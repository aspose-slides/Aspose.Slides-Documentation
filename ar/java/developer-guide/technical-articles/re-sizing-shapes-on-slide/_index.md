---
title: تغيير حجم الأشكال على شرائح العرض التقديمي
type: docs
weight: 110
url: /ar/java/re-sizing-shapes-on-slide/
keywords:
- تغيير حجم الشكل
- تعديل حجم الشكل
- PowerPoint
- OpenDocument
- عرض تقديمي
- Java
- Aspose.Slides
description: "قم بسهولة بإعادة تحجيم الأشكال على شرائح PowerPoint وOpenDocument باستخدام Aspose.Slides لـ Java — أتمتة تعديل تخطيط الشرائح وزيادة الإنتاجية."
---

## **نظرة عامة**

أحد أكثر الأسئلة شيوعًا من عملاء Aspose.Slides for Java هو كيفية تغيير حجم الأشكال بحيث لا يتم قطع البيانات عندما يتغير حجم الشريحة. يوضح هذا المقال التقني القصير كيفية القيام بذلك.

## **تغيير حجم الأشكال**

لمنع حدوث اختلال في محاذاة الأشكال عندما يتغير حجم الشريحة، قم بتحديث موضع كل شكل وأبعاده لتتوافق مع تخطيط الشريحة الجديد.
```java
// تحميل ملف العرض التقديمي.
Presentation presentation = new Presentation("sample.ppt");
try {
    // الحصول على حجم الشريحة الأصلي.
    float currentHeight = (float) presentation.getSlideSize().getSize().getHeight();
    float currentWidth = (float) presentation.getSlideSize().getSize().getWidth();

    // تغيير حجم الشريحة دون تحجيم الأشكال الموجودة.
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);

    // الحصول على حجم الشريحة الجديد.
    float newHeight = (float) presentation.getSlideSize().getSize().getHeight();
    float newWidth = (float) presentation.getSlideSize().getSize().getWidth();

    float heightRatio = newHeight / currentHeight;
    float widthRatio = newWidth / currentWidth;

    // تعديل حجم وإعادة وضع الأشكال على كل شريحة.
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            
            // تحجيم حجم الشكل.
            shape.setHeight(shape.getHeight() * heightRatio);
            shape.setWidth(shape.getWidth() * widthRatio);

            // تحجيم موضع الشكل.
            shape.setY(shape.getY() * heightRatio);
            shape.setX(shape.getX() * widthRatio);
        }
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```


{{% alert color="primary" %}} 
إذا احتوت الشريحة على جدول، فإن الشيفرة أعلاه لن تعمل بشكل صحيح. في هذه الحالة، يجب تغيير حجم كل خلية في الجدول.
{{% /alert %}} 

