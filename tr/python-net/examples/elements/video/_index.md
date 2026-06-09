---
title: Video
type: docs
weight: 80
url: /tr/python-net/examples/elements/video/
keywords:
- video
- video çerçevesi
- video ekle
- videoya eriş
- videoyu kaldır
- video oynatma
- kod örnekleri
- PowerPoint
- OpenDocument
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides kullanarak Python'da video ile çalışın: ekleme, değiştirme, kırpma, poster çerçeveleri ve oynatma seçeneklerini ayarlama ve PPT, PPTX ve ODP için sunumları dışa aktarma."
---
**Aspose.Slides for Python via .NET** kullanarak video çerçevelerini gömmeyi ve oynatma seçeneklerini ayarlamayı gösterir.

## **Video Çerçevesi Ekle**

Bir slayta boş bir video çerçevesi ekleyin.

```py
def add_video():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Video çerçevesi ekle.
        video_frame = slide.shapes.add_video_frame(50, 50, 320, 240, "video.mp4")

        presentation.save("video.pptx", slides.export.SaveFormat.PPTX)
```

## **Video Çerçevesine Eriş**

Bir slayta eklenen ilk video çerçevesini alın.

```py
def access_video():
    with slides.Presentation("video.pptx") as presentation:
        slide = presentation.slides[0]

        # Slayttaki ilk video çerçevesine eriş.
        first_video = next(shape for shape in slide.shapes if isinstance(shape, slides.VideoFrame))
```

## **Video Çerçevesini Kaldır**

Slayttan bir video çerçevesini silin.

```py
def remove_video():
    with slides.Presentation("video.pptx") as presentation:
        slide = presentation.slides[0]

        # İlk şeklin bir video çerçevesi olduğunu varsayıyor.
        video_frame = slide.shapes[0]

        # Video çerçevesini kaldır.
        slide.shapes.remove(video_frame)

        presentation.save("video_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Video Oynatmayı Ayarla**

Slayt gösterildiğinde videonun otomatik olarak oynatılmasını yapılandırın.

```py
def set_video_playback():
    with slides.Presentation("video.pptx") as presentation:
        slide = presentation.slides[0]

        # İlk şeklin bir video çerçevesi olduğunu varsayıyor.
        video_frame = slide.shapes[0]

        # Videoyu otomatik olarak oynatacak şekilde yapılandır.
        video_frame.play_mode = slides.VideoPlayModePreset.AUTO

        presentation.save("video_playback.pptx", slides.export.SaveFormat.PPTX)
```