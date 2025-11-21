---
title: إنشاء وتطبيق تأثيرات WordArt في بايثون
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
- تأثير العرض
- تأثير التوهج
- تحويل WordArt
- تأثير ثلاثي الأبعاد
- تأثير الظل الخارجي
- تأثير الظل الداخلي
- Python
- Aspose.Slides
description: "تعلم كيفية إنشاء وتخصيص تأثيرات WordArt في Aspose.Slides لبايثون عبر .NET. يقدّم هذا الدليل خطوة بخطوة مساعدة للمطوّرين لتحسين العروض التقديمية بنص أنيق واحترافي في بايثون."
---

## **حول WordArt؟**
WordArt أو Word Art هي ميزة تتيح لك تطبيق تأثيرات على النصوص لجعلها بارزة. مع WordArt، على سبيل المثال، يمكنك تحديد حدود النص أو ملئه بلون (أو تدرج)، إضافة تأثيرات ثلاثية الأبعاد إليه، إلخ. كما يمكنك إمالة أو انحناء أو تمديد شكل النص. 

{{% alert color="primary" %}} 
WordArt يتيح لك التعامل مع النص كما تتعامل مع كائن رسومي. يتكون WordArt من تأثيرات أو تعديلات خاصة تُجرى على النصوص لجعلها أكثر جذباً أو وضوحاً. 
{{% /alert %}} 

**WordArt في Microsoft PowerPoint**

لاستخدام WordArt في Microsoft PowerPoint، عليك اختيار أحد قوالب WordArt المعدة مسبقاً. قالب WordArt هو مجموعة من التأثيرات تُطبّق على النص أو شكله. 

**WordArt في Aspose.Slides**

في Aspose.Slides for Python via .NET 20.10، نفّذنا دعم WordArt وأجرينا تحسينات على الميزة في إصدارات Aspose.Slides for Python via .NET اللاحقة. 

مع Aspose.Slides for Python via .NET، يمكنك بسهولة إنشاء قالب WordArt خاص بك (تأثير واحد أو مجموعة تأثيرات) في Python وتطبيقه على النصوص. 

## إنشاء قالب WordArt بسيط وتطبيقه على نص

**استخدام Aspose.Slides** 

أولاً، ننشئ نصًا بسيطًا باستخدام هذا الكود في Python: 
```py
import aspose.slides as slides

with slides.Presentation() as pres:
    slide = pres.slides[0]
    autoShape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)
    textFrame = autoShape.text_frame

    portion = textFrame.paragraphs[0].portions[0]
    portion.text = "Aspose.Slides"

    pres.save("wordart-1.pptx", slides.export.SaveFormat.PPTX)
```

الآن، نضبط ارتفاع خط النص إلى قيمة أكبر لجعل التأثير أكثر وضوحًا من خلال هذا الكود: 
```py 
    fontData = slides.FontData("Arial Black")
    portion.portion_format.latin_font = fontData
    portion.portion_format.font_height = 36
```


**استخدام Microsoft PowerPoint**

انتقل إلى قائمة تأثيرات WordArt في Microsoft PowerPoint:

![todo:image_alt_text](image-20200930113926-1.png)

من القائمة على اليمين، يمكنك اختيار تأثير WordArt مُعرّف مسبقًا. من القائمة على اليسار، يمكنك تحديد إعدادات WordArt جديد. 

هذه بعض الوسائط أو الخيارات المتاحة:

![todo:image_alt_text](image-20200930114015-3.png)

**استخدام Aspose.Slides**

هنا، نطبق لون نمط SmallGrid على النص ونضيف حد نص أسود بعرض 1 باستخدام هذا الكود: 
```py 
    portion.portion_format.fill_format.fill_type = slides.FillType.PATTERN
    portion.portion_format.fill_format.pattern_format.fore_color.color = draw.Color.dark_orange
    portion.portion_format.fill_format.pattern_format.back_color.color = draw.Color.white
    portion.portion_format.fill_format.pattern_format.pattern_style = slides.PatternStyle.SMALL_GRID
                
    portion.portion_format.line_format.fill_format.fill_type = slides.FillType.SOLID
    portion.portion_format.line_format.fill_format.solid_fill_color.color = draw.Color.black
```


النص الناتج:

![todo:image_alt_text](image-20200930114108-4.png)

## تطبيق تأثيرات WordArt أخرى

**استخدام Microsoft PowerPoint**

من واجهة البرنامج، يمكنك تطبيق هذه التأثيرات على نص أو كتلة نص أو شكل أو عنصر مشابه:

![todo:image_alt_text](image-20200930114129-5.png)

