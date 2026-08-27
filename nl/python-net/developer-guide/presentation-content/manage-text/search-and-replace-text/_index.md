---
title: Zoeken en Vervangen van Tekst in PowerPoint-presentaties met Python
linktitle: Zoeken en Vervangen van Tekst
type: docs
weight: 55
url: /nl/python-net/search-and-replace-text/
keywords:
- tekst zoeken
- tekst markeren
- tekst vervangen
- reguliere expressie
- tekstframe
- PowerPoint
- OpenDocument
- presentatie
- Python
- Aspose.Slides
description: "Zoek, markeer en vervang tekst in PowerPoint-presentaties met Aspose.Slides voor Python via .NET."
---
## **Overzicht**

Aspose.Slides for Python via .NET kan zoeken, markeren en tekst vervangen in een enkel tekstframe of in de volledige presentatie. Deze functionaliteit is nuttig voor controle, redactie, terminologie‑checks, sjabloon‑opschoning en andere geautomatiseerde document‑verwerkingsprocessen.

In de eerste voorbeelden hieronder gebruiken we een bestand genaamd "sample.pptx", dat een enkele tekstbox op de eerste dia bevat met de volgende tekst:

![Voorbeeldtekst](sample_text.png)

## **Kies de zoekscope**

Gebruik methoden op [TextFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframe/) om een bewerking te beperken tot één tekstframe. Gebruik methoden op [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/) om alle toepasselijke tekst in de presentatie te verwerken.

| Bewerking | Eén tekstframe | Volledige presentatie |
|---|---|---|
| Markeer letterlijke tekst | [TextFrame.highlight_text](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframe/highlight_text/) | [Presentation.highlight_text](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/highlight_text/) |
| Markeer reguliere‑expressie‑overeenkomsten | [TextFrame.highlight_regex](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframe/highlight_regex/) | [Presentation.highlight_regex](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/highlight_regex/) |
| Vervang letterlijke tekst | [TextFrame.replace_text](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframe/replace_text/) | [Presentation.replace_text](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/replace_text/) |
| Vervang reguliere‑expressie‑overeenkomsten | [TextFrame.replace_regex](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframe/replace_regex/) | [Presentation.replace_regex](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/replace_regex/) |

## **Configureer tekstmatching**

Voor letterlijke‑tekstbewerkingen gebruik je [TextSearchOptions](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textsearchoptions/) om het zoeken te sturen:

- [TextSearchOptions.whole_words_only](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textsearchoptions/whole_words_only/) beperkt overeenkomsten tot volledige woorden.
- [TextSearchOptions.case_sensitive](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textsearchoptions/case_sensitive/) bepaalt of hoofdlettergebruik moet overeenkomen.
- [TextSearchOptions.include_notes](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textsearchoptions/include_notes/) neemt dia‑aantekeningen op in zoek‑, vervang‑ en markeringsbewerkingen op presentatieniveau.

Reguliere‑expressie‑bewerkingen maken gebruik van een patroon‑string, waardoor regels zoals hoofdlettergevoeligheid en woordgrenzen door de expressie zelf worden gedefinieerd.

## **Identificeer de eigenaar van een tekstframe**

Generieke tekstverwerkingsworkflows ontvangen vaak een [TextFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframe/) tijdens het zoeken, vervangen, valideren of exporteren van tekst. Gebruik [TextFrame.parent_shape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframe/parent_shape/) en [TextFrame.parent_cell](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframe/parent_cell/) om te bepalen welk presentatie‑object het tekstframe bezit.

De verwachte waarden hangen af van de eigenaar:

