---
title: مدیریت پاراگراف‌های متن PowerPoint در .NET
linktitle: مدیریت پاراگراف
type: docs
weight: 40
url: /fa/net/manage-paragraph/
aliases:
  - /net/paragraph/
  - /net/portion/
keywords:
- افزودن متن
- افزودن پاراگراف
- مدیریت متن
- مدیریت پاراگراف
- مدیریت گلوله
- تورفتگی پاراگراف
- تورفتگی معلق
- گلوله پاراگراف
- فهرست شماره‌دار
- فهرست نقطه‌ای
- ویژگی‌های پاراگرف
- واردات HTML
- متن به HTML
- پاراگراف به HTML
- پاراگراف به تصویر
- متن به تصویر
- صادرات پاراگراف
- PowerPoint
- ارائه
- .NET
- C#
- Aspose.Slides
description: "یاد بگیرید چگونه با Aspose.Slides برای .NET پاراگراف‌ها، بخش‌ها، گلوله‌ها، فهرست‌های شماره‌دار، تورفتگی‌ها، محتوای HTML و تصاویر پاراگراف را ایجاد و قالب‌بندی کنید."
---
## **مرور کلی**

Aspose.Slides for .NET متن را به‌عنوان سلسله‌مراتی از فریم‌های متن، پاراگراف‌ها و بخش‌ها نشان می‌دهد:

