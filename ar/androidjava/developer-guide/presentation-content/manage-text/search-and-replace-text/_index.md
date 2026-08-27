---
title: بحث واستبدال النص في عروض PowerPoint على Android
linktitle: بحث واستبدال النص
type: docs
weight: 55
url: /ar/androidjava/search-and-replace-text/
keywords:
- بحث النص
- تظليل النص
- استبدال النص
- تعبير نمطي
- رد نداء النتيجة
- إطار النص
- تقرير تدقيق
- PowerPoint
- OpenDocument
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "ابحث، ظلل، واستبدل النص في عروض PowerPoint مع جمع كل مطابقة باستخدام Aspose.Slides للـ Android عبر Java."
---
## **نظرة عامة**

يمكن لـ Aspose.Slides for Android via Java البحث وتظليل واستبدال النص في إطار نصي فردي أو عبر العرض التقديمي بأكمله. يمكن لكل عملية أيضًا إبلاغ التطبيق عن كل تطابق من خلال رد نداء النتيجة. يتيح ذلك تحديث العرض التقديمي وبناء سجل تدقيق يتضمن النص المتطابق وسياقه وموقعه وإطار النص ورقم الشريحة.

هذه الإمكانات مفيدة للمراجعة وإزالة المعلومات الحساسة وفحوصات المصطلحات وتنظيف القوالب وتدفقات العمل الآلية للتقارير.

في الأمثلة الأولى أدناه، نستخدم ملفًا باسم "sample.pptx"، يحتوي على صندوق نص واحد في الشريحة الأولى بالنص التالي:

![Sample text](sample_text.png)

## **اختر نطاق البحث**

استخدم الأساليب على [ITextFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/itextframe/) لتحديد عملية لإطار نصي واحد. استخدم الأساليب على [IPresentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipresentation/) لمعالجة جميع النصوص القابلة للتطبيق في العرض التقديمي.

