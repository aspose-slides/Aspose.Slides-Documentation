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
- ویژگی خودسازگاری
- لنگر قاب متن
- تب‌گذاری متن
- زبان پیش‌فرض
- PowerPoint
- OpenDocument
- ارائه
- .NET
- C#
- Aspose.Slides
description: "قالب‌بندی و استایل‌دهی به متن در ارائه‌های PowerPoint و OpenDocument با استفاده از Aspose.Slides برای .NET. سفارشی‌سازی قلم‌ها، رنگ‌ها، تراز و موارد دیگر."
---
## **بررسی کلی**

این مقاله نشان می‌دهد چگونه متن را در ارائه‌های PowerPoint و OpenDocument با استفاده از Aspose.Slides برای .NET قالب‌بندی کنید. این مقاله به رنگ پس‌زمینه، شفافیت، فاصله بین حروف، ویژگی‌های قلم، چرخش، فاصله پاراگراف، رفتار Autofit، قرارگیری متن، تب‌استاپ‌ها و تنظیمات زبان می‌پردازد.

در مثال‌های زیر، از فایلی به نام "sample.pptx" استفاده می‌کنیم که یک جعبهٔ متن واحد در اسلاید اول دارد و شامل متن زیر است:

![متن نمونه](sample_text.png)

برای پیدا کردن و برجسته‌کردن متن دقیق یا تطبیق‌های عبارت منظم، به [جستجو و جایگزینی متن](/slides/fa/net/search-and-replace-text/) مراجعه کنید.

## **تنظیم رنگ پس‌زمینه متن**

از [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/iparagraphformat/defaultportionformat/) برای تنظیم رنگ برجسته پیش‌فرض یک پاراگراف استفاده کنید، یا برای بخش‌های متنی فردی از [IBasePortionFormat.HighlightColor](https://reference.aspose.com/slides/fa/net/aspose.slides/ibaseportionformat/highlightcolor/) استفاده کنید.

کد زیر نحوه تنظیم رنگ پس‌زمینه برای **کل پاراگراف** را نشان می‌دهد:

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

کد زیر نشان می‌دهد چگونه رنگ پس‌زمینه برای **بخش‌های متنی با قلم بولد** تنظیم شود:

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

![بخش‌های متنی خاکستری](gray_text_portions.png)

## **تراز کردن پاراگراف‌های متن**

از [IParagraphFormat.Alignment](https://reference.aspose.com/slides/fa/net/aspose.slides/iparagraphformat/alignment/) برای تنظیم تراز پاراگراف داخل یک فریم متن استفاده کنید. مقدار می‌تواند centered، left‑aligned، right‑aligned، justified و غیره باشد.

کد زیر نشان می‌دهد چگونه پاراگراف را به **مرکز** تراز کنید:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // تراز پاراگراف را به مرکز تنظیم کنید.
    paragraph.ParagraphFormat.Alignment = TextAlignment.Center;

    presentation.Save("aligned_paragraph.pptx", SaveFormat.Pptx);
}
```

نتیجه:

![پاراگراف تراز‌شده](aligned_paragraph.png)

## **تنظیم شفافیت برای متن**

شفافیت متن از طریق مؤلفهٔ آلفای رنگ اختصاص داده شده به [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/ibaseportionformat/fillformat/) کنترل می‌شود. در مثال‌های زیر، `alpha = 50` مقدار کانال آلفای ARGB در مقیاس 0–255 است، نه درصد شفافیت.

کد زیر نشان می‌دهد چگونه شفافیت برای **کل پاراگراف** اعمال شود:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

int alpha = 50;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // رنگ پر متن را به رنگ شفاف تنظیم کنید.
    paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Black);

    presentation.Save("transparent_paragraph.pptx", SaveFormat.Pptx);
}
```

نتیجه:

![پاراگراف شفاف](transparent_paragraph.png)

کد زیر نشان می‌دهد چگونه شفافیت برای **بخش‌های متنی با قلم بولد** اعمال شود:

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
            // شفافیت بخش متنی را تنظیم کنید.
            portion.PortionFormat.FillFormat.FillType = FillType.Solid;
            portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Black);
        }
    }

    presentation.Save("transparent_text_portions.pptx", SaveFormat.Pptx);
}
```

نتیجه:

![بخش‌های متنی شفاف](transparent_text_portions.png)

## **تنظیم فاصلهٔ بین حروف برای متن**

از [IBasePortionFormat.Spacing](https://reference.aspose.com/slides/fa/net/aspose.slides/ibaseportionformat/spacing/) برای افزایش یا کاهش فاصله بین حروف در یک جعبهٔ متن استفاده کنید.

کد C# زیر نشان می‌دهد چگونه فاصلهٔ بین حروف در **کل پاراگراف** افزایش یابد:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // توجه: برای فشرده‌کردن فاصله بین حروف از مقادیر منفی استفاده کنید.
    paragraph.ParagraphFormat.DefaultPortionFormat.Spacing = 3;  // فاصله بین حروف را گسترش دهید.

    presentation.Save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
}
```

