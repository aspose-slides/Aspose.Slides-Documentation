---
title: PowerPoint-presentaties naar XML converteren in Python
linktitle: PowerPoint naar XML
type: docs
weight: 145
url: /nl/python-net/convert-powerpoint-to-xml/
keywords:
- PowerPoint converteren naar XML
- presentatie converteren naar XML
- PPT naar XML
- PPTX naar XML
- ODP naar XML
- PowerPoint XML-presentatie
- SaveFormat.XML
- presentatie opslaan als XML
- presentatie exporteren naar XML
- XML-stream
- Python
- Aspose.Slides
description: "Converteer PowerPoint- en OpenDocument-presentaties naar PowerPoint XML-bestanden of -streams in Python met Aspose.Slides."
---
## **Overzicht**

Aspose.Slides for Python via .NET kan PowerPoint‑presentaties converteren naar het PowerPoint XML Presentation‑formaat. XML‑output is handig wanneer u een tekstgebaseerde weergave nodig heeft om de presentatiestructuur te inspecteren, gegenereerde documenten te troubleshooten, output te vergelijken in geautomatiseerde tests, of te integreren met een workflow die XML consumeert in plaats van een presentatiepakket.

Gebruik de [Presentation.save](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/save/) methode met de `XML`‑waarde van de [SaveFormat](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/saveformat/) enumeratie. U kunt het resultaat rechtstreeks naar een bestand of naar een stream schrijven.

{{% alert color="info" title="Opmerking" %}}

`SaveFormat.XML` maakt een PowerPoint XML Presentation. Het extraheert niet de individuele Office Open XML‑onderdelen die opgeslagen zijn in een PPTX‑pakket. Als u de exacte PPTX‑pakketonderdelen nodig hebt, zoals `ppt/presentation.xml` of individuele dia‑XML‑bestanden, inspecteer dan het PPTX‑pakket zelf.

{{% /alert %}}

## **Een presentatie naar een XML‑bestand converteren**

Laad een bronpresentatie met de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)‑klasse en geef vervolgens het uitvoerpad en `SaveFormat.XML` door aan [Presentation.save](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/save/). De bron kan elk presentatiefomaat zijn dat ondersteund wordt voor laden, zoals PPT, PPTX of ODP.

Het volgende voorbeeld converteert een PPTX‑presentatie naar een XML‑bestand:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.xml", slides.export.SaveFormat.XML)
```

## **De XML‑output naar een stream schrijven**

Gebruik de stream‑overload van [Presentation.save](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/save/) wanneer de XML in het geheugen moet blijven of moet worden doorgegeven aan een ander component, zoals een webservice, opslagprovider, of XML‑verwerkingspipeline. Het volgende voorbeeld schrijft het resultaat naar een [BytesIO](https://docs.python.org/3/library/io.html#io.BytesIO)‑stream en rewindt deze voor later lezen:

```py
from io import BytesIO

import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    xml_stream = BytesIO()
    presentation.save(xml_stream, slides.export.SaveFormat.XML)
    xml_stream.seek(0)

    # Geef xml_stream door aan het volgende component in de workflow.
```

## **XML vergelijken met presentatie‑ en exportformaten**

Kies het uitvoerformaat op basis van hoe het resultaat zal worden gebruikt:

| Formaat | Output | Typisch gebruik |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | Een PowerPoint XML‑presentatie | Structuur inspecteren, troubleshooten, gegenereerde output vergelijken, en XML‑gebaseerde integratie |
| PPT (`.ppt`) | Een ouder binair presentiebestand | Compatibiliteit met oudere PowerPoint‑workflows |
| PPTX (`.pptx`) | Een Office Open XML‑pakket dat meerdere onderdelen bevat | Reguliere PowerPoint‑bewerking en presentatiewisseling |
| PDF of TIFF | Vaste‑layout pagina’s of een meer‑pagina afbeelding | Bekijken, afdrukken en archiveren |
| PNG, JPEG of SVG | Een gerenderde weergave van een individuele dia | Miniatuur‑afbeeldingen, voorbeeldweergaven en beeld‑assets |
| HTML of HTML5 | Webgerichte presentatie‑output | Weergave in browsers en webpublicatie |

In tegenstelling tot PPT en PPTX is XML‑output primair bedoeld voor inspectie en data‑georiënteerde workflows. In tegenstelling tot PDF, TIFF, HTML en dia‑afbeeldingsformaten vertegenwoordigt het presentatiedata in plaats van dia’s als pagina’s of visuele assets te renderen. De [supported file formats](/slides/nl/python-net/supported-file-formats/)‑tabel vermeldt PowerPoint XML Presentation als een alleen‑opslaan‑formaat; gebruik het dus niet wanneer een workflow het geëxporteerde bestand moet herladen in Aspose.Slides voor verdere bewerking.

## **FAQ**

**Is `SaveFormat.XML` hetzelfde als het opslaan van een PPTX‑bestand?**

Nee. PPTX is een pakket dat meerdere Office Open XML‑onderdelen bevat, terwijl `SaveFormat.XML` een PowerPoint XML Presentation‑bestand aanmaakt.

**Kan ik de XML‑output opslaan zonder een bestand op schijf te maken?**

Ja. Geef een beschrijfbare stream door aan [Presentation.save](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/save/). Gebruik bijvoorbeeld een [BytesIO](https://docs.python.org/3/library/io.html#io.BytesIO)‑stream voor verwerking in het geheugen.

**Kan Aspose.Slides het geëxporteerde XML‑bestand opnieuw laden?**

Nee. PowerPoint XML Presentation wordt momenteel alleen ondersteund voor opslaan, niet voor laden. Gebruik PPTX of een ander ondersteund presentatiefomaat wanneer round‑trip bewerking vereist is.

**Rendert de XML‑conversie elke dia als een pagina of afbeelding?**

Nee. XML‑conversie schrijft gestructureerde presentatiedata. Gebruik PDF of TIFF voor paginageoriënteerde output, of PNG, JPEG en SVG voor individuele dia‑afbeeldingen.