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
- تأثير العرض
- تأثير التوهج
- تحويل WordArt
- تأثير ثلاثي الأبعاد
- تأثير الظل الخارجي
- تأثير الظل الداخلي
- Python
- Aspose.Slides
description: "تعرّف على كيفية إنشاء وتخصيص تأثيرات WordArt في Aspose.Slides for Python via .NET. يقدّم هذا الدليل خطوة بخطوة مساعدة للمطورين على تحسين العروض التقديمية بنص أنيق واحترافي في Python."
---

## **ماذا عن فن الكلمات؟**
فن الكلمة هو ميزة تسمح لك بتطبيق تأثيرات على النصوص لجعلها بارزة. مع فن الكلمة، على سبيل المثال، يمكنك تحديد شكل النص أو ملؤه بلون (أو تدرج)، وإضافة تأثيرات ثلاثية الأبعاد له، وما إلى ذلك. يمكنك أيضًا تشويه، وانحناء، وتمديد شكل النص.

{{% alert color="primary" %}}

يسمح لك فن الكلمة بالتعامل مع النص كمجسم رسومي. يتكون فن الكلمة من تأثيرات أو تعديلات خاصة تضاف للنصوص لجعلها أكثر جاذبية أو وضوحًا.

{{% /alert %}}

**فن الكلمة في Microsoft PowerPoint**

لاستخدام فن الكلمة في Microsoft PowerPoint، يجب عليك اختيار أحد قوالب فن الكلمة المحددة مسبقًا. قالب فن الكلمة هو مجموعة من التأثيرات التي تُطبق على نص أو شكله.

**فن الكلمة في Aspose.Slides**

في Aspose.Slides لبايثون عبر .NET 20.10، قمنا بتنفيذ دعم لفن الكلمة وأجرينا تحسينات على هذه الميزة في إصدارات Aspose.Slides لبايثون عبر .NET التي تليها.

مع Aspose.Slides لبايثون عبر .NET، يمكنك بسهولة إنشاء قالب فن الكلمة الخاص بك (تأثير واحد أو مجموعة من التأثيرات) في بايثون وتطبيقه على النصوص.

## إنشاء قالب بسيط لفن الكلمة وتطبيقه على نص

**باستخدام Aspose.Slides**

أولاً، نقوم بإنشاء نص بسيط باستخدام هذا الرمز بلغة بايثون:

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
الآن، نقوم بتعيين ارتفاع خط النص إلى قيمة أكبر لجعل التأثير أكثر وضوحًا من خلال هذا الرمز:

```py 
    fontData = slides.FontData("Arial Black")
    portion.portion_format.latin_font = fontData
    portion.portion_format.font_height = 36
```

**باستخدام Microsoft PowerPoint**

اذهب إلى قائمة تأثيرات فن الكلمة في Microsoft PowerPoint:

![todo:image_alt_text](image-20200930113926-1.png)

يمكنك من القائمة على اليمين اختيار تأثير فن الكلمة المحدد مسبقًا. من القائمة على اليسار، يمكنك تحديد إعدادات لفن الكلمة الجديد.

هذه بعض المعلمات أو الخيارات المتاحة:

![todo:image_alt_text](image-20200930114015-3.png)

**باستخدام Aspose.Slides**

هنا، نطبق لون نمط SmallGrid على النص ونضيف حد للنص بعرض 1 بلون أسود باستخدام هذا الرمز:

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

## تطبيق تأثيرات فن الكلمة الأخرى

**باستخدام Microsoft PowerPoint**

من واجهة البرنامج، يمكنك تطبيق هذه التأثيرات على نص، كتلة نصية، شكل، أو عنصر مشابه:

![todo:image_alt_text](image-20200930114129-5.png)

على سبيل المثال، يمكن تطبيق تأثيرات الظل، الانعكاس، والتوهج على نص؛ يمكن تطبيق تأثيرات تنسيق ثلاثي الأبعاد ودوران ثلاثي الأبعاد على كتلة نصية؛ و خاصية الحواف الناعمة يمكن تطبيقها على كائن الشكل (لا يزال له تأثير عندما لا يتم تعيين خاصية تنسيق ثلاثي الأبعاد).

### تطبيق تأثيرات الظل

هنا، نهدف إلى تعيين الخصائص المتعلقة بالنص فقط. نطبق تأثير الظل على النص باستخدام هذا الرمز في بايثون:

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

