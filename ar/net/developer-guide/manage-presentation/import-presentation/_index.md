---
title: استيراد PowerPoint من PDF أو HTML
linktitle: استيراد العرض التقديمي
type: docs
weight: 60
url: /ar/net/import-presentation/
keywords: "استيراد PowerPoint, PDF إلى PowerPoint, HTML إلى PowerPoint, PDF إلى PPT, HTML إلى PPT, C#, Csharp, Aspose.Slides for .NET"
description: "استيراد PowerPoint من PDF أو HTML. تحويل PDF إلى PowerPoint. تحويل HTML إلى PowerPoint"
---

باستخدام [**Aspose.Slides for .NET**](https://products.aspose.com/slides/net/)، يمكنك استيراد العروض التقديمية من ملفات بصيغ أخرى. توفر Aspose.Slides الفئة [SlideCollection](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/) للسماح لك باستيراد العروض التقديمية من مستندات PDF.

## **استيراد PowerPoint من PDF**

في هذه الحالة، ستحول ملف PDF إلى عرض تقديمي بصيغة PowerPoint.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom: 50%;" />

1. أنشئ مثيًلا من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) .
2. استدعِ الطريقة [AddFromPdf](https://reference.aspose.com/slides/net/aspose.slides.slidecollection/addfrompdf/methods/1) ومرّر ملف PDF.
3. استخدم الطريقة [Save](https://reference.aspose.com/slides/net/aspose.slides.presentation/save/methods/5) لحفظ الملف بصيغة PowerPoint.

يعرض هذا الكود C# عملية التحويل من PDF إلى PowerPoint:
```c#
using (Presentation pres = new Presentation())
{
    pres.Slides.AddFromPdf("InputPDF.pdf");
    pres.Save("OutputPresentation.pptx", SaveFormat.Pptx);
}
```


{{% alert  title="TIP" color="primary" %}} 
قد ترغب في تجربة تطبيق الويب **Aspose free** [PDF to PowerPoint](https://products.aspose.app/slides/import/pdf-to-powerpoint) لأنه تنفيذ حي للعملية الموضحة هنا. 
{{% /alert %}} 

## **استيراد PowerPoint من HTML**

في هذه الحالة، ستحول مستند HTML إلى عرض تقديمي بصيغة PowerPoint.

1. أنشئ مثيًلا من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) .
2. استدعِ الطريقة [AddFromHtml](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/addfromhtml/#addfromhtml) ومرّر ملف HTML.
3. استخدم الطريقة [Save](https://apireference.aspose.com/slides/net/aspose.slides.presentation/save/methods/5) لحفظ الملف كوثيقة PowerPoint.

يعرض هذا الكود C# عملية التحويل من HTML إلى PowerPoint: 
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


## **الأسئلة الشائعة**

**هل يتم الحفاظ على الجداول عند استيراد PDF، وهل يمكن تحسين اكتشافها؟**

يمكن اكتشاف الجداول أثناء الاستيراد؛ يحتوي [PdfImportOptions](https://reference.aspose.com/slides/net/aspose.slides.import/pdfimportoptions/) على معامل [DetectTables](https://reference.aspose.com/slides/net/aspose.slides.import/pdfimportoptions/detecttables/) الذي يتيح التعرف على الجداول. تعتمد الفعالية على بنية ملف PDF.

{{% alert title="Note" color="warning" %}} 
يمكنك أيضًا استخدام Aspose.Slides لتحويل HTML إلى تنسيقات ملفات شائعة أخرى: 

* [HTML إلى صورة](https://products.aspose.com/slides/net/conversion/html-to-image/)
* [HTML إلى JPG](https://products.aspose.com/slides/net/conversion/html-to-jpg/)
* [HTML إلى XML](https://products.aspose.com/slides/net/conversion/html-to-xml/)
* [HTML إلى TIFF](https://products.aspose.com/slides/net/conversion/html-to-tiff/)

{{% /alert %}}