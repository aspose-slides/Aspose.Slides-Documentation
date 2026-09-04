---
title: Âm thanh
type: docs
weight: 70
url: /vi/python-java/examples/elements/audio/
keywords:
- ví dụ mã
- âm thanh
- khung âm thanh
- thêm âm thanh
- truy cập âm thanh
- xóa âm thanh
- phát lại âm thanh
- PowerPoint
- OpenDocument
- bài thuyết trình
- Python
- Java
- Aspose.Slides
description: "Sử dụng Aspose.Slides cho Python thông qua Java để thêm, truy cập, xóa và cấu hình các khung âm thanh trong các bài thuyết trình PowerPoint và OpenDocument."
---
Bài viết này trình bày cách nhúng khung âm thanh và điều khiển phát lại bằng **Aspose.Slides for Python via Java**. Các ví dụ sau minh họa các thao tác âm thanh cơ bản.

Cài đặt gói theo mô tả trong [Installation](/slides/vi/python-java/installation/). Mỗi ví dụ sẽ import `asposeslides` trước khi khởi động JVM, sau đó import API khi JVM đã chạy.

## **Thêm khung âm thanh**

Chèn một khung âm thanh trống mà sau này có thể chứa dữ liệu âm thanh nhúng.

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

    # Tạo một khung âm thanh trống (âm thanh sẽ được nhúng sau này).
    audio_frame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio_stream)
finally:
    presentation.dispose()
```

## **Truy cập khung âm thanh**

Đoạn mã này lấy khung âm thanh đầu tiên trên một slide.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpade.startJVM()

from java.io import ByteArrayInputStream
from asposeslides.api import AudioFrame, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    audio_data = jpype.JArray(jpype.JByte)(0)
    audio_stream = ByteArrayInputStream(audio_data)
    slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio_stream)

    # Truy cập khung âm thanh đầu tiên trên slide.
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

## **Xóa khung âm thanh**

Xóa một khung âm thanh đã được thêm trước đó.

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

    # Xóa khung âm thanh.
    slide.getShapes().remove(audio_frame)
finally:
    presentation.dispose()
```

## **Cài đặt phát lại âm thanh**

Cấu hình khung âm thanh để phát tự động khi slide xuất hiện.

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

    # Phát tự động khi slide xuất hiện.
    audio_frame.setPlayMode(AudioPlayModePreset.Auto)
finally:
    presentation.dispose()
```