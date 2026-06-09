---
title: Sunumu XPS'ye Dönüştür
type: docs
weight: 60
url: /tr/net/convert-presentation-to-xps/
---
**XPS** formatı da veri değişimi için yaygın olarak kullanılmaktadır. Aspose.Slides for .NET bunun önemine dikkat eder ve bir sunumu XPS belgesine dönüştürmek için yerleşik destek sağlar.

Presentation sınıfı tarafından sunulan **Save** yöntemi, tüm sunumu **XPS** belgesine dönüştürmek için kullanılabilir. Ayrıca, **XpsOptions** sınıfı **SaveMetafileAsPng** özelliğini sağlar; bu özellik ihtiyaca göre true ya da false olarak ayarlanabilir.
## **Örnek**

``` 

 //Bir sunum dosyasını temsil eden Presentation nesnesi oluşturur

Presentation pres = new Presentation("Conversion.ppt");

//Sunumu TIFF belgesine kaydediyor

pres.Save("converted.xps", Aspose.Slides.Export.SaveFormat.Xps);

``` 
## **Çalışan Örneği İndir**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Converting%20to%20XPS)
## **Örnek Kodu İndir**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 

Daha fazla detay için [PowerPoint Sunumlarını .NET'te XPS'ye Dönüştür](/slides/tr/net/convert-powerpoint-to-xps/).

{{% /alert %}}