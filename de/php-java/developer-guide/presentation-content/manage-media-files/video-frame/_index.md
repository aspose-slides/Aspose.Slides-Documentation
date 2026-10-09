---
title: Video-Frames in Präsentationen mit PHP verwalten
linktitle: Video-Frame
type: docs
weight: 10
url: /de/php-java/video-frame/
keywords:
- Video hinzufügen
- Video erstellen
- Video einbetten
- Video extrahieren
- Video abrufen
- Video-Frame
- Webquelle
- PowerPoint
- OpenDocument
- Präsentation
- PHP
- Aspose.Slides
description: "Erfahren Sie, wie Sie programmgesteuert Video-Frames in PowerPoint- und OpenDocument-Folien mit Aspose.Slides für PHP via Java hinzufügen und extrahieren. Schnelle Anleitung."
---
## **Einleitung**

Videos können dabei helfen, Ideen zu erläutern und ein Publikum zu fesseln. Aspose.Slides für PHP via Java ermöglicht das Hinzufügen von Video‑Frames zu Folien, das Anpassen von Wiedergabeeinstellungen, das Verwalten von Untertiteln und das Extrahieren eingebetteter Videodaten.

PowerPoint unterstützt lokale Videos sowie Verknüpfungen zu Online‑Videos, beispielsweise YouTube‑Videos.

