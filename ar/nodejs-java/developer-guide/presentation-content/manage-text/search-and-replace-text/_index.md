---
title: البحث واستبدال النص في عروض PowerPoint التقديمية باستخدام JavaScript
linktitle: البحث واستبدال النص
type: docs
weight: 55
url: /ar/nodejs-java/search-and-replace-text/
keywords:
- بحث نص
- تظليل النص
- استبدال النص
- تعبير نمطي
- رد ناتج
- إطار النص
- تقرير تدقيق
- PowerPoint
- OpenDocument
- عرض تقديمي
- Node.js
- JavaScript
- Aspose.Slides
description: "ابحث، ظلل، واستبدل النص في عروض PowerPoint التقديمية مع جمع كل تطابق باستخدام Aspose.Slides للـ Node.js عبر Java."
---
## **نظرة عامة**

يمكن لـ Aspose.Slides for Node.js عبر Java البحث عن النص وتظليله واستبداله في إطار نص فردي أو عبر العرض التقديمي بالكامل. يمكن لكل عملية أيضًا إخطار التطبيق بكل تطابق عبر رد ناتج. هذا يجعل من الممكن تحديث العرض التقديمي وإنشاء سجل تدقيق يحتوي على النص المتطابق، وسياقه، وموقعه، وإطار النص، ورقم الشريحة.

تُعد هذه القدرات مفيدة للمراجعة، وحذف المعلومات الحساسة، والتحقق من المصطلحات، وتنظيف القوالب، وتدفقات عمل التقارير الآلية.

في الأمثلة الأولى أدناه، نستخدم ملفًا اسمه "sample.pptx"، والذي يحتوي على صندوق نص واحد في الشريحة الأولى بالنص التالي:

![نص تجريبي](sample_text.png)

## **اختر نطاق البحث**

استخدم الطرق على [TextFrame](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/textframe/) لتقييد العملية على إطار نص واحد. استخدم الطرق على [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/) لمعالجة جميع النصوص القابلة للتطبيق في العرض التقديمي.

