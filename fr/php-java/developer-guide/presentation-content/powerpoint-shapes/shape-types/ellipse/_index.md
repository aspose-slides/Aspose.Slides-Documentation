---
title: Ajouter des ellipses aux présentations en PHP
linktitle: Ellipse
type: docs
weight: 30
url: /fr/php-java/ellipse/
keywords:
- ellipse
- forme
- ajouter une ellipse
- créer une ellipse
- dessiner une ellipse
- ellipse formatée
- PowerPoint
- présentation
- PHP
- Aspose.Slides
description: "Apprenez comment créer, formater et manipuler des formes d'ellipse dans Aspose.Slides pour PHP via Java dans les présentations PPT et PPTX — exemples de code inclus."
---

{{% alert color="primary" %}} 

Dans ce sujet, nous présenterons aux développeurs comment ajouter des formes d'ellipse à leurs diapositives en utilisant Aspose.Slides pour PHP via Java. Aspose.Slides pour PHP via Java fournit un ensemble d'API plus simple pour dessiner différents types de formes en quelques lignes de code.

{{% /alert %}} 

## **Créer une ellipse**
Pour ajouter une ellipse simple à une diapositive sélectionnée de la présentation, veuillez suivre les étapes ci-dessous :

- Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
- Obtenez la référence d'une diapositive en utilisant son Index.
- Ajoutez une AutoShape de type Ellipse en utilisant la méthode [addAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addAutoShape) exposée par l'objet [ShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/).
- Enregistrez la présentation modifiée en tant que fichier PPTX.

Dans l'exemple ci-dessous, nous avons ajouté une ellipse à la première diapositive
```php
  # Instancie la classe Presentation qui représente le PPTX
  $pres = new Presentation();
  try {
    # Obtient la première diapositive
    $sld = $pres->getSlides()->get_Item(0);
    # Ajoute une AutoShape de type ellipse
    $sld->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 150, 150, 50);
    # Enregistre le fichier PPTX sur le disque
    $pres->save("EllipseShp1.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Créer une ellipse formatée**
Pour ajouter une ellipse mieux formatée à une diapositive, veuillez suivre les étapes ci-dessous :

- Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
- Obtenez la référence d'une diapositive en utilisant son Index.
- Ajoutez une AutoShape de type Ellipse en utilisant la méthode [addAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addAutoShape) exposée par l'objet [ShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/).
- Définissez le type de remplissage de l'ellipse sur Solid.
- Définissez la couleur de l'ellipse en utilisant la méthode `SolidFillColor::setColor` exposée par l'objet [FillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/) associé à l'objet [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/).
- Définissez la couleur des lignes de l'ellipse.
- Définissez la largeur des lignes de l'ellipse.
- Enregistrez la présentation modifiée en tant que fichier PPTX.

Dans l'exemple ci-dessus, nous avons ajouté une ellipse formatée à la première diapositive de la présentation.
```php
  # Instancie la classe Presentation qui représente le PPTX
  $pres = new Presentation();
  try {
    # Obtient la première diapositive
    $sld = $pres->getSlides()->get_Item(0);
    # Ajoute une AutoShape de type ellipse
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 150, 150, 50);
    # Applique un certain formatage à la forme ellipse
    $shp->getFillFormat()->setFillType(FillType::Solid);
    $shp->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", PresetColor->Chocolate));
    # Applique un certain formatage à la ligne de l'ellipse
    $shp->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shp->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $shp->getLineFormat()->setWidth(5);
    # Enregistre le fichier PPTX sur le disque
    $pres->save("EllipseShp1.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**Comment puis-je définir la position exacte et la taille d'une ellipse par rapport aux unités de la diapositive ?**

Les coordonnées et les tailles sont généralement spécifiées **en points**. Pour obtenir des résultats prévisibles, basez vos calculs sur la taille de la diapositive et convertissez les millimètres ou pouces requis en points avant d'assigner les valeurs.

**Comment puis-je placer une ellipse au-dessus ou en dessous d'autres objets (contrôler l'ordre d'empilement) ?**

Modifiez l'ordre de dessin de l'objet en le mettant au premier plan ou en l'envoyant à l'arrière. Cela permet à l'ellipse de se superposer à d'autres objets ou de révéler ceux qui se trouvent en dessous.

**Comment animer l'apparition ou l'accentuation d'une ellipse ?**

[Appliquer](/slides/fr/php-java/shape-animation/) des effets d'entrée, d'accentuation ou de sortie à la forme, et configurez les déclencheurs et le minutage pour orchestrer quand et comment l'animation se joue.