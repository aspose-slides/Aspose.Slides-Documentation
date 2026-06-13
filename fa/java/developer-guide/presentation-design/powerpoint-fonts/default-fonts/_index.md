---
title: مشخص کردن قلم‌های پیش‌فرض ارائه در Java
linktitle: قلم پیش‌فرض
type: docs
weight: 30
url: /fa/java/default-font/
keywords:
- قلم پیش‌فرض
- قلم عادی
- قلم معمولی
- قلم آسیایی
- صادرات PDF
- صادرات XPS
- صادرات تصویر
- PowerPoint
- OpenDocument
- ارائه
- Java
- Aspose.Slides
description: "قلم‌های پیش‌فرض را در Aspose.Slides برای Java تنظیم کنید تا تبدیل صحیح PowerPoint (PPT، PPTX) و OpenDocument (ODP) به PDF، XPS و تصویرها تضمین شود."
---
## **بررسی کلی**

Aspose.Slides به شما اجازه می‌دهد قلم‌های پیش‌فرضی را که هنگام رندر ارائه استفاده می‌شوند، مشخص کنید. این هنگام تولید تصویرهای کوچک اسلایدها یا صادرات ارائه به فرمت‌هایی مانند PDF و XPS مفید است. قلم‌های پیش‌فرض از طریق `LoadOptions` پیش از بارگذاری ارائه پیکربندی می‌شوند.

متد `setDefaultRegularFont` قلم پیش‌فرض برای متن معمولی را تعریف می‌کند، در حالی که `setDefaultAsianFont` قلم پیش‌فرض برای متن آسیایی را تعریف می‌کند. پس از تنظیم این گزینه‌ها، می‌توان ارائه را بارگذاری و با استفاده از قلم‌های مشخص‌شده رندر کرد.

## **استفاده از قلم‌های پیش‌فرض برای رندر یک ارائه**

Aspose.Slides به شما امکان تنظیم قلم پیش‌فرض برای رندر ارائه به PDF، XPS یا تصویرهای کوچک را می‌دهد. این مقاله نشان می‌دهد چگونه DefaultRegular Font و DefaultAsian Font را به عنوان قلم‌های پیش‌فرض تعریف کنید. لطفاً مراحل زیر را برای بارگذاری قلم‌ها از مسیرهای خارجی با استفاده از Aspose.Slides for Java API دنبال کنید:

