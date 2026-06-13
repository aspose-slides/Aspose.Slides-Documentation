---
title: تعیین فونت‌های پیش‌فرض ارائه در JavaScript
linktitle: فونت پیش‌فرض
type: docs
weight: 30
url: /fa/nodejs-java/default-font/
keywords:
- فونت پیش‌فرض
- فونت عادی
- فونت معمولی
- فونت آسیایی
- خروجی PDF
- خروجی XPS
- خروجی تصویر
- PowerPoint
- OpenDocument
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "فونت‌های پیش‌فرض را در Aspose.Slides برای Node.js از طریق Java تنظیم کنید تا تبدیل صحیح PowerPoint (PPT، PPTX) و OpenDocument (ODP) به PDF، XPS و تصویرها تضمین شود."
---
## **بررسی کلی**

Aspose.Slides به شما امکان می‌دهد فونت‌های پیش‌فرضی را که هنگام رندر ارائه استفاده می‌شوند، مشخص کنید. این برای تولید تصویر بندانگشتی اسلایدها یا صادر کردن ارائه به قالب‌هایی مانند PDF و XPS مفید است. فونت‌های پیش‌فرض از طریق `LoadOptions` قبل از بارگذاری ارائه پیکربندی می‌شوند.

`متد setDefaultRegularFont` فونت پیش‌فرض برای متن عادي را تعریف می‌کند، در حالی که `setDefaultAsianFont` فونت پیش‌فرض برای متن آسیایی را تعیین می‌کند. پس از تنظیم این گزینه‌ها، می‌توان ارائه را بارگذاری و با استفاده از فونت‌های مشخص رندر کرد.

## **استفاده از فونت‌های پیش‌فرض برای رندر ارائه**
Aspose.Slides به شما اجازه می‌دهد فونت پیش‌فرض را برای رندر ارائه به PDF، XPS یا تصویر بندانگشتی تنظیم کنید. این مقاله نشان می‌دهد چگونه DefaultRegularFont و DefaultAsianFont را به عنوان فونت‌های پیش‌فرض تعریف کنید. لطفاً مراحل زیر را برای بارگذاری فونت‌ها از پوشه‌های خارجی با استفاده از Aspose.Slides برای Node.js از طریق API جاوا دنبال کنید:

