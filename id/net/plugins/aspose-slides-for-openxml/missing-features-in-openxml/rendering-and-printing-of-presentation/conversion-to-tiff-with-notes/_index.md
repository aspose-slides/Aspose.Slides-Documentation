---
title: Konversi ke Tiff dengan Catatan
type: docs
weight: 10
url: /id/net/conversion-to-tiff-with-notes/
---
TIFF adalah salah satu dari beberapa format gambar yang banyak digunakan yang didukung oleh Aspose.Slides for .NET untuk mengonversi presentasi dengan catatan menjadi gambar. Anda juga dapat menghasilkan thumbnail slide di tampilan Slide Catatan. Di bawah ini ada dua cuplikan kode yang menunjukkan cara menghasilkan gambar TIFF dari sebuah presentasi dalam tampilan Slide Catatan.

Metode **Save** yang disediakan oleh Kelas **Presentation** dapat digunakan untuk mengonversi seluruh presentasi dalam tampilan Slide Catatan ke TIFF. Anda juga dapat menghasilkan thumbnail slide dalam tampilan Slide Catatan untuk slide individual.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Tiff conversion with note.pptx";

string destFileName = FilePath + "Tiff conversion with note.tiff";

//Instansiasi objek Presentation yang merepresentasikan file presentasi

Presentation pres = new Presentation(srcFileName);

//Menyimpan presentasi ke catatan TIFF

pres.Save(destFileName, SaveFormat.TiffNotes);

``` 
## **Download Sample Code**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Tiff%20conversion%20with%20note%20%28Aspose.Slides%29.zip)