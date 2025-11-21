---
title: تغيير حجم الأشكال في شرائح العرض التقديمي في .NET
type: docs
weight: 130
url: /ar/net/re-sizing-shapes-on-slide/
keywords:
- تغيير حجم الشكل
- تعديل حجم الشكل
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "قم بتغيير حجم الأشكال بسهولة في شرائح PowerPoint و OpenDocument باستخدام Aspose.Slides for .NET — أتمتة تعديل تخطيط الشرائح وزيادة الإنتاجية."
---

## **نظرة عامة**

أحد أكثر الأسئلة شيوعًا من عملاء Aspose.Slides for .NET هو كيفية تغيير حجم الأشكال بحيث لا يتم قطع البيانات عند تغيير حجم الشريحة. توضح هذه المقالة التقنية القصيرة كيفية القيام بذلك.

## **تغيير حجم الأشكال**

لمنع حدوث اختلال في مواضع الأشكال عندما يتغير حجم الشريحة، يجب تحديث موضع وأبعاد كل شكل لتتوافق مع تخطيط الشريحة الجديد.
```c#
// تحميل ملف العرض التقديمي.
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

    // إعادة تحجيم وإعادة وضع الأشكال في كل شريحة.
    foreach (ISlide slide in presentation.Slides)
    {
        foreach (IShape shape in slide.Shapes)
        {
            // تحجيم حجم الشكل.
            shape.Height *= heightRatio;
            shape.Width *= widthRatio;

            // تحجيم موضع الشكل.
            shape.Y *= heightRatio;
            shape.X *= widthRatio;
        }
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```


{{% alert color="primary" %}}
إذا احتوت الشريحة على جدول، فلن يعمل الكود أعلاه بشكل صحيح. في هذه الحالة، يجب تغيير حجم كل خلية في الجدول.
{{% /alert %}}

استخدم الشيفرة التالية في تطبيقك لتغيير حجم الشرائح التي تحتوي على جداول. بالنسبة للجداول، فإن ضبط العرض أو الارتفاع هو حالة خاصة: يجب تعديل ارتفاعات الصفوف وأعرض الأعمدة الفردية لتغيير الحجم الكلي للجدول.
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

            // تحجيم موضع الشكل.
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

                // تحجيم موضع الشكل.
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

            // تحجيم موضع الشكل.
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


## **الأسئلة المتكررة**

**لماذا تتشوه الأشكال أو تُقتطع بعد تغيير حجم الشريحة؟**

عند تغيير حجم الشريحة، تحتفظ الأشكال بموقعها وحجمها الأصلي ما لم يتم تعديل المقياس صراحةً. هذا قد يؤدي إلى قص المحتوى أو اختلال مواضع الأشكال.

**هل يعمل الكود المقدم مع جميع أنواع الأشكال؟**

المثال الأساسي يعمل مع معظم أنواع الأشكال (صناديق النص، الصور، المخططات، إلخ). ومع ذلك، بالنسبة للجداول، تحتاج إلى معالجة الصفوف والأعمدة بشكل منفصل، لأن ارتفاع وعرض الجدول يحددهما أبعاد الخلايا الفردية.

**كيف يمكنني تغيير حجم الجداول عند تعديل حجم الشريحة؟**

يجب عليك المرور على جميع صفوف وأعمدة الجدول وتغيير ارتفاعها وعرضها بشكل نسبي، كما هو موضح في مثال الشيفرة الثاني.

**هل سيعمل هذا التغيير في الحجم مع الشرائح الرئيسية وشرائح التخطيط؟**

نعم، ولكن عليك أيضًا المرور على [Masters](https://reference.aspose.com/slides/net/aspose.slides/presentation/masters/) و[LayoutSlides](https://reference.aspose.com/slides/net/aspose.slides/presentation/layoutslides/) وتطبيق نفس منطق التدرج على أشكالها لضمان الاتساق عبر العرض التقديمي.

**هل يمكنني تغيير اتجاه الشريحة (عمودي/أفقي) مع تعديل الحجم؟**

نعم. يمكنك ضبط [presentation.SlideSize.Orientation](https://reference.aspose.com/slides/net/aspose.slides/islidesize/orientation/) لتغيير الاتجاه. تأكد من ضبط منطق التدرج وفقًا لذلك للحفاظ على التخطيط.

**هل هناك حد لحجم الشريحة الذي يمكنني تحديده؟**

يدعم Aspose.Slides أحجامًا مخصصة، ولكن الأحجام الكبيرة جدًا قد تؤثر على الأداء أو التوافق مع بعض إصدارات PowerPoint.

**كيف يمكنني منع تشوه الأشكال ذات نسبة العرض إلى الارتفاع الثابتة؟**

يمكنك فحص الخاصية `AspectRatioLocked` للشكل قبل التدرج. إذا كانت مقفلة، اضبط العرض أو الارتفاع بشكل نسبي بدلاً من تعديل كل منهما على حدة.