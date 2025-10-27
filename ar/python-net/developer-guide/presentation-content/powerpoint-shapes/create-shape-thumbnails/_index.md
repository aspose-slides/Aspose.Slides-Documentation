---
title: إنشاء صور مصغرة لأشكال العروض التقديمية في بايثون
linktitle: مصغرات الشكل
type: docs
weight: 70
url: /ar/python-net/developer-guide/presentation-content/powerpoint-shapes/create-shape-thumbnails/
keywords:
- صورة مصغرة للشكل
- صورة الشكل
- عرض الشكل
- تصيير الشكل
- PowerPoint
- عرض تقديمي
- Python
- Aspose.Slides
description: "توليد صور مصغرة عالية الجودة للأشكال من شرائح PowerPoint وOpenDocument باستخدام Aspose.Slides للبايثون عبر .NET – إنشاء وتصدير صور مصغرة للعرض التقديمي بسهولة."
---

## **المقدمة**

يُستخدم Aspose.Slides للبايثون عبر .NET لإنشاء ملفات عروض تقديمية حيث كل صفحة هي شريحة. يمكنك عرض هذه الشرائح في Microsoft PowerPoint عبر فتح ملف العرض التقديمي. ومع ذلك، قد يحتاج المطورون أحيانًا إلى عرض صور الأشكال بشكل منفصل في عارض صور. في مثل هذه الحالات، يمكن لـ Aspose.Slides توليد صور مصغرة لأشكال الشرائح. يوضح هذا المقال كيفية استخدام هذه الميزة.

## **إنشاء صور مصغرة للأشكال من الشرائح**

عندما تحتاج إلى معاينة كائن معين بدلاً من الشريحة entière، يمكنك تصيير صورة مصغرة لشكل فردي. يسمح Aspose.Slides لك بتصدير أي شكل إلى صورة، مما يسهل إنشاء معاينات خفيفة الوزن أو أيقونات أو أصول لمعالجة لاحقة.

لإنشاء صورة مصغرة من أي شكل:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. الحصول على مرجع إلى شريحة عبر معرّفها أو فهرسها.
1. الحصول على مرجع إلى شكل على تلك الشريحة.
1. تصيير صورة المصغرة للشكل.
1. حفظ صورة المصغرة بالتنسيق المطلوب.

المثال أدناه يولد صورة مصغرة لشكل.

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

## **إنشاء صور مصغرة بمعامل تحجيم مخصص**

توضح هذه القسم كيفية إنشاء صور مصغرة للأشكال باستخدام معامل تحجيم يحدده المستخدم في Aspose.Slides. من خلال التحكم في المقياس، يمكنك ضبط حجم الصورة المصغرة لتناسب المعاينات أو التصدير أو الشاشات عالية الدقة.

لإنشاء صورة مصغرة لأي شكل على شريحة:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. الحصول على شريحة عبر معرّفها أو فهرسها.
1. الحصول على الشكل الهدف على تلك الشريحة.
1. تصيير صورة المصغرة للشكل باستخدام المقياس المحدد.
1. حفظ صورة المصغرة بالتنسيق المطلوب.

المثال أدناه يولد صورة مصغرة بمعامل تحجيم يحدده المستخدم.

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

## **إنشاء صور مصغرة باستخدام حدود مظهر الشكل**

توضح هذه القسم كيفية إنشاء صورة مصغرة ضمن حدود مظهر الشكل. يأخذ ذلك جميع تأثيرات الشكل في الاعتبار. تُقيد الصورة المصغرة الناتجة بحدود الشريحة.

لإنشاء صورة مصغرة لأي شكل شريحة داخل حدود مظهره:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. الحصول على شريحة عبر معرّفها أو فهرسها.
1. الحصول على الشكل الهدف على تلك الشريحة.
1. تصيير صورة المصغرة للشكل باستخدام الحدود المحددة.
1. حفظ صورة المصغرة بالتنسيق المطلوب.

المثال أدناه ينشئ صورة مصغرة بحدود يحددها المستخدم.

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

## **الأسئلة الشائعة**

**ما هي تنسيقات الصور التي يمكن استخدامها عند حفظ مصغرات الأشكال؟**

[PNG، JPEG، BMP، GIF، TIFF](https://reference.aspose.com/slides/python-net/aspose.slides/imageformat/)، وغيرها. يمكن أيضًا [تصدير الأشكال كـ SVG متجه](https://reference.aspose.com/slides/python-net/aspose.slides/shape/write_as_svg/) عبر حفظ محتوى الشكل كـ SVG.

**ما الفرق بين حدود SHAPE وAPPEARANCE عند تصيير صورة مصغرة؟**

`SHAPE` يستخدم هندسة الشكل؛ `APPEARANCE` يأخذ [التأثيرات البصرية](/slides/ar/python-net/shape-effect/) (الظلال، التوهج، إلخ) في الاعتبار.

**ماذا يحدث إذا تم تعليم الشكل بأنه مخفي؟ هل سيظل يُصوّر كصورة مصغرة؟**

يبقى الشكل المخفي جزءًا من النموذج ويمكن تصييره؛ علم الإخفاء يؤثر على عرض الشريحة في العرض التقديمي لكنه لا يمنع توليد صورة الشكل.

**هل تدعم الأشكال الجماعية، المخططات، SmartArt، وغيرها من الكائنات المعقدة؟**

نعم. أي كائن يُمثَّل كـ [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) (بما في ذلك [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/)، [Chart](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/)، و[SmartArt](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/)) يمكن حفظه كصورة مصغرة أو كـ SVG.

**هل تؤثر الخطوط المثبتة على النظام على جودة مصغرات الأشكال النصية؟**

نعم. يجب عليك [توفير الخطوط المطلوبة](/slides/ar/python-net/custom-font/) (أو [تهيئة استبدال الخطوط](/slides/ar/python-net/font-substitution/)) لتجنب الفواصل غير المرغوب فيها وإعادة تدفق النص.