تدعم واجهة برمجة تطبيقات Aspose.Slides ثلاثة أنواع من الظلال: OuterShadow وInnerShadow وPresetShadow.

مع PresetShadow، يمكنك تطبيق ظل على نص (باستخدام قيم محددة مسبقًا).

**باستخدام Microsoft PowerPoint**

في PowerPoint، يمكنك استخدام نوع واحد من الظلال. إليك مثال:

![todo:image_alt_text](image-20200930114225-6.png)

**باستخدام Aspose.Slides**

تسمح لك Aspose.Slides فعليًا بتطبيق نوعين من الظلال في وقت واحد: InnerShadow وPresetShadow.

**ملاحظات:**

- عند استخدام OuterShadow وPresetShadow معًا، يتم تطبيق تأثير OuterShadow فقط.
- إذا تم استخدام OuterShadow وInnerShadow في نفس الوقت، فإن التأثير الناتج أو المطبق يعتمد على إصدار PowerPoint. على سبيل المثال، في PowerPoint 2013، يتم مضاعفة التأثير. ولكن في PowerPoint 2007، يتم تطبيق تأثير OuterShadow.

### تطبيق العرض على النصوص

نضيف العرض إلى النص من خلال هذا الكود في بايثون:

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

نطبق تأثير التوهج على النص لجعله يسطع أو يبرز باستخدام هذا الرمز:

```py 
    portion.portion_format.effect_format.enable_glow_effect()
    portion.portion_format.effect_format.glow_effect.color.r = 255
    portion.portion_format.effect_format.glow_effect.color.color_transform.add(slides.ColorTransformOperation.SET_ALPHA, 0.54)
    portion.portion_format.effect_format.glow_effect.radius = 7
```

نتيجة العملية:

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}}

يمكنك تغيير المعلمات للظل، العرض، والتوهج. يتم تعيين خصائص التأثيرات على كل جزء من النص بشكل منفصل.

{{% /alert %}}

### استخدام التحويلات في فن الكلمة

نستخدم خاصية Transform (التي تتعلق بكتلة النص بالكامل) من خلال هذا الرمز:
```py 
textFrame.text_frame_format.transform = slides.TextShapeType.ARCH_UP_POUR
```

النتيجة:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}}

يوفر كل من Microsoft PowerPoint وAspose.Slides لبايثون عبر .NET عددًا معينًا من أنواع التحويلات المحددة مسبقًا.

{{% /alert %}}

**باستخدام PowerPoint**

للوصول إلى أنواع التحويلات المحددة مسبقًا، مرر عبر: **تنسيق** -> **تأثير النص** -> **تحويل**

**باستخدام Aspose.Slides**

لاختيار نوع تحويل، استخدم التعداد النصي TextShapeType.

### تطبيق تأثيرات ثلاثية الأبعاد على النصوص والأشكال

نحدد تأثيرًا ثلاثي الأبعاد على شكل النص باستخدام هذا الرمز النموذجي:

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

النص الناتج وشكله:

![todo:image_alt_text](image-20200930114816-9.png)

نطبق تأثيرًا ثلاثي الأبعاد على النص باستخدام هذا الرمز في بايثون:

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

يعتمد تطبيق تأثيرات ثلاثية الأبعاد على النصوص أو أشكالها والتفاعلات بين التأثيرات على قواعد معينة.

اعتبر مشهدًا لنص والشكل الذي يحتوي على ذلك النص. يتضمن التأثير ثلاثي الأبعاد تمثيل الكائن ثلاثي الأبعاد والمشهد الذي وُضع فيه الكائن.

- عند تعيين المشهد لكل من الشكل والنص، يحصل شكل المشهد على الأولوية الأعلى - يُتجاهل مشهد النص.
- عندما يفتقر الشكل إلى مشهد خاص به ولكنه يحتوي على تمثيل ثلاثي الأبعاد، يتم استخدام مشهد النص.
- خلاف ذلك - عندما لا يحتوي الشكل أصلاً على تأثير ثلاثي الأبعاد - يكون الشكل مسطحًا ويتم تطبيق التأثير ثلاثي الأبعاد فقط على النص.

تتعلق الأوصاف بخصائص [ThreeDFormat.LightRig](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/) و[ThreeDFormat.Camera](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/).

{{% /alert %}}

