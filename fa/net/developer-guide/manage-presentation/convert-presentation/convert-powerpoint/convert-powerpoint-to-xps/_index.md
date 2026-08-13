---
title: تبدیل ارائه‌های PowerPoint به XPS در .NET
linktitle: PowerPoint به XPS
type: docs
weight: 70
url: /fa/net/convert-powerpoint-to-xps/
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
- ذخیره PPT به‌صورت XPS
- ذخیره PPTX به‌صورت XPS
- صادر کردن PPT به XPS
- صادر کردن PPTX به XPS
- PowerPoint
- ارائه
- .NET
- C#
- Aspose.Slides
description: "تبدیل PowerPoint PPT/PPTX به XPS با کیفیت بالا و مستقل از پلتفرم در .NET با استفاده از Aspose.Slides. دریافت راهنمای گام به گام و نمونه کد C#."
---
## **بررسی کلی**

Aspose.Slides به شما امکان می‌دهد ارائه‌های PowerPoint را به XPS تبدیل کنید با ذخیره‌سازی فایل PPT یا PPTX در قالب XPS. این مقاله توضیح می‌دهد که چه زمانی قالب XPS مفید است و نحوه انجام تبدیل با Aspose.Slides را با استفاده از تنظیمات پیش‌فرض یا تنظیمات سفارشی [XpsOptions](https://reference.aspose.com/slides/fa/net/aspose.slides.export/xpsoptions/) نشان می‌دهد.

## **درباره XPS**
مایکروسافت [XPS](https://docs.fileformat.com/page-description-language/xps/) را به‌عنوان جایگزینی برای [PDF](https://docs.fileformat.com/pdf/) توسعه داد. این فرمت به شما اجازه می‌دهد محتوا را چاپ کنید و فایلی بسیار شبیه به PDF تولید می‌کند. قالب XPS بر پایه XML است. چیدمان یا ساختار یک فایل XPS در تمام سیستم‌عامل‌ها و چاپگرها یکسان می‌ماند.

## **زمان استفاده از فرمت XPS مایکروسافت**

{{% alert color="info" %}} 

برای دیدن نحوه تبدیل ارائه PPT یا PPTX به قالب XPS توسط Aspose.Slides، می‌توانید به [این برنامه رایگان تبدیل آنلاین](https://products.aspose.app/slides/fa/conversion) مراجعه کنید.

{{% /alert %}} 

اگر می‌خواهید هزینه‌های ذخیره‌سازی را کاهش دهید، می‌توانید ارائه Microsoft PowerPoint خود را به قالب XPS تبدیل کنید. این کار ذخیره، به‌اشتراک‌گذاری و چاپ اسناد را آسان‌تر می‌سازد.

مایکروسافت همچنان پشتیبانی قوی از XPS را در ویندوز (حتی در ویندوز 10) پیاده‌سازی می‌کند، بنابراین ممکن است بخواهید فایل‌ها را در این قالب ذخیره کنید. اگر با ویندوز 8.1، ویندوز 8، ویندوز 7 و ویندوز ویستا کار می‌کنید، XPS می‌تواند گزینهٔ بهتری برای برخی عملیات باشد.

- **Windows 8** از قالب OXPS (Open XPS) برای فایل‌های XPS استفاده می‌کند. OXPS نسخهٔ استاندارد شدهٔ قالب اصلی XPS است. ویندوز 8 پشتیبانی بهتری برای فایل‌های XPS نسبت به فایل‌های PDF دارد. 
  - **XPS:** ویور/خواننده XPS داخلی و قابلیت چاپ به XPS موجود است. 
  - **PDF:** خواننده PDF موجود است اما قابلیت چاپ به PDF وجود ندارد. 

- **Windows 7** و **Windows Vista** از قالب اصلی XPS استفاده می‌کنند. این سیستم‌عامل‌ها نیز پشتیبانی بهتری برای فایل‌های XPS نسبت به PDF دارند. 
  - **XPS:** ویور XPS داخلی و قابلیت چاپ به XPS موجود است. 
  - **PDF:** خواننده PDF وجود ندارد. قابلیت چاپ به PDF وجود ندارد. 

|<p>**ورودی PPT(X):</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**خروجی XPS:</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

مایکروسافت در نهایت پشتیبانی از عملیات چاپ در PDF را از طریق ویژگی Print to PDF در ویندوز 10 پیاده‌سازی کرد. پیش از آن، کاربران انتظار داشتند اسناد را از طریق فرمت XPS چاپ کنند.

## **تبدیل XPS با Aspose.Slides**

در [**Aspose.Slides**](https://products.aspose.com/slides/fa/net/) برای .NET، می‌توانید از متد [**Save**](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/methods/save/index) که توسط کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) ارائه شده استفاده کنید تا کل ارائه را به یک سند XPS تبدیل کنید.

هنگام تبدیل یک ارائه به XPS، باید ارائه را با یکی از این تنظیمات ذخیره کنید:

- تنظیمات پیش‌فرض (بدون [**XPSOptions**](https://reference.aspose.com/slides/fa/net/aspose.slides.export/xpsoptions))
- تنظیمات سفارشی (با [**XPSOptions**](https://reference.aspose.com/slides/fa/net/aspose.slides.export/xpsoptions))

### **تبدیل ارائه‌ها به XPS با تنظیمات پیش‌فرض**

این کد نمونه در C# نشان می‌دهد چگونه یک ارائه را با تنظیمات استاندارد به سند XPS تبدیل کنید:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// ایجاد یک شیء Presentation که نمایانگر یک فایل ارائه است
using (Presentation pres = new Presentation("Convert_XPS.pptx"))
{
    // ذخیره‌سازی ارائه به سند XPS
    pres.Save("XPS_Output_Without_XPSOption_out.xps", SaveFormat.Xps);
}
```

### **تبدیل ارائه‌ها به XPS با تنظیمات سفارشی**
این کد نمونه نشان می‌دهد چگونه یک ارائه را با تنظیمات سفارشی در C# به سند XPS تبدیل کنید:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// ایجاد یک شیء Presentation که نمایانگر یک فایل ارائه است
using (Presentation pres = new Presentation("Convert_XPS_Options.pptx"))
{
    // ایجاد یک شیء از کلاس TiffOptions
    XpsOptions options = new XpsOptions();

    // ذخیره‌سازی متافایل‌ها به‌صورت PNG
    options.SaveMetafilesAsPng = true;

    // ذخیره‌سازی ارائه به سند XPS
    pres.Save("XPS_With_Options_out.xps", SaveFormat.Xps, options);
}
```

## **سوالات متداول**

### آیا می‌توانم XPS را به‌جای یک فایل در یک استریم ذخیره کنم؟

بله—Aspose.Slides به شما اجازه می‌دهد مستقیماً به یک استریم خروجی بدهید، که برای APIهای وب، خطوط پردازش سمت سرور یا هر سناریویی که می‌خواهید XPS را بدون لمس فایل‌سیستم بفرستید، ایده‌آل است.

### آیا اسلایدهای مخفی به XPS منتقل می‌شوند و می‌توانم آنها را حذف کنم؟

به‌طور پیش‌فرض، تنها اسلایدهای عادی (قابل مشاهده) رندر می‌شوند. می‌توانید با استفاده از [تنظیمات خروجی](https://reference.aspose.com/slides/fa/net/aspose.slides.export/xpsoptions/) [اسلایدهای مخفی را شامل یا حذف کنید](https://reference.aspose.com/slides/fa/net/aspose.slides.export/xpsoptions/showhiddenslides/) پیش از ذخیره‌سازی به XPS، تا خروجی دقیقاً شامل صفحاتی باشد که می‌خواهید.