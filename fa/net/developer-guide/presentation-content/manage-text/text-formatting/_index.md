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
- فاصله بین حروف
- ویژگی‌های قلم
- خانواده قلم
- چرخش متن
- زاویه چرخش
- قاب متن
- فاصله خطوط
- ویژگی خودکاراندازه‌گیری
- لنگر قاب متن
- تب‌بندی متن
- زبان پیش‌فرض
- PowerPoint
- OpenDocument
- ارائه
- .NET
- C#
- Aspose.Slides
description: "قالب‌بندی و استایل‌بندی متن در ارائه‌های PowerPoint و OpenDocument با استفاده از Aspose.Slides برای .NET. قلم‌ها، رنگ‌ها، ترازبندی و موارد دیگر را سفارشی کنید."
---
## **بررسی کلی**

این مقاله نشان می‌دهد چگونه متن را در ارائه‌های PowerPoint و OpenDocument با استفاده از Aspose.Slides for .NET قالب‌بندی کنیم. موضوعات شامل رنگ‌های پس‌زمینه، شفافیت، فاصله بین حروف، ویژگی‌های قلم، چرخش، فاصله پاراگراف، رفتار خودکاراندازه‌گیری، مکان‌یابی متن، تب‌ها و تنظیمات زبان می‌شود.

در مثال‌های زیر، فایلی به نام "sample.pptx" استفاده می‌کنیم که یک جعبه متن واحد در اولین اسلاید دارد و متن زیر را شامل می‌شود:

![متن نمونه](sample_text.png)

برای یافتن و برجسته‌سازی متن به صورت دقیق یا تطابق‌های عبارات منظم، به [جستجو و جایگزینی متن](/slides/fa/net/search-and-replace-text/) مراجعه کنید.

## **تنظیم رنگ پس‌زمینه متن**

از [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/iparagraphformat/defaultportionformat/) برای تنظیم رنگ برجسته پیش‌فرض یک پاراگراف استفاده کنید یا از [IBasePortionFormat.HighlightColor](https://reference.aspose.com/slides/fa/net/aspose.slides/ibaseportionformat/highlightcolor/) برای بخش‌های متن منفرد.

مثال کد زیر نشان می‌دهد چگونه رنگ پس‌زمینه **تمام پاراگراف** تنظیم شود:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // رنگ برجسته را برای کل پاراگراف تنظیم کنید.
    paragraph.ParagraphFormat.DefaultPortionFormat.HighlightColor.Color = Color.LightGray;

    presentation.Save("gray_paragraph.pptx", SaveFormat.Pptx);
}
```

نتیجه:

![پاراگراف خاکستری](gray_paragraph.png)

مثال کد زیر نحوه تنظیم رنگ پس‌زمینه برای **بخش‌های متنی با قلم بولد** را نشان می‌دهد:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
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
}
```

نتیجه:

![بخش‌های متن خاکستری](gray_text_portions.png)

## **هم‌ترازی پاراگراف‌های متن**

از [IParagraphFormat.Alignment](https://reference.aspose.com/slides/fa/net/aspose.slides/iparagraphformat/alignment/) برای تنظیم ترازبندی پاراگراف داخل قاب متن استفاده کنید. مقدار می‌تواند مرکز، چپ، راست، توجیه‌شده و ... باشد.

مثال کد زیر نشان می‌دهد چگونه پاراگراف به **مرکز** ترازبندی شود:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // ترازبندی پاراگراف را به مرکز تنظیم کنید.
    paragraph.ParagraphFormat.Alignment = TextAlignment.Center;

    presentation.Save("aligned_paragraph.pptx", SaveFormat.Pptx);
}
```

نتیجه:

![پاراگراف هم‌تراز شده](aligned_paragraph.png)

## **تنظیم شفافیت برای متن**

شفافیت متن از طریق جزء آلفا رنگی که به [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/ibaseportionformat/fillformat/) اختصاص داده می‌شود، کنترل می‌شود. در مثال‌های زیر، `alpha = 50` مقدار کانال آلفای ARGB در مقیاس 0–255 است، نه درصد شفافیت.

مثال کد زیر نشان می‌دهد چگونه شفافیت به **تمام پاراگراف** اعمال شود:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

int alpha = 50;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    //    رنگ پر کردن متن را به رنگ شفاف تنظیم کنید.
    paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Black);

    presentation.Save("transparent_paragraph.pptx", SaveFormat.Pptx);
}
```

