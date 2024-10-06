---
title: Gérer Blob
type: docs
weight: 10
url: /php-java/manage-blob/
description: Gérer Blob dans une présentation PowerPoint en utilisant PHP. Utiliser Blob pour réduire la consommation de mémoire dans une présentation PowerPoint en utilisant PHP. Ajouter un gros fichier par le biais de Blob à une présentation PowerPoint en utilisant PHP. Exporter un gros fichier par le biais de Blob depuis une présentation PowerPoint en utilisant PHP. Charger une grande présentation PowerPoint en tant que Blob en utilisant PHP.
---

## **À propos de BLOB**

**BLOB** (**Binary Large Object**) est généralement un élément volumineux (photo, présentation, document ou média) enregistré au format binaire.

Aspose.Slides pour PHP via Java vous permet d'utiliser des BLOBs pour les objets d'une manière qui réduit la consommation de mémoire lorsque des fichiers volumineux sont impliqués.

{{% alert title="Info" color="info" %}}

Pour contourner certaines limitations lors de l'interaction avec les flux, Aspose.Slides peut copier le contenu du flux. Charger une grande présentation via son flux entraînera la copie du contenu de la présentation et causera un chargement lent. Par conséquent, lorsque vous envisagez de charger une grande présentation, nous vous recommandons fortement d'utiliser le chemin du fichier de présentation et non son flux.

{{% /alert %}}

## **Utiliser BLOB pour Réduire la Consommation de Mémoire**

### **Ajouter un Gros Fichier par BLOB à une Présentation**

[Aspose.Slides](/slides/php-java/) pour Java vous permet d'ajouter de gros fichiers (dans ce cas, un gros fichier vidéo) par un processus impliquant des BLOBs pour réduire la consommation de mémoire.

Ce code Java vous montre comment ajouter un gros fichier vidéo via le processus BLOB à une présentation :

