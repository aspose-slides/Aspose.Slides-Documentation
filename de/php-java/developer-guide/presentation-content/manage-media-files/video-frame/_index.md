---
title: "Verwalten von Videoframes in Präsentationen mit PHP"
linktitle: "Video‑Frame"
type: docs
weight: 10
url: /de/php-java/video-frame/
keywords:
- "Video hinzufügen"
- "Video erstellen"
- "Video einbetten"
- "Video extrahieren"
- "Video abrufen"
- "Videoframe"
- "Webquelle"
- "PowerPoint"
- "OpenDocument"
- "Präsentation"
- "PHP"
- "Aspose.Slides"
description: "Erfahren Sie, wie Sie programmgesteuert Videoframes in PowerPoint- und OpenDocument‑Folien mit Aspose.Slides für PHP über Java hinzufügen und extrahieren. Schnelle Anleitung."
---
Ein gut platziertes Video in einer Präsentation kann Ihre Botschaft überzeugender machen und das Engagement Ihrer Zielgruppe steigern. 

PowerPoint ermöglicht das Hinzufügen von Videos zu einer Folie in einer Präsentation auf zwei Arten:

* Ein lokales Video hinzufügen oder einbetten (auf Ihrem Computer gespeichert)
* Ein Online-Video hinzufügen (von einer Webquelle wie YouTube).

