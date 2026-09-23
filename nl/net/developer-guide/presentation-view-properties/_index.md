---
title: Ophalen en bijwerken van presentatieweergave-eigenschappen in .NET
linktitle: Weergave-eigenschappen
type: docs
weight: 80
url: /nl/net/presentation-view-properties/
keywords:
- weergave-eigenschappen
- normale weergave
- outline-inhoud
- outline-icoontjes
- snap verticale splitter
- enkele weergave
- balkstatus
- dimensie-grootte
- automatisch aanpassen
- standaardzoom
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Ontdek de weergave-eigenschappen van Aspose.Slides for .NET om PPT, PPTX en ODP-dia's aan te passen—lay-outs, zoomniveaus en weergave-instellingen wijzigen."
---
## **Inleiding**

De normale weergave bestaat uit drie inhoudsgebieden: de dia zelf, een zijinhoudsgebied en een onderinhoudsgebied. Eigenschappen met betrekking tot de positionering van de verschillende inhoudsgebieden. Deze informatie stelt de applicatie in staat om de weergavestatus op te slaan in het bestand, zodat bij het opnieuw openen de weergave zich in dezelfde staat bevindt als toen de presentatie voor het laatst werd opgeslagen.

De eigenschap [IViewProperties.NormalViewProperties](https://reference.aspose.com/slides/nl/net/aspose.slides/iviewproperties/properties/normalviewproperties) is toegevoegd om toegang te geven tot de normale weergave‑eigenschappen van een presentatie.

[INormalViewProperties](https://reference.aspose.com/slides/nl/net/aspose.slides/inormalviewproperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/nl/net/aspose.slides/inormalviewrestoredproperties), interfaces en hun afstammelingen, [SplitterBarStateType](https://reference.aspose.com/slides/nl/net/aspose.slides/splitterbarstatetype) enum zijn toegevoegd.

## **Over INormalViewProperties**

Stelt de normale weergave‑eigenschappen voor.

De eigenschap **ShowOutlineIcons** geeft aan of de applicatie pictogrammen moet weergeven bij het tonen van outline‑inhoud in een van de inhoudsgebieden in de normale weergavemodus.

De eigenschap **SnapVerticalSplitter** bepaalt of de verticale splitter moet “snapen” naar een geminimaliseerde toestand wanneer het zijgebied voldoende klein is.

De eigenschap **PreferSingleView** geeft aan of de gebruiker de voorkeur geeft aan een enkel‑venster weergave met één inhoudsgebied in plaats van de standaard normale weergave met drie inhoudsgebieden. Indien ingeschakeld, kan de applicatie ervoor kiezen om één van de inhoudsgebieden in het volledige venster weer te geven.

De eigenschappen **VerticalBarState** en **HorizontalBarState** geven de toestand aan waarin de horizontale of verticale scheidingsbalk moet worden getoond. Een horizontale scheidingsbalk scheidt de dia van het inhoudsgebied onder de dia, een verticale scheidingsbalk scheidt de dia van het zij‑inhoudsgebied. Mogelijke waarden zijn: **SplitterBarStateType.Minimized, SplitterBarStateType.Maximized** en **SplitterBarStateType.Restored**.

De eigenschappen **RestoredLeft** en **RestoredTop** geven de afmetingen aan van respectievelijk het boven‑ of zij‑dia‑gebied in de normale weergave, wanneer de waarde **SplitterBarStateType.Restored** wordt toegepast op **VerticalBarState** en **HorizontalBarState**.

## **Over het herstellen van INormalViewProperties**

Bepaalt de afmetingen van het dia‑gebied (breedte wanneer een kind van RestoredTop, hoogte wanneer een kind van RestoredLeft) in de normale weergave, wanneer het gebied een variabele herstelde grootte heeft (niet geminimaliseerd of gemaximaliseerd).

De eigenschap **DimensionSize** geeft de grootte van het dia‑gebied aan (breedte wanneer een kind van RestoredTop, hoogte wanneer een kind van RestoredLeft).

De eigenschap **AutoAdjust** bepaalt of de grootte van het zij‑inhoudsgebied moet worden aangepast aan de nieuwe grootte bij het wijzigen van de grootte van het venster dat de weergave binnen de applicatie bevat.

Een voorbeeld hieronder toont hoe u toegang kunt krijgen tot de **ViewProperties.NormalViewProperties**‑eigenschappen voor een presentatie.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("demo.pptx"))
{
    pres.ViewProperties.NormalViewProperties.HorizontalBarState = SplitterBarStateType.Restored;
    pres.ViewProperties.NormalViewProperties.VerticalBarState = SplitterBarStateType.Maximized;

    // Herstel de weergave‑eigenschappen van de presentatie
    pres.ViewProperties.NormalViewProperties.RestoredTop.AutoAdjust = true;
    pres.ViewProperties.NormalViewProperties.RestoredTop.DimensionSize = 80;
    pres.ViewProperties.NormalViewProperties.ShowOutlineIcons = true;

    pres.Save("presentation_normal_view_state.pptx", SaveFormat.Pptx);
}
```

## **Stel de standaardzoomwaarde in**

Aspose.Slides for .NET ondersteunt nu het instellen van de standaardzoomwaarde voor een presentatie, zodat bij het openen van de presentatie de zoom reeds is ingesteld. Dit kan worden gedaan door de [ViewProperties](https://reference.aspose.com/slides/nl/net/aspose.slides/viewproperties) van een presentatie in te stellen. Slide View Properties evenals [NotesViewProperties](https://reference.aspose.com/slides/nl/net/aspose.slides/viewproperties/properties/notesviewproperties) kunnen programmatisch worden ingesteld. In dit onderwerp laten we aan de hand van een voorbeeld zien hoe u de weergave‑eigenschappen van een presentatie in Aspose.Slides kunt instellen.

Om de weergave‑eigenschappen in te stellen, volgt u de onderstaande stappen:

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation) aan
1. Stel de weergave‑[Properties](https://reference.aspose.com/slides/nl/net/aspose.slides/viewproperties) van de presentatie in
1. Schrijf de presentatie weg als een PPTX‑bestand

In het onderstaande voorbeeld hebben we de zoomwaarde ingesteld voor zowel de dia‑weergave als de notitie‑weergave.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("demo.pptx"))
{
    // Instellen van de weergave‑eigenschappen van de presentatie
    presentation.ViewProperties.SlideViewProperties.Scale = 100; // Zoomwaarde in procenten voor diaview
    presentation.ViewProperties.NotesViewProperties.Scale = 100; // Zoomwaarde in procenten voor notitie‑view 

    presentation.Save("Zoom_out.pptx", SaveFormat.Pptx);
}
```

## **Stel de rasterafstand in**

Gebruik [Presentation.ViewProperties](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/viewproperties/) om de weergave‑instellingen op presentatieniveau te benaderen. De eigenschap [IViewProperties.GridSpacing](https://reference.aspose.com/slides/nl/net/aspose.slides/iviewproperties/gridspacing/) leest of wijzigt het interval van het onderliggende bewerkingsraster. Deze instelling is van toepassing op de volledige presentatie, niet op een individuele dia. Rasterafstand wordt gespecificeerd in points, waarbij 72 points gelijk zijn aan één inch. Gebruik een positieve waarde, zoals vereist door de API‑documentatie.

Het volgende voorbeeld opent een bestaande `demo.pptx`, geeft de huidige rasterafstand weer, stelt een kwart‑inch interval in en slaat het resultaat op.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("demo.pptx");
var gridSpacing = presentation.ViewProperties.GridSpacing;
Console.WriteLine($"Current grid spacing: {gridSpacing} points");

presentation.ViewProperties.GridSpacing = 18f;
presentation.Save("grid-spacing.pptx", SaveFormat.Pptx);
```

Het raster verschilt van [drawing guides](/slides/nl/net/drawing-guides/). Rasterafstand beheerst een regelmatig interval, terwijl tekenrichtlijnen individuele horizontale of verticale uitlijningslijnen zijn. Het toevoegen, verplaatsen of verwijderen van tekenrichtlijnen verandert de rasterafstand niet.

Zowel het raster als tekenrichtlijnen zijn hulpmiddelen bij het bewerken. Ze worden niet gerenderd als dia‑inhoud in PDF, afbeeldingen, SVG of een diavoorstelling. Het opslaan van de rasterafstand garandeert niet dat een editor het raster weergeeft: de zichtbaarheid hangt ook af van de voorkeuren van de viewer of editor.

## **Toon of verberg opmerkingen bij het openen van een presentatie**

Gebruik [Presentation.ViewProperties](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/viewproperties/) om de weergave‑instellingen op presentatieniveau te benaderen. Lees of wijzig [IViewProperties.ShowComments](https://reference.aspose.com/slides/nl/net/aspose.slides/iviewproperties/showcomments/) om een voorkeur op te slaan voor het al dan niet tonen van opmerkingen wanneer de presentatie wordt geopend in PowerPoint of een andere compatibele editor.

Deze instelling regelt uitsluitend de opgeslagen weergave‑voorkeur. Het voegt geen opmerkingen toe, verwijdert ze, bewerkt of lost ze op. Het verbergen van opmerkingen behoudt hun inhoud, auteurs, posities, antwoorden en statussen. Zie [Presentation Comments](/slides/nl/net/presentation-comments/) voor bewerkingen die de opmerkingen zelf wijzigen.

Het volgende voorbeeld vereist een bestaande `comments.pptx` met opmerkingen. Het geeft de huidige zichtbaarheid weer, vraagt om de opmerkingen te verbergen en slaat een nieuw PPTX op zonder opmerkingen te verwijderen. Het stelt tevens [IViewProperties.LastView](https://reference.aspose.com/slides/nl/net/aspose.slides/iviewproperties/lastview/) in op [ViewType.SlideView](https://reference.aspose.com/slides/nl/net/aspose.slides/viewtype/) om de initiële bewerkingsweergave samen met de opmerkingzichtbaarheid te configureren.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("comments.pptx");
var showComments = presentation.ViewProperties.ShowComments;
Console.WriteLine($"Current comment visibility: {showComments}");

presentation.ViewProperties.ShowComments = NullableBool.False;
presentation.ViewProperties.LastView = ViewType.SlideView;
presentation.Save("comments-hidden.pptx", SaveFormat.Pptx);
```

Deze instelling bepaalt niet of opmerkingen worden meegenomen in PDF-, HTML-, afbeelding-, notitie- of handout‑exporten. Configureer de relevante export‑specifieke opties afzonderlijk.

## **Veelgestelde vragen**

**Waarom is het raster niet zichtbaar nadat ik de presentatie opnieuw open?**

Het bestand slaat de rasterafstand op, maar de editor bepaalt of het raster wordt weergegeven. Controleer de raster‑zichtbaarheidsinstellingen van de editor.

**Verandert het verwijderen van tekenrichtlijnen de rasterafstand?**

Nee. Tekenrichtlijnen en rasterafstand zijn onafhankelijke instellingen. Het verwijderen van richtlijnen laat het opgeslagen rasterinterval ongewijzigd.

**Kan ik verschillende weergave‑instellingen instellen voor verschillende secties van een presentatie?**

[View settings](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/viewproperties/) worden gedefinieerd op presentatieniveau ([Normal View](https://reference.aspose.com/slides/nl/net/aspose.slides/viewproperties/normalviewproperties/)/[Slide View](https://reference.aspose.com/slides/nl/net/aspose.slides/viewproperties/slideviewproperties/)), niet per sectie, zodat één set parameters van toepassing is op het hele document bij openen.

**Kan ik vooraf verschillende weergave‑staten definiëren voor verschillende gebruikers?**

Nee. De instellingen worden in het bestand opgeslagen en gedeeld. Viewer‑applicaties kunnen rekening houden met gebruikersvoorkeuren, maar het bestand zelf bevat één set weergave‑eigenschappen.

**Kan ik een sjabloon voorbereiden met vooraf gedefinieerde View Properties zodat nieuwe presentaties op dezelfde manier openen?**

Ja. Omdat [view properties](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/viewproperties/) worden opgeslagen op presentatieniveau, kunt u ze in een sjabloon opnemen en nieuwe documenten ervan maken met dezelfde initiële weergaveconfiguratie.