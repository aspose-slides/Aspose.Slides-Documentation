---
title: استيراد العروض التقديمية باستخدام بايثون
linktitle: استيراد عرض تقديمي
type: docs
weight: 60
url: /ar/python-net/import-presentation/
keywords:
- استيراد PowerPoint
- استيراد عرض تقديمي
- استيراد شريحة
- PDF إلى عرض تقديمي
- PDF إلى PPT
- PDF إلى PPTX
- PDF إلى ODP
- HTML إلى عرض تقديمي
- HTML إلى PPT
- HTML إلى PPTX
- HTML إلى ODP
- Python
- Aspose.Slides
description: "قُم باستيراد مستندات PDF وHTML بسهولة إلى عروض PowerPoint وOpenDocument باستخدام Python وAspose.Slides لمعالجة الشرائح بسلاسة وعالية الأداء."
---

## **نظرة عامة**

مع [**Aspose.Slides for Python via .NET**](https://products.aspose.com/slides/python-net/)، يمكنك استيراد المحتوى إلى عرض تقديمي من صيغ ملفات أخرى. توفر فئة [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/) طرقًا لاستيراد الشرائح من PDF وHTML ومصادر أخرى.

## **تحويل PDF إلى عرض تقديمي**

يوضح هذا القسم كيفية تحويل PDF إلى عرض تقديمي باستخدام Aspose.Slides. يهدف إلى إرشادك عبر استيراد ملف PDF، تحويل صفحاته إلى شرائح، وحفظ النتيجة كملف PPTX.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. أنشئ مثيلاً لفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. استدعِ طريقة [add_from_pdf](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_from_pdf/) ومرّر ملف PDF.
3. استخدم طريقة [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) لحفظ العرض التقديمي بصيغة PowerPoint.

الكود التالي بايثون يوضح تحويل PDF إلى عرض تقديمي:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slides.remove_at(0)

    presentation.slides.add_from_pdf("sample.pdf")

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert  title="نصيحة" color="primary" %}}
قد ترغب في تجربة تطبيق الويب المجاني [PDF إلى PowerPoint](https://products.aspose.app/slides/import/pdf-to-powerpoint) من Aspose؛ فهو تنفيذ مباشر للعملية الموضحة هنا.
{{% /alert %}}

## **تحويل HTML إلى عرض تقديمي**

يظهر هذا القسم كيفية استيراد محتوى HTML إلى عرض تقديمي باستخدام Aspose.Slides. يغطي تحميل ملف HTML، تحويله إلى شرائح مع الحفاظ على النصوص والصور والتنسيق الأساسي، ثم حفظ النتيجة كملف PPTX.

1. أنشئ مثيلاً لفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. استدعِ طريقة [add_from_html](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_from_html/) ومرّر ملف HTML. 
3. استخدم طريقة [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) لحفظ العرض التقديمي بصيغة PowerPoint.

الكود التالي بايثون يوضح تحويل HTML إلى عرض تقديمي:

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

يمكن اكتشاف الجداول أثناء الاستيراد؛ يحتوي [PdfImportOptions](https://reference.aspose.com/slides/python-net/aspose.slides.importing/pdfimportoptions/) على معلمة [detect_tables](https://reference.aspose.com/slides/python-net/aspose.slides.importing/pdfimportoptions/detect_tables/) التي تتيح التعرف على الجداول. تعتمد الفعالية على بنية ملف PDF.

{{% alert title="ملاحظة" color="info" %}}
يمكنك أيضًا استخدام Aspose.Slides لتحويل HTML إلى صيغ ملفات شائعة أخرى:

* [HTML إلى صورة](https://products.aspose.com/slides/python-net/conversion/html-to-image/)
* [HTML إلى JPG](https://products.aspose.com/slides/python-net/conversion/html-to-jpg/)
* [HTML إلى XML](https://products.aspose.com/slides/python-net/conversion/html-to-xml/)
* [HTML إلى TIFF](https://products.aspose.com/slides/python-net/conversion/html-to-tiff/)
{{% /alert %}}