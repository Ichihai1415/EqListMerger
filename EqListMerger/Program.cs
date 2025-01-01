using System.Text;

namespace EqListMerger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("都度コードを調整するタイプのソフトです。");




            var baseDir = @"D:\Ichihai1415\data\_github\Data\EQDB";
            //var baseDir = @"D:\Ichihai1415\data\_github\Data\HypoList\eqdb";


            var startDate = new DateTime(1919, 1, 1);


            var endDate = new DateTime(1920, 1, 1);


            var getSpan = TimeSpan.FromDays(1);

            var newSt = new StringBuilder();
            for (DateTime getDate = endDate - getSpan; getDate >= startDate; getDate -= getSpan)
            {
                var path = baseDir + "\\" + getDate.Year + "\\" + getDate.Month + "\\" + getDate.Day + ".csv";
                Console.WriteLine(path);
                newSt.Append(File.ReadAllText(path).Replace("地震の発生日,地震の発生時刻,震央地名,緯度,経度,深さ,Ｍ,最大震度\n", "").Replace("\n\n", "\n"));
            }
            Console.WriteLine();
            Console.WriteLine(newSt.ToString());
            File.WriteAllText(baseDir + "\\1919\\1919.csv", newSt.ToString());
            Console.WriteLine();
            Console.WriteLine(baseDir + "\\1919\\1919.csv");

        }
    }
}
