---
title: مدیریت اسلاید مسترهای ارائه در پایتون
linktitle: اسلاید مستر
type: docs
weight: 80
url: /fa/python-net/slide-master/
keywords:
- اسلاید مستر
- اسلاید مستر
- اسلاید مستر PPT
- اسلایدهای مستر چندگانه
- مقایسه اسلایدهای مستر
- پس‌زمینه
- نگهدارنده
- کلون اسلاید مستر
- کپی اسلاید مستر
- تکثیر اسلاید مستر
- اسلاید مستر استفاده‌نشده
- PowerPoint
- OpenDocument
- ارائه
- پایتون
- Aspose.Slides
description: "مدیریت اسلاید مسترها در Aspose.Slides برای پایتون از طریق .NET: دسترسی، ویرایش، کلون، مقایسه و حذف اسلایدهای مستر در ارائه‌های PowerPoint و OpenDocument."
---
## **بررسی کلی**

یک **اسلاید مستر** تنظیمات طراحی مشترک را برای یک گروه از اسلایدها تعریف می‌کند. می‌تواند شامل شکل‌های عمومی، لوگوها، پس‌زمینه‌ها، سبک‌های متن، تنظیمات تم و تنظیمات پاورقی باشد. در PowerPoint، ویرایش اسلاید مستر روش معمول برای حفظ ثبات ارائه بدون تکرار قالب‌بندی در هر اسلاید است.

Aspose.Slides for Python via .NET نیز همین مدل را پشتیبانی می‌کند. یک ارائه می‌تواند حاوی یک یا چند اسلاید مستر باشد و هر اسلاید مستر می‌تواند چندین اسلاید طرح‌بندی (layout) داشته باشد. اسلایدهای معمولی به‌طور مستقیم به اسلاید مستر ارجاع نمی‌دهند. در عوض، یک اسلاید معمولی از اسلاید طرح‌بندی استفاده می‌کند و آن اسلاید طرح‌بندی به یک اسلاید مستر تعلق دارد.

ساختار سلسله‌مراتبی به‌صورت زیر است:

1. **اسلاید مستر** – تنظیمات طراحی و تم مشترک را تعریف می‌کند.  
2. **اسلاید طرح‌بندی** – چینش خاصی از نگهدارنده‌ها و قالب‌بندی سطح طرح‌بندی را تعیین می‌کند.  
3. **اسلاید معمولی** – محتوای ارائه واقعی را شامل می‌شود و از یک اسلاید طرح‌بندی استفاده می‌کند.

![سلسله‌مراتبی اسلایدهای مستر، طرح‌بندی و معمولی](slide-master_2.jpg)

