---
title: Sunumu HTML'ye Dönüştür
type: docs
weight: 40
url: /tr/net/convert-presentation-to-html/
---
**HTML** bir çok yaygın kullanılan veri değişim formatından biridir. **Aspose.Slides for .NET**, bir sunumu HTML'ye dönüştürme desteği sağlar. Aşağıda nasıl yapılacağını gösteren kod snippet'i yer almaktadır.
## **Örnek**
``` 
 //Bir sunum dosyasını temsil eden Presentation nesnesini örnekleyin

Presentation pres = new Presentation("Conversion.ppt");

HtmlOptions htmlOpt = new HtmlOptions();

htmlOpt.HtmlFormatter = HtmlFormatter.CreateDocumentFormatter("", false);

//Sunumu HTML'ye kaydediyor

pres.Save("Converted.html", Aspose.Slides.Export.SaveFormat.Html, htmlOpt);

``` 
## **Çalışan Örneği İndir**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Converting%20to%20HTML)
## **Örnek Kodu İndir**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 

Daha fazla detay için, [PowerPoint Sunumlarını .NET'te HTML'ye Dönüştür](/slides/tr/net/convert-powerpoint-to-html/) adresini ziyaret edin.

{{% /alert %}}