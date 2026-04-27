---
title: Video‑Frames in Präsentationen auf Android verwalten
linktitle: Video‑Frame
type: docs
weight: 10
url: /de/androidjava/video-frame/
keywords:
- Video hinzufügen
- Video erstellen
- Video einbetten
- Video extrahieren
- Video abrufen
- Video‑Frame
- Web‑Quelle
- PowerPoint
- OpenDocument
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie programmgesteuert Video‑Frames in PowerPoint- und OpenDocument‑Folien mithilfe von Aspose.Slides für Android in Java hinzufügen und extrahieren. Schnelle Anleitung."
---
Ein gut platziertes Video in einer Präsentation kann Ihre Botschaft überzeugender machen und das Engagement‑Level Ihres Publikums erhöhen.

PowerPoint ermöglicht das Hinzufügen von Videos zu einer Folie in einer Präsentation auf zwei Arten:

* Ein lokales Video hinzufügen oder einbetten (auf Ihrem Rechner gespeichert)
* Ein Online‑Video hinzufügen (aus einer Web‑Quelle wie YouTube).

Um Ihnen das Hinzufügen von Videos (Video‑Objekten) zu einer Präsentation zu ermöglichen, stellt Aspose.Slides die Schnittstelle [IVideo](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ivideo/) , die Schnittstelle [IVideoFrame](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ivideoframe/) und weitere relevante Typen bereit.

## **Erstellen eines eingebetteten Video‑Frames**

Wenn die Videodatei, die Sie Ihrer Folie hinzufügen möchten, lokal gespeichert ist, können Sie einen Video‑Frame erstellen, um das Video in Ihre Präsentation einzubetten.

1. Erstellen Sie eine Instanz der Klasse [Presentation ](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/Presentation)class.
1. Holen Sie die Referenz einer Folie über ihren Index.
1. Fügen Sie ein [IVideo](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ivideo/)‑Objekt hinzu und übergeben Sie den Pfad der Videodatei, um das Video in die Präsentation einzubetten.
1. Fügen Sie ein [IVideoFrame](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ivideoframe/)‑Objekt hinzu, um einen Frame für das Video zu erstellen.
1. Speichern Sie die modifizierte Präsentation.

```java
// Instanziert die Presentation-Klasse
Presentation pres = new Presentation("pres.pptx");
try {
    // Lädt das Video
    FileInputStream fileStream = new FileInputStream("Wildlife.mp4");
    
    IVideo video = pres.getVideos().addVideo(fileStream, LoadingStreamBehavior.KeepLocked);

    // Holt die erste Folie und fügt einen Video-Frame hinzu
    pres.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 150, 250, video);

    // Speichert die Präsentation auf dem Datenträger
    pres.save("pres-with-video.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

Alternativ können Sie ein Video hinzufügen, indem Sie dessen Dateipfad direkt an die Methode [addVideoFrame(float x, float y, float width, float height, IVideo video)](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-com.aspose.slides.IVideo-) übergeben:

``` java
Presentation pres = new Presentation();
try {
	ISlide sld = pres.getSlides().get_Item(0);
	IVideoFrame vf = sld.getShapes().addVideoFrame(50, 150, 300, 150, "video1.avi");
} finally {
	if (pres != null) pres.dispose();
}
```

## **Erstellen eines Video‑Frames mit Video aus einer Web‑Quelle**

Microsoft [PowerPoint 2013 und neuer](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) unterstützt YouTube‑Videos in Präsentationen. Wenn das Video, das Sie verwenden möchten, online verfügbar ist (z. B. auf YouTube), können Sie es über seinen Web‑Link zu Ihrer Präsentation hinzufügen.

1. Erstellen Sie eine Instanz der Klasse [Presentation ](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/Presentation)class
1. Holen Sie die Referenz einer Folie über ihren Index.
1. Fügen Sie ein [IVideo](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ivideo/)‑Objekt hinzu und übergeben Sie den Link zum Video.
1. Legen Sie ein Miniaturbild für den Video‑Frame fest.
1. Speichern Sie die Präsentation.

```java
// Instanziert ein Presentation-Objekt, das eine Präsentationsdatei darstellt
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

    // Lädt das Miniaturbild
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

## **Video‑Untertitel verwalten**

Aspose.Slides ermöglicht die Verwaltung von Closed Captions für Video‑Frames in PowerPoint‑Präsentationen. Untertitel werden im WebVTT‑Format gespeichert und über die Methode [IVideoFrame.getCaptionTracks](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--) bereitgestellt.

**Untertitel zu einem Video‑Frame hinzufügen**

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation/) class.
1. Fügen Sie ein Video zur Präsentation hinzu.
1. Fügen Sie ein [IVideoFrame](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ivideoframe/)‑Objekt zu einer Folie hinzu.
1. Verwenden Sie die von [getCaptionTracks](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--) zurückgegebene [ICaptionsCollection](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/icaptionscollection/) , um eine WebVTT‑Untertitelspur hinzuzufügen.
1. Speichern Sie die modifizierte Präsentation.

