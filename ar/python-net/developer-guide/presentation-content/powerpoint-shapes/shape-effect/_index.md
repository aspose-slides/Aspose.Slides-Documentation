---
title: تطبيق تأثيرات الشكل في العروض التقديمية باستخدام Python
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
description: "حوّل ملفات PPT و PPTX و ODP الخاصة بك باستخدام تأثيرات الشكل المتقدمة عبر Aspose.Slides for Python—أنشئ شرائح جذابة ومهنية في ثوانٍ."
---
## **المقدمة**

في حين يمكن استخدام التأثيرات في PowerPoint لجعل الشكل يبرز، فهي تختلف عن [الملء](/slides/ar/python-net/shape-formatting/#gradient-fill) أو الحدود. باستخدام تأثيرات PowerPoint، يمكنك إنشاء انعكاسات مقنعة على الشكل، وإضفاء توهج على الشكل، إلخ.

![تأثير الشكل](shape-effect.png)

PowerPoint يوفر ستة تأثيرات يمكن تطبيقها على الأشكال. يمكنك تطبيق تأثير واحد أو أكثر على الشكل.

بعض تركيبات التأثيرات تبدو أفضل من غيرها. لهذا السبب، يحتوي PowerPoint على خيارات تحت **Preset**. خيارات Preset هي في الأساس تركيبة معروفة ذات مظهر جيد مكونة من اثنين أو أكثر من التأثيرات. بهذه الطريقة، عند اختيار إعداد مسبق، لن تحتاج إلى إضاعة الوقت في اختبار أو دمج تأثيرات مختلفة للعثور على تركيبة مناسبة.

توفر Aspose.Slides خصائص وأساليب ضمن الفئة [EffectFormat](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/) التي تسمح لك بتطبيق نفس التأثيرات على الأشكال في عروض PowerPoint التقديمية.

## **تطبيق تأثير الظل**

يدعم Aspose.Slides for Python عبر .NET الظلال الخارجية والداخلية للأشكال. يمكنك تخصيص لونها واتجاهها والمسافة ونصف قطر الضبابية لتتناسب مع تصميم عرضك التقديمي.

### **تطبيق ظل خارجي**

استخدم ظلًا خارجيًا لجعل بطاقة أو لوحة تبرز ضد خلفية الشريحة. يمتد الظل خارج حدود الشكل، مما يخلق الانطباع بأن الشكل مرتفع فوق الشريحة. اضبط لونه واتجاهه والمسافة ونصف قطر الضبابية لتتناسب مع الإضاءة وتنسيق القالب.

هذا الكود Python يوضح كيفية تطبيق [تأثير الظل الخارجي](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/outer_shadow_effect/) على مستطيل:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 100)
    shape.effect_format.enable_outer_shadow_effect()
    shape.effect_format.outer_shadow_effect.shadow_color.color = slides.Color.dark_gray
    shape.effect_format.outer_shadow_effect.distance = 10
    shape.effect_format.outer_shadow_effect.direction = 45

    presentation.save("shadow_effect.pptx", slides.export.SaveFormat.PPTX)
```

![تأثير الظل](shadow_effect.png)

### **تطبيق ظل داخلي**

عند إعادة إنتاج نمط بصري للقالب، استخدم ظلًا داخليًا لإعطاء بطاقة أو لوحة مظهرًا متجعدًا. يمتد الظل الخارجي خارج الشكل ويجعله يبدو مرتفعًا، بينما يظلل الظل الداخلي داخل حواف الشكل.

استدعِ [enable_inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/enable_inner_shadow_effect/) ثم قم بتهيئة [inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/inner_shadow_effect/). القيم الأكبر لنصف قطر الضبابية تنتج حوافًا أكثر نعومة.

هذا المثال Python ينشئ بطاقة زرقاء فاتحة مع ظل داخلي رمادي داكن ويحفظها كملف PPTX:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 200, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = slides.Color.light_blue
    shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL

    shape.effect_format.enable_inner_shadow_effect()
    shadow = shape.effect_format.inner_shadow_effect
    shadow.shadow_color.color = slides.Color.dim_gray
    shadow.direction = 225
    shadow.distance = 7
    shadow.blur_radius = 6

    presentation.save("inner_shadow_effect.pptx", slides.export.SaveFormat.PPTX)
```

![مستطيل أزرق فاتح مع ظل داخلي](inner_shadow_effect.png)