* [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) نمایانگر محفظه متن در یک شکل است و دسترسی به مجموعه پاراگراف‌های آن را فراهم می‌کند.
* [IParagraph](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/) نمایانگر یک پاراگراف در فریم متن است و دسترسی به بخش‌ها و قالب‌بندی سطح پاراگراف را فراهم می‌کند.
* [IPortion](https://reference.aspose.com/slides/net/aspose.slides/iportion/) نمایانگر یک بخش متن درون یک پاراگراف است. هر بخش می‌تواند متن و قالب‌بندی در سطح کاراکتر خود را داشته باشد.

بنابراین یک پاراگراف می‌تواند متن با فونت‌ها، رنگ‌ها، اندازه‌ها و سایر قالب‌بندی‌های مختلف را با استفاده از چندین بخش داشته باشد.

## **ایجاد و قالب‌بندی پاراگراف‌ها**

پاراگراف‌ها را در فریم متن یک شکل ایجاد کنید و از بخش‌ها برای قالب‌بندی اجرای متن‌های فردی استفاده کنید. این بخش نشان می‌دهد چگونه چندین بخش را در هر پاراگراف ترکیب کنید و رنگ‌ها، اندازه‌های قلم و سبک‌های مختلف را اعمال کنید.

### **ایجاد پاراگراف با چندین بخش**

مثال زیر به زبان C# سه پاراگراف ایجاد می‌کند که هر کدام شامل سه اجرای متن در مجموعه [IParagraph.Portions](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/portions/) خود هستند. این مثال پاراگراف پیش‌فرض و بخش خالی آن را مجدداً استفاده می‌کند، سپس پاراگراف‌ها و بخش‌های باقی‌مانده را اضافه می‌کند. قالب‌بندی از طریق [IPortion.PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iportion/portionformat/) اعمال می‌شود: اولین بخش در هر پاراگراف قرمز، بولد و 15 پوینت است؛ دومین بخش آبی، ایتالیک و 18 پوینت؛ بخش سوم قالب‌بندی پیش‌فرض خود را حفظ می‌کند:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 300, 150);
var textFrame = shape.TextFrame;

var firstParagraph = textFrame.Paragraphs[0];
firstParagraph.Portions.Add(new Portion());
firstParagraph.Portions.Add(new Portion());

var secondParagraph = new Paragraph();
secondParagraph.Portions.Add(new Portion());
secondParagraph.Portions.Add(new Portion());
secondParagraph.Portions.Add(new Portion());
textFrame.Paragraphs.Add(secondParagraph);

var thirdParagraph = new Paragraph();
thirdParagraph.Portions.Add(new Portion());
thirdParagraph.Portions.Add(new Portion());
thirdParagraph.Portions.Add(new Portion());
textFrame.Paragraphs.Add(thirdParagraph);

var paragraphCount = textFrame.Paragraphs.Count;
for (var paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++)
{
    var paragragaph = textFrame.Paragraphs[paragraphIndex];
    var portionCount = paragragaph.Portions.Count;
    for (var portionIndex = 0; portionIndex < portionCount; portionIndex++)
    {
        var portion = paragragaph.Portions[portionIndex];
        portion.Text = $"Portion {paragraphIndex + 1}.{portionIndex + 1}";

        if (portionIndex == 0)
        {
            portion.PortionFormat.FillFormat.FillType = FillType.Solid;
            portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Red;
            portion.PortionFormat.FontBold = NullableBool.True;
            portion.PortionFormat.FontHeight = 15;
        }
        else if (portionIndex == 1)
        {
            portion.PortionFormat.FillFormat.FillType = FillType.Solid;
            portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Blue;
            portion.PortionFormat.FontItalic = NullableBool.True;
            portion.PortionFormat.FontHeight = 18;
        }
    }
}

presentation.Save("paragraphs_with_portions.pptx", SaveFormat.Pptx);
```

## **ایجاد فهرست‌های نقطه‌ای و عددی**

متن پاراگراف را در فهرست‌هایی با نمادها، اعداد یا تصاویر سفارشی سازماندهی کنید. مثال‌های این بخش شامل قالب‌بندی گلوله‌ها، فهرست‌های چندسطحه‌ای و شروع اعداد سفارشی هستند.

### **ایجاد فهرست نقطه‌ای یا عددی**

گلوله‌ها و شماره‌گذاری موارد مرتبط را برای اسکن آسان‌تر می‌کند. در Aspose.Slides، تنظیمات فهرست از طریق [IBulletFormat](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/) تعریف می‌شوند.

این مثال به زبان C# یک گلوله نمادین و یک مورد شماره‌دار را به همان فریم متن اضافه می‌کند. [IBulletFormat.Type](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/type/) نوع گلوله را انتخاب می‌کند، در حالی که [IBulletFormat.Char](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/char/) نماد را ارائه می‌دهد و [IBulletFormat.NumberedBulletStyle](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/numberedbulletstyle/) سبک شماره‌گذاری را انتخاب می‌کند. هر دو مورد از گلوله‌های سیاه با ارتفاع 100 درصد و تورفتگی پاراگراف 25 پوینت استفاده می‌کنند:

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
var textFrame = shape.TextFrame;
textFrame.Paragraphs.Clear();

var symbolParagraph = new Paragraph { Text = "Welcome to Aspose.Slides" };
symbolParagraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
symbolParagraph.ParagraphFormat.Bullet.Char = Convert.ToChar(0x2022);
symbolParagraph.ParagraphFormat.Indent = 25;
symbolParagraph.ParagraphFormat.Bullet.Color.ColorType = ColorType.RGB;
symbolParagraph.ParagraphFormat.Bullet.Color.Color = Color.Black;
symbolParagraph.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True;
symbolParagraph.ParagraphFormat.Bullet.Height = 100;
textFrame.Paragraphs.Add(symbolParagraph);

var numberedParagraph = new Paragraph { Text = "This is a numbered item" };
numberedParagraph.ParagraphFormat.Bullet.Type = BulletType.Numbered;
numberedParagraph.ParagraphFormat.Bullet.NumberedBulletStyle = NumberedBulletStyle.BulletCircleNumWDBlackPlain;
numberedParagraph.ParagraphFormat.Indent = 25;
numberedParagraph.ParagraphFormat.Bullet.Color.ColorType = ColorType.RGB;
numberedParagraph.ParagraphFormat.Bullet.Color.Color = Color.Black;
numberedParagraph.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True;
numberedParagraph.ParagraphFormat.Bullet.Height = 100;
textFrame.Paragraphs.Add(numberedParagraph);

presentation.Save("bulleted_and_numbered_list.pptx", SaveFormat.Pptx);
```

### **استفاده از گلوله‌های تصویری**

گلوله‌های تصویری به شما امکان می‌دهند به جای نماد یا عدد، از یک تصویر سفارشی استفاده کنید.

این مثال به زبان C# یک تصویر را به مجموعه تصویرهای ارائه به عنوان یک [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/) اضافه می‌کند و به عنوان گلوله پاراگراف استفاده می‌کند. این مثال [IBulletFormat.Type](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/type/) را برای استفاده از گلوله تصویری تنظیم می‌کند و تصویر را از طریق [IBulletFormat.Picture](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/picture/) اختصاص می‌دهد. [IBulletFormat.Height](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/height/) بر روی 100 درصد تنظیم می‌شود تا اندازه گلوله نسبت به متن پاراگراف تنظیم شود:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var bulletImage = Images.FromFile("bullets.png");
var presentationImage = presentation.Images.AddImage(bulletImage);

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
var textFrame = shape.TextFrame;
textFrame.Paragraphs.Clear();

var paragraph = new Paragraph { Text = "Welcome to Aspose.Slides" };
paragraph.ParagraphFormat.Bullet.Type = BulletType.Picture;
paragraph.ParagraphFormat.Bullet.Picture.Image = presentationImage;
paragraph.ParagraphFormat.Bullet.Height = 100;
textFrame.Paragraphs.Add(paragraph);

presentation.Save("picture_bullet.pptx", SaveFormat.Pptx);
presentation.Save("picture_bullet.ppt", SaveFormat.Ppt);
```

### **ایجاد فهرست چندسطحی**

مقدار [IParagraphFormat.Depth](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/depth/) را تنظیم کنید تا پاراگراف‌ها در سطوح مختلف یک فهرست قرار گیرند. سطح بالایی عمق `0` دارد.

این مثال به زبان C# مقادیر [IParagraphFormat.Depth](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/depth/) را از 0 تا 3 به چهار پاراگراف اختصاص می‌دهد و یک سلسله‌مراتبی در یک فریم متن ایجاد می‌کند. هر پاراگراف از یک گلوله نماد استفاده می‌کند، به‌طوری که [IBulletFormat.Char](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/char/) بین یک گلوله گرد و یک خط تیره برای تمایز سطوح مجاور جابجا می‌شود:

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
var textFrame = shape.TextFrame;
textFrame.Paragraphs.Clear();

var firstParagraph = new Paragraph { Text = "Content" };
firstParagraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
firstParagraph.ParagraphFormat.Bullet.Char = Convert.ToChar(0x2022);
firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
firstParagraph.ParagraphFormat.Depth = 0;

var secondParagraph = new Paragraph { Text = "Second level" };
secondParagraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
secondParagraph.ParagraphFormat.Bullet.Char = '-';
secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
secondParagraph.ParagraphFormat.Depth = 1;

var thirdParagraph = new Paragraph { Text = "Third level" };
thirdParagraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
thirdParagraph.ParagraphFormat.Bullet.Char = Convert.ToChar(0x2022);
thirdParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
thirdParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
thirdParagraph.ParagraphFormat.Depth = 2;

var fourthParagraph = new Paragraph { Text = "Fourth level" };
fourthParagraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
fourthParagraph.ParagraphFormat.Bullet.Char = '-';
fourthParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
fourthParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
fourthParagraph.ParagraphFormat.Depth = 3;

textFrame.Paragraphs.Add(firstParagraph);
textFrame.Paragraphs.Add(secondParagraph);
textFrame.Paragraphs.Add(thirdParagraph);
textFrame.Paragraphs.Add(fourthParagraph);

presentation.Save("multilevel_list.pptx", SaveFormat.Pptx);
```

### **شروع موارد فهرست شماره‌دار با مقادیر سفارشی**

از [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/numberedbulletstartwith/) برای تنظیم عدد اولیه نمایش داده شده برای یک پاراگراف شماره‌دار استفاده کنید.

این مثال به زبان C# مقدار [IBulletFormat.Type](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/type/) را برای استفاده از شماره‌گذاری برای سه پاراگراف تنظیم می‌کند و مقادیر [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/numberedbulletstartwith/) را به ترتیب 2، 3 و 7 اختصاص می‌دهد. مقدار شروع به‌صورت جداگانه برای هر پاراگراف پیکربندی می‌شود تا اعداد نمایش داده شده مقادیر را صرف‌نظر کنند:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
var textFrame = shape.TextFrame;
textFrame.Paragraphs.Clear();

var firstParagraph = new Paragraph { Text = "Start at 2" };
firstParagraph.ParagraphFormat.Bullet.Type = BulletType.Numbered;
firstParagraph.ParagraphFormat.Bullet.NumberedBulletStartWith = 2;
textFrame.Paragraphs.Add(firstParagraph);

var secondParagraph = new Paragraph { Text = "Start at 3" };
secondParagraph.ParagraphFormat.Bullet.Type = BulletType.Numbered;
secondParagraph.ParagraphFormat.Bullet.NumberedBulletStartWith = 3;
textFrame.Paragraphs.Add(secondParagraph);

var thirdParagraph = new Paragraph { Text = "Start at 7" };
thirdParagraph.ParagraphFormat.Bullet.Type = BulletType.Numbered;
thirdParagraph.ParagraphFormat.Bullet.NumberedBulletStartWith = 7;
textFrame.Paragraphs.Add(thirdParagraph);

presentation.Save("custom_numbered_list.pptx", SaveFormat.Pptx);
```

## **کنترل طرح‌بندی پاراگراف و ویژگی‌های انتهای آن**

حاشیه‌ها و تورفتگی‌های پاراگراف را تنظیم کنید تا موقعیت خط اول و خطوط بسته‌شده را کنترل کنید. همچنین می‌توانید علامت انتهای پاراگراف را جدا از بخش‌های متن قابل مشاهده قالب‌بندی کنید.

### **تنظیم تورفتگی خط اول**

از ویژگی [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) برای کنترل تورفتگی خط اول یک پاراگراف استفاده کنید. این ویژگی فقط خط اول را نسبت به حاشیه چپ پاراگراف جابجا می‌کند. مقدار مثبت، خط اول را به راست منتقل می‌کند، در حالی که خطوط باقی‌مانده نسبت به بدنه پاراگراف هم‌راستا می‌مانند.

از [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginleft/) زمانی که نیاز دارید تمام پاراگراف را جابجا کنید، استفاده کنید. از [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) زمانی که فقط خط اول را می‌خواهید جابجا کنید، استفاده کنید.

مثال زیر سه پاراگراف را با همان مقدار [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginleft/) برابر 20 پوینت و مقادیر [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) برابر 0، 20 و 40 پوینت می‌دهد. خطوط اول در فاصله‌های افزایشی بزرگتر شروع می‌شوند، در حالی که خطوط بسته‌شده همان حاشیه چپ را حفظ می‌کنند:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
shape.FillFormat.FillType = FillType.NoFill;
shape.LineFormat.FillFormat.FillType = FillType.Solid;
shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Gray;

var textFrame = shape.TextFrame;
textFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;
textFrame.Paragraphs.Clear();

var firstParagraph = new Paragraph { Text = "No first-line indent. Wrapped lines start at the same position as the first line." };
firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
firstParagraph.ParagraphFormat.MarginLeft = 20;
firstParagraph.ParagraphFormat.Indent = 0;

var secondParagraph = new Paragraph { Text = "First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body." };
secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
secondParagraph.ParagraphFormat.MarginLeft = 20;
secondParagraph.ParagraphFormat.Indent = 20;

var thirdParagraph = new Paragraph { Text = "First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see." };
thirdParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
thirdParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
thirdParagraph.ParagraphFormat.MarginLeft = 20;
thirdParagraph.ParagraphFormat.Indent = 40;

textFrame.Paragraphs.Add(firstParagraph);
textFrame.Paragraphs.Add(secondParagraph);
textFrame.Paragraphs.Add(thirdParagraph);

presentation.Save("paragraph_indent.pptx", SaveFormat.Pptx);
```

نتیجه:

![تورفتگی خط اول پاراگراف‌ها](first_line_indent.png)

### **تنظیم تورفتگی معلق**

تورفتگی معلق یک طرح‌بندی پاراگراف است که در آن خط اول نسبت به بقیه خطوط به سمت چپ شروع می‌شود. در Aspose.Slides، می‌توانید این اثر را با ویژگی [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) ایجاد کنید. مقدار `Indent` را به مقدار منفی تنظیم کنید تا خط اول نسبت به بدنه پاراگراف به سمت چپ حرکت کند.

در عمل، [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginleft/) موقعیت چپ بدنه پاراگراف را تعریف می‌کند و [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) موقعیت خط اول را نسبت به آن حاشیه مشخص می‌کند. برای ایجاد تورفتگی معلق، مقدار `MarginLeft` مثبت و مقدار `Indent` منفی تنظیم کنید.

این قالب‌بندی برای کتاب‌های مرجع، مراجع، ورودی‌های واژه‌نامه و سایر پاراگراف‌هایی که خطوط بسته‌شده باید زیر بدنه پاراگراف و نه زیر اولین کاراکتر خط اول قرار گیرند، مفید است.

مثال زیر به زبان C# مقادیر [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginleft/) برابر 40 و 60 پوینت را با مقادیر [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) برابر -20 و -30 پوینت ترکیب می‌کند. در هر پاراگراف، خط اول نسبت به خطوط بسته‌شده به سمت چپ شروع می‌شود؛ پاراگراف دوم تورفتگی معلق عمیق‌تری دارد:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
shape.FillFormat.FillType = FillType.NoFill;
shape.LineFormat.FillFormat.FillType = FillType.Solid;
shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Gray;

var textFrame = shape.TextFrame;
textFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;
textFrame.Paragraphs.Clear();

var firstParagraph = new Paragraph { Text = "A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body." };
firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
firstParagraph.ParagraphFormat.MarginLeft = 40;
firstParagraph.ParagraphFormat.Indent = -20;

var secondParagraph = new Paragraph { Text = "This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare." };
secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
secondParagraph.ParagraphFormat.MarginLeft = 60;
secondParagraph.ParagraphFormat.Indent = -30;

textFrame.Paragraphs.Add(firstParagraph);
textFrame.Paragraphs.Add(secondParagraph);

presentation.Save("hanging_indent.pptx", SaveFormat.Pptx);
```

نتیجه:

![تورفتگی معلق پاراگراف‌ها](hanging_indent.png)

### **تنظیم ویژگی‌های اجرا در انتهای پاراگراف**

ویژگی [IParagraph.EndParagraphPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/endparagraphportionformat/) قالب‌بندی علامت انتهای پاراگراف را کنترل می‌کند. مثال زیر یک [PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/portionformat/) با [IBasePortionFormat.FontHeight](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fontheight/) برابر 48 پوینت و [IBasePortionFormat.LatinFont](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/latinfont/) برابر Times New Roman ایجاد می‌کند. این قالب را به علامت انتهای پاراگراف دوم اختصاص می‌دهد و بخش‌های متن قابل مشاهده را بدون تغییر می‌گذارد:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Test.pptx");
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 200, 250);
var textFrame = shape.TextFrame;
textFrame.Paragraphs.Clear();

var firstParagraph = new Paragraph();
firstParagraph.Portions.Add(new Portion("Sample text"));

var secondParagraph = new Paragraph();
secondParagraph.Portions.Add(new Portion("Sample text 2"));

var endParagraphFormat = new PortionFormat();
endParagraphFormat.FontHeight = 48;
endParagraphFormat.LatinFont = new FontData("Times New Roman");
secondParagraph.EndParagraphPortionFormat = endParagraphFormat;

textFrame.Paragraphs.Add(firstParagraph);
textFrame.Paragraphs.Add(secondParagraph);

presentation.Save("end_paragraph_format.pptx", SaveFormat.Pptx);
```

## **شمارش خطوط رندر شده**

برای قواعد پاراگراف که بر بسته شدن خودکار و نقطه‌گذاری در انتهای خطوط تأثیر می‌گذارند، به [Control Line Breaking](/slides/fa/net/text-formatting/#control-line-breaking) و [Control Hanging Punctuation](/slides/fa/net/text-formatting/#control-hanging-punctuation) مراجعه کنید.

از [IParagraph.GetLinesCount](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getlinescount/) برای شمارش خطوطی که یک پاراگراف پس از چیدمان متن اشغال می‌کند، شامل بسته شدن خودکار، استفاده کنید. این برای بررسی طول متن و چیدمان در قالب‌های ارائه مفید است.

پاراگراف یک مورد در [ITextFrame.Paragraphs](https://reference.aspose.com/slides/net/aspose.slides/itextframe/paragraphs/) است و می‌تواند چندین خط رندر شده را اشغال کند. یک شکست خط صریح درون پاراگراف یک خط جدید ایجاد می‌کند بدون اینکه پاراگراف دیگری ساخته شود. بسته شدن خودکار خطوط را بر اساس عرض موجود ایجاد می‌کند بدون اینکه شکست‌های صریح در متن درج شود. بنابراین شمارش پاراگراف‌ها یا کاراکترهای شکست خط شمارش خطوط رندر شده را نمی‌دهد.

مثال زیر یک شکل متن ایجاد می‌کند، خطوط آن را می‌شمارد، شکل را باریک می‌کند و سپس متن را با رشته کوتاه‌تری جایگزین می‌کند. این مثال [ITextFrameFormat.WrapText](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/wraptext/) را فعال می‌کند و [ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/autofittype/) را غیرفعال می‌سازد تا عرض شکل بسته شدن را کنترل کند بدون اینکه متن یا شکل به‌صورت خودکار کوچک شود. هر اندازه‌گیری با استفاده از [IParagraph.GetLinesCount](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getlinescount/) انجام می‌شود. ابعاد شکل بر پایه پوینت هستند. در نهایت، مثال یک پاراگراف دیگر اضافه می‌کند و شمارش خطوط را در سراسر فریم متن جمع می‌کند:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 200);
var textFrame = shape.TextFrame;
textFrame.TextFrameFormat.WrapText = NullableBool.True;
textFrame.TextFrameFormat.AutofitType = TextAutofitType.None;

var paragraph = textFrame.Paragraphs[0];
paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight = 20;
paragraph.Text = "This text demonstrates how automatic wrapping changes the number of rendered lines.";
Console.WriteLine($"Original width: {paragraph.GetLinesCount()}");

shape.Width = 150;
Console.WriteLine($"Narrower shape: {paragraph.GetLinesCount()}");

paragraph.Text = "Short text.";
Console.WriteLine($"Shorter text: {paragraph.GetLinesCount()}");

var secondParagraph = new Paragraph { Text = "Another paragraph." };
secondParagraph.ParagraphFormat.DefaultPortionFormat.FontHeight = 20;
textFrame.Paragraphs.Add(secondParagraph);

var totalLineCount = 0;
foreach (var currentParagraph in textFrame.Paragraphs)
{
    totalLineCount += currentParagraph.GetLinesCount();
}
Console.WriteLine($"Total lines in the text frame: {totalLineCount}");
```

با این متن و این ابعاد، باریک کردن شکل تعداد خطوط را افزایش می‌دهد، در حالی که جایگزینی متن با رشته کوتاه تعداد آن را کاهش می‌دهد. شمارش دقیق می‌تواند بسته به در دسترس بودن قلم و جایگزینی، اندازه قلم، حاشیه‌ها، تورفتگی، بسته شدن و تنظیمات autofit متفاوت باشد. برای بررسی قالب، از قلم‌ها و تنظیمات چیدمان مورد نظر برای محیط هدف استفاده کنید.

تعداد خطوط به تنهایی تعیین‌کننده این نیست که آیا متن از محفظه خود تجاوز می‌کند یا نه. ارتفاع موجود، ارتفاع خطوط، فاصله پاراگراف و خط، و رفتار autofit نیز مهم هستند؛ حتی یک خط می‌تواند عرض موجود را در صورت غیرفعال بودن بسته شدن تجاوز کند.

## **واردات و صادرات محتوای پاراگراف**

از HTML برای وارد کردن متن به یک ارائه یا صادرات پاراگراف‌های موجود برای استفاده خارج از آن استفاده کنید. این بخش همچنین نحوه رندر کردن پاراگراف‌های منفرد به عنوان تصویر، شامل پاراگراف‌های داخل سلول‌های جدول را نشان می‌دهد.

### **وارد کردن متن HTML به پاراگراف‌ها**

از [ParagraphCollection.AddFromHtml](https://reference.aspose.com/slides/net/aspose.slides/paragraphcollection/addfromhtml/) برای تبدیل نشانه‌گذاری HTML به پاراگراف‌ها و بخش‌ها در یک فریم متن استفاده کنید.

این مثال به زبان C# HTML را از یک فایل می‌خواند و نشانه‌گذاری را به [ParagraphCollection.AddFromHtml](https://reference.aspose.com/slides/net/aspose.slides/paragraphcollection/addfromhtml/) می‌فرستد. این مثال پاراگراف پیش‌فرض فریم متن را پاک می‌کند تا فریم فقط شامل محتوای وارد شده باشد. شکل مستطیلی حاشیه 10 پوینت در هر طرف اسلاید را باقی می‌گذارد:

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shapeWidth = presentation.SlideSize.Size.Width - 20;
var shapeHeight = presentation.SlideSize.Size.Height - 20;
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, shapeWidth, shapeHeight);
shape.FillFormat.FillType = FillType.NoFill;
shape.TextFrame.Paragraphs.Clear();

using var reader = new StreamReader("file.html");
var html = reader.ReadToEnd();
shape.TextFrame.Paragraphs.AddFromHtml(html);

presentation.Save("html_text.pptx", SaveFormat.Pptx);
```

### **صادر کردن متن پاراگراف به HTML**

از [ParagraphCollection.ExportToHtml](https://reference.aspose.com/slides/net/aspose.slides/paragraphcollection/exporttohtml/) برای صادرات یک بازه انتخاب شده از پاراگراف‌ها به HTML استفاده کنید. هنگام استفاده دوباره از متن ارائه در یک وب‌سایت، ممکن است بخواهید تأکید محلی را حفظ کنید بدون اینکه قلم، اندازه یا سبک جعبه متن ارائه را به‌هم بزنید. مقدار [TextToHtmlConversionOptions.TextInheritanceLimit](https://reference.aspose.com/slides/net/aspose.slides.export/texttohtmlconversionoptions/textinheritancelimit/) را تنظیم کنید تا کنترل کنید مبدل تا چه حد ویژگی‌های قالب‌بندی را دنبال می‌کند.

فایل نمونه ارائه را از طریق [the sample presentation](text-inheritance.pptx) دانلود کنید و آن را در پوشه کاری برنامه قرار دهید. اسلاید اول آن شامل یک شکل متن با متن "Inherited text; explicit red 18pt" است. ورودی عمداً از چندین سطح قالب‌بندی استفاده می‌کند:

- قالب متن پیش‌فرض ارائه Calibri و اندازه 28 پوینت را فراهم می‌کند.
- قالب متن سطح اول فریم متن متن آبی و ایتالیک را فراهم می‌کند.
- پاراگراف به‌صراحت متن بولد تنظیم می‌کند.
- بخش دوم، "explicit red 18pt"، به‌صراحت متن قرمز و اندازه 18 پوینت تنظیم می‌کند.

مثال کامل زیر همان پاراگراف‌ها را سه بار صادر می‌کند. این مثال [TextToHtmlConversionOptions](https://reference.aspose.com/slides/net/aspose.slides.export/texttohtmlconversionoptions/) را به متد صادرات می‌فرستد و هر نتیجه را به عنوان یک فایل HTML UTF-8 جداگانه می‌نویسد:

```csharp
using System.IO;
using System.Text;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("text-inheritance.pptx");
var textShape = (IAutoShape)presentation.Slides[0].Shapes[0];

var paragraphs = textShape.TextFrame.Paragraphs;
var modes = new[] { TextInheritanceLimit.All, TextInheritanceLimit.TextBox, TextInheritanceLimit.ParagraphOnly };

foreach (var mode in modes)
{
    var options = new TextToHtmlConversionOptions { TextInheritanceLimit = mode };

    var html = paragraphs.ExportToHtml(0, paragraphs.Count, options);
    File.WriteAllText($"{mode}.html", html, Encoding.UTF8);
}
```

HTML تولید شده شامل CSS زیر برای بخش اول، "Inherited text; " است. جدول اعلان‌های مربوطه را فهرست می‌کند؛ سایر ویژگی‌های تولید شده برای وضوح حذف شده‌اند.

| خروجی | CSS مربوط به بخش اول | ظاهر |
| --- | --- | --- |
| `All.html` | `font-family:'Calibri'; font-size:28pt; color:#0000ff; font-style:italic; font-weight:bold` | متن آبی، بولد، ایتالیک با اندازه 28 پوینت در Calibri، اگر این قلم موجود باشد. |
| `TextBox.html` | `color:#0000ff; font-style:italic; font-weight:bold` | متن آبی، بولد، ایتالیک؛ فونت و اندازه توسط صفحه یا مرورگر پیرامونی فراهم می‌شود. |
| `ParagraphOnly.html` | `font-weight:bold` | متن بولد؛ فونت، اندازه، رنگ و سبک ایتالیک توسط صفحه یا مرورگر پیرامونی تأمین می‌شود. |

بخش دوم `color:#ff0000`، `font-size:18pt` و `font-weight:bold` را در هر سه خروجی حفظ می‌کند. همچنین ایتالیک را در `All` و `TextBox` حفظ می‌کند، اما در `ParagraphOnly` نیست. محدود کردن وراثت بنابراین قالب‌بندی اختصاصی به یک پاراگراف یا بخش را حذف نمی‌کند.

فایل‌ها را در یک مرورگر یکسان باز کنید تا آنها را مقایسه کنید. در دو حالت محدود شده، ویژگی‌های CSS حذف‌شده توسط سبک‌های صفحه مقصد یا پیش‌فرض‌های مرورگر حل می‌شوند، بنابراین ظاهر نهایی به جایی که HTML استفاده می‌شود بستگی دارد.

### **رندر کردن یک پاراگراف به عنوان تصویر**

[IParagraph.GetImage](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getimage/) یک پاراگراف منفرد را مستقیماً رندر می‌کند و یک [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) برمی‌گرداند. نتیجه را می‌توانید با [IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/) در فایل یا جریان ذخیره کنید. نیازی به رندر شکل حاوی یا برش بیت‌مپ به‌صورت دستی ندارید.

[IParagraph.GetImage](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getimage/) می‌تواند `null` برگرداند اگر پاراگراف در مجموعه والد خود یافت نشود، مرزهای رندر معتبر نداشته باشد یا نتواند رندر شود. پیش از ذخیره‌سازی نتیجه را بررسی کنید و پس از استفاده تصویر بازگردانده‌شده را آزاد کنید.

#### **رندر یک پاراگراف با مقیاس پیش‌فرض**

این مثال از ارائه‌ای با یک اسلاید استفاده می‌کند که اولین شکل آن یک جعبه متن شامل سه پاراگراف است.

![جعبه متن با سه پاراگراف](paragraph_to_image_input.png)

مثال زیر پاراگراف دوم را با شاخص 1 انتخاب می‌کند و بدون پارامترهای مقیاس [IParagraph.GetImage](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getimage/) را صدا می‌زند. این مثال بررسی می‌کند که شکل پاراگراف مورد نیاز را دارد و رندر تصویر را قبل از فراخوانی [IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/) برای ذخیره به فرمت PNG بررسی می‌کند. دستور `using` تصویر را پس از استفاده آزاد می‌کند.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");
var shape = presentation.Slides[0].Shapes[0];

if (shape is IAutoShape textShape && 
    textShape.TextFrame != null && 
    textShape.TextFrame.Paragraphs.Count > 1)
{
    var paragraph = textShape.TextFrame.Paragraphs[1];
    using var paragraphImage = paragraph.GetImage();

    if (paragraphImage != null)
    {
        paragraphImage.Save("paragraph.png", ImageFormat.Png);
    }
    else
    {
        Console.WriteLine("The paragraph could not be rendered.");
    }
}
else
{
    Console.WriteLine("The expected text shape or paragraph was not found.");
}
```

نتیجه:

![تصویر پاراگراف](paragraph_to_image_output.png)

#### **رندر یک پاراگراف در سلول جدول با مقیاس‌بندی**

از بارگذاری [IParagraph.GetImage](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getimage/) که پارامترهای `float scaleX` و `float scaleY` را می‌پذیرند استفاده کنید تا عوامل مقیاس افقی و عمودی را تنظیم کنید. مثال زیر یک جدول ایجاد می‌کند، پاراگراف را در اولین سلول آن با عرض و ارتفاع دو برابر مقدار پیش‌فرض رندر می‌کند و نتیجه را به عنوان تصویر PNG ذخیره می‌کند.

```csharp
using System;
using Aspose.Slides;

var scaleX = 2f;
var scaleY = 2f;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var table = slide.Shapes.AddTable(50, 50, new[] { 300d }, new[] { 80d });
var paragraph = table[0, 0].TextFrame.Paragraphs[0];
paragraph.Text = "Text in a table cell";

using var paragraphImage = paragraph.GetImage(scaleX, scaleY);
if (paragraphImage != null)
{
    paragraphImage.Save("table_paragraph.png", ImageFormat.Png);
}
else
{
    Console.WriteLine("The paragraph could not be rendered.");
}
```

یک عامل مقیاس `1` آن محور را با اندازه پیکسلی پیش‌فرض حفظ می‌کند. به‌عنوان مثال، `2` برای هر دو عامل تصویری با عرض و ارتفاع تقریباً دو برابر ابعاد پیش‌فرض تولید می‌کند که چهار برابر پیکسل دارد. عوامل بزرگ‌تر معمولاً متن واضح‌تری برای بزرگ‌نمایی یا خروجی با وضوح بالا تولید می‌کنند، اما مصرف حافظه و حجم فایل را نیز افزایش می‌دهند. عوامل زیر `1` تصاویر کوچکتری با جزئیات کمتر تولید می‌کنند. برای حفظ نسبت تصویر پاراگراف از عوامل مساوی استفاده کنید؛ عوامل افقی و عمودی متفاوت خروجی را به‌صورت مستقل کشیده می‌کنند.

رندر یک شکل کامل با [IShape.GetImage](https://reference.aspose.com/slides/net/aspose.slides/ishape/getimage/) زمانی مفید است که خروجی باید شامل پر، کمر یا سایر زمینه‌های بصری شکل باشد. برای تصویر فقط پاراگراف، از [IParagraph.GetImage](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getimage/) استفاده کنید.

## **سؤالات متداول**

**آیا می‌توانم به‌طور کامل بسته شدن خط درون یک فریم متن را غیرفعال کنم؟**

بله. مقدار [ITextFrameFormat.WrapText](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/wraptext/) را تنظیم کنید تا بسته شدن غیرفعال شود و خطوط در لبه‌های فریم متن شکست نخورند.

**چگونه می‌توانم محدوده دقیق روی اسلاید یک پاراگراف خاص را به دست آورم؟**

از [IParagraph.GetRect](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getrect/) برای دریافت مستطیل محاطی پاراگراف استفاده کنید. [IPortion.GetRect](https://reference.aspose.com/slides/net/aspose.slides/iportion/getrect/) مرزهای یک بخش منفرد را فراهم می‌کند.

**محل کنترل تراز پاراگراف (چپ، راست، مرکز یا توزیع) کجا است؟**

[IParagraphFormat.Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) یک تنظیم سطح پاراگراف است و بر تمام پاراگراف اعمال می‌شود، صرف‌نظر از قالب‌بندی بخش‌های فردی. برای تراز عمودی بخش‌های مختلف با اندازه‌های قلم متفاوت در هر خط، به [Align Fonts Within a Line](/slides/fa/net/text-formatting/#align-fonts-within-a-line) مراجعه کنید.

**آیا می‌توانم زبان بررسی املای بخشی از یک پاراگراف را تنظیم کنم؟**

بله. مقدار [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/languageid/) را برای بخش‌های منفرد تنظیم کنید، به‌طوری که یک پاراگراف بتواند متن را در چند زبان مختلف داشته باشد.