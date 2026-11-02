---
title: مدیریت فهرست‌های نقطه‌دار و عددی در ارائه‌ها در .NET
linktitle: مدیریت فهرست‌ها
type: docs
weight: 70
url: /fa/net/manage-lists/
aliases:
  - /net/manage-bullet-and-numbered-lists/
keywords:
- نقطه‌چین
- فهرست نقطه‌دار
- فهرست عددی
- نقطه نمادین
- نقطه تصویری
- نقطه سفارشی
- فهرست چندسطحی
- ایجاد نقطه
- افزودن نقطه
- افزودن فهرست
- PowerPoint
- OpenDocument
- ارائه
- .NET
- C#
- Aspose.Slides
description: "نحوه ایجاد و قالب‌بندی فهرست‌های نقطه‌دار، تصویری، چندسطحی و عددی در ارائه‌های PowerPoint و OpenDocument با استفاده از Aspose.Slides برای .NET."
---
## **نمای کلی**

Aspose.Slides for .NET به شما امکان می‌دهد فهرست‌های نقطه‌دار و عددی را در ارائه‌های PowerPoint و OpenDocument ایجاد و قالب‌بندی کنید. یک مورد فهرست، پاراگرافی است که تنظیمات نقطه‌گذاری آن از طریق قالب پاراگراف کنترل می‌شود.

از ویژگی [IParagraph.ParagraphFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/paragraphformat/) برای دسترسی به تنظیمات فهرست در سطح پاراگراف استفاده کنید. نقطهٔ ورودی اصلی [IParagraphFormat.Bullet](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/bullet/) است که یک شیء [IBulletFormat](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/) را برمی‌گرداند. با استفاده از این شیء می‌توانید نوع نقطه، نماد، تصویر، رنگ، اندازه، سبک شماره‌گذاری و شمارهٔ آغاز را تعیین کنید.

این مقاله نحوهٔ:

- ایجاد فهرست نقطه‌دار با نماد سفارشی
- ایجاد نقطهٔ تصویری
- ایجاد فهرست چندسطحی با تنظیم عمق پاراگراف
- ایجاد فهرست عددی
- بررسی و تغییر قالب‌بندی فهرست در یک ارائه موجود
- خواندن مقادیر واقعی نقطه و شماره‌ها در کنار متن پاراگراف

را نشان می‌دهد.

## **ایجاد فهرست نقطه‌دار**

برای ایجاد فهرست نقطه‌دار، اشیاء [IParagraph](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/) را به یک [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) اضافه کنید و ویژگی [IBulletFormat.Type](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/type/) را به [BulletType.Symbol](https://reference.aspose.com/slides/net/aspose.slides/bullettype/) تنظیم کنید. سپس می‌توانید [IBulletFormat.Char](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/char/)، [IBulletFormat.Color](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/color/)، و [IBulletFormat.Height](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/height/) را برای کنترل ظاهر نقطه تنظیم کنید.

کد C# زیر نشان می‌دهد چگونه یک فهرست نقطه‌دار در یک اسلاید ایجاد شود:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

static Paragraph CreateParagraph(string text)
{
    var paragraph = new Paragraph();
    paragraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    paragraph.ParagraphFormat.Bullet.Char = '*';
    paragraph.ParagraphFormat.Indent = 15;
    paragraph.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True;
    paragraph.ParagraphFormat.Bullet.Color.Color = Color.IndianRed;
    paragraph.ParagraphFormat.Bullet.Height = 100;
    paragraph.Text = text;
    return paragraph;
}

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 200, 50);

var textFrame = autoShape.TextFrame;
textFrame.Paragraphs.Clear();

var paragraph1 = CreateParagraph("The first paragraph");
textFrame.Paragraphs.Add(paragraph1);

var paragraph2 = CreateParagraph("The second paragraph");
textFrame.Paragraphs.Add(paragraph2);