```java
Presentation presentation = new Presentation();
try {
    byte[] videoData = // "video.mp4";
    IVideo video = presentation.getVideos().addVideo(videoData);

    ISlide slide = presentation.getSlides().get_Item(0);
    IVideoFrame videoFrame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video);

    // Fügt eine neue Untertitelspur aus einer WebVTT-Datei hinzu.
    videoFrame.getCaptionTracks().add("English", "track.vtt");

    presentation.save("video_with_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Das Interface [ICaptionsCollection](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/icaptionscollection/) bietet außerdem eine Überladung, mit der Sie Untertitel aus einem Stream hinzufügen können.

**Untertitel aus einem Video‑Frame extrahieren**

1. Laden Sie die Präsentation, die das Video enthält.
1. Suchen Sie das Ziel‑[IVideoFrame](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ivideoframe/)‑Objekt.
1. Iterieren Sie über die von [getCaptionTracks](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--) zurückgegebenen Untertitelspuren.
1. Speichern Sie jede Untertitelspur in einer `.vtt`‑Datei.

```java
Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame) shape;
            for (ICaptions captionTrack : videoFrame.getCaptionTracks()) {
                // Speichert die Untertitelspur in einer WebVTT-Datei.
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

Jedes [ICaptions](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/icaptions/)‑Objekt stellt die Untertitel‑Kennung, das Label, die Binärdaten und die Untertitel‑Daten als UTF‑8‑String bereit.

**Untertitel von einem Video‑Frame entfernen**

1. Laden Sie die Präsentation, die das Video enthält.
1. Holen Sie das Ziel‑[IVideoFrame](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ivideoframe/)‑Objekt.
1. Entfernen Sie Untertitelspuren aus der von [getCaptionTracks](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--) zurückgegebenen Sammlung.
1. Speichern Sie die modifizierte Präsentation.

```java
Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IVideoFrame videoFrame = (IVideoFrame) slide.getShapes().get_Item(0);

    // Entfernt alle Untertitel vom Video-Frame.
    videoFrame.getCaptionTracks().clear();

    presentation.save("video_without_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Wenn Sie nur eine Untertitelspur entfernen müssen, verwenden Sie die Methoden [remove](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/icaptionscollection/#remove-com.aspose.slides.ICaptions-) oder [removeAt](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/icaptionscollection/#removeAt-int-) , anstelle von [clear](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/icaptionscollection/#clear--).

## **Video von einer Folie extrahieren**

Neben dem Hinzufügen von Videos zu Folien ermöglicht Aspose.Slides das Extrahieren von in Präsentationen eingebetteten Videos.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/Presentation) , um die Präsentation zu laden, die das Video enthält.
2. Iterieren Sie über alle [ISlide](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/islide/)‑Objekte.
3. Iterieren Sie über alle [IShape](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ishape/)‑Objekte, um ein [VideoFrame](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/videoframe/)‑Objekt zu finden.
4. Speichern Sie das Video auf dem Datenträger.

```java
// Instanziert ein Presentation-Objekt, das eine Präsentationsdatei darstellt 
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

                // Ermittelt die Dateierweiterung
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

**Welche Video‑Wiedergabeparameter können für einen VideoFrame geändert werden?**

Sie können den [playback mode](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/videoframe/#setPlayMode-int-) (automatisch oder bei Klick) und das [looping](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) steuern. Diese Optionen sind über die Eigenschaften des [VideoFrame](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/videoframe/)‑Objekts verfügbar.

**Wirkt sich das Hinzufügen eines Videos auf die PPTX-Dateigröße aus?**

Ja. Wenn Sie ein lokales Video einbetten, werden die Binärdaten in das Dokument aufgenommen, sodass die Präsentationsgröße proportional zur Dateigröße wächst. Wenn Sie ein Online‑Video hinzufügen, werden ein Link und ein Miniaturbild eingebettet, sodass die Größen‑zunahme geringer ausfällt.

**Kann ich das Video in einem bestehenden VideoFrame ersetzen, ohne Position und Größe zu ändern?**

Ja. Sie können den [video content](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/videoframe/#setEmbeddedVideo-com.aspose.slides.IVideo-) innerhalb des Frames austauschen, wobei die Geometrie der Form erhalten bleibt; dies ist ein gängiges Szenario zum Aktualisieren von Medien in einem bestehenden Layout.

**Lässt sich der Inhaltstyp (MIME) eines eingebetteten Videos bestimmen?**

Ja. Ein eingebettetes Video besitzt einen [content type](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/video/#getContentType--) , den Sie auslesen und verwenden können, zum Beispiel beim Speichern auf dem Datenträger.