---
title: مدیریت جعبه‌های متن در ارائه‌ها با .NET
linktitle: مدیریت جعبه متن
type: docs
weight: 20
url: /fa/net/manage-textbox/
keywords:
- جعبه متن
- چارچوب متن
- افزودن متن
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
## **معرفی**

در Aspose.Slides برای .NET، متن اسلاید در چارچوب‌های متنی (text frames) که به شکل‌ها (shapes) تعلق دارند، ذخیره می‌شود. رابط [IAutoShape](https://reference.aspose.com/slides/fa/net/aspose.slides/iautoshape/) متداول‌ترین شکل حامل متن را نمایان می‌سازد و متن آن را از طریق ویژگی [IAutoShape.TextFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/iautoshape/textframe/) در دسترس قرار می‌دهد.

{{% alert color="info" title="نکته" %}}

هر شکل خودکار، [IShape](https://reference.aspose.com/slides/fa/net/aspose.slides/ishape/) را پیاده‌سازی می‌کند، اما هر شکل خودکار نیست یا چارچوب متن ندارد. هنگام پردازش یک ارائه موجود، قبل از دسترسی به متن، بررسی کنید که شکل پیاده‌سازی `IAutoShape` را داشته باشد.

{{% /alert %}}

## **ایجاد یک جعبه متن در اسلاید**

برای ایجاد یک جعبه متن، یک شکل خودکار به اسلاید اضافه کنید، متن را به چارچوب متن آن اضافه کنید و ارائه را ذخیره کنید. مثال زیر یک جعبه متن مستطیلی ایجاد می‌کند:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var textBox = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 300, 50);
textBox.AddTextFrame("Aspose TextBox");

presentation.Save("TextBox.pptx", SaveFormat.Pptx);
```

مختصات و ابعادی که به متد [IShapeCollection.AddAutoShape](https://reference.aspose.com/slides/fa/net/aspose.slides/ishapecollection/addautoshape/) ارسال می‌شوند، بر حسب پوینت‌اند. متد [IAutoShape.AddTextFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/iautoshape/addtextframe/) چارچوب متن را با متن فراهم‌شده مقداردهی اولیه می‌کند.

## **بررسی یک شکل جعبه متن**

از ویژگی [AutoShape.IsTextBox](https://reference.aspose.com/slides/fa/net/aspose.slides/autoshape/istextbox/) استفاده کنید تا تعیین کنید آیا یک شکل خودکار به عنوان جعبه متن در نظر گرفته می‌شود یا نه. این ویژگی زمانی مفید است که ارائه شامل هر دو شکل خودکار متن‌دار و صرفاً گرافیکی باشد.

![A text box and a shape](istextbox.png)

مثال زیر تمام اشکال خودکار موجود در یک ارائه را بررسی می‌کند:

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

یک شکل خودکار تازه اضافه‌شده تا زمانی که متن غیر خالی داشته باشد، به عنوان جعبه متن شناخته نمی‌شود. می‌توانید آن متن را از طریق [IAutoShape.AddTextFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/iautoshape/addtextframe/) یا [ITextFrame.Text](https://reference.aspose.com/slides/fa/net/aspose.slides/itextframe/text/) فراهم کنید. افزودن یا اختصاص یک رشته خالی مقدار `IsTextBox` را روی `false` می‌گذارد:

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

## **یافتن شکل مالک چارچوب متن**

کدهای عمومی پردازش متن ممکن است یک [ITextFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/itextframe/) را بدون دانستن شیء ارائه‌ای که آن را در بر دارد، دریافت کنند. از ویژگی فقط‑خواندنی [ITextFrame.ParentShape](https://reference.aspose.com/slides/fa/net/aspose.slides/itextframe/parentshape/) برای بازگشت به [IShape](https://reference.aspose.com/slides/fa/net/aspose.slides/ishape/) مالک آن استفاده کنید.

برای چارچوب متنی که توسط یک شکل خودکار یا شکل متن‌دار دیگر مالکیت می‌شود، `ParentShape` حامل مالک است و [ITextFrame.ParentCell](https://reference.aspose.com/slides/fa/net/aspose.slides/itextframe/parentcell/) مقدار `null` دارد. قبل از دسترسی به مقدار بازگردانده‌شده، آن را بررسی کنید. برای شناسایی هم مالک شکل و هم جدول‑سلول، از جمله اشکالی که با گره‌های SmartArt مرتبط هستند، به بخش [جستجو و جایگزینی متن](/slides/fa/net/search-and-replace-text/) مراجعه کنید.

## **افزودن ستون‌ها به یک جعبه متن**

ویژگی [ITextFrameFormat.ColumnCount](https://reference.aspose.com/slides/fa/net/aspose.slides/itextframeformat/columncount/) چارچوب متن را به ستون‌ها تقسیم می‌کند، در حالی که [ITextFrameFormat.ColumnSpacing](https://reference.aspose.com/slides/fa/net/aspose.slides/itextframeformat/columnspacing/) فاصله بین ستون‌ها را بر حسب پوینت تنظیم می‌نماید. هر دو تنظیم متعلق به [ITextFrameFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/itextframeformat/) هستند و می‌توان آن‌ها را با استفاده از چارچوب متن یک جعبه متن موجود تغییر داد. متن بین ستون‌ها در همان شکل بازپخش می‌شود؛ به شکل دیگری ادامه نمی‌یابد.

مثال زیر یک جعبه متن سه‑ستونی با فاصله 10 پوینت بین ستون‌ها ایجاد می‌کند، ارائه را ذخیره می‌نماید و تنظیمات ذخیره‌شده را از فایل خروجی می‌خواند:

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

از متد [TextFrame.SplitTextByColumns](https://reference.aspose.com/slides/fa/net/aspose.slides/textframe/splittextbycolumns/) برای دریافت متنی که به هر ستون بصری در یک چارچوب متن موجود اختصاص یافته استفاده کنید. این متد برای هر ستون یک رشته برمی‌گرداند، به ترتیب خواندن مبتنی بر ستون. یک چارچوب متن تک‌ستونی آرایه‌ای با یک عنصر تولید می‌کند و ستونی خالی توسط یک رشته خالی نمایان می‌شود. رشته‌ها فقط شامل متن ساده هستند؛ قالب‌بندی سطح بخش حفظ نمی‌شود.

این ویژگی زمانی مفید است که نیاز داشته باشید:

- متن را استخراج کنید در حالی که ترتیب خواندن مبتنی بر ستون حفظ می‌شود.
- محتوای اسلایدهای چندستونی را ایندکس یا مقایسه کنید.
- هر ستون را به فایل، فیلد پایگاه داده یا مقصد دیگری جداگانه صادر کنید.
- بررسی کنید که پس از تغییر [ITextFrameFormat.ColumnCount](https://reference.aspose.com/slides/fa/net/aspose.slides/itextframeformat/columncount/)، [ITextFrameFormat.ColumnSpacing](https://reference.aspose.com/slides/fa/net/aspose.slides/itextframeformat/columnspacing/)، قلم یا اندازه چارچوب متن، متن چگونه بازتوزیع می‌شود.

متد متن توزیع‌شده در [ITextFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/itextframe/) جاری را گزارش می‌دهد؛ به‌طور خودکار متن را بین اشکال یا جعبه‌های متن جداگانه جریان نمی‌دهد. توزیع ستون می‌تواند به قلم‌های موجود و تنظیمات دیگر چیدمان متن وابسته باشد، بنابراین هنگام نیاز به نتایج ثابت، اطمینان حاصل کنید که قلم‌های مورد نیاز در دسترس هستند.

مثال زیر یک ارائه را بارگذاری می‌کند، اولین شکل خودکار چندستونی با چارچوب متن را پیدا می‌کند، تعداد ستون‌های پیکربندی‌شده آن را می‌خواند و متن هر ستون را در یک فایل جداگانه می‌نویسد. شکل‌هایی که چارچوب متنی ندارند نادیده گرفته می‌شوند:

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

برای به‌روزرسانی متن در تمام ارائه، اسلایدها و اشکال را پیمایش کنید، اشکال خودکار را انتخاب کنید و سپس بخش‌های متنی آن‌ها را ویرایش کنید. کار بر سطح بخش امکان تغییر هم متن و هم قالب‌بندی کاراکترها را می‌دهد.

مثال زیر تمام وقوع‌های `years` را با `months` در متن اشکال خودکار جایگزین می‌کند و هر بخش مؤثر را به صورت بولد در می‌آورد:

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

این پیمایش فقط متن را در اشکال خودکار به‌روز می‌کند. متنی که در جداول، نمودارها، SmartArt یا اشکال گروهی ذخیره شده است، نیاز به پیمایش مجموعه‌های مربوطه آن اشیاء دارد.

## **افزودن جعبه متن با پیوند**

یک پیوند می‌تواند به بخش متنی خاصی اختصاص یابد، به طوری که فقط آن متن به عنوان لینک قابل کلیک باشد. از متد [IHyperlinkManager.SetExternalHyperlinkClick](https://reference.aspose.com/slides/fa/net/aspose.slides/ihyperlinkmanager/setexternalhyperlinkclick/) برای مرتبط کردن بخش با یک URL خارجی استفاده کنید.

مثال زیر متن لینک‌دار ایجاد کرده و آن را در یک ارائه ذخیره می‌کند:

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

**تفاوت جعبه متن و متغیر متن (placeholder) در اسلاید مستر یا طرح‌بندی چیست؟**

یک [placeholder](/slides/fa/net/manage-placeholder/) می‌تواند موقعیت و قالب‌بندی خود را از یک [master slide](https://reference.aspose.com/slides/fa/net/aspose.slides/masterslide/) یا [layout slide](https://reference.aspose.com/slides/fa/net/aspose.slides/layoutslide/) به ارث ببرد. یک جعبه متن معمولی یک شکل مستقل در اسلایدی است که در آن ایجاد شده و در هنگام تغییر طرح‌بندی، رفتار placeholder را کسب نمی‌کند.

**چگونه می‌توانم متن را بدون تغییر متن در نمودارها، جداول یا SmartArt جایگزین کنم؟**

پیمایش را محدود به اشکالی کنید که پیاده‌سازی [IAutoShape](https://reference.aspose.com/slides/fa/net/aspose.slides/iautoshape/) را دارند، همان‌طور که در مثال به‌روزرسانی متن نشان داده شد. نمودارها، جداول و SmartArt متن خود را در مدل‌های شیء مخصوص خود نگهداری می‌کنند، بنابراین توسط این حلقه تغییر نمی‌یابند.