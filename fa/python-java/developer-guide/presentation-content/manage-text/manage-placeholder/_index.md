---
title: مدیریت جایگزین‌های ارائه در پایتون
linktitle: مدیریت جایگزین‌ها
type: docs
weight: 10
url: /fa/python-java/manage-placeholder/
keywords:
- جایگزین
- جایگزین متن
- جایگزین تصویر
- جایگزین نمودار
- جایگزین محتوا
- متن راهنما
- PowerPoint
- ارائه
- پایتون
- جاوا
- Aspose.Slides
description: "یاد بگیرید چگونه جایگزین‌های متن، تصویر، نمودار و محتوا را بررسی و ویرایش کنید و وراثت جایگزین‌ها را با Aspose.Slides برای پایتون از طریق جاوا درک کنید."
---
## **بررسی کلی**

یک جایگزین (Placeholder) شکلی است که موقعیتی را برای یک نوع خاص از محتوا در قالب ارائه رزرو می‌کند. نمونه‌های رایج شامل عنوان، بدنه، تصویر، نمودار و جایگزین‌های محتوا با کاربرد عمومی هستند. برخلاف یک شکل معمولی، یک جایگزین می‌تواند موقعیت، اندازه، قالب‌بندی و سایر تنظیمات خود را از یک اسلاید چیدمان یا اسلاید اصلی به ارث ببرد.

