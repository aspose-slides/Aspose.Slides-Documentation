---
title: بحث واستبدال النص في عروض PowerPoint التقديمية باستخدام PHP
linktitle: بحث واستبدال النص
type: docs
weight: 55
url: /ar/php-java/search-and-replace-text/
keywords:
- بحث النص
- تمييز النص
- استبدال النص
- تعبير نمطي
- استدعاء النتيجة
- إطار النص
- تقرير تدقيق
- PowerPoint
- OpenDocument
- عرض تقديمي
- PHP
- Aspose.Slides
description: "بحث، تمييز، واستبدال النص في عروض PowerPoint التقديمية مع جمع كل تطابق باستخدام Aspose.Slides for PHP عبر Java."
---
## **نظرة عامة**

Aspose.Slides for PHP via Java يمكنه البحث وتحديد وإستبدال النص في إطار نص فردي أو عبر عرض تقديمي كامل. كل عملية يمكنها أيضًا إبلاغ التطبيق عن كل تطابق عبر رد نداء للنتيجة. هذا يتيح إمكانية تحديث العرض التقديمي وبنفس الوقت إنشاء سجل تدقيق يحتوي على النص المتطابق وسياقه وموقعه وإطار النص ورقم الشريحة.

هذه الإمكانات مفيدة للمراجعة، الحجب، فحص المصطلحات، تنظيف القوالب، وسير عمل تقارير مؤتمتة.

في الأمثلة الأولى أدناه، نستخدم ملفًا باسم "sample.pptx"، يحتوي على مربع نص واحد في الشريحة الأولى بالنص التالي:

![نص عينة](sample_text.png)

## **اختيار نطاق البحث**

