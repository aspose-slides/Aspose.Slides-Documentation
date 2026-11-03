---
title: "إدارة العناصر النائبة للعرض التقديمي في .NET"
linktitle: "إدارة العناصر النائبة"
type: docs
weight: 10
url: /ar/net/manage-placeholder/
keywords:
- عنصر نائب
- عنصر نائب نصي
- عنصر نائب صورة
- عنصر نائب مخطط
- عنصر نائب محتوى
- نص توجيه
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "تعلم كيفية فحص وتحرير العناصر النائبة للنص، الصورة، المخطط، والمحتوى وفهم وراثة العناصر النائبة باستخدام Aspose.Slides لـ .NET."
---
## **نظرة عامة**

العنصر النائب هو شكل يحجز موضعًا لنوع معين من المحتوى في قالب عرض تقديمي. الأمثلة الشائعة هي العناوين، النص الأساسي، الصورة، المخطط، والعناصر النائبة للمحتوى ذات الاستخدام العام. على عكس الشكل العادي، يمكن للعنصر النائب وراثة موضعه وحجمه وتنسيقه وإعداداته الأخرى من شريحة تخطيط أو شريحة رئيسية.

Aspose.Slides تقوم بإتاحة معلومات العنصر النائب من خلال الخاصية [IShape.Placeholder](https://reference.aspose.com/slides/net/aspose.slides/ishape/placeholder/). تُعيد الخاصية كائنًا من النوع [IPlaceholder](https://reference.aspose.com/slides/net/aspose.slides/iplaceholder/) أو `null` لشكل عادي. استخدم [IPlaceholder.Type](https://reference.aspose.com/slides/net/aspose.slides/iplaceholder/type/) لتحديد ما يُقصد أن يحتويه العنصر النائب.

لا يزال واجهة الشكل مهمة بعد معرفة نوع العنصر النائب:

- عادةً ما يُمثَّل العنصر النائب الفارغ للنص أو الصورة أو المخطط أو المحتوى بواسطة [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/).
- يمكن تمثيل العنصر النائب للصور المملوء بـ [IPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ipictureframe/).
- يمكن تمثيل العنصر النائب للمخطط المملوء بـ [IChart](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/).
- يمكن للعنصر النائب للمحتوى أن يحتوي على عدة أنواع من المحتوى. تحقق من كل من [IPlaceholder.Type](https://reference.aspose.com/slides/net/aspose.slides/iplaceholder/type/) وواجهة الشكل في وقت التشغيل بدلاً من افتراض أن كل عنصر نائب هو [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/).

{{% alert color="warning" title="Warning" %}}
[IPlaceholder.Type](https://reference.aspose.com/slides/net/aspose.slides/iplaceholder/type/) يصف دور العنصر النائب؛ لكنه لا يضمن نوع الشكل في وقت التشغيل. استخدم دائمًا فحص النوع قبل الوصول إلى النص أو الصورة أو المخطط أو الجدول أو الأعضاء الخاصة بالوسائط.
{{% /alert %}}

## **فهم وراثة العنصر النائب**

العناصر النائبة تشكل تسلسلًا هرميًا:

1. تُعرِّف شريحة الماستر الأنماط القابلة لإعادة الاستخدام، وفي بعض الحالات، العناصر النائبة على مستوى الماستر.
2. تُعرِّف شريحة التخطيط الترتيب المستخدم من قبل شريحة أو أكثر عادية ويمكنها الوراثة من شريحة الماستر.
3. تحتوي الشريحة العادية على العناصر النائبة لتلك الشريحة ويمكنها الوراثة من تخطيطها.

استدعِ [IShape.GetBasePlaceholder](https://reference.aspose.com/slides/net/aspose.slides/ishape/getbaseplaceholder/) للانتقال مستوى واحد أعلى في هذا التسلسل الهرمي. عادةً ما تُعيد العنصر النائب للشريحة عنصر النائب الخاص بالتخطيط؛ ويمكن لعنصر النائب الخاص بالتخطيط أن يُعيد عنصر النائب للماستر. تُعيد الطريقة `null` عندما لا يكون للشكل عنصر نائب أساسي.

المثال التالي يسرد العناصر النائبة في الشريحة الأولى ويُبلّغ عن عناصرها النائبة الأساسية:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("template.pptx");
var slide = presentation.Slides[0];

foreach (var shape in slide.Shapes)
{
    if (shape.Placeholder == null)
    {
        continue;
    }

    var placeholderType = shape.Placeholder.Type;
    var typeName = shape.GetType().Name;
    Console.WriteLine($"Slide placeholder: {placeholderType}; shape interface: {typeName}");

    var layoutPlaceholder = shape.GetBasePlaceholder();
    if (layoutPlaceholder != null)
    {
        var layoutPlaceholderType = layoutPlaceholder.Placeholder?.Type;
        Console.WriteLine($"  Layout placeholder: {layoutPlaceholderType}");

        var masterPlaceholder = layoutPlaceholder.GetBasePlaceholder();
        if (masterPlaceholder != null)
        {
            var masterPlaceholderType = masterPlaceholder.Placeholder?.Type;
            Console.WriteLine($"  Master placeholder: {masterPlaceholderType}");
        }
    }
}
```

تحرير عنصر نائب في شريحة عادية يُنشئ أو يُغيّر تعديلًا محليًا لتلك الشريحة. تحرير التخطيط أو الماستر المرتبط يمكن أن يؤثر على جميع الشرائح التي لا تزال تورث ذلك الإعداد. الشكل العادي المحلي لا يمتلك عنصر نائب أساسي ولا يبدأ الوراثة لمجرد أنه يشغل نفس الإحداثيات.

## **إزالة حالة العنصر النائب**

عند تعديل قالب، استخدم [IShape.RemovePlaceholder](https://reference.aspose.com/slides/net/aspose.slides/ishape/removeplaceholder/) للحفاظ على كائن موجود كشكل عادي. تصبح خاصية [Placeholder](https://reference.aspose.com/slides/net/aspose.slides/ishape/placeholder/) الخاصة به `null`، لكن يبقى الشكل في مجموعة الشرائح. بالمقابل، يحذف [IShapeCollection.Remove](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/remove/) الشكل من تلك المجموعة.

يتطلب المثال التالي ملف `template.pptx` يحتوي على شريحة واحدة على الأقل وعنصر نائب نص غير فارغ في الشريحة الأولى. استخدم عنصرًا نائبًا بتنسيق موروث من تخطيطه أو ماستره لرؤية تأثير إزالة تلك العلاقة. يتحقق المثال من بقاء الشكل نفسه، ثم يستدعي الطريقة مرة أخرى على الشكل العادي الآن، ويحفظ النتيجة.

{{% alert color="warning" title="Warning" %}}
إزالة حالة العنصر النائب لا تحتفظ تلقائيًا بإعدادات المظهر الموروثة. المثال أدناه يترك تلك الإعدادات دون تغيير عمدًا، لذا قد يبدو الناتج مختلفًا. يمكن أن يصبح الشكل الذي يتم وراثة موضعه وحجمه بالكامل له إحداثيات وأبعاد صفرية بعد الاستدعاء ويصبح غير مرئي رغم بقائه في المجموعة.
{{% /alert %}}

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("template.pptx");
var slide = presentation.Slides[0];
var found = false;

for (var index = 0; index < slide.Shapes.Count; index++)
{
    if (slide.Shapes[index] is not IAutoShape shape || 
        shape.Placeholder == null || 
        string.IsNullOrEmpty(shape.TextFrame?.Text))
    {
        continue;
    }

    var shapeCount = slide.Shapes.Count;
    shape.RemovePlaceholder();

    Console.WriteLine($"Placeholder removed: {shape.Placeholder == null}");
    Console.WriteLine($"Same shape retained: {ReferenceEquals(slide.Shapes[index], shape)}");
    Console.WriteLine($"Shape count unchanged: {slide.Shapes.Count == shapeCount}");

    // استدعاء الطريقة على شكل عادي لا يؤثر.
    shape.RemovePlaceholder();
    found = true;
    break;
}

if (found)
{
    presentation.Save("placeholder-status-removed.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("No nonempty text placeholder was found on the first slide.");
}
```

بالنسبة إلى عنصر نائب مطابق، تطبع الفحوصات الثلاثة `True`. يبقى النص، لكن قد تتغير الموضع والحجم والدوران والخط ومحاذاة الفقرة وهوامش إطار النص والتموضع الرأسي والتعبئة وإعدادات الخط عندما تُزيل علاقة العنصر النائب. على سبيل المثال، قد يعود تنسيق العنوان الموروث إلى تنسيق النص العادي. راجع [Slide Layout](/slides/ar/net/slide-layout/) لمزيد من المعلومات حول التخطيطات.

للحفاظ على المظهر المقصود، احصل على الموضع والحجم والدوران المحسوبين قبل الاستدعاء، وانسخ قيم التنسيق الفعّال المطلوبة إلى متغيرات منفصلة. استرجع تلك القيم عبر [IPortionFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/geteffective/), [IParagraphFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/geteffective/), [ITextFrameFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/geteffective/), [IFillFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/geteffective/), و[ILineFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/geteffective/). لا تعتمد على الاحتفاظ فقط بأجسام التنسيق الفعّال، لأن قيم تنسيق النص قد تتغير بعد إزالة العلاقة. طبق القيم الملتقطة على الشكل العادي صراحةً بعد ذلك، بما في ذلك عائلة الخط، الحجم، النمط، اللون، إعدادات الفقرة، إعدادات إطار النص، التعبئة، والخط المستخدم في القالب.

قد تحتاج هندسة الشكل الموروثة أيضًا إلى تعيين صريح عبر [IGeometryShape.ShapeType](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/shapetype/). بالنسبة لعنصر نائب نصي مستطيل، يعني ذلك تعيين [ShapeType.Rectangle](https://reference.aspose.com/slides/net/aspose.slides/shapetype/); قد لا يقتصر استعادة التعبئة والخط فقط على استعادة المستطيل المرئي. القوالب ذات المؤثرات الإضافية أو التنسيق المعقد أكثر تتطلب معالجة تلك الإعدادات أيضًا.

## **تغيير النص في العنصر النائب**

عادةً ما تدعم عناصر نائب العنوان، العنوان الوسطي، العنوان الفرعي، النص الرئيسي، وعناصر النص النص. تحقق من وجود [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) قبل استخدام خاصية [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/textframe/).

يُحدّث هذا المثال عنصر نائب العنوان الأول في الشريحة الأولى ويحفظ النتيجة:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("template.pptx");
var slide = presentation.Slides[0];
IAutoShape? titleShape = null;

foreach (var shape in slide.Shapes)
{
    if (shape is not IAutoShape autoShape || autoShape.Placeholder == null)
    {
        continue;
    }

    var placeholderType = autoShape.Placeholder.Type;
    if (placeholderType == PlaceholderType.Title || placeholderType == PlaceholderType.CenteredTitle)
    {
        titleShape = autoShape;
        break;
    }
}

if (titleShape == null)
{
    throw new InvalidOperationException("The first slide does not contain a title placeholder.");
}

titleShape.TextFrame.Text = "Quarterly Business Review";
presentation.Save("title-placeholder-updated.pptx", SaveFormat.Pptx);
```

يتجنب هذا النمط تحويل العناصر النائبة للصور أو المخططات أو الجداول أو الوسائط إلى [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/). كما يحدد العنصر النائب بناءً على الغرض بدلاً من الاعتماد على فهرس الشكل الهش.

## **تعيين نص التلميح في تخطيط**

نص التلميح هو التعليمات في وقت التصميم التي تُعرض في عنصر نائب فارغ، مثل *Click to add title*. عيّن نص تلميح مخصص على عنصر نائب التخطيط بدلاً من محاولة الوصول إليه عبر مجموعة أشكال الشريحة العادية. احصل على التخطيط عبر [ISlide.LayoutSlide](https://reference.aspose.com/slides/net/aspose.slides/islide/layoutslide/) وتكرّر عبر [ILayoutSlide.Shapes](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/shapes/).

المثال التالي يغيّر تلميحات العنوان والعنوان الفرعي في التخطيط المستخدم من قبل الشريحة الأولى:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("template.pptx");
var layoutSlide = presentation.Slides[0].LayoutSlide;

foreach (var shape in layoutSlide.Shapes)
{
    if (shape is not IAutoShape autoShape || autoShape.Placeholder == null)
    {
        continue;
    }

    switch (autoShape.Placeholder.Type)
    {
        case PlaceholderType.Title:
        case PlaceholderType.CenteredTitle:
            autoShape.TextFrame.Text = "Enter a concise slide title";
            break;
        case PlaceholderType.Subtitle:
            autoShape.TextFrame.Text = "Enter a subtitle or reporting period";
            break;
    }
}

presentation.Save("custom-placeholder-prompts.pptx", SaveFormat.Pptx);
```

نص التلميح ليس محتوى شريحة عادي. إنه مخصص للعناصر النائبة الفارغة في تطبيقات التحرير مثل PowerPoint. بمجرد أن يزود المستخدم أو البرنامج محتوى حقيقيًا، لا يعود التلميح معروضًا. تغيير التلميح لا يستبدل أيضًا النص الموجود في الشرائح التي تستخدم التخطيط.

## **تحديث العنصر النائب للصورة**

هناك حالتان للتعامل معهما:

- إذا كان عنصر نائب الصورة مُعبأًا بالفعل ومُمثلاً بـ [IPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ipictureframe/), استبدل الصورة عبر [IPictureFillFormat.Picture](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/picture/) و[ISlidesPicture.Image](https://reference.aspose.com/slides/net/aspose.slides/islidespicture/image/).
- إذا كان لا يزال عنصر نائب فارغًا، أضف إطار صورة في إحداثيات العنصر النائب باستخدام [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addpictureframe/) وأزل العنصر النائب الفارغ.

الدليل التالي يدعم الحالتين ويحفظ العرض التقديمي:

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("picture-template.pptx");
var slide = presentation.Slides[0];
IShape? picturePlaceholder = null;

foreach (var shape in slide.Shapes)
{
    if (shape.Placeholder?.Type == PlaceholderType.Picture)
    {
        picturePlaceholder = shape;
        break;
    }
}

if (picturePlaceholder == null)
{
    throw new InvalidOperationException("The first slide does not contain a picture placeholder.");
}

var imageBytes = File.ReadAllBytes("replacement.png");
var image = presentation.Images.AddImage(imageBytes);

if (picturePlaceholder is IPictureFrame pictureFrame)
{
    pictureFrame.PictureFormat.Picture.Image = image;
}
else
{
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle, picturePlaceholder.X, picturePlaceholder.Y, picturePlaceholder.Width, picturePlaceholder.Height, image);
    slide.Shapes.Remove(picturePlaceholder);
}

presentation.Save("picture-placeholder-updated.pptx", SaveFormat.Pptx);
```

الاستبدال المُنشأ لعنصر نائب فارغ هو إطار صورة محلي، وليس عنصر نائبًا جديدًا، لأن [IShape.Placeholder](https://reference.aspose.com/slides/net/aspose.slides/ishape/placeholder/) للقراءة فقط. يحتفظ بالموقع المحجوز لكنه لا يرث سلوك العنصر النائب بعد الآن. إذا كان الحفاظ على علاقة العنصر النائب ضروريًا، قم بإعداد وتعبئة العنصر النائب في PowerPoint أولًا، ثم حدّث [IPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ipictureframe/) الناتج باستخدام Aspose.Slides.

لشفافية الصورة، القص، وتأثيرات الصورة الأخرى، راجع [Manage Picture Frames](/slides/ar/net/picture-frame/). تلك العمليات تخص إطار الصورة أو تعبئة الصورة، لا بيانات التعريف للعنصر النائب.

## **العمل مع العناصر النائبة للمخطط والمحتوى**

يمكن تمثيل عنصر نائب المخطط المملوء بـ [IChart](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/). يجد هذا المثال مثل هذا المخطط بناءً على نوع العنصر النائب وواجهة وقت التشغيل، ويغيّر عنوانه، ثم يحفظ الملف:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("chart-template.pptx");
var slide = presentation.Slides[0];
IChart? placeholderChart = null;

foreach (var shape in slide.Shapes)
{
    if (shape is IChart chart && shape.Placeholder?.Type == PlaceholderType.Chart)
    {
        placeholderChart = chart;
        break;
    }
}

if (placeholderChart == null)
{
    throw new InvalidOperationException("The first slide does not contain a populated chart placeholder.");
}

placeholderChart.HasTitle = true;
placeholderChart.ChartTitle.AddTextFrameForOverriding("Quarterly Revenue");
presentation.Save("chart-placeholder-updated.pptx", SaveFormat.Pptx);
```

عادةً ما يحتوي العنصر النائب للمحتوى العام على [PlaceholderType.Object](https://reference.aspose.com/slides/net/aspose.slides/placeholdertype/). في PowerPoint يعمل كمنطلق لعدة أنواع من المحتوى، بما في ذلك المخططات، الجداول، المخططات البيانية، الصور، والوسائط. بعد تعبئته، افحص واجهة الشكل الفعلية لتعرف ما يحتويه. يمكن للتخطيطات المتخصصة أيضًا أن تعرض [PlaceholderType.Chart](https://reference.aspose.com/slides/net/aspose.slides/placeholdertype/), [PlaceholderType.Table](https://reference.aspose.com/slides/net/aspose.slides/placeholdertype/), [PlaceholderType.Picture](https://reference.aspose.com/slides/net/aspose.slides/placeholdertype/), [PlaceholderType.Media](https://reference.aspose.com/slides/net/aspose.slides/placeholdertype/), أو [PlaceholderType.Diagram](https://reference.aspose.com/slides/net/aspose.slides/placeholdertype/).

لا تقوم Aspose.Slides بتحويل عنصر نائب فارغ من نوع [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) إلى [IChart](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/) بمجرد تغيير [IPlaceholder.Type](https://reference.aspose.com/slides/net/aspose.slides/iplaceholder/type/); فالنوع للقراءة فقط. لتعبئة مخطط أو مساحة محتوى فارغة برمجيًا، أضف الكائن المطلوب عند إحداثيات العنصر النائب ثم أزل العنصر النائب الفارغ. المثال التالي يقوم بذلك لمخطط:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("content-template.pptx");
var slide = presentation.Slides[0];
IShape? targetPlaceholder = null;

foreach (var shape in slide.Shapes)
{
    if (shape.Placeholder?.Type is PlaceholderType.Chart or PlaceholderType.Object)
    {
        targetPlaceholder = shape;
        break;
    }
}

if (targetPlaceholder == null)
{
    throw new InvalidOperationException("The first slide does not contain a chart or content placeholder.");
}

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, targetPlaceholder.X, targetPlaceholder.Y, targetPlaceholder.Width, targetPlaceholder.Height);
chart.HasTitle = true;
chart.ChartTitle.AddTextFrameForOverriding("Quarterly Revenue");
slide.Shapes.Remove(targetPlaceholder);
presentation.Save("content-placeholder-replaced-with-chart.pptx", SaveFormat.Pptx);
```

المخطط المضاف هو مخطط محلي عادي. يشغل مساحة العنصر النائب لكنه لا يرث من عنصر نائب التخطيط. استخدم مقالات إدارة المخططات المخصصة [chart management articles](/slides/ar/net/powerpoint-charts/) عندما تحتاج إلى استبدال الفئات أو السلاسل أو بيانات المصنف.

## **مثال كامل: تحديث النص أو محتوى الصورة**

المثال الشامل التالي يفتح قالبًا، يبحث في الشريحة الأولى عن عنصر نائب للعنوان أو الصورة، يتحقق من أنواع العنصر النائب والشكل، يحدّث المحتوى المناسب، ويحفظ الناتج. يتجنب المثال عمداً افتراض فهرس الشكل أو تحويل كل عنصر نائب إلى نفس الواجهة.

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("template.pptx");
var slide = presentation.Slides[0];
var updated = false;

foreach (var shape in slide.Shapes)
{
    if (shape.Placeholder == null)
    {
        continue;
    }

    var placeholderType = shape.Placeholder.Type;

    if ((placeholderType == PlaceholderType.Title || placeholderType == PlaceholderType.CenteredTitle) && shape is IAutoShape titleShape)
    {
        titleShape.TextFrame.Text = "Quarterly Business Review";
        updated = true;
        break;
    }

    if (placeholderType == PlaceholderType.Picture)
    {
        var imageBytes = File.ReadAllBytes("replacement.png");
        var image = presentation.Images.AddImage(imageBytes);

        if (shape is IPictureFrame pictureFrame)
        {
            pictureFrame.PictureFormat.Picture.Image = image;
        }
        else
        {
            slide.Shapes.AddPictureFrame(ShapeType.Rectangle, shape.X, shape.Y, shape.Width, shape.Height, image);
            slide.Shapes.Remove(shape);
        }

        updated = true;
        break;
    }
}

if (!updated)
{
    throw new InvalidOperationException("No supported title or picture placeholder was found on the first slide.");
}

presentation.Save("placeholder-content-updated.pptx", SaveFormat.Pptx);
```

## **الأسئلة المتكررة**

**ما هو العنصر النائب الأساسي؟**

العنصر النائب الأساسي هو الشكل المقابل على التخطيط أو الماستر الذي يرث منه عنصر نائب آخر. استخدم [IShape.GetBasePlaceholder](https://reference.aspose.com/slides/net/aspose.slides/ishape/getbaseplaceholder/) لاسترجاعه. يعيد الشكل العادي المحلي `null` لأنه ليس جزءًا من تسلسل العناصر النائبة.

**هل يمكنني تغيير جميع عناوين الشرائح عن طريق تحرير عنصر نائب في التخطيط؟**

يمكنك تغيير التنسيق الموروث أو نص التلميح من خلال التخطيط، لكن محتوى العنوان الموجود يُخزن في الشرائح العادية. لاستبدال نص العنوان الفعلي عبر العرض التقديمي، كرّر على الشرائح وقم بتحديث كل عنصر نائب للعنوان.

**كيف يمكنني إدارة عناصر نائب التاريخ، رقم الشريحة، الرأس، والتذييل؟**

استخدم مديري الرأس والتذييل في نطاق الشريحة أو التخطيط أو الماستر أو الملاحظات أو النشر المناسب. راجع [Manage Presentation Header and Footer](/slides/ar/net/presentation-header-and-footer/) للحصول على أمثلة كاملة.