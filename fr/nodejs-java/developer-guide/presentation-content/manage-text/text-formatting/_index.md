---
title: Formatage du texte de présentation en JavaScript
linktitle: Mise en forme du texte
type: docs
weight: 50
url: /fr/nodejs-java/text-formatting/
keywords:
- aligner le paragraphe
- style de texte
- arrière-plan du texte
- transparence du texte
- espacement des caractères
- propriétés de police
- famille de police
- rotation du texte
- angle de rotation
- cadre de texte
- interligne
- propriété d'ajustement automatique
- ancre du cadre de texte
- tabulation du texte
- langue par défaut
- PowerPoint
- OpenDocument
- présentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Formatez et stylisez le texte des présentations PowerPoint et OpenDocument à l'aide d'Aspose.Slides pour Node.js via Java. Personnalisez les polices, les couleurs, l'alignement et plus encore."
---
## **Vue d'ensemble**

Cet article montre comment formater du texte dans les présentations PowerPoint et OpenDocument en utilisant Aspose.Slides pour Node.js via Java. Il couvre les couleurs d'arrière-plan, la transparence, l'espacement des caractères, les propriétés de police, la rotation, l'espacement des paragraphes, le comportement d'ajustement automatique, l'ancrage du texte, les tabulations et les paramètres de langue.

Dans les exemples ci‑dessous, nous utiliserons un fichier nommé **sample.pptx**, qui contient une seule zone de texte sur la première diapositive avec le texte suivant :

