---
title: تغيير حجم الأشكال على شرائح العرض باستخدام Python عبر Java
type: docs
weight: 110
url: /ar/python-java/re-sizing-shapes-on-slide/
keywords:
- تحجيم الشكل
- تغيير حجم الشكل
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Java
- Aspose.Slides
description: "قم بسهولة بتغيير حجم الأشكال على شرائح PowerPoint وOpenDocument باستخدام Aspose.Slides لـ Python عبر Java—قم بأتمتة تعديل تخطيط الشرائح وزيادة الإنتاجية."
---
## **نظرة عامة**

إحدى الأسئلة الشائعة من عملاء Aspose.Slides for Python via Java هي كيفية تغيير حجم الأشكال بحيث، عندما يتغير حجم الشريحة، لا يتم قطع البيانات. توضح هذه المقالة التقنية القصيرة كيفية القيام بذلك.

## **تغيير حجم الأشكال**

لمنع تشويه الأشكال عندما يتغير حجم الشريحة، قم بتحديث موقع كل شكل وأبعادها لتتوافق مع تخطيط الشريحة الجديد.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeType, SlideSizeScaleType, SlideOrientation

# تحميل ملف العرض.
presentation = Presentation("sample.ppt")
try:
    # الحصول على حجم الشريحة الأصلي.
    current_height = presentation.getSlideSize().getSize().getHeight()
    current_width = presentation.getSlideSize().getSize().getWidth()

    # تغيير حجم الشريحة دون تعديل مقياس الأشكال الموجودة.
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale)

    # الحصول على حجم الشريحة الجديد.
    new_height = presentation.getSlideSize().getSize().getHeight()
    new_width = presentation.getSlideSize().getSize().getWidth()

    height_ratio = new_height / current_height
    width_ratio = new_width / current_width

    # تغيير حجم وإعادة موضع الأشكال في كل شريحة.
    for slide in presentation.getSlides():
        for shape in slide.getShapes():

            # تعديل مقياس حجم الشكل.
            shape.setHeight(shape.getHeight() * height_ratio)
            shape.setWidth(shape.getWidth() * width_ratio)

            # تعديل مقياس موضع الشكل.
            shape.setY(shape.getY() * height_ratio)
            shape.setX(shape.getX() * width_ratio)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}} 
لا تحتاج الجداول إلى معالجة خاصة: ضبط عرض وارتفاع الجدول يعيد تحجيم أعمدته وصفوفه بالتناسب، لذا فإن تحجيم ارتفاعات الصفوف وعرض الأعمدة مرة أخرى سيطبق النسبة مرتين.
{{% /alert %}} 

الكود أعلاه يغيّر فقط الأشكال على الشرائح. تحتفظ الشرائح الرئيسية وشرائح التخطيط بأشكالها الخاصة، لذا قم بتحجيمها أيضًا عندما تريد أن يتبع العرض الكامل حجم الشريحة الجديد:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeType, SlideSizeScaleType, SlideOrientation

presentation = Presentation("sample.pptx")
try:
    # الحصول على حجم الشريحة الأصلي.
    current_height = presentation.getSlideSize().getSize().getHeight()
    current_width = presentation.getSlideSize().getSize().getWidth()

    # تغيير حجم الشريحة دون تعديل مقياس الأشكال الحالية.
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale)
    # presentation.getSlideSize().setOrientation(SlideOrientation.Portrait)

    # الحصول على حجم الشريحة الجديد.
    new_height = presentation.getSlideSize().getSize().getHeight()
    new_width = presentation.getSlideSize().getSize().getWidth()

    height_ratio = new_height / current_height
    width_ratio = new_width / current_width

    for master in presentation.getMasters():
        for shape in master.getShapes():
            # تحجيم حجم الشكل.
            shape.setHeight(shape.getHeight() * height_ratio)
            shape.setWidth(shape.getWidth() * width_ratio)

            # تحجيم موضع الشكل.
            shape.setY(shape.getY() * height_ratio)
            shape.setX(shape.getX() * width_ratio)

        for layout_slide in master.getLayoutSlides():
            for shape in layout_slide.getShapes():
                # تحجيم حجم الشكل.
                shape.setHeight(shape.getHeight() * height_ratio)
                shape.setWidth(shape.getWidth() * width_ratio)

                # تحجيم موضع الشكل.
                shape.setY(shape.getY() * height_ratio)
                shape.setX(shape.getX() * width_ratio)

    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            # تحجيم حجم الشكل.
            shape.setHeight(shape.getHeight() * height_ratio)
            shape.setWidth(shape.getWidth() * width_ratio)

            # تحجيم موضع الشكل.
            shape.setY(shape.getY() * height_ratio)
            shape.setX(shape.getX() * width_ratio)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **الأسئلة الشائعة**

**لماذا تتشوه الأشكال أو تُقطع بعد تغيير حجم الشريحة؟**

عند تغيير حجم الشريحة، تحتفظ الأشكال بموقعها وحجمها الأصليين ما لم يتم تغيير المقياس صراحةً. قد يؤدي ذلك إلى قص المحتوى أو تشويه الأشكال.

**هل يعمل الكود المقدم مع جميع أنواع الأشكال؟**

نعم. ضبط الارتفاع والعرض يعمل مع مربعات النص والصور والمخططات والجداول على حد سواء.

**كيف أقوم بتغيير حجم الجداول عند تغيير حجم الشريحة؟**

قم بتحجيم شكل الجدول نفسه، تمامًا مثل أي شكل آخر. تتبع صفوفه وأعمدته النسبة بشكل متناسب، لذا لا تقم بتحجيمها مرة أخرى لاحقًا.

**هل سيعمل هذا التحجيم على الشرائح الرئيسية وشرائح التخطيط؟**

نعم، ولكن يجب عليك أيضًا التجول عبر [Presentation.getMasters](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#getMasters) و[Presentation.getLayoutSlides](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#getLayoutSlides) وتطبيق نفس منطق التحجيم على أشكالها لضمان التناسق عبر العرض التقديمي.

**هل يمكنني تغيير اتجاه الشريحة (عمودي/عرضي) مع التحجيم؟**

نعم. يمكنك استخدام [SlideSize.setOrientation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slidesize/#setOrientation) لتغيير الاتجاه. تأكد من ضبط منطق التحجيم بما يتناسب للحفاظ على التخطيط.

**هل هناك حد لحجم الشريحة الذي يمكنني تحديده؟**

يدعم Aspose.Slides الأحجام المخصصة، ولكن الأحجام الكبيرة جدًا قد تؤثر على الأداء أو التوافق مع بعض إصدارات PowerPoint.

**كيف يمكنني منع تشويه الأشكال ذات نسبة العرض إلى الارتفاع الثابتة؟**

يمكنك التحقق من طريقة [getAspectRatioLocked](https://reference.aspose.com/slides/ar/python-java/aspose.slides/autoshapelock/#getAspectRatioLocked) لقفل الشكل قبل التحجيم. إذا كان مقفلًا، اضبط العرض أو الارتفاع بالتناسب بدلاً من تحجيمهما بشكل منفصل.