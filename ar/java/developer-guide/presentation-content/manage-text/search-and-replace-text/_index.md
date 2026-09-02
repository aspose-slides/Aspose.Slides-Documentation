---
title: البحث والاستبدال النص في عروض PowerPoint التقديمية باستخدام Java
linktitle: البحث والاستبدال النص
type: docs
weight: 55
url: /ar/java/search-and-replace-text/
keywords:
- بحث نص
- تمييز نص
- استبدال نص
- تعبير نمطي
- استدعاء نتيجة
- إطار نص
- تقرير تدقيق
- PowerPoint
- OpenDocument
- عرض تقديمي
- Java
- Aspose.Slides
description: "البحث، التمييز، والاستبدال النص في عروض PowerPoint التقديمية مع جمع كل تطابق باستخدام Aspose.Slides for Java."
---
## **نظرة عامة**

يمكن لـ Aspose.Slides for Java البحث عن النص وتظليله واستبداله داخل إطار نصي فردي أو عبر عرض تقديمي كامل. يمكن لكل عملية أيضًا إخطار التطبيق بكل تطابق من خلال استدعاء نتيجة. هذا يجعل من الممكن تحديث العرض التقديمي وفي الوقت نفسه بناء سجل تدقيق يحتوي على النص المتطابق وسياقه وموقعه وإطار النص ورقم الشريحة.

هذه الإمكانات مفيدة لمراجعة المحتوى، وحجب المعلومات، وفحص المصطلحات، وتنظيف القوالب، وسير عمل التقارير الآلية.

في الأمثلة الأولى أدناه، نستخدم ملفًا باسم "sample.pptx"، يحتوي على صندوق نص واحد في الشريحة الأولى بالنص التالي:

![نص العينة](sample_text.png)

## **اختر نطاق البحث**

استخدم الأساليب على [ITextFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itextframe/) لتقييد العملية على إطار نص واحد. استخدم الأساليب على [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/) لمعالجة جميع النصوص القابلة للتطبيق في العرض التقديمي.

