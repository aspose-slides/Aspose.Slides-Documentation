---
title: PDF veya HTML'den .NET'te Sunumları İçe Aktar
linktitle: Sunumu İçe Aktar
type: docs
weight: 60
url: /tr/net/import-presentation/
keywords:
- sunum içe aktar
- slayt içe aktar
- PDF içe aktar
- HTML içe aktar
- PDF'den sunuma
- PDF'den PPT
- PDF'den PPTX
- PDF'den ODP
- HTML'den sunuma
- HTML'den PPT
- HTML'den PPTX
- HTML'den ODP
- PowerPoint
- OpenDocument
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides ile .NET'te PDF ve HTML belgelerini sorunsuz ve yüksek performanslı slayt işleme için PowerPoint ve OpenDocument sunumlarına zahmetsizce içe aktarın."
---
## **Giriş**

Aspose.Slides kullanarak, diğer formatlardaki dosyalardan sunumları içe aktarabilirsiniz. Aspose.Slides, PDF ve HTML belgelerinden sunumları içe aktarmanıza olanak tanıyan SlideCollection sınıfını sağlar.

## **PDF'den PowerPoint'i İçe Aktar**

Bu durumda, bir PDF dosyasını PowerPoint sunumuna dönüştürürsünüz.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom: 50%;"/>

1. [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
2. [AddFromPdf](https://reference.aspose.com/slides/tr/net/aspose.slides.slidecollection/addfrompdf/methods/1) yöntemini çağırın ve PDF dosyasını geçirin.  
3. Dosyayı PowerPoint formatında kaydetmek için [Save](https://reference.aspose.com/slides/tr/net/aspose.slides.presentation/save/methods/5) yöntemini kullanın.

Bu C# kodu PDF'den PowerPoint'e dönüşümü gösterir:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    pres.Slides.AddFromPdf("InputPDF.pdf");
    pres.Save("OutputPresentation.pptx", SaveFormat.Pptx);
}
```

{{% alert  title="TIP" color="info" %}} 
Burada açıklanan sürecin canlı bir uygulaması olduğu için Aspose ücretsiz PDF'den PowerPoint'e web uygulamasına göz atmak isteyebilirsiniz. 
{{% /alert %}} 

## **HTML'den PowerPoint'i İçe Aktar**

Bu durumda, bir HTML belgesini PowerPoint sunumuna dönüştürürsünüz.

1. [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
2. [AddFromHtml](https://reference.aspose.com/slides/tr/net/aspose.slides/slidecollection/addfromhtml/#addfromhtml) yöntemini çağırın ve HTML dosyasını geçirin.  
3. Dosyayı PowerPoint belgesi olarak kaydetmek için [Save](https://apireference.aspose.com/slides/tr/net/aspose.slides.presentation/save/methods/5) yöntemini kullanın.

Bu C# kodu HTML'den PowerPoint'e dönüşümü gösterir: 

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation())
{
    using (var htmlStream = File.OpenRead("page.html"))
    {
        presentation.Slides.AddFromHtml(htmlStream);
    }

    presentation.Save("MyPresentation.pptx", SaveFormat.Pptx);
}
```

## **SSS**

### PDF içe aktarırken tablolar korunur mu ve tespiti geliştirilebilir mi?

Tablolar içe aktarım sırasında tespit edilebilir; PdfImportOptions sınıfı, tablo tanımını etkinleştiren DetectTables parametresini içerir. Etkililik, PDF'in yapısına bağlıdır.

{{% alert title="Note" color="warning" %}} 
Ayrıca Aspose.Slides'i HTML'yi diğer popüler dosya formatlarına dönüştürmek için de kullanabilirsiniz: 

* [HTML to image](https://products.aspose.com/slides/tr/net/conversion/html-to-image/)
* [HTML to JPG](https://products.aspose.com/slides/tr/net/conversion/html-to-jpg/)
* [HTML to XML](https://products.aspose.com/slides/tr/net/conversion/html-to-xml/)
* [HTML to TIFF](https://products.aspose.com/slides/tr/net/conversion/html-to-tiff/)

{{% /alert %}}