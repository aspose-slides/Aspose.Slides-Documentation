---
title: مدیریت فهرست‌های بولت‌دار و عددی در ارائه‌ها با .NET
linktitle: مدیریت فهرست‌ها
type: docs
weight: 70
url: /fa/net/manage-lists/
keywords:
- بولت
- فهرست بولت‌دار
- فهرست عددی
- بولت نمادین
- بولت تصویری
- بولت سفارشی
- فهرست چندسطحی
- ایجاد بولت
- اضافه کردن بولت
- اضافه کردن فهرست
- PowerPoint
- OpenDocument
- ارائه
- .NET
- C#
- Aspose.Slides
description: "بیاموزید چگونه فهرست‌های بولت‌دار، تصویری، چندسطحی و عددی را در ارائه‌های PowerPoint و OpenDocument با استفاده از Aspose.Slides برای .NET ایجاد و قالب‌بندی کنید."
---
## **نمای کلی**

Aspose.Slides for .NET به شما امکان می‌دهد تا فهرست‌های بولت‌دار و عددی را در ارائه‌های PowerPoint و OpenDocument ایجاد و قالب‌بندی کنید. یک مورد فهرست یک پاراگراف است که تنظیمات بولت آن از طریق قالب پاراگراف آن کنترل می‌شود.

