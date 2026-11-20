---
title: قالب‌بندی متن ارائه در .NET
linktitle: قالب‌بندی متن
type: docs
weight: 50
url: /fa/net/text-formatting/
keywords:
- تنظیم پاراگراف
- سبک متن
- پس‌زمینه متن
- شفافیت متن
- فاصله حروف
- ویژگی‌های قلم
- خانواده قلم
- چرخش متن
- زاویهٔ چرخش
- قاب متن
- فاصله خطوط
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
description: "متن را در ارائه‌های PowerPoint و OpenDocument با استفاده از Aspose.Slides برای .NET قالب‌بندی و استایل دهید. قلم‌ها، رنگ‌ها، تراز و موارد دیگر را سفارشی کنید."
---
## **نمای کلی**

این مقاله نشان می‌دهد چطور متن در ارائه‌های PowerPoint و OpenDocument را با استفاده از Aspose.Slides برای .NET قالب‌بندی کنید. این مقاله به رنگ‌های پس‌زمینه، شفافیت، فاصله بین حروف، ویژگی‌های قلم، چرخش، فاصله پاراگراف، رفتار autofit، لنگر متن، توقف‌های تب و تنظیمات زبان می‌پردازد.

مگر آنکه خلاف آن ذکر شود، مثال‌ها از [sample.pptx](sample.pptx) استفاده می‌کنند. اولین شکل در اولین اسلاید یک جعبهٔ متن است و اولین پاراگراف آن شامل متنی است که در زیر نشان داده شده است. هر دو شاخص اسلاید و شکل صفر‑پایه هستند. مثال‌هایی که بخش‌های بولد را انتخاب می‌کنند از قالب‌بندی مؤثر استفاده می‌کنند، شامل قالب‌بندی بولد ارث‌بری:

![نمونه متن](sample_text.png)

برای یافتن و برجسته‌سازی متن دقیق یا مطابقت با عبارات منظم، به [جستجو و جایگزینی متن](/slides/fa/net/search-and-replace-text/) مراجعه کنید.

## **تنظیم رنگ پس‌زمینه متن**

از [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaultportionformat/) برای تنظیم رنگ برجسته پیش‌فرض یک پاراگراف استفاده کنید، یا از [IBasePortionFormat.HighlightColor](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/highlightcolor/) برای بخش‌های متنی جداگانه استفاده کنید.

مثال زیر یک برجستهٔ خاکستیر روشن را به عنوان پیش‌فرض برای اولین پاراگراف تنظیم می‌کند. رنگ‌های برجستهٔ صریح در بخش‌های جداگانه بر این پیش‌فرض اولویت دارند:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// رنگ برجسته را برای کل پاراگراف تنظیم کنید.
paragraph.ParagraphFormat.DefaultPortionFormat.HighlightColor.Color = Color.LightGray;

presentation.Save("gray_paragraph.pptx", SaveFormat.Pptx);
```

نتیجه:

![پاراگراف خاکستری](gray_paragraph.png)

کد زیر نشان می‌دهد چطور رنگ پس‌زمینه را برای **بخش‌های متنی با قلم بولد** تنظیم کنید:

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
        // رنگ برجسته را برای بخش متن تنظیم کنید.
        portion.PortionFormat.HighlightColor.Color = Color.LightGray;
    }
}

presentation.Save("gray_text_portions.pptx", SaveFormat.Pptx);
```

نتیجه:

![بخش‌های متنی خاکستری](gray_text_portions.png)

## **تراز پاراگراف‌های متن**

از [IParagraphFormat.Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) برای تنظیم تراز پاراگراف درون یک قاب متن استفاده کنید. مقدار می‌تواند centered، left‑aligned، right‑aligned، justified و غیره باشد.

مثال زیر نشان می‌دهد چطور پاراگراف را به **مرکز** تراز کنید:

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

