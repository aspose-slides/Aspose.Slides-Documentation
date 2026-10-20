---
title: إعادة تحجيم الأشكال على شرائح العرض التقديمي في .NET
type: docs
weight: 130
url: /ar/net/resizing-shapes-on-slide/
aliases:
  - /net/re-sizing-shapes-on-slide/
  - /ar/net/re-sizing-shapes-on-slide/
keywords:
- إعادة تحجيم الشكل
- تغيير حجم الشكل
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "قم بسهولة بإعادة تحجيم الأشكال على شرائح PowerPoint وOpenDocument باستخدام Aspose.Slides لـ .NET—قم بأتمتة تعديلات تخطيط الشرائح وزيادة الإنتاجية."
---
## **نظرة عامة**

عند تغيير حجم شريحة العرض التقديمي، قد تحتاج أيضًا إلى تغيير حجم الأشكال وإعادة موضعها لتتناسب مع الأبعاد الجديدة. يوضح هذا المقال كيفية قياس الأشكال يدويًا وكيفية التعامل مع الجداول على الشرائح والماستر والتصاميم.

## **تغيير حجم الأشكال**

للحفاظ على الموضع النسبي وحجم كل شكل، اضرب إحداثياته الأفقية وعرضه في نسبة عرض الشريحة الجديد إلى العرض الأصلي. طبّق نسبة الارتفاع المقابلة على إحداثياته العمودية وارتفاعه.

المثال الأول يحمل عرضًا تقديميًا لا تحتوي شرائحه على جداول، يغيّر حجم الشريحة إلى A4، ويحفظ النتيجة. يستخدم [SlideSize.SetSize](https://reference.aspose.com/slides/net/aspose.slides/slidesize/setsize/) مع [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/net/aspose.slides/slidesizescaletype/) بحيث يتحكم الحلقة اللاحقة في القياس. النسب بلا وحدة؛ مواضع الأشكال وأبعادها تُقاس بالنقاط. يمكن أن تشوه نسب العرض والارتفاع المختلفة الأشكال، وتغيير أبعاد الشكل لا يغير حجم الخطوط.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");

// احسب عوامل التحجيم الأفقية والرأسية المستقلة.
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

{{% alert color="info" title="Note" %}}
تتطلب الجداول معالجة منفصلة: قم بتغيير عرض الأعمدة وارتفاعات الصفوف بدلاً من تعيين العرض والارتفاع الكليين للجدول. قد تظل ارتفاعات الصفوف أكبر من المطلوب إذا كان محتوى الخلايا يحتاج إلى مساحة أكبر.
{{% /alert %}}

يدعم المثال الثاني الجداول ويعالج الأشكال على الماسترات والتصاميم وكذلك على الشرائح الفردية قبل حفظ العرض التقديمي المُعاد تحجيمه. يتعامل المساعد الخاص به مع كل [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) عن طريق قياس [IColumn.Width](https://reference.aspose.com/slides/net/aspose.slides/icolumn/width/) و[IRow.MinimalHeight](https://reference.aspose.com/slides/net/aspose.slides/irow/minimalheight/). ثم يقوم بقياس موضع الجدول دون قياس أبعاده الكلية بشكل منفصل.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");

// احسب عوامل التحجيم الأفقية والرأسية المستقلة.
var originalSize = presentation.SlideSize.Size;
presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
var targetSize = presentation.SlideSize.Size;
var widthRatio = targetSize.Width / originalSize.Width;
var heightRatio = targetSize.Height / originalSize.Height;

// أعد تحجيم الأشكال المعرفة على الماسترات والتصاميم وكذلك على الشرائح الفردية.
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
            // أبعاد الجدول تتحكم فيها عرض الأعمدة وارتفاعات الصفوف.
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

## **الأسئلة الشائعة**

**لماذا تتشوه الأشكال أو تُقطع بعد تغيير حجم الشريحة؟**

إذا قمت بتغيير حجم الشريحة دون قياس الأشكال، فإنها تحتفظ بمواقعها وأبعادها الأصلية وقد تتجاوز حدود الشريحة. قد يؤدي قياس العرض والارتفاع بنسب مختلفة أيضًا إلى تشوه الأشكال.

**هل يعمل الكود المقدم لجميع أنواع الأشكال؟**

المثال الأول يغيّر حدود الشكل مباشرةً ويُقصد به الشرائح التي لا تحتوي على جداول. المثال الثاني يتعامل مع الجداول بشكل منفصل. تحقق من التخطيط الناتج، خاصةً النصوص والجداول، لأن هذه الأمثلة لا تقوم بقياس أحجام الخطوط ومحتوى الجدول يمكن أن يحد من ارتفاعات الصفوف.

**كيف أقوم بتغيير حجم الجداول عند تغيير حجم الشريحة؟**

قِم بقياس عرض الأعمدة وفقًا لنسبة العرض وارتفاعات الصفوف الدنيا وفقًا لنسبة الارتفاع، ثم قِم بقياس موضع الجدول، كما هو موضح في المثال الثاني.

**هل سيعمل هذا التحجيم على ماستر الشرائح وتصاميم الشرائح؟**

نعم. يتنقل المثال الثاني عبر [Presentation.Masters](https://reference.aspose.com/slides/net/aspose.slides/presentation/masters/) وكل [LayoutSlides](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/layoutslides/) للماستر ويطبق نفس منطق التحجيم على أشكالها.

**هل يمكنني تغيير اتجاه الشريحة (عمودي/أفقي) مع التحجيم؟**

نعم. قم بتعيين [SlideSize.Orientation](https://reference.aspose.com/slides/net/aspose.slides/slidesize/orientation/) بعد تغيير حجم الشريحة وقبل قراءة الأبعاد المستهدفة، لكي تعكس عوامل القياس الاتجاه النهائي.

**هل هناك حد لحجم الشريحة الذي يمكنني تحديده؟**

يمكنك تحديد أبعاد شريحة مخصصة باستخدام [SlideSize.SetSize](https://reference.aspose.com/slides/net/aspose.slides/slidesize/setsize/). تعتمد الأبعاد المدعومة أيضًا على تنسيق العرض التقديمي والتطبيق المستخدم لفتح الملف.

**كيف يمكنني منع تشوه الأشكال ذات نسبة العرض إلى الارتفاع الثابتة؟**

استخدم عامل قياس واحد للعرض والارتفاع. لتناسب التخطيط الأصلي داخل أبعاد الشريحة الجديدة، استخدم الأصغر بين نسب العرض والارتفاع لكلا البعدين والمواقع. هذا يحافظ على النسب ولكنه قد يترك مساحة غير مستخدمة على أحد الحواف.