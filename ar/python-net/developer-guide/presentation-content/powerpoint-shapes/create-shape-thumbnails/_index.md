---
title: إنشاء صور مصغرة لأشكال العرض التقديمي في بايثون
linktitle: صور مصغرة للأشكال
type: docs
weight: 70
url: /ar/python-net/create-shape-thumbnails/
keywords:
- صورة مصغرة للشكل
- صورة الشكل
- رسم الشكل
- تصيير الشكل
- PowerPoint
- العرض التقديمي
- Python
- Aspose.Slides
description: "إنشاء صور مصغرة عالية الجودة للأشكال من شرائح PowerPoint وOpenDocument باستخدام Aspose.Slides لبايثون عبر .NET – إنشاء وتصدير صور مصغرة للعرض التقديمي بسهولة."
---

## **المقدمة**

تُستخدم Aspose.Slides for Python عبر .NET لإنشاء ملفات عروض تقديمية تكون كل صفحة فيها شريحة. يمكنك عرض هذه الشرائح في Microsoft PowerPoint عن طريق فتح ملف العرض. ومع ذلك، قد يحتاج المطورون أحيانًا إلى عرض صور الأشكال بشكل منفصل في عارض صور. في مثل هذه الحالات، يمكن لـ Aspose.Slides إنشاء صور مصغرة لأشكال الشرائح. يشرح هذا المقال كيفية استخدام هذه الميزة.

## **إنشاء صور مصغرة للأشكال من الشرائح**

عندما تحتاج إلى معاينة لكائن محدد بدلاً من الشريحة بأكملها، يمكنك إنشاء صورة مصغرة لشكل فردي. تتيح لك Aspose.Slides تصدير أي شكل إلى صورة، مما يجعل إنشاء معاينات خفيفة الوزن أو أيقونات أو موارد للمعالجة اللاحقة أمرًا سهلاً.

لإنشاء صورة مصغرة من أي شكل:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. الحصول على مرجع إلى شريحة باستخدام معرفها أو فهرستها.
1. الحصول على مرجع إلى شكل على تلك الشريحة.
1. إنشاء صورة مصغرة للشكل.
1. حفظ صورة المصغرة بالتنسيق المطلوب.

```py
import aspose.slides as slides

# إنشاء كائن من فئة Presentation لفتح ملف العرض.
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    
    # إنشاء صورة بمقياس افتراضي.
    with shape.get_image() as thumbnail:
        # حفظ الصورة إلى القرص بتنسيق PNG.
        thumbnail.save("shape_thumbnail.png", slides.ImageFormat.PNG)
```


## **إنشاء صور مصغرة بمعامل قياس مخصص**

يعرض هذا القسم كيفية إنشاء صور مصغرة للأشكال بمعامل قياس يحدده المستخدم في Aspose.Slides. من خلال التحكم في المقياس، يمكنك ضبط حجم الصورة المصغرة لتتناسب مع المعاينات أو الصادرات أو الشاشات عالية الدقة.

لإنشاء صورة مصغرة لأي شكل على شريحة:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. الحصول على شريحة باستخدام معرفها أو فهرستها.
1. الحصول على الشكل المستهدف على تلك الشريحة.
1. إنشاء صورة مصغرة للشكل باستخدام المقياس المحدد.
1. حفظ صورة المصغرة بالتنسيق المطلوب.

```py
import aspose.slides as slides

scale_x = 2.0
scale_y = scale_x

# إنشاء كائن من فئة Presentation لفتح ملف العرض.
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    
    # إنشاء صورة بالمقياس المحدد.
    with shape.get_image(slides.ShapeThumbnailBounds.SHAPE, scale_x, scale_y) as thumbnail:
        # حفظ الصورة إلى القرص بتنسيق PNG.
        thumbnail.save("scaling_factor.png", slides.ImageFormat.PNG)
```


## **إنشاء صور مصغرة باستخدام حدود مظهر الشكل**

يعرض هذا القسم كيفية إنشاء صورة مصغرة ضمن حدود مظهر الشكل. يأخذ ذلك في الاعتبار جميع تأثيرات الشكل. تُقيَّد الصورة المصغرة التي تم إنشاؤها بحدود الشريحة.

لإنشاء صورة مصغرة لأي شكل شريحة ضمن حدود مظهره:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. الحصول على شريحة باستخدام معرفها أو فهرستها.
1. الحصول على الشكل المستهدف على تلك الشريحة.
1. إنشاء صورة مصغرة للشكل باستخدام الحدود المحددة.
1. حفظ صورة المصغرة بالتنسيق المرغوب للصور.

```py
import aspose.slides as slides

image_bounds = slides.ShapeThumbnailBounds.APPEARANCE

# إنشاء كائن من فئة Presentation لفتح ملف العرض.
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    # إنشاء صورة شكل بحدود المظهر.
    with shape.get_image(image_bounds, 1.0, 1.0) as thumbnail:
        # حفظ الصورة إلى القرص بتنسيق PNG.
        thumbnail.save("apperance_bounds.png", slides.ImageFormat.PNG)
```


## **الأسئلة المتكررة**

**ما صيغ الصور التي يمكن استخدامها عند حفظ صور المصغرة للأشكال؟**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/python-net/aspose.slides/imageformat/)، وغيرها. يمكن أيضًا [تصدير الأشكال كـ SVG متجهة](https://reference.aspose.com/slides/python-net/aspose.slides/shape/write_as_svg/) عن طريق حفظ محتوى الشكل كملف SVG.

**ما الفرق بين حدود SHAPE وAPPEARANCE عند إنشاء صورة مصغرة؟**

`SHAPE` يستخدم هندسة الشكل؛ `APPEARANCE` يأخذ [التأثيرات البصرية](/slides/ar/python-net/shape-effect/) (الظلال، التوهجات، إلخ) في الاعتبار.

**ماذا يحدث إذا تم وضع علامة على شكل كـ مخفي؟ هل سيستمر في إنشاء صورة مصغرة؟**

يبقى الشكل المخفي جزءًا من النموذج ويمكن إنشاء صورة له؛ علم الإخفاء يؤثر على عرض الشريحة في العرض التقديمي ولكنه لا يمنع إنشاء صورة الشكل.

**هل تدعم الأشكال الجماعية والمخططات وSmartArt وغيرها من الكائنات المعقدة؟**

نعم. يمكن حفظ أي كائن ممثل كـ [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) (بما في ذلك [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/)، [Chart](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/)، و[SmartArt](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/)) كصورة مصغرة أو كملف SVG.

**هل تؤثر الخطوط المثبتة على النظام على جودة الصور المصغرة لأشكال النص؟**

نعم. يجب عليك [توفير الخطوط المطلوبة](/slides/ar/python-net/custom-font/) (أو [تكوين استبدالات الخطوط](/slides/ar/python-net/font-substitution/)) لتجنب العروض الاحتياطية غير المرغوبة وإعادة تدفق النص.