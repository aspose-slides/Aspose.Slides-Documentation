---
title: Automatiser la localisation de présentations en Python via Java
linktitle: Localisation de présentation
type: docs
weight: 100
url: /fr/python-java/presentation-localization/
keywords:
- modifier la langue
- vérification orthographique
- désactiver la vérification orthographique
- langue de vérification
- identifiant de langue
- texte multilingue
- PowerPoint
- présentation
- Python
- Java
- Aspose.Slides
description: "Définir les langues de vérification pour le texte des présentations PowerPoint et OpenDocument en Python via Java avec Aspose.Slides, y compris les paramètres par défaut et les paragraphes multilingues."
---
## **Vue d'ensemble**

Aspose.Slides for Python via Java vous permet de configurer les métadonnées de vérification pour des portions de texte individuelles. Utilisez [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/fr/python-java/aspose.slides/baseportionformat/#setLanguageId) pour identifier la langue de vérification, [BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/fr/python-java/aspose.slides/baseportionformat/#setSpellCheck) pour autoriser ou supprimer les vérifications orthographiques, et [BasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/fr/python-java/aspose.slides/baseportionformat/#setProofDisabled) pour contrôler l’état plus large « pas de vérification ». Étant donné que ces paramètres sont appliqués au niveau de la portion, un paragraphe peut contenir plusieurs langues et différentes règles de vérification.

Cet article explique comment affecter une langue à un texte spécifique, définir la langue par défaut pour le nouveau texte avec [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/fr/python-java/aspose.slides/loadoptions/#setDefaultTextLanguage), créer des paragraphes multilingues, choisir entre [BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/fr/python-java/aspose.slides/baseportionformat/#setSpellCheck) et [BasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/fr/python-java/aspose.slides/baseportionformat/#setProofDisabled), et préserver les paramètres souhaités lors de l’utilisation de [Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/#joinPortionsWithSameFormatting). Ces propriétés stockent des métadonnées pour les applications de présentation ; elles ne traduisent pas le texte, n’effectuent pas de vérification orthographique basée sur un dictionnaire, et ne renvoient pas les mots mal orthographiés.

## **Définir la langue de vérification pour le texte**

Créez ou chargez une [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/), accédez à la portion de texte souhaitée via [Portion.getPortionFormat](https://reference.aspose.com/slides/fr/python-java/aspose.slides/portion/#getPortionFormat), puis attribuez son identifiant de langue. L’exemple suivant crée une forme, définit l’anglais britannique comme langue de vérification, et enregistre le résultat avec [Presentation.save](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/#save):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 320, 80)
    shape.getTextFrame().setText("Set the proofing language for this text.")

    portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.getPortionFormat().setLanguageId("en-GB")

    presentation.save("proofing_language.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Définir la langue par défaut pour le nouveau texte**

Utilisez [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/fr/python-java/aspose.slides/loadoptions/#setDefaultTextLanguage) pour spécifier la langue de vérification qu’Aspose.Slides attribue au texte nouvellement créé. Ce paramètre est utile lorsque la plupart ou la totalité du nouveau texte d’une présentation utilise la même langue. Il ne modifie pas les métadonnées de langue du texte qui possède déjà une langue explicite.

L’exemple suivant crée une présentation dont le nouveau texte utilise les règles de vérification allemandes :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, SaveFormat, ShapeType

load_options = LoadOptions()
load_options.setDefaultTextLanguage("de-DE")

presentation = Presentation(load_options)
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 320, 80)
    shape.getTextFrame().setText("Willkommen zur Präsentation")

    presentation.save("default_text_language.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Utiliser plusieurs langues dans un même paragraphe**

Un [Paragraph](https://reference.aspose.com/slides/fr/python-java/aspose.slides/paragraph/) contient une collection de portions de texte. Créez une [Portion](https://reference.aspose.com/slides/fr/python-java/aspose.slides/portion/) distincte pour chaque langue et définissez son [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/fr/python-java/aspose.slides/baseportionformat/#setLanguageId) indépendamment.

Cet exemple crée un paragraphe contenant des portions en anglais et en français :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Portion, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 80)
    paragraph = shape.getTextFrame().getParagraphs().get_Item(0)
    paragraph.getPortions().clear()

    english_portion = Portion("Welcome")
    english_portion.getPortionFormat().setLanguageId("en-US")
    paragraph.getPortions().add(english_portion)

    french_portion = Portion(" — Bienvenue")
    french_portion.getPortionFormat().setLanguageId("fr-FR")
    paragraph.getPortions().add(french_portion)

    presentation.save("multilingual_text.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Activer ou désactiver la vérification orthographique pour des portions individuelles**

[PortionFormat](https://reference.aspose.com/slides/fr/python-java/aspose.slides/portionformat/) hérite des propriétés de texte communes définies par [BasePortionFormat](https://reference.aspose.com/slides/fr/python-java/aspose.slides/baseportionformat/). Accédez au format d’une portion via [Portion.getPortionFormat](https://reference.aspose.com/slides/fr/python-java/aspose.slides/portion/#getPortionFormat) et utilisez [BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/fr/python-java/aspose.slides/baseportionformat/#setSpellCheck) pour contrôler si une application de présentation peut vérifier l’orthographe de cette portion. La valeur par défaut est `False` : `True` autorise la vérification orthographique, tandis que `False` la désactive.

Ce paramètre s’applique aux portions de texte individuelles. Des portions différentes dans le même paragraphe peuvent ainsi utiliser des valeurs différentes. [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/fr/python-java/aspose.slides/baseportionformat/#setLanguageId) et [setSpellCheck](https://reference.aspose.com/slides/fr/python-java/aspose.slides/baseportionformat/#setSpellCheck) ont des objectifs complémentaires : [setLanguageId](https://reference.aspose.com/slides/fr/python-java/aspose.slides/baseportionformat/#setLanguageId) identifie la langue de vérification, tandis que [setSpellCheck](https://reference.aspose.com/slides/fr/python-java/aspose.slides/baseportionformat/#setSpellCheck) détermine si les vérifications orthographiques sont autorisées pour la portion.

[BasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/fr/python-java/aspose.slides/baseportionformat/#setProofDisabled) contrôle également la vérification, mais il représente l’état plus large « ne pas vérifier » sous forme de [NullableBool](https://reference.aspose.com/slides/fr/python-java/aspose.slides/nullablebool/). Utilisez [setSpellCheck](https://reference.aspose.com/slides/fr/python-java/aspose.slides/baseportionformat/#setSpellCheck) lorsque vous avez besoin d’un commutateur booléen direct spécifiquement pour la vérification orthographique. Utilisez [setProofDisabled](https://reference.aspose.com/slides/fr/python-java/aspose.slides/baseportionformat/#setProofDisabled) lorsque vous devez conserver ou contrôler explicitement les métadonnées « pas de vérification » de la présentation, y compris son état [NullableBool.NotDefined](https://reference.aspose.com/slides/fr/python-java/aspose.slides/nullablebool/#NotDefined). Si vous définissez les deux propriétés, maintenez leurs valeurs cohérentes ; ne combinez pas [setSpellCheck](https://reference.aspose.com/slides/fr/python-java/aspose.slides/baseportionformat/#setSpellCheck) à `True` avec [setProofDisabled](https://reference.aspose.com/slides/fr/python-java/aspose.slides/baseportionformat/#setProofDisabled) à l’état [NullableBool.True](https://reference.aspose.com/slides/fr/python-java/aspose.slides/nullablebool/#True).

Ces propriétés configurent les métadonnées de vérification utilisées par PowerPoint et d’autres applications de présentation. Aspose.Slides ne les utilise pas pour exécuter une vérification orthographique basée sur un dictionnaire ou renvoyer une liste de mots mal orthographiés.

L’exemple complet suivant crée une présentation d’entrée, la charge, attribue des paramètres de vérification orthographique et des langues de vérification différents à deux portions du même paragraphe, enregistre le résultat, le rouvre et vérifie les valeurs stockées :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Portion, Presentation, SaveFormat, ShapeType

input_file = "spell_check_input.pptx"
output_file = "spell_check_settings.pptx"

source_presentation = Presentation()
try:
    source_slide = source_presentation.getSlides().get_Item(0)
    source_shape = source_slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 80)
    source_paragraph = source_shape.getTextFrame().getParagraphs().get_Item(0)
    source_paragraph.getPortions().clear()

    source_english_portion = Portion("Check this text. ")
    source_english_portion.getPortionFormat().setLanguageId("en-US")
    source_paragraph.getPortions().add(source_english_portion)

    source_french_portion = Portion("Ignorer ce code : ZX-81.")
    source_french_portion.getPortionFormat().setLanguageId("fr-FR")
    source_paragraph.getPortions().add(source_french_portion)

    source_presentation.save(input_file, SaveFormat.Pptx)
finally:
    source_presentation.dispose()

presentation = Presentation(input_file)
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    portions = shape.getTextFrame().getParagraphs().get_Item(0).getPortions()

    checked_portion = portions.get_Item(0)
    checked_portion.getPortionFormat().setLanguageId("en-US")
    checked_portion.getPortionFormat().setSpellCheck(True)

    suppressed_portion = portions.get_Item(1)
    suppressed_portion.getPortionFormat().setLanguageId("fr-FR")
    suppressed_portion.getPortionFormat().setSpellCheck(False)

    presentation.save(output_file, SaveFormat.Pptx)
finally:
    presentation.dispose()

reopened_presentation = Presentation(output_file)
try:
    reopened_shape = reopened_presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    stored_portions = reopened_shape.getTextFrame().getParagraphs().get_Item(0).getPortions()

    first_portion_stored = stored_portions.getCount() == 2 and stored_portions.get_Item(0).getPortionFormat().getLanguageId() == "en-US" and stored_portions.get_Item(0).getPortionFormat().getSpellCheck()

    second_portion_stored = stored_portions.getCount() == 2 and stored_portions.get_Item(1).getPortionFormat().getLanguageId() == "fr-FR" and not stored_portions.get_Item(1).getPortionFormat().getSpellCheck()

    if first_portion_stored and second_portion_stored:
        print("The proofing settings were stored correctly.")
    else:
        print("The proofing settings could not be verified.")

finally:
    reopened_presentation.dispose()
```

[Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/#joinPortionsWithSameFormatting) combine les portions adjacentes qui ont le même formatage. Une différence dans [BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/fr/python-java/aspose.slides/baseportionformat/#setSpellCheck) seule ne maintient pas ces portions séparées ; après leur fusion, la portion résultante conserve la valeur [BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/fr/python-java/aspose.slides/baseportionformat/#setSpellCheck) de la première portion. Si les portions nécessitent des paramètres de vérification orthographique différents, appelez [joinPortionsWithSameFormatting](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/#joinPortionsWithSameFormatting) avant d’attribuer ces paramètres, ou inspectez les frontières de la portion résultante et réappliquez les paramètres par la suite. Les portions avec des valeurs différentes de [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/fr/python-java/aspose.slides/baseportionformat/#setLanguageId) restent séparées car leur formatage de langue de vérification diffère.

## **FAQ**

**Un identifiant de langue traduit-il le texte ?**

Non. [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/fr/python-java/aspose.slides/baseportionformat/#setLanguageId) stocke les métadonnées de vérification pour l’orthographe et la grammaire ; il ne modifie pas le contenu du texte. Traduisez le texte séparément, puis définissez l’identifiant de langue approprié pour chaque portion traduite.

**La langue de vérification contrôle-t-elle les polices, la césure ou le retour à la ligne ?**

Non. L’identifiant de langue sert à la vérification. Le rendu du texte et la mise en page dépendent principalement des [fonts](/slides/fr/python-java/powerpoint-fonts/) disponibles, du système d’écriture et des paramètres du cadre de texte. Pour un rendu fiable, fournissez les polices requises, configurez la [font substitution](/slides/fr/python-java/font-substitution/) ou [embed fonts](/slides/fr/python-java/embedded-font/) dans la présentation.

**Un paragraphe peut-il utiliser plusieurs langues de vérification ?**

Oui. Assignez chaque langue à une portion distincte, comme le montre l’exemple de paragraphe multilingue.

**Dois-je utiliser [setDefaultTextLanguage](https://reference.aspose.com/slides/fr/python-java/aspose.slides/loadoptions/#setDefaultTextLanguage) ou [setLanguageId](https://reference.aspose.com/slides/fr/python-java/aspose.slides/baseportionformat/#setLanguageId) ?**

Utilisez [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/fr/python-java/aspose.slides/loadoptions/#setDefaultTextLanguage) lorsque vous souhaitez une langue par défaut pour le texte nouvellement créé. Utilisez [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/fr/python-java/aspose.slides/baseportionformat/#setLanguageId) lorsqu’une portion spécifique nécessite une langue de vérification explicite ou lorsqu’un paragraphe contient plusieurs langues.