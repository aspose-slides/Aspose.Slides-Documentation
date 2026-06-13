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
- اسلایدهای مستر متعدد
- مقایسه اسلایدهای مستر
- پس‌زمینه
- جای‌گیر
- کلون اسلاید مستر
- کپی اسلاید مستر
- تکرار اسلاید مستر
- اسلاید مستر استفاده‌نشده
- PowerPoint
- OpenDocument
- ارائه
- Python
- Aspose.Slides
description: "مدیریت اسلاید مسترها در Aspose.Slides برای پایتون از طریق .NET: دسترسی، ویرایش، کلون، مقایسه و حذف اسلایدهای مستر در ارائه‌های PowerPoint و OpenDocument."
---
## **مرور کلی**

یک **اسلاید مستر** تنظیمات طراحی مشترک برای گروهی از اسلایدها را تعریف می‌کند. می‌تواند اشکال عمومی، لوگوها، پس‌زمینه‌ها، سبک‌های متنی، تنظیمات تم و تنظیمات پاورقی را شامل شود. در PowerPoint، ویرایش اسلاید مستر روش معمول برای حفظ ثبات یک ارائه بدون تکرار یکسان قالب‌بندی در هر اسلاید است.

Aspose.Slides for Python via .NET همین مدل را پشتیبانی می‌کند. یک ارائه می‌تواند یک یا چند اسلاید مستر داشته باشد و هر اسلاید مستر می‌تواند چندین اسلاید لایه‌بندی (layout) داشته باشد. اسلایدهای عادی معمولاً به‌صورت مستقیم به اسلاید مستر ارجاع نمی‌دهند؛ در عوض، یک اسلاید عادی از یک اسلاید لایه‌بندی استفاده می‌کند و آن لایه‌بندی متعلق به یک اسلاید مستر است.

سلسله‌مراتب به صورت زیر است:

1. **اسلاید مستر** – تنظیمات طراحی و تم مشترک را تعریف می‌کند.  
1. **اسلاید لایه‌بندی** – ترتیب خاصی از جای‌گیرها و قالب‌بندی در سطح لایه‌بندی را تعریف می‌کند.  
1. **اسلاید عادی** – محتوای واقعی ارائه را شامل می‌شود و از یک اسلاید لایه‌بندی استفاده می‌کند.

![سلسله‌مراتب اسلایدهای مستر، لایه‌بندی و عادی](slide-master_2.jpg)

در Aspose.Slides، یک اسلاید مستر توسط کلاس [MasterSlide](https://reference.aspose.com/slides/fa/python-net/aspose.slides/masterslide/) نمایندگی می‌شود. تمام اسلایدهای مستر در یک ارائه از طریق مجموعه `Presentation.masters` در دسترس هستند.

{{% alert color="info" title="Inheritance" %}}

هنگامی که یک ویژگی در بیش از یک سطح تعریف شود، سطح خاص‌تر برتری دارد. به عنوان مثال، اگر یک اسلاید مستر و یک اسلاید لایه‌بندی هر دو پس‌زمینه‌ای تعریف کنند، اسلایدهای مبتنی بر آن لایه‌بندی از پس‌زمینه لایه‌بندی استفاده می‌کنند. برای اطلاعات بیشتر درباره اسلایدهای لایه‌بندی، به [Apply or Change Slide Layouts](/python-net/slide-layout/) مراجعه کنید.

{{% /alert %}}

## **دسترسی به اسلایدهای مستر**

در PowerPoint می‌توانید نمای اسلاید مستر را از **View** > **Slide Master** باز کنید.

![دستورات اسلاید مستر در برگه View برنامه PowerPoint](slide-master_3.jpg)

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

همچنین می‌توانید اسلاید مستری که یک اسلاید عادی از آن استفاده می‌کند را از طریق لایه‌بندی آن به دست آورید:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]
    layout_slide = slide.layout_slide
    master_slide = layout_slide.master_slide
    master_slide_name = master_slide.name

    print(master_slide_name)
