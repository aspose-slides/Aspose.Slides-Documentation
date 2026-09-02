---
title: جستجو و جایگزینی متن در ارائه‌های PowerPoint در PHP
linktitle: جستجو و جایگزینی متن
type: docs
weight: 55
url: /fa/php-java/search-and-replace-text/
keywords:
- متن جستجو
- متن برجسته
- متن جایگزین
- عبارت منظم
- فراخوانی نتیجه
- قاب متن
- گزارش حسابرسی
- PowerPoint
- OpenDocument
- ارائه
- PHP
- Aspose.Slides
description: "متن را در ارائه‌های PowerPoint جستجو، برجسته و جایگزین کنید و در عین حال هر مطابقت را با Aspose.Slides for PHP via Java جمع‌آوری کنید."
---
## **مروری کلی**

Aspose.Slides for PHP via Java می‌تواند متن را در یک قاب متن منفرد یا در سراسر یک ارائه جستجو، برجسته و جایگزین کند. هر عملیات می‌تواند با فراخوانی یک تابع بازگشت نتیجه، برنامه را از هر مطابقت مطلع سازد. این امکان به‌روز رسانی ارائه و همزمان ساختن ردپای حسابرسی شامل متن مطابق، زمینهٔ آن، موقعیت، قاب متن و شمارهٔ اسلاید را فراهم می‌کند.

این قابلیت‌ها برای بازبینی، محرمانه‌سازی، بررسی اصطلاحات، پاک‌سازی قالب و گردش‌کارهای گزارش‌گیری خودکار مفید هستند.

در مثال‌های اولیهٔ زیر، از فایلی به نام «sample.pptx» استفاده می‌کنیم که در اسلاید اول یک جعبه متن با متن زیر دارد:

![متن نمونه](sample_text.png)

## **انتخاب محدوده جستجو**

از متدهای [TextFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textframe/) برای محدود کردن عملیات به یک قاب متن استفاده کنید. از متدهای [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) برای پردازش تمام متن‌های قابل اعمال در ارائه بهره بگیرید.