| العملية | إطار نصي واحد | العرض التقديمي بالكامل |
|---|---|---|
| تظليل النص الحرفي | [ITextFrame.highlightText](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [IPresentation.highlightText](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipresentation/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| تظليل التطابقات باستخدام تعبيرات نمطية | [ITextFrame.highlightRegex](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-) | [IPresentation.highlightRegex](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipresentation/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-) |
| استبدال النص الحرفي | [ITextFrame.replaceText](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [IPresentation.replaceText](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipresentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| استبدال التطابقات باستخدام تعبيرات نمطية | [ITextFrame.replaceRegex](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) | [IPresentation.replaceRegex](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipresentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) |

## **تكوين مطابقة النص**

لعمليات النص الحرفي، استخدم [TextSearchOptions](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/textsearchoptions/) للتحكم في المطابقة:

- [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) يحد من المطابقات إلى كلمات كاملة.
- [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) يتحكم فيما إذا كان يجب مطابقة حالة الأحرف.
- [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) يضم ملاحظات الشرائح في عمليات البحث والاستبدال والتظليل على مستوى العرض التقديمي.

تستخدم عمليات التعبيرات النمطية كائن Java `Pattern`، لذا فإن قواعد المطابقة مثل حساسية الحالة وحدود الكلمات تُحدد بواسطة التعبير وعلماته.

## **تحديد مالك إطار النص**

غالبًا ما تتلقى سير عمل معالجة النص العامة كائنًا من النوع [ITextFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/itextframe/) أثناء البحث أو الاستبدال أو التحقق أو التصدير. استخدم [ITextFrame.getParentShape](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/itextframe/#getParentShape--) و[ITextFrame.getParentCell](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/itextframe/#getParentCell--) لتحديد أي كائن عرض تقديمي يملك إطار النص.

القيم المتوقعة تعتمد على المالك:

| مالك إطار النص | `getParentShape` | `getParentCell` |
|---|---|---|
| شكل AutoShape أو أي شكل يحتوي على نص | الشكل [IShape](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ishape/) المالك | `null` |
| خلية جدول | `null` | الخلية [ICell](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/icell/) المالك |

كلا الطريقتين توفر تنقلًا للقراءة فقط. لا يؤدي استدعاؤهما إلى نقل إطار النص أو تغيير مالكه. يجب على الشيفرة العامة فحص القيمتين لـ `null` ومعالجة احتمال عدم توفر أي مالك.

المثال التالي يستخدم [SlideUtil.getAllTextFrames](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/slideutil/#getAllTextFrames-com.aspose.slides.IPresentation-boolean-) للتكرار عبر إطارات النص في عرض تقديمي. بالنسبة للأشكال، يُظهر اسم الشكل، ونوعه في وقت تشغيل Java، والشريحة المحتوية. بالنسبة لخلايا الجدول، يُظهر إحداثيات العمود والصف (بدءًا من الصفر) والشريحة المحتوية.

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

لمحتوى SmartArt، كرر عبر الأشكال في [ISmartArtNode.getShapes](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ismartartnode/#getShapes--) وادخل إلى كل [ISmartArtShape.getTextFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ismartartshape/#getTextFrame--). يمكن تتبع إطار النص إلى الشكل المرتبط عبر [ITextFrame.getParentShape](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/itextframe/#getParentShape--)، بينما تُعيد [ITextFrame.getParentCell](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/itextframe/#getParentCell--) `null`. لذلك يتعامل فرع الشكل في المثال أيضًا مع النص من عقد SmartArt.

## **جمع معلومات المطابقة باستخدام رد النداء**

نفّذ [IFindResultCallback](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ifindresultcallback/) لتلقي إشعار لكل مطابقة. توفر طريقة [IFindResultCallback.foundResult](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ifindresultcallback/#foundResult-com.aspose.slides.ITextFrame-java.lang.String-java.lang.String-int-) إطار النص ذو الصلة، والنص المصدر، والنص المتطابق، وموقع المطابقة.

لا تستقبل رد النداء رقم الشريحة مباشرة. يستنتج التنفيذ أدناه الرقم من الشريحة الأم ويعالج أيضًا النص الموجود في ملاحظات الشريحة. يسمح `Integer` القابل للخطأ بتوحيد نموذج النتيجة لتمثيل النص المرتبط بأنواع شرائح أخرى.

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

في عمليات الاستبدال، يحتوي `foundText` على النص المتطابق الأصلي، لذا يمكن لرد النداء تسجيل المصطلحات التي تم استبدالها بدقة.

## **تظليل النص**

استخدم طريقة [ITextFrame.highlightText](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) لتظليل مطابقات النص الحرفي في إطار نص. مرّر [TextSearchOptions](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/textsearchoptions/) للتحكم في البحث ومرّر رد نداء لتجميع تفاصيل المطابقة.

يوضح مثال الشيفرة أدناه تظليل جميع مرات ظهور الأحرف **"try"** ثم تظليل الكلمة الكاملة **"to"** فقط. كلا البحثين يبلغان عن نتائجهما إلى نفس رد النداء.

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

    // تظليل كل ظهور لكلمة "try" في إطار النص.
    shape.getTextFrame().highlightText("try", substringHighlightColor, substringSearchOptions, callback);

    TextSearchOptions wholeWordSearchOptions = new TextSearchOptions();
    wholeWordSearchOptions.setWholeWordsOnly(true);
    wholeWordSearchOptions.setCaseSensitive(false);
    int wholeWordHighlightColor = Color.rgb(238, 130, 238);

    // تظليل الكلمة الكاملة "to" فقط.
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

## **تظليل النص باستخدام تعبيرات نمطية**

طريقة [ITextFrame.highlightRegex](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-) تضع تظليلًا على مطابقة النص التي يجدها تعبير نمطي في إطار نص.

الشيفرة التالية تظلل جميع الكلمات التي تحتوي على سبعة أحرف أو أكثر وتجمع كل مطابقة:

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

## **تظليل النص عبر عرض تقديمي**

استخدم [IPresentation.highlightText](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipresentation/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) و[IPresentation.highlightRegex](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipresentation/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-) للبحث في جميع إطارات النص القابلة للتطبيق في عرض تقديمي. المثال التالي يظلل مصطلحًا حرفيًا وجميع عناوين البريد الإلكتروني مع الحفاظ على مجموعات نتائج منفصلة لكل بحث.

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

استخدم [ITextFrame.replaceText](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) للنص الحرفي و[ITextFrame.replaceRegex](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) للاستبدال القائم على نمط. تقوم هذه الأساليب بتحديث النص المتطابق داخل إطار النص الحالي، مما يحافظ على تنسيق الجزء المحيط بدلاً من إعادة بناء إطار النص من سلسلة عادية.

المثال التالي يوحّد متغير تهجئة ثم يستبدل تسميات الإصدارات. يسجل نفس رد النداء المصطلحات الأصلية التي طابقها كل من العمليتين.

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

إذا امتد مطابقة عبر أجزاء ذات تنسيق مختلف، راجع الناتج لتأكيد أي تنسيق يجب أن يُطبق على النص المستبدل.

## **استبدال النص عبر عرض تقديمي**

استخدم [IPresentation.replaceText](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipresentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) و[IPresentation.replaceRegex](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipresentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) لتطبيق نفس العمليات عبر العرض التقديمي. هذا مفيد لتنظيف القالب، وتحديث المصطلحات، وإزالة المعلومات الحساسة.

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

نظرًا لأن كل نتيجة تخزن رقم الشريحة وإطار النص، يمكن للتطبيقات تجميع المطابقات للتدقيق أو التقارير أو سير عمل المراجعة. المثال التالي يجمع النتائج المجمّعة أولًا حسب الشريحة ثم حسب إطار النص:

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

## **الأسئلة المتكررة**

**كيف يمكنني البحث في مربع نص واحد فقط بدلاً من العرض التقديمي بأكمله؟**

احصل على إطار النص الخاص بالشكل واستدعِ [ITextFrame.highlightText](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-)، [ITextFrame.highlightRegex](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-)، [ITextFrame.replaceText](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-)، أو [ITextFrame.replaceRegex](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) على ذلك الإطار. تُعالج طرق مستوى العرض التقديمي جميع إطارات النص القابلة للتطبيق بدلاً من ذلك.

**كيف يمكنني مطابقة الكلمات الكاملة مع الحالة الصحيحة للأحرف؟**

قم بتعيين [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) و[TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) إلى `true`، ومرّر الخيارات إلى طريقة تظليل أو استبدال النص الحرفي. بالنسبة للتعبيرات النمطية، عرّف حدود الكلمات وحساسية الحالة في Java `Pattern` نفسه.

**هل يمكن أن تشمل عملية البحث والاستبدال النص الموجود في ملاحظات الشرائح؟**

نعم. عيّن [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) إلى `true` عند استخدام عملية نص حرفي على مستوى العرض التقديمي. تقوم تنفيذية رد النداء الموضحة أعلاه بربط مطابقة في شريحة ملاحظات برقم الشريحة الأم.

**كيف يمكنني إنشاء تقرير دون مسح العرض التقديمي مرة ثانية؟**

مرّر تنفيذًا لـ [IFindResultCallback](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ifindresultcallback/) إلى عملية التظليل أو الاستبدال. يتلقى رد النداء كل مطابقة أثناء تشغيل العملية، بحيث يمكن للتطبيق تخزين النص المصدر، والنص المتطابق، والموقع، وإطار النص، ورقم الشريحة المستنتج لتجميعه لاحقًا أو تصديره.

**هل يحافظ استبدال النص على تنسيقه؟**

تُعيد كل من [ITextFrame.replaceText](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) و[ITextFrame.replaceRegex](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) تعديل النص المتطابق داخل إطار النص الحالي وتحتفظ بتنسيق الجزء المحيط. إذا امتدت مطابقة عبر أجزاء ذات تنسيقات مختلفة، فافحص النتيجة للتأكد من أن الاستبدال يستخدم النمط المطلوب.