```

## **محتویات یک اسلاید مستر**

اسلاید مستر یک شیء شبیه اسلاید است. رفتار عمومی اسلاید را از کلاس [BaseSlide](https://reference.aspose.com/slides/fa/python-net/aspose.slides/baseslide/) به ارث می‌برد، بنابراین بسیاری از ویژگی‌های اسلایدی که توسط اسلایدهای عادی و لایه‌بندی استفاده می‌شود را در اختیار می‌گذارد. اعضای خاص مستر در صفحه API [MasterSlide](https://reference.aspose.com/slides/fa/python-net/aspose.slides/masterslide/) فهرست شده‌اند.

عضوهای معمولاً استفاده‌شده از اسلاید مستر شامل:

| Member | Purpose |
| --- | --- |
| `background` | تنظیم پس‌زمینه در سطح مستر. |
| `shapes` | ذخیره اشکالی که بر روی مستر قرار گرفته‌اند، مانند لوگوها، فریم‌های تصویر و متن‌های مشترک. |
| `layout_slides` | ذخیره اسلایدهای لایه‌بندی که به این مستر تعلق دارند. |
| `theme_manager` | دسترسی به APIهای تم مستر را فراهم می‌کند. |
| `header_footer_manager` | کنترل سرصفحه‌ها، پاورقی‌ها، تاریخ‌ها و شماره اسلایدها برای مستر و لایه‌بندی‌های فرزند آن. |
| `get_depending_slides` | اسلایدهای عادی که از طریق لایه‌بندی‌ها به این مستر وابسته‌اند را برمی‌گرداند. |

## **افزودن تصویر به اسلاید مستر**

هنگامی که تصویری را به یک اسلاید مستر اضافه می‌کنید، در اسلایدهایی که از لایه‌بندی‌های آن مستر استفاده می‌کنند ظاهر می‌شود. این برای لوگوها، علامت‌های آب، باندهای تزئینی و سایر عناصر تصویری تکراری مفید است.

مثال زیر لوگویی را به اولین اسلاید مستر اضافه می‌کند:

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

برای اطلاعات بیشتر درباره فریم‌های تصویر، به [Picture Frame](/python-net/picture-frame/) مراجعه کنید.

## **کار با جای‌گیرها**

جای‌گیرها معمولاً در اسلایدهای لایه‌بندی تعریف می‌شوند. اسلاید مستر سبک و تم مشترکی را که این لایه‌بندی‌ها ارث می‌برند فراهم می‌کند، در حالی که هر لایه‌بندی تصمیم می‌گیرد کدام جای‌گیرها در دسترس هستند و کجا قرار می‌گیرند.

در PowerPoint، دستورات جای‌گیر در نمای اسلاید مستر موجود است.

![دستورات Insert Placeholder در نمای اسلاید مستر PowerPoint](slide-master_5.png)

برای افزودن جای‌گیرهای جدید با Aspose.Slides، با اسلاید لایه‌بندی که به مستر تعلق دارد کار کنید:

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

همچنین می‌توانید اشکال جای‌گیر موجود بر روی یک اسلاید مستر را قالب‌بندی کنید. مثال زیر جای‌گیر عنوان را پیدا کرده و پر رنگ گرادیان خطی اعمال می‌کند:

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
        title_placeholder.fill_format.gradient_format.gradient_stops.add(255, purple_gradient_color)

    presentation.save("presentation-title-style.pptx", slides.export.SaveFormat.PPTX)
```

![جای‌گیر عنوان قالب‌بندی‌شده که توسط اسلایدهای عادی ارث می‌برد](slide-master_8.png)

برای گزینه‌های بیشتر قالب‌بندی جای‌گیر و متن، به [Set Prompt Text in Placeholder](/python-net/manage-placeholder/) و [Text Formatting](/python-net/text-formatting/) مراجعه کنید.

## **تغییر پس‌زمینه اسلاید مستر**

پس‌زمینه مستر توسط لایه‌بندی‌ها و اسلایدهایی که آن را بازنویسی نمی‌کنند، به ارث می‌رود. مثال زیر رنگ پس‌زمینهٔ سالید را برای اولین اسلاید مستر تنظیم می‌کند:

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

برای موضوعات مرتبط، به [Presentation Background](/python-net/presentation-background/) و [Presentation Theme](/python-net/presentation-theme/) مراجعه کنید.

## **کلون کردن یک اسلاید مستر به ارائهٔ دیگر**

