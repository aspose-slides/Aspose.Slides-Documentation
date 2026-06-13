---
title: تبدیل ارائه‌ها به GIFهای متحرک در پایتون
linktitle: ارائه به GIF
type: docs
weight: 65
url: /fa/python-net/convert-powerpoint-to-animated-gif/
keywords:
- GIF متحرک
- تبدیل PowerPoint
- تبدیل OpenDocument
- تبدیل ارائه
- تبدیل اسلاید
- تبدیل PPT
- تبدیل PPTX
- تبدیل ODP
- PowerPoint به GIF
- OpenDocument به GIF
- ارائه به GIF
- اسلاید به GIF
- PPT به GIF
- PPTX به GIF
- ODP به GIF
- تنظیمات پیش‌فرض
- تنظیمات سفارشی
- پایتون
- Aspose.Slides
description: "به راحتی ارائه‌های PowerPoint (PPT، PPTX) و فایل‌های OpenDocument (ODP) را به GIFهای متحرک با Aspose.Slides برای پایتون تبدیل کنید. نتایج سریع و با کیفیت بالا."
---
## **مرور کلی**

Aspose.Slides به شما امکان می‌دهد ارائه‌های PowerPoint را به فایل‌های GIF متحرک تبدیل کنید تنها با چند خط کد. این برای زمانی مفید است که نیاز به به‌اشتراک‌گذاری محتوای اسلاید در قالبی سبک، متحرک و با پشتیبانی گسترده دارید که می‌تواند در صفحات وب، پیام‌رسان‌ها یا مستندات جاسازی شود. این مقاله توضیح می‌دهد چگونه یک ارائه را با تنظیمات پیش‌فرض به GIF صادر کنید و چگونه خروجی را با پیکربندی گزینه‌هایی مانند اندازه فریم، تأخیر اسلاید و نرخ فریم انتقال از طریق [GifOptions](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/gifoptions/) سفارشی کنید.

## **تبدیل ارائه‌ها به GIF متحرک با استفاده از تنظیمات پیش‌فرض**

این کد نمونه در پایتون نشان می‌دهد چگونه یک ارائه را به GIF متحرک با استفاده از تنظیمات استاندارد تبدیل کنید:

```py
import aspose.slides as slides

pres = slides.Presentation(path + "pres.pptx")
pres.save("pres.gif", slides.export.SaveFormat.GIF)
```

فایل GIF متحرک با پارامترهای پیش‌فرض ایجاد خواهد شد. 

{{%  alert  title="TIP"  color="primary"  %}} 
اگر ترجیح می‌دهید پارامترهای GIF را سفارشی کنید، می‌توانید از کلاس [GifOptions](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/gifoptions/) استفاده کنید. کد نمونه زیر را ببینید. 
{{% /alert %}} 

## **تبدیل ارائه‌ها به GIF متحرک با استفاده از تنظیمات سفارشی**

این کد نمونه نشان می‌دهد چگونه یک ارائه را با تنظیمات سفارشی در پایتون به GIF متحرک تبدیل کنید:

```py
import aspose.slides as slides
import aspose.pydrawing as drawing

pres = slides.Presentation(path + "pres.pptx")

options = slides.export.GifOptions()
options.frame_size = drawing.Size(960, 720) # اندازه GIF تولید شده
options.default_delay = 2000 # مدت زمانی که هر اسلاید نمایش داده می‌شود تا به اسلاید بعدی تغییر کند
options.transition_fps = 35  # FPS را افزایش دهید تا کیفیت انیمیشن انتقال بهتر شود

pres.save("pres.gif", slides.export.SaveFormat.GIF, options)
```

{{% alert title="Info" color="info" %}}
ممکن است بخواهید مبدل رایگان [Text to GIF](https://products.aspose.app/slides/fa/text-to-gif) که توسط Aspose توسعه یافته است را بررسی کنید. 
{{% /alert %}}

## **سوالات متداول**

**اگر فونت‌های استفاده شده در ارائه بر روی سیستم نصب نشده باشند چه؟**

فونت‌های گمشده را نصب کنید یا [configure fallback fonts](/slides/fa/python-net/powerpoint-fonts/). Aspose.Slides جایگزین خواهد کرد، اما ظاهر ممکن است متفاوت باشد. برای برندینگ، همیشه اطمینان حاصل کنید که قلم‌های مورد نیاز به‌صراحت در دسترس باشند.

**آیا می‌توانم یک watermark را بر روی فریم‌های GIF قرار دهم؟**

بله. [Add a semi-transparent object/logo](/slides/fa/python-net/watermark/) را به اسلاید اصلی یا اسلایدهای فردی قبل از خروجی اضافه کنید — watermark بر روی هر فریم ظاهر خواهد شد.