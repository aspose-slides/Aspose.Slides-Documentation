---
title: جستجو و جایگزینی متن در ارائه‌های PowerPoint با JavaScript
linktitle: جستجو و جایگزینی متن
type: docs
weight: 55
url: /fa/nodejs-java/search-and-replace-text/
keywords:
- جستجوی متن
- هایلایت متن
- جایگزینی متن
- عبارت منظم
- کال‌بک نتیجه
- قاب متن
- گزارش حسابرسی
- PowerPoint
- OpenDocument
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: جستجو، هایلایت و جایگزینی متن در ارائه‌های PowerPoint در حالی که هر مطابقت با Aspose.Slides برای Node.js از طریق Java جمع‌آوری می‌شود.
---
## **مرور کلی**

Aspose.Slides برای Node.js از طریق Java می‌تواند متن را در یک قاب متن منفرد یا در کل ارائه جستجو، هایلایت و جایگزین کند. هر عملیات می‌تواند با استفاده از یک کال‌بک نتیجه، برنامه را از هر تطابق آگاه سازد. این امکان را می‌دهد تا یک ارائه بروزرسانی شود و همزمان یک ردپای حسابرسی شامل متن مطابقت یافته، زمینه‌ آن، موقعیت، قاب متن و شماره اسلاید ساخته شود.

این قابلیت‌ها برای بازبینی، حذف اطلاعات حساس، بررسی اصطلاحات، پاک‌سازی قالب و جریان‌های کاری گزارش‌گیری خودکار مفید هستند.

در مثال‌های اولیه زیر، از فایلی به نام «sample.pptx» استفاده می‌کنیم که یک جعبه متن روی اسلاید اول دارد و متن زیر را شامل می‌شود:

![Sample text](sample_text.png)

## **انتخاب دامنه جستجو**

از متدهای موجود در [TextFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframe/) برای محدود کردن یک عملیات به یک قاب متن استفاده کنید. از متدهای موجود در [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) برای پردازش تمام متن‌های قابل اعمال در ارائه بهره ببرید.

