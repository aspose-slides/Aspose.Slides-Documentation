---
title: Video-Frame
type: docs
weight: 10
url: /php-java/video-frame/
keywords: "Video hinzufügen, Video-Frame erstellen, Video extrahieren, PowerPoint-Präsentation, Java, Aspose.Slides für PHP über Java"
description: "Video-Frame zu einer PowerPoint-Präsentation hinzufügen"
---

Ein gut platzierter Video in einer Präsentation kann Ihre Botschaft überzeugender gestalten und das Engagement Ihres Publikums erhöhen.

PowerPoint ermöglicht es Ihnen, Videos auf zwei Arten zu einer Folie in einer Präsentation hinzuzufügen:

* Fügen Sie ein lokales Video hinzu oder betten Sie es ein (auf Ihrem Computer gespeichert)
* Fügen Sie ein Online-Video hinzu (aus einer Webquelle wie YouTube).

Um Ihnen das Hinzufügen von Videos (Video-Objekten) zu einer Präsentation zu ermöglichen, bietet Aspose.Slides die [IVideo](https://reference.aspose.com/slides/php-java/aspose.slides/ivideo/) Schnittstelle, die [IVideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/ivideoframe/) Schnittstelle und andere relevante Typen.

## **Eingebetteten Video-Frame erstellen**

Wenn die Videodatei, die Sie zu Ihrer Folie hinzufügen möchten, lokal gespeichert ist, können Sie einen Video-Frame erstellen, um das Video in Ihre Präsentation einzubetten.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) Klasse.
1. Holen Sie einen Verweis auf die Folie über ihren Index.
1. Fügen Sie ein [IVideo](https://reference.aspose.com/slides/php-java/aspose.slides/ivideo/) Objekt hinzu und geben Sie den Videodateipfad an, um das Video in die Präsentation einzubetten.
1. Fügen Sie ein [IVideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/ivideoframe/) Objekt hinzu, um einen Rahmen für das Video zu erstellen.
1. Speichern Sie die bearbeitete Präsentation.

Dieser PHP-Code zeigt Ihnen, wie Sie ein lokal gespeichertes Video zu einer Präsentation hinzufügen:

```php
  # Instanziiert die Presentation-Klasse
  $pres = new Presentation("pres.pptx");
  try {
    # Lädt das Video
    $fileStream = new Java("java.io.FileInputStream", "Wildlife.mp4");
    $video = $pres->getVideos()->addVideo($fileStream, LoadingStreamBehavior->KeepLocked);
    # Holt die erste Folie und fügt einen Video-Frame hinzu
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

Alternativ können Sie ein Video hinzufügen, indem Sie den Dateipfad direkt an die [addVideoFrame(float x, float y, float width, float height, IVideo video)](https://reference.aspose.com/slides/php-java/aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-com.aspose.slides.IVideo-) Methode übergeben:

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

## **Video-Frame mit Video aus einer Webquelle erstellen**

Microsoft [PowerPoint 2013 und neuer](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) unterstützt YouTube-Videos in Präsentationen. Wenn das Video, das Sie verwenden möchten, online verfügbar ist (z. B. auf YouTube), können Sie es über seinen Weblink zu Ihrer Präsentation hinzufügen.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) Klasse.
1. Holen Sie einen Verweis auf die Folie über ihren Index.
1. Fügen Sie ein [IVideo](https://reference.aspose.com/slides/php-java/aspose.slides/ivideo/) Objekt hinzu und geben Sie den Link zum Video an.
1. Legen Sie ein Thumbnail für den Video-Frame fest.
1. Speichern Sie die Präsentation.

Dieser PHP-Code zeigt Ihnen, wie Sie ein Video aus dem Web zu einer Folie in einer PowerPoint-Präsentation hinzufügen:

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

## **Video von der Folie extrahieren**

Neben dem Hinzufügen von Videos zu Folien ermöglicht es Aspose.Slides, Videos, die in Präsentationen eingebettet sind, zu extrahieren.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) Klasse, um die Präsentation zu laden, die das Video enthält.
2. Durchlaufen Sie alle [ISlide](https://reference.aspose.com/slides/php-java/aspose.slides/islide/) Objekte.
3. Durchlaufen Sie alle [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/ishape/) Objekte, um einen [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/) zu finden.
4. Speichern Sie das Video auf der Festplatte.

Dieser PHP-Code zeigt Ihnen, wie Sie das Video auf einer Präsentationsfolie extrahieren:

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