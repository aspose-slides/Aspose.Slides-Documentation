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
- ذخیره PPT به عنوان XPS
- ذخیره PPTX به عنوان XPS
- صادرات PPT به XPS
- صادرات PPTX به XPS
- PowerPoint
- ارائه
- C++
- Aspose.Slides
description: "PowerPoint PPT/PPTX را به XPS با کیفیت بالا و مستقل از پلتفرم در C++ با استفاده از Aspose.Slides تبدیل کنید. راهنمای گام‌به‌گام و نمونه کد را دریافت کنید."
---
## **مروری کلی**

Aspose.Slides به شما امکان می‌دهد ارائه‌های PowerPoint را به XPS تبدیل کنید با ذخیره‌سازی یک فایل PPT یا PPTX در قالب XPS. این مقاله توضیح می‌دهد چه زمانی قالب XPS می‌تواند مفید باشد و نشان می‌دهد چگونه می‌توانید تبدیل را با Aspose.Slides با استفاده از تنظیمات پیش‌فرض یا تنظیمات سفارشی [XpsOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/xpsoptions/) انجام دهید.

## **درباره XPS**
مایکروسافت [XPS](https://docs.fileformat.com/page-description-language/xps/) را به عنوان جایگزینی برای [PDF](https://docs.fileformat.com/pdf/) توسعه داد. این قالب به شما امکان چاپ محتوا را با خروجی یک فایل بسیار مشابه PDF می‌دهد. قالب XPS مبتنی بر XML است. چیدمان یا ساختار یک فایل XPS در تمام سیستم‌عامل‌ها و چاپگرها یکسان باقی می‌ماند. 

## **زمان استفاده از قالب XPS مایکروسافت**

{{% alert color="info" %}} 

برای مشاهده نحوه تبدیل ارائه PPT یا PPTX به قالب XPS توسط Aspose.Slides، می‌توانید [این برنامه رایگان تبدیل آنلاین](https://products.aspose.app/slides/fa/conversion) را بررسی کنید. 

{{% /alert %}} 

اگر می‌خواهید هزینه‌های ذخیره‌سازی را کاهش دهید، می‌توانید ارائه Microsoft PowerPoint خود را به قالب XPS تبدیل کنید. این کار باعث می‌شود ذخیره‌سازی، اشتراک‌گذاری و چاپ اسناد برای شما آسان‌تر باشد. 

مایکروسافت همچنان پشتیبانی قوی از XPS را در ویندوز (حتی در Windows 10) ادامه می‌دهد، بنابراین ممکن است بخواهید فایل‌ها را در این قالب ذخیره کنید. اگر با Windows 8.1، Windows 8، Windows 7 و Windows Vista سر و کار دارید، XPS می‌تواند گزینه بهترین برای برخی عملیات باشد. 

- **Windows 8** از قالب OXPS (Open XPS) برای فایل‌های XPS استفاده می‌کند. OXPS نسخه استاندارد شده‌ای از قالب اصلی XPS است. Windows 8 پشتیبانی بهتری از فایل‌های XPS نسبت به فایل‌های PDF دارد. 
  - **XPS:** مشاهده‌گر/خواننده XPS داخلی و قابلیت چاپ به XPS موجود است. 
  - **PDF:** خواننده PDF موجود است اما قابلیت چاپ به PDF ندارد. 

- **Windows 7** و **Windows Vista** از قالب اصلی XPS استفاده می‌کنند. این سیستم‌عامل‌ها نیز پشتیبانی بهتری از فایل‌های XPS نسبت به PDF دارند. 
  - **XPS:** مشاهده‌گر XPS داخلی و قابلیت چاپ به XPS موجود است. 
  - **PDF:** خواننده PDF وجود ندارد. قابلیت چاپ به PDF نیز موجود نیست. 

|<p>**ورودی PPT(X):**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**خروجی XPS:**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

مایکروسافت در نهایت پشتیبانی از عملیات چاپ در PDF را از طریق ویژگی Print to PDF در Windows 10 پیاده‌سازی کرد. پیش از آن کاربران برای چاپ اسناد مجبور به استفاده از قالب XPS بودند. 

## **تبدیل XPS با Aspose.Slides**

در [**Aspose.Slides**](https://products.aspose.com/slides/fa/cpp/) برای C++ می‌توانید از متد [**Save**](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) که توسط کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.presentation) ارائه می‌شود، برای تبدیل کل ارائه به یک سند XPS استفاده کنید. 

هنگام تبدیل یک ارائه به XPS باید ارائه را با یکی از این تنظیمات ذخیره کنید:

- تنظیمات پیش‌فرض (بدون [**XPSOptions**](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.export.xps_options))
- تنظیمات سفارشی (با [**XPSOptions**](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.export.xps_options))

### **تبدیل ارائه‌ها به XPS با تنظیمات پیش‌فرض**

این نمونه کد در C++ نشان می‌دهد چگونه یک ارائه را با تنظیمات استاندارد به سند XPS تبدیل کنید:

``` cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

// Instantiate a Presentation object that represents a presentation file
auto pres = System::MakeObject<Presentation>(u"Convert_XPS.pptx");
// Saving the presentation to XPS document
pres->Save(u"XPS_Output_Without_XPSOption_out.xps", SaveFormat::Xps);
```

### **تبدیل ارائه‌ها به XPS با تنظیمات سفارشی**
این نمونه کد نشان می‌دهد چگونه یک ارائه را با تنظیمات سفارشی در C++ به سند XPS تبدیل کنید:

``` cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Export/XpsOptions.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

// یک شیء Presentation که نمایانگر یک فایل ارائه است را نمونه‌سازی می‌کند
auto pres = System::MakeObject<Presentation>(u"Convert_XPS_Options.pptx");
// یک نمونه از کلاس TiffOptions ایجاد می‌کند
auto options = System::MakeObject<XpsOptions>();

// متافایل‌ها را به‌صورت PNG ذخیره کنید
options->set_SaveMetafilesAsPng(true);

// ارائه را به سند XPS ذخیره کنید
pres->Save(u"XPS_With_Options_out.xps", SaveFormat::Xps, options);
```

## **سؤالات متداول**

### آیا می‌توانم به جای ذخیره در فایل، XPS را در یک جریان (stream) ذخیره کنم؟

بله—Aspose.Slides به شما امکان می‌دهد مستقیماً به یک جریان خروجی صادر کنید، که برای APIهای وب، پردازش‌های سمت سرور یا هر سناریوئی که می‌خواهید XPS را بدون استفاده از سیستم فایل بفرستید، ایده‌آل است.

### آیا اسلایدهای مخفی در XPS انتقال می‌یابند و می‌توانم آن‌ها را حذف کنم؟

به‌صورت پیش‌فرض فقط اسلایدهای معمولی (قابل مشاهده) رندر می‌شوند. می‌توانید [اسلایدهای مخفی را شامل یا حذف کنید](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/xpsoptions/set_showhiddenslides/) از طریق [تنظیمات خروجی](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/xpsoptions/) قبل از ذخیره‌سازی به XPS، تا خروجی دقیقاً شامل صفحات مورد نظر شما باشد.