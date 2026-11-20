---
title: Tekst van presentatie opmaken in Python via Java
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
- tekstkader
- regelafstand
- autofit-eigenschap
- tekstkaderverankering
- teksttabulatie
- standaardtaal
- PowerPoint
- OpenDocument
- presentatie
- Python
- Java
- Aspose.Slides
description: "Formatteer en stijl tekst in PowerPoint- en OpenDocument-presentaties met Aspose.Slides voor Python via Java. Pas lettertypen, kleuren, uitlijning en meer aan."
---
## **Overzicht**

Dit artikel laat zien hoe u tekst opmaakt in PowerPoint‑ en OpenDocument‑presentaties met Aspose.Slides voor Python via Java. Het behandelt achtergrondkleuren, transparantie, tekenafstand, lettereigenschappen, rotatie, alinea‑afstand, autofit‑gedrag, tekstverankering, tabs en taalinstellingen.

Tenzij anders aangegeven, gebruiken de voorbeelden [sample.pptx](sample.pptx). De eerste vorm op de eerste dia is een tekstvak, en de eerste alinea ervan bevat de hieronder getoonde tekst. Zowel dia‑ als vorm‑indexen beginnen bij nul. Voorbeelden die vette gedeelten selecteren gebruiken effectieve opmaak, inclusief geërfde vette opmaak:

![Voorbeeldtekst](sample_text.png)

Om letterlijke tekst of reguliere‑expressie‑overeenkomsten te vinden en te markeren, zie [Zoeken en vervangen van tekst](/slides/nl/python-java/search-and-replace-text/).

## **Instellen van tekstachtergrondkleur**

