---
title: إنشاء صور مصغرة لأشكال العروض التقديمية في بايثون
linktitle: مصغرات الأشكال
type: docs
weight: 70
url: /ar/python-net/create-shape-thumbnails/
keywords:
- مصغرة الشكل
- صورة الشكل
- رسم الشكل
- عرض الشكل
- الحدود البصرية
- حدود الشكل
- PowerPoint
- عرض تقديمي
- Python
- Aspose.Slides
description: "إنشاء صور مصغرة عالية الجودة للأشكال من شرائح PowerPoint وOpenDocument باستخدام Aspose.Slides للبايثون عبر .NET – إنشاء وتصدير مصغرات العروض التقديمية بسهولة."
---
## **المقدمة**

يُستخدم Aspose.Slides for Python عبر .NET لإنشاء ملفات عرض حيث تمثل كل صفحة شريحة. يمكنك عرض هذه الشرائح في Microsoft PowerPoint عن طريق فتح ملف العرض. ومع ذلك، قد يحتاج المطورون أحيانًا إلى عرض صور الأشكال بشكل منفصل في عارض صور. في مثل هذه الحالات، يمكن لـ Aspose.Slides生成 صور مصغرة لأشكال الشرائح. يوضح هذا المقال كيفية استخدام هذه الميزة.

## **إنشاء صور مصغرة للأشكال من الشرائح**

عند الحاجة إلى معاينة لكائن معين بدلاً من الشريحة بالكامل، يمكنك إنشاء صورة مصغرة لشكل واحد. يتيح لك Aspose.Slides تصدير أي شكل إلى صورة، مما يجعل من السهل إنشاء معاينات خفيفة الوزن أو أيقونات أو أصول للمعالجة اللاحقة.

لإنشاء صورة مصغرة من أي شكل:

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/) .
1. الحصول على مرجع للشفرة عبر معرّفها أو فهرسها.
1. الحصول على مرجع للشكل الموجود على تلك الشريحة.
1. توليد صورة المصغرة للشكل.
1. حفظ صورة المصغرة بالتنسيق المطلوب.

المثال أدناه ينشئ صورة مصغرة لشكل.

```py
import aspose.slides as slides

# إنشاء نسخة من فئة Presentation لفتح ملف العرض التقديمي.
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    
    # إنشاء صورة باستخدام المقياس الافتراضي.
    with shape.get_image() as thumbnail:
        # حفظ الصورة إلى القرص بصيغة PNG.
        thumbnail.save("shape_thumbnail.png", slides.ImageFormat.PNG)
```

## **إنشاء صور مصغرة بمعامل تكبير مخصص**

تظهر هذه الفقرة كيفية إنشاء صور مصغرة للأشكال بمعامل تكبير يُحدده المستخدم في Aspose.Slides. من خلال التحكم في المقياس، يمكنك ضبط حجم الصورة المصغرة لتناسب المعاينات أو الصادرات أو الشاشات عالية الدقة.

لإنشاء صورة مصغرة لأي شكل على شريحة:

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/) .
1. الحصول على شريحة عبر معرّفها أو فهرسها.
1. الحصول على الشكل المستهدف على تلك الشريحة.
1. توليد صورة المصغرة للشكل باستخدام المقياس المحدد.
1. حفظ صورة المصغرة بالتنسيق المطلوب.

المثال أدناه يولد صورة مصغرة بمعامل تكبير مخصص.

```py
import aspose.slides as slides

scale_x = 2.0
scale_y = scale_x

# إنشاء نسخة من فئة Presentation لفتح ملف العرض التقديمي.
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    
    # إنشاء صورة باستخدام المقياس المحدد.
    with shape.get_image(slides.ShapeThumbnailBounds.SHAPE, scale_x, scale_y) as thumbnail:
        # حفظ الصورة إلى القرص بصيغة PNG.
        thumbnail.save("scaling_factor.png", slides.ImageFormat.PNG)
```

## **إنشاء صور مصغرة باستخدام حدود مظهر الشكل**

توضح هذه الفقرة كيفية إنشاء صورة مصغرة داخل حدود مظهر الشكل. تأخذ جميع تأثيرات الشكل في الاعتبار. يتم تقييد الصورة المصغرة الناتجة بحدود الشريحة.

لإنشاء صورة مصغرة لأي شكل شريحة ضمن حدود مظهره:

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/) .
1. الحصول على شريحة عبر معرّفها أو فهرسها.
1. الحصول على الشكل المستهدف على تلك الشريحة.
1. توليد صورة المصغرة للشكل باستخدام الحدود المحددة.
1. حفظ صورة المصغرة بالتنسيق المطلوب.

المثال أدناه ينشئ صورة مصغرة بحدود يحددها المستخدم.

```py
import aspose.slides as slides

image_bounds = slides.ShapeThumbnailBounds.APPEARANCE

# إنشاء نسخة من فئة Presentation لفتح ملف العرض التقديمي.
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    # إنشاء صورة للشكل بحدود المظهر.
    with shape.get_image(image_bounds, 1.0, 1.0) as thumbnail:
        # حفظ الصورة إلى القرص بصيغة PNG.
        thumbnail.save("apperance_bounds.png", slides.ImageFormat.PNG)
```

## **الحصول على الحدود البصرية الفعلية لشكل**

