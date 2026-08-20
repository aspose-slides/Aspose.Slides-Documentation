---
title: مدیریت اشکال ارائه در .NET
linktitle: دستکاری شکل
type: docs
weight: 40
url: /fa/net/shape-manipulations/
keywords:
- شکل PowerPoint
- شکل ارائه
- شکل در اسلاید
- یافتن شکل
- کلون کردن شکل
- حذف شکل
- پنهان کردن شکل
- تغییر ترتیب شکل
- دریافت شناسه شکل Interop
- متن جایگزین شکل
- قالب‌بندی‌های طرح‌بندی شکل
- شکل به عنوان SVG
- شکل به SVG
- تراز کردن شکل
- معکوس کردن شکل
- PowerPoint
- ارائه
- .NET
- C#
- Aspose.Slides
description: "یاد بگیرید چگونه اشکال ارائه را با Aspose.Slides برای .NET شناسایی، کلون، حذف، پنهان، دوباره ترتیب‌بندی، صادر، تراز و معکوس کنید."
---
## **مرور کلی**

Aspose.Slides برای .NET اشکال موجود در یک اسلاید را به عنوان یک [IShapeCollection](https://reference.aspose.com/slides/fa/net/aspose.slides/ishapecollection/) مرتب شده نمایش می‌دهد. این مجموعه هم مکانی است که می‌توانید اشکال را پیدا و اصلاح کنید و هم منبع ترتیب انباشته شدن آن‌ها: اندیس `0` پایین‌ترین شکل است، در حالی که آخرین اندیس، بالاترین شکل است.

این مقاله همان مدل را دنبال می‌کند. ابتدا توضیح می‌دهد چطور به‌طور قابل‌اعتماد یک شکل را شناسایی کنید، سپس نشان می‌دهد چگونه اشکال را کلون، حذف، مخفی و دوباره ترتیب دهید. بخش‌های نهایی به قالب‌بندی در سطح طرح‌بندی، خروجی SVG، تراز کردن و تنظیمات معکوس‌سازی می‌پردازند. هر مثال مستقل است، بنابراین می‌توانید فقط عملیاتی را که جریان کاری شما نیاز دارد، استفاده کنید.

## **شناسایی و یافتن اشکال**

اندیس‌های مجموعه در حین پردازش یک فایل شناخته‌شده راحت هستند، اما شناساگرهای پایداری نیستند. افزودن، حذف یا تغییر ترتیب یک شکل می‌تواند اندیس آن را تغییر دهد. یک شناساگر را بر اساس نحوه ایجاد و نگهداری ارائه انتخاب کنید:

- [Name](https://reference.aspose.com/slides/fa/net/aspose.slides/ishape/name/) برای قالب‌های کنترل‌شده توسط توسعه‌دهنده مفید است و در پانل انتخاب PowerPoint به‌راحتی قابل‌مشاهده است. نام‌ها قابل ویرایش‌اند و تضمین نمی‌شود که یکتا باشند، بنابراین اگر کد به آن‌ها وابسته است یک قواعد نام‌گذاری تعریف کنید.
- [AlternativeText](https://reference.aspose.com/slides/fa/net/aspose.slides/ishape/alternativetext/) زمانی مفید است که یک توضیح دسترس‌پذیری یا برچسب ارائه‌شده توسط نویسنده پیشاپیش شکل را شناسایی می‌کند. این متن برای کاربران قابل‌مشاهده است، ممکن است محلی‌سازی یا بازنویسی برای دسترس‌پذیری شود و تضمین یکتایی ندارد. متن دسترس‌پذیری معنادار را به‌صورت ساکن به عنوان کلید دیتابیس استفاده نکنید.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/fa/net/aspose.slides/ishape/officeinteropshapeid/) یک شناساگر فقط‑خواندنی است که درون یک اسلاید یکتا بوده و با شناسه شکلی که PowerPoint Interop استفاده می‌کند مطابقت دارد. هنگام یکپارچه‌سازی با PowerPoint یا وقتی که به یک مرجع واضح در طول عمر یک شکل نیاز دارید از آن استفاده کنید. یک شکل کلون‌شده یا مجدداً ساخته‌شده یک شکل متفاوت است و شناسه خود را دریافت می‌کند.

خاصیت مرتبط [UniqueId](https://reference.aspose.com/slides/fa/net/aspose.slides/ishape/uniqueid/) محدودهٔ ارائه دارد، اما برای افزونه‌ها در نظر گرفته شده و می‌تواند بازتخصیص شود. نباید به‌عنوان کلید خارجی دائم رفتار شود. اگر هویت طولانی‌مدت ضروری است، نگاشت را در داده‌های برنامه نگه دارید و اعتبارسنجی کنید که شکل مورد انتظار هنوز وجود دارد.

مثال زیر با استفاده از مقایسهٔ عددی `Name` جستجو می‌کند و شناسهٔ interop scoped به اسلاید را گزارش می‌دهد. وقتی قالب شامل شکل مورد انتظار نباشد، کد همان نتیجه را گزارش می‌کند به‌جای ادامه با شیء اشتباه.

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

هنگامی که یک عملیات به نوع خاصی از شکل مربوط می‌شود، قبل از استفاده از اعضای نوع‑خاص، اینترفیس را بررسی کنید. این مثال متن و متن جایگزین را فقط در صورتی به‌روز می‌کند که شیء نام‌گذاری‌شده یک [IAutoShape](https://reference.aspose.com/slides/fa/net/aspose.slides/iautoshape/) باشد.

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

## **تغییر مجموعه اشکال**

متدهای افزودن، کلون، حذف و تغییر ترتیب بلافاصله بر روی مجموعه عمل می‌کنند. اگر عملیاتی تعداد یا ترتیب اشکال را تغییر دهد، پس از آن عملیات دیگر نباید به اندیس‌های گرفته‌شده قبل از آن عملیات اعتماد کند.

### **کلون کردن یک شکل**

[AddClone](https://reference.aspose.com/slides/fa/net/aspose.slides/ishapecollection/addclone/) یک نسخهٔ مستقل ایجاد کرده و به انتهای مجموعه هدف اضافه می‌کند. [InsertClone](https://reference.aspose.com/slides/fa/net/aspose.slides/ishapecollection/insertclone/) نیز یک نسخه می‌سازد اما آن را در اندیس z‑order مشخصی قرار می‌دهد. overloadهایی که مختصات را می‌پذیرند، کلون را بدون تغییر اندازه جابه‌جا می‌کنند؛ overloadهایی با عرض و ارتفاع می‌توانند اندازه را نیز تغییر دهند.

مثال یک اسلاید مقصد می‌سازد، یک مستطیل برچسب‌دار را به جلو کلون می‌کند و کلون دوم را در پشت قرار می‌دهد. تغییرات روی هر یک از کلون‌ها شکل منبع را تحت تأثیر قرار نمی‌دهد.

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

کلون کردن محتوای شکل و قالب‌بندی آن را شامل نام و متن جایگزین کپی می‌کند. در زمانی که این مقادیر باید یکتا باشند، شناساگرهای منطقی جدیدی به کلون اختصاص دهید. منابع مورد استفادهٔ اشکال پیچیده توسط ارائه مدیریت می‌شوند، اما یک کلون همچنان یک مورد جدید در مجموعه با هویت شکل جدید است.

### **حذف اشکال**

[Remove](https://reference.aspose.com/slides/fa/net/aspose.slides/ishapecollection/remove/) یک شیء شکل خاص را از مجموعه‌اش حذف می‌کند. هنگام حذف چندین مورد مطابقتی در طول یک حلقهٔ اندیس‌دار، از انتها به سمت ابتدا پیمایش کنید تا هر اندیس باقی‌مانده معتبر بماند.

این مثال هر شکلی که نام تعیین‌شده‌ای داشته باشد را حذف می‌کند. آن `slide.Shapes[i]` را می‌خواند، نه یک مورد ثابت از مجموعه، و به‌طور غیرضروری شکل را کست نمی‌کند.

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

پس از حذف، تعداد اشکال و اندیس‌های شکل‌های بعدی تغییر می‌کند. ارجاع به اشکالی که تحت تأثیر قرار نگرفته‌اند نسبت به ذخیرهٔ اندیس‌ها قابل‌اعتمادتر است. همچنین به کانکتورها، انیمیشن‌ها و سایر ویژگی‌های ارائه که ممکن است به شیء حذف‌شده ارجاع دهند توجه کنید؛ حذف یک شکل قابل‌مشاهده می‌تواند بیش از ظاهر اسلاید را تغییر دهد.

### **پنهان کردن یک شکل**

تنظیم [Hidden](https://reference.aspose.com/slides/fa/net/aspose.slides/ishape/hidden/) روی `true` شکل را در مجموعه نگه می‌دارد اما از نمایش در اسلاید شو معمولی جلوگیری می‌کند. اندیس، قالب‌بندی و محتوا همچنان برای کد در دسترس هستند، بنابراین پنهان کردن برای عناصری که ممکن است بعداً بازیابی شوند مناسب است.

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

پنهان کردن حذف یا امنیت نیست. شیء هنوز می‌تواند توسط کاربر یا کد کشف و دوباره نمایان شود و همچنان بخشی از فایل ارائه باقی می‌ماند.

### **تغییر ترتیب Z**

اشکال همپوشانیافته بر اساس ترتیب مجموعه نقاشی می‌شوند. [Reorder](https://reference.aspose.com/slides/fa/net/aspose.slides/ishapecollection/reorder/) یک شکل موجود را به اندیس هدف می‌برد بدون اینکه آن را کلون کند. اندیس `0` پشت‌ترین است؛ `Count - 1` جلوی‌ترین.

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

در ابتدا مستطیل ساخته می‌شود و پشت بیضی قرار دارد. جابجایی آن به اندیس نهایی آن را به جلو می‌برد. پس از افزودن یا کلون تمام اشکال مرتبط، ترتیب z‑order را نهایی کنید، زیرا این عملیات موارد جدیدی به مجموعه اضافه یا درج می‌کنند و می‌توانند ترتیب دلخواه را تغییر دهند.

## **بازرسی اشکال در اسلایدهای طرح‌بندی**

اسلایدهای معمولی، اسلایدهای طرح‌بندی و اسلایدهای مادر مجموعهٔ اشکال جداگانه‌ای دارند. یک شکل در مجموعهٔ طرح‌بندی همان شیء شکل در اسلاید معمولی نیست. هنگام نیاز به درک یا تغییر قالب‌بندی‌ای که توسط یک طرح‌بندی فراهم شده است، اشکال طرح‌بندی را بررسی کنید.

مثال زیر `FillFormat` و `LineFormat` هر شکل در طرح‌بندی را می‌خواند بدون این فرض که هر شکل یک `AutoShape` باشد.

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

ویرایش یک طرح‌بندی می‌تواند بر اسلایدهای متعددی که از آن استفاده می‌کنند تأثیر بگذارد. قبل از تغییر یک شکل در طرح‌بندی، تعیین کنید آیا اسلاید معمولی آن شیء را ارث می‌برد یا یک بازنویسی محلی دارد، و هر اسلایدی که از آن طرح‌بندی استفاده می‌کند را تست کنید.

## **صادر کردن یک شکل به SVG**

[WriteAsSvg](https://reference.aspose.com/slides/fa/net/aspose.slides/ishape/writeassvg/) محتوای رندرشدهٔ یک شکل را به یک استریم می‌نویسد. نتیجه فقط شامل شکل است، نه پس‌زمینهٔ کامل اسلاید یا اشکال همسایه.

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

همزمان با رندر، ارائه را باز نگه دارید. خروجی به قالب‌بندی شکل و به منابعی مانند فونت‌ها و تصاویر وابسته است. اگر به کل ترکیب نیاز دارید، اسلاید را به‌جای یک شکل منفرد صادر کنید. فراخواننده مالک استریم است و باید آن را آزاد کند.

## **تراز کردن اشکال**

متدهای [SlideUtil.AlignShapes](https://reference.aspose.com/slides/fa/net/aspose.slides.util/slideutil/alignshapes/) می‌توانند همهٔ اشکال یا اندیس‌های انتخاب‌شدهٔ مجموعه را تراز کنند. [ShapesAlignmentType](https://reference.aspose.com/slides/fa/net/aspose.slides/shapesalignmenttype/) لبه، خط میانه یا حالت توزیع را مشخص می‌کند. `alignToSlide` را روی `true` تنظیم کنید تا از لبه‌های اسلاید استفاده شود؛ روی `false` تنظیم کنید تا اشکال منتخب نسبت به یکدیگر تراز شوند.

این مثال سه شکل را به لبهٔ بالایی اسلاید تراز می‌کند. ارجاع‌های شکل برگرفته‌شده بلافاصله قبل از تراز به اندیس‌های فعلیشان تبدیل می‌شوند.

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

تراز کردن موقعیت‌ها را تغییر می‌دهد، نه ترتیب z‑order. تراز نسبی معمولاً به حداقل دو شکل نیاز دارد، در حالی که توزیع افقی یا عمودی به تعداد کافی شکل برای تعریف فاصله‌ها نیاز دارد. اگر قبل از فراخوانی متد مجموعه را تغییر می‌دهید، اندیس‌ها را دوباره محاسبه کنید.

## **معکوس کردن یک شکل**

کلاس [ShapeFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/shapeframe/) موقعیت، اندازه، تنظیمات معکوس افقی و عمودی و چرخش را ذخیره می‌کند. مقادیر `FlipH` و `FlipV` از [NullableBool](https://reference.aspose.com/slides/fa/net/aspose.slides/nullablebool/) استفاده می‌کنند: `True` معکوس را فعال می‌کند، `False` غیرفعال می‌کند و `NotDefined` حالت ناشناخته/پیش‌فرض را حفظ می‌کند.

ارائهٔ ورودی زیر شامل یک شکل بدون معکوس است.

![شکل قبل از معکوس کردن](shape_to_be_flipped.png)

مثال فقط مقادیر دیگر فریم را حفظ می‌کند و تنها دو تنظیم معکوس را جایگزین می‌کند. این مهم است چون اختصاص یک [Frame](https://reference.aspose.com/slides/fa/net/aspose.slides/ishape/frame/) جدید تمام فریم را بازنویسی می‌کند.

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

شکل ذخیره‌شده به صورت افقی و عمودی معکوس می‌شود در حالی که موقعیت، اندازه و چرخش آن حفظ می‌شوند.

![شکل بعد از معکوس کردن](flipped_shape.png)

## **سوالات متداول**

**آیا باید از اندیس مجموعه به عنوان شناسه یک شکل استفاده کنم؟**

فقط برای پردازش‌های کوتاه‌مدت که قبل از استفاده از اندیس، مجموعه تغییر نخواهد کرد. برای قالب‌های نویسنده‌شده یک قرارداد معتبر `Name` یا `AlternativeText` ترجیح دهید، یا برای کارهای interop scoped به اسلاید از `OfficeInteropShapeId` استفاده کنید.

**آیا مخفی کردن یک شکل آن را از ترتیب Z حذف می‌کند؟**

خیر. یک شکل مخفی در همان اندیس باقی می‌ماند. می‌توان آن را پیدا کرد، دوباره ترتیب داد، ویرایش کرد یا دوباره نمایان ساخت.

**چرا یک شکل کلون‌شده جلوی شکل دیگری ظاهر شد؟**

`AddClone` کلون را به انتهای مجموعه اضافه می‌کند که جلوی ترتیب Z است. برای انتخاب اندیس اولیه از `InsertClone` استفاده کنید یا پس از افزودن تمام اشکال از `Reorder` استفاده کنید.