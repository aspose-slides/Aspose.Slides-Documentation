---
title: Low-Code presentatiewerkzaamheden in .NET
linktitle: Low-Code API
type: docs
weight: 50
url: /nl/net/low-code-presentation-operations/
keywords:
- low-code presentatie-API
- presentatie converteren
- presentaties samenvoegen
- dia's doorlopen
- vormen doorlopen
- tekst doorlopen
- vormen verzamelen
- presentatie comprimeren
- ongebruikte masterdia's verwijderen
- ongebruikte lay-outdia's verwijderen
- ingesloten lettertypen comprimeren
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Gebruik de Aspose.Slides low-code API in .NET om presentaties te converteren en samen te voegen, door de inhoud te lopen, vormen te verzamelen en de grootte van de presentatie te verkleinen."
---
## **Overzicht**

De [Aspose.Slides.LowCode](https://reference.aspose.com/slides/nl/net/aspose.slides.lowcode/) namespace biedt statische hulpklassen voor veelvoorkomende presentatietaken. Deze helpers verpakken vaak gebruikte objectmodel‑workflows in gerichte methoden, zodat u bestanden kunt converteren of samenvoegen, presentatiestructuren kunt verwerken, vormen kunt verzamelen en ongebruikte inhoud kunt verwijderen met minder code.

Low-code helpers zijn het meest bruikbaar wanneer de bewerking van toepassing is op een heel bestand of een hele presentatie en de standaard workflow aan uw vereisten voldoet. Gebruik het volledige [Aspose.Slides object model](https://reference.aspose.com/slides/nl/net/aspose.slides/) wanneer u fijnmazige controle nodig heeft over individuele dia's, masters, lay‑outs, vormen, exportinstellingen of relaties tussen presentatie‑elementen.

De onderstaande tabel geeft een overzicht van de beschikbare helpers:

| Helper | Waarvoor te gebruiken |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/nl/net/aspose.slides.lowcode/convert/) | Een presentatie converteren naar een ander formaat met een directe bestands‑naar‑bestandsaanroep. |
| [Merger](https://reference.aspose.com/slides/nl/net/aspose.slides.lowcode/merger/) | Volledige presentatiebestanden van hetzelfde formaat combineren. |
| [ForEach](https://reference.aspose.com/slides/nl/net/aspose.slides.lowcode/foreach/) | Een actie uitvoeren voor elke dia, vorm, alinea of tekstdelen. |
| [Collect](https://reference.aspose.com/slides/nl/net/aspose.slides.lowcode/collect/) | Vormen ophalen uit de volledige presentatie voor herhaaldelijk verwerken of analyseren. |
| [Compress](https://reference.aspose.com/slides/nl/net/aspose.slides.lowcode/compress/) | Ongebruikte masters en lay‑outs verwijderen en ingesloten lettertype‑gegevens verkleinen. |

## **Een presentatie converteren**

Gebruik [Convert.AutoByExtension](https://reference.aspose.com/slides/nl/net/aspose.slides.lowcode/convert/autobyextension/) wanneer de bestands­extensie van het uitvoerbestand voldoende is om het exportformaat te bepalen. De methode opent de bronpresentatie, bepaalt het vereiste formaat aan de hand van het uitvoerpad en schrijft het resultaat.

```csharp
using Aspose.Slides.LowCode;

Convert.AutoByExtension("input.pptx", "output.pdf");
```

De [Convert](https://reference.aspose.com/slides/nl/net/aspose.slides.lowcode/convert/) klasse biedt ook specifieke methoden voor PDF-, SVG-, JPEG-, PNG- en TIFF‑uitvoer. Gebruik het volledige objectmodel wanneer u de presentatie moet inspecteren of wijzigen vóór het exporteren of een exportoptie moet configureren die niet beschikbaar is via de geselecteerde helper. Zie [Presentatie converteren](/net/convert-presentation/) voor format‑specifieke workflows en opties.

## **Presentaties samenvoegen**

Gebruik [Merger.Process](https://reference.aspose.com/slides/nl/net/aspose.slides.lowcode/merger/process/) om volledige presentatiebestanden met één aanroep te combineren. De invoerpresentaties moeten hetzelfde bestandsformaat hebben.

```csharp
using Aspose.Slides.LowCode;

var inputFiles = new[] { "part-1.pptx", "part-2.pptx" };
Merger.Process(inputFiles, "merged.pptx");
```

De helper is geschikt wanneer alle dia's moeten worden toegevoegd aan één resultaat zonder ze individueel te selecteren of opnieuw toe te wijzen. Gebruik het volledige objectmodel wanneer u geselecteerde dia's moet samenvoegen, een doeldia‑master of lay‑out wilt toepassen, secties expliciet wilt behouden of verschillende dia‑groottes moet combineren. Zie [Presentaties samenvoegen](/net/merge-presentation/) voor die scenario's.

## **Itereren door presentatie‑elementen**

De [ForEach](https://reference.aspose.com/slides/nl/net/aspose.slides.lowcode/foreach/) klasse roept een callback aan voor elk opgevraagd type presentatie‑element. Het voorkomt geneste collectielussen en is handig voor inspectie of opmaakwijzigingen over de hele presentatie.

Het onderstaande voorbeeld gebruikt [ForEach.Slide](https://reference.aspose.com/slides/nl/net/aspose.slides.lowcode/foreach/slide/), [ForEach.Shape](https://reference.aspose.com/slides/nl/net/aspose.slides.lowcode/foreach/shape/), [ForEach.Paragraph](https://reference.aspose.com/slides/nl/net/aspose.slides.lowcode/foreach/paragraph/), en [ForEach.Portion](https://reference.aspose.com/slides/nl/net/aspose.slides.lowcode/foreach/portion/) om de overeenkomstige elementen te inspecteren:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");

ForEach.Slide(presentation, (slide, index) =>
{
    Console.WriteLine($"Slide {index}: {slide.Shapes.Count} shapes");
});

ForEach.Shape(presentation, (shape, slide, index) =>
{
    Console.WriteLine($"Shape {index} on {slide.GetType().Name}: {shape.Name}");
});

ForEach.Paragraph(presentation, (paragraph, slide, index) =>
{
    Console.WriteLine($"Paragraph {index} on {slide.GetType().Name}: {paragraph.Text}");
});

ForEach.Portion(presentation, (portion, paragraph, slide, index) =>
{
    Console.WriteLine($"Portion {index} on {slide.GetType().Name}: {portion.Text}");
});
```

Standaard omvat traverseren van vormen en tekst over de hele presentatie normale, master‑ en lay‑out‑dia's. Overloads met een `includeNotes`‑parameter kunnen ook notitiedia's verwerken. Gebruik directe collectielussen wanneer de volgorde van traverseren, vroegtijdige beëindiging, filteren vóór de callback‑aanroep, of gedetailleerde ouder‑kind‑controle belangrijk is.

## **Vormen verzamelen**

Gebruik [Collect.Shapes](https://reference.aspose.com/slides/nl/net/aspose.slides.lowcode/collect/shapes/) wanneer u een verzameling van alle vormen in een presentatie nodig heeft in plaats van een callback voor elke vorm. Dit is nuttig wanneer dezelfde set vaker zal worden gefilterd, geteld of verwerkt.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");
var shapes = Collect.Shapes(presentation);

foreach (var shape in shapes)
{
    Console.WriteLine($"{shape.Name}: {shape.GetType().Name}");
}
```

Gebruik in plaats daarvan [ForEach.Shape](https://reference.aspose.com/slides/nl/net/aspose.slides.lowcode/foreach/shape/) wanneer elke vorm onmiddellijk kan worden verwerkt en u het verzamelde resultaat niet hoeft te behouden.

## **Presentatie‑inhoud comprimeren**

De [Compress](https://reference.aspose.com/slides/nl/net/aspose.slides.lowcode/compress/) klasse kan ongebruikte structurele elementen verwijderen en ingesloten lettertype‑gegevens verkleinen:

- [Compress.RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/nl/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) verwijdert lay‑out‑dia's waar geen normale dia naar verwijst.
- [Compress.RemoveUnusedMasterSlides](https://reference.aspose.com/slides/nl/net/aspose.slides.lowcode/compress/removeunusedmasterslides/) verwijdert master‑dia's die niet meer worden gebruikt.
- [Compress.CompressEmbeddedFonts](https://reference.aspose.com/slides/nl/net/aspose.slides.lowcode/compress/compressembeddedfonts/) verwijdert ongebruikte tekens uit ingesloten lettertypen.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");

Compress.RemoveUnusedLayoutSlides(presentation);
Compress.RemoveUnusedMasterSlides(presentation);
Compress.CompressEmbeddedFonts(presentation);

presentation.Save("compressed.pptx", SaveFormat.Pptx);
```

Verwijder ongebruikte lay-outs vóór ongebruikte masters, zodat een master die na het opruimen van de lay‑outs niet meer wordt verwezen, ook kan worden verwijderd. Sla de geoptimaliseerde presentatie op in een nieuw bestand als u later de originele masters, lay‑outs of volledige ingesloten lettertype‑gegevens nodig heeft. Voor meer details, zie [Slide‑master](/net/slide-master/) en [Ingesloten lettertype](/net/embedded-font/).

## **FAQ**

**Wanneer moet ik de low-code‑API gebruiken in plaats van het volledige objectmodel?**

Gebruik low-code helpers wanneer een standaardbewerking van toepassing is op een volledig bestand of een volledige presentatie en geen gedetailleerde controle over individuele elementen vereist. Gebruik het volledige objectmodel wanneer u specifieke dia's moet selecteren, de relaties tussen master‑ en lay‑out‑dia's moet beheersen, de tussenliggende status moet inspecteren, of gedrag moet configureren dat de helper niet blootstelt.

**Kan Merger presentaties combineren in verschillende bestandsformaten?**

Nee. [Merger.Process](https://reference.aspose.com/slides/nl/net/aspose.slides.lowcode/merger/process/) vereist dat de invoer‑presentaties hetzelfde formaat hebben. Converteer de invoerbestanden eerst naar een gemeenschappelijk formaat, bijvoorbeeld met [Convert.AutoByExtension](https://reference.aspose.com/slides/nl/net/aspose.slides.lowcode/convert/autobyextension/), en voeg vervolgens de geconverteerde bestanden samen.

**Verwerkt ForEach master‑, lay‑out‑ en notitiedia's?**

[ForEach.Slide](https://reference.aspose.com/slides/nl/net/aspose.slides.lowcode/foreach/slide/) doorloopt normale presentatiedia's. [ForEach.Shape](https://reference.aspose.com/slides/nl/net/aspose.slides.lowcode/foreach/shape/), [ForEach.Paragraph](https://reference.aspose.com/slides/nl/net/aspose.slides.lowcode/foreach/paragraph/) en [ForEach.Portion](https://reference.aspose.com/slides/nl/net/aspose.slides.lowcode/foreach/portion/) over de hele presentatie omvatten standaard normale, master‑ en lay‑out‑dia's. Gebruik hun overloads met `includeNotes` ingesteld op `true` om notitiedia's op te nemen.

**Wat is het verschil tussen ForEach.Shape en Collect.Shapes?**

Gebruik [ForEach.Shape](https://reference.aspose.com/slides/nl/net/aspose.slides.lowcode/foreach/shape/) om elke vorm onmiddellijk via een callback te verwerken. Gebruik [Collect.Shapes](https://reference.aspose.com/slides/nl/net/aspose.slides.lowcode/collect/shapes/) wanneer u een doorzoekbaar resultaat nodig heeft dat kan worden behouden, gefilterd, geteld of meerdere keren doorlopen.

**Maakt Compress altijd het presentatiebestand kleiner?**

Niet per se. Het resultaat hangt af van of de presentatie ongebruikte lay-outs, ongebruikte masters of ingesloten lettertypen met ongebruikte tekens bevat. Als geen van deze aanwezig is, kunnen de bijbehorende [Compress](https://reference.aspose.com/slides/nl/net/aspose.slides.lowcode/compress/)‑bewerkingen de bestandsgrootte mogelijk niet verkleinen.

**Worden wijzigingen gemaakt door ForEach of Compress automatisch opgeslagen?**

Nee. Deze helpers werken op het geladen [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/)‑object in het geheugen. Nadat u elementen hebt gewijzigd in een [ForEach](https://reference.aspose.com/slides/nl/net/aspose.slides.lowcode/foreach/)‑callback of [Compress](https://reference.aspose.com/slides/nl/net/aspose.slides.lowcode/compress/) hebt uitgevoerd, roept u [Presentation.Save](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/save/) aan om het resultaat op te slaan.

## **Gerelateerde artikelen**

- [Presentatie converteren](/net/convert-presentation/)
- [Presentaties samenvoegen](/net/merge-presentation/)
- [Slide‑master](/net/slide-master/)
- [Tekstvak beheren](/net/manage-textbox/)
- [Ingesloten lettertype](/net/embedded-font/)