استخدم الشيفرة التالية على جانبك لتغيير حجم الشرائح التي تحتوي على جداول. بالنسبة للجداول، يُعد ضبط العرض أو الارتفاع حالة خاصة: يجب تعديل ارتفاعات الصفوف الفردية وعرض الأعمدة لتغيير الحجم الإجمالي للجدول.
```java
Presentation presentation = new Presentation("sample.pptx");
try {
    // الحصول على حجم الشريحة الأصلي.
    float currentHeight = (float) presentation.getSlideSize().getSize().getHeight();
    float currentWidth = (float) presentation.getSlideSize().getSize().getWidth();

    // تغيير حجم الشريحة دون تحجيم الأشكال الموجودة.
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    // presentation.getSlideSize().setOrientation(SlideOrientation.Portrait);

    // الحصول على حجم الشريحة الجديد.
    float newHeight = (float) presentation.getSlideSize().getSize().getHeight();
    float newWidth = (float) presentation.getSlideSize().getSize().getWidth();

    float heightRatio = newHeight / currentHeight;
    float widthRatio = newWidth / currentWidth;

    for (IMasterSlide master : presentation.getMasters()) {
        for (IShape shape : master.getShapes()) {
            // تحجيم حجم الشكل.
            shape.setHeight(shape.getHeight() * heightRatio);
            shape.setWidth(shape.getWidth() * widthRatio);

            // تحجيم موضع الشكل.
            shape.setY(shape.getY() * heightRatio);
            shape.setX(shape.getX() * widthRatio);
        }

        for (ILayoutSlide layoutSlide : master.getLayoutSlides()) {
            for (IShape shape : layoutSlide.getShapes()) {
                // تحجيم حجم الشكل.
                shape.setHeight(shape.getHeight() * heightRatio);
                shape.setWidth(shape.getWidth() * widthRatio);

                // تحجيم موضع الشكل.
                shape.setY(shape.getY() * heightRatio);
                shape.setX(shape.getX() * widthRatio);
            }
        }
    }

    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            // تحجيم حجم الشكل.
            shape.setHeight(shape.getHeight() * heightRatio);
            shape.setWidth(shape.getWidth() * widthRatio);

            // تحجيم موضع الشكل.
            shape.setY(shape.getY() * heightRatio);
            shape.setX(shape.getX() * widthRatio);
            if (shape instanceof ITable) {
                ITable table = (ITable) shape;
                for (int i = 0; i < table.getRows().size(); i++) {
                    IRow row = table.getRows().get_Item(i);
                    row.setMinimalHeight(row.getMinimalHeight() * heightRatio);
                }
                for (int j = 0; j < table.getColumns().size(); j++) {
                    IColumn column = table.getColumns().get_Item(j);
                    column.setWidth(column.getWidth() * widthRatio);
                }
            }
        }
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```


## **الأسئلة الشائعة**

**لماذا يتم تشويه الأشكال أو قطعها بعد تغيير حجم الشريحة؟**

عند تغيير حجم الشريحة، تحتفظ الأشكال بموقعها وحجمها الأصلي ما لم يتم تغيير المقياس صراحة. يمكن أن يؤدي ذلك إلى اقتصاص المحتوى أو اختلال محاذاة الأشكال.

**هل تعمل الشيفرة المقدمة مع جميع أنواع الأشكال؟**

المثال الأساسي يعمل مع معظم أنواع الأشكال (مربعات النص، الصور، المخططات، إلخ). ومع ذلك، بالنسبة للجداول، تحتاج إلى التعامل مع الصفوف والأعمدة بشكل منفصل، لأن ارتفاع وعرض الجدول يحددان بابعاد الخلايا الفردية.

**كيف أقوم بتغيير حجم الجداول عند تغيير حجم الشريحة؟**

يتعين عليك المرور عبر جميع الصفوف والأعمدة في الجدول وتغيير ارتفاعها وعرضها بنسبية، كما هو موضح في مثال الشيفرة الثاني.

**هل سيعمل هذا التغيير مع الشرائح الرئيسية وشرائح التخطيط؟**

نعم، ولكن يجب عليك أيضًا المرور عبر [الرئيسيات](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getMasters--) و[شرائح التخطيط](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getLayoutSlides--) وتطبيق نفس منطق المقياس على أشكالها لضمان التناسق عبر العرض التقديمي بأكمله.

**هل يمكنني تغيير اتجاه الشريحة (عمودي/عرضي) مع تغيير الحجم؟**

نعم. يمكنك استخدام [presentation.getSlideSize().setOrientation](https://reference.aspose.com/slides/java/com.aspose.slides/islidesize/#setOrientation-int-) لتغيير الاتجاه. تأكد من ضبط منطق المقياس وفقًا لذلك للحفاظ على التخطيط.

**هل هناك حد لحجم الشريحة يمكنني تحديده؟**

يدعم Aspose.Slides الأحجام المخصصة، لكن الأحجام الكبيرة جدًا قد تؤثر على الأداء أو التوافق مع بعض إصدارات PowerPoint.

**كيف يمكنني منع تشوه الأشكال ذات النسبة الثابتة؟**

يمكنك التحقق من طريقة `getAspectRatioLocked` للشكل قبل التحجيم. إذا كانت مقفلة، قم بضبط العرض أو الارتفاع بنسبية بدلاً من تحجيمهما بشكل منفصل.