---
title: "Gérer les cadres vidéo dans les présentations avec Java"
linktitle: "Cadre vidéo"
type: docs
weight: 10
url: /fr/java/video-frame/
keywords:
- "ajouter une vidéo"
- "créer une vidéo"
- "intégrer une vidéo"
- "extraire une vidéo"
- "récupérer une vidéo"
- "cadre vidéo"
- "source Web"
- "PowerPoint"
- "OpenDocument"
- "présentation"
- "Java"
- "Aspose.Slides"
description: "Apprenez à ajouter et extraire programmaticalement des cadres vidéo dans les diapositives PowerPoint et OpenDocument en utilisant Aspose.Slides pour Java. Guide pratique rapide."
---
## **Introduction**

Une vidéo bien placée dans une présentation peut rendre votre message plus percutant et augmenter le niveau d'engagement de votre public.

PowerPoint vous permet d'ajouter des vidéos à une diapositive d'une présentation de deux manières :
* Ajouter ou incorporer une vidéo locale (stockée sur votre machine)
* Ajouter une vidéo en ligne (provenant d'une source Web telle que YouTube).

Pour vous permettre d’ajouter des vidéos (objets vidéo) à une présentation, Aspose.Slides fournit l’interface [IVideo](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ivideo/), l’interface [IVideoFrame](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ivideoframe/) et d’autres types pertinents.

## **Créer des cadres vidéo incorporés**

Si le fichier vidéo que vous souhaitez ajouter à votre diapositive est stocké localement, vous pouvez créer un cadre vidéo pour incorporer la vidéo dans votre présentation.

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/Presentation).
2. Obtenez la référence d’une diapositive via son indice.
3. Ajoutez un objet [IVideo](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ivideo/) et transmettez le chemin du fichier vidéo pour incorporer la vidéo à la présentation.
4. Ajoutez un objet [IVideoFrame](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ivideoframe/) pour créer un cadre pour la vidéo.
5. Enregistrez la présentation modifiée.

Ce code Java montre comment ajouter une vidéo stockée localement à une présentation :

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

Sinon, vous pouvez ajouter une vidéo en transmettant directement son chemin de fichier à la méthode [addVideoFrame(float x, float y, float width, float height, IVideo video)](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-com.aspose.slides.IVideo-) :

``` java
Presentation pres = new Presentation();
try {
	ISlide sld = pres.getSlides().get_Item(0);
	IVideoFrame vf = sld.getShapes().addVideoFrame(50, 150, 300, 150, "video1.avi");
} finally {
	if (pres != null) pres.dispose();
}
```

## **Créer des cadres vidéo avec une vidéo provenant de sources Web**

Microsoft [PowerPoint 2013 et versions ultérieures](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) prend en charge les vidéos YouTube dans les présentations. Si la vidéo que vous souhaitez utiliser est disponible en ligne (par exemple sur YouTube), vous pouvez l’ajouter à votre présentation via son lien Web.

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/Presentation).
2. Obtenez la référence d’une diapositive via son indice.
3. Ajoutez un objet [IVideo](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ivideo/) et transmettez le lien vers la vidéo.
4. Définissez une miniature pour le cadre vidéo.
5. Enregistrez la présentation.

Ce code Java montre comment ajouter une vidéo depuis le Web à une diapositive d’une présentation PowerPoint :

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

## **Rogner un cadre vidéo**

