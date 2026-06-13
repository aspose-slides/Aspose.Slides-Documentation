---
title: نمایش ارائه‌ها با فونت‌های جایگزین در .NET
linktitle: نمایش ارائه‌ها
type: docs
weight: 30
url: /fa/net/render-presentation-with-fallback-font/
keywords:
- فونت جایگزین
- رندر PowerPoint
- رندر ارائه
- رندر اسلاید
- PowerPoint
- OpenDocument
- ارائه
- .NET
- C#
- Aspose.Slides
description: "ارائه‌ها را با فونت‌های جایگزین در Aspose.Slides برای .NET رندر کنید – متن را در فرمت‌های PPT، PPTX و ODP به صورت سازگار و یکنواخت نگه دارید با نمونه‌های کد گام‌به‌گام C#."
---
## **بررسی کلی**

Aspose.Slides به شما اجازه می‌دهد ارائه‌ها را با استفاده از قوانین فونت جایگزین رندر کنید. این مقاله نشان می‌دهد چگونه یک مجموعه قوانین فونت جایگزین ایجاد کنید، قوانین آن را با حذف یا افزودن فونت‌های جایگزین تغییر دهید، و مجموعه را به ویژگی `FontsManager.FontFallBackRulesCollection` اختصاص دهید.

پس از اینکه مجموعه قوانین فونت جایگزین به `FontsManager` ارائه اختصاص یافت، این قوانین در عملیات‌هایی مانند ذخیره، رندر و تبدیل ارائه اعمال می‌شوند. مثال نشان می‌دهد چگونه از قوانین پیکربندی‌شده هنگام رندر کردن تصویر کوچک اسلاید و ذخیره آن به صورت تصویر PNG استفاده کنید.

## **رندر اسلاید با استفاده از قوانین فونت جایگزین**

مثال زیر شامل این مراحل است:

1. ما [مجموعه قوانین فونت جایگزین را ایجاد می‌کنیم](/slides/fa/net/create-fallback-fonts-collection/).
2. [Remove()] یک قانون فونت جایگزین را حذف می‌کند و [AddFallBackFonts()] را به قانون دیگر اضافه می‌کند.
3. مجموعه قوانین را به ویژگی [FontsManager.FontFallBackRulesCollection] تنظیم کنید.
4. با متد [Presentation.Save()] می‌توانیم ارائه را در همان قالب ذخیره کنیم یا در قالب دیگری ذخیره کنیم. پس از تنظیم مجموعه قوانین فونت جایگزین در FontsManager، این قوانین در هر عملیاتی روی ارائه اعمال می‌شوند: ذخیره، رندر، تبدیل و غیره.

```c#
// یک نمونه جدید از مجموعه قوانین ایجاد کنید
IFontFallBackRulesCollection rulesList = new FontFallBackRulesCollection();

// تعداد مشخصی از قوانین ایجاد کنید
rulesList.Add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));
//rulesList.Add(new FontFallBackRule(...));

foreach (IFontFallBackRule fallBackRule in rulesList)
{
	// در حال تلاش برای حذف فونت جایگزین "Tahoma" از قوانین بارگذاری‌شده
	fallBackRule.Remove("Tahoma");

	// و به‌روزرسانی قوانین برای بازهٔ مشخص شده
	if ((fallBackRule.RangeEndIndex >= 0x4000) && (fallBackRule.RangeStartIndex < 0x5000))
		fallBackRule.AddFallBackFonts("Verdana");
}

// همچنین می‌توانیم هر قانون موجودی را از لیست حذف کنیم
if (rulesList.Count > 0)
	rulesList.Remove(rulesList[0]);

using (Presentation pres = new Presentation("input.pptx"))
{
    // اختصاص فهرست قوانین آماده برای استفاده
    pres.FontsManager.FontFallBackRulesCollection = rulesList;

    // رندر تصویر کوچک با استفاده از مجموعه قوانین اولیه و ذخیره به PNG
    using (IImage image = pres.Slides[0].GetImage(1f, 1f))
    {
        image.Save("Slide_0.png", ImageFormat.Png);
    }
}
```

{{% alert color="primary" %}} 
اطلاعات بیشتر در مورد [ذخیره و تبدیل در ارائه](/slides/fa/net/convert-powerpoint-to-png/).
{{% /alert %}}