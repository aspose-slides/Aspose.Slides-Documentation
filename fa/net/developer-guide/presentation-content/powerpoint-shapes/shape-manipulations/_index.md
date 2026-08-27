---
title: مدیریت اشکال ارائه در .NET
linktitle: دستکاری اشکال
type: docs
weight: 40
url: /fa/net/shape-manipulations/
keywords:
- اشکال PowerPoint
- اشکال ارائه
- اشکال در اسلاید
- یافتن اشکال
- کلون کردن اشکال
- حذف اشکال
- مخفی کردن اشکال
- تغییر ترتیب اشکال
- دریافت شناسه interop اشکال
- متن جایگزین اشکال
- نقطه تنظیم اشکال
- تنظیم پیش‌تنظیم اشکال
- هندسهٔ اشکال
- قالب‌بندی‌های لایهٔ اشکال
- اشکال به صورت SVG
- تبدیل اشکال به SVG
- تراز کردن اشکال
- چرخاندن اشکال
- PowerPoint
- ارائه
- .NET
- C#
- Aspose.Slides
description: "آموزش شناسایی، تنظیم، کلون، حذف، مخفی‌سازی، بازترتیب، خروجی، تراز و چرخاندن اشکال ارائه با Aspose.Slides برای .NET."
---
## **بررسی کلی**