نتیجه:

![پاراگراف شفاف](transparent_paragraph.png)

مثال کد زیر نشان می‌دهد چگونه شفافیت به **بخش‌های متنی با قلم بولد** اعمال شود:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

int alpha = 50;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    foreach (var portion in paragraph.Portions)
    {
        if (portion.PortionFormat.GetEffective().FontBold)
        {
            // شفافیت بخش متن را تنظیم کنید.
            portion.PortionFormat.FillFormat.FillType = FillType.Solid;
            portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Black);
        }
    }

    presentation.Save("transparent_text_portions.pptx", SaveFormat.Pptx);
}
```

نتیجه:

![بخش‌های متن شفاف](transparent_text_portions.png)

## **تنظیم فاصله بین حروف برای متن**

از [IBasePortionFormat.Spacing](https://reference.aspose.com/slides/fa/net/aspose.slides/ibaseportionformat/spacing/) برای افزایش یا کاهش فاصله بین حروف در یک جعبه متن استفاده کنید.

کد C# زیر نشان می‌دهد چگونه فاصله حروف در **تمام پاراگراف** گسترش یابد:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // توجه: برای فشرده‌سازی فاصله حروف از مقادیر منفی استفاده کنید.
    paragraph.ParagraphFormat.DefaultPortionFormat.Spacing = 3;  // فاصله حروف را گسترش دهید.

    presentation.Save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
}
```

نتیجه:

![فاصله حروف در پاراگراف](character_spacing_in_paragraph.png)

مثال کد زیر نشان می‌دهد چگونه فاصله حروف در **بخش‌های متنی با قلم بولد** گسترش یابد:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    foreach (var portion in paragraph.Portions)
    {
        if (portion.PortionFormat.GetEffective().FontBold)
        {
            // توجه: برای فشرده‌سازی فاصله حروف از مقادیر منفی استفاده کنید.
            portion.PortionFormat.Spacing = 3;  // فاصله حروف را گسترش دهید.
        }
    }

    presentation.Save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
}
```

نتیجه:

![فاصله حروف در بخش‌های متن](character_spacing_in_text_portions.png)

### **غیرفعال کردن کرنینگ برای قلم‌های خاص**

در برخی موارد، متنی که توسط Aspose.Slides رندر می‌شود، ممکن است اندکی فشرده‌تر از متن مشابه در PowerPoint به نظر برسد. این می‌تواند به این دلیل باشد که PowerPoint ممکن است داده‌های کرنینگ را برای برخی قلم‌ها نادیده بگیرد، حتی اگر قلم حاوی اطلاعات کرنینگ معتبر باشد و کرنینگ در تنظیمات PowerPoint فعال باشد.

برای نزدیک‌تر کردن خروجی رندر به PowerPoint در این موارد، می‌توانید کرنینگ را برای بخش‌های متنی که از قلم مورد نظر استفاده می‌کنند غیرفعال کنید. مقدار [IBasePortionFormat.KerningMinimalSize](https://reference.aspose.com/slides/fa/net/aspose.slides/ibaseportionformat/kerningminimalsize/) را به مقدار قابل‌توجهی بزرگتر از اندازه واقعی قلم تنظیم کنید:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

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

این تنظیم مانع اعمال کرنینگ بر بخش‌های متن مطابق می‌شود و می‌تواند به هم‌راستایی رندر Aspose.Slides با خروجی بصری PowerPoint برای قلم‌هایی که تحت تأثیر این رفتار خاص PowerPoint هستند، کمک کند.

## **مدیریت ویژگی‌های قلم متن**

ویژگی‌های قلم می‌توانند در سطح پاراگراف از طریق [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/iparagraphformat/defaultportionformat/) یا در بخش‌های منفرد از طریق [IPortionFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/iportionformat/) تنظیم شوند.

کد زیر قلم و سبک متن را برای **تمام پاراگراف** تنظیم می‌کند: اندازه قلم، بولد، ایتالیک، زیرخط نقطه‌ای و قلم Times New Roman را برای همه بخش‌های پاراگراف اعمال می‌کند.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // ویژگی‌های قلم را برای پاراگراف تنظیم کنید.
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

مثال کد زیر ویژگی‌های مشابهی را برای **بخش‌های متنی با قلم بولد** اعمال می‌کند:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
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
}
```

