---
title: "تطبيق تأثيرات الشكل في العروض التقديمية باستخدام بايثون"
linktitle: "تأثير الشكل"
type: docs
weight: 30
url: /ar/python-net/shape-effect
keywords:
- "تأثير الشكل"
- "تأثير الظل"
- "تأثير الانعكاس"
- "تأثير التوهج"
- "تأثير الحواف الناعمة"
- "تنسيق التأثير"
- "PowerPoint"
- "OpenDocument"
- "عرض تقديمي"
- "Python"
- "Aspose.Slides"
description: "حوّل ملفات PPT و PPTX و ODP الخاصة بك باستخدام تأثيرات الشكل المتقدمة عبر Aspose.Slides for Python—أنشئ شرائح جذابة ومحترفة في ثوانٍ."
---
## **المقدمة**

يمكن استخدام التأثيرات في PowerPoint لجعل الشكل يبرز، لكنها تختلف عن [التعبئات](/slides/ar/python-net/shape-formatting/#gradient-fill) أو المخططات. باستخدام تأثيرات PowerPoint، يمكنك إنشاء انعكاسات مقنعة على الشكل، أو إضاءة توزع توهج الشكل، وغيرها.

![تأثير الشكل](shape-effect.png)

يقدم PowerPoint ستة تأثيرات يمكن تطبيقها على الأشكال. يمكنك تطبيق تأثير واحد أو أكثر على الشكل.

بعض تركيبات التأثيرات تبدو أفضل من غيرها. لهذا السبب، يقدم PowerPoint خيارات تحت **Preset**. خيارات Preset هي أساساً تركيبة معروفة ذات مظهر جيد من اثنين أو أكثر من التأثيرات. بهذه الطريقة، باختيار إعداد مسبق، لن تحتاج إلى إضاعة الوقت في اختبار أو دمج تأثيرات مختلفة للعثور على تركيبة مناسبة.

Aspose.Slides يوفر خصائص وطرق تحت فئة [EffectFormat](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/) التي تسمح لك بتطبيق نفس التأثيرات على الأشكال في عروض PowerPoint.

## **تطبيق تأثير الظل**

Aspose.Slides for Python via .NET يدعم الظلال الخارجية والداخلية للأشكال. يمكنك تخصيص لونها، واتجاهها، ومسافتها، ونصف قطر التشويش لتتناسب مع تصميم العرض الخاص بك.

### **تطبيق ظل خارجي**

استخدم ظلًا خارجيًا لجعل بطاقة أو لوحة تبرز مقابل خلفية الشريحة. يمتد الظل خارج حدود الشكل، مما يعطي الانطباع بأن الشكل مرفوع فوق الشريحة. قم بضبط لونه، واتجاهه، ومسافته، ونصف قطر التشويش ليتناسب مع إضاءة وتصميم القالب الخاص بك.

يظهر هذا الكود بلغة Python كيفية تطبيق [تأثير الظل الخارجي](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/outer_shadow_effect/) على مستطيل:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 100)
    shape.effect_format.enable_outer_shadow_effect()
    shape.effect_format.outer_shadow_effect.shadow_color.color = draw.Color.dark_gray
    shape.effect_format.outer_shadow_effect.distance = 10
    shape.effect_format.outer_shadow_effect.direction = 45

    presentation.save("shadow_effect.pptx", slides.export.SaveFormat.PPTX)
```

![تأثير الظل](shadow_effect.png)

### **تطبيق ظل داخلي**

عند إعادة إنتاج النمط المرئي للقالب، استخدم ظلًا داخليًا لإعطاء بطاقة أو لوحة مظهرًا مغمورًا. الظل الخارجي يمتد خارج الشكل ويجعله يبدو مرتفعًا، بينما الظل الداخلي يظلّل داخل حواف الشكل.

استدعِ [enable_inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/enable_inner_shadow_effect/)، ثم ضبط [inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/inner_shadow_effect/). قيم نصف القطر الأكبر تنتج حوافًا أكثر نعومة.

هذا المثال في Python ينشئ بطاقة زرقاء فاتحة مع ظل داخلي رمادي داكن ويحفظها كملف PPTX:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 200, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.light_blue
    shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL

    shape.effect_format.enable_inner_shadow_effect()
    shadow = shape.effect_format.inner_shadow_effect
    shadow.shadow_color.color = draw.Color.dim_gray
    shadow.direction = 225
    shadow.distance = 7
    shadow.blur_radius = 6

    presentation.save("inner_shadow_effect.pptx", slides.export.SaveFormat.PPTX)
```

