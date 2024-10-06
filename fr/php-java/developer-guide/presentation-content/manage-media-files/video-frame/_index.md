---
title: Cadre Vidéo
type: docs
weight: 10
url: /php-java/video-frame/
keywords: "Ajouter vidéo, créer cadre vidéo, extraire vidéo, présentation PowerPoint, Java, Aspose.Slides pour PHP via Java"
description: "Ajouter un cadre vidéo à la présentation PowerPoint"
---

Une vidéo bien placée dans une présentation peut rendre votre message plus convaincant et augmenter l'engagement de votre public.

PowerPoint vous permet d'ajouter des vidéos à une diapositive dans une présentation de deux manières :

* Ajouter ou intégrer une vidéo locale (stockée sur votre machine)
* Ajouter une vidéo en ligne (d'une source web telle que YouTube).

Pour vous permettre d'ajouter des vidéos (objets vidéo) à une présentation, Aspose.Slides fournit l'interface [IVideo](https://reference.aspose.com/slides/php-java/aspose.slides/ivideo/), l'interface [IVideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/ivideoframe/) et d'autres types pertinents.

## **Créer un Cadre Vidéo Intégré**

Si le fichier vidéo que vous souhaitez ajouter à votre diapositive est stocké localement, vous pouvez créer un cadre vidéo pour intégrer la vidéo dans votre présentation.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Obtenez une référence de diapositive par son index.
1. Ajoutez un objet [IVideo](https://reference.aspose.com/slides/php-java/aspose.slides/ivideo/) et passez le chemin du fichier vidéo pour intégrer la vidéo à la présentation.
1. Ajoutez un objet [IVideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/ivideoframe/) pour créer un cadre pour la vidéo.
1. Enregistrez la présentation modifiée.

Ce code PHP vous montre comment ajouter une vidéo stockée localement à une présentation :

```php
  # Instancie la classe Presentation
  $pres = new Presentation("pres.pptx");
  try {
    # Charge la vidéo
    $fileStream = new Java("java.io.FileInputStream", "Wildlife.mp4");
    $video = $pres->getVideos()->addVideo($fileStream, LoadingStreamBehavior->KeepLocked);
    # Obtient la première diapositive et ajoute un cadre vidéo
    $pres->getSlides()->get_Item(0)->getShapes()->addVideoFrame(10, 10, 150, 250, $video);
    # Enregistre la présentation sur le disque
    $pres->save("pres-with-video.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Alternativement, vous pouvez ajouter une vidéo en passant directement son chemin de fichier à la méthode [addVideoFrame(float x, float y, float width, float height, IVideo video)](https://reference.aspose.com/slides/php-java/aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-com.aspose.slides.IVideo-) :

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

## **Créer un Cadre Vidéo avec une Vidéo d'une Source Web**

Microsoft [PowerPoint 2013 et versions ultérieures](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) prend en charge les vidéos YouTube dans les présentations. Si la vidéo que vous souhaitez utiliser est disponible en ligne (par exemple sur YouTube), vous pouvez l'ajouter à votre présentation via son lien web.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Obtenez une référence de diapositive par son index.
1. Ajoutez un objet [IVideo](https://reference.aspose.com/slides/php-java/aspose.slides/ivideo/) et passez le lien vers la vidéo.
1. Définissez une miniature pour le cadre vidéo.
1. Enregistrez la présentation.

Ce code PHP vous montre comment ajouter une vidéo du web à une diapositive dans une présentation PowerPoint :

```php
  # Instancie un objet Presentation qui représente un fichier de présentation
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

## **Extraire une Vidéo d'une Diapositive**

En plus d'ajouter des vidéos aux diapositives, Aspose.Slides vous permet d'extraire des vidéos intégrées dans des présentations.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) pour charger la présentation contenant la vidéo.
2. Itérez à travers tous les objets [ISlide](https://reference.aspose.com/slides/php-java/aspose.slides/islide/).
3. Itérez à travers tous les objets [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/ishape/) pour trouver un [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/).
4. Enregistrez la vidéo sur le disque.

Ce code PHP vous montre comment extraire la vidéo sur une diapositive de présentation :

```php
  # Instancie un objet Presentation qui représente un fichier de présentation
  $pres = new Presentation("VideoSample.pptx");
  try {
    foreach($pres->getSlides() as $slide) {
      foreach($slide->getShapes() as $shape) {
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
          $vf = $shape;
          $type = $vf->getEmbeddedVideo()->getContentType();
          $ss = $type->lastIndexOf('-');
          $buffer = $vf->getEmbeddedVideo()->getBinaryData();
          # Obtient l'extension de fichier
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