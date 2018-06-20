using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;
using System.Data;

namespace K_means
{
  class Program
  {
    //Guilherme Fonseca, João Victor Ramos, Henrique palote, Ioná Vieira
    //substutuir o caminho para o caminho atual do arquivo (Grupo de Pessoas.txt) e para a criação do arquivo.
    const string path = @"C:\Users\ASUS\Desktop\K-means\";
    const string nomeArquivo = @"Grupo de Pessoas.txt";
    public static void Main(string[] args)
    {
      DataTable dtInfo = new DataTable("info");
      dtInfo.Columns.Add("UserID", typeof(long));
      dtInfo.Columns.Add("Sexo", typeof(string));
      dtInfo.Columns.Add("Idade", typeof(long));
      dtInfo.Columns.Add("Ocupacao", typeof(long));
      dtInfo.Columns.Add("CodigoPostal", typeof(string));


      Console.Write("Execução K-means");

      //centro de cada grupo definido de maneitra aleatoria para o inicio da execução
      double centro_1 = 1, centro_2 = 16, centro_3 = 22, centro_4 = 30, centro_5 = 40, centro_6 = 50, centro_7 = 60;
      Boolean igual = false;

      //variaveis para somar os elemenstos de cada grupo
      double SomaElementos1 = 0, SomaElementos2 = 0, SomaElementos3 = 0, SomaElementos4 = 0, SomaElementos5 = 0, SomaElementos6 = 0, SomaElementos7 = 0;
      int contadorIteracao = 1;

      LerArquivo(dtInfo);

      //datatable para representar cada grupo
      DataTable Kmeans1 = dtInfo.Clone();
      DataTable Kmeans2 = dtInfo.Clone();
      DataTable Kmeans3 = dtInfo.Clone();
      DataTable Kmeans4 = dtInfo.Clone();
      DataTable Kmeans5 = dtInfo.Clone();
      DataTable Kmeans6 = dtInfo.Clone();
      DataTable Kmeans7 = dtInfo.Clone();
      DataTable KmeansAux1 = dtInfo.Clone();
      DataTable KmeansAux2 = dtInfo.Clone();
      DataTable KmeansAux3 = dtInfo.Clone();
      DataTable KmeansAux4 = dtInfo.Clone();
      DataTable KmeansAux5 = dtInfo.Clone();
      DataTable KmeansAux6 = dtInfo.Clone();
      DataTable KmeansAux7 = dtInfo.Clone();

      while (!igual)//enquanto a ultima iteração for diferente da anterior, a execução continua
      {
        LimpaTable(Kmeans1, Kmeans2, Kmeans3, Kmeans4, Kmeans5, Kmeans6, Kmeans7);
        SomaElementos1 = 0;
        SomaElementos2 = 0;
        SomaElementos3 = 0;
        SomaElementos4 = 0;
        SomaElementos5 = 0;
        SomaElementos6 = 0;
        SomaElementos7 = 0;

        Console.Write("\n\n---------> Iteração {0} <---------", contadorIteracao);

        foreach (DataRow row in dtInfo.Rows)
        {
          double numero = Convert.ToDouble(row["Idade"]);

          //verifiações para encaixar cada idade em seu grupo adequado de acordo com o centro
          if (Math.Abs(centro_1 - numero) <= Math.Abs(centro_2 - numero) && Math.Abs(centro_1 - numero) <= Math.Abs(centro_3 - numero)
              && Math.Abs(centro_1 - numero) <= Math.Abs(centro_4 - numero) && Math.Abs(centro_1 - numero) <= Math.Abs(centro_5 - numero)
              && Math.Abs(centro_1 - numero) <= Math.Abs(centro_6 - numero) && Math.Abs(centro_1 - numero) <= Math.Abs(centro_7 - numero))
          {
            Kmeans1.ImportRow(row);
            SomaElementos1 += numero;
          }
          else if (Math.Abs(centro_2 - numero) <= Math.Abs(centro_1 - numero) && Math.Abs(centro_2 - numero) <= Math.Abs(centro_3 - numero)
                        && Math.Abs(centro_2 - numero) <= Math.Abs(centro_4 - numero) && Math.Abs(centro_2 - numero) <= Math.Abs(centro_5 - numero)
                        && Math.Abs(centro_2 - numero) <= Math.Abs(centro_6 - numero) && Math.Abs(centro_2 - numero) <= Math.Abs(centro_7 - numero))
          {
            Kmeans2.ImportRow(row);
            SomaElementos2 += numero;
          }
          else if (Math.Abs(centro_3 - numero) <= Math.Abs(centro_1 - numero) && Math.Abs(centro_3 - numero) <= Math.Abs(centro_2 - numero)
                    && Math.Abs(centro_3 - numero) <= Math.Abs(centro_4 - numero) && Math.Abs(centro_3 - numero) <= Math.Abs(centro_5 - numero)
                    && Math.Abs(centro_3 - numero) <= Math.Abs(centro_6 - numero) && Math.Abs(centro_3 - numero) <= Math.Abs(centro_7 - numero))
          {
            Kmeans3.ImportRow(row);
            SomaElementos3 += numero;
          }
          else if (Math.Abs(centro_4 - numero) <= Math.Abs(centro_1 - numero) && Math.Abs(centro_4 - numero) <= Math.Abs(centro_2 - numero)
                   && Math.Abs(centro_4 - numero) <= Math.Abs(centro_3 - numero) && Math.Abs(centro_4 - numero) <= Math.Abs(centro_5 - numero)
                   && Math.Abs(centro_4 - numero) <= Math.Abs(centro_6 - numero) && Math.Abs(centro_4 - numero) <= Math.Abs(centro_7 - numero))
          {
            Kmeans4.ImportRow(row);
            SomaElementos4 += numero;
          }
          else if (Math.Abs(centro_5 - numero) <= Math.Abs(centro_1 - numero) && Math.Abs(centro_5 - numero) <= Math.Abs(centro_2 - numero)
                    && Math.Abs(centro_5 - numero) <= Math.Abs(centro_3 - numero) && Math.Abs(centro_5 - numero) <= Math.Abs(centro_4 - numero)
                    && Math.Abs(centro_5 - numero) <= Math.Abs(centro_6 - numero) && Math.Abs(centro_5 - numero) <= Math.Abs(centro_7 - numero))
          {
            Kmeans5.ImportRow(row);
            SomaElementos5 += numero;
          }
          else if (Math.Abs(centro_6 - numero) <= Math.Abs(centro_1 - numero) && Math.Abs(centro_6 - numero) <= Math.Abs(centro_2 - numero)
                     && Math.Abs(centro_6 - numero) <= Math.Abs(centro_3 - numero) && Math.Abs(centro_6 - numero) <= Math.Abs(centro_4 - numero)
                     && Math.Abs(centro_6 - numero) <= Math.Abs(centro_5 - numero) && Math.Abs(centro_6 - numero) <= Math.Abs(centro_7 - numero))
          {
            Kmeans6.ImportRow(row);
            SomaElementos6 += numero;
          }
          else if (Math.Abs(centro_7 - numero) <= Math.Abs(centro_1 - numero) && Math.Abs(centro_7 - numero) <= Math.Abs(centro_2 - numero)
                   && Math.Abs(centro_7 - numero) <= Math.Abs(centro_3 - numero) && Math.Abs(centro_7 - numero) <= Math.Abs(centro_4 - numero)
                   && Math.Abs(centro_7 - numero) <= Math.Abs(centro_5 - numero) && Math.Abs(centro_7 - numero) <= Math.Abs(centro_6 - numero))
          {
            Kmeans7.ImportRow(row);
            SomaElementos7 += numero;
          }

        }

        //verifica se o grupo atual é igual ao anterior, condição para parar a execução
        if (Kmeans1.Rows.Count == KmeansAux1.Rows.Count && Kmeans2.Rows.Count == KmeansAux2.Rows.Count && Kmeans3.Rows.Count == KmeansAux3.Rows.Count &&
            Kmeans4.Rows.Count == KmeansAux4.Rows.Count && Kmeans5.Rows.Count == KmeansAux5.Rows.Count && Kmeans6.Rows.Count == KmeansAux6.Rows.Count &&
            Kmeans7.Rows.Count == KmeansAux7.Rows.Count)
        {
          igual = true;
        }

        LimpaTable(KmeansAux1, KmeansAux2, KmeansAux3, KmeansAux4, KmeansAux5, KmeansAux6, KmeansAux7);


        //calulo dos novos centros apos a iteração
        centro_1 = SomaElementos1 / Kmeans1.Rows.Count;
        centro_2 = SomaElementos2 / Kmeans2.Rows.Count;
        centro_3 = SomaElementos3 / Kmeans3.Rows.Count;
        centro_4 = SomaElementos4 / Kmeans4.Rows.Count;
        centro_5 = SomaElementos5 / Kmeans5.Rows.Count;
        centro_6 = SomaElementos6 / Kmeans6.Rows.Count;
        centro_7 = SomaElementos7 / Kmeans7.Rows.Count;

        //os grupos são copiados para um grupo auxiliar para facilitar a comparação dos grupos na iteração anterior e na atual
        KmeansAux1 = Kmeans1.Copy();
        KmeansAux2 = Kmeans2.Copy();
        KmeansAux3 = Kmeans3.Copy();
        KmeansAux4 = Kmeans4.Copy();
        KmeansAux5 = Kmeans5.Copy();
        KmeansAux6 = Kmeans6.Copy();
        KmeansAux7 = Kmeans7.Copy();

        contadorIteracao++;
      }

      //criação dos arquivos ja com os grupos separados
      GeraArquivo(Kmeans1, centro_1, 001);
      GeraArquivo(Kmeans2, centro_2, 002);
      GeraArquivo(Kmeans3, centro_3, 003);
      GeraArquivo(Kmeans4, centro_4, 004);
      GeraArquivo(Kmeans5, centro_5, 005);
      GeraArquivo(Kmeans6, centro_6, 006);
      GeraArquivo(Kmeans7, centro_7, 007);

      Console.WriteLine($"\n\n---> Fim da execução!!! Os arquivos criados estão no caminho {path}");
      Console.ReadKey();
    }

