---
title: "البحث واستبدال النص في عروض PowerPoint التقديمية باستخدام Java"
linktitle: "البحث واستبدال النص"
type: docs
weight: 55
url: /ar/java/search-and-replace-text/
keywords:
- نص البحث
- تمييز النص
- استبدال النص
- تعبير عادي
- رد نداء للنتيجة
- إطار النص
- تقرير تدقيق
- PowerPoint
- OpenDocument
- عرض تقديمي
- Java
- Aspose.Slides
description: "البحث، وتمييز، واستبدال النص في عروض PowerPoint التقديمية مع جمع كل تطابق باستخدام Aspose.Slides for Java."
---
## **نظرة عامة**

يمكن لـ Aspose.Slides for Java البحث عن النص وتحديده واستبداله داخل إطار نصي واحد أو عبر العرض التقديمي بأكمله. يمكن لكل عملية أيضًا إخطار التطبيق عن كل تطابق من خلال رد نداء للنتيجة. يتيح ذلك إمكانية تحديث العرض التقديمي وبناء سجل تدقيق يحتوي على النص المتطابق وسياقه وموقعه وإطار النص ورقم الشريحة.

تُعد هذه الإمكانات مفيدة للمراجعة، والتمويه، والتحقق من المصطلحات، وتنظيف القوالب، وسير عمل التقارير الآلية.

في الأمثلة الأولى أدناه، نستخدم ملفًا باسم **“sample.pptx”** يحتوي على صندوق نصي واحد في الشريحة الأولى بالنص التالي:

![Sample text](sample_text.png)

## **اختر نطاق البحث**

استخدم الطرق على [ITextFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itextframe/) لتقييد عملية على إطار نص واحد. استخدم الطرق على [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/) لمعالجة جميع النصوص القابلة للتطبيق في العرض التقديمي.

