---
title: Video-Frames in Präsentationen auf Android verwalten
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
description: "Erfahren Sie, wie Sie programmatisch Video-Frames in PowerPoint- und OpenDocument-Folien mit Aspose.Slides für Android via Java hinzufügen und extrahieren. Schnelle Anleitung."
---
## **Einleitung**

Videos können helfen, Ideen zu erklären und ein Publikum zu fesseln. Aspose.Slides für Android über Java ermöglicht das Hinzufügen von Videoframes zu Folien, das Anpassen von Wiedergabeeinstellungen, das Verwalten von Untertiteln und das Extrahieren eingebetteter Videodaten.

PowerPoint unterstützt lokale Videos und Links zu Online‑Videos, etwa YouTube‑Videos.

Um Videodaten und Videoframes darzustellen, stellt Aspose.Slides die Schnittstellen [IVideo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideo/) und [IVideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/) sowie weitere relevante Typen bereit.

## **Ein eingebettetes Video‑Frame erstellen**

Wenn die Videodatei, die Sie Ihrer Folie hinzufügen möchten, lokal gespeichert ist, können Sie ein Video‑Frame erstellen, um das Video in Ihre Präsentation einzubetten.

Dieses Beispiel bettet ein lokales Video auf der ersten Folie einer vorhandenen Präsentation ein und speichert das Ergebnis. Frame‑Koordinaten und -Abmessungen werden in Punkten angegeben. Der Stream bleibt geöffnet, bis das Speichern abgeschlossen ist, da [LoadingStreamBehavior.KeepLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadingstreambehavior/) ihn gesperrt hält, solange die Präsentation ihn verwendet.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation("presentation.pptx");
try (FileInputStream videoStream = new FileInputStream("video.mp4")) {
    ISlide slide = presentation.getSlides().get_Item(0);

    IVideo video = presentation.getVideos().addVideo(videoStream, LoadingStreamBehavior.KeepLocked);
    slide.getShapes().addVideoFrame(10, 10, 150, 250, video);

    presentation.save("embedded_video.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sie können auch einen lokalen Videopfad direkt an [addVideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-java.lang.String-) übergeben. Dieses Beispiel bettet das Video auf der ersten Folie einer neuen Präsentation ein. Das Video muss bis zum Speichern der Präsentation zugänglich bleiben.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    slide.getShapes().addVideoFrame(50, 150, 300, 150, "video.avi");

    presentation.save("video_from_path.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ein Video‑Frame mit Video aus einer Web‑Quelle erstellen**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) unterstützt Online‑Videos in Präsentationen. Sie können ein Video‑Frame erstellen, das auf ein Online‑Video, etwa ein YouTube‑Video, verweist.

Dieses Beispiel fügt der ersten Folie einen YouTube‑Video‑Link und ein Vorschaubild hinzu. Ersetzen Sie die Video‑Kennung, um ein anderes Video zu verwenden. Die Methode [setPlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/#setPlayMode-int-) fordert die automatische Wiedergabe an. Das Herunterladen des Vorschaubilds und das Abspielen des Videos erfordern Internetzugriff. Der Präsentationsviewer muss ebenfalls die Wiedergabe von Online‑Videos unterstützen.

```java
import com.aspose.slides.*;
import java.io.InputStream;
import java.net.URL;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    String videoId = "aqz-KE-bpKQ";
    String videoUrl = "https://www.youtube.com/embed/" + videoId;
    IVideoFrame videoFrame = slide.getShapes().addVideoFrame(10, 10, 427, 240, videoUrl);
    videoFrame.setPlayMode(VideoPlayModePreset.Auto);

    String thumbnailUrl = "https://img.youtube.com/vi/" + videoId + "/hqdefault.jpg";
    URL thumbnailLocation = new URL(thumbnailUrl);
    try (InputStream thumbnailStream = thumbnailLocation.openStream()) {
        IPPImage thumbnail = presentation.getImages().addImage(thumbnailStream);
        videoFrame.getPictureFormat().getPicture().setImage(thumbnail);
    }

    presentation.save("online_video.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ein Video im Vollbild‑Modus abspielen**

In einer Schulungspräsentation können Sie eine Software‑Demonstration im Vollbild‑Modus abspielen, damit das Publikum die Details sehen kann. Rufen Sie [setFullScreenMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setFullScreenMode-boolean-) mit `true` auf, um dieses Verhalten während der Wiedergabe zu aktivieren.

Dieses Beispiel öffnet eine Präsentation, findet das erste [IVideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/) auf der ersten Folie und aktiviert die Vollbild‑Wiedergabe. Die Eingabe‑Präsentation muss mindestens eine Folie mit einem bestehenden Video‑Frame auf der ersten Folie enthalten.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("training.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame) shape;
            videoFrame.setFullScreenMode(true);
            break;
        }
    }

    presentation.save("full_screen_video.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Die Vollbild‑Wiedergabe steuert, wie das Video angezeigt wird. Unabhängig davon steuert [setPlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayMode-int-) ob es automatisch oder per Klick startet, und [setPlayLoopMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) ob es wiederholt wird. Um das Startverhalten festzulegen, setzen Sie den Wiedergabemodus auf [VideoPlayModePreset.Auto or VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoplaymodepreset/). Das Beispiel erhält die bestehenden Start‑ und Schleifeinstellungen bei.

## **Ein Video nach der Wiedergabe zurückspulen**

In einer Schulungspräsentation macht das Zurückspulen eines Demonstrationsvideos an den Anfang das Video bereit für die nächste Wiedergabe. Rufen Sie [setRewindVideo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setRewindVideo-boolean-) mit `true` auf, um das Video nach Abschluss der Wiedergabe an den Anfang zurückzusetzen.

Dieses Beispiel öffnet eine Präsentation, findet das erste [IVideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/) auf der ersten Folie und aktiviert das Zurückspulen. Es deaktiviert die Schleife, damit die Wiedergabe beendet werden kann, und setzt die Wiedergabe auf Klick‑Start. Die Eingabe‑Präsentation muss mindestens eine Folie mit einem bestehenden Video‑Frame auf der ersten Folie enthalten.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("training.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame) shape;
            videoFrame.setRewindVideo(true);
            videoFrame.setPlayLoopMode(false);
            videoFrame.setPlayMode(VideoPlayModePreset.OnClick);
            break;
        }
    }

    presentation.save("rewind_video.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Das Zurückspulen setzt das Video wieder an den Anfang, ohne es erneut zu starten. Im Gegensatz dazu wiederholt ein Aufruf von [setPlayLoopMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) mit `true` die Wiedergabe automatisch. Deaktivieren Sie die Schleife, wenn das Video vollständig abgespielt und bereit für eine erneute Wiedergabe sein soll. [setPlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayMode-int-) steuert unabhängig davon, ob die Wiedergabe automatisch oder per Klick beginnt; dieses Beispiel verwendet [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoplaymodepreset/), sodass der Präsentierende den Startzeitpunkt kontrolliert. Setzen Sie den Wiedergabemodus nach der Schleife‑Einstellung, wie im Beispiel gezeigt. Das Zurückspulen funktioniert unabhängig von [setFullScreenMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setFullScreenMode-boolean-).

## **Ein Video‑Frame trimmen**

Verwenden Sie [IVideoFrame.setTrimFromStart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/#setTrimFromStart-float-) und [IVideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/#setTrimFromEnd-float-), um den Anfang oder das Ende eines Videos während der Wiedergabe zu überspringen. Beide Werte werden in Millisekunden angegeben. Das Trimmen ändert die Wiedergabeeinstellungen, ohne die eingebetteten Videodaten zu verändern.

**Trim‑Einstellungen festlegen**

Dieses Beispiel bettet ein lokales Video ein und überspringt die ersten 2,5 Sekunden sowie die letzte Sekunde während der Wiedergabe. Verwenden Sie ein Video, das länger als 3,5 Sekunden ist, damit ein abspielbarer Abschnitt erhalten bleibt.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IVideo video;
    try (FileInputStream videoStream = new FileInputStream("video.mp4")) {
        video = presentation.getVideos().addVideo(videoStream, LoadingStreamBehavior.ReadStreamAndRelease);
    }

    IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 640, 360, video);
    videoFrame.setTrimFromStart(2500f);
    videoFrame.setTrimFromEnd(1000f);

    presentation.save("video_with_trim.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Trim‑Einstellungen auslesen**

Dieses Beispiel gibt die Trim‑Werte des ersten Video‑Frames auf der ersten Folie in Millisekunden aus. Die Präsentation muss mindestens eine Folie enthalten. Wenn diese Folie keinen Video‑Frame hat, wird nichts ausgegeben. Das vorherige Beispiel liefert die Werte 2500 und 1000.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("video_with_trim.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame) shape;
            System.out.println("Trim from start: " + videoFrame.getTrimFromStart() + " ms");
            System.out.println("Trim from end: " + videoFrame.getTrimFromEnd() + " ms");
            break;
        }
    }
} finally {
    presentation.dispose();
}
```

## **Videountertitel verwalten**

Aspose.Slides ermöglicht das Verwalten von Closed‑Captions für Video‑Frames in PowerPoint‑Präsentationen. Untertitel werden im WebVTT‑Format gespeichert und über die Methode [IVideoFrame.getCaptionTracks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--) bereitgestellt.

### **Untertitel zu einem Video‑Frame hinzufügen**

Dieses Beispiel bettet ein lokales Video ein und fügt eine WebVTT‑Untertitelspur mit der Bezeichnung English hinzu. Die Zeitstempel der Untertitel sollten zum Video passen. Die gespeicherte Präsentation enthält sowohl das Video als auch seine Untertitel.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IVideo video;
    try (FileInputStream videoStream = new FileInputStream("video.mp4")) {
        video = presentation.getVideos().addVideo(videoStream, LoadingStreamBehavior.ReadStreamAndRelease);
    }

    IVideoFrame videoFrame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video);
    videoFrame.getCaptionTracks().add("English", "track.vtt");

    presentation.save("video_with_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Das Interface [ICaptionsCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptionscollection/) bietet ebenfalls eine Überladung, mit der Untertitel aus einem Stream hinzugefügt werden können.

### **Untertitel aus einem Video‑Frame extrahieren**

Dieses Beispiel speichert alle Untertitelspuren von Video‑Frames auf der ersten Folie als separate WebVTT‑Dateien. Aufeinanderfolgende Nummern halten die Ausgabedateien eindeutig. Die Konsole gibt die Anzahl extrahierter Spuren aus. Die Präsentation muss mindestens eine Folie enthalten.

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;

Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int trackCount = 0;
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame) shape;
            for (ICaptions captionTrack : videoFrame.getCaptionTracks()) {
                trackCount++;
                try (FileOutputStream outputStream = new FileOutputStream("captions_" + trackCount + ".vtt")) {
                    outputStream.write(captionTrack.getBinaryData());
                }
            }
        }
    }

    System.out.println("Caption tracks extracted: " + trackCount);
} finally {
    presentation.dispose();
}
```

Jedes [ICaptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptions/)‑Objekt stellt den Untertitel‑Identifier, das Label, die Binärdaten und den Untertiteltext als UTF‑8‑String bereit.

### **Untertitel aus einem Video‑Frame entfernen**

Dieses Beispiel entfernt alle Untertitel aus dem Video‑Frame an der ersten Shape‑Position auf der ersten Folie und speichert das Ergebnis. Es wird davon ausgegangen, dass Folie und Shape existieren und dass das Shape ein Video‑Frame ist.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IVideoFrame videoFrame = (IVideoFrame) slide.getShapes().get_Item(0);
    videoFrame.getCaptionTracks().clear();

    presentation.save("video_without_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Wenn Sie nur eine Untertitelspur entfernen möchten, verwenden Sie die Methoden [remove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/captionscollection/#remove-com.aspose.slides.ICaptions-) oder [removeAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/captionscollection/#removeAt-int-) anstelle von [clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/captionscollection/#clear--).

### **Videountertitel durchsuchen**

[ICaptions.getDataAsString](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptions/#getDataAsString--) liefert die komplette WebVTT‑Spur, einschließlich Header, Zeitlinien und Untertiteltext. Sie können die Cues im Speicher durchsuchen, um eine gesprochene Phrase und ihren Zeitstempel zu finden. Zum Beispiel könnte eine englische Spur auf Folie 2 folgenden Text enthalten.

```text
WEBVTT Café tour

