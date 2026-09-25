---
title: إنشاء وتطبيق تأثيرات WordArt في Python
linktitle: WordArt
type: docs
weight: 110
url: /ar/python-net/wordart/
keywords:
- WordArt
- إنشاء WordArt
- قالب WordArt
- تأثير WordArt
- تأثير الظل
- تأثير الانعكاس
- تأثير التوهج
- تحويل WordArt
- تأثير ثلاثي الأبعاد
- تأثير الظل الخارجي
- تأثير الظل الداخلي
- Python
- Aspose.Slides
description: "إنشاء وتخصيص تأثيرات WordArt في Aspose.Slides للغة Python عبر .NET. يساعد هذا الدليل خطوة بخطوة المطورين على تحسين العروض التقديمية بنص احترافي باستخدام Python."
---
## **نظرة عامة**

تتيح لك تأثيرات WordArt تنسيق النص باستخدام التعبئات، والحدود، والظلال، والانعكاسات، والتوهج، والتحولات، وتنسيق ثلاثي الأبعاد. توضح هذه المقالة كيفية إنشاء وتخصيص هذه التأثيرات في عروض PowerPoint باستخدام Aspose.Slides for Python via .NET، دون تثبيت Microsoft Office.

## **إنشاء قالب WordArt بسيط وتطبيقه على النص**

تقوم الأمثلة التالية بإنشاء نمط WordArt بسيط عن طريق ضبط النص، الخط، تعبئة النمط، والحد.

كل مثال ينشئ عرض تقديمي جديدًا ويضيف مستطيلًا إلى شريحةه الأولى؛ لا يلزم ملف إدخال. المثال الأول يحدد النص إلى "Aspose.Slides". موضع الشكل وأبعاده تُقاس بالنقاط:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 200)
    text_frame = auto_shape.text_frame

    portion = text_frame.paragraphs[0].portions[0]
    portion.text = "Aspose.Slides"
```

عيّن الخط إلى Arial Black بحجم 36 نقطة لجعل التنسيق أكثر وضوحًا:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 200)

    portion = auto_shape.text_frame.paragraphs[0].portions[0]
    portion.text = "Aspose.Slides"
    portion.portion_format.latin_font = slides.FontData("Arial Black")
    portion.portion_format.font_height = 36
```

