---
title: مدیریت Placeholderها در Python
linktitle: مدیریت Placeholderها
type: docs
weight: 10
url: /fa/python-net/manage-placeholder/
keywords:
- محل‌نگهدار
- محل‌نگهدار متن
- محل‌نگهدار تصویر
- محل‌نگهدار نمودار
- محل‌نگهدار محتوا
- متن راهنما
- پاورپوینت
- ارائه
- پایتون
- Aspose.Slides
description: "یاد بگیرید چگونه placeholderهای متن، تصویر، نمودار و محتوا را بررسی و ویرایش کنید و ارث‌بری placeholderها را با Aspose.Slides برای پایتون از طریق .NET درک نمایید."
---
## **مرور کلی**

یک placeholder شکل است که برای یک نوع خاص از محتوا در قالب ارائه یک موقعیت را رزرو می‌کند. مثال‌های رایج شامل placeholderهای عنوان، بدنه، تصویر، نمودار و placeholderهای محتوای عمومی هستند. برخلاف یک شکل معمولی، یک placeholder می‌تواند موقعیت، اندازه، قالب‌بندی و سایر تنظیمات خود را از اسلاید چیدمان یا اسلاید اصلی به ارث برد.

Aspose.Slides اطلاعات placeholder را از طریق ویژگی [Shape.placeholder](https://reference.aspose.com/slides/fa/python-net/aspose.slides/shape/placeholder/) در دسترس قرار می‌دهد. این ویژگی یک شیء [Placeholder](https://reference.aspose.com/slides/fa/python-net/aspose.slides/placeholder/) یا `None` برای یک شکل معمولی برمی‌گرداند. برای تعیین آنچه placeholder قرار است شامل شود از [Placeholder.type](https://reference.aspose.com/slides/fa/python-net/aspose.slides/placeholder/type/) استفاده کنید.

کلاس شکل همچنان پس از دانستن نوع placeholder مهم است:

- یک placeholder خالی متن، تصویر، نمودار یا محتوا معمولاً توسط یک [AutoShape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/autoshape/) نشان داده می‌شود.
- یک placeholder تصویر پرشده می‌تواند توسط یک [PictureFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/pictureframe/) نمایان شود.
- یک placeholder نمودار پرشده می‌تواند توسط یک [Chart](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chart/) نمایش داده شود.
- یک placeholder محتوا می‌تواند چندین نوع محتوا را در خود داشته باشد. به جای فرض اینکه هر placeholder یک [AutoShape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/autoshape/) است، هم [Placeholder.type](https://reference.aspose.com/slides/fa/python-net/aspose.slides/placeholder/type/) و هم کلاس شکل در زمان اجرا را بررسی کنید.

{{% alert color="warning" title="Warning" %}}
[Placeholder.type](https://reference.aspose.com/slides/fa/python-net/aspose.slides/placeholder/type/) نقش یک placeholder را توصیف می‌کند؛ اما کلاس شکل در زمان اجرا را تضمین نمی‌کند. همیشه قبل از دسترسی به اعضای متن، تصویر، نمودار، جدول یا رسانه نوع را بررسی کنید.
{{% /alert %}}

## **درک ارث‌بری Placeholder**

Placeholderها سلسله‌مراتی تشکیل می‌دهند:

1. یک اسلاید اصلی استایل‌های قابل استفاده مجدد و در برخی موارد placeholderهای سطح‑مستر را تعریف می‌کند.
2. یک اسلاید چیدمان چیدمانی را که توسط یک یا چند اسلاید معمولی استفاده می‌شود تعریف می‌کند و می‌تواند از مستر ارث ببرد.
3. یک اسلاید معمولی placeholderهای خود را دارد و می‌تواند از چیدمان خود ارث ببرد.

برای حرکت یک سطح بالاتر در این سلسله‌مرات، [Shape.get_base_placeholder](https://reference.aspose.com/slides/fa/python-net/aspose.slides/shape/get_base_placeholder/) را فراخوانی کنید. یک placeholder اسلاید معمولاً placeholder چیدمان خود را برمی‌گرداند؛ یک placeholder چیدمان می‌تواند placeholder مستر خود را برگرداند. این متد وقتی شکل پایه‌ای ندارد `None` برمی‌گرداند.

مثال زیر placeholderهای اسلاید اول را فهرست می‌کند و placeholderهای پایهٔ آن‌ها را گزارش می‌دهد:

```python
import aspose.slides as slides

with slides.Presentation("template.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if shape.placeholder is None:
            continue

        placeholder_type = shape.placeholder.type
        type_name = type(shape).__name__
        print(f"Slide placeholder: {placeholder_type}; shape class: {type_name}")

        layout_placeholder = shape.get_base_placeholder()
        if layout_placeholder is not None:
            layout_placeholder_type = layout_placeholder.placeholder.type if layout_placeholder.placeholder is not None else None
            print(f"  Layout placeholder: {layout_placeholder_type}")

            master_placeholder = layout_placeholder.get_base_placeholder()
            if master_placeholder is not None:
                master_placeholder_type = master_placeholder.placeholder.type if master_placeholder.placeholder is not None else None
                print(f"  Master placeholder: {master_placeholder_type}")
```

ویرایش یک placeholder در اسلاید معمولی باعث ایجاد یا تغییر یک لغو محلی برای آن اسلاید می‌شود. ویرایش چیدمان یا مستر مرتبط می‌تواند بر تمام اسلایدهایی که هنوز آن تنظیم را ارث می‌برند تأثیر بگذارد. یک شکل معمولی محلی پایهٔ placeholder ندارد و صرفاً به دلیل داشتن همان مختصات، ارث‌بری آغاز نمی‌شود.

## **تغییر متن در Placeholder**

placeholderهای عنوان، centered‑title، subtitle، body و متن معمولاً از متن پشتیبانی می‌کنند. پیش از استفاده از ویژگی [text_frame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/autoshape/text_frame/) حتماً بررسی کنید که شکل یک [AutoShape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/autoshape/) است.

این مثال ابتدا عنوان اولین placeholder در اسلاید اول را به‌روزرسانی می‌کند و نتیجه را ذخیره می‌نماید:

```python
import aspose.slides as slides

with slides.Presentation("template.pptx") as presentation:
    slide = presentation.slides[0]
    title_shape = None

    for shape in slide.shapes:
        if not isinstance(shape, slides.AutoShape) or shape.placeholder is None:
            continue

        placeholder_type = shape.placeholder.type
        if placeholder_type in (slides.PlaceholderType.TITLE, slides.PlaceholderType.CENTERED_TITLE):
            title_shape = shape
            break

    if title_shape is None:
        raise RuntimeError("The first slide does not contain a title placeholder.")

    title_shape.text_frame.text = "Quarterly Business Review"
    presentation.save("title-placeholder-updated.pptx", slides.export.SaveFormat.PPTX)
```

این الگو از برخورد با placeholderهای تصویر، نمودار، جدول یا رسانه به عنوان اشیای [AutoShape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/autoshape/) جلوگیری می‌کند و به‌جای وابستگی به ایندکس ناپایدار، placeholder را بر اساس هدفش شناسایی می‌نماید.

## **تنظیم متن راهنمایی در Layout**

متن راهنمایی (Prompt text) دستور طراحی زمان اجرا است که در یک placeholder خالی نمایش داده می‌شود، مانند *Click to add title*. متن راهنمای سفارشی را بر روی placeholder چیدمان تنظیم کنید نه این‌که سعی کنید از طریق مجموعهٔ شکلهای اسلاید معمولی به آن دسترسی پیدا کنید. چیدمان را از طریق [Slide.layout_slide](https://reference.aspose.com/slides/fa/python-net/aspose.slides/slide/layout_slide/) دریافت کنید و بر روی [LayoutSlide.shapes](https://reference.aspose.com/slides/fa/python-net/aspose.slides/baseslide/shapes/) پیمایش کنید.

مثال زیر متن‌های راهنمای عنوان و زیرعنوان را در چیدمانی که توسط اسلاید اول استفاده می‌شود تغییر می‌دهد:

```python
import aspose.slides as slides

with slides.Presentation("template.pptx") as presentation:
    layout_slide = presentation.slides[0].layout_slide

    for shape in layout_slide.shapes:
        if not isinstance(shape, slides.AutoShape) or shape.placeholder is None:
            continue

        placeholder_type = shape.placeholder.type

        if placeholder_type in (slides.PlaceholderType.TITLE, slides.PlaceholderType.CENTERED_TITLE):
            shape.text_frame.text = "Enter a concise slide title"
        elif placeholder_type == slides.PlaceholderType.SUBTITLE:
            shape.text_frame.text = "Enter a subtitle or reporting period"

    presentation.save("custom-placeholder-prompts.pptx", slides.export.SaveFormat.PPTX)
```

متن راهنمایی محتوی اسلاید معمولی نیست؛ برای placeholderهای خالی در برنامه‌های ویرایشی مانند PowerPoint طراحی شده است. وقتی کاربر یا برنامه محتوا واقعی را فراهم می‌کند، متن راهنمای دیگر نمایش داده نمی‌شود. تغییر راهنمایی متن موجود در اسلایدهای استفاده‌کننده از چیدمان را جایگزین نمی‌کند.

## **به‌روزرسانی یک Picture Placeholder**

دو حالت برای پردازش وجود دارد:

- اگر picture placeholder قبلاً پر شده باشد و توسط یک [PictureFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/pictureframe/) نشان داده می‌شود، تصویر را از طریق [PictureFillFormat.picture](https://reference.aspose.com/slides/fa/python-net/aspose.slides/picturefillformat/picture/) و [Picture.image](https://reference.aspose.com/slides/fa/python-net/aspose.slides/picture/image/) جایگزین کنید.
- اگر هنوز یک placeholder خالی است، یک picture frame را در مختصات placeholder با استفاده از [ShapeCollection.add_picture_frame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/shapecollection/add_picture_frame/) اضافه کنید و placeholder خالی را حذف کنید.

مثال بعدی هر دو حالت را پشتیبانی می‌کند و ارائه را ذخیره می‌نماید:

```python
import aspose.slides as slides

with slides.Presentation("picture-template.pptx") as presentation:
    slide = presentation.slides[0]
    picture_placeholder = None

    for shape in slide.shapes:
        if shape.placeholder is not None and shape.placeholder.type == slides.PlaceholderType.PICTURE:
            picture_placeholder = shape
            break

    if picture_placeholder is None:
        raise RuntimeError("The first slide does not contain a picture placeholder.")

    with open("replacement.png", "rb") as image_stream:
        image_bytes = image_stream.read()

    image = presentation.images.add_image(image_bytes)

    if isinstance(picture_placeholder, slides.PictureFrame):
        picture_placeholder.picture_format.picture.image = image
    else:
        slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, picture_placeholder.x, picture_placeholder.y, picture_placeholder.width, picture_placeholder.height, image)
        slide.shapes.remove(picture_placeholder)

    presentation.save("picture-placeholder-updated.pptx", slides.export.SaveFormat.PPTX)
```

جایگزینی که برای یک placeholder خالی ساخته می‌شود، یک picture frame محلی است، نه یک placeholder جدید، زیرا [Shape.placeholder](https://reference.aspose.com/slides/fa/python-net/aspose.slides/shape/placeholder/) فقط‑خواندنی است. این کار موقعیت رزرو شده را حفظ می‌کند اما دیگر رفتار خاص placeholder را به ارث نمی‌برد. اگر حفظ رابطهٔ placeholder ضروری است، ابتدا در PowerPoint placeholder را آماده و پر کنید، سپس با Aspose.Slides [PictureFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/pictureframe/) حاصل را به‌روزرسانی کنید.

برای شفافیت تصویر، برش و سایر افکت‌های خاص تصویر به مقالهٔ [Manage Picture Frames](/slides/fa/python-net/picture-frame/) مراجعه کنید. این عملیات مربوط به picture frame یا picture fill است، نه به متادادهٔ placeholder.

## **کار با Chart و Content Placeholderها**

یک chart placeholder پرشده می‌تواند توسط یک [Chart](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chart/) نمایش داده شود. این مثال چنین نموداری را هم بر اساس نوع placeholder و هم بر اساس کلاس زمان اجرا می‌یابد، عنوان آن را تغییر می‌دهد و فایل را ذخیره می‌کند:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart-template.pptx") as presentation:
    slide = presentation.slides[0]
    placeholder_chart = None

    for shape in slide.shapes:
        if isinstance(shape, charts.Chart) and shape.placeholder is not None and shape.placeholder.type == slides.PlaceholderType.CHART:
            placeholder_chart = shape
            break

    if placeholder_chart is None:
        raise RuntimeError("The first slide does not contain a populated chart placeholder.")

    placeholder_chart.has_title = True
    placeholder_chart.chart_title.add_text_frame_for_overriding("Quarterly Revenue")
    presentation.save("chart-placeholder-updated.pptx", slides.export.SaveFormat.PPTX)
```

یک placeholder محتوای کلی معمولاً دارای [PlaceholderType.OBJECT](https://reference.aspose.com/slides/fa/python-net/aspose.slides/placeholdertype/) است. در PowerPoint به‌عنوان راه‌اندازی‌کننده‌ای برای چندین نوع محتوا، از جمله نمودارها، جداول، دیاگرام‌ها، تصاویر و رسانه‌ها عمل می‌کند. پس از پر شدن، کلاس شکل واقعی را بررسی کنید تا متوجه شوید چه چیزی در آن وجود دارد. چیدمان‌های تخصصی می‌توانند همچنین [PlaceholderType.CHART](https://reference.aspose.com/slides/fa/python-net/aspose.slides/placeholdertype/)، [PlaceholderType.TABLE](https://reference.aspose.com/slides/fa/python-net/aspose.slides/placeholdertype/)، [PlaceholderType.PICTURE](https://reference.aspose.com/slides/fa/python-net/aspose.slides/placeholdertype/)، [PlaceholderType.MEDIA](https://reference.aspose.com/slides/fa/python-net/aspose.slides/placeholdertype/)، یا [PlaceholderType.DIAGRAM](https://reference.aspose.com/slides/fa/python-net/aspose.slides/placeholdertype/) را در بر داشته باشند.

Aspose.Slides یک [AutoShape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/autoshape/) خالی را صرف تغییر [Placeholder.type](https://reference.aspose.com/slides/fa/python-net/aspose.slides/placeholder/type/) به یک [Chart](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chart/) تبدیل نمی‌کند؛ این ویژگی فقط‑خواندنی است. برای پر کردن برنامه‌ای یک ناحیهٔ خالی نمودار یا محتوا، شیء مورد نیاز را در مختصات placeholder اضافه کنید و سپس placeholder خالی را حذف کنید. مثال زیر این کار را برای یک نمودار انجام می‌دهد:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("content-template.pptx") as presentation:
    slide = presentation.slides[0]
    target_placeholder = None

    for shape in slide.shapes:
        if shape.placeholder is None:
            continue

        if shape.placeholder.type in (slides.PlaceholderType.CHART, slides.PlaceholderType.OBJECT):
            target_placeholder = shape
            break

    if target_placeholder is None:
        raise RuntimeError("The first slide does not contain a chart or content placeholder.")

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, target_placeholder.x, target_placeholder.y, target_placeholder.width, target_placeholder.height)
    chart.has_title = True
    chart.chart_title.add_text_frame_for_overriding("Quarterly Revenue")
    slide.shapes.remove(target_placeholder)
    presentation.save("content-placeholder-replaced-with-chart.pptx", slides.export.SaveFormat.PPTX)
```

نمودار اضافه شده یک نمودار محلی عادی است. این نمودار ناحیهٔ placeholder را اشغال می‌کند اما از placeholder چیدمان ارث نمی‌برد. برای جایگزینی دسته‌بندی‌ها، سری‌ها یا داده‌های کاربرگ آن، از مقالات ویژهٔ مدیریت نمودارهای PowerPoint در [chart management articles](/slides/fa/python-net/powerpoint-charts/) استفاده کنید.

## **مثال کامل: به‌روزرسانی متن یا محتوی تصویر**

مثال پایان‑به‑پایان زیر یک قالب را باز می‌کند، اسلاید اول را برای پیدا کردن یک placeholder عنوان یا تصویر جستجو می‌کند، نوع placeholder و شکل را بررسی می‌کند، محتوی مناسب را به‌روزرسانی می‌کند و خروجی را ذخیره می‌نماید. این مثال عمداً از فرض وجود ایندکس شکل یا رفتار یکسان تمام placeholderها اجتناب می‌کند.

```python
import aspose.slides as slides

with slides.Presentation("template.pptx") as presentation:
    slide = presentation.slides[0]
    updated = False

    for shape in slide.shapes:
        if shape.placeholder is None:
            continue

        placeholder_type = shape.placeholder.type

        if placeholder_type in (slides.PlaceholderType.TITLE, slides.PlaceholderType.CENTERED_TITLE) and isinstance(shape, slides.AutoShape):
            shape.text_frame.text = "Quarterly Business Review"
            updated = True
            break

        if placeholder_type == slides.PlaceholderType.PICTURE:
            with open("replacement.png", "rb") as image_stream:
                image_bytes = image_stream.read()

            image = presentation.images.add_image(image_bytes)

            if isinstance(shape, slides.PictureFrame):
                shape.picture_format.picture.image = image
            else:
                slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, shape.x, shape.y, shape.width, shape.height, image)
                slide.shapes.remove(shape)

            updated = True
            break

    if not updated:
        raise RuntimeError("No supported title or picture placeholder was found on the first slide.")

    presentation.save("placeholder-content-updated.pptx", slides.export.SaveFormat.PPTX)
```

## **سؤالات متداول**

**Placeholder پایه چیست؟**

Placeholder پایه، شکل متناظر موجود در چیدمان یا مستری است که از آن placeholder دیگر ارث می‌برد. برای دریافت آن از [Shape.get_base_placeholder](https://reference.aspose.com/slides/fa/python-net/aspose.slides/shape/get_base_placeholder/) استفاده کنید. یک شکل محلی عادی `None` برمی‌گرداند زیرا بخشی از سلسله‌مرات placeholder نیست.

**آیا می‌توانم تمام عناوین اسلایدها را با ویرایش یک placeholder در layout تغییر دهم؟**

می‌توانید قالب‌بندی یا متن راهنمای ارث‌برده را از طریق layout تغییر دهید، اما محتوای عنوان موجود در اسلایدهای معمولی ذخیره شده است. برای جایگزینی واقعی متن عنوان در سراسر ارائه، بر روی اسلایدها پیمایش کنید و هر placeholder عنوان را به‌روزرسانی کنید.

**چگونه می‌توانم placeholderهای تاریخ، شماره اسلاید، سرآیند و پانویس را مدیریت کنم؟**

از مدیران سرآیند و پانویس در سطح اسلاید، layout، master، notes یا handout استفاده کنید. برای مثال‌های کامل به مقالهٔ [Manage Presentation Header and Footer](/slides/fa/python-net/presentation-header-and-footer/) مراجعه کنید.