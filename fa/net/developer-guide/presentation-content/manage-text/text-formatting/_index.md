---
title: قالب‌بندی متن ارائه در .NET
linktitle: قالب‌بندی متن
type: docs
weight: 50
url: /fa/net/text-formatting/
keywords:
- متن برجسته
- عبارت منظم
- همترازی پاراگراف
- سبک متن
- پس‌زمینه متن
- شفافیت متن
- فاصله کاراکترها
- ویژگی‌های قلم
- خانواده قلم
- چرخش متن
- زاویه چرخش
- قاب متن
- فاصله خطوط
- ویژگی Autofit
- تکیه‌گاه قاب متن
- تب بندی متن
- زبان پیش‌فرض
- PowerPoint
- OpenDocument
- ارائه
- .NET
- C#
- Aspose.Slides
description: "متن را در ارائه‌های PowerPoint و OpenDocument با استفاده از Aspose.Slides برای .NET قالب‌بندی و استایل کنید. قلم‌ها، رنگ‌ها، همترازی و موارد دیگر را سفارشی کنید."
---
## **نمای کلی**

این مقاله نشان می‌دهد که چگونه می‌توان متن را در ارائه‌های PowerPoint و OpenDocument با استفاده از Aspose.Slides برای .NET قالب‌بندی کرد. این مقاله به مواردی مانند هایلایت، رنگ پس‌زمینه، شفافیت، فاصله بین حروف، ویژگی‌های قلم، چرخش، فاصله پاراگراف، رفتار Autofit، تکیه‌گاه متن، توقف‌های تب و تنظیمات زبان پرداخته است.

در مثال‌های زیر، فایلی به نام "sample.pptx" را استفاده می‌کنیم که یک جعبه متن در اسلاید اول دارد و متن زیر را شامل می‌شود:

![متن نمونه](sample_text.png)

## **برجسته‌سازی متن**

از روش [ITextFrame.HighlightText](https://reference.aspose.com/slides/fa/net/aspose.slides/itextframe/highlighttext/) زمانی استفاده کنید که نیاز به برجسته‌سازی متنی دارید که با یک نمونه خاص درون یک فریم متن مطابقت دارد. این روش رنگ برجسته را به بخش‌های متن منطبق اعمال می‌کند و می‌تواند همراه با [TextSearchOptions](https://reference.aspose.com/slides/fa/net/aspose.slides/textsearchoptions/) برای کنترل نحوه جستجو، برای مثال برای مطابقت فقط با کلمات کامل، استفاده شود.

مثال کد زیر تمام موارد حروف **"try"** را برجسته می‌کند و سپس فقط کلمه کامل **"to"** را برجسته می‌نماید.

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    // دریافت اولین شکل از اولین اسلاید.
    var shape = (IAutoShape)presentation.Slides[0].Shapes[0];

    // برجسته‌سازی واژه "try" در شکل.
    shape.TextFrame.HighlightText("try", Color.LightBlue);

    var searchOptions = new TextSearchOptions()
    {
        WholeWordsOnly = true
    };

    // برجسته‌سازی واژه "to" در شکل.
    shape.TextFrame.HighlightText("to", Color.Violet, searchOptions, null);

    presentation.Save("highlighted_text.pptx", SaveFormat.Pptx);
}
```

نتیجه:

![متن برجسته شده](highlighted_text.png)

## **برجسته‌سازی متن با استفاده از عبارات منظم**

روش [ITextFrame.HighlightRegex](https://reference.aspose.com/slides/fa/net/aspose.slides/itextframe/highlightregex/) متون منطبق یافت‌شده توسط یک عبارت منظم را برجسته می‌کند. در .NET، این API بر روی [ITextFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/itextframe/) در دسترس است.

مثال کد زیر تمام کلماتی که دارای **هفت یا بیشتر کاراکتر** هستند را برجسته می‌کند:

```cs
using (var presentation = new Presentation(folderPath + "sample.pptx"))
{
    var shape = (IAutoShape)presentation.Slides[0].Shapes[0];

    var regex = new Regex(@"\b[^\s]{7,}\b");

    // برجسته‌سازی تمام کلماتی که هفت یا بیشتر کاراکتر دارند.
    shape.TextFrame.HighlightRegex(regex, Color.Yellow, null);

    presentation.Save(folderPath + "highlighted_text_using_regex.pptx", SaveFormat.Pptx);
}
```

نتیجه:

![متن برجسته شده با استفاده از عبارت منظم](highlighted_text_using_regex.png)

## **تنظیم رنگ پس‌زمینه متن**

از [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/iparagraphformat/defaultportionformat/) برای تنظیم رنگ برجسته پیش‌فرض یک پاراگراف یا از [IPortionFormat.HighlightColor](https://reference.aspose.com/slides/fa/net/aspose.slides/iportionformat/highlightcolor/) برای بخش‌های متنی فردی استفاده کنید.

مثال کد زیر نشان می‌دهد چگونه رنگ پس‌زمینه برای **تمام پاراگراف** تنظیم شود:

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // تنظیم رنگ برجسته برای تمام پاراگراف.
    paragraph.ParagraphFormat.DefaultPortionFormat.HighlightColor.Color = Color.LightGray;

    presentation.Save("gray_paragraph.pptx", SaveFormat.Pptx);
}
```

