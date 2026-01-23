---
title: Gérer les formes de présentation en PHP
linktitle: Manipulation des formes
type: docs
weight: 40
url: /fr/php-java/shape-manipulations/
keywords:
- forme PowerPoint
- forme de présentation
- forme sur diapositive
- trouver forme
- cloner forme
- supprimer forme
- masquer forme
- changer l'ordre des formes
- obtenir l'ID de forme interop
- texte alternatif de forme
- formats de mise en page de forme
- forme en SVG
- forme vers SVG
- aligner forme
- PowerPoint
- présentation
- PHP
- Aspose.Slides
description: "Apprenez à créer, modifier et optimiser les formes dans Aspose.Slides pour PHP via Java et à livrer des présentations PowerPoint haute performance."
---

## **Trouver une forme sur une diapositive**
Cet article décrit une technique simple pour faciliter la recherche d'une forme spécifique sur une diapositive sans utiliser son Id interne. Il est important de savoir que les fichiers de présentation PowerPoint ne disposent d'aucun moyen d'identifier les formes sur une diapositive, à l'exception d'un Id unique interne. Il semble difficile pour les développeurs de trouver une forme en utilisant son Id unique interne. Toutes les formes ajoutées aux diapositives possèdent un texte alternatif. Nous suggérons aux développeurs d'utiliser le texte alternatif pour trouver une forme spécifique. Vous pouvez utiliser MS PowerPoint pour définir le texte alternatif des objets que vous prévoyez de modifier ultérieurement.

