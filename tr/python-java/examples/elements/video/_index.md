---
title: Video
type: docs
weight: 80
url: /tr/python-java/examples/elements/video/
keywords:
- kod örneği
- video
- video çerçevesi
- video ekle
- videoya eriş
- videoyu kaldır
- video oynatma
- PowerPoint
- OpenDocument
- sunum
- Python
- Java
- Aspose.Slides
description: "PowerPoint ve OpenDocument sunumlarında video çerçevelerini eklemek, erişmek, kaldırmak ve yapılandırmak için Java aracılığıyla Python için Aspose.Slides kullanın."
---
Bu makale, **Aspose.Slides for Python via Java** kullanarak video çerçevelerini eklemeyi ve oynatma seçeneklerini ayarlamayı gösterir.

Paketi, [Installation](/slides/tr/python-java/installation/) bölümünde açıklandığı şekilde yükleyin. Her örnek, JVM’i başlatmadan önce `asposeslides` paketini içe aktarır, ardından JVM çalıştıktan sonra API’yi içe aktarır.

## **Video Çerçevesi Ekle**

Harici bir video dosyasına referans veren bir video çerçevesi ekleyin.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Video dosyasına bağlanan bir video çerçevesi ekleyin.
    video_frame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4")
finally:
    presentation.dispose()
```

## **Video Çerçevesine Erişim**

Bir slayta eklenen ilk video çerçevesini alın.

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

    # Slaytta ilk video çerçevesine erişin.
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

## **Video Çerçevesini Kaldır**

Video çerçevesini slayttan silin.

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

    # Video çerçevesini kaldır.
    slide.getShapes().remove(video_frame)
finally:
    presentation.dispose()
```

## **Video Oynatmayı Ayarla**

Slayt gösterildiğinde videonun otomatik olarak oynatılacak şekilde yapılandırın.

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

    # Videoyu otomatik olarak oynatılacak şekilde yapılandır.
    video_frame.setPlayMode(VideoPlayModePreset.Auto)
finally:
    presentation.dispose()
```