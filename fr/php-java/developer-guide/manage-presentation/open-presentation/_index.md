---
title: Ouvrir la Présentation
linktitle: Ouvrir la Présentation
type: docs
weight: 20
url: /fr/php-java/open-presentation/
keywords: "Ouvrir PowerPoint, PPTX, PPT, Ouvrir la Présentation, Charger la Présentation, Java"
description: "Ouvrir ou charger la Présentation PPT, PPTX, ODP"
---

En plus de créer des présentations PowerPoint à partir de zéro, Aspose.Slides vous permet d'ouvrir des présentations existantes. Une fois que vous avez chargé une présentation, vous pouvez obtenir des informations sur la présentation, modifier la présentation (le contenu de ses diapositives), ajouter de nouvelles diapositives ou supprimer celles existantes, etc.

## Ouvrir la Présentation

Pour ouvrir une présentation existante, vous devez simplement instancier la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) et passer le chemin du fichier (de la présentation que vous souhaitez ouvrir) à son constructeur.

Ce code PHP vous montre comment ouvrir une présentation et également découvrir le nombre de diapositives qu'elle contient :

```php
  # Instancie la classe Presentation et passe le chemin du fichier à son constructeur
  $pres = new Presentation("Presentation.pptx");
  try {
    # Affiche le nombre total de diapositives présentes dans la présentation
    echo($pres->getSlides()->size());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Ouvrir une Présentation Protégée par Mot de Passe**

Lorsque vous devez ouvrir une présentation protégée par un mot de passe, vous pouvez passer le mot de passe via la propriété [Password](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/#getPassword--) (de la classe [LoadOptions](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/)) pour déchiffrer la présentation et charger la présentation. Ce code PHP démontre l'opération :

```php
  $loadOptions = new LoadOptions();
  $loadOptions->setPassword("VOTRE_MOT_DE_PASSE");
  $pres = new Presentation("pres.pptx", $loadOptions);
  try {
    # Faites des travaux avec la présentation déchiffrée
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## Ouvrir une Grande Présentation

Aspose.Slides fournit des options (la propriété [BlobManagementOptions](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/#setBlobManagementOptions-com.aspose.slides.IBlobManagementOptions-) en particulier) sous la classe [LoadOptions](https://reference.aspose.com/slides/php-java/aspose.slides/LoadOptions) pour vous permettre de charger de grandes présentations.

Ce Java démontrer une opération dans laquelle une grande présentation (disons de 2 Go) est chargée :

```php
  $loadOptions = new LoadOptions();
  $loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior->KeepLocked);
  $loadOptions->getBlobManagementOptions()->setTemporaryFilesAllowed(true);
  $loadOptions->getBlobManagementOptions()->setMaxBlobsBytesInMemory(0);
  $pres = new Presentation("veryLargePresentation.pptx", $loadOptions);
  try {
    # La grande présentation a été chargée et peut être utilisée, mais la consommation de mémoire reste faible.
    # effectue des modifications sur la présentation.
    $pres->getSlides()->get_Item(0)->setName("Très grande présentation");
    # La présentation sera sauvegardée dans l'autre fichier. La consommation de mémoire reste faible pendant l'opération
    $pres->save("veryLargePresentation-copy.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="info" title="Info" %}}

Pour contourner certaines limitations lors de l'interaction avec un flux, Aspose.Slides peut copier le contenu du flux. Charger une grande présentation via son flux entraînera la copie du contenu de la présentation et provoquera un chargement lent. Par conséquent, lorsque vous souhaitez charger une grande présentation, nous vous recommandons fortement d'utiliser le chemin du fichier de présentation et non son flux.

Lorsque vous souhaitez créer une présentation contenant de grands objets (vidéo, audio, grandes images, etc.), vous pouvez utiliser la [facilité Blob](https://docs.aspose.com/slides/php-java/manage-blob/) pour réduire la consommation de mémoire.

{{%/alert %}} 

## Charger la Présentation

Aspose.Slides fournit [IResourceLoadingCallback](https://reference.aspose.com/slides/php-java/aspose.slides/iresourceloadingcallback/) avec une seule méthode pour vous permettre de gérer les ressources externes. Ce code PHP vous montre comment utiliser l'interface `IResourceLoadingCallback` :

```php

class ImageLoadingHandler {
    function resourceLoading($args) {
      if (java_values($args->getOriginalUri()->endsWith(".jpg"))) {
        # charge l'image de substitution
        $file = new Java("java.io.File", "aspose-logo.jpg");
        $Array = new JavaClass("java.lang.reflect.Array");
        $Byte = new JavaClass("java.lang.Byte");
        $imageBytes = $Array->newInstance($Byte, $Array->getLength($file));
        try {
            $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", $file));
            $dis->readFully($imageBytes);
        } finally {
            if (!java_is_null($dis)) $dis->close();
        }
          $args->setData($imageBytes);
          return ResourceLoadingAction::UserProvided;
      } else if (java_values($args->getOriginalUri()->endsWith(".png"))) {
        # définit l'url de substitution
        $args->setUri("http://www.google.com/images/logos/ps_logo2.png");
        return ResourceLoadingAction::Default;
      }
      # ignore toutes les autres images
      return ResourceLoadingAction::Skip;
    }
  }

  $opts = new LoadOptions();
  $loadingHandler = java_closure(new ImageLoadingHandler(), null, java("com.aspose.slides.IResourceLoadingCallback"));
  $opts->setResourceLoadingCallback($loadingHandler);
  $pres = new Presentation("presentation.pptx", $opts);
```

## Charger la Présentation Sans Objets Binaires Intégrés

La présentation PowerPoint peut contenir les types suivants d'objets binaires intégrés :

- Projet VBA ([IPresentation.VbaProject](https://reference.aspose.com/slides/java/com.aspose.slides/vbaproject/));
- Données d'objet OLE intégrées ([IOleEmbeddedDataInfo.EmbeddedFileData](https://reference.aspose.com/slides/java/com.aspose.slides/ioleembeddeddatainfo/#getEmbeddedFileData--));
- Données binaires de contrôle ActiveX ([IControl.ActiveXControlBinary](https://reference.aspose.com/slides/java/com.aspose.slides/icontrol/#getActiveXControlBinary--));

En utilisant la propriété [ILoadOptions.DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/java/com.aspose.slides/iloadoptions/#setDeleteEmbeddedBinaryObjects-boolean-), vous pouvez charger la présentation sans aucun objet binaire intégré.

Cette propriété peut être utile pour supprimer un contenu binaire potentiellement malveillant.

Le code démontre comment charger et sauvegarder une présentation sans aucun contenu malveillant :

```java
  $loadOptions = new LoadOptions();
  $loadOptions->setDeleteEmbeddedBinaryObjects(true);

  $pres = new Presentation("malware.ppt", $loadOptions);
  try {
    $pres->save("clean.ppt", SaveFormat::Ppt);
  } finally {
    if (!java_is_null(pres)) { 
      $pres->dispose();
    }
  }
```

## Ouvrir et Sauvegarder la Présentation

Étapes pour Ouvrir et Sauvegarder une Présentation :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) et passez le fichier que vous souhaitez ouvrir.
2. Sauvegardez la présentation.

```php
  # Instancie un objet Presentation qui représente un fichier PPT
  $pres = new Presentation();
  try {
    # ... faites votre travail ici ...
    # Sauvegarde votre présentation dans un fichier
    $pres->save("demoPass.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```