---
title: قالب‌بندی متن ارائه در .NET
linktitle: قالب‌بندی متن
type: docs
weight: 50
url: /fa/net/text-formatting/
keywords:
- تراز پاراگراف
- سبک متن
- پس‌زمینه متن
- شفافیت متن
- فاصله کاراکتر
- ویژگی‌های قلم
- خانواده قلم
- چرخش متن
- زاویه چرخش
- قاب متن
- فاصله خط
- ویژگی autofit
- لنگر قاب متن
- تب‌بندی متن
- زبان پیش‌فرض
- PowerPoint
- OpenDocument
- ارائه
- .NET
- C#
- Aspose.Slides
description: "قالب‌بندی و استایل متن در ارائه‌های PowerPoint و OpenDocument با استفاده از Aspose.Slides برای .NET. قلم‌ها، رنگ‌ها، تراز و موارد دیگر را سفارشی کنید."
---
## **مروری کلی**

این مقاله نحوه قالب‌بندی متن در ارائه‌های PowerPoint و OpenDocument با استفاده از Aspose.Slides for .NET را نشان می‌دهد. این مقاله رنگ‌های پس‌زمینه، شفافیت، فاصله‌گذاری کاراکترها، ویژگی‌های قلم، چرخش، فاصله‌بندی پاراگراف، رفتار خودکار‑فیت، مکان‌یابی متن، توقف‌های تب و تنظیمات زبان را پوشش می‌دهد.

به‌جز مواردی که صریحاً ذکر شده، مثال‌ها از [sample.pptx](sample.pptx) استفاده می‌کنند. اولین شکل در اولین اسلاید یک کادر متن است و اولین پاراگراف آن حاوی متنی است که در زیر نشان داده شده است. هر دو شاخص اسلاید و شکل به صورت صفر‑پایه هستند. مثال‌هایی که بخش‌های پررنگ را انتخاب می‌کنند از قالب‌بندی مؤثر، شامل قالب‌بندی پررنگ به‌ارث‌برده، استفاده می‌کنند:

![متن نمونه](sample_text.png)

برای یافتن و برجسته‌سازی متن دقیق یا مطابقت‌های عبارات منظم، به [جستجو و جایگزینی متن](/slides/fa/net/search-and-replace-text/) مراجعه کنید.

## **تنظیم رنگ پس‌زمینه متن**

از [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaultportionformat/) برای تنظیم رنگ برجسته پیش‌فرض یک پاراگراف استفاده کنید، یا برای بخش‌های متنی جداگانه از [IBasePortionFormat.HighlightColor](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/highlightcolor/) استفاده کنید.

مثال زیر برجسته‌کردن خاکستری روشن را به‌عنوان پیش‌فرض برای اولین پاراگراف تنظیم می‌کند. رنگ‌های برجسته صریح برای بخش‌های جداگانه بر این پیش‌فرض ارجحیت دارند:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// تنظیم رنگ برجسته برای کل پاراگراف.
presentation.Save("gray_paragraph.pptx", SaveFormat.Pptx);
```

نتیجه:

![پاراگراف خاکستری](gray_paragraph.png)

مثال کدی زیر نشان می‌دهد چگونه رنگ پس‌زمینه را برای **بخش‌های متنی با قلم پررنگ** تنظیم کنید:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

foreach (var portion in paragraph.Portions)
{
    if (portion.PortionFormat.GetEffective().FontBold)
    {
        // تنظیم رنگ برجسته برای بخش متنی.
        portion.PortionFormat.HighlightColor.Color = Color.LightGray;
    }
}

presentation.Save("gray_text_portions.pptx", SaveFormat.Pptx);
```

نتیجه:

![بخش‌های متنی خاکستری](gray_text_portions.png)

## **تراز پاراگراف‌های متنی**

از [IParagraphFormat.Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) برای تنظیم تراز پاراگراف داخل یک قاب متن استفاده کنید. مقدار می‌تواند مرکز، چپ‌تراز، راست‌تراز، توجیه‌شده و ... باشد.

مثال کد زیر نشان می‌دهد چگونه پاراگراف را به **مرکز** تراز کنید:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// تنظیم تراز پاراگراف به مرکز.
paragraph.ParagraphFormat.Alignment = TextAlignment.Center;

