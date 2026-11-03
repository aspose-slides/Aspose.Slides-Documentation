---
title: مدیریت محل‌نگهدارهای ارائه در پایتون
linktitle: مدیریت محل‌نگهدارها
type: docs
weight: 10
url: /fa/python-java/manage-placeholder/
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
  - جاوا
  - Aspose.Slides
description: "یاد بگیرید چگونه محل‌نگهدارهای متن، تصویر، نمودار و محتوا را بررسی و ویرایش کنید و ارث‌بری محل‌نگهدارها را با Aspose.Slides برای پایتون از طریق جاوا درک کنید."
---
## **نمای کلی**

یک محل‌نگهدار (placeholder) شکلی است که موقعیتی را برای یک نوع خاص محتوا در قالب ارائه رزرو می‌کند. مثال‌های متداول شامل عنوان، متن بدنه، تصویر، نمودار و محل‌نگهدارهای محتوای عمومی هستند. برخلاف یک شکل عادی، یک محل‌نگهدار می‌تواند موقعیت، اندازه، قالب‌بندی و سایر تنظیمات خود را از یک اسلاید طرح‌بندی یا اسلاید اصلی به ارث ببرد.

Aspose.Slides اطلاعات محل‌نگهدار را از طریق متد [Shape.getPlaceholder](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getPlaceholder) ارائه می‌دهد. این متد یک شیء [Placeholder](https://reference.aspose.com/slides/python-java/aspose.slides/placeholder/) یا `None` برای یک شکل عادی برمی‌گرداند. برای تعیین محتوای موردنظر محل‌نگهدار از [Placeholder.getType](https://reference.aspose.com/slides/python-java/aspose.slides/placeholder/#getType) استفاده کنید.

نوع شکل همچنان پس از دانستن نوع محل‌نگهدار اهمیت دارد:

- یک محل‌نگهدار خالی متن، تصویر، نمودار یا محتوا معمولاً توسط یک [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) نمایان می‌شود.
- یک محل‌نگهدار تصویر پر شده می‌تواند توسط یک [PictureFrame](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframe/) نمایان شود.
- یک محل‌نگهدار نمودار پر شده می‌تواند توسط یک [Chart](https://reference.aspose.com/slides/python-java/aspose.slides/chart/) نمایان شود.
- یک محل‌نگهدار محتوا می‌تواند چندین نوع محتوا را در خود داشته باشد. به جای فرض اینکه هر محل‌نگهدار یک [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) است، هم [Placeholder.getType](https://reference.aspose.com/slides/python-java/aspose.slides/placeholder/#getType) و هم نوع شکل در زمان اجرا را بررسی کنید.

{{% alert color="warning" title="Warning" %}}
متد [Placeholder.getType](https://reference.aspose.com/slides/python-java/aspose.slides/placeholder/#getType) نقش یک محل‌نگهدار را توصیف می‌کند؛ اما نوع شکل در زمان اجرا را تضمین نمی‌کند. همیشه پیش از دسترسی به اعضای متنی، تصویری، نموداری، جدول یا رسانه‌ای، یک بررسی نوع انجام دهید.
{{% /alert %}}

## **درک ارث‌بری محل‌نگهدار**

محل‌نگهدارها یک سلسله مراتب تشکیل می‌دهند:

1. یک اسلاید اصلی (master) سبک‌های قابل استفاده مجدد و در برخی موارد، محل‌نگهدارهای سطح اصلی را تعریف می‌کند.
2. یک اسلاید طرح‌بندی (layout) ترتیب استفاده‌شده توسط یک یا چند اسلاید عادی را تعریف می‌کند و می‌تواند از اسلاید اصلی ارث ببرد.
3. یک اسلاید عادی شامل محل‌نگهدارهای آن اسلاید است و می‌تواند از طرح‌بندی خود ارث ببرد.

برای حرکت یک سطح بالاتر در این سلسله مراتب، متد [Shape.getBasePlaceholder](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getBasePlaceholder) را فراخوانی کنید. یک محل‌نگهدار اسلاید معمولاً محل‌نگهدار طرح‌بندی خود را برمی‌گرداند؛ یک محل‌نگهدار طرح‌بندی می‌تواند محل‌نگهدار اصلی خود را برگرداند. این متد زمانی که شکل پایه‌ای برای محل‌نگهدار ندارد، `None` برمی‌گرداند.

مثال زیر محل‌نگهدارهای اسلاید اول را فهرست می‌کند و پایهٔ آن‌ها را گزارش می‌دهد:

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

ویرایش یک محل‌نگهدار در یک اسلاید عادی یک لغو یا تغییر محلی برای آن اسلاید ایجاد می‌کند. ویرایش طرح‌بندی یا اسلاید اصلی مرتبط می‌تواند بر تمام اسلایدهایی که هنوز آن تنظیم را ارث می‌برند، تأثیر بگذارد. یک شکل عادی محلی پایهٔ محل‌نگهدار ندارد و تنها به دلیل قرار گرفتن در همان مختصات، شروع به ارث‌بری نمی‌کند.

## **حذف وضعیت محل‌نگهدار**

هنگام سازگار کردن یک قالب، از [Shape.removePlaceholder](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#removePlaceholder) استفاده کنید تا یک شیء موجود به عنوان یک شکل عادی باقی بماند. متد [getPlaceholder](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getPlaceholder) آن `None` برمی‌گرداند، اما شکل در مجموعهٔ اسلاید باقی می‌ماند. برعکس، [ShapeCollection.remove](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#remove) شکل را از آن مجموعه حذف می‌کند.

مثال زیر نیاز به فایلی به نام `template.pptx` دارد که حداقل یک اسلاید و یک محل‌نگهدار متنی غیر خالی در اسلاید اول داشته باشد. برای مشاهده تأثیر حذف این رابطه، از یک محل‌نگهدار با قالب‌بندی ارث‌برده از طرح‌بندی یا اسلاید اصلی استفاده کنید. مثال بررسی می‌کند که همان شکل باقی می‌ماند، مجدداً متد را بر روی شکل عادی شده فراخوانی می‌کند و نتیجه را ذخیره می نماید.

{{% alert color="warning" title="Warning" %}}
حذف وضعیت محل‌نگهدار به‌طور خودکار تنظیمات ظاهر ارث‌بری را حفظ نمی‌کند. مثال زیر به‌صورت عمدی این تنظیمات را بدون تغییر می‌گذارد، بنابراین خروجی ممکن است متفاوت به‌نظر برسد. یک شکل که موقعیت و اندازهٔ آن کاملاً ارث‌بری باشد می‌تواند پس از فراخوانی مختصات و ابعاد صفر داشته باشد و حتی اگر در مجموعه باقی بماند، نامرئی شود.
{{% /alert %}}

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, AutoShape, SaveFormat

presentation = Presentation("template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    found = False

    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if not isinstance(shape, AutoShape):
            continue

        text_frame = shape.getTextFrame()
        if shape.getPlaceholder() is None or text_frame is None:
            continue
        text = text_frame.getText()
        if text is None or len(text) == 0:
            continue

        shape_count = slide.getShapes().size()
        shape.removePlaceholder()

        print(f"Placeholder removed: {shape.getPlaceholder() is None}")
        print(f"Same shape retained: {slide.getShapes().get_Item(index) == shape}")
        print(f"Shape count unchanged: {slide.getShapes().size() == shape_count}")

        # فراخوانی متد بر روی یک شکل عادی هیچ اثری ندارد.
        shape.removePlaceholder()
        found = True
        break

    if found:
        presentation.save("placeholder-status-removed.pptx", SaveFormat.Pptx)
    else:
        print("No nonempty text placeholder was found on the first slide.")
finally:
    presentation.dispose()
```

برای یک محل‌نگهدار منطبق، هر سه بررسی `True` چاپ می‌شوند. متن باقی می‌ماند، اما موقعیت، اندازه، چرخش، قلم، تراز پاراگراف، حاشیه‌های فریم متن، لنگر عمودی، پرکننده و تنظیمات خط که به‌صورت ارث‌بری هستند می‌توانند هنگام حذف رابطهٔ محل‌نگهدار تغییر کنند. به‌عنوان مثال، قالب‌بندی عنوان ارث‌برده می‌تواند به قالب‌بندی متن عادی بازگردد. برای اطلاعات بیشتر درباره طرح‌ها، به [Slide Layout](/slides/fa/python-java/slide-layout/) مراجعه کنید.

برای حفظ ظاهر موردنظر، قبل از فراخوانی موقعیت، اندازه و چرخش محاسبه‌شده را ضبط کنید و مقادیر قالب‌بندی مؤثر لازم را در متغیرهای جداگانه کپی کنید. این مقادیر را از طریق [PortionFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/#getEffective)، [ParagraphFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getEffective)، [TextFrameFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#getEffective)، [FillFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getEffective)، و [LineFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#getEffective) بازیابی کنید. تنها به نگهداری اشیاء قالب‌بندی مؤثر تکیه نکنید، زیرا مقادیر قالب‌بندی متن آن‌ها می‌تواند پس از حذف رابطه تغییر کند. به‌صورت صریح مقادیر ضبط‌شده را پس از آن بر روی شکل عادی اعمال کنید، شامل خانوادهٔ قلم، اندازه، سبک، رنگ، تنظیمات پاراگراف، تنظیمات فریم متن، پرکننده و خط مورد استفاده در قالب شما.

زیست‌شکل ارث‌بردهٔ شکل نیز ممکن است نیاز به اختصاص صریح از طریق [GeometryShape.setShapeType](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setShapeType) داشته باشد. برای یک محل‌نگهدار متن مستطیلی، این به معنای اختصاص [ShapeType.Rectangle](https://reference.aspose.com/slides/python-java/aspose.slides/shapetype/#Rectangle) است؛ بازگرداندن تنها پرکننده و خط ممکن است مستطیل قابل مشاهده را بازسازی نکند. قالب‌های دارای افکت‌های اضافه یا قالب‌بندی پیچیده‌تر نیز به‌همین‌منظور نیاز به تنظیم این خصوصیت‌ها دارند.

## **تغییر متن در یک محل‌نگهدار**

محل‌نگهدارهای عنوان، عنوان‌وسط‌چین، زیرعنوان، بدنه و متن معمولاً از متن پشتیبانی می‌کنند. قبل از استفاده از متد [getTextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/#getTextFrame) آن، وجود [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) را بررسی کنید.

این مثال اولین محل‌نگهدار عنوان در اسلاید اول را به‌روز می‌کند و نتیجه را ذخیره می‌نماید:

```python
import jpace
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

این الگو از در نظر گرفتن محل‌نگهدارهای تصویر، نمودار، جدول یا رسانه به‌عنوان [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) جلوگیری می‌کند. همچنین محل‌نگهدار را بر اساس هدفش شناسایی می‌کند به‌جای اتکا به یک شاخص شکل ناپایدار.

## **تنظیم متن راهنما در یک طرح‌بندی**

متن راهنما (Prompt text) دستور طراحی است که در یک محل‌نگهدار خالی نمایش داده می‌شود، مانند *برای افزودن عنوان کلیک کنید*. متن راهنمای سفارشی را بر روی محل‌نگهدار طرح‌بندی تنظیم کنید نه اینکه سعی کنید از طریق مجموعهٔ اشکال اسلاید عادی به آن دسترسی پیدا کنید. با استفاده از [Slide.getLayoutSlide](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getLayoutSlide) به طرح‌بندی دسترسی پیدا کنید و روی مجموعه‌ای که توسط [BaseSlide.getShapes](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getShapes) برگردانده می‌شود، تکرار کنید.

مثال زیر متن‌های راهنمای عنوان و زیرعنوان را در طرح‌بندی مورد استفاده در اسلاید اول تغییر می‌دهد:

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

متن راهنما محتوای معمول اسلاید نیست. این متن برای محل‌نگهدارهای خالی در برنامه‌های ویرایشی مانند PowerPoint در نظر گرفته شده است. وقتی کاربر یا برنامه محتوای واقعی را فراهم می‌کند، متن راهنما دیگر نمایش داده نمی‌شود. تغییر یک متن راهنما همچنین متن موجود در اسلایدهایی که از این طرح‌بندی استفاده می‌کنند را جایگزین نمی‌کند.

## **به‌روزرسانی یک محل‌نگهدار تصویر**

دو حالت برای پردازش وجود دارد:

- اگر محل‌نگهدار تصویر قبلاً پر شده باشد و توسط یک [PictureFrame](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframe/) نمایان شده باشد، تصویر را با استفاده از [PictureFillFormat.getPicture](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#getPicture) و [Picture.setImage](https://reference.aspose.com/slides/python-java/aspose.slides/picture/#setImage) جایگزین کنید.
- اگر هنوز یک محل‌نگهدار خالی باشد، یک فریم تصویر را در مختصات محل‌نگهدار با [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addPictureFrame) اضافه کنید و محل‌نگهدار خالی را حذف کنید.

مثال بعدی هر دو حالت را پشتیبانی می‌کند و ارائه را ذخیره می‌نماید:

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

جایگزینی که برای یک محل‌نگهدار خالی ایجاد می‌شود یک فریم تصویر محلی است، نه یک محل‌نگهدار جدید، زیرا [Shape.getPlaceholder](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getPlaceholder) ستری فراهم نمی‌کند. این فریم موقعیت رزرو شده را حفظ می‌کند اما دیگر رفتار خاص محل‌نگهدار را به ارث نمی‌برد. اگر حفظ رابطهٔ محل‌نگهدار ضروری است، ابتدا محل‌نگهدار را در PowerPoint آماده و پر کنید، سپس [PictureFrame](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframe/) حاصل را با Aspose.Slides به‌روزرسانی کنید.

برای شفافیت تصویر، برش و سایر افکت‌های خاص تصویر، به [Manage Picture Frames](/slides/fa/python-java/picture-frame/) مراجعه کنید. این عملیات‌ها به فریم تصویر یا پرکنندهٔ تصویر تعلق دارند، نه به فرادادهٔ محل‌نگهدار.

## **کار با محل‌نگهدارهای نمودار و محتوا**

یک محل‌نگهدار نمودار پر شده می‌تواند توسط یک [Chart](https://reference.aspose.com/slides/python-java/aspose.slides/chart/) نمایان شود. این مثال چنین نموداری را هم بر اساس نوع محل‌نگهدار و هم نوع زمان اجرا پیدا می‌کند، عنوان آن را تغییر می‌دهد و فایل را ذخیره می‌کند:

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

یک محل‌نگهدار محتوای عمومی معمولاً دارای [PlaceholderType.Object](https://reference.aspose.com/slides/python-java/aspose.slides/placeholdertype/#Object) است. در PowerPoint این محل‌نگهدار به‌عنوان یک راه‌انداز برای چندین نوع محتوا عمل می‌کند، از جمله نمودارها، جدول‌ها، دیاگرام‌ها، تصاویر و رسانه‌ها. پس از پر شدن، نوع شکل واقعی را بررسی کنید تا بفهمید چه محتوایی دارد. طرح‌بندی‌های خاص نیز می‌توانند [PlaceholderType.Chart](https://reference.aspose.com/slides/python-java/aspose.slides/placeholdertype/#Chart)، [PlaceholderType.Table](https://reference.aspose.com/slides/python-java/aspose.slides/placeholdertype/#Table)، [PlaceholderType.Picture](https://reference.aspose.com/slides/python-java/aspose.slides/placeholdertype/#Picture)، [PlaceholderType.Media](https://reference.aspose.com/slides/python-java/aspose.slides/placeholdertype/#Media) یا [PlaceholderType.Diagram](https://reference.aspose.com/slides/python-java/aspose.slides/placeholdertype/#Diagram) را در معرض نمایش قرار دهند.

Aspose.Slides یک محل‌نگهدار خالی [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) را به‌سادگی با تغییر [Placeholder.getType](https://reference.aspose.com/slides/python-java/aspose.slides/placeholder/#getType) به یک [Chart](https://reference.aspose.com/slides/python-java/aspose.slides/chart/) تبدیل نمی‌کند؛ نوع را نمی‌توان از طریق API تغییر داد. برای برنامه‌نویسی پر کردن یک نمودار یا ناحیه محتوا خالی، شیء مورد نیاز را در مختصات محل‌نگهدار اضافه کنید و سپس محل‌نگهدار خالی را حذف کنید. مثال زیر این کار را برای یک نمودار انجام می‌دهد:

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

نموداری که اضافه می‌شود یک نمودار محلی عادی است. این نمودار ناحیهٔ محل‌نگهدار را اشغال می‌کند اما از محل‌نگهدار طرح‌بندی ارث نمی‌برد. هنگامی که نیاز به تغییر دسته‌ها، سری‌ها یا داده‌های کاربرگ آن دارید، از مقالات اختصاصی مدیریت نمودارها ([chart management articles](/slides/fa/python-java/powerpoint-charts/)) استفاده کنید.

## **مثال کامل: به‌روزرسانی متن یا محتوای تصویر**

مثال کامل زیر یک قالب را باز می‌کند، اسلاید اول را برای یک محل‌نگهدار عنوان یا تصویر جستجو می‌کند، نوع محل‌نگهدار و نوع شکل را بررسی می‌کند، محتوای مناسب را به‌روزرسانی می‌کند و خروجی را ذخیره می نماید. این مثال عمداً از فرض وجود شاخص شکل یا رفتار همهٔ محل‌نگهدارها به‌عنوان یک نوع خودداری می‌کند.

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

## **FAQ**

**پایهٔ یک محل‌نگهدار چیست؟**

یک پایهٔ محل‌نگهدار، شکلی متناظر در طرح‌بندی یا اسلاید اصلی است که یک محل‌نگهدار دیگر از آن ارث می‌برد. برای بازیابی آن از [Shape.getBasePlaceholder](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getBasePlaceholder) استفاده کنید. یک شکل عادی محلی `None` برمی‌گرداند زیرا بخشی از سلسله مراتب محل‌نگهدارها نیست.

**آیا می‌توانم تمام عناوین اسلایدها را با ویرایش یک محل‌نگهدار طرح‌بندی تغییر دهم؟**

می‌توانید قالب‌بندی یا متن راهنمای ارث‌برده را از طریق یک طرح‌بندی تغییر دهید، اما محتوای واقعی عناوین در اسلایدهای عادی ذخیره شده است. برای جایگزینی متن واقعی عناوین در تمام ارائه، بر روی اسلایدها تکرار کنید و هر محل‌نگهدار عنوان را به‌روزرسانی کنید.

**چگونه می‌توانم محل‌نگهدارهای تاریخ، شمارهٔ اسلاید، سرصفحه و پاورقی را مدیریت کنم؟**

از مدیران سرصفحه و پاورقی در سطح اسلاید، طرح‌بندی، اسلاید اصلی، یادداشت‌ها یا توزیع‌کننده استفاده کنید. برای مثال‌های کامل به [Manage Presentation Header and Footer](/slides/fa/python-java/presentation-header-and-footer/) مراجعه کنید.