نتیجه:

![پاراگراف خاکستری](gray_paragraph.png)

مثال کد زیر نشان می‌دهد چگونه رنگ پس‌زمینه برای **بخش‌های متنی با قلم ضخیم** تنظیم شود:

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
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
}
```

نتیجه:

![بخش‌های متنی خاکستری](gray_text_portions.png)

## **همترازی پاراگراف‌های متن**

از [IParagraphFormat.Alignment](https://reference.aspose.com/slides/fa/net/aspose.slides/iparagraphformat/alignment/) برای تنظیم همترازی پاراگراف درون یک فریم متن استفاده کنید. مقدار می‌تواند مرکزی، سمت چپ، سمت راست، توجیه‌شده و غیره باشد.

مثال کد زیر نشان می‌دهد چگونه پاراگراف به **مرکز** همترازی شود:

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // تنظیم همترازی پاراگراف به مرکز.
    paragraph.ParagraphFormat.Alignment = TextAlignment.Center;

    presentation.Save("aligned_paragraph.pptx", SaveFormat.Pptx);
}
```

نتیجه:

![پاراگراف همتراز شده](aligned_paragraph.png)

## **تنظیم شفافیت برای متن**

شفافیت متن از طریق مؤلفه آلفای رنگ اختصاص یافته به [IPortionFormat.FillFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/iportionformat/fillformat/) کنترل می‌شود. در مثال‌های زیر، `alpha = 50` مقدار کانال آلفای ARGB در مقیاس ۰–۲۵۵ است، نه درصد شفافیت.

مثال کد زیر نشان می‌دهد چگونه شفافیت به **تمام پاراگراف** اعمال شود:

```cs
int alpha = 50;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // تنظیم رنگ پر کردن متن به رنگ شفاف.
    paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Black);

    presentation.Save("transparent_paragraph.pptx", SaveFormat.Pptx);
}
```

نتیجه:

![پاراگراف شفاف](transparent_paragraph.png)

مثال کد زیر نشان می‌دهد چگونه شفافیت به **بخش‌های متنی با قلم ضخیم** اعمال شود:

```cs
int alpha = 50;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
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
}
```

نتیجه:

![بخش‌های متنی شفاف](transparent_text_portions.png)

## **تنظیم فاصله کاراکترها برای متن**

از [IBasePortionFormat.Spacing](https://reference.aspose.com/slides/fa/net/aspose.slides/ibaseportionformat/spacing/) برای گسترش یا فشردن فاصله بین حروف در یک جعبه متن استفاده کنید.

کد C# زیر نشان می‌دهد چگونه فاصله کاراکترها در **تمام پاراگراف** گسترش یابد:

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // توجه: برای فشرده‌سازی فاصله کاراکتر از مقادیر منفی استفاده کنید.
    paragraph.ParagraphFormat.DefaultPortionFormat.Spacing = 3;  // گسترش فاصله کاراکتر.

    presentation.Save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
}
```

نتیجه:

![فاصله کاراکترها در پاراگراف](character_spacing_in_paragraph.png)

مثال کد زیر نشان می‌دهد چگونه فاصله کاراکترها در **بخش‌های متنی با قلم ضخیم** گسترش یابد:

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
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
}
```

نتیجه:

![فاصله کاراکترها در بخش‌های متنی](character_spacing_in_text_portions.png)

### **غیرفعال‌سازی کرنینگ برای قلم‌های خاص**

در برخی موارد، متنی که توسط Aspose.Slides رندر می‌شود ممکن است کمی فشرده‌تر از همان متن در PowerPoint به نظر برسد. این می‌تواند به این دلیل باشد که PowerPoint داده‌های کرنینگ برای برخی قلم‌ها را نادیده می‌گیرد، حتی اگر قلم حاوی اطلاعات کرنینگ معتبر باشد و کرنینگ در تنظیمات PowerPoint فعال باشد.

