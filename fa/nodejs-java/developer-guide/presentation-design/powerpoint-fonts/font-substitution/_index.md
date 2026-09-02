---
title: پیکربندی جایگزینی قلم در ارائه‌ها با استفاده از JavaScript
linktitle: جایگزینی قلم
type: docs
weight: 70
url: /fa/nodejs-java/font-substitution/
keywords:
- قلم
- قلم جایگزین
- جایگزینی قلم
- تعویض قلم
- تعویض قلم
- قانون جایگزینی
- قانون تعویض
- PowerPoint
- OpenDocument
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "قوانین جایگزینی قلم را پیکربندی کنید و قلم‌های جایگزین‌شده را در Aspose.Slides برای Node.js از طریق Java هنگام رندر یا تبدیل ارائه‌های PowerPoint و OpenDocument بررسی کنید."
---
## **بررسی کلی**

جایگزینی قلم (Font substitution) به Aspose.Slides اجازه می‌دهد که به‌جای قلم‌ای که در هنگام رندر یا تبدیل ارائه دسترسی‌پذیر نیست، از قلم موجود استفاده کند. این جایگزینی فقط بر خروجی رندر شده تأثیر می‌گذارد؛ قلم اختصاص‌یافته به محتوای ارائه تغییر نمی‌کند.

شما می‌توانید قلمی را که هنگام عدم دسترسی به یک قلم خاص استفاده می‌شود تعریف کنید و می‌توانید جایگزینی‌هایی را که Aspose.Slides در حین رندر انجام می‌دهد بررسی کنید. این کار به حفظ یکنواختی خروجی در محیط‌هایی با قلم‌های نصب‌شده متفاوت کمک می‌کند.

## **دریافت جایگزینی‌های قلم**

از روش [FontsManager.getSubstitutions](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) برای تعیین اینکه کدام قلم‌ها هنگام رندر ارائه جایگزین می‌شوند استفاده کنید. این روش اشیاء [FontSubstitutionInfo](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/fontsubstitutioninfo/) را برمی‌گرداند که نام قلم اصلی و قلم جایگزین را شناسایی می‌کند.

