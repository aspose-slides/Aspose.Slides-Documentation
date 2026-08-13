---  
title: دریافت خصوصیات مؤثر شکل از ارائه‌ها در .NET  
linktitle: خصوصیات مؤثر  
type: docs  
weight: 50  
url: /fa/net/shape-effective-properties/  
keywords:  
- خصوصیات شکل  
- خصوصیات دوربین  
- نورپردازی  
- شکل برجسته  
- قاب متن  
- سبک متن  
- ارتفاع قلم  
- قالب پرکردن  
- PowerPoint  
- ارائه  
- .NET  
- C#  
- Aspose.Slides  
description: "کشف کنید چگونه Aspose.Slides برای .NET خصوصیات مؤثر شکل را محاسبه و اعمال می‌کند تا رندر دقیق PowerPoint حاصل شود."  
---
## **نمای کلی**

این موضوع تفاوت بین خصوصیات **محلی** و **موثر** را توضیح می‌دهد. مقادیر محلی، مقادیری هستند که به‌ طور مستقیم در یک سطح خاص قالب‌بندی تنظیم می‌شوند، از جمله:
1. خصوصیات بخشی در یک اسلاید.
1. سبک‌های متن شکل نمونه در یک طرح‌بندی یا اسلاید اصلی، زمانی که شکل قاب متن بخشی دارای آن باشد.
1. تنظیمات متن سراسری در ارائه.

مقادیر محلی می‌توانند در هر سطحی تعریف یا حذف شوند. وقتی Aspose.Slides به قالب‌بندی نهایی «به‌صورت رندر‌شده» نیاز دارد، زنجیره وراثت را حل می‌کند و مقادیر **موثر** را باز می‌گرداند. شما می‌توانید با فراخوانی متد `GetEffective` بر روی شیء قالب‌بندی محلی، آن‌ها را دریافت کنید.