برای نزدیک‌تر کردن خروجی رندر به PowerPoint در چنین مواردی، می‌توانید کرنینگ را برای بخش‌های متنی که از قلم مورد نظر استفاده می‌کنند، غیرفعال کنید. مقدار [IPortionFormat.KerningMinimalSize](https://reference.aspose.com/slides/fa/net/aspose.slides/ibaseportionformat/kerningminimalsize/) را به عددی بسیار بزرگتر از اندازه واقعی قلم تنظیم کنید:

```cs
using (var presentation = new Presentation("presentation.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var targetFont = "Roboto";

    foreach (var paragraph in autoShape.TextFrame.Paragraphs)
    {
        foreach (var portion in paragraph.Portions)
        {
            if ((portion.PortionFormat.LatinFont != null &&
                 portion.PortionFormat.LatinFont.FontName == targetFont) ||
                (portion.PortionFormat.EastAsianFont != null &&
                 portion.PortionFormat.EastAsianFont.FontName == targetFont) ||
                (portion.PortionFormat.ComplexScriptFont != null &&
                 portion.PortionFormat.ComplexScriptFont.FontName == targetFont))
            {
                portion.PortionFormat.KerningMinimalSize = 100;
            }
        }
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

این تنظیم از اعمال کرنینگ بر روی بخش‌های متنی منطبق جلوگیری می‌کند و می‌تواند به هم‌سویی رندر Aspose.Slides با خروجی بصری PowerPoint برای قلم‌هایی که تحت این رفتار خاص PowerPoint هستند، کمک کند.

## **مدیریت ویژگی‌های قلم متن**

ویژگی‌های قلم می‌توانند در سطح پاراگراف از طریق [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/iparagraphformat/defaultportionformat/) یا در بخش‌های منفرد از طریق [IPortionFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/iportionformat/) تنظیم شوند.

کد زیر قلم و سبک متن را برای تمام پاراگراف تنظیم می‌کند: اندازه قلم، ضخیم، ایتالیک، زیرخط نقطه‌دار و قلم Times New Roman به همه بخش‌های پاراگراف اعمال می‌شود.

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // تنظیم ویژگی‌های قلم برای پاراگراف.
    paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight = 12;
    paragraph.ParagraphFormat.DefaultPortionFormat.FontBold = NullableBool.True;
    paragraph.ParagraphFormat.DefaultPortionFormat.FontItalic = NullableBool.True;
    paragraph.ParagraphFormat.DefaultPortionFormat.FontUnderline = TextUnderlineType.Dotted;
    paragraph.ParagraphFormat.DefaultPortionFormat.LatinFont = new FontData("Times New Roman");

    presentation.Save("font_properties_for_paragraph.pptx", SaveFormat.Pptx);
}
```

نتیجه:

![ویژگی‌های قلم برای پاراگراف](font_properties_for_paragraph.png)

مثال کد زیر ویژگی‌های مشابهی را برای **بخش‌های متنی با قلم ضخیم** اعمال می‌کند:

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
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
}
```

نتیجه:

![ویژگی‌های قلم برای بخش‌های متنی](font_properties_for_text_portions.png)

## **تنظیم چرخش متن**

از [ITextFrameFormat.TextVerticalType](https://reference.aspose.com/slides/fa/net/aspose.slides/itextframeformat/textverticaltype/) برای تنظیم یک جهت‌گیری پیش‌فرض متن داخل یک شکل استفاده کنید.

کد زیر جهت‌گیری متن در شکل را به `Vertical270` تنظیم می‌کند که متن را **۹۰ درجه به صورت پادساعتگرد** می‌چرخاند:

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.TextVerticalType = TextVerticalType.Vertical270;

    presentation.Save("text_rotation.pptx", SaveFormat.Pptx);
}
```

نتیجه:

![چرخش متن](text_rotation.png)

## **تنظیم چرخش سفارشی برای فریم‌های متن**

