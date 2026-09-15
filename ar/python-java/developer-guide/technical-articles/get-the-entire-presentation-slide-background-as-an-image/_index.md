---
title: استخراج خلفية الشريحة بالكامل من العرض التقديمي كصورة
linktitle: خلفية الشريحة بالكامل
type: docs
weight: 95
url: /ar/python-java/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- خلفية الشريحة
- الخلفية النهائية
- استخراج الخلفية
- الخلفية الكاملة
- الخلفية إلى صورة
- خلفية PPT
- خلفية PPTX
- خلفية ODP
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Java
- Aspose.Slides
description: "استخراج خلفيات الشرائح الكاملة كصور من عروض PowerPoint و OpenDocument باستخدام Aspose.Slides for Python عبر Java، مما يبسط سير العمل البصري."
---
## **نظرة عامة**

في عروض PowerPoint، يمكن أن يتكوّن خلفية الشريحة من عدة عناصر، بما في ذلك صورة خلفية الشريحة، سمة العرض، نظام الألوان، والكائنات الموضوعة على شريحة الماستر أو شريحة التخطيط.

توضح هذه المقالة كيفية استخراج خلفية الشريحة بالكامل كصورة باستخدام Aspose.Slides for Python via Java. نظراً لعدم وجود طريقة واحدة لهذا الغرض، تتضمن العملية استنساخ الشريحة المحددة إلى عرض تقديمي مؤقت، إزالة الأشكال من الشريحة، ثم تحويل خلفية الشريحة الناتجة إلى صورة.

## **الحصول على خلفية الشريحة بالكامل**

لا يوفر Aspose.Slides for Python via Java طريقة بسيطة لاستخراج خلفية جميع شرائح العرض كصورة، لكن يمكنك اتباع الخطوات أدناه للقيام بذلك:

1. حمّل العرض باستخدام فئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/).
2. احصل على حجم الشريحة من العرض.
3. اختر شريحة.
4. أنشئ عرضاً تقديمياً مؤقتاً.
5. حدد نفس حجم الشريحة في العرض المؤقت.
6. استنسخ الشريحة المحددة إلى العرض المؤقت.
7. احذف الأشكال من الشريحة المستنسخة.
8. حوّل الشريحة المستنسخة إلى صورة.

يوضح مثال الشيفرة التالي كيفية استخراج خلفية جميع شرائح العرض كصورة.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideSizeScaleType, ImageFormat

slide_index = 0
image_scale = 1.0

presentation = Presentation("sample.pptx")
try:
    slide_size = presentation.getSlideSize().getSize()
    slide = presentation.getSlides().get_Item(slide_index)

    temp_presentation = Presentation()
    try:
        slide_width = jpype.JFloat(slide_size.getWidth())
        slide_height = jpype.JFloat(slide_size.getHeight())
        temp_presentation.getSlideSize().setSize(slide_width, slide_height, SlideSizeScaleType.DoNotScale)

        cloned_slide = temp_presentation.getSlides().addClone(slide)
        cloned_slide.getShapes().clear()

        background = cloned_slide.getImage(image_scale, image_scale)
        try:
            background.save("output.png", ImageFormat.Png)
        finally:
            background.dispose()
    finally:
        temp_presentation.dispose()
finally:
    presentation.dispose()
```

## **الأسئلة المتكررة**

**هل سيتم الحفاظ على التدرجات المعقدة أو القوام أو ملء الصور من الشريحة الأساسية في صورة الخلفية الناتجة؟**

نعم. يقوم Aspose.Slides بمعالجة التدرجات، والملء بالصور، والقوام المعرفة على الشريحة أو التخطيط أو الماستر. إذا كنت بحاجة إلى عزل المظهر عن الماسترات الموروثة، قم بـ[تعيين خلفية مخصصة](/slides/ar/python-java/presentation-background/) على الشريحة الحالية قبل التصدير.

**هل يمكنني إضافة علامة مائية إلى صورة الخلفية الناتجة قبل حفظها؟**

نعم. يمكنك [إضافة علامة مائية](/slides/ar/python-java/watermark/) كشكل أو صورة على [نسخة من الشريحة](/slides/ar/python-java/clone-slides/) (موضوعة خلف المحتوى الآخر) ثم التصدير. يتيح لك ذلك إنشاء صورة خلفية مع دمج العلامة المائية.

**هل يمكنني الحصول على الخلفية لتخطيط أو ماستر معين دون ربطها بشريحة موجودة؟**

نعم. وصول إلى الماستر أو التخطيط المطلوب، وتطبيقه على [شريحة مؤقتة](/slides/ar/python-java/clone-slides/) بالحجم اللازم، ثم تصدير تلك الشريحة للحصول على الخلفية المستخلصة من ذلك التخطيط أو الماستر.

**هل توجد قيود ترخيص تؤثر على تصدير الصور؟**

ميزات التصيير متاحة بالكامل مع [رخصة صالحة](/slides/ar/python-java/licensing/). في وضع التقييم، قد يتضمن الناتج قيوداً مثل العلامة المائية. فعّل الرخصة مرة واحدة لكل عملية قبل تشغيل تصديرات الدفعة.