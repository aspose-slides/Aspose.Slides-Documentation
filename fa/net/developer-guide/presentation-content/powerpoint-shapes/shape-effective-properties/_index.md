---
title: دریافت ویژگی‌های مؤثر شکل از ارائه‌ها در .NET
linktitle: ویژگی‌های مؤثر
type: docs
weight: 50
url: /fa/net/shape-effective-properties/
keywords:
- ویژگی‌های شکل
- ویژگی‌های دوربین
- نظام نورپردازی
- ویژگی‌های برش شکل
- قاب متن
- سبک متن
- ارتفاع قلم
- قالب پر شدن
- پاورپوینت
- ارائه
- .NET
- C#
- Aspose.Slides
description: "یاد بگیرید چگونه از Aspose.Slides برای .NET استفاده کنید تا قالب‌بندی شکل‌های محلی، ارث‌برده و مؤثر را در ارائه‌های PowerPoint تشخیص دهید."
---
## **درک ویژگی‌های محلی، ارث‌برده و مؤثر**
PowerPoint قالب‌بندی می‌تواند از چندین منبع سرچشمه بگیرد. مقداری که مستقیماً بر روی یک شی ذخیره می‌شود **مقدار محلی** آن است. اگر آن مقدار تنظیم نشده باشد، PowerPoint به منابع قالب‌بندی والد نگاه می‌کند، مانند پیش‌فرض پاراگراف، سبک متن، طرح یا اسلاید اصلی، تم یا پیش‌فرض‌های سطح ارائه. آن مقادیر **مقادیر ارث‌برده** نامیده می‌شوند. مقداری که پس از حل کل سلسله‌مراتب باقی می‌ماند **مقدار مؤثر** است — مقداری که برای رندر شی استفاده می‌شود.

