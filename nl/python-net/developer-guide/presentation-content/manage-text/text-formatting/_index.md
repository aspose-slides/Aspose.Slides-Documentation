---
title: Presentatietekst opmaken in Python
linktitle: Tekstopmaak
type: docs
weight: 50
url: /nl/python-net/text-formatting/
keywords:
- alinea uitlijnen
- tekststijl
- tekstachtergrond
- teksttransparantie
- tekenafstand
- fonteigenschappen
- fontfamilie
- tekstrotatie
- rotatiehoek
- tekstframe
- regelafstand
- autofit‑eigenschap
- tekstframe‑ankerpunt
- teksttabulatie
- standaardtaal
- PowerPoint
- OpenDocument
- presentatie
- Python
- Aspose.Slides
description: "Opmaak en stijl van tekst in PowerPoint‑ en OpenDocument‑presentaties met Aspose.Slides voor Python via .NET. Pas lettertypes, kleuren, uitlijning en meer aan."
---
## **Overzicht**

Dit artikel laat zien hoe u tekst kunt opmaken in PowerPoint‑ en OpenDocument‑presentaties met Aspose.Slides for Python via .NET. Het behandelt achtergrondkleuren, transparantie, tekenafstand, font‑eigenschappen, rotatie, alinea‑afstand, autofit‑gedrag, tekst‑ankering, tab‑stops en taalinstellingen.

Tenzij anders vermeld, gebruiken de voorbeelden [sample.pptx](sample.pptx). De eerste vorm op de eerste dia is een tekstvak, en de eerste alinea daarvan bevat de onderstaande tekst. Zowel dia‑ als vormindices beginnen bij nul. Voorbeelden die vetgedrukte delen selecteren gebruiken effectieve opmaak, inclusief geërfde vette opmaak:

![Voorbeeldtekst](sample_text.png)

Om letterlijke tekst of reguliere‑expressie‑overeenkomsten te vinden en te markeren, zie [Zoeken en vervangen van tekst](/slides/nl/python-net/search-and-replace-text/).

## **Achtergrondkleur van tekst instellen**

Gebruik [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/) om de standaard markeerkleur voor een alinea in te stellen, of gebruik [BasePortionFormat.highlight_color](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/highlight_color/) voor individuele tekstgedeelten.

