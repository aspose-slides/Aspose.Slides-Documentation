---
title: Cadre Vidéo
type: docs
weight: 10
url: /fr/androidjava/video-frame/
keywords: "Ajouter vidéo, créer cadre vidéo, extraire vidéo, présentation PowerPoint, Java, Aspose.Slides pour Android via Java"
description: "Ajouter un cadre vidéo à une présentation PowerPoint en Java"
---

Un vidéo bien placée dans une présentation peut rendre votre message plus convaincant et augmenter les niveaux d'engagement de votre public.

PowerPoint vous permet d'ajouter des vidéos à une diapositive dans une présentation de deux manières :

* Ajouter ou intégrer une vidéo locale (stockée sur votre machine)
* Ajouter une vidéo en ligne (d'une source web comme YouTube).

Pour vous permettre d'ajouter des vidéos (objets vidéo) à une présentation, Aspose.Slides fournit l'interface [IVideo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideo/), l'interface [IVideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/) et d'autres types pertinents.

## **Créer un Cadre Vidéo Intégré**

Si le fichier vidéo que vous souhaitez ajouter à votre diapositive est stocké localement, vous pouvez créer un cadre vidéo pour intégrer la vidéo dans votre présentation.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. Obtenez la référence d'une diapositive via son index.
1. Ajoutez un objet [IVideo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideo/) et passez le chemin du fichier vidéo pour intégrer la vidéo avec la présentation.
1. Ajoutez un objet [IVideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/) pour créer un cadre pour la vidéo.
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

Alternativement, vous pouvez ajouter une vidéo en passant directement son chemin de fichier au méthode [addVideoFrame(float x, float y, float width, float height, IVideo video)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-com.aspose.slides.IVideo-) :

``` java
Presentation pres = new Presentation();
try {
	ISlide sld = pres.getSlides().get_Item(0);
	IVideoFrame vf = sld.getShapes().addVideoFrame(50, 150, 300, 150, "video1.avi");
} finally {
	if (pres != null) pres.dispose();
}
```


## **Créer un Cadre Vidéo avec une Vidéo d'une Source Web**

Microsoft [PowerPoint 2013 et versions ultérieures](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) prend en charge les vidéos YouTube dans les présentations. Si la vidéo que vous souhaitez utiliser est disponible en ligne (par exemple sur YouTube), vous pouvez l'ajouter à votre présentation via son lien web.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. Obtenez la référence d'une diapositive via son index.
1. Ajoutez un objet [IVideo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideo/) et passez le lien vers la vidéo.
1. Définissez une miniature pour le cadre vidéo.
1. Enregistrez la présentation.

Ce code Java vous montre comment ajouter une vidéo du web à une diapositive dans une présentation PowerPoint :

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

## **Extraire une Vidéo d'une Diapositive**

En plus d'ajouter des vidéos aux diapositives, Aspose.Slides vous permet d'extraire des vidéos intégrées dans des présentations.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) pour charger la présentation contenant la vidéo.
2. Parcourez tous les objets [ISlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/) .
3. Parcourez tous les objets [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) pour trouver un [VideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/) .
4. Enregistrez la vidéo sur le disque.

Ce code Java vous montre comment extraire la vidéo d'une diapositive de présentation :

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