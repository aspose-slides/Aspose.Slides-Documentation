---
title: Gérer les trames vidéo dans les présentations sur Android
linktitle: Trame vidéo
type: docs
weight: 10
url: /fr/androidjava/video-frame/
keywords:
- ajouter une vidéo
- créer une vidéo
- incorporer une vidéo
- extraire une vidéo
- récupérer une vidéo
- trame vidéo
- source web
- PowerPoint
- OpenDocument
- présentation
- Android
- Java
- Aspose.Slides
description: "Apprenez à ajouter et extraire programmétiquement des trames vidéo dans les diapositives PowerPoint et OpenDocument à l'aide d'Aspose.Slides pour Android via Java. Guide pratique rapide."
---
## **Introduction**

Une vidéo bien placée dans une présentation peut rendre votre message plus percutant et augmenter le niveau d’engagement de votre audience.  

PowerPoint vous permet d’ajouter des vidéos à une diapositive d’une présentation de deux manières :

* Ajouter ou incorporer une vidéo locale (stockée sur votre machine)
* Ajouter une vidéo en ligne (provenant d’une source Web telle que YouTube).

Pour vous permettre d’ajouter des vidéos (objets vidéo) à une présentation, Aspose.Slides fournit l’interface [IVideo](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ivideo/) , l’interface [IVideoFrame](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ivideoframe/) et d’autres types pertinents.

## **Créer une trame vidéo intégrée**

Si le fichier vidéo que vous souhaitez ajouter à votre diapositive est stocké localement, vous pouvez créer une trame vidéo pour incorporer la vidéo dans votre présentation.  

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/Presentation) .
1. Obtenir la référence d’une diapositive via son indice. 
1. Ajouter un objet [IVideo](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ivideo/) et fournir le chemin du fichier vidéo pour incorporer la vidéo à la présentation. 
1. Ajouter un objet [IVideoFrame](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ivideoframe/) pour créer une trame pour la vidéo. 
1. Enregistrer la présentation modifiée. 

Ce code Java montre comment ajouter une vidéo stockée localement à une présentation :

