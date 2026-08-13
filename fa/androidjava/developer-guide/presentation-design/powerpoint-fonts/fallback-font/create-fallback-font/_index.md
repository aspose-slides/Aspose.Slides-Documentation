---
title: مشخص‌کردن فونت‌های جایگزین برای ارائه‌ها در اندروید
linktitle: فونت جایگزین
type: docs
weight: 10
url: /fa/androidjava/create-fallback-font/
keywords:
- فونت جایگزین
- قانون جایگزین
- اعمال فونت
- جایگزینی فونت
- بازه یونیکد
- گلیف گمشده
- گلیف مناسب
- PowerPoint
- OpenDocument
- ارائه
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides برای اندروید را با استفاده از جاوا به‌کارگیرید تا فونت‌های جایگزین را در فایل‌های PPT، PPTX و ODP تنظیم کنید و نمایش متن یکسان را در هر دستگاه یا سیستم‌عاملی تضمین کنید."
---
## **مروری کلی**

Aspose.Slides به شما امکان می‌دهد فونت‌های جایگزین را برای رندر و عملیات صادرات ارائه تعیین کنید. فونت‌های جایگزین زمانی استفاده می‌شوند که فونت اصلی گلیف‌های کاراکترهای خاصی را نداشته باشد.

رفتار جایگزینی از طریق قوانین جایگزین پیکربندی می‌شود. هر قانون یک بازه یونیکد را با یک یا چند فونت که ممکن است گلیف‌های مورد نیاز را داشته باشند، مرتبط می‌کند. می‌توانید برای بازه‌های کاراکتری مختلف قوانین تعریف کنید، فونت‌های جایگزین را از قوانین موجود اضافه یا حذف کنید و چندین قانون را در یک مجموعه قوانین فونت جایگزین سازماندهی کنید.

قوانین جایگزین تنظیمات رندر در زمان اجرا هستند. آن‌ها فایل ارائه را تغییر نمی‌دهند و در داخل فایل PPTX ذخیره نمی‌شوند.

## **قوانین جایگزین**

Aspose.Slides رابط [IFontFallBackRule](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IFontFallBackRule) و کلاس [FontFallBackRule](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/FontFallBackRule) را برای مشخص کردن قوانینی که فونت جایگزین را اعمال می‌کنند، پشتیبانی می‌کند. کلاس [FontFallBackRule](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/FontFallBackRule) نشان‌دهندهٔ ارتباط بین بازهٔ یونیکد مشخص‌شده، که برای جستجوی گلیف‌های گمشده استفاده می‌شود، و فهرستی از فونت‌هایی است که ممکن است گلیف‌های مناسب را داشته باشند:

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

همچنین می‌توانید فونت جایگزین را [remove](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) کنید یا [addFallBackFonts](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) را به شیء [FontFallBackRule](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/FontFallBackRule) موجود اضافه کنید.

می‌توان از [FontFallBackRulesCollection](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/FontFallBackRulesCollection) برای سازماندهی فهرستی از اشیای [FontFallBackRule](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/FontFallBackRule) استفاده کرد، هنگامی که نیاز به تعیین قوانین جایگزینی فونت برای چندین بازهٔ یونیکد باشد.

{{% alert color="info" title="همچنین ببینید" %}} 
- [Create Fallback Fonts Collection](/slides/fa/androidjava/create-fallback-fonts-collection/)
{{% /alert %}}

## **سوالات متداول**

### تفاوت فونت جایگزین، جایگزینی فونت و جاسازی فونت چیست؟

یک فونت جایگزین فقط برای کاراکترهایی که در فونت اصلی موجود نیستند، استفاده می‌شود. [Font substitution](/slides/fa/androidjava/font-substitution/) کل فونت مشخص‌شده را با فونت دیگری جایگزین می‌کند. [Font embedding](/slides/fa/androidjava/embedded-font/) فونت‌ها را داخل فایل خروجی بسته‌بندی می‌کند تا دریافت‌کنندگان بتوانند متن را همان‌گونه که منظور شده است، مشاهده کنند.

### آیا فونت‌های جایگزین در زمان صادرات مانند PDF، PNG یا SVG اعمال می‌شوند یا فقط در رندر روی صفحه نمایش؟

بله. جایگزین کردن بر تمام [rendering and export operations](/slides/fa/androidjava/convert-presentation/) که در آن کاراکترها باید رسم شوند اما در فونت منبع وجود ندارند، تأثیر می‌گذارد.

### آیا پیکربندی فونت جایگزین فایل ارائه را تغییر می‌دهد و آیا تنظیم برای باز کردن‌های بعدی باقی می‌ماند؟

خیر. قوانین جایگزین تنظیمات رندر در زمان اجرا در کد شما هستند؛ آنها در داخل فایل .pptx ذخیره نمی‌شوند و در PowerPoint نشان داده نمی‌شوند.

### آیا سیستم‌عامل (Windows/Linux/macOS) و مجموعهٔ مسیرهای فونت بر انتخاب جایگزین تأثیر می‌گذارد؟

بله. موتور فونت‌ها را از پوشه‌های سیستم موجود و هر [additional paths](/slides/fa/androidjava/custom-font/) که ارائه می‌دهید، پیدا می‌کند. اگر فونتی به‌صورت فیزیکی موجود نباشد، قانونی که به آن اشاره دارد نمی‌تواند اعمال شود.

### آیا جایگزینی برای WordArt، SmartArt و نمودارها اعمال می‌شود؟

بله. وقتی این اشیا شامل متن می‌شوند، همان مکانیزم جایگزینی گلیف برای رندر کاراکترهای گمشده اعمال می‌شود.