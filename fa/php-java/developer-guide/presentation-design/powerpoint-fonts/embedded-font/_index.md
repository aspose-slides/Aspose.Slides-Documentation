---
title: توکار کردن فونت‌ها در ارائه‌ها با PHP
linktitle: فونت‌های توکار
type: docs
weight: 40
url: /fa/php-java/embedded-font/
keywords:
- افزودن فونت
- توکار کردن فونت
- توکار کردن فونت
- دریافت فونت توکار
- افزودن فونت توکار
- حذف فونت توکار
- فشرده‌سازی فونت توکار
- PowerPoint
- ارائه
- PHP
- Aspose.Slides
description: "فونت‌های توکار شده در PowerPoint را با Aspose.Slides برای PHP از طریق Java مدیریت کنید. برای حفظ ظاهر متن و کاهش حجم فایل، فونت‌ها را اضافه، دریافت، حذف و فشرده کنید."
---
## **مقدمه**

ج embedding فونت‌ها داده‌های فونت را داخل یک ارائه PowerPoint ذخیره می‌کند. هنگامی که یک نمایشگر از فونت‌های توکار پشتیبانی می‌کند، می‌تواند متن را با استفاده از آن فونت‌ها نمایش دهد حتی اگر بر روی سیستم مقصد نصب نشده باشند. این کار به حفظ شکست‌های خطوط، فاصله‌های متن و چیدمان اسلاید کمک می‌کند.

