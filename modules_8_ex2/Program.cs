namespace modules_8_ex2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\Fed_w\Desktop\Webb";
            DirectoryInfo directory = new DirectoryInfo(path);
            long a = MemoryDirectory(directory);

            Console.WriteLine("Общий вес директории: " + (a/1024/1024) +" Мегабайт");
            long MemoryDirectory(DirectoryInfo directoryInfo)
            {
                long totalSize = 0;

                if (directoryInfo.Exists)
                {
                    totalSize += MemoryFileInDerictory(directoryInfo);

                    DirectoryInfo[] directories = directoryInfo.GetDirectories();
                    foreach (DirectoryInfo d in directories)
                    {
                      totalSize +=MemoryDirectory(d);
                    }

                }
                return totalSize;
            }
            long MemoryFileInDerictory(DirectoryInfo info)
            {
                long size = 0;
                FileInfo[] fileInfo = info.GetFiles();
                foreach (FileInfo file in fileInfo)
                {
                    size+= file.Length;
                }
                return size;
            }
        }


    }
}
