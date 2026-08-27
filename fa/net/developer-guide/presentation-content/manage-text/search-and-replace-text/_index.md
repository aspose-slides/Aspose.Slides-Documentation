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
- فریم متن
- گزارش حسابرسی
- PowerPoint
- OpenDocument
- ارائه
- .NET
- C#
- Aspose.Slides
description: "متن را در ارائه‌های PowerPoint جستجو، برجسته و جایگزین کنید در حالی که هر مطابقت را با Aspose.Slides برای .NET جمع‌آوری می‌کنید."
---
## **مروری کلی**

Aspose.Slides for .NET می‌تواند متن را در یک فریم متنی منفرد یا در تمام ارائه جستجو، برجسته و جایگزین کند. هر عملیات می‌تواند با یک فراخوانی نتیجه، برنامه را در مورد هر مطابقت آگاه سازد. این امکان به‌روز‌رسانی ارائه و به‌طور همزمان ایجاد ردپای حسابرسی شامل متن مطابقت‌داری، زمینه، موقعیت، فریم متن و شماره اسلاید را فراهم می‌آورد.

این قابلیت‌ها برای بازبینی، محو کردن، بررسی واژگان، پاک‌سازی قالب و جریان‌های کاری گزارش‌دهی خودکار مفید هستند.

در مثال‌های اولیه زیر، از پرونده‌ای به نام «sample.pptx» استفاده می‌کنیم که یک جعبه متن در اسلاید اول دارد و شامل متن زیر است:

![متن نمونه](sample_text.png)

## **انتخاب دامنه جستجو**

از روش‌های موجود در [ITextFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/itextframe/) برای محدود کردن عملیات به یک فریم متنی استفاده کنید. از روش‌های موجود در [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) برای پردازش تمام متن‌های قابل‌ اعمال در ارائه بهره ببرید.

