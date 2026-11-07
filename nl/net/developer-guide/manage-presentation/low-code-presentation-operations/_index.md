---
title: Low-Code Presentatie‑operaties in .NET
linktitle: Low-Code API
type: docs
weight: 50
url: /nl/net/low-code-presentation-operations/
keywords:
- low-code presentaties API
- presentatie converteren
- presentaties samenvoegen
- dia's itereren
- shapes itereren
- tekst itereren
- shapes verzamelen
- presentatie comprimeren
- ongebruikte mastersdia's verwijderen
- ongebruikte lay-outdia's verwijderen
- ingesloten lettertypen comprimeren
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Gebruik de Aspose.Slides low-code API in .NET om presentaties te converteren en samen te voegen, door inhoud te itereren, shapes te verzamelen en de grootte van de presentatie te verkleinen."
---
## **Overzicht**

De [Aspose.Slides.LowCode](https://reference.aspose.com/slides/net/aspose.slides.lowcode/) namespace biedt statische hulpprogramma‑klassen voor gemeenschappelijke presentatie‑bewerkingen. Deze helpers wikkelen vaak gebruikte object‑model‑werkstromen in gerichte methoden, zodat je bestanden kunt converteren of samenvoegen, presentatie‑elementen kunt verwerken, shapes kunt verzamelen en ongebruikte content kunt verwijderen met minder code.

Low‑code helpers zijn het meest nuttig wanneer de bewerking van toepassing is op een heel bestand of presentatie en de standaard workflow voldoet aan je eisen. Gebruik het volledige [Aspose.Slides object model](https://reference.aspose.com/slides/net/aspose.slides/) wanneer je fijnmazige controle nodig hebt over individuele dia’s, masters, layouts, shapes, exportinstellingen of relaties tussen presentatie‑elementen.

De onderstaande tabel geeft een overzicht van de beschikbare helpers:

| Helper | Waarvoor gebruiken |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/net/aspose.slides.lowcode/convert/) | Een presentatie converteren naar een ander formaat met een directe bestand‑naar‑bestand‑aanroep. |
| [Merger](https://reference.aspose.com/slides/net/aspose.slides.lowcode/merger/) | Complete presentatie‑bestanden van hetzelfde formaat combineren. |
| [ForEach](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/) | Een actie uitvoeren voor elke dia, shape, alinea of tekstgedeelte. |
| [Collect](https://reference.aspose.com/slides/net/aspose.slides.lowcode/collect/) | Shapes ophalen uit de volledige presentatie voor herhaalde verwerking of analyse. |
| [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/) | Niet‑gebruikte masters/layouts verwijderen, ingesloten lettertype‑data verkleinen en afbeeldingen comprimeren. |

## **Een presentatie converteren**

Gebruik [Convert.AutoByExtension](https://reference.aspose.com/slides/net/aspose.slides.lowcode/convert/autobyextension/) wanneer de extensie van het uitvoerbestand voldoende is om het exportformaat te bepalen. De methode opent de bronpresentatie, bepaalt het vereiste formaat op basis van het uitvoerpad en schrijft het resultaat.

```csharp
using Aspose.Slides.LowCode;

Convert.AutoByExtension("input.pptx", "output.pdf");
```

De [Convert](https://reference.aspose.com/slides/net/aspose.slides.lowcode/convert/) klasse biedt ook specifieke methoden voor PDF, SVG, JPEG, PNG en TIFF uitvoer. Gebruik het volledige object model wanneer je de presentatie moet inspecteren of aanpassen vóór export of wanneer je een exportoptie moet configureren die niet wordt blootgesteld door de geselecteerde helper. Zie [Presentatie converteren](/slides/nl/net/convert-presentation/) voor formaat‑specifieke werkstromen en opties.

## **Presentaties samenvoegen**

Gebruik [Merger.Process](https://reference.aspose.com/slides/net/aspose.slides.lowcode/merger/process/) om volledige presentatie‑bestanden in één stap te combineren. De invoer‑presentaties moeten hetzelfde bestandsformaat hebben.

```csharp
using Aspose.Slides.LowCode;

var inputFiles = new[] { "part-1.pptx", "part-2.pptx" };
Merger.Process(inputFiles, "merged.pptx");
```

De helper is geschikt wanneer alle dia’s moeten worden toegevoegd aan één resultaat zonder ze individueel te selecteren of opnieuw toe te wijzen. Gebruik het volledige object model wanneer je geselecteerde dia’s moet samenvoegen, een bestemmings‑master of layout moet toepassen, secties expliciet moet behouden, of verschillende dia‑groottes moet harmoniseren. Zie [Presentaties samenvoegen](/slides/nl/net/merge-presentation/) voor die scenario’s.

## **Itereren over presentatie‑elementen**

De [ForEach](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/) klasse roept een callback aan voor elk aangevraagd type presentatie‑element. Het voorkomt geneste collectie‑lussen en is praktisch voor inspectie of opmaakwijzigingen over de hele presentatie.

Het volgende voorbeeld gebruikt [ForEach.Slide](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/slide/), [ForEach.Shape](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/shape/), [ForEach.Paragraph](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/paragraph/) en [ForEach.Portion](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/portion/) om de overeenkomstige elementen te inspecteren:

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

Standaard omvat de traversering van shapes en tekst over de hele presentatie normale, master‑ en layout‑dia’s. Overloads met een `includeNotes`‑parameter kunnen ook notitiedia’s verwerken. Gebruik directe collectie‑lussen wanneer de volgorde van traversering, vroegtijdig stoppen, filteren vóór callback‑aanroep of gedetailleerde ouder‑kind‑controle belangrijk is.

## **Shapes verzamelen**

Gebruik [Collect.Shapes](https://reference.aspose.com/slides/net/aspose.slides.lowcode/collect/shapes/) wanneer je een collectie van alle shapes in een presentatie nodig hebt in plaats van een callback voor elke shape. Dit is handig wanneer dezelfde verzameling meerdere keren gefilterd, geteld of verwerkt moet worden.

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

Gebruik in plaats daarvan [ForEach.Shape](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/shape/) wanneer elke shape direct kan worden afgehandeld en je de verzamelde resultaten niet hoeft te behouden.

## **Presentatie‑content comprimeren**

De [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/) klasse kan ongebruikte structurele elementen verwijderen en ingesloten lettertype‑data verkleinen:

- [Compress.RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) verwijdert layout‑dia’s die door geen enkele normale dia worden gerefereerd.
- [Compress.RemoveUnusedMasterSlides](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/removeunusedmasterslides/) verwijdert master‑dia’s die niet langer worden gebruikt.
- [Compress.CompressEmbeddedFonts](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compressembeddedfonts/) verwijdert ongebruikte tekens uit ingesloten lettertypen.

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

Verwijder ongebruikte layouts vóór ongebruikte masters zodat een master die na het opschonen van layouts ongerefereerd raakt ook verwijderd kan worden. Sla de geoptimaliseerde presentatie op in een nieuw bestand als je later de originele masters, layouts of volledige ingesloten lettertype‑data mogelijk nodig hebt. Voor meer details, zie [Slide Master](/slides/nl/net/slide-master/) en [Embedded Font](/slides/nl/net/embedded-font/).

### **De volledige presentatie comprimeren**

Aspose.Slides for .NET 26.11 voegt [Compress.CompressPresentation](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compresspresentation/) toe. Het combineert het verwijderen van ongebruikte layout/master‑dia’s, het reduceren van ingesloten lettertypen tot gebruikte tekens en afbeeldingcompressie op 150 DPI. Gebruik de individuele bewerkingen hierboven wanneer je controle wilt hebben over welke wijzigingen worden toegepast.

Installeer [Aspose.Slides for .NET](/slides/nl/net/installation/) 26.11 of later en lever `input.pptx`. Sla op naar een apart bestand: verwijderde layouts, lettertype‑tekens en bijgesneden afbeelding‑pixels kunnen later nodig zijn voor verdere bewerking.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");
Compress.CompressPresentation(presentation);
presentation.Save("compressed.pptx", SaveFormat.Pptx);
```

### **Afbeeldingen comprimeren op een gekozen resolutie**

Gebruik [Compress.CompressImages](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compressimages/) om in aanmerking komende afbeeldingen te verwerken zonder ook layouts te verwijderen of lettertypen te reduceren. Dit voorbeeld gebruikt 96 DPI; selecteer een andere [PicturesCompression](https://reference.aspose.com/slides/net/aspose.slides.export/picturescompression/) waarde voor je uitvoerbehoefte.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");
Compress.CompressImages(presentation, PicturesCompression.Dpi96);
presentation.Save("compressed-images.pptx", SaveFormat.Pptx);
```

Beide helpers gebruiken de volgende afbeeldings‑verwerkingsscope:

| Inhoud | Behandeling |
| --- | --- |
| Raster‑afbeeldingen en shape‑picture‑fills op normale, master‑ en layout‑dia’s, inclusief gegroepeerde shapes | In aanmerking voor compressie. |
| Afbeeldingen die al op of onder de gevraagde resolutie zitten | Niet opgewaardeerd. Bijgesneden gebieden kunnen nog steeds worden verwijderd. |
| Bijgesneden afbeelding‑gebieden | Verborgen pixels worden permanent verwijderd en bijsnij‑offsets gereset. |
| Dia‑achtergronden en tabelcel‑fills | Niet verwerkt door deze helpers. |
| Internals van grafieken/SmartArt, GIF‑ en vectorformaten zoals SVG, EMF en WMF | Buiten het gedocumenteerde beeld‑compressie‑bereik. |

In 26.11 voorkomt [PicturesCompression.DocumentResolution](https://reference.aspose.com/slides/net/aspose.slides.export/picturescompression/) resolutie‑gebaseerde downsampling van een niet‑bijgesneden afbeelding, maar **behoudt geen bijgesneden pixels**. Een bijgesneden afbeelding kan nog steeds worden herschreven met de verborgen gebieden verwijderd. Geen van de helpers biedt een optie om bijgesneden pixels te behouden. Voor individuele controle, zie het [per‑afbeelding compressie‑voorbeeld](/slides/nl/net/examples/optimization-batch/compression/).

Vergelijk het uiterlijk en de bestandsgrootte van de output vóór het vervangen van het origineel. Besparingen hangen af van de bronafbeeldingen, hun weergegeven grootte en ongebruikte content; compressie garandeert niet dat het bestand kleiner wordt. Zie [Embedded Fonts](/slides/nl/net/embedded-font/) voor de gevolgen van lettertype‑reductie.

## **FAQ**

**Wanneer moet ik de low‑code API gebruiken in plaats van het volledige object model?**

Gebruik low‑code helpers wanneer een standaardbewerking wordt toegepast op een compleet bestand of presentatie en geen gedetailleerde controle over individuele elementen vereist is. Gebruik het volledige object model wanneer je specifieke dia’s moet selecteren, master‑ en layout‑relaties moet beheren, een tussentijdse status moet inspecteren, of gedrag moet configureren dat de helper niet blootstelt.

**Kan Merger presentaties combineren met verschillende bestandsformaten?**

Nee. [Merger.Process](https://reference.aspose.com/slides/net/aspose.slides.lowcode/merger/process/) vereist input‑presentaties in hetzelfde formaat. Converteer de invoer‑bestanden eerst naar een gemeenschappelijk formaat, bijvoorbeeld met [Convert.AutoByExtension](https://reference.aspose.com/slides/net/aspose.slides.lowcode/convert/autobyextension/), en voeg daarna de geconverteerde bestanden samen.

**Verwerkt ForEach master‑, layout‑ en notitiedia’s?**

[ForEach.Slide](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/slide/) iterateert door normale presentatiedia’s. Presentatie‑brede [ForEach.Shape](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/shape/), [ForEach.Paragraph](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/paragraph/) en [ForEach.Portion](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/portion/) operaties omvatten standaard normale, master‑ en layout‑dia’s. Gebruik hun overloads met `includeNotes` op `true` om notitiedia’s op te nemen.

**Wat is het verschil tussen ForEach.Shape en Collect.Shapes?**

Gebruik [ForEach.Shape](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/shape/) om elke shape direct te verwerken via een callback. Gebruik [Collect.Shapes](https://reference.aspose.com/slides/net/aspose.slides.lowcode/collect/shapes/) wanneer je een enumerate‑resultaat nodig hebt dat kan worden bewaard, gefilterd, geteld of meerdere keren kan worden doorlopen.

**Maakt Compress altijd het presentatie‑bestand kleiner?**

Niet per se. Besparingen hangen af van ongebruikte layouts/masters, ingesloten lettertypen met ongebruikte tekens en afbeeldingen die baat hebben bij compressie. De [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/) helpers kunnen de grootte ongewijzigd laten of zelfs een groter bestand opleveren voor sommige invoerbestanden. Vergelijk zowel grootte als render‑kwaliteit, en bewaar het origineel.

**Worden wijzigingen die door ForEach of Compress worden aangebracht automatisch opgeslagen?**

Nee. Deze helpers werken op het geladen [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) object in het geheugen. Na het wijzigen van elementen in een [ForEach](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/) callback of het uitvoeren van [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/), roep [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) aan om het resultaat weg te schrijven.

## **Gerelateerde artikelen**

- [Presentatie converteren](/slides/nl/net/convert-presentation/)
- [Presentaties samenvoegen](/slides/nl/net/merge-presentation/)
- [Slide Master](/slides/nl/net/slide-master/)
- [Manage Text Box](/slides/nl/net/manage-textbox/)
- [Embedded Font](/slides/nl/net/embedded-font/)