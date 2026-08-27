---
title: جستجو و جایگزینی متن در ارائه‌های PowerPoint در Java
linktitle: جستجو و جایگزینی متن
type: docs
weight: 55
url: /fa/java/search-and-replace-text/
keywords:
  - جستجوی متن
  - برجسته‌سازی متن
  - جایگزینی متن
  - عبارت منظم
  - کال‌بک نتیجه
  - فریم متن
  - گزارش حسابرسی
  - PowerPoint
  - OpenDocument
  - ارائه
  - Java
  - Aspose.Slides
description: "جستجو، برجسته‌سازی و جایگزینی متن در ارائه‌های PowerPoint در حالی که هر تطابق را با Aspose.Slides for Java جمع‌آوری می‌کند."
---
## **بررسی اجمالی**

Aspose.Slides for Java می‌تواند متن را در یک فریم متن منفرد یا در تمام ارائه جستجو، برجسته و جایگزین کند. هر عملیات می‌تواند از طریق یک کال‌بک نتیجه، برنامه را از هر تطابق مطلع سازد. این امکان را فراهم می‌کند تا یک ارائه را به‌روزرسانی کرده و همزمان یک ردپای حسابرسی شامل متن مطابقت یافته، زمینهٔ آن، موقعیت، فریم متن و شماره اسلاید بسازید.

این قابلیت‌ها برای بازبینی، حذف اطلاعات حساس، بررسی اصطلاحات، پاک‌سازی قالب‌ها و گردش کارهای گزارش‌گیری خودکار مفید هستند.

در مثال‌های اولیه زیر، از فایلی به نام "sample.pptx" استفاده می‌کنیم که حاوی یک جعبه متن در اسلاید اول با متن زیر است:

![Sample text](sample_text.png)

## **انتخاب حوزهٔ جستجو**

از متدهای [ITextFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itextframe/) برای محدود کردن عملیات به یک فریم متن استفاده کنید. از متدهای [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) برای پردازش تمام متن‌های قابل استفاده در ارائه استفاده کنید.

