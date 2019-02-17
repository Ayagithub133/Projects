using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Linq.Mapping;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Data;
using JobsWebSite.Models;
namespace JobsWebSite.DAL
{


    public class DataAccessLayer
    {
        /* Function of add new user */
        [Function(Name = "AddUser3")]
        public int AddUser3(UserProfile user)
        {
            SqlConnection con = null;
            int rows = 0;
            try
            {
                con = new SqlConnection("Data Source=.;Initial Catalog=JobsDataBase;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("AddUser3", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@firstname", user.FirstName);
                cmd.Parameters.AddWithValue("@lastname", user.LastName);
                cmd.Parameters.AddWithValue("@userpassword", user.UserPassword);
                cmd.Parameters.AddWithValue("@confirmpassword", user.ConfirmPassword);
                cmd.Parameters.AddWithValue("@email", user.Email);
                cmd.Parameters.AddWithValue("@usertype", user.UserType);
                // cmd.Parameters.AddWithValue("@userimage", null);
                con.Open();
              rows=  cmd.ExecuteNonQuery();
            }
            catch { }
            finally { con.Close(); }
            return rows;
        }
        /* Function of retrive user by password and email */
        [Function(Name = "LoginUser")]
        public UserProfile LoginUser(UserProfile user)
        {
            SqlConnection con = null;
            UserProfile userProfile = null;
            try
            {
                con = new SqlConnection("Data Source=.;Initial Catalog=JobsDataBase;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("LoginUser", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@password", user.UserPassword);
                cmd.Parameters.AddWithValue("@email", user.Email);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    userProfile = new UserProfile();
                    userProfile.FirstName = reader["FirstName"].ToString();
                    userProfile.LastName = reader["LastName"].ToString();
                    userProfile.Email = reader["Email"].ToString();
                    userProfile.UserPassword = reader["UserPassword"].ToString();
                    userProfile.ConfirmPassword = reader["ConfirmPassword"].ToString();
                    userProfile.UserType = reader["UserType"].ToString();
                    //userProfile.UserImage = reader["UserImage"].ToString();
                    userProfile.Id = (int)reader["Id"];
                    return userProfile;
                        
                }
            }
            catch { }
            finally { con.Close(); }
            return userProfile;
        }


