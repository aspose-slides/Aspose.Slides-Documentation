---
title: دریافت ویژگی‌های مؤثر شکل از ارائه‌ها در .NET
linktitle: ویژگی‌های مؤثر
type: docs
weight: 50
url: /fa/net/shape-effective-properties/
keywords:
- ویژگی‌های شکل
- ویژگی‌های دوربین
- نورپردازی
- شکل برجسته
- قاب متن
- سبک متن
- ارتفاع قلم
- قالب پر کردن
- PowerPoint
- ارائه
- .NET
- C#
- Aspose.Slides
description: "کشف کنید Aspose.Slides برای .NET چگونه ویژگی‌های مؤثر شکل را برای رندر دقیق PowerPoint محاسبه و اعمال می‌کند."
---
## **Overview**

این موضوع تفاوت بین ویژگی‌های **local** و **effective** را توضیح می‌دهد. مقادیر محلی، مقادیری هستند که مستقیماً در یک سطح خاص قالب‌بندی تنظیم می‌شوند، مانند:

1. ویژگی‌های بخش در یک اسلاید.  
1. سبک‌های متن شکل نمونه در یک طرح‌بندی یا اسلاید مستر، وقتی‌که شکل قاب متن بخش دارای آن باشد.  
1. تنظیمات متن سراسری در یک ارائه.

مقادیر محلی می‌توانند در هر سطحی تعریف یا حذف شوند. هنگامی که Aspose.Slides به قالب‌بندی نهایی «as rendered» نیاز دارد، زنجیره وراثت را حل می‌کند و مقادیر **effective** را برمی‌گرداند. می‌توانید با فراخوانی متد `GetEffective` روی شیء قالب‌بندی محلی، این مقادیر را دریافت کنید.

