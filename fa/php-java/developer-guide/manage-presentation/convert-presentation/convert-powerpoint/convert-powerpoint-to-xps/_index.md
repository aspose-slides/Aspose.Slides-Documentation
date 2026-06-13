---
title: تبدیل ارائه‌های PowerPoint به XPS در PHP
linktitle: PowerPoint به XPS
type: docs
weight: 70
url: /fa/php-java/convert-powerpoint-to-xps/
keywords:
- تبدیل PowerPoint
- تبدیل ارائه
- تبدیل اسلاید
- تبدیل PPT
- تبدیل PPTX
- PowerPoint به XPS
- ارائه به XPS
- اسلاید به XPS
- PPT به XPS
- PPTX به XPS
- ذخیره PPT به عنوان XPS
- ذخیره PPTX به عنوان XPS
- صادرات PPT به XPS
- صادرات PPTX به XPS
- PowerPoint
- ارائه
- PHP
- Aspose.Slides
description: "PowerPoint PPT/PPTX را به XPS با کیفیت بالا و مستقل از پلتفرم تبدیل کنید با استفاده از Aspose.Slides برای PHP از طریق Java. راهنمای گام به گام و کد نمونه را دریافت کنید."
---
## **نمای کلی**

Aspose.Slides به شما امکان تبدیل ارائه‌های PowerPoint به XPS را می‌دهد با ذخیره ‌سازی فایل PPT یا PPTX در قالب XPS. این مقاله توضیح می‌دهد که چه زمانی قالب XPS می‌تواند مفید باشد و نحوه انجام تبدیل را با Aspose.Slides با استفاده از تنظیمات پیش‌فرض یا تنظیمات سفارشی [XpsOptions](https://reference.aspose.com/slides/fa/php-java/aspose.slides/xpsoptions/) نشان می‌دهد.

## **درباره XPS**
مایکروسافت [XPS](https://docs.fileformat.com/page-description-language/xps/) را به عنوان جایگزینی برای [PDF](https://docs.fileformat.com/pdf/) توسعه داد. این امکان را می‌دهد تا محتوا را با خروجی یک فایل بسیار مشابه PDF چاپ کنید. قالب XPS بر پایه XML است. چیدمان یا ساختار یک فایل XPS در تمام سیستم‌عامل‌ها و چاپگرها یکسان می‌ماند. 

## **چه زمانی از قالب XPS مایکروسافت استفاده کنیم**

{{% alert color="primary" %}} 

برای مشاهده نحوه تبدیل ارائه PPT یا PPTX به قالب XPS توسط Aspose.Slides، می‌توانید [این برنامه رایگان تبدیل آنلاین](https://products.aspose.app/slides/fa/conversion) را بررسی کنید. 

{{% /alert %}} 

اگر می‌خواهید هزینه‌های ذخیره‌سازی را کاهش دهید، می‌توانید ارائه Microsoft PowerPoint خود را به قالب XPS تبدیل کنید. به این ترتیب، ذخیره‌سازی، به‌اشتراک‌گذاری و چاپ اسناد برای شما آسان‌تر خواهد شد. 

مایکروسافت پشتیبانی قوی از XPS را در ویندوز (حتی در ویندوز 10) ادامه داده است، بنابراین ممکن است بخواهید فایل‌ها را به این قالب ذخیره کنید. اگر با ویندوز 8.1، ویندوز 8، ویندوز 7 و ویندوز ویستای کار می‌کنید، XPS ممکن است گزینه بهترین برای برخی عملیات باشد. 

- **Windows 8** از فرمت OXPS (Open XPS) برای فایل‌های XPS استفاده می‌کند. OXPS نسخه‌ای استاندارد شده از فرمت اصلی XPS است. ویندوز 8 پشتیبانی بهتری از فایل‌های XPS نسبت به فایل‌های PDF ارائه می‌دهد. 
  - **XPS:** مشاهده‌گر/خواننده XPS داخلی و قابلیت چاپ به XPS در دسترس است. 
  - **PDF:** خواننده PDF موجود است اما قابلیت چاپ به PDF موجود نیست. 

- **Windows 7 و Windows Vista** از فرمت اصلی XPS استفاده می‌کنند. این سیستم‌عامل‌ها نیز پشتیبانی بهتری از فایل‌های XPS نسبت به PDF دارند. 
  - **XPS:** مشاهده‌گر XPS داخلی و قابلیت چاپ به XPS در دسترس است. 
  - **PDF:** هیچ خواننده PDF ای وجود ندارد. هیچ قابلیت چاپ به PDF ای نیست. 

|<p>**ورودی PPT(X):</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)</p>|<p>**خروجی XPS:</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)</p>|
| :- | :- |

مایکروسافت در نهایت پشتیبانی از عملیات چاپ در PDF را از طریق ویژگی Print to PDF در ویندوز 10 پیاده‌سازی کرد. پیش از این، کاربران انتظار داشتند اسناد را از طریق قالب XPS چاپ کنند. 

## **تبدیل XPS با Aspose.Slides**

در [**Aspose.Slides**](https://products.aspose.com/slides/fa/php-java/) برای جاوا، می‌توانید از متد [**Save**](https://reference.aspose.com/slides/fa/php-java/aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) که توسط کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/Presentation) ارائه می‌شود، برای تبدیل کل ارائه به یک سند XPS استفاده کنید.

هنگام تبدیل یک ارائه به XPS، باید ارائه را با یکی از این تنظیمات ذخیره کنید:
- تنظیمات پیش‌فرض (بدون [**XPSOptions**](https://reference.aspose.com/slides/fa/php-java/aspose.slides/xpsoptions))
- تنظیمات سفارشی (با [**XPSOptions**](https://reference.aspose.com/slides/fa/php-java/aspose.slides/xpsoptions))

### **تبدیل ارائه‌ها به XPS با تنظیمات پیش‌فرض**

این کد نمونه نشان می‌دهد که چگونه یک ارائه را به سند XPS با استفاده از تنظیمات استاندارد تبدیل کنید:

```php
  # یک شی Presentation ایجاد کنید که نمایانگر یک فایل ارائه است
  $pres = new Presentation("Convert_XPS.pptx");
  try {
    # ارائه را به سند XPS ذخیره کنید
    $pres->save("XPS_Output_Without_XPSOption.xps", SaveFormat::Xps);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **تبدیل ارائه‌ها به XPS با تنظیمات سفارشی**

این کد نمونه نشان می‌دهد که چگونه یک ارائه را به سند XPS با استفاده از تنظیمات سفارشی تبدیل کنید:

```php
  # یک شی Presentation ایجاد کنید که نمایانگر یک فایل ارائه است
  $pres = new Presentation("Convert_XPS_Options.pptx");
  try {
    # یک شیء TiffOptions ایجاد کنید
    $options = new XpsOptions();
    # متافایل‌ها را به عنوان PNG ذخیره کنید
    $options->setSaveMetafilesAsPng(true);
    # ارائه را به سند XPS ذخیره کنید
    $pres->save("XPS_Output_With_Options.xps", SaveFormat::Xps, $options);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **سؤالات متداول**

**آیا می‌توانم XPS را به‌جای یک فایل در یک جریان (stream) ذخیره کنم؟**

بله—Aspose.Slides به شما امکان خروجی مستقیم به یک جریان را می‌دهد، که برای APIهای وب، خط لوله‌های سمت سرور، یا هر سناریویی که می‌خواهید XPS را بدون دست‌کاری سیستم فایل ارسال کنید، ایده‌آل است.

**آیا اسلایدهای مخفی به XPS منتقل می‌شوند و می‌توانم آن‌ها را حذف کنم؟**

به‌طور پیش‌فرض، تنها اسلایدهای معمولی (قابل مشاهده) رندر می‌شوند. می‌توانید با استفاده از [تنظیمات خروجی](https://reference.aspose.com/slides/fa/php-java/aspose.slides/xpsoptions/) و [شامل یا حذف اسلایدهای مخفی](https://reference.aspose.com/slides/fa/php-java/aspose.slides/xpsoptions/setshowhiddenslides/) قبل از ذخیره به XPS، اطمینان حاصل کنید که خروجی دقیقاً شامل صفحاتی باشد که می‌خواهید.