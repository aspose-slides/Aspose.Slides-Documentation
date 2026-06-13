---
title: رندر ارائه‌ها با فونت‌های جایگزین در JavaScript
linktitle: رندر ارائه‌ها
type: docs
weight: 30
url: /fa/nodejs-java/render-presentation-with-fallback-font/
keywords:
- فونت جایگزین
- رندر PowerPoint
- رندر ارائه
- رندر اسلاید
- PowerPoint
- OpenDocument
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "رندر ارائه‌ها با فونت‌های جایگزین در Aspose.Slides برای Node.js – متن را در سراسر PPT، PPTX و ODP به‌صورت یک‌دست نگه دارید با نمونه‌های کد گام به گام JavaScript."
---
## **بررسی کلی**

Aspose.Slides به شما امکان می‌دهد ارائه‌ها را با استفاده از قوانین فونت جایگزین رندر کنید. این مقاله نشان می‌دهد چگونه یک مجموعه قوانین فونت جایگزین ایجاد کنید، قوانین آن را با حذف یا افزودن فونت‌های جایگزین تغییر دهید، و مجموعه را با استفاده از متد `FontsManager.setFontFallBackRulesCollection` اختصاص دهید.

به‌محض اختصاص مجموعه قوانین فونت جایگزین به `FontsManager` ارائه، این قوانین در عملیات‌هایی مانند ذخیره، رندر و تبدیل ارائه اعمال می‌شوند. مثال نشان می‌دهد چگونه هنگام رندر تصویر کوچک اسلاید و ذخیره آن به عنوان تصویر PNG از قوانین پیکربندی شده استفاده شود.

## **رندر اسلاید با استفاده از قوانین فونت جایگزین**

1. ما [مجموعه قوانین فونت جایگزین را ایجاد می‌کنیم](/slides/fa/nodejs-java/create-fallback-fonts-collection/).
2. [حذف](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/FontFallBackRule#remove-java.lang.String-) یک قانون فونت جایگزین و [addFallBackFonts](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) به قانون دیگری.
3. مجموعه قوانین را به متد [getFontsManager](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation#getFontsManager--).[getFontFallBackRulesCollection](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/FontsManager#getFontFallBackRulesCollection--) اختصاص دهید.
4. با استفاده از متد [Presentation.save](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-) می‌توانیم ارائه را در همان قالب ذخیره کنیم یا در قالب دیگری ذخیره کنیم. پس از اینکه مجموعه قوانین فونت جایگزین به [FontsManager](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/FontsManager) اختصاص یافت، این قوانین در تمام عملیات روی ارائه اعمال می‌شوند: ذخیره، رندر، تبدیل و غیره.

```javascript
// ایجاد یک نمونه جدید از مجموعه قوانین
var rulesList = new aspose.slides.FontFallBackRulesCollection();
// ایجاد تعدادی قانون
rulesList.add(new aspose.slides.FontFallBackRule(0x400, 0x4ff, "Times New Roman"));
for (let i = 0; i < rulesList.size(); i++) {
    let fallBackRule = rulesList.get_Item(0);
    // تلاش برای حذف فونت FallBack "Tahoma" از قوانین بارگذاری‌شده
    fallBackRule.remove("Tahoma");
    // و به‌روزرسانی قوانین برای بازه مشخص شده
    if ((fallBackRule.getRangeEndIndex() >= 0x4000) && (fallBackRule.getRangeStartIndex() < 0x5000)) {
        fallBackRule.addFallBackFonts("Verdana");
    }
}
// همچنین می‌توانیم هر قانون موجودی را از لیست حذف کنیم
if (rulesList.size() > 0) {
    rulesList.remove(rulesList.get_Item(0));
}
var pres = new aspose.slides.Presentation("input.pptx");
try {
    // اختصاص یک فهرست قوانین آماده برای استفاده
    pres.getFontsManager().setFontFallBackRulesCollection(rulesList);
    // رندر تصویر بندانگشتی با استفاده از مجموعه قوانین اولیه و ذخیره به فرمت JPEG
    var slideImage = pres.getSlides().get_Item(0).getImage(1.0, 1.0);
    // ذخیره تصویر بر روی دیسک در فرمت JPEG
    try {
        slideImage.save("Slide_0.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert color="primary" %}} 
اطلاعات بیشتر در مورد نحوه [تبدیل PPT و PPTX به JPG در JavaScript](/slides/fa/nodejs-java/convert-powerpoint-to-jpg/).
{{% /alert %}}