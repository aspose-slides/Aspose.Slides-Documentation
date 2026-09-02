---
title: پیکربندی جایگزینی فونت در ارائه‌ها با استفاده از PHP
linktitle: جایگزینی فونت
type: docs
weight: 70
url: /fa/php-java/font-substitution/
keywords:
- فونت
- فونت جایگزین
- جایگزینی فونت
- جایگزینی فونت
- جایگزینی فونت
- قانون جایگزینی
- قانون جایگزینی
- PowerPoint
- OpenDocument
- ارائه
- PHP
- Aspose.Slides
description: "قوانین جایگزینی فونت را پیکربندی کنید و قلم‌های جایگزین شده را در Aspose.Slides برای PHP از طریق Java هنگام رندر یا تبدیل ارائه‌های PowerPoint و OpenDocument بررسی کنید."
---
## **بررسی کلی**

جایگزینی قلم به Aspose.Slides این امکان را می‌دهد که در هنگام رندر یا تبدیل یک ارائه، از یک قلم موجود به جای قلم غیرقابل دسترسی استفاده کند. این جایگزینی بر خروجی رندر تأثیر می‌گذارد؛ اما قلم تخصیص‑دهی‌شده به محتوای ارائه را تغییر نمی‌دهد.

می‌توانید قلمی را که هنگام عدم دسترس بودن قلم خاصی باید استفاده شود تعریف کنید و جایگزینی‌هایی را که Aspose.Slides در هنگام رندر انجام می‌دهد بررسی کنید. این باعث می‌شود خروجی در محیط‌های مختلف با قلم‌های نصب‌شده متفاوت، یکنواخت بماند.

## **دریافت جایگزینی‌های قلم**

