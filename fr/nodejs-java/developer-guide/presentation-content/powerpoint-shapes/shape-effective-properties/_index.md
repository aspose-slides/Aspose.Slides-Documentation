---
title: Obtenir les propriétés effectives des formes à partir de présentations en JavaScript
linktitle: Propriétés effectives
type: docs
weight: 50
url: /fr/nodejs-java/shape-effective-properties/
keywords:
- propriétés de forme
- propriétés de la caméra
- système d'éclairage
- forme à biseau
- cadre de texte
- style de texte
- hauteur de police
- format de remplissage
- PowerPoint
- présentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Découvrez comment Aspose.Slides pour Node.js via Java calcule et applique les propriétés effectives des formes pour un rendu PowerPoint précis."
---
## **Aperçu**

Ce sujet explique la différence entre les propriétés **locales** et **effectives**. Les valeurs locales sont des valeurs définies directement à un niveau de formatage spécifique, tel que :

1. Les propriétés de portion sur une diapositive.  
1. Les styles de texte de forme prototype sur une diapositive de mise en page ou maître, lorsque la forme de cadre de texte de la portion en possède un.  
1. Les paramètres de texte globaux dans une présentation.

Les valeurs locales peuvent être définies ou omises à n’importe quel niveau. Lorsque Aspose.Slides a besoin du formatage final « tel qu’affiché », il résout la chaîne d’héritage et renvoie les valeurs **effectives**. Vous pouvez les obtenir en appelant la méthode `getEffective` sur l’objet de format local.

L’exemple suivant montre comment obtenir les valeurs effectives. Il suppose que la première forme de la première diapositive est une [AutoShape](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/autoshape/) avec un cadre de texte et au moins une portion.

```javascript

let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().get_Item(0);

    let localTextFrameFormat = shape.getTextFrame().getTextFrameFormat();
    let effectiveTextFrameFormat = localTextFrameFormat.getEffective();

    let paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    let localPortionFormat = paragraph.getPortions().get_Item(0).getPortionFormat();
    let effectivePortionFormat = localPortionFormat.getEffective();
} finally {
    presentation.dispose();
}
```

{{% alert color="primary" %}}

Les données de formatage effectif représentent le formatage calculé actuel après application de l’héritage. Dans l’implémentation actuelle, certains objets de données effectives peuvent être mis en cache en interne. Un appel supplémentaire à `getEffective` après modification du formatage parent ou hérité peut rafraîchir le cache, et un objet précédemment obtenu peut ne plus représenter l’état antérieur. Si vous devez conserver les valeurs effectives pour une réutilisation ultérieure, copiez les propriétés requises, telles que la hauteur de police, la couleur de remplissage, le style de police ou l’alignement, dans votre propre objet de données.

{{% /alert %}}

## **Obtenir les propriétés effectives d’une caméra**

Aspose.Slides vous permet d’obtenir les propriétés effectives d’une caméra. L’objet de données de caméra effective contient des propriétés de caméra immuables et est exposé via les valeurs effectives renvoyées pour [ThreeDFormat](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/threedformat/).

Le code suivant montre comment obtenir les propriétés effectives de la caméra. Il suppose que la première forme de la première diapositive possède un formatage 3D.

```javascript
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().get_Item(0);

    let threeDEffectiveData = shape.getThreeDFormat().getEffective();
    let camera = threeDEffectiveData.getCamera();
    let cameraType = camera.getCameraType();
    let fieldOfViewAngle = camera.getFieldOfViewAngle();
    let zoom = camera.getZoom();

    console.log("= Effective camera properties =");
    console.log("Type: " + cameraType);
    console.log("Field of view: " + fieldOfViewAngle);
    console.log("Zoom: " + zoom);
} finally {
    presentation.dispose();
}
```

## **Obtenir les propriétés effectives d’un dispositif d’éclairage**

Aspose.Slides vous permet d’obtenir les propriétés effectives d’un dispositif d’éclairage. L’objet de données d’éclairage effective contient des propriétés d’éclairage immuables et est exposé via les valeurs effectives renvoyées pour [ThreeDFormat](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/threedformat/).

Le code suivant montre comment obtenir les propriétés effectives du dispositif d’éclairage. Il suppose que la première forme de la première diapositive possède un formatage 3D.

```javascript
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().get_Item(0);

    let threeDEffectiveData = shape.getThreeDFormat().getEffective();
    let lightRig = threeDEffectiveData.getLightRig();
    let lightType = lightRig.getLightType();
    let direction = lightRig.getDirection();

    console.log("= Effective light rig properties =");
    console.log("Type: " + lightType);
    console.log("Direction: " + direction);
} finally {
    presentation.dispose();
}
```

