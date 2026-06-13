---
title: مشخص کردن فونت‌های جایگزین برای ارائه‌ها در PHP
linktitle: فونت جایگزین
type: docs
weight: 10
url: /fa/php-java/create-fallback-font/
keywords:
- فونت جایگزین
- قانون جایگزینی
- اعمال فونت
- جایگزینی فونت
- بازه یونیکد
- گلیف از دست رفته
- گلیف مناسب
- PowerPoint
- OpenDocument
- ارائه
- PHP
- Aspose.Slides
description: "Aspose.Slides برای PHP از طریق Java را به‌کار بگیرید تا فونت‌های جایگزین را در فایل‌های PPT، PPTX و ODP تنظیم کنید و نمایش ثابت متن را در هر دستگاه یا سیستم‌عامل تضمین نمایید."
---
## **بررسی کلی**

Aspose.Slides به شما امکان می‌دهد فونت‌های جایگزین را برای رندر و عملیات صادرات ارائه تعیین کنید. فونت‌های جایگزین زمانی استفاده می‌شوند که فونت اصلی شامل گلیف‌های کاراکترهای خاصی نباشد.

رفتار جایگزینی از طریق قواعد جایگزینی پیکربندی می‌شود. هر قانون یک بازه یونیکد را به یک یا چند فونت که ممکن است گلیف‌های مورد نیاز را داشته باشند، مرتبط می‌کند. می‌توانید برای بازه‌های کاراکتری مختلف قوانین تعریف کنید، فونت‌های جایگزین را به قوانین موجود اضافه یا حذف کنید و چندین قانون را در یک مجموعه قواعد فونت جایگزین سازماندهی کنید.

قواعد جایگزینی تنظیمات رندر زمان اجرا هستند. آن‌ها فایل ارائه را تغییر نمی‌دهند و داخل فایل PPTX ذخیره نمی‌شوند.

## **قواعد جایگزینی**

Aspose.Slides کلاس [FontFallBackRule](https://reference.aspose.com/slides/fa/php-java/aspose.slides/FontFallBackRule) را برای مشخص‌کردن قواعدی که یک فونت جایگزین باید اعمال شود، پشتیبانی می‌کند. کلاس [FontFallBackRule](https://reference.aspose.com/slides/fa/php-java/aspose.slides/FontFallBackRule) نمادی است از ارتباط بین بازه یونیکد مشخص‌شده (که برای جستجوی گلیف‌های مفقود استفاده می‌شود) و فهرستی از فونت‌ها که ممکن است گلیف‌های مناسب را داشته باشند:

```php
  $startUnicodeIndex = 0xb80;
  $endUnicodeIndex = 0xbff;
  $firstRule = new FontFallBackRule($startUnicodeIndex, $endUnicodeIndex, "Vijaya");
  $secondRule = new FontFallBackRule(0x3040, 0x309f, "MS Mincho, MS Gothic");
  # با استفاده از روش‌های متعدد می‌توانید فهرست فونت‌ها را اضافه کنید:
  $fontNames = array("Segoe UI Emoji, Segoe UI Symbol", "Arial" );
  $thirdRule = new FontFallBackRule(0x1f300, 0x1f64f, $fontNames);
```

همچنین امکان [حذف](https://reference.aspose.com/slides/fa/php-java/aspose.slides/fontfallbackrule/remove/) فونت جایگزین یا [addFallBackFonts](https://reference.aspose.com/slides/fa/php-java/aspose.slides/fontfallbackrule/addfallbackfonts/) به شی [FontFallBackRule](https://reference.aspose.com/slides/fa/php-java/aspose.slides/FontFallBackRule) موجود وجود دارد.

[FontFallBackRulesCollection](https://reference.aspose.com/slides/fa/php-java/aspose.slides/FontFallBackRulesCollection) می‌تواند برای سازماندهی فهرستی از اشیای [FontFallBackRule](https://reference.aspose.com/slides/fa/php-java/aspose.slides/FontFallBackRule) استفاده شود، زمانی که نیاز به تعیین قواعد جایگزینی فونت برای چندین بازه یونیکد باشد.

{{% alert color="primary" title="See also" %}} 
- [ایجاد مجموعه فونت‌های جایگزین](/slides/fa/php-java/create-fallback-fonts-collection/)
{{% /alert %}}

## **سوالات متداول**

**تفاوت بین فونت جایگزین، جایگزینی فونت و جاسازی فونت چیست؟**

یک فونت جایگزین فقط برای کاراکترهای غایب در فونت اصلی استفاده می‌شود. [جایگزینی فونت](/slides/fa/php-java/font-substitution/) کل فونت مشخص‌شده را با فونت دیگری جایگزین می‌کند. [جاسازی فونت](/slides/fa/php-java/embedded-font/) فونت‌ها را داخل فایل خروجی بسته‌بندی می‌کند تا گیرندگان بتوانند متن را همان‌طور که منظور شده، مشاهده کنند.

**آیا فونت‌های جایگزین در زمان صادرات مانند PDF، PNG یا SVG اعمال می‌شوند یا فقط در رندر روی‑صفحه؟**

بله. جایگزینی بر تمام [عملیات رندر و صادرات](/slides/fa/php-java/convert-presentation/) که کاراکترها باید کشیده شوند ولی در فونت منبع موجود نیستند، تأثیر می‌گذارد.

**آیا پیکربندی جایگزینی فایل ارائه را تغییر می‌دهد و آیا این تنظیم برای باز شدن‌های بعدی حفظ می‌شود؟**

خیر. قواعد جایگزینی تنظیمات رندر زمان اجرا در کد شما هستند؛ آن‌ها داخل پرونده .pptx ذخیره نمی‌شوند و در PowerPoint ظاهر نمی‌شوند.

**آیا سیستم‌عامل (Windows/Linux/macOS) و مجموعهٔ پوشه‌های فونت بر انتخاب جایگزین تأثیر می‌گذارد؟**

بله. موتور فونت‌ها را از پوشه‌های سیستم موجود و هر [مسیر اضافی](/slides/fa/php-java/custom-font/) که شما فراهم می‌کنید، حل می‌کند. اگر یک فونت به‌صورت فیزیکی موجود نباشد، قانون ارجاع‌دهنده به آن قابل اجرا نیست.

**آیا جایگزینی برای WordArt، SmartArt و نمودارها کار می‌کند؟**

بله. وقتی این اشیاء شامل متن می‌شوند، همان مکانیزم جایگزینی گلیف برای رندر کاراکترهای مفقود اعمال می‌شود.