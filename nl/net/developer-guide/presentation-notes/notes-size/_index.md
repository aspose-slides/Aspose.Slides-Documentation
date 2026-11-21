---
title: Wijzig notitiepagina-grootte en oriëntatie in .NET
linktitle: Notitiepagina-grootte
type: docs
weight: 10
url: /nl/net/notes-size/
keywords:
- notitiepagina-grootte
- notitie-oriëntatie
- liggende notities
- staande notities
- handout-grootte
- PowerPoint
- presentatie
- PPT
- PPTX
- C#
- Aspose.Slides
description: "Lees en wijzig de afmetingen van de notitiepagina in Aspose.Slides voor .NET, wissel de oriëntatie, controleer de opgeslagen maten en exporteer notities of hand-outs naar PDF en afbeeldingen."
---
## **Overzicht**

Gebruik [Presentation.NotesSize](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/notessize/) om de instellingen van de notitiepagina van de presentatie te benaderen. Het retourneert een [INotesSize](https://reference.aspose.com/slides/nl/net/aspose.slides/inotessize/)‑object waarvan de [Size](https://reference.aspose.com/slides/nl/net/aspose.slides/inotessize/size/)‑eigenschap schrijfbaar is. Hoewel het instellingenobject zelf alleen‑lezen is, kun je nieuwe afmetingen toewijzen aan de eigenschap size.

Breedte en hoogte worden opgegeven in **punten**, met 72 punten per inch. Bijvoorbeeld, 900 × 600 punten is 12,5 × 8⅓ inch. Deze instellingen zijn van toepassing op de presentatie, niet op de notities van een individuele dia.

| Instelling | Doel |
| --- | --- |
| [Presentation.NotesSize](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/notessize/) | Bepaalt de afmetingen van de notitiepagina en de paginagrootte die wordt gebruikt bij het exporteren van hand-outs. |
| [Presentation.SlideSize](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/slidesize/) | Bepaalt de normale presentatiedia-afmetingen via [ISlideSize](https://reference.aspose.com/slides/nl/net/aspose.slides/islidesize/). |

Het wijzigen van de ene instelling wijzigt niet automatisch de andere. Het wijzigen van de oriëntatie van de notitiepagina roteert ook niet de gewone dia’s. Zie [Slide Size](/slides/nl/net/slide-size/) om gewone dia’s van formaat te veranderen.

De voorbeelden hieronder gebruiken een bestaande `sample.pptx`. Voor de export‑voorbeelden gebruik je een presentatie met ten minste één dia met spreker‑notities. Elk voorbeeld kan onafhankelijk worden uitgevoerd.

## **Lees de notitiepagina‑grootte en -oriëntatie**

Lees de breedte en hoogte en vergelijk ze om de oriëntatie te bepalen: een bredere pagina is liggend, een hogere pagina is staand, en gelijke afmetingen beschrijven een vierkante pagina. Dit voorbeeld drukt de werkelijke afmetingen in punten af, zonder een standaard papierformaat aan te nemen.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");
var size = presentation.NotesSize.Size;
var orientation = "Square";

if (size.Width > size.Height)
    orientation = "Landscape";
else if (size.Width < size.Height)
    orientation = "Portrait";

Console.WriteLine($"Notes page: {size.Width} x {size.Height} points");
Console.WriteLine($"Orientation: {orientation}");
```

## **Overschakelen naar liggend zonder het papierformaat te wijzigen**

Om alleen de oriëntatie te wijzigen, verwissel je de bestaande breedte en hoogte. Dit behoudt de lengtes van beide zijden, inclusief die van een aangepast papierformaat. De voorwaarde hieronder voorkomt dat een reeds liggende pagina wordt teruggeschakeld naar staand en laat een vierkante pagina ongewijzigd.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var size = presentation.NotesSize.Size;

if (size.Width < size.Height)
    presentation.NotesSize.Size = new SizeF(size.Height, size.Width);

presentation.Save("landscape-notes.pptx", SaveFormat.Pptx);
```

Voor staande oriëntatie gebruik je dezelfde toewijzing wanneer `size.Width > size.Height`. Vervang geen A4‑ of Letter‑afmetingen tenzij je ook het papierformaat wilt wijzigen.

## **Stel een aangepaste notitiepagina‑grootte in en verifieer deze**

Wijs beide afmetingen tegelijk toe en gebruik vervolgens [Presentation.Save](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/save/) om de presentatie op te slaan. Dit voorbeeld stelt een liggende pagina van 900 × 600 punten in, slaat deze op als PPTX en opent het opgeslagen bestand opnieuw om de persistente waarden te controleren. De vergelijking laat een tolerantiewaarde van 0,01 punt toe voor zwevende‑kommagetallen; het is geen garantie voor nauwkeurigheid voor elk bestandsformaat.

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var expectedSize = new SizeF(900, 600);
presentation.NotesSize.Size = expectedSize;
presentation.Save("custom-notes.pptx", SaveFormat.Pptx);

using var reopened = new Presentation("custom-notes.pptx");
var actualSize = reopened.NotesSize.Size;
var widthMatches = Math.Abs(actualSize.Width - expectedSize.Width) < 0.01f;
var heightMatches = Math.Abs(actualSize.Height - expectedSize.Height) < 0.01f;
var preserved = widthMatches && heightMatches;

Console.WriteLine($"Stored notes page: {actualSize.Width} x {actualSize.Height} points");
Console.WriteLine($"Size preserved: {preserved}");
```

Het verwachte resultaat is `900 x 600 points` en `Size preserved: True`. Het controleren van een pas geopende presentatie verifieert het opgeslagen bestand, in plaats van alleen de in‑memory‑instellingen.

## **Exporteer notities en hand‑outs**

De paginagrootte bepaalt het beschikbare gebied voor notitie‑ of hand‑out‑lay‑outs. Ze activeren die lay‑outs niet vanzelf: configureer ook de export‑opties. Export van gewone dia’s blijft de dia‑afmetingen gebruiken.

### **Exporteer notities naar PDF en PNG**

Wijs [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/nl/net/aspose.slides.export/notescommentslayoutingoptions/) toe aan [PdfOptions.SlidesLayoutOptions](https://reference.aspose.com/slides/nl/net/aspose.slides.export/pdfoptions/slideslayoutoptions/) om notities in de PDF op te nemen. Dit voorbeeld rendert ook de eerste dia met notities naar PNG via [Slide.GetImage](https://reference.aspose.com/slides/nl/net/aspose.slides/slide/getimage/) en [RenderingOptions](https://reference.aspose.com/slides/nl/net/aspose.slides.export/renderingoptions/).

De [BottomTruncated](https://reference.aspose.com/slides/nl/net/aspose.slides.export/notespositions/)‑modus houdt de notities op één pagina; notities die niet passen kunnen worden afgekapt. De PDF gebruikt pagina’s van 900 × 600 punten. Bij de afbeeldingsschaal van 1 × 1 die hieronder wordt gebruikt, is de PNG 900 × 600 pixels. Punten beschrijven de paginageometrie; pixels beschrijven de raster‑output, waarvan de afmetingen ook afhangen van de render‑schaal.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
presentation.NotesSize.Size = new SizeF(900, 600);

var layout = new NotesCommentsLayoutingOptions
{
    NotesPosition = NotesPositions.BottomTruncated
};

var pdfOptions = new PdfOptions { SlidesLayoutOptions = layout };
presentation.Save("notes.pdf", SaveFormat.Pdf, pdfOptions);

var renderingOptions = new RenderingOptions { SlidesLayoutOptions = layout };
using var image = presentation.Slides[0].GetImage(renderingOptions, 1, 1);
image.Save("first-slide-notes.png", ImageFormat.Png);
```

Voor PDF‑export met lange notities laat [BottomFull](https://reference.aspose.com/slides/nl/net/aspose.slides.export/notespositions/) extra pagina’s toe indien nodig. Gebruik die modus niet bij de enkel‑dia‑afbeeldingsaanroep hierboven, die dit niet ondersteunt. Na het aanpassen van de afmetingen, inspecteer de output op afgesneden notities en de plaatsing van bestaande notes‑master‑objecten; alleen de paginagrootte wijzigen is geen garantie dat alle inhoud past. Zie [Convert PowerPoint to PDF with Notes](/slides/nl/net/convert-powerpoint-to-pdf-with-notes/) voor meer over notitie‑export.

### **Exporteer hand‑outs naar PDF**

Gebruik [HandoutLayoutingOptions](https://reference.aspose.com/slides/nl/net/aspose.slides.export/handoutlayoutingoptions/) voor meerdere dia‑miniaturen op één pagina. Het volgende voorbeeld stelt een pagina van 900 × 600 punten in en gebruikt [HandoutType.Handouts4Horizontal](https://reference.aspose.com/slides/nl/net/aspose.slides.export/handouttype/) om maximaal vier dia’s per pagina te rangschikken. De horizontale preset bepaalt de volgorde van de dia’s; de paginawijziging komt van de breedte en hoogte.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
presentation.NotesSize.Size = new SizeF(900, 600);

var layout = new HandoutLayoutingOptions
{
    Handout = HandoutType.Handouts4Horizontal
};

var pdfOptions = new PdfOptions { SlidesLayoutOptions = layout };
presentation.Save("handouts.pdf", SaveFormat.Pdf, pdfOptions);
```

Het wijzigen van de paginagrootte verandert het beschikbare gebied voor het hand‑out‑rooster zonder de afmetingen van de bron‑dia's aan te passen. Voor hand‑out‑afbeeldingen gebruik je [Presentation.GetImages](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/getimages/) met de hand‑out‑layout, in plaats van de afbeelding‑methode van een individuele dia. In Aspose.Slides gebruikt de rendering van hand‑outs op presentatieniveau de notitiepagina‑afmetingen, terwijl de afbeelding‑aanroep voor een enkele dia de hand‑out‑pagina niet oplevert. Zie [Handout Mode](/slides/nl/net/convert-powerpoint-in-handout-mode/) voor lay‑out‑opties.

## **Paginaformaat in viewers, export en afdrukken**

Houd het opgeslagen presentatiesize, de geëxporteerde paginagrootte en de afgedrukte papiergrootte gescheiden:

- **Presentatie‑viewers:** Een viewer kan notities tonen of afdrukken volgens zijn eigen layout‑regels. Als een andere applicatie het bestand opslaat, open het dan opnieuw en controleer de afmetingen; de bestandsconversie van die applicatie kan ze normaliseren.
- **Export‑formaten:** De notities‑ en hand‑out‑PDF‑voorbeelden hierboven gebruiken de geconfigureerde paginagrootte. Raster‑afbeeldingen gebruiken gehele pixel‑afmetingen en een render‑schaal, zodat fractie‑punt‑waarden kunnen worden afgerond in de afbeelding. Export van gewone dia’s past de notitiepagina‑grootte niet toe.
- **Printer‑drivers:** Papierselectie, automatische rotatie en fit‑to‑page‑instellingen kunnen de fysieke output wijzigen zonder de opgeslagen afmetingen in de presentatie of PDF te veranderen. Voor een specifiek papierformaat, stem de printerinstellingen af en inspecteer de afdruk‑preview.

## **FAQ**

**Kan ik de notitie‑grootte instellen voor slechts één dia?**

De notitiepagina‑grootte is een instelling op presentatieniveau. Individuele dia’s kunnen verschillende notitie‑inhoud hebben, maar deze eigenschap biedt geen aparte paginagrootte per dia.

**Waarom wijzigde het aanpassen van de notitie‑oriëntatie mijn dia’s niet?**

Notitiepagina’s en gewone dia’s hebben onafhankelijke afmetingen. Gebruik de instellingen voor gewone dia‑grootte wanneer je de dia’s zelf wilt aanpassen.

**Waarom heeft mijn opgeslagen of afgedrukte resultaat een andere grootte?**

Open de opgeslagen presentatie opnieuw en vergelijk de notitie‑afmetingen. Als die veranderd zijn, controleer dan of het opslaan of converteren in een andere applicatie de paginainstellingen heeft aangepast. Als dat niet het geval is, controleer dan de export‑layout, afbeeldingsschaal, viewer‑instellingen en de papierselectie van de printer.