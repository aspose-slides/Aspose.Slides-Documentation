---
title: ایجاد تصویرهای بندانگشتی از اشکال ارائه در Python
linktitle: تصویرهای بندانگشتی شکل
type: docs
weight: 70
url: /fa/python-net/create-shape-thumbnails/
keywords:
- تصویر بندانگشتی شکل
- تصویر شکل
- رندر شکل
- رندرینگ شکل
- مرزهای بصری
- مرزهای شکل
- PowerPoint
- ارائه
- Python
- Aspose.Slides
description: "تصاویر بندانگشتی با کیفیت بالا از اشکال اسلایدهای PowerPoint و OpenDocument با Aspose.Slides برای Python از طریق .NET تولید کنید – به راحتی تصویرهای بندانگشتی ارائه را ایجاد و صادر کنید."
---
## **مقدمه**

Aspose.Slides for Python via .NET برای ایجاد فایل‌های ارائه استفاده می‌شود که در آن هر صفحه یک اسلاید است. می‌توانید این اسلایدها را در Microsoft PowerPoint با باز کردن فایل ارائه مشاهده کنید. اما گاهی توسعه‌دهندگان نیاز دارند تصاویر اشکال را جداگانه در یک مشاهده‌گر تصویر ببینند. در چنین مواردی، Aspose.Slides می‌تواند تصاویر بندانگشتی برای اشکال اسلاید تولید کند. این مقاله نحوه استفاده از این قابلیت را توضیح می‌دهد.

## **تولید بندانگشت‌های شکل از اسلایدها**

وقتی به پیش‌نمایشی از یک شیء خاص به‌جای کل اسلاید نیاز دارید، می‌توانید یک بندانگشت برای یک شکل منفرد رندر کنید. Aspose.Slides به شما اجازه می‌دهد هر شکلی را به تصویر صادر کنید، که ایجاد پیش‌نمایش‌های سبک، آیکون‌ها یا دارایی‌ها برای پردازش‌های بعدی را آسان می‌سازد.

برای تولید یک بندانگشت از هر شکل:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.
1. یک مرجع به اسلایدی با شناسه یا اندیس آن دریافت کنید.
1. یک مرجع به شکلی بر روی آن اسلاید دریافت کنید.
1. تصویر بندانگشتی شکل را رندر کنید.
1. تصویر بندانگشتی را در قالب موردنظر ذخیره کنید.

مثال زیر یک بندانگشت شکل تولید می‌کند.

```py
import aspose.slides as slides

# یک نمونه از کلاس Presentation ایجاد می‌کند تا فایل ارائه را باز کند.
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    
    # یک تصویر با مقیاس پیش‌فرض ایجاد می‌کند.
    with shape.get_image() as thumbnail:
        # تصویر را در قالب PNG روی دیسک ذخیره می‌کند.
        thumbnail.save("shape_thumbnail.png", slides.ImageFormat.PNG)
```

## **تولید بندانگشت‌ها با عامل مقیاس سفارشی**

این بخش نشان می‌دهد چگونه با استفاده از عامل مقیاس تعریف‌شده توسط کاربر در Aspose.Slides، بندانگشت‌های شکل را تولید کنید. با کنترل مقیاس، می‌توانید اندازه بندانگشت را برای پیش‌نمایش‌ها، خروجی‌ها یا نمایشگرهای با وضوح بالا تنظیم دقیق کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.
1. یک اسلاید را با شناسه یا اندیس آن دریافت کنید.
1. شکل هدف را بر روی آن اسلاید دریافت کنید.
1. تصویر بندانگشت شکل را با مقیاس مشخص شده رندر کنید.
1. تصویر بندانگشت را در قالب موردنظر ذخیره کنید.

مثال زیر یک بندانگشت با عامل مقیاس تعریف‌شده توسط کاربر تولید می‌کند.

```py
import aspose.slides as slides

scale_x = 2.0
scale_y = scale_x

# یک نمونه از کلاس Presentation ایجاد می‌کند تا فایل ارائه را باز کند.
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    
    # یک تصویر با مقیاس تعریف‌شده ایجاد می‌کند.
    with shape.get_image(slides.ShapeThumbnailBounds.SHAPE, scale_x, scale_y) as thumbnail:
        # تصویر را در قالب PNG روی دیسک ذخیره می‌کند.
        thumbnail.save("scaling_factor.png", slides.ImageFormat.PNG)
```

## **تولید بندانگشت‌ها با استفاده از مرزهای ظاهر شکل**

این بخش نشان می‌دهد چگونه یک بندانگشت درون مرزهای ظاهر یک شکل تولید شود. این مرزها تمام اثرات شکل را در نظر می‌گیرند. بندانگشت تولیدشده توسط مرزهای اسلاید محدود می‌شود.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.
1. یک اسلاید را با شناسه یا اندیس آن دریافت کنید.
1. شکل هدف را بر روی آن اسلاید دریافت کنید.
1. تصویر بندانگشت شکل را با مرزهای مشخص شده رندر کنید.
1. تصویر بندانگشت را در قالب تصویر موردنظر ذخیره کنید.

مثال زیر یک بندانگشت با مرزهای تعریف‌شده توسط کاربر ایجاد می‌کند.

```py
import aspose.slides as slides

image_bounds = slides.ShapeThumbnailBounds.APPEARANCE

# یک نمونه از کلاس Presentation ایجاد می‌کند تا فایل ارائه را باز کند.
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    # یک تصویر شکل بر اساس مرزهای ظاهر ایجاد می‌کند.
    with shape.get_image(image_bounds, 1.0, 1.0) as thumbnail:
        # تصویر را در قالب PNG روی دیسک ذخیره می‌کند.
        thumbnail.save("apperance_bounds.png", slides.ImageFormat.PNG)
```

