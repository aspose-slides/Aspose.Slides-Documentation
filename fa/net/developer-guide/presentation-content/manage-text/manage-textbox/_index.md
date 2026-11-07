---
title: مدیریت جعبه‌های متن در ارائه‌ها با .NET
linktitle: مدیریت جعبه متن
type: docs
weight: 20
url: /fa/net/manage-textbox/
keywords:
- جعبه متن
- قاب متن
- اضافه کردن متن
- به‌روزرسانی متن
- ایجاد جعبه متن
- بررسی جعبه متن
- افزودن ستون متن
- افزودن پیوند
- PowerPoint
- ارائه
- .NET
- C#
- Aspose.Slides
description: "ایجاد، شناسایی، قالب‌بندی و به‌روزرسانی جعبه‌های متن در ارائه‌های PowerPoint و OpenDocument با استفاده از Aspose.Slides برای .NET."
---
## **مقدمه**

در Aspose.Slides برای .NET، متن اسلاید در چارچوب‌های متنی که به شکل‌ها تعلق دارند ذخیره می‌شود. اینترفیس [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) رایج‌ترین شکل حامل متن را نشان می‌دهد و متن آن را از طریق ویژگی [IAutoShape.TextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/textframe/) در دسترس قرار می‌دهد.

{{% alert color="info" title="Note" %}}
هر شکل خودکار [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) را پیاده‌سازی می‌کند، اما هر شکلی خودکار نیست یا چارچوب متنی پشتیبانی نمی‌کند. هنگام پردازش یک ارائه موجود، قبل از دسترسی به متن، بررسی کنید که شکل `IAutoShape` را پیاده‌سازی می‌کند.
{{% /alert %}}

## **ایجاد یک جعبه متن در اسلاید**

برای ایجاد یک جعبه متن، یک شکل خودکار را به اسلاید اضافه کنید، متن را به چارچوب متنی آن اضافه کنید و ارائه را ذخیره کنید. مثال زیر یک جعبه متن مستطیلی ایجاد می‌کند:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var textBox = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 300, 50);
textBox.AddTextFrame("Aspose TextBox");

presentation.Save("TextBox.pptx", SaveFormat.Pptx);
```

مختصات و ابعاد پاس داده شده به [IShapeCollection.AddAutoShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addautoshape/) بر حسب نقطه‌اند. متد [IAutoShape.AddTextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/addtextframe/) چارچوب متن را با متنی که فراهم می‌کنید مقداردهی اولیه می‌کند.

## **بررسی اینکه یک شکل Text Box است**

از ویژگی [AutoShape.IsTextBox](https://reference.aspose.com/slides/net/aspose.slides/autoshape/istextbox/) برای تعیین اینکه آیا یک شکل خودکار به عنوان جعبه متن در نظر گرفته می‌شود استفاده کنید. این ویژگی زمانی مفید است که یک ارائه شامل هر دو شکل خودکار حامل متن و شکل‌های گرافیکی صرفاً باشد.

![یک جعبه متن و یک شکل](istextbox.png)

مثال زیر هر شکل خودکار را در یک ارائه بررسی می‌کند:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var textBox = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 120, 40);
textBox.AddTextFrame("Text box");
slide.Shapes.AddAutoShape(ShapeType.Ellipse, 150, 10, 40, 40);

foreach (var currentSlide in presentation.Slides)
{
    foreach (var shape in currentSlide.Shapes)
    {
        if (shape is IAutoShape autoShape)
        {
            Console.WriteLine(autoShape.IsTextBox ? "The shape is a text box." : "The shape is not a text box.");
        }
    }
}
```

یک شکل خودکار تازه اضافه‌شده تا زمانی که متن غیر خالی داشته باشد، به عنوان جعبه متن محسوب نمی‌شود. می‌توانید متن را از طریق [IAutoShape.AddTextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/addtextframe/) یا [ITextFrame.Text](https://reference.aspose.com/slides/net/aspose.slides/itextframe/text/) فراهم کنید. افزودن یا اختصاص یک رشته خالی `IsTextBox` را به `false` نگه می‌دارد:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 40);
shape1.AddTextFrame("Shape 1");
Console.WriteLine(shape1.IsTextBox);

var shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 70, 100, 40);
shape2.TextFrame.Text = "Shape 2";
Console.WriteLine(shape2.IsTextBox);

var shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 130, 100, 40);
shape3.AddTextFrame("");
Console.WriteLine(shape3.IsTextBox);

var shape4 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 190, 100, 40);
shape4.TextFrame.Text = "";
Console.WriteLine(shape4.IsTextBox);
```

دو فراخوانی اول `True` چاپ می‌کنند؛ دو فراخوانی آخر `False`.

## **یافتن شکلی که چارچوب متن را دارد**

کدهای عمومی پردازش متن ممکن است یک [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) را دریافت کنند بدون اینکه بدانند کدام شی ارائه آن را شامل می‌شود. از ویژگی فقط‑خواندنی [ITextFrame.ParentShape](https://reference.aspose.com/slides/net/aspose.slides/itextframe/parentshape/) برای بازگشت به [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) مالک استفاده کنید.

برای یک چارچوب متنی که توسط یک شکل خودکار یا شکل دیگری حامل متن مالکیت می‌شود، `ParentShape` شامل صاحب است و [ITextFrame.ParentCell](https://reference.aspose.com/slides/net/aspose.slides/itextframe/parentcell/) مقدار `null` دارد. قبل از دسترسی به مقدار بازگردانده‌شده آن را بررسی کنید. برای شناسایی هر دو صاحب شکل و سلول جدول، شامل شکل‌های مرتبط با گره‌های SmartArt، به [Search and Replace Text](/slides/fa/net/search-and-replace-text/) مراجعه کنید.

## **دریافت مستطیل متن شکل**

از Aspose.Slides برای .NET نسخه 26.11 به بعد، متد [ITextFrame.GetTextRect](https://reference.aspose.com/slides/net/aspose.slides/itextframe/gettextrect/) ناحیه متنی تعریف‌شده توسط هندسه شکل والد را بر می‌گرداند. مختصات و ابعاد آن بر حسب نقطه‌اند و نسبت به گوشه بالای چپ همان شکل هستند. به عنوان مثال، یک بیضی مستطیل متن کوچکتری نسبت به مرزهای بیرونی خود دارد.

این مستطیل توصیف‌کننده شکل است، نه کاراکترهای رندرشده. تغییر متن یا حاشیه‌های چارچوب متن آن را به معیاری برای متن اشغال‌شده تبدیل نمی‌کند. برای اندازه‌گیری متن رندرشده از [paragraph bounds](/slides/fa/net/paragraph-bounds/) یا [portion bounds](/slides/fa/net/portion-bounds/) استفاده کنید.

پس از [installing Aspose.Slides for .NET](/slides/fa/net/installation/) نسخه 26.11 یا بالاتر، این مثال را اجرا کنید تا مستطیل متن هندسی را با رنگ قرمز رسم کنید. شکل‌ها چرخش ندارند و گروه‌بندی نشده‌اند، بنابراین افزودن موقعیت X/Y کافی است تا overlay روی اسلاید قرار گیرد.

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

foreach (var shapeType in new[] { ShapeType.Rectangle, ShapeType.Ellipse })
{
    var x = shapeType == ShapeType.Rectangle ? 50 : 300;
    var shape = slide.Shapes.AddAutoShape(shapeType, x, 200, 200, 100);
    shape.AddTextFrame("Text area");
    var rectangle = shape.TextFrame.GetTextRect();
    Console.WriteLine($"{shapeType}: {rectangle}");

    var overlayX = shape.X + rectangle.X;
    var overlayY = shape.Y + rectangle.Y;
    var outline = slide.Shapes.AddAutoShape(ShapeType.Rectangle, overlayX, overlayY, rectangle.Width, rectangle.Height);
    outline.FillFormat.FillType = FillType.NoFill;
    outline.LineFormat.FillFormat.FillType = FillType.Solid;
    outline.LineFormat.FillFormat.SolidFillColor.Color = Color.Red;
}

presentation.Save("text-rectangles.pptx", SaveFormat.Pptx);
```

برای شکل‌های 200 × 100 نقطه‌ای که در بالا آمده‌اند، مستطیل `(0, 0, 200, 100)` را بر می‌گرداند؛ بیضی تقریباً `(29.289, 14.645, 141.421, 70.711)` بر می‌گرداند. این متد همچنین مستطیل متن اعلام‌شده برای هندسه سفارشی را می‌خواند. چرخش فضای اسلاید یا تبدیل‌های گروهی را اعمال نمی‌کند؛ برای موقعیت‌دهی overlay باید آنها را جداگانه در نظر بگیرید. یک چارچوب متن بدون شکل هندسی، مانند چارچوب متن سلول جدول، می‌تواند `InvalidOperationException` را به‌وجود آورد.

