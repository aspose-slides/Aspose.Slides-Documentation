---
title: مشخص کردن فونت‌های پیش‌فرض ارائه در PHP
linktitle: فونت پیش‌فرض
type: docs
weight: 30
url: /fa/php-java/default-font/
keywords:
- فونت پیش‌فرض
- فونت عادی
- فونت معمولی
- فونت آسیایی
- خروجی PDF
- خروجی XPS
- خروجی تصویر
- پاورپوینت
- OpenDocument
- ارائه
- PHP
- Aspose.Slides
description: "تنظیم فونت‌های پیش‌فرض در Aspose.Slides برای PHP از طریق Java جهت اطمینان از تبدیل صحیح PowerPoint (PPT, PPTX) و OpenDocument (ODP) به PDF، XPS و تصاویر."
---
## **نمای کلی**

Aspose.Slides به شما امکان می‌دهد فونت‌های پیش‌فرضی را که هنگام رندر ارائه استفاده می‌شوند، مشخص کنید. این کار هنگام تولید تصویرک‌های اسلاید یا Export ارائه به قالب‌هایی مانند PDF و XPS مفید است. فونت‌های پیش‌فرض از طریق `LoadOptions` قبل از بارگذاری ارائه پیکربندی می‌شوند.

متد `setDefaultRegularFont` فونت پیش‌فرض برای متن عادی را تعریف می‌کند، در حالی که `setDefaultAsianFont` فونت پیش‌فرض برای متن آسیایی را تعیین می‌سازد. پس از تنظیم این گزینه‌ها، می‌توان ارائه را بارگذاری و با استفاده از فونت‌های مشخص‌شده رندر کرد.

## **استفاده از فونت‌های پیش‌فرض برای رندر یک ارائه**
Aspose.Slides به شما اجازه می‌دهد فونت پیش‌فرض را برای رندر ارائه به PDF، XPS یا تصویرک‌ها تنظیم کنید. این مقاله نشان می‌دهد چگونه DefaultRegularFont و DefaultAsianFont را برای استفاده به‌عنوان فونت‌های پیش‌فرض تعریف کنید. لطفاً مراحل زیر را برای بارگذاری فونت‌ها از پوشه‌های خارجی با استفاده از Aspose.Slides برای PHP از طریق Java API دنبال کنید:

