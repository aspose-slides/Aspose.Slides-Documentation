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
- ذخیره PPT به عنوان XPS
- ذخیره PPTX به عنوان XPS
- صادر کردن PPT به XPS
- صادر کردن PPTX به XPS
- PowerPoint
- ارائه
- .NET
- C#
- Aspose.Slides
description: "PowerPoint PPT/PPTX را به XPS با کیفیت بالا و مستقل از پلتفرم در .NET با استفاده از Aspose.Slides تبدیل کنید. راهنمای گام به گام و نمونه کد C# را دریافت کنید."
---
## **بررسی کلی**

Aspose.Slides به شما امکان می‌دهد ارائه‌های PowerPoint را به XPS تبدیل کنید با ذخیره‌سازی فایل PPT یا PPTX در قالب XPS. این مقاله توضیح می‌دهد که چه زمانی قالب XPS مفید است و نشان می‌دهد چگونه می‌توانید تبدیل را با Aspose.Slides با استفاده از تنظیمات پیش‌فرض یا تنظیمات سفارشی [XpsOptions](https://reference.aspose.com/slides/fa/net/aspose.slides.export/xpsoptions/) انجام دهید.

## **درباره XPS**

Microsoft [XPS](https://docs.fileformat.com/page-description-language/xps/) را به عنوان یک جایگزین برای [PDF](https://docs.fileformat.com/pdf/) توسعه داد. این امکان را می‌دهد تا محتوا را با خروجی فایلی بسیار مشابه PDF چاپ کنید. قالب XPS بر پایه XML است. چیدمان یا ساختار یک فایل XPS در تمام سیستم‌عامل‌ها و چاپگرها یکسان می‌ماند.

## **زمان استفاده از قالب XPS مایکروسافت**

{{% alert color="primary" %}} 
برای مشاهده نحوه‌ای که Aspose.Slides ارائه PPT یا PPTX را به قالب XPS تبدیل می‌کند، می‌توانید [این برنامه رایگان تبدیل آنلاین](https://products.aspose.app/slides/fa/conversion) را بررسی کنید. 
{{% /alert %}} 

اگر می‌خواهید هزینه‌های ذخیره‌سازی را کاهش دهید، می‌توانید ارائه Microsoft PowerPoint خود را به قالب XPS تبدیل کنید. به این ترتیب، ذخیره، اشتراک‌گذاری و چاپ اسناد برای شما ساده‌تر خواهد شد.

مایکروسافت به حمایت قوی از XPS در ویندوز (حتی در ویندوز 10) ادامه می‌دهد، بنابراین ممکن است بخواهید فایل‌ها را در این قالب ذخیره کنید. اگر با ویندوز 8.1، ویندوز 8، ویندوز 7 و ویندوز ویستاگر کار می‌کنید، XPS ممکن است برای برخی عملیات بهترین گزینه شما باشد.

- **Windows 8** از قالب OXPS (Open XPS) برای فایل‌های XPS استفاده می‌کند. OXPS نسخه استاندارددهی‌شده‌ای از قالب اصلی XPS است. ویندوز 8 پشتیبانی بهتری از فایل‌های XPS نسبت به فایل‌های PDF ارائه می‌دهد. 
  - **XPS:** نمایشگر/خواننده XPS داخلی و قابلیت چاپ به XPS موجود است. 
  - **PDF:** خواننده PDF موجود است اما قابلیت چاپ به PDF وجود ندارد. 

- **Windows 7** و **Windows Vista** از قالب اصلی XPS استفاده می‌کنند. این سیستم‌عامل‌ها نیز پشتیبانی بهتری از فایل‌های XPS نسبت به PDF دارند. 
  - **XPS:** نمایشگر XPS داخلی و قابلیت چاپ به XPS موجود است. 
  - **PDF:** خواننده PDF وجود ندارد. قابلیت چاپ به PDF نیز وجود ندارد. 

|<p>**ورودی PPT(X):</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**خروجی XPS:</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

در نهایت، مایکروسافت پشتیبانی از عملیات چاپ در PDF را از طریق ویژگی Print to PDF در ویندوز 10 پیاده‌سازی کرد. پیش‌تر، کاربران انتظار داشتند که اسناد را از طریق قالب XPS چاپ کنند.

## **تبدیل XPS با Aspose.Slides**

در [**Aspose.Slides**](https://products.aspose.com/slides/fa/net/) برای .NET، می‌توانید از متد [**Save**](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/methods/save/index) که توسط کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) ارائه می‌شود، برای تبدیل کل ارائه به سند XPS استفاده کنید.

هنگام تبدیل یک ارائه به XPS، باید ارائه را با یکی از این تنظیمات ذخیره کنید:

- تنظیمات پیش‌فرض (بدون [**XPSOptions**](https://reference.aspose.com/slides/fa/net/aspose.slides.export/xpsoptions))
- تنظیمات سفارشی (با [**XPSOptions**](https://reference.aspose.com/slides/fa/net/aspose.slides.export/xpsoptions))

### **تبدیل ارائه‌ها به XPS با تنظیمات پیش‌فرض**

این نمونه کد در C# نشان می‌دهد چگونه یک ارائه را به سند XPS با استفاده از تنظیمات استاندارد تبدیل کنید:

```c#
// یک شیء Presentation که نمایانگر یک فایل ارائه است را ایجاد می‌کند
using (Presentation pres = new Presentation("Convert_XPS.pptx"))
{
    // ذخیره ارائه به سند XPS
    pres.Save("XPS_Output_Without_XPSOption_out.xps", SaveFormat.Xps);
}
```

### **تبدیل ارائه‌ها به XPS با تنظیمات سفارشی**

این نمونه کد نشان می‌دهد چگونه یک ارائه را به سند XPS با استفاده از تنظیمات سفارشی در C# تبدیل کنید:

```c#
// یک شیء Presentation که نمایانگر یک فایل ارائه است را ایجاد می‌کند
using (Presentation pres = new Presentation("Convert_XPS_Options.pptx"))
{
    // یک شیء TiffOptions را ایجاد می‌کند
    XpsOptions options = new XpsOptions();

    // ذخیره MetaFiles به صورت PNG
    options.SaveMetafilesAsPng = true;

    // ذخیره ارائه به سند XPS
    pres.Save("XPS_With_Options_out.xps", SaveFormat.Xps, options);
}
```

## **سوالات متداول**

**آیا می‌توانم XPS را به‌جای فایل، به یک استریم ذخیره کنم؟**

بله—Aspose.Slides امکان صادرات مستقیم به یک استریم را فراهم می‌کند، که برای APIهای وب، خط لوله‌های سمت سرور یا هر سناریویی که می‌خواهید XPS را بدون دست‌کاری سیستم‌فایل ارسال کنید، ایده‌آل است.

**آیا اسلایدهای مخفی به XPS منتقل می‌شوند و می‌توانم آنها را حذف کنم؟**

به‌طور پیش‌فرض، فقط اسلایدهای معمولی (قابل مشاهده) رندر می‌شوند. شما می‌توانید [اسلایدهای مخفی را شامل یا حذف کنید](https://reference.aspose.com/slides/fa/net/aspose.slides.export/xpsoptions/showhiddenslides/) از طریق [تنظیمات خروجی](https://reference.aspose.com/slides/fa/net/aspose.slides.export/xpsoptions/) قبل از ذخیره به XPS، تضمین کنید که خروجی دقیقاً صفحاتی که می‌خواهید شامل شود.