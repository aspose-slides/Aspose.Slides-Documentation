---
title: Automatiseer Presentatielocalisatie met Python
linktitle: Presentatielocalisatie
type: docs
weight: 100
url: /nl/python-net/presentation-localization/
keywords:
  - taal wijzigen
  - spellingcontrole
  - spellingcontrole onderdrukken
  - proefleestaal
  - taal-id
  - meertalige tekst
  - PowerPoint
  - presentatie
  - Python
  - Aspose.Slides
description: "Stel proefleestalen in voor PowerPoint- en OpenDocument-presentatietekst in Python met Aspose.Slides, inclusief standaardinstellingen en meertalige alinea's."
---
## **Overzicht**

Aspose.Slides for Python via .NET maakt het mogelijk om proefleesmetadata te configureren voor individuele tekstgedeelten. Gebruik [BasePortionFormat.language_id](https://reference.aspose.com/slides/nl/python-net/aspose.slides/baseportionformat/language_id/) om de proefleestaal te identificeren, [BasePortionFormat.spell_check](https://reference.aspose.com/slides/nl/python-net/aspose.slides/baseportionformat/spell_check/) om spellingcontroles toe te staan of te onderdrukken, en [BasePortionFormat.proof_disabled](https://reference.aspose.com/slides/nl/python-net/aspose.slides/baseportionformat/proof_disabled/) om de bredere “geen‑proef”‑status te regelen. Omdat deze instellingen op het gedeelte‑niveau worden toegepast, kan één alinea meerdere talen en verschillende proefleesregels bevatten.

Dit artikel legt uit hoe je een taal toewijst aan specifieke tekst, de standaardtaal instelt voor nieuwe tekst met [LoadOptions.default_text_language](https://reference.aspose.com/slides/nl/python-net/aspose.slides/loadoptions/default_text_language/), meertalige alinea’s bouwt, kiest tussen `spell_check` en `proof_disabled`, en de beoogde instellingen behoudt bij het gebruik van [Presentation.join_portions_with_same_formatting](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/join_portions_with_same_formatting/). Deze eigenschappen slaan metadata op voor presentatietoepassingen; ze vertalen de tekst niet, voeren geen woordenboek‑gebaseerde spellingcontrole uit, en geven geen fout gespelde woorden terug.

## **De proefleestaal voor tekst instellen**

Maak of laad een [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/), krijg toegang tot het gewenste tekstgedeelte via [Portion.portion_format](https://reference.aspose.com/slides/nl/python-net/aspose.slides/portion/portion_format/), en wijs de taal‑identifier toe. Het volgende voorbeeld maakt een vorm, stelt Britisch Engels in als proefleestaal, en slaat het resultaat op met [Presentation.save](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/save/):

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

## **Standaardtaal voor nieuwe tekst instellen**

Gebruik [LoadOptions.default_text_language](https://reference.aspose.com/slides/nl/python-net/aspose.slides/loadoptions/default_text_language/) om de proefleestaal op te geven die Aspose.Slides toekent aan nieuw aangemaakte tekst. Deze instelling is handig wanneer de meeste of alle nieuwe tekst in een presentatie dezelfde taal gebruikt. Hij wijzigt niet de taal‑metadata van tekst die al een expliciete taal heeft.

Het volgende voorbeeld maakt een presentatie waarvan de nieuwe tekst Duitse proefleesregels hanteert:

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.default_text_language = "de-DE"

with slides.Presentation(load_options) as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 320, 80)
    shape.text_frame.text = "Willkommen zur Präsentation"

    presentation.save("default_text_language.pptx", slides.export.SaveFormat.PPTX)
```

## **Meerdere talen in één alinea gebruiken**

Een [Paragraph](https://reference.aspose.com/slides/nl/python-net/aspose.slides/paragraph/) bevat een collectie tekstgedeelten. Maak voor elke taal een apart [Portion](https://reference.aspose.com/slides/nl/python-net/aspose.slides/portion/) en stel diens `language_id` onafhankelijk in.

Dit voorbeeld creëert één alinea met Engelse en Franse gedeelten:

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

## **Spellingcontrole voor individuele gedeelten in- of uitschakelen**

[PortionFormat](https://reference.aspose.com/slides/nl/python-net/aspose.slides/portionformat/) erft de algemene tekst‑eigenschappen die gedefinieerd worden door [BasePortionFormat](https://reference.aspose.com/slides/nl/python-net/aspose.slides/baseportionformat/). Benader het formaat van een gedeelte via [Portion.portion_format](https://reference.aspose.com/slides/nl/python-net/aspose.slides/portion/portion_format/) en stel [BasePortionFormat.spell_check](https://reference.aspose.com/slides/nl/python-net/aspose.slides/baseportionformat/spell_check/) in om te bepalen of een presentatietoepassing spelling mag controleren voor dat gedeelte. De standaardwaarde is `False`: `True` staat spellingcontrole toe, `False` onderdrukt deze.

De instelling geldt voor individuele tekstgedeelten. Verschillende gedeelten in dezelfde alinea kunnen dus verschillende waarden hebben. [BasePortionFormat.language_id](https://reference.aspose.com/slides/nl/python-net/aspose.slides/baseportionformat/language_id/) en `spell_check` dienen complementaire doelen: `language_id` identificeert de proefleestaal, terwijl `spell_check` bepaalt of spellingcontroles voor het gedeelte zijn toegestaan.

[BasePortionFormat.proof_disabled](https://reference.aspose.com/slides/nl/python-net/aspose.slides/baseportionformat/proof_disabled/) regelt ook proeflezen, maar vertegenwoordigt de bredere “niet‑proeven”‑status als een [NullableBool](https://reference.aspose.com/slides/nl/python-net/aspose.slides/nullablebool/). Gebruik `spell_check` wanneer je een directe Boolean‑schakelaar nodig hebt specifiek voor spellingcontroles. Gebruik `proof_disabled` wanneer je de “geen‑proef” metadata van de presentatie wilt behouden of expliciet wilt beheren, inclusief de `NOT_DEFINED`‑status. Als je beide eigenschappen instelt, houd hun waarden consistent; combineer `spell_check = True` niet met `proof_disabled = slides.NullableBool.TRUE`.

Deze eigenschappen configureren proefleesmetadata die gebruikt wordt door PowerPoint en andere presentatietoepassingen. Aspose.Slides gebruikt ze niet om woordenboek‑gebaseerde spellingcontroles uit te voeren of een lijst met fout gespelde woorden terug te geven.

Het volgende volledige voorbeeld maakt een invoer‑presentatie, laadt deze, kent verschillende spelling‑controle‑instellingen en proefleestalen toe aan twee gedeelten in dezelfde alinea, slaat het resultaat op, opent het opnieuw, en controleert de opgeslagen waarden:

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

[Presentation.join_portions_with_same_formatting](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/join_portions_with_same_formatting/) combineert aangrenzende gedeelten die dezelfde opmaak hebben. Een verschil alleen in `spell_check` houdt dergelijke gedeelten niet gescheiden; nadat ze zijn samengevoegd, behoudt het resulterende gedeelte de `spell_check`‑waarde van het eerste gedeelte. Als gedeelten verschillende spelling‑controle‑instellingen nodig hebben, roep `join_portions_with_same_formatting` aan voordat je die instellingen toewijst, of inspecteer de resulterende grenzen en pas de instellingen daarna opnieuw toe. Gedeelten met verschillende `language_id`‑waarden blijven gescheiden omdat hun proefleestaal‑opmaak verschilt.

## **FAQ**

**Zet een taal‑ID de tekst om?**

Nee. [BasePortionFormat.language_id](https://reference.aspose.com/slides/nl/python-net/aspose.slides/baseportionformat/language_id/) slaat proefleesmetadata op voor spelling en grammatica; het verandert de inhoud van de tekst niet. Vertaal de tekst apart en stel daarna de juiste taal‑identifier in voor elk vertaald gedeelte.

**Bepaalt de proefleestaal lettertypen, afbreking of regeleinden?**

Nee. De taal‑identifier is enkel voor proeflezen. Tekstweergave en lay‑out zijn voornamelijk afhankelijk van de beschikbare [fonts](/slides/nl/python-net/powerpoint-fonts/), het schrift, en de instellingen van het tekst‑frame. Zorg voor de benodigde lettertypen, configureer [font substitution](/slides/nl/python-net/font-substitution/), of [embed fonts](/slides/nl/python-net/embedded-font/) in de presentatie voor een betrouwbare weergave.

**Kan één alinea meerdere proefleestalen gebruiken?**

Ja. Wijs elke taal toe aan een apart gedeelte, zoals getoond in het voorbeeld van een meertalige alinea.

**Moet ik `default_text_language` of `language_id` gebruiken?**

Gebruik [LoadOptions.default_text_language](https://reference.aspose.com/slides/nl/python-net/aspose.slides/loadoptions/default_text_language/) wanneer je een standaard wilt voor nieuw aangemaakte tekst. Gebruik [BasePortionFormat.language_id](https://reference.aspose.com/slides/nl/python-net/aspose.slides/baseportionformat/language_id/) wanneer een specifiek gedeelte een expliciete proefleestaal nodig heeft of wanneer een alinea meerdere talen bevat.