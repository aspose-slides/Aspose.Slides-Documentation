---
title: Ajouter des ellipses aux présentations sur Android
linktitle: Ellipse
type: docs
weight: 30
url: /fr/androidjava/ellipse/
keywords:
- ellipse
- forme
- ajouter ellipse
- créer ellipse
- dessiner ellipse
- ellipse formatée
- PowerPoint
- présentation
- Android
- Java
- Aspose.Slides
description: "Apprenez à créer, formater et manipuler des formes d'ellipse dans Aspose.Slides pour Android pour les présentations PPT et PPTX — exemples de code Java inclus."
---

{{% alert color="primary" %}} 

Dans ce sujet, nous présenterons aux développeurs comment ajouter des formes d'ellipse à leurs diapositives à l'aide d'Aspose.Slides for Android via Java. Aspose.Slides for Android via Java offre un jeu d'API plus simple pour dessiner différents types de formes en quelques lignes de code.

{{% /alert %}} 

## **Créer une ellipse**
Pour ajouter une ellipse simple à une diapositive sélectionnée de la présentation, suivez les étapes ci-dessous :

- Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
- Obtenir la référence d'une diapositive en utilisant son Index.
- Ajouter un AutoShape de type Ellipse en utilisant la méthode [addAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) exposée par l'objet [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection).
- Enregistrer la présentation modifiée en tant que fichier PPTX.

Dans l'exemple ci-dessous, nous avons ajouté une ellipse à la première diapositive
```java
// Instancier la classe Presentation qui représente le PPTX
Presentation pres = new Presentation();
try {
    // Obtenir la première diapositive
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Ajouter un AutoShape de type ellipse
    sld.getShapes().addAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);
    
    // Écrire le fichier PPTX sur le disque
    pres.save("EllipseShp1.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Créer une ellipse formatée**
Pour ajouter une ellipse mieux formatée à une diapositive, suivez les étapes ci-dessous :

- Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
- Obtenir la référence d'une diapositive en utilisant son Index.
- Ajouter un AutoShape de type Ellipse en utilisant la méthode [addAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) exposée par l'objet [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection).
- Définir le type de remplissage de l'ellipse sur Solid.
- Définir la couleur de l'ellipse à l'aide de la propriété SolidFillColor.Color telle qu'exposée par l'objet [FillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IFillFormat).
- Définir la couleur des lignes de l'ellipse.
- Définir la largeur des lignes de l'ellipse.
- Enregistrer la présentation modifiée en tant que fichier PPTX.

Dans l'exemple ci-dessous, nous avons ajouté une ellipse formatée à la première diapositive de la présentation.
```java
// Instancier la classe Presentation qui représente le PPTX
Presentation pres = new Presentation();
try {
    // Obtenir la première diapositive
    ISlide sld = pres.getSlides().get_Item(0);

    // Ajouter un AutoShape de type ellipse
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);

    // Appliquer un formatage à la forme ellipse
    shp.getFillFormat().setFillType(FillType.Solid);
    shp.getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.Chocolate));

    // Appliquer un formatage à la ligne de l'ellipse
    shp.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shp.getLineFormat().setWidth(5);

    // Enregistrer le fichier PPTX sur le disque
    pres.save("EllipseShp1.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**Comment définir la position exacte et la taille d'une ellipse par rapport aux unités de la diapositive ?**

Les coordonnées et les tailles sont généralement spécifiées **en points**. Pour obtenir des résultats prévisibles, basez vos calculs sur la taille de la diapositive et convertissez les millimètres ou pouces requis en points avant d'assigner les valeurs.

**Comment placer une ellipse au-dessus ou en dessous d'autres objets (contrôler l'ordre d'empilement) ?**

Ajustez l'ordre de dessin de l'objet en le ramenant à l'avant ou en l'envoyant à l'arrière. Cela permet à l'ellipse de chevaucher d'autres objets ou de révéler ceux qui se trouvent en dessous.

**Comment animer l'apparition ou l'emphase d'une ellipse ?**

[Apply](/slides/fr/androidjava/shape-animation/) des effets d'entrée, d'emphase ou de sortie à la forme, et configurez les déclencheurs et le timing pour orchestrer quand et comment l'animation se déroule.