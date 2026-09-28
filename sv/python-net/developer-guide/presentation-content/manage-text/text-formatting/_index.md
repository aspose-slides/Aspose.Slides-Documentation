---
title: "Formatera presentationstext i Python"
linktitle: "Textformatering"
type: docs
weight: 50
url: /sv/python-net/text-formatting/
keywords:
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
- autofit-egenskap
- ankning för textram
- texttabulering
- standardspråk
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Formatera och stilistiskt anpassa text i PowerPoint- och OpenDocument-presentationer med Aspose.Slides för Python via .NET. Anpassa teckensnitt, färger, justering och mer."
---
## **Översikt**

Denna artikel visar hur man formaterar text i PowerPoint- och OpenDocument-presentationer med Aspose.Slides för Python via .NET. Den täcker bakgrundsfärger, transparens, teckenavstånd, teckensnittsegenskaper, rotation, styckeavstånd, autofit-beteende, textankring, tabbstopp och språkinställningar.

Om inget annat anges använder exemplen [sample.pptx](sample.pptx). Den första formen på den första bilden är en textruta, och dess första stycke innehåller texten som visas nedan. Både bild- och formindex är nollbaserade. Exempel som markerar fetstilda delar använder effektiv formatering, inklusive ärvd fetstil.

![Exempeltext](sample_text.png)

För att hitta och markera exakt text eller matchningar med reguljära uttryck, se [Sök och ersätt text](/slides/sv/python-net/search-and-replace-text/).

## **Ange bakgrundsfärg för text**

