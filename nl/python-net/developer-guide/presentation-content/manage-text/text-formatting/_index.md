---
title: Tekst opmaken in presentaties met Python
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
- lettertype-eigenschappen
- lettertypefamilie
- tekstrotatie
- rotatiehoek
- tekstframe
- regelafstand
- autofit-eigenschap
- tekstframe-anker
- teksttabulatie
- standaardtaal
- PowerPoint
- OpenDocument
- presentatie
- Python
- Aspose.Slides
description: "Formatteer en styleer tekst in PowerPoint- en OpenDocument-presentaties met Aspose.Slides voor Python via .NET. Pas lettertypen, kleuren, uitlijning en meer aan."
---
## **Overzicht**

Dit artikel laat zien hoe u tekst kunt opmaken in PowerPoint- en OpenDocument‑presentaties met Aspose.Slides voor Python via .NET. Het behandelt achtergrondkleuren, transparantie, tekenafstand, lettertype‑eigenschappen, rotatie, alineaspatiëring, autofit‑gedrag, tekstverankering, tabstops en taalinstellingen.

In de onderstaande voorbeelden gebruiken we een bestand genaamd "sample.pptx", dat een enkele tekstvak op de eerste dia bevat met de volgende tekst:

![Voorbeeldtekst](sample_text.png)

Zie ook [Zoek en vervang tekst](/slides/nl/python-net/search-and-replace-text/) om letterlijke tekst of reguliere‑expressie‑overeenkomsten te vinden en te markeren.

## **Instellen tekstachtergrondkleur**