از ویژگی [IParagraph.ParagraphFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/iparagraph/paragraphformat/) برای دسترسی به تنظیمات فهرست در سطح پاراگراف استفاده کنید. نقطهٔ ورودی اصلی [IParagraphFormat.Bullet](https://reference.aspose.com/slides/fa/net/aspose.slides/iparagraphformat/bullet/) است که یک شیء [IBulletFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/ibulletformat/) برمی‌گرداند. با این شیء می‌توانید نوع بولت، نماد، تصویر، رنگ، اندازه، سبک شماره‌گذاری و شمارهٔ شروع را تنظیم کنید.

این مقاله نشان می‌دهد چگونه:

- ایجاد یک فهرست بولت‌دار با نماد سفارشی
- ایجاد یک بولت تصویری
- ایجاد یک فهرست چندسطحی با تنظیم عمق پاراگراف
- ایجاد یک فهرست عددی
- بررسی و تغییر قالب‌بندی فهرست در یک ارائه موجود

## **ایجاد یک فهرست بولت‌دار**

برای ایجاد یک فهرست بولت‌دار، اشیای [IParagraph](https://reference.aspose.com/slides/fa/net/aspose.slides/iparagraph/) را به یک [ITextFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/itextframe/) اضافه کنید و [IBulletFormat.Type](https://reference.aspose.com/slides/fa/net/aspose.slides/ibulletformat/type/) را به [BulletType.Symbol](https://reference.aspose.com/slides/fa/net/aspose.slides/bullettype/) تنظیم کنید. سپس می‌توانید [IBulletFormat.Char](https://reference.aspose.com/slides/fa/net/aspose.slides/ibulletformat/char/)، [IBulletFormat.Color](https://reference.aspose.com/slides/fa/net/aspose.slides/ibulletformat/color/) و [IBulletFormat.Height](https://reference.aspose.com/slides/fa/net/aspose.slides/ibulletformat/height/) را برای کنترل ظاهر بولت تعیین کنید.

```csharp
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

![بولت‌های نمادین](symbol_bullets.png)

## **ایجاد یک فهرست عددی**

از فهرست‌های عددی زمانی استفاده کنید که ترتیب موارد مهم است. [IBulletFormat.Type](https://reference.aspose.com/slides/fa/net/aspose.slides/ibulletformat/type/) را به [BulletType.Numbered](https://reference.aspose.com/slides/fa/net/aspose.slides/bullettype/) تنظیم کنید. همچنین می‌توانید قالب شماره‌گذاری را با [IBulletFormat.NumberedBulletStyle](https://reference.aspose.com/slides/fa/net/aspose.slides/ibulletformat/numberedbulletstyle/) انتخاب کنید یا هنگام نیاز به شروع از مقدار دیگری غیر از 1، [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/fa/net/aspose.slides/ibulletformat/numberedbulletstartwith/) را تنظیم کنید.

```csharp
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

![بولت‌های عددی](numbered_bullets.png)

## **ایجاد یک بولت تصویری**

Aspose.Slides به شما اجازه می‌دهد تا نماد بولت معمولی را با یک تصویر جایگزین کنید. بولت‌های تصویری بهترین عملکرد را با تصاویری ساده که در اندازهٔ کوچک قابل خواندن باقی می‌مانند، مانند آیکون‌ها یا فایل‌های PNG شفاف کوچک، دارند.

{{% alert color="primary" %}}
در حالت ایده‌آل، اگر قصد دارید نماد بولت معمولی را با یک تصویر جایگزین کنید، بهتر است گرافیک ساده‌ای با پس‌زمینهٔ شفاف انتخاب کنید. چنین تصاویری به عنوان نمادهای بولت سفارشی به خوبی عمل می‌کنند.
{{% /alert %}}

به خاطر داشته باشید که تصویر به یک اندازهٔ بسیار کوچک مقیاس می‌شود. به همین دلیل، به شدت توصیه می‌کنیم تصویری انتخاب کنید که حتی در این اندازهٔ کوچک واضح و بصری مؤثر باقی بماند.

برای ایجاد یک بولت تصویری، یک تصویر را به [Presentation.Images](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/images/) اضافه کنید و شیء تصویر بازگشتی را به [IBulletFormat.Picture](https://reference.aspose.com/slides/fa/net/aspose.slides/ibulletformat/picture/) اختصاص دهید. قبل از اختصاص تصویر، [IBulletFormat.Type](https://reference.aspose.com/slides/fa/net/aspose.slides/ibulletformat/type/) را به [BulletType.Picture](https://reference.aspose.com/slides/fa/net/aspose.slides/bullettype/) تنظیم کنید.

فرض کنید فایلی به نام "image.png" داریم:

![تصویری برای بولت‌ها](picture_for_bullets.png)

```csharp
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

## **ایجاد یک فهرست چندسطحی**

از [IParagraphFormat.Depth](https://reference.aspose.com/slides/fa/net/aspose.slides/iparagraphformat/depth/) برای قرار دادن موارد فهرست در سطوح مختلف استفاده کنید. سطح 0 بالاترین سطح است، سطح 1 زیر آن تو در تو می‌شود و به همین ترتیب ادامه دارد.

```csharp
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

## **تغییر یک فهرست موجود**

برای تغییر قالب‌بندی فهرست در یک ارائه موجود، به پاراگراف هدف دسترسی پیدا کنید و تنظیمات [IParagraphFormat.Bullet](https://reference.aspose.com/slides/fa/net/aspose.slides/iparagraphformat/bullet/) آن را به‌روزرسانی کنید. همان خصوصیات استفاده‌شده برای ایجاد فهرست‌ها می‌توانند برای بررسی یا اصلاح فهرست‌های بارگذاری‌شده از فایل‌های PPT، PPTX یا ODP استفاده شوند.

```csharp
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

## **سوالات متداول**

**آیا فهرست‌های بولت‌دار و عددی می‌توانند به PDF یا تصاویر صادر شوند؟**

بله. Aspose.Slides قالب‌بندی فهرست را زمانی که فرمت هدف از چیدمان متن و ویژگی‌های بولت متناظر پشتیبانی می‌کند، حفظ می‌کند.

**آیا می‌توانم فهرست‌ها را در ارائه‌های موجود ویرایش کنم؟**

بله. ارائه را بارگذاری کنید، به پاراگراف هدف دسترسی پیدا کنید، تنظیمات [IParagraphFormat.Bullet](https://reference.aspose.com/slides/fa/net/aspose.slides/iparagraphformat/bullet/) را بررسی یا به‌روزرسانی کنید و سپس ارائه را ذخیره کنید.

**آیا فهرست‌ها می‌توانند متن غیرلاتین داشته باشند؟**

بله. متن موارد فهرست می‌تواند شامل کاراکترهای یونیکد باشد، بنابراین می‌توانید فهرست‌ها را در ارائه‌های چندزبانه ایجاد کنید. اطمینان حاصل کنید که قلم‌های استفاده‌شده در ارائه، کاراکترهای مورد نیاز شما را پشتیبانی می‌کنند.