presentation.Save("aligned_paragraph.pptx", SaveFormat.Pptx);
```

نتیجه:

![پاراگراف تراز شده](aligned_paragraph.png)

## **تراز قلم‌ها درون یک خط**

از [IParagraphFormat.FontAlignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/fontalignment/) برای تراز عمودی بخش‌های متنی با اندازه‌های قلم مختلف درون یک خط استفاده کنید. این تنظیم برای کل پاراگراف اعمال می‌شود و تراز را در هر خط کنترل می‌کند.

مثال خودکفا زیر چهار کادر متن برچسب‌دار روی یک اسلاید ایجاد می‌کند. هر پاراگراف متن یکسانی را با اندازه‌های 18، 36 و 54 پوینت دارد و تراز قلم متفاوتی دارد. این مثال از Arial استفاده می‌کند، Autofit و بسته‌بندی را غیرفعال می‌کند و قاب‌های متن را به اندازه‌ای بزرگ می‌گذارد که یک خط کافی باشد.

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var alignments = new[] { FontAlignment.Baseline, FontAlignment.Top, FontAlignment.Center, FontAlignment.Bottom };
var fontSizes = new[] { 18f, 36f, 54f };

for (var i = 0; i < alignments.Length; i++)
{
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 20 + i * 130, 660, 120);
    shape.FillFormat.FillType = FillType.NoFill;
    shape.LineFormat.FillFormat.FillType = FillType.NoFill;

    var textFrame = shape.TextFrame;
    textFrame.TextFrameFormat.AnchoringType = TextAnchorType.Top;
    textFrame.TextFrameFormat.AutofitType = TextAutofitType.None;
    textFrame.TextFrameFormat.WrapText = NullableBool.False;

    var label = textFrame.Paragraphs[0];
    label.Text = alignments[i].ToString();
    label.ParagraphFormat.Alignment = TextAlignment.Left;
    label.ParagraphFormat.DefaultPortionFormat.FontHeight = 14;
    label.ParagraphFormat.DefaultPortionFormat.LatinFont = new FontData("Arial");
    label.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    label.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;

    var paragraph = new Paragraph();
    paragraph.ParagraphFormat.FontAlignment = alignments[i];
    paragraph.ParagraphFormat.Alignment = TextAlignment.Left;
    paragraph.ParagraphFormat.DefaultPortionFormat.LatinFont = new FontData("Arial");
    paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

    foreach (var fontSize in fontSizes)
    {
        var portion = new Portion("Ag ");
        portion.PortionFormat.FontHeight = fontSize;
        paragraph.Portions.Add(portion);
    }

    textFrame.Paragraphs.Add(paragraph);
}

presentation.Save("font_alignment.pptx", SaveFormat.Pptx);
```

نتیجه:

![مقایسه تراز پایه، بالا، مرکز و پایین با اندازه‌های متفاوت قلم](font_alignment.png)

تراز قلم از معیارهای قلم استفاده می‌کند، بنابراین لبه‌های قابل مشاهدهٔ حروف به‌طور دقیق هم‌سطح نیستند. مثال شامل یک حرف بزرگ و یک حرف پایین‌دست برای نشان دادن تفاوت بین تراز پایه و پایین است. در دسترس بودن قلم و جایگزینی، کاراکترهای استفاده‑شده و تفاوت در اندازه‌های قلم بر نتیجه تاثیر می‌گذارند. ابعاد فریم، حاشیه‌ها، فاصله خط، بسته‌بندی و خودکار‑فیت نیز بر چیدمان اثر دارند؛ هنگام مقایسهٔ حالت‌ها از همان قلم‌ها و تنظیمات چیدمان استفاده کنید.

این تنظیم متفاوت از [IParagraphFormat.Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) است که تراز افقی پاراگراف را کنترل می‌کند، و از [ITextFrameFormat.AnchoringType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/anchoringtype/) که موقعیت بلوک متن را به صورت عمودی داخل شکل تعیین می‌کند. قالب‌بندی بالانویس و زیرنویس از طریق [IBasePortionFormat.Escapement](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/escapement/) بخش‌های جداگانه را نسبت به پایه جابه‌جا می‌کند به جای تنظیم تراز قلم برای خطوط پاراگراف.

## **تنظیم شفافیت متن**

شفافی متن از طریق مؤلفه آلفای رنگ اختصاص داده شده به [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fillformat/) کنترل می‌شود. در مثال‌های زیر، `alpha = 50` مقدار کانال آلفای ARGB در مقیاس 0‑255 است، نه درصد شفافیت.

مثال کدی زیر نشان می‌دهد چگونه شفافیت را به **کل پاراگراف** اعمال کنید:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

var alpha = 50;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// تنظیم پرکردن مشکی نیمه شفاف برای متن.
paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Black);

presentation.Save("transparent_paragraph.pptx", SaveFormat.Pptx);
```

نتیجه:

![پاراگراف شفاف](transparent_paragraph.png)

مثال کد زیر نشان می‌دهد چگونه شفافیت را به **بخش‌های متنی با قلم پررنگ** اعمال کنید:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

var alpha = 50;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

foreach (var portion in paragraph.Portions)
{
    if (portion.PortionFormat.GetEffective().FontBold)
    {
        // تنظیم شفافیت بخش متن.
        portion.PortionFormat.FillFormat.FillType = FillType.Solid;
        portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Black);
    }
}

presentation.Save("transparent_text_portions.pptx", SaveFormat.Pptx);
```

نتیجه:

![بخش‌های متنی شفاف](transparent_text_portions.png)

## **تنظیم فاصله کاراکتر برای متن**

از [IBasePortionFormat.Spacing](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/spacing/) برای گسترش یا فشردن فاصله بین کاراکترها در یک کادر متن استفاده کنید. مثال‌ها 3 پوینت فاصله اضافه می‌کنند؛ مقادیر منفی متن را فشرده می‌کنند.

