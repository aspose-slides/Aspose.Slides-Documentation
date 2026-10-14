---
title: قالب‌بندی اشکال PowerPoint در .NET
linktitle: قالب‌بندی شکل
type: docs
weight: 20
url: /fa/net/shape-formatting/
keywords:
- قالب‌بندی شکل
- قالب‌بندی خط
- اثر اسکچ
- خط شکل اسکچ
- قالب‌بندی سبک اتصال
- پر کردن گرادیان
- پر کردن الگو
- پر کردن تصویر
- پر کردن بافت
- پر کردن با رنگ یکدست
- شفافیت شکل
- رندر سیاه‑سفید شکل
- رندر خاکستری شکل
- چرخاندن شکل
- اثر برش ۳‑بعدی
- اثر چرخش ۳‑بعدی
- بازنشانی قالب‌بندی
- PowerPoint
- ارائه
- .NET
- C#
- Aspose.Slides
description: "یاد بگیرید چگونه اشکال PowerPoint را در C# با استفاده از Aspose.Slides قالب‌بندی کنید—پر کردن، خط و سبک‌های اثر را برای فایل‌های PPT و PPTX با دقت و کنترل کامل تنظیم نمایید."
---
## **مقدمه**

در PowerPoint می‌توانید اشکال را به اسلایدها اضافه کنید. از آنجا که اشکال از خطوط تشکیل شده‌اند، می‌توانید آنها را با تغییر یا اعمال اثرات بر روی خطوط مرزیشان قالب‌بندی کنید. علاوه بر این، می‌توانید با تعیین تنظیماتی که نحوه پر کردن داخلی آنها را کنترل می‌کند، اشکال را قالب‌بندی کنید.

![قالب‌اشکال‑پاورپوینت](format-shape-powerpoint.png)

Aspose.Slides برای .NET رابط‌ها و ویژگی‌هایی را فراهم می‌کند که به شما اجازه می‌دهد اشکال را با همان گزینه‌های موجود در PowerPoint قالب‌بندی کنید.

## **قالب‌بندی خطوط**