![مستطيل أزرق فاتح مع ظل داخلي](inner_shadow_effect.png)

لإزالة الظل الداخلي، استدعِ [disable_inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/disable_inner_shadow_effect/) على تنسيق تأثير الشكل.

## **تطبيق تأثير الانعكاس**

لتطبيق تأثير الانعكاس في Aspose.Slides for Python via .NET، يمكنك إضافة انعكاس شبيه بالمرآة إلى الأشكال، وضبط معلمات مثل المسافة، والشفافية، والحجم. هذا التأثير يعزز جمال عروضك بمنح الأشكال مظهرًا أكثر صقلًا وتطورًا. من السهل تطبيقه باستخدام كود بسيط، مما يتيح تطبيقًا سريعًا عبر عدة عناصر لتصميم موحد.

يظهر هذا الكود بلغة Python كيفية تطبيق [تأثير الانعكاس](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/reflection_effect/) على شكل:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 100)
    shape.effect_format.enable_reflection_effect()
    shape.effect_format.reflection_effect.rectangle_align = slides.RectangleAlignment.BOTTOM
    shape.effect_format.reflection_effect.direction = 90
    shape.effect_format.reflection_effect.distance = 40
    shape.effect_format.reflection_effect.blur_radius = 2

    presentation.save("reflection_effect.pptx", slides.export.SaveFormat.PPTX)
```

![تأثير الانعكاس](reflection_effect.png)

## **تطبيق تأثير التوهج**

لتطبيق تأثير التوهج على شكل في Aspose.Slides for Python عبر .NET، يمكنك إضافة هالة ناعمة ومضيئة حول الأشكال، وضبط خصائص مثل اللون والحجم. يساعد هذا التأثير على إبراز الأشكال ويضيف عنصرًا بصريًا جذابًا إلى العرض. من السهل تنفيذه بكود بسيط، مما يعزز المظهر العام للشرائح.

يظهر هذا الكود بلغة Python كيفية تطبيق [تأثير التوهج](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/glow_effect/) على شكل:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 100)
    shape.effect_format.enable_glow_effect()
    shape.effect_format.glow_effect.color.color = draw.Color.magenta
    shape.effect_format.glow_effect.radius = 15

    presentation.save("glow_effect.pptx", slides.export.SaveFormat.PPTX)
```

![تأثير التوهج](glow_effect.png)

## **تطبيق تأثير الحواف الناعمة**

لتطبيق تأثير الحواف الناعمة في Aspose.Slides for Python عبر .NET، يمكنك إنشاء انتقال سلس ومُبهم حول حواف الشكل. يضيف هذا التأثير مظهرًا أكثر رقة ونعومة، وهو مثالي للتصاميم التي تحتاج إلى مظهر أخف وأقل حدة. يمكنك بسهولة تعديل معلمات مثل نصف القطر لتحقيق التأثير المطلوب عبر مختلف الأشكال في عرضك.

يظهر هذا الكود بلغة Python كيفية تطبيق [الحواف الناعمة](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/soft_edge_effect/) على شكل:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 150)
    shape.effect_format.enable_soft_edge_effect()
    shape.effect_format.soft_edge_effect.radius = 8

    presentation.save("soft_edges_effect.pptx", slides.export.SaveFormat.PPTX)
```

![تأثير الحواف الناعمة](soft_edges_effect.png)

## **الأسئلة المتكررة**

**هل يمكنني تطبيق تأثيرات متعددة على نفس الشكل؟**

نعم، يمكنك دمج تأثيرات مختلفة، مثل الظل، والانعكاس، والتوهج، على شكل واحد لإنشاء مظهر أكثر ديناميكية.

**ما هي الأشكال التي يمكنني تطبيق التأثيرات عليها؟**

يمكنك تطبيق التأثيرات على أشكال متعددة، بما في ذلك الأشكال التلقائية، والرسوم البيانية، والجداول، والصور، وكائنات SmartArt، وكائنات OLE، وغيرها.

**هل يمكنني تطبيق التأثيرات على الأشكال المجمعة؟**

نعم، يمكنك تطبيق التأثيرات على الأشكال المجمعة. سيطبق التأثير على المجموعة بأكملها.