---
title: Gérer l'audio dans les présentations avec Python
linktitle: Cadre audio
type: docs
weight: 10
url: /fr/python-java/audio-frame/
keywords:
- audio
- cadre audio
- vignette
- ajouter de l'audio
- propriétés audio
- options audio
- extraire l'audio
- Python
- Aspose.Slides
description: "Créer et contrôler des cadres audio dans Aspose.Slides for Python via Java — exemples de code pour intégrer, rogner, boucler et configurer la lecture dans les présentations PPT, PPTX et ODP."
---
## **Vue d'ensemble**

Cet article explique comment travailler avec les cadres audio dans Aspose.Slides. Il montre comment ajouter de l'audio intégré aux diapositives, personnaliser la miniature du cadre audio, configurer les options de lecture telles que le volume, la boucle, le masquage, le découpage et les durées d'estompage, et extraire l'audio utilisé dans les transitions du diaporama.

## **Créer des cadres audio**

Aspose.Slides for Python via Java vous permet d'ajouter des fichiers audio aux diapositives. Les fichiers audio sont intégrés aux diapositives sous forme de cadres audio. 

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/) .
2. Obtenez une référence à une diapositive par son index.
3. Lisez le fichier audio que vous souhaitez intégrer dans la diapositive.
4. Ajoutez le cadre audio intégré (contenant le fichier audio) à la diapositive.
5. Utilisez [setPlayMode](https://reference.aspose.com/slides/fr/python-java/aspose.slides/audioframe/#setPlayMode) et [setVolume](https://reference.aspose.com/slides/fr/python-java/aspose.slides/audioframe/#setVolume) exposés par l'objet [AudioFrame](https://reference.aspose.com/slides/fr/python-java/aspose.slides/audioframe/) .
6. Enregistrez la présentation modifiée.

Ce code Python vous montre comment ajouter un cadre audio intégré à une diapositive :

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

## **Modifier la vignette du cadre audio**

Lorsque vous ajoutez un fichier audio à une présentation, l'audio apparaît sous forme d'un cadre avec une image par défaut standard (voir l'image dans la section ci‑dessous). Vous pouvez changer l'image d'aperçu du cadre audio par une image de votre choix.

Ce code Python vous montre comment changer la vignette ou l'image d'aperçu d'un cadre audio :

```python
from pathlib import Path

import jpime
import asposeslides

if not jpime.isJVMStarted():
    jpime.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    audio_data = Path("sample2.mp3").read_bytes()
    java_audio_data = jpime.JArray(jpime.JByte)(audio_data)
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

Aspose.Slides for Python via Java vous permet de modifier les options qui contrôlent la lecture audio ou ses propriétés. Par exemple, vous pouvez régler le volume audio, définir l'audio en boucle ou même masquer l'icône audio.

Le **Audio Options** pane in Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

Options audio de PowerPoint qui correspondent aux propriétés Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/fr/python-java/aspose.slides/audioframe/) :

- **Démarrer** (liste déroulante) correspond à la méthode [setPlayMode](https://reference.aspose.com/slides/fr/python-java/aspose.slides/audioframe/#setPlayMode)
- **Volume** correspond à la méthode [setVolume](https://reference.aspose.com/slides/fr/python-java/aspose.slides/audioframe/#setVolume)
- **Lire sur plusieurs diapositives** correspond à la méthode [setPlayAcrossSlides](https://reference.aspose.com/slides/fr/python-java/aspose.slides/audioframe/#setPlayAcrossSlides)
- **Boucler jusqu'à arrêt** correspond à la méthode [setPlayLoopMode](https://reference.aspose.com/slides/fr/python-java/aspose.slides/audioframe/#setPlayLoopMode)
- **Masquer pendant le diaporama** correspond à la méthode [setHideAtShowing](https://reference.aspose.com/slides/fr/python-java/aspose.slides/audioframe/#setHideAtShowing)
- **Rembobiner après lecture** correspond à la méthode [setRewindAudio](https://reference.aspose.com/slides/fr/python-java/aspose.slides/audioframe/#setRewindAudio)

Options d'édition de PowerPoint qui correspondent aux propriétés Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/fr/python-java/aspose.slides/audioframe/) :

- **Fondu d'entrée** correspond à la méthode [setFadeInDuration](https://reference.aspose.com/slides/fr/python-java/aspose.slides/audioframe/#setFadeInDuration) 
- **Fondu de sortie** correspond à la méthode [setFadeOutDuration](https://reference.aspose.com/slides/fr/python-java/aspose.slides/audioframe/#setFadeOutDuration) 
- **Temps de début du rognage audio** correspond à la méthode [setTrimFromStart](https://reference.aspose.com/slides/fr/python-java/aspose.slides/audioframe/#setTrimFromStart) 
- **Temps de fin du rognage audio** la valeur correspond à la durée audio moins la valeur définie par la méthode [setTrimFromEnd](https://reference.aspose.com/slides/fr/python-java/aspose.slides/audioframe/#setTrimFromEnd)

Le **contrôle du volume** de PowerPoint dans le panneau de contrôle audio correspond à la méthode [setVolumeValue](https://reference.aspose.com/slides/fr/python-java/aspose.slides/audioframe/#setVolumeValue). Il vous permet de modifier le volume audio en pourcentage.

Voici comment modifier les options de lecture audio :

1. [Créer](#create-audio-frames) ou obtenir le cadre audio.
2. Définissez de nouvelles valeurs pour les propriétés du cadre audio que vous souhaitez ajuster.
3. Enregistrez le fichier PowerPoint modifié.

Ce code Python démontre une opération dans laquelle les options audio sont ajustées :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioFrame, AudioPlayModePreset, AudioVolumeMode, Presentation, SaveFormat

presentation = Presentation("AudioFrameEmbed_out.pptx")
try:
    audio_frame = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(audio_frame, AudioFrame):
        # Lire au clic à faible volume, sur toutes les diapositives, sans boucle.
        audio_frame.setPlayMode(AudioPlayModePreset.OnClick)
        audio_frame.setVolume(AudioVolumeMode.Low)
        audio_frame.setPlayAcrossSlides(True)
        audio_frame.setPlayLoopMode(False)
        # Masquer le cadre pendant le diaporama et rembobiner après la lecture.
        audio_frame.setHideAtShowing(True)
        audio_frame.setRewindAudio(True)
        presentation.save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx)
    else:
        print("The shape is not an audio frame.")
finally:
    presentation.dispose()
```

Ce code Python montre comment ajouter un nouveau cadre audio avec audio intégré, le rogner et définir les durées d'estompage :

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
    audio_data = Path("sampleaudio.mp3").read_bytes()
    java_audio_data = jpype.JArray(jpype.JByte)(audio_data)
    audio = presentation.getAudios().addAudio(java_audio_data)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio)

    # Couper 1.5 secondes du début et 2 secondes de la fin.
    audio_frame.setTrimFromStart(1500.0)
    audio_frame.setTrimFromEnd(2000.0)
    # Définir le fondu d'entrée à 200 ms et le fondu de sortie à 500 ms.
    audio_frame.setFadeInDuration(200.0)
    audio_frame.setFadeOutDuration(500.0)
    presentation.save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

L'exemple de code suivant montre comment récupérer un cadre audio avec audio intégré et régler son volume à 85 % :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioFrame, Presentation, SaveFormat

presentation = Presentation("AudioFrameEmbed_out.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    audio_frame = slide.getShapes().get_Item(0)
    if isinstance(audio_frame, AudioFrame):
        audio_frame.setVolumeValue(85.0)
        presentation.save("AudioFrameValue_out.pptx", SaveFormat.Pptx)
    else:
        print("The shape is not an audio frame.")
finally:
    presentation.dispose()
```

## **Gérer les légendes audio**

Aspose.Slides vous permet d'ajouter des sous‑titres fermés à un cadre audio via la méthode [getCaptionTracks](https://reference.aspose.com/slides/fr/python-java/aspose.slides/audioframe/#getCaptionTracks). Cette méthode renvoie une [CaptionsCollection](https://reference.aspose.com/slides/fr/python-java/aspose.slides/captionscollection/), qui vous permet d'ajouter des pistes de sous‑titres WebVTT, d'itérer les pistes existantes et de les supprimer si nécessaire.

**Ajouter des légendes audio**

Utilisez la méthode [getCaptionTracks](https://reference.aspose.com/slides/fr/python-java/aspose.slides/audioframe/#getCaptionTracks) pour attacher une ou plusieurs pistes de sous‑titres à un cadre audio. Dans l'exemple suivant, un fichier audio est ajouté à une diapositive, puis une nouvelle piste de sous‑titres est chargée depuis un fichier `.vtt`.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    audio_data = Path("audio.mp3").read_bytes()
    java_audio_data = jpype.JArray(jpype.JByte)(audio_data)
    audio = presentation.getAudios().addAudio(java_audio_data)
    slide = presentation.getSlides().get_Item(0)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(10, 10, 50, 50, audio)

    # Ajouter une nouvelle piste de sous‑titres à partir d'un fichier WebVTT.
    audio_frame.getCaptionTracks().add("New track", "track.vtt")
    presentation.save("audio_with_captions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

**Extraire les légendes audio**

Vous pouvez parcourir les pistes de sous‑titres associées à un cadre audio et les enregistrer sous forme de fichiers `.vtt`. Chaque piste expose ses données binaires et son identifiant unique, qui peuvent être utilisés lors de l'exportation des sous‑titres.

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
                # Enregistrer la piste de sous‑titres sous forme de fichier .vtt.
                file_path = Path(str(caption_track.getCaptionId()) + ".vtt")
                caption_data = bytes(caption_track.getBinaryData())
                file_path.write_bytes(caption_data)
finally:
    presentation.dispose()
```

**Supprimer les légendes audio**

Pour supprimer les sous‑titres d'un cadre audio, utilisez les méthodes fournies par [CaptionsCollection](https://reference.aspose.com/slides/fr/python-java/aspose.slides/captionscollection/), telles que [clear](https://reference.aspose.com/slides/fr/python-java/aspose.slides/captionscollection/#clear), [remove](https://reference.aspose.com/slides/fr/python-java/aspose.slides/captionscollection/#remove) ou [removeAt](https://reference.aspose.com/slides/fr/python-java/aspose.slides/captionscollection/#removeAt). L'exemple suivant supprime toutes les pistes de sous‑titres d'un cadre audio.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioFrame, Presentation, SaveFormat

presentation = Presentation("audio_with_captions.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    audio_frame = slide.getShapes().get_Item(0)
    if isinstance(audio_frame, AudioFrame):
        audio_frame.getCaptionTracks().clear()
        presentation.save("audio_without_captions.pptx", SaveFormat.Pptx)
    else:
        print("The shape is not an audio frame.")
finally:
    presentation.dispose()
```

## **Extraire l'audio**

Aspose.Slides for Python via Java vous permet d'extraire le son utilisé dans les transitions du diaporama. Par exemple, vous pouvez extraire le son utilisé dans une diapositive spécifique.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/) et chargez la présentation contenant l'audio.
2. Obtenez une référence à la diapositive concernée par son index.
3. Accédez aux [transitions du diaporama](https://reference.aspose.com/slides/fr/python-java/aspose.slides/baseslide/#getSlideShowTransition) de la diapositive.
4. Extrayez le son sous forme de données binaires.

Ce code Python vous montre comment extraire l'audio utilisé dans une diapositive :

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
        print("Length:", len(audio_data))
    else:
        print("The slide transition has no sound.")
finally:
    presentation.dispose()
```

## **FAQ**

**Puis-je réutiliser le même fichier audio sur plusieurs diapositives sans gonfler la taille du fichier ?**

Oui. Ajoutez l'audio une fois à la [collection audio partagée](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/#getAudios) de la présentation et créez des cadres audio supplémentaires qui font référence à cet élément existant. Cela évite de dupliquer les données multimédia et maintient la taille de la présentation sous contrôle.

**Puis-je remplacer le son d'un cadre audio existant sans recréer la forme ?**

Oui. Pour un son lié, mettez à jour le [chemin du lien](https://reference.aspose.com/slides/fr/python-java/aspose.slides/audioframe/#setLinkPathLong) pour pointer vers le nouveau fichier. Pour un son intégré, échangez l'objet [embedded audio](https://reference.aspose.com/slides/fr/python-java/aspose.slides/audioframe/#setEmbeddedAudio) avec un autre provenant de la [collection audio](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/#getAudios) de la présentation. Le format du cadre et la plupart des paramètres de lecture restent intacts.

**Le rognage modifie-t-il les données audio sous‑jacentes stockées dans la présentation ?**

Non. Le rognage ajuste uniquement les limites de lecture. Les octets audio originaux restent intacts et accessibles via l'audio intégré ou la collection audio de la présentation.