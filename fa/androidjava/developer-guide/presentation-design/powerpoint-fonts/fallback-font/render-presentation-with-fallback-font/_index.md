---
title: رندر ارائه‌ها با فونت‌های جایگزین در اندروید
linktitle: رندر ارائه‌ها
type: docs
weight: 30
url: /fa/androidjava/render-presentation-with-fallback-font/
keywords:
- فونت جایگزین
- رندر پاورپوینت
- رندر ارائه
- رندر اسلاید
- پاورپوینت
- OpenDocument
- ارائه
- اندروید
- جاوا
- Aspose.Slides
description: "رندر ارائه‌ها با فونت‌های جایگزین در Aspose.Slides برای اندروید – متن را در PPT، PPTX و ODP به صورت یک‌دست نگه دارید با نمونه‌های کد جاوا گام به گام."
---
## **نمای کلی**

Aspose.Slides به شما امکان می‌دهد ارائه‌ها را با استفاده از قوانین فونت جایگزین رندر کنید. این مقاله نشان می‌دهد چگونه یک مجموعه قوانین فونت جایگزین ایجاد کنید، قوانین آن را با حذف یا افزودن فونت‌های جایگزین تغییر دهید، و مجموعه را با استفاده از متد `FontsManager.setFontFallBackRulesCollection` اختصاص دهید.

زمانی که مجموعه قوانین فونت جایگزین به `FontsManager` ارائه اختصاص داده می‌شود، این قوانین در طول عملیات‌هایی مانند ذخیره، رندر و تبدیل ارائه اعمال می‌شوند. مثال نشان می‌دهد چگونه از قوانین پیکربندی شده هنگام رندر تصویر بندانگشتی اسلاید و ذخیره آن به عنوان تصویر PNG استفاده کنید.

## **رندر یک اسلاید با استفاده از قوانین فونت جایگزین**

مثال زیر شامل این مراحل است:

1. ما [مجموعه قوانین فونت جایگزین را ایجاد می‌کنیم](/slides/fa/androidjava/create-fallback-fonts-collection/).
2. [حذف](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) یک قانون فونت جایگزین و [addFallBackFonts](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) به قانون دیگر.
3. مجموعه قوانین را به متد [getFontsManager](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation#getFontsManager--).[getFontFallBackRulesCollection](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/FontsManager#getFontFallBackRulesCollection--) تنظیم کنید.
4. با متد [Presentation.save](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-) می‌توانیم ارائه را در همان فرمت ذخیره کنیم یا در فرمت دیگری ذخیره کنیم. پس از تنظیم مجموعه قوانین فونت جایگزین به [FontsManager](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/FontsManager)، این قوانین در هر عملیاتی بر روی ارائه اعمال می‌شوند: ذخیره، رندر، تبدیل و غیره.

```java
// ایجاد یک نمونه جدید از مجموعه قوانین
IFontFallBackRulesCollection rulesList = new FontFallBackRulesCollection();

// ایجاد چندین قانون
rulesList.add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));

for (IFontFallBackRule fallBackRule : rulesList)
{
    // در حال تلاش برای حذف فونت جایگزین "Tahoma" از قوانین بارگذاری شده
    fallBackRule.remove("Tahoma");

    // و به‌روزرسانی قوانین برای بازه مشخص شده
    if ((fallBackRule.getRangeEndIndex() >= 0x4000) && (fallBackRule.getRangeStartIndex() < 0x5000))
        fallBackRule.addFallBackFonts("Verdana");
}

// همچنین می‌توانیم هر قانون موجودی را از لیست حذف کنیم
if (rulesList.size() > 0)
    rulesList.remove(rulesList.get_Item(0));

Presentation pres = new Presentation("input.pptx");
try {
    // اختصاص یک لیست قوانین آماده برای استفاده
    pres.getFontsManager().setFontFallBackRulesCollection(rulesList);

    // رندر تصویر بندانگشتی با استفاده از مجموعه قوانین مقداردهی اولیه و ذخیره به JPEG
   IImage slideImage = pres.getSlides().get_Item(0).getImage(1f, 1f);

   // ذخیره تصویر در دیسک به فرمت JPEG
   try {
         slideImage.save("Slide_0.jpg", ImageFormat.Jpeg);
   } finally {
        if (slideImage != null) slideImage.dispose();
   }
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="primary" %}} 
اطلاعات بیشتر درباره [تبدیل PPT و PPTX به JPG در اندروید](/slides/fa/androidjava/convert-powerpoint-to-jpg/).
{{% /alert %}}