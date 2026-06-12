---
title: Dirender Sebagai Tiff
type: docs
weight: 30
url: /id/net/rendered-as-tiff/
---
Format TIFF dikenal karena fleksibilitasnya dalam menampung gambar multi-halaman dan data. Mengingat pentingnya dan popularitas format TIFF, Aspose.Slides for .NET menyediakan dukungan untuk mengonversi presentasi menjadi dokumen TIFF.
Artikel ini menjelaskan berbagai opsi ekspor TIFF:

- Mengonversi Presentation ke TIFF dengan ukuran default.
- Mengonversi Presentation ke TIFF dengan ukuran khusus.

Metode **Save** yang diungkapkan oleh kelas **Presentation** dapat dipanggil oleh pengembang untuk mengonversi seluruh presentasi menjadi dokumen **TIFF**. Selanjutnya, kelas TiffOptions menampilkan properti ImageSize yang memungkinkan pengembang menentukan ukuran gambar bila diperlukan.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Conversion to Tiff.tiff";

//Membuat objek Presentation yang mewakili file presentasi

using (Presentation pres = new Presentation(srcFileName))

{

    //Menyimpan presentasi ke dokumen TIFF

    pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Tiff);

}
``` 
## **Unduh Kode Contoh**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Conversion%20to%20Tiff%20%28Aspose.Slides%29.zip)