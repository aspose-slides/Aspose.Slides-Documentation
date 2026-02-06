---
title: الرسوم المتحركة
type: docs
weight: 100
url: /ar/python-net/examples/elements/animation/
keywords:
- الرسوم المتحركة
- إضافة رسوم متحركة
- الوصول إلى الرسوم المتحركة
- إزالة الرسوم المتحركة
- تسلسل الرسوم المتحركة
- أمثلة برمجية
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "تحكم في رسومات الشرائح المتحركة في Python باستخدام Aspose.Slides: أضف، حرر، وأزل التأثيرات، التوقيتات، والمُشغلات لإنشاء عروض تقديمية ديناميكية بصيغ PPT و PPTX و ODP."
---
يوضح كيفية إنشاء رسوم متحركه بسيطة وإدارة تسلسلها باستخدام **Aspose.Slides for Python via .NET**.

## **إضافة رسوم متحركة**

إنشاء شكل مستطيل وتطبيق تأثير تلاشي يتم تشغيله عند النقر.

```py
def add_animation():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]
        shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 100, 100)

        # إضافة تأثير تلاشي.
        slide.timeline.main_sequence.add_effect(
            shape,
            slides.animation.EffectType.FADE,
            slides.animation.EffectSubtype.NONE,
            slides.animation.EffectTriggerType.ON_CLICK)

        presentation.save("animation.pptx", slides.export.SaveFormat.PPTX)
```

## **الوصول إلى رسوم متحركة**

استخراج أول تأثير حركة من خط زمني الشريحة.

```py
def access_animation():
    with slides.Presentation("animation.pptx") as presentation:
        slide = presentation.slides[0]

        # الوصول إلى أول تأثير حركة.
        effect = slide.timeline.main_sequence[0]
```

## **إزالة رسوم متحركة**

إزالة تأثير حركة من التسلسل.

```py
def remove_animation():
    with slides.Presentation("animation.pptx") as presentation:
        slide = presentation.slides[0]

        # افتراض أن التسلسل الرئيسي يحتوي على تأثير واحد على الأقل.
        effect = slide.timeline.main_sequence[0]

        # إزالة التأثير.
        slide.timeline.main_sequence.remove(effect)

        presentation.save("animation_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **تسلسل الرسوم المتحركة**

إضافة تأثيرات متعددة وإظهار الترتيب الذي تحدث فيه الحركات.

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