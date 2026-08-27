---
title: Recherche et remplacement du texte dans les présentations PowerPoint en JavaScript
linktitle: Recherche et remplacement du texte
type: docs
weight: 55
url: /fr/nodejs-java/search-and-replace-text/
keywords:
- recherche de texte
- mise en surbrillance de texte
- remplacement de texte
- expression régulière
- rappel de résultat
- cadre de texte
- rapport d'audit
- PowerPoint
- OpenDocument
- présentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Recherchez, mettez en surbrillance et remplacez du texte dans les présentations PowerPoint tout en collectant chaque correspondance avec Aspose.Slides pour Node.js via Java."
---
## **Vue d'ensemble**

Aspose.Slides pour Node.js via Java peut rechercher, mettre en surbrillance et remplacer du texte dans un cadre de texte individuel ou dans l'ensemble d'une présentation. Chaque opération peut également informer une application de chaque correspondance via un rappel de résultat. Cela permet de mettre à jour une présentation et de créer simultanément une piste d’audit contenant le texte correspondant, son contexte, sa position, le cadre de texte et le numéro de diapositive.

Ces fonctionnalités sont utiles pour la révision, la rédaction, la vérification de la terminologie, le nettoyage de modèles et les flux de travail de génération de rapports automatisés.

Dans les premiers exemples ci‑dessus, nous utilisons un fichier nommé "sample.pptx", qui contient une seule zone de texte sur la première diapositive avec le texte suivant :

