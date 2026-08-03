---
title: Ajouter des vidéos aux présentations en Python
linktitle: Cadre vidéo
type: docs
weight: 10
url: /fr/python-net/video-frame/
keywords:
- ajouter vidéo
- créer vidéo
- intégrer vidéo
- extraire vidéo
- récupérer vidéo
- cadre vidéo
- source Web
- PowerPoint
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Apprenez à ajouter et extraire programmatiquement des cadres vidéo dans les diapositives PowerPoint et OpenDocument à l'aide d'Aspose.Slides pour Python via .NET. Guide pratique rapide."
---
## **Introduction**

Une vidéo bien placée dans une présentation peut rendre votre message plus percutant et augmenter le niveau d'engagement de votre public. 

PowerPoint vous permet d'ajouter des vidéos à une diapositive d'une présentation de deux manières :

* Ajouter ou intégrer une vidéo locale (stockée sur votre ordinateur)
* Ajouter une vidéo en ligne (à partir d'une source Web telle que YouTube).

Pour vous permettre d'ajouter des vidéos (objets vidéo) à une présentation, Aspose.Slides fournit les classes [Video](https://reference.aspose.com/slides/fr/python-net/aspose.slides/video/) , [VideoFrame](https://reference.aspose.com/slides/fr/python-net/aspose.slides/videoframe/) et d'autres types pertinents. 

## **Créer un cadre vidéo incorporé**

Si le fichier vidéo que vous souhaitez ajouter à votre diapositive est stocké localement, vous pouvez créer un cadre vidéo pour intégrer la vidéo dans votre présentation. 

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/).
1. Obtenez la référence d'une diapositive via son indice. 
1. Ajoutez un objet [Video](https://reference.aspose.com/slides/fr/python-net/aspose.slides/video/) et transmettez le chemin du fichier vidéo pour intégrer la vidéo à la présentation. 
1. Ajoutez un objet [VideoFrame](https://reference.aspose.com/slides/fr/python-net/aspose.slides/videoframe/) pour créer un cadre pour la vidéo.  
1. Enregistrez la présentation modifiée. 

Ce code Python vous montre comment ajouter une vidéo stockée localement à une présentation :

```python
import aspose.slides as slides

with slides.Presentation(path + "pres.pptx") as pres:
    with open("Wildlife.mp4", "br") as fileStream:
        video = pres.videos.add_video(fileStream, slides.LoadingStreamBehavior.KEEP_LOCKED)

        # Obtient la première diapositive et ajoute un cadre vidéo
        pres.slides[0].shapes.add_video_frame(10, 10, 150, 250, video)

        # Enregistre la présentation sur le disque
        pres.save(path + "pres-with-video.pptx", slides.export.SaveFormat.PPTX)
```

Alternativement, vous pouvez ajouter une vidéo en transmettant directement son chemin de fichier à la méthode `add_video_frame(x, y, width, height, fname)` :

``` python
import aspose.slides as slides

with slides.Presentation() as pres:
    sld = pres.slides[0]
    vf = sld.shapes.add_video_frame(50, 150, 300, 150, "video1.avi")
```

## **Créer un cadre vidéo avec une vidéo provenant d'une source Web**

Les versions récentes de Microsoft [PowerPoint](https://support.microsoft.com/en-us/office/insert-a-video-from-youtube-or-another-site-8340ec69-4cee-4fe1-ab96-4849154bc6db) prennent en charge les vidéos en ligne dans les présentations. Si la vidéo que vous souhaitez utiliser est disponible en ligne (par exemple sur YouTube), vous pouvez l'ajouter à votre présentation via son lien web.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/).
1. Obtenez la référence d'une diapositive via son indice. 
1. Ajoutez un objet [Video](https://reference.aspose.com/slides/fr/python-net/aspose.slides/video/) et transmettez le lien vers la vidéo.
1. Définissez une miniature pour le cadre vidéo. 
1. Enregistrez la présentation. 

Ce code Python vous montre comment ajouter une vidéo depuis le Web à une diapositive d'une présentation PowerPoint :

```python
import aspose.slides as slides
from urllib.request import urlopen

def add_video_from_youyube(pres, videoId):
    # Ajoute un cadre vidéo
    videoFrame = pres.slides[0].shapes.add_video_frame(10, 10, 427, 240, "https://www.youtube.com/embed/" + videoId)
    videoFrame.play_mode = slides.VideoPlayModePreset.AUTO

    # Charge la miniature
    thumbnail_uri = "http://img.youtube.com/vi/" + videoId + "/hqdefault.jpg"
    f = urlopen(thumbnail_uri)
    videoFrame.picture_format.picture.image = pres.images.add_image(f.read())


with slides.Presentation() as pres:
    add_video_from_youyube(pres, "s5JbfQZ5Cc0")
    pres.save("AddVideoFrameFromWebSource_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Rogner un cadre vidéo**

Aspose.Slides vous permet de contrôler quelle partie d'une vidéo est lue en définissant les valeurs trim-from-start et trim-from-end via [VideoFrame.trim_from_start](https://reference.aspose.com/slides/fr/python-net/aspose.slides/videoframe/trim_from_start/) et [VideoFrame.trim_from_end](https://reference.aspose.com/slides/fr/python-net/aspose.slides/videoframe/trim_from_end/). Les deux valeurs sont exprimées en millisecondes et définissent la durée à sauter respectivement du début et de la fin de la vidéo. Ces paramètres modifient les réglages de lecture de la vidéo dans la présentation ; ils ne coupent pas ou ne modifient pas les données binaires de la vidéo incorporée.

**Définir les paramètres de rognage**

Pour créer un cadre vidéo et définir ses paramètres de rognage :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/).
1. Ajoutez un objet [Video](https://reference.aspose.com/slides/fr/python-net/aspose.slides/video/) à la présentation.
1. Ajoutez un objet [VideoFrame](https://reference.aspose.com/slides/fr/python-net/aspose.slides/videoframe/) à une diapositive.
1. Définissez les valeurs trim-from-start et trim-from-end via [VideoFrame.trim_from_start](https://reference.aspose.com/slides/fr/python-net/aspose.slides/videoframe/trim_from_start/) et [VideoFrame.trim_from_end](https://reference.aspose.com/slides/fr/python-net/aspose.slides/videoframe/trim_from_end/).
1. Enregistrez la présentation modifiée.

L'exemple de code suivant saute les 2,5 premières secondes et la dernière seconde d'une vidéo incorporée pendant la lecture :

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    with open("video.mp4", "rb") as video_stream:
        video_data = video_stream.read()

    video = presentation.videos.add_video(video_data)

    slide = presentation.slides[0]
    video_frame = slide.shapes.add_video_frame(50, 50, 640, 360, video)

    video_frame.trim_from_start = 2500.0
    video_frame.trim_from_end = 1000.0

    presentation.save("video_with_trim.pptx", slides.export.SaveFormat.PPTX)
```

**Lire les paramètres de rognage**

Pour inspecter les paramètres de rognage existants, chargez une présentation, trouvez un objet [VideoFrame](https://reference.aspose.com/slides/fr/python-net/aspose.slides/videoframe/) parmi les formes de la première diapositive, et lisez les valeurs via [VideoFrame.trim_from_start](https://reference.aspose.com/slides/fr/python-net/aspose.slides/videoframe/trim_from_start/) et [VideoFrame.trim_from_end](https://reference.aspose.com/slides/fr/python-net/aspose.slides/videoframe/trim_from_end/).

L'exemple de code suivant trouve le premier cadre vidéo sur la première diapositive et indique ses paramètres de rognage en millisecondes :

```python
import aspose.slides as slides

with slides.Presentation("video_with_trim.pptx") as presentation:
    slide = presentation.slides[0]
    for shape in slide.shapes:
        if isinstance(shape, slides.VideoFrame):
            video_frame = shape
            trim_from_start = video_frame.trim_from_start
            trim_from_end = video_frame.trim_from_end

            print(f"Trim from start: {trim_from_start} ms")
            print(f"Trim from end: {trim_from_end} ms")
            break
```

## **Gérer les sous-titres vidéo**

Aspose.Slides vous permet de gérer les sous-titres fermés pour les cadres vidéo dans les présentations PowerPoint. Les sous-titres sont stockés au format WebVTT et sont exposés via la propriété [VideoFrame.caption_tracks](https://reference.aspose.com/slides/fr/python-net/aspose.slides/videoframe/caption_tracks/).

**Ajouter des sous-titres à un cadre vidéo**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/).
1. Ajoutez une vidéo à la présentation.
1. Ajoutez un objet [VideoFrame](https://reference.aspose.com/slides/fr/python-net/aspose.slides/videoframe/) à une diapositive.
1. Utilisez le [CaptionsCollection](https://reference.aspose.com/slides/fr/python-net/aspose.slides/captionscollection/) retourné par [caption_tracks](https://reference.aspose.com/slides/fr/python-net/aspose.slides/videoframe/caption_tracks/) pour ajouter une piste de sous-titres WebVTT.
1. Enregistrez la présentation modifiée.

Le code suivant vous montre comment ajouter des sous-titres à un cadre vidéo :

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    with open("video.mp4", "rb") as video_stream:
        video_data = video_stream.read()

    video = presentation.videos.add_video(video_data)

    slide = presentation.slides[0]
    video_frame = slide.shapes.add_video_frame(0, 0, 100, 100, video)

    # Ajoute une nouvelle piste de sous-titres à partir d'un fichier WebVTT.
    video_frame.caption_tracks.add("English", "track.vtt")

    presentation.save("video_with_captions.pptx", slides.export.SaveFormat.PPTX)
```

La classe [CaptionsCollection](https://reference.aspose.com/slides/fr/python-net/aspose.slides/captionscollection/) fournit également une surcharge qui vous permet d'ajouter des sous-titres depuis un flux.

**Extraire les sous-titres d'un cadre vidéo**

1. Chargez la présentation contenant la vidéo.
1. Trouvez l'objet [VideoFrame](https://reference.aspose.com/slides/fr/python-net/aspose.slides/videoframe/) cible.
1. Parcourez la collection [caption_tracks](https://reference.aspose.com/slides/fr/python-net/aspose.slides/videoframe/caption_tracks/).
1. Enregistrez chaque piste de sous-titres dans un fichier `.vtt`.

Le code suivant montre comment extraire les sous-titres d'un cadre vidéo :

```py
import aspose.slides as slides

with slides.Presentation("video_with_captions.pptx") as presentation:
    slide = presentation.slides[0]
    for shape in slide.shapes:
        if isinstance(shape, slides.VideoFrame):
            for caption_track in shape.caption_tracks:
                # Enregistre la piste de sous-titres dans un fichier WebVTT.
                file_path = f"{caption_track.caption_id}.vtt"
                with open(file_path, "wb") as track_stream:
                    track_stream.write(bytes(caption_track.binary_data))
```

Chaque objet [Captions](https://reference.aspose.com/slides/fr/python-net/aspose.slides/captions/) expose l'identifiant du sous-titre, le label, les données binaires et le texte du sous-titre sous forme de chaîne UTF-8.

**Supprimer les sous-titres d'un cadre vidéo**

1. Chargez la présentation contenant la vidéo.
1. Obtenez l'objet [VideoFrame](https://reference.aspose.com/slides/fr/python-net/aspose.slides/videoframe/) cible.
1. Supprimez les pistes de sous-titres de la [CaptionsCollection](https://reference.aspose.com/slides/fr/python-net/aspose.slides/captionscollection/).
1. Enregistrez la présentation modifiée.

Le code suivant montre comment supprimer tous les sous-titres d'un cadre vidéo :

```py
import aspose.slides as slides

with slides.Presentation("video_with_captions.pptx") as presentation:
    slide = presentation.slides[0]
    video_frame = slide.shapes[0]  # type: slides.VideoFrame

    # Supprime tous les sous-titres du cadre vidéo.
    video_frame.caption_tracks.clear()

    presentation.save("video_without_captions.pptx", slides.export.SaveFormat.PPTX)
```

Si vous devez supprimer une seule piste de sous-titres, utilisez les méthodes [remove](https://reference.aspose.com/slides/fr/python-net/aspose.slides/captionscollection/remove/) ou [remove_at](https://reference.aspose.com/slides/fr/python-net/aspose.slides/captionscollection/remove_at/) au lieu de [clear](https://reference.aspose.com/slides/fr/python-net/aspose.slides/captionscollection/clear/).

## **Extraire la vidéo d'une diapositive**

Outre l'ajout de vidéos aux diapositives, Aspose.Slides permet d'extraire les vidéos incorporées dans les présentations.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/) pour charger la présentation contenant la vidéo. 
2. Parcourez tous les objets [Slide](https://reference.aspose.com/slides/fr/python-net/aspose.slides/slide/).
3. Parcourez tous les objets [Shape](https://reference.aspose.com/slides/fr/python-net/aspose.slides/shape/) pour trouver un [VideoFrame](https://reference.aspose.com/slides/fr/python-net/aspose.slides/videoframe/). 
4. Enregistrez la vidéo sur le disque.

Ce code Python montre comment extraire la vidéo d'une diapositive de présentation :

```python
import aspose.slides as slides

# Instancie un objet Presentation qui représente un fichier de présentation
with slides.Presentation(path + "Video.pptx") as presentation:
    for shape in presentation.slides[0].shapes:
        if type(shape) is slides.VideoFrame:
            type = shape.embedded_video.content_type
            buffer = shape.embedded_video.binary_data
            with open("NewVideo_out." + type[type.rfind('/') + 1:len(type)], "wb") as stream:
                stream.write(buffer)
```

## **FAQ**

**Quels paramètres de lecture vidéo peuvent être modifiés pour un VideoFrame ?**

Vous pouvez contrôler le [playback mode](https://reference.aspose.com/slides/fr/python-net/aspose.slides/videoframe/play_mode/) (auto ou au clic) et le [looping](https://reference.aspose.com/slides/fr/python-net/aspose.slides/videoframe/play_loop_mode/). Ces options sont disponibles via les propriétés de l'objet [VideoFrame](https://reference.aspose.com/slides/fr/python-net/aspose.slides/videoframe/).

**L'ajout d'une vidéo affecte-t-il la taille du fichier PPTX ?**

Oui. Lorsque vous intégrez une vidéo locale, les données binaires sont incluses dans le document, ce qui fait croître la taille de la présentation proportionnellement à la taille du fichier. Lorsque vous ajoutez une vidéo en ligne, un lien et une miniature sont incorporés, de sorte que l'augmentation de taille est moindre.

**Puis-je remplacer la vidéo dans un VideoFrame existant sans modifier sa position et sa taille ?**

Oui. Vous pouvez échanger le [video content](https://reference.aspose.com/slides/fr/python-net/aspose.slides/videoframe/embedded_video/) à l'intérieur du cadre tout en conservant la géométrie de la forme ; il s'agit d'un scénario fréquent pour mettre à jour les médias dans une mise en page existante.

**Peut-on déterminer le type de contenu (MIME) d'une vidéo incorporée ?**

Oui. Une vidéo intégrée possède un [content type](https://reference.aspose.com/slides/fr/python-net/aspose.slides/video/content_type/) que vous pouvez lire et utiliser, par exemple lors de l'enregistrement sur le disque.