استخدم الأساليب على [TextFrame](https://reference.aspose.com/slides/ar/php-java/aspose.slides/textframe/) لتقييد العملية على إطار نص واحد. استخدم الأساليب على [Presentation](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/) لمعالجة كل النص القابل للتطبيق في العرض التقديمي.

| العملية | إطار نص واحد | العرض التقديمي بالكامل |
|---|---|---|
| تمييز النص الحرفي | [TextFrame::highlightText](https://reference.aspose.com/slides/ar/php-java/aspose.slides/textframe/#highlightText) | [Presentation::highlightText](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/#highlightText) |
| تمييز تطابقات التعبير النمطي | [TextFrame::highlightRegex](https://reference.aspose.com/slides/ar/php-java/aspose.slides/textframe/#highlightRegex) | [Presentation::highlightRegex](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/#highlightRegex) |
| استبدال النص الحرفي | [TextFrame::replaceText](https://reference.aspose.com/slides/ar/php-java/aspose.slides/textframe/#replaceText) | [Presentation::replaceText](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/#replaceText) |
| استبدال تطابقات التعبير النمطي | [TextFrame::replaceRegex](https://reference.aspose.com/slides/ar/php-java/aspose.slides/textframe/#replaceRegex) | [Presentation::replaceRegex](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/#replaceRegex) |

## **تكوين مطابقة النص**

لعمليات النص الحرفي، استخدم [TextSearchOptions](https://reference.aspose.com/slides/ar/php-java/aspose.slides/textsearchoptions/) للتحكم في المطابقة:

- [TextSearchOptions::setWholeWordsOnly](https://reference.aspose.com/slides/ar/php-java/aspose.slides/textsearchoptions/#setWholeWordsOnly) يحد من التطابقات لتشمل كلمات كاملة.
- [TextSearchOptions::setCaseSensitive](https://reference.aspose.com/slides/ar/php-java/aspose.slides/textsearchoptions/#setCaseSensitive) يتحكم فيما إذا كان يجب مطابقة حالة الأحرف.
- [TextSearchOptions::setIncludeNotes](https://reference.aspose.com/slides/ar/php-java/aspose.slides/textsearchoptions/#setIncludeNotes) يشمل ملاحظات الشرائح في عمليات البحث والاستبدال والتمييز على مستوى العرض التقديمي.

عمليات التعبير النمطي تستخدم Java `Pattern`، لذا فإن قواعد المطابقة مثل حساسية حالة الأحرف وحدود الكلمات تُحدد بواسطة التعبير والعلمات الخاصة به.

## **جمع معلومات التطابق باستخدام رد نداء**

مرّر رد نداء Java وكيل إلى طريقة تمييز أو استبدال لتلقي إشعار لكل تطابق. تتلقى طريقة رد النداء إطار النص المتعلق، النص الأصلي، النص المتطابق، وموقع التطابق.

رد النداء لا يتلقى رقم الشريحة مباشرة. التنفيذ أدناه يستخرجه من الشريحة الأصلية ويتعامل أيضًا مع النص الموجود في ملاحظات الشرائح. يستخدم مصفوفة النتيجة `null` عندما يكون النص مرتبطًا بنوع شريحة آخر.

```php
class TextSearchCallback {
    private $results = [];

    public function getResults() {
        return $this->results;
    }

    public function foundResult($textFrame, $sourceText, $foundText, $textPosition) {
        $slideNumber = $this->getSlideNumber($textFrame);
        $this->results[] = [
            "textFrame" => $textFrame,
            "sourceText" => java_values($sourceText),
            "foundText" => java_values($foundText),
            "textPosition" => java_values($textPosition),
            "slideNumber" => $slideNumber
        ];
    }

    private function getSlideNumber($textFrame) {
        $parentSlide = $textFrame->getSlide();
        if (java_is_null($parentSlide)) {
            return null;
        }

        $parentSlideClass = $parentSlide->getClass();
        $classNameValue = $parentSlideClass->getName();
        $className = java_values($classNameValue);

        if ($className === "com.aspose.slides.Slide") {
            $slideNumber = $parentSlide->getSlideNumber();
            return java_values($slideNumber);
        }

        if ($className === "com.aspose.slides.NotesSlide") {
            $slide = $parentSlide->getParentSlide();
            $slideNumber = $slide->getSlideNumber();
            return java_values($slideNumber);
        }

        return null;
    }
}
```

أنشئ وكيلًا لهذا الكائن PHP قبل تمريره إلى عملية:

```php
$callbackHandler = new TextSearchCallback();
$callbackInterface = java("com.aspose.slides.IFindResultCallback");
$callback = java_closure(
    $callbackHandler,
    null,
    $callbackInterface
);
```

لعمليات الاستبدال، يحتوي `foundText` على النص المتطابق الأصلي، لذا يمكن لرد النداء تسجيل المصطلحات التي تم استبدالها بدقة.

## **تمييز النص**

استخدم طريقة [TextFrame::highlightText](https://reference.aspose.com/slides/ar/php-java/aspose.slides/textframe/#highlightText) لتحديد تطابقات النص الحرفي في إطار نص. مرّر [TextSearchOptions](https://reference.aspose.com/slides/ar/php-java/aspose.slides/textsearchoptions/) للتحكم في البحث.

الكود أدناه يحدد كل ما يظهر من الأحرف **"try"** ثم يحدد فقط الكلمة الكاملة **"to"**.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);
    $callbackHandler = new TextSearchCallback();
    $callbackInterface = java("com.aspose.slides.IFindResultCallback");
    $callback = java_closure(
        $callbackHandler,
        null,
        $callbackInterface
    );

    $substringSearchOptions = new TextSearchOptions();
    $substringSearchOptions->setCaseSensitive(false);
    $substringHighlightColor = new Java("java.awt.Color", 173, 216, 230);

    // تمييز كل تكرار لكلمة "try" داخل إطار النص.
    $shape->getTextFrame()->highlightText(
        "try",
        $substringHighlightColor,
        $substringSearchOptions,
        $callback
    );

    $wholeWordSearchOptions = new TextSearchOptions();
    $wholeWordSearchOptions->setWholeWordsOnly(true);
    $wholeWordSearchOptions->setCaseSensitive(false);
    $wholeWordHighlightColor = new Java("java.awt.Color", 238, 130, 238);

    // تمييز الكلمة الكاملة "to" فقط.
    $shape->getTextFrame()->highlightText(
        "to",
        $wholeWordHighlightColor,
        $wholeWordSearchOptions,
        $callback
    );

    foreach ($callbackHandler->getResults() as $result) {
        echo(
            "Found '" . $result["foundText"] . "' at position " .
            $result["textPosition"] . " on slide " .
            $result["slideNumber"] . ".\n"
        );
    }

    $presentation->save("highlighted_text.pptx", SaveFormat::Pptx);
}
finally {
    $presentation->dispose();
}
```

النتيجة:

![النص المميز](highlighted_text.png)

## **تمييز النص باستخدام التعبيرات النمطية**

طريقة [TextFrame::highlightRegex](https://reference.aspose.com/slides/ar/php-java/aspose.slides/textframe/#highlightRegex) تميز تطابقات النص التي يتم العثور عليها بواسطة تعبير نمطي في إطار نص.

الكود التالي يميز كل الكلمات التي تحتوي على سبعة أحرف أو أكثر:

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);
    $regex = java("java.util.regex.Pattern")->compile("\\b[^\\s]{7,}\\b");
    $highlightColor = java("java.awt.Color")->YELLOW;

    $shape->getTextFrame()->highlightRegex($regex, $highlightColor, null);

    $presentation->save("highlighted_text_using_regex.pptx", SaveFormat::Pptx);
}
finally {
    $presentation->dispose();
}
```

النتيجة:

![النص المميز باستخدام التعبير النمطي](highlighted_text_using_regex.png)

## **تمييز النص عبر العرض التقديمي**

استخدم [Presentation::highlightText](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/#highlightText) و[Presentation::highlightRegex](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/#highlightRegex) للبحث في جميع إطارات النص القابلة للتطبيق في العرض التقديمي. المثال التالي يحدد مصطلحًا حرفيًا وكل عناوين البريد الإلكتروني:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $searchOptions = new TextSearchOptions();
    $searchOptions->setWholeWordsOnly(true);
    $searchOptions->setCaseSensitive(false);
    $termHighlightColor = java("java.awt.Color")->ORANGE;

    $presentation->highlightText(
        "confidential",
        $termHighlightColor,
        $searchOptions,
        null
    );

    $patternClass = java("java.util.regex.Pattern");
    $emailPattern = "\\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\\.[A-Z]{2,}\\b";
    $emailRegex = $patternClass->compile(
        $emailPattern,
        $patternClass->CASE_INSENSITIVE
    );
    $emailHighlightColor = java("java.awt.Color")->YELLOW;

    $presentation->highlightRegex($emailRegex, $emailHighlightColor, null);
    $presentation->save("highlighted_presentation.pptx", SaveFormat::Pptx);
}
finally {
    $presentation->dispose();
}
```

## **استبدال النص في إطار نص**

استخدم [TextFrame::replaceText](https://reference.aspose.com/slides/ar/php-java/aspose.slides/textframe/#replaceText) للنص الحرفي و[TextFrame::replaceRegex](https://reference.aspose.com/slides/ar/php-java/aspose.slides/textframe/#replaceRegex) للاستبدال القائم على النمط. تقوم هذه الطرق بتحديث النص المتطابق داخل إطار النص الحالي، مما يحافظ على تنسيق الجزء المحيط بدلاً من إعادة بناء إطار النص من سلسلة عادية.

المثال التالي موحد صيغة تهجئة ثم يستبدل تسميات الإصدارات:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    $searchOptions = new TextSearchOptions();
    $searchOptions->setWholeWordsOnly(true);
    $searchOptions->setCaseSensitive(false);

    $shape->getTextFrame()->replaceText(
        "colour",
        "color",
        $searchOptions,
        null
    );

    $patternClass = java("java.util.regex.Pattern");
    $versionPattern = "\\bv\\d+(?:\\.\\d+)*\\b";
    $versionRegex = $patternClass->compile(
        $versionPattern,
        $patternClass->CASE_INSENSITIVE
    );
    $shape->getTextFrame()->replaceRegex(
        $versionRegex,
        "current version",
        null
    );

    $presentation->save("updated_text_frame.pptx", SaveFormat::Pptx);
}
finally {
    $presentation->dispose();
}
```

إذا امتد تطابق واحد على أجزاء ذات تنسيقات مختلفة، راجع المخرجات لتأكيد أي تنسيق ينبغي تطبيقه على النص المستبدل.

## **استبدال النص عبر العرض التقديمي**

استخدم [Presentation::replaceText](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/#replaceText) و[Presentation::replaceRegex](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/#replaceRegex) لتطبيق نفس العمليات عبر العرض التقديمي. هذا مفيد لتنظيف القوالب، تحديث المصطلحات، والحجب.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $searchOptions = new TextSearchOptions();
    $searchOptions->setWholeWordsOnly(true);
    $searchOptions->setCaseSensitive(true);

    $presentation->replaceText(
        "Contoso",
        "Example Corp",
        $searchOptions,
        null
    );

    $accountNumberRegex = java("java.util.regex.Pattern")->compile(
        "\\bACCT-\\d{6}\\b"
    );
    $presentation->replaceRegex(
        $accountNumberRegex,
        "ACCT-REDACTED",
        null
    );

    $presentation->save("updated_presentation.pptx", SaveFormat::Pptx);
}
finally {
    $presentation->dispose();
}
```

## **تجميع التطابقات للتقارير**

نظرًا لأن كل نتيجة تخزن رقم الشريحة وإطار النص، يمكن للتطبيقات تجميع التطابقات للتدقيق أو التقارير أو سير العمل المراجعي. المثال التالي يجمع النتائج المجمعة أولاً حسب الشريحة ثم حسب إطار النص:

```php
$matchesBySlide = [];
$systemClass = java("java.lang.System");

foreach ($callbackHandler->getResults() as $result) {
    $slideNumber = $result["slideNumber"];
    $slideLabel = $slideNumber === null ? "Other" : (string) $slideNumber;
    $textFrame = $result["textFrame"];
    $textFrameHash = $systemClass->identityHashCode($textFrame);
    $textFrameKey = (string) java_values($textFrameHash);

    if (!isset($matchesBySlide[$slideLabel])) {
        $matchesBySlide[$slideLabel] = [];
    }

    if (!isset($matchesBySlide[$slideLabel][$textFrameKey])) {
        $matchesBySlide[$slideLabel][$textFrameKey] = [
            "textFrame" => $textFrame,
            "matches" => []
        ];
    }

    $matchesBySlide[$slideLabel][$textFrameKey]["matches"][] = $result;
}

foreach ($matchesBySlide as $slideLabel => $textFrameGroups) {
    echo("Slide: " . $slideLabel . "\n");

    foreach ($textFrameGroups as $textFrameGroup) {
        $textFrame = $textFrameGroup["textFrame"];
        echo("  Text frame: " . $textFrame->getText() . "\n");

        foreach ($textFrameGroup["matches"] as $result) {
            echo(
                "    '" . $result["foundText"] . "' at position " .
                $result["textPosition"] . "; context: '" .
                $result["sourceText"] . "'\n"
            );
        }
    }
}
```

## **الأسئلة المتكررة**

**كيف يمكنني البحث في مربع نص واحد فقط بدلًا من كامل العرض التقديمي؟**

احصل على إطار النص الخاص بالشكل واستدعِ [TextFrame::highlightText](https://reference.aspose.com/slides/ar/php-java/aspose.slides/textframe/#highlightText)، [TextFrame::highlightRegex](https://reference.aspose.com/slides/ar/php-java/aspose.slides/textframe/#highlightRegex)، [TextFrame::replaceText](https://reference.aspose.com/slides/ar/php-java/aspose.slides/textframe/#replaceText) أو [TextFrame::replaceRegex](https://reference.aspose.com/slides/ar/php-java/aspose.slides/textframe/#replaceRegex) على ذلك الإطار. الأساليب على مستوى العرض التقديمي تعالج جميع إطارات النص القابلة للتطبيق بدلًا من ذلك.

**كيف يمكنني مطابقة الكلمات الكاملة مع الأحرف الكبيرة الصحيحة؟**

اضبط [TextSearchOptions::setWholeWordsOnly](https://reference.aspose.com/slides/ar/php-java/aspose.slides/textsearchoptions/#setWholeWordsOnly) و[TextSearchOptions::setCaseSensitive](https://reference.aspose.com/slides/ar/php-java/aspose.slides/textsearchoptions/#setCaseSensitive) على `true`، ومرّر الخيارات إلى طريقة تمييز أو استبدال نص حرفي. بالنسبة للتعبيرات النمطية، عرّف حدود الكلمات وحساسية الحالة في Java `Pattern` نفسه.

**هل يمكن للبحث والاستبدال أن يشمل نصًا في ملاحظات الشريحة؟**

نعم. اضبط [TextSearchOptions::setIncludeNotes](https://reference.aspose.com/slides/ar/php-java/aspose.slides/textsearchoptions/#setIncludeNotes) على `true` عند استخدام عملية نص حرفي على مستوى العرض التقديمي.

**كيف يمكنني إنشاء تقرير دون فحص العرض التقديمي مرة ثانية؟**

مرّر رد نداء Java وكيل إلى عملية التمييز أو الاستبدال. سيتلقى كل تطابق أثناء تشغيل العملية، وبالتالي يمكن للتطبيق تخزين النص الأصلي، النص المتطابق، الموقع، إطار النص، ورقم الشريحة المستنتج للاستخدام لاحقًا في التجميع أو التصدير.

**هل يحافظ استبدال النص على تنسيقه؟**

[TextFrame::replaceText](https://reference.aspose.com/slides/ar/php-java/aspose.slides/textframe/#replaceText) و[TextFrame::replaceRegex](https://reference.aspose.com/slides/ar/php-java/aspose.slides/textframe/#replaceRegex) يغيران النص المتطابق داخل إطار النص الحالي ويحتفظان بتنسيق الجزء المحيط. إذا امتد تطابق إلى أجزاء ذات تنسيقات مختلفة، افحص النتيجة للتأكد من أن الاستبدال يستخدم النمط المطلوب.