کد C# زیر نشان می‌دهد چگونه فاصله کاراکتر را در **کل پاراگراف** گسترش دهید:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// نکته: برای فشرده‌سازی فاصله کاراکتر از مقادیر منفی استفاده کنید.
paragraph.ParagraphFormat.DefaultPortionFormat.Spacing = 3;  // گسترش فاصله کاراکتر.

presentation.Save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
```

نتیجه:

![فاصله کاراکتر در پاراگراف](character_spacing_in_paragraph.png)

مثال کد زیر نشان می‌دهد چگونه فاصله کاراکتر را در **بخش‌های متنی با قلم پررنگ** گسترش دهید:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

foreach (var portion in paragraph.Portions)
{
    if (portion.PortionFormat.GetEffective().FontBold)
    {
        // نکته: برای فشرده‌سازی فاصله کاراکتر از مقادیر منفی استفاده کنید.
        portion.PortionFormat.Spacing = 3;  // گسترش فاصله کاراکتر.
    }
}

presentation.Save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
```

نتیجه:

![فاصله کاراکتر در بخش‌های متنی](character_spacing_in_text_portions.png)

### **غیرفعال کردن کرنینگ برای قلم‌های خاص**

در برخی موارد، متنی که توسط Aspose.Slides رندر می‌شود ممکن است کمی تنگ‌تر از همان متن در PowerPoint ظاهر شود. این می‌تواند به این دلیل باشد که PowerPoint ممکن است داده‌های کرنینگ برای برخی قلم‌ها را نادیده بگیرد، حتی اگر قلم حاوی اطلاعات کرنینگ معتبر باشد و کرنینگ در تنظیمات PowerPoint فعال باشد.

برای نزدیک‌تر کردن خروجی رندر شده به PowerPoint در چنین مواردی، می‌توانید کرنینگ را برای بخش‌های متنی که از قلم متاثر استفاده می‌کنند غیرفعال کنید. مقدار [IBasePortionFormat.KerningMinimalSize](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/kerningminimalsize/) را بزرگتر از اندازه واقعی قلم تنظیم کنید. این مثال نیاز به «presentation.pptx» دارد که یک کادر متن به عنوان اولین شکل روی اولین اسلاید داشته باشد. این مثال نام‌های قلم مؤثر، شامل قلم‌های به ارث‌برده، را بررسی کرده و آستانه 100 پوینت را برای بخش‌هایی که از Roboto استفاده می‌کنند تنظیم می‌کند. این کار کرنینگ را برای بخش‌های مطابقی که اندازه قلمشان زیر 100 پوینت است غیرفعال می‌کند:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var targetFont = "Roboto";

foreach (var paragraph in autoShape.TextFrame.Paragraphs)
{
    foreach (var portion in paragraph.Portions)
    {
        var textFormat = portion.PortionFormat.GetEffective();
        
        var usesTargetFont = textFormat.LatinFont?.FontName == targetFont || 
            textFormat.EastAsianFont?.FontName == targetFont || 
            textFormat.ComplexScriptFont?.FontName == targetFont;

        if (usesTargetFont)
        {
            portion.PortionFormat.KerningMinimalSize = 100;
        }
    }
}

presentation.Save("output.pptx", SaveFormat.Pptx);
```

## **مدیریت ویژگی‌های قلم متن**

ویژگی‌های قلم می‌توانند در سطح پاراگراف از طریق [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaultportionformat/) یا روی بخش‌های جداگانه از طریق [IPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/) تنظیم شوند.

مثال زیر فونت پیش‌فرض پاراگراف اول را به 12‑پوینت Times New Roman با قالب‌بندی پررنگ، ایتالیک و زیرخط نقطه‌دار تنظیم می‌کند. قالب‌بندی صریح روی بخش‌های جداگانه بر این پیش‌فرض‌ها ارجحیت دارد:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// تنظیم ویژگی‌های قلم برای پاراگراف.
var portionFormat = paragraph.ParagraphFormat.DefaultPortionFormat;
portionFormat.FontHeight = 12;
portionFormat.FontBold = NullableBool.True;
portionFormat.FontItalic = NullableBool.True;
portionFormat.FontUnderline = TextUnderlineType.Dotted;
portionFormat.LatinFont = new FontData("Times New Roman");

presentation.Save("font_properties_for_paragraph.pptx", SaveFormat.Pptx);
```

نتیجه:

![ویژگی‌های قلم برای پاراگراف](font_properties_for_paragraph.png)

مثال زیر 13‑پوینت Times New Roman، قالب‌بندی ایتالیک و زیرخط نقطه‌دار را به بخش‌هایی که قالب‌بندی مؤثرشان پررنگ است اعمال می‌کند:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

foreach (var portion in paragraph.Portions)
{
    if (portion.PortionFormat.GetEffective().FontBold)
    {
        // تنظیم ویژگی‌های قلم برای بخش متنی.
        portion.PortionFormat.FontHeight = 13;
        portion.PortionFormat.FontItalic = NullableBool.True;
        portion.PortionFormat.FontUnderline = TextUnderlineType.Dotted;
        portion.PortionFormat.LatinFont = new FontData("Times New Roman");
    }
}