presentation.Save("symbol_bullets.pptx", SaveFormat.Pptx);
```

نتیجه:

![نمادهای نقطه‌ای](symbol_bullets.png)

## **ایجاد فهرست عددی**

از فهرست‌های عددی زمانی استفاده کنید که ترتیب موارد مهم باشد. ویژگی [IBulletFormat.Type](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/type/) را به [BulletType.Numbered](https://reference.aspose.com/slides/net/aspose.slides/bullettype/) تنظیم کنید. همچنین می‌توانید قالب شماره‌گذاری را با [IBulletFormat.NumberedBulletStyle](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/numberedbulletstyle/) انتخاب کنید یا با [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/numberedbulletstartwith/) شمارهٔ شروع را وقتی فهرست باید از مقداری غیر از 1 آغاز شود، تعیین کنید.

کد C# زیر نشان می‌دهد چگونه یک فهرست عددی در یک اسلاید ایجاد شود:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 90, 80);

var textFrame = autoShape.TextFrame;
textFrame.Paragraphs.Clear();

var paragraph1 = new Paragraph();
paragraph1.ParagraphFormat.Bullet.Type = BulletType.Numbered;
paragraph1.Text = "Apple";
textFrame.Paragraphs.Add(paragraph1);

var paragraph2 = new Paragraph();
paragraph2.ParagraphFormat.Bullet.Type = BulletType.Numbered;
paragraph2.Text = "Orange";
textFrame.Paragraphs.Add(paragraph2);

var paragraph3 = new Paragraph();
paragraph3.ParagraphFormat.Bullet.Type = BulletType.Numbered;
paragraph3.Text = "Banana";
textFrame.Paragraphs.Add(paragraph3);

presentation.Save("numbered_bullets.pptx", SaveFormat.Pptx);
```

نتیجه:

![نقاط عددی](numbered_bullets.png)

## **ایجاد نقطهٔ تصویری**

Aspose.Slides به شما اجازه می‌دهد نماد نقطهٔ معمولی را با یک تصویر جایگزین کنید. نقاط تصویری بهترین عملکرد را با تصاویری ساده دارند که در اندازهٔ کوچک قابل خواندن باشند، مانند آیکون‌ها یا فایل‌های PNG شفاف کوچک.

{{% alert color="info" title="Note" %}}
در صورتی که قصد جایگزینی نماد نقطهٔ معمولی با تصویر را دارید، بهتر است گرافیک ساده‌ای با پس‌زمینهٔ شفاف انتخاب کنید. چنین تصاویری به‌عنوان نمادهای سفارشی نقطهٔ مناسب‌اند.

به خاطر داشته باشید که تصویر تا اندازهٔ بسیار کوچکی مقیاس می‌شود. به همین دلیل توصیه می‌کنیم تصویری را انتخاب کنید که هنگام استفاده به عنوان نقطه در فهرست واضح و مؤثر بماند.
{{% /alert %}}

برای ایجاد نقطهٔ تصویری، یک تصویر را به [Presentation.Images](https://reference.aspose.com/slides/net/aspose.slides/presentation/images/) اضافه کنید و شیء تصویر برگشتی را به [IBulletFormat.Picture](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/picture/) اختصاص دهید. قبل از اختصاص تصویر، ویژگی [IBulletFormat.Type](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/type/) را به [BulletType.Picture](https://reference.aspose.com/slides/net/aspose.slides/bullettype/) تنظیم کنید.

فرض کنیم فایلی به نام "image.png" داریم:

![تصویری برای نقاط](picture_for_bullets.png)

کد C# زیر نشان می‌دهد چگونه نقاط تصویری در یک اسلاید ایجاد شوند:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

static Paragraph CreateParagraph(string text, IPPImage image)
{
    var paragraph = new Paragraph();
    paragraph.ParagraphFormat.Bullet.Type = BulletType.Picture;
    paragraph.ParagraphFormat.Bullet.Picture.Image = image;
    paragraph.ParagraphFormat.Indent = 15;
    paragraph.ParagraphFormat.Bullet.Height = 100;
    paragraph.Text = text;
    return paragraph;
}

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 200, 50);

var textFrame = autoShape.TextFrame;
textFrame.Paragraphs.Clear();

var imageBytes = File.ReadAllBytes("image.png");
var bulletImage = presentation.Images.AddImage(imageBytes);

