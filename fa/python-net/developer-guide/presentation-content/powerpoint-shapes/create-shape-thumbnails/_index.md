---
title: ایجاد تصویرهای بندانگشتی از اشکال ارائه در پایتون
linktitle: بندانگشتی‌های شکل
type: docs
weight: 70
url: /fa/python-net/create-shape-thumbnails/
keywords:
- بندانگشتی شکل
- تصویر شکل
- رندر شکل
- رندر کردن شکل
- پاورپوینت
- ارائه
- پایتون
- Aspose.Slides
description: "تصاویر بندانگشتی با کیفیت بالا از اشکال اسلایدهای PowerPoint و OpenDocument با Aspose.Slides برای Python از طریق .NET ایجاد کنید – به راحتی تصویرهای بندانگشتی ارائه را ایجاد و صادر کنید."
---
## **مقدمه**

Aspose.Slides برای Python از طریق .NET برای ایجاد فایل‌های ارائه استفاده می‌شود که هر صفحه آن یک اسلاید است. می‌توانید این اسلایدها را در Microsoft PowerPoint با باز کردن فایل ارائه مشاهده کنید. اما گاهی توسعه‌دهندگان ممکن است نیاز داشته باشند تصاویر اشکال را به‌صورت جداگانه در یک نمایشگر تصویر ببینند. در چنین مواردی، Aspose.Slides می‌تواند تصاویر بندانگشتی برای اشکال اسلاید تولید کند. این مقاله نحوه استفاده از این ویژگی را توضیح می‌دهد.

## **تولید تصویر بندانگشت اشکال از اسلایدها**

وقتی به پیش‌نمایش یک شیء خاص به جای کل اسلاید نیاز دارید، می‌توانید تصویر بندانگشت برای یک شکل واحد تولید کنید. Aspose.Slides به شما امکان می‌دهد هر شکل را به تصویر صادر کنید و پیش‌نمایش‌های سبک، آیکون‌ها یا دارایی‌های پردازش بعدی را به‌راحتی ایجاد کنید.

برای تولید تصویر بندانگشت از هر شکل:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.
1. یک ارجاع به اسلاید را بر اساس شناسه یا شاخص آن دریافت کنید.
1. یک ارجاع به یک شکل روی آن اسلاید دریافت کنید.
1. تصویر بندانگشت شکل را رندر کنید.
1. تصویر بندانگشت را با فرمت مورد نظر ذخیره کنید.

مثال زیر یک تصویر بندانگشت شکل تولید می‌کند.

```py
import aspose.slides as slides

# نمونه سازی کلاس Presentation برای باز کردن فایل ارائه.
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    
    # ایجاد یک تصویر با مقیاس پیش‌فرض.
    with shape.get_image() as thumbnail:
        # ذخیره تصویر در دیسک با فرمت PNG.
        thumbnail.save("shape_thumbnail.png", slides.ImageFormat.PNG)
```

## **تولید تصویر بندانگشت با فاکتور مقیاس سفارشی**

این بخش نشان می‌دهد چگونه می‌توان تصویر بندانگشت اشکال را با فاکتور مقیاس تعریف‌شده توسط کاربر در Aspose.Slides تولید کرد. با کنترل مقیاس می‌توانید اندازه تصویر بندانگشت را برای پیش‌نمایش‌ها، صادرات یا نمایشگرهای با وضوح بالا تنظیم دقیق کنید.

برای تولید تصویر بندانگشت برای هر شکل روی اسلاید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.
1. یک اسلاید را بر اساس شناسه یا شاخص آن دریافت کنید.
1. شکل هدف را روی آن اسلاید دریافت کنید.
1. تصویر بندانگشت شکل را با مقیاس مشخص رندر کنید.
1. تصویر بندانگشت را با فرمت مورد نظر ذخیره کنید.

مثال زیر یک تصویر بندانگشت با فاکتور مقیاس تعریف‌شده توسط کاربر تولید می‌کند.

