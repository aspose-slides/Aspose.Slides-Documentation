---
title: Zoeken en vervangen van tekst in PowerPoint-presentaties in Python
linktitle: Zoeken en vervangen van tekst
type: docs
weight: 55
url: /nl/python-net/search-and-replace-text/
keywords:
- tekst zoeken
- tekst markeren
- tekst vervangen
- reguliere expressie
- tekstkader
- PowerPoint
- OpenDocument
- presentatie
- Python
- Aspose.Slides
description: "Zoek, markeer en vervang tekst in PowerPoint-presentaties met Aspose.Slides for Python via .NET."
---
## **Overzicht**

Aspose.Slides for Python via .NET kan zoeken, markeren en tekst vervangen in een enkel tekstkader of in de gehele presentatie. Deze mogelijkheden zijn nuttig voor beoordeling, redactie, terminologiecontroles, sjabloonopschoning en andere geautomatiseerde documentverwerkings‑workflows.

In de eerste voorbeelden hieronder gebruiken we een bestand met de naam "sample.pptx", dat één tekstvak op de eerste dia bevat met de volgende tekst:

![Voorbeeldtekst](sample_text.png)

## **Kies het zoekbereik**

Gebruik methoden op [TextFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframe/) om een bewerking te beperken tot één tekstkader. Gebruik methoden op [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/) om alle toepasselijke tekst in de presentatie te verwerken.

| Bewerkingen | Eén tekstkader | Gehele presentatie |
|---|---|---|
| Markeer letterlijke tekst | [TextFrame.highlight_text](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframe/highlight_text/) | [Presentation.highlight_text](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/highlight_text/) |
| Markeer reguliere‑expressie‑overeenkomsten | [TextFrame.highlight_regex](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframe/highlight_regex/) | [Presentation.highlight_regex](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/highlight_regex/) |
| Vervang letterlijke tekst | [TextFrame.replace_text](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframe/replace_text/) | [Presentation.replace_text](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/replace_text/) |
| Vervang reguliere‑expressie‑overeenkomsten | [TextFrame.replace_regex](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframe/replace_regex/) | [Presentation.replace_regex](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/replace_regex/) |

## **Configureer tekstmatching**

Voor bewerkingen met letterlijke tekst, gebruik [TextSearchOptions](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textsearchoptions/) om de overeenkomsten te regelen:

- [TextSearchOptions.whole_words_only](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textsearchoptions/whole_words_only/) beperkt overeenkomsten tot volledige woorden.
- [TextSearchOptions.case_sensitive](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textsearchoptions/case_sensitive/) bepaalt of hoofdlettergevoeligheid vereist is.
- [TextSearchOptions.include_notes](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textsearchoptions/include_notes/) neemt dia‑notities op in zoek‑, vervang‑ en markeerbewerkingen op presentatie‑niveau.

Bewerkingen met reguliere expressies gebruiken een patroon‑string, zodat regels voor overeenkomsten zoals hoofdlettergevoeligheid en woordgrenzen door de expressie worden bepaald.

## **Markeer tekst**

Gebruik de methode [TextFrame.highlight_text](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframe/highlight_text/) om letterlijke tekst‑overeenkomsten in een tekstkader te markeren. Geef [TextSearchOptions](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textsearchoptions/) door om de zoekopdracht te regelen.

Het code‑voorbeeld hieronder markeert alle voorkomens van de tekens **"try"** en vervolgens alleen het volledige woord **"to"**.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    substring_search_options = slides.TextSearchOptions()
    substring_search_options.case_sensitive = False

    # Markeer elk voorkomen van "try" in het tekstkader.
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

De methode [TextFrame.highlight_regex](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframe/highlight_regex/) markeert tekst‑overeenkomsten die door een reguliere expressie in een tekstkader worden gevonden.

De volgende code markeert alle woorden die zeven of meer tekens bevatten:

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

![De gemarkeerde tekst met behulp van de reguliere expressie](highlighted_text_using_regex.png)

## **Markeer tekst in een volledige presentatie**

Gebruik [Presentation.highlight_text](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/highlight_text/) en [Presentation.highlight_regex](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/highlight_regex/) om alle toepasselijke tekstkaders in een presentatie te doorzoeken. Het volgende voorbeeld markeert een letterlijke term en alle e‑mailadressen:

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

## **Vervang tekst in een tekstkader**

Gebruik [TextFrame.replace_text](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframe/replace_text/) voor letterlijke tekst en [TextFrame.replace_regex](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframe/replace_regex/) voor op patroon gebaseerde vervanging. Deze methoden werken de gevonden tekst bij binnen het bestaande tekstkader, waarbij de opmaak van de omringende delen behouden blijft in plaats van het tekstkader opnieuw op te bouwen vanuit een platte string.

Het volgende voorbeeld standaardiseert een spellingvariatie en vervangt vervolgens versie‑labels:

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

Als één overeenkomst delen met verschillende opmaak omvat, controleer dan de output om te bevestigen welke opmaak op de vervangende tekst moet worden toegepast.

## **Vervang tekst in een volledige presentatie**

Gebruik [Presentation.replace_text](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/replace_text/) en [Presentation.replace_regex](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/replace_regex/) om dezelfde bewerkingen door de hele presentatie toe te passen. Dit is handig voor sjabloonopschoning, terminologie‑updates en redactie.

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

Haal het tekstkader van de vorm op en roep [TextFrame.highlight_text](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframe/highlight_text/), [TextFrame.highlight_regex](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframe/highlight_regex/), [TextFrame.replace_text](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframe/replace_text/) of [TextFrame.replace_regex](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframe/replace_regex/) aan op dat tekstkader. Methoden op presentatieniveau verwerken alle toepasselijke tekstkaders.

**Hoe kan ik volledige woorden met de juiste kapitalisatie matchen?**

Zet [TextSearchOptions.whole_words_only](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textsearchoptions/whole_words_only/) en [TextSearchOptions.case_sensitive](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textsearchoptions/case_sensitive/) op `True` en geef de opties door aan een markeer‑ of vervangingsmethode voor letterlijke tekst. Voor reguliere expressies definieer je woordgrenzen en hoofdlettergevoeligheid in de expressie zelf.

**Kunnen zoek‑ en vervangingsbewerkingen tekst in dia‑notities omvatten?**

Ja. Zet [TextSearchOptions.include_notes](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textsearchoptions/include_notes/) op `True` bij het gebruik van een letterlijke‑tekst‑bewerking op presentatieniveau.

**Behoudt het vervangen van tekst de opmaak?**

[TextFrame.replace_text](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframe/replace_text/) en [TextFrame.replace_regex](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframe/replace_regex/) wijzigen de gevonden tekst binnen het bestaande tekstkader en behouden de opmaak van de omringende delen. Als een overeenkomst delen met verschillende opmaak omvat, inspecteer dan het resultaat om te verzekeren dat de vervanging de gewenste stijl gebruikt.