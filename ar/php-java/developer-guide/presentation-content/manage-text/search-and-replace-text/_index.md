---
title: بحث واستبدال النص في عروض PowerPoint التقديمية باستخدام PHP
linktitle: بحث واستبدال النص
type: docs
weight: 55
url: /ar/php-java/search-and-replace-text/
keywords:
- بحث نص
- تمييز نص
- استبدال نص
- تعبير نمطي
- نداء نتيجة
- إطار نص
- تقرير تدقيق
- PowerPoint
- OpenDocument
- عرض تقديمي
- PHP
- Aspose.Slides
description: "بحث وتمييز واستبدال النص في عروض PowerPoint التقديمية مع جمع كل مطابقة باستخدام Aspose.Slides for PHP via Java."
---
## **نظرة عامة**

Aspose.Slides for PHP via Java يمكنه البحث وتنسيق النص وإستبداله في إطار نص فردي أو عبر عرض تقديمي كامل. يمكن لكل عملية أيضاً إبلاغ التطبيق عن كل مطابقة من خلال رد نداء للنتيجة. هذا يجعل من الممكن تحديث عرض تقديمي وفي الوقت نفسه بناء سجل تدقيق يحتوي على النص المطابق، وسياقه، وموقعه، وإطار النص، ورقم الشريحة.

هذه القدرات مفيدة للمراجعة، والتمويه، وفحص المصطلحات، وتنظيف القوالب، وتدفقات عمل التقارير المؤتمتة.

في الأمثلة الأولى أدناه، نستخدم ملفًا باسم "sample.pptx"، يحتوي على صندوق نص واحد في الشريحة الأولى بالنص التالي:

![نص العينة](sample_text.png)

## **اختيار نطاق البحث**