## **تطبيق تأثيرات الظل الخارجي على النصوص**
توفر Aspose.Slides لبايثون عبر .NET [**IOuterShadow**](https://reference.aspose.com/slides/python-net/aspose.slides.effects/ioutershadow/) و[**IInnerShadow**](https://reference.aspose.com/slides/python-net/aspose.slides.effects/iinnershadow/) التي تتيح لك تطبيق تأثيرات الظل على النص الذي تحمله TextFrame. اتبع هذه الخطوات:

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. احصل على مرجع لشريحة باستخدام فهرسها.
3. أضف شكلاً تلقائيًا من نوع المستطيل إلى الشريحة.
4. الوصول إلى TextFrame المرتبطة بالشكل التلقائي.
5. تعيين FillType للشكل التلقائي إلى NoFill.
6. قم بتثبيت فئة OuterShadow.
7. تعيين BlurRadius للظل.
8. تعيين اتجاه الظل.
9. تعيين مسافة الظل.
10. تعيين RectangleAlign إلى TopLeft.
11. تعيين PresetColor للظل إلى اللون الأسود.
12. كتابة العرض التقديمي كملف PPTX.

هذا الرمز التجريبي بلغة بايثون - هو تنفيذ للخطوات أعلاه - يوضح لك كيفية تطبيق تأثير الظل الخارجي على نص:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:

    # احصل على مرجع الشريحة
    sld = pres.slides[0]

    # أضف شكلاً تلقائيًا من نوع المستطيل
    ashp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 150, 50)

    # أضف TextFrame إلى المستطيل
    ashp.add_text_frame("Aspose TextBox")

    # تعطيل تعبئة الشكل في حالة رغبتنا في الحصول على ظل النص
    ashp.fill_format.fill_type = slides.FillType.NO_FILL

    # أضف ظل خارجي وقم بتعيين جميع المعلمات اللازمة
    ashp.effect_format.enable_outer_shadow_effect()
    shadow = ashp.effect_format.outer_shadow_effect
    shadow.blur_radius = 4.0
    shadow.direction = 45
    shadow.distance = 3
    shadow.rectangle_align = slides.RectangleAlignment.TOP_LEFT
    shadow.shadow_color.preset_color = slides.PresetColor.BLACK

    # كتابة العرض التقديمي إلى القرص
    pres.save("pres_out.pptx", slides.export.SaveFormat.PPTX)
```


## **تطبيق تأثير الظل الداخلي على الأشكال**
اتبع هذه الخطوات:

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. احصل على مرجع الشريحة.
3. أضف شكلاً تلقائيًا من نوع المستطيل.
4. قم بتمكين تأثير الظل الداخلي.
5. تعيين جميع المعلمات اللازمة.
6. تعيين ColorType كـ Scheme.
7. تعيين لون المخطط.
8. كتابة العرض التقديمي كملف [PPTX](https://docs.fileformat.com/presentation/pptx/) .

هذا الرمز التجريبي (استنادًا إلى الخطوات أعلاه) يوضح لك كيفية إضافة موصل بين شكلين في بايثون:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    # احصل على مرجع لشريحة
    slide = presentation.slides[0]

    # أضف شكلاً تلقائيًا من نوع المستطيل
    ashp = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 400, 300)
    ashp.fill_format.fill_type = slides.FillType.NO_FILL

    # أضف TextFrame إلى المستطيل
    ashp.add_text_frame("Aspose TextBox")
    port = ashp.text_frame.paragraphs[0].portions[0]
    pf = port.portion_format
    pf.font_height = 50

    # تمكين تأثير الظل الداخلي    
    ef = pf.effect_format
    ef.enable_inner_shadow_effect()

    # تعيين جميع المعلمات اللازمة
    ef.inner_shadow_effect.blur_radius = 8.0
    ef.inner_shadow_effect.direction = 90.0
    ef.inner_shadow_effect.distance = 6.0
    ef.inner_shadow_effect.shadow_color.b = 189

    # تعيين ColorType كـ Scheme
    ef.inner_shadow_effect.shadow_color.color_type = slides.ColorType.SCHEME

    # تعيين لون المخطط
    ef.inner_shadow_effect.shadow_color.scheme_color = slides.SchemeColor.ACCENT1

    # حفظ العرض التقديمي
    presentation.save("WordArt_out.pptx", slides.export.SaveFormat.PPTX)
```