## **افزودن ستون‌ها به یک جعبه متن**

ویژگی [ITextFrameFormat.ColumnCount](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/columncount/) چارچوب متن را به ستون‌ها تقسیم می‌کند، در حالی که [ITextFrameFormat.ColumnSpacing](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/columnspacing/) فاصله بین ستون‌ها را بر حسب نقطه تنظیم می‌کند. هر دو تنظیم متعلق به [ITextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/) هستند و می‌توان از طریق چارچوب متن یک جعبه متن موجود تغییر داد. متن بین ستون‌های داخل همان شکل جریان می‌یابد؛ به شکل دیگری ادامه نمی‌یابد.

مثال زیر یک جعبه متن سه‌ستونه با فاصله 10 نقطه‌ای بین ستون‌ها ایجاد می‌کند، ارائه را ذخیره می‌کند و تنظیمات ذخیره‌شده را از فایل خروجی می‌خواند:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var textBox = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 200);
textBox.AddTextFrame("This text is distributed automatically across all columns in the text box.");

var textFrameFormat = textBox.TextFrame.TextFrameFormat;
textFrameFormat.ColumnCount = 3;
textFrameFormat.ColumnSpacing = 10;

presentation.Save("TextBoxColumns.pptx", SaveFormat.Pptx);

using var savedPresentation = new Presentation("TextBoxColumns.pptx");
var savedTextBox = (IAutoShape)savedPresentation.Slides[0].Shapes[0];
var savedFormat = savedTextBox.TextFrame.TextFrameFormat;
Console.WriteLine($"Columns: {savedFormat.ColumnCount}; spacing: {savedFormat.ColumnSpacing} points");
```

## **استخراج متن از ستون‌های جداگانه**

از [TextFrame.SplitTextByColumns](https://reference.aspose.com/slides/net/aspose.slides/textframe/splittextbycolumns/) برای بازیابی متنی که به هر ستون بصری در یک چارچوب متن موجود اختصاص یافته استفاده کنید. این متد برای هر ستون یک رشته بر می‌گرداند، به ترتیب خواندن بر پایه ستون. یک چارچوب متن تک‌ستونی یک آرایه با یک عنصر تولید می‌کند و ستون خالی با رشته خالی نشان داده می‌شود. رشته‌ها فقط شامل متن ساده هستند؛ قالب‌بندی سطح بخش حفظ نمی‌شود.

این قابلیت زمانی مفید است که بخواهید:

- متن را هنگام حفظ ترتیب خواندن بر پایه ستون استخراج کنید.
- محتوای اسلایدهای چندستونه را فهرست یا مقایسه کنید.
- هر ستون را به فایل، فیلد پایگاه داده یا مقصد دیگری جداگانه صادر کنید.
- بررسی کنید که پس از تغییر [ITextFrameFormat.ColumnCount](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/columncount/)، [ITextFrameFormat.ColumnSpacing](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/columnspacing/)، فونت یا اندازه چارچوب متن، متن چگونه بازتوزیع می‌شود.

این متد متن توزیع‌شده در [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) فعلی را گزارش می‌کند؛ به‌طور خودکار متن را بین شکل‌ها یا جعبه‌های متن جداگانه جریان نمی‌دهد. توزیع ستون می‌تواند به فونت‌های موجود و سایر تنظیمات طرح‌بندی متن وابسته باشد، بنابراین اطمینان حاصل کنید که فونت‌های مورد نیاز هنگام نیاز به نتایج سازگار در دسترس باشند.

مثال زیر یک ارائه را بارگذاری می‌کند، اولین شکل خودکار چندستونی با چارچوب متن را پیدا می‌کند، تعداد ستون‌های پیکربندی‌شده را می‌خواند و متن هر ستون را به یک فایل جداگانه می‌نویسد. شکل‌هایی که چارچوب متنی ندارند نادیده گرفته می‌شوند.

```csharp
using System;
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation("MultiColumnText.pptx");