1. یک نمونه از [LoadOptions](https://reference.aspose.com/slides/fa/php-java/aspose.slides/LoadOptions) ایجاد کنید.
1. [Set the DefaultRegularFont](https://reference.aspose.com/slides/fa/php-java/aspose.slides/LoadOptions#setDefaultRegularFont-java.lang.String-) را به فونت دلخواه خود تنظیم کنید. در مثال زیر من از Wingdings استفاده کرده‌ام.
1. [Set the DefaultAsianFont](https://reference.aspose.com/slides/fa/php-java/aspose.slides/LoadOptions#setDefaultAsianFont-java.lang.String-) را به فونت دلخواه خود تنظیم کنید. من در نمونه زیر از Wingdings استفاده کرده‌ام.
1. ارائه را با استفاده از Presentation و تنظیم گزینه‌های بارگذاری بارگذاری کنید.
1. در حال حاضر، تصویرک اسلاید، PDF و XPS را تولید کنید تا نتایج را بررسی کنید.

پیاده‌سازی موارد بالا در زیر آورده شده است.

```php
  # استفاده از گزینه‌های بارگذاری برای تعریف فونت‌های پیش‌فرض عادی و آسیایی
  $loadOptions = new LoadOptions(LoadFormat::Auto);
  $loadOptions->setDefaultRegularFont("Wingdings");
  $loadOptions->setDefaultAsianFont("Wingdings");
  # بارگذاری ارائه
  $pres = new Presentation("DefaultFonts.pptx", $loadOptions);
  try {
    # تولید تصویرک اسلاید
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(1, 1);
    try {
      # ذخیره تصویر بر روی دیسک.
      $slideImage->save("output.png", ImageFormat::Png);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
    # تولید PDF
    $pres->save("output_out.pdf", SaveFormat::Pdf);
    # تولید XPS
    $pres->save("output_out.xps", SaveFormat::Xps);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **سوالات متداول**

**دقیقاً DefaultRegularFont و DefaultAsianFont بر چه چیزی تأثیر می‌گذارند—فقط بر خروجی یا همچنین بر تصویرک‌ها، PDF، XPS، HTML و SVG؟**

آنها در مسیر رندر برای همه خروجی‌های پشتیبانی‌شده شرکت می‌کنند. این شامل تصویرک‌های اسلاید، [PDF](/slides/fa/php-java/convert-powerpoint-to-pdf/)، [XPS](/slides/fa/php-java/convert-powerpoint-to-xps/), [تصاویر رستر](/slides/fa/php-java/convert-powerpoint-to-png/), [HTML](/slides/fa/php-java/convert-powerpoint-to-html/), و [SVG](/slides/fa/php-java/render-a-slide-as-an-svg-image/) می‌شود، زیرا Aspose.Slides از همان منطق چیدمان و حل نشان‌گرها در این اهداف استفاده می‌کند.

**آیا فونت‌های پیش‌فرض هنگام فقط خواندن و ذخیره یک PPTX بدون هیچ رندری اعمال می‌شوند؟**

خیر. فونت‌های پیش‌فرض زمانی مهم هستند که متن باید اندازه‌گیری و رسم شود. یک بازکردن‑ذخیره ساده از ارائه، ران‌های فونت ذخیره‌شده یا ساختار فایل را تغییر نمی‌دهد. فونت‌های پیش‌فرض در عملیات‌هایی که متن را رندر یا بازآرایی می‌کند، اثر می‌گذارند.

**اگر پوشه‌های فونت خودم را اضافه کنم یا فونت‌ها را از حافظه‌ فراهم کنم، آیا در انتخاب فونت‌های پیش‌فرض در نظر گرفته می‌شوند؟**

بله. [Custom font sources](/slides/fa/php-java/custom-font/) کاتالوگ خانواده‌ها و نشان‌گرهای موجود که موتور می‌تواند از آن‌ها استفاده کند را گسترش می‌دهند. فونت‌های پیش‌فرض و هر [قواعد fallback](/slides/fa/php-java/fallback-font/) ابتدا در مقابل این منابع حل می‌شوند و پوشش قابل‌اعتمادتری بر روی سرور‌ها و درون‌پوشه‌ها فراهم می‌آورند.

**آیا فونت‌های پیش‌فرض بر معیارهای متن (کرنینگ، پیشروی) و درنتیجه شکست خطوط و بسته‌بندی تأثیر می‌گذارند؟**

بله. تغییر فونت معیارهای نشان‌گرها را تغییر می‌دهد و می‌تواند شکست خطوط، بسته‌بندی و صفحه‌بندی را در حین رندر تغییر دهد. برای پایداری چیدمان، [embed the original fonts](/slides/fa/php-java/embedded-font/) یا خانواده‌های پیش‌فرض و fallback سازگار از نظر معیارها را انتخاب کنید.

**آیا تنظیم فونت‌های پیش‌فرض هنگامی که تمام فونت‌های استفاده‌شده در ارائه جاسازی شده‌اند، معنایی دارد؟**

اغلب لازم نیست، زیرا [embedded fonts](/slides/fa/php-java/embedded-font/) از ظاهر یکنواخت اطمینان می‌دهند. فونت‌های پیش‌فرض همچنان به عنوان یک شبکه ایمنی برای کاراکترهای پوشش‌داده‌نشده توسط زیرمجموعه جاسازی‌شده یا زمانی که فایلی ترکیبی از متن‌های جاسازی‌شده و غیرجاسازی‌شده باشد، مفید هستند.