مثال زیر نشان می‌دهد چگونه مقادیر effective را به دست آورید. فرض می‌شود اولین شکل در اولین اسلاید یک [IAutoShape](https://reference.aspose.com/slides/fa/net/aspose.slides/iautoshape/) با یک قاب متن و حداقل یک بخش باشد.

```csharp
using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = (IAutoShape)slide.Shapes[0];

var localTextFrameFormat = shape.TextFrame.TextFrameFormat;
var effectiveTextFrameFormat = localTextFrameFormat.GetEffective();

var portion = shape.TextFrame.Paragraphs[0].Portions[0];
var localPortionFormat = portion.PortionFormat;
var effectivePortionFormat = localPortionFormat.GetEffective();
```

{{% alert color="primary" %}}
داده‌های قالب‌بندی Effective، قالب‌بندی محاسبه‌شده فعلی پس از اعمال وراثت را نشان می‌دهد. در پیاده‌سازی فعلی، برخی از اشیای دادهٔ Effective، مانند [IPortionFormatEffectiveData](https://reference.aspose.com/slides/fa/net/aspose.slides/iportionformateffectivedata/)، ممکن است به‌صورت داخلی کش شوند. فراخوانی مجدد `GetEffective` پس از تغییر قالب‌بندی پدر یا وراثتی می‌تواند کش را تازه‌سازی کند و شیء قبلاً به‌دست آمده ممکن است دیگر نمایانگر وضعیت قبلی نباشد. اگر نیاز دارید مقادیر effective را برای استفادهٔ بعدی حفظ کنید، ویژگی‌های مورد نیاز مانند ارتفاع قلم، رنگ پر، سبک قلم یا تراز شدن را در شیء دادهٔ خود کپی کنید.
{{% /alert %}}

## **Get Effective Properties of a Camera**

Aspose.Slides به شما امکان می‌دهد ویژگی‌های effective دوربین را دریافت کنید. اینترفیس [ICameraEffectiveData](https://reference.aspose.com/slides/fa/net/aspose.slides/icameraeffectivedata/) یک شیء غیرقابل تغییر است که ویژگی‌های effective دوربین را شامل می‌شود. یک نمونهٔ [ICameraEffectiveData](https://reference.aspose.com/slides/fa/net/aspose.slides/icameraeffectivedata/) از طریق [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/fa/net/aspose.slides/ithreedformateffectivedata/) در دسترس قرار می‌گیرد که مقادیر effective برای [IThreeDFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/ithreedformat/) را فراهم می‌کند.

کد نمونهٔ زیر نشان می‌دهد چگونه ویژگی‌های effective دوربین را دریافت کنید. فرض می‌شود اولین شکل در اولین اسلاید دارای قالب‌بندی سه‌بعدی باشد.

```csharp
using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = slide.Shapes[0];

var threeDEffectiveData = shape.ThreeDFormat.GetEffective();

Console.WriteLine("= Effective camera properties =");
Console.WriteLine("Type: " + threeDEffectiveData.Camera.CameraType);
Console.WriteLine("Field of view: " + threeDEffectiveData.Camera.FieldOfViewAngle);
Console.WriteLine("Zoom: " + threeDEffectiveData.Camera.Zoom);
```

## **Get Effective Properties of a Light Rig**

Aspose.Slides به شما امکان می‌دهد ویژگی‌های effective تنظیمات نور را دریافت کنید. اینترفیس [ILightRigEffectiveData](https://reference.aspose.com/slides/fa/net/aspose.slides/ilightrigeffectivedata/) یک شیء غیرقابل تغییر است که ویژگی‌های effective تنظیمات نور را شامل می‌شود. یک نمونهٔ [ILightRigEffectiveData](https://reference.aspose.com/slides/fa/net/aspose.slides/ilightrigeffectivedata/) از طریق [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/fa/net/aspose.slides/ithreedformateffectivedata/) در دسترس قرار می‌گیرد که مقادیر effective برای [IThreeDFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/ithreedformat/) را فراهم می‌کند.

کد نمونهٔ زیر نشان می‌دهد چگونه ویژگی‌های effective تنظیمات نور را دریافت کنید. فرض می‌شود اولین شکل در اولین اسلاید دارای قالب‌بندی سه‌بعدی باشد.

```csharp
using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = slide.Shapes[0];

var threeDEffectiveData = shape.ThreeDFormat.GetEffective();

Console.WriteLine("= Effective light rig properties =");
Console.WriteLine("Type: " + threeDEffectiveData.LightRig.LightType);
Console.WriteLine("Direction: " + threeDEffectiveData.LightRig.Direction);
```

## **Get Effective Properties of a Bevel Shape**

Aspose.Slides به شما امکان می‌دهد ویژگی‌های effective برجستگی (Bevel) یک شکل را دریافت کنید. اینترفیس [IShapeBevelEffectiveData](https://reference.aspose.com/slides/fa/net/aspose.slides/ishapebeveleffectivedata/) یک شیء غیرقابل تغییر است که ویژگی‌های effective برجستگی برای یک شکل را شامل می‌شود. یک نمونهٔ [IShapeBevelEffectiveData](https://reference.aspose.com/slides/fa/net/aspose.slides/ishapebeveleffectivedata/) از طریق [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/fa/net/aspose.slides/ithreedformateffectivedata/) در دسترس قرار می‌گیرد که مقادیر effective برای [IThreeDFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/ithreedformat/) را فراهم می‌کند.

کد نمونهٔ زیر نشان می‌دهد چگونه ویژگی‌های effective برجستگی بالایی یک شکل را دریافت کنید. فرض می‌شود اولین شکل در اولین اسلاید دارای قالب‌بندی سه‌بعدی باشد.

```csharp
using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = slide.Shapes[0];

var threeDEffectiveData = shape.ThreeDFormat.GetEffective();

Console.WriteLine("= Effective shape's top face relief properties =");
Console.WriteLine("Type: " + threeDEffectiveData.BevelTop.BevelType);
Console.WriteLine("Width: " + threeDEffectiveData.BevelTop.Width);
Console.WriteLine("Height: " + threeDEffectiveData.BevelTop.Height);
```

## **Get Effective Properties of a Text Frame**

با استفاده از Aspose.Slides می‌توانید ویژگی‌های effective یک قاب متن را دریافت کنید. اینترفیس [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/fa/net/aspose.slides/itextframeformateffectivedata/) شامل ویژگی‌های قالب‌بندی effective قاب متن است.

کد نمونهٔ زیر نشان می‌دهد چگونه ویژگی‌های قالب‌بندی effective قاب متن را دریافت کنید. فرض می‌شود اولین شکل در اولین اسلاید یک [IAutoShape](https://reference.aspose.com/slides/fa/net/aspose.slides/iautoshape/) با یک قاب متن باشد.

```csharp
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

## **Get Effective Properties of a Text Style**

با استفاده از Aspose.Slides می‌توانید ویژگی‌های effective یک سبک متن را دریافت کنید. اینترفیس [ITextStyleEffectiveData](https://reference.aspose.com/slides/fa/net/aspose.slides/itextstyleeffectivedata/) شامل ویژگی‌های سبک متن effective است.

کد نمونهٔ زیر نشان می‌دهد چگونه ویژگی‌های سبک متن effective را دریافت کنید. فرض می‌شود اولین شکل در اولین اسلاید یک [IAutoShape](https://reference.aspose.com/slides/fa/net/aspose.slides/iautoshape/) با یک قاب متن باشد.

```csharp
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

## **Get the Effective Font Height Value**

با استفاده از Aspose.Slides می‌توانید ارتفاع قلم effective را دریافت کنید. کد زیر نشان می‌دهد چگونه ارتفاع قلم effective یک بخش پس از تنظیم مقادیر محلی ارتفاع قلم در سطوح مختلف ساختار ارائه تغییر می‌کند.

```csharp
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

## **Get the Effective Fill Format for a Table**

با استفاده از Aspose.Slides می‌توانید قالب‌بندی پر شدن effective برای قسمت‌های مختلف جدول را دریافت کنید. اینترفیس [IFillFormatEffectiveData](https://reference.aspose.com/slides/fa/net/aspose.slides/ifillformateffectivedata/) شامل ویژگی‌های قالب‌بندی پر شدن effective است. قالب‌بندی سلول نسبت به قالب‌بندی ردیف اولویت بالاتری دارد، قالب‌بندی ردیف نسبت به قالب‌بندی ستون، و قالب‌بندی ستون نسبت به قالب‌بندی کل جدول اولویت بیشتری دارد.

در نتیجه، ویژگی‌های [ICellFormatEffectiveData](https://reference.aspose.com/slides/fa/net/aspose.slides/icellformateffectivedata/) برای رسم سلول جدول استفاده می‌شوند. کد نمونهٔ زیر نشان می‌دهد چگونه قالب‌بندی پر شدن effective برای قسمت‌های مختلف جدول را دریافت کنید. فرض می‌شود اولین شکل در اولین اسلاید یک [ITable](https://reference.aspose.com/slides/fa/net/aspose.slides/itable/) باشد.

```csharp
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

## **FAQ**

**آیا `GetEffective` یک snapshot برمی‌گرداند؟**

همیشه نیست. دادهٔ Effective نمایانگر قالب‌بندی محاسبه‌شده پس از اعمال وراثت است، ولی برخی از اشیای دادهٔ Effective می‌توانند به‌صورت داخلی کش شوند. فراخوانی بعدی `GetEffective` ممکن است قالب‌بندی را دوباره محاسبه کند و کش را تازه‌سازی کند، بنابراین شیء قبلاً به‌دست آمده نباید به‌عنوان یک snapshot پایدار در نظر گرفته شود.

**چه زمانی باید دوباره ویژگی‌های effective را بخوانم؟**

بعد از تغییر قالب‌بندی محلی، سبک‌های پدر، قالب‌بندی طرح‌بندی، قالب‌بندی مستر یا پیش‌فرض‌های سطح ارائه، `GetEffective` را دوباره فراخوانی کنید. فراخوانی بعدی سلسله‌مراتب قالب‌بندی را مجدداً ارزیابی می‌کند و نتیجهٔ effective فعلی را برمی‌گرداند.

**آیا تغییر یا حذف یک اسلاید طرح‌بندی/مستر بر ویژگی‌های effective که قبلاً دریافت شده‌اند تأثیر می‌گذارد؟**

بله، اما تغییر در فراخوانی بعدی `GetEffective` منعکس می‌شود. اگر منبع قالب‌بندی پدر تغییر یا حذف شود، دادهٔ Effective قبلاً به‌دست آمده ممکن است قدیمی باشد. پس از فراخوانی مجدد `GetEffective`، Aspose.Slides درخت قالب‌بندی را دوباره ارزیابی می‌کند و قلم‌ها، رنگ‌ها، اندازه‌ها یا مقادیر دیگر ممکن است تغییر کنند.

**آیا می‌توانم مقادیر را از طریق اشیای دادهٔ Effective اصلاح کنم؟**

خیر. اشیای دادهٔ Effective فقط مقادیر محاسبه‌شده را نشان می‌دهند. تغییرات را در اشیای قالب‌بندی محلی اعمال کنید و سپس مجدداً مقادیر effective را دریافت کنید.

**اگر یک ویژگی در سطح شکل، در طرح‌بندی/مستر یا در تنظیمات سراسری تنظیم نشده باشد چه می‌شود؟**

مقدار effective بر پایه مکانیزم پیش‌فرض تعیین می‌شود که شامل پیش‌فرض‌های PowerPoint و Aspose.Slides می‌شود. آن مقدار حل‌شده بخشی از دادهٔ Effective فعلی می‌شود.

**از یک مقدار قلم effective، آیا می‌توانم تشخیص دهم کدام سطح اندازه یا نوع قلم را فراهم کرده است؟**

به‌صورت مستقیم نمی‌توان. دادهٔ Effective مقدار نهایی را برمی‌گرداند. برای پیدا کردن منبع، مقادیر محلی را در بخش، پاراگراف، قاب متن و سبک‌های متن در طرح‌بندی، مستر و سطوح ارائه بررسی کنید تا ببینید اولین تعریف صریح کجا قرار دارد.

**چرا گاهی مقدارهای effective شبیه مقدارهای محلی به نظر می‌آیند؟**

چون مقدار محلی در نهایت نهایی شده است (نیازی به وراثت از سطوح بالاتر نبوده). در این حالت مقدار effective با مقدار محلی مطابقت دارد.

**چه زمانی باید از ویژگی‌های effective استفاده کنم و چه زمانی فقط با مقدارهای محلی کار کنم؟**

وقتی به نتیجهٔ «as rendered» پس از اعمال تمام وراثت‌ها نیاز دارید (مثل هم‌ترازی رنگ‌ها، تو رفتگی‌ها یا اندازه‌ها) از دادهٔ Effective استفاده کنید. اگر می‌خواهید این مقادیر را صرف‌نظر از تغییرات بعدی قالب‌بندی حفظ کنید، ویژگی‌های مورد نیاز را در شیء خود کپی کنید. اگر می‌خواهید قالب‌بندی را در سطح خاصی تغییر دهید، ویژگی‌های محلی را اصلاح کنید و سپس، در صورت نیاز، دادهٔ Effective را دوباره بخوانید تا نتیجه را تأیید کنید.