به عنوان مثال، ممکن است یک بخش متن ارتفاع قلم خود را تعریف نکند. مقدار **محلی** آن بخش [FontHeight](https://reference.aspose.com/slides/fa/net/aspose.slides/ibaseportionformat/fontheight/) سپس `float.NaN` است که به معنای «در اینجا تنظیم نشده» می‌باشد. این بخش می‌تواند ارتفاعی را از پاراگراف خود، سبک متن پیش‌فرض ارائه یا منبع قابل‌اعمال دیگر به ارث ببرد. فراخوانی [GetEffective](https://reference.aspose.com/slides/fa/net/aspose.slides/iportionformat/geteffective/) بر روی فرمت بخش، ارتفاع نهایی حل‌شده را برمی‌گرداند.

از دو نوع داده قالب‌بندی برای مقاصد مختلف استفاده کنید:

- خواندن یا تغییر شی قالب محلی، مانند [IPortionFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/iportionformat/)، زمانی که نیاز دارید کنترل کنید مقدار از کجا تعریف شده است.
- خواندن شی داده مؤثر، مانند [IPortionFormatEffectiveData](https://reference.aspose.com/slides/fa/net/aspose.slides/iportionformateffectivedata/)، زمانی که به نتیجه نهایی رندر شده نیاز دارید. داده‌های مؤثر فقط‑خواندنی هستند.

## **مقایسه مقادیر محلی، ارث‌برده و مؤثر**
مثال کامل زیر یک شکل ایجاد می‌کند و ارتفاع‌های قلم را در سطوح ارائه، پاراگراف و بخش اعمال می‌نماید. در هر گام مقادیر تعریف‌شده در آن سطوح و مقدار مؤثر حاصل برای همان بخش متن چاپ می‌شود. همچنین نشان می‌دهد چرا پس از تغییرات قالب‌بندی باید داده‌های مؤثر دوباره خوانده شوند.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 500, 80, false);
var textFrame = shape.AddTextFrame("Effective formatting");
var paragraph = textFrame.Paragraphs[0];
var portion = paragraph.Portions[0];

// تعریف مقادیر ارث‌برده در دو سطح مختلف.
presentation.DefaultTextStyle.GetLevel(0).DefaultPortionFormat.FontHeight = 20;
paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight = 28;

PrintFontHeights("The portion inherits from the paragraph", presentation, paragraph, portion);

// یک مقدار محلی در بخش هر دو مقدار ارث‌برده را نادیده می‌گیرد.
portion.PortionFormat.FontHeight = 36;
PrintFontHeights("A local value overrides inherited values", presentation, paragraph, portion);

// تغییر یک مقدار ارث‌برده، مقدار محلی موجود را نادیده نمی‌گیرد.
paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight = 30;
PrintFontHeights("The local value still has priority", presentation, paragraph, portion);

// مقدار محلی را پاک کنید. سپس بخش دوباره از پاراگراف ارث می‌برد.
portion.PortionFormat.FontHeight = float.NaN;
PrintFontHeights("The local value is cleared", presentation, paragraph, portion);

// مقدار پاراگراف را پاک کنید. پیش‌فرض ارائه الآن نتیجه را تامین می‌کند.
paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight = float.NaN;
PrintFontHeights("The paragraph value is cleared", presentation, paragraph, portion);

presentation.Save("effective-properties.pptx", SaveFormat.Pptx);

static void PrintFontHeights(string caption, Presentation presentation, IParagraph paragraph, IPortion portion)
{
    var presentationValue = presentation.DefaultTextStyle.GetLevel(0).DefaultPortionFormat.FontHeight;
    var paragraphValue = paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight;
    var localValue = portion.PortionFormat.FontHeight;

    // پس از تغییرات قبلی داده‌های مؤثر را بخوانید.
    var effectiveValue = portion.PortionFormat.GetEffective().FontHeight;

    Console.WriteLine(caption);
    Console.WriteLine($"  Presentation default: {FormatLocalValue(presentationValue)}");
    Console.WriteLine($"  Paragraph default:    {FormatLocalValue(paragraphValue)}");
    Console.WriteLine($"  Portion local:        {FormatLocalValue(localValue)}");
    Console.WriteLine($"  Portion effective:    {effectiveValue}");
}

static string FormatLocalValue(float value) => float.IsNaN(value) ? "<not set>" : value.ToString();
```

اولویت در این مثال قالب‌بندی محلی بخش، سپس قالب‌بندی پاراگراف، و در نهایت پیش‌فرض ارائه است. اشیاء دیگر می‌توانند زنجیره‌های وراثتی متفاوتی داشته باشند، اما اصل همان است: یک مقدار صریح و خاص‌تر برنده می‌شود و [GetEffective](https://reference.aspose.com/slides/fa/net/aspose.slides/iportionformat/geteffective/) نتیجه نهایی را برمی‌گرداند.

## **دریافت ویژگی‌های متن مؤثر**
قالب‌بندی متن در چندین شی تقسیم می‌شود:

- [ITextFrameFormat.GetEffective()](https://reference.aspose.com/slides/fa/net/aspose.slides/itextframeformat/geteffective/) ویژگی‌های چارچوب متن مانند حاشیه‌ها، لنگرگذاری، خود‌تنظیم و جهت عمودی متن را حل می‌کند.
- [ITextStyle.GetEffective()](https://reference.aspose.com/slides/fa/net/aspose.slides/itextstyle/geteffective/) قالب‌بندی پاراگراف را برای هر سطح سبک متن حل می‌کند.
- [IParagraphFormat.GetEffective()](https://reference.aspose.com/slides/fa/net/aspose.slides/iparagraphformat/geteffective/) ویژگی‌های پاراگراف مانند تراز، تورفتگی و بولت‌ها را حل می‌کند.
- [IPortionFormat.GetEffective()](https://reference.aspose.com/slides/fa/net/aspose.slides/iportionformat/geteffective/) ویژگی‌های کاراکتر مانند ارتفاع قلم، نوع قلم، رنگ، ضخیم و کج را حل می‌کند.

برای مثال بعدی، فایل `text-formatting.pptx` باید حداقل یک اسلاید و یک [AutoShape](https://reference.aspose.com/slides/fa/net/aspose.slides/autoshape/) با فریم متن غیرخالی داشته باشد. AutoShape می‌تواند در هر موقعیتی از مجموعه اشکال ظاهر شود؛ کد یک شی مناسب را جستجو کرده و پیش از استفاده آن را اعتبارسنجی می‌کند.

```csharp
using System;
using System.Linq;
using Aspose.Slides;

using var presentation = new Presentation("text-formatting.pptx");

if (presentation.Slides.Count == 0)
    throw new InvalidOperationException("The presentation contains no slides.");

var autoShapes = presentation.Slides[0].Shapes.OfType<IAutoShape>();
var shape = autoShapes.FirstOrDefault(candidate => HasNonEmptyText(candidate));

if (shape == null)
{
    throw new InvalidOperationException("The first slide must contain an AutoShape with non-empty text.");
}

var textFrame = shape.TextFrame;
var paragraph = textFrame.Paragraphs[0];
var portion = paragraph.Portions[0];

var textFrameEffective = textFrame.TextFrameFormat.GetEffective();
var paragraphEffective = paragraph.ParagraphFormat.GetEffective();
var portionEffective = portion.PortionFormat.GetEffective();

Console.WriteLine("Text frame margins:");
Console.WriteLine($"  Left: {textFrameEffective.MarginLeft}");
Console.WriteLine($"  Top: {textFrameEffective.MarginTop}");
Console.WriteLine($"  Right: {textFrameEffective.MarginRight}");
Console.WriteLine($"  Bottom: {textFrameEffective.MarginBottom}");
Console.WriteLine($"Paragraph alignment: {paragraphEffective.Alignment}");
Console.WriteLine($"Font height: {portionEffective.FontHeight}");
Console.WriteLine($"Bold: {portionEffective.FontBold}");

var effectiveTextStyle = textFrame.TextFrameFormat.TextStyle.GetEffective();
for (var level = 0; level < 9; level++)
{
    var levelEffective = effectiveTextStyle.GetLevel(level);
    Console.WriteLine($"Level {level} indent: {levelEffective.Indent}");
}

static bool HasNonEmptyText(IAutoShape shape)
{
    if (shape.TextFrame == null)
        return false;

    if (shape.TextFrame.Paragraphs.Count == 0)
        return false;

    return shape.TextFrame.Paragraphs[0].Portions.Count > 0;
}
```

## **دریافت ویژگی‌های 3D مؤثر**
[IThreeDFormat.GetEffective()](https://reference.aspose.com/slides/fa/net/aspose.slides/ithreedformat/geteffective/) یک شی [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/fa/net/aspose.slides/ithreedformateffectivedata/) را برمی‌گرداند که تمام تنظیمات 3D حل‌شده را گروه‌بندی می‌کند. ویژگی‌های آن شامل [Camera](https://reference.aspose.com/slides/fa/net/aspose.slides/ithreedformateffectivedata/camera/), [LightRig](https://reference.aspose.com/slides/fa/net/aspose.slides/ithreedformateffectivedata/lightrig/), [BevelTop](https://reference.aspose.com/slides/fa/net/aspose.slides/ithreedformateffectivedata/beveltop/) و [BevelBottom](https://reference.aspose.com/slides/fa/net/aspose.slides/ithreedformateffectivedata/bevelbottom/) داده‌های مؤثر مربوطه را نشان می‌دهند. خواندن این تنظیمات مرتبط به‌صورت 함께، درک ظاهر نهایی 3D یک شکل را آسان‌تر می‌کند.

برای این مثال، فایل `shape-3d.pptx` باید حداقل یک شکل در اسلاید اول داشته باشد. اگر می‌خواهید خروجی شامل مقادیر دیگری نسبت به پیش‌فرض‌ها باشد، تنظیمات دوربین 3D، نورپردازی یا برجستگی را بر آن شکل اعمال کنید.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("shape-3d.pptx");

if (presentation.Slides.Count == 0 || presentation.Slides[0].Shapes.Count == 0)
{
    throw new InvalidOperationException("The first slide must contain a shape.");
}

var shape = presentation.Slides[0].Shapes[0];
var threeDEffective = shape.ThreeDFormat.GetEffective();

Console.WriteLine("Camera:");
Console.WriteLine($"  Type: {threeDEffective.Camera.CameraType}");
Console.WriteLine($"  Field of view: {threeDEffective.Camera.FieldOfViewAngle}");
Console.WriteLine($"  Zoom: {threeDEffective.Camera.Zoom}");

Console.WriteLine("Light rig:");
Console.WriteLine($"  Type: {threeDEffective.LightRig.LightType}");
Console.WriteLine($"  Direction: {threeDEffective.LightRig.Direction}");

Console.WriteLine("Top bevel:");
Console.WriteLine($"  Type: {threeDEffective.BevelTop.BevelType}");
Console.WriteLine($"  Width: {threeDEffective.BevelTop.Width}");
Console.WriteLine($"  Height: {threeDEffective.BevelTop.Height}");
```

## **دریافت قالب‌بندی جدول مؤثر**
قالب‌بندی جدول می‌تواند از سبک جدول و از قالب‌هایی که بر کل جدول، یک ستون، یک ردیف یا یک سلول منفرد اعمال می‌شود، سرچشمه بگیرد. برای تضادهای موجود در پرکننده‌های صریح، اولویت به ترتیب سلول، ردیف، ستون و سپس کل جدول است. قالب مؤثر یک سلول، قالب نهایی استفاده‌شده برای رسم آن سلول است.

برای این مثال، فایل `table-formatting.pptx` باید حداقل یک جدول در اسلاید اول داشته باشد. جدول باید حداقل یک ردیف و یک ستون داشته باشد. کد به دنبال یک [ITable](https://reference.aspose.com/slides/fa/net/aspose.slides/itable/) می‌گردد به‌جای فرض اینکه `Shapes[0]` یک جدول است.

```csharp
using System;
using System.Linq;
using Aspose.Slides;

using var presentation = new Presentation("table-formatting.pptx");

if (presentation.Slides.Count == 0)
    throw new InvalidOperationException("The presentation contains no slides.");

var table = presentation.Slides[0].Shapes.OfType<ITable>().FirstOrDefault();

if (table == null)
    throw new InvalidOperationException("The first slide must contain a table.");

if (table.Rows.Count == 0 || table.Columns.Count == 0)
    throw new InvalidOperationException("The table must contain at least one cell.");

var tableEffective = table.TableFormat.GetEffective();
var rowEffective = table.Rows[0].RowFormat.GetEffective();
var columnEffective = table.Columns[0].ColumnFormat.GetEffective();
var cellEffective = table[0, 0].CellFormat.GetEffective();

Console.WriteLine($"Table fill: {tableEffective.FillFormat.FillType}");
Console.WriteLine($"Row fill: {rowEffective.FillFormat.FillType}");
Console.WriteLine($"Column fill: {columnEffective.FillFormat.FillType}");
Console.WriteLine($"Final cell fill: {cellEffective.FillFormat.FillType}");
```

اگر به رنگ نیاز دارید نه فقط نوع پرکننده، ابتدا [FillType](https://reference.aspose.com/slides/fa/net/aspose.slides/ifillformateffectivedata/filltype/) مؤثر را بررسی کنید، سپس ویژگی مربوط به آن نوع را بخوانید — برای مثال، [SolidFillColor](https://reference.aspose.com/slides/fa/net/aspose.slides/ifillformateffectivedata/solidfillcolor/) برای پرکنندهٔ جامد.

## **دوباره‌خوانی داده‌های مؤثر پس از تغییرات**
داده‌های مؤثر سلسله‌مراتبی قالب‌بندی را در زمان حل توصیف می‌کنند. پس از تغییر هر چیزی که می‌تواند در این سلسله‌مراتب شرکت کند، مجدداً `GetEffective` را فراخوانی کنید، شامل:

- قالب‌بندی محلی شی؛
- پیش‌فرض‌های پاراگراف یا فریم متن؛
- سبک جدول، جدول، ستون، ردیف یا قالب سلول؛
- قالب‌بندی چیدمان یا اسلاید اصلی؛
- داده‌های تم یا پیش‌فرض‌های سطح ارائه؛
- چیدمان یا اسلاید اصلی اختصاص یافته به یک اسلاید.

یک شی داده مؤثر را به‌عنوان تصویر دائمی نگه ندارید. Aspose.Slides ممکن است برخی داده‌های مؤثر را به‌صورت داخلی کش کند و فراخوانی بعدی `GetEffective` می‌تواند آن داده‌ها را به‌روز کند. اگر نیاز به مقایسه مقادیر قبل و بعد از تغییر دارید، مقادیر اسکالر مورد نیاز خود—مانند ارتفاع قلم، رنگ، تراز یا عرض برجستگی—را قبل از اعمال تغییر در متغیرهای خود کپی کنید.

برای تغییر یک مقدار، شی قالب محلی مناسب را به‌روزرسانی کنید و سپس `GetEffective` را فراخوانی کنید تا نتیجه را تأیید کنید. خود اشیای داده مؤثر فقط‑خواندنی هستند.

## **سوالات متداول**
**چگونه می‌توانم تعیین کنم کدام سطح مقدار مؤثر را فراهم کرده است؟**
داده‌های مؤثر مقدار نهایی را شامل می‌شوند، نه منبع آن. اشیای محلی قابل‌استفاده را از سطح خاص‌ترین به سمت بیرون بررسی کنید. برای متن، این می‌تواند شامل بخش، پاراگراف، فریم متن، چیدمان، اسلاید اصلی، تم و پیش‌فرض‌های ارائه باشد. مقادیر تعریف‌نشده مانند `float.NaN` یا `null` نشان می‌دهند که جستجو به سطح دیگری ادامه می‌یابد.

**چه اتفاقی می‌افتد اگر هیچ سطحی ویژگی را تعریف نکند؟**
Aspose.Slides پیش‌فرض مناسب PowerPoint یا کتابخانه را حل می‌کند. آن مقدار حل‌شده در داده‌های مؤثر ظاهر می‌شود حتی اگر هیچ شی محلی به‌وضوح آن را تعریف نکرده باشد.

**چرا گاهی مقدار مؤثر برابر مقدار محلی است؟**
مقدار محلی محاسبه وراثت را برنده شده است. این هنگام تنظیم صریح ویژگی بر روی شی و عدم وجود قاعده‌ای خاص‌تر که آن را بازنویسی کند، انتظار می‌رود.

**کی باید از داده‌های محلی به‌جای داده‌های مؤثر استفاده کنم؟**
از داده‌های محلی برای بازرسی یا ویرایش یک سطح خاص قالب‌بندی استفاده کنید. از داده‌های مؤثر زمانی استفاده کنید که به ظاهر نهایی پس از وراثت، قواعد تم و سبک‌های قابل‌اعمال نیاز دارید. مثال [complete comparison example](#compare-local-inherited-and-effective-values) هر دو را در یک جریان کاری نشان می‌دهد.