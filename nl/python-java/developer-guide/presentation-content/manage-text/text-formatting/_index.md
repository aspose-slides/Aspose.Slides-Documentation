---
title: Tekst in presentaties formatteren in Python via Java
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
description: "Formatteer en styleer tekst in PowerPoint‑ en OpenDocument‑presentaties met Aspose.Slides voor Python via Java. Pas lettertypen, kleuren, uitlijning en meer aan."
---
## **Overzicht**

Dit artikel laat zien hoe u tekst kunt opmaken in PowerPoint‑ en OpenDocument‑presentaties met Aspose.Slides voor Python via Java. Het behandelt achtergrondkleuren, transparantie, tekenafstand, lettertype‑eigenschappen, rotatie, alinea‑afstand, autofit‑gedrag, tekstverankering, tabstops en taalinstellingen.

Tenzij anders vermeld, gebruiken de voorbeelden [sample.pptx](sample.pptx). De eerste vorm op de eerste dia is een tekstvak, en de eerste alinea bevat de hieronder getoonde tekst. Zowel dia‑ als vorm‑indices beginnen bij nul. Voorbeelden die vette delen selecteren gebruiken effectieve opmaak, inclusief geërfde vette opmaak:

![Voorbeeldtekst](sample_text.png)

Voor het vinden en markeren van letterlijke tekst of reguliere‑expressie‑overeenkomsten, zie [Zoeken en vervangen van tekst](/slides/nl/python-java/search-and-replace-text/).

## **Tekstachtergrondkleur instellen**

