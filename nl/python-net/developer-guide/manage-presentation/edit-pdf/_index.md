---
title: PDF-documenten bewerken in Python
linktitle: PDF bewerken
type: docs
weight: 65
url: /nl/python-net/edit-pdf/
keywords:
- PDF bewerken
- PDF-tekst vervangen
- PDF naar PPTX
- PPTX naar PDF
- Python
- Aspose.Slides
description: "Bewerk PDF-documenten in Python door ze te importeren in Aspose.Slides, tekst te vervangen en de gewijzigde presentatie op te slaan als PDF."
---
## **Overzicht**

Aspose.Slides for Python via .NET stelt u in staat om PDF-inhoud te bewerken door de pagina's te importeren als dia's, de presentatie aan te passen en deze weer naar PDF te exporteren. Dit artikel toont een eenvoudige tekstvervanging. De presentatie blijft in het geheugen, dus het opslaan van een tussenliggende PPTX‑bestand is optioneel.

## **Tekst vervangen in een PDF**

Gebruik [add_from_pdf](https://reference.aspose.com/slides/nl/python-net/aspose.slides/slidecollection/add_from_pdf/) om de pagina's te importeren, [replace_text](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/replace_text/) om de tekst bij te werken, en [save](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/save/) om het resultaat te exporteren.

Het volgende voorbeeld gaat ervan uit dat `input.pdf` na import het woord "Draft" bevat als bewerkbare tekst. Het vervangt dat woord door "Final" en schrijft `edited.pdf`. Het wissen van de eerste dia vóór import voorkomt een extra lege pagina in de uitvoer. De zoekopdracht zoekt naar volledige woorden met dezelfde hoofdlettergevoeligheid; `None` betekent dat er geen resultaat‑callback nodig is.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slides.remove_at(0)

    presentation.slides.add_from_pdf("input.pdf")

    search_options = slides.TextSearchOptions()
    search_options.whole_words_only = True
    search_options.case_sensitive = True
    presentation.replace_text("Draft", "Final", search_options, None)

    presentation.save("edited.pdf", slides.export.SaveFormat.PDF)
```

Voor meer opties, zie [Zoeken en vervangen van tekst](/slides/nl/python-net/search-and-replace-text/) en [PowerPoint naar PDF converteren](/slides/nl/python-net/convert-powerpoint-to-pdf/).

{{% alert color="info" title="Note" %}}
Tekstvervanging werkt op geïmporteerde tekst, niet op tekst in gescande afbeeldingen. De conversie kan de lay-out en opmaak beïnvloeden, dus controleer de uitvoer, vooral wanneer de vervangende tekst langer is dan het origineel.
{{% /alert %}}

## **FAQ**

**Moet ik een PPTX‑bestand opslaan voordat ik de PDF exporteer?**

Nee. U kunt dezelfde presentatie in het geheugen bewerken en exporteren. Sla een PPTX‑kopie alleen op als u deze later ook in PowerPoint wilt blijven bewerken; zie [Presentaties opslaan](/slides/nl/python-net/save-presentation/).

**Waarom kan sommige tekst ongewijzigd blijven?**

Het voorbeeld zoekt naar het volledige woord "Draft" met exacte hoofdlettergevoeligheid. Tekst die is geïmporteerd als afbeelding of verdeeld over afzonderlijke tekstframes zal niet noodzakelijkerwijs overeenkomen met de zoekopdracht. Controleer de geïmporteerde inhoud en pas de zoekopdracht aan voor uw document.