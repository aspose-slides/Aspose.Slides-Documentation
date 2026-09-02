---
title: Beheer tekengidsen in presentaties in .NET
linktitle: Tekengidsen
type: docs
weight: 85
url: /nl/net/drawing-guides/
keywords:
- tekengids
- horizontale gids
- verticale gids
- uitlijningsgids
- diaweergave
- masterdia
- lay-outdia
- notitiemaster
- handoutmaster
- PowerPoint
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Voeg toe, krijg toegang tot en wis horizontale en verticale tekengidsen in PowerPoint-presentaties met Aspose.Slides for .NET."
---
## **Overzicht**

Tekengidsen zijn verstelbare horizontale en verticale lijnen die gebruikers helpen vormen consistent uit te lijnen tijdens het bewerken van een presentatie in PowerPoint. Ze zijn vooral nuttig wanneer een applicatie een presentatie genereert die later handmatig wordt verfijnd: de applicatie kan dezelfde uitlijn‑hulpmiddelen opslaan die auteurs moeten volgen bij het toevoegen of verplaatsen van inhoud.

Tekengidsen zijn hulpmiddelen voor bewerken, geen dia‑inhoud. Ze verschijnen niet in een diavoorstelling of gerenderde uitvoer. Aspose.Slides for .NET maakt ze beschikbaar via de [IDrawingGuidesCollection](https://reference.aspose.com/slides/nl/net/aspose.slides/idrawingguidescollection/) interface. Een gids wordt weergegeven door [IDrawingGuide](https://reference.aspose.com/slides/nl/net/aspose.slides/idrawingguide/) en heeft een oriëntatie, een positie en een kleur.

De positie wordt gemeten in punten vanaf de linkerbovenhoek van de betreffende dia of master. Een verticale gids gebruikt een horizontale coördinaat, gewoonlijk tussen nul en de breedte van de dia. Een horizontale gids gebruikt een verticale coördinaat, gewoonlijk tussen nul en de hoogte van de dia.

## **Gidsen toevoegen aan de diaweergave**

Gebruik [ICommonSlideViewProperties.DrawingGuides](https://reference.aspose.com/slides/nl/net/aspose.slides/icommonslideviewproperties/drawingguides/) om gidsen te beheren die worden weergegeven tijdens het bewerken van normale dia's. Roep [IDrawingGuidesCollection.Add](https://reference.aspose.com/slides/nl/net/aspose.slides/idrawingguidescollection/add/) aan met een [Orientation](https://reference.aspose.com/slides/nl/net/aspose.slides/orientation/)‑waarde en een positie in punten.

Het volgende voorbeeld voegt één verticale gids toe rechts van het midden van de dia en één horizontale gids eronder:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var slideSize = presentation.SlideSize.Size;
var guides = presentation.ViewProperties.SlideViewProperties.DrawingGuides;

guides.Add(Orientation.Vertical, slideSize.Width / 2 + 12.5f);
guides.Add(Orientation.Horizontal, slideSize.Height / 2 + 12.5f);

presentation.Save("drawing-guides.pptx", SaveFormat.Pptx);
```

## **Toegang tot tekengidsen**

De eigenschap [IDrawingGuidesCollection.Count](https://reference.aspose.com/slides/nl/net/aspose.slides/idrawingguidescollection/count/) en de indexer geven toegang tot bestaande gidsen. De eigenschappen [IDrawingGuide.Orientation](https://reference.aspose.com/slides/nl/net/aspose.slides/idrawingguide/orientation/), [IDrawingGuide.Position](https://reference.aspose.com/slides/nl/net/aspose.slides/idrawingguide/position/) en [IDrawingGuide.Color](https://reference.aspose.com/slides/nl/net/aspose.slides/idrawingguide/color/) kunnen worden gelezen of gewijzigd.

Het volgende voorbeeld leest de gidsen van de diaweergave uit de hierboven gemaakte presentatie:

```csharp
using Aspose.Slides;

using var presentation = new Presentation("drawing-guides.pptx");

var guides = presentation.ViewProperties.SlideViewProperties.DrawingGuides;

for (var index = 0; index < guides.Count; index++)
{
    var guide = guides[index];
    Console.WriteLine($"Guide {index}: orientation = {guide.Orientation}, position = {guide.Position}, color = {guide.Color}");
}
```

## **Gidsen toevoegen aan master‑ en lay‑outdia’s**

Een dia‑master en elk van de bijbehorende lay‑outdia’s kunnen hun eigen tekengids‑collecties hebben. Gebruik [IMasterSlide.DrawingGuides](https://reference.aspose.com/slides/nl/net/aspose.slides/imasterslide/drawingguides/) voor een master‑dia en [ILayoutSlide.DrawingGuides](https://reference.aspose.com/slides/nl/net/aspose.slides/ilayoutslide/drawingguides/) voor een lay‑outdia.

Het volgende voorbeeld voegt een verticale gids toe aan de eerste master‑dia en een horizontale gids aan de eerste lay‑outdia:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var slideSize = presentation.SlideSize.Size;
var masterGuides = presentation.Masters[0].DrawingGuides;
var layoutGuides = presentation.LayoutSlides[0].DrawingGuides;

masterGuides.Add(Orientation.Vertical, slideSize.Width / 2 - 20f);
layoutGuides.Add(Orientation.Horizontal, slideSize.Height / 2 + 20f);

presentation.Save("master-layout-drawing-guides.pptx", SaveFormat.Pptx);
```

## **Gidsen toevoegen aan notitie‑ en handout‑masters**

Notitie‑masters en handout‑masters ondersteunen ook tekengidsen. Gebruik [IMasterNotesSlide.DrawingGuides](https://reference.aspose.com/slides/nl/net/aspose.slides/imasternotesslide/drawingguides/) en [IMasterHandoutSlide.DrawingGuides](https://reference.aspose.com/slides/nl/net/aspose.slides/imasterhandoutslide/drawingguides/) om hun collecties te benaderen. Als een presentatie een van deze masters niet bevat, maakt [IMasterNotesSlideManager.SetDefaultMasterNotesSlide](https://reference.aspose.com/slides/nl/net/aspose.slides/imasternotesslidemanager/setdefaultmasternotesslide/) of [IMasterHandoutSlideManager.SetDefaultMasterHandoutSlide](https://reference.aspose.com/slides/nl/net/aspose.slides/imasterhandoutslidemanager/setdefaultmasterhandoutslide/) de standaard‑master aan en retourneert deze.

Het volgende voorbeeld voegt een horizontale gids toe aan een notitie‑master en een verticale gids aan een handout‑master:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var notesSize = presentation.NotesSize.Size;
var notesMaster = presentation.MasterNotesSlideManager.SetDefaultMasterNotesSlide();
var handoutMaster = presentation.MasterHandoutSlideManager.SetDefaultMasterHandoutSlide();

notesMaster.DrawingGuides.Add(Orientation.Horizontal, notesSize.Height / 2 + 50f);
handoutMaster.DrawingGuides.Add(Orientation.Vertical, notesSize.Width / 2 - 50f);

presentation.Save("notes-handout-drawing-guides.pptx", SaveFormat.Pptx);
```

## **Tekengidsen wissen**

Roep [IDrawingGuidesCollection.Clear](https://reference.aspose.com/slides/nl/net/aspose.slides/idrawingguidescollection/clear/) aan om alle gidsen uit een bepaalde collectie te verwijderen. Het wissen van één collectie heeft geen invloed op gidsen die in een andere scope zijn opgeslagen.

Het volgende voorbeeld wist de diaweergave‑gidsen en alle gidsen op dia‑masters, lay‑outdia’s, de notitie‑master en de handout‑master zonder ontbrekende masters te creëren:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation-with-guides.pptx");

presentation.ViewProperties.SlideViewProperties.DrawingGuides.Clear();

foreach (var masterSlide in presentation.Masters)
{
    masterSlide.DrawingGuides.Clear();
}

foreach (var layoutSlide in presentation.LayoutSlides)
{
    layoutSlide.DrawingGuides.Clear();
}

var notesMaster = presentation.MasterNotesSlideManager.MasterNotesSlide;
if (notesMaster != null)
{
    notesMaster.DrawingGuides.Clear();
}

var handoutMaster = presentation.MasterHandoutSlideManager.MasterHandoutSlide;
if (handoutMaster != null)
{
    handoutMaster.DrawingGuides.Clear();
}

presentation.Save("presentation-without-guides.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Verschijnen tekengidsen in een diavoorstelling of geëxporteerde afbeeldingen?**

Nee. Tekengidsen zijn uitlijn‑hulpmiddelen voor bewerken en worden niet weergegeven als presentatiedocumentinhoud.

**Kan een tekengids direct aan een individuele normale dia worden toegevoegd?**

Bewerkingsgidsen voor normale dia’s worden opgeslagen in de diaweergave‑eigenschappen van de presentatie. Aparte gids‑collecties zijn beschikbaar voor dia‑masters, lay‑outdia’s, notitie‑masters en handout‑masters.

**Welke eenheden worden gebruikt voor gidsposities?**

Posities worden gespecificeerd in punten, waarbij 72 punten gelijk zijn aan één inch. Verticale posities worden gemeten vanaf de linkerrand, en horizontale posities vanaf de bovenzijde.

**Verwijdert het wissen van tekengidsen vormen of wijzigt het de dia‑inhoud?**

Nee. De `Clear`‑methode verwijdert alleen de gidsen in de geselecteerde collectie. Vormen en andere dia‑inhoud blijven ongewijzigd.