| Eigenaar van tekstframe | `parent_shape` | `parent_cell` |
|---|---|---|
| Een AutoShape of een andere tekstbevatende vorm | De bijbehorende [Shape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/shape/) | `None` |
| Een tabelcel | `None` | De bijbehorende [Cell](https://reference.aspose.com/slides/nl/python-net/aspose.slides/cell/) |

Beide eigenschappen zijn alleen‑lees‑navigatie‑eigenschappen. Ze lezen verplaatst het tekstframe niet en verandert de eigenaar niet. Generieke code moet beide waarden op `None` controleren en rekening houden met de mogelijkheid dat geen van beide eigenaar beschikbaar is.

Het volgende voorbeeld gebruikt [SlideUtil.get_all_text_frames](https://reference.aspose.com/slides/nl/python-net/aspose.slides.util/slideutil/get_all_text_frames/) om door de tekstframes in een presentatie te itereren. Voor vormen rapporteert het de vormnaam, het Python‑runtime‑type en de bijbehorende dia. Voor tabelcellen rapporteert het de nul‑gebaseerde kolom‑ en rijcoördinaten en de bijbehorende dia.

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

Voor SmartArt‑inhoud itereren we door de vormen in [SmartArtNode.shapes](https://reference.aspose.com/slides/nl/python-net/aspose.slides.smartart/smartartnode/shapes/) en benaderen we elke [ISmartArtShape.text_frame](https://reference.aspose.com/slides/nl/python-net/aspose.slides.smartart/ismartartshape/text_frame/). Het tekstframe kan worden getraceerd naar de bijbehorende vorm via [TextFrame.parent_shape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframe/parent_shape/), terwijl [TextFrame.parent_cell](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframe/parent_cell/) `None` is. Daarom behandelt de vorm‑tak in het voorbeeld ook tekst uit SmartArt‑knopen.

## **Markeer tekst**

Gebruik de [TextFrame.highlight_text](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframe/highlight_text/) methode om letterlijke‑tekstovereenkomsten in een tekstframe te markeren. Geef [TextSearchOptions](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textsearchoptions/) door om het zoeken te sturen.

Het code‑voorbeeld hieronder markeert alle voorkomens van de tekens **"try"** en daarna alleen het volledige woord **"to"**.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    substring_search_options = slides.TextSearchOptions()
    substring_search_options.case_sensitive = False

    # Markeer elke keer dat "try" voorkomt in het tekstframe.
    shape.text_frame.highlight_text(
        "try", draw.Color.light_blue, substring_search_options, None
    )

    whole_word_search_options = slides.TextSearchOptions()
    whole_word_search_options.whole_words_only = True
    whole_word_search_options.case_sensitive = False

    # Markeer alleen het volledige woord "to".
    shape.text_frame.highlight_text(
        "to", draw.Color.violet, whole_word_search_options, None
    )

    presentation.save("highlighted_text.pptx", slides.export.SaveFormat.PPTX)
```

Het resultaat:

![De gemarkeerde tekst](highlighted_text.png)

## **Markeer tekst met reguliere expressies**

De [TextFrame.highlight_regex](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframe/highlight_regex/) methode markeert tekstovereenkomsten die door een reguliere expressie worden gevonden in een tekstframe.

De volgende code markeert alle woorden met zeven of meer tekens:

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

Het resultaat:

![De gemarkeerde tekst met de reguliere expressie](highlighted_text_using_regex.png)

## **Markeer tekst in een presentatie**

Gebruik [Presentation.highlight_text](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/highlight_text/) en [Presentation.highlight_regex](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/highlight_regex/) om alle toepasselijke tekstframes in een presentatie te doorzoeken. Het volgende voorbeeld markeert een letterlijke term en alle e‑mailadressen:

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

## **Vervang tekst in een tekstframe**

Gebruik [TextFrame.replace_text](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframe/replace_text/) voor letterlijke tekst en [TextFrame.replace_regex](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframe/replace_regex/) voor patroon‑gebaseerde vervanging. Deze methoden werken de gevonden tekst bij binnen het bestaande tekstframe, waardoor de omliggende opmaak behouden blijft in plaats van het tekstframe opnieuw op te bouwen uit een platte string.

Het volgende voorbeeld normaliseert een spellingvariant en vervangt vervolgens versie‑labels:

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

Als een overeenkomst delen met verschillende opmaak overspant, controleer dan de output om te bevestigen welke opmaak op de vervangende tekst moet worden toegepast.

## **Vervang tekst in een presentatie**

Gebruik [Presentation.replace_text](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/replace_text/) en [Presentation.replace_regex](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/replace_regex/) om dezelfde bewerkingen over de hele presentatie toe te passen. Dit is nuttig voor sjabloon‑opschoning, terminologie‑updates en redactie.

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

**Hoe kan ik slechts één tekstvak doorzoeken in plaats van de hele presentatie?**

Haal het tekstframe van de vorm op en roep [TextFrame.highlight_text](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframe/highlight_text/), [TextFrame.highlight_regex](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframe/highlight_regex/), [TextFrame.replace_text](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframe/replace_text/) of [TextFrame.replace_regex](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframe/replace_regex/) aan op dat tekstframe. Methoden op presentatieniveau verwerken alle toepasselijke tekstframes in plaats daarvan.

**Hoe kan ik volledige woorden matchen met de juiste hoofdlettergebruik?**

Stel [TextSearchOptions.whole_words_only](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textsearchoptions/whole_words_only/) en [TextSearchOptions.case_sensitive](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textsearchoptions/case_sensitive/) in op `True` en geef de opties door aan een letterlijke‑tekst‑markerings‑ of vervangingsmethode. Voor reguliere expressies definieer je woordgrenzen en hoofdlettergevoeligheid direct in het patroon.

**Kunnen zoeken en vervangen tekst uit dia‑aantekeningen opnemen?**

Ja. Stel [TextSearchOptions.include_notes](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textsearchoptions/include_notes/) in op `True` wanneer je een letterlijke‑tekstbewerking op presentatieniveau gebruikt.

**Behoudt het vervangen van tekst de opmaak?**

[TextFrame.replace_text](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframe/replace_text/) en [TextFrame.replace_regex](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframe/replace_regex/) wijzigen de gevonden tekst binnen het bestaande tekstframe en behouden de opmaak van de omliggende delen. Als een overeenkomst delen met verschillende opmaak overspant, inspecteer dan het resultaat om te verzekeren dat de vervanging de gewenste stijl gebruikt.