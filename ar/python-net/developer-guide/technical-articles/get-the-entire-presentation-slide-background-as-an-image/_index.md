---
title: احصل على خلفية شريحة العرض كاملة كصورة
type: docs
weight: 95
url: /ar/python-net/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- شريحة
- خلفية
- خلفية الشريحة
- الخلفية إلى صورة
- PowerPoint
- PPT
- PPTX
- عرض PowerPoint
- بايثون
- Aspose.Slides for Python
---

في عروض PowerPoint، يمكن أن تتكون خلفية الشريحة من العديد من العناصر. بالإضافة إلى الصورة المخصصة كـ [خلفية الشريحة](/slides/ar/python-net/presentation-background/)، يمكن أن تتأثر الخلفية النهائية بموضوع العرض، ونظام الألوان، والأشكال الموضوعة على الشريحة الرئيسية وشريحة التخطيط.

لا توفر Aspose.Slides for Python طريقة بسيطة لاستخراج خلفية شريحة العرض كاملة كصورة، ولكن يمكنك اتباع الخطوات أدناه للقيام بذلك:
1. قم بتحميل العرض باستخدام فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. احصل على حجم الشريحة من العرض.
1. اختر شريحة.
1. أنشئ عرضًا تقديميًا مؤقتًا.
1. قم بتعيين نفس حجم الشريحة في العرض المؤقت.
1. استنسخ الشريحة المحددة إلى العرض المؤقت.
1. احذف الأشكال من الشريحة المستنسخة.
1. قم بتحويل الشريحة المستنسخة إلى صورة.

مثال الكود التالي يستخرج خلفية شريحة العرض كاملة كصورة.
```py
slide_index = 0
image_scale = 1

with slides.Presentation("sample.pptx") as presentation:
    slide_size = presentation.slide_size.size
    slide = presentation.slides[slide_index]

    with slides.Presentation() as temp_presentation:
        temp_presentation.slide_size.set_size(
            slide_size.width, slide_size.height, slides.SlideSizeScaleType.DO_NOT_SCALE)

        cloned_slide = temp_presentation.slides.add_clone(slide)
        cloned_slide.shapes.clear()

        with cloned_slide.get_image(image_scale, image_scale) as background:
            background.save("output.png", slides.ImageFormat.PNG)
```