---
title: استيراد العروض التقديمية من PDF أو HTML في .NET
linktitle: استيراد عرض تقديمي
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
description: "استيراد مستندات PDF وHTML بسهولة إلى عروض PowerPoint وOpenDocument في .NET باستخدام Aspose.Slides لمعالجة شرائح سلسة وعالية الأداء."
---

باستخدام [**Aspose.Slides for .NET**](https://products.aspose.com/slides/net/)، يمكنك استيراد العروض التقديمية من ملفات بتنسيقات أخرى. يوفر Aspose.Slides الفئة [SlideCollection](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/) للسماح لك باستيراد العروض التقديمية من مستندات PDF.

## **استيراد PowerPoint من PDF**

في هذه الحالة، ستحول ملف PDF إلى عرض PowerPoint.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom: 50%;" />

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) .
2. استدعاء الطريقة [AddFromPdf](https://reference.aspose.com/slides/net/aspose.slides.slidecollection/addfrompdf/methods/1) وتمرير ملف PDF.
3. استخدام الطريقة [Save](https://reference.aspose.com/slides/net/aspose.slides.presentation/save/methods/5) لحفظ الملف بتنسيق PowerPoint.

هذا الكود C# يوضح عملية تحويل PDF إلى PowerPoint:
```c#
using (Presentation pres = new Presentation())
{
    pres.Slides.AddFromPdf("InputPDF.pdf");
    pres.Save("OutputPresentation.pptx", SaveFormat.Pptx);
}
```


{{% alert  title="TIP" color="primary" %}} 
قد ترغب في تجربة تطبيق الويب **Aspose free** [PDF to PowerPoint](https://products.aspose.app/slides/import/pdf-to-powerpoint) لأنه تنفيذ مباشر للعملية الموضحة هنا. 
{{% /alert %}} 

## **استيراد PowerPoint من HTML**

في هذه الحالة، ستحول مستند HTML إلى عرض PowerPoint.

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) .
2. استدعاء الطريقة [AddFromHtml](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/addfromhtml/#addfromhtml) وتمرير ملف HTML.
3. استخدام الطريقة [Save](https://apireference.aspose.com/slides/net/aspose.slides.presentation/save/methods/5) لحفظ الملف كمستند PowerPoint.

هذا الكود C# يوضح عملية تحويل HTML إلى PowerPoint: 
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


## **الأسئلة المتكررة**

**هل يتم الحفاظ على الجداول عند استيراد PDF، وهل يمكن تحسين اكتشافها؟**

يمكن اكتشاف الجداول أثناء الاستيراد؛ يحتوي [PdfImportOptions](https://reference.aspose.com/slides/net/aspose.slides.import/pdfimportoptions/) على معامل [DetectTables](https://reference.aspose.com/slides/net/aspose.slides.import/pdfimportoptions/detecttables/) الذي يمكّن التعرف على الجداول. يعتمد الفعالية على بنية ملف PDF.

{{% alert title="Note" color="warning" %}} 
يمكنك أيضًا استخدام Aspose.Slides لتحويل HTML إلى صيغ ملفات شائعة أخرى: 

* [HTML إلى صورة](https://products.aspose.com/slides/net/conversion/html-to-image/)
* [HTML إلى JPG](https://products.aspose.com/slides/net/conversion/html-to-jpg/)
* [HTML إلى XML](https://products.aspose.com/slides/net/conversion/html-to-xml/)
* [HTML إلى TIFF](https://products.aspose.com/slides/net/conversion/html-to-tiff/)

{{% /alert %}}