---
title: Recherche et remplacement de texte dans les présentations PowerPoint en JavaScript
linktitle: Recherche et remplacement de texte
type: docs
weight: 55
url: /fr/nodejs-java/search-and-replace-text/
keywords:
- recherche de texte
- mettre en évidence le texte
- remplacer le texte
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
description: "Recherchez, mettez en évidence et remplacez du texte dans les présentations PowerPoint tout en collectant chaque correspondance avec Aspose.Slides for Node.js via Java."
---
## **Aperçu**

Aspose.Slides for Node.js via Java peut rechercher, mettre en évidence et remplacer du texte dans un cadre de texte individuel ou dans l’ensemble d’une présentation. Chaque opération peut également notifier une application de chaque correspondance via un rappel de résultat. Cela permet de mettre à jour une présentation tout en construisant simultanément une piste d’audit contenant le texte trouvé, son contexte, sa position, le cadre de texte et le numéro de diapositive.

Ces capacités sont utiles pour la révision, la rédaction, la vérification de terminologie, le nettoyage de modèles et les flux de travail de génération de rapports automatisés.

Dans les premiers exemples ci‑dessous, nous utilisons un fichier nommé **"sample.pptx"**, qui contient une seule zone de texte sur la première diapositive avec le texte suivant :

![Texte d'exemple](sample_text.png)

## **Choisir la portée de recherche**

Utilisez les méthodes sur [TextFrame](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/textframe/) pour limiter une opération à un seul cadre de texte. Utilisez les méthodes sur [Presentation](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/) pour traiter tout le texte applicable de la présentation.

| Opération | Un cadre de texte | Toute la présentation |
|---|---|---|
| Mettre en évidence du texte littéral | [TextFrame.highlightText](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/textframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [Presentation.highlightText](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Mettre en évidence des correspondances d’expression régulière | [TextFrame.highlightRegex](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/textframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) | [Presentation.highlightRegex](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) |
| Remplacer du texte littéral | [TextFrame.replaceText](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [Presentation.replaceText](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Remplacer des correspondances d’expression régulière | [TextFrame.replaceRegex](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) | [Presentation.replaceRegex](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) |

## **Configurer la correspondance de texte**

Pour les opérations sur du texte littéral, utilisez [TextSearchOptions](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/textsearchoptions/) afin de contrôler la correspondance :

- [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) limite les correspondances aux mots complets.
- [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) contrôle si la casse des caractères doit correspondre.
- [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) inclut les notes de diapositive dans les opérations de recherche, de remplacement et de mise en évidence au niveau de la présentation.

Les opérations d’expression régulière utilisent un `Pattern` Java, de sorte que les règles de correspondance telles que la sensibilité à la casse et les limites de mots sont définies par l’expression et ses drapeaux.

## **Collecter les informations de correspondance avec un rappel**

Créez un proxy Java pour le rappel de résultat afin de recevoir une notification pour chaque correspondance. La fonction proxy reçoit le cadre de texte concerné, le texte source, le texte correspondant et la position de la correspondance.

Le rappel ne reçoit pas directement le numéro de diapositive. L’implémentation ci‑dessous le dérive via [TextFrame.getSlide](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/textframe/#getSlide--), [Slide.getSlideNumber](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/slide/#getSlideNumber--), et [NotesSlide.getParentSlide](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/notesslide/#getParentSlide--). Il gère également le texte trouvé dans les notes de diapositive.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

function getSlideNumber(textFrame) {
    const parentSlide = textFrame.getSlide();

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

Pour les opérations de remplacement, `foundText` contient le texte original trouvé, de sorte que le rappel peut enregistrer précisément quels termes ont été remplacés.

## **Mettre en évidence le texte**

Utilisez la méthode [TextFrame.highlightText](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/textframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) pour mettre en évidence les correspondances de texte littéral dans un cadre de texte. Passez un [TextSearchOptions](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/textsearchoptions/) pour contrôler la recherche.

L’exemple de code ci‑dessous met en évidence toutes les occurrences des caractères **"try"** puis ne met en évidence que le mot complet **"to"**.

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

![Le texte mis en évidence](highlighted_text.png)

## **Mettre en évidence le texte à l’aide d’expressions régulières**

La méthode [TextFrame.highlightRegex](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/textframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) met en évidence les correspondances de texte trouvées par une expression régulière dans un cadre de texte.

Le code suivant met en évidence tous les mots contenant sept caractères ou plus :

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

![Le texte mis en évidence en utilisant l'expression régulière](highlighted_text_using_regex.png)

## **Mettre en évidence le texte dans une présentation**

Utilisez [Presentation.highlightText](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) et [Presentation.highlightRegex](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) pour rechercher tous les cadres de texte applicables d’une présentation. L’exemple suivant met en évidence un terme littéral et toutes les adresses e‑mail :

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

Utilisez [TextFrame.replaceText](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) pour le texte littéral et [TextFrame.replaceRegex](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) pour le remplacement basé sur un modèle. Ces méthodes mettent à jour le texte correspondant à l’intérieur du cadre de texte existant, qui conserve le formatage de la portion environnante au lieu de reconstruire le cadre de texte à partir d’une chaîne brute.

L’exemple suivant uniformise une variante orthographique puis remplace les libellés de version :

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

Si une correspondance couvre des portions avec un formatage différent, examinez le résultat pour confirmer quel formatage doit s’appliquer au texte remplacé.

## **Remplacer le texte dans toute la présentation**

Utilisez [Presentation.replaceText](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) et [Presentation.replaceRegex](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) pour appliquer les mêmes opérations à l’ensemble de la présentation. Ceci est utile pour le nettoyage de modèles, les mises à jour de terminologie et la rédaction.

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

## **Regrouper les correspondances pour les rapports**

Comme chaque résultat collecté stocke son numéro de diapositive et son cadre de texte, les applications peuvent regrouper les correspondances pour les audits, les rapports ou les flux de travail de révision. L’exemple suivant regroupe d’abord les résultats par diapositive, puis par cadre de texte :

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

function getSlideNumber(textFrame) {
    const parentSlide = textFrame.getSlide();

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

**Comment puis‑je rechercher uniquement une zone de texte au lieu de toute la présentation ?**

Obtenez le cadre de texte de la forme et appelez [TextFrame.highlightText](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/textframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), [TextFrame.highlightRegex](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/textframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-), [TextFrame.replaceText](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), ou [TextFrame.replaceRegex](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) sur ce cadre de texte. Les méthodes au niveau de la présentation traitent toutes les formes de texte applicables.

**Comment puis‑je faire correspondre des mots complets avec la bonne capitalisation ?**

Définissez [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) et [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) sur `true`, puis passez les options à une méthode de mise en évidence ou de remplacement de texte littéral. Pour les expressions régulières, définissez les limites de mots et la sensibilité à la casse directement dans le `Pattern` Java.

**La recherche et le remplacement peuvent‑ils inclure le texte des notes de diapositive ?**

Oui. Définissez [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) sur `true` lors de l’utilisation d’une opération littérale au niveau de la présentation. L’implémentation du rappel présentée ci‑dessus reconduit une correspondance dans une diapositive de notes à son numéro de diapositive parent.

**Comment créer un rapport sans analyser la présentation une seconde fois ?**

Passez un proxy Java de rappel de résultat à l’opération de mise en évidence ou de remplacement. Le rappel reçoit chaque correspondance pendant l’exécution de l’opération, de sorte que l’application puisse stocker le texte source, le texte trouvé, la position, le cadre de texte et le numéro de diapositive dérivé pour un regroupement ou une exportation ultérieure.

**Le remplacement du texte préserve‑t‑il son formatage ?**

[TextFrame.replaceText](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) et [TextFrame.replaceRegex](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) modifient le texte correspondant à l’intérieur du cadre de texte existant et conservent le formatage de la portion environnante. Si une correspondance englobe des parties avec un formatage différent, inspectez le résultat afin de vous assurer que le texte remplacé utilise le style souhaité.