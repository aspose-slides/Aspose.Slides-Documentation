---
title: الصوت
type: docs
weight: 70
url: /ar/python-java/examples/elements/audio/
keywords:
- مثال على الكود
- صوت
- إطار صوت
- إضافة صوت
- الوصول إلى صوت
- إزالة صوت
- تشغيل صوت
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Java
- Aspose.Slides
description: "استخدام Aspose.Slides for Python via Java لإضافة، والوصول إلى، وإزالة، وتكوين إطارات الصوت في عروض PowerPoint وOpenDocument التقديمية."
---
توضح هذه المقالة كيفية تضمين إطارات الصوت والتحكم في تشغيلها باستخدام **Aspose.Slides for Python via Java**. تُظهر الأمثلة التالية عمليات الصوت الأساسية.

قم بتثبيت الحزمة كما هو موضح في [Installation](/slides/ar/python-java/installation/). كل مثال يستورد `asposeslides` قبل بدء تشغيل JVM، ثم يستورد API بعد تشغيل JVM.

## **إضافة إطار صوت**

إدراج إطار صوت فارغ يمكنه لاحقًا احتواء بيانات الصوت المضمنة.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from java.io import ByteArrayInputStream
from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    audio_data = jpype.JArray(jpype.JByte)(0)
    audio_stream = ByteArrayInputStream(audio_data)

    # إنشاء إطار صوت فارغ (سيتم تضمين الصوت لاحقًا).
    audio_frame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio_stream)
finally:
    presentation.dispose()
```

## **الوصول إلى إطار صوت**

يقوم هذا الكود باسترداد أول إطار صوت في الشريحة.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from java.io import ByteArrayInputStream
from asposeslides.api import AudioFrame, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    audio_data = jpype.JArray(jpype.JByte)(0)
    audio_stream = ByteArrayInputStream(audio_data)
    slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio_stream)

    # الوصول إلى أول إطار صوت في الشريحة.
    first_audio = None
    for shape in slide.getShapes():
        if isinstance(shape, AudioFrame):
            first_audio = shape
            break

    if first_audio is None:
        print("The slide contains no audio frames.")
finally:
    presentation.dispose()
```

## **إزالة إطار صوت**

احذف إطار الصوت الذي تم إضافته مسبقًا.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from java.io import ByteArrayInputStream
from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    audio_data = jpype.JArray(jpype.JByte)(0)
    audio_stream = ByteArrayInputStream(audio_data)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio_stream)

    # إزالة إطار الصوت.
    slide.getShapes().remove(audio_frame)
finally:
    presentation.dispose()
```

## **تعيين تشغيل الصوت**

قم بتكوين إطار الصوت ليتم تشغيله تلقائيًا عندما تظهر الشريحة.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from java.io import ByteArrayInputStream
from asposeslides.api import AudioPlayModePreset, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    audio_data = jpype.JArray(jpype.JByte)(0)
    audio_stream = ByteArrayInputStream(audio_data)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio_stream)

    # تشغيل تلقائيًا عندما تظهر الشريحة.
    audio_frame.setPlayMode(AudioPlayModePreset.Auto)
finally:
    presentation.dispose()
```