![Texte d'exemple](sample_text.png)

Pour rechercher et mettre en évidence du texte littéral ou des correspondances d'expressions régulières, voir [Rechercher et remplacer du texte](/slides/fr/nodejs-java/search-and-replace-text/).

## **Définir la couleur d'arrière-plan du texte**

Utilisez [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/paragraphformat/#getDefaultPortionFormat--) pour définir la couleur de surbrillance par défaut d'un paragraphe, ou utilisez [BasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/baseportionformat/#getHighlightColor--) pour des portions de texte individuelles.

L'exemple de code suivant montre comment définir la couleur d'arrière-plan pour le **paragraphe entier** :

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Définir la couleur de surbrillance pour le paragraphe entier.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));

    presentation.save("gray_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le résultat :

![Le paragraphe gris](gray_paragraph.png)

L'exemple de code ci‑dessous montre comment définir la couleur d'arrière-plan pour les **portions de texte en gras** :

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const portions = paragraph.getPortions();
    const portionCount = portions.getCount();

    for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
        const portion = portions.get_Item(portionIndex);
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Définir la couleur de surbrillance pour la portion de texte.
            portion.getPortionFormat().getHighlightColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));
        }
    }

    presentation.save("gray_text_portions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le résultat :

![Les portions de texte gris](gray_text_portions.png)

## **Aligner les paragraphes de texte**

Utilisez [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) pour définir l'alignement des paragraphes dans un cadre de texte. La valeur peut être centrée, alignée à gauche, à droite, justifiée, etc.

L'exemple de code suivant montre comment aligner le paragraphe au **centre** :

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Définir l'alignement du paragraphe au centre.
    paragraph.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Center);

    presentation.save("aligned_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le résultat :

![Le paragraphe aligné](aligned_paragraph.png)

## **Définir la transparence du texte**

La transparence du texte est contrôlée via le composant alpha de la couleur assignée à [BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/baseportionformat/#getFillFormat--). Dans les exemples ci‑dessous, `alpha = 50` est une valeur de canal alpha ARGB sur l'échelle 0–255, et non un pourcentage de transparence.

L'exemple de code suivant montre comment appliquer la transparence au **paragraphe entier** :

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const alpha = 50;
const transparentBlack = java.newInstanceSync("java.awt.Color", 0, 0, 0, alpha);
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const fillFormat = paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat();

    // Définir la couleur de remplissage du texte à une couleur transparente.
    fillFormat.setFillType(java.newByte(aspose.slides.FillType.Solid));
    fillFormat.getSolidFillColor().setColor(transparentBlack);

    presentation.save("transparent_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le résultat :

![Le paragraphe transparent](transparent_paragraph.png)

L'exemple de code suivant montre comment appliquer la transparence aux **portions de texte en gras** :

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const alpha = 50;
const transparentBlack = java.newInstanceSync("java.awt.Color", 0, 0, 0, alpha);
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const portions = paragraph.getPortions();
    const portionCount = portions.getCount();

    for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
        const portion = portions.get_Item(portionIndex);
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            const fillFormat = portion.getPortionFormat().getFillFormat();

            // Définir la transparence de la portion de texte.
            fillFormat.setFillType(java.newByte(aspose.slides.FillType.Solid));
            fillFormat.getSolidFillColor().setColor(transparentBlack);
        }
    }

    presentation.save("transparent_text_portions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le résultat :

![Les portions de texte transparentes](transparent_text_portions.png)

## **Définir l'espacement des caractères du texte**

Utilisez [BasePortionFormat.setSpacing](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/baseportionformat/#setSpacing-float-) pour élargir ou réduire l'espacement entre les caractères dans une zone de texte.

Le code JavaScript suivant montre comment élargir l'espacement des caractères dans le **paragraphe entier** :

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Note : Utilisez des valeurs négatives pour compresser l'espacement des caractères.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3); // Élargir l'espacement des caractères.

    presentation.save("character_spacing_in_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le résultat :

![L'espacement des caractères dans le paragraphe](character_spacing_in_paragraph.png)

L'exemple de code ci‑dessous montre comment élargir l'espacement des caractères dans les **portions de texte en gras** :

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const portions = paragraph.getPortions();
    const portionCount = portions.getCount();

    for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
        const portion = portions.get_Item(portionIndex);
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Note: Utilisez des valeurs négatives pour compresser l'espacement des caractères.
            portion.getPortionFormat().setSpacing(3); // Élargir l'espacement des caractères.
        }
    }

    presentation.save("character_spacing_in_text_portions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le résultat :

![L'espacement des caractères dans les portions de texte](character_spacing_in_text_portions.png)

### **Désactiver le crénage pour des polices spécifiques**

Dans certains cas, le texte rendu par Aspose.Slides peut sembler légèrement plus serré que le même texte affiché dans PowerPoint. Cela peut se produire parce que PowerPoint peut ignorer les données de crénage pour certaines polices, même lorsque la police contient des informations de crénage valides et que le crénage est activé dans les paramètres de PowerPoint.

Pour rendre le rendu plus proche de PowerPoint dans ces cas, vous pouvez désactiver le crénage pour les portions de texte qui utilisent la police concernée. Définissez [BasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/baseportionformat/#setKerningMinimalSize-float-) à une valeur nettement supérieure à la taille réelle de la police :

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const autoShape = slide.getShapes().get_Item(0);
    const paragraphs = autoShape.getTextFrame().getParagraphs();
    const paragraphCount = paragraphs.getCount();
    const targetFont = "Roboto";

    for (let paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
        const portions = paragraphs.get_Item(paragraphIndex).getPortions();
        const portionCount = portions.getCount();

        for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
            const portion = portions.get_Item(portionIndex);
            const portionFormat = portion.getPortionFormat();
            const latinFont = portionFormat.getLatinFont();
            const eastAsianFont = portionFormat.getEastAsianFont();
            const complexScriptFont = portionFormat.getComplexScriptFont();

            if ((latinFont !== null && latinFont.getFontName() === targetFont) ||
                (eastAsianFont !== null && eastAsianFont.getFontName() === targetFont) ||
                (complexScriptFont !== null && complexScriptFont.getFontName() === targetFont)) {
                portionFormat.setKerningMinimalSize(100);
            }
        }
    }

    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Ce réglage empêche l'application du crénage aux portions de texte correspondantes et peut aider à aligner le rendu d'Aspose.Slides avec la sortie visuelle de PowerPoint pour les polices affectées par ce comportement propre à PowerPoint.

## **Gérer les propriétés de police du texte**

Les propriétés de police peuvent être définies au niveau du paragraphe via [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/paragraphformat/#getDefaultPortionFormat--) ou sur des portions individuelles via [PortionFormat](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/portionformat/).

Le code suivant définit la police et le style de texte pour tout le paragraphe : il applique la taille de police, le gras, l'italique, le soulignement pointillé et la police Times New Roman à toutes les portions du paragraphe.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const defaultPortionFormat = paragraph.getParagraphFormat().getDefaultPortionFormat();

    // Définir les propriétés de police pour le paragraphe.
    defaultPortionFormat.setFontHeight(12);
    defaultPortionFormat.setFontBold(java.newByte(aspose.slides.NullableBool.True));
    defaultPortionFormat.setFontItalic(java.newByte(aspose.slides.NullableBool.True));
    defaultPortionFormat.setFontUnderline(java.newByte(aspose.slides.TextUnderlineType.Dotted));
    defaultPortionFormat.setLatinFont(new aspose.slides.FontData("Times New Roman"));

    presentation.save("font_properties_for_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le résultat :

![Les propriétés de police du paragraphe](font_properties_for_paragraph.png)

L'exemple de code ci‑dessous applique des propriétés similaires aux **portions de texte en gras** :

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const portions = paragraph.getPortions();
    const portionCount = portions.getCount();

    for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
        const portion = portions.get_Item(portionIndex);
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            const portionFormat = portion.getPortionFormat();

            // Définir les propriétés de police pour la portion de texte.
            portionFormat.setFontHeight(13);
            portionFormat.setFontItalic(java.newByte(aspose.slides.NullableBool.True));
            portionFormat.setFontUnderline(java.newByte(aspose.slides.TextUnderlineType.Dotted));
            portionFormat.setLatinFont(new aspose.slides.FontData("Times New Roman"));
        }
    }

    presentation.save("font_properties_for_text_portions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le résultat :

![Les propriétés de police des portions de texte](font_properties_for_text_portions.png)

## **Définir la rotation du texte**

Utilisez [TextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-) pour définir une orientation de texte prédéfinie à l'intérieur d'une forme.

L'exemple de code suivant définit l'orientation du texte dans la forme sur `Vertical270`, ce qui fait pivoter le texte de **90 degrés dans le sens antihoraire** :

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const autoShape = slide.getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setTextVerticalType(java.newByte(aspose.slides.TextVerticalType.Vertical270));

    presentation.save("text_rotation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le résultat :

![La rotation du texte](text_rotation.png)

## **Définir une rotation personnalisée pour les cadres de texte**

Utilisez [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/textframeformat/#setRotationAngle-float-) pour définir un angle de rotation personnalisé pour un [TextFrame](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/textframe/).

L'exemple de code ci‑dessus fait pivoter le cadre de texte de 3 degrés dans le sens horaire à l'intérieur de la forme :

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const autoShape = slide.getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setRotationAngle(3);

    presentation.save("custom_text_rotation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le résultat :

![La rotation personnalisée du texte](custom_text_rotation.png)

## **Définir l'espacement des lignes des paragraphes**

Aspose.Slides fournit [ParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/paragraphformat/#setSpaceAfter-float-), [ParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/paragraphformat/#setSpaceBefore-float-) et [ParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/paragraphformat/#setSpaceWithin-float-) pour contrôler l'espacement des paragraphes. Ces propriétés s'utilisent comme suit :

* Utilisez une valeur positive pour spécifier l'interligne en pourcentage de la hauteur de ligne.
* Utilisez une valeur négative pour spécifier l'interligne en points.

L'exemple de code suivant montre comment spécifier l'interligne à l'intérieur du paragraphe :

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    paragraph.getParagraphFormat().setSpaceWithin(200);

    presentation.save("line_spacing.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le résultat :

![L'interligne dans le paragraphe](line_spacing.png)

## **Définir le type d'ajustement automatique pour les cadres de texte**

[TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/textframeformat/#setAutofitType-byte-) détermine comment le texte se comporte lorsqu'il dépasse les limites de son conteneur. Utilisez‑le pour contrôler si le texte se rétrécit, déborde ou redimensionne automatiquement la forme.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const autoShape = slide.getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.Shape));

    presentation.save("autofit_type.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Définir l'ancre des cadres de texte**

[TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/textframeformat/#setAnchoringType-byte-) définit la façon dont le texte est positionné verticalement à l'intérieur d'une forme, par exemple en haut, au milieu ou en bas.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const autoShape = slide.getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setAnchoringType(java.newByte(aspose.slides.TextAnchorType.Bottom));

    presentation.save("text_anchor.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Définir la tabulation du texte**

Utilisez [ParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/paragraphformat/#setDefaultTabSize-float-) et [ParagraphFormat.getTabs](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/paragraphformat/#getTabs--) pour configurer les tabulations dans un paragraphe.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    paragraph.getParagraphFormat().setDefaultTabSize(100);
    paragraph.getParagraphFormat().getTabs().add(30, java.newByte(aspose.slides.TabAlignment.Left));

    presentation.save("paragraph_tabs.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le résultat :

![Les tabulations du paragraphe](paragraph_tabs.png)

## **Définir la langue de vérification**

Aspose.Slides fournit [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-), qui permet de définir la langue de vérification pour une portion de texte. La langue de vérification détermine la langue utilisée pour les vérifications orthographiques et grammaticales dans PowerPoint.

L'exemple de code suivant montre comment définir la langue de vérification pour une portion de texte :

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    const font = new aspose.slides.FontData("SimSun");
    const textPortion = new aspose.slides.Portion();
    textPortion.getPortionFormat().setComplexScriptFont(font);
    textPortion.getPortionFormat().setEastAsianFont(font);
    textPortion.getPortionFormat().setLatinFont(font);

    // Définir l'Id d'une langue de vérification.
    textPortion.getPortionFormat().setLanguageId("zh-CN");

    textPortion.setText("1。");
    paragraph.getPortions().add(textPortion);

    presentation.save("proofing_language.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Définir la langue par défaut**

Utilisez [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) pour définir la langue par défaut du texte créé lors du chargement ou de la création d'une présentation.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

const presentation = new aspose.slides.Presentation(loadOptions);
try {
    const slide = presentation.getSlides().get_Item(0);

    // Ajouter une nouvelle forme rectangulaire avec du texte.
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 150, 50);
    shape.getTextFrame().setText("Sample text");

    // Vérifier la langue de la première portion.
    const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    console.log(portion.getPortionFormat().getLanguageId());
} finally {
    presentation.dispose();
}
```

## **Définir le style de texte par défaut**

Pour appliquer un formatage de texte par défaut au niveau de la présentation, utilisez [Presentation.getDefaultTextStyle](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/#getDefaultTextStyle--).

L'exemple de code suivant montre comment définir une police en gras de 14 pt par défaut pour tout le texte de toutes les diapositives d'une nouvelle présentation.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    // Récupérer le format de paragraphe de niveau supérieur.
    const paragraphFormat = presentation.getDefaultTextStyle().getLevel(0);

    if (paragraphFormat !== null) {
        paragraphFormat.getDefaultPortionFormat().setFontHeight(14);
        paragraphFormat.getDefaultPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));
    }

    presentation.save("default_text_style.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Extraire le texte avec l'effet Tout en majuscules**

Dans PowerPoint, appliquer l'effet de police **Tout en majuscules** fait apparaître le texte en majuscules sur la diapositive même s'il a été saisi en minuscules. Lors de la récupération d’une telle portion de texte avec Aspose.Slides, la bibliothèque renvoie le texte exactement tel qu’il a été saisi. Pour correspondre au texte affiché, vérifiez [TextCapType](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/textcaptype/) et convertissez la chaîne renvoyée en majuscules lorsque la valeur est `All`.

Supposons que nous ayons la zone de texte suivante sur la première diapositive du fichier sample2.pptx.

![L'effet Tout en majuscules](all_caps_effect.png)

L'exemple de code ci‑dessus montre comment extraire le texte avec l'effet **Tout en majuscules** appliqué :

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("sample2.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const autoShape = slide.getShapes().get_Item(0);
    const textPortion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);

    console.log("Original text: " + textPortion.getText());

    const textFormat = textPortion.getPortionFormat().getEffective();
    if (textFormat.getTextCapType() === aspose.slides.TextCapType.All) {
        const text = textPortion.getText().toUpperCase();
        console.log("All-Caps effect: " + text);
    }
} finally {
    presentation.dispose();
}
```

Sortie :

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **FAQ**

**Comment modifier le texte dans un tableau sur une diapositive ?**

Pour modifier le texte dans un tableau sur une diapositive, utilisez [Table](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/table/). Parcourez les cellules et mettez à jour chaque cellule via [Cell.getTextFrame](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/cell/#getTextFrame--) et le formatage des paragraphes via [Paragraph.getParagraphFormat](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/paragraph/#getParagraphFormat--).

**Comment appliquer une couleur dégradée au texte dans une diapositive PowerPoint ?**

Pour appliquer une couleur dégradée au texte, utilisez [BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/baseportionformat/#getFillFormat--). Définissez [FillFormat.setFillType](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/fillformat/#setFillType-byte-) sur [FillType.Gradient](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/filltype/) et configurez les arrêts du dégradé, la direction et la transparence.