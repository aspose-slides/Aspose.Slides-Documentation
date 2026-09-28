---
title: PowerPoint-presentaties converteren naar XML in .NET
linktitle: PowerPoint naar XML
type: docs
weight: 145
url: /nl/net/convert-powerpoint-to-xml/
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
- .NET
- C#
- Aspose.Slides
description: "Converteer PowerPoint- en OpenDocument-presentaties naar PowerPoint XML-bestanden of -streams in C# met Aspose.Slides voor .NET."
---
## **Overzicht**

Aspose.Slides voor .NET kan PowerPoint‑presentaties converteren naar het PowerPoint XML‑presentatieformaat. XML‑output is handig wanneer u een tekstgebaseerde representatie nodig heeft om de presentatiestructuur te inspecteren, gegenereerde documenten te troubleshooten, output te vergelijken in geautomatiseerde tests, of te integreren met een workflow die XML consumeert in plaats van een presentatiedossier.

Gebruik de [Presentation.Save](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/save/)‑methode met de `Xml`‑waarde uit de [SaveFormat](https://reference.aspose.com/slides/nl/net/aspose.slides.export/saveformat/)-enumeratie. U kunt het resultaat rechtstreeks naar een bestand of naar een stream schrijven.

{{% alert color="info" title="Note" %}}

`SaveFormat.Xml` maakt een PowerPoint XML‑presentatie aan. Het extraheert niet de afzonderlijke Office Open XML‑onderdelen die in een PPTX‑pakket zijn opgeslagen. Als u de exacte PPTX‑pakketonderdelen nodig heeft, zoals `ppt/presentation.xml` of individuele dia‑XML‑bestanden, inspecteer dan het PPTX‑pakket zelf.

{{% /alert %}}

## **Converteer een presentatie naar een XML‑bestand**

Laad een bronpresentatie met de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/)‑klasse en geef vervolgens het uitvoerpad en `SaveFormat.Xml` mee aan [Presentation.Save](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/save/). De bron kan elk presentatie‑formaat zijn dat ondersteund wordt voor laden, zoals PPT, PPTX of ODP.

Het volgende voorbeeld converteert een PPTX‑presentatie naar een XML‑bestand:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
presentation.Save("presentation.xml", SaveFormat.Xml);
```

## **Schrijf de XML‑output naar een stream**

Gebruik de stream‑overload van [Presentation.Save](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/save/) wanneer de XML in het geheugen moet blijven of moet worden doorgegeven aan een andere component, zoals een webservice, opslagprovider of XML‑verwerkingspipeline. Het volgende voorbeeld schrijft het resultaat naar een [MemoryStream](https://learn.microsoft.com/en-us/dotnet/api/system.io.memorystream?view=net-10.0) en zet de positie terug voor later lezen:

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
using var xmlStream = new MemoryStream();

presentation.Save(xmlStream, SaveFormat.Xml);
xmlStream.Position = 0;

// Geef xmlStream door aan de volgende component in de workflow.
```

## **Vergelijk XML met presentatie‑ en exportformaten**

Kies het uitvoerformaat op basis van hoe het resultaat zal worden gebruikt:

| Formaat | Output | Typisch gebruik |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | Een PowerPoint‑XML‑presentatie | Inspectie van de structuur, probleemoplossing, vergelijking van gegenereerde output en XML‑gebaseerde integratie |
| PPT (`.ppt`) | Een legacy binair presentatiedossier | Compatibiliteit met oudere PowerPoint‑workflows |
| PPTX (`.pptx`) | Een Office Open XML‑pakket met meerdere onderdelen | Normaal bewerken van PowerPoint‑presentaties en uitwisseling van presentaties |
| PDF of TIFF | Vaste‑layout pagina's of TIFF‑afbeeldingen | Weergeven, afdrukken en archiveren |
| PNG, JPEG of SVG | Een gerenderde weergave van een individuele dia | Miniaturen, voorbeeldweergaven en beeldbronnen |
| HTML of HTML5 | Web‑gerichte presentatie‑output | Weergave in browsers en webpublicatie |

In tegenstelling tot PPT en PPTX is XML‑output primair bedoeld voor inspectie en data‑gerichte workflows. In tegenstelling tot PDF, TIFF, HTML en dia‑afbeeldingsformaten representeert het presentatiedata in plaats van dia’s te renderen als pagina’s of visuele assets. De tabel met [ondersteunde bestandsformaten](/slides/nl/net/supported-file-formats/) geeft elk formaat weer dat Aspose.Slides kan laden, importeren, opslaan of renderen.

## **FAQ**

**Is `SaveFormat.Xml` hetzelfde als het opslaan van een PPTX‑bestand?**

Nee. PPTX is een pakket dat meerdere Office Open XML‑onderdelen bevat, terwijl `SaveFormat.Xml` een PowerPoint XML‑presentatie‑bestand aanmaakt.

**Kan ik de XML‑output opslaan zonder een bestand op schijf aan te maken?**

Ja. Geef een schrijfbare stream mee aan [Presentation.Save](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/save/). Gebruik bijvoorbeeld een [MemoryStream](https://learn.microsoft.com/en-us/dotnet/api/system.io.memorystream?view=net-10.0) voor verwerking in het geheugen.

**Kan Aspose.Slides het geëxporteerde XML‑bestand opnieuw laden?**

Ja. Geef het XML‑bestand of een stream mee aan de constructor van [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/presentation/). [Presentation.SourceFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/sourceformat/) geeft vervolgens `SourceFormat.Xml` terug. [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/nl/net/aspose.slides/presentationfactory/getpresentationinfo/) meldt `LoadFormat.Unknown` voor dit formaat, dus gebruik dit niet om te beslissen of een XML‑bestand geopend kan worden.

**Renderen XML‑conversies elke dia als een pagina of afbeelding?**

Nee. XML‑conversie schrijft gestructureerde presentatiedata. Gebruik PDF of TIFF voor paginageoriënteerde output, of PNG, JPEG en SVG voor afbeeldingen van afzonderlijke dia’s.