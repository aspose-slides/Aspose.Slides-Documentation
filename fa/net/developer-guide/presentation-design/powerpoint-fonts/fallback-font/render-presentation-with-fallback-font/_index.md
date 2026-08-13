---
title: رندر ارائه‌ها با فونت‌های جایگزین در .NET
linktitle: رندر ارائه‌ها
type: docs
weight: 30
url: /fa/net/render-presentation-with-fallback-font/
keywords:
- فونت جایگزین
- رندر پاورپوینت
- رندر ارائه
- رندر اسلاید
- پاورپوینت
- OpenDocument
- ارائه
- .NET
- C#
- Aspose.Slides
description: "رندر ارائه‌ها با فونت‌های جایگزین در Aspose.Slides برای .NET – حفظ سازگاری متن در میان PPT، PPTX و ODP با نمونه‌های کد گام‌به‌گام C#."
---
## **نمای کلی**

Aspose.Slides به شما امکان رندر ارائه‌ها را با استفاده از قوانین فونت جایگزین می‌دهد. این مقاله نشان می‌دهد که چگونه یک مجموعه قوانین فونت جایگزین ایجاد کنید، قوانین آن را با حذف یا افزودن فونت‌های جایگزین تغییر دهید، و مجموعه را به ویژگی `FontsManager.FontFallBackRulesCollection` اختصاص دهید.

هنگامی که مجموعه قوانین فونت جایگزین به `FontsManager` ارائه اختصاص یافت، این قوانین در طول عملیات‌هایی مانند ذخیره، رندر و تبدیل ارائه اعمال می‌شوند. مثال نشان می‌دهد که چگونه از قوانین پیکربندی‌شده هنگام رندر تصویر بندانگشتی اسلاید و ذخیره آن به عنوان تصویر PNG استفاده کنید.

## **رندر یک اسلاید با استفاده از قوانین فونت جایگزین**

1. ما [مجموعه قوانین فونت جایگزین را ایجاد می‌کنیم](/slides/fa/net/create-fallback-fonts-collection/).
2. [Remove()](https://reference.aspose.com/slides/fa/net/aspose.slides/fontfallbackrule/methods/remove) یک قانون فونت جایگزین را حذف کنید و [AddFallBackFonts()](https://reference.aspose.com/slides/fa/net/aspose.slides/fontfallbackrule/methods/addfallbackfonts) را به قانون دیگر اضافه کنید.
3. مجموعه قوانین را به ویژگی [FontsManager.FontFallBackRulesCollection](https://reference.aspose.com/slides/fa/net/aspose.slides/fontsmanager/properties/fontfallbackrulescollection) تنظیم کنید.
4. با متد [Presentation.Save()](https://reference.aspose.com/slides/fa/net/aspose.slides.presentation/save/methods/4) می‌توانیم ارائه را در همان قالب ذخیره کنیم یا در قالب دیگری ذخیره کنیم. پس از تنظیم مجموعه قوانین فونت جایگزین به FontsManager، این قوانین در هر عملیاتی روی ارائه اعمال می‌شوند: ذخیره، رندر، تبدیل و غیره.

```c#
using Aspose.Slides;

// ایجاد یک نمونه جدید از مجموعه قوانین
IFontFallBackRulesCollection rulesList = new FontFallBackRulesCollection();

// ایجاد چند قانون
rulesList.Add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));
rulesList.Add(new FontFallBackRule(0x600, 0x6FF, "Tahoma, Arial"));

foreach (IFontFallBackRule fallBackRule in rulesList)
{
	// تلاش برای حذف فونت جایگزین "Tahoma" از قوانین بارگذاری شده
	fallBackRule.Remove("Tahoma");

	// و به‌روزرسانی قوانین برای بازه مشخص
	if ((fallBackRule.RangeEndIndex >= 0x400) && (fallBackRule.RangeStartIndex < 0x500))
		fallBackRule.AddFallBackFonts("Verdana");
}

// همچنین می‌توانیم هر قانون موجودی را از لیست حذف کنیم، به‌طوری که حداقل یک قانون برای رندر باقی بماند
if (rulesList.Count > 1)
	rulesList.Remove(rulesList[1]);

using (Presentation pres = new Presentation("input.pptx"))
{
    // اختصاص یک لیست قوانین آماده برای استفاده
    pres.FontsManager.FontFallBackRulesCollection = rulesList;

    // رندر تصویر بندانگشتی با استفاده از مجموعه قوانین اولیه و ذخیره به PNG
    using (IImage image = pres.Slides[0].GetImage(1f, 1f))
    {
        image.Save("Slide_0.png", ImageFormat.Png);
    }
}
```

{{% alert color="info" %}} 
بیشتر بخوانید درباره [ذخیره‌سازی و تبدیل در ارائه](/slides/fa/net/convert-powerpoint-to-png/).
{{% /alert %}}