---
title: مدیریت فهرست‌های بولت‌دار و شماره‌دار در ارائه‌ها در .NET
linktitle: مدیریت فهرست‌ها
type: docs
weight: 70
url: /fa/net/manage-lists/
aliases:
  - /net/manage-bullet-and-numbered-lists/
keywords:
- بولت
- فهرست بولت‌دار
- فهرست شماره‌دار
- بولت نماد
- بولت تصویری
- بولت سفارشی
- فهرست چندسطحی
- ایجاد بولت
- اضافه کردن بولت
- اضافه کردن فهرست
- پاورپوینت
- اسناد باز
- ارائه
- .NET
- C#
- Aspose.Slides
description: "یاد بگیرید چگونه فهرست‌های بولت‌دار، تصویری، چندسطحی و شماره‌دار را در ارائه‌های پاورپوینت و اسناد باز با استفاده از Aspose.Slides برای .NET ایجاد و قالب‌بندی کنید."
---
## **نمای کلی**

Aspose.Slides for .NET به شما امکان ایجاد و قالب‌بندی فهرست‌های بولت‌دار و شماره‌دار را در ارائه‌های PowerPoint و OpenDocument می‌دهد. یک آیتم فهرست یک پاراگراف است که تنظیمات بولت آن از طریق قالب‌بندی پاراگراف کنترل می‌شود.

