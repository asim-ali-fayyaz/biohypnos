using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entites;
using static System.Formats.Asn1.AsnWriter;
using System.Reflection;

namespace DAL
{
    public class DalCRUD
    {
        public static string Registration(EntRegistration er)
        {
            using (SqlConnection connection = DBHelper.GetConnection())
            {
                using (SqlCommand command = new SqlCommand("SP_Registration", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    // Add parameters
                    command.Parameters.AddWithValue("@FirstName", er.FirstName);
                    command.Parameters.AddWithValue("@LastName", er.LastName);
                    command.Parameters.AddWithValue("@EmailAddress", er.Email);
                    command.Parameters.AddWithValue("@UserPassword", er.Password);
                    SqlParameter resultParameter = new SqlParameter("@Result", SqlDbType.NVarChar, 50);
                    resultParameter.Direction = ParameterDirection.Output;
                    command.Parameters.Add(resultParameter);
                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        string? result = resultParameter.Value.ToString();
                        return result;
                    }
                    catch (SqlException ex)
                    {
                        // Handle SQL Server exceptions
                        Console.WriteLine("SQL Server Exception: " + ex.Message);
                        return "";
                    }

                }
            }
        }
        public static EntRegistration Auth(EntRegistration er)
        {
            using (SqlConnection connection = DBHelper.GetConnection())
            {
                using (SqlCommand command = new SqlCommand("SP_Auth", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    // Add parameters

                    command.Parameters.AddWithValue("@EmailAddress", er.Email);
                    command.Parameters.AddWithValue("@UserPassword", er.Password);

                    try
                    {
                        connection.Open();
                        EntRegistration entRegistration = new EntRegistration();
                        SqlDataReader srd = command.ExecuteReader();
                        while (srd.Read())
                        {

                            entRegistration.LastName = srd["LastName"].ToString();
                            entRegistration.UserId = srd["UserID"].ToString();
                            entRegistration.Role = srd["Role"].ToString();
                        }
                        return entRegistration;
                    }
                    catch (SqlException ex)
                    {
                        // Handle SQL Server exceptions
                        Console.WriteLine("SQL Server Exception: " + ex.Message);
                        return new EntRegistration();

                    }

                }
            }
        }
        public static int SaveDemographic(EntDemographic ed)
        {
            using (SqlConnection connection = DBHelper.GetConnection())
            {
                using (SqlCommand command = new SqlCommand("SP_Demographic", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    // Add parameters
                    command.Parameters.AddWithValue("@UserID", ed.UserId);
                    command.Parameters.AddWithValue("@Gender", ed.Gender);
                    command.Parameters.AddWithValue("@Race", ed.Race);
                    command.Parameters.AddWithValue("@Ethnicity", ed.Ethnicity);
                    command.Parameters.AddWithValue("@NeckSize", ed.NeckSize);
                    command.Parameters.AddWithValue("@BMI", Convert.ToDouble(ed.BMI));

                    try
                    {
                        connection.Open();
                        int result = command.ExecuteNonQuery();
                        return result;
                    }
                    catch (SqlException ex)
                    {
                        // Handle SQL Server exceptions
                        Console.WriteLine("SQL Server Exception: " + ex.Message);
                        return 0;
                    }

                }
            }
        }

        public static int SavePastHistory(EntPastHistory ep)
        {
            using (SqlConnection connection = DBHelper.GetConnection())
            {
                using (SqlCommand command = new SqlCommand("SP_SavePastHistory", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    // Add parameters
                    command.Parameters.AddWithValue("@fk_UserId", ep.UserId);
                    command.Parameters.AddWithValue("@MedicalCondition", ep.MedicalCondition);
                    command.Parameters.AddWithValue("@PastSurgery", ep.PastSurgery);
                    command.Parameters.AddWithValue("@PastSurgeryDetails", ep.PastSurgeryDetails);
                    command.Parameters.AddWithValue("@Smoke", ep.Smoke);
                    command.Parameters.AddWithValue("@AlcoholUse", ep.AlcoholUse);
                    command.Parameters.AddWithValue("@IllegalDrugUse", ep.IllegalDrugUse);
                    command.Parameters.AddWithValue("@DrugsCurrentlyUse", ep.DrugsCurrentlyUse);
                    command.Parameters.AddWithValue("@FamilySleepDisorders", ep.FamilySleepDisorders);
                    command.Parameters.AddWithValue("@Medications", ep.Medications);
                    command.Parameters.AddWithValue("@MedicationsAllergic", ep.MedicationsAllergic);
                    command.Parameters.AddWithValue("@AllergicReactionTypes", ep.AllergicReactionTypes);


                    try
                    {
                        connection.Open();
                        int result = command.ExecuteNonQuery();
                        return result;
                    }
                    catch (SqlException ex)
                    {
                        // Handle SQL Server exceptions
                        Console.WriteLine("SQL Server Exception: " + ex.Message);
                        return 0;
                    }

                }
            }
        }

        public static int SaveExpertevaluation(EntExpertevaluation ep)
        {
            using (SqlConnection connection = DBHelper.GetConnection())
            {
                using (SqlCommand command = new SqlCommand("SP_SaveExpertevaluation", connection))
                {
                    Type objetype = ep.GetType();
                    PropertyInfo[] properties = objetype.GetProperties();

                    List<SqlParameter> sqlParameters = new List<SqlParameter>();
                    foreach (var item in properties)
                    {
                        sqlParameters.Add(new SqlParameter($"@{item.Name}", item.GetValue(ep)));

                    }
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddRange(sqlParameters.ToArray());
                    try
                    {
                        connection.Open();
                        int result = command.ExecuteNonQuery();
                        return result;
                    }
                    catch (SqlException ex)
                    {
                        // Handle SQL Server exceptions
                        Console.WriteLine("SQL Server Exception: " + ex.Message);
                        return 0;
                    }

                }
            }
        }
        public static int SaveSleepApnea(EntSleepApnea ep)
        {
            using (SqlConnection connection = DBHelper.GetConnection())
            {
                using (SqlCommand command = new SqlCommand("SP_SaveSleepApnea", connection))
                {
                    Type objetype = ep.GetType();
                    PropertyInfo[] properties = objetype.GetProperties();

                    List<SqlParameter> sqlParameters = new List<SqlParameter>();
                    foreach (var item in properties)
                    {
                        sqlParameters.Add(new SqlParameter($"@{item.Name}", item.GetValue(ep)));

                    }
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddRange(sqlParameters.ToArray());
                    try
                    {
                        connection.Open();
                        int result = command.ExecuteNonQuery();
                        return result;
                    }
                    catch (SqlException ex)
                    {
                        // Handle SQL Server exceptions
                        Console.WriteLine("SQL Server Exception: " + ex.Message);
                        return 0;
                    }

                }
            }
        }
        public static int SaveTobacco(EntTobacco ep)
        {
            using (SqlConnection connection = DBHelper.GetConnection())
            {
                using (SqlCommand command = new SqlCommand("SP_SaveTobaccoCessation", connection))
                {
                    Type objetype = ep.GetType();
                    PropertyInfo[] properties = objetype.GetProperties();

                    List<SqlParameter> sqlParameters = new List<SqlParameter>();
                    foreach (var item in properties)
                    {
                        sqlParameters.Add(new SqlParameter($"@{item.Name}", item.GetValue(ep)));

                    }
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddRange(sqlParameters.ToArray());
                    try
                    {
                        connection.Open();
                        int result = command.ExecuteNonQuery();
                        return result;
                    }
                    catch (SqlException ex)
                    {
                        // Handle SQL Server exceptions
                        Console.WriteLine("SQL Server Exception: " + ex.Message);
                        return 0;
                    }

                }
            }
        }
        public static int SaveLegMovements(EntLegMovements ep)
        {
            using (SqlConnection connection = DBHelper.GetConnection())
            {
                using (SqlCommand command = new SqlCommand("SP_SaveLegMovements", connection))
                {
                    Type objetype = ep.GetType();
                    PropertyInfo[] properties = objetype.GetProperties();

                    List<SqlParameter> sqlParameters = new List<SqlParameter>();
                    foreach (var item in properties)
                    {
                        sqlParameters.Add(new SqlParameter($"@{item.Name}", item.GetValue(ep)));

                    }
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddRange(sqlParameters.ToArray());
                    try
                    {
                        connection.Open();
                        int result = command.ExecuteNonQuery();
                        return result;
                    }
                    catch (SqlException ex)
                    {
                        // Handle SQL Server exceptions
                        Console.WriteLine("SQL Server Exception: " + ex.Message);
                        return 0;
                    }

                }
            }
        }
        public static int SaveExcessiveSleepiness(EntExcessiveSleepiness ep)
        {
            using (SqlConnection connection = DBHelper.GetConnection())
            {
                using (SqlCommand command = new SqlCommand("SP_SaveExcessiveSleepiness", connection))
                {
                    Type objetype = ep.GetType();
                    PropertyInfo[] properties = objetype.GetProperties();

                    List<SqlParameter> sqlParameters = new List<SqlParameter>();
                    foreach (var item in properties)
                    {
                        sqlParameters.Add(new SqlParameter($"@{item.Name}", item.GetValue(ep)));

                    }
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddRange(sqlParameters.ToArray());
                    try
                    {
                        connection.Open();
                        int result = command.ExecuteNonQuery();
                        return result;
                    }
                    catch (SqlException ex)
                    {
                        // Handle SQL Server exceptions
                        Console.WriteLine("SQL Server Exception: " + ex.Message);
                        return 0;
                    }

                }
            }
        }


        public static List<EntPatientsInfo> GetPatientsInfo()
        {
            using (SqlConnection connection = DBHelper.GetConnection())
            {
                using (SqlCommand command = new SqlCommand("SP_GetPatientsInfo", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    try
                    {
                        connection.Open();
                        List<EntPatientsInfo> ListPatientsInfo = new List<EntPatientsInfo>();
                        SqlDataReader srd = command.ExecuteReader();
                        while (srd.Read())
                        {

                            EntPatientsInfo entPatientsInfo = new EntPatientsInfo();
                            entPatientsInfo.UserId = srd["UserId"].ToString();
                            entPatientsInfo.FirstName = srd["FirstName"].ToString();
                            entPatientsInfo.LastName = srd["LastName"].ToString();
                            entPatientsInfo.Gender = srd["Gender"].ToString();
                            entPatientsInfo.Email = srd["EmailAddress"].ToString();
                            entPatientsInfo.Race = srd["Race"].ToString();
                            entPatientsInfo.Ethnicity = srd["Ethnicity"].ToString();
                            entPatientsInfo.NeckSize = srd["NeckSize"].ToString();
                            entPatientsInfo.BMI = srd["BMI"].ToString();
                            entPatientsInfo.CreationDateTime = srd["CreationDateTime"].ToString();
                            ListPatientsInfo.Add(entPatientsInfo);
                        }
                        return ListPatientsInfo;
                    }
                    catch (SqlException ex)
                    {
                        // Handle SQL Server exceptions
                        Console.WriteLine("SQL Server Exception: " + ex.Message);
                        return new List<EntPatientsInfo>();

                    }

                }
            }
        }

        public static EntDetails GetUserAccountById(string id)
        {
            using (SqlConnection connection = DBHelper.GetConnection())
            {
                using (SqlCommand command = new SqlCommand("SP_GetUserDetailsById", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    // Add parameters

                    command.Parameters.AddWithValue("@fk_UserId", id);

                    try
                    {
                        connection.Open();
                        EntDetails entdetails = new EntDetails();
                        SqlDataReader srd = command.ExecuteReader();
                        while (srd.Read())
                        {

                            entdetails.UserId = srd["UserId"].ToString();
                            entdetails.FirstName = srd["FirstName"].ToString();
                            entdetails.LastName = srd["LastName"].ToString();
                            entdetails.Gender = srd["Gender"].ToString();
                            entdetails.Email = srd["EmailAddress"].ToString();
                            entdetails.Race = srd["Race"].ToString();
                            entdetails.Ethnicity = srd["Ethnicity"].ToString();
                            entdetails.NeckSize = srd["NeckSize"].ToString();
                            entdetails.BMI = srd["BMI"].ToString();
                         

                            entdetails.MedicalCondition = srd["MedicalCondition"].ToString();
                            entdetails.PastSurgery = srd["PastSurgery"].ToString();
                            entdetails.PastSurgeryDetails = srd["PastSurgeryDetails"].ToString();
                            entdetails.Smoke = srd["Smoke"].ToString();
                            entdetails.AlcoholUse = srd["AlcoholUse"].ToString();
                            entdetails.IllegalDrugUse = srd["IllegalDrugUse"].ToString();
                            entdetails.DrugsCurrentlyUse = srd["DrugsCurrentlyUse"].ToString();
                            entdetails.FamilySleepDisorders = srd["FamilySleepDisorders"].ToString();
                            entdetails.Medications = srd["Medications"].ToString();
                            entdetails.MedicationsAllergic = srd["MedicationsAllergic"].ToString();
                            entdetails.AllergicReactionTypes = srd["AllergicReactionTypes"].ToString();




                            entdetails.SittingAndReading = srd["SittingAndReading"].ToString();
                            entdetails.SittingAndWatchingTV = srd["SittingAndWatchingTV"].ToString();
                            entdetails.SittingInactiveInPublic = srd["SittingInactiveInPublic"].ToString();
                            entdetails.AsaPassengerCar = srd["AsaPassengerCar"].ToString();
                            entdetails.LyingDown = srd["LyingDown"].ToString();
                            entdetails.SittingTalking = srd["SittingTalking"].ToString();
                            entdetails.SittingQuietfly = srd["SittingQuietfly"].ToString();
                            entdetails.WhileStopped = srd["WhileStopped"].ToString();





                        }
                        return entdetails;
                    }
                    catch (SqlException ex)
                    {
                        // Handle SQL Server exceptions
                        Console.WriteLine("SQL Server Exception: " + ex.Message);
                        return new EntDetails();

                    }

                }
            }
        }

        public static int SaveFeedBack(EntFeedBack fb)
        {
            using (SqlConnection connection = DBHelper.GetConnection())
            {
                using (SqlCommand command = new SqlCommand("SP_SaveFeedBack", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    // Add parameters
                    command.Parameters.AddWithValue("@UserName", fb.UserName);
                    command.Parameters.AddWithValue("@Email", fb.Email);
                    command.Parameters.AddWithValue("@UserFeedBack", fb.Feedback); 
                    try
                    {
                        connection.Open();
                        int result = command.ExecuteNonQuery();
                        return result;
                    }
                    catch (SqlException ex)
                    {
                        // Handle SQL Server exceptions
                        Console.WriteLine("SQL Server Exception: " + ex.Message);
                        return 0;
                    }

                }
            }
        }

        public static List<EntFeedBack> GetAllFeedback()
        {
            using (SqlConnection connection = DBHelper.GetConnection())
            {
                using (SqlCommand command = new SqlCommand("SP_GetAllFeedback", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    try
                    {
                        connection.Open();
                        List<EntFeedBack> ListFeedBack = new List<EntFeedBack>();
                        SqlDataReader srd = command.ExecuteReader();
                        while (srd.Read())
                        {

                            EntFeedBack entFeedBack = new EntFeedBack();
                            entFeedBack.UserName = srd["UserName"].ToString();                           
                            entFeedBack.Email = srd["Email"].ToString();
                            entFeedBack.Feedback = srd["UserFeedBack"].ToString();
                            entFeedBack.DateTime = srd["FeedBackDateTime"].ToString();
                            ListFeedBack.Add(entFeedBack);
                        }
                        return ListFeedBack;
                    }
                    catch (SqlException ex)
                    {
                        // Handle SQL Server exceptions
                        Console.WriteLine("SQL Server Exception: " + ex.Message);
                        return new List<EntFeedBack>();

                    }

                }
            }
        }
    }
}

