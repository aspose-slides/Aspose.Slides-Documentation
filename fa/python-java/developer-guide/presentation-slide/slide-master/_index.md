---
title: مدیریت اسلاید مسترهای ارائه در پایتون از طریق جاوا
linktitle: اسلاید مستر
type: docs
weight: 70
url: /fa/python-java/slide-master/
keywords:
- اسلاید مستر
- اسلاید مستر
- اسلاید مستر PPT
- اسلاید مسترهای متعدد
- مقایسه اسلاید مسترها
- پس‌زمینه
- نگهدارنده
- کلون اسلاید مستر
- کپی اسلاید مستر
- تکثیر اسلاید مستر
- اسلاید مستر استفاده‌نشده
- PowerPoint
- OpenDocument
- ارائه
- Python
- Java
- Aspose.Slides
description: "مدیریت اسلاید مسترها در Aspose.Slides برای پایتون از طریق جاوا: دسترسی، ویرایش، کلون، مقایسه و حذف اسلاید مسترها در ارائه‌های PowerPoint و OpenDocument."
---
## **نمای کلی**

یک **slide master** تنظیمات طراحی مشترک برای یک گروه از اسلایدها را تعریف می‌کند. می‌تواند شامل اشکال عمومی، لوگوها، پس‌زمینه‌ها، سبک‌های متنی، تنظیمات قالب و تنظیمات پاورقی باشد. در PowerPoint، ویرایش یک slide master رایج‌ترین روش برای حفظ یکپارچگی ارائه بدون تکرار همان فرمت‌بندی در هر اسلاید است.

Aspose.Slides for Python via Java از همین مدل پشتیبانی می‌کند. یک ارائه می‌تواند یک یا چند master slide داشته باشد و هر master slide می‌تواند چندین layout slide را شامل شود. اسلایدهای معمولی معمولاً مستقیماً به یک master slide ارجاع نمی‌دهند. در عوض، یک اسلاید معمولی از یک layout slide استفاده می‌کند و آن layout slide متعلق به یک master slide است.

سلسله‌مراتب به این صورت است:

1. **Slide master** – تنظیمات طراحی و قالب مشترک را تعریف می‌کند.  
1. **Layout slide** – چینش خاصی از نگهدارنده‌ها و قالب‌بندی سطح layout را تعیین می‌کند.  
1. **Normal slide** – محتوای واقعی ارائه را در بر می‌گیرد و از یک layout slide استفاده می‌کند.

![The hierarchy of master slides, layout slides, and normal slides](slide-master_2.jpg)

