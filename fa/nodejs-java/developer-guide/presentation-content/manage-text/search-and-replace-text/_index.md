---
title: جستجو و جایگزینی متن در ارائه‌های PowerPoint با JavaScript
linktitle: جستجو و جایگزینی متن
type: docs
weight: 55
url: /fa/nodejs-java/search-and-replace-text/
keywords:
- جستجوی متن
- برجسته‌سازی متن
- جایگزینی متن
- عبارت منظم
- فراخوانی بازگشت نتیجه
- فریم متن
- گزارش حسابرسی
- PowerPoint
- OpenDocument
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "جستجو، برجسته‌سازی و جایگزینی متن در ارائه‌های PowerPoint را در حین جمع‌آوری تمام تطابق‌ها با Aspose.Slides برای Node.js از طریق Java انجام می‌دهد."
---
## **نمای کلی**

Aspose.Slides for Node.js via Java می‌تواند متن را در یک فریم متنی مجزا یا در کل ارائه جستجو، برجسته و جایگزین کند. هر عملیات می‌تواند با یک فراخوانی نتیجه، برنامه را از هر تطابق مطلع سازد. این امکان به‌روز‑رسانی ارائه و همزمان ساخت یک ردپای حسابرسی شامل متن تطبیق‌شده، زمینه، موقعیت، فریم متنی و شمارهٔ اسلاید را فراهم می‌کند.

این قابلیت‌ها برای بازبینی، محرمانه‌سازی، بررسی واژگان، پاک‌سازی قالب و جریان‌های کاری گزارش‌گیری خودکار مفید هستند.

در مثال‌های اولیه، فایلی به نام «sample.pptx» استفاده می‌شود که شامل یک جعبهٔ متنی در اسلاید اول با متن زیر است:

![نمونه متن](sample_text.png)

## **انتخاب محدودهٔ جستجو**

از متدهای [TextFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframe/) برای محدود کردن یک عملیات به یک فریم متنی استفاده کنید. از متدهای [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) برای پردازش تمام متون قابل اعمال در ارائه استفاده کنید.

