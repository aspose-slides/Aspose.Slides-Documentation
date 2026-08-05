---
title: ایجاد تصویرهای بندانگشتی از شکل‌های ارائه در .NET
linktitle: تصویرهای بندانگشتی شکل
type: docs
weight: 70
url: /fa/net/create-shape-thumbnails/
keywords:
- بندانگشتی شکل
- تصویر شکل
- رندر شکل
- رندر شکل
- حدود بصری
- حدود شکل
- پاورپوینت
- ارائه
- .NET
- C#
- Aspose.Slides
description: "تصویرهای بندانگشتی با کیفیت بالا از شکل‌های اسلایدهای PowerPoint را با Aspose.Slides برای .NET ایجاد کنید – به راحتی بندانگشتی‌های ارائه را ایجاد و صادر کنید."
---
## **معرفی**

Aspose.Slides for .NET برای ایجاد فایل‌های ارائه استفاده می‌شود که هر صفحه یک اسلاید است. این اسلایدها می‌توانند با باز کردن فایل‌های ارائه با Microsoft PowerPoint مشاهده شوند. اما گاهی اوقات توسعه‌دهندگان ممکن است نیاز داشته باشند تصاویر شکل‌ها را به‌صورت جداگانه در یک نمایشگر تصویر ببینند. در این موارد Aspose.Slides for .NET به شما کمک می‌کند تا تصاویر بندانگشتی از شکل‌های اسلاید تولید کنید. نحوه استفاده از این ویژگی در این مقاله توضیح داده شده است.

این مقاله توضیح می‌دهد که چگونه می‌توانید تصاویر بندانگشتی اسلاید را به روش‌های مختلف تولید کنید:

- تولید تصویر بندانگشتی یک شکل داخل اسلاید.
- تولید تصویر بندانگشتی یک شکل اسلاید با ابعاد تعریف‌شده توسط کاربر.
- تولید تصویر بندانگشتی یک شکل در محدودیت ظاهر شکل.

## **تولید تصویر بندانگشتی یک شکل از اسلاید**
برای تولید تصویر بندانگشتی یک شکل از هر اسلاید با استفاده از Aspose.Slides for .NET:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) ایجاد کنید.
2. مرجع هر اسلاید را با استفاده از شناسه یا اندیس آن به‌دست آورید.
3. تصویر بندانگشتی شکل اسلاید مرجع را با مقیاس پیش‌فرض دریافت کنید.
4. تصویر بندانگشتی را در هر فرمت تصویری دلخواه ذخیره کنید.

مثال زیر تصویر بندانگشتی شکل را تولید می‌کند.

```c#
using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    IShape shape = presentation.Slides[0].Shapes[0];
    using (IImage image = shape.GetImage())
    {
        image.Save("Shape_thumbnail_out.png", ImageFormat.Png);
    }
}
```

## **تولید تصویر بندانگشتی با ضریب مقیاس کاربر تعریف‌شده**
برای تولید تصویر بندانگشتی شکل هر اسلاید با استفاده از Aspose.Slides for .NET:

1. یک نمونه از کلاس `Presentation` ایجاد کنید.
2. مرجع هر اسلاید را با استفاده از شناسه یا اندیس آن به‌دست آورید.
3. تصویر بندانگشت اسلاید مرجع را با محدودهٔ شکل دریافت کنید.
4. تصویر بندانگشت را در هر فرمت تصویری دلخواه ذخیره کنید.

مثال زیر تصویری بندانگشتی با ضریب مقیاس تعریف‌شده توسط کاربر تولید می‌کند.

```c#
ShapeThumbnailBounds bounds = ShapeThumbnailBounds.Shape;
float scale = 1; // مقیاس‌بندی در محورهای X و Y.

using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    IShape shape = presentation.Slides[0].Shapes[0];
    using (IImage image = shape.GetImage(bounds, scale, scale))
    {
        image.Save("Scaling Factor Thumbnail_out.png", ImageFormat.Png);
    }
}
```

