---
title: تغيير حجم الأشكال على شرائح العروض التقديمية في .NET
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
description: "قم بسهولة بتغيير حجم الأشكال على شرائح PowerPoint وOpenDocument باستخدام Aspose.Slides for .NET — أتمتة تعديل تخطيط الشرائح وزيادة الإنتاجية."
---
## **نظرة عامة**

أحد أكثر الأسئلة شيوعًا من عملاء Aspose.Slides for .NET هو كيفية تغيير حجم الأشكال بحيث، عند تغيير حجم الشريحة، لا يتم قطع البيانات. تُظهر هذه المقالة التقنية القصيرة كيفية القيام بذلك.

## **تغيير حجم الأشكال**

لمنع تشوه الأشكال عندما يتغير حجم الشريحة، قم بتحديث موضع كل شكل وأبعاده بحيث تتوافق مع تخطيط الشريحة الجديد.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// تحميل ملف العرض التقديمي.
using (Presentation presentation = new Presentation("sample.pptx"))
{
    // الحصول على حجم الشريحة الأصلي.
    float currentHeight = presentation.SlideSize.Size.Height;
    float currentWidth = presentation.SlideSize.Size.Width;

    // تغيير حجم الشريحة دون تكبير الأشكال الحالية.
    presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);

    // الحصول على حجم الشريحة الجديد.
    float newHeight = presentation.SlideSize.Size.Height;
    float newWidth = presentation.SlideSize.Size.Width;

    float heightRatio = newHeight / currentHeight;
    float widthRatio = newWidth / currentWidth;

    // تغيير حجم الأشكال وإعادة وضعها على كل شريحة.
    foreach (ISlide slide in presentation.Slides)
    {
        foreach (IShape shape in slide.Shapes)
        {
            // تعديل حجم الشكل.
            shape.Height *= heightRatio;
            shape.Width *= widthRatio;

            // تعديل موضع الشكل.
            shape.Y *= heightRatio;
            shape.X *= widthRatio;
        }
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

{{% alert color="info" %}}
إذا احتوت الشريحة على جدول، فإن الشيفرة أعلاه لن تعمل بشكل صحيح. في هذه الحالة، يجب تغيير حجم كل خلية في الجدول.
{{% /alert %}}

استخدم الشيفرة التالية في جانبك لتغيير حجم الشرائح التي تحتوي على جداول. بالنسبة للجداول، قم بتكبير ارتفاع الصفوف الفردية وعرض الأعمدة بدلاً من عرض وارتفاع الشكل—تطبيق كلاهما سيضاعف تكبير الجدول ويدفعه خارج الشريحة.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    // الحصول على حجم الشريحة الأصلي.
    float currentHeight = presentation.SlideSize.Size.Height;
    float currentWidth = presentation.SlideSize.Size.Width;

    // تغيير حجم الشريحة دون تكبير الأشكال الحالية.
    presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    // presentation.SlideSize.Orientation = SlideOrienation.Portrait;

    // الحصول على حجم الشريحة الجديد.
    float newHeight = presentation.SlideSize.Size.Height;
    float newWidth = presentation.SlideSize.Size.Width;

    float heightRatio = newHeight / currentHeight;
    float widthRatio = newWidth / currentWidth;

    foreach (IMasterSlide master in presentation.Masters)
    {
        foreach (IShape shape in master.Shapes)
        {
            // تعديل حجم الشكل.
            shape.Height *= heightRatio;
            shape.Width *= widthRatio;

            // تعديل موضع الشكل.
            shape.Y *= heightRatio;
            shape.X *= widthRatio;
        }

        foreach (ILayoutSlide layoutSlide in master.LayoutSlides)
        {
            foreach (IShape shape in layoutSlide.Shapes)
            {
                // تعديل حجم الشكل.
                shape.Height *= heightRatio;
                shape.Width *= widthRatio;

                // تعديل موضع الشكل.
                shape.Y *= heightRatio;
                shape.X *= widthRatio;
            }
        }
    }

    foreach (ISlide slide in presentation.Slides)
    {
        foreach (IShape shape in slide.Shapes)
        {
            if (shape is ITable)
            {
                // تكبير حجم الجدول عبر صفوفه وأعمدته.
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
            else
            {
                // تعديل حجم الشكل.
                shape.Height *= heightRatio;
                shape.Width *= widthRatio;
            }

            // تعديل موضع الشكل.
            shape.Y *= heightRatio;
            shape.X *= widthRatio;
        }
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **الأسئلة الشائعة**

### لماذا تتشوه الأشكال أو تُقَطَع بعد تغيير حجم الشريحة؟

عند تغيير حجم الشريحة، تحتفظ الأشكال بموقعها وحجمها الأصلي ما لم يتم تغيير المقياس صراحةً. يمكن أن يؤدي ذلك إلى قص المحتوى أو تشوه الأشكال.

### هل تعمل الشيفرة المقدمة مع جميع أنواع الأشكال؟

العينة الأساسية تعمل مع معظم أنواع الأشكال (صناديق النص، الصور، المخططات، إلخ). ولكن بالنسبة للجداول، تحتاج إلى معالجة الصفوف والأعمدة بشكل منفصل، لأن ارتفاع وعرض الجدول يحددهما أبعاد الخلايا الفردية.

### كيف أقوم بتغيير حجم الجداول عند تغيير حجم الشريحة؟

يجب عليك المرور عبر جميع الصفوف والأعمدة في الجدول وتغيير ارتفاعها وعرضها بنسبية، كما هو موضح في مثال الشيفرة الثاني.

### هل سيعمل هذا التغيير في الحجم على الشرائح الرئيسة وشرائح التخطيط؟

نعم، ولكن يجب عليك أيضًا المرور عبر [Masters](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/masters/) و[LayoutSlides](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/layoutslides/) وتطبيق نفس منطق التكبير على أشكالها لضمان الاتساق عبر العرض التقديمي.

### هل يمكنني تغيير اتجاه الشريحة (عمودي/أفقي) مع تغيير الحجم؟

نعم. يمكنك تعيين [presentation.SlideSize.Orientation](https://reference.aspose.com/slides/ar/net/aspose.slides/islidesize/orientation/) لتغيير الاتجاه. تأكد من ضبط منطق التكبير وفقًا لذلك للحفاظ على التخطيط.

### هل هناك حد لحجم الشريحة الذي يمكنني تحديده؟

يدعم Aspose.Slides أحجامًا مخصصة، لكن الأحجام الكبيرة جدًا قد تؤثر على الأداء أو التوافق مع بعض إصدارات PowerPoint.

### كيف يمكنني منع تشوه الأشكال ذات نسبة العرض إلى الارتفاع الثابتة؟

يمكنك التحقق من خاصية `AspectRatioLocked` للشكل قبل التكبير. إذا كانت مقفلة، قم بضبط العرض أو الارتفاع بنسبية بدلاً من تكبيرهما بشكل فردي.