Använd [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/sv/python-net/aspose.slides/paragraphformat/default_portion_format/) för att ange standardmarkeringsfärgen för ett stycke, eller använd [BasePortionFormat.highlight_color](https://reference.aspose.com/slides/sv/python-net/aspose.slides/baseportionformat/highlight_color/) för enskilda textdelar.

Följande exempel anger en ljusgrå markering som standard för det första stycket. Explícita markeringsfärger på enskilda delar har företräde framför detta standardvärde:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Ange markeringsfärgen för hela stycket.
    paragraph.paragraph_format.default_portion_format.highlight_color.color = draw.Color.light_gray

    presentation.save("gray_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

![Det gråa stycket](gray_paragraph.png)

Kodexemplet nedan visar hur man anger bakgrundsfärg för **textdelar med fet stil**:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Ange markeringsfärgen för textdelen.
            portion.portion_format.highlight_color.color = draw.Color.light_gray

    presentation.save("gray_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

![De gråa textdelarna](gray_text_portions.png)

## **Justera textstycken**

Använd [ParagraphFormat.alignment](https://reference.aspose.com/slides/sv/python-net/aspose.slides/paragraphformat/alignment/) för att ange styckejustering inom en textruta. Värdet kan vara centrerat, vänsterjusterat, högerjusterat, justerat osv.

Följande kodexempel visar hur man justerar stycket till **centrum**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Ställ in justeringen av stycket till centrerad.
    paragraph.paragraph_format.alignment = slides.TextAlignment.CENTER

    presentation.save("aligned_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

![Det justerade stycket](aligned_paragraph.png)

## **Ange transparens för text**

Texttransparens styrs via alfakomponenten i färgen som tilldelas [BasePortionFormat.fill_format](https://reference.aspose.com/slides/sv/python-net/aspose.slides/baseportionformat/fill_format/). I exemplen nedan är `alpha = 50` ett ARGB-alphakanalvärde på skalan 0–255, inte en transparensprocent.

Kodexemplet nedan visar hur man applicerar transparens på **hela stycket**:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

alpha = 50

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Ställ in en semitransparent svart fyllning för texten.
    paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.from_argb(alpha, draw.Color.black)

    presentation.save("transparent_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

![Det transparenta stycket](transparent_paragraph.png)

Följande kodexempel visar hur man applicerar transparens på **textdelar med fet stil**:

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
            # Ställ in transparensen för textdelen.
            portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
            portion.portion_format.fill_format.solid_fill_color.color = draw.Color.from_argb(alpha, draw.Color.black)

    presentation.save("transparent_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

![De transparenta textdelarna](transparent_text_portions.png)

## **Ange teckenavstånd för text**

Använd [BasePortionFormat.spacing](https://reference.aspose.com/slides/sv/python-net/aspose.slides/baseportionformat/spacing/) för att öka eller minska avståndet mellan tecken i en textruta. Exemplen lägger till 3 punkt avstånd; negativa värden komprimerar texten.

Följande Python-kod visar hur man ökar teckenavståndet i **hela stycket**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Obs: Använd negativa värden för att komprimera teckenavståndet.
    paragraph.paragraph_format.default_portion_format.spacing = 3  # Utöka teckenavståndet.

    presentation.save("character_spacing_in_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

![Teckenavståndet i stycket](character_spacing_in_paragraph.png)

Kodexemplet nedan visar hur man ökar teckenavståndet i **textdelar med fet stil**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Obs: Använd negativa värden för att komprimera teckenavståndet.
            portion.portion_format.spacing = 3  # Utöka teckenavståndet.

    presentation.save("character_spacing_in_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

![Teckenavståndet i textdelarna](character_spacing_in_text_portions.png)

### **Inaktivera kerning för specifika teckensnitt**

I vissa fall kan text som renderas av Aspose.Slides se något tätare ut än samma text i PowerPoint. Detta kan hända eftersom PowerPoint kan ignorera kerningdata för vissa teckensnitt, även om teckensnittet innehåller giltig kerninginformation och kerning är aktiverat i PowerPoint-inställningarna.

För att göra den renderade utskriften närmare PowerPoint i sådana fall kan du inaktivera kerning för textdelar som använder det drabbade teckensnittet. Ställ in [BasePortionFormat.kerning_minimal_size](https://reference.aspose.com/slides/sv/python-net/aspose.slides/baseportionformat/kerning_minimal_size/) på ett värde som är större än den faktiska teckenstorleken. Detta exempel kräver "presentation.pptx" med en textruta som den första formen på den första bilden. Det kontrollerar effektiva teckensnittsnamn, inklusive ärvda teckensnitt, och sätter ett tröskelvärde på 100 punkter för delar som använder Roboto. Detta inaktiverar kerning för matchande delar med en teckenstorlek under 100 punkter:

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

För matchande text under tröskelvärdet förhindrar denna inställning kerning och kan hjälpa till att få Aspose.Slides-renderingen att matcha PowerPoints visuella utslag för teckensnitt som påverkas av detta PowerPoint-specifika beteende.

## **Hantera textteckensnittsegenskaper**

Teckensnittsegenskaper kan anges på styckennivå via [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/sv/python-net/aspose.slides/paragraphformat/default_portion_format/) eller på enskilda delar via [PortionFormat](https://reference.aspose.com/slides/sv/python-net/aspose.slides/portionformat/).

Följande exempel sätter det första styckets standardteckensnitt till 12 punkt Times New Roman med fet, kursiv och prickad understrykning. Explícit formatering på enskilda delar har företräde framför dessa standardvärden.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Ställ in teckensnittsegenskaper för stycket.
    portion_format = paragraph.paragraph_format.default_portion_format
    portion_format.font_height = 12
    portion_format.font_bold = slides.NullableBool.TRUE
    portion_format.font_italic = slides.NullableBool.TRUE
    portion_format.font_underline = slides.TextUnderlineType.DOTTED
    portion_format.latin_font = slides.FontData("Times New Roman")

    presentation.save("font_properties_for_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

![Teckensnittsegenskaper för stycket](font_properties_for_paragraph.png)

Följande exempel applicerar 13 punkt Times New Roman, kursiv formatering och en prickad understrykning på delar vars effektiva formatering är fet:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Ställ in teckensnittsegenskaper för textdelen.
            portion.portion_format.font_height = 13
            portion.portion_format.font_italic = slides.NullableBool.TRUE
            portion.portion_format.font_underline = slides.TextUnderlineType.DOTTED
            portion.portion_format.latin_font = slides.FontData("Times New Roman")

    presentation.save("font_properties_for_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

![Teckensnittsegenskaper för textdelarna](font_properties_for_text_portions.png)

## **Ange textrotation**

Använd [TextFrameFormat.text_vertical_type](https://reference.aspose.com/slides/sv/python-net/aspose.slides/textframeformat/text_vertical_type/) för att ange en fördefinierad textriktning inom en form.

Följande kodexempel sätter textriktningen i formen till [TextVerticalType.VERTICAL270](https://reference.aspose.com/slides/sv/python-net/aspose.slides/textverticaltype/), vilket roterar texten **90 grader moturs**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL270

    presentation.save("text_rotation.pptx", slides.export.SaveFormat.PPTX)
```

![Textrotationen](text_rotation.png)

## **Ange anpassad rotation för textramar**

Använd [TextFrameFormat.rotation_angle](https://reference.aspose.com/slides/sv/python-net/aspose.slides/textframeformat/rotation_angle/) för att ange en anpassad rotationsvinkel för en [TextFrame](https://reference.aspose.com/slides/sv/python-net/aspose.slides/textframe/).

Kodexemplet nedan roterar textramen med 3 grader medurs inom formen:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.rotation_angle = 3

    presentation.save("custom_text_rotation.pptx", slides.export.SaveFormat.PPTX)
```

![Den anpassade textrotationen](custom_text_rotation.png)

## **Ange radavstånd för stycken**

Aspose.Slides tillhandahåller [ParagraphFormat.space_after](https://reference.aspose.com/slides/sv/python-net/aspose.slides/paragraphformat/space_after/), [ParagraphFormat.space_before](https://reference.aspose.com/slides/sv/python-net/aspose.slides/paragraphformat/space_before/), och [ParagraphFormat.space_within](https://reference.aspose.com/slides/sv/python-net/aspose.slides/paragraphformat/space_within/) för att kontrollera styckeavstånd. Dessa egenskaper används på följande sätt:

* Använd ett positivt värde för att ange radavstånd som en procentandel av radhöjden.
* Använd ett negativt värde för att ange radavstånd i punkter.

Följande exempel sätter avståndet inom det första stycket till 200 % av radhöjden (dubbelradavstånd):

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    paragraph.paragraph_format.space_within = 200

    presentation.save("line_spacing.pptx", slides.export.SaveFormat.PPTX)
```

![Radavståndet inom stycket](line_spacing.png)

## **Styr radbrytning**

Regler för radbrytning i stycken är användbara i smala textblock och presentationer som blandar latinsk och östasiatisk text. Följande egenskaper tillhör [ParagraphFormat](https://reference.aspose.com/slides/sv/python-net/aspose.slides/paragraphformat/), så de gäller för ett helt stycke:

- [latin_line_break](https://reference.aspose.com/slides/sv/python-net/aspose.slides/paragraphformat/latin_line_break/) styr radbrytningsregler för latin. I blandad text kan en förändring också förändra var intilliggande östasiatisk text och interpunktion radbryts.
- [east_asian_line_break](https://reference.aspose.com/slides/sv/python-net/aspose.slides/paragraphformat/east_asian_line_break/) styr radbrytningsregler för östasiatisk text, inklusive begränsningar för tecken i början och slutet av en rad.

Dessa regler ersätter inte [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/sv/python-net/aspose.slides/textframeformat/wrap_text/), som möjliggör automatisk radbrytning inom en textruta. De påverkar layouten när radbrytning sker; de infogar inte radbrytningstecken. Ett explicit radbrytningstecken tvingar en ny rad inom stycket oberoende av den tillgängliga bredden.

Följande fristående exempel skapar ett smalt textblock som innehåller kinesisk och latinsk text. Det anger båda radbrytningsegenskaperna explicit och sparar "line_breaking.pptx". För att experimentera med någon av reglerna, ändra den egenskapens värde medan den andra inställningen hålls oförändrad. Exemplet använder 24-punkts Arial och SimSun med en rambredd på 160 punkter och noll horisontella textramssmarginaler. [TextFrameFormat.autofit_type](https://reference.aspose.com/slides/sv/python-net/aspose.slides/textframeformat/autofit_type/) är satt till [TextAutofitType.NONE](https://reference.aspose.com/slides/sv/python-net/aspose.slides/textautofittype/) så att textstorlek och ramdimensioner förblir fasta.

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

## **Styr hängande interpunktion**

[ParagraphFormat.hanging_punctuation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/paragraphformat/hanging_punctuation/) låter berättigad interpunktion sträcka sig bortom textlinjens högra kant istället för att ockupera nästa rad. Den gäller för hela stycket och skiljer sig från en hängande indrag.

Följande fristående exempel aktiverar hängande interpunktion i en 100-punkts bred textruta och sparar "hanging_punctuation.pptx". Med 24-punkts Arial och noll horisontella textramssmarginaler förblir den sista punkten efter "sentence" och sträcker sig bortom den högra textranden. Ställ in egenskapen till [NullableBool.FALSE](https://reference.aspose.com/slides/sv/python-net/aspose.slides/nullablebool/) för att jämföra: med dessa inställningar tar punkten en separat rad. Radbrytning är aktiverad och autofit är inaktiverat för att hålla den tillgängliga bredden fast.

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

Inte varje interpunktionstecken kan hänga. Det synliga resultatet beror på teckensnitt och layoutförhållanden: att ändra teckensnitt, tillgänglig bredd, marginaler eller autofit-inställningar kan ta bort den synliga skillnaden.

## **Ange autofit-typ för textramar**

[TextFrameFormat.autofit_type](https://reference.aspose.com/slides/sv/python-net/aspose.slides/textframeformat/autofit_type/) bestämmer hur text beter sig när den överskrider behållarens gränser. Använd den för att styra om texten krymper, rinner över eller ändrar formens storlek automatiskt. Följande exempel konfigurerar formen att storleksanpassa sig för att passa sin text och sparar resultatet till "autofit_type.pptx".

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE

    presentation.save("autofit_type.pptx", slides.export.SaveFormat.PPTX)
```

För att räkna rader efter automatisk radbrytning och se hur text- eller formbredd förändrar resultatet, se [Count Rendered Lines](/slides/sv/python-net/manage-paragraph/). Antalet rader ensamt indikerar inte om texten överskrider sin behållare.

## **Ange ankare för textramar**

[TextFrameFormat.anchoring_type](https://reference.aspose.com/slides/sv/python-net/aspose.slides/textframeformat/anchoring_type/) definierar hur text placeras vertikalt inne i en form, till exempel högst, i mitten eller längst ner. Följande exempel ankare texten till botten av den första formen och sparar resultatet till "text_anchor.pptx".

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.BOTTOM

    presentation.save("text_anchor.pptx", slides.export.SaveFormat.PPTX)
```

## **Ange texttabulering**

Använd [ParagraphFormat.default_tab_size](https://reference.aspose.com/slides/sv/python-net/aspose.slides/paragraphformat/default_tab_size/) och [ParagraphFormat.tabs](https://reference.aspose.com/slides/sv/python-net/aspose.slides/paragraphformat/tabs/) för att konfigurera tabbstopp i ett stycke. Följande exempel sätter standardtabbintervallet till 100 punkter och lägger till ett vänsterjusterat tabbstopp vid 30 punkter. Dessa inställningar påverkar text som innehåller tabbtecken.

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

![Stycke-tabbarna](paragraph_tabs.png)

## **Ange korrekturläsningsspråk**

Aspose.Slides tillhandahåller [BasePortionFormat.language_id](https://reference.aspose.com/slides/sv/python-net/aspose.slides/baseportionformat/language_id/), vilket låter dig ange korrekturläsningsspråket för en textdel. Korrekturläsningsspråket bestämmer vilket språk som används för stavnings- och grammatikgranskning i PowerPoint.

Följande exempel kräver "presentation.pptx" med en textruta som den första formen på den första bilden och minst ett stycke. Det ersätter första styckets innehåll med "1。", sätter SimSun som teckensnitt och tilldelar det förenklade kinesiska korrekturläsningsspråket (`zh-CN`). Det sparar resultatet till "proofing_language.pptx":

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

    # Ange korrekturläsningsspråket till förenklad kinesiska.
    text_portion.portion_format.language_id = "zh-CN"

    text_portion.text = "1。"
    paragraph.portions.add(text_portion)

    presentation.save("proofing_language.pptx", slides.export.SaveFormat.PPTX)
```

## **Ange standardspråk**

Använd [LoadOptions.default_text_language](https://reference.aspose.com/slides/sv/python-net/aspose.slides/loadoptions/default_text_language/) för att definiera standardspråket för text som skapas vid inläsning eller skapande av en presentation. Följande exempel skapar en presentation med amerikansk engelska som standardtextspråk, lägger till en textruta och skriver ut `en-US` för dess första textdel.

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

Följande exempel sätter ett 14-punkts fet stil som standard för översta paragrafnivån i en ny presentation och sparar den till "default_text_style.pptx". Text kan ärva dessa standardvärden om inte mer specifik formatering åsidosätter dem.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    # Hämta styckeformatet på toppnivå.
    paragraph_format = presentation.default_text_style.get_level(0)

    if paragraph_format is not None:
        paragraph_format.default_portion_format.font_height = 14
        paragraph_format.default_portion_format.font_bold = slides.NullableBool.TRUE

    presentation.save("default_text_style.pptx", slides.export.SaveFormat.PPTX)
```

## **Extrahera text med All Caps-effekt**

I PowerPoint får man genom att applicera **All Caps**-teffekten att text visas med stora bokstäver på bilden även om den ursprungligen skrevs med små bokstäver. När du hämtar en sådan textdel med Aspose.Slides returnerar biblioteket texten exakt som den angavs. För att matcha den visade texten, kontrollera [TextCapType](https://reference.aspose.com/slides/sv/python-net/aspose.slides/textcaptype/) och konvertera den returnerade strängen till versaler när värdet är `ALL`.

Detta exempel kräver "sample2.pptx" med en textruta som den första formen på den första bilden. Dess första styckes första del innehåller "Hello, Aspose!" med All Caps-effekt applicerad, som visas nedan.

![All Caps-effekten](all_caps_effect.png)

Kodexemplet nedan visar hur man extraherar texten med **All Caps**-effekt applicerad:

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

Output:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **FAQ**

**Hur ändrar jag text i en tabell på en bild?**

För att ändra text i en tabell på en bild, använd [Table](https://reference.aspose.com/slides/sv/python-net/aspose.slides/table/). Iterera genom cellerna och uppdatera varje cell via [Cell.text_frame](https://reference.aspose.com/slides/sv/python-net/aspose.slides/cell/text_frame/) och styckeformatering via [Paragraph.paragraph_format](https://reference.aspose.com/slides/sv/python-net/aspose.slides/paragraph/paragraph_format/).

**Hur applicerar jag en gradientfärg på text i en PowerPoint-bild?**

För att applicera en gradientfärg på text, använd [BasePortionFormat.fill_format](https://reference.aspose.com/slides/sv/python-net/aspose.slides/baseportionformat/fill_format/). Ställ in [FillFormat.fill_type](https://reference.aspose.com/slides/sv/python-net/aspose.slides/fillformat/fill_type/) till [FillType.GRADIENT](https://reference.aspose.com/slides/sv/python-net/aspose.slides/filltype/) och konfigurera gradientstopp, riktning och transparens.