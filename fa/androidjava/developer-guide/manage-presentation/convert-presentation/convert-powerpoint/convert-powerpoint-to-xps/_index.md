---
title: تبدیل ارائه‌های PowerPoint به XPS در اندروید
linktitle: PowerPoint به XPS
type: docs
weight: 70
url: /fa/androidjava/convert-powerpoint-to-xps/
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
- ذخیره PPT به صورت XPS
- ذخیره PPTX به صورت XPS
- صادرات PPT به XPS
- صادرات PPTX به XPS
- PowerPoint
- ارائه
- Android
- Java
- Aspose.Slides
description: "PowerPoint PPT/PPTX را به XPS با کیفیت بالا و مستقل از پلتفرم در جاوا با استفاده از Aspose.Slides برای اندروید تبدیل کنید. راهنمای گام‌به‌گام و کد نمونه را دریافت کنید."
---
## **مروری کلی**

Aspose.Slides به شما اجازه می‌دهد ارائه‌های PowerPoint را به XPS تبدیل کنید با ذخیره‌سازی فایل PPT یا PPTX در قالب XPS. این مقاله توضیح می‌دهد که چه زمانی قالب XPS مفید است و نشان می‌دهد چگونه تبدیل را با Aspose.Slides با استفاده از تنظیمات پیش‌فرض یا تنظیمات سفارشی [XpsOptions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/xpsoptions/) انجام دهید.

## **درباره XPS**

Microsoft [XPS](https://docs.fileformat.com/page-description-language/xps/) را به عنوان جایگزینی برای [PDF](https://docs.fileformat.com/pdf/) توسعه داد. این قالب به شما اجازه می‌دهد محتوا را با خروجی فایل بسیار شبیه به PDF چاپ کنید. فرمت XPS بر پایه XML است. طرح یا ساختار یک فایل XPS در تمام سیستم‌عامل‌ها و چاپگرها یکسان باقی می‌ماند.

## **وقتی باید از فرمت XPS مایکروسافت استفاده کنید**

{{% alert color="primary" %}} 
برای مشاهده اینکه Aspose.Slides چگونه ارائه PPT یا PPTX را به فرمت XPS تبدیل می‌کند، می‌توانید این برنامه تبدیل آنلاین رایگان را بررسی کنید[this free online converter app](https://products.aspose.app/slides/fa/conversion). 
{{% /alert %}} 

اگر می‌خواهید هزینه‌های ذخیره‌سازی را کاهش دهید، می‌توانید ارائه Microsoft PowerPoint خود را به فرمت XPS تبدیل کنید. به این ترتیب ذخیره، به اشتراک‌گذاری و چاپ اسناد برای شما آسان‌تر می‌شود.

Microsoft همچنان پشتیبانی قوی از XPS را در ویندوز (حتی در Windows 10) اعمال می‌کند، بنابراین ممکن است بخواهید فایل‌ها را در این قالب ذخیره کنید. اگر با Windows 8.1، Windows 8، Windows 7 و Windows Vista کار می‌کنید، XPS ممکن است گزینه بهترین برای برخی عملیات‌ها باشد.

- **Windows 8** از قالب OXPS (Open XPS) برای فایل‌های XPS استفاده می‌کند. OXPS نسخه استاندارد شده‌ای از قالب اصلی XPS است. Windows 8 پشتیبانی بهتری برای فایل‌های XPS نسبت به فایل‌های PDF ارائه می‌دهد. 
  - **XPS:** ویوور/خواننده XPS داخلی و قابلیت چاپ به XPS در دسترس است. 
  - **PDF:** خواننده PDF موجود است اما قابلیت چاپ به PDF وجود ندارد. 

- **Windows 7 و Windows Vista** از قالب اصلی XPS استفاده می‌کنند. این سیستم‌عامل‌ها نیز پشتیبانی بهتری برای فایل‌های XPS نسبت به PDF دارند. 
  - **XPS:** ویوور XPS داخلی و قابلیت چاپ به XPS در دسترس است. 
  - **PDF:** خواننده PDF وجود ندارد. قابلیت چاپ به PDF نیز وجود ندارد. 

|<p>**ورودی PPT(X):**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**خروجی XPS:**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

Microsoft در نهایت پشتیبانی از عملیات چاپ را در PDF از طریق ویژگی Print to PDF در Windows 10 پیاده‌سازی کرد. پیش از آن کاربران انتظار داشتند اسناد را از طریق قالب XPS چاپ کنند. 

## **تبدیل XPS با Aspose.Slides**

در [**Aspose.Slides**](https://products.aspose.com/slides/fa/androidjava/) برای Java می‌توانید از متد [**Save**](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) که توسط کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) ارائه می‌شود استفاده کنید تا کل ارائه را به سند XPS تبدیل کنید.

هنگام تبدیل یک ارائه به XPS، باید ارائه را با یکی از این تنظیمات ذخیره کنید:

- تنظیمات پیش‌فرض (بدون [**XPSOptions**](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/xpsoptions))
- تنظیمات سفارشی (با [**XPSOptions**](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/xpsoptions))

### **تبدیل ارائه‌ها به XPS با استفاده از تنظیمات پیش‌فرض**

این کد نمونه در Java نشان می‌دهد چگونه یک ارائه را به سند XPS با تنظیمات استاندارد تبدیل کنید:

```java
// یک شی Presentation که نمایانگر یک فایل ارائه است را نمونه‌سازی کنید
Presentation pres = new Presentation("Convert_XPS.pptx");
try {
    // ذخیرهٔ ارائه به سند XPS
    pres.save("XPS_Output_Without_XPSOption.xps", SaveFormat.Xps);
} finally {
    if (pres != null) pres.dispose();
}
```

### **تبدیل ارائه‌ها به XPS با استفاده از تنظیمات سفارشی**

این کد نمونه نشان می‌دهد چگونه یک ارائه را به سند XPS با تنظیمات سفارشی در Java تبدیل کنید:

```java
// یک شی Presentation که نمایانگر یک فایل ارائه است را نمونه‌سازی کنید
Presentation pres = new Presentation("Convert_XPS_Options.pptx");
try {
    // کلاس XpsOptions را نمونه‌سازی کنید
    XpsOptions options = new XpsOptions();

    // ذخیره متافایل‌ها به صورت PNG
    options.setSaveMetafilesAsPng(true);

    // ذخیرهٔ ارائه به سند XPS
    pres.save("XPS_Output_With_Options.xps", SaveFormat.Xps, options);
} finally {
    if (pres != null) pres.dispose();
}
```

## **پرسش‌های متداول**

**آیا می‌توانم به جای ذخیره در فایل، XPS را در یک جریان (stream) ذخیره کنم؟**

بله—Aspose.Slides به شما امکان خروجی مستقیم به یک جریان را می‌دهد که برای APIهای وب، خطوط لوله سمت سرور یا هر سناریویی که می‌خواهید XPS را بدون تماس با سیستم فایل ارسال کنید، ایده‌آل است.

**آیا اسلایدهای مخفی به XPS منتقل می‌شوند و می‌توانم آن‌ها را حذف کنم؟**

به‌طور پیش‌فرض تنها اسلایدهای معمولی (قابل مشاهده) رندر می‌شوند. می‌توانید [اسلایدهای مخفی را شامل یا حذف کنید](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/xpsoptions/#setShowHiddenSlides-boolean-) از طریق [تنظیمات خروجی](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/xpsoptions/) قبل از ذخیره به XPS، تا خروجی دقیقاً شامل صفحاتی باشد که می‌خواهید.