---
title: مدیریت الگوهای اسلاید ارائه در پایتون
linktitle: الگوی اسلاید
type: docs
weight: 80
url: /fa/python-net/slide-master/
keywords:
- الگوی اسلاید
- اسلاید الگو
- اسلاید الگوی PPT
- چندین اسلاید الگو
- مقایسه اسلایدهای الگو
- پس‌زمینه
- جای‌نگهدار
- کلون اسلاید الگو
- کپی اسلاید الگو
- تکثیر اسلاید الگو
- اسلاید الگوی استفاده نشده
- PowerPoint
- OpenDocument
- ارائه
- Python
- Aspose.Slides
description: "مدیریت الگوهای اسلاید در Aspose.Slides برای پایتون از طریق .NET: دسترسی، ویرایش، کلون، مقایسه و حذف اسلایدهای الگو در ارائه‌های PowerPoint و OpenDocument."
---
## **نمای کلی**

یک **الگوی اسلاید** تنظیمات طراحی مشترک را برای گروهی از اسلایدها تعریف می‌کند. می‌تواند شامل اشکال مشترک، لوگوها، پس‌زمینه‌ها، سبک‌های متنی، تنظیمات تم و تنظیمات پاورقی باشد. در PowerPoint، ویرایش یک الگوی اسلاید معمول‌ترین روش برای حفظ یکپارچگی ارائه بدون تکرار همان قالب‌بندی در هر اسلاید است.

Aspose.Slides for Python via .NET از همان مدل پشتیبانی می‌کند. یک ارائه می‌تواند حاوی یک یا چند الگوی اسلاید باشد و هر الگوی اسلاید می‌تواند چندین اسلاید چیدمان داشته باشد. اسلایدهای معمولی معمولاً به طور مستقیم به یک الگوی اسلاید ارجاع نمی‌دهند. در عوض، یک اسلاید معمولی از یک اسلاید چیدمان استفاده می‌کند و آن اسلاید چیدمان متعلق به یک الگوی اسلاید است.

سلسله‌مراتب به شرح زیر است:

1. **الگوی اسلاید** - طراحی و تم مشترک را تعریف می‌کند.  
2. **اسلاید چیدمان** - ترتیب خاصی از جای‌نگهدارها و قالب‌بندی سطح چیدمان را تعریف می‌کند.  
3. **اسلاید معمولی** - محتوای واقعی ارائه را شامل می‌شود و از یک اسلاید چیدمان استفاده می‌کند.

![The hierarchy of master slides, layout slides, and normal slides](slide-master_2.jpg)

