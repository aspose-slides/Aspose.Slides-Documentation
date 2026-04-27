---
title: Gérer les trames vidéo dans les présentations sur Android
linktitle: Trame vidéo
type: docs
weight: 10
url: /fr/androidjava/video-frame/
keywords:
- ajouter une vidéo
- créer une vidéo
- intégrer une vidéo
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
description: "Apprenez à ajouter et extraire programmatique des trames vidéo dans les diapositives PowerPoint et OpenDocument en utilisant Aspose.Slides pour Android via Java. Guide pratique rapide."
---
Une vidéo bien placée dans une présentation peut rendre votre message plus percutant et augmenter le niveau d'engagement de votre audience. 

PowerPoint vous permet d'ajouter des vidéos à une diapositive d'une présentation de deux manières :

* Ajouter ou incorporer une vidéo locale (stockée sur votre machine)
* Ajouter une vidéo en ligne (provenant d’une source web telle que YouTube).

Pour vous permettre d’ajouter des vidéos (objets vidéo) à une présentation, Aspose.Slides fournit l’interface [IVideo](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ivideo/), l’interface [IVideoFrame](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ivideoframe/) et d’autres types pertinents.

## **Créer une trame vidéo incorporée**

Si le fichier vidéo que vous souhaitez ajouter à votre diapositive est stocké localement, vous pouvez créer une trame vidéo pour incorporer la vidéo dans votre présentation. 

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/Presentation).
1. Obtenez la référence d’une diapositive par son indice. 
1. Ajoutez un objet [IVideo](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ivideo/) et transmettez le chemin du fichier vidéo pour incorporer la vidéo à la présentation.
1. Ajoutez un objet [IVideoFrame](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ivideoframe/) pour créer une trame pour la vidéo.
1. Enregistrez la présentation modifiée. 

Ce code Java montre comment ajouter une vidéo stockée localement à une présentation :

