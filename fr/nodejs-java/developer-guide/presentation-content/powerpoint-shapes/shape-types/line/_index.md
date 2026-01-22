---
title: Ajouter des formes de ligne aux présentations en JavaScript
linktitle: Ligne
type: docs
weight: 50
url: /fr/nodejs-java/line/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Apprenez à manipuler le format des lignes dans les présentations PowerPoint avec JavaScript et Aspose.Slides pour Node.js. Découvrez les propriétés, méthodes et exemples."
---

{{% alert color="primary" %}} 

Aspose.Slides for Node.js via Java prend en charge l’ajout de différents types de formes aux diapositives. Dans ce sujet, nous commencerons à travailler avec les formes en ajoutant des lignes aux diapositives. Avec Aspose.Slides for Node.js via Java, les développeurs peuvent non seulement créer des lignes simples, mais aussi dessiner des lignes décoratives sur les diapositives.

{{% /alert %}} 

## **Créer une ligne simple**

Pour ajouter une ligne simple à une diapositive sélectionnée de la présentation, veuillez suivre les étapes ci‑dessous :

- Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
- Obtenez la référence d’une diapositive en utilisant son index.
- Ajoutez une AutoShape de type Line à l’aide de la méthode [addAutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) exposée par l’objet [ShapeCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection).
- Enregistrez la présentation modifiée sous forme de fichier PPTX.

Dans l’exemple ci‑dessous, nous avons ajouté une ligne à la première diapositive de la présentation.
```javascript
// Instancie la classe PresentationEx qui représente le fichier PPTX
var pres = new aspose.slides.Presentation();
try {
    // Récupère la première diapositive
    var sld = pres.getSlides().get_Item(0);
    // Ajoute une AutoShape de type ligne
    sld.getShapes().addAutoShape(aspose.slides.ShapeType.Line, 50, 150, 300, 0);
    // Enregistre le PPTX sur le disque
    pres.save("LineShape.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Créer une ligne en forme de flèche**

Aspose.Slides for Node.js via Java permet également aux développeurs de configurer certaines propriétés de la ligne pour la rendre plus attrayante. Essayons de configurer quelques propriétés afin que la ligne ressemble à une flèche. Veuillez suivre les étapes ci‑dessous :

- Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
- Obtenez la référence d’une diapositive en utilisant son index.
- Ajoutez une AutoShape de type Line à l’aide de la méthode [addAutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) exposée par l’objet [ShapeCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection).
- Définissez le [Line Style](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LineStyle) sur l’un des styles proposés par Aspose.Slides for Node.js via Java.
- Définissez la largeur de la ligne.
- Définissez le [Dash Style](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LineDashStyle) de la ligne sur l’un des styles proposés par Aspose.Slides for Node.js via Java.
- Définissez le [Arrow Head Style](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LineArrowheadStyle) et la [Length](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LineArrowheadLength) du point de départ de la ligne.
- Définissez le [Arrow Head Style](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LineArrowheadStyle) et la [Length](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LineArrowheadLength) du point d’arrivée de la ligne.
- Enregistrez la présentation modifiée sous forme de fichier PPTX.
```javascript
// Instancie la classe PresentationEx qui représente le fichier PPTX
var pres = new aspose.slides.Presentation();
try {
    // Récupère la première diapositive
    var sld = pres.getSlides().get_Item(0);
    // Ajoute une AutoShape de type ligne
    var shp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Line, 50, 150, 300, 0);
    // Applique un certain format à la ligne
    shp.getLineFormat().setStyle(aspose.slides.LineStyle.ThickBetweenThin);
    shp.getLineFormat().setWidth(10);
    shp.getLineFormat().setDashStyle(aspose.slides.LineDashStyle.DashDot);
    shp.getLineFormat().setBeginArrowheadLength(aspose.slides.LineArrowheadLength.Short);
    shp.getLineFormat().setBeginArrowheadStyle(aspose.slides.LineArrowheadStyle.Oval);
    shp.getLineFormat().setEndArrowheadLength(aspose.slides.LineArrowheadLength.Long);
    shp.getLineFormat().setEndArrowheadStyle(aspose.slides.LineArrowheadStyle.Triangle);
    shp.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", aspose.slides.PresetColor.Maroon));
    // Enregistre le PPTX sur le disque
    pres.save("LineShape.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**Puis‑je convertir une ligne ordinaire en connecteur afin qu’elle « s’ajuste » aux formes ?**

Non. Une ligne ordinaire (une [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) de type [Line](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapetype/)) ne devient pas automatiquement un connecteur. Pour qu’elle s’ajuste aux formes, utilisez le type dédié [Connector](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connector/) et les [API correspondantes](/slides/fr/nodejs-java/connector/) pour les connexions.

**Que faire si les propriétés d’une ligne sont héritées du thème et qu’il est difficile de déterminer les valeurs finales ?**

[Lisez les propriétés effectives](/slides/fr/nodejs-java/shape-effective-properties/) via les classes `ILineFormatEffectiveData`/`ILineFillFormatEffectiveData` — elles tiennent déjà compte de l’héritage et des styles du thème.

**Puis‑je verrouiller une ligne contre la modification (déplacement, redimensionnement) ?**

Oui. Les formes fournissent des [objets de verrouillage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/getautoshapelock/) qui vous permettent d’interdire les opérations de modification.