---
title: Konversi ke Tiff dengan Catatan
type: docs
weight: 10
url: /id/net/conversion-to-tiff-with-notes/
---
TIFF adalah salah satu dari beberapa format gambar yang banyak digunakan yang didukung oleh Aspose.Slides untuk .NET untuk mengonversi presentasi dengan catatan menjadi gambar. Anda juga dapat menghasilkan thumbnail slide dalam tampilan Slide Catatan. Di bawah ini ada dua cuplikan kode yang menunjukkan cara menghasilkan gambar TIFF dari sebuah presentasi dalam tampilan Slide Catatan.

Metode **Save** yang tersedia pada Kelas **Presentation** dapat digunakan untuk mengonversi seluruh presentasi dalam tampilan Slide Catatan ke format TIFF. Anda juga dapat menghasilkan thumbnail slide dalam tampilan Slide Catatan untuk slide individual.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;

string FilePath = @"..\..\..\Sample Files\";
string srcFileName = FilePath + "Tiff conversion with note.pptx";
string destFileName = FilePath + "Tiff conversion with note.tiff";

//Membuat objek Presentation yang mewakili file presentasi
using (Presentation pres = new Presentation(srcFileName))
{
    //Letakkan catatan pembicara di bawah setiap slide yang dirender
    TiffOptions tiffOptions = new TiffOptions();
    tiffOptions.SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        NotesPosition = NotesPositions.BottomFull
    };

    //Menyimpan presentasi ke TIFF dengan catatan
    pres.Save(destFileName, SaveFormat.Tiff, tiffOptions);
}
``` 
## **Unduh Kode Contoh**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Tiff%20conversion%20with%20note%20%28Aspose.Slides%29.zip)