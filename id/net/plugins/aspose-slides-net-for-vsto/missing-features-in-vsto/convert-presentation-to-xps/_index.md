---
title: Mengonversi Presentasi ke XPS
type: docs
weight: 60
url: /id/net/convert-presentation-to-xps/
---
**XPS** format juga banyak digunakan untuk pertukaran data. Aspose.Slides untuk .NET memperhatikan pentingnya dan menyediakan dukungan bawaan untuk mengonversi presentasi menjadi dokumen XPS.

Metode **Save** yang disediakan oleh kelas Presentation dapat digunakan untuk mengonversi seluruh presentasi menjadi dokumen **XPS**. Selanjutnya, kelas **XpsOptions** menampilkan properti **SaveMetafileAsPng** yang dapat diatur ke true atau false sesuai kebutuhan.
## **Contoh**

``` 

 //Membuat objek Presentation yang mewakili file presentasi

Presentation pres = new Presentation("Conversion.ppt");

//Menyimpan presentasi ke dokumen TIFF

pres.Save("converted.xps", Aspose.Slides.Export.SaveFormat.Xps);
``` 
## **Unduh Contoh yang Berjalan**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Converting%20to%20XPS)
## **Unduh Kode Contoh**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 

Untuk detail lebih lanjut, kunjungi [Mengonversi Presentasi PowerPoint ke XPS di .NET](/slides/id/net/convert-powerpoint-to-xps/).

{{% /alert %}}