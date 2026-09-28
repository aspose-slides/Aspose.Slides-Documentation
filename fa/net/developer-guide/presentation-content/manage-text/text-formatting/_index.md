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
- ویژگی خودسازگار
- لنگر قاب متن
- تب‌بندی متن
- زبان پیش‌فرض
- PowerPoint
- OpenDocument
- ارائه
- .NET
- C#
- Aspose.Slides
description: "متن را در ارائه‌های PowerPoint و OpenDocument با استفاده از Aspose.Slides برای .NET قالب‌بندی و استایل‌دهی کنید. قلم‌ها، رنگ‌ها، تراز و موارد دیگر را سفارشی کنید."
---
## **مرور کلی**

این مقاله نحوه قالب‌بندی متن در ارائه‌های PowerPoint و OpenDocument با استفاده از Aspose.Slides برای .NET را نشان می‌دهد. این مقاله شامل رنگ‌های پس‌زمینه، شفافیت، فاصله بین کاراکترها، ویژگی‌های قلم، چرخش، فاصله‌بندی پاراگراف، رفتار خودسازگار، تنظیمات لنگر متن، توقف‌های تب و تنظیمات زبان می‌شود.

به‌جز مواردی که خلاف آن ذکر شده باشد، مثال‌ها از [sample.pptx](sample.pptx) استفاده می‌کنند. اولین شکل در اسلاید اول یک جعبه متن است و پاراگراف اول آن شامل متنی است که در زیر نشان داده شده است. هر دو شاخص اسلاید و شکل به‌صورت صفر‑پایه هستند. مثال‌هایی که بخش‌های بولد را انتخاب می‌کنند از قالب‌بندی مؤثر، شامل قالب‌بندی بولد ارث‌بری، استفاده می‌کنند:

![متن نمونه](sample_text.png)

برای یافتن و برجسته‌سازی متن به‌صورت دقیق یا مطابقت‌های عبارات منظم، به [جستجو و جایگزینی متن](/slides/fa/net/search-and-replace-text/) مراجعه کنید.

## **تنظیم رنگ پس‌زمینه متن**

از [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/iparagraphformat/defaultportionformat/) برای تنظیم رنگ برجسته پیش‌فرض یک پاراگراف استفاده کنید، یا از [IBasePortionFormat.HighlightColor](https://reference.aspose.com/slides/fa/net/aspose.slides/ibaseportionformat/highlightcolor/) برای بخش‌های متنی جداگانه استفاده کنید.

مثال زیر یک برجسته خاکستری روشن را به‌عنوان پیش‌فرض برای پاراگراف اول تنظیم می‌کند. رنگ‌های برجسته صریح روی بخش‌های جداگانه بر این پیش‌فرض اولویت دارند:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// تنظیم رنگ برجسته برای تمام پاراگراف.
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
        // تنظیم رنگ برجسته برای بخش متن.
        portion.PortionFormat.HighlightColor.Color = Color.LightGray;
    }
}

presentation.Save("gray_text_portions.pptx", SaveFormat.Pptx);
```

نتیجه:

![بخش‌های متنی خاکستری](gray_text_portions.png)

## **تراز پاراگراف‌های متن**

از [IParagraphFormat.Alignment](https://reference.aspose.com/slides/fa/net/aspose.slides/iparagraphformat/alignment/) برای تنظیم تراز پاراگراف داخل چهارچوب متن استفاده کنید. مقدار می‌تواند وسط، چپ، راست، توجیه‌شده و غیره باشد.

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

## **تنظیم شفافیت متن**

شفافیت متن از طریق مؤلفه alpha رنگی که به [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/ibaseportionformat/fillformat/) اختصاص داده می‌شود، کنترل می‌شود. در مثال‌های زیر، `alpha = 50` مقدار کانال alpha ARGB در مقیاس 0–255 است، نه درصد شفافیت.

کد زیر نشان می‌دهد چطور شفافیت را به **تمام پاراگراف** اعمال کنید:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

var alpha = 50;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// تنظیم پر کردن مشکی نیمه‌شفاف برای متن.
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

## **تنظیم فاصله کاراکترهای متن**

از [IBasePortionFormat.Spacing](https://reference.aspose.com/slides/fa/net/aspose.slides/ibaseportionformat/spacing/) برای افزایش یا کاهش فاصله بین کاراکترها در یک جعبه متن استفاده کنید. مثال‌ها 3 point فاصله اضافه می‌کنند؛ مقادیر منفی متن را متراکم می‌کنند.

کد C# زیر نشان می‌دهد چطور فاصله کاراکترها را در **تمام پاراگراف** گسترش دهید:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// توجه: برای فشرده‌سازی فاصله کاراکتر از مقادیر منفی استفاده کنید.
paragraph.ParagraphFormat.DefaultPortionFormat.Spacing = 3;  // گسترش فاصله کاراکتر.

presentation.Save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
```