```java
// Instancie la classe Presentation
Presentation pres = new Presentation("pres.pptx");
try {
    // Charge la vidéo
    FileInputStream fileStream = new FileInputStream("Wildlife.mp4");
    
    IVideo video = pres.getVideos().addVideo(fileStream, LoadingStreamBehavior.KeepLocked);

    // Récupère la première diapositive et ajoute une trame vidéo
    pres.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 150, 250, video);

    // Enregistre la présentation sur le disque
    pres.save("pres-with-video.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

Vous pouvez également ajouter une vidéo en passant directement son chemin de fichier à la méthode [addVideoFrame(float x, float y, float width, float height, IVideo video)](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-com.aspose.slides.IVideo-) :

``` java
Presentation pres = new Presentation();
try {
	ISlide sld = pres.getSlides().get_Item(0);
	IVideoFrame vf = sld.getShapes().addVideoFrame(50, 150, 300, 150, "video1.avi");
} finally {
	if (pres != null) pres.dispose();
}
```

## **Créer une trame vidéo avec une vidéo provenant d’une source Web**

Microsoft [PowerPoint 2013 et versions ultérieures](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) prend en charge les vidéos YouTube dans les présentations. Si la vidéo que vous souhaitez utiliser est disponible en ligne (par ex. sur YouTube), vous pouvez l’ajouter à votre présentation via son lien web. 

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/Presentation).
1. Obtenez la référence d’une diapositive par son indice. 
1. Ajoutez un objet [IVideo](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ivideo/) et transmettez le lien vers la vidéo.
1. Définissez une vignette pour la trame vidéo. 
1. Enregistrez la présentation. 

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

## **Gérer les sous‑titres vidéo**

Aspose.Slides vous permet de gérer les sous‑titres fermés pour les trames vidéo dans les présentations PowerPoint. Les sous‑titres sont stockés au format WebVTT et sont exposés via la méthode [IVideoFrame.getCaptionTracks](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--) .

**Ajouter des sous‑titres à une trame vidéo**

Pour ajouter des sous‑titres à une trame vidéo :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentation/) .
1. Ajoutez une vidéo à la présentation.
1. Ajoutez un objet [IVideoFrame](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ivideoframe/) à une diapositive.
1. Utilisez l’interface [ICaptionsCollection](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/icaptionscollection/) retournée par [getCaptionTracks](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--) pour ajouter une piste de sous‑titre WebVTT.
1. Enregistrez la présentation modifiée.

Le code suivant montre comment ajouter des sous‑titres à une trame vidéo :

```java
Presentation presentation = new Presentation();
try {
    byte[] videoData = // "video.mp4";
    IVideo video = presentation.getVideos().addVideo(videoData);

    ISlide slide = presentation.getSlides().get_Item(0);
    IVideoFrame videoFrame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video);

    // Ajoute une nouvelle piste de sous‑titres à partir d'un fichier WebVTT.
    videoFrame.getCaptionTracks().add("English", "track.vtt");

    presentation.save("video_with_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

L’interface [ICaptionsCollection](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/icaptionscollection/) propose également une surcharge qui vous permet d’ajouter des sous‑titres depuis un flux.

**Extraire les sous‑titres d’une trame vidéo**

Pour extraire les sous‑titres d’une trame vidéo :

1. Chargez la présentation contenant la vidéo.
1. Trouvez l’objet cible [IVideoFrame](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ivideoframe/).
1. Parcourez les pistes de sous‑titres retournées par [getCaptionTracks](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--).
1. Enregistrez chaque piste de sous‑titre dans un fichier `.vtt`.

Le code suivant montre comment extraire les sous‑titres d’une trame vidéo :

```java
Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame) shape;
            for (ICaptions captionTrack : videoFrame.getCaptionTracks()) {
                // Enregistre la piste de sous‑titres dans un fichier WebVTT.
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

1. Chargez la présentation contenant la vidéo.
1. Obtenez l’objet cible [IVideoFrame](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ivideoframe/).
1. Supprimez les pistes de sous‑titres de la collection retournée par [getCaptionTracks](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--).
1. Enregistrez la présentation modifiée.

Le code suivant montre comment supprimer tous les sous‑titres d’une trame vidéo :

```java
Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IVideoFrame videoFrame = (IVideoFrame) slide.getShapes().get_Item(0);

    // Supprime tous les sous‑titres de la trame vidéo.
    videoFrame.getCaptionTracks().clear();

    presentation.save("video_without_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Si vous devez supprimer une seule piste de sous‑titre, utilisez les méthodes [remove](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/icaptionscollection/#remove-com.aspose.slides.ICaptions-) ou [removeAt](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/icaptionscollection/#removeAt-int-) au lieu de [clear](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/icaptionscollection/#clear--) .

## **Extraire la vidéo d’une diapositive**

En plus d’ajouter des vidéos aux diapositives, Aspose.Slides vous permet d’extraire les vidéos incorporées dans les présentations.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/Presentation) pour charger la présentation contenant la vidéo.
2. Parcourez tous les objets [ISlide](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/islide/).
3. Parcourez tous les objets [IShape](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ishape/) afin de trouver un [VideoFrame](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/videoframe/).
4. Enregistrez la vidéo sur le disque.

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

                // Obtient l'extension du fichier
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

Vous pouvez contrôler le [mode de lecture](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/videoframe/#setPlayMode-int-) (automatique ou sur clic) et le [bouclage](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-). Ces options sont disponibles via les propriétés de l’objet [VideoFrame](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/videoframe/) .

**L’ajout d’une vidéo affecte-t‑il la taille du fichier PPTX ?**

Oui. Lorsque vous incorporez une vidéo locale, les données binaires sont incluses dans le document, ce qui augmente la taille de la présentation proportionnellement à la taille du fichier. Lorsque vous ajoutez une vidéo en ligne, un lien et une vignette sont incorporés, ce qui entraîne une augmentation de taille moindre.

**Puis‑je remplacer la vidéo d’une VideoFrame existante sans changer sa position et sa taille ?**

Oui. Vous pouvez remplacer le [contenu vidéo](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/videoframe/#setEmbeddedVideo-com.aspose.slides.IVideo-) à l’intérieur de la trame tout en conservant la géométrie de la forme ; c’est un scénario fréquent pour mettre à jour les médias dans une mise en page existante.

**Peut‑on déterminer le type de contenu (MIME) d’une vidéo incorporée ?**

Oui. Une vidéo incorporée possède un [type de contenu](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/video/#getContentType--) que vous pouvez lire et utiliser, par exemple lors de son enregistrement sur le disque.