Het volgende voorbeeld stelt een lichtgrijze markering in als standaard voor de eerste alinea. Expliciete markeerkleuren op individuele gedeelten hebben voorrang op deze standaard:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Stel de markeerkleur in voor de volledige alinea.
    paragraph.paragraph_format.default_portion_format.highlight_color.color = draw.Color.light_gray

    presentation.save("gray_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Het resultaat:

![De grijze alinea](gray_paragraph.png)

De code‑voorbeeld hieronder toont hoe u de achtergrondkleur kunt instellen voor **tekstgedeelten met een vet lettertype**:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Stel de markeerkleur in voor het tekstgedeelte.
            portion.portion_format.highlight_color.color = draw.Color.light_gray

    presentation.save("gray_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

Het resultaat:

![De grijze tekstgedeelten](gray_text_portions.png)

## **Tekst‑alinea's uitlijnen**

Gebruik [ParagraphFormat.alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) om de alinea‑uitlijning binnen een tekstvak in te stellen. De waarde kan gecentreerd, links uitgelijnd, rechts uitgelijnd, uitgevuld, enz. zijn.

Het volgende code‑voorbeeld toont hoe u de alinea naar het **midden** kunt uitlijnen:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Stel de uitlijning van de alinea in op centrum.
    paragraph.paragraph_format.alignment = slides.TextAlignment.CENTER

    presentation.save("aligned_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Het resultaat:

![De uitgelijnde alinea](aligned_paragraph.png)

## **Lettertypen binnen een regel uitlijnen**

Gebruik [ParagraphFormat.font_alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/font_alignment/) om tekstgedeelten met verschillende lettergroottes verticaal uit te lijnen binnen een regel. Deze instelling is van toepassing op de hele alinea en beheert de uitlijning binnen elke regel.

Het volgende zelfstandige voorbeeld maakt vier gelabelde tekstvakken op één dia. Elke alinea bevat dezelfde tekst in 18, 36 en 54 punten, met een andere lettertype‑uitlijning. Het gebruikt Arial, schakelt autofit en afbreken uit, en houdt de tekstvakken groot genoeg voor één regel.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    alignments = [slides.FontAlignment.BASELINE, slides.FontAlignment.TOP, slides.FontAlignment.CENTER, slides.FontAlignment.BOTTOM]
    font_sizes = [18, 36, 54]

    for i, alignment in enumerate(alignments):
        shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 20 + i * 130, 660, 120)
        shape.fill_format.fill_type = slides.FillType.NO_FILL
        shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL

        text_frame = shape.text_frame
        text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.TOP
        text_frame.text_frame_format.autofit_type = slides.TextAutofitType.NONE
        text_frame.text_frame_format.wrap_text = slides.NullableBool.FALSE

        label = text_frame.paragraphs[0]
        label.text = alignment.name.title()
        label.paragraph_format.alignment = slides.TextAlignment.LEFT
        label.paragraph_format.default_portion_format.font_height = 14
        label.paragraph_format.default_portion_format.latin_font = slides.FontData("Arial")
        label.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
        label.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.gray

        paragraph = slides.Paragraph()
        paragraph.paragraph_format.font_alignment = alignment
        paragraph.paragraph_format.alignment = slides.TextAlignment.LEFT
        paragraph.paragraph_format.default_portion_format.latin_font = slides.FontData("Arial")
        paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
        paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black

        for font_size in font_sizes:
            portion = slides.Portion("Ag ")
            portion.portion_format.font_height = font_size
            paragraph.portions.add(portion)

        text_frame.paragraphs.add(paragraph)

    presentation.save("font_alignment.pptx", slides.export.SaveFormat.PPTX)
```

Het resultaat:

![Vergelijking van Basislijn, Top, Midden en Onder lettertype‑uitlijning met gemengde lettergroottes](font_alignment.png)

Lettertype‑uitlijning maakt gebruik van font‑metrieken, zodat de zichtbare randen van individuele letters niet per se exact op één lijn liggen. Het voorbeeld bevat zowel een hoofdletter als een afdalende letter om het verschil tussen basislijn‑ en onder‑uitlijning te laten zien. Beschikbaarheid en substitutie van fonts, de gebruikte tekens, en het verschil in lettergroottes beïnvloeden het resultaat. Frame‑afmetingen, marges, regelafstand, afbreken en autofit beïnvloeden ook de lay‑out; gebruik dezelfde fonts en lay‑outinstellingen bij het vergelijken van de modi.

Deze instelling verschilt van [ParagraphFormat.alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/), die de horizontale alinea‑uitlijning regelt, en van [TextFrameFormat.anchoring_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/anchoring_type/), die het tekstblok verticaal binnen de vorm positioneert. Superscript‑ en subscript‑opmaak via [BasePortionFormat.escapement](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/escapement/) verschuift individuele gedeelten ten opzichte van de basislijn in plaats van de lettertype‑uitlijning voor de regellijnen van de alinea in te stellen.

## **Transparantie van tekst instellen**

Transparantie van tekst wordt geregeld via het alfa‑component van de kleur die aan [BasePortionFormat.fill_format](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/fill_format/) is toegewezen. In de onderstaande voorbeelden is `alpha = 50` een ARGB‑alfa‑waarde op de schaal 0–255, geen transparantie‑percentage.

Het code‑voorbeeld hieronder toont hoe u transparantie kunt toepassen op de **hele alinea**:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

alpha = 50

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Stel een halftransparante zwarte vulling in voor de tekst.
    paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.from_argb(alpha, draw.Color.black)

    presentation.save("transparent_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Het resultaat:

![De transparante alinea](transparent_paragraph.png)

Het volgende code‑voorbeeld toont hoe u transparantie kunt toepassen op **tekstgedeelten met een vet lettertype**:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

alpha = 50

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Stel de transparantie van het tekstgedeelte in.
            portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
            portion.portion_format.fill_format.solid_fill_color.color = draw.Color.from_argb(alpha, draw.Color.black)

    presentation.save("transparent_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

Het resultaat:

![De transparante tekstgedeelten](transparent_text_portions.png)

## **Tekenafstand voor tekst instellen**

Gebruik [BasePortionFormat.spacing](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/spacing/) om de spatiëring tussen tekens in een tekstvak uit te breiden of samen te trekken. De voorbeelden voegen 3 punten spatiëring toe; negatieve waarden trekken de tekst samen.

De volgende Python‑code laat zien hoe u de tekenafstand in de **hele alinea** kunt vergroten:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Opmerking: Gebruik negatieve waarden om de tekenafstand te verkleinen.
    paragraph.paragraph_format.default_portion_format.spacing = 3  # Vergroot de tekenafstand.

    presentation.save("character_spacing_in_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Het resultaat:

![De tekenafstand in de alinea](character_spacing_in_paragraph.png)

Het code‑voorbeeld hieronder toont hoe u de tekenafstand kunt vergroten in **tekstgedeelten met een vet lettertype**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Opmerking: Gebruik negatieve waarden om de tekenafstand te verkleinen.
            portion.portion_format.spacing = 3  # Vergroot de tekenafstand.

    presentation.save("character_spacing_in_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

Het resultaat:

![De tekenafstand in de tekstgedeelten](character_spacing_in_text_portions.png)

### **Kerning voor specifieke fonts uitschakelen**

In sommige gevallen kan tekst die door Aspose.Slides wordt gerenderd er iets strakker uitzien dan dezelfde tekst in PowerPoint. Dit kan gebeuren omdat PowerPoint kerning‑gegevens voor bepaalde fonts negeert, zelfs wanneer het font geldige kerning‑informatie bevat en kerning in de PowerPoint‑instellingen is ingeschakeld.

Om de gerenderde output dichter bij PowerPoint te brengen in zulke gevallen, kunt u kerning uitschakelen voor tekstgedeelten die het betreffende font gebruiken. Stel [BasePortionFormat.kerning_minimal_size](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/kerning_minimal_size/) in op een waarde die groter is dan de werkelijke fontgrootte. Dit voorbeeld vereist "presentation.pptx" met een tekstvak als eerste vorm op de eerste dia. Het controleert effectieve fontnamen, inclusief geërfde fonts, en stelt een drempel van 100 punten in voor gedeelten die Roboto gebruiken. Dit schakelt kerning uit voor overeenkomende gedeelten met een fontgrootte onder de 100 punten:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    target_font = "Roboto"

    for paragraph in auto_shape.text_frame.paragraphs:
        for portion in paragraph.portions:
            text_format = portion.portion_format.get_effective()
            fonts = (text_format.latin_font, text_format.east_asian_font, text_format.complex_script_font)
            uses_target_font = any(font is not None and font.font_name == target_font for font in fonts)

            if uses_target_font:
                portion.portion_format.kerning_minimal_size = 100

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

Voor overeenkomende tekst onder de drempel voorkomt deze instelling kerning en kan het helpen de weergave van Aspose.Slides af te stemmen op de visuele output van PowerPoint voor fonts die door dit PowerPoint‑specifieke gedrag worden beïnvloed.

## **Tekst‑font‑eigenschappen beheren**

Font‑eigenschappen kunnen op alinea‑niveau worden ingesteld via [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/) of op individuele gedeelten via [PortionFormat](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/).

Het volgende voorbeeld stelt de standaard font van de eerste alinea in op 12‑punt Times New Roman met vet, cursief en gestippelde onderstreping. Expliciete opmaak op individuele gedeelten heeft voorrang op deze standaarden.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Stel de lettertype‑eigenschappen voor de alinea in.
    portion_format = paragraph.paragraph_format.default_portion_format
    portion_format.font_height = 12
    portion_format.font_bold = slides.NullableBool.TRUE
    portion_format.font_italic = slides.NullableBool.TRUE
    portion_format.font_underline = slides.TextUnderlineType.DOTTED
    portion_format.latin_font = slides.FontData("Times New Roman")

    presentation.save("font_properties_for_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Het resultaat:

![De font‑eigenschappen voor de alinea](font_properties_for_paragraph.png)

Het volgende voorbeeld past 13‑punt Times New Roman, cursieve opmaak en een gestippelde onderstreping toe op gedeelten waarvan de effectieve opmaak vet is:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Stel de lettertype‑eigenschappen in voor het tekstgedeelte.
            portion.portion_format.font_height = 13
            portion.portion_format.font_italic = slides.NullableBool.TRUE
            portion.portion_format.font_underline = slides.TextUnderlineType.DOTTED
            portion.portion_format.latin_font = slides.FontData("Times New Roman")

    presentation.save("font_properties_for_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

Het resultaat:

![De font‑eigenschappen voor tekstgedeelten](font_properties_for_text_portions.png)

## **Tekstrotatie instellen**

Gebruik [TextFrameFormat.text_vertical_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/text_vertical_type/) om een vooraf gedefinieerde tekstoriëntatie binnen een vorm in te stellen.

Het volgende code‑voorbeeld stelt de tekstoriëntatie in de vorm in op [TextVerticalType.VERTICAL270](https://reference.aspose.com/slides/python-net/aspose.slides/textverticaltype/), wat de tekst **90 graden tegen de klok in** roteert:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL270

    presentation.save("text_rotation.pptx", slides.export.SaveFormat.PPTX)
```

Het resultaat:

![De tekstrotatie](text_rotation.png)

## **Aangepaste rotatie voor tekstframes instellen**

Gebruik [TextFrameFormat.rotation_angle](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/rotation_angle/) om een aangepaste rotatiehoek in te stellen voor een [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/).

Het code‑voorbeeld hieronder roteert het tekstframe met 3 graden met de klok mee binnen de vorm:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.rotation_angle = 3

    presentation.save("custom_text_rotation.pptx", slides.export.SaveFormat.PPTX)
```

Het resultaat:

![De aangepaste tekstrotatie](custom_text_rotation.png)

## **Regelafstand van alinea's instellen**

Aspose.Slides biedt [ParagraphFormat.space_after](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_after/), [ParagraphFormat.space_before](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_before/), en [ParagraphFormat.space_within](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_within/) om de alinea‑afstand te regelen. Deze eigenschappen worden als volgt gebruikt:

* Gebruik een positieve waarde om regelafstand op te geven als een percentage van de regelhoogte.
* Gebruik een negatieve waarde om regelafstand in punten op te geven.

Het volgende voorbeeld stelt de spatiëring binnen de eerste alinea in op 200 % van de regelhoogte (dubbele regelafstand):

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    paragraph.paragraph_format.space_within = 200

    presentation.save("line_spacing.pptx", slides.export.SaveFormat.PPTX)
```

Het resultaat:

![De regelafstand binnen de alinea](line_spacing.png)

## **Regelafbreking beheersen**

Regel‑afbreekregels voor alinea’s zijn bruikbaar in smalle tekstblokken en presentaties die Latijnse en Oost‑Aziatische tekst combineren. De volgende eigenschappen behoren tot [ParagraphFormat](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/), dus ze gelden voor een volledige alinea:

- [latin_line_break](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/latin_line_break/) regelt de Latijnse regel‑afbreekregels. In gemengde tekst kan het aanpassen ervan ook wijzigen waar aangrenzende Oost‑Aziatische tekst en interpunctie afbreken.
- [east_asian_line_break](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/east_asian_line_break/) regelt de Oost‑Aziatische regel‑afbreekregels, inclusief beperkingen voor tekens aan het begin en einde van een regel.

Deze regels vervangen niet [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/wrap_text/), die automatisch afbreken binnen een tekstframe inschakelt. Ze beïnvloeden de lay‑out wanneer afbreken plaatsvindt; ze voegen geen regeleinde‑tekens toe. Een expliciete regeleinde dwingt een nieuwe regel binnen de alinea, onafhankelijk van de beschikbare breedte.

Het volgende zelfstandige voorbeeld maakt een smal tekstblok met Chinese en Latijnse tekst. Het stelt beide regel‑afbreek‑eigenschappen expliciet in en slaat "line_breaking.pptx" op. Om met een regel te experimenteren, wijzig de waarde van die eigenschap terwijl u de andere instellingen ongewijzigd laat. Het voorbeeld gebruikt 24‑punt Arial en SimSun met een frame‑breedte van 160 punten en nul horizontale tekst‑frame‑marges. [TextFrameFormat.autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/) is ingesteld op [TextAutofitType.NONE](https://reference.aspose.com/slides/python-net/aspose.slides/textautofittype/) zodat tekstgrootte en frame‑afmetingen vast blijven.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 160, 300)
    shape.fill_format.fill_type = slides.FillType.NO_FILL

    text_frame = shape.text_frame
    text_frame.text_frame_format.wrap_text = slides.NullableBool.TRUE
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.NONE
    text_frame.text_frame_format.margin_left = 0
    text_frame.text_frame_format.margin_right = 0

    paragraph = text_frame.paragraphs[0]
    paragraph.text = "中文排版测试，PowerPoint 中文演示。"

    paragraph_format = paragraph.paragraph_format
    paragraph_format.alignment = slides.TextAlignment.LEFT
    paragraph_format.default_portion_format.font_height = 24
    paragraph_format.default_portion_format.latin_font = slides.FontData("Arial")
    paragraph_format.default_portion_format.east_asian_font = slides.FontData("SimSun")
    paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    paragraph_format.latin_line_break = slides.NullableBool.FALSE
    paragraph_format.east_asian_line_break = slides.NullableBool.TRUE

    presentation.save("line_breaking.pptx", slides.export.SaveFormat.PPTX)
```

## **Hangende interpunctie beheersen**

[ParagraphFormat.hanging_punctuation](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/hanging_punctuation/) staat toe dat in aanmerking komende interpunctie zich uitstrekt voorbij de rechterkant van de tekstregel in plaats van de volgende regel in te nemen. Het geldt voor de volledige alinea en verschilt van een hangende inspringing.

Het volgende zelfstandige voorbeeld schakelt hangende interpunctie in een 100‑punten breed tekstframe in en slaat "hanging_punctuation.pptx" op. Met 24‑punt Arial en nul horizontale tekst‑frame‑marges blijft de punt achter "sentence" staan en strekt zich uit voorbij de rechterkant van de tekst. Stel de eigenschap in op [NullableBool.FALSE](https://reference.aspose.com/slides/python-net/aspose.slides/nullablebool/) om te vergelijken: met deze instellingen staat de punt op een aparte regel. Afbreken is ingeschakeld en autofit uitgeschakeld om de beschikbare breedte vast te houden.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 100, 200)
    shape.fill_format.fill_type = slides.FillType.NO_FILL

    text_frame = shape.text_frame
    text_frame.text_frame_format.wrap_text = slides.NullableBool.TRUE
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.NONE
    text_frame.text_frame_format.margin_left = 0
    text_frame.text_frame_format.margin_right = 0

    paragraph = text_frame.paragraphs[0]
    paragraph.text = "Simple text, next sentence."

    paragraph_format = paragraph.paragraph_format
    paragraph_format.alignment = slides.TextAlignment.LEFT
    paragraph_format.default_portion_format.font_height = 24
    paragraph_format.default_portion_format.latin_font = slides.FontData("Arial")
    paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    paragraph_format.hanging_punctuation = slides.NullableBool.TRUE

    presentation.save("hanging_punctuation.pptx", slides.export.SaveFormat.PPTX)
```

Niet elk leesteken kan hangend zijn. Het zichtbare resultaat hangt af van [font‑ en lay‑out‑condities](#control-line-breaking): het wijzigen van het font, de beschikbare breedte, marges of autofit‑instellingen kan het zichtbare verschil wegnemen.

## **Autofit‑type voor tekstframes instellen**

[TextFrameFormat.autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/) bepaalt hoe tekst zich gedraagt wanneer deze de grenzen van de container overschrijdt. Gebruik het om te regelen of de tekst krimpt, overloopt of de vorm automatisch schaalt. Het volgende voorbeeld configureert de vorm zodat deze wordt aangepast aan de tekst en slaat het resultaat op als "autofit_type.pptx".

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE

    presentation.save("autofit_type.pptx", slides.export.SaveFormat.PPTX)
```

Om het aantal regels te tellen na automatisch afbreken en te zien hoe tekst‑ of vorm‑breedte het resultaat verandert, zie [Aantal gerenderde regels](/slides/nl/python-net/manage-paragraph/). Aantal regels alleen geeft niet aan of tekst buiten de container overlapt.

## **Anker van tekstframes instellen**

[TextFrameFormat.anchoring_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/anchoring_type/) definieert hoe tekst verticaal binnen een vorm wordt gepositioneerd, bijvoorbeeld bovenaan, in het midden of onderaan. Het volgende voorbeeld ankert de tekst aan de onderkant van de eerste vorm en slaat het resultaat op als "text_anchor.pptx".

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.BOTTOM

    presentation.save("text_anchor.pptx", slides.export.SaveFormat.PPTX)
```

## **Tekst‑tabulatie instellen**

Gebruik [ParagraphFormat.default_tab_size](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_tab_size/) en [ParagraphFormat.tabs](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/tabs/) om tab‑stops in een alinea te configureren. Het volgende voorbeeld stelt de standaard tab‑intervallen in op 100 punten en voegt een links uitgelijnde tab‑stop toe op 30 punten. Deze instellingen beïnvloeden tekst die tab‑tekens bevat.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    paragraph.paragraph_format.default_tab_size = 100
    paragraph.paragraph_format.tabs.add(30, slides.TabAlignment.LEFT)

    presentation.save("paragraph_tabs.pptx", slides.export.SaveFormat.PPTX)
```

Het resultaat:

![De alinea‑tabs](paragraph_tabs.png)

## **Controlerende taal instellen**

Aspose.Slides biedt [BasePortionFormat.language_id](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/language_id/), waarmee u de controletaal voor een tekstgedeelte kunt instellen. De controletaal bepaalt de taal die wordt gebruikt voor spelling‑ en grammatica‑controles in PowerPoint.

Het volgende voorbeeld vereist "presentation.pptx" met een tekstvak als eerste vorm op de eerste dia en ten minste één alinea. Het vervangt de inhoud van de eerste alinea door "1。", stelt SimSun in als het font en wijst de vereenvoudigde Chinese controletaal (`zh-CN`) toe. Het slaat het resultaat op als "proofing_language.pptx":

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    paragraph = auto_shape.text_frame.paragraphs[0]
    paragraph.portions.clear()

    font = slides.FontData("SimSun")

    text_portion = slides.Portion()
    text_portion.portion_format.complex_script_font = font
    text_portion.portion_format.east_asian_font = font
    text_portion.portion_format.latin_font = font

    # Stel de proefleestaal in op Vereenvoudigd Chinees.
    text_portion.portion_format.language_id = "zh-CN"

    text_portion.text = "1。"
    paragraph.portions.add(text_portion)

    presentation.save("proofing_language.pptx", slides.export.SaveFormat.PPTX)
```

## **Standaardtaal instellen**

Gebruik [LoadOptions.default_text_language](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/default_text_language/) om de standaardtaal te definiëren voor tekst die wordt aangemaakt tijdens het laden of maken van een presentatie. Het volgende voorbeeld maakt een presentatie met VS‑Engels als de standaardteksttaal, voegt een tekstvak toe en geeft `en-US` weer voor het eerste tekstgedeelte.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.default_text_language = "en-US"

with slides.Presentation(load_options) as presentation:
    slide = presentation.slides[0]

    # Voeg een nieuwe rechthoekige vorm toe met tekst.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 50)
    shape.text_frame.text = "Sample text"

    # Controleer de taal van het eerste tekstgedeelte.
    portion = shape.text_frame.paragraphs[0].portions[0]
    print(portion.portion_format.language_id)
```

## **Standaard‑tekststijl instellen**

Om standaard‑tekstopmaak op presentatieniveau toe te passen, gebruik [Presentation.default_text_style](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/default_text_style/).

Het volgende voorbeeld stelt een 14‑punt vet font in als standaard voor alinea's op het hoogste niveau in een nieuwe presentatie en slaat deze op als "default_text_style.pptx". Tekst kan deze standaarden erven tenzij specifiekere opmaak ze overschrijft.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    # Haal het alinea‑formaat van het hoogste niveau op.
    paragraph_format = presentation.default_text_style.get_level(0)

    if paragraph_format is not None:
        paragraph_format.default_portion_format.font_height = 14
        paragraph_format.default_portion_format.font_bold = slides.NullableBool.TRUE

    presentation.save("default_text_style.pptx", slides.export.SaveFormat.PPTX)
```

## **Tekst extraheren met het All-Caps‑effect**

In PowerPoint zorgt het toepassen van het **All Caps**‑fonteffect ervoor dat tekst in hoofdletters wordt weergegeven op de dia, zelfs als deze oorspronkelijk in kleine letters is getypt. Wanneer u zo’n tekstgedeelte ophaalt met Aspose.Slides, retourneert de bibliotheek de tekst exact zoals ingevoerd. Om overeen te komen met de getoonde tekst, controleer [TextCapType](https://reference.aspose.com/slides/python-net/aspose.slides/textcaptype/) en zet de teruggegeven string om naar hoofdletters wanneer de waarde `ALL` is.

Dit voorbeeld vereist "sample2.pptx" met een tekstvak als eerste vorm op de eerste dia. Het eerste gedeelte van de eerste alinea bevat "Hello, Aspose!" met het All Caps‑effect toegepast, zoals hieronder weergegeven.

![Het All Caps‑effect](all_caps_effect.png)

Het code‑voorbeeld hieronder toont hoe u de tekst kunt extraheren met het **All Caps**‑effect toegepast:

```python
import aspose.slides as slides

with slides.Presentation("sample2.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    text_portion = auto_shape.text_frame.paragraphs[0].portions[0]

    print("Original text:", text_portion.text)

    text_format = text_portion.portion_format.get_effective()
    if text_format.text_cap_type == slides.TextCapType.ALL:
        text = text_portion.text.upper()
        print("All-Caps effect:", text)
```

Uitvoer:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **FAQ**

**Hoe wijzig ik tekst in een tabel op een dia?**

Om tekst in een tabel op een dia te wijzigen, gebruik [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/). Loop door de cellen en werk elke cel bij via [Cell.text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/cell/text_frame/) en alinea‑opmaak via [Paragraph.paragraph_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/paragraph_format/).

**Hoe pas ik een gradientkleur toe op tekst op een PowerPoint‑dia?**

Om een gradientkleur op tekst toe te passen, gebruik [BasePortionFormat.fill_format](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/fill_format/). Stel [FillFormat.fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) in op [FillType.GRADIENT](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) en configureer de gradientstops, richting en transparantie.