مثال زیر به‌زبان JavaScript تمام جایگزینی‌های قلم برای یک ارائه را فهرست می‌کند:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    var substitutions = presentation.getFontsManager().getSubstitutions().iterator();
    while (substitutions.hasNext()) {
        var substitution = substitutions.next();
        console.log(substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName());
    }
} finally {
    presentation.dispose();
}
```

## **دریافت جایگزینی‌های قلم برای اسلایدهای انتخابی**

از بارگذاری ‎[FontsManager.getSubstitutions](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) با آرایه‌ای از اندیس‌های اسلاید برای بررسی تنها جایگزینی‌های لازم برای رندر اسلایدهای خاص استفاده کنید. این کار زمانی مفید است که بخواهید بخشی از یک ارائه را رندر یا صادرات کنید، ارائهٔ بزرگ را به‌صورت تدریجی بررسی کنید، اسلایدهایی را که به قلم‌های غیرقابل دسترس وابسته‌اند پیدا کنید، بستهٔ قلم‌های حداقلی برای سرور یا کانتینر تهیه کنید یا تفاوت‌های رندر را بدون پردازش اسلایدهای نامرتبط تشخیص دهید.

این بارگذاری انتظار یک ‎`int[]`‎ اولیهٔ جاوا را دارد. آن را با ‎`java.newArray("int", [...])`‎ بسازید؛ یک آرایهٔ سادهٔ JavaScript به ‎`Integer[]`‎ تبدیل می‌شود و با این بارگذاری مطابقت ندارد.

آرایه شامل اندیس‌های اسلاید با شمارش یک‌پایه است: ‎`1`‎ اسلاید اول را شناسایی می‌کند. برعکس، دسترسی‌کنندهٔ مجموعهٔ [Presentation.getSlides](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/getslides/) از شمارش صفرپایه استفاده می‌کند، بنابراین همان اسلاید به‌صورت ‎`presentation.getSlides().get_Item(0)`‎ دسترسی‌پذیر است. هنگام ساختن آرایه این تفاوت را در نظر بگیرید تا از خطای یک‑واحدی جلوگیری کنید.

بارگذاری را از طریق [Presentation.getFontsManager](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/getfontsmanager/) صدا بزنید. این فقط جایگزینی‌هایی را که هنگام رندر اسلایدهای انتخابی تعیین شده‌اند برمی‌گرداند. هر نتیجه یک شیء [FontSubstitutionInfo](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/fontsubstitutioninfo/) است که شامل نام‌های قلم اصلی و جایگزین می‌باشد. نتیجه بازتاب‌دهندهٔ محیط قلم فعلی، قوانین fallback پیکربندی‌شده، قوانین جایگزینی ذخیره‌شده در یک ‎[FontSubstRuleCollection](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/fontsubstrulecollection/)‎ و ‎[قلم‌های بارگذاری‌شدهٔ خارجی](/slides/fa/nodejs-java/custom-font/)‎ است.

یک جایگزینی ممکن است برای بیش از یک اسلاید انتخابی لازم باشد. هنگام ایجاد فهرست موجودی قلم یا گزارش پیش‌پروازی، نتایج را بدون تکرار کنید. مثال زیر هر جایگزینی برگردانده‌شده را گزارش می‌کند و سپس فهرست مرتب‌ شده‌ای از نگاشت‌های قلم یکتا ایجاد می‌نماید:

```javascript
var aspose = aspose || {};
const java = require("java");
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    var selectedSlides = java.newArray("int", [1, 3, 5]);
    var substitutions = [];
    var substitutionIterator = presentation.getFontsManager().getSubstitutions(selectedSlides).iterator();
    while (substitutionIterator.hasNext()) {
        substitutions.push(substitutionIterator.next());
    }

    console.log("Substitutions for the selected slides:");
    substitutions.forEach(function (substitution) {
        console.log(substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName());
    });

    var preflightEntries = substitutions.map(function (substitution) {
        return substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName();
    });
    var sortedPreflightEntries = Array.from(new Set(preflightEntries)).sort(function (first, second) {
        return first.localeCompare(second, undefined, { sensitivity: "base" });
    });

    console.log("Deduplicated font preflight report:");
    sortedPreflightEntries.forEach(function (entry) {
        console.log(entry);
    });
} finally {
    presentation.dispose();
}
```

کلاس [FontsManager](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/fontsmanager/) هر دو بارگذاری را فراهم می‌کند. بر حسب دامنهٔ عملیات رندر، یکی را انتخاب کنید:

| بارگذاری | زمان استفاده |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) بدون آرگومان | نیاز به جایگزینی برای کل ارائه دارید. |
| [getSubstitutions](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) با ‎`int[]`‎ جاوا شامل اندیس‌های اسلاید | نیاز به جایگزینی برای بازهٔ انتخابی، بررسی تدریجی یا صادرات جزئی دارید. |

## **تنظیم قوانین جایگزینی قلم**

برای مشخص کردن قلمی که Aspose.Slides باید وقتی قلم منبع در دسترس نیست استفاده کند:

1. ارائه را بارگذاری کنید.
2. تعریف‌های قلم برای قلم منبع و قلم جایگزین ایجاد کنید.
3. یک ‎[FontSubstRule](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/fontsubstrule/)‎ با شرط ‎[WhenInaccessible](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/fontsubstcondition/)‎ ایجاد کنید.
4. قانون را به یک ‎[FontSubstRuleCollection](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/fontsubstrulecollection/)‎ اضافه کنید.
5. مجموعه را با استفاده از روش ‎[FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/fontsmanager/setfontsubstrulelist/)‎ اختصاص دهید.
6. ارائه را رندر یا تبدیل کنید.

مثال زیر به‌زبان JavaScript، وقتی ‎`SomeRareFont`‎ در دسترس نیست، ‎`Arial`‎ را به‌جای آن جایگزین می‌کند و سپس اولین اسلاید را برای تأیید نتیجه رندر می‌کند. قلم جایگزین باید برای Aspose.Slides قابل دسترس باشد.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    var sourceFont = new aspose.slides.FontData("SomeRareFont");
    var substituteFont = new aspose.slides.FontData("Arial");
    var substitutionRule = new aspose.slides.FontSubstRule(sourceFont, substituteFont, aspose.slides.FontSubstCondition.WhenInaccessible);

    var substitutionRules = new aspose.slides.FontSubstRuleCollection();
    substitutionRules.add(substitutionRule);
    presentation.getFontsManager().setFontSubstRuleList(substitutionRules);

    var image = presentation.getSlides().get_Item(0).getImage(1.0, 1.0);
    try {
        image.save("slide.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}

برای تغییر بی‌قید و شرط قلم‌های استفاده‌شده در سراسر یک ارائه، به ‎[جایگزینی قلم](/slides/fa/nodejs-java/font-replacement/)‎ مراجعه کنید.

{{% /alert %}}

## **محدودیت‌ها برای قلم‌های معادلات ریاضی**

قوانین جایگزینی قلم جزو فرآیند استاندارد انتخاب قلم استفاده‌شده در حین رندر و تبدیل هستند. آن‌ها برای متن معمولی کار می‌کنند وقتی Aspose.Slides می‌تواند قلم غیرقابل دسترس را با قلم موجود تعیین‌شده در یک قانون جایگزین کند.

معادلات Office Math نیازمندی اضافی دارند. اگر یک معادله از ‎**Cambria Math**‎ استفاده کند، Aspose.Slides ممکن است برای محاسبه و رندر چیدمان معادله به دقیقاً همان قلم نیاز داشته باشد. قانونی که قلم ریاضی دیگری مانند ‎**STIX Two Math**‎ را جایگزین می‌کند، نمی‌تواند ‎**Cambria Math**‎ را برای این منظور جایگزین کند و رندر ممکن است همچنان گزارش دهد که ‎**Cambria Math**‎ لازم است.

برای رندر یا تبدیل چنین ارائه‌ای، ‎**Cambria Math**‎ را در دسترس Aspose.Slides قرار دهید. آن را در سیستم عامل نصب کنید یا به‌عنوان یک ‎[قلم خارجی](/slides/fa/nodejs-java/custom-font/)‎ بارگذاری کنید.

این محدودیت فقط بر چیدمان معادله اعمال می‌شود. قوانین جایگزینی توصیف‌شده در بالا همچنان برای متن معمولی ارائه معتبر هستند.

## **سوالات متداول**

**تفاوت جایگزینی قلم و جایگزینی کامل قلم چیست؟**

[جایگزینی قلم](/slides/fa/nodejs-java/font-replacement/) به‌طور عمدی یک قلم را در سراسر ارائه با قلم دیگری تغییر می‌دهد. جایگزینی قلم قلمی برای خروجی رندر شده انتخاب می‌کند وقتی شرط پیکربندی‌شده برآورده شود، مثلاً وقتی قلم اصلی در دسترس نباشد.

**قوانین جایگزینی چه زمانی اعمال می‌شوند؟**

قوانین در ‎[دنبالهٔ انتخاب قلم](/slides/fa/nodejs-java/font-selection-sequence/)‎ در طول رندر و تبدیل شرکت می‌کنند. با ‎`WhenInaccessible`‎، قانون فقط وقتی استفاده می‌شود که Aspose.Slides نتواند به قلم منبع دسترسی پیدا کند.

**اگر قلمی موجود نباشد و هیچ قانونی برای جایگزینی تعریف نشده باشد چه می‌شود؟**

Aspose.Slides نزدیک‌ترین قلم موجود را بر اساس فرآیند انتخاب قلم خود انتخاب می‌کند. نتیجه به قلم‌های موجود در محیط زمان اجرا بستگی دارد.

**آیا می‌توانم قلم‌های خارجی را بارگذاری کنم تا از جایگزینی جلوگیری کنم؟**

بله. می‌توانید ‎[قلم‌های خارجی را بارگذاری](/slides/fa/nodejs-java/custom-font/)‎ کنید تا Aspose.Slides در حین رندر و تبدیل از آن‌ها استفاده کند.

**آیا Aspose قلم‌ها را همراه کتابخانه توزیع می‌کند؟**

خیر. مسئولیت تهیهٔ قلم‌ها و رعایت مجوزهای آن‌ها بر عهدهٔ شماست.

**آیا نتایج جایگزینی می‌توانند بین ویندوز، لینوکس و macOS متفاوت باشند؟**

بله. قلم‌های نصب‌شده و مکان‌های جستجوی قلم توسط سیستم‌عامل متفاوت است، بنابراین قلمه‌ای که در یک ماشین موجود است ممکن است در ماشین دیگری نیاز به جایگزینی داشته باشد.

**چگونه می‌توانم انتخاب قلم را در تبدیل‌های دسته‌ای یکنواخت نگه دارم؟**

از همان فایل‌ها و نسخه‌های قلم در تمام ماشین‌ها یا کانتینرها استفاده کنید، ‎[قلم‌های خارجی لازم را بارگذاری](/slides/fa/nodejs-java/custom-font/)‎ کنید و هنگام اجازهٔ مجوز، ‎[قلم‌ها را جاسازی](/slides/fa/nodejs-java/embedded-font/)‎ کنید. همچنین می‌توانید قبل از صادرات، ‎[FontsManager.getSubstitutions](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/)‎ را فراخوانی کنید تا جایگزینی‌های غیرمنتظره را شناسایی کنید.