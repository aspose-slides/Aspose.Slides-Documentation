---
title: إعادة تحجيم الأشكال على شرائح العرض التقديمي في .NET
type: docs
weight: 130
url: /ar/net/resizing-shapes-on-slide/
aliases:
  - /ar/net/re-sizing-shapes-on-slide/
  /net/إعادة-تحجيم-الأشكال-على-الشريحة/
keywords:
- إعادة تحجيم الشكل
- تغيير حجم الشكل
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "قم بسهولة بإعادة تحجيم الأشكال على شرائح PowerPoint وOpenDocument باستخدام Aspose.Slides لـ .NET — أتمتة تعديل تخطيط الشرائح وزيادة الإنتاجية."
---
## **نظرة عامة**

عند تغيير حجم شريحة العرض التقديمي، قد تحتاج أيضًا إلى إعادة تحجيم الأشكال وإعادة وضعها لتناسب الأبعاد الجديدة. يوضح هذا المقال كيفية تحجيم الأشكال يدويًا وكيفية التعامل مع الجداول في الشرائح، القوالب الرئيسة، والتخطيطات.

## **إعادة تحجيم الأشكال**

للحفاظ على الموضع النسبي وحجم كل شكل، اضرب إحداثياته الأفقية وعرضه في نسبة عرض الشريحة الجديدة إلى العرض الأصلي. طبق نسبة الارتفاع المقابلة على إحداثياته العمودية والارتفاع.

المثال الأول يحمل عرضًا تقديميًا لا تحتوي شرائحه على جداول، يغيّر حجم الشريحة إلى A4، ويحفظ النتيجة. يستخدم [SlideSize.SetSize](https://reference.aspose.com/slides/net/aspose.slides/slidesize/setsize/) مع [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/net/aspose.slides/slidesizescaletype/) بحيث تتحكم الحلقة اللاحقة في التحجيم. النسب لا تحمل وحدة؛ مواضع الأشكال وأبعادها تُقاس بالنقاط. يمكن أن تشوه نسب العرض والارتفاع المختلفة الأشكال، وتغيير أبعاد الشكل لا يغير حجم الخطوط.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");

// احسب عوامل التحجيم الأفقية والعمودية المستقلة.
var originalSize = presentation.SlideSize.Size;
presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
var targetSize = presentation.SlideSize.Size;
var widthRatio = targetSize.Width / originalSize.Width;
var heightRatio = targetSize.Height / originalSize.Height;

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        shape.Width *= widthRatio;
        shape.Height *= heightRatio;
        shape.X *= widthRatio;
        shape.Y *= heightRatio;
    }
}

presentation.Save("output.pptx", SaveFormat.Pptx);
```

{{% alert color="info" title="ملاحظة" %}}
تتطلب الجداول معالجة منفصلة: قم بتحجيم أعرض الأعمدة وارتفاعات الصفوف بدلاً من تعيين عرض وارتفاع الجدول ككل. قد تظل ارتفاعات الصفوف أكبر من المطلوب إذا كان محتوى الخلية يحتاج إلى مساحة إضافية.
{{% /alert %}}

المثال الثاني يدعم الجداول ويعالج الأشكال في القوالب الرئيسة والتخطيطات وكذلك في الشرائح الفردية قبل حفظ العرض التقديمي المعاد تحجيمه. المساعد الخاص به يتعامل مع كل [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) من خلال تحجيم [IColumn.Width](https://reference.aspose.com/slides/net/aspose.slides/icolumn/width/) و[IRow.MinimalHeight](https://reference.aspose.com/slides/net/aspose.slides/irow/minimalheight/). ثم يحجم موضع الجدول دون تحجيم أبعادها الكلية بشكل منفصل.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");

// احسب عوامل التحجيم الأفقية والعمودية المستقلة.
var originalSize = presentation.SlideSize.Size;
presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
var targetSize = presentation.SlideSize.Size;
var widthRatio = targetSize.Width / originalSize.Width;
var heightRatio = targetSize.Height / originalSize.Height;

// إعادة تحجيم الأشكال المعرفة على القوالب الرئيسة والتخطيطات وكذلك الشرائح الفردية.
foreach (var master in presentation.Masters)
{
    ResizeShapes(master.Shapes, widthRatio, heightRatio);

    foreach (var layoutSlide in master.LayoutSlides)
    {
        ResizeShapes(layoutSlide.Shapes, widthRatio, heightRatio);
    }
}

foreach (var slide in presentation.Slides)
{
    ResizeShapes(slide.Shapes, widthRatio, heightRatio);
}

presentation.Save("output.pptx", SaveFormat.Pptx);

static void ResizeShapes(IShapeCollection shapes, float widthRatio, float heightRatio)
{
    foreach (var shape in shapes)
    {
        if (shape is ITable table)
        {
            // أبعاد الجدول تتحكم فيها أعرض الأعمدة وارتفاعات الصفوف.
            foreach (var column in table.Columns)
            {
                column.Width *= widthRatio;
            }

            foreach (var row in table.Rows)
            {
                row.MinimalHeight *= heightRatio;
            }
        }
        else
        {
            shape.Width *= widthRatio;
            shape.Height *= heightRatio;
        }

        shape.X *= widthRatio;
        shape.Y *= heightRatio;
    }
}
```

