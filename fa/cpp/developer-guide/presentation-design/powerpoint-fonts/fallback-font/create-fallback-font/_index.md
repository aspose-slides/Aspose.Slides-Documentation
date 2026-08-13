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
- بازه یونیکد
- گلیف گم‌شده
- گلیف مناسب
- PowerPoint
- OpenDocument
- ارائه
- C++
- Aspose.Slides
description: "با Aspose.Slides برای C++، فونت‌های جایگزین را در فایل‌های PPT، PPTX و ODP تنظیم کنید تا نمایش متن به‌صورت یکسان در هر دستگاه یا سیستم‌عامل حفظ شود."
---
## **نمای کلی**

Aspose.Slides به شما امکان می‌دهد فونت‌های جایگزین را برای رندر و عملیات صادرات ارائه تعریف کنید. فونت‌های جایگزین زمانی استفاده می‌شوند که فونت اصلی شامل گلیف‌های کاراکترهای خاص نباشد.

رفتار جایگزین از طریق قوانین جایگزینی پیکربندی می‌شود. هر قانون یک بازه یونیکد را با یک یا چند فونت که ممکن است گلیف‌های مورد نیاز را داشته باشند، ارتباط می‌دهد. می‌توانید قوانین برای بازه‌های کاراکتری مختلف تعریف کنید، فونت‌های جایگزین را به قوانین موجود اضافه یا حذف کنید و چندین قانون را در یک مجموعه قوانین فونت جایگزین سازماندهی کنید.

قوانین جایگزین تنظیمات رندر در زمان اجرا هستند. آن‌ها فایل ارائه را تغییر نمی‌دهند و در داخل فایل PPTX ذخیره نمی‌شوند.

## **قوانین جایگزین**

Aspose.Slides از رابط [IFontFallBackRule](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ifontfallbackrule/) و کلاس [FontFallBackRule](https://reference.aspose.com/slides/fa/cpp/aspose.slides/fontfallbackrule/) برای تعیین قوانینی که فونت جایگزین را اعمال می‌کنند، پشتیبانی می‌کند. کلاس [FontFallBackRule](https://reference.aspose.com/slides/fa/cpp/aspose.slides/fontfallbackrule/) نمایانگر ارتباط بین بازه یونیکد مشخص شده، که برای جستجوی گلیف‌های مفقود استفاده می‌شود، و فهرستی از فونت‌ها که ممکن است گلیف‌های مناسب را داشته باشند:

``` cpp
#include <DOM/Fonts/FontFallBackRule.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;

uint32_t startUnicodeIndex = 0x0B80;
uint32_t endUnicodeIndex = 0x0BFF;

auto firstRule = MakeObject<FontFallBackRule>(startUnicodeIndex, endUnicodeIndex, u"Vijaya");
auto secondRule = MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x3040), static_cast<uint32_t>(0x309F), u"MS Mincho, MS Gothic");

// Using multiple ways you can add fonts list:
auto fontNames = MakeArray<String>({ u"Segoe UI Emoji, Segoe UI Symbol", u"Arial" });

auto thirdRule = MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x1F300), static_cast<uint32_t>(0x1F64F), fontNames);
```

همچنین امکان [Remove()](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ifontfallbackrule/remove/) فونت جایگزین یا [AddFallBackFonts()](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ifontfallbackrule/addfallbackfonts/) به شیء [FontFallBackRule](https://reference.aspose.com/slides/fa/cpp/aspose.slides/fontfallbackrule/) موجود وجود دارد.

[FontFallBackRulesCollection](https://reference.aspose.com/slides/fa/cpp/aspose.slides/fontfallbackrulescollection/) می‌تواند برای سازماندهی فهرستی از اشیاء [FontFallBackRule](https://reference.aspose.com/slides/fa/cpp/aspose.slides/fontfallbackrule/) استفاده شود، هنگامی که نیاز به تعیین قوانین جایگزینی فونت برای چندین بازه یونیکد باشد.

{{% alert color="info" title="See also" %}} 
- [Create Fallback Fonts Collection](/slides/fa/cpp/create-fallback-fonts-collection/)
{{% /alert %}}

## **سؤالات متداول**

### تفاوت بین فونت جایگزین، جایگزینی فونت و جاسازی فونت چیست؟

یک فونت جایگزین فقط برای کاراکترهایی که در فونت اصلی موجود نیستند استفاده می‌شود. [Font substitution](/slides/fa/cpp/font-substitution/) کل فونت مشخص شده را با فونت دیگری جایگزین می‌کند. [Font embedding](/slides/fa/cpp/embedded-font/) فونت‌ها را داخل فایل خروجی بسته‌بندی می‌کند تا دریافت‌کنندگان بتوانند متن را همان‌طور که منظور بوده نمایش دهند.

### آیا فونت‌های جایگزین در زمان صادرات مانند PDF، PNG یا SVG اعمال می‌شوند یا فقط در رندر روی صفحه نمایش؟

بله. جایگزین بر تمام [عملیات رندر و صادرات](/slides/fa/cpp/convert-presentation/) که کاراکترها باید رسم شوند اما در فونت منبع موجود نیستند، تأثیر می‌گذارد.

### آیا پیکربندی جایگزین فایل ارائه را تغییر می‌دهد و آیا این تنظیم برای باز کردن‌های آینده حفظ می‌شود؟

خیر. قوانین جایگزین تنظیمات رندر در زمان اجرا در کد شما هستند؛ آن‌ها داخل فایل .pptx ذخیره نمی‌شوند و در پاورپوینت نمایش داده نمی‌شوند.

### آیا سیستم عامل (Windows/Linux/macOS) و مجموعهٔ پوشه‌های فونت بر انتخاب جایگزین تأثیر می‌گذارد؟

بله. موتور فونت‌ها را از پوشه‌های سیستم موجود و هر [مسیر اضافی](/slides/fa/cpp/custom-font/) که شما ارائه می‌دهید، بازیابی می‌کند. اگر فونتی به صورت فیزیکی در دسترس نباشد، قانونی که به آن ارجاع می‌دهد نمی‌تواند اثر داشته باشد.

### آیا جایگزین برای WordArt، SmartArt و نمودارها کار می‌کند؟

بله. وقتی این اشیا شامل متن باشند، همان مکانیزم جایگزینی گلیف برای رندر کاراکترهای مفقود به کار می‌رود.