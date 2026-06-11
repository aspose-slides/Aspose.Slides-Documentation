---
title: Formatera presentationstext i Python
linktitle: Textformatering
type: docs
weight: 50
url: /sv/python-net/text-formatting/
keywords:
- markera text
- reguljärt uttryck
- justera stycke
- textstil
- textbakgrund
- texttransparens
- teckenavstånd
- teckensnittsegenskaper
- teckensnittsfamilj
- textrotation
- rotationsvinkel
- textram
- radavstånd
- autofit egenskap
- ankare för textram
- texttabulering
- standardspråk
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Formatera och stilisera text i PowerPoint- och OpenDocument-presentationer med Aspose.Slides för Python via .NET. Anpassa teckensnitt, färger, justering och mer."
---
## **Översikt**

Denna artikel visar hur man formaterar text i PowerPoint- och OpenDocument-presentationer med Aspose.Slides för Python via .NET. Den täcker markering, bakgrundsfärger, transparens, teckenavstånd, teckensnittsegenskaper, rotation, styckeavstånd, autofit‑beteende, textankring, tabbstopp och språk­inställningar.

I exemplen nedan använder vi en fil med namnet "sample.pptx", som innehåller en enda textruta på den första bilden med följande text:

![Exempeltext](sample_text.png)

## **Markera text**

