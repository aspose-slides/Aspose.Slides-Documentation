---
title: الحبر
type: docs
weight: 180
url: /ar/python-net/examples/elements/ink/
keywords:
- الحبر
- الوصول إلى الحبر
- إزالة الحبر
- أمثلة على الشيفرة
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "معالجة الحبر الرقمي على الشرائح في Python باستخدام Aspose.Slides: إضافة ضربات القلم، تعديل المسارات، ضبط اللون والعرض، وتصدير النتائج لـ PowerPoint و OpenDocument."
---
يوفر أمثلة على الوصول إلى أشكال الحبر الموجودة وإزالتها باستخدام **Aspose.Slides for Python via .NET**.

> ❗ **ملاحظة:** تمثل أشكال الحبر مدخلات المستخدم من الأجهزة المتخصصة. لا يمكن لـ Aspose.Slides إنشاء ضربات حبر جديدة برمجياً، ولكن يمكنك قراءة وتعديل الحبر الموجود.

## **الوصول إلى الحبر**

احصل على أول شكل حبر من الشريحة.

```py
def access_ink():
    with slides.Presentation("ink.pptx") as presentation:
        slide = presentation.slides[0]

        first_ink = None
        for shape in slide.shapes:
            if isinstance(shape, slides.ink.Ink):
                first_ink = shape
                break
```

## **إزالة الحبر**

احذف شكل الحبر من الشريحة.

```py
def remove_ink():
    with slides.Presentation("ink.pptx") as presentation:
        slide = presentation.slides[0]

        # بافتراض أن الشكل الأول هو كائن حبر.
        ink = slide.shapes[0]

        slide.shapes.remove(ink)

        presentation.save("ink_removed.pptx", slides.export.SaveFormat.PPTX)
```