00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

Das Beispiel öffnet `captioned_media.pptx` und verwendet [IVideoFrame.getCaptionTracks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--) zum Auslesen der Spuren jedes Video‑Frames auf jeder Folie. In einem reinen Text‑Cue enthält die Zeitlinie `-->`, und eine leere Zeile beendet den Cue. Enthält ein Untertitel das Wort „café“ in beliebiger Groß‑/Kleinschreibung, gibt das Beispiel die Foliennummer, das Spuren‑Label, die originale Zeitlinie und den kompletten Untertitel aus.

```java
import com.aspose.slides.*;
import java.util.Locale;
import java.util.Scanner;

Presentation presentation = new Presentation("captioned_media.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (!(shape instanceof IVideoFrame)) {
                continue;
            }
            IVideoFrame videoFrame = (IVideoFrame) shape;
            for (ICaptions track : videoFrame.getCaptionTracks()) {
                try (Scanner reader = new Scanner(track.getDataAsString())) {
                    while (reader.hasNextLine()) {
                        String timing = reader.nextLine();
                        if (!timing.contains("-->")) {
                            continue;
                        }
                        StringBuilder caption = new StringBuilder();
                        while (reader.hasNextLine()) {
                            String line = reader.nextLine();
                            if (line.isEmpty()) {
                                break;
                            }
                            if (caption.length() > 0) {
                                caption.append('\n');
                            }
                            caption.append(line);
                        }
                        if (caption.toString().toLowerCase(Locale.ROOT).contains("café")) {
                            System.out.printf("Slide %d | %s | %s%n", slide.getSlideNumber(), track.getLabel(), timing);
                            System.out.println(caption);
                        }
                    }
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Die Suche nach „café“ liefert einen Treffer für die Beispielspur. Die Suche schließt den Spuren‑Header aus und behält die Zeitangabe in der Ausgabe bei.

```text
Slide 2 | English | 00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