با استفاده از Aspose.Slides می‌توانید یک سبک خط سفارشی برای یک شکل مشخص کنید. مراحل زیر روش کار را شرح می‌دهند:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) بسازید.
1. مرجعی به اسلایدی بر اساس شاخص آن دریافت کنید.
1. یک [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) به اسلاید اضافه کنید.
1. [line style](https://reference.aspose.com/slides/net/aspose.slides/linestyle/) شکل را تنظیم کنید.
1. عرض خط را تنظیم کنید.
1. [dash style](https://reference.aspose.com/slides/net/aspose.slides/linedashstyle/) خط را تنظیم کنید.
1. رنگ خط برای شکل را تنظیم کنید.
1. ارائهٔ اصلاح‌شده را به‌صورت فایل PPTX ذخیره کنید.

کد C# زیر نشان می‌دهد چگونه یک `AutoShape` مستطیل را قالب‌بندی کنید:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// یک نمونه از کلاس Presentation که نمایانگر یک فایل ارائه است ایجاد کنید.
using (Presentation presentation = new Presentation())
{
    // اسلاید اول را دریافت کنید.
    ISlide slide = presentation.Slides[0];

    // یک شکل خودکار از نوع مستطیل اضافه کنید.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // رنگ پر کردن برای شکل مستطیل را تنظیم کنید.
    shape.FillFormat.FillType = FillType.NoFill;

    // قالب‌بندی را بر خطوط مستطیل اعمال کنید.
    shape.LineFormat.Style = LineStyle.ThickThin;
    shape.LineFormat.Width = 7;
    shape.LineFormat.DashStyle = LineDashStyle.Dash;

    // رنگ خط مستطیل را تنظیم کنید.
    shape.LineFormat.FillFormat.FillType = FillType.Solid;
    shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;

    // فایل PPTX را بر روی دیسک ذخیره کنید.
    presentation.Save("formatted_lines.pptx", SaveFormat.Pptx);
}
```

نتیجه:

![خطوط قالب‌بندی‌شده در ارائه](formatted-lines.png)

## **اعمال اثرهای اسکچ بر خطوط شکل**

یک اثر اسکچ باعث می‌شود خط شکل شبیه به دست‌نویس باشد. از [IShape.LineFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/lineformat/) برای دسترسی به تنظیمات خط، [ILineFormat.SketchFormat](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/sketchformat/) برای دسترسی به تنظیمات اسکچ، و [ISketchFormat.SketchType](https://reference.aspose.com/slides/net/aspose.slides/isketchformat/sketchtype/) برای انتخاب مقدار از شمارش‌گر [LineSketchType](https://reference.aspose.com/slides/net/aspose.slides/linesketchtype/) استفاده کنید.

کد C# زیر نشان می‌دهد چگونه اثر [LineSketchType.Curved](https://reference.aspose.com/slides/net/aspose.slides/linesketchtype/) را اعمال کرده، مقدار صراحتاً اختصاص‑یافته را بخوانید و اثر را با [LineSketchType.None](https://reference.aspose.com/slides/net/aspose.slides/linesketchtype/) حذف کنید:

```csharp
using Aspose.Slides;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);

// Access the shape's line format and its sketch format.
var sketchFormat = shape.LineFormat.SketchFormat;

// Apply a sketch effect.
sketchFormat.SketchType = LineSketchType.Curved;

// Read the sketch effect assigned directly to the shape.
var explicitSketchType = sketchFormat.SketchType;
Console.WriteLine($"Explicit sketch type: {explicitSketchType}");

// Remove the sketch effect.
sketchFormat.SketchType = LineSketchType.None;
```

مقداری که `ISketchFormat.SketchType` برمی‌گرداند، تنظیمی را نشان می‌دهد که مستقیماً به شکل اختصاص یافته است. اگر قالب‌بندی خط می‌تواند از تم، اسلاید‑اصلی یا اسلاید‑چیدمان ارث‌بری شود، از [ILineFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/geteffective/) استفاده کنید، به [ILineFormatEffectiveData.SketchFormat](https://reference.aspose.com/slides/net/aspose.slides/ilineformateffectivedata/sketchformat/) دسترسی پیدا کنید، و [ISketchFormatEffectiveData.SketchType](https://reference.aspose.com/slides/net/aspose.slides/isketchformateffectivedata/sketchtype/) را بخوانید. مقدار مؤثر، قالب‌بندی‌ای را نشان می‌دهد که پس از حل ارث‌بری واقعاً اعمال می‌شود:

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

var shape = presentation.Slides[0].Shapes[0];
var lineFormat = shape.LineFormat;

var explicitSketchType = lineFormat.SketchFormat.SketchType;
var effectiveLineFormat = lineFormat.GetEffective();
var effectiveSketchType = effectiveLineFormat.SketchFormat.SketchType;

Console.WriteLine($"Explicit sketch type: {explicitSketchType}");
Console.WriteLine($"Effective sketch type: {effectiveSketchType}");
```

## **قالب‌بندی سبک‌های اتصال**

در ادامه سه گزینهٔ نوع اتصال آورده شده است:

* گرد
* میتر
* شیاردار

به طور پیش‌فرض، وقتی PowerPoint دو خط را در یک زاویه (مانند گوشهٔ یک شکل) به‑هم می‌پیوندد، از تنظیم **گرد** استفاده می‌کند. با این حال، اگر شما شکلی با زوایای تیز می‌کشید، ممکن است گزینهٔ **میتر** را برگزینید.

![سبک اتصال در ارائه](join-style-powerpoint.png)

کد C# زیر نشان می‌دهد چگونه سه مستطیل (همان‌طور که در تصویر بالا نشان داده شده) با تنظیمات نوع اتصال میتر، شیاردار و گرد ایجاد شدند:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// یک نمونه از کلاس Presentation که نمایانگر یک فایل ارائه است ایجاد کنید.
using (Presentation presentation = new Presentation())
{
    // اسلاید اول را دریافت کنید.
    ISlide slide = presentation.Slides[0];

    // سه شکل خودکار از نوع مستطیل اضافه کنید.
    IAutoShape shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 75);
    IAutoShape shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 210, 20, 150, 75);
    IAutoShape shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 135, 150, 75);

    // رنگ پر کردن برای هر شکل مستطیل را تنظیم کنید.
    shape1.FillFormat.FillType = FillType.Solid;
    shape1.FillFormat.SolidFillColor.Color = Color.Black;
    shape2.FillFormat.FillType = FillType.Solid;
    shape2.FillFormat.SolidFillColor.Color = Color.Black;
    shape3.FillFormat.FillType = FillType.Solid;
    shape3.FillFormat.SolidFillColor.Color = Color.Black;

    // عرض خط را تنظیم کنید.
    shape1.LineFormat.Width = 15;
    shape2.LineFormat.Width = 15;
    shape3.LineFormat.Width = 15;

    // رنگ خط برای هر مستطیل را تنظیم کنید.
    shape1.LineFormat.FillFormat.FillType = FillType.Solid;
    shape1.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    shape2.LineFormat.FillFormat.FillType = FillType.Solid;
    shape2.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    shape3.LineFormat.FillFormat.FillType = FillType.Solid;
    shape3.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;

    // سبک اتصال را تنظیم کنید.
    shape1.LineFormat.JoinStyle = LineJoinStyle.Miter;
    shape2.LineFormat.JoinStyle = LineJoinStyle.Bevel;
    shape3.LineFormat.JoinStyle = LineJoinStyle.Round;

    // متن را به هر مستطیل اضافه کنید.
    shape1.TextFrame.Text = "Miter Join Style";
    shape2.TextFrame.Text = "Bevel Join Style";
    shape3.TextFrame.Text = "Round Join Style";

    // فایل PPTX را بر روی دیسک ذخیره کنید.
    presentation.Save("join_styles.pptx", SaveFormat.Pptx);
}
```

## **پر کردن با گرادیان**

در PowerPoint، «پر کردن با گرادیان» یک گزینهٔ قالب‌بندی است که به شما امکان می‌دهد ترکیبی پیوسته از رنگ‌ها را بر روی یک شکل اعمال کنید. به‌عنوان مثال، می‌توانید دو یا چند رنگ را به‌طوری اعمال کنید که یکی به‑تدریج به دیگری محو شود.

در ادامه نحوهٔ اعمال پر کردن گرادیان به یک شکل با استفاده از Aspose.Slides آورده شده است:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) بسازید.
1. مرجعی به اسلایدی بر اساس شاخص آن دریافت کنید.
1. یک [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) به اسلاید اضافه کنید.
1. ویژگی [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) شکل را به `Gradient` تنظیم کنید.
1. دو رنگ دلخواه خود را با موقعیت‌های تعریف‌شده با استفاده از متدهای `Add` جمع‌آوری گرادیان‌استاپ که توسط رابط [IGradientFormat](https://reference.aspose.com/slides/net/aspose.slides/igradientformat/) در دسترس است، اضافه کنید.
1. ارائهٔ اصلاح‌شده را به‌صورت فایل PPTX ذخیره کنید.

کد C# زیر نشان می‌دهد چگونه یک اثر پر کردن گرادیان به یک بیضی اعمال می‌شود:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// یک نمونه از کلاس Presentation که نمایانگر یک فایل ارائه است ایجاد کنید.
using (Presentation presentation = new Presentation())
{
    // اسلاید اول را دریافت کنید.
    ISlide slide = presentation.Slides[0];

    // یک شکل خودکار از نوع بیضی اضافه کنید.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // قالب‌بندی گرادیان را به بیضی اعمال کنید.
    shape.FillFormat.FillType = FillType.Gradient;
    shape.FillFormat.GradientFormat.GradientShape = GradientShape.Linear;

    // جهت گرادیان را تنظیم کنید.
    shape.FillFormat.GradientFormat.GradientDirection = GradientDirection.FromCorner2;

    // دو ایست‌گرادیان اضافه کنید.
    shape.FillFormat.GradientFormat.GradientStops.Add(1.0f, PresetColor.Purple);
    shape.FillFormat.GradientFormat.GradientStops.Add(0.0f, PresetColor.Red);

    // فایل PPTX را بر روی دیسک ذخیره کنید.
    presentation.Save("gradient_fill.pptx", SaveFormat.Pptx);
}
```

