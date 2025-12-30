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
- configurer ligne
- personnaliser ligne
- style pointillé
- tête de flèche
- PowerPoint
- présentation
- PHP
- Aspose.Slides
description: "Apprenez à manipuler le formatage des lignes dans les présentations PowerPoint avec Aspose.Slides pour PHP via Java. Découvrez les propriétés, les méthodes et les exemples."
---

{{% alert color="primary" %}} 

Aspose.Slides for PHP via Java prend en charge l'ajout de différents types de formes aux diapositives. Dans ce sujet, nous allons commencer à travailler avec les formes en ajoutant des lignes aux diapositives. Avec Aspose.Slides for PHP via Java, les développeurs peuvent non seulement créer des lignes simples, mais aussi dessiner des lignes fantaisistes sur les diapositives.

{{% /alert %}} 

## **Créer une ligne simple**

Pour ajouter une ligne simple à une diapositive sélectionnée de la présentation, suivez les étapes ci‑dessous :

- Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
- Obtenir la référence d’une diapositive en utilisant son Index.
- Ajouter un AutoShape de type Ligne en utilisant la méthode [addAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) exposée par l’objet [IShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection).
- Enregistrer la présentation modifiée sous forme de fichier PPTX.

Dans l’exemple ci‑dessous, nous avons ajouté une ligne à la première diapositive de la présentation.
```php
  # Instancier la classe PresentationEx qui représente le fichier PPTX
  $pres = new Presentation();
  try {
    # Obtenir la première diapositive
    $sld = $pres->getSlides()->get_Item(0);
    # Ajouter un AutoShape de type ligne
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

Aspose.Slides for PHP via Java permet également aux développeurs de configurer certaines propriétés de la ligne pour la rendre plus attrayante. Essayons de configurer quelques propriétés d’une ligne pour qu’elle ressemble à une flèche. Veuillez suivre les étapes ci‑dessous pour ce faire :

- Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
- Obtenir la référence d’une diapositive en utilisant son Index.
- Ajouter un AutoShape de type Ligne en utilisant la méthode [addAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) exposée par l’objet [IShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection).
- Définir le [Line Style](https://reference.aspose.com/slides/php-java/aspose.slides/LineStyle) sur l’un des styles proposés par Aspose.Slides for PHP via Java.
- Définir la largeur de la ligne.
- Définir le [Dash Style](https://reference.aspose.com/slides/php-java/aspose.slides/LineDashStyle) de la ligne sur l’un des styles proposés par Aspose.Slides for PHP via Java.
- Définir le [Arrow Head Style](https://reference.aspose.com/slides/php-java/aspose.slides/LineArrowheadStyle) et la [Length](https://reference.aspose.com/slides/php-java/aspose.slides/LineArrowheadLength) du point de départ de la ligne.
- Définir le [Arrow Head Style](https://reference.aspose.com/slides/php-java/aspose.slides/LineArrowheadStyle) et la [Length](https://reference.aspose.com/slides/php-java/aspose.slides/LineArrowheadLength) du point d’arrivée de la ligne.
- Enregistrer la présentation modifiée sous forme de fichier PPTX.
```php
  # Instancier la classe PresentationEx qui représente le fichier PPTX
  $pres = new Presentation();
  try {
    # Obtenir la première diapositive
    $sld = $pres->getSlides()->get_Item(0);
    # Ajouter un AutoShape de type ligne
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Line, 50, 150, 300, 0);
    # Appliquer un formatage à la ligne
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

**Puis‑je convertir une ligne ordinaire en connecteur pour qu’elle s’ajuste aux formes ?**

Non. Une ligne ordinaire (un [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) de type [Line](https://reference.aspose.com/slides/php-java/aspose.slides/shapetype/)) ne devient pas automatiquement un connecteur. Pour qu’elle s’ajuste aux formes, utilisez le type dédié [Connector](https://reference.aspose.com/slides/php-java/aspose.slides/connector/) ainsi que les [corresponding APIs](/slides/fr/php-java/connector/) pour les connexions.

**Que faire si les propriétés d’une ligne sont héritées du thème et qu’il est difficile de déterminer les valeurs finales ?**

[Lire les propriétés effectives](/slides/fr/php-java/shape-effective-properties/) via les `LineFormatEffectiveData`/`LineFillFormatEffectiveData` — elles tiennent déjà compte de l’héritage et des styles du thème.

**Puis‑je verrouiller une ligne contre la modification (déplacement, redimensionnement) ?**

Oui. Les formes offrent des [lock objects](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/getautoshapelock/) qui vous permettent d’[interdire les opérations de modification](/slides/fr/php-java/applying-protection-to-presentation/).