## **ایجاد تصویر بندانگشتی ظاهر شکل مبتنی بر حدود**
این روش برای ایجاد تصاویر بندانگشتی از شکل‌ها به توسعه‌دهندگان امکان می‌دهد تا یک تصویر بندانگشتی در حدود ظاهر شکل تولید کنند. تمام اثرات شکل در نظر گرفته می‌شود. تصویر بندانگشتی تولید شده توسط حدود اسلاید محدود می‌شود. برای تولید تصویر بندانگشتی هر شکل اسلاید در حدود ظاهر آن، از کد نمونه زیر استفاده کنید:

1. یک نمونه از کلاس `Presentation` ایجاد کنید.
2. مرجع هر اسلاید را با استفاده از شناسه یا اندیس آن به‌دست آورید.
3. تصویر بندانگشتی اسلاید مرجع را با حدود شکل به‌عنوان ظاهر دریافت کنید.
4. تصویر بندانگشتی را در هر فرمت تصویری دلخواه ذخیره کنید.

مثال زیر تصویری بندانگشتی را با تولید تصویر بندانگشتی با ضریب مقیاس تعریف‌شده توسط کاربر ایجاد می‌کند.

```c#
ShapeThumbnailBounds bounds = ShapeThumbnailBounds.Appearance;
float scale = 1; // مقیاس‌بندی در محورهای X و Y.

using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    IShape shape = presentation.Slides[0].Shapes[0];
    using (IImage image = shape.GetImage(bounds, scale, scale))
    {
        image.Save("Shape_thumbnail_Bound_Shape_out.png", ImageFormat.Png);
    }
}
```

## **دریافت حدود بصری واقعی یک شکل**