| العملية | إطار نص واحد | العرض التقديمي بالكامل |
|---|---|---|
| تمييز النص الحرفي | [ITextFrame.highlightText](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [Presentation.highlightText](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| تمييز التطابقات بتعبير عادي | [ITextFrame.highlightRegex](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) | [Presentation.highlightRegex](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) |
| استبدال النص الحرفي | [ITextFrame.replaceText](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [Presentation.replaceText](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| استبدال التطابقات بتعبير عادي | [ITextFrame.replaceRegex](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) | [Presentation.replaceRegex](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) |

## **تهيئة مطابقة النص**

لعمليات النص الحرفي، استخدم [TextSearchOptions](https://reference.aspose.com/slides/ar/java/com.aspose.slides/textsearchoptions/) للتحكم في المطابقة:

- [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/ar/java/com.aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) يحدّ التطابقات إلى كلمات كاملة.
- [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/ar/java/com.aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) يحدد ما إذا كان يجب مطابقة حالة الأحرف.
- [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/ar/java/com.aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) يضمّن ملاحظات الشرائح في عمليات البحث والاستبدال والتمييز على مستوى العرض التقديمي.

تستخدم عمليات التعبير العادي كائن Java `Pattern`، لذا تُحدد قواعد المطابقة مثل حساسية الحالة وحدود الكلمات داخل التعبير وعلماته.

## **جمع معلومات التطابق عبر رد نداء**

نفّذ [IFindResultCallback](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ifindresultcallback/) لتلقي إشعار لكل تطابق. يوفر أسلوبه [IFindResultCallback.foundResult](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ifindresultcallback/#foundResult-com.aspose.slides.ITextFrame-java.lang.String-java.lang.String-int-) إطار النص المرتبط، والنص الأصلي، والنص المتطابق، وموقع التطابق.

لا يتلقى رد النداء رقم الشريحة مباشرة. يستخلص التنفيذ أدناه الرقم من الشريحة الأصلية ويتعامل أيضًا مع النص الموجود في ملاحظات الشرائح. يسمح `Integer` القابل للخطأ للنتيجة نفسها بتمثيل النص المرتبط بأنواع شرائح أخرى.

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

في عمليات الاستبدال، يحتوي `foundText` على النص المتطابق الأصلي، وبالتالي يمكن لرد النداء تسجيل المصطلحات التي تم استبدالها بالضبط.

## **تمييز النص**

استخدم الأسلوب [ITextFrame.highlightText](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) لتمييز تطابقات النص الحرفي في إطار نص. مرّر [TextSearchOptions](https://reference.aspose.com/slides/ar/java/com.aspose.slides/textsearchoptions/) للتحكم في البحث ورد النداء لجمع تفاصيل التطابق.

يعرض المثال البرمجي أدناه تمييز جميع تكرارات الحرفين **"try"** ثم تمييز الكلمة الكاملة **"to"** فقط. كلا البحثين يبلghanنت تطابقاتهما إلى نفس رد النداء.

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

    // تمييز كل ظهور لكلمة "try" في إطار النص.
    shape.getTextFrame().highlightText("try", substringHighlightColor, substringSearchOptions, callback);

    TextSearchOptions wholeWordSearchOptions = new TextSearchOptions();
    wholeWordSearchOptions.setWholeWordsOnly(true);
    wholeWordSearchOptions.setCaseSensitive(false);
    Color wholeWordHighlightColor = new Color(238, 130, 238);

    // تمييز الكلمة الكاملة "to" فقط.
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

النتيجة:

![The highlighted text](highlighted_text.png)

## **تمييز النص باستخدام تعبيرات عادية**

يتميز الأسلوب [ITextFrame.highlightRegex](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) النصوص التي يجدها التعبير العادي في إطار نص.

الكود التالي يميّز جميع الكلمات التي تحتوي على سبعة أحرف أو أكثر ويجمع كل تطابق:

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

النتيجة:

![The highlighted text using the regular expression](highlighted_text_using_regex.png)

## **تمييز النص عبر العرض التقديمي**

استخدم [Presentation.highlightText](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) و[Presentation.highlightRegex](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) للبحث في جميع إطارات النص القابلة للتطبيق في العرض التقديمي. يوضح المثال التالي تمييز مصطلح حرفي وجميع عناوين البريد الإلكتروني مع الاحتفاظ بمجموعات نتائج منفصلة للبحثين.

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

## **استبدال النص في إطار نص**

استخدم [ITextFrame.replaceText](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) للنص الحرفي و[ITextFrame.replaceRegex](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) للاستبدال القائم على نمط. تقوم هذه الأساليب بتحديث النص المتطابق داخل إطار النص الحالي، مع الحفاظ على تنسيق الجزء المحيط بدلاً من إعادة بناء إطار النص من سلسلة نصية عادية.

المثال التالي يوحد متغير إملائي ثم يستبدل علامات الإصدارات. يسجل نفس رد النداء المصطلحات الأصلية المتطابقة في كلا العمليتين.

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

إذا امتد تطابق واحد عبر أجزاء ذات تنسيقات مختلفة، راجع النتيجة لتأكيد أي تنسيق يجب أن يُطبق على النص المستبدل.

## **استبدال النص عبر العرض التقديمي**

استخدم [Presentation.replaceText](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) و[Presentation.replaceRegex](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) لتطبيق نفس العمليات عبر العرض التقديمي. هذا مفيد لتنظيف القوالب، وتحديث المصطلحات، والتمويه.

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

## **تجميع التطابقات للتقارير**

نظرًا لأن كل نتيجة تخزن رقم الشريحة وإطار النص، يمكن للتطبيقات تجميع التطابقات للتدقيق أو التقارير أو سير عمل المراجعة. يجمع المثال التالي النتائج المجمعة أولاً حسب الشريحة ثم حسب إطار النص:

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

## **الأسئلة الشائعة**

**كيف يمكنني البحث في صندوق نص واحد فقط بدلاً من العرض التقديمي بأكمله؟**

احصل على إطار النص الخاص بالشكل واستدعِ [ITextFrame.highlightText](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-)، [ITextFrame.highlightRegex](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-)، [ITextFrame.replaceText](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-)، أو [ITextFrame.replaceRegex](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) على ذلك الإطار. تُعالج طرق مستوى العرض التقديمي جميع إطارات النص القابلة للتطبيق بدلاً من ذلك.

**كيف يمكنني مطابقة الكلمات الكاملة مع الاعتبار الصحيح لحالة الأحرف؟**

عيّن [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/ar/java/com.aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) و[TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/ar/java/com.aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) إلى `true`، ومرّر الخيارات إلى طريقة تمييز أو استبدال النص الحرفي. بالنسبة للتعبيرات العادية، عرّف حدود الكلمات وحساسية الحالة داخل كائن Java `Pattern` نفسه.

**هل يمكن أن تشمل عمليات البحث والاستبدال النص الموجود في ملاحظات الشرائح؟**

نعم. عيّن [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/ar/java/com.aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) إلى `true` عند استخدام عملية نص حرفي على مستوى العرض التقديمي. تقوم تنفيذية رد النداء الموضحة أعلاه بربط التطابق في شريحة ملاحظات بالرقم الأصلي للشريحة الأصلية.

**كيف يمكنني إنشاء تقرير دون مسح العرض التقديمي مرة ثانية؟**

مرّر تنفيذية [IFindResultCallback](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ifindresultcallback/) إلى عملية التمييز أو الاستبدال. يتلقى رد النداء كل تطابق أثناء تنفيذ العملية، مما يسمح للتطبيق بتخزين النص الأصلي، والنص المتطابق، والموقع، وإطار النص، ورقم الشريحة المستنتج لتجميعه لاحقًا أو تصديره.

**هل يحافظ استبدال النص على تنسيقه؟**

كل من [ITextFrame.replaceText](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) و[ITextFrame.replaceRegex](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) يعديلان النص المتطابق داخل إطار النص الحالي ويحتفظان بتنسيق الجزء المحيط. إذا امتد التطابق عبر أجزاء ذات تنسيقات مختلفة، فافحص النتيجة لضمان أن الاستبدال يستخدم النمط المطلوب.