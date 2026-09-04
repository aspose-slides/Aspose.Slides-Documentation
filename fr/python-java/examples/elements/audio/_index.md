---
title: Audio
type: docs
weight: 70
url: /fr/python-java/examples/elements/audio/
keywords:
- exemple de code
- audio
- cadre audio
- ajouter de l'audio
- accéder à l'audio
- supprimer l'audio
- lecture audio
- PowerPoint
- OpenDocument
- présentation
- Python
- Java
- Aspose.Slides
description: "Utilisez Aspose.Slides for Python via Java pour ajouter, accéder, supprimer et configurer des cadres audio dans les présentations PowerPoint et OpenDocument."
---
Cet article montre comment intégrer des cadres audio et contrôler la lecture à l'aide de **Aspose.Slides for Python via Java**. Les exemples suivants illustrent les opérations audio de base.

Installez le package comme décrit dans [Installation](/slides/fr/python-java/installation/). Chaque exemple importe `asposeslides` avant de démarrer la JVM, puis importe l'API après le démarrage de la JVM.

## **Ajouter un cadre audio**

Insérez un cadre audio vide qui pourra ultérieurement contenir des données sonores intégrées.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from java.io import ByteArrayInputStream
from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    audio_data = jpype.JArray(jpype.JByte)(0)
    audio_stream = ByteArrayInputStream(audio_data)

    # Créez un cadre audio vide (l'audio sera intégré ultérieurement).
    audio_frame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio_stream)
finally:
    presentation.dispose()
```

## **Accéder à un cadre audio**

Ce code récupère le premier cadre audio d'une diapositive.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from java.io import ByteArrayInputStream
from asposeslides.api import AudioFrame, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    audio_data = jpype.JArray(jpype.JByte)(0)
    audio_stream = ByteArrayInputStream(audio_data)
    slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio_stream)

    # Accéder au premier cadre audio de la diapositive.
    first_audio = None
    for shape in slide.getShapes():
        if isinstance(shape, AudioFrame):
            first_audio = shape
            break

    if first_audio is None:
        print("The slide contains no audio frames.")
finally:
    presentation.dispose()
```

## **Supprimer un cadre audio**

Supprimez un cadre audio ajouté précédemment.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from java.io import ByteArrayInputStream
from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    audio_data = jpype.JArray(jpype.JByte)(0)
    audio_stream = ByteArrayInputStream(audio_data)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio_stream)

    # Supprimer le cadre audio.
    slide.getShapes().remove(audio_frame)
finally:
    presentation.dispose()
```

## **Définir la lecture audio**

Configurez le cadre audio pour qu'il se lise automatiquement lorsque la diapositive apparaît.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from java.io import ByteArrayInputStream
from asposeslides.api import AudioPlayModePreset, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    audio_data = jpype.JArray(jpype.JByte)(0)
    audio_stream = ByteArrayInputStream(audio_data)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio_stream)

    # Lire automatiquement lorsque la diapositive apparaît.
    audio_frame.setPlayMode(AudioPlayModePreset.Auto)
finally:
    presentation.dispose()
```