نتیجه:

![بیضی با پر کردن گرادیان](gradient-fill.png)

اگر یک گرادیان در تصویر خروجی متفاوت از آنچه در PowerPoint می‌بینید باشد، به [Choose a Gradient Rendering Style](/slides/fa/net/convert-powerpoint-to-png/#choose-a-gradient-rendering-style) مراجعه کنید. می‌توانید یک سبک رندر انتخاب کنید بدون اینکه پر کردن گرادیان ذخیره‌شده در ارائه تغییر کند.

## **پر کردن با الگو**

در PowerPoint، «پر کردن با الگو» یک گزینهٔ قالب‌بندی است که به شما اجازه می‌دهد یک طرح دو‑رنگ—مانند نقطه‌ها، خط‌ها، شطرنج‌مانند یا شطرنجی—را بر روی یک شکل اعمال کنید. می‌توانید رنگ‌های پیش‌زمینه و پس‌زمینه الگو را به دلخواه انتخاب کنید.

Aspose.Slides بیش از ۴۵ سبک الگوی پیش‌تعریف‌شده ارائه می‌دهد که می‌توانید آنها را بر روی اشکال برای افزایش جذابیت بصری ارائه‌هایتان اعمال کنید. حتی پس از انتخاب یک الگوی پیش‌تعریف‌شده، همچنان می‌توانید رنگ‌های دقیق مورد استفاده را مشخص کنید.

در ادامه نحوهٔ اعمال پر کردن الگو به یک شکل با استفاده از Aspose.Slides آورده شده است:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) بسازید.
1. مرجعی به اسلایدی بر اساس شاخص آن دریافت کنید.
1. یک [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) به اسلاید اضافه کنید.
1. ویژگی [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) شکل را به `Pattern` تنظیم کنید.
1. یک سبک الگو از گزینه‌های پیش‌تعریف‌شده انتخاب کنید.
1. [Background Color](https://reference.aspose.com/slides/net/aspose.slides/ipatternformat/backcolor/) الگو را تنظیم کنید.
1. [Foreground Color](https://reference.aspose.com/slides/net/aspose.slides/ipatternformat/forecolor/) الگو را تنظیم کنید.
1. ارائهٔ اصلاح‌شده را به‌صورت فایل PPTX ذخیره کنید.

کد C# زیر نشان می‌دهد چگونه یک پر کردن الگو به یک مستطیل اعمال می‌شود:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// یک نمونه از کلاس Presentation که نمایانگر یک فایل ارائه است ایجاد کنید.
using (Presentation presentation = new Presentation())
{
    // اسلاید اول را دریافت کنید.
    ISlide slide = presentation.Slides[0];

    // یک شکل خودکار از نوع مستطیل اضافه کنید.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // نوع پر کردن را به Pattern تنظیم کنید.
    shape.FillFormat.FillType = FillType.Pattern;

    // سبک الگو را تنظیم کنید.
    shape.FillFormat.PatternFormat.PatternStyle = PatternStyle.Trellis;

    // رنگ زمینه و رنگ پیش‌زمینه الگو را تنظیم کنید.
    shape.FillFormat.PatternFormat.BackColor.Color = Color.LightGray;
    shape.FillFormat.PatternFormat.ForeColor.Color = Color.Yellow;

    // فایل PPTX را بر روی دیسک ذخیره کنید.
    presentation.Save("pattern_fill.pptx", SaveFormat.Pptx);
}
```

نتیجه:

![مستطیل با پر کردن الگو](pattern-fill.png)

## **پر کردن با تصویر**

در PowerPoint، «پر کردن با تصویر» یک گزینهٔ قالب‌بندی است که به شما اجازه می‌دهد یک تصویر را داخل یک شکل درج کنید—به‌صورت مؤثر، تصویر را به‌عنوان پس‌زمینهٔ شکل استفاده می‌کنید.

در ادامه نحوهٔ استفاده از Aspose.Slides برای اعمال پر کردن تصویر به یک شکل آورده شده است:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) بسازید.
1. مرجعی به اسلایدی بر اساس شاخص آن دریافت کنید.
1. یک [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) به اسلاید اضافه کنید.
1. ویژگی [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) شکل را به `Picture` تنظیم کنید.
1. حالت پر کردن تصویر را به `Tile` (یا حالت دلخواه دیگری) تنظیم کنید.
1. یک شیء [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/) از تصویری که می‌خواهید استفاده کنید، ایجاد کنید.
1. این تصویر را به ویژگی `Picture.Image` از `PictureFillFormat` شکل اختصاص دهید.
1. ارائهٔ اصلاح‌شده را به‌صورت فایل PPTX ذخیره کنید.

بیایید بگوییم فایلی به نام «lotus.png» با تصویر زیر داریم:

![تصویر لوتوس](lotus.png)

کد C# زیر نشان می‌دهد چگونه یک شکل را با تصویر پر کنید:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// یک نمونه از کلاس Presentation که نمایانگر یک فایل ارائه است ایجاد کنید.
using (Presentation presentation = new Presentation())
{
    // اسلاید اول را دریافت کنید.
    ISlide slide = presentation.Slides[0];

    // یک شکل خودکار از نوع مستطیل اضافه کنید.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);

    // نوع پر کردن را به Picture تنظیم کنید.
    shape.FillFormat.FillType = FillType.Picture;

    // حالت پر کردن تصویر را تنظیم کنید.
    shape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Tile;

    // یک تصویر را بارگذاری کرده و به منابع ارائه اضافه کنید.
    IImage image = Images.FromFile("lotus.png");
    IPPImage presentationImage = presentation.Images.AddImage(image);
    image.Dispose();

    // تصویر را تنظیم کنید.
    shape.FillFormat.PictureFillFormat.Picture.Image = presentationImage;

    // فایل PPTX را بر روی دیسک ذخیره کنید.
    presentation.Save("picture_fill.pptx", SaveFormat.Pptx);
}
```

نتیجه:

![شکل با پر کردن تصویر](picture-fill.png)

### **کاشی تصویر به عنوان بافت**

اگر می‌خواهید یک تصویر کاشی‌شده را به‌عنوان بافت تنظیم کنید و رفتار کاشی شدن را سفارشی کنید، می‌توانید از ویژگی‌های زیر رابط [IPictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/) و کلاس [PictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/) استفاده کنید:

- [PictureFillMode](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/picturefillmode/): حالت پر کردن تصویر را تنظیم می‌کند—یا `Tile` یا `Stretch`.
- [TileAlignment](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tilealignment/): تراز کاشی‌ها را در داخل شکل مشخص می‌کند.
- [TileFlip](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tileflip/): تعیین می‌کند آیا کاشی به‌صورت افقی، عمودی یا هر دو معکوس شود.
- [TileOffsetX](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tileoffsetx/): افست افقی کاشی (به پوینت) را از مبدا شکل تنظیم می‌کند.
- [TileOffsetY](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tileoffsety/): افست عمودی کاشی (به پوینت) را از مبدا شکل تنظیم می‌کند.
- [TileScaleX](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tilescalex/): مقیاس افقی کاشی را به‌صورت درصد تعریف می‌کند.
- [TileScaleY](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tilescaley/): مقیاس عمودی کاشی را به‌صورت درصد تعریف می‌کند.

نمونه کد زیر نشان می‌دهد چگونه یک شکل مستطیل با پر کردن تصویر کاشی‌شده اضافه کنید و گزینه‌های کاشی را پیکربندی کنید:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// یک نمونه از کلاس Presentation که نمایانگر یک فایل ارائه است ایجاد کنید.
using (Presentation presentation = new Presentation())
{
    // اسلاید اول را دریافت کنید.
    ISlide firstSlide = presentation.Slides[0];

    // یک شکل خودکار مستطیلی اضافه کنید.
    IAutoShape shape = firstSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

    // نوع پر کردن شکل را به Picture تنظیم کنید.
    shape.FillFormat.FillType = FillType.Picture;

    // تصویر را بارگذاری کرده و به منابع ارائه اضافه کنید.
    IPPImage presentationImage;
    using (IImage sourceImage = Images.FromFile("lotus.png"))
        presentationImage = presentation.Images.AddImage(sourceImage);

    // تصویر را به شکل اختصاص دهید.
    IPictureFillFormat pictureFillFormat = shape.FillFormat.PictureFillFormat;
    pictureFillFormat.Picture.Image = presentationImage;

    // حالت پر کردن تصویر و ویژگی‌های کاشی‌گذاری را پیکربندی کنید.
    pictureFillFormat.PictureFillMode = PictureFillMode.Tile;
    pictureFillFormat.TileOffsetX = -32;
    pictureFillFormat.TileOffsetY = -32;
    pictureFillFormat.TileScaleX = 50;
    pictureFillFormat.TileScaleY = 50;
    pictureFillFormat.TileAlignment = RectangleAlignment.BottomRight;
    pictureFillFormat.TileFlip = TileFlip.FlipBoth;

    // فایل PPTX را بر روی دیسک ذخیره کنید.
    presentation.Save("tile.pptx", SaveFormat.Pptx);
}
```

نتیجه:

![گزینه‌های کاشی](tile-options.png)

## **پر کردن با رنگ یکدست**

در PowerPoint، «پر کردن با رنگ یکدست» یک گزینهٔ قالب‌بندی است که شکل را با یک رنگ یکدست و یکنواخت پر می‌کند. این رنگ پس‌زمینه ساده بدون هیچ‌گونه گرادیان، بافت یا الگو اعمال می‌شود.

برای اعمال پر کردن رنگ یکدست به یک شکل با استفاده از Aspose.Slides، این مراحل را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) بسازید.
1. مرجعی به اسلایدی بر اساس شاخص آن دریافت کنید.
1. یک [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) به اسلاید اضافه کنید.
1. ویژگی [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) شکل را به `Solid` تنظیم کنید.
1. رنگ پر کردن مورد نظر خود را به شکل اختصاص دهید.
1. ارائهٔ اصلاح‌شده را به‌صورت فایل PPTX ذخیره کنید.

کد C# زیر نشان می‌دهد چگونه یک پر کردن رنگ یکدست به یک مستطیل در اسلاید PowerPoint اعمال می‌شود:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// یک نمونه از کلاس Presentation که نمایانگر یک فایل ارائه است ایجاد کنید.
using (Presentation presentation = new Presentation())
{
    // اسلاید اول را دریافت کنید.
    ISlide slide = presentation.Slides[0];

    // یک شکل خودکار از نوع مستطیل اضافه کنید.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // نوع پر کردن را به Solid تنظیم کنید.
    shape.FillFormat.FillType = FillType.Solid;

    // رنگ پر کردن را تنظیم کنید.
    shape.FillFormat.SolidFillColor.Color = Color.Yellow;

    // فایل PPTX را بر روی دیسک ذخیره کنید.
    presentation.Save("solid_color_fill.pptx", SaveFormat.Pptx);
}
```

نتیجه:

![شکل با پر کردن رنگ یکدست](solid-color-fill.png)

## **تنظیم شفافیت**

در PowerPoint، وقتی پر کردن رنگی، گرادیان، تصویر یا بافت را به اشکال اعمال می‌کنید، می‌توانید سطح شفافیت را نیز تنظیم کنید تا میزان شفافیت پر کردن را کنترل کنید. مقدار شفافیت بالاتر باعث می‌شود شکل شفاف‌تر شود و پس‌زمینه یا اشیای زیرین به‌صورت جزئی قابل مشاهده باشند.

Aspose.Slides به شما امکان می‌دهد سطح شفافیت را با تنظیم مقدار آلفا در رنگ استفاده‌شده برای پر کردن تنظیم کنید. در ادامه نحوهٔ انجام این کار آمده است:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) بسازید.
1. مرجعی به اسلایدی بر اساس شاخص آن دریافت کنید.
1. یک [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) به اسلاید اضافه کنید.
1. ویژگی [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) را به `Solid` تنظیم کنید.
1. از `Color.FromArgb(alpha, baseColor)` برای تعریف رنگی با شفافیت استفاده کنید (مقدار `alpha` شفافیت را کنترل می‌کند).
1. ارائه را ذخیره کنید.

کد C# زیر نشان می‌دهد چگونه یک رنگ پر کردن شفاف به یک مستطیل اعمال شود:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

const int alpha = 128;

// یک نمونه از کلاس Presentation که نمایانگر یک فایل ارائه است ایجاد کنید.
using (Presentation presentation = new Presentation())
{
    // اسلاید اول را دریافت کنید.
    ISlide slide = presentation.Slides[0];

    // یک شکل خودکار مستطیل ثابت اضافه کنید.
    IAutoShape solidShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // یک شکل خودکار مستطیل شفاف بر روی شکل ثابت اضافه کنید.
    IAutoShape transparentShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.FillFormat.FillType = FillType.Solid;
    transparentShape.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Yellow);

    // فایل PPTX را بر روی دیسک ذخیره کنید.
    presentation.Save("shape_transparency.pptx", SaveFormat.Pptx);
}
```

نتیجه:

![شکل شفاف](shape-transparency.png)

## **چرخاندن اشکال**

Aspose.Slides به شما اجازه می‌دهد اشکال را در ارائه‌های PowerPoint بچرخانید. این می‌تواند هنگام موقعیت‌یابی عناصر بصری با نیازهای خاص هم‌راستایی یا طراحی مفید باشد.

برای چرخاندن یک شکل در اسلاید، این مراحل را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) بسازید.
1. مرجعی به اسلایدی بر اساس شاخص آن دریافت کنید.
1. یک [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) به اسلاید اضافه کنید.
1. ویژگی `Rotation` شکل را بر حسب زاویهٔ دلخواه تنظیم کنید.
1. ارائه را ذخیره کنید.

کد C# زیر نشان می‌دهد چگونه یک شکل را به‌صورت 5 درجه بچرخانید:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// یک نمونه از کلاس Presentation که نمایانگر یک فایل ارائه است ایجاد کنید.
using (Presentation presentation = new Presentation())
{
    // اسلاید اول را دریافت کنید.
    ISlide slide = presentation.Slides[0];

    // یک شکل خودکار از نوع مستطیل اضافه کنید.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // شکل را به اندازه 5 درجه بچرخانید.
    shape.Rotation = 5;

    // فایل PPTX را بر روی دیسک ذخیره کنید.
    presentation.Save("shape_rotation.pptx", SaveFormat.Pptx);
}
```

