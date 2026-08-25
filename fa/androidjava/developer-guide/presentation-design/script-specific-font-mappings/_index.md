---
title: مدیریت قلم‌های تم مخصوص اسکریپت در اندروید
linktitle: قلم‌های تم مخصوص اسکریپت
type: docs
weight: 15
url: /fa/androidjava/script-specific-font-mappings/
keywords:
- قلم مخصوص اسکریپت
- نقشه‌گذاری قلم تم
- ارائه چندزبانه
- سیستم نوشتاری
- قلم سیریل
- قلم عربی
- قلم ژاپنی
- قلم گرجی
- قلم توانا
- PowerPoint
- ارائه
- Android
- Java
- Aspose.Slides
description: "بررسی، افزودن، جایگزینی و حذف نقشه‌گذاری‌های قلم خاص اسکریپت در تم‌های PowerPoint با Aspose.Slides برای Android از طریق Java."
---
## **مرور کلی**

یک تم ارائه می‌تواند خانواده‌های فونت مختلفی را برای سیستم‌های نوشتاری متفاوت انتخاب کند. این امکان باعث می‌شود متن چند زبانه که همچنان از فونت‌های تم استفاده می‌کند، یک طرح فونت هماهنگ را دنبال کند در حالی که برای سیریل، عربی، ژاپنی، گرجی، توانا و سایر نگارش‌ها فونت‌های مناسب به کار رود.

تم دارای [IFontScheme](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ifontscheme/) شامل یک مجموعه فونت اصلی است که معمولاً برای عناوین استفاده می‌شود و یک مجموعه فونت فرعی که معمولاً برای متن اصلی به کار می‌رود. علاوه بر تنظیمات فونت‌های لاتین و آسیای شرقی، هر دو مجموعه نقشه‌برداری‌هایی از برچسب‌های سیستم نوشتاری به نام‌های خانواده فونت از طریق رابط [IFonts](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ifonts/) ارائه می‌دهند.

این مقاله نشان می‌دهد چگونه می‌توان این نقشه‌ها را در تم اصلی ارائه بررسی و اصلاح کرد و اطمینان حاصل کرد که تغییرات پس از ذخیره‌سازی و بارگذاری مجدد حفظ می‌شوند.

## **درک برچسب‌های اسکریپت**

روش‌های قلم اسکریپت از زیربرچسب‌های چهار حرفی BCP 47 برای شناسایی سیستم‌های نوشتاری استفاده می‌کنند. مقادیر رایج عبارتند از:

| Script tag | Writing system |
|---|---|
| `Cyrl` | سیریل |
| `Arab` | عربی |
| `Hans` | چینی ساده |
| `Jpan` | ژاپنی |
| `Geor` | گرگی |
| `Thaa` | توانا |

این نقشه‌ها به طرح فونت تم تعلق دارند، نه به بخش‌های متنی جداگانه. یک ارائه ممکن است نقشه‌های متفاوتی برای مجموعه‌های اصلی و فرعی تعریف کند و ممکن است برای برخی اسکریپت‌ها نقشه‌ای ارائه ندهد.

## **دسترسی و بررسی نقشه‌های قلم اسکریپت**

