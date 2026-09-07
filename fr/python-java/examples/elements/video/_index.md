---
title: Vidéo
type: docs
weight: 80
url: /fr/python-java/examples/elements/video/
keywords:
- exemple de code
- vidéo
- cadre vidéo
- ajouter une vidéo
- accéder à la vidéo
- supprimer une vidéo
- lecture vidéo
- PowerPoint
- OpenDocument
- présentation
- Python
- Java
- Aspose.Slides
description: "Utilisez Aspose.Slides for Python via Java pour ajouter, accéder, supprimer et configurer des cadres vidéo dans les présentations PowerPoint et OpenDocument."
---
Cet article montre comment ajouter des cadres vidéo et définir les options de lecture à l'aide de **Aspose.Slides for Python via Java**.

Installez le paquet comme décrit dans [Installation](/slides/fr/python-java/installation/). Chaque exemple importe `asposeslides` avant de démarrer la JVM, puis importe l'API après le démarrage de la JVM.

## **Ajouter un cadre vidéo**

Insérez un cadre vidéo qui fait référence à un fichier vidéo externe.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Ajouter un cadre vidéo lié à un fichier vidéo.
    video_frame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4")
finally:
    presentation.dispose()
```

## **Accéder à un cadre vidéo**

Récupérez le premier cadre vidéo ajouté à une diapositive.

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

    # Accéder au premier cadre vidéo sur la diapositive.
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

## **Supprimer un cadre vidéo**

Supprimez un cadre vidéo de la diapositive.

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

    # Supprimer le cadre vidéo.
    slide.getShapes().remove(video_frame)
finally:
    presentation.dispose()
```

## **Définir la lecture vidéo**

Configurez la vidéo pour qu'elle se lise automatiquement lorsque la diapositive est affichée.

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

    # Configurer la vidéo pour qu'elle se lise automatiquement.
    video_frame.setPlayMode(VideoPlayModePreset.Auto)
finally:
    presentation.dispose()
```