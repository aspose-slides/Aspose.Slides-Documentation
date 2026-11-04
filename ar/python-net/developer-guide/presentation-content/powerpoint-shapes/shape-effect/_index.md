---
title: "تطبيق تأثيرات الأشكال في العروض التقديمية باستخدام بايثون"
linktitle: "تأثير الشكل"
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
description: "حوّل ملفات PPT و PPTX و ODP الخاصة بك باستخدام تأثيرات الأشكال المتقدمة عبر Aspose.Slides for Python—أنشئ شرائح جذابة واحترافية في ثوانٍ."
---
## **المقدمة**

في حين يمكن استخدام التأثيرات في PowerPoint لجعل شكل يبرز، فإنها تختلف عن [التعبئات](/slides/ar/python-net/shape-formatting/#gradient-fill) أو الخطوط الخارجية. باستخدام تأثيرات PowerPoint، يمكنك إنشاء انعكاسات مقنعة على الشكل، ونشر توهج الشكل، وما إلى ذلك.

![تأثير الشكل](shape-effect.png)

يوفر PowerPoint ستة تأثيرات يمكن تطبيقها على الأشكال. يمكنك تطبيق تأثير واحد أو أكثر على شكل.

بعض تركيبات التأثيرات تبدو أفضل من غيرها. لهذا السبب، يحتوي PowerPoint على خيارات تحت **Preset**. خيارات Preset هي أساسًا تركيبة معروفة ذات مظهر جيد تتكون من اثنين أو أكثر من التأثيرات. بهذه الطريقة، باختيار Preset، لن تحتاج إلى إضاعة الوقت في اختبار أو دمج تأثيرات مختلفة للعثور على تركيبة جميلة.

توفر Aspose.Slides الخصائص والطرق ضمن الفئة [EffectFormat](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/) التي تتيح لك تطبيق نفس التأثيرات على الأشكال في عروض PowerPoint التقديمية.

## **تطبيق تأثير الظل**

يدعم Aspose.Slides for Python عبر .NET الظلال الخارجية والداخلية للأشكال. يمكنك تخصيص لونها واتجاهها والمسافة نصف قطر التشويش لتتناسب مع تصميم عرضك التقديمي.

### **تطبيق الظل الخارجي**

استخدم ظلًا خارجيًا لجعل بطاقة أو لوحة تبرز ضد خلفية الشريحة. يمتد الظل خارج حواف الشكل، مما يخلق انطباعًا بأن الشكل مرتفع فوق الشريحة. اضبط لونه واتجاهه ومسافته ونصف قطر التشويش ليتوافق مع الإضاءة وتنسيق القالب الخاص بك.

يعرض هذا الكود Python كيفية تطبيق [تأثير الظل الخارجي](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/outer_shadow_effect/) على مستطيل:

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

### **تطبيق الظل الداخلي**

عند تكرار النمط البصري للقالب، استخدم ظلًا داخليًا لإعطاء بطاقة أو لوحة مظهرًا مغمورًا. يمتد الظل الخارجي خارج الشكل ويجعلها تبدو مرتفعة، بينما يظلل الظل الداخلي داخل حواف الشكل.

استدعِ [enable_inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/enable_inner_shadow_effect/)، ثم قم بتكوين [inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/inner_shadow_effect/). القيم الأكبر لنصف قطر التشويش تنتج حوافًا أكثر نعومة.

إن مثال Python هذا ينشئ بطاقة زرقاء فاتحة مع ظل داخلي رمادي داكن ويحفظها كملف PPTX:

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

## **تطبيق تأثير الانعكاس**

لتطبيق تأثير الانعكاس في Aspose.Slides for Python عبر .NET، يمكنك إضافة انعكاس يشبه المرآة إلى الأشكال، مع ضبط معلمات مثل المسافة والشفافية والحجم. يحسن هذا التأثير الجمالية لعروضك التقديمية من خلال إعطاء الأشكال مظهرًا أكثر صقلًا وتطورًا. من السهل تطبيقه باستخدام كود بسيط، مما يتيح تطبيقًا سريعًا عبر عدة عناصر لتصميم متسق.

يعرض هذا الكود Python كيفية تطبيق [تأثير الانعكاس](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/reflection_effect/) على شكل:

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

لتطبيق تأثير التوهج على شكل في Aspose.Slides for Python عبر .NET، يمكنك إضافة هالة ناعمة ومضيئة حول الأشكال، مع ضبط خصائص مثل اللون والحجم. يساعد هذا التأثير على إبراز الأشكال ويضيف عنصرًا بصريًا جذابًا ولافتًا للانتباه إلى عرضك التقديمي. من السهل تنفيذه بكمية قليلة من الكود، مما يعزز المظهر العام لشرائحك.

يعرض هذا الكود Python كيفية تطبيق [تأثير التوهج](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/glow_effect/) على شكل:

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

لتطبيق تأثير الحواف الناعمة في Aspose.Slides for Python عبر .NET، يمكنك إنشاء انتقال ناعم ومشوش حول حواف الشكل. يضيف هذا التأثير مظهرًا أكثر دقة ورقيًا، مثاليًا للتصاميم التي تحتاج إلى مظهر هادئ وأكثر نعومة. يمكنك بسهولة ضبط معلمات مثل نصف القطر لتحقيق التأثير المرجو عبر مختلف الأشكال في عرضك التقديمي.

يعرض هذا الكود Python كيفية تطبيق [الحواف الناعمة](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/soft_edge_effect/) على شكل:

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

استخدم ضبابية الشكل لتنعيم ملء الشكل وخطه مع الحفاظ على إمكانية تحرير الشكل. استدعِ [set_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/set_blur_effect/) على تنسيق تأثير الشكل. يُقاس نصف القطر بالنقاط (1/72 بوصة): استخدم قيمة غير سالبة، حيث تنتج القيم الأكبر ضبابية أقوى. نصف القطر صفر يبقى المظهر دون تغيير.

إعداد [grow](https://reference.aspose.com/slides/python-net/aspose.slides.effects/blur/grow/) يتحكم في الحد المرئي للتأثير. عندما يكون `False`، يتم قص الضبابية إلى الحدود الأصلية المرسومة، بما في ذلك الخط الخارجي. عندما يكون `True`، يمكن أن تمتد الضبابية إلى ما خارج تلك الحدود. لا يغيّر أي من الإعدادين موضع الشكل أو أبعاده.

المقارنة أدناه تستخدم نفس الملء والخط والقياسات الشكلية طوال الوقت. الصف العلوي يستخدم `grow = False`؛ الصف السفلي يستخدم `grow = True`.

![مقارنة المستطيل الأصلي مع أنصاف قطر الضبابية 5 و15 نقطة، مع تعطيل وتمكين grow](shape_blur_comparison.png)

إن مثال Python هذا ينشئ مستطيلًا برتقاليًا مع خط خارجي أزرق داكن، يطبق ضبابية ب5 نقاط، ثم يحدّثها إلى ضبابية ب15 نقطة عبر استدعاء [set_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/set_blur_effect/) مرة أخرى. يحفظ كلا الحالةين الضبابيتين، ثم يستدعي [disable_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/disable_blur_effect/) ويحفظ الشكل بدون ضبابية.

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

تؤثر ضبابية الشكل على الملء والخط معًا. يخفّض تأثير الحواف الناعمة حواف الشكل، بينما يعمل ضباب الظل على تليين الظل فقط. تعمل تأثيرات تحويل الصورة على محتوى الصورة؛ يطبق هذا المثال الضبابية مباشرة على تنسيق تأثير الشكل دون تحويل الشكل إلى صورة.

## **الأسئلة المتكررة**

**هل يمكنني تطبيق تأثيرات متعددة على نفس الشكل؟**

نعم، يمكنك دمج تأثيرات مختلفة، مثل الظل والانعكاس والتوهج، على شكل واحد لإنشاء مظهر أكثر ديناميكية.

**ما الأشكال التي يمكنني تطبيق التأثيرات عليها؟**

يمكنك تطبيق التأثيرات على أشكال مختلفة، بما في ذلك الأشكال التلقائية، والرسوم البيانية، والجداول، والصور، وكائنات SmartArt، وكائنات OLE، وغير ذلك.

**هل يمكنني تطبيق التأثيرات على الأشكال المجمعة؟**

نعم، يمكنك تطبيق التأثيرات على الأشكال المجمعة. سيُطبق التأثير على المجموعة بأكملها.