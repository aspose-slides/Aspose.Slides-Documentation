---
title: مدیریت قلم‌های تم مخصوص اسکریپت در جاوااسکریپت
linktitle: قلم‌های تم مخصوص اسکریپت
type: docs
weight: 15
url: /fa/nodejs-java/script-specific-font-mappings/
keywords:
- قلم مخصوص اسکریپت
- نگاشت قلم تم
- ارائه چندزبانه
- سیستم نوشتاری
- قلم سیریلیک
- قلم عربی
- قلم ژاپنی
- قلم گرجی
- قلم ثانایی
- پاورپوینت
- ارائه
- Node.js
- جاوااسکریپت
- Aspose.Slides
description: "بررسی، افزودن، جایگزینی و حذف نگاشت‌های قلم مخصوص اسکریپت در تم‌های پاورپوینت با Aspose.Slides برای Node.js."
---
## **نمای کلی**

یک تم ارائه می‌تواند برای سیستم‌های نوشتاری مختلف، خانواده‌های قلم متفاوتی انتخاب کند. این امکان باعث می‌شود متن‌های چندزبانه که همچنان از قلم‌های تم استفاده می‌کنند، یک طرح قلم هماهنگ داشته باشند و در عین حال برای سیریلیک، عربی، ژاپنی، گرجی، ثانایی و سایر اسکریپت‌ها قلم‌های مناسب به کار روند.

تم **[FontScheme](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/fontscheme/)** شامل یک مجموعه قلم «اصلی» است که معمولاً برای سرتیترها به کار می‌رود و یک مجموعه قلم «ثانویه» که معمولاً برای متن اصلی استفاده می‌شود. علاوه بر تنظیمات قلم‌های لاتین و آسیای شرقی، هر دو مجموعه از طریق کلاس **[Fonts](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/fonts/)** نگاشت‌هایی از برچسب‌های سیستم نوشتاری به نام‌های خانواده قلم‌ها را فراهم می‌کند.

این مقاله نشان می‌دهد چگونه این نگاشت‌ها را در تم اصلی ارائه بررسی و تغییر دهیم و بررسی کنیم که آیا تغییرات پس از یک چرخه ذخیره‑و‑بارگذاری باقی می‌مانند یا خیر.

## **درک برچسب‌های اسکریپت**

روش‌های قلم اسکریپت از زیربرچسب‌های چهار حرفی BCP 47 برای شناسایی سیستم‌های نوشتاری استفاده می‌کنند. مقادیر رایج عبارتند از:

| برچسب اسکریپت | سیستم نوشتاری |
|---|---|
| `Cyrl` | سیریلیک |
| `Arab` | عربی |
| `Hans` | چینی ساده |
| `Jpan` | ژاپنی |
| `Geor` | گرجی |
| `Thaa` | ثانایی |

این نگاشت‌ها متعلق به طرح قلم تم هستند، نه به بخش‌های متنی جداگانه. یک ارائه می‌تواند نگاشت‌های متفاوتی برای مجموعه‌های اصلی و ثانویه داشته باشد و ممکن است برای برخی اسکریپت‌ها نگاشت تعریف نکند.

## **دسترسی و بررسی نگاشت‌های قلم اسکریپت**

از **[Presentation.getMasterTheme](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/getmastertheme/)** برای دسترسی به تم سطح ارائه استفاده کنید. متدهای **[FontScheme.getMajor](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/fontscheme/)** و **[FontScheme.getMinor](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/fontscheme/)** دو مجموعه **[Fonts](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/fonts/)** را برمی‌گردانند.

با فراخوانی **[Fonts.getScriptFontMap](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/fonts/)** می‌توانید تمام نگاشت‌ها را از یک مجموعه دریافت کنید. برای جستجوی یک سیستم نوشتاری، **[Fonts.getScriptFont](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/fonts/)** را با برچسب اسکریپت مربوطه فراخوانی کنید. `getScriptFont` هنگام عدم وجود نگاشت در آن مجموعه `null` برمی‌گرداند.

## **تغییر نگاشت‌ها و تأیید ماندگاری**

با استفاده از **[Fonts.setScriptFont](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/fonts/)** می‌توانید یک نگاشت جدید ایجاد یا خانواده قلم فعلی را جایگزین کنید. برای حذف یک نگاشت از **[Fonts.removeScriptFont](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/fonts/)** استفاده کنید.

