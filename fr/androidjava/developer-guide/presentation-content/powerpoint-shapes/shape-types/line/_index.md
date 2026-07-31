---
title: Ajouter des formes de ligne aux présentations sur Android
linktitle: Ligne
type: docs
weight: 50
url: /fr/androidjava/line/
keywords:
- ligne
- créer une ligne
- ajouter une ligne
- ligne simple
- configurer une ligne
- personnaliser une ligne
- style de tirets
- tête de flèche
- PowerPoint
- présentation
- Android
- Java
- Aspose.Slides
description: "Apprenez à manipuler la mise en forme des lignes dans les présentations PowerPoint avec Aspose.Slides pour Android. Découvrez les propriétés, les méthodes et des exemples Java."
---
## **Vue d'ensemble**

Aspose.Slides vous permet d'ajouter des formes de ligne aux diapositives PowerPoint de façon programmatique. Cet article montre comment créer une ligne simple et comment la personnaliser afin qu'elle apparaisse sous forme de flèche.

Vous apprendrez comment ajouter une forme de ligne à une diapositive, ajuster son apparence visuelle et enregistrer la présentation mise à jour. Les exemples se concentrent sur des paramètres pratiques de mise en forme de ligne tels que le style, la largeur, le motif de tirets, les options de tête de flèche et la couleur de remplissage.

## **Créer une ligne simple**

Pour ajouter une ligne simple à une diapositive sélectionnée de la présentation, suivez les étapes ci‑dessous :

- Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/Presentation).
- Obtenir la référence d’une diapositive en utilisant son Index.
- Ajouter une AutoShape de type Line en utilisant la méthode [addAutoShape](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) exposée par l’objet [IShapeCollection](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/IShapeCollection).
- Enregistrer la présentation modifiée sous forme de fichier PPTX.

Dans l'exemple ci‑dessous, nous avons ajouté une ligne à la première diapositive de la présentation.

```java
// Instancie la classe PresentationEx qui représente le fichier PPTX
Presentation pres = new Presentation();
try {
    // Obtient la première diapositive
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Ajoute une AutoShape de type ligne
    sld.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);
    
    // Enregistre le PPTX sur le disque
    pres.save("LineShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Créer une ligne en forme de flèche**

Aspose.Slides for Android via Java permet également aux développeurs de configurer certaines propriétés de la ligne afin de la rendre plus attrayante. Essayons de configurer quelques propriétés de la ligne pour qu’elle ressemble à une flèche. Veuillez suivre les étapes ci‑dessous pour ce faire :

- Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/Presentation).
- Obtenir la référence d’une diapositive en utilisant son Index.
- Ajouter une AutoShape de type Line en utilisant la méthode [addAutoShape](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) exposée par l’objet [IShapeCollection](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/IShapeCollection).
- Définir le [Line Style](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/LineStyle) sur l’un des styles proposés par Aspose.Slides for Android via Java.
- Définir la largeur de la ligne.
- Définir le [Dash Style](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/LineDashStyle) de la ligne sur l’un des styles proposés par Aspose.Slides for Android via Java.
- Définir le [Arrow Head Style](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/LineArrowheadStyle) et la [Length](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/LineArrowheadLength) du point de départ de la ligne.
- Définir le [Arrow Head Style](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/LineArrowheadStyle) et la [Length](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/LineArrowheadLength) du point d’arrivée de la ligne.
- Enregistrer la présentation modifiée sous forme de fichier PPTX.

```java
// Instancie la classe PresentationEx qui représente le fichier PPTX
Presentation pres = new Presentation();
try {
    // Obtient la première diapositive
    ISlide sld = pres.getSlides().get_Item(0);

    // Ajoute une AutoShape de type ligne
    IAutoShape shp = sld.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);

    // Applique un certain formatage sur la ligne
    shp.getLineFormat().setStyle(LineStyle.ThickBetweenThin);
    shp.getLineFormat().setWidth(10);

    shp.getLineFormat().setDashStyle(LineDashStyle.DashDot);

    shp.getLineFormat().setBeginArrowheadLength(LineArrowheadLength.Short);
    shp.getLineFormat().setBeginArrowheadStyle(LineArrowheadStyle.Oval);

    shp.getLineFormat().setEndArrowheadLength(LineArrowheadLength.Long);
    shp.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);

    shp.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.Maroon));

    // Enregistre le PPTX sur le disque
    pres.save("LineShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Puis-je convertir une ligne ordinaire en connecteur afin qu’elle « s’accroche » aux formes ?**

Non. Une ligne ordinaire (une [AutoShape](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/autoshape/) de type [Line](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/shapetype/)) ne devient pas automatiquement un connecteur. Pour la faire s’accrocher aux formes, utilisez le type dédié [Connector](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/connector/) ainsi que les [corresponding APIs](/slides/fr/androidjava/connector/) pour les connexions.

**Que faire si les propriétés d’une ligne sont héritées du thème et qu’il est difficile de déterminer les valeurs finales ?**

[Lire les propriétés effectives](/slides/fr/androidjava/shape-effective-properties/) via les interfaces [ILineFormatEffectiveData](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ilinefillformateffectivedata/) — celles‑ci tiennent déjà compte de l’héritage et des styles du thème.

**Puis-je verrouiller une ligne contre l’édition (déplacement, redimensionnement) ?**

Oui. Les formes offrent des [lock objects](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/autoshape/#getAutoShapeLock--) qui vous permettent d’interdire les opérations d’édition.