---
title: جستجو و جایگزینی متن در ارائه‌های PowerPoint با PHP
linktitle: جستجو و جایگزینی متن
type: docs
weight: 55
url: /fa/php-java/search-and-replace-text/
keywords:
- جستجوی متن
- برجسته‌سازی متن
- جایگزینی متن
- عبارت منظم
- callback نتیجه
- قاب متن
- گزارش حسابرسی
- PowerPoint
- OpenDocument
- ارائه
- PHP
- Aspose.Slides
description: "جستجو، برجسته‌سازی و جایگزینی متن در ارائه‌های PowerPoint را هنگام جمع‌آوری همهٔ تطبیق‌ها با Aspose.Slides برای PHP از طریق Java انجام می‌دهد."
---
## **بررسی کلی**

Aspose.Slides for PHP via Java می‌تواند متن را در یک قاب متن منفرد یا در سرتاسر ارائه جستجو، برجسته و جایگزین کند. هر عملیات می‌تواند از طریق یک callback نتایج، هر تطبیق را به برنامه اطلاع دهد. این امکان را فراهم می‌آورد تا یک ارائه به‌روزرسانی شود و در همان زمان یک ردپای حسابرسی شامل متن مطابقت‌یافته، زمینه، موقعیت، قاب متن و شماره اسلاید ساخته شود.

این قابلیت‌ها برای بررسی، محو کردن، بررسی اصطلاحات، پاک‌سازی قالب و جریان‌های کاری گزارش‌دهی خودکار مفید هستند.

در مثال‌های زیر از فایلی به نام "sample.pptx" استفاده می‌کنیم که یک جعبه متن واحد در اسلاید اول دارد و متن زیر را شامل می‌شود:

![متن نمونه](sample_text.png)

## **انتخاب محدودهٔ جستجو**

از توابع موجود در [TextFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textframe/) برای محدود کردن عملیات به یک قاب متن استفاده کنید. از توابع موجود در [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) برای پردازش تمام متون قابل اعمال در ارائه استفاده کنید.

