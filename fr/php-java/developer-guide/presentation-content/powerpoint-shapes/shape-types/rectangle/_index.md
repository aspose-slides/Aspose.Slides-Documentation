---
title: Rectangle
type: docs
weight: 80
url: /php-java/rectangle/
---

{{% alert color="primary" %}} 

Comme les sujets précédents, celui-ci concerne également l'ajout d'une forme et cette fois la forme dont nous allons discuter est **Rectangle**. Dans ce sujet, nous avons décrit comment les développeurs peuvent ajouter des rectangles simples ou formatés à leurs diapositives en utilisant Aspose.Slides pour PHP via Java.

{{% /alert %}} 

## **Ajouter un Rectangle à la Diapositive**
Pour ajouter un rectangle simple à une diapositive sélectionnée de la présentation, veuillez suivre les étapes ci-dessous :

- Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
- Obtenir la référence d'une diapositive en utilisant son Index.
- Ajouter un [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape) de type Rectangle en utilisant la méthode [addAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) exposée par l'objet [IShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection).
- Écrire la présentation modifiée en tant que fichier PPTX.

Dans l'exemple donné ci-dessous, nous avons ajouté un rectangle simple à la première diapositive de la présentation.

```php
  # Instancier la classe Présentation qui représente le PPTX
  $pres = new Presentation();
  try {
    # Obtenir la première diapositive
    $sld = $pres->getSlides()->get_Item(0);
    # Ajouter une AutoShape de type ellipse
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 150, 50);
    # Écrire le fichier PPTX sur le disque
    $pres->save("RecShp1.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Ajouter un Rectangle Formaté à la Diapositive**
Pour ajouter un rectangle formaté à une diapositive, veuillez suivre les étapes ci-dessous :

- Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
- Obtenir la référence d'une diapositive en utilisant son Index.
- Ajouter un [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape) de type Rectangle en utilisant la méthode [addAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) exposée par l'objet [IShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection).
- Définir le [Type de Remplissage](https://reference.aspose.com/slides/php-java/aspose.slides/FillType) du Rectangle sur Solide.
- Définir la Couleur du Rectangle en utilisant la méthode [SolidFillColor.setColor](https://reference.aspose.com/slides/php-java/aspose.slides/IColorFormat#setColor-java.awt.Color-) exposée par l'objet [IFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/IFillFormat) associé à l'objet [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShape).
- Définir la Couleur des lignes du Rectangle.
- Définir la Largeur des lignes du Rectangle.
- Écrire la présentation modifiée en tant que fichier PPTX.

Les étapes ci-dessus sont mises en œuvre dans l'exemple donné ci-dessous.

```php
  # Instancier la classe Présentation qui représente le PPTX
  $pres = new Presentation();
  try {
    # Obtenir la première diapositive
    $sld = $pres->getSlides()->get_Item(0);
    # Ajouter une AutoShape de type ellipse
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 150, 50);
    # Appliquer certains formatages à la forme ellipse
    $shp->getFillFormat()->setFillType(FillType::Solid);
    $shp->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    # Appliquer certains formatages à la ligne de l'Ellipse
    $shp->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shp->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $shp->getLineFormat()->setWidth(5);
    # Écrire le fichier PPTX sur le disque
    $pres->save("RecShp2.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```