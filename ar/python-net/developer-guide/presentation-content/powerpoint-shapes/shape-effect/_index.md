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
description: "حوّل ملفات PPT و PPTX و ODP باستخدام تأثيرات الشكل المتقدمة عبر Aspose.Slides for Python — أنشئ شرائح رائعة ومحترفة في ثوانٍ."
---
## **مقدمة**

في حين يمكن استخدام التأثيرات في PowerPoint لجعل الشكل يبرز، فإنها تختلف عن [الملء](/slides/ar/python-net/shape-formatting/#gradient-fill) أو الخطوط الخارجية. باستخدام تأثيرات PowerPoint، يمكنك إنشاء انعكاسات مقنعة على الشكل، ونشر توهج الشكل، وما إلى ذلك.

![تأثير الشكل](shape-effect.png)

يوفر PowerPoint ستة تأثيرات يمكن تطبيقها على الأشكال. يمكنك تطبيق تأثير أو أكثر على الشكل.

بعض تركيبات التأثيرات تبدو أفضل من غيرها. لهذا السبب، يحتوي PowerPoint على خيارات تحت **Preset**. خيارات Prest هو في الأساس تركيبة معروفة ذات مظهر جيد مكوّنة من تأثيرين أو أكثر. بهذه الطريقة، عند اختيار إعداد مسبق، لن تحتاج إلى إضاعة الوقت في اختبار أو دمج تأثيرات مختلفة للعثور على تركيبة مناسبة.

توفر Aspose.Slides خصائص وأساليب تحت فئة [EffectFormat](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/) التي تتيح لك تطبيق نفس التأثيرات على الأشكال في عروض PowerPoint التقديمية.

## **تطبيق تأثير الظل**

تدعم Aspose.Slides for Python عبر .NET الظلال الخارجية والداخلية للأشكال. يمكنك تخصيص لونها، واتجاهها، والمسافة، ونصف قطر التشويش لتتوافق مع تصميم العرض التقديمي.

### **تطبيق ظل خارجي**

استخدم الظل الخارجي لجعل بطاقة أو لوحة تبرز ضد خلفية الشريحة. يمتد الظل خارج حواف الشكل، مما يخلق انطباعًا بأن الشكل مرتفع فوق الشريحة. اضبط لونه، واتجاهه، ومسافته، ونصف قطر التشويش لتتناسب مع إضاءة ونمط القالب الخاص بك.

يظهر هذا الكود Python كيفية تطبيق [تأثير الظل الخارجي](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/outer_shadow_effect/) على مستطيل:

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

#### **التحكم في اتجاه الظل عند تدوير الشكل**

بشكل افتراضي، تكون القيمة `[OuterShadow.rotate_shadow_with_shape](https://reference.aspose.com/slides/python-net/aspose.slides.effects/outershadow/rotate_shadow_with_shape/)` `True`، لذا يدور الظل مع الشكل. لجعل الأشكال ذات الدورانات المختلفة تبدو مضاءة من نفس الاتجاه، عيّن هذه الخاصية إلى `False` ومنح ظلالها نفس [direction](https://reference.aspose.com/slides/python-net/aspose.slides.effects/outershadow/direction/).

ينشئ المثال سهمين بظلال رمادية مائلة 42 نقطة إلى اليمين (`direction = 0`). ثم يكرر الشريحة ويُدوّر السهمين 90° في اتجاه عقارب الساعة.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    before = presentation.slides[0]

    left = before.shapes.add_auto_shape(slides.ShapeType.RIGHT_ARROW, 55, 130, 110, 60)
    left.fill_format.fill_type = slides.FillType.SOLID
    left.fill_format.solid_fill_color.color = slides.Color.steel_blue
    left.line_format.fill_format.fill_type = slides.FillType.NO_FILL

    left.effect_format.enable_outer_shadow_effect()
    shadow = left.effect_format.outer_shadow_effect
    shadow.shadow_color.color = slides.Color.gray
    shadow.direction = 0
    shadow.distance = 42
    shadow.blur_radius = 0
    shadow.rotate_shadow_with_shape = True

    right = before.shapes.add_clone(left)
    right.x = 395
    right.effect_format.outer_shadow_effect.rotate_shadow_with_shape = False

    after = presentation.slides.add_clone(before)
    for arrow in after.shapes:
        arrow.rotation = 90

    presentation.save("arrow_shadows.pptx", slides.export.SaveFormat.PPTX)
```

في الشريحة الثانية، يلقي السهم الأيسر ظله نحو الأسفل، بينما يظل السهم الأيمن يلقي ظله إلى اليمين. يبقى الاتجاه المُضبط 0° لكلا الظلين.

![عرض PowerPoint قبل وبعد تدوير 90°. يبدأ كلا الظلين على اليمين. بعد الدوران، يتحرك الظل أسفل السهم الأيسر ويبقى إلى يمين السهم الأيمن.](arrow-shadow-rotation.png)

### **تطبيق ظل داخلي**

عند إعادة إنتاج النمط البصري للقالب، استخدم ظلًا داخليًا لإضفاء مظهر مرتد على بطاقة أو لوحة. يمتد الظل الخارجي خارج الشكل ويجعله يبدو مرتفعًا، بينما يظلل الظل الداخلي داخل حواف الشكل.

استدعِ [enable_inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/enable_inner_shadow_effect/)، ثم قم بتكوين [inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/inner_shadow_effect/). القيم الأكبر لنصف قطر التشويش تنتج حوافًا أكثر نعومة.

يُنشئ هذا المثال Python بطاقة زرقاء فاتحة بظل داخلي رمادي داكن ويحفظها كملف PPTX:

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

![مستطيل أزرق فاتح بظل داخلي](inner_shadow_effect.png)

لإزالة الظل الداخلي، استدعِ [disable_inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/disable_inner_shadow_effect/) على تنسيق تأثير الشكل.

### **تطبيق، تعديل، وإزالة ظل مُسبق الإعداد**

استدعِ [enable_preset_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/enable_preset_shadow_effect/)، وضع خاصية الظل [preset](https://reference.aspose.com/slides/python-net/aspose.slides.effects/presetshadow/preset/) إلى قيمة [PresetShadowType](https://reference.aspose.com/slides/python-net/aspose.slides/presetshadowtype/). لتغيير الأنماط، عدّل الإعداد المسبق على الشكل نفسه. استدعِ [disable_preset_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/disable_preset_shadow_effect/) لإزالة الظل مع الحفاظ على التعبئة والخط الخارجي.

يعرض هذا المثال أربع مراحل جنبًا إلى جنب على شريحة واحدة. يقوم باستنساخ المستطيل قبل كل تعديل لتتمكن من مقارنة النتائج. كلا الظلين مُزاحان بمقدار 10 نقاط. اتجاه 225° يضع الظل الأول أعلى ويسار المستطيل، و45° يضع الثاني أسفل ويمنه.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(800, 120, slides.SlideSizeScaleType.DO_NOT_SCALE)
    shapes = presentation.slides[0].shapes

    shape = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 15, 30, 170, 60)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = slides.Color.steel_blue
    shape.line_format.fill_format.fill_type = slides.FillFormat.SOLID
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

| الأصلي | الإعداد المسبق الأول | الإعداد المسبق الثاني | بعد الإزالة |
| :---: | :---: | :---: | :---: |
| ![بدون ظل](preset_shadow_original.png) | ![ظل إسقاط أعلى-يسار](preset_shadow_top_left.png) | ![ظل إسقاط أسفل-يمين](preset_shadow_bottom_right.png) | ![بدون ظل بعد الإزالة](preset_shadow_removed.png) |

## **تطبيق تأثير الانعكاس**

لتطبيق تأثير الانعكاس في Aspose.Slides for Python عبر .NET، يمكنك إضافة انعكاس يشبه المرآة إلى الأشكال، مع تعديل معلمات مثل المسافة، الشفافية، والحجم. يعزز هذا التأثير جمالية عروضك من خلال إعطاء الأشكال مظهرًا أكثر صقلاً ورقيًا. من السهل تنفيذه باستخدام كود بسيط، مما يسمح بتطبيق سريع عبر عناصر متعددة لتصميم متسق.

يظهر هذا الكود Python كيفية تطبيق [تأثير الانعكاس](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/reflection_effect/) على شكل:

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

لتطبيق تأثير التوهج على شكل في Aspose.Slides for Python عبر .NET، يمكنك إضافة هالة ناعمة ومضيئة حول الأشكال، مع تعديل خصائص مثل اللون والحجم. يساعد هذا التأثير على إبراز الأشكال وإضافة عنصر بصري جذاب إلى عرضك. من السهل تنفيذه بقليل من الكود، مما يحسن المظهر العام للشرائح.

يظهر هذا الكود Python كيفية تطبيق [تأثير التوهج](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/glow_effect/) على شكل:

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

لتطبيق تأثير الحواف الناعمة في Aspose.Slides for Python عبر .NET، يمكنك إنشاء انتقال سلس ومبهم حول حواف الشكل. يضيف هذا التأثير مظهرًا أكثر رقة وتفصيلًا، مثالي لتصاميم تحتاج إلى مظهر هادئ وناعم. يمكنك بسهولة تعديل معلمات مثل نصف القطر لتحقيق التأثير المطلوب عبر أشكال متعددة في عرضك.

يظهر هذا الكود Python كيفية تطبيق [الحواف الناعمة](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/soft_edge_effect/) على شكل:

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

## **تطبيق تأثير التشويش**

استخدم تشويش الشكل لتنعيم تعبئة الشكل وخطه الخارجي مع الحفاظ على إمكانية تحرير الشكل. استدعِ [set_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/set_blur_effect/) على تنسيق تأثير الشكل. يُقاس نصف القطر بالنقاط (1/72 بوصة): استخدم قيمة غير سالبة، فالقيم الأكبر تُنتج تشويشًا أقوى. نصف القطر صفر يترك المظهر دون تغيير.

تتحكم خاصية [grow](https://reference.aspose.com/slides/python-net/aspose.slides.effects/blur/grow/) في الحدود المرئية للتأثير. عندما تكون `False`، يُقتَص التشويش على الحدود المرسومة الأصلية، بما في ذلك الخط الخارجي. عندما تكون `True`، يمكن للتشويش أن يمتد خارج تلك الحدود. لا يغيّر أي من الإعدادين موضع الشكل أو أبعادها.

المقارنة أدناه تستخدم نفس التعبئة، الخط الخارجي، وأبعاد الشكل طوال الوقت. الصف العلوي يستخدم `grow = False`؛ الصف السفلي يستخدم `grow = True`.

![مستطيل أصلي مقارن مع أنصاف قطر التشويش 5 و15 نقطة، مع تعطيل وتمكين خاصية grow](shape_blur_comparison.png)

يُنشئ هذا المثال Python مستطيلًا برتقاليًا بخط خارجي أزرق داكن، يطبق تشويشًا بمقدار 5 نقاط، ثم يحدّثه إلى تشويش 15 نقطة باستدعاء [set_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/set_blur_effect/) مرة أخرى. يحفظ كلا الحالتين المشوشتين، ثم يستدعي [disable_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/disable_blur_effect/) ويحفظ الشكل بدون تشويش.

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

تشويش الشكل يؤثر على التعبئة والخط الخارجي معًا. تأثير الحواف الناعمة يخفف حواف الشكل، بينما تشويش الظل ينعّم الظل فقط. تعمل تأثيرات تحويل الصور على محتوى الصورة؛ يطبق هذا المثال التشويش مباشرة على تنسيق تأثير الشكل دون تحويل الشكل إلى صورة.

## **الأسئلة الشائعة**

**هل يمكنني تطبيق تأثيرات متعددة على نفس الشكل؟**

نعم، يمكنك دمج تأثيرات مختلفة، مثل الظل، والانعكاس، والتوهج، على شكل واحد لإنشاء مظهر أكثر ديناميكية.

**ما الأشكال التي يمكنني تطبيق التأثيرات عليها؟**

يمكنك تطبيق التأثيرات على مجموعة متنوعة من الأشكال، بما في ذلك الأشكال التلقائية، والمخططات، والجداول، والصور، وكائنات SmartArt، وكائنات OLE، وغيرها.

**هل يمكنني تطبيق التأثيرات على الأشكال المجمعة؟**

نعم، يمكنك تطبيق التأثيرات على الأشكال المجمعة. سيُطبق التأثير على المجموعة بأكملها.