نتیجه:

![فاصله کاراکترها در پاراگراف](character_spacing_in_paragraph.png)

کد زیر نشان می‌دهد چطور فاصله کاراکترها را در **بخش‌های متنی با قلم بولد** گسترش دهید:

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
        // توجه: برای فشرده‌سازی فاصله کاراکتر از مقادیر منفی استفاده کنید.
        portion.PortionFormat.Spacing = 3;  // گسترش فاصله کاراکتر.
    }
}

presentation.Save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
```

نتیجه:

![فاصله کاراکترها در بخش‌های متنی](character_spacing_in_text_portions.png)

### **غیرفعال‌سازی Kerning برای قلم‌های خاص**

در برخی موارد، متنی که توسط Aspose.Slides رندر می‌شود ممکن است کمی فشرده‌تر از متن مشابه در PowerPoint به نظر برسد. این می‌تواند به این دلیل باشد که PowerPoint داده‌های kerning را برای برخی قلم‌ها نادیده می‌گیرد، حتی اگر قلم اطلاعات کرنینگ معتبر داشته باشد و تنظیمات کرنینگ در PowerPoint فعال باشد.

برای نزدیک‌تر کردن خروجی رندر شده به PowerPoint در چنین شرایطی، می‌توانید kerning را برای بخش‌های متنی که از قلم موردنظر استفاده می‌کنند غیرفعال کنید. مقدار [IBasePortionFormat.KerningMinimalSize](https://reference.aspose.com/slides/fa/net/aspose.slides/ibaseportionformat/kerningminimalsize/) را بزرگ‌تر از اندازه واقعی قلم تنظیم کنید. این مثال نیاز به «presentation.pptx» دارد که جعبه متن به‌عنوان اولین شکل در اسلاید اول داشته باشد. این مثال نام‌های قلم مؤثر، از جمله قلم‌های ارث‌بری را بررسی می‌کند و برای بخش‌هایی که از Roboto استفاده می‌کنند آستانه 100 point را تنظیم می‌کند: این کار kerning را برای بخش‌های مطابقت دهنده با اندازه قلم زیر 100 point غیرفعال می‌کند:

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

برای متنی که زیر آستانه است، این تنظیم kerning را جلوگیری می‌کند و می‌تواند به هم‌راستای کردن رندر Aspose.Slides با خروجی بصری PowerPoint برای قلم‌های تحت تأثیر این رفتار خاص PowerPoint کمک کند.

## **مدیریت ویژگی‌های قلم متن**

ویژگی‌های قلم می‌توانند در سطح پاراگراف از طریق [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/iparagraphformat/defaultportionformat/) یا در بخش‌های جداگانه از طریق [IPortionFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/iportionformat/) تنظیم شوند.

مثال زیر قلم پیش‌فرض پاراگراف اول را به 12‑point Times New Roman با بولد، ایتالیک و خط زیر نقطه‌ای تنظیم می‌کند. قالب‌بندی صریح بر بخش‌های جداگانه بر این پیش‌فرض‌ها اولویت دارد:

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

مثال زیر 13‑point Times New Roman، قالب ایتالیک و خط زیر نقطه‌ای را به بخش‌هایی که قالب مؤثر آنها بولد است، اعمال می‌کند:

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
        // تنظیم ویژگی‌های قلم برای بخش متن.
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

## **تنظیم چرخش متن**

از [ITextFrameFormat.TextVerticalType](https://reference.aspose.com/slides/fa/net/aspose.slides/itextframeformat/textverticaltype/) برای تنظیم جهت پیش‌تعریف‌شده متن داخل یک شکل استفاده کنید.

کد زیر جهت متن در شکل را به [TextVerticalType.Vertical270](https://reference.aspose.com/slides/fa/net/aspose.slides/textverticaltype/) تنظیم می‌کند که متن را **90 درجه خلاف ساعت‌گرد** می‌چرخاند:

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

از [ITextFrameFormat.RotationAngle](https://reference.aspose.com/slides/fa/net/aspose.slides/itextframeformat/rotationangle/) برای تنظیم زاویه چرخش دلخواه یک [ITextFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/itextframe/) استفاده کنید.

کد زیر فریم متن را داخل شکل به‌صورت 3  درجه ساعت‌گرد می‌چرخاند:

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

Aspose.Slides موارد [IParagraphFormat.SpaceAfter](https://reference.aspose.com/slides/fa/net/aspose.slides/iparagraphformat/spaceafter/)، [IParagraphFormat.SpaceBefore](https://reference.aspose.com/slides/fa/net/aspose.slides/iparagraphformat/spacebefore/) و [IParagraphFormat.SpaceWithin](https://reference.aspose.com/slides/fa/net/aspose.slides/iparagraphformat/spacewithin/) را برای کنترل فاصله پاراگراف فراهم می‌کند. این ویژگی‌ها به‌صورت زیر استفاده می‌شوند:

* برای مشخص کردن فاصله خط به‌عنوان درصدی از ارتفاع خط، مقدار مثبت استفاده کنید.
* برای مشخص کردن فاصله خط به‌واحد پوینت، مقدار منفی استفاده کنید.

مثال زیر فاصله داخل اولین پاراگراف را به 200 % از ارتفاع خط (دو برابر) تنظیم می‌کند:

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

قواعد شکست خط پاراگراف در بلوک‌های متنی باریک و ارائه‌های ترکیبی لاتین و متون آسیای شرقی مفید هستند. ویژگی‌های زیر به [IParagraphFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/iparagraphformat/) تعلق دارند، بنابراین بر کل پاراگراف اعمال می‌شوند:

- [LatinLineBreak](https://reference.aspose.com/slides/fa/net/aspose.slides/iparagraphformat/latinlinebreak/) قوانین شکست خط لاتین را کنترل می‌کند. در متن ترکیبی، تغییر آن می‌تواند محل پیچش متن و نقطه‌گذاری آسیای شرقی را نیز تغییر دهد.
- [EastAsianLineBreak](https://reference.aspose.com/slides/fa/net/aspose.slides/iparagraphformat/eastasianlinebreak/) قوانین شکست خط آسیای شرقی را کنترل می‌کند، از جمله محدودیت‌های کاراکترهای ابتدا و انتهای خط.

این قوانین جایگزین [ITextFrameFormat.WrapText](https://reference.aspose.com/slides/fa/net/aspose.slides/itextframeformat/wraptext/) نمی‌شوند، که امکان پیچش خودکار داخل فریم متن را فعال می‌کند. آن‌ها فقط نحوه چینش را هنگام پیچش تحت تأثیر قرار می‌دهند؛ کاراکترهای شکست خط را درج نمی‌کنند. یک شکست خط صریح یک خط جدید در داخل پاراگراف ایجاد می‌کند بدون توجه به عرض موجود.

مثال زیر یک بلوک متنی باریک حاوی متون چینی و لاتین می‌سازد، هر دو ویژگی شکست خط را به‌صورت صریح تنظیم می‌کند و «line_breaking.pptx» را ذخیره می‌کند. برای آزمایش هر یک از قوانین، مقدار ویژگی مربوطه را تغییر دهید در حالی که تنظیمات دیگر ثابت می‌مانند. این مثال از Arial 24‑point و SimSun با عرض فریم 160 point و حاشیه افقی صفر استفاده می‌کند. [ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/fa/net/aspose.slides/itextframeformat/autofittype/) بر روی [TextAutofitType.None](https://reference.aspose.com/slides/fa/net/aspose.slides/textautofittype/) تنظیم شده تا اندازه متن و ابعاد فریم ثابت بمانند.

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

## **کنترل نقطه‌گذاری تعلیقی**

[IParagraphFormat.HangingPunctuation](https://reference.aspose.com/slides/fa/net/aspose.slides/iparagraphformat/hangingpunctuation/) به نقطه‌گذاری‌های واجد شرایط اجازه می‌دهد تا از حاشیه راست خط متن فراتر بروند به‌جای اینکه در خط بعدی قرار گیرند. این ویژگی به کل پاراگراف اعمال می‌شود و با تورفتگی معلق متفاوت است.

مثال زیر نقطه‌گذاری تعلیقی را در یک فریم متن 100‑point عرض فعال می‌کند و «hanging_punctuation.pptx» را ذخیره می‌کند. با Arial 24‑point و حاشیه افقی صفر، نقطه نهایی پس از «sentence» می‌ماند و فراتر از لبه راست متن گسترش می‌یابد. برای مقایسه، مقدار این ویژگی را به [NullableBool.False](https://reference.aspose.com/slides/fa/net/aspose.slides/nullablebool/) تنظیم کنید: با این تنظیمات، نقطه در خط جداگانه‌ای قرار می‌گیرد. پیچش فعال و autofit غیرفعال شده تا عرض موجود ثابت بماند.

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

هر نقطه‌گذاری امکان تعلیق ندارند. شرایط قلم و چینش توضیح داده‌شده در بالا نیز برای این مقایسه اعمال می‌شود: تغییر قلم، عرض موجود، حاشیه‌ها یا تنظیمات autofit می‌تواند تفاوت قابل رؤیت را از بین ببرد.

## **تنظیم نوع Autofit برای فریم‌های متن**

[ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/fa/net/aspose.slides/itextframeformat/autofittype/) تعیین می‌کند که متن هنگام عبور از مرزهای محفظه‌اش چگونه رفتار کند. از آن برای کنترل اینکه آیا متن کوچک می‌شود، بالا می‌رود یا به‌صورت خودکار شکل را تغییر اندازه می‌دهد، استفاده کنید. مثال زیر شکل را برای متناسب شدن با متن تغییر اندازه می‌دهد و نتیجه را در «autofit_type.pptx» ذخیره می‌کند:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;

presentation.Save("autofit_type.pptx", SaveFormat.Pptx);
```

