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
- callback نتیجه
- فریم متن
- گزارش حسابرسی
- PowerPoint
- OpenDocument
- ارائه
- Android
- Java
- Aspose.Slides
description: "جستجو، برجسته‌سازی و جایگزینی متن در ارائه‌های PowerPoint در حالی که هر مطابقتی را با Aspose.Slides برای Android از طریق Java جمع‌آوری می‌کند."
---
## **بررسی کلی**

Aspose.Slides برای Android از طریق Java می‌تواند متن را در یک فریم متنی جداگانه یا در تمام ارائه جستجو، برجسته و جایگزین کند. هر عملیات می‌تواند با استفاده از یک callback نتیجه، برنامه را در مورد هر مطابقت مطلع سازد. این امکان را فراهم می‌کند که ارائه را به‌روزرسانی کنید و به‌طور همزمان یک ردپای ارزیابی شامل متن مطابقت یافته، زمینه آن، موقعیت، فریم متنی و شماره اسلاید ایجاد کنید.

این قابلیت‌ها برای بازبینی، حذف اطلاعات حساس، بررسی اصطلاحات، پاک‌سازی قالب و گردش‌کارهای گزارش‌گیری خودکار مفید هستند.

در مثال‌های اولیه زیر، از فایلی به نام «sample.pptx» استفاده می‌کنیم که یک جعبه متنی واحد در اسلاید اول دارد و متن زیر را شامل می‌شود:

![متن نمونه](sample_text.png)

## **انتخاب دامنه جستجو**

از متدهای موجود در [ITextFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itextframe/) برای محدود کردن یک عملیات به یک فریم متنی استفاده کنید. از متدهای موجود در [IPresentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipresentation/) برای پردازش تمام متن‌های قابل اعمال در ارائه استفاده کنید.