Gebruik [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) om de standaard markeerkleur voor een alinea in te stellen, of gebruik [BasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#getHighlightColor) voor individuele tekstgedeelten.

Het volgende voorbeeld stelt een lichtgrijze markering in als standaard voor de eerste alinea. Expliciete markeerkleuren op individuele gedeelten hebben voorrang boven deze standaard:

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

    # Stel de markeerkleur in voor de hele alinea.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY)

    presentation.save("gray_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Het resultaat:

![De grijze alinea](gray_paragraph.png)

Het onderstaande code‑voorbeeld laat zien hoe u de achtergrondkleur kunt instellen voor **tekstgedeelten met een vet lettertype**:

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
            # Stel de markeerkleur in voor het tekstgedeelte.
            portion.getPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY)

    presentation.save("gray_text_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Het resultaat:

![De grijze tekstgedeelten](gray_text_portions.png)

## **Tekst alinea’s uitlijnen**

Gebruik [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setAlignment) om alinea‑uitlijning binnen een tekstvak in te stellen. De waarde kan gecentreerd, links‑uitgelijnd, rechts‑uitgelijnd, uitgevuld, enz. zijn.

Het volgende code‑voorbeeld toont hoe u de alinea naar het **midden** kunt uitlijnen:

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

    # Stel de uitlijning van de alinea in op het midden.
    paragraph.getParagraphFormat().setAlignment(TextAlignment.Center)

    presentation.save("aligned_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Het resultaat:

![De uitgelijnde alinea](aligned_paragraph.png)

## **Lettertypen binnen een regel uitlijnen**

Gebruik [ParagraphFormat.setFontAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setFontAlignment) om tekstgedeelten van verschillende lettergroottes verticaal uit te lijnen binnen een regel. Deze instelling geldt voor de volledige alinea en bepaalt de uitlijning binnen elke regel.

Het volgende zelf‑contained voorbeeld maakt vier gelabelde tekstvakken op één dia. Elke alinea bevat dezelfde tekst in 18, 36 en 54 punten, met een andere lettertype‑uitlijning. Het gebruikt Arial, schakelt autofit en omloop uit, en houdt de tekstvakken groot genoeg voor één regel.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontAlignment, FontData, NullableBool, Paragraph, Portion, Presentation, SaveFormat, ShapeType, TextAlignment, TextAnchorType, TextAutofitType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    alignments = [FontAlignment.Baseline, FontAlignment.Top, FontAlignment.Center, FontAlignment.Bottom]
    alignment_names = ["Baseline", "Top", "Center", "Bottom"]
    font_sizes = [18.0, 36.0, 54.0]
    font = FontData("Arial")

    for i, alignment in enumerate(alignments):
        shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 20 + i * 130, 660, 120)
        shape.getFillFormat().setFillType(FillType.NoFill)
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)

        text_frame = shape.getTextFrame()
        text_frame.getTextFrameFormat().setAnchoringType(TextAnchorType.Top)
        text_frame.getTextFrameFormat().setAutofitType(TextAutofitType.None_)
        text_frame.getTextFrameFormat().setWrapText(NullableBool.False_)

        label = text_frame.getParagraphs().get_Item(0)
        label.setText(alignment_names[i])
        label.getParagraphFormat().setAlignment(TextAlignment.Left)
        label.getParagraphFormat().getDefaultPortionFormat().setFontHeight(14)
        label.getParagraphFormat().getDefaultPortionFormat().setLatinFont(font)
        label.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
        label.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)

        paragraph = Paragraph()
        paragraph.getParagraphFormat().setFontAlignment(alignment)
        paragraph.getParagraphFormat().setAlignment(TextAlignment.Left)
        paragraph.getParagraphFormat().getDefaultPortionFormat().setLatinFont(font)
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)

        for font_size in font_sizes:
            portion = Portion("Ag ")
            portion.getPortionFormat().setFontHeight(font_size)
            paragraph.getPortions().add(portion)

        text_frame.getParagraphs().add(paragraph)

    presentation.save("font_alignment.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Het resultaat:

![Vergelijking van baseline-, top-, centre‑ en onderkant‑lettertype‑uitlijning met gemengde lettergroottes](font_alignment.png)

Lettertype‑uitlijning gebruikt lettertype‑metriek, dus de zichtbare randen van individuele letters komen niet noodzakelijk precies op één lijn. Het voorbeeld bevat zowel een hoofdletter als een aflopende letter om het verschil tussen baseline‑ en onderkant‑uitlijning te laten zien. Beschikbaarheid en substitutie van lettertypen, de gebruikte tekens, en het verschil in lettergroottes beïnvloeden het resultaat. Frame‑dimensies, marges, alineaspatiëring, omloop en autofit hebben ook invloed op de lay‑out; gebruik dezelfde lettertypen en lay‑outinstellingen bij het vergelijken van de modi.

Deze instelling verschilt van [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setAlignment), die horizontale alinea‑uitlijning regelt, en van [TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setAnchoringType), die het tekstblok verticaal binnen de vorm positioneert. Superscript‑ en subscript‑opmaak via [BasePortionFormat.setEscapement](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setEscapement) verschuift individuele gedeelten ten opzichte van de baseline in plaats van de lettertype‑uitlijning voor de regels van de alinea in te stellen.

## **Transparantie voor tekst instellen**

Transparantie van tekst wordt geregeld via de alfa‑component van de kleur die aan [BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#getFillFormat) is toegewezen. In de onderstaande voorbeelden is `alpha = 50` een ARGB‑alfa‑waarde op de schaal 0‑255, geen transparantie‑percentage.

Het onderstaande code‑voorbeeld toont hoe u transparantie kunt toepassen op de **volle alinea**:

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

    # Stel de vulkleur van de tekst in op een transparante kleur.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(text_color)

    presentation.save("transparent_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Het resultaat:

![De transparante alinea](transparent_paragraph.png)

Het volgende code‑voorbeeld laat zien hoe u transparantie kunt toepassen op **tekstgedeelten met een vet lettertype**:

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

![De transparante tekstgedeelten](transparent_text_portions.png)

## **Tekenafstand voor tekst instellen**

Gebruik [BasePortionFormat.setSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setSpacing) om de afstand tussen tekens in een tekstvak uit te breiden of te verkleinen. De voorbeelden voegen 3 punten toe; negatieve waarden verkleinen de tekst.

Het volgende Python‑codevoorbeeld toont hoe u de tekenafstand in de **volle alinea** kunt uitbreiden:

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

![De tekenafstand in de alinea](character_spacing_in_paragraph.png)

Het onderstaande code‑voorbeeld laat zien hoe u de tekenafstand kunt uitbreiden in **tekstgedeelten met een vet lettertype**:

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

![De tekenafstand in de tekstgedeelten](character_spacing_in_text_portions.png)

### **Kerning voor specifieke lettertypen uitschakelen**

In sommige gevallen kan tekst die door Aspose.Slides wordt gerenderd iets strakker lijken dan dezelfde tekst in PowerPoint. Dit kan gebeuren omdat PowerPoint kerning‑gegevens voor bepaalde lettertypen negeert, zelfs wanneer het lettertype geldige kerning‑informatie bevat en kerning in de PowerPoint‑instellingen is ingeschakeld.

Om de weergave dichter bij PowerPoint te krijgen, kunt u kerning uitschakelen voor tekstgedeelten die het betreffende lettertype gebruiken. Stel [BasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setKerningMinimalSize) in op een waarde groter dan de werkelijke lettergrootte. Dit voorbeeld vereist “presentation.pptx” met een tekstvak als eerste vorm op de eerste dia. Het controleert effectieve lettertypen, inclusief geërfde lettertypen, en stelt een drempel van 100 punten in voor gedeelten die Roboto gebruiken. Daarmee wordt kerning uitgeschakeld voor overeenkomende gedeelten met een lettergrootte onder 100 punten:

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
            portion_format = portion.getPortionFormat().getEffective()
            fonts = (portion_format.getLatinFont(), portion_format.getEastAsianFont(), portion_format.getComplexScriptFont())
            if any(font is not None and font.getFontName() == target_font for font in fonts):
                portion.getPortionFormat().setKerningMinimalSize(100)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Voor tekst onder de drempel voorkomt deze instelling kerning en kan hij helpen de weergave van Aspose.Slides beter op die van PowerPoint af te stemmen voor lettertypen die door dit PowerPoint‑specifieke gedrag worden beïnvloed.

## **Tekstlettertype‑eigenschappen beheren**

Lettertype‑eigenschappen kunnen op alinea‑niveau worden ingesteld via [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) of op individuele gedeelten via [PortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/).

Het volgende voorbeeld stelt het standaardlettertype van de eerste alinea in op 12‑punt Times New Roman met vet, cursief en gestippelde onderstreping. Expliciete opmaak op individuele gedeelten heeft voorrang op deze standaardwaarden.

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

    # Stel de lettertype-eigenschappen in voor de alinea.
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

![De lettertype‑eigenschappen voor de alinea](font_properties_for_paragraph.png)

Het volgende voorbeeld past 13‑punt Times New Roman, cursieve opmaak en een gestippelde onderstreping toe op gedeelten waarvan de effectieve opmaak vet is:

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
            # Stel de lettertype-eigenschappen in voor het tekstgedeelte.
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

![De lettertype‑eigenschappen voor tekstgedeelten](font_properties_for_text_portions.png)

## **Normalisatie van teksthoogte regelen**

Gebruik [BasePortionFormat.setNormaliseHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setNormaliseHeight) bij het reproduceren van sjabloon‑typografie of bij het onderzoeken van verschillen in tekenhoogte. In PowerPoint strekt het inschakelen van normalisatie individuele tekens verticaal uit of comprimeert ze zodat ze een uniforme zichtbare hoogte hebben binnen het tekstgedeelte. Het garandeert geen gelijke teksthoogte tussen verschillende lettertypen.

Stel de eigenschap in op [NullableBool.True_ of False_](https://reference.aspose.com/slides/python-java/aspose.slides/nullablebool/) om normalisatie expliciet in‑ of uit te schakelen. `NullableBool.NotDefined` laat de lokale instelling onaangeduid zodat het gedeelte de waarde erft, bijvoorbeeld van het alinea‑[getDefaultPortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getDefaultPortionFormat). Het betekent niet `False`. Gebruik [PortionFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/#getEffective) en lees `getNormaliseHeight` van de geretourneerde effectieve opmaak om de uiteindelijke Boole‑waarde te krijgen.

Het volgende zelf‑contained voorbeeld vereist **Arial** om geïnstalleerd te zijn. Het maakt twee tekstblokken aan met dezelfde hoofdletters, kleine letters, afdrempels en accenten op 54 punten. Beide alinea’s hebben normalisatie standaard ingeschakeld. Het bovenste gedeelte schakelt het expliciet uit; het onderste neemt het over. De frame‑groottes, marges en alineaspatiëring zijn identiek, met omloop en autofit uitgeschakeld om de vergelijking consistent te houden. Het voorbeeld print `False: False` en `NotDefined: True`, en slaat “text_height_normalization.pptx” op.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, NullableBool, Presentation, SaveFormat, ShapeType, TextAlignment, TextAnchorType, TextAutofitType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    settings = [NullableBool.False_, NullableBool.NotDefined]
    setting_names = ["False", "NotDefined"]

    for i, setting in enumerate(settings):
        shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 60 + i * 200, 660, 150)
        shape.getFillFormat().setFillType(FillType.NoFill)
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)

        text_frame = shape.getTextFrame()
        text_frame.setText("Hxgjpq ÅÉ 0123")
        text_frame.getTextFrameFormat().setAutofitType(TextAutofitType.None_)
        text_frame.getTextFrameFormat().setWrapText(NullableBool.False_)
        text_frame.getTextFrameFormat().setAnchoringType(TextAnchorType.Top)
        text_frame.getTextFrameFormat().setMarginTop(0)
        text_frame.getTextFrameFormat().setMarginLeft(0)

        paragraph = text_frame.getParagraphs().get_Item(0)
        paragraph.getParagraphFormat().setAlignment(TextAlignment.Left)
        paragraph.getParagraphFormat().setSpaceBefore(0)
        paragraph.getParagraphFormat().setSpaceAfter(0)
        paragraph.getParagraphFormat().setSpaceWithin(100)
        paragraph.getParagraphFormat().getDefaultPortionFormat().setNormaliseHeight(NullableBool.True_)

        portion = paragraph.getPortions().get_Item(0)
        font = FontData("Arial")
        portion.getPortionFormat().setLatinFont(font)
        portion.getPortionFormat().setFontHeight(54)
        portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
        portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
        portion.getPortionFormat().setNormaliseHeight(setting)

        print(f"{setting_names[i]}: {bool(portion.getPortionFormat().getEffective().getNormaliseHeight())}")

    presentation.save("text_height_normalization.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

De vergelijking hieronder werd geëxporteerd uit de opgeslagen presentatie. De bovenste rij heeft normalisatie uitgeschakeld (`False`); de onderste rij erft de ingeschakelde instelling (`NotDefined` → `True`). Houd Arial geïnstalleerd om dit uiterlijk te reproduceren.

![Arial‑tekst van 54 punten met normalisatie uitgeschakeld boven en geërfde normalisatie ingeschakeld hieronder](text_height_normalization.png)

Normalisatie wijzigt de tekenhoogte zonder de toegewezen [getFontHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#getFontHeight)-waarde (die de lettergrootte in punten aangeeft) te wijzigen. Alinea‑[setSpaceWithin](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setSpaceWithin) regelt regelafstand, terwijl tekst‑frame‑[setAutofitType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setAutofitType) bepaalt hoe tekst of de container zich aanpast. Deze instellingen dienen verschillende doelen en kunnen de algehele lay‑out onafhankelijk beïnvloeden. Voor meer informatie over alinea‑opmaak en overerving, zie [Manage Paragraph](/slides/nl/python-java/manage-paragraph/).

## **Doorhalen toepassen en verwijderen**

Gebruik [BasePortionFormat.setStrikethroughType](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setStrikethroughType) op een tekstgedeelte om correcties, geannuleerde termen of eerdere prijzen weer te geven zonder de oorspronkelijke tekst te verwijderen. Stel in op [TextStrikethroughType.Single of Double](https://reference.aspose.com/slides/python-java/aspose.slides/textstrikethroughtype/) voor één of twee lijnen door de tekst.

Om doorhalen te verwijderen, geef [TextStrikethroughType.None_](https://reference.aspose.com/slides/python-java/aspose.slides/textstrikethroughtype/#None) door. Dit schakelt het effect expliciet uit, zelfs als de omliggende opmaak doorhalen specificeert. Daarentegen laat [TextStrikethroughType.NotDefined](https://reference.aspose.com/slides/python-java/aspose.slides/textstrikethroughtype/#NotDefined) de lokale instelling ongedefinieerd zodat het gedeelte de opmaak erft, bijvoorbeeld van de alinea. Het garandeert niet dat doorhalen wordt verwijderd. Gebruik [PortionFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/#getEffective) om de resulterende opmaak te lezen, inclusief geërfde waarden.

Het volgende zelf‑contained voorbeeld maakt drie prijsvergelijkingen. Elke alinea heeft afzonderlijke gedeelten voor het label, de vorige prijs en de huidige prijs, zodat alleen de vorige prijs wordt beïnvloed. De eerste rij past doorhalen toe en verwijdert het vervolgens; de andere rijen behouden enkel‑respectievelijk dubbel doorhalen. Het aanpassen van deze instelling behoudt de tekst en de overige opmaak, inclusief de vetgedrukte vorige prijs.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, NullableBool, Paragraph, Portion, Presentation, SaveFormat, ShapeType, TextAlignment, TextStrikethroughType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 620, 220)
    shape.getFillFormat().setFillType(FillType.NoFill)
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
    shape.getTextFrame().getParagraphs().clear()

    labels = ["None: ", "Single: ", "Double: "]

    for label in labels:
        paragraph = Paragraph()
        paragraph.getParagraphFormat().setAlignment(TextAlignment.Left)
        paragraph.getParagraphFormat().setSpaceAfter(20)

        portion_format = paragraph.getParagraphFormat().getDefaultPortionFormat()
        portion_format.setFontHeight(28)
        font = FontData("Arial")
        portion_format.setLatinFont(font)
        portion_format.getFillFormat().setFillType(FillType.Solid)
        portion_format.getFillFormat().getSolidFillColor().setColor(Color.BLACK)

        label_portion = Portion(label)
        paragraph.getPortions().add(label_portion)

        previous_price = Portion("$100")
        previous_price.getPortionFormat().setFontBold(NullableBool.True_)
        paragraph.getPortions().add(previous_price)
        current_price = Portion(" → $80")
        paragraph.getPortions().add(current_price)

        shape.getTextFrame().getParagraphs().add(paragraph)

    paragraphs = shape.getTextFrame().getParagraphs()

    # Pas doorhalen toe, dan verwijder je het expliciet van de eerste vorige prijs.
    paragraphs.get_Item(0).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.Single)
    paragraphs.get_Item(0).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.None_)

    paragraphs.get_Item(1).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.Single)
    paragraphs.get_Item(2).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.Double)

    presentation.save("strikethrough.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Het resultaat, van boven naar beneden: geen doorhalen, enkel doorhalen, dubbel doorhalen.

![Vorige prijzen zonder doorhalen, met enkel doorhalen en met dubbel doorhalen](strikethrough.png)

## **Tekstrotatie instellen**

Gebruik [TextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setTextVerticalType) om een vooraf gedefinieerde tekstoriëntatie binnen een vorm in te stellen.

Het volgende code‑voorbeeld stelt de tekstoriëntatie in de vorm in op [TextVerticalType.Vertical270](https://reference.aspose.com/slides/python-java/aspose.slides/textverticaltype/), wat de tekst **90 graden tegen de klok in** roteert:

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

![De tekstrotatie](text_rotation.png)

## **Cijfers naast elkaar weergeven in verticale tekst**

Om de cijfers van een tweecijferig getal naast elkaar te houden in een verticaal Japans label, plaats beide cijfers in één tekstgedeelte en roep [BasePortionFormat.setKumimoji](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setKumimoji) aan op dat gedeelte. Beide labels in dit voorbeeld gebruiken [TextVerticalType.EastAsianVertical](https://reference.aspose.com/slides/python-java/aspose.slides/textverticaltype/#EastAsianVertical) en 40‑punt MS Gothic. Alleen de [NullableBool](https://reference.aspose.com/slides/python-java/aspose.slides/nullablebool/)-instelling voor de cijfers verschilt.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, NullableBool, Portion, Presentation, SaveFormat, ShapeType, TextVerticalType

Color = jpype.JClass("java.awt.Color")
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    font = FontData("MS Gothic")

    for x, kumimoji in [(120, NullableBool.True_), (360, NullableBool.False_)]:
        label = slide.getShapes().addAutoShape(ShapeType.Rectangle, x, 48, 120, 420)
        label.getFillFormat().setFillType(FillType.NoFill)
        label.getLineFormat().getFillFormat().setFillType(FillType.NoFill)

        frame = label.addTextFrame("")
        frame.getTextFrameFormat().setTextVerticalType(TextVerticalType.EastAsianVertical)

        paragraph = frame.getParagraphs().get_Item(0)
        default_format = paragraph.getParagraphFormat().getDefaultPortionFormat()
        default_format.setLatinFont(font)
        default_format.setEastAsianFont(font)
        default_format.setFontHeight(40)
        default_format.getFillFormat().setFillType(FillType.Solid)
        default_format.getFillFormat().getSolidFillColor().setColor(Color.BLACK)

        digits = Portion("12")
        digits.getPortionFormat().setKumimoji(kumimoji)
        
        portions = paragraph.getPortions()
        portions.clear()
        portions.add(Portion("令和"))
        portions.add(digits)
        portions.add(Portion("年"))

    presentation.save("vertical_date.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

In PowerPoint toont het linkerlabe`l` (`True`) de cijfers rechtop en naast elkaar tussen 和 en 年. In het rechterlabel (`False`) wordt het paar 90 graden met de klok mee geroteerd. De omringende Japanse tekens blijven in beide labels rechtop.

![PowerPoint‑vergelijking van verticale datumlabels met rechtopstaande cijfers links en geroteerde cijfers rechts.](vertical_date.png)

## **Aangepaste rotatie voor tekstframes instellen**

Gebruik [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setRotationAngle) om een aangepaste rotatiehoek in te stellen voor een [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/).

Het onderstaande code‑voorbeeld roteert het tekstframe met 3 graden met de klok mee binnen de vorm:

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

![De aangepaste tekstrotatie](custom_text_rotation.png)

## **Regelafstand van alinea’s instellen**

Aspose.Slides biedt [ParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setSpaceAfter), [ParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setSpaceBefore) en [ParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setSpaceWithin) om alinea‑afstand te regelen. Deze eigenschappen worden als volgt gebruikt:

* Gebruik een positieve waarde om de regelafstand als percentage van de regelhoogte op te geven.
* Gebruik een negatieve waarde om de regelafstand in punten op te geven.

Het volgende voorbeeld stelt de afstand binnen de eerste alinea in op 200 % van de regelhoogte (dubbele spatiëring):

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

![De regelafstand binnen de alinea](line_spacing.png)

## **Regelafbreking regelen**

Regels voor regel‑afbreking in alinea’s zijn nuttig in smalle tekstblokken en presentaties die Latijnse en Oost‑Aziatische tekst mixen. De volgende methoden behoren tot [ParagraphFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/), dus ze gelden voor een volledige alinea:

- [setLatinLineBreak](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setLatinLineBreak) regelt de regels voor Latijnse afbreking. In gemengde tekst kan het wijzigen hiervan ook bepalen waar aangrenzende Oost‑Aziatische tekst en interpunctie omslaan.
- [setEastAsianLineBreak](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setEastAsianLineBreak) regelt de regels voor Oost‑Aziatische afbreking, inclusief beperkingen voor tekens aan het begin en einde van een regel.

Deze regels vervangen niet [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setWrapText), die automatisch omslaan binnen een tekstframe inschakelt. Ze beïnvloeden de lay‑out wanneer omslaan optreedt; ze voegen geen regel‑break‑tekens toe. Een expliciete regel‑break dwingt een nieuwe regel binnen de alinea, onafhankelijk van de beschikbare breedte.

Het volgende zelf‑contained voorbeeld maakt een smal tekstblok met Chinese en Latijnse tekst. Het stelt beide regel‑afbrekingsopties expliciet in en slaat “line_breaking.pptx” op. Om met een van de regels te experimenteren, wijzig de overeenkomstige waarde terwijl de andere instellingen gelijk blijven. Het voorbeeld gebruikt 24‑punt Arial en SimSun met een frame‑breedte van 160 punten en nul horizontale tekst‑frame‑marges. [TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setAutofitType) wordt aangeroepen met [TextAutofitType.None_](https://reference.aspose.com/slides/python-java/aspose.slides/textautofittype/) zodat tekstgrootte en frame‑dimensies vast blijven.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, NullableBool, Presentation, SaveFormat, ShapeType, TextAlignment, TextAutofitType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 160, 300)
    shape.getFillFormat().setFillType(FillType.NoFill)

    text_frame = shape.getTextFrame()
    text_frame.getTextFrameFormat().setWrapText(NullableBool.True_)
    text_frame.getTextFrameFormat().setAutofitType(TextAutofitType.None_)
    text_frame.getTextFrameFormat().setMarginLeft(0)
    text_frame.getTextFrameFormat().setMarginRight(0)

    paragraph = text_frame.getParagraphs().get_Item(0)
    paragraph.setText("中文排版测试，PowerPoint 中文演示。")

    paragraph_format = paragraph.getParagraphFormat()
    paragraph_format.setAlignment(TextAlignment.Left)
    paragraph_format.getDefaultPortionFormat().setFontHeight(24)
    latin_font = FontData("Arial")
    paragraph_format.getDefaultPortionFormat().setLatinFont(latin_font)
    east_asian_font = FontData("SimSun")
    paragraph_format.getDefaultPortionFormat().setEastAsianFont(east_asian_font)
    paragraph_format.getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph_format.getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    paragraph_format.setLatinLineBreak(NullableBool.False_)
    paragraph_format.setEastAsianLineBreak(NullableBool.True_)

    presentation.save("line_breaking.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Hangende interpunctie regelen**

[ParagraphFormat.setHangingPunctuation](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setHangingPunctuation) maakt het mogelijk dat in aanmerking komende interpunctie verder uitsteekt dan de rechterrand van de tekstlijn in plaats van op de volgende regel te verschijnen. Het geldt voor de volledige alinea en verschilt van een hangende inspringing.

Het volgende zelf‑contained voorbeeld schakelt hangende interpunctie in een tekstframe van 100 punten breed in en slaat “hanging_punctuation.pptx” op. Met 24‑punt Arial en nul horizontale tekst‑frame‑marges blijft de laatste punt achter “sentence” staan en reikt voorbij de rechterkant van de tekst. Stel de eigenschap in op [NullableBool.False_](https://reference.aspose.com/slides/python-java/aspose.slides/nullablebool/) om te vergelijken: met deze instelling neemt de punt een eigen regel in. Omloop wordt ingeschakeld en autofit uitgeschakeld om de beschikbare breedte vast te houden.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, NullableBool, Presentation, SaveFormat, ShapeType, TextAlignment, TextAutofitType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 100, 200)
    shape.getFillFormat().setFillType(FillType.NoFill)

    text_frame = shape.getTextFrame()
    text_frame.getTextFrameFormat().setWrapText(NullableBool.True_)
    text_frame.getTextFrameFormat().setAutofitType(TextAutofitType.None_)
    text_frame.getTextFrameFormat().setMarginLeft(0)
    text_frame.getTextFrameFormat().setMarginRight(0)

    paragraph = text_frame.getParagraphs().get_Item(0)
    paragraph.setText("Simple text, next sentence.")

    paragraph_format = paragraph.getParagraphFormat()
    paragraph_format.setAlignment(TextAlignment.Left)
    paragraph_format.getDefaultPortionFormat().setFontHeight(24)
    latin_font = FontData("Arial")
    paragraph_format.getDefaultPortionFormat().setLatinFont(latin_font)
    paragraph_format.getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph_format.getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    paragraph_format.setHangingPunctuation(NullableBool.True_)

    presentation.save("hanging_punctuation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Niet elk leesteken kan hangen. De [lettertype‑ en lay‑outvoorwaarden die hierboven beschreven zijn](#control-line-breaking) gelden ook voor deze vergelijking: wijzigen van het lettertype, de beschikbare breedte, marges of autofit‑instellingen kan het zichtbare verschil wegnemen.

## **Autofit‑type voor tekstframes instellen**

[TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setAutofitType) bepaalt hoe tekst zich gedraagt wanneer deze de grenzen van zijn container overschrijdt. Gebruik het om te regelen of de tekst krimpt, overlapt of automatisch de vorm vergroot. Het volgende voorbeeld configureert de vorm om zich aan te passen aan de tekst en slaat het resultaat op in “autofit_type.pptx”.

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

Om het aantal regels na automatisch omslaan te tellen en te zien hoe tekst‑ of vormbreedte het resultaat wijzigt, zie [Count Rendered Lines](/slides/nl/python-java/manage-paragraph/). Alleen het aantal regels geeft niet aan of tekst buiten de container overlapt.

## **Anker van tekstframes instellen**

[TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setAnchoringType) definieert hoe tekst verticaal binnen een vorm wordt gepositioneerd, bijvoorbeeld bovenaan, in het midden of onderaan. Het volgende voorbeeld verankert de tekst aan de onderkant van de eerste vorm en slaat het resultaat op in “text_anchor.pptx”.

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

## **Teksttabulatie instellen**

Gebruik [ParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setDefaultTabSize) en [ParagraphFormat.getTabs](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getTabs) om tabstops in een alinea te configureren. Het volgende voorbeeld stelt de standaardtab‑interval in op 100 punten en voegt een links‑uitgelijnde tabstop toe op 30 punten. Deze instellingen beïnvloeden tekst die tab‑tekens bevat.

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

![De alinea‑tabs](paragraph_tabs.png)

## **Controlatietaal instellen**

Aspose.Slides biedt [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setLanguageId), waarmee u de controlatietaal voor een tekstgedeelte kunt instellen. De controlatietaal bepaalt welke taal wordt gebruikt voor spelling‑ en grammaticacontrole in PowerPoint.

Het volgende voorbeeld vereist “presentation.pptx” met een tekstvak als eerste vorm op de eerste dia en ten minste één alinea. Het vervangt de inhoud van de eerste alinea door “1。”, stelt SimSun in als lettertype en kent de vereenvoudigd Chinees controlatietaal (`zh-CN`) toe. Het slaat het resultaat op in “proofing_language.pptx”:

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

    # Stel de Id van een proofing-taal in.
    text_portion.getPortionFormat().setLanguageId("zh-CN")

    text_portion.setText("1。")
    paragraph.getPortions().add(text_portion)

    presentation.save("proofing_language.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Taal‑metadata kopiëren**

Bij het kopiëren van meertalige tekst uit een sjabloon moeten zowel [BasePortionFormat.getLanguageId](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#getLanguageId) als [BasePortionFormat.getAlternativeLanguageId](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#getAlternativeLanguageId) bewaard blijven. Het volgende zelf‑contained voorbeeld maakt een bron‑gedeelte met Engels (VS) als taal en Frans als alternatieve taal en kopieert de tekst en identifiers naar een gedeelte in een nieuwe presentatie.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Portion, Presentation, SaveFormat, ShapeType

source = Portion("Hello! Bonjour!")
source.getPortionFormat().setLanguageId("en-US")
source.getPortionFormat().setAlternativeLanguageId("fr-FR")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 80)
    paragraph = shape.getTextFrame().getParagraphs().get_Item(0)
    paragraph.getPortions().clear()

    destination = Portion()
    destination.setText(source.getText())
    destination.getPortionFormat().setLanguageId(source.getPortionFormat().getLanguageId())
    # Als de bron geen alternatieve taal heeft, wist None de bestemmingswaarde.
    destination.getPortionFormat().setAlternativeLanguageId(source.getPortionFormat().getAlternativeLanguageId())
    paragraph.getPortions().add(destination)

    presentation.save("copied_language_metadata.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Om een bron zonder alternatieve taal te testen, laat de toewijzing van `"fr-FR"` weg. De alternatieve identifier is dan `None`, en dezelfde kopie‑opdracht behoudt de afwezigheid zonder een standaardwaarde in te voeren, zelfs als de bestemming eerder een alternatieve taal had.

Deze identifiers vormen metadata over de taal. Het behouden ervan bepaalt niet welke woordenlijst PowerPoint selecteert voor spelling‑ of grammaticacontrole.

## **Standaardtaal instellen**

Gebruik [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setDefaultTextLanguage) om de standaardtaal voor tekst te definiëren die tijdens het laden of maken van een presentatie wordt aangemaakt. Het volgende voorbeeld maakt een presentatie met Engels (VS) als standaardtekst‑taal, voegt een tekstvak toe en print `en-US` voor het eerste tekstgedeelte.

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

    # Controleer de taal van de eerste tekstgedeelte.
    portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    print(portion.getPortionFormat().getLanguageId())
finally:
    presentation.dispose()
```

## **Standaardtekstopmaak instellen**

Om standaardtekst‑formattering op presentatieniveau toe te passen, gebruik [Presentation.getDefaultTextStyle](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getDefaultTextStyle).

Het volgende voorbeeld stelt een 14‑punt vet lettertype in als standaard voor alinea’s van het hoogste niveau in een nieuwe presentatie en slaat deze op in “default_text_style.pptx”. Tekst kan deze standaarden erven tenzij meer specifieke opmaak ze overschrijft.

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

In PowerPoint zorgt het toepassen van het **All Caps**‑fonteffect ervoor dat tekst in hoofdletters wordt weergegeven op de dia, ook al is de originele invoer in kleine letters. Wanneer u een dergelijk tekstgedeelte met Aspose.Slides ophaalt, retourneert de bibliotheek de tekst precies zoals ingevoerd. Om de weergegeven tekst te verkrijgen, controleer [TextCapType](https://reference.aspose.com/slides/python-java/aspose.slides/textcaptype/) en converteer de geretourneerde string naar hoofdletters wanneer de waarde `All` is.

Dit voorbeeld vereist “sample2.pptx” met een tekstvak als eerste vorm op de eerste dia. De eerste alinea‑eerste gedeelte bevat “Hello, Aspose!” met het All‑Caps‑effect toegepast, zoals hieronder weergegeven.

![Het All‑Caps‑effect](all_caps_effect.png)

Het code‑voorbeeld hieronder toont hoe u de tekst met het **All Caps**‑effect kunt extraheren:

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

Uitvoer:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **FAQ**

**Hoe wijzig ik tekst in een tabel op een dia?**

Gebruik [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/). Loop door de cellen en werk elke cel bij via [Cell.getTextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getTextFrame) en alinea‑opmaak via [Paragraph.getParagraphFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/#getParagraphFormat).

**Hoe pas ik een kleurverloop toe op tekst in een PowerPoint‑dia?**

Gebruik [BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#getFillFormat). Stel [FillFormat.setFillType](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#setFillType) in op [FillType.Gradient](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/) en configureer de kleurverloop‑stops, richting en transparantie.