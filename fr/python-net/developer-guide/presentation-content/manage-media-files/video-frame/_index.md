---
title: Cadre Vidéo
type: docs
weight: 10
url: /python-net/video-frame/
keywords: "Ajouter une vidéo, créer un cadre vidéo, extraire une vidéo, présentation PowerPoint, Python, Aspose.Slides pour Python via .NET"
description: "Ajouter un cadre vidéo à une présentation PowerPoint en Python"
---

Une vidéo bien placée dans une présentation peut rendre votre message plus convaincant et augmenter les niveaux d'engagement avec votre public.

PowerPoint vous permet d'ajouter des vidéos à une diapositive dans une présentation de deux manières :

* Ajouter ou intégrer une vidéo locale (stockée sur votre machine)
* Ajouter une vidéo en ligne (provenant d'une source web telle que YouTube).

Pour vous permettre d'ajouter des vidéos (objets vidéo) à une présentation, Aspose.Slides fournit l'interface [IVideo](https://reference.aspose.com/slides/python-net/aspose.slides/ivideo/), l'interface [IVideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/ivideoframe/) et d'autres types pertinents.

## **Créer un Cadre Vidéo Intégré**

Si le fichier vidéo que vous souhaitez ajouter à votre diapositive est stocké localement, vous pouvez créer un cadre vidéo pour intégrer la vidéo dans votre présentation.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Obtenez la référence d'une diapositive à travers son index.
1. Ajoutez un objet [IVideo](https://reference.aspose.com/slides/python-net/aspose.slides/ivideo/) et passez le chemin du fichier vidéo pour intégrer la vidéo à la présentation.
1. Ajoutez un objet [IVideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/ivideoframe/) pour créer un cadre pour la vidéo.
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

Alternativement, vous pouvez ajouter une vidéo en passant directement son chemin de fichier à la méthode `add_video_frame(x, y, width, height, fname)` :

``` python
import aspose.slides as slides

with slides.Presentation() as pres:
    sld = pres.slides[0]
    vf = sld.shapes.add_video_frame(50, 150, 300, 150, "video1.avi")
```


## **Créer un Cadre Vidéo avec Vidéo en Source Web**

Microsoft [PowerPoint 2013 et versions ultérieures](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) prend en charge les vidéos YouTube dans les présentations. Si la vidéo que vous souhaitez utiliser est disponible en ligne (par exemple sur YouTube), vous pouvez l'ajouter à votre présentation via son lien web.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Obtenez la référence d'une diapositive à travers son index.
1. Ajoutez un objet [IVideo](https://reference.aspose.com/slides/python-net/aspose.slides/ivideo/) et passez le lien vers la vidéo.
1. Définissez une miniature pour le cadre vidéo.
1. Enregistrez la présentation.

Ce code Python vous montre comment ajouter une vidéo du web à une diapositive dans une présentation PowerPoint :

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

## **Extraire une Vidéo d'une Diapositive**

En plus d'ajouter des vidéos aux diapositives, Aspose.Slides vous permet d'extraire les vidéos intégrées dans les présentations.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) pour charger la présentation contenant la vidéo.
2. Itérez à travers tous les objets [ISlide](https://reference.aspose.com/slides/python-net/aspose.slides/islide/).
3. Itérez à travers tous les objets [IShape](https://reference.aspose.com/slides/python-net/aspose.slides/ishape/) pour trouver un [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/).
4. Enregistrez la vidéo sur le disque.

Ce code Python vous montre comment extraire la vidéo d'une diapositive de présentation :

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