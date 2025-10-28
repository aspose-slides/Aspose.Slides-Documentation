---
title: إنشاء صور مصغرة لأشكال العرض التقديمي في بايثون
linktitle: مصغرات الشكل
type: docs
weight: 70
url: /ar/python-net/create-shape-thumbnails/
keywords:
- مصغرة الشكل
- صورة الشكل
- رسم الشكل
- تصيير الشكل
- PowerPoint
- عرض تقديمي
- Python
- Aspose.Slides
description: إنشاء صور مصغرة عالية الجودة للأشكال من شرائح PowerPoint وOpenDocument باستخدام Aspose.Slides لبايثون عبر .NET – إنشاء وتصدير صور مصغرة للعرض التقديمي بسهولة.
---

## **مقدمة**

يُستخدم Aspose.Slides لبايثون عبر .NET لإنشاء ملفات عروض تقديمية تكون كل صفحة فيها شريحة. يمكنك عرض هذه الشرائح في Microsoft PowerPoint بفتح ملف العرض التقديمي. ومع ذلك، قد يحتاج المطورون أحيانًا إلى عرض صور الأشكال بشكل منفصل في عارض صور. في هذه الحالات، يمكن لـ Aspose.Slides توليد صور مصغرة لأشكال الشرائح. توضح هذه المقالة كيفية استخدام هذه الميزة.

## **إنشاء مصغرات الأشكال من الشرائح**

عندما تحتاج إلى معاينة لكائن محدد بدلاً من الشريحة كاملة، يمكنك تصيير صورة مصغرة لشكل فردي. يتيح لك Aspose.Slides تصدير أي شكل إلى صورة، مما يسهل إنشاء معاينات خفيفة الوزن أو أيقونات أو موارد لمعالجة لاحقة.

لإنشاء صورة مصغرة من أي شكل:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. الحصول على مرجع إلى شريحة عبر معرفها أو فهرستها.
3. الحصول على مرجع إلى شكل في تلك الشريحة.
4. تصيير صورة المصغرة للشكل.
5. حفظ صورة المصغرة بالتنسيق المطلوب.

```py
import aspose.slides as slides

# Instantiate the Presentation class to open the presentation file.
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    
    # Create a image with the default scale.
    with shape.get_image() as thumbnail:
        # Save the image to disk in PNG format.
        thumbnail.save("shape_thumbnail.png", slides.ImageFormat.PNG)
```

## **إنشاء مصغرات بمعامل تحجيم مخصص**

يوضح هذا القسم كيفية إنشاء مصغرات الأشكال بمعامل تحجيم يُحدده المستخدم في Aspose.Slides. من خلال التحكم في التحجيم، يمكنك ضبط حجم الصورة المصغرة لتناسب المعاينات أو الصادرات أو الشاشات عالية الدقة.

لإنشاء صورة مصغرة لأي شكل على شريحة:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. الحصول على شريحة عبر معرفها أو فهرستها.
3. الحصول على الشكل المستهدف على تلك الشريحة.
4. تصيير صورة المصغرة للشكل بالتحجيم المحدد.
5. حفظ صورة المصغرة بالتنسيق المطلوب.

```py
import aspose.slides as slides

scale_x = 2.0
scale_y = scale_x

# Instantiate the Presentation class to open the presentation file.
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    
    # Create an image with the defined scale.
    with shape.get_image(slides.ShapeThumbnailBounds.SHAPE, scale_x, scale_y) as thumbnail:
        # Save the image to disk in PNG format.
        thumbnail.save("scaling_factor.png", slides.ImageFormat.PNG)
```

## **إنشاء مصغرات باستخدام حدود مظهر الشكل**

يوضح هذا القسم كيفية إنشاء مصغرة داخل حدود مظهر الشكل. يأخذ ذلك جميع تأثيرات الشكل في الاعتبار. الصورة المصغرة الناتجة محدودة بحدود الشريحة.

لإنشاء صورة مصغرة لأي شكل شريحة داخل حدود مظهره:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. الحصول على شريحة عبر معرفها أو فهرستها.
3. الحصول على الشكل المستهدف على تلك الشريحة.
4. تصيير صورة المصغرة للشكل بالحدود المحددة.
5. حفظ صورة المصغرة بالتنسيق المطلوب.

```py
import aspose.slides as slides

image_bounds = slides.ShapeThumbnailBounds.APPEARANCE

# Instantiate the Presentation class to open the presentation file.
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    # Create an appearance-bounds shape image.
    with shape.get_image(image_bounds, 1.0, 1.0) as thumbnail:
        # Save the image to disk in PNG format.
        thumbnail.save("apperance_bounds.png", slides.ImageFormat.PNG)
```

## **الأسئلة المتكررة**

**ما هي تنسيقات الصور التي يمكن استخدامها عند حفظ مصغرات الأشكال؟**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/python-net/aspose.slides/imageformat/)، وغيرها. يمكن أيضًا [تصدير الأشكال كـ SVG متجهي](https://reference.aspose.com/slides/python-net/aspose.slides/shape/write_as_svg/) عن طريق حفظ محتوى الشكل كملف SVG.

**ما الفرق بين حدود SHAPE وAPPEARANCE عند تصيير المصغرة؟**

`SHAPE` يستخدم هندسة الشكل؛ `APPEARANCE` يأخذ [التأثيرات البصرية](/slides/ar/python-net/shape-effect/) (الظلال، التوهجات، إلخ) في الاعتبار.

**ماذا يحدث إذا تم وضع علامة على شكل ك مخفي؟ هل سيظل يُصوَر كمصغرة؟**

يبقى الشكل المخفي جزءًا من النموذج ويمكن تصييره؛ علامة الإخفاء تؤثر على عرض الشرائح فقط ولا تمنع إنشاء صورة الشكل.

**هل يتم دعم الأشكال الجماعية، المخططات، SmartArt، وغيرها من الكائنات المعقدة؟**

نعم. أي كائن يُمثل كـ [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) (بما في ذلك [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/)، [Chart](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/)، و[SmartArt](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/)) يمكن حفظه كمصغرة أو كملف SVG.

**هل تؤثر الخطوط المثبتة على النظام على جودة المصغرات للأشكال النصية؟**

نعم. يجب عليك [توفير الخطوط المطلوبة](/slides/ar/python-net/custom-font/) (أو [تهيئة استبدال الخطوط](/slides/ar/python-net/font-substitution/)) لتجنب الفواصل غير المرغوبة وإعادة تدفق النص.