![Texte d'exemple](sample_text.png)

## **Choisir la portée de la recherche**

Utilisez les méthodes de [TextFrame](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/textframe/) pour limiter une opération à un seul cadre de texte. Utilisez les méthodes de [Presentation](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/) pour traiter tout le texte applicable dans la présentation.

| Opération | Un cadre de texte | Présentation entière |
|---|---|---|
| Mettre en surbrillance le texte littéral | [TextFrame.highlightText](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/textframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [Presentation.highlightText](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Mettre en surbrillance les correspondances d'expression régulière | [TextFrame.highlightRegex](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/textframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) | [Presentation.highlightRegex](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) |
| Remplacer le texte littéral | [TextFrame.replaceText](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [Presentation.replaceText](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Remplacer les correspondances d'expression régulière | [TextFrame.replaceRegex](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) | [Presentation.replaceRegex](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) |

## **Configurer la correspondance de texte**

Pour les opérations de texte littéral, utilisez [TextSearchOptions](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/textsearchoptions/) pour contrôler la correspondance :

- [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) limite les correspondances aux mots complets.
- [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) contrôle si la casse des caractères doit correspondre.
- [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) inclut les notes de diapositive dans les opérations de recherche, de remplacement et de mise en surbrillance au niveau de la présentation.

Les opérations d'expression régulière utilisent un `Pattern` Java, de sorte que les règles de correspondance telles que la sensibilité à la casse et les limites de mots sont définies par l'expression et ses indicateurs.

## **Identifier le propriétaire d'un cadre de texte**

Les flux de travail génériques de traitement de texte reçoivent souvent un [TextFrame](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/textframe/) lors de la recherche, du remplacement, de la validation ou de l'exportation de texte. Utilisez [TextFrame.getParentShape](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/textframe/#getParentShape--) et [TextFrame.getParentCell](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/textframe/#getParentCell--) pour déterminer quel objet de présentation possède le cadre de texte.

Les valeurs attendues dépendent du propriétaire :

| Propriétaire du cadre de texte | getParentShape | getParentCell |
|---|---|---|
| Une AutoShape ou une autre forme contenant du texte | Le [Shape](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/shape/) propriétaire | `null` |
| Une cellule de tableau | `null` | Le [Cell](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/cell/) propriétaire |

Les deux méthodes offrent une navigation en lecture seule. Les appeler ne déplace pas le cadre de texte ni ne change son propriétaire. Le code générique doit vérifier les deux valeurs pour `null` et gérer la possibilité qu'aucun propriétaire ne soit disponible.

L'exemple suivant utilise [SlideUtil.getAllTextFrames](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/slideutil/#getAllTextFrames-aspose.slides.IPresentation-boolean-) pour parcourir les cadres de texte d'une présentation. Pour les formes, il indique le nom de la forme, le type d'exécution Java et la diapositive contenant. Pour les cellules de tableau, il indique les coordonnées de colonne et de ligne basées sur zéro ainsi que la diapositive contenant.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

function getSlideLabel(baseSlide) {
    if (java.instanceOf(baseSlide, "com.aspose.slides.Slide")) {
        return "slide " + baseSlide.getSlideNumber();
    }

    if (java.instanceOf(baseSlide, "com.aspose.slides.NotesSlide")) {
        return "notes for slide " + baseSlide.getParentSlide().getSlideNumber();
    }

    return baseSlide.getClass().getSimpleName();
}

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const textFrames = aspose.slides.SlideUtil.getAllTextFrames(presentation, false);

    for (let index = 0; index < textFrames.length; index++) {
        const textFrame = textFrames[index];
        const ownerShape = textFrame.getParentShape();
        if (ownerShape !== null) {
            const shapeName = ownerShape.getName() === "" ? "(unnamed)" : ownerShape.getName();
            const shapeType = ownerShape.getClass().getSimpleName();
            const slideLabel = getSlideLabel(ownerShape.getSlide());
            console.log("Shape: " + shapeName + "; type: " + shapeType + "; " + slideLabel);
            continue;
        }

        const ownerCell = textFrame.getParentCell();
        if (ownerCell !== null) {
            const slideLabel = getSlideLabel(ownerCell.getSlide());
            console.log("Table cell: column " + ownerCell.getFirstColumnIndex() + ", row " + ownerCell.getFirstRowIndex() + "; " + slideLabel);
            continue;
        }

        console.log("The text frame owner is not available as a shape or table cell.");
    }
} finally {
    presentation.dispose();
}
```

Pour le contenu SmartArt, parcourez les formes dans [SmartArtNode.getShapes](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/smartartnode/#getShapes--) et accédez à chaque [SmartArtShape.getTextFrame](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/smartartshape/#getTextFrame--). Le cadre de texte peut être retracé à sa forme associée via [TextFrame.getParentShape](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/textframe/#getParentShape--), tandis que [TextFrame.getParentCell](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/textframe/#getParentCell--) renvoie `null`. Ainsi, la branche de forme dans l'exemple gère également le texte des nœuds SmartArt.

## **Collecter les informations de correspondance avec un rappel**

Créez un proxy Java pour le rappel de résultat afin de recevoir une notification pour chaque correspondance. La fonction proxy reçoit le cadre de texte concerné, le texte source, le texte correspondant et la position de la correspondance.

Le rappel ne reçoit pas directement le numéro de la diapositive. L'implémentation ci‑dessus le déduit via la forme ou la cellule de tableau propriétaire du cadre de texte, avec [TextFrame.getSlide](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/textframe/#getSlide--) comme solution de repli. Il gère également le texte trouvé dans les notes de diapositive.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

function getSlideNumber(textFrame) {
    const parentShape = textFrame.getParentShape();
    const parentCell = textFrame.getParentCell();
    let parentSlide = textFrame.getSlide();
    if (parentShape !== null) {
        parentSlide = parentShape.getSlide();
    } else if (parentCell !== null) {
        parentSlide = parentCell.getSlide();
    }

    if (java.instanceOf(parentSlide, "com.aspose.slides.Slide")) {
        return parentSlide.getSlideNumber();
    }

    if (java.instanceOf(parentSlide, "com.aspose.slides.NotesSlide")) {
        return parentSlide.getParentSlide().getSlideNumber();
    }

    return null;
}

function createTextSearchCallback(results) {
    return java.newProxy("com.aspose.slides.IFindResultCallback", {
        foundResult: function(textFrame, sourceText, foundText, textPosition) {
            results.push({
                textFrame: textFrame,
                sourceText: sourceText,
                foundText: foundText,
                textPosition: textPosition,
                slideNumber: getSlideNumber(textFrame)
            });
        }
    });
}
```

Pour les opérations de remplacement, `foundText` contient le texte correspondant original, de sorte que le rappel peut enregistrer exactement quels termes ont été remplacés.

## **Mettre en surbrillance le texte**

Utilisez la méthode [TextFrame.highlightText](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/textframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) pour mettre en surbrillance les correspondances de texte littéral dans un cadre de texte. Passez [TextSearchOptions](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/textsearchoptions/) pour contrôler la recherche.

L'exemple de code ci‑dessus met en surbrillance toutes les occurrences des caractères **"try"** puis ne met en surbrillance que le mot complet **"to"**.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().get_Item(0);

    const substringSearchOptions = new aspose.slides.TextSearchOptions();
    substringSearchOptions.setCaseSensitive(false);
    const substringHighlightColor = java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY");

    // Mettre en évidence chaque occurrence de "try" dans le cadre de texte.
    shape.getTextFrame().highlightText(
        "try", substringHighlightColor, substringSearchOptions, null);

    const wholeWordSearchOptions = new aspose.slides.TextSearchOptions();
    wholeWordSearchOptions.setWholeWordsOnly(true);
    wholeWordSearchOptions.setCaseSensitive(false);
    const wholeWordHighlightColor = java.getStaticFieldValue("java.awt.Color", "MAGENTA");

    // Mettre en évidence uniquement le mot complet "to".
    shape.getTextFrame().highlightText(
        "to", wholeWordHighlightColor, wholeWordSearchOptions, null);

    presentation.save("highlighted_text.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le résultat :

![Le texte mis en surbrillance](highlighted_text.png)

## **Mettre en surbrillance le texte à l'aide d'expressions régulières**

La méthode [TextFrame.highlightRegex](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/textframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) met en surbrillance les correspondances de texte trouvées par une expression régulière dans un cadre de texte.

Le code suivant met en surbrillance tous les mots contenant sept caractères ou plus :

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const Pattern = java.import("java.util.regex.Pattern");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().get_Item(0);
    const regex = Pattern.compile("\\b[^\\s]{7,}\\b");
    const highlightColor = java.getStaticFieldValue("java.awt.Color", "YELLOW");

    shape.getTextFrame().highlightRegex(regex, highlightColor, null);

    presentation.save(
        "highlighted_text_using_regex.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le résultat :

![Le texte mis en surbrillance à l'aide de l'expression régulière](highlighted_text_using_regex.png)

## **Mettre en surbrillance le texte dans toute une présentation**

Utilisez [Presentation.highlightText](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) et [Presentation.highlightRegex](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) pour rechercher tous les cadres de texte applicables dans une présentation. L'exemple suivant met en surbrillance un terme littéral et toutes les adresses e‑mail :

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const Pattern = java.import("java.util.regex.Pattern");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const searchOptions = new aspose.slides.TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);
    searchOptions.setCaseSensitive(false);
    const termHighlightColor = java.getStaticFieldValue("java.awt.Color", "ORANGE");

    presentation.highlightText(
        "confidential", termHighlightColor, searchOptions, null);

    const emailRegex = Pattern.compile(
        "\\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\\.[A-Z]{2,}\\b",
        Pattern.CASE_INSENSITIVE);
    const emailHighlightColor = java.getStaticFieldValue("java.awt.Color", "YELLOW");

    presentation.highlightRegex(emailRegex, emailHighlightColor, null);
    presentation.save("highlighted_presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Remplacer le texte dans un cadre de texte**

Utilisez [TextFrame.replaceText](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) pour le texte littéral et [TextFrame.replaceRegex](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) pour le remplacement basé sur un modèle. Ces méthodes mettent à jour le texte correspondant au sein du cadre de texte existant, qui conserve la mise en forme des portions environnantes au lieu de reconstruire le cadre de texte à partir d'une chaîne brute.

L'exemple suivant normalise une variante orthographique puis remplace les libellés de version :

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const Pattern = java.import("java.util.regex.Pattern");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().get_Item(0);
    const searchOptions = new aspose.slides.TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);
    searchOptions.setCaseSensitive(false);

    shape.getTextFrame().replaceText(
        "colour", "color", searchOptions, null);

    const versionRegex = Pattern.compile(
        "\\bv\\d+(?:\\.\\d+)*\\b", Pattern.CASE_INSENSITIVE);
    shape.getTextFrame().replaceRegex(versionRegex, "current version", null);

    presentation.save("updated_text_frame.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Si une correspondance couvre des portions avec une mise en forme différente, examinez le résultat pour confirmer quelle mise en forme doit s'appliquer au texte de remplacement.

## **Remplacer le texte dans toute une présentation**

Utilisez [Presentation.replaceText](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) et [Presentation.replaceRegex](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) pour appliquer les mêmes opérations à l'ensemble de la présentation. Ceci est utile pour le nettoyage de modèles, les mises à jour de terminologie et la rédaction.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const Pattern = java.import("java.util.regex.Pattern");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const searchOptions = new aspose.slides.TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);
    searchOptions.setCaseSensitive(true);

    presentation.replaceText(
        "Contoso", "Example Corp", searchOptions, null);

    const accountNumberRegex = Pattern.compile("\\bACCT-\\d{6}\\b");
    presentation.replaceRegex(accountNumberRegex, "ACCT-REDACTED", null);

    presentation.save("updated_presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Regrouper les correspondances pour le reporting**

Étant donné que chaque résultat collecté conserve le numéro de diapositive et le cadre de texte, les applications peuvent regrouper les correspondances pour des flux de travail d'audit, de reporting ou de révision. L'exemple suivant regroupe les résultats d'abord par diapositive, puis par cadre de texte :

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

function getSlideNumber(textFrame) {
    const parentShape = textFrame.getParentShape();
    const parentCell = textFrame.getParentCell();
    let parentSlide = textFrame.getSlide();
    if (parentShape !== null) {
        parentSlide = parentShape.getSlide();
    } else if (parentCell !== null) {
        parentSlide = parentCell.getSlide();
    }

    if (java.instanceOf(parentSlide, "com.aspose.slides.Slide")) {
        return parentSlide.getSlideNumber();
    }

    if (java.instanceOf(parentSlide, "com.aspose.slides.NotesSlide")) {
        return parentSlide.getParentSlide().getSlideNumber();
    }

    return null;
}

const results = [];
const callback = java.newProxy("com.aspose.slides.IFindResultCallback", {
    foundResult: function(textFrame, sourceText, foundText, textPosition) {
        results.push({
            textFrame: textFrame,
            sourceText: sourceText,
            foundText: foundText,
            textPosition: textPosition,
            slideNumber: getSlideNumber(textFrame)
        });
    }
});

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const searchOptions = new aspose.slides.TextSearchOptions();
    searchOptions.setCaseSensitive(false);
    const highlightColor = java.getStaticFieldValue("java.awt.Color", "YELLOW");

    presentation.highlightText(
        "confidential", highlightColor, searchOptions, callback);

    const matchesBySlide = new Map();

    for (const result of results) {
        const slideLabel = result.slideNumber === null ? "Other" : result.slideNumber;

        if (!matchesBySlide.has(slideLabel)) {
            matchesBySlide.set(slideLabel, new Map());
        }

        const matchesByTextFrame = matchesBySlide.get(slideLabel);
        if (!matchesByTextFrame.has(result.textFrame)) {
            matchesByTextFrame.set(result.textFrame, []);
        }

        matchesByTextFrame.get(result.textFrame).push(result);
    }

    for (const [slideLabel, matchesByTextFrame] of matchesBySlide) {
        console.log("Slide: " + slideLabel);

        for (const [textFrame, textFrameMatches] of matchesByTextFrame) {
            console.log("  Text frame: " + textFrame.getText());

            for (const result of textFrameMatches) {
                console.log(
                    "    '" + result.foundText + "' at position " +
                    result.textPosition + "; context: '" + result.sourceText + "'");
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Comment puis‑je rechercher uniquement une zone de texte au lieu de l'ensemble de la présentation ?**

Obtenez le cadre de texte de la forme et appelez [TextFrame.highlightText](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/textframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), [TextFrame.highlightRegex](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/textframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-), [TextFrame.replaceText](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), ou [TextFrame.replaceRegex](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) sur ce cadre de texte. Les méthodes au niveau de la présentation traitent tous les cadres de texte applicables à la place.

**Comment puis‑je correspondre à des mots complets avec la casse correcte ?**

Définissez [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) et [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) sur `true`, et transmettez les options à une méthode de mise en surbrillance ou de remplacement de texte littéral. Pour les expressions régulières, définissez les limites de mots et la sensibilité à la casse directement dans le `Pattern` Java.

**La recherche et le remplacement peuvent‑ils inclure le texte des notes de diapositive ?**

Oui. Définissez [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) sur `true` lors de l'utilisation d'une opération de texte littéral au niveau de la présentation. L'implémentation du rappel présentée ci‑dessus mappe une correspondance dans une diapositive de notes à son numéro de diapositive parent.

**Comment créer un rapport sans analyser la présentation une seconde fois ?**

Passez un proxy Java de rappel de résultat à l'opération de mise en surbrillance ou de remplacement. Le rappel reçoit chaque correspondance pendant l'exécution de l'opération, de sorte que l'application puisse stocker le texte source, le texte correspondant, la position, le cadre de texte et le numéro de diapositive dérivé pour un regroupement ou une exportation ultérieure.

**Le remplacement du texte préserve‑t‑il sa mise en forme ?**

[TextFrame.replaceText](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) et [TextFrame.replaceRegex](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) modifient le texte correspondant au sein du cadre de texte existant et conservent la mise en forme des portions environnantes. Si une correspondance couvre des portions avec une mise en forme différente, examinez le résultat pour vous assurer que le remplacement utilise le style souhaité.