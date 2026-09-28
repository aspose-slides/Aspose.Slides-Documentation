---
title: Konvertera PowerPoint-presentationer till XML i .NET
linktitle: PowerPoint till XML
type: docs
weight: 145
url: /sv/net/convert-powerpoint-to-xml/
keywords:
- konvertera PowerPoint till XML
- konvertera presentation till XML
- PPT till XML
- PPTX till XML
- ODP till XML
- PowerPoint XML-presentation
- SaveFormat.Xml
- spara presentation som XML
- exportera presentation till XML
- XML-ström
- .NET
- C#
- Aspose.Slides
description: "Konvertera PowerPoint- och OpenDocument-presentationer till PowerPoint XML-filer eller strömmar i C# med Aspose.Slides för .NET."
---
## **Översikt**

Aspose.Slides för .NET kan konvertera PowerPoint-presentationer till PowerPoint XML‑presentationsformatet. XML‑utdata är användbart när du behöver en textbaserad representation för att inspektera presentationsstruktur, felsöka genererade dokument, jämföra utdata i automatiserade tester eller integrera med ett arbetsflöde som använder XML istället för ett presentationspaket.

Använd metoden [Presentation.Save](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/save/) med värdet `Xml` från uppräkningen [SaveFormat](https://reference.aspose.com/slides/sv/net/aspose.slides.export/saveformat/). Du kan skriva resultatet direkt till en fil eller till en ström.

{{% alert color="info" title="Obs" %}}

`SaveFormat.Xml` skapar en PowerPoint XML‑presentation. Den extraherar inte de enskilda Office Open XML‑delarna som lagras i ett PPTX‑paket. Om du behöver de exakta PPTX‑paketdelarna, till exempel `ppt/presentation.xml` eller enskilda slide‑XML‑filer, inspektera själva PPTX‑paketet.

{{% /alert %}}

## **Konvertera en presentation till en XML‑fil**

Läs in en källpresentation med klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/) och skicka sedan utvägsökvägen och `SaveFormat.Xml` till [Presentation.Save](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/save/). Källan kan vara vilket presentationsformat som helst som stöds för inläsning, såsom PPT, PPTX eller ODP.

Följande exempel konverterar en PPTX‑presentation till en XML‑fil:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
presentation.Save("presentation.xml", SaveFormat.Xml);
```

## **Skriv XML‑utdata till en ström**

Använd ström‑överladdningen av [Presentation.Save](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/save/) när XML måste förbli i minnet eller skickas till en annan komponent, såsom en webbtjänst, lagringsleverantör eller XML‑bearbetningspipeline. Följande exempel skriver resultatet till en [MemoryStream](https://learn.microsoft.com/en-us/dotnet/api/system.io.memorystream?view=net-10.0) och spolar tillbaka den för efterföljande läsning:

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
using var xmlStream = new MemoryStream();

presentation.Save(xmlStream, SaveFormat.Xml);
xmlStream.Position = 0;

// Skicka xmlStream till nästa komponent i arbetsflödet.
```

## **Jämför XML med presentations‑ och exportformat**

Välj utdataformat utifrån hur resultatet ska användas:

| Format | Utdata | Typisk användning |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | En PowerPoint XML‑presentation | Inspektion av struktur, felsökning, jämförelse av genererad utdata och XML‑baserad integration |
| PPT (`.ppt`) | En äldre binär presentationsfil | Kompatibilitet med äldre PowerPoint‑arbetsflöden |
| PPTX (`.pptx`) | Ett Office Open XML‑paket som innehåller flera delar | Vanlig PowerPoint‑redigering och presentationsutbyte |
| PDF eller TIFF | Sidor med fast layout eller TIFF‑bilder | Visning, utskrift och arkivering |
| PNG, JPEG eller SVG | En renderad representation av en enskild bild | Miniatyrer, förhandsgranskningar och bildresurser |
| HTML eller HTML5 | Webborienterad presentationsutdata | Visning i webbläsare och webbpublicering |

Till skillnad från PPT och PPTX är XML‑utdata främst avsedd för inspektion och dataorienterade arbetsflöden. Till skillnad från PDF, TIFF, HTML och bildformat för bilder representerar den presentationsdata snarare än att rendera bilder som sidor eller visuella resurser. Tabellen [supported file formats](/slides/sv/net/supported-file-formats/) listar alla format som Aspose.Slides kan läsa, importera, spara eller rendera.

## **Vanliga frågor**

**Är `SaveFormat.Xml` samma som att spara en PPTX‑fil?**

Nej. PPTX är ett paket som innehåller flera Office Open XML‑delar, medan `SaveFormat.Xml` skapar en PowerPoint XML‑presentationfil.

**Kan jag spara XML‑utdata utan att skapa en fil på disk?**

Ja. Skicka en skrivbar ström till [Presentation.Save](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/save/). Till exempel kan du använda en [MemoryStream](https://learn.microsoft.com/en-us/dotnet/api/system.io.memorystream?view=net-10.0) för in‑minnesbearbetning.

**Kan Aspose.Slides läsa in den exporterade XML‑filen igen?**

Ja. Skicka XML‑filen eller en ström till [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/presentation/)‑konstruktören. [Presentation.SourceFormat](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/sourceformat/) återger sedan `SourceFormat.Xml`. [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/sv/net/aspose.slides/presentationfactory/getpresentationinfo/) rapporterar `LoadFormat.Unknown` för detta format, så använd det inte för att avgöra om en XML‑fil kan öppnas.

**Renderar XML‑konvertering varje bild som en sida eller bild?**

Nej. XML‑konvertering skriver strukturerad presentationsdata. Använd PDF eller TIFF för sidorienterad utdata, eller PNG, JPEG och SVG för enskilda bild‑bilder.