در Aspose.Slides، اسلاید مستر توسط کلاس [MasterSlide](https://reference.aspose.com/slides/fa/python-net/aspose.slides/masterslide/) نمایندگی می‌شود. تمام اسلایدهای مستر موجود در یک ارائه از طریق مجموعه `Presentation.masters` در دسترس هستند.

{{% alert color="info" title="ارث‌بری" %}}

هنگامی که یک ویژگی در بیش از یک سطح تعریف شده باشد، سطح خاص‌تر برتری می‌یابد. به عنوان مثال، اگر یک اسلاید مستر و یک اسلاید طرح‌بندی هر دو پس‌زمینه‌ای تعریف کنند، اسلایدهای مبتنی بر آن طرح‌بندی از پس‌زمینهٔ طرح‌بندی استفاده می‌کنند. برای اطلاعات بیشتر دربارهٔ اسلایدهای طرح‌بندی، به صفحهٔ [Apply or Change Slide Layouts](/slides/fa/python-net/slide-layout/) مراجعه کنید.

{{% /alert %}}

## **دسترسی به اسلایدهای مستر**

در PowerPoint، می‌توانید نمای اسلاید مستر را از **View > Slide Master** باز کنید.

![دستورات اسلاید مستر در برگهٔ View برنامه PowerPoint](slide-master_3.jpg)

در Aspose.Slides، از مجموعه `masters` برای دسترسی به اسلایدهای مستر استفاده می‌شود:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    first_master_slide = presentation.masters[0]
    master_slide_count = len(presentation.masters)
    first_master_layout_slide_count = len(first_master_slide.layout_slides)

    print("Master slides: " + str(master_slide_count))
    print("Layouts in the first master: " + str(first_master_layout_slide_count))
```

همچنین می‌توانید اسلاید مستری که یک اسلاید معمولی از طریق طرح‌بندی‌اش استفاده می‌کند، به این شکل دریافت کنید:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]
    layout_slide = slide.layout_slide
    master_slide = layout_slide.master_slide
    master_slide_name = master_slide.name

    print(master_slide_name)
```

## **محتوای یک اسلاید مستر**

اسلاید مستر یک شیء شبیه اسلاید است. این شیء رفتارهای مشترک اسلاید را از کلاس [BaseSlide](https://reference.aspose.com/slides/fa/python-net/aspose.slides/baseslide/) به ارث می‌برد، بنابراین بسیاری از ویژگی‌های اسلاید مشابه اسلایدهای معمولی و طرح‌بندی در دسترس است. اعضای مخصوص مستر در صفحهٔ API [MasterSlide](https://reference.aspose.com/slides/fa/python-net/aspose.slides/masterslide/) فهرست شده‌اند.

اعضای رایج اسلاید مستر شامل موارد زیر هستند:

| عضو | هدف |
| --- | --- |
| `background` | تنظیم پس‌زمینهٔ سطح مستر. |
| `shapes` | نگهداری شکل‌های قرار گرفته بر روی مستر، مانند لوگوها، فریم‌های تصویر و متن‌های مشترک. |
| `layout_slides` | نگهداری اسلایدهای طرح‌بندی که به مستر تعلق دارند. |
| `theme_manager` | دسترسی به API‌های تم مستر. |
| `header_footer_manager` | کنترل سرصفحه‌ها، پاورقی‌ها، تاریخ‌ها و شماره اسلاید برای مستر و طرح‌بندی‌های فرزند آن. |
| `get_depending_slides` | بازگرداندن اسلایدهای معمولی که از طریق طرح‌بندی‌هایشان به این مستر وابسته‌اند. |

## **افزودن تصویر به اسلاید مستر**

هنگامی که تصویری را به اسلاید مستر اضافه می‌کنید، در اسلایدهایی که از طرح‌بندی‌های آن مستر استفاده می‌کنند ظاهر می‌شود. این برای لوگوها، واترمارک‌ها، نوارهای تزئینی و سایر عناصر تصویری تکراری مفید است.

مثال زیر یک لوگو را به اولین اسلاید مستر اضافه می‌کند:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    master_slide = presentation.masters[0]

    with open("logo.png", "rb") as logo_stream:
        logo_bytes = logo_stream.read()

    logo_image = presentation.images.add_image(logo_bytes)

    master_slide.shapes.add_picture_frame(
        slides.ShapeType.RECTANGLE,
        20,
        20,
        80,
        80,
        logo_image)

    presentation.save("presentation-with-logo.pptx", slides.export.SaveFormat.PPTX)
```

برای اطلاعات بیشتر دربارهٔ فریم‌های تصویر، به صفحهٔ [Picture Frame](/slides/fa/python-net/picture-frame/) مراجعه کنید.

## **کنترل نمایش گرافیک‌های مستر**

از [BaseSlide.show_master_shapes](https://reference.aspose.com/slides/fa/python-net/aspose.slides/baseslide/show_master_shapes/) برای مخفی کردن گرافیک‌های ارث‌بردهٔ مستر، مانند لوگوها یا شکل‌های تزئینی، بدون حذف آنها از مستر استفاده کنید. بر روی اسلایدی که باید این گرافیک‌ها را حذف کند، ویژگی [Slide.show_master_shapes](https://reference.aspose.com/slides/fa/python-net/aspose.slides/slide/show_master_shapes/) را به `False` تنظیم کنید و بر اسلایدهایی که باید نمایش داده شوند، مقدار `True` بگذارید.

مثال زیر یک نوار تزئینی آبی را بر روی مستر و دو اسلایدی که از همان طرح‌بندی خالی استفاده می‌کنند، ایجاد می‌کند. نوار در اولین اسلاید قابل مشاهده است و در دوم مخفی می‌شود. هیچ ارائه یا تصویر ورودی لازم نیست.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    master_slide = presentation.masters[0]
    layout_slide = master_slide.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)
    layout_slide.show_master_shapes = True

    slide_height = presentation.slide_size.size.height
    band = master_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 0, 0, 60, slide_height)
    band.fill_format.fill_type = slides.FillType.SOLID
    band.fill_format.solid_fill_color.color = draw.Color.steel_blue
    band.line_format.fill_format.fill_type = slides.FillType.NO_FILL

    visible_slide = presentation.slides[0]
    visible_slide.layout_slide = layout_slide
    visible_slide.shapes.clear()

    hidden_slide = presentation.slides.add_empty_slide(layout_slide)

    visible_slide.show_master_shapes = True
    hidden_slide.show_master_shapes = False

    presentation.save("master-graphics.pptx", slides.export.SaveFormat.PPTX)
```

این مثال از طرح‌بندی **Blank** که همراه با یک ارائهٔ جدید فراهم می‌شود استفاده می‌کند و نگهدارنده‌های اولیهٔ اسلاید را حذف می‌کند.

### **انتخاب حوزهٔ تنظیم**

یک اسلاید معمولی از طریق [Slide.layout_slide](https://reference.aspose.com/slides/fa/python-net/aspose.slides/slide/layout_slide/) و [LayoutSlide.master_slide](https://reference.aspose.com/slides/fa/python-net/aspose.slides/layoutslide/master_slide/) به مستر خود دسترسی دارد. تنظیم این ویژگی بر روی یک اسلاید فردی فقط همان اسلاید را تحت تأثیر قرار می‌دهد. تنظیم [LayoutSlide.show_master_shapes](https://reference.aspose.com/slides/fa/python-net/aspose.slides/layoutslide/show_master_shapes/) به `False` گرافیک‌های مستر را برای تمام اسلایدهایی که از آن طرح‌بندی مشترک استفاده می‌کنند، مخفی می‌کند، حتی اگر تنظیم شخصی آنها `True` باشد. برای مخفی کردن گرافیک فقط در یک اسلاید، ویژگی اسلاید را تغییر دهید و طرح‌بندی مشترک را دست‌نخورده بگذارید.

این تنظیم به‌عنوان کنترل نمایش بر روی خود اسلاید مستر پشتیبانی نمی‌شود. روی مستر همیشه مقدار `False` برمی‌گردد و اختصاص `True` منجر به پرتاب استثنا می‌شود. آن را بر روی یک اسلاید معمولی یا یک طرح‌بندی اعمال کنید.

### **تمایز گرافیک‌ها از پس‌زمینه**

| عملیات | اثر |
| --- | --- |
| مخفی کردن گرافیک‌های مستر | نمایش یا عدم نمایش اشکال ارث‌بردهٔ مستر را بدون حذف یا تغییر اشکال خود اسلاید کنترل می‌کند. |
| تغییر رنگ‌پر پس‌زمینهٔ اسلاید | رنگ، گرادیان یا تصویر پس‌زمینه را تغییر می‌دهد. گرافیک‌های مستر اشکال جداگانه‌ای هستند که می‌توانند بر روی آن پس‌زمینه دیده شوند. برای جزئیات بیشتر به صفحهٔ [Presentation Background](/slides/fa/python-net/presentation-background/) مراجعه کنید. |
| حذف یک شکل از مستر | شکل منبع مشترک را حذف می‌کند، به‌طوری که دیگر برای هیچ اسلایدی که از آن مستر استفاده می‌کند، در دسترس نخواهد بود. |

## **کار با نگهدارنده‌ها**

نگهدارنده‌ها معمولاً بر روی اسلایدهای طرح‌بندی تعریف می‌شوند. اسلاید مستر سبک و تم مشترکی را فراهم می‌کند که این طرح‌بندی‌ها از آن ارث می‌برند، در حالی که هر طرح‌بندی تصمیم می‌گیرد کدام نگهدارنده‌ها موجود هستند و در کجا قرار می‌گیرند.

در PowerPoint، دستورات نگهدارنده در نمای اسلاید مستر موجود است.

![دستور Insert Placeholder در نمای اسلاید مستر برنامه PowerPoint](slide-master_5.png)

برای افزودن نگهدارنده‌های جدید با Aspose.Slides، با اسلاید طرح‌بندی که به مستر تعلق دارد کار کنید:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    master_slide = presentation.masters[0]
    blank_layout_slide = master_slide.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    if blank_layout_slide is None:
        blank_layout_slide = presentation.layout_slides.add(
            master_slide,
            slides.SlideLayoutType.BLANK,
            "Blank")

    blank_layout_slide.placeholder_manager.add_text_placeholder(60, 120, 600, 80)

    presentation.slides.add_empty_slide(blank_layout_slide)
    presentation.save("presentation-with-placeholder.pptx", slides.export.SaveFormat.PPTX)
```

همچنین می‌توانید اشکال نگهدارنده‌ای که قبلاً بر روی اسلاید مستر وجود دارد را قالب‌بندی کنید. مثال زیر نگهدارندهٔ عنوان را پیدا کرده و پرکنندهٔ گرادیان خطی را اعمال می‌کند:

```python
import aspose.pydrawing as draw
import aspose.slides as slides


def find_placeholder(master_slide, placeholder_type):
    for shape in master_slide.shapes:
        if isinstance(shape, slides.AutoShape) and shape.placeholder is not None:
            if shape.placeholder.type == placeholder_type:
                return shape

    return None


with slides.Presentation("presentation.pptx") as presentation:
    master_slide = presentation.masters[0]
    title_placeholder = find_placeholder(master_slide, slides.PlaceholderType.TITLE)

    if title_placeholder is not None:
        red_gradient_color = draw.Color.from_argb(255, 0, 0)
        purple_gradient_color = draw.Color.from_argb(128, 0, 128)

        title_placeholder.fill_format.fill_type = slides.FillType.GRADIENT
        title_placeholder.fill_format.gradient_format.gradient_shape = slides.GradientShape.LINEAR
        title_placeholder.fill_format.gradient_format.gradient_stops.add(0, red_gradient_color)
        title_placeholder.fill_format.gradient_format.gradient_stops.add(1, purple_gradient_color)

    presentation.save("presentation-title-style.pptx", slides.export.SaveFormat.PPTX)
```

![نگهدارندهٔ عنوان قالب‌بندی‌شده که توسط اسلایدهای معمولی ارث‌بری می‌شود](slide-master_8.png)

برای گزینه‌های بیشتر مربوط به نگهدارنده و قالب‌بندی متن، به صفحات [Set Prompt Text in Placeholder](/slides/fa/python-net/manage-placeholder/) و [Text Formatting](/slides/fa/python-net/text-formatting/) مراجعه کنید.

## **تغییر پس‌زمینهٔ اسلاید مستر**

پس‌زمینهٔ مستر توسط طرح‌بندی‌ها و اسلایدهایی که آن را بازنویسی نمی‌کنند، ارث‌بری می‌شود. مثال زیر یک رنگ پس‌زمینهٔ ثابت برای اولین اسلاید مستر تنظیم می‌کند:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    master_slide = presentation.masters[0]

    master_slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    master_slide.background.fill_format.fill_type = slides.FillType.SOLID
    master_slide.background.fill_format.solid_fill_color.color = draw.Color.forest_green

    presentation.save("presentation-master-background.pptx", slides.export.SaveFormat.PPTX)
```

برای موضوعات مرتبط، به صفحات [Presentation Background](/slides/fa/python-net/presentation-background/) و [Presentation Theme](/slides/fa/python-net/presentation-theme/) نگاهی بیندازید.

## **کلون کردن اسلاید مستر به ارائهٔ دیگر**

از متد `add_clone` بر روی کلاس [MasterSlideCollection](https://reference.aspose.com/slides/fa/python-net/aspose.slides/masterslidecollection/) برای کپی یک اسلاید مستر به ارائهٔ دیگری استفاده کنید. مستر کپی‌شده سپس می‌تواند توسط طرح‌بندی‌ها و اسلایدهای موجود در ارائهٔ مقصد استفاده شود.

```python
import aspose.slides as slides

with slides.Presentation("source.pptx") as source_presentation:
    with slides.Presentation("destination.pptx") as destination_presentation:
        source_master_slide = source_presentation.masters[0]
        cloned_master_slide = destination_presentation.masters.add_clone(source_master_slide)

        destination_presentation.save("destination-with-master.pptx", slides.export.SaveFormat.PPTX)
```

اگر نیاز به کلون کردن اسلایدهای معمولی همراه با مسترشان دارید، به صفحهٔ [Clone Slides](/slides/fa/python-net/clone-slides/) مراجعه کنید.

## **افزودن چندین اسلاید مستر**

یک ارائه می‌تواند شامل چندین اسلاید مستر باشد. این برای بخش‌هایی که نیاز به برندینگ، ساختار صفحه یا تنظیمات تم متفاوتی دارند، مفید است.

![دستورات PowerPoint برای افزودن و مدیریت اسلایدهای مستر](slide-master_9.jpg)

مثال زیر مستر پیش‌فرض را کلون می‌کند، به کلون پس‌زمینه‌ای متفاوت می‌دهد، یک طرح‌بندی خالی زیر آن مستر کلون‌شده می‌گیرد و یک اسلاید جدید بر پایهٔ آن طرح‌بندی اضافه می‌کند:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    default_master_slide = presentation.masters[0]
    section_master_slide = presentation.masters.add_clone(default_master_slide)

    section_master_slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    section_master_slide.background.fill_format.fill_type = slides.FillType.SOLID
    section_master_slide.background.fill_format.solid_fill_color.color = draw.Color.light_steel_blue

    section_blank_layout = section_master_slide.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    if section_blank_layout is None:
        section_blank_layout = presentation.layout_slides.add(
            section_master_slide,
            slides.SlideLayoutType.BLANK,
            "Section Blank")

    presentation.slides.add_empty_slide(section_blank_layout)
    presentation.save("presentation-with-multiple-masters.pptx", slides.export.SaveFormat.PPTX)
```

## **مقایسه اسلایدهای مستر**

اسلایدهای مستر می‌توانند با متد `equals` که از کلاس [BaseSlide](https://reference.aspose.com/slides/fa/python-net/aspose.slides/baseslide/) ارث برده شده، مقایسه شوند. این مقایسه ساختار و محتوای ثابت مانند اشکال، متن، قالب‌بندی، انیمیشن‌ها و سایر تنظیمات اسلاید را بررسی می‌کند. شناسه‌های یکتا مانند شناسهٔ اسلاید یا مقادیر پویا مانند تاریخ فعلی مقایسه نمی‌شوند.

```python
import aspose.slides as slides

with slides.Presentation("first.pptx") as first_presentation:
    with slides.Presentation("second.pptx") as second_presentation:
        first_presentation_master_count = len(first_presentation.masters)
        second_presentation_master_count = len(second_presentation.masters)

        for first_master_index in range(first_presentation_master_count):
            for second_master_index in range(second_presentation_master_count):
                first_master_slide = first_presentation.masters[first_master_index]
                second_master_slide = second_presentation.masters[second_master_index]
                are_master_slides_equal = first_master_slide.equals(second_master_slide)

                if are_master_slides_equal:
                    print(
                        "first.pptx master #{} equals second.pptx master #{}".format(
                            first_master_index,
                            second_master_index))
```

برای اطلاعات بیشتر، به صفحهٔ [Compare Presentation Slides](/slides/fa/python-net/compare-slides/) مراجعه کنید.

## **تنظیم نمای اسلاید مستر به عنوان نمای پیش‌فرض**

از ویژگی `last_view` بر روی شیء [ViewProperties](https://reference.aspose.com/slides/fa/python-net/aspose.slides/viewproperties/) ارائه برای کنترل نمایی که PowerPoint ابتدا باز می‌کند، استفاده کنید. مثال زیر ارائه را در نمای اسلاید مستر باز می‌کند:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW
    presentation.save("presentation-master-view.pptx", slides.export.SaveFormat.PPTX)
```

برای تنظیمات نمای دیگر، به صفحهٔ [Save Presentation](/slides/fa/python-net/save-presentation/) مراجعه کنید.

## **حذف اسلایدهای مستر استفاده‌ نشده**

گاهی اوقات ارائه‌ها شامل اسلایدهای مستری می‌شوند که دیگر توسط هیچ اسلاید معمولی استفاده نمی‌شوند. حذف مسترهای استفاده‌نشده می‌تواند حجم فایل را کاهش داده و نگهداری قالب‌ها را ساده‌تر کند.

از `remove_unused` برای حذف مسترهای استفاده‌نشده از مجموعه `masters` استفاده کنید:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.masters.remove_unused(True)
    presentation.save("presentation-clean.pptx", slides.export.SaveFormat.PPTX)
```

همچنین می‌توانید از متد کم‌کد `remove_unused_master_slides` در کلاس [Compress](https://reference.aspose.com/slides/fa/python-net/aspose.slides.lowcode/compress/) استفاده کنید:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_master_slides(presentation)
    presentation.save("presentation-clean.pptx", slides.export.SaveFormat.PPTX)
```

## **پرسش‌های متداول**

**فرق اسلاید مستر و اسلاید طرح‌بندی چیست؟**

اسلاید مستر تنظیمات طراحی مشترک مانند تم، پس‌زمینه، شکل‌های عمومی و سبک‌های متن را تعریف می‌کند. اسلاید طرح‌بندی به یک اسلاید مستر تعلق دارد و چینش خاصی از نگهدارنده‌ها را تعیین می‌کند. یک اسلاید معمولی از اسلاید طرح‌بندی استفاده می‌کند، بنابراین از هر دو طرح‌بندی و مستر ارث می‌برد.

**آیا یک ارائه می‌تواند چندین اسلاید مستر داشته باشد؟**

بله. یک ارائه می‌تواند شامل چندین اسلاید مستر باشد. از مسترهای متعدد زمانی استفاده کنید که بخش‌های مختلف نیاز به سیستم‌های بصری یا برندینگ متفاوتی داشته باشند.

**آیا باید نگهدارنده‌ها را به اسلاید مستر یا اسلاید طرح‌بندی اضافه کنم؟**

در اکثر موارد، نگهدارنده‌ها را به اسلایدهای طرح‌بندی اضافه کنید. عناصر بصری مشترک و قالب‌بندی‌های عمومی را روی اسلاید مستر بگذارید و سپس نگهدارنده‌های محتوایی را روی طرح‌بندی‌هایی که اسلایدهای معمولی از آنها استفاده می‌کنند، قرار دهید.

**آیا می‌توانم اسلاید مستری را که هنوز استفاده می‌شود حذف کنم؟**

خیر. اسلاید مستری که اسلایدهای وابسته دارد، نمی‌تواند به‌صورت مستقیم حذف شود. ابتدا آن اسلایدها را به طرح‌بندی‌های تحت مستر دیگر منتقل کنید یا از روش پاک‌سازی مسترهای استفاده‌نشده استفاده کنید که فقط مسترهایی را که در حال استفاده نیستند حذف می‌کند.