Använd metoden [TextFrame.highlight_text](https://reference.aspose.com/slides/sv/python-net/aspose.slides/textframe/highlight_text/) när du behöver markera text som matchar ett specifikt exempel inom en textram. Metoden tillämpar en markeringsfärg på matchande textfragment och kan användas med [TextSearchOptions](https://reference.aspose.com/slides/sv/python-net/aspose.slides/textsearchoptions/) för att styra hur sökningen utförs, till exempel för att bara matcha hela ord.

Kodexemplet nedan markerar alla förekomster av tecknen **"try"** och markerar sedan endast hela ordet **"to"**.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    # Hämta den första formen från den första bilden.
    shape = presentation.slides[0].shapes[0]

    # Markera ordet "try" i formen.
    shape.text_frame.highlight_text("try", draw.Color.light_blue)

    search_options = slides.TextSearchOptions()
    search_options.whole_words_only = True

    # Markera ordet "to" i formen.
    shape.text_frame.highlight_text("to", draw.Color.violet, search_options, None)

    presentation.save("highlighted_text.pptx", slides.export.SaveFormat.PPTX)
```

Resultatet:

![Den markerade texten](highlighted_text.png)

## **Markera text med reguljära uttryck**

Metoden [TextFrame.highlight_regex](https://reference.aspose.com/slides/sv/python-net/aspose.slides/textframe/highlight_regex/) markerar textmatchningar som hittas med ett reguljärt uttryck. I Python exponeras detta API på [TextFrame](https://reference.aspose.com/slides/sv/python-net/aspose.slides/textframe/).

Kodexemplet nedan markerar alla ord som innehåller **sju eller fler tecken**:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    regex = r"\b[^\s]{7,}\b"

    # Markera alla ord med sju eller fler tecken.
    shape.text_frame.highlight_regex(regex, draw.Color.yellow, None)

    presentation.save("highlighted_text_using_regex.pptx", slides.export.SaveFormat.PPTX)
```

Resultatet:

![Den markerade texten med reguljärt uttryck](highlighted_text_using_regex.png)

## **Ange bakgrundsfärg för text**

Använd [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/sv/python-net/aspose.slides/paragraphformat/default_portion_format/) för att ange standardmarkeringsfärg för ett stycke, eller använd [PortionFormat.highlight_color](https://reference.aspose.com/slides/sv/python-net/aspose.slides/portionformat/highlight_color/) för enskilda textdelar.

Följande kodexempel visar hur man anger bakgrundsfärg för **hela stycket**:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Ange markeringsfärgen för hela stycket.
    paragraph.paragraph_format.default_portion_format.highlight_color.color = draw.Color.light_gray

    presentation.save("gray_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Resultatet:

![Det gråa stycket](gray_paragraph.png)

Kodexemplet nedan demonstrerar hur man anger bakgrundsfärg för **textdelar med fet stil**:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Ange markeringsfärgen för textdelen.
            portion.portion_format.highlight_color.color = draw.Color.light_gray

    presentation.save("gray_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

Resultatet:

![De gråa textdelarna](gray_text_portions.png)

## **Justera textstycken**

Använd [ParagraphFormat.alignment](https://reference.aspose.com/slides/sv/python-net/aspose.slides/paragraphformat/alignment/) för att ange styckejustering inom en textram. Värdet kan vara centrerat, vänsterjusterat, högerjusterat, justerat osv.

Följande kodexempel visar hur man justerar stycket till **centrum**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Ställ in styckejusteringen till centrum.
    paragraph.paragraph_format.alignment = slides.TextAlignment.CENTER

    presentation.save("aligned_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Resultatet:

![Det justerade stycket](aligned_paragraph.png)

## **Ange transparens för text**

Textransparens styrs via alfakomponenten i färgen som tilldelas [PortionFormat.fill_format](https://reference.aspose.com/slides/sv/python-net/aspose.slides/portionformat/fill_format/). I exemplen nedan är `alpha = 50` ett ARGB-alfakanalvärde på skalan 0‑255, inte en transparensprocent.

Kodexemplet nedan visar hur man tillämpar transparens på **hela stycket**:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

alpha = 50

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Ange fyllningsfärgen för texten till transparent färg.
    paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.from_argb(alpha, draw.Color.black)

    presentation.save("transparent_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Resultatet:

![Det transparenta stycket](transparent_paragraph.png)

Följande kodexempel visar hur man tillämpar transparens på **textdelar med fet stil**:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

alpha = 50

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Ange transparensen för textdelen.
            portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
            portion.portion_format.fill_format.solid_fill_color.color = draw.Color.from_argb(alpha, draw.Color.black)

    presentation.save("transparent_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

Resultatet:

![De transparenta textdelarna](transparent_text_portions.png)

## **Ange teckenavstånd för text**

Använd [BasePortionFormat.spacing](https://reference.aspose.com/slides/sv/python-net/aspose.slides/baseportionformat/spacing/) för att öka eller minska avståndet mellan tecken i en textruta.

Följande Python‑kod visar hur man ökar teckenavståndet i **hela stycket**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Obs: Använd negativa värden för att komprimera teckenavståndet.
    paragraph.paragraph_format.default_portion_format.spacing = 3  # Utöka teckenavståndet.

    presentation.save("character_spacing_in_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Resultatet:

![Teckenavståndet i stycket](character_spacing_in_paragraph.png)

Kodexemplet nedan visar hur man ökar teckenavståndet i **textdelar med fet stil**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Obs: Använd negativa värden för att komprimera teckenavståndet.
            portion.portion_format.spacing = 3  # Utöka teckenavståndet.

    presentation.save("character_spacing_in_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

Resultatet:

![Teckenavståndet i textdelarna](character_spacing_in_text_portions.png)

### **Inaktivera kerning för specifika typsnitt**

I vissa fall kan text som renderas av Aspose.Slides se något tajtare ut än samma text som visas i PowerPoint. Detta kan ske eftersom PowerPoint kan ignorera kerningdata för vissa typsnitt, även när typsnittet innehåller giltig kerninginformation och kerning är aktiverat i PowerPoint‑inställningarna.

För att få den renderade utdata närmare PowerPoint i sådana fall kan du inaktivera kerning för textdelar som använder det påverkade typsnittet. Ange [PortionFormat.kerning_minimal_size](https://reference.aspose.com/slides/sv/python-net/aspose.slides/baseportionformat/kerning_minimal_size/) till ett värde som är avsevärt större än den faktiska typsnittsstorleken:

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

Denna inställning förhindrar att kerning tillämpas på matchande textdelar och kan hjälpa till att anpassa Aspose.Slides‑renderingen till PowerPoints visuella utdata för typsnitt som påverkas av detta PowerPoint‑specifika beteende.

## **Hantera textens teckensnittsegenskaper**

Teckensnittsegenskaper kan sättas på styckennivå via [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/sv/python-net/aspose.slides/paragraphformat/default_portion_format/) eller på enskilda delar via [PortionFormat](https://reference.aspose.com/slides/sv/python-net/aspose.slides/portionformat/).

Följande kod sätter teckensnitt och textstil för hela stycket: den tillämpar teckenstorlek, fet, kursiv, prickad understrykning och teckensnittet Times New Roman på alla delar i stycket.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Ange teckensnittsegenskaperna för stycket.
    paragraph.paragraph_format.default_portion_format.font_height = 12
    paragraph.paragraph_format.default_portion_format.font_bold = slides.NullableBool.TRUE
    paragraph.paragraph_format.default_portion_format.font_italic = slides.NullableBool.TRUE
    paragraph.paragraph_format.default_portion_format.font_underline = slides.TextUnderlineType.DOTTED
    paragraph.paragraph_format.default_portion_format.latin_font = slides.FontData("Times New Roman")

    presentation.save("font_properties_for_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Resultatet:

![Teckensnittsegenskaperna för stycket](font_properties_for_paragraph.png)

Kodexemplet nedan tillämpar liknande egenskaper på **textdelar med fet stil**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Ange teckensnittsegenskaperna för textdelen.
            portion.portion_format.font_height = 13
            portion.portion_format.font_italic = slides.NullableBool.TRUE
            portion.portion_format.font_underline = slides.TextUnderlineType.DOTTED
            portion.portion_format.latin_font = slides.FontData("Times New Roman")

    presentation.save("font_properties_for_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

Resultatet:

![Teckensnittsegenskaperna för textdelarna](font_properties_for_text_portions.png)

## **Ange textrotation**

Använd [TextFrameFormat.text_vertical_type](https://reference.aspose.com/slides/sv/python-net/aspose.slides/textframeformat/text_vertical_type/) för att ange en fördefinierad textriktning inom en form.

Följande kodexempel sätter textriktningen i formen till `VERTICAL270`, vilket roterar texten **90 grader moturs**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    auto_shape.text_frame.text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL270

    presentation.save("text_rotation.pptx", slides.export.SaveFormat.PPTX)
```

Resultatet:

![Textrotationen](text_rotation.png)

## **Ange anpassad rotation för textramar**

Använd [TextFrameFormat.rotation_angle](https://reference.aspose.com/slides/sv/python-net/aspose.slides/textframeformat/rotation_angle/) för att ange en anpassad rotationsvinkel för en [TextFrame](https://reference.aspose.com/slides/sv/python-net/aspose.slides/textframe/).

Kodexemplet nedan roterar textramen med 3 grader medurs inom formen:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    auto_shape.text_frame.text_frame_format.rotation_angle = 3

    presentation.save("custom_text_rotation.pptx", slides.export.SaveFormat.PPTX)
```

Resultatet:

![Den anpassade textrotationen](custom_text_rotation.png)

## **Ange radavstånd för stycken**

Aspose.Slides tillhandahåller [ParagraphFormat.space_after](https://reference.aspose.com/slides/sv/python-net/aspose.slides/paragraphformat/space_after/), [ParagraphFormat.space_before](https://reference.aspose.com/slides/sv/python-net/aspose.slides/paragraphformat/space_before/), och [ParagraphFormat.space_within](https://reference.aspose.com/slides/sv/python-net/aspose.slides/paragraphformat/space_within/) för att kontrollera styckeavstånd. Dessa egenskaper används på följande sätt:

* Använd ett positivt värde för att ange radavstånd som en procentandel av radens höjd.
* Använd ett negativt värde för att ange radavstånd i punkter.

Följande kodexempel visar hur man specificerar radavståndet inom stycket:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    paragraph.paragraph_format.space_within = 200

    presentation.save("line_spacing.pptx", slides.export.SaveFormat.PPTX)
```

Resultatet:

![Radavståndet inom stycket](line_spacing.png)

## **Ange autofit‑typ för textramar**

[TextFrameFormat.autofit_type](https://reference.aspose.com/slides/sv/python-net/aspose.slides/textframeformat/autofit_type/) bestämmer hur text beter sig när den överskrider behållarens gränser. Använd den för att styra om texten krymper, överflödar eller automatiskt ändrar formens storlek.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    auto_shape.text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE

    presentation.save("autofit_type.pptx", slides.export.SaveFormat.PPTX)
```

## **Ange ankare för textramar**

[TextFrameFormat.anchoring_type](https://reference.aspose.com/slides/sv/python-net/aspose.slides/textframeformat/anchoring_type/) definierar hur text placeras vertikalt inne i en form, till exempel överst, i mitten eller nederst.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    auto_shape.text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.BOTTOM

    presentation.save("text_anchor.pptx", slides.export.SaveFormat.PPTX)
```

## **Ange texttabulering**

Använd [ParagraphFormat.default_tab_size](https://reference.aspose.com/slides/sv/python-net/aspose.slides/paragraphformat/default_tab_size/) och [ParagraphFormat.tabs](https://reference.aspose.com/slides/sv/python-net/aspose.slides/paragraphformat/tabs/) för att konfigurera tabbpositioner i ett stycke.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    paragraph.paragraph_format.default_tab_size = 100
    paragraph.paragraph_format.tabs.add(30, slides.TabAlignment.LEFT)

    presentation.save("paragraph_tabs.pptx", slides.export.SaveFormat.PPTX)
```

Resultatet:

![Styckets tabbar](paragraph_tabs.png)

## **Ange korrekturspråk**

Aspose.Slides tillhandahåller [PortionFormat.language_id](https://reference.aspose.com/slides/sv/python-net/aspose.slides/portionformat/language_id/), som låter dig ange korrekturspråket för en textdel. Korrekturspråket bestämmer vilket språk som används för stavnings- och grammatikkontroller i PowerPoint.

Följande kodexempel visar hur man anger korrekturspråket för en textdel:

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

    # Ange Id för ett korrekturläsningsspråk.
    text_portion.portion_format.language_id = "zh-CN"

    text_portion.text = "1."
    paragraph.portions.add(text_portion)

    presentation.save("proofing_language.pptx", slides.export.SaveFormat.PPTX)
```

## **Ange standardspråk**

Använd [LoadOptions.default_text_language](https://reference.aspose.com/slides/sv/python-net/aspose.slides/loadoptions/default_text_language/) för att definiera standardspråket för text som skapas vid inläsning eller skapande av en presentation.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.default_text_language = "en-US"

with slides.Presentation(load_options) as presentation:
    slide = presentation.slides[0]

    # Lägg till en ny rektangelform med text.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 50)
    shape.text_frame.text = "Sample text"

    # Kontrollera språk för den första textdelen.
    portion = shape.text_frame.paragraphs[0].portions[0]
    print(portion.portion_format.language_id)
```

## **Ange standardtextstil**

För att tillämpa standardtextformatering på presentationsnivå, använd [Presentation.default_text_style](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/default_text_style/).

Följande kodexempel visar hur man anger ett standardfett teckensnitt med storlek 14 pt för all text på alla bilder i en ny presentation.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    # Hämta formatet för stycket på toppnivå.
    paragraph_format = presentation.default_text_style.get_level(0)

    if paragraph_format is not None:
        paragraph_format.default_portion_format.font_height = 14
        paragraph_format.default_portion_format.font_bold = slides.NullableBool.TRUE

    presentation.save("default_text_style.pptx", slides.export.SaveFormat.PPTX)
```

## **Extrahera text med versaler‑effekt**

I PowerPoint gör appliceringen av **All Caps**‑teffekten att text visas i versaler på bilden även om den ursprungligen skrevs med gemener. När du hämtar en sådan textdel med Aspose.Slides returnerar biblioteket texten exakt som den angavs. För att matcha den visade texten, kontrollera [TextCapType](https://reference.aspose.com/slides/sv/python-net/aspose.slides/textcaptype/) och konvertera den returnerade strängen till versaler när värdet är `ALL`.

Låt oss säga att vi har följande textruta på den första bilden i filen sample2.pptx.

![All Caps‑effekten](all_caps_effect.png)

Kodexemplet nedan visar hur man extraherar texten med **All Caps**‑effekten tillämpad:

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

Utdata:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **FAQ**

**Hur ändrar man text i en tabell på en bild?**

För att ändra text i en tabell på en bild, använd [Table](https://reference.aspose.com/slides/sv/python-net/aspose.slides/table/). Iterera genom cellerna och uppdatera varje cell via [Cell.text_frame](https://reference.aspose.com/slides/sv/python-net/aspose.slides/cell/text_frame/) och styckeformatering via [Paragraph.paragraph_format](https://reference.aspose.com/slides/sv/python-net/aspose.slides/paragraph/paragraph_format/).

**Hur applicerar man färggradient på text i en PowerPoint‑bild?**

För att applicera en färggradient på text, använd [PortionFormat.fill_format](https://reference.aspose.com/slides/sv/python-net/aspose.slides/portionformat/fill_format/). Ange [FillFormat.fill_type](https://reference.aspose.com/slides/sv/python-net/aspose.slides/fillformat/fill_type/) till [FillType.GRADIENT](https://reference.aspose.com/slides/sv/python-net/aspose.slides/filltype/) och konfigurera gradientstopp, riktning och transparens.