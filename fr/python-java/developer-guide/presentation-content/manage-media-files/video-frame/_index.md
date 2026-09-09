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
- source web
- PowerPoint
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Apprenez à ajouter et extraire programmaticalement des cadres vidéo dans les diapositives PowerPoint et OpenDocument en utilisant Aspose.Slides pour Python via Java. Guide pratique rapide."
---
## **Introduction**

Une vidéo bien placée dans une présentation peut rendre votre message plus percutant et augmenter le niveau d'engagement de votre public.

PowerPoint vous permet d'ajouter des vidéos à une diapositive d'une présentation de deux manières :

* Ajouter ou incorporer une vidéo locale (stockée sur votre ordinateur)
* Ajouter une vidéo en ligne (provenant d'une source Web telle que YouTube).

Pour vous permettre d'ajouter des vidéos (objets vidéo) à une présentation, Aspose.Slides fournit la classe [Video](https://reference.aspose.com/slides/fr/python-java/aspose.slides/video/), la classe [VideoFrame](https://reference.aspose.com/slides/fr/python-java/aspose.slides/videoframe/) et d'autres types pertinents.

## **Créer des cadres vidéo incorporés**

Si le fichier vidéo que vous souhaitez ajouter à votre diapositive est stocké localement, vous pouvez créer un cadre vidéo pour incorporer la vidéo dans votre présentation.

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/).
1. Obtenir une référence à une diapositive par son index.
1. Ajouter un objet [Video](https://reference.aspose.com/slides/fr/python-java/aspose.slides/video/) et transmettre les données du fichier vidéo pour incorporer la vidéo dans la présentation.
1. Ajouter un objet [VideoFrame](https://reference.aspose.com/slides/fr/python-java/aspose.slides/videoframe/) pour créer un cadre pour la vidéo.
1. Enregistrer la présentation modifiée.

Ce code Python vous montre comment ajouter une vidéo stockée localement à une présentation:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    video_data = Path("Wildlife.mp4").read_bytes()
    java_video_data = jpype.JArray(jpype.JByte)(video_data)
    video = presentation.getVideos().addVideo(java_video_data)
    presentation.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 150, 250, video)
    presentation.save("pres-with-video.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Alternativement, vous pouvez ajouter une vidéo en passant directement son chemin de fichier à la méthode [addVideoFrame](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shapecollection/#addVideoFrame):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    video_frame = slide.getShapes().addVideoFrame(50, 150, 300, 150, "video1.avi")
finally:
    presentation.dispose()
```

## **Créer des cadres vidéo à partir de sources Web**

Microsoft [PowerPoint 2013 et versions ultérieures](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) prend en charge les vidéos YouTube dans les présentations. Si la vidéo que vous souhaitez utiliser est disponible en ligne (par exemple sur YouTube), vous pouvez l’ajouter à votre présentation via son lien web.

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/).
1. Obtenir une référence à une diapositive par son index.
1. Ajouter un objet [VideoFrame](https://reference.aspose.com/slides/fr/python-java/aspose.slides/videoframe/) et transmettre le lien vers la vidéo.
1. Définir une vignette pour le cadre vidéo.
1. Enregistrer la présentation.

Ce code Python vous montre comment ajouter une vidéo provenant du web à une diapositive dans une présentation PowerPoint:

```python
from urllib.request import urlopen

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, VideoPlayModePreset

video_id = "Tj75Arhq5ho"
presentation = Presentation()
try:
    video_frame = presentation.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 427, 240, "https://www.youtube.com/embed/" + video_id)
    video_frame.setPlayMode(VideoPlayModePreset.Auto)

    # Charger la vignette.
    thumbnail_uri = "https://img.youtube.com/vi/" + video_id + "/hqdefault.jpg"
    try:
        with urlopen(thumbnail_uri) as response:
            thumbnail_data = response.read()
        java_thumbnail_data = jpype.JArray(jpype.JByte)(thumbnail_data)
        thumbnail = presentation.getImages().addImage(java_thumbnail_data)
        video_frame.getPictureFormat().getPicture().setImage(thumbnail)
    except OSError as error:
        print("Could not load the thumbnail:", error)

    presentation.save("out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Rogner un cadre vidéo**

Aspose.Slides vous permet de contrôler la partie d’une vidéo qui est lue en définissant les valeurs trim-from-start et trim-from-end via [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/fr/python-java/aspose.slides/videoframe/#setTrimFromStart) et [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/fr/python-java/aspose.slides/videoframe/#setTrimFromEnd). Les deux valeurs sont spécifiées en millisecondes et définissent le temps à ignorer au début et à la fin de la vidéo, respectivement. Ces paramètres modifient les réglages de lecture de la vidéo dans la présentation ; ils ne découpent pas et ne modifient pas les données binaires de la vidéo incorporée.

**Définir les paramètres de rognage**

Pour créer un cadre vidéo et définir ses paramètres de rognage :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/).
1. Ajouter un objet [Video](https://reference.aspose.com/slides/fr/python-java/aspose.slides/video/) à la présentation.
1. Ajouter un objet [VideoFrame](https://reference.aspose.com/slides/fr/python-java/aspose.slides/videoframe/) à une diapositive.
1. Définir les valeurs trim-from-start et trim-from-end via [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/fr/python-java/aspose.slides/videoframe/#setTrimFromStart) et [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/fr/python-java/aspose.slides/videoframe/#setTrimFromEnd).
1. Enregistrer la présentation modifiée.

L'exemple de code suivant saute les 2,5 premières secondes et la dernière seconde d’une vidéo incorporée lors de la lecture :

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    video_data = Path("video.mp4").read_bytes()
    java_video_data = jpype.JArray(jpype.JByte)(video_data)
    video = presentation.getVideos().addVideo(java_video_data)
    slide = presentation.getSlides().get_Item(0)
    video_frame = slide.getShapes().addVideoFrame(50, 50, 640, 360, video)

    video_frame.setTrimFromStart(2500.0)
    video_frame.setTrimFromEnd(1000.0)
    presentation.save("video_with_trim.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

**Lire les paramètres de rognage**

Pour inspecter les paramètres de rognage existants, chargez une présentation, trouvez un objet [VideoFrame](https://reference.aspose.com/slides/fr/python-java/aspose.slides/videoframe/) parmi les formes de la première diapositive, et lisez les valeurs via [VideoFrame.getTrimFromStart](https://reference.aspose.com/slides/fr/python-java/aspose.slides/videoframe/#getTrimFromStart) et [VideoFrame.getTrimFromEnd](https://reference.aspose.com/slides/fr/python-java/aspose.slides/videoframe/#getTrimFromEnd).

L'exemple de code suivant trouve le premier cadre vidéo sur la première diapositive et indique ses paramètres de rognage en millisecondes :

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

## **Gérer les sous-titres vidéo**

Aspose.Slides vous permet de gérer les sous-titres fermés pour les cadres vidéo dans les présentations PowerPoint. Les sous-titres sont stockés au format WebVTT et sont accessibles via la méthode [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/fr/python-java/aspose.slides/videoframe/#getCaptionTracks).

**Ajouter des sous-titres à un cadre vidéo**

Pour ajouter des sous-titres à un cadre vidéo :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/).
1. Ajouter une vidéo à la présentation.
1. Ajouter un objet [VideoFrame](https://reference.aspose.com/slides/fr/python-java/aspose.slides/videoframe/) à une diapositive.
1. Utiliser le [CaptionsCollection](https://reference.aspose.com/slides/fr/python-java/aspose.slides/captionscollection/) retourné par [getCaptionTracks](https://reference.aspose.com/slides/fr/python-java/aspose.slides/videoframe/#getCaptionTracks) pour ajouter une piste de sous-titres WebVTT.
1. Enregistrer la présentation modifiée.

Le code suivant vous montre comment ajouter des sous-titres à un cadre vidéo:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    video_data = Path("video.mp4").read_bytes()
    java_video_data = jpype.JArray(jpype.JByte)(video_data)
    video = presentation.getVideos().addVideo(java_video_data)
    slide = presentation.getSlides().get_Item(0)
    video_frame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video)

    # Ajouter une nouvelle piste de sous-titres à partir d'un fichier WebVTT.
    video_frame.getCaptionTracks().add("English", "track.vtt")
    presentation.save("video_with_captions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

La classe [CaptionsCollection](https://reference.aspose.com/slides/fr/python-java/aspose.slides/captionscollection/) propose également une surcharge qui vous permet d’ajouter des sous-titres depuis un flux.

**Extraire les sous-titres d’un cadre vidéo**

Pour extraire les sous-titres d’un cadre vidéo :

1. Charger la présentation contenant la vidéo.
1. Trouver l’objet [VideoFrame](https://reference.aspose.com/slides/fr/python-java/aspose.slides/videoframe/) ciblé.
1. Parcourir les pistes de sous-titres dans le [CaptionsCollection](https://reference.aspose.com/slides/fr/python-java/aspose.slides/captionscollection/).
1. Enregistrer chaque piste de sous-titres dans un fichier `.vtt`.

Le code suivant vous montre comment extraire les sous-titres d’un cadre vidéo:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpipeline.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, VideoFrame

presentation = Presentation("video_with_captions.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    for shape in slide.getShapes():
        if isinstance(shape, VideoFrame):
            for caption_track in shape.getCaptionTracks():
                # Enregistrer la piste de sous-titres dans un fichier WebVTT.
                file_path = Path(str(caption_track.getCaptionId()) + ".vtt")
                caption_data = bytes(caption_track.getBinaryData())
                file_path.write_bytes(caption_data)
finally:
    presentation.dispose()
```

Chaque objet [Captions](https://reference.aspose.com/slides/fr/python-java/aspose.slides/captions/) expose l’identifiant du sous-titre, l’étiquette, les données binaires et le texte du sous-titre sous forme de chaîne UTF‑8.

**Supprimer les sous-titres d’un cadre vidéo**

Pour supprimer les sous-titres d’un cadre vidéo :

1. Charger la présentation contenant la vidéo.
1. Obtenir l’objet [VideoFrame](https://reference.aspose.com/slides/fr/python-java/aspose.slides/videoframe/) ciblé.
1. Supprimer les pistes de sous-titres du [CaptionsCollection](https://reference.aspose.com/slides/fr/python-java/aspose.slides/captionscollection/).
1. Enregistrer la présentation modifiée.

Le code suivant vous montre comment supprimer tous les sous-titres d’un cadre vidéo:

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
        # Supprimer tous les sous-titres du cadre vidéo.
        video_frame.getCaptionTracks().clear()
        presentation.save("video_without_captions.pptx", SaveFormat.Pptx)
    else:
        print("The shape is not a video frame.")
finally:
    presentation.dispose()
```

Si vous devez supprimer une seule piste de sous-titres, utilisez les méthodes [remove](https://reference.aspose.com/slides/fr/python-java/aspose.slides/captionscollection/#remove) ou [removeAt](https://reference.aspose.com/slides/fr/python-java/aspose.slides/captionscollection/#removeAt) au lieu de [clear](https://reference.aspose.com/slides/fr/python-java/aspose.slides/captionscollection/#clear).

## **Extraire des vidéos des diapositives**

En plus d’ajouter des vidéos aux diapositives, Aspose.Slides vous permet d’extraire les vidéos incorporées dans les présentations.

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/) pour charger la présentation contenant la vidéo.
2. Parcourir toutes les objets [Slide](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slide/).
3. Parcourir toutes les objets [Shape](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shape/) pour trouver un [VideoFrame](https://reference.aspose.com/slides/fr/python-java/aspose.slides/videoframe/).
4. Enregistrer la vidéo sur le disque.

Ce code Python vous montre comment extraire la vidéo d’une diapositive de présentation:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, VideoFrame

presentation = Presentation("VideoSample.pptx")
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if isinstance(shape, VideoFrame):
                video = shape.getEmbeddedVideo()
                if video is not None:
                    content_type = str(video.getContentType())
                    file_extension = content_type.split("/", 1)[-1]
                    video_data = bytes(video.getBinaryData())
                    Path("testing2." + file_extension).write_bytes(video_data)
                else:
                    print("The video frame has no embedded video.")
finally:
    presentation.dispose()
```

## **FAQ**

**Quels paramètres de lecture vidéo peuvent être modifiés pour un VideoFrame ?**

Vous pouvez contrôler le [mode de lecture](https://reference.aspose.com/slides/fr/python-java/aspose.slides/videoframe/#setPlayMode) (automatique ou au clic) et la [boucle](https://reference.aspose.com/slides/fr/python-java/aspose.slides/videoframe/#setPlayLoopMode). Ces options sont disponibles via les propriétés de l’objet [VideoFrame](https://reference.aspose.com/slides/fr/python-java/aspose.slides/videoframe/).

**L'ajout d’une vidéo affecte-t‑il la taille du fichier PPTX ?**

Oui. Lorsque vous incorporez une vidéo locale, les données binaires sont incluses dans le document, ce qui fait que la taille de la présentation augmente proportionnellement à la taille du fichier. Lorsque vous ajoutez une vidéo en ligne, un lien et une vignette sont incorporés, de sorte que l'augmentation de taille est moindre.

**Puis‑je remplacer la vidéo d’un VideoFrame existant sans modifier sa position et sa taille ?**

Oui. Vous pouvez échanger le [contenu vidéo](https://reference.aspose.com/slides/fr/python-java/aspose.slides/videoframe/#setEmbeddedVideo) à l’intérieur du cadre tout en préservant la géométrie de la forme ; c’est un scénario courant pour mettre à jour les médias dans une mise en page existante.

**Le type de contenu (MIME) d’une vidéo incorporée peut‑il être déterminé ?**

Oui. Une vidéo incorporée possède un [type de contenu](https://reference.aspose.com/slides/fr/python-java/aspose.slides/video/#getContentType) que vous pouvez lire et utiliser, par exemple lors de son enregistrement sur le disque.