var paragraph1 = CreateParagraph("The first paragraph", bulletImage);
textFrame.Paragraphs.Add(paragraph1);

var paragraph2 = CreateParagraph("The second paragraph", bulletImage);
textFrame.Paragraphs.Add(paragraph2);

presentation.Save("picture_bullets.pptx", SaveFormat.Pptx);
```

نتیجه:

![نقاط تصویری](picture_bullets.png)

## **ایجاد فهرست چندسطحی**

از ویژگی [IParagraphFormat.Depth](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/depth/) برای قرار دادن موارد فهرست در سطوح مختلف استفاده کنید. سطح 0 بالاترین سطح است، سطح 1 در زیر آن تو در تو می‌شود و به همین ترتیب.

کد C# زیر نشان می‌دهد چگونه یک فهرست نقطه‌دار چندسطحی ایجاد شود:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 260, 110);

var textFrame = autoShape.TextFrame;
textFrame.Paragraphs.Clear();

var paragraph1 = new Paragraph();
paragraph1.ParagraphFormat.Depth = 0;
paragraph1.Text = "My text - Depth 0";
textFrame.Paragraphs.Add(paragraph1);

var paragraph2 = new Paragraph();
paragraph2.ParagraphFormat.Depth = 1;
paragraph2.Text = "My text - Depth 1";
textFrame.Paragraphs.Add(paragraph2);

var paragraph3 = new Paragraph();
paragraph3.ParagraphFormat.Depth = 2;
paragraph3.Text = "My text - Depth 2";
textFrame.Paragraphs.Add(paragraph3);

var paragraph4 = new Paragraph();
paragraph4.ParagraphFormat.Depth = 3;
paragraph4.Text = "My text - Depth 3";
textFrame.Paragraphs.Add(paragraph4);

presentation.Save("multilevel_bullets.pptx", SaveFormat.Pptx);
```

نتیجه:

![فهرست چندسطحی](multilevel_list.png)

## **تغییر فهرست موجود**

برای تغییر قالب‌بندی فهرست در یک ارائه موجود، به پاراگراف هدف دسترسی پیدا کنید و تنظیمات [IParagraphFormat.Bullet](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/bullet/) آن را به‌روز کنید. همان ویژگی‌هایی که برای ایجاد فهرست‌ها استفاده می‌شدند، می‌توانند برای بررسی یا اصلاح فهرست‌های بارگذاری شده از فایل‌های PPT، PPTX یا ODP به کار روند.

کد C# زیر اولین پاراگراف در یک فریم متن را به سبک فهرست عددی تغییر می‌دهد:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");
var slide = presentation.Slides[0];
var autoShape = (IAutoShape)slide.Shapes[0];

var paragraph = autoShape.TextFrame.Paragraphs[0];
paragraph.ParagraphFormat.Bullet.Type = BulletType.Numbered;
paragraph.ParagraphFormat.Bullet.NumberedBulletStyle = NumberedBulletStyle.BulletRomanUCPeriod;
paragraph.ParagraphFormat.Bullet.NumberedBulletStartWith = 1;
paragraph.ParagraphFormat.MarginLeft = 30;
paragraph.ParagraphFormat.Indent = -20;

