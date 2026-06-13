---
title: مشخص کردن قلم‌های پیش‌فرض ارائه در Android
linktitle: قلم پیش‌فرض
type: docs
weight: 30
url: /fa/androidjava/default-font/
keywords:
- قلم پیش‌فرض
- قلم معمولی
- قلم عادی
- قلم آسیایی
- صادرات PDF
- صادرات XPS
- صادرات تصویر
- PowerPoint
- OpenDocument
- ارائه
- Android
- Java
- Aspose.Slides
description: "قلم‌های پیش‌فرض را در Aspose.Slides برای Android با استفاده از Java تنظیم کنید تا تبدیل صحیح PowerPoint (PPT، PPTX) و OpenDocument (ODP) به PDF، XPS و تصاویر تضمین شود."
---
## **بررسی کلی**

Aspose.Slides به شما امکان می‌دهد قلم‌های پیش‌فرض که هنگام رندر یک ارائه استفاده می‌شوند را مشخص کنید. این برای تولید تصویر کوچک اسلایدها یا استخراج ارائه به قالب‌هایی مانند PDF و XPS مفید است. قلم‌های پیش‌فرض از طریق `LoadOptions` قبل از بارگذاری ارائه پیکربندی می‌شوند.

`setDefaultRegularFont` قلم پیش‌فرض برای متن عادی را تعریف می‌کند، در حالی که `setDefaultAsianFont` قلم پیش‌فرض برای متن آسیایی را تعریف می‌کند. پس از تنظیم این گزینه‌ها، ارائه می‌تواند بارگذاری و با استفاده از قلم‌های مشخص شده رندر شود.

## **استفاده از قلم‌های پیش‌فرض برای رندر کردن یک ارائه**
Aspose.Slides به شما اجازه می‌دهد قلم پیش‌فرض را برای رندر کردن ارائه به PDF، XPS یا تصویرهای کوچک تنظیم کنید. این مقاله نشان می‌دهد چگونه قلم‌های DefaultRegularFont و DefaultAsianFont را به عنوان قلم‌های پیش‌فرض تعریف کنید. لطفاً مراحل زیر را برای بارگذاری قلم‌ها از دایرکتوری‌های خارجی با استفاده از Aspose.Slides برای Android از طریق API جاوا دنبال کنید:

1. یک نمونه از [LoadOptions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/LoadOptions) ایجاد کنید.
2. [Set the DefaultRegularFont](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/LoadOptions#setDefaultRegularFont-java.lang.String-) را به قلم دلخواه خود تنظیم کنید. در مثال زیر، من از Wingdings استفاده کرده‌ام.
3. [Set the DefaultAsianFont](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/LoadOptions#setDefaultAsianFont-java.lang.String-) را به قلم دلخواه خود تنظیم کنید. در نمونه زیر من از Wingdings استفاده کرده‌ام.
4. ارائه را با استفاده از Presentation و تنظیم گزینه‌های بارگذاری بارگذاری کنید.
5. حالا، تصویر کوچک اسلاید، PDF و XPS را تولید کنید تا نتایج را بررسی کنید.

پیاده‌سازی موارد فوق در زیر آورده شده است.

```java
// از گزینه‌های بارگذاری برای تعریف قلم‌های پیش‌فرض معمولی و آسیایی استفاده کنید
LoadOptions loadOptions = new LoadOptions(LoadFormat.Auto);
loadOptions.setDefaultRegularFont("Wingdings");
loadOptions.setDefaultAsianFont("Wingdings");

// ارائه را بارگذاری کنید
Presentation pres = new Presentation("DefaultFonts.pptx", loadOptions);
try {
    // تصویر کوچک اسلاید را تولید کنید
    IImage slideImage = pres.getSlides().get_Item(0).getImage(1, 1);
    try {
         // تصویر را روی دیسک ذخیره کنید.
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }

    // تولید PDF
    pres.save("output_out.pdf", SaveFormat.Pdf);

    // تولید XPS
    pres.save("output_out.xps", SaveFormat.Xps);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **سؤال‌های متداول**

**دقیقاً DefaultRegularFont و DefaultAsianFont چه تاثیری دارند — فقط در خروجی یا همچنین بر روی تصویرهای کوچک، PDF، XPS، HTML و SVG?**

آنها در خط لوله رندر برای تمام خروجی‌های پشتیبانی‌شده شرکت می‌کنند. این شامل تصویرهای کوچک اسلاید، [PDF](/slides/fa/androidjava/convert-powerpoint-to-pdf/)، [XPS](/slides/fa/androidjava/convert-powerpoint-to-xps/)، [raster images](/slides/fa/androidjava/convert-powerpoint-to-png/)، [HTML](/slides/fa/androidjava/convert-powerpoint-to-html/) و [SVG](/slides/fa/androidjava/render-a-slide-as-an-svg-image/) می‌شود، زیرا Aspose.Slides از همان منطق چیدمان و حل گلیف در این هدف‌ها استفاده می‌کند.

**آیا قلم‌های پیش‌فرض زمانی که فقط یک فایل PPTX را می‌خوانید و ذخیره می‌کنید بدون هیچ رندری اعمال می‌شوند؟**

خیر. قلم‌های پیش‌فرض زمانی مهم هستند که متن باید اندازه‌گیری و رسم شود. یک باز‑ذخیره ساده از ارائه، رخدادهای قلم ذخیره‌شده یا ساختار فایل را تغییر نمی‌دهد. قلم‌های پیش‌فرض در عملیات‌هایی که متن را رندر یا بازآرایش می‌کنند، به کار می‌آیند.

**اگر پوشه‌های قلم خودم را اضافه کنم یا قلم‌ها را از حافظه فراهم کنم، آیا در انتخاب قلم‌های پیش‌فرض در نظر گرفته می‌شوند؟**

بله. [Custom font sources](/slides/fa/androidjava/custom-font/) فهرست خانواده‌ها و گلیف‌های در دسترس را که موتور می‌تواند استفاده کند گسترش می‌دهد. قلم‌های پیش‌فرض و هر [fallback rules](/slides/fa/androidjava/fallback-font/) ابتدا نسبت به این منابع حل می‌شوند و پوشش قابل اعتمادتری در سرورها و کانتینرها فراهم می‌کنند.

**آیا قلم‌های پیش‌فرض معیارهای متنی (کرنینگ، پیشروی) و در نتیجه شکست خطوط و بسته‌بندی را تحت تأثیر قرار می‌دهند؟**

بله. تغییر قلم معیارهای گلیف را تغییر می‌دهد و می‌تواند شکست خطوط، بسته‌بندی و صفحه‌بندی را در حین رندر تغییر دهد. برای پایداری چیدمان، [embed the original fonts](/slides/fa/androidjava/embedded-font/) یا خانواده‌های پیش‌فرض و fallback متریکاً سازگار را انتخاب کنید.

**آیا تنظیم قلم‌های پیش‌فرض وقتی تمام قلم‌های استفاده شده در ارائه به صورت جاسازی شده هستند، معنایی دارد؟**

اغلب لازم نیست، زیرا [embedded fonts](/slides/fa/androidjava/embedded-font/) پیشاپیش ظاهر یکسانی را تضمین می‌کنند. قلم‌های پیش‌فرض همچنان به عنوان یک شبکه ایمنی برای کاراکترهایی که توسط زیرمجموعه جاسازی‌شده پوشش داده نشده‌اند یا زمانی که فایل متن‌های جاسازی‌شده و غیرجاسازی‌شده را ترکیب می‌کند، مفید هستند.