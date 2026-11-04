---
title: Appliquer des effets de forme dans les présentations avec JavaScript
linktitle: Effet de forme
type: docs
weight: 30
url: /fr/nodejs-java/shape-effect/
keywords:
- effet de forme
- effet d'ombre
- effet de réflexion
- effet de lueur
- effet de bords doux
- format d'effet
- PowerPoint
- présentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Transformez vos fichiers PPT et PPTX avec des effets de forme avancés en utilisant JavaScript et Aspose.Slides pour Node.js—créez des diapositives percutantes et professionnelles en quelques secondes."
---
## **Introduction**

Alors que les effets dans PowerPoint peuvent être utilisés pour faire ressortir une forme, ils diffèrent des [remplissages](/slides/fr/nodejs-java/shape-formatting/#gradient-fill) ou des contours. En utilisant les effets PowerPoint, vous pouvez créer des reflets convaincants sur une forme, diffuser la lueur d’une forme, etc.

![Effet de forme](shape-effect.png)

PowerPoint propose six effets pouvant être appliqués aux formes. Vous pouvez appliquer un ou plusieurs effets à une forme.

Certaines combinaisons d’effets sont plus harmonieuses que d’autres. Pour cette raison, PowerPoint propose des options sous **Preset**. Les options Préréglées sont des combinaisons de deux effets ou plus dont on sait qu’elles donnent de bons résultats. Ainsi, en sélectionnant un préréglage, vous n’aurez pas à perdre du temps à tester ou à combiner différents effets pour obtenir une jolie combinaison.

Aspose.Slides fournit des propriétés et des méthodes sous la classe [EffectFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/) qui vous permettent d’appliquer les mêmes effets aux formes dans les présentations PowerPoint.

## **Appliquer un effet d'ombre**

Aspose.Slides for Node.js via Java prend en charge les ombres extérieures et intérieures pour les formes. Vous pouvez personnaliser leur couleur, direction, distance et rayon de flou pour correspondre au design de votre présentation.

### **Appliquer une ombre extérieure**

Utilisez une ombre extérieure pour faire ressortir une carte ou un panneau par rapport à l’arrière‑plan de la diapositive. L’ombre s’étend au‑delà des bords de la forme, créant l’impression que la forme est surélevée au-dessus de la diapositive. Ajustez sa couleur, direction, distance et rayon de flou pour correspondre à l’éclairage et au style de votre modèle.

Ce code JavaScript montre comment appliquer l’[effet d'ombre extérieure](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getOuterShadowEffect) à un rectangle :

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableOuterShadowEffect();
    const color = java.newInstanceSync("java.awt.Color", 169, 169, 169);
    shape.getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(color);
    shape.getEffectFormat().getOuterShadowEffect().setDistance(10);
    shape.getEffectFormat().getOuterShadowEffect().setDirection(45);

    presentation.save("shadow_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Effet d'ombre](shadow_effect.png)

### **Appliquer une ombre intérieure**

Lorsque vous reproduisez le style visuel d’un modèle, utilisez une ombre intérieure pour donner à une carte ou un panneau un aspect en retrait. Une ombre extérieure s’étend à l’extérieur de la forme et la fait paraître surélevée, tandis qu’une ombre intérieure ombre l’intérieur de ses bords.

Appelez [enableInnerShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#enableInnerShadowEffect), puis configurez l’ombre renvoyée par [getInnerShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getInnerShadowEffect). Des valeurs de rayon de flou plus élevées produisent des bords plus doux.

Cet exemple JavaScript crée une carte bleu clair avec une ombre intérieure gris foncé et l’enregistre au format PPTX. La direction de l’ombre est de 225 degrés, sa distance est de 7 points et son rayon de flou est de 6 points :

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 200, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const fillColor = java.newInstanceSync("java.awt.Color", 173, 216, 230);
    shape.getFillFormat().getSolidFillColor().setColor(fillColor);
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    shape.getEffectFormat().enableInnerShadowEffect();
    const shadow = shape.getEffectFormat().getInnerShadowEffect();
    const color = java.newInstanceSync("java.awt.Color", 105, 105, 105);
    shadow.getShadowColor().setColor(color);
    shadow.setDirection(225);
    shadow.setDistance(7);
    shadow.setBlurRadius(6);

    presentation.save("inner_shadow_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Rectangle bleu clair avec une ombre intérieure](inner_shadow_effect.png)

Pour supprimer l’ombre intérieure, appelez [disableInnerShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#disableInnerShadowEffect) sur le format d’effet de la forme.

## **Appliquer un effet de réflexion**

Pour appliquer un effet de réflexion dans Aspose.Slides for Node.js via Java, vous pouvez ajouter une réflexion miroir aux formes, en ajustant des paramètres tels que la distance, la transparence et la taille. Cet effet améliore l’esthétique de vos présentations en donnant aux formes un aspect plus poli et sophistiqué. Il est facile à implémenter avec un code simple, permettant une application rapide sur plusieurs éléments pour une conception cohérente.

Ce code JavaScript montre comment appliquer l’[effet de réflexion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getReflectionEffect) à une forme :

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableReflectionEffect();
    shape.getEffectFormat().getReflectionEffect().setRectangleAlign(java.newByte(aspose.slides.RectangleAlignment.Bottom));
    shape.getEffectFormat().getReflectionEffect().setDirection(90);
    shape.getEffectFormat().getReflectionEffect().setDistance(40);
    shape.getEffectFormat().getReflectionEffect().setBlurRadius(2);

    presentation.save("reflection_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Effet de réflexion](reflection_effect.png)

## **Appliquer un effet de lueur**

Pour appliquer un effet de lueur à une forme dans Aspose.Slides for Node.js via Java, vous pouvez ajouter une aura douce et lumineuse autour des formes, en ajustant des propriétés comme la couleur et la taille. Cet effet aide les formes à se démarquer et ajoute un élément visuel attrayant à votre présentation. Il est facile à mettre en œuvre avec peu de code, améliorant l’aspect général de vos diapositives.

Ce code JavaScript montre comment appliquer l’[effet de lueur](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getGlowEffect) à une forme :

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableGlowEffect();
    const color = java.getStaticFieldValue("java.awt.Color", "MAGENTA");
    shape.getEffectFormat().getGlowEffect().getColor().setColor(color);
    shape.getEffectFormat().getGlowEffect().setRadius(15);

    presentation.save("glow_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Effet de lueur](glow_effect.png)

## **Appliquer un effet de bords doux**

Pour appliquer un effet de bords doux dans Aspose.Slides for Node.js via Java, vous pouvez créer une transition lisse et floue autour des bords d’une forme. Cet effet ajoute un aspect plus subtil et raffiné, parfait pour les conceptions nécessitant une apparence douce. Vous pouvez facilement ajuster des paramètres comme le rayon pour obtenir l’effet souhaité sur diverses formes de votre présentation.

Ce code JavaScript montre comment appliquer l’[effet de bords doux](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getSoftEdgeEffect) à une forme :

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.RoundCornerRectangle, 20, 20, 200, 150);
    shape.getEffectFormat().enableSoftEdgeEffect();
    shape.getEffectFormat().getSoftEdgeEffect().setRadius(8);

    presentation.save("soft_edges_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Effet de bords doux](soft_edges_effect.png)

## **Appliquer un effet de flou**

Utilisez le flou de forme pour adoucir le remplissage et le contour d’une forme tout en conservant la forme éditable. Appelez [setBlurEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#setBlurEffect) sur le format d’effet de la forme. Le rayon est mesuré en points (1/72 pouce) : utilisez une valeur non négative, des valeurs plus élevées produisant un flou plus fort. Un rayon de zéro laisse l’apparence inchangée.

Le paramètre [getGrow](https://reference.aspose.com/slides/nodejs-java/aspose.slides/blur/#getGrow) contrôle les limites visibles de l’effet. Avec `false`, le flou est limité aux limites peintes d’origine, y compris le contour. Avec `true`, le flou peut s’étendre au‑delà de ces limites. Aucun des deux réglages ne modifie la position ou les dimensions de la forme.

La comparaison ci‑dessous utilise le même remplissage, contour et dimensions de forme tout au long. La rangée supérieure utilise `grow = false` ; la rangée inférieure utilise `grow = true`.

![Rectangle original comparé avec des rayons de flou de 5 et 15 points, avec grow désactivé et activé](shape_blur_comparison.png)

Cet exemple JavaScript crée un rectangle orange avec un contour bleu foncé, applique un flou de 5 points, puis le met à jour avec un flou de 15 points en rappelant à nouveau [setBlurEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#setBlurEffect). Il enregistre les deux états floutés, puis appelle [disableBlurEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#disableBlurEffect) et enregistre la forme sans flou.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 80, 160, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const fillColor = java.newInstanceSync("java.awt.Color", 255, 165, 0);
    shape.getFillFormat().getSolidFillColor().setColor(fillColor);
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const lineColor = java.newInstanceSync("java.awt.Color", 0, 0, 139);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(lineColor);
    shape.getLineFormat().setWidth(8);

    shape.getEffectFormat().setBlurEffect(5, false);
    presentation.save("shape_blur_5.pptx", aspose.slides.SaveFormat.Pptx);

    shape.getEffectFormat().setBlurEffect(15, true);
    presentation.save("shape_blur_15.pptx", aspose.slides.SaveFormat.Pptx);

    shape.getEffectFormat().disableBlurEffect();
    presentation.save("shape_blur_removed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le flou de forme affecte le remplissage et le contour ensemble. Un effet de bords doux atténue les bords de la forme, tandis que le flou d’ombre adoucit uniquement l’ombre. Les effets de transformation d’image agissent sur le contenu de l’image ; cet exemple applique le flou directement au format d’effet de la forme sans convertir la forme en image.

## **FAQ**

**Puis‑je appliquer plusieurs effets à la même forme ?**

Oui, vous pouvez combiner différents effets, tels que l’ombre, la réflexion et la lueur, sur une seule forme pour créer une apparence plus dynamique.

**À quelles formes puis‑je appliquer des effets ?**

Vous pouvez appliquer des effets à diverses formes, y compris les formes automatiques, graphiques, tableaux, images, objets SmartArt, objets OLE, etc.

**Puis‑je appliquer des effets à des formes groupées ?**

Oui, vous pouvez appliquer des effets à des formes groupées. L’effet sera appliqué à l’ensemble du groupe.