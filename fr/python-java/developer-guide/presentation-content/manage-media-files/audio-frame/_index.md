---
title: "Gérer les cadres audio dans les présentations avec Python"
linktitle: "Cadre audio"
type: docs
weight: 10
url: /fr/python-java/audio-frame/
keywords:
- audio
- cadre audio
- miniature
- ajouter audio
- propriétés audio
- options audio
- extraire audio
- Python
- Aspose.Slides
description: "Intégrez de l'audio dans les diapositives, changez l'icône audio, configurez la lecture, gérez les sous-titres WebVTT et extrayez les sons de transition des diapositives avec Aspose.Slides for Python via Java."
---
## **Aperçu**

Un cadre audio vous permet de lire un son sur une diapositive. Avec Aspose.Slides for Python via Java, vous pouvez intégrer un extrait audio, choisir l'image qui le représente, ajuster la lecture et ajouter des sous‑titres. Vous pouvez également récupérer un son attribué à une transition de diapositive.

## **Créer des cadres audio**

Ajoutez les octets de `audio.wav` à la collection audio de la présentation, puis utilisez [addAudioFrameEmbedded](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addAudioFrameEmbedded) pour intégrer un extrait audio local sur la première diapositive. Les deux premières coordonnées positionnent le cadre sur la diapositive, et les deux valeurs suivantes définissent sa largeur et sa hauteur, le tout en points. Cet exemple appelle [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setPlayMode) pour démarrer automatiquement l’extrait et appelle [setVolume](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setVolume) pour choisir le préréglage fort.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioPlayModePreset, AudioVolumeMode, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    audio_data = Path("audio.wav").read_bytes()
    java_audio_data = jpype.JArray(jpype.JByte)(audio_data)
    audio = presentation.getAudios().addAudio(java_audio_data)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(50, 150, 100, 100, audio)

    audio_frame.setPlayMode(AudioPlayModePreset.Auto)
    audio_frame.setVolume(AudioVolumeMode.Loud)

    presentation.save("AudioFrameEmbed_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Modifier la miniature du cadre audio**

Par défaut, un cadre audio affiche une icône de haut‑parleur. Pour afficher une miniature personnalisée, ajoutez une image à la présentation avec [addImage](https://reference.aspose.com/slides/python-java/aspose.slides/imagecollection/#addImage) et affectez‑la au cadre avec [setImage](https://reference.aspose.com/slides/python-java/aspose.slides/picture/#setImage). L’exemple utilise un JPEG comme miniature pour un extrait audio intégré.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    audio_data = Path("audio.wav").read_bytes()
    java_audio_data = jpype.JArray(jpype.JByte)(audio_data)
    audio = presentation.getAudios().addAudio(java_audio_data)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(150, 100, 50, 50, audio)

    image = Images.fromFile("eagle.jpeg")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    audio_frame.getPictureFormat().getPicture().setImage(picture)

    presentation.save("example_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Modifier les options de lecture audio**

Les contrôles **Audio Options** de PowerPoint déterminent quand un extrait commence, quel volume il a et comment il se comporte pendant le diaporama.

![PowerPoint Audio Options controls for an audio frame](audio_frame_0.png)

| Contrôle PowerPoint | Méthode Aspose.Slides for Python via Java |
| --- | --- |
| Démarrer | [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setPlayMode) |
| Préréglage de volume | [setVolume](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setVolume) |
| Lire sur plusieurs diapositives | [setPlayAcrossSlides](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setPlayAcrossSlides) |
| Boucler jusqu'à l'arrêt | [setPlayLoopMode](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setPlayLoopMode) |
| Masquer pendant le diaporama | [setHideAtShowing](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setHideAtShowing) |
| Rembobiner après la lecture | [setRewindAudio](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setRewindAudio) |
| Fondu entrant | [setFadeInDuration](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setFadeInDuration) |
| Fondu sortant | [setFadeOutDuration](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setFadeOutDuration) |
| Rogner le temps de début de l’audio | [setTrimFromStart](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setTrimFromStart) |
| Rogner le temps de fin de l’audio | [setTrimFromEnd](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setTrimFromEnd) |
| Curseur de volume | [setVolumeValue](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setVolumeValue) |

L’exemple trouve le premier cadre audio sur la première diapositive, appelle [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setPlayMode) pour démarrer la lecture au clic, et sélectionne le préréglage de volume bas. L’extrait continue sur plusieurs diapositives avec la boucle désactivée. L’icône reste masquée pendant le diaporama, et l’extrait est rembobiné après la lecture.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioFrame, AudioPlayModePreset, AudioVolumeMode, Presentation, SaveFormat

presentation = Presentation("AudioFrameEmbed_out.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    audio_frame = next((shape for shape in slide.getShapes() if isinstance(shape, AudioFrame)), None)
    if audio_frame is not None:
        # Jouer au clic à faible volume, sur plusieurs diapositives, sans boucle.
        audio_frame.setPlayMode(AudioPlayModePreset.OnClick)
        audio_frame.setVolume(AudioVolumeMode.Low)
        audio_frame.setPlayAcrossSlides(True)
        audio_frame.setPlayLoopMode(False)
        # Masquer le cadre pendant le diaporama et rembobiner après la lecture.
        audio_frame.setHideAtShowing(True)
        audio_frame.setRewindAudio(True)

        presentation.save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx)
    else:
        print("The first slide has no audio frame.")
finally:
    presentation.dispose()
```

Pour un extrait de plus de 3,5 secondes, cet exemple saute les 1,5 premiers secondes et les 2 dernières secondes. [setTrimFromEnd](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setTrimFromEnd) indique la durée à omettre à la fin de l’extrait. Pour obtenir le temps de fin affiché dans PowerPoint, soustrayez ce décalage de la durée totale de l’extrait. L’extrait rogné fait un fondu entrant de 200 millisecondes et un fondu sortant de 500 millisecondes. Les quatre méthodes utilisent des valeurs en millisecondes.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    audio_data = Path("audio.wav").read_bytes()
    java_audio_data = jpype.JArray(jpype.JByte)(audio_data)
    audio = presentation.getAudios().addAudio(java_audio_data)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio)

    # Couper 1,5 seconde du début et 2 secondes de la fin.
    audio_frame.setTrimFromStart(1500.0)
    audio_frame.setTrimFromEnd(2000.0)
    # Définir le fondu entrant à 200 ms et le fondu sortant à 500 ms.
    audio_frame.setFadeInDuration(200.0)
    audio_frame.setFadeOutDuration(500.0)

    presentation.save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Pour définir le volume de lecture à un pourcentage précis, utilisez [setVolumeValue](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setVolumeValue). Cet exemple règle le premier cadre audio sur la première diapositive à 85 %.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioFrame, Presentation, SaveFormat

presentation = Presentation("AudioFrameEmbed_out.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    audio_frame = next((shape for shape in slide.getShapes() if isinstance(shape, AudioFrame)), None)
    if audio_frame is not None:
        audio_frame.setVolumeValue(85.0)
        presentation.save("AudioFrameValue_out.pptx", SaveFormat.Pptx)
    else:
        print("The first slide has no audio frame.")
finally:
    presentation.dispose()
```

## **Gérer les sous‑titres audio**

Chaque cadre audio offre un accès à ses pistes de sous‑titres via [getCaptionTracks](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#getCaptionTracks). Utilisez la collection pour joindre des sous‑titres WebVTT à l’extrait, exporter les pistes existantes ou les supprimer.

### **Ajouter des sous‑titres audio**

L’exemple intègre un extrait audio sur la première diapositive et utilise [add](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#add) pour attacher une piste WebVTT locale. Le premier argument fournit le libellé de la piste, et le second identifie le fichier contenant les sous‑titres synchronisés.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    audio_data = Path("audio.wav").read_bytes()
    java_audio_data = jpype.JArray(jpype.JByte)(audio_data)
    audio = presentation.getAudios().addAudio(java_audio_data)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(10, 10, 50, 50, audio)

    # Ajouter une nouvelle piste de sous-titres à partir d'un fichier WebVTT.
    audio_frame.getCaptionTracks().add("English", "track.vtt")

    presentation.save("audio_with_captions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Extraire les sous‑titres audio**

Cet exemple exporte chaque piste de sous‑titres attachée à un cadre audio sur la première diapositive. Il écrit les octets retournés par [getBinaryData](https://reference.aspose.com/slides/python-java/aspose.slides/captions/#getBinaryData) dans un fichier WebVTT et utilise l’identifiant retourné par [getCaptionId](https://reference.aspose.com/slides/python-java/aspose.slides/captions/#getCaptionId) comme nom de fichier afin que chaque piste possède une sortie distincte.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioFrame, Presentation

presentation = Presentation("audio_with_captions.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        if isinstance(shape, AudioFrame):
            for caption_track in shape.getCaptionTracks():
                # Enregistrer la piste de sous-titres en tant que fichier .vtt.
                file_path = Path(f"{caption_track.getCaptionId()}.vtt")
                caption_data = bytes(caption_track.getBinaryData())
                file_path.write_bytes(caption_data)
finally:
    presentation.dispose()
```

### **Supprimer les sous‑titres audio**

Utilisez [remove](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#remove) ou [removeAt](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#removeAt) pour supprimer une piste individuelle. L’exemple utilise [clear](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#clear) pour retirer tous les sous‑titres du premier cadre audio sur la première diapositive tout en conservant l’extrait.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioFrame, Presentation, SaveFormat

presentation = Presentation("audio_with_captions.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    audio_frame = next((shape for shape in slide.getShapes() if isinstance(shape, AudioFrame)), None)
    if audio_frame is not None:
        audio_frame.getCaptionTracks().clear()
        presentation.save("audio_without_captions.pptx", SaveFormat.Pptx)
    else:
        print("The first slide has no audio frame.")
finally:
    presentation.dispose()
```

### **Trouver une ligne dans les sous‑titres audio**

Pour trouver une ligne dans les sous‑titres audio sur la première diapositive, recherchez le texte retourné par [getDataAsString](https://reference.aspose.com/slides/python-java/aspose.slides/captions/#getDataAsString) en mémoire. Dans un cue WebVTT en texte brut, la ligne de timing contient `-->`, les lignes de sous‑titres la suivent, et une ligne vide termine le cue. Cet exemple affiche le libellé de la piste et chaque ligne de sous‑titre contenant «café».

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioFrame, Presentation

presentation = Presentation("audio_with_captions.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        if not isinstance(shape, AudioFrame):
            continue
        for track in shape.getCaptionTracks():
            in_cue = False
            captions = str(track.getDataAsString())
            for line in captions.splitlines():
                if not line:
                    in_cue = False
                elif "-->" in line:
                    in_cue = True
                elif in_cue and "café" in line.casefold():
                    print(f"{track.getLabel()}: {line}")
finally:
    presentation.dispose()
```

## **Extraire l’audio**

Une transition de diapositive peut avoir son propre son. Pour le récupérer, appelez [getSound](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getSound) sur la transition de la diapositive. L’exemple accède aux octets retournés par [getBinaryData](https://reference.aspose.com/slides/python-java/aspose.slides/audio/#getBinaryData) et affiche le nombre d’octets. Si la première diapositive n’a pas de son de transition, il affiche un message à la place.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("AudioSlide.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    
    transition = slide.getSlideShowTransition()
    sound = transition.getSound()
    if sound is not None:
        audio_data = sound.getBinaryData()
        print(f"Transition sound: {len(audio_data)} bytes.")
    else:
        print("The slide transition has no sound.")
finally:
    presentation.dispose()
```

## **FAQ**

**Puis-je réutiliser le même extrait audio sur plusieurs diapositives sans le dupliquer ?**

Oui. Ajoutez l’extrait une fois à la [audio collection](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getAudios) de la présentation et transmettez le même objet audio à [addAudioFrameEmbedded](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addAudioFrameEmbedded) pour chaque diapositive.

**Puis-je remplacer le son d’un cadre audio existant ?**

Oui. Pour un son lié, utilisez [setLinkPathLong](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setLinkPathLong) pour indiquer le fichier de remplacement. Pour un son intégré, choisissez un autre extrait dans la collection audio de la présentation avec [setEmbeddedAudio](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setEmbeddedAudio). Les deux approches conservent le cadre existant.

**Le rognage modifie-t-il les données audio stockées dans la présentation ?**

Non. [setTrimFromStart](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setTrimFromStart) et [setTrimFromEnd](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setTrimFromEnd) définissent les limites de lecture. Vous pouvez toujours récupérer l’extrait complet avec [getEmbeddedAudio](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#getEmbeddedAudio).