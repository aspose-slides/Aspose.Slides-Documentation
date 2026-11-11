---
title: مدیریت زوم ارائه در پایتون از طریق جاوا
linktitle: مدیریت زوم
type: docs
weight: 60
url: /fa/python-java/manage-zoom/
keywords:
- زوم
- فریم زوم
- زوم اسلاید
- زوم بخش
- زوم خلاصه
- افزودن زوم
- PowerPoint
- ارائه
- Python
- Java
- Aspose.Slides
description: "ایجاد و سفارشی‌سازی زوم با Aspose.Slides برای پایتون از طریق جاوا — بین بخش‌ها پرش کنید، تصویرهای بندانگشتی و انتقال‌ها را در ارائه‌های PowerPoint اضافه کنید."
---
## **مقدمه**

Zoomهای PowerPoint به شما امکان می‌دهند در طول نمایش اسلایدها بین اسلایدها و بخش‌های خاص حرکت کنید. با Aspose.Slides برای Python از طریق Java، می‌توانید Zoomهای اسلاید، بخش و خلاصه را ایجاد کرده و پیش‌نمایش، حاشیه‌ها و انتقال‌های آن‌ها را سفارشی کنید.

![نمای کلی Zoom PowerPoint](overview.png)

* برای خلاصه‌نویسی کل ارائه در یک اسلاید، از [Zoom خلاصه](#summary-zoom) استفاده کنید.
* برای نمایش فقط اسلایدهای انتخابی، از [Zoom اسلاید](#slide-zoom) استفاده کنید.
* برای نمایش فقط یک بخش، از [Zoom بخش](#section-zoom) استفاده کنید.

## **Zoom اسلاید**

Zoom اسلاید می‌تواند ارائه شما را پویا‌تر کند و به شما اجازه می‌دهد به‌صورت آزادانه بین اسلایدها به هر ترتیبی که می‌خواهید حرکت کنید بدون اینکه جریان ارائه قطع شود. Zoomهای اسلاید برای ارائه‌های کوتاه که بخش‌های زیادی ندارند مناسب هستند، اما می‌توانید آن‌ها را در سناریوهای مختلف ارائه نیز به کار ببرید.

Zoom اسلاید به شما امکان می‌دهد اطلاعات مرتبط را از یک اسلاید نمای کلی بررسی کنید.

![انتخاب اسلایدها برای Zoom اسلاید](slidezoomsel.png)

برای اشیای Zoom اسلاید، Aspose.Slides enumeration [ZoomImageType](https://reference.aspose.com/slides/python-java/aspose.slides/zoomimagetype/) ، کلاس [ZoomFrame](https://reference.aspose.com/slides/python-java/aspose.slides/zoomframe/) و متدهای موجود در کلاس [ShapeCollection](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/) را فراهم می‌کند.

### **ایجاد فریم‌های Zoom**

از [ShapeCollection.addZoomFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addZoomFrame) برای قرار دادن لینک‌های اسلایدهای تک تک روی یک اسلاید نمای کلی استفاده کنید. این مثال دو اسلاید هدف با پس‌زمینه‌ها و برچسب‌های متفاوت ایجاد می‌کند، سپس پیش‌نمایش هر یک را به اسلاید اول اضافه می‌کند و ارائه را به صورت PPTX ذخیره می‌نماید. موقعیت و ابعاد فریم‌ها بر حسب نقطه (points) مشخص شده‌اند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    overview_slide = presentation.getSlides().get_Item(0)

    second_slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    third_slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())

    second_slide.getBackground().setType(BackgroundType.OwnBackground)
    second_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    second_slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.CYAN)

    text_box = second_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200)
    text_box.getTextFrame().setText("Second Slide")

    third_slide.getBackground().setType(BackgroundType.OwnBackground)
    third_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    third_slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color(189, 183, 107))

    text_box = third_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200)
    text_box.getTextFrame().setText("Third Slide")

    overview_slide.getShapes().addZoomFrame(20, 20, 250, 200, second_slide)
    overview_slide.getShapes().addZoomFrame(200, 250, 250, 200, third_slide)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **ایجاد فریم‌های Zoom با تصاویر سفارشی**