خصائص الإطار لـ [Shape](https://reference.aspose.com/slides/ar/python-net/aspose.slides/shape/) — `Shape.x`، `Shape.y`، `Shape.width`، و `Shape.height` — تصف المستطيل المخزن في نموذج العرض. قد يمتد المحتوى الفعلي المُرسم خارج ذلك الإطار أو يشغل مستطيلًا محاذيًا مختلفًا. يمكن أن تغير التدوير، الحدود، رؤوس السهام، تخطيط النص وتدفقه، هندسة SmartArt المُولدة، وغيرها من تأثيرات الرسم المنطقة المحتلة.

استخدم [Shape.get_visual_bounds](https://reference.aspose.com/slides/ar/python-net/aspose.slides/shape/get_visual_bounds/) لحساب تلك المنطقة المحتلة دون إنشاء صورة. تُرجع الطريقة مستطيلًا عائمًا في إحداثيات الشريحة. لا يتم قص المستطيل إلى حدود الشريحة، لذا قد تكون إحداثياته سالبة عندما يمتد المحتوى خارج أصل الشريحة.

المثال التالي يحصل على الحدود الإطارية والبصرية ويقارنهما:

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

with slides.Presentation("example.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    visual_bounds = shape.get_visual_bounds()

    frame_values = (shape.x, shape.y, shape.width, shape.height)
    visual_values = (visual_bounds.x, visual_bounds.y, visual_bounds.width, visual_bounds.height)

    print(f"Frame bounds (x, y, width, height): {frame_values}")
    print(f"Visual bounds (x, y, width, height): {visual_values}")
```

يمكن استخدام نفس المستطيل لمحاذاة الأشكال القريبة إلى حافة `left` أو `right` أو `top` أو `bottom`؛ حجز مساحة كافية في تخطيط مُولّد؛ أو اكتشاف المحتوى خارج المنطقة المسموح بها. تكون الحدود البصرية مفيدة بشكل خاص لـ SmartArt، مربعات النص، الأسهم، الصور، الأشكال الدائرية، ومجموعات الأشكال، حيث قد لا يمثل الإطار المخزن النتيجة المُرسمة بالكامل.

استخدم [Shape.get_visual_bounds](https://reference.aspose.com/slides/ar/python-net/aspose.slides/shape/get_visual_bounds/) عندما تحتاج إلى إحداثيات للتخطيط أو التحقق ولا تحتاج إلى صورة نقطية. استخدم [Shape.get_image](https://reference.aspose.com/slides/ar/python-net/aspose.slides/shape/get_image/) عندما تحتاج إلى رسم الشكل. مع [ShapeThumbnailBounds](https://reference.aspose.com/slides/ar/python-net/aspose.slides/shapethumbnailbounds/)، يحدد `ShapeThumbnailBounds.SHAPE` حجم الصورة من حدود الشكل، متضمنًا إعدادات الخط، بينما يحدد `ShapeThumbnailBounds.APPEARANCE` الحجم من مظهر الشكل ويقيد النتيجة بحدود الشريحة. بالمقابل، تُرجع `Shape.get_visual_bounds` فقط المستطيل المحسوب ولا تقصه إلى الشريحة.

## **الأسئلة المتكررة**

**ما صيغ الصور التي يمكن استخدامها عند حفظ صور مصغرة للأشكال؟**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/ar/python-net/aspose.slides/imageformat/)، وغيرها. يمكن أيضًا [تصدير الأشكال كـ SVG متجه](https://reference.aspose.com/slides/ar/python-net/aspose.slides/shape/write_as_svg/) عن طريق حفظ محتوى الشكل كملف SVG.

**ما الفرق بين حدود SHAPE و APPEARANCE عند إنشاء صورة مصغرة؟**

يستخدم `SHAPE` هندسة الشكل؛ بينما يأخذ `APPEARANCE` في الاعتبار [التأثيرات البصرية](/slides/ar/python-net/shape-effect/) (الظلال، التوهجات، إلخ).

**ماذا يحدث إذا تم وضع علامة على الشكل كـ مخفي؟ هل سيظل يُنشأ له صورة مصغرة؟**

يبقى الشكل المخفي جزءًا من النموذج ويمكن رسمه؛ تؤثر علامة الإخفاء على عرض الشريحة فقط ولا تمنع إنشاء صورة الشكل.

**هل تدعم مجموعات الأشكال، المخططات، SmartArt، وغيرها من الكائنات المعقدة؟**

نعم. يمكن حفظ أي كائن يُمثَّل كـ [Shape](https://reference.aspose.com/slides/ar/python-net/aspose.slides/shape/) (بما في ذلك [GroupShape](https://reference.aspose.com/slides/ar/python-net/aspose.slides/groupshape/)، [Chart](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chart/)، و [SmartArt](https://reference.aspose.com/slides/ar/python-net/aspose.slides.smartart/smartart/)) كصورة مصغرة أو كملف SVG.

**هل تؤثر الخطوط المثبتة على النظام على جودة الصور المصغرة لأشكال النص؟**

نعم. يجب عليك [توفير الخطوط المطلوبة](/slides/ar/python-net/custom-font/) (أو [تكوين استبدالات الخطوط](/slides/ar/python-net/font-substitution/)) لتجنب الاعتماد على خطوط بديلة غير مرغوبة وتدفق النص غير المرغوب.