على سبيل المثال، يمكن تطبيق تأثيرات الظل، الانعكاس، والتوهج على نص؛ وتأثيرات تنسيق ثلاثي الأبعاد وتدوير ثلاثي الأبعاد على كتلة نص؛ وخاصية الحواف الناعمة يمكن تطبيقها على كائن شكل (لا يزال لها تأثير عندما لا يتم تعيين خاصية تنسيق ثلاثي الأبعاد). 

### تطبيق تأثيرات الظل

هنا، نهدف إلى ضبط الخصائص المتعلقة بنص فقط. نطبق تأثير الظل على النص باستخدام هذا الكود في Python: 
```py 
    portion.portion_format.effect_format.enable_outer_shadow_effect()
    portion.portion_format.effect_format.outer_shadow_effect.shadow_color.color = draw.Color.black
    portion.portion_format.effect_format.outer_shadow_effect.scale_horizontal = 100
    portion.portion_format.effect_format.outer_shadow_effect.scale_vertical = 65
    portion.portion_format.effect_format.outer_shadow_effect.blur_radius = 4.73
    portion.portion_format.effect_format.outer_shadow_effect.direction = 230
    portion.portion_format.effect_format.outer_shadow_effect.distance = 2
    portion.portion_format.effect_format.outer_shadow_effect.skew_horizontal = 30
    portion.portion_format.effect_format.outer_shadow_effect.skew_vertical = 0
    portion.portion_format.effect_format.outer_shadow_effect.shadow_color.color_transform.add(slides.ColorTransformOperation.SET_ALPHA, 0.32)
```


يدعم Aspose.Slides API ثلاثة أنواع من الظلال: OuterShadow وInnerShadow وPresetShadow. 

مع PresetShadow، يمكنك تطبيق ظل على النص (باستخدام قيم مُعدة مسبقًا). 

**استخدام Microsoft PowerPoint**

في PowerPoint، يمكنك استخدام نوع واحد من الظلال. إليك مثالًا:

![todo:image_alt_text](image-20200930114225-6.png)

**استخدام Aspose.Slides**

يسمح Aspose.Slides فعليًا بتطبيق نوعين من الظلال في آن واحد: InnerShadow وPresetShadow.

**ملاحظات:**

- عندما يُستخدم OuterShadow وPresetShadow معًا، يُطبّق فقط تأثير OuterShadow. 
- إذا استُخدم OuterShadow وInnerShadow معًا، فإن النتيجة أو التأثير المطبق يعتمد على نسخة PowerPoint. على سبيل المثال، في PowerPoint 2013، يتضاعف التأثير. ولكن في PowerPoint 2007، يُطبّق تأثير OuterShadow. 

### تطبيق عرض على النصوص

نضيف عرضًا للنص من خلال عيّنة الكود هذه في Python: 
```py 
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


### تطبيق تأثير التوهج على النصوص

نطبق تأثير التوهج على النص لجعله يلمع أو يبرز باستخدام هذا الكود: 
```py 
    portion.portion_format.effect_format.enable_glow_effect()
    portion.portion_format.effect_format.glow_effect.color.r = 255
    portion.portion_format.effect_format.glow_effect.color.color_transform.add(slides.ColorTransformOperation.SET_ALPHA, 0.54)
    portion.portion_format.effect_format.glow_effect.radius = 7
```


نتيجة العملية:

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 
يمكنك تغيير معلمات الظل والعرض والتوهج. تُضبط خصائص التأثيرات على كل جزء من النص بشكل منفصل. 
{{% /alert %}} 

### استخدام التحويلات في WordArt

نستخدم خاصية Transform (الموجودة في كتلة النص بأكملها) من خلال هذا الكود: 
```py 
textFrame.text_frame_format.transform = slides.TextShapeType.ARCH_UP_POUR
```


النتيجة:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 
يوفر كل من Microsoft PowerPoint وAspose.Slides for Python via .NET عددًا معينًا من أنواع التحويل المُعرّفة مسبقًا. 
{{% /alert %}} 

**استخدام PowerPoint**

للوصول إلى أنواع التحويل المُعرّفة مسبقًا، انتقل عبر: **Format** -> **TextEffect** -> **Transform**

**استخدام Aspose.Slides**

لاختيار نوع التحويل، استخدم تعداد TextShapeType. 

### تطبيق تأثيرات ثلاثية الأبعاد على النصوص والأشكال

نضبط تأثيرًا ثلاثيًا الأبعاد على شكل نص باستخدام عيّنة الكود هذه: 
```py 
    autoShape.three_d_format.bevel_bottom.bevel_type = slides.BevelPresetType.CIRCLE
    autoShape.three_d_format.bevel_bottom.height = 10.5
    autoShape.three_d_format.bevel_bottom.width = 10.5

    autoShape.three_d_format.bevel_top.bevel_type = slides.BevelPresetType.CIRCLE
    autoShape.three_d_format.bevel_top.height = 12.5
    autoShape.three_d_format.bevel_top.width = 11

    autoShape.three_d_format.extrusion_color.color = draw.Color.orange
    autoShape.three_d_format.extrusion_height = 6

    autoShape.three_d_format.contour_color.color = draw.Color.dark_red
    autoShape.three_d_format.contour_width = 1.5

    autoShape.three_d_format.depth = 3

    autoShape.three_d_format.material = slides.MaterialPresetType.PLASTIC

    autoShape.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    autoShape.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED
    autoShape.three_d_format.light_rig.set_rotation(0, 0, 40)

    autoShape.three_d_format.camera.camera_type = slides.CameraPresetType.PERSPECTIVE_CONTRASTING_RIGHT_FACING
