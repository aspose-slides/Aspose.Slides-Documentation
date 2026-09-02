---
title: Video-Frames in Präsentationen mit Java verwalten
linktitle: Video-Frame
type: docs
weight: 10
url: /de/java/video-frame/
keywords:
- Video hinzufügen
- Video erstellen
- Video einbetten
- Video extrahieren
- Video abrufen
- Video-Frame
- Web-Quelle
- PowerPoint
- OpenDocument
- Präsentation
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie mit Aspose.Slides für Java programmgesteuert Video‑Frames in PowerPoint‑ und OpenDocument‑Folien hinzufügen und extrahieren. Schnelle Schritt‑für‑Schritt‑Anleitung."
---
## **Einleitung**

Ein gut platziertes Video in einer Präsentation kann Ihre Botschaft überzeugender machen und die Engagement‑Level Ihres Publikums erhöhen.  

PowerPoint ermöglicht es Ihnen, Videos auf einer Folie einer Präsentation auf zwei Arten hinzuzufügen:

* Ein lokales Video hinzufügen oder einbetten (auf Ihrem Rechner gespeichert)
* Ein Online‑Video hinzufügen (aus einer Web‑Quelle wie YouTube).

Damit Sie Videos (Video‑Objekte) zu einer Präsentation hinzufügen können, stellt Aspose.Slides das [IVideo](https://reference.aspose.com/slides/de/java/com.aspose.slides/ivideo/)‑Interface, das [IVideoFrame](https://reference.aspose.com/slides/de/java/com.aspose.slides/ivideoframe/)‑Interface und weitere relevante Typen bereit. 

## **Erstellen eingebetteter Video‑Frames**

Wenn die Videodatei, die Sie Ihrer Folie hinzufügen möchten, lokal gespeichert ist, können Sie einen Video‑Frame erstellen, um das Video in Ihre Präsentation einzubetten. 

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/Presentation)‑Klasse.  
1. Holen Sie die Referenz einer Folie anhand ihres Index.  
1. Fügen Sie ein [IVideo](https://reference.aspose.com/slides/de/java/com.aspose.slides/ivideo/)‑Objekt hinzu und übergeben Sie den Pfad zur Videodatei, um das Video in die Präsentation einzubetten.  
1. Fügen Sie ein [IVideoFrame](https://reference.aspose.com/slides/de/java/com.aspose.slides/ivideoframe/)‑Objekt hinzu, um einen Rahmen für das Video zu erstellen.  
1. Speichern Sie die geänderte Präsentation.  

Dieser Java‑Code zeigt, wie Sie ein lokal gespeichertes Video zu einer Präsentation hinzufügen:

```java
// Instanziiert die Presentation-Klasse
Presentation pres = new Presentation("pres.pptx");
try {
    // Lädt das Video
    FileInputStream fileStream = new FileInputStream("Wildlife.mp4");
    
    IVideo video = pres.getVideos().addVideo(fileStream, LoadingStreamBehavior.KeepLocked);

    // Holt die erste Folie und fügt einen Video-Frame hinzu
    pres.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 150, 250, video);

    // Speichert die Präsentation auf die Festplatte
    pres.save("pres-with-video.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

Alternativ können Sie ein Video hinzufügen, indem Sie seinen Dateipfad direkt an die Methode [addVideoFrame(float x, float y, float width, float height, IVideo video)](https://reference.aspose.com/slides/de/java/com.aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-com.aspose.slides.IVideo-) übergeben:

``` java
Presentation pres = new Presentation();
try {
	ISlide sld = pres.getSlides().get_Item(0);
	IVideoFrame vf = sld.getShapes().addVideoFrame(50, 150, 300, 150, "video1.avi");
} finally {
	if (pres != null) pres.dispose();
}
```

## **Erstellen von Video‑Frames mit Videos aus Web‑Quellen**

Microsoft [PowerPoint 2013 und neuer](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) unterstützt YouTube‑Videos in Präsentationen. Wenn das Video, das Sie verwenden möchten, online verfügbar ist (z. B. auf YouTube), können Sie es über seinen Web‑Link zu Ihrer Präsentation hinzufügen. 

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/Presentation)‑Klasse.  
1. Holen Sie die Referenz einer Folie anhand ihres Index.  
1. Fügen Sie ein [IVideo](https://reference.aspose.com/slides/de/java/com.aspose.slides/ivideo/)‑Objekt hinzu und übergeben Sie den Link zum Video.  
1. Legen Sie ein Thumbnail für den Video‑Frame fest.  
1. Speichern Sie die Präsentation.  

Dieser Java‑Code zeigt, wie Sie ein Video aus dem Web zu einer Folie in einer PowerPoint‑Präsentation hinzufügen:

```java
// Instanziiert ein Presentation-Objekt, das eine Präsentationsdatei repräsentiert
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

## **Trimmen eines Video‑Frames**

Aspose.Slides ermöglicht es Ihnen, welchen Teil eines Videos Sie abspielen, indem Sie die Werte trim‑from‑start und trim‑from‑end über [IVideoFrame.setTrimFromStart](https://reference.aspose.com/slides/de/java/com.aspose.slides/ivideoframe/#setTrimFromStart-float-) und [IVideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/de/java/com.aspose.slides/ivideoframe/#setTrimFromEnd-float-) festlegen. Beide Werte werden in Millisekunden angegeben und definieren, wie viel Zeit zu Beginn bzw. am Ende des Videos übersprungen wird. Diese Einstellungen ändern die Wiedergabe‑Parameter im Präsentations‑Video; sie schneiden das eingebettete Videobinary nicht zu oder ändern es anderweitig.

**Trim‑Einstellungen festlegen**

Um einen Video‑Frame zu erstellen und seine Trim‑Einstellungen festzulegen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/)‑Klasse.  
1. Fügen Sie ein [IVideo](https://reference.aspose.com/slides/de/java/com.aspose.slides/ivideo/)‑Objekt zur Präsentation hinzu.  
1. Fügen Sie ein [IVideoFrame](https://reference.aspose.com/slides/de/java/com.aspose.slides/ivideoframe/)‑Objekt zu einer Folie hinzu.  
1. Setzen Sie die Werte trim‑from‑start und trim‑from‑end über [IVideoFrame.setTrimFromStart](https://reference.aspose.com/slides/de/java/com.aspose.slides/ivideoframe/#setTrimFromStart-float-) und [IVideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/de/java/com.aspose.slides/ivideoframe/#setTrimFromEnd-float-).  
1. Speichern Sie die geänderte Präsentation.  

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

**Trim‑Einstellungen auslesen**

Um vorhandene Trim‑Einstellungen zu prüfen, laden Sie eine Präsentation, finden ein [IVideoFrame](https://reference.aspose.com/slides/de/java/com.aspose.slides/ivideoframe/)‑Objekt unter den Formen der ersten Folie und lesen die Werte über [IVideoFrame.getTrimFromStart](https://reference.aspose.com/slides/de/java/com.aspose.slides/ivideoframe/#getTrimFromStart--) und [IVideoFrame.getTrimFromEnd](https://reference.aspose.com/slides/de/java/com.aspose.slides/ivideoframe/#getTrimFromEnd--).

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

## **Verwalten von Video‑Untertiteln**

Aspose.Slides erlaubt es Ihnen, geschlossene Untertitel für Video‑Frames in PowerPoint‑Präsentationen zu verwalten. Untertitel werden im WebVTT‑Format gespeichert und über die Methode [IVideoFrame.getCaptionTracks](https://reference.aspose.com/slides/de/java/com.aspose.slides/ivideoframe/#getCaptionTracks--) bereitgestellt.

**Untertitel zu einem Video‑Frame hinzufügen**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/)‑Klasse.  
1. Fügen Sie ein Video zur Präsentation hinzu.  
1. Fügen Sie ein [IVideoFrame](https://reference.aspose.com/slides/de/java/com.aspose.slides/ivideoframe/)‑Objekt zu einer Folie hinzu.  
1. Verwenden Sie die von [getCaptionTracks](https://reference.aspose.com/slides/de/java/com.aspose.slides/ivideoframe/#getCaptionTracks--) zurückgegebene [ICaptionsCollection](https://reference.aspose.com/slides/de/java/com.aspose.slides/icaptionscollection/), um einen WebVTT‑Untertitel‑Track hinzuzufügen.  
1. Speichern Sie die geänderte Präsentation.  

```java
Presentation presentation = new Presentation();
try {
    byte[] videoData = Files.readAllBytes(Paths.get("video.mp4"));
    IVideo video = presentation.getVideos().addVideo(videoData);

    ISlide slide = presentation.getSlides().get_Item(0);
    IVideoFrame videoFrame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video);

    // Fügt einen neuen Untertitel-Track aus einer WebVTT-Datei hinzu.
    videoFrame.getCaptionTracks().add("English", "track.vtt");

    presentation.save("video_with_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Das [ICaptionsCollection](https://reference.aspose.com/slides/de/java/com.aspose.slides/icaptionscollection/)‑Interface bietet zudem eine Überladung, mit der Sie Untertitel aus einem Stream hinzufügen können.

**Untertitel aus einem Video‑Frame extrahieren**

1. Laden Sie die Präsentation, die das Video enthält.  
1. Finden Sie das Ziel‑[IVideoFrame](https://reference.aspose.com/slides/de/java/com.aspose.slides/ivideoframe/)‑Objekt.  
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

Jedes [ICaptions](https://reference.aspose.com/slides/de/java/com.aspose.slides/icaptions/)‑Objekt gibt die Untertitel‑Kennung, das Label, die Binärdaten und den Untertiteltext als UTF‑8‑Zeichenkette zurück.

**Untertitel aus einem Video‑Frame entfernen**

1. Laden Sie die Präsentation, die das Video enthält.  
1. Holen Sie das Ziel‑[IVideoFrame](https://reference.aspose.com/slides/de/java/com.aspose.slides/ivideoframe/)‑Objekt.  
1. Entfernen Sie Untertitel‑Tracks aus der [ICaptionsCollection](https://reference.aspose.com/slides/de/java/com.aspose.slides/icaptionscollection/).  
1. Speichern Sie die geänderte Präsentation.  

```java
Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IVideoFrame videoFrame = (IVideoFrame)slide.getShapes().get_Item(0);

    // Entfernt alle Untertitel aus dem Video-Frame.
    videoFrame.getCaptionTracks().clear();

    presentation.save("video_without_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Falls Sie nur einen Untertitel‑Track entfernen müssen, verwenden Sie die Methoden [remove](https://reference.aspose.com/slides/de/java/com.aspose.slides/icaptionscollection/#remove-com.aspose.slides.ICaptions-) oder [removeAt](https://reference.aspose.com/slides/de/java/com.aspose.slides/icaptionscollection/#removeAt-int-) statt [clear](https://reference.aspose.com/slides/de/java/com.aspose.slides/icaptionscollection/#clear--).

## **Video aus Folien extrahieren**

Neben dem Hinzufügen von Videos zu Folien erlaubt Aspose.Slides das Extrahieren von in Präsentationen eingebetteten Videos.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/Presentation)‑Klasse, um die Präsentation zu laden, die das Video enthält.  
2. Durchlaufen Sie alle [ISlide](https://reference.aspose.com/slides/de/java/com.aspose.slides/islide/)‑Objekte.  
3. Durchlaufen Sie alle [IShape](https://reference.aspose.com/slides/de/java/com.aspose.slides/ishape/)‑Objekte, um ein [VideoFrame](https://reference.aspose.com/slides/de/java/com.aspose.slides/videoframe/) zu finden.  
4. Speichern Sie das Video auf dem Datenträger.  

Dieser Java‑Code zeigt, wie Sie das Video einer Präsentationsfolie extrahieren:

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

                //Ermittelt die Dateierweiterung
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

Sie können den [Wiedergabemodus](https://reference.aspose.com/slides/de/java/com.aspose.slides/videoframe/#setPlayMode-int-) (automatisch oder bei Klick) und das [Looping](https://reference.aspose.com/slides/de/java/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) steuern. Diese Optionen stehen über die Eigenschaften des [VideoFrame](https://reference.aspose.com/slides/de/java/com.aspose.slides/videoframe/)‑Objekts zur Verfügung.

**Beeinflusst das Hinzufügen eines Videos die PPTX‑Dateigröße?**

Ja. Beim Einbetten eines lokalen Videos werden die Binärdaten in das Dokument aufgenommen, sodass die Präsentationsgröße proportional zur Dateigröße wächst. Beim Hinzufügen eines Online‑Videos werden ein Link und ein Thumbnail eingebettet, sodass der Größenzuwachs geringer ist.

**Kann ich das Video in einem bestehenden VideoFrame ersetzen, ohne Position und Größe zu ändern?**

Ja. Sie können den [Video‑Inhalt](https://reference.aspose.com/slides/de/java/com.aspose.slides/videoframe/#setEmbeddedVideo-com.aspose.slides.IVideo-) innerhalb des Frames austauschen und gleichzeitig die Geometrie der Form beibehalten; dies ist ein häufiges Szenario zum Aktualisieren von Medien in einem bestehenden Layout.

**Kann der Inhaltstyp (MIME) eines eingebetteten Videos ermittelt werden?**

Ja. Ein eingebettetes Video verfügt über einen [Content‑Type](https://reference.aspose.com/slides/de/java/com.aspose.slides/video/#getContentType--), den Sie auslesen und z. B. beim Speichern auf dem Datenträger verwenden können.