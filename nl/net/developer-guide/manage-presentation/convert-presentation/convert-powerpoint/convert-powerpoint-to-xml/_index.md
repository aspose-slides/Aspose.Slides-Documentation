---
title: PowerPoint‑presentaties omzetten naar XML in .NET
linktitle: PowerPoint naar XML
type: docs
weight: 145
url: /nl/net/convert-powerpoint-to-xml/
keywords:
- PowerPoint omzetten naar XML
- presentatie omzetten naar XML
- PPT naar XML
- PPTX naar XML
- ODP naar XML
- PowerPoint XML‑presentatie
- SaveFormat.Xml
- presentatie opslaan als XML
- presentatie exporteren naar XML
- XML‑stroom
- .NET
- C#
- Aspose.Slides
description: "PowerPoint‑ en OpenDocument‑presentaties omzetten naar PowerPoint‑XML‑bestanden of -streams in C# met Aspose.Slides voor .NET."
---
## **Overzicht**

Aspose.Slides for .NET kan PowerPoint‑presentaties converteren naar het PowerPoint XML‑presentatieformaat. XML‑output is handig wanneer u een tekstgebaseerde weergave nodig hebt om de presentatiestructuur te inspecteren, gegenereerde documenten te troubleshooten, output te vergelijken in geautomatiseerde tests, of te integreren met een workflow die XML consumeert in plaats van een presentatie‑pakket.

Gebruik de [Presentation.Save](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/save/)‑methode met de `Xml`‑waarde uit de [SaveFormat](https://reference.aspose.com/slides/nl/net/aspose.slides.export/saveformat/)‑enumeratie. U kunt het resultaat direct naar een bestand of naar een stream schrijven.

{{% alert color="info" title="Note" %}}
`SaveFormat.Xml` maakt een PowerPoint XML‑presentatie. Het haalt niet de afzonderlijke Office Open XML‑onderdelen uit een PPTX‑pakket. Als u de exacte PPTX‑pakketonderdelen nodig hebt, zoals `ppt/presentation.xml` of individuele dia‑XML‑bestanden, inspecteer dan het PPTX‑pakket zelf.
{{% /alert %}}

## **Een presentatie converteren naar een XML‑bestand**

Laad een bronpresentatie met de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/)‑klasse en geef vervolgens het uitvoerpad en `SaveFormat.Xml` door aan [Presentation.Save](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/save/). De bron kan elk presentatiesformaat zijn dat wordt ondersteund voor laden, zoals PPT, PPTX of ODP.

Het volgende voorbeeld converteert een PPTX‑presentatie naar een XML‑bestand:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
presentation.Save("presentation.xml", SaveFormat.Xml);
```

## **De XML‑output naar een stream schrijven**

Gebruik de stream‑overload van [Presentation.Save](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/save/) wanneer de XML in het geheugen moet blijven of moet worden doorgegeven aan een ander component, zoals een webservice, opslagprovider of XML‑verwerkingspipeline. Het volgende voorbeeld schrijft het resultaat naar een [MemoryStream](https://learn.microsoft.com/en-us/dotnet/api/system.io.memorystream) en zet het terug naar het begin voor later lezen:

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
using var xmlStream = new MemoryStream();

presentation.Save(xmlStream, SaveFormat.Xml);
xmlStream.Position = 0;

// Stuur xmlStream door naar de volgende component in de workflow.
```

## **XML vergelijken met presentatie‑ en exportformaten**

Kies het uitvoerformaat op basis van hoe het resultaat zal worden gebruikt:

| Formaat | Output | Typisch gebruik |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | Een PowerPoint XML‑presentatie | Inspectie van de structuur, probleemoplossing, vergelijking van gegenereerde output en XML‑gebaseerde integratie |
| PPT (`.ppt`) | Een legacy binair presentatiedocument | Compatibiliteit met oudere PowerPoint‑workflows |
| PPTX (`.pptx`) | Een Office Open XML‑pakket met meerdere onderdelen | Regulier bewerken en uitwisselen van PowerPoint‑presentaties |
| PDF or TIFF | Paginas met vaste lay‑out of een afbeelding met meerdere pagina's | Weergeven, afdrukken en archiveren |
| PNG, JPEG, or SVG | Een weergave van een individuele dia | Miniaturen, voorbeeldweergaven en beeldassets |
| HTML or HTML5 | Web‑gerichte presentatie‑output | Weergave in browsers en publicatie op het web |

In tegenstelling tot PPT en PPTX is XML‑output primair bedoeld voor inspectie en data‑georiënteerde workflows. In tegenstelling tot PDF, TIFF, HTML en dia‑afbeeldingsformaten vertegenwoordigt het presentatie‑data in plaats van dia’s als pagina’s of visuele assets weer te geven. De tabel met [supported file formats](/slides/nl/net/supported-file-formats/) vermeldt PowerPoint XML Presentation als een alleen‑opslaan‑formaat; gebruik het daarom niet wanneer een workflow het geëxporteerde bestand moet terugladen in Aspose.Slides voor verdere bewerking.

## **FAQ**

**Is `SaveFormat.Xml` hetzelfde als het opslaan van een PPTX‑bestand?**

Nee. PPTX is een pakket met meerdere Office Open XML‑onderdelen, terwijl `SaveFormat.Xml` een PowerPoint XML‑presentatiebestand maakt.

**Kan ik de XML‑output opslaan zonder een bestand op de schijf te maken?**

Ja. Geef een beschrijfbare stream door aan [Presentation.Save](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/save/). Gebruik bijvoorbeeld een [MemoryStream](https://learn.microsoft.com/en-us/dotnet/api/system.io.memorystream) voor verwerking in het geheugen.

**Kan Aspose.Slides het geëxporteerde XML‑bestand opnieuw laden?**

Nee. PowerPoint XML Presentation wordt momenteel alleen ondersteund voor opslaan, niet voor laden. Gebruik PPTX of een ander ondersteund presentatiesformaat wanneer round‑trip bewerking vereist is.

**Renderen XML‑conversies elke dia als een pagina of afbeelding?**

Nee. XML‑conversie schrijft gestructureerde presentatiedata. Gebruik PDF of TIFF voor paginageoriënteerde output, of PNG, JPEG en SVG voor individuele dia‑afbeeldingen.