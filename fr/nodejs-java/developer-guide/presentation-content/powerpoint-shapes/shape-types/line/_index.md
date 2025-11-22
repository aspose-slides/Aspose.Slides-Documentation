---
title: Ligne
type: docs
weight: 50
url: /fr/nodejs-java/Line/
---

{{% alert color="primary" %}} 

Aspose.Slides for Node.js via Java prend en charge l'ajout de différents types de formes aux diapositives. Dans ce sujet, nous allons commencer à travailler avec les formes en ajoutant des lignes aux diapositives. Avec Aspose.Slides for Node.js via Java, les développeurs peuvent non seulement créer des lignes simples, mais également dessiner des lignes décoratives sur les diapositives.

{{% /alert %}} 

## **Créer une ligne simple**

Pour ajouter une ligne simple à une diapositive sélectionnée de la présentation, veuillez suivre les étapes ci-dessous:

- Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
- Obtenir la référence d'une diapositive en utilisant son index.
- Ajouter une AutoShape de type Line en utilisant la méthode [addAutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) exposée par l'objet [ShapeCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection).
- Enregistrer la présentation modifiée en tant que fichier PPTX.

Dans l'exemple ci-dessous, nous avons ajouté une ligne à la première diapositive de la présentation.
```javascript
// Instancier la classe PresentationEx qui représente le fichier PPTX
var pres = new aspose.slides.Presentation();
try {
    // Obtenir la première diapositive
    var sld = pres.getSlides().get_Item(0);
    // Ajouter une AutoShape de type ligne
    sld.getShapes().addAutoShape(aspose.slides.ShapeType.Line, 50, 150, 300, 0);
    // Enregistrer le PPTX sur le disque
    pres.save("LineShape.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Créer une ligne à forme de flèche**

Aspose.Slides for Node.js via Java permet également aux développeurs de configurer certaines propriétés de la ligne pour la rendre plus attrayante. Essayons de configurer quelques propriétés d'une ligne pour qu'elle ressemble à une flèche. Veuillez suivre les étapes ci-dessous pour le faire :

- Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
- Obtenir la référence d'une diapositive en utilisant son index.
- Ajouter une AutoShape de type Line en utilisant la méthode [addAutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) exposée par l'objet [ShapeCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection).
- Définir le [Line Style](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LineStyle) sur l'un des styles proposés par Aspose.Slides for Node.js via Java.
- Définir la largeur de la ligne.
- Définir le [Dash Style](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LineDashStyle) de la ligne sur l'un des styles proposés par Aspose.Slides for Node.js via Java.
- Définir le [Arrow Head Style](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LineArrowheadStyle) et la [Length](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LineArrowheadLength) du point de départ de la ligne.
- Définir le [Arrow Head Style](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LineArrowheadStyle) et la [Length](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LineArrowheadLength) du point d'arrivée de la ligne.
- Enregistrer la présentation modifiée en tant que fichier PPTX.
```javascript
// Instancier la classe PresentationEx qui représente le fichier PPTX
var pres = new aspose.slides.Presentation();
try {
    // Obtenir la première diapositive
    var sld = pres.getSlides().get_Item(0);
    // Ajouter une AutoShape de type ligne
    var shp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Line, 50, 150, 300, 0);
    // Appliquer un formatage à la ligne
    shp.getLineFormat().setStyle(aspose.slides.LineStyle.ThickBetweenThin);
    shp.getLineFormat().setWidth(10);
    shp.getLineFormat().setDashStyle(aspose.slides.LineDashStyle.DashDot);
    shp.getLineFormat().setBeginArrowheadLength(aspose.slides.LineArrowheadLength.Short);
    shp.getLineFormat().setBeginArrowheadStyle(aspose.slides.LineArrowheadStyle.Oval);
    shp.getLineFormat().setEndArrowheadLength(aspose.slides.LineArrowheadLength.Long);
    shp.getLineFormat().setEndArrowheadStyle(aspose.slides.LineArrowheadStyle.Triangle);
    shp.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", aspose.slides.PresetColor.Maroon));
    // Enregistrer le PPTX sur le disque
    pres.save("LineShape.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**Puis-je convertir une ligne ordinaire en connecteur afin qu'elle se « colle » aux formes ?**

Non. Une ligne ordinaire (une [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) de type [Line](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapetype/)) ne devient pas automatiquement un connecteur. Pour qu'elle se colle aux formes, utilisez le type [Connector](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connector/) dédié et les [API correspondantes](/slides/fr/nodejs-java/connector/) pour les connexions.

**Que faire si les propriétés d’une ligne sont héritées du thème et qu’il est difficile de déterminer les valeurs finales ?**

Consultez les [propriétés effectives](/slides/fr/nodejs-java/shape-effective-properties/) via les classes `ILineFormatEffectiveData`/`ILineFillFormatEffectiveData` — celles‑ci tiennent déjà compte de l'héritage et des styles du thème.

**Puis-je verrouiller une ligne contre l'édition (déplacement, redimensionnement) ?**

Oui. Les formes offrent des [objets de verrouillage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/getautoshapelock/) qui permettent de [interdire les opérations d'édition](/slides/fr/nodejs-java/applying-protection-to-presentation/).