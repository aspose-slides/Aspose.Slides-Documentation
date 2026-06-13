---
title: قالب‌بندی اشکال پاورپوینت در .NET
linktitle: قالب‌بندی شکل
type: docs
weight: 20
url: /fa/net/shape-formatting/
keywords:
- قالب‌بندی شکل
- قالب‌بندی خط
- قالب‌بندی سبک اتصال
- پر کردن گرادیان
- پر کردن الگو
- پر کردن تصویر
- پر کردن بافت
- پر کردن رنگ ثابت
- شفافیت شکل
- چرخاندن شکل
- اثر برجسته‌سازی 3D
- اثر چرخش 3D
- بازنشانی قالب‌بندی
- PowerPoint
- ارائه
- .NET
- C#
- Aspose.Slides
description: "یاد بگیرید چگونه اشکال پاورپوینت را در C# با استفاده از Aspose.Slides قالب‌بندی کنید—پر کردن، خط و سبک‌های افکت را برای فایل‌های PPT و PPTX با دقت و کنترل کامل تنظیم کنید."
---
## **مقدمه**

در پاورپوینت می‌توانید اشکال را به اسلایدها اضافه کنید. از آنجا که اشکال از خطوط تشکیل شده‌اند، می‌توانید با تغییر یا اعمال افکت‌ها بر حاشیه‌های آن‌ها، آن‌ها را قالب‌بندی کنید. علاوه بر این، می‌توانید با تعیین تنظیماتی که نحوه پر شدن داخلی آن‌ها را کنترل می‌کند، اشکال را قالب‌بندی کنید.

![قالب‌بندی اشکال در پاورپوینت](format-shape-powerpoint.png)

آسپوز.Slides برای .NET رابط‌ها و خصوصیتی را فراهم می‌کند که به شما امکان می‌دهد اشکال را با استفاده از همان گزینه‌های موجود در پاورپوینت قالب‌بندی کنید.

## **قالب‌بندی خطوط**