استخدم الأساليب على [TextFrame](https://reference.aspose.com/slides/ar/php-java/aspose.slides/textframe/) لتحديد عملية لإطار نص واحد. استخدم الأساليب على [Presentation](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/) لمعالجة جميع النصوص القابلة للتطبيق في العرض التقديمي.

| العملية | إطار نص واحد | العرض التقديمي بالكامل |
|---|---|---|
| تمييز النص الحرفي | [TextFrame::highlightText](https://reference.aspose.com/slides/ar/php-java/aspose.slides/textframe/#highlightText) | [Presentation::highlightText](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/#highlightText) |
| تمييز مطابقات التعبير النمطي | [TextFrame::highlightRegex](https://reference.aspose.com/slides/ar/php-java/aspose.slides/textframe/#highlightRegex) | [Presentation::highlightRegex](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/#highlightRegex) |
| استبدال النص الحرفي | [TextFrame::replaceText](https://reference.aspose.com/slides/ar/php-java/aspose.slides/textframe/#replaceText) | [Presentation::replaceText](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/#replaceText) |
| استبدال مطابقات التعبير النمطي | [TextFrame::replaceRegex](https://reference.aspose.com/slides/ar/php-java/aspose.slides/textframe/#replaceRegex) | [Presentation::replaceRegex](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/#replaceRegex) |

## **تكوين مطابقة النص**

لعمليات النص الحرفي، استخدم [TextSearchOptions](https://reference.aspose.com/slides/ar/php-java/aspose.slides/textsearchoptions/) للتحكم في المطابقة:

- [TextSearchOptions::setWholeWordsOnly](https://reference.aspose.com/slides/ar/php-java/aspose.slides/textsearchoptions/#setWholeWordsOnly) يقتصر المطابقات على كلمات كاملة.
- [TextSearchOptions::setCaseSensitive](https://reference.aspose.com/slides/ar/php-java/aspose.slides/textsearchoptions/#setCaseSensitive) يتحكم فيما إذا كان يجب مطابقة حالة الأحرف.
- [TextSearchOptions::setIncludeNotes](https://reference.aspose.com/slides/ar/php-java/aspose.slides/textsearchoptions/#setIncludeNotes) تشمل ملاحظات الشرائح في عمليات البحث، الإستبدال، وتنسيق النص على مستوى العرض التقديمي.

تستخدم عمليات التعبير النمطي كائن Java `Pattern`، لذا تُحدد قواعد المطابقة مثل حساسية الحالة وحدود الكلمات من خلال التعبير وعلماته.

## **تحديد مالك إطار النص**

غالبًا ما تستقبل تدفقات عمل معالجة النص العامة كائنًا من نوع [TextFrame](https://reference.aspose.com/slides/ar/php-java/aspose.slides/textframe/) أثناء البحث أو الإستبدال أو التحقق أو تصدير النص. استخدم [TextFrame::getParentShape](https://reference.aspose.com/slides/ar/php-java/aspose.slides/textframe/#getParentShape) و[TextFrame::getParentCell](https://reference.aspose.com/slides/ar/php-java/aspose.slides/textframe/#getParentCell) لتحديد أي كائن عرض تقديمي يملك إطار النص.

القيم المتوقعة تعتمد على المالك:

| مالك إطار النص | `getParentShape` | `getParentCell` |
|---|---|---|
| شكل AutoShape أو أي شكل آخر يحتوي على نص | الـ [Shape](https://reference.aspose.com/slides/ar/php-java/aspose.slides/shape/) المالك | `null` |
| خلية جدول | `null` | الـ [Cell](https://reference.aspose.com/slides/ar/php-java/aspose.slides/cell/) المالك |

كلا الطريقتين توفران تنقلًا للقراءة فقط. استدعاؤهما لا ينقل إطار النص ولا يغير مالكه. يجب على الشيفرة العامة فحص القيمتين باستخدام `java_is_null` ومعالجة احتمال عدم توفر أي من المالكين.

المثال التالي يستخدم [SlideUtil::getAllTextFrames](https://reference.aspose.com/slides/ar/php-java/aspose.slides/slideutil/#getAllTextFrames) للتنقل بين إطارات النص في عرض تقديمي. بالنسبة للأشكال، يُبلغ عن اسم الشكل، نوع وقت تشغيل Java، والشريحة التي يحتويها. بالنسبة لخلايا الجدول، يُبلغ عن إحداثيات العمود والصف التي تبدأ من الصفر والشريحة المحتوية.

```php
use aspose\slides\Presentation;
use aspose\slides\SlideUtil;

$presentation = new Presentation("presentation.pptx");
$arrayClass = new java_class("java.lang.reflect.Array");

try {
    $textFrames = SlideUtil::getAllTextFrames($presentation, false);
    $textFrameCount = java_values($arrayClass->getLength($textFrames));

    for ($textFrameIndex = 0; $textFrameIndex < $textFrameCount; $textFrameIndex++) {
        $textFrame = $textFrames[$textFrameIndex];
        $ownerShape = $textFrame->getParentShape();
        if (!java_is_null($ownerShape)) {
            $shapeName = java_values($ownerShape->getName());
            $shapeName = $shapeName === "" ? "(unnamed)" : $shapeName;
            $shapeType = java_values($ownerShape->getClass()->getSimpleName());
            $baseSlide = $ownerShape->getSlide();
            $slideClassName = java_values($baseSlide->getClass()->getName());

            if ($slideClassName === "com.aspose.slides.Slide") {
                $slideLabel = "slide " . java_values($baseSlide->getSlideNumber());
            } elseif ($slideClassName === "com.aspose.slides.NotesSlide") {
                $slideLabel = "notes for slide " . java_values($baseSlide->getParentSlide()->getSlideNumber());
            } else {
                $slideLabel = java_values($baseSlide->getClass()->getSimpleName());
            }

            echo("Shape: " . $shapeName . "; type: " . $shapeType . "; " . $slideLabel . "\n");
            continue;
        }

        $ownerCell = $textFrame->getParentCell();
        if (!java_is_null($ownerCell)) {
            $baseSlide = $ownerCell->getSlide();
            $slideClassName = java_values($baseSlide->getClass()->getName());

            if ($slideClassName === "com.aspose.slides.Slide") {
                $slideLabel = "slide " . java_values($baseSlide->getSlideNumber());
            } elseif ($slideClassName === "com.aspose.slides.NotesSlide") {
                $slideLabel = "notes for slide " . java_values($baseSlide->getParentSlide()->getSlideNumber());
            } else {
                $slideLabel = java_values($baseSlide->getClass()->getSimpleName());
            }

            echo("Table cell: column " . java_values($ownerCell->getFirstColumnIndex()) . ", row " . java_values($ownerCell->getFirstRowIndex()) . "; " . $slideLabel . "\n");
            continue;
        }

        echo("The text frame owner is not available as a shape or table cell.\n");
    }
} finally {
    $presentation->dispose();
}
```

لمحتوى SmartArt، تنقّل عبر الأشكال في [SmartArtNode::getShapes](https://reference.aspose.com/slides/ar/php-java/aspose.slides/smartartnode/#getShapes) وادخل إلى كل [SmartArtShape::getTextFrame](https://reference.aspose.com/slides/ar/php-java/aspose.slides/smartartshape/#getTextFrame). يمكن تتبع إطار النص إلى الشكل المرتبط عبر [TextFrame::getParentShape](https://reference.aspose.com/slides/ar/php-java/aspose.slides/textframe/#getParentShape)، بينما تُعيد [TextFrame::getParentCell](https://reference.aspose.com/slides/ar/php-java/aspose.slides/textframe/#getParentCell) `null`. لذلك يتعامل فرع الشكل في المثال أيضًا مع النص من عقد SmartArt.

## **جمع معلومات المطابقة باستخدام رد نداء**

مرّر رد نداء Java إلى طريقة تمييز أو إستبدال لتلقي إشعار عن كل مطابقة. تتلقى طريقة رد النداء إطار النص المرتبط، النص الأصلي، النص المطابق، وموقع المطابقة.

لا يتلقى رد النداء رقم الشريحة مباشرة. يشتق التنفيذ أدناه الرقم من الشريحة الأصلية ويتعامل أيضًا مع النص الموجود في ملاحظات الشرائح. يستخدم مصفوفة النتائج `null` عندما يكون النص مرتبطًا بنوع شريحة آخر.

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
        $parentShape = $textFrame->getParentShape();
        $parentCell = $textFrame->getParentCell();

        if (!java_is_null($parentShape)) {
            $parentSlide = $parentShape->getSlide();
        } elseif (!java_is_null($parentCell)) {
            $parentSlide = $parentCell->getSlide();
        } else {
            $parentSlide = $textFrame->getSlide();
        }

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

بالنسبة لعمليات الإستبدال، يحتوي `foundText` على النص الأصلي المطابق، لذا يمكن لرد النداء تسجيل بالضبط أي مصطلحات تم استبدالها.

## **تمييز النص**

استخدم الطريقة [TextFrame::highlightText](https://reference.aspose.com/slides/ar/php-java/aspose.slides/textframe/#highlightText) لتمييز مطابقات النص الحرفي في إطار نص. مرّر [TextSearchOptions](https://reference.aspose.com/slides/ar/php-java/aspose.slides/textsearchoptions/) للتحكم في البحث.

الكود أدناه يميز جميع تكرارات الأحرف **"try"** ثم يميز الكلمة الكاملة **"to"** فقط.

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

    // تمييز كل حدوث لكلمة "try" في إطار النص.
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

## **تمييز النص باستخدام التعابير النمطية**

الطريقة [TextFrame::highlightRegex](https://reference.aspose.com/slides/ar/php-java/aspose.slides/textframe/#highlightRegex) تميز مطابقات النص التي يجدها تعبير نمطي داخل إطار نص.

الكود التالي يميز جميع الكلمات التي تحتوي على سبعة أحرف أو أكثر:

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

## **تمييز النص عبر عرض تقديمي**

استخدم [Presentation::highlightText](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/#highlightText) و[Presentation::highlightRegex](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/#highlightRegex) للبحث عن جميع إطارات النص القابلة للتطبيق في عرض تقديمي. المثال التالي يميز مصطلح حرفي وجميع عناوين البريد الإلكتروني:

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

استخدم [TextFrame::replaceText](https://reference.aspose.com/slides/ar/php-java/aspose.slides/textframe/#replaceText) للنص الحرفي و[TextFrame::replaceRegex](https://reference.aspose.com/slides/ar/php-java/aspose.slides/textframe/#replaceRegex) للإستبدال القائم على نمط. تقوم هذه الطرق بتحديث النص المطابق داخل إطار النص الحالي، مع الحفاظ على تنسيق الجزء المحيط بدلاً من إعادة بناء إطار النص من سلسلة عادية.

المثال التالي يوحد متغير تهجئة ثم يستبدل تسميات الإصدارات:

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

إذا امتد مطابقة واحدة على أجزاء ذات تنسيقات مختلفة، راجع النتيجة لتأكيد أي تنسيق يجب تطبيقه على النص المستبدل.

## **استبدال النص عبر عرض تقديمي**

استخدم [Presentation::replaceText](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/#replaceText) و[Presentation::replaceRegex](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/#replaceRegex) لتطبيق نفس العمليات عبر العرض التقديمي. هذا مفيد لتنظيف القوالب، وتحديث المصطلحات، والتمويه.

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

## **تجميع المطابقات للتقارير**

نظرًا لأن كل نتيجة تخزن رقم الشريحة وإطار النص، يمكن للتطبيقات تجميع المطابقات للتدقيق أو التقارير أو تدفقات العمل المراجعية. المثال التالي يجمع النتائج المجمعة أولاً حسب الشريحة ثم حسب إطار النص:

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

## **الأسئلة المتداولة**

**كيف أبحث فقط في صندوق نص واحد بدلاً من العرض التقديمي بالكامل؟**

احصل على إطار نص الشكل واستدعِ [TextFrame::highlightText](https://reference.aspose.com/slides/ar/php-java/aspose.slides/textframe/#highlightText)، [TextFrame::highlightRegex](https://reference.aspose.com/slides/ar/php-java/aspose.slides/textframe/#highlightRegex)، [TextFrame::replaceText](https://reference.aspose.com/slides/ar/php-java/aspose.slides/textframe/#replaceText)، أو [TextFrame::replaceRegex](https://reference.aspose.com/slides/ar/php-java/aspose.slides/textframe/#replaceRegex) على ذلك الإطار. طرق مستوى العرض التقديمي تعالج جميع إطارات النص القابلة للتطبيق بدلاً من ذلك.

**كيف أُطابق الكلمات الكاملة مع كتابة الأحرف الصحيحة؟**

اضبط [TextSearchOptions::setWholeWordsOnly](https://reference.aspose.com/slides/ar/php-java/aspose.slides/textsearchoptions/#setWholeWordsOnly) و[TextSearchOptions::setCaseSensitive](https://reference.aspose.com/slides/ar/php-java/aspose.slides/textsearchoptions/#setCaseSensitive) على `true`، ومرّر الخيارات إلى طريقة تمييز أو إستبدال النص الحرفي. بالنسبة للتعابير النمطية، عّرّف حدود الكلمات وحساسية الحالة داخل كائن Java `Pattern` نفسه.

**هل يمكن أن تشمل عمليات البحث والإستبدال النص الموجود في ملاحظات الشرائح؟**

نعم. اضبط [TextSearchOptions::setIncludeNotes](https://reference.aspose.com/slides/ar/php-java/aspose.slides/textsearchoptions/#setIncludeNotes) على `true` عند استخدام عملية نص حرفي على مستوى العرض التقديمي.

**كيف أنشئ تقريرًا دون مسح العرض التقديمي مرة ثانية؟**

مرّر رد نداء Java إلى عملية التمييز أو الإستبدال. سيتلقى كل مطابقة أثناء تشغيل العملية، وبالتالي يمكن للتطبيق حفظ النص الأصلي، النص المطابق، الموقع، إطار النص، ورقم الشريحة المستخلص لتجميعه لاحقًا أو تصديره.

**هل يحافظ إستبدال النص على تنسيقه؟**

[TextFrame::replaceText](https://reference.aspose.com/slides/ar/php-java/aspose.slides/textframe/#replaceText) و[TextFrame::replaceRegex](https://reference.aspose.com/slides/ar/php-java/aspose.slides/textframe/#replaceRegex) يغيّران النص المطابق داخل إطار النص الحالي ويحتفظان بتنسيق الجزء المحيط. إذا امتدت مطابقة على أجزاء ذات تنسيقات مختلفة، افحص النتيجة لضمان أن الاستبدال يستخدم النمط المطلوب.