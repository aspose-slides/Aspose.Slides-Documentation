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
- اسلایدهای مستر متعدد
- مقایسه اسلایدهای مستر
- پس‌زمینه
- محل‌دار
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
description: "مدیریت اسلاید مسترها در Aspose.Slides برای پایتون از طریق جاوا: دسترسی، ویرایش، کلون، مقایسه و حذف اسلایدهای مستر در ارائه‌های PowerPoint و OpenDocument."
---
## **نمای کلی**

یک **slide master** تنظیمات طراحی مشترک را برای گروهی از اسلایدها تعریف می‌کند. می‌تواند شامل اشکال عمومی، لوگوها، پس‌زمینه‌ها، سبک‌های متن، تنظیمات تم و تنظیمات پاورقی باشد. در PowerPoint، ویرایش یک slide master معمول‌ترین روش برای حفظ سازگاری ارائه بدون تکرار قالب‌بندی یکسان در هر اسلاید است.

Aspose.Slides برای Python از طریق Java از همین مدل پشتیبانی می‌کند. یک ارائه می‌تواند یک یا چند اسلاید مستر داشته باشد و هر اسلاید مستر می‌تواند چندین اسلاید لِی‌آوت داشته باشد. اسلایدهای معمولی معمولاً مستقیماً به اسلاید مستر ارجاع نمی‌دهند. در عوض، یک اسلاید معمولی از یک اسلاید لِی‌آوت استفاده می‌کند که آن لِی‌آوت به یک اسلاید مستر تعلق دارد.

ساختار به صورت زیر است:

1. **Slide master** - طراحی و تم مشترک را تعریف می‌کند.  
1. **Layout slide** - چینش خاصی از جای‌دارهای محتوا و قالب‌بندی سطح لِی‌آوت را تعریف می‌کند.  
1. **Normal slide** - محتوای واقعی ارائه را در بر دارد و از یک اسلاید لِی‌آوت استفاده می‌کند.

![The hierarchy of master slides, layout slides, and normal slides](slide-master_2.jpg)

