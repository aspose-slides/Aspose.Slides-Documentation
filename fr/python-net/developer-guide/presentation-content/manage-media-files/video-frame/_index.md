---
title: Ajouter des vidéos aux présentations en Python
linktitle: Trame vidéo
type: docs
weight: 10
url: /fr/python-net/video-frame/
keywords:
- ajouter vidéo
- créer vidéo
- intégrer vidéo
- extraire vidéo
- récupérer vidéo
- trame vidéo
- source Web
- PowerPoint
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Apprenez à ajouter et extraire programmétiquement des trames vidéo dans les diapositives PowerPoint et OpenDocument à l'aide d'Aspose.Slides pour Python via .NET. Guide pratique rapide."
---
Une vidéo bien placée dans une présentation peut rendre votre message plus percutant et augmenter le niveau d’engagement de votre public.  

PowerPoint vous permet d’ajouter des vidéos à une diapositive d’une présentation de deux manières :

* Ajouter ou incorporer une vidéo locale (stockée sur votre ordinateur)  
* Ajouter une vidéo en ligne (à partir d’une source Web telle que YouTube).  

Pour vous permettre d’ajouter des vidéos (objets vidéo) à une présentation, Aspose.Slides fournit la classe [Video](https://reference.aspose.com/slides/fr/python-net/aspose.slides/video/), la classe [VideoFrame](https://reference.aspose.com/slides/fr/python-net/aspose.slides/videoframe/) et d’autres types pertinents.  

## **Créer une trame vidéo intégrée**

Si le fichier vidéo que vous souhaitez ajouter à votre diapositive est stocké localement, vous pouvez créer une trame vidéo pour incorporer la vidéo dans votre présentation.  

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/).  
1. Obtenez la référence d’une diapositive via son index.  
1. Ajoutez un objet [Video](https://reference.aspose.com/slides/fr/python-net/aspose.slides/video/) et transmettez le chemin du fichier vidéo pour incorporer la vidéo à la présentation.  
1. Ajoutez un objet [VideoFrame](https://reference.aspose.com/slides/fr/python-net/aspose.slides/videoframe/) pour créer une trame pour la vidéo.  
1. Enregistrez la présentation modifiée.  

Ce code Python vous montre comment ajouter une vidéo stockée localement à une présentation :

```python
import aspose.slides as slides

with slides.Presentation(path + "pres.pptx") as pres:
    with open("Wildlife.mp4", "br") as fileStream:
        video = pres.videos.add_video(fileStream, slides.LoadingStreamBehavior.KEEP_LOCKED)

        # Obtient la première diapositive et ajoute une trame vidéo
        pres.slides[0].shapes.add_video_frame(10, 10, 150, 250, video)

        # Enregistre la présentation sur le disque
        pres.save(path + "pres-with-video.pptx", slides.export.SaveFormat.PPTX)
```

En alternative, vous pouvez ajouter une vidéo en transmettant directement son chemin de fichier à la méthode `add_video_frame(x, y, width, height, fname)` :

``` python
import aspose.slides as slides

with slides.Presentation() as pres:
    sld = pres.slides[0]
    vf = sld.shapes.add_video_frame(50, 150, 300, 150, "video1.avi")
```

## **Créer une trame vidéo avec une vidéo provenant d’une source Web**

Microsoft [PowerPoint 2013 et versions ultérieures](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) prennent en charge les vidéos YouTube dans les présentations. Si la vidéo que vous souhaitez utiliser est disponible en ligne (par ex. sur YouTube), vous pouvez l’ajouter à votre présentation via son lien Web.  

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/).  
1. Obtenez la référence d’une diapositive via son index.  
1. Ajoutez un objet [Video](https://reference.aspose.com/slides/fr/python-net/aspose.slides/video/) et transmettez le lien vers la vidéo.  
1. Définissez une vignette pour la trame vidéo.  
1. Enregistrez la présentation.  

Ce code Python vous montre comment ajouter une vidéo depuis le Web à une diapositive d’une présentation PowerPoint :

```python
import aspose.slides as slides
from urllib.request import urlopen

def add_video_from_youyube(pres, videoId):
    # Ajoute une trame vidéo
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

## **Gérer les sous‑titres vidéo**

Aspose.Slides vous permet de gérer les sous‑titres fermés pour les trames vidéo dans les présentations PowerPoint. Les sous‑titres sont stockés au format WebVTT et sont exposés via la propriété [VideoFrame.caption_tracks](https://reference.aspose.com/slides/fr/python-net/aspose.slides/videoframe/caption_tracks/).  

**Ajouter des sous‑titres à une trame vidéo**

Pour ajouter des sous‑titres à une trame vidéo :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/).  
1. Ajoutez une vidéo à la présentation.  
1. Ajoutez un objet [VideoFrame](https://reference.aspose.com/slides/fr/python-net/aspose.slides/videoframe/) à une diapositive.  
1. Utilisez la [CaptionsCollection](https://reference.aspose.com/slides/fr/python-net/aspose.slides/captionscollection/) retournée par [caption_tracks](https://reference.aspose.com/slides/fr/python-net/aspose.slides/videoframe/caption_tracks/) pour ajouter une piste de sous‑titres WebVTT.  
1. Enregistrez la présentation modifiée.  

Le code suivant vous montre comment ajouter des sous‑titres à une trame vidéo :

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

La classe [CaptionsCollection](https://reference.aspose.com/slides/fr/python-net/aspose.slides/captionscollection/) propose également une surcharge qui vous permet d’ajouter des sous‑titres depuis un flux.  

**Extraire les sous‑titres d’une trame vidéo**

Pour extraire les sous‑titres d’une trame vidéo :

1. Chargez la présentation contenant la vidéo.  
1. Trouvez l’objet [VideoFrame](https://reference.aspose.com/slides/fr/python-net/aspose.slides/videoframe/) cible.  
1. Parcourez la collection [caption_tracks](https://reference.aspose.com/slides/fr/python-net/aspose.slides/videoframe/caption_tracks/).  
1. Enregistrez chaque piste de sous‑titres dans un fichier `.vtt`.  

Le code suivant vous montre comment extraire les sous‑titres d’une trame vidéo :

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

Chaque objet [Captions](https://reference.aspose.com/slides/fr/python-net/aspose.slides/captions/) expose l’identifiant du sous‑titre, l’étiquette, les données binaires et le texte du sous‑titre sous forme de chaîne UTF‑8.  

**Supprimer les sous‑titres d’une trame vidéo**

Pour supprimer les sous‑titres d’une trame vidéo :

1. Chargez la présentation contenant la vidéo.  
1. Obtenez l’objet [VideoFrame](https://reference.aspose.com/slides/fr/python-net/aspose.slides/videoframe/) cible.  
1. Supprimez les pistes de sous‑titres de la [CaptionsCollection](https://reference.aspose.com/slides/fr/python-net/aspose.slides/captionscollection/).  
1. Enregistrez la présentation modifiée.  

Le code suivant vous montre comment supprimer tous les sous‑titres d’une trame vidéo :

```py
import aspose.slides as slides

with slides.Presentation("video_with_captions.pptx") as presentation:
    slide = presentation.slides[0]
    video_frame = slide.shapes[0]  # type : slides.VideoFrame

    # Supprime toutes les sous-titres de la trame vidéo.
    video_frame.caption_tracks.clear()

    presentation.save("video_without_captions.pptx", slides.export.SaveFormat.PPTX)
```

Si vous devez supprimer uniquement une piste de sous‑titres, utilisez les méthodes [remove](https://reference.aspose.com/slides/fr/python-net/aspose.slides/captionscollection/remove/) ou [remove_at](https://reference.aspose.com/slides/fr/python-net/aspose.slides/captionscollection/remove_at/) au lieu de [clear](https://reference.aspose.com/slides/fr/python-net/aspose.slides/captionscollection/clear/).  

## **Extraire la vidéo d’une diapositive**

En plus d’ajouter des vidéos aux diapositives, Aspose.Slides vous permet d’extraire les vidéos incorporées dans les présentations.  

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/) pour charger la présentation contenant la vidéo.  
2. Parcourez tous les objets [Slide](https://reference.aspose.com/slides/fr/python-net/aspose.slides/slide/).  
3. Parcourez tous les objets [Shape](https://reference.aspose.com/slides/fr/python-net/aspose.slides/shape/) pour trouver un [VideoFrame](https://reference.aspose.com/slides/fr/python-net/aspose.slides/videoframe/).  
4. Enregistrez la vidéo sur le disque.  

Ce code Python vous montre comment extraire la vidéo d’une diapositive de présentation :

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

**Quels paramètres de lecture vidéo peuvent être modifiés pour une VideoFrame ?**  

Vous pouvez contrôler le [mode de lecture](https://reference.aspose.com/slides/fr/python-net/aspose.slides/videoframe/play_mode/) (automatique ou au clic) et la [boucle de lecture](https://reference.aspose.com/slides/fr/python-net/aspose.slides/videoframe/play_loop_mode/). Ces options sont accessibles via les propriétés de l’objet [VideoFrame](https://reference.aspose.com/slides/fr/python-net/aspose.slides/videoframe/).  

**L’ajout d’une vidéo influence‑t‑il la taille du fichier PPTX ?**  

Oui. Lorsque vous intégrez une vidéo locale, les données binaires sont incluses dans le document, ce qui augmente la taille de la présentation proportionnellement à la taille du fichier. Lorsque vous ajoutez une vidéo en ligne, seul un lien et une vignette sont incorporés, ce qui entraîne une augmentation de taille moindre.  

**Puis‑je remplacer la vidéo d’une VideoFrame existante sans changer sa position ni sa taille ?**  

Oui. Vous pouvez échanger le [contenu vidéo](https://reference.aspose.com/slides/fr/python-net/aspose.slides/videoframe/embedded_video/) à l’intérieur de la trame tout en conservant la géométrie de la forme ; c’est un scénario courant pour mettre à jour les médias dans une mise en page existante.  

**Le type de contenu (MIME) d’une vidéo intégrée peut‑il être déterminé ?**  

Oui. Une vidéo intégrée possède un [type de contenu](https://reference.aspose.com/slides/fr/python-net/aspose.slides/video/content_type/) que vous pouvez lire et utiliser, par exemple lors de l’enregistrement sur le disque.