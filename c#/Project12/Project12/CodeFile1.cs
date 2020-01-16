using System;
using System.IO;
using System.IO.Compression;



class Program
{
    static void Main(string[] args)
    {
        ZYVDiskInfo.FreeSpace("C:\\");
        ZYVDiskInfo.TypeOfFileSystem("C:\\");
        ZYVDiskInfo.DrivesInfo();
        Console.WriteLine(new string('-',50));
        ZYVFileInfo.FullPath(@"C:\Users\xiaom\Desktop\univer\c#\Project12\lol.txt");
        ZYVFileInfo.FullInfo(@"C:\Users\xiaom\Desktop\univer\c#\Project12\lol.txt");
        ZYVFileInfo.TimeOfCreation(@"C:\Users\xiaom\Desktop\univer\c#\Project12\lol.txt");
        Console.WriteLine(new string('-', 50));
        ZYVDirInfo.GetFiles(@"C:\Users\xiaom\Desktop\univer\c#\Project12\");
        ZYVDirInfo.GetSubDir(@"C:\Users\xiaom\Desktop\univer\c#\Project12\");
        ZYVDirInfo.GetTime(@"C:\Users\xiaom\Desktop\univer\c#\Project12\");
        ZYVDirInfo.GetParentDir(@"C:\Users\xiaom\Desktop\univer\c#\Project12\");
        Console.WriteLine(new string('-', 50));
        ZYVFileManager.UltimateMethod(@"C:\Users\xiaom\Desktop\univer\c#\Project12");
    }

    public static class ZYVLOG
    {
        public static void WriteLog(string name)
        {
            byte[] arr = System.Text.Encoding.Default.GetBytes("метод - "+name + ", вызван - " + DateTime.Now);
            using (StreamWriter st = new StreamWriter(@"C:\Users\xiaom\Desktop\univer\c#\Project12\ZYVlog.txt", true, System.Text.Encoding.Default))
            {
                st.WriteLine($"метод -  {name}  , вызван -  {DateTime.Now}");
            }
        }
    }

    static class ZYVDiskInfo
    {
        public static void FreeSpace(string DN)
        {
            ZYVLOG.WriteLog("FreeSpace");
            var Driveinfo = DriveInfo.GetDrives();
            foreach (var d in Driveinfo)
            {
                if (d.Name == DN)
                {
                    Console.WriteLine($"{ d.Name} - {d.TotalFreeSpace} bytes");
                }
            }
        }
        public static void TypeOfFileSystem(string DN)
        {
            ZYVLOG.WriteLog("TypeOfFileSystem");
            var Driveinfo = DriveInfo.GetDrives();
            foreach (var d in Driveinfo)
            {
                if (d.Name == DN)
                {
                    Console.WriteLine($"{d.Name} - {d.DriveFormat}");
                }
            }
        }
        public static void DrivesInfo()
        {
            ZYVLOG.WriteLog("DrivesInfo");
            var Driveinfo = DriveInfo.GetDrives();
            foreach (var d in Driveinfo)
            {
                if(d.IsReady)
                Console.WriteLine($"{d.Name} - {d.TotalFreeSpace} bytes / {d.TotalSize} bytes  -- {d.VolumeLabel}");
            }
        }
    }

    public static class ZYVFileInfo
    {
        public static void FullPath(string Path)
        {
            ZYVLOG.WriteLog("FullPath");
            FileInfo f = new FileInfo(Path);
            Console.WriteLine(f.DirectoryName);
        }
        public static void FullInfo(string Path)
        {
            ZYVLOG.WriteLog("FullInfo");
            FileInfo f = new FileInfo(Path);
            Console.WriteLine($"{f.Name} - {f.Extension} - {f.Length}");
        }
        public static void TimeOfCreation(string Path)
        {
            ZYVLOG.WriteLog("TimeOfCreation");
            FileInfo f = new FileInfo(Path);
            Console.WriteLine(f.CreationTime);
        }
    }

    public static class ZYVDirInfo
    {
        public static void GetFiles(string Path)
        {
            ZYVLOG.WriteLog("GetFiles");
            DirectoryInfo d = new DirectoryInfo(Path);
            foreach(var f in d.GetFiles())
                Console.WriteLine(f.FullName);
        }
        public static void GetTime(string Path)
        {
            ZYVLOG.WriteLog("GetTime");
            DirectoryInfo d = new DirectoryInfo(Path);
            Console.WriteLine(d.CreationTime);
        }
        public static void GetSubDir(string Path)
        {
            ZYVLOG.WriteLog("GetSubDir");
            DirectoryInfo d = new DirectoryInfo(Path);
            foreach (var f in d.GetDirectories())
                Console.WriteLine(f.FullName);
        }
        public static void GetParentDir(string Path)
        {
            ZYVLOG.WriteLog("GetParentDir");
            DirectoryInfo d = new DirectoryInfo(Path);
            foreach (var f in d.Parent.GetDirectories())
                Console.WriteLine(f.FullName);
        }
    }
    public static class ZYVFileManager
    {
        public static void UltimateMethod(string Path)
        {
            ZYVLOG.WriteLog("UltimateMethod");
            DirectoryInfo d = new DirectoryInfo(Path);
            ZYVDirInfo.GetFiles(Path);
            ZYVDirInfo.GetSubDir(Path);
            d.CreateSubdirectory("ZYVInspect");
            var file = new FileInfo(Path + @"\ZYVDirinfo.txt");
            FileStream fs = file.Open(FileMode.OpenOrCreate,FileAccess.ReadWrite,FileShare.None);
            byte[] arr = System.Text.Encoding.Default.GetBytes("kekekekekek");
            fs.Write(arr,0,arr.Length);
            fs.Dispose();
            file.CopyTo(Path + @"\lolol.txt", true);
            d.CreateSubdirectory("ZYVFiles");
            foreach (var f in d.GetFiles())
            {
                if (f.Extension == ".txt" && f.Name!="lol.txt" && f.Name!="ZYVlog.txt")
                    f.MoveTo(@"C:\Users\xiaom\Desktop\univer\c#\Project12\ZYVFiles"+@"\"+f.Name);
            }
            DirectoryInfo d1 = new DirectoryInfo(Path + @"\ZYVFiles");
            d1.MoveTo(Path + @"\ZYVInspect\ZYVFiles");
            ZipFile.CreateFromDirectory(Path + @"\ZYVInspect\ZYVFiles",Path + @"\ZYVInspect\zip.zip" );
            ZipFile.ExtractToDirectory(Path + @"\ZYVInspect\zip.zip", Path);
            string[] s = File.ReadAllLines(Path + @"\ZYVlog.txt");
            for (int i = 0; i < s.Length; i++)
            {
                Console.WriteLine(s[i]);
            }
            Console.WriteLine(s.Length+" Записей");
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i].Contains(DateTime.Now.Day.ToString()) && s[i].Contains("13:48"))
                    Console.WriteLine(s[i]);
            }
        }
    }

}