| عملیات | یک قاب متن | کل ارائه |
|---|---|---|
| هایلایت متن عینی | [TextFrame.highlightText](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [Presentation.highlightText](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| هایلایت تطابق‌های عبارت منظم | [TextFrame.highlightRegex](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) | [Presentation.highlightRegex](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) |
| جایگزینی متن عینی | [TextFrame.replaceText](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [Presentation.replaceText](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| جایگزینی تطابق‌های عبارت منظم | [TextFrame.replaceRegex](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) | [Presentation.replaceRegex](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) |

## **پیکربندی مطابقت متن**

برای عملیات متن عینی، از [TextSearchOptions](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textsearchoptions/) برای کنترل مطابقت استفاده کنید:

- [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) فقط تطابق‌های کامل کلمات را می‌پذیرد.
- [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) تعیین می‌کند که تشخیص حروف بزرگ/کوچک الزامی باشد یا نه.
- [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) یادداشت‌های اسلاید را در جستجو، جایگزینی و هایلایت سطح ارائه شامل می‌شود.

عملیات مبتنی بر عبارت منظم از یک `Pattern` جاوا استفاده می‌کند، بنابراین قواعد مطابقت مانند حساسیت به حروف و مرزهای کلمه توسط خود عبارت و پرچم‌های آن تعریف می‌شود.

## **جمع‌آوری اطلاعات مطابقت با کال‌بک**

یک پراکسی جاوا برای کال‌بک نتیجه ایجاد کنید تا برای هر تطابق یک اعلان دریافت کنید. تابع پراکسی قاب متن مربوطه، متن منبع، متن مطابقت یافته و موقعیت مطابقت را دریافت می‌کند.

کال‌بک مستقیماً شماره اسلاید را دریافت نمی‌کند. پیاده‌سازی زیر آن را از طریق [TextFrame.getSlide](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframe/#getSlide--)، [Slide.getSlideNumber](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/slide/#getSlideNumber--) و [NotesSlide.getParentSlide](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/notesslide/#getParentSlide--) استخراج می‌کند. همچنین متن موجود در یادداشت‌های اسلاید را مدیریت می‌کند.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

function getSlideNumber(textFrame) {
    const parentSlide = textFrame.getSlide();

    if (java.instanceOf(parentSlide, "com.aspose.slides.Slide")) {
        return parentSlide.getSlideNumber();
    }

    if (java.instanceOf(parentSlide, "com.aspose.slides.NotesSlide")) {
        return parentSlide.getParentSlide().getSlideNumber();
    }

    return null;
}

function createTextSearchCallback(results) {
    return java.newProxy("com.aspose.slides.IFindResultCallback", {
        foundResult: function(textFrame, sourceText, foundText, textPosition) {
            results.push({
                textFrame: textFrame,
                sourceText: sourceText,
                foundText: foundText,
                textPosition: textPosition,
                slideNumber: getSlideNumber(textFrame)
            });
        }
    });
}
```

برای عملیات جایگزینی، `foundText` شامل متن اصلی مطابقت یافته است، بنابراین کال‌بک می‌تواند دقیقاً ثبت کند که کدام عبارات جایگزین شده‌اند.

## **هایلایت متن**

از متد [TextFrame.highlightText](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) برای هایلایت تطابق‌های متن عینی در یک قاب متن استفاده کنید. برای کنترل جستجو، یک شیء [TextSearchOptions](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textsearchoptions/) را پاس دهید.

کد مثال زیر تمام رخدادهای کاراکترهای **"try"** را هایلایت می‌کند و سپس تنها کلمه کامل **"to"** را هایلایت می‌نماید.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().get_Item(0);

    const substringSearchOptions = new aspose.slides.TextSearchOptions();
    substringSearchOptions.setCaseSensitive(false);
    const substringHighlightColor = java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY");

    // در هر رخداد "try" در قاب متن را هایلایت کنید.
    shape.getTextFrame().highlightText(
        "try", substringHighlightColor, substringSearchOptions, null);

    const wholeWordSearchOptions = new aspose.slides.TextSearchOptions();
    wholeWordSearchOptions.setWholeWordsOnly(true);
    wholeWordSearchOptions.setCaseSensitive(false);
    const wholeWordHighlightColor = java.getStaticFieldValue("java.awt.Color", "MAGENTA");

    // فقط کلمه کامل "to" را هایلایت کنید.
    shape.getTextFrame().highlightText(
        "to", wholeWordHighlightColor, wholeWordSearchOptions, null);

    presentation.save("highlighted_text.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![The highlighted text](highlighted_text.png)

## **هایلایت متن با استفاده از عبارات منظم**

متد [TextFrame.highlightRegex](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) متن‌های مطابقت یافته توسط یک عبارت منظم را در یک قاب متن هایلایت می‌کند.

کد زیر تمام کلماتی که شامل هفت یا بیش تر کاراکتر هستند را هایلایت می‌کند:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const Pattern = java.import("java.util.regex.Pattern");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().get_Item(0);
    const regex = Pattern.compile("\\b[^\\s]{7,}\\b");
    const highlightColor = java.getStaticFieldValue("java.awt.Color", "YELLOW");

    shape.getTextFrame().highlightRegex(regex, highlightColor, null);

    presentation.save(
        "highlighted_text_using_regex.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![The highlighted text using the regular expression](highlighted_text_using_regex.png)

## **هایلایت متن در سراسر یک ارائه**

از متدهای [Presentation.highlightText](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) و [Presentation.highlightRegex](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) برای جستجو در تمام قاب‌های متن قابل اعمال در یک ارائه استفاده کنید. مثال زیر یک عبارت عینی و تمام آدرس‌های ایمیل را هایلایت می‌کند:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const Pattern = java.import("java.util.regex.Pattern");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const searchOptions = new aspose.slides.TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);
    searchOptions.setCaseSensitive(false);
    const termHighlightColor = java.getStaticFieldValue("java.awt.Color", "ORANGE");

    presentation.highlightText(
        "confidential", termHighlightColor, searchOptions, null);

    const emailRegex = Pattern.compile(
        "\\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\\.[A-Z]{2,}\\b",
        Pattern.CASE_INSENSITIVE);
    const emailHighlightColor = java.getStaticFieldValue("java.awt.Color", "YELLOW");

    presentation.highlightRegex(emailRegex, emailHighlightColor, null);
    presentation.save("highlighted_presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **جایگزینی متن در یک قاب متن**

از [TextFrame.replaceText](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) برای متن عینی و از [TextFrame.replaceRegex](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) برای جایگزینی مبتنی بر الگو استفاده کنید. این متدها متن مطابقت یافته را درون قاب متن موجود به‌روز می‌کنند و قالب‌بندی بخش‌های اطراف را حفظ می‌سازند، به‌جای بازسازی کامل قاب متن از یک رشته ساده.

مثال زیر یک نوع نوشتار متفاوت را استانداردسازی می‌کند و سپس برچسب‌های نسخه را جایگزین می‌نماید:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const Pattern = java.import("java.util.regex.Pattern");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().get_Item(0);
    const searchOptions = new aspose.slides.TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);
    searchOptions.setCaseSensitive(false);

    shape.getTextFrame().replaceText(
        "colour", "color", searchOptions, null);

    const versionRegex = Pattern.compile(
        "\\bv\\d+(?:\\.\\d+)*\\b", Pattern.CASE_INSENSITIVE);
    shape.getTextFrame().replaceRegex(versionRegex, "current version", null);

    presentation.save("updated_text_frame.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

اگر یک تطابق شامل بخش‌هایی با قالب‌بندی متفاوت باشد، خروجی را بررسی کنید تا مطمئن شوید کدام قالب باید بر متن جایگزین اعمال شود.

## **جایگزینی متن در سراسر یک ارائه**

از [Presentation.replaceText](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) و [Presentation.replaceRegex](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) برای اعمال همان عملیات در تمام ارائه استفاده کنید. این روش برای پاک‌سازی قالب، به‌روزرسانی اصطلاحات و حذف اطلاعات حساس مفید است.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const Pattern = java.import("java.util.regex.Pattern");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const searchOptions = new aspose.slides.TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);
    searchOptions.setCaseSensitive(true);

    presentation.replaceText(
        "Contoso", "Example Corp", searchOptions, null);

    const accountNumberRegex = Pattern.compile("\\bACCT-\\d{6}\\b");
    presentation.replaceRegex(accountNumberRegex, "ACCT-REDACTED", null);

    presentation.save("updated_presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **گروه‌بندی تطابق‌ها برای گزارش‌گیری**

از آنجا که هر نتیجه جمع‌آوری‌شده شماره اسلاید و قاب متن خود را ذخیره می‌کند، برنامه‌ها می‌توانند تطابق‌ها را برای حسابرسی، گزارش‌گیری یا جریان‌های کاری بازبینی گروه‌بندی کنند. مثال زیر نتایج را ابتدا بر اساس اسلاید و سپس بر اساس قاب متن گروه‌بندی می‌کند:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

function getSlideNumber(textFrame) {
    const parentSlide = textFrame.getSlide();

    if (java.instanceOf(parentSlide, "com.aspose.slides.Slide")) {
        return parentSlide.getSlideNumber();
    }

    if (java.instanceOf(parentSlide, "com.aspose.slides.NotesSlide")) {
        return parentSlide.getParentSlide().getSlideNumber();
    }

    return null;
}

const results = [];
const callback = java.newProxy("com.aspose.slides.IFindResultCallback", {
    foundResult: function(textFrame, sourceText, foundText, textPosition) {
        results.push({
            textFrame: textFrame,
            sourceText: sourceText,
            foundText: foundText,
            textPosition: textPosition,
            slideNumber: getSlideNumber(textFrame)
        });
    }
});

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const searchOptions = new aspose.slides.TextSearchOptions();
    searchOptions.setCaseSensitive(false);
    const highlightColor = java.getStaticFieldValue("java.awt.Color", "YELLOW");

    presentation.highlightText(
        "confidential", highlightColor, searchOptions, callback);

    const matchesBySlide = new Map();

    for (const result of results) {
        const slideLabel = result.slideNumber === null ? "Other" : result.slideNumber;

        if (!matchesBySlide.has(slideLabel)) {
            matchesBySlide.set(slideLabel, new Map());
        }

        const matchesByTextFrame = matchesBySlide.get(slideLabel);
        if (!matchesByTextFrame.has(result.textFrame)) {
            matchesByTextFrame.set(result.textFrame, []);
        }

        matchesByTextFrame.get(result.textFrame).push(result);
    }

    for (const [slideLabel, matchesByTextFrame] of matchesBySlide) {
        console.log("Slide: " + slideLabel);

        for (const [textFrame, textFrameMatches] of matchesByTextFrame) {
            console.log("  Text frame: " + textFrame.getText());

            for (const result of textFrameMatches) {
                console.log(
                    "    '" + result.foundText + "' at position " +
                    result.textPosition + "; context: '" + result.sourceText + "'");
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **سؤال‌ و جواب**

**چگونه می‌توانم فقط یک جعبه متن را به‌جای کل ارائه جستجو کنم؟**

قاب متن شکل را دریافت کنید و روی آن [TextFrame.highlightText](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-)، [TextFrame.highlightRegex](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-)، [TextFrame.replaceText](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) یا [TextFrame.replaceRegex](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) را فراخوانی کنید. متدهای سطح ارائه تمام قاب‌های متن قابل اعمال را پردازش می‌کنند.

**چگونه می‌توانم کلمات کامل را با حروف بزرگ/کوچک صحیح مطابقت دهم؟**

[TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) و [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) را به `true` تنظیم کنید و گزینه‌ها را به متدهای هایلایت یا جایگزینی متن عینی پاس دهید. برای عبارات منظم، مرزهای کلمه و حساسیت به حروف را در خود `Pattern` جاوا تعریف کنید.

**آیا جستجو و جایگزینی می‌تواند متن یادداشت‌های اسلاید را شامل شود؟**

بله. هنگام استفاده از یک عملیات متن عینی در سطح ارائه، [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) را به `true` تنظیم کنید. پیاده‌سازی کال‌بک نشان‌داده‌شده در بالا یک مطابقت در اسلاید یادداشت را به شماره اسلاید والد خود نگاشته می‌کند.

**چگونه می‌توانم گزارش‌گیری کنم بدون اینکه ارائه را بار دوم اسکن کنم؟**

یک پراکسی کال‌بک نتیجه جاوا را به عملیات هایلایت یا جایگزینی پاس دهید. کال‌بک در حین اجرا هر تطابق را دریافت می‌کند، بنابراین برنامه می‌تواند متن منبع، متن مطابقت یافته، موقعیت، قاب متن و شماره اسلاید استخراج‌شده را برای گروه‌بندی یا صادر کردن بعدی ذخیره کند.

**آیا جایگزینی متن قالب‌بندی آن را حفظ می‌کند؟**

[TextFrame.replaceText](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) و [TextFrame.replaceRegex](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) متن مطابقت یافته را درون قاب متن موجود اصلاح می‌کند و قالب‌بندی بخش‌های اطراف را نگه می‌دارد. اگر یک مطابقت شامل بخش‌های مختلف با قالب‌بندی متفاوت باشد، نتیجه را بررسی کنید تا اطمینان حاصل کنید که جایگزینی از سبک دلخواه استفاده می‌کند.