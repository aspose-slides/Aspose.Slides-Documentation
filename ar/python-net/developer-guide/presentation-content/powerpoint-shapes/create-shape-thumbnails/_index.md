---
title: إنشاء صور مصغرة لأشكال العروض التقديمية في بايثون
linktitle: صور مصغرة للأشكال
type: docs
weight: 70
url: /ar/python-net/create-shape-thumbnails/
keywords:
- shape thumbnail
- shape image
- render shape
- shape rendering
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "إنشاء صور مصغرة عالية الجودة للأشكال من شرائح PowerPoint وOpenDocument باستخدام Aspose.Slides for Python عبر .NET – بسهولة إنشاء وتصدير صور مصغرة للعرض التقديمي."
---

## **المقدمة**

يُستخدم Aspose.Slides for Python عبر .NET لإنشاء ملفات عرض تقديمي يكون كل صفحة فيها شريحة. يمكنك عرض هذه الشرائح في Microsoft PowerPoint عن طريق فتح ملف العرض التقديمي. مع ذلك، قد يحتاج المطورون أحيانًا إلى مشاهدة صور الأشكال منفصلًا في عارض صور. في هذه الحالات، يمكن لـ Aspose.Slides إنشاء صور مصغرة لأشكال الشرائح. توضح هذه المقالة كيفية استخدام هذه الميزة.

## **إنشاء صور مصغرة للأشكال من الشرائح**

عند الحاجة إلى معاينة لكائن محدد بدلاً من الشريحة بأكملها، يمكنك إنشاء صورة مصغرة لشكل فردي. يتيح لك Aspose.Slides تصدير أي شكل إلى صورة، مما يسهل إنشاء معاينات خفيفة الوزن أو أيقونات أو أصول للمعالجة اللاحقة.

لإنشاء صورة مصغرة من أي شكل:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. الحصول على مرجع إلى شريحة عبر معرّفها أو فهرسها.
1. الحصول على مرجع إلى شكل على تلك الشريحة.
1. إنشاء صورة مصغرة للشكل.
1. حفظ الصورة المصغرة بالصيغة المطلوبة.

المثال أدناه ينشئ صورة مصغرة لشكل.

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

يُظهر هذا القسم كيفية إنشاء صور مصغرة للأشكال بمعامل تحجيم يُحدده المستخدم في Aspose.Slides. من خلال التحكم في التحجيم، يمكنك ضبط حجم الصورة المصغرة لتناسب المعاينات أو الصادرات أو الشاشات ذات الكثافة العالية DPI.

لإنشاء صورة مصغرة لأي شكل على شريحة:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. الحصول على شريحة عبر معرّفها أو فهرسها.
1. الحصول على الشكل المستهدف على تلك الشريحة.
1. إنشاء صورة مصغرة للشكل بالتحجيم المحدد.
1. حفظ الصورة المصغرة بالصيغة المطلوبة.

المثال أدناه ينشئ صورة مصغرة بمعامل تحجيم يحدده المستخدم.

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

يُظهر هذا القسم كيفية إنشاء صورة مصغرة ضمن حدود مظهر الشكل. يأخذ ذلك جميع تأثيرات الشكل في الاعتبار. يتم تقييد الصورة المصغرة الناتجة بحدود الشريحة.

لإنشاء صورة مصغرة لأي شكل شريحة ضمن حدود مظهره:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. الحصول على شريحة عبر معرّفها أو فهرسها.
1. الحصول على الشكل المستهدف على تلك الشريحة.
1. إنشاء صورة مصغرة للشكل بالحدود المحددة.
1. حفظ الصورة المصغرة بالصيغة المطلوبة.

المثال أدناه يُنشئ صورة مصغرة بحدود يحددها المستخدم.

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

**ما هي صيغ الصور التي يمكن استخدامها عند حفظ صور مصغرة للأشكال؟**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/python-net/aspose.slides/imageformat/)، وغيرها. يمكن أيضًا [تصدير الأشكال كـ SVG متجهي](https://reference.aspose.com/slides/python-net/aspose.slides/shape/write_as_svg/) بحفظ محتوى الشكل كـ SVG.

**ما الفرق بين حدود SHAPE و APPEARANCE عند إنشاء صورة مصغرة؟**

`SHAPE` يستخدم هندسة الشكل؛ `APPEARANCE` يأخذ [التأثيرات البصرية](/slides/ar/python-net/shape-effect/) (الظلال، التوهج، إلخ) في الاعتبار.

**ماذا يحدث إذا تم وضع علامة على شكل كـ مخفي؟ هل سيظل يُنشئ صورة مصغرة له؟**

يبقى الشكل المخفي جزءًا من النموذج ويمكن إنشاء صورته؛ تؤثر علامة الإخفاء فقط على عرض الشرائح ولا تمنع إنشاء صورة الشكل.

**هل تدعم الأشكال الجماعية، المخططات، SmartArt، والكائنات المعقدة الأخرى؟**

نعم. أي كائن يمثل كـ [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) (بما في ذلك [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/)، [Chart](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/)، و[SmartArt](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/)) يمكن حفظه كصورة مصغرة أو كـ SVG.

**هل تؤثر الخطوط المثبتة على النظام على جودة الصور المصغرة لأشكال النص؟**

نعم. يجب عليك [توفير الخطوط المطلوبة](/slides/ar/python-net/custom-font/) (أو [تكوين بدائل الخطوط](/slides/ar/python-net/font-substitution/)) لتجنب الانتقالات غير المرغوبة وإعادة تدفق النص.