Aspose.Slides اطلاعات جایگزین را از طریق متد [Shape.getPlaceholder](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shape/#getPlaceholder) ارائه می‌کند. این متد یک شیء [Placeholder](https://reference.aspose.com/slides/fa/python-java/aspose.slides/placeholder/) یا `None` برای یک شکل عادی برمی‌گرداند. برای تعیین این‌که جایگزین برای چه محتوایی در نظر گرفته شده است، از [Placeholder.getType](https://reference.aspose.com/slides/fa/python-java/aspose.slides/placeholder/#getType) استفاده کنید.

نوع شکل همچنان پس از دانستن نوع جایگزین اهمیت دارد:

- یک جایگزین خالی متن، تصویر، نمودار یا محتوا معمولاً توسط یک [AutoShape](https://reference.aspose.com/slides/fa/python-java/aspose.slides/autoshape/) نمایش داده می‌شود.
- یک جایگزین تصویر پرشده می‌تواند توسط یک [PictureFrame](https://reference.aspose.com/slides/fa/python-java/aspose.slides/pictureframe/) نمایش داده شود.
- یک جایگزین نمودار پرشده می‌تواند توسط یک [Chart](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chart/) نمایش داده شود.
- یک جایگزین محتوا می‌تواند انواع مختلفی از محتوا را در خود داشته باشد. به جای این‌که فرض کنید هر جایگزین یک [AutoShape](https://reference.aspose.com/slides/fa/python-java/aspose.slides/autoshape/) است، هم [Placeholder.getType](https://reference.aspose.com/slides/fa/python-java/aspose.slides/placeholder/#getType) و هم نوع شکل در زمان اجرا را بررسی کنید.

{{% alert color="warning" title="Warning" %}}
[Placeholder.getType](https://reference.aspose.com/slides/fa/python-java/aspose.slides/placeholder/#getType) نقش یک جایگزین را توصیف می‌کند؛ اما نوع شکل در زمان اجرا را تضمین نمی‌کند. همیشه قبل از دسترسی به اعضای متنی، تصویری، نموداری، جدولی یا رسانه‌ای، یک بررسی نوع انجام دهید.
{{% /alert %}}

## **درک وراثت جایگزین‌ها**

جایگزین‌ها یک سلسله‌مراتب تشکیل می‌دهند:

1. یک اسلاید اصلی (master) سبک‌های قابل استفاده مجدد و در برخی موارد جایگزین‌های سطح master را تعریف می‌کند.
2. یک اسلاید چیدمان (layout) چیدمان استفاده‌شده توسط یک یا چند اسلاید عادی را تعریف می‌کند و می‌تواند از master ارث‌بری کند.
3. یک اسلاید عادی شامل جایگزین‌های آن اسلاید است و می‌تواند از چیدمان خود ارث‌بری کند.

برای رفتن یک سطح بالاتر در این سلسله‌مراتب، متد [Shape.getBasePlaceholder](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shape/#getBasePlaceholder) را فراخوانی کنید. یک جایگزین اسلاید معمولاً جایگزین چیدمان خود را برمی‌گرداند؛ یک جایگزین چیدمان می‌تواند جایگزین master خود را برگرداند. این متد زمانی که شکل هیچ جایگزین پایه‌ای نداشته باشد، `None` برمی‌گرداند.

مثال زیر جایگزین‌های اسلاید اول را فهرست می‌کند و جایگزین‌های پایه آن‌ها را گزارش می‌دهد:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        placeholder = shape.getPlaceholder()
        if placeholder is None:
            continue

        placeholder_type = placeholder.getType()
        type_name = shape.getClass().getSimpleName()
        print(f"Slide placeholder: {placeholder_type}; shape type: {type_name}")

        layout_placeholder = shape.getBasePlaceholder()
        if layout_placeholder is not None:
            layout_placeholder_info = layout_placeholder.getPlaceholder()
            layout_placeholder_type = None if layout_placeholder_info is None else layout_placeholder_info.getType()
            print(f"  Layout placeholder: {layout_placeholder_type}")

            master_placeholder = layout_placeholder.getBasePlaceholder()
            if master_placeholder is not None:
                master_placeholder_info = master_placeholder.getPlaceholder()
                master_placeholder_type = None if master_placeholder_info is None else master_placeholder_info.getType()
                print(f"  Master placeholder: {master_placeholder_type}")
finally:
    presentation.dispose()
```

ویرایش یک جایگزین در اسلاید عادی، یک بازنویسی محلی برای آن اسلاید ایجاد یا تغییر می‌دهد. ویرایش چیدمان یا master مرتبط می‌تواند تمام اسلایدهایی را که هنوز آن تنظیم را ارث می‌برند، تحت تاثیر قرار دهد. یک شکل عادی محلی هیچ جایگزین پایه‌ای ندارد و صرفاً به دلیل قرارگیری در همان مختصات شروع به وراثت نمی‌کند.

## **تغییر متن در یک جایگزین**

جایگزین‌های عنوان، عنوان-مرکز، زیرعنوان، بدنه و متن معمولاً از متن پشتیبانی می‌کنند. قبل از استفاده از متد [getTextFrame](https://reference.aspose.com/slides/fa/python-java/aspose.slides/autoshape/#getTextFrame) آن، بررسی کنید که شکل یک [AutoShape](https://reference.aspose.com/slides/fa/python-java/aspose.slides/autoshape/) است.

این مثال اولین جایگزین عنوان در اسلاید اول را به‌روز می‌کند و نتیجه را ذخیره می‌نماید:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, AutoShape, PlaceholderType, SaveFormat

presentation = Presentation("template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    title_shape = None

    for shape in slide.getShapes():
        if not isinstance(shape, AutoShape):
            continue

        placeholder = shape.getPlaceholder()
        if placeholder is None:
            continue

        placeholder_type = placeholder.getType()
        if placeholder_type in (PlaceholderType.Title, PlaceholderType.CenteredTitle):
            title_shape = shape
            break

    if title_shape is None:
        print("The first slide does not contain a title placeholder.")
    else:
        title_shape.getTextFrame().setText("Quarterly Business Review")
        presentation.save("title-placeholder-updated.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

این الگو از رفتار treating picture, chart, table, or media placeholders as [AutoShape](https://reference.aspose.com/slides/fa/python-java/aspose.slides/autoshape/) جلوگیری می‌کند. همچنین جایگزین را بر اساس هدف شناسایی می‌کند نه بر اساس یک ایندکس شکل ناپایدار.

## **تنظیم متن راهنما در یک چیدمان**

متن راهنما (Prompt text) دستور طراحی‑زمانی است که در یک جایگزین خالی نمایش داده می‌شود، مانند *Click to add title*. متن راهنمای سفارشی را بر روی جایگزین چیدمان تنظیم کنید نه این‌که سعی کنید از طریق مجموعه شکل‌های اسلاید عادی به آن دسترسی پیدا کنید. به چیدمان از طریق [Slide.getLayoutSlide](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slide/#getLayoutSlide) دسترسی پیدا کنید و بر روی مجموعه‌ای که توسط [BaseSlide.getShapes](https://reference.aspose.com/slides/fa/python-java/aspose.slides/baseslide/#getShapes) بازگردانده می‌شود، تکرار کنید.

مثال زیر عنوان و زیرعنوان راهنما را در چیدمان استفاده‌شده توسط اسلاید اول تغییر می‌دهد:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, AutoShape, PlaceholderType, SaveFormat

presentation = Presentation("template.pptx")
try:
    layout_slide = presentation.getSlides().get_Item(0).getLayoutSlide()

    for shape in layout_slide.getShapes():
        if not isinstance(shape, AutoShape):
            continue

        placeholder = shape.getPlaceholder()
        if placeholder is None:
            continue

        placeholder_type = placeholder.getType()
        if placeholder_type in (PlaceholderType.Title, PlaceholderType.CenteredTitle):
            shape.getTextFrame().setText("Enter a concise slide title")
        elif placeholder_type == PlaceholderType.Subtitle:
            shape.getTextFrame().setText("Enter a subtitle or reporting period")

    presentation.save("custom-placeholder-prompts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

متن راهنما محتویات اسلاید عادی نیست. این متن برای جایگزین‌های خالی در برنامه‌های ویرایشی مانند PowerPoint در نظر گرفته شده است. هنگامی که کاربر یا برنامه محتوای واقعی را وارد می‌کند، متن راهنما دیگر نمایش داده نمی‌شود. تغییر یک راهنما نیز متن موجود در اسلایدهای استفاده‌کننده از چیدمان را جایگزین نمی‌کند.

## **به‌روزرسانی یک جایگزین تصویر**

دو حالت برای پردازش وجود دارد:

- اگر جایگزین تصویر قبلاً پر شده باشد و توسط یک [PictureFrame](https://reference.aspose.com/slides/fa/python-java/aspose.slides/pictureframe/) نمایش داده می‌شود، تصویر را از طریق [PictureFillFormat.getPicture](https://reference.aspose.com/slides/fa/python-java/aspose.slides/picturefillformat/#getPicture) و [Picture.setImage](https://reference.aspose.com/slides/fa/python-java/aspose.slides/picture/#setImage) جایگزین کنید.
- اگر هنوز یک جایگزین خالی باشد، با استفاده از [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shapecollection/#addPictureFrame) یک فریم تصویر در مختصات جایگزین اضافه کنید و جایگزین خالی را حذف کنید.

مثال زیر هر دو حالت را پشتیبانی می‌کند و ارائه را ذخیره می‌نماید:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, PictureFrame, PlaceholderType, ShapeType, SaveFormat

presentation = Presentation("picture-template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    picture_placeholder = None

    for shape in slide.getShapes():
        placeholder = shape.getPlaceholder()
        if placeholder is not None and placeholder.getType() == PlaceholderType.Picture:
            picture_placeholder = shape
            break

    if picture_placeholder is None:
        print("The first slide does not contain a picture placeholder.")
    else:
        image_bytes = Path("replacement.png").read_bytes()
        java_image_bytes = jpype.JArray(jpype.JByte)(image_bytes)
        image = presentation.getImages().addImage(java_image_bytes)

        if isinstance(picture_placeholder, PictureFrame):
            picture_placeholder.getPictureFormat().getPicture().setImage(image)
        else:
            slide.getShapes().addPictureFrame(ShapeType.Rectangle, picture_placeholder.getX(), picture_placeholder.getY(), picture_placeholder.getWidth(), picture_placeholder.getHeight(), image)
            slide.getShapes().remove(picture_placeholder)

        presentation.save("picture-placeholder-updated.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

جایگزینی که برای یک جایگزین خالی ایجاد می‌شود، یک فریم تصویر محلی است، نه یک جایگزین جدید، زیرا [Shape.getPlaceholder](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shape/#getPlaceholder) setter‌ای ارائه نمی‌دهد. این فریم موقعیت رزرو شده را حفظ می‌کند اما دیگر رفتار ویژه جایگزین را به ارث نمی‌برد. اگر حفظ رابطه جایگزین ضروری است، ابتدا جایگزین را در PowerPoint آماده و پر کنید و سپس [PictureFrame](https://reference.aspose.com/slides/fa/python-java/aspose.slides/pictureframe/) حاصل را با Aspose.Slides به‌روزرسانی کنید.

برای شفافیت تصویر، برش و سایر اثرات خاص تصویر، به مقاله [Manage Picture Frames](/slides/fa/python-java/picture-frame/) مراجعه کنید. این عملیات‌ها به فریم تصویر یا پرکن تصویر تعلق دارند، نه به metadata جایگزین.

## **کار با جایگزین‌های نمودار و محتوا**

یک جایگزین نمودار پرشده می‌تواند توسط یک [Chart](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chart/) نمایش داده شود. این مثال چنین نموداری را هم بر اساس نوع جایگزین و هم بر اساس نوع زمان اجرا پیدا می‌کند، عنوان آن را تغییر می‌دهد و فایل را ذخیره می‌کند:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Chart, PlaceholderType, SaveFormat

presentation = Presentation("chart-template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    placeholder_chart = None

    for shape in slide.getShapes():
        if not isinstance(shape, Chart):
            continue

        placeholder = shape.getPlaceholder()
        if placeholder is not None and placeholder.getType() == PlaceholderType.Chart:
            placeholder_chart = shape
            break

    if placeholder_chart is None:
        print("The first slide does not contain a populated chart placeholder.")
    else:
        placeholder_chart.setTitle(True)
        placeholder_chart.getChartTitle().addTextFrameForOverriding("Quarterly Revenue")
        presentation.save("chart-placeholder-updated.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

یک جایگزین محتوا عمومی معمولاً دارای [PlaceholderType.Object](https://reference.aspose.com/slides/fa/python-java/aspose.slides/placeholdertype/#Object) است. در PowerPoint به‌عنوان یک راه‌انداز برای چندین نوع محتوا عمل می‌کند، از جمله نمودارها، جداول، دیاگرام‌ها، تصاویر و رسانه‌ها. پس از پر شدن، نوع شکل واقعی را بررسی کنید تا بفهمید چه چیزی در آن قرار دارد. چیدمان‌های ویژه می‌توانند همچنین [PlaceholderType.Chart](https://reference.aspose.com/slides/fa/python-java/aspose.slides/placeholdertype/#Chart)، [PlaceholderType.Table](https://reference.aspose.com/slides/fa/python-java/aspose.slides/placeholdertype/#Table)، [PlaceholderType.Picture](https://reference.aspose.com/slides/fa/python-java/aspose.slides/placeholdertype/#Picture)، [PlaceholderType.Media](https://reference.aspose.com/slides/fa/python-java/aspose.slides/placeholdertype/#Media) یا [PlaceholderType.Diagram](https://reference.aspose.com/slides/fa/python-java/aspose.slides/placeholdertype/#Diagram) را ارائه دهند.

Aspose.Slides یک جایگزین خالی [AutoShape](https://reference.aspose.com/slides/fa/python-java/aspose.slides/autoshape/) را صرفاً با تغییر [Placeholder.getType](https://reference.aspose.com/slides/fa/python-java/aspose.slides/placeholder/#getType) به یک [Chart](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chart/) تبدیل نمی‌کند؛ نوع از طریق API قابل تغییر نیست. برای پر کردن برنامه‌نویسی یک نمودار یا ناحیه محتوا خالی، شیء مورد نیاز را در مختصات جایگزین اضافه کنید و سپس جایگزین خالی را حذف کنید. مثال زیر این کار را برای یک نمودار انجام می‌دهد:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, PlaceholderType, ChartType, SaveFormat

presentation = Presentation("content-template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    target_placeholder = None

    for shape in slide.getShapes():
        placeholder = shape.getPlaceholder()
        if placeholder is None:
            continue

        placeholder_type = placeholder.getType()
        if placeholder_type in (PlaceholderType.Chart, PlaceholderType.Object):
            target_placeholder = shape
            break

    if target_placeholder is None:
        print("The first slide does not contain a chart or content placeholder.")
    else:
        chart = slide.getShapes().addChart(ChartType.ClusteredColumn, target_placeholder.getX(), target_placeholder.getY(), target_placeholder.getWidth(), target_placeholder.getHeight())
        chart.setTitle(True)
        chart.getChartTitle().addTextFrameForOverriding("Quarterly Revenue")
        slide.getShapes().remove(target_placeholder)
        presentation.save("content-placeholder-replaced-with-chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

نمودار اضافه‌شده یک نمودار محلی عادی است. این نمودار منطقه جایگزین را اشغال می‌کند اما از جایگزین چیدمان ارث نمی‌برد. هنگام نیاز به جایگزینی دسته‌ها، سری‌ها یا داده‌های workbook، از مقالات اختصاصی [chart management articles](/slides/fa/python-java/powerpoint-charts/) استفاده کنید.

## **مثال کامل: به‌روزرسانی متن یا محتوای تصویری**

مثال انتها‑به‑انتها زیر یک قالب را باز می‌کند، اسلاید اول را برای یافتن یک جایگزین عنوان یا تصویر جستجو می‌کند، نوع جایگزین و شکل را بررسی می‌کند، محتوای مناسب را به‌روزرسانی می‌نماید و خروجی را ذخیره می‌کند. این مثال به‌طور عمدی از فرض وجود یک ایندکس شکل یا رفتار یکسان برای همه جایگزین‌ها اجتناب می‌کند.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, AutoShape, PictureFrame, PlaceholderType, ShapeType, SaveFormat

presentation = Presentation("template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    updated = False

    for shape in slide.getShapes():
        placeholder = shape.getPlaceholder()
        if placeholder is None:
            continue

        placeholder_type = placeholder.getType()
        if placeholder_type in (PlaceholderType.Title, PlaceholderType.CenteredTitle) and isinstance(shape, AutoShape):
            shape.getTextFrame().setText("Quarterly Business Review")
            updated = True
            break

        if placeholder_type == PlaceholderType.Picture:
            image_bytes = Path("replacement.png").read_bytes()
            java_image_bytes = jpype.JArray(jpype.JByte)(image_bytes)
            image = presentation.getImages().addImage(java_image_bytes)

            if isinstance(shape, PictureFrame):
                shape.getPictureFormat().getPicture().setImage(image)
            else:
                slide.getShapes().addPictureFrame(ShapeType.Rectangle, shape.getX(), shape.getY(), shape.getWidth(), shape.getHeight(), image)
                slide.getShapes().remove(shape)

            updated = True
            break

    if updated:
        presentation.save("placeholder-content-updated.pptx", SaveFormat.Pptx)
    else:
        print("No supported title or picture placeholder was found on the first slide.")
finally:
    presentation.dispose()
```

## **سوالات متداول**

**یک جایگزین پایه چیست؟**

یک جایگزین پایه شکلی است که در چیدمان یا master قرار دارد و از آن جایگزین دیگران وراثت می‌گیرند. برای بازیابی آن از [Shape.getBasePlaceholder](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shape/#getBasePlaceholder) استفاده کنید. یک شکل محلی عادی `None` برمی‌گرداند زیرا بخشی از سلسله‌مراتب جایگزین نیست.

**آیا می‌توانم تمام عناوین اسلایدها را با ویرایش یک جایگزین چیدمان تغییر دهم؟**

می‌توانید قالب‌بندی ارث‌بری یا متن راهنما را از طریق یک چیدمان تغییر دهید، اما محتوای عنوان موجود در اسلایدهای عادی ذخیره شده است. برای جایگزینی متن واقعی عنوان در تمام ارائه، بر روی اسلایدها تکرار کنید و هر جایگزین عنوان را به‌روزرسانی کنید.

**چگونه می‌توانم جایگزین‌های تاریخ، شماره اسلاید، سرصفحه و پاورقی را مدیریت کنم؟**

از مدیرهای سرصفحه و پاورقی در سطح اسلاید، چیدمان، master، یادداشت یا توزیع‌کننده استفاده کنید. برای مثال‌های کامل به مقاله [Manage Presentation Header and Footer](/slides/fa/python-java/presentation-header-and-footer/) مراجعه کنید.