---
title: مدیریت قلم‌های قالب مخصوص اسکریپت در جاوا
linktitle: قلم‌های قالب مخصوص اسکریپت
type: docs
weight: 15
url: /fa/java/script-specific-font-mappings/
keywords:
- قلم مخصوص اسکریپت
- نقشه‌برداری قلم قالب
- ارائه چندزبانه
- سیستم نوشتاری
- قلم سیریلیک
- قلم عربی
- قلم ژاپنی
- قلم گرجستانی
- قلم ثانا
- پاورپوینت
- ارائه
- جاوا
- Aspose.Slides
description: بررسی، افزودن، جایگزینی و حذف نگاشت‌های قلم مخصوص اسکریپت در قالب‌های پاورپوینت با Aspose.Slides برای جاوا.
---
## **نمای کلی**

یک قالب ارائه می‌تواند خانواده‌های قلم متفاوتی را برای سیستم‌های نوشتاری مختلف انتخاب کند. این امکان را می‌دهد که متن چندزبانه که همچنان از قلم‌های قالب استفاده می‌کند، یک طرح قلم هماهنگ داشته باشد و همزمان برای سیریلیک، عربی، ژاپنی، گرجستانی، ثانا و سایر خط‌ها از قلم‌های مناسب استفاده شود.

قالب [IFontScheme](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ifontscheme/) شامل یک مجموعه قلم اصلی (معمولاً برای عناوین) و یک مجموعه قلم فرعی (معمولاً برای متن اصلی) است. علاوه بر تنظیمات قلم‌های لاتین و آسیای شرقی، هر دو مجموعه با واسط [IFonts](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ifonts/) نگاشت‌هایی از برچسب‌های سیستم نوشتاری به نام‌های خانواده قلم ارائه می‌دهند.

این مقاله نشان می‌دهد چگونه این نگاشت‌ها را در قالب اصلی ارائه بررسی و اصلاح کنیم و اطمینان حاصل کنیم که تغییرات پس از ذخیره‑سازی و بارگذاری مجدد حفظ می‌شوند.

## **درک برچسب‌های اسکریپت**

روش‌های قلم اسکریپت از زیربرچسب‌های چهار حرفی BCP 47 برای شناسایی سیستم‌های نوشتاری استفاده می‌کنند. مقادیر رایج عبارتند از:

| برچسب اسکریپت | سیستم نوشتاری |
|---|---|
| `Cyrl` | سیریلیک |
| `Arab` | عربی |
| `Hans` | چینی ساده |
| `Jpan` | ژاپنی |
| `Geor` | گرجستانی |
| `Thaa` | ثانا |

این نگاشت‌ها متعلق به طرح قلم قالب هستند، نه به بخش‌های متنی جداگانه. یک ارائه می‌تواند نگاشت‌های متفاوتی برای مجموعه‌های اصلی و فرعی داشته باشد و ممکن است برای برخی اسکریپت‌ها نگاتی نداشته باشد.

## **دسترسی و بررسی نگاشت‌های قلم اسکریپت**

