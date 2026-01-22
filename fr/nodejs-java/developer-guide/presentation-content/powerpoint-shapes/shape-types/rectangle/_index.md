---
title: Ajouter des rectangles aux présentations en JavaScript
linktitle: Rectangle
type: docs
weight: 80
url: /fr/nodejs-java/rectangle/
keywords:
- ajouter un rectangle
- créer un rectangle
- forme rectangle
- rectangle simple
- rectangle formaté
- PowerPoint
- présentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Améliorez vos présentations PowerPoint en ajoutant des rectangles avec JavaScript et Aspose.Slides pour Node.js — concevez et modifiez facilement les formes de manière programmatique."
---

{{% alert color="primary" %}} 

Comme les sujets précédents, celui‑ci porte également sur l’ajout d’une forme et cette fois la forme que nous allons aborder est **Rectangle**. Dans ce sujet, nous avons décrit comment les développeurs peuvent ajouter des rectangles simples ou formatés à leurs diapositives en utilisant Aspose.Slides for Node.js via Java.

{{% /alert %}} 

## **Ajouter un rectangle à la diapositive**
Pour ajouter un rectangle simple à une diapositive sélectionnée de la présentation, veuillez suivre les étapes ci‑dessous :

- Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation).
- Obtenir la référence d’une diapositive en utilisant son Index.
- Ajouter un [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape) de type Rectangle en utilisant la méthode [addAutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) exposée par l’objet [ShapeCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection).
- Enregistrer la présentation modifiée au format PPTX.

Dans l’exemple ci‑dessous, nous avons ajouté un rectangle simple à la première diapositive de la présentation.
```javascript
// Instancier la classe Presentation qui représente le PPTX
var pres = new aspose.slides.Presentation();
try {
    // Obtenir la première diapositive
    var sld = pres.getSlides().get_Item(0);
    // Ajouter une AutoShape de type ellipse
    var shp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 150, 50);
    // Enregistrer le fichier PPTX sur le disque
    pres.save("RecShp1.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Ajouter un rectangle formaté à la diapositive**
Pour ajouter un rectangle formaté à une diapositive, veuillez suivre les étapes ci‑dessous :

- Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation).
- Obtenir la référence d’une diapositive en utilisant son Index.
- Ajouter un [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape) de type Rectangle en utilisant la méthode [addAutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) exposée par l’objet [ShapeCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection).
- Définir le [Fill Type](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FillType) du Rectangle sur Solid.
- Définir la couleur du Rectangle à l’aide de la méthode [SolidFillColor.setColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ColorFormat#setColor-java.awt.Color-) exposée par l’objet [FillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FillFormat) associé à l’objet [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape).
- Définir la couleur des lignes du Rectangle.
- Définir la largeur des lignes du Rectangle.
- Enregistrer la présentation modifiée au format PPTX.

Les étapes ci‑dessus sont implémentées dans l’exemple ci‑dessous.
```javascript
// Instancier la classe Presentation qui représente le PPTX
var pres = new aspose.slides.Presentation();
try {
    // Obtenir la première diapositive
    var sld = pres.getSlides().get_Item(0);
    // Ajouter une AutoShape de type ellipse
    var shp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 150, 50);
    // Appliquer un formatage à la forme ellipse
    shp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shp.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    // Appliquer un formatage à la ligne de l'ellipse
    shp.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    shp.getLineFormat().setWidth(5);
    // Enregistrer le fichier PPTX sur le disque
    pres.save("RecShp2.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**Comment ajouter un rectangle aux coins arrondis ?**

Utilisez le type de forme à coins arrondis [shape type](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapetype/) et ajustez le rayon des coins dans les propriétés de la forme ; l’arrondi peut également être appliqué coin par coin via des ajustements géométriques.

**Comment remplir un rectangle avec une image (texture) ?**

Sélectionnez le [type de remplissage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) d’image, fournissez la source de l’image et configurez les [modes d’étirement/tuile](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillmode/).

**Un rectangle peut‑il avoir une ombre et un halo ?**

Oui. [Ombre extérieure/intérieure, halo et bords doux](/slides/fr/nodejs-java/shape-effect/) sont disponibles avec des paramètres réglables.

**Puis‑je transformer un rectangle en bouton avec un lien hypertexte ?**

Oui. [Attribuer un hyperlien](/slides/fr/nodejs-java/manage-hyperlinks/) au clic de la forme (aller à une diapositive, un fichier, une adresse web ou un e‑mail).

**Comment protéger un rectangle contre le déplacement et les modifications ?**

Utilisez les verrous de forme : vous pouvez interdire le déplacement, le redimensionnement, la sélection ou la modification du texte afin de préserver la mise en page.

**Puis‑je convertir un rectangle en image raster ou SVG ?**

Oui. Vous pouvez [rendre la forme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getImage) en image avec une taille/échelle spécifiée ou [l’exporter en SVG](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/writeassvg/) pour une utilisation vectorielle.

**Comment obtenir rapidement les propriétés réelles (effectives) d’un rectangle en tenant compte du thème et de l’héritage ?**

[Utilisez les propriétés effectives de la forme](/slides/fr/nodejs-java/shape-effective-properties/) : l’API renvoie des valeurs calculées qui tiennent compte des styles du thème, de la disposition et des paramètres locaux, simplifiant l’analyse du formatage.