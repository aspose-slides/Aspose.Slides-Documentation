---
title: Automatiser la localisation des présentations en .NET
linktitle: Localisation des présentations
type: docs
weight: 100
url: /fr/net/presentation-localization/
keywords:
- modifier la langue
- vérification orthographique
- supprimer la vérification orthographique
- langue de correction
- identifiant de langue
- texte multilingue
- PowerPoint
- présentation
- .NET
- C#
- Aspose.Slides
description: "Définissez les langues de correction pour le texte des présentations PowerPoint et OpenDocument en .NET avec Aspose.Slides, y compris les valeurs par défaut et les paragraphes multilingues."
---
## **Aperçu**

Aspose.Slides for .NET vous permet de configurer les métadonnées de correction pour des portions de texte individuelles. Utilisez [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/fr/net/aspose.slides/ibaseportionformat/languageid/) pour identifier la langue de correction, [BasePortionFormat.SpellCheck](https://reference.aspose.com/slides/fr/net/aspose.slides/baseportionformat/spellcheck/) pour autoriser ou supprimer les vérifications orthographiques, et [BasePortionFormat.ProofDisabled](https://reference.aspose.com/slides/fr/net/aspose.slides/baseportionformat/proofdisabled/) pour contrôler l’état plus large de non‑correction. Comme ces paramètres sont appliqués au niveau de la portion, un paragraphe peut contenir plusieurs langues et différentes règles de correction.

Cet article explique comment attribuer une langue à un texte spécifique, définir la langue par défaut pour le nouveau texte avec [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/fr/net/aspose.slides/loadoptions/defaulttextlanguage/), créer des paragraphes multilingues, choisir entre `SpellCheck` et `ProofDisabled`, et préserver les paramètres souhaités lors de l’utilisation de [Presentation.JoinPortionsWithSameFormatting](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/joinportionswithsameformatting/). Ces propriétés stockent des métadonnées pour les applications de présentation ; elles ne traduisent pas le texte, n’effectuent pas de vérification orthographique basée sur un dictionnaire et ne renvoient pas les mots mal orthographiés.

## **Définir la langue de correction pour le texte**

Créez ou chargez une [Presentation](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/), accédez à la portion de texte souhaitée via [IPortion.PortionFormat](https://reference.aspose.com/slides/fr/net/aspose.slides/iportion/portionformat/), puis attribuez son identifiant de langue. L’exemple suivant crée une forme, définit l’anglais britannique comme langue de correction, et enregistre le résultat avec [Presentation.Save](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/save/):

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 320, 80);
shape.TextFrame.Text = "Set the proofing language for this text.";

var portion = shape.TextFrame.Paragraphs[0].Portions[0];
portion.PortionFormat.LanguageId = "en-GB";

presentation.Save("proofing_language.pptx", SaveFormat.Pptx);
```

## **Définir la langue par défaut pour le nouveau texte**

Utilisez [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/fr/net/aspose.slides/loadoptions/defaulttextlanguage/) pour spécifier la langue de correction qu’Aspose.Slides attribue au texte nouvellement créé. Ce paramètre est utile lorsque la plupart ou la totalité du nouveau texte d’une présentation utilise la même langue. Il ne modifie pas les métadonnées de langue du texte qui possède déjà une langue explicite.

L’exemple suivant crée une présentation dont le nouveau texte utilise les règles de correction allemandes :

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var loadOptions = new LoadOptions
{
    DefaultTextLanguage = "de-DE"
};

using var presentation = new Presentation(loadOptions);
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 320, 80);
shape.TextFrame.Text = "Willkommen zur Präsentation";

presentation.Save("default_text_language.pptx", SaveFormat.Pptx);
```

## **Utiliser plusieurs langues dans un même paragraphe**

Un [IParagraph](https://reference.aspose.com/slides/fr/net/aspose.slides/iparagraph/) contient une collection de portions de texte. Créez une [Portion](https://reference.aspose.com/slides/fr/net/aspose.slides/portion/) distincte pour chaque langue et définissez son `LanguageId` indépendamment.

Cet exemple crée un paragraphe avec des portions en anglais et en français :

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 420, 80);
var paragraph = shape.TextFrame.Paragraphs[0];
paragraph.Portions.Clear();

var englishPortion = new Portion("Welcome");
englishPortion.PortionFormat.LanguageId = "en-US";
paragraph.Portions.Add(englishPortion);

var frenchPortion = new Portion(" — Bienvenue");
frenchPortion.PortionFormat.LanguageId = "fr-FR";
paragraph.Portions.Add(frenchPortion);

presentation.Save("multilingual_text.pptx", SaveFormat.Pptx);
```

## **Activer ou supprimer la vérification orthographique pour les portions individuelles**

[IPortionFormat](https://reference.aspose.com/slides/fr/net/aspose.slides/iportionformat/) hérite des propriétés de texte communes définies par [IBasePortionFormat](https://reference.aspose.com/slides/fr/net/aspose.slides/ibaseportionformat/). Accédez au format d’une portion via [IPortion.PortionFormat](https://reference.aspose.com/slides/fr/net/aspose.slides/iportion/portionformat/) et définissez [BasePortionFormat.SpellCheck](https://reference.aspose.com/slides/fr/net/aspose.slides/baseportionformat/spellcheck/) pour contrôler si une application de présentation peut vérifier l’orthographe de cette portion. La valeur par défaut est `false` : `true` autorise la vérification orthographique, tandis que `false` la supprime.

Le paramètre s’applique aux portions de texte individuelles. Ainsi, différentes portions dans le même paragraphe peuvent utiliser des valeurs différentes. [BasePortionFormat.LanguageId](https://reference.aspose.com/slides/fr/net/aspose.slides/baseportionformat/languageid/) et `SpellCheck` remplissent des fonctions complémentaires : `LanguageId` identifie la langue de correction, tandis que `SpellCheck` détermine si les vérifications orthographiques sont autorisées pour la portion.

[BasePortionFormat.ProofDisabled](https://reference.aspose.com/slides/fr/net/aspose.slides/baseportionformat/proofdisabled/) contrôle également la correction, mais il représente l’état plus large « ne pas corriger » sous forme de [NullableBool](https://reference.aspose.com/slides/fr/net/aspose.slides/nullablebool/). Utilisez `SpellCheck` lorsque vous avez besoin d’un commutateur booléen direct spécifiquement pour les vérifications orthographiques. Utilisez `ProofDisabled` lorsque vous devez préserver ou contrôler explicitement les métadonnées « no‑proof » de la présentation, y compris son état `NotDefined`. Si vous définissez les deux propriétés, maintenez leurs valeurs cohérentes ; ne combinez pas `SpellCheck = true` avec `ProofDisabled = NullableBool.True`.

Ces propriétés configurent les métadonnées de correction utilisées par PowerPoint et d’autres applications de présentation. Aspose.Slides ne les utilise pas pour exécuter une vérification orthographique basée sur un dictionnaire ni pour renvoyer une liste de mots mal orthographiés.

L’exemple complet suivant crée une présentation d’entrée, la charge, attribue différents paramètres de vérification orthographique et langues de correction à deux portions du même paragraphe, enregistre le résultat, le rouvre et vérifie les valeurs stockées :

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

const string inputFile = "spell_check_input.pptx";
const string outputFile = "spell_check_settings.pptx";

using (var sourcePresentation = new Presentation())
{
    var sourceSlide = sourcePresentation.Slides[0];
    var sourceShape = sourceSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 420, 80);
    var sourceParagraph = sourceShape.TextFrame.Paragraphs[0];
    sourceParagraph.Portions.Clear();

    var sourceEnglishPortion = new Portion("Check this text. ");
    sourceEnglishPortion.PortionFormat.LanguageId = "en-US";
    sourceParagraph.Portions.Add(sourceEnglishPortion);

    var sourceFrenchPortion = new Portion("Ignorer ce code : ZX-81.");
    sourceFrenchPortion.PortionFormat.LanguageId = "fr-FR";
    sourceParagraph.Portions.Add(sourceFrenchPortion);

    sourcePresentation.Save(inputFile, SaveFormat.Pptx);
}

using (var presentation = new Presentation(inputFile))
{
    var shape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var portions = shape.TextFrame.Paragraphs[0].Portions;

    var checkedPortion = portions[0];
    checkedPortion.PortionFormat.LanguageId = "en-US";
    checkedPortion.PortionFormat.SpellCheck = true;

    var suppressedPortion = portions[1];
    suppressedPortion.PortionFormat.LanguageId = "fr-FR";
    suppressedPortion.PortionFormat.SpellCheck = false;

    presentation.Save(outputFile, SaveFormat.Pptx);
}

using var reopenedPresentation = new Presentation(outputFile);
var reopenedShape = (IAutoShape)reopenedPresentation.Slides[0].Shapes[0];
var storedPortions = reopenedShape.TextFrame.Paragraphs[0].Portions;

var firstPortionStored = storedPortions.Count == 2 &&
    storedPortions[0].PortionFormat.LanguageId == "en-US" &&
    storedPortions[0].PortionFormat.SpellCheck;

var secondPortionStored = storedPortions.Count == 2 &&
    storedPortions[1].PortionFormat.LanguageId == "fr-FR" &&
    !storedPortions[1].PortionFormat.SpellCheck;

if (firstPortionStored && secondPortionStored)
{
    Console.WriteLine("The proofing settings were stored correctly.");
}
else
{
    Console.WriteLine("The proofing settings could not be verified.");
}
```

[Presentation.JoinPortionsWithSameFormatting](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/joinportionswithsameformatting/) combine les portions adjacentes qui ont le même formatage. Une différence uniquement au niveau de `SpellCheck` ne suffit pas à garder ces portions séparées ; après la jonction, la portion résultante conserve la valeur `SpellCheck` de la première portion. Si des portions nécessitent des paramètres de vérification orthographique différents, appelez `JoinPortionsWithSameFormatting` avant d’attribuer ces paramètres, ou examinez les limites de la portion résultante et réappliquez les paramètres par la suite. Les portions avec des valeurs `LanguageId` différentes restent distinctes parce que leur formatage de langue de correction diffère.

## **FAQ**

**Un identifiant de langue traduit‑il le texte ?**

Non. [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/fr/net/aspose.slides/ibaseportionformat/languageid/) stocke des métadonnées de correction pour l’orthographe et la grammaire ; il ne modifie pas le contenu du texte. Traduisez le texte séparément, puis définissez l’identifiant de langue approprié pour chaque portion traduite.

**La langue de correction contrôle‑t‑elle les polices, la césure ou le retour à la ligne ?**

Non. L’identifiant de langue sert à la correction. Le rendu du texte et la mise en page dépendent principalement des [polices](/slides/fr/net/powerpoint-fonts/), du système d’écriture et des paramètres du cadre de texte. Pour un rendu fiable, fournissez les polices requises, configurez la [substitution de police](/slides/fr/net/font-substitution/) ou [intégrez les polices](/slides/fr/net/embedded-font/) dans la présentation.

**Un paragraphe peut‑il utiliser plusieurs langues de correction ?**

Oui. Attribuez chaque langue à une portion distincte, comme le montre l’exemple du paragraphe multilingue.

**Dois‑je utiliser `DefaultTextLanguage` ou `LanguageId` ?**

Utilisez [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/fr/net/aspose.slides/loadoptions/defaulttextlanguage/) lorsque vous voulez une langue par défaut pour le texte nouvellement créé. Utilisez [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/fr/net/aspose.slides/ibaseportionformat/languageid/) lorsqu’une portion spécifique nécessite une langue de correction explicite ou lorsqu’un paragraphe contient plusieurs langues.