presentation.Save("font_properties_for_text_portions.pptx", SaveFormat.Pptx);
```

نتیجه:

![ویژگی‌های قلم برای بخش‌های متنی](font_properties_for_text_portions.png)

## **کنترل نرمال‌سازی ارتفاع متن**

از [IBasePortionFormat.NormaliseHeight](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/normaliseheight/) هنگام بازتولید تایپوگرافی قالب یا بررسی اختلافات ارتفاع کاراکترها استفاده کنید. در PowerPoint، فعال‌سازی نرمال‌سازی کاراکترها را عمودی کشیده یا فشرده می‌کند تا ارتفاع قابل رؤیتی یکنواختی درون بخش متنی داشته باشند. این ویژگی تضمین نمی‌کند که ارتفاع متون بین قلم‌های مختلف برابر باشد.

مقدار ویژگی را به [NullableBool.True یا False](https://reference.aspose.com/slides/net/aspose.slides/nullablebool/) تنظیم کنید تا به‌صورت صریح نرمال‌سازی را فعال یا غیرفعال کنید. `NullableBool.NotDefined` تنظیم محلی را خالی می‌گذارد تا بخش مقدار را از مثالاً از [DefaultPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaultportionformat/) پاراگراف به ارث ببرد. این به معنای `False` نیست. برای دریافت مقدار بولی حل‌شده از [IPortionFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/geteffective/) و [IBasePortionFormatEffectiveData.NormaliseHeight](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformateffectivedata/normaliseheight/) استفاده کنید.

مثال خودکفا زیر نیاز به نصب **Arial** دارد. این مثال دو بلوک متنی شامل حروف بزرگ، حروف کوچک، حروف پایین‌دست و حروف با لهجه را در اندازه 54 پوینت ایجاد می‌کند. هر دو پاراگراف به‌صورت پیش‌فرض نرمال‌سازی را فعال می‌کنند. بخش بالایی صریحاً آن را غیرفعال می‌کند؛ بخش زیرین ارث می‌برد. اندازه فریم‌ها، حاشیه‌ها و فاصله پاراگراف یکسان هستند و بسته‌بندی و autofit غیرفعال‌اند تا مقایسه ثابت بماند. مثال مقادیر `False: False` و `NotDefined: True` را چاپ می‌کند و سپس «text_height_normalization.pptx» را ذخیره می‌نماید:

```cs
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var settings = new[] { NullableBool.False, NullableBool.NotDefined };

for (var i = 0; i < settings.Length; i++)
{
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 60 + i * 200, 660, 150);
    shape.FillFormat.FillType = FillType.NoFill;
    shape.LineFormat.FillFormat.FillType = FillType.NoFill;

    var textFrame = shape.TextFrame;
    textFrame.Text = "Hxgjpq ÅÉ 0123";
    textFrame.TextFrameFormat.AutofitType = TextAutofitType.None;
    textFrame.TextFrameFormat.WrapText = NullableBool.False;
    textFrame.TextFrameFormat.AnchoringType = TextAnchorType.Top;
    textFrame.TextFrameFormat.MarginTop = 0;
    textFrame.TextFrameFormat.MarginLeft = 0;

    var paragraph = textFrame.Paragraphs[0];
    paragraph.ParagraphFormat.Alignment = TextAlignment.Left;
    paragraph.ParagraphFormat.SpaceBefore = 0;
    paragraph.ParagraphFormat.SpaceAfter = 0;
    paragraph.ParagraphFormat.SpaceWithin = 100;
    paragraph.ParagraphFormat.DefaultPortionFormat.NormaliseHeight = NullableBool.True;

    var portion = paragraph.Portions[0];
    portion.PortionFormat.LatinFont = new FontData("Arial");
    portion.PortionFormat.FontHeight = 54;
    portion.PortionFormat.FillFormat.FillType = FillType.Solid;
    portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    portion.PortionFormat.NormaliseHeight = settings[i];

    Console.WriteLine($"{settings[i]}: {portion.PortionFormat.GetEffective().NormaliseHeight}");
}