| عملیات | یک فریم متنی | کل ارائه |
|---|---|---|
| برجسته‌سازی متن به‌صورت لفظی | [TextFrame.highlightText](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [Presentation.highlightText](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| برجسته‌سازی تطابق‌های عبارت منظم | [TextFrame.highlightRegex](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) | [Presentation.highlightRegex](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) |
| جایگزینی متن به‌صورت لفظی | [TextFrame.replaceText](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [Presentation.replaceText](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| جایگزینی تطابق‌های عبارت منظم | [TextFrame.replaceRegex](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) | [Presentation.replaceRegex](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) |

## **پیکربندی تطبیق متن**

برای عملیات متن به‌صورت لفظی، از [TextSearchOptions](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textsearchoptions/) برای کنترل تطبیق استفاده کنید:

- [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) تطبیق‌ها را محدود به کلمات کامل می‌کند.
- [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) تعیین می‌کند که آیا حساسیت به حروف بزرگ/کوچک باید رعایت شود.
- [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) یادداشت‌های اسلاید را در جستجو، جایگزینی و برجسته‌سازی در سطح ارائه شامل می‌شود.

عملیات‌های عبارت منظم از یک `Pattern` جاوا استفاده می‌کنند، بنابراین قوانین تطبیق مانند حساسیت به حروف و مرزهای کلمه توسط عبارت و پرچم‌های آن تعریف می‌شوند.

## **شناسایی مالک فریم متنی**

جریان‌های کاری عمومی پردازش متن غالباً یک [TextFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframe/) را هنگام جستجو، جایگزینی، اعتبارسنجی یا استخراج دریافت می‌کنند. برای تعیین شیء ارائه‌ای که فریم متنی را مالک است، از [TextFrame.getParentShape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframe/#getParentShape--) و [TextFrame.getParentCell](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframe/#getParentCell--) استفاده کنید.

مقادیر انتظار می‌روند بر اساس مالک متفاوت باشند:

| مالک فریم متنی | `getParentShape` | `getParentCell` |
|---|---|---|
| یک AutoShape یا شکل دیگری حاوی متن | شیء مالک [Shape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/shape/) | `null` |
| یک سلول جدول | `null` | شیء مالک [Cell](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/cell/) |

هر دو متد جهت‌گیری فقط‑خواندنی فراهم می‌کنند. فراخوانی آن‌ها فریم متن را جابجا یا مالک آن را تغییر نمی‌دهد. کد عمومی باید هر دو مقدار را برای `null` بررسی کرده و امکان عدم وجود هر دو مالک را مدیریت کند.

مثال زیر از [SlideUtil.getAllTextFrames](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/slideutil/#getAllTextFrames-aspose.slides.IPresentation-boolean-) برای پیمایش فریم‌های متنی در یک ارائه استفاده می‌کند. برای اشکال، نام شکل، نوع زمان اجرای جاوا و اسلاید حاوی آن گزارش می‌شود. برای سلول‌های جدول، مختصات ستون و ردیف صفر‑مبنا و اسلاید حاوی آن گزارش می‌شود.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

function getSlideLabel(baseSlide) {
    if (java.instanceOf(baseSlide, "com.aspose.slides.Slide")) {
        return "slide " + baseSlide.getSlideNumber();
    }

    if (java.instanceOf(baseSlide, "com.aspose.slides.NotesSlide")) {
        return "notes for slide " + baseSlide.getParentSlide().getSlideNumber();
    }

    return baseSlide.getClass().getSimpleName();
}

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const textFrames = aspose.slides.SlideUtil.getAllTextFrames(presentation, false);

    for (let index = 0; index < textFrames.length; index++) {
        const textFrame = textFrames[index];
        const ownerShape = textFrame.getParentShape();
        if (ownerShape !== null) {
            const shapeName = ownerShape.getName() === "" ? "(unnamed)" : ownerShape.getName();
            const shapeType = ownerShape.getClass().getSimpleName();
            const slideLabel = getSlideLabel(ownerShape.getSlide());
            console.log("Shape: " + shapeName + "; type: " + shapeType + "; " + slideLabel);
            continue;
        }

        const ownerCell = textFrame.getParentCell();
        if (ownerCell !== null) {
            const slideLabel = getSlideLabel(ownerCell.getSlide());
            console.log("Table cell: column " + ownerCell.getFirstColumnIndex() + ", row " + ownerCell.getFirstRowIndex() + "; " + slideLabel);
            continue;
        }

        console.log("The text frame owner is not available as a shape or table cell.");
    }
} finally {
    presentation.dispose();
}
```

برای محتوای SmartArt، از طریق اشکال موجود در [SmartArtNode.getShapes](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/smartartnode/#getShapes--) پیمایش کنید و به هر [SmartArtShape.getTextFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/smartartshape/#getTextFrame--) دسترسی پیدا کنید. فریم متنی می‌تواند از طریق [TextFrame.getParentShape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframe/#getParentShape--) به شکل مرتبط خود ردیابی شود، در حالی که [TextFrame.getParentCell](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframe/#getParentCell--) `null` برمی‌گرداند. بنابراین شاخهٔ شکل در مثال نیز متن SmartArt را مدیریت می‌کند.

## **جمع‌آوری اطلاعات تطبیق با فراخوانی بازگشت**

یک پراکسی جاوا برای فراخوانی نتیجه ایجاد کنید تا برای هر تطابق یک اعلان دریافت شود. این تابع پراکسی فریم متنی مرتبط، متن منبع، متن تطبیق‌شده و موقعیت تطبیق را دریافت می‌کند.

فراخوانی بازگشت به‌طور مستقیم شمارهٔ اسلاید را دریافت نمی‌کند. پیاده‌سازی زیر آن را از طریق شکل یا سلول جدول مالک فریم متن به‌دست می‌آورد، با [TextFrame.getSlide](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframe/#getSlide--) به عنوان گزینهٔ پیش‌فرض. همچنین متن یافته در یادداشت‌های اسلاید را مدیریت می‌کند.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

function getSlideNumber(textFrame) {
    const parentShape = textFrame.getParentShape();
    const parentCell = textFrame.getParentCell();
    let parentSlide = textFrame.getSlide();
    if (parentShape !== null) {
        parentSlide = parentShape.getSlide();
    } else if (parentCell !== null) {
        parentSlide = parentCell.getSlide();
    }

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

برای عملیات جایگزینی، `foundText` شامل متن اصلی تطبیق‌شده است، بنابراین فراخوانی می‌تواند دقیقاً ثبت کند که کدام عبارات جایگزین شده‌اند.

## **برجسته‌سازی متن**

از متد [TextFrame.highlightText](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) برای برجسته‌سازی تطابق‌های متن به‌صورت لفظی در یک فریم متنی استفاده کنید. برای کنترل جستجو، یک [TextSearchOptions](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textsearchoptions/) را پاس دهید.

کد زیر تمام رخده‌های کاراکترهای **"try"** را برجسته می‌کند و سپس تنها کلمهٔ کامل **"to"** را برجسته می‌سازد.

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

    // تمام موارد ظهور "try" را در فریم متن برجسته کنید.
    shape.getTextFrame().highlightText(
        "try", substringHighlightColor, substringSearchOptions, null);

    const wholeWordSearchOptions = new aspose.slides.TextSearchOptions();
    wholeWordSearchOptions.setWholeWordsOnly(true);
    wholeWordSearchOptions.setCaseSensitive(false);
    const wholeWordHighlightColor = java.getStaticFieldValue("java.awt.Color", "MAGENTA");

    // فقط کلمه کامل "to" را برجسته کنید.
    shape.getTextFrame().highlightText(
        "to", wholeWordHighlightColor, wholeWordSearchOptions, null);

    presentation.save("highlighted_text.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![متن برجسته‌شده](highlighted_text.png)

## **برجسته‌سازی متن با استفاده از عبارات منظم**

متد [TextFrame.highlightRegex](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) متن‌های یافت‌شده توسط یک عبارت منظم را در یک فریم متنی برجسته می‌کند.

کد زیر تمام کلمات دارای هفت یا بیشتر کاراکتر را برجسته می‌کند:

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

![متن برجسته‌شده با استفاده از عبارت منظم](highlighted_text_using_regex.png)

## **برجسته‌سازی متن در سرتاسر ارائه**

از [Presentation.highlightText](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) و [Presentation.highlightRegex](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) برای جستجو در تمام فریم‌های متنی قابل اعمال در یک ارائه استفاده کنید. مثال زیر یک عبارت لفظی و تمام آدرس‌های ایمیل را برجسته می‌کند:

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

## **جایگزینی متن در یک فریم متنی**

برای متن به‌صورت لفظی از [TextFrame.replaceText](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) و برای جایگزینی مبتنی بر الگو از [TextFrame.replaceRegex](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) استفاده کنید. این متدها متن تطبیق‌شده را درون فریم متنی موجود بروز می‌کنند و قالب‌بندی بخش‌های اطراف را حفظ می‌نمایند، به‌جای ساخت مجدد فریم متن از یک رشتهٔ ساده.

مثال زیر یک نوع نوشتاری متفاوت را یکپارچه می‌کند و سپس برچسب‌های نسخه را جایگزین می‌سازد:

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

اگر یک تطابق شامل بخش‌هایی با قالب‌بندی متفاوت باشد، خروجی را بررسی کنید تا اطمینان حاصل کنید که قالب‌بندی مناسب برای متن جایگزین اعمال شده است.

## **جایگزینی متن در سرتاسر ارائه**

از [Presentation.replaceText](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) و [Presentation.replaceRegex](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) برای اعمال همان عملیات‌ها در تمام ارائه استفاده کنید. این روش برای پاک‌سازی قالب، به‌روزرسانی واژگان و محرمانه‌سازی مفید است.

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

## **گروه‌بندی تطبیق‌ها برای گزارش‌گیری**

از آنجا که هر نتیجهٔ جمع‌آوری‌شده شمارهٔ اسلاید و فریم متنی خود را ذخیره می‌کند، برنامه‌ها می‌توانند تطبیق‌ها را برای حسابرسی، گزارش‌گیری یا جریان‌های بازبینی گروه‌بندی کنند. مثال زیر نتایج را ابتدا بر حسب اسلاید و سپس بر حسب فریم متنی گروه‌بندی می‌کند:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

function getSlideNumber(textFrame) {
    const parentShape = textFrame.getParentShape();
    const parentCell = textFrame.getParentCell();
    let parentSlide = textFrame.getSlide();
    if (parentShape !== null) {
        parentSlide = parentShape.getSlide();
    } else if (parentCell !== null) {
        parentSlide = parentCell.getSlide();
    }

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

## **سوالات متداول**

**چگونه می‌توان فقط یک جعبهٔ متنی را به‌جای کل ارائه جستجو کرد؟**

فریم متنی شکل را دریافت کرده و روی آن [TextFrame.highlightText](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-)، [TextFrame.highlightRegex](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-)، [TextFrame.replaceText](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) یا [TextFrame.replaceRegex](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) را بر روی آن فریم متنی فراخوانی کنید. متدهای سطح ارائه تمام فریم‌های متنی قابل اعمال را پردازش می‌کنند.

**چگونه می‌توان فقط کلمات کامل را با حروف بزرگ/کوچک صحیح مطابقت داد؟**

[TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) و [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) را روی `true` تنظیم کنید و گزینه‌ها را به یک متد برجسته‌سازی یا جایگزینی متن به‌صورت لفظی پاس دهید. برای عبارات منظم، مرزهای کلمه و حساسیت به حروف را در خود `Pattern` جاوا تعریف کنید.

**آیا جستجو و جایگزینی می‌تواند متن موجود در یادداشت‌های اسلاید را شامل شود؟**

بله. هنگام استفاده از یک عملیات متن به‌صورت لفظی در سطح ارائه، [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) را روی `true` تنظیم کنید. پیاده‌سازی فراخوانی بازگشت در بالا یک تطابق در اسلاید یادداشت را به شماره اسلاید والد خود باز می‌گرداند.

**چگونه می‌توان بدون اسکن دوبارهٔ ارائه گزارش ایجاد کرد؟**

یک پراکسی جاوا برای فراخوانی نتیجه به عملیات برجسته‌سازی یا جایگزینی پاس دهید. این فراخوانی در طول اجرای عملیات هر تطابق را دریافت می‌کند، بنابراین برنامه می‌تواند متن منبع، متن تطبیق‌شده، موقعیت، فریم متنی و شماره اسلاید استخراج‌شده را برای گروه‌بندی یا خروجی بعدی ذخیره کند.

**آیا جایگزینی متن قالب‌بندی آن را حفظ می‌کند؟**

[TextFrame.replaceText](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) و [TextFrame.replaceRegex](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) متن تطبیق‌شده را درون فریم متنی موجود تغییر می‌دهند و قالب‌بندی بخش‌های اطراف را حفظ می‌کنند. اگر یک تطابق شامل بخش‌هایی با قالب‌بندی متفاوت باشد، نتیجه را بررسی کنید تا اطمینان حاصل شود که جایگزینی از سبک موردنظر استفاده می‌کند.