1. یک نمونه از [LoadOptions](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/LoadOptions) ایجاد کنید.
2. [Set the DefaultRegularFont](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/LoadOptions#setDefaultRegularFont-java.lang.String-) را به فونت مورد نظر خود تنظیم کنید. در مثال زیر، من از Wingdings استفاده کرده‌ام.
3. [Set the DefaultAsianFont](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/LoadOptions#setDefaultAsianFont-java.lang.String-) را به فونت مورد نظر خود تنظیم کنید. در نمونه زیر من از Wingdings استفاده کرده‌ام.
4. ارائه را با استفاده از Presentation و تنظیم گزینه‌های بارگذاری بارگذاری کنید.
5. حال، تصویر بندانگشتی اسلاید، PDF و XPS را تولید کنید تا نتایج را بررسی کنید.

پیاده‌سازی موارد فوق در زیر آورده شده است.

```javascript
// از گزینه‌های بارگذاری برای تعریف فونت‌های پیش‌فرض عادی و آسیایی استفاده کنید
var loadOptions = new aspose.slides.LoadOptions(aspose.slides.LoadFormat.Auto);
loadOptions.setDefaultRegularFont("Wingdings");
loadOptions.setDefaultAsianFont("Wingdings");
// ارائه را بارگذاری کنید
var pres = new aspose.slides.Presentation("DefaultFonts.pptx", loadOptions);
try {
    // تصویر بندانگشتی اسلاید را تولید کنید
    var slideImage = pres.getSlides().get_Item(0).getImage(1, 1);
    try {
        // تصویر را بر روی دیسک ذخیره کنید.
        slideImage.save("output.png", aspose.slides.ImageFormat.Png);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
    // PDF را تولید کنید
    pres.save("output_out.pdf", aspose.slides.SaveFormat.Pdf);
    // XPS را تولید کنید
    pres.save("output_out.xps", aspose.slides.SaveFormat.Xps);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **سوالات متداول**

**فونت‌های DefaultRegularFont و DefaultAsianFont دقیقاً چه چیزی را تحت تاثیر قرار می‌دهند — فقط خروجی یا همچنین تصویرهای بندانگشتی، PDF، XPS، HTML و SVG؟**  
آن‌ها در خط لوله رندر برای تمام خروجی‌های پشتیبانی‌شده شرکت می‌کنند. این شامل تصویرهای بندانگشتی اسلاید، [PDF](/slides/fa/nodejs-java/convert-powerpoint-to-pdf/)، [XPS](/slides/fa/nodejs-java/convert-powerpoint-to-xps/)، [raster images](/slides/fa/nodejs-java/convert-powerpoint-to-png/), [HTML](/slides/fa/nodejs-java/convert-powerpoint-to-html/), و [SVG](/slides/fa/nodejs-java/render-a-slide-as-an-svg-image/) می‌شود، زیرا Aspose.Slides از منطق یکسان چیدمان و حل گلیف در این هدف‌ها استفاده می‌کند.

**آیا فونت‌های پیش‌فرض هنگام فقط خواندن و ذخیرهٔ یک PPTX بدون هیچ رندر دیگری اعمال می‌شوند؟**  
خیر. فونت‌های پیش‌فرض زمانی اهمیت دارند که متن باید اندازه‌گیری و رسم شود. صرفاً باز‑باز کردن و ذخیرهٔ یک ارائه، فونت‌های ذخیره‌شده یا ساختار فایل را تغییر نمی‌دهد. فونت‌های پیش‌فرض در عملیات‌هایی که متن را رندر یا باز‌چیدمان می‌کنند، به کار می‌روند.

**اگر پوشه‌های فونت خودم را اضافه کنم یا فونت‌ها را از حافظه تامین کنم، آیا آن‌ها هنگام انتخاب فونت‌های پیش‌فرض در نظر گرفته می‌شوند؟**  
بله. [Custom font sources](/slides/fa/nodejs-java/custom-font/) فهرست خانواده‌ها و گلیف‌های موجود را که موتور می‌تواند استفاده کند، گسترش می‌دهد. فونت‌های پیش‌فرض و هر [fallback rules](/slides/fa/nodejs-java/fallback-font/) ابتدا در برابر این منابع حل می‌شوند و پوشش قابل اعتمادتری روی سرورها و در کانتینرها فراهم می‌آورند.

**آیا فونت‌های پیش‌فرض بر معیارهای متن (کرنینگ، پیشروی) و در نتیجه شکست خط و پیچش تأثیر می‌گذارند؟**  
بله. تغییر فونت معیارهای گلیف را تغییر می‌دهد و می‌تواند شکست‌های خط، پیچش و صفحه‌بندی را در هنگام رندر تغییر دهد. برای پایداری چیدمان، [embed the original fonts](/slides/fa/nodejs-java/embedded-font/) یا خانواده‌های پیش‌فرض و fallback متریکally سازگار را انتخاب کنید.

**آیا تنظیم فونت‌های پیش‌فرض مفید است اگر تمام فونت‌های استفاده‌شده در ارائه تعبیه شده باشند؟**  
اغلب لازم نیست، زیرا [embedded fonts](/slides/fa/nodejs-java/embedded-font/) پیش‌اپی ظاهر سازگار را تضمین می‌کنند. فونت‌های پیش‌فرض همچنان به عنوان یک شبکه ایمنی برای کاراکترهایی که توسط زیرمجموعهٔ تعبیه‌شده پوشش داده نشده‌اند یا زمانی که فایلی متن تعبیه‌شده و غیرتعبیف‌شده را ترکیب می‌کند، مفید هستند.