مثال پایان‑به‑پایان زیر تمام نگاشت‌های اصلی و ثانویه موجود را می‌خواند، قلم اصلی ژاپنی را جستجو می‌کند، قلم اصلی سیریلیک را تغییر می‌دهد، نگاشت ثانویه ثانایی را حذف می‌کند، ارائه را ذخیره می‌سازد و سپس آن را مجدداً باز می‌کند تا هر دو تغییر را تأیید کند. برای اینکه مرحله حذف مستقل از تم اولیه باشد، این مثال فقط زمانی که نگاشت ثانایی وجود نداشته باشد، یک نگاشت ثانایی ایجاد می‌کند.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var fontScheme = presentation.getMasterTheme().getFontScheme();
    var majorFonts = fontScheme.getMajor();
    var minorFonts = fontScheme.getMinor();

    console.log("Existing major mappings:");
    var majorMappings = majorFonts.getScriptFontMap().iterator();
    while (majorMappings.hasNext()) {
        var mapping = majorMappings.next();
        console.log("  " + mapping.getKey() + ": " + mapping.getValue());
    }

    console.log("Existing minor mappings:");
    var minorMappings = minorFonts.getScriptFontMap().iterator();
    while (minorMappings.hasNext()) {
        var mapping = minorMappings.next();
        console.log("  " + mapping.getKey() + ": " + mapping.getValue());
    }

    var japaneseFont = majorFonts.getScriptFont("Jpan");
    if (japaneseFont == null) {
        console.log("No major Japanese font is defined.");
    } else {
        console.log("Major Japanese font: " + japaneseFont);
    }

    majorFonts.setScriptFont("Cyrl", "Arial");

    if (minorFonts.getScriptFont("Thaa") == null) {
        minorFonts.setScriptFont("Thaa", "Arial");
    }

    minorFonts.removeScriptFont("Thaa");
    presentation.save("script-font-mappings.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

var savedPresentation = new aspose.slides.Presentation("script-font-mappings.pptx");
try {
    var savedMajorFonts = savedPresentation.getMasterTheme().getFontScheme().getMajor();
    var savedMinorFonts = savedPresentation.getMasterTheme().getFontScheme().getMinor();
    var savedCyrillicFont = savedMajorFonts.getScriptFont("Cyrl");
    var savedThaanaFont = savedMinorFonts.getScriptFont("Thaa");

    if (savedCyrillicFont === "Arial") {
        console.log("The Cyrillic mapping was preserved.");
    } else {
        console.log("The Cyrillic mapping was not preserved.");
    }

    if (savedThaanaFont == null) {
        console.log("The Thaana mapping removal was preserved.");
    } else {
        console.log("The Thaana mapping still exists.");
    }
} finally {
    savedPresentation.dispose();
}
```

تأیید با همان رفتار `null` یک جستجوی معمولی انجام می‌شود: پس از ذخیرهٔ حذف، `getScriptFont("Thaa")` برای مجموعهٔ ثانویه `null` برمی‌گرداند.

## **تمایز نگاشت‌های تم از سایر تنظیمات قلم**

نگاشت‌های تم مخصوص اسکریپت در انتخاب قلم شرکت می‌کنند، اما مشکل متفاوتی نسبت به قالب‌بندی مستقیم متن، جایگزینی و fallback حل می‌کنند:

| مکانیزم | هدف | اثر تغییر نگاشت تم |
|---|---|---|
| نگاشت قلم تم مخصوص اسکریپت | انتخاب قلم تم اصلی یا ثانویه برای یک سیستم نوشتاری. | متنی که هنوز از قلم تم مربوطه استفاده می‌کند می‌تواند به خانوادهٔ قلم جدید نگاشت‌شده حل شود. |
| قلم اختصاص داده‌شده صریحاً به بخش متنی | ثابت کردن خانوادهٔ قلم مورد درخواست برای آن بخش به جای تکیه به تم. | ممکن است بخش تغییری نکند زیرا قالب‌بندی مستقیم آن، انتخاب تم را نقض می‌کند. |
| جایگزینی قلم | هنگام عدم دسترس بودن قلم یا اعمال قانون جایگزینی، قلم درخواست‌شده را تعویض می‌کند. | پس از درخواست قلم عمل می‌کند؛ نگاشت اسکریپت تم را بازتعریف نمی‌کند. |
| fallback قلم | گلیف‌هایی که قلم انتخاب‌شده در آن‌ها ندارند را فراهم می‌کند، اغلب برای بازه‌های خاص Unicode. | پوشش گلیف‌های گمشده را تکمیل می‌کند؛ نگاشت تم ذخیره‌شده را تغییر نمی‌دهد. |

برای اطلاعات بیشتر دربارهٔ دو مکانیزم آخر، به **[Font Substitution](/slides/fa/nodejs-java/font-substitution/)** و **[Fallback Fonts](/slides/fa/nodejs-java/fallback-font/)** مراجعه کنید.

تغییر یک نگاشت در **[Presentation.getMasterTheme](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/getmastertheme/)** فقط محتواهایی را تحت تاثیر قرار می‌دهد که قالب‌بندی مؤثرشان هنوز به آن تم وابسته است. متن می‌تواند به جای آن، از یک بازنویسی تم در یک master، layout یا slide ارث‌بری کند یا از یک قلم اختصاصی استفاده کند. هنگام عدم تطابق نتیجهٔ قابل مشاهده با نگاشت سطح ارائه، سطوح فوق را بررسی کنید.

## **در دسترس قرار دادن قلم‌های نگاشت‌شده و اعتبارسنجی نتیجه**

یک نگاشت اسکریپت تنها نام خانوادهٔ قلم را ذخیره می‌کند؛ قلم مربوطه را نصب یا بارگذاری نمی‌کند. برای رندرینگ و خروجی ثابت، هر قلم نگاشت‌شده باید در محیط نصب شده باشد یا از طریق منبع سفارشی به Aspose.Slides ارائه شود، مانند **[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/fontsloader/loadexternalfonts/)** یا **[LoadOptions.getDocumentLevelFontSources](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/loadoptions/)**. برای گزینه‌های بارگذاری موجود به **[Custom Fonts](/slides/fa/nodejs-java/custom-font/)** مراجعه کنید.

تأیید نگاشت ذخیره‌شده تنها این را ثابت می‌کند که تعریف تم حفظ شده است. این به این معنی نیست که قلم در دسترس است، تمام گلیف‌های مورد نیاز را دارد یا چیدمان مورد نظر را تولید می‌کند. برای هر سیستم نوشتاری مورد نیاز متن نماینده‌ای را به تصویر یا PDF رندر کنید و خروجی را بررسی کنید. این کار قلم‌های گمشده، پوشش ناکافی گلیف، رفتار fallback و تغییرات چیدمان را پیش از توزیع ارائه شناسایی می‌کند. برای مثال‌های رندر و خروجی به **[Convert PowerPoint Presentations](/slides/fa/nodejs-java/convert-powerpoint/)** نگاه کنید.

## **سوالات متداول**

**`getScriptFont` وقتی اسکریپتی نگاشت نشده باشد چه مقدار باز می‌گرداند؟**

**[Fonts.getScriptFont](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/fonts/)** وقتی نگاشت اسکریپت درخواست‌شده در مجموعهٔ اصلی یا ثانویه تعریف نشده باشد `null` برمی‌گرداند.

**آیا `setScriptFont` وقتی اسکریپت از قبل وجود دارد، نگاشت دوم اضافه می‌کند؟**

خیر. **[Fonts.setScriptFont](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/fonts/)** زمانی که نگاشت موجود نباشد آن را ایجاد می‌کند و وقتی همان برچسب اسکریپت موجود باشد، خانوادهٔ قلم نگاشت‌شده را جایگزین می‌کند.

**چرا تغییر نگاشت تم باعث تغییر برخی متن‌ها نشد؟**

متن ممکن است قلمی اختصاصی داشته باشد، تم متفاوتی از طریق بازنویسی به ارث ببرد یا تحت تأثیر جایگزینی یا fallback هنگام رندرینگ باشد. یک نگاشت اسکریپت سطح ارائه تنها متنی را کنترل می‌کند که قالب‌بندی مؤثر آن هنوز به مجموعهٔ قلم تم ارجاع می‌دهد.

**آیا ذخیره و بازگشایی کافی است تا خروجی چندزبانه را اعتبارسنجی کنیم؟**

خیر. بازگشایی ماندگاری داده‌های تم را تأیید می‌کند. همچنین برای اطمینان از در دسترس بودن قلم‌های نگاشت‌شده و داشتن گلیف‌های لازم، باید متن نمایندهٔ هر سیستم نوشتاری را رندر کنید.