از ویژگی [IParagraph.ParagraphFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/iparagraph/paragraphformat/) برای دسترسی به تنظیمات فهرست در سطح پاراگراف استفاده کنید. نقطه ورودی اصلی [IParagraphFormat.Bullet](https://reference.aspose.com/slides/fa/net/aspose.slides/iparagraphformat/bullet/) است که یک شیء [IBulletFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/ibulletformat/) بازمی‌گرداند. با استفاده از این شیء می‌توانید نوع بولت، نماد، تصویر، رنگ، اندازه، سبک شماره‌گذاری و شماره شروع را تنظیم کنید.

این مقاله نشان می‌دهد چگونه:

- ایجاد یک فهرست بولت‌دار با نماد سفارشی
- ایجاد یک بولت تصویری
- ایجاد یک فهرست چندسطحی با تنظیم عمق پاراگراف
- ایجاد یک فهرست شماره‌دار
- بازرسی و تغییر قالب‌بندی فهرست در یک ارائه موجود

## **ایجاد فهرست بولت‌دار**

برای ایجاد یک فهرست بولت‌دار، اشیاء [IParagraph](https://reference.aspose.com/slides/fa/net/aspose.slides/iparagraph/) را به یک [ITextFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/itextframe/) اضافه کنید و [IBulletFormat.Type](https://reference.aspose.com/slides/fa/net/aspose.slides/ibulletformat/type/) را به [BulletType.Symbol](https://reference.aspose.com/slides/fa/net/aspose.slides/bullettype/) تنظیم کنید. سپس می‌توانید [IBulletFormat.Char](https://reference.aspose.com/slides/fa/net/aspose.slides/ibulletformat/char/)، [IBulletFormat.Color](https://reference.aspose.com/slides/fa/net/aspose.slides/ibulletformat/color/)، و [IBulletFormat.Height](https://reference.aspose.com/slides/fa/net/aspose.slides/ibulletformat/height/) را برای کنترل ظاهر بولت تنظیم کنید.

کد C# زیر نشان می‌دهد چگونه یک فهرست بولت‌دار را در یک اسلاید ایجاد کنید:

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

![نمادهای بولت](symbol_bullets.png)

## **ایجاد فهرست شماره‌دار**

در زمانی که ترتیب آیتم‌ها مهم است از فهرست‌های شماره‌دار استفاده کنید. [IBulletFormat.Type](https://reference.aspose.com/slides/fa/net/aspose.slides/ibulletformat/type/) را به [BulletType.Numbered](https://reference.aspose.com/slides/fa/net/aspose.slides/bullettype/) تنظیم کنید. همچنین می‌توانید یک قالب شماره‌گذاری را با [IBulletFormat.NumberedBulletStyle](https://reference.aspose.com/slides/fa/net/aspose.slides/ibulletformat/numberedbulletstyle/) انتخاب کنید یا [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/fa/net/aspose.slides/ibulletformat/numberedbulletstartwith/) را وقتی فهرست باید از مقداری غیر از 1 شروع شود تنظیم کنید.

کد C# زیر نشان می‌دهد چگونه یک فهرست شماره‌دار را در یک اسلاید ایجاد کنید:

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

![نمادهای شماره‌دار](numbered_bullets.png)

## **ایجاد بولت تصویری**

Aspose.Slides به شما امکان می‌دهد نماد بولت معمولی را با یک تصویر جایگزین کنید. بولت‌های تصویری بهترین کارایی را با تصاویر ساده‌ای دارند که در اندازه کوچک قابل خواندن باقی می‌مانند، مانند آیکون‌ها یا فایل‌های PNG شفاف کوچک.

{{% alert color="info" %}}
در حالت ایده‌آل، اگر قصد دارید نماد بولت معمولی را با تصویر جایگزین کنید، بهتر است یک گرافیک ساده با پس‌زمینه شفاف انتخاب کنید. چنین تصاویری به‌عنوان نمادهای بولت سفارشی به‌خوبی عمل می‌کنند.

به‌خاطر داشته باشید که تصویر به اندازه بسیار کوچکی مقیاس می‌شود. به همین دلیل، به‌شدّت توصیه می‌کنیم تصویری را انتخاب کنید که در استفاده به‌عنوان بولت در یک فهرست واضح و بصری مؤثر باقی بماند.
{{% /alert %}}

برای ایجاد یک بولت تصویری، یک تصویر را به [Presentation.Images](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/images/) اضافه کنید و شیء تصویر بازدهی شده را به [IBulletFormat.Picture](https://reference.aspose.com/slides/fa/net/aspose.slides/ibulletformat/picture/) اختصاص دهید. قبل از اختصاص تصویر، [IBulletFormat.Type](https://reference.aspose.com/slides/fa/net/aspose.slides/ibulletformat/type/) را به [BulletType.Picture](https://reference.aspose.com/slides/fa/net/aspose.slides/bullettype/) تنظیم کنید.

بیایید بگوییم فایلی به نام «image.png» داریم:

![یک تصویر برای بولت‌ها](picture_for_bullets.png)

کد C# زیر نشان می‌دهد چگونه بولت‌های تصویری را در یک اسلاید ایجاد کنید:

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

![بولت‌های تصویری](picture_bullets.png)

## **ایجاد فهرست چندسطحی**

از [IParagraphFormat.Depth](https://reference.aspose.com/slides/fa/net/aspose.slides/iparagraphformat/depth/) برای قرار دادن آیتم‌های فهرست در سطوح مختلف استفاده کنید. سطح 0 بالاترین سطح است، سطح 1 زیر آن تو در تو است و به همین ترتیب.

کد C# زیر نشان می‌دهد چگونه یک فهرست بولت‌دار چندسطحی ایجاد کنید:

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

برای تغییر قالب‌بندی فهرست در یک ارائه موجود، پاراگراف هدف را دسترسی یافته و تنظیمات [IParagraphFormat.Bullet](https://reference.aspose.com/slides/fa/net/aspose.slides/iparagraphformat/bullet/) آن را به‌روزرسانی کنید. همان ویژگی‌هایی که برای ایجاد فهرست‌ها استفاده می‌شوند می‌توانند برای بازرسی یا ویرایش فهرست‌های بارگذاری شده از فایل‌های PPT، PPTX یا ODP به کار روند.

کد C# زیر پاراگراف اول در یک چارچوب متن را به‌کارگیری سبک فهرست شماره‌دار تغییر می‌دهد:

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

## **سؤالات متداول**

### آیا فهرست‌های بولت‌دار و شماره‌دار می‌توانند به PDF یا تصاویر صادر شوند؟

بله. Aspose.Slides قالب‌بندی فهرست را حفظ می‌کند زمانی که قالب هدف از چیدمان متن و ویژگی‌های بولت مربوطه پشتیبانی می‌کند.

### آیا می‌توانم فهرست‌ها را در ارائه‌های موجود ویرایش کنم؟

بله. ارائه را بارگذاری کنید، به پاراگراف هدف دسترسی پیدا کنید، تنظیمات [IParagraphFormat.Bullet](https://reference.aspose.com/slides/fa/net/aspose.slides/iparagraphformat/bullet/) آن را بررسی یا به‌روزرسانی کنید و سپس ارائه را ذخیره نمایید.

### آیا فهرست‌ها می‌توانند متن غیر لاتین داشته باشند؟

بله. متن آیتم‌های فهرست می‌تواند شامل کاراکترهای یونی‌کد باشد، بنابراین می‌توانید فهرست‌ها را در ارائه‌های چند زبانه ایجاد کنید. مطمئن شوید که قلم‌های استفاده شده در ارائه از کاراکترهای مورد نیاز شما پشتیبانی می‌کند.