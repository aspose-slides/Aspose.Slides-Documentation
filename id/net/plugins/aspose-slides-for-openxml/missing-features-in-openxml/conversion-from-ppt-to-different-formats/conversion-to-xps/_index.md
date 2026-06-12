---
title: Konversi ke XPS
type: docs
weight: 40
url: /id/net/conversion-to-xps/
---
**XPS** format juga banyak digunakan untuk pertukaran data. Aspose.Slides for .NET memperhatikan pentingnya dan menyediakan dukungan bawaan untuk mengonversi presentasi menjadi dokumen XPS.

Metode **Save** yang disediakan oleh kelas Presentation dapat digunakan untuk mengonversi seluruh presentasi menjadi dokumen **XPS**. Selanjutnya, kelas **XpsOptions** mengekspos properti **SaveMetafileAsPng** yang dapat diatur ke true atau false sesuai kebutuhan.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Converting to XPS.xps";

//Membuat objek Presentation yang mewakili file presentasi

Presentation pres = new Presentation(srcFileName);

//Menyimpan presentasi ke dokumen TIFF

pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Xps);

``` 
## **Unduh Kode Contoh**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Converting%20to%20XPS%20%28Aspose.Slides%29.zip)