---
title: مدیریت پاراگراف‌های متن پاورپوینت در .NET
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
- تورفتگی معلق
- بولت پاراگراف
- فهرست شماره‌دار
- فهرست بولت‌دار
- ویژگی‌های پاراگراف
- وارد کردن HTML
- متن به HTML
- پاراگراف به HTML
- پاراگراف به تصویر
- متن به تصویر
- خروجی پاراگراف
- پاورپوینت
- ارائه
- .NET
- C#
- Aspose.Slides
description: "یاد بگیرید چگونه پاراگراف‌ها، بخش‌ها، بولت‌ها، فهرست‌های شماره‌دار، تورفتگی‌ها، محتوای HTML و تصاویر پاراگراف را با Aspose.Slides برای .NET ایجاد و قالب‌بندی کنید."
---
## **بررسی کلی**

Aspose.Slides for .NET متن را به صورت یک سلسله‌مراتبی از قاب‌های متن، پاراگراف‌ها و بخش‌ها نمایش می‌دهد:

* [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) نمایانگر محفظه متن در یک شکل است و دسترسی به مجموعه پاراگراف‌های آن را فراهم می‌کند.
* [IParagraph](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/) نمایانگر یک پاراگراف در یک قاب متن است و دسترسی به بخش‌ها و قالب‌بندی سطح پاراگراف را می‌دهد.
* [IPortion](https://reference.aspose.com/slides/net/aspose.slides/iportion/) نمایانگر یک بخش متن درون یک پاراگراف است. هر بخش می‌تواند متن و قالب‌بندی سطح کاراکتر خود را داشته باشد.

بنابراین یک پاراگراف می‌تواند متن با قلم‌ها، رنگ‌ها، اندازه‌ها و سایر قالب‌بندی‌های مختلف را با استفاده از چندین بخش شامل شود.

## **ایجاد و قالب‌بندی پاراگراف‌ها**

### **ایجاد پاراگراف‌ها با بخش‌های متعدد**

مراحل زیر یک قاب متن با سه پاراگراف، هر کدام شامل سه بخش، ایجاد می‌کند:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) ایجاد کنید.
2. مرجع اسلاید موردنظر را از طریق ایندکس آن دسترسی پیدا کنید.
3. یک [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) مستطیلی به اسلاید اضافه کنید.
4. به [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) شکل دسترسی پیدا کنید.
5. از پاراگراف پیش‌فرض استفاده کنید و دو شیء [IParagraph](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/) دیگر به قاب متن اضافه کنید.
6. برای هر پاراگراف به اندازه کافی شیء [IPortion](https://reference.aspose.com/slides/net/aspose.slides/iportion/) اضافه کنید تا سه بخش داشته باشد. پاراگراف پیش‌فرض در حال حاضر یک بخش خالی دارد.
7. متن هر بخش را تنظیم کنید.
8. قالب‌بندی سطح کاراکتر را از طریق [IPortion.PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iportion/portionformat/) اعمال کنید.
9. ارائه اصلاح‌شده را ذخیره کنید.

این مثال C# مراحل را پیاده‌سازی می‌کند:

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

## **ایجاد فهرست‌های بولت‌دار و شماره‌دار**

### **ایجاد فهرست بولت‌دار یا شماره‌دار**

بولت‌ها و شماره‌گذاری موارد مرتبط را برای اسکن آسان‌تر می‌کنند. در Aspose.Slides تنظیمات فهرست از طریق [IBulletFormat](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/) تعریف می‌شود.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) ایجاد کنید.
2. مرجع اسلاید موردنظر را از طریق ایندکس آن دسترسی پیدا کنید.
3. یک [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) به اسلاید انتخاب‌شده اضافه کنید.
4. به [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) شکل دسترسی پیدا کنید.
5. پاراگراف پیش‌فرض را از قاب متن حذف کنید.
6. یک [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph/) برای بولت نماد ایجاد کنید.
7. [IBulletFormat.Type](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/type/) را به [BulletType.Symbol](https://reference.aspose.com/slides/net/aspose.slides/bullettype/) تنظیم کنید و کاراکتر بولت را مشخص کنید.
8. متن پاراگراف، تورفتگی، رنگ بولت و ارتفاع بولت را تنظیم کنید.
9. پاراگراف را به قاب متن اضافه کنید.
10. پاراگراف دوم را ایجاد کنید و [IBulletFormat.Type](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/type/) را به [BulletType.Numbered](https://reference.aspose.com/slides/net/aspose.slides/bullettype/) تنظیم کنید.
11. سبک بولت شماره‌دار را پیکربندی کنید و پاراگراف را به قاب متن اضافه کنید.
12. ارائه را ذخیره کنید.

این مثال C# یک بولت نماد و یک بولت شماره‌دار ایجاد می‌کند:

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

### **استفاده از بولت تصویر**

بولت‌های تصویری به شما امکان می‌دهند به جای نماد یا عدد از یک تصویر سفارشی استفاده کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) ایجاد کنید.
2. مرجع اسلاید موردنظر را از طریق ایندکس آن دسترسی پیدا کنید.
3. یک [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) اضافه کنید و به [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) آن دسترسی پیدا کنید.
4. پاراگراف پیش‌فرض را از قاب متن حذف کنید.
5. تصویر بولت را بارگیری کنید و به مجموعه تصویرهای ارائه به‌عنوان یک [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/) اضافه کنید.
6. یک [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph/) ایجاد کنید و متن آن را تنظیم کنید.
7. [IBulletFormat.Type](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/type/) را به [BulletType.Picture](https://reference.aspose.com/slides/net/aspose.slides/bullettype/) تنظیم کنید.
8. تصویر را از طریق [IBulletFormat.Picture](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/picture/) اختصاص دهید و ارتفاع بولت را تنظیم کنید.
9. پاراگراف را به قاب متن اضافه کنید.
10. ارائه اصلاح‌شده را ذخیره کنید.

این مثال C# یک بولت تصویری ایجاد می‌کند:

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

[ IParagraphFormat.Depth](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/depth/) را تنظیم کنید تا پاراگراف‌ها در سطوح مختلف یک فهرست قرار گیرند. سطح بالایی دارای عمق `0` است.

1. یک [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) ایجاد کنید و به یک اسلاید دسترسی پیدا کنید.
2. یک [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) اضافه کنید و پاراگراف پیش‌فرض را از قاب متن آن پاک کنید.
3. چهار پاراگراف ایجاد کنید و نمادهای بولت آن‌ها را پیکربندی کنید.
4. مقدارهای [IParagraphFormat.Depth](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/depth/) آن‌ها را به ترتیب `0`، `1`، `2` و `3` تنظیم کنید.
5. پاراگراف‌ها را به قاب متن اضافه کنید و ارائه را ذخیره کنید.

این مثال C# فهرست بولت‌دار چهار سطحی ایجاد می‌کند:

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

### **شروع موارد فهرست شماره‌دار با مقادیر دلخواه**

از [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/numberedbulletstartwith/) برای تعیین عدد اولیه نمایش داده‌شده برای یک پاراگراف شماره‌دار استفاده کنید.

1. یک [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) ایجاد کنید و یک [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) به اسلاید اضافه کنید.
2. پاراگراف پیش‌فرض را از قاب متن شکل پاک کنید.
3. سه پاراگراف شماره‌دار ایجاد کنید.
4. برای هر پاراگراف [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/numberedbulletstartwith/) را به ترتیب به `2`، `3` و `7` تنظیم کنید.
5. پاراگراف‌ها را به قاب متن اضافه کنید و ارائه را ذخیره کنید.

این مثال C# عدد شروع سفارشی را به هر پاراگراف اختصاص می‌دهد:

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

## **کنترل چیدمان پاراگراف و ویژگی‌های انتهایی**

### **تنظیم تورفتگی اولین خط**

از ویژگی [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) برای کنترل تورفتگی اولین خط یک پاراگراف استفاده کنید. این ویژگی فقط خط اول را نسبت به حاشیه چپ پاراگراف جابه‌جا می‌کند. مقدار مثبت اولین خط را به سمت راست می‌برد، در حالی که خطوط باقی‌مانده در جای خود باقی می‌مانند.

زمانی که نیاز به جابه‌جایی کل پاراگراف دارید از [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginleft/) استفاده کنید. وقتی فقط اولین خط را می‌خواهید جابه‌جا کنید، از [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) استفاده کنید.

مثال زیر چند پاراگراف ایجاد می‌کند و مقادیر مختلف [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) را برای نشان دادن اثر تورفتگی اولین خط بر چیدمان پاراگراف اعمال می‌کند.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) ایجاد کنید.
2. اسلاید هدف را دسترسی پیدا کنید.
3. یک [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) مستطیلی به اسلاید اضافه کنید.
4. به [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) شکل دسترسی پیدا کنید و پاراگراف پیش‌فرض را حذف کنید.
5. چند پاراگراف ایجاد کنید و مقادیر مختلف [Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) را برای آن‌ها تنظیم کنید.
6. پاراگراف‌ها را به قاب متن اضافه کنید.
7. ارائه اصلاح‌شده را ذخیره کنید.

این کد نحوه تنظیم تورفتگی پاراگراف را نشان می‌دهد:

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

تورفتگی معلق یک چیدمان پاراگراف است که در آن خط اول به سمت چپ خطوط باقی‌مانده شروع می‌شود. در Aspose.Slides این اثر را با ویژگی [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) ایجاد می‌کنید. مقدار `Indent` را به مقدار منفی تنظیم کنید تا خط اول نسبت به بدنه پاراگراف به سمت چپ جابه‌جا شود.

در عمل، [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginleft/) موقعیت چپ بدنه پاراگراف را تعریف می‌کند و [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) موقعیت خط اول را نسبت به آن حاشیه تنظیم می‌کند. برای ایجاد تورفتگی معلق، مقدار `MarginLeft` را مثبت و مقدار `Indent` را منفی تنظیم کنید.

این قالب‌بندی برای کتاب‌شناسی‌ها، مراجع، واژگان و سایر پاراگراف‌هایی که خطوط بسته‌بندی‌شده باید زیر بدنه پاراگراف نه زیر اولین کاراکتر خط اول هم‌راستا شوند مفید است.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) ایجاد کنید.
2. اسلاید هدف را دسترسی پیدا کنید.
3. یک [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) مستطیلی به اسلاید اضافه کنید.
4. به [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) شکل دسترسی پیدا کنید و پاراگراف پیش‌فرض را حذف کنید.
5. پاراگراف‌ها ایجاد کنید و برای هرکدام مقدار مثبت [MarginLeft](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginleft/) تنظیم کنید.
6. مقدار منفی [Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) تنظیم کنید تا اثر تورفتگی معلق ایجاد شود.
7. پاراگراف‌ها را به قاب متن اضافه کنید.
8. ارائه اصلاح‌شده را ذخیره کنید.

