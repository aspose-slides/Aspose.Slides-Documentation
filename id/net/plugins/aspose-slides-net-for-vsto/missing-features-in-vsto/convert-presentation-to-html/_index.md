---
title: Konversi Presentasi ke HTML
type: docs
weight: 40
url: /id/net/convert-presentation-to-html/
---
**HTML** adalah salah satu format yang banyak digunakan untuk pertukaran data. **Aspose.Slides for .NET** menyediakan dukungan untuk mengonversi presentasi ke HTML. Di bawah ini cuplikan kode yang menunjukkan cara melakukannya.
## **Contoh**
``` 

 //Instansiasi objek Presentation yang mewakili file presentasi

Presentation pres = new Presentation("Conversion.ppt");

HtmlOptions htmlOpt = new HtmlOptions();

htmlOpt.HtmlFormatter = HtmlFormatter.CreateDocumentFormatter("", false);

//Menyimpan presentasi ke HTML

pres.Save("Converted.html", Aspose.Slides.Export.SaveFormat.Html, htmlOpt);

``` 
## **Unduh Contoh yang Berjalan**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Converting%20to%20HTML)
## **Unduh Kode Contoh**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 
Untuk detail lebih lanjut, kunjungi [Convert PowerPoint Presentations to HTML in .NET](/slides/id/net/convert-powerpoint-to-html/).
{{% /alert %}}