## **Obtenir les propriétés effectives d’un biseau de forme**

Aspose.Slides vous permet d’obtenir les propriétés effectives d’un biseau de forme. L’objet de données de biseau de forme effective contient des propriétés de relief de face immuables pour une forme et est exposé via les valeurs effectives renvoyées pour [ThreeDFormat](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/threedformat/).

Le code suivant montre comment obtenir les propriétés effectives du biseau supérieur d’une forme. Il suppose que la première forme de la première diapositive possède un formatage 3D.

```javascript
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().get_Item(0);

    let threeDEffectiveData = shape.getThreeDFormat().getEffective();
    let bevelTop = threeDEffectiveData.getBevelTop();
    let bevelType = bevelTop.getBevelType();
    let bevelWidth = bevelTop.getWidth();
    let bevelHeight = bevelTop.getHeight();

    console.log("= Effective shape's top face relief properties =");
    console.log("Type: " + bevelType);
    console.log("Width: " + bevelWidth);
    console.log("Height: " + bevelHeight);
} finally {
    presentation.dispose();
}
```

## **Obtenir les propriétés effectives d’un cadre de texte**

Avec Aspose.Slides, vous pouvez obtenir les propriétés effectives d’un cadre de texte. L’objet de données retourné contient les propriétés de formatage du cadre de texte.

Le code suivant montre comment obtenir les propriétés de formatage effectif du cadre de texte. Il suppose que la première forme de la première diapositive est une [AutoShape](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/autoshape/) avec un cadre de texte.

```javascript
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().get_Item(0);

    let textFrameFormat = shape.getTextFrame().getTextFrameFormat();
    let effectiveTextFrameFormat = textFrameFormat.getEffective();
    let anchoringType = effectiveTextFrameFormat.getAnchoringType();
    let autofitType = effectiveTextFrameFormat.getAutofitType();
    let textVerticalType = effectiveTextFrameFormat.getTextVerticalType();
    let marginLeft = effectiveTextFrameFormat.getMarginLeft();
    let marginTop = effectiveTextFrameFormat.getMarginTop();
    let marginRight = effectiveTextFrameFormat.getMarginRight();
    let marginBottom = effectiveTextFrameFormat.getMarginBottom();

    console.log("Anchoring type: " + anchoringType);
    console.log("Autofit type: " + autofitType);
    console.log("Text vertical type: " + textVerticalType);
    console.log("Margins");
    console.log("   Left: " + marginLeft);
    console.log("   Top: " + marginTop);
    console.log("   Right: " + marginRight);
    console.log("   Bottom: " + marginBottom);
} finally {
    presentation.dispose();
}
```

## **Obtenir les propriétés effectives d’un style de texte**

Avec Aspose.Slides, vous pouvez obtenir les propriétés effectives d’un style de texte. L’objet de données retourné contient les propriétés du style de texte.

Le code suivant montre comment obtenir les propriétés effectives du style de texte. Il suppose que la première forme de la première diapositive est une [AutoShape](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/autoshape/) avec un cadre de texte.

```javascript
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().get_Item(0);
    let effectiveTextStyle = shape.getTextFrame().getTextFrameFormat().getTextStyle().getEffective();
    let levelCount = 9;

    for (let levelIndex = 0; levelIndex < levelCount; levelIndex++) {
        let effectiveStyleLevel = effectiveTextStyle.getLevel(levelIndex);
        let depth = effectiveStyleLevel.getDepth();
        let indent = effectiveStyleLevel.getIndent();
        let alignment = effectiveStyleLevel.getAlignment();
        let fontAlignment = effectiveStyleLevel.getFontAlignment();

        console.log("= Effective paragraph formatting for style level #" + levelIndex + " =");

        console.log("Depth: " + depth);
        console.log("Indent: " + indent);
        console.log("Alignment: " + alignment);
        console.log("Font alignment: " + fontAlignment);
    }
} finally {
    presentation.dispose();
}
```

## **Obtenir la valeur effective de la hauteur de police**

