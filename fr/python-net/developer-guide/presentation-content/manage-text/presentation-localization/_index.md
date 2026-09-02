---
title: Automatiser la localisation de présentations avec Python
linktitle: Localisation de présentations
type: docs
weight: 100
url: /fr/python-net/presentation-localization/
keywords:
- changer de langue
- vérification orthographique
- supprimer la vérification orthographique
- langue de vérification
- identifiant de langue
- texte multilingue
- PowerPoint
- présentation
- Python
- Aspose.Slides
description: "Définir les langues de vérification pour le texte des présentations PowerPoint et OpenDocument en Python avec Aspose.Slides, y compris les valeurs par défaut et les paragraphes multilingues."
---
## **Vue d'ensemble**

Aspose.Slides for Python via .NET vous permet de configurer les métadonnées de vérification pour des portions de texte individuelles. Utilisez [BasePortionFormat.language_id](https://reference.aspose.com/slides/fr/python-net/aspose.slides/baseportionformat/language_id/) pour identifier la langue de vérification, [BasePortionFormat.spell_check](https://reference.aspose.com/slides/fr/python-net/aspose.slides/baseportionformat/spell_check/) pour autoriser ou supprimer la vérification orthographique, et [BasePortionFormat.proof_disabled](https://reference.aspose.com/slides/fr/python-net/aspose.slides/baseportionformat/proof_disabled/) pour contrôler l’état plus large « no‑proof ». Comme ces paramètres s’appliquent au niveau de la portion, un même paragraphe peut contenir plusieurs langues et différentes règles de vérification.

Cet article explique comment attribuer une langue à du texte spécifique, définir la langue par défaut pour le nouveau texte avec [LoadOptions.default_text_language](https://reference.aspose.com/slides/fr/python-net/aspose.slides/loadoptions/default_text_language/), créer des paragraphes multilingues, choisir entre `spell_check` et `proof_disabled`, et conserver les paramètres prévus lors de l’utilisation de [Presentation.join_portions_with_same_formatting](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/join_portions_with_same_formatting/). Ces propriétés stockent des métadonnées pour les applications de présentation ; elles ne traduisent pas le texte, n’effectuent pas de vérification orthographique basée sur un dictionnaire, et ne retournent pas les mots mal orthographiés.

## **Définir la langue de vérification pour le texte**

Créez ou chargez une [Presentation](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/), accédez à la portion de texte requise via [Portion.portion_format](https://reference.aspose.com/slides/fr/python-net/aspose.slides/portion/portion_format/), et attribuez son identifiant de langue. L’exemple suivant crée une forme, définit l’anglais britannique comme langue de vérification, puis enregistre le résultat avec [Presentation.save](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/save/):

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 320, 80)
    shape.text_frame.text = "Set the proofing language for this text."

    portion = shape.text_frame.paragraphs[0].portions[0]
    portion.portion_format.language_id = "en-GB"

    presentation.save("proofing_language.pptx", slides.export.SaveFormat.PPTX)
```

## **Définir la langue par défaut pour le nouveau texte**

Utilisez [LoadOptions.default_text_language](https://reference.aspose.com/slides/fr/python-net/aspose.slides/loadoptions/default_text_language/) pour spécifier la langue de vérification qu’Aspose.Slides affecte au texte nouvellement créé. Ce réglage est utile lorsque la plupart ou la totalité du texte nouveau d’une présentation utilise la même langue. Il ne modifie pas les métadonnées de langue du texte qui possède déjà une langue explicite.

L’exemple suivant crée une présentation dont le texte nouveau utilise les règles de vérification allemandes:

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.default_text_language = "de-DE"

with slides.Presentation(load_options) as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 320, 80)
    shape.text_frame.text = "Willkommen zur Präsentung"

    presentation.save("default_text_language.pptx", slides.export.SaveFormat.PPTX)
```

## **Utiliser plusieurs langues dans un même paragraphe**

Un [Paragraph](https://reference.aspose.com/slides/fr/python-net/aspose.slides/paragraph/) contient une collection de portions de texte. Créez une [Portion](https://reference.aspose.com/slides/fr/python-net/aspose.slides/portion/) distincte pour chaque langue et définissez son `language_id` indépendamment.

Cet exemple crée un paragraphe contenant des portions en anglais et en français:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 420, 80)
    paragraph = shape.text_frame.paragraphs[0]
    paragraph.portions.clear()

    english_portion = slides.Portion("Welcome")
    english_portion.portion_format.language_id = "en-US"
    paragraph.portions.add(english_portion)

    french_portion = slides.Portion(" — Bienvenue")
    french_portion.portion_format.language_id = "fr-FR"
    paragraph.portions.add(french_portion)

    presentation.save("multilingual_text.pptx", slides.export.SaveFormat.PPTX)
```

## **Activer ou supprimer la vérification orthographique pour des portions individuelles**

[PortionFormat](https://reference.aspose.com/slides/fr/python-net/aspose.slides/portionformat/) hérite des propriétés de texte communes définies par [BasePortionFormat](https://reference.aspose.com/slides/fr/python-net/aspose.slides/baseportionformat/). Accédez au format d’une portion via [Portion.portion_format](https://reference.aspose.com/slides/fr/python-net/aspose.slides/portion/portion_format/) et définissez [BasePortionFormat.spell_check](https://reference.aspose.com/slides/fr/python-net/aspose.slides/baseportionformat/spell_check/) pour contrôler si une application de présentation peut vérifier l’orthographe de cette portion. La valeur par défaut est `False` : `True` autorise la vérification, tandis que `False` la supprime.

Le réglage s’applique aux portions de texte individuelles. Ainsi, différentes portions dans le même paragraphe peuvent utiliser des valeurs différentes. [BasePortionFormat.language_id](https://reference.aspose.com/slides/fr/python-net/aspose.slides/baseportionformat/language_id/) et `spell_check` remplissent des fonctions complémentaires : `language_id` identifie la langue de vérification, tandis que `spell_check` détermine si la vérification orthographique est autorisée pour la portion.

[BasePortionFormat.proof_disabled](https://reference.aspose.com/slides/fr/python-net/aspose.slides/baseportionformat/proof_disabled/) contrôle également la vérification, mais représente l’état plus large « ne pas vérifier » sous forme de [NullableBool](https://reference.aspose.com/slides/fr/python-net/aspose.slides/nullablebool/). Utilisez `spell_check` lorsque vous avez besoin d’un commutateur booléen direct spécifiquement pour les vérifications orthographiques. Utilisez `proof_disabled` lorsque vous devez préserver ou contrôler explicitement les métadonnées « no‑proof » de la présentation, y compris son état `NOT_DEFINED`. Si vous définissez les deux propriétés, maintenez leurs valeurs cohérentes ; ne combinez pas `spell_check = True` avec `proof_disabled = slides.NullableBool.TRUE`.

Ces propriétés configurent les métadonnées de vérification utilisées par PowerPoint et d’autres applications de présentation. Aspose.Slides ne les utilise pas pour exécuter une vérification orthographique basée sur un dictionnaire ni pour renvoyer une liste de mots mal orthographiés.

L’exemple complet suivant crée une présentation d’entrée, la charge, attribue différents réglages de vérification orthographique et langues de vérification à deux portions du même paragraphe, enregistre le résultat, le rouvre, puis vérifie les valeurs stockées:

```python
import aspose.slides as slides

input_file = "spell_check_input.pptx"
output_file = "spell_check_settings.pptx"

with slides.Presentation() as source_presentation:
    source_slide = source_presentation.slides[0]
    source_shape = source_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 420, 80)
    source_paragraph = source_shape.text_frame.paragraphs[0]
    source_paragraph.portions.clear()

    source_english_portion = slides.Portion("Check this text. ")
    source_english_portion.portion_format.language_id = "en-US"
    source_paragraph.portions.add(source_english_portion)

    source_french_portion = slides.Portion("Ignorer ce code : ZX-81.")
    source_french_portion.portion_format.language_id = "fr-FR"
    source_paragraph.portions.add(source_french_portion)

    source_presentation.save(input_file, slides.export.SaveFormat.PPTX)

with slides.Presentation(input_file) as presentation:
    shape = presentation.slides[0].shapes[0]
    portions = shape.text_frame.paragraphs[0].portions

    checked_portion = portions[0]
    checked_portion.portion_format.language_id = "en-US"
    checked_portion.portion_format.spell_check = True

    suppressed_portion = portions[1]
    suppressed_portion.portion_format.language_id = "fr-FR"
    suppressed_portion.portion_format.spell_check = False

    presentation.save(output_file, slides.export.SaveFormat.PPTX)

with slides.Presentation(output_file) as reopened_presentation:
    reopened_shape = reopened_presentation.slides[0].shapes[0]
    stored_portions = reopened_shape.text_frame.paragraphs[0].portions

    has_two_portions = stored_portions.count == 2

    first_portion_stored = (
        has_two_portions 
        and stored_portions[0].portion_format.language_id == "en-US" 
        and stored_portions[0].portion_format.spell_check
    )

    second_portion_stored = (
        has_two_portions
        and stored_portions[1].portion_format.language_id == "fr-FR" 
        and not stored_portions[1].portion_format.spell_check
    )

    if first_portion_stored and second_portion_stored:
        print("The proofing settings were stored correctly.")
    else:
        print("The proofing settings could not be verified.")
```

[Presentation.join_portions_with_same_formatting](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/join_portions_with_same_formatting/) combine les portions adjacentes qui ont le même formatage. Une différence uniquement sur `spell_check` ne suffit pas à garder ces portions séparées ; après la combinaison, la portion résultante conserve la valeur `spell_check` de la première portion. Si les portions nécessitent des réglages de vérification différents, appelez `join_portions_with_same_formatting` avant d’attribuer ces réglages, ou inspectez les limites de la portion résultante et réappliquez les réglages ensuite. Les portions avec des valeurs `language_id` différentes restent séparées parce que leur formatage de langue de vérification diffère.

## **FAQ**

**Un ID de langue traduit‑il le texte ?**

Non. [BasePortionFormat.language_id](https://reference.aspose.com/slides/fr/python-net/aspose.slides/baseportionformat/language_id/) stocke des métadonnées de vérification pour l’orthographe et la grammaire ; il ne modifie pas le contenu du texte. Traduisez le texte séparément, puis définissez l’identifiant de langue approprié pour chaque portion traduite.

**La langue de vérification contrôle‑t‑elle les polices, la césure ou le retour à la ligne ?**

Non. L’identifiant de langue concerne la vérification. Le rendu du texte et la mise en page dépendent principalement des [fonts](/slides/fr/python-net/powerpoint-fonts/), du système d’écriture et des paramètres du cadre de texte. Pour un rendu fiable, fournissez les polices nécessaires, configurez la [substitution de polices](/slides/fr/python-net/font-substitution/), ou [intégrez les polices](/slides/fr/python-net/embedded-font/) dans la présentation.

**Un paragraphe peut‑il utiliser plusieurs langues de vérification ?**

Oui. Attribuez chaque langue à une portion distincte, comme le montre l’exemple de paragraphe multilingue.

**Dois‑je utiliser `default_text_language` ou `language_id` ?**

Utilisez [LoadOptions.default_text_language](https://reference.aspose.com/slides/fr/python-net/aspose.slides/loadoptions/default_text_language/) lorsque vous voulez une langue par défaut pour le texte nouvellement créé. Utilisez [BasePortionFormat.language_id](https://reference.aspose.com/slides/fr/python-net/aspose.slides/baseportionformat/language_id/) lorsqu’une portion spécifique nécessite une langue de vérification explicite ou lorsqu’un paragraphe contient plusieurs langues.