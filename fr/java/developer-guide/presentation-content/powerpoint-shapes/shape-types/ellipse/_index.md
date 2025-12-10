---
title: Ajouter des ellipses aux présentations en Java
linktitle: Ellipse
type: docs
weight: 30
url: /fr/java/ellipse/
keywords:
- ellipse
- forme
- ajouter ellipse
- créer ellipse
- dessiner ellipse
- ellipse formatée
- PowerPoint
- présentation
- Java
- Aspose.Slides
description: "Apprenez à créer, formater et manipuler des formes d'ellipse dans Aspose.Slides pour Java sur les présentations PPT et PPTX — exemples de code Java inclus."
---

{{% alert color="primary" %}} 

Dans ce sujet, nous présenterons aux développeurs comment ajouter des formes d'ellipse à leurs diapositives en utilisant Aspose.Slides for Java. Aspose.Slides for Java fournit un ensemble d'API plus simple pour dessiner différents types de formes en quelques lignes de code.

{{% /alert %}} 

## **Créer une ellipse**
Pour ajouter une simple ellipse à une diapositive sélectionnée de la présentation, veuillez suivre les étapes ci‑dessous :

- Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation).
- Obtenez la référence d’une diapositive en utilisant son Index.
- Ajoutez une AutoShape de type Ellipse en utilisant la méthode [addAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) exposée par l’objet [IShapeCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection).
- Enregistrez la présentation modifiée en tant que fichier PPTX.

Dans l’exemple ci‑dessous, nous avons ajouté une ellipse à la première diapositive
```java
// Instanciez la classe Presentation qui représente le PPTX
Presentation pres = new Presentation();
try {
    // Obtenez la première diapositive
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Ajoutez une AutoShape de type ellipse
    sld.getShapes().addAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);
    
    // Enregistrez le fichier PPTX sur le disque
    pres.save("EllipseShp1.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Créer une ellipse formatée**
Pour ajouter une ellipse mieux formatée à une diapositive, veuillez suivre les étapes ci‑dessous :

- Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation).
- Obtenez la référence d’une diapositive en utilisant son Index.
- Ajoutez une AutoShape de type Ellipse en utilisant la méthode [addAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) exposée par l’objet [IShapeCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection).
- Définissez le type de remplissage de l’ellipse sur Solide.
- Définissez la couleur de l’ellipse en utilisant la propriété SolidFillColor.Color exposée par l’objet [FillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/IFillFormat) associé à l’objet [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShape).
- Définissez la couleur des lignes de l’ellipse.
- Définissez la largeur des lignes de l’ellipse.
- Enregistrez la présentation modifiée en tant que fichier PPTX.

Dans l’exemple ci‑dessous, nous avons ajouté une ellipse formatée à la première diapositive de la présentation.
```java
// Instanciez la classe Presentation qui représente le PPTX
Presentation pres = new Presentation();
try {
    // Obtenez la première diapositive
    ISlide sld = pres.getSlides().get_Item(0);

    // Ajoutez une AutoShape de type ellipse
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);

    // Appliquez un certain formatage à la forme ellipse
    shp.getFillFormat().setFillType(FillType.Solid);
    shp.getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.Chocolate));

    // Appliquez un certain formatage à la ligne de l'ellipse
    shp.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shp.getLineFormat().setWidth(5);

    // Enregistrez le fichier PPTX sur le disque
    pres.save("EllipseShp1.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**Comment définir la position exacte et la taille d'une ellipse par rapport aux unités de la diapositive ?**

Les coordonnées et les tailles sont généralement spécifiées **en points**. Pour obtenir des résultats prévisibles, basez vos calculs sur la taille de la diapositive et convertissez les millimètres ou pouces requis en points avant d'assigner les valeurs.

**Comment placer une ellipse au-dessus ou au-dessous d'autres objets (contrôler l'ordre de superposition) ?**

Ajustez l'ordre de dessin de l'objet en le portant au premier plan ou en l'envoyant à l'arrière‑plan. Cela permet à l'ellipse de chevaucher d'autres objets ou de révéler ceux qui se trouvent en dessous.

**Comment animer l'apparition ou l'accentuation d'une ellipse ?**

[Appliquer](/slides/fr/java/shape-animation/) des effets d'entrée, d'accentuation ou de sortie à la forme, et configurez les déclencheurs et le timing pour orchestrer quand et comment l'animation se joue.