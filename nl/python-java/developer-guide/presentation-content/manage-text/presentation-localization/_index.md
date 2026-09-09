---
title: Automatiseer presentatie‑lokalisatie in Python via Java
linktitle: Presentatie lokalisatie
type: docs
weight: 100
url: /nl/python-java/presentation-localization/
keywords:
- taal wijzigen
- spellingcontrole
- spellingcontrole onderdrukken
- proefleestaal
- taal-ID
- meertalige tekst
- PowerPoint
- presentatie
- Python
- Java
- Aspose.Slides
description: "Stel proefleestalen in voor PowerPoint- en OpenDocument‑presentatietekst in Python via Java met Aspose.Slides, inclusief standaarden en meertalige alinea's."
---
## **Overzicht**

Aspose.Slides for Python via Java stelt u in staat om proefleesmmetadata voor afzonderlijke tekstgedeelten te configureren. Gebruik [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/nl/python-java/aspose.slides/baseportionformat/#setLanguageId) om de proefleestaal te identificeren, [BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/nl/python-java/aspose.slides/baseportionformat/#setSpellCheck) om spellingcontroles toe te staan of te onderdrukken, en [BasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/nl/python-java/aspose.slides/baseportionformat/#setProofDisabled) om de bredere “niet‑proeflezen” status te beheren. Omdat deze instellingen op het gedeelte‑niveau worden toegepast, kan één alinea meerdere talen en verschillende proefleesregels bevatten.

Dit artikel legt uit hoe u een taal toewijst aan specifieke tekst, de standaardtaal voor nieuwe tekst instelt met [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/nl/python-java/aspose.slides/loadoptions/#setDefaultTextLanguage), meertalige alinea’s maakt, kiest tussen [BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/nl/python-java/aspose.slides/baseportionformat/#setSpellCheck) en [BasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/nl/python-java/aspose.slides/baseportionformat/#setProofDisabled), en de bedoelde instellingen behoudt bij gebruik van [Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/#joinPortionsWithSameFormatting). Deze eigenschappen slaan metadata op voor presentatietoepassingen; ze vertalen geen tekst, voeren geen op woordenboek gebaseerde spellingscontrole uit en geven geen foutieve woorden terug.

## **Stel de proefleestaal in voor tekst**

Maak of laad een [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/), krijg toegang tot het gewenste tekstgedeelte via [Portion.getPortionFormat](https://reference.aspose.com/slides/nl/python-java/aspose.slides/portion/#getPortionFormat) en wijs de taal‑identifier toe. Het volgende voorbeeld maakt een vorm, stelt Brits‑Engels in als proefleestaal en slaat het resultaat op met [Presentation.save](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/#save):

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

## **Stel de standaardtaal in voor nieuwe tekst**

Gebruik [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/nl/python-java/aspose.slides/loadoptions/#setDefaultTextLanguage) om de proefleestaal te specificeren die Aspose.Slides toekent aan nieuw aangemaakte tekst. Deze instelling is handig wanneer het merendeel of alle nieuwe tekst in een presentatie dezelfde taal gebruikt. Het wijzigt de taalmMetadata van tekst die al een expliciete taal heeft.

Het volgende voorbeeld maakt een presentatie waarvan nieuwe tekst Duitse proefleesregels gebruikt:

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

## **Gebruik meerdere talen in één alinea**

Een [Paragraph](https://reference.aspose.com/slides/nl/python-java/aspose.slides/paragraph/) bevat een verzameling tekstgedeelten. Maak een apart [Portion](https://reference.aspose.com/slides/nl/python-java/aspose.slides/portion/) voor elke taal en stel diens [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/nl/python-java/aspose.slides/baseportionformat/#setLanguageId) onafhankelijk in.

Dit voorbeeld maakt één alinea met Engelse en Franse gedeelten:

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

## **Inschakelen of onderdrukken van spellingcontrole voor afzonderlijke gedeelten**

[PortionFormat](https://reference.aspose.com/slides/nl/python-java/aspose.slides/portionformat/) erft de gemeenschappelijke tekst‑eigenschappen die door [BasePortionFormat](https://reference.aspose.com/slides/nl/python-java/aspose.slides/baseportionformat/) worden gedefinieerd. Verkrijg een gedeelte‑formaat via [Portion.getPortionFormat](https://reference.aspose.com/slides/nl/python-java/aspose.slides/portion/#getPortionFormat) en gebruik [BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/nl/python-java/aspose.slides/baseportionformat/#setSpellCheck) om te bepalen of een presentatietoepassing spelling mag controleren voor dat gedeelte. De standaardwaarde is `False`: `True` staat spellingcontrole toe, terwijl `False` deze onderdrukt.

De instelling geldt voor afzonderlijke tekstgedeelten. Verschillende gedeelten in dezelfde alinea kunnen dus verschillende waarden gebruiken. [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/nl/python-java/aspose.slides/baseportionformat/#setLanguageId) en [setSpellCheck](https://reference.aspose.com/slides/nl/python-java/aspose.slides/baseportionformat/#setSpellCheck) dienen complementaire doelen: [setLanguageId](https://reference.aspose.com/slides/nl/python-java/aspose.slides/baseportionformat/#setLanguageId) identificeert de proefleestaal, terwijl [setSpellCheck](https://reference.aspose.com/slides/nl/python-java/aspose.slides/baseportionformat/#setSpellCheck) bepaalt of spellingcontroles zijn toegestaan voor het gedeelte.

[BasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/nl/python-java/aspose.slides/baseportionformat/#setProofDisabled) regelt ook proeflezen, maar representeert de bredere “niet‑proeflezen” status als een [NullableBool](https://reference.aspose.com/slides/nl/python-java/aspose.slides/nullablebool/). Gebruik [setSpellCheck](https://reference.aspose.com/slides/nl/python-java/aspose.slides/baseportionformat/#setSpellCheck) wanneer u een directe Booleaanse schakelaar nodig heeft specifiek voor spellingcontroles. Gebruik [setProofDisabled](https://reference.aspose.com/slides/nl/python-java/aspose.slides/baseportionformat/#setProofDisabled) wanneer u de “niet‑proeflezen” metadata van de presentatie wilt behouden of expliciet wilt beheersen, inclusief de [NullableBool.NotDefined](https://reference.aspose.com/slides/nl/python-java/aspose.slides/nullablebool/#NotDefined) status. Als u beide eigenschappen instelt, houd hun waarden consistent; combineer niet [setSpellCheck](https://reference.aspose.com/slides/nl/python-java/aspose.slides/baseportionformat/#setSpellCheck) op `True` met [setProofDisabled](https://reference.aspose.com/slides/nl/python-java/aspose.slides/baseportionformat/#setProofDisabled) op de [NullableBool.True](https://reference.aspose.com/slides/nl/python-java/aspose.slides/nullablebool/#True) status.

Deze eigenschappen configureren proefleesmmetadata die door PowerPoint en andere presentatietoepassingen worden gebruikt. Aspose.Slides gebruikt ze niet om op woordenboek gebaseerde spellingcontroles uit te voeren of een lijst met foutieve woorden te retourneren.

Het volgende volledige voorbeeld maakt een invoer‑presentatie, laadt deze, wijst verschillende spelling‑ en proefleestaalinstellingen toe aan twee gedeelten in dezelfde alinea, slaat het resultaat op, opent het opnieuw en verifieert de opgeslagen waarden:

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

[Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/#joinPortionsWithSameFormatting) voegt aangrenzende gedeelten samen die dezelfde opmaak hebben. Een verschil in [BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/nl/python-java/aspose.slides/baseportionformat/#setSpellCheck) alleen houdt dergelijke gedeelten niet gescheiden; nadat ze zijn samengevoegd, behoudt het resulterende gedeelte de [BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/nl/python-java/aspose.slides/baseportionformat/#setSpellCheck) waarde van het eerste gedeelte. Als gedeelten verschillende spelling‑instellingen nodig hebben, roep dan [joinPortionsWithSameFormatting](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/#joinPortionsWithSameFormatting) aan voordat u die instellingen toewijst, of inspecteer de resulterende gedeelte‑grenzen en pas de instellingen daarna opnieuw toe. Gedeelten met verschillende [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/nl/python-java/aspose.slides/baseportionformat/#setLanguageId) waarden blijven gescheiden omdat hun proefleestaal‑opmaak verschilt.

## **FAQ**

**Vertaalt een taal‑ID de tekst?**

Nee. [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/nl/python-java/aspose.slides/baseportionformat/#setLanguageId) slaat proefleesmmetadata op voor spelling en grammatica; het wijzigt de tekstinhoud niet. Vertaal de tekst apart en stel daarna de juiste taal‑identifier in voor elk vertaald gedeelte.

**Beheerst de proefleestaal lettertypen, afbreking of regelterugloop?**

Nee. De taal‑identifier is uitsluitend voor proeflezen. Tekst‑rendering en lay‑out hangen vooral af van de beschikbare [fonts](/slides/nl/python-java/powerpoint-fonts/), het schrijfsysteem en de instellingen van het tekst‑frame. Voor betrouwbare weergave moet u de benodigde lettertypen leveren, [font substitution](/slides/nl/python-java/font-substitution/) configureren of [embed fonts](/slides/nl/python-java/embedded-font/) in de presentatie opnemen.

**Kan één alinea verschillende proefleestalen gebruiken?**

Ja. Ken elke taal toe aan een apart gedeelte, zoals getoond in het voorbeeld met een meertalige alinea.

**Moet ik [setDefaultTextLanguage](https://reference.aspose.com/slides/nl/python-java/aspose.slides/loadoptions/#setDefaultTextLanguage) of [setLanguageId](https://reference.aspose.com/slides/nl/python-java/aspose.slides/baseportionformat/#setLanguageId) gebruiken?**

Gebruik [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/nl/python-java/aspose.slides/loadoptions/#setDefaultTextLanguage) wanneer u een standaard wilt voor nieuw aangemaakte tekst. Gebruik [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/nl/python-java/aspose.slides/baseportionformat/#setLanguageId) wanneer een specifiek gedeelte een expliciete proefleestaal nodig heeft of wanneer een alinea meerdere talen bevat.