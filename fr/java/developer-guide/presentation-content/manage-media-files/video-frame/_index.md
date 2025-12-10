---
title: Gérer les cadres vidéo dans les présentations avec Java
linktitle: Cadre vidéo
type: docs
weight: 10
url: /fr/java/video-frame/
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
- Java
- Aspose.Slides
description: "Apprenez à ajouter et extraire programmatiquement des cadres vidéo dans les diapositives PowerPoint et OpenDocument en utilisant Aspose.Slides pour Java. Guide pratique rapide."
---

Une vidéo bien placée dans une présentation peut rendre votre message plus percutant et augmenter le niveau d'engagement de votre public. 

PowerPoint vous permet d'ajouter des vidéos à une diapositive d'une présentation de deux manières :

* Ajouter ou intégrer une vidéo locale (stockée sur votre ordinateur)
* Ajouter une vidéo en ligne (depuis une source web telle que YouTube).

Pour vous permettre d'ajouter des vidéos (objets vidéo) à une présentation, Aspose.Slides fournit l'interface [IVideo](https://reference.aspose.com/slides/java/com.aspose.slides/ivideo/) , l'interface [IVideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/) et d'autres types pertinents. 

## **Créer des cadres vidéo intégrés**

Si le fichier vidéo que vous souhaitez ajouter à votre diapositive est stocké localement, vous pouvez créer un cadre vidéo pour intégrer la vidéo dans votre présentation. 

1. Créer une instance de la classe [Presentation ](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. Obtenir la référence d'une diapositive via son indice. 
1. Ajouter un objet [IVideo](https://reference.aspose.com/slides/java/com.aspose.slides/ivideo/) et fournir le chemin du fichier vidéo pour l'intégrer à la présentation. 
1. Ajouter un objet [IVideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/) pour créer un cadre pour la vidéo.  
1. Enregistrer la présentation modifiée. 

Ce code Java montre comment ajouter une vidéo stockée localement à une présentation:
```java
// Instancie la classe Presentation
Presentation pres = new Presentation("pres.pptx");
try {
    // Charge la vidéo
    FileInputStream fileStream = new FileInputStream("Wildlife.mp4");
    
    IVideo video = pres.getVideos().addVideo(fileStream, LoadingStreamBehavior.KeepLocked);

    // Récupère la première diapositive et ajoute un cadre vidéo
    pres.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 150, 250, video);

    // Enregistre la présentation sur le disque
    pres.save("pres-with-video.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


Alternativement, vous pouvez ajouter une vidéo en passant directement son chemin de fichier à la méthode [addVideoFrame(float x, float y, float width, float height, IVideo video)](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-com.aspose.slides.IVideo-) :
``` java
Presentation pres = new Presentation();
try {
	ISlide sld = pres.getSlides().get_Item(0);
	IVideoFrame vf = sld.getShapes().addVideoFrame(50, 150, 300, 150, "video1.avi");
} finally {
	if (pres != null) pres.dispose();
}
```



## **Créer des cadres vidéo à partir de sources web**

Microsoft [PowerPoint 2013 and newer](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) supporte les vidéos YouTube dans les présentations. Si la vidéo que vous souhaitez utiliser est disponible en ligne (par ex. sur YouTube), vous pouvez l'ajouter à votre présentation via son lien web. 

1. Créer une instance de la classe [Presentation ](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)
1. Obtenir la référence d'une diapositive via son indice. 
1. Ajouter un objet [IVideo](https://reference.aspose.com/slides/java/com.aspose.slides/ivideo/) et fournir le lien vers la vidéo.
1. Définir une vignette pour le cadre vidéo. 
1. Enregistrer la présentation. 

Ce code Java montre comment ajouter une vidéo depuis le web à une diapositive d'une présentation PowerPoint:
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

    // Charge la vignette
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

Outre l'ajout de vidéos aux diapositives, Aspose.Slides vous permet d'extraire les vidéos intégrées aux présentations.

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) pour charger la présentation contenant la vidéo. 
2. Parcourir tous les objets [ISlide](https://reference.aspose.com/slides/java/com.aspose.slides/islide/). 
3. Parcourir tous les objets [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) pour trouver un [VideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/). 
4. Enregistrer la vidéo sur le disque.

Ce code Java montre comment extraire la vidéo d'une diapositive de présentation:
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

                //Obtient l'extension de fichier
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

Vous pouvez contrôler le [mode de lecture](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayMode-int-) (automatique ou au clic) et la [lecture en boucle](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-). Ces options sont disponibles via les propriétés de l'objet [VideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/).

**L'ajout d'une vidéo affecte-t-il la taille du fichier PPTX ?**

Oui. Lorsque vous intégrez une vidéo locale, les données binaires sont incluses dans le document, ce qui augmente la taille de la présentation proportionnellement à la taille du fichier. Lorsque vous ajoutez une vidéo en ligne, un lien et une vignette sont intégrés, ce qui entraîne une augmentation de taille moindre.

**Puis-je remplacer la vidéo dans un VideoFrame existant sans changer sa position et sa taille ?**

Oui. Vous pouvez remplacer le [contenu vidéo](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setEmbeddedVideo-com.aspose.slides.IVideo-) à l'intérieur du cadre tout en conservant la géométrie de la forme ; c'est un scénario courant pour mettre à jour les médias dans une mise en page existante.

**Le type de contenu (MIME) d'une vidéo intégrée peut-il être déterminé ?**

Oui. Une vidéo intégrée possède un [type de contenu](https://reference.aspose.com/slides/java/com.aspose.slides/video/#getContentType--) que vous pouvez lire et utiliser, par exemple lors de son enregistrement sur le disque.