در Aspose.Slides، یک الگوی اسلاید توسط کلاس [MasterSlide](https://reference.aspose.com/slides/fa/python-net/aspose.slides/masterslide/) نمایان می‌شود. تمام الگوهای اسلاید در یک ارائه از طریق مجموعه `Presentation.masters` در دسترس هستند.

{{% alert color="info" title="ارث‌بری" %}}

زمانی که یک ویژگی در بیش از یک سطح تعریف شود، سطح خاص‌تر برتری دارد. به عنوان مثال، اگر یک الگوی اسلاید و یک اسلاید چیدمان هر دو پس‌زمینه‌ای را تعریف کنند، اسلایدهای مبتنی بر آن چیدمان از پس‌زمینه چیدمان استفاده می‌کنند. برای اطلاعات بیشتر درباره اسلایدهای چیدمان، به [Apply or Change Slide Layouts](/slides/fa/python-net/slide-layout/) مراجعه کنید.

{{% /alert %}}

## **دسترسی به الگوهای اسلاید**

در PowerPoint، می‌توانید نمای الگوی اسلاید را از **View** > **Slide Master** باز کنید.

![The Slide Master command on the PowerPoint View tab](slide-master_3.jpg)

در Aspose.Slides، از مجموعه `masters` برای دسترسی به الگوهای اسلاید استفاده کنید:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    first_master_slide = presentation.masters[0]
    master_slide_count = len(presentation.masters)
    first_master_layout_slide_count = len(first_master_slide.layout_slides)

    print("Master slides: " + str(master_slide_count))
    print("Layouts in the first master: " + str(first_master_layout_slide_count))
```

همچنین می‌توانید الگوی اسلایدی که توسط یک اسلاید معمولی استفاده می‌شود را از طریق چیدمان آن به دست آورید:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]
    layout_slide = slide.layout_slide
    master_slide = layout_slide.master_slide
    master_slide_name = master_slide.name

    print(master_slide_name)
```

## **محتوای یک الگوی اسلاید**

یک الگوی اسلاید یک شی شبیه اسلاید است. این شی رفتار عمومی اسلاید را از کلاس [BaseSlide](https://reference.aspose.com/slides/fa/python-net/aspose.slides/baseslide/) به ارث می‌برد، بنابراین بسیاری از ویژگی‌های اسلایدی که در اسلایدهای معمولی و چیدمان استفاده می‌شود، در دسترس است. اعضای مختص الگو در صفحه API [MasterSlide](https://reference.aspose.com/slides/fa/python-net/aspose.slides/masterslide/) فهرست شده‌اند.

عضوهای رایج الگوی اسلاید شامل:

| Member | Purpose |
| --- | --- |
| `background` | تنظیم پس‌زمینه سطح الگو. |
| `shapes` | اشکالی که بر روی الگو قرار دارند، مانند لوگوها، فریم‌های تصویر و متن‌های مشترک را ذخیره می‌کند. |
| `layout_slides` | اسلایدهای چیدمان متعلق به الگو را نگهداری می‌کند. |
| `theme_manager` | دسترسی به APIهای تم الگو را فراهم می‌کند. |
| `header_footer_manager` | سرصفحه‌ها، پاورقی‌ها، تاریخ‌ها و شماره اسلایدها را برای الگو و چیدمان‌های فرعی آن کنترل می‌کند. |
| `get_depending_slides` | اسلایدهای معمولی که از طریق چیدمان‌هایشان به الگو وابسته هستند را بر می‌گرداند. |

## **اضافه کردن تصویر به الگوی اسلاید**

هنگامی که یک تصویر را به یک الگوی اسلاید اضافه می‌کنید، بر روی اسلایدهایی که از چیدمان‌های آن الگو استفاده می‌کنند نمایش داده می‌شود. این برای لوگوها، واترمارک‌ها، نوارهای تزئینی و سایر عناصر بصری تکراری مفید است.

مثال زیر یک لوگو را به اولین الگوی اسلاید اضافه می‌کند:

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

برای اطلاعات بیشتر درباره فریم‌های تصویر، به [Picture Frame](/slides/fa/python-net/picture-frame/) مراجعه کنید.

## **کار با جای‌نگهدارها**

جای‌نگهدارها معمولاً در اسلایدهای چیدمان تعریف می‌شوند. الگوی اسلاید سبک و تم مشترکی را که آن چیدمان‌ها ارث می‌برند، فراهم می‌کند، در حالی که هر چیدمان تصمیم می‌گیرد کدام جای‌نگهدارها در دسترس هستند و در کجا قرار گرفته‌اند.

در PowerPoint، دستورات جای‌نگهدار در نمای الگوی اسلاید موجود است.

![The Insert Placeholder command in PowerPoint Slide Master view](slide-master_5.png)

برای اضافه کردن جای‌نگهدارهای جدید با Aspose.Slides، با اسلاید چیدمان متعلق به الگو کار کنید:

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

همچنین می‌توانید اشکال جای‌نگهدار موجود در یک الگوی اسلاید را قالب‌بندی کنید. مثال زیر جای‌نگهدار عنوان را پیدا کرده و یک پر رنگ گرادیان خطی اعمال می‌کند:

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

![Formatted title placeholder inherited by normal slides](slide-master_8.png)

برای گزینه‌های بیشتر قالب‌بندی جای‌نگهدار و متن، به [Set Prompt Text in Placeholder](/slides/fa/python-net/manage-placeholder/) و [Text Formatting](/slides/fa/python-net/text-formatting/) مراجعه کنید.

## **تغییر پس‌زمینه یک الگوی اسلاید**

پس‌زمینه الگو توسط چیدمان‌ها و اسلایدهایی که آن را بازنویسی نمی‌کنند، به ارث می‌رسد. مثال زیر رنگ پس‌زمینه ثابت را برای اولین الگوی اسلاید تنظیم می‌کند:

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

برای موضوعات مرتبط، به [Presentation Background](/slides/fa/python-net/presentation-background/) و [Presentation Theme](/slides/fa/python-net/presentation-theme/) نگاه کنید.

## **کپی کردن یک الگوی اسلاید به ارائه‌ای دیگر**

از متد `add_clone` در کلاس [MasterSlideCollection](https://reference.aspose.com/slides/fa/python-net/aspose.slides/masterslidecollection/) استفاده کنید تا یک الگوی اسلاید را به ارائه‌ای دیگر کپی کنید. الگوی کپی‌شده سپس می‌تواند توسط چیدمان‌ها و اسلایدهای هدف استفاده شود.

```python
import aspose.slides as slides

with slides.Presentation("source.pptx") as source_presentation:
    with slides.Presentation("destination.pptx") as destination_presentation:
        source_master_slide = source_presentation.masters[0]
        cloned_master_slide = destination_presentation.masters.add_clone(source_master_slide)

        destination_presentation.save("destination-with-master.pptx", slides.export.SaveFormat.PPTX)
```

اگر نیاز به کپی کردن اسلایدهای معمولی به همراه الگویشان دارید، به [Clone Slides](/slides/fa/python-net/clone-slides/) مراجعه کنید.

## **اضافه کردن چندین الگو به ارائه**

یک ارائه می‌تواند شامل چندین الگوی اسلاید باشد. این برای مواردی مفید است که بخش‌های مختلف نیاز به برندینگ، ساختار صفحه یا تنظیمات تم متفاوتی داشته باشند.

![PowerPoint commands for inserting and managing master slides](slide-master_9.jpg)

مثال زیر الگوی پیش‌فرض را کپی می‌کند، پس‌زمینه متفاوتی به کپی اختصاص می‌دهد، یک چیدمان خالی زیر آن الگوی کپی‌شده دریافت می‌کند و یک اسلاید جدید بر اساس آن چیدمان اضافه می‌کند:

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

## **مقایسه الگوهای اسلاید**

الگوهای اسلاید می‌توانند با متد `equals` که از کلاس [BaseSlide](https://reference.aspose.com/slides/fa/python-net/aspose.slides/baseslide/) به ارث برده شده است، مقایسه شوند. این مقایسه ساختار و محتویات ثابت مانند اشکال، متن، قالب‌بندی، انیمیشن‌ها و دیگر تنظیمات اسلاید را بررسی می‌کند. شناسه‌های یکتا مانند شناسه اسلاید یا مقادیر پویا مانند تاریخ جاری مقایسه نمی‌شوند.

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

برای اطلاعات بیشتر به [Compare Presentation Slides](/slides/fa/python-net/compare-slides/) نگاه کنید.

## **تنظیم نمای الگوی اسلاید به عنوان نمای پیش‌فرض**

از ویژگی `last_view` در کلاس [ViewProperties](https://reference.aspose.com/slides/fa/python-net/aspose.slides/viewproperties/) ارائه استفاده کنید تا نمایی که PowerPoint ابتدا باز می‌کند کنترل شود. مثال زیر ارائه را در نمای الگوی اسلاید باز می‌کند:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW
    presentation.save("presentation-master-view.pptx", slides.export.SaveFormat.PPTX)
```

برای تنظیمات بیشتر نمای، به [Save Presentation](/slides/fa/python-net/save-presentation/) مراجعه کنید.

## **حذف الگوهای اسلایدی که استفاده نمی‌شوند**

گاهی ارائه‌ها شامل الگوهای اسلایدی می‌شوند که دیگر توسط هیچ اسلاید معمولی استفاده نمی‌شوند. حذف الگوهای استفاده‌نشده می‌تواند اندازه فایل را کاهش داده و نگهداری قالب را ساده‌تر کند.

از `remove_unused` برای حذف الگوهای استفاده‌نشده از مجموعه `masters` استفاده کنید:

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

### تفاوت الگوی اسلاید و اسلاید چیدمان چیست؟

الگوی اسلاید تنظیمات طراحی مشترکی مانند تم، پس‌زمینه، اشکال عمومی و سبک‌های متنی را تعریف می‌کند. اسلاید چیدمان به یک الگوی اسلاید تعلق دارد و ترتیب خاصی از جای‌نگهدارها را تعریف می‌کند. یک اسلاید معمولی از یک اسلاید چیدمان استفاده می‌کند، بنابراین از هر دو چیدمان و الگو ارث می‌برد.

### آیا یک ارائه می‌تواند چندین الگوی اسلاید داشته باشد؟

بله. یک ارائه می‌تواند چندین الگوی اسلاید داشته باشد. در زمانی که بخش‌های مختلف به سیستم‌های بصری یا برندینگ متفاوتی نیاز دارند، از چندین الگو استفاده کنید.

### آیا باید جای‌نگهدارها را به الگوی اسلاید اضافه کنم یا به اسلاید چیدمان؟

در اکثر موارد، جای‌نگهدارها را به اسلایدهای چیدمان اضافه کنید. عناصر بصری مشترک و قالب‌بندی‌های مشترک را روی الگوی اسلاید بگذارید، سپس جای‌نگهدارهای محتوا را بر روی چیدمان‌هایی که اسلایدهای معمولی استفاده می‌کنند، قرار دهید.

### آیا می‌توانم یک الگوی اسلاید که هنوز استفاده می‌شود را حذف کنم؟

خیر. یک الگوی اسلاید که اسلایدهای وابسته دارد، به‌صورت مستقیم نمی‌تواند به‌صورت امن حذف شود. ابتدا آن اسلایدها را به چیدمان‌های زیر یک الگوی دیگر منتقل کنید یا از روش پاک‌سازی الگوهای استفاده‌نشده که تنها الگوهای بدون استفاده را حذف می‌کند، استفاده نمایید.