از [IParagraphFormat.FontAlignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/fontalignment/) برای تراز عمودی بخش‌های متنی با اندازه‌های قلم متفاوت در یک خط استفاده کنید. این تنظیم برای کل پاراگراف اعمال می‌شود و تراز را در هر یک از خطوط آن کنترل می‌کند.

مثال خودکفا زیر چهار جعبهٔ متن برچسب‌دار را روی یک اسلاید ایجاد می‌کند. هر پاراگراف همان متن را با اندازه‌های ۱۸، ۳۶ و ۵۴ پوینت دارد و تراز قلم متفاوتی دارد. این مثال از Arial استفاده می‌کند، autofit و wrapping را غیرفعال می‌کند و قاب‌های متن را به اندازه‌ای کافی بزرگ نگه می‌دارد تا فقط یک خط را در بر بگیرد.

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

![مقایسهٔ تراز Baseline، Top، Center و Bottom با اندازه‌های قلم ترکیبی](font_alignment.png)

تراز قلم از معیارهای متریک قلم استفاده می‌کند، بنابراین لبه‌های قابل مشاهدهٔ حروف جداگانه لزوماً دقیقاً هم‌سطح نیستند. مثال شامل یک حرف بزرگ و یک حرف descend‌دار است تا تفاوت بین تراز baseline و bottom را نشان دهد. در دسترس بودن قلم و جایگزینی، حروف استفاده شده و تفاوت در اندازه‌های قلم بر نتیجه تأثیر می‌گذارند. ابعاد قاب، حاشیه‌ها، فاصله خطوط، wrapping و autofit نیز بر چیدمان تأثیر دارند؛ برای مقایسهٔ حالت‌ها از همان قلم‌ها و تنظیمات چیدمان استفاده کنید.

این تنظیم متفاوت از [IParagraphFormat.Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) است که تراز افقی پاراگراف را کنترل می‌کند، و از [ITextFrameFormat.AnchoringType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/anchoringtype/) که بلوک متن را عمودی درون شکل موقعیت می‌دهد. قالب‌بندی‌ superscript و subscript از طریق [IBasePortionFormat.Escapement](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/escapement/) بخش‌های جداگانه را نسبت به baseline جابه‌جا می‌کند به‌جای تنظیم تراز قلم برای خطوط پاراگراف.

## **تنظیم شفافیت برای متن**

شفافیت متن از طریق مؤلفهٔ آلفای رنگی که به [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fillformat/) اختصاص داده می‌شود، کنترل می‌شود. در مثال‌های زیر، `alpha = 50` مقدار آلفای ARGB در مقیاس ۰–۲۵۵ است، نه درصد شفافیت.

کد زیر نشان می‌دهد چطور شفافیت را به **کل پاراگراف** اعمال کنید:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

var alpha = 50;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// تنظیم پرکردن مشکی نیمه‌شفاف برای متن.
paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Black);

presentation.Save("transparent_paragraph.pptx", SaveFormat.Pptx);
```

نتیجه:

![پاراگراف شفاف](transparent_paragraph.png)

مثال زیر نشان می‌دهد چطور شفافیت را به **بخش‌های متنی با قلم بولد** اعمال کنید:

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

## **تنظیم فاصلهٔ حروف برای متن**

از [IBasePortionFormat.Spacing](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/spacing/) برای گسترش یا فشرده‌سازی فاصله بین حروف در یک جعبهٔ متن استفاده کنید. مثال‌ها ۳ پوینت فاصله اضافه می‌کنند؛ مقادیر منفی متن را فشرده می‌کند.

کد C# زیر نشان می‌دهد چطور فاصلهٔ حروف را در **کل پاراگراف** گسترش دهید:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// توجه: برای فشرده‌سازی فاصله حروف از مقادیر منفی استفاده کنید.
paragraph.ParagraphFormat.DefaultPortionFormat.Spacing = 3;  // گسترش فاصله حروف.

presentation.Save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
```

نتیجه:

![فاصلهٔ حروف در پاراگراف](character_spacing_in_paragraph.png)

