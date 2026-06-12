---
title: Tekst van presentatie opmaken in Python
linktitle: Tekstopmaak
type: docs
weight: 50
url: /nl/python-net/text-formatting/
keywords:
- tekst markeren
- reguliere expressie
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
- anker van tekstkader
- teksttabulatie
- standaardtaal
- PowerPoint
- OpenDocument
- presentatie
- Python
- Aspose.Slides
description: "Tekst opmaken en stijlen in PowerPoint- en OpenDocument-presentaties met Aspose.Slides voor Python via .NET. Pas lettertypen, kleuren, uitlijning en meer aan."
---
## **Overzicht**

Dit artikel laat zien hoe u tekst kunt opmaken in PowerPoint‑ en OpenDocument‑presentaties met Aspose.Slides voor Python via .NET. Het behandelt markering, achtergrondkleuren, transparantie, tekenafstand, lettertype‑eigenschappen, rotatie, alinea‑afstand, autofit‑gedrag, tekst‑ankering, tab‑stops en taalinstellingen.

In de onderstaande voorbeelden gebruiken we een bestand genaamd "sample.pptx", dat een enkele tekstvak op de eerste dia bevat met de volgende tekst:

![Voorbeeldtekst](sample_text.png)

## **Tekst markeren**

Gebruik de [TextFrame.highlight_text](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframe/highlight_text/) methode wanneer u tekst wilt markeren die overeenkomt met een specifieke voorbeeldtekst binnen een tekstkader. De methode past een markeerkleur toe op overeenkomende tekstfragmenten en kan worden gebruikt met [TextSearchOptions](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textsearchoptions/) om te bepalen hoe de zoekopdracht wordt uitgevoerd, bijvoorbeeld om alleen volledige woorden te matchen.

Het onderstaande codevoorbeeld markeert alle voorkomens van de tekens **"try"** en markeert vervolgens alleen het volledige woord **"to"**.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    # Haal de eerste vorm van de eerste dia op.
    shape = presentation.slides[0].shapes[0]

    # Markeer het woord "try" in de vorm.
    shape.text_frame.highlight_text("try", draw.Color.light_blue)

    search_options = slides.TextSearchOptions()
    search_options.whole_words_only = True

    # Markeer het woord "to" in de vorm.
    shape.text_frame.highlight_text("to", draw.Color.violet, search_options, None)

    presentation.save("highlighted_text.pptx", slides.export.SaveFormat.PPTX)
```

Het resultaat:

![De gemarkeerde tekst](highlighted_text.png)

## **Tekst markeren met reguliere expressies**

De [TextFrame.highlight_regex](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframe/highlight_regex/) methode markeert tekst die gevonden is met een reguliere expressie. In Python wordt deze API beschikbaar gesteld via [TextFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframe/).

Het onderstaande codevoorbeeld markeert alle woorden die **zeven of meer tekens** bevatten:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    regex = r"\b[^\s]{7,}\b"

    # Markeer alle woorden met zeven of meer tekens.
    shape.text_frame.highlight_regex(regex, draw.Color.yellow, None)

    presentation.save("highlighted_text_using_regex.pptx", slides.export.SaveFormat.PPTX)
```

Het resultaat:

![De gemarkeerde tekst met de reguliere expressie](highlighted_text_using_regex.png)

## **Tekstachtergrondkleur instellen**

