---
title: "نمایش ارائه‌ها با قلم‌های بازگشتی در پایتون"
linktitle: "نمایش ارائه‌ها"
type: docs
weight: 30
url: /fa/python-net/render-presentation-with-fallback-font/
keywords:
- "قلم بازگشتی"
- "رندر پاورپوینت"
- "رندر ارائه"
- "رندر اسلاید"
- "پاورپوینت"
- "ارائه"
- "پایتون"
- "Aspose.Slides"
description: "نمایش ارائه‌ها با قلم‌های بازگشتی در Aspose.Slides برای پایتون از طریق .NET – حفظ سازگاری متن در فرمت‌های PPT، PPTX و ODP با نمونه‌های کد گام به گام."
---
## **نمایش کلی**

Aspose.Slides به شما امکان می‌دهد ارائه‌ها را با استفاده از قوانین قلم بازگشتی رندر کنید. این مقاله نشان می‌دهد چگونه یک مجموعه قوانین قلم بازگشتی ایجاد کنید، قوانین آن را با حذف یا افزودن قلم‌های بازگشتی تغییر دهید و مجموعه را به ویژگی `FontsManager.font_fall_back_rules_collection` اختصاص دهید.

پس از اختصاص مجموعه قوانین قلم بازگشتی به `fonts_manager` ارائه، این قوانین در عملیات‌هایی مانند ذخیره‌سازی، رندر و تبدیل ارائه اعمال می‌شوند. مثال نشان می‌دهد چگونه از قوانین پیکربندی‌شده هنگام رندر تصویر بندانگشتی اسلاید و ذخیره آن به صورت تصویر PNG استفاده کنید.

## **رندر اسلاید با استفاده از قوانین قلم بازگشتی**

مثال زیر شامل این مراحل است:

1. ما [مجموعه قوانین قلم بازگشتی را ایجاد می‌کنیم](/slides/fa/python-net/create-fallback-fonts-collection/).
2. [حذف](https://reference.aspose.com/slides/fa/python-net/aspose.slides/fontfallbackrule/remove/) یک قانون قلم بازگشتی و [add_fall_back_fonts](https://reference.aspose.com/slides/fa/python-net/aspose.slides/fontfallbackrule/add_fall_back_fonts/) را به قانون دیگر اضافه کنید.
3. مجموعه قوانین را به خصوصیت [FontsManager.font_fall_back_rules_collection](https://reference.aspose.com/slides/fa/python-net/aspose.slides/fontsmanager/font_fall_back_rules_collection/) تنظیم کنید.
4. با متد [Presentation.save()](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) می‌توانیم ارائه را با همان فرمت ذخیره کنیم یا آن را در فرمت دیگری ذخیره کنیم. پس از تنظیم مجموعه قوانین قلم بازگشتی در FontsManager، این قوانین در هر عملیات روی ارائه اعمال می‌شوند: ذخیره، رندر، تبدیل و غیره.

```py
import aspose.slides as slides

# ایجاد یک نمونه جدید از مجموعه قوانین
rulesList = slides.FontFallBackRulesCollection()

# ایجاد چندین قانون
rulesList.add(slides.FontFallBackRule(0x400, 0x4FF, "Times New Roman"))

for fallBackRule in rulesList:
	# سعی در حذف قلم FallBack "Tahoma" از قوانین بارگذاری شده
	fallBackRule.remove("Tahoma")

	# و به‌روزرسانی قوانین برای بازه مشخص
	if fallBackRule.range_end_index >= 0x4000 and fallBackRule.range_start_index < 0x5000:
		fallBackRule.add_fall_back_fonts("Verdana")

# همچنین می‌توانیم هر قانون موجودی را از لیست حذف کنیم
if len(rulesList) > 0:
	rulesList.remove(rulesList[0])

with slides.Presentation(path + "input.pptx") as pres:
	# اختصاص یک لیست قوانین آماده برای استفاده
	pres.fonts_manager.font_fall_back_rules_collection = rulesList

	# رندر تصویر بندانگشتی با استفاده از مجموعه قوانین اولیه و ذخیره به PNG
	with pres.slides[0].get_image(1, 1) as img:
		img.save("Slide_0.png", slides.ImageFormat.PNG)
```

{{% alert color="primary" %}} 
اطلاعات بیشتر دربارهٔ چگونگی [Convert PowerPoint Slides to PNG in Python](/slides/fa/python-net/convert-powerpoint-to-png/).
{{% /alert %}}