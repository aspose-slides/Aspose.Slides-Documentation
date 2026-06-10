---
title: Hang
type: docs
weight: 70
url: /hu/python-net/examples/elements/audio/
keywords:
- hang
- hangkeret
- hang hozzáadása
- hang elérése
- hang eltávolítása
- hang lejátszása
- kódrészletek
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Aspose.Slides
description: "Aspose.Slides használatával Pythonban dolgozhat a hangokkal: hangok hozzáadása, cseréje, kinyerése és vágása, hangerő és lejátszás beállítása a diák és alakzatok számára PowerPointban és OpenDocumentban."
---
Bemutatja, hogyan ágyazhat be hangkereteket, és vezérelheti a lejátszást az **Aspose.Slides for Python via .NET** segítségével. A következő példák az alapvető hangműveleteket mutatják be.

## **Hangkeret hozzáadása**

Az alábbi kódrészlet egy hangkeretet ad a prezentációs diára.

```py
def add_audio():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        with open("audio.wav", "rb") as audio_stream:
            audio_frame = slide.shapes.add_audio_frame_embedded(50, 50, 100, 100, audio_stream)

        presentation.save("audio.pptx", slides.export.SaveFormat.PPTX)
```

## **Hangkeret elérése**

Ez a kód lekéri az első hangkeretet a diáról.

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

## **Hangkeret eltávolítása**

Töröl egy korábban hozzáadott hangkeretet.

```py
def remove_audio():
    with slides.Presentation("audio.pptx") as presentation:
        slide = presentation.slides[0]

        # Feltételezve, hogy az első alakzat egy AudioFrame.
        audio_frame = slide.shapes[0]

        # Eltávolítja a hangkeretet.
        slide.shapes.remove(audio_frame)

        presentation.save("audio_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Hanglejátszás beállítása**

Állítsa be a hangkeretet úgy, hogy automatikusan lejátszódjon, amikor a dia megjelenik.

```py
def set_audio_playback():
    with slides.Presentation("audio.pptx") as presentation:
        slide = presentation.slides[0]

        # Feltételezve, hogy az első alakzat egy AudioFrame.
        audio_frame = slide.shapes[0]

        # Automatikusan lejátszódik, amikor a dia megjelenik.
        audio_frame.play_mode = slides.AudioPlayModePreset.AUTO

        presentation.save("audio_playback.pptx", slides.export.SaveFormat.PPTX)
```