| العملية | إطار نص واحد | العرض التقديمي بالكامل |
|---|---|---|
| تسليط الضوء على النص الحرفي | [TextFrame.highlightText](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/textframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [Presentation.highlightText](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| تسليط الضوء على مطابقتات التعبير النمطي | [TextFrame.highlightRegex](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/textframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) | [Presentation.highlightRegex](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) |
| استبدال النص الحرفي | [TextFrame.replaceText](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [Presentation.replaceText](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| استبدال مطابقتات التعبير النمطي | [TextFrame.replaceRegex](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) | [Presentation.replaceRegex](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) |

## **تكوين مطابقة النص**

لعمليات النص الحرفي، استخدم [TextSearchOptions](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/textsearchoptions/) للتحكم في المطابقة:

- [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) يقتصر على المطابقات للكلمات الكاملة.
- [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) يتحكم فيما إذا كان يجب تطابق حالة الأحرف.
- [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) يضمن تضمين ملاحظات الشرائح في عمليات البحث والاستبدال وتظليل المستوى العرض التقديمي.

تستخدم عمليات التعبير النمطي جافا `Pattern`، لذا يتم تعريف قواعد المطابقة مثل حساسية الحالة وحدود الكلمات داخل التعبير وعلاماته.

## **تحديد مالك إطار النص**

غالبًا ما تتلقى تدفقات عمل معالجة النص العامة كائنًا من نوع [TextFrame](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/textframe/) أثناء البحث أو الاستبدال أو التحقق أو التصدير. استخدم [TextFrame.getParentShape](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/textframe/#getParentShape--) و[TextFrame.getParentCell](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/textframe/#getParentCell--) لتحديد الكائن في العرض التقديمي الذي يمتلك إطار النص.

القيم المتوقعة تعتمد على المالك:

| مالك إطار النص | `getParentShape` | `getParentCell` |
|---|---|---|
| شكل AutoShape أو شكل آخر يحتوي على نص | المالك هو [Shape](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/shape/) | `null` |
| خلية جدول | `null` | المالك هو [Cell](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/cell/) |

كلا الطريقتين توفران تنقلًا للقراءة فقط. لا تحرك أيًا منهما إطار النص أو تغير مالكه. يجب على الشيفرة العامة فحص كلٍ من القيمتين للتحقق من كونها `null` ومعالجة احتمال عدم توافر أي مالك.

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

لمحتوى SmartArt، استعرض الأشكال في [SmartArtNode.getShapes](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/smartartnode/#getShapes--) واستخدم كل [SmartArtShape.getTextFrame](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/smartartshape/#getTextFrame--) للوصول إلى إطار النص. يمكن تتبع إطار النص إلى الشكل المرتبط عبر [TextFrame.getParentShape](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/textframe/#getParentShape--)، بينما [TextFrame.getParentCell](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/textframe/#getParentCell--) يُعيد `null`. لذلك يتعامل فرع الشكل في المثال أيضًا مع النص من عقد SmartArt.

## **جمع معلومات التطابق باستخدام رد نداء**

أنشئ وكيل جافا لرد النتيجة لتلقي إشعار عن كل تطابق. تتلقى دالة الوكيل إطار النص المرتبط، النص الأصلي، النص المتطابق، وموقع التطابق.

لا يتلقى رد النداء رقم الشريحة مباشرة. يشتق التنفيذ التالي الرقم عبر الشكل أو خلية الجدول التي يملكها إطار النص، باستخدام [TextFrame.getSlide](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/textframe/#getSlide--) كخيار احتياطي. كما يتعامل مع النص الموجود في ملاحظات الشرائح.

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

لعمليات الاستبدال، يحتوي `foundText` على النص الأصلي المتطابق، وبالتالي يمكن لرد النداء تسجيل المصطلحات التي تم استبدالها بدقة.

## **تسليط الضوء على النص**

استخدم طريقة [TextFrame.highlightText](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/textframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) لتسليط الضوء على تطابقات النص الحرفي في إطار نص. مرّر [TextSearchOptions](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/textsearchoptions/) للتحكم في البحث.

الكود التالي يسلط الضوء على جميع ظهورات الحرفين **"try"** ثم يسلط الضوء فقط على الكلمة الكاملة **"to"**.

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

    // تظليل الكلمة الكاملة "to" فقط.
    shape.getTextFrame().highlightText(
        "to", wholeWordHighlightColor, wholeWordSearchOptions, null);

    presentation.save("highlighted_text.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

النتيجة:

![النص المُظلل](highlighted_text.png)

## **تسليط الضوء على النص باستخدام تعبيرات نمطية**

طريقة [TextFrame.highlightRegex](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/textframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) تميز مطابقات النص التي يتم العثور عليها عبر تعبير نمطي في إطار نص.

الكود التالي يسلط الضوء على جميع الكلمات التي تحتوي على سبعة أحرف أو أكثر:

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

النتيجة:

![النص المُظلل باستخدام التعبير النمطي](highlighted_text_using_regex.png)

## **تسليط الضوء على النص عبر عرض تقديمي**

استخدم [Presentation.highlightText](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) و[Presentation.highlightRegex](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) للبحث في جميع أطر النص القابلة للتطبيق في العرض التقديمي. المثال التالي يسلط الضوء على مصطلح حرفي وجميع عناوين البريد الإلكتروني:

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

استخدم [TextFrame.replaceText](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) للنص الحرفي و[TextFrame.replaceRegex](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) للاستبدال القائم على نمط. تقوم هذه الطرق بتحديث النص المتطابق داخل إطار النص الحالي، مما يحافظ على تنسيق الجزء المحيط بدلاً من إعادة بناء إطار النص من سلسلة عادية.

المثال التالي يوحد صيغة كتابة بديلة ثم يستبدل علامات الإصدارات:

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

إذا امتد تطابق إلى أجزاء ذات تنسيقات مختلفة، راجع الناتج لتأكيد أي تنسيق يجب أن يُطبق على النص المستبدل.

## **استبدال النص عبر عرض تقديمي**

استخدم [Presentation.replaceText](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) و[Presentation.replaceRegex](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) لتطبيق العمليات نفسها عبر العرض التقديمي. هذا مفيد لتنظيف القوالب، وتحديث المصطلحات، وحذف المعلومات الحساسة.

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

## **تجميع المطابقات للتقارير**

نظرًا لأن كل نتيجة مجمعة تُخزن رقم الشريحة وإطار النص، يمكن للتطبيقات تجميع المطابقات للتدقيق أو التقارير أو عمليات المراجعة. المثال التالي يجمع النتائج أولاً حسب الشريحة ثم حسب إطار النص:

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

## **الأسئلة الشائعة**

**كيف يمكنني البحث في صندوق نص واحد فقط بدلاً من العرض التقديمي بالكامل؟**

احصل على إطار النص الخاص بالشكل واستدعِ [TextFrame.highlightText](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/textframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-)، [TextFrame.highlightRegex](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/textframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-)، [TextFrame.replaceText](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-)، أو [TextFrame.replaceRegex](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) على ذلك الإطار. طرق المستوى العرض التقديمي تعالج جميع أطر النص القابلة للتطبيق بدلاً من ذلك.

**كيف يمكنني مطابقة الكلمات الكاملة مع المحافظة على الحالة الصحيحة؟**

قم بتعيين [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) و[TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) إلى `true`، ومرّر الخيارات إلى طريقة تظليل أو استبدال النص الحرفي. بالنسبة للتعبيرات النمطية، عرّف حدود الكلمات وحساسية الحالة داخل `Pattern` نفسه.

**هل يمكن أن يشمل البحث والاستبدال النص الموجود في ملاحظات الشرائح؟**

نعم. قم بتعيين [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) إلى `true` عند استخدام عملية نص حرفي على مستوى العرض التقديمي. تنفيذ رد النداء الموضح أعلاه يربط مطابقة الموجودة في ملاحظة الشريحة برقم شريحة الأصل.

**كيف يمكنني إنشاء تقرير دون مسح العرض التقديمي مرة ثانية؟**

مرّر وكيل جافا لرد النتيجة إلى عملية التظليل أو الاستبدال. يتلقى رد النداء كل مطابقة أثناء تشغيل العملية، وبالتالي يمكن للتطبيق تخزين النص الأصلي، والنص المتطابق، والموقع، وإطار النص، ورقم الشريحة المستنبط لتجميعه أو تصديره لاحقًا.

**هل يحافظ استبدال النص على تنسيقه؟**

كل من [TextFrame.replaceText](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) و[TextFrame.replaceRegex](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) يعدلان النص المتطابق داخل إطار النص الحالي ويحتفظان بتنسيق الجزء المحيط. إذا امتد مطابقة إلى أجزاء ذات تنسيقات مختلفة، فافحص النتيجة لضمان أن الاستبدال يستخدم النمط المطلوب.