---
title: جستجو و جایگزینی متن در ارائه‌های PowerPoint با Java
linktitle: جستجو و جایگزینی متن
type: docs
weight: 55
url: /fa/java/search-and-replace-text/
keywords:
- جستجوی متن
- برجسته‌سازی متن
- جایگزینی متن
- عبارت منظم
- callback نتیجه
- فریم متن
- گزارش حسابرسی
- PowerPoint
- OpenDocument
- ارائه
- Java
- Aspose.Slides
description: "جستجو، برجسته‌سازی و جایگزینی متن در ارائه‌های PowerPoint در حالی که هر تطابق با Aspose.Slides برای Java جمع‌آوری می‌شود."
---
## **مرور کلی**

Aspose.Slides برای Java می‌تواند متن را در یک فریم متن منفرد یا در کل ارائه جستجو، برجسته (ها) و جایگزین کند. هر عملیات می‌تواند با استفاده از یک callback نتیجه، برنامه را از هر تطابق مطلع سازد. این امکان را فراهم می‌کند تا یک ارائه را به‌روزرسانی کنید و همزمان یک ردپای audit شامل متن مطابقت یافته، زمینهٔ آن، موقعیت، فریم متن و شمارهٔ اسلاید ایجاد کنید.

این قابلیت‌ها برای بازنگری، محرمانه‌سازی، بررسی اصطلاحات، پاک‌سازی قالب و جریان‌های کاری گزارش‌گیری خودکار مفید هستند.

در مثال‌های اولیهٔ زیر، از فایلی به نام «sample.pptx» استفاده می‌کنیم که یک جعبهٔ متن تنها در اسلاید اول دارد و متن زیر را شامل می‌شود:

![متن نمونه](sample_text.png)

## **انتخاب محدودهٔ جستجو**

از متدهای [ITextFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itextframe/) برای محدود کردن یک عملیات به یک فریم متن استفاده کنید. از متدهای [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) برای پردازش تمام متن‌های قابل اعمال در ارائه استفاده کنید.