نتیجه:

![چرخش شکل](shape-rotation.png)

## **افزودن اثرهای برش ۳ بعدی**

Aspose.Slides به شما اجازه می‌دهد اثرهای برش ۳ بعدی را به اشکال با پیکربندی ویژگی‌های [ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/threedformat/) اعمال کنید.

برای افزودن اثرهای برش ۳ بعدی به یک شکل، این مراحل را انجام دهید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) ایجاد کنید.
1. مرجعی به اسلایدی بر اساس شاخص آن دریافت کنید.
1. یک [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) به اسلاید اضافه کنید.
1. ویژگی‌های [ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/threedformat/) شکل را برای تعریف تنظیمات برش پیکربندی کنید.
1. ارائه را ذخیره کنید.

کد C# زیر نشان می‌دهد چگونه اثرهای برش ۳ بعدی به یک شکل اعمال شوند:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// یک نمونه از کلاس Presentation ایجاد کنید.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // یک شکل به اسلاید اضافه کنید.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 50, 100, 100);
    shape.FillFormat.FillType = FillType.Solid;
    shape.FillFormat.SolidFillColor.Color = Color.Green;
    shape.LineFormat.FillFormat.FillType = FillType.Solid;
    shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Orange;
    shape.LineFormat.Width = 2.0;

    // ویژگی‌های ThreeDFormat شکل را تنظیم کنید.
    shape.ThreeDFormat.Depth = 4;
    shape.ThreeDFormat.BevelTop.BevelType = BevelPresetType.Circle;
    shape.ThreeDFormat.BevelTop.Height = 6;
    shape.ThreeDFormat.BevelTop.Width = 6;
    shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
    shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.ThreePt;
    shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;

    // ارائه را به‌عنوان فایل PPTX ذخیره کنید.
    presentation.Save("3D_bevel_effect.pptx", SaveFormat.Pptx);
}
```

نتیجه:

![اثر برش ۳ بعدی](3D-bevel-effect.png)

## **افزودن اثرهای چرخش ۳ بعدی**

Aspose.Slides به شما اجازه می‌دهد اثرهای چرخش ۳ بعدی را به اشکال با پیکربندی ویژگی‌های [ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/threedformat/) اعمال کنید.

برای اعمال چرخش ۳ بعدی به یک شکل:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) ایجاد کنید.
1. مرجعی به اسلایدی بر اساس شاخص آن دریافت کنید.
1. یک [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) به اسلاید اضافه کنید.
1. ویژگی‌های [CameraType](https://reference.aspose.com/slides/net/aspose.slides/icamera/cameratype/) و [LightType](https://reference.aspose.com/slides/net/aspose.slides/ilightrig/lighttype/) شکل را برای تعریف چرخش ۳ بعدی تنظیم کنید.
1. ارائه را ذخیره کنید.

کد C# زیر نشان می‌دهد چگونه اثرهای چرخش ۳ بعدی به یک شکل اعمال شوند:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// یک نمونه از کلاس Presentation ایجاد کنید.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    autoShape.TextFrame.Text = "Hello, Aspose!";

    autoShape.ThreeDFormat.Camera.SetRotation(40, 35, 20);
    autoShape.ThreeDFormat.Camera.CameraType = CameraPresetType.IsometricLeftUp;
    autoShape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;

    // ارائه را به‌عنوان فایل PPTX ذخیره کنید.
    presentation.Save("3D_rotation_effect.pptx", SaveFormat.Pptx);
}
```

