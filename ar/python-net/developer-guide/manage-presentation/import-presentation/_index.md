---
title: استيراد العروض التقديمية باستخدام بايثون
linktitle: استيراد عرض تقديمي
type: docs
weight: 60
url: /ar/python-net/import-presentation/
keywords:
- استيراد PowerPoint
- استيراد العرض التقديمي
- استيراد الشريحة
- PDF إلى عرض تقديمي
- PDF إلى PPT
- PDF إلى PPTX
- PDF إلى ODP
- HTML إلى عرض تقديمي
- HTML إلى PPT
- HTML إلى PPTX
- HTML إلى ODP
- بايثون
- Aspose.Slides
description: "استيراد مستندات PDF وHTML بسهولة إلى عروض PowerPoint وعروض OpenDocument باستخدام بايثون مع Aspose.Slides لمعالجة شرائح سلسة وعالية الأداء."
---

## **نظرة عامة**

مع [Aspose.Slides لـ بايثون عبر .NET](https://products.aspose.com/slides/python-net/)، يمكنك استيراد المحتوى إلى عرض تقديمي من صيغ ملفات أخرى. توفر فئة [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/) طرقًا لاستيراد الشرائح من PDF وHTML ومصادر أخرى.

## **تحويل PDF إلى عرض تقديمي**

يوضح هذا القسم كيفية تحويل ملف PDF إلى عرض تقديمي باستخدام Aspose.Slides. يوجهك خلال استيراد ملف PDF، وتحويل صفحاته إلى شرائح، وحفظ النتيجة كملف PPTX.

<img src="pdf-to-powerpoint.png" alt="pdf إلى باوربوينت" style="zoom:50%;" />

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. استدعاء طريقة [add_from_pdf](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_from_pdf/) وتمرير ملف PDF.
3. استخدام طريقة [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) لحفظ العرض التقديمي بصيغة PowerPoint.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slides.remove_at(0)

    presentation.slides.add_from_pdf("sample.pdf")

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="نصيحة" color="primary" %}}
قد ترغب في تجربة تطبيق Aspose المجاني على الويب لتحويل [PDF إلى PowerPoint](https://products.aspose.app/slides/import/pdf-to-powerpoint) — وهو تنفيذ مباشر للعملية المذكورة هنا.
{{% /alert %}}

## **تحويل HTML إلى عرض تقديمي**

يوضح هذا القسم كيفية استيراد محتوى HTML إلى عرض تقديمي باستخدام Aspose.Slides. يغطي تحميل ملف HTML، وتحويله إلى شرائح مع الحفاظ على النصوص والصور والتنسيق الأساسي، وحفظ النتيجة كملف PPTX.

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. استدعاء طريقة [add_from_html](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_from_html/) وتمرير ملف HTML.
3. استخدام طريقة [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) لحفظ العرض التقديمي بصيغة PowerPoint.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slides.remove_at(0)

    with open("page.html", "rb") as html_stream:
        presentation.slides.add_from_html(html_stream)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **الأسئلة المتكررة**

**هل يتم الحفاظ على الجداول عند استيراد PDF، وهل يمكن تحسين اكتشافها؟**

يمكن اكتشاف الجداول أثناء الاستيراد؛ تحتوي فئة [PdfImportOptions](https://reference.aspose.com/slides/python-net/aspose.slides.importing/pdfimportoptions/) على معلمة [detect_tables](https://reference.aspose.com/slides/python-net/aspose.slides.importing/pdfimportoptions/detect_tables/) التي تمكّن من التعرف على الجداول. تعتمد الفعالية على بنية ملف PDF.

{{% alert title="ملاحظة" color="info" %}}
يمكنك أيضًا استخدام Aspose.Slides لتحويل HTML إلى صيغ ملفات شائعة أخرى:

* [HTML إلى صورة](https://products.aspose.com/slides/python-net/conversion/html-to-image/)
* [HTML إلى JPG](https://products.aspose.com/slides/python-net/conversion/html-to-jpg/)
* [HTML إلى XML](https://products.aspose.com/slides/python-net/conversion/html-to-xml/)
* [HTML إلى TIFF](https://products.aspose.com/slides/python-net/conversion/html-to-tiff/)
{{% /alert %}}