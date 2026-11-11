---
title: مدیریت متن پاراگراف‌های PowerPoint در .NET
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
- مدیریت بولت
- تورفتگی پاراگراف
- تورفتگی آویز
- بولت پاراگراف
- فهرست شماره‌دار
- فهرست با بولت
- ویژگی‌های پاراگراف
- واردات HTML
- متن به HTML
- پاراگراف به HTML
- پاراگراف به تصویر
- متن به تصویر
- خروجی پاراگراف
- PowerPoint
- ارائه
- .NET
- C#
- Aspose.Slides
description: "نحوه ایجاد و قالب‌بندی پاراگراف‌ها، بخش‌ها، بولت‌ها، فهرست‌های شماره‌دار، تورفتگی‌ها، محتوای HTML و تصاویر پاراگرافی را با Aspose.Slides برای .NET بیاموزید."
---
## **مرور کلی**

Aspose.Slides for .NET متن را به‌صورت یک سلسله‌مراتب از فریم‌های متنی، پاراگراف‌ها و بخش‌ها (Portions) نمایش می‌دهد:

* [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) نمایانگر محفظه متنی در یک شکل است و دسترسی به مجموعه پاراگراف‌های آن را فراهم می‌کند.
* [IParagraph](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/) نمایانگر یک پاراگراف در یک فریم متنی است و دسترسی به بخش‌ها و قالب‌بندی سطح پاراگراف را می‌دهد.
* [IPortion](https://reference.aspose.com/slides/net/aspose.slides/iportion/) نمایانگر یک قسمت متنی داخل پاراگراف است. هر بخش می‌تواند متن و قالب‌بندی کاراکتر خاص خود را داشته باشد.

بنابراین یک پاراگراف می‌تواند متنی با فونت‌ها، رنگ‌ها، اندازه‌ها و قالب‌بندی‌های مختلف داشته باشد که با استفاده از بخش‌های متعدد ایجاد می‌شود.

## **ایجاد و قالب‌بندی پاراگراف‌ها**

پاراگراف‌ها را در فریم متنی یک شکل ایجاد کنید و از بخش‌ها برای قالب‌بندی اجراهای متنی جداگانه استفاده کنید. این بخش نشان می‌دهد چگونه چندین بخش را در هر پاراگراف ترکیب کنید و رنگ‌ها، اندازه‌های فونت و سبک‌های مختلف را اعمال کنید.

### **ایجاد پاراگراف‌ها با چند بخش**

مثال زیر به‌زبان C# سه پاراگراف ایجاد می‌کند که هر کدام شامل سه اجرا (run) متنی در مجموعه [IParagraph.Portions](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/portions/) خود هستند. این مثال پاراگراف پیش‌فرض و بخش خالی آن را بازاستفاده می‌کند، سپس بقیه پاراگراف‌ها و بخش‌ها را اضافه می‌کند. قالب‌بندی از طریق [IPortion.PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iportion/portionformat/) انجام می‌شود: اولین بخش در هر پاراگراف قرمز، بولد و 15 پوینت است؛ دومین بخش آبی، ایتالیک و 18 پوینت؛ بخش سوم قالب‌بندی پیش‌فرض خود را حفظ می‌کند:

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

## **ایجاد فهرست‌های بولت‌دار و عددی**

متن پاراگراف‌ها را به‌صورت فهرست‌های دارای نماد، عدد یا تصاویر سفارشی سازماندهی کنید. مثال‌های این بخش شامل قالب‌بندی بولت، فهرست‌های چندسطحی و مقداردهی اولیه سفارشی به عدد‌ها می‌شود.

### **ایجاد فهرست بولت‌دار یا عددی**

بولت‌ها و شماره‌گذاری باعث می‌شوند موارد مرتبط آسان‌تر اسکن شوند. در Aspose.Slides تنظیمات فهرست از طریق [IBulletFormat](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/) تعریف می‌شود.

این مثال C# یک بولت نمادین و یک مورد عددی را به همان فریم متنی اضافه می‌کند. [IBulletFormat.Type](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/type/) نوع بولت را انتخاب می‌کند، در حالی که [IBulletFormat.Char](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/char/) نماد را فراهم می‌کند و [IBulletFormat.NumberedBulletStyle](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/numberedbulletstyle/) سبک شماره‌گذاری را انتخاب می‌کند. هر دو مورد از بولت‌های سیاه با ارتفاع 100 درصد و تورفتگی پاراگراف 25 پوینت استفاده می‌کنند:

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

### **استفاده از بولت تصویری**

بولت‌های تصویری به شما امکان می‌دهند به‌جای نماد یا عدد از یک تصویر سفارشی استفاده کنید.

این مثال C# یک تصویر را به مجموعه تصاویر ارائه به‌عنوان [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/) اضافه می‌کند و به‌عنوان بولت پاراگراف استفاده می‌کند. [IBulletFormat.Type](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/type/) برای استفاده از بولت تصویری تنظیم می‌شود و تصویر از طریق [IBulletFormat.Picture](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/picture/) اختصاص می‌یابد. [IBulletFormat.Height](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/height/) به 100 درصد تنظیم می‌شود تا اندازه بولت نسبت به متن پاراگراف تنظیم شود:

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

[ IParagraphFormat.Depth](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/depth/) را تنظیم کنید تا پاراگراف‌ها در سطوح مختلف یک فهرست قرار گیرند. سطح بالایی عمق `0` دارد.

این مثال C# مقادیر [IParagraphFormat.Depth](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/depth/) را از 0 تا 3 به چهار پاراگراف اختصاص می‌دهد و یک سلسله‌مراتب در یک فریم متنی ایجاد می‌کند. هر پاراگراف از بولت نمادین استفاده می‌کند؛ [IBulletFormat.Char](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/char/) بین بولت گرد و خط تیره برای تمایز سطوح مجاور می‌چرخد:

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

### **شروع شماره‌گذاری فهرست با مقادیر سفارشی**

از [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/numberedbulletstartwith/) برای تنظیم عدد اولیه نمایش داده‌شده برای پاراگراف عددی استفاده کنید.

این مثال C# [IBulletFormat.Type](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/type/) را برای استفاده از شماره‌گذاری برای سه پاراگراف تنظیم می‌کند و مقادیر [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/numberedbulletstartwith/) را به ترتیب 2، 3 و 7 اختصاص می‌دهد. مقدار شروع برای هر پاراگراف به‌صورت جداگانه پیکربندی می‌شود و اجازه می‌دهد اعداد نمایش داده‌شده مقادیر را رد کنند:

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

## **کنترل چیدمان پاراگراف و ویژگی‌های انتها**

حاشیه‌ها و تورفتگی‌های پاراگراف را تنظیم کنید تا موقعیت اولین خط و خطوط بسته‌شده را کنترل کنید. همچنین می‌توانید علامت انتهای پاراگراف را جدا از بخش‌های متنی قابل مشاهده قالب‌بندی کنید.

### **تنظیم تورفتگی خط اول**

از ویژگی [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) برای کنترل تورفتگی خط اول یک پاراگراف استفاده کنید. این ویژگی فقط خط اول را نسبت به حاشیه چپ پاراگراف جابه‌جا می‌کند. مقدار مثبت خط اول را به سمت راست می‌برد، در حالی که خطوط دیگر در بدنه پاراگراف ثابت می‌مانند.

زمانی که نیاز به جابه‌جایی تمام پاراگراف دارید از [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginleft/) استفاده کنید. زمانیکه فقط خط اول را می‌خواهید جابه‌جا کنید از [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) استفاده کنید.

مثال زیر سه پاراگراف را با همان مقدار [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginleft/) برابر 20 پوینت و مقادیر [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) به ترتیب 0، 20 و 40 پوینت می‌دهد. خطوط اول به طور پیش‌‏پیش افزایش افست شروع می‌شوند، در حالی که خطوط بسته‌شده همان حاشیه چپ را حفظ می‌کنند:

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

### **تنظیم تورفتگی آویزان**

تورفتگی آویزان چیدمانی است که در آن خط اول نسبت به خطوط باقیمانده به‌سمت چپ شروع می‌شود. در Aspose.Slides این اثر را با ویژگی [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) ایجاد می‌کنید. مقدار `Indent` را به عدد منفی تنظیم کنید تا خط اول نسبت به بدنه پاراگراف به‌سمت چپ جابه‌جا شود.

در عمل، [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginleft/) موقعیت چپ بدنه پاراگراف را تعریف می‌کند و [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) موقعیت خط اول را نسبت به آن حاشیه تعیین می‌کند. برای ایجاد تورفتگی آویزان، مقدار `MarginLeft` را مثبت و مقدار `Indent` را منفی تنظیم کنید.

این قالب‌بندی برای کتابشناسی‌ها، مراجع، ورودی‌های واژه‌نامه و سایر پاراگراف‌هایی که خطوط بسته‌شده باید زیر بدنه پاراگراف نه زیر کاراکتر اولین خط قرار گیرند مفید است.

مثال C# زیر مقادیر [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginleft/) برابر 40 و 60 پوینت را با مقادیر [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) برابر -20 و -30 پوینت جفت‌ می‌کند. در هر پاراگراف، خط اول به‌سمت چپ خطوط بسته‌شده شروع می‌شود؛ پاراگراف دوم تورفتگی آویزان عمیق‌تری دارد:

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

![تورفتگی آویزان پاراگراف‌ها](hanging_indent.png)

### **تنظیم ویژگی‌های انتهای پاراگراف**

ویژگی [IParagraph.EndParagraphPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/endparagraphportionformat/) قالب‌بندی علامت انتهای پاراگراف را کنترل می‌کند. مثال زیر یک [PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/portionformat/) با [IBasePortionFormat.FontHeight](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fontheight/) برابر 48 پوینت و [IBasePortionFormat.LatinFont](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/latinfont/) برابر Times New Roman ایجاد می‌کند. این قالب به علامت انتهای پاراگراف دوم اختصاص داده می‌شود، در حالی که بخش‌های متنی قابل مشاهده بدون تغییر می‌مانند:

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

برای قوانین پاراگرافی که بر بسته شدن خودکار و نقطه‌گذاری در انتهای خطوط تأثیر می‌گذارند، به بخش‌های [Control Line Breaking](/slides/fa/net/text-formatting/#control-line-breaking) و [Control Hanging Punctuation](/slides/fa/net/text-formatting/#control-hanging-punctuation) مراجعه کنید.

از [IParagraph.GetLinesCount](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getlinescount/) برای شمارش خطوطی که پاراگراف پس از چیدمان متن اشغال می‌کند (از جمله بسته شدن خودکار) استفاده کنید. این قابلیت هنگام بررسی طول متن و چیدمان در قالب‌های ارائه مفید است.

پاراگراف یک مورد در [ITextFrame.Paragraphs](https://reference.aspose.com/slides/net/aspose.slides/itextframe/paragraphs/) است و می‌تواند چندین خط رندر شده اشغال کند. شکست خط صریح داخل پاراگراف باعث ایجاد خط جدید می‌شود بدون این‌که پاراگراف دیگری ایجاد شود. بسته شدن خودکار خطوط بر اساس عرض موجود ایجاد می‌شود بدون این‌که شکست خط صریح به متن اضافه شود. بنابراین شمارش پاراگراف‌ها یا کاراکترهای شکست خط، تعداد خطوط رندر شده را نمی‌دهد.

مثال زیر یک شکل متنی ایجاد می‌کند، خطوط آن را می‌شمارد، شکل را باریک می‌کند و سپس متن را با رشته کوتاه‌تری جایگزین می‌کند. مثال ویژگی [ITextFrameFormat.WrapText](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/wraptext/) را فعال و [ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/autofittype/) را غیرفعال می‌کند تا عرض شکل کنترل‌کننده بسته شدن باشد بدون اینکه متن به‌صورت خودکار کوچک شود یا شکل تغییر اندازه دهد. هر اندازه‌گیری از [IParagraph.GetLinesCount](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getlinescount/) استفاده می‌کند. ابعاد شکل به پوینت است. در نهایت مثال یک پاراگراف دیگر اضافه می‌کند و مجموع شمارش خطوط را در فریم متنی جمع می‌نماید:

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

با این متن و این ابعاد، باریک‌کردن شکل تعداد خطوط را افزایش می‌دهد، در حالی که جایگزینی متن با رشته کوتاه‌تر آن را کاهش می‌دهد. شمارش دقیق می‌تواند بسته به در دسترس بودن فونت و جایگزینی، اندازه فونت، حاشیه‌ها، تورفتگی، بسته شدن و تنظیمات Autofit متفاوت باشد. هنگام بررسی قالب، از همان فونت‌ها و تنظیمات چیدمان هدف‌مانند استفاده کنید.

تنها شمارش خطوط تعیین‌کننده این نیست که آیا متن از محفظه‌اش فراتر می‌رود یا نه. ارتفاع موجود، ارتفاع خطوط، فاصله‌گذاری پاراگراف و خط و رفتار Autofit نیز مؤثرند؛ حتی یک خط نیز می‌تواند عرض موجود را تجاوز کند وقتی بسته شدن غیرفعال باشد.

## **واردات و صادرات محتوای پاراگراف**

از HTML برای وارد کردن متن به یک ارائه یا صادرات پاراگراف‌های موجود برای استفاده خارج از آن استفاده کنید. این بخش همچنین نشان می‌دهد چطور پاراگراف‌های منفرد را به‌عنوان تصویر رندر کنید، از جمله پاراگراف‌های داخل سلول جدول.

### **وارد کردن متن HTML به پاراگراف‌ها**

از [ParagraphCollection.AddFromHtml](https://reference.aspose.com/slides/net/aspose.slides/paragraphcollection/addfromhtml/) برای تبدیل نشانه‌گذاری HTML به پاراگراف‌ها و بخش‌ها در یک فریم متنی استفاده کنید.

این مثال C# HTML را از یک فایل می‌خواند و نشانه‌گذاری را به [ParagraphCollection.AddFromHtml](https://reference.aspose.com/slides/net/aspose.slides/paragraphcollection/addfromhtml/) می‌سپارد. پاراگراف پیش‌فرض فریم متنی را پاک می‌کند تا فریم فقط شامل محتوای وارد شده باشد. شکل مستطیلی حاشیه 10 پوینت در هر سمت اسلاید ایجاد می‌کند:

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

### **صادرات متن پاراگراف به HTML**

از [ParagraphCollection.ExportToHtml](https://reference.aspose.com/slides/net/aspose.slides/paragraphcollection/exporttohtml/) برای صادرات یک بازهٔ انتخابی از پاراگراف‌ها به HTML استفاده کنید. هنگامی که متن ارائه را در یک وب‌سایت دوباره استفاده می‌کنید، ممکن است بخواهید تاکید محلی را بدون انتقال فونت، اندازه یا سبک‌های جعبهٔ متن حفظ کنید. برای کنترل میزان ارث‌بری قالب‌بندی، [TextToHtmlConversionOptions.TextInheritanceLimit](https://reference.aspose.com/slides/net/aspose.slides.export/texttohtmlconversionoptions/textinheritancelimit/) را تنظیم کنید.

[نمونه ارائه را دانلود کنید](text-inheritance.pptx) و در پوشهٔ کاری برنامه قرار دهید. اسلاید اول آن شامل یک شکل متنی با متن «Inherited text; explicit red 18pt» است. ورودی به‌صراحت چندین سطح قالب‌بندی را استفاده می‌کند:

- سبک متن پیش‌فرض ارائه فونت Calibri و اندازه 28 پوینت را فراهم می‌کند.
- سبک متن سطح اول فریم متنی متن آبی و ایتالیک را فراهم می‌کند.
- پاراگراف به‌صراحت متن بولد تنظیم می‌کند.
- بخش دوم، «explicit red 18pt»، به‌صراحت متن قرمز و اندازه 18 پوینت تنظیم می‌کند.

مثال کامل زیر همان پاراگراف‌ها را سه بار صادر می‌کند. [TextToHtmlConversionOptions](https://reference.aspose.com/slides/net/aspose.slides.export/texttohtmlconversionoptions/) را به متد صادرات می‌فرستد و هر نتیجه را به‌عنوان یک فایل جداگانهٔ HTML UTF‑8 می‌نویسد:

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

HTML تولید شده CSS زیر را برای اولین بخش «Inherited text; » شامل می‌شود. جدول موارد مرتبط را فهرست می‌کند؛ سایر ویژگی‌های تولید شده برای وضوح حذف شده‌اند.

| خروجی | CSS مربوط به اولین بخش | ظاهر |
| --- | --- | --- |
| `All.html` | `font-family:'Calibri'; font-size:28pt; color:#0000ff; font-style:italic; font-weight:bold` | متن آبی، بولد، ایتالیک با اندازهٔ 28 پوینت در Calibri، اگر آن فونت موجود باشد. |
| `TextBox.html` | `color:#0000ff; font-style:italic; font-weight:bold` | متن آبی، بولد، ایتالیک؛ صفحه یا مرورگر فونت و اندازه را فراهم می‌کند. |
| `ParagraphOnly.html` | `font-weight:bold` | متن بولد؛ صفحه یا مرورگر فونت، اندازه، رنگ و سبک ایتالیک را فراهم می‌کند. |

بخش دوم `color:#ff0000`، `font-size:18pt` و `font-weight:bold` را در هر سه خروجی حفظ می‌کند. همچنین ایتالیک در خروجی‌های `All` و `TextBox` باقی می‌ماند ولی در `ParagraphOnly` نیست. محدود کردن ارث‌بری به این دلیل نمی‌شود قالب‌بندی صریحاً به یک پاراگراف یا بخش اختصاص یافته حذف شود.

فایل‌ها را در همان مرورگر باز کنید تا مقایسه کنید. در دو حالت محدود، ویژگی‌های CSS حذف‌شده توسط استایل‌های صفحه مقصد یا پیش‌فرض مرورگر حل می‌شوند، بنابراین ظاهر نهایی به مکانی که HTML استفاده می‌شود بستگی دارد.

### **تولید یک بخش از کلیپ‌بورد HTML**

[AddClipboardFragmentHeader](https://reference.aspose.com/slides/net/aspose.slides.export/texttohtmlconversionoptions/addclipboardfragmentheader/) را برای HTML معمولی `false` و برای شامل شدن سرصفحهٔ کلیپ‌بورد `true` تنظیم کنید. هر دو فراخوانی یک رشته برمی‌گردانند. سرصفحهٔ UTF‑8 بایت‌های `StartHTML` و `EndHTML` و محتویات برای چسباندن `StartFragment` و `EndFragment` را فراهم می‌کند.

این مثال دو پاراگراف قالب‌بندی‌شده را به‌صورت HTML معمولی (`html`) و به‌صورت یک بخش کلیپ‌بورد HTML (`clipboardHtml`) صادر می‌کند. نوشتن بخش به کلیپ‌بورد سیستم یک گام برنامه‌ای جداگانه است. یک API کلیپ‌بورد که بایت‌های HTML خام می‌پذیرد، به UTF‑8 بدون BOM نیاز دارد.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, 400, 100);
var paragraphs = shape.TextFrame.Paragraphs;
paragraphs.Clear();
paragraphs.AddFromHtml("<p>Status: <b>Ready</b></p><p><i>Next steps</i></p>");

var options = new TextToHtmlConversionOptions { AddClipboardFragmentHeader = false };
var html = paragraphs.ExportToHtml(0, paragraphs.Count, options);

options.AddClipboardFragmentHeader = true;
var clipboardHtml = paragraphs.ExportToHtml(0, paragraphs.Count, options);
```

### **رندر یک پاراگراف به عنوان تصویر**

[IParagraph.GetImage](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getimage/) پاراگراف منفرد را مستقیماً رندر می‌کند و یک [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) برمی‌گرداند. نتیجه را با [IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/) به‌صورت فایل یا جریان ذخیره کنید. نیازی به رندر شکل حاوی یا برش دستی بیت‌مپ نیست.

[IParagraph.GetImage](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getimage/) می‌تواند `null` برگرداند اگر پاراگراف در مجموعه والد یافت نشود، مرزهای رندر معتبری نداشته باشد یا نتواند رندر شود. قبل از ذخیره‌سازی نتیجه را بررسی کنید و پس از استفاده تصویر برگشتی را دفع کنید.

#### **رندر پاراگراف با مقیاس پیش‌فرض**

مثال از یک ارائه با یک اسلاید استفاده می‌کند که شکل اول آن یک جعبهٔ متن شامل سه پاراگراف است.

![جعبهٔ متنی با سه پاراگراف](paragraph_to_image_input.png)

مثال زیر پاراگراف دوم را با ایندکس 1 انتخاب می‌کند و بدون پارامترهای مقیاس [IParagraph.GetImage](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getimage/) را فراخوانی می‌کند. بررسی می‌کند که شکل حاوی پاراگراف مورد نیاز است و رندر تصویر را قبل از فراخوانی [IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/) برای ذخیره در قالب PNG تأیید می‌کند. عبارت `using` تصویر را پس از استفاده دفع می‌کند.

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

#### **رندر پاراگراف در سلول جدول با مقیاس‌بندی**

از بارگذاری [IParagraph.GetImage](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getimage/) که پارامترهای `float scaleX` و `float scaleY` را می‌پذیرد برای تنظیم عوامل مقیاس افقی و عمودی استفاده کنید. مثال زیر یک جدول ایجاد می‌کند، پاراگراف را در اولین سلول با دو برابر عرض و ارتفاع پیش‌فرض رندر می‌کند و نتیجه را به‌صورت تصویر PNG ذخیره می‌نماید.

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

عامل مقیاس `1` آن محور را در اندازه پیکسل پیش‌فرض خود نگه می‌دارد. به‌عنوان مثال، `2` برای هر دو عامل تصویری تولید می‌کند که عرض و ارتفاع آن تقریباً دو برابر ابعاد پیش‌فرض است و چهار برابر پیکسل دارد. عوامل بزرگ‌تر معمولاً متن واضح‌تری برای زوم یا خروجی با وضوح بالا می‌دهند، اما مصرف حافظه و حجم فایل را هم افزایش می‌دهند. عوامل کمتر از `1` تصاویر کوچکتری با جزئیات کمتر تولید می‌کنند. برای حفظ نسبت ابعاد پاراگراف از عوامل برابر استفاده کنید؛ عوامل متفاوت افقی و عمودی خروجی را به‌صورت مستقل کش می‌دهند.

رندر کل شکل با [IShape.GetImage](https://reference.aspose.com/slides/net/aspose.slides/ishape/getimage/) زمانی مفید است که خروجی باید شامل پر کردن، مرز یا سایر زمینه‌های بصری شکل باشد. برای تصویر فقط پاراگراف، از [IParagraph.GetImage](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getimage/) استفاده کنید.

## **سوالات متداول**

**آیا می‌توانم تمام بسته شدن خطوط داخل یک فریم متنی را غیرفعال کنم؟**

بله. [ITextFrameFormat.WrapText](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/wraptext/) را تنظیم کنید تا بسته شدن غیرفعال شود و خطوط در لبه‌های فریم متنی شکسته نشوند.

**چگونه می‌توانم دقیقاً محدودهٔ روی اسلاید یک پاراگراف خاص را به‌دست آورم؟**

از [IParagraph.GetRect](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getrect/) برای دریافت مستطیل محدودهٔ پاراگراف استفاده کنید. [IPortion.GetRect](https://reference.aspose.com/slides/net/aspose.slides/iportion/getrect/) محدودهٔ یک بخش منفرد را فراهم می‌کند.

**کنترل ترازبندی پاراگراف (چپ، راست، مرکز یا توجیه) در کجا قرار دارد؟**

[IParagraphFormat.Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) یک تنظیم سطح پاراگراف است و بر کل پاراگراف اعمال می‌شود، صرف‌نظر از قالب‌بندی بخش‌های منفرد.

برای ترازبندی عمودی بخش‌های با اندازهٔ فونت متفاوت در هر خط، به [Align Fonts Within a Line](/slides/fa/net/text-formatting/#align-fonts-within-a-line) مراجعه کنید.

**آیا می‌توانم زبان اصلاح‌گر برای بخشی از یک پاراگراف تنظیم کنم؟**

بله. برای بخش‌های منفرد [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/languageid/) را تنظیم کنید تا یک پاراگراف بتواند متنی به چند زبان مختلف داشته باشد.