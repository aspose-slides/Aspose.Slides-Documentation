---
title: رندر ارائه‌ها با فونت‌های پیش‌فرض در جاوا
linktitle: رندر ارائه‌ها
type: docs
weight: 30
url: /fa/java/render-presentation-with-fallback-font/
keywords:
- فونت پیش‌فرض
- رندر پاورپوینت
- رندر ارائه
- رندر اسلاید
- پاورپوینت
- OpenDocument
- ارائه
- جاوا
- Aspose.Slides
description: "رندر ارائه‌ها با فونت‌های پیش‌فرض در Aspose.Slides برای جاوا – متن را در قالب‌های PPT، PPTX و ODP به صورت یک‌دست نگه دارید با نمونه‌های کد گام‌به‌گام جاوا."
---
## **مرور کلی**

Aspose.Slides به شما امکان می‌دهد ارائه‌ها را با استفاده از قوانین فونت پیش‌فرض رندر کنید. این مقاله نشان می‌دهد چگونه یک مجموعهٔ قوانین فونت پیش‌فرض ایجاد کنید، قوانین آن را با حذف یا افزودن فونت‌های پیش‌فرض تغییر دهید و مجموعه را با استفاده از متد `FontsManager.setFontFallBackRulesCollection` اختصاص دهید.

هنگامی که مجموعهٔ قوانین فونت پیش‌فرض به `FontsManager` ارائه اختصاص داده شود، این قوانین در طول عملیات‌هایی مانند ذخیره، رندر و تبدیل ارائه اعمال می‌شوند. مثال نشان می‌دهد چگونه می‌توان هنگام رندر تصویر بندانگشتی یک اسلاید و ذخیرهٔ آن به‌صورت تصویر PNG از قوانین پیکربندی‌شده استفاده کرد.

## **رندر یک اسلاید با استفاده از قوانین فونت پیش‌فرض**

مثال زیر شامل این مراحل است:

1. ما [مجموعه قوانین فونت پیش‌فرض](/slides/fa/java/create-fallback-fonts-collection/) را ایجاد می‌کنیم.
2. [حذف](https://reference.aspose.com/slides/fa/java/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) یک قانون فونت پیش‌فرض و [addFallBackFonts](https://reference.aspose.com/slides/fa/java/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) را به قانون دیگری اضافه کنید.
3. مجموعه قوانین را به متد [getFontsManager](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation#getFontsManager--) .[getFontFallBackRulesCollection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/FontsManager#getFontFallBackRulesCollection--) اختصاص دهید.
4. با استفاده از متد [Presentation.save](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation#save-java.lang.String-int-) می‌توانیم ارائه را با همان فرمت ذخیره کنیم یا در فرمت دیگری ذخیره کنیم. پس از تنظیم مجموعهٔ قوانین فونت پیش‌فرض در [FontsManager](https://reference.aspose.com/slides/fa/java/com.aspose.slides/FontsManager)، این قوانین در هر عملیات بر روی ارائه مانند ذخیره، رندر، تبدیل و غیره اعمال می‌شوند.

```java
// ایجاد یک نمونه جدید از مجموعه قوانین
IFontFallBackRulesCollection rulesList = new FontFallBackRulesCollection();

// ایجاد چندین قانون
rulesList.add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));

for (IFontFallBackRule fallBackRule : rulesList)
{
    // در حال تلاش برای حذف فونت پیش‌فرض "Tahoma" از قوانین بارگذاری‌شده
    fallBackRule.remove("Tahoma");

    // و به‌روزرسانی قوانین برای بازه مشخص‌شده
    if ((fallBackRule.getRangeEndIndex() >= 0x4000) && (fallBackRule.getRangeStartIndex() < 0x5000))
        fallBackRule.addFallBackFonts("Verdana");
}

// همچنین می‌توانیم هر قانون موجودی را از لیست حذف کنیم
if (rulesList.size() > 0)
    rulesList.remove(rulesList.get_Item(0));

Presentation pres = new Presentation("input.pptx");
try {
    // اختصاص لیست قوانین آماده برای استفاده
    pres.getFontsManager().setFontFallBackRulesCollection(rulesList);

    // رندر تصویر بندانگشتی با استفاده از مجموعه قوانین مقداردهی‌شده و ذخیره به صورت JPEG
   IImage slideImage = pres.getSlides().get_Item(0).getImage(1f, 1f);

   // ذخیره تصویر بر روی دیسک با فرمت JPEG
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
بیشتر دربارهٔ نحوهٔ [تبدیل PPT و PPTX به JPG در جاوا](/slides/fa/java/convert-powerpoint-to-jpg/) بخوانید.
{{% /alert %}}