```java
// Instancie la classe Presentation
Presentation pres = new Presentation("pres.pptx");
try {
    // Charge la vidéo
    FileInputStream fileStream = new FileInputStream("Wildlife.mp4");
    
    IVideo video = pres.getVideos().addVideo(fileStream, LoadingStreamBehavior.KeepLocked);

    // Obtient la première diapositive et ajoute une trame vidéo
    pres.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 150, 250, video);

    // Enregistre la présentation sur le disque
    pres.save("pres-with-video.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

Alternativement, vous pouvez ajouter une vidéo en transmettant directement son chemin de fichier à la méthode [addVideoFrame(float x, float y, float width, float height, IVideo video)](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-com.aspose.slides.IVideo-) :

``` java
Presentation pres = new Presentation();
try {
	ISlide sld = pres.getSlides().get_Item(0);
	IVideoFrame vf = sld.getShapes().addVideoFrame(50, 150, 300, 150, "video1.avi");
} finally {
	if (pres != null) pres.dispose();
}
```

## **Créer une trame vidéo à partir d’une source Web**

Les versions récentes de Microsoft PowerPoint prennent en charge les vidéos en ligne dans les présentations. Si la vidéo que vous souhaitez utiliser est disponible en ligne (par ex. sur YouTube), vous pouvez l’ajouter à votre présentation via son lien web.  

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/Presentation) 
1. Obtenir la référence d’une diapositive via son indice. 
1. Ajouter un objet [IVideo](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ivideo/) et fournir le lien vers la vidéo. 
1. Définir une vignette pour la trame vidéo. 
1. Enregistrer la présentation. 

Ce code Java montre comment ajouter une vidéo depuis le web à une diapositive d’une présentation PowerPoint :

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
    // Ajoute une trame vidéo
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

## **Rogner une trame vidéo**

Aspose.Slides vous permet de contrôler quelle partie d’une vidéo est lue en définissant les valeurs trim‑from‑start et trim‑from‑end via [IVideoFrame.setTrimFromStart](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ivideoframe/#setTrimFromStart-float-) et [IVideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ivideoframe/#setTrimFromEnd-float-). Les deux valeurs sont exprimées en millisecondes et définissent le temps à ignorer au début et à la fin de la vidéo, respectivement. Ces réglages modifient les paramètres de lecture de la vidéo dans la présentation ; ils ne coupent ni ne modifient les données binaires de la vidéo incorporée.

**Définir les paramètres de rognage**

Pour créer une trame vidéo et définir ses paramètres de rognage :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentation/) . 
1. Ajouter un objet [IVideo](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ivideo/) à la présentation. 
1. Ajouter un objet [IVideoFrame](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ivideoframe/) à une diapositive. 
1. Définir les valeurs trim‑from‑start et trim‑from‑end via [IVideoFrame.setTrimFromStart](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ivideoframe/#setTrimFromStart-float-) et [IVideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ivideoframe/#setTrimFromEnd-float-). 
1. Enregistrer la présentation modifiée. 

L’exemple de code suivant ignore les 2,5 secondes initiales et la dernière seconde d’une vidéo incorporée pendant la lecture :

```java
Presentation presentation = new Presentation();
try {
    FileInputStream videoStream = new FileInputStream("video.mp4");
    try {
        IVideo video = presentation.getVideos().addVideo(
                videoStream, LoadingStreamBehavior.ReadStreamAndRelease);
        ISlide slide = presentation.getSlides().get_Item(0);
        IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 640, 360, video);

        videoFrame.setTrimFromStart(2500f);
        videoFrame.setTrimFromEnd(1000f);

        presentation.save("video_with_trim.pptx", SaveFormat.Pptx);
    } finally {
        videoStream.close();
    }
} finally {
    presentation.dispose();
}
```

**Lire les paramètres de rognage**

Pour examiner les paramètres de rognage existants, chargez une présentation, trouvez un objet [IVideoFrame](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ivideoframe/) parmi les formes de la première diapositive, et lisez les valeurs via [IVideoFrame.getTrimFromStart](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ivideoframe/#getTrimFromStart--) et [IVideoFrame.getTrimFromEnd](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ivideoframe/#getTrimFromEnd--). 

L’exemple de code suivant trouve la première trame vidéo de la première diapositive et rapporte ses paramètres de rognage en millisecondes :

```java
Presentation presentation = new Presentation("video_with_trim.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame) shape;
            float trimFromStart = videoFrame.getTrimFromStart();
            float trimFromEnd = videoFrame.getTrimFromEnd();

            System.out.println("Trim from start: " + trimFromStart + " ms");
            System.out.println("Trim from end: " + trimFromEnd + " ms");
            break;
        }
    }
} finally {
    presentation.dispose();
}
```

## **Gérer les sous‑titres vidéo**

Aspose.Slides vous permet de gérer les sous‑titres fermés pour les trames vidéo dans les présentations PowerPoint. Les sous‑titres sont stockés au format WebVTT et sont exposés via la méthode [IVideoFrame.getCaptionTracks](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--). 

**Ajouter des sous‑titres à une trame vidéo**

Pour ajouter des sous‑titres à une trame vidéo :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentation/) .
1. Ajouter une vidéo à la présentation. 
1. Ajouter un objet [IVideoFrame](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ivideoframe/) à une diapositive. 
1. Utiliser l’[ICaptionsCollection](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/icaptionscollection/) retourné par [getCaptionTracks](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--) pour ajouter une piste de sous‑titres WebVTT. 
1. Enregistrer la présentation modifiée. 

Le code suivant montre comment ajouter des sous‑titres à une trame vidéo :

```java
Presentation presentation = new Presentation();
try {
    byte[] videoData = // "video.mp4";
    IVideo video = presentation.getVideos().addVideo(videoData);

    ISlide slide = presentation.getSlides().get_Item(0);
    IVideoFrame videoFrame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video);

    // Ajoute une nouvelle piste de sous-titres à partir d'un fichier WebVTT.
    videoFrame.getCaptionTracks().add("English", "track.vtt");

    presentation.save("video_with_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

L’interface [ICaptionsCollection](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/icaptionscollection/) fournit également une surcharge qui permet d’ajouter des sous‑titres depuis un flux. 

**Extraire les sous‑titres d’une trame vidéo**

Pour extraire les sous‑titres d’une trame vidéo :

1. Charger la présentation contenant la vidéo. 
1. Trouver l’objet [IVideoFrame](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ivideoframe/) cible. 
1. Parcourir les pistes de sous‑titres retournées par [getCaptionTracks](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--). 
1. Enregistrer chaque piste de sous‑titres dans un fichier `.vtt`. 

Le code suivant montre comment extraire les sous‑titres d’une trame vidéo :

```java
Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame) shape;
            for (ICaptions captionTrack : videoFrame.getCaptionTracks()) {
                // Enregistre la piste de sous-titres dans un fichier WebVTT.
                FileOutputStream outputStream = new FileOutputStream(captionTrack.getCaptionId() + ".vtt");
                outputStream.write(captionTrack.getBinaryData());
                outputStream.close();
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Chaque objet [ICaptions](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/icaptions/) expose l’identifiant du sous‑titre, le libellé, les données binaires et les données du sous‑titre sous forme de chaîne UTF‑8. 

**Supprimer les sous‑titres d’une trame vidéo**

Pour supprimer les sous‑titres d’une trame vidéo :

1. Charger la présentation contenant la vidéo. 
1. Obtenir l’objet [IVideoFrame](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ivideoframe/) cible. 
1. Supprimer les pistes de sous‑titres de la collection retournée par [getCaptionTracks](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--). 
1. Enregistrer la présentation modifiée. 

Le code suivant montre comment supprimer tous les sous‑titres d’une trame vidéo :

```java
Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IVideoFrame videoFrame = (IVideoFrame) slide.getShapes().get_Item(0);

    // Supprime tous les sous-titres de la trame vidéo.
    videoFrame.getCaptionTracks().clear();

    presentation.save("video_without_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Si vous devez supprimer une seule piste de sous‑titres, utilisez les méthodes [remove](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/icaptionscollection/#remove-com.aspose.slides.ICaptions-) ou [removeAt](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/icaptionscollection/#removeAt-int-) au lieu de [clear](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/icaptionscollection/#clear--). 

## **Extraire la vidéo d’une diapositive**

En plus d’ajouter des vidéos aux diapositives, Aspose.Slides vous permet d’extraire les vidéos incorporées dans les présentations.  

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/Presentation) pour charger la présentation contenant la vidéo. 
2. Parcourir tous les objets [ISlide](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/islide/). 
3. Parcourir tous les objets [IShape](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ishape/) pour trouver un [VideoFrame](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/videoframe/). 
4. Enregistrer la vidéo sur le disque. 

Ce code Java montre comment extraire la vidéo d’une diapositive de présentation :

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

**Quels paramètres de lecture vidéo peuvent être modifiés pour une VideoFrame ?**

Vous pouvez contrôler le mode de lecture (automatique ou au clic) et la lecture en boucle. Ces options sont accessibles via les propriétés de l’objet VideoFrame.  

**L’ajout d’une vidéo affecte-t-il la taille du fichier PPTX ?**

Oui. Lorsque vous incorporez une vidéo locale, les données binaires sont incluses dans le document, ce qui augmente la taille de la présentation proportionnellement à la taille du fichier. Lorsque vous ajoutez une vidéo en ligne, seul un lien et une vignette sont incorporés, ce qui entraîne une augmentation de taille moindre.  

**Puis-je remplacer la vidéo d’une VideoFrame existante sans modifier sa position et sa taille ?**

Oui. Vous pouvez remplacer le contenu vidéo de la trame tout en préservant la géométrie de la forme ; c’est un scénario courant pour mettre à jour les médias dans une mise en page existante.  

**Le type de contenu (MIME) d’une vidéo incorporée peut-il être déterminé ?**

Oui. Une vidéo incorporée possède un type de contenu que vous pouvez lire et utiliser, par exemple lors de son enregistrement sur disque.