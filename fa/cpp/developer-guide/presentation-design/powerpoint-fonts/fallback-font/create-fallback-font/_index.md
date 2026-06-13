---
title: مشخص کردن فونت‌های جایگزین برای ارائه‌ها در C++
linktitle: فونت جایگزین
type: docs
weight: 10
url: /fa/cpp/create-fallback-font/
keywords:
- فونت جایگزین
- قانون جایگزینی
- اعمال فونت
- جایگزینی فونت
- بازه Unicode
- گلیف گمشده
- گلیف مناسب
- PowerPoint
- OpenDocument
- ارائه
- C++
- Aspose.Slides
description: "Aspose.Slides برای C++ را به‌کار ببرید تا فونت‌های جایگزین را در فایل‌های PPT، PPTX و ODP تنظیم کنید و نمایش یکسان متن را در هر دستگاه یا سیستم‌عامل تضمین کنید."
---
## **Overview**

Aspose.Slides به شما امکان می‌دهد فونت‌های جایگزین برای رندر و عملیات خروجی ارائه بدهید. فونت‌های جایگزین زمانی استفاده می‌شوند که فونت اصلی گلیف‌های کاراکترهای خاصی را نداشته باشد.

رفتار جایگزینی از طریق قوانین جایگزینی پیکربندی می‌شود. هر قانون یک بازه Unicode را به یک یا چند فونت که ممکن است گلیف‌های مورد نیاز را داشته باشند، مرتبط می‌کند. می‌توانید قوانین را برای بازه‌های کاراکتری مختلف تعریف کنید، فونت‌های جایگزین را به قوانین موجود اضافه یا حذف کنید، و چندین قانون را در یک مجموعه قوانین فونت جایگزین سازماندهی کنید.

قوانین جایگزینی تنظیمات رندر در زمان اجرا هستند. آن‌ها فایل ارائه را تغییر نمی‌دهند و در فایل PPTX ذخیره نمی‌شوند.

## **Fallback Rules**

Aspose.Slides از رابط کاربری [IFontFallBackRule](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ifontfallbackrule/) و کلاس [FontFallBackRule](https://reference.aspose.com/slides/fa/cpp/aspose.slides/fontfallbackrule/) برای تعیین قوانین اعمال فونت جایگزین پشتیبانی می‌کند. کلاس [FontFallBackRule](https://reference.aspose.com/slides/fa/cpp/aspose.slides/fontfallbackrule/) رابطه‌ای بین بازه Unicode مشخص‌شده، که برای جستجوی گلیف‌های گمشده استفاده می‌شود، و فهرستی از فونت‌هایی که ممکن است گلیف‌های مناسب را داشته باشند، نشان می‌دهد:

``` cpp
uint32_t startUnicodeIndex = 0x0B80;
uint32_t endUnicodeIndex = 0x0BFF;

auto firstRule = MakeObject<FontFallBackRule>(startUnicodeIndex, endUnicodeIndex, u"Vijaya");
auto secondRule = MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x3040), static_cast<uint32_t>(0x309F), u"MS Mincho, MS Gothic");

// با استفاده از روش‌های مختلف می‌توانید فهرست فونت‌ها را اضافه کنید:
auto fontNames = MakeArray<String>({ u"Segoe UI Emoji, Segoe UI Symbol", u"Arial" });

auto thirdRule = MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x1F300), static_cast<uint32_t>(0x1F64F), fontNames);
```

همچنین می‌توانید با استفاده از متد [Remove()](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ifontfallbackrule/remove/) فونت جایگزین را حذف کنید یا با متد [AddFallBackFonts()](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ifontfallbackrule/addfallbackfonts/) به شیء [FontFallBackRule](https://reference.aspose.com/slides/fa/cpp/aspose.slides/fontfallbackrule/) موجود اضافه کنید.

با استفاده از [FontFallBackRulesCollection](https://reference.aspose.com/slides/fa/cpp/aspose.slides/fontfallbackrulescollection/) می‌توانید فهرستی از اشیاء [FontFallBackRule](https://reference.aspose.com/slides/fa/cpp/aspose.slides/fontfallbackrule/) را سازماندهی کنید، زمانی که نیاز به تعیین قوانین جایگزینی فونت برای چندین بازه Unicode دارید.

{{% alert color="primary" title="See also" %}} 
- [ایجاد مجموعه فونت‌های جایگزین](/slides/fa/cpp/create-fallback-fonts-collection/)
{{% /alert %}}

## **FAQ**

**فرق بین فونت جایگزین، جایگزینی فونت و جاسازی فونت چیست؟**

فونت جایگزین تنها برای کاراکترهای گم‌شده در فونت اصلی استفاده می‌شود. [جایگزینی فونت](/slides/fa/cpp/font-substitution/) کل فونت مشخص‌شده را با فونت دیگری عوض می‌کند. [جاسازی فونت](/slides/fa/cpp/embedded-font/) فونت‌ها را داخل فایل خروجی بسته‌بندی می‌کند تا دریافت‌کنندگان متن را همان‌گونه که قصد شده است مشاهده کنند.

**آیا فونت‌های جایگزین فقط در رندر روی صفحه نمایش اعمال می‌شوند یا در خروجی‌هایی مانند PDF، PNG یا SVG نیز عمل می‌کنند؟**

بله. فونت جایگزین بر تمام [عملیات رندر و خروجی](/slides/fa/cpp/convert-presentation/) که در آن‌ها کاراکترها باید رسم شوند ولی در فونت منبع وجود ندارند، تأثیر می‌گذارد.

**آیا پیکربندی فونت جایگزین فایل ارائه را تغییر می‌دهد و آیا این تنظیم برای بازهای آینده حفظ می‌شود؟**

خیر. قوانین جایگزینی تنظیمات رندر زمان اجرا در کد شما هستند؛ آن‌ها داخل فایل .pptx ذخیره نمی‌شوند و در PowerPoint نشان داده نمی‌شوند.

**آیا سیستم‌عامل (Windows/Linux/macOS) و مجموعه مسیرهای فونت بر انتخاب فونت جایگزین تأثیر می‌گذارد؟**

بله. موتور فونت‌ها را از پوشه‌های سیستم موجود و هر [مسیر اضافی](/slides/fa/cpp/custom-font/) که شما فراهم می‌کنید، بازیابی می‌کند. اگر یک فونت به صورت فیزیکی موجود نباشد، قانونی که به آن ارجاع می‌دهد نمی‌تواند اعمال شود.

**آیا فونت جایگزین برای WordArt، SmartArt و نمودارها کار می‌کند؟**

بله. وقتی این اشیاء شامل متن شوند، همان مکانیزم جایگزینی گلیف برای رندر کاراکترهای گمشده اعمال می‌شود.