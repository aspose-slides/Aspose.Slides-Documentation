---
title: Gérer les BLOBs de présentation en PHP pour une utilisation efficace de la mémoire
linktitle: Gérer les BLOB
type: docs
weight: 10
url: /fr/php-java/manage-blob/
keywords:
- grand objet
- grand élément
- grand fichier
- ajouter BLOB
- exporter BLOB
- ajouter image comme BLOB
- réduire la mémoire
- consommation de mémoire
- grande présentation
- fichier temporaire
- PowerPoint
- OpenDocument
- présentation
- PHP
- Aspose.Slides
description: "Gérer les données BLOB dans Aspose.Slides pour PHP via Java afin de simplifier les opérations de fichiers PowerPoint et OpenDocument pour une manipulation efficace des présentations."
---

## **À propos de BLOB**

**BLOB** (**Binary Large Object**) est généralement un élément volumineux (photo, présentation, document ou média) enregistré sous forme binaire. 

Aspose.Slides for PHP via Java vous permet d’utiliser les BLOB pour les objets de manière à réduire la consommation de mémoire lorsque des fichiers volumineux sont impliqués.

{{% alert title="Info" color="info" %}}
Pour contourner certaines limitations lors de l’interaction avec les flux, Aspose.Slides peut copier le contenu du flux. Le chargement d’une grande présentation via son flux entraîne la copie du contenu de la présentation et provoque un chargement lent. Ainsi, lorsque vous avez l’intention de charger une grande présentation, nous vous recommandons fortement d’utiliser le chemin du fichier de présentation et non son flux.
{{% /alert %}}

## **Utiliser BLOB pour réduire la consommation de mémoire**

### **Ajouter un fichier volumineux via BLOB à une présentation**

[Aspose.Slides](/slides/fr/php-java/) for Java vous permet d’ajouter des fichiers volumineux (dans ce cas, un gros fichier vidéo) grâce à un processus impliquant des BLOB afin de réduire la consommation de mémoire.

