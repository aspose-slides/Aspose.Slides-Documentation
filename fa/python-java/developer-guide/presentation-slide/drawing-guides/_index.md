---
title: مدیریت راهنماهای رسم در ارائه‌ها در Python
linktitle: راهنماهای رسم
type: docs
weight: 85
url: /fa/python-java/drawing-guides/
keywords:
- راهنمای رسم
- راهنمای افقی
- راهنمای عمودی
- راهنمای هم‌ترازی
- نمای اسلاید
- مستر اسلاید
- اسلاید طرح‌بندی
- مستر یادداشت
- مستر جزوه
- PowerPoint
- ارائه
- Python
- Aspose.Slides
description: "افزودن، دسترسی و حذف راهنماهای افقی و عمودی در ارائه‌های PowerPoint با استفاده از Aspose.Slides برای Python via Java."
---
## **نمای کلی**

راهنماهای رسم خطوط افقی و عمودی قابل تنظیمی هستند که به کاربران کمک می‌کنند تا اشکال را به‌صورت مداوم هنگام ویرایش یک ارائه در PowerPoint هم‌راستا کنند. این راهنماها به‌ویژه زمانی مفید هستند که یک برنامه یک ارائه را تولید می‌کند که بعداً به‌صورت دستی اصلاح خواهد شد: برنامه می‌تواند همان ابزارهای هم‌راستایی را که نویسندگان باید هنگام افزودن یا جابه‌جایی محتوا دنبال کنند، ذخیره کند.

