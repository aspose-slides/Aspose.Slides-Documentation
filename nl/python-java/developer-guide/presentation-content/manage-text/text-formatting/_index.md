---
title: Tekst opmaken in presentaties met Python via Java
linktitle: Tekstopmaak
type: docs
weight: 50
url: /nl/python-java/text-formatting/
keywords:
- alinea uitlijnen
- tekststijl
- tekstachtergrond
- teksttransparantie
- tekenafstand
- lettertype-eigenschappen
- lettertypefamilie
- tekstrotatie
- rotatiehoek
- tekstframe
- regelafstand
- autofit eigenschap
- tekstframe anker
- teksttabulatie
- standaardtaal
- PowerPoint
- OpenDocument
- presentatie
- Python
- Java
- Aspose.Slides
description: "Formatteer en styleer tekst in PowerPoint- en OpenDocument-presentaties met Aspose.Slides voor Python via Java. Pas lettertypen, kleuren, uitlijning en meer aan."
---
## **Overzicht**

Dit artikel laat zien hoe je tekst opmaakt in PowerPoint‑ en OpenDocument‑presentaties met Aspose.Slides voor Python via Java. Het behandelt achtergrondkleuren, transparantie, tekenafstand, lettertype‑eigenschappen, rotatie, alinea‑afstand, autofit‑gedrag, tekst‑ankering, tab‑stops en taalinstellingen.

In de voorbeelden hieronder gebruiken we een bestand met de naam "sample.pptx", dat een enkele tekstvak op de eerste dia bevat met de volgende tekst:

![Sample text](sample_text.png)

Om letterlijke tekst of reguliere‑expressie‑overeenkomsten te vinden en te markeren, zie [Search and Replace Text](/slides/nl/python-java/search-and-replace-text/).

## **Achtergrondkleur van tekst instellen**

