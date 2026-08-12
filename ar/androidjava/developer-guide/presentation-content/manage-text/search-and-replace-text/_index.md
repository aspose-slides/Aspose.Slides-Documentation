---
title: البحث عن النص واستبداله في عروض PowerPoint على Android
linktitle: البحث عن النص واستبداله
type: docs
weight: 55
url: /ar/androidjava/search-and-replace-text/
keywords:
- البحث عن النص
- تظليل النص
- استبدال النص
- تعبير نمطي
- استدعاء نتيجة
- إطار النص
- تقرير تدقيق
- PowerPoint
- OpenDocument
- العرض التقديمي
- Android
- Java
- Aspose.Slides
description: "ابحث، وميّز، واستبدل النص في عروض PowerPoint بينما تجمع كل تطابق باستخدام Aspose.Slides for Android عبر Java."
---
## **نظرة عامة**

يمكن لـ Aspose.Slides for Android عبر Java البحث وتحديد النص وتغييره داخل إطار نصي فردي أو عبر عرض تقديمي كامل. يمكن لكل عملية أيضًا إبلاغ التطبيق عن كل تطابق من خلال استدعاء نتيجة. هذا يجعل من الممكن تحديث العرض التقديمي وفي الوقت نفسه إنشاء سجل تتبع يحتوي على النص المتطابق، وسياقه، وموقعه، وإطار النص، ورقم الشريحة.

هذه الإمكانات مفيدة للمراجعة، والطمس، وفحص المصطلحات، وتنظيف القوالب، وتدفقات العمل للتقارير الآلية.

في الأمثلة الأولى أدناه، نستخدم ملفًا باسم "sample.pptx"، يحتوي على صندوق نص واحد في الشريحة الأولى بالنص التالي:

![Sample text](sample_text.png)

## **اختر نطاق البحث**

استخدم الأساليب في [ITextFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/itextframe/) لتقييد العملية على إطار نص واحد. استخدم الأساليب في [IPresentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipresentation/) لمعالجة جميع النصوص القابلة للتطبيق في العرض التقديمي.

