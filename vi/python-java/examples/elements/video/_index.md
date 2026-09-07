---
title: Video
type: docs
weight: 80
url: /vi/python-java/examples/elements/video/
keywords:
- ví dụ mã
- video
- khung video
- thêm video
- truy cập video
- xóa video
- phát lại video
- PowerPoint
- OpenDocument
- bài thuyết trình
- Python
- Java
- Aspose.Slides
description: "Sử dụng Aspose.Slides for Python via Java để thêm, truy cập, xóa và cấu hình các khung video trong các bài thuyết trình PowerPoint và OpenDocument."
---
Bài viết này trình bày cách thêm khung video và thiết lập tùy chọn phát lại bằng **Aspose.Slides for Python via Java**.

Cài đặt gói như mô tả trong [Installation](/slides/vi/python-java/installation/). Mỗi ví dụ sẽ import `asposeslides` trước khi khởi động JVM, sau đó import API khi JVM đã chạy.

## **Thêm Khung Video**

Chèn một khung video tham chiếu tới tệp video bên ngoài.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Thêm một khung video liên kết tới tệp video.
    video_frame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4")
finally:
    presentation.dispose()
```

## **Truy Cập Khung Video**

Lấy khung video đầu tiên được thêm vào một slide.

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

    # Truy cập khung video đầu tiên trên slide.
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

## **Xóa Khung Video**

Xóa một khung video khỏi slide.

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

    # Xóa khung video.
    slide.getShapes().remove(video_frame)
finally:
    presentation.dispose()
```

## **Thiết Lập Phát Lại Video**

Cấu hình video để phát tự động khi slide được hiển thị.

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

    # Cấu hình video để tự động phát.
    video_frame.setPlayMode(VideoPlayModePreset.Auto)
finally:
    presentation.dispose()
```