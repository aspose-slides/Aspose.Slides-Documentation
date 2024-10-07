---
title: Video Frame
type: docs
weight: 10
url: /androidjava/video-frame/
keywords: "Video hinzufügen, Video-Frame erstellen, Video extrahieren, PowerPoint-Präsentation, Java, Aspose.Slides für Android über Java"
description: "Video-Frame zur PowerPoint-Präsentation in Java hinzufügen"
---

Ein gut platzierter Video in einer Präsentation kann Ihre Botschaft überzeugender machen und das Engagement Ihres Publikums erhöhen.

PowerPoint ermöglicht es Ihnen, Videos auf einer Folie in einer Präsentation auf zwei Arten hinzuzufügen:

* Lokales Video hinzufügen oder einbetten (auf Ihrem Computer gespeichert)
* Online-Video hinzufügen (von einer Webquelle wie YouTube).

Um Ihnen zu ermöglichen, Videos (Videoobjekte) zu einer Präsentation hinzuzufügen, bietet Aspose.Slides das [IVideo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideo/) -Interface, das [IVideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/) -Interface und andere relevante Typen an.

## **Eingebetteten Video-Frame erstellen**

Wenn die Videodatei, die Sie zu Ihrer Folie hinzufügen möchten, lokal gespeichert ist, können Sie einen Video-Frame erstellen, um das Video in Ihrer Präsentation einzubetten.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) -Klasse.
1. Holen Sie sich die Referenz einer Folie über ihren Index.
1. Fügen Sie ein [IVideo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideo/) -Objekt hinzu und übergeben Sie den Dateipfad des Videos, um das Video mit der Präsentation einzubetten.
1. Fügen Sie ein [IVideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/) -Objekt hinzu, um einen Frame für das Video zu erstellen.
1. Speichern Sie die modifizierte Präsentation.

Dieser Java-Code zeigt Ihnen, wie Sie ein lokal gespeichertes Video zu einer Präsentation hinzufügen:

```java
// Instanziiert die Präsentationsklasse
Presentation pres = new Presentation("pres.pptx");
try {
    // Lädt das Video
    FileInputStream fileStream = new FileInputStream("Wildlife.mp4");

    IVideo video = pres.getVideos().addVideo(fileStream, LoadingStreamBehavior.KeepLocked);

    // Holt die erste Folie und fügt einen Video-Frame hinzu
    pres.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 150, 250, video);

    // Speichert die Präsentation auf der Festplatte
    pres.save("pres-with-video.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

Alternativ können Sie ein Video hinzufügen, indem Sie dessen Dateipfad direkt an die [addVideoFrame(float x, float y, float width, float height, IVideo video)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-com.aspose.slides.IVideo-) -Methode übergeben:

``` java
Presentation pres = new Presentation();
try {
    ISlide sld = pres.getSlides().get_Item(0);
    IVideoFrame vf = sld.getShapes().addVideoFrame(50, 150, 300, 150, "video1.avi");
} finally {
    if (pres != null) pres.dispose();
}
```

## **Video-Frame mit Video aus einer Webquelle erstellen**

Microsoft [PowerPoint 2013 und neuer](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) unterstützt YouTube-Videos in Präsentationen. Wenn das Video, das Sie verwenden möchten, online verfügbar ist (z.B. auf YouTube), können Sie es über seinen Weblink zu Ihrer Präsentation hinzufügen.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) -Klasse.
1. Holen Sie sich die Referenz einer Folie über ihren Index.
1. Fügen Sie ein [IVideo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideo/) -Objekt hinzu und übergeben Sie den Link zum Video.
1. Setzen Sie ein Thumbnail für den Video-Frame.
1. Speichern Sie die Präsentation.

Dieser Java-Code zeigt Ihnen, wie Sie ein Video aus dem Internet zu einer Folie in einer PowerPoint-Präsentation hinzufügen:

```java
// Instanziert ein Präsentationsobjekt, das eine Präsentationsdatei darstellt
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
    // Fügt einen Video-Frame hinzu
    IVideoFrame videoFrame = pres.getSlides().get_Item(0).getShapes().addVideoFrame(
            10, 10, 427, 240, "https://www.youtube.com/embed/" + videoID);
    videoFrame.setPlayMode(VideoPlayModePreset.Auto);

    // Lädt Thumbnail
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

## **Video aus einer Folie extrahieren**

Neben dem Hinzufügen von Videos zu Folien ermöglicht es Aspose.Slides, Videos aus Präsentationen zu extrahieren.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) -Klasse, um die Präsentation zu laden, die das Video enthält.
2. Iterieren Sie über alle [ISlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/) -Objekte.
3. Iterieren Sie über alle [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) -Objekte, um einen [VideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/) zu finden.
4. Speichern Sie das Video auf der Festplatte.

Dieser Java-Code zeigt Ihnen, wie Sie das Video auf einer Folie einer Präsentation extrahieren:

```java
// Instanziert ein Präsentationsobjekt, das eine Präsentationsdatei darstellt
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

                // Holt die Dateierweiterung
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