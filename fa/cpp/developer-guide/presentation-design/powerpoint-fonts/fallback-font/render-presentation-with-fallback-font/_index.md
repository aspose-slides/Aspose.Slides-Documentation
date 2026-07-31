---
title: رندر ارائه‌ها با فونت‌های جایگزین در C++
linktitle: رندر ارائه‌ها
type: docs
weight: 30
url: /fa/cpp/render-presentation-with-fallback-font/
keywords:
- فونت جایگزین
- رندر پاورپوینت
- رندر ارائه
- رندر اسلاید
- پاورپوینت
- OpenDocument
- ارائه
- C++
- Aspose.Slides
description: "ارائه‌ها را با فونت‌های جایگزین در Aspose.Slides برای C++ رندر کنید – متن را در قالب‌های PPT، PPTX و ODP به‌صورت ثابت نگه دارید با نمونه کدهای گام‌به‌گام C++."
---
## **بررسی کلی**

Aspose.Slides به شما امکان رندر ارائه‌ها با استفاده از قوانین فونت جایگزین را می‌دهد. این مقاله نشان می‌دهد چگونه یک مجموعه قوانین فونت جایگزین ایجاد کنید، قوانین آن را با حذف یا افزودن فونت‌های جایگزین تعديل کنید، و مجموعه را با استفاده از متد `FontsManager::set_FontFallBackRulesCollection` اختصاص دهید.

به محض اینکه مجموعه قوانین فونت جایگزین به `FontsManager` ارائه اختصاص یابد، این قوانین در طول عملیات‌هایی مانند ذخیره، رندر و تبدیل ارائه اعمال می‌شوند. مثال نشان می‌دهد چگونه هنگام رندر تصویر بندانگشتی یک اسلاید و ذخیره آن به‌عنوان تصویر PNG از قوانین پیکربندی شده استفاده کنیم.

## **رندر اسلاید با استفاده از قوانین فونت جایگزین**

1. ما [مجموعه قوانین فونت جایگزین را ایجاد می‌کنیم](/slides/fa/cpp/create-fallback-fonts-collection/).
2. [Remove()](https://reference.aspose.com/slides/fa/cpp/aspose.slides/fontfallbackrule/remove/) یک قانون فونت جایگزین را حذف می‌کند و [AddFallBackFonts()](https://reference.aspose.com/slides/fa/cpp/aspose.slides/fontfallbackrule/addfallbackfonts/) را به قانون دیگری اضافه می‌کند.
3. مجموعه قوانین را به متد [FontsManager::set_FontFallBackRulesCollection()](https://reference.aspose.com/slides/fa/cpp/aspose.slides/fontsmanager/set_fontfallbackrulescollection/) پاس می‌دهید.
4. با متد [Presentation::Save()](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/save/) می‌توانیم ارائه را در همان قالب ذخیره کنیم یا در قالب دیگری ذخیره کنیم. پس از تنظیم مجموعه قوانین فونت جایگزین در FontsManager، این قوانین در طول هر عملیاتی روی ارائه اعمال می‌شوند: ذخیره، رندر، تبدیل و غیره.

``` cpp
// یک نمونه جدید از مجموعه قوانین ایجاد کنید
auto rulesList = MakeObject<FontFallBackRulesCollection>();

// تعداد تعدادی قانون ایجاد کنید
rulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x400), static_cast<uint32_t>(0x4FF), u"Times New Roman"));
//rulesList.Add(new FontFallBackRule(...));

for (const auto& fallBackRule : rulesList)
{
	// در حال تلاش برای حذف فونت FallBack "Tahoma" از قوانین بارگذاری شده
	fallBackRule->Remove(u"Tahoma");

	// و به‌روزرسانی قوانین برای بازه مشخص شده
	if ((fallBackRule->get_RangeEndIndex() >= static_cast<uint32_t>(0x4000)) && 
		(fallBackRule->get_RangeStartIndex() < static_cast<uint32_t>(0x5000)))
	{
		fallBackRule->AddFallBackFonts(u"Verdana");
	}
}

// همچنین می‌توانیم هر قاعده موجودی را از لیست حذف کنیم
if (rulesList->get_Count() > 0)
{
	rulesList->Remove(rulesList->idx_get(0));
}

auto pres = System::MakeObject<Presentation>(u"input.pptx");
// اختصاص یک لیست قوانین آماده برای استفاده
pres->get_FontsManager()->set_FontFallBackRulesCollection(rulesList);

// رندر تصویر بندانگشتی با استفاده از مجموعه قوانین اولیه و ذخیره به صورت PNG
auto image = pres->get_Slide(0)->GetImage(1.f, 1.f);
image->Save(u"Slide_0.png", ImageFormat::Png);
image->Dispose();

pres->Dispose();
```

{{% alert color="primary" %}} 
اطلاعات بیشتر در مورد چگونگی [تبدیل اسلایدهای پاورپوینت به PNG در C++](/slides/fa/cpp/convert-powerpoint-to-png/).
{{% /alert %}}