---
title: مشخص کردن فونت‌های جایگزین برای ارائه‌ها در .NET
linktitle: فونت جایگزین
type: docs
weight: 10
url: /fa/net/create-fallback-font/
keywords:
- فونت جایگزین
- قانون جایگزین
- اعمال فونت
- جایگزینی فونت
- بازه یونیکد
- گلیف گمشده
- گلیف صحیح
- PowerPoint
- OpenDocument
- ارائه
- .NET
- C#
- Aspose.Slides
description: "به کارگیری کامل Aspose.Slides برای .NET جهت تنظیم فونت‌های جایگزین در پرونده‌های PPT، PPTX و ODP، برای اطمینان از نمایش یکسان متن در هر دستگاه یا سیستم‌عامل."
---
## **بررسی اجمالی**

Aspose.Slides به شما امکان می‌دهد فونت‌های جایگزین را برای رندر و عملیات خروجی ارائه مشخص کنید. فونت‌های جایگزین زمانی استفاده می‌شوند که فونت اصلی گلیف‌های مربوط به کاراکترهای خاصی را نداشته باشد.

رفتار جایگزین‌فونت از طریق قواعد جایگزین‌فونت پیکربندی می‌شود. هر قاعده یک بازه یونیکد را با یک یا چند فونت که ممکن است گلیف‌های مورد نیاز را داشته باشند، مرتبط می‌کند. می‌توانید قواعد را برای بازه‌های کاراکتر مختلف تعریف کنید، فونت‌های جایگزین را به قواعد موجود اضافه یا حذف کنید، و چندین قاعده را در یک مجموعه قواعد فونت جایگزین سازماندهی کنید.

قواعد جایگزین‌فونت تنظیمات رندر در زمان اجرا هستند. آن‌ها فایل ارائه را تغییر نمی‌دهند و در داخل فایل PPTX ذخیره نمی‌شوند.

## **قواعد فونت جایگزین**

Aspose.Slides از رابط کاربری [IFontFallBackRule](https://reference.aspose.com/slides/fa/net/aspose.slides/iFontFallBackRule) و کلاس [FontFallBackRule](https://reference.aspose.com/slides/fa/net/aspose.slides/FontFallBackRule) برای مشخص کردن قواعد اعمال فونت جایگزین پشتیبانی می‌کند. کلاس [FontFallBackRule](https://reference.aspose.com/slides/fa/net/aspose.slides/FontFallBackRule) نمایانگر ارتباط بین بازه یونیکد مشخص‌شده، که برای جستجوی گلیف‌های گمشده استفاده می‌شود، و فهرستی از فونت‌هایی است که ممکن است گلیف‌های مناسب را داشته باشند:

```c#
uint startUnicodeIndex = 0x0B80;
uint endUnicodeIndex = 0x0BFF;

IFontFallBackRule firstRule = new FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
IFontFallBackRule secondRule = new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic");

//با استفاده از روش‌های مختلف می‌توانید فهرست فونت‌ها را اضافه کنید:
string[] fontNames = new string[] { "Segoe UI Emoji, Segoe UI Symbol", "Arial" };

IFontFallBackRule thirdRule = new FontFallBackRule(0x1F300, 0x1F64F, fontNames);
```

همچنین می‌توانید فونت جایگزین را با استفاده از [Remove()](https://reference.aspose.com/slides/fa/net/aspose.slides/ifontfallbackrule/methods/remove) حذف کنید یا با استفاده از [AddFallBackFonts()](https://reference.aspose.com/slides/fa/net/aspose.slides/fontfallbackrule/methods/addfallbackfonts) به شیء [FontFallBackRule](https://reference.aspose.com/slides/fa/net/aspose.slides/FontFallBackRule) موجود اضافه کنید.

[FontFallBackRulesCollection](https://reference.aspose.com/slides/fa/net/aspose.slides/fontfallbackrulescollection)[ ](https://reference.aspose.com/slides/fa/net/aspose.slides/fontfallbackrulescollection)می‌توان از این مجموعه برای سازماندهی فهرستی از شیءهای [FontFallBackRule](https://reference.aspose.com/slides/fa/net/aspose.slides/FontFallBackRule) استفاده کرد، زمانی که نیاز به مشخص کردن قواعد جایگزینی فونت برای چندین بازه یونیکد باشد.

{{% alert color="primary" title="See also" %}} 
- [ایجاد مجموعه فونت‌های جایگزین](/slides/fa/net/create-fallback-fonts-collection/)
{{% /alert %}}

## **پرسش‌های متداول**

**تفاوت بین فونت جایگزین، جایگزینی فونت و جاسازی فونت چیست؟**

یک فونت جایگزین فقط برای کاراکترهایی که در فونت اصلی موجود نیستند استفاده می‌شود. [جایگزینی فونت](/slides/fa/net/font-substitution/) کل فونت مشخص‌شده را با فونت دیگری جایگزین می‌کند. [جاسازی فونت](/slides/fa/net/embedded-font/) فونت‌ها را داخل فایل خروجی بسته‌بندی می‌کند تا دریافت‌کنندگان بتوانند متن را همان‌طور که منظور شده مشاهده کنند.

**آیا فونت‌های جایگزین در زمان خروجی‌گیری مانند PDF، PNG یا SVG اعمال می‌شوند یا فقط در رندر روی صفحه؟**

بله. فونت‌های جایگزین بر تمام [عملیات رندر و خروجی](/slides/fa/net/convert-presentation/) که در آن کاراکترها باید رسم شوند اما در فونت منبع وجود ندارند، تأثیر می‌گذارند.

**آیا پیکربندی فونت جایگزین فایل ارائه را تغییر می‌دهد و تنظیمات برای بازگشت‌های بعدی حفظ می‌شوند؟**

خیر. قواعد جایگزین‌فونت تنظیمات رندر در زمان اجرا در کد شما هستند؛ آن‌ها در داخل فایل .pptx ذخیره نمی‌شوند و در پاورپوینت نمایش داده نمی‌شوند.

**آیا سیستم‌عامل (Windows/Linux/macOS) و مجموعه پوشه‌های فونت بر انتخاب فونت جایگزین تأثیر می‌گذارند؟**

بله. موتور فونت‌ها را از پوشه‌های سیستم موجود و هر [مسیرهای اضافی](/slides/fa/net/custom-font/) که شما ارائه می‌دهید، پیدا می‌کند. اگر فونتی به صورت فیزیکی موجود نباشد، قانون ارجاع‌دهنده به آن قابل اجرا نخواهد بود.

**آیا جایگزین‌فونت برای WordArt، SmartArt و نمودارها کار می‌کند؟**

بله. هنگامی که این اشیاء شامل متن باشند، همان مکانیزم جایگزینی گلیف برای رندر کاراکترهای گمشده به کار گرفته می‌شود.