using System.Text;

namespace EqListMerger
{
    internal class Program
    {
       static string baseDir= @"D:\Ichihai1415\data\_github\Data\EQDB";
        static void Main(string[] args)
        {
            Console.WriteLine("都度コードを調整するタイプのソフトです。何かキーを押すと続行します。");
            Console.ReadKey();
            Console.Clear();

            //コード内調整が必要なものもあります。製作から時間が経っている場合

            baseDir = @"D:\Ichihai1415\data\_github\Data\EQDB";
            /*for (int i = 1919; i < 2025; i++)
                EQDB(i);*/
            /*for (int i = 1910; i < 2030; i += 10)
                EQDB10(i);*/
            //EQDBAll();

            baseDir = @"D:\Ichihai1415\data\_github\Data\HypoList\eqdb";
            for (int i = 2023; i < 2025; i++)
                EQDB(i);
            for (int i = 2020; i < 2030; i += 10)
                EQDB10(i);
            EQDBAll();

            //baseDir = @"D:\Ichihai1415\data\_github\Data\HypoList\original"; //必要な場合csvヘッダ部分の処理を変更する必要

        }

        static void EQDB(int startYear, int spanYear = 1)
        {
            var startDate = new DateTime(startYear, 1, 1);
            var endDate = new DateTime(startYear + 1, 1, 1);
            var getSpan = TimeSpan.FromDays(1);

            var newSt = new StringBuilder("地震の発生日,地震の発生時刻,震央地名,緯度,経度,深さ,Ｍ,最大震度\n");
            for (DateTime getDate = endDate - getSpan; getDate >= startDate; getDate -= getSpan)
            {
                var path = baseDir + "\\" + getDate.Year + "\\" + getDate.Month + "\\" + getDate.Day + ".csv";
                if (!File.Exists(path))
                    continue;
                Console.WriteLine(path);
                newSt.Append(File.ReadAllText(path).Replace("地震の発生日,地震の発生時刻,震央地名,緯度,経度,深さ,Ｍ,最大震度\n", "").Replace("\n\n", "\n"));
            }
            Console.WriteLine();
            Console.WriteLine(newSt.ToString());
            File.WriteAllText(baseDir + "\\" + startYear + "\\" + startYear + ".csv", newSt.ToString());
            Console.WriteLine();
            Console.WriteLine(baseDir + "\\" + startYear + "\\" + startYear + ".csv");
        }

        static void EQDB10(int startYear)
        {
            var newSt = new StringBuilder("地震の発生日,地震の発生時刻,震央地名,緯度,経度,深さ,Ｍ,最大震度\n");
            for (int getYear = startYear + 9; getYear >= startYear; getYear--)
            {
                var path = baseDir + "\\" + getYear + "\\" + getYear + ".csv";
                if (!File.Exists(path))
                    continue;
                Console.WriteLine(path);
                newSt.Append(File.ReadAllText(path).Replace("地震の発生日,地震の発生時刻,震央地名,緯度,経度,深さ,Ｍ,最大震度\n", "").Replace("\n\n", "\n"));
            }
            Console.WriteLine();
            Console.WriteLine(newSt.ToString());
            File.WriteAllText(baseDir + "\\" + startYear + "s.csv", newSt.ToString());
            Console.WriteLine();
            Console.WriteLine(baseDir + "\\" + startYear + "s.csv");
        }

        static void EQDBAll()
        {
            var newSt = new StringBuilder("地震の発生日,地震の発生時刻,震央地名,緯度,経度,深さ,Ｍ,最大震度\n");
            for (int getYear = 2020; getYear >= 1910; getYear -= 10)
            {
                var path = baseDir + "\\" + getYear + "s.csv";
                if (!File.Exists(path))
                    continue;
                Console.WriteLine(path);
                newSt.Append(File.ReadAllText(path).Replace("地震の発生日,地震の発生時刻,震央地名,緯度,経度,深さ,Ｍ,最大震度\n", "").Replace("\n\n", "\n"));
            }
            Console.WriteLine();
            Console.WriteLine(newSt.ToString());
            File.WriteAllText(baseDir + "\\all.csv", newSt.ToString());
            Console.WriteLine();
            Console.WriteLine(baseDir + "\\all.csv");
        }
    }
}