## **الأسئلة المتكررة**

**لماذا تتشوه الأشكال أو تُقص بعد إعادة تحجيم الشريحة؟**

إذا قمت بتغيير حجم الشريحة دون تحجيم الأشكال، فإنها تحتفظ بمواقعها وأبعادها الأصلية وقد تمتد خارج الشريحة. يمكن أن يؤدي تحجيم العرض والارتفاع بنسب مختلفة إلى تشويه الأشكال أيضًا.

**هل يعمل الكود المقدم مع جميع أنواع الأشكال؟**

المثال الأول يغيّر حدود الشكل مباشرةً ويُقصد به الشرائح التي لا تحتوي على جداول. المثال الثاني يتعامل مع الجداول بشكل منفصل. تحقق من التخطيط الناتج، خاصة النص والجداول، لأن هذه الأمثلة لا تحجم حجم الخطوط ومحتوى الجدول قد يحد من ارتفاع الصفوف.

**كيف يمكنني إعادة تحجيم الجداول عند إعادة تحجيم الشريحة؟**

قم بتحجيم أعرض الأعمدة بنسبة عرض الشريحة، وارتفاعات الصفوف الدنيا بنسبة ارتفاع الشريحة، ثم احجم موضع الجدول، كما هو موضح في المثال الثاني.

**هل سيعمل هذا التحجيم على الشرائح الرئيسة وشرائح التخطيط؟**

نعم. المثال الثاني يت遍 عبر [Presentation.Masters](https://reference.aspose.com/slides/net/aspose.slides/presentation/masters/) وكل [LayoutSlides](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/layoutslides/) لكل قالب رئيسي ويطبق نفس منطق التحجيم على أجهزتهم.

**هل يمكنني تغيير اتجاه الشريحة (عمودي/أفقي) مع التحجيم؟**

نعم. قم بتعيين [SlideSize.Orientation](https://reference.aspose.com/slides/net/aspose.slides/slidesize/orientation/) بعد تغيير حجم الشريحة وقبل قراءة الأبعاد المستهدفة، بحيث تعكس عوامل التحجيم الاتجاه النهائي.

**هل هناك حد لحجم الشريحة الذي يمكنني تعيينه؟**

يمكنك تحديد أبعاد شريحة مخصصة باستخدام [SlideSize.SetSize](https://reference.aspose.com/slides/net/aspose.slides/slidesize/setsize/). تعتمد الأبعاد المدعومة أيضًا على تنسيق العرض التقديمي والتطبيق المستخدم لفتح الملف.

**كيف يمكنني منع الأشكال ذات النسبة الثابتة من التشوه؟**

استخدم نفس عامل التحجيم للعرض والارتفاع. لتلائم التخطيط الأصلي داخل أبعاد الشريحة الجديدة، استخدم الأصغر بين نسبة العرض ونسبة الارتفاع لكل من الأبعاد والمواقع. هذا يحافظ على النسب ولكنه قد يترك مساحة غير مستخدمة على أحد الحواف.