نتیجه:

![فاصلهٔ بین حروف در پاراگراف](character_spacing_in_paragraph.png)

کد زیر نشان می‌دهد چگونه فاصلهٔ بین حروف در **بخش‌های متنی با قلم بولد** افزایش یابد:

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
            // توجه: برای فشرده‌کردن فاصله بین حروف از مقادیر منفی استفاده کنید.
            portion.PortionFormat.Spacing = 3;  // فاصله بین حروف را گسترش دهید.
        }
    }

    presentation.Save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
}
```

نتیجه:

![فاصلهٔ بین حروف در بخش‌های متنی](character_spacing_in_text_portions.png)

### **غیرفعال کردن Kerning برای قلم‌های خاص**

در برخی موارد، متنی که توسط Aspose.Slides رندر می‌شود، ممکن است نسبت به همان متن در PowerPoint کمی فشرده‌تر به نظر برسد. این می‌تواند به این دلیل باشد که PowerPoint داده‌های kerning را برای برخی قلم‌ها نادیده می‌گیرد، حتی اگر قلم دارای اطلاعات kerning معتبر باشد و kerning در تنظیمات PowerPoint فعال باشد.

برای نزدیک‌تر شدن خروجی رندر شده به PowerPoint، می‌توانید kerning را برای بخش‌های متنی که از قلم موردنظر استفاده می‌کنند غیرفعال کنید. مقدار [IBasePortionFormat.KerningMinimalSize](https://reference.aspose.com/slides/fa/net/aspose.slides/ibaseportionformat/kerningminimalsize/) را به مقداری بزرگتر از اندازهٔ واقعی قلم تنظیم کنید:

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

این تنظیم از اعمال kerning بر روی بخش‌های متنی مطابقت‌دار جلوگیری می‌کند و می‌تواند به همسویی رندر Aspose.Slides با خروجی بصری PowerPoint برای قلم‌های تحت‌تاثیر این رفتار خاص PowerPoint کمک کند.

## **مدیریت ویژگی‌های قلم متن**

ویژگی‌های قلم می‌توانند در سطح پاراگراف از طریق [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/iparagraphformat/defaultportionformat/) یا در بخش‌های فردی از طریق [IPortionFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/iportionformat/) تنظیم شوند.

کد زیر قلم و سبک متن را برای **کل پاراگراف** تنظیم می‌کند: اندازه قلم، بولد، ایتالیک، زیرخط نقطه‌دار و قلم Times New Roman برای همهٔ بخش‌ها اعمال می‌شود.

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

کد زیر ویژگی‌های مشابه را برای **بخش‌های متنی با قلم بولد** اعمال می‌کند:

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
            // ویژگی‌های قلم را برای بخش متنی تنظیم کنید.
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

از [ITextFrameFormat.TextVerticalType](https://reference.aspose.com/slides/fa/net/aspose.slides/itextframeformat/textverticaltype/) برای تنظیم جهت پیش‌فرض متن در داخل یک شکل استفاده کنید.

کد زیر جهت متن در شکل را به `Vertical270` تنظیم می‌کند که متن را **۹۰ درجه در جهت مخالف عقربه‌های ساعت** می‌چرخاند:

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

از [ITextFrameFormat.RotationAngle](https://reference.aspose.com/slides/fa/net/aspose.slides/itextframeformat/rotationangle/) برای تنظیم زاویهٔ چرخش سفارشی یک [ITextFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/itextframe/) استفاده کنید.

کد زیر فریم متن را به میزان ۳ درجه در جهت ساعت در داخل شکل می‌چرخاند:

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

## **تنظیم فاصلهٔ خط پاراگراف‌ها**

Aspose.Slides مجموعه‌ای از ویژگی‌های [IParagraphFormat.SpaceAfter](https://reference.aspose.com/slides/fa/net/aspose.slides/iparagraphformat/spaceafter/)، [IParagraphFormat.SpaceBefore](https://reference.aspose.com/slides/fa/net/aspose.slides/iparagraphformat/spacebefore/) و [IParagraphFormat.SpaceWithin](https://reference.aspose.com/slides/fa/net/aspose.slides/iparagraphformat/spacewithin/) را برای کنترل فاصلهٔ پاراگراف فراهم می‌آورد. این ویژگی‌ها به شرح زیر استفاده می‌شوند:

* برای مشخص کردن فاصلهٔ خط به صورت درصدی از ارتفاع خط، مقدار مثبت استفاده کنید.
* برای مشخص کردن فاصلهٔ خط به صورت نقاط، مقدار منفی استفاده کنید.

کد زیر نشان می‌دهد چگونه فاصلهٔ خط داخل پاراگراف را مشخص کنید:

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

![فاصلهٔ خط داخل پاراگراف](line_spacing.png)

## **تنظیم نوع Autofit برای فریم‌های متن**

[ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/fa/net/aspose.slides/itextframeformat/autofittype/) تعیین می‌کند هنگامیکه متن بیش از مرزهای کانتینر خود باشد، چه رفتار داشته باشد. از آن برای کنترل اینکه متن کوچک شود، سرریز شود یا به‌صورت خودکار اندازهٔ شکل را تغییر دهد استفاده کنید.

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

## **تنظیم نقطهٔ لنگر فریم‌های متن**

[ITextFrameFormat.AnchoringType](https://reference.aspose.com/slides/fa/net/aspose.slides/itextframeformat/anchoringtype/) تعریف می‌کند متن به صورت عمودی داخل شکل در کجا قرار گیرد، مثلا در بالا، وسط یا پایین.

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

## **تنظیم تب‌گذاری متن**

از [IParagraphFormat.DefaultTabSize](https://reference.aspose.com/slides/fa/net/aspose.slides/iparagraphformat/defaulttabsize/) و [IParagraphFormat.Tabs](https://reference.aspose.com/slides/fa/net/aspose.slides/iparagraphformat/tabs/) برای پیکربندی توقف‌های تب در یک پاراگراف استفاده کنید.

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

## **تنظیم زبان تصحیح املایی**

Aspose.Slides ویژگی [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/fa/net/aspose.slides/ibaseportionformat/languageid/) را فراهم می‌کند که به شما اجازه می‌دهد زبان تصحیح املایی برای یک بخش متنی را تنظیم کنید. این زبان تعیین می‌کند در PowerPoint برای چک املایی و دستوری از چه زبانی استفاده شود.

کد زیر نشان می‌دهد چگونه زبان تصحیح املایی برای یک بخش متنی تنظیم شود:

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

    // شناسه زبان تصحیح املایی را تنظیم کنید.
    textPortion.PortionFormat.LanguageId = "zh-CN";

    textPortion.Text = "1。";
    paragraph.Portions.Add(textPortion);

    presentation.Save("proofing_language.pptx", SaveFormat.Pptx);
}
```