ویژگی‌های فریم [IShape](https://reference.aspose.com/slides/fa/net/aspose.slides/ishape/) — ویژگی‌های `X`، `Y`، `Width` و `Height` — مستطیلی را که در مدل ارائه ذخیره شده توصیف می‌کنند. محتوایی که در واقع رندر می‌شود می‌تواند فراتر از آن فریم گسترش یابد یا مستطیل محور‑محور متفاوتی را اشغال کند. چرخش، خطوط مرزی، سرهای پیکان، چیدمان و سرریز متن، هندسهٔ SmartArt تولید شده و سایر اثرات رندر می‌توانند تماماً ناحیهٔ اشغال‌شده را تغییر دهند.

از [GetVisualBounds](https://reference.aspose.com/slides/fa/net/aspose.slides/shape/getvisualbounds/) برای محاسبهٔ آن ناحیهٔ اشغال‌شده بدون ایجاد تصویر استفاده کنید. این متد یک [RectangleF](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.rectanglef) در مختصات اسلاید برمی‌گرداند. مستطیل بازگشتی به اسلاید کلیپ نمی‌شود، بنابراین مختصات آن می‌تواند هنگام گسترش محتوا فراتر از مبدأ اسلاید منفی باشد.

[GetVisualBounds](https://reference.aspose.com/slides/fa/net/aspose.slides/shape/getvisualbounds/) در حال حاضر توسط رابط [IShape](https://reference.aspose.com/slides/fa/net/aspose.slides/ishape/) اعلام نشده است. بنابراین، شکل به‌دست‌آمده از مجموعهٔ شکل‌های اسلاید را به عنوان مقدار رابط نگه دارید و فقط هنگام فراخوانی متد آن را تبدیل کنید.

مثال زیر فریم و حدود بصری را دریافت و مقایسه می‌کند:

```csharp
using var presentation = new Presentation("example.pptx");

var slide = presentation.Slides[0];
IShape shape = slide.Shapes[0];

var visualBounds = ((Shape)shape).GetVisualBounds();
var frameBounds = new RectangleF(shape.X, shape.Y, shape.Width, shape.Height);

Console.WriteLine($"Frame bounds: {frameBounds}");
Console.WriteLine($"Visual bounds: {visualBounds}");
```

همین [RectangleF](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.rectanglef) می‌تواند برای تراز کردن شکل‌های نزدیک به لبهٔ `Left`، `Right`، `Top` یا `Bottom` آن، رزرو فضای کافی در یک چیدمان تولید شده، یا تشخیص محتوای خارج از ناحیهٔ مجاز استفاده شود. حدود بصری به‌ویژه برای SmartArt، جعبه‌های متن، پیکان‌ها، تصاویر، شکل‌های چرخان و گروه‌های شکل‌ها مفید هستند، جایی که فریم ذخیره‌شده ممکن است نمای کامل رندر شده را نشان ندهد.

از [GetVisualBounds](https://reference.aspose.com/slides/fa/net/aspose.slides/shape/getvisualbounds/) زمانی استفاده کنید که به مختصات برای چیدمان یا اعتبارسنجی نیاز دارید و به یک بیت‌مپ نیاز ندارید. برای رندر کردن شکل از [IShape.GetImage](https://reference.aspose.com/slides/fa/net/aspose.slides/ishape/getimage/) استفاده کنید. با [ShapeThumbnailBounds](https://reference.aspose.com/slides/fa/net/aspose.slides/shapethumbnailbounds/)، `ShapeThumbnailBounds.Shape` تصویر را از حدود شکل، شامل تنظیمات خطوط مرزی، اندازه می‌دهد، در حالی که `ShapeThumbnailBounds.Appearance` آن را از ظاهر شکل اندازه می‌کند و نتیجه را به حدود اسلاید محدود می‌سازد. در مقابل، [GetVisualBounds](https://reference.aspose.com/slides/fa/net/aspose.slides/shape/getvisualbounds/) فقط مستطیل محاسبه‌شده را برمی‌گرداند و آن را به اسلاید کلیپ نمی‌کند.

## **FAQ**

**چه فرمت‌های تصویری می‌توانند هنگام ذخیرهٔ تصاویر بندانگشتی شکل استفاده شوند؟**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/fa/net/aspose.slides/imageformat/)، و دیگران. شکل‌ها همچنین می‌توانند به‌صورت [SVG برداری صادر شوند](https://reference.aspose.com/slides/fa/net/aspose.slides/shape/writeassvg/) با ذخیرهٔ محتوای شکل به‌عنوان SVG.

**تفاوت حدود Shape و Appearance هنگام رندر کردن یک تصویر بندانگشتی چیست؟**

`Shape` از هندسهٔ شکل استفاده می‌کند؛ `Appearance` اثرات بصری را درنظر می‌گیرد، مانند [visual effects](/slides/fa/net/shape-effect/) (سایه‌ها، درخشندگی‌ها و غیره).

**اگر یک شکل به‌عنوان مخفی علامت‌گذاری شود چه اتفاقی می‌افتد؟ آیا همچنان به‌عنوان تصویر بندانگشتی رندر می‌شود؟**

یک شکل مخفی همچنان بخشی از مدل است و می‌تواند رندر شود؛ پرچم مخفی بودن فقط نمایش اسلایدشو را تحت تأثیر قرار می‌دهد اما از تولید تصویر شکل جلوگیری نمی‌کند.

**آیا شکل‌های گروهی، نمودارها، SmartArt و سایر اشیاء پیچیده پشتیبانی می‌شوند؟**

بله. هر شیئی که به‌صورت [Shape](https://reference.aspose.com/slides/fa/net/aspose.slides/shape/) نمایندگی می‌شود (از جمله [GroupShape](https://reference.aspose.com/slides/fa/net/aspose.slides/groupshape/)، [Chart](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/chart/)، و [SmartArt](https://reference.aspose.com/slides/fa/net/aspose.slides.smartart/smartart/)) می‌تواند به‌عنوان تصویر بندانگشتی یا به‌صورت SVG ذخیره شود.

**آیا قلم‌های نصب‌شده در سیستم بر کیفیت تصاویر بندانگشتی شکل‌های متنی تأثیر می‌گذارند؟**

بله. باید [قلم‌های مورد نیاز را فراهم کنید](/slides/fa/net/custom-font/) (یا [جایگزینی قلم‌ها را پیکربندی کنید](/slides/fa/net/font-substitution/)) تا از بازگشت‌های ناخواسته و بازچیدمان متن جلوگیری شود.