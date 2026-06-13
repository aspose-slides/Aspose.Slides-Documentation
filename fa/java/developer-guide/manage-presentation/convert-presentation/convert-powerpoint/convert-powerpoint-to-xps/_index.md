---
title: تبدیل ارائه‌های PowerPoint به XPS در Java
linktitle: PowerPoint به XPS
type: docs
weight: 70
url: /fa/java/convert-powerpoint-to-xps/
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
- جاوا
- Aspose.Slides
description: "PowerPoint PPT/PPTX را با استفاده از Aspose.Slides در Java به XPS با کیفیت بالا و مستقل از پلتفرم تبدیل کنید. راهنمای گام‌به‌گام و کد نمونه را دریافت کنید."
---
## **نمای کلی**

Aspose.Slides به شما امکان می‌دهد ارائه‌های PowerPoint را به XPS تبدیل کنید؛ کافی است فایل PPT یا PPTX را در فرمت XPS ذخیره کنید. این مقاله توضیح می‌دهد که چه زمانی فرمت XPS می‌تواند مفید باشد و نشان می‌دهد چگونه می‌توانید تبدیل را با Aspose.Slides با استفاده از تنظیمات پیش‌فرض یا تنظیمات سفارشی [XpsOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/xpsoptions/) انجام دهید.

## **درباره XPS**

Microsoft [XPS](https://docs.fileformat.com/page-description-language/xps/) را به‌عنوان جایگزینی برای [PDF](https://docs.fileformat.com/pdf/) توسعه داد. این فرمت به شما امکان چاپ محتوا را با خروجی فایلی بسیار شبیه به PDF می‌دهد. فرمت XPS مبتنی بر XML است. چیدمان یا ساختار یک فایل XPS در تمام سیستم‌عامل‌ها و چاپگرها یکسان می‌ماند.

## **چه زمانی از فرمت XPS مایکروسافت استفاده کنیم**

{{% alert color="primary" %}} 

برای مشاهده نحوهٔ تبدیل ارائه PPT یا PPTX به فرمت XPS توسط Aspose.Slides، می‌توانید به [این برنامهٔ رایگان تبدیل آنلاین](https://products.aspose.app/slides/fa/conversion) سر بزنید. 

{{% /alert %}} 

اگر می‌خواهید هزینه‌های ذخیره‌سازی را کاهش دهید، می‌توانید ارائه Microsoft PowerPoint خود را به فرمت XPS تبدیل کنید. به این ترتیب ذخیره‌سازی، به‌اشتراک‌گذاری و چاپ اسناد برای شما آسان‌تر خواهد شد.

Microsoft پشتیبانی قوی از XPS را در ویندوز (حتی در Windows 10) ادامه داده است، بنابراین ممکن است بخواهید فایل‌ها را در این فرمت ذخیره کنید. اگر از Windows 8.1، Windows 8، Windows 7 یا Windows Vista استفاده می‌کنید، XPS می‌تواند گزینهٔ بهترین برای برخی عملیات باشد.

- **Windows 8** از فرمت OXPS (Open XPS) برای فایل‌های XPS استفاده می‌کند. OXPS نسخهٔ استانداردی از فرمت اصلی XPS است. Windows 8 پشتیبانی بهتری برای فایل‌های XPS نسبت به فایل‌های PDF فراهم می‌کند. 
  - **XPS:** ویور/ریدر XPS داخلی و قابلیت چاپ به XPS موجود است. 
  - **PDF:** ریدر PDF موجود است اما قابلیت چاپ به PDF ندارند. 

- **Windows 7 و Windows Vista** از فرمت اصلی XPS استفاده می‌کنند. این سیستم‌عامل‌ها نیز پشتیبانی بهتری برای فایل‌های XPS نسبت به PDF دارند. 
  - **XPS:** ویور XPS داخلی و قابلیت چاپ به XPS موجود است. 
  - **PDF:** ریدر PDF وجود ندارد. قابلیت چاپ به PDF نیز وجود ندارد. 

|<p>**ورودی PPT(X):**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**خروجی XPS:**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

Microsoft در نهایت پشتیبانی از عملیات چاپ به PDF را از طریق ویژگی Print to PDF در Windows 10 اضافه کرد. پیش از آن، کاربران انتظار داشتند اسناد را از طریق فرمت XPS چاپ کنند.

## **تبدیل XPS با Aspose.Slides**

در [**Aspose.Slides**](https://products.aspose.com/slides/fa/java/) برای Java، می‌توانید از روش [**Save**](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) که توسط کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) ارائه می‌شود، برای تبدیل کل ارائه به یک سند XPS استفاده کنید.

هنگام تبدیل یک ارائه به XPS، باید ارائه را با یکی از این تنظیمات ذخیره کنید:

- تنظیمات پیش‌فرض (بدون [**XPSOptions**](https://reference.aspose.com/slides/fa/java/com.aspose.slides/xpsoptions))
- تنظیمات سفارشی (با [**XPSOptions**](https://reference.aspose.com/slides/fa/java/com.aspose.slides/xpsoptions))

### **تبدیل ارائه‌ها به XPS با تنظیمات پیش‌فرض**

این نمونه کد در Java نشان می‌دهد چگونه یک ارائه را با تنظیمات استاندارد به سند XPS تبدیل کنید:

```java
// یک شیء Presentation ایجاد کنید که نمایانگر یک فایل ارائه باشد
Presentation pres = new Presentation("Convert_XPS.pptx");
try {
    // ذخیره ارائه به سند XPS
    pres.save("XPS_Output_Without_XPSOption.xps", SaveFormat.Xps);
} finally {
    if (pres != null) pres.dispose();
}
```

### **تبدیل ارائه‌ها به XPS با تنظیمات سفارشی**

این نمونه کد نشان می‌دهد چگونه یک ارائه را با تنظیمات سفارشی در Java به سند XPS تبدیل کنید:

```java
// یک شیء Presentation ایجاد کنید که نمایانگر یک فایل ارائه باشد
Presentation pres = new Presentation("Convert_XPS_Options.pptx");
try {
    // یک شیء TiffOptions ایجاد کنید
    XpsOptions options = new XpsOptions();

    // MetaFiles را به صورت PNG ذخیره کنید
    options.setSaveMetafilesAsPng(true);

    // ارائه را به سند XPS ذخیره کنید
    pres.save("XPS_Output_With_Options.xps", SaveFormat.Xps, options);
} finally {
    if (pres != null) pres.dispose();
}
```

## **سؤالات متداول**

**آیا می‌توانم به‌جای ذخیره در فایل، XPS را در یک استریم ذخیره کنم؟**

بله—Aspose.Slides به شما امکان می‌دهد مستقیماً به یک استریم صادر کنید؛ این برای APIهای وب، خط لوله‌های سمت سرور یا هر سناریویی که می‌خواهید XPS را بدون دست‌کاری سیستم فایل ارسال کنید، ایده‌آل است.

**آیا اسلایدهای پنهان به XPS منتقل می‌شوند و می‌توانم آن‌ها را حذف کنم؟**

به‌صورت پیش‌فرض تنها اسلایدهای معمولی (قابل مشاهده) رندر می‌شوند. می‌توانید [اسلایدهای پنهان را شامل یا حذف کنید](https://reference.aspose.com/slides/fa/java/com.aspose.slides/xpsoptions/#setShowHiddenSlides-boolean-) از طریق [تنظیمات خروجی](https://reference.aspose.com/slides/fa/java/com.aspose.slides/xpsoptions/) قبل از ذخیره‌سازی به XPS، تا خروجی دقیقا شامل صفحاتی باشد که می‌خواهید.