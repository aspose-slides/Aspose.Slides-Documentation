---
title: مدیریت پاراگراف‌های متنی پاورپوینت در .NET
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
- فهرست عددی
- فهرست گلوله‌ای
- ویژگی‌های پاراگراف
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
description: "با Aspose.Slides برای .NET بیاموزید چگونه پاراگراف‌ها، بخش‌ها، گلوله‌ها، فهرست‌های عددی، تورفتگی‌ها، محتویات HTML و تصاویر پاراگراف را ایجاد و قالب‌بندی کنید."
---
## **بررسی کلی**

Aspose.Slides برای .NET متن را به صورت سلسله‌مراتبی از فریم‌های متن، پاراگراف‌ها و بخش‌ها (Portions) نمایش می‌دهد:

* [ITextFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/itextframe/) نمایانگر محفظه متن در یک شکل است و دسترسی به مجموعه پاراگراف‌های آن را فراهم می‌کند.
* [IParagraph](https://reference.aspose.com/slides/fa/net/aspose.slides/iparagraph/) نمایانگر یک پاراگراف در فریم متن است و دسترسی به بخش‌ها و قالب‌بندی سطح پاراگراف را می‌دهد.
* [IPortion](https://reference.aspose.com/slides/fa/net/aspose.slides/iportion/) نمایانگر یک بخش متنی داخل پاراگراف است. هر بخش می‌تواند متن و قالب‌بندی کاراکتری مخصوص به خود را داشته باشد.

بنابراین یک پاراگراف می‌تواند متنی با قلم‌ها، رنگ‌ها، اندازه‌ها و قالب‌بندی‌های مختلف داشته باشد که با استفاده از بخش‌های متعدد ایجاد می‌شود.

## **ایجاد و قالب‌بندی پاراگراف‌ها**

### **ایجاد پاراگراف‌ها با چندین بخش**

مراحل زیر یک فریم متن با سه پاراگراف ایجاد می‌کند که هر کدام شامل سه بخش هستند:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) ایجاد کنید.
2. از طریق ایندکس، مرجع اسلاید موردنظر را دریافت کنید.
3. یک [IAutoShape](https://reference.aspose.com/slides/fa/net/aspose.slides/iautoshape/) مستطیلی به اسلاید اضافه کنید.
4. به [ITextFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/itextframe/) شکل دسترسی پیدا کنید.
5. از پاراگراف پیش‌فرض استفاده کنید و دو [IParagraph](https://reference.aspose.com/slides/fa/net/aspose.slides/iparagraph/) دیگر به فریم متن اضافه کنید.
6. به ازای هر پاراگراف به اندازه کافی [IPortion](https://reference.aspose.com/slides/fa/net/aspose.slides/iportion/) اضافه کنید تا شامل سه بخش شود. پاراگراف پیش‌فرض از پیش یک بخش خالی دارد.
7. متن هر بخش را تنظیم کنید.
8. قالب‌بندی کاراکتری را از طریق [IPortion.PortionFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/iportion/portionformat/) اعمال کنید.
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

## **ایجاد فهرست‌های گلوله‌ای و عددی**

### **ایجاد فهرست گلوله‌ای یا عددی**

گلوله‌ها و شماره‌گذاری، موارد مرتبط را اسکن راحت‌تری می‌کند. در Aspose.Slides تنظیمات فهرست از طریق [IBulletFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/ibulletformat/) تعریف می‌شود.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) ایجاد کنید.
2. از طریق ایندکس، مرجع اسلاید موردنظر را دریافت کنید.
3. یک [IAutoShape](https://reference.aspose.com/slides/fa/net/aspose.slides/iautoshape/) به اسلاید انتخاب‌شده اضافه کنید.
4. به [ITextFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/itextframe/) شکل دسترسی پیدا کنید.
5. پاراگراف پیش‌فرض را از فریم متن حذف کنید.
6. برای یک گلوله نمادیک، یک [Paragraph](https://reference.aspose.com/slides/fa/net/aspose.slides/paragraph/) ایجاد کنید.
7. مقدار [IBulletFormat.Type](https://reference.aspose.com/slides/fa/net/aspose.slides/ibulletformat/type/) را به [BulletType.Symbol](https://reference.aspose.com/slides/fa/net/aspose.slides/bullettype/) تنظیم کنید و کاراکتر گلوله را مشخص کنید.
8. متن پاراگراف، تو رفتگی، رنگ گلوله و ارتفاع گلوله را تنظیم کنید.
9. پاراگراف را به فریم متن اضافه کنید.
10. یک پاراگراف دوم ایجاد کنید و مقدار [IBulletFormat.Type](https://reference.aspose.com/slides/fa/net/aspose.slides/ibulletformat/type/) را به [BulletType.Numbered](https://reference.aspose.com/slides/fa/net/aspose.slides/bullettype/) تنظیم کنید.
11. سبک گلوله عددی را پیکربندی کنید و پاراگراف را به فریم متن اضافه کنید.
12. ارائه را ذخیره کنید.

این مثال C# یک گلوله نمادیک و یک گلوله عددی ایجاد می‌کند:

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

### **استفاده از گلوله‌های تصویر**

گلوله‌های تصویر به شما امکان می‌دهند به جای نماد یا عدد، یک تصویر سفارشی استفاده کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) ایجاد کنید.
2. از طریق ایندکس، مرجع اسلاید موردنظر را دریافت کنید.
3. یک [IAutoShape](https://reference.aspose.com/slides/fa/net/aspose.slides/iautoshape/) اضافه کنید و به [ITextFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/itextframe/) آن دسترسی پیدا کنید.
4. پاراگراف پیش‌فرض را از فریم متن حذف کنید.
5. تصویر گلوله را بارگذاری کنید و به مجموعه تصاویر ارائه به عنوان یک [IPPImage](https://reference.aspose.com/slides/fa/net/aspose.slides/ippimage/) اضافه کنید.
6. یک [Paragraph](https://reference.aspose.com/slides/fa/net/aspose.slides/paragraph/) ایجاد کنید و متن آن را تنظیم کنید.
7. مقدار [IBulletFormat.Type](https://reference.aspose.com/slides/fa/net/aspose.slides/ibulletformat/type/) را به [BulletType.Picture](https://reference.aspose.com/slides/fa/net/aspose.slides/bullettype/) تنظیم کنید.
8. تصویر را از طریق [IBulletFormat.Picture](https://reference.aspose.com/slides/fa/net/aspose.slides/ibulletformat/picture/) اختصاص دهید و ارتفاع گلوله را تنظیم کنید.
9. پاراگراف را به فریم متن اضافه کنید.
10. ارائه اصلاح‌شده را ذخیره کنید.

این مثال C# یک گلوله تصویر ایجاد می‌کند:

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

مقدار [IParagraphFormat.Depth](https://reference.aspose.com/slides/fa/net/aspose.slides/iparagraphformat/depth/) را تنظیم کنید تا پاراگراف‌ها در سطوح مختلف فهرست قرار گیرند. سطح بالایی عمق `0` دارد.

1. یک [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) ایجاد کنید و به یک اسلاید دسترسی پیدا کنید.
2. یک [IAutoShape](https://reference.aspose.com/slides/fa/net/aspose.slides/iautoshape/) اضافه کنید و پاراگراف پیش‌فرض را از فریم متن آن پاک کنید.
3. چهار پاراگراف ایجاد کنید و نمادهای گلوله آن‌ها را پیکربندی کنید.
4. مقدارهای [IParagraphFormat.Depth](https://reference.aspose.com/slides/fa/net/aspose.slides/iparagraphformat/depth/) آن‌ها را به ترتیب `0`، `1`، `2` و `3` تنظیم کنید.
5. پاراگراف‌ها را به فریم متن اضافه کنید و ارائه را ذخیره کنید.

این مثال C# یک فهرست چهارسطحی گلوله‌ای ایجاد می‌کند:

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

### **شروع موارد فهرست عددی با مقادیر سفارشی**

از [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/fa/net/aspose.slides/ibulletformat/numberedbulletstartwith/) برای تنظیم عدد اولیه نمایش‌داده‌شده برای یک پاراگراف عددی استفاده کنید.

1. یک [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) ایجاد کنید و یک [IAutoShape](https://reference.aspose.com/slides/fa/net/aspose.slides/iautoshape/) به اسلاید اضافه کنید.
2. پاراگراف پیش‌فرض را از فریم متن شکل پاک کنید.
3. سه پاراگراف عددی ایجاد کنید.
4. برای پاراگراف‌های مربوطه مقادیر [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/fa/net/aspose.slides/ibulletformat/numberedbulletstartwith/) را به ترتیب `2`، `3` و `7` تنظیم کنید.
5. پاراگراف‌ها را به فریم متن اضافه کنید و ارائه را ذخیره کنید.

این مثال C# عدد شروع سفارشی را برای هر پاراگراف اختصاص می‌دهد:

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

از ویژگی [IParagraphFormat.Indent](https://reference.aspose.com/slides/fa/net/aspose.slides/iparagraphformat/indent/) برای کنترل تورفتگی اولین خط پاراگراف استفاده کنید. این ویژگی فقط خط اول را نسبت به حاشیه چپ پاراگراف جابه‌جا می‌کند. مقدار مثبت، خط اول را به سمت راست می‌برد؛ در حالی که خطوط باقی‌مانده ثابت می‌مانند.

وقتی نیاز به جابه‌جایی کل پاراگراف دارید، از [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/fa/net/aspose.slides/iparagraphformat/marginleft/) استفاده کنید. برای جابه‌جایی فقط خط اول، از [IParagraphFormat.Indent](https://reference.aspose.com/slides/fa/net/aspose.slides/iparagraphformat/indent/) استفاده کنید.

مثال زیر چند پاراگراف ایجاد می‌کند و مقادیر مختلف [IParagraphFormat.Indent](https://reference.aspose.com/slides/fa/net/aspose.slides/iparagraphformat/indent/) را اعمال می‌کند تا نشان دهد تورفتگی اولین خط چگونه چیدمان پاراگراف را تحت تأثیر قرار می‌دهد.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) ایجاد کنید.
2. اسلاید هدف را دریافت کنید.
3. یک [IAutoShape](https://reference.aspose.com/slides/fa/net/aspose.slides/iautoshape/) مستطیلی به اسلاید اضافه کنید.
4. به [ITextFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/itextframe/) شکل دسترسی پیدا کنید و پاراگراف پیش‌فرض را حذف کنید.
5. چند پاراگراف ایجاد کنید و مقادیر مختلف [Indent](https://reference.aspose.com/slides/fa/net/aspose.slides/iparagraphformat/indent/) را برای آن‌ها تنظیم کنید.
6. پاراگراف‌ها را به فریم متن اضافه کنید.
7. ارائه اصلاح‌شده را ذخیره کنید.

این کد نشان می‌دهد چگونه تورفتگی پاراگراف تنظیم می‌شود:

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

![تورفتگی اولین خط پاراگراف‌ها](first_line_indent.png)

### **تنظیم تورفتگی معلق**

تورفتگی معلق یک چیدمان پاراگراف است که در آن خط اول به سمت چپ خطوط بعدی قرار می‌گیرد. در Aspose.Slides این اثر را با ویژگی [IParagraphFormat.Indent](https://reference.aspose.com/slides/fa/net/aspose.slides/iparagraphformat/indent/) ایجاد می‌کنید. مقدار `Indent` را به عدد منفی تنظیم کنید تا خط اول نسبت به بدنه پاراگراف به چپ جابه‌جا شود.

در عمل، [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/fa/net/aspose.slides/iparagraphformat/marginleft/) موقعیت چپ بدنه پاراگراف را تعیین می‌کند و [IParagraphFormat.Indent](https://reference.aspose.com/slides/fa/net/aspose.slides/iparagraphformat/indent/) موقعیت خط اول را نسبت به آن حاشیه تعریف می‌کند. برای ایجاد تورفتگی معلق، مقدار مثبت `MarginLeft` و مقدار منفی `Indent` تنظیم کنید.

این قالب‌بندی برای کتابشناسی‌ها، مراجع، واژه‌نامه‌ها و سایر پاراگراف‌هایی که خطوط بسته‌شده باید زیر بدنه پاراگراف نه زیر اولین کاراکتر خط اول قرار گیرند، مفید است.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) ایجاد کنید.
2. اسلاید هدف را دریافت کنید.
3. یک [IAutoShape](https://reference.aspose.com/slides/fa/net/aspose.slides/iautoshape/) مستطیلی به اسلاید اضافه کنید.
4. به [ITextFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/itextframe/) شکل دسترسی پیدا کنید و پاراگراف پیش‌فرض را حذف کنید.
5. برای هر پاراگراف مقدار مثبت [MarginLeft](https://reference.aspose.com/slides/fa/net/aspose.slides/iparagraphformat/marginleft/) تنظیم کنید.
6. مقدار منفی [Indent](https://reference.aspose.com/slides/fa/net/aspose.slides/iparagraphformat/indent/) را برای ایجاد اثر تورفتگی معلق تنظیم کنید.
7. پاراگراف‌ها را به فریم متن اضافه کنید.
8. ارائه اصلاح‌شده را ذخیره کنید.

این کد نشان می‌دهد چطور تورفتگی معلق برای یک پاراگراف تنظیم می‌شود:

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

### **تنظیم ویژگی‌های انتهای پاراگراف**

ویژگی [IParagraph.EndParagraphPortionFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/iparagraph/endparagraphportionformat/) قالب‌بندی علامت پایان پاراگراف را کنترل می‌کند. مثال زیر اندازه فونت و فونت لاتین را برای علامت پایان پاراگراف دوم تنظیم می‌کند:

1. یک [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) بارگیری کنید و به یک اسلاید دسترسی پیدا کنید.
2. یک [IAutoShape](https://reference.aspose.com/slides/fa/net/aspose.slides/iautoshape/) اضافه کنید و پاراگراف پیش‌فرض آن را پاک کنید.
3. دو پاراگراف ایجاد کنید و به آن‌ها بخش‌های متنی اضافه کنید.
4. برای علامت پایان پاراگراف دوم یک [PortionFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/portionformat/) ایجاد کنید.
5. مقدارهای [IBasePortionFormat.FontHeight](https://reference.aspose.com/slides/fa/net/aspose.slides/ibaseportionformat/fontheight/) و [IBasePortionFormat.LatinFont](https://reference.aspose.com/slides/fa/net/aspose.slides/ibaseportionformat/latinfont/) را تنظیم کنید.
6. قالب را به [IParagraph.EndParagraphPortionFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/iparagraph/endparagraphportionformat/) اختصاص دهید و ارائه را ذخیره کنید.

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

## **واردات و صادرات محتوای پاراگراف**

### **وارد کردن متن HTML به پاراگراف‌ها**

از [ParagraphCollection.AddFromHtml](https://reference.aspose.com/slides/fa/net/aspose.slides/paragraphcollection/addfromhtml/) برای تبدیل نشانه‌گذاری HTML به پاراگراف‌ها و بخش‌ها در یک فریم متن استفاده کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) ایجاد کنید.
2. به یک اسلاید دسترسی پیدا کنید و یک [IAutoShape](https://reference.aspose.com/slides/fa/net/aspose.slides/iautoshape/) اضافه کنید.
3. به [ITextFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/itextframe/) شکل دسترسی پیدا کنید و پاراگراف پیش‌فرض را پاک کنید.
4. فایل HTML منبع را بخوانید.
5. رشته HTML را به [ParagraphCollection.AddFromHtml](https://reference.aspose.com/slides/fa/net/aspose.slides/paragraphcollection/addfromhtml/) پاس بدهید.
6. ارائه اصلاح‌شده را ذخیره کنید.

این مثال C# HTML را به یک فریم متن وارد می‌کند:

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

از [ParagraphCollection.ExportToHtml](https://reference.aspose.com/slides/fa/net/aspose.slides/paragraphcollection/exporttohtml/) برای صادرات محدوده‌ای انتخابی از پاراگراف‌ها به HTML استفاده کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) ایجاد کنید و ارائه موردنظر را بارگیری کنید.
2. اسلاید را دریافت کنید و [IAutoShape](https://reference.aspose.com/slides/fa/net/aspose.slides/iautoshape/) حاوی متن را پیدا کنید.
3. به [ITextFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/itextframe/) شکل دسترسی پیدا کنید.
4. با مشخص کردن ایندکس پاراگراف شروع و تعداد پاراگراف‌ها، [ParagraphCollection.ExportToHtml](https://reference.aspose.com/slides/fa/net/aspose.slides/paragraphcollection/exporttohtml/) را فراخوانی کنید.
5. رشته HTML برگردانده‌شده را در فایلی بنویسید.

این مثال C# تمام پاراگراف‌های اولین شکل متنی را экспорт می‌کند:

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

### **رندر یک پاراگراف به عنوان تصویر**

[IParagraph.GetImage](https://reference.aspose.com/slides/fa/net/aspose.slides/iparagraph/getimage/) یک پاراگراف را به‌صورت مستقیم رندر می‌کند و یک [IImage](https://reference.aspose.com/slides/fa/net/aspose.slides/iimage/) برمی‌گرداند. نتیجه را می‌توان با [IImage.Save](https://reference.aspose.com/slides/fa/net/aspose.slides/iimage/save/) در یک فایل یا جریان ذخیره کرد. نیازی به رندر شکل کلی یا برش دستی bitmap نیست.

اگر پاراگراف یافت نشود، هیچ ابعاد رندر معتبری نداشته باشد یا نتواند رندر شود، [IParagraph.GetImage](https://reference.aspose.com/slides/fa/net/aspose.slides/iparagraph/getimage/) می‌تواند `null` برگرداند. قبل از ذخیره نتیجه را بررسی کنید و پس از استفاده تصویر برگردانده‌شده را آزاد کنید.

#### **رندر پاراگراف با مقیاس پیش‌فرض**

فرض کنید فایلی به نام sample.pptx با یک اسلاید داریم که اولین شکل آن یک جعبه متن شامل سه پاراگراف است.

![جعبه متن با سه پاراگراف](paragraph_to_image_input.png)

مثال زیر پاراگراف دوم را در یک شکل متنی معمولی با مقیاس پیش‌فرض رندر می‌کند و تصویر برگردانده‌شده را در قالب PNG ذخیره می‌نماید. عبارت `using` تضمین می‌کند که تصویر به‌درستی آزاد شود.

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

#### **رندر پاراگراف در یک سلول جدول با مقیاس‌بندی**

از بارگذاری [IParagraph.GetImage](https://reference.aspose.com/slides/fa/net/aspose.slides/iparagraph/getimage/) که پارامترهای `float scaleX` و `float scaleY` را می‌پذیرد، برای تنظیم عوامل مقیاس افقی و عمودی استفاده کنید. مثال زیر یک جدول ایجاد می‌کند، پاراگراف را در اولین سلول آن با دو برابر عرض و ارتفاع پیش‌فرض رندر می‌کند و نتیجه را به‌صورت تصویر PNG ذخیره می‌نماید.

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

عامل مقیاس `1` اندازه پیش‌فرض پیکسل را حفظ می‌کند. برای مثال، `2` برای هر دو عامل تصویری تولید می‌کند که عرض و ارتفاع آن تقریباً دو برابر ابعاد پیش‌فرض بوده و چهار برابر پیکسل دارند. عوامل بزرگتر معمولاً متن واضح‌تری برای بزرگ‌نمایی یا خروجی با وضوح بالا می‌دهند، اما مصرف حافظه و اندازه فایل را نیز افزایش می‌دهند. عوامل کمتر از `1` تصاویر کوچکتر با جزئیات کمتر تولید می‌کنند. برای حفظ نسبت ابعاد پاراگراف از عوامل برابر استفاده کنید؛ عوامل متفاوت افقی و عمودی خروجی را به‌صورت مستقل کش می‌دهند.

رندر کلی یک شکل با [IShape.GetImage](https://reference.aspose.com/slides/fa/net/aspose.slides/ishape/getimage/) زمانی مفید است که خروجی نیاز به نمایش پرکن، حاشیه یا سایر زمینه‌های بصری شکل داشته باشد. برای تصویر فقط پاراگراف، از [IParagraph.GetImage](https://reference.aspose.com/slides/fa/net/aspose.slides/iparagraph/getimage/) استفاده کنید.

## **پرسش‌های متداول**

**آیا می‌توانم کاملاً بسته‌بندی خطوط داخل فریم متن را غیرفعال کنم؟**

بله. مقدار [ITextFrameFormat.WrapText](https://reference.aspose.com/slides/fa/net/aspose.slides/itextframeformat/wraptext/) را تنظیم کنید تا بسته‌بندی غیرفعال شود و خطوط در لبه‌های فریم متن شکسته نشوند.

**چگونه می‌توانم مرزهای دقیق روی اسلاید یک پاراگراف خاص را دریافت کنم؟**

از [IParagraph.GetRect](https://reference.aspose.com/slides/fa/net/aspose.slides/iparagraph/getrect/) برای دریافت مستطیل محاطی پاراگراف استفاده کنید. [IPortion.GetRect](https://reference.aspose.com/slides/fa/net/aspose.slides/iportion/getrect/) مرزهای یک بخش منفرد را فراهم می‌کند.

**محل کنترل تراز پاراگراف (چپ، راست، وسط یا تعادل) کجا است؟**

[IParagraphFormat.Alignment](https://reference.aspose.com/slides/fa/net/aspose.slides/iparagraphformat/alignment/) تنظیم سطح پاراگراف است و بر تمام پاراگراف اعمال می‌شود، صرف‌نظر از قالب‌بندی بخش‌های منفرد.

**آیا می‌توانم زبان تصحیح املایی را برای بخشی از پاراگراف تنظیم کنم؟**

بله. مقدار [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/fa/net/aspose.slides/ibaseportionformat/languageid/) را برای بخش‌های منفرد تنظیم کنید تا یک پاراگراف بتواند متنی در چند زبان داشته باشد.