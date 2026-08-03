---
title: Verwalten von Video-Frames in Präsentationen auf Android
linktitle: Video-Frame
type: docs
weight: 10
url: /de/androidjava/video-frame/
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
- Android
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie programmgesteuert Video-Frames in PowerPoint- und OpenDocument-Folien mit Aspose.Slides für Android in Java hinzufügen und extrahieren. Schnelle Anleitung."
---
## **Einleitung**

Ein gut platziertes Video in einer Präsentation kann Ihre Botschaft überzeugender machen und das Engagement Ihres Publikums erhöhen.

PowerPoint ermöglicht das Hinzufügen von Videos zu einer Folie in einer Präsentation auf zwei Arten:

* Ein lokales Video hinzufügen oder einbetten (auf Ihrem Rechner gespeichert)
* Ein Online-Video hinzufügen (aus einer Webquelle wie YouTube).

Um das Hinzufügen von Videos (Videoobjekten) zu einer Präsentation zu ermöglichen, stellt Aspose.Slides die [IVideo](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ivideo/)‑Schnittstelle, die [IVideoFrame](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ivideoframe/)‑Schnittstelle und weitere relevante Typen bereit.

## **Erstellen eines eingebetteten Video‑Frames**

Wenn die Videodatei, die Sie zu Ihrer Folie hinzufügen möchten, lokal gespeichert ist, können Sie einen Video‑Frame erstellen, um das Video in Ihrer Präsentation einzubetten.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/Presentation)‑Klasse.
1. Holen Sie sich über den Index einen Verweis auf eine Folie.
1. Fügen Sie ein [IVideo](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ivideo/)‑Objekt hinzu und übergeben Sie den Pfad zur Videodatei, um das Video in die Präsentation einzubetten.
1. Fügen Sie ein [IVideoFrame](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ivideoframe/)‑Objekt hinzu, um einen Frame für das Video zu erstellen.
1. Speichern Sie die geänderte Präsentation.

Dieser Java‑Code zeigt, wie Sie ein lokal gespeichertes Video zu einer Präsentation hinzufügen:

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

Alternativ können Sie ein Video hinzufügen, indem Sie den Dateipfad direkt an die Methode [addVideoFrame(float x, float y, float width, float height, IVideo video)](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-com.aspose.slides.IVideo-) übergeben:

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

Neuere Versionen von Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) unterstützen Online‑Videos in Präsentationen. Wenn das Video, das Sie verwenden möchten, online verfügbar ist (z. B. auf YouTube), können Sie es über seinen Web‑Link zu Ihrer Präsentation hinzufügen.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/Presentation)‑Klasse.
1. Holen Sie sich über den Index einen Verweis auf eine Folie.
1. Fügen Sie ein [IVideo](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ivideo/)‑Objekt hinzu und übergeben Sie den Link zum Video.
1. Legen Sie ein Thumbnail für den Video‑Frame fest.
1. Speichern Sie die Präsentation.

Dieser Java‑Code zeigt, wie Sie ein Video aus dem Web zu einer Folie in einer PowerPoint‑Präsentation hinzufügen:

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
    // Fügt ein Video-Frame hinzu
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

## **Trimmen eines Video‑Frames**

