---
title: مدیریت اشکال ارائه در .NET
linktitle: دستکاری شکل
type: docs
weight: 40
url: /fa/net/shape-manipulations/
keywords:
- شکل PowerPoint
- شکل ارائه
- شکل روی اسلاید
- یافتن شکل
- کلون کردن شکل
- حذف شکل
- مخفی کردن شکل
- تغییر ترتیب شکل
- دریافت شناسهٔ شکل Interop
- متن جایگزین شکل
- نقطه تنظیم شکل
- تنظیم پیش‌تنظیم‌شدهٔ شکل
- هندسهٔ شکل
- قالب‌بندی‌های لایهٔ شکل
- شکل به‌صورت SVG
- شکل به SVG
- تراز کردن شکل
- وارونه‌سازی شکل
- PowerPoint
- ارائه
- .NET
- C#
- Aspose.Slides
description: "یاد بگیرید چگونه اشکال ارائه را با Aspose.Slides برای .NET شناسایی، تنظیم، کلون، حذف، مخفی، دوباره‌چین، صادر، تراز و وارونه‌سازی کنید."
---
## **بررسی کلی**

Aspose.Slides for .NET اشکال موجود در یک اسلاید را به عنوان یک [IShapeCollection](https://reference.aspose.com/slides/fa/net/aspose.slides/ishapecollection/) مرتب‌شده نشان می‌دهد. این مجموعه هم محلی است که می‌توانید اشکال را پیدا و اصلاح کنید و هم منبع ترتیب اندیس‌بندی آن‌ها: اندیس `0` پایین‌ترین شکل و آخرین اندیس بالاترین شکل است.

این مقاله بر همین مدل استوار است. ابتدا نحوه‌ی شناسایی قابل اطمینان یک شکل و اصلاح نقاط تنظیم پیش‌تنظیم‌شده را توضیح می‌دهد، سپس نشان می‌دهد چگونه شکل‌ها را کپی، حذف، مخفی و دوباره‌چین کنید. بخش‌های نهایی به قالب‌بندی سطح لایه، خروجی SVG، تراز کردن و تنظیمات وارونه‌سازی می‌پردازند. هر مثال به‌صورت مستقل است، بنابراین می‌توانید تنها عملیات مورد نیاز جریان کار خود را استفاده کنید.

## **شناسایی و یافتن اشکال**

اندیس‌های مجموعه هنگام پردازش فایل شناخته‌شده راحت هستند، اما شناسه‌های پایداری نیستند. افزودن، حذف یا دوباره‌چین کردن یک شکل می‌تواند اندیس آن را تغییر دهد. بر اساس نحوه‌ی تهیه و نگهداری ارائه، یک شناسه انتخاب کنید:

- [Name](https://reference.aspose.com/slides/fa/net/aspose.slides/ishape/name/) برای قالب‌های کنترل‌شده توسط توسعه‌دهنده مفید است و در پنل انتخاب PowerPoint به راحتی قابل مشاهده است. نام‌ها قابل ویرایش‌اند اما ضمانت یکتایی ندارند، بنابراین اگر کد به آن‌ها وابسته باشد یک قرارداد نام‌گذاری تعیین کنید.
- [AlternativeText](https://reference.aspose.com/slides/fa/net/aspose.slides/ishape/alternativetext/) زمانی مفید است که یک توضیح دسترسی یا برچسب ارائه‌شده توسط نویسنده قبلاً شکل را شناسایی کرده باشد. این متن برای کاربران قابل مشاهده است، می‌تواند بومی‌سازی یا برای دسترسی بازنویسی شود و ضمانت یکتایی ندارد. متن دسترسی معنادار را به‌صورت بی‌صدا به عنوان کلید پایگاه داده استفاده نکنید.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/fa/net/aspose.slides/ishape/officeinteropshapeid/) یک شناسه فقط‑خواندنی است که در داخل یک اسلاید یکتا بوده و با شناسه شکل مورد استفاده در interop PowerPoint مطابقت دارد. زمانی که با PowerPoint یکپارچه می‌شوید یا به یک مرجع بدون ابهام در طول عمر یک شکل نیاز دارید از آن استفاده کنید. یک شکل کلون شده یا بازساخت‌شده شکل دیگری است و شناسه مخصوص به خود را دریافت می‌کند.

ویژگی مرتبط [UniqueId](https://reference.aspose.com/slides/fa/net/aspose.slides/ishape/uniqueid/) دارای دامنهٔ ارائه است، اما برای افزونه‌ها در نظر گرفته شده و می‌تواند دوباره تخصیص یابد. نباید به‌عنوان کلید خارجی دائمی استفاده شود. اگر هویت طولانی‌مدت ضروری است، نگاشت را در داده‌های اپلیکیشن نگه‌دارید و اعتبارسنجی کنید که شکل مورد انتظار هنوز موجود است.

برای مثال عملی خواندن و به‌روزرسانی هم عنوان متن جایگزین و هم توضیح آن، به [Manage Alternative Text Titles and Descriptions](/slides/fa/net/presentation-accessibility/) مراجعه کنید. از متن جایگزین برای توضیح معنی بصری به خوانندگان استفاده کنید و آن را از نام‌های اشکال که توسط کد برای یافتن اشکال به‌کار می‌رود، جدا نگه دارید.

مثال زیر با مقایسهٔ ترتیبی بر پایه `Name` جستجو می‌کند و شناسهٔ interop scoped به اسلاید را گزارش می‌دهد. وقتی قالب شکل مورد انتظار را نداشته باشد، کد همان نتیجه را گزارش می‌کند به‌جای ادامه با شیء اشتباه.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");
var slide = presentation.Slides[0];

IShape? targetShape = null;
foreach (var shape in slide.Shapes)
{
    if (string.Equals(shape.Name, "RevenueChart", StringComparison.Ordinal))
    {
        targetShape = shape;
        break;
    }
}

if (targetShape is null)
{
    Console.WriteLine("The shape 'RevenueChart' was not found on slide 1.");
}
else
{
    Console.WriteLine($"Found {targetShape.Name}; interop ID: {targetShape.OfficeInteropShapeId}");
}
```

هنگامی که یک عملیات به نوع خاصی از شکل مرتبط است، قبل از استفاده از اعضای نوع‑خاص، اینترفیس را بررسی کنید. این مثال متن و متن جایگزین را فقط در صورتی به‌روز می‌کند که شیء نام‌گذاری‌شده یک [IAutoShape](https://reference.aspose.com/slides/fa/net/aspose.slides/iautoshape/) باشد.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");
var slide = presentation.Slides[0];

IShape? candidate = null;
foreach (var shape in slide.Shapes)
{
    if (string.Equals(shape.Name, "StatusLabel", StringComparison.Ordinal))
    {
        candidate = shape;
        break;
    }
}

if (candidate is IAutoShape autoShape)
{
    autoShape.TextFrame.Text = "Approved";
    autoShape.AlternativeText = "Approval status: approved";
    presentation.Save("identified-shape.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("'StatusLabel' is missing or is not an AutoShape.");
}
```

## **شناسایی و اصلاح تنظیمات پیش‌تنظیم‌شدهٔ شکل**

اشکال هندسی پیش‌تنظیم‌شده می‌توانند نقاط تنظیمی ارائه دهند که ویژگی‌هایی مانند اندازهٔ گوشه، نسبت‌های فلش یا زوایای قوس را کنترل می‌کند. از مجموعهٔ فقط‑خواندنی [IGeometryShape.Adjustments](https://reference.aspose.com/slides/fa/net/aspose.slides/igeometryshape/adjustments/) برای دسترسی به آن‌ها استفاده کنید. خود مجموعه توسط شکل فراهم می‌شود، اما هر [IAdjustValue](https://reference.aspose.com/slides/fa/net/aspose.slides/iadjustvalue/) شامل مقداری است که می‌توان آن را تغییر داد.

فقط به یک اندیس ثابت مجموعه تکیه نکنید. از طریق تنظیمات پیمایش کنید و ویژگی فقط‑خواندنی [Type](https://reference.aspose.com/slides/fa/net/aspose.slides/adjustvalue/type/) را بررسی کنید که مقدار [ShapeAdjustmentType](https://reference.aspose.com/slides/fa/net/aspose.slides/shapeadjustmenttype/) توصیف‌کنندهٔ اینکه تنظیم چه چیزی را کنترل می‌کند، است. ویژگی فقط‑خواندنی [Name](https://reference.aspose.com/slides/fa/net/aspose.slides/adjustvalue/name/) اطلاعات شناسایی اضافی فراهم می‌کند و به‌ویژه وقتی یک پیش‌تنظیم بیش از یک تنظیم با همان نوع معنایی داشته باشد، مفید است.

از ویژگی مقدار که با معنای تنظیم مطابقت دارد استفاده کنید:

| نوع تنظیم | هدف | مقدار برای تغییر |
|---|---|---|
| `CornerSize` | اندازهٔ گوشه‌های گرد | [RawValue](https://reference.aspose.com/slides/fa/net/aspose.slides/adjustvalue/rawvalue/) |
| `ArrowTailThickness` | ضخامت دم فلش | `RawValue` |
| `ArrowheadLength` | طول سر فلش | `RawValue` |
| `ArrowheadWidth` | عرض سر فلش | `RawValue` |
| `StartAngle` | زاویهٔ شروع کیک یا قوس | [AngleValue](https://reference.aspose.com/slides/fa/net/aspose.slides/adjustvalue/anglevalue/) |
| `EndAngle` | زاویهٔ پایان کیک یا قوس | `AngleValue` |

`Type` و `Name` قابل انتساب نیستند. `RawValue` یک عدد صحیح خواندنی/نوشتنی در واحدهای هندسی بومی پیش‌تنظیم است، در حالی که `AngleValue` یک زاویهٔ خواندنی/نوشتنی بر حسب درجه است. تعداد، ترتیب، معنی و بازهٔ معتبر تنظیمات به [ShapeType](https://reference.aspose.com/slides/fa/net/aspose.slides/igeometryshape/shapetype/) پیش‌تنظیم وابسته است. مقداری که برای یک پیش‌تنظیم معتبر است ممکن است برای پیش‌تنظیم دیگر نامعتبر یا اثر متفاوتی داشته باشد.

وقتی `Type` برابر `ShapeAdjustmentType.Custom` باشد، API معنای معنایی استانداردی را تشخیص نمی‌دهد. `Name`، نوع پیش‌تنظیم و مقدار موجود را بررسی کنید و تنظیم را دست‌نخورده بگذارید مگر اینکه معنی و بازهٔ مورد انتظار شناخته‌شده باشد. حتی برای انواع شناخته‌شده، قبل از انتخاب مقدار بررسی کنید که آیا همان نوع بیش از یک‌بار رخ می‌دهد یا نه. مقالهٔ [Connector](/slides/fa/net/connector/) این وضعیت را با تنظیمات خمیدگی کانکتور نشان می‌دهد.

مثال کامل زیر نسخه‌های پیش‌فرض و اصلاح‌شدهٔ سه شکل پیش‌تنظیم‌شده را ایجاد می‌کند. تمام تنظیمات را پیمایش می‌کند، `Name` و `Type` آن‌ها را گزارش می‌دهد، مقادیر مرتبط با اندازه را از طریق `RawValue` و زوایا را از طریق `AngleValue` تغییر می‌دهد و نتیجه را ذخیره می‌کند. ستون چپ هندسهٔ پیش‌فرض را حفظ می‌کند؛ ستون راست مستطیل گرد، فلش چهار‑پهن و کیک تنظیم‌شده را نشان می‌دهد.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

// سرصفحات ستون‌های شکل پیش‌فرض و تنظیم‌شده را اضافه می‌کند.
var defaultColumnLabel = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 20, 250, 30);
defaultColumnLabel.TextFrame.Text = "Default preset geometry";
var adjustedColumnLabel = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 390, 20, 250, 30);
adjustedColumnLabel.TextFrame.Text = "Modified adjustment values";

slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 80, 70, 160, 70);
var modifiedRoundedRectangle = slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 430, 70, 160, 70);
modifiedRoundedRectangle.Name = "ModifiedRoundedRectangle";

slide.Shapes.AddAutoShape(ShapeType.QuadArrow, 80, 180, 160, 110);
var modifiedArrow = slide.Shapes.AddAutoShape(ShapeType.QuadArrow, 430, 180, 160, 110);
modifiedArrow.Name = "ModifiedQuadArrow";

slide.Shapes.AddAutoShape(ShapeType.Pie, 95, 330, 130, 130);
var modifiedPie = slide.Shapes.AddAutoShape(ShapeType.Pie, 445, 330, 130, 130);
modifiedPie.Name = "ModifiedPie";

var shapesToAdjust = new IGeometryShape[]
{
    modifiedRoundedRectangle,
    modifiedArrow,
    modifiedPie
};

foreach (var shape in shapesToAdjust)
{
    for (var adjustmentIndex = 0; adjustmentIndex < shape.Adjustments.Count; adjustmentIndex++)
    {
        var adjustment = shape.Adjustments[adjustmentIndex];
        Console.WriteLine($"{shape.Name} / {adjustment.Name}: {adjustment.Type}");

        switch (adjustment.Type)
        {
            case ShapeAdjustmentType.CornerSize:
                adjustment.RawValue = 5000;
                break;
            case ShapeAdjustmentType.ArrowTailThickness:
                adjustment.RawValue = 25000;
                break;
            case ShapeAdjustmentType.ArrowheadLength:
                adjustment.RawValue = 30000;
                break;
            case ShapeAdjustmentType.ArrowheadWidth:
                adjustment.RawValue = 40000;
                break;
            case ShapeAdjustmentType.StartAngle:
                adjustment.AngleValue = 30;
                break;
            case ShapeAdjustmentType.EndAngle:
                adjustment.AngleValue = 300;
                break;
            case ShapeAdjustmentType.Custom:
                Console.WriteLine($"Custom adjustment '{adjustment.Name}' was not changed.");
                break;
        }
    }
}

presentation.Save("preset-shape-adjustments.pptx", SaveFormat.Pptx);
```

بررسی نوع معنایی قبل از تغییر مقدار، کد را دربارهٔ نیت خود صریح می‌کند و از فرض اینکه یک اندیس خاص در پیش‌تنظیم‌های مختلف همان معنی را دارد، جلوگیری می‌کند.

## **اصلاح مجموعهٔ اشکال**

متدهای افزودن، کلون کردن، حذف و دوباره‌چین کردن بلافاصله بر روی مجموعه عمل می‌کنند. اگر عملی تعداد یا ترتیب اشکال را تغییر دهد، پس از آن عملیات دیگر به اندیس‌های دریافت‌شده قبل از آن عمل متکی نباشید.

### **کلون کردن یک شکل**

[AddClone](https://reference.aspose.com/slides/fa/net/aspose.slides/ishapecollection/addclone/) یک کپی مستقل ایجاد می‌کند و آن را به انتهای مجموعه هدف اضافه می‌سازد. [InsertClone](https://reference.aspose.com/slides/fa/net/aspose.slides/ishapecollection/insertclone/) نیز یک کپی می‌سازد اما آن را در یک اندیس z‑order مشخص قرار می‌دهد. overloadهایی که مختصات می‌پذیرند کلون را بدون تغییر اندازه جابجا می‌کنند؛ overloadهایی با عرض و ارتفاع می‌توانند اندازه را نیز تغییر دهند.

مثال یک اسلاید مقصد ایجاد می‌کند، یک مستطیل برچسب‌دار را به جلو کلون می‌کند و یک کلون دوم را در پشت درج می‌کند. تغییرات در هر دو کلون شکل منبع را تغییر نمی‌دهد.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var sourceSlide = presentation.Slides[0];
var sourceShape = sourceSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 180, 60);
sourceShape.Name = "SourceLabel";
sourceShape.TextFrame.Text = "Source";

var blankLayout = presentation.Masters[0].LayoutSlides.GetByType(SlideLayoutType.Blank);
var destinationSlide = presentation.Slides.AddEmptySlide(blankLayout);

var frontCloneShape = destinationSlide.Shapes.AddClone(sourceShape, 80, 80);
frontCloneShape.Name = "FrontClone";
if (frontCloneShape is IAutoShape frontClone)
{
    frontClone.TextFrame.Text = "Front clone";
}
else
{
    Console.WriteLine("The front clone is not an AutoShape; its text was not changed.");
}

var backCloneShape = destinationSlide.Shapes.InsertClone(0, sourceShape, 80, 180);
backCloneShape.Name = "BackClone";
if (backCloneShape is IAutoShape backClone)
{
    backClone.TextFrame.Text = "Back clone";
}
else
{
    Console.WriteLine("The back clone is not an AutoShape; its text was not changed.");
}

presentation.Save("cloned-shapes.pptx", SaveFormat.Pptx);
```

کلون کردن محتوا و قالب‌بندی شکل را کپی می‌کند، از جمله نام و متن جایگزین. وقتی این مقادیر باید یکتا باشند، شناسه‌های منطقی جدیدی به کلون اختصاص دهید. منابع استفاده‌شده توسط اشکال پیچیده توسط ارائه مدیریت می‌شوند، اما یک کلون باقی می‌ماند یک آیتم جدید در مجموعه با هویت شکل جدید.

### **حذف اشکال**

[Remove](https://reference.aspose.com/slides/fa/net/aspose.slides/ishapecollection/remove/) یک شیء شکل خاص را از مجموعهٔ خود حذف می‌کند. هنگام حذف چندین تطابق در طول پیمایش اندیس‌دار، از انتها به ابتدا پیش بروید تا هر اندیس باقی‌مانده معتبر بماند.

این مثال هر شکلی که نام معین دارد را حذف می‌کند. آن `slide.Shapes[i]` را می‌خواند، نه یک آیتم ثابت مجموعه، و شکل را بدون Cast غیرضروری استفاده می‌کند.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var keepShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 140, 60);
keepShape.Name = "Keep";

var firstTemporaryShape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 220, 40, 80, 80);
firstTemporaryShape.Name = "Temporary";

var secondTemporaryShape = slide.Shapes.AddAutoShape(ShapeType.Triangle, 340, 40, 100, 80);
secondTemporaryShape.Name = "Temporary";

for (var i = slide.Shapes.Count - 1; i >= 0; i--)
{
    var shape = slide.Shapes[i];
    if (string.Equals(shape.Name, "Temporary", StringComparison.Ordinal))
    {
        slide.Shapes.Remove(shape);
    }
}

presentation.Save("removed-shapes.pptx", SaveFormat.Pptx);
```

پس از حذف، تعداد شکل‌ها و اندیس‌های اشکال بعدی تغییر می‌کند. ارجاعات به شکل‌های بدون اثر نسبت به اندیس‌های ذخیره‌شده قابل اطمینان‌تر باقی می‌مانند. همچنین کانکتورها، انیمیشن‌ها و سایر ویژگی‌های ارائه که ممکن است به شیء حذف‌شده ارجاع دهند را در نظر بگیرید؛ حذف یک شکل قابل مشاهده می‌تواند بیش از ظاهر اسلاید را تغییر دهد.

### **مخفی کردن یک شکل**

تنظیم [Hidden](https://reference.aspose.com/slides/fa/net/aspose.slides/ishape/hidden/) به `true` شکل را در مجموعه نگه می‌دارد اما مانع نمایش آن در اسلاید شو عادی می‌شود. اندیس، قالب‌بندی و محتویات آن همچنان برای کد در دسترس است، بنابراین مخفی کردن برای عناصر اختیاری که ممکن است بعداً بازگردانده شوند مناسب است.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var visibleShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 160, 60);
visibleShape.Name = "VisibleLabel";

var optionalShape = slide.Shapes.AddAutoShape(ShapeType.Moon, 240, 40, 100, 100);
optionalShape.Name = "OptionalDecoration";

foreach (var shape in slide.Shapes)
{
    if (string.Equals(shape.Name, "OptionalDecoration", StringComparison.Ordinal))
    {
        shape.Hidden = true;
    }
}

presentation.Save("hidden-shape.pptx", SaveFormat.Pptx);
```

مخفی کردن حذف یا امنیت نیست. شیء هنوز می‌تواند توسط کاربر یا کد کشف و دوباره آشکار شود و همچنان بخشی از فایل ارائه باقی می‌ماند.

### **تغییر Z‑Order**

اشکال هم‑پوشان به ترتیب مجموعه رنگ می‌شوند. [Reorder](https://reference.aspose.com/slides/fa/net/aspose.slides/ishapecollection/reorder/) یک شکل موجود را به یک اندیس هدف منتقل می‌کند بدون اینکه آن را کلون کند. اندیس `0` پشت‌ترین است؛ `Count - 1` جلوی‌ترین.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var blueRectangle = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 220, 120);
blueRectangle.Name = "BlueRectangle";
blueRectangle.FillFormat.FillType = FillType.Solid;
blueRectangle.FillFormat.SolidFillColor.Color = Color.SteelBlue;

var orangeEllipse = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 180, 140, 220, 120);
orangeEllipse.Name = "OrangeEllipse";
orangeEllipse.FillFormat.FillType = FillType.Solid;
orangeEllipse.FillFormat.SolidFillColor.Color = Color.Orange;

slide.Shapes.Reorder(slide.Shapes.Count - 1, blueRectangle);
presentation.Save("reordered-shapes.pptx", SaveFormat.Pptx);
```

در ابتدا مستطیل ایجاد می‌شود و پشت بیضی قرار می‌گیرد. جابجا کردن آن به اندیس نهایی باعث می‌شود در جلو قرار گیرد. پس از افزودن یا کلون کردن تمام اشکال مرتبط، Z‑order نهایی کنید، چرا که این عملیات آیتم‌های جدیدی به مجموعه اضافه یا درج می‌کنند و می‌توانند ترتیب دلخواه را تغییر دهند.

## **بازرسی اشکال در اسلایدهای Layout**

اسلایدهای عادی، اسلایدهای layout و اسلایدهای master دارای مجموعهٔ اشکال جداگانه‌ای هستند. یک شکل در مجموعهٔ layout همان شیء شکل مشابه در اسلاید عادی نیست. زمانی که نیاز به درک یا تغییر قالب‌بندی ارائه‌شده توسط یک layout دارید، به اشکال layout نگاهی بیندازید.

مثال زیر قالب هر شکل layout را از طریق [FillFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/ishape/fillformat/) و [LineFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/ishape/lineformat/) می‌خواند بدون این که فرض کند هر شکل یک `AutoShape` است.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");

foreach (var layoutSlide in presentation.LayoutSlides)
{
    foreach (var shape in layoutSlide.Shapes)
    {
        var fillType = shape.FillFormat.FillType;
        var lineWidth = shape.LineFormat.Width;
        Console.WriteLine($"{layoutSlide.Name} / {shape.Name}: fill={fillType}, line width={lineWidth}");
    }
}
```

ویرایش یک layout می‌تواند بر چندین اسلایدی که از آن استفاده می‌کنند تأثیر بگذارد. قبل از تغییر یک شکل layout، تعیین کنید آیا اسلاید عادی شیء را به ارث می‌برد یا حاوی بازنویسی محلی است و هر اسلایدی که از آن layout استفاده می‌کند را تست کنید.

## **صادر کردن یک شکل به SVG**

[WriteAsSvg](https://reference.aspose.com/slides/fa/net/aspose.slides/ishape/writeassvg/) محتوای رندر شدهٔ یک شکل را به یک جریان می‌نویسد. نتیجه شامل فقط همان شکل است، نه پس‌زمینهٔ تمام اسلاید یا اشکال همسایه.

```csharp
using System;
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");
var slide = presentation.Slides[0];

if (slide.Shapes.Count == 0)
{
    Console.WriteLine("Slide 1 does not contain a shape to export.");
}
else
{
    var shape = slide.Shapes[0];
    using var svgStream = File.Create("shape.svg");
    shape.WriteAsSvg(svgStream);
}
```

در حین رندر، ارائه باید باز بماند. خروجی به قالب‌بندی شکل و به منابعی مانند فونت‌ها و تصاویر وابسته است. اگر به کل ترکیب نیاز دارید، اسلاید را به‌جای یک شکل منفرد صادر کنید. فراخواننده مسئول جریان است و باید آن را آزاد کند.

## **تراز کردن اشکال**

متدهای [SlideUtil.AlignShapes](https://reference.aspose.com/slides/fa/net/aspose.slides.util/slideutil/alignshapes/) می‌توانند همهٔ اشکال یا اندیس‌های منتخب مجموعه را تراز کنند. [ShapesAlignmentType](https://reference.aspose.com/slides/fa/net/aspose.slides/shapesalignmenttype/) لبه، خط مرکز یا حالت توزیع را مشخص می‌کند. `alignToSlide` را به `true` تنظیم کنید تا لبه‌های اسلاید استفاده شوند؛ به `false` تنظیم کنید تا اشکال منتخب نسبت به یکدیگر تراز شوند.

این مثال سه شکل را به لبهٔ بالا اسلاید تراز می‌کند. ارجاعات به شکل‌ها بلافاصله قبل از تراز به اندیس‌های فعلیشان تبدیل می‌شوند.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Util;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var firstShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 60, 80, 120, 50);
var secondShape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 240, 160, 120, 50);
var thirdShape = slide.Shapes.AddAutoShape(ShapeType.Triangle, 420, 240, 120, 50);
firstShape.Name = "FirstAlignedShape";
secondShape.Name = "SecondAlignedShape";
thirdShape.Name = "ThirdAlignedShape";

var shapeIndexes = new[]
{
    slide.Shapes.IndexOf(firstShape),
    slide.Shapes.IndexOf(secondShape),
    slide.Shapes.IndexOf(thirdShape)
};

SlideUtil.AlignShapes(ShapesAlignmentType.AlignTop, true, slide, shapeIndexes);
presentation.Save("aligned-shapes.pptx", SaveFormat.Pptx);
```

ترازبندی موقعیت‌ها را تغییر می‌دهد، نه Z‑order. ترازبندی نسبی معمولاً حداقل به دو شکل نیاز دارد، در حالی که توزیع افقی یا عمودی به اشکال کافی برای تعریف فاصله نیاز دارد. اگر قبل از فراخوانی متد مجموعه را تغییر دادید، اندیس‌ها را مجدداً محاسبه کنید.

## **وارونه‌سازی (Flip) یک شکل**

کلاس [ShapeFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/shapeframe/) موقعیت، اندازه، تنظیمات وارونه‌سازی افقی و عمودی و چرخش را ذخیره می‌کند. مقادیر `FlipH` و `FlipV` از [NullableBool](https://reference.aspose.com/slides/fa/net/aspose.slides/nullablebool/) استفاده می‌کنند: `True` وارونه‌سازی را فعال می‌کند، `False` غیرفعال می‌کند و `NotDefined` حالت غیرمشخص/پیش‌فرض را حفظ می‌کند.

ارائه‌ی ورودی زیر یک شکل بدون وارونه‌سازی دارد.

![The shape before flipping](shape_to_be_flipped.png)

مثال تمام مقادیر دیگر Frame را حفظ می‌کند و فقط دو تنظیم وارونه‌سازی را جایگزین می‌کند. این مهم است زیرا تخصیص یک [Frame](https://reference.aspose.com/slides/fa/net/aspose.slides/ishape/frame/) جدید تمام Frame را جایگزین می‌کند.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var shape = presentation.Slides[0].Shapes[0];
var frame = shape.Frame;

Console.WriteLine($"Horizontal flip before change: {frame.FlipH}");
Console.WriteLine($"Vertical flip before change: {frame.FlipV}");

shape.Frame = new ShapeFrame(
    frame.X, frame.Y, frame.Width, frame.Height,
    NullableBool.True, NullableBool.True, frame.Rotation);

presentation.Save("flipped-shape.pptx", SaveFormat.Pptx);
```

شکل ذخیره‌شده به صورت افقی و عمودی آینه‌ای می‌شود در حالی که موقعیت، اندازه و چرخش خود را حفظ می‌کند.

![The shape after flipping](flipped_shape.png)

## **سؤالات متداول**

**آیا باید از اندیس مجموعه به‌عنوان شناسهٔ شکل استفاده کنم؟**

فقط برای پردازش کوتاه‑مدت که مجموعه قبل از استفاده از اندیس تغییر نخواهد کرد. برای قالب‌های ساخته‌شده یک قرارداد معتبر `Name` یا `AlternativeText`، یا برای کارهای interop scoped به اسلاید `OfficeInteropShapeId` ترجیح دهید.

**آیا مخفی کردن یک شکل آن را از Z‑order حذف می‌کند؟**

خیر. یک شکل مخفی در همان اندیس در مجموعه باقی می‌ماند. می‌تواند یافت، دوباره‌چین، ویرایش یا مجدداً قابل مشاهده شود.

**چرا یک شکل کلون‌شده در جلوی شکل دیگری ظاهر شد؟**

`AddClone` کلون را به انتهای مجموعه اضافه می‌کند که جلوی Z‑order است. برای انتخاب اندیس اولیه از `InsertClone` استفاده کنید یا پس از افزودن تمام اشکال از `Reorder` بهره بگیرید.

**آیا می‌توانم از یک اندیس ثابت برای شناسایی تنظیم پیش‌تنظیم شکل استفاده کنم؟**

فقط پس از اعتبارسنجی دقیق پیش‌تنظیم و چیدمان مجموعه. ترجیحاً از طریق پیمایش `IGeometryShape.Adjustments` و بررسی `IAdjustValue.Type` عمل کنید؛ هنگامی که همان نوع معنایی بیش از یک‌بار ظاهر می‌شود از `IAdjustValue.Name` به‌عنوان اطلاعات اضافی استفاده کنید.