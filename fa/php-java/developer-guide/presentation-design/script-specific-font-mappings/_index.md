---
title: مدیریت قلم‌های تم مخصوص اسکریپت در PHP
linktitle: قلم‌های تم مخصوص اسکریپت
type: docs
weight: 15
url: /fa/php-java/script-specific-font-mappings/
keywords:
- قلم مخصوص اسکریپت
- نگاشت قلم تم
- ارائه چندزبانه
- سیستم نوشتاری
- قلم سیریلیک
- قلم عربی
- قلم ژاپنی
- قلم گرجی
- قلم ثانا
- PowerPoint
- ارائه
- PHP
- Aspose.Slides
description: "بررسی، افزودن، جایگزینی و حذف نگاشت‌های قلم مخصوص اسکریپت در تم‌های PowerPoint با Aspose.Slides برای PHP از طریق Java."
---
## **نمای کلی**

یک تم ارائه می‌تواند خانواده‌های قلم متفاوتی را برای سیستم‌های نوشتاری مختلف انتخاب کند. این امکان باعث می‌شود متنی چندزبانه که همچنان از قلم‌های تم استفاده می‌کند، یک طرح قلم هماهنگ داشته باشد و در عین حال برای سیریلیک، عربی، ژاپنی، گرجی، ثانا و سایر اسکریپت‌ها از قلم‌های مناسب استفاده شود.

