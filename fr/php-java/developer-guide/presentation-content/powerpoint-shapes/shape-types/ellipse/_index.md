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
description: "Apprenez à créer, formater et manipuler des formes d'ellipse dans Aspose.Slides for PHP via Java pour les présentations PPT et PPTX — exemples de code inclus."
---

{{% alert color="primary" %}} 
Dans ce sujet, nous présenterons aux développeurs comment ajouter des formes d'ellipse à leurs diapositives en utilisant Aspose.Slides for PHP via Java. Aspose.Slides for PHP via Java fournit un ensemble d'API plus simple pour dessiner différents types de formes en quelques lignes de code.
{{% /alert %}} 

## **Créer une ellipse**
Pour ajouter une ellipse simple à une diapositive sélectionnée de la présentation, suivez les étapes ci-dessous :

- Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
- Obtenir la référence d'une diapositive en utilisant son Index.
- Ajouter une AutoShape de type Ellipse en utilisant la méthode [addAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) exposée par l'objet [IShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection).
- Enregistrer la présentation modifiée en tant que fichier PPTX.

Dans l'exemple ci-dessous, nous avons ajouté une ellipse à la première diapositive
```php
  # Instancier la classe Presentation qui représente le PPTX
  $pres = new Presentation();
  try {
    # Obtenir la première diapositive
    $sld = $pres->getSlides()->get_Item(0);
    # Ajouter une AutoShape de type ellipse
    $sld->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 150, 150, 50);
    # Enregistrer le fichier PPTX sur le disque
    $pres->save("EllipseShp1.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Créer une ellipse formatée**
Pour ajouter une ellipse mieux formatée à une diapositive, suivez les étapes ci-dessous :

- Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
- Obtenir la référence d'une diapositive en utilisant son Index.
- Ajouter une AutoShape de type Ellipse en utilisant la méthode [addAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) exposée par l'objet [IShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection).
- Définir le type de remplissage de l'ellipse sur Solid.
- Définir la couleur de l'ellipse en utilisant la propriété SolidFillColor.Color exposée par l'objet [FillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/IFillFormat) associé à l'objet [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShape).
- Définir la couleur des lignes de l'ellipse.
- Définir la largeur des lignes de l'ellipse.
- Enregistrer la présentation modifiée en tant que fichier PPTX.

Dans l'exemple ci-dessous, nous avons ajouté une ellipse formatée à la première diapositive de la présentation.
```php
  # Instancier la classe Presentation qui représente le PPTX
  $pres = new Presentation();
  try {
    # Obtenir la première diapositive
    $sld = $pres->getSlides()->get_Item(0);
    # Ajouter une AutoShape de type ellipse
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 150, 150, 50);
    # Appliquer un formatage à la forme ellipse
    $shp->getFillFormat()->setFillType(FillType::Solid);
    $shp->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", PresetColor->Chocolate));
    # Appliquer un formatage à la ligne de l'ellipse
    $shp->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shp->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $shp->getLineFormat()->setWidth(5);
    # Enregistrer le fichier PPTX sur le disque
    $pres->save("EllipseShp1.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**Comment définir la position exacte et la taille d'une ellipse par rapport aux unités de la diapositive ?**
Les coordonnées et les tailles sont généralement spécifiées **in points**. Pour des résultats prévisibles, basez vos calculs sur la taille de la diapositive et convertissez les millimètres ou pouces requis en points avant d'attribuer les valeurs.

**Comment placer une ellipse au-dessus ou en dessous d'autres objets (contrôler l'ordre d'empilement) ?**
Ajustez l'ordre de dessin de l'objet en le mettant en avant-plan ou en arrière-plan. Cela permet à l'ellipse de chevaucher d'autres objets ou de révéler ceux qui se trouvent en dessous.

**Comment animer l'apparition ou l'accentuation d'une ellipse ?**
[Apply](/slides/fr/php-java/shape-animation/) des effets d'entrée, d'accentuation ou de sortie sur la forme, et configurez les déclencheurs et le timing pour orchestrer quand et comment l'animation se déroule.