این کد نحوه تنظیم تورفتگی معلق برای یک پاراگراف را نشان می‌دهد:

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

### **تنظیم ویژگی‌های انتهایی پاراگراف**

ویژگی [IParagraph.EndParagraphPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/endparagraphportionformat/) قالب‌بندی علامت انتهای پاراگراف را کنترل می‌کند. مثال زیر اندازه قلم و قلم لاتین را به علامت انتهای پاراگراف دوم اختصاص می‌دهد:

1. یک [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) بارگذاری کنید و به یک اسلاید دسترسی پیدا کنید.
2. یک [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) اضافه کنید و پاراگراف پیش‌فرض آن را پاک کنید.
3. دو پاراگراف ایجاد کنید و به آن‌ها بخش‌های متنی اضافه کنید.
4. برای علامت انتهای پاراگراف دوم یک [PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/portionformat/) ایجاد کنید.
5. [IBasePortionFormat.FontHeight](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fontheight/) و [IBasePortionFormat.LatinFont](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/latinfont/) را تنظیم کنید.
6. قالب را به [IParagraph.EndParagraphPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/endparagraphportionformat/) اختصاص دهید و ارائه را ذخیره کنید.

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

برای قوانین پاراگرافی که بر بسته‌بندی خودکار و نقطه‌گذاری در انتهای خطوط تأثیر می‌گذارند، به بخش‌های [Control Line Breaking](/slides/fa/net/text-formatting/#control-line-breaking) و [Control Hanging Punctuation](/slides/fa/net/text-formatting/#control-hanging-punctuation) مراجعه کنید.

از [IParagraph.GetLinesCount](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getlinescount/) برای شمارش خطوطی که یک پاراگراف پس از چیدمان متن اشغال می‌کند، از جمله بسته‌بندی خودکار استفاده کنید. این قابلیت هنگام بررسی طول متن و چیدمان در قالب‌های ارائه مفید است.

یک پاراگراف یکی از آیتم‌های [ITextFrame.Paragraphs](https://reference.aspose.com/slides/net/aspose.slides/itextframe/paragraphs/) است و می‌تواند چندین خط رندر شده داشته باشد. یک شکست خط صریح داخل یک پاراگراف یک خط جدید ایجاد می‌کند بدون اینکه پاراگراف جدیدی ساخته شود. بسته‌بندی خودکار خطوط را بر اساس عرض موجود تولید می‌کند بدون اینکه شکست‌های خط صریح به متن افزوده شود. بنابراین شمارش پاراگراف‌ها یا کاراکترهای شکست خط، شمارش خطوط رندر شده را نمی‌دهد.

مثال زیر یک شکل متنی ایجاد می‌کند، خطوط آن را می‌شمارد، شکل را باریک می‌کند و سپس متن را با رشته کوتاه‌تری جایگزین می‌کند. بسته‌بندی فعال است و AutoFit غیرفعال شده تا عرض شکل کنترل بسته‌بندی را بدون کوچک‌کردن خودکار متن یا تغییر اندازه شکل بر عهده گیرد. ابعاد شکل بر حسب نقطه (pt) است. در نهایت، مثال یک پاراگراف دیگر اضافه می‌کند و مجموع شمارش خطوط را در کل قاب متن محاسبه می‌کند.

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

با این متن و این ابعاد، باریک کردن شکل تعداد خطوط را افزایش می‌دهد، در حالی که جایگزینی متن با رشته کوتاه شمارش را کاهش می‌دهد. شمارش دقیق می‌تواند بسته به در دسترس بودن قلم‌ها و جایگزینی، اندازه قلم، حاشیه‌ها، تورفتگی، بسته‌بندی و تنظیمات AutoFit متفاوت باشد. هنگام بررسی قالب، از قلم‌ها و تنظیمات چیدمان موردنظر برای محیط هدف استفاده کنید.

تنها شمارش خطوط تعیین‌کنندهٔ خروجی متن از محفظه نیست. ارتفاع موجود، ارتفاع خطوط، فاصله‌های پاراگراف و خط، و رفتار AutoFit نیز مهم‌اند؛ حتی یک خط واحد می‌تواند عرض موجود را در صورت غیرفعال بودن بسته‌بندی تجاوز کند.

## **واردات و صادرات محتوای پاراگراف**

### **وارد کردن متن HTML به پاراگراف‌ها**

از [ParagraphCollection.AddFromHtml](https://reference.aspose.com/slides/net/aspose.slides/paragraphcollection/addfromhtml/) برای تبدیل نشانه‌گذاری HTML به پاراگراف‌ها و بخش‌ها در یک قاب متن استفاده کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) ایجاد کنید.
2. به یک اسلاید دسترسی پیدا کنید و یک [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) اضافه کنید.
3. به [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) شکل دسترسی پیدا کنید و پاراگراف پیش‌فرض آن را پاک کنید.
4. فایل HTML منبع را بخوانید.
5. رشته HTML را به [ParagraphCollection.AddFromHtml](https://reference.aspose.com/slides/net/aspose.slides/paragraphcollection/addfromhtml/) پاس دهید.
6. ارائه اصلاح‌شده را ذخیره کنید.

این مثال C# HTML را به یک قاب متن وارد می‌کند:

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

از [ParagraphCollection.ExportToHtml](https://reference.aspose.com/slides/net/aspose.slides/paragraphcollection/exporttohtml/) برای صادرات یک محدوده انتخابی از پاراگراف‌ها به قالب HTML استفاده کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) ایجاد کنید و ارائه موردنظر را بارگذاری کنید.
2. به اسلاید دسترسی پیدا کنید و [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) حاوی متن را پیدا کنید.
3. به [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) شکل دسترسی پیدا کنید.
4. با استفاده از [ParagraphCollection.ExportToHtml](https://reference.aspose.com/slides/net/aspose.slides/paragraphcollection/exporttohtml/) شاخص پاراگراف اولیه و تعداد پاراگراف‌های موردنظر برای صادرات را مشخص کنید.
5. رشته HTML بازگردانده‌شده را در یک فایل بنویسید.

این مثال C# تمام پاراگراف‌های اولین شکل متنی را صادر می‌کند:

```csharp
using System;
using System.IO;
using System.Text;
using Aspose.Slides;

using var presentation = new Presentation("ExportingHTMLText.pptx");
var shape = presentation.Slides[0].Shapes[0];

if (shape is IAutoShape textShape && textShape.TextFrame != null)
{
    var paragraphs = textShape.TextFrame.Paragraphs;
    var html = paragraphs.ExportToHtml(0, paragraphs.Count, null);
    using var writer = new StreamWriter("paragraphs.html", false, Encoding.UTF8);
    writer.Write(html);
}
else
{
    Console.WriteLine("The first shape is not a text shape.");
}
```

### **رندر کردن یک پاراگراف به عنوان تصویر**

[IParagraph.GetImage](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getimage/) یک پاراگراف منفرد را به‌طور مستقیم رندر می‌کند و یک [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) باز می‌گرداند. نتیجه را با [IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/) در یک فایل یا جریان ذخیره کنید؛ نیازی به رندر کردن شکل حامل یا برش دستی بیت‌مپ نیست.

[IParagraph.GetImage](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getimage/) می‌تواند `null` برگرداند اگر پاراگراف در مجموعه والد یافت نشود، مرزهای رندر معتبری نداشته باشد یا امکان رندر شدن نداشته باشد. قبل از ذخیره‌سازی نتیجه را بررسی کنید و پس از استفاده تصویر بازگشتی را آزاد کنید.

#### **رندر کردن پاراگراف با مقیاس پیش‌فرض**

فرض کنید فایل ارائه‌ای به نام sample.pptx داریم که شامل یک اسلاید است و اولین شکل آن یک جعبه متن با سه پاراگراف است.

![جعبه متن با سه پاراگراف](paragraph_to_image_input.png)

مثال زیر پاراگراف دوم را در یک شکل متنی عادی با مقیاس پیش‌فرض رندر می‌کند و تصویر بازگشت‌داده‌شده را در قالب PNG ذخیره می‌نماید. اعلان `using` اطمینان می‌دهد که تصویر به‌درستی آزاد شود.

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

#### **رندر کردن پاراگراف در یک سلول جدول با مقیاس‌بندی**

از بارگذاری [IParagraph.GetImage](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getimage/) که پارامترهای `float scaleX` و `float scaleY` را می‌پذیرد استفاده کنید تا عوامل مقیاس افقی و عمودی را تنظیم کنید. مثال زیر یک جدول ایجاد می‌کند، پاراگراف را در اولین سلول آن با دو برابر عرض و ارتفاع پیش‌فرض رندر می‌کند و نتیجه را به‌صورت تصویر PNG ذخیره می‌نماید.

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

عامل مقیاس `1` آن محور را در اندازه پیش‌فرض پیکسل نگه می‌دارد. به عنوان مثال، مقدار `2` برای هر دو عامل تصویری تولید می‌کند که عرض و ارتفاع آن تقریباً دو برابر ابعاد پیش‌فرض است، که منجر به چهار برابر پیکسل می‌شود. عوامل بزرگتر معمولاً متن شفاف‌تری برای زوم یا خروجی با وضوح بالا تولید می‌کنند، اما استفاده از حافظه و اندازه فایل را نیز افزایش می‌دهند. عوامل زیر `1` تصاویر کوچکتر با جزئیات کمتر ایجاد می‌کنند. برای حفظ نسبت تصویر پاراگراف از عوامل برابر استفاده کنید؛ عوامل افقی و عمودی متفاوت تصویر را به‌صورت مستقل کش می‌دهند.

رندر کردن کل یک شکل با [IShape.GetImage](https://reference.aspose.com/slides/net/aspose.slides/ishape/getimage/) زمانی مفید است که خروجی نیاز به شامل پرکردگی، مرز یا سایر زمینه‌های بصری شکل داشته باشد. برای تصویر تنها شامل پاراگراف، از [IParagraph.GetImage](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getimage/) استفاده کنید.

## **سوالات متداول**

**آیا می‌توانم بسته‌بندی خطوط داخل یک قاب متن را به‌طور کامل غیرفعال کنم؟**

بله. ویژگی [ITextFrameFormat.WrapText](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/wraptext/) را برای غیرفعال‌سازی بسته‌بندی تنظیم کنید تا خطوط در لبه‌های قاب متن شکسته نشوند.

**چگونه می‌توانم مرزهای دقیق روی اسلاید یک پاراگراف خاص را دریافت کنم؟**

از [IParagraph.GetRect](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getrect/) برای دریافت مستطیل محدودکننده پاراگراف استفاده کنید. [IPortion.GetRect](https://reference.aspose.com/slides/net/aspose.slides/iportion/getrect/) مرزهای یک بخش منفرد را فراهم می‌کند.

**کنترل تراز پاراگراف (چپ، راست، وسط یا توجیه) کجا انجام می‌شود؟**

[IParagraphFormat.Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) یک تنظیم سطح پاراگراف است و بر کل پاراگراف اعمال می‌شود بدون در نظر گرفتن قالب‌بندی بخش‌های منفرد.

برای تراز عمودی بخش‌های با اندازه‌های قلم مختلف در هر خط، به [Align Fonts Within a Line](/slides/fa/net/text-formatting/#align-fonts-within-a-line) مراجعه کنید.

**آیا می‌توانم زبان تصحیح املای بخشی از یک پاراگراف را تنظیم کنم؟**

بله. برای بخش‌های منفرد [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/languageid/) تنظیم کنید تا یک پاراگراف بتواند متنی به چند زبان مختلف داشته باشد.