## **Video aus einer Folie extrahieren**

Neben dem Hinzufügen von Videos zu Folien ermöglicht Aspose.Slides das Extrahieren von in Präsentationen eingebetteten Videos.

Dieses Beispiel extrahiert eingebettete Videos von jeder Folie in separate, nummerierte Binärdateien. Verknüpfte Videos werden übersprungen, da sie keine eingebetteten Daten besitzen. Die Konsole gibt den MIME‑Typ jedes Videos und die Gesamtanzahl aus. Die Ausgabe verwendet die generische Erweiterung `.bin`; passen Sie sie bei Bedarf an den gemeldeten Medientyp an.

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;

Presentation presentation = new Presentation("presentation_with_videos.pptx");
try {
    int videoCount = 0;
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IVideoFrame) {
                IVideoFrame videoFrame = (IVideoFrame) shape;
                IVideo video = videoFrame.getEmbeddedVideo();
                if (video == null) {
                    System.out.println("Skipped a linked video: no embedded data is available.");
                    continue;
                }

                videoCount++;
                try (FileOutputStream outputStream = new FileOutputStream("extracted_video_" + videoCount + ".bin")) {
                    outputStream.write(video.getBinaryData());
                }
                System.out.println("Video " + videoCount + ": " + video.getContentType());
            }
        }
    }

    System.out.println("Embedded videos extracted: " + videoCount);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Welche Wiedergabe‑Parameter können für ein Video‑Frame geändert werden?**

