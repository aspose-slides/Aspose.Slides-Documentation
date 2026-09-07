---
title: PowerPoint-presentaties converteren naar XML in Python via Java
linktitle: PowerPoint naar XML
type: docs
weight: 145
url: /nl/python-java/convert-powerpoint-to-xml/
keywords:
- PowerPoint converteren naar XML
- presentatie converteren naar XML
- PPT naar XML
- PPTX naar XML
- ODP naar XML
- PowerPoint XML-presentatie
- SaveFormat.Xml
- presentatie opslaan als XML
- presentatie exporteren naar XML
- XML-stream
- Python
- Java
- Aspose.Slides
description: "PowerPoint- en OpenDocument-presentaties converteren naar PowerPoint XML-bestanden of -streams in Python via Java met Aspose.Slides voor Python via Java."
---
## **Overzicht**

Aspose.Slides for Python via Java kan PowerPoint‑presentaties converteren naar het PowerPoint XML‑presentatieformaat. XML‑uitvoer is handig wanneer u een tekstgebaseerde weergave nodig heeft om de structuur van een presentatie te inspecteren, gegenereerde documenten te troubleshooten, uitvoer te vergelijken in geautomatiseerde tests, of te integreren met een workflow die XML consumeert in plaats van een presentatiepakket.

Gebruik de [Presentation.save](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/#save)‑methode met de [Xml](https://reference.aspose.com/slides/nl/python-java/aspose.slides/saveformat/#Xml)‑waarde uit de [SaveFormat](https://reference.aspose.com/slides/nl/python-java/aspose.slides/saveformat/)‑klasse. U kunt het resultaat direct naar een bestand of naar een stream schrijven.

{{% alert color="info" title="Opmerking" %}}
[SaveFormat.Xml](https://reference.aspose.com/slides/nl/python-java/aspose.slides/saveformat/#Xml) maakt een PowerPoint XML‑presentatie. Het haalt de individuele Office Open XML‑onderdelen die in een PPTX‑pakket zijn opgeslagen niet eruit. Als u de exacte PPTX‑pakketonderdelen nodig heeft, zoals `ppt/presentation.xml` of individuele dia‑XML‑bestanden, inspecteer dan het PPTX‑pakket zelf.
{{% /alert %}}

## **Een presentatie converteren naar een XML‑bestand**

Laad een bronpresentatie met de [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/)‑klasse en geef vervolgens het uitvoerpad en [SaveFormat.Xml](https://reference.aspose.com/slides/nl/python-java/aspose.slides/saveformat/#Xml) door aan [Presentation.save](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/#save). De bron kan elk presentatieformaat zijn dat ondersteund wordt voor laden, zoals PPT, PPTX of ODP.

Het volgende voorbeeld converteert een PPTX‑presentatie naar een XML‑bestand:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation.xml", SaveFormat.Xml)
finally:
    presentation.dispose()
```

## **XML‑uitvoer naar een stream schrijven**

Gebruik de stream‑overload van [Presentation.save](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/#save) wanneer de XML in het geheugen moet blijven of moet worden doorgegeven aan een ander component, zoals een webservice, opslagprovider of XML‑verwerkingspipeline. Het volgende voorbeeld schrijft het resultaat naar een [ByteArrayOutputStream](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/io/ByteArrayOutputStream.html) en verkrijgt de resulterende XML als een Python‑bytes‑object:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

presentation = Presentation("presentation.pptx")
try:
    xml_stream = ByteArrayOutputStream()
    try:
        presentation.save(xml_stream, SaveFormat.Xml)
        java_bytes = xml_stream.toByteArray()
        xml_data = bytes(java_bytes)

        # Geef xml_data door aan de volgende component in de workflow.
    finally:
        xml_stream.close()
finally:
    presentation.dispose()
```

## **XML vergelijken met presentatie‑ en exportformaten**

Kies het uitvoerformaat op basis van hoe het resultaat zal worden gebruikt:

| Formaat | Uitvoer | Typisch gebruik |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | Een PowerPoint XML‑presentatie | Structuur inspecteren, troubleshooten, gegenereerde uitvoer vergelijken, en XML‑gebaseerde integratie |
| PPT (`.ppt`) | Een legacy binair presentatiebestand | Compatibiliteit met oudere PowerPoint‑workflows |
| PPTX (`.pptx`) | Een Office Open XML‑pakket met meerdere onderdelen | Standaard PowerPoint‑bewerking en presentatiewisseling |
| PDF or TIFF | Pagina's met vaste lay-out of een meerpagina‑afbeelding | Bekijken, afdrukken en archiveren |
| PNG, JPEG, or SVG | Een gerenderde weergave van een enkele dia | Miniaturen, voorbeeldweergaven en beeldbestanden |
| HTML or HTML5 | Webgerichte presentatie‑output | Weergave in browsers en webpublicatie |

In tegenstelling tot PPT en PPTX is XML‑uitvoer primair bedoeld voor inspectie en data‑georiënteerde workflows. In tegenstelling tot PDF, TIFF, HTML en dia‑afbeeldingsformaten vertegenwoordigt het presentatie‑data in plaats van dia's te renderen als pagina's of visuele assets. De tabel met [ondersteunde bestandsformaten](/slides/nl/python-java/supported-file-formats/) vermeldt PowerPoint XML‑presentatie als een alleen‑opslaan‑formaat, dus gebruik het niet wanneer een workflow het geëxporteerde bestand moet laden in Aspose.Slides voor verdere bewerking.

## **Veelgestelde vragen**

**Is XML‑export hetzelfde als het opslaan van een PPTX‑bestand?**

Nee. PPTX is een pakket dat meerdere Office Open XML‑onderdelen bevat, terwijl [SaveFormat.Xml](https://reference.aspose.com/slides/nl/python-java/aspose.slides/saveformat/#Xml) een PowerPoint XML‑presentatie‑bestand maakt.

**Kan ik de XML‑uitvoer opslaan zonder een bestand op schijf te creëren?**

Ja. Geef een schrijfbare Java‑output‑stream door aan [Presentation.save](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/#save). Gebruik bijvoorbeeld een [ByteArrayOutputStream](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/io/ByteArrayOutputStream.html) voor verwerking in het geheugen.

**Kan Aspose.Slides het geëxporteerde XML‑bestand opnieuw laden?**

Nee. PowerPoint XML‑presentatie wordt momenteel alleen ondersteund voor opslaan, niet voor laden. Gebruik PPTX of een ander ondersteund presentatiefomaat wanneer round‑trip bewerking vereist is.

**Renderen XML‑conversies elke dia als een pagina of afbeelding?**

Nee. XML‑conversie schrijft gestructureerde presentatiedata. Gebruik PDF of TIFF voor paginageoriënteerde uitvoer, of PNG, JPEG en SVG voor individuele dia‑afbeeldingen.