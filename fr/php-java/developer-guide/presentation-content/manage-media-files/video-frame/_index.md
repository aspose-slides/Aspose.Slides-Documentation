---
title: Gérer les cadres vidéo dans les présentations avec PHP
linktitle: Cadre vidéo
type: docs
weight: 10
url: /fr/php-java/video-frame/
keywords:
- ajouter une vidéo
- créer une vidéo
- intégrer une vidéo
- extraire une vidéo
- récupérer une vidéo
- cadre vidéo
- source web
- PowerPoint
- OpenDocument
- présentation
- PHP
- Aspose.Slides
description: "Apprenez à ajouter et extraire programmatique des cadres vidéo dans les diapositives PowerPoint et OpenDocument en utilisant Aspose.Slides pour PHP via Java. Guide pratique rapide."
---
Une vidéo bien placée dans une présentation peut rendre votre message plus percutant et augmenter le niveau d'engagement de votre public.  

PowerPoint vous permet d’ajouter des vidéos à une diapositive d’une présentation de deux manières :

* Ajouter ou intégrer une vidéo locale (stockée sur votre machine)  
* Ajouter une vidéo en ligne (provenant d’une source Web telle que YouTube).

Pour vous permettre d’ajouter des vidéos (objets vidéo) à une présentation, Aspose.Slides fournit la classe [Video](https://reference.aspose.com/slides/fr/php-java/aspose.slides/video/), la classe [VideoFrame](https://reference.aspose.com/slides/fr/php-java/aspose.slides/videoframe/) et d’autres types pertinents.

## **Créer des cadres vidéo intégrés**

Si le fichier vidéo que vous souhaitez ajouter à votre diapositive est stocké localement, vous pouvez créer un cadre vidéo pour intégrer la vidéo dans votre présentation.  

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/).  
1. Obtenez la référence d’une diapositive via son index.  
1. Ajoutez un objet [Video](https://reference.aspose.com/slides/fr/php-java/aspose.slides/video/) et passez le chemin du fichier vidéo pour l’intégrer à la présentation.  
1. Ajoutez un objet [VideoFrame](https://reference.aspose.com/slides/fr/php-java/aspose.slides/videoframe/) pour créer un cadre pour la vidéo.  
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

Vous pouvez également ajouter une vidéo en transmettant directement son chemin de fichier à la méthode [addVideoFrame(float x, float y, float width, float height, Video video)](https://reference.aspose.com/slides/fr/php-java/aspose.slides/shapecollection/addvideoframe/) :

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

## **Créer des cadres vidéo à partir de sources Web**

Microsoft [PowerPoint 2013 et versions ultérieures](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) prend en charge les vidéos YouTube dans les présentations. Si la vidéo que vous souhaitez utiliser est disponible en ligne (par exemple sur YouTube), vous pouvez l’ajouter à votre présentation via son lien Web.  

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/).  
1. Obtenez la référence d’une diapositive via son index.  
1. Ajoutez un objet [Video](https://reference.aspose.com/slides/fr/php-java/aspose.slides/video/) et transmettez le lien vers la vidéo.  
1. Définissez une vignette pour le cadre vidéo.  
1. Enregistrez la présentation.  

Ce code PHP vous montre comment ajouter une vidéo depuis le Web à une diapositive d’une présentation PowerPoint :

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

## **Gérer les sous-titres vidéo**

Aspose.Slides vous permet de gérer les sous‑titres fermés pour les cadres vidéo dans les présentations PowerPoint. Les sous‑titres sont stockés au format WebVTT et sont accessibles via la méthode [VideoFrame::getCaptionTracks](https://reference.aspose.com/slides/fr/php-java/aspose.slides/videoframe/#getCaptionTracks).  

**Ajouter des sous‑titres à un cadre vidéo**

Pour ajouter des sous‑titres à un cadre vidéo :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/).  
1. Ajoutez une vidéo à la présentation.  
1. Ajoutez un objet [VideoFrame](https://reference.aspose.com/slides/fr/php-java/aspose.slides/videoframe/) à une diapositive.  
1. Utilisez la collection [CaptionsCollection](https://reference.aspose.com/slides/fr/php-java/aspose.slides/captionscollection/) renvoyée par [getCaptionTracks](https://reference.aspose.com/slides/fr/php-java/aspose.slides/videoframe/#getCaptionTracks) pour ajouter une piste de sous‑titres WebVTT.  
1. Enregistrez la présentation modifiée.  

Le code suivant vous montre comment ajouter des sous‑titres à un cadre vidéo :

```php
$presentation = new Presentation();
try {
    $videoData = file_get_contents("video.mp4");
    $video = $presentation->getVideos()->addVideo($videoData);

    $slide = $presentation->getSlides()->get_Item(0);
    $videoFrame = $slide->getShapes()->addVideoFrame(0, 0, 100, 100, $video);

    // Ajoute une nouvelle piste de sous-titres depuis un fichier WebVTT.
    $videoFrame->getCaptionTracks()->add("English", "track.vtt");

    $presentation->save("video_with_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

La classe [CaptionsCollection](https://reference.aspose.com/slides/fr/php-java/aspose.slides/captionscollection/) propose également une surcharge qui vous permet d’ajouter des sous‑titres à partir d’un flux.  

**Extraire les sous‑titres d’un cadre vidéo**

Pour extraire les sous‑titres d’un cadre vidéo :

1. Chargez la présentation contenant la vidéo.  
1. Trouvez l’objet cible [VideoFrame](https://reference.aspose.com/slides/fr/php-java/aspose.slides/videoframe/).  
1. Parcourez la collection [getCaptionTracks](https://reference.aspose.com/slides/fr/php-java/aspose.slides/videoframe/#getCaptionTracks).  
1. Enregistrez chaque piste de sous‑titres dans un fichier `.vtt`.  

Le code suivant vous montre comment extraire les sous‑titres d’un cadre vidéo :

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
                // Enregistre la piste de sous-titres dans un fichier WebVTT.
                $filePath = $captionTrack->getCaptionId() . ".vtt";
                file_put_contents($filePath, $captionTrack->getBinaryData());
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

Chaque objet [Captions](https://reference.aspose.com/slides/fr/php-java/aspose.slides/captions/) expose l’identifiant du sous‑titre, le libellé, les données binaires et le texte du sous‑titre sous forme de chaîne UTF‑8.  

**Supprimer les sous‑titres d’un cadre vidéo**

Pour supprimer les sous‑titres d’un cadre vidéo :

1. Chargez la présentation contenant la vidéo.  
1. Obtenez l’objet cible [VideoFrame](https://reference.aspose.com/slides/fr/php-java/aspose.slides/videoframe/).  
1. Supprimez les pistes de sous‑titres de la collection [getCaptionTracks](https://reference.aspose.com/slides/fr/php-java/aspose.slides/videoframe/#getCaptionTracks).  
1. Enregistrez la présentation modifiée.  

Le code suivant vous montre comment supprimer tous les sous‑titres d’un cadre vidéo :

```php
$presentation = new Presentation("video_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $videoFrame = $slide->getShapes()->get_Item(0); // type: VideoFrame

    // Supprime toutes les sous-titres du cadre vidéo.
    $videoFrame->getCaptionTracks()->clear();

    $presentation->save("video_without_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Si vous devez supprimer uniquement une piste de sous‑titre, utilisez les méthodes [remove](https://reference.aspose.com/slides/fr/php-java/aspose.slides/captionscollection/#remove) ou [removeAt](https://reference.aspose.com/slides/fr/php-java/aspose.slides/captionscollection/#removeAt) au lieu de [clear](https://reference.aspose.com/slides/fr/php-java/aspose.slides/captionscollection/#clear).  

## **Extraire la vidéo des diapositives**

En plus d’ajouter des vidéos aux diapositives, Aspose.Slides vous permet d’extraire les vidéos intégrées dans les présentations.  

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/) pour charger la présentation contenant la vidéo.  
2. Parcourez toutes les objets [Slide](https://reference.aspose.com/slides/fr/php-java/aspose.slides/slide/).  
3. Parcourez tous les objets [Shape](https://reference.aspose.com/slides/fr/php-java/aspose.slides/shape/) afin de trouver un [VideoFrame](https://reference.aspose.com/slides/fr/php-java/aspose.slides/videoframe/).  
4. Enregistrez la vidéo sur le disque.  

Ce code PHP vous montre comment extraire la vidéo d’une diapositive de présentation :

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
          # Obtient l'extension du fichier
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

**Quels paramètres de lecture vidéo peuvent être modifiés pour un VideoFrame ?**

Vous pouvez contrôler le [mode de lecture](https://reference.aspose.com/slides/fr/php-java/aspose.slides/videoframe/setplaymode/) (auto ou sur clic) et la [boucle de lecture](https://reference.aspose.com/slides/fr/php-java/aspose.slides/videoframe/setplayloopmode/). Ces options sont disponibles via les propriétés de l’objet [VideoFrame](https://reference.aspose.com/slides/fr/php-java/aspose.slides/videoframe/).  

**L’ajout d’une vidéo influence‑t‑il la taille du fichier PPTX ?**

Oui. Lorsque vous intégrez une vidéo locale, les données binaires sont incluses dans le document, ce qui augmente la taille de la présentation proportionnellement à la taille du fichier. Lorsque vous ajoutez une vidéo en ligne, un lien et une vignette sont intégrés, ce qui entraîne une augmentation de taille moindre.  

**Puis‑je remplacer la vidéo d’un VideoFrame existant sans modifier sa position et sa taille ?**

Oui. Vous pouvez remplacer le [contenu vidéo](https://reference.aspose.com/slides/fr/php-java/aspose.slides/videoframe/setembeddedvideo/) à l’intérieur du cadre tout en conservant la géométrie de la forme ; c’est un scénario courant pour mettre à jour les médias d’une mise en page existante.  

**Peut‑on déterminer le type de contenu (MIME) d’une vidéo intégrée ?**

Oui. Une vidéo intégrée possède un [type de contenu](https://reference.aspose.com/slides/fr/php-java/aspose.slides/video/getcontenttype/) que vous pouvez lire et utiliser, par exemple lors de l’enregistrement sur le disque.