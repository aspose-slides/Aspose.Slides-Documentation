---
title: Ajouter des rectangles aux présentations en PHP
linktitle: Rectangle
type: docs
weight: 80
url: /fr/php-java/rectangle/
keywords:
- ajouter rectangle
- créer rectangle
- forme rectangle
- rectangle simple
- rectangle formaté
- PowerPoint
- présentation
- PHP
- Aspose.Slides
description: "Améliorez vos présentations PowerPoint en ajoutant des rectangles avec Aspose.Slides pour PHP via Java — concevez et modifiez facilement des formes de façon programmatique."
---

{{% alert color="primary" %}} 

Comme les sujets précédents, celui-ci porte également sur l'ajout d'une forme et cette fois la forme dont nous allons parler est le **Rectangle**. Dans ce sujet, nous avons décrit comment les développeurs peuvent ajouter des rectangles simples ou formatés à leurs diapositives en utilisant Aspose.Slides pour PHP via Java.

{{% /alert %}} 

## **Ajouter un rectangle à une diapositive**
Pour ajouter un rectangle simple à une diapositive sélectionnée de la présentation, veuillez suivre les étapes ci-dessous :

- Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
- Obtenez la référence d'une diapositive en utilisant son index.
- Ajoutez une [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) de type Rectangle en utilisant la méthode [addAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addAutoShape) exposée par l'objet [ShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/).
- Enregistrez la présentation modifiée au format PPTX.

Dans l'exemple ci-dessous, nous avons ajouté un rectangle simple à la première diapositive de la présentation.
```php
  # Instancier la classe Presentation qui représente le PPTX
  $pres = new Presentation();
  try {
    # Obtenir la première diapositive
    $sld = $pres->getSlides()->get_Item(0);
    # Ajouter une AutoShape de type ellipse
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 150, 50);
    # Enregistrer le fichier PPTX sur le disque
    $pres->save("RecShp1.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Ajouter un rectangle formaté à une diapositive**
Pour ajouter un rectangle formaté à une diapositive, veuillez suivre les étapes ci-dessous :

- Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
- Obtenez la référence d'une diapositive en utilisant son index.
- Ajoutez une [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) de type Rectangle en utilisant la méthode [addAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addAutoShape) exposée par l'objet [ShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/).
- Définissez le [Fill Type](https://reference.aspose.com/slides/php-java/aspose.slides/FillType) du rectangle sur Solid.
- Définissez la couleur du rectangle en utilisant la méthode [ColorFormat::setColor](https://reference.aspose.com/slides/php-java/aspose.slides/colorformat/#setColor) exposée par l'objet [FillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/) associé à l'objet [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/).
- Définissez la couleur des bordures du rectangle.
- Définissez la largeur des bordures du rectangle.
- Enregistrez la présentation modifiée au format PPTX.

Les étapes ci-dessus sont implémentées dans l'exemple ci-dessous.
```php
  # Instancier la classe Presentation qui représente le PPTX
  $pres = new Presentation();
  try {
    # Obtenir la première diapositive
    $sld = $pres->getSlides()->get_Item(0);
    # Ajouter une AutoShape de type ellipse
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 150, 50);
    # Appliquer un certain formatage à la forme ellipse
    $shp->getFillFormat()->setFillType(FillType::Solid);
    $shp->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    # Appliquer un certain formatage à la ligne de l'Ellipse
    $shp->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shp->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $shp->getLineFormat()->setWidth(5);
    # Enregistrer le fichier PPTX sur le disque
    $pres->save("RecShp2.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**Comment ajouter un rectangle avec des coins arrondis ?**

Utilisez le [type de forme](https://reference.aspose.com/slides/php-java/aspose.slides/shapetype/) à coins arrondis et ajustez le rayon des coins dans les propriétés de la forme ; l'arrondissement peut également être appliqué coin par coin via des ajustements géométriques.

**Comment remplir un rectangle avec une image (texture) ?**

Sélectionnez le [type de remplissage](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) image, fournissez la source de l'image et configurez les [modes d'étirement/tuile](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillmode/).

**Un rectangle peut-il avoir une ombre et un éclat ?**

Oui. Les [ombres externes/intérieures, l'éclat et les bords doux](/slides/fr/php-java/shape-effect/) sont disponibles avec des paramètres réglables.

**Puis-je transformer un rectangle en bouton avec un hyperlien ?**

Oui. [Attribuez un hyperlien](/slides/fr/php-java/manage-hyperlinks/) au clic de la forme (vers une diapositive, un fichier, une adresse web ou un e‑mail).

**Comment protéger un rectangle contre le déplacement et les modifications ?**

Utilisez les verrous de forme : vous pouvez interdire le déplacement, le redimensionnement, la sélection ou la modification du texte pour préserver la disposition.

**Puis-je convertir un rectangle en image raster ou SVG ?**

Oui. Vous pouvez [rendre la forme](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getImage) en image avec une taille/échelle spécifiée ou [l'exporter en SVG](https://reference.aspose.com/slides/php-java/aspose.slides/shape/writeassvg/) pour une utilisation vectorielle.

**Comment obtenir rapidement les propriétés réelles (effectives) d'un rectangle en tenant compte du thème et de l'héritage ?**

[Utilisez les propriétés effectives de la forme](/slides/fr/php-java/shape-effective-properties/) : l'API renvoie les valeurs calculées qui tiennent compte des styles du thème, de la disposition et des paramètres locaux, simplifiant l'analyse du formatage.