---
title: Rectangle
type: docs
weight: 80
url: /fr/nodejs-java/rectangle/
---

{{% alert color="primary" %}} 

Comme les sujets précédents, celui-ci porte également sur l'ajout d'une forme et cette fois la forme dont nous allons parler est **Rectangle**. Dans ce sujet, nous avons décrit comment les développeurs peuvent ajouter des rectangles simples ou formatés à leurs diapositives en utilisant Aspose.Slides pour Node.js via Java.

{{% /alert %}} 

## **Ajouter un rectangle à la diapositive**
Pour ajouter un rectangle simple à une diapositive sélectionnée de la présentation, suivez les étapes ci‑dessous :

- Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation).
- Obtenez la référence d'une diapositive en utilisant son Index.
- Ajoutez une [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape) de type Rectangle à l'aide de la méthode [addAutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) exposée par l'objet [ShapeCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection).
- Enregistrez la présentation modifiée au format PPTX.

Dans l'exemple ci‑dessous, nous avons ajouté un rectangle simple à la première diapositive de la présentation.
```javascript
// Instancier la classe Presentation qui représente le PPTX
var pres = new aspose.slides.Presentation();
try {
    // Récupérer la première diapositive
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
Pour ajouter un rectangle formaté à une diapositive, suivez les étapes ci‑dessous :

- Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation).
- Obtenez la référence d'une diapositive en utilisant son Index.
- Ajoutez une [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape) de type Rectangle à l'aide de la méthode [addAutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) exposée par l'objet [ShapeCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection).
- Définissez le [Fill Type](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FillType) du Rectangle sur Solid.
- Définissez la couleur du Rectangle à l'aide de la méthode [SolidFillColor.setColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ColorFormat#setColor-java.awt.Color-) exposée par l'objet [FillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FillFormat) associé à l'objet [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape).
- Définissez la couleur des lignes du Rectangle.
- Définissez la largeur des lignes du Rectangle.
- Enregistrez la présentation modifiée au format PPTX.

Les étapes ci‑dessus sont implémentées dans l'exemple ci‑dessous.
```javascript
// Instancier la classe Presentation qui représente le PPTX
var pres = new aspose.slides.Presentation();
try {
    // Récupérer la première diapositive
    var sld = pres.getSlides().get_Item(0);
    // Ajouter une AutoShape de type ellipse
    var shp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 150, 50);
    // Appliquer un formatage à la forme ellipse
    shp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shp.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    // Appliquer un formatage à la bordure de l'ellipse
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

**Comment ajouter un rectangle avec des coins arrondis ?**

Utilisez le [shape type](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapetype/) à coins arrondis et ajustez le rayon des coins dans les propriétés de la forme ; l'arrondissement peut également être appliqué coin par coin via des ajustements géométriques.

**Comment remplir un rectangle avec une image (texture) ?**

Sélectionnez le type de remplissage d'image [fill type](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/), fournissez la source de l'image et configurez les [modes d'étirement/tiling](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillmode/).

**Un rectangle peut-il avoir une ombre et une lueur ?**

Oui. Les [Ombre extérieure/intérieure, lueur et bords doux](/slides/fr/nodejs-java/shape-effect/) sont disponibles avec des paramètres réglables.

**Puis-je transformer un rectangle en bouton avec un hyperlien ?**

Oui. [Assignez un hyperlien](/slides/fr/nodejs-java/manage-hyperlinks/) au clic de la forme (aller à une diapositive, un fichier, une adresse Web ou un e‑mail).

**Comment puis‑je protéger un rectangle contre le déplacement et les modifications ?**

[Utilisez les verrous de forme](/slides/fr/nodejs-java/applying-protection-to-presentation/) : vous pouvez interdire le déplacement, le redimensionnement, la sélection ou la modification du texte afin de préserver la mise en page.

**Puis‑je convertir un rectangle en image raster ou SVG ?**

Oui. Vous pouvez [rendre la forme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getImage) en image avec une taille/échelle spécifiée ou [l'exporter au format SVG](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/writeassvg/) pour une utilisation vectorielle.

**Comment obtenir rapidement les propriétés réelles (effectives) d'un rectangle en tenant compte du thème et de l'héritage ?**

[Utilisez les propriétés effectives de la forme](/slides/fr/nodejs-java/shape-effective-properties/) : l’API renvoie des valeurs calculées qui tiennent compte des styles de thème, de la mise en page et des paramètres locaux, simplifiant l’analyse du formatage.