---
title: Video-Frames in Präsentationen mit Java verwalten
linktitle: Video-Frame
type: docs
weight: 10
url: /de/java/video-frame/
keywords:
- video hinzufügen
- video erstellen
- video einbetten
- video extrahieren
- video abrufen
- Video-Frame
- Webquelle
- PowerPoint
- OpenDocument
- Präsentation
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie programmgesteuert Video-Frames in PowerPoint- und OpenDocument-Folien mit Aspose.Slides für Java hinzufügen und extrahieren. Schnelle Anleitung."
---
Ein gut platziertes Video in einer Präsentation kann Ihre Botschaft überzeugender machen und das Engagement Ihres Publikums erhöhen. 

PowerPoint ermöglicht es Ihnen, Videos auf einer Folie in einer Präsentation auf zwei Arten hinzuzufügen:

* Ein lokales Video hinzufügen oder einbetten (auf Ihrem Computer gespeichert)
* Ein Online‑Video hinzufügen (von einer Web‑Quelle wie YouTube).

Damit Sie Videos (Video‑Objekte) zu einer Präsentation hinzufügen können, stellt Aspose.Slides die Schnittstelle [IVideo](https://reference.aspose.com/slides/de/java/com.aspose.slides/ivideo/) , die Schnittstelle [IVideoFrame](https://reference.aspose.com/slides/de/java/com.aspose.slides/ivideoframe/) und weitere relevante Typen bereit. 

## **Eingebettete Video‑Frames erstellen**

Wenn die Videodatei, die Sie Ihrer Folie hinzufügen möchten, lokal gespeichert ist, können Sie einen Video‑Frame erstellen, um das Video in Ihre Präsentation einzubetten. 

1. Erstellen Sie eine Instanz der [Presentation ](https://reference.aspose.com/slides/de/java/com.aspose.slides/Presentation) Klasse. 
1. Holen Sie sich eine Referenz auf eine Folie über deren Index. 
1. Fügen Sie ein [IVideo](https://reference.aspose.com/slides/de/java/com.aspose.slides/ivideo/) Objekt hinzu und übergeben Sie den Pfad zur Videodatei, um das Video in die Präsentation einzubetten. 
1. Fügen Sie ein [IVideoFrame](https://reference.aspose.com/slides/de/java/com.aspose.slides/ivideoframe/) Objekt hinzu, um einen Frame für das Video zu erstellen.  
1. Speichern Sie die geänderte Präsentation. 

```java
// Instanziert die Presentation‑Klasse
Presentation pres = new Presentation("pres.pptx");
try {
    // Lädt das Video
    FileInputStream fileStream = new FileInputStream("Wildlife.mp4");
    
    IVideo video = pres.getVideos().addVideo(fileStream, LoadingStreamBehavior.KeepLocked);

    // Holt die erste Folie und fügt einen Video‑Frame hinzu
    pres.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 150, 250, video);

    // Speichert die Präsentation auf dem Datenträger
    pres.save("pres-with-video.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

Alternativ können Sie ein Video hinzufügen, indem Sie dessen Dateipfad direkt an die Methode [addVideoFrame(float x, float y, float width, float height, IVideo video)](https://reference.aspose.com/slides/de/java/com.aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-com.aspose.slides.IVideo-) übergeben:

``` java
Presentation pres = new Presentation();
try {
	ISlide sld = pres.getSlides().get_Item(0);
	IVideoFrame vf = sld.getShapes().addVideoFrame(50, 150, 300, 150, "video1.avi");
} finally {
	if (pres != null) pres.dispose();
}
```

## **Video‑Frames mit Video aus Web‑Quellen erstellen**

Microsoft [PowerPoint 2013 und  neuer](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) unterstützt YouTube‑Videos in Präsentationen. Wenn das Video, das Sie verwenden möchten, online verfügbar ist (z. B. auf YouTube), können Sie es mittels seines Web‑Links zu Ihrer Präsentation hinzufügen. 

1. Erstellen Sie eine Instanz der [Presentation ](https://reference.aspose.com/slides/de/java/com.aspose.slides/Presentation) Klasse
1. Holen Sie sich eine Referenz auf eine Folie über deren Index. 
1. Fügen Sie ein [IVideo](https://reference.aspose.com/slides/de/java/com.aspose.slides/ivideo/) Objekt hinzu und übergeben Sie den Link zum Video.
1. Legen Sie ein Thumbnail für den Video‑Frame fest. 
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
    // Fügt einen VideoFrame hinzu
    IVideoFrame videoFrame = pres.getSlides().get_Item(0).getShapes().addVideoFrame(
            10, 10, 427, 240, "https://www.youtube.com/embed/" + videoID);
    videoFrame.setPlayMode(VideoPlayModePreset.Auto);

    // Lädt das Vorschaubild
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

Aspose.Slides ermöglicht es Ihnen, geschlossene Untertitel für Video‑Frames in PowerPoint‑Präsentationen zu verwalten. Untertitel werden im WebVTT‑Format gespeichert und über die Methode [IVideoFrame.getCaptionTracks](https://reference.aspose.com/slides/de/java/com.aspose.slides/ivideoframe/#getCaptionTracks--) bereitgestellt.

**Untertitel zu einem Video‑Frame hinzufügen**

Um Untertitel zu einem Video‑Frame hinzuzufügen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/) Klasse.
1. Fügen Sie ein Video zur Präsentation hinzu.
1. Fügen Sie ein [IVideoFrame](https://reference.aspose.com/slides/de/java/com.aspose.slides/ivideoframe/) Objekt zu einer Folie hinzu.
1. Verwenden Sie die von [getCaptionTracks](https://reference.aspose.com/slides/de/java/com.aspose.slides/ivideoframe/#getCaptionTracks--) zurückgegebene [ICaptionsCollection](https://reference.aspose.com/slides/de/java/com.aspose.slides/icaptionscollection/) , um einen WebVTT‑Untertitel‑Track hinzuzufügen.
1. Speichern Sie die geänderte Präsentation.

```java
Presentation presentation = new Presentation();
try {
    byte[] videoData = Files.readAllBytes(Paths.get("video.mp4"));
    IVideo video = presentation.getVideos().addVideo(videoData);

    ISlide slide = presentation.getSlides().get_Item(0);
    IVideoFrame videoFrame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video);

    // Fügt einen neuen Untertitel‑Track aus einer WebVTT‑Datei hinzu.
    videoFrame.getCaptionTracks().add("English", "track.vtt");

    presentation.save("video_with_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Die Schnittstelle [ICaptionsCollection](https://reference.aspose.com/slides/de/java/com.aspose.slides/icaptionscollection/) bietet ebenfalls eine Überladung, mit der Sie Untertitel aus einem Stream hinzufügen können.

**Untertitel aus einem Video‑Frame extrahieren**

Um Untertitel aus einem Video‑Frame zu extrahieren:

1. Laden Sie die Präsentation, die das Video enthält.
1. Finden Sie das gewünschte [IVideoFrame](https://reference.aspose.com/slides/de/java/com.aspose.slides/ivideoframe/) Objekt.
1. Durchlaufen Sie die Untertitel‑Tracks in der [ICaptionsCollection](https://reference.aspose.com/slides/de/java/com.aspose.slides/icaptionscollection/).
1. Speichern Sie jeden Untertitel‑Track in einer `.vtt`‑Datei.

```java
Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame)shape;
            for (ICaptions captionTrack : videoFrame.getCaptionTracks()) {
                // Speichert den Untertitel-Track in einer WebVTT-Datei.
                String filePath = captionTrack.getCaptionId().toString() + ".vtt";
                Files.write(Paths.get(filePath), captionTrack.getBinaryData());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Jedes [ICaptions](https://reference.aspose.com/slides/de/java/com.aspose.slides/icaptions/) Objekt stellt die Untertitel‑Kennung, das Label, die Binärdaten und den Untertiteltext als UTF‑8‑Zeichenkette bereit.

**Untertitel aus einem Video‑Frame entfernen**

Um Untertitel aus einem Video‑Frame zu entfernen:

1. Laden Sie die Präsentation, die das Video enthält.
1. Holen Sie das gewünschte [IVideoFrame](https://reference.aspose.com/slides/de/java/com.aspose.slides/ivideoframe/) Objekt.
1. Entfernen Sie die Untertitel‑Tracks aus der [ICaptionsCollection](https://reference.aspose.com/slides/de/java/com.aspose.slides/icaptionscollection/).
1. Speichern Sie die geänderte Präsentation.

```java
Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IVideoFrame videoFrame = (IVideoFrame)slide.getShapes().get_Item(0);

    // Entfernt alle Untertitel vom Video-Frame.
    videoFrame.getCaptionTracks().clear();

    presentation.save("video_without_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Wenn Sie nur einen Untertitel‑Track entfernen müssen, verwenden Sie die Methoden [remove](https://reference.aspose.com/slides/de/java/com.aspose.slides/icaptionscollection/#remove-com.aspose.slides.ICaptions-) oder [removeAt](https://reference.aspose.com/slides/de/java/com.aspose.slides/icaptionscollection/#removeAt-int-) anstelle von [clear](https://reference.aspose.com/slides/de/java/com.aspose.slides/icaptionscollection/#clear--).

## **Video aus Folien extrahieren**

Zusätzlich zum Hinzufügen von Videos zu Folien ermöglicht Aspose.Slides das Extrahieren von in Präsentationen eingebetteten Videos.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/Presentation) Klasse, um die Präsentation zu laden, die das Video enthält. 
2. Durchlaufen Sie alle [ISlide](https://reference.aspose.com/slides/de/java/com.aspose.slides/islide/) Objekte.
3. Durchlaufen Sie alle [IShape](https://reference.aspose.com/slides/de/java/com.aspose.slides/ishape/) Objekte, um einen [VideoFrame](https://reference.aspose.com/slides/de/java/com.aspose.slides/videoframe/) zu finden. 
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

## **FAQ**

**Welche Video‑Wiedergabe‑Parameter können für einen VideoFrame geändert werden?**

Sie können den [Wiedergabemodus](https://reference.aspose.com/slides/de/java/com.aspose.slides/videoframe/#setPlayMode-int-) (automatisch oder bei Klick) und das [Looping](https://reference.aspose.com/slides/de/java/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) steuern. Diese Optionen stehen über die Eigenschaften des [VideoFrame](https://reference.aspose.com/slides/de/java/com.aspose.slides/videoframe/) Objekts zur Verfügung.

**Beeinflusst das Hinzufügen eines Videos die PPTX‑Dateigröße?**

Ja. Wenn Sie ein lokales Video einbetten, werden die Binärdaten in das Dokument aufgenommen, sodass die Präsentationsgröße proportional zur Dateigröße steigt. Wenn Sie ein Online‑Video hinzufügen, werden ein Link und ein Thumbnail eingebettet, wodurch die Größensteigerung geringer ausfällt.

**Kann ich das Video in einem vorhandenen VideoFrame ersetzen, ohne Position und Größe zu ändern?**

Ja. Sie können den [Video‑Inhalt](https://reference.aspose.com/slides/de/java/com.aspose.slides/videoframe/#setEmbeddedVideo-com.aspose.slides.IVideo-) innerhalb des Frames austauschen, während Sie die Geometrie der Form beibehalten; dies ist ein häufiges Szenario zum Aktualisieren von Medien in einem bestehenden Layout.

**Kann der Inhaltstyp (MIME) eines eingebetteten Videos ermittelt werden?**

Ja. Ein eingebettetes Video verfügt über einen [Content‑Typ](https://reference.aspose.com/slides/de/java/com.aspose.slides/video/#getContentType--) , den Sie auslesen und verwenden können, z. B. beim Speichern auf die Festplatte.