تم [FontScheme](https://reference.aspose.com/slides/fa/php-java/aspose.slides/fontscheme/) شامل یک مجموعه قلم اصلی (معمولاً برای عناوین) و یک مجموعه قلم فرعی (معمولاً برای متن بدنه) است. علاوه بر تنظیمات قلم‌های لاتین و شرق‑آسیا، هر دو مجموعه [Fonts](https://reference.aspose.com/slides/fa/php-java/aspose.slides/fonts/) نگاشت‌هایی از برچسب‌های سیستم نوشتاری به نام‌های خانواده قلم ارائه می‌دهند.

این مقاله نشان می‌دهد چگونه می‌توان این نگاشت‌ها را در تم اصلی ارائه بررسی و اصلاح کرد و تأیید کرد که تغییرات پس از ذخیره و بارگذاری مجدد باقی می‌مانند.

## **درک برچسب‌های اسکریپت**

متدهای قلم اسکریپت از برچسب‌های چهار حرفی BCP 47 برای شناسایی سیستم‌های نوشتاری استفاده می‌کنند. مقادیر رایج شامل:

| برچسب اسکریپت | سیستم نوشتاری |
|---|---|
| `Cyrl` | سیریلیک |
| `Arab` | عربی |
| `Hans` | چینی ساده |
| `Jpan` | ژاپنی |
| `Geor` | گرجی |
| `Thaa` | ثانا |

این نگاشت‌ها متعلق به طرح قلم تم هستند، نه به بخش‌های متنی فردی. یک ارائه می‌تواند نگاشت‌های متفاوتی برای مجموعه‌های اصلی و فرعی تعریف کند و ممکن است برای برخی اسکریپت‌ها نگاشت نداشته باشد.

## **دسترسی و بررسی نگاشت‌های قلم اسکریپت**

از [Presentation::getMasterTheme](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/#getMasterTheme) برای دسترسی به تم سطح ارائه استفاده کنید. متدهای [MasterTheme::getFontScheme](https://reference.aspose.com/slides/fa/php-java/aspose.slides/mastertheme/#getFontScheme)، [FontScheme::getMajor](https://reference.aspose.com/slides/fa/php-java/aspose.slides/fontscheme/#getMajor) و [FontScheme::getMinor](https://reference.aspose.com/slides/fa/php-java/aspose.slides/fontscheme/#getMinor) دسترسی به دو مجموعه [Fonts](https://reference.aspose.com/slides/fa/php-java/aspose.slides/fonts/) را فراهم می‌آورند.

برای بازیابی تمام نگاشت‌ها از یک مجموعه، [Fonts::getScriptFontMap](https://reference.aspose.com/slides/fa/php-java/aspose.slides/fonts/#getScriptFontMap) را فراخوانی کنید. برای جستجوی یک سیستم نوشتاری خاص، [Fonts::getScriptFont](https://reference.aspose.com/slides/fa/php-java/aspose.slides/fonts/#getScriptFont) را با برچسب اسکریپت آن صدا بزنید. `Fonts::getScriptFont` در صورتی که آن مجموعه نگاشت درخواست‌شده را تعریف نکرده باشد، `null` بر می‌گرداند.

## **اصلاح نگاشت‌ها و تأیید پایداری**

از [Fonts::setScriptFont](https://reference.aspose.com/slides/fa/php-java/aspose.slides/fonts/#setScriptFont) برای ایجاد یا جایگزینی خانواده قلم فعلی استفاده کنید. برای حذف یک نگاشت، [Fonts::removeScriptFont](https://reference.aspose.com/slides/fa/php-java/aspose.slides/fonts/#removeScriptFont) را به کار ببرید.

مثال جامع زیر همهٔ نگاشت‌های اصلی و فرعی موجود را می‌خواند، قلم اصلی ژاپنی را جستجو می‌کند، قلم اصلی سیریلیک را تغییر می‌دهد، نگاشت فرعی ثانا را حذف می‌کند، ارائه را ذخیره می‌نماید و سپس برای تأیید هر دو تغییر آن را باز می‌خواند. برای اینکه مرحلهٔ حذف مستقل از تم اولیه باشد، مثال ابتدا تنها در زمانی که نگاشت ثانا وجود نداشته باشد، یک نگاشت ثانا ایجاد می‌کند.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $fontScheme = $presentation->getMasterTheme()->getFontScheme();
    $majorFonts = $fontScheme->getMajor();
    $minorFonts = $fontScheme->getMinor();

    echo "Existing major mappings:" . PHP_EOL;
    $majorMappings = $majorFonts->getScriptFontMap()->iterator();
    while (java_values($majorMappings->hasNext())) {
        $mapping = $majorMappings->next();
        echo "  " . java_values($mapping->getKey()) . ": " . java_values($mapping->getValue()) . PHP_EOL;
    }

    echo "Existing minor mappings:" . PHP_EOL;
    $minorMappings = $minorFonts->getScriptFontMap()->iterator();
    while (java_values($minorMappings->hasNext())) {
        $mapping = $minorMappings->next();
        echo "  " . java_values($mapping->getKey()) . ": " . java_values($mapping->getValue()) . PHP_EOL;
    }

    $japaneseFont = $majorFonts->getScriptFont("Jpan");
    if (java_is_null($japaneseFont)) {
        echo "No major Japanese font is defined." . PHP_EOL;
    } else {
        echo "Major Japanese font: " . java_values($japaneseFont) . PHP_EOL;
    }

    $majorFonts->setScriptFont("Cyrl", "Arial");

    if (java_is_null($minorFonts->getScriptFont("Thaa"))) {
        $minorFonts->setScriptFont("Thaa", "Arial");
    }

    $minorFonts->removeScriptFont("Thaa");
    $presentation->save("script-font-mappings.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

$savedPresentation = new Presentation("script-font-mappings.pptx");
try {
    $savedMajorFonts = $savedPresentation->getMasterTheme()->getFontScheme()->getMajor();
    $savedMinorFonts = $savedPresentation->getMasterTheme()->getFontScheme()->getMinor();
    $savedCyrillicFont = $savedMajorFonts->getScriptFont("Cyrl");
    $savedThaanaFont = $savedMinorFonts->getScriptFont("Thaa");

    if (!java_is_null($savedCyrillicFont) && java_values($savedCyrillicFont) === "Arial") {
        echo "The Cyrillic mapping was preserved." . PHP_EOL;
    } else {
        echo "The Cyrillic mapping was not preserved." . PHP_EOL;
    }

    if (java_is_null($savedThaanaFont)) {
        echo "The Thaana mapping removal was preserved." . PHP_EOL;
    } else {
        echo "The Thaana mapping still exists." . PHP_EOL;
    }
} finally {
    $savedPresentation->dispose();
}
```

تأیید از همان رفتار `null` مانند یک جستجوی عادی استفاده می‌کند: پس از ذخیرهٔ حذف، `Fonts::getScriptFont("Thaa")` برای مجموعهٔ فرعی `null` بر می‌گرداند.

## **تمایز نگاشت‌های تم از سایر تنظیمات قلم**

نگاشت‌های تم مخصوص اسکریپت در انتخاب قلم شرکت می‌کنند، اما مسأله‌ای متفاوت را نسبت به قالب‌بندی مستقیم متن، جابجایی و پس‌زمینه حل می‌کنند:

| مکانیزم | هدف | تأثیر تغییر یک نگاشت تم |
|---|---|---|
| نگاشت قلم تم مخصوص اسکریپت | انتخاب یک قلم تم اصلی یا فرعی برای یک سیستم نوشتاری. | متنی که همچنان از قلم تم مربوطه استفاده می‌کند می‌تواند به خانوادهٔ قلم جدید تبدیل شود. |
| قلم اختصاصی به یک بخش متن | خانوادهٔ قلم درخواستی را برای آن بخش ثابت می‌کند و به تم تکیه نمی‌کند. | ممکن است بخش بدون تغییر بماند، زیرا قالب‌بندی مستقیم آن انتخاب تم را نادیده می‌گیرد. |
| جابجایی قلم | وقتی قلم درخواست‌شده در دسترس نیست یا قانون جابجایی اعمال می‌شود، قلم دیگری جایگزین می‌شود. | پس از درخواست قلم عمل می‌کند؛ نگاشت اسکریپت تم را بازتعریف نمی‌کند. |
| پس‌زمینهٔ قلم | گلیف‌های مفقودی که قلم انتخاب‌شده دربر ندارند را تأمین می‌کند، اغلب برای بازه‌های یونیکد خاص. | پوشش گلیف‌های گمشده را پر می‌کند؛ نگاشت تم ذخیره‌شده را تغییر نمی‌دهد. |

برای اطلاعات بیشتر دربارهٔ دو مکانیزم آخر، به [Font Substitution](/slides/fa/php-java/font-substitution/) و [Fallback Fonts](/slides/fa/php-java/fallback-font/) مراجعه کنید.

تغییر یک نگاشت در [Presentation::getMasterTheme](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/#getMasterTheme) فقط بر محتوایی که قالب‌بندی مؤثر آن هنوز به آن تم وابسته است، تأثیر می‌گذارد. متن می‌تواند به جای آن از یک پیش‌نویس، طرح‌بندی یا اسلاید تم‌شفاف‌سازی شده ارث‌بری کند یا از قلم اختصاصی استفاده کند. هنگام مشاهدهٔ نتایج متفاوت، سطوح آن‌ها را بررسی کنید.

## **در دسترس قرار دادن قلم‌های نگاشت‌شده و اعتبارسنجی نتیجه**

یک نگاشت اسکریپت فقط نام خانوادهٔ قلم را ذخیره می‌کند؛ قلم مربوطه را نصب یا بارگذاری نمی‌کند. برای رندر و صادرات سازگار، هر قلم نگاشت‌شده باید در محیط نصب شده باشد یا از طریق منبع سفارشی مانند [FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/fa/php-java/aspose.slides/fontsloader/#loadExternalFonts) یا [LoadOptions::getDocumentLevelFontSources](https://reference.aspose.com/slides/fa/php-java/aspose.slides/loadoptions/#getDocumentLevelFontSources) در Aspose.Slides فراهم شود. گزینه‌های بارگذاری موجود را در [Custom Fonts](/slides/fa/php-java/custom-font/) ببینید.

تأیید نگاشت ذخیره‌شده تنها این را ثابت می‌کند که تعریف تم حفظ شده است؛ نشان نمی‌دهد قلم در دسترس است، تمام گلیف‌های مورد نیاز را دارد یا چیدمان مورد نظر را تولید می‌کند. برای هر سیستم نوشتاری لازم، متن نمایشی را به تصویر یا PDF رندر کنید و خروجی را بررسی کنید. این کار قلم‌های مفقود، پوشش گلیف ناقص، رفتار پس‌زمینه و تغییرات چیدمان را پیش از توزیع ارائه شناسایی می‌کند. برای مثال‌های رندر و صادرات، به [Convert PowerPoint Presentations](/slides/fa/php-java/convert-powerpoint/) مراجعه کنید.

## **سوالات متداول**

**`Fonts::getScriptFont` وقتی اسکریپتی نگاشت نشود چه مقداری بر می‌گرداند؟**

[Fonts::getScriptFont](https://reference.aspose.com/slides/fa/php-java/aspose.slides/fonts/#getScriptFont) وقتی نگاشت اسکریپت درخواست‌شده در مجموعهٔ اصلی یا فرعی تعریف نشده باشد، `null` بر می‌گرداند.

**آیا `Fonts::setScriptFont` وقتی اسکریپت از پیش وجود دارد، نگاشت دوم ایجاد می‌کند؟**

خیر. [Fonts::setScriptFont](https://reference.aspose.com/slides/fa/php-java/aspose.slides/fonts/#setScriptFont) هنگام نبودن نگاشت آن را ایجاد می‌کند و وقتی همان برچسب اسکریپت از پیش موجود است، خانوادهٔ قلم نگاشت‌شده را جایگزین می‌کند.

**چرا تغییر یک نگاشت تم منجر به تغییر برخی متن‌ها نشد؟**

متن ممکن است قلم اختصاصی داشته باشد، از تم متفاوتی از طریق یک لغو ارث‌بری کند یا هنگام رندر تحت تأثیر جابجایی یا پس‌زمینه قرار گیرد. یک نگاشت اسکریپت در سطح ارائه فقط بر متنی که قالب‌بندی مؤثر آن هنوز به مجموعهٔ قلم تم اشاره می‌کند، کنترل دارد.

**آیا ذخیره و باز کردن مجدد برای اعتبارسنجی خروجی چندزبانه کافی است؟**

خیر. باز کردن مجدد فقط پایداری داده‌های تم را تأیید می‌کند. همچنین باید متن نمایشی از هر سیستم نوشتاری مورد نیاز را رندر کنید تا اطمینان حاصل شود قلم‌های نگاشت‌شده در دسترس هستند و گلیف‌های لازم را دارا می‌باشند.