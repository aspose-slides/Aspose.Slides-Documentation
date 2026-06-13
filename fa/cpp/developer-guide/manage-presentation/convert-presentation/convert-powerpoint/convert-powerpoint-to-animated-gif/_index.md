---
title: تبدیل ارائه‌های PowerPoint به GIF‌های انیمیشنی در C++
linktitle: PowerPoint به GIF
type: docs
weight: 65
url: /fa/cpp/convert-powerpoint-to-animated-gif/
keywords:
  - GIF انیمیشنی
  - تبدیل PowerPoint
  - تبدیل ارائه
  - تبدیل اسلاید
  - تبدیل PPT
  - تبدیل PPTX
  - PowerPoint به GIF
  - ارائه به GIF
  - اسلاید به GIF
  - PPT به GIF
  - PPTX به GIF
  - ذخیره PPT به صورت GIF
  - ذخیره PPTX به صورت GIF
  - استخراج PPT به GIF
  - استخراج PPTX به GIF
  - تنظیمات پیش‌فرض
  - تنظیمات سفارشی
  - PowerPoint
  - ارائه
  - C++
  - Aspose.Slides
description: "به راحتی ارائه‌های PowerPoint (PPT، PPTX) را به GIF‌های انیمیشنی با Aspose.Slides برای C++ تبدیل کنید. نتایج سریع و با کیفیت بالا."
---
## **Overview**

Aspose.Slides به شما امکان می‌دهد ارائه‌های PowerPoint را به فایل‌های GIF انیمیشنی تنها با چند خط کد تبدیل کنید. این ویژگی زمانی مفید است که بخواهید محتوای اسلایدها را در قالبی سبک، با پشتیبانی گسترده و قابلیت تعبیه در صفحات وب، پیام‌رسان‌ها یا مستندات به اشتراک بگذارید. این مقاله نحوه استخراج یک ارائه به صورت GIF با تنظیمات پیش‌فرض و همچنین نحوه سفارشی‌سازی خروجی از طریق تنظیم گزینه‌هایی مانند اندازه فریم، تاخیر اسلاید و نرخ فریم انتقال با استفاده از [GifOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/gifoptions/) را توضیح می‌دهد.

## **Convert Presentations to Animated GIF Using Default Settings**

این قطعه‌کد نمونه در C++ نشان می‌دهد چگونه یک ارائه را با تنظیمات استاندارد به GIF انیمیشنی تبدیل کنید:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.gif", SaveFormat::Gif);
```

GIF انیمیشنی با پارامترهای پیش‌فرض ایجاد خواهد شد. 

{{%  alert  title="TIP"  color="primary"  %}} 

اگر مایل به سفارشی‌سازی پارامترهای GIF باشید، می‌توانید از کلاس [GifOptions](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.export.gif_options) استفاده کنید. کد نمونه زیر را ببینید. 

{{% /alert %}} 

## **Convert Presentations to Animated GIF Using Custom Settings**

این قطعه‌کد نمونه نشان می‌دهد چگونه یک ارائه را با تنظیمات سفارشی در C++ به GIF انیمیشنی تبدیل کنید:

``` cpp
auto gifOptions = System::MakeObject<GifOptions>();
// اندازه GIF تولید شده 
gifOptions->set_FrameSize(Size(960, 720));
// مدت زمانی که هر اسلاید نمایش داده می‌شود تا به اسلاید بعدی تغییر کند
gifOptions->set_DefaultDelay(2000);
// افزایش FPS برای بهبود کیفیت انیمیشن انتقال
gifOptions->set_TransitionFps(35);

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.gif", SaveFormat::Gif, gifOptions);
```

{{% alert title="Info" color="info" %}}

شاید بخواهید یک مبدل **FREE** [Text to GIF](https://products.aspose.app/slides/fa/text-to-gif) تولید شده توسط Aspose را بررسی کنید. 

{{% /alert %}}

## **FAQ**

**اگر فونت‌های استفاده شده در ارائه روی سیستم نصب نباشند چه می‌شود؟**

فونت‌های گمشده را نصب کنید یا [fallback fonts را پیکربندی](/slides/fa/cpp/powerpoint-fonts/) کنید. Aspose.Slides سعی می‌کند جایگزین کند، اما ممکن است ظاهر متفاوت باشد. برای برندینگ، همیشه اطمینان حاصل کنید که نوع‌پوست‌های مورد نیاز به‌صورت صریح در دسترس باشند.

**آیا می‌توانم یک واترمارک روی فریم‌های GIF اضافه کنم؟**

بله. می‌توانید یک شیء/لوگوی نیمه‌شفاف را به اسلاید مادر یا به اسلایدهای جداگانه قبل از استخراج اضافه کنید — واترمارک در هر فریم نمایش داده خواهد شد.