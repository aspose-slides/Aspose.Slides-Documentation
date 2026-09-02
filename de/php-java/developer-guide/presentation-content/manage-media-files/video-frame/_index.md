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
description: "Erfahren Sie, wie Sie programmgesteuert Video-Frames in PowerPoint- und OpenDocument-Folien mit Aspose.Slides für PHP über Java hinzufügen und extrahieren. Schnelle Kurz-Anleitung."
---
## **Einführung**

Ein gut platziertes Video in einer Präsentation kann Ihre Botschaft überzeugender machen und das Engagement Ihres Publikums erhöhen. 

PowerPoint ermöglicht das Hinzufügen von Videos zu einer Folie in einer Präsentation auf zwei Arten:

* Ein lokales Video hinzufügen oder einbetten (auf Ihrem Rechner gespeichert)
* Ein Online-Video hinzufügen (von einer Webquelle wie YouTube).

Um Ihnen das Hinzufügen von Videos (Videoobjekten) zu einer Präsentation zu ermöglichen, stellt Aspose.Slides die Klasse [Video](https://reference.aspose.com/slides/de/php-java/aspose.slides/video/) , die Klasse [VideoFrame](https://reference.aspose.com/slides/de/php-java/aspose.slides/videoframe/) und andere relevante Typen bereit.

## **Erstellen eingebetteter Video-Frames**

Wenn die Videodatei, die Sie zu Ihrer Folie hinzufügen möchten, lokal gespeichert ist, können Sie einen Video-Frame erstellen, um das Video in Ihre Präsentation einzubetten. 

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/).
1. Holen Sie sich eine Referenz auf eine Folie über deren Index. 
1. Fügen Sie ein [Video](https://reference.aspose.com/slides/de/php-java/aspose.slides/video/)-Objekt hinzu und übergeben Sie den Pfad zur Videodatei, um das Video in die Präsentation einzubetten.
1. Fügen Sie ein [VideoFrame](https://reference.aspose.com/slides/de/php-java/aspose.slides/videoframe/)-Objekt hinzu, um einen Frame für das Video zu erstellen.
1. Speichern Sie die geänderte Präsentation. 

Dieser PHP‑Code zeigt, wie Sie ein lokal gespeichertes Video zu einer Präsentation hinzufügen:

```php
  # Instanziert die Presentation-Klasse
  $pres = new Presentation("pres.pptx");
  try {
    # Lädt das Video
    $fileStream = new Java("java.io.FileInputStream", "Wildlife.mp4");
    $video = $pres->getVideos()->addVideo($fileStream, LoadingStreamBehavior->KeepLocked);
    # Ermittelt die erste Folie und fügt einen Video-Frame hinzu
    $pres->getSlides()->get_Item(0)->getShapes()->addVideoFrame(10, 10, 150, 250, $video);
    # Speichert die Präsentation auf der Festplatte
    $pres->save("pres-with-video.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Alternativ können Sie ein Video hinzufügen, indem Sie dessen Dateipfad direkt an die Methode [addVideoFrame(float x, float y, float width, float height, Video video)](https://reference.aspose.com/slides/de/php-java/aspose.slides/shapecollection/addvideoframe/) übergeben:

```php
  $pres = new Presentation();
  try {
    $sld = $pres->getSlides()->get_Item(0);
    $vf = $sld->getShapes()->addVideoFrame(50, 150, 300, 150, "video1.avi");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Video-Frames mit Videos aus Webquellen erstellen**

Microsoft [PowerPoint 2013 und neuer](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) unterstützt YouTube‑Videos in Präsentationen. Wenn das Video, das Sie verwenden möchten, online verfügbar ist (z. B. auf YouTube), können Sie es über dessen Weblink zu Ihrer Präsentation hinzufügen. 

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/) .
1. Holen Sie sich eine Referenz auf eine Folie über deren Index. 
1. Fügen Sie ein [Video](https://reference.aspose.com/slides/de/php-java/aspose.slides/video/)-Objekt hinzu und übergeben Sie den Link zum Video.
1. Legen Sie ein Miniaturbild für den Video-Frame fest. 
1. Speichern Sie die Präsentation. 

Dieser PHP‑Code zeigt, wie Sie ein Video aus dem Web zu einer Folie in einer PowerPoint‑Präsentation hinzufügen:

```php
  # Instanziert ein Presentation-Objekt, das eine Präsentationsdatei darstellt
  $pres = new Presentation();
  try {
    addVideoFromYouTube($pres, "Tj75Arhq5ho");
    $pres->save("out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

```php

```

## **Trimmen eines Video-Frames**

Aspose.Slides ermöglicht es Ihnen, zu steuern, welcher Teil eines Videos abgespielt wird, indem Sie die Werte trim-from-start und trim-from-end über [VideoFrame::setTrimFromStart](https://reference.aspose.com/slides/de/php-java/aspose.slides/videoframe/#setTrimFromStart) und [VideoFrame::setTrimFromEnd](https://reference.aspose.com/slides/de/php-java/aspose.slides/videoframe/#setTrimFromEnd) festlegen. Beide Werte werden in Millisekunden angegeben und definieren, wie viel Zeit zu Beginn bzw. am Ende des Videos übersprungen wird. Diese Einstellungen verändern die Wiedergabeeigenschaften des Videos in der Präsentation; sie schneiden das eingebettete Videobinary nicht zu oder ändern es anderweitig.

**Trim‑Einstellungen festlegen**

So erstellen Sie einen Video-Frame und setzen seine Trim‑Einstellungen:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/) .
1. Fügen Sie ein [Video](https://reference.aspose.com/slides/de/php-java/aspose.slides/video/)-Objekt zur Präsentation hinzu.
1. Fügen Sie ein [VideoFrame](https://reference.aspose.com/slides/de/php-java/aspose.slides/videoframe/)-Objekt zu einer Folie hinzu.
1. Setzen Sie die Werte trim-from-start und trim-from-end über [VideoFrame::setTrimFromStart](https://reference.aspose.com/slides/de/php-java/aspose.slides/videoframe/#setTrimFromStart) und [VideoFrame::setTrimFromEnd](https://reference.aspose.com/slides/de/php-java/aspose.slides/videoframe/#setTrimFromEnd).
1. Speichern Sie die geänderte Präsentation.

Das folgende Codebeispiel überspringt die ersten 2,5 Sekunden und die letzte Sekunde eines eingebetteten Videos während der Wiedergabe:

```php
$presentation = new Presentation();
$videoStream = null;
try {
    $videoStream = new Java("java.io.FileInputStream", "video.mp4");
    $video = $presentation->getVideos()->addVideo(
        $videoStream, LoadingStreamBehavior::ReadStreamAndRelease);
    $slide = $presentation->getSlides()->get_Item(0);
    $videoFrame = $slide->getShapes()->addVideoFrame(50, 50, 640, 360, $video);

    $videoFrame->setTrimFromStart(2500);
    $videoFrame->setTrimFromEnd(1000);

    $presentation->save("video_with_trim.pptx", SaveFormat::Pptx);
} finally {
    if ($videoStream !== null) {
        $videoStream->close();
    }
    $presentation->dispose();
}
```

**Trim‑Einstellungen auslesen**

Um vorhandene Trim‑Einstellungen zu prüfen, laden Sie eine Präsentation, finden Sie ein [VideoFrame](https://reference.aspose.com/slides/de/php-java/aspose.slides/videoframe/)-Objekt unter den Formen auf der ersten Folie und lesen Sie die Werte über [VideoFrame::getTrimFromStart](https://reference.aspose.com/slides/de/php-java/aspose.slides/videoframe/#getTrimFromStart) und [VideoFrame::getTrimFromEnd](https://reference.aspose.com/slides/de/php-java/aspose.slides/videoframe/#getTrimFromEnd).

Das folgende Codebeispiel findet den ersten Video-Frame auf der ersten Folie und gibt seine Trim‑Einstellungen in Millisekunden aus:

```php
$presentation = new Presentation("video_with_trim.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
            $videoFrame = $shape;
            $trimFromStart = java_values($videoFrame->getTrimFromStart());
            $trimFromEnd = java_values($videoFrame->getTrimFromEnd());

            echo "Trim from start: " . $trimFromStart . " ms\n";
            echo "Trim from end: " . $trimFromEnd . " ms\n";
            break;
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Video-Untertitel verwalten**

Aspose.Slides ermöglicht es Ihnen, geschlossene Untertitel für Video-Frames in PowerPoint‑Präsentationen zu verwalten. Untertitel werden im WebVTT‑Format gespeichert und über die Methode [VideoFrame::getCaptionTracks](https://reference.aspose.com/slides/de/php-java/aspose.slides/videoframe/#getCaptionTracks) bereitgestellt.

**Untertitel zu einem Video-Frame hinzufügen**

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/) .
1. Fügen Sie ein Video zur Präsentation hinzu.
1. Fügen Sie ein [VideoFrame](https://reference.aspose.com/slides/de/php-java/aspose.slides/videoframe/)‑Objekt zu einer Folie hinzu.
1. Verwenden Sie die Sammlung [CaptionsCollection](https://reference.aspose.com/slides/de/php-java/aspose.slides/captionscollection/), die von [getCaptionTracks](https://reference.aspose.com/slides/de/php-java/aspose.slides/videoframe/#getCaptionTracks) zurückgegeben wird, um eine WebVTT‑Untertitelspur hinzuzufügen.
1. Speichern Sie die geänderte Präsentation.

Der folgende Code zeigt, wie Sie Untertitel zu einem Video-Frame hinzufügen:

```php
$presentation = new Presentation();
try {
    $videoData = file_get_contents("video.mp4");
    $video = $presentation->getVideos()->addVideo($videoData);

    $slide = $presentation->getSlides()->get_Item(0);
    $videoFrame = $slide->getShapes()->addVideoFrame(0, 0, 100, 100, $video);

    // Fügt eine neue Untertitelspur aus einer WebVTT-Datei hinzu.
    $videoFrame->getCaptionTracks()->add("English", "track.vtt");

    $presentation->save("video_with_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Die Klasse [CaptionsCollection](https://reference.aspose.com/slides/de/php-java/aspose.slides/captionscollection/) bietet außerdem eine Überladung, mit der Sie Untertitel aus einem Stream hinzufügen können.

**Untertitel aus einem Video-Frame extrahieren**

1. Laden Sie die Präsentation, die das Video enthält.
1. Suchen Sie das Ziel‑[VideoFrame](https://reference.aspose.com/slides/de/php-java/aspose.slides/videoframe/)‑Objekt.
1. Durchlaufen Sie die Sammlung [getCaptionTracks](https://reference.aspose.com/slides/de/php-java/aspose.slides/videoframe/#getCaptionTracks).
1. Speichern Sie jede Untertitelspur in einer `.vtt`‑Datei.

Der folgende Code zeigt, wie Sie Untertitel aus einem Video-Frame extrahieren:

```php
$presentation = new Presentation("video_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
            $videoFrame = $shape;
            $trackCount = java_values($videoFrame->getCaptionTracks()->getCount());
            for ($trackIndex = 0; $trackIndex < $trackCount; $trackIndex++) {
                $captionTrack = $videoFrame->getCaptionTracks()->get_Item($trackIndex);
                // Speichert die Untertitelspur in einer WebVTT-Datei.
                $filePath = $captionTrack->getCaptionId() . ".vtt";
                file_put_contents($filePath, $captionTrack->getBinaryData());
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

Jedes [Captions](https://reference.aspose.com/slides/de/php-java/aspose.slides/captions/)‑Objekt stellt den Untertitel‑Bezeichner, das Label, die Binärdaten und den Untertiteltext als UTF‑8‑String bereit.

**Untertitel aus einem Video-Frame entfernen**

1. Laden Sie die Präsentation, die das Video enthält.
1. Holen Sie das Ziel‑[VideoFrame](https://reference.aspose.com/slides/de/php-java/aspose.slides/videoframe/)‑Objekt.
1. Entfernen Sie Untertitelspuren aus der Sammlung [getCaptionTracks](https://reference.aspose.com/slides/de/php-java/aspose.slides/videoframe/#getCaptionTracks).
1. Speichern Sie die geänderte Präsentation.

Der folgende Code zeigt, wie Sie alle Untertitel aus einem Video-Frame entfernen:

```php
$presentation = new Presentation("video_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $videoFrame = $slide->getShapes()->get_Item(0); // Typ: VideoFrame

    // Entfernt alle Untertitel aus dem Video-Frame.
    $videoFrame->getCaptionTracks()->clear();

    $presentation->save("video_without_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Wenn Sie nur eine Untertitelspur entfernen müssen, verwenden Sie die Methoden [remove](https://reference.aspose.com/slides/de/php-java/aspose.slides/captionscollection/#remove) oder [removeAt](https://reference.aspose.com/slides/de/php-java/aspose.slides/captionscollection/#removeAt) anstelle von [clear](https://reference.aspose.com/slides/de/php-java/aspose.slides/captionscollection/#clear).

## **Video aus Folien extrahieren**

Neben dem Hinzufügen von Videos zu Folien ermöglicht Aspose.Slides das Extrahieren von in Präsentationen eingebetteten Videos.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/), um die Präsentation zu laden, die das Video enthält.
2. Durchlaufen Sie alle [Slide](https://reference.aspose.com/slides/de/php-java/aspose.slides/slide/)‑Objekte.
3. Durchlaufen Sie alle [Shape](https://reference.aspose.com/slides/de/php-java/aspose.slides/shape/)‑Objekte, um ein [VideoFrame](https://reference.aspose.com/slides/de/php-java/aspose.slides/videoframe/) zu finden.
4. Speichern Sie das Video auf dem Datenträger.

Dieser PHP‑Code zeigt, wie Sie das Video auf einer Präsentationsfolie extrahieren:

```php
  # Instanziert ein Presentation-Objekt, das eine Präsentationsdatei repräsentiert
  $pres = new Presentation("VideoSample.pptx");
  try {
    foreach($pres->getSlides() as $slide) {
      foreach($slide->getShapes() as $shape) {
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
          $vf = $shape;
          $type = $vf->getEmbeddedVideo()->getContentType();
          $ss = $type->lastIndexOf('-');
          $buffer = $vf->getEmbeddedVideo()->getBinaryData();
          # Holt die Dateierweiterung
          $charIndex = $type->indexOf("/");
          $type = $type->substring($charIndex + 1);
          $fop = new Java("java.io.FileOutputStream", "testing2." . $type);
          $fop->write($buffer);
          $fop->flush();
          $fop->close();
        }
      }
    }
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Welche Video‑Wiedergabeparameter können für einen VideoFrame geändert werden?**

Sie können den [Wiedergabemodus](https://reference.aspose.com/slides/de/php-java/aspose.slides/videoframe/setplaymode/) (automatisch oder bei Klick) und das [Looping](https://reference.aspose.com/slides/de/php-java/aspose.slides/videoframe/setplayloopmode/) steuern. Diese Optionen stehen über die Eigenschaften des [VideoFrame](https://reference.aspose.com/slides/de/php-java/aspose.slides/videoframe/)‑Objekts zur Verfügung.

**Wirkt sich das Hinzufügen eines Videos auf die Größe der PPTX‑Datei aus?**

Ja. Wenn Sie ein lokales Video einbetten, werden die Binärdaten in das Dokument aufgenommen, sodass die Präsentationsgröße proportional zur Dateigröße zunimmt. Beim Hinzufügen eines Online‑Videos werden ein Link und ein Miniaturbild eingebettet, sodass der Größenzuwachs geringer ist.

**Kann ich das Video in einem vorhandenen VideoFrame ersetzen, ohne Position und Größe zu ändern?**

Ja. Sie können den [Video‑Inhalt](https://reference.aspose.com/slides/de/php-java/aspose.slides/videoframe/setembeddedvideo/) innerhalb des Frames austauschen, während Sie die Geometrie der Form beibehalten; dies ist ein häufiges Szenario zum Aktualisieren von Medien in einem bestehenden Layout.

**Kann der Inhaltstyp (MIME) eines eingebetteten Videos ermittelt werden?**

Ja. Ein eingebettetes Video hat einen [Inhaltstyp](https://reference.aspose.com/slides/de/php-java/aspose.slides/video/getcontenttype/), den Sie auslesen und beispielsweise beim Speichern auf dem Datenträger verwenden können.