```


النص والشكل الناتج:

![todo:image_alt_text](image-20200930114816-9.png)

نطبق تأثيرًا ثلاثيًا الأبعاد على النص باستخدام هذا الكود في Python: 
```py 
    textFrame.text_frame_format.three_d_format.bevel_bottom.bevel_type = slides.BevelPresetType.CIRCLE
    textFrame.text_frame_format.three_d_format.bevel_bottom.height = 3.5
    textFrame.text_frame_format.three_d_format.bevel_bottom.width = 3.5

    textFrame.text_frame_format.three_d_format.bevel_top.bevel_type = slides.BevelPresetType.CIRCLE
    textFrame.text_frame_format.three_d_format.bevel_top.height = 4
    textFrame.text_frame_format.three_d_format.bevel_top.width = 4

    textFrame.text_frame_format.three_d_format.extrusion_color.color = draw.Color.orange
    textFrame.text_frame_format.three_d_format.extrusion_height= 6

    textFrame.text_frame_format.three_d_format.contour_color.color = draw.Color.dark_red
    textFrame.text_frame_format.three_d_format.contour_width = 1.5

    textFrame.text_frame_format.three_d_format.depth= 3

    textFrame.text_frame_format.three_d_format.material = slides.MaterialPresetType.PLASTIC

    textFrame.text_frame_format.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    textFrame.text_frame_format.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED
    textFrame.text_frame_format.three_d_format.light_rig.set_rotation(0, 0, 40)

    textFrame.text_frame_format.three_d_format.camera.camera_type = slides.CameraPresetType.PERSPECTIVE_CONTRASTING_RIGHT_FACING
```


نتيجة العملية:

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="primary" %}} 
تطبيق تأثيرات ثلاثية الأبعاد على النصوص أو أشكالها وتفاعلاتها مع بعضها البعض يعتمد على قواعد معينة. 

تخيل مشهدًا لنص والشكل الذي يحتوي على ذلك النص. يحتوي تأثير ثلاثي الأبعاد على تمثيل كائن ثلاثي الأبعاد والمشهد الذي وُضع فيه الكائن. 

- عندما يُحدد المشهد لكل من الشكل والنص، يحصل مشهد الشكل على أولوية أعلى—يُتجاهل مشهد النص. 
- عندما لا يمتلك الشكل مشهدًا خاصًا به ولكن له تمثيل ثلاثي الأبعاد، يُستخدم مشهد النص. 
- وإلا—عندما لا يمتلك الشكل أصلاً تأثيرًا ثلاثيًا الأبعاد—يبقى الشكل مسطحًا ويُطبق التأثير الثلاثي الأبعاد فقط على النص. 

الوصف متصل بخصائص [ThreeDFormat.LightRig](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/) و[ThreeDFormat.Camera](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/). 
{{% /alert %}} 

## **تطبيق تأثيرات الظل الخارجي على النصوص**
توفر Aspose.Slides for Python via .NET الفئة [**IOuterShadow**](https://reference.aspose.com/slides/python-net/aspose.slides.effects/ioutershadow/) والفئة [**IInnerShadow**](https://reference.aspose.com/slides/python-net/aspose.slides.effects/iinnershadow/) التي تسمح لك بتطبيق تأثيرات الظل على نص داخل TextFrame. اتبع الخطوات التالية:

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/). 
2. احصل على مرجع الشريحة باستخدام فهرستها. 
3. أضف AutoShape من نوع Rectangle إلى الشريحة. 
4. وصول إلى TextFrame المرتبط بـ AutoShape. 
5. اضبط FillType للـ AutoShape إلى NoFill. 
6. أنشئ مثيلًا من فئة OuterShadow. 
7. ضبط BlurRadius للظل. 
8. ضبط Direction للظل. 
9. ضبط Distance للظل. 
10. ضبط RectanglelAlign إلى TopLeft. 
11. ضبط PresetColor للظل إلى Black. 
12. احفظ العرض التقديمي كملف PPTX. 

يعرض هذا الكود في Python—تنفيذ الخطوات أعلاه—كيفية تطبيق تأثير الظل الخارجي على نص: 
```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:

    # الحصول على مرجع الشريحة
    sld = pres.slides[0]

    # إضافة شكل تلقائي من نوع مستطيل
    ashp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 150, 50)

    # إضافة إطار نص إلى المستطيل
    ashp.add_text_frame("Aspose TextBox")

    # تعطيل تعبئة الشكل في حال رغبتنا بالحصول على ظل النص
    ashp.fill_format.fill_type = slides.FillType.NO_FILL

    # إضافة ظل خارجي وتعيين جميع المعلمات الضرورية
    ashp.effect_format.enable_outer_shadow_effect()
    shadow = ashp.effect_format.outer_shadow_effect
    shadow.blur_radius = 4.0
    shadow.direction = 45
    shadow.distance = 3
    shadow.rectangle_align = slides.RectangleAlignment.TOP_LEFT
    shadow.shadow_color.preset_color = slides.PresetColor.BLACK

    #كتابة العرض التقديمي إلى القرص
    pres.save("pres_out.pptx", slides.export.SaveFormat.PPTX)
