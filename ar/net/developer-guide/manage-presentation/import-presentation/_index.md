---
title: استيراد العروض التقديمية من PDF أو HTML في .NET
linktitle: استيراد العرض التقديمي
type: docs
weight: 60
url: /ar/net/import-presentation/
keywords:
- استيراد عرض تقديمي
- استيراد شريحة
- استيراد PDF
- استيراد HTML
- PDF إلى عرض تقديمي
- PDF إلى PPT
- PDF إلى PPTX
- PDF إلى ODP
- HTML إلى عرض تقديمي
- HTML إلى PPT
- HTML إلى PPTX
- HTML إلى ODP
- PowerPoint
- OpenDocument
- .NET
- C#
- Aspose.Slides
description: "استيراد مستندات PDF وHTML بسهولة إلى عروض PowerPoint وOpenDocument في .NET باستخدام Aspose.Slides لمعالجة الشرائح ذات الأداء العالي والسلس."
---

باستخدام [**Aspose.Slides for .NET**](https://products.aspose.com/slides/net/)، يمكنك استيراد العروض التقديمية من ملفات بصيغ أخرى. توفر Aspose.Slides الفئة [SlideCollection](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/) للسماح لك باستيراد العروض التقديمية من مستندات PDF.

## **استيراد PowerPoint من PDF**

في هذه الحالة، ستحول ملف PDF إلى عرض تقديمي PowerPoint.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom: 50%;" />

1. أنشئ كائنًا من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).  
2. استدعِ طريقة [AddFromPdf](https://reference.aspose.com/slides/net/aspose.slides.slidecollection/addfrompdf/methods/1) ومرّر ملف PDF.  
3. استخدم طريقة [Save](https://reference.aspose.com/slides/net/aspose.slides.presentation/save/methods/5) لحفظ الملف بصيغة PowerPoint.

هذا الكود C# يوضح عملية التحويل من PDF إلى PowerPoint:
```c#
using (Presentation pres = new Presentation())
{
    pres.Slides.AddFromPdf("InputPDF.pdf");
    pres.Save("OutputPresentation.pptx", SaveFormat.Pptx);
}
```


{{% alert  title="TIP" color="primary" %}} 

قد ترغب في تجربة تطبيق **Aspose free** [PDF to PowerPoint](https://products.aspose.app/slides/import/pdf-to-powerpoint) على الويب لأنه تنفيذ حي للعملية الموضحة هنا. 

{{% /alert %}} 

## **استيراد PowerPoint من HTML**

في هذه الحالة، ستحول مستند HTML إلى عرض تقديمي PowerPoint.

1. أنشئ كائنًا من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).  
2. استدعِ طريقة [AddFromHtml](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/addfromhtml/#addfromhtml) ومرّر ملف HTML.  
3. استخدم طريقة [Save](https://apireference.aspose.com/slides/net/aspose.slides.presentation/save/methods/5) لحفظ الملف كمستند PowerPoint.

هذا الكود C# يوضح عملية التحويل من HTML إلى PowerPoint: 
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


## **FAQ**

**هل يتم الحفاظ على الجداول عند استيراد PDF، وهل يمكن تحسين اكتشافها؟**

يمكن اكتشاف الجداول أثناء الاستيراد؛ تتضمن [PdfImportOptions](https://reference.aspose.com/slides/net/aspose.slides.import/pdfimportoptions/) المعامل [DetectTables](https://reference.aspose.com/slides/net/aspose.slides.import/pdfimportoptions/detecttables/) الذي يفعّل التعرف على الجداول. تعتمد الفعالية على بنية ملف PDF.

{{% alert title="Note" color="warning" %}} 

يمكنك أيضًا استخدام Aspose.Slides لتحويل HTML إلى صيغ ملفات شائعة أخرى: 

* [HTML إلى صورة](https://products.aspose.com/slides/net/conversion/html-to-image/)  
* [HTML إلى JPG](https://products.aspose.com/slides/net/conversion/html-to-jpg/)  
* [HTML إلى XML](https://products.aspose.com/slides/net/conversion/html-to-xml/)  
* [HTML إلى TIFF](https://products.aspose.com/slides/net/conversion/html-to-tiff/)

{{% /alert %}}