در Aspose.Slides، یک slide master توسط کلاس [MasterSlide](https://reference.aspose.com/slides/fa/python-java/aspose.slides/masterslide/) نمایندگی می‌شود. تمام master slideهای موجود در یک ارائه از طریق مجموعه [Presentation.getMasters](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#getMasters) در دسترس هستند که توسط [MasterSlideCollection](https://reference.aspose.com/slides/fa/python-java/aspose.slides/masterslidecollection/) نمایندگی می‌شود.

{{% alert color="info" title="Inheritance" %}}
زمانی که یک ویژگی در بیش از یک سطح تعریف شود، سطح خاص‌تر برتری دارد. به عنوان مثال، اگر یک master slide و یک layout slide هر دو پس‌زمینه‌ای تعریف کنند، اسلایدهای مبتنی بر آن layout از پس‌زمینه layout استفاده می‌کنند. برای اطلاعات بیشتر درباره layout slideها، به صفحه [Apply or Change Slide Layouts](/slides/fa/python-java/slide-layout/) مراجعه کنید.
{{% /alert %}}

## **دسترسی به Slide Masters**

در PowerPoint، می‌توانید نمای Slide Master را از **View** > **Slide Master** باز کنید.

![The Slide Master command on the PowerPoint View tab](slide-master_3.jpg)

در Aspose.Slides، برای دسترسی به master slideها از مجموعه [Presentation.getMasters](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#getMasters) استفاده کنید:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    first_master_slide = presentation.getMasters().get_Item(0)
    master_slide_count = presentation.getMasters().size()
    first_master_layout_slide_count = first_master_slide.getLayoutSlides().size()

    print(f"Master slides: {master_slide_count}")
    print(f"Layouts in the first master: {first_master_layout_slide_count}")
finally:
    presentation.dispose()
```

همچنین می‌توانید master slideی که یک اسلاید معمولی از آن استفاده می‌کند را از طریق layout آن به دست آورید:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    layout_slide = slide.getLayoutSlide()
    master_slide = layout_slide.getMasterSlide()
    master_slide_name = master_slide.getName()

    print(master_slide_name)
finally:
    presentation.dispose()
```

## **محتویات یک Slide Master**

یک master slide یک شیء شبیه اسلاید است. از [BaseSlide](https://reference.aspose.com/slides/fa/python-java/aspose.slides/baseslide/) ارث‌بری می‌کند، بنابراین بسیاری از ویژگی‌های اسلایدی که توسط اسلایدهای معمولی و layout استفاده می‌شود را در اختیار دارد. اعضای مخصوص master در صفحه API [MasterSlide](https://reference.aspose.com/slides/fa/python-java/aspose.slides/masterslide/) لیست شده‌اند.

اعضای معمولاً استفاده‌شده master slide عبارتند از:

| Member | Purpose |
| --- | --- |
| [getBackground](https://reference.aspose.com/slides/fa/python-java/aspose.slides/baseslide/#getBackground) | تنظیم پس‌زمینه اسلاید در سطح master. |
| [getShapes](https://reference.aspose.com/slides/fa/python-java/aspose.slides/baseslide/#getShapes) | اشکالی که بر روی master قرار گرفته‌اند مانند لوگوها، فریم‌های تصویری و متن‌های مشترک را ذخیره می‌کند. |
| [getLayoutSlides](https://reference.aspose.com/slides/fa/python-java/aspose.slides/masterslide/#getLayoutSlides) | layout slideهایی را که به این master تعلق دارند نگه می‌دارد. |
| [getThemeManager](https://reference.aspose.com/slides/fa/python-java/aspose.slides/masterslide/#getThemeManager) | دسترسی به APIهای قالب master را فراهم می‌کند. |
| [getHeaderFooterManager](https://reference.aspose.com/slides/fa/python-java/aspose.slides/masterslide/#getHeaderFooterManager) | کنترل سرصفحه‌ها، پاورقی‌ها، تاریخ‌ها و شماره اسلایدها برای master و layoutهای فرزند آن. |
| [getDependingSlides](https://reference.aspose.com/slides/fa/python-java/aspose.slides/masterslide/#getDependingSlides) | اسلایدهای معمولی که از طریق layoutهای خود به این master وابسته‌اند را باز می‌گرداند. |

## **افزودن تصویر به Slide Master**

زمانی که تصویری به یک master slide اضافه می‌کنید، بر روی اسلایدهایی که از layoutهای آن master استفاده می‌کنند نمایش داده می‌شود. این ویژگی برای لوگوها، واترمارک‌ها، نوارهای تزئینی و سایر عناصر بصری تکراری مفید است.

مثال زیر یک لوگو را به اولین master slide اضافه می‌کند:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat, ShapeType

presentation = Presentation("presentation.pptx")
try:
    master_slide = presentation.getMasters().get_Item(0)
    logo = Images.fromFile("logo.png")
    try:
        logo_image = presentation.getImages().addImage(logo)
        master_slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 80, 80, logo_image)
    finally:
        logo.dispose()

    presentation.save("presentation-with-logo.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

برای اطلاعات بیشتر درباره فریم‌های تصویری، به صفحه [Picture Frame](/slides/fa/python-java/picture-frame/) مراجعه کنید.

## **کار با Placeholders**

Placeholders عموماً در layout slideها تعریف می‌شوند. master slide سبک و قالب مشترکی را که layoutها از آن ارث می‌برند فراهم می‌کند، در حالی که هر layout تصمیم می‌گیرد کدام placeholders در دسترس هستند و در کجا قرار می‌گیرند.

در PowerPoint، فرمان‌های placeholder در نمای Slide Master موجود هستند.

![The Insert Placeholder command in PowerPoint Slide Master view](slide-master_5.png)

برای افزودن placeholders جدید با Aspose.Slides، به layout slideی که به master تعلق دارد کار کنید:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideLayoutType

presentation = Presentation("presentation.pptx")
try:
    master_slide = presentation.getMasters().get_Item(0)
    blank_layout_slide = master_slide.getLayoutSlides().getByType(SlideLayoutType.Blank)

    if blank_layout_slide is None:
        blank_layout_slide = master_slide.getLayoutSlides().add(SlideLayoutType.Blank, "Blank")

    blank_layout_slide.getPlaceholderManager().addTextPlaceholder(60, 120, 600, 80)

    presentation.getSlides().addEmptySlide(blank_layout_slide)
    presentation.save("presentation-with-placeholder.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

همچنین می‌توانید شکل‌های placeholderی که از پیش بر روی master slide وجود دارند را قالب‌بندی کنید. مثال زیر placeholder عنوان را پیدا می‌کند و یک پرکن خطی گرادیان اعمال می‌نماید:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, FillType, GradientShape, PlaceholderType, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

presentation = Presentation("presentation.pptx")
try:
    master_slide = presentation.getMasters().get_Item(0)
    title_placeholder = None

    for shape in master_slide.getShapes():
        if isinstance(shape, AutoShape):
            if shape.getPlaceholder() is not None and shape.getPlaceholder().getType() == PlaceholderType.Title:
                title_placeholder = shape
                break

    if title_placeholder is not None:
        red_gradient_color = Color(255, 0, 0)
        purple_gradient_color = Color(128, 0, 128)

        title_placeholder.getFillFormat().setFillType(FillType.Gradient)
        title_placeholder.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear)
        title_placeholder.getFillFormat().getGradientFormat().getGradientStops().add(jpype.JFloat(0.0), red_gradient_color)
        title_placeholder.getFillFormat().getGradientFormat().getGradientStops().add(jpype.JFloat(1.0), purple_gradient_color)

    presentation.save("presentation-title-style.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Formatted title placeholder inherited by normal slides](slide-master_8.png)

برای گزینه‌های بیشتر مربوط به placeholders و قالب‌بندی متن، به صفحات [Set Prompt Text in Placeholder](/slides/fa/python-java/manage-placeholder/) و [Text Formatting](/slides/fa/python-java/text-formatting/) مراجعه کنید.

## **تغییر پس‌زمینه Slide Master**

یک پس‌زمینه master توسط layoutها و اسلایدهایی که آن را بازنویسی نمی‌کنند، به ارث می‌رسد. مثال زیر رنگ پس‌زمینه‌ی جامد را برای اولین master slide تنظیم می‌کند:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

presentation = Presentation("presentation.pptx")
try:
    master_slide = presentation.getMasters().get_Item(0)
    master_background_color = Color.GREEN

    master_slide.getBackground().setType(BackgroundType.OwnBackground)
    master_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    master_slide.getBackground().getFillFormat().getSolidFillColor().setColor(master_background_color)

    presentation.save("presentation-master-background.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

برای موضوعات مرتبط، به صفحات [Presentation Background](/slides/fa/python-java/presentation-background/) و [Presentation Theme](/slides/fa/python-java/presentation-theme/) نگاهی بیندازید.

## **کلون کردن یک Slide Master به ارائه دیگر**

از متد [MasterSlideCollection.addClone](https://reference.aspose.com/slides/fa/python-java/aspose.slides/masterslidecollection/#addClone) برای کپی یک master slide به یک ارائه دیگر استفاده کنید. master کپی‌شده سپس می‌تواند توسط layoutها و اسلایدهای موجود در ارائه مقصد استفاده شود.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

source_presentation = Presentation("source.pptx")
destination_presentation = Presentation("destination.pptx")
try:
    source_master_slide = source_presentation.getMasters().get_Item(0)
    cloned_master_slide = destination_presentation.getMasters().addClone(source_master_slide)

    destination_presentation.save("destination-with-master.pptx", SaveFormat.Pptx)
finally:
    source_presentation.dispose()
    destination_presentation.dispose()
```

اگر نیاز دارید اسلایدهای معمولی را به همراه master آن‌ها کلون کنید، به صفحه [Clone Slides](/slides/fa/python-java/clone-slides/) مراجعه کنید.

## **افزودن چندین Slide Master**

یک ارائه می‌تواند شامل چندین master slide باشد. این ویژگی زمانی مفید است که بخش‌های مختلف نیاز به برندینگ، ساختار صفحه یا تنظیمات قالب متفاوتی داشته باشند.

![PowerPoint commands for inserting and managing master slides](slide-master_9.jpg)

مثال زیر master پیش‌فرض را کلون می‌کند، به کلون پس‌زمینه‌ای متفاوت می‌دهد، یک layout تحت آن master کلون‌شده ایجاد می‌کند و سپس اسلایدی جدید بر پایه آن layout اضافه می‌نماید:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat, SlideLayoutType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation("presentation.pptx")
try:
    default_master_slide = presentation.getMasters().get_Item(0)
    section_master_slide = presentation.getMasters().addClone(default_master_slide)
    section_master_background_color = Color.LIGHT_GRAY

    section_master_slide.getBackground().setType(BackgroundType.OwnBackground)
    section_master_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    section_master_slide.getBackground().getFillFormat().getSolidFillColor().setColor(section_master_background_color)

    source_blank_layout = default_master_slide.getLayoutSlides().getByType(SlideLayoutType.Blank)
    if source_blank_layout is None:
        source_blank_layout = default_master_slide.getLayoutSlides().get_Item(0)

    section_blank_layout = section_master_slide.getLayoutSlides().addClone(source_blank_layout)

    presentation.getSlides().addEmptySlide(section_blank_layout)
    presentation.save("presentation-with-multiple-masters.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **مقایسه Slide Masters**

Slide masterها می‌توانند با متد [equals](https://reference.aspose.com/slides/fa/python-java/aspose.slides/baseslide/#equals) که از [BaseSlide](https://reference.aspose.com/slides/fa/python-java/aspose.slides/baseslide/) به ارث می‌برد، مقایسه شوند. این مقایسه ساختار و محتوای ثابت مانند اشکال، متن، قالب‌بندی، انیمیشن‌ها و سایر تنظیمات اسلاید را بررسی می‌کند. شناسه‌های منحصر به فرد مانند slide ID یا مقادیر پویا مانند تاریخ فعلی در مقایسه درنظر گرفته نمی‌شوند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

first_presentation = Presentation("first.pptx")
second_presentation = Presentation("second.pptx")
try:
    first_presentation_master_count = first_presentation.getMasters().size()
    second_presentation_master_count = second_presentation.getMasters().size()

    for first_master_index in range(first_presentation_master_count):
        for second_master_index in range(second_presentation_master_count):
            first_master_slide = first_presentation.getMasters().get_Item(first_master_index)
            second_master_slide = second_presentation.getMasters().get_Item(second_master_index)
            are_master_slides_equal = first_master_slide.equals(second_master_slide)

            if are_master_slides_equal:
                print(f"first.pptx master #{first_master_index} equals second.pptx master #{second_master_index}")
finally:
    first_presentation.dispose()
    second_presentation.dispose()
```

برای اطلاعات بیشتر، به صفحه [Compare Presentation Slides](/slides/fa/python-java/compare-slides/) مراجعه کنید.

## **تنظیم Slide Master View به عنوان نمای پیش‌فرض**

از متد [setLastView](https://reference.aspose.com/slides/fa/python-java/aspose.slides/viewproperties/#setLastView) در کلاس [ViewProperties](https://reference.aspose.com/slides/fa/python-java/aspose.slides/viewproperties/) برای کنترل نمایی که PowerPoint ابتدا باز می‌کند، استفاده کنید. مثال زیر ارائه را در نمای Slide Master باز می‌کند:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ViewType

presentation = Presentation("presentation.pptx")
try:
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView)
    presentation.save("presentation-master-view.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

برای تنظیمات بیشتر نمایی، به صفحه [Save Presentation](/slides/fa/python-java/save-presentation/) نگاه کنید.

## **حذف Slide Masterهای استفاده‌نشده**

گاهی ارائه‌ها شامل master slideهایی می‌شوند که دیگر توسط هیچ اسلاید معمولی استفاده نمی‌شوند. حذف masterهای استفاده‌نشده می‌تواند حجم فایل را کاهش داده و نگهداری قالب را ساده‌تر کند.

از متد [removeUnused](https://reference.aspose.com/slides/fa/python-java/aspose.slides/masterslidecollection/#removeUnused) برای حذف masterهای استفاده‌نشده از مجموعه [Presentation.getMasters](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#getMasters) استفاده کنید:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    presentation.getMasters().removeUnused(True)
    presentation.save("presentation-clean.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

همچنین می‌توانید از متد کم‌کد [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/fa/python-java/aspose.slides/compress/#removeUnusedMasterSlides) بهره ببرید:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Compress, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    Compress.removeUnusedMasterSlides(presentation)
    presentation.save("presentation-clean.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **پرسش‌های متداول**

**تفاوت بین slide master و layout slide چیست؟**

یک slide master تنظیمات طراحی مشترکی مانند قالب، پس‌زمینه، اشکال عمومی و سبک‌های متنی را تعریف می‌کند. یک layout slide به یک master slide تعلق دارد و چینش خاصی از placeholders را تعیین می‌کند. یک اسلاید معمولی از یک layout slide استفاده می‌کند، بنابراین از هر دو layout و master ارث می‌برد.

**آیا یک ارائه می‌تواند چندین slide master داشته باشد؟**

بله. یک ارائه می‌تواند چندین slide master داشته باشد. هنگامی که بخش‌های مختلف نیاز به سیستم‌های بصری یا برندینگ متفاوتی دارند، از masterهای متعدد استفاده کنید.

**آیا باید placeholders را به master slide یا layout slide اضافه کنم؟**

در اکثر موارد، placeholders را به layout slideها اضافه کنید. عناصر بصری مشترک و قالب‌بندی‌های مشترک را بر روی master slide قرار دهید و سپس placeholders محتوا را بر روی layoutهایی که اسلایدهای معمولی استفاده می‌کنند، اضافه کنید.

**آیا می‌توانم یک master slide که هنوز استفاده می‌شود را حذف کنم؟**

نه. یک master slide که اسلایدهای وابسته دارد، نمی‌تواند به‌صورت مستقیم حذف شود. ابتدا آن اسلایدها را به layoutهای تحت master دیگری منتقل کنید یا از روش پاک‌سازی masterهای استفاده‌نشده که تنها masterهای بدون استفاده را حذف می‌کند، استفاده کنید.