presentation.Save("updated_list.pptx", SaveFormat.Pptx);
```

## **خواندن مقادیر واقعی نقطه**

هنگام استخراج محتوای ارائه، نشانه‌های فهرست را در کنار متن پاراگراف نگه دارید. با فراخوانی [IParagraphFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/geteffective/) و دسترسی به [IParagraphFormatEffectiveData.Bullet](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformateffectivedata/bullet/) قالب نقطهٔ مؤثر را دریافت کنید. قبل از خواندن [ActualBulletValue](https://reference.aspose.com/slides/net/aspose.slides/ibulletformateffectivedata/actualbulletvalue/) نوع ([Type](https://reference.aspose.com/slides/net/aspose.slides/ibulletformateffectivedata/type/)) آن را بررسی کنید.

برای فهرست‌های عددی، این سه مقدار را متمایز کنید:

- [NumberedBulletStyle](https://reference.aspose.com/slides/net/aspose.slides/ibulletformateffectivedata/numberedbulletstyle/) قالب را تعیین می‌کند، مثلاً اعداد عربی به‌همراه نقطه یا حروف کوچک الفبا به‌همراه نقطه.
- [NumberedBulletStartWith](https://reference.aspose.com/slides/net/aspose.slides/ibulletformateffectivedata/numberedbulletstartwith/) شمارهٔ شروع را برای یک گروه از پاراگراف‌های عددی مشخص می‌کند.
- [ActualBulletValue](https://reference.aspose.com/slides/net/aspose.slides/ibulletformateffectivedata/actualbulletvalue/) نشانگر قالب‌بندی شدهٔ پاراگراف خاصی را برمی‌گرداند. به‌عنوان مثال، مورد دوم در فهرستی که از 5 شروع می‌شود، `6.` را برمی‌گرداند.

با هر پاراگراف، ویژگی [Depth](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/depth/) را حفظ کنید تا سطح تو در توی آن باقی بماند. نشانگر واقعی کل سلسله‌مراتب را رمزگذاری نمی‌کند: یک مورد تو در تو می‌تواند `c.` را برگرداند نه برچسب ترکیبی مانند `6.c.`.

مثال کاملاً خودکفی زیر فهرست‌ها را ایجاد می‌کند، آنها را در یک ارائه ذخیره می‌کند و سپس ارائه را بارگذاری می‌کند تا متن هر پاراگراف، عمق، نوع نقطه و مقدار واقعی را گزارش دهد. نشانگر تصویر آبی کوچک از SVG درون‌خطی ساخته می‌شود.

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation())
{
    presentation.SlideSize.SetSize(720, 440, SlideSizeScaleType.DoNotScale);
    var slide = presentation.Slides[0];

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 20, 660, 400);
    shape.FillFormat.FillType = FillType.NoFill;
    shape.LineFormat.FillFormat.FillType = FillType.NoFill;

    var textFrame = shape.TextFrame;
    textFrame.Paragraphs.Clear();

    // یک نشانگر تصویری بدون فایل تصویر خارجی ایجاد کنید.
    var svg = new SvgImage("<svg xmlns='http://www.w3.org/2000/svg' width='16' height='16'><rect width='16' height='16' rx='4' fill='#0078D4'/></svg>");
    var bulletImage = presentation.Images.AddImage(svg);

    void AddParagraph(string text, short depth, BulletType type, short start = 1, NumberedBulletStyle style = NumberedBulletStyle.BulletArabicPeriod)
    {
        var paragraph = new Paragraph { Text = text };

        var format = paragraph.ParagraphFormat;
        format.Depth = depth;
        format.MarginLeft = 30 + depth * 40;
        format.Indent = -28;
        format.SpaceAfter = 8;
        format.DefaultPortionFormat.FontHeight = 22;
        format.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
        format.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
        format.Bullet.Type = type;
        format.Bullet.IsBulletHardColor = NullableBool.True;
        format.Bullet.Color.Color = Color.Black;
        if (type == BulletType.Numbered)
        {
            format.Bullet.NumberedBulletStyle = style;
            format.Bullet.NumberedBulletStartWith = start;
        }
        else if (type == BulletType.Symbol)
        {
            format.Bullet.Char = '\u2022';
        }
        else if (type == BulletType.Picture)
        {
            format.Bullet.Picture.Image = bulletImage;
        }

        textFrame.Paragraphs.Add(paragraph);
    }

    AddParagraph("First item", 0, BulletType.Numbered, 5);
    AddParagraph("Second item", 0, BulletType.Numbered, 5);
    AddParagraph("Nested item", 1, BulletType.Numbered, 3, NumberedBulletStyle.BulletAlphaLCPeriod);
    AddParagraph("Next nested item", 1, BulletType.Numbered, 3, NumberedBulletStyle.BulletAlphaLCPeriod);
    AddParagraph("Deep item", 2, BulletType.Numbered, 4, NumberedBulletStyle.BulletRomanLCPeriod);
    AddParagraph("Back to top level", 0, BulletType.Numbered, 5);
    AddParagraph("Symbol marker", 0, BulletType.Symbol);
    AddParagraph("No bullet", 0, BulletType.None);
    AddParagraph("Picture marker", 0, BulletType.Picture);
    presentation.Save("actual_bullet_values.pptx", SaveFormat.Pptx);
}

using var loadedPresentation = new Presentation("actual_bullet_values.pptx");
var loadedShape = (IAutoShape)loadedPresentation.Slides[0].Shapes[0];
Console.WriteLine("Text | Depth | Type | Actual value");
foreach (var paragraph in loadedShape.TextFrame.Paragraphs)
{
    var bullet = paragraph.ParagraphFormat.GetEffective().Bullet;
    string marker;
    switch (bullet.Type)
    {
        case BulletType.Numbered:
        case BulletType.Symbol:
            marker = bullet.ActualBulletValue;
            break;
        case BulletType.None:
            marker = $"{bullet.ActualBulletValue ?? "null"} (no bullet)";
            break;
        case BulletType.Picture:
            marker = $"{bullet.ActualBulletValue ?? "null"} (image required)";
            break;
        default:
            marker = "unsupported bullet type";
            break;
    }
    Console.WriteLine($"{paragraph.Text} | {paragraph.ParagraphFormat.Depth} | {bullet.Type} | {marker}");
}
```

