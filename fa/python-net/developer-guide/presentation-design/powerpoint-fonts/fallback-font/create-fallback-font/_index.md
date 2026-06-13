---
title: مشخص‌کردن قلم‌های جایگزین برای ارائه‌ها در پایتون
linktitle: قلم جایگزین
type: docs
weight: 10
url: /fa/python-net/create-fallback-font/
keywords:
- قلم جایگزین
- قانون جایگزینی
- اعمال قلم
- جایگزینی قلم
- بازه یونیکد
- گلیف مفقود
- گلیف مناسب
- PowerPoint
- OpenDocument
- ارائه
- Python
- Aspose.Slides
description: "Aspose.Slides برای پایتون را از طریق .NET به‌کار ببرید تا قلم‌های جایگزین را در فایل‌های PPT، PPTX و ODP تنظیم کنید و نمایش متن یکسان را بر روی هر دستگاه یا سیستم‌عامل تضمین کنید."
---
## **نمای کلی**

Aspose.Slides به شما امکان می‌دهد قلم‌های جایگزین (fallback) را برای رندر و عملیات صادرات ارائه تعیین کنید. قلم‌های جایگزین زمانی استفاده می‌شوند که قلم اصلی گلیف‌های مربوط به برخی کاراکترها را نداشته باشد.

رفتار جایگزین از طریق قوانین fallback تنظیم می‌شود. هر قانون یک بازه یونیکد را با یک یا چند قلم که ممکن است گلیف‌های مورد نیاز را داشته باشند، ارتباط می‌دهد. می‌توانید قوانین را برای بازه‌های مختلف کاراکتر تعریف کنید، قلم‌های جایگزین را به قوانین موجود اضافه یا حذف کنید و چندین قانون را در یک مجموعه قوانین قلم‌های جایگزین سازماندهی کنید.

قوانین جایگزین تنظیمات رندر زمان اجرا هستند. آن‌ها فایل ارائه را تغییر نمی‌دهند و در داخل فایل PPTX ذخیره نمی‌شوند.

## **مشخص‌کردن قلم‌های جایگزین**

Aspose.Slides از کلاس [FontFallBackRule](https://reference.aspose.com/slides/fa/python-net/aspose.slides/FontFallBackRule/) برای مشخص کردن قواعد اعمال یک قلم جایگزین پشتیبانی می‌کند. کلاس [FontFallBackRule](https://reference.aspose.com/slides/fa/python-net/aspose.slides/FontFallBackRule/) یک ارتباط بین بازه یونیکد مشخص شده، که برای جستجوی گلیف‌های مفقود استفاده می‌شود، و فهرستی از قلم‌ها که ممکن است گلیف‌های مناسب را داشته باشند، نمایان می‌کند:

```py
startUnicodeIndex = 0x0B80
endUnicodeIndex = 0x0BFF

firstRule = slides.FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya")
secondRule = slides.FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic")

#با استفاده از روش‌های مختلف می‌توانید لیست قلم‌ها را اضافه کنید:
fontNames =  ["Segoe UI Emoji, Segoe UI Symbol", "Arial" ]

thirdRule = slides.FontFallBackRule(0x1F300, 0x1F64F, fontNames)
```

همچنین می‌توانید قلم جایگزین را [remove](https://reference.aspose.com/slides/fa/python-net/aspose.slides/fontfallbackrule/remove/) کنید یا [add_fall_back_fonts](https://reference.aspose.com/slides/fa/python-net/aspose.slides/fontfallbackrule/add_fall_back_fonts/) را به شیء [FontFallBackRule](https://reference.aspose.com/slides/fa/python-net/aspose.slides/FontFallBackRule/) موجود اضافه کنید.

[FontFallBackRulesCollection](https://reference.aspose.com/slides/fa/python-net/aspose.slides/fontfallbackrulescollection/) می‌تواند برای سازماندهی فهرستی از اشیاء [FontFallBackRule](https://reference.aspose.com/slides/fa/python-net/aspose.slides/FontFallBackRule/) استفاده شود، زمانی که نیاز به تعیین قوانین جایگزینی قلم‌های fallback برای چندین بازه یونیکد باشد.

{{% alert color="primary" title="همچنین" %}} 
- [ایجاد مجموعه قلم‌های جایگزین](/slides/fa/python-net/create-fallback-fonts-collection/)
{{% /alert %}}

## **سوالات متداول**

**تفاوت قلم fallback، جایگزینی قلم و جاسازی قلم چه چیزی است؟**

یک قلم fallback فقط برای کاراکترهایی که در قلم اصلی موجود نیستند استفاده می‌شود. [Font substitution](/slides/fa/python-net/font-substitution/) کل قلم مشخص‌شده را با قلم دیگری جایگزین می‌کند. [Font embedding](/slides/fa/python-net/embedded-font/) قلم‌ها را داخل فایل خروجی بسته‌بندی می‌کند تا دریافت‌کنندگان بتوانند متن را همان‌گونه که منظور شده نمایش دهند.

**آیا قلم‌های fallback هنگام صادرات به فرمت‌های PDF، PNG یا SVG اعمال می‌شوند یا فقط در رندر روی صفحه نمایش؟**

بله. قلم‌های fallback بر تمام [رندر و عملیات صادرات](/slides/fa/python-net/convert-presentation/) که در آن کاراکترها باید رسم شوند اما در قلم منبع موجود نیستند، تأثیر می‌گذارند.

**آیا پیکربندی fallback فایل ارائه را تغییر می‌دهد و آیا این تنظیم برای باز کردن‌های آینده حفظ می‌شود؟**

خیر. قوانین fallback تنظیمات رندر زمان اجرا در کد شما هستند؛ آن‌ها داخل فایل .pptx ذخیره نمی‌شوند و در PowerPoint نمایش داده نمی‌شوند.

**آیا سیستم‌عامل (Windows/Linux/macOS) و مجموعه پوشه‌های قلم بر انتخاب fallback تأثیر می‌گذارد؟**

بله. موتور قلم‌ها را از پوشه‌های سیستم موجود و هر [مسیر اضافی](/slides/fa/python-net/custom-font/) که شما ارائه می‌دهید، بازیابی می‌کند. اگر قلم به‌صورت فیزیکی موجود نباشد، قانونی که به آن اشاره می‌کند اثر نخواهد داشت.

**آیا fallback برای WordArt، SmartArt و نمودارها کار می‌کند؟**

بله. هنگامی که این اشیاء حاوی متن هستند، همان مکانیزم جایگزینی گلیف برای رندر کاراکترهای گمشده اعمال می‌شود.