Avec Aspose.Slides, vous pouvez obtenir la hauteur de police effective. Le code suivant montre comment la hauteur de police effective d’une portion change après que des valeurs de hauteur de police locales aient été définies à différents niveaux de la structure de la présentation.

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let shapeType = aspose.slides.ShapeType.Rectangle;
    let autoShape = slide.getShapes().addAutoShape(shapeType, 100, 100, 400, 75, false);
    autoShape.addTextFrame("");

    let paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    let firstPortion = new aspose.slides.Portion("Sample text with first portion");
    let secondPortion = new aspose.slides.Portion(" and second portion.");

    paragraph.getPortions().add(firstPortion);
    paragraph.getPortions().add(secondPortion);

    let firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    let secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    let firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    let secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    console.log("Effective font height just after creation:");
    console.log("Portion #0: " + firstPortionFontHeight);
    console.log("Portion #1: " + secondPortionFontHeight);

    presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().setFontHeight(24);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    console.log("Effective font height after setting the presentation default font height:");
    console.log("Portion #0: " + firstPortionFontHeight);
    console.log("Portion #1: " + secondPortionFontHeight);

    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(40);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    console.log("Effective font height after setting paragraph default font height:");
    console.log("Portion #0: " + firstPortionFontHeight);
    console.log("Portion #1: " + secondPortionFontHeight);

    firstPortion.getPortionFormat().setFontHeight(55);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    console.log("Effective font height after setting portion #0 font height:");
    console.log("Portion #0: " + firstPortionFontHeight);
    console.log("Portion #1: " + secondPortionFontHeight);

    secondPortion.getPortionFormat().setFontHeight(18);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    console.log("Effective font height after setting portion #1 font height:");
    console.log("Portion #0: " + firstPortionFontHeight);
    console.log("Portion #1: " + secondPortionFontHeight);

    let saveFormat = aspose.slides.SaveFormat.Pptx;
    presentation.save("SetLocalFontHeightValues.pptx", saveFormat);
} finally {
    presentation.dispose();
}
```

## **Obtenir le format de remplissage effectif d’un tableau**

Avec Aspose.Slides, vous pouvez obtenir le format de remplissage effectif pour différentes parties d’un tableau. L’objet de données retourné contient les propriétés de format de remplissage. Le formatage de la cellule a une priorité supérieure à celui de la ligne, le formatage de la ligne a une priorité supérieure à celui de la colonne, et le formatage de la colonne a une priorité supérieure à celui du tableau entier.

En conséquence, les propriétés de formatage effectif de la cellule sont utilisées pour dessiner la cellule du tableau. Le code suivant montre comment obtenir le format de remplissage effectif pour différentes parties du tableau. Il suppose que la première forme de la première diapositive est un [Table](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/table/).

```javascript
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let table = slide.getShapes().get_Item(0);

    let tableFormatEffective = table.getTableFormat().getEffective();
    let rowFormatEffective = table.getRows().get_Item(0).getRowFormat().getEffective();
    let columnFormatEffective = table.getColumns().get_Item(0).getColumnFormat().getEffective();
    let cellFormatEffective = table.get_Item(0, 0).getCellFormat().getEffective();

    let tableFillFormatEffective = tableFormatEffective.getFillFormat();
    let rowFillFormatEffective = rowFormatEffective.getFillFormat();
    let columnFillFormatEffective = columnFormatEffective.getFillFormat();
    let cellFillFormatEffective = cellFormatEffective.getFillFormat();
} finally {
    presentation.dispose();
}
```

## **FAQ**

**`getEffective` renvoie‑t‑il un instantané ?**

Pas toujours. Les données effectives représentent le formatage calculé après application de l’héritage, mais certains objets de données effectives peuvent être mis en cache en interne. Un appel ultérieur à `getEffective` peut recalculer le formatage et rafraîchir le cache, de sorte qu’un objet précédemment obtenu ne doit pas être considéré comme un instantané durable.

**Quand devrais‑je relire les propriétés effectives ?**

Appelez `getEffective` à nouveau après avoir modifié le formatage local, les styles parents, le formatage de mise en page, le formatage maître ou les valeurs par défaut au niveau de la présentation. L’appel suivant réévalue la hiérarchie de formatage et renvoie le résultat effectif actuel.

**La modification ou la suppression d’une diapositive de mise en page/maître affecte‑t‑elle les propriétés effectives déjà récupérées ?**

Oui, mais le changement n’est reflété que lors du prochain appel à `getEffective`. Si une source de formatage parent est modifiée ou supprimée, les données effectives obtenues précédemment peuvent devenir obsolètes. Une fois `getEffective` appelé de nouveau, Aspose.Slides réévalue l’arbre de formatage et les polices, couleurs, tailles ou autres valeurs résultantes peuvent changer.

**Puis‑je modifier les valeurs via les objets de données effectives ?**

Non
