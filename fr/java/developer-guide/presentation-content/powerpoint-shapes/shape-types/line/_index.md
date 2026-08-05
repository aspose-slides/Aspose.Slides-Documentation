---
title: Ajouter des formes de ligne aux présentations en Java
linktitle: Ligne
type: docs
weight: 50
url: /fr/java/line/
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
- Java
- Aspose.Slides
description: "Apprenez à manipuler le formatage des lignes dans les présentations PowerPoint avec Aspose.Slides for Java. Découvrez les propriétés, les méthodes et des exemples."
---
## **Vue d'ensemble**

Aspose.Slides vous permet d'ajouter des formes de ligne aux diapositives PowerPoint par programmation. Cet article montre comment créer une ligne simple et comment la personnaliser pour qu'elle apparaisse sous forme de flèche.

Vous apprendrez comment ajouter une forme de ligne à une diapositive, ajuster son apparence visuelle et enregistrer la présentation mise à jour. Les exemples portent sur des paramètres de mise en forme de ligne pratiques tels que le style, la largeur, le motif de tirets, les options de tête de flèche et la couleur de remplissage.

## **Créer une ligne simple**

Pour ajouter une ligne simple à la diapositive sélectionnée de la présentation, suivez les étapes ci‑dessus :

- Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/Presentation).
- Obtenez la référence d’une diapositive en utilisant son Index.
- Ajoutez une AutoShape de type Line en utilisant la méthode [addAutoShape](https://reference.aspose.com/slides/fr/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) exposée par l’objet [IShapeCollection](https://reference.aspose.com/slides/fr/java/com.aspose.slides/IShapeCollection).
- Enregistrez la présentation modifiée sous forme de fichier PPTX.

Dans l’exemple ci‑dessous, nous avons ajouté une ligne à la première diapositive de la présentation.

```java
// Instancier la classe PresentationEx qui représente le fichier PPTX
Presentation pres = new Presentation();
try {
    // Obtenir la première diapositive
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Ajouter une AutoShape de type ligne
    sld.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);
    
    // Enregistrer le PPTX sur le disque
    pres.save("LineShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Créer une ligne en forme de flèche**

Aspose.Slides for Java permet également aux développeurs de configurer certaines propriétés de la ligne pour la rendre plus attrayante. Essayons de configurer quelques propriétés afin que la ligne ressemble à une flèche. Suivez les étapes ci‑dessus :

- Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/Presentation).
- Obtenez la référence d’une diapositive en utilisant son Index.
- Ajoutez une AutoShape de type Line en utilisant la méthode [addAutoShape](https://reference.aspose.com/slides/fr/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) exposée par l’objet [IShapeCollection](https://reference.aspose.com/slides/fr/java/com.aspose.slides/IShapeCollection).
- Définissez le [Line Style](https://reference.aspose.com/slides/fr/java/com.aspose.slides/LineStyle) sur l’un des styles proposés par Aspose.Slides for Java.
- Définissez la largeur de la ligne.
- Définissez le [Dash Style](https://reference.aspose.com/slides/fr/java/com.aspose.slides/LineDashStyle) de la ligne sur l’un des styles proposés par Aspose.Slides for Java.
- Définissez le [Arrow Head Style](https://reference.aspose.com/slides/fr/java/com.aspose.slides/LineArrowheadStyle) et la [Length](https://reference.aspose.com/slides/fr/java/com.aspose.slides/LineArrowheadLength) du point de départ de la ligne.
- Définissez le [Arrow Head Style](https://reference.aspose.com/slides/fr/java/com.aspose.slides/LineArrowheadStyle) et la [Length](https://reference.aspose.com/slides/fr/java/com.aspose.slides/LineArrowheadLength) du point d’arrivée de la ligne.
- Enregistrez la présentation modifiée sous forme de fichier PPTX.

```java
// Instancier la classe PresentationEx qui représente le fichier PPTX
Presentation pres = new Presentation();
try {
    // Obtenir la première diapositive
    ISlide sld = pres.getSlides().get_Item(0);

    // Ajouter une AutoShape de type ligne
    IAutoShape shp = sld.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);

    // Appliquer un certain formatage sur la ligne
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

**Puis‑je convertir une ligne ordinaire en connecteur afin qu’elle « s’aimante » aux formes ?**

Non. Une ligne ordinaire (une [AutoShape](https://reference.aspose.com/slides/fr/java/com.aspose.slides/autoshape/) de type [Line](https://reference.aspose.com/slides/fr/java/com.aspose.slides/shapetype/)) ne devient pas automatiquement un connecteur. Pour la faire « aimanter » aux formes, utilisez le type [Connector](https://reference.aspose.com/slides/fr/java/com.aspose.slides/connector/) dédié ainsi que les [API correspondantes](/slides/fr/java/connector/) pour les connexions.

**Que faire si les propriétés d’une ligne sont héritées du thème et qu’il est difficile de déterminer les valeurs finales ?**

[Lire les propriétés effectives](/slides/fr/java/shape-effective-properties/) via les interfaces [ILineFormatEffectiveData](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ilinefillformateffectivedata/) — celles‑ci tiennent déjà compte de l’héritage et des styles du thème.

**Puis‑je verrouiller une ligne contre l’édition (déplacement, redimensionnement) ?**

Oui. Les formes fournissent des [lock objects](https://reference.aspose.com/slides/fr/java/com.aspose.slides/autoshape/#getAutoShapeLock--) qui vous permettent de [interdire les opérations d’édition](/slides/fr/java/applying-protection-to-presentation/).