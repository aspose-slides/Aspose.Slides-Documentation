---
title: Manipulations de Formes
type: docs
weight: 40
url: /fr/php-java/shape-manipulations/
---

## **Trouver une forme dans une diapositive**
Ce sujet décrira une technique simple pour faciliter aux développeurs la recherche d'une forme spécifique sur une diapositive sans utiliser son Id interne. Il est important de savoir que les fichiers de présentation PowerPoint n'ont aucun moyen d'identifier les formes sur une diapositive à part un Id unique interne. Il semble difficile pour les développeurs de trouver une forme en utilisant son Id unique interne. Toutes les formes ajoutées aux diapositives ont un texte alternatif. Nous suggérons aux développeurs d'utiliser le texte alternatif pour trouver une forme spécifique. Vous pouvez utiliser MS PowerPoint pour définir le texte alternatif pour les objets que vous prévoyez de modifier à l'avenir.

Après avoir défini le texte alternatif de la forme souhaitée, vous pouvez ensuite ouvrir cette présentation en utilisant Aspose.Slides pour PHP via Java et itérer à travers toutes les formes ajoutées à une diapositive. Lors de chaque itération, vous pouvez vérifier le texte alternatif de la forme et la forme avec le texte alternatif correspondant serait la forme requise. Pour démontrer cette technique de manière meilleure, nous avons créé une méthode, [findShape](https://reference.aspose.com/slides/php-java/aspose.slides/SlideUtil#findShape-com.aspose.slides.IBaseSlide-java.lang.String-) qui fait le travail de trouver une forme spécifique dans une diapositive et retourne simplement cette forme.

```php
  # Instancier une classe Presentation qui représente le fichier de présentation
  $pres = new Presentation("FindingShapeInSlide.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    # Texte alternatif de la forme à trouver
    $shape = findShape($slide, "Shape1");
    if (!java_is_null($shape)) {
      echo("Nom de la forme: " . $shape->getName());
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
```php

```

## **Cloner une forme**
Pour cloner une forme sur une diapositive en utilisant Aspose.Slides pour PHP via Java :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Obtenez la référence d'une diapositive en utilisant son index.
1. Accédez à la collection de formes de la diapositive source.
1. Ajoutez une nouvelle diapositive à la présentation.
1. Clonez les formes de la collection de formes de la diapositive source à la nouvelle diapositive.
1. Enregistrez la présentation modifiée en tant que fichier PPTX.

L'exemple ci-dessous ajoute une forme groupée à une diapositive.

```php
  # Instancier la classe Presentation
  $pres = new Presentation("Source Frame.pptx");
  try {
    $sourceShapes = $pres->getSlides()->get_Item(0)->getShapes();
    $blankLayout = $pres->getMasters()->get_Item(0)->getLayoutSlides()->getByType(SlideLayoutType::Blank);
    $destSlide = $pres->getSlides()->addEmptySlide($blankLayout);
    $destShapes = $destSlide->getShapes();
    $destShapes->addClone($sourceShapes->get_Item(1), 50, 150 + $sourceShapes->get_Item(0)->getHeight());
    $destShapes->addClone($sourceShapes->get_Item(2));
    $destShapes->insertClone(0, $sourceShapes->get_Item(0), 50, 150);
    # Écrire le fichier PPTX sur le disque
    $pres->save("CloneShape_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Supprimer une forme**
Aspose.Slides pour PHP via Java permet aux développeurs de supprimer n'importe quelle forme. Pour supprimer la forme d'une diapositive, veuillez suivre les étapes ci-dessous :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Accédez à la première diapositive.
1. Trouvez la forme avec un AlternativeText spécifique.
1. Supprimez la forme.
1. Enregistrez le fichier sur le disque.

```php
  # Créer un objet Presentation
  $pres = new Presentation();
  try {
    # Obtenir la première diapositive
    $sld = $pres->getSlides()->get_Item(0);
    # Ajouter une autoforme de type rectangle
    $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 40, 150, 50);
    $sld->getShapes()->addAutoShape(ShapeType::Moon, 160, 40, 150, 50);
    $altText = "Défini par l'utilisateur";
    $iCount = $sld->getShapes()->size();
    for($i = 0; $i < java_values($iCount) ; $i++) {
      $ashp = $sld->getShapes()->get_Item(0);
      if ($alttext->equals($ashp->getAlternativeText())) {
        $sld->getShapes()->remove($ashp);
      }
    }
    # Enregistrer la présentation sur le disque
    $pres->save("RemoveShape_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Cacher une forme**
Aspose.Slides pour PHP via Java permet aux développeurs de cacher n'importe quelle forme. Pour cacher la forme d'une diapositive, veuillez suivre les étapes ci-dessous :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Accédez à la première diapositive.
1. Trouvez la forme avec un AlternativeText spécifique.
1. Cachez la forme.
1. Enregistrez le fichier sur le disque.

```php
  # Instancier la classe Presentation qui représente le PPTX
  $pres = new Presentation();
  try {
    # Obtenir la première diapositive
    $sld = $pres->getSlides()->get_Item(0);
    # Ajouter une autoforme de type rectangle
    $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 40, 150, 50);
    $sld->getShapes()->addAutoShape(ShapeType::Moon, 160, 40, 150, 50);
    $alttext = "Défini par l'utilisateur";
    $iCount = $sld->getShapes()->size();
    for($i = 0; $i < java_values($iCount) ; $i++) {
      $ashp = $sld->getShapes()->get_Item($i);
      if ($alttext->equals($ashp->getAlternativeText())) {
        $ashp->setHidden(true);
      }
    }
    # Enregistrer la présentation sur le disque
    $pres->save("Hiding_Shapes_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Changer l'ordre des formes**
Aspose.Slides pour PHP via Java permet aux développeurs de réorganiser les formes. La réorganisation des formes précise quelle forme est au premier plan ou quelle forme est à l'arrière. Pour réorganiser les formes d'une diapositive, veuillez suivre les étapes ci-dessous :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Accédez à la première diapositive.
1. Ajoutez une forme.
1. Ajoutez du texte dans le cadre de texte de la forme.
1. Ajoutez une autre forme avec les mêmes coordonnées.
1. Réorganisez les formes.
1. Enregistrez le fichier sur le disque.

```php
  $pres = new Presentation("ChangeShapeOrder.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $shp3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 365, 400, 150);
    $shp3->getFillFormat()->setFillType(FillType::NoFill);
    $shp3->addTextFrame(" ");
    $para = $shp3->getTextFrame()->getParagraphs()->get_Item(0);
    $portion = $para->getPortions()->get_Item(0);
    $portion->setText("Texte de Filigrane Texte de Filigrane Texte de Filigrane");
    $shp3 = $slide->getShapes()->addAutoShape(ShapeType::Triangle, 200, 365, 400, 150);
    $slide->getShapes()->reorder(2, $shp3);
    $pres->save("Reshape_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Obtenir l'ID de forme Interop**
Aspose.Slides pour PHP via Java permet aux développeurs d'obtenir un identifiant de forme unique dans le cadre de la diapositive contrairement à la méthode [getUniqueId](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#getUniqueId--) qui permet d'obtenir un identifiant unique dans le cadre de la présentation. La méthode [getOfficeInteropShapeId](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#getOfficeInteropShapeId--) a été ajoutée aux interfaces [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShape) et à la classe [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/Shape). La valeur retournée par la méthode [getOfficeInteropShapeId](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#getOfficeInteropShapeId--) correspond à la valeur de l'Id de l'objet Microsoft.Office.Interop.PowerPoint.Shape. Ci-dessous un échantillon de code est donné.

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # Obtenir l'identifiant unique de forme dans le cadre de la diapositive
    $officeInteropShapeId = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getOfficeInteropShapeId();
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Définir le texte alternatif pour une forme**
Aspose.Slides pour PHP via Java permet aux développeurs de définir le texte alternatif de n'importe quelle forme. 
Les formes dans une présentation peuvent être distinguées par la méthode [AlternativeText](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#setAlternativeText-java.lang.String-) ou [Nom de la forme](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#setName-java.lang.String-).
Les méthodes [setAlternativeText](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#setAlternativeText-java.lang.String-) et [getAlternativeText](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#getAlternativeText--) peuvent être lues ou définies en utilisant Aspose.Slides ainsi que Microsoft PowerPoint. 
En utilisant cette méthode, vous pouvez taguer une forme et effectuer différentes opérations telles que la suppression d'une forme, le masquage d'une forme ou la réorganisation des formes sur une diapositive. 
Pour définir le texte alternatif d'une forme, veuillez suivre les étapes ci-dessous :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Accédez à la première diapositive.
1. Ajoutez une forme à la diapositive.
1. Faites quelques travaux avec la forme nouvellement ajoutée.
1. Parcourez les formes pour trouver une forme.
1. Définissez le texte alternatif.
1. Enregistrez le fichier sur le disque.

```php
  # Instancier la classe Presentation qui représente le PPTX
  $pres = new Presentation();
  try {
    # Obtenir la première diapositive
    $sld = $pres->getSlides()->get_Item(0);
    # Ajouter une autoforme de type rectangle
    $shp1 = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 40, 150, 50);
    $shp2 = $sld->getShapes()->addAutoShape(ShapeType::Moon, 160, 40, 150, 50);
    $shp2->getFillFormat()->setFillType(FillType::Solid);
    $shp2->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    for($i = 0; $i < java_values($sld->getShapes()->size()) ; $i++) {
      $shape = $sld->getShapes()->get_Item($i);
      if (!java_is_null($shape)) {
        $shape->setAlternativeText("Défini par l'utilisateur");
      }
    }
    # Enregistrer la présentation sur le disque
    $pres->save("Set_AlternativeText_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Accéder aux formats de mise en page pour une forme**
Aspose.Slides pour PHP via Java fournit une API simple pour accéder aux formats de mise en page pour une forme. Cet article démontre comment vous pouvez accéder aux formats de mise en page.

Ci-dessous un échantillon de code est donné.

```php
  $pres = new Presentation("pres.pptx");
  try {
    foreach($pres->getLayoutSlides() as $layoutSlide) {
      foreach($layoutSlide->getShapes() as $shape) {
        $fillFormats = $shape->getFillFormat();
        $lineFormats = $shape->getLineFormat();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Rendre une forme en tant que SVG**
Désormais, Aspose.Slides pour PHP via Java prend en charge le rendu d'une forme en tant que svg. La méthode [writeAsSvg](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#writeAsSvg-java.io.OutputStream-) (et son surcharge) a été ajoutée à la classe [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/Shape) et à l'interface [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShape). Cette méthode permet de sauvegarder le contenu de la forme en tant que fichier SVG. L'extrait de code ci-dessous montre comment exporter la forme de la diapositive en un fichier SVG.

```php
  $pres = new Presentation("TestExportShapeToSvg.pptx");
  try {
    $stream = new Java("java.io.FileOutputStream", "SingleShape.svg");
    try {
      $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->writeAsSvg($stream);
    } finally {
      if (!java_is_null($stream)) {
        $stream->close();
      }
    }
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Alignement des formes**
Aspose.Slides permet d'aligner les formes soit par rapport aux marges de la diapositive, soit par rapport les unes aux autres. À cet effet, la méthode surchargée [SlidesUtil.alignShape()](https://reference.aspose.com/slides/php-java/aspose.slides/SlideUtil#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-) a été ajoutée. L'énumération [ShapesAlignmentType](https://reference.aspose.com/slides/php-java/aspose.slides/ShapesAlignmentType) définit les options d'alignement possibles.

**Exemple 1**

Le code source ci-dessous aligne les formes aux indices 1, 2 et 4 le long du bord supérieur de la diapositive.

```php
  $pres = new Presentation("example.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $shape1 = $slide->getShapes()->get_Item(1);
    $shape2 = $slide->getShapes()->get_Item(2);
    $shape3 = $slide->getShapes()->get_Item(4);
    SlideUtil->alignShapes(ShapesAlignmentType::AlignTop, true, $pres->getSlides()->get_Item(0), array($slide->getShapes()->indexOf($shape1), $slide->getShapes()->indexOf($shape2), $slide->getShapes()->indexOf($shape3) ));
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

**Exemple 2**

L'exemple ci-dessous montre comment aligner toute la collection de formes par rapport à la forme la plus basse de la collection.

```php
  $pres = new Presentation("example.pptx");
  try {
    SlideUtil->alignShapes(ShapesAlignmentType::AlignBottom, false, $pres->getSlides()->get_Item(0));
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```