presentation.Save("text_height_normalization.pptx", SaveFormat.Pptx);
```

مقایسهٔ زیر از ارائهٔ ذخیره‌شده استخراج شده است. ردیف بالایی نرمال‌سازی غیرفعال (`False`) دارد؛ ردیف زیرین تنظیم فعال را ارث می‌برد (`NotDefined` → `True`). برای بازتولید این ظاهر Arial باید نصب باشد.

![متن 54‑نقطه‌ای Arial با نرمال‌سازی غیرفعال در بالا و نرمال‌سازی وارث شده در پایین](text_height_normalization.png)

نرمال‌سازی ارتفاع کاراکترها را بدون تغییر مقدار [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fontheight/) که اندازه قلم را بر حسب پوینت مشخص می‌کند، تغییر می‌دهد. [SpaceWithin](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacewithin/) پاراگراف کنترل‌کنندهٔ فاصله خطوط است، در حالی که [AutofitType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/autofittype/) فریم متن تعیین می‌کند که چگونه متن یا محفظهٔ آن برای جا شدن تنظیم می‌شود. این تنظیمات اهداف مختلفی دارند و می‌توانند به‌ طور مستقل بر چیدمان کلی تاثیر بگذارند. برای جزئیات بیشتر درباره قالب‌بندی پاراگراف و ارث‌بری، به [Manage Paragraph](/slides/fa/net/manage-paragraph/) مراجعه کنید.

## **اعمال و حذف خط‌خورده**

از [IBasePortionFormat.StrikethroughType](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/strikethroughtype/) بر یک بخش متنی برای نمایش اصلاحات، عبارات لغو شده یا قیمت‌های قبلی بدون حذف متن اصلی استفاده کنید. برای یک یا دو خط عبور از متن، مقدار آن را به [TextStrikethroughType.Single یا Double](https://reference.aspose.com/slides/net/aspose.slides/textstrikethroughtype/) تنظیم کنید.

برای حذف خط‌خورده، `TextStrikethroughType.None` را اختصاص دهید. این مقدار اثر را صریحاً غیرفعال می‌کند، حتی اگر قالب‌بندی اطراف خط‌خورده باشد. در مقابل، `TextStrikethroughType.NotDefined` تنظیم محلی را تعریف‌نشده می‌گذارد تا بخش بتواند قالب‌بندی را از مثالاً از پاراگراف به ارث ببرد. استفاده از [IPortionFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/geteffective/) برای خواندن قالب‌بندی نهایی، شامل مقادیر ارث‌برده، توصیه می‌شود.

مثال خودکفا زیر سه مقایسهٔ قیمتی ایجاد می‌کند. هر پاراگراف بخش‌های جداگانه‌ای برای برچسب، قیمت قبلی و قیمت جاری دارد، بنابراین فقط قیمت قبلی تحت تأثیر قرار می‌گیرد. ردیف اول خط‌خورده را اعمال سپس حذف می‌کند؛ سایر ردیف‌ها به ترتیب خط‌خوردهٔ تک و دو خطی را حفظ می‌کنند. تغییر این ویژگی متن و سایر قالب‌بندی‌های آن، شامل قلم پررنگ قبلی، را حفظ می‌کند.

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 620, 220);
shape.FillFormat.FillType = FillType.NoFill;
shape.LineFormat.FillFormat.FillType = FillType.NoFill;
shape.TextFrame.Paragraphs.Clear();

var labels = new[] { "None: ", "Single: ", "Double: " };

foreach (var label in labels)
{
    var paragraph = new Paragraph();
    paragraph.ParagraphFormat.Alignment = TextAlignment.Left;
    paragraph.ParagraphFormat.SpaceAfter = 20;

    var format = paragraph.ParagraphFormat.DefaultPortionFormat;
    format.FontHeight = 28;
    format.LatinFont = new FontData("Arial");
    format.FillFormat.FillType = FillType.Solid;
    format.FillFormat.SolidFillColor.Color = Color.Black;

    paragraph.Portions.Add(new Portion(label));

    var previousPrice = new Portion("$100");
    previousPrice.PortionFormat.FontBold = NullableBool.True;
    paragraph.Portions.Add(previousPrice);
    paragraph.Portions.Add(new Portion(" → $80"));
    
    shape.TextFrame.Paragraphs.Add(paragraph);
}

var paragraphs = shape.TextFrame.Paragraphs;

// خط‌خورده را اعمال کنید، سپس به‌طور صریح آن را از اولین قیمت قبلی حذف کنید.
paragraphs[0].Portions[1].PortionFormat.StrikethroughType = TextStrikethroughType.Single;
paragraphs[0].Portions[1].PortionFormat.StrikethroughType = TextStrikethroughType.None;

paragraphs[1].Portions[1].PortionFormat.StrikethroughType = TextStrikethroughType.Single;
paragraphs[2].Portions[1].PortionFormat.StrikethroughType = TextStrikethroughType.Double;

presentation.Save("strikethrough.pptx", SaveFormat.Pptx);
```

نتیجه، از بالا به پایین: بدون خط‌خورده، خط‌خوردهٔ تک‌خطی، و خط‌خوردهٔ دوخطی.

![قیمت‌های قبلی بدون خط‌خورده، با خط‌خوردهٔ تک‌خطی، و با خط‌خوردهٔ دوخطی](strikethrough.png)

## **تنظیم چرخش متن**

از [ITextFrameFormat.TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/textverticaltype/) برای تنظیم جهت پیش‌فرض متن درون یک شکل استفاده کنید.

