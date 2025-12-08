---
title: Ellipse
type: docs
weight: 30
url: /fr/nodejs-java/ellipse/
---

{{% alert color="primary" %}} 
Dans ce sujet, nous présenterons aux développeurs comment ajouter des formes d'ellipse à leurs diapositives en utilisant Aspose.Slides pour Node.js via Java. Aspose.Slides pour Node.js via Java offre un ensemble d'API plus simple pour dessiner différents types de formes avec seulement quelques lignes de code.
{{% /alert %}} 

## **Créer une ellipse**
Pour ajouter une ellipse simple à une diapositive sélectionnée de la présentation, veuillez suivre les étapes ci‑dessous :

- Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation).
- Obtenir la référence d'une diapositive en utilisant son Index.
- Ajouter une AutoShape de type Ellipse en utilisant la méthode [addAutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) exposée par l'objet [ShapeCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection).
- Enregistrer la présentation modifiée en tant que fichier PPTX.

Dans l'exemple ci‑dessous, nous avons ajouté une ellipse à la première diapositive
```javascript
// Instancier la classe Presentation qui représente le PPTX
var pres = new aspose.slides.Presentation();
try {
    // Obtenir la première diapositive
    var sld = pres.getSlides().get_Item(0);
    // Ajouter une AutoShape de type ellipse
    sld.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 150, 150, 50);
    // Écrire le fichier PPTX sur le disque
    pres.save("EllipseShp1.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Créer une ellipse formatée**
Pour ajouter une ellipse mieux formatée à une diapositive, veuillez suivre les étapes ci‑dessous :

- Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation).
- Obtenir la référence d'une diapositive en utilisant son Index.
- Ajouter une AutoShape de type Ellipse en utilisant la méthode [addAutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) exposée par l'objet [ShapeCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection).
- Définir le type de remplissage de l'ellipse sur Solid.
- Définir la couleur de l'ellipse à l'aide de la propriété SolidFillColor.Color exposée par l'objet [FillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FillFormat) associé à l'objet [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape).
- Définir la couleur des bordures de l'ellipse.
- Définir la largeur des bordures de l'ellipse.
- Enregistrer la présentation modifiée en tant que fichier PPTX.

Dans l'exemple ci‑dessus, nous avons ajouté une ellipse formatée à la première diapositive de la présentation.
```javascript
// Instancier la classe Presentation qui représente le PPTX
var pres = new aspose.slides.Presentation();
try {
    // Obtenir la première diapositive
    var sld = pres.getSlides().get_Item(0);
    // Ajouter une AutoShape de type ellipse
    var shp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 150, 150, 50);
    // Appliquer un certain formatage à la forme ellipse
    shp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shp.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", aspose.slides.PresetColor.Chocolate));
    // Appliquer un certain formatage à la ligne de l'ellipse
    shp.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    shp.getLineFormat().setWidth(5);
    // Écrire le fichier PPTX sur le disque
    pres.save("EllipseShp1.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

 
## **FAQ**

**Comment définir la position exacte et la taille d'une ellipse par rapport aux unités de la diapositive ?**

Les coordonnées et les tailles sont généralement spécifiées **en points**. Pour obtenir des résultats prévisibles, basez vos calculs sur la taille de la diapositive et convertissez les millimètres ou pouces requis en points avant d'assigner les valeurs.

**Comment placer une ellipse au-dessus ou en dessous d'autres objets (contrôler l'ordre d'empilement) ?**

Ajustez l'ordre de dessin de l'objet en le portant au premier plan ou en l'envoyant à l'arrière-plan. Cela permet à l'ellipse de recouvrir d'autres objets ou de révéler ceux qui se trouvent en dessous.

**Comment animer l'apparition ou l'emphase d'une ellipse ?**

[Appliquez](/slides/fr/nodejs-java/shape-animation/) des effets d'entrée, d'emphase ou de sortie à la forme, et configurez les déclencheurs et le timing pour orchestrer quand et comment l'animation se joue.