لإزالة الظل الداخلي، استدعِ [disable_inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/disable_inner_shadow_effect/) على تنسيق تأثير الشكل.

### **تطبيق، تغيير، وإزالة ظل مسبق**

استدعِ [enable_preset_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/enable_preset_shadow_effect/) وحدد خاصية [preset](https://reference.aspose.com/slides/python-net/aspose.slides.effects/presetshadow/preset/) للظل إلى قيمة من نوع [PresetShadowType](https://reference.aspose.com/slides/python-net/aspose.slides/presetshadowtype/). لتبديل الأنماط، غير الإعداد المسبق على نفس الشكل. استدعِ [disable_preset_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/disable_preset_shadow_effect/) لإزالة الظل مع الحفاظ على الملء والحدود.

هذا المثال يُظهر أربع مراحل جنبًا إلى جنب على شريحة واحدة. ينسخ المستطيل قبل كل تغيير لتتمكن من مقارنة النتائج. كلا الظليلين مُزاحان بمقدار 10 نقاط. اتجاه 225° يضع الظل الأول فوق ويسار المستطيل، و45° يضع الظل الثاني أسفل ويسر.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(800, 120, slides.SlideSizeScaleType.DO_NOT_SCALE)
    shapes = presentation.slides[0].shapes

    shape = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 15, 30, 170, 60)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = slides.Color.steel_blue
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = slides.Color.dark_blue
    shape.text_frame.text = "No shadow"
    shape.text_frame.paragraphs[0].paragraph_format.default_portion_format.font_height = 14
    shapes.add_clone(shape)

    shape.x += 200
    shape.effect_format.enable_preset_shadow_effect()
    shadow = shape.effect_format.preset_shadow_effect
    shadow.preset = slides.PresetShadowType.TOP_LEFT_DROP_SHADOW
    shadow.distance = 10
    shadow.direction = 225
    shape.text_frame.text = "TopLeftDropShadow"
    shapes.add_clone(shape)

    shape.x += 200
    shadow.preset = slides.PresetShadowType.BOTTOM_RIGHT_DROP_SHADOW
    shadow.direction = 45
    shape.text_frame.text = "BottomRightDropShadow"
    shapes.add_clone(shape)

    shape.x += 200
    shape.effect_format.disable_preset_shadow_effect()
    shape.text_frame.text = "No shadow"

    presentation.save("preset_shadows.pptx", slides.export.SaveFormat.PPTX)
```

| الأصل | الإعداد المسبق الأول | الإعداد المسبق الثاني | بعد الإزالة |
| :---: | :---: | :---: | :---: |
| ![بدون ظل](preset_shadow_original.png) | ![ظل إسقاط أعلى-يسار](preset_shadow_top_left.png) | ![ظل إسقاط أسفل-يمين](preset_shadow_bottom_right.png) | ![بدون ظل بعد الإزالة](preset_shadow_removed.png) |

## **تطبيق تأثير الانعكاس**

لتطبيق تأثير الانعكاس في Aspose.Slides for Python عبر .NET، يمكنك إضافة انعكاس يشبه المرآة إلى الأشكال، مع ضبط معلمات مثل المسافة والشفافية والحجم. هذا التأثير يعزز جمالية عروضك التقديمية من خلال إعطاء الأشكال مظهرًا أكثر صقلًا وتطورًا. من السهل تنفيذه باستخدام كود بسيط، مما يتيح تطبيقًا سريعًا عبر عدة عناصر لتصميم متسق.

هذا الكود Python يوضح كيفية تطبيق [تأثير الانعكاس](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/reflection_effect/) على شكل:

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

لتطبيق تأثير التوهج على شكل في Aspose.Slides for Python عبر .NET، يمكنك إضافة هالة ناعمة مضيئة حول الأشكال، مع ضبط خصائص مثل اللون والحجم. يساعد هذا التأثير في إبراز الأشكال ويضيف عنصرًا بصريًا جذابًا إلى عرضك التقديمي. من السهل تنفيذه بكود قليل، مما يحسن المظهر العام لشرائحك.

هذا الكود Python يوضح كيفية تطبيق [تأثير التوهج](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/glow_effect/) على شكل:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 100)
    shape.effect_format.enable_glow_effect()
    shape.effect_format.glow_effect.color.color = slides.Color.magenta
    shape.effect_format.glow_effect.radius = 15

    presentation.save("glow_effect.pptx", slides.export.SaveFormat.PPTX)
```