Gebruik [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/nl/python-net/aspose.slides/paragraphformat/default_portion_format/) om de standaard markeerkleur voor een alinea in te stellen, of gebruik [PortionFormat.highlight_color](https://reference.aspose.com/slides/nl/python-net/aspose.slides/portionformat/highlight_color/) voor individuele tekstgedeelten.

Het volgende codevoorbeeld laat zien hoe u de achtergrondkleur voor de **hele alinea** instelt:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Stel de markeerkleur in voor de hele alinea.
    paragraph.paragraph_format.default_portion_format.highlight_color.color = draw.Color.light_gray

    presentation.save("gray_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Het resultaat:

![De grijze alinea](gray_paragraph.png)

Het onderstaande codevoorbeeld toont hoe u de achtergrondkleur voor **tekstgedeelten met een vet lettertype** instelt:

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

## **Tekst alinea's uitlijnen**

Gebruik [ParagraphFormat.alignment](https://reference.aspose.com/slides/nl/python-net/aspose.slides/paragraphformat/alignment/) om de alinea‑uitlijning binnen een tekstkader in te stellen. De waarde kan gecentreerd, links uitgelijnd, rechts uitgelijnd, gerechtvaardigd, enzovoort zijn.

Het volgende codevoorbeeld laat zien hoe u de alinea naar het **midden** uitlijnt:

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

Teksttransparantie wordt geregeld via het alfacomponent van de kleur die is toegewezen aan [PortionFormat.fill_format](https://reference.aspose.com/slides/nl/python-net/aspose.slides/portionformat/fill_format/). In de onderstaande voorbeelden is `alpha = 50` een ARGB-alphakanaalwaarde op de schaal 0‑255, geen transparantiepercentage.

Het onderstaande codevoorbeeld toont hoe u transparantie toepast op de **hele alinea**:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

alpha = 50

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Stel de vulkleur van de tekst in op een transparante kleur.
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

Gebruik [BasePortionFormat.spacing](https://reference.aspose.com/slides/nl/python-net/aspose.slides/baseportionformat/spacing/) om de afstand tussen tekens in een tekstvak te vergroten of te verkleinen.

De volgende Python‑code toont hoe u de tekenafstand in de **hele alinea** vergroot:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Opmerking: gebruik negatieve waarden om de tekenafstand te verkleinen.
    paragraph.paragraph_format.default_portion_format.spacing = 3  # Vergroot de tekenafstand.

    presentation.save("character_spacing_in_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Het resultaat:

![De tekenafstand in de alinea](character_spacing_in_paragraph.png)

Het onderstaande codevoorbeeld toont hoe u de tekenafstand vergroot in **tekstgedeelten met een vet lettertype**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Opmerking: gebruik negatieve waarden om de tekenafstand te verkleinen.
            portion.portion_format.spacing = 3  # Vergroot de tekenafstand.

    presentation.save("character_spacing_in_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

Het resultaat:

![De tekenafstand in de tekstgedeelten](character_spacing_in_text_portions.png)

### **Kerning uitschakelen voor specifieke lettertypen**

In sommige gevallen kan de door Aspose.Slides gerenderde tekst iets strakker lijken dan dezelfde tekst in PowerPoint. Dit kan gebeuren omdat PowerPoint kerning‑gegevens voor bepaalde lettertypen kan negeren, zelfs wanneer het lettertype geldige kerning‑informatie bevat en kerning is ingeschakeld in de PowerPoint‑instellingen.

Om de gerenderde uitvoer in dergelijke gevallen dichter bij PowerPoint te laten komen, kunt u kerning uitschakelen voor tekstgedeelten die het betreffende lettertype gebruiken. Stel [PortionFormat.kerning_minimal_size](https://reference.aspose.com/slides/nl/python-net/aspose.slides/baseportionformat/kerning_minimal_size/) in op een waarde die veel groter is dan de werkelijke lettergrootte:

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

Deze instelling voorkomt dat kerning wordt toegepast op overeenkomende tekstgedeelten en kan helpen om de weergave van Aspose.Slides beter af te stemmen op de visuele uitvoer van PowerPoint voor lettertypen die door dit PowerPoint‑specifieke gedrag worden beïnvloed.

## **Lettertype‑eigenschappen van tekst beheren**

Lettertype‑eigenschappen kunnen op alinea‑niveau worden ingesteld via [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/nl/python-net/aspose.slides/paragraphformat/default_portion_format/) of op individuele gedeelten via [PortionFormat](https://reference.aspose.com/slides/nl/python-net/aspose.slides/portionformat/).

De volgende code stelt het lettertype en de tekststijl in voor de hele alinea: het past lettergrootte, vet, cursief, gestippelde onderstreping en het lettertype Times New Roman toe op alle gedeelten in de alinea.

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

![De lettertype‑eigenschappen voor de alinea](font_properties_for_paragraph.png)

Het onderstaande codevoorbeeld past vergelijkbare eigenschappen toe op **tekstgedeelten met een vet lettertype**:

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

![De lettertype‑eigenschappen voor tekstgedeelten](font_properties_for_text_portions.png)

## **Tekstrotatie instellen**

Gebruik [TextFrameFormat.text_vertical_type](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframeformat/text_vertical_type/) om een vooraf gedefinieerde tekstoriëntatie binnen een vorm in te stellen.

Het volgende codevoorbeeld zet de tekstoriëntatie in de vorm op `VERTICAL270`, waardoor de tekst **90 graden tegen de klok in** wordt gedraaid:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    auto_shape.text_frame.text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL270

    presentation.save("text_rotation.pptx", slides.export.SaveFormat.PPTX)
```

Het resultaat:

![De tekstrotatie](text_rotation.png)

## **Aangepaste rotatie voor tekstkaders instellen**

Gebruik [TextFrameFormat.rotation_angle](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframeformat/rotation_angle/) om een aangepaste rotatiehoek in te stellen voor een [TextFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframe/).

Het onderstaande codevoorbeeld draait het tekstkader 3 graden met de klok mee binnen de vorm:

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

Aspose.Slides biedt [ParagraphFormat.space_after](https://reference.aspose.com/slides/nl/python-net/aspose.slides/paragraphformat/space_after/), [ParagraphFormat.space_before](https://reference.aspose.com/slides/nl/python-net/aspose.slides/paragraphformat/space_before/) en [ParagraphFormat.space_within](https://reference.aspose.com/slides/nl/python-net/aspose.slides/paragraphformat/space_within/) om de alinea‑afstand te regelen. Deze eigenschappen worden als volgt gebruikt:

* Gebruik een positieve waarde om de regelafstand als een percentage van de regelhoogte op te geven.
* Gebruik een negatieve waarde om de regelafstand in punten op te geven.

Het volgende codevoorbeeld toont hoe u de regelafstand binnen de alinea opgeeft:

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

## **Autofit‑type voor tekstkaders instellen**

[TextFrameFormat.autofit_type](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframeformat/autofit_type/) bepaalt hoe tekst zich gedraagt wanneer deze de grenzen van de container overschrijdt. Gebruik het om te bepalen of de tekst krimpt, overlapt of de vorm automatisch vergroot.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    auto_shape.text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE

    presentation.save("autofit_type.pptx", slides.export.SaveFormat.PPTX)
```

## **Anker van tekstkaders instellen**

[TextFrameFormat.anchoring_type](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframeformat/anchoring_type/) definieert hoe tekst verticaal binnen een vorm wordt gepositioneerd, bijvoorbeeld bovenaan, in het midden of onderaan.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    auto_shape.text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.BOTTOM

    presentation.save("text_anchor.pptx", slides.export.SaveFormat.PPTX)
```

## **Tekst‑tabulatie instellen**

Gebruik [ParagraphFormat.default_tab_size](https://reference.aspose.com/slides/nl/python-net/aspose.slides/paragraphformat/default_tab_size/) en [ParagraphFormat.tabs](https://reference.aspose.com/slides/nl/python-net/aspose.slides/paragraphformat/tabs/) om tab‑stops in een alinea te configureren.

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

![De alinea‑tabs](paragraph_tabs.png)

## **Controlertaal instellen**

Aspose.Slides biedt [PortionFormat.language_id](https://reference.aspose.com/slides/nl/python-net/aspose.slides/portionformat/language_id/), waarmee u de controlertaal voor een tekstgedeelte kunt instellen. De controlertaal bepaalt de taal die wordt gebruikt voor spelling‑ en grammaticacontrole in PowerPoint.

Het volgende codevoorbeeld toont hoe u de controlertaal voor een tekstgedeelte instelt:

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

    # Stel de Id van een controlertaal in.
    text_portion.portion_format.language_id = "zh-CN"

    text_portion.text = "1."
    paragraph.portions.add(text_portion)

    presentation.save("proofing_language.pptx", slides.export.SaveFormat.PPTX)
```

## **Standaardtaal instellen**

Gebruik [LoadOptions.default_text_language](https://reference.aspose.com/slides/nl/python-net/aspose.slides/loadoptions/default_text_language/) om de standaardtaal te definiëren voor tekst die wordt aangemaakt tijdens het laden of creëren van een presentatie.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.default_text_language = "en-US"

with slides.Presentation(load_options) as presentation:
    slide = presentation.slides[0]

    # Voeg een nieuw rechthoekig vorm toe met tekst.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 50)
    shape.text_frame.text = "Sample text"

    # Controleer de taal van de eerste tekstgedeelte.
    portion = shape.text_frame.paragraphs[0].portions[0]
    print(portion.portion_format.language_id)
```

## **Standaardtekststijl instellen**

Om standaardtekstopmaak op presentatieniveau toe te passen, gebruik [Presentation.default_text_style](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/default_text_style/).

Het volgende codevoorbeeld laat zien hoe u een standaard vet lettertype met een grootte van 14 pt instelt voor alle tekst op alle dia's in een nieuwe presentatie.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    # Haal de alinea‑indeling van het hoogste niveau op.
    paragraph_format = presentation.default_text_style.get_level(0)

    if paragraph_format is not None:
        paragraph_format.default_portion_format.font_height = 14
        paragraph_format.default_portion_format.font_bold = slides.NullableBool.TRUE

    presentation.save("default_text_style.pptx", slides.export.SaveFormat.PPTX)
```

## **Tekst extraheren met het Alles‑Hoofdletters‑effect**

In PowerPoint maakt het toepassen van het **All Caps**‑lettertype‑effect dat tekst op de dia in hoofdletters verschijnt, zelfs wanneer deze oorspronkelijk in kleine letters is getypt. Wanneer u zo'n tekstgedeelte ophaalt met Aspose.Slides, geeft de bibliotheek de tekst exact terug zoals deze is ingevoerd. Om overeen te komen met de weergegeven tekst, controleer [TextCapType](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textcaptype/) en zet de geretourneerde tekenreeks om naar hoofdletters wanneer de waarde `ALL` is.

Stel dat we het volgende tekstvak hebben op de eerste dia van het bestand sample2.pptx.

![Het All Caps‑effect](all_caps_effect.png)

Het onderstaande codevoorbeeld toont hoe u de tekst kunt extraheren met het **All Caps**‑effect toegepast:

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

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **Veelgestelde vragen**

**Hoe wijzig ik tekst in een tabel op een dia?**

Om tekst in een tabel op een dia te wijzigen, gebruikt u [Table](https://reference.aspose.com/slides/nl/python-net/aspose.slides/table/). Loop door de cellen en werk elke cel bij via [Cell.text_frame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/cell/text_frame/) en de alinea‑opmaak via [Paragraph.paragraph_format](https://reference.aspose.com/slides/nl/python-net/aspose.slides/paragraph/paragraph_format/).

**Hoe pas ik een verloopkleur toe op tekst in een PowerPoint‑dia?**

Om een verloopkleur op tekst toe te passen, gebruikt u [PortionFormat.fill_format](https://reference.aspose.com/slides/nl/python-net/aspose.slides/portionformat/fill_format/). Stel [FillFormat.fill_type](https://reference.aspose.com/slides/nl/python-net/aspose.slides/fillformat/fill_type/) in op [FillType.GRADIENT](https://reference.aspose.com/slides/nl/python-net/aspose.slides/filltype/) en configureer de verloopstops, richting en transparantie.