---
title: Audio
type: docs
weight: 70
url: /fr/python-net/examples/elements/audio/
keywords:
- audio
- cadre audio
- ajouter audio
- accéder à l'audio
- supprimer audio
- lecture audio
- exemples de code
- PowerPoint
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Travaillez avec l'audio en Python à l'aide d'Aspose.Slides : ajoutez, remplacez, extrayez et coupez les sons, définissez le volume et la lecture pour les diapositives et les formes dans PowerPoint et OpenDocument."
---
Illustre comment intégrer des cadres audio et contrôler la lecture avec **Aspose.Slides for Python via .NET**. Les exemples suivants montrent les opérations audio de base.

## **Ajouter un cadre audio**

L'exemple de code ci‑dessous ajoute un cadre audio sur une diapositive de présentation.

```py
def add_audio():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        with open("audio.wav", "rb") as audio_stream:
            audio_frame = slide.shapes.add_audio_frame_embedded(50, 50, 100, 100, audio_stream)

        presentation.save("audio.pptx", slides.export.SaveFormat.PPTX)
```

## **Accéder à un cadre audio**

Ce code récupère le premier cadre audio de la diapositive.

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

## **Supprimer un cadre audio**

Supprimez un cadre audio ajouté précédemment.

```py
def remove_audio():
    with slides.Presentation("audio.pptx") as presentation:
        slide = presentation.slides[0]

        # Supposons que la première forme est un AudioFrame.
        audio_frame = slide.shapes[0]

        # Supprimer le cadre audio.
        slide.shapes.remove(audio_frame)

        presentation.save("audio_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Configurer la lecture audio**

Configurez le cadre audio pour qu’il se lise automatiquement lorsque la diapositive apparaît.

```py
def set_audio_playback():
    with slides.Presentation("audio.pptx") as presentation:
        slide = presentation.slides[0]

        # Supposons que la première forme est un AudioFrame.
        audio_frame = slide.shapes[0]

        # Lire automatiquement lorsque la diapositive apparaît.
        audio_frame.play_mode = slides.AudioPlayModePreset.AUTO

        presentation.save("audio_playback.pptx", slides.export.SaveFormat.PPTX)
```