1. یک نمونه از [LoadOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/LoadOptions) ایجاد کنید.
2. [Set the DefaultRegularFont](https://reference.aspose.com/slides/fa/java/com.aspose.slides/LoadOptions#setDefaultRegularFont-java.lang.String-) را به قلم موردنظر خود تنظیم کنید. در مثال زیر، من از Wingdings استفاده کرده‌ام.
3. [Set the DefaultAsianFont](https://reference.aspose.com/slides/fa/java/com.aspose.slides/LoadOptions#setDefaultAsianFont-java.lang.String-) را به قلم موردنظر خود تنظیم کنید. من در نمونه زیر از Wingdings استفاده کرده‌ام.
4. ارائه را با استفاده از Presentation و تنظیم گزینه‌های بارگذاری بارگذاری کنید.
5. اکنون، تصویر کوچک اسلاید، PDF و XPS را تولید کنید تا نتایج را بررسی کنید.

اجرای موارد فوق در زیر آورده شده است.

```java
// از گزینه‌های بارگذاری برای تعریف قلم‌های پیش‌فرض معمولی و آسیایی استفاده کنید
LoadOptions loadOptions = new LoadOptions(LoadFormat.Auto);
loadOptions.setDefaultRegularFont("Wingdings");
loadOptions.setDefaultAsianFont("Wingdings");

// بارگذاری ارائه
Presentation pres = new Presentation("DefaultFonts.pptx", loadOptions);
try {
    // ایجاد تصویر کوچک اسلاید
    IImage slideImage = pres.getSlides().get_Item(0).getImage(1, 1);
    try {
         // ذخیره تصویر بر روی دیسک.
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }

    // ایجاد PDF
    pres.save("output_out.pdf", SaveFormat.Pdf);

    // ایجاد XPS
    pres.save("output_out.xps", SaveFormat.Xps);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **سوالات متداول**

**دقیقاً DefaultRegularFont و DefaultAsianFont چه چیزی را تحت تأثیر قرار می‌دهند — فقط صادرات یا همچنین تصویرهای کوچک، PDF، XPS، HTML و SVG؟**

آنها در خط لوله رندر برای تمام خروجی‌های پشتیبانی‌شده شرکت می‌کنند. این شامل تصویرهای کوچک اسلاید، [PDF](/slides/fa/java/convert-powerpoint-to-pdf/)، [XPS](/slides/fa/java/convert-powerpoint-to-xps/)، [raster images](/slides/fa/java/convert-powerpoint-to-png/)، [HTML](/slides/fa/java/convert-powerpoint-to-html/)، و [SVG](/slides/fa/java/render-a-slide-as-an-svg-image/) هستند، زیرا Aspose.Slides از یک منطق چیدمان و حل گلیف یکسان برای این هدف‌ها استفاده می‌کند.

**آیا قلم‌های پیش‌فرض هنگام صرفاً خواندن و ذخیره‌سازی یک فایل PPTX بدون هیچ رندری اعمال می‌شوند؟**

خیر. قلم‌های پیش‌فرض زمانی مهم می‌شوند که متن باید اندازه‌گیری و رسم شود. یک باز‑ذخیره ساده یک ارائه، اجرای‌های قلم ذخیره‌شده یا ساختار فایل را تغییر نمی‌دهد. قلم‌های پیش‌فرض در عملیات‌هایی که متن را رندر یا بازآرایی می‌کنند، به کار می‌روند.

**اگر پوشه‌های قلم خودم را اضافه کنم یا قلم‌ها را از حافظه تامین کنم، آیا در انتخاب قلم‌های پیش‌فرض در نظر گرفته می‌شوند؟**

بله. [Custom font sources](/slides/fa/java/custom-font/) فهرست خانواده‌ها و گلیف‌های در دسترس که موتور می‌تواند استفاده کند را گسترش می‌دهند. قلم‌های پیش‌فرض و هر [fallback rules](/slides/fa/java/fallback-font/) ابتدا در برابر این منابع حل می‌شوند، که پوشش قابل اطمینان‌تری روی سرور‌ها و در کانتینرها فراهم می‌آورد.

**آیا قلم‌های پیش‌فرض بر معیارهای متنی (کرنینگ، پیشرفت‌ها) و در نتیجه شکست خطوط و بسته‌بندی تأثیر می‌گذارند؟**

بله. تغییر قلم معیارهای گلیف را تغییر می‌دهد و می‌تواند شکست خطوط، بسته‌بندی و صفحه‌بندی را در حین رندر تغییر دهد. برای پایداری چیدمان، [embed the original fonts](/slides/fa/java/embedded-font/) یا خانواده‌های پیش‌فرض و جایگزین متریکاً سازگار را انتخاب کنید.

**آیا تنظیم قلم‌های پیش‌فرض زمانی که همه قلم‌های استفاده‌شده در ارائه جاسازی‌شده‌اند، معنایی دارد؟**

اغلب لازم نیست، زیرا [embedded fonts](/slides/fa/java/embedded-font/) از پیش ظاهر یکسان را تضمین می‌کنند. قلم‌های پیش‌فرض همچنان به عنوان یک شبکه ایمنی برای کاراکترهایی که توسط زیرمجموعه جاسازی‌شده پوشش داده نشده‌اند یا زمانی که فایلی متن ترکیبی از متن‌های جاسازی‌شده و غیرجاسازی دارد، مفید هستند.