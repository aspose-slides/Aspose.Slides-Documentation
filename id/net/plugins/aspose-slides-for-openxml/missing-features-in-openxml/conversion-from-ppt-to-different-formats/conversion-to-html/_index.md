---
title: Konversi ke HTML
type: docs
weight: 20
url: /id/net/conversion-to-html/
---
**HTML** adalah salah satu dari beberapa format yang banyak digunakan untuk pertukaran data. **Aspose.Slides for .NET** menyediakan dukungan untuk mengonversi presentasi ke HTML. Berikut ini potongan kode yang menunjukkan cara melakukannya.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Converting to HTML.html";

//Instansiasi objek Presentation yang mewakili file presentasi

Presentation pres = new Presentation(srcFileName);

HtmlOptions htmlOpt = new HtmlOptions();

htmlOpt.HtmlFormatter = HtmlFormatter.CreateDocumentFormatter("", false);

//Menyimpan presentasi ke HTML

pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Html, htmlOpt);

``` 
## **Unduh Kode Contoh**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Converting%20to%20HTML%20%28Aspose.Slides%29.zip)