---
title: تبدیل ارائه‌های PowerPoint به XPS در C++
linktitle: PowerPoint به XPS
type: docs
weight: 70
url: /fa/cpp/convert-powerpoint-to-xps
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
- C++
- Aspose.Slides
description: "تبدیل PowerPoint PPT/PPTX به XPS با کیفیت بالا و مستقل از پلتفرم در C++ با استفاده از Aspose.Slides. راهنمای گام به گام و کد نمونه را دریافت کنید."
---
## **بررسی اجمالی**

Aspose.Slides به شما امکان می‌دهد ارائه‌های PowerPoint را به XPS تبدیل کنید با ذخیره‌سازی فایل PPT یا PPTX در قالب XPS. این مقاله وقتی که قالب XPS مفید است را توضیح می‌دهد و نشان می‌دهد چگونه می‌توانید تبدیل را با Aspose.Slides انجام دهید با استفاده از تنظیمات پیش‌فرض یا تنظیمات سفارشی [XpsOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/xpsoptions/) .

## **در مورد XPS**

Microsoft [XPS](https://docs.fileformat.com/page-description-language/xps/) را به عنوان جایگزینی برای [PDF](https://docs.fileformat.com/pdf/) توسعه داد. این امکان را می‌دهد محتوایی را چاپ کنید با خروجی یک فایل بسیار شبیه PDF. قالب XPS بر پایه XML است. چیدمان یا ساختار یک فایل XPS در تمام سیستم‌عامل‌ها و چاپگرها یکسان باقی می‌ماند.

## **زمان استفاده از قالب XPS مایکروسافت**

{{% alert color="primary" %}} 

برای مشاهده نحوه تبدیل ارائه PPT یا PPTX به قالب XPS توسط Aspose.Slides، می‌توانید [این برنامه رایگان تبدیل آنلاین](https://products.aspose.app/slides/fa/conversion) را بررسی کنید. 

{{% /alert %}} 

اگر می‌خواهید هزینه‌های ذخیره‌سازی را کاهش دهید، می‌توانید ارائه Microsoft PowerPoint خود را به قالب XPS تبدیل کنید. به این ترتیب ذخیره، به اشتراک‌گذاری و چاپ اسناد برای شما راحت‌تر خواهد شد. 

مایکروسافت همچنان پشتیبانی قدرتمند از XPS را در ویندوز (حتی در ویندوز 10) پیاده‌سازی می‌کند، بنابراین ممکن است بخواهید فایل‌ها را در این قالب ذخیره کنید. اگر با ویندوز 8.1، ویندوز 8، ویندوز 7 و ویندوز ویستا سروکار دارید، XPS ممکن است گزینهٔ بهترین برای برخی عملیات باشد. 

- **Windows 8** از قالب OXPS (Open XPS) برای فایل‌های XPS استفاده می‌کند. OXPS نسخه‌ استانداردی از قالب اصلی XPS است. ویندوز 8 پشتیبانی بهتری برای فایل‌های XPS نسبت به فایل‌های PDF ارائه می‌دهد. 
  - **XPS:** نماینده/خوانندهٔ XPS داخلی و قابلیت چاپ به XPS در دسترس است. 
  - **PDF:** خواننده PDF موجود است اما قابلیت چاپ به PDF وجود ندارد. 

- **Windows 7 and Windows Vista** از قالب اصلی XPS استفاده می‌کنند. این سیستم‌عامل‌ها نیز پشتیبانی بهتری برای فایل‌های XPS نسبت به PDF دارند. 
  - **XPS:** نماینده/خوانندهٔ XPS داخلی و قابلیت چاپ به XPS در دسترس است. 
  - **PDF:** خواننده PDF وجود ندارد. قابلیت چاپ به PDF وجود ندارد. 

|<p>**ورودی PPT(X):</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**خروجی XPS:</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

مایکروسافت در نهایت پشتیبانی از عملیات چاپ در PDF را از طریق ویژگی Print to PDF در ویندوز 10 پیاده‌سازی کرد. پیش از آن، انتظار می‌رفت کاربران اسناد را از طریق قالب XPS چاپ کنند. 

## **تبدیل XPS با Aspose.Slides**

در [**Aspose.Slides**](https://products.aspose.com/slides/fa/cpp/) برای C++، می‌توانید از روش [**Save**](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) که توسط کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.presentation) عرضه می‌شود استفاده کنید تا کل ارائه را به یک سند XPS تبدیل کنید. 

هنگام تبدیل یک ارائه به XPS، باید ارائه را با یکی از این تنظیمات ذخیره کنید:

- تنظیمات پیش‌فرض (بدون [**XPSOptions**](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.export.xps_options))
- تنظیمات سفارشی (با [**XPSOptions**](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.export.xps_options))

### **تبدیل ارائه‌ها به XPS با استفاده از تنظیمات پیش‌فرض**

این کد نمونه در C++ نشان می‌دهد چگونه یک ارائه را با استفاده از تنظیمات استاندارد به یک سند XPS تبدیل کنید:

``` cpp
// یک شیء Presentation ایجاد می‌کند که نمایانگر یک فایل ارائه است
auto pres = System::MakeObject<Presentation>(u"Convert_XPS.pptx");
// ذخیره‌سازی ارائه به سند XPS
pres->Save(u"XPS_Output_Without_XPSOption_out.xps", SaveFormat::Xps);
```

### **تبدیل ارائه‌ها به XPS با استفاده از تنظیمات سفارشی**

این کد نمونه نشان می‌دهد چگونه یک ارائه را با استفاده از تنظیمات سفارشی در C++ به یک سند XPS تبدیل کنید:

``` cpp
// یک شیء Presentation ایجاد می‌کند که نمایانگر یک فایل ارائه است
auto pres = System::MakeObject<Presentation>(u"Convert_XPS_Options.pptx");
// یک شیء از کلاس TiffOptions ایجاد می‌کند
auto options = System::MakeObject<XpsOptions>();

// ذخیره MetaFiles به صورت PNG
options->set_SaveMetafilesAsPng(true);

// ذخیره ارائه در سند XPS
pres->Save(u"XPS_With_Options_out.xps", SaveFormat::Xps, options);
```

## **سوالات متداول**

**آیا می‌توانم XPS را به جای یک فایل در یک استریم ذخیره کنم؟**

بله—Aspose.Slides به شما امکان می‌دهد مستقیماً به یک استریم خروجی دهید، که برای APIهای وب، خطوط لوله سمت سرور، یا هر سناریویی که می‌خواهید XPS را بدون دست‌کاری سیستم فایل ارسال کنید، ایده‌آل است.

**آیا اسلایدهای مخفی به XPS منتقل می‌شوند و می‌توانم آنها را حذف کنم؟**

به‌طور پیش‌فرض، تنها اسلایدهای معمولی (قابل مشاهده) رندر می‌شوند. می‌توانید با استفاده از [شامل یا حذف اسلایدهای مخفی](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/xpsoptions/set_showhiddenslides/) از طریق [تنظیمات خروجی](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/xpsoptions/) قبل از ذخیره به XPS، اطمینان حاصل کنید خروجی دقیقاً صفحاتی را که می‌خواهید شامل می‌شود.