```php
  $pathToVeryLargeVideo = "veryLargeVideo.avi";
  # Crée une nouvelle présentation à laquelle la vidéo sera ajoutée
  $pres = new Presentation();
  try {
    $fileStream = new Java("java.io.FileInputStream", $pathToVeryLargeVideo);
    try {
      # Ajoutons la vidéo à la présentation - nous choisissons le comportement KeepLocked parce que nous ne 
      # prévoyons pas d'accéder au fichier "veryLargeVideo.avi".
      $video = $pres->getVideos()->addVideo($fileStream, LoadingStreamBehavior->KeepLocked);
      $pres->getSlides()->get_Item(0)->getShapes()->addVideoFrame(0, 0, 480, 270, $video);
      # Sauvegarde la présentation. Bien qu'une grande présentation soit produite, la consommation de mémoire
      # reste faible pendant le cycle de vie de l'objet pres.
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

### **Exporter un Gros Fichier par BLOB depuis une Présentation**
Aspose.Slides pour PHP via Java vous permet d'exporter de gros fichiers (dans ce cas, un fichier audio ou vidéo) par un processus impliquant des BLOBs depuis des présentations. Par exemple, vous pourriez avoir besoin d'extraire un gros fichier multimédia d'une présentation sans que le fichier soit chargé dans la mémoire de votre ordinateur. En exportant le fichier par le biais du processus BLOB, vous parvenez à maintenir la consommation de mémoire à un faible niveau.

Ce code démontre l'opération décrite :

```php
  $hugePresentationWithAudiosAndVideosFile = "LargeVideoFileTest.pptx";
  $loadOptions = new LoadOptions();
  # Verrouille le fichier source et ne le charge PAS en mémoire
  $loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior->KeepLocked);
  # crée l'instance de la Présentation, verrouille le fichier "hugePresentationWithAudiosAndVideos.pptx".
  $pres = new Presentation($hugePresentationWithAudiosAndVideosFile, $loadOptions);
  try {
    # Sauvons chaque vidéo dans un fichier. Pour éviter une consommation élevée de mémoire, nous avons besoin
    # d'un tampon qui sera utilisé pour transférer les données depuis le flux vidéo de la présentation vers un flux pour un nouveau fichier vidéo créé.
    $Array = new JavaClass("java.lang.reflect.Array");
    $Byte = new JavaClass("java.lang.Byte");
    $buffer = $Array->newInstance($Byte, 8 * 1024);
    # Itère à travers les vidéos
    for($index = 0; $index < java_values($pres->getVideos()->size()) ; $index++) {
      $video = $pres->getVideos()->get_Item($index);
      # Ouvre le flux vidéo de la présentation. Veuillez noter que nous avons intentionnellement évité d'accéder aux propriétés
      # comme video.BinaryData - car cette propriété retourne un tableau d'octets contenant une vidéo complète, ce qui charge ensuite
      # des octets en mémoire. Nous utilisons video.GetStream, qui renvoie un Stream - et ne nécessite pas
      # que nous chargions toute la vidéo en mémoire.
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
    # Si nécessaire, vous pouvez appliquer les mêmes étapes pour les fichiers audio.
  } catch (JavaException $e) {
  } finally {
    $pres->dispose();
  }
```

### **Ajouter une Image en tant que BLOB dans une Présentation**
Avec les méthodes de l'interface [**IImageCollection**](https://reference.aspose.com/slides/php-java/aspose.slides/IImageCollection) et de la classe [**ImageCollection**](https://reference.aspose.com/slides/php-java/aspose.slides/ImageCollection), vous pouvez ajouter une grande image en tant que flux pour qu'elle soit traitée comme un BLOB.

Ce code PHP vous montre comment ajouter une grande image via le processus BLOB :

```php
  $pathToLargeImage = "large_image.jpg";
  # crée une nouvelle présentation à laquelle l'image sera ajoutée.
  $pres = new Presentation();
  try {
    $fileStream = new Java("java.io.FileInputStream", $pathToLargeImage);
    try {
      # Ajoutons l'image à la présentation - nous choisissons le comportement KeepLocked parce que nous ne
      # prévoyons PAS d'accéder au fichier "largeImage.png".
      $img = $pres->getImages()->addImage($fileStream, LoadingStreamBehavior->KeepLocked);
      $pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 0, 0, 300, 200, $img);
      # Sauvegarde la présentation. Bien qu'une grande présentation soit produite, la consommation de mémoire
      # reste faible pendant le cycle de vie de l'objet pres.
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

## **Mémoire et Grandes Présentations**

En général, pour charger une grande présentation, les ordinateurs nécessitent beaucoup de mémoire temporaire. Tout le contenu de la présentation est chargé en mémoire et le fichier (à partir duquel la présentation a été chargée) cesse d'être utilisé.

Considérez une grande présentation PowerPoint (large.pptx) qui contient un fichier vidéo de 1,5 Go. La méthode standard pour charger la présentation est décrite dans ce code PHP :

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

### **Charger une Grande Présentation en tant que BLOB**

Grâce au processus impliquant un BLOB, vous pouvez charger une grande présentation tout en utilisant peu de mémoire. Ce code PHP décrit l'implémentation où le processus BLOB est utilisé pour charger un fichier de présentation volumineux (large.pptx) :

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

### **Changer le Dossier pour les Fichiers Temporaires**

Lorsque le processus BLOB est utilisé, votre ordinateur crée des fichiers temporaires dans le dossier par défaut pour les fichiers temporaires. Si vous souhaitez que les fichiers temporaires soient conservés dans un autre dossier, vous pouvez changer les paramètres de stockage en utilisant `TempFilesRootPath` :

```php
  $loadOptions = new LoadOptions();
  $loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior->KeepLocked);
  $loadOptions->getBlobManagementOptions()->setTemporaryFilesAllowed(true);
  $loadOptions->getBlobManagementOptions()->setTempFilesRootPath("temp");

```

{{% alert title="Info" color="info" %}}

Lorsque vous utilisez `TempFilesRootPath`, Aspose.Slides ne crée pas automatiquement un dossier pour stocker les fichiers temporaires. Vous devez créer le dossier manuellement.

{{% /alert %}}