| عملیات | یک فریم متنی | تمام ارائه |
|---|---|---|
| نشان‌گذاری متن ثابت | [ITextFrame.highlightText](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [IPresentation.highlightText](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipresentation/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| نشان‌گذاری مطابقت‌های عبارت منظم | [ITextFrame.highlightRegex](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-) | [IPresentation.highlightRegex](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipresentation/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-) |
| جایگزینی متن ثابت | [ITextFrame.replaceText](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [IPresentation.replaceText](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipresentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| جایگزینی مطابقت‌های عبارت منظم | [ITextFrame.replaceRegex](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) | [IPresentation.replaceRegex](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipresentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) |

## **پیکربندی مطابقت متن**

برای عملیات متن ثابت، از [TextSearchOptions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/textsearchoptions/) برای کنترل مطابقت استفاده کنید:

- متد [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) مطابقت‌ها را به کلمات کامل محدود می‌کند.
- متد [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) کنترل می‌کند که آیا باید حروف به‌صورت حساس به حروف بزرگ/کوچک مطابقت داشته باشند.
- متد [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) یادداشت‌های اسلاید را در جستجو، جایگزینی و عملیات برجسته‌سازی در سطح ارائه شامل می‌شود.

عملیات عبارات منظم از یک `Pattern` جاوا استفاده می‌کند، بنابراین قوانین مطابقت مانند حساسیت به حروف و مرزهای کلمه توسط عبارت و پرچم‌های آن تعریف می‌شوند.

## **شناسایی صاحب فریم متنی**

گردش‌کارهای عمومی پردازش متن اغلب یک [ITextFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itextframe/) را هنگام جستجو، جایگزینی، اعتبارسنجی یا خروجی گرفتن متن دریافت می‌کنند. از [ITextFrame.getParentShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itextframe/#getParentShape--) و [ITextFrame.getParentCell](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itextframe/#getParentCell--) برای تعیین اینکه کدام شیء ارائه صاحب فریم متنی است استفاده کنید.

مقادیر مورد انتظار بسته به صاحب متفاوت است:

| صاحب فریم متنی | `getParentShape` | `getParentCell` |
|---|---|---|
| یک AutoShape یا شکل دیگری که شامل متن است | شیء [IShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ishape/) مالک | `null` |
| یک سلول جدول | `null` | شیء [ICell](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/icell/) مالک |

هر دو متد پیمایش فقط‑خواندنی فراهم می‌کنند. فراخوانی آن‌ها فریم متنی را جابه‌جا نمی‌کند و صاحب آن را تغییر نمی‌دهد. کد عمومی باید هر دو مقدار را برای `null` بررسی کرده و امکان عدم وجود هر دو صاحب را مدیریت کند.

مثال زیر از [SlideUtil.getAllTextFrames](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/slideutil/#getAllTextFrames-com.aspose.slides.IPresentation-boolean-) برای مرور فریم‌های متنی در یک ارائه استفاده می‌کند. برای شکل‌ها، نام شکل، نوع زمان اجرا در جاوا و اسلاید حاوی را گزارش می‌کند. برای سلول‌های جدول، مختصات ستون و ردیف صفر‑مبتنی و اسلاید حاوی را گزارش می‌کند.

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

برای محتوای SmartArt، از شکل‌ها در [ISmartArtNode.getShapes](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ismartartnode/#getShapes--) پیمایش کنید و به هر [ISmartArtShape.getTextFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ismartartshape/#getTextFrame--) دسترسی پیدا کنید. فریم متنی می‌تواند از طریق [ITextFrame.getParentShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itextframe/#getParentShape--) به شکل مرتبط خود ردیابی شود، در حالی که [ITextFrame.getParentCell](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itextframe/#getParentCell--) `null` برمی‌گرداند. بنابراین شاخه شکل در مثال نیز متن موجود در گره‌های SmartArt را پردازش می‌کند.

## **جمع‌آوری اطلاعات مطابقت با یک Callback**

یک پیاده‌سازی از [IFindResultCallback](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ifindresultcallback/) را پیاده کنید تا برای هر مطابقت یک اعلان دریافت کنید. متد [IFindResultCallback.foundResult](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ifindresultcallback/#foundResult-com.aspose.slides.ITextFrame-java.lang.String-java.lang.String-int-) اطلاعات فریم متنی مرتبط، متن منبع، متن مطابقت یافته و موقعیت مطابقت را فراهم می‌کند.

callback شماره اسلاید را به‌صورت مستقیم دریافت نمی‌کند. پیاده‌سازی زیر آن را از اسلاید والد استخراج می‌کند و همچنین متن پیدا شده در یادداشت‌های اسلاید را مدیریت می‌کند. یک `Integer` قابل‌null اجازه می‌دهد همان مدل نتیجه متن مرتبط با انواع دیگر اسلایدها را نشان دهد.

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

برای عملیات جایگزینی، `foundText` شامل متن اصلی مطابقت یافته است، بنابراین callback می‌تواند دقیقاً ثبت کند که کدام عبارات جایگزین شده‌اند.

## **برجسته‌سازی متن**

از متد [ITextFrame.highlightText](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) برای برجسته‌سازی مطابقت‌های متن ثابت در یک فریم متنی استفاده کنید. برای کنترل جستجو، یک [TextSearchOptions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/textsearchoptions/) را می‌توانید پاس کنید و یک callback برای جمع‌آوری جزئیات مطابقت‌ها فراهم کنید.

کد زیر تمام موارد کاراکترهای **"try"** را برجسته می‌کند و سپس فقط کلمه کامل **"to"** را برجسته می‌نماید. هر دو جستجو مطابقت‌های خود را به همان callback گزارش می‌دهند.

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

    // تمام موارد ظهور "try" را در فریم متنی برجسته کنید.
    shape.getTextFrame().highlightText("try", substringHighlightColor, substringSearchOptions, callback);

    TextSearchOptions wholeWordSearchOptions = new TextSearchOptions();
    wholeWordSearchOptions.setWholeWordsOnly(true);
    wholeWordSearchOptions.setCaseSensitive(false);
    int wholeWordHighlightColor = Color.rgb(238, 130, 238);

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

![متن برجسته شده](highlighted_text.png)

## **برجسته‌سازی متن با استفاده از عبارات منظم**

متد [ITextFrame.highlightRegex](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-) متن‌های پیدا شده توسط یک عبارت منظم را در یک فریم متنی برجسته می‌کند.

کد زیر تمام کلماتی که دارای هفت یا بیشتر کاراکتر هستند را برجسته می‌کند و هر مطابقت را جمع‌آوری می‌کند:

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

![متن برجسته شده با استفاده از عبارت منظم](highlighted_text_using_regex.png)

## **برجسته‌سازی متن در سراسر یک ارائه**

از [IPresentation.highlightText](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipresentation/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) و [IPresentation.highlightRegex](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipresentation/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-) برای جستجوی تمام فریم‌های متنی قابل اعمال در یک ارائه استفاده کنید. مثال زیر یک اصطلاح ثابت و تمام آدرس‌های ایمیل را برجسته می‌کند و کلکسیون نتایج جداگانه‌ای برای دو جستجو نگه می‌دارد.

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

## **جایگزینی متن در یک فریم متنی**

از [ITextFrame.replaceText](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) برای متن ثابت و از [ITextFrame.replaceRegex](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) برای جایگزینی مبتنی بر الگو استفاده کنید. این متدها متن مطابقت یافته را درون فریم متنی موجود به‌روزرسانی می‌کنند که فرمت بخش‌های اطراف را حفظ می‌کند و نیازی به بازسازی فریم متنی از یک رشته ساده نیست.

مثال زیر یک نوع نوشتاری را استاندارد می‌کند و سپس برچسب‌های نسخه را جایگزین می‌نماید. همان callback عبارات اصلی مطابقت یافته توسط هر دو عملیات را ثبت می‌کند.

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

اگر یک مطابقت بخش‌هایی با فرمت‌های متفاوت را در بر داشته باشد، خروجی را بررسی کنید تا تأیید کنید کدام فرمت باید بر روی متن جایگزین اعمال شود.

## **جایگزینی متن در سراسر یک ارائه**

از [IPresentation.replaceText](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipresentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) و [IPresentation.replaceRegex](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipresentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) برای اعمال همان عملیات‌ها در تمام ارائه استفاده کنید. اینکار برای پاک‌سازی قالب، به‌روزرسانی اصطلاحات و حذف اطلاعات حساس مفید است.

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

## **گروه‌بندی مطابقت‌ها برای گزارش‌گیری**

از آنجا که هر نتیجه شماره اسلاید و فریم متنی خود را ذخیره می‌کند، برنامه‌ها می‌توانند مطابقت‌ها را برای حسابرسی، گزارش‌گیری یا گردش‌کارهای بازبینی گروه‌بندی کنند. مثال زیر نتایج جمع‌آوری‌شده را ابتدا بر اساس اسلاید و سپس بر اساس فریم متنی گروه‌بندی می‌کند:

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

**چگونه می‌توانم فقط یک جعبه متنی را به‌جای تمام ارائه جستجو کنم؟**

فریم متنی شکل را دریافت کنید و بر روی آن [ITextFrame.highlightText](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-)، [ITextFrame.highlightRegex](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-)، [ITextFrame.replaceText](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-)، یا [ITextFrame.replaceRegex](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) را فراخوانی کنید. متدهای سطح ارائه تمام فریم‌های متنی قابل اعمال را پردازش می‌کنند.

**چگونه می‌توانم کلمات کامل را با حروف بزرگ/کوچک صحیح مطابقت دهم؟**

[TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) و [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) را به `true` تنظیم کنید و گزینه‌ها را به متد برجسته‌سازی یا جایگزینی متن ثابت پاس بدهید. برای عبارات منظم، مرزهای کلمه و حساسیت به حروف را در خود `Pattern` جاوا تعریف کنید.

**آیا جستجو و جایگزینی می‌تواند متن در یادداشت‌های اسلاید را شامل شود؟**

بله. هنگام استفاده از یک عملیات متن ثابت در سطح ارائه، [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) را به `true` تنظیم کنید. پیاده‌سازی callback نشان‑داده‌شده در بالا، مطابقت در یک اسلاید یادداشت را به شماره اسلاید والد بازمی‌گرداند.

**چگونه می‌توانم بدون اسکن دوباره ارائه یک گزارش ایجاد کنم؟**

یک پیاده‌سازی از [IFindResultCallback](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ifindresultcallback/) را به عملیات برجسته‌سازی یا جایگزینی پاس بدهید. این callback در حین اجرا هر مطابقت را دریافت می‌کند، بنابراین برنامه می‌تواند متن منبع، متن مطابقت یافته، موقعیت، فریم متنی و شماره اسلاید استخراج‌شده را برای گروه‌بندی یا صادرات بعدی ذخیره کند.

**آیا جایگزینی متن فرمت آن را حفظ می‌کند؟**

[ITextFrame.replaceText](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) و [ITextFrame.replaceRegex](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) متن مطابقت یافته را درون فریم متنی موجود تغییر می‌دهند و فرمت بخش‌های اطراف را حفظ می‌کنند. اگر یک مطابقت بخش‌هایی با فرمت‌های متفاوت را در بر داشته باشد، نتیجه را بررسی کنید تا اطمینان حاصل کنید جایگزینی از سبک موردنظر استفاده می‌کند.