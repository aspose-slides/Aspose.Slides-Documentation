---
title: "تبدیل ارائه‌های PowerPoint به GIFهای متحرک در C++"
linktitle: "PowerPoint به GIF"
type: docs
weight: 65
url: /fa/cpp/convert-powerpoint-to-animated-gif/
keywords:
- "GIF متحرک"
- "تبدیل PowerPoint"
- "تبدیل ارائه"
- "تبدیل اسلاید"
- "تبدیل PPT"
- "تبدیل PPTX"
- "PowerPoint به GIF"
- "ارائه به GIF"
- "اسلاید به GIF"
- "PPT به GIF"
- "PPTX به GIF"
- "ذخیره PPT به عنوان GIF"
- "ذخیره PPTX به عنوان GIF"
- "صدور PPT به عنوان GIF"
- "صدور PPTX به عنوان GIF"
- "تنظیمات پیش‌فرض"
- "تنظیمات سفارشی"
- "PowerPoint"
- "ارائه"
- "C++"
- "Aspose.Slides"
description: "به راحتی ارائه‌های PowerPoint (PPT, PPTX) را به GIFهای متحرک با Aspose.Slides برای C++ تبدیل کنید. نتایج سریع و با کیفیت بالا."
---
## **بررسی کلی**

Aspose.Slides به شما امکان می‌دهد ارائه‌های PowerPoint را به فایل‌های GIF متحرک با تنها چند خط کد تبدیل کنید. این زمانی مفید است که نیاز دارید محتویات اسلاید را به فرمتی سبک، گسترده‌پذیر و متحرک به اشتراک بگذارید که می‌تواند در صفحات وب، پیام‌رسان‌ها یا مستندات جاسازی شود. این مقاله توضیح می‌دهد چگونه یک ارائه را به GIF با استفاده از تنظیمات پیش‌فرض صادر کنید و چگونه خروجی را با پیکربندی گزینه‌هایی مانند اندازه فریم، تأخیر اسلاید و نرخ فریم انتقال از طریق [GifOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/gifoptions/) سفارشی کنید.

## **تبدیل ارائه‌ها به GIF متحرک با استفاده از تنظیمات پیش‌فرض**

این نمونه کد در C++ نشان می‌دهد چگونه یک ارائه را به GIF متحرک با تنظیمات استاندارد تبدیل کنید:

``` cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.gif", SaveFormat::Gif);
```

GIF متحرک با پارامترهای پیش‌فرض ایجاد خواهد شد.

{{%  alert  title="TIP"  color="info"  %}} 
اگر ترجیح می‌دهید پارامترهای GIF را سفارشی کنید، می‌توانید از کلاس [GifOptions](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.export.gif_options) استفاده کنید. کد نمونه زیر را ببینید. 
{{% /alert %}} 

## **تبدیل ارائه‌ها به GIF متحرک با تنظیمات سفارشی**

این نمونه کد نشان می‌دهد چگونه یک ارائه را به GIF متحرک با تنظیمات سفارشی در C++ تبدیل کنید:

``` cpp
#include <DOM/Presentation.h>
#include <Export/GifOptions.h>
#include <Export/SaveFormat.h>
#include <drawing/size.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto gifOptions = System::MakeObject<GifOptions>();
// اندازه GIF حاصل
gifOptions->set_FrameSize(System::Drawing::Size(960, 720));
// مدت زمان نمایش هر اسلاید تا تغییر به اسلاید بعدی
gifOptions->set_DefaultDelay(2000);
// افزایش FPS برای بهبود کیفیت انیمیشن انتقال
gifOptions->set_TransitionFps(35);

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.gif", SaveFormat::Gif, gifOptions);
```

{{% alert title="Info" color="info" %}}
ممکن است بخواهید یک مبدل رایگان [Text to GIF](https://products.aspose.app/slides/fa/text-to-gif) ساخته‌شده توسط Aspose را بررسی کنید. 
{{% /alert %}}

## **پرسش‌های متداول**

### اگر قلم‌های استفاده‌شده در ارائه بر روی سیستم نصب نباشند چه می‌شود؟

قلم‌های گمشده را نصب کنید یا [پیکربندی قلم‌های جایگزین](/slides/fa/cpp/powerpoint-fonts/). Aspose.Slides جایگزینی انجام خواهد داد، اما ظاهر ممکن است متفاوت باشد. برای برندسازی، همیشه اطمینان حاصل کنید که فونت‌های مورد نیاز به‌صورت صریح در دسترس باشند.

### آیا می‌توانم یک واترمارک بر فریم‌های GIF قرار دهم؟

بله. [افزودن یک شیء/لوگو نیمه‌شفاف](/slides/fa/cpp/watermark/) را به اسلاید اصلی یا به اسلایدهای جداگانه قبل از صادر کردن اضافه کنید — واترمارک در هر فریم ظاهر خواهد شد.