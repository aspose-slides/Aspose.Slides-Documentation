---
title: مشخص کردن فونت‌های بازگشتی برای ارائه‌ها در C++
linktitle: فونت بازگشتی
type: docs
weight: 10
url: /fa/cpp/create-fallback-font/
keywords:
- فونت بازگشتی
- قاعده بازگشتی
- اعمال فونت
- جایگزینی فونت
- بازه یونیکد
- گلیف‌های گمشده
- گلیف‌های صحیح
- PowerPoint
- OpenDocument
- ارائه
- C++
- Aspose.Slides
description: "Aspose.Slides برای C++ را به‌کار بگیرید تا فونت‌های بازگشتی را در فایل‌های PPT، PPTX و ODP تنظیم کنید و نمایش متنی ثابت را در هر دستگاه یا سیستم‌عامل تضمین کنید."
---
## **نمای کلی**

Aspose.Slides به شما امکان می‌دهد که فونت‌های بازگشتی را برای رندرینگ و عملیات خروجی ارائه مشخص کنید. فونت‌های بازگشتی زمانی استفاده می‌شوند که فونت اصلی حاوی گلیف‌های مورد نیاز برای کاراکترهای خاص نباشد.

رفتار بازگشت از طریق قواعد بازگشتی پیکربندی می‌شود. هر قاعده یک بازه یونیکد را با یک یا چند فونت که ممکن است گلیف‌های مورد نیاز را داشته باشند، مرتبط می‌کند. می‌توانید قواعدی برای بازه‌های کاراکتری مختلف تعریف کنید، فونت‌های بازگشتی را به قواعد موجود اضافه یا حذف کنید، و چندین قاعده را در یک مجموعه قواعد فونت بازگشتی سازماندهی کنید.

قواعد بازگشت تنظیمات رندرینگ زمان اجرا هستند. آن‌ها فایل ارائه را به‌طور مستقیم تغییر نمی‌دهند و در داخل فایل PPTX ذخیره نمی‌شوند.

## **قواعد فونت بازگشتی**

Aspose.Slides از اینترفیس [IFontFallBackRule](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ifontfallbackrule/) و کلاس [FontFallBackRule](https://reference.aspose.com/slides/fa/cpp/aspose.slides/fontfallbackrule/) برای مشخص کردن قواعد اعمال فونت بازگشتی پشتیبانی می‌کند. کلاس [FontFallBackRule](https://reference.aspose.com/slides/fa/cpp/aspose.slides/fontfallbackrule/) یک ارتباط بین بازه یونیکد مشخص‌شده، که برای جستجوی گلیف‌های گم‌شده استفاده می‌شود، و فهرستی از فونت‌ها که ممکن است گلیف‌های مناسب را داشته باشند، نشان می‌دهد:

``` cpp
uint32_t startUnicodeIndex = 0x0B80;
uint32_t endUnicodeIndex = 0x0BFF;

auto firstRule = MakeObject<FontFallBackRule>(startUnicodeIndex, endUnicodeIndex, u"Vijaya");
auto secondRule = MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x3040), static_cast<uint32_t>(0x309F), u"MS Mincho, MS Gothic");

// با استفاده از روش‌های مختلف می‌توانید فهرست فونت‌ها را اضافه کنید:

auto fontNames = MakeArray<String>({ u"Segoe UI Emoji, Segoe UI Symbol", u"Arial" });

auto thirdRule = MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x1F300), static_cast<uint32_t>(0x1F64F), fontNames);
```

همچنین می‌توانید فونت بازگشتی را با استفاده از [Remove()](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ifontfallbackrule/remove/) حذف کنید یا با [AddFallBackFonts()](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ifontfallbackrule/addfallbackfonts/) به شیء [FontFallBackRule](https://reference.aspose.com/slides/fa/cpp/aspose.slides/fontfallbackrule/) موجود اضافه کنید.

از [FontFallBackRulesCollection](https://reference.aspose.com/slides/fa/cpp/aspose.slides/fontfallbackrulescollection/) می‌توان برای سازماندهی فهرستی از اشیاء [FontFallBackRule](https://reference.aspose.com/slides/fa/cpp/aspose.slides/fontfallbackrule/) استفاده کرد، زمانی که نیاز به تعیین قواعد جایگزینی فونت بازگشتی برای چندین بازه یونیکد باشد.

{{% alert color="primary" title="همچنین ببینید" %}} 
- [ایجاد مجموعه فونت‌های بازگشتی](/slides/fa/cpp/create-fallback-fonts-collection/)
{{% /alert %}}

## **سوالات متداول**

**تفاوت بین فونت بازگشتی، جایگزینی فونت، و تعبیهٔ فونت چیست؟**

یک فونت بازگشتی فقط برای کاراکترهایی که در فونت اصلی موجود نیستند استفاده می‌شود. [جایگزینی فونت](/slides/fa/cpp/font-substitution/) کل فونت مشخص‌شده را با فونت دیگری جایگزین می‌کند. [تعبیهٔ فونت](/slides/fa/cpp/embedded-font/) فونت‌ها را داخل فایل خروجی بسته‌بندی می‌کند تا گیرندگان بتوانند متن را همان‌طور که منظور شده است ببینند.

**آیا فونت‌های بازگشتی در زمان خروجی‌گیری مانند PDF، PNG یا SVG اعمال می‌شوند یا فقط در رندرینگ روی‌صفحه؟**

بله. فونت‌های بازگشتی بر تمام [عملیات رندرینگ و خروجی](/slides/fa/cpp/convert-presentation/) که در آن کاراکترها باید رسم شوند اما در فونت منبع موجود نیستند، تأثیر می‌گذارند.

**آیا پیکربندی فونت بازگشتی فایل ارائه را تغییر می‌دهد و آیا این تنظیم برای باز کردن‌های آینده حفظ می‌شود؟**

خیر. قواعد بازگشت تنظیمات رندرینگ زمان اجرا در کد شما هستند؛ آن‌ها داخل فایل .pptx ذخیره نمی‌شوند و در PowerPoint نمایش داده نمی‌شوند.

**آیا سیستم‌عامل (Windows/Linux/macOS) و مجموعهٔ مسیرهای فونت بر انتخاب بازگشت تأثیر می‌گذارد؟**

بله. موتور فونت‌ها را از پوشه‌های موجود در سیستم و هر [مسیر اضافی](/slides/fa/cpp/custom-font/) که شما فراهم می‌کنید، بازیابی می‌کند. اگر یک فونت به‌صورت فیزیکی در دسترس نباشد، قاعده‌ای که به آن ارجاع می‌دهد قابل اجرا نخواهد بود.

**آیا بازگشت برای WordArt، SmartArt و نمودارها کار می‌کند؟**

بله. هنگامیکه این اشیاء متن دارند، همان‌ مکانیزم جایگزینی گلیف برای رندر کردن کاراکترهای گم‌شده اعمال می‌شود.