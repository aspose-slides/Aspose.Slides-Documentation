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
description: "استيراد مستندات PDF و HTML بسهولة إلى عروض PowerPoint و OpenDocument في .NET باستخدام Aspose.Slides لمعالجة الشرائح بسلاسة وعالية الأداء."
---

Using [**Aspose.Slides for .NET**](https://products.aspose.com/slides/net/), you can import presentations from files in other formats. Aspose.Slides provides the [SlideCollection](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/) class to allow you to import presentations from PDF documents.

## **استيراد PowerPoint من PDF**

في هذه الحالة، يمكنك تحويل ملف PDF إلى عرض تقديمي PowerPoint.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom: 50%;" />

1. أنشئ مثيلاً للفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) .
2. استدعِ الطريقة [AddFromPdf](https://reference.aspose.com/slides/net/aspose.slides.slidecollection/addfrompdf/methods/1) ومرّر ملف PDF.
3. استخدم الطريقة [Save](https://reference.aspose.com/slides/net/aspose.slides.presentation/save/methods/5) لحفظ الملف بصيغة PowerPoint.

```c#
using (Presentation pres = new Presentation())
{
    pres.Slides.AddFromPdf("InputPDF.pdf");
    pres.Save("OutputPresentation.pptx", SaveFormat.Pptx);
}
```


{{% alert  title="نصيحة" color="primary" %}} 
قد ترغب في تجربة تطبيق الويب **Aspose free** [PDF إلى PowerPoint](https://products.aspose.app/slides/import/pdf-to-powerpoint) لأنه تنفيذ حي للعملية الموضحة هنا. 
{{% /alert %}} 

## **استيراد PowerPoint من HTML**

في هذه الحالة، يمكنك تحويل مستند HTML إلى عرض تقديمي PowerPoint.

1. أنشئ مثيلاً للفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) .
2. استدعِ الطريقة [AddFromHtml](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/addfromhtml/#addfromhtml) ومرّر ملف HTML.
3. استخدم الطريقة [Save](https://apireference.aspose.com/slides/net/aspose.slides.presentation/save/methods/5) لحفظ الملف كمستند PowerPoint.

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

يمكن اكتشاف الجداول أثناء الاستيراد؛ يتضمن [PdfImportOptions](https://reference.aspose.com/slides/net/aspose.slides.import/pdfimportoptions/) المعامل [DetectTables](https://reference.aspose.com/slides/net/aspose.slides.import/pdfimportoptions/detecttables/) الذي يتيح التعرف على الجداول. تعتمد الفعالية على بنية ملف PDF.

{{% alert title="ملاحظة" color="warning" %}} 
يمكنك أيضًا استخدام Aspose.Slides لتحويل HTML إلى صيغ ملفات شائعة أخرى: 

* [HTML إلى صورة](https://products.aspose.com/slides/net/conversion/html-to-image/)
* [HTML إلى JPG](https://products.aspose.com/slides/net/conversion/html-to-jpg/)
* [HTML إلى XML](https://products.aspose.com/slides/net/conversion/html-to-xml/)
* [HTML إلى TIFF](https://products.aspose.com/slides/net/conversion/html-to-tiff/)

{{% /alert %}}