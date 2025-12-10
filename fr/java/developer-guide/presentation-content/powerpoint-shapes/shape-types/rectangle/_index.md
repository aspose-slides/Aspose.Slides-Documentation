---
title: Ajouter des rectangles aux présentations en Java
linktitle: Rectangle
type: docs
weight: 80
url: /fr/java/rectangle/
keywords:
- ajouter rectangle
- créer rectangle
- forme rectangle
- rectangle simple
- rectangle formaté
- PowerPoint
- présentation
- Java
- Aspose.Slides
description: "Améliorez vos présentations PowerPoint en ajoutant des rectangles avec Aspose.Slides for Java — concevez et modifiez facilement les formes de manière programmatique."
---

{{% alert color="primary" %}} 

Comme les sujets précédents, celui‑ci porte également sur l’ajout d’une forme et cette fois la forme dont nous parlerons est le **Rectangle**. Dans ce sujet, nous avons décrit comment les développeurs peuvent ajouter des rectangles simples ou formatés à leurs diapositives à l’aide d’Aspose.Slides for Java.

{{% /alert %}} 

## **Ajouter un Rectangle à une Diapositive**
Pour ajouter un rectangle simple à une diapositive sélectionnée de la présentation, veuillez suivre les étapes ci‑dessous :

- Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation).
- Obtenez la référence d’une diapositive en utilisant son index.
- Ajoutez une [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape) de type Rectangle en utilisant la méthode [addAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) exposée par l’objet [IShapeCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection).
- Enregistrez la présentation modifiée en tant que fichier PPTX.

Dans l’exemple ci‑dessus, nous avons ajouté un rectangle simple à la première diapositive de la présentation.
```java
// Instanciez la classe Presentation qui représente le PPTX
Presentation pres = new Presentation();
try {
    // Récupérez la première diapositive
    ISlide sld = pres.getSlides().get_Item(0);

    // Ajoutez une AutoShape de type ellipse
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    // Enregistrez le fichier PPTX sur le disque
    pres.save("RecShp1.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Ajouter un Rectangle Formaté à une Diapositive**
Pour ajouter un rectangle formaté à une diapositive, veuillez suivre les étapes ci‑dessous :

- Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation).
- Obtenez la référence d’une diapositive en utilisant son index.
- Ajoutez une [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape) de type Rectangle en utilisant la méthode [addAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) exposée par l’objet [IShapeCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection).
- Définissez le [Fill Type](https://reference.aspose.com/slides/java/com.aspose.slides/FillType) du Rectangle sur Solid.
- Définissez la couleur du Rectangle à l’aide de la méthode [SolidFillColor.setColor](https://reference.aspose.com/slides/java/com.aspose.slides/IColorFormat#setColor-java.awt.Color-) exposée par l’objet [IFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/IFillFormat) associé à l’objet [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShape).
- Définissez la couleur des bordures du Rectangle.
- Définissez la largeur des bordures du Rectangle.
- Enregistrez la présentation modifiée en tant que fichier PPTX.

Les étapes ci‑dessus sont implémentées dans l’exemple ci‑dessous.
```java
// Instanciez la classe Presentation qui représente le PPTX
Presentation pres = new Presentation();
try {
    // Obtenir la première diapositive
    ISlide sld = pres.getSlides().get_Item(0);

    // Ajouter une AutoShape de type ellipse
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    // Appliquer un formatage à la forme ellipse
    shp.getFillFormat().setFillType(FillType.Solid);
    shp.getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    // Appliquer un formatage à la ligne de l'Ellipse
    shp.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shp.getLineFormat().setWidth(5);

    // Enregistrer le fichier PPTX sur le disque
    pres.save("RecShp2.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**Comment ajouter un rectangle avec des coins arrondis ?**

Utilisez le type de forme à coins arrondis [shape type](https://reference.aspose.com/slides/java/com.aspose.slides/shapetype/) et ajustez le rayon des coins dans les propriétés de la forme ; le rayon peut également être appliqué individuellement à chaque coin via des ajustements géométriques.

**Comment remplir un rectangle avec une image (texture) ?**

Sélectionnez le [fill type](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) d’image, fournissez la source de l’image et configurez les modes d’étirement/tuile ([stretching/tiling modes](https://reference.aspose.com/slides/java/com.aspose.slides/picturefillmode/)).

**Un rectangle peut‑il avoir une ombre et une lueur ?**

Oui. Les [ombres extérieures/intérieures, la lueur et les bords doux](/slides/fr/java/shape-effect/) sont disponibles avec des paramètres réglables.

**Puis‑je transformer un rectangle en bouton avec un hyperlien ?**

Oui. [Attribuez un hyperlien](/slides/fr/java/manage-hyperlinks/) au clic sur la forme (vers une diapositive, un fichier, une adresse web ou un e‑mail).

**Comment protéger un rectangle contre les déplacements et les modifications ?**

[Utilisez les verrous de forme](/slides/fr/java/applying-protection-to-presentation/) : vous pouvez interdire le déplacement, le redimensionnement, la sélection ou la modification du texte afin de préserver la disposition.

**Puis‑je convertir un rectangle en image raster ou en SVG ?**

Oui. Vous pouvez [rendre la forme](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getImage-int-float-float-) en une image avec une taille/échelle spécifiée ou [l’exporter en SVG](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) pour une utilisation vectorielle.

**Comment obtenir rapidement les propriétés réelles (effectives) d’un rectangle en tenant compte du thème et de l’héritage ?**

[Utilisez les propriétés effectives de la forme](/slides/fr/java/shape-effective-properties/) : l’API renvoie les valeurs calculées qui tiennent compte des styles du thème, de la mise en page et des paramètres locaux, simplifiant l’analyse du formatage.