نتیجه:

![ویژگی‌های قلم برای بخش‌های متن](font_properties_for_text_portions.png)

## **تنظیم چرخش متن**

از [ITextFrameFormat.TextVerticalType](https://reference.aspose.com/slides/fa/net/aspose.slides/itextframeformat/textverticaltype/) برای تنظیم جهت پیش‌تعریف‌شده متن داخل یک شکل استفاده کنید.

مثال کد زیر جهت متن در شکل را به `Vertical270` تنظیم می‌کند که متن را **۹۰ درجه ضد ساعت‌گرد** می‌چرخاند:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

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

مثال کد زیر فریم متن را داخل شکل به میزان ۳ درجه به سمت ساعت‌گرد می‌چرخاند:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

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

Aspose.Slides امکانات [IParagraphFormat.SpaceAfter](https://reference.aspose.com/slides/fa/net/aspose.slides/iparagraphformat/spaceafter/)، [IParagraphFormat.SpaceBefore](https://reference.aspose.com/slides/fa/net/aspose.slides/iparagraphformat/spacebefore/)، و [IParagraphFormat.SpaceWithin](https://reference.aspose.com/slides/fa/net/aspose.slides/iparagraphformat/spacewithin/) را برای کنترل فاصله پاراگراف ارائه می‌دهد. این ویژگی‌ها به صورت زیر استفاده می‌شوند:

* از مقدار مثبت برای تعیین فاصله خط به صورت درصدی از ارتفاع خط استفاده کنید.
* از مقدار منفی برای تعیین فاصله خط به نقطه استفاده کنید.

مثال کد زیر نشان می‌دهد چگونه فاصله خط را داخل پاراگراف مشخص کنید:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

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

## **تنظیم نوع خودکاراندازه‌گیری برای فریم‌های متن**

[ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/fa/net/aspose.slides/itextframeformat/autofittype/) تعیین می‌کند که متن هنگام فراتر رفتن از مرزهای محفظه‌اش چگونه رفتار کند. از آن برای کنترل اینکه متن کوچک شود، بیش از حد جریان یابد یا به‌صورت خودکار شکل را تغییر اندازه دهد استفاده کنید.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;

    presentation.Save("autofit_type.pptx", SaveFormat.Pptx);
}
```

برای شمارش خطوط پس از بسته‌بندی خودکار و مشاهده اینکه چگونه عرض متن یا شکل نتایج را تغییر می‌دهد، به [شمارش خطوط رندرشده](/slides/fa/net/manage-paragraph/) مراجعه کنید. تنها شمارش خطوط نشانگر این نیست که متن از محفظه‌اش سرریز می‌شود یا خیر.

## **تنظیم نقطه مرجع فریم‌های متن**

[ITextFrameFormat.AnchoringType](https://reference.aspose.com/slides/fa/net/aspose.slides/itextframeformat/anchoringtype/) تعیین می‌کند که متن به‌صورت عمودی داخل شکل چگونه موقعیت یابد، به‌عنوان مثال در بالا، وسط یا پایین.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.AnchoringType = TextAnchorType.Bottom;

    presentation.Save("text_anchor.pptx", SaveFormat.Pptx);
}
```

## **تنظیم تب‌بندی متن**

از [IParagraphFormat.DefaultTabSize](https://reference.aspose.com/slides/fa/net/aspose.slides/iparagraphformat/defaulttabsize/) و [IParagraphFormat.Tabs](https://reference.aspose.com/slides/fa/net/aspose.slides/iparagraphformat/tabs/) برای پیکربندی موقعیت‌های تب در یک پاراگراف استفاده کنید.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

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

## **تنظیم زبان بازبینی**

Aspose.Slides ویژگی [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/fa/net/aspose.slides/ibaseportionformat/languageid/) را فراهم می‌کند که به شما امکان می‌دهد زبان بازبینی برای یک بخش متن را تنظیم کنید. زبان بازبینی تعیین می‌کند که برای بررسی املا و دستور در PowerPoint از کدام زبان استفاده شود.

مثال کد زیر نشان می‌دهد چگونه زبان بازبینی را برای یک بخش متن تنظیم کنید:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

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

    // شناسه زبان بازبینی را تنظیم کنید.
    textPortion.PortionFormat.LanguageId = "zh-CN";

    textPortion.Text = "1。";
    paragraph.Portions.Add(textPortion);

    presentation.Save("proofing_language.pptx", SaveFormat.Pptx);
}
```

## **تنظیم زبان پیش‌فرض**

از [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/fa/net/aspose.slides/loadoptions/defaulttextlanguage/) برای تعریف زبان پیش‌فرض متنی که هنگام بارگذاری یا ایجاد یک ارائه ایجاد می‌شود، استفاده کنید.

```cs
using Aspose.Slides;

var loadOptions = new LoadOptions();
loadOptions.DefaultTextLanguage = "en-US";

using (var presentation = new Presentation(loadOptions))
{
    var slide = presentation.Slides[0];

    // یک شکل مستطیلی جدید با متن اضافه کنید.
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
    shape.TextFrame.Text = "Sample text";

    // زبان اولین بخش را بررسی کنید.
    var portion = shape.TextFrame.Paragraphs[0].Portions[0];
    Console.WriteLine(portion.PortionFormat.LanguageId);
}
```

## **تنظیم سبک متن پیش‌فرض**

برای اعمال قالب‌بندی متن پیش‌فرض در سطح ارائه، از [IPresentation.DefaultTextStyle](https://reference.aspose.com/slides/fa/net/aspose.slides/ipresentation/defaulttextstyle/) استفاده کنید.

مثال کد زیر نشان می‌دهد چگونه یک قلم بولد پیش‌فرض با اندازه ۱۴ پوینت برای تمام متن‌ها در اسلایدهای یک ارائه جدید تنظیم شود.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation())
{
    // دریافت قالب پاراگراف سطح بالا.
    var paragraphFormat = presentation.DefaultTextStyle.GetLevel(0);

    if (paragraphFormat != null)
    {
        paragraphFormat.DefaultPortionFormat.FontHeight = 14;
        paragraphFormat.DefaultPortionFormat.FontBold = NullableBool.True;
    }

    presentation.Save("default_text_style.pptx", SaveFormat.Pptx);
}
```

## **استخراج متن با اثر تمام حروف بزرگ**

در PowerPoint، اعمال اثر **All Caps** به قلم باعث می‌شود متن روی اسلاید به صورت حروف بزرگ نشان داده شود حتی اگر ابتدا با حروف کوچک وارد شده باشد. وقتی چنین بخشی از متن را با Aspose.Slides بازیابی می‌کنید، کتابخانه متن را دقیقاً همان‌طور که وارد شده است برمی‌گرداند. برای تطبیق با متن نمایش داده‌شده، [TextCapType](https://reference.aspose.com/slides/fa/net/aspose.slides/textcaptype/) را بررسی کرده و رشتهٔ برگردانده‌شده را به حروف بزرگ تبدیل کنید وقتی مقدار آن `All` باشد.

فرض کنید جعبه متن زیر را در اولین اسلاید فایل sample2.pptx داریم.

![اثر تمام حروف بزرگ](all_caps_effect.png)

مثال کد زیر نشان می‌دهد چگونه متن با اثر **All Caps** استخراج شود:

```cs
using Aspose.Slides;

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

**چگونه متن در یک جدول در اسلاید را ویرایش کنیم؟**

برای ویرایش متن در یک جدول در اسلاید، از [ITable](https://reference.aspose.com/slides/fa/net/aspose.slides/itable/) استفاده کنید. سلول‌ها را مرور کنید و هر سلول را از طریق [ICell.TextFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/icell/textframe/) به‌روزرسانی کنید و قالب‌بندی پاراگراف را از طریق [IParagraph.ParagraphFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/iparagraph/paragraphformat/) تنظیم کنید.

**چگونه رنگ گرادیان به متن در یک اسلاید پاورپوینت اعمال کنیم؟**

برای اعمال رنگ گرادیان به متن، از [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/ibaseportionformat/fillformat/) استفاده کنید. [IFillFormat.FillType](https://reference.aspose.com/slides/fa/net/aspose.slides/ifillformat/filltype/) را روی [FillType.Gradient](https://reference.aspose.com/slides/fa/net/aspose.slides/filltype/) تنظیم کنید و نقاط توقف گرادیان، جهت و شفافیت را پیکربندی کنید.