یک تصویر سفارشی را به [ShapeCollection.addZoomFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addZoomFrame) پاس بدهید تا پیش‌نمایش پیش‌فرض اسلاید هدف را جایگزین کنید. این مثال به یک تصویر محلی نیاز دارد، آن را با [Images.fromFile](https://reference.aspose.com/slides/python-java/aspose.slides/images/#fromFile) بارگذاری می‌کند و با استفاده از [ImageCollection.addImage](https://reference.aspose.com/slides/python-java/aspose.slides/imagecollection/#addImage) به ارائه اضافه می‌کند. فریم حاصل آن تصویر را نمایش می‌دهد در حالی که هنوز به اسلاید دوم لینک دارد.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    overview_slide = presentation.getSlides().get_Item(0)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().setType(BackgroundType.OwnBackground)
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.CYAN)

    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200)
    text_box.getTextFrame().setText("Second Slide")

    image = Images.fromFile("image.png")
    try:
        preview_image = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    overview_slide.getShapes().addZoomFrame(20, 20, 300, 200, slide, preview_image)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **قالب‌بندی فریم‌های Zoom**

این مثال دو فریم Zoom اسلاید را سفارشی می‌کند. تصویر محلی را به فریم اول از طریق [ZoomObject.setZoomImage](https://reference.aspose.com/slides/python-java/aspose.slides/zoomobject/#setZoomImage) اختصاص می‌دهد و به فریم دوم حاشیه‌رنگ صورتی به ضخامت پنج نقطه و با الگوی خط‌خط‑نقطه‑خط از طریق [Shape.getLineFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getLineFormat) می‌افزاید. با پاس دادن `False` به [ZoomObject.setShowBackground](https://reference.aspose.com/slides/python-java/aspose.slides/zoomobject/#setShowBackground) پس‌زمینه فریم دوم مخفی می‌شود. برای پیش‌نمایش سفارشی به یک تصویر محلی نیاز است؛ هر دو فریم هدف اسلاید خود را در PPTX ذخیره‑شده حفظ می‌کنند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, LineDashStyle, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    overview_slide = presentation.getSlides().get_Item(0)

    second_slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    third_slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())

    second_slide.getBackground().setType(BackgroundType.OwnBackground)
    second_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    second_slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.CYAN)

    text_box = second_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200)
    text_box.getTextFrame().setText("Second Slide")

    third_slide.getBackground().setType(BackgroundType.OwnBackground)
    third_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    third_slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color(189, 183, 107))

    text_box = third_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200)
    text_box.getTextFrame().setText("Third Slide")

    first_zoom_frame = overview_slide.getShapes().addZoomFrame(20, 20, 250, 200, second_slide)
    second_zoom_frame = overview_slide.getShapes().addZoomFrame(200, 250, 250, 200, third_slide)

    image = Images.fromFile("image.png")
    try:
        preview_image = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    first_zoom_frame.setZoomImage(preview_image)

    second_zoom_frame.getLineFormat().setWidth(5)
    second_zoom_frame.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    second_zoom_frame.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color(255, 105, 180))
    second_zoom_frame.getLineFormat().setDashStyle(LineDashStyle.DashDot)

    second_zoom_frame.setShowBackground(False)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Zoom بخش**

Zoom بخش به بخشی از ارائه شما لینک می‌دهد. از آن برای بازبینی یک موضوع یا نشان دادن نحوه ارتباط بخش‌های مختلف استفاده کنید.

![انتخاب یک بخش برای Zoom بخش](seczoomsel.png)

