---
title: Zvuk
type: docs
weight: 70
url: /cs/python-net/examples/elements/audio/
keywords:
- zvuk
- audio rámeček
- přidat audio
- přístup k audio
- odstranit audio
- přehrávání audio
- příklady kódu
- PowerPoint
- OpenDocument
- prezentace
- Python
- Aspose.Slides
description: "Práce se zvukem v Pythonu pomocí Aspose.Slides: přidávat, nahrazovat, extrahovat a ořezávat zvuky, nastavit hlasitost a přehrávání pro snímky a tvary v PowerPointu a OpenDocumentu."
---
Ukazuje, jak vložit audio rámečky a řídit přehrávání pomocí **Aspose.Slides for Python via .NET**. Následující příklady ukazují základní operace se zvukem.

## **Přidání audio rámečku**

Níže uvedený příklad kódu přidá audio rámeček do snímku prezentace.

```py
def add_audio():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        with open("audio.wav", "rb") as audio_stream:
            audio_frame = slide.shapes.add_audio_frame_embedded(50, 50, 100, 100, audio_stream)

        presentation.save("audio.pptx", slides.export.SaveFormat.PPTX)
```

## **Přístup k audio rámečku**

Tento kód načte první audio rámeček ze snímku.

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

## **Odstranění audio rámečku**

Odstraňte dříve přidaný audio rámeček.

```py
def remove_audio():
    with slides.Presentation("audio.pptx") as presentation:
        slide = presentation.slides[0]

        # Předpokládáme, že první tvar je AudioFrame.
        audio_frame = slide.shapes[0]

        # Odstraňte audio frame.
        slide.shapes.remove(audio_frame)

        presentation.save("audio_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Nastavení přehrávání audia**

Nakonfigurujte audio rámeček tak, aby se přehrával automaticky, když se snímek zobrazí.

```py
def set_audio_playback():
    with slides.Presentation("audio.pptx") as presentation:
        slide = presentation.slides[0]

        # Předpokládáme, že první tvar je AudioFrame.
        audio_frame = slide.shapes[0]

        # Přehrát automaticky, když se snímek objeví.
        audio_frame.play_mode = slides.AudioPlayModePreset.AUTO

        presentation.save("audio_playback.pptx", slides.export.SaveFormat.PPTX)
```