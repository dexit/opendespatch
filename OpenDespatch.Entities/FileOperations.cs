﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenDespatch.Entities
{
    public static class FileOperations
    {
        /// <summary>
        /// Moves file to arhive and supress errors
        /// </summary>
        /// <param name="fullFilePath"></param>
        public static void ArchiveFile(string fromLocation, string toLocation)
        {
            try
            {
                var fullToLocation = Path.Combine(toLocation, Path.GetFileName(fromLocation));
                if (!System.IO.Directory.Exists(toLocation))
                    System.IO.Directory.CreateDirectory(toLocation);

                if (System.IO.File.Exists(fullToLocation))
                    System.IO.File.Delete(fullToLocation);

                File.Move(fromLocation, fullToLocation);
            }
            catch { }
        }

        /// <summary>
        /// Reads a text file
        /// </summary>
        /// <param name="fullFilePath"></param>
        /// <returns></returns>
        public static string ReadFile(string fullFilePath)
        {
            //TODO: lock the file
            try
            {
                return File.ReadAllText(fullFilePath);
            }
            catch
            {
                return string.Empty;
            }
        }

        public static string ReadFile(string fileLocation, string filename)
        {
            return ReadFile(Path.Combine(fileLocation, filename));
        }

        /// <summary>
        /// Returns the full path of the first file in the location
        /// </summary>
        /// <param name="fileLocation">Folder to check</param>
        /// <param name="filePattern">File pattern to look for</param>
        /// <returns></returns>
        public static string GetFirstFileInFolder(string fileLocation, string filePattern)
        {
            try
            {
                DirectoryInfo info = new DirectoryInfo(fileLocation);
                return info.GetFiles(filePattern).OrderByDescending(f => f.LastWriteTime).First().FullName;
            }
            catch
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Deletes a file and supress errors
        /// </summary>
        /// <param name="fullFilePath"></param>
        public static void DeleteFile(string fullFilePath)
        {
            try
            {
                //TODO: lock the file
                File.Delete(fullFilePath);
            }
            catch { }
        }

        public static void DeleteFile(string fileLocation, string filename)
        {
            DeleteFile(Path.Combine(fileLocation, filename));
        }

        /// <summary>
        /// Writes a text file
        /// </summary>
        /// <param name="fullFilePath"></param>
        /// <param name="data"></param>
        /// <param name="encoding"></param>
        public static void WriteFile(string fullFilePath, string data, Encoding encoding)
        {
            try
            {
                //TODO: lock the file
                //This will override the file
                File.WriteAllText(fullFilePath, data, encoding);
            }
            catch { }
        }

        public static void WriteFile(string fullFilePath, string data)
        {
            WriteFile(fullFilePath, data, Encoding.Default);
        }

        public static void WriteFile(string fileLocation, string filename, string data, Encoding encoding)
        {
            WriteFile(Path.Combine(fileLocation, filename), data, encoding);
        }

        public static void WriteFile(string fileLocation, string filename, string data)
        {
            WriteFile(fileLocation, filename, data, Encoding.Default);
        }

        /// <summary>
        /// Check whether a file exist
        /// </summary>
        /// <param name="fullFilePath"></param>
        /// <returns></returns>
        public static bool CheckFileExists(string fullFilePath)
        {
            try
            {
                return File.Exists(fullFilePath);
            }
            catch 
            {
                return false;
            }
        }

        public static bool CheckFileExists(string fileLocation, string filename)
        {
            return CheckFileExists(Path.Combine(fileLocation, filename));
        }
    }
}