![تأثير التوهج](glow_effect.png)

## **تطبيق تأثير الحواف الناعمة**

لتطبيق تأثير الحواف الناعمة في Aspose.Slides for Python عبر .NET، يمكنك إنشاء انتقال سلس ومُطمس حول حواف الشكل. يضيف هذا التأثير مظهرًا أكثر رقة وتفصيلًا، مثالي للتصاميم التي تحتاج إلى مظهر لطيف وأقل حدة. يمكنك بسهولة ضبط معلمات مثل نصف القطر لتحقيق التأثير المطلوب عبر مختلف الأشكال في عرضك.

هذا الكود Python يوضح كيفية تطبيق [الحواف الناعمة](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/soft_edge_effect/) على شكل:

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

## **تطبيق تأثير الضبابية**

استخدم ضبابية الشكل لتنعيم ملء الشكل وحدوده مع الحفاظ على قابلية تحرير الشكل. استدعِ [set_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/set_blur_effect/) على تنسيق تأثير الشكل. يُقاس نصف القطر بوحدات النقاط (1/72 بوصة): استخدم قيمة غير سالبة، حيث تُنتج القيم الأكبر ضبابية أقوى. نصف القطر صفر يترك المظهر دون تغيير.

إعداد [grow](https://reference.aspose.com/slides/python-net/aspose.slides.effects/blur/grow/) يتحكم في حدود التأثير المرئية. عند `False`، تُقصر الضبابية على الحدود المرسومة الأصلية، بما في ذلك الحدود. عند `True`، يمكن للضبابية أن تمتد خارج تلك الحدود. لا يغيّر أي من الإعدادين موضع الشكل أو أبعاده.

المقارنة أدناه تستخدم نفس الملء والحدود وأبعاد الشكل طوال الوقت. الصف العلوي يستخدم `grow = False`؛ والصف السفلي يستخدم `grow = True`.

![مستطيل أصلي مقارنةً بنصف قطر الضبابية 5 و 15 نقطة، مع تعطيل وتمكين خاصية النمو](shape_blur_comparison.png)

هذا المثال Python ينشئ مستطيلًا برتقاليًا بحدود زرقاء داكنة، يطبق ضبابية 5 نقاط، ثم يحدّثها إلى 15 نقطة باستدعاء [set_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/set_blur_effect/) مرة أخرى. يحفظ الحالتين الضبابيتين، ثم يستدعي [disable_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/disable_blur_effect/) ويحفظ الشكل بدون ضبابية.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 80, 160, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = slides.Color.orange
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = slides.Color.dark_blue
    shape.line_format.width = 8

    shape.effect_format.set_blur_effect(5, False)
    presentation.save("shape_blur_5.pptx", slides.export.SaveFormat.PPTX)

    shape.effect_format.set_blur_effect(15, True)
    presentation.save("shape_blur_15.pptx", slides.export.SaveFormat.PPTX)

    shape.effect_format.disable_blur_effect()
    presentation.save("shape_blur_removed.pptx", slides.export.SaveFormat.PPTX)
```

تؤثر ضبابية الشكل على الملء والحدود معًا. يخفّف تأثير الحواف الناعمة حواف الشكل، بينما يخفّف ضبابية الظل الظل فقط. تعمل تأثيرات تحويل الصورة على محتوى الصورة؛ هذا المثال يطبق الضبابية مباشرة على تنسيق تأثير الشكل دون تحويله إلى صورة.

## **الأسئلة المتداولة**

**هل يمكنني تطبيق تأثيرات متعددة على الشكل نفسه؟**

نعم، يمكنك دمج تأثيرات مختلفة، مثل الظل، والانعكاس، والتوهج، على شكل واحد لإنشاء مظهر أكثر ديناميكية.

**ما هي الأشكال التي يمكنني تطبيق التأثيرات عليها؟**

يمكنك تطبيق التأثيرات على أشكال متعددة، بما في ذلك الأشكال التلقائية، والرسوم البيانية، والجداول، والصور، وكائنات SmartArt، وكائنات OLE، وغيرها.

**هل يمكنني تطبيق التأثيرات على الأشكال المجمعة؟**

نعم، يمكنك تطبيق التأثيرات على الأشكال المجمعة. سيُطبق التأثير على المجموعة بأكملها.