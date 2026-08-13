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
description: "یک مجموعه فونت جایگزین را در Aspose.Slides برای C++ تنظیم کنید تا متن در ارائه‌های PowerPoint و OpenDocument یکنواخت و واضح باشد."
---
## **مرور کلی**

Aspose.Slides به شما امکان پیکربندی مجموعه‌ای از قوانین فونت جایگزین برای یک ارائه را می‌دهد. هر قانون جایگزین توسط کلاس `FontFallBackRule` نمایندگی می‌شود و می‌تواند به `FontFallBackRulesCollection` اضافه شود، که اینترفیس `IFontFallBackRulesCollection` را پیاده‌سازی می‌کند.

پس از ایجاد مجموعه، می‌توانید با استفاده از متد `set_FontFallBackRulesCollection` از `FontsManager` ارائه، آن را اختصاص دهید. `FontsManager` فونت‌ها را در سراسر ارائه کنترل می‌کند و هر نمونه `Presentation` دارای `FontsManager` خود است.

به‌عنوان‌یک‌بار `FontsManager` با مجموعه فونت‌های جایگزین مقداردهی اولیه شد، فونت‌های جایگزین مشخص شده در هنگام رندر ارائه اعمال می‌شوند.

## **اعمال قوانین جایگزین**

نمونه‌های کلاس [FontFallBackRule](https://reference.aspose.com/slides/fa/cpp/aspose.slides/fontfallbackrule/) می‌توانند در [FontFallBackRulesCollection](https://reference.aspose.com/slides/fa/cpp/aspose.slides/fontfallbackrulescollection/) سازماندهی شوند، که اینترفیس [IFontFallBackRulesCollection](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ifontfallbackrulescollection/) را پیاده‌سازی می‌کند. امکان افزودن یا حذف قوانین از مجموعه وجود دارد.

سپس این مجموعه می‌تواند به متد [set_FontFallBackRulesCollection()](https://reference.aspose.com/slides/fa/cpp/aspose.slides/fontsmanager/set_fontfallbackrulescollection/) از کلاس [FontsManager](https://reference.aspose.com/slides/fa/cpp/aspose.slides/fontsmanager/) ارسال شود. FontsManager فونت‌ها را در سراسر ارائه کنترل می‌کند.

هر [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) دارای متد [get_FontsManager()](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/get_fontsmanager/) است که نمونهٔ خود را از کلاس FontsManager دارد.

در زیر نمونه‌ای از چگونگی ایجاد مجموعه قوانین فونت جایگزین و اختصاص آن به FontsManager یک ارائه خاص آورده شده است:

``` cpp
#include <DOM/Fonts/FontFallBackRule.h>
#include <DOM/Fonts/FontFallBackRulesCollection.h>
#include <DOM/IFontFallBackRule.h>
#include <DOM/IFontsManager.h>
#include <DOM/Presentation.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto userRulesList = MakeObject<FontFallBackRulesCollection>();

userRulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x0B80), static_cast<uint32_t>(0x0BFF), u"Vijaya"));
userRulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x3040), static_cast<uint32_t>(0x309F), u"MS Mincho, MS Gothic"));

presentation->get_FontsManager()->set_FontFallBackRulesCollection(userRulesList);
```

پس از اینکه FontsManager با مجموعه فونت‌های جایگزین مقداردهی اولیه شد، فونت‌های جایگزین در هنگام رندر ارائه اعمال می‌شوند.

{{% alert color="info" %}} 
بیشتر بخوانید دربارهٔ [رندر ارائه با فونت جایگزین](/slides/fa/cpp/render-presentation-with-fallback-font/). 
{{% /alert %}}

## **سوالات متداول**

### آیا قوانین جایگزینی من در فایل PPTX تعبیه می‌شوند و پس از ذخیره در PowerPoint قابل مشاهده خواهند بود؟

خیر. قوانین جایگزینی تنظیمات زمان اجرا برای رندر هستند؛ آنها به‌صورت سریالایز در فایل PPTX ذخیره نمی‌شوند و در رابط کاربری PowerPoint نمایش داده نمی‌شوند.

### آیا جایگزینی بر متن داخل SmartArt، WordArt، نمودارها و جداول اعمال می‌شود؟

بله. همان مکانیزم جایگزینی گلیف برای هر متنی در این اشیاء استفاده می‌شود.

### آیا Aspose فونتی را به همراه کتابخانه توزیع می‌کند؟

خیر. شما فونت‌ها را خودتان اضافه و استفاده می‌کنید و مسئولیت آن بر عهدهٔ شماست.

### آیا می‌توان جایگزینی/جایگزینی برای فونت‌های گم‌شده و جایگزینی برای گلیف‌های گم‌شده را همزمان استفاده کرد؟

بله. آنها مراحل مستقلی از همان خط لولهٔ حل فونت هستند: ابتدا موتور در دسترس بودن فونت را حل می‌کند ([replacement](/slides/fa/cpp/font-replacement/)/[substitution](/slides/fa/cpp/font-substitution/))، سپس جایگزینی خلاهای گلیف‌های گم‌شده در فونت‌های موجود را پر می‌کند.