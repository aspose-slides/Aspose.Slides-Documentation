---
title: Konversi dari format PPT ke PPTX
type: docs
weight: 20
url: /id/net/conversion-from-ppt-to-pptx-format/
---
Fitur unik Aspose.Slides yang memberikan fleksibilitas dalam konversi versi tanpa memengaruhi pekerjaan.
SaveFormat adalah enumerasi yang dapat mengonversi dokumen ke ekstensi yang diberikan pada tabel di bawah.

|**Nama Anggota**|**Nilai**|**Deskripsi**|
| :- | :- | :- |
|HTML|13| |
|ODP|6| |
|PDF|1| |
|PDF Notes|12| |
|POTM|11| |
|POTX|10| |
|PPS|0| |
|PPSM|9| |
|PPSX|4| |
|PPT|0| |
|PPTM|7| |
|PPTX|3| |
|TIFF|5| |
|TiffNotes|14| |
|XPS|2| |

Berikut cuplikan kode yang menunjukkan konversi dari PPT ke PPTX; Anda juga dapat melakukannya sebaliknya.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion PPT to PPTX.ppt";

string destFileName = FilePath + "Conversion PPT to PPTX.pptx";

//Membuat objek Presentation yang merepresentasikan file PPTX

Presentation pres = new Presentation(srcFileName);

//Menyimpan presentasi PPTX ke format PPTX

pres.Save(destFileName, SaveFormat.Pptx);

``` 
## **Unduh Contoh Kode**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Conversion%20between%20different%20presentation%20version%20%28Aspose.Slides%29.zip)