Gebruik [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/nl/python-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) om de standaard markeringskleur voor een alinea in te stellen, of gebruik [PortionFormat.getHighlightColor](https://reference.aspose.com/slides/nl/python-java/aspose.slides/portionformat/) voor individuele tekstgedeelten.

Het volgende code‑voorbeeld toont hoe je de achtergrondkleur voor de **hele alinea** instelt:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat
from java.awt import Color

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # Stel de markeringskleur in voor de hele alinea.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY)

    presentation.save("gray_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Het resultaat:

![The gray paragraph](gray_paragraph.png)

Het code‑voorbeeld hieronder laat zien hoe je de achtergrondkleur instelt voor **tekstgedeelten met een vet lettertype**:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat
from java.awt import Color

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    for portion in paragraph.getPortions():
        if portion.getPortionFormat().getEffective().getFontBold():
            # Stel de markeringskleur in voor het tekstgedeelte.
            portion.getPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY)

    presentation.save("gray_text_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Het resultaat:

![The gray text portions](gray_text_portions.png)

## **Tekst‑alinea’s uitlijnen**

Gebruik [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/nl/python-java/aspose.slides/paragraphformat/#setAlignment) om alinea‑uitlijning binnen een tekstframe in te stellen. De waarde kan gecentreerd, links uitgelijnd, rechts uitgelijnd, uitgevuld, enzovoort zijn.

Het volgende code‑voorbeeld toont hoe je de alinea uitlijnt naar het **midden**:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TextAlignment

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # Stel de uitlijning van de alinea in op gecentreerd.
    paragraph.getParagraphFormat().setAlignment(TextAlignment.Center)

    presentation.save("aligned_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Het resultaat:

![The aligned paragraph](aligned_paragraph.png)

## **Transparantie van tekst instellen**

Teksttransparantie wordt geregeld via het alfacomponent van de kleur die is toegewezen aan [PortionFormat.getFillFormat](https://reference.aspose.com/slides/nl/python-java/aspose.slides/portionformat/). In de onderstaande voorbeelden is `alpha = 50` een ARGB‑alfakanaalwaarde op de schaal 0–255, geen transparantie‑percentage.

Het code‑voorbeeld hieronder toont hoe je transparantie toepast op de **hele alinea**:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

alpha = 50
text_color = Color(0, 0, 0, alpha)

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # Stel de opvulkleur van de tekst in op een transparante kleur.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(text_color)

    presentation.save("transparent_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Het resultaat:

![The transparent paragraph](transparent_paragraph.png)

Het volgende code‑voorbeeld toont hoe je transparantie toepast op **tekstgedeelten met een vet lettertype**:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

alpha = 50
text_color = Color(0, 0, 0, alpha)

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    for portion in paragraph.getPortions():
        if portion.getPortionFormat().getEffective().getFontBold():
            # Stel de transparantie van het tekstgedeelte in.
            portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
            portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(text_color)

    presentation.save("transparent_text_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Het resultaat:

![The transparent text portions](transparent_text_portions.png)

## **Tekenafstand voor tekst instellen**

Gebruik [PortionFormat.setSpacing](https://reference.aspose.com/slides/nl/python-java/aspose.slides/portionformat/) om de spatiëring tussen tekens in een tekstvak uit te breiden of te verkleinen.

De volgende Python‑code toont hoe je de tekenafstand uitbreidt in de **hele alinea**:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # Opmerking: Gebruik negatieve waarden om de tekenafstand te comprimeren.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3) # Vergroot de tekenafstand.

    presentation.save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Het resultaat:

![The character spacing in the paragraph](character_spacing_in_paragraph.png)

Het code‑voorbeeld hieronder toont hoe je de tekenafstand uitbreidt in **tekstgedeelten met een vet lettertype**:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    for portion in paragraph.getPortions():
        if portion.getPortionFormat().getEffective().getFontBold():
            # Opmerking: Gebruik negatieve waarden om de tekenafstand te comprimeren.
            portion.getPortionFormat().setSpacing(3) # Vergroot de tekenafstand.

    presentation.save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Het resultaat:

![The character spacing in the text portions](character_spacing_in_text_portions.png)

### **Kerning uitschakelen voor specifieke lettertypes**

In sommige gevallen kan tekst die door Aspose.Slides wordt gerenderd iets strakker lijken dan dezelfde tekst die in PowerPoint wordt weergegeven. Dit kan gebeuren omdat PowerPoint kerning‑gegevens voor bepaalde lettertypes negeert, zelfs wanneer het lettertype geldige kerning‑informatie bevat en kerning is ingeschakeld in de PowerPoint‑instellingen.

Om de gerenderde uitvoer in dergelijke gevallen dichter bij PowerPoint te brengen, kun je kerning uitschakelen voor tekstgedeelten die het betreffende lettertype gebruiken. Stel [PortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/nl/python-java/aspose.slides/portionformat/) in op een waarde die aanzienlijk groter is dan de werkelijke lettergrootte:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().get_Item(0)
    target_font = "Roboto"

    for paragraph in auto_shape.getTextFrame().getParagraphs():
        for portion in paragraph.getPortions():
            portion_format = portion.getPortionFormat()
            fonts = (portion_format.getLatinFont(), portion_format.getEastAsianFont(), portion_format.getComplexScriptFont())
            if any(font is not None and font.getFontName() == target_font for font in fonts):
                portion_format.setKerningMinimalSize(100)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Lettertype‑eigenschappen van tekst beheren**

De volgende code stelt het lettertype en de tekststijl in voor de hele alinea: het past lettergrootte, vet, cursief, gestippelde onderstreping en het Times New Roman‑lettertype toe op alle gedeelten in de alinea.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, NullableBool, Presentation, SaveFormat, TextUnderlineType

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # Stel de lettertype‑eigenschappen in voor de alinea.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(12)
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontBold(NullableBool.True_)
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontItalic(NullableBool.True_)
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontUnderline(TextUnderlineType.Dotted)
    font = FontData("Times New Roman")
    paragraph.getParagraphFormat().getDefaultPortionFormat().setLatinFont(font)

    presentation.save("font_properties_for_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Het resultaat:

![The font properties for the paragraph](font_properties_for_paragraph.png)

Het code‑voorbeeld hieronder past vergelijkbare eigenschappen toe op **tekstgedeelten met een vet lettertype**:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, NullableBool, Presentation, SaveFormat, TextUnderlineType

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    for portion in paragraph.getPortions():
        if portion.getPortionFormat().getEffective().getFontBold():
            # Stel de lettertype‑eigenschappen in voor het tekstgedeelte.
            portion.getPortionFormat().setFontHeight(13)
            portion.getPortionFormat().setFontItalic(NullableBool.True_)
            portion.getPortionFormat().setFontUnderline(TextUnderlineType.Dotted)
            font = FontData("Times New Roman")
            portion.getPortionFormat().setLatinFont(font)

    presentation.save("font_properties_for_text_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Het resultaat:

![The font properties for text portions](font_properties_for_text_portions.png)

## **Tekstrotatie instellen**

Gebruik [TextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/nl/python-java/aspose.slides/textframeformat/#setTextVerticalType) om een vooraf gedefinieerde tekstoriëntatie binnen een vorm in te stellen.

Het volgende code‑voorbeeld stelt de tekstoriëntatie in de vorm in op `Vertical270`, wat de tekst **90 graden tegen de klok in** roteert:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TextVerticalType

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().get_Item(0)

    auto_shape.getTextFrame().getTextFrameFormat().setTextVerticalType(TextVerticalType.Vertical270)

    presentation.save("text_rotation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Het resultaat:

![The text rotation](text_rotation.png)

## **Aangepaste rotatie voor tekstframes instellen**

Gebruik [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/nl/python-java/aspose.slides/textframeformat/#setRotationAngle) om een aangepaste rotatiehoek voor een [TextFrame](https://reference.aspose.com/slides/nl/python-java/aspose.slides/textframe/) in te stellen.

Het code‑voorbeeld hieronder roteert het tekstframe met 3 graden met de klok mee binnen de vorm:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().get_Item(0)

    auto_shape.getTextFrame().getTextFrameFormat().setRotationAngle(3)

    presentation.save("custom_text_rotation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Het resultaat:

![The custom text rotation](custom_text_rotation.png)

## **Regelafstand van alinea’s instellen**

Aspose.Slides biedt [ParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/nl/python-java/aspose.slides/paragraphformat/#setSpaceAfter), [ParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/nl/python-java/aspose.slides/paragraphformat/#setSpaceBefore) en [ParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/nl/python-java/aspose.slides/paragraphformat/#setSpaceWithin) om alinea‑afstand te regelen. Deze eigenschappen worden als volgt gebruikt:

* Gebruik een positieve waarde om de regelafstand op te geven als een percentage van de regelhoogte.
* Gebruik een negatieve waarde om de regelafstand in punten op te geven.

Het volgende code‑voorbeeld toont hoe je de regelafstand binnen de alinea specificeert:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    paragraph.getParagraphFormat().setSpaceWithin(200)

    presentation.save("line_spacing.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Het resultaat:

![The line spacing within the paragraph](line_spacing.png)

## **Autofit‑type voor tekstframes instellen**

[TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/nl/python-java/aspose.slides/textframeformat/#setAutofitType) bepaalt hoe tekst zich gedraagt wanneer deze de grenzen van de container overschrijdt. Gebruik het om te bepalen of de tekst verkleint, overlapt of de vorm automatisch van grootte verandert.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TextAutofitType

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().get_Item(0)

    auto_shape.getTextFrame().getTextFrameFormat().setAutofitType(TextAutofitType.Shape)

    presentation.save("autofit_type.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Om het aantal regels te tellen na automatisch afbreken en te zien hoe de breedte van tekst of vorm het resultaat verandert, zie [Count Rendered Lines](/slides/nl/python-java/manage-paragraph/). Het aantal regels alleen geeft niet aan of tekst buiten de container overlapt.

## **Anker van tekstframes instellen**

[TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/nl/python-java/aspose.slides/textframeformat/#setAnchoringType) bepaalt hoe tekst verticaal binnen een vorm wordt gepositioneerd, bijvoorbeeld bovenaan, in het midden of onderaan.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TextAnchorType

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().get_Item(0)

    auto_shape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Bottom)

    presentation.save("text_anchor.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Tabulatie van tekst instellen**

Gebruik [ParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/nl/python-java/aspose.slides/paragraphformat/#setDefaultTabSize) en [ParagraphFormat.getTabs](https://reference.aspose.com/slides/nl/python-java/aspose.slides/paragraphformat/#getTabs) om tab‑stops in een alinea te configureren.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TabAlignment

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    paragraph.getParagraphFormat().setDefaultTabSize(100)
    paragraph.getParagraphFormat().getTabs().add(30, TabAlignment.Left)

    presentation.save("paragraph_tabs.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Het resultaat:

![The paragraph tabs](paragraph_tabs.png)

## **Controlertaal instellen**

Aspose.Slides biedt [PortionFormat.setLanguageId](https://reference.aspose.com/slides/nl/python-java/aspose.slides/portionformat/), waarmee je de controlertaal voor een tekstgedeelte kunt instellen. De controlertaal bepaalt de taal die wordt gebruikt voor spelling‑ en grammaticacontrole in PowerPoint.

Het volgende code‑voorbeeld toont hoe je de controlertaal instelt voor een tekstgedeelte:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, Portion, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().get_Item(0)

    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)
    paragraph.getPortions().clear()

    font = FontData("SimSun")

    text_portion = Portion()
    text_portion.getPortionFormat().setComplexScriptFont(font)
    text_portion.getPortionFormat().setEastAsianFont(font)
    text_portion.getPortionFormat().setLatinFont(font)

    # Stel de Id van een controle-taal in.
    text_portion.getPortionFormat().setLanguageId("zh-CN")

    text_portion.setText("1。")
    paragraph.getPortions().add(text_portion)

    presentation.save("proofing_language.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Standaardtaal instellen**

Gebruik [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/nl/python-java/aspose.slides/loadoptions/#setDefaultTextLanguage) om de standaardtaal te definiëren voor tekst die wordt aangemaakt tijdens het laden of maken van een presentatie.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, ShapeType

load_options = LoadOptions()
load_options.setDefaultTextLanguage("en-US")

presentation = Presentation(load_options)
try:
    slide = presentation.getSlides().get_Item(0)

    # Voeg een rechthoekvorm toe met tekst.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 50)
    shape.getTextFrame().setText("Sample text")

    # Controleer de taal van het eerste tekstgedeelte.
    portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    print(portion.getPortionFormat().getLanguageId())
finally:
    presentation.dispose()
```

## **Standaard‑tekststijl instellen**

Om standaard‑tekstopmaak op presentatieniveau toe te passen, gebruik je [Presentation.getDefaultTextStyle](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/#getDefaultTextStyle).

Het volgende code‑voorbeeld toont hoe je een standaard vet lettertype met een grootte van 14 pt instelt voor alle tekst op alle dia's in een nieuwe presentatie.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, Presentation, SaveFormat

presentation = Presentation()
try:
    # Haal het alineaformaat van het hoogste niveau op.
    paragraph_format = presentation.getDefaultTextStyle().getLevel(0)

    if paragraph_format is not None:
        paragraph_format.getDefaultPortionFormat().setFontHeight(14)
        paragraph_format.getDefaultPortionFormat().setFontBold(NullableBool.True_)

    presentation.save("default_text_style.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Tekst extraheren met het All‑Caps‑effect**

In PowerPoint zorgt het toepassen van het **All Caps**‑font‑effect ervoor dat tekst in hoofdletters wordt weergegeven op de dia, zelfs als deze oorspronkelijk in kleine letters is getypt. Wanneer je zo'n tekstgedeelte ophaalt met Aspose.Slides, geeft de bibliotheek de tekst precies terug zoals ingevoerd. Om overeen te komen met de weergegeven tekst, controleer je [TextCapType](https://reference.aspose.com/slides/nl/python-java/aspose.slides/textcaptype/) en zet je de geretourneerde string om naar hoofdletters wanneer de waarde `All` is.

Stel dat we het volgende tekstvak hebben op de eerste dia van het bestand sample2.pptx.

![The All Caps effect](all_caps_effect.png)

Het code‑voorbeeld hieronder toont hoe je de tekst extraheert met het **All Caps**‑effect toegepast:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, TextCapType

presentation = Presentation("sample2.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().get_Item(0)
    text_portion = auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)

    print("Original text: " + str(text_portion.getText()))

    text_format = text_portion.getPortionFormat().getEffective()
    if text_format.getTextCapType() == TextCapType.All:
        text = str(text_portion.getText()).upper()
        print("All-Caps effect: " + text)
finally:
    presentation.dispose()
```

Output:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **FAQ**

**Hoe wijzig ik tekst in een tabel op een dia?**

Om tekst in een tabel op een dia te wijzigen, gebruik je [Table](https://reference.aspose.com/slides/nl/python-java/aspose.slides/table/). Loop door de cellen en werk elke cel bij via [Cell.getTextFrame](https://reference.aspose.com/slides/nl/python-java/aspose.slides/cell/#getTextFrame) en alinea‑opmaak via [Paragraph.getParagraphFormat](https://reference.aspose.com/slides/nl/python-java/aspose.slides/paragraph/#getParagraphFormat).

**Hoe pas ik een kleurverloop toe op tekst op een PowerPoint‑dia?**

Om een kleurverloop op tekst toe te passen, gebruik je [PortionFormat.getFillFormat](https://reference.aspose.com/slides/nl/python-java/aspose.slides/portionformat/). Stel [FillFormat.setFillType](https://reference.aspose.com/slides/nl/python-java/aspose.slides/fillformat/#setFillType) in op [FillType.Gradient](https://reference.aspose.com/slides/nl/python-java/aspose.slides/filltype/#Gradient) en configureer de gradient‑stops, richting en transparantie.