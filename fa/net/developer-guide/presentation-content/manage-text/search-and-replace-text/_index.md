---
title: جستجو و جایگزینی متن در ارائه‌های PowerPoint در .NET
linktitle: جستجو و جایگزینی متن
type: docs
weight: 55
url: /fa/net/search-and-replace-text/
keywords:
- جستجوی متن
- برجسته‌سازی متن
- جایگزینی متن
- عبارت منظم
- فراخوانی نتیجه
- قاب متن
- گزارش حسابرسی
- PowerPoint
- OpenDocument
- ارائه
- .NET
- C#
- Aspose.Slides
description: "جستجو، برجسته‌سازی و جایگزینی متن در ارائه‌های PowerPoint هنگام جمع‌آوری هر تطبیق با Aspose.Slides برای .NET."
---
## **نمای کلی**

Aspose.Slides for .NET می‌تواند متن را در یک قاب متن منفرد یا در کل ارائه جستجو، برجسته‌سازی و جایگزینی کند. هر عملیات می‌تواند با استفاده از یک فراخوانی نتیجه، برنامه را از هر تطبیق آگاه کند. این امکان را می‌دهد تا یک ارائه را به‌روزرسانی کنید و به‌طور همزمان یک مسیر حسابرسی شامل متن مطابق، زمینه آن، موقعیت، قاب متن و شماره اسلاید ایجاد کنید.

این قابلیت‌ها برای مرور، حذف، بررسی واژگان، پاک‌سازی قالب و گردش‌کارهای گزارش‌گیری خودکار مفید هستند.

در مثال‌های اول زیر، از فایلی به نام "sample.pptx" استفاده می‌کنیم که یک جعبه متن واحد در اسلاید اول دارد و متن زیر را شامل می‌شود:

![متن نمونه](sample_text.png)

## **انتخاب دامنه جستجو**

از متدهای [ITextFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/itextframe/) برای محدود کردن یک عملیات به یک قاب متن استفاده کنید. از متدهای [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) برای پردازش تمام متن‌های قابل اعمال در ارائه استفاده کنید.

