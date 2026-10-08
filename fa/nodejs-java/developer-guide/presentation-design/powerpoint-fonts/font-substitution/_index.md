---
title: پیکربندی جایگزینی فونت در ارائه‌ها با استفاده از JavaScript
linktitle: جایگزینی فونت
type: docs
weight: 70
url: /fa/nodejs-java/font-substitution/
keywords:
- فونت
- فونت جایگزین
- جایگزینی فونت
- تعویض فونت
- جایگزینی فونت
- قانون جایگزینی
- قانون تعویض
- PowerPoint
- OpenDocument
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "قوانین جایگزینی فونت را پیکربندی کنید و فونت‌های جایگزین‌شده را در Aspose.Slides برای Node.js از طریق Java هنگام رندر یا تبدیل ارائه‌های PowerPoint و OpenDocument بررسی کنید."
---
## **نمای کلی**

جایگزینی فونت به Aspose.Slides امکان می‌دهد تا به جای فونتی که هنگام رندر یا تبدیل ارائه قابل دسترسی نیست، از یک فونت موجود استفاده کند. این جایگزینی بر خروجی رندر شده تأثیر می‌گذارد؛ اما فونت اختصاص‌یافته به محتوای ارائه را تغییر نمی‌دهد.

می‌توانید فونتی را که هنگام عدم دسترسی به یک فونت خاص استفاده می‌شود، تعریف کنید و می‌توانید جایگزینی‌های که Aspose.Slides در طول رندر انجام می‌دهد را بررسی کنید. این کار به حفظ سازگاری خروجی در محیط‌های مختلف با فونت‌های نصب‌شده متفاوت کمک می‌کند.

اگر فونتی در دسترس باشد اما قلم ضخیم (Bold) اختصاصی نداشته باشد، به [Handle Fonts Without a Dedicated Bold Typeface](/slides/fa/nodejs-java/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface) مراجعه کنید. آن بخش توضیح می‌دهد چگونه متن تحت تأثیر را در هنگام خروجی PDF شیار (rasterize) کنید و پیامدهای آن برای انتخاب متن، جستجو و مقیاس‌بندی چیست.

## **دریافت جایگزینی‌های فونت**

از روش [FontsManager.getSubstitutions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) برای تعیین اینکه کدام فونت‌ها هنگام رندر ارائه جایگزین می‌شوند، استفاده کنید. این روش اشیاء [FontSubstitutionInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsubstitutioninfo/) را برمی‌گرداند که نام‌های فونت اصلی و جایگزین را شناسایی می‌کنند.

مثال زیر به زبان JavaScript تمام جایگزینی‌های فونت برای یک ارائه را فهرست می‌کند:
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

## **دریافت جایگزینی‌های فونت برای اسلایدهای انتخاب‌شده**

از نسخه overload شدهٔ [FontsManager.getSubstitutions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) با آرایه‌ای از ایندکس‌های اسلاید استفاده کنید تا فقط جایگزینی‌های مورد نیاز برای رندر اسلایدهای خاص را بررسی کنید. این کار زمانی مفید است که بخواهید بخشی از یک ارائه را رندر یا خروجی بگیرید، یک ارائه بزرگ را به‌صورت افزایشی بررسی کنید، اسلایدهایی را که به فونت‌های غیرقابل دسترس بستگی دارند پیدا کنید، بستهٔ حداقل فونت‌ها را برای سرور یا کانتینر آماده کنید، یا اختلافات رندر را بدون پردازش اسلایدهای نامرتبط تشخیص دهید.

این overload انتظار یک نوع اولیهٔ جاوا `int[]` را دارد. آن را با `java.newArray("int", [...])` ایجاد کنید؛ یک آرایهٔ سادهٔ JavaScript به `Integer[]` تبدیل می‌شود و با این overload مطابقت ندارند.

آرایه شامل ایندکس‌های اسلاید به‌صورت یک‌مبنا است: `1` اولین اسلاید را نشان می‌دهد. در مقابل، دسترسی به مجموعهٔ [Presentation.getSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getslides/) از ایندکس صفر مبنا استفاده می‌کند، بنابراین همان اسلاید به صورت `presentation.getSlides().get_Item(0)` دسترسی می‌شود. هنگام ساخت آرایه این تفاوت را در نظر بگیرید تا از خطاهای off-by-one جلوگیری کنید.

نسخه overload را از طریق [Presentation.getFontsManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getfontsmanager/) صدا بزنید. این متد تنها جایگزینی‌هایی که در حین رندر اسلایدهای انتخاب‌شده تعیین شده‌اند را برمی‌گرداند. هر نتیجه یک شیء [FontSubstitutionInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsubstitutioninfo/) است که نام‌های فونت اصلی و جایگزین را شامل می‌شود. این نتیجه محیط فعلی فونت، قوانین fallback پیکربندی‌شده، قوانین جایگزینی ذخیره‌شده در یک [FontSubstRuleCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsubstrulecollection/)، و [فونت‌های بارگذاری‌شده به‌صورت خارجی](/slides/fa/nodejs-java/custom-font/) را بازتاب می‌دهد.

یک جایگزینی می‌تواند توسط بیش از یک اسلاید انتخاب‌شده لازم باشد. هنگام ایجاد موجودی فونت یا گزارش پیش‌پرواز نتایج را یکتا کنید. مثال زیر هر جایگزینی بازگردانده‌شده را گزارش می‌کند و سپس فهرست مرتب شده‌ای از نگاشت‌های منحصر به‌فرد فونت ایجاد می‌کند:
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

کلاس [FontsManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/) هر دو overload را فراهم می‌آورد. یکی را بر حسب گسترهٔ عملیات رندر انتخاب کنید:

| Overload | زمان استفاده |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) with no arguments | به جایگزینی‌ها برای کل ارائه نیاز دارید. |
| [getSubstitutions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) with a Java `int[]` of slide indexes | به جایگزینی‌ها برای محدودهٔ انتخابی، بررسی افزایشی، یا خروجی جزئی نیاز دارید. |

## **تنظیم قوانین جایگزینی فونت**

برای تعیین فونتی که Aspose.Slides باید هنگام عدم دسترسی به فونت منبع استفاده کند:

1. ارائه را بارگذاری کنید.
2. تعاریف فونت برای فونت منبع و فونت جایگزین ایجاد کنید.
3. یک [FontSubstRule](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsubstrule/) را با شرط [WhenInaccessible](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsubstcondition/) ایجاد کنید.
4. قانون را به یک [FontSubstRuleCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsubstrulecollection/) اضافه کنید.
5. مجموعه را با استفاده از متد [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/setfontsubstrulelist/) انتساب دهید.
6. ارائه را رندر یا تبدیل کنید.

مثال زیر به زبان JavaScript، وقتی `SomeRareFont` در دسترس نیست، `Arial` را به عنوان جایگزین استفاده می‌کند و سپس اولین اسلاید را رندر می‌کند تا نتیجه را تأیید کند. فونت جایگزین باید برای Aspose.Slides در دسترس باشد.
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
برای تغییر بدون شرط فونت‌های استفاده‌شده در تمام ارائه، به [Font Replacement](/slides/fa/nodejs-java/font-replacement/) مراجعه کنید.
{{% /alert %}}

## **محدودیت‌ها برای فونت‌های معادلات ریاضی**

قوانین جایگزینی فونت بخشی از فرآیند استاندارد انتخاب فونت هستند که در طول رندر و تبدیل استفاده می‌شوند. آن‌ها برای متن عادی کار می‌کنند هنگامی که Aspose.Slides می‌تواند یک فونت غیرقابل دسترس را با فونت موجودی که توسط یک قانون مشخص شده است، جایگزین کند.

معادلات Office Math یک نیاز اضافی دارند. اگر یک معادله از **Cambria Math** استفاده کند، Aspose.Slides ممکن است به همان فونت دقیق برای محاسبه و رندر چیدمان معادله نیاز داشته باشد. قانونی که یک فونت ریاضی دیگر مانند **STIX Two Math** را جایگزین کند، نمی‌تواند **Cambria Math** را برای این منظور جایگزین کند و رندر ممکن است همچنان گزارش دهد که **Cambria Math** لازم است.

برای رندر یا تبدیل چنین ارائه‌ای، **Cambria Math** را در دسترس Aspose.Slides قرار دهید. آن را در سیستم‌عامل نصب کنید یا به عنوان یک [external font](/slides/fa/nodejs-java/custom-font/) بارگذاری کنید.

این محدودیت بر روی چیدمان معادلات اعمال می‌شود. قوانین جایگزینی که در بالا توضیح داده شد همچنان برای متن عادی ارائه اعمال می‌شوند.

## **سوالات متداول**

**تفاوت جایگزینی فونت با تعویض فونت چیست؟**

[Font replacement](/slides/fa/nodejs-java/font-replacement/) به‌طور عمدی یک فونت را در تمام ارائه به فونت دیگری تغییر می‌دهد. جایگزینی فونت، هنگام برآورده شدن شرط پیکربندی‌شده—مانند عدم دسترسی به فونت اصلی—یک فونت را برای خروجی رندر شده انتخاب می‌کند.

**قوانین جایگزینی چه زمانی اعمال می‌شوند؟**

قوانین در [font selection sequence](/slides/fa/nodejs-java/font-selection-sequence/) در طول رندر و تبدیل شرکت می‌کنند. با `WhenInaccessible`، یک قانون فقط زمانی استفاده می‌شود که Aspose.Slides نتواند به فونت منبع دسترسی داشته باشد.

**اگر فونتی موجود نباشد و قانونی برای جایگزینی تنظیم نشده باشد چه می‌شود؟**

Aspose.Slides نزدیک‌ترین فونت موجود را بر اساس فرآیند انتخاب فونت خود انتخاب می‌کند. نتیجه بستگی به فونت‌های موجود در محیط زمان اجرا دارد.

**آیا می‌توانم فونت‌های خارجی بارگذاری کنم تا از جایگزینی جلوگیری کنم؟**

بله. می‌توانید [load external fonts](/slides/fa/nodejs-java/custom-font/) را بارگذاری کنید تا Aspose.Slides در طول رندر و تبدیل از آن‌ها استفاده کند.

**آیا Aspose فونت‌ها را همراه کتابخانه توزیع می‌کند؟**

خیر. شما مسئول تهیه فونت‌ها و رعایت مجوزهای آن‌ها هستید.

**آیا نتایج جایگزینی می‌توانند بین ویندوز، لینوکس و macOS متفاوت باشند؟**

بله. فونت‌های نصب شده و مکان‌های جستجوی فونت در هر سیستم‌عامل متفاوت است، بنابراین فونتی که در یک دستگاه موجود است ممکن است در دستگاه دیگر نیاز به جایگزینی داشته باشد.

**چگونه می‌توانم انتخاب فونت را در تبدیل‌های دسته‌ای سازگار کنم؟**

از همان فایل‌ها و نسخه‌های فونت در هر دستگاه یا کانتینر استفاده کنید، [load required external fonts](/slides/fa/nodejs-java/custom-font/) را بارگذاری کنید، و هنگام اجازهٔ مجوز، [embed fonts](/slides/fa/nodejs-java/embedded-font/) کنید. همچنین می‌توانید قبل از خروجی‌گیری، [FontsManager.getSubstitutions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) را فراخوانی کنید تا جایگزینی‌های غیرمنتظره شناسایی شوند.