Ce Java vous montre comment ajouter un gros fichier vidéo via le processus BLOB à une présentation :
```php
  $pathToVeryLargeVideo = "veryLargeVideo.avi";
  # Crée une nouvelle présentation à laquelle la vidéo sera ajoutée
  $pres = new Presentation();
  try {
    $fileStream = new Java("java.io.FileInputStream", $pathToVeryLargeVideo);
    try {
      # Ajoutons la vidéo à la présentation - nous avons choisi le comportement KeepLocked parce que nous
      # n'avons pas l'intention d'accéder au fichier "veryLargeVideo.avi".
      $video = $pres->getVideos()->addVideo($fileStream, LoadingStreamBehavior->KeepLocked);
      $pres->getSlides()->get_Item(0)->getShapes()->addVideoFrame(0, 0, 480, 270, $video);
      # Enregistre la présentation. Lorsqu'une grande présentation est générée, la consommation de mémoire
      # reste basse tout au long du cycle de vie de l'objet pres
      $pres->save("presentationWithLargeVideo.pptx", SaveFormat::Pptx);
    } finally {
      if (!java_is_null($fileStream)) {
        $fileStream->close();
      }
    }
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


### **Exporter un fichier volumineux via BLOB depuis une présentation**
Aspose.Slides for PHP via Java vous permet d’exporter des fichiers volumineux (dans ce cas, un fichier audio ou vidéo) grâce à un processus impliquant des BLOB depuis des présentations. Par exemple, vous pouvez devoir extraire un gros fichier média d’une présentation sans le charger entièrement en mémoire. En exportant le fichier via le processus BLOB, vous maintenez une faible consommation de mémoire.

Ce code montre l’opération décrite :
```php
  $hugePresentationWithAudiosAndVideosFile = "LargeVideoFileTest.pptx";
  $loadOptions = new LoadOptions();
  # Verrouille le fichier source et ne le charge PAS en mémoire
  $loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior->KeepLocked);
  # crée l'instance de Presentation, verrouille le fichier "hugePresentationWithAudiosAndVideos.pptx".
  $pres = new Presentation($hugePresentationWithAudiosAndVideosFile, $loadOptions);
  try {
    # Enregistrez chaque vidéo dans un fichier. Pour éviter une utilisation élevée de la mémoire, nous avons besoin d'un tampon qui sera utilisé
    # pour transférer les données du flux vidéo de la présentation vers un flux pour un nouveau fichier vidéo créé.
    $Array = new JavaClass("java.lang.reflect.Array");
    $Byte = new JavaClass("java.lang.Byte");
    $buffer = $Array->newInstance($Byte, 8 * 1024);
    # Iterates through the videos
    for($index = 0; $index < java_values($pres->getVideos()->size()) ; $index++) {
      $video = $pres->getVideos()->get_Item($index);
      # Ouvre le flux vidéo de la présentation. Veuillez noter que nous avons intentionnellement évité d'accéder aux propriétés
      # comme video.BinaryData - car cette propriété renvoie un tableau d'octets contenant une vidéo complète, ce qui
      # entraîne le chargement d'octets en mémoire. Nous utilisons video.GetStream, qui renvoie un Stream - et ne
      # nécessite pas de charger la vidéo entière en mémoire.
      $presVideoStream = $video->getStream();
      try {
        $outputFileStream = new Java("java.io.FileOutputStream", "video" . $index . ".avi");
        try {
          $bytesRead;
          while ($bytesRead = $presVideoStream->read($buffer, 0, java_values($Array->getLength($buffer))) > 0) {
            $outputFileStream->write($buffer, 0, $bytesRead);
          } 
        } finally {
          $outputFileStream->close();
        }
      } finally {
        $presVideoStream->close();
      }
      # La consommation de mémoire restera faible quel que soit la taille de la vidéo ou de la présentation.
    }
    # Si nécessaire, vous pouvez appliquer les mêmes étapes aux fichiers audio.
  } catch (JavaException $e) {
  } finally {
    $pres->dispose();
  }
```


### **Ajouter une image en tant que BLOB à une présentation**
Avec les méthodes de la classe [ImageCollection](https://reference.aspose.com/slides/php-java/aspose.slides/imagecollection/), vous pouvez ajouter une grande image sous forme de flux pour qu’elle soit traitée comme un BLOB.

Ce code PHP vous montre comment ajouter une grande image via le processus BLOB :
```php
  $pathToLargeImage = "large_image.jpg";
  # crée une nouvelle présentation à laquelle l'image sera ajoutée.
  $pres = new Presentation();
  try {
    $fileStream = new Java("java.io.FileInputStream", $pathToLargeImage);
    try {
      # Ajoutons l'image à la présentation - nous choisissons le comportement KeepLocked car nous
      # N'AVONS PAS l'intention d'accéder au fichier "largeImage.png".
      $img = $pres->getImages()->addImage($fileStream, LoadingStreamBehavior->KeepLocked);
      $pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 0, 0, 300, 200, $img);
      # Enregistre la présentation. Lorsqu'une grande présentation est générée, la consommation de mémoire
      # reste faible tout au long du cycle de vie de l'objet pres.
      $pres->save("presentationWithLargeImage.pptx", SaveFormat::Pptx);
    } finally {
      if (!java_is_null($fileStream)) {
        $fileStream->close();
      }
    }
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Mémoire et présentations volumineuses**

Typiquement, pour charger une grande présentation, les ordinateurs ont besoin de beaucoup de mémoire temporaire. L’ensemble du contenu de la présentation est chargé en mémoire et le fichier (à partir duquel la présentation a été chargée) n’est plus utilisé. 