| العملية | إطار نص واحد | العرض التقديمي كامل |
|---|---|---|
| تمييز النص الحرفي | [ITextFrame.highlightText](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [Presentation.highlightText](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| تمييز التطابقات باستخدام التعبير النمطي | [ITextFrame.highlightRegex](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) | [Presentation.highlightRegex](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) |
| استبدال النص الحرفي | [ITextFrame.replaceText](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [Presentation.replaceText](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| استبدال التطابقات باستخدام التعبير النمطي | [ITextFrame.replaceRegex](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) | [Presentation.replaceRegex](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) |

## **ضبط مطابقة النص**

لعمليات النص الحرفي، استخدم [TextSearchOptions](https://reference.aspose.com/slides/ar/java/com.aspose.slides/textsearchoptions/) للتحكم في المطابقة:

- [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/ar/java/com.aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) يحد من التطابقات إلى كلمات كاملة.
- [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/ar/java/com.aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) يتحكم فيما إذا كان يجب مطابقة حالة الأحرف.
- [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/ar/java/com.aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) يشمل ملاحظات الشرائح في عمليات البحث والاستبدال والتمييز على مستوى العرض التقديمي.

تستخدم عمليات التعبير النمطي كائن Java `Pattern`، لذلك تُعرّف قواعد المطابقة مثل حساسية الحالة وحدود الكلمات بواسطة التعبير وعلماته.

## **تحديد مالك إطار النص**

غالبًا ما تستقبل سير عمل معالجة النص العامة كائنًا من نوع [ITextFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itextframe/) أثناء البحث أو الاستبدال أو التحقق أو التصدير. استخدم [ITextFrame.getParentShape](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itextframe/#getParentShape--) و[ITextFrame.getParentCell](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itextframe/#getParentCell--) لتحديد أي كائن عرض تقديمي يملك إطار النص.

القيم المتوقعة تعتمد على المالك:

| مالك إطار النص | `getParentShape` | `getParentCell` |
|---|---|---|
| AutoShape أو شكل آخر يحتوي نصًا | الـ[IShape](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ishape/) المالك | `null` |
| خلية جدول | `null` | الـ[ICell](https://reference.aspose.com/slides/ar/java/com.aspose.slides/icell/) المالك |

كلا الطريقتين توفران تنقلًا للقراءة فقط. استدعاؤهما لا ينقل إطار النص ولا يغيّر مالكه. يجب على الشيفرة العامة فحص كلا القيمتين للتحقق من `null` ومعالجة احتمال عدم توفر أي مالك.

يستخدم المثال التالي [SlideUtil.getAllTextFrames](https://reference.aspose.com/slides/ar/java/com.aspose.slides/slideutil/#getAllTextFrames-com.aspose.slides.IPresentation-boolean-) للتكرار عبر إطارات النص في العرض التقديمي. بالنسبة للأشكال، يُبلغ عن اسم الشكل، ونوعه في وقت تشغيل Java، والشريحة المحتوية. بالنسبة لخلايا الجدول، يُبلغ عن إحداثيات العمود والصف التي تبدأ من الصفر والشريحة المحتوية.

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

لمحتوى SmartArt، تكرّر عبر الأشكال في [ISmartArtNode.getShapes](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ismartartnode/#getShapes--) واحصل على كل [ISmartArtShape.getTextFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ismartartshape/#getTextFrame--). يمكن تتبع إطار النص إلى الشكل المرتبط عبر [ITextFrame.getParentShape](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itextframe/#getParentShape--)، بينما تُعيد [ITextFrame.getParentCell](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itextframe/#getParentCell--) `null`. لذلك، يتعامل فرع الشكل في المثال أيضًا مع النص من عقد SmartArt.

## **جمع معلومات المطابقة عبر استدعاء رد ناتج**

قم بتنفيذ [IFindResultCallback](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ifindresultcallback/) لتلقي إشعار لكل مطابقة. توفر الطريقة [IFindResultCallback.foundResult](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ifindresultcallback/#foundResult-com.aspose.slides.ITextFrame-java.lang.String-java.lang.String-int-) الإطار النصي المتعلق، النص الأصلي، النص المتطابق، وموقع المطابقة.

لا تتلقى الاستدعاءات رقم الشريحة مباشرة. تستخرج التنفيذ أدناه ذلك من الشريحة الأم وتتعامل أيضًا مع النص الموجود في ملاحظات الشرائح. يسمح `Integer` القابل للكون بـ `null` لنفس نموذج النتيجة بتمثيل النص المرتبط بأنواع شرائح أخرى.

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

في عمليات الاستبدال، يحتوي `foundText` على النص المتطابق الأصلي، لذا يمكن للاستدعاء تسجيل المصطلحات التي تم استبدالها بدقة.

## **تمييز النص**

استخدم طريقة [ITextFrame.highlightText](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) لتظليل التطابقات النصية الحرفية في إطار نص. مرّر [TextSearchOptions](https://reference.aspose.com/slides/ar/java/com.aspose.slides/textsearchoptions/) للتحكم في البحث واستدعاء رد ناتج لجمع تفاصيل المطابقة.

يُظهر مثال الشيفرة أدناه كيفية تمييز جميع حالات الأحرف **"try"** ثم تمييز الكلمة الكاملة **"to"** فقط. كلا البحثين يرسلان تطابقاتهما إلى نفس الاستدعاء.

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

    // تمييز كلمة "to" الكاملة فقط.
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

![النص المميز](highlighted_text.png)

## **تمييز النص باستخدام التعبيرات النمطية**

تُبرز طريقة [ITextFrame.highlightRegex](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) النصوص التي يحددها التعبير النمطي داخل إطار نص.

يقوم الشيفرة التالية بتمييز جميع الكلمات التي تحتوي على سبعة أحرف أو أكثر وتجمع كل تطابق:

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

![النص المميز باستخدام التعبير النمطي](highlighted_text_using_regex.png)

## **تمييز النص عبر عرض تقديمي**

استخدم [Presentation.highlightText](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) و[Presentation.highlightRegex](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) للبحث في جميع إطارات النص القابلة للتطبيق في العرض التقديمي. يوضح المثال التالي تمييز مصطلح حرفي وجميع عناوين البريد الإلكتروني مع الاحتفاظ بمجموعات نتائج منفصلة لكل بحث.

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

استخدم [ITextFrame.replaceText](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) للنص الحرفي و[ITextFrame.replaceRegex](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) للاستبدال القائم على النمط. تُحدّث هذه الأساليب النص المتطابق داخل إطار النص الحالي، مما يحافظ على تنسيق الجزء المحيط بدلاً من إعادة بناء إطار النص من سلسلة عادية.

يقوم المثال التالي بتوحيد تنوع إملائي ثم استبدال تسميات الإصدارات. يسجل نفس الاستدعاء المصطلحات الأصلية التي تم مطابقتها في كلتا العمليتين.

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

إذا امتد أحد التطابقات عبر أجزاء ذات تنسيق مختلف، راجع النتيجة لتأكيد أي تنسيق يجب أن يُطبق على النص المستبدل.

## **استبدال النص عبر عرض تقديمي**

استخدم [Presentation.replaceText](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) و[Presentation.replaceRegex](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) لتطبيق نفس العمليات عبر العرض التقديمي. هذا مفيد لتنظيف القوالب، وتحديث المصطلحات، والحجب.

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

## **تجميع المطابقات للتقارير**

نظرًا لأن كل نتيجة تخزن رقم الشريحة وإطار النص، يمكن للتطبيقات تجميع المطابقات للتدقيق أو التقارير أو سير العمل المراجعي. يوضح المثال التالي تجميع النتائج المجمّعة أولاً حسب الشريحة ثم حسب إطار النص:

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

**كيف يمكنني البحث في صندوق نص واحد فقط بدلاً من العرض التقديمي بالكامل؟**

احصل على إطار النص الخاص بالشكل واستدعِ [ITextFrame.highlightText](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-)، [ITextFrame.highlightRegex](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-)، [ITextFrame.replaceText](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-)، أو [ITextFrame.replaceRegex](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) على ذلك الإطار. تعالج الأساليب على مستوى العرض التقديمي جميع إطارات النص القابلة للتطبيق بدلاً من ذلك.

**كيف يمكنني مطابقة الكلمات الكاملة مع الالتزام بحالة الأحرف الصحيحة؟**

اضبط [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/ar/java/com.aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) و[TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/ar/java/com.aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) على `true`، ومرّر الخيارات إلى طريقة تمييز أو استبدال النص الحرفي. بالنسبة للتعبيرات النمطية، عرّف حدود الكلمات وحساسية الحالة داخل `Pattern` في Java نفسه.

**هل يمكن أن تشمل عمليات البحث والاستبدال النص الموجود في ملاحظات الشرائح؟**

نعم. اضبط [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/ar/java/com.aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) على `true` عند استخدام عملية نص حرفي على مستوى العرض التقديمي. تُعيد تنفيذ الاستدعاء الموضحة أعلاه مطابقة في شريحة ملاحظات إلى رقم الشريحة الأم.

**كيف يمكنني إنشاء تقرير دون مسح العرض التقديمي مرة ثانية؟**

مرّر تنفيذًا لـ [IFindResultCallback](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ifindresultcallback/) إلى عملية التمييز أو الاستبدال. يتلقى الاستدعاء كل مطابقة أثناء تشغيل العملية، وبالتالي يمكن للتطبيق تخزين النص الأصلي، والنص المتطابق، والموقع، وإطار النص، ورقم الشريحة المستنتج لتجميعها أو تصديرها لاحقًا.

**هل يحافظ استبدال النص على تنسيقه؟**

تُعيد كل من [ITextFrame.replaceText](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) و[ITextFrame.replaceRegex](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) تعديل النص المتطابق داخل إطار النص الحالي وتحتفظ بتنسيق الجزء المحيط. إذا امتد التطابق عبر أجزاء ذات تنسيق مختلف، تحقّق من النتيجة لضمان أن الاستبدال يستخدم النمط المطلوب.