---
title: Import Presentaties met Python
linktitle: Import Presentatie
type: docs
weight: 60
url: /nl/python-net/import-presentation/
keywords:
- PowerPoint importeren
- presentatie importeren
- dia importeren
- PDF naar presentatie
- PDF naar PPT
- PDF naar PPTX
- PDF naar ODP
- HTML naar presentatie
- HTML naar PPT
- HTML naar PPTX
- HTML naar ODP
- Python
- Aspose.Slides
description: "Importeer moeiteloos PDF- en HTML-documenten in PowerPoint- en OpenDocument-presentaties in Python met Aspose.Slides voor naadloze, high-performance dia-verwerking."
---
## **Introductie**

Met [**Aspose.Slides for Python via .NET**](https://products.aspose.com/slides/nl/python-net/) kun je inhoud importeren in een presentatie vanuit andere bestandsformaten. De klasse [SlideCollection](https://reference.aspose.com/slides/nl/python-net/aspose.slides/slidecollection/) biedt methoden om dia’s te importeren vanuit PDF, HTML en andere bronnen.

## **PDF converteren naar een presentatie**

Deze sectie laat zien hoe je een PDF converteert naar een presentatie met Aspose.Slides. Het leidt je door het importeren van de PDF, het omzetten van de pagina’s naar dia’s en het opslaan van het resultaat als een PPTX‑bestand.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/).
2. Roep de methode [add_from_pdf](https://reference.aspose.com/slides/nl/python-net/aspose.slides/slidecollection/add_from_pdf/) aan en geef het PDF‑bestand door.
3. Gebruik de methode [save](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/save/) om de presentatie op te slaan in PowerPoint‑formaat.

Het volgende Python‑voorbeeld toont het converteren van een PDF naar een presentatie:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slides.remove_at(0)

    presentation.slides.add_from_pdf("sample.pdf")

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert  title="Tip" color="primary" %}}
Je wilt misschien de **gratis** [PDF to PowerPoint](https://products.aspose.app/slides/nl/import/pdf-to-powerpoint) webapp van Aspose proberen — het is een live‑implementatie van het hier beschreven proces.
{{% /alert %}}

## **HTML converteren naar een presentatie**

Deze sectie laat zien hoe je HTML‑inhoud importeert in een presentatie met Aspose.Slides. Het behandelt het laden van de HTML, het omzetten ervan naar dia’s met behoud van tekst, afbeeldingen en eenvoudige opmaak, en het opslaan van het resultaat als een PPTX‑bestand.

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/).
2. Roep de methode [add_from_html](https://reference.aspose.com/slides/nl/python-net/aspose.slides/slidecollection/add_from_html/) aan en geef het HTML‑bestand door.
3. Gebruik de methode [save](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/save/) om de presentatie op te slaan in PowerPoint‑formaat.

Het volgende Python‑voorbeeld toont het converteren van HTML naar een presentatie:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slides.remove_at(0)

    with open("page.html", "rb") as html_stream:
        presentation.slides.add_from_html(html_stream)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Worden tabellen behouden bij het importeren van een PDF, en kan hun detectie worden verbeterd?**

Tabellen kunnen tijdens het importeren worden gedetecteerd; [PdfImportOptions](https://reference.aspose.com/slides/nl/python-net/aspose.slides.importing/pdfimportoptions/) bevat een parameter [detect_tables](https://reference.aspose.com/slides/nl/python-net/aspose.slides.importing/pdfimportoptions/detect_tables/) die tabelherkenning inschakelt. De effectiviteit hangt af van de structuur van de PDF.

{{% alert title="Note" color="info" %}}
Je kunt ook Aspose.Slides gebruiken om HTML om te zetten naar andere populaire bestandsformaten:

* [HTML naar afbeelding](https://products.aspose.com/slides/nl/python-net/conversion/html-to-image/)
* [HTML naar JPG](https://products.aspose.com/slides/nl/python-net/conversion/html-to-jpg/)
* [HTML naar XML](https://products.aspose.com/slides/nl/python-net/conversion/html-to-xml/)
* [HTML naar TIFF](https://products.aspose.com/slides/nl/python-net/conversion/html-to-tiff/)

{{% /alert %}}