کد زیر نشان می‌دهد چطور فاصلهٔ حروف را در **بخش‌های متنی با قلم بولد** گسترش دهید:

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
        // توجه: برای فشرده‌سازی فاصله حروف از مقادیر منفی استفاده کنید.
        portion.PortionFormat.Spacing = 3;  // گسترش فاصله حروف.
    }
}

presentation.Save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
```

نتیجه:

![فاصلهٔ حروف در بخش‌های متنی](character_spacing_in_text_portions.png)

### **غیرفعال کردن کرنینگ برای قلم‌های خاص**

در برخی موارد، متنی که توسط Aspose.Slides رندر می‌شود ممکن است کمی فشرده‌تر از همان متن در PowerPoint ظاهر شود. این می‌تواند به این دلیل باشد که PowerPoint ممکن است داده‌های کرنینگ را برای برخی قلم‌ها نادیده بگیرد، حتی زمانی که قلم دارای اطلاعات کرنینگ معتبر باشد و کرنینگ در تنظیمات PowerPoint فعال باشد.

برای نزدیک‌تر شدن خروجی رندر شده به PowerPoint در چنین مواردی، می‌توانید کرنینگ را برای بخش‌های متنی که از قلم متاثر استفاده می‌کنند، غیرفعال کنید. مقدار [IBasePortionFormat.KerningMinimalSize](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/kerningminimalsize/) را بزرگ‌تر از اندازهٔ واقعی قلم تنظیم کنید. این مثال به «presentation.pptx» که اولین شکل آن یک جعبهٔ متن در اولین اسلاید است، نیاز دارد. نام‌های قلم مؤثر، شامل قلم‌های ارث‌بری، بررسی می‌شود و برای بخش‌هایی که از Roboto استفاده می‌کنند، آستانهٔ ۱۰۰ پوینت تنظیم می‌شود. این کار کرنینگ را برای بخش‌های مطابقت‌یافته با اندازهٔ قلم زیر ۱۰۰ پوینت غیرفعال می‌کند:

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

برای متن‌های مطابقت‌یافته زیر آستانه، این تنظیم از کرنینگ جلوگیری می‌کند و می‌تواند به هم‌راستایی رندر Aspose.Slides با خروجی بصری PowerPoint برای قلم‌هایی که تحت تأثیر این رفتار خاص PowerPoint هستند، کمک کند.

## **مدیریت ویژگی‌های قلم متن**

ویژگی‌های قلم می‌توانند در سطح پاراگراف از طریق [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaultportionformat/) یا در بخش‌های جداگانه از طریق [IPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/) تنظیم شوند.

مثال زیر قلم پیش‌فرض اولین پاراگراف را به ۱۲ پوینت Times New Roman با بولد، ایتالیک و زیرخط نقطه‌دار تنظیم می‌کند. قالب‌بندی صریح بر بخش‌های جداگانه بر پیش‌فرض‌ها اولویت دارد:

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

مثال زیر Times New Roman ۱۳ پوینت، قالب ایتالیک و زیرخط نقطه‌دار را به بخش‌هایی که قالب مؤثر آنها بولد است، اعمال می‌کند:

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
            // ویژگی‌های قلم را برای بخش متن تنظیم کنید.
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

از [IBasePortionFormat.NormaliseHeight](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/normaliseheight/) زمانی استفاده کنید که می‌خواهید تایپوگرافی قالب یا تفاوت‌های ارتفاع حروف را بررسی کنید. در PowerPoint، فعال‌سازی نرمال‌سازی حروف را به صورت عمودی کشیده یا فشرده می‌کند تا ارتفاع قابل مشاهدهٔ یکسانی درون بخش متن داشته باشند. این کار تضمین نمی‌کند که ارتفاع متون در قلم‌های مختلف برابر باشد.

خاصیت را به [NullableBool.True یا False](https://reference.aspose.com/slides/net/aspose.slides/nullablebool/) تنظیم کنید تا به‌صورت صریح نرمال‌سازی را فعال یا غیرفعال کنید. `NullableBool.NotDefined` تنظیم محلی را خالی می‌گذارد تا بخش مقدار را از پاراگراف (مثلاً از [DefaultPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaultportionformat/)) به ارث ببرد. این به معنای `False` نیست. از [IPortionFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/geteffective/) و [IBasePortionFormatEffectiveData.NormaliseHeight](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformateffectivedata/normaliseheight/) برای دریافت مقدار Boolean حل‌شده استفاده کنید.

مثال خودکفا زیر برای اجرا نیاز به نصب **Arial** دارد. دو بلوک متن حاوی حروف بزرگ، حروف کوچک، حروف زیرخطی و کاراکترهای لهیفهٔ ۵۴ پوینت ایجاد می‌کند. هر دو پاراگراف به‌طور پیش‌فرض نرمال‌سازی را فعال می‌کنند. بخش بالایی صراحتاً آن را غیرفعال می‌کند؛ بخش پایینی ارث می‌برد. اندازه‌های قاب، حاشیه‌ها و فاصله پاراگراف یکسان هستند و wrapping و autofit غیرفعال هستند تا مقایسه ثابت بماند. مثال `False: False` و `NotDefined: True` را چاپ می‌کند و «text_height_normalization.pptx» را ذخیره می‌کند.

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

مقایسهٔ زیر از ارائه ذخیره‌شده استخراج شده است. ردیف بالا نرمال‌سازی غیرفعال (`False`) دارد؛ ردیف پایین مقدار ارث‌بری فعال (`NotDefined` → `True`) را نشان می‌دهد. برای بازآفرینی این ظاهر، Arial باید نصب باشد.

![متن ۵۴‑پوینتی Arial با نرمال‌سازی غیرفعال در بالا و نرمال‌سازی ارث‌بری در پایین](text_height_normalization.png)

نرمال‌سازی ارتفاع حروف را بدون تغییر مقدار [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fontheight/) که اندازهٔ قلم را به پوینت مشخص می‌کند، تغییر می‌دهد. [SpaceWithin](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacewithin/) فاصله خطوط را کنترل می‌کند، در حالی که [AutofitType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/autofittype/) نحوهٔ تنظیم متن یا محفظهٔ آن را برای جا شدن تعیین می‌کند. این تنظیمات مقاصد متفاوتی دارند و می‌توانند به‌صورت مستقل بر طرح کلی تأثیر بگذارند. برای اطلاعات بیشتر دربارهٔ قالب‌بندی پاراگراف و ارث‌بری، به [مدیریت پاراگراف](/slides/fa/net/manage-paragraph/) مراجعه کنید.

## **اعمال و حذف Strikethrough**

از [IBasePortionFormat.StrikethroughType](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/strikethroughtype/) برای یک بخش متنی استفاده کنید تا اصلاحات، عبارات لغو شده یا قیمت‌های قبلی را بدون حذف متن اصلی نشان دهید. برای یک یا دو خط عبور از متن، آن را به‌صورت [TextStrikethroughType.Single یا Double](https://reference.aspose.com/slides/net/aspose.slides/textstrikethroughtype/) تنظیم کنید.

برای حذف strikethrough، `TextStrikethroughType.None` را اختصاص دهید. این صراحتاً اثر را غیرفعال می‌کند، حتی اگر قالب‌بندی اطراف strikethrough را مشخص کرده باشد. در مقابل، `TextStrikethroughType.NotDefined` تنظیم محلی را تعریف نشده می‌گذارد تا بخش بتواند قالب‌بندی را از پاراگراف به ارث ببرد. این تضمین نمی‌کند که strikethrough حذف شود. برای خواندن قالب‌بندی نهایی، شامل مقادیر ارث‌بری، از [IPortionFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/geteffective/) استفاده کنید.

مثال خودکفا زیر سه مقایسهٔ قیمتی ایجاد می‌کند. هر پاراگراف بخش‌های جداگانه‌ای برای برچسب، قیمت قبلی و قیمت فعلی دارد، به‌طوری که فقط قیمت قبلی تحت تأثیر قرار می‌گیرد. ردیف اول strikethrough را اعمال می‌کند و سپس حذف می‌کند؛ ردیف‌های دیگر به ترتیب strikethrough تک‌خطی و دوخطی را حفظ می‌کنند. تغییر این ویژگی متن و سایر قالب‌بندی‌های آن، از جمله بولد بودن قیمت قبلی، را حفظ می‌کند.

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

// Apply strikethrough, then explicitly remove it from the first previous price.
paragraphs[0].Portions[1].PortionFormat.StrikethroughType = TextStrikethroughType.Single;
paragraphs[0].Portions[1].PortionFormat.StrikethroughType = TextStrikethroughType.None;

paragraphs[1].Portions[1].PortionFormat.StrikethroughType = TextStrikethroughType.Single;
paragraphs[2].Portions[1].PortionFormat.StrikethroughType = TextStrikethroughType.Double;

presentation.Save("strikethrough.pptx", SaveFormat.Pptx);
```

