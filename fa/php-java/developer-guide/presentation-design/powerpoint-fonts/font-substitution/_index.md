---
title: پیکربندی جایگزینی قلم در ارائه‌ها با PHP
linktitle: جایگزینی قلم
type: docs
weight: 70
url: /fa/php-java/font-substitution/
keywords:
- قلم
- قلم جایگزین
- جایگزینی قلم
- جایگزینی قلم
- تعویض قلم
- قانون جایگزینی
- قانون تعویض
- PowerPoint
- OpenDocument
- ارائه
- PHP
- Aspose.Slides
description: "قوانین جایگزینی قلم را پیکربندی کنید و قلم‌های جایگزین شده را در Aspose.Slides برای PHP از طریق Java هنگام رندر یا تبدیل ارائه‌های PowerPoint و OpenDocument بررسی کنید."
---
## **نمای کلی**

جایگزینی قلم به Aspose.Slides این امکان را می‌دهد که به‌جای قلمی که هنگام رندر یا تبدیل ارائه قابل دسترسی نیست، از یک قلم موجود استفاده کند. جایگزینی بر خروجی رندر شده تأثیر می‌گذارد؛ اما قلم اختصاص یافته به محتوای ارائه را تغییر نمی‌دهد.

می‌توانید قلم مورد استفاده را زمانی که قلم خاصی در دسترس نیست، تعریف کنید و جایگزینی‌هایی که Aspose.Slides در زمان رندر انجام می‌دهد، بررسی کنید. این کار به حفظ سازگاری خروجی در محیط‌های مختلف با قلم‌های نصب شده متفاوت کمک می‌کند.

اگر قلم در دسترس است اما قوی‌نویسی (bold) اختصاصی ندارد، بخش [Handle Fonts Without a Dedicated Bold Typeface](/slides/fa/php-java/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface) را ببینید. آن بخش توضیح می‌دهد چگونه متن تحت تأثیر را هنگام خروجی PDF رستر کنیم و پیامدهای انتخاب متن، جستجو و مقیاس‌بندی را اعلام می‌کند.

## **دریافت جایگزینی‌های قلم**