Aspose.Slides for .NET اشکال موجود در یک اسلاید را به عنوان یک ‎[IShapeCollection](https://reference.aspose.com/slides/fa/net/aspose.slides/ishapecollection/)‎ مرتب شده نشان می‌دهد. این مجموعه هم محلی است که می‌توانید اشکال را پیدا و اصلاح کنید و هم منبع ترتیب لایهٔ آن‌ها: اندیس ‎0‎ پشت‌ترین شکل است، در حالی که آخرین اندیس، شکل جلویی‌ترین است.

این مقاله همین مدل را دنبال می‌کند. ابتدا توضیح می‌دهد چگونه می‌توان یک شکل را به‌طور قابل اطمینان شناسایی و نقاط تنظیم از پیش تعریف‌شدهٔ آن را اصلاح کرد، سپس نشان می‌دهد چگونه می‌توان اشکال را کلون، حذف، مخفی و بازترتیب کرد. بخش‌های نهایی به قالب‌بندی سطح طرح، خروجی SVG، تراز و تنظیمات چرخش می‌پردازند. هر مثال مستقل است، بنابراین می‌توانید تنها عملیات مورد نیاز جریان کاری خود را استفاده کنید.

## **شناسایی و یافتن اشکال**

اندیس‌های مجموعه هنگام پردازش یک فایل شناخته‌شده مفید هستند، اما شناسه‌های پایداری نیستند. افزودن، حذف یا بازترتیب یک شکل می‌تواند اندیس آن را تغییر دهد. یک شناسه مناسب بر اساس نحوهٔ ایجاد و نگهداری ارائه انتخاب کنید:

- ‎[Name](https://reference.aspose.com/slides/fa/net/aspose.slides/ishape/name/)‎ برای قالب‌های کنترل‌شده توسط توسعه‌دهنده مفید است و در پنل انتخاب PowerPoint به‌راحتی قابل بررسی است. نام‌ها قابل ویرایش‌اند اما تضمین نمی‌شود که یکتا باشند، بنابراین اگر کد به آن‌ها وابسته است یک قرارداد نام‌گذاری تعریف کنید.
- ‎[AlternativeText](https://reference.aspose.com/slides/fa/net/aspose.slides/ishape/alternativetext/)‎ زمانی مفید است که یک توضیح دسترس‌پذیری یا برچسبی که توسط نویسنده ارائه شده است، پیشاپیش شکل را شناسایی می‌کند. این متن برای کاربران قابل دیدن است، ممکن است بومی‌سازی یا برای دسترس‌پذیری بازنویسی شود و تضمین یکتایی ندارند. متن دسترس‌پذیری معنادار را به‌صورت ساکت به‌عنوان کلید پایگاه داده استفاده نکنید.
- ‎[OfficeInteropShapeId](https://reference.aspose.com/slides/fa/net/aspose.slides/ishape/officeinteropshapeid/)‎ یک شناسهٔ فقط‑خواندنی است که درون یک اسلاید یکتا است و به شناسهٔ شکل استفاده‌شده توسط PowerPoint interop مربوط می‌شود. هنگام یکپارچه‌سازی با PowerPoint یا زمانی که به یک مرجع واضح در طول عمر یک شکل نیاز دارید از آن استفاده کنید. یک شکل کلون‌شده یا بازساخته، شکل متفاوتی است و شناسهٔ خاص خود را دریافت می‌کند.

ویژگی مرتبط ‎[UniqueId](https://reference.aspose.com/slides/fa/net/aspose.slides/ishape/uniqueid/)‎ دارای دامنهٔ ارائه است، اما برای افزونه‌ها منظور شده و می‌تواند مجدداً اختصاص یابد. نباید به‌عنوان کلید خارجی دائمی در نظر گرفته شود. اگر هویت طولانی‌مدت ضروری است، نگاشت را در داده‌های برنامه نگه دارید و اطمینان حاصل کنید که شکل مورد انتظار هنوز وجود دارد.

مثال زیر با استفاده از ‎Name‎ و مقایسهٔ ترتیبی جستجو می‌کند و شناسهٔ interop scoped به اسلاید را گزارش می‌دهد. وقتی قالب شامل شکل مورد انتظار نباشد، کد همان نتیجه را گزارش می‌کند به‌جای این‌که با شیء اشتباه ادامه دهد.

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

زمانی که یک عملیات به نوع خاصی از شکل مربوط می‌شود، پیش از استفاده از اعضای نوع‑خاص، اینترفیس را بررسی کنید. این مثال متن و متن جایگزین را فقط در صورتی به‌روز می‌کند که شیء نام‌دار یک ‎[IAutoShape](https://reference.aspose.com/slides/fa/net/aspose.slides/iautoshape/)‎ باشد.

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

## **شناسایی و تغییر تنظیمات پیش‌فرض شکل**

اشکال هندسی پیش‌فرض می‌توانند نقاط تنظیمی داشته باشند که ویژگی‌هایی مانند اندازهٔ گوشه، نسبت تیر یا زاویهٔ قوس را کنترل می‌کنند. با استفاده از مجموعهٔ فقط‑خواندنی ‎[IGeometryShape.Adjustments](https://reference.aspose.com/slides/fa/net/aspose.slides/igeometryshape/adjustments/)‎ به آن‌ها دسترسی پیدا کنید. خود مجموعه توسط شکل فراهم می‌شود، اما هر ‎[IAdjustValue](https://reference.aspose.com/slides/fa/net/aspose.slides/iadjustvalue/)‎ شامل مقدار قابل تغییر است.

فقط به اندیس ثابت مجموعه اکتفا نکنید. از طریق تنظیمات پیمایش کنید و ویژگی فقط‑خواندنی ‎[Type](https://reference.aspose.com/slides/fa/net/aspose.slides/adjustvalue/type/)‎ را بررسی کنید؛ مقدار ‎ShapeAdjustmentType‎ توضیح می‌دهد که تنظیم چه چیزی را کنترل می‌کند. ویژگی فقط‑خواندنی ‎[Name](https://reference.aspose.com/slides/fa/net/aspose.slides/adjustvalue/name/)‎ اطلاعات شناسایی اضافی می‌دهد و به‌ویژه وقتی یک پیش‌تنظیم بیش از یک تنظیم با همان نوع معنایی دارد، مفید است.

از ویژگی مقدار متناسب با معنای تنظیم استفاده کنید:

| نوع تنظیم | هدف | مقدار برای تغییر |
|---|---|---|
| `CornerSize` | اندازهٔ گوشه‌های گرد | [RawValue](https://reference.aspose.com/slides/fa/net/aspose.slides/adjustvalue/rawvalue/) |
| `ArrowTailThickness` | ضخامت دم تیر | `RawValue` |
| `ArrowheadLength` | طول سر تیر | `RawValue` |
| `ArrowheadWidth` | عرض سر تیر | `RawValue` |
| `StartAngle` | زاویهٔ شروع پای یا قوس | [AngleValue](https://reference.aspose.com/slides/fa/net/aspose.slides/adjustvalue/anglevalue/) |
| `EndAngle` | زاویهٔ پایان پای یا قوس | `AngleValue` |

`Type` و `Name` قابل تخصیص نیستند. `RawValue` یک عدد صحیح خواندنی/قابل‑نوشتن در واحدهای هندسی بومی پیش‌تنظیم است، در حالی که `AngleValue` یک زاویهٔ خواندنی/قابل‑نوشتن به درجه است. تعداد، ترتیب، معنی و بازهٔ معتبر تنظیمات به ‎[ShapeType](https://reference.aspose.com/slides/fa/net/aspose.slides/igeometryshape/shapetype/)‎ پیش‌تنظیم وابسته است. مقداری که برای یک پیش‌تنظیم معتبر است، ممکن است برای پیش‌تنظیم دیگری نامعتبر یا اثر متفاوتی داشته باشد.

وقتی `Type` برابر ‎ShapeAdjustmentType.Custom‎ باشد، API معنای معنایی استانداردی را شناسایی نمی‌کند. `Name`، نوع پیش‌تنظیم و مقدار موجود را بررسی کنید و تنظیم را دست‌نخورده بگذارید مگر اینکه معنا و بازهٔ مورد انتظار شناخته شده باشد. حتی برای انواع شناخته‌شده، قبل از انتخاب مقدار بررسی کنید که آیا همان نوع بیش از یک بار رخ می‌دهد یا نه. مقاله ‎[Connector](/slides/fa/net/connector/)‎ این وضعیت را با تنظیمات خم اتصال نشان می‌دهد.

مثال کامل زیر نسخه‌های پیش‌فرض و تغییر یافتهٔ سه شکل پیش‌تنظیم‌شده را می‌سازد. تمام تنظیمات را پیمایش می‌کند، `Name` و `Type` آن‌ها را گزارش می‌دهد، مقادیر مرتبط با اندازه را از طریق `RawValue`، زاویه‌ها را از طریق `AngleValue` تغییر می‌دهد و نتیجه را ذخیره می‌کند. ستون چپ هندسهٔ پیش‌فرض را حفظ می‌کند؛ ستون راست مستطیل گرد تنظیم‌شده، تیر چهار طرفه و پای را نشان می‌دهد.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

// سرصفحه‌ها را برای ستون‌های شکل پیش‌فرض و تنظیم‌شده اضافه می‌کند.
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

بررسی نوع معنایی قبل از تغییر مقدار باعث می‌شود کد هدف خود را صریحاً بیان کند و از فرض اینکه یک اندیس خاص در پیش‌تنظیم‌های مختلف همان معنا را دارد، جلوگیری شود.

## **تغییر مجموعهٔ اشکال**

متدهای افزودن، کلون، حذف و بازترتیب بلافاصله بر روی مجموعه اعمال می‌شوند. اگر عملیاتی تعداد یا ترتیب اشکال را تغییر دهد، پس از آن دیگر به اندیس‌های گرفته‌شده قبل از آن عملیات تکیه نکنید.

### **کلون کردن یک شکل**

‎[AddClone](https://reference.aspose.com/slides/fa/net/aspose.slides/ishapecollection/addclone/)‎ یک کپی مستقل می‌سازد و آن را به انتهای مجموعه هدف می‌افزاید. ‎[InsertClone](https://reference.aspose.com/slides/fa/net/aspose.slides/ishapecollection/insertclone/)‎ نیز یک کپی می‌سازد اما آن را در یک اندیس z‑order مشخص قرار می‌دهد. overloadهایی که مختصات می‌پذیرند، کلون را بدون تغییر اندازه حرکت می‌دهند؛ overloadهایی با عرض و ارتفاع می‌توانند اندازه را نیز تغییر دهند.

مثال یک اسلاید مقصد می‌سازد، مستطیل برچسب‌دار را به جلو کلون می‌کند و کلون دوم را در عقب 삽입 می‌کند. تغییرات در هر یک از کلون‌ها شکل منبع را تحت تأثیر قرار نمی‌دهد.

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

کلون کردن محتوای شکل و قالب‌بندی آن را شامل نام و متن جایگزین کپی می‌کند. وقتی این مقادیر باید یکتا باشند، شناسه‌های منطقی جدیدی به کلون اختصاص دهید. منابع مورد استفادهٔ اشکال پیچیده توسط ارائه‌نامه مدیریت می‌شوند، اما یک کلون یک مورد جدید در مجموعه با شناسهٔ شکل جدید است.

### **حذف اشکال**

‎[Remove](https://reference.aspose.com/slides/fa/net/aspose.slides/ishapecollection/remove/)‎ یک شیء شکل خاص را از مجموعه‌اش حذف می‌کند. هنگام حذف چندین تطبیق در طول یک حلقهٔ اندیس‌دار، از انتها به جلو پیش بروید تا هر اندیس باقی‌مانده معتبر بماند.

این مثال هر شکلی که نام تعیین‌شده دارد را حذف می‌کند. آن ‎slide.Shapes[i]‎ را می‌خواند، نه یک آیتم ثابت مجموعه، و شکل را به‌صورت غیرضروری کست نمی‌کند.

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

پس از حذف، تعداد اشکال و اندیس‌های اشکال بعدی تغییر می‌کند. ارجاعات به اشکال غیرمُتأثر نسبت به اندیس‌های ذخیره‌شده قابل اطمینان‌تر هستند. همچنین به اتصال‌ها، انیمیشن‌ها و سایر ویژگی‌های ارائه که ممکن است به شیء حذف‌شده اشاره داشته باشند، توجه کنید؛ حذف یک شکل قابل مشاهده می‌تواند بیش از ظاهر اسلاید را تغییر دهد.

### **مخفی کردن یک شکل**

تنظیم ‎[Hidden](https://reference.aspose.com/slides/fa/net/aspose.slides/ishape/hidden/)‎ روی ‎true‎ شکل را در مجموعه نگه می‌دارد اما از ظاهر شدن آن در نمایش معمولی اسلاید جلوگیری می‌کند. اندیس، قالب‌بندی و محتویات آن برای کد در دسترس می‌مانند، بنابراین مخفی‌سازی برای عناصری که ممکن است بعداً بازگردانده شوند مناسب است.

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

مخفی‌سازی حذف یا امنیت نیست. شیء همچنان می‌تواند توسط کاربر یا کد کشف و آشکار شود و بخشی از فایل ارائه باقی می‌ماند.

### **تغییر Z‑Order**

اشکال هم‑پوشانی‌شده به ترتیب مجموعه رنگ می‌شوند. ‎[Reorder](https://reference.aspose.com/slides/fa/net/aspose.slides/ishapecollection/reorder/)‎ یک شکل موجود را به یک اندیس هدف منتقل می‌کند بدون این که آن را کلون کند. اندیس ‎0‎ پشت است؛ ‎Count - 1‎ جلو.

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

مستطیل ابتدا ساخته می‌شود و در ابتدا پشت بیضی قرار دارد. جابه‌جا کردن آن به اندیس نهایی، آن را به جلو می‌برد. پس از افزودن یا کلون کردن تمام اشکال مرتبط، Z‑Order را نهایی کنید، چون این عملیات موارد جدیدی به مجموعه اضافه یا درج می‌کنند و می‌توانند ترتیب دلخواه را تغییر دهند.

## **بازرسی اشکال در اسلایدهای Layout**

اسلایدهای عادی، اسلایدهای layout و اسلایدهای master مجموعهٔ اشکال جداگانه‌ای دارند. یک شکل در مجموعهٔ layout با یک شکل مشابه در اسلاید عادی یک شیء یکسان نیست. هنگام نیاز به درک یا تغییر قالب‌بندی ارائه‌شده توسط یک layout، اشکال layout را بررسی کنید.

مثال زیر ‎FillFormat‎ و ‎LineFormat‎ هر شکل layout را می‌خواند بدون اینکه فرض کند هر شکل یک ‎AutoShape‎ است.

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

ویرایش یک layout می‌تواند بر چندین اسلایدی که از آن استفاده می‌کنند اثر بگذارد. پیش از تغییر یک شکل layout، تعیین کنید آیا اسلاید عادی شی را به ارث می‌برد یا دارای بازنویسی محلی است و هر اسلایدی که از آن layout استفاده می‌کند را تست کنید.

## **صدور یک شکل به SVG**

‎[WriteAsSvg](https://reference.aspose.com/slides/fa/net/aspose.slides/ishape/writeassvg/)‎ محتوای رندر شدهٔ یک شکل را به یک جریان می‌نویسد. نتیجه شامل همان شکل است، نه پس‌زمینه کل اسلاید یا اشکال همسایه.

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

در حین رندر، ارائه را باز نگه دارید. خروجی به قالب‌بندی شکل و به منابعی مانند فونت‌ها و تصویرها وابسته است. اگر به ترکیب کامل نیاز دارید، اسلاید را به‌جای یک شکل منفرد صادر کنید. فراخواننده مالک جریان است و باید آن را تخلیه کند.

## **تراز اشکال**

متدهای ‎[SlideUtil.AlignShapes](https://reference.aspose.com/slides/fa/net/aspose.slides.util/slideutil/alignshapes/)‎ می‌توانند همهٔ اشکال یا اندیس‌های انتخابی مجموعه را تراز کنند. ‎[ShapesAlignmentType](https://reference.aspose.com/slides/fa/net/aspose.slides/shapesalignmenttype/)‎ لبه، خط مرکز یا حالت توزیع را مشخص می‌کند. مقدار ‎alignToSlide‎ را روی ‎true‎ بگذارید تا از لبه‌های اسلاید استفاده شود؛ روی ‎false‎ بگذارید تا اشکال انتخابی نسبت به یکدیگر تراز شوند.

این مثال سه شکل را به لبهٔ بالای اسلاید تراز می‌کند. مراجع شکل‌های برگشتی بلافاصله قبل از تراز به اندیس‌های فعلیشان تبدیل می‌شوند.

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

تراز موقعیت‌ها را تغییر می‌دهد، نه Z‑Order. تراز نسبی معمولاً به حداقل دو شکل نیاز دارد، در حالی که توزیع افقی یا عمودی به تعداد کافی شکلی برای تعریف فواصل نیاز دارد. اگر قبل از فراخوانی متد مجموعه را تغییر دادید، اندیس‌ها را دوباره محاسبه کنید.

## **چرخاندن (Flip) یک شکل**

کلاس ‎[ShapeFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/shapeframe/)‎ موقعیت، اندازه، تنظیمات چرخش افقی و عمودی و چرخش را ذخیره می‌کند. مقادیر ‎FlipH‎ و ‎FlipV‎ از ‎[NullableBool](https://reference.aspose.com/slides/fa/net/aspose.slides/nullablebool/)‎ استفاده می‌کنند: ‎True‎ چرخش را فعال می‌کند، ‎False‎ غیرفعال می‌کند و ‎NotDefined‎ حالت پیش‌فرض/نامشخص را حفظ می‌کند.

ارائهٔ زیر یک شکل بدون چرخش دارد.

![The shape before flipping](shape_to_be_flipped.png)

مثال فقط مقادیر دو تنظیم چرخش را تغییر می‌دهد و سایر مقادیر فریم را همان‌طور نگه می‌دارد. این مهم است زیرا تخصیص یک ‎[Frame](https://reference.aspose.com/slides/fa/net/aspose.slides/ishape/frame/)‎ جدید تمام فریم را جایگزین می‌کند.

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

شکل ذخیره‌شده به صورت افقی و عمودی معکوس می‌شود در حالی که موقعیت، اندازه و چرخش آن حفظ می‌شود.

![The shape after flipping](flipped_shape.png)

## **سؤالات متداول**

**آیا باید از اندیس مجموعه به‌عنوان شناسهٔ شکل استفاده کنم؟**

فقط برای پردازش کوتاه‌مدتی که مجموعه قبل از استفاده از اندیس تغییر نمی‌کند. برای قالب‌های نوشته‌شده، ترجیحاً از یک قرارداد معتبر ‎Name‎ یا ‎AlternativeText‎ استفاده کنید؛ یا برای کارهای interop scoped به اسلاید، ‎OfficeInteropShapeId‎ را به کار ببرید.

**آیا مخفی‌سازی یک شکل آن را از Z‑Order حذف می‌کند؟**

خیر. یک شکل مخفی در همان اندیس مجموعه می‌ماند. می‌تواند پیدا شود، بازترتیب شود، ویرایش یا دوباره قابل رؤیت شود.

**چرا یک شکل کلون‌شده جلوی شکل دیگری ظاهر شد؟**

‎AddClone‎ کلون را به انتهای مجموعه می‌افزاید که جلو Z‑Order است. برای انتخاب اندیس اولیه از ‎InsertClone‎ استفاده کنید یا پس از افزودن تمام اشکال از ‎Reorder‎ بهره ببرید.

**آیا می‌توانم از یک اندیس ثابت برای شناسایی تنظیم پیش‌تنظیم شکل استفاده کنم؟**

تنها پس از اعتبارسنجی دقیق پیش‌تنظیم و چیدمان مجموعه. ترجیحاً ‎IGeometryShape.Adjustments‎ را پیمایش کنید و ‎IAdjustValue.Type‎ را بررسی کنید؛ وقتی همان نوع معنایی بیش از یک بار ظاهر می‌شود، ‎IAdjustValue.Name‎ را به عنوان اطلاعات تکمیلی به کار ببرید.