IAutoShape? textBox = null;
foreach (var shape in presentation.Slides[0].Shapes)
{
    if (shape is IAutoShape autoShape && autoShape.TextFrame is not null)
    {
        var columnCount = autoShape.TextFrame.TextFrameFormat.ColumnCount;
        if (columnCount > 1)
        {
            textBox = autoShape;
            break;
        }
    }
}

if (textBox is null)
{
    Console.WriteLine("No multi-column text frame was found.");
}
else
{
    var textFrame = textBox.TextFrame;
    var configuredColumnCount = textFrame.TextFrameFormat.ColumnCount;
    var columnTexts = textFrame.SplitTextByColumns();

    Console.WriteLine($"Configured columns: {configuredColumnCount}");

    for (var columnIndex = 0; columnIndex < columnTexts.Length; columnIndex++)
    {
        var columnNumber = columnIndex + 1;
        var columnText = columnTexts[columnIndex];
        Console.WriteLine($"Column {columnNumber}: {columnText}");
        File.WriteAllText($"Column-{columnNumber}.txt", columnText);
    }
}
```

## **به‌روزرسانی متن**

برای به‌روزرسانی متن در سراسر یک ارائه، اسلایدها و شکل‌ها را پیمایشی کنید، شکل‌های خودکار را انتخاب کنید و سپس بخش‌های متنی آن‌ها را ویرایش کنید. کار بر سطح بخش به شما اجازه می‌دهد هم متن و هم قالب‌بندی کاراکترها را تغییر دهید.

مثال زیر هر رخداد `years` را در متن شکل‌های خودکار با `months` جایگزین می‌کند و هر بخش تأثیر‌گذاری‌شده را بولد می‌نماید:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Text.pptx");

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape is not IAutoShape autoShape)
        {
            continue;
        }

        foreach (var paragraph in autoShape.TextFrame.Paragraphs)
        {
            foreach (var portion in paragraph.Portions)
            {
                portion.Text = portion.Text.Replace("years", "months");
                portion.PortionFormat.FontBold = NullableBool.True;
            }
        }
    }
}

presentation.Save("TextChanged.pptx", SaveFormat.Pptx);
```

این پیمایش فقط متن در شکل‌های خودکار را به‌روزرسانی می‌کند. متنی که در جداول، نمودارها، SmartArt یا شکل‌های گروهی ذخیره شده است، نیاز به پیمایش مجموعه‌های خود آن اشیاء دارد.

## **افزودن یک جعبه متن با پیوند**

یک پیوند می‌تواند به بخش متنی مشخصی اختصاص یابد، به‌طوری که فقط آن متن به عنوان پیوند قابل کلیک باشد. از [IHyperlinkManager.SetExternalHyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/setexternalhyperlinkclick/) برای ارتباط بخش با یک URL خارجی استفاده کنید.

مثال زیر متن پیوندی ایجاد می‌کند و آن را در یک ارائه ذخیره می‌نماید:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var textBox = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 150, 200, 50);
textBox.AddTextFrame("Aspose.Slides");

var textPortion = textBox.TextFrame.Paragraphs[0].Portions[0];
textPortion.PortionFormat.HyperlinkManager.SetExternalHyperlinkClick("https://www.aspose.com/");

presentation.Save("Hyperlink.pptx", SaveFormat.Pptx);
```

## **پرسش‌های متداول**

**تفاوت جعبه متن با placeholder متن در اسلاید master یا layout چیست؟**

یک [placeholder](/slides/fa/net/manage-placeholder/) می‌تواند موقعیت و قالب‌بندی خود را از یک [master slide](https://reference.aspose.com/slides/net/aspose.slides/masterslide/) یا [layout slide](https://reference.aspose.com/slides/net/aspose.slides/layoutslide/) ارث‌بگیرد. یک جعبه متن معمولی یک شکل مستقل در اسلایدی است که در آن ایجاد شده و هنگام تغییر طرح، رفتار placeholder را دریافت نمی‌کند.

**چگونه می‌توان متن را بدون تغییر متن در نمودارها، جداول یا SmartArt جایگزین کرد؟**

پیمایش را به شکل‌هایی که [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) را پیاده‌سازی می‌کنند محدود کنید، همان‌طور که در مثال به‌روزرسانی متن نشان داده شد. نمودارها، جداول و SmartArt متن خود را در مدل‌های شیء خود ذخیره می‌کنند، بنابراین توسط این حلقه تغییر نمی‌یابند.