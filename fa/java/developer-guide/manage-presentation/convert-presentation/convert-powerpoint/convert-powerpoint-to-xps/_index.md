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
- Java
- Aspose.Slides
description: "PowerPoint PPT/PPTX را به XPS با کیفیت بالا و مستقل از پلتفرم در Java با استفاده از Aspose.Slides تبدیل کنید. راهنمای گام به گام و کد نمونه دریافت کنید."
---
## **نمای کلی**

Aspose.Slides به شما امکان می‌دهد ارائه‌های PowerPoint را به XPS تبدیل کنید با ذخیره‌سازی یک فایل PPT یا PPTX در قالب XPS. این مقاله توضیح می‌دهد که چه زمانی قالب XPS مفید است و نشان می‌دهد چگونه می‌توانید تبدیل را با Aspose.Slides با استفاده از تنظیمات پیش‌فرض یا تنظیمات سفارشی [XpsOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/xpsoptions/) انجام دهید.

## **درباره XPS**
Microsoft [XPS](https://docs.fileformat.com/page-description-language/xps/) را به‌عنوان جایگزینی برای [PDF](https://docs.fileformat.com/pdf/) توسعه داد. این قالب به شما امکان چاپ محتوا را با خروجی‌گیری به‌صورت فایلی بسیار شبیه PDF می‌دهد. قالب XPS بر پایه XML است. چیدمان یا ساختار یک فایل XPS در تمام سیستم‌عامل‌ها و چاپگرها یکسان باقی می‌ماند. 

## **هنگامی که باید از قالب Microsoft XPS استفاده کنید**

{{% alert color="info" %}} 

برای مشاهده نحوه تبدیل ارائه PPT یا PPTX به قالب XPS توسط Aspose.Slides، می‌توانید [این برنامه رایگان تبدیل آنلاین] را بررسی کنید(https://products.aspose.app/slides/fa/conversion). 

{{% /alert %}} 

اگر می‌خواهید هزینه‌های ذخیره‌سازی را کاهش دهید، می‌توانید ارائه Microsoft PowerPoint خود را به قالب XPS تبدیل کنید. به این ترتیب، ذخیره، اشتراک‌گذاری و چاپ اسناد برای شما راحت‌تر خواهد بود. 

Microsoft همچنان پشتیبانی قوی از XPS را در ویندوز (حتی در Windows 10) اجرا می‌کند، بنابراین ممکن است بخواهید فایل‌ها را در این قالب ذخیره کنید. اگر با Windows 8.1، Windows 8، Windows 7 و Windows Vista سروکار دارید، XPS می‌تواند گزینهٔ بهترین برای برخی عملیات باشد. 

- **Windows 8** از قالب OXPS (Open XPS) برای فایل‌های XPS استفاده می‌کند. OXPS نسخهٔ استاندارد شدهٔ قالب اصلی XPS است. ویندوز ۸ نسبت به فایل‌های PDF، پشتیبانی بهتری از فایل‌های XPS دارد. 
  - **XPS:** نماینده/خواننده XPS داخلی و ویژگی چاپ به XPS در دسترس است. 
  - **PDF:** خواننده PDF موجود است اما ویژگی چاپ به PDF وجود ندارد. 

- **Windows 7 و Windows Vista** از قالب اصلی XPS استفاده می‌کنند. این سیستم‌عامل‌ها نیز پشتیبانی بهتری از فایل‌های XPS نسبت به PDF دارند. 
  - **XPS:** نماینده/خواننده XPS داخلی و ویژگی چاپ به XPS در دسترس است. 
  - **PDF:** خواننده PDF وجود ندارد. ویژگی چاپ به PDF وجود ندارد. 

|<p>**ورودی PPT(X):**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**خروجی XPS:**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

Microsoft در نهایت پشتیبانی از عملیات چاپ در PDF را از طریق ویژگی Print to PDF در Windows 10 پیاده‌سازی کرد. قبلاً کاربران انتظار داشتند اسناد را از طریق قالب XPS چاپ کنند. 

## **تبدیل XPS با Aspose.Slides**

در [**Aspose.Slides**](https://products.aspose.com/slides/fa/java/) برای Java، می‌توانید از متد [**Save**](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) که توسط کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) افشا می‌شود، برای تبدیل کل ارائه به یک سند XPS استفاده کنید. 

هنگام تبدیل یک ارائه به XPS، باید ارائه را با یکی از این تنظیمات ذخیره کنید:

- تنظیمات پیش‌فرض (بدون [**XPSOptions**](https://reference.aspose.com/slides/fa/java/com.aspose.slides/xpsoptions))
- تنظیمات سفارشی (با [**XPSOptions**](https://reference.aspose.com/slides/fa/java/com.aspose.slides/xpsoptions))

### **تبدیل ارائه‌ها به XPS با استفاده از تنظیمات پیش‌فرض**

این کد نمونه در Java نشان می‌دهد چگونه یک ارائه را به سند XPS با استفاده از تنظیمات استاندارد تبدیل کنید:

```java
import com.aspose.slides.*;

// یک شیء Presentation ایجاد کنید که نمایانگر یک فایل ارائه است
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
import com.aspose.slides.*;

// یک شیء Presentation ایجاد کنید که نمایانگر یک فایل ارائه است
Presentation pres = new Presentation("Convert_XPS_Options.pptx");
try {
    // یک شیء از کلاس XpsOptions ایجاد کنید
    XpsOptions options = new XpsOptions();

    // متافایل‌ها را به صورت PNG ذخیره کنید
    options.setSaveMetafilesAsPng(true);

    // ارائه را به سند XPS ذخیره کنید
    pres.save("XPS_Output_With_Options.xps", SaveFormat.Xps, options);
} finally {
    if (pres != null) pres.dispose();
}
```

## **سوالات متداول**

### آیا می‌توانم XPS را به‌جای فایل، در یک استریم ذخیره کنم؟

بله—Aspose.Slides به شما امکان می‌دهد مستقیماً به یک استریم خروجی بدهید، که برای APIهای وب، خط‌لوله‌های سمت سرور یا هر سناریویی که می‌خواهید XPS را بدون لمس فایل‌سیستم ارسال کنید، ایده‌آل است.

### آیا اسلایدهای مخفی به XPS منتقل می‌شوند و می‌توانم آن‌ها را حذف کنم؟

به‌طور پیش‌فرض، فقط اسلایدهای عادی (قابل مشاهده) رندر می‌شوند. می‌توانید [اسلایدهای مخفی را شامل یا حذف کنید](https://reference.aspose.com/slides/fa/java/com.aspose.slides/xpsoptions/#setShowHiddenSlides-boolean-) از طریق [تنظیمات خروجی](https://reference.aspose.com/slides/fa/java/com.aspose.slides/xpsoptions/) قبل از ذخیره‌سازی به XPS، تا خروجی دقیقاً شامل صفحاتی باشد که می‌خواهید.