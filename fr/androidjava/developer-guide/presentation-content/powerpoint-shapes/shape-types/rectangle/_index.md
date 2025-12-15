---
title: Ajouter des rectangles aux présentations sur Android
linktitle: Rectangle
type: docs
weight: 80
url: /fr/androidjava/rectangle/
keywords:
- ajouter un rectangle
- créer un rectangle
- forme rectangle
- rectangle simple
- rectangle formaté
- PowerPoint
- présentation
- Android
- Java
- Aspose.Slides
description: "Améliorez vos présentations PowerPoint en ajoutant des rectangles avec Aspose.Slides pour Android via Java — créez et modifiez facilement des formes par programme."
---

{{% alert color="primary" %}} 

Comme les sujets précédents, celui-ci porte également sur l’ajout d’une forme et cette fois la forme que nous allons aborder est le **Rectangle**. Dans ce sujet, nous expliquons comment les développeurs peuvent ajouter des rectangles simples ou formatés à leurs diapositives en utilisant Aspose.Slides pour Android via Java.

{{% /alert %}} 

## **Ajouter un rectangle à une diapositive**
Pour ajouter un rectangle simple à une diapositive sélectionnée de la présentation, suivez les étapes ci‑dessous :

- Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
- Obtenir la référence d’une diapositive en utilisant son indice.
- Ajouter un [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) de type Rectangle en utilisant la méthode [addAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) exposée par l’objet [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection).
- Enregistrer la présentation modifiée sous forme de fichier PPTX.

Dans l’exemple ci‑dessous, nous avons ajouté un rectangle simple à la première diapositive de la présentation.
```java
// Instancier la classe Presentation qui représente le PPTX
Presentation pres = new Presentation();
try {
    // Obtenir la première diapositive
    ISlide sld = pres.getSlides().get_Item(0);

    // Ajouter une AutoShape de type ellipse
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    // Enregistrer le fichier PPTX sur le disque
    pres.save("RecShp1.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Ajouter un rectangle formaté à une diapositive**
Pour ajouter un rectangle formaté à une diapositive, suivez les étapes ci‑dessous :

- Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
- Obtenir la référence d’une diapositive en utilisant son indice.
- Ajouter un [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) de type Rectangle en utilisant la méthode [addAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) exposée par l’objet [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection).
- Définir le [Fill Type](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FillType) du rectangle sur Solid.
- Définir la couleur du rectangle à l’aide de la méthode [SolidFillColor.setColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IColorFormat#setColor-java.awt.Color-) exposée par l’objet [IFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IFillFormat) associé à l’objet [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape).
- Définir la couleur des lignes du rectangle.
- Définir la largeur des lignes du rectangle.
- Enregistrer la présentation modifiée sous forme de fichier PPTX.

Les étapes ci‑dessus sont implémentées dans l’exemple ci‑dessous.
```java
// Instancier la classe Presentation qui représente le PPTX
Presentation pres = new Presentation();
try {
    // Obtenir la première diapositive
    ISlide sld = pres.getSlides().get_Item(0);

    // Ajouter une AutoShape de type ellipse
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    // Appliquer un certain formatage à la forme ellipse
    shp.getFillFormat().setFillType(FillType.Solid);
    shp.getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    // Appliquer un certain formatage à la ligne de l'ellipse
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

Utilisez le [shape type](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapetype/) à coins arrondis et ajustez le rayon des coins dans les propriétés de la forme ; l’arrondi peut également être appliqué coin par coin via des ajustements géométriques.

**Comment remplir un rectangle avec une image (texture) ?**

Sélectionnez le [fill type](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) d’image, fournissez la source de l’image et configurez les [modes d’étirement/tuile](https://reference.aspose.com/slides/androidjava/com.aspose.slides/picturefillmode/).

**Un rectangle peut-il avoir une ombre et une lueur ?**

Oui. Les [ombre extérieure/intérieure, lueur et bords doux](/slides/fr/androidjava/shape-effect/) sont disponibles avec des paramètres ajustables.

**Puis-je transformer un rectangle en bouton avec un hyperlien ?**

Oui. [Attribuer un hyperlien](/slides/fr/androidjava/manage-hyperlinks/) au clic de la forme (aller à une diapositive, un fichier, une adresse web ou un e‑mail).

**Comment protéger un rectangle contre le déplacement et les modifications ?**

[Utiliser les verrous de forme](/slides/fr/androidjava/applying-protection-to-presentation/): vous pouvez interdire le déplacement, le redimensionnement, la sélection ou la modification du texte afin de préserver la mise en page.

**Puis-je convertir un rectangle en image raster ou SVG ?**

Oui. Vous pouvez [rendre la forme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getImage-int-float-float-) en image avec une taille/échelle spécifiée ou [l’exporter en SVG](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) pour une utilisation vectorielle.

**Comment obtenir rapidement les propriétés réelles (effectives) d’un rectangle en tenant compte du thème et de l’héritage ?**

[Utiliser les propriétés effectives de la forme](/slides/fr/androidjava/shape-effective-properties/): l’API renvoie des valeurs calculées qui tiennent compte des styles de thème, de la mise en page et des paramètres locaux, simplifiant l’analyse du formatage.