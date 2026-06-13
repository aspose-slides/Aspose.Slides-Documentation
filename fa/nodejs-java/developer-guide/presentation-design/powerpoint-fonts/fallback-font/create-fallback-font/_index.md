---
title: "مشخص کردن فونت‌های جایگزین برای ارائه‌ها در JavaScript"
linktitle: "فونت جایگزین"
type: docs
weight: 10
url: /fa/nodejs-java/create-fallback-font/
keywords:
- "فونت جایگزین"
- "قانون جایگزین"
- "اعمال فونت"
- "جایگزینی فونت"
- "بازه Unicode"
- "گلیف گمشده"
- "گلیف صحیح"
- PowerPoint
- OpenDocument
- "ارائه"
- Node.js
- JavaScript
- Aspose.Slides
description: "یکپارچه با Aspose.Slides برای Node.js، برای تنظیم فونت‌های جایگزین در فایل‌های PPT، PPTX و ODP در JavaScript، اطمینان از نمایش متن به‌صورت سازگار در هر دستگاه یا سیستم‌عامل."
---
## **بررسی کلی**

Aspose.Slides به شما امکان می‌دهد تا فونت‌های جایگزین را برای رندر ارائه و عملیات خروجی تعیین کنید. فونت‌های جایگزین زمانی استفاده می‌شوند که فونت اصلی گلیف‌های کاراکترهای خاصی را نداشته باشد.

رفتار جایگزینی از طریق قوانین جایگزین پیکربندی می‌شود. هر قانون یک بازه یونیکد را با یک یا چند فونت که ممکن است گلیف‌های مورد نیاز را داشته باشند، مرتبط می‌کند. می‌توانید قوانین را برای بازه‌های کاراکتر مختلف تعریف کنید، فونت‌های جایگزین را از قوانین موجود اضافه یا حذف کنید و چندین قانون را در یک مجموعه قوانین فونت جایگزین سازماندهی کنید.

قوانین جایگزین تنظیمات رندر در زمان اجرا هستند. آنها فایل ارائه را تغییر نمی‌دهند و در فایل PPTX ذخیره نمی‌شوند.

## **قوانین جایگزینی**

Aspose.Slides کلاس [FontFallBackRule](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/FontFallBackRule) و [FontFallBackRule](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/FontFallBackRule) را برای تعیین قوانین اعمال فونت جایگزین پشتیبانی می‌کند. کلاس [FontFallBackRule](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/FontFallBackRule) نمایانگر ارتباط بین بازه یونیکد مشخص شده، که برای جستجوی گلیف‌های از دست رفته استفاده می‌شود، و لیستی از فونت‌هاست که ممکن است گلیف‌های مناسب را داشته باشند:

```javascript
var startUnicodeIndex = 0xb80;
var endUnicodeIndex = 0xbff;
var firstRule = new aspose.slides.FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
var secondRule = new aspose.slides.FontFallBackRule(0x3040, 0x309f, "MS Mincho, MS Gothic");
// با استفاده از روش‌های مختلف می‌توانید فهرست فونت‌ها را اضافه کنید:
var fontNames = java.newArray("java.lang.String", ["Segoe UI Emoji, Segoe UI Symbol", "Arial"]));
var thirdRule = new aspose.slides.FontFallBackRule(0x1f300, 0x1f64f, fontNames);
```

همچنین می‌توانید با استفاده از [remove](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/FontFallBackRule#remove-java.lang.String-) فونت جایگزین را حذف کنید یا با استفاده از [addFallBackFonts](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) به شیء [FontFallBackRule](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/FontFallBackRule) موجود فونت‌های جایگزین اضافه کنید.

کلاس [FontFallBackRulesCollection](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/FontFallBackRulesCollection) می‌تواند برای سازماندهی فهرستی از اشیاء [FontFallBackRule](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/FontFallBackRule) استفاده شود، زمانی که نیاز به مشخص کردن قوانین جایگزینی فونت برای چند بازه یونیکد باشد.

{{% alert color="primary" title="همچنین ببینید" %}} 
- [ایجاد مجموعه فونت‌های جایگزین](/slides/fa/nodejs-java/create-fallback-fonts-collection/)
{{% /alert %}}

## **پرسش‌های متداول**

**تفاوت فونت جایگزین، جایگزینی فونت و جاسازی فونت چیست؟**

یک فونت جایگزین فقط برای کاراکترهایی استفاده می‌شود که در فونت اصلی موجود نیستند. [جایگزینی فونت](/slides/fa/nodejs-java/font-substitution/) کل فونت مشخص شده را با فونت دیگری جایگزین می‌کند. [جاسازی فونت](/slides/fa/nodejs-java/embedded-font/) فونت‌ها را داخل فایل خروجی بسته‌بندی می‌کند تا دریافت‌کنندگان بتوانند متن را همان‌طور که منظور شده است ببینند.

**آیا فونت‌های جایگزین در هنگام خروجی مثل PDF، PNG یا SVG اعمال می‌شوند یا فقط در رندر روی صفحه نمایش؟**

بله. جایگزین کردن بر تمام [عملیات رندر و خروجی](/slides/fa/nodejs-java/convert-presentation/) که در آن کاراکترها باید رسم شوند اما در فونت منبع وجود ندارند، تأثیر می‌گذارد.

**آیا پیکربندی جایگزین باعث تغییر فایل ارائه می‌شود و آیا تنظیمات برای باز شدن‌های بعدی حفظ می‌شوند؟**

خیر. قوانین جایگزین تنظیمات رندر در زمان اجرا در کد شما هستند؛ آنها در داخل فایل .pptx ذخیره نمی‌شوند و در PowerPoint نمایش داده نمی‌شوند.

**آیا سیستم عامل (Windows/Linux/macOS) و مجموعهٔ پوشه‌های فونت بر انتخاب جایگزین تأثیر می‌گذارند؟**

بله. موتور فونت‌ها را از پوشه‌های موجود در سیستم و هر [مسیر اضافی](/slides/fa/nodejs-java/custom-font/) که شما ارائه می‌دهید، پیدا می‌کند. اگر یک فونت به صورت فیزیکی در دسترس نباشد، قانونی که به آن اشاره دارد نمی‌تواند اعمال شود.

**آیا جایگزین برای WordArt، SmartArt و نمودارها نیز کار می‌کند؟**

بله. وقتی این اشیاء شامل متن می‌شوند، همان مکانیزم جایگزینی گلیف برای رندر کاراکترهای گمشده اعمال می‌شود.