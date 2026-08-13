---
title: تعیین فونت‌های جایگزین برای ارائه‌ها در جاوا
linktitle: فونت جایگزین
type: docs
weight: 10
url: /fa/java/create-fallback-font/
keywords:
- فونت جایگزین
- قانون جایگزین
- اعمال فونت
- جایگزینی فونت
- بازه یونیکد
- گلیف از دست رفته
- گلیف صحیح
- پاورپوینت
- OpenDocument
- ارائه
- جاوا
- Aspose.Slides
description: "آشنایی کامل با Aspose.Slides برای جاوا جهت تنظیم فونت‌های جایگزین در فایل‌های PPT، PPTX و ODP، تضمین نمایش ثابت متن در هر دستگاه یا سیستم‌عامل."
---
## **مرور کلی**

Aspose.Slides به شما امکان می‌دهد فونت‌های جایگزین برای رندرینگ و عملیات خروجی ارائه را مشخص کنید. فونت‌های جایگزین زمانی استفاده می‌شوند که فونت اصلی گلیف‌های مربوط به برخی کاراکترها را نداشته باشد.

رفتار جایگزینی از طریق قوانین fallback پیکربندی می‌شود. هر قانون یک بازه Unicode را با یک یا چند فونت که ممکن است گلیف‌های مورد نیاز را داشته باشند، مرتبط می‌کند. می‌توانید قوانین را برای بازه‌های کاراکتری مختلف تعریف کنید، فونت‌های جایگزین را به قوانین موجود اضافه یا حذف کنید و چندین قانون را در یک مجموعه قوانین فونت‌های جایگزین سازماندهی کنید.

قوانین fallback تنظیمات رندرینگ در زمان اجرا هستند. آن‌ها فایل ارائه را تغییر نمی‌دهند و در داخل فایل PPTX ذخیره نمی‌شوند.

## **قوانین جایگزینی**

Aspose.Slides رابط [IFontFallBackRule](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IFontFallBackRule) و کلاس [FontFallBackRule](https://reference.aspose.com/slides/fa/java/com.aspose.slides/FontFallBackRule) را برای مشخص کردن قواعد اعمال فونت جایگزین پشتیبانی می‌کند. کلاس [FontFallBackRule](https://reference.aspose.com/slides/fa/java/com.aspose.slides/FontFallBackRule) یک ارتباط بین بازه Unicode مشخص‌شده، که برای جستجوی گلیف‌های مفقود استفاده می‌شود، و فهرستی از فونت‌ها که ممکن است گلیف‌های مناسب را داشته باشند، نشان می‌دهد:

```java
import com.aspose.slides.*;

long startUnicodeIndex = 0x0B80;
long endUnicodeIndex = 0x0BFF;

IFontFallBackRule firstRule = new FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
IFontFallBackRule secondRule = new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic");

//با استفاده از روش‌های مختلف می‌توانید فهرست فونت‌ها را اضافه کنید:
String[] fontNames = new String[] { "Segoe UI Emoji, Segoe UI Symbol", "Arial" };

IFontFallBackRule thirdRule = new FontFallBackRule(0x1F300, 0x1F64F, fontNames);
```

همچنین امکان [remove](https://reference.aspose.com/slides/fa/java/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) حذف فونت جایگزین یا [addFallBackFonts](https://reference.aspose.com/slides/fa/java/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) اضافه کردن فونت‌های جایگزین به شیء [FontFallBackRule](https://reference.aspose.com/slides/fa/java/com.aspose.slides/FontFallBackRule) موجود وجود دارد.

کلاس [FontFallBackRulesCollection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/FontFallBackRulesCollection) می‌تواند برای سازماندهی فهرستی از اشیاء [FontFallBackRule](https://reference.aspose.com/slides/fa/java/com.aspose.slides/FontFallBackRule) استفاده شود، زمانی که نیاز به تعیین قواعد جایگزینی فونت‌های fallback برای چندین بازه Unicode باشد.

{{% alert color="info" title="See also" %}} 
- [ایجاد مجموعه فونت‌های جایگزین](/slides/fa/java/create-fallback-fonts-collection/)
{{% /alert %}}

## **سوالات متداول**

### تفاوت فونت جایگزین، جایگزینی فونت و جاسازی فونت چیست؟

فونت جایگزین فقط برای کاراکترهایی که در فونت اصلی موجود نیستند استفاده می‌شود. [Font substitution](/slides/fa/java/font-substitution/) کل فونت مشخص‌شده را با فونت دیگری جایگزین می‌کند. [Font embedding](/slides/fa/java/embedded-font/) فونت‌ها را داخل فایل خروجی بسته‌بندی می‌کند تا دریافت‌کنندگان بتوانند متن را همان‌گونه که منظور شده مشاهده کنند.

### آیا فونت‌های جایگزین در هنگام خروجی‌گیری مانند PDF، PNG یا SVG اعمال می‌شوند یا فقط در رندرینگ روی صفحه نمایش؟

بله. فونت‌های جایگزین بر تمام [rendering and export operations](/slides/fa/java/convert-presentation/) که در آن‌ها کاراکترها باید رسم شوند اما در فونت منبع موجود نیستند، تأثیر می‌گذارند.

### آیا پیکربندی جایگزینی فایل ارائه را تغییر می‌دهد و آیا تنظیم برای باز شدن‌های آینده باقی می‌ماند؟

خیر. قوانین fallback تنظیمات رندرینگ در زمان اجرا در کد شما هستند؛ در داخل فایل .pptx ذخیره نمی‌شوند و در پاورپوینت ظاهر نمی‌شوند.

### آیا سیستم عامل (Windows/Linux/macOS) و مجموعهٔ پوشه‌های فونت بر انتخاب جایگزین تأثیر می‌گذارد؟

بله. موتور فونت‌ها را از پوشه‌های سیستم موجود و هر [additional paths](/slides/fa/java/custom-font/) که شما فراهم می‌کنید، پیدا می‌کند. اگر فونتی به طور فیزیکی موجود نباشد، قانونی که به آن اشاره دارد نمی‌تواند اعمال شود.

### آیا جایگزینی برای WordArt، SmartArt و نمودارها کار می‌کند؟

بله. زمانی که این اشیاء شامل متن می‌شوند، همان مکانیزم جایگزینی گلیف برای رسم کاراکترهای مفقود اعمال می‌شود.