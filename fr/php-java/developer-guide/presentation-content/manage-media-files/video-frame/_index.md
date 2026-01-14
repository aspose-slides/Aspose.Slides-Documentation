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
- source Web
- PowerPoint
- OpenDocument
- présentation
- PHP
- Aspose.Slides
description: "Apprenez à ajouter et extraire programmatique des cadres vidéo dans les diapositives PowerPoint et OpenDocument en utilisant Aspose.Slides pour PHP via Java. Guide pratique rapide."
---

Une vidéo bien placée dans une présentation peut rendre votre message plus percutant et augmenter le niveau d'engagement de votre audience. 

PowerPoint vous permet d'ajouter des vidéos à une diapositive dans une présentation de deux manières :

* Ajouter ou incorporer une vidéo locale (stockée sur votre ordinateur)
* Ajouter une vidéo en ligne (provenant d'une source Web telle que YouTube).

Pour vous permettre d'ajouter des vidéos (objets vidéo) à une présentation, Aspose.Slides fournit les classes [Video](https://reference.aspose.com/slides/php-java/aspose.slides/video/) et [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/) ainsi que d'autres types pertinents.

## **Créer des cadres vidéo incorporés**

Si le fichier vidéo que vous souhaitez ajouter à votre diapositive est stocké localement, vous pouvez créer un cadre vidéo pour incorporer la vidéo dans votre présentation. 

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. Obtenez la référence d’une diapositive via son indice. 
1. Ajoutez un objet [Video](https://reference.aspose.com/slides/php-java/aspose.slides/video/) et transmettez le chemin du fichier vidéo pour incorporer la vidéo à la présentation.
1. Ajoutez un objet [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/) pour créer un cadre pour la vidéo.
1. Enregistrez la présentation modifiée. 

Ce code PHP vous montre comment ajouter une vidéo stockée localement à une présentation :
```php
  # Instancie la classe Presentation
  $pres = new Presentation("pres.pptx");
  try {
    # Charge la vidéo
    $fileStream = new Java("java.io.FileInputStream", "Wildlife.mp4");
    $video = $pres->getVideos()->addVideo($fileStream, LoadingStreamBehavior->KeepLocked);
    # Obtient la première diapositive et ajoute un videoframe
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


Vous pouvez également ajouter une vidéo en transmettant son chemin de fichier directement à la méthode [addVideoFrame(float x, float y, float width, float height, Video video)](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addvideoframe/) :
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



## **Créer des cadres vidéo avec une vidéo provenant de sources Web**

Microsoft [PowerPoint 2013 et versions ultérieures](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) prend en charge les vidéos YouTube dans les présentations. Si la vidéo que vous souhaitez utiliser est disponible en ligne (par ex. sur YouTube), vous pouvez l’ajouter à votre présentation via son lien web. 

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. Obtenez la référence d’une diapositive via son indice. 
1. Ajoutez un objet [Video](https://reference.aspose.com/slides/php-java/aspose.slides/video/) et transmettez le lien vers la vidéo.
1. Définissez une miniature pour le cadre vidéo. 
1. Enregistrez la présentation. 

Ce code PHP vous montre comment ajouter une vidéo depuis le web à une diapositive dans une présentation PowerPoint :
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


## **Extraire la vidéo des diapositives**

En plus d’ajouter des vidéos aux diapositives, Aspose.Slides vous permet d’extraire les vidéos incorporées dans les présentations.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) pour charger la présentation contenant la vidéo.
2. Parcourez tous les objets [Slide](https://reference.aspose.com/slides/php-java/aspose.slides/slide/).
3. Parcourez tous les objets [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) pour trouver un [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/).
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


## **FAQ**

**Quels paramètres de lecture vidéo peuvent être modifiés pour un VideoFrame ?**

Vous pouvez contrôler le [mode de lecture](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/setplaymode/) (auto ou au clic) et la [boucle](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/setplayloopmode/). Ces options sont disponibles via les propriétés de l'objet [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/).

**L’ajout d’une vidéo affecte-t-il la taille du fichier PPTX ?**

Oui. Lorsque vous incorporez une vidéo locale, les données binaires sont incluses dans le document, ce qui augmente la taille de la présentation proportionnellement à la taille du fichier. Lorsque vous ajoutez une vidéo en ligne, un lien et une miniature sont incorporés, de sorte que l’augmentation de taille est moindre.

**Puis‑je remplacer la vidéo d’un VideoFrame existant sans modifier sa position et sa taille ?**

Oui. Vous pouvez échanger le [contenu vidéo](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/setembeddedvideo/) à l’intérieur du cadre tout en conservant la géométrie de la forme ; c’est un scénario courant pour mettre à jour les médias dans une mise en page existante.

**Peut‑on déterminer le type de contenu (MIME) d’une vidéo incorporée ?**

Oui. Une vidéo incorporée possède un [type de contenu](https://reference.aspose.com/slides/php-java/aspose.slides/video/getcontenttype/) que vous pouvez lire et utiliser, par exemple lors de son enregistrement sur le disque.