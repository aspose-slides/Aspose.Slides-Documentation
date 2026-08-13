---
title: رندر ارائه‌ها با فونت‌های پیش‌فرض در اندروید
linktitle: رندر ارائه‌ها
type: docs
weight: 30
url: /fa/androidjava/render-presentation-with-fallback-font/
keywords:
- فونت پیش‌فرض
- رندر پاورپوینت
- رندر ارائه
- رندر اسلاید
- پاورپوینت
- OpenDocument
- ارائه
- اندروید
- جاوا
- Aspose.Slides
description: "در Aspose.Slides برای اندروید، ارائه‌ها را با فونت‌های پیش‌فرض رندر کنید – متن را در PPT، PPTX و ODP به‌صورت ثابت نگه دارید با نمونه‌های کد جاوا گام‌به‑گام."
---
## **نمایش کلی**

Aspose.Slides به شما امکان رندر ارائه‌ها را با استفاده از قوانین فونت پیش‌فرض می‌دهد. این مقاله نشان می‌دهد چگونه یک مجموعه قوانین فونت پیش‌فرض ایجاد کنید، قوانین آن را با حذف یا افزودن فونت‌های پیش‌فرض تغییر دهید، و مجموعه را با استفاده از متد `FontsManager.setFontFallBackRulesCollection` اختصاص دهید.

پس از اختصاص مجموعه قوانین فونت پیش‌فرض به `FontsManager` ارائه، این قوانین در طول عملیات‌هایی مانند ذخیره، رندر و تبدیل ارائه اعمال می‌شوند. مثال نشان می‌دهد چگونه از قوانین پیکربندی‌شده هنگام رندر تصویر بندانگشتی اسلاید و ذخیره آن به‌صورت تصویر JPEG استفاده کنید.

## **رندر یک اسلاید با استفاده از قوانین فونت پیش‌فرض**

1. ما [مجموعه قوانین فونت پیش‌فرض را ایجاد می‌کنیم](/slides/fa/androidjava/create-fallback-fonts-collection/).
1. [حذف](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) یک قانون فونت پیش‌فرض و [addFallBackFonts](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) به قانون دیگری.
1. مجموعه قوانین را به [getFontsManager](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation#getFontsManager--).[getFontFallBackRulesCollection](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/FontsManager#getFontFallBackRulesCollection--) متد تنظیم کنید.
1. با متد [Presentation.save](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-) می‌توانیم ارائه را در همان قالب ذخیره کنیم یا در قالب دیگری. پس از تنظیم مجموعه قوانین فونت پیش‌فرض به [FontsManager](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/FontsManager)، این قوانین در هر عملیات روی ارائه اعمال می‌شوند: ذخیره، رندر، تبدیل و غیره.

```java
import com.aspose.slides.*;

// Create new instance of a rules collection
IFontFallBackRulesCollection rulesList = new FontFallBackRulesCollection();

// create a number of rules
rulesList.add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));
rulesList.add(new FontFallBackRule(0x600, 0x6FF, "Tahoma, Arial"));

for (IFontFallBackRule fallBackRule : rulesList)
{
    //Trying to remove FallBack font "Tahoma" from loaded rules
    fallBackRule.remove("Tahoma");

    //And to update of rules for specified range
    if ((fallBackRule.getRangeEndIndex() >= 0x400) && (fallBackRule.getRangeStartIndex() < 0x500))
        fallBackRule.addFallBackFonts("Verdana");
}

//Also we can remove any existing rules from list, keeping at least one rule to render with
if (rulesList.size() > 1)
    rulesList.remove(rulesList.get_Item(1));

Presentation pres = new Presentation("input.pptx");
try {
    //Assigning a prepared rules list for using
    pres.getFontsManager().setFontFallBackRulesCollection(rulesList);

    // Rendering of thumbnail with using of initialized rules collection and saving to JPEG
   IImage slideImage = pres.getSlides().get_Item(0).getImage(1f, 1f);

   //Save the image to disk in JPEG format
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
اطلاعات بیشتر درباره [تبدیل PPT و PPTX به JPG در اندروید](/slides/fa/androidjava/convert-powerpoint-to-jpg/).
{{% /alert %}}