| عملیات | یک قاب متن | کل ارائه |
|---|---|---|
| برجسته‌سازی متن لغوی | [TextFrame::highlightText](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textframe/#highlightText) | [Presentation::highlightText](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/#highlightText) |
| برجسته‌سازی تطبیق‌های عبارات منظم | [TextFrame::highlightRegex](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textframe/#highlightRegex) | [Presentation::highlightRegex](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/#highlightRegex) |
| جایگزینی متن لغوی | [TextFrame::replaceText](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textframe/#replaceText) | [Presentation::replaceText](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/#replaceText) |
| جایگزینی تطبیق‌های عبارات منظم | [TextFrame::replaceRegex](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textframe/#replaceRegex) | [Presentation::replaceRegex](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/#replaceRegex) |

## **پیکربندی مطابقت متن**

برای عملیات‌های متن لغوی، از [TextSearchOptions](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textsearchoptions/) برای کنترل مطابقت استفاده کنید:

- `TextSearchOptions::setWholeWordsOnly` مطابقت‌ها را به کلمات کامل محدود می‌کند.
- `TextSearchOptions::setCaseSensitive` تعیین می‌کند که آیا حس حساسیت به حروف بزرگ/کوچک لازم است یا نه.
- `TextSearchOptions::setIncludeNotes` یادداشت‌های اسلاید را در عملیات جستجو، جایگزینی و برجسته‌سازی در سطح ارائه گنجانده می‌کند.

عملیات‌های عبارات منظم از یک `Pattern` جاوا استفاده می‌کنند، بنابراین قوانین مطابقت مانند حساسیت به حروف و مرزهای کلمه توسط خود عبارت و پرچم‌های آن تعریف می‌شود.

## **جمع‌آوری اطلاعات مطابقت با Callback**

یک callback پروکسی جاوا را به متد برجسته‌سازی یا جایگزینی بدهید تا برای هر تطبیق یک اعلان دریافت کنید. متد callback قاب متن مرتبط، متن منبع، متن مطابقت یافته و موقعیت تطبیق را دریافت می‌کند.

callback به‌طور مستقیم شمارهٔ اسلاید را دریافت نمی‌کند. پیاده‌سازی زیر آن را از اسلاید والد استخراج می‌کند و همچنین متن موجود در یادداشت‌های اسلاید را مدیریت می‌کند. آرایهٔ نتیجه برای متنی که به نوع اسلاید دیگری مرتبط است مقدار `null` دارد.

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

برای عملیات جایگزینی، `foundText` شامل متن اصلی مطابقت یافته است، بنابراین callback می‌تواند دقیقاً ثبت کند که کدام اصطلاحات جایگزین شده‌اند.

## **برجسته‌سازی متن**

از متد [TextFrame::highlightText](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textframe/#highlightText) برای برجسته‌سازی مطابقت‌های متن لغوی در یک قاب متن استفاده کنید. برای کنترل جستجو، یک [TextSearchOptions](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textsearchoptions/) را پاس کنید.

کد مثال زیر تمام رخدادهای کاراکترهای **"try"** را برجسته می‌کند و سپس فقط کلمهٔ کامل **"to"** را برجسته می‌کند.

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

    // برجسته‌سازی هر بار وقوع "try" در قاب متن.
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

    // برجسته‌سازی فقط کلمه کامل "to".
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

![متن برجسته شده](highlighted_text.png)

## **برجسته‌سازی متن با عبارات منظم**

متد [TextFrame::highlightRegex](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textframe/#highlightRegex) متن‌های مطابق با یک عبارت منظم را در یک قاب متن برجسته می‌کند.

کد زیر تمام کلماتی را که شامل هفت یا بیشتر حرف هستند برجسته می‌کند:

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

![متن برجسته شده با استفاده از عبارت منظم](highlighted_text_using_regex.png)

## **برجسته‌سازی متن در سراسر یک ارائه**

از متدهای [Presentation::highlightText](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/#highlightText) و [Presentation::highlightRegex](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/#highlightRegex) برای جستجوی تمام قاب‌های متن قابل اعمال در یک ارائه استفاده کنید. مثال زیر یک عبارت لغوی و تمام آدرس‌های ایمیل را برجسته می‌کند:

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

از [TextFrame::replaceText](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textframe/#replaceText) برای متن لغوی و [TextFrame::replaceRegex](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textframe/#replaceRegex) برای جایگزینی مبتنی بر الگو استفاده کنید. این متدها متن مطابقت یافته را داخل قاب متن موجود به‌روز می‌کنند، به‌طوری که قالب‌بندی بخش‌های اطراف حفظ می‌شود و نیازی به بازسازی کامل قاب متن از یک رشته ساده نیست.

کد زیر یک گونهٔ املایی را استاندارد می‌کند و سپس برچسب‌های نسخه را جایگزین می‌کند:

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

اگر یک مطابقت شامل بخش‌هایی با قالب‌بندی متفاوت باشد، خروجی را بررسی کنید تا تعیین کنید کدام قالب‌بندی باید برای متن جایگزین اعمال شود.

## **جایگزینی متن در سراسر یک ارائه**

از [Presentation::replaceText](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/#replaceText) و [Presentation::replaceRegex](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/#replaceRegex) برای اعمال همان عملیات‌ها در سرتاسر ارائه استفاده کنید. این برای پاک‌سازی قالب، به‌روزرسانی اصطلاحات و محرمانه‌سازی مفید است.

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

## **گروه‌بندی تطبیق‌ها برای گزارش‌دهی**

از آنجا که هر نتیجه شمارهٔ اسلاید و قاب متن خود را ذخیره می‌کند، برنامه‌ها می‌توانند مطابقت‌ها را برای حسابرسی، گزارش‌دهی یا گردش‌کارهای بازبینی گروه‌بندی کنند. مثال زیر نتایج جمع‌آوری شده را ابتدا بر اساس اسلاید و سپس بر اساس قاب متن گروه‌بندی می‌کند:

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

**چگونه می‌توانم فقط یک جعبه متن را به جای کل ارائه جستجو کنم؟**

قاب متن شکل را دریافت کنید و بر روی آن [TextFrame::highlightText](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textframe/#highlightText)، [TextFrame::highlightRegex](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textframe/#highlightRegex)، [TextFrame::replaceText](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textframe/#replaceText) یا [TextFrame::replaceRegex](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textframe/#replaceRegex) را فراخوانی کنید. متدهای سطح ارائه تمام قاب‌های متن قابل اعمال را پردازش می‌کنند.

**چگونه می‌توانم کلمات کامل را با حروف بزرگ/کوچک صحیح مطابقت دهم؟**

`[TextSearchOptions::setWholeWordsOnly](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textsearchoptions/#setWholeWordsOnly)` و `[TextSearchOptions::setCaseSensitive](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textsearchoptions/#setCaseSensitive)` را به `true` تنظیم کنید و گزینه‌ها را به متد برجسته‌سازی یا جایگزینی متن لغوی پاس دهید. برای عبارات منظم، مرزهای کلمه و حساسیت به حروف را در خود `Pattern` جاوا تعریف کنید.

**آیا جستجو و جایگزینی می‌تواند متن موجود در یادداشت‌های اسلاید را شامل شود؟**

بله. هنگام استفاده از یک عملیات متن لغوی در سطح ارائه، `[TextSearchOptions::setIncludeNotes](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textsearchoptions/#setIncludeNotes)` را به `true` تنظیم کنید.

**چگونه می‌توانم بدون اسکن دوبارهٔ ارائه گزارش بسازم؟**

یک callback پروکسی جاوا را به عملیات برجسته‌سازی یا جایگزینی پاس دهید. این callback در زمان اجرای عملیات هر مطابقت را دریافت می‌کند، بنابراین برنامه می‌تواند متن منبع، متن مطابقت یافته، موقعیت، قاب متن و شمارهٔ اسلاید محاسبه‌شده را برای گروه‌بندی یا استخراج بعدی ذخیره کند.

**آیا جایگزینی متن قالب‌بندی آن را حفظ می‌کند؟**

`[TextFrame::replaceText](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textframe/#replaceText)` و `[TextFrame::replaceRegex](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textframe/#replaceRegex)` متن مطابقت یافته را داخل قاب متن موجود تغییر می‌دهند و قالب‌بندی بخش‌های اطراف را حفظ می‌کنند. اگر یک مطابقت شامل بخش‌هایی با قالب‌بندی متفاوت باشد، نتیجه را بررسی کنید تا مطمئن شوید جایگزینی از سبک دلخواه استفاده می‌کند.