Gebruik [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) om de standaard markeerkleur voor een alinea in te stellen, of gebruik [BasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#getHighlightColor) voor individuele tekstgedeelten.

Het volgende voorbeeld stelt een lichtgrijze markering in als de standaard voor de eerste alinea. Expliciete markeerkleuren voor individuele gedeelten hebben voorrang op deze standaard:

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

    # Stel de markeerkleur in voor de volledige alinea.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY)

    presentation.save("gray_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Het resultaat:

![De grijze alinea](gray_paragraph.png)

Het codevoorbeeld hieronder toont hoe u de achtergrondkleur instelt voor **tekstgedeelten met een vet lettertype**:

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

## **Tekst alinea's uitlijnen**

Gebruik [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setAlignment) om de uitlijning van alinea's binnen een tekstkader in te stellen. De waarde kan gecentreerd, links‑uitgelijnd, rechts‑uitgelijnd, uitgevuld, enz. zijn.

Het volgende codevoorbeeld toont hoe u de alinea naar het **midden** uitlijnt:

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

    # Stel de uitlijning van de alinea in op midden.
    paragraph.getParagraphFormat().setAlignment(TextAlignment.Center)

    presentation.save("aligned_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Het resultaat:

![De uitgelijnde alinea](aligned_paragraph.png)

## **Lettertype‑uitlijning binnen een regel**

Gebruik [ParagraphFormat.setFontAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setFontAlignment) om tekstgedeelten met verschillende lettergroottes binnen een regel verticaal uit te lijnen. Deze instelling geldt voor de gehele alinea en regelt de uitlijning binnen elke regel daarvan.

Het volgende zelfstandige voorbeeld maakt vier gelabelde tekstvakken op één dia. Elke alinea bevat dezelfde tekst in 18, 36 en 54 punten, met een andere lettertype‑uitlijning. Het gebruikt Arial, schakelt autofit en woordomslag uit, en houdt de tekstkaders groot genoeg voor één regel.

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

![Vergelijking van basislijn, bovenkant, midden en onderkant lettertype‑uitlijning met gemengde lettergroottes](font_alignment.png)

Lettertype‑uitlijning gebruikt lettertype‑metrische gegevens, waardoor de zichtbare randen van afzonderlijke letters niet per se exact op één lijn liggen. Het voorbeeld bevat zowel een hoofdletter als een afdalende letter om het verschil tussen basislijn‑ en onderkant‑uitlijning te laten zien. Beschikbaarheid en substitutie van lettertypen, de gebruikte tekens, en het verschil in lettergroottes beïnvloeden het resultaat. Kaderafmetingen, marges, regelafstand, woordomslag en autofit beïnvloeden eveneens de lay‑out; gebruik dezelfde lettertypen en lay‑outinstellingen bij het vergelijken van de modi.

Deze instelling verschilt van [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setAlignment), die horizontale alinea‑uitlijning regelt, en van [TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setAnchoringType), die het tekstblok verticaal binnen de vorm positioneert. Superscript‑ en subscript‑opmaak via [BasePortionFormat.setEscapement](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setEscapement) verschuift individuele gedeelten ten opzichte van de basislijn in plaats van de lettertype‑uitlijning voor de regels van de alinea in te stellen.

## **Transparantie voor tekst instellen**

Transparantie van tekst wordt geregeld via de alfa‑component van de kleur die is toegewezen aan [BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#getFillFormat). In de onderstaande voorbeelden is `alpha = 50` een ARGB‑alfa‑waarde op een schaal van 0–255, geen transparantie‑percentage.

Het codevoorbeeld hieronder toont hoe u transparantie toepast op de **volledige alinea**:

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

Het volgende codevoorbeeld toont hoe u transparantie toepast op **tekstgedeelten met een vet lettertype**:

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

Gebruik [BasePortionFormat.setSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setSpacing) om de afstand tussen tekens in een tekstvak uit te breiden of te verkleinen. In de voorbeelden wordt 3 punten afstand toegevoegd; negatieve waarden verkleinen de tekst.

De volgende Python‑code toont hoe u de tekenafstand uitbreidt in de **volledige alinea**:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpime.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # Opmerking: Gebruik negatieve waarden om de tekenafstand te verkleinen.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3) # Vergroot de tekenafstand.

    presentation.save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Het resultaat:

![De tekenafstand in de alinea](character_spacing_in_paragraph.png)

Het codevoorbeeld hieronder toont hoe u de tekenafstand vergroot in **tekstgedeelten met een vet lettertype**:

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
            # Opmerking: Gebruik negatieve waarden om de tekenafstand te verkleinen.
            portion.getPortionFormat().setSpacing(3) # Vergroot de tekenafstand.

    presentation.save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Het resultaat:

![De tekenafstand in de tekstgedeelten](character_spacing_in_text_portions.png)

### **Kerning voor specifieke lettertypen uitschakelen**

In sommige gevallen kan tekst die door Aspose.Slides wordt gerenderd er iets strakker uitzien dan dezelfde tekst in PowerPoint. Dit kan gebeuren omdat PowerPoint kerning‑gegevens voor bepaalde lettertypen negeert, zelfs wanneer het lettertype geldige kerning‑informatie bevat en kerning is ingeschakeld in de PowerPoint‑instellingen.

Om de gerenderde uitvoer dichter bij PowerPoint te krijgen, kunt u kerning uitschakelen voor tekstgedeelten die het betreffende lettertype gebruiken. Stel [BasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setKerningMinimalSize) in op een waarde die groter is dan de werkelijke lettergrootte. Dit voorbeeld vereist “presentation.pptx” met een tekstvak als eerste vorm op de eerste dia. Het controleert effectieve lettertypenamen, inclusief geërfde lettertypen, en stelt een drempel van 100 punten in voor gedeelten die Roboto gebruiken. Dit schakelt kerning uit voor overeenkomende gedeelten met een lettergrootte lager dan 100 punten:

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

Voor overeenkomende tekst onder de drempel voorkomt deze instelling kerning en kan het helpen om de Aspose.Slides‑rendering af te stemmen op de visuele uitvoer van PowerPoint voor lettertypen die door dit PowerPoint‑specifieke gedrag worden beïnvloed.

## **Tekstlettertype‑eigenschappen beheren**

Lettertype‑eigenschappen kunnen op alinea‑niveau worden ingesteld via [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getDefaultPortionFormat), of op individuele gedeelten via [PortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/).

Het volgende voorbeeld stelt het standaardlettertype van de eerste alinea in op 12‑punt Times New Roman met vet, cursief en gestippelde onderstreping. Expliciete opmaak op individuele gedeelten heeft voorrang op deze standaarden:

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

![De lettertype‑eigenschappen voor de alinea](font_properties_for_paragraph.png)

Het volgende voorbeeld past 13‑punt Times New Roman, cursieve opmaak en een gestippelde onderstreping toe op gedeelten waarvan de effectieve opmaak vet is:

```python
import jpime
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

![De lettertype‑eigenschappen voor tekstgedeelten](font_properties_for_text_portions.png)

## **Normalisatie van teksthoogte regelen**

Gebruik [BasePortionFormat.setNormaliseHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setNormaliseHeight) wanneer u typografie van een sjabloon reproduceert of verschillen in tekenhoogte onderzoekt. In PowerPoint zorgt het inschakelen van normalisatie ervoor dat individuele tekens verticaal worden uitgerekt of samengeperst om een uniforme zichtbare hoogte te krijgen binnen het tekstgedeelte. Het garandeert geen gelijke teksthoogten tussen verschillende lettertypen.

Stel de eigenschap in op [NullableBool.True_ of False_](https://reference.aspose.com/slides/python-java/aspose.slides/nullablebool/) om normalisatie expliciet in of uit te schakelen. `NullableBool.NotDefined` laat de lokale instelling onveranderd zodat het gedeelte de waarde erft, bijvoorbeeld van de alinea‑[getDefaultPortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getDefaultPortionFormat). Dit betekent niet `False`. Gebruik [PortionFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/#getEffective) en lees `getNormaliseHeight` op de geretourneerde effectieve opmaak om de geresolveerde Booleaanse waarde te verkrijgen.

Het volgende zelfstandige voorbeeld vereist dat **Arial** is geïnstalleerd. Het maakt twee tekstblokken aan met dezelfde hoofdletters, kleine letters, afdalende tekens en accented characters op 54 punten. Beide alinea's hebben normalisatie standaard ingeschakeld. Het bovenste gedeelte schakelt het expliciet uit; het onderste erft het. De kadergroottes, marges en alinea‑afstand zijn identiek, met woordomslag en autofit uitgeschakeld om de vergelijking consistent te houden. Het voorbeeld print `False: False` en `NotDefined: True`, en slaat “text_height_normalization.pptx” op.

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

De onderstaande vergelijking is geëxporteerd uit de opgeslagen presentatie. De bovenste rij heeft normalisatie uitgeschakeld (`False`); de onderste rij erft de ingeschakelde instelling (`NotDefined` → `True`). Houd Arial geïnstalleerd om dit uiterlijk te reproduceren.

![Arial‑tekst van 54 punt met normalisatie uitgeschakeld boven en geërfde normalisatie ingeschakeld hieronder](text_height_normalization.png)

Normalisatie verandert de tekenhoogte zonder de toegewezen [getFontHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#getFontHeight) waarde te wijzigen, die de lettergrootte in punten specificeert. Alinea‑[setSpaceWithin](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setSpaceWithin) regelt de regelafstand, terwijl tekst‑kader‑[setAutofitType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setAutofitType) bepaalt hoe tekst of de container zich aanpast. Deze instellingen dienen verschillende doeleinden en kunnen de algehele lay‑out onafhankelijk beïnvloeden. Voor meer over alinea‑opmaak en overerving, zie [Manage Paragraph](/slides/nl/python-java/manage-paragraph/).

## **Doorhalen toepassen en verwijderen**

Gebruik [BasePortionFormat.setStrikethroughType](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setStrikethroughType) op een tekstgedeelte om correcties, geannuleerde termen of eerdere prijzen weer te geven zonder de originele tekst te verwijderen. Stel het in op [TextStrikethroughType.Single of Double](https://reference.aspose.com/slides/python-java/aspose.slides/textstrikethroughtype/) voor één of twee doorhalingsstrepen door de tekst.

Om doorhalen te verwijderen, geef [TextStrikethroughType.None_](https://reference.aspose.com/slides/python-java/aspose.slides/textstrikethroughtype/#None) door. Dit schakelt het effect expliciet uit, zelfs als de omringende opmaak doorhalen opgeeft. Daarentegen laat [TextStrikethroughType.NotDefined](https://reference.aspose.com/slides/python-java/aspose.slides/textstrikethroughtype/#NotDefined) de lokale instelling ongedefinieerd, waardoor het gedeelte de opmaak kan erven, bijvoorbeeld van de alinea. Het garandeert niet dat doorhalen wordt verwijderd. Gebruik [PortionFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/#getEffective) om de resulterende opmaak, inclusief geërfde waarden, te lezen.

Het volgende zelfstandige voorbeeld maakt drie prijsvergelijkingen. Elke alinea bevat afzonderlijke gedeelten voor het label, de vorige prijs en de huidige prijs, zodat alleen de vorige prijs wordt doorgehaald. De eerste rij past doorhalen toe en verwijdert het vervolgens; de andere rijen behouden enkel‑respectievelijk dubbel‑doorhalen. Het wijzigen van deze instelling behoudt de tekst en andere opmaak, inclusief de vetgedrukte vorige prijs.

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

    # Pas doorhaling toe, en verwijder deze vervolgens expliciet van de eerste vorige prijs.
    paragraphs.get_Item(0).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.Single)
    paragraphs.get_Item(0).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.None_)

    paragraphs.get_Item(1).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.Single)
    paragraphs.get_Item(2).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.Double)

    presentation.save("strikethrough.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Het resultaat, van boven naar beneden: geen doorhalen, enkel doorhalen, en dubbel doorhalen.

![Vorige prijzen zonder doorhalen, met enkel doorhalen, en met dubbel doorhalen](strikethrough.png)

## **Tekstrotatie instellen**

Gebruik [TextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setTextVerticalType) om een vooraf gedefinieerde tekstoriëntatie binnen een vorm in te stellen.

Het volgende codevoorbeeld stelt de tekstoriëntatie in de vorm in op [TextVerticalType.Vertical270](https://reference.aspose.com/slides/python-java/aspose.slides/textverticaltype/), wat de tekst **90 graden tegen de klok in** roteert:

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

## **Aangepaste rotatie voor tekstkaders instellen**

Gebruik [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setRotationAngle) om een aangepaste rotatiehoek in te stellen voor een [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/).

Het codevoorbeeld hieronder roteert het tekstkader met 3 graden met de klok mee binnen de vorm:

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

## **Regelafstand voor alinea's instellen**

Aspose.Slides biedt [ParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setSpaceAfter), [ParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setSpaceBefore) en [ParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setSpaceWithin) om alinea‑afstand te regelen. Deze eigenschappen worden als volgt gebruikt:

* Gebruik een positieve waarde om de regelafstand als percentage van de regelhoogte op te geven.
* Gebruik een negatieve waarde om de regelafstand in punten op te geven.

Het volgende voorbeeld stelt de afstand binnen de eerste alinea in op 200 % van de regelhoogte (dubbele regelafstand):

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

## **Regelafbreking beheren**

Regel‑afbrekingsregels voor alinea's zijn nuttig in smalle tekstblokken en presentaties die Latijnse en Oost‑Aziatische tekst combineren. De volgende methoden behoren tot [ParagraphFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/), zodat ze van toepassing zijn op een volledige alinea:

- [setLatinLineBreak](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setLatinLineBreak) regelt de regelafbrekingsregels voor het Latijnse schrift. In gemengde tekst kan een wijziging ook de plaats bepalen waar aangrenzende Oost‑Aziatische tekst en interpunctie afbreken.
- [setEastAsianLineBreak](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setEastAsianLineBreak) regelt de regelafbrekingsregels voor het Oost‑Aziatische schrift, inclusief beperkingen voor tekens aan het begin en einde van een regel.

Deze regels vervangen niet [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setWrapText), die automatische woordomslag binnen een tekstkader inschakelt. Ze beïnvloeden de lay‑out wanneer er omslag optreedt; ze voegen geen regeleinde‑tekens toe. Een expliciete regeleinde dwingt een nieuwe regel binnen de alinea, onafhankelijk van de beschikbare breedte.

Het volgende zelfstandige voorbeeld maakt een smal tekstblok met Chinees en Latijnse tekst. Het stelt beide regelafbrekingsopties expliciet in en slaat “line_breaking.pptx” op. Om met een van de regels te experimenteren, wijzig de betreffende waarde terwijl de andere instellingen gelijk blijven. Het voorbeeld gebruikt 24‑punt Arial en SimSun met een kaderbreedte van 160 punt en nul horizontale tekstkader‑marges. [TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setAutofitType) wordt aangeroepen met [TextAutofitType.None_](https://reference.aspose.com/slides/python-java/aspose.slides/textautofittype/), zodat tekengrootte en kaderafmetingen vast blijven.

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

## **Hangende interpunctie beheren**

[ParagraphFormat.setHangingPunctuation](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setHangingPunctuation) laat in aanmerking komende interpunctie buiten de rechterrand van de tekstlijn uitsteken in plaats van de volgende regel te bezetten. Het geldt voor de volledige alinea en verschilt van een hangende inspringing.

Het volgende zelfstandige voorbeeld schakelt hangende interpunctie in een tekstkader van 100 punt breed in en slaat “hanging_punctuation.pptx” op. Met 24‑punt Arial en nul horizontale tekstkader‑marges blijft de eindpunt na “sentence” achter de tekst en strekt zich uit buiten de rechterkant. Stel de eigenschap in op [NullableBool.False_](https://reference.aspose.com/slides/python-java/aspose.slides/nullablebool/) om te vergelijken: met deze instellingen neemt de punt een aparte regel in. Woordomslag is ingeschakeld en autofit uitgeschakeld om de beschikbare breedte vast te houden.

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

Niet elk leesteken kan hangen. De [lettertype‑ en lay‑out‑condities die hierboven zijn beschreven](#control-line-breaking) gelden ook voor deze vergelijking: het wijzigen van het lettertype, de beschikbare breedte, marges of autofit‑instellingen kan het zichtbare verschil verwijderen.

## **Autofit‑type voor tekstkaders instellen**

[TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setAutofitType) bepaalt hoe tekst zich gedraagt wanneer deze de grenzen van de container overschrijdt. Gebruik het om te regelen of de tekst krimpt, overlapt, of de vorm automatisch opnieuw schaalt. Het volgende voorbeeld configureert de vorm om te worden aangepast aan de tekst en slaat het resultaat op als “autofit_type.pptx”.

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

Om regels te tellen na automatische omslag en te zien hoe tekst‑ of vormbreedte het resultaat verandert, zie [Count Rendered Lines](/slides/nl/python-java/manage-paragraph/). Alleen het aantal regels geeft niet aan of tekst buiten de container overlapt.

## **Anker van tekstkaders instellen**

[TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setAnchoringType) bepaalt hoe tekst verticaal binnen een vorm wordt gepositioneerd, bijvoorbeeld bovenaan, in het midden of onderaan. Het volgende voorbeeld verankert de tekst aan de onderkant van de eerste vorm en slaat het resultaat op als “text_anchor.pptx”.

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

Gebruik [ParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setDefaultTabSize) en [ParagraphFormat.getTabs](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getTabs) om tabs in een alinea te configureren. Het volgende voorbeeld stelt de standaardtab‑intervallen in op 100 punt en voegt een links‑uitgelijnde tab op 30 punt toe. Deze instellingen beïnvloeden tekst die tab‑tekens bevat.

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

## **Spelling‑ en grammaticacontroletaal instellen**

Aspose.Slides biedt [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setLanguageId), waarmee u de correctietaal voor een tekstgedeelte kunt instellen. De correctietaal bepaalt de taal die wordt gebruikt voor spelling‑ en grammaticacontrole in PowerPoint.

Het volgende voorbeeld vereist “presentation.pptx” met een tekstvak als eerste vorm op de eerste dia en ten minste één alinea. Het vervangt de inhoud van de eerste alinea door “1。”, stelt SimSun in als lettertype, en wijst de vereenvoudigde Chinese correctietaal (`zh-CN`) toe. Het slaat het resultaat op als “proofing_language.pptx”:

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

    # Stel de Id van een correctietaal in.
    text_portion.getPortionFormat().setLanguageId("zh-CN")

    text_portion.setText("1。")
    paragraph.getPortions().add(text_portion)

    presentation.save("proofing_language.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Taalmetadata kopiëren**

Bij het kopiëren van meertalige tekst uit een sjabloon, behoud zowel [BasePortionFormat.getLanguageId](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#getLanguageId) als [BasePortionFormat.getAlternativeLanguageId](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#getAlternativeLanguageId). Het volgende zelfstandige voorbeeld maakt een bron‑gedeelte met VS‑Engels als taal en Frans als alternatieve taal, en kopieert de tekst en identifiers naar een gedeelte in een nieuwe presentatie.

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
    # Als de bron geen alternatieve taal heeft, wist None de waarde van de bestemming.
    destination.getPortionFormat().setAlternativeLanguageId(source.getPortionFormat().getAlternativeLanguageId())
    paragraph.getPortions().add(destination)

    presentation.save("copied_language_metadata.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Om een bron zonder alternatieve taal te testen, laat de toewijzing van "fr-FR" weg. De alternatieve identifier is dan `None`, en dezelfde kopie‑instructie behoudt de afwezigheid zonder een standaardwaarde toe te voegen, zelfs als de bestemming eerder een alternatieve taal had toegewezen.

Deze identifiers worden opgeslagen als taalmetadata. Het behouden ervan bepaalt niet welke woordenlijst PowerPoint selecteert voor spelling‑ of grammaticacontrole.

## **Standaardtaal instellen**

Gebruik [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setDefaultTextLanguage) om de standaardtaal voor tekst te definiëren die wordt aangemaakt tijdens het laden of maken van een presentatie. Het volgende voorbeeld maakt een presentatie met VS‑Engels als standaardteksttaal, voegt een tekstvak toe, en print `en-US` voor het eerste tekstgedeelte.

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

    # Voeg een rechthoekvorm met tekst toe.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 50)
    shape.getTextFrame().setText("Sample text")

    # Controleer de taal van het eerste tekstgedeelte.
    portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    print(portion.getPortionFormat().getLanguageId())
finally:
    presentation.dispose()
```

## **Standaardtekststijl instellen**

Om standaardtekstopmaak op presentatieniveau toe te passen, gebruik [Presentation.getDefaultTextStyle](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getDefaultTextStyle).

Het volgende voorbeeld stelt een 14‑punt vet lettertype in als standaard voor top‑level alinea's in een nieuwe presentatie en slaat het op als “default_text_style.pptx”. Tekst kan deze standaarden erven, tenzij specifiekere opmaak ze overschrijft.

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

In PowerPoint maakt het toepassen van het **All Caps**‑lettertype‑effect dat tekst in hoofdletters wordt weergegeven op de dia, zelfs wanneer deze oorspronkelijk in kleine letters is getypt. Wanneer u zo’n tekstgedeelte ophaalt met Aspose.Slides, geeft de bibliotheek de tekst exact terug zoals ingevoerd. Om de weergegeven tekst overeen te laten komen, controleer [TextCapType](https://reference.aspose.com/slides/python-java/aspose.slides/textcaptype/) en zet de geretourneerde string om naar hoofdletters wanneer de waarde `All` is.

Dit voorbeeld vereist “sample2.pptx” met een tekstvak als eerste vorm op de eerste dia. Het eerste gedeelte van de eerste alinea bevat “Hello, Aspose!” met het All Caps‑effect toegepast, zoals hieronder getoond.

![Het All Caps‑effect](all_caps_effect.png)

Het codevoorbeeld hieronder toont hoe u de tekst extrahert met het **All Caps**‑effect toegepast:

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

Om tekst in een tabel op een dia te wijzigen, gebruik [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/). Loop door de cellen en werk elke cel bij via [Cell.getTextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getTextFrame) en alinea‑opmaak via [Paragraph.getParagraphFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/#getParagraphFormat).

**Hoe pas ik een kleurverloop toe op tekst in een PowerPoint‑dia?**

Om een kleurverloop op tekst toe te passen, gebruik [BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#getFillFormat). Stel [FillFormat.setFillType](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#setFillType) in op [FillType.Gradient](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/) en configureer de verloopstops, richting en transparantie.