از روش [FontsManager::getSubstitutions](https://reference.aspose.com/slides/fa/php-java/aspose.slides/fontsmanager/getsubstitutions/) برای تعیین اینکه کدام قلم‌ها هنگام رندر ارائه جایگزین می‌شوند استفاده کنید. این روش اشیای [FontSubstitutionInfo](https://reference.aspose.com/slides/fa/php-java/aspose.slides/fontsubstitutioninfo/) را برمی‌گرداند که نام‌های قلم اصلی و جایگزین را شناسایی می‌کند.

مثال زیر در PHP تمام جایگزینی‌های قلم برای یک ارائه را فهرست می‌کند:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("Presentation.pptx");
try {
    $enumerator = $presentation->getFontsManager()->getSubstitutions()->iterator();
    try {
        while (java_values($enumerator->hasNext())) {
            $substitution = $enumerator->next();
            $originalFontName = java_values($substitution->getOriginalFontName());
            $substitutedFontName = java_values($substitution->getSubstitutedFontName());
            echo $originalFontName . " -> " . $substitutedFontName . PHP_EOL;
        }
    } finally {
        $enumerator->dispose();
    }
} finally {
    $presentation->dispose();
}
```

## **دریافت جایگزینی‌های قلم برای اسلایدهای انتخاب شده**

از overload روش [FontsManager::getSubstitutions](https://reference.aspose.com/slides/fa/php-java/aspose.slides/fontsmanager/getsubstitutions/) با آرگومان `int[] slides` استفاده کنید تا فقط جایگزینی‌های مورد نیاز برای رندر اسلایدهای خاص را بررسی کنید. این در صورتی مفید است که بخواهید بخشی از یک ارائه را رندر یا استخراج کنید، یک ارائه بزرگ را به صورت تدریجی بررسی کنید، اسلایدهایی که به قلم‌های غیرقابل دسترس وابسته‌اند پیدا کنید، بستهٔ قلمی حداقل برای سرور یا کانتینر تهیه کنید یا اختلافات رندر را بدون پردازش اسلایدهای نامرتبط تشخیص دهید.

آرایه `slides` شامل ایندکس‌های اسلاید به صورت یک‌پایه است: `1` اولین اسلاید را شناسایی می‌کند. در مقابل، دسترسی‌گر مجموعهٔ [Presentation::getSlides](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/#getSlides) از ایندکس صفر‑پایه استفاده می‌کند، بنابراین همان اسلاید به صورت `$presentation->getSlides()->get_Item(0)` دسترسی پیدا می‌کند. هنگام ساخت آرایه این تفاوت را در نظر بگیرید تا از خطای یک‑به‑یک دوری کنید.

این overload را از طریق روش [Presentation::getFontsManager](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/#getFontsManager) فراخوانی کنید. این فقط جایگزینی‌هایی را برمی‌گرداند که در زمان رندر اسلایدهای انتخاب شده تعیین شده‌اند. هر نتیجه یک شیء [FontSubstitutionInfo](https://reference.aspose.com/slides/fa/php-java/aspose.slides/fontsubstitutioninfo/) است که نام‌های قلم اصلی و جایگزین را شامل می‌شود. نتیجه منعکس‌کنندهٔ محیط قلم فعلی، قوانین fallback پیکربندی‌شده، قوانین جایگزینی ذخیره‌شده در یک [FontSubstRuleCollection](https://reference.aspose.com/slides/fa/php-java/aspose.slides/fontsubstrulecollection/) و [قلم‌های بارگذاری‌شده به‌صورت خارجی](/slides/fa/php-java/custom-font/) است.

یک جایگزینی می‌تواند توسط بیش از یک اسلاید انتخاب شده مورد نیاز باشد. هنگام ایجاد موجودی قلم یا گزارش preflight، نتایج را حذف تکرار کنید. مثال زیر هر جایگزینی برگردانده‌شده را گزارش می‌کند و سپس فهرست مرتب‌شده‌ای از نگاشت‌های قلم منحصر به‌فرد ایجاد می‌کند:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("Presentation.pptx");
try {
    $selectedSlides = [1, 3, 5];
    $substitutions = [];
    $enumerator = $presentation->getFontsManager()->getSubstitutions($selectedSlides)->iterator();
    try {
        while (java_values($enumerator->hasNext())) {
            $substitutions[] = $enumerator->next();
        }
    } finally {
        $enumerator->dispose();
    }

    echo "Substitutions for the selected slides:" . PHP_EOL;
    foreach ($substitutions as $substitution) {
        $originalFontName = java_values($substitution->getOriginalFontName());
        $substitutedFontName = java_values($substitution->getSubstitutedFontName());
        echo $originalFontName . " -> " . $substitutedFontName . PHP_EOL;
    }

    $sortedPreflightEntries = [];
    foreach ($substitutions as $substitution) {
        $originalFontName = java_values($substitution->getOriginalFontName());
        $substitutedFontName = java_values($substitution->getSubstitutedFontName());
        $entry = $originalFontName . " -> " . $substitutedFontName;
        $sortedPreflightEntries[strtolower($entry)] = $entry;
    }
    ksort($sortedPreflightEntries, SORT_NATURAL | SORT_FLAG_CASE);

    echo "Deduplicated font preflight report:" . PHP_EOL;
    foreach ($sortedPreflightEntries as $entry) {
        echo $entry . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

کلاس [FontsManager](https://reference.aspose.com/slides/fa/php-java/aspose.slides/fontsmanager/) هر دو overload را فراهم می‌کند. یکی را بر مبنای دامنهٔ عملیات رندر انتخاب کنید:

| بارگذاری | زمان استفاده |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/fa/php-java/aspose.slides/fontsmanager/getsubstitutions/) بدون آرگومان | اگر به جایگزینی‌ها برای کل ارائه نیاز دارید. |
| [getSubstitutions](https://reference.aspose.com/slides/fa/php-java/aspose.slides/fontsmanager/getsubstitutions/) با `int[] slides` | اگر به جایگزینی‌ها برای محدودهٔ انتخابی، بررسی تدریجی یا استخراج جزئی نیاز دارید. |

## **تنظیم قوانین جایگزینی قلم**

برای مشخص کردن قلمی که Aspose.Slides باید هنگام عدم دسترس بودن قلم منبع استفاده کند:

1. ارائه را بارگذاری کنید.
2. تعریف‌های قلم برای قلم منبع و جایگزین ایجاد کنید.
3. یک [FontSubstRule](https://reference.aspose.com/slides/fa/php-java/aspose.slides/fontsubstrule/) با شرط [WhenInaccessible](https://reference.aspose.com/slides/fa/php-java/aspose.slides/fontsubstcondition/) ایجاد کنید.
4. این قانون را به یک [FontSubstRuleCollection](https://reference.aspose.com/slides/fa/php-java/aspose.slides/fontsubstrulecollection/) اضافه کنید.
5. مجموعه را با استفاده از روش [FontsManager::setFontSubstRuleList](https://reference.aspose.com/slides/fa/php-java/aspose.slides/fontsmanager/setfontsubstrulelist/) اختصاص دهید.
6. ارائه را رندر یا تبدیل کنید.

مثال زیر در PHP `Arial` را به جای `SomeRareFont` استفاده می‌کند وقتی `SomeRareFont` در دسترس نیست و سپس اولین اسلاید را رندر می‌کند تا نتیجه را تأیید کند. قلم جایگزین باید برای Aspose.Slides قابل دسترس باشد.

```php
use aspose\slides\FontData;
use aspose\slides\FontSubstCondition;
use aspose\slides\FontSubstRule;
use aspose\slides\FontSubstRuleCollection;
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$presentation = new Presentation("Fonts.pptx");
try {
    $sourceFont = new FontData("SomeRareFont");
    $substituteFont = new FontData("Arial");
    $substitutionRule = new FontSubstRule($sourceFont, $substituteFont, FontSubstCondition::WhenInaccessible);

    $substitutionRules = new FontSubstRuleCollection();
    $substitutionRules->add($substitutionRule);
    $presentation->getFontsManager()->setFontSubstRuleList($substitutionRules);

    $image = $presentation->getSlides()->get_Item(0)->getImage(1.0, 1.0);
    try {
        $image->save("slide.jpg", ImageFormat::Jpeg);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}
برای تغییر بدون قید و شرط قلم‌های استفاده‌شده در سراسر یک ارائه، به [Font Replacement](/slides/fa/php-java/font-replacement/) مراجعه کنید.
{{% /alert %}}

## **محدودیت‌ها برای قلم‌های معادلات ریاضی**

قوانین جایگزینی قلم بخشی از فرآیند استاندارد انتخاب قلم هستند که در هنگام رندر و تبدیل استفاده می‌شود. این قوانین برای متن عادی کار می‌کنند وقتی Aspose.Slides می‌تواند قلم غیرقابل دسترسی را با قلم موجود تعریف‌شده توسط قانون جایگزین کند.

معادلات Office Math نیاز اضافی دارند. اگر معادله‌ای از **Cambria Math** استفاده کند، Aspose.Slides ممکن است به همان قلم دقیق برای محاسبه و رندر طرح‌بندی معادله نیاز داشته باشد. قاعده‌ای که قلم ریاضی دیگری مانند **STIX Two Math** را جایگزین می‌کند، نمی‌تواند **Cambria Math** را برای این منظور جایگزین کند و ممکن است رندر هنوز گزارش دهد که **Cambria Math** لازم است.

برای رندر یا تبدیل چنین ارائه‌ای، **Cambria Math** را برای Aspose.Slides در دسترس قرار دهید. آن را در سیستم‌عامل نصب کنید یا به‌عنوان یک [قلم خارجی](/slides/fa/php-java/custom-font/) بارگذاری کنید.

این محدودیت فقط در طرح‌بندی معادله اعمال می‌شود. قوانین جایگزینی توضیح‌داده‌شده در بالا همچنان برای متن عادی ارائه اعمال می‌شوند.

## **سوالات متداول**

**تفاوت جایگزینی قلم (Font replacement) و جایگزینی فونت (Font substitution) چیست؟**

[Font replacement](/slides/fa/php-java/font-replacement/) به‌طور عمدی یک قلم را در سراسر ارائه با قلم دیگری تعویض می‌کند. جایگزینی قلم (font substitution) در زمان رندر یک قلم برای خروجی رندر شده انتخاب می‌کند وقتی شرط پیکربندی‑شده برقرار باشد، مانند زمانی که قلم اصلی در دسترس نباشد.

**قوانین جایگزینی چه زمانی اعمال می‌شوند؟**

قوانین در [دنبالهٔ انتخاب قلم](/slides/fa/php-java/font-selection-sequence/) در طول رندر و تبدیل مشارکت می‌کنند. با `WhenInaccessible`، یک قانون فقط زمانی استفاده می‌شود که Aspose.Slides نتواند به قلم منبع دسترسی پیدا کند.

**اگر قلمی موجود نباشد و قانون جایگزینی پیکربندی نشده باشد چه می‌شود؟**

Aspose.Slides نزدیک‌ترین قلم موجود را بر اساس فرآیند انتخاب قلم خود انتخاب می‌کند. نتایج به قلم‌های موجود در محیط زمان اجرا بستگی دارد.

**آیا می‌توانم قلم‌های خارجی را بارگذاری کنم تا از جایگزینی جلوگیری کنم؟**

بله. می‌توانید [قلم‌های خارجی را بارگذاری](/slides/fa/php-java/custom-font/) کنید تا Aspose.Slides در زمان رندر و تبدیل از آن‌ها استفاده کند.

**آیا Aspose قلم‌ها را همراه کتابخانه توزیع می‌کند؟**

خیر. مسئولیت فراهم‌کردن قلم‌ها و رعایت مجوزهای آن‌ها بر عهدهٔ شماست.

**آیا نتایج جایگزینی بین Windows، Linux و macOS متفاوت است؟**

بله. قلم‌های نصب‌شده و مکان‌های جستجوی قلم در هر سیستم‌عامل متفاوت است، بنابراین قلمی که در یک ماشین در دسترس است ممکن است در ماشین دیگر نیاز به جایگزینی داشته باشد.

**چگونه می‌توان انتخاب قلم را در تبدیل‌های دسته‌ای یکسان کرد؟**

از همان فایل‌ها و نسخه‌های قلم روی هر ماشین یا کانتینر استفاده کنید، [قلم‌های خارجی مورد نیاز را بارگذاری](/slides/fa/php-java/custom-font/) کنید و در صورت اجازهٔ مجوز، [قلم‌ها را جاسازی](/slides/fa/php-java/embedded-font/) کنید. می‌توانید قبل از خروجی‌گیری از [FontsManager::getSubstitutions](https://reference.aspose.com/slides/fa/php-java/aspose.slides/fontsmanager/getsubstitutions/) برای شناسایی جایگزینی‌های غیرمنتظره استفاده کنید.