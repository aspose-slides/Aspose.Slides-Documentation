---
title: پیکربندی مجموعه‌های فونت جایگزین در C++
linktitle: مجموعه فونت جایگزین
type: docs
weight: 20
url: /fa/cpp/create-fallback-fonts-collection/
keywords:
- فونت جایگزین
- قانون جایگزین
- مجموعه فونت
- پیکربندی فونت
- راه‌اندازی فونت
- PowerPoint
- OpenDocument
- ارائه
- C++
- Aspose.Slides
description: "یک مجموعه فونت‌های جایگزین را در Aspose.Slides برای C++ تنظیم کنید تا متن در ارائه‌های PowerPoint و OpenDocument ثابت و واضح باقی بماند."
---
## **بررسی کلی**

Aspose.Slides به شما امکان می‌دهد مجموعه‌ای از قوانین فونت جایگزین برای یک ارائه پیکربندی کنید. هر قانون جایگزین توسط کلاس `FontFallBackRule` نمایان شده و می‌تواند به `FontFallBackRulesCollection` اضافه شود که رابط `IFontFallBackRulesCollection` را پیاده‌سازی می‌کند.

پس از ایجاد مجموعه، می‌توانید آن را با استفاده از متد `set_FontFallBackRulesCollection` از `FontsManager` ارائه اختصاص دهید. `FontsManager` فونت‌ها را در سراسر ارائه کنترل می‌کند و هر نمونهٔ `Presentation` دارای `FontsManager` خاص خود است.

زمانی که `FontsManager` با مجموعهٔ فونت‌های جایگزین مقداردهی اولیه شد، فونت‌های جایگزین مشخص‌شده در حین رندرینگ ارائه اعمال می‌شوند.

## **اعمال قوانین جایگزین**

نمونه‌های کلاس [FontFallBackRule](https://reference.aspose.com/slides/fa/cpp/aspose.slides/fontfallbackrule/) می‌توانند در [FontFallBackRulesCollection](https://reference.aspose.com/slides/fa/cpp/aspose.slides/fontfallbackrulescollection/) سازماندهی شوند که رابط [IFontFallBackRulesCollection](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ifontfallbackrulescollection/) را پیاده‌سازی می‌کند. امکان افزودن یا حذف قوانین از مجموعه وجود دارد.

سپس این مجموعه می‌تواند به متد [set_FontFallBackRulesCollection()](https://reference.aspose.com/slides/fa/cpp/aspose.slides/fontsmanager/set_fontfallbackrulescollection/) از کلاس [FontsManager](https://reference.aspose.com/slides/fa/cpp/aspose.slides/fontsmanager/) پاس داده شود. FontsManager فونت‌ها را در سراسر ارائه کنترل می‌کند.

هر [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) دارای متد [get_FontsManager()](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/get_fontsmanager/) است که نمونهٔ مخصوص خود از کلاس FontsManager را دارد.

در ادامه نمونه‌ای از چگونگی ایجاد مجموعهٔ قوانین فونت جایگزین و اختصاص آن به FontsManager یک ارائهٔ خاص آورده شده است:  

``` cpp
auto presentation = MakeObject<Presentation>();
auto userRulesList = MakeObject<FontFallBackRulesCollection>();

userRulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x0B80), static_cast<uint32_t>(0x0BFF), u"Vijaya"));
userRulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x3040), static_cast<uint32_t>(0x309F), u"MS Mincho, MS Gothic"));

presentation->get_FontsManager()->set_FontFallBackRulesCollection(userRulesList);
```

پس از مقداردهی اولیهٔ FontsManager با مجموعهٔ فونت‌های جایگزین، فونت‌های جایگزین در حین رندرینگ ارائه اعمال می‌شوند.

{{% alert color="primary" %}} 
برای اطلاعات بیشتر دربارهٔ نحوهٔ [Render Presentation with Fallback Font](/slides/fa/cpp/render-presentation-with-fallback-font/).
{{% /alert %}}

## **سوالات متداول**

**آیا قوانین جایگزین من در فایل PPTX جاسازی می‌شوند و پس از ذخیره در PowerPoint قابل مشاهده خواهند بود؟**

خیر. قوانین جایگزین تنظیمات رندرینگ در زمان اجرا هستند؛ آنها به صورت سریال‌شده به PPTX اضافه نمی‌شوند و در رابط کاربری PowerPoint نمایش داده نمی‌شوند.

**آیا جایگزین برای متنی داخل SmartArt، WordArt، نمودارها و جداول اعمال می‌شود؟**

بله. همان مکانیزم جایگزینی گلیف برای هر متنی در این اشیاء استفاده می‌شود.

**آیا Aspose فونتی همراه با کتابخانه توزیع می‌کند؟**

خیر. شما فونت‌ها را به صورت محلی اضافه و استفاده می‌کنید و مسئولیت آن بر عهدهٔ خود شماست.

**آیا می‌توان جایگزینی/جایگزینی برای فونت‌های گمشده و جایگزین برای گلیف‌های گمشده را همزمان استفاده کرد؟**

بله. این‌ها مراحل مستقلی از همان خط لولهٔ حل فونت هستند: ابتدا موتور در دسترس بودن فونت‌ها را ([replacement](/slides/fa/cpp/font-replacement/)/[substitution](/slides/fa/cpp/font-substitution/)) حل می‌کند، سپس جایگزین خالی‌ها را برای گلیف‌های گمشده در فونت‌های موجود پر می‌کند.