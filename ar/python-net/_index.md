---
title: Aspose.Slides لـ Python عبر .NET
second_title: Aspose.Slides لـ Python
type: docs
weight: 35
url: /ar/python-net/
is_root: true
keywords:
- Aspose.Slides لـ Python
- أتمتة PowerPoint باستخدام Python
- مكتبة PPT لـ Python
- تصدير PowerPoint إلى PDF باستخدام Python
- تصدير PowerPoint إلى SVG باستخدام Python
- تعديل PowerPoint في Python
- PowerPoint لـ Python دون Microsoft Office
- إدارة ملفات PPTX باستخدام Python
- معاينة الشرائح باستخدام Python
- إضافة صوت إلى الشرائح باستخدام Python
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "يوفر Aspose.Slides لـ Python عبر .NET مجموعة شاملة من الميزات، بما في ذلك إدارة النصوص والأشكال والجداول والرسوم المتحركة، إضافة الصوت والفيديو إلى الشرائح، معاينة الشرائح، وتصديرها إلى SVG وPDF وأكثر."
---
{{% alert color="primary" %}}

**مرحبًا بكم في Aspose.Slides for Python عبر .NET**

![شعار منتج Aspose.Slides for Python عبر .NET](aspose_slides-for-python.png)

Aspose.Slides for Python عبر .NET هي مكتبة فئات قوية تتيح لتطبيقاتك قراءة وكتابة عروض PowerPoint® دون الحاجة إلى Microsoft PowerPoint®.

إنها المكوّن الأول والوحيد الذي يوفر إدارة مستندات PowerPoint® كاملة المميزات لمطوري Python.

يتضمن Aspose.Slides for Python عبر .NET مجموعة واسعة من الميزات مثل العمل مع النصوص، الأشكال، الجداول، والرسوم المتحركة؛ إضافة الصوت والفيديو؛ معاينة الشرائح؛ وتصدير الشرائح إلى تنسيقات مثل SVG، PDF، وأكثر.

{{% /alert %}}

## تثبيت Aspose.Slides for Python عبر .NET

```bash
pip install aspose.slides
```

الحزمة تشمل بيئة تشغيل .NET التي تحتاجها، لذا لا توجد حاجة لتثبيت أي شيء آخر ولا يتطلب Microsoft PowerPoint. Python 3.7 أو أحدث على Windows أو Linux أو macOS.

## إنشاء عرض PowerPoint في Python

هذا المثال ينشئ عرضًا تقديميًا، يضيف شكلًا يحتوي على نص إلى الشريحة الأولى، ويحفظ النتيجة كملفي PPTX وPDF.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 600, 100)
    shape.text_frame.text = "Created with Aspose.Slides for Python via .NET"

    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
    presentation.save("presentation.pdf", slides.export.SaveFormat.PDF)
```

تشغيله يكتب `presentation.pptx` (حوالي 34 كيلوبايت) و`presentation.pdf` (حوالي 36 كيلوبايت) في دليل العمل.

بدون ترخيص تعمل المكتبة في وضع التقييم، مما يضيف علامة مائية ويحدّ عدد الشرائح. راجع [الترخيص](/slides/ar/python-net/licensing/) لتطبيق واحد.

## موارد Aspose.Slides for Python عبر .NET

استكشاف هذه الموارد المفيدة::

- [توثيق Aspose.Slides for Python عبر .NET على الإنترنت](/slides/ar/python-net/)
- [ميزات Aspose.Slides for Python عبر .NET](/slides/ar/python-net/features-overview/)
- [ملاحظات إصدار Aspose.Slides for Python عبر .NET](https://releases.aspose.com/slides/ar/python-net/release-notes/)
- [صفحة المنتج Aspose.Slides for Python عبر .NET](https://products.aspose.com/slides/ar/python-net/)
- [تحميل Aspose.Slides for Python عبر .NET](https://releases.aspose.com/slides/ar/python-net/)
- [تثبيت حزمة PyPi لـ Aspose.Slides for Python عبر .NET](https://pypi.org/project/aspose.slides/)
- [دليل مرجع API لـ Aspose.Slides for Python عبر .NET](https://reference.aspose.com/slides/ar/python-net/)
- [منتدى الدعم المجاني لـ Aspose.Slides for Python عبر .NET](https://forum.aspose.com/c/slides/ar/11)
- [مكتب المساعدة للدعم المدفوع لـ Aspose.Slides for Python عبر .NET](https://helpdesk.aspose.com/)

## الأسئلة المتكررة

### ما هو Aspose.Slides for Python عبر .NET؟

Aspose.Slides for Python عبر .NET هي مكتبة Python قوية تتيح لك إنشاء، تعديل، وتحويل عروض PowerPoint (PPT، PPTX، ODP) برمجيًا دون الحاجة إلى تثبيت Microsoft PowerPoint.

### ما هي ميزات العرض التي يدعمها Aspose.Slides؟

تدعم المكتبة إدارة النصوص، الأشكال، الجداول، المخططات، الرسوم المتحركة، الشرائح الرئيسة، الصوت، الفيديو، وأكثر. كما تتيح معاينة الشرائح، التصيير، الطباعة، والتصدير إلى تنسيقات مثل PDF، SVG، HTML، والصور.

### هل يمكنني تحويل العروض إلى تنسيقات أخرى باستخدام Aspose.Slides؟

نعم. يتيح Aspose.Slides تحويل ملفات PowerPoint إلى PDF، SVG، HTML، JPG، PNG، TIFF، وغيرها من التنسيقات بدقة عالية وأداء ممتاز.

### هل يلزم وجود Microsoft PowerPoint لاستخدام Aspose.Slides؟

لا. Aspose.Slides هي واجهة برمجة تطبيقات مستقلة ولا تتطلب Microsoft Office أو أي برنامج طرف ثالث.

### ما المنصات التي يدعمها Aspose.Slides for Python عبر .NET؟

إنها متعددة المنصات وتعمل على بيئات Windows وLinux وmacOS.

### كيف أبدأ العمل مع Aspose.Slides for Python؟

يمكنك تثبيتها عبر PyPi واستكشاف [دليل المطور](/slides/ar/python-net/developer-guide/) للبدء بالأمثلة، مراجع API، والدروس.