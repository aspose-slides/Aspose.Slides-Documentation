---
title: Automatiser la localisation de présentation en PHP
linktitle: Localisation de présentation
type: docs
weight: 100
url: /fr/php-java/presentation-localization/
keywords:
- changer la langue
- vérification orthographique
- supprimer la vérification orthographique
- langue de révision
- identifiant de langue
- texte multilingue
- PowerPoint
- présentation
- PHP
- Aspose.Slides
description: "Définissez les langues de révision pour le texte des présentations PowerPoint et OpenDocument en PHP avec Aspose.Slides, y compris les paramètres par défaut et les paragraphes multilingues."
---
## **Aperçu**

Aspose.Slides for PHP via Java vous permet de configurer les métadonnées de vérification pour des portions de texte individuelles. Utilisez [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/fr/php-java/aspose.slides/baseportionformat/#setLanguageId) pour identifier la langue de vérification, [BasePortionFormat::setSpellCheck](https://reference.aspose.com/slides/fr/php-java/aspose.slides/baseportionformat/#setSpellCheck) pour autoriser ou supprimer les vérifications orthographiques, et [BasePortionFormat::setProofDisabled](https://reference.aspose.com/slides/fr/php-java/aspose.slides/baseportionformat/#setProofDisabled) pour contrôler l’état plus large « ne pas vérifier ». Parce que ces paramètres sont appliqués au niveau de la portion, un paragraphe peut contenir plusieurs langues et différentes règles de vérification.

Cet article explique comment attribuer une langue à du texte spécifique, définir la langue par défaut pour le nouveau texte avec [LoadOptions::setDefaultTextLanguage](https://reference.aspose.com/slides/fr/php-java/aspose.slides/loadoptions/#setDefaultTextLanguage), créer des paragraphes multilingues, choisir entre `SpellCheck` et `ProofDisabled`, et préserver les paramètres souhaités lors de l’utilisation de [Presentation::joinPortionsWithSameFormatting](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/#joinPortionsWithSameFormatting). Ces propriétés stockent des métadonnées pour les applications de présentation ; elles ne traduisent pas le texte, n’effectuent pas de vérification orthographique basée sur un dictionnaire, et ne renvoient pas les mots mal orthographiés.

## **Définir la langue de vérification pour le texte**

Créez ou chargez une [Presentation](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/), accédez à la portion de texte requise via [Portion::getPortionFormat](https://reference.aspose.com/slides/fr/php-java/aspose.slides/portion/#getPortionFormat), et attribuez son identifiant de langue. L’exemple suivant crée une forme, définit l’anglais britannique comme langue de vérification, et enregistre le résultat avec [Presentation::save](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/#save):

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 320, 80);
    $shape->getTextFrame()->setText("Set the proofing language for this text.");

    $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->getPortionFormat()->setLanguageId("en-GB");

    $presentation->save("proofing_language.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Définir la langue par défaut pour le nouveau texte**

Utilisez [LoadOptions::setDefaultTextLanguage](https://reference.aspose.com/slides/fr/php-java/aspose.slides/loadoptions/#setDefaultTextLanguage) pour spécifier la langue de vérification qu’Aspose.Slides attribue au texte nouvellement créé. Ce paramètre est utile lorsque la plupart ou la totalité du nouveau texte d’une présentation utilise la même langue. Il ne modifie pas les métadonnées de langue du texte qui possède déjà une langue explicite.

L’exemple suivant crée une présentation dont le nouveau texte utilise les règles de vérification allemandes :

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$loadOptions = new LoadOptions();
$loadOptions->setDefaultTextLanguage("de-DE");

$presentation = new Presentation($loadOptions);
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 320, 80);
    $shape->getTextFrame()->setText("Willkommen zur Präsentation");

    $presentation->save("default_text_language.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Utiliser plusieurs langues dans un même paragraphe**

Un [Paragraph](https://reference.aspose.com/slides/fr/php-java/aspose.slides/paragraph/) contient une collection de portions de texte. Créez une [Portion](https://reference.aspose.com/slides/fr/php-java/aspose.slides/portion/) distincte pour chaque langue et définissez son `LanguageId` indépendamment.

Cet exemple crée un paragraphe avec des portions en anglais et en français :

```php
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 420, 80);
    $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getPortions()->clear();

    $englishPortion = new Portion("Welcome");
    $englishPortion->getPortionFormat()->setLanguageId("en-US");
    $paragraph->getPortions()->add($englishPortion);

    $frenchPortion = new Portion(" — Bienvenue");
    $frenchPortion->getPortionFormat()->setLanguageId("fr-FR");
    $paragraph->getPortions()->add($frenchPortion);

    $presentation->save("multilingual_text.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Activer ou supprimer la vérification orthographique pour des portions individuelles**

[PortionFormat](https://reference.aspose.com/slides/fr/php-java/aspose.slides/portionformat/) hérite des propriétés de texte communes définies par [BasePortionFormat](https://reference.aspose.com/slides/fr/php-java/aspose.slides/baseportionformat/). Accédez au format d’une portion via [Portion::getPortionFormat](https://reference.aspose.com/slides/fr/php-java/aspose.slides/portion/#getPortionFormat) et utilisez [BasePortionFormat::setSpellCheck](https://reference.aspose.com/slides/fr/php-java/aspose.slides/baseportionformat/#setSpellCheck) pour contrôler si une application de présentation peut vérifier l’orthographe de cette portion. La valeur par défaut est `false` : `true` autorise la vérification orthographique, tandis que `false` la supprime.

Le paramètre s’applique aux portions de texte individuelles. Des portions différentes dans le même paragraphe peuvent donc utiliser des valeurs distinctes. [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/fr/php-java/aspose.slides/baseportionformat/#setLanguageId) et `setSpellCheck` remplissent des fonctions complémentaires : `setLanguageId` identifie la langue de vérification, tandis que `setSpellCheck` détermine si la vérification orthographique est autorisée pour la portion.

[BasePortionFormat::setProofDisabled](https://reference.aspose.com/slides/fr/php-java/aspose.slides/baseportionformat/#setProofDisabled) contrôle également la vérification, mais représente l’état plus large « ne pas vérifier » sous la forme d’un [NullableBool](https://reference.aspose.com/slides/fr/php-java/aspose.slides/nullablebool/). Utilisez `setSpellCheck` lorsque vous avez besoin d’un commutateur booléen direct spécifiquement pour la vérification orthographique. Utilisez `setProofDisabled` lorsque vous devez préserver ou contrôler explicitement les métadonnées « no‑proof » de la présentation, y compris son état `NotDefined`. Si vous définissez les deux propriétés, conservez leurs valeurs cohérentes ; ne combinez pas `setSpellCheck(true)` avec `setProofDisabled(NullableBool::True)`.

Ces propriétés configurent les métadonnées de vérification utilisées par PowerPoint et d’autres applications de présentation. Aspose.Slides ne les utilise pas pour exécuter une vérification orthographique basée sur un dictionnaire ni pour renvoyer une liste de mots mal orthographiés.

L’exemple complet suivant crée une présentation d’entrée, la charge, attribue différents paramètres de vérification orthographique et langues de vérification à deux portions du même paragraphe, enregistre le résultat, le rouvre, et vérifie les valeurs stockées :

```php
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$inputFile = "spell_check_input.pptx";
$outputFile = "spell_check_settings.pptx";

$sourcePresentation = new Presentation();
try {
    $sourceSlide = $sourcePresentation->getSlides()->get_Item(0);
    $sourceShape = $sourceSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 420, 80);
    $sourceParagraph = $sourceShape->getTextFrame()->getParagraphs()->get_Item(0);
    $sourceParagraph->getPortions()->clear();

    $sourceEnglishPortion = new Portion("Check this text. ");
    $sourceEnglishPortion->getPortionFormat()->setLanguageId("en-US");
    $sourceParagraph->getPortions()->add($sourceEnglishPortion);

    $sourceFrenchPortion = new Portion("Ignorer ce code : ZX-81.");
    $sourceFrenchPortion->getPortionFormat()->setLanguageId("fr-FR");
    $sourceParagraph->getPortions()->add($sourceFrenchPortion);

    $sourcePresentation->save($inputFile, SaveFormat::Pptx);
} finally {
    $sourcePresentation->dispose();
}

$presentation = new Presentation($inputFile);
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $portions = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions();

    $checkedPortion = $portions->get_Item(0);
    $checkedPortion->getPortionFormat()->setLanguageId("en-US");
    $checkedPortion->getPortionFormat()->setSpellCheck(true);

    $suppressedPortion = $portions->get_Item(1);
    $suppressedPortion->getPortionFormat()->setLanguageId("fr-FR");
    $suppressedPortion->getPortionFormat()->setSpellCheck(false);

    $presentation->save($outputFile, SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

$reopenedPresentation = new Presentation($outputFile);
try {
    $reopenedShape = $reopenedPresentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $storedPortions = $reopenedShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions();

    $storedPortionCount = java_values($storedPortions->getCount());
    $firstStoredFormat = $storedPortions->get_Item(0)->getPortionFormat();
    $secondStoredFormat = $storedPortions->get_Item(1)->getPortionFormat();

    $firstPortionStored = $storedPortionCount === 2 && 
        java_values($firstStoredFormat->getLanguageId()) === "en-US" && 
        java_values($firstStoredFormat->getSpellCheck());

    $secondPortionStored = $storedPortionCount === 2 && 
        java_values($secondStoredFormat->getLanguageId()) === "fr-FR" && 
        !java_values($secondStoredFormat->getSpellCheck());

    if ($firstPortionStored && $secondPortionStored) {
        echo "The proofing settings were stored correctly.";
    } else {
        echo "The proofing settings could not be verified.";
    }
} finally {
    $reopenedPresentation->dispose();
}
```

[Presentation::joinPortionsWithSameFormatting](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/#joinPortionsWithSameFormatting) combine les portions adjacentes qui ont le même formatage. Une différence uniquement au niveau de `SpellCheck` ne suffit pas à maintenir ces portions séparées ; après la fusion, la portion résultante conserve la valeur `SpellCheck` de la première portion. Si des portions nécessitent des paramètres de vérification différents, appelez `joinPortionsWithSameFormatting` avant d’assigner ces paramètres, ou inspectez les limites des portions résultantes et réappliquez les paramètres ensuite. Les portions avec des valeurs `LanguageId` différentes restent séparées parce que leur formatage de langue de vérification diffère.

## **FAQ**

**Un identifiant de langue traduit‑il le texte ?**

Non. [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/fr/php-java/aspose.slides/baseportionformat/#setLanguageId) stocke des métadonnées de vérification pour l’orthographe et la grammaire ; il ne modifie pas le contenu du texte. Traduisez le texte séparément, puis définissez l’identifiant de langue approprié pour chaque portion traduite.

**La langue de vérification contrôle‑t‑elle les polices, la césure ou le saut de ligne ?**

Non. L’identifiant de langue sert uniquement à la révision. Le rendu du texte et la mise en page dépendent principalement des [polices](/slides/fr/php-java/powerpoint-fonts/) disponibles, du système d’écriture et des paramètres du cadre de texte. Pour un rendu fiable, fournissez les polices requises, configurez la [substitution de polices](/slides/fr/php-java/font-substitution/), ou [intégrez les polices](/slides/fr/php-java/embedded-font/) dans la présentation.

**Un paragraphe peut‑il utiliser plusieurs langues de vérification ?**

Oui. Attribuez chaque langue à une portion distincte, comme le montre l’exemple de paragraphe multilingue.

**Dois‑je utiliser `setDefaultTextLanguage` ou `setLanguageId` ?**

Utilisez [LoadOptions::setDefaultTextLanguage](https://reference.aspose.com/slides/fr/php-java/aspose.slides/loadoptions/#setDefaultTextLanguage) lorsque vous souhaitez une langue par défaut pour le texte nouvellement créé. Utilisez [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/fr/php-java/aspose.slides/baseportionformat/#setLanguageId) lorsqu’une portion spécifique nécessite une langue de vérification explicite ou lorsqu’un paragraphe contient plusieurs langues.