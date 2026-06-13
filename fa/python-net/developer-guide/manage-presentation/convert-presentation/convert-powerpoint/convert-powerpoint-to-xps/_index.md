---
title: تبدیل ارائه‌های PowerPoint به XPS در Python
linktitle: PowerPoint به XPS
type: docs
weight: 70
url: /fa/python-net/convert-powerpoint-to-xps/
keywords:
- تبدیل PowerPoint
- تبدیل ارائه
- PowerPoint به XPS
- ارائه به XPS
- PPT به XPS
- PPTX به XPS
- PowerPoint
- ارائه
- Python
- Aspose.Slides
description: "تبدیل PowerPoint PPT/PPTX به XPS با کیفیت بالا و مستقل از پلتفرم در Python با استفاده از Aspose.Slides. راهنمای قدم به قدم و کد نمونه دریافت کنید."
---
## **مروری**

Aspose.Slides به شما امکان می‌دهد ارائه‌های PowerPoint را به XPS تبدیل کنید با ذخیره‌سازی فایل PPT یا PPTX در قالب XPS. این مقاله توضیح می‌دهد که چه زمانی قالب XPS مفید است و نشان می‌دهد چگونه تبدیل را با Aspose.Slides با استفاده از تنظیمات پیش‌فرض یا تنظیمات سفارشی [XpsOptions](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/xpsoptions/) انجام دهید.

## **درباره XPS**
مایکروسافت [XPS](https://docs.fileformat.com/page-description-language/xps/) را به عنوان جایگزینی برای [PDF](https://docs.fileformat.com/pdf/) توسعه داد. این امکان را به شما می‌دهد تا محتوا را با خروجی فایلی بسیار مشابه PDF چاپ کنید. قالب XPS بر پایه XML است. چیدمان یا ساختار یک فایل XPS در تمام سیستم‌عامل‌ها و چاپگرها یکسان می‌ماند. 

## زمان استفاده از قالب XPS مایکروسافت

{{% alert color="primary" %}} 

برای مشاهده نحوه تبدیل ارائه PPT یا PPTX به قالب XPS توسط Aspose.Slides، می‌توانید [این برنامه رایگان تبدیل آنلاین](https://products.aspose.app/slides/fa/conversion) را بررسی کنید. 

{{% /alert %}} 

اگر می‌خواهید هزینه‌های ذخیره‌سازی را کاهش دهید، می‌توانید ارائه Microsoft PowerPoint خود را به قالب XPS تبدیل کنید. این کار باعث می‌شود ذخیره، اشتراک‌گذاری و چاپ اسناد برای شما آسان‌تر شود. 

مایکروسافت همچنان پشتیبانی قوی از XPS را در ویندوز (حتی در ویندوز 10) اجرا می‌کند، بنابراین ممکن است بخواهید فایل‌ها را در این قالب ذخیره کنید. اگر با ویندوز 8.1، ویندوز 8، ویندوز 7 و ویندوز ویستا سروکار دارید، XPS ممکن است گزینه بهترین برای برخی عملیات باشد. 

- **Windows 8** از قالب OXPS (Open XPS) برای فایل‌های XPS استفاده می‌کند. OXPS نسخه‌ای استاندارد شده از قالب اصلی XPS است. ویندوز 8 نسبت به فایل‌های PDF، پشتیبانی بهتر از فایل‌های XPS ارائه می‌دهد. 
  - **XPS:** ویور/خواننده XPS داخلی و قابلیت چاپ به XPS موجود است. 
  - **PDF**: خواننده PDF موجود است اما قابلیت چاپ به PDF وجود ندارد. 

- **Windows 7 and Windows Vista** از قالب اصلی XPS استفاده می‌کنند. این سیستم‌عامل‌ها نیز نسبت به PDF، پشتیبانی بهتری از فایل‌های XPS ارائه می‌دهند. 
  - **XPS**: ویور XPS داخلی و قابلیت چاپ به XPS موجود است. 
  - **PDF**: خواننده PDF وجود ندارد. قابلیت چاپ به PDF نیز وجود ندارد. 

|<p>**ورودی PPT(X):</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**خروجی XPS:</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

مایکروسافت در نهایت پشتیبانی از عملیات چاپ در PDF را از طریق ویژگی چاپ به PDF در ویندوز 10 پیاده‌سازی کرد. قبلاً کاربران انتظار داشتند اسناد را از طریق قالب XPS چاپ کنند. 

## تبدیل XPS با Aspose.Slides

در [**Aspose.Slides**](https://products.aspose.com/slides/fa/python-net/) برای .NET، می‌توانید از متد [**Save**](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) که توسط کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) فراهم شده استفاده کنید تا کل ارائه را به یک سند XPS تبدیل کنید. 

هنگام تبدیل یک ارائه به XPS، باید ارائه را با یکی از این تنظیمات ذخیره کنید:

- تنظیمات پیش‌فرض (بدون [**XPSOptions**](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/xpsoptions/))
- تنظیمات سفارشی (با [**XPSOptions**](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/xpsoptions/))

### **تبدیل ارائه‌ها به XPS با استفاده از تنظیمات پیش‌فرض**

این کد نمونه در Python نشان می‌دهد چگونه یک ارائه را به سند XPS با استفاده از تنظیمات استاندارد تبدیل کنید:

```py
import aspose.slides as slides

# یک شی Presentation ایجاد کنید که نمایانگر یک فایل ارائه است
# ذخیرهٔ ارائه به‌صورت سند XPS
pres = slides.Presentation("Convert_XPS.pptx")

# Saving the presentation to XPS document
pres.save("XPS_Output_Without_XPSOption_out.xps", slides.export.SaveFormat.XPS)
```

### **تبدیل ارائه‌ها به XPS با استفاده از تنظیمات سفارشی**

این کد نمونه نشان می‌دهد چگونه یک ارائه را به سند XPS با استفاده از تنظیمات سفارشی در Python تبدیل کنید:

```py
import aspose.slides as slides

# یک شی Presentation ایجاد کنید که نمایانگر یک فایل ارائه است
pres = slides.Presentation("Convert_XPS_Options.pptx")

# یک شی از کلاس TiffOptions ایجاد کنید
options = slides.export.XpsOptions()

# ذخیره متافایل‌ها به‌صورت PNG
options.save_metafiles_as_png = True

# ذخیره ارائه به‌صورت سند XPS
pres.save("XPS_With_Options_out.xps", slides.export.SaveFormat.XPS, options)
```

## **پرسش‌های متداول**

**آیا می‌توانم XPS را به‌جای فایل در یک استریم ذخیره کنم؟**

بله—Aspose.Slides به شما امکان می‌دهد مستقیماً به یک استریم خروجی بدهید، که برای APIهای وب، خطوط لوله سمت سرور، یا هر سناریویی که می‌خواهید XPS را بدون تعامل با سیستم فایل ارسال کنید، مناسب است.

**آیا اسلایدهای مخفی به XPS منتقل می‌شوند و می‌توانم آن‌ها را حذف کنم؟**

به‌صورت پیش‌فرض، تنها اسلایدهای عادی (قابل مشاهده) رندر می‌شوند. شما می‌توانید با استفاده از [شامل یا حذف اسلایدهای مخفی](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/xpsoptions/show_hidden_slides/) از طریق [تنظیمات خروجی](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/xpsoptions/) قبل از ذخیره به XPS، خروجی را دقیقاً شامل صفحات مورد نظر خود کنید.