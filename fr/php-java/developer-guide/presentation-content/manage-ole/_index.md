---
title: Gérer OLE
type: docs
weight: 40
url: /fr/php-java/manage-ole/
keywords:
- ajouter OLE
- intégrer OLE
- ajouter un objet
- intégrer un objet
- intégrer un fichier
- objet lié
- Liaison et Intégration d'Objets
- objet OLE
- PowerPoint 
- présentation
- PHP
- Java
- Aspose.Slides pour PHP via Java
description: Ajouter des objets OLE aux présentations PowerPoint en PHP
---

{{% alert color="primary" %}} 

OLE (Liaison et Intégration d'Objets) est une technologie de Microsoft qui permet aux données et objets créés dans une application d'être placés dans une autre application par le biais de la liaison ou de l'intégration. 

{{% /alert %}} 

Considérez un graphique créé dans MS Excel. Le graphique est ensuite placé à l'intérieur d'une diapositive PowerPoint. Ce graphique Excel est considéré comme un objet OLE. 

- Un objet OLE peut apparaître sous forme d'icône. Dans ce cas, lorsque vous double-cliquez sur l'icône, le graphique s'ouvre dans son application associée (Excel), ou on vous demande de sélectionner une application pour ouvrir ou éditer l'objet. 
- Un objet OLE peut afficher des contenus réels, par exemple, le contenu d'un graphique. Dans ce cas, le graphique est activé dans PowerPoint, l'interface du graphique se charge et vous avez la possibilité de modifier les données du graphique au sein de l'application PowerPoint.

[Aspose.Slides pour PHP via Java](https://products.aspose.com/slides/php-java/) vous permet d'insérer des objets OLE dans des diapositives sous forme de Cadres d'Objet OLE ([OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/OleObjectFrame)).

## **Ajout de Cadres d'Objet OLE aux Diapositives**
Supposons que vous ayez déjà créé un graphique dans Microsoft Excel et que vous souhaitiez intégrer ce graphique dans une diapositive en tant que Cadre d'Objet OLE en utilisant Aspose.Slides pour PHP via Java, vous pouvez le faire de cette manière :

1. Créer une instance de la [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) classe.
1. Obtenir la référence de la diapositive en utilisant son index.
1. Ouvrir le fichier Excel contenant l'objet graphique Excel et le sauvegarder dans un `MemoryStream`.
1. Ajouter le [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/OleObjectFrame) à la diapositive contenant le tableau d'octets et d'autres informations sur l'objet OLE.
1. Écrire la présentation modifiée sous forme de fichier PPTX.

Dans l'exemple ci-dessous, nous avons ajouté un graphique provenant d'un fichier Excel à une diapositive sous forme de Cadre d'Objet OLE en utilisant Aspose.Slides pour PHP via Java.
**Remarque** que le constructeur [IOleEmbeddedDataInfo](https://reference.aspose.com/slides/php-java/aspose.slides/IOleEmbeddedDataInfo) prend l'extension d'un objet intégrable comme deuxième paramètre. Cette extension permet à PowerPoint d'interpréter correctement le type de fichier et de choisir l'application adéquate pour ouvrir cet objet OLE.

```php
  # Instancie la classe Prseetation qui représente le fichier PPTX
  $pres = new Presentation();
  try {
    # Accède à la première diapositive
    $sld = $pres->getSlides()->get_Item(0);
    # Charge un fichier Excel dans le flux
    $fs = new Java("java.io.FileInputStream", "book1.xlsx");
    $Array = new java_class("java.lang.reflect.Array");
    $Byte = new JavaClass("java.lang.Byte");
    $mstream = new Java("java.io.ByteArrayOutputStream");
    $buf = $Array->newInstance($Byte, 4096);
    while (true) {
      $bytesRead = $fs->read($buf, 0, $Array->getLength($buf));
      if ($bytesRead <= 0) {
        break;
      }
      $mstream->write($buf, 0, $bytesRead);
    } 
    $fs->close();
    # Crée un objet de données pour intégrer
    $dataInfo = new OleEmbeddedDataInfo($mstream->toByteArray(), "xlsx");
    $mstream->close();
    # Ajoute une forme de Cadre d'Objet Ole
    $oleObjectFrame = $sld->getShapes()->addOleObjectFrame(0, 0, $pres->getSlideSize()->getSize()->getWidth(), $pres->getSlideSize()->getSize()->getHeight(), $dataInfo);
    # Écrit le fichier PPTX sur le disque
    $pres->save("OleEmbed_out.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Accès aux Cadres d'Objet OLE**
Si un objet OLE est déjà intégré dans une diapositive, vous pouvez trouver ou accéder facilement à cet objet de cette manière :

1. Créer une instance de la [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) classe.
1. Obtenir la référence de la diapositive en utilisant son index.
1. Accéder à la forme du Cadre d'Objet OLE.

   Dans notre exemple, nous avons utilisé le PPTX précédemment créé, qui n'a qu'une seule forme sur la première diapositive. Nous avons ensuite *casté* cet objet en tant que [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/OleObjectFrame). C'était le Cadre d'Objet OLE souhaité à accéder.
1. Une fois le Cadre d'Objet OLE accessible, vous pouvez effectuer n'importe quelle opération sur celui-ci.

Dans l'exemple ci-dessous, un Cadre d'Objet OLE (un objet graphique Excel intégré dans une diapositive) est accédé - puis ses données de fichier sont écrites dans un fichier Excel.

```php
  # Charge le PPTX dans un objet Presentation
  $pres = new Presentation("AccessingOLEObjectFrame.pptx");
  try {
    # Accède à la première diapositive
    $sld = $pres->getSlides()->get_Item(0);
    # Cast la forme en OleObjectFrame
    $oleObjectFrame = $sld->getShapes()->get_Item(0);
    # Lit l'objet OLE et l'écrit sur le disque
    if (!java_is_null($oleObjectFrame)) {
      # Obtient les données du fichier intégré
      $data = $oleObjectFrame->getEmbeddedData()->getEmbeddedFileData();
      # Obtient l'extension du fichier intégré
      $fileExtention = $oleObjectFrame->getEmbeddedData()->getEmbeddedFileExtension();
      # Crée un chemin pour sauvegarder le fichier extrait
      $extractedPath = "excelFromOLE_out" . $fileExtention;
      # Sauvegarde les données extraites
      $fstr = new Java("java.io.FileOutputStream", $extractedPath);
      $Array = new java_class("java.lang.reflect.Array");
      try {
        $fstr->write($data, 0, $Array->getLength($data));
      } finally {
        $fstr->close();
      }
    }
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Modification des Données de l'Objet OLE**

Si un objet OLE est déjà intégré dans une diapositive, vous pouvez facilement accéder à cet objet et modifier ses données de cette manière :

1. Ouvrir la présentation souhaitée avec l'objet OLE intégré en créant une instance de la [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) classe.
1. Obtenir la référence de la diapositive par son index. 
1. Accéder à la forme du Cadre d'Objet OLE.

   Dans notre exemple, nous avons utilisé le PPTX précédemment créé qui n'a qu'une seule forme sur la première diapositive. Nous avons ensuite *casté* cet objet en tant que [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/OleObjectFrame). C'était le Cadre d'Objet OLE souhaité à accéder.
1. Une fois le Cadre d'Objet OLE accessible, vous pouvez effectuer n'importe quelle opération sur celui-ci.
1. Créer l'objet Workbook et accéder aux Données OLE.
1. Accéder à la feuille de calcul souhaitée et amender les données.
1. Sauvegarder le Workbook mis à jour dans des flux.
1. Modifier les données de l'objet OLE à partir des données de flux.

Dans l'exemple ci-dessous, un Cadre d'Objet OLE (un objet graphique Excel intégré dans une diapositive) est accédé - puis ses données de fichier sont modifiées pour changer les données du graphique :

```php
  $pres = new Presentation("ChangeOLEObjectData.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $ole = null;
    # Parcourt toutes les formes pour le cadre Ole
    foreach($slide->getShapes() as $shape) {
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
        $ole = $shape;
      }
    }
    if (!java_is_null($ole)) {
      $msln = new ByteArrayInputStream($ole->getEmbeddedData()->getEmbeddedFileData());
      try {
        # Lit les données de l'objet dans Workbook
        $Wb = new Workbook($msln);
        $msout = new Java("java.io.ByteArrayOutputStream");
        try {
          # Modifie les données du workbook
          $Wb->getWorksheets()->get(0)->getCells()->get(0, 4)->putValue("E");
          $Wb->getWorksheets()->get(0)->getCells()->get(1, 4)->putValue(12);
          $Wb->getWorksheets()->get(0)->getCells()->get(2, 4)->putValue(14);
          $Wb->getWorksheets()->get(0)->getCells()->get(3, 4)->putValue(15);
          $so1 = new OoxmlSaveOptions(SaveFormat::XLSX);
          $Wb->save($msout, $so1);
          # Change les données de l'objet de cadre Ole
          $newData = new OleEmbeddedDataInfo($msout->toByteArray(), $ole->getEmbeddedData()->getEmbeddedFileExtension());
          $ole->setEmbeddedData($newData);
        } finally {
          if (!java_is_null($msout)) {
            $msout->close();
          }
        }
      } finally {
        if (!java_is_null($msln)) {
          $msln->close();
        }
      }
    }
    $pres->save("OleEdit_out.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## Intégration d'Autres Types de Fichiers dans les Diapositives

Outre les graphiques Excel, Aspose.Slides pour PHP via Java permet d'intégrer d'autres types de fichiers dans les diapositives. Par exemple, vous pouvez insérer des fichiers HTML, PDF et ZIP en tant qu'objets dans une diapositive. Lorsqu'un utilisateur double-clique sur l'objet inséré, l'objet est automatiquement lancé dans le programme pertinent, ou l'utilisateur est dirigé pour sélectionner un programme approprié pour ouvrir l'objet.

Ce code PHP vous montre comment intégrer du HTML et un fichier ZIP dans une diapositive :

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
$Array = new JavaClass("java.lang.reflect.Array");
$Byte = (new JavaClass("java.lang.Byte"))->TYPE;
try {
    $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", "embedOle.html"));
    $bytes = $Array->newInstance($Byte, $dis->available());
    $dis->readFully($bytes);
} finally {
    if (!java_is_null($dis)) $dis->close();
}
    $htmlBytes = $bytes;

    $dataInfoHtml = new OleEmbeddedDataInfo($htmlBytes, "html");
    $oleFrameHtml = $slide->getShapes()->addOleObjectFrame(150, 120, 50, 50, $dataInfoHtml);
    $oleFrameHtml->setObjectIcon(true);
try {
    $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", "embedOle.zip"));
    $bytes = $Array->newInstance($Byte, $dis->available());
    $dis->readFully($bytes);
} finally {
    if (!java_is_null($dis)) $dis->close();
}
    $zipBytes = $bytes;

    $dataInfoZip = new OleEmbeddedDataInfo($zipBytes, "zip");
    $oleFrameZip = $slide->getShapes()->addOleObjectFrame(150, 220, 50, 50, $dataInfoZip);
    $oleFrameZip->setObjectIcon(true);
    $pres->save("embeddedOle.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## Définir les Types de Fichiers pour les Objets Intégrés

Lorsque vous travaillez sur des présentations, il se peut que vous ayez besoin de remplacer d'anciens objets OLE par de nouveaux. Ou vous pourriez avoir besoin de remplacer un objet OLE non pris en charge par un objet pris en charge. 

Aspose.Slides pour PHP via Java vous permet de définir le type de fichier pour un objet intégré. De cette manière, vous pouvez modifier les données du cadre OLE ou son extension.

Ce Java vous montre comment définir le type de fichier pour un objet OLE intégré :

```php
  $pres = new Presentation("embeddedOle.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $oleObjectFrame = $slide->getShapes()->get_Item(0);
    echo("L'extension des données intégrées actuelle est : " . $oleObjectFrame->getEmbeddedData()->getEmbeddedFileExtension());
$Array = new JavaClass("java.lang.reflect.Array");
$Byte = (new JavaClass("java.lang.Byte"))->TYPE;
try {
    $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", "embedOle.zip"));
    $bytes = $Array->newInstance($Byte, $dis->available());
    $dis->readFully($bytes);
} finally {
    if (!java_is_null($dis)) $dis->close();
}
    $oleObjectFrame->setEmbeddedData(new OleEmbeddedDataInfo($bytes, "zip"));

    $pres->save("embeddedChanged.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## Définir des Images et Titres d'Icônes pour les Objets Intégrés

Après avoir intégré un objet OLE, un aperçu composé d'une image d'icône et d'un titre est ajouté automatiquement. L'aperçu est ce que les utilisateurs voient avant d'accéder ou d'ouvrir l'objet OLE. 

Si vous souhaitez utiliser une image et un texte spécifiques comme éléments de l'aperçu, vous pouvez définir l'image d'icône et le titre en utilisant Aspose.Slides pour PHP via Java.

Ce code PHP vous montre comment définir l'image d'icône et le titre pour un objet intégré :

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $oleObjectFrame = $slide->getShapes()->get_Item(0);
    $oleImage;
    $image = Images->fromFile("image.png");
    try {
      $oleImage = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    $oleObjectFrame->setSubstitutePictureTitle("Mon titre");
    $oleObjectFrame->getSubstitutePictureFormat()->getPicture()->setImage($oleImage);
    $oleObjectFrame->setObjectIcon(false);
    $pres->save("embeddedOle-newImage.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Prévenir un Cadre d'Objet OLE d'être Redimensionné et Repositionné**

Après avoir ajouté un objet OLE lié à une diapositive de présentation, lorsque vous ouvrez la présentation dans PowerPoint, vous pourriez voir un message vous demandant de mettre à jour les liens. En cliquant sur le bouton "Mettre à jour les liens", la taille et la position du cadre d'objet OLE peuvent changer parce que PowerPoint met à jour les données de l'objet OLE lié et rafraîchit l'aperçu de l'objet. Pour empêcher PowerPoint de demander la mise à jour des données de l'objet, définissez la méthode `setUpdateAutomatic` de la classe [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) sur `false` :

```php
$oleObjectFrame->setUpdateAutomatic(false);
```

## Extraction de Fichiers Intégrés

Aspose.Slides pour PHP via Java vous permet d'extraire les fichiers intégrés dans les diapositives sous forme d'objets OLE de cette manière :

1. Créer une instance de la [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) classe contenant l'objet OLE que vous souhaitez extraire.
2. Boucler à travers toutes les formes dans la présentation et accéder à la forme [OLEObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe).
3. Accéder aux données du fichier intégré à partir du Cadre d'Objet OLE et écrire sur disque. 

Ce code PHP vous montre comment extraire un fichier intégré dans une diapositive sous forme d'objet OLE :

```php
  $pres = new Presentation("embeddedOle.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    for($index = 0; $index < java_values($slide->getShapes()->size()) ; $index++) {
      $shape = $slide->getShapes()->get_Item($index);
      $oleFrame = $shape;
      if (!java_is_null($oleFrame)) {
        $data = $oleFrame->getEmbeddedData()->getEmbeddedFileData();
        $extension = $oleFrame->getEmbeddedData()->getEmbeddedFileExtension();
        # Sauvegarde des données extraites
        $fstr = new Java("java.io.FileOutputStream", "oleFrame" . $index . $extension);
        $Array = new java_class("java.lang.reflect.Array");
        try {
          $fstr->write($data, 0, $Array->getLength($data));
        } finally {
          $fstr->close();
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
