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
description: "Apprenez à ajouter et extraire programmétiquement des cadres vidéo dans les présentations PowerPoint et OpenDocument à l'aide d'Aspose.Slides pour Python via .NET. Guide pratique rapide."
---

Une vidéo bien placée dans une présentation peut rendre votre message plus percutant et augmenter le niveau d'engagement de votre auditoire. 

PowerPoint vous permet d’ajouter des vidéos à une diapositive d’une présentation de deux manières :

* Ajouter ou incorporer une vidéo locale (stockée sur votre ordinateur)
* Ajouter une vidéo en ligne (provenant d’une source Web telle que YouTube).

Pour vous permettre d’ajouter des vidéos (objets vidéo) à une présentation, Aspose.Slides fournit les classes [Video](https://reference.aspose.com/slides/python-net/aspose.slides/video/) , [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/) ainsi que d’autres types pertinents. 

## **Créer un cadre vidéo intégré**

Si le fichier vidéo que vous souhaitez ajouter à votre diapositive est stocké localement, vous pouvez créer un cadre vidéo pour incorporer la vidéo dans votre présentation. 

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
1. Obtenez la référence d’une diapositive via son index. 
1. Ajoutez un objet [Video](https://reference.aspose.com/slides/python-net/aspose.slides/video/) et transmettez le chemin du fichier vidéo pour l’incorporer à la présentation. 
1. Ajoutez un objet [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/) pour créer un cadre pour la vidéo.  
1. Enregistrez la présentation modifiée. 

Ce code Python vous montre comment ajouter une vidéo stockée localement à une présentation :
```python
import aspose.slides as slides

with slides.Presentation(path + "pres.pptx") as pres:
    with open("Wildlife.mp4", "br") as fileStream:
        video = pres.videos.add_video(fileStream, slides.LoadingStreamBehavior.KEEP_LOCKED)

        # Obtient la première diapositive et ajoute un cadre vidéo
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



## **Créer un cadre vidéo avec une vidéo provenant d’une source Web**

Microsoft [PowerPoint 2013 et versions ultérieures](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) prend en charge les vidéos YouTube dans les présentations. Si la vidéo que vous souhaitez utiliser est disponible en ligne (par exemple sur YouTube), vous pouvez l’ajouter à votre présentation via son lien Web. 

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
1. Obtenez la référence d’une diapositive via son index. 
1. Ajoutez un objet [Video](https://reference.aspose.com/slides/python-net/aspose.slides/video/) et transmettez le lien vers la vidéo.
1. Définissez une miniature pour le cadre vidéo. 
1. Enregistrez la présentation. 

Ce code Python vous montre comment ajouter une vidéo depuis le Web à une diapositive d’une présentation PowerPoint :
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


## **Extraire une vidéo d’une diapositive**

En plus d’ajouter des vidéos aux diapositives, Aspose.Slides vous permet d’extraire les vidéos incorporées dans les présentations.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) pour charger la présentation contenant la vidéo. 
2. Parcourez tous les objets [Slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/) . 
3. Parcourez tous les objets [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) pour trouver un [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/) . 
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

**Quels paramètres de lecture vidéo peuvent être modifiés pour un VideoFrame ?**

Vous pouvez contrôler le [mode de lecture](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_mode/) (automatique ou sur clic) et la [boucle](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_loop_mode/). Ces options sont disponibles via les propriétés de l’objet [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/) .

**L’ajout d’une vidéo affecte-t-il la taille du fichier PPTX ?**

Oui. Lorsque vous incorporez une vidéo locale, les données binaires sont incluses dans le document, de sorte que la taille de la présentation augmente proportionnellement à la taille du fichier. Lorsque vous ajoutez une vidéo en ligne, un lien et une miniature sont incorporés, ce qui entraîne une augmentation de taille moindre.

**Puis-je remplacer la vidéo d’un VideoFrame existant sans modifier sa position ni sa taille ?**

Oui. Vous pouvez échanger le [contenu vidéo](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/embedded_video/) dans le cadre tout en conservant la géométrie de la forme ; c’est un cas d’utilisation fréquent pour mettre à jour les médias dans une mise en page existante.

**Peut-on déterminer le type de contenu (MIME) d’une vidéo incorporée ?**

Oui. Une vidéo incorporée possède un [type de contenu](https://reference.aspose.com/slides/python-net/aspose.slides/video/content_type/) que vous pouvez lire et utiliser, par exemple lors de son enregistrement sur le disque.