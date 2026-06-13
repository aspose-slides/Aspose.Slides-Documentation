---
title: گروه‌شکل
type: docs
weight: 170
url: /fa/python-net/examples/elements/group-shape/
keywords:
- گروه
- افزودن شکل گروهی
- دسترسی به شکل گروهی
- حذف شکل گروهی
- جدا کردن شکل‌ها
- نمونه کد
- PowerPoint
- OpenDocument
- ارائه
- Python
- Aspose.Slides
description: "کار با شکل‌های گروهی در Python با استفاده از Aspose.Slides: ایجاد و جداسازی، مرتب‌سازی شکل‌های فرزند، تنظیم تبدیلات و محدوده‌ها در PowerPoint و OpenDocument."
---
مثال‌هایی برای ایجاد گروه‌های شکل، دسترسی به آن‌ها، جداسازی و حذف با استفاده از **Aspose.Slides for Python via .NET**.

## **Add a Group Shape**
## **افزودن یک شکل گروهی**

یک گروه حاوی دو شکل پایه ایجاد کنید.

```py
def add_group_shape():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # افزودن یک شکل گروهی.
        group = slide.shapes.add_group_shape()
        group.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 0, 0, 50, 50)
        group.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 60, 0, 50, 50)

        presentation.save("group.pptx", slides.export.SaveFormat.PPTX)
```

## **Access a Group Shape**
## **دسترسی به یک شکل گروهی**

شکل گروهی اول را از یک اسلاید دریافت کنید.

```py
def access_group_shape():
    with slides.Presentation("group.pptx") as presentation:
        slide = presentation.slides[0]

        # دسترسی به اولین شکل گروهی در اسلاید.
        first_group = None
        for shape in slide.shapes:
            if isinstance(shape, slides.GroupShape):
                first_group = shape
                break
```

## **Remove a Group Shape**
## **حذف یک شکل گروهی**

یک شکل گروهی را از اسلاید حذف کنید.

```py
def remove_group_shape():
    with slides.Presentation("group.pptx") as presentation:
        slide = presentation.slides[0]

        # فرض بر این است که اولین شکل یک شکل گروهی است.
        group = slide.shapes[0]

        # حذف شکل گروهی.
        slide.shapes.remove(group)

        presentation.save("group_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Ungroup Shapes**
## **جداسازی شکل‌ها**

شکل‌ها را از یک محفظه گروهی خارج کنید.

```py
def ungroup_shapes():
    with slides.Presentation("group.pptx") as presentation:
        slide = presentation.slides[0]

        # فرض می‌شود که اولین شکل یک شکل گروهی است.
        group = slide.shapes[0]

        # اشکال را از گروه خارج می‌کنیم.
        for shape in group.shapes:
            slide.shapes.add_clone(shape)

        slide.shapes.remove(group)

        presentation.save("shapes_ungrouped.pptx", slides.export.SaveFormat.PPTX)
```