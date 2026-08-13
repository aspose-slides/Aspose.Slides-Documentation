---
title: تبدیل ارائه‌های PowerPoint به XPS در Android
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
- ذخیره PPT به عنوان XPS
- ذخیره PPTX به عنوان XPS
- صادرات PPT به XPS
- صادرات PPTX به XPS
- PowerPoint
- ارائه
- Android
- Java
- Aspose.Slides
description: "تبدیل PowerPoint PPT/PPTX به XPS با کیفیت بالا و مستقل از پلتفرم در جاوا با استفاده از Aspose.Slides برای Android. راهنمای قدم به قدم و کد نمونه را دریافت کنید."
---
## **بررسی کلی**

Aspose.Slides به شما امکان می‌دهد ارائه‌های PowerPoint را به XPS تبدیل کنید با ذخیره کردن فایل PPT یا PPTX در فرمت XPS. این مقاله توضیح می‌دهد که چه زمان‌هایی فرمت XPS مفید است و نحوه انجام تبدیل با Aspose.Slides را با تنظیمات پیش‌فرض یا تنظیمات سفارشی [XpsOptions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/xpsoptions/) نشان می‌دهد.

## **درباره XPS**
مایکروسافت [XPS](https://docs.fileformat.com/page-description-language/xps/) را به عنوان جایگزینی برای [PDF](https://docs.fileformat.com/pdf/) توسعه داد. این فرمت به شما اجازه می‌دهد محتوا را با خروجی مشابه PDF چاپ کنید. فرمت XPS بر پایه XML است. طرح یا ساختار یک فایل XPS در تمام سیستم‌عامل‌ها و چاپگرها یکسان می‌ماند.

## **زمان استفاده از فرمت XPS مایکروسافت**

{{% alert color="info" %}} 
برای مشاهده نحوه تبدیل ارائه PPT یا PPTX به فرمت XPS توسط Aspose.Slides، می‌توانید به [این برنامه رایگان آنلاین تبدیل](https://products.aspose.app/slides/fa/conversion) مراجعه کنید. 
{{% /alert %}} 

اگر می‌خواهید هزینه‌های ذخیره‌سازی را کاهش دهید، می‌توانید ارائه Microsoft PowerPoint خود را به فرمت XPS تبدیل کنید. بدین ترتیب ذخیره، اشتراک‌گذاری و چاپ اسناد برای شما آسان‌تر خواهد شد.

مایکروسافت همچنان پشتیبانی قوی از XPS را در ویندوز (حتی در ویندوز 10) پیاده‌سازی می‌کند، بنابراین ممکن است بخواهید فایل‌ها را با این فرمت ذخیره کنید. اگر با ویندوز 8.1، ویندوز 8، ویندوز 7 و ویندوز Vista کار می‌کنید، XPS می‌تواند گزینهٔ بهترین برای برخی عملیات باشد.

- **Windows 8** از فرمت OXPS (Open XPS) برای فایل‌های XPS استفاده می‌کند. OXPS نسخه استاندارد شدهٔ فرمت اصلی XPS است. ویندوز 8 پشتیبانی بهتری برای فایل‌های XPS نسبت به فایل‌های PDF ارائه می‌دهد. 
  - **XPS:** مشاهده‌گر/خوانندهٔ داخلی XPS و قابلیت چاپ به XPS موجود است. 
  - **PDF:** خوانندهٔ PDF موجود است اما قابلیت چاپ به PDF وجود ندارد. 

- **Windows 7 و Windows Vista** از فرمت اصلی XPS استفاده می‌کنند. این سیستم‌عامل‌ها نیز پشتیبانی بهتری برای فایل‌های XPS نسبت به PDF دارند. 
  - **XPS:** مشاهده‌گر داخلی XPS و قابلیت چاپ به XPS موجود است. 
  - **PDF:** خوانندهٔ PDF وجود ندارد. قابلیت چاپ به PDF وجود ندارد. 

|<p>**ورودی PPT(X):**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**خروجی XPS:**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

مایکروسافت در نهایت پشتیبانی از عملیات چاپ در PDF را از طریق قابلیت Print to PDF در ویندوز 10 پیاده‌سازی کرد. پیش از آن کاربران مجبور بودند اسناد را از طریق فرمت XPS چاپ کنند.

## **تبدیل XPS با Aspose.Slides**

در [**Aspose.Slides**](https://products.aspose.com/slides/fa/androidjava/) برای Java، می‌توانید از متد [**Save**](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) که توسط کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) ارائه می‌شود، برای تبدیل کل ارائه به یک سند XPS استفاده کنید.

هنگام تبدیل یک ارائه به XPS، باید ارائه را با یکی از این تنظیمات ذخیره کنید:

- تنظیمات پیش‌فرض (بدون [**XPSOptions**](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/xpsoptions))
- تنظیمات سفارشی (با [**XPSOptions**](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/xpsoptions))

### **تبدیل ارائه‌ها به XPS با تنظیمات پیش‌فرض**

این نمونه کد در Java نشان می‌دهد چگونه یک ارائه را با تنظیمات استاندارد به سند XPS تبدیل کنید:

```java
import com.aspose.slides.*;

// ایجاد یک شیء Presentation که نمایانگر یک فایل ارائه است
Presentation pres = new Presentation("Convert_XPS.pptx");
try {
    // ذخیره‌ی ارائه به سند XPS
    pres.save("XPS_Output_Without_XPSOption.xps", SaveFormat.Xps);
} finally {
    if (pres != null) pres.dispose();
}
```

### **تبدیل ارائه‌ها به XPS با تنظیمات سفارشی**
این نمونه کد نشان می‌دهد چگونه یک ارائه را با تنظیمات سفارشی در Java به سند XPS تبدیل کنید:

```java
import com.aspose.slides.*;

// ایجاد یک شیء Presentation که نمایانگر یک فایل ارائه است
Presentation pres = new Presentation("Convert_XPS_Options.pptx");
try {
    // ایجاد شیء XpsOptions
    XpsOptions options = new XpsOptions();

    // ذخیره MetaFiles به صورت PNG
    options.setSaveMetafilesAsPng(true);

    // ذخیرهٔ ارائه به سند XPS
    pres.save("XPS_Output_With_Options.xps", SaveFormat.Xps, options);
} finally {
    if (pres != null) pres.dispose();
}
```

## **سوالات متداول**

### آیا می‌توانم به‌جای ذخیره در فایل، XPS را به یک استریم ذخیره کنم؟

بله—Aspose.Slides به شما امکان صادرات مستقیم به یک استریم را می‌دهد که برای APIهای وب، خطوط لوله سمت سرور یا هر سناریویی که می‌خواهید XPS را بدون دسترسی به سیستم فایل ارسال کنید، ایده‌آل است.

### آیا اسلایدهای مخفی به XPS منتقل می‌شوند و می‌توانم آنها را حذف کنم؟

به‌طور پیش‌فرض، تنها اسلایدهای معمولی (قابل مشاهده) رندر می‌شوند. می‌توانید [اسلایدهای مخفی را وارد یا حذف کنید](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/xpsoptions/#setShowHiddenSlides-boolean-) از طریق [تنظیمات صادرات](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/xpsoptions/) قبل از ذخیره به XPS، تا خروجی دقیقاً شامل صفحاتی باشد که می‌خواهید.