    //metodo para limpar as tabelas
    public static void LimpaTable(DataTable dt1, DataTable dt2, DataTable dt3, DataTable dt4, DataTable dt5, DataTable dt6, DataTable dt7)
    {
      dt1.Rows.Clear();
      dt2.Rows.Clear();
      dt3.Rows.Clear();
      dt4.Rows.Clear();
      dt5.Rows.Clear();
      dt6.Rows.Clear();
      dt7.Rows.Clear();
    }

    //metodo para ler o arquivo e extrair as informações necessárias
    private static void LerArquivo(DataTable dtInfo)
    {
      StreamReader arquivo = new StreamReader(path + nomeArquivo);

      string arq = arquivo.ReadToEnd();
      string[] linhas = arq.Split('\n');
      foreach (string str in linhas)
      {
        string[] info = str.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
        DataRow row = dtInfo.NewRow();
        row["UserID"] = Convert.ToInt64(info[0]);
        row["Sexo"] = info[1];
        row["Idade"] = Convert.ToInt64(info[2]);
        row["Ocupacao"] = Convert.ToInt64(info[3]);
        row["CodigoPostal"] = info[4];

        dtInfo.Rows.Add(info[0], info[1], info[2], info[3], info[4]);
      }
    }

    //metodo para gerar os arquivos com todas as informações e cabeçãlho adequado 
    private static void GeraArquivo(DataTable informacoesGrupo, double mediaIdade, long codGrupo)
    {
      long qtdPessoas = informacoesGrupo.Rows.Count;
      string nomeArquivo = $@"{path}{qtdPessoas}_{mediaIdade}_{codGrupo}.txt";

      string cabecalho = @"UserID::Sexo::Idade::Ocupação::CodigoPostal";

      using (StreamWriter novoArq = new StreamWriter(nomeArquivo))
      {
        novoArq.WriteLine(cabecalho);
        foreach (DataRow row in informacoesGrupo.Rows)
        {
          novoArq.WriteLine($"{row[0].ToString()}::{row[1].ToString()}::{row[2].ToString()}::{row[3].ToString()}::{row[4].ToString()}");
        }
      }
    }
  }
}