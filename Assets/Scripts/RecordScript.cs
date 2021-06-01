using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class RecordScript : MonoBehaviour
{
    public int[] recordArr = new int[5] { 0, 0, 0, 0, 0};
    public string[] nameArr = new string[5] { null, null, null, null, null };
    public Text Rec0, Rec1, Rec2, Rec3, Rec4, textMoves2;
    public InputField FieldOfName;
    int moves = 0;
   

    public void ReadFromRecordList() {
        int count = 0;
        StreamReader ReadFile = new StreamReader("Save.txt");
        if (ReadFile != null) {
            while (!ReadFile.EndOfStream) {
                
                nameArr[count] = System.Convert.ToString(ReadFile.ReadLine());
                recordArr[count] = System.Convert.ToInt32(ReadFile.ReadLine());
                ++count;
            }
        }
        ReadFile.Close();
    }


    public void WriteToRecordList()
    {
        StreamWriter WriteFile = new StreamWriter("Save.txt", false, System.Text.Encoding.Default);
        if (WriteFile != null)
        {
            for (int i = 0; i < 5; ++i) {
                WriteFile.WriteLine(nameArr[i]);
                WriteFile.WriteLine(recordArr[i]);
                }
        }
        WriteFile.Close();
    }

    public int Comparison(int moves) {
        for (int i=0; i<5; ++i) {
            if (moves < recordArr[i] || recordArr[i] == 0) {
                return i;
            }
        }
        return -1;
    }


    public void OutputRecord() {
        Rec0.text = "1." + nameArr[0] + "(" + recordArr[0] + ")";
        Rec1.text = "2." + nameArr[1] + "(" + recordArr[1] + ")";
        Rec2.text = "3." + nameArr[2] + "(" + recordArr[2] + ")";
        Rec3.text = "4." + nameArr[3] + "(" + recordArr[3] + ")";
        Rec4.text = "5." + nameArr[4] + "(" + recordArr[4] + ")";
    }

    public void saveRecord() {
        ReadFromRecordList();
        if (FieldOfName.text != null) {
            moves = int.Parse(textMoves2.text.ToString());
            int index = Comparison(moves);
            if (index != -1) {
                if (index < 4) {
                    recordArr[index + 1] = recordArr[index];
                    nameArr[index + 1] = nameArr[index];
                }
                recordArr[index] = moves;
                nameArr[index] = FieldOfName.text;
            }
            WriteToRecordList();
        }
    }

   
}
