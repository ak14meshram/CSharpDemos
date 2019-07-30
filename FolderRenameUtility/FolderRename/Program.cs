using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolderRename
{
    class Program
    {
        public static void RenameAllFolders(string rootDirectory)
        {

            //String RootDirectoryPath = @"E:\Test";
            String[] subDirsPath = Directory.GetDirectories(rootDirectory);
            
            foreach (string subDirPath in subDirsPath)
            {
                //get files
                var folders = Directory.GetDirectories(subDirPath);
                foreach (string folder in folders)
                {
                    //get folders by triming till '\'
                    int index = folder.LastIndexOf('\\');
                    var folderName = folder.Substring(index);

                    //If folder is "Baseline" or "baseline"
                    if (folderName.Equals("\\Baseline", StringComparison.OrdinalIgnoreCase))
                    {
                        //get files
                        var files = Directory.GetFiles(folder);
                        bool multiplesFiles = false;
                        int count = 0;

                        foreach (var file in files)
                        {
                            if (files.Length > 1)
                            {
                                multiplesFiles = true;
                            }

                            //get only file name
                            int i = file.LastIndexOf('\\');
                            var oldfilename = file.Substring(i + 1);  //after '\'

                            int j = oldfilename.IndexOf('_');   //Get index if '_' for Testcase name "TC123456"
                            int ext_index = oldfilename.LastIndexOf('.');   //Get index to get extension
                            var extension = oldfilename.Substring(ext_index);  //Get extension 

                            if (multiplesFiles && extension.Contains(".amx"))
                            {
                                count++;
                                extension = "_" + count + extension;
                            }

                            //rename file
                            var newfilename = folder + "\\" + oldfilename.Substring(0,j) + extension;

                        }

                    }

                }
            }
        }
        public static void Main(string[] args)
        {
            String RootDirectoryPath = @"E:\Test";
            RenameAllFolders(RootDirectoryPath);
        }
    }
}
