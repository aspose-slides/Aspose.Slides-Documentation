---
title: رأس وتذييل
type: docs
weight: 220
url: /ar/python-net/examples/elements/header-footer/
keywords:
- رأس وتذييل
- إضافة رأس وتذييل
- تحديث رأس وتذييل
- تعيين التاريخ والوقت
- أمثلة على الشيفرة
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "التحكم في الرأس والتذييل في Python باستخدام Aspose.Slides: إضافة أو تعديل التاريخ/الوقت، أرقام الشرائح، ونص التذييل، إظهار أو إخفاء عناصر النائب عبر PPT وPPTX وODP."
---
يعرض كيفية إضافة تذييلات وتحديث عناصر النائب للتاريخ والوقت باستخدام **Aspose.Slides for Python via .NET**.

## **إضافة تذييل**

إضافة نص إلى منطقة التذييل في الشريحة وجعله مرئيًا.

```py
def add_footer():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        slide.header_footer_manager.set_footer_text("My footer")
        slide.header_footer_manager.set_footer_visibility(True)

        presentation.save("footer.pptx", slides.export.SaveFormat.PPTX)
```

## **تحديث التاريخ والوقت**

تعديل عنصر النائب للتاريخ والوقت في الشريحة.

```py
def add_date_time():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        slide.header_footer_manager.set_date_time_text("01/01/2024")
        slide.header_footer_manager.set_date_time_visibility(True)

        presentation.save("date_time.pptx", slides.export.SaveFormat.PPTX)
```