| عملیات | یک فریم متن | کل ارائه |
|---|---|---|
| برجسته‌سازی متن ثابت | [ITextFrame.highlightText](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [Presentation.highlightText](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| برجسته‌سازی تطابق‌های عبارات منظم | [ITextFrame.highlightRegex](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) | [Presentation.highlightRegex](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) |
| جایگزینی متن ثابت | [ITextFrame.replaceText](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [Presentation.replaceText](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| جایگزینی تطابق‌های عبارات منظم | [ITextFrame.replaceRegex](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) | [Presentation.replaceRegex](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) |

## **پیکربندی مطابقت متن**

برای عملیات متن ثابت، از [TextSearchOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/textsearchoptions/) برای کنترل تطابق استفاده کنید:

- [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/fa/java/com.aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) تطبیق‌ها را به کلمات کامل محدود می‌کند.
- [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/fa/java/com.aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) کنترل می‌کند که آیا حروف باید با حالت حروف مطابقت داشته باشند.
- [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/fa/java/com.aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) شامل یادداشت‌های اسلاید در عملیات جستجو، جایگزینی و برجسته‌سازی در سطح ارائه می‌شود.

عملیات عبارات منظم از یک `Pattern` جاوا استفاده می‌کنند، بنابراین قواعد تطابق مانند حساسیت به حروف و مرزهای کلمه توسط عبارت و پرچم‌های آن تعریف می‌شود.

## **شناسایی مالک فریم متن**

گردش‌کارهای عمومی پردازش متن اغلب یک [ITextFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itextframe/) را هنگام جستجو، جایگزینی، اعتبارسنجی یا خروجی گرفتن متن دریافت می‌کنند. از [ITextFrame.getParentShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itextframe/#getParentShape--) و [ITextFrame.getParentCell](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itextframe/#getParentCell--) برای تعیین اینکه کدام شی ارائه صاحب فریم متن است استفاده کنید.

مقدارهای مورد انتظار بسته به مالک متفاوت است:

| مالک فریم متن | `getParentShape` | `getParentCell` |
|---|---|---|
| یک AutoShape یا شکل دیگری حاوی متن | The owning [IShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ishape/) | `null` |
| یک سلول جدول | `null` | The owning [ICell](https://reference.aspose.com/slides/fa/java/com.aspose.slides/icell/) |

هر دو متد ناوبری فقط‑خواندنی فراهم می‌کنند. فراخوانی آن‌ها فریم متن را جابجا یا مالک آن را تغییر نمی‌دهد. کد عمومی باید هر دو مقدار را برای `null` بررسی کرده و امکان عدم وجود هر دو مالک را مدیریت کند.

مثال زیر از [SlideUtil.getAllTextFrames](https://reference.aspose.com/slides/fa/java/com.aspose.slides/slideutil/#getAllTextFrames-com.aspose.slides.IPresentation-boolean-) برای پیمایش فریم‌های متن در یک ارائه استفاده می‌کند. برای شکل‌ها، نام شکل، نوع زمان اجرا جاوا و اسلاید حاوی آن گزارش می‌شود. برای سلول‌های جدول، مختصات ستون و ردیف صفر‑مبنا و اسلاید حاوی آن گزارش می‌شود.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ITextFrame[] textFrames = SlideUtil.getAllTextFrames(presentation, false);

    for (ITextFrame textFrame : textFrames) {
        IShape ownerShape = textFrame.getParentShape();
        if (ownerShape != null) {
            String shapeName = ownerShape.getName().isEmpty() ? "(unnamed)" : ownerShape.getName();
            String shapeType = ownerShape.getClass().getSimpleName();
            IBaseSlide baseSlide = ownerShape.getSlide();
            String slideLabel;
            if (baseSlide instanceof ISlide) {
                slideLabel = "slide " + ((ISlide) baseSlide).getSlideNumber();
            } else if (baseSlide instanceof INotesSlide) {
                slideLabel = "notes for slide " + ((INotesSlide) baseSlide).getParentSlide().getSlideNumber();
            } else {
                slideLabel = baseSlide.getClass().getSimpleName();
            }
            System.out.println("Shape: " + shapeName + "; type: " + shapeType + "; " + slideLabel);
            continue;
        }

        ICell ownerCell = textFrame.getParentCell();
        if (ownerCell != null) {
            IBaseSlide baseSlide = ownerCell.getSlide();
            String slideLabel;
            if (baseSlide instanceof ISlide) {
                slideLabel = "slide " + ((ISlide) baseSlide).getSlideNumber();
            } else if (baseSlide instanceof INotesSlide) {
                slideLabel = "notes for slide " + ((INotesSlide) baseSlide).getParentSlide().getSlideNumber();
            } else {
                slideLabel = baseSlide.getClass().getSimpleName();
            }
            System.out.println("Table cell: column " + ownerCell.getFirstColumnIndex() + ", row " + ownerCell.getFirstRowIndex() + "; " + slideLabel);
            continue;
        }

        System.out.println("The text frame owner is not available as a shape or table cell.");
    }
} finally {
    presentation.dispose();
}
```

برای محتوای SmartArt، از طریق شکل‌های موجود در [ISmartArtNode.getShapes](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ismartartnode/#getShapes--) پیمایش کنید و به هر [ISmartArtShape.getTextFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ismartartshape/#getTextFrame--) دسترسی پیدا کنید. فریم متن می‌تواند از طریق [ITextFrame.getParentShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itextframe/#getParentShape--) به شکل مرتبط خود ردیابی شود، در حالی که [ITextFrame.getParentCell](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itextframe/#getParentCell--) `null` برمی‌گرداند. بنابراین، شاخه شکل در مثال نیز متن‌های موجود در نودهای SmartArt را پردازش می‌کند.

## **جمع‌آوری اطلاعات تطبیق با کال‌بک**

یک پیاده‌سازی از [IFindResultCallback](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ifindresultcallback/) برای دریافت اعلان برای هر تطابق ایجاد کنید. متد [IFindResultCallback.foundResult](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ifindresultcallback/#foundResult-com.aspose.slides.ITextFrame-java.lang.String-java.lang.String-int-) آن فریم متن مرتبط، متن منبع، متن مطابقت یافته و موقعیت تطابق را فراهم می‌کند.

کال‌بک شماره اسلاید را به‌طور مستقیم دریافت نمی‌کند. پیاده‌سازی زیر آن را از اسلاید والد استخراج می‌کند و همچنین متن‌های یافت‌شده در یادداشت‌های اسلاید را مدیریت می‌کند. یک `Integer` قابل‌null اجازه می‌دهد مدل نتیجه یکسان متن مرتبط با انواع دیگر اسلایدها را نیز نمایندگی کند.

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

    private Integer getSlideNumber(ITextFrame textFrame) {
        IShape parentShape = textFrame.getParentShape();
        ICell parentCell = textFrame.getParentCell();
        IBaseSlide parentSlide = parentShape != null ? parentShape.getSlide() : parentCell != null ? parentCell.getSlide() : textFrame.getSlide();

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

برای عملیات جایگزینی، `foundText` شامل متن اصلی مطابقت یافته است، بنابراین کال‌بک می‌تواند دقیقاً چه واژه‌هایی جایگزین شده‌اند را ثبت کند.

## **برجسته‌سازی متن**

از متد [ITextFrame.highlightText](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) برای برجسته‌سازی تطابق‌های متن ثابت در یک فریم متن استفاده کنید. برای کنترل جستجو، یک [TextSearchOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/textsearchoptions/) پاس دهید و برای جمع‌آوری جزئیات تطابق یک کال‌بک فراهم کنید.

کد زیر تمام موارد کاراکترهای **"try"** را برجسته می‌کند و سپس تنها واژه کامل **"to"** را برجسته می‌سازد. هر دو جستجو تطابق‌های خود را به همان کال‌بک گزارش می‌دهند.

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

![The highlighted text](highlighted_text.png)

## **برجسته‌سازی متن با استفاده از عبارات منظم**

متد [ITextFrame.highlightRegex](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) متن‌های مطابق با یک عبارت منظم را در فریم متن برجسته می‌کند.

کد زیر تمام واژه‌هایی که دارای هفت کاراکتر یا بیشتر هستند را برجسته می‌کند و هر تطابق را جمع‌آوری می‌نماید:

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

![The highlighted text using the regular expression](highlighted_text_using_regex.png)

## **برجسته‌سازی متن در سراسر ارائه**

از [Presentation.highlightText](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) و [Presentation.highlightRegex](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) برای جستجو در تمام فریم‌های متن قابل استفاده در یک ارائه استفاده کنید. مثال زیر یک عبارت ثابت و تمام آدرس‌های ایمیل را برجسته می‌کند و مجموعه نتایج هر جستجو را جداگانه نگه می‌دارد.

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

## **جایگزینی متن در فریم متن**

از [ITextFrame.replaceText](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) برای متن ثابت و از [ITextFrame.replaceRegex](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) برای جایگزینی مبتنی بر الگو استفاده کنید. این متدها متن مطابقت یافته را داخل فریم متن موجود به‌روز می‌کنند، به‌طوری که قالب‌بندی بخش‌های اطراف باقی می‌ماند و نیازی به بازسازی فریم متن از رشته ساده نیست.

مثال زیر یک گونه املایی را استانداردسازی می‌کند و سپس برچسب‌های نسخه را جایگزین می‌سازد. همان کال‌بک اصطلاحات اصلی مطابقت یافته توسط هر دو عملیات را ثبت می‌کند.

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

اگر یک تطابق بخش‌هایی با قالب‌بندی متفاوت را در برگیرد، خروجی را بررسی کنید تا مطمئن شوید کدام قالب‌بندی برای متن جایگزین اعمال می‌شود.

## **جایگزینی متن در سراسر ارائه**

از [Presentation.replaceText](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) و [Presentation.replaceRegex](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) برای اعمال همان عملیات‌ها در کل ارائه استفاده کنید. این روش برای پاک‌سازی قالب، به‌روزرسانی اصطلاحات و حذف اطلاعات حساس مفید است.

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

## **گروه‌بندی تطابق‌ها برای گزارش‌دهی**

از آنجا که هر نتیجه شماره اسلاید و فریم متن مربوطه را ذخیره می‌کند، برنامه‌ها می‌توانند تطابق‌ها را برای حسابرسی، گزارش‌دهی یا گردش کارهای بازبینی گروه‌بندی کنند. مثال زیر نتایج جمع‌آوری‌شده را ابتدا بر اساس اسلاید و سپس بر اساس فریم متن گروه‌بندی می‌کند:

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

**چگونه می‌توانم فقط در یک جعبه متن جستجو کنم نه در کل ارائه؟**

فریم متن شکل را دریافت کنید و بر روی آن [ITextFrame.highlightText](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-)، [ITextFrame.highlightRegex](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-)، [ITextFrame.replaceText](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-)، یا [ITextFrame.replaceRegex](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) را روی آن فریم متن فراخوانی کنید. متدهای سطح ارائه تمام فریم‌های متن قابل استفاده را پردازش می‌کنند.

**چگونه می‌توانم کلمات کامل را با بزرگ‌نویسی صحیح مطابقت دهم؟**

[TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/fa/java/com.aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) و [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/fa/java/com.aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) را به `true` تنظیم کنید و گزینه‌ها را به متد برجسته‌سازی یا جایگزینی متن ثابت پاس دهید. برای عبارات منظم، مرزهای کلمه و حساسیت به حروف را در خود `Pattern` جاوا تعریف کنید.

**آیا جستجو و جایگزینی می‌تواند متن موجود در یادداشت‌های اسلاید را نیز شامل شود؟**

بله. هنگام استفاده از یک عملیات متن ثابت در سطح ارائه، [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/fa/java/com.aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) را به `true` تنظیم کنید. پیاده‌سازی کال‌بک نشان‌داده‌شده شماره اسلاید یادداشت را به شماره اسلاید اصلی مرتبط می‌کند.

**چگونه می‌توانم بدون اسکن مجدد ارائه گزارشی تهیه کنم؟**

یک پیاده‌سازی از [IFindResultCallback](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ifindresultcallback/) را به عملیات برجسته‌سازی یا جایگزینی پاس دهید. کال‌بک در حین اجرای عملیات هر تطابق را دریافت می‌کند، بنابراین برنامه می‌تواند متن منبع، متن مطابقت یافته، موقعیت، فریم متن و شماره اسلاید استخراج‌شده را برای گروه‌بندی یا خروجی بعدی ذخیره کند.

**آیا جایگزینی متن قالب‌بندی آن را حفظ می‌کند؟**

[ITextFrame.replaceText](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) و [ITextFrame.replaceRegex](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) متن مطابقت یافته را داخل فریم متن موجود تغییر می‌دهند و قالب‌بندی بخش‌های اطراف را حفظ می‌کنند. اگر یک تطابق بخش‌هایی با قالب‌بندی متفاوت را در برگیرد، نتیجه را بررسی کنید تا اطمینان حاصل شود قالب‌بندی موردنظر بر متن جایگزین اعمال شده است.