مثال زیر نحوه دریافت مقادیر موثر را نشان می‌دهد. فرض می‌شود که اولین شکل در اولین اسلاید یک [IAutoShape](https://reference.aspose.com/slides/fa/net/aspose.slides/iautoshape/) با یک قاب متن و حداقل یک بخش باشد.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = (IAutoShape)slide.Shapes[0];

var localTextFrameFormat = shape.TextFrame.TextFrameFormat;
var effectiveTextFrameFormat = localTextFrameFormat.GetEffective();

var portion = shape.TextFrame.Paragraphs[0].Portions[0];
var localPortionFormat = portion.PortionFormat;
var effectivePortionFormat = localPortionFormat.GetEffective();
```

{{% alert color="info" %}}
داده‌های قالب‌بندی موثر نشان‌دهنده قالب‌بندی محاسبه‌شده فعلی پس از اعمال وراثت هستند. در پیاده‌سازی فعلی، برخی از اشیای داده موثر، مانند [IPortionFormatEffectiveData](https://reference.aspose.com/slides/fa/net/aspose.slides/iportionformateffectivedata/)، ممکن است به‌ صورت داخلی کش شوند. فراخوانی دوباره `GetEffective` پس از تغییر قالب‌بندی والد یا ارث‌گیری شده می‌تواند کش را تازه کند و شیء قبلاً به‌دست آمده ممکن است دیگر حالت قبلی را نشان ندهد. اگر نیاز دارید مقادیر موثر را برای استفاده بعدی حفظ کنید، ویژگی‌های مورد نیاز مانند ارتفاع فونت، رنگ پرکن، سبک فونت یا تراز را به شیء داده خود کپی کنید.
{{% /alert %}}

## **دریافت خصوصیات موثر دوربین**

Aspose.Slides به شما امکان دریافت خصوصیات موثر یک دوربین را می‌دهد. رابط [ICameraEffectiveData](https://reference.aspose.com/slides/fa/net/aspose.slides/icameraeffectivedata/) یک شیء غیرقابل تغییر را نشان می‌دهد که شامل خصوصیات موثر دوربین است. یک نمونهٔ [ICameraEffectiveData](https://reference.aspose.com/slides/fa/net/aspose.slides/icameraeffectivedata/) از طریق [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/fa/net/aspose.slides/ithreedformateffectivedata/) در دسترس قرار می‌گیرد که مقادیر موثر برای [IThreeDFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/ithreedformat/) را ارائه می‌دهد.

نمونه کد زیر نحوه دریافت خصوصیات موثر برای دوربین را نشان می‌دهد. فرض می‌شود اولین شکل در اولین اسلاید دارای قالب‌بندی سه‌بعدی باشد.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = slide.Shapes[0];

var threeDEffectiveData = shape.ThreeDFormat.GetEffective();

Console.WriteLine("= Effective camera properties =");
Console.WriteLine("Type: " + threeDEffectiveData.Camera.CameraType);
Console.WriteLine("Field of view: " + threeDEffectiveData.Camera.FieldOfViewAngle);
Console.WriteLine("Zoom: " + threeDEffectiveData.Camera.Zoom);
```

## **دریافت خصوصیات موثر نورپردازی**

Aspose.Slides به شما امکان دریافت خصوصیات موثر یک دستگاه نورپردازی را می‌دهد. رابط [ILightRigEffectiveData](https://reference.aspose.com/slides/fa/net/aspose.slides/ilightrigeffectivedata/) یک شیء غیرقابل تغییر را نشان می‌دهد که شامل خصوصیات موثر دستگاه نورپردازی است. یک نمونهٔ [ILightRigEffectiveData](https://reference.aspose.com/slides/fa/net/aspose.slides/ilightrigeffectivedata/) از طریق [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/fa/net/aspose.slides/ithreedformateffectivedata/) در دسترس قرار می‌گیرد که مقادیر موثر برای [IThreeDFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/ithreedformat/) را ارائه می‌دهد.

نمونه کد زیر نحوه دریافت خصوصیات موثر برای نورپردازی را نشان می‌دهد. فرض می‌شود اولین شکل در اولین اسلاید دارای قالب‌بندی سه‌بعدی باشد.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = slide.Shapes[0];

var threeDEffectiveData = shape.ThreeDFormat.GetEffective();

Console.WriteLine("= Effective light rig properties =");
Console.WriteLine("Type: " + threeDEffectiveData.LightRig.LightType);
Console.WriteLine("Direction: " + threeDEffectiveData.LightRig.Direction);
```

## **دریافت خصوصیات موثر برجستگی شکل**

Aspose.Slides به شما امکان دریافت خصوصیات موثر برجستگی یک شکل را می‌دهد. رابط [IShapeBevelEffectiveData](https://reference.aspose.com/slides/fa/net/aspose.slides/ishapebeveleffectivedata/) یک شیء غیرقابل تغییر را نشان می‌دهد که شامل خصوصیات موثر برجستگی برای یک شکل است. یک نمونهٔ [IShapeBevelEffectiveData](https://reference.aspose.com/slides/fa/net/aspose.slides/ishapebeveleffectivedata/) از طریق [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/fa/net/aspose.slides/ithreedformateffectivedata/) در دسترس قرار می‌گیرد که مقادیر موثر برای [IThreeDFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/ithreedformat/) را ارائه می‌دهد.

نمونه کد زیر نحوه دریافت خصوصیات موثر برای برجستگی بالای یک شکل را نشان می‌دهد. فرض می‌شود اولین شکل در اولین اسلاید دارای قالب‌بندی سه‌بعدی باشد.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = slide.Shapes[0];

var threeDEffectiveData = shape.ThreeDFormat.GetEffective();

Console.WriteLine("= Effective shape's top face relief properties =");
Console.WriteLine("Type: " + threeDEffectiveData.BevelTop.BevelType);
Console.WriteLine("Width: " + threeDEffectiveData.BevelTop.Width);
Console.WriteLine("Height: " + threeDEffectiveData.BevelTop.Height);
```

## **دریافت خصوصیات موثر قاب متن**

با استفاده از Aspose.Slides می‌توانید خصوصیات موثر یک قاب متن را دریافت کنید. رابط [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/fa/net/aspose.slides/itextframeformateffectivedata/) شامل خصوصیات قالب‌بندی موثر قاب متن است.

نمونه کد زیر نحوه دریافت خصوصیات قالب‌بندی موثر قاب متن را نشان می‌دهد. فرض می‌شود اولین شکل در اولین اسلاید یک [IAutoShape](https://reference.aspose.com/slides/fa/net/aspose.slides/iautoshape/) با یک قاب متن باشد.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = (IAutoShape)slide.Shapes[0];

var textFrameFormat = shape.TextFrame.TextFrameFormat;
var effectiveTextFrameFormat = textFrameFormat.GetEffective();

Console.WriteLine("Anchoring type: " + effectiveTextFrameFormat.AnchoringType);
Console.WriteLine("Autofit type: " + effectiveTextFrameFormat.AutofitType);
Console.WriteLine("Text vertical type: " + effectiveTextFrameFormat.TextVerticalType);
Console.WriteLine("Margins");
Console.WriteLine("   Left: " + effectiveTextFrameFormat.MarginLeft);
Console.WriteLine("   Top: " + effectiveTextFrameFormat.MarginTop);
Console.WriteLine("   Right: " + effectiveTextFrameFormat.MarginRight);
Console.WriteLine("   Bottom: " + effectiveTextFrameFormat.MarginBottom);
```

## **دریافت خصوصیات موثر سبک متن**

با استفاده از Aspose.Slides می‌توانید خصوصیات موثر یک سبک متن را دریافت کنید. رابط [ITextStyleEffectiveData](https://reference.aspose.com/slides/fa/net/aspose.slides/itextstyleeffectivedata/) شامل خصوصیات موثر سبک متن است.

نمونه کد زیر نحوه دریافت خصوصیات موثر سبک متن را نشان می‌دهد. فرض می‌شود اولین شکل در اولین اسلاید یک [IAutoShape](https://reference.aspose.com/slides/fa/net/aspose.slides/iautoshape/) با یک قاب متن باشد.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = (IAutoShape)slide.Shapes[0];

var effectiveTextStyle = shape.TextFrame.TextFrameFormat.TextStyle.GetEffective();
var levelCount = 9;

for (var levelIndex = 0; levelIndex < levelCount; levelIndex++)
{
    var effectiveStyleLevel = effectiveTextStyle.GetLevel(levelIndex);
    Console.WriteLine("= Effective paragraph formatting for style level #" + levelIndex + " =");

    Console.WriteLine("Depth: " + effectiveStyleLevel.Depth);
    Console.WriteLine("Indent: " + effectiveStyleLevel.Indent);
    Console.WriteLine("Alignment: " + effectiveStyleLevel.Alignment);
    Console.WriteLine("Font alignment: " + effectiveStyleLevel.FontAlignment);
}
```

## **دریافت مقدار مؤثر ارتفاع قلم**

با استفاده از Aspose.Slides می‌توانید ارتفاع قلم مؤثر را دریافت کنید. کد زیر نشان می‌دهد که چگونه ارتفاع قلم مؤثر یک بخش پس از تنظیم مقادیر محلی ارتفاع قلم در سطوح مختلف ساختار ارائه تغییر می‌کند.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 75, false);
autoShape.AddTextFrame("");

var paragraph = autoShape.TextFrame.Paragraphs[0];
paragraph.Portions.Clear();

var firstPortion = new Portion("Sample text with first portion");
var secondPortion = new Portion(" and second portion.");

paragraph.Portions.Add(firstPortion);
paragraph.Portions.Add(secondPortion);

var firstPortionFormatEffectiveData = firstPortion.PortionFormat.GetEffective();
var secondPortionFormatEffectiveData = secondPortion.PortionFormat.GetEffective();

Console.WriteLine("Effective font height just after creation:");
Console.WriteLine("Portion #0: " + firstPortionFormatEffectiveData.FontHeight);
Console.WriteLine("Portion #1: " + secondPortionFormatEffectiveData.FontHeight);

presentation.DefaultTextStyle.GetLevel(0).DefaultPortionFormat.FontHeight = 24;
firstPortionFormatEffectiveData = firstPortion.PortionFormat.GetEffective();
secondPortionFormatEffectiveData = secondPortion.PortionFormat.GetEffective();

Console.WriteLine("Effective font height after setting the presentation default font height:");
Console.WriteLine("Portion #0: " + firstPortionFormatEffectiveData.FontHeight);
Console.WriteLine("Portion #1: " + secondPortionFormatEffectiveData.FontHeight);

paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight = 40;
firstPortionFormatEffectiveData = firstPortion.PortionFormat.GetEffective();
secondPortionFormatEffectiveData = secondPortion.PortionFormat.GetEffective();

Console.WriteLine("Effective font height after setting paragraph default font height:");
Console.WriteLine("Portion #0: " + firstPortionFormatEffectiveData.FontHeight);
Console.WriteLine("Portion #1: " + secondPortionFormatEffectiveData.FontHeight);

firstPortion.PortionFormat.FontHeight = 55;
firstPortionFormatEffectiveData = firstPortion.PortionFormat.GetEffective();
secondPortionFormatEffectiveData = secondPortion.PortionFormat.GetEffective();

Console.WriteLine("Effective font height after setting portion #0 font height:");
Console.WriteLine("Portion #0: " + firstPortionFormatEffectiveData.FontHeight);
Console.WriteLine("Portion #1: " + secondPortionFormatEffectiveData.FontHeight);

secondPortion.PortionFormat.FontHeight = 18;
firstPortionFormatEffectiveData = firstPortion.PortionFormat.GetEffective();
secondPortionFormatEffectiveData = secondPortion.PortionFormat.GetEffective();

Console.WriteLine("Effective font height after setting portion #1 font height:");
Console.WriteLine("Portion #0: " + firstPortionFormatEffectiveData.FontHeight);
Console.WriteLine("Portion #1: " + secondPortionFormatEffectiveData.FontHeight);

presentation.Save("SetLocalFontHeightValues.pptx", SaveFormat.Pptx);
```

## **دریافت قالب پر کردن مؤثر برای جدول**

با استفاده از Aspose.Slides می‌توانید قالب‌پر کردن مؤثر برای قسمت‌های مختلف جدول را دریافت کنید. رابط [IFillFormatEffectiveData](https://reference.aspose.com/slides/fa/net/aspose.slides/ifillformateffectivedata/) شامل خصوصیات قالب‌پر کردن مؤثر است. قالب‌بندی سلول دارای اولویت بالاتری نسبت به قالب‌بندی ردیف، قالب‌بندی ردیف نسبت به قالب‌بندی ستون و قالب‌بندی ستون نسبت به قالب‌بندی کل جدول است.

در نتیجه، خصوصیات [ICellFormatEffectiveData](https://reference.aspose.com/slides/fa/net/aspose.slides/icellformateffectiveData/) برای رسم سلول جدول استفاده می‌شوند. نمونه کد زیر نشان می‌دهد چگونه قالب‌پر کردن مؤثر برای قسمت‌های مختلف جدول دریافت شود. فرض می‌شود اولین شکل در اولین اسلاید یک [ITable](https://reference.aspose.com/slides/fa/net/aspose.slides/itable/) باشد.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var table = (ITable)presentation.Slides[0].Shapes[0];

var tableFormatEffective = table.TableFormat.GetEffective();
var rowFormatEffective = table.Rows[0].RowFormat.GetEffective();
var columnFormatEffective = table.Columns[0].ColumnFormat.GetEffective();
var cellFormatEffective = table[0, 0].CellFormat.GetEffective();

var tableFillFormatEffective = tableFormatEffective.FillFormat;
var rowFillFormatEffective = rowFormatEffective.FillFormat;
var columnFillFormatEffective = columnFormatEffective.FillFormat;
var cellFillFormatEffective = cellFormatEffective.FillFormat;
```

## **پرسش‌های متداول**

### آیا `GetEffective` یک snapshot برمی‌گرداند؟

همیشه نیست. داده‌های مؤثر نمایانگر قالب‌بندی محاسبه‌شده پس از اعمال وراثت هستند، اما برخی از اشیای داده مؤثر می‌توانند به‌صورت داخلی کش شوند. فراخوانی بعدی `GetEffective` ممکن است قالب‌بندی را دوباره محاسبه کند و داده‌های کش‌شده را تازه‌سازی کند، بنابراین نباید شیء قبلاً به‌دست آمده را به‌عنوان یک snapshot پایدار در نظر گرفت.

### کی باید مجدداً خصوصیات مؤثر را بخوانم؟

پس از تغییر قالب‌بندی محلی، سبک‌های والد، قالب‌بندی طرح‌بندی، قالب‌بندی اسلاید اصلی یا تنظیمات پیش‌فرض سطح ارائه، دوباره `GetEffective` را فراخوانی کنید. فراخوانی بعدی سیر سلسله‌مراتبی قالب‌بندی را دوباره ارزیابی می‌کند و نتیجهٔ مؤثر فعلی را باز می‌گرداند.

### آیا تغییر یا حذف یک اسلاید طرح‌بندی/اصلی بر خصوصیات مؤثری که قبلاً دریافت شده‌اند تأثیر می‌گذارد؟

بله، اما تغییر در فراخوانی بعدی `GetEffective` منعکس می‌شود. اگر منبع قالب‌بندی والد تغییر یا حذف شود، داده‌های مؤثر قبلاً به‌دست آمده ممکن است منسوخ شوند. پس از فراخوانی مجدد `GetEffective`، Aspose.Slides درخت قالب‌بندی را دوباره ارزیابی می‌کند و قلم‌ها، رنگ‌ها، اندازه‌ها یا سایر مقادیر ممکن است تغییر کنند.

### آیا می‌توانم مقادیر را از طریق اشیای داده مؤثر تغییر دهم؟

خیر. اشیای داده مؤثر فقط مقادیر محاسبه‌شده را نمایش می‌دهند. تغییرات را در اشیای قالب‌بندی محلی اعمال کنید و سپس مقادیر مؤثر را دوباره دریافت کنید.

### چه اتفاقی می‌افتد اگر یک ویژگی در سطح شکل، طرح‌بندی/اسلاید اصلی یا تنظیمات سراسری تنظیم نشده باشد؟

مقدار مؤثر توسط سازوکار پیش‌فرض تعیین می‌شود که شامل پیش‌فرض‌های PowerPoint و Aspose.Slides می‌باشد. آن مقدار حل‌شده بخشی از دادهٔ مؤثر فعلی می‌شود.

### آیا می‌توانم از مقدار مؤثر فونت بفهمم که کدام سطح اندازه یا نوع قلم را فراهم کرده است؟

به‌طور مستقیم نیست. دادهٔ مؤثر فقط مقدار نهایی را برمی‌گرداند. برای پیدا کردن منبع، مقادیر محلی را در بخش، پاراگراف، قاب متن و سبک‌های متن در سطوح طرح‌بندی، اسلاید اصلی و ارائه بررسی کنید تا ببینید اولین تعریف صریح در کجا قرار دارد.

### چرا گاهی مقادیر مؤثر شبیه مقادیر محلی به نظر می‌رسند؟

زیرا مقدار محلی در نهایت نهایی شد (نیازی به وراثت از سطوح بالاتر نبود). در چنین مواردی، مقدار مؤثر با مقدار محلی یکسان است.

### کی باید از خصوصیات مؤثر استفاده کنم و کی فقط با خصوصیات محلی کار کنم؟

داده‌های مؤثر را زمانی استفاده کنید که به نتیجهٔ «به‌صورت رندر‌شده» پس از اعمال تمام وراثت نیاز دارید، مثلاً برای هماهنگ‌سازی رنگ‌ها، تورفتگی‌ها یا اندازه‌ها. اگر می‌خواهید این مقادیر را صرف‌نظر از تغییرات بعدی قالب‌بندی حفظ کنید، ویژگی‌های مورد نیاز را در شیء خود کپی کنید. اگر نیاز به تغییر قالب‌بندی در سطح خاصی دارید، ویژگی‌های محلی را تنظیم کنید و سپس در صورت نیاز، دوباره داده‌های مؤثر را خوانده تا نتیجه را تأیید کنید.