استخدم نمط [SMALL_GRID](https://reference.aspose.com/slides/ar/python-net/aspose.slides/patternstyle/) بلون أمامي برتقالي داكن وخلفية بيضاء، ثم أضف حدًا نصيًا أسود بعرض نقطة واحدة:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 200)

    portion = auto_shape.text_frame.paragraphs[0].portions[0]
    portion.text = "Aspose.Slides"
    portion.portion_format.latin_font = slides.FontData("Arial Black")
    portion.portion_format.font_height = 36

    portion.portion_format.fill_format.fill_type = slides.FillType.PATTERN
    portion.portion_format.fill_format.pattern_format.fore_color.color = draw.Color.dark_orange
    portion.portion_format.fill_format.pattern_format.back_color.color = draw.Color.white
    portion.portion_format.fill_format.pattern_format.pattern_style = slides.PatternStyle.SMALL_GRID

    portion.portion_format.line_format.width = 1
    portion.portion_format.line_format.fill_format.fill_type = slides.FillType.SOLID
    portion.portion_format.line_format.fill_format.solid_fill_color.color = draw.Color.black
```

النص الناتج:

![قالب WordArt البسيط](WordArt_template.png)

## **تطبيق تأثيرات WordArt أخرى**

تُظهر الأمثلة التالية كيفية تطبيق الظلال، الانعكاسات، التوهج، التحولات، وتأثيرات ثلاثية الأبعاد على النص.

### **تطبيق تأثير الظل الخارجي**

يضيف الظل الخارجي عمقًا بوضع ظل خلف النص. يمكنك تخصيص لونه، اتجاهه، مسافته، نصف قطر التمويه، المقياس، والإنحراف.

تستدعي هذه المثال الدالة [enable_outer_shadow_effect](https://reference.aspose.com/slides/ar/python-net/aspose.slides/effectformat/enable_outer_shadow_effect/) وتحدد ظلًا أسود بنصف قطر تمويه 4 نقاط، اتجاه 230 درجة، ومسافة 30 نقطة. قيم المقياس 100 تحافظ على حجم الظل، بينما الانحراف الأفقي يميل الظل بمقدار 20 درجة. ضبط التحويل ألفا يحدد شفافيته إلى 32٪:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 200)

    portion = auto_shape.text_frame.paragraphs[0].portions[0]
    portion.text = "Aspose.Slides"
    portion.portion_format.latin_font = slides.FontData("Arial Black")
    portion.portion_format.font_height = 36

    portion.portion_format.effect_format.enable_outer_shadow_effect()
    portion.portion_format.effect_format.outer_shadow_effect.shadow_color.color = draw.Color.black
    portion.portion_format.effect_format.outer_shadow_effect.scale_horizontal = 100
    portion.portion_format.effect_format.outer_shadow_effect.scale_vertical = 100
    portion.portion_format.effect_format.outer_shadow_effect.blur_radius = 4
    portion.portion_format.effect_format.outer_shadow_effect.direction = 230
    portion.portion_format.effect_format.outer_shadow_effect.distance = 30
    portion.portion_format.effect_format.outer_shadow_effect.skew_horizontal = 20
    portion.portion_format.effect_format.outer_shadow_effect.skew_vertical = 0
    portion.portion_format.effect_format.outer_shadow_effect.shadow_color.color_transform.add(slides.ColorTransformOperation.SET_ALPHA, 0.32)
```

النص الناتج:

![تأثير الظل الخارجي](outer_shadow_effect.png)

{{% alert color="info" title="Note" %}}
- عندما يتم استخدام الظل الخارجي والظلال المسبقة معًا، يُطبق الظل الخارجي فقط.
- إذا تم استخدام الظل الخارجي والظل الداخلي في آنٍ واحد، يعتمد التأثير الناتج على إصدار PowerPoint. على سبيل المثال، في PowerPoint 2013، يتضاعف التأثير، بينما في PowerPoint 2007 يُطبق الظل الخارجي فقط.
{{% /alert %}}

### **تطبيق تأثير الانعكاس**

يُنشئ الانعكاس نسخةً معكوسةً من النص. قم بضبط موضعه، مقياسه، تمويهه، وشفافيته للتحكم في مظهره.

تستدعي هذه المثال الدالة [enable_reflection_effect](https://reference.aspose.com/slides/ar/python-net/aspose.slides/effectformat/enable_reflection_effect/) وتقلّب الانعكاس عموديًا بمقياس -100٪. يستخدم نصف قطر تمويه 0.5 نقطة ومسافة 4.72 نقطة. تنخفض الشفافية من 60٪ إلى 0.9٪ بين الموضعين 0٪ و60٪ على طول الانعكاس:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 200)

    portion = auto_shape.text_frame.paragraphs[0].portions[0]
    portion.text = "Aspose.Slides"
    portion.portion_format.latin_font = slides.FontData("Arial Black")
    portion.portion_format.font_height = 36

    portion.portion_format.effect_format.enable_reflection_effect()
    portion.portion_format.effect_format.reflection_effect.blur_radius = 0.5
    portion.portion_format.effect_format.reflection_effect.distance = 4.72
    portion.portion_format.effect_format.reflection_effect.start_pos_alpha = 0
    portion.portion_format.effect_format.reflection_effect.end_pos_alpha = 60
    portion.portion_format.effect_format.reflection_effect.direction = 90
    portion.portion_format.effect_format.reflection_effect.scale_horizontal = 100
    portion.portion_format.effect_format.reflection_effect.scale_vertical = -100
    portion.portion_format.effect_format.reflection_effect.start_reflection_opacity = 60
    portion.portion_format.effect_format.reflection_effect.end_reflection_opacity = 0.9
    portion.portion_format.effect_format.reflection_effect.rectangle_align = slides.RectangleAlignment.BOTTOM_LEFT
```

النص الناتج:

![تأثير الانعكاس](reflection_effect.png)

### **تطبيق تأثير التوهج**

يضيف التوهج حدًا ملونًا ناعمًا حول النص. قم بضبط لونه، شفافيته، ونصف قطره للتحكم في التأثير.

تستدعي هذه المثال الدالة [enable_glow_effect](https://reference.aspose.com/slides/ar/python-net/aspose.slides/effectformat/enable_glow_effect/) وتطبق توهجًا أحمر بنسبة شفافية 54٪ ونصف قطر 7 نقاط:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 200)

    portion = auto_shape.text_frame.paragraphs[0].portions[0]
    portion.text = "Aspose.Slides"
    portion.portion_format.latin_font = slides.FontData("Arial Black")
    portion.portion_format.font_height = 36

    portion.portion_format.effect_format.enable_glow_effect()
    portion.portion_format.effect_format.glow_effect.color.color = draw.Color.red
    portion.portion_format.effect_format.glow_effect.color.color_transform.add(slides.ColorTransformOperation.SET_ALPHA, 0.54)
    portion.portion_format.effect_format.glow_effect.radius = 7
```

النص الناتج:

![تأثير التوهج](glow_effect.png)

### **تطبيق تحولات WordArt**

تحولات WordArt تُقوّس أو تمدد أو تشوه كتلة من النص.

عيّن [transform](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframeformat/transform/) إلى [ARCH_UP_POUR](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textshapetype/) لإنحناء إطار النص بأكمله نحو الأعلى:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 200)

    text_frame = auto_shape.text_frame
    text_frame.text = "Aspose.Slides"
    text_frame.text_frame_format.transform = slides.TextShapeType.ARCH_UP_POUR
```

النص الناتج:

![تحول WordArt](transform_effect.png)

{{% alert color="info" title="Note" %}}
يوفر Aspose.Slides for Python via .NET مجموعة من [أنواع التحولات](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textshapetype/).
{{% /alert %}}

### **تطبيق تأثيرات ثلاثية الأبعاد على الأشكال والنص**

يمكنك تطبيق تأثيرات ثلاثية الأبعاد على شكل أو على نصه. تتحكم القواعد، والإخراج، والإضاءة، وإعدادات الكاميرا في المظهر الناتج.

يستخدم المثال التالي [ThreeDFormat](https://reference.aspose.com/slides/ar/python-net/aspose.slides/threedformat/) لإضافة قواعد دائرية، إخراج برتقالي، وتحديد بلون أحمر غامق للمستطيل. تُقاس أبعاد القاعدة، ارتفاع الإخراج، عرض الحدود، والعمق بالنقاط. مادة بلاستيك، إضاءة متوازنة تدور 40 درجة حول المحور Z، وكاميرا منظور تحدد مظهره:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 200)
    auto_shape.text_frame.text = "Aspose.Slides"

    auto_shape.three_d_format.bevel_bottom.bevel_type = slides.BevelPresetType.CIRCLE
    auto_shape.three_d_format.bevel_bottom.height = 10.5
    auto_shape.three_d_format.bevel_bottom.width = 10.5

    auto_shape.three_d_format.bevel_top.bevel_type = slides.BevelPresetType.CIRCLE
    auto_shape.three_d_format.bevel_top.height = 12.5
    auto_shape.three_d_format.bevel_top.width = 11

    auto_shape.three_d_format.extrusion_color.color = draw.Color.orange
    auto_shape.three_d_format.extrusion_height = 6

    auto_shape.three_d_format.contour_color.color = draw.Color.dark_red
    auto_shape.three_d_format.contour_width = 1.5

    auto_shape.three_d_format.depth = 3

    auto_shape.three_d_format.material = slides.MaterialPresetType.PLASTIC

    auto_shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    auto_shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED
    auto_shape.three_d_format.light_rig.set_rotation(0, 0, 40)

    auto_shape.three_d_format.camera.camera_type = slides.CameraPresetType.PERSPECTIVE_CONTRASTING_RIGHT_FACING
```

الشكل الناتج:

![تأثير الشكل ثلاثي الأبعاد](shape_3D_effect.png)

يقوم هذا المثال بتطبيق تنسيق ثلاثي الأبعاد مشابه على النص عبر [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframeformat/three_d_format/). القواعد الصغيرة تشكل حواف الحروف، بينما الإخراج والإضاءة يضيفان عمقًا للنص:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 200)
    text_frame = auto_shape.text_frame
    text_frame.text = "Aspose.Slides"

    text_frame.text_frame_format.three_d_format.bevel_bottom.bevel_type = slides.BevelPresetType.CIRCLE
    text_frame.text_frame_format.three_d_format.bevel_bottom.height = 3.5
    text_frame.text_frame_format.three_d_format.bevel_bottom.width = 3.5

    text_frame.text_frame_format.three_d_format.bevel_top.bevel_type = slides.BevelPresetType.CIRCLE
    text_frame.text_frame_format.three_d_format.bevel_top.height = 4
    text_frame.text_frame_format.three_d_format.bevel_top.width = 4

    text_frame.text_frame_format.three_d_format.extrusion_color.color = draw.Color.orange
    text_frame.text_frame_format.three_d_format.extrusion_height = 6

    text_frame.text_frame_format.three_d_format.contour_color.color = draw.Color.dark_red
    text_frame.text_frame_format.three_d_format.contour_width = 1.5

    text_frame.text_frame_format.three_d_format.depth = 3

    text_frame.text_frame_format.three_d_format.material = slides.MaterialPresetType.PLASTIC

    text_frame.text_frame_format.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    text_frame.text_frame_format.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED
    text_frame.text_frame_format.three_d_format.light_rig.set_rotation(0, 0, 40)

    text_frame.text_frame_format.three_d_format.camera.camera_type = slides.CameraPresetType.PERSPECTIVE_CONTRASTING_RIGHT_FACING
