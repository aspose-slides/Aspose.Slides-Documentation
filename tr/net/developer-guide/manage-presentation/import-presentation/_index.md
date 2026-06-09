---
title: PDF veya HTML'den .NET'te Sunumları İçeri Aktarma
linktitle: Sunumu İçeri Aktar
type: docs
weight: 60
url: /tr/net/import-presentation/
keywords:
- sunum içe aktar
- slayt içe aktar
- PDF içe aktar
- HTML içe aktar
- PDF'den sunuma
- PDF'den PPT'ye
- PDF'den PPTX'e
- PDF'den ODP'ye
- HTML'den sunuma
- HTML'den PPT'ye
- HTML'den PPTX'e
- HTML'den ODP'ye
- PowerPoint
- OpenDocument
- .NET
- C#
- Aspose.Slides
description: Aspose.Slides ile .NET'te PDF ve HTML belgelerini PowerPoint ve OpenDocument sunumlarına sorunsuz ve yüksek performanslı slayt işleme ile zahmetsizce içe aktarın.
---
## **Giriş**

Aspose.Slides kullanarak, diğer biçimlerdeki dosyalardan sunumları içe aktarabilirsiniz. Aspose.Slides, PDF ve HTML belgelerinden sunumları içe aktarmanıza olanak tanıyan [SlideCollection](https://reference.aspose.com/slides/tr/net/aspose.slides/slidecollection/) sınıfını sağlar.

## **PDF'den PowerPoint İçe Aktarma**

Bu durumda, bir PDF'yi PowerPoint sunumuna dönüştürebilirsiniz.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom: 50%;" />

1. [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun. 
2. [AddFromPdf](https://reference.aspose.com/slides/tr/net/aspose.slides.slidecollection/addfrompdf/methods/1) metodunu çağırın ve PDF dosyasını iletin. 
3. Dosyayı PowerPoint formatında kaydetmek için [Save](https://reference.aspose.com/slides/tr/net/aspose.slides.presentation/save/methods/5) metodunu kullanın.

Bu C# kodu PDF'den PowerPoint'e dönüştürme işlemini gösterir:

```c#
using (Presentation pres = new Presentation())
{
    pres.Slides.AddFromPdf("InputPDF.pdf");
    pres.Save("OutputPresentation.pptx", SaveFormat.Pptx);
}
```

{{% alert  title="TIP" color="primary" %}} 
**Aspose ücretsiz** [PDF to PowerPoint](https://products.aspose.app/slides/tr/import/pdf-to-powerpoint) web uygulamasını incelemek isteyebilirsiniz, çünkü burada açıklanan sürecin canlı bir uygulamasıdır. 
{{% /alert %}} 

## **HTML'den PowerPoint İçe Aktarma**

Bu durumda, bir HTML belgesini PowerPoint sunumuna dönüştürebilirsiniz.

1. [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun. 
2. [AddFromHtml](https://reference.aspose.com/slides/tr/net/aspose.slides/slidecollection/addfromhtml/#addfromhtml) metodunu çağırın ve HTML dosyasını iletin. 
3. Dosyayı PowerPoint belgesi olarak kaydetmek için [Save](https://apireference.aspose.com/slides/tr/net/aspose.slides.presentation/save/methods/5) metodunu kullanın.

Bu C# kodu HTML'den PowerPoint'e dönüştürme işlemini gösterir: 

```c#
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

**PDF içe aktarılırken tablolar korunur mu ve algılamaları iyileştirilebilir mi?**

Tablolar içe aktarma sırasında algılanabilir; [PdfImportOptions](https://reference.aspose.com/slides/tr/net/aspose.slides.import/pdfimportoptions/) sınıfı, tablo tanıma özelliğini etkinleştiren bir [DetectTables](https://reference.aspose.com/slides/tr/net/aspose.slides.import/pdfimportoptions/detecttables/) parametresi içerir. Etkinlik, PDF'nin yapısına bağlıdır.

{{% alert title="Note" color="warning" %}} 
Ayrıca Aspose.Slides'i HTML'yi diğer popüler dosya formatlarına dönüştürmek için kullanabilirsiniz: 

* [HTML'den görüntüye](https://products.aspose.com/slides/tr/net/conversion/html-to-image/)
* [HTML'den JPG'ye](https://products.aspose.com/slides/tr/net/conversion/html-to-jpg/)
* [HTML'den XML'e](https://products.aspose.com/slides/tr/net/conversion/html-to-xml/)
* [HTML'den TIFF'e](https://products.aspose.com/slides/tr/net/conversion/html-to-tiff/)

{{% /alert %}}