---
title: Sök och ersätt text i PowerPoint-presentationer i Python
linktitle: Sök och ersätt text
type: docs
weight: 55
url: /sv/python-net/search-and-replace-text/
keywords:
- sök text
- markera text
- ersätt text
- reguljärt uttryck
- textram
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Sök, markera och ersätt text i PowerPoint-presentationer med Aspose.Slides för Python via .NET."
---
## **Översikt**

Aspose.Slides för Python via .NET kan söka, markera och ersätta text i en enskild textram eller i hela en presentation. Dessa funktioner är användbara för granskning, redigering, terminologikontroller, mallrengöring och andra automatiserade dokumentbehandlingsarbetsflöden.

I de första exemplen nedan använder vi en fil som heter "sample.pptx", som innehåller en enda textruta på den första bilden med följande text:

![Exempeltext](sample_text.png)

## **Välj sökområde**

Använd metoder på [TextFrame](https://reference.aspose.com/slides/sv/python-net/aspose.slides/textframe/) för att begränsa en operation till en textram. Använd metoder på [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/) för att bearbeta all tillämplig text i presentationen.

| Operation | En textram | Hela presentationen |
|---|---|---|
| Markera bokstavlig text | [TextFrame.highlight_text](https://reference.aspose.com/slides/sv/python-net/aspose.slides/textframe/highlight_text/) | [Presentation.highlight_text](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/highlight_text/) |
| Markera matchningar med reguljärt uttryck | [TextFrame.highlight_regex](https://reference.aspose.com/slides/sv/python-net/aspose.slides/textframe/highlight_regex/) | [Presentation.highlight_regex](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/highlight_regex/) |
| Ersätt bokstavlig text | [TextFrame.replace_text](https://reference.aspose.com/slides/sv/python-net/aspose.slides/textframe/replace_text/) | [Presentation.replace_text](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/replace_text/) |
| Ersätt matchningar med reguljärt uttryck | [TextFrame.replace_regex](https://reference.aspose.com/slides/sv/python-net/aspose.slides/textframe/replace_regex/) | [Presentation.replace_regex](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/replace_regex/) |

## **Konfigurera textmatchning**

För operationer med bokstavlig text, använd [TextSearchOptions](https://reference.aspose.com/slides/sv/python-net/aspose.slides/textsearchoptions/) för att kontrollera matchning:

- [TextSearchOptions.whole_words_only](https://reference.aspose.com/slides/sv/python-net/aspose.slides/textsearchoptions/whole_words_only/) begränsar matchningar till hela ord.
- [TextSearchOptions.case_sensitive](https://reference.aspose.com/slides/sv/python-net/aspose.slides/textsearchoptions/case_sensitive/) styr om teckenkasning måste matcha.
- [TextSearchOptions.include_notes](https://reference.aspose.com/slides/sv/python-net/aspose.slides/textsearchoptions/include_notes/) inkluderar bildanteckningar i sök-, ersättnings- och markeringsoperationer på presentationsnivå.

Operationer med reguljära uttryck använder en mönstersträng, så matchningsregler såsom teckenkasning och ordgränser definieras av själva uttrycket.

## **Identifiera ägaren av en textram**

Generiska textbehandlingsarbetsflöden får ofta en [TextFrame](https://reference.aspose.com/slides/sv/python-net/aspose.slides/textframe/) när de söker, ersätter, validerar eller exporterar text. Använd [TextFrame.parent_shape](https://reference.aspose.com/slides/sv/python-net/aspose.slides/textframe/parent_shape/) och [TextFrame.parent_cell](https://reference.aspose.com/slides/sv/python-net/aspose.slides/textframe/parent_cell/) för att avgöra vilket presentationsobjekt som äger textramen.

De förväntade värdena beror på ägaren:

| Ägare av textram | `parent_shape` | `parent_cell` |
|---|---|---|
| En AutoShape eller en annan textinnehållande form | Den ägande [Shape](https://reference.aspose.com/slides/sv/python-net/aspose.slides/shape/) | `None` |
| En tabellcell | `None` | Den ägande [Cell](https://reference.aspose.com/slides/sv/python-net/aspose.slides/cell/) |

Båda egenskaperna är skrivskyddade navigeringsegenskaper. Att läsa dem flyttar inte textramen eller ändrar dess ägare. Generisk kod bör kontrollera båda värdena för `None` och hantera möjligheten att ingen ägare finns tillgänglig.

Följande exempel använder [SlideUtil.get_all_text_frames](https://reference.aspose.com/slides/sv/python-net/aspose.slides.util/slideutil/get_all_text_frames/) för att iterera genom textramarna i en presentation. För former rapporteras formens namn, Python‑körtidstyp och innehållande bild. För tabellceller rapporteras de nollbaserade kolumn‑ och radkoordinaterna samt den innehållande bilden.

```python
import aspose.slides as slides


def get_slide_label(base_slide):
    if isinstance(base_slide, slides.Slide):
        return f"slide {base_slide.slide_number}"

    if isinstance(base_slide, slides.NotesSlide):
        return f"notes for slide {base_slide.parent_slide.slide_number}"

    return type(base_slide).__name__


with slides.Presentation("presentation.pptx") as presentation:
    text_frames = slides.util.SlideUtil.get_all_text_frames(presentation, False)

    for text_frame in text_frames:
        owner_shape = text_frame.parent_shape
        if owner_shape is not None:
            shape_name = owner_shape.name or "(unnamed)"
            shape_type = type(owner_shape).__name__
            slide_label = get_slide_label(owner_shape.slide)
            print(f"Shape: {shape_name}; type: {shape_type}; {slide_label}")
            continue

        owner_cell = text_frame.parent_cell
        if owner_cell is not None:
            slide_label = get_slide_label(owner_cell.slide)
            print(f"Table cell: column {owner_cell.first_column_index}, row {owner_cell.first_row_index}; {slide_label}")
            continue

        print("The text frame owner is not available as a shape or table cell.")
```

För SmartArt‑innehåll itereras genom formerna i [SmartArtNode.shapes](https://reference.aspose.com/slides/sv/python-net/aspose.slides.smartart/smartartnode/shapes/) och varje [ISmartArtShape.text_frame](https://reference.aspose.com/slides/sv/python-net/aspose.slides.smartart/ismartartshape/text_frame/) nås. Textramen kan spåras till sin associerade form via [TextFrame.parent_shape](https://reference.aspose.com/slides/sv/python-net/aspose.slides/textframe/parent_shape/), medan [TextFrame.parent_cell](https://reference.aspose.com/slides/sv/python-net/aspose.slides/textframe/parent_cell/) är `None`. Därför hanterar formgrenen i exemplet även text från SmartArt‑noder.

## **Markera text**

Använd metoden [TextFrame.highlight_text](https://reference.aspose.com/slides/sv/python-net/aspose.slides/textframe/highlight_text/) för att markera bokstavliga matchningar i en textram. Skicka in [TextSearchOptions](https://reference.aspose.com/slides/sv/python-net/aspose.slides/textsearchoptions/) för att styra sökningen.

Kodexemplet nedan markerar alla förekomster av tecknen **"try"** och markerar sedan bara hela ordet **"to"**.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    substring_search_options = slides.TextSearchOptions()
    substring_search_options.case_sensitive = False

    # Markera varje förekomst av "try" i textramen.
    shape.text_frame.highlight_text(
        "try", draw.Color.light_blue, substring_search_options, None
    )

    whole_word_search_options = slides.TextSearchOptions()
    whole_word_search_options.whole_words_only = True
    whole_word_search_options.case_sensitive = False

    # Markera bara hela ordet "to".
    shape.text_frame.highlight_text(
        "to", draw.Color.violet, whole_word_search_options, None
    )

    presentation.save("highlighted_text.pptx", slides.export.SaveFormat.PPTX)
```

Resultatet:

![Den markerade texten](highlighted_text.png)

## **Markera text med reguljära uttryck**

Metoden [TextFrame.highlight_regex](https://reference.aspose.com/slides/sv/python-net/aspose.slides/textframe/highlight_regex/) markerar textmatchningar som hittas med ett reguljärt uttryck i en textram.

Följande kod markerar alla ord som innehåller sju eller fler tecken:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    word_pattern = r"\b[^\s]{7,}\b"

    shape.text_frame.highlight_regex(word_pattern, draw.Color.yellow, None)

    presentation.save(
        "highlighted_text_using_regex.pptx", slides.export.SaveFormat.PPTX
    )
```

Resultatet:

![Den markerade texten med reguljärt uttryck](highlighted_text_using_regex.png)

## **Markera text i en presentation**

Använd [Presentation.highlight_text](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/highlight_text/) och [Presentation.highlight_regex](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/highlight_regex/) för att söka alla tillämpliga textramar i en presentation. Följande exempel markerar ett bokstavligt begrepp och alla e‑postadresser:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    search_options = slides.TextSearchOptions()
    search_options.whole_words_only = True
    search_options.case_sensitive = False

    presentation.highlight_text(
        "confidential", draw.Color.orange, search_options, None
    )

    email_pattern = r"(?i)\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,}\b"
    presentation.highlight_regex(email_pattern, draw.Color.yellow)

    presentation.save(
        "highlighted_presentation.pptx", slides.export.SaveFormat.PPTX
    )
```

## **Ersätt text i en textram**

Använd [TextFrame.replace_text](https://reference.aspose.com/slides/sv/python-net/aspose.slides/textframe/replace_text/) för bokstavlig text och [TextFrame.replace_regex](https://reference.aspose.com/slides/sv/python-net/aspose.slides/textframe/replace_regex/) för mönsterbaserad ersättning. Dessa metoder uppdaterar matchad text inom den befintliga textramen, vilket bevarar formateringen på omgivande delar istället för att bygga om textramen från en vanlig sträng.

Följande exempel standardiserar en stavningsvariant och ersätter sedan versionsetiketter:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    search_options = slides.TextSearchOptions()
    search_options.whole_words_only = True
    search_options.case_sensitive = False

    shape.text_frame.replace_text(
        "colour", "color", search_options, None
    )

    version_pattern = r"(?i)\bv\d+(?:\.\d+)*\b"
    shape.text_frame.replace_regex(version_pattern, "current version")

    presentation.save(
        "updated_text_frame.pptx", slides.export.SaveFormat.PPTX
    )
```

Om en matchning spänner över delar med olika formatering, granska resultatet för att bekräfta vilken formatering som ska tillämpas på den ersatta texten.

## **Ersätt text i en presentation**

Använd [Presentation.replace_text](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/replace_text/) och [Presentation.replace_regex](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/replace_regex/) för att tillämpa samma operationer i hela presentationen. Detta är användbart för mallrengöring, terminologiska uppdateringar och redigering.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    search_options = slides.TextSearchOptions()
    search_options.whole_words_only = True
    search_options.case_sensitive = True

    presentation.replace_text(
        "Contoso", "Example Corp", search_options, None
    )

    account_number_pattern = r"\bACCT-\d{6}\b"
    presentation.replace_regex(account_number_pattern, "ACCT-REDACTED")

    presentation.save(
        "updated_presentation.pptx", slides.export.SaveFormat.PPTX
    )
```

## **FAQ**

**Hur kan jag söka endast i en textruta istället för hela presentationen?**

Hämta formens textram och anropa [TextFrame.highlight_text](https://reference.aspose.com/slides/sv/python-net/aspose.slides/textframe/highlight_text/), [TextFrame.highlight_regex](https://reference.aspose.com/slides/sv/python-net/aspose.slides/textframe/highlight_regex/), [TextFrame.replace_text](https://reference.aspose.com/slides/sv/python-net/aspose.slides/textframe/replace_text/) eller [TextFrame.replace_regex](https://reference.aspose.com/slides/sv/python-net/aspose.slides/textframe/replace_regex/) på den textramen. Metoder på presentationsnivå bearbetar alla tillämpliga textramar istället.

**Hur kan jag matcha hela ord med korrekt versalisering?**

Ställ in [TextSearchOptions.whole_words_only](https://reference.aspose.com/slides/sv/python-net/aspose.slides/textsearchoptions/whole_words_only/) och [TextSearchOptions.case_sensitive](https://reference.aspose.com/slides/sv/python-net/aspose.slides/textsearchoptions/case_sensitive/) till `True` och skicka alternativen till en metod för markerning eller ersättning av bokstavlig text. För reguljära uttryck definieras ordgränser och teckenkasning i själva mönstret.

**Kan sökning och ersättning inkludera text i bildanteckningar?**

Ja. Ställ in [TextSearchOptions.include_notes](https://reference.aspose.com/slides/sv/python-net/aspose.slides/textsearchoptions/include_notes/) till `True` när du använder en bokstavlig textoperation på presentationsnivå.

**Behåller ersättning av text dess formatering?**

[TextFrame.replace_text](https://reference.aspose.com/slides/sv/python-net/aspose.slides/textframe/replace_text/) och [TextFrame.replace_regex](https://reference.aspose.com/slides/sv/python-net/aspose.slides/textframe/replace_regex/) ändrar matchad text inom den befintliga textramen och behåller formateringen på omgivande delar. Om en matchning spänner över delar med olika formatering, inspektera resultatet för att säkerställa att ersättningen använder den önskade stilen.