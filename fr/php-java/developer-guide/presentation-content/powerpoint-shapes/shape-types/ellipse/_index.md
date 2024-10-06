---
title: Ellipse
type: docs
weight: 30
url: /php-java/ellipse/
---


{{% alert color="primary" %}} 

Dans ce sujet, nous allons présenter aux développeurs comment ajouter des formes d'ellipse à leurs diapositives en utilisant Aspose.Slides pour PHP via Java. Aspose.Slides pour PHP via Java fournit un ensemble d'APIs plus simples pour dessiner différents types de formes en quelques lignes de code.

{{% /alert %}} 

## **Créer une Ellipse**
Pour ajouter une simple ellipse à une diapositive sélectionnée de la présentation, veuillez suivre les étapes ci-dessous :

- Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
- Obtenez la référence d'une diapositive en utilisant son Index.
- Ajoutez une AutoShape de type Ellipse en utilisant la méthode [addAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) exposée par l'objet [IShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection).
- Écrivez la présentation modifiée en tant que fichier PPTX.

Dans l'exemple donné ci-dessous, nous avons ajouté une ellipse à la première diapositive.

```php
  # Instanciation de la classe Presentation qui représente le PPTX
  $pres = new Presentation();
  try {
    # Obtenez la première diapositive
    $sld = $pres->getSlides()->get_Item(0);
    # Ajoutez une AutoShape de type ellipse
    $sld->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 150, 150, 50);
    # Écrivez le fichier PPTX sur le disque
    $pres->save("EllipseShp1.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Créer une Ellipse Formattée**
Pour ajouter une ellipse mieux formatée à une diapositive, veuillez suivre les étapes ci-dessous :

- Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
- Obtenez la référence d'une diapositive en utilisant son Index.
- Ajoutez une AutoShape de type Ellipse en utilisant la méthode [addAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) exposée par l'objet [IShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection).
- Définissez le type de remplissage de l'ellipse sur Solide.
- Définissez la couleur de l'ellipse en utilisant la propriété SolidFillColor.Color telle qu'exposée par l'objet [FillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/IFillFormat) associé à l'objet [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShape).
- Définissez la couleur des lignes de l'ellipse.
- Définissez la largeur des lignes de l'ellipse.
- Écrivez la présentation modifiée en tant que fichier PPTX.

Dans l'exemple donné ci-dessous, nous avons ajouté une ellipse formatée à la première diapositive de la présentation.

```php
  # Instanciation de la classe Presentation qui représente le PPTX
  $pres = new Presentation();
  try {
    # Obtenez la première diapositive
    $sld = $pres->getSlides()->get_Item(0);
    # Ajoutez une AutoShape de type ellipse
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 150, 150, 50);
    # Appliquez un certain formatage à la forme ellipse
    $shp->getFillFormat()->setFillType(FillType::Solid);
    $shp->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", PresetColor->Chocolate));
    # Appliquez un certain formatage à la ligne de l'ellipse
    $shp->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shp->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $shp->getLineFormat()->setWidth(5);
    # Écrivez le fichier PPTX sur le disque
    $pres->save("EllipseShp1.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```