Considérez une grande présentation PowerPoint (large.pptx) contenant un fichier vidéo de 1,5 Go. La méthode standard de chargement de la présentation est décrite dans ce code PHP :
```php
  $pres = new Presentation("large.pptx");
  try {
    $pres->save("large.pdf", SaveFormat::Pdf);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


Mais cette méthode consomme environ 1,6 Go de mémoire temporaire. 

### **Charger une grande présentation en tant que BLOB**

Grâce au processus impliquant un BLOB, vous pouvez charger une grande présentation tout en utilisant peu de mémoire. Ce code PHP décrit l’implémentation où le processus BLOB est utilisé pour charger un fichier de présentation volumineux (large.pptx) :
```php
  $loadOptions = new LoadOptions();
  $loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior->KeepLocked);
  $loadOptions->getBlobManagementOptions()->setTemporaryFilesAllowed(true);
  $pres = new Presentation("large.pptx", $loadOptions);
  try {
    $pres->save("large.pdf", SaveFormat::Pdf);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


### **Modifier le dossier des fichiers temporaires**

Lorsque le processus BLOB est utilisé, votre ordinateur crée des fichiers temporaires dans le dossier par défaut. Si vous souhaitez que les fichiers temporaires soient conservés dans un autre dossier, vous pouvez changer les paramètres de stockage avec `setTempFilesRootPath` :
```php
  $loadOptions = new LoadOptions();
  $loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior->KeepLocked);
  $loadOptions->getBlobManagementOptions()->setTemporaryFilesAllowed(true);
  $loadOptions->getBlobManagementOptions()->setTempFilesRootPath("temp");

```


{{% alert title="Info" color="info" %}}
Lorsque vous utilisez `setTempFilesRootPath`, Aspose.Slides ne crée pas automatiquement de dossier pour stocker les fichiers temporaires. Vous devez créer le dossier manuellement. 
{{% /alert %}}

## **FAQ**

**Quelles données d’une présentation Aspose.Slides sont traitées comme BLOB et contrôlées par les options BLOB ?**

Les grands objets binaires tels que les images, l’audio et la vidéo sont traités comme BLOB. Le fichier complet de la présentation implique également une gestion BLOB lors de son chargement ou de son enregistrement. Ces objets sont régis par des politiques BLOB qui vous permettent de gérer l’utilisation de la mémoire et le basculement vers des fichiers temporaires si nécessaire.

**Où configurer les règles de gestion des BLOB lors du chargement d’une présentation ?**

Utilisez [LoadOptions](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/) avec [BlobManagementOptions](https://reference.aspose.com/slides/php-java/aspose.slides/blobmanagementoptions/). Vous y définissez la limite en mémoire pour les BLOB, autorisez ou interdisez les fichiers temporaires, choisissez le chemin racine des fichiers temporaires et sélectionnez le comportement de verrouillage de la source.

**Les paramètres BLOB affectent-ils les performances et comment équilibrer vitesse et mémoire ?**

Oui. Conserver les BLOB en mémoire maximise la vitesse mais augmente la consommation de RAM ; réduire la limite mémoire transfère davantage de travail vers les fichiers temporaires, diminuant la RAM au prix d’un I/O supplémentaire. Utilisez la méthode [setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/php-java/aspose.slides/blobmanagementoptions/setmaxblobsbytesinmemory/) pour trouver le bon équilibre selon votre charge de travail et votre environnement.

**Les options BLOB aident‑elles lors de l’ouverture de présentations extrêmement volumineuses (par exemple, plusieurs gigaoctets) ?**

Oui. [BlobManagementOptions](https://reference.aspose.com/slides/php-java/aspose.slides/blobmanagementoptions/) sont conçues pour ces scénarios : activer les fichiers temporaires et utiliser le verrouillage de la source peut considérablement réduire l’utilisation maximale de RAM et stabiliser le traitement de très grands decks.

**Puis‑je appliquer les politiques BLOB lors du chargement depuis des flux au lieu de fichiers disque ?**

Oui. Les mêmes règles s’appliquent aux flux : l’instance de présentation peut posséder et verrouiller le flux d’entrée (selon le mode de verrouillage choisi), et les fichiers temporaires sont utilisés lorsqu’ils sont autorisés, maintenant une utilisation prévisible de la mémoire pendant le traitement.