| العملية | إطار نص واحد | العرض التقديمي بالكامل |
|---|---|---|
| Highlight literal text | [ITextFrame.highlightText](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [IPresentation.highlightText](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipresentation/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Highlight regular-expression matches | [ITextFrame.highlightRegex](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-) | [IPresentation.highlightRegex](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipresentation/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-) |
| Replace literal text | [ITextFrame.replaceText](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [IPresentation.replaceText](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipresentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Replace regular-expression matches | [ITextFrame.replaceRegex](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) | [IPresentation.replaceRegex](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipresentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) |

## **تكوين مطابقة النص**

للعمليات التي تتعامل مع النص الحرفي، استخدم [TextSearchOptions](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/textsearchoptions/) للتحكم في المطابقة:

- [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) يقتصر المطابقات على الكلمات الكاملة.
- [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) يتحكم فيما إذا كان يجب تطابق حالة الأحرف.
- [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) يضم ملاحظات الشرائح في عمليات البحث والاستبدال والتمييز على مستوى العرض التقديمي.

تستخدم عمليات التعبير النمطي Java `Pattern`، لذا تُحدد قواعد المطابقة مثل حساسية الحالة وحدود الكلمات داخل التعبير وعلاماته.

## **جمع معلومات التطابق عبر استدعاء رد الاتصال**

نفّذ [IFindResultCallback](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ifindresultcallback/) لتلقي إشعار لكل تطابق. الطريقة [IFindResultCallback.foundResult](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ifindresultcallback/#foundResult-com.aspose.slides.ITextFrame-java.lang.String-java.lang.String-int-) توفر إطار النص المتعلق، والنص المصدر، والنص المتطابق، وموقع التطابق.

لا يتلقى رد الاتصال رقم الشريحة مباشرة. تُستمد القيمة في المثال أدناه من الشريحة الأصلية وتتعامل أيضًا مع النص الموجود في ملاحظات الشرائح. يسمح `Integer` قابل للعدّ بالقيم `null` بتمثيل النص المرتبط بأنواع شرائح أخرى بنفس نموذج النتيجة.

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

بالنسبة لعمليات الاستبدال، يحتوي `foundText` على النص الأصلي المتطابق، وبالتالي يمكن لاستدعاء رد الاتصال تسجيل المصطلحات التي تم استبدالها بدقة.

## **تمييز النص**

استخدم الطريقة [ITextFrame.highlightText](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) لتمييز مطابقات النص الحرفي داخل إطار نص. مرّر [TextSearchOptions](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/textsearchoptions/) للتحكم في البحث واستدعاء رد الاتصال لجمع تفاصيل التطابق.

المثال البرمجي أدناه يميز جميع تكرارات الحرفين **"try"** ثم يميز الكلمة الكاملة **"to"** فقط. كلا البحثين يبلّغان عن تطابقاتهما إلى نفس رد الاتصال.

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

    // تسليط الضوء على كل ظهور لكلمة "try" في إطار النص.
    shape.getTextFrame().highlightText("try", substringHighlightColor, substringSearchOptions, callback);

    TextSearchOptions wholeWordSearchOptions = new TextSearchOptions();
    wholeWordSearchOptions.setWholeWordsOnly(true);
    wholeWordSearchOptions.setCaseSensitive(false);
    int wholeWordHighlightColor = Color.rgb(238, 130, 238);

    // تسليط الضوء فقط على الكلمة الكاملة "to".
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

## **تمييز النص باستخدام التعبيرات النمطية**

الطريقة [ITextFrame.highlightRegex](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-) تميز مطابقات النص التي يجدها تعبير نمطي داخل إطار نص.

الكود التالي يميز جميع الكلمات التي تحتوي على سبعة أحرف أو أكثر ويجمع كل تطابق:

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

النتيجة:

![The highlighted text using the regular expression](highlighted_text_using_regex.png)

## **تمييز النص عبر العرض التقديمي**

استخدم [IPresentation.highlightText](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipresentation/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) و [IPresentation.highlightRegex](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipresentation/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-) للبحث في جميع إطارات النص القابلة للتطبيق في العرض التقديمي. المثال التالي يميز مصطلحًا حرفيًا وجميع عناوين البريد الإلكتروني مع الحفاظ على مجموعات نتائج منفصلة للبحثين.

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

## **استبدال النص في إطار نص**

استخدم [ITextFrame.replaceText](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) للنص الحرفي و[ITextFrame.replaceRegex](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) للاستبدال القائم على النمط. تُحدّث هذه الأساليب النص المتطابق داخل إطار النص الموجود، مع الحفاظ على تنسيق الجزء المحيط بدلاً من إعادة بناء إطار النص من سلسلة عادية.

المثال التالي يوحد صيغة لفظية ثم يستبدل تسميات الإصدارات. نفس رد الاتصال يسجّل المصطلحات الأصلية التي تم مطابقتها في كلا العمليتين.

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

إذا امتد تطابق على أجزاء ذات تنسيق مختلف، راجع المخرجات لتأكيد أي تنسيق يجب تطبيقه على النص المستبدل.

## **استبدال النص عبر العرض التقديمي**

استخدم [IPresentation.replaceText](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipresentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) و[IPresentation.replaceRegex](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipresentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) لتطبيق نفس العمليات عبر العرض التقديمي. هذا مفيد لتنظيف القوالب، وتحديث المصطلحات، والطمس.

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

نظرًا لأن كل نتيجة تخزن رقم الشريحة وإطار النص، يمكن للتطبيقات تجميع التطابقات لأغراض التدقيق أو التقارير أو سير عمل المراجعة. المثال التالي يجمع النتائج التي تم جمعها أولاً بحسب الشريحة ثم بحسب إطار النص:

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

**كيف يمكنني البحث داخل صندوق نص واحد فقط بدلاً من العرض التقديمي بالكامل؟**

احصل على إطار النص الخاص بالشكل واستدعِ [ITextFrame.highlightText](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-)، [ITextFrame.highlightRegex](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-)، [ITextFrame.replaceText](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-)، أو [ITextFrame.replaceRegex](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) على ذلك الإطار. تُعالج أساليب مستوى العرض التقديمي جميع إطارات النص القابلة للتطبيق بدلاً من ذلك.

**كيف يمكنني مطابقة الكلمات الكاملة مع الحالة الصحيحة للأحرف؟**

عيّن [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) و[TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) إلى `true`، ومرّر الخيارات إلى طريقة تمييز أو استبدال النص الحرفي. بالنسبة للتعبيرات النمطية، عيّن حدود الكلمات وحساسية الحالة داخل `Pattern` في Java نفسها.

**هل يمكن أن تشمل عمليات البحث والاستبدال النص الموجود في ملاحظات الشرائح؟**

نعم. عيّن [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) إلى `true` عند استخدام عملية نص حرفي على مستوى العرض التقديمي. تقوم تنفيذية رد الاتصال الموضحة أعلاه بربط التطابق في شريحة الملاحظات برقم الشريحة الأصلية.

**كيف يمكنني إنشاء تقرير دون مسح العرض التقديمي مرة ثانية؟**

مرّر تنفيذية [IFindResultCallback](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ifindresultcallback/) إلى عملية التمييز أو الاستبدال. يتلقى رد الاتصال كل تطابق أثناء تشغيل العملية، وبالتالي يمكن للتطبيق تخزين النص المصدر، والنص المتطابق، والموقع، وإطار النص، ورقم الشريحة المستنتج لتجميعه أو تصديره لاحقًا.

**هل يحافظ استبدال النص على تنسيقه؟**

[ITextFrame.replaceText](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) و[ITextFrame.replaceRegex](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) يغيران النص المتطابق داخل إطار النص الحالي ويحتفظان بتنسيق الجزء المحيط. إذا امتد التطابق على أجزاء ذات تنسيق مختلف، فافحص النتيجة لضمان أن الاستبدال يستخدم النمط المطلوب.