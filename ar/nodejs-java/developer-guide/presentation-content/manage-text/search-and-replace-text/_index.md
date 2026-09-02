---
title: بحث واستبدال النص في عروض PowerPoint التقديمية باستخدام JavaScript
linktitle: بحث واستبدال النص
type: docs
weight: 55
url: /ar/nodejs-java/search-and-replace-text/
keywords:
- بحث النص
- تظليل النص
- استبدال النص
- تعبير نمطي
- رد نداء النتيجة
- إطار النص
- تقرير التدقيق
- PowerPoint
- OpenDocument
- عرض تقديمي
- Node.js
- JavaScript
- Aspose.Slides
description: "بحث وتظليل واستبدال النص في عروض PowerPoint التقديمية مع جمع كل تطابق باستخدام Aspose.Slides لـ Node.js عبر Java."
---
## **نظرة عامة**

يمكن لـ Aspose.Slides for Node.js عبر Java البحث عن النص وتظليله واستبداله داخل إطار نصي فردي أو عبر عرض تقديمي كامل. يمكن لكل عملية أيضًا إعلام التطبيق بكل تطابق عبر رد نداء للنتيجة. يتيح ذلك تحديث العرض وإنشاء سجل تدقيق يحتوي على النص المتطابق وسياقه وموقعه وإطار النص ورقم الشريحة.

تُعد هذه القدرات مفيدة للمراجعة، والإزالة، وفحص المصطلحات، وتنظيف القوالب، وتدفقات العمل الآلية للتقارير.

في الأمثلة الأولى أدناه، نستخدم ملفًا اسمه "sample.pptx"، يحتوي على صندوق نص واحد في الشريحة الأولى بالنص التالي:

![نص تجريبي](sample_text.png)

## **اختر نطاق البحث**

استخدم الأساليب على [TextFrame](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/textframe/) لتقييد العملية بإطار نص واحد. استخدم الأساليب على [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/) لمعالجة جميع النصوص القابلة للتطبيق في العرض التقديمي.

