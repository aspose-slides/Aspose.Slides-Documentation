---
title: مشخص کردن فونت‌های فالبیک برای ارائه‌ها در جاوا
linktitle: فونت فالبیک
type: docs
weight: 10
url: /fa/java/create-fallback-font/
keywords:
- فونت فالبیک
- قانون فالبیک
- اعمال فونت
- جایگزینی فونت
- بازه یونیکد
- گلیف گمشده
- گلیف مناسب
- PowerPoint
- OpenDocument
- ارائه
- Java
- Aspose.Slides
description: "به‌کارگیری کامل Aspose.Slides برای جاوا جهت تنظیم فونت‌های فالبیک در فایل‌های PPT، PPTX و ODP، به‌منظور حفظ نمایش متنی یکسان در هر دستگاه یا سیستم‌عامل."
---
## **Overview**

Aspose.Slides به شما امکان می‌دهد فونت‌های فالبیک را برای رندرینگ و عملیات خروجی‌گیری ارائه‌ها مشخص کنید. فونت‌های فالبیک زمانی استفاده می‌شوند که فونت اصلی برای کاراکترهای خاص گلیف نداشته باشد.

رفتار فالبیک از طریق قوانین فالبیک پیکربندی می‌شود. هر قانون یک بازه Unicode را با یک یا چند فونت که ممکن است گلیف‌های مورد نیاز را داشته باشند، مرتبط می‌کند. می‌توانید قوانین برای بازه‌های مختلف کاراکتر تعریف کنید، فونت‌های فالبیک را به قوانین موجود اضافه یا حذف کنید و چندین قانون را در یک مجموعه قوانین فونت فالبیک سازماندهی کنید.

قوانین فالبیک تنظیمات رندرینگ زمان اجرا هستند. آن‌ها فایل ارائه را تغییر نمی‌دهند و داخل فایل PPTX ذخیره نمی‌شوند.

## **Fallback Rules**

Aspose.Slides از اینترفیس [IFontFallBackRule](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IFontFallBackRule) و کلاس [FontFallBackRule](https://reference.aspose.com/slides/fa/java/com.aspose.slides/FontFallBackRule) برای مشخص کردن قوانینی که فونت فالبیک را اعمال می‌کند، پشتیبانی می‌کند. کلاس [FontFallBackRule](https://reference.aspose.com/slides/fa/java/com.aspose.slides/FontFallBackRule) نمایانگر ارتباط بین بازه Unicode مشخص‌شده (که برای جستجوی گلیف‌های گمشده استفاده می‌شود) و فهرستی از فونت‌هاست که ممکن است گلیف‌های مناسب را داشته باشند:

```java
long startUnicodeIndex = 0x0B80;
long endUnicodeIndex = 0x0BFF;

IFontFallBackRule firstRule = new FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
IFontFallBackRule secondRule = new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic");

//با استفاده از روش‌های مختلف می‌توانید فهرست فونت‌ها را اضافه کنید:
String[] fontNames = new String[] { "Segoe UI Emoji, Segoe UI Symbol", "Arial" };

IFontFallBackRule thirdRule = new FontFallBackRule(0x1F300, 0x1F64F, fontNames);
```

همچنین می‌توانید فونت فالبیک را [remove](https://reference.aspose.com/slides/fa/java/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) کنید یا با استفاده از [addFallBackFonts](https://reference.aspose.com/slides/fa/java/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) به شیء موجود [FontFallBackRule](https://reference.aspose.com/slides/fa/java/com.aspose.slides/FontFallBackRule) اضافه کنید.

[FontFallBackRulesCollection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/FontFallBackRulesCollection) می‌تواند برای سازماندهی فهرستی از اشیای [FontFallBackRule](https://reference.aspose.com/slides/fa/java/com.aspose.slides/FontFallBackRule) استفاده شود، وقتی که نیاز به تعیین قوانین جایگزینی فونت فالبیک برای چندین بازه Unicode وجود دارد.

{{% alert color="primary" title="See also" %}} 
- [ایجاد مجموعه فونت‌های فالبیک](/slides/fa/java/create-fallback-fonts-collection/)
{{% /alert %}}

## **FAQ**

**تفاوت بین فونت فالبیک، جایگزینی فونت و تعبیه فونت چیست؟**

یک فونت فالبیک فقط برای کاراکترهایی که در فونت اصلی موجود نیستند استفاده می‌شود. [Font substitution](/slides/fa/java/font-substitution/) کل فونت مشخص‌شده را با فونت دیگری جایگزین می‌کند. [Font embedding](/slides/fa/java/embedded-font/) فونت‌ها را داخل فایل خروجی بسته‌بندی می‌کند تا دریافت‌کنندگان بتوانند متن را همان‌طور که منظور شده است مشاهده کنند.

**آیا فونت‌های فالبیک در زمان خروجی‌گیری مانند PDF، PNG یا SVG اعمال می‌شوند یا فقط در رندرینگ روی صفحه؟**

بله. فالبیک بر تمام [rendering and export operations](/slides/fa/java/convert-presentation/) که کاراکترها باید رسم شوند اما در فونت منبع موجود نیستند، تأثیر می‌گذارد.

**آیا پیکربندی فالبیک فایل ارائه را تغییر می‌دهد و آیا این تنظیم برای باز شدن‌های آینده باقی می‌ماند؟**

خیر. قوانین فالبیک تنظیمات رندرینگ زمان اجرا در کد شما هستند؛ آن‌ها داخل فایل .pptx ذخیره نمی‌شوند و در PowerPoint نشان داده نمی‌شوند.

**آیا سیستم‌عامل (Windows/Linux/macOS) و مجموعهٔ پوشه‌های فونت بر انتخاب فالبیک تأثیر می‌گذارد؟**

بله. موتور فونت‌ها را از پوشه‌های سیستم موجود و هر [additional paths](/slides/fa/java/custom-font/) که ارائه می‌کنید، حل می‌کند. اگر یک فونت به صورت فیزیکی در دسترس نباشد، قانونی که به آن ارجاع می‌دهد نمی‌تواند اثر کند.

**آیا فالبیک برای WordArt، SmartArt و نمودارها کار می‌کند؟**

بله. وقتی این اشیاء حاوی متن هستند، همان مکانیزم جایگزینی گلیف برای رندر کردن کاراکترهای گمشده اعمال می‌شود.