Um Videodaten und Video‑Frames darzustellen, stellt Aspose.Slides die Klasse [Video](https://reference.aspose.com/slides/php-java/aspose.slides/video/), die Klasse [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/) und weitere relevante Typen bereit.

## **Einbetten eines lokalen Video‑Frames erstellen**

Wenn die Videodatei, die Sie Ihrer Folie hinzufügen möchten, lokal gespeichert ist, können Sie einen Video‑Frame erstellen, um das Video in Ihre Präsentation einzubetten.

Dieses Beispiel bettet ein lokales Video auf der ersten Folie einer bestehenden Präsentation ein und speichert das Ergebnis. Die Koordinaten und Abmessungen des Frames werden in Punkt angegeben. Der Stream bleibt geöffnet, bis das Speichern abgeschlossen ist, weil [LoadingStreamBehavior::KeepLocked](https://reference.aspose.com/slides/php-java/aspose.slides/loadingstreambehavior/) ihn gesperrt hält, solange die Präsentation ihn verwendet.

```php
use aspose\slides\LoadingStreamBehavior;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
$videoStream = null;
try {
    $videoStream = new Java("java.io.FileInputStream", "video.mp4");
    $slide = $presentation->getSlides()->get_Item(0);

    $video = $presentation->getVideos()->addVideo($videoStream, LoadingStreamBehavior::KeepLocked);
    $slide->getShapes()->addVideoFrame(10, 10, 150, 250, $video);

    $presentation->save("embedded_video.pptx", SaveFormat::Pptx);
} finally {
    if ($videoStream !== null) {
        $videoStream->close();
    }
    $presentation->dispose();
}
```

Sie können auch einen lokalen Videopfad direkt an [addVideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addVideoFrame) übergeben. Dieses Beispiel bettet das Video auf der ersten Folie einer neuen Präsentation ein. Das Video muss bis zum Speichern der Präsentation zugänglich bleiben.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $slide->getShapes()->addVideoFrame(50, 150, 300, 150, "video.avi");

    $presentation->save("video_from_path.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Erstellen eines Video‑Frames mit Video aus einer Web‑Quelle**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) unterstützt Online‑Videos in Präsentationen. Sie können einen Video‑Frame erstellen, der auf ein Online‑Video verweist, beispielsweise ein YouTube‑Video.

Dieses Beispiel fügt einen YouTube‑Video‑Link und ein Vorschaubild zur ersten Folie hinzu. Ersetzen Sie den Video‑Identifier, um ein anderes Video zu verwenden. Die Methode [setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayMode) fordert die automatische Wiedergabe an. Das Herunterladen des Vorschaubilds und das Abspielen des Videos erfordern Internetzugang. Der Präsentations‑Viewer muss ebenfalls die Online‑Videowiedergabe unterstützen.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\VideoPlayModePreset;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $videoId = "aqz-KE-bpKQ";
    $videoUrl = "https://www.youtube.com/embed/" . $videoId;
    $videoFrame = $slide->getShapes()->addVideoFrame(10, 10, 427, 240, $videoUrl);
    $videoFrame->setPlayMode(VideoPlayModePreset::Auto);

    $thumbnailUrl = "https://img.youtube.com/vi/" . $videoId . "/hqdefault.jpg";
    $thumbnailLocation = new Java("java.net.URL", $thumbnailUrl);
    $thumbnailStream = $thumbnailLocation->openStream();
    try {
        $thumbnail = $presentation->getImages()->addImage($thumbnailStream);
        $videoFrame->getPictureFormat()->getPicture()->setImage($thumbnail);
    } finally {
        $thumbnailStream->close();
    }

    $presentation->save("online_video.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Video im Vollbildmodus wiedergeben**

In einer Schulungspräsentation können Sie eine Software‑Demonstration im Vollbildmodus abspielen, damit das Publikum die Details sehen kann. Rufen Sie [setFullScreenMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setFullScreenMode) mit `true` auf, um dieses Verhalten während der Wiedergabe zu aktivieren.

Dieses Beispiel öffnet eine Präsentation, findet den ersten [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/) auf der ersten Folie und aktiviert die Vollbild‑Wiedergabe. Die Eingangs‑Präsentation muss mindestens eine Folie mit einem bereits vorhandenen Video‑Frame auf der ersten Folie enthalten.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("training.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
            $videoFrame = $shape;
            $videoFrame->setFullScreenMode(true);
            break;
        }
    }

    $presentation->save("full_screen_video.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Die Vollbild‑Wiedergabe steuert, wie das Video angezeigt wird. Unabhängig davon regelt [setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayMode) das automatische Starten oder den Start per Klick, und [setPlayLoopMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayLoopMode) steuert die Wiederholung. Um das Startverhalten festzulegen, setzen Sie den Wiedergabemodus auf [VideoPlayModePreset::Auto or VideoPlayModePreset::OnClick](https://reference.aspose.com/slides/php-java/aspose.slides/videoplaymodepreset/). Das Beispiel bewahrt die bestehenden Start‑ und Schleifeneinstellungen.

## **Video nach der Wiedergabe zurückspulen**

In einer Schulungspräsentation macht das Zurückspulen eines Demonstrationsvideos an den Anfang das Video wieder bereit für die erneute Wiedergabe. Rufen Sie [setRewindVideo](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setRewindVideo) mit `true` auf, um das Video nach Abschluss der Wiedergabe an den Anfang zurückzusetzen.

Dieses Beispiel öffnet eine Präsentation, findet den ersten [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/) auf der ersten Folie und aktiviert das Zurückspulen. Es deaktiviert die Schleife, damit die Wiedergabe beendet werden kann, und setzt die Wiedergabe auf Start per Klick. Die Eingangs‑Präsentation muss mindestens eine Folie mit einem bereits vorhandenen Video‑Frame auf der ersten Folie enthalten.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\VideoPlayModePreset;

$presentation = new Presentation("training.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
            $videoFrame = $shape;
            $videoFrame->setRewindVideo(true);
            $videoFrame->setPlayLoopMode(false);
            $videoFrame->setPlayMode(VideoPlayModePreset::OnClick);
            break;
        }
    }

    $presentation->save("rewind_video.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Das Zurückspulen setzt das Video auf den Anfang zurück, ohne es erneut zu starten. Im Gegensatz dazu wiederholt ein Aufruf von [setPlayLoopMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayLoopMode) mit `true` die Wiedergabe automatisch. Deaktivieren Sie die Schleife, wenn das Video vollständig beendet werden soll und danach bereit für eine erneute Wiedergabe ist. [setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayMode) steuert unabhängig davon das automatische bzw. klickbasierte Starten; dieses Beispiel verwendet [VideoPlayModePreset::OnClick](https://reference.aspose.com/slides/php-java/aspose.slides/videoplaymodepreset/), sodass der Präsentator entscheidet, wann die Wiedergabe beginnt. Setzen Sie den Wiedergabemodus nach der Schleifen‑Einstellung, wie im Beispiel gezeigt. Das Zurückspulen funktioniert unabhängig von [setFullScreenMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setFullScreenMode).

## **Video‑Frame zuschneiden**

Verwenden Sie [VideoFrame::setTrimFromStart](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setTrimFromStart) und [VideoFrame::setTrimFromEnd](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setTrimFromEnd), um zu Beginn oder am Ende eines Videos während der Wiedergabe Teile zu überspringen. Beide Werte werden in Millisekunden angegeben. Das Zuschneiden ändert die Wiedergabeeinstellungen, ohne die eingebetteten Videodaten zu verändern.

**Zuschneide‑Einstellungen festlegen**

Dieses Beispiel bettet ein lokales Video ein und überspringt die ersten 2,5 Sekunden sowie die letzte Sekunde während der Wiedergabe. Verwenden Sie ein Video, das länger als 3,5 Sekunden ist, damit ein abspielbarer Abschnitt erhalten bleibt.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $videoFile = new Java("java.io.File", "video.mp4");
    $videoPath = $videoFile->toPath();
    $videoData = java("java.nio.file.Files")->readAllBytes($videoPath);
    $video = $presentation->getVideos()->addVideo($videoData);

    $videoFrame = $slide->getShapes()->addVideoFrame(50, 50, 640, 360, $video);
    $videoFrame->setTrimFromStart(2500);
    $videoFrame->setTrimFromEnd(1000);

    $presentation->save("video_with_trim.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

**Zuschneide‑Einstellungen auslesen**

Dieses Beispiel gibt die Zuschneidewerte des ersten Video‑Frames auf der ersten Folie in Millisekunden aus. Die Präsentation muss mindestens eine Folie enthalten. Hat diese Folie keinen Video‑Frame, wird nichts ausgegeben. Das vorherige Beispiel erzeugt Werte von 2500 und 1000.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("video_with_trim.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
            $videoFrame = $shape;
            echo "Trim from start: " . java_values($videoFrame->getTrimFromStart()) . " ms\n";
            echo "Trim from end: " . java_values($videoFrame->getTrimFromEnd()) . " ms\n";
            break;
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Videountertitel verwalten**

Aspose.Slides ermöglicht das Verwalten von geschlossenen Untertiteln für Video‑Frames in PowerPoint‑Präsentationen. Untertitel werden im WebVTT‑Format gespeichert und über die Methode [VideoFrame::getCaptionTracks](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#getCaptionTracks) bereitgestellt.

**Untertitel zu einem Video‑Frame hinzufügen**

Dieses Beispiel bettet ein lokales Video ein und fügt einen WebVTT‑Untertitel‑Track mit der Bezeichnung English hinzu. Die Zeitstempel der Untertitel sollten mit dem Video übereinstimmen. Die gespeicherte Präsentation enthält sowohl das Video als auch seine Untertitel.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $videoFile = new Java("java.io.File", "video.mp4");
    $videoPath = $videoFile->toPath();
    $videoData = java("java.nio.file.Files")->readAllBytes($videoPath);
    $video = $presentation->getVideos()->addVideo($videoData);

    $videoFrame = $slide->getShapes()->addVideoFrame(0, 0, 100, 100, $video);
    $videoFrame->getCaptionTracks()->add("English", "track.vtt");

    $presentation->save("video_with_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Die Klasse [CaptionsCollection](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/) bietet ebenfalls eine Überladung, mit der Sie Untertitel aus einem Stream hinzufügen können.

**Untertitel aus einem Video‑Frame extrahieren**

Dieses Beispiel speichert alle Untertitel‑Tracks von Video‑Frames auf der ersten Folie als separate WebVTT‑Dateien. Fortlaufende Nummern halten die Ausgabedateien eindeutig. Die Konsole gibt die Anzahl extrahierter Tracks aus. Die Präsentation muss mindestens eine Folie enthalten.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("video_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $trackCount = 0;
    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
            $videoFrame = $shape;
            $captionCount = java_values($videoFrame->getCaptionTracks()->getCount());
            for ($trackIndex = 0; $trackIndex < $captionCount; $trackIndex++) {
                $captionTrack = $videoFrame->getCaptionTracks()->get_Item($trackIndex);
                $trackCount++;
                $outputStream = new Java("java.io.FileOutputStream", "captions_" . $trackCount . ".vtt");
                try {
                    $outputStream->write($captionTrack->getBinaryData());
                } finally {
                    $outputStream->close();
                }
            }
        }
    }

    echo "Caption tracks extracted: " . $trackCount . "\n";
} finally {
    $presentation->dispose();
}
```

Jedes [Captions](https://reference.aspose.com/slides/php-java/aspose.slides/captions/)‑Objekt stellt die Untertitel‑Kennung, das Label, die Binärdaten und den Untertiteltext als UTF‑8‑String bereit.

**Untertitel aus einem Video‑Frame entfernen**

Dieses Beispiel entfernt alle Untertitel aus dem Video‑Frame an der ersten Shape‑Position auf der ersten Folie und speichert das Ergebnis. Es wird davon ausgegangen, dass die Folie und das Shape existieren und dass das Shape ein Video‑Frame ist.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("video_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $videoFrame = $slide->getShapes()->get_Item(0);
    $videoFrame->getCaptionTracks()->clear();

    $presentation->save("video_without_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Wenn Sie nur einen Untertitel‑Track entfernen möchten, verwenden Sie die Methoden [remove](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#remove) oder [removeAt](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#removeAt) anstelle von [clear](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#clear).

## **Video aus einer Folie extrahieren**

Neben dem Hinzufügen von Videos zu Folien ermöglicht Aspose.Slides das Extrahieren von in Präsentationen eingebetteten Videos.

Dieses Beispiel extrahiert eingebettete Videos aus jeder Folie in separate, nummerierte Binärdateien. Verknüpfte Videos werden übersprungen, da sie keine eingebetteten Daten besitzen. Die Konsole gibt den MIME‑Typ jedes Videos und die Gesamtanzahl aus. Die Ausgabe verwendet die generische Erweiterung `.bin`; passen Sie sie bei Bedarf an den gemeldeten Medientyp an.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("presentation_with_videos.pptx");
try {
    $videoCount = 0;
    $slideCount = java_values($presentation->getSlides()->size());
    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $shapeCount = java_values($slide->getShapes()->size());
        for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
                $videoFrame = $shape;
                $video = $videoFrame->getEmbeddedVideo();
                if (java_is_null($video)) {
                    echo "Skipped a linked video: no embedded data is available.\n";
                    continue;
                }

                $videoCount++;
                $outputStream = new Java("java.io.FileOutputStream", "extracted_video_" . $videoCount . ".bin");
                try {
                    $outputStream->write($video->getBinaryData());
                } finally {
                    $outputStream->close();
                }
                echo "Video " . $videoCount . ": " . java_values($video->getContentType()) . "\n";
            }
        }
    }

    echo "Embedded videos extracted: " . $videoCount . "\n";
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Welche Wiedergabe‑Parameter können für einen Video‑Frame geändert werden?**

Sie können den [Wiedergabemodus](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayMode) (automatisch oder per Klick) und das [Looping](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayLoopMode) steuern. Diese Optionen stehen über die Methoden des [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/)‑Objekts zur Verfügung.

**Wirkt sich das Hinzufügen eines Videos auf die Dateigröße der PPTX aus?**

Ja. Beim Einbetten eines lokalen Videos werden die Binärdaten in das Dokument aufgenommen, sodass die Präsentationsgröße proportional zur Dateigröße des Videos wächst. Wenn Sie ein Online‑Video verknüpfen und ein Vorschaubild hinzufügen, speichert die Präsentation lediglich den Link und das Vorschaubild, nicht die Videodaten, sodass die Größenzunahme in der Regel geringer ist.

**Kann ich das Video in einem bestehenden Video‑Frame ersetzen, ohne Position und Größe zu ändern?**

Ja. Sie können den [Video‑Inhalt](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setEmbeddedVideo) innerhalb des Frames austauschen und dabei die Geometrie der Form beibehalten; dies ist ein gängiges Szenario für das Aktualisieren von Medien in einem bestehenden Layout.

**Kann der Inhaltstyp (MIME) eines eingebetteten Videos ermittelt werden?**

Ja. Ein eingebettetes Video verfügt über einen [Content‑Type](https://reference.aspose.com/slides/php-java/aspose.slides/video/#getContentType), den Sie auslesen und beispielsweise beim Speichern auf dem Datenträger verwenden können.