| العملية | إطار نص واحد | العرض الكامل |
|---|---|---|
| تظليل النص الحرفي | [TextFrame.highlightText](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/textframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [Presentation.highlightText](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| تظليل تطابقات التعبير النمطي | [TextFrame.highlightRegex](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/textframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) | [Presentation.highlightRegex](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) |
| استبدال النص الحرفي | [TextFrame.replaceText](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [Presentation.replaceText](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| استبدال تطابقات التعبير النمطي | [TextFrame.replaceRegex](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) | [Presentation.replaceRegex](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) |

## **تكوين مطابقة النص**

للعمليات الحرفية، استخدم [TextSearchOptions](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/textsearchoptions/) للتحكم في المطابقة:

- [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) يحدد المطابقات لتكون كلمات كاملة.
- [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) يتحكم فيما إذا كان يجب مطابقة حالة الأحرف.
- [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) يتضمن ملاحظات الشرائح في عمليات البحث والاستبدال والتظليل على مستوى العرض التقديمي.

تستخدم عمليات التعبير النمطي Java `Pattern`، لذلك تُحدد قواعد المطابقة مثل حساسية الحالة وحدود الكلمات بواسطة التعبير وعلاماته.

## **جمع معلومات التطابق باستخدام رد نداء**

أنشئ وكيل Java لرد نداء النتيجة لتلقي إشعار بكل تطابق. تستقبل دالة الوكيل إطار النص المرتبط، النص الأصلي، النص المتطابق، وموقع التطابق.

لا يتلقى رد النداء رقم الشريحة مباشرة. يحصل التطبيق أدناه على ذلك عبر [TextFrame.getSlide](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/textframe/#getSlide--), [Slide.getSlideNumber](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/slide/#getSlideNumber--), و[NotesSlide.getParentSlide](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/notesslide/#getParentSlide--). كما يتعامل مع النص الموجود في ملاحظات الشرائح.

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

بالنسبة لعمليات الاستبدال، يحتوي `foundText` على النص الأصلي المتطابق، وبالتالي يمكن لرد النداء تسجيل المصطلحات التي تم استبدالها بدقة.

## **تظليل النص**

استخدم طريقة [TextFrame.highlightText](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/textframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) لتظليل التطابقات الحرفية داخل إطار نص. مرّر [TextSearchOptions](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/textsearchoptions/) للتحكم في البحث.

يوضح مثال الشيفرة أدناه تظليل جميع تكرارات الأحرف **"try"** ثم تظليل الكلمة الكاملة **"to"** فقط.

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

    // تظليل كل ظهور لكلمة "try" في إطار النص.
    shape.getTextFrame().highlightText(
        "try", substringHighlightColor, substringSearchOptions, null);

    const wholeWordSearchOptions = new aspose.slides.TextSearchOptions();
    wholeWordSearchOptions.setWholeWordsOnly(true);
    wholeWordSearchOptions.setCaseSensitive(false);
    const wholeWordHighlightColor = java.getStaticFieldValue("java.awt.Color", "MAGENTA");

    // تظليل الكلمة الكاملة فقط "to".
    shape.getTextFrame().highlightText(
        "to", wholeWordHighlightColor, wholeWordSearchOptions, null);

    presentation.save("highlighted_text.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![النص المظلَل](highlighted_text.png)

## **تظليل النص باستخدام التعبيرات النمطية**

طريقة [TextFrame.highlightRegex](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/textframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) تظلل التطابقات النصية التي تم العثور عليها بواسطة تعبير نمطي داخل إطار نص.

الشيفرة التالية تظلل جميع الكلمات التي تحتوي على سبعة أحرف أو أكثر:

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

![النص المظلَل باستخدام التعبير النمطي](highlighted_text_using_regex.png)

## **تظليل النص عبر عرض تقديمي**

استخدم [Presentation.highlightText](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) و[Presentation.highlightRegex](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) للبحث في جميع إطارات النص القابلة للتطبيق في عرض تقديمي. يوضح المثال التالي تظليل مصطلح حرفي وجميع عناوين البريد الإلكتروني:

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

## **استبدال النص في إطار نص**

استخدم [TextFrame.replaceText](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) للنص الحرفي و[TextFrame.replaceRegex](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) للاستبدال القائم على الأنماط. تقوم هذه الطرق بتحديث النص المتطابق داخل إطار النص الموجود، مع الحفاظ على تنسيق الجزء المحيط بدلاً من إعادة بناء إطار النص من سلسلة عادية.

يوضح المثال التالي توحيد شكل تهجئة ثم استبدال تسميات الإصدارات:

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

إذا كان أحد التطابقات يغطي أقسامًا بتنسيق مختلف، يرجى مراجعة النتيجة للتأكد من أي تنسيق يجب تطبيقه على النص المستبدَل.

## **استبدال النص عبر عرض تقديمي**

استخدم [Presentation.replaceText](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) و[Presentation.replaceRegex](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) لتطبيق نفس العمليات عبر العرض التقديمي. هذا مفيد لتنظيف القوالب وتحديث المصطلحات والإزالة.

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

## **تجميع التطابقات للتقارير**

نظرًا لأن كل نتيجة مُجَمعَة تخزن رقم الشريحة وإطار النص، يمكن للتطبيقات تجميع التطابقات للتدقيق أو التقارير أو سير عمل المراجعة. يوضح المثال التالي تجميع النتائج أولًا حسب الشريحة ثم حسب إطار النص:

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

## **الأسئلة المتكررة**

**كيف يمكنني البحث فقط في صندوق نص واحد بدلاً من العرض التقديمي كاملًا؟**

احصل على إطار النص للشكل واستدعِ [TextFrame.highlightText](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/textframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), [TextFrame.highlightRegex](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/textframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-), [TextFrame.replaceText](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), أو [TextFrame.replaceRegex](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) على ذلك الإطار. تقوم الأساليب على مستوى العرض التقديمي بمعالجة جميع إطارات النص القابلة للتطبيق بدلاً من ذلك.

**كيف يمكنني مطابقة الكلمات الكاملة مع الحالة الأحرف الصحيحة؟**

قم بتعيين [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) و[TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) إلى `true`، ومرّر الخيارات إلى طريقة تظليل أو استبدال النص الحرفي. بالنسبة للتعبيرات النمطية، عرّف حدود الكلمات وحساسية الحالة داخل `Pattern` في Java نفسها.

**هل يمكن أن تشمل البحث والاستبدال النص الموجود في ملاحظات الشريحة؟**

نعم. قم بتعيين [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) إلى `true` عند استخدام عملية نص حرفي على مستوى العرض التقديمي. يقوم تنفيذ رد النداء المعروض أعلاه بربط تطابق في شريحة ملاحظات برقم الشريحة الأصلية.

**كيف يمكنني إنشاء تقرير دون فحص العرض التقديمي مرة ثانية؟**

مرّر وكيل رد نداء نتيجة Java إلى عملية التظليل أو الاستبدال. يتلقى رد النداء كل تطابق أثناء تنفيذ العملية، لذا يمكن للتطبيق تخزين النص الأصلي، والنص المتطابق، والموقع، وإطار النص، ورقم الشريحة المستمد لتجميعه أو تصديره لاحقًا.

**هل يحافظ استبدال النص على تنسيقه؟**

[TextFrame.replaceText](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) و[TextFrame.replaceRegex](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) يعدلان النص المتطابق داخل إطار النص الموجود ويحتفظان بتنسيق الجزء المحيط. إذا كان التطابق يغطي أقسامًا بتنسيق مختلف، فافحص النتيجة للتأكد من أن الاستبدال يستخدم النمط المطلوب.