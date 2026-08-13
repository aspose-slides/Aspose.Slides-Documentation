---
title: استيراد عروض تقديمية من PDF أو HTML في .NET
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
description: "استورد مستندات PDF وHTML بسهولة إلى عروض PowerPoint وOpenDocument في .NET باستخدام Aspose.Slides لمعالجة الشرائح بسلاسة وفعالية عالية."
---
## **المقدمة**

باستخدام Aspose.Slides، يمكنك استيراد العروض التقديمية من ملفات بصيغ أخرى. توفر Aspose.Slides الفئة [SlideCollection](https://reference.aspose.com/slides/ar/net/aspose.slides/slidecollection/) التي تتيح لك استيراد العروض من مستندات PDF وHTML.

## **استيراد PowerPoint من PDF**

في هذه الحالة، يمكنك تحويل ملف PDF إلى عرض تقديمي بصيغة PowerPoint.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom: 50%;" />

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/) .
2. استدعاء الطريقة [AddFromPdf](https://reference.aspose.com/slides/ar/net/aspose.slides.slidecollection/addfrompdf/methods/1) وتمرير ملف PDF.
3. استخدام الطريقة [Save](https://reference.aspose.com/slides/ar/net/aspose.slides.presentation/save/methods/5) لحفظ الملف بصيغة PowerPoint.

يوضح هذا الكود C# عملية تحويل PDF إلى PowerPoint:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    pres.Slides.AddFromPdf("InputPDF.pdf");
    pres.Save("OutputPresentation.pptx", SaveFormat.Pptx);
}
```

{{% alert title="نصيحة" color="info" %}} 
قد ترغب في تجربة تطبيق الويب **Aspose free** [PDF إلى PowerPoint](https://products.aspose.app/slides/ar/import/pdf-to-powerpoint) لأنه تنفيذ حي للعملية الموصوفة هنا. 
{{% /alert %}} 

## **استيراد PowerPoint من HTML**

في هذه الحالة، يمكنك تحويل مستند HTML إلى عرض تقديمي بصيغة PowerPoint.

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/) .
2. استدعاء الطريقة [AddFromHtml](https://reference.aspose.com/slides/ar/net/aspose.slides/slidecollection/addfromhtml/#addfromhtml) وتمرير ملف HTML.
3. استخدام الطريقة [Save](https://apireference.aspose.com/slides/ar/net/aspose.slides.presentation/save/methods/5) لحفظ الملف كوثيقة PowerPoint.

يوضح هذا الكود C# عملية تحويل HTML إلى PowerPoint: 

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

## **الأسئلة الشائعة**

### هل يتم الحفاظ على الجداول عند استيراد ملف PDF، وهل يمكن تحسين اكتشافها؟

يمكن اكتشاف الجداول أثناء الاستيراد؛ يحتوي PdfImportOptions على معلمة [DetectTables](https://reference.aspose.com/slides/ar/net/aspose.slides.import/pdfimportoptions/detecttables/) التي تمكّن من التعرف على الجداول. تعتمد الفعالية على بنية ملف PDF.

{{% alert title="ملاحظة" color="warning" %}} 
يمكنك أيضًا استخدام Aspose.Slides لتحويل HTML إلى صيغ ملفات شائعة أخرى: 

* [HTML إلى صورة](https://products.aspose.com/slides/ar/net/conversion/html-to-image/)
* [HTML إلى JPG](https://products.aspose.com/slides/ar/net/conversion/html-to-jpg/)
* [HTML إلى XML](https://products.aspose.com/slides/ar/net/conversion/html-to-xml/)
* [HTML إلى TIFF](https://products.aspose.com/slides/ar/net/conversion/html-to-tiff/)

{{% /alert %}}