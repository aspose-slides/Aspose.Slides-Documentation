---
title: تعديل حجم الأشكال على شرائح العرض
type: docs
weight: 110
url: /ar/java/re-sizing-shapes-on-slide/
keywords:
- إعادة تحجيم الشكل
- تغيير حجم الشكل
- PowerPoint
- OpenDocument
- عرض تقديمي
- Java
- Aspose.Slides
description: "قم بسهولة بإعادة تحجيم الأشكال على شرائح PowerPoint وOpenDocument باستخدام Aspose.Slides for Java—أتمتة تعديل تخطيط الشرائح وزيادة الإنتاجية."
---
## **نظرة عامة**

أحد أكثر الأسئلة شيوعًا من عملاء Aspose.Slides for Java هو كيفية تغيير حجم الأشكال بحيث، عندما يتغير حجم الشريحة، لا يتم قطع البيانات. تُظهر هذه المقالة التقنية القصيرة كيفية القيام بذلك.

## **تغيير حجم الأشكال**

لتجنب حدوث اختلال في محاذاة الأشكال عندما يتغير حجم الشريحة، قم بتحديث موضع كل شكل وأبعاده لتتوافق مع تخطيط الشريحة الجديد.

```java
import com.aspose.slides.*;

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

    // تغيير حجم وإعادة تموضع الأشكال على كل شريحة.
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

{{% alert color="info" %}} 

لا تحتاج الجداول إلى معالجة خاصة: ضبط عرض وارتفاع الجدول يعيد تحجيم أعمدةه وصفوفه بنسب متناسبة، لذا فإن تحجيم ارتفاعات الصفوف وعروض الأعمدة مرة أخرى سيطبق النسبة مرتين.

{{% /alert %}} 

الكود أعلاه يغيّر فقط الأشكال على الشرائح. تحتفظ شرائح الماستر وشرائح التخطيط بأشكالها الخاصة، لذا قم بتحجيمها أيضًا عندما تريد أن يتبع العرض الكامل حجم الشريحة الجديد:

```java
import com.aspose.slides.*;

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
        }
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

## **الأسئلة الشائعة**

### لماذا تتشوه الأشكال أو تُقص بعد تغيير حجم الشريحة؟

عند تغيير حجم الشريحة، تحتفظ الأشكال بموضعها وحجمها الأصليين ما لم يتم تعديل المقياس صراحةً. يمكن أن يؤدي ذلك إلى قص المحتوى أو اختلال محاذاة الأشكال.

### هل يعمل الكود المقدم لجميع أنواع الأشكال؟

نعم. يعمل ضبط الارتفاع والعرض على صناديق النصوص والصور والمخططات والجداول على حدٍ سواء.

### كيف أقوم بتغيير حجم الجداول عند تغيير حجم الشريحة؟

قم بتحجيم شكل الجدول نفسه، تمامًا كما هو الحال مع أي شكل آخر. تتبع صفوفه وأعمدته النسبية تلقائيًا، لذا لا تقم بتحجيمها مرة أخرى بعد ذلك.

### هل سيعمل هذا التحجيم على شرائح الماستر وشرائح التخطيط؟

نعم، ولكن ينبغي أيضًا التجول عبر [الماستر]({{% raw %}}https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/#getMasters--{{% endraw %}}) و[شرائح التخطيط]({{% raw %}}https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/#getLayoutSlides--{{% endraw %}}) وتطبيق نفس منطق التحجيم على أشكالها لضمان التناسق عبر العرض بأكمله.

### هل يمكنني تغيير اتجاه الشريحة (رأسي/أفقي) مع التحجيم؟

نعم. يمكنك استخدام [presentation.getSlideSize().setOrientation]({{% raw %}}https://reference.aspose.com/slides/ar/java/com.aspose.slides/islidesize/#setOrientation-int-{{% endraw %}}) لتغيير الاتجاه. تأكد من ضبط منطق التحجيم وفقًا لذلك للحفاظ على التخطيط.

### هل هناك حد لحجم الشريحة الذي يمكنني تحديده؟

يدعم Aspose.Slides الأحجام المخصصة، لكن الأحجام الكبيرة جدًا قد تؤثر على الأداء أو التوافق مع بعض إصدارات PowerPoint.

### كيف يمكنني منع تشوه الأشكال ذات نسبة العرض إلى الارتفاع الثابتة؟

يمكنك التحقق من طريقة `getAspectRatioLocked` للشكل قبل التحجيم. إذا كانت مقفلة، عدل العرض أو الارتفاع بشكل متناسب بدلاً من تحجيمهما بشكل منفصل.