از روش [FontsManager::getSubstitutions](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/getsubstitutions/) برای تعیین اینکه کدام قلم‌ها هنگام رندر ارائه جایگزین می‌شوند، استفاده کنید. این روش اشیاء [FontSubstitutionInfo](https://reference.aspose.com/slides/php-java/aspose.slides/fontsubstitutioninfo/) را برمی‌گرداند که نام قلم اصلی و قلم جایگزین را شناسایی می‌کند.

مثال PHP زیر تمام جایگزینی‌های قلم برای یک ارائه را فهرست می‌کند:

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

## **دریافت جایگزینی‌های قلم برای اسلایدهای انتخاب‌شده**

از روش [FontsManager::getSubstitutions](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/getsubstitutions/) با آرگومان `int[] slides` برای بررسی تنها جایگزینی‌های مورد نیاز برای رندر اسلایدهای خاص استفاده کنید. این کار زمانی مفید است که بخشی از ارائه را رندر یا خروجی می‌گیرید، یک ارائه بزرگ را به‌صورت افزایشی بررسی می‌کنید، اسلایدهایی که به قلم‌های غیرقابل دسترسی وابسته‌اند را می‌یابید، بستهٔ قلمی حداقل را برای سرور یا کانتینر آماده می‌کنید، یا تفاوت‌های رندر را بدون پردازش اسلایدهای نامرتبط تشخیص می‌دهید.

آرایه `slides` شامل اندیس‌های اسلاید به‌صورت یک‌پایه است: `1` اولین اسلاید را شناسایی می‌کند. در مقابل، دسترسی به مجموعهٔ [Presentation::getSlides](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getslides/) با اندیس صفرپایه انجام می‌شود، بنابراین همان اسلاید به‌صورت `$presentation->getSlides()->get_Item(0)` دسترسی پیدا می‌کند. هنگام ساخت آرایه این تفاوت را در نظر بگیرید تا خطای «یک‑پایه‑خطا» رخ ندهد.

این overload را از طریق روش [Presentation::getFontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getfontsmanager/) فراخوانی کنید. این روش فقط جایگزینی‌هایی را برمی‌گرداند که در هنگام رندر اسلایدهای انتخاب‌شده تعیین شده‌اند. هر نتیجه یک شیء [FontSubstitutionInfo](https://reference.aspose.com/slides/php-java/aspose.slides/fontsubstitutioninfo/) است که نام قلم اصلی و قلم جایگزین را شامل می‌شود. نتیجه بازتاب‌دهندهٔ محیط قلمی فعلی، قوانین fallback پیکربندی‌شده، قوانین جایگزینی ذخیره‌شده در یک [FontSubstRuleCollection](https://reference.aspose.com/slides/php-java/aspose.slides/fontsubstrulecollection/)، و [قلم‌های بارگذاری‑شده به‌صورت خارجی](/slides/fa/php-java/custom-font/) است.

همین جایگزینی ممکن است برای بیش از یک اسلاید انتخاب‌شده لازم باشد. هنگام ایجاد فهرست موجودی قلم یا گزارش preflight نتایج را یکبار یکتا کنید. مثال زیر هر جایگزینی بازگردانده‌شده را گزارش می‌کند و سپس فهرست مرتب‌شده‌ای از نگاشت‌های قلم یکتا می‌سازد:

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

کلاس [FontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/) هر دو overload را فراهم می‌کند. یکی را بر حسب دامنهٔ عملیات رندر انتخاب کنید:

| Overload | Use it when |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/getsubstitutions/) with no arguments | شما به جایگزینی‌ها برای کل ارائه نیاز دارید. |
| [getSubstitutions](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/getsubstitutions/) with `int[] slides` | شما به جایگزینی‌ها برای بازه‌ای انتخابی، بررسی افزایشی یا خروجی جزئی نیاز دارید. |

## **تنظیم قوانین جایگزینی قلم**

برای مشخص کردن قلمی که Aspose.Slides باید هنگام عدم دسترسی به قلم منبع استفاده کند:

1. ارائه را بارگذاری کنید.
2. تعریف‌های قلم برای قلم منبع و قلم جایگزین ایجاد کنید.
3. یک [FontSubstRule](https://reference.aspose.com/slides/php-java/aspose.slides/fontsubstrule/) با شرط [WhenInaccessible](https://reference.aspose.com/slides/php-java/aspose.slides/fontsubstcondition/) ایجاد کنید.
4. قانون را به یک [FontSubstRuleCollection](https://reference.aspose.com/slides/php-java/aspose.slides/fontsubstrulecollection/) اضافه کنید.
5. مجموعه را با استفاده از روش [FontsManager::setFontSubstRuleList](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/setfontsubstrulelist/) اختصاص دهید.
6. ارائه را رندر یا تبدیل کنید.

مثال PHP زیر وقتی `SomeRareFont` در دسترس نیست، `Arial` را به‌جای آن جایگزین می‌کند و سپس اولین اسلاید را رندر می‌کند تا نتیجه را بررسی کند. قلم جایگزین باید برای Aspose.Slides در دسترس باشد.

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
برای تغییر بدون شرط قلم‌های مورد استفاده در تمام ارائه، به [Font Replacement](/slides/fa/php-java/font-replacement/) مراجعه کنید.
{{% /alert %}}

## **محدودیت‌ها برای قلم‌های معادلات ریاضی**

قوانین جایگزینی قلم بخشی از فرایند استاندارد انتخاب قلم هستند که در زمان رندر و تبدیل به‌کار می‌روند. آن‌ها برای متن عادی کار می‌کنند؛ زمانی که Aspose.Slides می‌تواند یک قلم غیرقابل دسترسی را با قلم موجود تعریف‌شده در قانون جایگزین کند.

معادلات Office Math یک نیاز اضافی دارند. اگر معادله‌ای از **Cambria Math** استفاده کند، Aspose.Slides ممکن است برای محاسبه و رندر چیدمان معادله به دقیقاً همان قلم نیاز داشته باشد. قانون جایگزینی که قلم ریاضی دیگری مانند **STIX Two Math** را جایگزین می‌کند، نمی‌تواند **Cambria Math** را برای این منظور تعویض کند و رندر ممکن است همچنان گزارش دهد که **Cambria Math** مورد نیاز است.

برای رندر یا تبدیل چنین ارائه‌ای، **Cambria Math** را برای Aspose.Slides در دسترس قرار دهید. آن را در سیستم‌عامل نصب کنید یا به‌عنوان یک [external font](/slides/fa/php-java/custom-font/) بارگذاری کنید.

این محدودیت به چیدمان معادله اعمال می‌شود. قوانین جایگزینی که در بالا توضیح داده شد همچنان برای متن عادی ارائه معتبر هستند.

## **سؤال‌های متداول**

**تفاوت بین جایگزینی قلم و جایگزینی کامل قلم چیست؟**

[Font replacement](/slides/fa/php-java/font-replacement/) به‌طور عمدی یک قلم را در سراسر ارائه با قلم دیگر تعویض می‌کند. جایگزینی قلم، قلمی را برای خروجی رندر شده انتخاب می‌کند وقتی شرط پیکربندی‌شده برآورده شود، مانند عدم دسترسی به قلم اصلی.

**قوانین جایگزینی چه زمانی اعمال می‌شوند؟**

قوانین در [font selection sequence](/slides/fa/php-java/font-selection-sequence/) هنگام رندر و تبدیل شرکت می‌کنند. با `WhenInaccessible`، قانون فقط زمانی استفاده می‌شود که Aspose.Slides نتواند به قلم منبع دسترسی پیدا کند.

**اگر قلمی موجود نباشد و قانون جایگزینی تنظیم نشده باشد چه می‌شود؟**

Aspose.Slides نزدیک‌ترین قلم موجود را بر اساس فرایند انتخاب قلم خود انتخاب می‌کند. نتیجه به قلم‌های موجود در محیط زمان اجرا وابسته است.

**آیا می‌توانم قلم‌های خارجی را بارگذاری کنم تا از جایگزینی جلوگیری کنم؟**

بله. می‌توانید [load external fonts](/slides/fa/php-java/custom-font/) کنید تا Aspose.Slides در زمان رندر و تبدیل از آن‌ها استفاده کند.

**آیا Aspose قلم‌ها را همراه کتابخانه توزیع می‌کند؟**

خیر. شما مسئول ارائهٔ قلم‌ها و رعایت مجوزهای آن‌ها هستید.

**آیا نتایج جایگزینی می‌توانند بین ویندوز، لینوکس و macOS متفاوت باشند؟**

بله. قلم‌های نصب‌شده و مکان‌های جستجوی قلم بر حسب سیستم‌عامل متفاوت است، بنابراین قلمی که در یک ماشین موجود است ممکن است در ماشین دیگر نیاز به جایگزینی داشته باشد.

**چگونه می‌توانم انتخاب قلم را در تبدیل‌های دسته‌ای منسجم نگه دارم؟**

از همان فایل‌ها و نسخه‌های قلم در تمام ماشین‌ها یا کانتینرها استفاده کنید، [load required external fonts](/slides/fa/php-java/custom-font/) کنید و هنگام مجوز، [embed fonts](/slides/fa/php-java/embedded-font/) کنید. همچنین می‌توانید قبل از خروجی [FontsManager::getSubstitutions](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/getsubstitutions/) را صدا بزنید تا جایگزینی‌های غیرمنتظره شناسایی شوند.