برای شمارش خطوط پس از پیچش خودکار و مشاهده نحوه تغییر عرض متن یا شکل، به [شمارش خطوط رندر شده](/slides/fa/net/manage-paragraph/) مراجعه کنید. تنها شمارش خطوط بیانگر این نیست که متن از محفظه‌اش فراتر رفته است یا نه.

## **تنظیم لنگر فریم‌های متن**

[ITextFrameFormat.AnchoringType](https://reference.aspose.com/slides/fa/net/aspose.slides/itextframeformat/anchoringtype/) تعیین می‌کند که متن به صورت عمودی داخل شکل چگونه موقعیت‌یابی شود، برای مثال در بالا، وسط یا پایین. مثال زیر متن را به پایین اولین شکل لنگر می‌کند و نتیجه را در «text_anchor.pptx» ذخیره می‌کند:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.AnchoringType = TextAnchorType.Bottom;

presentation.Save("text_anchor.pptx", SaveFormat.Pptx);
```

## **تنظیم تب‌بندی متن**

از [IParagraphFormat.DefaultTabSize](https://reference.aspose.com/slides/fa/net/aspose.slides/iparagraphformat/defaulttabsize/) و [IParagraphFormat.Tabs](https://reference.aspose.com/slides/fa/net/aspose.slides/iparagraphformat/tabs/) برای پیکربندی توقف‌های تب در یک پاراگراف استفاده کنید. مثال زیر فاصله تب پیش‌فرض را به 100 point تنظیم می‌کند و یک توقف تب چپ‌تراز در 30 point اضافه می‌کند. این تنظیمات بر متنی که شامل کاراکترهای تب است تأثیر می‌گذارد.

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

## **تنظیم زبان تصحیح**

Aspose.Slides متد [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/fa/net/aspose.slides/ibaseportionformat/languageid/) را فراهم می‌کند که به شما اجازه می‌دهد زبان تصحیح برای یک بخش متنی را تنظیم کنید. زبان تصحیح تعیین می‌کند که بررسی املایی و گرامری در PowerPoint به‌کدام زبان انجام شود.

مثال زیر به «presentation.pptx» نیاز دارد که جعبه متن به‌عنوان اولین شکل در اسلاید اول داشته باشد و حداقل یک پاراگراف داشته باشد. این مثال محتوای اولین پاراگراف را با «1。」» جایگزین می‌کند، قلم را به SimSun تنظیم می‌کند و زبان تصحیح چینی ساده (`zh-CN`) را اختصاص می‌دهد. نتیجه در «proofing_language.pptx» ذخیره می‌شود:

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

// تنظیم زبان تصحیح به چینی ساده.
textPortion.PortionFormat.LanguageId = "zh-CN";

textPortion.Text = "1。";
paragraph.Portions.Add(textPortion);

presentation.Save("proofing_language.pptx", SaveFormat.Pptx);
```

## **تنظیم زبان پیش‌فرض**

از [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/fa/net/aspose.slides/loadoptions/defaulttextlanguage/) برای تعریف زبان پیش‌فرض متنی که هنگام بارگذاری یا ایجاد یک ارائه ایجاد می‌شود استفاده کنید. مثال زیر یک ارائه با زبان پیش‌فرض متن انگلیسی ایالات متحده ایجاد می‌کند، یک جعبه متن اضافه می‌کند و برای اولین بخش متنی آن «en‑US» را چاپ می‌کند.

```cs
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions();
loadOptions.DefaultTextLanguage = "en-US";

using var presentation = new Presentation(loadOptions);
var slide = presentation.Slides[0];

// اضافه کردن یک شکل مستطیل جدید با متن.
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
shape.TextFrame.Text = "Sample text";

// بررسی زبان اولین بخش متن.
var portion = shape.TextFrame.Paragraphs[0].Portions[0];
Console.WriteLine(portion.PortionFormat.LanguageId);
```

## **تنظیم سبک پیش‌فرض متن**

برای اعمال قالب‌بندی پیش‌فرض متن در سطح ارائه، از [IPresentation.DefaultTextStyle](https://reference.aspose.com/slides/fa/net/aspose.slides/ipresentation/defaulttextstyle/) استفاده کنید.

مثال زیر یک قلم بولد 14‑point را به‌عنوان پیش‌فرض برای پاراگراف‌های سطح بالایی در یک ارائه جدید تنظیم می‌کند و آن را در «default_text_style.pptx» ذخیره می‌کند. متن می‌تواند این پیش‌فرض‌ها را به ارث ببرد مگر این که قالب‌بندی خاص‌تری آنها را بازنویسی کند.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
// دریافت فرمت پاراگراف سطح بالا.
var paragraphFormat = presentation.DefaultTextStyle.GetLevel(0);

if (paragraphFormat != null)
{
    paragraphFormat.DefaultPortionFormat.FontHeight = 14;
    paragraphFormat.DefaultPortionFormat.FontBold = NullableBool.True;
}

presentation.Save("default_text_style.pptx", SaveFormat.Pptx);
```

## **استخراج متن با اثر تمام حروف بزرگ**

در PowerPoint، اعمال اثربخش **All Caps** به قلم باعث می‌شود متن روی اسلاید به‌صورت حروف بزرگ نمایش داده شود حتی اگر به‌صورت حروف کوچک وارد شده باشد. وقتی چنین بخشی از متن را با Aspose.Slides بازیابی می‌کنید، کتابخانه متن را دقیقاً همان‌گونه که وارد شده است برمی‌گرداند. برای تطبیق با متنی که نمایش داده می‌شود، [TextCapType](https://reference.aspose.com/slides/fa/net/aspose.slides/textcaptype/) را بررسی کنید و رشته بازگشتی را به حروف بزرگ تبدیل کنید وقتی مقدار آن `All` باشد.

این مثال به «sample2.pptx» نیاز دارد که جعبه متن به‌عنوان اولین شکل در اسلاید اول داشته باشد. اولین پاراگراف آن اولین بخش متنی شامل «Hello, Aspose!» با اثر All Caps دارد، همان‌طور که در زیر نشان داده شده است.

![اثر تمام حروف بزرگ](all_caps_effect.png)

کد زیر نشان می‌دهد چطور متن با اثر **All Caps** استخراج شود:

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

**چگونه متن را در یک جدول در یک اسلاید ویرایش کنم؟**

برای ویرایش متن در جدول یک اسلاید، از [ITable](https://reference.aspose.com/slides/fa/net/aspose.slides/itable/) استفاده کنید. در سلول‌ها iteration کنید و هر سلول را از طریق [ICell.TextFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/icell/textframe/) به‌روزرسانی کنید و قالب‌بندی پاراگراف را از طریق [IParagraph.ParagraphFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/iparagraph/paragraphformat/) تنظیم کنید.

**چگونه یک رنگ گرادیان به متن در یک اسلاید PowerPoint اعمال کنم؟**

برای اعمال رنگ گرادیان به متن، از [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/ibaseportionformat/fillformat/) استفاده کنید. مقدار [IFillFormat.FillType](https://reference.aspose.com/slides/fa/net/aspose.slides/ifillformat/filltype/) را به [FillType.Gradient](https://reference.aspose.com/slides/fa/net/aspose.slides/filltype/) تنظیم کنید و نقاط توقف، جهت و شفافیت گرادیان را پیکربندی نمایید.