---
title: مدیریت جای‌دارهای ارائه در پایتون
linktitle: مدیریت جای‌دارها
type: docs
weight: 10
url: /fa/python-net/manage-placeholder/
keywords:
- جای‌دار
- جای‌دار متن
- جای‌دار تصویر
- جای‌دار نمودار
- جای‌دار محتوا
- متن راهنما
- PowerPoint
- ارائه
- Python
- Aspose.Slides
description: "یاد بگیرید چگونه جای‌دارهای متن، تصویر، نمودار و محتوا را بررسی و ویرایش کنید و وراثت جای‌دارها را با Aspose.Slides برای پایتون از طریق .NET درک کنید."
---
## **مروری کلی**

یک جای‌دار شکلی است که یک موقعیت را برای نوع خاصی از محتوا در قالب ارائه رزرو می‌کند. نمونه‌های رایج شامل عنوان، بدنه، تصویر، نمودار و جای‌دارهای محتوای عمومی هستند. برخلاف یک شکل عادی، یک جای‌دار می‌تواند موقعیت، اندازه، قالب‌بندی و سایر تنظیمات خود را از یک اسلاید طرح‌بندی یا اسلاید مادر به ارث ببرد.

Aspose.Slides اطلاعات جای‌دار را از طریق ویژگی [Shape.placeholder](https://reference.aspose.com/slides/python-net/aspose.slides/shape/placeholder/) ارائه می‌دهد. این ویژگی یک شیء [Placeholder](https://reference.aspose.com/slides/python-net/aspose.slides/placeholder/) یا `None` برای یک شکل عادی برمی‌گرداند. برای تعیین محتوای مورد انتظار جای‌دار از [Placeholder.type](https://reference.aspose.com/slides/python-net/aspose.slides/placeholder/type/) استفاده کنید.

کلاس شکل همچنان پس از دانستن نوع جای‌دار مهم است:

- یک جای‌دار خالی متن، تصویر، نمودار یا محتوا معمولاً توسط یک [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) نمایش داده می‌شود.
- یک جای‌دار تصویر پرشده می‌تواند توسط یک [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) نمایش داده شود.
- یک جای‌دار نمودار پرشده می‌تواند توسط یک [Chart](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/) نمایش داده شود.
- یک جای‌دار محتوا می‌تواند شامل چندین نوع محتوا باشد. به جای فرض اینکه هر جای‌دار یک [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) است، هم [Placeholder.type](https://reference.aspose.com/slides/python-net/aspose.slides/placeholder/type/) و هم کلاس شکل زمان اجرا را بررسی کنید.

{{% alert color="warning" title="Warning" %}}
[Placeholder.type](https://reference.aspose.com/slides/python-net/aspose.slides/placeholder/type/) نقش یک جای‌دار را توصیف می‌کند؛ اما کلاس زمان اجرای شکل را تضمین نمی‌کند. همیشه قبل از دسترسی به اعضای متن، تصویر، نمودار، جدول یا رسانه‌ای، یک بررسی نوع انجام دهید.
{{% /alert %}}

## **درک وراثت جای‌دار**

جای‌دارها یک سلسله‌مراتب تشکیل می‌دهند:

1. یک اسلاید مادر سبک‌های قابل استفاده مجدد را تعریف می‌کند و در برخی موارد، جای‌دارهای سطح مادر را نیز دارد.
2. یک اسلاید طرح‌بندی چیدمان مورد استفاده توسط یک یا چند اسلاید عادی را تعریف می‌کند و می‌تواند از اسلاید مادر ارث بگیرد.
3. یک اسلاید عادی شامل جای‌دارهای آن اسلاید است و می‌تواند از طرح‌بندی خود ارث بگیرد.

برای رفتن یک سطح بالاتر در این سلسله‌مراتب، [Shape.get_base_placeholder](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_base_placeholder/) را فراخوانی کنید. یک جای‌دار اسلاید معمولاً جای‌دار طرح‌بندی خود را برمی‌گرداند؛ یک جای‌دار طرح‌بندی می‌تواند جای‌دار مادر خود را برگرداند. این روش `None` برمی‌گرداند وقتی که شکل پایه‌ای برای جای‌دار ندارد.

مثال زیر جای‌دارهای اسلاید اول را فهرست می‌کند و پایه‌ جای‌دارهای آن‌ها را گزارش می‌دهد:
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

ویرایش یک جای‌دار در اسلاید عادی، یک پوشش محلی برای آن اسلاید ایجاد یا تغییر می‌دهد. ویرایش طرح‌بندی یا اسلاید مادر مرتبط می‌تواند بر تمام اسلایدهایی که هنوز آن تنظیم را ارث می‌برند تأثیر بگذارد. یک شکل عادی محلی پایه‌ای برای جای‌دار ندارد و فقط به این دلیل که در همان مختصات قرار دارد، وراثت شروع نمی‌شود.

## **حذف وضعیت جای‌دار**

هنگام سازگارسازی یک قالب، از [Shape.remove_placeholder](https://reference.aspose.com/slides/python-net/aspose.slides/shape/remove_placeholder/) استفاده کنید تا یک شی موجود را به عنوان یک شکل عادی نگه دارید. ویژگی [placeholder](https://reference.aspose.com/slides/python-net/aspose.slides/shape/placeholder/) آن به `None` تبدیل می‌شود، اما شکل در مجموعه اسلاید باقی می‌ماند. در مقابل، [ShapeCollection.remove](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/remove/) شکل را از آن مجموعه حذف می‌کند.

مثال زیر به فایلی به نام `template.pptx` با حداقل یک اسلاید و یک جای‌دار متن غیر خالی در اسلاید اول نیاز دارد. از یک جای‌دار با قالب‌بندی ارث‌برده از طرح‌بندی یا اسلاید مادر استفاده کنید تا تأثیر حذف آن رابطه را مشاهده کنید. مثال بررسی می‌کند که همان شکل باقی می‌ماند، دوباره متد را بر روی شکل اکنون عادی فراخوانی می‌کند و نتیجه را ذخیره می‌کند.

{{% alert color="warning" title="Warning" %}}
حذف وضعیت جای‌دار به طور خودکار تنظیمات ظاهر ارث‌برده را حفظ نمی‌کند. مثال زیر عمداً این تنظیمات را بدون تغییر می‌گذارد، بنابراین خروجی ممکن است متفاوت به نظر برسد. یک شکل که موقعیت و اندازه‌اش کاملاً ارث‌بری شده باشد می‌تواند پس از فراخوانی مختصات و ابعاد صفر داشته باشد و حتی با باقی‌ماندن در مجموعه، نامرئی شود.
{{% /alert %}}

```python
import aspose.slides as slides

with slides.Presentation("template.pptx") as presentation:
    slide = presentation.slides[0]
    found = False

    for index in range(len(slide.shapes)):
        shape = slide.shapes[index]
        if not isinstance(shape, slides.AutoShape) or shape.placeholder is None:
            continue
        if shape.text_frame is None or not shape.text_frame.text:
            continue

        shape_count = len(slide.shapes)
        shape.remove_placeholder()

        print(f"Placeholder removed: {shape.placeholder is None}")
        print(f"Same shape retained: {slide.shapes[index] == shape}")
        print(f"Shape count unchanged: {len(slide.shapes) == shape_count}")

        # فراخوانی متد بر روی یک شکل عادی هیچ تأثیری ندارد.
        shape.remove_placeholder()
        found = True
        break

    if found:
        presentation.save("placeholder-status-removed.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("No nonempty text placeholder was found on the first slide.")
```

برای یک جای‌دار مطابقت‌دار، هر سه بررسی `True` چاپ می‌شود. متن باقی می‌ماند، اما موقعیت، اندازه، چرخش، قلم، ترازبندی پاراگراف، حاشیه‌های چارچوب متن، لنگر عمودی، پرکننده و تنظیمات خط که به ارث برده‌اند می‌توانند هنگام حذف رابطه جای‌دار تغییر کنند. به عنوان مثال، قالب‌بندی ارث‌برده عنوان ممکن است به قالب‌بندی متن عادی بازگردد. برای اطلاعات بیشتر درباره طرح‌بندی‌ها، به [Slide Layout](/slides/fa/python-net/slide-layout/) مراجعه کنید.

برای حفظ ظاهر مورد نظر، قبل از فراخوانی موقعیت، اندازه و چرخش محاسبه‌شده را ضبط کنید و مقادیر قالب‌بندی مؤثر مورد نیاز را در متغیرهای جداگانه کپی کنید. این مقادیر را از طریق [PortionFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/get_effective/)، [ParagraphFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/get_effective/)، [TextFrameFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/get_effective/)، [FillFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/get_effective/)، و [LineFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/get_effective/) بازیابی کنید. فقط به اشیای قالب‌بندی مؤثر تکیه نکنید، زیرا مقادیر قالب‌بندی متنی آن‌ها پس از حذف رابطه ممکن است تغییر کنند. پس از آن مقادیر ضبط‌شده را به شکل عادی اعمال کنید، از جمله خانواده قلم، اندازه، سبک، رنگ، تنظیمات پاراگراف، تنظیمات چارچوب متن، پرکننده و خط مورد استفاده در قالب شما.

هندسه ارث‌برده شکل ممکن است نیاز به اختصاص صریح از طریق [GeometryShape.shape_type](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/shape_type/) داشته باشد. برای یک جای‌دار متن مستطیلی، این به معنای اختصاص [ShapeType.RECTANGLE](https://reference.aspose.com/slides/python-net/aspose.slides/shapetype/) است؛ بازگرداندن فقط پرکننده و خط ممکن است مستطیل قابل مشاهده را بازسازی نکند. قالب‌های دارای افکت‌های اضافی یا قالب‌بندی پیچیده‌تر نیز نیاز به مدیریت این تنظیمات دارند.

## **تغییر متن در یک جای‌دار**

جای‌دارهای عنوان، عنوان‌متمرکز، زیرعنوان، بدنه و متن معمولاً از متن پشتیبانی می‌کنند. قبل از استفاده از ویژگی [text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/text_frame/) آن، بررسی کنید که آیا آن یک [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) است یا نه.

این مثال اولین جای‌دار عنوان در اسلاید اول را به‌روزرسانی می‌کند و نتیجه را ذخیره می‌نماید:
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

این الگو از رفتار به‌صورت یک [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) برای جای‌دارهای تصویر، نمودار، جدول یا رسانه جلوگیری می‌کند. همچنین جای‌دار را بر اساس هدفش شناسایی می‌کند به جای اتکا به یک ایندکس شکل ناپایدار.

## **تنظیم متن راهنما در یک طرح‌بندی**

متن راهنما دستور طراحی‑زمانی است که در یک جای‌دار خالی نمایش داده می‌شود، مانند *برای افزودن عنوان کلیک کنید*. متن راهنمای سفارشی را بر روی جای‌دار طرح‌بندی تنظیم کنید به‌جای این که سعی کنید آن را از طریق مجموعه شکل‌های اسلاید عادی دسترس پیدا کنید. دسترسی به طرح‌بندی از طریق [Slide.layout_slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/layout_slide/) امکان‌پذیر است و بر روی [LayoutSlide.shapes](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/shapes/) پیمایش کنید.

مثال زیر متن راهنمای عنوان و زیرعنوان را در طرح‌بندی مورد استفاده توسط اسلاید اول تغییر می‌دهد:
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

متن راهنما محتویات اسلاید عادی نیست. برای جای‌دارهای خالی در برنامه‌های ویرایشی مانند PowerPoint در نظر گرفته شده است. وقتی کاربر یا برنامه محتوی واقعی ارائه دهد، راهنما دیگر نمایش داده نمی‌شود. تغییر یک راهنما همچنین متن موجود در اسلایدهایی که از این طرح‌بندی استفاده می‌کنند را جایگزین نمی‌کند.

## **به‌روزرسانی یک جای‌دار تصویر**

دو حالت برای پردازش وجود دارد:

- اگر جای‌دار تصویر از قبل پر شده باشد و توسط یک [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) نشان داده شود، تصویر را از طریق [PictureFillFormat.picture](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/picture/) و [Picture.image](https://reference.aspose.com/slides/python-net/aspose.slides/picture/image/) جایگزین کنید.
- اگر هنوز یک جای‌دار خالی باشد، یک چارچوب تصویر را در مختصات جای‌دار با استفاده از [ShapeCollection.add_picture_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_picture_frame/) اضافه کنید و جای‌دار خالی را حذف کنید.

مثال بعدی هر دو حالت را پشتیبانی می‌کند و ارائه را ذخیره می‌کند:
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

جایگزینی که برای یک جای‌دار خالی ایجاد می‌شود یک چارچوب تصویر محلی است، نه یک جای‌دار جدید، چون ویژگی [Shape.placeholder](https://reference.aspose.com/slides/python-net/aspose.slides/shape/placeholder/) فقط‑خواندنی است. این موقعیت رزروشده را حفظ می‌کند اما دیگر رفتار خاص جای‌دار را ارث نمی‌برد. اگر حفظ رابطه جای‌دار ضروری باشد، ابتدا جای‌دار را در PowerPoint آماده و پر کنید، سپس [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) حاصل را با Aspose.Slides به‌روزرسانی کنید.

برای شفافیت تصویر، برش و دیگر افکت‌های خاص تصویر، به [Manage Picture Frames](/slides/fa/python-net/picture-frame/) مراجعه کنید. این عملیات‌ها به چارچوب تصویر یا پرکننده تصویر تعلق دارند، نه به فراداده‌های جای‌دار.

## **کار با جای‌دارهای نمودار و محتوا**

یک جای‌دار نمودار پرشده می‌تواند توسط یک [Chart](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/) نشان داده شود. این مثال چنین نموداری را هم بر اساس نوع جای‌دار و هم کلاس زمان اجرا پیدا می‌کند، عنوان آن را تغییر می‌دهد و فایل را ذخیره می‌کند:
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

یک جای‌دار محتوا عمومی معمولاً دارای [PlaceholderType.OBJECT](https://reference.aspose.com/slides/python-net/aspose.slides/placeholdertype/) است. در PowerPoint به‌عنوان یک راه‌انداز برای چندین نوع محتوا عمل می‌کند، از جمله نمودارها، جدول‌ها، دیاگرام‌ها، تصاویر و رسانه‌ها. پس از پر شدن، کلاس شکل واقعی را بررسی کنید تا بفهمید چه چیزی دارد. طرح‌بندی‌های تخصصی می‌توانند همچنین [PlaceholderType.CHART](https://reference.aspose.com/slides/python-net/aspose.slides/placeholdertype/)، [PlaceholderType.TABLE](https://reference.aspose.com/slides/python-net/aspose.slides/placeholdertype/), [PlaceholderType.PICTURE](https://reference.aspose.com/slides/python-net/aspose.slides/placeholdertype/), [PlaceholderType.MEDIA](https://reference.aspose.com/slides/python-net/aspose.slides/placeholdertype/), یا [PlaceholderType.DIAGRAM](https://reference.aspose.com/slides/python-net/aspose.slides/placeholdertype/) را نمایش دهند.

Aspose.Slides تنها با تغییر [Placeholder.type](https://reference.aspose.com/slides/python-net/aspose.slides/placeholder/type/) یک جای‌دار [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) خالی را به یک [Chart](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/) تبدیل نمی‌کند؛ نوع فقط‑خواندنی است. برای پر کردن برنامه‌ای یک نمودار یا ناحیه محتوا خالی، شیء مورد نیاز را در مختصات جای‌دار اضافه کنید و سپس جای‌دار خالی را حذف کنید. مثال زیر این کار را برای یک نمودار انجام می‌دهد:
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

نمودار اضافه‌شده یک نمودار محلی عادی است. آن ناحیه جای‌دار را اشغال می‌کند اما از جای‌دار طرح‌بندی ارث نمی‌برد. هنگامی که نیاز به جایگزینی دسته‌ها، سری‌ها یا داده‌های کتاب‌کار دارید، از مقالات اختصاصی مدیریت نمودار [chart management articles](/slides/fa/python-net/powerpoint-charts/) استفاده کنید.

## **مثال کامل: به‌روزرسانی متن یا محتوای تصویر**

مثال انتها‑به‑انتها زیر یک قالب را باز می‌کند، اسلاید اول را برای یک جای‌دار عنوان یا تصویر جستجو می‌کند، نوع جای‌دار و شکل را بررسی می‌کند، محتوای مناسب را به‌روزرسانی می‌کند و خروجی را ذخیره می‌نماید. این مثال عمداً از فرض یک ایندکس شکل یا رفتار همه جای‌دارها به عنوان یک کلاس شکل یکسان صرف‌نظر می‌کند.
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

## **سوالات متداول**

**پایگاه جای‌دار چیست؟**

یک پایه‌ی جای‌دار شکل متناظر بر روی طرح‌بندی یا اسلاید مادر است که یک جای‌دار دیگر از آن ارث می‌برد. برای دریافت آن از [Shape.get_base_placeholder](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_base_placeholder/) استفاده کنید. یک شکل محلی عادی `None` برمی‌گرداند زیرا بخشی از سلسله‌مراتب جای‌دار نیست.

**آیا می‌توانم تمام عناوین اسلایدها را با ویرایش یک جای‌دار طرح‌بندی تغییر دهم؟**

شما می‌توانید قالب‌بندی یا متن راهنمای ارث‌برده را از طریق یک طرح‌بندی تغییر دهید، اما محتوای عنوان موجود در اسلایدهای عادی ذخیره می‌شود. برای جایگزینی متن واقعی عنوان در سراسر ارائه، بر روی اسلایدها تکرار کنید و هر جای‌دار عنوان را به‌روزرسانی کنید.

**چگونه می‌توانم جای‌دارهای تاریخ، شماره اسلاید، هدر و فوتر را مدیریت کنم؟**

از مدیران هدر و فوتر در اسلاید، طرح‌بندی، اسلاید مادر، یادداشت‌ها یا انتشارهای مناسب استفاده کنید. برای مثال‌های کامل به [Manage Presentation Header and Footer](/slides/fa/python-net/presentation-header-and-footer/) مراجعه کنید.