فهرست‌های منبع در زیر نشان داده شده‌اند.

![فهرست‌هایی که از 5 شروع می‌شوند، موارد حروفی و رومی تو در تو، یک نشانگر نمادین، پاراگرافی بدون نقطه و یک نشانگر تصویر آبی](actual_bullet_values.png)

گزارش با نشانگرهای نمایش داده‌شده در PowerPoint مطابقت دارد:

```text
Text | Depth | Type | Actual value
First item | 0 | Numbered | 5.
Second item | 0 | Numbered | 6.
Nested item | 1 | Numbered | c.
Next nested item | 1 | Numbered | d.
Deep item | 2 | Numbered | iv.
Back to top level | 0 | Numbered | 7.
Symbol marker | 0 | Symbol | •
No bullet | 0 | None | null (no bullet)
Picture marker | 0 | Picture | null (image required)
```

برای [BulletType.None and BulletType.Picture](https://reference.aspose.com/slides/net/aspose.slides/bullettype/)، [ActualBulletValue](https://reference.aspose.com/slides/net/aspose.slides/ibulletformateffectivedata/actualbulletvalue/) مقدار `null` را برمی‌گرداند، نه رشتهٔ خالی. این انواع را جداگانه مدیریت کنید: نوع اول هیچ نشانگری ندارد، در حالی که نوع دوم نیاز به استخراج تصویر نقطه به‌صورت جداگانه دارد. یک نقطهٔ تصویری تنها با استخراج نشانگر متنی قابل بازآفرینی نیست.

## **سؤال‌های متداول**

**آیا می‌توان فهرست‌های نقطه‌دار و عددی را به PDF یا تصویر صادر کرد؟**

بله. Aspose.Slides قالب‌بندی فهرست را هنگامی که قالب هدف ویژگی‌های متن و نقطهٔ مربوطه را پشتیبانی کند، حفظ می‌کند.

**آیا می‌توان فهرست‌ها را در ارائه‌های موجود ویرایش کرد؟**

بله. ارائه را بارگذاری کنید، به پاراگراف هدف دسترسی پیدا کنید، تنظیمات [IParagraphFormat.Bullet](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/bullet/) آن را بررسی یا به‌روز کنید و سپس ارائه را ذخیره نمایید.

**آیا فهرست‌ها می‌توانند شامل متن غیرلاتینی باشند؟**

بله. متن موارد فهرست می‌تواند شامل کاراکترهای یونیکد باشد، بنابراین می‌توانید فهرست‌ها را در ارائه‌های چندزبانه ایجاد کنید. اطمینان حاصل کنید که قلم‌های استفاده‌شده در ارائه، کاراکترهای مورد نیاز شما را پشتیبانی می‌کنند.