---
title: Obtenir les propriétés effectives des formes à partir des présentations en JavaScript
linktitle: Propriétés effectives
type: docs
weight: 50
url: /fr/nodejs-java/shape-effective-properties/
keywords:
- propriétés de forme
- propriétés de la caméra
- rig d'éclairage
- forme biseautée
- cadre de texte
- style de texte
- hauteur de police
- format de remplissage
- PowerPoint
- présentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Apprenez comment utiliser Aspose.Slides pour Node.js via Java afin de distinguer le formatage de forme local, hérité et effectif dans les présentations PowerPoint."
---
## **Comprendre les propriétés locales, héritées et effectives**

Le formatage PowerPoint peut provenir de plusieurs sources. La valeur stockée directement sur un objet est sa **valeur locale**. Si cette valeur n’est pas définie, PowerPoint examine les sources de formatage parentes, telles que le paramètre par défaut d’un paragraphe, un style de texte, une disposition ou une diapositive maître, un thème ou les valeurs par défaut au niveau de la présentation. Ces valeurs sont des **valeurs héritées**. La valeur qui subsiste après la résolution de l’ensemble de la hiérarchie est la **valeur effective** — la valeur utilisée pour rendre l’objet.

Par exemple, une portion de texte peut ne pas définir sa propre hauteur de police. Sa valeur locale [getFontHeight](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/portionformat/#getFontHeight) est alors `NaN`, ce qui signifie « non défini ici ». La portion peut hériter d’une hauteur de son paragraphe, du style de texte par défaut de la présentation ou d’une autre source applicable. L’appel de [getEffective](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/portionformat/#getEffective) sur le format de la portion renvoie la hauteur finale résolue.

Utilisez les deux types de données de formatage à des fins différentes :

- Lire ou modifier un objet de format local, tel que [PortionFormat](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/portionformat/), lorsque vous devez contrôler l’endroit où une valeur est définie.  
- Lire les [données effectives renvoyées par PortionFormat.getEffective](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/portionformat/#getEffective) lorsque vous avez besoin du résultat final rendu. Les données effectives sont en lecture seule.

Avant d’exécuter les exemples, [installez Aspose.Slides pour Node.js via Java](/slides/fr/nodejs-java/installation/).

## **Comparer les valeurs locales, héritées et effectives**

L’exemple complet suivant crée une forme et applique des hauteurs de police aux niveaux de la présentation, du paragraphe et de la portion. Chaque étape imprime les valeurs définies à ces niveaux et la valeur effective résultante pour la même portion de texte. Il montre également pourquoi les données effectives doivent être lues à nouveau après des modifications de formatage.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

function formatLocalValue(value) {
    return Number.isNaN(value) ? "<not set>" : value.toString();
}

function printFontHeights(caption, presentation, paragraph, portion) {
    const presentationValue = presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().getFontHeight();
    const paragraphValue = paragraph.getParagraphFormat().getDefaultPortionFormat().getFontHeight();
    const localValue = portion.getPortionFormat().getFontHeight();

    // Lire les données effectives après les changements précédents.
    const effectiveValue = portion.getPortionFormat().getEffective().getFontHeight();

    console.log(caption);
    console.log("  Presentation default: " + formatLocalValue(presentationValue));
    console.log("  Paragraph default:    " + formatLocalValue(paragraphValue));
    console.log("  Portion local:        " + formatLocalValue(localValue));
    console.log("  Portion effective:    " + effectiveValue);
}

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 500, 80, false);
    const textFrame = shape.addTextFrame("Effective formatting");
    const paragraph = textFrame.getParagraphs().get_Item(0);
    const portion = paragraph.getPortions().get_Item(0);

    // Définir les valeurs héritées à deux niveaux différents.
    presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().setFontHeight(20);
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(28);

    printFontHeights("The portion inherits from the paragraph", presentation, paragraph, portion);

    // Une valeur locale sur la portion remplace les deux valeurs héritées.
    portion.getPortionFormat().setFontHeight(36);
    printFontHeights("A local value overrides inherited values", presentation, paragraph, portion);

    // Modifier une valeur héritée ne remplace pas une valeur locale existante.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(30);
    printFontHeights("The local value still has priority", presentation, paragraph, portion);

    // Effacer la valeur locale. La portion hérite à nouveau du paragraphe.
    portion.getPortionFormat().setFontHeight(java.newFloat(Number.NaN));
    printFontHeights("The local value is cleared", presentation, paragraph, portion);

    // Effacer la valeur du paragraphe. La valeur par défaut de la présentation fournit maintenant le résultat.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(java.newFloat(Number.NaN));
    printFontHeights("The paragraph value is cleared", presentation, paragraph, portion);

    presentation.save("effective-properties.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

La priorité dans cet exemple est le formatage local de la portion, puis le formatage du paragraphe, puis le paramètre par défaut de la présentation. D’autres objets peuvent avoir des chaînes d’héritage différentes, mais le principe est le même : une valeur explicite plus spécifique l’emporte, et [getEffective](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/portionformat/#getEffective) renvoie le résultat final.

## **Obtenir les propriétés de texte effectives**

Le formatage du texte est réparti sur plusieurs objets :

- [TextFrameFormat.getEffective](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/textframeformat/#getEffective) résout les propriétés du cadre de texte telles que les marges, l’ancrage, l’ajustement automatique et la direction verticale du texte.  
- [TextStyle.getEffective](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/textstyle/#getEffective) résout le formatage des paragraphes pour chaque niveau de style de texte.  
- [ParagraphFormat.getEffective](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/paragraphformat/#getEffective) résout les propriétés de paragraphe telles que l’alignement, l’indentation et les puces.  
- [PortionFormat.getEffective](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/portionformat/#getEffective) résout les propriétés de caractère telles que la hauteur de police, la police, la couleur, le gras et l’italique.

Pour l’exemple suivant, le fichier `text-formatting.pptx` doit contenir au moins une diapositive et une [AutoShape](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/autoshape/) avec un cadre de texte non vide. L’AutoShape peut apparaître à n’importe quelle position dans la collection de formes ; le code recherche un objet approprié et le valide avant utilisation.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

function hasNonEmptyText(shape) {
    if (shape.getTextFrame() == null) {
        return false;
    }
    if (shape.getTextFrame().getParagraphs().getCount() === 0) {
        return false;
    }
    return shape.getTextFrame().getParagraphs().get_Item(0).getPortions().getCount() > 0;
}

function findAutoShapeWithText(slide) {
    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const candidate = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(candidate, "com.aspose.slides.AutoShape") && hasNonEmptyText(candidate)) {
            return candidate;
        }
    }
    return null;
}

const presentation = new aspose.slides.Presentation("text-formatting.pptx");
try {
    if (presentation.getSlides().size() === 0) {
        throw new Error("The presentation contains no slides.");
    }

    const shape = findAutoShapeWithText(presentation.getSlides().get_Item(0));
    if (shape == null) {
        throw new Error("The first slide must contain an AutoShape with non-empty text.");
    }

    const textFrame = shape.getTextFrame();
    const paragraph = textFrame.getParagraphs().get_Item(0);
    const portion = paragraph.getPortions().get_Item(0);

    const textFrameEffective = textFrame.getTextFrameFormat().getEffective();
    const paragraphEffective = paragraph.getParagraphFormat().getEffective();
    const portionEffective = portion.getPortionFormat().getEffective();

    console.log("Text frame margins:");
    console.log("  Left: " + textFrameEffective.getMarginLeft());
    console.log("  Top: " + textFrameEffective.getMarginTop());
    console.log("  Right: " + textFrameEffective.getMarginRight());
    console.log("  Bottom: " + textFrameEffective.getMarginBottom());
    console.log("Paragraph alignment: " + paragraphEffective.getAlignment());
    console.log("Font height: " + portionEffective.getFontHeight());
    console.log("Bold: " + portionEffective.getFontBold());

    const effectiveTextStyle = textFrame.getTextFrameFormat().getTextStyle().getEffective();
    for (let level = 0; level < 9; level++) {
        const levelEffective = effectiveTextStyle.getLevel(level);
        console.log("Level " + level + " indent: " + levelEffective.getIndent());
    }
} finally {
    presentation.dispose();
}
```

## **Obtenir les propriétés 3D effectives**

[ThreeDFormat.getEffective](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/threedformat/#getEffective) renvoie un objet de données effectives qui regroupe tous les paramètres 3D résolus. Ses méthodes [getCamera](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/threedformat/#getCamera), [getLightRig](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/threedformat/#getLightRig), [getBevelTop](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/threedformat/#getBevelTop) et [getBevelBottom](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/threedformat/#getBevelBottom) exposent les données effectives correspondantes. Lire ces paramètres liés ensemble facilite la compréhension de l’apparence 3D finale d’une forme.

Pour cet exemple, le fichier `shape-3d.pptx` doit contenir au moins une forme sur sa première diapositive. Appliquez des paramètres de caméra 3D, d’éclairage ou de biseau à cette forme si vous souhaitez que la sortie contienne des valeurs autres que les valeurs par défaut.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("shape-3d.pptx");
try {
    if (presentation.getSlides().size() === 0 || presentation.getSlides().get_Item(0).getShapes().size() === 0) {
        throw new Error("The first slide must contain a shape.");
    }

    const shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const threeDEffective = shape.getThreeDFormat().getEffective();

    console.log("Camera:");
    console.log("  Type: " + threeDEffective.getCamera().getCameraType());
    console.log("  Field of view: " + threeDEffective.getCamera().getFieldOfViewAngle());
    console.log("  Zoom: " + threeDEffective.getCamera().getZoom());

    console.log("Light rig:");
    console.log("  Type: " + threeDEffective.getLightRig().getLightType());
    console.log("  Direction: " + threeDEffective.getLightRig().getDirection());

    console.log("Top bevel:");
    console.log("  Type: " + threeDEffective.getBevelTop().getBevelType());
    console.log("  Width: " + threeDEffective.getBevelTop().getWidth());
    console.log("  Height: " + threeDEffective.getBevelTop().getHeight());
} finally {
    presentation.dispose();
}
```

## **Obtenir le formatage de tableau effectif**

Le formatage d’un tableau peut provenir du style de tableau et des formats appliqués à l’ensemble du tableau, à une colonne, à une ligne ou à une cellule individuelle. En cas de conflit entre des remplissages explicitement définis, la priorité est la cellule, la ligne, la colonne, puis l’ensemble du tableau. Le format effectif d’une cellule est le format final utilisé pour dessiner cette cellule.

Pour cet exemple, le fichier `table-formatting.pptx` doit contenir au moins un tableau sur sa première diapositive. Le tableau doit comporter au moins une ligne et une colonne. Le code recherche un [Table](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/table/) au lieu de supposer que `getShapes().get_Item(0)` est un tableau.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

function findTable(slide) {
    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.Table")) {
            return shape;
        }
    }
    return null;
}

const presentation = new aspose.slides.Presentation("table-formatting.pptx");
try {
    if (presentation.getSlides().size() === 0) {
        throw new Error("The presentation contains no slides.");
    }

    const table = findTable(presentation.getSlides().get_Item(0));
    if (table == null) {
        throw new Error("The first slide must contain a table.");
    }
    if (table.getRows().size() === 0 || table.getColumns().size() === 0) {
        throw new Error("The table must contain at least one cell.");
    }

    const tableEffective = table.getTableFormat().getEffective();
    const rowEffective = table.getRows().get_Item(0).getRowFormat().getEffective();
    const columnEffective = table.getColumns().get_Item(0).getColumnFormat().getEffective();
    const cellEffective = table.get_Item(0, 0).getCellFormat().getEffective();

    console.log("Table fill: " + tableEffective.getFillFormat().getFillType());
    console.log("Row fill: " + rowEffective.getFillFormat().getFillType());
    console.log("Column fill: " + columnEffective.getFillFormat().getFillType());
    console.log("Final cell fill: " + cellEffective.getFillFormat().getFillType());
} finally {
    presentation.dispose();
}
```

Si vous avez besoin de la couleur plutôt que seulement du type de remplissage, vérifiez d’abord le [getFillType](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/fillformat/#getFillType) effectif, puis lisez la méthode qui s’applique à ce type — par exemple, [getSolidFillColor](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/fillformat/#getSolidFillColor) pour un remplissage plein.

## **Relire les données effectives après des modifications**

Les données effectives décrivent la hiérarchie de formatage au moment où elles sont résolues. Appelez à nouveau `getEffective` après avoir modifié quoi que ce soit pouvant participer à cette hiérarchie, y compris :

- le formatage local de l’objet ;  
- les paramètres par défaut du paragraphe ou du cadre de texte ;  
- le style de tableau, le tableau, la colonne, la ligne ou le format de cellule ;  
- le formatage de la disposition ou de la diapositive maître ;  
- les données de thème ou les paramètres par défaut au niveau de la présentation ;  
- la disposition ou le maître assigné à une diapositive.

Ne conservez pas un objet de données effectives comme une capture permanente. Aspose.Slides peut mettre en cache certaines données effectives en interne, et un appel ultérieur à `getEffective` peut actualiser ces données. Si vous devez comparer les valeurs avant et après une modification, copiez les valeurs scalaires dont vous avez besoin — comme une hauteur de police, une couleur, un alignement ou une largeur de biseau — dans vos propres variables avant d’effectuer la modification.

Pour modifier une valeur, mettez à jour l’objet de format local approprié puis appelez `getEffective` pour vérifier le résultat. Les objets de données effectives eux‑mêmes sont en lecture seule.

## **FAQ**

**Comment savoir quel niveau a fourni une valeur effective ?**

Les données effectives contiennent la valeur finale, pas sa source. Examinez les objets locaux applicables du niveau le plus spécifique vers l’extérieur. Pour le texte, cela peut inclure la portion, le paragraphe, le cadre de texte, la disposition, le maître, le thème et les paramètres par défaut de la présentation. Les valeurs non définies comme `NaN` ou `null` indiquent que la recherche se poursuit à un autre niveau.

**Que se passe‑t‑il lorsqu’aucun niveau ne définit une propriété ?**

Aspose.Slides résout le défaut approprié de PowerPoint ou de la bibliothèque. Cette valeur résolue apparaît dans les données effectives même si aucun objet local ne la définit explicitement.

**Pourquoi une valeur effective est‑elle parfois égale à la valeur locale ?**

La valeur locale a remporté le calcul d’héritage. Cela est attendu lorsque la propriété est explicitement définie sur l’objet et qu’aucune règle plus spécifique ne la remplace.

**Quand dois‑je utiliser les données locales au lieu des données effectives ?**

Utilisez les données locales pour inspecter ou modifier un niveau de formatage spécifique. Utilisez les données effectives lorsque vous avez besoin de l’apparence finale après l’héritage, les règles de thème et les styles applicables ont été résolus. L’[exemple complet de comparaison](#compare-local-inherited-and-effective-values) montre les deux dans le même flux de travail.