Aspose.Slides ermöglicht es, zu steuern, welcher Teil eines Videos abgespielt wird, indem die Werte trim‑from‑start und trim‑from‑end über [IVideoFrame.setTrimFromStart](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ivideoframe/#setTrimFromStart-float-) bzw. [IVideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ivideoframe/#setTrimFromEnd-float-) festgelegt werden. Beide Werte werden in Millisekunden angegeben und bestimmen, wie viel Zeit zu Beginn bzw. Ende des Videos übersprungen wird. Diese Einstellungen ändern die Wiedergabe­parameter im Dokument; sie schneiden oder verändern die eingebetteten Videodaten nicht.

**Trim‑Einstellungen festlegen**

Um einen Video‑Frame zu erstellen und seine Trim‑Einstellungen festzulegen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation/)‑Klasse.
1. Fügen Sie ein [IVideo](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ivideo/)‑Objekt zur Präsentation hinzu.
1. Fügen Sie ein [IVideoFrame](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ivideoframe/)‑Objekt zu einer Folie hinzu.
1. Setzen Sie die Werte trim‑from‑start und trim‑from‑end über [IVideoFrame.setTrimFromStart](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ivideoframe/#setTrimFromStart-float-) und [IVideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ivideoframe/#setTrimFromEnd-float-).
1. Speichern Sie die geänderte Präsentation.

Das folgende Codebeispiel überspringt die ersten 2,5 Sekunden und die letzte Sekunde eines eingebetteten Videos während der Wiedergabe:

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

Um vorhandene Trim‑Einstellungen zu prüfen, laden Sie eine Präsentation, finden ein [IVideoFrame](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ivideoframe/)‑Objekt auf der ersten Folie und lesen die Werte über [IVideoFrame.getTrimFromStart](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ivideoframe/#getTrimFromStart--) bzw. [IVideoFrame.getTrimFromEnd](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ivideoframe/#getTrimFromEnd--).

Das folgende Codebeispiel findet den ersten Video‑Frame auf der ersten Folie und gibt dessen Trim‑Einstellungen in Millisekunden aus:

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

Aspose.Slides ermöglicht das Verwalten von Closed‑Captions für Video‑Frames in PowerPoint‑Präsentationen. Untertitel werden im WebVTT‑Format gespeichert und über die Methode [IVideoFrame.getCaptionTracks](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--) bereitgestellt.

**Untertitel zu einem Video‑Frame hinzufügen**

Um einem Video‑Frame Untertitel hinzuzufügen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation/)‑Klasse.
1. Fügen Sie ein Video zur Präsentation hinzu.
1. Fügen Sie ein [IVideoFrame](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ivideoframe/)‑Objekt zu einer Folie hinzu.
1. Verwenden Sie die über [getCaptionTracks](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--) zurückgegebene [ICaptionsCollection](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/icaptionscollection/), um eine WebVTT‑Untertitelspur hinzuzufügen.
1. Speichern Sie die geänderte Präsentation.

Der folgende Code zeigt, wie Untertitel zu einem Video‑Frame hinzugefügt werden:

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

Die [ICaptionsCollection](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/icaptionscollection/)-Schnittstelle bietet zudem eine Überladung, mit der Untertitel aus einem Stream hinzugefügt werden können.

**Untertitel aus einem Video‑Frame extrahieren**

Um Untertitel aus einem Video‑Frame zu extrahieren:

1. Laden Sie die Präsentation, die das Video enthält.
1. Finden Sie das Ziel‑[IVideoFrame](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ivideoframe/)‑Objekt.
1. Iterieren Sie über die über [getCaptionTracks](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--) zurückgegebenen Untertitelspuren.
1. Speichern Sie jede Untertitelspur in einer `.vtt`‑Datei.

Der folgende Code zeigt, wie Untertitel aus einem Video‑Frame extrahiert werden:

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

Jedes [ICaptions](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/icaptions/)-Objekt stellt die Untertitel‑ID, das Label, die binären Daten und die Untertitel‑Daten als UTF‑8‑String bereit.

**Untertitel aus einem Video‑Frame entfernen**

Um Untertitel aus einem Video‑Frame zu entfernen:

1. Laden Sie die Präsentation, die das Video enthält.
1. Holen Sie sich das Ziel‑[IVideoFrame](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ivideoframe/)‑Objekt.
1. Entfernen Sie die Untertitelspuren aus der über [getCaptionTracks](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--) zurückgegebenen Sammlung.
1. Speichern Sie die geänderte Präsentation.

Der folgende Code zeigt, wie alle Untertitel aus einem Video‑Frame entfernt werden:

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

Möchten Sie nur eine Untertitelspur entfernen, verwenden Sie die Methoden [remove](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/icaptionscollection/#remove-com.aspose.slides.ICaptions-) bzw. [removeAt](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/icaptionscollection/#removeAt-int-) anstelle von [clear](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/icaptionscollection/#clear--).

## **Video aus einer Folie extrahieren**

Neben dem Hinzufügen von Videos zu Folien ermöglicht Aspose.Slides das Extrahieren von in Präsentationen eingebetteten Videos.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/Presentation)‑Klasse, um die Präsentation zu laden, die das Video enthält.
2. Iterieren Sie über alle [ISlide](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/islide/)-Objekte.
3. Durchlaufen Sie alle [IShape](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ishape/)-Objekte, um ein [VideoFrame](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/videoframe/) zu finden.
4. Speichern Sie das Video auf dem Datenträger.

Dieser Java‑Code zeigt, wie das Video einer Präsentationsfolie extrahiert wird:

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

**Welche Wiedergabe‑Parameter können für einen VideoFrame geändert werden?**

Sie können den [Wiedergabemodus](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/videoframe/#setPlayMode-int-) (automatisch oder bei Klick) und das [Looping](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) steuern. Diese Optionen stehen über die Eigenschaften des [VideoFrame](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/videoframe/)-Objekts bereit.

**Wirkt das Hinzufügen eines Videos auf die Dateigröße einer PPTX?**

Ja. Beim Einbetten eines lokalen Videos werden die Binärdaten in das Dokument aufgenommen, sodass die Präsentationsgröße proportional zur Dateigröße wächst. Beim Hinzufügen eines Online‑Videos werden nur ein Link und ein Thumbnail eingebettet, sodass die Größen­zunahme geringer ausfällt.

**Kann ich das Video in einem bestehenden VideoFrame austauschen, ohne Position und Größe zu ändern?**

Ja. Sie können den [Video‑Inhalt](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/videoframe/#setEmbeddedVideo-com.aspose.slides.IVideo-) innerhalb des Frames austauschen und dabei die Geometrie der Form beibehalten; dies ist ein gängiges Szenario zum Aktualisieren von Medien in einem bestehenden Layout.

**Kann der MIME‑Typ eines eingebetteten Videos ermittelt werden?**

Ja. Ein eingebettetes Video verfügt über einen [Content‑Typ](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/video/#getContentType--), den Sie auslesen und beispielsweise beim Speichern auf dem Datenträger verwenden können.