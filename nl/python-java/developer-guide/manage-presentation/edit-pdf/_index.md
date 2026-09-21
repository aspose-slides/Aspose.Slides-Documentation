---
title: PDF-documenten bewerken in Python via Java
linktitle: PDF bewerken
type: docs
weight: 65
url: /nl/python-java/edit-pdf/
keywords:
- PDF bewerken
- PDF-tekst vervangen
- PDF naar PPTX
- PPTX naar PDF
- Python
- Java
- Aspose.Slides
description: "PDF-documenten bewerken in Python via Java door ze te importeren in Aspose.Slides, de tekst te vervangen en de aangepaste presentatie terug op te slaan als PDF."
---
## **Overzicht**

Aspose.Slides for Python via Java stelt je in staat PDF‑inhoud te bewerken door de pagina's te importeren als dia's, de presentatie aan te passen en deze weer naar PDF te exporteren. Dit artikel laat een eenvoudige tekstvervanging zien. De presentatie blijft in het geheugen, waardoor het opslaan van een tijdelijk PPTX‑bestand optioneel is.

## **Tekst vervangen in een PDF**

Gebruik [addFromPdf](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slidecollection/#addFromPdf) om de pagina's te importeren, [replaceText](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/#replaceText) om de tekst bij te werken, en [save](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/#save) om het resultaat te exporteren.

Het volgende voorbeeld gaat ervan uit dat `input.pdf` het woord "Draft" bevat als bewerkbare tekst na import. Het vervangt dat woord door "Final" en schrijft `edited.pdf`. Het leegmaken van de eerste dia vóór import voorkomt een extra lege pagina in de uitvoer. De zoekopdracht zoekt naar volledige woorden met dezelfde hoofdlettergevoeligheid; `None` betekent dat er geen resultaat‑callback nodig is.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TextSearchOptions

presentation = Presentation()
try:
    presentation.getSlides().removeAt(0)

    presentation.getSlides().addFromPdf("input.pdf")

    search_options = TextSearchOptions()
    search_options.setWholeWordsOnly(True)
    search_options.setCaseSensitive(True)
    presentation.replaceText("Draft", "Final", search_options, None)

    presentation.save("edited.pdf", SaveFormat.Pdf)
finally:
    presentation.dispose()
```

Voor meer opties, zie [Zoeken en vervangen van tekst](/slides/nl/python-java/search-and-replace-text/) en [PowerPoint naar PDF converteren](/slides/nl/python-java/convert-powerpoint-to-pdf/).

{{% alert color="info" title="Note" %}}
Tekstvervanging werkt op geïmporteerde tekst, niet op tekst in gescande afbeeldingen. De conversie kan de lay-out en opmaak beïnvloeden, dus controleer de uitvoer, vooral wanneer de vervangende tekst langer is dan het origineel.
{{% /alert %}}

## **FAQ**

**Moet ik een PPTX‑bestand opslaan voordat ik de PDF exporteer?**

Nee. Je kunt dezelfde presentatie in het geheugen bewerken en exporteren. Sla een PPTX‑kopie alleen op als je deze ook in PowerPoint wilt blijven bewerken; zie [Presentaties opslaan](/slides/nl/python-java/save-presentation/).

**Waarom kan het voorkomen dat bepaalde tekst ongewijzigd blijft?**

Het voorbeeld zoekt naar het volledige woord "Draft" met exacte hoofdlettergevoeligheid. Tekst die als afbeelding wordt geïmporteerd of verspreid over afzonderlijke tekstframes, zal niet per se overeenkomen met de zoekopdracht. Controleer de geïmporteerde inhoud en pas de zoekopdracht aan voor je document.