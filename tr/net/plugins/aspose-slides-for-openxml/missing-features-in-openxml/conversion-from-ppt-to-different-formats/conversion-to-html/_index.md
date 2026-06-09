---
title: HTML'ye Dönüştürme
type: docs
weight: 20
url: /tr/net/conversion-to-html/
---
**HTML**, veri alışverişi için yaygın olarak kullanılan birkaç formattan biridir. **Aspose.Slides for .NET**, bir sunumu HTML'ye dönüştürme desteği sağlar. Aşağıda bunun nasıl yapılacağını gösteren bir kod parçacığı bulunmaktadır.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Converting to HTML.html";

//Sunum dosyasını temsil eden bir Presentation nesnesi oluşturun

Presentation pres = new Presentation(srcFileName);

HtmlOptions htmlOpt = new HtmlOptions();

htmlOpt.HtmlFormatter = HtmlFormatter.CreateDocumentFormatter("", false);

//Sunumu HTML olarak kaydediyor

pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Html, htmlOpt);

``` 
## **Örnek Kodu İndir**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Converting%20to%20HTML%20%28Aspose.Slides%29.zip)