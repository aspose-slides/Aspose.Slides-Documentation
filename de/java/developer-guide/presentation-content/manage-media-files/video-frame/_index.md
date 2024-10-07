---
title: Video Frame
type: docs
weight: 10
url: /java/video-frame/
keywords: "Video hinzufügen, Video-Frame erstellen, Video extrahieren, PowerPoint-Präsentation, Java, Aspose.Slides für Java"
description: "Fügen Sie ein Video-Frame zu einer PowerPoint-Präsentation in Java hinzu"
---

Ein gut platziertes Video in einer Präsentation kann Ihre Botschaft überzeugender gestalten und die Engagement-Levels Ihres Publikums erhöhen.

PowerPoint ermöglicht es, Videos auf zwei Arten in eine Folie einzufügen:

* Fügen Sie ein lokales Video (auf Ihrem Computer gespeichert) hinzu oder betten Sie es ein
* Fügen Sie ein Online-Video (aus einer Webquelle wie YouTube) hinzu.

Um Ihnen das Hinzufügen von Videos (Videoobjekten) zu einer Präsentation zu ermöglichen, bietet Aspose.Slides das [IVideo](https://reference.aspose.com/slides/java/com.aspose.slides/ivideo/) Interface, das [IVideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/) Interface und andere relevante Typen.

## **Erstellen eines eingebetteten Video-Frames**

Wenn die Videodatei, die Sie zu Ihrer Folie hinzufügen möchten, lokal gespeichert ist, können Sie einen Video-Frame erstellen, um das Video in Ihrer Präsentation einzubetten.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) Klasse.
1. Holen Sie sich eine Referenz zur Folie über ihren Index.
1. Fügen Sie ein [IVideo](https://reference.aspose.com/slides/java/com.aspose.slides/ivideo/) Objekt hinzu und übergeben Sie den Videodateipfad, um das Video mit der Präsentation einzubetten.
1. Fügen Sie ein [IVideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/) Objekt hinzu, um einen Rahmen für das Video zu erstellen.
1. Speichern Sie die modifizierte Präsentation.

Dieser Java-Code zeigt Ihnen, wie Sie ein lokal gespeichertes Video zu einer Präsentation hinzufügen:

```java
// Instanziiert die Presentation-Klasse
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

Alternativ können Sie ein Video hinzufügen, indem Sie seinen Dateipfad direkt an die [addVideoFrame(float x, float y, float width, float height, IVideo video)](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-com.aspose.slides.IVideo-) Methode übergeben:

``` java
Presentation pres = new Presentation();
try {
	ISlide sld = pres.getSlides().get_Item(0);
	IVideoFrame vf = sld.getShapes().addVideoFrame(50, 150, 300, 150, "video1.avi");
} finally {
	if (pres != null) pres.dispose();
}
```


## **Erstellen eines Video-Frames mit Video aus einer Webquelle**

Microsoft [PowerPoint 2013 und neuer](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) unterstützt YouTube-Videos in Präsentationen. Wenn das Video, das Sie verwenden möchten, online verfügbar ist (z. B. auf YouTube), können Sie es über seinen Weblink zu Ihrer Präsentation hinzufügen.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) Klasse.
1. Holen Sie sich eine Referenz zur Folie über ihren Index.
1. Fügen Sie ein [IVideo](https://reference.aspose.com/slides/java/com.aspose.slides/ivideo/) Objekt hinzu und übergeben Sie den Link zum Video.
1. Setzen Sie ein Thumbnail für den Video-Frame.
1. Speichern Sie die Präsentation.

Dieser Java-Code zeigt Ihnen, wie Sie ein Video von der Web zu einer Folie in einer PowerPoint-Präsentation hinzufügen:

```java
// Instanziiert ein Presentation-Objekt, das eine Präsentationsdatei darstellt 
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
    // Fügt einen VideoFrame hinzu
    IVideoFrame videoFrame = pres.getSlides().get_Item(0).getShapes().addVideoFrame(
            10, 10, 427, 240, "https://www.youtube.com/embed/" + videoID);
    videoFrame.setPlayMode(VideoPlayModePreset.Auto);

    // Lädt das Thumbnail
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

## **Video von Folie extrahieren**

Neben dem Hinzufügen von Videos zu Folien erlaubt Aspose.Slides Ihnen auch, Videos, die in Präsentationen eingebettet sind, zu extrahieren.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) Klasse, um die Präsentation zu laden, die das Video enthält.
2. Durchlaufen Sie alle [ISlide](https://reference.aspose.com/slides/java/com.aspose.slides/islide/) Objekte.
3. Durchlaufen Sie alle [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) Objekte, um einen [VideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/) zu finden.
4. Speichern Sie das Video auf der Festplatte.

Dieser Java-Code zeigt Ihnen, wie Sie das Video auf einer Präsentationsfolie extrahieren:

```java
// Instanziiert ein Presentation-Objekt, das eine Präsentationsdatei darstellt 
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

                // Holt die Dateiendung
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