راهنماهای رسم ابزارهای ویرایشی هستند، نه محتوای اسلاید. آن‌ها در نمایش اسلاید یا خروجی رندر شده ظاهر نمی‌شوند. Aspose.Slides for Python via Java این‌ها را از طریق کلاس [DrawingGuidesCollection](https://reference.aspose.com/slides/fa/python-java/aspose.slides/drawingguidescollection/) در دسترس قرار می‌دهد. یک راهنما توسط [DrawingGuide](https://reference.aspose.com/slides/fa/python-java/aspose.slides/drawingguide/) نمایان می‌شود و دارای جهت، موقعیت و رنگ است.

موقعیت بر حسب پوینت از گوشهٔ بالا‑چپ اسلاید یا مستر مربوطه اندازه‌گیری می‌شود. یک راهنمای عمودی از یک مختصات افقی استفاده می‌کند که معمولاً بین صفر و عرض اسلاید قرار دارد. یک راهنمای افقی از یک مختصات عمودی استفاده می‌کند که معمولاً بین صفر و ارتفاع اسلاید قرار دارد.

## **افزودن راهنماها به نمای اسلاید**

از [CommonSlideViewProperties.getDrawingGuides](https://reference.aspose.com/slides/fa/python-java/aspose.slides/commonslideviewproperties/#getDrawingGuides) برای مدیریت راهنماهایی که هنگام ویرایش اسلایدهای معمولی نمایش داده می‌شوند، استفاده کنید. با فراخوانی [DrawingGuidesCollection.add](https://reference.aspose.com/slides/fa/python-java/aspose.slides/drawingguidescollection/#add) یک مقدار [Orientation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/orientation/) و موقعیتی بر حسب پوینت، یک راهنما اضافه کنید.

مثال زیر یک راهنمای عمودی را در سمت راست مرکز اسلاید و یک راهنمای افقی را در زیر آن اضافه می‌کند:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Orientation, SaveFormat

presentation = Presentation()
try:
    slide_size = presentation.getSlideSize().getSize()
    guides = presentation.getViewProperties().getSlideViewProperties().getDrawingGuides()

    guides.add(Orientation.Vertical, slide_size.getWidth() / 2 + 12.5)
    guides.add(Orientation.Horizontal, slide_size.getHeight() / 2 + 12.5)

    presentation.save("drawing-guides.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **دسترسی به راهنماهای رسم**

متدهای [DrawingGuidesCollection.getCount](https://reference.aspose.com/slides/fa/python-java/aspose.slides/drawingguidescollection/#getCount) و [DrawingGuidesCollection.get_Item](https://reference.aspose.com/slides/fa/python-java/aspose.slides/drawingguidescollection/#get_Item) دسترسی به راهنماهای موجود را فراهم می‌کنند. متدهای [DrawingGuide.getOrientation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/drawingguide/#getOrientation)، [DrawingGuide.getPosition](https://reference.aspose.com/slides/fa/python-java/aspose.slides/drawingguide/#getPosition) و [DrawingGuide.getColor](https://reference.aspose.com/slides/fa/python-java/aspose.slides/drawingguide/#getColor) مقادیری را برمی‌گردانند که می‌توان آنها را با متدهای setter مربوطه نیز تغییر داد.

مثال زیر راهنماهای نمای اسلاید را از ارائه‌ای که در بالا ایجاد شد، می‌خواند:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("drawing-guides.pptx")
try:
    guides = presentation.getViewProperties().getSlideViewProperties().getDrawingGuides()

    for index in range(guides.getCount()):
        guide = guides.get_Item(index)
        print(f"Guide {index}: orientation = {guide.getOrientation()}, position = {guide.getPosition()}, color = {guide.getColor()}")
finally:
    presentation.dispose()
```

## **افزودن راهنماها به مسترها و اسلایدهای طرح‌بندی**

یک مستر اسلاید و هر یک از اسلایدهای طرح‌بندی آن می‌توانند مجموعهٔ راهنماهای رسم خود را داشته باشند. برای یک مستر اسلاید از [MasterSlide.getDrawingGuides](https://reference.aspose.com/slides/fa/python-java/aspose.slides/masterslide/#getDrawingGuides) و برای یک اسلاید طرح‌بندی از [LayoutSlide.getDrawingGuides](https://reference.aspose.com/slides/fa/python-java/aspose.slides/layoutslide/#getDrawingGuides) استفاده کنید.

مثال زیر یک راهنمای عمودی را به اولین مستر اسلاید و یک راهنمای افقی را به اولین اسلاید طرح‌بندی اضافه می‌کند:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Orientation, SaveFormat

presentation = Presentation()
try:
    slide_size = presentation.getSlideSize().getSize()
    master_guides = presentation.getMasters().get_Item(0).getDrawingGuides()
    layout_guides = presentation.getLayoutSlides().get_Item(0).getDrawingGuides()

    master_guides.add(Orientation.Vertical, slide_size.getWidth() / 2 - 20)
    layout_guides.add(Orientation.Horizontal, slide_size.getHeight() / 2 + 20)

    presentation.save("master-layout-drawing-guides.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **افزودن راهنماها به مسترهای یادداشت و جزوه**

مستری‌های یادداشت و جزوه نیز از راهنماهای رسم پشتیبانی می‌کنند. برای دسترسی به مجموعه‌های آنها از [MasterNotesSlide.getDrawingGuides](https://reference.aspose.com/slides/fa/python-java/aspose.slides/masternotesslide/#getDrawingGuides) و [MasterHandoutSlide.getDrawingGuides](https://reference.aspose.com/slides/fa/python-java/aspose.slides/masterhandoutslide/#getDrawingGuides) استفاده کنید. اگر ارائه‌ای یکی از این مسترها را نداشته باشد، `MasterNotesSlideManager.setDefaultMasterNotesSlide` یا `MasterHandoutSlideManager.setDefaultMasterHandoutSlide` مستر پیش‌فرض را ایجاد کرده و برمی‌گرداند.

مثال زیر یک راهنمای افقی را به یک مستر یادداشت و یک راهنمای عمودی را به یک مستر جزوه اضافه می‌کند:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Orientation, SaveFormat

presentation = Presentation()
try:
    notes_size = presentation.getNotesSize().getSize()
    notes_master = presentation.getMasterNotesSlideManager().setDefaultMasterNotesSlide()
    handout_master = presentation.getMasterHandoutSlideManager().setDefaultMasterHandoutSlide()

    notes_master.getDrawingGuides().add(Orientation.Horizontal, notes_size.getHeight() / 2 + 50)
    handout_master.getDrawingGuides().add(Orientation.Vertical, notes_size.getWidth() / 2 - 50)

    presentation.save("notes-handout-drawing-guides.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **پاک کردن راهنماهای رسم**

با فراخوانی [DrawingGuidesCollection.clear](https://reference.aspose.com/slides/fa/python-java/aspose.slides/drawingguidescollection/#clear) می‌توانید همهٔ راهنماها را از یک مجموعهٔ خاص حذف کنید. پاک کردن یک مجموعه، بر راهنماهای ذخیره‌شده در حوزهٔ دیگر تأثیر نمی‌گذارد.

مثال زیر راهنماهای نمای اسلاید و تمام راهنماهای موجود در مسترهای اسلاید، اسلایدهای طرح‌بندی، مستر یادداشت و مستر جزوه را بدون ایجاد مسترهای از دست رفته پاک می‌کند:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation-with-guides.pptx")
try:
    presentation.getViewProperties().getSlideViewProperties().getDrawingGuides().clear()

    for master_slide in presentation.getMasters():
        master_slide.getDrawingGuides().clear()

    for layout_slide in presentation.getLayoutSlides():
        layout_slide.getDrawingGuides().clear()

    notes_master = presentation.getMasterNotesSlideManager().getMasterNotesSlide()
    if notes_master is not None:
        notes_master.getDrawingGuides().clear()

    handout_master = presentation.getMasterHandoutSlideManager().getMasterHandoutSlide()
    if handout_master is not None:
        handout_master.getDrawingGuides().clear()

    presentation.save("presentation-without-guides.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **سؤال‌های متداول**

**آیا راهنماهای رسم در نمایش اسلاید یا تصاویر صادرشده ظاهر می‌شوند؟**

خیر. راهنماهای رسم ابزارهای هم‌راستایی برای ویرایش هستند و به‌عنوان محتوای ارائه رندر نمی‌شوند.

**آیا می‌توان یک راهنمای رسم را مستقیماً به یک اسلاید نرمال افزود؟**

راهنماهای ویرایشی اسلایدهای نرمال در ویژگی‌های نمای اسلاید ارائه ذخیره می‌شوند. مجموعه‌های راهنماهای جداگانه‌ای برای مسترهای اسلاید، اسلایدهای طرح‌بندی، مسترهای یادداشت و مسترهای جزوه موجود است.

**برای موقعیت راهنماها از چه واحدهایی استفاده می‌شود؟**

موقعیت‌ها بر حسب پوینت مشخص می‌شوند، جایی که ۷۲ پوینت برابر یک اینچ است. موقعیت‌های عمودی از لبهٔ چپ اندازه‌گیری می‌شوند و موقعیت‌های افقی از لبهٔ بالا.

**آیا پاک کردن راهنماهای رسم باعث حذف اشکال یا تغییر محتوی اسلاید می‌شود؟**

خیر. متد [DrawingGuidesCollection.clear](https://reference.aspose.com/slides/fa/python-java/aspose.slides/drawingguidescollection/#clear) تنها راهنماهای موجود در مجموعهٔ انتخاب‌شده را حذف می‌کند. اشکال و سایر محتویات اسلاید بدون تغییر باقی می‌مانند.