---
title: جستجو و جایگزینی متن در ارائه‌های PowerPoint در Android
linktitle: جستجو و جایگزینی متن
type: docs
weight: 55
url: /fa/androidjava/search-and-replace-text/
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
- Android
- Java
- Aspose.Slides
description: "جستجو، برجسته‌سازی و جایگزینی متن در ارائه‌های PowerPoint در حالی که هر تطبیق با Aspose.Slides for Android via Java جمع‌آوری می‌شود."
---
## **بررسی کلی**

Aspose.Slides for Android via Java می‌تواند متن را در یک فریم متن جداگانه یا در سرتاسر ارائه جستجو، برجسته و جایگزین کند. هر عملیات می‌تواند با یک فراخوانی نتیجه، برنامه را از هر تطبیق مطلع سازد. این امکان به‌روزرسانی ارائه و همزمان ساخت یک ردپای حسابرسی شامل متن تطبیق یافته، متن زمینه، موقعیت، فریم متن و شماره اسلاید را فراهم می‌کند.

این قابلیت‌ها برای بازنگری، محرمانه‌سازی، بررسی واژگان، پاک‌سازی قالب و گردش کارهای گزارش‌دهی خودکار مفید هستند.

در مثال‌های اولیه زیر، از فایلی به نام «sample.pptx» استفاده می‌کنیم که شامل یک جعبه متن در اولین اسلاید با متن زیر است:

![متن نمونه](sample_text.png)

## **انتخاب دامنه جستجو**

از متدهای [ITextFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itextframe/) برای محدود کردن یک عملیات به یک فریم متن استفاده کنید. برای پردازش تمام متن‌های قابل‌جستجو در ارائه، از متدهای [IPresentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipresentation/) بهره ببرید.

