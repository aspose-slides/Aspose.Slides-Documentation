---
title: Verwalten von Video-Frames in Präsentationen mit Node.js
linktitle: Video-Frame
type: docs
weight: 10
url: /de/nodejs-java/video-frame/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Lernen Sie, wie Sie programmgesteuert Video-Frames in PowerPoint- und OpenDocument-Folien mit Aspose.Slides für Node.js über Java hinzufügen und extrahieren. Schnell‑Anleitung."
---
## **Einleitung**

Videos können helfen, Ideen zu erklären und ein Publikum zu fesseln. Aspose.Slides für Node.js über Java ermöglicht das Hinzufügen von Videoframes zu Folien, das Anpassen von Wiedergabeeinstellungen, die Verwaltung von Untertiteln und das Extrahieren eingebetteter Videodaten.

PowerPoint unterstützt lokale Videos und Links zu Online‑Videos, wie zum Beispiel YouTube‑Videos.

Um Videodaten und Videoframes darzustellen, stellt Aspose.Slides die Klasse [Video](https://reference.aspose.com/slides/nodejs-java/aspose.slides/video/) und die Klasse [VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/) sowie weitere relevante Typen bereit.

## **Erstellen eines eingebetteten Video‑Frames**

Wenn die Videodatei, die Sie Ihrer Folie hinzufügen möchten, lokal gespeichert ist, können Sie ein Video‑Frame erstellen, um das Video in Ihre Präsentation einzubetten.

Dieses Beispiel bettet ein lokales Video auf der ersten Folie einer bestehenden Präsentation ein und speichert das Ergebnis. Frame‑Koordinaten und -Abmessungen sind in Punkt angegeben. Der Stream bleibt geöffnet, bis das Speichern abgeschlossen ist, weil [LoadingStreamBehavior.KeepLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadingstreambehavior/) ihn gesperrt hält, solange die Präsentation ihn verwendet.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const videoStream = java.newInstanceSync("java.io.FileInputStream", "video.mp4");
    try {
        const slide = presentation.getSlides().get_Item(0);

        const video = presentation.getVideos().addVideo(videoStream, aspose.slides.LoadingStreamBehavior.KeepLocked);
        slide.getShapes().addVideoFrame(10, 10, 150, 250, video);

        presentation.save("embedded_video.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        videoStream.close();
    }
} finally {
    presentation.dispose();
}
```

Sie können auch einen lokalen Videopfad direkt an [addVideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addvideoframe/) übergeben. Dieses Beispiel bettet das Video auf der ersten Folie einer neuen Präsentation ein. Das Video muss bis zum Speichern der Präsentation zugänglich bleiben.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    slide.getShapes().addVideoFrame(50, 150, 300, 150, "video.avi");

    presentation.save("video_from_path.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Erstellen eines Video‑Frames mit Video aus einer Web‑Quelle**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) unterstützt Online‑Videos in Präsentationen. Sie können ein Video‑Frame erstellen, das auf ein Online‑Video, etwa ein YouTube‑Video, verlinkt.

Dieses Beispiel fügt einen YouTube‑Video‑Link und ein Vorschaubild zur ersten Folie hinzu. Ersetzen Sie den Video‑Identifikator, um ein anderes Video zu verwenden. Die Methode [setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplaymode/) fordert die automatische Wiedergabe an. Das Herunterladen des Vorschaubildes und die Videowiedergabe erfordern Internetzugriff. Der Präsentations‑Viewer muss ebenfalls die Wiedergabe von Online‑Videos unterstützen.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const videoId = "aqz-KE-bpKQ";
    const videoUrl = "https://www.youtube.com/embed/" + videoId;
    const videoFrame = slide.getShapes().addVideoFrame(10, 10, 427, 240, videoUrl);
    videoFrame.setPlayMode(aspose.slides.VideoPlayModePreset.Auto);

    const thumbnailUrl = "https://img.youtube.com/vi/" + videoId + "/hqdefault.jpg";
    const thumbnailLocation = java.newInstanceSync("java.net.URL", thumbnailUrl);
    const thumbnailStream = thumbnailLocation.openStream();
    try {
        const thumbnail = presentation.getImages().addImage(thumbnailStream);
        videoFrame.getPictureFormat().getPicture().setImage(thumbnail);
    } finally {
        thumbnailStream.close();
    }

    presentation.save("online_video.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Video im Vollbildmodus wiedergeben**

In einer Schulungspräsentation können Sie eine Software‑Demonstration im Vollbildmodus abspielen, damit das Publikum die Details sehen kann. Rufen Sie [setFullScreenMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setfullscreenmode/) mit `true` auf, um dieses Verhalten während der Wiedergabe zu aktivieren.

Dieses Beispiel öffnet eine Präsentation, findet das erste [VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/) auf der ersten Folie und aktiviert die Vollbild‑Wiedergabe. Die Eingabepäsentation muss mindestens eine Folie mit einem vorhandenen Video‑Frame auf der ersten Folie enthalten.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("training.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
            const videoFrame = shape;
            videoFrame.setFullScreenMode(true);
            break;
        }
    }

    presentation.save("full_screen_video.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Die Vollbild‑Wiedergabe bestimmt, wie das Video angezeigt wird. Unabhängig davon steuert [setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplaymode/), ob es automatisch oder per Klick startet, und [setPlayLoopMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplayloopmode/) steuert, ob es wiederholt wird. Um das Startverhalten zu wählen, setzen Sie den Wiedergabemodus auf [VideoPlayModePreset.Auto or VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoplaymodepreset/). Das Beispiel behält die bestehenden Start‑ und Schleifeinstellungen bei.

## **Video nach Wiedergabe zurückspulen**

In einer Schulungspräsentation macht es Sinn, ein Demonstrationsvideo nach dem Abspielen wieder an den Anfang zu setzen, damit der Präsentierer es erneut starten kann. Rufen Sie [setRewindVideo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setrewindvideo/) mit `true` auf, um das Video nach Abschluss der Wiedergabe zurückzuspulen.

Dieses Beispiel öffnet eine Präsentation, findet das erste [VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/) auf der ersten Folie und aktiviert das Zurückspulen. Es deaktiviert das Schleifen, damit die Wiedergabe beendet werden kann, und setzt die Wiedergabe auf Start per Klick. Die Eingabepäsentation muss mindestens eine Folie mit einem vorhandenen Video‑Frame auf der ersten Folie enthalten.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("training.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
            const videoFrame = shape;
            videoFrame.setRewindVideo(true);
            videoFrame.setPlayLoopMode(false);
            videoFrame.setPlayMode(aspose.slides.VideoPlayModePreset.OnClick);
            break;
        }
    }

    presentation.save("rewind_video.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Das Zurückspulen setzt das Video wieder an den Anfang, ohne es erneut zu starten. Im Gegensatz dazu wiederholt [setPlayLoopMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplayloopmode/) mit `true` die Wiedergabe automatisch. Deaktivieren Sie das Schleifen, wenn das Video bis zum Ende laufen und anschließend bereit zum erneuten Abspielen sein soll. [setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplaymode/) steuert unabhängig davon, ob die Wiedergabe automatisch oder per Klick startet; dieses Beispiel verwendet [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoplaymodepreset/), sodass der Präsentierer entscheidet, wann die Wiedergabe beginnt. Setzen Sie den Wiedergabemodus nach der Schleifeneinstellung, wie im Beispiel gezeigt. Das Zurückspulen funktioniert unabhängig von [setFullScreenMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setfullscreenmode/).

## **Ein Video‑Frame trimmen**

Verwenden Sie [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/settrimfromstart/) und [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/settrimfromend/), um zu Beginn oder am Ende eines Videos während der Wiedergabe Teile zu überspringen. Beide Werte werden in Millisekunden angegeben. Das Trimmen ändert die Wiedergabeeinstellungen, ohne die eingebetteten Videodaten zu verändern.

**Trim‑Einstellungen festlegen**

Dieses Beispiel bettet ein lokales Video ein und überspringt die ersten 2,5 Sekunden sowie die letzte Sekunde während der Wiedergabe. Verwenden Sie ein Video, das länger als 3,5 Sekunden ist, damit ein abspielbarer Abschnitt verbleibt.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const videoBuffer = fs.readFileSync("video.mp4");
    const videoData = java.newArray("byte", Array.from(videoBuffer));
    const video = presentation.getVideos().addVideo(videoData);

    const videoFrame = slide.getShapes().addVideoFrame(50, 50, 640, 360, video);
    videoFrame.setTrimFromStart(2500);
    videoFrame.setTrimFromEnd(1000);

    presentation.save("video_with_trim.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Trim‑Einstellungen auslesen**

Dieses Beispiel gibt die Trimmwerte des ersten Video‑Frames auf der ersten Folie in Millisekunden aus. Die Präsentation muss mindestens eine Folie enthalten. Wenn diese Folie keinen Video‑Frame hat, wird nichts ausgegeben. Das vorherige Beispiel liefert die Werte 2500 und 1000.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("video_with_trim.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
            const videoFrame = shape;
            console.log("Trim from start: " + videoFrame.getTrimFromStart() + " ms");
            console.log("Trim from end: " + videoFrame.getTrimFromEnd() + " ms");
            break;
        }
    }
} finally {
    presentation.dispose();
}
```

## **Video‑Untertitel verwalten**

Aspose.Slides ermöglicht die Verwaltung von geschlossenen Untertiteln für Video‑Frames in PowerPoint‑Präsentationen. Untertitel werden im WebVTT‑Format gespeichert und über die Methode [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/#getCaptionTracks) bereitgestellt.

**Untertitel zu einem Video‑Frame hinzufügen**

Dieses Beispiel bettet ein lokales Video ein und fügt eine WebVTT‑Untertitelspur mit der Bezeichnung English hinzu. Die Untertitel‑Zeitstempel sollten zum Video passen. Die gespeicherte Präsentation enthält sowohl das Video als auch seine Untertitel.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const videoBuffer = fs.readFileSync("video.mp4");
    const videoData = java.newArray("byte", Array.from(videoBuffer));
    const video = presentation.getVideos().addVideo(videoData);

    const videoFrame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video);
    videoFrame.getCaptionTracks().add("English", "track.vtt");

    presentation.save("video_with_captions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Die Klasse [CaptionsCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/) bietet zudem die Methode [addFromStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#addFromStream) zum Hinzufügen von Untertiteln aus einem Stream.

**Untertitel aus einem Video‑Frame extrahieren**

Dieses Beispiel speichert alle Untertitelspuren von Video‑Frames auf der ersten Folie als separate WebVTT‑Dateien. Durch fortlaufende Nummerierung bleiben die Ausgabedateien eindeutig. Die Konsole gibt die Anzahl der extrahierten Spuren aus. Die Präsentation muss mindestens eine Folie enthalten.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation("video_with_captions.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    let trackCount = 0;
    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
            const videoFrame = shape;
            for (let trackIndex = 0; trackIndex < videoFrame.getCaptionTracks().getCount(); trackIndex++) {
                const captionTrack = videoFrame.getCaptionTracks().get_Item(trackIndex);
                trackCount++;
                const outputPath = "captions_" + trackCount + ".vtt";
                const outputData = Buffer.from(captionTrack.getBinaryData());
                fs.writeFileSync(outputPath, outputData);
            }
        }
    }

    console.log("Caption tracks extracted: " + trackCount);
} finally {
    presentation.dispose();
}
```

Jedes [Captions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captions/)‑Objekt stellt die Untertitel‑Kennung, das Label, die Binärdaten und den Untertiteltext als UTF‑8‑Zeichenfolge bereit.

**Untertitel von einem Video‑Frame entfernen**

Dieses Beispiel entfernt alle Untertitel vom Video‑Frame an der ersten Shape‑Position auf der ersten Folie und speichert das Ergebnis. Es wird davon ausgegangen, dass die Folie und das Shape existieren und das Shape ein Video‑Frame ist.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("video_with_captions.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const videoFrame = slide.getShapes().get_Item(0);
    videoFrame.getCaptionTracks().clear();

    presentation.save("video_without_captions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Wenn Sie nur eine Untertitelspur entfernen möchten, verwenden Sie stattdessen die Methoden [remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#remove) oder [removeAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#removeAt) anstelle von [clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#clear).

## **Video aus einer Folie extrahieren**

Neben dem Hinzufügen von Videos zu Folien ermöglicht Aspose.Slides das Extrahieren von in Präsentationen eingebetteten Videos.

Dieses Beispiel extrahiert eingebettete Videos von jeder Folie in separate, nummerierte Binärdateien. Verlinkte Videos werden übersprungen, da sie keine eingebetteten Daten besitzen. Die Konsole gibt den MIME‑Typ jedes Videos und die Gesamtanzahl aus. Die Ausgabe verwendet die generische Erweiterung `.bin`; ändern Sie sie bei Bedarf, um dem gemeldeten Medientyp zu entsprechen.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation("presentation_with_videos.pptx");
try {
    let videoCount = 0;
    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
                const videoFrame = shape;
                const video = videoFrame.getEmbeddedVideo();
                if (video == null) {
                    console.log("Skipped a linked video: no embedded data is available.");
                    continue;
                }

                videoCount++;
                const outputPath = "extracted_video_" + videoCount + ".bin";
                const outputData = Buffer.from(video.getBinaryData());
                fs.writeFileSync(outputPath, outputData);
                console.log("Video " + videoCount + ": " + video.getContentType());
            }
        }
    }

    console.log("Embedded videos extracted: " + videoCount);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Welche Wiedergabeparameter können für ein Video‑Frame geändert werden?**

Sie können den [Wiedergabemodus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplaymode/) (automatisch oder per Klick) und das [Schleifen](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplayloopmode/) steuern. Diese Optionen stehen über die Methoden des [VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/)-Objekts zur Verfügung.

**Vergrößert das Hinzufügen eines Videos die PPTX-Dateigröße?**

Ja. Wenn Sie ein lokales Video einbetten, wird die Binärdatei in das Dokument aufgenommen, sodass die Präsentationsgröße proportional zur Dateigröße wächst. Wenn Sie dagegen zu einem Online‑Video verlinken und ein Vorschaubild hinzufügen, speichert die Präsentation lediglich den Link und das Bild, nicht das eigentliche Videomaterial, sodass der Größenzuwachs in der Regel geringer ist.

**Kann ich das Video in einem bestehenden Video‑Frame ersetzen, ohne Position und Größe zu ändern?**

Ja. Sie können den [Video‑Inhalt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setembeddedvideo/) im Frame austauschen, während die Geometrie der Form erhalten bleibt; dies ist ein gängiges Szenario zum Aktualisieren von Medien in einem bestehenden Layout.

**Kann der Inhaltstyp (MIME) eines eingebetteten Videos ermittelt werden?**

Ja. Ein eingebettetes Video verfügt über einen [Content‑Type](https://reference.aspose.com/slides/nodejs-java/aspose.slides/video/getcontenttype/), den Sie lesen und beispielsweise beim Speichern auf die Festplatte verwenden können.