Sie können den [playback mode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayMode-int-) (automatisch oder per Klick) und die [looping](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) steuern. Diese Optionen stehen über die Methoden des [VideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/)‑Objekts zur Verfügung.

**Wirkt sich das Hinzufügen eines Videos auf die Dateigröße der PPTX‑Datei aus?**

Ja. Wenn Sie ein lokales Video einbetten, wird die Binärdatei in das Dokument aufgenommen, sodass die Präsentationsgröße proportional zur Dateigröße wächst. Wenn Sie auf ein Online‑Video verlinken und ein Thumbnail hinzufügen, speichert die Präsentation nur den Link und das Vorschaubild, nicht das Videomaterial, sodass die Größensteigerung in der Regel geringer ist.

**Kann ich das Video in einem bestehenden Video‑Frame ersetzen, ohne Position und Größe zu ändern?**

Ja. Sie können den [video content](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setEmbeddedVideo-com.aspose.slides.IVideo-) innerhalb des Frames austauschen, während die Geometrie der Shape erhalten bleibt; dies ist ein gängiges Szenario zum Aktualisieren von Medien in einem bestehenden Layout.

**Kann der Inhaltstyp (MIME) eines eingebetteten Videos ermittelt werden?**

Ja. Ein eingebettetes Video hat einen [content type](https://reference.aspose.com/slides/androidjava/com.aspose.slides/video/#getContentType--), den Sie auslesen und beispielsweise beim Speichern auf die Festplatte verwenden können.