---
title: Ajouter des formes de ligne aux présentations en PHP
linktitle: Ligne
type: docs
weight: 50
url: /fr/php-java/Line/
keywords:
- ligne
- créer une ligne
- ajouter une ligne
- ligne simple
- configurer la ligne
- personnaliser la ligne
- style tireté
- tête de flèche
- PowerPoint
- présentation
- PHP
- Aspose.Slides
description: "Apprenez à manipuler le formatage des lignes dans les présentations PowerPoint avec Aspose.Slides for PHP via Java. Découvrez les propriétés, les méthodes et des exemples."
---

{{% alert color="primary" %}} 

Aspose.Slides for PHP via Java prend en charge l'ajout de différents types de formes aux diapositives. Dans ce sujet, nous commencerons à travailler avec les formes en ajoutant des lignes aux diapositives. Avec Aspose.Slides for PHP via Java, les développeurs peuvent non seulement créer des lignes simples, mais également dessiner des lignes décoratives sur les diapositives.

{{% /alert %}} 

## **Créer une ligne simple**

- Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
- Obtenir la référence d’une diapositive en utilisant son Index.
- Ajouter une AutoShape de type Line à l’aide de la méthode [addAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addAutoShape) exposée par l’objet [ShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/).
- Enregistrer la présentation modifiée au format PPTX.

Dans l’exemple ci‑dessous, nous avons ajouté une ligne à la première diapositive de la présentation.
```php
  # Instancier la classe PresentationEx qui représente le fichier PPTX
  $pres = new Presentation();
  try {
    # Obtenir la première diapositive
    $sld = $pres->getSlides()->get_Item(0);
    # Ajouter une AutoShape de type ligne
    $sld->getShapes()->addAutoShape(ShapeType::Line, 50, 150, 300, 0);
    # Enregistrer le PPTX sur le disque
    $pres->save("LineShape.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Créer une ligne en forme de flèche**

Aspose.Slides for PHP via Java permet également aux développeurs de configurer certaines propriétés de la ligne pour la rendre plus attrayante. Essayons de configurer quelques propriétés d’une ligne afin qu’elle ressemble à une flèche. Veuillez suivre les étapes ci‑dessous pour ce faire :

- Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
- Obtenir la référence d’une diapositive en utilisant son Index.
- Ajouter une AutoShape de type Line à l’aide de la méthode [addAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addAutoShape) exposée par l’objet [ShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/).
- Définir le [Line Style] à l’un des styles proposés par Aspose.Slides for PHP via Java.
- Définir la largeur de la ligne.
- Définir le [Dash Style] de la ligne à l’un des styles proposés par Aspose.Slides for PHP via Java.
- Définir le [Arrow Head Style] et la [Length] du point de départ de la ligne.
- Définir le [Arrow Head Style] et la [Length] du point d’arrivée de la ligne.
- Enregistrer la présentation modifiée au format PPTX.
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
    # Enregistrer le PPTX sur le disque
    $pres->save("LineShape.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**Puis‑je convertir une ligne ordinaire en connecteur afin qu’elle s’ajuste automatiquement aux formes ?**

Non. Une ligne ordinaire (une [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) de type [Line](https://reference.aspose.com/slides/php-java/aspose.slides/shapetype/)) ne devient pas automatiquement un connecteur. Pour qu’elle s’ajuste aux formes, utilisez le type dédié [Connector](https://reference.aspose.com/slides/php-java/aspose.slides/connector/) ainsi que les [corresponding APIs](/slides/fr/php-java/connector/) pour les connexions.

**Que faire si les propriétés d’une ligne sont héritées du thème et qu’il est difficile de déterminer les valeurs finales ?**

[Read the effective properties](/slides/fr/php-java/shape-effective-properties/) via les `LineFormatEffectiveData`/`LineFillFormatEffectiveData` — ces derniers tiennent déjà compte de l’héritage et des styles du thème.

**Puis‑je verrouiller une ligne contre les modifications (déplacement, redimensionnement) ?**

Oui. Les formes offrent des [lock objects](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/getautoshapelock/) qui permettent d’interdire les opérations de modification.