```py
import aspose.slides as slides

scale_x = 2.0
scale_y = scale_x

# نمونه‌سازی کلاس Presentation برای باز کردن فایل ارائه.
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    
    # ایجاد یک تصویر با مقیاس تعریف‌شده.
    with shape.get_image(slides.ShapeThumbnailBounds.SHAPE, scale_x, scale_y) as thumbnail:
        # ذخیره تصویر در دیسک با فرمت PNG.
        thumbnail.save("scaling_factor.png", slides.ImageFormat.PNG)
```

## **تولید تصویر بندانگشت با استفاده از مرزهای ظاهر شکل**

این بخش نشان می‌دهد چگونه می‌توان تصویر بندانگشتی درون مرزهای ظاهر یک شکل تولید کرد. این روش تمام اثرات شکل را در نظر می‌گیرد. تصویر بندانگشت تولید شده توسط مرزهای اسلاید محدود می‌شود.

 برای تولید تصویر بندانگشت هر شکل اسلاید درون مرزهای ظاهر آن:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.
1. یک اسلاید را بر اساس شناسه یا شاخص آن دریافت کنید.
1. شکل هدف را روی آن اسلاید دریافت کنید.
1. تصویر بندانگشت شکل را با مرزهای مشخص رندر کنید.
1. تصویر بندانگشت را با فرمت تصویر مورد نظر ذخیره کنید.

مثال زیر یک تصویر بندانگشت با مرزهای تعریف‌شده توسط کاربر ایجاد می‌کند.

```py
import aspose.slides as slides

image_bounds = slides.ShapeThumbnailBounds.APPEARANCE

# نمونه‌سازی کلاس Presentation برای باز کردن فایل ارائه.
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    # ایجاد تصویر شکل با مرزهای ظاهر.
    with shape.get_image(image_bounds, 1.0, 1.0) as thumbnail:
        # ذخیره تصویر در دیسک با فرمت PNG.
        thumbnail.save("apperance_bounds.png", slides.ImageFormat.PNG)
```

## **سؤالات متداول**

**کدام فرمت‌های تصویر می‌توانند هنگام ذخیره‌سازی تصویر بندانگشت اشکال استفاده شوند؟**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/fa/python-net/aspose.slides/imageformat/)، و سایر فرمت‌ها. همچنین می‌توان اشکال را به‌صورت [صادر به‌صورت SVG برداری](https://reference.aspose.com/slides/fa/python-net/aspose.slides/shape/write_as_svg/) با ذخیره محتوای شکل به‌عنوان SVG.

**تفاوت بین مرزهای SHAPE و APPEARANCE هنگام رندر تصویر بندانگشت چیست؟**

`SHAPE` از هندسه شکل استفاده می‌کند؛ `APPEARANCE` اثرات [اثرات بصری](/slides/fa/python-net/shape-effect/) (سایه‌ها، درخشندگی‌ها و غیره) را در نظر می‌گیرد.

**اگر یک شکل به‌عنوان مخفی علامت‌گذاری شود چه می‌شود؟ آیا همچنان به‌عنوان تصویر بندانگشت رندر می‌شود؟**

یک شکل مخفی همچنان بخشی از مدل است و می‌تواند رندر شود؛ پرچم مخفی فقط نمایش اسلایدشو را تحت تأثیر قرار می‌دهد اما مانع تولید تصویر شکل نمی‌شود.

**آیا اشکال گروهی، نمودارها، SmartArt و سایر اشیای پیچیده پشتیبانی می‌شوند؟**

بله. هر شیئی که به‌عنوان [Shape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/shape/) (از جمله [GroupShape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/groupshape/)، [Chart](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chart/) و [SmartArt](https://reference.aspose.com/slides/fa/python-net/aspose.slides.smartart/smartart/)) نمایان می‌شود می‌تواند به‌صورت تصویر بندانگشت یا SVG ذخیره شود.

**آیا فونت‌های نصب‌شده در سیستم بر کیفیت تصویر بندانگشت‌های اشکال متنی تأثیر می‌گذارند؟**

بله. باید [فونت‌های مورد نیاز را فراهم کنید](/slides/fa/python-net/custom-font/) (یا [پیکربندی جایگزینی فونت‌ها](/slides/fa/python-net/font-substitution/)) تا از بازگشت ناخواسته و تغییر قالب‌بندی متن جلوگیری شود.