از متد `add_clone` در کلاس [MasterSlideCollection](https://reference.aspose.com/slides/fa/python-net/aspose.slides/masterslidecollection/) برای کپی کردن یک اسلاید مستر به ارائهٔ دیگر استفاده کنید. مستر نسخه‌برداری‌شده سپس می‌تواند توسط لایه‌بندی‌ها و اسلایدهای مقصد استفاده شود.

```python
import aspose.slides as slides

with slides.Presentation("source.pptx") as source_presentation:
    with slides.Presentation("destination.pptx") as destination_presentation:
        source_master_slide = source_presentation.masters[0]
        cloned_master_slide = destination_presentation.masters.add_clone(source_master_slide)

        destination_presentation.save("destination-with-master.pptx", slides.export.SaveFormat.PPTX)
```

اگر نیاز به کلون کردن اسلایدهای عادی همراه با مستر آن‌ها دارید، به [Clone Slides](/python-net/clone-slides/) نگاه کنید.

## **افزودن چندین اسلاید مستر**

یک ارائه می‌تواند شامل چندین اسلاید مستر باشد. این هنگامیکه بخش‌های مختلف نیاز به برندینگ، ساختار صفحه یا تنظیمات تم متفاوتی داشته باشند مفید است.

![دستورات PowerPoint برای افزودن و مدیریت اسلایدهای مستر](slide-master_9.jpg)

مثال زیر مستر پیش‌فرض را کلون می‌کند، به کلون پس‌زمینه متفاوتی می‌دهد، یک لایه‌بندی خالی زیر آن مستر کلون‌شده می‌گیرد و سپس یک اسلاید جدید بر پایهٔ آن لایه‌بندی اضافه می‌کند:

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

اسلایدهای مستر می‌توانند با متد `equals` که از کلاس [BaseSlide](https://reference.aspose.com/slides/fa/python-net/aspose.slides/baseslide/) به ارث برده شده است، مقایسه شوند. این مقایسه ساختار و محتوای ثابت مانند اشکال، متن، قالب‌بندی، انیمیشن‌ها و سایر تنظیمات اسلاید را بررسی می‌کند. شناسه‌های یکتا مانند Slide ID یا مقادیر پویا مانند تاریخ جاری مقایسه نمی‌شوند.

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

برای اطلاعات بیشتر، به [Compare Presentation Slides](/python-net/compare-slides/) مراجعه کنید.

## **تنظیم نمای اسلاید مستر به‌عنوان نمای پیش‌فرض**

از ویژگی `last_view` در کلاس [ViewProperties](https://reference.aspose.com/slides/fa/python-net/aspose.slides/viewproperties/) برای کنترل نمایی که PowerPoint ابتدا باز می‌کند، استفاده کنید. مثال زیر ارائه را در نمای اسلاید مستر باز می‌کند:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW
    presentation.save("presentation-master-view.pptx", slides.export.SaveFormat.PPTX)
```

برای تنظیمات نمای بیشتر، به [Save Presentation](/python-net/save-presentation/) مراجعه کنید.

## **حذف اسلایدهای مستر استفاده‌نشده**

گاهی اوقات ارائه‌ها شامل اسلایدهای مستری می‌شوند که دیگر توسط هیچ اسلاید عادی‌ای استفاده نمی‌شوند. حذف مسترهای استفاده‌نشده می‌تواند حجم فایل را کاهش داده و نگهداری قالب‌ها را ساده‌تر کند.

از `remove_unused` برای حذف مسترهای استفاده‌نشده از مجموعه `masters` استفاده کنید:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.masters.remove_unused(True)
    presentation.save("presentation-clean.pptx", slides.export.SaveFormat.PPTX)
```

همچنین می‌توانید از متد کم‌کدی `remove_unused_master_slides` در کلاس [Compress](https://reference.aspose.com/slides/fa/python-net/aspose.slides.lowcode/compress/) بهره ببرید:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_master_slides(presentation)
    presentation.save("presentation-clean.pptx", slides.export.SaveFormat.PPTX)
```

## **پرسش‌های متداول**

**تفاوت اسلاید مستر و اسلاید لایه‌بندی چیست؟**

اسلاید مستر تنظیمات طراحی مشترکی مانند تم، پس‌زمینه، اشکال عمومی و سبک‌های متنی را تعریف می‌کند. اسلاید لایه‌بندی به یک اسلاید مستر تعلق دارد و ترتیب خاصی از جای‌گیرها را تعیین می‌کند. اسلاید عادی از یک اسلاید لایه‌بندی استفاده می‌کند، بنابراین از هر دو لایه‌بندی و مستر ارث می‌برد.

**آیا یک ارائه می‌تواند چندین اسلاید مستر داشته باشد؟**

بله. یک ارائه می‌تواند شامل چندین اسلاید مستر باشد. وقتی بخش‌های مختلف نیاز به سیستم‌های بصری یا برندینگ متفاوت دارند، از مسترهای متعدد استفاده کنید.

**آیا باید جای‌گیرها را به اسلاید مستر یا اسلاید لایه‌بندی اضافه کنم؟**

در اکثر موارد، جای‌گیرها را به اسلایدهای لایه‌بندی اضافه کنید. عناصر بصری مشترک و قالب‌بندی مشترک را بر روی اسلاید مستر بگذارید و سپس جای‌گیرهای محتوا را بر روی لایه‌بندی‌هایی که اسلایدهای عادی استفاده می‌کنند، قرار دهید.

**آیا می‌توانم اسلاید مستری را که هنوز استفاده می‌شود حذف کنم؟**

خیر. اسلاید مستری که اسلایدهای وابسته دارد نمی‌تواند به‌صورت مستقیم حذف شود. ابتدا آن اسلایدها را به لایه‌بندی‌های تحت مستر دیگری منتقل کنید یا از روش پاک‌سازی مسترهای استفاده‌نشده که فقط مسترهای غیرقابله به‌کار استفاده را حذف می‌کند، استفاده کنید.