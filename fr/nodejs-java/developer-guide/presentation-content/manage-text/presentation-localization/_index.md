---
title: Automatiser la localisation des présentations en JavaScript
linktitle: Localisation des présentations
type: docs
weight: 100
url: /fr/nodejs-java/presentation-localization/
keywords:
- changer de langue
- vérification orthographique
- supprimer la vérification orthographique
- langue de correction
- identifiant de langue
- texte multilingue
- PowerPoint
- présentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Définir les langues de correction pour le texte des présentations PowerPoint et OpenDocument en JavaScript avec Aspose.Slides, y compris les valeurs par défaut et les paragraphes multilingues."
---
## **Vue d'ensemble**

Aspose.Slides for Node.js via Java vous permet de configurer les métadonnées de correction pour des portions de texte individuelles. Utilisez [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) pour identifier la langue de correction, [BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/baseportionformat/#setSpellCheck-boolean-) pour autoriser ou supprimer la vérification orthographique, et [BasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/baseportionformat/#setProofDisabled-byte-) pour contrôler l’état plus large «pas de correction». Parce que ces paramètres sont appliqués au niveau de la portion, un paragraphe peut contenir plusieurs langues et différentes règles de correction.

Cet article explique comment affecter une langue à un texte spécifique, définir la langue par défaut pour le texte nouveau avec [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-), créer des paragraphes multilingues, choisir entre `SpellCheck` et `ProofDisabled`, et préserver les paramètres souhaités lors de l'utilisation de [Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/#joinPortionsWithSameFormatting--). Ces propriétés stockent des métadonnées pour les applications de présentation ; elles ne traduisent pas le texte, n’exécutent pas de vérification orthographique basée sur un dictionnaire, et ne renvoient pas les mots mal orthographiés.

## **Définir la langue de correction pour le texte**

Créez ou chargez une [Presentation](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/), accédez à la portion de texte requise via [Portion.getPortionFormat](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/portion/#getPortionFormat--), et affectez son identifiant de langue. L'exemple suivant crée une forme, définit l'anglais britannique comme langue de correction, et enregistre le résultat avec [Presentation.save](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/#save-java.lang.String-int-):

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 320, 80);
    shape.getTextFrame().setText("Set the proofing language for this text.");

    const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.getPortionFormat().setLanguageId("en-GB");

    presentation.save("proofing_language.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Définir la langue par défaut pour le texte nouveau**

Utilisez [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) pour spécifier la langue de correction qu’Aspose.Slides attribue au texte nouvellement créé. Ce paramètre est utile lorsque la majeure partie ou la totalité du texte nouveau d’une présentation utilise la même langue. Il ne modifie pas les métadonnées de langue du texte qui possède déjà une langue explicite.

L'exemple suivant crée une présentation dont le texte nouveau utilise les règles de correction allemandes :

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setDefaultTextLanguage("de-DE");

const presentation = new aspose.slides.Presentation(loadOptions);
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 320, 80);
    shape.getTextFrame().setText("Willkommen zur Präsentation");

    presentation.save("default_text_language.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Utiliser plusieurs langues dans un même paragraphe**

Un [Paragraph](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/paragraph/) contient une collection de portions de texte. Créez une [Portion](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/portion/) distincte pour chaque langue et définissez son `LanguageId` de façon indépendante.

Cet exemple crée un paragraphe contenant des portions en anglais et en français :

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 420, 80);
    const paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    const englishPortion = new aspose.slides.Portion("Welcome");
    englishPortion.getPortionFormat().setLanguageId("en-US");
    paragraph.getPortions().add(englishPortion);

    const frenchPortion = new aspose.slides.Portion(" — Bienvenue");
    frenchPortion.getPortionFormat().setLanguageId("fr-FR");
    paragraph.getPortions().add(frenchPortion);

    presentation.save("multilingual_text.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Activer ou supprimer la vérification orthographique pour les portions individuelles**

[PortionFormat](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/portionformat/) hérite des propriétés de texte communes définies par [BasePortionFormat](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/baseportionformat/). Accédez au format d’une portion via [Portion.getPortionFormat](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/portion/#getPortionFormat--) et utilisez [BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/baseportionformat/#setSpellCheck-boolean-) pour contrôler si une application de présentation peut vérifier l’orthographe de cette portion. La valeur par défaut est `false` : `true` autorise la vérification orthographique, tandis que `false` la supprime.

Ce paramètre s’applique aux portions de texte individuelles. Ainsi, différentes portions dans le même paragraphe peuvent utiliser des valeurs différentes. [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) et `setSpellCheck` remplissent des fonctions complémentaires : `setLanguageId` identifie la langue de correction, tandis que `setSpellCheck` détermine si la vérification orthographique est autorisée pour la portion.

[BasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/baseportionformat/#setProofDisabled-byte-) contrôle également la correction, mais il représente l’état plus large «ne pas corriger» sous forme d’un [NullableBool](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/nullablebool/). Utilisez `setSpellCheck` lorsque vous avez besoin d’un interrupteur booléen direct spécifiquement pour la vérification orthographique. Utilisez `setProofDisabled` lorsque vous devez préserver ou contrôler explicitement les métadonnées «pas de correction» de la présentation, y compris son état `NotDefined`. Si vous définissez les deux propriétés, maintenez leurs valeurs cohérentes ; ne combinez pas `setSpellCheck(true)` avec `setProofDisabled(NullableBool.True)`.

Ces propriétés configurent les métadonnées de correction utilisées par PowerPoint et d’autres applications de présentation. Aspose.Slides ne les utilise pas pour exécuter une vérification orthographique basée sur un dictionnaire ou renvoyer une liste de mots mal orthographiés.

L'exemple complet suivant crée une présentation d'entrée, la charge, affecte des paramètres de vérification orthographique et des langues de correction différents à deux portions du même paragraphe, enregistre le résultat, le rouvre, et vérifie les valeurs stockées :

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const inputFile = "spell_check_input.pptx";
const outputFile = "spell_check_settings.pptx";

const sourcePresentation = new aspose.slides.Presentation();
try {
    const sourceSlide = sourcePresentation.getSlides().get_Item(0);
    const sourceShape = sourceSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 420, 80);
    const sourceParagraph = sourceShape.getTextFrame().getParagraphs().get_Item(0);
    sourceParagraph.getPortions().clear();

    const sourceEnglishPortion = new aspose.slides.Portion("Check this text. ");
    sourceEnglishPortion.getPortionFormat().setLanguageId("en-US");
    sourceParagraph.getPortions().add(sourceEnglishPortion);

    const sourceFrenchPortion = new aspose.slides.Portion("Ignorer ce code : ZX-81.");
    sourceFrenchPortion.getPortionFormat().setLanguageId("fr-FR");
    sourceParagraph.getPortions().add(sourceFrenchPortion);

    sourcePresentation.save(inputFile, aspose.slides.SaveFormat.Pptx);
} finally {
    sourcePresentation.dispose();
}

const presentation = new aspose.slides.Presentation(inputFile);
try {
    const shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const portions = shape.getTextFrame().getParagraphs().get_Item(0).getPortions();

    const checkedPortion = portions.get_Item(0);
    checkedPortion.getPortionFormat().setLanguageId("en-US");
    checkedPortion.getPortionFormat().setSpellCheck(true);

    const suppressedPortion = portions.get_Item(1);
    suppressedPortion.getPortionFormat().setLanguageId("fr-FR");
    suppressedPortion.getPortionFormat().setSpellCheck(false);

    presentation.save(outputFile, aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

const reopenedPresentation = new aspose.slides.Presentation(outputFile);
try {
    const reopenedShape = reopenedPresentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const storedPortions = reopenedShape.getTextFrame().getParagraphs().get_Item(0).getPortions();

    const firstPortionStored = storedPortions.getCount() === 2 && 
        storedPortions.get_Item(0).getPortionFormat().getLanguageId() === "en-US" && 
        storedPortions.get_Item(0).getPortionFormat().getSpellCheck();

    const secondPortionStored = storedPortions.getCount() === 2 && 
        storedPortions.get_Item(1).getPortionFormat().getLanguageId() === "fr-FR" && 
        !storedPortions.get_Item(1).getPortionFormat().getSpellCheck();

    if (firstPortionStored && secondPortionStored) {
        console.log("The proofing settings were stored correctly.");
    } else {
        console.log("The proofing settings could not be verified.");
    }
} finally {
    reopenedPresentation.dispose();
}
```

[Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/#joinPortionsWithSameFormatting--) combine les portions adjacentes qui ont le même formatage. Une différence uniquement au niveau de `SpellCheck` ne garde pas ces portions séparées ; après la fusion, la portion résultante conserve la valeur `SpellCheck` de la première portion. Si les portions nécessitent des paramètres de vérification orthographique différents, appelez `joinPortionsWithSameFormatting` avant d’affecter ces paramètres, ou examinez les limites des portions résultantes et réappliquez les paramètres ensuite. Les portions avec des valeurs `LanguageId` différentes restent séparées car leur formatage de langue de correction diffère.

## **FAQ**

**Un identifiant de langue traduit-il le texte ?**

Non. [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) stocke des métadonnées de correction pour l’orthographe et la grammaire ; il ne modifie pas le contenu du texte. Traduisez le texte séparément, puis définissez l’identifiant de langue approprié pour chaque portion traduite.

**La langue de correction contrôle-t-elle les polices, la césure ou le retour à la ligne ?**

Non. L’identifiant de langue sert à la correction. Le rendu du texte et la mise en page dépendent principalement des [polices](/slides/fr/nodejs-java/powerpoint-fonts/), du système d’écriture et des paramètres du cadre de texte. Pour un rendu fiable, fournissez les polices requises, configurez la [substitution de police](/slides/fr/nodejs-java/font-substitution/), ou [intégrez des polices](/slides/fr/nodejs-java/embedded-font/) dans la présentation.

**Un paragraphe peut-il utiliser plusieurs langues de correction ?**

Oui. Assignez chaque langue à une portion distincte, comme montré dans l’exemple de paragraphe multilingue.

**Dois-je utiliser `setDefaultTextLanguage` ou `setLanguageId` ?**

Utilisez [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) lorsque vous souhaitez une langue par défaut pour le texte nouvellement créé. Utilisez [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) lorsqu’une portion spécifique nécessite une langue de correction explicite ou lorsqu’un paragraphe contient plusieurs langues.