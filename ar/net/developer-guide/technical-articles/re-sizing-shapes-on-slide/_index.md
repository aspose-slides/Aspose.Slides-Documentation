---
title: إعادة تحجيم الأشكال على شرائح العرض
type: docs
weight: 130
url: /ar/net/re-sizing-shapes-on-slide/
keywords:
- إعادة تحجيم الشكل
- تغيير حجم الشكل
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "قم بإعادة تحجيم الأشكال بسهولة على شرائح PowerPoint و OpenDocument باستخدام Aspose.Slides for .NET — أتمتة تعديل تخطيط الشرائح وزيادة الإنتاجية."
---

## **نظرة عامة**

إحدى الأسئلة الشائعة من عملاء Aspose.Slides for .NET هي كيفية تغيير حجم الأشكال بحيث لا يتم قطع البيانات عندما يتغير حجم الشريحة. يوضح هذا المقال التقني القصير كيفية القيام بذلك.

## **تغيير حجم الأشكال**

لمنع تحرك الأشكال عن مواضعها عندما يتغير حجم الشريحة، قم بتحديث موقع كل شكل وأبعاده لتتوافق مع تخطيط الشريحة الجديد.
```c#
// تحميل ملف العرض.
using (Presentation presentation = new Presentation("sample.pptx"))
{
    // الحصول على حجم الشريحة الأصلي.
    float currentHeight = presentation.SlideSize.Size.Height;
    float currentWidth = presentation.SlideSize.Size.Width;

    // تغيير حجم الشريحة دون تحجيم الأشكال الموجودة.
    presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);

    // الحصول على حجم الشريحة الجديد.
    float newHeight = presentation.SlideSize.Size.Height;
    float newWidth = presentation.SlideSize.Size.Width;

    float heightRatio = newHeight / currentHeight;
    float widthRatio = newWidth / currentWidth;

    // تحجيم وإعادة وضع الأشكال في كل شريحة.
    foreach (ISlide slide in presentation.Slides)
    {
        foreach (IShape shape in slide.Shapes)
        {
            // تحجيم حجم الشكل.
            shape.Height *= heightRatio;
            shape.Width *= widthRatio;

            // تحجيم موقع الشكل.
            shape.Y *= heightRatio;
            shape.X *= widthRatio;
        }
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```


{{% alert color="primary" %}}
إذا كانت الشريحة تحتوي على جدول، فإن الشفرة أعلاه لن تعمل بشكل صحيح. في هذه الحالة، يجب تغيير حجم كل خلية في الجدول.
{{% /alert %}}

استخدم الشفرة التالية على جانبك لتغيير حجم الشرائح التي تحتوي على جداول. بالنسبة للجداول، فإن تعيين العرض أو الارتفاع حالة خاصة: يجب تعديل ارتفاعات الصفوف الفردية وعروض الأعمدة لتغيير الحجم الكلي للجدول.
```c#
using (Presentation presentation = new Presentation("sample.pptx"))
{
    // احصل على حجم الشريحة الأصلي.
    float currentHeight = presentation.SlideSize.Size.Height;
    float currentWidth = presentation.SlideSize.Size.Width;

    // غير حجم الشريحة دون تحجيم الأشكال الموجودة.
    presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    // presentation.SlideSize.Orientation = SlideOrienation.Portrait;

    // احصل على حجم الشريحة الجديد.
    float newHeight = presentation.SlideSize.Size.Height;
    float newWidth = presentation.SlideSize.Size.Width;

    float heightRatio = newHeight / currentHeight;
    float widthRatio = newWidth / currentWidth;

    foreach (IMasterSlide master in presentation.Masters)
    {
        foreach (IShape shape in master.Shapes)
        {
            // تحجيم حجم الشكل.
            shape.Height *= heightRatio;
            shape.Width *= widthRatio;

            // تحجيم موقع الشكل.
            shape.Y *= heightRatio;
            shape.X *= widthRatio;
        }

        foreach (ILayoutSlide layoutSlide in master.LayoutSlides)
        {
            foreach (IShape shape in layoutSlide.Shapes)
            {
                // تحجيم حجم الشكل.
                shape.Height *= heightRatio;
                shape.Width *= widthRatio;

                // تحجيم موقع الشكل.
                shape.Y *= heightRatio;
                shape.X *= widthRatio;
            }
        }
    }

    foreach (ISlide slide in presentation.Slides)
    {
        foreach (IShape shape in slide.Shapes)
        {
            // تحجيم حجم الشكل.
            shape.Height *= heightRatio;
            shape.Width *= widthRatio;

            // تحجيم موقع الشكل.
            shape.Y *= heightRatio;
            shape.X *= widthRatio;

            if (shape is ITable)
            {
                ITable table = (ITable)shape;
                foreach (IRow row in table.Rows)
                {
                    row.MinimalHeight *= heightRatio;
                }
                foreach (IColumn column in table.Columns)
                {
                    column.Width *= widthRatio;
                }
            }
        }
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```


## **الأسئلة الشائعة**

**لماذا تتشوه الأشكال أو تُقطَع بعد تغيير حجم الشريحة؟**

عند تغيير حجم الشريحة، تحتفظ الأشكال بموقعها وحجمها الأصلي ما لم يتم تعديل المقياس صراحة. يمكن أن يؤدي ذلك إلى قص المحتوى أو تشويه الأشكال.

**هل تعمل الشفرة المقدمة مع جميع أنواع الأشكال؟**

المثال الأساسي يعمل مع معظم أنواع الأشكال (صناديق النص، الصور، المخططات، إلخ). ومع ذلك، بالنسبة للجداول، تحتاج إلى معالجة الصفوف والأعمدة بشكل منفصل، لأن ارتفاع وعرض الجدول يحددهما أبعاد الخلايا الفردية.

**كيف يمكنني تغيير حجم الجداول عند تغيير حجم الشريحة؟**

عليك المرور على جميع صفوف وأعمدة الجدول وتغيير ارتفاعها وعرضها بنسبة متناسبة، كما هو موضح في مثال الشفرة الثاني.

**هل سيعمل هذا التغيير على الشرائح الرئيسية و LayoutSlides؟**

نعم، ولكن يجب أيضًا المرور عبر [Masters](https://reference.aspose.com/slides/net/aspose.slides/presentation/masters/) و [LayoutSlides](https://reference.aspose.com/slides/net/aspose.slides/presentation/layoutslides/) وتطبيق نفس منطق القياس على الأشكال الخاصة بهم لضمان الاتساق عبر العرض التقديمي.

**هل يمكنني تغيير اتجاه الشريحة (عمودي/أفقي) مع تغيير الحجم؟**

نعم. يمكنك ضبط [presentation.SlideSize.Orientation](https://reference.aspose.com/slides/net/aspose.slides/islidesize/orientation/) لتغيير الاتجاه. تأكد من ضبط منطق القياس وفقًا لذلك للحفاظ على التخطيط.

**هل هناك حد لحجم الشريحة الذي يمكنني تحديده؟**

يدعم Aspose.Slides الأحجام المخصصة، ولكن الأحجام الكبيرة جدًا قد تؤثر على الأداء أو التوافق مع بعض إصدارات PowerPoint.

**كيف يمكنني منع تشوه الأشكال ذات نسبة العرض إلى الارتفاع الثابتة؟**

يمكنك التحقق من الخاصية `AspectRatioLocked` للشكل قبل القياس. إذا كانت مقفولة، قم بضبط العرض أو الارتفاع بنسبة متناسبة بدلاً من قياسهما بشكل فردي.