نتیجه:

![اثر چرخش ۳ بعدی](3D-rotation-effect.png)

## **کنترل رندر سیاه‑سفید برای اشکال**

ویژگی [IShape.BlackWhiteMode](https://reference.aspose.com/slides/net/aspose.slides/ishape/blackwhitemode/) مشخص می‌کند که یک شکل منفرد چگونه در حالت سیاه‑سفید رندر می‌شود هنگامی که یک ارائه در این حالت مشاهده یا پردازش می‌شود. این ویژگی به‌تنهایی نمایش سیاه‑سفید را فعال نمی‌کند و قالب‌بندی‌های پر کردن، خط یا دیگر ویژگی‌های شکل را در حالت رنگ عادی تغییر نمی‌دهد.

از یک مقدار از شمارش‌گر [BlackWhiteMode](https://reference.aspose.com/slides/net/aspose.slides/blackwhitemode/) برای انتخاب رفتار دلخواه استفاده کنید. به عنوان مثال، `Automatic` اجازه می‌دهد برنامهٔ رندرینگ تبدیل را انتخاب کند، `Gray` و `LightGray` از رنگ خاکستری استفاده می‌کنند، `BlackWhite` فقط سیاه و سفید را به‌کار می‌برد، `Black` و `White` یک رنگ ثابت را تحمیل می‌کنند، `Color` رنگ عادی را حفظ می‌کند و `Hidden` شکل را در حالت سیاه‑سفید حذف می‌کند. `NotDefined` به این معنی است که هیچ حالت سطح‑شکل اختصاص داده نشده است.

کد C# زیر یک شکل رنگی ایجاد می‌کند و آن را در حالت نمایش سیاه‑سفید به‌صورت خاکستری نشان می‌دهد:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.Orange;

// پر کردن نارنجی را در حالت رنگی نگه دارید، اما شکل را در حالت سیاه-سفید با رنگ خاکستری رندر کنید.
shape.BlackWhiteMode = BlackWhiteMode.Gray;

presentation.Save("shape_black_white_mode.pptx", SaveFormat.Pptx);
```

در حالت رنگ عادی، مستطیل پر شدن نارنجی خود را حفظ می‌کند. در یک گردش کاری نمایش سیاه‑سفید، به‌دلیل تنظیم حالت به `Gray` از رنگ خاکستری استفاده می‌کند. این امکان را به شما می‌دهد تا یک اسلاید رنگی کامل را حفظ کنید و در عین حال ظاهر متمایزی برای چاپ، پیش‌نمایش یا سایر گردش‌های کاری که تنظیمات نمایش سیاه‑سفید ارائه را رعایت می‌کنند، تعریف کنید.

## **بازنشانی قالب‌بندی**

کد C# زیر نشان می‌دهد چگونه قالب‌بندی یک اسلاید را بازنشانی کنید و موقعیت، اندازه و قالب‌بندی تمام اشکالی که مکان‌نگهدار در [LayoutSlide](https://reference.aspose.com/slides/net/aspose.slides/layoutslide/) دارند به تنظیمات پیش‌فرض برگردند:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    foreach (ISlide slide in presentation.Slides)
    {
        // بازنشانی هر شکلی که در اسلاید دارای یک نگهدارنده مکان در طرح‌بندی است.
        slide.Reset();
    }

    presentation.Save("reset_formatting.pptx", SaveFormat.Pptx);
}
```

## **سؤالات متداول**

**آیا قالب‌بندی شکل بر حجم نهایی فایل ارائه تأثیر می‌گذارد؟**

فقط به‌صورت جزئی. تصاویر و رسانه‌های جاسازی‌شده بیشترین فضای فایل را اشغال می‌کنند، در حالی که پارامترهای شکل مانند رنگ‌ها، اثرات و گرادیان‌ها به‌عنوان متادیتا ذخیره می‌شوند و به‌طور ملموسی حجم اضافه‌ای ندارند.

**چگونه می‌توانم شکل‌هایی را که در یک اسلاید قالب‌بندی یکسان دارند شناسایی کنم تا بتوانم آنها را گروه‌بندی کنم؟**

ویژگی‌های کلیدی قالب‌بندی هر شکل—پر کردن، خط و تنظیمات اثر—را مقایسه کنید. اگر تمام مقادیر متناظر برابر باشند، سبک‌های آنها را یکسان درنظر بگیرید و منطقی آن شکل‌ها را گروه‌بندی کنید؛ این کار مدیریت سبک‌ها را در مراحل بعدی ساده می‌کند.

**آیا می‌توانم مجموعه‌ای از سبک‌های سفارشی شکل را در فایلی جداگانه ذخیره کنم تا در ارائه‌های دیگر استفاده کنم؟**

بله. اشکال نمونه با سبک‌های دلخواه را در یک اسلاید قالب یا فایل قالب .POTX ذخیره کنید. هنگام ایجاد یک ارائهٔ جدید، قالب را باز کنید، اشکال سبک‌دار مورد نیاز را کلون کنید و قالب‌بندی آنها را در هر جایی که لازم است دوباره اعمال کنید.