در Aspose.Slides، یک slide master توسط کلاس [MasterSlide](https://reference.aspose.com/slides/fa/python-java/aspose.slides/masterslide/) نمایش داده می‌شود. همه اسلایدهای مستر در یک ارائه از طریق مجموعه [Presentation.getMasters](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#getMasters) در دسترس هستند که توسط [MasterSlideCollection](https://reference.aspose.com/slides/fa/python-java/aspose.slides/masterslidecollection/) نمایان می‌شود.

{{% alert color="info" title="Inheritance" %}}
زمانی که یک ویژگی در بیش از یک سطح تعریف شده باشد، سطح خاص‌تر برتری دارد. برای مثال، اگر یک اسلاید مستر و یک اسلاید لِی‌آوت هر دو پس‌زمینه‌ای تعریف کنند، اسلایدهایی که بر پایه آن لِی‌آوت هستند از پس‌زمینه لِی‌آوت استفاده می‌کنند. برای اطلاعات بیشتر درباره اسلایدهای لِی‌آوت، به [Apply or Change Slide Layouts](/slides/fa/python-java/slide-layout/) مراجعه کنید.
{{% /alert %}}

## **دسترسی به Slide Masters**

در PowerPoint می‌توانید نمای Slide Master را از **View** > **Slide Master** باز کنید.

![The Slide Master command on the PowerPoint View tab](slide-master_3.jpg)

در Aspose.Slides، برای دسترسی به اسلایدهای مستر از مجموعه [Presentation.getMasters](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#getMasters) استفاده کنید:

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

همچنین می‌توانید اسلاید مستری که یک اسلاید معمولی از طریق لِی‌آوت خود استفاده می‌کند را به دست آورید:

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

## **محتوای یک Slide Master**

یک اسلاید مستر یک شیء شبیه اسلاید است. این شیء از [BaseSlide](https://reference.aspose.com/slides/fa/python-java/aspose.slides/baseslide/) به ارث می‌برد، بنابراین بسیاری از ویژگی‌های اسلاید که توسط اسلایدهای معمولی و لِی‌آوت استفاده می‌شود را نشان می‌دهد. اعضای خاص مستر در صفحه API [MasterSlide](https://reference.aspose.com/slides/fa/python-java/aspose.slides/masterslide/) فهرست شده‌اند.

عضوهای معمولاً استفاده‌شدهٔ اسلاید مستر شامل:

| Member | Purpose |
| --- | --- |
| [getBackground](https://reference.aspose.com/slides/fa/python-java/aspose.slides/baseslide/#getBackground) | تنظیم پس‌زمینهٔ سطح مستر اسلاید. |
| [getShapes](https://reference.aspose.com/slides/fa/python-java/aspose.slides/baseslide/#getShapes) | نگهداری اشکالی که روی مستر قرار گرفته‌اند، مانند لوگوها، قاب‌های تصویر و متن‌های مشترک. |
| [getLayoutSlides](https://reference.aspose.com/slides/fa/python-java/aspose.slides/masterslide/#getLayoutSlides) | نگهداری اسلایدهای لِی‌آوتی که به مستر تعلق دارند. |
| [getThemeManager](https://reference.aspose.com/slides/fa/python-java/aspose.slides/masterslide/#getThemeManager) | دسترسی به APIهای تم مستر. |
| [getHeaderFooterManager](https://reference.aspose.com/slides/fa/python-java/aspose.slides/masterslide/#getHeaderFooterManager) | کنترل سرصفحه، پاورقی، تاریخ و شماره اسلاید برای مستر و لِی‌آوت‌های فرزند آن. |
| [getDependingSlides](https://reference.aspose.com/slides/fa/python-java/aspose.slides/masterslide/#getDependingSlides) | بازگرداندن اسلایدهای معمولی که از طریق لِی‌آوت‌های خود به مستر وابسته‌اند. |

## **افزودن تصویر به یک Slide Master**

هنگامی که یک تصویر را به یک اسلاید مستر اضافه می‌کنید، در اسلایدهایی که از لِی‌آوت‌های آن مستر استفاده می‌کنند ظاهر می‌شود. این کار برای لوگوها، واترمارک‌ها، باندهای تزئینی و سایر عناصر بصری تکراری مفید است.

مثال زیر یک لوگو را به اولین اسلاید مستر اضافه می‌کند:

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

برای اطلاعات بیشتر دربارهٔ قاب‌های تصویر، به [Picture Frame](/slides/fa/python-java/picture-frame/) مراجعه کنید.

## **کنترل نمایش گرافیک‌های مستر**

از [BaseSlide.setShowMasterShapes](https://reference.aspose.com/slides/fa/python-java/aspose.slides/baseslide/#setShowMasterShapes) استفاده کنید تا گرافیک‌های ارث‌برگرفتهٔ مستر مانند لوگوها یا اشکال تزئینی را بدون حذف آن‌ها از مستر مخفی کنید. مقدار `False` را به [Slide.setShowMasterShapes](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slide/#setShowMasterShapes) در اسلایدی که باید این گرافیک‌ها حذف شوند بدهید و روی اسلایدهایی که باید نمایش داده شوند مقدار `True` بگذارید.

مثال زیر یک باند تزئینی آبی روی یک مستر و دو اسلاید که از همان لِی‌آوت خالی استفاده می‌کنند، ایجاد می‌کند. باند در اسلاید اول قابل مشاهده و در اسلاید دوم مخفی است. نیازی به ارائه یا تصویر ورودی نیست.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType, SlideLayoutType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    master_slide = presentation.getMasters().get_Item(0)
    layout_slide = master_slide.getLayoutSlides().getByType(SlideLayoutType.Blank)
    layout_slide.setShowMasterShapes(True)

    slide_height = jpype.JFloat(presentation.getSlideSize().getSize().getHeight())
    band = master_slide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 60, slide_height)
    band_color = Color(70, 130, 180)
    band.getFillFormat().setFillType(FillType.Solid)
    band.getFillFormat().getSolidFillColor().setColor(band_color)
    band.getLineFormat().getFillFormat().setFillType(FillType.NoFill)

    visible_slide = presentation.getSlides().get_Item(0)
    visible_slide.setLayoutSlide(layout_slide)
    visible_slide.getShapes().clear()

    hidden_slide = presentation.getSlides().addEmptySlide(layout_slide)

    visible_slide.setShowMasterShapes(True)
    hidden_slide.setShowMasterShapes(False)

    presentation.save("master-graphics.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

این مثال از لِی‌آوت **Blank** موجود در یک ارائهٔ جدید استفاده می‌کند و جای‌دارهای اسلاید اولیه را حذف می‌کند.

### **انتخاب دامنهٔ تنظیم**

یک اسلاید معمولی از طریق [Slide.getLayoutSlide](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slide/#getLayoutSlide) و [LayoutSlide.getMasterSlide](https://reference.aspose.com/slides/fa/python-java/aspose.slides/layoutslide/#getMasterSlide) به مستر خود دسترسی پیدا می‌کند. تنظیم این ویژگی روی یک اسلاید منفرد تنها بر همان اسلاید تأثیر می‌گذارد. مقدار `False` را به [LayoutSlide.setShowMasterShapes](https://reference.aspose.com/slides/fa/python-java/aspose.slides/layoutslide/#setShowMasterShapes) پاس دادن گرافیک‌های مستر را برای اسلایدهایی که از همان لِی‌آوت مشترک استفاده می‌کنند مخفی می‌کند، حتی اگر تنظیم خودشان `True` باشد. برای مخفی کردن گرافیک فقط در یک اسلاید، ویژگی اسلاید را تغییر دهید و لِی‌آوت مشترک را دست‌نخورده بگذارید.

این تنظیم به‌عنوان کنترل قابلیت نمایش بر روی خود اسلاید مستر پشتیبانی نمی‌شود. در یک مستر، [getShowMasterShapes](https://reference.aspose.com/slides/fa/python-java/aspose.slides/masterslide/#getShowMasterShapes) همیشه `False` برمی‌گرداند و پاس دادن `True` به [setShowMasterShapes](https://reference.aspose.com/slides/fa/python-java/aspose.slides/masterslide/#setShowMasterShapes) استثنائی ایجاد می‌کند. آن را بر روی یک اسلاید معمولی یا یک لِی‌آوت اعمال کنید.

### **تمایز گرافیک‌ها از پس‌زمینه**

| Operation | Effect |
| --- | --- |
| Hide master graphics | کنترل نمایش اشکال ارث‌برگرفتهٔ مستر بدون حذف یا تغییر اشکال خود اسلاید. |
| Change the slide background fill | تغییر رنگ، گرادیانت یا تصویر پس‌زمینه. گرافیک‌های مستر اشکال جداگانه‌ای هستند و می‌توانند بر روی آن پس‌زمینه دیده شوند. به [Presentation Background](/slides/fa/python-java/presentation-background/) مراجعه کنید. |
| Delete a shape from the master | حذف شکل منبع مشترک، به‌طوری که دیگر برای هیچ اسلایدی که از آن مستر استفاده می‌کند در دسترس نباشد. |

## **کار با Placeholders**

Placeholders معمولاً در اسلایدهای لِی‌آوت تعریف می‌شوند. اسلاید مستر سبک و تم مشترکی را که این لِی‌آوت‌ها ارث می‌برند، فراهم می‌کند، در حالی که هر لِی‌آوت تصمیم می‌گیرد کدام Placeholders در دسترس هستند و کجا قرار می‌گیرند.

در PowerPoint، فرمان‌های Placeholder در نمای Slide Master موجود است.

![The Insert Placeholder command in PowerPoint Slide Master view](slide-master_5.png)

برای افزودن Placeholders جدید با Aspose.Slides، با اسلاید لِی‌آوتی که به مستر تعلق دارد کار کنید:

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

همچنین می‌توانید اشکال Placeholder که قبلاً روی یک اسلاید مستر وجود دارند را قالب‌بندی کنید. مثال زیر Placeholder عنوان را پیدا کرده و یک پر کردن گرادیان خطی اعمال می‌کند:

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

برای گزینه‌های بیشتر مربوط به Placeholder و قالب‌بندی متن، به [Set Prompt Text in Placeholder](/slides/fa/python-java/manage-placeholder/) و [Text Formatting](/slides/fa/python-java/text-formatting/) مراجعه کنید.

## **تغییر پس‌زمینهٔ یک Slide Master**

پس‌زمینهٔ مستر توسط لِی‌آوت‌ها و اسلایدهایی که آن را بازنویسی نمی‌کنند، به ارث می‌رسد. مثال زیر یک رنگ پس‌زمینهٔ ثابت برای اولین اسلاید مستر تنظیم می‌کند:

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

برای موضوعات مرتبط، به [Presentation Background](/slides/fa/python-java/presentation-background/) و [Presentation Theme](/slides/fa/python-java/presentation-theme/) مراجعه کنید.

## **کلون کردن یک Slide Master به ارائه‌ای دیگر**

از [MasterSlideCollection.addClone](https://reference.aspose.com/slides/fa/python-java/aspose.slides/masterslidecollection/#addClone) برای کپی یک اسلاید مستر به یک ارائهٔ دیگر استفاده کنید. مستر کپی‌شده سپس می‌تواند توسط لِی‌آوت‌ها و اسلایدهای مقصد استفاده شود.

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

اگر نیاز دارید اسلایدهای معمولی را همراه با مسترشان کلون کنید، به [Clone Slides](/slides/fa/python-java/clone-slides/) مراجعه کنید.

## **اضافه‌کردن چند Slide Master**

یک ارائه می‌تواند چندین اسلاید مستر داشته باشد. این برای بخش‌های مختلف که نیاز به برندینگ، ساختار صفحه یا تنظیمات تم متفاوتی دارند مفید است.

![PowerPoint commands for inserting and managing master slides](slide-master_9.jpg)

مثال زیر مستر پیش‌فرض را کلون می‌کند، به کلون پس‌زمینهٔ متفاوتی می‌دهد، یک لِی‌آوت تحت آن مستر کلون‌شده ایجاد می‌کند و یک اسلاید جدید بر پایهٔ آن لِی‌آوت اضافه می‌کند:

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

اسلایدهای مستر می‌توانند با استفاده از متد [equals](https://reference.aspose.com/slides/fa/python-java/aspose.slides/baseslide/#equals) که از [BaseSlide](https://reference.aspose.com/slides/fa/python-java/aspose.slides/baseslide/) به ارث می‌رسد، مقایسه شوند. این مقایسه ساختار و محتوای ثابت مانند اشکال، متن، قالب‌بندی، انیمیشن‌ها و سایر تنظیمات اسلاید را بررسی می‌کند. شناسه‌های منحصر به فرد مانند شناسه‌های اسلاید یا مقادیر پویا مانند تاریخ جاری در مقایسه در نظر گرفته نمی‌شوند.

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

برای اطلاعات بیشتر، به [Compare Presentation Slides](/slides/fa/python-java/compare-slides/) مراجعه کنید.

## **تنظیم Slide Master View به عنوان نمای پیش‌فرض**

از متد [setLastView](https://reference.aspose.com/slides/fa/python-java/aspose.slides/viewproperties/#setLastView) بر روی [ViewProperties](https://reference.aspose.com/slides/fa/python-java/aspose.slides/viewproperties/) استفاده کنید تا نمایی که PowerPoint ابتدا باز می‌کند کنترل شود. مثال زیر ارائه را در نمای Slide Master باز می‌کند:

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

برای تنظیمات نمای بیشتر، به [Save Presentation](/slides/fa/python-java/save-presentation/) مراجعه کنید.

## **حذف Slide Masterهای استفاده‌نشده**

گاهی اوقات ارائه‌ها شامل اسلایدهای مستری می‌شوند که دیگر توسط هیچ اسلاید معمولی استفاده نمی‌شوند. حذف مسترهای استفاده‌نشده می‌تواند اندازهٔ فایل را کاهش دهد و نگهداری قالب را ساده‌تر کند.

از [removeUnused](https://reference.aspose.com/slides/fa/python-java/aspose.slides/masterslidecollection/#removeUnused) برای حذف مسترهای استفاده‌نشده از مجموعه [Presentation.getMasters](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#getMasters) استفاده کنید:

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

همچنین می‌توانید از متد کم‌کد [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/fa/python-java/aspose.slides/compress/#removeUnusedMasterSlides) استفاده کنید:

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

## **سوالات متداول**

**تفاوت اسلاید مستر و اسلاید لِی‌آوت چیست؟**

یک اسلاید مستر تنظیمات طراحی مشترکی مانند تم، پس‌زمینه، اشکال عمومی و سبک‌های متن را تعریف می‌کند. یک اسلاید لِی‌آوت به یک اسلاید مستر تعلق دارد و چینش خاصی از جای‌دارها را تعیین می‌کند. یک اسلاید معمولی از یک اسلاید لِی‌آوت استفاده می‌کند، بنابراین از هر دو لِی‌آوت و مستر ارث می‌برد.

**آیا یک ارائه می‌تواند چندین اسلاید مستر داشته باشد؟**

بله. یک ارائه می‌تواند چندین اسلاید مستر داشته باشد. از مسترهای متعدد زمانی استفاده کنید که بخش‌های مختلف به سیستم‌های بصری یا برندینگ متفاوتی نیاز دارند.

**آیا باید Placeholders را به اسلاید مستر یا اسلاید لِی‌آوت اضافه کنم؟**

در اکثر موارد Placeholders را به اسلایدهای لِی‌آوت اضافه کنید. عناصر بصری مشترک و قالب‌بندی‌های مشترک را در اسلاید مستر قرار دهید و سپس Placeholders محتوا را در لِی‌آوت‌هایی که اسلایدهای معمولی استفاده می‌کنند، بگذارید.

**آیا می‌توانم یک اسلاید مستر که هنوز استفاده می‌شود را حذف کنم؟**

خیر. یک اسلاید مستر که اسلایدهای وابسته دارد، به‌صورت مستقیم نمی‌تواند به‌صورت ایمن حذف شود. ابتدا آن اسلایدها را به لِی‌آوت‌های تحت مستر دیگری منتقل کنید یا از روش پاک‌سازی مسترهای استفاده‌نشده که فقط مسترهای غیرقابل استفاده را حذف می‌کند، استفاده کنید.