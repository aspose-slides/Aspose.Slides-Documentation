---
title: پیکربندی مجموعه‌های فونت بازگشتی در C++
linktitle: مجموعه فونت بازگشتی
type: docs
weight: 20
url: /fa/cpp/create-fallback-fonts-collection/
keywords:
- فونت بازگشتی
- قانون بازگشتی
- مجموعه فونت
- پیکربندی فونت
- راه‌اندازی فونت
- PowerPoint
- OpenDocument
- ارائه
- C++
- Aspose.Slides
description: "یک مجموعه فونت‌های بازگشتی را در Aspose.Slides برای C++ تنظیم کنید تا متن در ارائه‌های PowerPoint و OpenDocument یکنواخت و واضح باشد."
---
## **نمای کلی**

Aspose.Slides به شما امکان می‌دهد یک مجموعه از قواعد فونت بازگشتی برای یک ارائه پیکربندی کنید. هر قاعده بازگشتی توسط کلاس `FontFallBackRule` نمایش داده می‌شود و می‌تواند به `FontFallBackRulesCollection` اضافه شود که اینترفیس `IFontFallBackRulesCollection` را پیاده‌سازی می‌کند.

پس از ایجاد مجموعه، می‌توانید آن را با استفاده از متد `set_FontFallBackRulesCollection` از `FontsManager` ارائه اختصاص دهید. `FontsManager` فونت‌ها را در سراسر ارائه کنترل می‌کند و هر نمونه `Presentation` یک `FontsManager` مخصوص به خود دارد.

هنگامی که `FontsManager` با مجموعه فونت‌های بازگشتی مقداردهی اولیه شد، فونت‌های بازگشتی مشخص شده در هنگام رندر ارائه اعمال می‌شوند.

## **اعمال قواعد بازگشتی**

نمونه‌های کلاس [FontFallBackRule](https://reference.aspose.com/slides/fa/cpp/aspose.slides/fontfallbackrule/) می‌توانند در [FontFallBackRulesCollection](https://reference.aspose.com/slides/fa/cpp/aspose.slides/fontfallbackrulescollection/) که اینترفیس [IFontFallBackRulesCollection](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ifontfallbackrulescollection/) را پیاده‌سازی می‌کند، سازماندهی شوند. امکان افزودن یا حذف قواعد از این مجموعه وجود دارد.

سپس این مجموعه می‌تواند به متد [set_FontFallBackRulesCollection()](https://reference.aspose.com/slides/fa/cpp/aspose.slides/fontsmanager/set_fontfallbackrulescollection/) از کلاس [FontsManager](https://reference.aspose.com/slides/fa/cpp/aspose.slides/fontsmanager/) ارسال شود. FontsManager فونت‌ها را در سراسر ارائه کنترل می‌کند.

هر کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) متد [get_FontsManager()](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/get_fontsmanager/) خود را دارد که یک نمونه از کلاس FontsManager را برمی‌گرداند.

در اینجا یک مثال از نحوه ایجاد مجموعه قواعد فونت بازگشتی و اختصاص آن به FontsManager یک ارائه خاص آمده است:  

``` cpp
auto presentation = MakeObject<Presentation>();
auto userRulesList = MakeObject<FontFallBackRulesCollection>();

userRulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x0B80), static_cast<uint32_t>(0x0BFF), u"Vijaya"));
userRulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x3040), static_cast<uint32_t>(0x309F), u"MS Mincho, MS Gothic"));

presentation->get_FontsManager()->set_FontFallBackRulesCollection(userRulesList);
```

پس از مقداردهی اولیه FontsManager با مجموعه فونت‌های بازگشتی، فونت‌های بازگشتی در هنگام رندر ارائه اعمال می‌شوند.

{{% alert color="primary" %}} 
برای اطلاعات بیشتر نحوه [Render Presentation with Fallback Font](/slides/fa/cpp/render-presentation-with-fallback-font/) را مطالعه کنید.
{{% /alert %}}

## **سوالات متداول**

**آیا قواعد بازگشتی من داخل فایل PPTX جاسازی می‌شوند و پس از ذخیره در PowerPoint قابل مشاهده هستند؟**

خیر. قواعد بازگشتی تنظیمات زمان اجرا برای رندر هستند؛ آن‌ها به فایل PPTX سریال‌سازی نمی‌شوند و در رابط کاربری PowerPoint ظاهر نمی‌شوند.

**آیا بازگشت برای متنی درون SmartArt، WordArt، نمودارها و جدول‌ها اعمال می‌شود؟**

بله. همان مکانیزم جایگزینی گلیف برای هر متنی در این اشیاء استفاده می‌شود.

**آیا Aspose فونتی را به همراه کتابخانه توزیع می‌کند؟**

خیر. شما فونت‌ها را خودتان اضافه و استفاده می‌کنید و مسئولیت آن بر عهده شماست.

**آیا می‌توان جایگزینی/جایگزینی برای فونت‌های گم‌شده و بازگشت برای گلیف‌های گم‌شده را همزمان استفاده کرد؟**

بله. این‌ها مراحل مستقلی از همان مسیر حل فونت هستند: ابتدا موتور در دسترس بودن فونت را حل می‌کند ([replacement](/slides/fa/cpp/font-replacement/)/[substitution](/slides/fa/cpp/font-substitution/))، سپس بازگشت شکاف‌های گلیف‌های گم‌شده در فونت‌های موجود را پر می‌کند.