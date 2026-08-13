---
title: رندر ارائه‌ها با فونت‌های جایگزین در C++
linktitle: رندر ارائه‌ها
type: docs
weight: 30
url: /fa/cpp/render-presentation-with-fallback-font/
keywords:
- فونت جایگزین
- رندر PowerPoint
- رندر ارائه
- رندر اسلاید
- PowerPoint
- OpenDocument
- ارائه
- C++
- Aspose.Slides
description: "رندر ارائه‌ها با فونت‌های جایگزین در Aspose.Slides برای C++ – حفظ سازگاری متن در میان PPT، PPTX و ODP با نمونه‌های کد C++ گام‌به‌گام."
---
## **بررسی کلی**

Aspose.Slides به شما امکان رندر ارائه‌ها را با استفاده از قوانین فونت جایگزین می‌دهد. این مقاله نشان می‌دهد چگونه یک مجموعه قوانین فونت جایگزین ایجاد کنید، قوانین آن را با حذف یا افزودن فونت‌های جایگزین تغییر دهید، و مجموعه را با استفاده از متد `FontsManager::set_FontFallBackRulesCollection` اختصاص دهید.

پس از انتساب مجموعه قوانین فونت جایگزین به `FontsManager` ارائه، قوانین در طی عملیات‌هایی مانند ذخیره‌سازی، رندر و تبدیل ارائه اعمال می‌شوند. این مثال نشان می‌دهد چگونه از قوانین پیکربندی‌شده هنگام رندر تصویر بندانگشتی اسلاید و ذخیره آن به‌صورت تصویر PNG استفاده کنید.

## **رندر اسلاید با استفاده از قوانین فونت جایگزین**

مثال زیر شامل این مراحل است:

1. ما [مجموعه قوانین فونت جایگزین](/slides/fa/cpp/create-fallback-fonts-collection/) را ایجاد می‌کنیم.
2. [Remove()](https://reference.aspose.com/slides/fa/cpp/aspose.slides/fontfallbackrule/remove/) یک قانون فونت جایگزین را حذف کنید و [AddFallBackFonts()](https://reference.aspose.com/slides/fa/cpp/aspose.slides/fontfallbackrule/addfallbackfonts/) را به قانون دیگری اضافه کنید.
3. مجموعه قوانین را به متد [FontsManager::set_FontFallBackRulesCollection()](https://reference.aspose.com/slides/fa/cpp/aspose.slides/fontsmanager/set_fontfallbackrulescollection/) بدهید.
4. با متد [Presentation::Save()](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/save/) می‌توانیم ارائه را در همان قالب ذخیره کنیم، یا در قالب دیگری ذخیره کنیم. پس از تنظیم مجموعه قوانین فونت جایگزین در FontsManager، این قوانین در طول هر عملیات روی ارائه اعمال می‌شوند: ذخیره، رندر، تبدیل و غیره.

```cpp
#include <DOM/Fonts/FontFallBackRule.h>
#include <DOM/Fonts/FontFallBackRulesCollection.h>
#include <DOM/IFontsManager.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

// ایجاد یک نمونه جدید از مجموعه قوانین
auto rulesList = MakeObject<FontFallBackRulesCollection>();

// ایجاد تعداد مشخصی از قوانین
rulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x400), static_cast<uint32_t>(0x4FF), u"Times New Roman"));
//rulesList.Add(new FontFallBackRule(...));

for (const auto& fallBackRule : rulesList)
{
	// در حال تلاش برای حذف فونت FallBack "Tahoma" از قوانین بارگذاری‌شده
	fallBackRule->Remove(u"Tahoma");

	// و به‌روزرسانی قوانین برای بازه مشخص‌شده
	if ((fallBackRule->get_RangeEndIndex() >= static_cast<uint32_t>(0x4000)) &&
		(fallBackRule->get_RangeStartIndex() < static_cast<uint32_t>(0x5000)))
	{
		fallBackRule->AddFallBackFonts(u"Verdana");
	}
}

// همچنین می‌توانیم هر قانون موجودی را از لیست حذف کنیم
if (rulesList->get_Count() > 0)
{
	rulesList->Remove(rulesList->idx_get(0));
}

auto pres = System::MakeObject<Presentation>(u"input.pptx");
// اختصاص فهرست قوانین آماده برای استفاده
pres->get_FontsManager()->set_FontFallBackRulesCollection(rulesList);

// رندر تصویر بندانگشتی با استفاده از مجموعه قوانین مقداردهی‌شده و ذخیره به فرمت PNG
auto image = pres->get_Slide(0)->GetImage(1.f, 1.f);
image->Save(u"Slide_0.png", Aspose::Slides::ImageFormat::Png);
image->Dispose();

pres->Dispose();
```

{{% alert color="info" %}} 
بیشتر بخوانید درباره چگونگی [تبدیل اسلایدهای PowerPoint به PNG در C++](/slides/fa/cpp/convert-powerpoint-to-png/). 
{{% /alert %}}