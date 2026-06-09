---
title: Aspose.Slides'te PPT'den PPTX formatına dönüşüm
type: docs
weight: 10
url: /tr/net/conversion-from-ppt-to-pptx-format-in-aspose-slides/
---
**Aspose.Slides** for .NET artık geliştiricilerin Presentation sınıfı örneğiyle PPT'ye erişmesini ve bunu ilgili PPTX formatına dönüştürmesini sağlar. Şu anda, PPT'den PPTX'e kısmi dönüşümü desteklemektedir. PPT'den PPTX'e dönüşümde hangi özelliklerin desteklendiği ve desteklenmediği hakkında daha fazla bilgi için lütfen bu dokümantasyon bağlantısına gidin.

**Aspose.Slides** for .NET, PPTX sunum dosyasını temsil eden Presentation sınıfını sunar. Presentation sınıfı, nesne örneklendiğinde artık PPT'ye de Presentation aracılığıyla erişebilir.

``` csharp

 //Bir PPTX dosyasını temsil eden Presentation nesnesi oluştur

PresentationEx pres = new PresentationEx("Conversion.ppt");

//PPTX sunumunu PPTX formatına kaydetme

pres.Save(MyDir +"Converted.pptx", SaveFormat.Pptx);

``` 
## **Download Sample Code**
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Conversion%20PPT%20to%20PPTX%20%28Aspose.Slides%29.zip)