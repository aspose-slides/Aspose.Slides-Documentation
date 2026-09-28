---
title: Tekst van presentaties opmaken in Python
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
- lettertype‑eigenschappen
- lettertype‑familie
- tekstrotatie
- rotatiehoek
- tekstframe
- regelafstand
- autofit‑eigenschap
- tekstframe‑anker
- teksttabulatie
- standaardtaal
- PowerPoint
- OpenDocument
- presentatie
- Python
- Aspose.Slides
description: "Formateer en stijl tekst in PowerPoint- en OpenDocument‑presentaties met Aspose.Slides voor Python via .NET. Pas lettertypen, kleuren, uitlijning en meer aan."
---
## **Overzicht**

Dit artikel laat zien hoe je tekst kunt opmaken in PowerPoint‑ en OpenDocument‑presentaties met Aspose.Slides voor Python via .NET. Het behandelt achtergrondkleuren, transparantie, tekenafstand, lettertype‑eigenschappen, rotatie, alinea‑afstand, autofit‑gedrag, tekst‑verankering, tabs en taalinstellingen.

Tenzij anders vermeld, gebruiken de voorbeelden [sample.pptx](sample.pptx). De eerste vorm op de eerste dia is een tekstvak, en de eerste alinea ervan bevat de hieronder getoonde tekst. Zowel dia‑ als vormindices beginnen bij nul. Voorbeelden die vette delen selecteren, gebruiken effectieve opmaak, inclusief geërfde vette opmaak:

![Voorbeeldtekst](sample_text.png)

Om letterlijke tekst of reguliere‑expressie‑overeenkomsten te vinden en markeren, zie [Zoeken en Vervangen van Tekst](/slides/nl/python-net/search-and-replace-text/).

## **Achtergrondkleur van Tekst Instellen**

