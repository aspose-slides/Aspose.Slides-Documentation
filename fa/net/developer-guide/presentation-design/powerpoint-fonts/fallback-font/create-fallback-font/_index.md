---
title: مشخص کردن فونت‌های جایگزین برای ارائه‌ها در .NET
linktitle: فونت جایگزین
type: docs
weight: 10
url: /fa/net/create-fallback-font/
keywords:
- فونت جایگزین
- قانون جایگزینی
- اعمال فونت
- جایگزینی فونت
- بازه یونیکد
- گلیف گمشده
- گلیف مناسب
- PowerPoint
- OpenDocument
- ارائه
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides برای .NET را به‌کار بگیرید تا فونت‌های جایگزین را در فایل‌های PPT، PPTX و ODP تنظیم کنید و نمایش ثابت متن را در هر دستگاه یا سیستم‌عاملی تضمین نمایید."
---
## **نمای کلی**

Aspose.Slides به شما امکان می‌دهد تا برای رندر و عملیات خروجی ارائه‌ها، فونت‌های جایگزین را تعیین کنید. فونت‌های جایگزین زمانی استفاده می‌شوند که فونت اصلی گلیف‌های مربوط به برخی کاراکترها را نداشته باشد.

رفتار جایگزین‌سازی از طریق قوانین fallback پیکربندی می‌شود. هر قانون یک بازه یونیکد را با یک یا چند فونت که ممکن است گلیف‌های مورد نیاز را داشته باشند، مرتبط می‌کند. می‌توانید قوانین را برای بازه‌های مختلف کاراکتر تعریف کنید، فونت‌های جایگزین را به قوانین موجود اضافه یا حذف کنید و چندین قانون را در مجموعه قوانین فونت جایگزین سازماندهی کنید.

قوانین fallback تنظیمات رندر در زمان اجرا هستند. آن‌ها فایل ارائه را تغییر نمی‌دهند و در داخل فایل PPTX ذخیره نمی‌شوند.

## **قواعد جایگزین**

Aspose.Slides از رابط [IFontFallBackRule](https://reference.aspose.com/slides/fa/net/aspose.slides/iFontFallBackRule) و کلاس [FontFallBackRule](https://reference.aspose.com/slides/fa/net/aspose.slides/FontFallBackRule) برای تعیین قواعد اعمال فونت جایگزین پشتیبانی می‌کند. کلاس [FontFallBackRule](https://reference.aspose.com/slides/fa/net/aspose.slides/FontFallBackRule) یک ارتباط بین بازه یونیکد مشخص‌شده، که برای جستجوی گلیف‌های گمشده استفاده می‌شود، و فهرستی از فونت‌ها که ممکن است گلیف‌های مناسب را داشته باشند، نمایش می‌دهد:

```c#
using Aspose.Slides;

uint startUnicodeIndex = 0x0B80;
uint endUnicodeIndex = 0x0BFF;

IFontFallBackRule firstRule = new FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
IFontFallBackRule secondRule = new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic");

//با استفاده از چندین روش می‌توانید لیست فونت‌ها را اضافه کنید:
string[] fontNames = new string[] { "Segoe UI Emoji, Segeu UI Symbol", "Arial" };

IFontFallBackRule thirdRule = new FontFallBackRule(0x1F300, 0x1F64F, fontNames);
```

همچنین می‌توان با متدهای [Remove()](https://reference.aspose.com/slides/fa/net/aspose.slides/ifontfallbackrule/methods/remove) فونت جایگزین را حذف یا با متد [AddFallBackFonts()](https://reference.aspose.com/slides/fa/net/aspose.slides/fontfallbackrule/methods/addfallbackfonts) به شیء موجود [FontFallBackRule](https://reference.aspose.com/slides/fa/net/aspose.slides/FontFallBackRule) فونت‌های جایگزین اضافه کرد.

[FontFallBackRulesCollection](https://reference.aspose.com/slides/fa/net/aspose.slides/fontfallbackrulescollection)[ ](https://reference.aspose.com/slides/fa/net/aspose.slides/fontfallbackrulescollection)می‌تواند برای سازماندهی فهرستی از اشیای [FontFallBackRule](https://reference.aspose.com/slides/fa/net/aspose.slides/FontFallBackRule) استفاده شود، هنگامی که نیاز به تعیین قواعد جایگزینی فونت برای بازه‌های یونیکد متعدد باشد.

{{% alert color="info" title="همچنین" %}} 
- [ایجاد مجموعه فونت‌های پیش‌فرض](/slides/fa/net/create-fallback-fonts-collection/)
{{% /alert %}}

## **سؤالات متداول**

### تفاوت بین فونت جایگزین، جایگزینی فونت و تعبیه فونت چیست؟

یک فونت جایگزین فقط برای کاراکترهایی که در فونت اصلی موجود نیستند استفاده می‌شود. [جایگزینی فونت](/slides/fa/net/font-substitution/) کل فونت مشخص‌شده را با فونت دیگری جایگزین می‌کند. [تعبیه فونت](/slides/fa/net/embedded-font/) فونت‌ها را داخل فایل خروجی بسته‌بندی می‌کند تا دریافت‌کنندگان بتوانند متن را همان‌گونه که منظور شده نمایش دهند.

### آیا فونت‌های جایگزین فقط در رندر روی صفحه نمایش اعمال می‌شوند یا در عملیات خروجی مانند PDF، PNG یا SVG نیز؟

بله. جایگزین‌سازی بر روی تمام [عملیات رندر و خروجی](/slides/fa/net/convert-presentation/) که نیاز به رسم کاراکترها دارند ولی در فونت منبع موجود نیستند، تأثیر می‌گذارد.

### آیا پیکربندی فونت جایگزین فایل ارائه را تغییر می‌دهد و این تنظیم برای باز کردن‌های آینده حفظ می‌شود؟

خیر. قوانین fallback تنظیمات رندر در زمان اجرا در کد شما هستند؛ آن‌ها داخل فایل .pptx ذخیره نمی‌شوند و در پاورپوینت نمایش داده نمی‌شوند.

### آیا سیستم‌عامل (Windows/Linux/macOS) و مجموعه پوشه‌های فونت بر انتخاب جایگزین تأثیر می‌گذارند؟

بله. موتور فونت‌ها را از پوشه‌های سیستم موجود و هر [مسیر اضافی](/slides/fa/net/custom-font/) که شما فراهم می‌کنید، استخراج می‌کند. اگر فونتی به صورت فیزیکی در دسترس نباشد، قانونی که به آن ارجاع می‌دهد نمی‌تواند اجرا شود.

### آیا جایگزین‌سازی برای WordArt، SmartArt و نمودارها نیز کار می‌کند؟

بله. هنگامی که این اشیا شامل متن باشند، همان‌ مکانیزم جایگزینی گلیف برای رندر کاراکترهای گمشده اعمال می‌شود.