مثال کد زیر جهت متن در شکل را به [TextVerticalType.Vertical270](https://reference.aspose.com/slides/net/aspose.slides/textverticaltype/) تنظیم می‌کند که متن را **90 درجه در جهت خلاف عقربه‌های ساعت** می‌چرخاند:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.TextVerticalType = TextVerticalType.Vertical270;

presentation.Save("text_rotation.pptx", SaveFormat.Pptx);
```

نتیجه:

![چرخش متن](text_rotation.png)

## **تنظیم چرخش سفارشی برای فریم‌های متن**

از [ITextFrameFormat.RotationAngle](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/rotationangle/) برای تنظیم زاویهٔ چرخش سفارشی یک [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) استفاده کنید.

مثال کد زیر فریم متن را 3 درجه در جهت ساعت داخل شکل می‌چرخاند:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.RotationAngle = 3;

presentation.Save("custom_text_rotation.pptx", SaveFormat.Pptx);
```

نتیجه:

![چرخش سفارشی متن](custom_text_rotation.png)

## **تنظیم فاصله خط پاراگراف‌ها**

Aspose.Slides ویژگی‌های [IParagraphFormat.SpaceAfter](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spaceafter/)، [IParagraphFormat.SpaceBefore](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacebefore/) و [IParagraphFormat.SpaceWithin](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacewithin/) را برای کنترل فاصله پاراگراف ارائه می‌دهد. این خصوصیات به شکل زیر استفاده می‌شوند:

* برای مشخص کردن فاصله خط به‌عنوان درصدی از ارتفاع خط، مقدار مثبت بدهید.
* برای مشخص کردن فاصله خط به پوینت، مقدار منفی بدهید.

مثال زیر فاصله داخل اولین پاراگراف را به 200 ٪ از ارتفاع خط (دو برابر) تنظیم می‌کند:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

paragraph.ParagraphFormat.SpaceWithin = 200;

presentation.Save("line_spacing.pptx", SaveFormat.Pptx);
```

نتیجه:

![فاصله خط درون پاراگراف](line_spacing.png)

## **کنترل شکست خط**

قوانین شکست خط پاراگراف در بلاک‌های متنی باریک و ارائه‌هایی که متن لاتین و شرق آسیا را ترکیب می‌کنند مفید هستند. این ویژگی‌ها به [IParagraphFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/) تعلق دارند، بنابراین برای کل پاراگراف اعمال می‌شوند:

* [LatinLineBreak](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/latinlinebreak/) قوانین شکست خط لاتین را کنترل می‌کند. در متن ترکیبی، تغییر آن می‌تواند محل بسته شدن متن و نقطه‌گذاری شرق آسیا را نیز تغییر دهد.
* [EastAsianLineBreak](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/eastasianlinebreak/) قوانین شکست خط شرق آسیا را کنترل می‌کند، از جمله محدودیت‌های کاراکترهای ابتدای و انتهای خط.

این قوانین جایگزین [ITextFrameFormat.WrapText](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/wraptext/) که بسته‌بندی خودکار را درون فریم متن فعال می‌کند، نمی‌شوند. آن‌ها بر چیدمان هنگام بسته‌بندی تأثیر می‌گذارند؛ کاراکترهای شکست خط را وارد نمی‌کنند. یک شکست خط صریح یک خط جدید درون پاراگراف ایجاد می‌کند بدون توجه به عرض موجود.

مثال خودکفا زیر یک بلاک متنی باریک شامل متن چینی و لاتین ایجاد می‌کند. هر دو ویژگی شکست خط به‌صورت صریح تنظیم شده و «line_breaking.pptx» ذخیره می‌شود. برای آزمایش هر قانون، مقدار آن ویژگی را تغییر دهید در حالی که تنظیمات دیگر ثابت می‌مانند. مثال از Arial 24‑پوینت و SimSun با عرض فریم 160‑پوینت و حاشیه افقی صفر استفاده می‌کند. [ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/autofittype/) به [TextAutofitType.None](https://reference.aspose.com/slides/net/aspose.slides/textautofittype/) تنظیم شده تا اندازه متن و ابعاد فریم ثابت بمانند.

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 160, 300);
shape.FillFormat.FillType = FillType.NoFill;

var textFrame = shape.TextFrame;
textFrame.TextFrameFormat.WrapText = NullableBool.True;
textFrame.TextFrameFormat.AutofitType = TextAutofitType.None;
textFrame.TextFrameFormat.MarginLeft = 0;
textFrame.TextFrameFormat.MarginRight = 0;

var paragraph = textFrame.Paragraphs[0];
paragraph.Text = "中文排版测试，PowerPoint 中文演示。";

var format = paragraph.ParagraphFormat;
format.Alignment = TextAlignment.Left;
format.DefaultPortionFormat.FontHeight = 24;
format.DefaultPortionFormat.LatinFont = new FontData("Arial");
format.DefaultPortionFormat.EastAsianFont = new FontData("SimSun");
format.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
format.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
format.LatinLineBreak = NullableBool.False;
format.EastAsianLineBreak = NullableBool.True;

presentation.Save("line_breaking.pptx", SaveFormat.Pptx);
```

## **کنترل نقطه‌گذاری معلق**

[IParagraphFormat.HangingPunctuation](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/hangingpunctuation/) اجازه می‌دهد نقطه‌گذاری‌های مجاز از حاشیهٔ راست خط متن فراتر روند به جای اشغال خط بعدی. این ویژگی برای کل پاراگراف اعمال می‌شود و با تورفتگی معلق متفاوت است.

مثال خودکفا زیر نقطه‌گذاری معلق را در فریم متنی 100‑پوینت‌عرض فعال می‌کند و «hanging_punctuation.pptx» ذخیره می‌نماید. با Arial 24‑پوینت و حاشیه افقی صفر، نقطهٔ نهایی پس از «sentence» می‌ماند و از لبهٔ راست متن فراتر می‌رود. برای مقایسه مقدار ویژگی را به [NullableBool.False](https://reference.aspose.com/slides/net/aspose.slides/nullablebool/) تنظیم کنید: با این تنظیمات نقطه در خط جداگانه‌ای قرار می‌گیرد. بسته‌بندی فعال و autofit غیرفعال است تا عرض موجود ثابت بماند.

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 100, 200);
shape.FillFormat.FillType = FillType.NoFill;

var textFrame = shape.TextFrame;
textFrame.TextFrameFormat.WrapText = NullableBool.True;
textFrame.TextFrameFormat.AutofitType = TextAutofitType.None;
textFrame.TextFrameFormat.MarginLeft = 0;
textFrame.TextFrameFormat.MarginRight = 0;

var paragraph = textFrame.Paragraphs[0];
paragraph.Text = "Simple text, next sentence.";

var format = paragraph.ParagraphFormat;
format.Alignment = TextAlignment.Left;
format.DefaultPortionFormat.FontHeight = 24;
format.DefaultPortionFormat.LatinFont = new FontData("Arial");
format.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
format.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
format.HangingPunctuation = NullableBool.True;

presentation.Save("hanging_punctuation.pptx", SaveFormat.Pptx);
```

هر علامت نقطه‌گذاری ممکن نیست که معلق باشد. شرایط قلم و چیدمان توضیح داده‌شده در [کنترل شکست خط](#control-line-breaking) نیز برای این مقایسه صدق می‌کند: تغییر قلم، عرض موجود، حاشیه‌ها یا تنظیمات autofit می‌تواند تفاوت قابل مشاهده را از بین ببرد.

## **تنظیم نوع Autofit برای فریم‌های متن**

[ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/autofittype/) تعیین می‌کند متن هنگام تجاوز از مرزهای محفظهٔ خود چگونه رفتار کند. از آن برای کنترل این‌که آیا متن کوچک می‌شود، خارج می‌شود یا شکل به‌صورت خودکار اندازه می‌شود، استفاده کنید. مثال زیر شکل را طوری تنظیم می‌کند که برای متن خود تغییر اندازه دهد و نتیجه را در «autofit_type.pptx» ذخیره می‌کند:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;

presentation.Save("autofit_type.pptx", SaveFormat.Pptx);
```

برای شمارش خطوط پس از بسته‌بندی خودکار و مشاهدهٔ چگونگی تغییر عرض متن یا شکل، به [Count Rendered Lines](/slides/fa/net/manage-paragraph/) مراجعه کنید. شمارش خطوط به تنهایی نشان‌دهندهٔ overflow متن نیست.

## **تنظیم محل لنگری فریم‌های متن**

[ITextFrameFormat.AnchoringType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/anchoringtype/) تعریف می‌کند متن به صورت عمودی داخل شکل در کجا قرار گیرد، مثلاً بالا، وسط یا پایین. مثال زیر متن را به پایین اولین شکل لنگر می‌کند و نتیجه را در «text_anchor.pptx» ذخیره می‌نماید:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.AnchoringType = TextAnchorType.Bottom;

presentation.Save("text_anchor.pptx", SaveFormat.Pptx);
```

## **تنظیم تبulation متن**

از [IParagraphFormat.DefaultTabSize](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaulttabsize/) و [IParagraphFormat.Tabs](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/tabs/) برای پیکربندی توقف‌های تب در یک پاراگراف استفاده کنید. مثال زیر فاصلهٔ تب پیش‌فرض را به 100 پوینت تنظیم می‌کند و یک توقف تب چپ‌تراز در 30 پوینت اضافه می‌کند. این تنظیمات بر متنی که شامل کاراکترهای تب است، تأثیر می‌گذارند:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];
paragraph.ParagraphFormat.DefaultTabSize = 100;
paragraph.ParagraphFormat.Tabs.Add(30, TabAlignment.Left);

presentation.Save("paragraph_tabs.pptx", SaveFormat.Pptx);
```

نتیجه:

![تب‌های پاراگراف](paragraph_tabs.png)

## **تنظیم زبان اصلاح‌گری**

Aspose.Slides [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/languageid/) را فراهم می‌کند که به شما امکان می‌دهد زبان اصلاح‌گری برای یک بخش متنی را تنظیم کنید. زبان اصلاح‌گری تعیین‌کنندهٔ زبان استفاده‌شده برای بررسی املایی و گرامری در PowerPoint است.

مثال زیر نیاز به «presentation.pptx» دارد که یک کادر متن به عنوان اولین شکل روی اولین اسلاید داشته باشد و حداقل یک پاراگراف داشته باشد. این مثال محتویات اولین پاراگراف را با «1。» جایگزین می‌کند، SimSun را به‌عنوان قلم آن تنظیم می‌کند و زبان اصلاح‌گری چینی ساده (`zh-CN`) را اختصاص می‌دهد. سپس نتیجه در «proofing_language.pptx» ذخیره می‌شود:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];
paragraph.Portions.Clear();

