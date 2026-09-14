---
title: مدیریت قلم‌های تم مخصوص اسکریپت در پایتون از طریق جاوا
linktitle: قلم‌های تم مخصوص اسکریپت
type: docs
weight: 15
url: /fa/python-java/script-specific-font-mappings/
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
- Python
- Java
- Aspose.Slides
description: "بررسی، افزودن، جایگزینی و حذف نگاشت‌های قلم مخصوص اسکریپت در تم‌های PowerPoint با Aspose.Slides برای Python از طریق جاوا."
---
## **نمای کلی**

یک تم ارائه می‌تواند خانواده‌های قلم متفاوتی را برای سیستم‌های نوشتاری مختلف انتخاب کند. این امکان را می‌دهد که متن چندزبانه که هنوز از قلم‌های تم استفاده می‌کند، یک طرح قلم هماهنگ را دنبال کند در حالی که از قلم‌های مناسب برای سیریلیک، عربی، ژاپنی، گرجی، ثانا و سایر اسکریپت‌ها استفاده می‌کند.

تم شامل مجموعه قلم اصلی ([FontScheme](https://reference.aspose.com/slides/fa/python-java/aspose.slides/fontscheme/)) است که معمولاً برای سرفصل‌ها استفاده می‌شود و مجموعه قلم جزئی که معمولاً برای متن اصلی به کار می‌رود. علاوه بر تنظیمات قلم‌های لاتین و شرق آسیایی، هر دو مجموعه نگاشت‌هایی از برچسب‌های سیستم نوشتاری به نام‌های خانواده قلم از طریق کلاس [Fonts](https://reference.aspose.com/slides/fa/python-java/aspose.slides/fonts/) ارائه می‌دهند.

این مقاله نشان می‌دهد چگونه این نگاشت‌ها را در تم اصلی ارائه بررسی و تغییر داده و اطمینان حاصل می‌کند که تغییرات پس از ذخیره‑و‑بارگذاری حفظ می‌شوند.

## **درک برچسب‌های اسکریپت**

متدهای قلم اسکریپت از زیربرچسب‌های چهار حرفی BCP 47 برای شناسایی سیستم‌های نوشتاری استفاده می‌کنند. مقدارهای رایج شامل موارد زیر است:

| برچسب اسکریپت | سیستم نوشتاری |
|---|---|
| `Cyrl` | سیریلیک |
| `Arab` | عربی |
| `Hans` | چینی ساده‌سازی شده |
| `Jpan` | ژاپنی |
| `Geor` | گرجی |
| `Thaa` | ثانا |

این نگاشت‌ها به طرح قلم تم تعلق دارند، نه به بخش‌های متنی جداگانه. یک ارائه ممکن است نگاشت‌های متفاوتی برای مجموعه‌های اصلی و جزئی تعریف کند و ممکن است برخی از اسکریپت‌ها را حذف کند.

## **دسترسی و بازرسی نگاشت‌های قلم اسکریپت**

از [Presentation.getMasterTheme](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#getMasterTheme) برای دسترسی به تم سطح ارائه استفاده کنید. متدهای [FontScheme.getMajor](https://reference.aspose.com/slides/fa/python-java/aspose.slides/fontscheme/#getMajor) و [FontScheme.getMinor](https://reference.aspose.com/slides/fa/python-java/aspose.slides/fontscheme/#getMinor) دو مجموعه [Fonts](https://reference.aspose.com/slides/fa/python-java/aspose.slides/fonts/) را برمی‌گردانند.

با فراخوانی [Fonts.getScriptFontMap](https://reference.aspose.com/slides/fa/python-java/aspose.slides/fonts/#getScriptFontMap) می‌توانید تمام نگاشت‌ها را از یک مجموعه دریافت کنید. برای جستجوی یک سیستم نوشتاری، [Fonts.getScriptFont](https://reference.aspose.com/slides/fa/python-java/aspose.slides/fonts/#getScriptFont) را همراه با برچسب اسکریپت آن فراخوانی کنید. `getScriptFont` زمانی که آن مجموعه نگاشت درخواست‌شده را تعریف نکرده باشد، `None` برمی‌گرداند.

## **تغییر نگاشت‌ها و تأیید پایداری**

از [Fonts.setScriptFont](https://reference.aspose.com/slides/fa/python-java/aspose.slides/fonts/#setScriptFont) برای ایجاد یک نگاشت یا جایگزینی خانواده قلم فعلی استفاده کنید. برای حذف یک نگاشت، از [Fonts.removeScriptFont](https://reference.aspose.com/slides/fa/python-java/aspose.slides/fonts/#removeScriptFont) بهره بگیرید.

مثال کامل زیر تمام نگاشت‌های اصلی و جزئی موجود را می‌خواند، قلم اصلی ژاپنی را جستجو می‌کند، قلم اصلی سیریلیک را تغییر می‌دهد، نگاشت جزئی ثانا را حذف می‌کند، ارائه را ذخیره و سپس باز می‌کند تا هر دو تغییر را تأیید نماید. برای اینکه گام حذف مستقل از تم اولیه باشد، مثال ابتدا فقط در صورتی که نگاشت ثانا تعریف نشده باشد، یک نگاشت ثانا ایجاد می‌کند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    font_scheme = presentation.getMasterTheme().getFontScheme()
    major_fonts = font_scheme.getMajor()
    minor_fonts = font_scheme.getMinor()

    print("Existing major mappings:")
    major_mappings = major_fonts.getScriptFontMap().iterator()
    while major_mappings.hasNext():
        mapping = major_mappings.next()
        print(f"  {mapping.getKey()}: {mapping.getValue()}")

    print("Existing minor mappings:")
    minor_mappings = minor_fonts.getScriptFontMap().iterator()
    while minor_mappings.hasNext():
        mapping = minor_mappings.next()
        print(f"  {mapping.getKey()}: {mapping.getValue()}")

    japanese_font = major_fonts.getScriptFont("Jpan")
    if japanese_font is None:
        print("No major Japanese font is defined.")
    else:
        print(f"Major Japanese font: {japanese_font}")

    major_fonts.setScriptFont("Cyrl", "Arial")

    if minor_fonts.getScriptFont("Thaa") is None:
        minor_fonts.setScriptFont("Thaa", "Arial")

    minor_fonts.removeScriptFont("Thaa")
    presentation.save("script-font-mappings.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()

saved_presentation = Presentation("script-font-mappings.pptx")
try:
    saved_major_fonts = saved_presentation.getMasterTheme().getFontScheme().getMajor()
    saved_minor_fonts = saved_presentation.getMasterTheme().getFontScheme().getMinor()
    saved_cyrillic_font = saved_major_fonts.getScriptFont("Cyrl")
    saved_thaana_font = saved_minor_fonts.getScriptFont("Thaa")

    if saved_cyrillic_font == "Arial":
        print("The Cyrillic mapping was preserved.")
    else:
        print("The Cyrillic mapping was not preserved.")

    if saved_thaana_font is None:
        print("The Thaana mapping removal was preserved.")
    else:
        print("The Thaana mapping still exists.")
finally:
    saved_presentation.dispose()
```

تأیید از همان رفتار `None` در یک جستجوی عادی استفاده می‌کند: پس از ذخیره‌سازی حذف، `getScriptFont("Thaa")` برای مجموعه جزئی `None` برمی‌گرداند.

## **تمایز نگاشت‌های تم از سایر تنظیمات قلم**

نگاشت‌های تم مخصوص اسکریپت در انتخاب قلم نقش دارند، اما مشکلی متفاوت را نسبت به قالب‌بندی مستقیم متن، جایگزینی و فالت حل می‌کنند:

| مکانیزم | هدف | اثر تغییر یک نگاشت تم |
|---|---|---|
| نگاشت قلم تم مخصوص اسکریپت | یک قلم تم اصلی یا جزئی را برای یک سیستم نوشتاری انتخاب می‌کند. | متنی که هنوز از قلم تم مربوطه استفاده می‌کند می‌تواند به خانواده قلم جدید نگاشت‌شده حل شود. |
| قلم اختصاص داده‌شده صریحاً به یک بخش متن | خانواده قلم درخواست‌شده را بر روی آن بخش ثابت می‌کند به جای اتکای به تم. | این بخش ممکن است بدون تغییر بماند زیرا قالب‌بندی مستقیم آن انتخاب تم را بازنویسی می‌کند. |
| جایگزینی قلم | وقتی قلم درخواست‌شده در دسترس نیست یا قاعده جایگزینی اعمال می‌شود، قلم را جایگزین می‌کند. | پس از درخواست قلم عمل می‌کند؛ نگاشت اسکریپت تم را بازتعریف نمی‌کند. |
| قلم فالت | علائم (glyph)ی که قلم انتخاب‌شده شامل آنها نیست را فراهم می‌کند، اغلب برای بازه‌های خاص یونی‌کد. | پوشش گلیف‌های گمشده را تکمیل می‌کند؛ نگاشت تم ذخیره‌شده را تغییر نمی‌دهد. |

برای اطلاعات بیشتر درباره دو مکانیزم آخر، به [جایگزینی قلم](/slides/fa/python-java/font-substitution/) و [قلم‌های فالت](/slides/fa/python-java/fallback-font/) مراجعه کنید.

تغییر یک نگاشت در [Presentation.getMasterTheme](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#getMasterTheme) فقط بر محتوایی که قالب‌بندی مؤثر آن هنوز به آن تم وابسته است تأثیر می‌گذارد. متن می‌تواند به جای آن، یک تغییر تم از یک مستر، چیدمان یا اسلاید به ارث ببرد یا از قلم اختصاص داده‌شده صریحاً استفاده کند. وقتی نتایج قابل مشاهده با نگاشت سطح ارائه مطابقت ندارند، این سطوح را بررسی کنید.

## **در دسترس قرار دادن قلم‌های نگاشت‌شده و اعتبارسنجی نتیجه**

یک نگاشت اسکریپت نام یک خانواده قلم را ذخیره می‌کند؛ قلم مربوطه را نصب یا بارگذاری نمی‌کند. برای رندر و خروجی یکسان، هر قلم نگاشت‌شده باید در محیط نصب شده باشد یا از طریق منبع سفارشی مانند [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/fa/python-java/aspose.slides/fontsloader/#loadExternalFonts) یا [LoadOptions.getDocumentLevelFontSources](https://reference.aspose.com/slides/fa/python-java/aspose.slides/loadoptions/#getDocumentLevelFontSources) به Aspose.Slides ارائه شود. گزینه‌های بارگذاری موجود را در [قلم‌های سفارشی](/slides/fa/python-java/custom-font/) ببینید.

تأیید نگاشت ذخیره‌شده فقط نشان می‌دهد تعریف تم حفظ شده است. این تضمین نمی‌کند که قلم در دسترس باشد، تمام گلیف‌های لازم را داشته باشد یا چیدمان مطلوب را تولید کند. متن نمونه برای هر سیستم نوشتاری مورد نیاز را به تصویر یا PDF رندر کنید و خروجی را بررسی کنید. این کار قلم‌های گمشده، پوشش ناقص گلیف، رفتار فالت و تغییرات چیدمان را قبل از توزیع ارائه شناسایی می‌کند. برای مثال‌های رندر و خروجی به [تبدیل ارائه‌های پاورپوینت](/slides/fa/python-java/convert-powerpoint/) مراجعه کنید.

## **سؤالات متداول**

**`getScriptFont` وقتی یک اسکریپت نگاشت نشده است چه مقدار برمی‌گرداند؟**

`[Fonts.getScriptFont](https://reference.aspose.com/slides/fa/python-java/aspose.slides/fonts/#getScriptFont)` وقتی نگاشت اسکریپت درخواست‌شده در آن مجموعه قلم اصلی یا جزئی تعریف نشده باشد، `None` برمی‌گرداند.

**آیا `setScriptFont` وقتی اسکریپت قبلاً وجود داشته باشد، یک نگاشت دوم اضافه می‌کند؟**

خیر. `[Fonts.setScriptFont](https://reference.aspose.com/slides/fa/python-java/aspose.slides/fonts/#setScriptFont)` زمانی که نگاشت موجود نباشد، آن را ایجاد می‌کند و وقتی برچسب اسکریپت همان‌طور موجود باشد، خانواده قلم نگاشت‌شده را جایگزین می‌کند.

**چرا تغییر یک نگاشت تم بعضی متن‌ها را تغییر نداد؟**

متن ممکن است قلم اختصاص داده‌شده صریحاً داشته باشد، تم متفاوتی را از طریق یک بازنویسی به ارث ببرد یا در رندر تحت تأثیر جایگزینی یا فالت باشد. یک نگاشت اسکریپت سطح ارائه فقط بر متنی که قالب‌بندی مؤثر آن هنوز به مجموعه قلم تم آن ارجاع می‌دهد، کنترل دارد.

**آیا ذخیره و بازگشایی کافی است تا خروجی چندزبانه اعتبارسنجی شود؟**

خیر. بازگشائی فقط پایداری داده‌های تم را تأیید می‌کند. همچنین متن نمونه‌ای از هر سیستم نوشتاری مورد نیاز را رندر کنید تا از در دسترس بودن قلم‌های نگاشت‌شده و داشتن گلیف‌های لازم اطمینان حاصل کنید.