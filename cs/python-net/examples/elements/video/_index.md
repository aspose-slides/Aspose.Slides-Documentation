---
title: Video
type: docs
weight: 80
url: /cs/python-net/examples/elements/video/
keywords:
- video
- video rámec
- přidat video
- přístup k videu
- odstranit video
- přehrávání videa
- ukázky kódu
- PowerPoint
- OpenDocument
- prezentace
- Python
- Aspose.Slides
description: "Pracujte s videem v Pythonu pomocí Aspose.Slides: vkládejte, nahrazujte, ořezávejte, nastavujte plakátové rámce a možnosti přehrávání a exportujte prezentace pro PPT, PPTX a ODP."
---
Ukazuje, jak vložit video rámečky a nastavit možnosti přehrávání pomocí **Aspose.Slides for Python via .NET**.

## **Add a Video Frame**
Přidejte prázdný video rámeček na snímek.

```py
def add_video():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Přidejte video rámec.
        video_frame = slide.shapes.add_video_frame(50, 50, 320, 240, "video.mp4")

        presentation.save("video.pptx", slides.export.SaveFormat.PPTX)
```

## **Access a Video Frame**
Získejte první video rámeček přidaný do snímku.

```py
def access_video():
    with slides.Presentation("video.pptx") as presentation:
        slide = presentation.slides[0]

        # Přístup k prvnímu video rámci na snímku.
        first_video = next(shape for shape in slide.shapes if isinstance(shape, slides.VideoFrame))
```

## **Remove a Video Frame**
Odstraňte video rámeček ze snímku.

```py
def remove_video():
    with slides.Presentation("video.pptx") as presentation:
        slide = presentation.slides[0]

        # Předpokládáme, že první tvar je video rámec.
        video_frame = slide.shapes[0]

        # Odstraňte video rámec.
        slide.shapes.remove(video_frame)

        presentation.save("video_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Set Video Playback**
Nakonfigurujte video tak, aby se přehrávalo automaticky při zobrazení snímku.

```py
def set_video_playback():
    with slides.Presentation("video.pptx") as presentation:
        slide = presentation.slides[0]

        # Předpokládáme, že první tvar je video rámec.
        video_frame = slide.shapes[0]

        # Nastavte video tak, aby se přehrávalo automaticky.
        video_frame.play_mode = slides.VideoPlayModePreset.AUTO

        presentation.save("video_playback.pptx", slides.export.SaveFormat.PPTX)
```