var font = new FontData("SimSun");

var textPortion = new Portion();
textPortion.PortionFormat.ComplexScriptFont = font;
textPortion.PortionFormat.EastAsianFont = font;
textPortion.PortionFormat.LatinFont = font;

// تنظیم زبان اصلاح‌گری به چینی ساده.
textPortion.PortionFormat.LanguageId = "zh-CN";

textPortion.Text = "1。";
paragraph.Portions.Add(textPortion);

presentation.Save("proofing_language.pptx", SaveFormat.Pptx);
```

## **تنظیم زبان پیش‌فرض**

از [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/defaulttextlanguage/) برای تعریف زبان پیش‌فرض متنی که هنگام بارگذاری یا ایجاد ارائه ایجاد می‌شود، استفاده کنید. مثال زیر ارائه‌ای با زبان پیش‌فرض متن انگلیسی آمریکایی ایجاد می‌کند، یک کادر متن اضافه می‌کند و برای اولین بخش متنی آن `en-US` چاپ می‌کند:

```cs
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions();
loadOptions.DefaultTextLanguage = "en-US";

using var presentation = new Presentation(loadOptions);
var slide = presentation.Slides[0];

// یک شکل مستطیل جدید با متن اضافه کنید.
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
shape.TextFrame.Text = "Sample text";