| عملیات | یک فریم متن | کل ارائه |
|---|---|---|
| برجسته‌سازی متن به صورت واژه‌ای | [ITextFrame.highlightText](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [IPresentation.highlightText](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipresentation/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| برجسته‌سازی تطبیق‌های عبارت منظم | [ITextFrame.highlightRegex](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-) | [IPresentation.highlightRegex](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipresentation/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-) |
| جایگزینی متن به صورت واژه‌ای | [ITextFrame.replaceText](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [IPresentation.replaceText](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipresentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| جایگزینی تطبیق‌های عبارت منظم | [ITextFrame.replaceRegex](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) | [IPresentation.replaceRegex](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipresentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) |

## **پیکربندی تطبیق متن**

برای عملیات‌های متن به صورت واژه‌ای، از [TextSearchOptions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/textsearchoptions/) برای کنترل تطبیق استفاده کنید:

- [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) تطبیق‌ها را به کلمات کامل محدود می‌کند.
- [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) تعیین می‌کند که آیا حساسیت به حروف بزرگ و کوچک باید رعایت شود یا نه.
- [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) یادداشت‌های اسلاید را در جستجو، جایگزینی و برجسته‌سازی سطح ارائه شامل می‌شود.

عملیات‌های عبارت منظم از یک `Pattern` جاوا استفاده می‌کنند، بنابراین قوانین تطبیق مانند حساسیت به حروف و مرزهای واژه در خود الگو و پرچم‌های آن تعریف می‌شود.

## **جمع‌آوری اطلاعات تطبیق با فراخوانی بازگشتی**

برای دریافت اعلان برای هر تطبیق، [IFindResultCallback](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ifindresultcallback/) را پیاده‌سازی کنید. متد [IFindResultCallback.foundResult](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ifindresultcallback/#foundResult-com.aspose.slides.ITextFrame-java.lang.String-java.lang.String-int-) فریم متن مرتبط، متن منبع، متن تطبیق یافته و موقعیت تطبیق را فراهم می‌کند.

این فراخوانی مستقیم شماره اسلاید را دریافت نمی‌کند. پیاده‌سازی زیر آن را از اسلاید والد استخراج می‌کند و همچنین متن یافت‌شده در یادداشت‌های اسلاید را مدیریت می‌نماید. یک `Integer` قابل‌null اجازه می‌دهد همان مدل نتیجه متن مرتبط با انواع دیگر اسلایدها را نیز نشان دهد.

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

برای عملیات‌های جایگزینی، `foundText` حاوی متن اصلی مطابقت یافته است، به‌طوری که فراخوانی می‌تواند دقیقاً ثبت کند کدام اصطلاحات جایگزین شده‌اند.

## **برجسته‌سازی متن**

از متد [ITextFrame.highlightText](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) برای برجسته‌سازی تطبیق‌های متن به صورت واژه‌ای در یک فریم متن استفاده کنید. با پاس کردن [TextSearchOptions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/textsearchoptions/) جستجو را کنترل کنید و یک فراخوانی برای جمع‌آوری جزئیات تطبیق‌ها بدهید.

کد زیر تمام رخدادهای کاراکترهای **"try"** را برجسته می‌کند و سپس تنها کلمه کامل **"to"** را برجسته می‌سازد. هر دو جستجو تطبیق‌های خود را به همان فراخوانی اطلاع می‌دهند.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);
    TextSearchCallback callback = new TextSearchCallback();

    TextSearchOptions substringSearchOptions = new TextSearchOptions();
    substringSearchOptions.setCaseSensitive(false);
    int substringHighlightColor = Color.rgb(173, 216, 230);

    // برجسته‌سازی هر رخداد "try" در فریم متن.
    shape.getTextFrame().highlightText("try", substringHighlightColor, substringSearchOptions, callback);

    TextSearchOptions wholeWordSearchOptions = new TextSearchOptions();
    wholeWordSearchOptions.setWholeWordsOnly(true);
    wholeWordSearchOptions.setCaseSensitive(false);
    int wholeWordHighlightColor = Color.rgb(238, 130, 238);

    // برجسته‌سازی فقط کلمهٔ کامل "to".
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

![متن برجسته‌شده](highlighted_text.png)

## **برجسته‌سازی متن با استفاده از عبارات منظم**

متد [ITextFrame.highlightRegex](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-) متن‌های یافت‌شده توسط یک عبارت منظم را در یک فریم متن برجسته می‌کند.

کد زیر تمام واژه‌هایی که دارای هفت یا بیش از هفت حرف هستند برجسته می‌کند و هر تطبیق را جمع‌آوری می‌نماید:

```java
import com.aspose.slides.*;
import android.graphics.Color;
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

![متن برجسته‌شده با استفاده از عبارت منظم](highlighted_text_using_regex.png)

## **برجسته‌سازی متن در سرتاسر یک ارائه**

از [IPresentation.highlightText](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipresentation/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) و [IPresentation.highlightRegex](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipresentation/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-) برای جستجو در تمام فریم‌های متن قابل اعمال در یک ارائه استفاده کنید. مثال زیر یک واژهٔ لغوی و تمام آدرس‌های ایمیل را برجسته می‌کند و نتایج دو جستجو را به‌صورت جداگانه جمع‌آوری می‌کند.

```java
import com.aspose.slides.*;
import android.graphics.Color;
import java.util.regex.Pattern;

Presentation presentation = new Presentation("presentation.pptx");
try {
    TextSearchCallback termCallback = new TextSearchCallback();
    TextSearchOptions searchOptions = new TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);
    searchOptions.setCaseSensitive(false);

    int termHighlightColor = Color.rgb(255, 165, 0);
    presentation.highlightText("confidential", termHighlightColor, searchOptions, termCallback);

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

برای متن به صورت واژه‌ای از [ITextFrame.replaceText](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) و برای جایگزینی مبتنی بر الگو از [ITextFrame.replaceRegex](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) استفاده کنید. این متدها متن مطابقت یافته را درون فریم متن موجود به‌روزرسانی می‌کنند و قالب‌بخشی بخش‌های اطراف را حفظ می‌نمایند، به‌جای بازسازی فریم متن از یک رشتهٔ ساده.

مثال زیر یک واریانت املا را استاندارد می‌کند و سپس برچسب‌های نسخه را جایگزین می‌سازد. همان فراخوانی واژه‌های اصلی مطابقت یافته در هر دو عملیات را ثبت می‌کند.

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

اگر یک تطبیق شامل بخش‌هایی با قالب‌بندی متفاوت باشد، خروجی را بررسی کنید تا اطمینان حاصل شود کدام قالب‌بندی باید بر متن جایگزین اعمال شود.

## **جایگزینی متن در سرتاسر یک ارائه**

از [IPresentation.replaceText](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipresentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) و [IPresentation.replaceRegex](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipresentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) برای اعمال همان عملیات‌ها در تمام ارائه استفاده کنید. این روش برای پاک‌سازی قالب، به‌روزرسانی واژگان و محرمانه‌سازی مفید است.

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

از آنجا که هر نتیجه شماره اسلاید و فریم متن خود را ذخیره می‌کند، برنامه‌ها می‌توانند تطبیق‌ها را برای حسابرسی، گزارش یا گردش کارهای بازنگری گروه‌بندی کنند. مثال زیر نتایج جمع‌آوری‌شده را ابتدا بر حسب اسلاید و سپس بر حسب فریم متن گروه‌بندی می‌کند:

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

## **سؤال‌های متداول**

**چگونه می‌توانم فقط یک جعبه متن را به جای کل ارائه جستجو کنم؟**

فریم متن شکل را دریافت کنید و بر روی آن [ITextFrame.highlightText](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-)، [ITextFrame.highlightRegex](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-)، [ITextFrame.replaceText](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) یا [ITextFrame.replaceRegex](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) را فراخوانی کنید. متدهای سطح ارائه تمام فریم‌های متن قابل‌جستجو را پردازش می‌کنند.

**چگونه می‌توانم کلمات کامل را با حروف بزرگ/کوچک صحیح مطابقت دهم؟**

[TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) و [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) را روی `true` تنظیم کنید و گزینه‌ها را به متد برجسته‌سازی یا جایگزینی متن به صورت واژه‌ای بدهید. برای عبارات منظم، مرزهای واژه و حساسیت به حروف را خود در `Pattern` تعریف کنید.

**آیا جستجو و جایگزینی می‌تواند متن موجود در یادداشت‌های اسلاید را شامل شود؟**

بله. هنگام استفاده از عملیات متن به صورت واژه‌ای در سطح ارائه، [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) را روی `true` تنظیم کنید. پیاده‌سازی فراخوانی نشان‌داده‌شده، تطبیق در اسلاید یادداشت‌ها را به شماره اسلاید والد خود بازمی‌گرداند.

**چگونه می‌توانم گزارشی ایجاد کنم بدون اینکه دوباره ارائه را اسکن کنم؟**

یک پیاده‌سازی از [IFindResultCallback](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ifindresultcallback/) را به عملیات برجسته‌سازی یا جایگزینی پاس کنید. این فراخوانی در هنگام اجرای عملیات هر تطبیق را دریافت می‌کند، بنابراین برنامه می‌تواند متن منبع، متن تطبیق یافته، موقعیت، فریم متن و شماره اسلاید استخراج‌شده را برای گروه‌بندی یا صادرات بعدی ذخیره کند.

**آیا جایگزینی متن قالب‌بندی آن را حفظ می‌کند؟**

[ITextFrame.replaceText](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) و [ITextFrame.replaceRegex](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) متن مطابقت یافته را درون فریم متن موجود اصلاح می‌کنند و قالب‌بندی بخش‌های اطراف را حفظ می‌کنند. اگر یک تطبیق بخش‌هایی با قالب‌بندی متفاوت را شامل شود، نتیجه را بررسی کنید تا مطمئن شوید جایگزینی از سبک موردنظر استفاده می‌کند.