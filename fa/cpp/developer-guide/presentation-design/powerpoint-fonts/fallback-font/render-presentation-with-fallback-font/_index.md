---
title: رندر ارائه‌ها با فونت‌های پیش‌گزین در C++
linktitle: رندر ارائه‌ها
type: docs
weight: 30
url: /fa/cpp/render-presentation-with-fallback-font/
keywords:
- فونت پیش‌گزین
- رندر پاورپوینت
- رندر ارائه
- رندر اسلاید
- PowerPoint
- OpenDocument
- ارائه
- C++
- Aspose.Slides
description: "رندر ارائه‌ها با فونت‌های پیش‌گزین در Aspose.Slides برای C++ – متن را در قالب‌های PPT، PPTX و ODP به صورت یکسان نگه دارید با نمونه‌های کد گام‌به‌گام C++."
---
## **مرور کلی**

Aspose.Slides به شما امکان رندر کردن ارائه‌ها را با استفاده از قوانین فونت پیش‌گزین می‌دهد. این مقاله نشان می‌دهد چگونه یک مجموعه قوانین فونت پیش‌گزین ایجاد کنید، قوانین آن را با حذف یا افزودن فونت‌های پیش‌گزین تغییر دهید، و مجموعه را با استفاده از متد `FontsManager::set_FontFallBackRulesCollection` اختصاص دهید.

پس از انتساب مجموعه قوانین فونت پیش‌گزین به `FontsManager` ارائه، این قوانین در طول عملیات‌هایی مانند ذخیره‌سازی، رندر کردن و تبدیل ارائه اعمال می‌شوند. این مثال نشان می‌دهد چگونه از قوانین پیکربندی‌شده هنگام رندر کردن تصویر بندانگشتی یک اسلاید و ذخیره آن به صورت تصویر PNG استفاده کنید.

## **رندر یک اسلاید با استفاده از قوانین فونت پیش‌گزین**

مثال زیر شامل این مراحل است:

1. ما [مجموعه قوانین فونت پیش‌گزین را ایجاد می‌کنیم](/slides/fa/cpp/create-fallback-fonts-collection/).
2. [Remove()](https://reference.aspose.com/slides/fa/cpp/aspose.slides/fontfallbackrule/remove/) یک قانون فونت پیش‌گزین را حذف می‌کنیم و [AddFallBackFonts()](https://reference.aspose.com/slides/fa/cpp/aspose.slides/fontfallbackrule/addfallbackfonts/) را به قانون دیگری اضافه می‌کنیم.
3. مجموعه قوانین را به متد [FontsManager::set_FontFallBackRulesCollection()](https://reference.aspose.com/slides/fa/cpp/aspose.slides/fontsmanager/set_fontfallbackrulescollection/) پاس می‌دهیم.
4. با متد [Presentation::Save()](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/save/) می‌توانیم ارائه را در همان فرمت ذخیره کنیم یا در فرمت دیگری ذخیره کنیم. پس از تنظیم مجموعه قوانین فونت پیش‌گزین در FontsManager، این قوانین در هر عملیاتی روی ارائه اعمال می‌شوند: ذخیره، رندر، تبدیل و غیره.

``` cpp
// ایجاد یک نمونه جدید از مجموعه قوانین
auto rulesList = MakeObject<FontFallBackRulesCollection>();

// ایجاد چندین قانون
rulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x400), static_cast<uint32_t>(0x4FF), u"Times New Roman"));
//rulesList.Add(new FontFallBackRule(...));

for (const auto& fallBackRule : rulesList)
{
	// تلاش برای حذف فونت پیش‌گزین "Tahoma" از قوانین بارگذاری‌شده
	fallBackRule->Remove(u"Tahoma");

	// و برای به‌روزرسانی قوانین برای بازه مشخص شده
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
// Assigning a prepared rules list for using
pres->get_FontsManager()->set_FontFallBackRulesCollection(rulesList);

// Rendering of thumbnail with using of initialized rules collection and saving to PNG
auto image = pres->get_Slide(0)->GetImage(1.f, 1.f);
image->Save(u"Slide_0.png", ImageFormat::Png);
image->Dispose();

pres->Dispose();
```

{{% alert color="primary" %}} 
اطلاعات بیشتری در مورد نحوه [تبدیل اسلایدهای PowerPoint به PNG در C++](/slides/fa/cpp/convert-powerpoint-to-png/) بخوانید.
{{% /alert %}}