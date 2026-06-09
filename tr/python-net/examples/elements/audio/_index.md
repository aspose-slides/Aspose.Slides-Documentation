---
title: Ses
type: docs
weight: 70
url: /tr/python-net/examples/elements/audio/
keywords:
- ses
- ses çerçevesi
- ses ekle
- sese erişim
- sesi kaldır
- ses oynatımı
- kod örnekleri
- PowerPoint
- OpenDocument
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides kullanarak Python'da sesle çalışın: sesleri ekleyin, değiştirin, çıkarın ve kesin, PowerPoint ve OpenDocument'te slayt ve şekiller için ses seviyesini ve oynatmayı ayarlayın."
---
Ses çerçevelerinin nasıl gömüleceğini ve **Aspose.Slides for Python via .NET** ile oynatmanın nasıl kontrol edileceğini gösterir. Aşağıdaki örnekler temel ses işlemlerini gösterir.

## **Ses Çerçevesi Ekle**

Aşağıdaki kod örneği, bir sunum slaytına ses çerçevesi ekler.

```py
def add_audio():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        with open("audio.wav", "rb") as audio_stream:
            audio_frame = slide.shapes.add_audio_frame_embedded(50, 50, 100, 100, audio_stream)

        presentation.save("audio.pptx", slides.export.SaveFormat.PPTX)
```

## **Ses Çerçevesine Erişim**

Bu kod, slayttan ilk ses çerçevesini alır.

```py
def access_audio():
    with slides.Presentation("audio.pptx") as presentation:
        slide = presentation.slides[0]

        first_audio_frame = None
        for shape in slide.shapes:
            if isinstance(shape, slides.AudioFrame):
                first_audio_frame = shape
                break
```

## **Ses Çerçevesini Kaldır**

Daha önce eklenmiş bir ses çerçevesini sil.

```py
def remove_audio():
    with slides.Presentation("audio.pptx") as presentation:
        slide = presentation.slides[0]

        # İlk şeklin bir AudioFrame olduğunu varsayarak.
        audio_frame = slide.shapes[0]

        # Ses çerçevesini kaldır.
        slide.shapes.remove(audio_frame)

        presentation.save("audio_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Ses Oynatmayı Ayarla**

Ses çerçevesini, slayt göründüğünde otomatik olarak çalacak şekilde yapılandır.

```py
def set_audio_playback():
    with slides.Presentation("audio.pptx") as presentation:
        slide = presentation.slides[0]

        # İlk şeklin bir AudioFrame olduğunu varsayarak.
        audio_frame = slide.shapes[0]

        # Slayt göründüğünde otomatik olarak oynat.
        audio_frame.play_mode = slides.AudioPlayModePreset.AUTO

        presentation.save("audio_playback.pptx", slides.export.SaveFormat.PPTX)
```