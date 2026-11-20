---
title: Gérer les cadres vidéo dans les présentations avec Python
linktitle: Cadre vidéo
type: docs
weight: 10
url: /fr/python-java/video-frame/
keywords:
- ajouter une vidéo
- créer une vidéo
- intégrer une vidéo
- extraire une vidéo
- récupérer une vidéo
- cadre vidéo
- source Web
- PowerPoint
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Apprenez à ajouter et extraire programmatiquement des cadres vidéo dans les diapositives PowerPoint et OpenDocument en utilisant Aspose.Slides pour Python via Java. Guide pratique rapide."
---
## **Introduction**

Les vidéos peuvent aider à expliquer des idées et à capter l’attention du public. Aspose.Slides for Python via Java vous permet d’ajouter des cadres vidéo aux diapositives, d’ajuster les paramètres de lecture, de gérer les sous‑titres et d’extraire les données vidéo intégrées.

PowerPoint prend en charge les vidéos locales ainsi que les liens vers des vidéos en ligne, comme les vidéos YouTube.

Pour représenter les données vidéo et les cadres vidéo, Aspose.Slides fournit la classe [Video](https://reference.aspose.com/slides/python-java/aspose.slides/video/) , la classe [VideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/) et d’autres types pertinents.

## **Créer un cadre vidéo intégré**

Si le fichier vidéo que vous souhaitez ajouter à votre diapositive est stocké localement, vous pouvez créer un cadre vidéo pour intégrer la vidéo dans votre présentation.

Cet exemple intègre une vidéo locale sur la première diapositive d’une présentation existante et enregistre le résultat. Les coordonnées et les dimensions du cadre sont exprimées en points. Python lit les octets de la vidéo depuis le disque, et JPype les convertit en tableau d’octets Java avant que la vidéo ne soit ajoutée à la présentation.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    video_data = Path("video.mp4").read_bytes()
    java_video_data = jpype.JArray(jpype.JByte)(video_data)

    video = presentation.getVideos().addVideo(java_video_data)
    slide.getShapes().addVideoFrame(10, 10, 150, 250, video)

    presentation.save("embedded_video.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Vous pouvez également transmettre directement un chemin de vidéo locale à [addVideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addVideoFrame). Cet exemple intègre la vidéo sur la première diapositive d’une nouvelle présentation. La vidéo doit rester accessible jusqu’à ce que la présentation soit enregistrée.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getShapes().addVideoFrame(50, 150, 300, 150, "video.avi")

    presentation.save("video_from_path.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Créer un cadre vidéo avec une vidéo provenant d’une source Web**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) prend en charge les vidéos en ligne dans les présentations. Vous pouvez créer un cadre vidéo qui lie à une vidéo en ligne, comme une vidéo YouTube.

Cet exemple ajoute un lien vidéo YouTube et une miniature à la première diapositive. Remplacez l’identifiant vidéo pour utiliser une autre vidéo. La méthode [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayMode) demande la lecture automatique. Le téléchargement de la miniature et la lecture de la vidéo nécessitent un accès Internet. Le visualiseur de présentation doit également prendre en charge la lecture de vidéos en ligne.

```python
from urllib.request import urlopen

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, VideoPlayModePreset

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    video_id = "aqz-KE-bpKQ"
    video_url = "https://www.youtube.com/embed/" + video_id
    video_frame = slide.getShapes().addVideoFrame(10, 10, 427, 240, video_url)
    video_frame.setPlayMode(VideoPlayModePreset.Auto)

    thumbnail_url = "https://img.youtube.com/vi/" + video_id + "/hqdefault.jpg"
    with urlopen(thumbnail_url) as response:
        thumbnail_data = response.read()
    java_thumbnail_data = jpype.JArray(jpype.JByte)(thumbnail_data)
    thumbnail = presentation.getImages().addImage(java_thumbnail_data)
    video_frame.getPictureFormat().getPicture().setImage(thumbnail)

    presentation.save("online_video.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Lire une vidéo en mode plein écran**

Dans une présentation de formation, vous pouvez lire une démonstration logicielle en mode plein écran afin que le public voie les détails. Appelez [setFullScreenMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setFullScreenMode) avec `True` pour activer ce comportement pendant la lecture.

Cet exemple ouvre une présentation, trouve le premier [VideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/) sur la première diapositive et active la lecture en plein écran. La présentation d’entrée doit contenir au moins une diapositive avec un cadre vidéo existant sur la première diapositive.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, VideoFrame

presentation = Presentation("training.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        if isinstance(shape, VideoFrame):
            shape.setFullScreenMode(True)
            break

    presentation.save("full_screen_video.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

La lecture en plein écran contrôle la façon dont la vidéo est affichée. De façon indépendante, [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayMode) contrôle si elle démarre automatiquement ou au clic, et [setPlayLoopMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayLoopMode) contrôle si elle se répète. Pour choisir le comportement de démarrage, définissez le mode de lecture sur [VideoPlayModePreset.Auto or VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/python-java/aspose.slides/videoplaymodepreset/). L’exemple préserve les réglages existants de démarrage et de boucle.

## **Rembobiner une vidéo après la lecture**

Dans une présentation de formation, ramener une vidéo de démonstration au début la rend prête à être relancée par le présentateur. Appelez [setRewindVideo](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setRewindVideo) avec `True` pour ramener la vidéo au début après la fin de la lecture.

Cet exemple ouvre une présentation, trouve le premier [VideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/) sur la première diapositive et active le rembobinage. Il désactive le bouclage afin que la lecture puisse se terminer et définit la lecture pour qu’elle démarre au clic. La présentation d’entrée doit contenir au moins une diapositive avec un cadre vidéo existant sur la première diapositive.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, VideoFrame, VideoPlayModePreset

presentation = Presentation("training.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        if isinstance(shape, VideoFrame):
            shape.setRewindVideo(True)
            shape.setPlayLoopMode(False)
            shape.setPlayMode(VideoPlayModePreset.OnClick)
            break

    presentation.save("rewind_video.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Le rembobinage ramène la vidéo à son début sans la relancer. En revanche, appeler [setPlayLoopMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayLoopMode) avec `True` répète la lecture automatiquement. Gardez le bouclage désactivé lorsque vous souhaitez que la vidéo se termine et reste prête à être rejouée. [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayMode) contrôle indépendamment le démarrage automatique ou au clic ; cet exemple utilise [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/python-java/aspose.slides/videoplaymodepreset/) afin que le présentateur contrôle le moment du démarrage. Définissez le mode de lecture après le réglage de boucle, comme indiqué dans l’exemple. Le rembobinage fonctionne indépendamment de [setFullScreenMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setFullScreenMode).

## **Rogner un cadre vidéo**

Utilisez [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setTrimFromStart) et [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setTrimFromEnd) pour ignorer une partie du début ou de la fin d’une vidéo pendant la lecture. Les deux valeurs sont exprimées en millisecondes. Le rognage modifie les paramètres de lecture sans altérer les données vidéo intégrées.

**Définir les paramètres de rognage**

Cet exemple intègre une vidéo locale et ignore les 2,5 secondes initiales ainsi que la dernière seconde pendant la lecture. Utilisez une vidéo de plus de 3,5 secondes afin qu’un segment lisible reste.

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

    video_data = Path("video.mp4").read_bytes()
    java_video_data = jpype.JArray(jpype.JByte)(video_data)

    video = presentation.getVideos().addVideo(java_video_data)
    video_frame = slide.getShapes().addVideoFrame(50, 50, 640, 360, video)

    video_frame.setTrimFromStart(2500.0)
    video_frame.setTrimFromEnd(1000.0)

    presentation.save("video_with_trim.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

**Lire les paramètres de rognage**

Cet exemple affiche les valeurs de rognage du premier cadre vidéo sur la première diapositive en millisecondes. La présentation doit contenir au moins une diapositive. Si cette diapositive ne possède aucun cadre vidéo, rien n’est affiché. L’exemple précédent produit les valeurs 2500 et 1000.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, VideoFrame

presentation = Presentation("video_with_trim.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        if isinstance(shape, VideoFrame):
            trim_from_start = shape.getTrimFromStart()
            trim_from_end = shape.getTrimFromEnd()
            print(f"Trim from start: {trim_from_start} ms")
            print(f"Trim from end: {trim_from_end} ms")
            break
finally:
    presentation.dispose()
```

## **Gérer les sous‑titres vidéo**

Aspose.Slides vous permet de gérer les sous‑titres fermés pour les cadres vidéo dans les présentations PowerPoint. Les sous‑titres sont stockés au format WebVTT et sont accessibles via la méthode [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#getCaptionTracks).

### **Ajouter des sous‑titres à un cadre vidéo**

Cet exemple intègre une vidéo locale et ajoute une piste de sous‑titre WebVTT intitulée English. Les horodatages des sous‑titres doivent correspondre à la vidéo. La présentation enregistrée comprend à la fois la vidéo et ses sous‑titres.

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

    video_data = Path("video.mp4").read_bytes()
    java_video_data = jpype.JArray(jpype.JByte)(video_data)

    video = presentation.getVideos().addVideo(java_video_data)
    video_frame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video)

    # Ajouter une nouvelle piste de sous-titre à partir d'un fichier WebVTT.
    video_frame.getCaptionTracks().add("English", "track.vtt")

    presentation.save("video_with_captions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

La classe [CaptionsCollection](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/) offre également une surcharge permettant d’ajouter des sous‑titres depuis un flux.

### **Extraire les sous‑titres d’un cadre vidéo**

Cet exemple enregistre toutes les pistes de sous‑titres des cadres vidéo de la première diapositive sous forme de fichiers WebVTT distincts. Des numéros séquentiels maintiennent les fichiers de sortie distincts. La console indique le nombre de pistes extraites. La présentation doit contenir au moins une diapositive.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpime.isJVMStarted():
    jpime.startJVM()

from asposeslides.api import Presentation, VideoFrame

presentation = Presentation("video_with_captions.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    track_count = 0
    for shape in slide.getShapes():
        if isinstance(shape, VideoFrame):
            for caption_track in shape.getCaptionTracks():
                track_count += 1
                output_path = Path(f"captions_{track_count}.vtt")
                caption_data = bytes(caption_track.getBinaryData())
                output_path.write_bytes(caption_data)

    print(f"Caption tracks extracted: {track_count}")
finally:
    presentation.dispose()
```

Chaque objet [Captions](https://reference.aspose.com/slides/python-java/aspose.slides/captions/) expose l’identifiant du sous‑titre, le libellé, les données binaires et le texte du sous‑titre sous forme de chaîne UTF‑8.

### **Supprimer les sous‑titres d’un cadre vidéo**

Cet exemple supprime tous les sous‑titres du cadre vidéo à la première position de forme sur la première diapositive et enregistre le résultat. Il suppose que la diapositive et la forme existent et que la forme est un cadre vidéo.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, VideoFrame

presentation = Presentation("video_with_captions.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    video_frame = slide.getShapes().get_Item(0)
    if isinstance(video_frame, VideoFrame):
        # Supprimer toutes les pistes de sous-titres du cadre vidéo.
        video_frame.getCaptionTracks().clear()
        
        presentation.save("video_without_captions.pptx", SaveFormat.Pptx)
    else:
        print("The shape is not a video frame.")
finally:
    presentation.dispose()
```

Si vous devez supprimer uniquement une piste de sous‑titre, utilisez les méthodes [remove](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#remove) ou [removeAt](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#removeAt) au lieu de [clear](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#clear).

### **Rechercher des sous‑titres vidéo**

[Captions.getDataAsString](https://reference.aspose.com/slides/python-java/aspose.slides/captions/#getDataAsString) renvoie la piste WebVTT complète, incluant son en‑tête, ses lignes de timing et le texte du sous‑titre. Vous pouvez rechercher les sous‑titres en mémoire pour trouver une phrase et son horodatage. Par exemple, une piste anglaise sur la diapositive 2 pourrait contenir le texte suivant.

```text
WEBVTT Café tour

00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

Cet exemple ouvre `captioned_media.pptx` et utilise [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#getCaptionTracks) pour lire les pistes de chaque cadre vidéo de niveau supérieur sur chaque diapositive. Dans un cue texte brut, la ligne de timing contient `-->`, et une ligne vide termine le cue. Pour chaque sous‑titre contenant « café » quel que soit le cas des lettres, l’exemple affiche le numéro de la diapositive, le libellé de la piste, la ligne de timing originale et le sous‑titre complet.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, VideoFrame

presentation = Presentation("captioned_media.pptx")
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if not isinstance(shape, VideoFrame):
                continue
            for track in shape.getCaptionTracks():
                track_text = str(track.getDataAsString())
                lines = iter(track_text.splitlines())
                for timing in lines:
                    if "-->" not in timing:
                        continue
                    caption_lines = []
                    for line in lines:
                        if not line:
                            break
                        caption_lines.append(line)
                    caption = "\n".join(caption_lines)
                    if "café" in caption.casefold():
                        print(f"Slide {slide.getSlideNumber()} | {track.getLabel()} | {timing}")
                        print(caption)
finally:
    presentation.dispose()
```

La recherche de « café » produit une correspondance pour la piste d’exemple. La recherche exclut l’en‑tête de la piste et préserve le réglage de timing ainsi que les sauts de ligne dans la sortie.

```text
Slide 2 | English | 00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

## **Extraire la vidéo d’une diapositive**

Outre l’ajout de vidéos aux diapositives, Aspose.Slides permet d’extraire les vidéos intégrées dans les présentations.

Cet exemple extrait les vidéos intégrées de chaque diapositive dans des fichiers binaires numérotés distincts. Les vidéos liées sont ignorées car elles ne contiennent aucune donnée intégrée. La console affiche le type MIME de chaque vidéo et le nombre total. La sortie utilise l’extension générique `.bin` ; modifiez‑la pour correspondre au type de média rapporté si nécessaire.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, VideoFrame

presentation = Presentation("presentation_with_videos.pptx")
try:
    video_count = 0
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if isinstance(shape, VideoFrame):
                video = shape.getEmbeddedVideo()
                if video is None:
                    print("Skipped a linked video: no embedded data is available.")
                    continue

                video_count += 1
                output_path = Path(f"extracted_video_{video_count}.bin")
                video_data = bytes(video.getBinaryData())
                output_path.write_bytes(video_data)
                print(f"Video {video_count}: {video.getContentType()}")

    print(f"Embedded videos extracted: {video_count}")
finally:
    presentation.dispose()
```

## **FAQ**

**Quels paramètres de lecture vidéo peuvent être modifiés pour un cadre vidéo ?**

Vous pouvez contrôler le [mode de lecture](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayMode) (auto ou au clic) et le [bouclage](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayLoopMode). Ces options sont disponibles via les méthodes de l’objet [VideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/).

**L’ajout d’une vidéo affecte-t-il la taille du fichier PPTX ?**

Oui. Lorsque vous intégrez une vidéo locale, les données binaires sont incluses dans le document, ce qui augmente la taille de la présentation proportionnellement à la taille du fichier. Lorsque vous liez à une vidéo en ligne et ajoutez une miniature, la présentation stocke le lien et l’image de prévisualisation plutôt que les données vidéo, ce qui entraîne généralement une augmentation de taille moindre.

**Puis-je remplacer la vidéo d’un cadre vidéo existant sans modifier sa position et sa taille ?**

Oui. Vous pouvez remplacer le [contenu vidéo](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setEmbeddedVideo) à l’intérieur du cadre tout en conservant la géométrie de la forme ; c’est un scénario courant pour mettre à jour les médias dans une mise en page existante.

**Le type de contenu (MIME) d’une vidéo intégrée peut-il être déterminé ?**

Oui. Une vidéo intégrée possède un [type de contenu](https://reference.aspose.com/slides/python-java/aspose.slides/video/#getContentType) que vous pouvez lire et utiliser, par exemple lors de son enregistrement sur disque.