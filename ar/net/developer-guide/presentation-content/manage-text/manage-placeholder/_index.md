---
title: إدارة عناصر نائب العرض التقديمي في .NET
linktitle: إدارة العناصر النائبة
type: docs
weight: 10
url: /ar/net/manage-placeholder/
keywords:
- عنصر نائب
- عنصر نائب نص
- عنصر نائب صورة
- عنصر نائب رسم بياني
- عنصر نائب محتوى
- نص توجيه
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "تعرف على كيفية فحص وتحرير عناصر نائب النص والصورة والرسم البياني والمحتوى وفهم وراثة العناصر النائبة باستخدام Aspose.Slides لـ .NET."
---
## **نظرة عامة**

العنصر النائب هو شكل يخصص موضعًا لنوع معين من المحتوى في قالب عرض تقديمي. من الأمثلة الشائعة العناوين، النص الأساسي، الصورة، الرسم البياني، وعناصر نائب محتوى متعددة الأغراض. على عكس الشكل العادي، يمكن للعنصر النائب أن يرث موضعه وحجمه وتنسيقه وإعدادات أخرى من شريحة تخطيط أو شريحة رئيسية.

تكشف Aspose.Slides معلومات العنصر النائب عبر خاصية [IShape.Placeholder](https://reference.aspose.com/slides/ar/net/aspose.slides/ishape/placeholder/). تُرجع الخاصية كائنًا من نوع [IPlaceholder](https://reference.aspose.com/slides/ar/net/aspose.slides/iplaceholder/) أو `null` لشكل عادي. استخدم [IPlaceholder.Type](https://reference.aspose.com/slides/ar/net/aspose.slides/iplaceholder/type/) لتحديد ما يُقصد بالعنصر النائب أن يحتويه.

واجهة الشكل لا تزال مهمة بعد معرفة نوع العنصر النائب:

- عادةً ما يُمثَّل عنصر نائب فارغ للنص أو الصورة أو الرسم البياني أو المحتوى بواسطة [IAutoShape](https://reference.aspose.com/slides/ar/net/aspose.slides/iautoshape/).
- يمكن تمثيل عنصر نائب صورة مُعبَّأ بواسطة [IPictureFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/ipictureframe/).
- يمكن تمثيل عنصر نائب رسم بياني مُعبَّأ بواسطة [IChart](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichart/).
- يمكن لعنصر نائب محتوى أن يحتوي عدة أنواع من المحتوى. تحقَّق من كلٍ من [IPlaceholder.Type](https://reference.aspose.com/slides/ar/net/aspose.slides/iplaceholder/type/) وواجهة الشكل وقت التشغيل بدلاً من افتراض أن كل عنصر نائب هو [IAutoShape](https://reference.aspose.com/slides/ar/net/aspose.slides/iautoshape/).

{{% alert color="warning" title="Warning" %}}
[IPlaceholder.Type](https://reference.aspose.com/slides/ar/net/aspose.slides/iplaceholder/type/) يصف دور العنصر النائب؛ لكنه لا يضمن نوع الشكل وقت التشغيل. استخدم دائمًا فحص النوع قبل الوصول إلى النص أو الصورة أو الرسم البياني أو الجدول أو الأعضاء الخاصة بالوسائط.
{{% /alert %}}

## **فهم وراثة العنصر النائب**

العناصر النائبة تُشكل تسلسلًا هرميًا:

1. تُعرِّف شريحة رئيسية أنماطًا قابلة لإعادة الاستخدام، وفي بعض الحالات عناصر نائبة على مستوى الرئيسة.
2. تُعرِّف شريحة تخطيط الترتيب المستخدم في شريحة أو أكثر عادية ويمكن أن ترث من الرئيسة.
3. تحتوي شريحة عادية على العناصر النائبة لتلك الشريحة ويمكن أن ترث من تخطيطها.

استدعِ [IShape.GetBasePlaceholder](https://reference.aspose.com/slides/ar/net/aspose.slides/ishape/getbaseplaceholder/) للانتقال مستوى واحد أعلى في هذا التسلسل. عادةً ما تُرجع شريحة عنصر نائب تخطيطها؛ ويمكن لعنصر نائب التخطيط أن يُرجع عنصر نائب الرئيسة. تُرجع الطريقة `null` عندما لا يكون للشكل عنصر نائب أساسي.

المثال التالي يسرد العناصر النائبة على الشريحة الأولى ويُبلغ عن عناصرها النائبة الأساسية:

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

تحرير عنصر نائب على شريحة عادية يُنشئ أو يُغيّر تجاوزًا محليًا لتلك الشريحة. تحرير التخطيط أو الرئيسة المرتبطين يمكن أن يؤثر على جميع الشرائح التي لا تزال ترث ذلك الإعداد. الشكل العادي المحلي لا يمتلك عنصر نائب أساسي ولا يبدأ بالوراثة لمجرد أنه يشغل نفس الإحداثيات.

## **تغيير النص في عنصر نائب**

العناوين، العنوان المركزي، العنوان الفرعي، النص الأساسي، وعناصر نائب النص عادةً ما تدعم النص. تحقق من وجود [IAutoShape](https://reference.aspose.com/slides/ar/net/aspose.slides/iautoshape/) قبل استخدام خاصية [TextFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/iautoshape/textframe/).

هذا المثال يُحدِّث أول عنصر نائب للعنوان على الشريحة الأولى ويحفظ النتيجة:

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

هذا النمط يتجنب تحويل العناصر النائبة للصورة أو الرسم البياني أو الجدول أو الوسائط إلى [IAutoShape](https://reference.aspose.com/slides/ar/net/aspose.slides/iautoshape/). كما يحدد العنصر النائب وفقًا للغرض بدلاً من الاعتماد على فهرس شكل هش.

## **ضبط نص التوجيه على تخطيط**

نص التوجيه هو التعليمات التي تُظهر في عنصر نائب فارغ أثناء التصميم، مثل *انقر لإضافة عنوان*. اضبط نص توجيه مخصص على عنصر نائب التخطيط بدلاً من محاولة الوصول إليه عبر مجموعة أشكال الشريحة العادية. ادخل إلى التخطيط عبر [ISlide.LayoutSlide](https://reference.aspose.com/slides/ar/net/aspose.slides/islide/layoutslide/) وتكرّر عبر [ILayoutSlide.Shapes](https://reference.aspose.com/slides/ar/net/aspose.slides/ibaseslide/shapes/).

المثال التالي يغيّر توجيهات العنوان والعنوان الفرعي على التخطيط المستخدم في الشريحة الأولى:

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

نص التوجيه ليس محتوى شريحة عادية. إنه مخصص للعناصر النائبة الفارغة في تطبيقات التحرير مثل PowerPoint. بمجرد أن يضيف المستخدم أو البرنامج محتوى حقيقي، لن يُعرض النص التوجيهي بعد ذلك. تغيير التوجيه لا يحلّ محل النص الموجود على الشرائح التي تستخدم التخطيط.

## **تحديث عنصر نائب صورة**

هناك حالتان للتعامل معهما:

- إذا كان عنصر نائب الصورة مُعبَّأ بالفعل وممثَّلًا بـ [IPictureFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/ipictureframe/)، استبدل الصورة عبر [IPictureFillFormat.Picture](https://reference.aspose.com/slides/ar/net/aspose.slides/ipicturefillformat/picture/) و[ISlidesPicture.Image](https://reference.aspose.com/slides/ar/net/aspose.slides/islidespicture/image/).
- إذا كان لا يزال عنصرًا نائبًا فارغًا، أضف إطار صورة عند إحداثيات العنصر النائب باستخدام [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/ishapecollection/addpictureframe/) واحذف العنصر النائب الفارغ.

المثال التالي يدعم الحالتين ويحفظ العرض التقديمي:

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

الاستبدال الذي يُنشأ لعناصر نائب فارغة هو إطار صورة محلي، ليس عنصرًا نائبًا جديدًا، لأن خاصية [IShape.Placeholder](https://reference.aspose.com/slides/ar/net/aspose.slides/ishape/placeholder/) للقراءة فقط. يحتفظ بالموقع المحجوز لكنه لم يعد يرث سلوك العنصر النائب. إذا كان الحفاظ على علاقة العنصر النائب أمرًا أساسيًا، عدّ وعبئ العنصر النائب في PowerPoint أولًا، ثم حدّث [IPictureFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/ipictureframe/) الناتج باستخدام Aspose.Slides.

للتعامل مع شفافية الصورة، الاقتصاص، وتأثيرات خاصة أخرى، راجع [Manage Picture Frames](/slides/ar/net/picture-frame/). تلك العمليات تنتمي إلى إطار الصورة أو تعبئة الصورة، لا إلى بيانات تعريف العنصر النائب.

## **العمل مع عناصر نائب الرسم البياني والمحتوى**

يمكن تمثيل عنصر نائب رسم بياني مُعبَّأ بـ [IChart](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichart/). هذا المثال يعثر على مثل هذا الرسم البياني عبر نوع العنصر النائب وواجهة وقت التشغيل، يغيّر عنوانه، ويحفظ الملف:

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

عادةً ما يكون عنصر نائب محتوى عام من النوع [PlaceholderType.Object](https://reference.aspose.com/slides/ar/net/aspose.slides/placeholdertype/). في PowerPoint يعمل كمنطلق لعدة أنواع محتوى، بما في ذلك الرسوم البيانية والجدوال والمخططات والصور والوسائط. بعد تعبئته، افحص واجهة الشكل الفعلية لمعرفة ما يحتويه. يمكن للتخطيطات المتخصصة أيضًا أن تعرض [PlaceholderType.Chart](https://reference.aspose.com/slides/ar/net/aspose.slides/placeholdertype/)، [PlaceholderType.Table](https://reference.aspose.com/slides/ar/net/aspose.slides/placeholdertype/), [PlaceholderType.Picture](https://reference.aspose.com/slides/ar/net/aspose.slides/placeholdertype/), [PlaceholderType.Media](https://reference.aspose.com/slides/ar/net/aspose.slides/placeholdertype/), أو [PlaceholderType.Diagram](https://reference.aspose.com/slides/ar/net/aspose.slides/placeholdertype/).

لا تقوم Aspose.Slides بتحويل عنصر نائب [IAutoShape](https://reference.aspose.com/slides/ar/net/aspose.slides/iautoshape/) فارغ إلى [IChart](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichart/) بمجرد تغيير [IPlaceholder.Type](https://reference.aspose.com/slides/ar/net/aspose.slides/iplaceholder/type/); النوع للقراءة فقط. لملء رسم بياني أو منطقة محتوى فارغة برمجيًا، أضف الكائن المطلوب عند إحداثيات العنصر النائب ثم احذف العنصر النائب الفارغ. المثال التالي يقوم بذلك لرسم بياني:

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

الرسم البياني المضاف هو رسم بياني محلي عادي. يحتل مساحة العنصر النائب لكنه لا يرث من عنصر نائب التخطيط. استخدم مقالات إدارة الرسم البياني المخصصة [chart management articles](/slides/ar/net/powerpoint-charts/) عندما تحتاج إلى استبدال الفئات أو السلاسل أو بيانات دفتر العمل.

## **مثال كامل: تحديث النص أو محتوى الصورة**

المثال التالي الشامل يفتح قالبًا، يبحث في الشريحة الأولى عن عنوان أو عنصر نائب صورة، يتحقق من نوع العنصر النائب والشكل، يحدّث المحتوى المناسب، ويحفظ الناتج. يتجنب المثال الافتراض بأن هناك فهرس شكل أو تحويل كل عنصر نائب إلى نفس الواجهة.

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

## **الأسئلة الشائعة**

**ما هو العنصر النائب الأساسي؟**

العنصر النائب الأساسي هو الشكل المقابل على التخطيط أو الرئيسة الذي يرث منه عنصر نائب آخر. استخدم [IShape.GetBasePlaceholder](https://reference.aspose.com/slides/ar/net/aspose.slides/ishape/getbaseplaceholder/) لاسترجاعه. الشكل المحلي العادي يُعيد `null` لأنه ليس جزءًا من تسلسل عناصر النائب.

**هل يمكنني تغيير جميع عناوين الشرائح عن طريق تحرير عنصر نائب تخطيط؟**

يمكنك تعديل التنسيق الوراثي أو نص التوجيه عبر التخطيط، لكن محتوى العنوان الموجود يُخزَّن على الشرائح العادية. لاستبدال نص العنوان الفعلي عبر العرض بأكمله، كرّر على الشرائح و حدّث كل عنصر نائب للعنوان.

**كيف أدير عناصر نائب التاريخ، رقم الشريحة، الرأس، والتذييل؟**

استخدم مديري الرأس والتذييل في نطاق الشريحة المناسب، التخطيط، الرئيسة، الملاحظات، أو النسخة المطبوعة. راجع [Manage Presentation Header and Footer](/slides/ar/net/presentation-header-and-footer/) للحصول على أمثلة كاملة.