از [ITextFrameFormat.RotationAngle](https://reference.aspose.com/slides/fa/net/aspose.slides/itextframeformat/rotationangle/) برای تنظیم زاویه چرخش سفارشی یک [ITextFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/itextframe/) استفاده کنید.

کد زیر فریم متن را داخل شکل ۳ درجه به جهت ساعتگرد می‌چرخاند:

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.RotationAngle = 3;

    presentation.Save("custom_text_rotation.pptx", SaveFormat.Pptx);
}
```

نتیجه:

![چرخش سفارشی متن](custom_text_rotation.png)

## **تنظیم فاصله خطوط پاراگراف‌ها**

Aspose.Slides دارای [IParagraphFormat.SpaceAfter](https://reference.aspose.com/slides/fa/net/aspose.slides/iparagraphformat/spaceafter/)، [IParagraphFormat.SpaceBefore](https://reference.aspose.com/slides/fa/net/aspose.slides/iparagraphformat/spacebefore/)، و [IParagraphFormat.SpaceWithin](https://reference.aspose.com/slides/fa/net/aspose.slides/iparagraphformat/spacewithin/) برای کنترل فاصله پاراگراف است. این ویژگی‌ها به شکل زیر استفاده می‌شوند:

* از مقدار مثبت برای تعیین فاصله خط به صورت درصدی از ارتفاع خط استفاده کنید.
* از مقدار منفی برای تعیین فاصله خط به صورت پوینت استفاده کنید.

کد زیر نشان می‌دهد چگونه فاصله خط را داخل پاراگراف تنظیم کنید:

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    paragraph.ParagraphFormat.SpaceWithin = 200;

    presentation.Save("line_spacing.pptx", SaveFormat.Pptx);
}
```

نتیجه:

![فاصله خطوط در پاراگراف](line_spacing.png)

## **تنظیم نوع Autofit برای فریم‌های متن**

[ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/fa/net/aspose.slides/itextframeformat/autofittype/) تعیین می‌کند که متن هنگام فراتر رفتن از مرزهای ظرف خود چگونه رفتار کند. از آن برای کنترل اینکه متن کوچک شود، سرریز شود یا به‌صورت خودکار شکل را تغییر اندازه دهد، استفاده کنید.

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;

    presentation.Save("autofit_type.pptx", SaveFormat.Pptx);
}
```

## **تنظیم نقطه تکیه فریم‌های متن**

[ITextFrameFormat.AnchoringType](https://reference.aspose.com/slides/fa/net/aspose.slides/itextframeformat/anchoringtype/) تعیین می‌کند متن به صورت عمودی داخل یک شکل در کجا قرار گیرد، برای مثال در بالا، وسط یا پایین.

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.AnchoringType = TextAnchorType.Bottom;

    presentation.Save("text_anchor.pptx", SaveFormat.Pptx);
}
```

## **تنظیم تب‌بندی متن**

