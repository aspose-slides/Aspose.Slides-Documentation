---
title: تبدیل ارائه‌های PowerPoint به XPS در JavaScript
linktitle: PowerPoint به XPS
type: docs
weight: 70
url: /fa/nodejs-java/convert-powerpoint-to-xps/
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
- خروجی PPT به XPS
- خروجی PPTX به XPS
- PowerPoint
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "PowerPoint PPT/PPTX را به XPS با کیفیت بالا و مستقل از پلتفرم در JavaScript با استفاده از Aspose.Slides برای Node.js تبدیل کنید. راهنمای گام به گام و کد نمونه را دریافت کنید."
---
## **نمایش کلی**

Aspose.Slides به شما امکان می‌دهد ارائه‌های PowerPoint را به XPS تبدیل کنید با ذخیره‌سازی فایل PPT یا PPTX در قالب XPS. این مقاله توضیح می‌دهد که چه زمانی قالب XPS مفید است و نشان می‌دهد چگونه می‌توانید تبدیل را با Aspose.Slides با استفاده از تنظیمات پیش‌فرض یا تنظیمات سفارشی [XpsOptions](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/xpsoptions/) انجام دهید.

## **درباره XPS**

Microsoft [XPS](https://docs.fileformat.com/page-description-language/xps/) را به عنوان یک جایگزین برای [PDF](https://docs.fileformat.com/pdf/) توسعه داد. این فرمت به شما اجازه می‌دهد محتوا را چاپ کنید با تولید فایلی که بسیار شبیه PDF است. قالب XPS بر پایه XML است. چیدمان یا ساختار یک فایل XPS در تمام سیستم‌عامل‌ها و چاپگرها یکسان می‌ماند.

## **زمان استفاده از قالب XPS مایکروسافت**

{{% alert color="primary" %}} 

برای مشاهده نحوه تبدیل ارائه PPT یا PPTX به قالب XPS توسط Aspose.Slides، می‌توانید برنامه آنلاین رایگان تبدیل را در [این برنامه آنلاین رایگان](https://products.aspose.app/slides/fa/conversion) بررسی کنید. 

{{% /alert %}} 

اگر می‌خواهید هزینه‌های ذخیره‌سازی را کاهش دهید، می‌توانید ارائه Microsoft PowerPoint خود را به قالب XPS تبدیل کنید. این کار ذخیره‌سازی، اشتراک‌گذاری و چاپ اسناد را آسان‌تر می‌سازد.

Microsoft پشتیبانی قوی از XPS را در ویندوز (حتی در Windows 10) ادامه می‌دهد، بنابراین ممکن است بخواهید فایل‌ها را در این قالب ذخیره کنید. اگر با Windows 8.1، Windows 8، Windows 7 و Windows Vista کار می‌کنید، XPS ممکن است بهترین گزینه برای برخی عملیات باشد.

- **Windows 8** از قالب OXPS (Open XPS) برای فایل‌های XPS استفاده می‌کند. OXPS یک نسخه استاندارد شده از قالب اصلی XPS است. Windows 8 پشتیبانی بهتری برای فایل‌های XPS نسبت به PDF ارائه می‌دهد. 
  - **XPS:** قابلیت مشاهده/خواندن داخلی XPS و چاپ به XPS موجود است. 
  - **PDF:** خواننده PDF موجود است اما ویژگی چاپ به PDF وجود ندارد. 

- **Windows 7** و **Windows Vista** از قالب اصلی XPS استفاده می‌کنند. این سیستم‌عامل‌ها نیز پشتیبانی بهتری برای فایل‌های XPS نسبت به PDF دارند. 
  - **XPS:** قابلیت مشاهده داخلی XPS و چاپ به XPS موجود است. 
  - **PDF:** خواننده PDF وجود ندارد. ویژگی چاپ به PDF وجود ندارد. 

|<p>**ورودی PPT(X):**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**خروجی XPS:**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

Microsoft در نهایت پشتیبانی از عملیات چاپ را در PDF از طریق ویژگی Print to PDF در Windows 10 پیاده‌سازی کرد. پیش‌تر، کاربران انتظار داشتند اسناد را از طریق قالب XPS چاپ کنند. 

## **تبدیل XPS با Aspose.Slides**

در [**Aspose.Slides for Node.js via Java**](https://products.aspose.com/slides/fa/nodejs-java/)، می‌توانید از متد [**save**](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-aspose.slides.ISaveOptions-) که توسط کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation) فراهم شده استفاده کنید تا کل ارائه را به یک سند XPS تبدیل کنید.

هنگام تبدیل یک ارائه به XPS، باید ارائه را با یکی از این تنظیمات ذخیره کنید:

- تنظیمات پیش‌فرض (بدون [**XPSOptions**](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/xpsoptions))
- تنظیمات سفارشی (با [**XPSOptions**](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/xpsoptions))

### **تبدیل ارائه‌ها به XPS با استفاده از تنظیمات پیش‌فرض**

این نمونه کد در JavaScript نشان می‌دهد چگونه یک ارائه را با تنظیمات استاندارد به سند XPS تبدیل کنید:

```javascript
// یک شیء Presentation ایجاد می‌کند که نمایانگر یک فایل ارائه است
var pres = new aspose.slides.Presentation("Convert_XPS.pptx");
try {
    // ذخیره ارائه به سند XPS
    pres.save("XPS_Output_Without_XPSOption.xps", aspose.slides.SaveFormat.Xps);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **تبدیل ارائه‌ها به XPS با استفاده از تنظیمات سفارشی**

این نمونه کد نشان می‌دهد چگونه یک ارائه را با تنظیمات سفارشی در JavaScript به سند XPS تبدیل کنید:

```javascript
// یک شیء Presentation ایجاد می‌کند که نمایانگر یک فایل ارائه است
var pres = new aspose.slides.Presentation("Convert_XPS_Options.pptx");
try {
    // نمونه‌سازی کلاس TiffOptions
    var options = new aspose.slides.XpsOptions();
    // ذخیره MetaFiles به عنوان PNG
    options.setSaveMetafilesAsPng(true);
    // ذخیره ارائه به سند XPS
    pres.save("XPS_Output_With_Options.xps", aspose.slides.SaveFormat.Xps, options);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **سوالات متداول**

**آیا می‌توانم به جای ذخیره در فایل، XPS را به یک جریان (stream) ذخیره کنم؟**

بله—Aspose.Slides به شما اجازه می‌دهد به‌صورت مستقیم به یک جریان خروجی دهید، که برای API‌های وب، خطوط لوله سمت سرور یا هر سناریویی که می‌خواهید XPS را بدون دست‌کاری در فایل‌سیستم ارسال کنید، ایده‌آل است.

**آیا اسلایدهای مخفی به XPS منتقل می‌شوند و می‌توانم آنها را مستثنی کنم؟**

به‌صورت پیش‌فرض، فقط اسلایدهای معمولی (قابل مشاهده) رندرز می‌شوند. می‌توانید با استفاده از [شامل یا مستثنی کردن اسلایدهای مخفی](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/xpsoptions/setshowhiddenslides/) از طریق [تنظیمات خروجی](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/xpsoptions/) قبل از ذخیره به XPS، خروجی را دقیقاً مطابق با صفحاتی که می‌خواهید داشته باشید، تنظیم کنید.