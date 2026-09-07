---
title: ویدئو
type: docs
weight: 80
url: /fa/python-java/examples/elements/video/
keywords:
- نمونه کد
- ویدئو
- فریم ویدئویی
- افزودن ویدئو
- دسترسی به ویدئو
- حذف ویدئو
- پخش ویدئو
- PowerPoint
- OpenDocument
- ارائه
- Python
- Java
- Aspose.Slides
description: "از Aspose.Slides برای Python از طریق Java برای افزودن، دسترسی، حذف و پیکربندی فریم‌های ویدئویی در ارائه‌های PowerPoint و OpenDocument استفاده کنید."
---
این مقاله نشان می‌دهد چگونه فریم‌های ویدئویی اضافه کنید و گزینه‌های پخش را با استفاده از **Aspose.Slides for Python via Java** تنظیم کنید.

پکیج را همان‌طور که در [Installation](/slides/fa/python-java/installation/) توضیح داده شده است نصب کنید. هر مثال قبل از شروع JVM `asposeslides` را وارد می‌کند، سپس پس از اجرا شدن JVM API را وارد می‌نماید.

## **افزودن فریم ویدئویی**
یک فریم ویدئویی که به یک فایل ویدئویی خارجی ارجاع می‌دهد، وارد کنید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # فریم ویدئویی مرتبط با یک فایل ویدئویی اضافه کنید.
    video_frame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4")
finally:
    presentation.dispose()
```

## **دسترسی به فریم ویدئویی**
اولین فریم ویدئویی اضافه شده به یک اسلاید را بازیابی کنید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, VideoFrame

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4")

    # دسترسی به اولین فریم ویدئویی در اسلاید.
    first_video = None
    for shape in slide.getShapes():
        if isinstance(shape, VideoFrame):
            first_video = shape
            break

    if first_video is None:
        print("The slide contains no video frames.")
finally:
    presentation.dispose()
```

## **حذف فریم ویدئویی**
یک فریم ویدئویی را از اسلاید حذف کنید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    video_frame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4")

    # فریم ویدئویی را حذف کنید.
    slide.getShapes().remove(video_frame)
finally:
    presentation.dispose()
```

## **تنظیم پخش ویدئو**
ویدئو را طوری پیکربندی کنید که به‌صورت خودکار هنگام نمایش اسلاید پخش شود.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, VideoPlayModePreset

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    video_frame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4")

    # پیکربندی ویدئو برای پخش خودکار.
    video_frame.setPlayMode(VideoPlayModePreset.Auto)
finally:
    presentation.dispose()
```