با استفاده از Aspose.Slides می‌توانید سبک خط سفارشی برای یک شکل تعیین کنید. مراحل زیر روند را توضیح می‌دهند:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) ایجاد کنید.
1. با استفاده از شاخص، مرجع یک اسلاید را دریافت کنید.
1. یک [IAutoShape](https://reference.aspose.com/slides/fa/net/aspose.slides/iautoshape/) به اسلاید اضافه کنید.
1. قالب [line style](https://reference.aspose.com/slides/fa/net/aspose.slides/linestyle/) شکل را تنظیم کنید.
1. عرض خط را تنظیم کنید.
1. قالب [dash style](https://reference.aspose.com/slides/fa/net/aspose.slides/linedashstyle/) خط را تنظیم کنید.
1. رنگ خط شکل را تنظیم کنید.
1. ارائهٔ تغییر یافته را به صورت فایل PPTX ذخیره کنید.

کد C# زیر نحوه قالب‌بندی یک `AutoShape` مستطیلی را نشان می‌دهد:
```c#
// یک نمونه از کلاس Presentation که یک فایل ارائه را نشان می‌دهد، ایجاد کنید.
using (Presentation presentation = new Presentation())
{
    // اسلاید اول را دریافت کنید.
    ISlide slide = presentation.Slides[0];

    // یک شکل خودکار از نوع Rectangle اضافه کنید.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // رنگ پر را برای شکل مستطیلی تنظیم کنید.
    shape.FillFormat.FillType = FillType.NoFill;

    // قالب‌بندی را برای خطوط مستطیل اعمال کنید.
    shape.LineFormat.Style = LineStyle.ThickThin;
    shape.LineFormat.Width = 7;
    shape.LineFormat.DashStyle = LineDashStyle.Dash;

    // رنگ خط مستطیل را تنظیم کنید.
    shape.LineFormat.FillFormat.FillType = FillType.Solid;
    shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;

    // فایل PPTX را روی دیسک ذخیره کنید.
    presentation.Save("formatted_lines.pptx", SaveFormat.Pptx);
}
```

نتیجه:
![خطوط قالب‌بندی شده در ارائه](formatted-lines.png)

## **قالب‌بندی سبک‌های اتصال**

در اینجا سه گزینهٔ نوع اتصال وجود دارد:

* گرد
* میتر
* شیاردار

به‌صورت پیش‌فرض، وقتی پاورپوینت دو خط را در یک زاویه (مانند گوشهٔ یک شکل) به‌هم می‌پیوندد، تنظیم **گرد** را استفاده می‌کند. اما اگر شکل با زوایای تند ترسیم می‌کنید، ممکن است گزینهٔ **میتر** را ترجیح دهید.

![سبک اتصال در ارائه](join-style-powerpoint.png)

کد C# زیر نشان می‌دهد چگونه سه مستطیل (همان‌طور که در تصویر بالا دیده می‌شود) با استفاده از تنظیمات نوع اتصال میتر، شیاردار و گرد ایجاد شدند:
```c#
// یک نمونه از کلاس Presentation که یک فایل ارائه را نشان می‌دهد، ایجاد کنید.
using (Presentation presentation = new Presentation())
{
    // اسلاید اول را دریافت کنید.
    ISlide slide = presentation.Slides[0];

    // سه شکل خودکار از نوع Rectangle اضافه کنید.
    IAutoShape shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 75);
    IAutoShape shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 210, 20, 150, 75);
    IAutoShape shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 135, 150, 75);

    // رنگ پر را برای هر شکل مستطیلی تنظیم کنید.
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

    // رنگ خط هر مستطیل را تنظیم کنید.
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

    // فایل PPTX را روی دیسک ذخیره کنید.
    presentation.Save("join_styles.pptx", SaveFormat.Pptx);
}
```

## **پر شدن گرادیان**

در پاورپوینت، پر شدن گرادیان یک گزینهٔ قالب‌بندی است که به شما امکان می‌دهد ترکیبی پیوسته از رنگ‌ها را بر روی یک شکل اعمال کنید. برای مثال، می‌توانید دو یا چند رنگ را به‌طوری که یکی به تدریج به دیگری محو شود، اعمال کنید.

در اینجا نحوهٔ اعمال پر شدن گرادیان به یک شکل با استفاده از Aspose.Slides آورده شده است:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) ایجاد کنید.
1. با استفاده از شاخص، مرجع یک اسلاید را دریافت کنید.
1. یک [IAutoShape](https://reference.aspose.com/slides/fa/net/aspose.slides/iautoshape/) به اسلاید اضافه کنید.
1. قالب [FillType](https://reference.aspose.com/slides/fa/net/aspose.slides/filltype/) شکل را به `Gradient` تنظیم کنید.
1. دو رنگ مورد نظر خود را با موقعیت‌های تعریف‌شده با استفاده از متدهای `Add` مجموعهٔ نقاط توقف گرادیان که توسط رابط [IGradientFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/igradientformat/) در اختیار است، اضافه کنید.
1. ارائهٔ تغییر یافته را به صورت فایل PPTX ذخیره کنید.

کد C# زیر نشان می‌دهد چگونه یک اثر پر شدن گرادیان به یک بیضی اعمال شود:
```c#
// یک نمونه از کلاس Presentation که یک فایل ارائه را نشان می‌دهد، ایجاد کنید.
using (Presentation presentation = new Presentation())
{
    // اسلاید اول را دریافت کنید.
    ISlide slide = presentation.Slides[0];

    // یک شکل خودکار از نوع Ellipse اضافه کنید.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // قالب‌بندی گرادیان را بر روی بیضی اعمال کنید.
    shape.FillFormat.FillType = FillType.Gradient;
    shape.FillFormat.GradientFormat.GradientShape = GradientShape.Linear;

    // جهت گرادیان را تنظیم کنید.
    shape.FillFormat.GradientFormat.GradientDirection = GradientDirection.FromCorner2;

    // دو نقطه توقف گرادیان اضافه کنید.
    shape.FillFormat.GradientFormat.GradientStops.Add(1.0f, PresetColor.Purple);
    shape.FillFormat.GradientFormat.GradientStops.Add(0.0f, PresetColor.Red);

    // فایل PPTX را روی دیسک ذخیره کنید.
    presentation.Save("gradient_fill.pptx", SaveFormat.Pptx);
}
```

نتیجه:
![بیضی با پر شدن گرادیان](gradient-fill.png)

## **پر شدن الگو**

در پاورپوینت، پر شدن الگو یک گزینهٔ قالب‌بندی است که به شما امکان می‌دهد یک طرح دو رنگی—مانند نقطه‌ها، خط‌کش‌ها، خط‌متقاطع یا شطرنجی—را بر روی یک شکل اعمال کنید. می‌توانید رنگ‌های سفارشی برای پیش‌زمینه و پس‌زمینهٔ الگو انتخاب کنید.

Aspose.Slides بیش از ۴۵ سبک الگوی پیش‌تعریف‌شده را ارائه می‌دهد که می‌توانید بر روی اشکال اعمال کنید تا جذابیت بصری ارائه‌هایتان افزایاش یابد. حتی پس از انتخاب یک الگوی پیش‌تعریف‌شده، می‌توانید رنگ‌های دقیق مورد استفاده آن را مشخص کنید.

در اینجا نحوهٔ اعمال پر شدن الگو به یک شکل با استفاده از Aspose.Slides آورده شده است:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) ایجاد کنید.
1. با استفاده از شاخص، مرجع یک اسلاید را دریافت کنید.
1. یک [IAutoShape](https://reference.aspose.com/slides/fa/net/aspose.slides/iautoshape/) به اسلاید اضافه کنید.
1. قالب [FillType](https://reference.aspose.com/slides/fa/net/aspose.slides/filltype/) شکل را به `Pattern` تنظیم کنید.
1. یک سبک الگو از گزینه‌های پیش‌تعریف‌شده انتخاب کنید.
1. [Background Color](https://reference.aspose.com/slides/fa/net/aspose.slides/ipatternformat/backcolor/) الگو را تنظیم کنید.
1. [Foreground Color](https://reference.aspose.com/slides/fa/net/aspose.slides/ipatternformat/forecolor/) الگو را تنظیم کنید.
1. ارائهٔ تغییر یافته را به صورت فایل PPTX ذخیره کنید.

```c#
// یک نمونه از کلاس Presentation که یک فایل ارائه را نشان می‌دهد، ایجاد کنید.
using (Presentation presentation = new Presentation())
{
    // اسلاید اول را دریافت کنید.
    ISlide slide = presentation.Slides[0];

    // یک شکل خودکار از نوع Rectangle اضافه کنید.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // نوع پر را به Pattern تنظیم کنید.
    shape.FillFormat.FillType = FillType.Pattern;

    // سبک الگو را تنظیم کنید.
    shape.FillFormat.PatternFormat.PatternStyle = PatternStyle.Trellis;

    // رنگ پس‌زمینه و پیش‌زمینه الگو را تنظیم کنید.
    shape.FillFormat.PatternFormat.BackColor.Color = Color.LightGray;
    shape.FillFormat.PatternFormat.ForeColor.Color = Color.Yellow;

    // فایل PPTX را روی دیسک ذخیره کنید.
    presentation.Save("pattern_fill.pptx", SaveFormat.Pptx);
}
```

نتیجه:
![مستطیل با پر شدن الگو](pattern-fill.png)

## **پر شدن تصویر**

در پاورپوینت، پر شدن تصویر یک گزینهٔ قالب‌بندی است که به شما امکان می‌دهد تصویر را داخل یک شکل قرار دهید—به‌طوری که تصویر به‌عنوان پس‌زمینهٔ شکل عمل کند.

در اینجا نحوهٔ استفاده از Aspose.Slides برای اعمال پر شدن تصویر به یک شکل آورده شده است:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) ایجاد کنید.
1. با استفاده از شاخص، مرجع یک اسلاید را دریافت کنید.
1. یک [IAutoShape](https://reference.aspose.com/slides/fa/net/aspose.slides/iautoshape/) به اسلاید اضافه کنید.
1. قالب [FillType](https://reference.aspose.com/slides/fa/net/aspose.slides/filltype/) شکل را به `Picture` تنظیم کنید.
1. حالت پر شدن تصویر را به `Tile` (یا حالت دیگری که ترجیح می‌دهید) تنظیم کنید.
1. یک شیء [IPPImage](https://reference.aspose.com/slides/fa/net/aspose.slides/ippimage/) از تصویری که می‌خواهید استفاده کنید، ایجاد کنید.
1. این تصویر را به ویژگی `Picture.Image` از `PictureFillFormat` شکل اختصاص دهید.
1. ارائهٔ تغییر یافته را به صورت فایل PPTX ذخیره کنید.

فرض کنید فایلی به نام «lotus.png» با تصویر زیر داریم:
![عکس لوتوس](lotus.png)

کد C# زیر نشان می‌دهد چگونه یک شکل را با تصویر پر کنید:
```c#
// یک نمونه از کلاس Presentation که یک فایل ارائه را نشان می‌دهد، ایجاد کنید.
using (Presentation presentation = new Presentation())
{
    // اسلاید اول را دریافت کنید.
    ISlide slide = presentation.Slides[0];

    // یک شکل خودکار از نوع Rectangle اضافه کنید.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);

    // نوع پر را به Picture تنظیم کنید.
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
![شکل با پر شدن تصویر](picture-fill.png)

### **کاشی تصویر به‌عنوان بافت**

اگر می‌خواهید یک تصویر کاشی‌شده را به‌عنوان بافت تنظیم کنید و رفتار کاشی‌گذاری را سفارشی کنید، می‌توانید از ویژگی‌های زیر رابط [IPictureFillFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/ipicturefillformat/) و کلاس [PictureFillFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/picturefillformat/) استفاده کنید:

- [PictureFillMode](https://reference.aspose.com/slides/fa/net/aspose.slides/ipicturefillformat/picturefillmode/): حالت پر شدن تصویر را تنظیم می‌کند — یا `Tile` یا `Stretch`.
- [TileAlignment](https://reference.aspose.com/slides/fa/net/aspose.slides/ipicturefillformat/tilealignment/): ترازبندی کاشی‌ها داخل شکل را مشخص می‌کند.
- [TileFlip](https://reference.aspose.com/slides/fa/net/aspose.slides/ipicturefillformat/tileflip/): کنترل می‌کند آیا کاشی به‌صورت افقی، عمودی یا هر دو برگردانده شود.
- [TileOffsetX](https://reference.aspose.com/slides/fa/net/aspose.slides/ipicturefillformat/tileoffsetx/): افست افقی کاشی (به نقطه) را از مبدأ شکل تنظیم می‌کند.
- [TileOffsetY](https://reference.aspose.com/slides/fa/net/aspose.slides/ipicturefillformat/tileoffsety/): افست عمودی کاشی (به نقطه) را از مبدأ شکل تنظیم می‌کند.
- [TileScaleX](https://reference.aspose.com/slides/fa/net/aspose.slides/ipicturefillformat/tilescalex/): مقیاس افقی کاشی را به‌صورت درصد تعریف می‌کند.
- [TileScaleY](https://reference.aspose.com/slides/fa/net/aspose.slides/ipicturefillformat/tilescaley/): مقیاس عمودی کاشی را به‌صورت درصد تعریف می‌کند.

کد نمونه زیر نشان می‌دهد چگونه یک شکل مستطیلی با پر شدن تصویر کاشی‌شده اضافه کنید و گزینه‌های کاشی را پیکربندی کنید:
```c#
// یک نمونه از کلاس Presentation که یک فایل ارائه را نشان می‌دهد، ایجاد کنید.
using (Presentation presentation = new Presentation())
{
    // اسلاید اول را دریافت کنید.
    ISlide firstSlide = presentation.Slides[0];

    // یک شکل خودکار مستطیلی اضافه کنید.
    IAutoShape shape = firstSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

    // نوع پر کردن شکل را به Picture تنظیم کنید.
    shape.FillFormat.FillType = FillType.Picture;

    // تصویر را بارگذاری کنید و به منابع ارائه اضافه کنید.
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

## **پر شدن رنگ ثابت**

در پاورپوینت، پر شدن رنگ ثابت یک گزینهٔ قالب‌بندی است که یک شکل را با یک رنگ یکنواخت پر می‌کند. این رنگ ساده پس‌زمینه بدون هیچ‌گونه گرادیان، بافت یا الگو اعمال می‌شود.

برای اعمال پر شدن رنگ ثابت به یک شکل با استفاده از Aspose.Slides، این مراحل را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) ایجاد کنید.
1. با استفاده از شاخص، مرجع یک اسلاید را دریافت کنید.
1. یک [IAutoShape](https://reference.aspose.com/slides/fa/net/aspose.slides/iautoshape/) به اسلاید اضافه کنید.
1. قالب [FillType](https://reference.aspose.com/slides/fa/net/aspose.slides/filltype/) شکل را به `Solid` تنظیم کنید.
1. رنگ پر مورد نظر خود را به شکل اختصاص دهید.
1. ارائهٔ تغییر یافته را به صورت فایل PPTX ذخیره کنید.

```c#
// یک نمونه از کلاس Presentation که یک فایل ارائه را نشان می‌دهد، ایجاد کنید.
using (Presentation presentation = new Presentation())
{
    // اسلاید اول را دریافت کنید.
    ISlide slide = presentation.Slides[0];

    // یک شکل خودکار از نوع Rectangle اضافه کنید.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // نوع پر را به Solid تنظیم کنید.
    shape.FillFormat.FillType = FillType.Solid;

    // رنگ پر را تنظیم کنید.
    shape.FillFormat.SolidFillColor.Color = Color.Yellow;

    // فایل PPTX را روی دیسک ذخیره کنید.
    presentation.Save("solid_color_fill.pptx", SaveFormat.Pptx);
}
```

نتیجه:
![شکل با پر شدن رنگ ثابت](solid-color-fill.png)

## **تنظیم شفافیت**

در پاورپوینت، هنگام اعمال پر شدن رنگ ثابت، گرادیان، تصویر یا بافت به اشکال، می‌توانید سطح شفافیتی را تنظیم کنید تا شفافیت پر شدن را کنترل کنید. مقدار بالاتر شفافیت باعث می‌شود شکل بیشتر شفاف شود و پس‌زمینه یا اشیاء زیرین به‌صورت جزئی قابل مشاهده باشند.

Aspose.Slides به شما امکان می‌دهد سطح شفافیت را با تنظیم مقدار آلفا در رنگ مورد استفاده برای پر شدن تنظیم کنید. در اینجا نحوهٔ انجام آن آورده شده است:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) ایجاد کنید.
1. با استفاده از شاخص، مرجع یک اسلاید را دریافت کنید.
1. یک [IAutoShape](https://reference.aspose.com/slides/fa/net/aspose.slides/iautoshape/) به اسلاید اضافه کنید.
1. قالب [FillType](https://reference.aspose.com/slides/fa/net/aspose.slides/filltype/) شکل را به `Solid` تنظیم کنید.
1. از `Color.FromArgb(alpha, baseColor)` برای تعریف رنگی با شفافیت استفاده کنید (مقدار `alpha` شفافیت را کنترل می‌کند).
1. ارائه را ذخیره کنید.

```c#
const int alpha = 128;

// یک نمونه از کلاس Presentation که یک فایل ارائه را نشان می‌دهد، ایجاد کنید.
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

## **چرخاندن اشکال**

Aspose.Slides به شما امکان می‌دهد اشکال را در ارائه‌های پاورپوینت چرخانده کنید. این می‌تواند هنگام موقعیت‌یابی عناصر بصری با نیازهای خاص تراز یا طراحی مفید باشد.

برای چرخاندن یک شکل در اسلاید، این مراحل را انجام دهید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) ایجاد کنید.
1. با استفاده از شاخص، مرجع یک اسلاید را دریافت کنید.
1. یک [IAutoShape](https://reference.aspose.com/slides/fa/net/aspose.slides/iautoshape/) به اسلاید اضافه کنید.
1. ویژگی `Rotation` شکل را به زاویهٔ دلخواه تنظیم کنید.
1. ارائه را ذخیره کنید.

```c#
// یک نمونه از کلاس Presentation که یک فایل ارائه را نشان می‌دهد، ایجاد کنید.
using (Presentation presentation = new Presentation())
{
    // اسلاید اول را دریافت کنید.
    ISlide slide = presentation.Slides[0];

    // یک شکل خودکار از نوع Rectangle اضافه کنید.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // شکل را به میزان 5 درجه بچرخانید.
    shape.Rotation = 5;

    // فایل PPTX را روی دیسک ذخیره کنید.
    presentation.Save("shape_rotation.pptx", SaveFormat.Pptx);
}
```

نتیجه:
![چرخش شکل](shape-rotation.png)

## **افزودن افکت‌های برجسته‌سازی 3D**

Aspose.Slides به شما امکان می‌دهد افکت‌های برجسته‌سازی 3D را بر روی اشکال اعمال کنید با پیکربندی ویژگی‌های [ThreeDFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/threedformat/) آن‌ها.

برای افزودن افکت‌های برجسته‌سازی 3D به یک شکل، مراحل زیر را دنبال کنید:

1. نمونه‌ای از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) ایجاد کنید.
1. با استفاده از شاخص، مرجع یک اسلاید را دریافت کنید.
1. یک [IAutoShape](https://reference.aspose.com/slides/fa/net/aspose.slides/iautoshape/) به اسلاید اضافه کنید.
1. ویژگی [ThreeDFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/threedformat/) شکل را پیکربندی کنید تا تنظیمات برجسته‌سازی را تعریف کنید.
1. ارائه را ذخیره کنید.

```c#
// یک نمونه از کلاس Presentation که یک فایل ارائه را نشان می‌دهد، ایجاد کنید.
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
![افکت برجسته‌سازی 3D](3D-bevel-effect.png)

## **افزودن افکت‌های چرخش 3D**

Aspose.Slides به شما امکان می‌دهد افکت‌های چرخش 3D را بر روی اشکال اعمال کنید با پیکربندی ویژگی‌های [ThreeDFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/threedformat/) آن‌ها.

برای اعمال چرخش 3D به یک شکل:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) ایجاد کنید.
1. با استفاده از شاخص، مرجع یک اسلاید را دریافت کنید.
1. یک [IAutoShape](https://reference.aspose.com/slides/fa/net/aspose.slides/iautoshape/) به اسلاید اضافه کنید.
1. [CameraType](https://reference.aspose.com/slides/fa/net/aspose.slides/icamera/cameratype/) و [LightType](https://reference.aspose.com/slides/fa/net/aspose.slides/ilightrig/lighttype/) شکل را تنظیم کنید تا چرخش 3D تعریف شود.
1. ارائه را ذخیره کنید.

```c#
// یک نمونه از کلاس Presentation که یک فایل ارائه را نشان می‌دهد، ایجاد کنید.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    autoShape.TextFrame.Text = "Hello, Aspose!";

    autoShape.ThreeDFormat.Depth = 6;
    autoShape.ThreeDFormat.Camera.SetRotation(40, 35, 20);
    autoShape.ThreeDFormat.Camera.CameraType = CameraPresetType.IsometricLeftUp;
    autoShape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;

    // ارائه را به صورت فایل PPTX ذخیره کنید.
    presentation.Save("3D_rotation_effect.pptx", SaveFormat.Pptx);
}
```

نتیجه:
![افکت چرخش 3D](3D-rotation-effect.png)

## **بازنشانی قالب‌بندی**

کد C# زیر نشان می‌دهد چگونه قالب‌بندی یک اسلاید را بازنشانی کرده و موقعیت، اندازه و قالب‌بندی تمام اشکال با مکان‌نگهدارها روی [LayoutSlide](https://reference.aspose.com/slides/fa/net/aspose.slides/layoutslide/) را به تنظیمات پیش‌فرض برگرداند:
```c#
using (Presentation presentation = new Presentation("sample.pptx"))
{
    foreach (ISlide slide in presentation.Slides)
    {
        // هر شکل را که در اسلاید دارای مکان‌نگهدار در طرح‌بندی است، بازنشانی کنید.
        slide.Reset();
    }

    presentation.Save("reset_formatting.pptx", SaveFormat.Pptx);
}
```

## **پرسش‌های متداول**

**آیا قالب‌بندی اشکال بر اندازهٔ نهایی فایل ارائه تاثیر می‌گذارد؟**

فقط به‌صورت کم. تصاویر و رسانه‌های جاسازی‌شده بیشترین فضای فایل را اشغال می‌کنند، در حالی که پارامترهای شکل مانند رنگ‌ها، افکت‌ها و گرادیان‌ها به‌صورت متادیتا ذخیره می‌شوند و به‌طور تقریباً هیچ افزایشی در حجم ایجاد نمی‌کنند.

**چگونه می‌توانم اشکالی را در یک اسلاید که قالب‌بندی یکسانی دارند شناسایی کنم تا بتوانم آن‌ها را گروه‌بندی کنم؟**

هر یک از ویژگی‌های کلیدی قالب‌بندی هر شکل را — تنظیمات پر، خط و افکت — مقایسه کنید. اگر تمام مقادیر مربوطه مطابقت داشته باشند، سبک‌های آن‌ها را یکسان در نظر گرفته و به‌صورت منطقی آن اشکال را گروه‌بندی کنید، که مدیریت سبک‌ها را در آینده ساده می‌کند.

**آیا می‌توانم مجموعه‌ای از سبک‌های سفارشی اشکال را در فایلی جداگانه ذخیره کنم تا در ارائه‌های دیگر استفاده مجدد شود؟**

بله. اشکال نمونه با سبک‌های دلخواه را در یک مجموعه اسلاید قالب یا یک فایل قالب .POTX ذخیره کنید. هنگام ایجاد یک ارائه جدید، قالب را باز کنید، اشکال سبک‌دار مورد نیاز را کلون کنید و قالب‌بندی آن‌ها را در هر جایی که لازم است دوباره اعمال کنید.