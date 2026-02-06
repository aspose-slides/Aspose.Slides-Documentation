---
title: Vidéo
type: docs
weight: 80
url: /fr/python-net/examples/elements/video/
keywords:
- vidéo
- cadre vidéo
- ajouter vidéo
- accéder vidéo
- supprimer vidéo
- lecture vidéo
- exemples de code
- PowerPoint
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Travailler avec la vidéo en Python à l'aide d'Aspose.Slides : insérer, remplacer, couper, définir les images d'affiche et les options de lecture, et exporter les présentations au format PPT, PPTX et ODP."
---
Montre comment intégrer des cadres vidéo et définir les options de lecture en utilisant **Aspose.Slides for Python via .NET**.

## **Ajouter un cadre vidéo**

Insérez un cadre vidéo vide sur une diapositive.

```py
def add_video():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Ajouter un cadre vidéo.
        video_frame = slide.shapes.add_video_frame(50, 50, 320, 240, "video.mp4")

        presentation.save("video.pptx", slides.export.SaveFormat.PPTX)
```

## **Accéder à un cadre vidéo**

Récupérez le premier cadre vidéo ajouté à une diapositive.

```py
def access_video():
    with slides.Presentation("video.pptx") as presentation:
        slide = presentation.slides[0]

        # Accéder au premier cadre vidéo sur la diapositive.
        first_video = next(shape for shape in slide.shapes if isinstance(shape, slides.VideoFrame))
```

## **Supprimer un cadre vidéo**

Supprimez un cadre vidéo de la diapositive.

```py
def remove_video():
    with slides.Presentation("video.pptx") as presentation:
        slide = presentation.slides[0]

        # En supposant que la première forme est un cadre vidéo.
        video_frame = slide.shapes[0]

        # Supprimer le cadre vidéo.
        slide.shapes.remove(video_frame)

        presentation.save("video_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Définir la lecture vidéo**

Configurez la vidéo pour qu'elle se lise automatiquement lorsque la diapositive est affichée.

```py
def set_video_playback():
    with slides.Presentation("video.pptx") as presentation:
        slide = presentation.slides[0]

        # En supposant que la première forme est un cadre vidéo.
        video_frame = slide.shapes[0]

        # Configurer la vidéo pour qu'elle se lise automatiquement.
        video_frame.play_mode = slides.VideoPlayModePreset.AUTO

        presentation.save("video_playback.pptx", slides.export.SaveFormat.PPTX)
```