| عملیات | یک قاب متن | کل ارائه |
|---|---|---|
| برجسته‌سازی متن صریح | [TextFrame::highlightText](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textframe/#highlightText) | [Presentation::highlightText](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/#highlightText) |
| برجسته‌سازی تطبیق‌های عبارات منظم | [TextFrame::highlightRegex](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textframe/#highlightRegex) | [Presentation::highlightRegex](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/#highlightRegex) |
| جایگزینی متن صریح | [TextFrame::replaceText](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textframe/#replaceText) | [Presentation::replaceText](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/#replaceText) |
| جایگزینی تطبیق‌های عبارات منظم | [TextFrame::replaceRegex](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textframe/#replaceRegex) | [Presentation::replaceRegex](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/#replaceRegex) |

## **پیکربندی تطبیق متن**

برای عملیات متن صریح، از [TextSearchOptions](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textsearchoptions/) برای کنترل تطبیق استفاده کنید:

- [TextSearchOptions::setWholeWordsOnly](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textsearchoptions/#setWholeWordsOnly) تطبیق‌ها را به کلمات کامل محدود می‌کند.
- [TextSearchOptions::setCaseSensitive](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textsearchoptions/#setCaseSensitive) کنترل می‌کند که حساسیت به حروف بزرگ/کوچک لحاظ شود یا نه.
- [TextSearchOptions::setIncludeNotes](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textsearchoptions/#setIncludeNotes) یادداشت‌های اسلاید را در عملیات جستجو، جایگزینی و برجسته‌سازی سطح ارائه گنجانده می‌شود.

عملیات عبارات منظم از یک `Pattern` جاوا استفاده می‌کند، بنابراین قوانین تطبیق مثل حساسیت به حروف و مرزهای کلمه توسط عبارت و پرچم‌های آن تعریف می‌شوند.

## **شناسایی مالک یک قاب متن**

گردش‌کارهای عمومی پردازش متن اغلب یک [TextFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textframe/) را هنگام جستجو، جایگزینی، اعتبارسنجی یا استخراج دریافت می‌کنند. از [TextFrame::getParentShape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textframe/#getParentShape) و [TextFrame::getParentCell](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textframe/#getParentCell) برای تعیین شیء ارائه‌ای که مالک این قاب متن است استفاده کنید.

مقادیر مورد انتظار بسته به مالک متفاوت است:

| مالک قاب متن | `getParentShape` | `getParentCell` |
|---|---|---|
| یک AutoShape یا شکل دیگری که متن دارد | شیء مالک [Shape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shape/) | `null` |
| یک سلول جدول | `null` | شیء مالک [Cell](https://reference.aspose.com/slides/fa/php-java/aspose.slides/cell/) |

هر دو روش ناوبری فقط‑خواندنی هستند. فراخوانی آن‌ها قاب متن را جابه‌جا یا مالک آن را تغییر نمی‌دهد. کد عمومی باید هر دو مقدار را با `java_is_null` بررسی کند و امکان عدم وجود هر دو مالک را مدیریت کند.

مثال زیر از [SlideUtil::getAllTextFrames](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slideutil/#getAllTextFrames) برای پیمایش قاب‌های متن در یک ارائه استفاده می‌کند. برای شکل‌ها، نام شکل، نوع زمان اجرا در جاوا و اسلاید حاوی آن گزارش می‌شود. برای سلول‌های جدول، مختصات ستون و ردیف صفر‑مبنا و اسلاید حاوی آن گزارش می‌شود.

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

برای محتوای SmartArt، به شکل‌های موجود در [SmartArtNode::getShapes](https://reference.aspose.com/slides/fa/php-java/aspose.slides/smartartnode/#getShapes) سر بزنید و به هر [SmartArtShape::getTextFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/smartartshape/#getTextFrame) دسترسی پیدا کنید. قاب متن می‌تواند از طریق [TextFrame::getParentShape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textframe/#getParentShape) به شکل مرتبط خود ردیابی شود، در حالی که [TextFrame::getParentCell](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textframe/#getParentCell) مقدار `null` برمی‌گرداند. بنابراین، شاخهٔ شکل در مثال همچنین متن از گره‌های SmartArt را مدیریت می‌کند.

## **جمع‌آوری اطلاعات تطبیق با یک Callback**

یک callback پروکسی جاوا را به متد برجسته‌سازی یا جایگزینی پاس دهید تا برای هر تطبیق یک اعلان دریافت کنید. متد callback متن قاب متن مرتبط، متن منبع، متن مطابقت‑یافته و موقعیت تطبیق را دریافت می‌کند.

callback شماره اسلاید را به‌طور مستقیم دریافت نمی‌کند. پیاده‌سازی زیر آن را از اسلاید والد استخراج می‌کند و همچنین متن پیدا شده در یادداشت‌های اسلاید را مدیریت می‌کند. آرایهٔ نتیجه هنگام ارتباط متن با نوع اسلاید دیگری از `null` استفاده می‌کند.

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

قبل از پاس دادن به یک عملیات، یک پروکسی برای این شیء PHP ایجاد کنید:

```php
$callbackHandler = new TextSearchCallback();
$callbackInterface = java("com.aspose.slides.IFindResultCallback");
$callback = java_closure(
    $callbackHandler,
    null,
    $callbackInterface
);
```

برای عملیات جایگزینی، `foundText` شامل متن مطابقت‑یافتهٔ اصلی است، بنابراین callback می‌تواند دقیقاً ثبت کند که کدام عبارات جایگزین شده‌اند.

## **برجسته‌سازی متن**

از متد [TextFrame::highlightText](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textframe/#highlightText) برای برجسته‌سازی تطبیق‌های متن صریح در یک قاب متن استفاده کنید. برای کنترل جستجو، یک [TextSearchOptions](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textsearchoptions/) پاس دهید.

مثال کد زیر تمام رخده‌های کاراکترهای **"try"** را برجسته می‌کند و سپس فقط کلمهٔ کامل **"to"** را برجسته می‌سازد.

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

    // برجسته‌سازی تمام رخدادهای "try" در قاب متن.
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

    // برجسته‌سازی تنها کلمه کامل "to".
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

نتیجه:

![متن برجسته‌شده](highlighted_text.png)

## **برجسته‌سازی متن با استفاده از عبارات منظم**

متد [TextFrame::highlightRegex](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textframe/#highlightRegex) متن‌های یافت‌شده توسط یک عبارت منظم را در یک قاب متن برجسته می‌کند.

کد زیر تمام کلماتی که شامل هفت یا بیشتر کاراکتر هستند را برجسته می‌کند:

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

نتیجه:

![متن برجسته‌شده با استفاده از عبارت منظم](highlighted_text_using_regex.png)

## **برجسته‌سازی متن در تمام ارائه**

از [Presentation::highlightText](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/#highlightText) و [Presentation::highlightRegex](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/#highlightRegex) برای جستجو در تمام قاب‌های متن قابل اعمال در یک ارائه استفاده کنید. مثال زیر یک اصطلاح صریح و تمام آدرس‌های ایمیل را برجسته می‌کند:

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

## **جایگزینی متن در یک قاب متن**

از [TextFrame::replaceText](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textframe/#replaceText) برای متن صریح و از [TextFrame::replaceRegex](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textframe/#replaceRegex) برای جایگزینی مبتنی بر الگو استفاده کنید. این متدها متن مطابقت‑یافته را درون قاب متن موجود به‌روزرسانی می‌کنند، به‌طوری که قالب‌بندی بخش‌های اطراف حفظ می‌شود و نیازی به بازسازی کامل قاب متن از یک رشتهٔ ساده نیست.

مثال زیر یک گونهٔ املایی را استانداردسازی کرده و سپس برچسب‌های نسخه را جایگزین می‌کند:

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

اگر یک تطبیق شامل بخش‌هایی با قالب‌بندی متفاوت باشد، خروجی را بررسی کنید تا تأیید شود که قالب‌بندی مطلوب برای متن جایگزین اعمال شده است.

## **جایگزینی متن در کل ارائه**

از [Presentation::replaceText](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/#replaceText) و [Presentation::replaceRegex](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/#replaceRegex) برای اعمال همان عملیات‌ها در تمام ارائه استفاده کنید. این کار برای پاک‌سازی قالب، به‌روزرسانی اصطلاحات و محو کردن مفید است.

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

## **گروه‌بندی تطبیق‌ها برای گزارش‌گیری**

از آنجا که هر نتیجه شماره اسلاید و قاب متن خود را ذخیره می‌کند، برنامه‌ها می‌توانند تطبیق‌ها را برای حسابرسی، گزارش‌گیری یا گردش‌کارهای بررسی گروه‌بندی کنند. مثال زیر نتایج جمع‌آوری‌شده را ابتدا بر اساس اسلاید و سپس بر اساس قاب متن گروه‌بندی می‌کند:

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

## **سوالات متداول**

**چگونه فقط یک جعبه متن را به‌جای کل ارائه جستجو کنم؟**

قاب متن شکل را دریافت کنید و بر روی آن [TextFrame::highlightText](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textframe/#highlightText)، [TextFrame::highlightRegex](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textframe/#highlightRegex)، [TextFrame::replaceText](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textframe/#replaceText) یا [TextFrame::replaceRegex](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textframe/#replaceRegex) فراخوانی کنید. متدهای سطح ارائه تمام قاب‌های متن قابل اعمال را پردازش می‌کنند.

**چگونه می‌توانم کلمات کامل را با حروف بزرگ/کوچک صحیح مطابقت دهم؟**

[TextSearchOptions::setWholeWordsOnly](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textsearchoptions/#setWholeWordsOnly) و [TextSearchOptions::setCaseSensitive](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textsearchoptions/#setCaseSensitive) را به `true` تنظیم کنید و گزینه‌ها را به یک متد برجسته‌سازی یا جایگزینی متن صریح پاس دهید. برای عبارات منظم، مرزهای کلمه و حساسیت به حروف را خود عبارت `Pattern` جاوا تعریف می‌کند.

**آیا جستجو و جایگزینی می‌تواند متن موجود در یادداشت‌های اسلاید را شامل شود؟**

بله. هنگام استفاده از یک عملیات متن صریح در سطح ارائه، [TextSearchOptions::setIncludeNotes](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textsearchoptions/#setIncludeNotes) را به `true` تنظیم کنید.

**چگونه می‌توانم یک گزارش تهیه کنم بدون اینکه ارائه را بار دیگر اسکن کنم؟**

یک callback پروکسی جاوا را به عملیات برجسته‌سازی یا جایگزینی پاس دهید. این callback در طول اجرای عملیات هر تطبیق را دریافت می‌کند، بنابراین برنامه می‌تواند متن منبع، متن مطابقت‑یافته، موقعیت، قاب متن و شماره اسلاید استخراج‌شده را برای گروه‌بندی یا خروجی بعدی ذخیره کند.

**آیا جایگزینی متن قالب‌بندی آن را حفظ می‌کند؟**

[TextFrame::replaceText](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textframe/#replaceText) و [TextFrame::replaceRegex](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textframe/#replaceRegex) متن مطابقت‑یافته را درون قاب متن موجود تغییر می‌دهند و قالب‌بندی بخش‌های اطراف را نگه می‌دارند. اگر یک تطبیق شامل بخش‌هایی با قالب‌بندی متفاوت باشد، نتیجه را بررسی کنید تا اطمینان حاصل شود که جایگزینی از سبک موردنظر استفاده می‌کند.