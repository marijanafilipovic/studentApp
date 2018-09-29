using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using BaseStudentApp.Models;
using BaseStudentApp.ViewModel;
using System.Data.Entity;


namespace BaseStudentApp.Repository
{
    public class StudentRepository
    {
 
        private SqlConnection con;
        private void connection()
        {
            string connString = ConfigurationManager.ConnectionStrings["StudentDB"].ToString();
            con = new SqlConnection(connString);
        }
      
        public bool addStudent(Student student) 
        {
            connection();
            SqlCommand com = new SqlCommand("createStudent", con);
            com.CommandType = CommandType.StoredProcedure;
           // com.Parameters.AddWithValue("@IdStudent", "");
            com.Parameters.AddWithValue("@BiStudent", student.BiStudent);
            com.Parameters.AddWithValue("@sName", student.sName);
            com.Parameters.AddWithValue("@sLastname", student.sLastname);
            com.Parameters.AddWithValue("@City", student.City);

            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if(i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
 
        public List<Student> getStudent()
        {
            connection();
            List<Student> studentList = new List<Student>();

            SqlCommand com = new SqlCommand("getStudent", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapt = new SqlDataAdapter(com);
            DataTable dt = new System.Data.DataTable();

            con.Open();
            adapt.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                studentList.Add(
                    new Student
                    {
                        IdStudent = Convert.ToInt32(dr["IdStudent"]),
                        BiStudent = Convert.ToString(dr["BiStudent"]),
                        sName = Convert.ToString(dr["sName"]),
                        sLastname = Convert.ToString(dr["sLastname"]),
                        City = Convert.ToString(dr["City"])

                    }
                    );
            }
            return studentList;
        }

        public bool UpdateStudent(Student student)
        {
            connection();
            SqlCommand com = new SqlCommand("UpdateStudentDetails", con);

            com.CommandType = System.Data.CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@IdStudent", student.IdStudent);
            com.Parameters.AddWithValue("@BiStudent", student.BiStudent);
            com.Parameters.AddWithValue("@sName", student.sName);
            com.Parameters.AddWithValue("@sLastname", student.sLastname);
            com.Parameters.AddWithValue("@City", student.City);

            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if(i >=1)
            {
                return true;
            }
            else
            {
                return false;
            }


        }
        public Student getSingleStudent(int? IdStudent)
        {
            connection();
            Student student = new Student();
            string qSingleStudentData = "SELECT * FROM Student WHERE IdStudent=" + IdStudent;
            SqlCommand comm = new SqlCommand(qSingleStudentData, con);
            con.Open();
            SqlDataReader readSingleStudent = comm.ExecuteReader();

            while(readSingleStudent.Read())
            {
                student.IdStudent = Convert.ToInt32(readSingleStudent["IdStudent"]);
                student.BiStudent = readSingleStudent["BiStudent"].ToString();
                student.sName = readSingleStudent["sName"].ToString();
                student.sLastname = readSingleStudent["sLastname"].ToString();
                student.City = readSingleStudent["City"].ToString();
            }
            return student;
        }
        public bool deleteStudent(int? IdStudent)
        {
            connection();
            SqlCommand com = new SqlCommand("deleteStudent", con);

            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.AddWithValue("@IdStudent", IdStudent);

            con.Open();
            int i = com.ExecuteNonQuery();
           // com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }


        }
        
       
    }
}