---
title: انیمیشن
type: docs
weight: 100
url: /fa/python-net/examples/elements/animation/
keywords:
- انیمیشن
- افزودن انیمیشن
- دسترسی به انیمیشن
- حذف انیمیشن
- توالی انیمیشن
- مثال‌های کد
- PowerPoint
- OpenDocument
- ارائه
- Python
- Aspose.Slides
description: "انیمیشن‌های اسلاید را در پایتون با Aspose.Slides به‌صورت حرفه‌ای مدیریت کنید: افزودن، ویرایش و حذف افکت‌ها، زمان‌بندی‌ها و محرک‌ها برای ایجاد ارائه‌های پویا در فرمت‌های PPT، PPTX و ODP."
---
نشان می‌دهد چگونه انیمیشن‌های ساده ایجاد کرده و توالی آن‌ها را با استفاده از **Aspose.Slides for Python via .NET** مدیریت کنید.

## **افزودن یک انیمیشن**

یک شکل مستطیل ایجاد کنید و اثر محو شدن را که با کلیک فعال می‌شود اعمال کنید.

```py
def add_animation():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]
        shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 100, 100)

        # افکت محو شدن را اضافه کنید.
        slide.timeline.main_sequence.add_effect(
            shape,
            slides.animation.EffectType.FADE,
            slides.animation.EffectSubtype.NONE,
            slides.animation.EffectTriggerType.ON_CLICK)

        presentation.save("animation.pptx", slides.export.SaveFormat.PPTX)
```

## **دسترسی به یک انیمیشن**

افکت اولین انیمیشن را از جدول زمانی اسلاید دریافت کنید.

```py
def access_animation():
    with slides.Presentation("animation.pptx") as presentation:
        slide = presentation.slides[0]

        # دسترسی به اولین افکت انیمیشن.
        effect = slide.timeline.main_sequence[0]
```

## **حذف یک انیمیشن**

یک افکت انیمیشن را از توالی حذف کنید.

```py
def remove_animation():
    with slides.Presentation("animation.pptx") as presentation:
        slide = presentation.slides[0]

        # فرض بر این است که توالی اصلی حداقل یک افکت دارد.
        effect = slide.timeline.main_sequence[0]

        # حذف افکت.
        slide.timeline.main_sequence.remove(effect)

        presentation.save("animation_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **توالی‌گذاری انیمیشن‌ها**

چندین افکت اضافه کنید و ترتیب وقوع انیمیشن‌ها را نشان دهید.

```py
def sequence_animations():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]
        shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 100, 100)
        shape2 = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 200, 50, 100, 100)

        sequence = slide.timeline.main_sequence
        sequence.add_effect(
            shape1,
            slides.animation.EffectType.FLY,
            slides.animation.EffectSubtype.BOTTOM,
            slides.animation.EffectTriggerType.ON_CLICK)
        sequence.add_effect(
            shape2,
            slides.animation.EffectType.FLY,
            slides.animation.EffectSubtype.BOTTOM,
            slides.animation.EffectTriggerType.ON_CLICK)

        presentation.save("animation_sequence.pptx", slides.export.SaveFormat.PPTX)
```