از [Presentation.getMasterTheme](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/#getMasterTheme--) برای دسترسی به قالب سطح ارائه استفاده کنید. متدهای [IFontScheme.getMajor](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ifontscheme/#getMajor--) و [IFontScheme.getMinor](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ifontscheme/#getMinor--) دو مجموعه [IFonts](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ifonts/) را بازمی‌گردانند.

با فراخوانی [IFonts.getScriptFontMap](https://reference.aspose.com/slides/fa/java/com.aspose.slides/fonts/#getScriptFontMap--) تمام نگاشت‌های یک مجموعه بازیابی می‌شوند. برای جستجوی یک سیستم نوشتاری خاص، [IFonts.getScriptFont](https://reference.aspose.com/slides/fa/java/com.aspose.slides/fonts/#getScriptFont-java.lang.String-) را با برچسب اسکریپت مربوطه صدا بزنید. `getScriptFont` زمانی که آن مجموعه نگاشت درخواست‌شده را تعریف نکرده باشد، `null` برمی‌گرداند.

## **تغییر نگاشت‌ها و تأیید پایداری**

از [IFonts.setScriptFont](https://reference.aspose.com/slides/fa/java/com.aspose.slides/fonts/#setScriptFont-java.lang.String-java.lang.String-) برای ایجاد یک نگاشت یا جایگزینی خانواده قلم فعلی استفاده کنید. برای حذف یک نگاشت، از [IFonts.removeScriptFont](https://reference.aspose.com/slides/fa/java/com.aspose.slides/fonts/#removeScriptFont-java.lang.String-) بهره ببرید.

مثال کامل زیر تمام نگاشت‌های اصلی و فرعی موجود را می‌خواند، قلم اصلی ژاپنی را بررسی می‌کند، قلم اصلی سیریلیک را تغییر می‌دهد، نگاشت ثانا در مجموعه فرعی را حذف می‌کند، ارائه را ذخیره می‌نماید و سپس آن را باز می‌کند تا هر دو تغییر را تأیید کند. برای اینکه مرحله حذف مستقل از قالب اولیه باشد، مثال ابتدا تنها در صورت عدم وجود نگاشت ثانا، یک نگاشت جدید ایجاد می‌کند.

```java
import com.aspose.slides.*;
import com.aspose.slides.Collections.Generic.Dictionary;
import com.aspose.slides.Collections.Generic.KeyValuePair;

Presentation presentation = new Presentation();
try {
    IFontScheme fontScheme = presentation.getMasterTheme().getFontScheme();
    IFonts majorFonts = fontScheme.getMajor();
    IFonts minorFonts = fontScheme.getMinor();

    System.out.println("Existing major mappings:");
    Dictionary.Enumerator<String, String> majorMappings = majorFonts.getScriptFontMap().iterator();
    while (majorMappings.hasNext()) {
        KeyValuePair<String, String> mapping = majorMappings.next();
        System.out.println("  " + mapping.getKey() + ": " + mapping.getValue());
    }

    System.out.println("Existing minor mappings:");
    Dictionary.Enumerator<String, String> minorMappings = minorFonts.getScriptFontMap().iterator();
    while (minorMappings.hasNext()) {
        KeyValuePair<String, String> mapping = minorMappings.next();
        System.out.println("  " + mapping.getKey() + ": " + mapping.getValue());
    }

    String japaneseFont = majorFonts.getScriptFont("Jpan");
    if (japaneseFont == null) {
        System.out.println("No major Japanese font is defined.");
    } else {
        System.out.println("Major Japanese font: " + japaneseFont);
    }

    majorFonts.setScriptFont("Cyrl", "Arial");

    if (minorFonts.getScriptFont("Thaa") == null) {
        minorFonts.setScriptFont("Thaa", "Arial");
    }

    minorFonts.removeScriptFont("Thaa");
    presentation.save("script-font-mappings.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

Presentation savedPresentation = new Presentation("script-font-mappings.pptx");
try {
    IFonts savedMajorFonts = savedPresentation.getMasterTheme().getFontScheme().getMajor();
    IFonts savedMinorFonts = savedPresentation.getMasterTheme().getFontScheme().getMinor();
    String savedCyrillicFont = savedMajorFonts.getScriptFont("Cyrl");
    String savedThaanaFont = savedMinorFonts.getScriptFont("Thaa");

    if ("Arial".equals(savedCyrillicFont)) {
        System.out.println("The Cyrillic mapping was preserved.");
    } else {
        System.out.println("The Cyrillic mapping was not preserved.");
    }

    if (savedThaanaFont == null) {
        System.out.println("The Thaana mapping removal was preserved.");
    } else {
        System.out.println("The Thaana mapping still exists.");
    }
} finally {
    savedPresentation.dispose();
}
```

تأیید با همان رفتار `null` همانند یک جستجوی معمولی انجام می‌شود: پس از ذخیره‌سازی حذف، `getScriptFont("Thaa")` برای مجموعه فرعی `null` برمی‌گرداند.

## **تمایز نگاشت‌های قالب از سایر تنظیمات قلم**

نگاشت‌های قالب مخصوص اسکریپت در انتخاب قلم مشارکت می‌کنند، اما مشکلی متفاوت نسبت به قالب‌بندی مستقیم متن، جایگزینی و fallback حل می‌کنند:

| سازوکار | هدف | اثر تغییر یک نگاشت قالب |
|---|---|---|
| نگاشت قلم قالب مخصوص اسکریپت | انتخاب یک قلم اصلی یا فرعی قالب برای یک سیستم نوشتاری | متنی که همچنان از قلم قالب مربوطه استفاده می‌کند می‌تواند به خانواده قلم جدید مجاور شود |
| قلم اختصاصی به یک بخش متنی | ثابت کردن خانواده قلم درخواست‌شده برای آن بخش به‌جای اتکا به قالب | ممکن است بخش تغییری نکند چون قالب‌بندی مستقیم آن بر انتخاب قالب اولویت دارد |
| جایگزینی قلم | جایگزینی قلم درخواست‌شده وقتی آن قلم موجود نیست یا قانون جایگزینی اعمال می‌شود | پس از درخواست قلم اعمال می‌شود؛ نگاشت اسکریپت قالب را بازتعریف نمی‌کند |
| fallback قلم | تامین گلیف‌هایی که قلم انتخاب‌شده شامل آن‌ها نیست، معمولاً برای بازه‌های خاص یونیکد | پوشش گلیف‌های گمشده را فراهم می‌کند؛ نگاشت قالب ذخیره‌شده را تغییر نمی‌دهد |

برای اطلاعات بیشتر درباره دو سازوکار آخر، به [Font Substitution](/slides/fa/java/font-substitution/) و [Fallback Fonts](/slides/fa/java/fallback-font/) مراجعه کنید.

تغییر یک نگاشت در [Presentation.getMasterTheme](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/#getMasterTheme--) فقط بر محتوایی که قالب مؤثر آن هنوز به آن قالب وابسته است اثر می‌گذارد. متن می‌تواند به جای آن، یک پوشش قالب از master، layout یا اسلاید دریافت کند یا قلم اختصاصی داشته باشد. هنگام مشاهده نتایج متفاوت، سطوح مختلف را بررسی کنید.

## **در دسترس قرار دادن قلم‌های نگاشت‌شده و اعتبارسنجی نتیجه**

یک نگاشت اسکریپت فقط نام خانواده قلم را ذخیره می‌کند؛ قلم مربوطه را نصب یا بارگذاری نمی‌کند. برای رندر سازگار و خروجی، هر قلم نگاشت‌شده باید در محیط نصب شده باشد یا از طریق منبع سفارشی به Aspose.Slides ارائه شود، مانند [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/fa/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) یا [LoadOptions.getDocumentLevelFontSources](https://reference.aspose.com/slides/fa/java/com.aspose.slides/loadoptions/#getDocumentLevelFontSources--). گزینه‌های بارگذاری موجود در [Custom Fonts](/slides/fa/java/custom-font/) را ببینید.

تأیید نگاشت ذخیره‌شده تنها نشان می‌دهد که تعریف قالب حفظ شده است. این کار اثبات نمی‌کند که قلم در دسترس است، تمام گلیف‌های لازم را دارد یا چیدمان مورد انتظار را تولید می‌کند. برای هر سیستم نوشتاری مورد نیاز، متن نمایشی را به تصویر یا PDF رندر کنید و خروجی را بررسی کنید. این روش قلم‌های گمشده، پوشش ناقص گلیف، رفتار fallback و تغییرات چیدمان را پیش از توزیع ارائه کشف می‌کند. برای مثال‌های رندر و خروجی به [Convert PowerPoint Presentations](/slides/fa/java/convert-powerpoint/) مراجعه کنید.

## **سوالات متداول**

**`getScriptFont` وقتی یک اسکریپت نگاشت نشده باشد، چه مقدار برمی‌گرداند؟**

[IFonts.getScriptFont](https://reference.aspose.com/slides/fa/java/com.aspose.slides/fonts/#getScriptFont-java.lang.String-) وقتی نگاشت اسکریپت درخواست‌شده در مجموعه اصلی یا فرعی تعریف نشده باشد، `null` برمی‌گرداند.

**آیا `setScriptFont` وقتی اسکریپت از قبل وجود داشته باشد، یک نگاشت دوم اضافه می‌کند؟**

نه. [IFonts.setScriptFont](https://reference.aspose.com/slides/fa/java/com.aspose.slides/fonts/#setScriptFont-java.lang.String-java.lang.String-) وقتی نگاشت موجود نیست، آن را ایجاد می‌کند و وقتی همان برچسب اسکریپت قبلاً وجود دارد، خانواده قلم نگاشت‌شده را جایگزین می‌نماید.

**چرا تغییر یک نگاشت قالب برخی متن‌ها را تغییر نداد؟**

ممکن است متن قلم اختصاصی داشته باشد، قالب متفاوتی از طریق یک override دریافت کند، یا در رندر تحت تأثیر جایگزینی یا fallback باشد. نگاشت اسکریپت در سطح ارائه فقط بر متنی که قالب مؤثر آن هنوز به مجموعه قلم قالب مراجعه می‌کند، تاثیر دارد.

**آیا ذخیره و بازگشایی کافی است تا خروجی چندزبانه را اعتبارسنجی کنیم؟**

نه. بازگشایی فقط پایداری داده‌های قالب را تأیید می‌کند. همچنین باید متن نمایشی هر سیستم نوشتاری مورد نیاز را رندر کنید تا مطمئن شوید قلم‌های نگاشت‌شده در دسترس هستند و گلیف‌های لازم را شامل می‌شوند.