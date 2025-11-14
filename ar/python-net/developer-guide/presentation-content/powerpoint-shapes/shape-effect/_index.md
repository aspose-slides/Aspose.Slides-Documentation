---
title: تأثير الشكل
type: docs
weight: 30
url: /ar/python-net/shape-effect
keywords: "تأثير الشكل، عرض PowerPoint، بايثون، Aspose.Slides لبايثون عبر .NET"
description: "تطبيق تأثير على شكل PowerPoint في بايثون"
---

بينما يمكن استخدام التأثيرات في PowerPoint لجعل الشكل بارزًا، إلا أنها تختلف عن [التعبئات](/slides/ar/python-net/shape-formatting/#gradient-fill) أو الحواف. باستخدام تأثيرات PowerPoint، يمكنك إنشاء انعكاسات مقنعة على شكل، ونشر توهج شكل، إلخ.

<img src="shape-effect.png" alt="تأثير الشكل" style="zoom:50%;" />

* يوفر PowerPoint ستة تأثيرات يمكن تطبيقها على الأشكال. يمكنك تطبيق تأثير واحد أو أكثر على شكل.

* تبدو بعض مجموعات التأثيرات أفضل من غيرها. لهذه السبب، تقدم PowerPoint خيارات تحت **preset**. خيارات preset هي في الأساس مجموعة معروفة ذات مظهر جيد من اثنين أو أكثر من التأثيرات. بهذه الطريقة، من خلال اختيار preset، لن تضطر إلى إضاعة الوقت في اختبار أو دمج تأثيرات مختلفة للعثور على مجموعة جميلة.

توفر Aspose.Slides خصائص وطرق تحت فئة [EffectFormat](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/) التي تسمح لك بتطبيق نفس التأثيرات على الأشكال في عروض PowerPoint.

## **تطبيق تأثير الظل**

يظهر لك هذا الكود البرمجي بلغة بايثون كيفية تطبيق تأثير الظل الخارجي (`outer_shadow_effect`) على مستطيل:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 150)

    shape.effect_format.enable_outer_shadow_effect()
    shape.effect_format.outer_shadow_effect.shadow_color.color = draw.Color.dark_gray
    shape.effect_format.outer_shadow_effect.distance = 10
    shape.effect_format.outer_shadow_effect.direction = 45

    pres.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **تطبيق تأثير الانعكاس**

يظهر لك هذا الكود البرمجي بلغة بايثون كيفية تطبيق تأثير الانعكاس على شكل:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 150)

    shape.effect_format.enable_reflection_effect()
    shape.effect_format.reflection_effect.rectangle_align = slides.RectangleAlignment.BOTTOM
    shape.effect_format.reflection_effect.direction = 90
    shape.effect_format.reflection_effect.distance = 55
    shape.effect_format.reflection_effect.blur_radius = 4

    pres.save("reflection.pptx", slides.export.SaveFormat.PPTX)
```

## **تطبيق تأثير التوهج**

يظهر لك هذا الكود البرمجي بلغة بايثون كيفية تطبيق تأثير التوهج على شكل:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 150)

    shape.effect_format.enable_glow_effect()
    shape.effect_format.glow_effect.color.color = draw.Color.magenta
    shape.effect_format.glow_effect.radius = 15

    pres.save("glow.pptx", slides.export.SaveFormat.PPTX)
```

## **تطبيق تأثير الحواف الناعمة**

يظهر لك هذا الكود البرمجي بلغة بايثون كيفية تطبيق الحواف الناعمة على شكل:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 150)

    shape.effect_format.enable_soft_edge_effect()
    shape.effect_format.soft_edge_effect.radius = 15

    pres.save("softEdges.pptx", slides.export.SaveFormat.PPTX)
```