| عملیات | یک فریم متن | کل ارائه |
|---|---|---|
| برجسته متن به‌صورت دقیق | [ITextFrame.highlightText](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [Presentation.highlightText](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| برجسته مطابقات عبارات منظم | [ITextFrame.highlightRegex](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) | [Presentation.highlightRegex](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) |
| جایگزینی متن به‌صورت دقیق | [ITextFrame.replaceText](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [Presentation.replaceText](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| جایگزینی مطابقات عبارات منظم | [ITextFrame.replaceRegex](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) | [Presentation.replaceRegex](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) |

## **پیکربندی مطابقت متن**

برای عملیات‌های متن به‌صورت دقیق، از [TextSearchOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/textsearchoptions/) برای کنترل مطابقت استفاده کنید:

- [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/fa/java/com.aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) مطابقت‌ها را به کلمات کامل محدود می‌کند.
- [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/fa/java/com.aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) تعیین می‌کند که حروف باید با توجه به بزرگ/کوچک بودن مطابقت داشته باشند.
- [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/fa/java/com.aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) یادداشت‌های اسلاید را در عملیات‌های جستجو، جایگزینی و برجسته‌سازی در سطح ارائه شامل می‌کند.

عملیات‌های عبارات منظم از یک `Pattern` جاوا استفاده می‌کنند، بنابراین قوانین مطابقت مثل حساسیت به حروف و مرزهای کلمه توسط خود عبارت و پرچم‌های آن تعریف می‌شوند.

## **جمع‌آوری اطلاعات تطبیق با استفاده از Callback**

یک پیاده‌سازی از [IFindResultCallback](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ifindresultcallback/) ایجاد کنید تا برای هر تطابق یک اعلان دریافت کنید. متد [IFindResultCallback.foundResult](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ifindresultcallback/#foundResult-com.aspose.slides.ITextFrame-java.lang.String-java.lang.String-int-) فریم متن مربوطه، متن منبع، متن مطابقت یافته و موقعیت مطابقت را فراهم می‌کند.

این callback مستقیم شمارهٔ اسلاید را دریافت نمی‌کند. پیاده‌سازی زیر آن را از اسلاید والد استخراج می‌کند و همچنین متن پیدا شده در یادداشت اسلاید را مدیریت می‌کند. یک `Integer` قابل‌null اجازه می‌دهد همان مدل نتیجه برای متنی که به انواع دیگر اسلایدها مربوط است استفاده شود.

```java
import com.aspose.slides.*;
import java.util.ArrayList;
import java.util.List;

final class TextMatch {
    private final ITextFrame textFrame;
    private final String sourceText;
    private final String foundText;
    private final int textPosition;
    private final Integer slideNumber;

    TextMatch(ITextFrame textFrame, String sourceText, String foundText, int textPosition, Integer slideNumber) {
        this.textFrame = textFrame;
        this.sourceText = sourceText;
        this.foundText = foundText;
        this.textPosition = textPosition;
        this.slideNumber = slideNumber;
    }

    ITextFrame getTextFrame() {
        return textFrame;
    }

    String getSourceText() {
        return sourceText;
    }

    String getFoundText() {
        return foundText;
    }

    int getTextPosition() {
        return textPosition;
    }

    Integer getSlideNumber() {
        return slideNumber;
    }
}

final class TextSearchCallback implements IFindResultCallback {
    private final List<TextMatch> results = new ArrayList<TextMatch>();

    List<TextMatch> getResults() {
        return results;
    }

    @Override
    public void foundResult(ITextFrame textFrame, String sourceText, String foundText, int textPosition) {
        Integer slideNumber = getSlideNumber(textFrame);
        TextMatch result = new TextMatch(textFrame, sourceText, foundText, textPosition, slideNumber);
        results.add(result);
    }

    private static Integer getSlideNumber(ITextFrame textFrame) {
        if (!(textFrame instanceof TextFrame)) {
            return null;
        }

        IBaseSlide parentSlide = ((TextFrame) textFrame).getSlide();

        if (parentSlide instanceof ISlide) {
            return ((ISlide) parentSlide).getSlideNumber();
        }

        if (parentSlide instanceof INotesSlide) {
            return ((INotesSlide) parentSlide).getParentSlide().getSlideNumber();
        }

        return null;
    }
}
```

برای عملیات‌های جایگزینی، `foundText` متن اصلی مطابقت یافته را شامل می‌شود، بنابراین callback می‌تواند دقیقاً ثبت کند که کدام عبارات جایگزین شده‌اند.

## **هایلایت متن**

از متد [ITextFrame.highlightText](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) برای برجسته‌سازی مطابقت‌های متن دقیق در یک فریم متن استفاده کنید. برای کنترل جستجو [TextSearchOptions] را ارسال کنید و یک callback برای جمع‌آوری جزئیات مطابقت فراهم کنید.

کد نمونه زیر تمام رخدادهای کاراکترهای **"try"** را برجسته می‌کند و سپس فقط کلمهٔ کامل **"to"** را برجسته می‌کند. هر دو جستجو تطابق‌های خود را به یک callback گزارش می‌دهند.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);
    TextSearchCallback callback = new TextSearchCallback();

    TextSearchOptions substringSearchOptions = new TextSearchOptions();
    substringSearchOptions.setCaseSensitive(false);
    Color substringHighlightColor = new Color(173, 216, 230);

    // تمام رخدادهای "try" را در فریم متن برجسته کنید.
    shape.getTextFrame().highlightText("try", substringHighlightColor, substringSearchOptions, callback);

    TextSearchOptions wholeWordSearchOptions = new TextSearchOptions();
    wholeWordSearchOptions.setWholeWordsOnly(true);
    wholeWordSearchOptions.setCaseSensitive(false);
    Color wholeWordHighlightColor = new Color(238, 130, 238);

    // فقط کلمه کامل "to" را برجسته کنید.
    shape.getTextFrame().highlightText("to", wholeWordHighlightColor, wholeWordSearchOptions, callback);

    for (TextMatch result : callback.getResults()) {
        System.out.println("Found '" + result.getFoundText() + "' at position " +
                result.getTextPosition() + " on slide " + result.getSlideNumber() + ".");
    }

    presentation.save("highlighted_text.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![متن هایلایت شده](highlighted_text.png)

## **هایلایت متن با استفاده از عبارات منظم**

متد [ITextFrame.highlightRegex](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) متن مطابقت یافته توسط یک عبارت منظم را در یک فریم متن برجسته می‌کند.

کد زیر تمام واژه‌هایی که شامل هفت یا بیش‌تر کاراکتر هستند برجسته می‌کند و هر تطابق را جمع‌آوری می‌کند:

```java
import com.aspose.slides.*;
import java.awt.Color;
import java.util.regex.Pattern;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);
    TextSearchCallback callback = new TextSearchCallback();
    Pattern regex = Pattern.compile("\\b[^\\s]{7,}\\b");

    shape.getTextFrame().highlightRegex(regex, Color.YELLOW, callback);

    presentation.save("highlighted_text_using_regex.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![متن هایلایت شده با استفاده از عبارت منظم](highlighted_text_using_regex.png)

## **هایلایت متن در سراسر یک ارائه**

از [Presentation.highlightText](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) و [Presentation.highlightRegex](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) برای جستجو در تمام فریم‌های متنی قابل اعمال در یک ارائه استفاده کنید. مثال زیر یک اصطلاح دقیق و تمام آدرس‌های ایمیل را برجسته می‌کند و برای دو جستجو مجموعه نتایج جداگانه‌ای نگه می‌دارد.

```java
import com.aspose.slides.*;
import java.awt.Color;
import java.util.regex.Pattern;

Presentation presentation = new Presentation("presentation.pptx");
try {
    TextSearchCallback termCallback = new TextSearchCallback();
    TextSearchOptions searchOptions = new TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);
    searchOptions.setCaseSensitive(false);

    presentation.highlightText("confidential", Color.ORANGE, searchOptions, termCallback);

    TextSearchCallback emailCallback = new TextSearchCallback();
    Pattern emailRegex = Pattern.compile(
            "\\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\\.[A-Z]{2,}\\b",
            Pattern.CASE_INSENSITIVE);

    presentation.highlightRegex(emailRegex, Color.YELLOW, emailCallback);
    presentation.save("highlighted_presentation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **جایگزینی متن در یک فریم متن**

از [ITextFrame.replaceText](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) برای متن دقیق و [ITextFrame.replaceRegex](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) برای جایگزینی بر پایه الگو استفاده کنید. این متدها متن مطابقت یافته را در همان فریم متن موجود به‌روزرسانی می‌کنند و قالب‌بندی قسمت‌های اطراف را حفظ می‌نمایند، به‌جای بازسازی فریم متن از یک رشته ساده.

مثال زیر یک گونهٔ املایی را استانداردسازی می‌کند و سپس برچسب‌های نسخه را جایگزین می‌سازد. همان callback عبارات اصلی مطابقت یافته در هر دو عملیات را ثبت می‌کند.

```java
import com.aspose.slides.*;
import java.util.regex.Pattern;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);
    TextSearchCallback callback = new TextSearchCallback();
    TextSearchOptions searchOptions = new TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);
    searchOptions.setCaseSensitive(false);

    shape.getTextFrame().replaceText("colour", "color", searchOptions, callback);

    Pattern versionRegex = Pattern.compile("\\bv\\d+(?:\\.\\d+)*\\b", Pattern.CASE_INSENSITIVE);
    shape.getTextFrame().replaceRegex(versionRegex, "current version", callback);

    presentation.save("updated_text_frame.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

اگر یک تطابق بخش‌هایی با قالب‌بندی متفاوت را در بر بگیرد، خروجی را بررسی کنید تا تأیید کنید کدام قالب‌بندی باید برای متن جایگزین اعمال شود.

## **جایگزینی متن در سراسر یک ارائه**

از [Presentation.replaceText](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) و [Presentation.replaceRegex](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) برای اعمال همان عملیات‌ها در سرتاسر ارائه استفاده کنید. این مورد برای پاک‌سازی قالب، به‌روزرسانی اصطلاحات و محرمانه‌سازی مفید است.

```java
import com.aspose.slides.*;
import java.util.regex.Pattern;

Presentation presentation = new Presentation("presentation.pptx");
try {
    TextSearchCallback callback = new TextSearchCallback();
    TextSearchOptions searchOptions = new TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);
    searchOptions.setCaseSensitive(true);

    presentation.replaceText("Contoso", "Example Corp", searchOptions, callback);

    Pattern accountNumberRegex = Pattern.compile("\\bACCT-\\d{6}\\b");
    presentation.replaceRegex(accountNumberRegex, "ACCT-REDACTED", callback);

    presentation.save("updated_presentation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **گروه‌بندی تطبیق‌ها برای گزارش‌دهی**

از آنجا که هر نتیجه شمارهٔ اسلاید و فریم متن خود را ذخیره می‌کند، برنامه‌ها می‌توانند تطبیق‌ها را برای حسابرسی، گزارش‌دهی یا گردش کاری بازنگری گروه‌بندی کنند. مثال زیر نتایج جمع‌آوری شده را ابتدا بر اساس اسلاید و سپس بر اساس فریم متن گروه‌بندی می‌کند:

```java
import com.aspose.slides.ITextFrame;
import java.util.LinkedHashMap;
import java.util.List;
import java.util.Map;

Map<Integer, Map<ITextFrame, List<TextMatch>>> matchesBySlide =
        new LinkedHashMap<Integer, Map<ITextFrame, List<TextMatch>>>();

for (TextMatch result : callback.getResults()) {
    Integer slideNumber = result.getSlideNumber();
    Map<ITextFrame, List<TextMatch>> matchesByTextFrame = matchesBySlide.get(slideNumber);

    if (matchesByTextFrame == null) {
        matchesByTextFrame = new LinkedHashMap<ITextFrame, List<TextMatch>>();
        matchesBySlide.put(slideNumber, matchesByTextFrame);
    }

    ITextFrame textFrame = result.getTextFrame();
    List<TextMatch> textFrameMatches = matchesByTextFrame.get(textFrame);

    if (textFrameMatches == null) {
        textFrameMatches = new java.util.ArrayList<TextMatch>();
        matchesByTextFrame.put(textFrame, textFrameMatches);
    }

    textFrameMatches.add(result);
}

for (Map.Entry<Integer, Map<ITextFrame, List<TextMatch>>> slideEntry : matchesBySlide.entrySet()) {
    String slideLabel = slideEntry.getKey() == null ? "Other" : slideEntry.getKey().toString();
    System.out.println("Slide: " + slideLabel);

    for (Map.Entry<ITextFrame, List<TextMatch>> textFrameEntry : slideEntry.getValue().entrySet()) {
        System.out.println("  Text frame: " + textFrameEntry.getKey().getText());

        for (TextMatch result : textFrameEntry.getValue()) {
            System.out.println("    '" + result.getFoundText() + "' at position " +
                    result.getTextPosition() + "; context: '" + result.getSourceText() + "'");
        }
    }
}
```

## **سوالات متداول**

**چگونه می‌توانم فقط یک جعبه متن را به جای کل ارائه جستجو کنم؟**

فریم متن شکل را دریافت کنید و بر روی آن [ITextFrame.highlightText](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-)، [ITextFrame.highlightRegex](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-)، [ITextFrame.replaceText](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-)، یا [ITextFrame.replaceRegex](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) را بر آن فریم متن صدا بزنید. متدهای سطح ارائه تمام فریم‌های متنی قابل اعمال را پردازش می‌کنند.

**چگونه می‌توانم کلمات کامل را با حروف بزرگ‌ و کوچک صحیح مطابقت دهم؟**

[TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/fa/java/com.aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) و [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/fa/java/com.aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) را روی `true` تنظیم کنید و گزینه‌ها را به متد برجسته‌سازی یا جایگزینی متن دقیق پاس دهید. برای عبارات منظم، مرزهای کلمه و حساسیت به حروف را در خود `Pattern` جاوا تعریف کنید.

**آیا جستجو و جایگزینی می‌توانند متن در یادداشت‌های اسلاید را نیز شامل شوند؟**

بله. هنگام استفاده از یک عملیات متن دقیق در سطح ارائه، [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/fa/java/com.aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) را روی `true` تنظیم کنید. پیاده‌سازی callback نشان داده شده، تطابقی در اسلاید یادداشت را به شمارهٔ اسلاید والد خود باز می‌گرداند.

**چگونه می‌توانم یک گزارش ایجاد کنم بدون اینکه ارائه را برای بار دوم اسکن کنم؟**

یک پیاده‌سازی از [IFindResultCallback](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ifindresultcallback/) را به عملیات برجسته‌سازی یا جایگزینی پاس دهید. این callback در حین اجرای عملیات هر تطابق را دریافت می‌کند، بنابراین برنامه می‌تواند متن منبع، متن مطابقت یافته، موقعیت، فریم متن و شمارهٔ اسلاید استخراج‌شده را برای گروه‌بندی یا خروجی بعدی ذخیره کند.

**آیا جایگزینی متن قالب‌بندی آن را حفظ می‌کند؟**

[ITextFrame.replaceText](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) و [ITextFrame.replaceRegex](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) متن مطابقت یافته را در فریم متن موجود به‌روزرسانی می‌کنند و قالب‌بندی قسمت‌های اطراف را نگه می‌دارند. اگر یک تطابق بخش‌هایی با قالب‌بندی متفاوت را شامل شود، نتیجه را بررسی کنید تا اطمینان حاصل کنید که قالب‌بندی مورد نظر برای متن جایگزین اعمال شده است.