Um Ihnen das Hinzufügen von Videos (Videoobjekten) zu einer Präsentation zu ermöglichen, stellt Aspose.Slides die Klasse [Video](https://reference.aspose.com/slides/de/php-java/aspose.slides/video/) bereit, die Klasse [VideoFrame](https://reference.aspose.com/slides/de/php-java/aspose.slides/videoframe/) und weitere relevante Typen.

## **Einbetten von Videoframes erstellen**

Wenn die Videodatei, die Sie zu Ihrer Folie hinzufügen möchten, lokal gespeichert ist, können Sie einen Videoframe erstellen, um das Video in Ihrer Präsentation einzubetten. 

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/).
1. Rufen Sie die Referenz einer Folie über ihren Index ab. 
1. Fügen Sie ein [Video](https://reference.aspose.com/slides/de/php-java/aspose.slides/video/)‑Objekt hinzu und übergeben Sie den Pfad zur Videodatei, um das Video in die Präsentation einzubetten.
1. Fügen Sie ein [VideoFrame](https://reference.aspose.com/slides/de/php-java/aspose.slides/videoframe/)‑Objekt hinzu, um einen Frame für das Video zu erstellen.
1. Speichern Sie die modifizierte Präsentation. 

Dieser PHP‑Code zeigt, wie Sie ein lokal gespeichertes Video zu einer Präsentation hinzufügen:

```php
  # Instanziiert die Presentation-Klasse
  $pres = new Presentation("pres.pptx");
  try {
    # Lädt das Video
    $fileStream = new Java("java.io.FileInputStream", "Wildlife.mp4");
    $video = $pres->getVideos()->addVideo($fileStream, LoadingStreamBehavior->KeepLocked);
    # Holt die erste Folie und fügt einen Videoframe hinzu
    $pres->getSlides()->get_Item(0)->getShapes()->addVideoFrame(10, 10, 150, 250, $video);
    # Speichert die Präsentation auf dem Datenträger
    $pres->save("pres-with-video.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Alternativ können Sie ein Video hinzufügen, indem Sie den Dateipfad direkt an die Methode [addVideoFrame(float x, float y, float width, float height, Video video)](https://reference.aspose.com/slides/de/php-java/aspose.slides/shapecollection/addvideoframe/) übergeben:

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

## **Erstellen von Videoframes mit Videos aus Webquellen**

Microsoft [PowerPoint 2013 and newer](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) unterstützt YouTube‑Videos in Präsentationen. Wenn das Video, das Sie verwenden möchten, online verfügbar ist (z. B. auf YouTube), können Sie es über seinen Weblink zu Ihrer Präsentation hinzufügen. 

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/).
1. Rufen Sie die Referenz einer Folie über ihren Index ab. 
1. Fügen Sie ein [Video](https://reference.aspose.com/slides/de/php-java/aspose.slides/video/)‑Objekt hinzu und übergeben Sie den Link zum Video.
1. Legen Sie ein Thumbnail für den Videoframe fest. 
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

## **Video-Untertitel verwalten**

Aspose.Slides ermöglicht das Verwalten von geschlossenen Untertiteln für Videoframes in PowerPoint‑Präsentationen. Untertitel werden im WebVTT‑Format gespeichert und über die Methode [VideoFrame::getCaptionTracks](https://reference.aspose.com/slides/de/php-java/aspose.slides/videoframe/#getCaptionTracks) bereitgestellt.

**Untertitel zu einem Videoframe hinzufügen**

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/).
1. Fügen Sie der Präsentation ein Video hinzu.
1. Fügen Sie ein [VideoFrame](https://reference.aspose.com/slides/de/php-java/aspose.slides/videoframe/)‑Objekt zu einer Folie hinzu.
1. Verwenden Sie die von [getCaptionTracks](https://reference.aspose.com/slides/de/php-java/aspose.slides/videoframe/#getCaptionTracks) zurückgegebene [CaptionsCollection](https://reference.aspose.com/slides/de/php-java/aspose.slides/captionscollection/), um einen WebVTT‑Untertiteltrack hinzuzufügen.
1. Speichern Sie die modifizierte Präsentation.

Der folgende Code zeigt, wie Sie Untertitel zu einem Videoframe hinzufügen:

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

Die Klasse [CaptionsCollection](https://reference.aspose.com/slides/de/php-java/aspose.slides/captionscollection/) bietet zudem eine Überladung, mit der Sie Untertitel aus einem Stream hinzufügen können.

**Untertitel aus einem Videoframe extrahieren**

1. Laden Sie die Präsentation, die das Video enthält.
1. Suchen Sie das Ziel‑[VideoFrame](https://reference.aspose.com/slides/de/php-java/aspose.slides/videoframe/)-Objekt.
1. Iterieren Sie über die [getCaptionTracks](https://reference.aspose.com/slides/de/php-java/aspose.slides/videoframe/#getCaptionTracks)-Sammlung.
1. Speichern Sie jeden Untertiteltrack in einer `.vtt`‑Datei.

Der folgende Code zeigt, wie Sie Untertitel aus einem Videoframe extrahieren:

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

Jedes [Captions](https://reference.aspose.com/slides/de/php-java/aspose.slides/captions/)‑Objekt stellt die Untertitel‑Kennung, das Label, die Binärdaten und den Untertiteltext als UTF‑8‑Zeichenfolge bereit.

**Untertitel von einem Videoframe entfernen**

1. Laden Sie die Präsentation, die das Video enthält.
1. Rufen Sie das Ziel‑[VideoFrame](https://reference.aspose.com/slides/de/php-java/aspose.slides/videoframe/)-Objekt ab.
1. Entfernen Sie Untertiteltracks aus der [getCaptionTracks](https://reference.aspose.com/slides/de/php-java/aspose.slides/videoframe/#getCaptionTracks)-Sammlung.
1. Speichern Sie die modifizierte Präsentation.

Der folgende Code zeigt, wie Sie alle Untertitel von einem Videoframe entfernen:

```php
$presentation = new Presentation("video_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $videoFrame = $slide->getShapes()->get_Item(0); // Typ: VideoFrame

    // Entfernt alle Untertitel aus dem Videoframe.
    $videoFrame->getCaptionTracks()->clear();

    $presentation->save("video_without_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Wenn Sie nur einen Untertiteltrack entfernen müssen, verwenden Sie die Methoden [remove](https://reference.aspose.com/slides/de/php-java/aspose.slides/captionscollection/#remove) oder [removeAt](https://reference.aspose.com/slides/de/php-java/aspose.slides/captionscollection/#removeAt), anstelle von [clear](https://reference.aspose.com/slides/de/php-java/aspose.slides/captionscollection/#clear).

## **Video aus Folien extrahieren**

Neben dem Hinzufügen von Videos zu Folien ermöglicht Aspose.Slides das Extrahieren von in Präsentationen eingebetteten Videos.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/), um die Präsentation zu laden, die das Video enthält.
2. Iterieren Sie über alle [Slide](https://reference.aspose.com/slides/de/php-java/aspose.slides/slide/)‑Objekte.
3. Iterieren Sie über alle [Shape](https://reference.aspose.com/slides/de/php-java/aspose.slides/shape/)‑Objekte, um ein [VideoFrame](https://reference.aspose.com/slides/de/php-java/aspose.slides/videoframe/) zu finden.
4. Speichern Sie das Video auf dem Datenträger.

Dieser PHP‑Code zeigt, wie Sie das Video einer Präsentationsfolie extrahieren:

```php
  # Instanziert ein Presentation-Objekt, das eine Präsentationsdatei darstellt
  $pres = new Presentation("VideoSample.pptx");
  try {
    foreach($pres->getSlides() as $slide) {
      foreach($slide->getShapes() as $shape) {
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
          $vf = $shape;
          $type = $vf->getEmbeddedVideo()->getContentType();
          $ss = $type->lastIndexOf('-');
          $buffer = $vf->getEmbeddedVideo()->getBinaryData();
          # Ermittelt die Dateierweiterung
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

**Welche Wiedergabeparameter können für einen VideoFrame geändert werden?**

Sie können den [playback mode](https://reference.aspose.com/slides/de/php-java/aspose.slides/videoframe/setplaymode/) (automatisch oder bei Klick) und das [looping](https://reference.aspose.com/slides/de/php-java/aspose.slides/videoframe/setplayloopmode/) steuern. Diese Optionen sind über die Eigenschaften des [VideoFrame](https://reference.aspose.com/slides/de/php-java/aspose.slides/videoframe/)‑Objekts verfügbar.

**Beeinflusst das Hinzufügen eines Videos die PPTX-Dateigröße?**

Ja. Beim Einbetten eines lokalen Videos werden die Binärdaten in das Dokument aufgenommen, sodass die Präsentationsgröße proportional zur Dateigröße wächst. Beim Hinzufügen eines Online‑Videos werden ein Link und ein Thumbnail eingebettet, wodurch die Größensteigerung geringer ausfällt.

**Kann ich das Video in einem bestehenden VideoFrame ersetzen, ohne Position und Größe zu ändern?**

Ja. Sie können den [video content](https://reference.aspose.com/slides/de/php-java/aspose.slides/videoframe/setembeddedvideo/) innerhalb des Frames austauschen und dabei die Geometrie der Form beibehalten; dies ist ein gängiges Szenario zum Aktualisieren von Medien in einem bestehenden Layout.

**Kann der Content-Type (MIME) eines eingebetteten Videos ermittelt werden?**

Ja. Ein eingebettetes Video hat einen [content type](https://reference.aspose.com/slides/de/php-java/aspose.slides/video/getcontenttype/), den Sie auslesen und verwenden können, zum Beispiel beim Speichern auf dem Datenträger.