## **دریافت مرزهای بصری واقعی یک شکل**

ویژگی‌های قاب یک [Shape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/shape/) —`Shape.x`، `Shape.y`، `Shape.width` و `Shape.height`—مستطیلی را توصیف می‌کنند که در مدل ارائه ذخیره شده است. محتوایی که در واقع رندر می‌شود می‌تواند فراتر از آن قاب گسترش یابد یا مستطیل محور-منطبق متفاوتی را اشغال کند. چرخش، خطوط مرزی، سرهای پیکان، چیدمان متن و سرریز، هندسه SmartArt تولید شده و سایر اثرات رندر می‌توانند مساحت اشغال شده را تغییر دهند.

از [Shape.get_visual_bounds](https://reference.aspose.com/slides/fa/python-net/aspose.slides/shape/get_visual_bounds/) برای محاسبه آن ناحیه اشغال‌شده بدون ایجاد تصویر استفاده کنید. این روش یک مستطیل نقطه‌ی شناور در مختصات اسلاید باز می‌گرداند. مستطیل بازگردانده‌شده به اسلاید قطع نمی‌شود، بنابراین مختصات آن می‌تواند هنگام گسترش محتوا فراتر از مبدأ اسلاید منفی باشد.

مثال زیر قاب و مرزهای بصری را دریافت و مقایسه می‌کند:

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

with slides.Presentation("example.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    visual_bounds = shape.get_visual_bounds()

    frame_values = (shape.x, shape.y, shape.width, shape.height)
    visual_values = (visual_bounds.x, visual_bounds.y, visual_bounds.width, visual_bounds.height)

    print(f"Frame bounds (x, y, width, height): {frame_values}")
    print(f"Visual bounds (x, y, width, height): {visual_values}")
```

همان مستطیل می‌تواند برای ترازبندی اشکال نزدیک به لبه `left`، `right`، `top` یا `bottom` آن، رزرو فضای کافی در یک چیدمان تولیدشده، یا تشخیص محتوای خارج از ناحیه مجاز استفاده شود. مرزهای بصری به‌ویژه برای SmartArt، جعبه‌های متن، پیکان‌ها، تصاویر، اشکال چرخیده و اشکال گروهی مفید هستند، جایی که قاب ذخیره‌شده ممکن است نتیجه رندر کامل را نشان ندهد.

از [Shape.get_visual_bounds](https://reference.aspose.com/slides/fa/python-net/aspose.slides/shape/get_visual_bounds/) وقتی به مختصات برای چیدمان یا اعتبارسنجی نیاز دارید و به بیت‌مپ نیاز ندارید استفاده کنید. وقتی نیاز به رندر کردن شکل دارید، از [Shape.get_image](https://reference.aspose.com/slides/fa/python-net/aspose.slides/shape/get_image/) استفاده کنید. با [ShapeThumbnailBounds](https://reference.aspose.com/slides/fa/python-net/aspose.slides/shapethumbnailbounds/)، `ShapeThumbnailBounds.SHAPE` اندازه تصویر را بر اساس مرزهای شکل، شامل تنظیمات خط مرزی، تعیین می‌کند، در حالی که `ShapeThumbnailBounds.APPEARANCE` اندازه را بر اساس ظاهر شکل می‌گیرد و نتیجه را به مرزهای اسلاید محدود می‌کند. در مقابل، `Shape.get_visual_bounds` فقط مستطیل محاسبه‌شده را برمی‌گرداند و آن را به اسلاید قطع نمی‌کند.

## **سوالات متداول**

**کدام فرمت‌های تصویری می‌توان هنگام ذخیره‌سازی بندانگشت‌های شکل استفاده کرد؟**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/fa/python-net/aspose.slides/imageformat/)، و سایرین. اشکال همچنین می‌توانند به عنوان [SVG برداری صادر شوند](https://reference.aspose.com/slides/fa/python-net/aspose.slides/shape/write_as_svg/) با ذخیره محتوای شکل به صورت SVG.

**تفاوت بین مرزهای SHAPE و APPEARANCE هنگام رندر کردن یک بندانگشت چیست؟**

`SHAPE` از هندسه شکل استفاده می‌کند؛ `APPEARANCE` [اثرهای بصری](/slides/fa/python-net/shape-effect/) (سایه‌ها، تابش‌ها و غیره) را در نظر می‌گیرد.

**اگر یک شکل به‌عنوان مخفی علامت‌گذاری شود چه اتفاقی می‌افتد؟ آیا هنوز به‌عنوان بندانگشت رندر می‌شود؟**

یک شکل مخفی همچنان بخشی از مدل باقی می‌ماند و می‌تواند رندر شود؛ پرچم مخفی فقط نمایش اسلایدشو را تحت تأثیر قرار می‌دهد اما از تولید تصویر شکل جلوگیری نمی‌کند.

**آیا اشکال گروهی، نمودارها، SmartArt و سایر اشیاء پیچیده پشتیبانی می‌شوند؟**

بله. هر شیئی که به عنوان [Shape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/shape/) نشان داده شود (از جمله [GroupShape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/groupshape/)، [Chart](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chart/) و [SmartArt](https://reference.aspose.com/slides/fa/python-net/aspose.slides.smartart/smartart/)) می‌تواند به‌صورت بندانگشت یا SVG ذخیره شود.

**آیا قلم‌های نصب‌شده در سیستم بر کیفیت بندانگشت‌های متنی تأثیر می‌گذارند؟**

بله. شما باید [قلم‌های مورد نیاز را فراهم کنید](/slides/fa/python-net/custom-font/) (یا [جایگزینی قلم‌ها را پیکربندی کنید](/slides/fa/python-net/font-substitution/)) تا از بازگردانی ناخواسته و بازچیدمان متن جلوگیری شود.