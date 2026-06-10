---
title: Videó
type: docs
weight: 80
url: /hu/python-net/examples/elements/video/
keywords:
- videó
- videókeret
- videó hozzáadása
- videó elérése
- videó eltávolítása
- videó lejátszása
- kódpéldák
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Aspose.Slides
description: "Videóval való munka Pythonban az Aspose.Slides használatával: beszúrás, cserélés, vágás, poszterkeretek és lejátszási beállítások beállítása, valamint prezentációk exportálása PPT, PPTX és ODP formátumokba."
---
Bemutatja, hogyan ágyazhat be videókereteket, és állíthatja be a lejátszási beállításokat a **Aspose.Slides for Python via .NET** használatával.

## **Videókeret hozzáadása**

Helyezzen egy üres videókeretet a diára.

```py
def add_video():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Videókeret hozzáadása.
        video_frame = slide.shapes.add_video_frame(50, 50, 320, 240, "video.mp4")

        presentation.save("video.pptx", slides.export.SaveFormat.PPTX)
```

## **Videókeret elérése**

Szerezze meg az első, a diára hozzáadott videókeretet.

```py
def access_video():
    with slides.Presentation("video.pptx") as presentation:
        slide = presentation.slides[0]

        # Az első videókeret elérése a dián.
        first_video = next(shape for shape in slide.shapes if isinstance(shape, slides.VideoFrame))
```

## **Videókeret eltávolítása**

Törölje a videókeretet a diáról.

```py
def remove_video():
    with slides.Presentation("video.pptx") as presentation:
        slide = presentation.slides[0]

        # Feltételezve, hogy az első alakzat egy videókeret.
        video_frame = slide.shapes[0]

        # A videókeret eltávolítása.
        slide.shapes.remove(video_frame)

        presentation.save("video_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Videó lejátszásának beállítása**

Állítsa be a videót, hogy automatikusan lejátszódjon, amikor a dia megjelenik.

```py
def set_video_playback():
    with slides.Presentation("video.pptx") as presentation:
        slide = presentation.slides[0]

        # Feltételezve, hogy az első alakzat egy videókeret.
        video_frame = slide.shapes[0]

        # A videó automatikus lejátszásának beállítása.
        video_frame.play_mode = slides.VideoPlayModePreset.AUTO

        presentation.save("video_playback.pptx", slides.export.SaveFormat.PPTX)
```