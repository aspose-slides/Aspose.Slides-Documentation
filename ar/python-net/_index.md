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
- مكتبة PPT للـ Python
- تحويل PowerPoint إلى PDF باستخدام Python
- تحويل PowerPoint إلى SVG باستخدام Python
- تحرير PowerPoint في Python
- PowerPoint للـ Python بدون Microsoft Office
- إدارة ملفات PPTX باستخدام Python
- معاينة الشرائح باستخدام Python
- إضافة صوت إلى الشرائح في Python
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "يوفر Aspose.Slides لـ Python عبر .NET مجموعة شاملة من الميزات، تشمل إدارة النصوص، الأشكال، الجداول، والرسوم المتحركة، إضافة الصوت والفيديو إلى الشرائح، معاينة الشرائح، وتصديرها إلى SVG و PDF وغيرها."
---
{{% alert color="info" %}}

**مرحبًا بكم في Aspose.Slides for Python عبر .NET**

![شعار منتج Aspose.Slides for Python عبر .NET](aspose_slides-for-python.png)

Aspose.Slides for Python عبر .NET هي مكتبة فصلية قوية تتيح لتطبيقاتك قراءة وكتابة عروض تقديمية PowerPoint® دون الحاجة إلى Microsoft PowerPoint®.

إنها المكوّن الأول والوحيد الذي يوفر إدارة مستندات PowerPoint® كاملة المميزات لمطوري Python.

Aspose.Slides for Python عبر .NET تشمل مجموعة واسعة من الميزات مثل التعامل مع النصوص، الأشكال، الجداول، والرسوم المتحركة؛ إضافة الصوت والفيديو؛ معاينة الشرائح؛ وتصدير الشرائح إلى تنسيقات مثل SVG و PDF وغير ذلك.

{{% /alert %}}

## تثبيت Aspose.Slides for Python عبر .NET

```bash
pip install aspose.slides
```

الحزمة تتضمن زمن تشغيل .NET المطلوب، لذا لا يوجد ما تحتاج إلى تثبيته بالإضافة إلى ذلك لا يلزم وجود Microsoft PowerPoint. Python 3.7 أو أحدث على Windows أو Linux أو macOS.

## إنشاء عرض PowerPoint في Python

هذا المثال ينشئ عرضًا تقديميًا، يضيف شكلًا يحتوي على نص إلى الشريحة الأولى، ويحفظ النتيجة كملفين PPTX و PDF.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 600, 100)
    shape.text_frame.text = "Created with Aspose.Slides for Python via .NET"

    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
    presentation.save("presentation.pdf", slides.export.SaveFormat.PDF)
```

تشغيله يكتب `presentation.pptx` (بحجم حوالي 34 كيلوبايت) و `presentation.pdf` (بحجم حوالي 36 كيلوبايت) في دليل العمل.

بدون ترخيص تعمل المكتبة في وضع التقييم، مما يضيف علامة مائية ويحد من عدد الشرائح. راجع [Licensing](/slides/ar/python-net/licensing/) لتطبيق ترخيص.

## موارد Aspose.Slides for Python عبر .NET

استكشف هذه الموارد المفيدة::

- [Aspose.Slides for Python عبر .NET Online Documentation](/slides/ar/python-net/)
- [Aspose.Slides for Python عبر .NET Features](/slides/ar/python-net/features-overview/)
- [Aspose.Slides for Python عبر .NET Release Notes](https://releases.aspose.com/slides/ar/python-net/release-notes/)
- [Aspose.Slides for Python عبر .NET Product Page](https://products.aspose.com/slides/ar/python-net/)
- [Download Aspose.Slides for Python عبر .NET](https://releases.aspose.com/slides/ar/python-net/)
- [Install Aspose.Slides for Python عبر .NET PyPi Package](https://pypi.org/project/aspose.slides/)
- [Aspose.Slides for Python عبر .NET API Reference Guide](https://reference.aspose.com/slides/ar/python-net/)
- [Aspose.Slides for Python عبر .NET Free Support Forum](https://forum.aspose.com/c/slides/ar/11)
- [Aspose.Slides for Python عبر .NET Paid Support Helpdesk](https://helpdesk.aspose.com/)

## الأسئلة المتكررة

### ما هو Aspose.Slides for Python عبر .NET؟

Aspose.Slides for Python عبر .NET هي مكتبة Python قوية تتيح لك إنشاء وتحرير وتحويل عروض PowerPoint (PPT و PPTX و ODP) برمجيًا دون الحاجة إلى Microsoft PowerPoint المثبت.

### ما هي ميزات العرض التي يدعمها Aspose.Slides؟

المكتبة تدعم إدارة النصوص، الأشكال، الجداول، المخططات، الرسوم المتحركة، الشرائح الرئيسة، الصوت، الفيديو، والمزيد. كما تتيح معاينة الشرائح، عرضها، وتصديرها إلى تنسيقات مثل PDF و SVG و HTML والصور.

### هل يمكنني تحويل العروض إلى تنسيقات أخرى باستخدام Aspose.Slides؟

نعم. Aspose.Slides يتيح تحويل ملفات PowerPoint إلى PDF و SVG و HTML و JPG و PNG و TIFF وغيرها مع دقة وأداء عالٍ.

### هل يلزم وجود Microsoft PowerPoint لاستخدام Aspose.Slides؟

لا. Aspose.Slides هو واجهة برمجة تطبيقات مستقلة ولا يتطلب Microsoft Office أو أي برنامج طرف ثالث.

### ما المنصات التي يدعمها Aspose.Slides for Python عبر .NET؟

إنه متعدد المنصات ويعمل على بيئات Windows و Linux و macOS.

### كيف أبدأ باستخدام Aspose.Slides for Python؟

يمكنك تثبيته عبر PyPi واستكشاف [Developer Guide](/slides/ar/python-net/developer-guide/) للبدء بالأمثلة، مراجع API، والدروس.