        /* Function of retrive user */
        [Function(Name = "RetriveUser")]
        public UserProfile RetriveUser(int id)
        {
            SqlConnection con = null;
            UserProfile userProfile = null;
            try
            {
                con = new SqlConnection("Data Source=.;Initial Catalog=JobsDataBase;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("RetriveUser", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    userProfile = new UserProfile();
                    userProfile.FirstName = reader["FirstName"].ToString();
                    userProfile.LastName = reader["LastName"].ToString();
                    userProfile.Email = reader["Email"].ToString();
                    //userProfile.UserPassword = reader["UserPassword"].ToString();
                    //userProfile.ConfirmPassword = reader["ConfirmPassword"].ToString();
                    userProfile.UserType = reader["UserType"].ToString();
                    //userProfile.UserImage = reader["UserImage"].ToString();
                    return userProfile;

                }
            }
            catch { }
            finally { con.Close(); }
            return userProfile;
        }
        [Function(Name = "EditUser")]
        public int EditUser(UserProfile user)
        {
            SqlConnection con = null;
            int state=0;
            try
            {
                con = new SqlConnection("Data Source=.;Initial Catalog=JobsDataBase;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("EditUser", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@firstname", user.FirstName);
                cmd.Parameters.AddWithValue("@lastname", user.LastName);
                cmd.Parameters.AddWithValue("@newpass", user.UserPassword);
                cmd.Parameters.AddWithValue("@confirmpass", user.ConfirmPassword);
                cmd.Parameters.AddWithValue("@email", user.Email);
                cmd.Parameters.AddWithValue("@currentpass", user.CurrentPass);
                cmd.Parameters.AddWithValue("@id", user.Id);
                con.Open();
                state = cmd.ExecuteNonQuery();
                
            }
            catch { }
            finally { con.Close(); }
            return state;
        }
    }
    public class DAL_Category
    {
        /////////////create category////////////
        [Function(Name = "AddCategory")]
        public void AddCategory(Category category)
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection("Data Source=.;Initial Catalog=JobsDataBase;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("AddCategory", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@categoryname", category.CategoryName);
                cmd.Parameters.AddWithValue("@id", category.Id);
                cmd.Parameters.AddWithValue("@categorydescription", category.CategoryDescription);
                con.Open();
                cmd.ExecuteScalar();
            }
            catch { }
            finally { con.Close(); }
        }
        /////////////////edit category//////////////
        [Function(Name = "EditCategory")]
        public void EditCategory(Category category)
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection("Data Source=.;Initial Catalog=JobsDataBase;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("EditCategory", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@categoryname", category.CategoryName);
                cmd.Parameters.AddWithValue("@categorydescription", category.CategoryDescription);
                cmd.Parameters.AddWithValue("@id", category.Id);
                con.Open();
                cmd.ExecuteScalar();
            }
            catch { }
            finally { con.Close(); }
        }
        ////////////////////delete category////////
        [Function(Name = "DeleteCategory")]
        public void DeleteCategory(int id)
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection("Data Source=.;Initial Catalog=JobsDataBase;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("DeleteCategory", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteScalar();
            }
            catch { }
            finally { con.Close(); }
        }
        ////////////////retrive all category////////
        [Function(Name = "RetriveAllCategories")]
        public List<Category> RetriveAllCategories()
        {
            SqlConnection con = null;
            List<Category> Categories = new List<Category>();
            Category category = null;
            DAL_Job dal_job = new DAL_Job();
            try
            {
                con = new SqlConnection("Data Source=.;Initial Catalog=JobsDataBase;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("RetriveAllCategories", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    category = new Category();
                    category.CategoryName = reader["CategoryName"].ToString();
                    category.CategoryDescription = reader["CategoryDescription"].ToString();
                    category.Id = Convert.ToInt32(reader["Id"]);
                    category.Jobs = dal_job.JobsOfEachCategory(Convert.ToInt32(reader["Id"]));
                    Categories.Add(category);

                }
                return Categories;

            }
            catch { }
            finally { con.Close(); }
            return Categories;
        }
        ///////////////////////retrive names of category/////////////////
        [Function(Name = "NamesOfCategories")]
        public List<string> NamesOfCategories()
        {
            SqlConnection con = null;
            List<string> nameOfCategory = new List<string>();
            Category category = null;

            try
            {
                con = new SqlConnection("Data Source=.;Initial Catalog=JobsDataBase;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("NamesOfCategories", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    category = new Category();
                    category.CategoryName = reader["CategoryName"].ToString();

                    nameOfCategory.Add(category.CategoryName);

                }
                return nameOfCategory;

            }
            catch { }
            finally { con.Close(); }
            return nameOfCategory;
        }
        ////////////////retrive category by id////////
        [Function(Name = "RetriveById")]
        public Category RetriveById(int id)
        {
            SqlConnection con = null;

            Category category = new Category(); ;
            try
            {
                con = new SqlConnection("Data Source=.;Initial Catalog=JobsDataBase;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("RetriveById", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    category.CategoryName = reader["CategoryName"].ToString();
                    category.CategoryDescription = reader["CategoryDescription"].ToString();
                    category.Id = Convert.ToInt32(reader["Id"]);


                }
                return category;

            }
            catch { }
            finally { con.Close(); }
            return category;
        }

    }
    //////jobs/////////////////////////////////////////////////////
    public class DAL_Job
    {
        //////////Retrive All Jobs/////////////
        [Function(Name = "RetriveAllJobs")]
        public List<Jobs> RetriveAllJobs()
        {
            SqlConnection con = null;
            List<Jobs> AllJobs = new List<Jobs>();
            Jobs job = null;
            try
            {
                con = new SqlConnection("Data Source=.;Initial Catalog=JobsDataBase;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("RetriveAllJobs", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    job = new Jobs();
                    job.JobTitle = reader["JobTitle"].ToString();
                    job.JobDescription = reader["JobDescription"].ToString();
                    job.JobImage = reader["JobImage"].ToString();
                    job.CategoryId = Convert.ToInt32(reader["CategoryId"]);
                    job.Id = Convert.ToInt32(reader["Id"]);

                    AllJobs.Add(job);
                }
                return AllJobs;
            }
            catch { }
            finally { con.Close(); }
            return AllJobs;
        }
        /////////////Retrive Job By id
        [Function(Name = "RetriveJobById")]
        public Jobs RetriveJobById(int id)
        {
            SqlConnection con = null;
            Jobs job = null;
            try
            {
                con = new SqlConnection("Data Source=.;Initial Catalog=JobsDataBase;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("RetriveJobById", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    job = new Jobs();
                    job.JobTitle = reader["JobTitle"].ToString();
                    job.JobDescription = reader["JobDescription"].ToString();
                    job.JobImage = reader["JobImage"].ToString();
                    job.CategoryId = Convert.ToInt32(reader["CategoryId"]);
                    job.Id = Convert.ToInt32(reader["Id"]);

                }
                return job;
            }
            catch { }
            return job;
        }
        ///////////add job/////////
        [Function(Name = "AddJob")]
        public void AddJob(Jobs job)
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection("Data Source=.;Initial Catalog=JobsDataBase;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("AddJob", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@jobtitle", job.JobTitle);
                cmd.Parameters.AddWithValue("@jobdescription", job.JobDescription);
                cmd.Parameters.AddWithValue("@jobimage", job.JobImage);
                cmd.Parameters.AddWithValue("@categoryid", job.CategoryId);
                cmd.Parameters.AddWithValue("@publisherid", job.Publisher);
                con.Open();
                cmd.ExecuteScalar();
            }
            catch { }
            finally
            {
                con.Close();
            }
        }
        //////////////Edit Job///////////////
        [Function(Name = "EditJob")]
        public void EditJob(Jobs job)
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection("Data Source=.;Initial Catalog=JobsDataBase;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("EditJob", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", job.Id);
                cmd.Parameters.AddWithValue("@jobtitle", job.JobTitle);
                cmd.Parameters.AddWithValue("@jobdescription", job.JobDescription);
                cmd.Parameters.AddWithValue("@jobimage", job.JobImage);
                cmd.Parameters.AddWithValue("@categoryid", job.CategoryId);
                con.Open();
                cmd.ExecuteScalar();
            }
            catch { }
            finally { con.Close(); }
        }
        //////////////////////////Delete Job///////////////////
        [Function(Name = "DeleteJob")]
        public void DeleteJob(int id)
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection("Data Source=.;Initial Catalog=JobsDataBase;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("DeleteJob", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteScalar();
            }
            catch { }
            finally { con.Close(); }
        }
        [Function(Name = "JobsOfEachCategory")]
        public List<Jobs> JobsOfEachCategory(int id)
        {
            SqlConnection con = null;
            Jobs job = null;
            List<Jobs> jobs = new List<Jobs>();
            try
            {
                con = new SqlConnection("Data Source=.;Initial Catalog=JobsDataBase;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("JobsOfEachCategory", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@cateid", id);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    job = new Jobs();
                    job.JobTitle = reader["JobTitle"].ToString();
                    job.JobDescription = reader["JobDescription"].ToString();
                    job.JobImage = reader["JobImage"].ToString();
                    job.CategoryId = Convert.ToInt32(reader["CategoryId"]);
                    

                    jobs.Add(job);
                }
                return jobs;
            }
            catch { }
            finally { con.Close(); }
            return jobs;
        }
        [Function(Name = "Search")]
        public List<Jobs> SearchForJobs(string SearchName)
        {
            SqlConnection con = null;
            Jobs job = null;
            List<Jobs> jobs = new List<Jobs>();
            try
            {
                con = new SqlConnection("Data Source=.;Initial Catalog=JobsDataBase;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("Search", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@content", SearchName);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    job = new Jobs();
                    job.JobImage = reader["JobImage"].ToString();
                    job.JobTitle = reader["JobTitle"].ToString();
                    job.JobDescription = reader["JobDescription"].ToString();
                    job.Id = Convert.ToInt32(reader["Id"]);
                    jobs.Add(job);

                }
                return jobs;
            }
            catch { }
            finally { con.Close(); }
            return jobs;
        }


    }
    public class DAL_Roles
    {
        ////////////////retrive all roles///////////
        [Function(Name = "AllRoles")]
        public List<string> AllRoles()
        {
            SqlConnection con = null;
            Role role = null;
            List<string> Roles = new List<string>();
            try
            {
                con = new SqlConnection("Data Source=.;Initial Catalog=JobsDataBase;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("AllRoles", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    role = new Role();
                    role.RoleName = reader["RoleName"].ToString();
                    Roles.Add(role.RoleName);
                }
                return Roles;
            }
            catch { }
            finally { con.Close(); }
            return Roles;
        }
        [Function(Name = "AllRoles")]
        public List<Role> AllRolesObjects()
        {
            SqlConnection con = null;
            Role role = null;
            List<Role> Roles = new List<Role>();
            try
            {
                con = new SqlConnection("Data Source=.;Initial Catalog=JobsDataBase;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("AllRoles", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    role = new Role();
                    role.RoleName = reader["RoleName"].ToString();
                    role.Id = Convert.ToInt32(reader["Id"]);
                    Roles.Add(role);
                }
                return Roles;
            }
            catch { }
            finally { con.Close(); }
            return Roles;
        }
        /////////////////////role details/////////////////
        [Function(Name = "RoleDetails")]
        public Role RoleDetails(int id)
        {
            SqlConnection con = null;
            Role role = null;

            try
            {
                con = new SqlConnection("Data Source=.;Initial Catalog=JobsDataBase;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("RoleDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    role = new Role();
                    role.RoleName = reader["RoleName"].ToString();


                }
                return role;
            }
            catch { }
            finally { con.Close(); }
            return role;
        }
        /////////////////////remove role/////////////////
        [Function(Name = "RemoveRole")]
        public void RemoveRole(int id)
        {
            SqlConnection con = null;


            try
            {
                con = new SqlConnection("Data Source=.;Initial Catalog=JobsDataBase;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("RemoveRole", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteScalar();

            }
            catch { }
            finally { con.Close(); }

        }
        /////////////////////Edit role/////////////////
        [Function(Name = "EditRole")]
        public void EditRole(Role role)
        {
            SqlConnection con = null;


            try
            {
                con = new SqlConnection("Data Source=.;Initial Catalog=JobsDataBase;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("EditRole", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", role.Id);
                cmd.Parameters.AddWithValue("@rolename", role.RoleName);
                con.Open();
                cmd.ExecuteScalar();

            }
            catch { }
            finally { con.Close(); }

        }
        ///////////////////////Add Role///////////////
        [Function(Name = "Roles")]
        public void Roles(Role role)
        {
            SqlConnection con = null;


            try
            {
                con = new SqlConnection("Data Source=.;Initial Catalog=JobsDataBase;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("Roles", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", role.Id);
                cmd.Parameters.AddWithValue("@rolename", role.RoleName);
                con.Open();
                cmd.ExecuteScalar();

            }
            catch { }
            finally { con.Close(); }

        }



    }
    ////////////apply to job////////////
    public class Apply
    {
        [Function(Name = "ApplyToJob")]
        public void ApplyToJob(ApplierForJob applier)
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection("Data Source=.;Initial Catalog=JobsDataBase;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("ApplyToJob", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@resala", applier.Resala);
                cmd.Parameters.AddWithValue("@applydate", applier.ApplyDate);
                cmd.Parameters.AddWithValue("@jobid", applier.JobId);
                cmd.Parameters.AddWithValue("@applierid", applier.ApplierId);
                con.Open();
                cmd.ExecuteScalar();
            }
            catch{}
            finally
            {
                con.Close();}
                
            }
        }
    public class DAL_ApplyForJob
    {
        [Function(Name = "JobsOfUser")]
        public List<Jobs> JobsOfUser(int userid)
        {
            SqlConnection con = null;
            Jobs job = null;
            List<Jobs> listofjobs = new List<Jobs>();
            try
            {
                con = new SqlConnection("Data Source=.;Initial Catalog=JobsDataBase;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("JobsOfUser", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@userid", userid);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    job = new Jobs();
                    job.JobTitle = reader["JobTitle"].ToString();
                    job.applierForJob = JobApplyInfo(Convert.ToInt32(reader["Id"]),userid);
                    listofjobs.Add(job);
                }
                return listofjobs;
            }
            catch { }
            finally{con.Close();}
            return listofjobs;
        }
        [Function(Name = "JobApplyInfo")]
        public ApplierForJob JobApplyInfo(int jobid,int userid)
        {
            SqlConnection con = null;
            ApplierForJob Applier = null;

            try
            {
                con = new SqlConnection("Data Source=.;Initial Catalog=JobsDataBase;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("JobApplyInfo", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@jobid", jobid);
                cmd.Parameters.AddWithValue("@userid", userid);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Applier = new ApplierForJob();
                    Applier.Resala = reader["Resala"].ToString();
                    Applier.ApplyDate = (DateTime)reader["ApplyDate"];
                }
                return Applier;


            }
            catch { }
            finally { con.Close(); }
            return Applier;
        }
        //////// GetJobsByPublisher/////
        //[Function(Name = "GetJobsByPublisher")]
        //public List<ApplierForJob> GetJobsByPublisher(int userid)
        //{
        //    SqlConnection con = null;
        //    ApplierForJob applier = null;
        //    List<ApplierForJob> appliers = new List<ApplierForJob>();
        //    try
        //    {
        //        con = new SqlConnection("Data Source=.;Initial Catalog=JobsDataBase;Integrated Security=True");
        //        SqlCommand cmd = new SqlCommand("GetJobsByPublisher", con);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@publisherid", userid);
        //        con.Open();
        //        SqlDataReader reader = cmd.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            applier = new ApplierForJob();
        //            applier.Resala = reader["Resala"].ToString();
        //            applier.ApplyDate = (DateTime)reader["ApplyDate"];
        //            applier.jobtitle.JobTitle = reader["JobTitle"].ToString();
        //            //applier.user_profile.FirstName = reader["FirstName"].ToString();
        //            appliers.Add(applier);
        //        }
        //        return appliers;
        //    }
        //    catch { }
        //    finally { con.Close(); }
        //    return appliers;
        //}
        [Function(Name = "GetJobsByPublisher")]
        public List<JobsViewModel> GetJobsByPublisher(int userid)
        {
            SqlConnection con = null;
            //ApplierForJob applier = null;
            //List<ApplierForJob> appliers = new List<ApplierForJob>();
            JobsViewModel jobmodel = null;
            List<JobsViewModel> modellist = new List<JobsViewModel>();

            try
            {
                con = new SqlConnection("Data Source=.;Initial Catalog=JobsDataBase;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("GetJobsByPublisher", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@publisherid", userid);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                        //applier = new ApplierForJob();
                        jobmodel = new JobsViewModel();
                        //applier.Resala = reader["Resala"].ToString();
                        //applier.ApplyDate = (DateTime)reader["ApplyDate"];
                        jobmodel.Resala = reader["Resala"].ToString();
                        jobmodel.ApplyDate = (DateTime)reader["ApplyDate"];
                        jobmodel.FullName = reader["FullName"].ToString();

                        jobmodel.JobTitle = reader["JobTitle"].ToString();
                        //jobmodel.items = appliers;
                        modellist.Add(jobmodel);
                    
                }
                return modellist;
            }
            catch { }
            finally { con.Close(); }
            return modellist;
        }
      
    }
    }




    