از [Presentation.getMasterTheme](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/#getMasterTheme--) برای دسترسی به تم سطح ارائه استفاده کنید. متدهای [IFontScheme.getMajor](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ifontscheme/#getMajor--) و [IFontScheme.getMinor](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ifontscheme/#getMinor--) دو مجموعه [IFonts](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ifonts/) را برمی‌گردانند.

برای دریافت تمام نقشه‌ها از یک مجموعه، [IFonts.getScriptFontMap](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/fonts/#getScriptFontMap--) را فراخوانی کنید. برای جستجوی یک سیستم نوشتاری، [IFonts.getScriptFont](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/fonts/#getScriptFont-java.lang.String-) را با برچسب اسکریپت مربوطه صدا بزنید. `getScriptFont` زمانی که آن مجموعه نقشهٔ درخواست‌شده را تعریف نکرده باشد، `null` برمی‌گرداند.

## **اصلاح نقشه‌ها و تأیید پایداری**

از [IFonts.setScriptFont](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/fonts/#setScriptFont-java.lang.String-java.lang.String-) برای ایجاد یک نقشه یا جایگزینی خانوادهٔ فونت فعلی آن استفاده کنید. برای حذف یک نقشه از [IFonts.removeScriptFont](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/fonts/#removeScriptFont-java.lang.String-) استفاده کنید.

مثال کامل زیر تمام نقشه‌های اصلی و فرعی موجود را می‌خواند، قلم اصلی ژاپنی را جستجو می‌کند، قلم اصلی سیریل را تغییر می‌دهد، نقشهٔ فرعی توانا را حذف می‌کند، ارائه را ذخیره کرده و برای تأیید هر دو تغییر آن را دوباره باز می‌کند. برای اینکه گام حذف مستقل از تم اولیه باشد، مثال ابتدا یک نقشهٔ توانا ایجاد می‌کند فقط در صورتی که قبلاً تعریف نشده باشد.

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

تأیید از همان رفتار `null` مشابه جستجوی معمولی استفاده می‌کند: پس از ذخیره‌سازی حذف، `getScriptFont("Thaa")` برای مجموعهٔ فرعی `null` بر می‌گرداند.

## **تمیز دادن نقشه‌های تم از سایر تنظیمات فونت**

نقشه‌های تم مخصوص اسکریپت در انتخاب فونت شرکت می‌کنند، اما مشکل متفاوتی نسبت به قالب‌بندی مستقیم متن، جایگزینی و پس‌زمینه (fallback) حل می‌کنند:

| مکانیزم | هدف | اثر تغییر یک نقشه تم |
|---|---|---|
| نقشهٔ فونت تم مخصوص اسکریپت | فونت تم اصلی یا فرعی را برای یک سیستم نوشتاری انتخاب می‌کند. | متنی که هنوز از فونت تم مربوطه استفاده می‌کند می‌تواند به خانوادهٔ جدید نقشه‌دار حل شود. |
| فونت اختصاص داده شده صریحاً به یک بخش متن | خانوادهٔ فونت درخواستی را بر روی آن بخش ثابت می‌کند به جای اتکا به تم. | ممکن است بخش بدون تغییر بماند چون قالب‌بندی مستقیم آن بر انتخاب تم ارجاع می‌دهد. |
| جایگزینی فونت | فونت درخواستی را وقتی در دسترس نیست یا قاعدهٔ جایگزینی اعمال می‌شود، جایگزین می‌کند. | پس از درخواست یک فونت عمل می‌کند؛ نقشهٔ اسکریپت تم را دوباره تعریف نمی‌کند. |
| پشتیبان‌گذاری فونت | گلایف‌هایی را که فونت انتخاب‌شده شامل آن‌ها نیست، به‌ویژه برای محدوده‌های خاص یونیکد، فراهم می‌کند. | پوشش گلایف‌های گمشده را تکمیل می‌کند؛ نقشهٔ ذخیره‌شدهٔ تم را تغییر نمی‌دهد. |

برای اطلاعات بیشتر دربارهٔ دو مکانیزم آخر، به [Font Substitution](/slides/fa/androidjava/font-substitution/) و [Fallback Fonts](/slides/fa/androidjava/fallback-font/) مراجعه کنید.

تغییر یک نقشه در [Presentation.getMasterTheme](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/#getMasterTheme--) فقط بر محتوایی که قالب‌بندی مؤثرشان هنوز به آن تم وابسته است تأثیر می‌گذارد. متن می‌تواند به‌جای آن، یک بازنویسی تم از یک مستر، چیدمان یا اسلاید به ارث ببرد، یا از فونت اختصاصی استفاده کند. هنگام عدم تطابق نتیجهٔ قابل مشاهده با نقشهٔ سطح ارائه، این سطوح را بررسی کنید.

## **در دسترس قرار دادن فونت‌های نقشه‌دار و اعتبارسنجی نتیجه**

یک نقشهٔ اسکریپت نام یک خانوادهٔ فونت را ذخیره می‌کند؛ اما فایل فونت متناظر را نصب یا بارگذاری نمی‌کند. برای رندرینگ و صادرات سازگار، هر فونت نقشه‌دار باید در محیط نصب شود یا از طریق منبع سفارشی مانند [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) یا [LoadOptions.getDocumentLevelFontSources](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/loadoptions/#getDocumentLevelFontSources--) به Aspose.Slides ارائه شود. برای گزینه‌های بارگذاری موجود به [Custom Fonts](/slides/fa/androidjava/custom-font/) مراجعه کنید.

تأیید نقشهٔ ذخیره‌شده فقط نشان می‌دهد تعریف تم حفظ شده است. این به معنای موجود بودن فونت، داشتن تمام گلایف‌های مورد نیاز یا تولید طرح مورد نظر نیست. متن نمونه برای هر سیستم نوشتاری لازم را به یک تصویر یا PDF رندر کنید و خروجی را بررسی کنید. این کار فونت‌های گمشده، پوشش ناقص گلایف‌ها، رفتار fallback و تغییرات طرح را پیش از توزیع ارائه شناسایی می‌کند. برای مثال‌های رندرینگ و صادرات به [Convert PowerPoint Presentations](/slides/fa/androidjava/convert-powerpoint/) مراجعه کنید.

## **پرسش‌های متداول**

**`getScriptFont` چه مقداری باز می‌گرداند وقتی اسکریپت نقشه‌گذاری نشده باشد؟**  
[IFonts.getScriptFont](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/fonts/#getScriptFont-java.lang.String-) زمانی که نقشهٔ اسکریپت درخواست‌شده در آن مجموعهٔ اصلی یا فرعی تعریف نشده باشد، `null` باز می‌گرداند.

**آیا `setScriptFont` وقتی اسکریپت از قبل وجود دارد یک نقشهٔ دوم اضافه می‌کند؟**  
نه. [IFonts.setScriptFont](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/fonts/#setScriptFont-java.lang.String-java.lang.String-) وقتی نقشه وجود نداشته باشد، ایجاد می‌کند و وقتی برچسب اسکریپت یکسان قبلاً موجود باشد، خانوادهٔ فونت نقشه‌دار را جایگزین می‌کند.

**چرا تغییر یک نقشهٔ تم برخی متن‌ها را تغییر نداد؟**  
متن ممکن است فونت به‌طور صریح اختصاص داده شده داشته باشد، تم متفاوتی را از طریق یک بازنویسی به ارث ببرد، یا در هنگام رندر شدن تحت تأثیر جایگزینی یا fallback قرار گیرد. یک نقشهٔ اسکریپت در سطح ارائه تنها بر متنی که قالب‌بندی مؤثرش هنوز به آن مجموعهٔ فونت تم اشاره دارد، کنترل می‌کند.

**آیا ذخیره‌سازی و بازگشایی کافی است تا خروجی چندزبانه را اعتبارسنجی کنیم؟**  
نه. بازگشایی فقط پایداری داده‌های تم را تأیید می‌کند. همچنین باید متن نمونه از هر سیستم نوشتاری مورد نیاز را رندر کنید تا اطمینان حاصل شود فونت‌های نقشه‌دار موجود هستند و گلایف‌های لازم را شامل می‌شوند.