## **تنظیم زبان پیش‌فرض**

از [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/fa/net/aspose.slides/loadoptions/defaulttextlanguage/) برای تعریف زبان پیش‌فرض متنی که هنگام بارگذاری یا ایجاد یک ارائه تولید می‌شود، استفاده کنید.

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

## **تنظیم سبک پیش‌فرض متن**

برای اعمال قالب‌بندی پیش‌فرض متن در سطح ارائه، از [IPresentation.DefaultTextStyle](https://reference.aspose.com/slides/fa/net/aspose.slides/ipresentation/defaulttextstyle/) استفاده کنید.

کد زیر نشان می‌دهد چگونه قلم بولد پیش‌فرض با اندازهٔ ۱۴ pt برای تمام متن‌ها در اسلایدهای یک ارائهٔ جدید تنظیم شود.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

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

## **استخراج متن با افکت تمام حروف بزرگ**

در PowerPoint، اعمال افکت **All Caps** باعث می‌شود متن در اسلاید به صورت حروف بزرگ نمایش داده شود حتی اگر اصلاً به حروف کوچک وارد شده باشد. هنگام دریافت چنین بخشی از متن با Aspose.Slides، کتابخانه متن را دقیقاً همان‌طوری که وارد شده بر می‌گرداند. برای تطبیق با متنی که نمایش داده می‌شود، [TextCapType](https://reference.aspose.com/slides/fa/net/aspose.slides/textcaptype/) را بررسی کنید و زمانی که مقدار `All` باشد، رشتهٔ برگردانده شده را به حروف بزرگ تبدیل کنید.

فرض کنید جعبهٔ متن زیر در اسلاید اول فایل sample2.pptx وجود دارد.

![افکت All Caps](all_caps_effect.png)

کد زیر نشان می‌دهد چگونه متن با افکت **All Caps** استخراج شود:

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

## **پرسش‌های متداول**

**چگونه متن در جدول یک اسلاید را ویرایش کنیم؟**

برای ویرایش متن در جدول یک اسلاید، از [ITable](https://reference.aspose.com/slides/fa/net/aspose.slides/itable/) استفاده کنید. سلول‌ها را پیمایش کنید و هر سلول را از طریق [ICell.TextFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/icell/textframe/) و قالب‌بندی پاراگراف از طریق [IParagraph.ParagraphFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/iparagraph/paragraphformat/) به‌روزرسانی کنید.

**چگونه رنگ گرادیان به متن در اسلاید PowerPoint اعمال کنیم؟**

برای اعمال رنگ گرادیان به متن، از [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/ibaseportionformat/fillformat/) استفاده کنید. [IFillFormat.FillType](https://reference.aspose.com/slides/fa/net/aspose.slides/ifillformat/filltype/) را به [FillType.Gradient](https://reference.aspose.com/slides/fa/net/aspose.slides/filltype/) تنظیم کنید و نقاط توقف گرادیان، جهت و شفافیت را پیکربندی کنید.