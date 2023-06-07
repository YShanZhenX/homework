using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.ComponentModel;
using System.Configuration;
using System.Drawing;
using System.Threading.Tasks;


namespace 学生成绩查询管理系统
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int choice = 0;
            Console.WriteLine("**************************************************");
            Console.WriteLine("*********     欢迎进入教务管理系统        ********");
            Console.WriteLine("*********        请选择你的身份           ********");
            Console.WriteLine("*********          1--管理员              ********");
            Console.WriteLine("*********          2--学 生               ********");
            Console.WriteLine("*********          3--教 师               ********");
            Console.WriteLine("*********          0--退出系统            ********");
            Console.WriteLine("**************************************************");
            choice = int.Parse(Console.ReadLine());
            //密码验证
            while (true)
            {
                switch (choice)
                {
                    //管理员
                    case 1:
                        {
                            // authentication();扩展以后，可以对此函数对每个角色进行权限检查
                            Administrator();

                             //创建数据库连接
                            String connn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\xscjgl\\wcxsgl\\wcxsgl.mdf;Integrated Security=True;Connect Timeout=30"; //定义数据库连接信息
                            SqlConnection con14 = new SqlConnection(connn); 
                            con14.Open();
                            Console.WriteLine("**************************************************");
                            Console.WriteLine("***********        请输入工号        ***********：");
                            string strtxt1 = Console.ReadLine();
                            Console.WriteLine("***********        请输入密码        ***********：");
                            string strtxt2 = Console.ReadLine();
                            Console.WriteLine("**************************************************");
                            string command5 = "select count(ID) from [Administrator] where ID=" + strtxt1;//自定义sql查询语言  
                            SqlCommand mySqlCommand = new SqlCommand(command5, con14);
                            int m = Convert.ToInt32(mySqlCommand.ExecuteScalar());//把查询结果转换成数字，如果没有查询到相应MID的账号，查询结果为0 
                            if (m == 0)
                                Console.WriteLine("用户不存在");
                            else
                            {
                                command5 = "select count(ID) from [Administrator] where ID=" + strtxt1 + "and Password=" + strtxt2;
                                SqlCommand sql = new SqlCommand(command5, con14);//sqlcommand执行sql命令，注意函参  
                                int f = Convert.ToInt32(sql.ExecuteScalar());
                                if (f != 0)
                                {
                                    Console.WriteLine("成功");
                                }
                                else
                                {
                                    Console.WriteLine("密码错误");
                                }
                            }
                            break;
                        }
                    //case 2: 学生
                    case 2:
                        {  // authentication();扩展以后，可以对此函数对每个角色进行权限检查
                            Student();
                            SqlConnection con2 = new SqlConnection(); //创建数据库连接
                            String con = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\xscjgl\\wcxsgl\\wcxsgl.mdf;Integrated Security=True;Connect Timeout=30"; //定义数据库连接信息
                            con2.ConnectionString = con;
                            if (con2.State == ConnectionState.Closed)
                            { //打开链接
                                con2.Open();//打开数据库
                                Console.WriteLine("已连接到学生成绩查询管理系统数据库");
                            }
                            string sqlStr3 = "select * from dbo.Student();";
                            break;
                        }
                    // 老师
                    case 3:
                        { // authentication();扩展以后，可以对此函数对每个角色进行权限检查
                            Teacher();

                            SqlConnection con3 = new SqlConnection(); //创建数据库连接
                            String con = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\xscjgl\\wcxsgl\\wcxsgl.mdf;Integrated Security=True;Connect Timeout=30"; //定义数据库连接信息
                            con3.ConnectionString = con;
                            if (con3.State == ConnectionState.Closed)
                            {
                                //打开链接
                                con3.Open();//打开数据库
                                Console.WriteLine("已连接到学生成绩查询管理系统数据库");
                            }
                            string sqlStr3 = "select * from dbo.Teacher();";
                            break;
                        }
                    case 0:
                        return;
                    default:
                        {
                            Console.WriteLine("输入错误，请重新选择");
                            choice = int.Parse(Console.ReadLine());
                            break;
                        }

                }
            }
        }
    //学生相关的模块函数
        public static void Student()
        {
            int choice2 = 0;
            Console.WriteLine("*********         请选择你需要的操作      ********");
            Console.WriteLine("*********          1--浏览学生信息        ********");
            Console.WriteLine("*********          2--修改学生信息        ********");
            Console.WriteLine("*********          3--浏览学生成绩        ********");
            Console.WriteLine("*********          0--退出系统            ********");
            Console.WriteLine("**************************************************");
            choice2 = int.Parse(Console.ReadLine());
            switch(choice2)
            {
//已完成                //1.浏览学生信息
                case 1:
                    {
                        SqlConnection con1 = new SqlConnection(); //创建数据库连接
                        String con = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\xscjgl\\wcxsgl\\wcxsgl.mdf;Integrated Security=True;Connect Timeout=30"; //定义数据库连接信息
                        con1.ConnectionString = con;
                        if (con1.State == ConnectionState.Closed)
                        { //打开链接
                            con1.Open();//打开数据库
                            Console.WriteLine("已连接到学生成绩查询管理系统数据库");
                        }
                        string sqlStr = "select * from dbo.Student";
                        SqlCommand comm = new SqlCommand(sqlStr, con1);
                        SqlDataReader sdr = null;
                        try
                        {
                            Console.WriteLine("学号:      姓名:      性别:      年龄:      班级:");
                            sdr = comm.ExecuteReader();
                            while (sdr.Read())
                            {
                                Console.WriteLine(sdr["ID"].ToString() + "      " + sdr["Name"] + "      " + sdr["Sex"] + "      " + sdr["Age"].ToString() + "      " + sdr["Class"].ToString());
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        finally
                        {
                            con1.Close();
                        }
                        Console.Read();
                        con1.Close();
                        break;
                    }
                //-修改学生信息
                case 2:
                    {

                        break;
                    }
 //已完成               //浏览学生成绩
                case 3:
                    {
                        SqlConnection con15 = new SqlConnection(); //创建数据库连接
                        String con = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\xscjgl\\wcxsgl\\wcxsgl.mdf;Integrated Security=True;Connect Timeout=30"; //定义数据库连接信息
                        con15.ConnectionString = con;
                        if (con15.State == ConnectionState.Closed)
                        { //打开链接
                            con15.Open();//打开数据库
                            Console.WriteLine("已连接到学生成绩查询管理系统数据库");
                        }
                        string sqlStr = "select * from dbo.Score";
                        SqlCommand comm = new SqlCommand(sqlStr, con15);
                        SqlDataReader sdr = null;
                        try
                        {
                            Console.WriteLine("学号:  姓名:   语文:   数学:   英语:   物理：   化学：   生物：   历史：   政治：   地理：");
                            sdr = comm.ExecuteReader();
                            while (sdr.Read())
                            {
                                Console.WriteLine(sdr["ID"].ToString() + "   " + sdr["Name"] + "   " + sdr["Chinese"] + "     " + sdr["Maths"].ToString() + "      " + sdr["English"].ToString() + "      " + sdr["Physics"].ToString() + "      " + sdr["Chemistry"].ToString() + "        " + sdr["Biology"].ToString() + "       " + sdr["History"].ToString() + "       " + sdr["Politics"].ToString() + "      " + sdr["Geography"].ToString());
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        finally
                        {
                            con15.Close();
                        }
                        Console.Read();
                        con15.Close();
                        break;
                    }
            }

        }
        //学生相关的模块函数结束

        //老师相关的模块函数
        public static void Teacher()
        {
            int choice3 = 0;
            Console.WriteLine("*********         请选择你需要的操作      ********");
            Console.WriteLine("*********          1--浏览学生信息        ********");
            Console.WriteLine("*********          2--修改学生信息        ********");
            Console.WriteLine("*********          3--浏览学生成绩        ********");
            Console.WriteLine("*********          4--修改学生成绩        ********");
            Console.WriteLine("*********          0--退出系统            ********");
            Console.WriteLine("**************************************************");
            choice3 = int.Parse(Console.ReadLine());
            switch (choice3)
            {
  //已完成       //浏览学生信息          
                case 1:
                    {
                        SqlConnection con1 = new SqlConnection(); //创建数据库连接
                        String con = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\xscjgl\\wcxsgl\\wcxsgl.mdf;Integrated Security=True;Connect Timeout=30"; //定义数据库连接信息
                        con1.ConnectionString = con;
                        if (con1.State == ConnectionState.Closed)
                        { //打开链接
                            con1.Open();//打开数据库
                            Console.WriteLine("已连接到学生成绩查询管理系统数据库");
                        }
                        string sqlStr = "select * from dbo.Student";
                        SqlCommand comm = new SqlCommand(sqlStr, con1);
                        SqlDataReader sdr = null;
                        try
                        {
                            Console.WriteLine("学号:      姓名:      性别:      年龄:      班级:");
                            sdr = comm.ExecuteReader();
                            while (sdr.Read())
                            {
                                Console.WriteLine(sdr["ID"].ToString() + "      " + sdr["Name"] + "      " + sdr["Sex"] + "      " + sdr["Age"].ToString() + "      " + sdr["Class"].ToString());
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        finally
                        {
                            con1.Close();
                        }
                        Console.Read();

                        con1.Close();
                        break;
                    }

                //修改学生信息
                case 2:
                    {
                        break;
                    }
 //已完成               //浏览学生成绩 
                case 3:
                    {
                        SqlConnection con15 = new SqlConnection(); //创建数据库连接
                        String con = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\xscjgl\\wcxsgl\\wcxsgl.mdf;Integrated Security=True;Connect Timeout=30"; //定义数据库连接信息
                        con15.ConnectionString = con;
                        if (con15.State == ConnectionState.Closed)
                        { //打开链接
                            con15.Open();//打开数据库
                            Console.WriteLine("已连接到学生成绩查询管理系统数据库");
                        }
                        string sqlStr = "select * from dbo.Score";
                        SqlCommand comm = new SqlCommand(sqlStr, con15);
                        SqlDataReader sdr = null;
                        try
                        {
                            Console.WriteLine("学号:  姓名:   语文:   数学:   英语:   物理：   化学：   生物：   历史：   政治：   地理：");
                            sdr = comm.ExecuteReader();
                            while (sdr.Read())
                            {
                                Console.WriteLine(sdr["ID"].ToString() + "   " + sdr["Name"] + "   " + sdr["Chinese"] + "     " + sdr["Maths"].ToString() + "      " + sdr["English"].ToString() + "      " + sdr["Physics"].ToString() + "      " + sdr["Chemistry"].ToString() + "        " + sdr["Biology"].ToString() + "       " + sdr["History"].ToString() + "       " + sdr["Politics"].ToString() + "      " + sdr["Geography"].ToString());

                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        finally
                        {
                            con15.Close();
                        }
                        Console.Read();

                        con15.Close();
                        break;
                    }
                //修改学生成绩
                case 4:
                    {
                        break;
                    }
            }
        }
        //老师相关的模块函数结束


        //管理员相关的模块函数
        public static void Administrator()
        {
            int choice1 = 0;
            Console.WriteLine("*********         请选择你需要的操作      ********");
            Console.WriteLine("*********          1--浏览学生信息        ********");
            Console.WriteLine("*********          2--增加学生信息        ********");
            Console.WriteLine("*********          3--修改学生信息        ********");
            Console.WriteLine("*********          4--删除学生信息        ********");
            Console.WriteLine("*********          5--浏览学生成绩        ********");
            Console.WriteLine("*********          6--增加学生成绩        ********");
            Console.WriteLine("*********          7--删除学生成绩        ********");
            Console.WriteLine("*********          0--退出系统            ********");
            Console.WriteLine("**************************************************");
            choice1 = int.Parse(Console.ReadLine());
            switch (choice1)
            {
 //已完成               //数据库的浏览操作
                case 1:
                    {
                        SqlConnection con1 = new SqlConnection(); //创建数据库连接
                        String con = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\xscjgl\\wcxsgl\\wcxsgl.mdf;Integrated Security=True;Connect Timeout=30"; //定义数据库连接信息
                        con1.ConnectionString = con;
                        if (con1.State == ConnectionState.Closed)
                        {  //打开链接
                            con1.Open();//打开数据库
                            Console.WriteLine("已连接到学生成绩查询管理系统数据库");
                        }
                        string sqlStr = "select * from dbo.Student";
                        SqlCommand comm = new SqlCommand(sqlStr, con1);
                        SqlDataReader sdr = null;
                        try
                        {
                            Console.WriteLine("学号:      姓名:     性别:    年龄:    班级:");
                            sdr = comm.ExecuteReader();
                            while (sdr.Read())
                            {
                                Console.WriteLine(sdr["ID"].ToString() + "      " + sdr["Name"] +"      "+ sdr["Sex"] + "      " + sdr["Age"].ToString() + "      " + sdr["Class"].ToString());
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        finally
                        {
                            con1.Close();
                        }
                        Console.Read();
                        con1.Close();
                        break;
                    }
 //已完成                   //增加学生信息
                case 2:
                    {
                        string MyConn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\xscjgl\\wcxsgl\\wcxsgl.mdf;Integrated Security=True;Connect Timeout=30";
                        using (SqlConnection MyConnection = new SqlConnection(MyConn))  //创建数据库连接
                        {
                            MyConnection.Open();
                            Console.WriteLine("**************************************************");
                            Console.WriteLine("*********      请输入要添加的学生学号    *********");
                            string ID1 = Console.ReadLine();
                            Console.WriteLine("*********         请输入学生姓名         *********");
                            string Name1 = Console.ReadLine();
                            Console.WriteLine("*********         请输入学生性别         *********");
                            string Sex1 = Console.ReadLine();
                            Console.WriteLine("*********         请输入学生年龄         *********");
                            string Age1 = Console.ReadLine();
                            Console.WriteLine("*********         请输入学生班级         *********");
                            string Class1 = Console.ReadLine();
                            Console.WriteLine("*********         请输入学生密码         *********");
                            Console.WriteLine("**************************************************");
                            string Passsword1 = Console.ReadLine();
                            string MyInsert = "select count(ID) from Student where ID=" + ID1;//自定义sql查询语言
                            SqlCommand Mycommand = new SqlCommand(MyInsert, MyConnection);
                            int i = Convert.ToInt32(Mycommand.ExecuteScalar());//把查询结果转换成数字，如果没有查询到相应MID的账号，查询结果为0 
                            if (i > 0)
                            {
                                Console.WriteLine("*********         学号已存在         *********");
                                return;
                            }
                            MyInsert = string.Format("Insert into Student values('{0}', '{1}','{2}','{3}','{4}','{5}')", ID1, Name1, Sex1, Age1,Class1, Passsword1);
                                SqlCommand sql = new SqlCommand(MyInsert, MyConnection);//sqlcommand执行sql命令，注意函参  
                                int j = sql.ExecuteNonQuery();
                                if (j > 0)
                                {
                                    Console.WriteLine("*********         添加成功         *********");//弹出提示框，显示成功  
                                }
                                else
                                    Console.WriteLine("*********         添加失败         *********");
                        }
                        Console.ReadKey();

                        //显示添加后的结果
                        SqlConnection con12 = new SqlConnection(); //创建数据库连接
                        String conn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\xscjgl\\wcxsgl\\wcxsgl.mdf;Integrated Security=True;Connect Timeout=30"; //定义数据库连接信息
                        con12.ConnectionString = conn;
                        if (con12.State == ConnectionState.Closed)
                        { //打开链接
                            con12.Open();//打开数据库
                            Console.WriteLine("*********         已连接到课程管理数据库         *********");
                        }
                        Console.WriteLine("*********         添加后的学生新数据为         *********");
                        string sqlStr = "select ID from dbo.Student";
                        SqlCommand comm = new SqlCommand(sqlStr, con12);
                        SqlDataReader sdr = null;
                        try
                        {
                            sdr = comm.ExecuteReader();
                            while (sdr.Read())
                            {
                                Console.WriteLine("学号：" + sdr["ID"].ToString());
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        finally
                        {
                            con12.Close();
                        }
                        Console.Read();
                        con12.Close();
                        break;
                    }

                //修改学生信息
                case 3:
                    {
                        int choice31 = 0;
                        Console.WriteLine("*********          1--修改学生学号        ********");
                        Console.WriteLine("*********          2--修改学生姓名        ********");
                        Console.WriteLine("*********          3--修改学生性别        ********");
                        Console.WriteLine("*********          4--修改学生年龄        ********");
                        Console.WriteLine("*********          5--修改学生班级        ********");
                        Console.WriteLine("*********          0--退出系统            ********");
                        Console.WriteLine("**************************************************");
                        choice31 = int.Parse(Console.ReadLine());
                        switch (choice31)
                        {
                            //学号
                            case 1:
                                {//连接字符串
                                    string strcon = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\xscjgl\\wcxsgl\\wcxsgl.mdf;Integrated Security=True;Connect Timeout=30"; //1、新建通道
                                    SqlConnection conn = new SqlConnection();
                                    conn.ConnectionString = strcon;//2、准备新增sql命令
                                    Console.WriteLine("*********         请输入要修改的学生学号         *********");
                                    string ID2 = Console.ReadLine();
                                    Console.WriteLine("*********         请输入修改后的内容         *********");
                                    string value2 = Console.ReadLine();
                                    string strcommand = "update Student set ID = 'value2' where ID = 'ID2' ";
                                    //3、新建命令对象，并前告诉它走那条路，做什么事情
                                    SqlCommand cmd = new SqlCommand(strcommand, conn);
                                    //4、打开通道
                                    conn.Open();
                                    //5、执行sql语句
                                    int intres = -1;
                                    intres = cmd.ExecuteNonQuery();
                                    //6、关闭连接通道
                                    conn.Close();
                                    if (intres > 0)
                                    {
                                        Console.WriteLine("修改成功");
                                    }
                                    else
                                    {
                                        Console.WriteLine("修改失败");
                                    }
                                    break;
                                }

                            //姓名
                            case 2:
                                {//连接字符串
                                    string strcon = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\xscjgl\\wcxsgl\\wcxsgl.mdf;Integrated Security=True;Connect Timeout=30"; //1、新建通道
                                    SqlConnection conn = new SqlConnection();
                                    conn.ConnectionString = strcon;//2、准备新增sql命令
                                    Console.WriteLine("*********         请输入要修改的学生姓名         *********");
                                    string Name2 = Console.ReadLine();
                                    Console.WriteLine("*********         请输入修改后的内容的         *********");
                                    string value2 = Console.ReadLine();
                                    string strcommand = "update Student set Name= 'value2' where Name = 'Name2' ";
                                    //3、新建命令对象，并前告诉它走那条路，做什么事情
                                    SqlCommand cmd = new SqlCommand(strcommand, conn);
                                    //4、打开通道
                                    conn.Open();
                                    //5、执行sql语句
                                    int intres = -1;
                                    intres = cmd.ExecuteNonQuery();
                                    //6、关闭连接通道
                                    conn.Close();
                                    if (intres > 0)
                                    {
                                        Console.WriteLine("修改成功");
                                    }
                                    else
                                    {
                                        Console.WriteLine("修改失败");
                                    }
                                    break;
                                }
                               
                            //性别
                            case 3:
                                {//连接字符串
                                    string strcon = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\xscjgl\\wcxsgl\\wcxsgl.mdf;Integrated Security=True;Connect Timeout=30"; //1、新建通道
                                    SqlConnection conn = new SqlConnection();
                                    conn.ConnectionString = strcon;//2、准备新增sql命令
                                    Console.WriteLine("*********         请输入要修改的学生性别         *********");
                                    string Sex2 = Console.ReadLine();
                                    Console.WriteLine("*********         请输入修改后的内容的         *********");
                                    string value2 = Console.ReadLine();
                                    string strcommand = "update Student set Sex= 'value2' where Sex = 'Sex2' ";
                                    //3、新建命令对象，并前告诉它走那条路，做什么事情
                                    SqlCommand cmd = new SqlCommand(strcommand, conn);
                                    //4、打开通道
                                    conn.Open();
                                    //5、执行sql语句
                                    int intres = -1;
                                    intres = cmd.ExecuteNonQuery();
                                    //6、关闭连接通道
                                    conn.Close();
                                    if (intres > 0)
                                    {
                                        Console.WriteLine("修改成功");
                                    }
                                    else
                                    {
                                        Console.WriteLine("修改失败");
                                    }
                                    break;
                                }
                                
                            //年龄
                            case 4:
                                {//连接字符串
                                    string strcon = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\xscjgl\\wcxsgl\\wcxsgl.mdf;Integrated Security=True;Connect Timeout=30"; //1、新建通道
                                    SqlConnection conn = new SqlConnection();
                                    conn.ConnectionString = strcon;//2、准备新增sql命令
                                    Console.WriteLine("*********         请输入要修改的学生年龄         *********");
                                    string Age = Console.ReadLine();
                                    Console.WriteLine("*********         请输入修改后的内容的         *********");
                                    string value2 = Console.ReadLine();
                                    string strcommand = "update Student set Age= 'value2' where Age = 'Age2' ";
                                    //3、新建命令对象，并前告诉它走那条路，做什么事情
                                    SqlCommand cmd = new SqlCommand(strcommand, conn);
                                    //4、打开通道
                                    conn.Open();
                                    //5、执行sql语句
                                    int intres = -1;
                                    intres = cmd.ExecuteNonQuery();
                                    //6、关闭连接通道
                                    conn.Close();
                                    if (intres > 0)
                                    {
                                        Console.WriteLine("修改成功");
                                    }
                                    else
                                    {
                                        Console.WriteLine("修改失败");
                                    }
                                    break;
                                }
                                
                            //班级
                            case 5:
                                {//连接字符串
                                    string strcon = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\xscjgl\\wcxsgl\\wcxsgl.mdf;Integrated Security=True;Connect Timeout=30"; //1、新建通道
                                    SqlConnection conn = new SqlConnection();
                                    conn.ConnectionString = strcon;//2、准备新增sql命令
                                    Console.WriteLine("*********         请输入要修改的学生班级         *********");
                                    string Class2 = Console.ReadLine();
                                    Console.WriteLine("*********         请输入修改后的内容的         *********");
                                    string value2 = Console.ReadLine();
                                    string strcommand = "update Student set Class= 'value2' where Class = 'Class2' ";
                                    //3、新建命令对象，并前告诉它走那条路，做什么事情
                                    SqlCommand cmd = new SqlCommand(strcommand, conn);
                                    //4、打开通道
                                    conn.Open();
                                    //5、执行sql语句
                                    int intres = -1;
                                    intres = cmd.ExecuteNonQuery();
                                    //6、关闭连接通道
                                    conn.Close();
                                    if (intres > 0)
                                    {
                                        Console.WriteLine("修改成功");
                                    }
                                    else
                                    {
                                        Console.WriteLine("修改失败");
                                    }
                                    break;
                                }
                        }
                        break;
                    }

 //已完成                  // 删除学生信息
                case 4:
                    { //1.创建连接字符串
                        string constr = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\xscjgl\\wcxsgl\\wcxsgl.mdf;Integrated Security=True;Connect Timeout=30";
                        //2.连接对象
                        using (SqlConnection con = new SqlConnection(constr))
                        { //3.sql语句
                            Console.WriteLine("*********     请输入要删除的学生学号     *********");
                            string ID = Console.ReadLine();
                            string sql = "delete from dbo.Student where ID='" + ID + "'";
                            //4.创建sqlcommand对象
                            using (SqlCommand cmd = new SqlCommand(sql, con))
                            {
                                //5.打开数据库连接
                                con.Open();
                                //6.执行数据库语句
                                int r = cmd.ExecuteNonQuery();
                                Console.WriteLine("*********        成功删除了{0}行数据       *********", r);
                            }
                        }
                        Console.ReadKey();
                        //显示删除后的结果
                        SqlConnection con1 = new SqlConnection(); //创建数据库连接
                        String conn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\xscjgl\\wcxsgl\\wcxsgl.mdf;Integrated Security=True;Connect Timeout=30"; //定义数据库连接信息
                        con1.ConnectionString = conn;
                        if (con1.State == ConnectionState.Closed)
                        {//打开链接
                            con1.Open();//打开数据库
                            Console.WriteLine("*********      已连接到课程管理数据库      *********");
                        }
                        Console.WriteLine("*********      删除后的学生新数据为      *********");
                        string sqlStr = "select ID from dbo.Student";
                        SqlCommand comm = new SqlCommand(sqlStr, con1);
                        SqlDataReader sdr = null;
                        try
                        {
                            sdr = comm.ExecuteReader();
                            while (sdr.Read())
                            {
                                Console.WriteLine("学号：" + sdr["ID"].ToString());
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        finally
                        {
                            con1.Close();
                        }
                        Console.Read();

                        con1.Close();
                        break;
                    }
 //已完成                 //5--浏览学生成绩
                case 5:
                    {

                        SqlConnection con15 = new SqlConnection(); //创建数据库连接Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\xscjgl\xt.mdf;Integrated Security=True;Connect Timeout=30

                        String con = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\xscjgl\\wcxsgl\\wcxsgl.mdf;Integrated Security=True;Connect Timeout=30"; //定义数据库连接信息
                        con15.ConnectionString = con;
                        if (con15.State == ConnectionState.Closed)
                        {
                            //打开链接
                            con15.Open();//打开数据库
                            Console.WriteLine("******  已连接到学生成绩查询管理系统数据库  ******");
                        }
                        string sqlStr = "select * from dbo.Score";
                        SqlCommand comm = new SqlCommand(sqlStr, con15);
                        SqlDataReader sdr = null;
                        try
                        {
                            Console.WriteLine("学号:  姓名:   语文:   数学:   英语:   物理：   化学：   生物：   历史：   政治：   地理：");
                            sdr = comm.ExecuteReader();
                            while (sdr.Read())
                            {
                                Console.WriteLine(sdr["ID"].ToString() + "   " + sdr["Name"] + "   " + sdr["Chinese"] + "     " + sdr["Maths"].ToString() + "      " + sdr["English"].ToString()+"      "+sdr["Physics"].ToString() + "      "+ sdr["Chemistry"].ToString() + "        "+ sdr["Biology"].ToString() + "       "+ sdr["History"].ToString() + "       "+ sdr["Politics"].ToString()+"      "+sdr["Geography"].ToString());
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        finally
                        {
                            con15.Close();
                        }
                        Console.Read();

                        con15.Close();
                        break;
                    }

 //y已完成                //增加学生成绩
                case 6:
                    {
                        string MyConn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\xscjgl\\wcxsgl\\wcxsgl.mdf;Integrated Security=True;Connect Timeout=30";
                        using (SqlConnection MyConnection = new SqlConnection(MyConn))  //创建数据库连接
                        {
                            Console.WriteLine("**************************************************"); 
                            Console.WriteLine("*********          添加学生成绩           ********");
                            Console.WriteLine("**************************************************");
                            MyConnection.Open(); 
                            Console.WriteLine("*********         请输入学生学号         *********");
                            string ID2 = Console.ReadLine();
                            Console.WriteLine("*********         请输入学生姓名         *********");
                            string Name2 = Console.ReadLine();
                            Console.WriteLine("*********         请输入语文成绩         *********");
                            string Chinese2 = Console.ReadLine();
                            Console.WriteLine("*********         请输入数学成绩         *********");
                            string Maths2 = Console.ReadLine();
                            Console.WriteLine("*********         请输入英语成绩         *********");
                            string English2 = Console.ReadLine();
                            Console.WriteLine("*********         请输入物理成绩         *********");
                            string Physics2 = Console.ReadLine();
                            Console.WriteLine("*********         请输入化学成绩         *********");
                            string Chemistry2 = Console.ReadLine();
                            Console.WriteLine("*********         请输入生物成绩         *********");
                            string Biology2 = Console.ReadLine();
                            Console.WriteLine("*********         请输入历史成绩         *********");
                            string History2 = Console.ReadLine();
                            Console.WriteLine("*********         请输入政治成绩         *********");
                            string Politics2 = Console.ReadLine();
                            Console.WriteLine("*********         请输入地理成绩         *********");
                            string Geography2 = Console.ReadLine();
                            Console.WriteLine("**************************************************");
                            string MyInsert = "select count(ID) from Score where ID=" + ID2;//自定义sql查询语言
                            SqlCommand Mycommand = new SqlCommand(MyInsert, MyConnection);
                            int i = Convert.ToInt32(Mycommand.ExecuteScalar());//把查询结果转换成数字，如果没有查询到相应MID的账号，查询结果为0 
                            if (i > 0)
                            {
                                Console.WriteLine("*********         学号已存在         *********");
                                return;
                            }
                            MyInsert = string.Format("Insert into Score values('{0}', '{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}')" ,ID2, Name2, Chinese2, Maths2, English2, Physics2, Chemistry2, Biology2, History2, Politics2, Geography2);
                            SqlCommand sql = new SqlCommand(MyInsert, MyConnection);//sqlcommand执行sql命令，注意函参  
                            int j = sql.ExecuteNonQuery();
                            if (j > 0)
                            {
                                Console.WriteLine("*********         添加成功         *********");
                            }
                            else
                                Console.WriteLine("*********         添加失败         *********");

                        }
                        Console.ReadKey();
                        //显示添加后的结果
                        SqlConnection con12 = new SqlConnection(); //创建数据库连接
                        String conn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\xscjgl\\wcxsgl\\wcxsgl.mdf;Integrated Security=True;Connect Timeout=30"; //定义数据库连接信息
                        con12.ConnectionString = conn;
                        if (con12.State == ConnectionState.Closed)
                        {
                            //打开链接
                            con12.Open();//打开数据库
                            Console.WriteLine("*********     已连接到课程管理数据库     *********");
                        }
                        Console.WriteLine("*********        添加后的学生新数据为       *********");
                        string sqlStr = "select ID from dbo.Score";
                        SqlCommand comm = new SqlCommand(sqlStr, con12);
                        SqlDataReader sdr = null;
                        try
                        {
                            sdr = comm.ExecuteReader();
                            while (sdr.Read())
                            {
                                Console.WriteLine("学号：" + sdr["ID"].ToString());
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        finally
                        {
                            con12.Close();
                        }
                        Console.Read();
                        con12.Close();
                        break;
                    }
//已完成                 //删除学生成绩
               case 7:
                    {
                        //1.创建连接字符串
                        string constr8 = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\xscjgl\\wcxsgl\\wcxsgl.mdf;Integrated Security=True;Connect Timeout=30";
                        //2.连接对象
                        using (SqlConnection con8 = new SqlConnection(constr8))
                        {
                            //3.sql语句
                            Console.WriteLine("*********     请输入要删除的学生学号     *********");
                            string ID = Console.ReadLine();
                            string sql8 = "delete from dbo.Score where ID='" + ID + "'";
                            //4.创建sqlcommand对象
                            using (SqlCommand cmd8 = new SqlCommand(sql8, con8))
                            { //5.打开数据库连接
                                con8.Open();
                                //6.执行数据库语句
                                int r = cmd8.ExecuteNonQuery();
                                Console.WriteLine("*********       成功删除了{0}行数据       *********", r);
                            }
                        }
                        Console.ReadKey();
                        //显示删除后的结果
                        SqlConnection con18 = new SqlConnection(); //创建数据库连接
                        String conn8 = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\xscjgl\\wcxsgl\\wcxsgl.mdf;Integrated Security=True;Connect Timeout=30"; //定义数据库连接信息
                        con18.ConnectionString = conn8;
                        if (con18.State == ConnectionState.Closed)
                        {
                            //打开链接
                            con18.Open();//打开数据库
                            Console.WriteLine("*********     已连接到课程管理数据库     *********");
                        }
                        Console.WriteLine("*********        删除后的学生新数据为       *********");
                        string sqlStr = "select ID from dbo.Score";
                        SqlCommand comm = new SqlCommand(sqlStr, con18);
                        SqlDataReader sdr = null;
                        try
                        {
                            sdr = comm.ExecuteReader();
                            while (sdr.Read())
                            {
                                Console.WriteLine("学号：" + sdr["ID"].ToString());
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        finally
                        {
                            con18.Close();
                        }
                        Console.Read();
                        con18.Close();
                        break;
                    }
            }
            System.Environment.Exit(0);
        }//switch开关语句结束
    } //管理员相关的模块函数结束
}

