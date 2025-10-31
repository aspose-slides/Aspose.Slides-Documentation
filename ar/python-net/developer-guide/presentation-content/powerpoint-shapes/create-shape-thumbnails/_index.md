---
title: إنشاء صور مصغرة لأشكال العرض التقديمي في بايثون
linktitle: مصغرات الأشكال
type: docs
weight: 70
url: /ar/python-net/create-shape-thumbnails/
keywords:
- مصغرة الشكل
- صورة الشكل
- تصيير الشكل
- تصيير الأشكال
- PowerPoint
- العرض التقديمي
- Python
- Aspose.Slides
description: "إنشاء صور مصغرة عالية الجودة للأشكال من شرائح PowerPoint وOpenDocument باستخدام Aspose.Slides لبايثون عبر .NET – بسهولة إنشاء وتصدير مصغرات العروض التقديمية."
---

## **مقدمة**

يُستخدم Aspose.Slides لبايثون عبر .NET لإنشاء ملفات عرض تقديمي تكون كل صفحة فيها شريحة. يمكنك عرض هذه الشرائح في Microsoft PowerPoint بفتح ملف العرض التقديمي. في بعض الأحيان قد يحتاج المطورون إلى عرض صور الأشكال بشكل منفصل في عارض صور. في مثل هذه الحالات يمكن لـ Aspose.Slides إنشاء صور مصغرة لأشكال الشرائح. يشرح هذا المقال كيفية استخدام هذه الميزة.

## **إنشاء مصغرات أشكال من الشرائح**

عند الحاجة إلى معاينة لكائن معين بدلاً من الشريحة كاملة، يمكنك تصيير مصغرة لشكل فردي. يتيح لك Aspose.Slides تصدير أي شكل إلى صورة، مما يجعل من السهل إنشاء معاينات خفيفة الوزن أو أيقونات أو موارد للمعالجة اللاحقة.

لإنشاء مصغرة من أي شكل:

1. إنشاء كائن من فئة [العرض التقديمي](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
2. الحصول على مرجع إلى شريحة عبر معرفها أو فهرسها.
3. الحصول على مرجع إلى شكل على تلك الشريحة.
4. تصيير صورة المصغرة للشكل.
5. حفظ صورة المصغرة بالتنسيق المطلوب.

المثال أدناه ينشئ مصغرة شكل.

```py
import aspose.slides as slides

# إنشاء كائن من الفئة Presentation لفتح ملف العرض التقديمي.
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    
    # إنشاء صورة بمقياس افتراضي.
    with shape.get_image() as thumbnail:
        # حفظ الصورة إلى القرص بتنسيق PNG.
        thumbnail.save("shape_thumbnail.png", slides.ImageFormat.PNG)
```

## **إنشاء مصغرات بمعامل تكبير مخصص**

يظهر هذا القسم كيفية إنشاء مصغرات أشكال بمعامل تكبير يُحدده المستخدم في Aspose.Slides. من خلال التحكم في المقياس، يمكنك ضبط حجم المصغرة لتناسب المعاينات أو الصادرات أو الشاشات ذات الدقة العالية.

لإنشاء مصغرة لأي شكل على شريحة:

1. إنشاء كائن من فئة [العرض التقديمي](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
2. الحصول على شريحة عبر معرفها أو فهرسها.
3. الحصول على الشكل المستهدف على تلك الشريحة.
4. تصيير صورة المصغرة للشكل بالمقياس المحدد.
5. حفظ صورة المصغرة بالتنسيق المطلوب.

المثال أدناه ينشئ مصغرة بمعامل تكبير مُحدّد من قبل المستخدم.

```py
import aspose.slides as slides

scale_x = 2.0
scale_y = scale_x

# إنشاء كائن من الفئة Presentation لفتح ملف العرض التقديمي.
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    
    # إنشاء صورة بالمقياس المُحدد.
    with shape.get_image(slides.ShapeThumbnailBounds.SHAPE, scale_x, scale_y) as thumbnail:
        # حفظ الصورة إلى القرص بتنسيق PNG.
        thumbnail.save("scaling_factor.png", slides.ImageFormat.PNG)
```

## **إنشاء مصغرات باستخدام حدود ظهور الشكل**

يُظهر هذا القسم كيفية إنشاء مصغرة داخل حدود ظهور الشكل. يأخذ ذلك جميع تأثيرات الشكل في الاعتبار. تكون المصغرة الناتجة مقيدة بحدود الشريحة.

لإنشاء مصغرة لأي شكل شريحة داخل حدود ظهوره:

1. إنشاء كائن من فئة [العرض التقديمي](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
2. الحصول على شريحة عبر معرفها أو فهرسها.
3. الحصول على الشكل المستهدف على تلك الشريحة.
4. تصيير صورة المصغرة للشكل بالحدود المحددة.
5. حفظ صورة المصغرة بالتنسيق المطلوب.

المثال أدناه ينشئ مصغرة بحدود يتم تعريفها من قبل المستخدم.

```py
import aspose.slides as slides

image_bounds = slides.ShapeThumbnailBounds.APPEARANCE

# إنشاء كائن من الفئة Presentation لفتح ملف العرض التقديمي.
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    # إنشاء صورة شكل بحدود الظهور.
    with shape.get_image(image_bounds, 1.0, 1.0) as thumbnail:
        # حفظ الصورة إلى القرص بتنسيق PNG.
        thumbnail.save("apperance_bounds.png", slides.ImageFormat.PNG)
```

## **الأسئلة المتكررة**

**ما صيغ الصورة التي يمكن استخدامها عند حفظ مصغرات الأشكال؟**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/python-net/aspose.slides/imageformat/)، وغيرها. يمكن أيضًا [تصدير الأشكال كـ SVG](https://reference.aspose.com/slides/python-net/aspose.slides/shape/write_as_svg/) بحفظ محتوى الشكل كملف SVG.

**ما الفرق بين حدود SHAPE و APPEARANCE عند تصيير المصغرة؟**

`SHAPE` يستخدم هندسة الشكل؛ `APPEARANCE` يأخذ [التأثيرات المرئية](/slides/ar/python-net/shape-effect/) (الظلال، التوهجات، إلخ) في الاعتبار.

**ماذا يحدث إذا تم تعليم الشكل كـ مخفي؟ هل سيظل يُصَيَّر كمصغرة؟**

يبقى الشكل المخفي جزءًا من النموذج ويمكن تصييره؛ علم الإخفاء يؤثر على عرض الشريحة في العرض التقديمي لكنه لا يمنع إنشاء صورة الشكل.

**هل تدعم الأشكال الجماعية، المخططات، SmartArt، وغيرها من الكائنات المعقدة؟**

نعم. أي كائن يُمثَّل كـ [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) (بما في ذلك [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/)، [Chart](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/)، و[SmartArt](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/)) يمكن حفظه كمصغرة أو كـ SVG.

**هل تؤثر الخطوط المثبتة على النظام على جودة المصغرات للأشكال النصية؟**

نعم. يجب عليك [توفير الخطوط المطلوبة](/slides/ar/python-net/custom-font/) (أو [تكوين بدائل الخطوط](/slides/ar/python-net/font-substitution/)) لتجنب الاستبدالات غير المرغوبة وإعادة تدفق النص.