```

النص الناتج:

![تأثير النص ثلاثي الأبعاد](text_3D_effect.png)

{{% alert color="info" title="Note" %}}
تطبيق تأثيرات ثلاثية الأبعاد على النص أو أشكاله — والتفاعل بين هذه التأثيرات — يخضع لقواعد محددة. ضع في اعتبارك مشهدًا يتضمن كلٍ من النص والشكل الذي يحتويه. يشمل تأثير ثلاثي الأبعاد تمثيلًا ثلاثيًا الأبعاد للكائن والمشهد الذي يُوضع فيه.

- إذا تم تعيين مشهد لكلٍ من الشكل والنص، يأخذ مشهد الشكل الأولوية ويتم تجاهل مشهد النص.
- إذا كان الشكل يفتقر إلى مشهد خاص به ولكنه يمتلك تمثيلًا ثلاثيًا الأبعاد، يُستخدم مشهد النص.
- إذا لم يكن لدى الشكل أي تأثير ثلاثي الأبعاد على الإطلاق، يُعامل كشكل مسطح، ويُطبق التأثير ثلاثي الأبعاد فقط على النص.

هذه السلوكيات ترتبط بخصائص [ThreeDFormat.light_rig](https://reference.aspose.com/slides/ar/python-net/aspose.slides/threedformat/light_rig/) و[ThreeDFormat.camera](https://reference.aspose.com/slides/ar/python-net/aspose.slides/threedformat/camera/).
{{% /alert %}}

للحفاظ على النص مسطحًا وقابلاً للقراءة مع الاحتفاظ بتنسيق الشكل ثلاثي الأبعاد، راجع [Keep Text Flat on a 3D Shape](/slides/ar/python-net/3d-presentation/) للمقارنة بين الإعدادين ومثال Python كامل.

## **الأسئلة الشائعة**

**هل يمكنني استخدام تأثيرات WordArt مع خطوط أو أنظمة كتابة مختلفة (مثل العربية، الصيني)؟**

نعم، يدعم Aspose.Slides for Python via .NET Unicode ويعمل مع جميع الخطوط والأنظمة المكتوبة الرئيسية. يمكن تطبيق تأثيرات WordArt مثل الظل، التعبئة، والحد بغض النظر عن اللغة، رغم أن توفر الخطوط وعرضها قد يعتمد على خطوط النظام.

**هل يمكنني تطبيق تأثيرات WordArt على عناصر القالب الرئيسي للشرائح؟**

نعم، يمكنك تطبيق تأثيرات WordArt على الأشكال في القوالب الرئيسية للشرائح، بما في ذلك عناصر نائب العنوان، التذييلات، أو النص الخلفي. ستنعكس التغييرات التي تُجرى على تخطيط القالب على جميع الشرائح المرتبطة.

**هل تؤثر تأثيرات WordArt على حجم ملف العرض التقديمي؟**

قليلًا. قد تزيد تأثيرات WordArt مثل الظلال، التوهج، وتعبئات التدرج اللوني حجم الملف قليلًا بسبب إضافة بيانات تنسيق، لكن الفرق عادةً ما يكون ضئيلًا.

**هل يمكنني معاينة نتيجة تأثيرات WordArt دون حفظ العرض التقديمي؟**

نعم، يمكنك تصيير الشرائح التي تحتوي على WordArt إلى صور (مثل PNG، JPEG) باستخدام [Slide.get_image](https://reference.aspose.com/slides/ar/python-net/aspose.slides/slide/get_image/)، أو تصيير الأشكال الفردية باستخدام [Shape.get_image](https://reference.aspose.com/slides/ar/python-net/aspose.slides/shape/get_image/). يتيح لك ذلك معاينة النتيجة في الذاكرة أو على الشاشة قبل حفظ أو تصدير العرض الكامل.