---
title: استيراد باوربوينت من PDF أو HTML
linktitle: استيراد العرض التقديمي
type: docs
weight: 60
url: /net/import-presentation/
keywords: "استيراد باوربوينت، PDF إلى باوربوينت، HTML إلى باوربوينت، PDF إلى PPT، HTML إلى PPT، C#، Csharp، Aspose.Slides لـ .NET"
description: "استيراد باوربوينت من PDF أو HTML. تحويل PDF إلى باوربوينت. تحويل HTML إلى باوربوينت"
---

باستخدام [**Aspose.Slides لـ .NET**](https://products.aspose.com/slides/net/)، يمكنك استيراد العروض التقديمية من الملفات بصيغ أخرى. يوفر Aspose.Slides الفئة [SlideCollection](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/) للسماح لك باستيراد العروض التقديمية من مستندات PDF.

## **استيراد باوربوينت من PDF**

في هذه الحالة، ستقوم بتحويل PDF إلى عرض تقديمي باوربوينت.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom: 50%;" />

1. قم بإنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
2. قم باستدعاء طريقة [AddFromPdf](https://reference.aspose.com/slides/net/aspose.slides.slidecollection/addfrompdf/methods/1) ومرر ملف PDF.
3. استخدم طريقة [Save](https://reference.aspose.com/slides/net/aspose.slides.presentation/save/methods/5) لحفظ الملف بتنسيق باوربوينت.

هذا هو كود C# الذي يوضح عملية تحويل PDF إلى باوربوينت:

```c#
using (Presentation pres = new Presentation())
{
    pres.Slides.AddFromPdf("InputPDF.pdf");
    pres.Save("OutputPresentation.pptx", SaveFormat.Pptx);
}
```

{{% alert  title="نصيحة" color="primary" %}} 

يمكنك الاطلاع على تطبيق **Aspose المجاني** [PDF إلى PowerPoint](https://products.aspose.app/slides/import/pdf-to-powerpoint) لأنه تطبيق مباشر للعملية الموصوفة هنا. 

{{% /alert %}} 

## **استيراد باوربوينت من HTML**

في هذه الحالة، ستقوم بتحويل مستند HTML إلى عرض تقديمي باوربوينت.

1. قم بإنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
2. قم باستدعاء طريقة [AddFromHtml](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/addfromhtml/#addfromhtml) ومرر ملف HTML.
3. استخدم طريقة [Save](https://apireference.aspose.com/slides/net/aspose.slides.presentation/save/methods/5) لحفظ الملف كوثيقة باوربوينت.

هذا هو كود C# الذي يوضح عملية تحويل HTML إلى باوربوينت:

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

{{% alert title="ملاحظة" color="warning" %}} 

يمكنك أيضًا استخدام Aspose.Slides لتحويل HTML إلى صيغ ملفات شائعة أخرى:

* [HTML إلى صورة](https://products.aspose.com/slides/net/conversion/html-to-image/)
* [HTML إلى JPG](https://products.aspose.com/slides/net/conversion/html-to-jpg/)
* [HTML إلى XML](https://products.aspose.com/slides/net/conversion/html-to-xml/)
* [HTML إلى TIFF](https://products.aspose.com/slides/net/conversion/html-to-tiff/)

{{% /alert %}}