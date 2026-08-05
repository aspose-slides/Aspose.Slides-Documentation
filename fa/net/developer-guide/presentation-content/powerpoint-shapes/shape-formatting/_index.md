---
title: قالب‌بندی اشکال PowerPoint در .NET
linktitle: قالب‌بندی شکل
type: docs
weight: 20
url: /fa/net/shape-formatting/
keywords:
- قالب‌بندی شکل
- قالب‌بندی خط
- افکت طرح‌دستی
- خط شکل طرح‌دستی
- قالب‌بندی سبک اتصال
- پر کردن گرادیانتی
- پر کردن الگوئی
- پر کردن تصویر
- پر کردن بافت
- پر کردن رنگ ثابت
- شفافیت شکل
- چرخاندن شکل
- افکت برجستگی 3 بعدی
- افکت چرخش 3 بعدی
- بازنشانی قالب‌بندی
- PowerPoint
- ارائه
- .NET
- C#
- Aspose.Slides
description: "یاد بگیرید چگونه اشکال PowerPoint را در C# با استفاده از Aspose.Slides—استایل‌های پر، خط و افکت را برای فایل‌های PPT و PPTX با دقت و کنترل کامل تنظیم کنید."
---
## **معرفی**

در PowerPoint می‌توانید شکل‌ها را به اسلایدها اضافه کنید. از آنجا که شکل‌ها از خطوط تشکیل شده‌اند، می‌توانید آنها را با تغییر یا اعمال افکت‌ها بر روی خطوط حاشیه‌ای‌شان قالب‌بندی کنید. علاوه بر این، می‌توانید شکل‌ها را با تعیین تنظیماتی که نحوه پر شدن داخلی آنها را کنترل می‌کند، قالب‌بندی کنید.

![قالب‌بندی-شکل-پاورپوینت](format-shape-powerpoint.png)

Aspose.Slides برای .NET رابط‌ها و خصوصیتی را فراهم می‌کند که به شما امکان می‌دهد شکل‌ها را با استفاده از همان گزینه‌های موجود در PowerPoint قالب‌بندی کنید.

## **قالب‌بندی خطوط**

