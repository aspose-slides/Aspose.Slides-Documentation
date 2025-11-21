---
title: تطبيق تأثيرات الأشكال في العروض التقديمية باستخدام بايثون
linktitle: تأثير الشكل
type: docs
weight: 30
url: /ar/python-net/shape-effect
keywords:
- تأثير الشكل
- تأثير الظل
- تأثير الانعكاس
- تأثير التوهج
- تأثير الحواف الناعمة
- تنسيق التأثير
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "حوّل ملفات PPT و PPTX و ODP الخاصة بك باستخدام تأثيرات الأشكال المتقدمة عبر Aspose.Slides للبايثون—أنشئ شرائح جذابة ومحترفة في ثوانٍ."
---

بينما يمكن استخدام التأثيرات في PowerPoint لجعل الشكل يبرز، فإنها تختلف عن [fills](/slides/ar/python-net/shape-formatting/#gradient-fill) أو الخطوط الخارجية. باستخدام تأثيرات PowerPoint، يمكنك إنشاء انعكاسات مقنعة على الشكل، أو نشر توهج الشكل، إلخ.

<img src="shape-effect.png" alt="تأثير الشكل" style="zoom:50%;" />

* يوفر PowerPoint ستة تأثيرات يمكن تطبيقها على الأشكال. يمكنك تطبيق واحد أو أكثر من التأثيرات على الشكل. 

* بعض تركيبات التأثيرات تبدو أفضل من غيرها. لهذا السبب، تتوفر خيارات PowerPoint تحت **Preset**. خيارات Preset هي في الأساس تركيبة معروفة المظهر من اثنين أو أكثر من التأثيرات. بهذه الطريقة، باختيار إعداد مسبق، لن تضطر إلى إضاعة الوقت في اختبار أو دمج تأثيرات مختلفة للعثور على تركيبة جميلة.

توفر Aspose.Slides خصائص وأساليب تحت فئة [EffectFormat](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/) التي تتيح لك تطبيق نفس التأثيرات على الأشكال في عروض PowerPoint.

## **تطبيق تأثير الظل**

هذا الشيفرة Python توضح لك كيفية تطبيق تأثير الظل الخارجي (`outer_shadow_effect`) على مستطيل:
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

هذا الشيفرة Python توضح لك كيفية تطبيق تأثير الانعكاس على شكل:
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

هذا الشيفرة Python توضح لك كيفية تطبيق تأثير التوهج على شكل:
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

هذا الشيفرة Python توضح لك كيفية تطبيق الحواف الناعمة على شكل:
```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 150)

    shape.effect_format.enable_soft_edge_effect()
    shape.effect_format.soft_edge_effect.radius = 15

    pres.save("softEdges.pptx", slides.export.SaveFormat.PPTX)
```


## **الأسئلة المتكررة**

**هل يمكنني تطبيق عدة تأثيرات على نفس الشكل؟**

نعم، يمكنك دمج تأثيرات مختلفة، مثل الظل، والانعكاس، والتوهج، على شكل واحد لإنشاء مظهر أكثر ديناميكية.

**ما هي الأشكال التي يمكنني تطبيق التأثيرات عليها؟**

يمكنك تطبيق التأثيرات على أشكال متنوعة، بما في ذلك الأشكال التلقائية، المخططات، الجداول، الصور، كائنات SmartArt، كائنات OLE، وأكثر.

**هل يمكنني تطبيق التأثيرات على مجموعة من الأشكال؟**

نعم، يمكنك تطبيق التأثيرات على مجموعات الأشكال. سيُطبق التأثير على المجموعة بأكملها.