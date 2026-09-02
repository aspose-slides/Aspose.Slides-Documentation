---
title: Low-Code presentatiewerkzaamheden in .NET
linktitle: Low-Code API
type: docs
weight: 50
url: /nl/net/low-code-presentation-operations/
keywords:
- low-code presentaties API
- presentaties converteren
- presentaties samenvoegen
- dia's itereren
- vormen itereren
- tekst itereren
- vormen verzamelen
- presentatie comprimeren
- ongebruikte mastersdia's verwijderen
- ongebruikte lay-outdia's verwijderen
- ingebedde lettertypen comprimeren
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Gebruik de Aspose.Slides low-code API in .NET om presentaties te converteren en samen te voegen, door de inhoud te itereren, vormen te verzamelen en de presentatiegrootte te verkleinen."
---
## **Overzicht**

De [Aspose.Slides.LowCode](https://reference.aspose.com/slides/nl/net/aspose.slides.lowcode/) namespace biedt statische hulpklassen voor algemene presentatie‑bewerkingen. Deze helpers verpakken veelgebruikte object‑modelworkflows in gerichte methoden, zodat u bestanden kunt converteren of samenvoegen, presentatie‑elementen kunt verwerken, vormen kunt verzamelen en ongebruikte inhoud kunt verwijderen met minder code.

Low‑code helpers zijn het meest bruikbaar wanneer de bewerking van toepassing is op een volledig bestand of presentatie en de standaard workflow aan uw eisen voldoet. Gebruik het volledige [Aspose.Slides objectmodel](https://reference.aspose.com/slides/nl/net/aspose.slides/) wanneer u fijnmazige controle nodig heeft over individuele dia’s, masters, lay‑outs, vormen, exportinstellingen of relaties tussen presentatie‑elementen.

De onderstaande tabel geeft een overzicht van de beschikbare helpers:

| Helper | Gebruik voor |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/nl/net/aspose.slides.lowcode/convert/) | Een presentatie naar een ander formaat converteren met een directe bestand‑naar‑bestand‑aanroep. |
| [Merger](https://reference.aspose.com/slides/nl/net/aspose.slides.lowcode/merger/) | Volledige presentatiesamenvoeging van bestanden met hetzelfde formaat. |
| [ForEach](https://reference.aspose.com/slides/nl/net/aspose.slides.lowcode/foreach/) | Een actie uitvoeren voor elke dia, vorm, alinea of tekstgedeelte. |
| [Collect](https://reference.aspose.com/slides/nl/net/aspose.slides.lowcode/collect/) | Vormen ophalen uit de volledige presentatie voor herhaalde verwerking of analyse. |
| [Compress](https://reference.aspose.com/slides/nl/net/aspose.slides.lowcode/compress/) | Ongebruikte masters en lay‑outs verwijderen en ingesloten lettertype‑data reduceren. |

## **Presentatie converteren**

Gebruik [Convert.AutoByExtension](https://reference.aspose.com/slides/nl/net/aspose.slides.lowcode/convert/autobyextension/) wanneer de bestandsextensie van de uitvoer voldoende is om het exportformaat te bepalen. De methode opent de bronpresentatie, bepaalt het vereiste formaat op basis van het uitvoerpad en schrijft het resultaat.

```csharp
using Aspose.Slides.LowCode;

Convert.AutoByExtension("input.pptx", "output.pdf");
```

De [Convert](https://reference.aspose.com/slides/nl/net/aspose.slides.lowcode/convert/)‑klasse biedt ook speciale methoden voor PDF, SVG, JPEG, PNG en TIFF uitvoer. Gebruik het volledige objectmodel wanneer u de presentatie moet inspecteren of aanpassen vóór export, of wanneer u een exportoptie moet configureren die niet beschikbaar is via de helper. Zie [Convert Presentation](/slides/nl/net/convert-presentation/) voor formaat‑specifieke workflows en opties.

## **Presentaties samenvoegen**

Gebruik [Merger.Process](https://reference.aspose.com/slides/nl/net/aspose.slides.lowcode/merger/process/) om volledige presentaties met één oproep samen te voegen. De invoer‑presentaties moeten hetzelfde bestandsformaat hebben.

```csharp
using Aspose.Slides.LowCode;

var inputFiles = new[] { "part-1.pptx", "part-2.pptx" };
Merger.Process(inputFiles, "merged.pptx");
```

De helper is geschikt wanneer alle dia’s aan één resultaat moeten worden toegevoegd zonder dat ze individueel geselecteerd of opnieuw gemapt moeten worden. Gebruik het volledige objectmodel wanneer u geselecteerde dia’s moet samenvoegen, een bestemmings‑master of lay‑out moet toepassen, secties expliciet moet behouden, of verschillende dia‑groottes moet harmoniseren. Zie [Merge Presentations](/slides/nl/net/merge-presentation/) voor die scenario’s.

## **Door presentatie‑elementen itereren**

De [ForEach](https://reference.aspose.com/slides/nl/net/aspose.slides.lowcode/foreach/)‑klasse roept een terugbel‑functie aan voor elk gevraagd type presentatie‑element. Het voorkomt geneste verzamelings‑lussen en is handig voor inspectie of formatteringswijzigingen op presentatieniveau.

Het volgende voorbeeld gebruikt [ForEach.Slide](https://reference.aspose.com/slides/nl/net/aspose.slides.lowcode/foreach/slide/), [ForEach.Shape](https://reference.aspose.com/slides/nl/net/aspose.slides.lowcode/foreach/shape/), [ForEach.Paragraph](https://reference.aspose.com/slides/nl/net/aspose.slides.lowcode/foreach/paragraph/) en [ForEach.Portion](https://reference.aspose.com/slides/nl/net/aspose.slides.lowcode/foreach/portion/) om de overeenkomstige elementen te inspecteren:

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

Standaard omvat de traversering van vormen en tekst over de gehele presentatie normale, master‑ en lay‑outdia’s. Overloads met een `includeNotes`‑parameter kunnen ook notitiedia’s verwerken. Gebruik directe verzamelings‑lussen wanneer de volgorde van traversering, vroegtijdig afbreken, filteren vóór de terugbel‑aanroep of gedetailleerde ouder‑kind‑controle belangrijk is.

## **Vormen verzamelen**

Gebruik [Collect.Shapes](https://reference.aspose.com/slides/nl/net/aspose.slides.lowcode/collect/shapes/) wanneer u een verzameling van alle vormen in een presentatie nodig heeft in plaats van een terugbel‑functie voor elke vorm. Dit is nuttig wanneer dezelfde set later gefilterd, geteld of meerdere keren verwerkt moet worden.

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

Gebruik [ForEach.Shape](https://reference.aspose.com/slides/nl/net/aspose.slides.lowcode/foreach/shape/) in plaats daarvan wanneer elke vorm direct kan worden verwerkt en u de verzamelde resultaten niet hoeft te behouden.

## **Presentatie‑inhoud comprimeren**

De [Compress](https://reference.aspose.com/slides/nl/net/aspose.slides.lowcode/compress/)‑klasse kan ongebruikte structurele elementen verwijderen en ingesloten lettertype‑data reduceren:

- [Compress.RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/nl/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) verwijdert lay‑outdia’s die door geen enkele normale dia worden gerefereerd.
- [Compress.RemoveUnusedMasterSlides](https://reference.aspose.com/slides/nl/net/aspose.slides.lowcode/compress/removeunusedmasterslides/) verwijdert masters die niet langer in gebruik zijn.
- [Compress.CompressEmbeddedFonts](https://reference.aspose.com/slides/nl/net/aspose.slides.lowcode/compress/compressembeddedfonts/) verwijdert ongebruikte tekens uit ingesloten lettertypes.

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

Verwijder eerst ongebruikte lay‑outs voordat u ongebruikte masters verwijdert, zodat een master die na het opschonen van lay‑outs niet meer wordt gerefereerd eveneens kan worden verwijderd. Sla de geoptimaliseerde presentatie op in een nieuw bestand als u later de oorspronkelijke masters, lay‑outs of volledige ingesloten lettertype‑data nodig heeft. Voor meer details, zie [Slide Master](/slides/nl/net/slide-master/) en [Embedded Font](/slides/nl/net/embedded-font/).

## **Veelgestelde vragen**

**Wanneer moet ik de low‑code‑API gebruiken in plaats van het volledige objectmodel?**

Gebruik low‑code helpers wanneer een standaardbewerking van toepassing is op een compleet bestand of presentatie en geen gedetailleerde controle over individuele elementen vereist. Gebruik het volledige objectmodel wanneer u specifieke dia’s moet selecteren, relaties tussen master en lay‑out moet beheersen, de tussentijdse status moet inspecteren, of gedrag moet configureren dat de helper niet blootlegt.

**Kan Merger presentaties combineren met verschillende bestandsformaten?**

Nee. [Merger.Process](https://reference.aspose.com/slides/nl/net/aspose.slides.lowcode/merger/process/) vereist invoer‑presentaties in hetzelfde formaat. Converteer de invoer‑bestanden eerst naar een gemeenschappelijk formaat, bijvoorbeeld met [Convert.AutoByExtension](https://reference.aspose.com/slides/nl/net/aspose.slides.lowcode/convert/autobyextension/), en voeg vervolgens de geconverteerde bestanden samen.

**Verwerkt ForEach master‑, lay‑out‑ en notitiedia’s?**

[ForEach.Slide](https://reference.aspose.com/slides/nl/net/aspose.slides.lowcode/foreach/slide/) doorloopt normale presentatiedia’s. De presentatie‑brede [ForEach.Shape](https://reference.aspose.com/slides/nl/net/aspose.slides.lowcode/foreach/shape/), [ForEach.Paragraph](https://reference.aspose.com/slides/nl/net/aspose.slides.lowcode/foreach/paragraph/) en [ForEach.Portion](https://reference.aspose.com/slides/nl/net/aspose.slides.lowcode/foreach/portion/) operaties omvatten standaard normale, master‑ en lay‑outdia’s. Gebruik hun overloads met `includeNotes` op `true` om notitiedia’s op te nemen.

**Wat is het verschil tussen ForEach.Shape en Collect.Shapes?**

Gebruik [ForEach.Shape](https://reference.aspose.com/slides/nl/net/aspose.slides.lowcode/foreach/shape/) om elke vorm direct via een terugbel‑functie te verwerken. Gebruik [Collect.Shapes](https://reference.aspose.com/slides/nl/net/aspose.slides.lowcode/collect/shapes/) wanneer u een dooriterbare verzameling nodig heeft die u later kunt behouden, filteren, tellen of meerdere keren kunt doorlopen.

**Maakt Compress altijd de presentatiedatei kleiner?**

Niet noodzakelijk. Het resultaat hangt af van of de presentatie ongebruikte lay‑outs, ongebruikte masters of ingesloten lettertypes met ongebruikte tekens bevat. Als geen van deze aanwezig is, zullen de betreffende [Compress](https://reference.aspose.com/slides/nl/net/aspose.slides.lowcode/compress/)‑operaties de bestandsgrootte mogelijk niet verkleinen.

**Worden wijzigingen die door ForEach of Compress worden aangebracht automatisch opgeslagen?**

Nee. Deze helpers werken op het geladen [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/) object in het geheugen. Nadat u elementen hebt gewijzigd in een [ForEach](https://reference.aspose.com/slides/nl/net/aspose.slides.lowcode/foreach/) terugbel‑functie of [Compress](https://reference.aspose.com/slides/nl/net/aspose.slides.lowcode/compress/) hebt uitgevoerd, roept u [Presentation.Save](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/save/) aan om het resultaat weg te schrijven.

## **Gerelateerde artikelen**

- [Convert Presentation](/slides/nl/net/convert-presentation/)
- [Merge Presentations](/slides/nl/net/merge-presentation/)
- [Slide Master](/slides/nl/net/slide-master/)
- [Manage Text Box](/slides/nl/net/manage-textbox/)
- [Embedded Font](/slides/nl/net/embedded-font/)