```


## **تطبيق تأثير الظل الداخلي على الأشكال**
اتبع الخطوات التالية:

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/). 
2. احصل على مرجع الشريحة. 
3. أضف AutoShape من نوع Rectangle. 
4. فعّل InnerShadowEffect. 
5. اضبط جميع المعلمات اللازمة. 
6. اضبط ColorType إلى Scheme. 
7. اضبط Scheme Color. 
8. احفظ العرض التقديمي كملف [PPTX](https://docs.fileformat.com/presentation/pptx/). 

يعرض هذا الكود (المستند إلى الخطوات أعلاه) كيفية إضافة موصل بين شكلين في Python: 
```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    # الحصول على مرجع الشريحة
    slide = presentation.slides[0]

    # إضافة AutoShape من نوع Rectangle
    ashp = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 400, 300)
    ashp.fill_format.fill_type = slides.FillType.NO_FILL

    # إضافة TextFrame إلى Rectangle
    ashp.add_text_frame("Aspose TextBox")
    port = ashp.text_frame.paragraphs[0].portions[0]
    pf = port.portion_format
    pf.font_height = 50

    # تمكين inner_shadow_effect    
    ef = pf.effect_format
    ef.enable_inner_shadow_effect()

    # تعيين جميع المعلمات الضرورية
    ef.inner_shadow_effect.blur_radius = 8.0
    ef.inner_shadow_effect.direction = 90.0
    ef.inner_shadow_effect.distance = 6.0
    ef.inner_shadow_effect.shadow_color.b = 189

    # تعيين ColorType كـ Scheme
    ef.inner_shadow_effect.shadow_color.color_type = slides.ColorType.SCHEME

    # تعيين Scheme Color
    ef.inner_shadow_effect.shadow_color.scheme_color = slides.SchemeColor.ACCENT1

    # حفظ العرض التقديمي
    presentation.save("WordArt_out.pptx", slides.export.SaveFormat.PPTX)
```


## **الأسئلة الشائعة**

**هل يمكنني استخدام تأثيرات WordArt مع خطوط أو نصوص بلغات مختلفة (مثل العربية أو الصينية)؟**

نعم، يدعم Aspose.Slides Unicode ويعمل مع جميع الخطوط والنصوص الرئيسية. يمكن تطبيق تأثيرات WordArt مثل الظل، التعبئة، والحد بغض النظر عن اللغة، رغم أن توفر الخطوط وعرضها قد يعتمد على خطوط النظام. 

**هل يمكنني تطبيق تأثيرات WordArt على عناصر ماستر الشريحة؟**

نعم، يمكنك تطبيق تأثيرات WordArt على الأشكال في ماستر الشرائح، بما في ذلك نواقل العناوين، التذييلات، أو النص الخلفي. سيعكس أي تعديل يُجرى على تخطيط الماستر عبر جميع الشرائح المرتبطة. 

**هل تؤثر تأثيرات WordArt على حجم ملف العرض؟**

قليلاً. قد تزيد تأثيرات WordArt مثل الظلال، التوهج، وتعبئة التدرجات من حجم الملف قليلاً بسبب إضافة بيانات تنسيق، لكن الفرق عادةً ما يكون ضئيلًا. 

**هل يمكنني معاينة نتيجة تأثيرات WordArt دون حفظ العرض؟**

نعم، يمكنك تحويل الشرائح التي تحتوي على WordArt إلى صور (مثل PNG أو JPEG) باستخدام طريقة `get_image` من فئة [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) أو فئة [Slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/). يتيح لك ذلك معاينة النتيجة في الذاكرة أو على الشاشة قبل حفظ أو تصدير العرض بالكامل.