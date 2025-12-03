---
title: Gérer les cadres vidéo dans les présentations en Java
linktitle: Cadre vidéo
type: docs
weight: 10
url: /fr/java/video-frame/
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
- Java
- Aspose.Slides
description: "Apprenez à ajouter et extraire programmatiquement des cadres vidéo dans les diapositives PowerPoint et OpenDocument en utilisant Aspose.Slides pour Java. Guide pratique rapide."
---

Une vidéo bien placée dans une présentation peut rendre votre message plus percutant et augmenter le niveau d'engagement de votre public. 

PowerPoint vous permet d’ajouter des vidéos à une diapositive d’une présentation de deux manières :

* Ajouter ou intégrer une vidéo locale (stockée sur votre machine)
* Ajouter une vidéo en ligne (provenant d’une source Web telle que YouTube).

Pour vous permettre d’ajouter des vidéos (objets vidéo) à une présentation, Aspose.Slides fournit les interfaces [IVideo](https://reference.aspose.com/slides/java/com.aspose.slides/ivideo/) et [IVideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/), ainsi que d’autres types pertinents. 

## **Créer des cadres vidéo intégrés**

Si le fichier vidéo que vous souhaitez ajouter à votre diapositive est stocké localement, vous pouvez créer un cadre vidéo pour intégrer la vidéo dans votre présentation. 

1. Créez une instance de la classe [Presentation ](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)class.
1. Obtenez la référence d’une diapositive via son index. 
1. Ajoutez un objet [IVideo](https://reference.aspose.com/slides/java/com.aspose.slides/ivideo/) et transmettez le chemin du fichier vidéo pour intégrer la vidéo à la présentation. 
1. Ajoutez un objet [IVideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/) pour créer un cadre pour la vidéo.  
1. Enregistrez la présentation modifiée. 

Ce code Java vous montre comment ajouter une vidéo stockée localement à une présentation :
```java
// Instancie la classe Presentation
Presentation pres = new Presentation("pres.pptx");
try {
    // Charge la vidéo
    FileInputStream fileStream = new FileInputStream("Wildlife.mp4");
    
    IVideo video = pres.getVideos().addVideo(fileStream, LoadingStreamBehavior.KeepLocked);

    // Obtient la première diapositive et ajoute un cadre vidéo
    pres.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 150, 250, video);

    // Enregistre la présentation sur le disque
    pres.save("pres-with-video.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


Alternativement, vous pouvez ajouter une vidéo en transmettant directement son chemin de fichier à la méthode [addVideoFrame(float x, float y, float width, float height, IVideo video)](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-com.aspose.slides.IVideo-) :
``` java
Presentation pres = new Presentation();
try {
	ISlide sld = pres.getSlides().get_Item(0);
	IVideoFrame vf = sld.getShapes().addVideoFrame(50, 150, 300, 150, "video1.avi");
} finally {
	if (pres != null) pres.dispose();
}
```



## **Créer des cadres vidéo avec des vidéos provenant de sources Web**

Microsoft [PowerPoint 2013 et versions ultérieures](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) prend en charge les vidéos YouTube dans les présentations. Si la vidéo que vous souhaitez utiliser est disponible en ligne (par exemple sur YouTube), vous pouvez l’ajouter à votre présentation via son lien Web. 

1. Créez une instance de la classe [Presentation ](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)class
1. Obtenez la référence d’une diapositive via son index. 
1. Ajoutez un objet [IVideo](https://reference.aspose.com/slides/java/com.aspose.slides/ivideo/) et transmettez le lien vers la vidéo.
1. Définissez une miniature pour le cadre vidéo. 
1. Enregistrez la présentation. 

Ce code Java vous montre comment ajouter une vidéo depuis le Web à une diapositive d’une présentation PowerPoint :
```java
// Instancie un objet Presentation qui représente un fichier de présentation 
Presentation pres = new Presentation();
try {
    addVideoFromYouTube(pres, "Tj75Arhq5ho");
    pres.save("out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

```java
private static void addVideoFromYouTube(Presentation pres, String videoID)
{
    // Ajoute un cadre vidéo
    IVideoFrame videoFrame = pres.getSlides().get_Item(0).getShapes().addVideoFrame(
            10, 10, 427, 240, "https://www.youtube.com/embed/" + videoID);
    videoFrame.setPlayMode(VideoPlayModePreset.Auto);

    // Charge la miniature
    String thumbnailUri = "http://img.youtube.com/vi/" + videoID + "/hqdefault.jpg";
    URL url;

    try {
        url = new URL(thumbnailUri);
        videoFrame.getPictureFormat().getPicture().setImage(pres.getImages().addImage(url.openStream()));
    } catch (MalformedURLException e) {
        e.printStackTrace();
    } catch (IOException e) {
        e.printStackTrace();
    }
}
```


## **Extraire la vidéo des diapositives**

En plus d’ajouter des vidéos aux diapositives, Aspose.Slides vous permet d’extraire les vidéos incorporées dans les présentations.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) pour charger la présentation contenant la vidéo. 
2. Parcourez tous les objets [ISlide](https://reference.aspose.com/slides/java/com.aspose.slides/islide/).
3. Parcourez tous les objets [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) afin de trouver un [VideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/). 
4. Enregistrez la vidéo sur le disque.

Ce code Java vous montre comment extraire la vidéo d’une diapositive de présentation :
```java
// Instancie un objet Presentation qui représente un fichier de présentation 
Presentation pres = new Presentation("VideoSample.pptx");
try {
    for (ISlide slide : pres.getSlides()) 
    {
        for (IShape shape : slide.getShapes()) 
        {
            if (shape instanceof VideoFrame) 
            {
                IVideoFrame vf = (IVideoFrame) shape;
                String type = vf.getEmbeddedVideo().getContentType();
                int ss = type.lastIndexOf('-');
                byte[] buffer = vf.getEmbeddedVideo().getBinaryData();

                //Obtient l'extension du fichier
                int charIndex = type.indexOf("/");
                type = type.substring(charIndex + 1);

                FileOutputStream fop = new FileOutputStream("testing2." + type);
                fop.write(buffer);
                fop.flush();
                fop.close();
            }
        }
    }
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**Quels paramètres de lecture vidéo peuvent être modifiés pour un VideoFrame ?**

Vous pouvez contrôler le [mode de lecture](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayMode-int-) (auto ou au clic) et la [boucle](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-). Ces options sont disponibles via les propriétés de l’objet [VideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/).

**L’ajout d’une vidéo affecte-t-il la taille du fichier PPTX ?**

Oui. Lorsque vous intégrez une vidéo locale, les données binaires sont incluses dans le document, ce qui fait que la taille de la présentation augmente proportionnellement à la taille du fichier. Lorsque vous ajoutez une vidéo en ligne, un lien et une miniature sont incorporés, de sorte que l’augmentation de taille est moindre.

**Puis-je remplacer la vidéo dans un VideoFrame existant sans changer sa position et sa taille ?**

Oui. Vous pouvez échanger le [contenu vidéo](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setEmbeddedVideo-com.aspose.slides.IVideo-) à l’intérieur du cadre tout en préservant la géométrie de la forme ; c’est un scénario courant pour mettre à jour les médias dans une disposition existante.

**Peut-on déterminer le type de contenu (MIME) d’une vidéo incorporée ?**

Oui. Une vidéo incorporée possède un [type de contenu](https://reference.aspose.com/slides/java/com.aspose.slides/video/#getContentType--) que vous pouvez lire et utiliser, par exemple lors de l’enregistrement sur le disque.