// زبان اولین بخش را بررسی کنید.
var portion = shape.TextFrame.Paragraphs[0].Portions[0];
Console.WriteLine(portion.PortionFormat.LanguageId);
```

## **تنظیم سبک پیش‌فرض متن**

برای اعمال قالب‌بندی پیش‌فرض متن در سطح ارائه، از [IPresentation.DefaultTextStyle](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/defaulttextstyle/) استفاده کنید.

مثال زیر یک قلم 14‑پوینت پررنگ را به‌عنوان پیش‌فرض برای پاراگراف‌های سطح بالای یک ارائه جدید تنظیم می‌کند و آن را در «default_text_style.pptx» ذخیره می‌کند. متن می‌تواند این پیش‌فرض‌ها را به ارث ببرد مگر اینکه قالب‌بندی خاص‌تری آن‌ها را نادیده بگیرد.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
// دریافت قالب پاراگراف سطح بالایی.
var paragraphFormat = presentation.DefaultTextStyle.GetLevel(0);

if (paragraphFormat != null)
{
    paragraphFormat.DefaultPortionFormat.FontHeight = 14;
    paragraphFormat.DefaultPortionFormat.FontBold = NullableBool.True;
}

presentation.Save("default_text_style.pptx", SaveFormat.Pptx);
```

## **استخراج متن با اثر تمام حروف بزرگ**

در PowerPoint، اعمال اثر **All Caps** روی قلم باعث می‌شود متن بر روی اسلاید بزرگنمایی شود حتی اگر در ابتدا با حروف کوچک وارد شده باشد. وقتی چنین بخش متنی را با Aspose.Slides بازیابی می‌کنید، کتابخانه متن دقیقاً همان‌گونه که وارد شده برمی‌گرداند. برای مطابقت با متن نمایش داده‌شده، [TextCapType](https://reference.aspose.com/slides/net/aspose.slides/textcaptype/) را بررسی کنید و در صورت برابر بودن مقدار با `All`، رشته برگشتی را به حروف بزرگ تبدیل کنید.

این مثال نیاز به «sample2.pptx» دارد که یک کادر متن به عنوان اولین شکل روی اولین اسلاید داشته باشد. اولین پاراگراف اولین بخش آن شامل «Hello, Aspose!» با اثر All Caps است، همان‌طور که در زیر نشان داده شده است.

![اثر All Caps](all_caps_effect.png)

مثال کد زیر نشان می‌دهد چگونه متن با اثر **All Caps** استخراج شود:

```cs
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample2.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var textPortion = autoShape.TextFrame.Paragraphs[0].Portions[0];

Console.WriteLine($"Original text: {textPortion.Text}");

var textFormat = textPortion.PortionFormat.GetEffective();
if (textFormat.TextCapType == TextCapType.All)
{
    var text = textPortion.Text.ToUpper();
    Console.WriteLine($"All-Caps effect: {text}");
}
```

خروجی:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **سوالات متداول**

**چگونه می‌توان متن داخل جدول در یک اسلاید را اصلاح کرد؟**

برای اصلاح متن داخل جدول در یک اسلاید، از [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) استفاده کنید. سلول‌ها را مرور کنید و هر سلول را از طریق [ICell.TextFrame](https://reference.aspose.com/slides/net/aspose.slides/icell/textframe/) و قالب‌بندی پاراگراف از طریق [IParagraph.ParagraphFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/paragraphformat/) به‌روز کنید.

**چگونه می‌توان رنگ گرادیان به متن در یک اسلاید PowerPoint اعمال کرد؟**

برای اعمال رنگ گرادیان به متن، از [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fillformat/) استفاده کنید. مقدار [IFillFormat.FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) را به [FillType.Gradient](https://reference.aspose.com/slides/net/aspose.slides/filltype/) تنظیم کنید و توقف‌های گرادیان، جهت و شفافیت را پیکربندی کنید.

ویژگی مرتبط: [Format text within slides](/slides/fa/features/text-formatting/).