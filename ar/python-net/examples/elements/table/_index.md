---
title: جدول
type: docs
weight: 120
url: /ar/python-net/examples/elements/table/
keywords:
- جدول
- إضافة جدول
- الوصول إلى جدول
- حذف جدول
- دمج خلايا
- أمثلة على التعليمات البرمجية
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "إنشاء وتنسيق الجداول في Python باستخدام Aspose.Slides: إدراج البيانات، دمج الخلايا، تنسيق الحدود، محاذاة المحتوى، والاستيراد/التصدير لملفات PPT، PPTX و ODP."
---
أمثلة على إضافة الجداول، والوصول إليها، وإزالتها، ودمج الخلايا باستخدام **Aspose.Slides for Python via .NET**.

## **إضافة جدول**

إنشاء جدول بسيط يتكون من صفين وعمودين.

```py
def add_table():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # تحديد عرض الأعمدة وارتفاع الصفوف.
        widths = [80, 80]
        heights = [30, 30]

        # إضافة شكل جدول إلى الشريحة.
        table = slide.shapes.add_table(50, 50, widths, heights)

        presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **الوصول إلى جدول**

استرجاع الشكل الجدولي الأول في الشريحة.

```py
def access_table():
    with slides.Presentation("table.pptx") as presentation:
        slide = presentation.slides[0]

        # الوصول إلى الجدول الأول في الشريحة.
        first_table = next(shape for shape in slide.shapes if isinstance(shape, slides.Table))
```

## **حذف جدول**

حذف جدول من الشريحة.

```py
def remove_table():
    with slides.Presentation("table.pptx") as presentation:
        slide = presentation.slides[0]

        # افتراض أن الشكل الأول هو جدول.
        table = slide.shapes[0]

        # إزالة الجدول من الشريحة.
        slide.shapes.remove(table)

        presentation.save("table_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **دمج خلايا الجدول**

دمج الخلايا المتجاورة في جدول إلى خلية واحدة.

```py
def merge_table_cells():
    with slides.Presentation("table.pptx") as presentation:
        slide = presentation.slides[0]

        # افتراض أن الشكل الأول هو جدول.
        table = slide.shapes[0]

        # دمج الخلايا.
        table.merge_cells(table.rows[0][0], table.rows[1][1], False)

        presentation.save("cells_merged.pptx", slides.export.SaveFormat.PPTX)
```