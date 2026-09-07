---
title: فيديو
type: docs
weight: 80
url: /ar/python-java/examples/elements/video/
keywords:
- مثال على الكود
- فيديو
- إطار فيديو
- إضافة فيديو
- الوصول إلى فيديو
- حذف فيديو
- تشغيل الفيديو
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Java
- Aspose.Slides
description: "استخدم Aspose.Slides for Python via Java لإضافة وإتاحة الوصول وإزالة وتكوين إطارات الفيديو في عروض PowerPoint وOpenDocument."
---
هذه المقالة توضح كيفية إضافة إطارات فيديو وتعيين خيارات التشغيل باستخدام **Aspose.Slides for Python via Java**.

قم بتثبيت الحزمة كما هو موضح في [التثبيت](/slides/ar/python-java/installation/). كل مثال يستورد `asposeslides` قبل بدء الـ JVM، ثم يستورد الـ API بعد تشغيل الـ JVM.

## **إضافة إطار فيديو**

إدراج إطار فيديو يشير إلى ملف فيديو خارجي.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # إضافة إطار فيديو مرتبط بملف فيديو.
    video_frame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4")
finally:
    presentation.dispose()
```

## **الوصول إلى إطار فيديو**

استرجاع أول إطار فيديو تم إضافته إلى شريحة.

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

    # الوصول إلى أول إطار فيديو على الشريحة.
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

## **إزالة إطار فيديو**

حذف إطار فيديو من الشريحة.

```python
import jpype
import asposeslides

if not jpape.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    video_frame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4")

    # إزالة إطار الفيديو.
    slide.getShapes().remove(video_frame)
finally:
    presentation.dispose()
```

## **تعيين تشغيل الفيديو**

تكوين الفيديو للتشغيل تلقائيًا عند عرض الشريحة.

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

    # ضبط الفيديو لتشغيله تلقائيًا.
    video_frame.setPlayMode(VideoPlayModePreset.Auto)
finally:
    presentation.dispose()
```