Après avoir défini le texte alternatif de la forme souhaitée, vous pouvez ouvrir cette présentation en utilisant Aspose.Slides for PHP via Java et parcourir toutes les formes ajoutées à une diapositive. À chaque itération, vous pouvez vérifier le texte alternatif de la forme et la forme dont le texte alternatif correspond sera celle dont vous avez besoin. Pour illustrer cette technique de manière plus claire, nous avons créé une méthode, [findShape](https://reference.aspose.com/slides/php-java/aspose.slides/SlideUtil#findShape-com.aspose.slides.IBaseSlide-java.lang.String-) qui permet de trouver une forme spécifique dans une diapositive et renvoie simplement cette forme.
```php
  # Instancier une classe Presentation qui représente le fichier de présentation
  $pres = new Presentation("FindingShapeInSlide.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    # Texte alternatif de la forme à trouver
    $shape = findShape($slide, "Shape1");
    if (!java_is_null($shape)) {
      echo("Shape Name: " . $shape->getName());
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
Pour cloner une forme sur une diapositive en utilisant Aspose.Slides for PHP via Java :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Obtenir la référence d'une diapositive en utilisant son index.
3. Accéder à la collection de formes de la diapositive source.
4. Ajouter une nouvelle diapositive à la présentation.
5. Cloner les formes de la collection de formes de la diapositive source vers la nouvelle diapositive.
6. Enregistrer la présentation modifiée au format PPTX.

L'exemple ci‑dessous ajoute une forme groupée à une diapositive.
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
    # Enregistrer le fichier PPTX sur le disque
    $pres->save("CloneShape_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Supprimer une forme**
Aspose.Slides for PHP via Java permet aux développeurs de supprimer n'importe quelle forme. Pour supprimer la forme d'une diapositive, suivez les étapes ci‑dessous :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Accéder à la première diapositive.
3. Trouver la forme avec un AlternativeText spécifique.
4. Supprimer la forme.
5. Enregistrer le fichier sur le disque.
```php
  # Créer l'objet Presentation
  $pres = new Presentation();
  try {
    # Obtenir la première diapositive
    $sld = $pres->getSlides()->get_Item(0);
    # Ajouter une forme auto de type rectangle
    $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 40, 150, 50);
    $sld->getShapes()->addAutoShape(ShapeType::Moon, 160, 40, 150, 50);
    $altText = "User Defined";
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


## **Masquer une forme**
Aspose.Slides for PHP via Java permet aux développeurs de masquer n'importe quelle forme. Pour masquer la forme d'une diapositive, suivez les étapes ci‑dessous :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Accéder à la première diapositive.
3. Trouver la forme avec un AlternativeText spécifique.
4. Masquer la forme.
5. Enregistrer le fichier sur le disque.
```php
  # Instancier la classe Presentation qui représente le PPTX
  $pres = new Presentation();
  try {
    # Obtenir la première diapositive
    $sld = $pres->getSlides()->get_Item(0);
    # Ajouter une forme auto de type rectangle
    $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 40, 150, 50);
    $sld->getShapes()->addAutoShape(ShapeType::Moon, 160, 40, 150, 50);
    $alttext = "User Defined";
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


## **Modifier l'ordre des formes**
Aspose.Slides for PHP via Java permet aux développeurs de réorganiser les formes. Le réordonnancement détermine quelle forme est au premier plan ou à l'arrière-plan. Pour réorganiser les formes d'une diapositive, suivez les étapes ci‑dessous :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Accéder à la première diapositive.
3. Ajouter une forme.
4. Ajouter du texte dans le cadre de texte de la forme.
5. Ajouter une autre forme avec les mêmes coordonnées.
6. Réorganiser les formes.
7. Enregistrer le fichier sur le disque.
```php
  $pres = new Presentation("ChangeShapeOrder.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $shp3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 365, 400, 150);
    $shp3->getFillFormat()->setFillType(FillType::NoFill);
    $shp3->addTextFrame(" ");
    $para = $shp3->getTextFrame()->getParagraphs()->get_Item(0);
    $portion = $para->getPortions()->get_Item(0);
    $portion->setText("Watermark Text Watermark Text Watermark Text");
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
Aspose.Slides for PHP via Java permet aux développeurs d'obtenir un identifiant de forme unique au niveau de la diapositive, contrairement à la méthode [getUniqueId](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getuniqueid/), qui permet d'obtenir un identifiant unique au niveau de la présentation. La méthode [getOfficeInteropShapeId](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getofficeinteropshapeid/) a été ajoutée à la classe [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/). La valeur renvoyée par la méthode [getOfficeInteropShapeId](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getofficeinteropshapeid/) correspond à la valeur de l'Id de l'objet Microsoft.Office.Interop.PowerPoint.Shape. Vous trouverez ci‑dessous un exemple de code.
```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # Obtention de l'identifiant unique de forme au niveau de la diapositive
    $officeInteropShapeId = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getOfficeInteropShapeId();
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Définir le texte alternatif d'une forme**
Aspose.Slides for PHP via Java permet aux développeurs de définir le texte alternatif (AlternateText) de n'importe quelle forme.
Les formes d'une présentation peuvent être distinguées par le `Alternative Text` ou la méthode [Shape Name](https://reference.aspose.com/slides/php-java/aspose.slides/shape/setname/).
Les méthodes [setAlternativeText](https://reference.aspose.com/slides/php-java/aspose.slides/shape/setalternativetext/) et [getAlternativeText](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getalternativetext/) peuvent être lues ou définies à l'aide d'Aspose.Slides ainsi que de Microsoft PowerPoint.
En utilisant cette méthode, vous pouvez marquer une forme et réaliser différentes opérations telles que la suppression, le masquage ou le réordonnancement des formes sur une diapositive.
Pour définir le texte alternatif d'une forme, suivez les étapes ci‑dessous :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Accéder à la première diapositive.
3. Ajouter n'importe quelle forme à la diapositive.
4. Effectuer des opérations avec la forme nouvellement ajoutée.
5. Parcourir les formes pour en trouver une.
6. Définir l'AlternativeText.
7. Enregistrer le fichier sur le disque.
```php
  # Instancier la classe Presentation qui représente le PPTX
  $pres = new Presentation();
  try {
    # Obtenir la première diapositive
    $sld = $pres->getSlides()->get_Item(0);
    # Ajouter une forme auto de type rectangle
    $shp1 = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 40, 150, 50);
    $shp2 = $sld->getShapes()->addAutoShape(ShapeType::Moon, 160, 40, 150, 50);
    $shp2->getFillFormat()->setFillType(FillType::Solid);
    $shp2->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    for($i = 0; $i < java_values($sld->getShapes()->size()) ; $i++) {
      $shape = $sld->getShapes()->get_Item($i);
      if (!java_is_null($shape)) {
        $shape->setAlternativeText("User Defined");
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


## **Accéder aux formats de mise en page d'une forme**
Aspose.Slides for PHP via Java offre une API simple pour accéder aux formats de mise en page d'une forme. Cet article montre comment accéder aux formats de mise en page.

Vous trouverez ci‑dessous un exemple de code.
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


## **Rendre une forme au format SVG**
Aspose.Slides for PHP via Java prend désormais en charge le rendu d'une forme au format SVG. La méthode [writeAsSvg](https://reference.aspose.com/slides/php-java/aspose.slides/shape/writeassvg/) (et ses surcharges) a été ajoutée à la classe [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/). Cette méthode permet d'enregistrer le contenu de la forme dans un fichier SVG. Le fragment de code ci‑dessous montre comment exporter la forme d'une diapositive vers un fichier SVG.
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


## **Aligner une forme**
Aspose.Slides permet d'aligner les formes soit par rapport aux marges de la diapositive, soit entre elles. À cet effet, la méthode surchargée [SlidesUtil::alignShapes](https://reference.aspose.com/slides/php-java/aspose.slides/slideutil/alignshapes/) a été ajoutée. L'énumération [ShapesAlignmentType](https://reference.aspose.com/slides/php-java/aspose.slides/shapesalignmenttype/) définit les options d'alignement possibles.

**Exemple 1**

Le code source ci‑dessous aligne les formes avec les indices 1, 2 et 4 le long de la bordure supérieure de la diapositive.
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

L'exemple ci‑dessus montre comment aligner l'ensemble de la collection de formes par rapport à la forme la plus basse de la collection.
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


## **Propriétés de retournement**
Dans Aspose.Slides, la classe [ShapeFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapeframe/) fournit le contrôle du retournement horizontal et vertical des formes via ses propriétés `flipH` et `flipV`. Les deux propriétés sont de type [NullableBool](https://reference.aspose.com/slides/php-java/aspose.slides/nullablebool/), permettant les valeurs `True` pour indiquer un retournement, `False` pour aucun retournement, ou `NotDefined` pour utiliser le comportement par défaut. Ces valeurs sont accessibles depuis le [Frame](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getFrame) d’une forme.

Pour modifier les paramètres de retournement, une nouvelle instance de [ShapeFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapeframe/) est construite avec la position et la taille actuelles de la forme, les valeurs souhaitées pour `flipH` et `flipV`, ainsi que l'angle de rotation. L’assignation de cette instance au [Frame](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getFrame) de la forme et l’enregistrement de la présentation appliquent les transformations de miroir et les enregistrent dans le fichier de sortie.

Supposons que nous disposions d’un fichier sample.pptx dans lequel la première diapositive contient une seule forme avec les paramètres de retournement par défaut, comme indiqué ci‑dessous.

![La forme à retourner](shape_to_be_flipped.png)

L’exemple de code suivant récupère les propriétés de retournement actuelles de la forme et la retourne à la fois horizontalement et verticalement.
```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    // Récupérer la propriété de retournement horizontal de la forme.
    $horizontalFlip = $shape->getFrame()->getFlipH();
    echo "Horizontal flip: ", $horizontalFlip, "\n";

    // Récupérer la propriété de retournement vertical de la forme.
    $verticalFlip = $shape->getFrame()->getFlipV();
    echo "Vertical flip: ", $verticalFlip, "\n";

    $x = $shape->getFrame()->getX();
    $y = $shape->getFrame()->getY();
    $width = $shape->getFrame()->getWidth();
    $height = $shape->getFrame()->getHeight();
    $flipH = NullableBool::True; // Retourner horizontalement.
    $flipV = NullableBool::True; // Retourner verticalement.
    $rotation = $shape->getFrame()->getRotation();

    $shape->setFrame(new ShapeFrame($x, $y, $width, $height, $flipH, $flipV, $rotation));

    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```


Le résultat :

![La forme retournée](flipped_shape.png)

## **FAQ**

**Puis-je combiner des formes (union/intersection/soustraction) sur une diapositive comme dans un éditeur de bureau ?**

Il n'existe pas d'API d'opérations booléennes intégrée. Vous pouvez l'approximer en construisant vous‑même le contour souhaité — par exemple, calculer la géométrie résultante (via [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/)) et créer une nouvelle forme avec ce contour, en supprimant éventuellement les originales.

**Comment contrôler l'ordre d'empilement (z‑order) afin qu'une forme reste toujours « au premier plan » ?**

Modifiez l'ordre d'insertion/déplacement au sein de la collection [shapes](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getShapes) de la diapositive. Pour des résultats prévisibles, finalisez le z‑order après toutes les autres modifications de la diapositive.

**Puis-je « verrouiller » une forme pour empêcher les utilisateurs de la modifier dans PowerPoint ?**

Oui. Définissez les drapeaux de protection au niveau de la forme (par ex., verrouiller la sélection, le déplacement, le redimensionnement, les modifications de texte). Si nécessaire, appliquez des restrictions similaires sur le maître ou la disposition. Notez qu’il s’agit d’une protection au niveau de l’interface utilisateur, et non d’une fonction de sécurité ; pour une protection plus forte, combinez‑la avec des restrictions au niveau du fichier comme les recommandations en lecture seule ou les mots de passe ([read‑only recommendations or passwords](/slides/fr/php-java/password-protected-presentation/)).