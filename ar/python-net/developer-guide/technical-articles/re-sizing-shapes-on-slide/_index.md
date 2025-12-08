---
title: "تحجيم الأشكال في العروض التقديمية باستخدام بايثون"
linktitle: "تحجيم الأشكال"
type: docs
weight: 130
url: /ar/python-net/re-sizing-shapes-on-slide/
keywords:
- "تحجيم الشكل"
- "تغيير حجم الشكل"
- PowerPoint
- OpenDocument
- "عرض تقديمي"
- Python
- Aspose.Slides
description: "قم بتحجيم الأشكال بسهولة على شرائح PowerPoint و OpenDocument باستخدام Aspose.Slides لـ Python عبر .NET — أتمتة تعديل تخطيط الشرائح وتعزيز الإنتاجية."
---

## **نظرة عامة**

إحدى الأسئلة الأكثر شيوعًا من عملاء Aspose.Slides for Python هي كيفية تغيير حجم الأشكال بحيث، عند تغيير حجم الشريحة، لا يتم قص البيانات. يوضح هذا المقال التقني القصير كيفية القيام بذلك.

## **تغيير حجم الأشكال**

لمنع حدوث اختلال في موضع الأشكال عند تغيير حجم الشريحة، قم بتحديث موضع كل شكل وأبعاده لتتوافق مع تخطيط الشريحة الجديد.
```py
import aspose.slides as slides

# تحميل ملف العرض التقديمي.
with slides.Presentation("sample.pptx") as presentation:
    # الحصول على حجم الشريحة الأصلي.
    current_height = presentation.slide_size.size.height
    current_width = presentation.slide_size.size.width

    # تغيير حجم الشريحة دون تعديل مقياس الأشكال الموجودة.
    presentation.slide_size.set_size(slides.SlideSizeType.A4_PAPER, slides.SlideSizeScaleType.DO_NOT_SCALE)

    # الحصول على حجم الشريحة الجديد.
    new_height = presentation.slide_size.size.height
    new_width = presentation.slide_size.size.width

    height_ratio = new_height / current_height
    width_ratio = new_width / current_width

    # تعديل حجم وإعادة موضع الأشكال في كل شريحة.
    for slide in presentation.slides:
        for shape in slide.shapes:
            # تعديل مقياس حجم الشكل.
            shape.height = shape.height * height_ratio
            shape.width = shape.width * width_ratio

            # تعديل مقياس موضع الشكل.
            shape.y = shape.y * height_ratio
            shape.x = shape.x * width_ratio

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


{{% alert color="primary" %}} 
إذا احتوت الشريحة على جدول، فإن الكود أعلاه لن يعمل بشكل صحيح. في هذه الحالة، يجب تغيير حجم كل خلية في الجدول.
{{% /alert %}} 

استخدم الكود التالي على جانبك لتغيير حجم الشرائح التي تحتوي على جداول. بالنسبة للجداول، يُعد ضبط العرض أو الارتفاع حالة خاصة: يجب تعديل ارتفاعات الصفوف الفردية وعروض الأعمدة لتغيير الحجم الكلي للجدول.
```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    # الحصول على حجم الشريحة الأصلي.
    current_height = presentation.slide_size.size.height
    current_width = presentation.slide_size.size.width

    # تغيير حجم الشريحة دون تعديل مقياس الأشكال الموجودة.
    presentation.slide_size.set_size(slides.SlideSizeType.A4_PAPER, slides.SlideSizeScaleType.DO_NOT_SCALE)

    # الحصول على حجم الشريحة الجديد.
    new_height = presentation.slide_size.size.height
    new_width = presentation.slide_size.size.width

    height_ratio = new_height / current_height
    width_ratio = new_width / current_width

    for master in presentation.masters:
        for shape in master.shapes:
            # تعديل مقياس حجم الشكل.
            shape.height = shape.height * height_ratio
            shape.width = shape.width * width_ratio

            # تعديل مقياس موضع الشكل.
            shape.y = shape.y * height_ratio
            shape.x = shape.x * width_ratio

        for layout_slide in master.layout_slides:
            for shape in layout_slide.shapes:
                # تعديل مقياس حجم الشكل.
                shape.height = shape.height * height_ratio
                shape.width = shape.width * width_ratio

                # تعديل مقياس موضع الشكل.
                shape.y = shape.y * height_ratio
                shape.x = shape.x * width_ratio

    for slide in presentation.slides:
        for shape in slide.shapes:
            # تعديل مقياس حجم الشكل.
            shape.height = shape.height * height_ratio
            shape.width = shape.width * width_ratio

            # تعديل مقياس موضع الشكل.
            shape.y = shape.y * height_ratio
            shape.x = shape.x * width_ratio

            if type(shape) is slides.Table:
                for row in shape.rows:
                    row.minimal_height = row.minimal_height * height_ratio
                for column in shape.columns:
                    column.width = column.width * width_ratio

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **الأسئلة الشائعة**

**لماذا تتشوه الأشكال أو يتم قصها بعد تعديل حجم الشريحة؟**

عند تعديل حجم الشريحة، تحتفظ الأشكال بموقعها وحجمها الأصليين ما لم يتم تغيير المقياس بشكل صريح. يمكن أن يؤدي ذلك إلى قص المحتوى أو اختلال موضع الأشكال.

**هل يعمل الكود المقدم لجميع أنواع الأشكال؟**

تعمل المثال الأساسي لمعظم أنواع الأشكال (مربعات النص، الصور، المخططات، إلخ). ومع ذلك، بالنسبة للجداول، تحتاج إلى معالجة الصفوف والأعمدة بشكل منفصل، إذ يتم تحديد ارتفاع وعرض الجدول بأبعاد الخلايا الفردية.

**كيف يمكنني تغيير حجم الجداول عند تعديل حجم الشريحة؟**

يجب عليك المرور عبر جميع صفوف وأعمدة الجدول وتغيير ارتفاعها وعرضها بشكل متناسب، كما هو موضح في مثال الكود الثاني.

**هل سيعمل هذا التغيير في الحجم على الشرائح الرئيسية وشُرائح التخطيط؟**

نعم، لكن يجب عليك أيضًا المرور عبر [الشرائح الرئيسية](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/masters/) و[شرائح التخطيط](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/layout_slides/) وتطبيق نفس منطق التحجيم على أشكالها لضمان التناسق عبر العرض التقديمي بأكمله.

**هل يمكنني تغيير اتجاه الشريحة (عمودي/أفقي) مع تغيير الحجم؟**

نعم. يمكنك استخدام [presentation.slide_size.orientation](https://reference.aspose.com/slides/python-net/aspose.slides/islidesize/orientation/) لتغيير الاتجاه. تأكد من ضبط منطق التحجيم وفقًا لذلك للحفاظ على التخطيط.

**هل هناك حد لحجم الشريحة الذي يمكنني تعيينه؟**

يدعم Aspose.Slides أحجامًا مخصصة، لكن الأحجام الكبيرة جدًا قد تؤثر على الأداء أو التوافق مع بعض إصدارات PowerPoint.

**كيف يمكنني منع تشوه الأشكال ذات نسبة العرض إلى الارتفاع الثابتة؟**

يمكنك فحص الخاصية `aspect_ratio_locked` للشكل قبل التحجيم. إذا كانت مقفلة، عدّل العرض أو الارتفاع بشكل متناسب بدلاً من تحجيمهما بشكل منفصل.