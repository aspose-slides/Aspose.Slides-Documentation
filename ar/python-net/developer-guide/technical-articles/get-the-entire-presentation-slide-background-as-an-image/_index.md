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
- تحويل الخلفية إلى صورة
- PowerPoint
- OpenDocument
- عرض تقديمي
- PPT
- PPTX
- ODP
- Python
- Aspose.Slides
description: "استخراج خلفيات الشرائح الكاملة كصور من عروض PowerPoint وOpenDocument باستخدام Aspose.Slides for Python عبر .NET، لتبسيط سير العمل البصري."
---

## **احصل على خلفية الشريحة بالكامل**

في عروض PowerPoint التقديمية، يمكن أن تتكون خلفية الشريحة من عدة عناصر. بالإضافة إلى الصورة المعينة كـ [خلفية الشريحة](/slides/ar/python-net/presentation-background/)، يمكن أن يتأثر الخلفية النهائية بموضوع العرض، مخطط الألوان، والأشكال الموضوعة على الشريحة الرئيسية وشريحة التخطيط.

Aspose.Slides for Python لا توفر طريقة بسيطة لاستخراج خلفية الشريحة بالكامل كصورة، ولكن يمكنك اتباع الخطوات التالية للقيام بذلك:
1. حمّل العرض باستخدام الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. احصل على حجم الشريحة من العرض.
1. اختر شريحة.
1. أنشئ عرضًا مؤقتًا.
1. عيّن نفس حجم الشريحة في العرض المؤقت.
1. استنسخ الشريحة المحددة إلى العرض المؤقت.
1. احذف الأشكال من الشريحة المستنسخة.
1. حوِّل الشريحة المستنسخة إلى صورة.

يستخرج مثال الشيفرة التالي خلفية الشريحة بالكامل كصورة.
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


## **الأسئلة الشائعة**

**هل سيتم الحفاظ على التدرجات المعقدة أو القوام أو تعبئة الصور من الشريحة الرئيسية في صورة الخلفية الناتجة؟**

نعم. تقوم Aspose.Slides بإنشاء التدرجات وتعبئة الصور والقوام المحددة على الشريحة أو التخطيط أو الرئيسي. إذا كنت بحاجة إلى عزل المظهر عن الرؤوس الموروثة، [قم بتعيين خلفية خاصة](/slides/ar/python-net/presentation-background/) على الشريحة الحالية قبل التصدير.

**هل يمكنني إضافة علامة مائية إلى صورة الخلفية الناتجة قبل حفظها؟**

نعم. يمكنك [إضافة علامة مائية](/slides/ar/python-net/watermark/) كشكل أو صورة على نسخة [عمل من الشريحة](/slides/ar/python-net/clone-slides/) (موضوعة خلف المحتوى الآخر) ثم تصديرها. هذا يتيح لك إنشاء صورة خلفية مدمجة مع العلامة المائية.

**هل يمكنني الحصول على الخلفية لتخطيط أو رئيس معين دون ربطها بشريحة موجودة؟**

نعم. ادخل إلى الرئيسي أو التخطيط المطلوب، وطبقه على [شريحة مؤقتة](/slides/ar/python-net/clone-slides/) بالحجم المطلوب، ثم صدّر تلك الشريحة للحصول على الخلفية المستمدة من ذلك التخطيط أو الرئيسي.

**هل هناك قيود ترخيص تؤثر على تصدير الصور؟**

ميزات العرض متاحة بالكامل مع [رخصة صالحة](/slides/ar/python-net/licensing/). في وضع التقييم، قد يتضمن الناتج قيودًا مثل العلامة المائية. فعّل الرخصة مرة واحدة لكل عملية قبل تشغيل عمليات التصدير الدفعي.