Gebruik [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/nl/python-net/aspose.slides/paragraphformat/default_portion_format/) om de standaard markeerkleur voor een alinea in te stellen, of gebruik [PortionFormat.highlight_color](https://reference.aspose.com/slides/nl/python-net/aspose.slides/portionformat/highlight_color/) voor individuele tekstgedeelten.

Het volgende codevoorbeeld toont hoe u de achtergrondkleur voor de **hele alinea** kunt instellen:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Stel de markeerkleur in voor de volledige alinea.
    paragraph.paragraph_format.default_portion_format.highlight_color.color = draw.Color.light_gray

    presentation.save("gray_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Het resultaat:

![De grijze alinea](gray_paragraph.png)

Het codevoorbeeld hieronder toont hoe u de achtergrondkleur voor **tekstgedeelten met een vet lettertype** kunt instellen:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Stel de markeerkleur in voor het tekstgedeelte.
            portion.portion_format.highlight_color.color = draw.Color.light_gray

    presentation.save("gray_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

Het resultaat:

![De grijze tekstgedeelten](gray_text_portions.png)

## **Alinea's uitlijnen**

Gebruik [ParagraphFormat.alignment](https://reference.aspose.com/slides/nl/python-net/aspose.slides/paragraphformat/alignment/) om de uitlijning van alinea's binnen een tekstvak in te stellen. De waarde kan gecentreerd, links uitgelijnd, rechts uitgelijnd, uitgevuld, enzovoort zijn.

Het volgende codevoorbeeld toont hoe u de alinea naar het **midden** uitlijnt:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Stel de uitlijning van de alinea in op het midden.
    paragraph.paragraph_format.alignment = slides.TextAlignment.CENTER

    presentation.save("aligned_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Het resultaat:

![De uitgelijnde alinea](aligned_paragraph.png)

## **Transparantie voor tekst instellen**

De transparantie van tekst wordt geregeld via het alfacomponent van de kleur die is toegewezen aan [PortionFormat.fill_format](https://reference.aspose.com/slides/nl/python-net/aspose.slides/portionformat/fill_format/). In de onderstaande voorbeelden is `alpha = 50` een ARGB alfa-kanaalwaarde op de schaal 0-255, geen transparantiepercentage.

Het codevoorbeeld hieronder laat zien hoe u transparantie toepast op de **hele alinea**:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

alpha = 50

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Stel de vulkleur van de tekst in op transparante kleur.
    paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.from_argb(alpha, draw.Color.black)

    presentation.save("transparent_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Het resultaat:

![De transparante alinea](transparent_paragraph.png)

Het volgende codevoorbeeld toont hoe u transparantie toepast op **tekstgedeelten met een vet lettertype**:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

alpha = 50

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
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

Gebruik [BasePortionFormat.spacing](https://reference.aspose.com/slides/nl/python-net/aspose.slides/baseportionformat/spacing/) om de afstand tussen karakters in een tekstvak uit te breiden of te verkleinen.

De volgende Python‑code toont hoe u de tekenafstand in de **hele alinea** kunt vergroten:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Opmerking: Gebruik negatieve waarden om de tekenafstand te comprimeren.
    paragraph.paragraph_format.default_portion_format.spacing = 3  # Vergroot de tekenafstand.

    presentation.save("character_spacing_in_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Het resultaat:

![De tekenafstand in de alinea](character_spacing_in_paragraph.png)

Het codevoorbeeld hieronder toont hoe u de tekenafstand vergroot in **tekstgedeelten met een vet lettertype**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Opmerking: Gebruik negatieve waarden om de tekenafstand te comprimeren.
            portion.portion_format.spacing = 3  # Vergroot de tekenafstand.

    presentation.save("character_spacing_in_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

Het resultaat:

![De tekenafstand in de tekstgedeelten](character_spacing_in_text_portions.png)

### **Kerning uitschakelen voor specifieke lettertypes**

In sommige gevallen kan tekst die door Aspose.Slides wordt gerenderd er iets strakker uitzien dan dezelfde tekst in PowerPoint. Dit kan gebeuren omdat PowerPoint kerning-gegevens voor bepaalde lettertypes negeert, zelfs wanneer het lettertype geldige kerning-informatie bevat en kerning is ingeschakeld in de PowerPoint-instellingen.

Om de gerenderde weergave in dergelijke gevallen dichter bij PowerPoint te brengen, kunt u kerning uitschakelen voor tekstgedeelten die het betreffende lettertype gebruiken. Stel [BasePortionFormat.kerning_minimal_size](https://reference.aspose.com/slides/nl/python-net/aspose.slides/baseportionformat/kerning_minimal_size/) in op een waarde die aanzienlijk groter is dan de werkelijke lettergrootte:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    target_font = "Roboto"

    for paragraph in auto_shape.text_frame.paragraphs:
        for portion in paragraph.portions:
            latin_font = portion.portion_format.latin_font
            east_asian_font = portion.portion_format.east_asian_font
            complex_script_font = portion.portion_format.complex_script_font

            if ((latin_font is not None and latin_font.font_name == target_font) or
                    (east_asian_font is not None and east_asian_font.font_name == target_font) or
                    (complex_script_font is not None and complex_script_font.font_name == target_font)):
                portion.portion_format.kerning_minimal_size = 100

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

Deze instelling voorkomt dat kerning wordt toegepast op overeenkomende tekstgedeelten en kan helpen de weergave van Aspose.Slides te laten overeenkomen met de visuele output van PowerPoint voor lettertypes die door dit PowerPoint-specifieke gedrag worden beïnvloed.

## **Lettertype-eigenschappen van tekst beheren**

Lettertype-eigenschappen kunnen op alinea-niveau worden ingesteld via [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/nl/python-net/aspose.slides/paragraphformat/default_portion_format/) of op individuele gedeelten via [PortionFormat](https://reference.aspose.com/slides/nl/python-net/aspose.slides/portionformat/).

De volgende code stelt het lettertype en de tekststijl in voor de **hele alinea**: het past lettergrootte, vet, cursief, gestippelde onderstreping en het lettertype Times New Roman toe op alle gedeelten in de alinea.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Stel de lettertype-eigenschappen in voor de alinea.
    paragraph.paragraph_format.default_portion_format.font_height = 12
    paragraph.paragraph_format.default_portion_format.font_bold = slides.NullableBool.TRUE
    paragraph.paragraph_format.default_portion_format.font_italic = slides.NullableBool.TRUE
    paragraph.paragraph_format.default_portion_format.font_underline = slides.TextUnderlineType.DOTTED
    paragraph.paragraph_format.default_portion_format.latin_font = slides.FontData("Times New Roman")

    presentation.save("font_properties_for_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Het resultaat:

![De lettertype-eigenschappen voor de alinea](font_properties_for_paragraph.png)

Het codevoorbeeld hieronder past soortgelijke eigenschappen toe op **tekstgedeelten met een vet lettertype**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Stel de lettertype-eigenschappen in voor het tekstgedeelte.
            portion.portion_format.font_height = 13
            portion.portion_format.font_italic = slides.NullableBool.TRUE
            portion.portion_format.font_underline = slides.TextUnderlineType.DOTTED
            portion.portion_format.latin_font = slides.FontData("Times New Roman")

    presentation.save("font_properties_for_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

Het resultaat:

![De lettertype-eigenschappen voor tekstgedeelten](font_properties_for_text_portions.png)

## **Tekstrotatie instellen**

Gebruik [TextFrameFormat.text_vertical_type](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframeformat/text_vertical_type/) om een vooraf gedefinieerde tekstoriëntatie binnen een vorm in te stellen.

Het volgende codevoorbeeld stelt de tekstoriëntatie in de vorm in op `VERTICAL270`, waardoor de tekst **90 graden tegen de klok in** wordt geroteerd:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    auto_shape.text_frame.text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL270

    presentation.save("text_rotation.pptx", slides.export.SaveFormat.PPTX)
```

Het resultaat:

![De tekstrotatie](text_rotation.png)

## **Aangepaste rotatie voor tekstframes instellen**

Gebruik [TextFrameFormat.rotation_angle](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframeformat/rotation_angle/) om een aangepaste rotatiehoek in te stellen voor een [TextFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframe/).

Het codevoorbeeld hieronder roteert het tekstframe met 3 graden met de klok mee binnen de vorm:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    auto_shape.text_frame.text_frame_format.rotation_angle = 3

    presentation.save("custom_text_rotation.pptx", slides.export.SaveFormat.PPTX)
```

Het resultaat:

![De aangepaste tekstrotatie](custom_text_rotation.png)

## **Regelafstand van alinea's instellen**

Aspose.Slides biedt [ParagraphFormat.space_after](https://reference.aspose.com/slides/nl/python-net/aspose.slides/paragraphformat/space_after/), [ParagraphFormat.space_before](https://reference.aspose.com/slides/nl/python-net/aspose.slides/paragraphformat/space_before/) en [ParagraphFormat.space_within](https://reference.aspose.com/slides/nl/python-net/aspose.slides/paragraphformat/space_within/) om de afstand tussen alinea's te regelen. Deze eigenschappen worden als volgt gebruikt:

* Gebruik een positieve waarde om de regelafstand op te geven als een percentage van de regelhoogte.
* Gebruik een negatieve waarde om de regelafstand in punten op te geven.

Het volgende codevoorbeeld toont hoe u de regelafstand binnen de alinea kunt specificeren:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    paragraph.paragraph_format.space_within = 200

    presentation.save("line_spacing.pptx", slides.export.SaveFormat.PPTX)
```

Het resultaat:

![De regelafstand binnen de alinea](line_spacing.png)

## **Autofit-type voor tekstframes instellen**

[TextFrameFormat.autofit_type](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframeformat/autofit_type/) bepaalt hoe tekst zich gedraagt wanneer deze de grenzen van de container overschrijdt. Gebruik het om te controleren of de tekst wordt verkleind, overlapt of de vorm automatisch wordt aangepast.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    auto_shape.text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE

    presentation.save("autofit_type.pptx", slides.export.SaveFormat.PPTX)
```

## **Anker van tekstframes instellen**

[TextFrameFormat.anchoring_type](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframeformat/anchoring_type/) bepaalt hoe tekst verticaal in een vorm wordt gepositioneerd, bijvoorbeeld bovenaan, in het midden of onderaan.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    auto_shape.text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.BOTTOM

    presentation.save("text_anchor.pptx", slides.export.SaveFormat.PPTX)
```

## **Teksttabulatie instellen**

Gebruik [ParagraphFormat.default_tab_size](https://reference.aspose.com/slides/nl/python-net/aspose.slides/paragraphformat/default_tab_size/) en [ParagraphFormat.tabs](https://reference.aspose.com/slides/nl/python-net/aspose.slides/paragraphformat/tabs/) om tabstops in een alinea te configureren.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    paragraph.paragraph_format.default_tab_size = 100
    paragraph.paragraph_format.tabs.add(30, slides.TabAlignment.LEFT)

    presentation.save("paragraph_tabs.pptx", slides.export.SaveFormat.PPTX)
```

Het resultaat:

![De alinea-tabstops](paragraph_tabs.png)

## **Controlerende taal instellen**

Aspose.Slides biedt [PortionFormat.language_id](https://reference.aspose.com/slides/nl/python-net/aspose.slides/portionformat/language_id/), waarmee u de controlerende taal voor een tekstgedeelte kunt instellen. De controlerende taal bepaalt welke taal wordt gebruikt voor spellings- en grammaticacontrole in PowerPoint.

Het volgende codevoorbeeld toont hoe u de controlerende taal voor een tekstgedeelte instelt:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    paragraph = auto_shape.text_frame.paragraphs[0]
    paragraph.portions.clear()

    font = slides.FontData("SimSun")

    text_portion = slides.Portion()
    text_portion.portion_format.complex_script_font = font
    text_portion.portion_format.east_asian_font = font
    text_portion.portion_format.latin_font = font

    # Stel de ID van een correctietaal in.
    text_portion.portion_format.language_id = "zh-CN"

    text_portion.text = "1。"
    paragraph.portions.add(text_portion)

    presentation.save("proofing_language.pptx", slides.export.SaveFormat.PPTX)
```

## **Standaardtaal instellen**

Gebruik [LoadOptions.default_text_language](https://reference.aspose.com/slides/nl/python-net/aspose.slides/loadoptions/default_text_language/) om de standaardtaal te definiëren voor tekst die wordt aangemaakt tijdens het laden of maken van een presentatie.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.default_text_language = "en-US"

with slides.Presentation(load_options) as presentation:
    slide = presentation.slides[0]

    # Voeg een nieuwe rechthoekvorm met tekst toe.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 50)
    shape.text_frame.text = "Sample text"

    # Controleer de taal van het eerste tekstgedeelte.
    portion = shape.text_frame.paragraphs[0].portions[0]
    print(portion.portion_format.language_id)
```

## **Standaard tekststijl instellen**

Om standaard tekstopmaak toe te passen op presentatieniveau, gebruikt u [Presentation.default_text_style](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/default_text_style/).

Het volgende codevoorbeeld toont hoe u een standaard vet lettertype met een grootte van 14 pt instelt voor alle tekst op alle dia's in een nieuwe presentatie.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    # Haal het alineaformaat van het hoogste niveau op.
    paragraph_format = presentation.default_text_style.get_level(0)

    if paragraph_format is not None:
        paragraph_format.default_portion_format.font_height = 14
        paragraph_format.default_portion_format.font_bold = slides.NullableBool.TRUE

    presentation.save("default_text_style.pptx", slides.export.SaveFormat.PPTX)
```

## **Tekst extraheren met hoofdletters-effect**

In PowerPoint zorgt het toepassen van het **All Caps**-lettertype-effect ervoor dat tekst in hoofdletters op de dia wordt weergegeven, zelfs als deze oorspronkelijk in kleine letters is getypt. Wanneer u zo’n tekstgedeelte ophaalt met Aspose.Slides, geeft de bibliotheek de tekst precies terug zoals ingevoerd. Om overeen te komen met de weergegeven tekst, controleert u [TextCapType](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textcaptype/) en zet u de geretourneerde tekenreeks om naar hoofdletters wanneer de waarde `ALL` is.

Laten we zeggen dat we het volgende tekstvak hebben op de eerste dia van het bestand sample2.pptx.

![Het All Caps-effect](all_caps_effect.png)

Het codevoorbeeld hieronder toont hoe u de tekst kunt extraheren met het **All Caps**-effect toegepast:

```python
import aspose.slides as slides

with slides.Presentation("sample2.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
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

**Hoe pas ik tekst aan in een tabel op een dia?**

Om tekst in een tabel op een dia aan te passen, gebruikt u [Table](https://reference.aspose.com/slides/nl/python-net/aspose.slides/table/). Loop door de cellen en werk elke cel bij via [Cell.text_frame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/cell/text_frame/) en alinea-opmaak via [Paragraph.paragraph_format](https://reference.aspose.com/slides/nl/python-net/aspose.slides/paragraph/paragraph_format/).

**Hoe pas ik een verlopen kleur toe op tekst in een PowerPoint-dia?**

Om een verlopen kleur op tekst toe te passen, gebruikt u [PortionFormat.fill_format](https://reference.aspose.com/slides/nl/python-net/aspose.slides/portionformat/fill_format/). Stel [FillFormat.fill_type](https://reference.aspose.com/slides/nl/python-net/aspose.slides/fillformat/fill_type/) in op [FillType.GRADIENT](https://reference.aspose.com/slides/nl/python-net/aspose.slides/filltype/) en configureer de verloopstops, richting en transparantie.