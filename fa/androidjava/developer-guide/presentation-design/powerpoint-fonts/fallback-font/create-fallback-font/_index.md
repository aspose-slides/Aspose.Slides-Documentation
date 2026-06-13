---
title: مشخص کردن فونت‌های جایگزین برای ارائه‌ها در اندروید
linktitle: فونت جایگزین
type: docs
weight: 10
url: /fa/androidjava/create-fallback-font/
keywords:
- فونت جایگزین
- قانون جایگزین
- اعمال فونت
- جایگزین کردن فونت
- بازه یونیکد
- گلیف گمشده
- گلیف مناسب
- PowerPoint
- OpenDocument
- ارائه
- اندروید
- جاوا
- Aspose.Slides
description: "Aspose.Slides برای اندروید را با جاوا به‌کار بگیرید تا فونت‌های جایگزین را در فایل‌های PPT، PPTX و ODP تنظیم کنید و نمایش یکپارچهٔ متن را در هر دستگاه یا سیستم عاملی تضمین کنید."
---
## **مرور کلی**

Aspose.Slides به شما امکان مشخص کردن فونت‌های جایگزین برای رندر و عملیات خروجی ارائه‌ها را می‌دهد. فونت‌های جایگزین زمانی استفاده می‌شوند که فونت اصلی شامل گلیف‌های کاراکترهای خاصی نباشد.

رفتار جایگزینی از طریق قوانین جایگزینی پیکربندی می‌شود. هر قانون یک بازهٔ یونیکد را با یک یا چند فونت که ممکن است گلیف‌های مورد نیاز را داشته باشند، مرتبط می‌کند. می‌توانید قوانین را برای بازه‌های کاراکتری مختلف تعریف کنید، فونت‌های جایگزین را به قوانین موجود اضافه یا حذف کنید و چندین قانون را در یک مجموعهٔ قوانین فونت جایگزین سازماندهی کنید.

قوانین جایگزینی تنظیمات رندر زمان اجرا هستند. آن‌ها فایل ارائه را تغییر نمی‌دهند و داخل فایل PPTX ذخیره نمی‌شوند.

## **قواعد جایگزینی فونت**

Aspose.Slides از اینترفیس [IFontFallBackRule](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IFontFallBackRule) و کلاس [FontFallBackRule](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/FontFallBackRule) برای مشخص کردن قواعد اعمال فونت جایگزین پشتیبانی می‌کند. کلاس [FontFallBackRule](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/FontFallBackRule) نمایانگر ارتباط بین بازهٔ یونیکد مشخص‌شده (که برای جستجوی گلیف‌های گمشده استفاده می‌شود) و فهرستی از فونت‌ها است که ممکن است گلیف‌های مناسب را داشته باشند:

```java
long startUnicodeIndex = 0x0B80;
long endUnicodeIndex = 0x0BFF;

IFontFallBackRule firstRule = new FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
IFontFallBackRule secondRule = new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic");

//استفاده از روش‌های مختلف می‌توانید فهرست فونت‌ها را اضافه کنید:
String[] fontNames = new String[] { "Segoe UI Emoji, Segoe UI Symbol", "Arial" };

IFontFallBackRule thirdRule = new FontFallBackRule(0x1F300, 0x1F64F, fontNames);
```

همچنین امکان [remove](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) فونت جایگزین یا [addFallBackFonts](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) به شیء [FontFallBackRule](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/FontFallBackRule) موجود وجود دارد.

[FontFallBackRulesCollection](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/FontFallBackRulesCollection) می‌تواند برای سازماندهی فهرستی از اشیای [FontFallBackRule](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/FontFallBackRule) استفاده شود، هنگامی که نیاز به مشخص کردن قواعد جایگزینی فونت برای بازه‌های یونیکد متعدد باشد.

{{% alert color="primary" title="See also" %}} 
- [ایجاد مجموعهٔ فونت‌های جایگزین](/slides/fa/androidjava/create-fallback-fonts-collection/)
{{% /alert %}}

## **سوالات متداول**

**تفاوت بین فونت جایگزین، جایگزینی فونت و جاسازی فونت چیست؟**

یک فونت جایگزین فقط برای کاراکترهای گمشده در فونت اصلی استفاده می‌شود. [Font substitution](/slides/fa/androidjava/font-substitution/) کل فونت مشخص‌شده را با فونت دیگری جایگزین می‌کند. [Font embedding](/slides/fa/androidjava/embedded-font/) فونت‌ها را داخل فایل خروجی بسته‌بندی می‌کند تا دریافت‌کنندگان بتوانند متن را همان‌طور که منظور شده است ببینند.

**آیا فونت‌های جایگزین فقط در رندر روی صفحه نمایش اعمال می‌شوند یا در عملیات خروجی مانند PDF، PNG یا SVG نیز کار می‌کنند؟**

بله. جایگزینی بر تمام [رندر و عملیات خروجی](/slides/fa/androidjava/convert-presentation/) که کاراکترها باید رسم شوند اما در فونت منبع موجود نیستند، تأثیر می‌گذارد.

**آیا پیکربندی جایگزینی فایل ارائه را تغییر می‌دهد و آیا این تنظیم برای باز کردن‌های آینده حفظ می‌شود؟**

نه. قوانین جایگزینی تنظیمات رندر زمان اجرا در کد شما هستند؛ آن‌ها داخل فایل .pptx ذخیره نمی‌شوند و در پاورپوینت نمایان نخواهند شد.

**آیا سیستم‌عامل (Windows/Linux/macOS) و مجموعهٔ پوشه‌های فونت بر انتخاب جایگزین تأثیر می‌گذارد؟**

بله. موتور فونت‌ها را از پوشه‌های سیستمی موجود و هر [مسیر اضافی](/slides/fa/androidjava/custom-font/) که شما فراهم می‌کنید، بازیابی می‌کند. اگر یک فونت به صورت فیزیکی در دسترس نباشد، قانونی که به آن ارجاع می‌دهد نمی‌تواند مؤثر باشد.

**آیا جایگزینی برای WordArt، SmartArt و نمودارها کار می‌کند؟**

بله. وقتی این اشیاء شامل متن هستند، همان مکانیزم جایگزینی گلیف برای رندر کاراکترهای گمشده اعمال می‌شود.