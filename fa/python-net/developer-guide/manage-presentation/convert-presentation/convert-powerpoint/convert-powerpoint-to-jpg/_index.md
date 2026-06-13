---
title: تبدیل PPT، PPTX و ODP به JPG در پایتون
linktitle: تبدیل اسلایدها به تصاویر JPG
type: docs
weight: 60
url: /fa/python-net/convert-powerpoint-to-jpg/
keywords:
- تبدیل پاورپوینت به JPG
- تبدیل ارائه به JPG
- تبدیل اسلاید به JPG
- تبدیل PPT به JPG
- تبدیل PPTX به JPG
- تبدیل ODP به JPG
- پاورپوینت به JPG
- ارائه به JPG
- اسلاید به JPG
- PPT به JPG
- PPTX به JPG
- ODP به JPG
- تبدیل پاورپوینت به JPEG
- تبدیل ارائه به JPEG
- تبدیل اسلاید به JPEG
- تبدیل PPT به JPEG
- تبدیل PPTX به JPEG
- تبدیل ODP به JPEG
- پاورپوینت به JPEG
- ارائه به JPEG
- اسلاید به JPEG
- PPT به JPEG
- PPTX به JPEG
- ODP به JPEG
- پایتون
- Aspose.Slides
description: "بیاموزید چگونه اسلایدهای خود را از ارائه‌های PowerPoint و OpenDocument به تصاویر JPEG با کیفیت بالا تبدیل کنید تنها با چند خط کد در پایتون. ارائه‌ها را برای استفاده در وب، اشتراک‌گذاری و آرشیو بهینه کنید. راهنمای کامل را هم‌اکنون بخوانید!"
---
## **مقدمه**

تبدیل ارائه‌های PowerPoint و OpenDocument به تصاویر JPG به اشتراک‌گذاری اسلایدها، بهینه‌سازی کارایی و جاسازی محتوا در وب‌سایت‌ها یا برنامه‌ها کمک می‌کند. Aspose.Slides برای Python به شما امکان تبدیل فایل‌های PPTX، PPT و ODP به تصاویر JPEG با کیفیت بالا را می‌دهد. این راهنما روش‌های مختلف تبدیل را توضیح می‌دهد.

با این ویژگی‌ها، پیاده‌سازی نمایشگر سفارشی ارائه و ایجاد تصویر کوچک برای هر اسلاید بسیار ساده می‌شود. این می‌تواند در صورتی مفید باشد که بخواهید اسلایدهای ارائه را از کپی‌برداری محافظت کنید یا ارائه را در حالت فقط‑خواندنی نشان دهید. Aspose.Slides به شما اجازه می‌دهد کل ارائه یا اسلاید خاصی را به فرمت‌های تصویری تبدیل کنید.

## **تبدیل اسلایدهای ارائه به تصاویر JPG**