| عملیات | یک فریم متنی | تمام ارائه |
|---|---|---|
| برجسته‌سازی متن لغوی | [ITextFrame.HighlightText](https://reference.aspose.com/slides/fa/net/aspose.slides/itextframe/highlighttext/) | [Presentation.HighlightText](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/highlighttext/) |
| برجسته‌سازی مطابقت‌های عبارت منظم | [ITextFrame.HighlightRegex](https://reference.aspose.com/slides/fa/net/aspose.slides/itextframe/highlightregex/) | [Presentation.HighlightRegex](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/highlightregex/) |
| جایگزینی متن لغوی | [ITextFrame.ReplaceText](https://reference.aspose.com/slides/fa/net/aspose.slides/itextframe/replacetext/) | [Presentation.ReplaceText](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/replacetext/) |
| جایگزینی مطابقت‌های عبارت منظم | [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/fa/net/aspose.slides/itextframe/replaceregex/) | [Presentation.ReplaceRegex](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/replaceregex/) |

## **پیکربندی مطابقت متن**

برای عملیات متن لغوی، از [TextSearchOptions](https://reference.aspose.com/slides/fa/net/aspose.slides/textsearchoptions/) برای کنترل مطابقت استفاده کنید:

- [TextSearchOptions.WholeWordsOnly](https://reference.aspose.com/slides/fa/net/aspose.slides/textsearchoptions/wholewordsonly/) مطابقت‌ها را فقط به کلمات کامل محدود می‌کند.
- [TextSearchOptions.CaseSensitive](https://reference.aspose.com/slides/fa/net/aspose.slides/textsearchoptions/casesensitive/) تعیین می‌کند که حروف باید با حساسیت به حالت (بزرگ/کوچک) مطابقت داشته باشند یا نه.
- [TextSearchOptions.IncludeNotes](https://reference.aspose.com/slides/fa/net/aspose.slides/textsearchoptions/includenotes/) یادداشت‌های اسلاید را در عملیات جستجو، جایگزینی و برجسته‌سازی در سطح ارائه گنجانده می‌شود.

عملیات‌های عبارت منظم از یک `Regex` در .NET استفاده می‌کنند، بنابراین قوانین مطابقت مانند حساسیت به حالت و مرزهای کلمه توسط الگو و گزینه‌های آن تعریف می‌شود.

## **شناسایی مالک فریم متنی**

رویکردهای عمومی پردازش متن اغلب یک [ITextFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/itextframe/) را در حین جستجو، جایگزینی، اعتبارسنجی یا استخراج دریافت می‌کنند. برای تعیین شیء ارائه‌ای که فریم متن را مالک است، از [ITextFrame.ParentShape](https://reference.aspose.com/slides/fa/net/aspose.slides/itextframe/parentshape/) و [ITextFrame.ParentCell](https://reference.aspose.com/slides/fa/net/aspose.slides/itextframe/parentcell/) استفاده کنید.

مقادیر مورد انتظار بسته به مالک متفاوت است:

| مالک فریم متنی | `ParentShape` | `ParentCell` |
|---|---|---|
| یک AutoShape یا شکل دیگری که متن دارد | شیء مالک [IShape](https://reference.aspose.com/slides/fa/net/aspose.slides/ishape/) | `null` |
| یک سلول جدول | `null` | شیء مالک [ICell](https://reference.aspose.com/slides/fa/net/aspose.slides/icell/) |

هر دو ویژگی فقط-خواندنی هستند. خواندن آن‌ها فریم متن را جابجا یا مالک آن را تغییر نمی‌دهد. کد عمومی باید هر دو مقدار را برای `null` بررسی کند و امکان عدم وجود هر دو مالک را در نظر بگیرد.

مثال زیر از [SlideUtil.GetAllTextFrames](https://reference.aspose.com/slides/fa/net/aspose.slides.util/slideutil/getalltextframes/) برای پیمایش فریم‌های متنی در یک ارائه استفاده می‌کند. برای اشکال، نام شکل، نوع شکل و اسلاید حاوی آن گزارش می‌شود. برای سلول‌های جدول، مختصات ستون و ردیف صفر‑مبنای و اسلاید حاوی آن گزارش می‌شود.

```cs
using System;
using Aspose.Slides;
using Aspose.Slides.Util;

using var presentation = new Presentation("presentation.pptx");

var textFrames = SlideUtil.GetAllTextFrames(presentation, false);

foreach (var textFrame in textFrames)
{
    var ownerShape = textFrame.ParentShape;
    if (ownerShape != null)
    {
        var shapeName = string.IsNullOrEmpty(ownerShape.Name) ? "(unnamed)" : ownerShape.Name;
        var shapeType = GetShapeType(ownerShape);
        var slideLabel = GetSlideLabel(ownerShape.Slide);
        Console.WriteLine($"Shape: {shapeName}; type: {shapeType}; {slideLabel}");

        continue;
    }

    var ownerCell = textFrame.ParentCell;
    if (ownerCell != null)
    {
        var slideLabel = GetSlideLabel(ownerCell.Slide);
        Console.WriteLine($"Table cell: column {ownerCell.FirstColumnIndex}, row {ownerCell.FirstRowIndex}; {slideLabel}");
        continue;
    }

    Console.WriteLine("The text frame owner is not available as a shape or table cell.");
}

static string GetShapeType(IShape shape)
{
    if (shape is IGeometryShape geometryShape)
    {
        return geometryShape.ShapeType.ToString();
    }

    return shape.GetType().Name;
}

static string GetSlideLabel(IBaseSlide baseSlide)
{
    if (baseSlide is ISlide slide)
    {
        return $"slide {slide.SlideNumber}";
    }

    if (baseSlide is INotesSlide notesSlide)
    {
        return $"notes for slide {notesSlide.ParentSlide.SlideNumber}";
    }

    return baseSlide.GetType().Name;
}
```

برای محتوای SmartArt، در اشکال موجود در [ISmartArtNode.Shapes](https://reference.aspose.com/slides/fa/net/aspose.slides.smartart/ismartartnode/shapes/) پیمایش کنید و به هر [ISmartArtShape.TextFrame](https://reference.aspose.com/slides/fa/net/aspose.slides.smartart/ismartartshape/textframe/) دسترسی داشته باشید. فریم متنی می‌تواند از طریق [ITextFrame.ParentShape](https://reference.aspose.com/slides/fa/net/aspose.slides/itextframe/parentshape/) به شکل مرتبط خود ردیابی شود، در حالی که [ITextFrame.ParentCell](https://reference.aspose.com/slides/fa/net/aspose.slides/itextframe/parentcell/) برابر `null` است. بنابراین شاخه شکل در مثال نیز متن SmartArt را پردازش می‌کند.

## **جمع‌آوری اطلاعات مطابقت با فراخوانی بازگشت**

برای دریافت اطلاعیه برای هر مطابقت، [IFindResultCallback](https://reference.aspose.com/slides/fa/net/aspose.slides/ifindresultcallback/) را پیاده‌سازی کنید. متد [IFindResultCallback.FoundResult](https://reference.aspose.com/slides/fa/net/aspose.slides/ifindresultcallback/foundresult/) فریم متن مرتبط، متن منبع، متن مطابقت‌دار و موقعیت مطابقت را فراهم می‌کند.

فراخوانی بازگشت شماره اسلاید را مستقیماً دریافت نمی‌کند. پیاده‌سازی زیر آن را از اسلاید والد استخراج می‌کند و متن موجود در یادداشت اسلاید را نیز مدیریت می‌کند. یک شماره اسلاید nullable امکان نمایندگی متن مرتبط با انواع دیگر اسلایدها را در همان مدل نتیجه فراهم می‌سازد.

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
        var parentSlide = textFrame.ParentShape?.Slide ?? textFrame.ParentCell?.Slide ?? textFrame.Slide;

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

برای عملیات جایگزینی، `FoundText` شامل متن اصلی مطابقت‌دار است، بنابراین فراخوانی می‌تواند دقیقاً ثبت کند که کدام عبارات جایگزین شده‌اند.

## **برجسته‌سازی متن**

از متد [ITextFrame.HighlightText](https://reference.aspose.com/slides/fa/net/aspose.slides/itextframe/highlighttext/) برای برجسته‌سازی مطابقت‌های متن لغوی در یک فریم متنی استفاده کنید. برای کنترل جستجو، یک [TextSearchOptions](https://reference.aspose.com/slides/fa/net/aspose.slides/textsearchoptions/) پاس بدهید و برای جمع‌آوری جزئیات مطابقت یک فراخوانی بازگشت ارائه کنید.

کد زیر تمام رخدادهای کاراکترهای **"try"** را برجسته می‌کند و سپس فقط کلمهٔ کامل **"to"** را. هر دو جستجو مطابقت‌های خود را به همان فراخوانی بازگشت گزارش می‌دهند.

```cs
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");

// دریافت اولین شکل از اولین اسلاید.
var shape = (IAutoShape)presentation.Slides[0].Shapes[0];
var callback = new TextSearchCallback();

var substringSearchOptions = new TextSearchOptions
{
    CaseSensitive = false
};

// برجسته‌سازی تمام رخدادهای "try" در فریم متن.
shape.TextFrame.HighlightText("try", Color.LightBlue, substringSearchOptions, callback);

var wholeWordSearchOptions = new TextSearchOptions
{
    WholeWordsOnly = true,
    CaseSensitive = false
};

// برجسته‌سازی فقط کلمه کامل "to".
shape.TextFrame.HighlightText("to", Color.Violet, wholeWordSearchOptions, callback);

foreach (var result in callback.Results)
{
    Console.WriteLine($"Found '{result.FoundText}' at position {result.TextPosition} on slide {result.SlideNumber}.");
}

presentation.Save("highlighted_text.pptx", SaveFormat.Pptx);
```

نتیجه:

![متن برجسته‌شده](highlighted_text.png)

## **برجسته‌سازی متن با استفاده از عبارات منظم**

متد [ITextFrame.HighlightRegex](https://reference.aspose.com/slides/fa/net/aspose.slides/itextframe/highlightregex/) متن مطابقت‌یافته با یک عبارت منظم را در یک فریم متنی برجسته می‌کند.

کد زیر تمام کلمات حاوی هفت یا بیشتر کاراکتر را برجسته کرده و هر مطابقت را جمع‌آوری می‌کند:

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

![متن برجسته‌شده با استفاده از عبارت منظم](highlighted_text_using_regex.png)

## **برجسته‌سازی متن در سراسر یک ارائه**

از [Presentation.HighlightText](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/highlighttext/) و [Presentation.HighlightRegex](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/highlightregex/) برای جستجوی تمام فریم‌های متنی قابل‌ اعمال در یک ارائه استفاده کنید. مثال زیر یک اصطلاح لغوی و تمام آدرس‌های ایمیل را برجسته می‌کند در حالی که مجموعه نتایج جداگانه‌ای برای دو جستجو نگه می‌دارد.

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

## **جایگزینی متن در یک فریم متنی**

برای متن لغوی از [ITextFrame.ReplaceText](https://reference.aspose.com/slides/fa/net/aspose.slides/itextframe/replacetext/) و برای جایگزینی مبتنی بر الگو از [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/fa/net/aspose.slides/itextframe/replaceregex/) استفاده کنید. این روش‌ها متن مطابقت‌یافته را درون فریم متنی موجود به‌روز می‌کنند و قالب‌بندی بخش‌های اطراف را حفظ می‌نمایند، به‌جای ساخت مجدد فریم از یک رشتهٔ ساده.

مثال زیر یک نوع نوشتاری را استانداردسازی می‌کند و سپس برچسب‌های نسخه را جایگزین می‌سازد. همان فراخوانی بازگشت عبارات اصلی مطابقت‌دار توسط هر دو عملیات را ثبت می‌کند.

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

اگر یک مطابقت بخش‌هایی با قالب‌بندی متفاوت را در بر گیرد، خروجی را بررسی کنید تا تأیید کنید کدام قالب‌بندی باید برای متن جایگزین اعمال شود.

## **جایگزینی متن در سراسر یک ارائه**

از [Presentation.ReplaceText](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/replacetext/) و [Presentation.ReplaceRegex](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/replaceregex/) برای اعمال همان عملیات در سراسر ارائه استفاده کنید. این روش برای پاک‌سازی قالب، به‌روزرسانی واژگان و محو کردن مفید است.

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

## **گروه‌بندی مطابقت‌ها برای گزارش‌گیری**

از آنجا که هر نتیجه شماره اسلاید و فریم متن را ذخیره می‌کند، برنامه‌ها می‌توانند مطابقت‌ها را برای حسابرسی، گزارش‌گیری یا کارهای بازبینی گروه‌بندی کنند. مثال زیر نتایج جمع‌آوری‌شده را ابتدا بر حسب اسلاید و سپس بر حسب فریم متن گروه‌بندی می‌کند:

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

## **سوالات متداول**

**چگونه می‌توانم فقط یک جعبه متن را به جای تمام ارائه جستجو کنم؟**

فریم متن شکل را دریافت کنید و بر روی آن [ITextFrame.HighlightText](https://reference.aspose.com/slides/fa/net/aspose.slides/itextframe/highlighttext/)، [ITextFrame.HighlightRegex](https://reference.aspose.com/slides/fa/net/aspose.slides/itextframe/highlightregex/)، [ITextFrame.ReplaceText](https://reference.aspose.com/slides/fa/net/aspose.slides/itextframe/replacetext/) یا [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/fa/net/aspose.slides/itextframe/replaceregex/) فراخوانی کنید. روش‌های سطح ارائه تمام فریم‌های متنی قابل‌ اعمال را پردازش می‌کنند.

**چگونه می‌توانم کلمات کامل را با حروف بزرگ/کوچک صحیح مطابقت دهم؟**

[TextSearchOptions.WholeWordsOnly](https://reference.aspose.com/slides/fa/net/aspose.slides/textsearchoptions/wholewordsonly/) و [TextSearchOptions.CaseSensitive](https://reference.aspose.com/slides/fa/net/aspose.slides/textsearchoptions/casesensitive/) را به `true` تنظیم کنید و گزینه‌ها را به متد برجسته‌سازی یا جایگزینی متن لغوی پاس دهید. برای عبارات منظم، مرزهای کلمه و حساسیت به حروف را در خود `Regex` تعریف کنید.

**آیا می‌توان جستجو و جایگزینی را شامل متن موجود در یادداشت‌های اسلاید کرد؟**

بله. هنگام استفاده از یک عملیات متن لغوی در سطح ارائه، [TextSearchOptions.IncludeNotes](https://reference.aspose.com/slides/fa/net/aspose.slides/textsearchoptions/includenotes/) را به `true` تنظیم کنید. پیاده‌سازی فراخوانی بازگشت در بالا یک مطابقت در اسلاید یادداشت را به شماره اسلاید والد خود نگاشت می‌کند.

**چگونه می‌توانم گزارش بدون اسکن دوبارهٔ ارائه ایجاد کنم؟**

یک پیاده‌سازی از [IFindResultCallback](https://reference.aspose.com/slides/fa/net/aspose.slides/ifindresultcallback/) را به عملیات برجسته‌سازی یا جایگزینی پاس دهید. فراخوانی بازگشت هر مطابقت را در حین اجرا دریافت می‌کند، بنابراین برنامه می‌تواند متن منبع، متن مطابقت‌دار، موقعیت، فریم متن و شماره اسلاید مشتق‌شده را برای گروه‌بندی یا خروجی بعدی ذخیره کند.

**آیا جایگزینی متن قالب‌بندی آن را حفظ می‌کند؟**

[ITextFrame.ReplaceText](https://reference.aspose.com/slides/fa/net/aspose.slides/itextframe/replacetext/) و [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/fa/net/aspose.slides/itextframe/replaceregex/) متن مطابقت‌یافته را درون فریم متنی موجود اصلاح می‌کنند و قالب‌بندی بخش‌های اطراف را حفظ می‌نمایند. اگر یک مطابقت بخش‌هایی با قالب‌بندی متفاوت را در بر گیرد، نتیجه را بررسی کنید تا اطمینان حاصل کنید جایگزینی از سبک موردنظر استفاده می‌کند.