| عملیات | یک قاب متن | کل ارائه |
|---|---|---|
| برجسته‌سازی متن ثابت | [ITextFrame.HighlightText](https://reference.aspose.com/slides/fa/net/aspose.slides/itextframe/highlighttext/) | [Presentation.HighlightText](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/highlighttext/) |
| برجسته‌سازی تطبیق‌های عبارات منظم | [ITextFrame.HighlightRegex](https://reference.aspose.com/slides/fa/net/aspose.slides/itextframe/highlightregex/) | [Presentation.HighlightRegex](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/highlightregex/) |
| جایگزینی متن ثابت | [ITextFrame.ReplaceText](https://reference.aspose.com/slides/fa/net/aspose.slides/itextframe/replacetext/) | [Presentation.ReplaceText](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/replacetext/) |
| جایگزینی تطبیق‌های عبارات منظم | [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/fa/net/aspose.slides/itextframe/replaceregex/) | [Presentation.ReplaceRegex](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/replaceregex/) |

## **پیکربندی مطابقت متن**

برای عملیات متن ثابت، از [TextSearchOptions](https://reference.aspose.com/slides/fa/net/aspose.slides/textsearchoptions/) برای کنترل تطبیق استفاده کنید:

- [TextSearchOptions.WholeWordsOnly](https://reference.aspose.com/slides/fa/net/aspose.slides/textsearchoptions/wholewordsonly/) تطبیق‌ها را به کلمات کامل محدود می‌کند.
- [TextSearchOptions.CaseSensitive](https://reference.aspose.com/slides/fa/net/aspose.slides/textsearchoptions/casesensitive/) تعیین می‌کند که حروف باید به‌طور دقیق مطابقت داشته باشند.
- [TextSearchOptions.IncludeNotes](https://reference.aspose.com/slides/fa/net/aspose.slides/textsearchoptions/includenotes/) یادداشت‌های اسلاید را در عملیات جستجو، جایگزینی و برجسته‌سازی سطح ارائه شامل می‌شود.

عملیات‌های عبارات منظم از یک `Regex` .NET استفاده می‌کنند، بنابراین قوانین مطابقت مانند حساسیت به حروف و مرزهای کلمه توسط الگو و گزینه‌های آن تعریف می‌شوند.

## **جمع‌آوری اطلاعات تطبیق با فراخوانی**

یک پیاده‌سازی از [IFindResultCallback](https://reference.aspose.com/slides/fa/net/aspose.slides/ifindresultcallback/) برای دریافت اعلان برای هر تطبیق پیاده کنید. متد [IFindResultCallback.FoundResult](https://reference.aspose.com/slides/fa/net/aspose.slides/ifindresultcallback/foundresult/) آن قاب متن مرتبط، متن منبع، متن مطابقت‌یافته و موقعیت تطبیق را ارائه می‌دهد.

فراخوانی شماره اسلاید را به‌صورت مستقیم دریافت نمی‌کند. پیاده‌سازی زیر آن را از اسلاید والد استخراج می‌کند و همچنین متنی که در یادداشت‌های اسلاید یافت می‌شود را مدیریت می‌کند. یک شماره اسلاید قابل نال شدن اجازه می‌دهد تا همان مدل نتیجه متن مرتبط با انواع دیگر اسلایدها را نشان دهد.

```cs
using System.Collections.Generic;
using Aspose.Slides;

public sealed class TextMatch
{
    public TextMatch(ITextFrame textFrame, string sourceText, string foundText, int textPosition, int? slideNumber)
    {
        TextFrame = textFrame;
        SourceText = sourceText;
        FoundText = foundText;
        TextPosition = textPosition;
        SlideNumber = slideNumber;
    }

    public ITextFrame TextFrame { get; }
    public string SourceText { get; }
    public string FoundText { get; }
    public int TextPosition { get; }
    public int? SlideNumber { get; }
}

public sealed class TextSearchCallback : IFindResultCallback
{
    public List<TextMatch> Results { get; } = new();

    public void FoundResult(ITextFrame textFrame, string sourceText, string foundText, int textPosition)
    {
        var slideNumber = GetSlideNumber(textFrame);
        var result = new TextMatch(textFrame, sourceText, foundText, textPosition, slideNumber);

        Results.Add(result);
    }

    private static int? GetSlideNumber(ITextFrame textFrame)
    {
        if (textFrame is not TextFrame concreteTextFrame)
        {
            return null;
        }

        var parentSlide = concreteTextFrame.Slide;

        if (parentSlide is ISlide slide)
        {
            return slide.SlideNumber;
        }

        if (parentSlide is INotesSlide notesSlide)
        {
            return notesSlide.ParentSlide.SlideNumber;
        }

        return null;
    }
}
```

برای عملیات جایگزینی، `FoundText` شامل متن اصلی مطابقت‌یافته است، بنابراین فراخوانی می‌تواند دقیقاً ثبت کند که چه اصطلاحاتی جایگزین شده‌اند.

## **برجسته‌سازی متن**

از متد [ITextFrame.HighlightText](https://reference.aspose.com/slides/fa/net/aspose.slides/itextframe/highlighttext/) برای برجسته‌سازی تطبیق‌های متن ثابت در یک قاب متن استفاده کنید. برای کنترل جستجو و جمع‌آوری جزئیات تطبیق، یک [TextSearchOptions](https://reference.aspose.com/slides/fa/net/aspose.slides/textsearchoptions/) و یک فراخوانی پاس کنید.

کد زیر تمام رخدادهای کاراکترهای **"try"** را برجسته می‌کند و سپس تنها کلمه کامل **"to"** را برجسته می‌سازد. هر دو جستجو تطبیق‌های خود را به همان فراخوانی گزارش می‌دهند.

```cs
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");

// Get the first shape from the first slide.
var shape = (IAutoShape)presentation.Slides[0].Shapes[0];
var callback = new TextSearchCallback();

var substringSearchOptions = new TextSearchOptions
{
    CaseSensitive = false
};

// Highlight every occurrence of "try" in the text frame.
shape.TextFrame.HighlightText("try", Color.LightBlue, substringSearchOptions, callback);

var wholeWordSearchOptions = new TextSearchOptions
{
    WholeWordsOnly = true,
    CaseSensitive = false
};

// Highlight only the complete word "to".
shape.TextFrame.HighlightText("to", Color.Violet, wholeWordSearchOptions, callback);

foreach (var result in callback.Results)
{
    Console.WriteLine($"Found '{result.FoundText}' at position {result.TextPosition} on slide {result.SlideNumber}.");
}

presentation.Save("highlighted_text.pptx", SaveFormat.Pptx);
```

نتیجه:

![متن برجسته شده](highlighted_text.png)

## **برجسته‌سازی متن با استفاده از عبارات منظم**

متد [ITextFrame.HighlightRegex](https://reference.aspose.com/slides/fa/net/aspose.slides/itextframe/highlightregex/) تطبیق‌های متنی را که با یک عبارت منظم پیدا می‌شوند، در یک قاب متن برجسته می‌کند.

کد زیر تمام کلماتی که شامل هفت یا بیشتر کاراکتر هستند را برجسته می‌کند و هر تطبیق را جمع‌آوری می‌نماید:

```cs
using System.Drawing;
using System.Text.RegularExpressions;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");

var shape = (IAutoShape)presentation.Slides[0].Shapes[0];
var callback = new TextSearchCallback();
var regex = new Regex(@"\b[^\s]{7,}\b");

shape.TextFrame.HighlightRegex(regex, Color.Yellow, callback);

presentation.Save("highlighted_text_using_regex.pptx", SaveFormat.Pptx);
```

نتیجه:

![متن برجسته شده با استفاده از عبارت منظم](highlighted_text_using_regex.png)

## **برجسته‌سازی متن در کل ارائه**

از [Presentation.HighlightText](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/highlighttext/) و [Presentation.HighlightRegex](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/highlightregex/) برای جستجو در تمام قاب‌های متنی قابل اعمال در یک ارائه استفاده کنید. مثال زیر یک اصطلاح ثابت و تمام آدرس‌های ایمیل را برجسته می‌کند در حالی که مجموعه نتایج جداگانه‌ای برای دو جستجو نگه می‌دارد.

```cs
using System.Drawing;
using System.Text.RegularExpressions;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var termCallback = new TextSearchCallback();
var searchOptions = new TextSearchOptions
{
    WholeWordsOnly = true,
    CaseSensitive = false
};

presentation.HighlightText("confidential", Color.Orange, searchOptions, termCallback);

var emailCallback = new TextSearchCallback();
var emailRegex = new Regex(@"\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,}\b", RegexOptions.IgnoreCase);

presentation.HighlightRegex(emailRegex, Color.Yellow, emailCallback);

presentation.Save("highlighted_presentation.pptx", SaveFormat.Pptx);
```

## **جایگزینی متن در یک قاب متن**

از [ITextFrame.ReplaceText](https://reference.aspose.com/slides/fa/net/aspose.slides/itextframe/replacetext/) برای متن ثابت و [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/fa/net/aspose.slides/itextframe/replaceregex/) برای جایگزینی بر پایه الگو استفاده کنید. این متدها متن مطابقت‌یافته را درون قاب متن موجود به‌روزرسانی می‌کنند و قالب‌بندی قسمت‌های اطراف را حفظ می‌نمایند، به جای این که قاب متن را از یک رشته ساده بازسازی کنند.

مثال زیر یک واریانت املایی را استاندارد کرده و سپس برچسب‌های نسخه را جایگزین می‌کند. همان فراخوانی اصطلاحات اصلی مطابقت‌یافته توسط هر دو عملیات را ثبت می‌کند.

```cs
using System.Text.RegularExpressions;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var shape = (IAutoShape)presentation.Slides[0].Shapes[0];
var callback = new TextSearchCallback();
var searchOptions = new TextSearchOptions
{
    WholeWordsOnly = true,
    CaseSensitive = false
};

shape.TextFrame.ReplaceText("colour", "color", searchOptions, callback);

var versionRegex = new Regex(@"\bv\d+(?:\.\d+)*\b", RegexOptions.IgnoreCase);
shape.TextFrame.ReplaceRegex(versionRegex, "current version", callback);

presentation.Save("updated_text_frame.pptx", SaveFormat.Pptx);
```

اگر یک تطبیق بخش‌هایی با قالب‌بندی متفاوت را در بر گیرد، خروجی را بررسی کنید تا تأیید کنید کدام قالب‌بندی باید بر متن جایگزین اعمال شود.

## **جایگزینی متن در کل ارائه**

از [Presentation.ReplaceText](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/replacetext/) و [Presentation.ReplaceRegex](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/replaceregex/) برای اعمال همان عملیات‌ها در سراسر ارائه استفاده کنید. این برای پاک‌سازی قالب، به‌روزرسانی واژگان و حذف اطلاعات مفید است.

```cs
using System.Text.RegularExpressions;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var callback = new TextSearchCallback();
var searchOptions = new TextSearchOptions
{
    WholeWordsOnly = true,
    CaseSensitive = true
};

presentation.ReplaceText("Contoso", "Example Corp", searchOptions, callback);

var accountNumberRegex = new Regex(@"\bACCT-\d{6}\b");
presentation.ReplaceRegex(accountNumberRegex, "ACCT-REDACTED", callback);

presentation.Save("updated_presentation.pptx", SaveFormat.Pptx);
```

## **گروه‌بندی تطبیق‌ها برای گزارش‌گیری**

از آنجا که هر نتیجه شماره اسلاید و قاب متن خود را ذخیره می‌کند، برنامه‌ها می‌توانند تطبیق‌ها را برای حسابرسی، گزارش‌گیری یا گردش‌کارهای مرور گروه‌بندی کنند. مثال زیر نتایج جمع‌آوری‌شده را ابتدا بر اساس اسلاید و سپس بر اساس قاب متن گروه‌بندی می‌کند:

```cs
using System;
using System.Linq;

var matchesBySlide = callback.Results.GroupBy(result => result.SlideNumber);

foreach (var slideGroup in matchesBySlide)
{
    var slideLabel = slideGroup.Key.HasValue ? slideGroup.Key.Value.ToString() : "Other";
    Console.WriteLine($"Slide: {slideLabel}");

    var matchesByTextFrame = slideGroup.GroupBy(result => result.TextFrame);
    foreach (var textFrameGroup in matchesByTextFrame)
    {
        Console.WriteLine($"  Text frame: {textFrameGroup.Key.Text}");

        foreach (var result in textFrameGroup)
        {
            Console.WriteLine($"    '{result.FoundText}' at position {result.TextPosition}; context: '{result.SourceText}'");
        }
    }
}
```

## **سؤال‌های متداول**

**چگونه می‌توانم فقط یک جعبه متن را به‌جای کل ارائه جستجو کنم؟**

قاب متن شکل را به‌دست آورید و بر روی آن [ITextFrame.HighlightText](https://reference.aspose.com/slides/fa/net/aspose.slides/itextframe/highlighttext/)، [ITextFrame.HighlightRegex](https://reference.aspose.com/slides/fa/net/aspose.slides/itextframe/highlightregex/)، [ITextFrame.ReplaceText](https://reference.aspose.com/slides/fa/net/aspose.slides/itextframe/replacetext/) یا [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/fa/net/aspose.slides/itextframe/replaceregex/) فراخوانی کنید. متدهای سطح ارائه تمام قاب‌های متنی قابل اعمال را پردازش می‌کنند.

**چگونه می‌توانم کلمات کامل را با حروف بزرگ/کوچک صحیح مطابقت دهم؟**

[TextSearchOptions.WholeWordsOnly](https://reference.aspose.com/slides/fa/net/aspose.slides/textsearchoptions/wholewordsonly/) و [TextSearchOptions.CaseSensitive](https://reference.aspose.com/slides/fa/net/aspose.slides/textsearchoptions/casesensitive/) را به `true` تنظیم کنید و گزینه‌ها را به متد برجسته‌سازی یا جایگزینی متن ثابت پاس دهید. برای عبارات منظم، مرزهای کلمه و حساسیت به حروف را در خود `Regex` تعریف کنید.

**آیا جستجو و جایگزینی می‌توانند متن در یادداشت‌های اسلاید را شامل شوند؟**

بله. هنگام استفاده از عملیات متن ثابت در سطح ارائه، [TextSearchOptions.IncludeNotes](https://reference.aspose.com/slides/fa/net/aspose.slides/textsearchoptions/includenotes/) را به `true` تنظیم کنید. پیاده‌سازی فراخوانی نشان‌شده در بالا یک تطبیق در اسلاید یادداشت‌ها را به شماره اسلاید والد خود بازمی‌گرداند.

**چگونه می‌توانم گزارش بدون اسکن مجدد ارائه ایجاد کنم؟**

یک پیاده‌سازی از [IFindResultCallback](https://reference.aspose.com/slides/fa/net/aspose.slides/ifindresultcallback/) را به عملیات برجسته‌سازی یا جایگزینی پاس کنید. فراخوانی در حین اجرای عملیات هر تطبیق را دریافت می‌کند، بنابراین برنامه می‌تواند متن منبع، متن مطابقت‌یافته، موقعیت، قاب متن و شماره اسلاید استخراج‌شده را برای گروه‌بندی یا خروجی بعدی ذخیره کند.

**آیا جایگزینی متن قالب‌بندی آن را حفظ می‌کند؟**

[ITextFrame.ReplaceText](https://reference.aspose.com/slides/fa/net/aspose.slides/itextframe/replacetext/) و [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/fa/net/aspose.slides/itextframe/replaceregex/) متن مطابقت‌یافته را درون قاب متن موجود اصلاح می‌کنند و قالب‌بندی بخش‌های اطراف را حفظ می‌نمایند. اگر یک تطبیق بخش‌هایی با قالب‌بندی متفاوت را شامل شود، نتیجه را بررسی کنید تا اطمینان حاصل کنید که جایگزینی از استایل مطلوب استفاده می‌کند.