با استفاده از Aspose.Slides می‌توانید یک سبک خط سفارشی برای یک شکل مشخص کنید. مراحل زیر روش انجام را شرح می‌دهند:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) ایجاد کنید.
1. یک مرجع به اسلاید را بر اساس اندیس آن دریافت کنید.
1. یک [IAutoShape](https://reference.aspose.com/slides/fa/net/aspose.slides/iautoshape/) به اسلاید اضافه کنید.
1. قالب [line style](https://reference.aspose.com/slides/fa/net/aspose.slides/linestyle/) شکل را تنظیم کنید.
1. ضخامت خط را تنظیم کنید.
1. قالب [dash style](https://reference.aspose.com/slides/fa/net/aspose.slides/linedashstyle/) خط را تنظیم کنید.
1. رنگ خط برای شکل را تنظیم کنید.
1. ارائهٔ اصلاح شده را به عنوان فایل PPTX ذخیره کنید.

```c#
// یک شی از کلاس Presentation که نمایانگر فایل ارائه است را ایجاد کنید.
using (Presentation presentation = new Presentation())
{
    // اسلاید اول را دریافت کنید.
    ISlide slide = presentation.Slides[0];

    // یک شکل خودکار از نوع Rectangle اضافه کنید.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // رنگ پر کردن برای شکل Rectangle را تنظیم کنید.
    shape.FillFormat.FillType = FillType.NoFill;

    // قالب‌بندی را بر خطوط Rectangle اعمال کنید.
    shape.LineFormat.Style = LineStyle.ThickThin;
    shape.LineFormat.Width = 7;
    shape.LineFormat.DashStyle = LineDashStyle.Dash;

    // رنگ خط Rectangle را تنظیم کنید.
    shape.LineFormat.FillFormat.FillType = FillType.Solid;
    shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;

    // فایل PPTX را روی دیسک ذخیره کنید.
    presentation.Save("formatted_lines.pptx", SaveFormat.Pptx);
}
```

نتیجه:

![خطوط قالب‌بندی‌شده در ارائه](formatted-lines.png)

## **اعمال افکت‌های اسکچ بر خطوط شکل**

یک افکت اسکچ باعث می‌شود خط یک شکل شبیه به دست‌نویس باشد. برای دسترسی به تنظیمات خط از [IShape.LineFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/ishape/lineformat/) استفاده کنید، برای دسترسی به تنظیمات اسکچ از [ILineFormat.SketchFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/ilineformat/sketchformat/) و برای انتخاب مقدار از شمارندهٔ [LineSketchType](https://reference.aspose.com/slides/fa/net/aspose.slides/linesketchtype/) از [ISketchFormat.SketchType](https://reference.aspose.com/slides/fa/net/aspose.slides/isketchformat/sketchtype/) استفاده کنید.

کد C# زیر نشان می‌دهد چگونه یک افکت [LineSketchType.Curved](https://reference.aspose.com/slides/fa/net/aspose.slides/linesketchtype/) اعمال شود، مقدار اختصاص داده‌شده به‌وضوح خوانده شود و افکت با [LineSketchType.None](https://reference.aspose.com/slides/fa/net/aspose.slides/linesketchtype/) حذف گردد:

```csharp
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

مقداری که `ISketchFormat.SketchType` برمی‌گرداند نشان‌دهنده تنظیمی است که مستقیماً به شکل اختصاص یافته است. اگر قالب‌بندی خط می‌تواند از یک تم، اسلاید اصلی یا اسلاید چیدمان به ارث برده شود، از [ILineFormat.GetEffective](https://reference.aspose.com/slides/fa/net/aspose.slides/ilineformat/geteffective/) استفاده کنید، به [ILineFormatEffectiveData.SketchFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/ilineformateffectivedata/sketchformat/) دسترسی پیدا کنید و [ISketchFormatEffectiveData.SketchType](https://reference.aspose.com/slides/fa/net/aspose.slides/isketchformateffectivedata/sketchtype/) را بخوانید. مقدار مؤثر، قالب‌بندی‌ای را نشان می‌دهد که پس از حل ارث‌بری واقعاً اعمال شده است:

```csharp
using var presentation = new Presentation("presentation.pptx");

var shape = presentation.Slides[0].Shapes[0];
var lineFormat = shape.LineFormat;

var explicitSketchType = lineFormat.SketchFormat.SketchType;
var effectiveLineFormat = lineFormat.GetEffective();
var effectiveSketchType = effectiveLineFormat.SketchFormat.SketchType;

Console.WriteLine($"Explicit sketch type: {explicitSketchType}");
Console.WriteLine($"Effective sketch type: {effectiveSketchType}");
```

## **قالب‌بندی نوع اتصال‌ها**

در اینجا سه گزینهٔ نوع اتصال موجود است:

* گرد
* میتر
* بویل

به‌طور پیش‌فرض، زمانی که PowerPoint دو خط را در یک زاویه (مانند گوشهٔ شکل) به هم می‌پیوندد، تنظیم **گرد** را استفاده می‌کند. اما اگر شکل با زوایای تیز رسم می‌کنید، ممکن است گزینه **میتر** را ترجیح دهید.

![نوع اتصال در ارائه](join-style-powerpoint.png)

```c#
// یک شی از کلاس Presentation که نمایانگر یک فایل ارائه است را ایجاد کنید.
using (Presentation presentation = new Presentation())
{
    // اسلاید اول را دریافت کنید.
    ISlide slide = presentation.Slides[0];

    // سه شکل خودکار از نوع Rectangle اضافه کنید.
    IAutoShape shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 75);
    IAutoShape shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 210, 20, 150, 75);
    IAutoShape shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 135, 150, 75);

    // رنگ پر کردن برای هر شکل Rectangle تنظیم شود.
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

    // رنگ خط هر Rectangle را تنظیم کنید.
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

    // متن را به هر Rectangle اضافه کنید.
    shape1.TextFrame.Text = "Miter Join Style";
    shape2.TextFrame.Text = "Bevel Join Style";
    shape3.TextFrame.Text = "Round Join Style";

    // فایل PPTX را روی دیسک ذخیره کنید.
    presentation.Save("join_styles.pptx", SaveFormat.Pptx);
}
```

## **پر کردن گرادیانتی**

در PowerPoint، پر کردن گرادیانتی گزینه‌ای قالب‌بندی است که به شما امکان می‌دهد ترکیبی متصل از رنگ‌ها را به یک شکل اعمال کنید. به‌عنوان مثال می‌توانید دو یا چند رنگ را به‌گونه‌ای به‌کار ببرید که یکی به‌تدریج به دیگری ختم شود.

در اینجا نحوهٔ اعمال پر کردن گرادیانتی به یک شکل با استفاده از Aspose.Slides آمده است:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) ایجاد کنید.
1. یک مرجع به اسلاید را بر اساس اندیس آن دریافت کنید.
1. یک [IAutoShape](https://reference.aspose.com/slides/fa/net/aspose.slides/iautoshape/) به اسلاید اضافه کنید.
1. [FillType](https://reference.aspose.com/slides/fa/net/aspose.slides/filltype/) شکل را به `Gradient` تنظیم کنید.
1. دو رنگ مورد علاقهٔ خود را با موقعیت‌های تعریف‌شده با استفاده از متدهای `Add` مجموعهٔ توقف گرادیان که توسط رابط [IGradientFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/igradientformat/) در دسترس است، اضافه کنید.
1. ارائهٔ اصلاح‌شده را به عنوان فایل PPTX ذخیره کنید.

```c#
// یک شی از کلاس Presentation که نمایانگر یک فایل ارائه است را ایجاد کنید.
using (Presentation presentation = new Presentation())
{
    // اسلاید اول را دریافت کنید.
    ISlide slide = presentation.Slides[0];

    // یک شکل خودکار از نوع Ellipse اضافه کنید.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // قالب‌بندی گرادیانتی را به بیضی اعمال کنید.
    shape.FillFormat.FillType = FillType.Gradient;
    shape.FillFormat.GradientFormat.GradientShape = GradientShape.Linear;

    // جهت گرادیان را تنظیم کنید.
    shape.FillFormat.GradientFormat.GradientDirection = GradientDirection.FromCorner2;

    // دو توقف گرادیان اضافه کنید.
    shape.FillFormat.GradientFormat.GradientStops.Add(1.0f, PresetColor.Purple);
    shape.FillFormat.GradientFormat.GradientStops.Add(0.0f, PresetColor.Red);

    // فایل PPTX را روی دیسک ذخیره کنید.
    presentation.Save("gradient_fill.pptx", SaveFormat.Pptx);
}
```

نتیجه:

![بیضی با پر کردن گرادیانتی](gradient-fill.png)

## **پر کردن الگوئی**

در PowerPoint، پر کردن الگوئی گزینه‌ای قالب‌بندی است که به شما امکان می‌دهد یک طرح دو‌رنگ—مانند نقاط، نوارها، خطوط متقاطع یا شطرنجی—را به یک شکل اعمال کنید. می‌توانید رنگ‌های سفارشی برای پیش‌زمینه و پس‌زمینهٔ الگو انتخاب کنید.

Aspose.Slides بیش از ۴۵ سبک الگوی پیش‌تعریف‌شده ارائه می‌دهد که می‌توانید به شکل‌ها اعمال کنید تا جذابیت بصری ارائه‌های خود را افزایش دهید. حتی پس از انتخاب یک الگوی پیش‌تعریف‌شده، می‌توانید رنگ‌های دقیق مورد استفاده را مشخص کنید.

در اینجا نحوهٔ اعمال پر کردن الگوئی به یک شکل با استفاده از Aspose.Slides آمده است:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) ایجاد کنید.
1. یک مرجع به اسلاید را بر اساس اندیس آن دریافت کنید.
1. یک [IAutoShape](https://reference.aspose.com/slides/fa/net/aspose.slides/iautoshape/) به اسلاید اضافه کنید.
1. [FillType](https://reference.aspose.com/slides/fa/net/aspose.slides/filltype/) شکل را به `Pattern` تنظیم کنید.
1. یک سبک الگو را از گزینه‌های پیش‌تعریف‌شده انتخاب کنید.
1. [Background Color](https://reference.aspose.com/slides/fa/net/aspose.slides/ipatternformat/backcolor/) الگو را تنظیم کنید.
1. [Foreground Color](https://reference.aspose.com/slides/fa/net/aspose.slides/ipatternformat/forecolor/) الگو را تنظیم کنید.
1. ارائهٔ اصلاح‌شده را به عنوان فایل PPTX ذخیره کنید.

```c#
// یک شی از کلاس Presentation که نمایانگر یک فایل ارائه است را ایجاد کنید.
using (Presentation presentation = new Presentation())
{
    // اسلاید اول را دریافت کنید.
    ISlide slide = presentation.Slides[0];

    // یک شکل خودکار از نوع Rectangle اضافه کنید.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // نوع پر کردن را به Pattern تنظیم کنید.
    shape.FillFormat.FillType = FillType.Pattern;

    // سبک الگو را تنظیم کنید.
    shape.FillFormat.PatternFormat.PatternStyle = PatternStyle.Trellis;

    // رنگ پس‌زمینه و پیش‌زمینهٔ الگو را تنظیم کنید.
    shape.FillFormat.PatternFormat.BackColor.Color = Color.LightGray;
    shape.FillFormat.PatternFormat.ForeColor.Color = Color.Yellow;

    // فایل PPTX را روی دیسک ذخیره کنید.
    presentation.Save("pattern_fill.pptx", SaveFormat.Pptx);
}
```

نتیجه:

![مستطیل با پر کردن الگوئی](pattern-fill.png)

## **پر کردن تصویر**

در PowerPoint، پر کردن تصویر گزینه‌ای قالب‌بندی است که به شما امکان می‌دهد یک تصویر را داخل یک شکل قرار دهید—به‌صورت مؤثری تصویر را به‌عنوان پس‌زمینهٔ شکل استفاده می‌کند.

در اینجا نحوهٔ استفاده از Aspose.Slides برای اعمال پر کردن تصویر به یک شکل آمده است:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) ایجاد کنید.
1. یک مرجع به اسلاید را بر اساس اندیس آن دریافت کنید.
1. یک [IAutoShape](https://reference.aspose.com/slides/fa/net/aspose.slides/iautoshape/) به اسلاید اضافه کنید.
1. [FillType](https://reference.aspose.com/slides/fa/net/aspose.slides/filltype/) شکل را به `Picture` تنظیم کنید.
1. حالت پر کردن تصویر را به `Tile` (یا حالت دلخواه دیگر) تنظیم کنید.
1. یک شیء [IPPImage](https://reference.aspose.com/slides/fa/net/aspose.slides/ippimage/) از تصویری که می‌خواهید استفاده کنید، ایجاد کنید.
1. این تصویر را به ویژگی `Picture.Image` از `PictureFillFormat` شکل اختصاص دهید.
1. ارائهٔ اصلاح‌شده را به عنوان فایل PPTX ذخیره کنید.

![تصویر نبات‌قهره](lotus.png)

```c#
// یک شی از کلاس Presentation که نمایانگر یک فایل ارائه است را ایجاد کنید.
using (Presentation presentation = new Presentation())
{
    // اسلاید اول را دریافت کنید.
    ISlide slide = presentation.Slides[0];

    // یک شکل خودکار از نوع Rectangle اضافه کنید.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);

    // نوع پر کردن را به Picture تنظیم کنید.
    shape.FillFormat.FillType = FillType.Picture;

    // حالت پر کردن تصویر را تنظیم کنید.
    shape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Tile;

    // یک تصویر بارگذاری کنید و به منابع ارائه اضافه کنید.
    IImage image = Images.FromFile("lotus.png");
    IPPImage presentationImage = presentation.Images.AddImage(image);
    image.Dispose();

    // تصویر را تنظیم کنید.
    shape.FillFormat.PictureFillFormat.Picture.Image = presentationImage;

    // فایل PPTX را روی دیسک ذخیره کنید.
    presentation.Save("picture_fill.pptx", SaveFormat.Pptx);
}
```

نتیجه:

![شکل با پر کردن تصویر](picture-fill.png)

### **کاشی تصویر به عنوان بافت**

اگر می‌خواهید یک تصویر کاشی‌شده را به‌عنوان بافت تنظیم کنید و رفتار کاشی‌بندی را سفارشی کنید، می‌توانید از خصوصیات زیر رابط [IPictureFillFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/ipicturefillformat/) و کلاس [PictureFillFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/picturefillformat/) استفاده کنید:

- [PictureFillMode](https://reference.aspose.com/slides/fa/net/aspose.slides/ipicturefillformat/picturefillmode/): حالت پر کردن تصویر را تنظیم می‌کند—یا `Tile` یا `Stretch`.
- [TileAlignment](https://reference.aspose.com/slides/fa/net/aspose.slides/ipicturefillformat/tilealignment/): ترازبندی کاشی‌ها داخل شکل را مشخص می‌کند.
- [TileFlip](https://reference.aspose.com/slides/fa/net/aspose.slides/ipicturefillformat/tileflip/): کنترل می‌کند که کاشی به‌صورت افقی، عمودی یا هر دو معکوس شود.
- [TileOffsetX](https://reference.aspose.com/slides/fa/net/aspose.slides/ipicturefillformat/tileoffsetx/): افست افقی کاشی (به‌پیکسل) را از مبدأ شکل تنظیم می‌کند.
- [TileOffsetY](https://reference.aspose.com/slides/fa/net/aspose.slides/ipicturefillformat/tileoffsety/): افست عمودی کاشی (به‌پیکسل) را از مبدأ شکل تنظیم می‌کند.
- [TileScaleX](https://reference.aspose.com/slides/fa/net/aspose.slides/ipicturefillformat/tilescalex/): مقیاس افقی کاشی را به‌صورت درصد تعریف می‌کند.
- [TileScaleY](https://reference.aspose.com/slides/fa/net/aspose.slides/ipicturefillformat/tilescaley/): مقیاس عمودی کاشی را به‌صورت درصد تعریف می‌کند.

```c#
// یک شی از کلاس Presentation که نمایانگر یک فایل ارائه است را ایجاد کنید.
using (Presentation presentation = new Presentation())
{
    // اسلاید اول را دریافت کنید.
    ISlide firstSlide = presentation.Slides[0];

    // یک شکل خودکار مستطیل اضافه کنید.
    IAutoShape shape = firstSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

    // نوع پر کردن شکل را به Picture تنظیم کنید.
    shape.FillFormat.FillType = FillType.Picture;

    // تصویر را بارگیری کنید و به منابع ارائه اضافه کنید.
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

    // فایل PPTX را روی دیسک ذخیره کنید.
    presentation.Save("tile.pptx", SaveFormat.Pptx);
}
```

نتیجه:

![گزینه‌های کاشی](tile-options.png)

## **پر کردن با رنگ ثابت**

در PowerPoint، پر کردن با رنگ ثابت گزینه‌ای قالب‌بندی است که شکل را با یک رنگ یکنواخت پر می‌کند. این پس‌زمینهٔ ساده بدون هیچ‌گونه گرادیان، بافت یا الگو اعمال می‌شود.

برای اعمال پر کردن با رنگ ثابت به یک شکل با استفاده از Aspose.Slides، مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) ایجاد کنید.
1. یک مرجع به اسلاید را بر اساس اندیس آن دریافت کنید.
1. یک [IAutoShape](https://reference.aspose.com/slides/fa/net/aspose.slides/iautoshape/) به اسلاید اضافه کنید.
1. [FillType](https://reference.aspose.com/slides/fa/net/aspose.slides/filltype/) شکل را به `Solid` تنظیم کنید.
1. رنگ پر کردن مورد نظر خود را به شکل اختصاص دهید.
1. ارائهٔ اصلاح‌شده را به عنوان فایل PPTX ذخیره کنید.

```c#
// یک شی از کلاس Presentation که نمایانگر یک فایل ارائه است را ایجاد کنید.
using (Presentation presentation = new Presentation())
{
    // اسلاید اول را دریافت کنید.
    ISlide slide = presentation.Slides[0];

    // یک شکل خودکار از نوع Rectangle اضافه کنید.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // نوع پر کردن را به Solid تنظیم کنید.
    shape.FillFormat.FillType = FillType.Solid;

    // رنگ پر کردن را تنظیم کنید.
    shape.FillFormat.SolidFillColor.Color = Color.Yellow;

    // فایل PPTX را روی دیسک ذخیره کنید.
    presentation.Save("solid_color_fill.pptx", SaveFormat.Pptx);
}
```

نتیجه:

![شکل با پر کردن رنگ ثابت](solid-color-fill.png)

## **تنظیم شفافیت**

در PowerPoint، زمانی که پر کردن رنگ ثابت، گرادیان، تصویر یا بافت را به شکل‌ها اعمال می‌کنید، می‌توانید همچنین سطح شفافیتی را تنظیم کنید تا میزان شفافیت پر کردن را کنترل کنید. مقدار شفافیت بالاتر باعث می‌شود شکل بیشتر قابل‌مشاهده باشد و پس‌زمینه یا اشیای زیرین به‌صورت جزئی دیده شوند.

Aspose.Slides به شما اجازه می‌دهد سطح شفافیت را با تنظیم مقدار آلفا در رنگ مورد استفاده برای پر کردن تنظیم کنید. در اینجا نحوهٔ انجام آن آورده شده است:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) ایجاد کنید.
1. یک مرجع به اسلاید را بر اساس اندیس آن دریافت کنید.
1. یک [IAutoShape](https://reference.aspose.com/slides/fa/net/aspose.slides/iautoshape/) به اسلاید اضافه کنید.
1. [FillType](https://reference.aspose.com/slides/fa/net/aspose.slides/filltype/) را به `Solid` تنظیم کنید.
1. از `Color.FromArgb(alpha, baseColor)` برای تعریف رنگی با شفافیت استفاده کنید (کامپوننت `alpha` شفافیت را کنترل می‌کند).
1. ارائه را ذخیره کنید.

```c#
const int alpha = 128;

// یک شی از کلاس Presentation که نمایانگر یک فایل ارائه است را ایجاد کنید.
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

    // فایل PPTX را روی دیسک ذخیره کنید.
    presentation.Save("shape_transparency.pptx", SaveFormat.Pptx);
}
```

نتیجه:

![شکل شفاف](shape-transparency.png)

## **چرخاندن شکل‌ها**

Aspose.Slides به شما امکان می‌دهد شکل‌ها را در ارائه‌های PowerPoint بچرخانید. این می‌تواند هنگام قرار دادن عناصر بصری با نیازهای خاص تراز یا طراحی مفید باشد.

برای چرخاندن یک شکل در اسلاید، مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) ایجاد کنید.
1. یک مرجع به اسلاید را بر اساس اندیس آن دریافت کنید.
1. یک [IAutoShape](https://reference.aspose.com/slides/fa/net/aspose.slides/iautoshape/) به اسلاید اضافه کنید.
1. ویژگی `Rotation` شکل را به زاویهٔ مورد نظر تنظیم کنید.
1. ارائه را ذخیره کنید.

```c#
// یک شی از کلاس Presentation که نمایانگر یک فایل ارائه است را ایجاد کنید.
using (Presentation presentation = new Presentation())
{
    // اسلاید اول را دریافت کنید.
    ISlide slide = presentation.Slides[0];

    // یک شکل خودکار از نوع Rectangle اضافه کنید.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // شکل را به‌صورت 5 درجه بچرخانید.
    shape.Rotation = 5;

    // فایل PPTX را روی دیسک ذخیره کنید.
    presentation.Save("shape_rotation.pptx", SaveFormat.Pptx);
}
```

نتیجه:

![چرخش شکل](shape-rotation.png)

## **افکت‌های برجستگی 3 بعدی را اضافه کنید**

Aspose.Slides به شما اجازه می‌دهد افکت‌های برجستگی 3 بعدی را به شکل‌ها با پیکربندی خصوصیات [ThreeDFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/threedformat/) اعمال کنید.

برای افزودن افکت‌های برجستگی 3 بعدی به یک شکل، مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) ایجاد کنید.
1. یک مرجع به اسلاید را بر اساس اندیس آن دریافت کنید.
1. یک [IAutoShape](https://reference.aspose.com/slides/fa/net/aspose.slides/iautoshape/) به اسلاید اضافه کنید.
1. [ThreeDFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/threedformat/) شکل را برای تعریف تنظیمات برجستگی پیکربندی کنید.
1. ارائه را ذخیره کنید.

```c#
// یک شی از کلاس Presentation ایجاد کنید.
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

    // ارائه را به‌صورت فایل PPTX ذخیره کنید.
    presentation.Save("3D_bevel_effect.pptx", SaveFormat.Pptx);
}
```

نتیجه:

![افکت برجستگی 3 بعدی](3D-bevel-effect.png)

## **افکت‌های چرخش 3 بعدی را اضافه کنید**

Aspose.Slides به شما امکان می‌دهد افکت‌های چرخش 3 بعدی را به شکل‌ها با پیکربندی خصوصیات [ThreeDFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/threedformat/) اعمال کنید.

برای اعمال چرخش 3 بعدی به یک شکل:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) ایجاد کنید.
1. یک مرجع به اسلاید را بر اساس اندیس آن دریافت کنید.
1. یک [IAutoShape](https://reference.aspose.com/slides/fa/net/aspose.slides/iautoshape/) به اسلاید اضافه کنید.
1. [CameraType](https://reference.aspose.com/slides/fa/net/aspose.slides/icamera/cameratype/) و [LightType](https://reference.aspose.com/slides/fa/net/aspose.slides/ilightrig/lighttype/) شکل را تنظیم کنید تا چرخش 3 بعدی تعریف شود.
1. ارائه را ذخیره کنید.

```c#
// یک شی از کلاس Presentation ایجاد کنید.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    autoShape.TextFrame.Text = "Hello, Aspose!";

    autoShape.ThreeDFormat.Depth = 6;
    autoShape.ThreeDFormat.Camera.SetRotation(40, 35, 20);
    autoShape.ThreeDFormat.Camera.CameraType = CameraPresetType.IsometricLeftUp;
    autoShape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;

    // ارائه را به عنوان فایل PPTX ذخیره کنید.
    presentation.Save("3D_rotation_effect.pptx", SaveFormat.Pptx);
}
```

نتیجه:

![افکت چرخش 3 بعدی](3D-rotation-effect.png)

## **بازنشانی قالب‌بندی**

کد C# زیر نشان می‌دهد چگونه قالب‌بندی یک اسلاید و موقعیت، اندازه و قالب‌بندی تمام اشکال با نگهدارنده‌ها در [LayoutSlide](https://reference.aspose.com/slides/fa/net/aspose.slides/layoutslide/) را به تنظیمات پیش‌فرض بازگردانید:

```c#
using (Presentation presentation = new Presentation("sample.pptx"))
{
    foreach (ISlide slide in presentation.Slides)
    {
        // بازنشانی هر شکلی در اسلاید که دارای یک placeholder در لایهٔ چیدمان است.
        slide.Reset();
    }

    presentation.Save("reset_formatting.pptx", SaveFormat.Pptx);
}
```

## **سوالات متداول**

**آیا قالب‌بندی شکل بر اندازهٔ نهایی فایل ارائه تأثیر می‌گذارد؟**

به‌صرفه‌ترین تأثیر. تصاویر و رسانه‌های تعبیه‌شده بیشتر فضای فایل را اشغال می‌کنند، در حالی که پارامترهای شکل مانند رنگ‌ها، افکت‌ها و گرادیان‌ها به‌عنوان فراداده ذخیره می‌شوند و تقریباً هیچ حجم اضافی ایجاد نمی‌کنند.

**چگونه می‌توانم شکل‌هایی در یک اسلاید که قالب‌بندی یکسان دارند را شناسایی کنم تا بتوانم آنها را گروه‌بندی کنم؟**

ویژگی‌های کلیدی قالب‌بندی هر شکل—تنظیمات پر، خط و اثر—را مقایسه کنید. اگر تمام مقادیر متناظر مطابقت داشته باشند، سبک‌های آنها را یکسان در نظر بگیرید و منطقی آن اشکال را گروه‌بندی کنید؛ این کار مدیریت سبک‌ها را در ادامه ساده می‌کند.

**آیا می‌توانم مجموعه‌ای از سبک‌های سفارشی شکل را در فایلی جداگانه ذخیره کنم تا در ارائه‌های دیگر دوباره استفاده کنم؟**

بله. اشکال نمونه با سبک‌های مورد نظر را در یک اسلاید الگو یا فایل قالب .POTX ذخیره کنید. هنگام ایجاد یک ارائهٔ جدید، قالب را باز کنید، اشکال سبک‌دار مورد نیاز را کلون کنید و قالب‌بندی آنها را هرجا که لازم باشد اعمال کنید.