Aspose.Slides for PHP via Java به شما امکان می‌دهد فونت‌های توکار را از طریق کلاس [FontsManager](https://reference.aspose.com/slides/fa/php-java/aspose.slides/fontsmanager/) که توسط [Presentation::getFontsManager](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/#getFontsManager) برگردانده می‌شود، دریافت، اضافه و حذف کنید. همچنین می‌توانید با حذف کاراکترهایی که ارائه از آن‌ها استفاده نمی‌کند، اندازه داده‌های فونت توکار را کاهش دهید.

مثال‌های زیر با فایل‌های PPTX کار می‌کنند. قبل از توکار کردن یک فونت، اطمینان حاصل کنید که داده‌های فونت آن برای Aspose.Slides در دسترس است و مجوز آن اجازه توکار کردن را می‌دهد.

## **دریافت و حذف فونت‌های توکار**

از [FontsManager::getEmbeddedFonts](https://reference.aspose.com/slides/fa/php-java/aspose.slides/fontsmanager/#getEmbeddedFonts) برای فهرست کردن فونت‌های ذخیره‌شده در یک ارائه استفاده کنید. برای حذف یک فونت، یک فونت از آن فهرست را به [FontsManager::removeEmbeddedFont](https://reference.aspose.com/slides/fa/php-java/aspose.slides/fontsmanager/#removeEmbeddedFont) پاس بدهید و سپس ارائه را ذخیره کنید.

مثال زیر فونت‌های توکار موجود در `EmbeddedFonts.pptx` را فهرست می‌کند و اگر Calibri موجود باشد، آن را حذف می‌کند:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("EmbeddedFonts.pptx");
try {
    $fontsManager = $presentation->getFontsManager();
    $embeddedFonts = $fontsManager->getEmbeddedFonts();

    foreach ($embeddedFonts as $font) {
        echo java_values($font->getFontName()) . PHP_EOL;
    }

    $fontToRemove = null;
    foreach ($embeddedFonts as $font) {
        $fontName = java_values($font->getFontName());
        if (strcasecmp($fontName, "Calibri") === 0) {
            $fontToRemove = $font;
            break;
        }
    }

    if ($fontToRemove !== null) {
        $fontsManager->removeEmbeddedFont($fontToRemove);
        $presentation->save("WithoutEmbeddedCalibri.pptx", SaveFormat::Pptx);
    } else {
        echo "Calibri is not embedded. No output file was created." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

حذف یک فونت توکار، داده‌های ذخیره‌شده آن فونت را حذف می‌کند؛ اما فونت اختصاص داده‌شده به متن را تغییر نمی‌دهد. اگر فونت بر روی سیستم هدف نصب باشد، متن می‌تواند همچنان از آن استفاده کند. در غیر این صورت، رندر ممکن است به [جایگزینی فونت](/slides/fa/php-java/font-substitution/) نیاز داشته باشد که می‌تواند بر چیدمان تأثیر بگذارد.

## **بازرسی داده‌های فونت و مجوزهای توکار کردن**

از کلاس [FontsManager](https://reference.aspose.com/slides/fa/php-java/aspose.slides/fontsmanager/) برای بازرسی فونت‌ها قبل از توکار کردن آن‌ها استفاده کنید. با فراخوانی [FontsManager::getFonts](https://reference.aspose.com/slides/fa/php-java/aspose.slides/fontsmanager/#getFonts) می‌توانید فونت‌های استفاده‌شده در ارائه را بازیابی کنید. برای هر فونت، یک شیء [FontData](https://reference.aspose.com/slides/fa/php-java/aspose.slides/fontdata/) و مقدار مورد نیاز [FontStyleType](https://reference.aspose.com/slides/fa/php-java/aspose.slides/fontstyletype/) را به [FontsManager::getFontBytes](https://reference.aspose.com/slides/fa/php-java/aspose.slides/fontsmanager/#getFontBytes) پاس بدهید. این متد داده‌های باینری برای آن سبک فونت را بر می‌گرداند یا در صورت عدم موجودی فونت یا سبک درخواست‌شده `null` بر می‌گرداند. `null` را به [FontsManager::getFontEmbeddingLevel](https://reference.aspose.com/slides/fa/php-java/aspose.slides/fontsmanager/#getFontEmbeddingLevel) پاس ندهید، زیرا این متد به آرایه بایت نیاز دارد.

[EmbeddingLevel](https://reference.aspose.com/slides/fa/php-java/aspose.slides/embeddinglevel/) یک شمارش پرچم‌ها است که محدودیت‌های توکار شدن ذخیره‌شده در فونت را گزارش می‌دهد:
- `Installable` اجازه می‌دهد فونت توکار شود و به‌صورت دائم بر روی سیستم دیگر نصب شود، مشروط بر مجوز فونت.
- `Restricted` توکار کردن را ممنوع می‌کند مگر آنکه اجازه از صاحب قانونی فونت گرفته شود وقتی که این پرچم تنها پرچم اجازه استفاده باشد.
- `PreviewPrint` اجازه استفاده موقتی برای مشاهده و چاپ را می‌دهد؛ سند حاوی فونت باید فقط‑خواندنی باشد.
- `Editable` اجازه استفاده موقتی را می‌دهد و امکان ویرایش و ذخیره سند را فراهم می‌کند.
- `NoSubsetting` محدودیتی اضافی است که توکار کردن تنها زیرمجموعه‌ای از گلیف‌ها را منع می‌کند. وقتی این پرچم حضور داشته باشد، تمام کاراکترها باید توکار شوند.
- `BitmapOnly` محدودیتی اضافی است که فقط توکار کردن ضربات بیت‌مپ را اجازه می‌دهد، نه داده‌های خطوط. اگر فونت هیچ ضربه‌ای بیت‌مپ نداشته باشد، نمی‌تواند توکار شود.

چهار مقدار اول مجوز استفاده را توصیف می‌کنند، در حالی که `NoSubsetting` و `BitmapOnly` می‌توانند با آن‌ها ترکیب شوند. اصلاح‌کننده‌ها را با عملیات بیتی بررسی کنید. چون مقدار `Installable` صفر است، بیت‌های مجوز استفاده را ماسک کنید و نتیجه را با `Installable` مقایسه کنید به‌جای اینکه آن را به‌عنوان پرچم بررسی کنید. فونت‌های فعلی باید حداکثر یک بیت مجوز استفاده تنظیم کنند. برای سازگاری با فونت‌های قدیمی که بیش از یک بیت تنظیم کرده‌اند، کمک‌کدی که در زیر است، کم‌ترین محدودیت را انتخاب می‌کند: ابتدا `Editable`، سپس `PreviewPrint` و در نهایت `Restricted`.

مثال زیر داده‌های معمولی، بولد، ایتالیک و بولد‑ایتالیک موجود برای هر فونتی که توسط `FontsManager::getFonts` بازگردانده می‌شود را بررسی می‌کند. سبک‌های غیرقابل دسترس، فونت‌های محدود شده، فونت‌های فقط‑بیت‌مپ، فونت‌های محدود به پیش‌نمایش و چاپ (چون خروجی ویرایش‌پذیر می‌ماند) و فونت‌هایی که قبلاً توکار شده‌اند را نادیده می‌گیرد. اگر هر سبک موجود دارای `NoSubsetting` باشد، تمام کاراکترهای آن خانواده فونت توکار می‌شود.

```php
use aspose\slides\EmbedFontCharacters;
use aspose\slides\EmbeddingLevel;
use aspose\slides\FontStyleType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

function getUsagePermission($level) {
    $permissionMask = EmbeddingLevel::Restricted | EmbeddingLevel::PreviewPrint | EmbeddingLevel::Editable;
    $permissions = $level & $permissionMask;

    if (($permissions & EmbeddingLevel::Editable) !== 0) {
        return EmbeddingLevel::Editable;
    }

    if (($permissions & EmbeddingLevel::PreviewPrint) !== 0) {
        return EmbeddingLevel::PreviewPrint;
    }

    if (($permissions & EmbeddingLevel::Restricted) !== 0) {
        return EmbeddingLevel::Restricted;
    }

    return EmbeddingLevel::Installable;
}

$presentation = new Presentation("Fonts.pptx");
try {
    $fontsManager = $presentation->getFontsManager();
    $fontStyles = [
        FontStyleType::Regular,
        FontStyleType::Bold,
        FontStyleType::Italic,
        FontStyleType::Bold | FontStyleType::Italic
    ];

    $embeddedFontNames = [];
    foreach ($fontsManager->getEmbeddedFonts() as $embeddedFont) {
        $fontName = java_values($embeddedFont->getFontName());
        $embeddedFontNames[strtolower($fontName)] = true;
    }

    $fontsToEmbed = [];
    $embeddingRules = [];
    foreach ($fontsManager->getFonts() as $font) {
        $fontName = java_values($font->getFontName());
        if (isset($embeddedFontNames[strtolower($fontName)])) {
            echo $fontName . ": already embedded." . PHP_EOL;
            continue;
        }

        $hasAvailableData = false;
        $allAvailableStylesCanBeEmbedded = true;
        $previewPrintOnly = false;
        $requiresFullFont = false;

        foreach ($fontStyles as $fontStyle) {
            $fontBytes = $fontsManager->getFontBytes($font, $fontStyle);
            if (java_is_null($fontBytes)) {
                echo $fontName . " (" . $fontStyle . "): font data is unavailable." . PHP_EOL;
                continue;
            }

            $hasAvailableData = true;
            $embeddingLevel = java_values($fontsManager->getFontEmbeddingLevel($fontBytes, $fontName));
            $usagePermission = getUsagePermission($embeddingLevel);
            $noSubsetting = ($embeddingLevel & EmbeddingLevel::NoSubsetting) !== 0;
            $bitmapOnly = ($embeddingLevel & EmbeddingLevel::BitmapOnly) !== 0;

            $requiresFullFont = $requiresFullFont || $noSubsetting;
            $previewPrintOnly = $previewPrintOnly || $usagePermission === EmbeddingLevel::PreviewPrint;
            $allAvailableStylesCanBeEmbedded = $allAvailableStylesCanBeEmbedded && $usagePermission !== EmbeddingLevel::Restricted && !$bitmapOnly;

            echo $fontName . " (" . $fontStyle . "): " . $embeddingLevel . "." . PHP_EOL;
        }

        if (!$hasAvailableData) {
            echo $fontName . ": skipped because no requested style is available." . PHP_EOL;
        } elseif (!$allAvailableStylesCanBeEmbedded) {
            echo $fontName . ": skipped because at least one available style does not permit outline embedding." . PHP_EOL;
        } elseif ($previewPrintOnly) {
            echo $fontName . ": skipped because this example produces an editable presentation." . PHP_EOL;
        } else {
            $rule = $requiresFullFont ? EmbedFontCharacters::All : EmbedFontCharacters::OnlyUsed;
            $fontsToEmbed[] = $font;
            $embeddingRules[] = $rule;
        }
    }

    for ($i = 0; $i < count($fontsToEmbed); $i++) {
        $fontsManager->addEmbeddedFont($fontsToEmbed[$i], $embeddingRules[$i]);
    }

    $presentation->save("WithAuditedFonts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

این بازرسی محدودیت‌های کدگذاری‌شده در هر فایل فونت را گزارش می‌دهد. این امر مجوزی اعطا نمی‌کند، اثبات نمی‌کند که فونت را به‌صورت قانونی به‌دست آورده‌اید و جای بررسی توافق‌نامه مجوز فونت پیش از توزیع نسخه توکار را نمی‌گیرد.

## **افزودن فونت‌های توکار**

از [FontsManager::addEmbeddedFont](https://reference.aspose.com/slides/fa/php-java/aspose.slides/fontsmanager/#addEmbeddedFont) برای توکار کردن یک فونت استفاده کنید. بارگذاری‌های این متد می‌توانند یا یک شیء [FontData](https://reference.aspose.com/slides/fa/php-java/aspose.slides/fontdata/) یا آرایه بایتی حاوی داده‌های فونت را بپذیرند. شمارش [EmbedFontCharacters](https://reference.aspose.com/slides/fa/php-java/aspose.slides/embedfontcharacters/) تعیین می‌کند که کدام کاراکترها گنجانده شوند:
- [All](https://reference.aspose.com/slides/fa/php-java/aspose.slides/embedfontcharacters/) تمام کاراکترهای فونت را توکار می‌کند. از این گزینه وقتی دریافت‌کنندگان نیاز به ویرایش ارائه و وارد کردن متن جدید دارند استفاده کنید.
- [OnlyUsed](https://reference.aspose.com/slides/fa/php-java/aspose.slides/embedfontcharacters/) فقط کاراکترهای استفاده‌شده در ارائه را توکار می‌کند تا حجم فایل کاهش یابد. برای یک ارائه نهایی که عمدتاً برای مشاهده است این گزینه را انتخاب کنید.

مثال زیر از [FontsManager::getFonts](https://reference.aspose.com/slides/fa/php-java/aspose.slides/fontsmanager/#getFonts) برای بازیابی فونت‌های استفاده‌شده در `Fonts.pptx` استفاده می‌کند و آن‌هایی که هنوز توکار نشده‌اند را توکار می‌کند. فونت‌های مورد افزودن باید بر روی ماشینی که کد را اجرا می‌کند موجود باشند. فونت‌های توکار موجود مجموعه کاراکترهای فعلی خود را حفظ می‌کنند.

```php
use aspose\slides\EmbedFontCharacters;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Fonts.pptx");
try {
    $fontsManager = $presentation->getFontsManager();
    $allFonts = $fontsManager->getFonts();
    $embeddedFonts = $fontsManager->getEmbeddedFonts();
    $embeddedFontNames = [];

    foreach ($embeddedFonts as $embeddedFont) {
        $fontName = java_values($embeddedFont->getFontName());
        $embeddedFontNames[strtolower($fontName)] = true;
    }

    foreach ($allFonts as $font) {
        $fontName = java_values($font->getFontName());
        $normalizedFontName = strtolower($fontName);
        if (!isset($embeddedFontNames[$normalizedFontName])) {
            $fontsManager->addEmbeddedFont($font, EmbedFontCharacters::All);
            $embeddedFontNames[$normalizedFontName] = true;
        }
    }

    $presentation->save("WithEmbeddedFonts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **فشرده‌سازی فونت‌های توکار**

[Compress::compressEmbeddedFonts](https://reference.aspose.com/slides/fa/php-java/aspose.slides/compress/#compressEmbeddedFonts) داده‌های فونت توکار را با حذف کاراکترهای استفاده‌نشده کاهش می‌دهد. این متد بر روی فونت‌هایی که قبلاً توکار شده‌اند عمل می‌کند، بنابراین کاهش اندازه بستگی به مقدار داده‌های فونتی که استفاده نشده در ارائه دارد.

مثال زیر فونت‌های موجود در `EmbeddedFonts.pptx` را فشرده می‌کند و نتیجه را به‌عنوان یک فایل جداگانه ذخیره می‌نماید:

```php
use aspose\slides\Compress;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("EmbeddedFonts.pptx");
try {
    Compress::compressEmbeddedFonts($presentation);
    $presentation->save("CompressedEmbeddedFonts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

اگر دریافت‌کنندگان ممکن است بعداً نیاز به افزودن متن داشته باشند، فایل اصلی را نگه دارید. کاراکترهای حذف‌شده در حین فشرده‌سازی دیگر از فونت توکار در دسترس نیستند، حتی اگر در ابتدا تمام کاراکترها را توکار کرده باشید.

## **سوالات متداول**

**چگونه می‌توانم بررسی کنم که آیا یک فونت توکار در هنگام رندر همچنان جایگزین می‌شود یا نه؟**

در محیطی که ارائه را رندر می‌کنید، از [FontsManager::getSubstitutions](https://reference.aspose.com/slides/fa/php-java/aspose.slides/fontsmanager/#getSubstitutions) فراخوانی کنید تا ببینید Aspose.Slides چه فونت‌هایی را جایگزین خواهد کرد. همچنین تنظیمات [جایگزینی فونت](/slides/fa/php-java/font-substitution/) و قوانین [پشتیبان فونت](/slides/fa/php-java/fallback-font/) را بررسی کنید. پشتیبان فونت کاراکترهای مفقود را مدیریت می‌کند، بنابراین توکار کردن یک فونت کاراکترهایی را که خود فونت شامل آنها نیست حل نمی‌کند.

**آیا باید فونت‌های رایج مانند Arial و Calibri را توکار کنم؟**

تصمیم‌گیری را بر اساس محیط هدف انجام دهید. اگر فونت‌های مورد نیاز بر روی هر دستگاهی که ارائه را باز یا رندر می‌کند موجود باشد، توکار کردن آنها ممکن است حجم فایل را بی‌نیاز افزایش دهد. اگر دریافت‌کنندگان یا سرورها ممکن است آن فونت‌ها را نداشته باشند، توکار کردن آنها می‌تواند به حفظ ظاهر موردنظر کمک کند، مشروط بر این که مجوزهایشان اجازه این کار را بدهد.