برای اشیای Zoom بخش، Aspose.Slides کلاس [SectionZoomFrame](https://reference.aspose.com/slides/python-java/aspose.slides/sectionzoomframe/) و متدهای موجود در کلاس [ShapeCollection](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/) را ارائه می‌دهد.

### **ایجاد فریم‌های Zoom بخش**

یک بخش را با [SectionCollection.addSection](https://reference.aspose.com/slides/python-java/aspose.slides/sectioncollection/#addSection) ایجاد کنید، سپس بخش برگشتی را به [ShapeCollection.addSectionZoomFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addSectionZoomFrame) پاس بدهید. این مثال یک Zoom بخش را بر روی اسلاید اول قرار می‌دهد و آن را به بخشی که با یک اسلاید رنگی شروع می‌شود لینک می‌کند. موقعیت و ابعاد فریم بر حسب نقطه مشخص شده‌اند و ارائه به صورت PPTX ذخیره می‌شود.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    overview_slide = presentation.getSlides().get_Item(0)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color(154, 205, 50))
    slide.getBackground().setType(BackgroundType.OwnBackground)

    section = presentation.getSections().addSection("Section 1", slide)
    section_zoom_frame = overview_slide.getShapes().addSectionZoomFrame(20, 20, 300, 200, section)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **ایجاد فریم‌های Zoom بخش با تصاویر سفارشی**

 overload تصویری متد [ShapeCollection.addSectionZoomFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addSectionZoomFrame) به شما اجازه می‌دهد پیش‌نمایش سفارشی بدون تغییر بخش مقصد نمایش داده شود. این مثال به یک تصویر محلی نیاز دارد که با [Images.fromFile](https://reference.aspose.com/slides/python-java/aspose.slides/images/#fromFile) بارگذاری می‌شود و با [ImageCollection.addImage](https://reference.aspose.com/slides/python-java/aspose.slides/imagecollection/#addImage) اضافه می‌شود. ارائه ذخیره‌شده شامل یک Zoom بخش بر روی اسلاید اول است که به بخش تازه‌ساخته لینک دارد.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    overview_slide = presentation.getSlides().get_Item(0)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color(154, 205, 50))
    slide.getBackground().setType(BackgroundType.OwnBackground)

    image = Images.fromFile("image.png")
    try:
        preview_image = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    section = presentation.getSections().addSection("Section 1", slide)
    section_zoom_frame = overview_slide.getShapes().addSectionZoomFrame(20, 20, 300, 200, section, preview_image)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **تغییر بخش هدف یک Zoom بخش**

از [SectionZoomFrame.setTargetSection](https://reference.aspose.com/slides/python-java/aspose.slides/sectionzoomframe/#setTargetSection) برای تغییر مسیر یک Zoom بخش موجود بدون نیاز به ساخت مجدد آن استفاده کنید. یک بخش پر شده از مجموعه [Presentation.getSections](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getSections) همان ارائه را انتخاب کنید. اختصاص دادن یک بخش خالی هدف فعلی را تغییری نمی‌دهد، بنابراین قبل از اختصاص، به [Section.getSlidesListOfSection](https://reference.aspose.com/slides/python-java/aspose.slides/section/#getSlidesListOfSection) مراجعه کنید. برای اطلاعات بیشتر درباره بخش‌ها، به [Manage Slide Sections](/slides/fa/python-java/slide-section/) مراجعه کنید.

مثال زیر یک فایل ارائه را بارگذاری می‌کند که باید شامل چندین بخش پر شده باشد، یک Zoom بخش موجود به نام `Section navigation` داشته باشد و بخشی با نام منحصر به فرد `Results` داشته باشد. این مثال تمام اسلایدها را برای یافتن Zoom جستجو می‌کند و مقصد را بر اساس نام پیدا می‌کند نه بر اساس ایندکس مجموعه‌ای که ممکن است هنگام ترتیب‌گذاری مجدد بخش‌ها تغییر کند. اگر نام‌ها یکتا نیستند، می‌توانید از [Section.getSectionId](https://reference.aspose.com/slides/python-java/aspose.slides/section/#getSectionId) برای شناسایی مقصد استفاده کنید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SectionZoomFrame

presentation = Presentation("section-zoom.pptx")
try:
    zoom = None
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if isinstance(shape, SectionZoomFrame) and shape.getName() == "Section navigation":
                zoom = shape
                break
        if zoom is not None:
            break

    target_section = None
    for section in presentation.getSections():
        if section.getName() == "Results":
            target_section = section
            break

    if zoom is None or target_section is None:
        print("The section zoom or destination section was not found.")
    elif target_section.getSlidesListOfSection().size() == 0:
        print("The destination section is empty.")
    else:
        current_section = zoom.getTargetSection()
        current_name = "" if current_section is None else current_section.getName()
        print("Current section: " + str(current_name))
        zoom.setTargetSection(target_section)
        presentation.save("section-zoom-updated.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **قالب‌بندی فریم‌های Zoom بخش**

این مثال یک Zoom بخش را به ابعاد ۱۰۰ در ۷۵ نقطه جابه‌جا و اندازه‌گیری می‌کند، تصویر محلی را از طریق [ZoomObject.setZoomImage](https://reference.aspose.com/slides/python-java/aspose.slides/zoomobject/#setZoomImage) اختصاص می‌دهد و حاشیه قهوه‌ای با ضخامت ۲٫۵ نقطه و الگوی خط‌خط‑نقطه‑خط اعمال می‌کند. با فعال کردن [ZoomObject.setReturnToParent](https://reference.aspose.com/slides/python-java/aspose.slides/zoomobject/#setReturnToParent) پس از بخش به اسلاید منبع بازمی‌گردد، با غیرفعال کردن [ZoomObject.setShowBackground](https://reference.aspose.com/slides/python-java/aspose.slides/zoomobject/#setShowBackground) پس‌زمینه مخفی می‌شود و با تنظیم [ZoomObject.setTransitionDuration](https://reference.aspose.com/slides/python-java/aspose.slides/zoomobject/#setTransitionDuration) به ۱٫۵ ثانیه مدت زمان انتقال تنظیم می‌شود. برای پیش‌نمایش سفارشی به تصویر محلی نیاز است.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, LineDashStyle, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    overview_slide = presentation.getSlides().get_Item(0)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color(154, 205, 50))
    slide.getBackground().setType(BackgroundType.OwnBackground)

    section = presentation.getSections().addSection("Section 1", slide)

    section_zoom_frame = overview_slide.getShapes().addSectionZoomFrame(20, 20, 300, 200, section)
    section_zoom_frame.setX(100)
    section_zoom_frame.setY(300)
    section_zoom_frame.setWidth(100)
    section_zoom_frame.setHeight(75)

    image = Images.fromFile("image.png")
    try:
        preview_image = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    section_zoom_frame.setZoomImage(preview_image)

    section_zoom_frame.setReturnToParent(True)
    section_zoom_frame.setShowBackground(False)

    section_zoom_frame.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    section_zoom_frame.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color(165, 42, 42))
    section_zoom_frame.getLineFormat().setDashStyle(LineDashStyle.DashDot)
    section_zoom_frame.getLineFormat().setWidth(2.5)

    section_zoom_frame.setTransitionDuration(1.5)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Zoom خلاصه**

Zoom خلاصه نمای کلی از بخش‌های ارائه را فراهم می‌کند. در طول نمایش اسلاید، می‌توانید از آن برای پرش به یک بخش، جلو رفتن یا بازدید مجدد از یک موضوع بدون پیروی از ترتیب اسلایدها استفاده کنید.

![انتخاب بخش‌ها برای Zoom خلاصه](sumzoomsel.png)

برای اشیای Zoom خلاصه، Aspose.Slides کلاس‌های [SummaryZoomFrame](https://reference.aspose.com/slides/python-java/aspose.slides/summaryzoomframe/)، [SummaryZoomSection](https://reference.aspose.com/slides/python-java/aspose.slides/summaryzoomsection/) و [SummaryZoomSectionCollection](https://reference.aspose.com/slides/python-java/aspose.slides/summaryzoomsectioncollection/) و متدهای موجود در کلاس [ShapeCollection](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/) را فراهم می‌کند.

### **ایجاد یک Zoom خلاصه**

از [ShapeCollection.addSummaryZoomFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addSummaryZoomFrame) برای ساخت نمای کلی از بخش‌های ارائه استفاده کنید. این مثال چهار بخش با پس‌زمینه‌های اسلاید متفاوت ایجاد می‌کند و یک Zoom خلاصه را به اسلاید اول اضافه می‌کند. موقعیت و ابعاد فریم بر حسب نقطه تنظیم شده و نمای کلی حاصل در یک ارائه PPTX ذخیره می‌شود.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    overview_slide = presentation.getSlides().get_Item(0)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color(165, 42, 42))
    slide.getBackground().setType(BackgroundType.OwnBackground)

    presentation.getSections().addSection("Section 1", slide)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.CYAN)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    presentation.getSections().addSection("Section 2", slide)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color(127, 255, 0))
    slide.getBackground().setType(BackgroundType.OwnBackground)

    presentation.getSections().addSection("Section 3", slide)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color(0, 100, 0))
    slide.getBackground().setType(BackgroundType.OwnBackground)

    presentation.getSections().addSection("Section 4", slide)

    summary_zoom_frame = overview_slide.getShapes().addSummaryZoomFrame(150, 50, 300, 200)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **افزودن و حذف یک بخش Zoom خلاصه**

یک Zoom خلاصه اشیای [SummaryZoomSection](https://reference.aspose.com/slides/python-java/aspose.slides/summaryzoomsection/) خود را در [SummaryZoomFrame.getSummaryZoomCollection](https://reference.aspose.com/slides/python-java/aspose.slides/summaryzoomframe/#getSummaryZoomCollection) ذخیره می‌کند. این مثال نمای کلی از دو بخش را ایجاد می‌کند، با استفاده از [SummaryZoomSectionCollection.addSummaryZoomSection](https://reference.aspose.com/slides/python-java/aspose.slides/summaryzoomsectioncollection/#addSummaryZoomSection) بخش سوم را اضافه می‌کند و با [SummaryZoomSectionCollection.removeSummaryZoomSection](https://reference.aspose.com/slides/python-java/aspose.slides/summaryzoomsectioncollection/#removeSummaryZoomSection) ورودی اولین بخش را حذف می‌کند. حذف ورودی بخش، بخش ارائه و اسلایدهای آن را دست نخورده باقی می‌گذارد.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    overview_slide = presentation.getSlides().get_Item(0)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color(165, 42, 42))
    slide.getBackground().setType(BackgroundType.OwnBackground)

    first_section = presentation.getSections().addSection("Section 1", slide)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.CYAN)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    presentation.getSections().addSection("Section 2", slide)

    summary_zoom_frame = overview_slide.getShapes().addSummaryZoomFrame(150, 50, 300, 200)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color(127, 255, 0))
    slide.getBackground().setType(BackgroundType.OwnBackground)

    third_section = presentation.getSections().addSection("Section 3", slide)

    summary_zoom_frame.getSummaryZoomCollection().addSummaryZoomSection(third_section)

    summary_zoom_frame.getSummaryZoomCollection().removeSummaryZoomSection(first_section)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **قالب‌بندی بخش‌های Zoom خلاصه**

این مثال اولین ورودی در [SummaryZoomFrame.getSummaryZoomCollection](https://reference.aspose.com/slides/python-java/aspose.slides/summaryzoomframe/#getSummaryZoomCollection) را با استفاده از ایندکس صفر (`0`) قالب‌بندی می‌کند. برای [ZoomObject.setZoomImage](https://reference.aspose.com/slides/python-java/aspose.slides/zoomobject/#setZoomImage) به یک تصویر محلی نیاز دارد، حاشیه سیاه به ضخامت ۱٫۵ نقطه و الگوی خط‌خط‑نقطه‑خط اعمال می‌کند و [ZoomObject.setTransitionDuration](https://reference.aspose.com/slides/python-java/aspose.slides/zoomobject/#setTransitionDuration) را به ۱٫۵ ثانیه تنظیم می‌نماید. با پاس دادن `False` به [ZoomObject.setReturnToParent](https://reference.aspose.com/slides/python-java/aspose.slides/zoomobject/#setReturnToParent) بازگشت خودکار به اسلاید خلاصه برای این ورودی غیرفعال می‌شود.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, LineDashStyle, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    overview_slide = presentation.getSlides().get_Item(0)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color(165, 42, 42))
    slide.getBackground().setType(BackgroundType.OwnBackground)

    presentation.getSections().addSection("Section 1", slide)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.CYAN)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    presentation.getSections().addSection("Section 2", slide)

    summary_zoom_frame = overview_slide.getShapes().addSummaryZoomFrame(150, 50, 300, 200)

    summary_section = summary_zoom_frame.getSummaryZoomCollection().get_Item(0)

    image = Images.fromFile("image.png")
    try:
        preview_image = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    summary_section.setZoomImage(preview_image)
    summary_section.setReturnToParent(False)

    summary_section.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    summary_section.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    summary_section.getLineFormat().setDashStyle(LineDashStyle.DashDot)
    summary_section.getLineFormat().setWidth(1.5)

    summary_section.setTransitionDuration(1.5)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **سؤال‌پرسش (FAQ)**

**آیا می‌توانم کنترل کنم که پس از نمایش هدف به اسلاید «والد» بازگردم؟**

بله. با فراخوانی [ZoomObject.setReturnToParent](https://reference.aspose.com/slides/python-java/aspose.slides/zoomobject/#setReturnToParent) با مقدار `True` پس از نمایش محتوای هدف به اسلاید منبع باز می‌گردید.

**آیا می‌توانم «سرعت» یا مدت زمان انتقال Zoom را تنظیم کنم؟**

بله. با استفاده از [ZoomObject.setTransitionDuration](https://reference.aspose.com/slides/python-java/aspose.slides/zoomobject/#setTransitionDuration) می‌توانید مدت زمان انتقال را بر حسب ثانیه تنظیم کنید.

**آیا محدودیتی برای تعداد اشیای Zoom در یک ارائه وجود دارد؟**

محدودیت سخت‌گیرانه‌ای در API مستند نشده است. محدودیت‌های عملی به پیچیدگی کلی ارائه و عملکرد نمایشگر بستگی دارد. می‌توانید فریم‌های Zoom زیادی اضافه کنید، اما به حجم فایل و زمان رندر توجه داشته باشید.