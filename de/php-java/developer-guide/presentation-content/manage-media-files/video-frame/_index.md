---
title: Verwalten von Video-Frames in Präsentationen mit PHP
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
description: "Erfahren Sie, wie Sie mithilfe von Aspose.Slides für PHP via Java programmgesteuert Video-Frames in PowerPoint- und OpenDocument-Folien hinzufügen und extrahieren. Schnelle Anleitung."
---

Ein gut platziertes Video in einer Präsentation kann Ihre Botschaft überzeugender machen und das Engagement Ihres Publikums erhöhen. 

PowerPoint ermöglicht es Ihnen, Videos auf einer Folie in einer Präsentation auf zwei Arten hinzuzufügen:

* Ein lokales Video hinzufügen oder einbetten (auf Ihrem Rechner gespeichert)
* Ein Online-Video hinzufügen (aus einer Webquelle wie YouTube).

Um Ihnen das Hinzufügen von Videos (Videoobjekten) zu einer Präsentation zu ermöglichen, stellt Aspose.Slides die Klasse [Video](https://reference.aspose.com/slides/php-java/aspose.slides/video/) , die Klasse [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/) und weitere relevante Typen bereit.

## **Erstellen eingebetteter Video-Frames**

Wenn die Videodatei, die Sie zu Ihrer Folie hinzufügen möchten, lokal gespeichert ist, können Sie ein Video-Frame erstellen, um das Video in Ihre Präsentation einzubetten. 

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) .
2. Holen Sie eine Referenz auf eine Folie über deren Index. 
3. Fügen Sie ein [Video](https://reference.aspose.com/slides/php-java/aspose.slides/video/) Objekt hinzu und übergeben Sie den Dateipfad des Videos, um das Video in die Präsentation einzubetten.
4. Fügen Sie ein [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/) Objekt hinzu, um einen Frame für das Video zu erstellen.
5. Speichern Sie die geänderte Präsentation. 

Dieser PHP‑Code zeigt, wie Sie ein lokal gespeichertes Video zu einer Präsentation hinzufügen:
```php
  # Instanziiert die Presentation-Klasse
  $pres = new Presentation("pres.pptx");
  try {
    # Lädt das Video
    $fileStream = new Java("java.io.FileInputStream", "Wildlife.mp4");
    $video = $pres->getVideos()->addVideo($fileStream, LoadingStreamBehavior->KeepLocked);
    # Ermittelt die erste Folie und fügt einen Videoframe hinzu
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


Alternativ können Sie ein Video hinzufügen, indem Sie seinen Dateipfad direkt an die Methode [addVideoFrame(float x, float y, float width, float height, Video video)](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addvideoframe/) übergeben:
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


## **Erstellen von Video-Frames mit Videos aus Webquellen**

Microsoft [PowerPoint 2013 und neuer](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) unterstützt YouTube‑Videos in Präsentationen. Wenn das Video, das Sie verwenden möchten, online verfügbar ist (z. B. auf YouTube), können Sie es über seinen Weblink zu Ihrer Präsentation hinzufügen. 

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 
2. Holen Sie eine Referenz auf eine Folie über deren Index. 
3. Fügen Sie ein [Video](https://reference.aspose.com/slides/php-java/aspose.slides/video/) Objekt hinzu und übergeben Sie den Link zum Video.
4. Legen Sie ein Miniaturbild für das Video-Frame fest. 
5. Speichern Sie die Präsentation. 

Dieser PHP‑Code zeigt, wie Sie ein Video aus dem Web zu einer Folie in einer PowerPoint‑Präsentation hinzufügen:
```php
  # Instanziiert ein Presentation-Objekt, das eine Präsentationsdatei darstellt
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


## **Video aus Folien extrahieren**

Neben dem Hinzufügen von Videos zu Folien ermöglicht Aspose.Slides Ihnen, in Präsentationen eingebettete Videos zu extrahieren.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) , um die Präsentation zu laden, die das Video enthält.
2. Iterieren Sie über alle [Slide](https://reference.aspose.com/slides/php-java/aspose.slides/slide/) Objekte.
3. Iterieren Sie über alle [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) Objekte, um ein [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/) zu finden.
4. Speichern Sie das Video auf dem Datenträger.

Dieser PHP‑Code zeigt, wie Sie das Video auf einer Präsentationsfolie extrahieren:
```php
  # Instanziiert ein Presentation-Objekt, das eine Präsentationsdatei darstellt
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

**Welche Wiedergabeparameter können für ein VideoFrame geändert werden?**

Sie können den [Wiedergabemodus](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/setplaymode/) (automatisch oder bei Klick) und das [Looping](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/setplayloopmode/) steuern. Diese Optionen sind über die Eigenschaften des [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/)‑Objekts verfügbar.

**Wirkt sich das Hinzufügen eines Videos auf die Dateigröße der PPTX aus?**

Ja. Wenn Sie ein lokales Video einbetten, werden die Binärdaten in das Dokument aufgenommen, sodass die Präsentationsgröße proportional zur Dateigröße wächst. Wenn Sie ein Online‑Video hinzufügen, werden ein Link und ein Miniaturbild eingebettet, sodass die Größensteigerung geringer ist.

**Kann ich das Video in einem bestehenden VideoFrame ersetzen, ohne Position und Größe zu ändern?**

Ja. Sie können den [Videoinhalt](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/setembeddedvideo/) innerhalb des Frames austauschen, während Sie die Geometrie der Form beibehalten; dies ist ein häufiges Szenario zum Aktualisieren von Medien in einem bestehenden Layout.

**Kann der Inhaltstyp (MIME) eines eingebetteten Videos bestimmt werden?**

Ja. Ein eingebettetes Video hat einen [Inhaltstyp](https://reference.aspose.com/slides/php-java/aspose.slides/video/getcontenttype/), den Sie auslesen und verwenden können, zum Beispiel beim Speichern auf dem Datenträger.