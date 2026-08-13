---
title: رندر ارائه‌ها با فونت‌های جایگزین در جاوا
linktitle: رندر ارائه‌ها
type: docs
weight: 30
url: /fa/java/render-presentation-with-fallback-font/
keywords:
- فونت جایگزین
- رندر پاورپوینت
- رندر ارائه
- رندر اسلاید
- پاورپوینت
- اسناد باز
- ارائه
- جاوا
- Aspose.Slides
description: "رندر ارائه‌ها با فونت‌های جایگزین در Aspose.Slides برای جاوا – متن را در سراسر PPT، PPTX و ODP به‌صورت سازگار نگه داشته و نمونه‌های کد گام به گام جاوا."
---
## **مروری کلی**

Aspose.Slides به شما امکان رندر ارائه‌ها با استفاده از قوانین فونت جایگزین را می‌دهد. این مقاله نشان می‌دهد چگونه یک مجموعهٔ قوانین فونت جایگزین ایجاد کنید، قوانین آن را با حذف یا افزودن فونت‌های جایگزین تغییر دهید، و مجموعه را با استفاده از متد `FontsManager.setFontFallBackRulesCollection` اختصاص دهید.

به‌محض اینکه مجموعهٔ قوانین فونت جایگزین به `FontsManager` ارائه اختصاص یابد، این قوانین در عملیات‌هایی مانند ذخیره، رندر و تبدیل ارائه اعمال می‌شوند. این مثال نشان می‌دهد چگونه هنگام رندر تصویر بندانگشتی اسلاید و ذخیره آن به عنوان تصویر JPEG از قوانین پیکربندی‌شده استفاده کنید.

## **رندر اسلاید با استفاده از قوانین فونت جایگزین**

مثال زیر شامل این مراحل است:

1. ما [مجموعهٔ قوانین فونت جایگزین را ایجاد می‌کنیم](/slides/fa/java/create-fallback-fonts-collection/).
2. [حذف](https://reference.aspose.com/slides/fa/java/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) یک قانون فونت جایگزین و [addFallBackFonts](https://reference.aspose.com/slides/fa/java/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) به قانون دیگر.
3. مجموعهٔ قوانین را به متد [getFontsManager](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation#getFontsManager--).[getFontFallBackRulesCollection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/FontsManager#getFontFallBackRulesCollection--) تنظیم کنید.
4. با متد [Presentation.save](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation#save-java.lang.String-int-) می‌توانیم ارائه را در همان فرمت ذخیره کنیم، یا آن را در قالب دیگری ذخیره کنیم. پس از اینکه مجموعهٔ قوانین فونت جایگزین به [FontsManager](https://reference.aspose.com/slides/fa/java/com.aspose.slides/FontsManager) تنظیم شد، این قوانین در تمام عملیات‌های انجام شده بر روی ارائه اعمال می‌شوند: ذخیره، رندر، تبدیل و غیره.

```java
import com.aspose.slides.*;

// ایجاد یک نمونه جدید از مجموعهٔ قوانین
IFontFallBackRulesCollection rulesList = new FontFallBackRulesCollection();

// create a number of rules
rulesList.add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));
rulesList.add(new FontFallBackRule(0x600, 0x6FF, "Tahoma, Arial"));

for (IFontFallBackRule fallBackRule : rulesList)
{
    // سعی در حذف فونت جایگزین "Tahoma" از قوانین بارگذاری‌شده
    fallBackRule.remove("Tahoma");

    // و به‌روزرسانی قوانین برای بازهٔ مشخص‌شده
    if ((fallBackRule.getRangeEndIndex() >= 0x400) && (fallBackRule.getRangeStartIndex() < 0x500))
        fallBackRule.addFallBackFonts("Verdana");
}

// همچنین می‌توانیم هر قانونی که موجود است از لیست حذف کنیم، به‌طوری‌که حداقل یک قانون برای رندر باقی بماند
if (rulesList.size() > 1)
    rulesList.remove(rulesList.get_Item(1));

Presentation pres = new Presentation("input.pptx");
try {
    // تخصیص فهرست قوانین آماده برای استفاده
    pres.getFontsManager().setFontFallBackRulesCollection(rulesList);

    // رندر تصویر بندانگشتی با استفاده از مجموعهٔ قوانین مقداردهی‌شده و ذخیره به فرمت JPEG
   IImage slideImage = pres.getSlides().get_Item(0).getImage(1f, 1f);

   // ذخیره تصویر بر روی دیسک به فرمت JPEG
   try {
         slideImage.save("Slide_0.jpg", ImageFormat.Jpeg);
   } finally {
        if (slideImage != null) slideImage.dispose();
   }
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="info" %}} 
برای اطلاعات بیشتر دربارهٔ نحوهٔ [تبدیل PPT و PPTX به JPG در جاوا](/slides/fa/java/convert-powerpoint-to-jpg/) بخوانید.
{{% /alert %}}