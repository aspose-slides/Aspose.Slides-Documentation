---
title: الحصول على خلفية الشريحة بالكامل من عرض تقديمي كصورة
linktitle: خلفية الشريحة بالكامل
type: docs
weight: 95
url: /ar/python-net/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- شريحة
- خلفية
- خلفية الشريحة
- الخلفية النهائية
- الخلفية إلى صورة
- PowerPoint
- OpenDocument
- عرض تقديمي
- PPT
- PPTX
- ODP
- Python
- Aspose.Slides
description: استخراج خلفيات الشرائح الكاملة كصور من عروض PowerPoint وOpenDocument باستخدام Aspose.Slides للغة Python عبر .NET، وتبسيط سير العمل البصري.
---

## **الحصول على خلفية الشريحة بالكامل**

في عروض PowerPoint التقديمية، يمكن أن تتكون خلفية الشريحة من العديد من العناصر. بالإضافة إلى الصورة المحددة كـ[خلفية الشريحة](/slides/ar/python-net/presentation-background/)، يمكن أن تتأثر الخلفية النهائية بموضوع العرض، نظام الألوان، والأشكال الموضوعة على الشريحة الأساسية وشريحة التخطيط.

لا يوفر Aspose.Slides للغة Python طريقة بسيطة لاستخراج خلفية الشريحة الكاملة في العرض التقديمي كصورة، ولكن يمكنك اتباع الخطوات أدناه للقيام بذلك:
1. تحميل العرض التقديمي باستخدام فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. الحصول على حجم الشريحة من العرض التقديمي.
3. اختيار شريحة.
4. إنشاء عرض تقديمي مؤقت.
5. تعيين نفس حجم الشريحة في العرض التقديمي المؤقت.
6. استنساخ الشريحة المختارة إلى العرض التقديمي المؤقت.
7. حذف الأشكال من الشريحة المستنسخة.
8. تحويل الشريحة المستنسخة إلى صورة.

مثال الكود التالي يستخرج خلفية الشريحة الكاملة في العرض التقديمي كصورة.
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

## **الأسئلة المتكررة**

**هل سيتم الحفاظ على التدرجات المعقدة أو القوام أو ملء الصور من الشريحة الأساسية في صورة الخلفية الناتجة؟**

نعم. يقوم Aspose.Slides بمعالجة التدرجات، والملء بالصور، والملء بالقوام المحددة على الشريحة أو التخطيط أو الشريحة الأساسية. إذا كنت بحاجة إلى عزل المظهر عن الشرائح الأساسية الموروثة، [قم بتعيين خلفية خاصة](/slides/ar/python-net/presentation-background/) على الشريحة الحالية قبل التصدير.

**هل يمكنني إضافة علامة مائية إلى صورة الخلفية الناتجة قبل حفظها؟**

نعم. يمكنك [إضافة علامة مائية](/slides/ar/python-net/watermark/) كشكل أو صورة على نسخة [معملولة من الشريحة](/slides/ar/python-net/clone-slides/) (موضوعة خلف المحتوى الآخر) ثم تصديرها. هذا يتيح لك إنشاء صورة خلفية مع دمج العلامة المائية.

**هل يمكنني الحصول على الخلفية لتخطيط أو شريحة أساسية محددة دون ربطها بشريحة موجودة؟**

نعم. الوصول إلى الشريحة الأساسية أو التخطيط المطلوب، وتطبيقه على [شريحة مؤقتة](/slides/ar/python-net/clone-slides/) بالحجم المطلوب، ثم تصدير تلك الشريحة للحصول على الخلفية المستمدة من ذلك التخطيط أو الشريحة الأساسية.

**هل هناك قيود ترخيص تؤثر على تصدير الصور؟**

ميزات التصيير متاحة بالكامل مع [ترخيص صالح](/slides/ar/python-net/licensing/). في وضع التقييم، قد يتضمن الناتج قيودًا مثل العلامة المائية. فعّل الترخيص مرة واحدة لكل عملية قبل تشغيل تصدير الدُفعات.