از [IParagraphFormat.DefaultTabSize](https://reference.aspose.com/slides/fa/net/aspose.slides/iparagraphformat/defaulttabsize/) و [IParagraphFormat.Tabs](https://reference.aspose.com/slides/fa/net/aspose.slides/iparagraphformat/tabs/) برای پیکربندی توقف‌های تب در یک پاراگراف استفاده کنید.

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    paragraph.ParagraphFormat.DefaultTabSize = 100;
    paragraph.ParagraphFormat.Tabs.Add(30, TabAlignment.Left);

    presentation.Save("paragraph_tabs.pptx", SaveFormat.Pptx);
}
```

نتیجه:

![تب‌های پاراگراف](paragraph_tabs.png)

## **تنظیم زبان تصحیح**

Aspose.Slides دارای [IPortionFormat.LanguageId](https://reference.aspose.com/slides/fa/net/aspose.slides/iportionformat/languageid/) است که به شما امکان می‌دهد زبان تصحیح را برای یک بخش متنی تنظیم کنید. زبان تصحیح زبانی را تعیین می‌کند که برای بررسی املایی و گرامری در PowerPoint استفاده می‌شود.

مثال کد زیر نشان می‌دهد چگونه زبان تصحیح برای یک بخش متنی تنظیم شود:

```cs
using (var presentation = new Presentation("presentation.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    var paragraph = autoShape.TextFrame.Paragraphs[0];
    paragraph.Portions.Clear();

    var font = new FontData("SimSun");

    var textPortion = new Portion();
    textPortion.PortionFormat.ComplexScriptFont = font;
    textPortion.PortionFormat.EastAsianFont = font;
    textPortion.PortionFormat.LatinFont = font;

    // تنظیم شناسه زبان تصحیح.
    textPortion.PortionFormat.LanguageId = "zh-CN";

    textPortion.Text = "1。";
    paragraph.Portions.Add(textPortion);

    presentation.Save("proofing_language.pptx", SaveFormat.Pptx);
}
```

## **تنظیم زبان پیش‌فرض**

از [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/fa/net/aspose.slides/loadoptions/defaulttextlanguage/) برای تعریف زبان پیش‌فرض متنی که در هنگام بارگذاری یا ایجاد یک ارائه ایجاد می‌شود، استفاده کنید.

```cs
var loadOptions = new LoadOptions();
loadOptions.DefaultTextLanguage = "en-US";

using (var presentation = new Presentation(loadOptions))
{
    var slide = presentation.Slides[0];

    // افزودن یک شکل مستطیلی جدید با متن.
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
    shape.TextFrame.Text = "Sample text";

    // بررسی زبان بخش اول.
    var portion = shape.TextFrame.Paragraphs[0].Portions[0];
    Console.WriteLine(portion.PortionFormat.LanguageId);
}
```

## **تنظیم سبک متن پیش‌فرض**

برای اعمال فرمت‌بندی پیش‌فرض متن در سطح ارائه، از [IPresentation.DefaultTextStyle](https://reference.aspose.com/slides/fa/net/aspose.slides/ipresentation/defaulttextstyle/) استفاده کنید.

مثال کد زیر نشان می‌دهد چگونه یک قلم ضخیم پیش‌فرض با اندازه ۱۴ پوینت برای تمام متن‌ها در تمام اسلایدهای یک ارائه جدید تنظیم شود.

```cs
using (var presentation = new Presentation())
{
    // دریافت قالب پاراگراف سطح بالایی.
    var paragraphFormat = presentation.DefaultTextStyle.GetLevel(0);

    if (paragraphFormat != null)
    {
        paragraphFormat.DefaultPortionFormat.FontHeight = 14;
        paragraphFormat.DefaultPortionFormat.FontBold = NullableBool.True;
    }

    presentation.Save("default_text_style.pptx", SaveFormat.Pptx);
}
```

## **استخلاص متن با اثر تمام حروف بزرگ**

در PowerPoint، اعمال اثر **All Caps** باعث می‌شود متن روی اسلاید به صورت حروف بزرگ نمایش داده شود حتی اگر اصلاً به حروف کوچک تایپ شده باشد. هنگام استخراج چنین بخشی از متن با Aspose.Slides، کتابخانه متن را دقیقاً همان‌گونه که وارد شده است برمی‌گرداند. برای مطابقت با متنی که نمایش داده می‌شود، [TextCapType](https://reference.aspose.com/slides/fa/net/aspose.slides/textcaptype/) را بررسی کنید و هنگامیکه مقدار `All` باشد، رشته برگردانده‌شده را به حروف بزرگ تبدیل کنید.

فرض کنیم جعبه متنی زیر را در اسلاید اول فایل sample2.pptx داریم.

![اثر تمام حروف بزرگ](all_caps_effect.png)

مثال کد زیر نشان می‌دهد چگونه متن با اثر **All Caps** استخراج شود:

```cs
using (var presentation = new Presentation("sample2.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var textPortion = autoShape.TextFrame.Paragraphs[0].Portions[0];

    Console.WriteLine($"Original text: {textPortion.Text}");

    var textFormat = textPortion.PortionFormat.GetEffective();
    if (textFormat.TextCapType == TextCapType.All)
    {
        var text = textPortion.Text.ToUpper();
        Console.WriteLine($"All-Caps effect: {text}");
    }
}
```

خروجی:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **سوالات متداول**

**چگونه متن داخل یک جدول در اسلاید را ویرایش کنیم؟**

برای ویرایش متن داخل یک جدول در اسلاید، از [ITable](https://reference.aspose.com/slides/fa/net/aspose.slides/itable/) استفاده کنید. سلول‌ها را پیمایش کنید و هر سلول را از طریق [ICell.TextFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/icell/textframe/) و قالب‌بندی پاراگراف از طریق [IParagraph.ParagraphFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/iparagraph/paragraphformat/) به‌روز کنید.

**چگونه رنگ گرادیان را به متن در یک اسلاید PowerPoint اعمال کنیم؟**

برای اعمال رنگ گرادیان به متن، از [IPortionFormat.FillFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/iportionformat/fillformat/) استفاده کنید. [IFillFormat.FillType](https://reference.aspose.com/slides/fa/net/aspose.slides/ifillformat/filltype/) را به [FillType.Gradient](https://reference.aspose.com/slides/fa/net/aspose.slides/filltype/) تنظیم کنید و توقف‌های گرادیان، جهت و شفافیت را پیکربندی کنید.