نتیجه، از بالا به پایین: بدون strikethrough، strikethrough تک‌خطی، و strikethrough دوخطی.

![قیمت‌های قبلی بدون strikethrough، با strikethrough تک‌خطی و با strikethrough دوخطی](strikethrough.png)

## **تنظیم چرخش متن**

از [ITextFrameFormat.TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/textverticaltype/) برای تنظیم جهت‌گیری پیش‌فرض متن درون یک شکل استفاده کنید.

کد زیر جهت‌گیری متن در شکل را به [TextVerticalType.Vertical270](https://reference.aspose.com/slides/net/aspose.slides/textverticaltype/) تنظیم می‌کند که متن را **۹۰ درجه خلاف ساعت** می‌چرخاند:

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

## **تنظیم چرخش سفارشی برای قاب‌های متن**

از [ITextFrameFormat.RotationAngle](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/rotationangle/) برای تنظیم زاویهٔ چرخش سفارشی یک [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) استفاده کنید.

کد زیر قاب متن را داخل شکل ۳ درجه ساعتگرد می‌چرخاند:

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

## **تنظیم فاصله خطوط پاراگراف‌ها**

Aspose.Slides ارائه می‌دهد [IParagraphFormat.SpaceAfter](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spaceafter/)، [IParagraphFormat.SpaceBefore](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacebefore/)، و [IParagraphFormat.SpaceWithin](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacewithin/) برای کنترل فاصله پاراگراف. این خصوصیات به‌صورت زیر استفاده می‌شوند:

* برای مشخص کردن فاصله خط به‌عنوان درصدی از ارتفاع خط، مقدار مثبت استفاده کنید.
* برای مشخص کردن فاصله خط به‌واحد پوینت، مقدار منفی استفاده کنید.

مثال زیر فاصلهٔ داخل اولین پاراگراف را به ۲۰۰٪ ارتفاع خط (دوبل اسپیسینگ) تنظیم می‌کند:

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

![فاصلهٔ خط درون پاراگراف](line_spacing.png)

## **کنترل شکستن خطوط**

قوانین شکستن خطوط پاراگراف در بلوک‌های متن باریک و ارائه‌هایی که متن لاتین و شرق آسیا را ترکیب می‌کنند، مفید هستند. این خصوصیات متعلق به [IParagraphFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/) هستند، بنابراین بر کل پاراگراف اعمال می‌شوند:

- [LatinLineBreak](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/latinlinebreak/) قوانین شکستن خطوط لاتین را کنترل می‌کند. در متن ترکیبی، تغییر آن می‌تواند مکان بسته شدن متن و علائم نقطه‌گذاری شرق آسیا را نیز تغییر دهد.
- [EastAsianLineBreak](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/eastasianlinebreak/) قوانین شکستن خطوط شرق آسیا را کنترل می‌کند، از جمله محدودیت‌های کاراکتر در ابتدای و انتهای خط.

این قوانین جایگزین [ITextFrameFormat.WrapText](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/wraptext/) نمی‌شوند که wrapping خودکار را درون یک قاب متن فعال می‌کند. آنها بر چیدمان هنگام wrapping تأثیر می‌گذارند؛ کاراکترهای newline را وارد نمی‌کنند. یک شکستن خط صریح یک خط جدید را درون پاراگراف مستقل از عرض موجود ایجاد می‌کند.

مثال خودکفا زیر بلوک متن باریکی شامل چینی و لاتین ایجاد می‌کند. هر دو خصوصیت شکستن خط به‌صورت صریح تنظیم شده و «line_breaking.pptx» ذخیره می‌شود. برای آزمایش هر یک از قوانین، مقدار آن خصوصیت را تغییر دهید و تنظیم دیگر را ثابت نگه دارید. مثال از Arial ۲۴ پوینت و SimSun با عرض قاب ۱۶۰ پوینت و حاشیه افقی صفر استفاده می‌کند. [ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/autofittype/) به [TextAutofitType.None](https://reference.aspose.com/slides/net/aspose.slides/textautofittype/) تنظیم شده تا اندازهٔ متن و ابعاد قاب ثابت بمانند.

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

## **کنترل علائم نقطه‌گذاری معلق**

[IParagraphFormat.HangingPunctuation](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/hangingpunctuation/) اجازه می‌دهد علائم نقطه‌گذاری واجد شرایط فراتر از لبهٔ راست خط متن گسترش یابند به‌جای اینکه در خط بعدی جای بگیرند. این ویژگی برای کل پاراگراف اعمال می‌شود و متفاوت از تورفتگی معلق است.

مثال خودکفا زیر علائم نقطه‌گذاری معلق را در قاب متنی با عرض ۱۰۰ پوینت فعال می‌کند و «hanging_punctuation.pptx» ذخیره می‌شود. با Arial ۲۴ پوینت و حاشیه افقی صفر، نقطهٔ نهایی پس از «جمله» می‌ماند و فراتر از لبهٔ راست متن گسترش می‌یابد. برای مقایسه، ویژگی را به [NullableBool.False](https://reference.aspose.com/slides/net/aspose.slides/nullablebool/) تنظیم کنید: با این تنظیمات، نقطه در یک خط جداگانه قرار می‌گیرد. wrapping فعال و autofit غیرفعال است تا عرض موجود ثابت بماند.

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

هر علامت نقطه‌گذاری نمی‌تواند معلق باشد. شرایط قلم و چیدمان توضیح داده شده در [Control line breaking](#control-line-breaking) نیز برای این مقایسه اعمال می‌شود: تغییر قلم، عرض موجود، حاشیه‌ها یا تنظیمات autofit می‌تواند تفاوت قابل مشاهده را از بین ببرد.

## **تنظیم نوع Autofit برای قاب‌های متن**

[ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/autofittype/) تعیین می‌کند متن وقتی بیش از مرزهای محفظهٔ خود باشد، چگونه رفتار کند. از آن برای کنترل اینکه آیا متن کوچک شود، overflow کند یا به‌صورت خودکار شکل را تغییر اندازه دهد، استفاده کنید. مثال زیر شکل را طوری تنظیم می‌کند که برای متنش به‌طور خودکار تغییر اندازه دهد و نتیجه در «autofit_type.pptx» ذخیره می‌شود.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;

presentation.Save("autofit_type.pptx", SaveFormat.Pptx);
```

برای شمارش خطوط پس از wrapping خودکار و مشاهدهٔ تغییرات عرض متن یا شکل، به [Count Rendered Lines](/slides/fa/net/manage-paragraph/) مراجعه کنید. شمارش خطوط به‌تنهایی نشان نمی‌دهد آیا متن از محفظه‌اش عبور می‌کند یا خیر.

## **تنظیم لنگر قاب‌های متن**

[ITextFrameFormat.AnchoringType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/anchoringtype/) تعیین می‌کند متن به صورت عمودی داخل یک شکل چگونه موقعیت یابد، مثلاً در بالا، وسط یا پایین. مثال زیر متن را به پایین اولین شکل لنگر می‌کند و نتیجه را در «text_anchor.pptx» ذخیره می‌کند.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.AnchoringType = TextAnchorType.Bottom;

presentation.Save("text_anchor.pptx", SaveFormat.Pptx);
```

## **تنظیم تب‌های متن**

از [IParagraphFormat.DefaultTabSize](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaulttabsize/) و [IParagraphFormat.Tabs](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/tabs/) برای پیکربندی توقف‌های تب در یک پاراگراف استفاده کنید. مثال زیر فاصلهٔ پیش‌فرض تب را به ۱۰۰ پوینت تنظیم می‌کند و یک توقف تب چپ‌تراز را در ۳۰ پوینت اضافه می‌کند. این تنظیمات بر متنی که شامل کاراکتر تب است تأثیر می‌گذارد.

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

## **تنظیم زبان تصحیح املایی**

Aspose.Slides ارائه می‌دهد [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/languageid/)، که به شما امکان می‌دهد زبان تصحیح املایی برای یک بخش متن را تنظیم کنید. زبان تصحیح املایی تعیین می‌کند که PowerPoint چه زبانی را برای بررسی املا و گرامر استفاده کند.

مثال زیر به «presentation.pptx» که اولین شکل آن یک جعبهٔ متن در اولین اسلاید است و حداقل یک پاراگراف دارد، نیاز دارد. محتویات اولین پاراگراف را با «1。» جایگزین می‌کند، SimSun را به عنوان قلم آن تنظیم می‌کند و زبان تصحیح Simplified Chinese (`zh-CN`) را اختصاص می‌دهد. نتیجه در «proofing_language.pptx» ذخیره می‌شود:

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

// زبان تصحیح املایی را به چینی ساده تنظیم کنید.
textPortion.PortionFormat.LanguageId = "zh-CN";

textPortion.Text = "1。";
paragraph.Portions.Add(textPortion);

presentation.Save("proofing_language.pptx", SaveFormat.Pptx);
```

### **کپی متادیتای زبان**

هنگام کپی متن چندزبانه از یک قالب، هر دو [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/languageid/) و [IBasePortionFormat.AlternativeLanguageId](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/alternativelanguageid/) را حفظ کنید. مثال خودکفا زیر یک بخش منبع با زبان US English و زبان جایگزین French ایجاد می‌کند و متن و شناسه‌ها را به یک بخش در ارائهٔ جدید کپی می‌کند.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

var source = new Portion("Hello! Bonjour!");
source.PortionFormat.LanguageId = "en-US";
source.PortionFormat.AlternativeLanguageId = "fr-FR";

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 80);
var paragraph = shape.TextFrame.Paragraphs[0];
paragraph.Portions.Clear();

var destination = new Portion();
destination.Text = source.Text;
destination.PortionFormat.LanguageId = source.PortionFormat.LanguageId;
// اگر منبع زبان جایگزین نداشته باشد، null مقدار مقصد را پاک می‌کند.
destination.PortionFormat.AlternativeLanguageId = source.PortionFormat.AlternativeLanguageId;
paragraph.Portions.Add(destination);

presentation.Save("copied_language_metadata.pptx", SaveFormat.Pptx);
```

برای آزمایش منبع بدون زبان جایگزین، اختصاص `"fr-FR"` را حذف کنید. در این صورت شناسهٔ جایگزین `null` خواهد بود و همان عبارت کپی عدم وجود را بدون افزودن مقدار پیش‌فرض حفظ می‌کند، حتی اگر مقصد قبلاً زبان جایگزین داشته باشد.

این شناسه‌ها متادیتای زبان را ذخیره می‌کنند. حفظ آنها تعیین نمی‌کند که PowerPoint برای املا یا بررسی گرامر کدام لغت‌نامه را انتخاب می‌کند.

## **تنظیم زبان پیش‌فرض**

از [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/defaulttextlanguage/) برای تعریف زبان پیش‌فرض متنی که هنگام بارگذاری یا ایجاد یک ارائه ایجاد می‌شود، استفاده کنید. مثال زیر ارائه‌ای با زبان پیش‌فرض US English ایجاد می‌کند، یک جعبهٔ متن اضافه می‌کند و `en-US` را برای اولین بخش متن آن چاپ می‌کند.

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

// زبان اولین بخش متن را بررسی کنید.
var portion = shape.TextFrame.Paragraphs[0].Portions[0];
Console.WriteLine(portion.PortionFormat.LanguageId);
```

## **تنظیم سبک پیش‌فرض متن**

برای اعمال قالب‌بندی پیش‌فرض متن در سطح ارائه، از [IPresentation.DefaultTextStyle](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/defaulttextstyle/) استفاده کنید.

مثال زیر قلم ۱۴‑پوینت Bold را به‌عنوان پیش‌فرض برای پاراگراف‌های سطح بالا در یک ارائهٔ جدید تنظیم می‌کند و آن را در «default_text_style.pptx» ذخیره می‌کند. متن می‌تواند این پیش‌فرض‌ها را ارث ببرد مگر این‌که قالب‌بندی خاص‌تر آنها را لغو کند.

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

## **استخراج متن با اثر All‑Caps**

در PowerPoint، اعمال اثر فونت **All Caps** باعث می‌شود متن در اسلاید به حروف بزرگ نمایش داده شود حتی اگر به‌صورت حروف کوچک وارد شده باشد. وقتی چنین بخشی از متن را با Aspose.Slides دریافت می‌کنید، کتابخانه دقیقاً همان متن وارد شده را برمی‌گرداند. برای مطابقت با متنی که نمایش داده می‌شود، [TextCapType](https://reference.aspose.com/slides/net/aspose.slides/textcaptype/) را بررسی کنید و رشتهٔ بازگشتی را به حروف بزرگ تبدیل کنید وقتی مقدار `All` باشد.

این مثال به «sample2.pptx» که اولین شکل آن یک جعبهٔ متن در اولین اسلاید است، نیاز دارد. اولین پاراگراف آن اولین بخش «Hello, Aspose!» را دارد که اثر All Caps روی آن اعمال شده است، همان‌طور که در زیر نشان داده شده است.

![اثر All Caps](all_caps_effect.png)

کد زیر نشان می‌دهد چطور متن را با اثر **All Caps** استخراج کنید:

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

## **FAQ**

**چگونه متن داخل یک جدول را در یک اسلاید ویرایش کنم؟**

برای ویرایش متن داخل یک جدول در اسلاید، از [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) استفاده کنید. از طریق حلقه‌گذاری بر سلول‌ها و به‌روزرسانی هر سلول از طریق [ICell.TextFrame](https://reference.aspose.com/slides/net/aspose.slides/icell/textframe/) و قالب‌بندی پاراگراف از طریق [IParagraph.ParagraphFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/paragraphformat/) عمل کنید.

**چگونه رنگ گرادیان را به متن در یک اسلاید PowerPoint اعمال کنم؟**

برای اعمال رنگ گرادیان به متن، از [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fillformat/) استفاده کنید. [IFillFormat.FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) را به [FillType.Gradient](https://reference.aspose.com/slides/net/aspose.slides/filltype/) تنظیم کنید و توقف‌های گرادیان، جهت و شفافیت را پیکربندی کنید.

ویژگی مرتبط: [قالب‌بندی متن درون اسلایدها](/slides/fa/features/text-formatting/).