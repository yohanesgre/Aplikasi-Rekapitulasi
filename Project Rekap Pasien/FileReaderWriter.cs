using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Project_Rekap_Pasien
{
    public sealed class FileReaderWriter
    {
        static readonly FileReaderWriter _instance = new FileReaderWriter();
        private static StreamReader sr;
        private static StreamWriter sw;
        public Stream s;

        public static FileReaderWriter Instance
        {
            get
            {
                return _instance;
            }
        }

        private FileReaderWriter(){
            s = new MemoryStream();
        }

        public static StreamReader getSR(string path)
        {
            sr = new StreamReader(path);
            return sr;
        }

        public static StreamWriter getSW(string path)
        {
            sw = new StreamWriter(path);
            return sw;
        }
    }
}
