---
title: استيراد العرض التقديمي
type: docs
weight: 60
url: /ar/python-net/import-presentation/
keywords: "استيراد PowerPoint، PDF إلى عرض تقديمي، PDF إلى PPTX، PDF إلى PPT، بايثون، Aspose.Slides لبايثون عبر .NET"
description: "استيراد عرض PowerPoint من PDF. تحويل PDF إلى PowerPoint"
---

باستخدام [**Aspose.Slides لبايثون عبر .NET**](https://products.aspose.com/slides/python-net/)، يمكنك استيراد العروض التقديمية من ملفات بصيغ أخرى. توفر Aspose.Slides فئة [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/) لتسمح لك باستيراد العروض التقديمية من PDFs، مستندات HTML، إلخ.

## **استيراد PowerPoint من PDF**

في هذه الحالة، ستحول PDF إلى عرض تقديمي PowerPoint.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. أنشئ كائنًا من فئة العرض التقديمي.
2. استدعِ دالة `add_from_pdf` ومرر ملف PDF.
3. استخدم دالة `save` لحفظ الملف بصيغة PowerPoint.

هذا الشيفرة بايثون توضح عملية تحويل PDF إلى PowerPoint:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    pres.slides.remove_at(0)
    pres.slides.add_from_pdf("welcome-to-powerpoint.pdf")
    pres.save("OutputPresentation.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert  title="نصيحة" color="primary" %}} 

قد ترغب في تجربة تطبيق **Aspose المجاني** [PDF إلى PowerPoint](https://products.aspose.app/slides/import/pdf-to-powerpoint) الإلكتروني لأنه تنفيذ حي للعملية الموضحة هنا. 

{{% /alert %}} 

## **استيراد PowerPoint من HTML**

في هذه الحالة، ستحول مستند HTML إلى عرض تقديمي PowerPoint.

1. أنشئ كائنًا من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. استدعِ دالة `add_from_html` ومرر ملف HTML.
3. استخدم دالة `save` لحفظ الملف كمستند PowerPoint.

هذا الشيفرة بايثون توضح عملية تحويل HTML إلى PowerPoint:

```python
import aspose.slides as slides

with slides.Presentation() as pres:
    with open("page.html", "rb") as htmlStream:
        pres.slides.add_from_html(htmlStream)

    pres.save("MyPresentation.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="ملاحظة" color="warning" %}} 

يمكنك أيضًا استخدام Aspose.Slides لتحويل HTML إلى صيغ ملفات شائعة أخرى:

* [HTML إلى صورة](https://products.aspose.com/slides/python-net/conversion/html-to-image/)
* [HTML إلى JPG](https://products.aspose.com/slides/python-net/conversion/html-to-jpg/)
* [HTML إلى XML](https://products.aspose.com/slides/python-net/conversion/html-to-xml/)
* [HTML إلى TIFF](https://products.aspose.com/slides/python-net/conversion/html-to-tiff/)

{{% /alert %}}