---
title: Verwalten von Video-Frames in Präsentationen mit Java
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
description: "Lernen Sie, wie Sie programmgesteuert Video-Frames in PowerPoint- und OpenDocument-Folien mit Aspose.Slides für Java hinzufügen und extrahieren. Schnelle Anleitung."
---
## **Einleitung**

Videos können dabei helfen, Ideen zu erklären und ein Publikum zu fesseln. Aspose.Slides for Java ermöglicht das Hinzufügen von Videoframes zu Folien, das Anpassen von Wiedergabeeinstellungen, das Verwalten von Untertiteln und das Extrahieren eingebetteter Videodaten.

PowerPoint unterstützt lokale Videos und Links zu Online‑Videos, wie z. B. YouTube‑Videos.

Um Videodaten und Videoframes darzustellen, stellt Aspose.Slides das Interface [IVideo](https://reference.aspose.com/slides/java/com.aspose.slides/ivideo/) und das Interface [IVideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/) sowie weitere relevante Typen bereit.

## **Ein eingebettetes Video‑Frame erstellen**

Wenn die Videodatei, die Sie Ihrer Folie hinzufügen möchten, lokal gespeichert ist, können Sie ein Videoframe erstellen, um das Video in Ihre Präsentation einzubetten.

Dieses Beispiel bettet ein lokales Video auf der ersten Folie einer vorhandenen Präsentation ein und speichert das Ergebnis. Die Koordinaten und Abmessungen des Frames sind in Punkten angegeben. Der Stream bleibt geöffnet, bis das Speichern abgeschlossen ist, weil [LoadingStreamBehavior.KeepLocked](https://reference.aspose.com/slides/java/com.aspose.slides/loadingstreambehavior/) ihn gesperrt hält, solange die Präsentation ihn verwendet.

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

Sie können zudem einen lokalen Videopfad direkt an [addVideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-java.lang.String-) übergeben. Dieses Beispiel bettet das Video auf der ersten Folie einer neuen Präsentation ein. Das Video muss bis zum Speichern der Präsentation zugänglich bleiben.

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

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) unterstützt Online‑Videos in Präsentationen. Sie können ein Video‑Frame erstellen, das auf ein Online‑Video, zum Beispiel ein YouTube‑Video, verlinkt.

Dieses Beispiel fügt der ersten Folie einen YouTube‑Video‑Link und ein Vorschaubild hinzu. Ersetzen Sie den Video‑Bezeichner, um ein anderes Video zu verwenden. Die Methode [setPlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/#setPlayMode-int-) fordert die automatische Wiedergabe an. Das Herunterladen des Vorschaubilds und das Abspielen des Videos benötigen Internetzugang. Der Präsentations‑Viewer muss außerdem die Online‑Video‑Wiedergabe unterstützen.

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

## **Ein Video im Vollbildmodus abspielen**

In einer Schulungspräsentation können Sie eine Software‑Demonstration im Vollbildmodus abspielen, damit das Publikum die Details sehen kann. Rufen Sie [setFullScreenMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setFullScreenMode-boolean-) mit `true` auf, um dieses Verhalten während der Wiedergabe zu aktivieren.

Dieses Beispiel öffnet eine Präsentation, findet das erste [IVideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/) auf der ersten Folie und aktiviert die Wiedergabe im Vollbildmodus. Die Eingabepräsentation muss mindestens eine Folie mit einem bereits vorhandenen Video‑Frame auf der ersten Folie enthalten.

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

Die Vollbild‑Wiedergabe bestimmt, wie das Video angezeigt wird. Unabhängig davon steuert [setPlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayMode-int-) ob es automatisch oder per Klick startet, und [setPlayLoopMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) legt fest, ob es wiederholt wird. Um das Startverhalten zu wählen, setzen Sie den Wiedergabemodus auf [VideoPlayModePreset.Auto oder VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/java/com.aspose.slides/videoplaymodepreset/). Das Beispiel bewahrt die vorhandenen Start‑ und Schleife‑Einstellungen.

## **Ein Video nach der Wiedergabe zurückspulen**

In einer Schulungspräsentation stellt das Zurückspulen eines Demonstrationsvideos zum Anfang sicher, dass es vom Vortragenden erneut abgespielt werden kann. Rufen Sie [setRewindVideo](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setRewindVideo-boolean-) mit `true` auf, um das Video nach Abschluss der Wiedergabe zum Anfang zurückzusetzen.

Dieses Beispiel öffnet eine Präsentation, findet das erste [IVideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/) auf der ersten Folie und aktiviert das Zurückspulen. Es deaktiviert die Schleife, damit die Wiedergabe beendet werden kann, und legt die Wiedergabe so fest, dass sie per Klick startet. Die Eingabepräsentation muss mindestens eine Folie mit einem vorhandenen Video‑Frame auf der ersten Folie enthalten.

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

Das Zurückspulen setzt das Video auf den Anfang zurück, ohne es erneut zu starten. Im Gegensatz dazu wiederholt ein Aufruf von [setPlayLoopMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) mit `true` die Wiedergabe automatisch. Deaktivieren Sie die Schleife, wenn das Video zu Ende laufen und bereit für eine erneute Wiedergabe sein soll. [setPlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayMode-int-) steuert unabhängig davon, ob die Wiedergabe automatisch oder per Klick startet; dieses Beispiel verwendet [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/java/com.aspose.slides/videoplaymodepreset/), sodass der Vortragende bestimmt, wann die Wiedergabe beginnt. Setzen Sie den Wiedergabemodus nach der Schleifeinstellung, wie im Beispiel gezeigt. Das Zurückspulen funktioniert unabhängig von [setFullScreenMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setFullScreenMode-boolean-).

## **Ein Video‑Frame zuschneiden**

Verwenden Sie [IVideoFrame.setTrimFromStart](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/#setTrimFromStart-float-) und [IVideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/#setTrimFromEnd-float-), um zu Beginn oder am Ende eines Videos während der Wiedergabe einen Teil zu überspringen. Beide Werte sind in Millisekunden angegeben. Das Zuschneiden ändert die Wiedergabeeinstellungen, ohne die eingebetteten Videodaten zu verändern.

**Trim-Einstellungen festlegen**

Dieses Beispiel bettet ein lokales Video ein und überspringt während der Wiedergabe die ersten 2,5 Sekunden und die letzte Sekunde. Verwenden Sie ein Video, das länger als 3,5 Sekunden ist, damit ein abspielbarer Abschnitt erhalten bleibt.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    Path videoPath = Paths.get("video.mp4");
    byte[] videoData = Files.readAllBytes(videoPath);
    IVideo video = presentation.getVideos().addVideo(videoData);

    IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 640, 360, video);
    videoFrame.setTrimFromStart(2500f);
    videoFrame.setTrimFromEnd(1000f);

    presentation.save("video_with_trim.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Trim-Einstellungen auslesen**

Dieses Beispiel gibt die Trimmwerte des ersten Video‑Frames auf der ersten Folie in Millisekunden aus. Die Präsentation muss mindestens eine Folie enthalten. Hat diese Folie keinen Video‑Frame, wird nichts ausgegeben. Das vorherige Beispiel erzeugt die Werte 2500 und 1000.

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

## **Video‑Captions verwalten**

Aspose.Slides ermöglicht das Verwalten von Closed‑Captions für Video‑Frames in PowerPoint‑Präsentationen. Captions werden im WebVTT‑Format gespeichert und über die Methode [IVideoFrame.getCaptionTracks](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/#getCaptionTracks--) bereitgestellt.

**Captions zu einem Video‑Frame hinzufügen**

Dieses Beispiel bettet ein lokales Video ein und fügt eine WebVTT‑Caption‑Spur mit dem Label English hinzu. Die Zeitstempel der Captions sollten zum Video passen. Die gespeicherte Präsentation enthält sowohl das Video als auch seine Captions.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    Path videoPath = Paths.get("video.mp4");
    byte[] videoData = Files.readAllBytes(videoPath);
    IVideo video = presentation.getVideos().addVideo(videoData);

    IVideoFrame videoFrame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video);
    videoFrame.getCaptionTracks().add("English", "track.vtt");

    presentation.save("video_with_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Das Interface [ICaptionsCollection](https://reference.aspose.com/slides/java/com.aspose.slides/icaptionscollection/) bietet ebenfalls eine Überladung, mit der Sie Captions aus einem Stream hinzufügen können.

**Captions aus einem Video‑Frame extrahieren**

Dieses Beispiel speichert alle Caption‑Spuren von Video‑Frames auf der ersten Folie als separate WebVTT‑Dateien. Fortlaufende Nummern halten die Ausgabedateien eindeutig. Die Konsole gibt die Anzahl der extrahierten Spuren aus. Die Präsentation muss mindestens eine Folie enthalten.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int trackCount = 0;
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame) shape;
            for (ICaptions captionTrack : videoFrame.getCaptionTracks()) {
                trackCount++;
                Path outputPath = Paths.get("captions_" + trackCount + ".vtt");
                Files.write(outputPath, captionTrack.getBinaryData());
            }
        }
    }

    System.out.println("Caption tracks extracted: " + trackCount);
} finally {
    presentation.dispose();
}
```

Jedes [ICaptions](https://reference.aspose.com/slides/java/com.aspose.slides/icaptions/)‑Objekt stellt den Caption‑Bezeichner, das Label, die Binärdaten und den Caption‑Text als UTF‑8‑Zeichenkette bereit.

**Captions von einem Video‑Frame entfernen**

Dieses Beispiel entfernt alle Captions vom Video‑Frame an der ersten Shape‑Position auf der ersten Folie und speichert das Ergebnis. Es wird davon ausgegangen, dass die Folie und das Shape existieren und dass das Shape ein Video‑Frame ist.

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

Wenn Sie nur eine Caption‑Spur entfernen müssen, verwenden Sie die Methoden [remove](https://reference.aspose.com/slides/java/com.aspose.slides/captionscollection/#remove-com.aspose.slides.ICaptions-) oder [removeAt](https://reference.aspose.com/slides/java/com.aspose.slides/captionscollection/#removeAt-int-) , anstatt [clear](https://reference.aspose.com/slides/java/com.aspose.slides/captionscollection/#clear--).

## **Video aus einer Folie extrahieren**

Neben dem Hinzufügen von Videos zu Folien ermöglicht Aspose.Slides das Extrahieren von in Präsentationen eingebetteten Videos.

Dieses Beispiel extrahiert eingebettete Videos von jeder Folie in separate, nummerierte Binärdateien. Verknüpfte Videos werden übersprungen, da sie keine eingebetteten Daten besitzen. Die Konsole gibt den MIME‑Typ jedes Videos und die Gesamtanzahl aus. Die Ausgabe verwendet die generische Erweiterung `.bin`; passen Sie sie bei Bedarf dem gemeldeten Medientyp an.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

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
                Path outputPath = Paths.get("extracted_video_" + videoCount + ".bin");
                Files.write(outputPath, video.getBinaryData());
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

**Welche Videowiedergabe‑Parameter können für ein Video‑Frame geändert werden?**

Sie können den [playback mode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayMode-int-) (automatisch oder per Klick) und das [looping](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) steuern. Diese Optionen stehen über die Methoden des [VideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/)‑Objekts zur Verfügung.

**Beeinflusst das Hinzufügen eines Videos die PPTX-Dateigröße?**

Ja. Wenn Sie ein lokales Video einbetten, werden die Binärdaten in das Dokument aufgenommen, sodass die Präsentationsgröße proportional zur Dateigröße wächst. Wenn Sie auf ein Online‑Video verlinken und ein Vorschaubild hinzufügen, speichert die Präsentation den Link und das Vorschaubild statt der Videodaten, sodass die Größenzunahme in der Regel geringer ist.

**Kann ich das Video in einem vorhandenen Video‑Frame ersetzen, ohne Position und Größe zu ändern?**

Ja. Sie können den [video content](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setEmbeddedVideo-com.aspose.slides.IVideo-) innerhalb des Frames austauschen, während Sie die Geometrie des Shapes beibehalten; dies ist ein häufiges Szenario zum Aktualisieren von Medien in einem bestehenden Layout.

**Kann der Content‑Typ (MIME) eines eingebetteten Videos bestimmt werden?**

Ja. Ein eingebettetes Video verfügt über einen [content type](https://reference.aspose.com/slides/java/com.aspose.slides/video/#getContentType--) , den Sie auslesen und beispielsweise beim Speichern auf die Festplatte verwenden können.