Gebruik [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/nl/python-net/aspose.slides/paragraphformat/default_portion_format/) om de standaardmarkeerkleur voor een alinea in te stellen, of gebruik [BasePortionFormat.highlight_color](https://reference.aspose.com/slides/nl/python-net/aspose.slides/baseportionformat/highlight_color/) voor individuele tekstgedeelten.

Het volgende voorbeeld stelt een lichtgrijze markering in als de standaard voor de eerste alinea. Expliciete markeer‑kleuren op individuele gedeelten hebben voorrang boven deze standaard:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Stel de markeerkleur in voor de hele alinea.
    paragraph.paragraph_format.default_portion_format.highlight_color.color = draw.Color.light_gray

    presentation.save("gray_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Het resultaat:

![De grijze alinea](gray_paragraph.png)

De onderstaande code‑voorbeeld toont hoe je de achtergrondkleur instelt voor **tekstgedeelten met een vet lettertype**:

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

## **Tekst‑alinea’s Uitlijnen**

Gebruik [ParagraphFormat.alignment](https://reference.aspose.com/slides/nl/python-net/aspose.slides/paragraphformat/alignment/) om de alinea‑uitlijning binnen een tekstframe in te stellen. De waarde kan gecentreerd, links‑uitgelijnd, rechts‑uitgelijnd, uitgevuld, enzovoort zijn.

Het volgende code‑voorbeeld laat zien hoe je de alinea naar het **midden** uitlijnt:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Stel de uitlijning van de alinea in op gecentreerd.
    paragraph.paragraph_format.alignment = slides.TextAlignment.CENTER

    presentation.save("aligned_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Het resultaat:

![De uitgelijnde alinea](aligned_paragraph.png)

## **Transparantie van Tekst Instellen**

Teksttransparantie wordt geregeld via het alfa‑component van de kleur die is toegewezen aan [BasePortionFormat.fill_format](https://reference.aspose.com/slides/nl/python-net/aspose.slides/baseportionformat/fill_format/). In de onderstaande voorbeelden is `alpha = 50` een ARGB‑alfa‑kanaalwaarde op de schaal 0–255, geen transparantie‑percentage.

Het onderstaande code‑voorbeeld laat zien hoe je transparantie toepast op de **hele alinea**:

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

Het volgende code‑voorbeeld laat zien hoe je transparantie toepast op **tekstgedeelten met een vet lettertype**:

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

## **Tekenafstand voor Tekst Instellen**

Gebruik [BasePortionFormat.spacing](https://reference.aspose.com/slides/nl/python-net/aspose.slides/baseportionformat/spacing/) om de ruimte tussen tekens in een tekstvak te vergroten of te verkleinen. De voorbeelden voegen 3 punten toe; negatieve waarden verkleinen de tekst.

De volgende Python‑code toont hoe je de tekenafstand in de **hele alinea** vergroot:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Opmerking: gebruik negatieve waarden om de tekenafstand te verkleinen.
    paragraph.paragraph_format.default_portion_format.spacing = 3  # Vergroot de tekenafstand.

    presentation.save("character_spacing_in_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Het resultaat:

![De tekenafstand in de alinea](character_spacing_in_paragraph.png)

Het onderstaande code‑voorbeeld toont hoe je de tekenafstand in **tekstgedeelten met een vet lettertype** vergroot:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Opmerking: gebruik negatieve waarden om de tekenafstand te verkleinen.
            portion.portion_format.spacing = 3  # Vergroot de tekenafstand.

    presentation.save("character_spacing_in_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

Het resultaat:

![De tekenafstand in de tekstgedeelten](character_spacing_in_text_portions.png)

### **Kerning Uitschakelen voor Specifieke Lettertypen**

In sommige gevallen kan door Aspose.Slides weergegeven tekst iets strakker lijken dan dezelfde tekst in PowerPoint. Dit kan gebeuren omdat PowerPoint kerning‑gegevens voor bepaalde lettertypen negeert, zelfs wanneer het lettertype geldige kerning‑informatie bevat en kerning is ingeschakeld in de PowerPoint‑instellingen.

Om de gerenderde uitvoer in dergelijke gevallen dichter bij PowerPoint te krijgen, kun je kerning uitschakelen voor tekstgedeelten die het betreffende lettertype gebruiken. Stel [BasePortionFormat.kerning_minimal_size](https://reference.aspose.com/slides/nl/python-net/aspose.slides/baseportionformat/kerning_minimal_size/) in op een waarde die groter is dan de werkelijke fontgrootte. Dit voorbeeld vereist "presentation.pptx" met een tekstvak als eerste vorm op de eerste dia. Het controleert effectieve lettertype‑namen, inclusief geërfde lettertypen, en stelt een drempel van 100 punten in voor gedeelten die Roboto gebruiken. Dit schakelt kerning uit voor overeenkomende gedeelten met een lettergrootte onder de 100 punten:

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

Voor overeenkomende tekst onder de drempel voorkomt deze instelling kerning en kan het helpen om de weergave van Aspose.Slides af te stemmen op de visuele uitvoer van PowerPoint voor lettertypen die door dit PowerPoint‑specifieke gedrag zijn getroffen.

## **Tekst‑lettertype‑eigenschappen Beheren**

Lettertype‑eigenschappen kunnen op alinea‑niveau worden ingesteld via [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/nl/python-net/aspose.slides/paragraphformat/default_portion_format/), of op individuele gedeelten via [PortionFormat](https://reference.aspose.com/slides/nl/python-net/aspose.slides/portionformat/).

Het volgende voorbeeld stelt het standaardlettertype van de eerste alinea in op 12‑punt Times New Roman met vet, cursief en gestippelde onderstreping. Expliciete opmaak op individuele gedeelten heeft voorrang op deze standaardinstellingen:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Stel de lettertype-eigenschappen in voor de alinea.
    portion_format = paragraph.paragraph_format.default_portion_format
    portion_format.font_height = 12
    portion_format.font_bold = slides.NullableBool.TRUE
    portion_format.font_italic = slides.NullableBool.TRUE
    portion_format.font_underline = slides.TextUnderlineType.DOTTED
    portion_format.latin_font = slides.FontData("Times New Roman")

    presentation.save("font_properties_for_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Het resultaat:

![De lettertype‑eigenschappen voor de alinea](font_properties_for_paragraph.png)

Het volgende voorbeeld past 13‑punt Times New Roman, cursieve opmaak en een gestippelde onderstreping toe op gedeelten waarvan de effectieve opmaak vet is:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
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

![De lettertype‑eigenschappen voor de tekstgedeelten](font_properties_for_text_portions.png)

## **Tekstrotatie Instellen**

Gebruik [TextFrameFormat.text_vertical_type](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframeformat/text_vertical_type/) om een vooraf gedefinieerde tekstoriëntatie binnen een vorm in te stellen.

Het volgende code‑voorbeeld stelt de tekstoriëntatie in de vorm in op [TextVerticalType.VERTICAL270](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textverticaltype/), waardoor de tekst **90 graden tegen de klok in** wordt gedraaid:

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

## **Aangepaste Rotatie voor Tekstframes Instellen**

Gebruik [TextFrameFormat.rotation_angle](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframeformat/rotation_angle/) om een aangepaste rotatiehoek in te stellen voor een [TextFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframe/).

Het onderstaande code‑voorbeeld roteert het tekstframe met 3 graad met de klok mee binnen de vorm:

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

## **Regelafstand van Alinea’s Instellen**

Aspose.Slides biedt [ParagraphFormat.space_after](https://reference.aspose.com/slides/nl/python-net/aspose.slides/paragraphformat space_after/), [ParagraphFormat.space_before](https://reference.aspose.com/slides/nl/python-net/aspose.slides/paragraphformat/space_before/), en [ParagraphFormat.space_within](https://reference.aspose.com/slides/nl/python-net/aspose.slides/paragraphformat/space_within/) om de alinea‑afstand te regelen. Deze eigenschappen worden als volgt gebruikt:

* Gebruik een positieve waarde om de regelafstand op te geven als een percentage van de regelhoogte.
* Gebruik een negatieve waarde om de regelafstand in punten op te geven.

Het volgende voorbeeld stelt de afstand binnen de eerste alinea in op 200 % van de regelhoogte (dubbele regelafstand):

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

## **Regelafbreking Beheersen**

Regel‑afbreekregels voor alinea’s zijn nuttig in smalle tekstblokken en presentaties die Latijnse en Oost‑Aziatische tekst combineren. De volgende eigenschappen behoren tot [ParagraphFormat](https://reference.aspose.com/slides/nl/python-net/aspose.slides/paragraphformat/), dus ze gelden voor een hele alinea:

- [latin_line_break](https://reference.aspose.com/slides/nl/python-net/aspose.slides/paragraphformat/latin_line_break/) regelt de regel‑afbreekregels voor Latijnse tekst. In gemengde tekst kan een wijziging ook bepalen waar aangrenzende Oost‑Aziatische tekst en interpunctie worden afgebroken.
- [east_asian_line_break](https://reference.aspose.com/slides/nl/python-net/aspose.slides/paragraphformat/east_asian_line_break/) regelt de regel‑afbreekregels voor Oost‑Aziatische tekst, inclusief beperkingen voor tekens aan het begin en einde van een regel.

Deze regels vervangen niet [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframeformat/wrap_text/), die automatisch omloop binnen een tekstframe inschakelt. Ze beïnvloeden de lay‑out wanneer omloop optreedt; ze voegen geen regeleinde‑tekens toe. Een expliciete regelafbreking dwingt een nieuwe regel binnen de alinea af, onafhankelijk van de beschikbare breedte.

Het volgende zelfstandige voorbeeld maakt een smal tekstblok met Chinese en Latijnse tekst. Het stelt beide regel‑afbreek‑eigenschappen expliciet in en slaat "line_breaking.pptx" op. Om met een van de regels te experimenteren, wijzig je de waarde van die eigenschap terwijl je de andere instellingen onveranderd laat. Het voorbeeld gebruikt 24‑punt Arial en SimSun met een frame‑breedte van 160 punten en nul horizontale tekstframe‑marges. [TextFrameFormat.autofit_type](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframeformat/autofit_type/) is ingesteld op [TextAutofitType.NONE](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textautofittype/) zodat tekstgrootte en frame‑afmetingen vast blijven.

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

## **Hangende Interpunctie Beheersen**

[ParagraphFormat.hanging_punctuation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/paragraphformat/hanging_punctuation/) staat toe dat in aanmerking komende interpunctie zich uitstrekt voorbij de rechterrand van de tekstregel in plaats van de volgende regel in te nemen. Het geldt voor de hele alinea en verschilt van een hangende inspringing.

Het volgende zelfstandige voorbeeld schakelt hangende interpunctie in een tekstframe van 100 punten breed in en slaat "hanging_punctuation.pptx" op. Met 24‑punt Arial en nul horizontale tekstframe‑marges blijft de laatste punt achter "sentence" staan en strekt zich uit voorbij de rechtertekstkant. Stel de eigenschap in op [NullableBool.FALSE](https://reference.aspose.com/slides/nl/python-net/aspose.slides/nullablebool/) om te vergelijken: met deze instellingen neemt de punt een aparte regel in. Omloop is ingeschakeld en autofit is uitgeschakeld om de beschikbare breedte vast te houden.

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

Niet elk leesteken kan hangen. Het zichtbare resultaat hangt af van het lettertype en de lay‑out‑omstandigheden: het wijzigen van het lettertype, de beschikbare breedte, marges of autofit‑instellingen kan het zichtbare verschil wegnemen.

## **Autofit‑type voor Tekstframes Instellen**

[TextFrameFormat.autofit_type](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframeformat/autofit_type/) bepaalt hoe tekst zich gedraagt wanneer deze de grenzen van de container overschrijdt. Gebruik het om te controleren of de tekst krimpt, overstroomt of de vorm automatisch vergroot. Het volgende voorbeeld configureert de vorm om van grootte te veranderen zodat de tekst past en slaat het resultaat op als "autofit_type.pptx".

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE

    presentation.save("autofit_type.pptx", slides.export.SaveFormat.PPTX)
```

Om het aantal regels te tellen na automatisch omlopen en te zien hoe tekst‑ of vorm‑breedte het resultaat wijzigt, zie [Aantal Gerenderde Regels](/slides/nl/python-net/manage-paragraph/). Het aantal regels alleen geeft niet aan of de tekst de container overstroomt.

## **Anker van Tekstframes Instellen**

[TextFrameFormat.anchoring_type](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframeformat/anchoring_type/) definieert hoe tekst verticaal binnen een vorm wordt gepositioneerd, bijvoorbeeld bovenaan, in het midden of onderaan. Het volgende voorbeeld verankert de tekst aan de onderkant van de eerste vorm en slaat het resultaat op als "text_anchor.pptx".

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.BOTTOM

    presentation.save("text_anchor.pptx", slides.export.SaveFormat.PPTX)
```

## **Tekst‑tabulatie Instellen**

Gebruik [ParagraphFormat.default_tab_size](https://reference.aspose.com/slides/nl/python-net/aspose.slides/paragraphformat/default_tab_size/) en [ParagraphFormat.tabs](https://reference.aspose.com/slides/nl/python-net/aspose.slides/paragraphformat/tabs/) om tab‑stops in een alinea te configureren. Het volgende voorbeeld stelt de standaard tab‑interval in op 100 punten en voegt een links‑uitgelijnde tab‑stop toe op 30 punten. Deze instellingen beïnvloeden tekst die tab‑tekens bevat.

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

## **Spelling‑ en grammaticacontrole‑taal Instellen**

Aspose.Slides biedt [BasePortionFormat.language_id](https://reference.aspose.com/slides/nl/python-net/aspose.slides/baseportionformat/language_id/), waarmee je de controletaal voor een tekstgedeelte kunt instellen. De controletaal bepaalt welke taal wordt gebruikt voor spelling‑ en grammaticacontrole in PowerPoint.

Het volgende voorbeeld vereist "presentation.pptx" met een tekstvak als eerste vorm op de eerste dia en minstens één alinea. Het vervangt de inhoud van de eerste alinea door "1。", stelt SimSun in als lettertype en wijst de vereenvoudigde Chinese controletaal (`zh-CN`) toe. Het slaat het resultaat op als "proofing_language.pptx":

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

    # Stel de controletaal in op Vereenvoudigd Chinees.
    text_portion.portion_format.language_id = "zh-CN"

    text_portion.text = "1。"
    paragraph.portions.add(text_portion)

    presentation.save("proofing_language.pptx", slides.export.SaveFormat.PPTX)
```

## **Standaardtaal Instellen**

Gebruik [LoadOptions.default_text_language](https://reference.aspose.com/slides/nl/python-net/aspose.slides/loadoptions/default_text_language/) om de standaardtaal voor tekst te definiëren die wordt aangemaakt tijdens het laden of creëren van een presentatie. Het volgende voorbeeld maakt een presentatie met US English als standaardteksttaal, voegt een tekstvak toe en print `en-US` voor het eerste tekstgedeelte.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.default_text_language = "en-US"

with slides.Presentation(load_options) as presentation:
    slide = presentation.slides[0]

    # Voeg een nieuw rechthoekvorm toe met tekst.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 50)
    shape.text_frame.text = "Sample text"

    # Controleer de taal van het eerste gedeelte.
    portion = shape.text_frame.paragraphs[0].portions[0]
    print(portion.portion_format.language_id)
```

## **Standaard Tekststijl Instellen**

Om standaardtekstopmaak op presentatieniveau toe te passen, gebruik je [Presentation.default_text_style](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/default_text_style/).

Het volgende voorbeeld stelt een 14‑punt vet lettertype in als standaard voor alinea’s op top‑niveau in een nieuwe presentatie en slaat deze op als "default_text_style.pptx". Tekst kan deze standaardwaarden erven, tenzij specifiekere opmaak ze overschrijft.

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

## **Tekst Extracten met het All‑Caps‑Effect**

In PowerPoint zorgt het toepassen van het **All Caps**‑lettertype‑effect ervoor dat tekst in hoofdletters wordt weergegeven op de dia, zelfs wanneer deze oorspronkelijk in kleine letters is getypt. Wanneer je zo'n tekstgedeelte ophaalt met Aspose.Slides, geeft de bibliotheek de tekst precies zoals ingevoerd terug. Om overeen te komen met de weergegeven tekst, controleer je [TextCapType](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textcaptype/) en converteer je de geretourneerde tekenreeks naar hoofdletters wanneer de waarde `ALL` is.

Dit voorbeeld vereist "sample2.pptx" met een tekstvak als eerste vorm op de eerste dia. Het eerste gedeelte van de eerste alinea bevat "Hello, Aspose!" met het All Caps‑effect toegepast, zoals hieronder weergegeven.

![Het All Caps‑effect](all_caps_effect.png)

Het onderstaande code‑voorbeeld laat zien hoe je de tekst kunt extraheren met het **All Caps**‑effect toegepast:

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

Om tekst in een tabel op een dia te wijzigen, gebruik je [Table](https://reference.aspose.com/slides/nl/python-net/aspose.slides/table/). Loop door de cellen en werk elke cel bij via [Cell.text_frame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/cell/text_frame/) en alinea‑opmaak via [Paragraph.paragraph_format](https://reference.aspose.com/slides/nl/python-net/aspose.slides/paragraph/paragraph_format/).

**Hoe pas ik een verloopkleur toe op tekst op een PowerPoint‑dia?**

Om een verloopkleur op tekst toe te passen, gebruik je [BasePortionFormat.fill_format](https://reference.aspose.com/slides/nl/python-net/aspose.slides/baseportionformat/fill_format/). Stel [FillFormat.fill_type](https://reference.aspose.com/slides/nl/python-net/aspose.slides/fillformat/fill_type/) in op [FillType.GRADIENT](https://reference.aspose.com/slides/nl/python-net/aspose.slides/filltype/) en configureer de verloopstops, richting en transparantie.