Aspose.Slides vous permet de contrôler quelle partie d’une vidéo est lue en définissant les valeurs trim-from-start et trim-from-end via [IVideoFrame.setTrimFromStart](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ivideoframe/#setTrimFromStart-float-) et [IVideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ivideoframe/#setTrimFromEnd-float-). Les deux valeurs sont indiquées en millisecondes et définissent le temps à ignorer au début et à la fin de la vidéo, respectivement. Ces paramètres modifient les paramètres de lecture de la vidéo dans la présentation ; ils ne découpent pas et ne modifient pas les données binaires de la vidéo incorporée.

**Définir les paramètres de rognage**

Pour créer un cadre vidéo et définir ses paramètres de rognage :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation/).
2. Ajouter un objet [IVideo](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ivideo/) à la présentation.
3. Ajouter un objet [IVideoFrame](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ivideoframe/) à une diapositive.
4. Définir les valeurs trim-from-start et trim-from-end via [IVideoFrame.setTrimFromStart](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ivideoframe/#setTrimFromStart-float-) et [IVideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ivideoframe/#setTrimFromEnd-float-).
5. Enregistrez la présentation modifiée.

L’exemple de code suivant saute les 2,5 premières secondes et la dernière seconde d’une vidéo incorporée lors de la lecture :

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

Pour examiner les paramètres de rognage existants, chargez une présentation, trouvez un objet [IVideoFrame](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ivideoframe/) parmi les formes de la première diapositive, et lisez les valeurs via [IVideoFrame.getTrimFromStart](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ivideoframe/#getTrimFromStart--) et [IVideoFrame.getTrimFromEnd](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ivideoframe/#getTrimFromEnd--).

L’exemple de code suivant trouve le premier cadre vidéo de la première diapositive et indique ses paramètres de rognage en millisecondes :

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

Aspose.Slides vous permet de gérer les sous‑titres fermés pour les cadres vidéo dans les présentations PowerPoint. Les sous‑titres sont stockés au format WebVTT et sont accessibles via la méthode [IVideoFrame.getCaptionTracks](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ivideoframe/#getCaptionTracks--).

**Ajouter des sous‑titres à un cadre vidéo**

Pour ajouter des sous‑titres à un cadre vidéo :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation/).
2. Ajouter une vidéo à la présentation.
3. Ajouter un objet [IVideoFrame](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ivideoframe/) à une diapositive.
4. Utilisez la [ICaptionsCollection](https://reference.aspose.com/slides/fr/java/com.aspose.slides/icaptionscollection/) renvoyée par [getCaptionTracks](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ivideoframe/#getCaptionTracks--) pour ajouter une piste de sous‑titre WebVTT.
5. Enregistrez la présentation modifiée.

Le code suivant montre comment ajouter des sous‑titres à un cadre vidéo :

```java
Presentation presentation = new Presentation();
try {
    byte[] videoData = Files.readAllBytes(Paths.get("video.mp4"));
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

L’interface [ICaptionsCollection](https://reference.aspose.com/slides/fr/java/com.aspose.slides/icaptionscollection/) propose également une surcharge qui vous permet d’ajouter des sous‑titres depuis un flux.

**Extraire les sous‑titres d’un cadre vidéo**

Pour extraire les sous‑titres d’un cadre vidéo :

1. Charger la présentation contenant la vidéo.
2. Trouver l’objet [IVideoFrame](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ivideoframe/) cible.
3. Parcourir les pistes de sous‑titres dans la [ICaptionsCollection](https://reference.aspose.com/slides/fr/java/com.aspose.slides/icaptionscollection/).
4. Enregistrer chaque piste de sous‑titre dans un fichier `.vtt`.

Le code suivant montre comment extraire les sous‑titres d’un cadre vidéo :

```java
Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame)shape;
            for (ICaptions captionTrack : videoFrame.getCaptionTracks()) {
                // Enregistre la piste de sous-titres dans un fichier WebVTT.
                String filePath = captionTrack.getCaptionId().toString() + ".vtt";
                Files.write(Paths.get(filePath), captionTrack.getBinaryData());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Chaque objet [ICaptions](https://reference.aspose.com/slides/fr/java/com.aspose.slides/icaptions/) expose l’identifiant du sous‑titre, le libellé, les données binaires et le texte du sous‑titre sous forme de chaîne UTF‑8.

**Supprimer les sous‑titres d’un cadre vidéo**

Pour supprimer les sous‑titres d’un cadre vidéo :

1. Charger la présentation contenant la vidéo.
2. Obtenir l’objet [IVideoFrame](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ivideoframe/) cible.
3. Supprimer les pistes de sous‑titres de la [ICaptionsCollection](https://reference.aspose.com/slides/fr/java/com.aspose.slides/icaptionscollection/).
4. Enregistrez la présentation modifiée.

Le code suivant montre comment supprimer tous les sous‑titres d’un cadre vidéo :

```java
Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IVideoFrame videoFrame = (IVideoFrame)slide.getShapes().get_Item(0);

    // Supprime tous les sous-titres du cadre vidéo.
    videoFrame.getCaptionTracks().clear();

    presentation.save("video_without_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Si vous devez supprimer uniquement une piste de sous‑titre, utilisez les méthodes [remove](https://reference.aspose.com/slides/fr/java/com.aspose.slides/icaptionscollection/#remove-com.aspose.slides.ICaptions-) ou [removeAt](https://reference.aspose.com/slides/fr/java/com.aspose.slides/icaptionscollection/#removeAt-int-) au lieu de [clear](https://reference.aspose.com/slides/fr/java/com.aspose.slides/icaptionscollection/#clear--).

## **Extraire la vidéo des diapositives**

Outre l’ajout de vidéos aux diapositives, Aspose.Slides vous permet d’extraire les vidéos incorporées dans les présentations.

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/Presentation) pour charger la présentation contenant la vidéo.
2. Parcourir tous les objets [ISlide](https://reference.aspose.com/slides/fr/java/com.aspose.slides/islide/).
3. Parcourir tous les objets [IShape](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ishape/) pour trouver un [VideoFrame](https://reference.aspose.com/slides/fr/java/com.aspose.slides/videoframe/).
4. Enregistrer la vidéo sur le disque.

Ce code Java montre comment extraire la vidéo d’une diapositive d’une présentation :

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

                // Obtient l'extension de fichier
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

Vous pouvez contrôler le [mode de lecture](https://reference.aspose.com/slides/fr/java/com.aspose.slides/videoframe/#setPlayMode-int-) (auto ou au clic) et la [boucle](https://reference.aspose.com/slides/fr/java/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-). Ces options sont disponibles via les propriétés de l’objet [VideoFrame](https://reference.aspose.com/slides/fr/java/com.aspose.slides/videoframe/).

**L’ajout d’une vidéo affecte‑t‑il la taille du fichier PPTX ?**

Oui. Lorsque vous incorporez une vidéo locale, les données binaires sont incluses dans le document, ce qui augmente proportionnellement la taille de la présentation. Lorsque vous ajoutez une vidéo en ligne, un lien et une miniature sont incorporés, de sorte que l’augmentation de taille est moindre.

**Puis‑je remplacer la vidéo d’un VideoFrame existant sans changer sa position et sa taille ?**

Oui. Vous pouvez échanger le [contenu vidéo](https://reference.aspose.com/slides/fr/java/com.aspose.slides/videoframe/#setEmbeddedVideo-com.aspose.slides.IVideo-) à l’intérieur du cadre tout en conservant la géométrie de la forme ; c’est un scénario courant pour mettre à jour les médias dans une disposition existante.

**Le type de contenu (MIME) d’une vidéo incorporée peut‑il être déterminé ?**

Oui. Une vidéo incorporée possède un [type de contenu](https://reference.aspose.com/slides/fr/java/com.aspose.slides/video/#getContentType--) que vous pouvez lire et utiliser, par exemple lors de son enregistrement sur le disque.