---
title: Video
type: docs
weight: 80
url: /id/python-java/examples/elements/video/
keywords:
- contoh kode
- video
- bingkai video
- tambahkan video
- akses video
- hapus video
- pemutaran video
- PowerPoint
- OpenDocument
- presentasi
- Python
- Java
- Aspose.Slides
description: "Gunakan Aspose.Slides for Python via Java untuk menambahkan, mengakses, menghapus, dan mengonfigurasi bingkai video dalam presentasi PowerPoint dan OpenDocument."
---
Artikel ini menunjukkan cara menambahkan bingkai video dan mengatur opsi pemutaran menggunakan **Aspose.Slides for Python via Java**.

Instal paket seperti yang dijelaskan di [Installation](/slides/id/python-java/installation/). Setiap contoh mengimpor `asposeslides` sebelum memulai JVM, kemudian mengimpor API setelah JVM berjalan.

## **Menambahkan Bingkai Video**

Sisipkan bingkai video yang merujuk ke file video eksternal.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Tambahkan bingkai video yang terhubung ke file video.
    video_frame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4")
finally:
    presentation.dispose()
```

## **Mengakses Bingkai Video**

Ambil bingkai video pertama yang ditambahkan ke slide.

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

    # Akses bingkai video pertama pada slide.
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

## **Menghapus Bingkai Video**

Hapus bingkai video dari slide.

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

    # Hapus bingkai video.
    slide.getShapes().remove(video_frame)
finally:
    presentation.dispose()
```

## **Mengatur Pemutaran Video**

Konfigurasikan video agar diputar secara otomatis ketika slide ditampilkan.

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

    # Konfigurasikan video agar diputar secara otomatis.
    video_frame.setPlayMode(VideoPlayModePreset.Auto)
finally:
    presentation.dispose()
```