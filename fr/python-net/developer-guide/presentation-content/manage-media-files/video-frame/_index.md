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
- source web
- PowerPoint
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Apprenez à ajouter et extraire programmément des cadres vidéo dans les diapositives PowerPoint et OpenDocument en utilisant Aspose.Slides pour Python via .NET. Guide pratique rapide."
---

Une vidéo bien placée dans une présentation peut rendre votre message plus percutant et augmenter le niveau d'engagement de votre audience. 

PowerPoint vous permet d'ajouter des vidéos à une diapositive d'une présentation de deux manières :

* Ajouter ou intégrer une vidéo locale (stockée sur votre ordinateur)
* Ajouter une vidéo en ligne (à partir d'une source web comme YouTube).

Pour vous permettre d'ajouter des vidéos (objets vidéo) à une présentation, Aspose.Slides fournit les interfaces [IVideo](https://reference.aspose.com/slides/python-net/aspose.slides/ivideo/) , [IVideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/ivideoframe/) et d'autres types pertinents. 

## **Créer un cadre vidéo intégré**

Si le fichier vidéo que vous souhaitez ajouter à votre diapositive est stocké localement, vous pouvez créer un cadre vidéo pour intégrer la vidéo dans votre présentation. 

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
2. Obtenir la référence d'une diapositive via son index. 
3. Ajouter un objet [IVideo](https://reference.aspose.com/slides/python-net/aspose.slides/ivideo/) et fournir le chemin du fichier vidéo pour intégrer la vidéo à la présentation. 
4. Ajouter un objet [IVideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/ivideoframe/) pour créer un cadre pour la vidéo.  
5. Enregistrer la présentation modifiée. 

Ce code Python montre comment ajouter une vidéo stockée localement à une présentation :

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

Vous pouvez également ajouter une vidéo en passant directement son chemin de fichier à la méthode `add_video_frame(x, y, width, height, fname)` :

```python
import aspose.slides as slides

with slides.Presentation() as pres:
    sld = pres.slides[0]
    vf = sld.shapes.add_video_frame(50, 150, 300, 150, "video1.avi")
```

## **Créer un cadre vidéo avec une vidéo provenant d’une source web**

Microsoft [PowerPoint 2013 et versions ultérieures](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) prend en charge les vidéos YouTube dans les présentations. Si la vidéo que vous souhaitez utiliser est disponible en ligne (par ex. sur YouTube), vous pouvez l’ajouter à votre présentation via son lien web. 

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 
2. Obtenir la référence d'une diapositive via son index. 
3. Ajouter un objet [IVideo](https://reference.aspose.com/slides/python-net/aspose.slides/ivideo/) et fournir le lien vers la vidéo.
4. Définir une miniature pour le cadre vidéo. 
5. Enregistrer la présentation. 

Ce code Python montre comment ajouter une vidéo depuis le web à une diapositive d’une présentation PowerPoint :

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

## **Extraire la vidéo d’une diapositive**

En plus d’ajouter des vidéos aux diapositives, Aspose.Slides vous permet d’extraire les vidéos intégrées dans les présentations.

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) pour charger la présentation contenant la vidéo. 
2. Parcourir tous les objets [ISlide](https://reference.aspose.com/slides/python-net/aspose.slides/islide/). 
3. Parcourir tous les objets [IShape](https://reference.aspose.com/slides/python-net/aspose.slides/ishape/) afin de trouver un [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/). 
4. Enregistrer la vidéo sur le disque.

Ce code Python montre comment extraire la vidéo d’une diapositive de présentation :

```python
import aspose.slides as slides

# Crée une instance d'un objet Presentation qui représente un fichier de présentation 
with slides.Presentation(path + "Video.pptx") as presentation:
    for shape in presentation.slides[0].shapes:
        if type(shape) is slides.VideoFrame:
            type = shape.embedded_video.content_type
            buffer = shape.embedded_video.binary_data
            with open("NewVideo_out." + type[type.rfind('/') + 1:len(type)], "wb") as stream:
                stream.write(buffer)
```

## **FAQ**

**Quels paramètres de lecture vidéo peuvent être modifiés pour un VideoFrame ?**

Vous pouvez contrôler le [mode de lecture](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_mode/) (automatique ou au clic) et la [boucle](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_loop_mode/). Ces options sont accessibles via les propriétés de l’objet [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/).

**L’ajout d’une vidéo affecte‑t‑il la taille du fichier PPTX ?**

Oui. Lorsque vous intégrez une vidéo locale, les données binaires sont incluses dans le document, ce qui augmente la taille de la présentation proportionnellement à la taille du fichier. Lorsque vous ajoutez une vidéo en ligne, un lien et une miniature sont intégrés, de sorte que l’augmentation de taille est moindre.

**Puis‑je remplacer la vidéo d’un VideoFrame existant sans changer sa position et sa taille ?**

Oui. Vous pouvez remplacer le [contenu vidéo](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/embedded_video/) du cadre tout en conservant la géométrie de la forme ; c’est un scénario courant pour mettre à jour les médias dans une disposition existante.

**Peut‑on déterminer le type de contenu (MIME) d’une vidéo intégrée ?**

Oui. Une vidéo intégrée possède un [type de contenu](https://reference.aspose.com/slides/python-net/aspose.slides/video/content_type/) que vous pouvez lire et utiliser, par exemple lors de l’enregistrement sur le disque.