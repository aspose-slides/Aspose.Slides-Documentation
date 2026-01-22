---
title: Ajouter des formes de ligne aux présentations sur Android
linktitle: Ligne
type: docs
weight: 50
url: /fr/androidjava/Line/
keywords:
- ligne
- créer une ligne
- ajouter une ligne
- ligne simple
- configurer la ligne
- personnaliser la ligne
- style de tiret
- tête de flèche
- PowerPoint
- présentation
- Android
- Java
- Aspose.Slides
description: "Apprenez à manipuler le formatage des lignes dans les présentations PowerPoint avec Aspose.Slides pour Android. Découvrez les propriétés, les méthodes et des exemples Java."
---

{{% alert color="primary" %}} 

Aspose.Slides for Android via Java prend en charge l'ajout de différents types de formes aux diapositives. Dans ce sujet, nous commencerons à travailler avec les formes en ajoutant des lignes aux diapositives. En utilisant Aspose.Slides for Android via Java, les développeurs peuvent non seulement créer des lignes simples, mais aussi dessiner des lignes plus sophistiquées sur les diapositives.

{{% /alert %}} 

## **Créer une ligne simple**

Pour ajouter une ligne simple à une diapositive sélectionnée de la présentation, veuillez suivre les étapes ci‑dessous :

- Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
- Obtenir la référence d’une diapositive en utilisant son Index.
- Ajouter une AutoShape de type Ligne à l’aide de la méthode [addAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) exposée par l’objet [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection).
- Enregistrer la présentation modifiée en fichier PPTX.

Dans l’exemple ci‑dessous, nous avons ajouté une ligne à la première diapositive de la présentation.
```java
// Instancier la classe PresentationEx qui représente le fichier PPTX
Presentation pres = new Presentation();
try {
    // Obtenir la première diapositive
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Ajouter une AutoShape de type ligne
    sld.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);
    
    // Écrire le PPTX sur le disque
    pres.save("LineShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Créer une ligne en forme de flèche**

Aspose.Slides for Android via Java permet également aux développeurs de configurer certaines propriétés de la ligne pour la rendre plus attrayante. Essayons de configurer quelques propriétés afin qu’elle ressemble à une flèche. Veuillez suivre les étapes ci‑dessous :

- Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
- Obtenir la référence d’une diapositive en utilisant son Index.
- Ajouter une AutoShape de type Ligne à l’aide de la méthode [addAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) exposée par l’objet [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection).
- Définir le [Line Style](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LineStyle) sur l’un des styles proposés par Aspose.Slides for Android via Java.
- Définir la largeur de la ligne.
- Définir le [Dash Style](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LineDashStyle) de la ligne sur l’un des styles proposés par Aspose.Slides for Android via Java.
- Définir le [Arrow Head Style](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LineArrowheadStyle) et la [Length](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LineArrowheadLength) du point de départ de la ligne.
- Définir le [Arrow Head Style](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LineArrowheadStyle) et la [Length](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LineArrowheadLength) du point d’arrivée de la ligne.
- Enregistrer la présentation modifiée en fichier PPTX.
```java
// Instancier la classe PresentationEx qui représente le fichier PPTX
Presentation pres = new Presentation();
try {
    // Obtenir la première diapositive
    ISlide sld = pres.getSlides().get_Item(0);

    // Ajouter une AutoShape de type ligne
    IAutoShape shp = sld.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);

    // Appliquer un formatage à la ligne
    shp.getLineFormat().setStyle(LineStyle.ThickBetweenThin);
    shp.getLineFormat().setWidth(10);

    shp.getLineFormat().setDashStyle(LineDashStyle.DashDot);

    shp.getLineFormat().setBeginArrowheadLength(LineArrowheadLength.Short);
    shp.getLineFormat().setBeginArrowheadStyle(LineArrowheadStyle.Oval);

    shp.getLineFormat().setEndArrowheadLength(LineArrowheadLength.Long);
    shp.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);

    shp.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.Maroon));

    // Enregistrer le PPTX sur le disque
    pres.save("LineShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**Puis‑je convertir une ligne normale en connecteur afin qu’elle se « accroche » aux formes ?**

Non. Une ligne normale (une [AutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/autoshape/) de type [Line](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapetype/)) ne devient pas automatiquement un connecteur. Pour qu’elle s’accroche aux formes, utilisez le type [Connector](https://reference.aspose.com/slides/androidjava/com.aspose.slides/connector/) dédié et les [API correspondantes](/slides/fr/androidjava/connector/) pour les connexions.

**Que faire si les propriétés d’une ligne sont héritées du thème et qu’il est difficile de déterminer les valeurs finales ?**

[Lisez les propriétés effectives](/slides/fr/androidjava/shape-effective-properties/) via les interfaces [ILineFormatEffectiveData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilinefillformateffectivedata/) — celles‑ci tiennent déjà compte de l’héritage et des styles du thème.

**Puis‑je verrouiller une ligne contre l’édition (déplacement, redimensionnement) ?**

Oui. Les formes offrent des [objets de verrouillage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/autoshape/#getAutoShapeLock--) qui vous permettent d’interdire les opérations d’édition.