مراحل تبدیل فایل PPT، PPTX یا ODP به JPG به شرح زیر است:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.
2. شیء اسلاید از نوع [Slide](https://reference.aspose.com/slides/fa/python-net/aspose.slides/slide/) را از مجموعه [Presentation.slides](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/slides/fa/) دریافت کنید.
3. با استفاده از متد [Slide.get_image(scale_x,scale_y)](https://reference.aspose.com/slides/fa/python-net/aspose.slides/slide/get_image/#float-float) یک تصویر از اسلاید ایجاد کنید.
4. متد [IImage.save(filename,format)](https://reference.aspose.com/slides/fa/python-net/aspose.slides/iimage/save/#str-imageformat) را بر روی شیء تصویر فراخوانی کنید. نام فایل خروجی و فرمت تصویر را به عنوان آرگومان‌ها پاس دهید.

{{% alert color="primary" %}}
**توجه:** تبدیل PPT، PPTX یا ODP به JPG متفاوت از تبدیل به سایر فرمت‌ها در API Aspose.Slides Python است. برای سایر فرمت‌ها معمولاً از متد [Presentation.save(fname,format,options)](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/save/#str-asposeslidesexportsaveformat-asposeslidesexportisaveoptions) استفاده می‌کنید. اما برای تبدیل به JPG باید از متد [IImage.save(filename,format)](https://reference.aspose.com/slides/fa/python-net/aspose.slides/iimage/save/#str-imageformat) استفاده کنید.
{{% /alert %}}

```py
import aspose.slides as slides

scale_x = 1
scale_y = scale_x

with slides.Presentation("PowerPoint_Presentation.ppt") as presentation:
    for slide in presentation.slides:
        with slide.get_image(scale_x, scale_y) as thumbnail:
            # تصویر را در فرمت JPEG روی دیسک ذخیره کنید.
            file_name = f"Slide_{slide.slide_number}.jpg"
            thumbnail.save(file_name, slides.ImageFormat.JPEG)
```

## **تبدیل اسلایدها به JPG با ابعاد سفارشی**

برای تغییر ابعاد تصاویر JPG تولید شده می‌توانید اندازه تصویر را با عبور آن به متد [Slide.get_image(image_size)](https://reference.aspose.com/slides/fa/python-net/aspose.slides/slide/get_image/#asposepydrawingsize) تنظیم کنید. این امکان به شما اجازه می‌دهد تصاویر با مقادیر عرض و ارتفاع مشخص تولید کنید تا خروجی با رزولوشن و نسبت تصویر مورد نیاز شما هم‌خوانی داشته باشد. این انعطاف‌پذیری به‌ویژه هنگام تولید تصاویر برای برنامه‌های وب، گزارش‌ها یا مستندات که ابعاد دقیق تصویر ضروری است، مفید است.

```py
import aspose.slides as slides
import aspose.pydrawing as pydrawing

image_size = pydrawing.Size(1200, 800)

with slides.Presentation("PowerPoint_Presentation.pptx") as presentation:
    for slide in presentation.slides:
        # یک تصویر اسلاید با اندازه مشخص ایجاد کنید.
        with slide.get_image(image_size) as thumbnail:
            # تصویر را در فرمت JPEG روی دیسک ذخیره کنید.
            file_name = f"Slide_{slide.slide_number}.jpg"
            thumbnail.save(file_name, slides.ImageFormat.JPEG)
```

## **رندر نظرات هنگام ذخیره اسلایدها به عنوان تصاویر**

Aspose.Slides برای Python ویژگی‌ای ارائه می‌دهد که به شما امکان رندر نظرات روی اسلایدهای یک ارائه را هنگام تبدیل آن‌ها به تصاویر JPG می‌دهد. این قابلیت برای حفظ حواشی، بازخوردها یا بحث‌های اضافه‌شده توسط همکاران در ارائه‌های PowerPoint بسیار مفید است. با فعال‌سازی این گزینه، نظرات در تصاویر تولید شده نمایش داده می‌شوند و بررسی و به‌اشتراک‌گذاری بازخورد بدون نیاز به باز کردن فایل اصلی ارائه آسان‌تر می‌شود.

فرض کنید فایلی به نام "sample.pptx" داریم که شامل اسلایدی با نظرات است:

![The slide with comments](slide_with_comments.png)

کد Python زیر اسلاید را به تصویر JPG تبدیل می‌کند و نظرات را حفظ می‌نماید:

```py
import aspose.slides as slides
import aspose.pydrawing as pydrawing

scale_x = 1
scale_y = scale_x

with slides.Presentation("sample.pptx") as presentation:
    # گزینه‌های نظرات اسلاید را تنظیم کنید.
    comments_options = slides.export.NotesCommentsLayoutingOptions()
    comments_options.comments_position = slides.export.CommentsPositions.RIGHT
    comments_options.comments_area_width = 200
    comments_options.comments_area_color = pydrawing.Color.dark_orange

    options = slides.export.RenderingOptions()
    options.slides_layout_options = comments_options

    # اسلاید اول را به یک تصویر تبدیل کنید.
    with presentation.slides[0].get_image(options, scale_x, scale_y) as thumbnail:
        thumbnail.save("Slide_1.jpg", slides.ImageFormat.JPEG)
```

نتیجه:

![The JPG image with comments](image_with_comments.png)

## **موارد دیگر**

- [تبدیل پاورپوینت به GIF](/slides/fa/python-net/convert-powerpoint-to-animated-gif/)
- [تبدیل پاورپوینت به PNG](/slides/fa/python-net/convert-powerpoint-to-png/)
- [تبدیل پاورپوینت به TIFF](/slides/fa/python-net/convert-powerpoint-to-tiff/)
- [تبدیل پاورپوینت به SVG](/slides/fa/python-net/render-a-slide-as-an-svg-image/)

{{% alert color="primary" %}} 
برای مشاهده نحوه تبدیل PowerPoint به تصاویر JPG توسط Aspose.Slides، این مبدل‌های آنلاین رایگان را امتحان کنید: PowerPoint [PPTX to JPG](https://products.aspose.app/slides/fa/conversion/pptx-to-jpg) و [PPT to JPG](https://products.aspose.app/slides/fa/conversion/ppt-to-jpg). 
{{% /alert %}} 

![مبدل آنلاین رایگان PPTX به JPG](ppt-to-jpg.png)

{{% alert title="Tip" color="primary" %}}
Aspose یک برنامه وب رایگان به نام [FREE Collage web app](https://products.aspose.app/slides/fa/collage) ارائه می‌دهد. با استفاده از این سرویس آنلاین می‌توانید تصاویر [JPG to JPG](https://products.aspose.app/slides/fa/collage/jpg) یا PNG به PNG را ترکیب کنید، [photo grids](https://products.aspose.app/slides/fa/collage/photo-grid) ایجاد کنید و غیره.

با استفاده از همان اصول شرح داده‌شده در این مقاله می‌توانید تصاویر را از یک فرمت به فرمت دیگر تبدیل کنید. برای اطلاعات بیشتر این صفحات را ببینید: تبدیل [image to JPG](https://products.aspose.com/slides/fa/python-net/conversion/image-to-jpg/); تبدیل [JPG to image](https://products.aspose.com/slides/fa/python-net/conversion/jpg-to-image/); تبدیل [JPG to PNG](https://products.aspose.com/slides/fa/python-net/conversion/jpg-to-png/)، تبدیل [PNG to JPG](https://products.aspose.com/slides/fa/python-net/conversion/png-to-jpg/); تبدیل [PNG to SVG](https://products.aspose.com/slides/fa/python-net/conversion/png-to-svg/)، تبدیل [SVG to PNG](https://products.aspose.com/slides/fa/python-net/conversion/svg-to-png/).
{{% /alert %}}

## **پرسش‌های متداول**

**آیا این روش از تبدیل دسته‌ای پشتیبانی می‌کند؟**  
بله، Aspose.Slides امکان تبدیل دسته‌ای چندین اسلاید به JPG را در یک عملیات فراهم می‌کند.

**آیا تبدیل از SmartArt، نمودارها و سایر اشیای پیچیده پشتیبانی می‌کند؟**  
بله، Aspose.Slides تمام محتوا شامل SmartArt، نمودارها، جدول‌ها، اشکال و غیره را رندر می‌کند. با این حال دقت رندر ممکن است نسبت به PowerPoint کمی متفاوت باشد، به‌ویژه هنگام استفاده از فونت‌های سفارشی یا گمشده.

**آیا محدودیتی برای تعداد اسلایدهای قابل پردازش وجود دارد؟**  
Aspose.Slides خود محدودیت سخت‌گیری برای تعداد اسلایدها اعمال نمی‌کند. اما ممکن است با خطای کمبود حافظه هنگام کار با ارائه‌های بزرگ یا تصاویر با رزولوشن بالا مواجه شوید.