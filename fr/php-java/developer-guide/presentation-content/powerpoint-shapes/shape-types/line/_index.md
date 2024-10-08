---
title: Ligne
type: docs
weight: 50
url: /fr/php-java/Ligne/
---


{{% alert color="primary" %}} 

Aspose.Slides pour PHP via Java prend en charge l'ajout de différents types de formes aux diapositives. Dans ce sujet, nous allons commencer à travailler avec des formes en ajoutant des lignes aux diapositives. Avec Aspose.Slides pour PHP via Java, les développeurs peuvent non seulement créer des lignes simples, mais aussi dessiner des lignes plus élaborées sur les diapositives.

{{% /alert %}} 

## **Créer une ligne simple**

Pour ajouter une ligne simple à une diapositive sélectionnée de la présentation, veuillez suivre les étapes ci-dessous :

- Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
- Obtenez la référence d'une diapositive en utilisant son index.
- Ajoutez une AutoShape de type ligne en utilisant la méthode [addAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) exposée par l'objet [IShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection).
- Écrivez la présentation modifiée sous forme de fichier PPTX.

Dans l'exemple donné ci-dessous, nous avons ajouté une ligne à la première diapositive de la présentation.

```php
  # Instancier la classe PresentationEx qui représente le fichier PPTX
  $pres = new Presentation();
  try {
    # Obtenir la première diapositive
    $sld = $pres->getSlides()->get_Item(0);
    # Ajouter une AutoShape de type ligne
    $sld->getShapes()->addAutoShape(ShapeType::Line, 50, 150, 300, 0);
    # Écrire le PPTX sur le disque
    $pres->save("LigneShape.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Créer une ligne en forme de flèche**

Aspose.Slides pour PHP via Java permet également aux développeurs de configurer certaines propriétés de la ligne pour lui donner un aspect plus attrayant. Essayons de configurer quelques propriétés d'une ligne pour qu'elle ressemble à une flèche. Veuillez suivre les étapes ci-dessous pour cela :

- Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
- Obtenez la référence d'une diapositive en utilisant son index.
- Ajoutez une AutoShape de type ligne en utilisant la méthode [addAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) exposée par l'objet [IShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection).
- Définissez le [Style de ligne](https://reference.aspose.com/slides/php-java/aspose.slides/LineStyle) sur l'un des styles proposés par Aspose.Slides pour PHP via Java.
- Définissez la largeur de la ligne.
- Définissez le [Style de trait](https://reference.aspose.com/slides/php-java/aspose.slides/LineDashStyle) de la ligne sur l'un des styles offerts par Aspose.Slides pour PHP via Java.
- Définissez le [Style de tête de flèche](https://reference.aspose.com/slides/php-java/aspose.slides/LineArrowheadStyle) et la [Longueur](https://reference.aspose.com/slides/php-java/aspose.slides/LineArrowheadLength) du point de début de la ligne.
- Définissez le [Style de tête de flèche](https://reference.aspose.com/slides/php-java/aspose.slides/LineArrowheadStyle) et la [Longueur](https://reference.aspose.com/slides/php-java/aspose.slides/LineArrowheadLength) du point de fin de la ligne.
- Écrivez la présentation modifiée sous forme de fichier PPTX.

```php
  # Instancier la classe PresentationEx qui représente le fichier PPTX
  $pres = new Presentation();
  try {
    # Obtenir la première diapositive
    $sld = $pres->getSlides()->get_Item(0);
    # Ajouter une AutoShape de type ligne
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Line, 50, 150, 300, 0);
    # Appliquer un certain formatage à la ligne
    $shp->getLineFormat()->setStyle(LineStyle->ThickBetweenThin);
    $shp->getLineFormat()->setWidth(10);
    $shp->getLineFormat()->setDashStyle(LineDashStyle->DashDot);
    $shp->getLineFormat()->setBeginArrowheadLength(LineArrowheadLength->Short);
    $shp->getLineFormat()->setBeginArrowheadStyle(LineArrowheadStyle->Oval);
    $shp->getLineFormat()->setEndArrowheadLength(LineArrowheadLength->Long);
    $shp->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle->Triangle);
    $shp->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shp->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", PresetColor->Maroon));
    # Écrire le PPTX sur le disque
    $pres->save("LigneShape.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```