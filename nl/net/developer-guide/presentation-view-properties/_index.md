---
title: Ophalen en bijwerken van presentatie‑weergave‑eigenschappen in .NET
linktitle: Weergave‑eigenschappen
type: docs
weight: 80
url: /nl/net/presentation-view-properties/
keywords:
- weergave‑eigenschappen
- normale weergave
- outline‑inhoud
- outline‑pictogrammen
- verticale splitter vastklikken
- enkele weergave
- balkstatus
- dimensiegrootte
- automatisch aanpassen
- standaard‑zoom
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Ontdek de weergave‑eigenschappen van Aspose.Slides for .NET om PPT-, PPTX- en ODP‑dia's aan te passen – lay‑outs, zoomniveaus en weergave‑instellingen te wijzigen."
---
## **Inleiding**

De normale weergave bestaat uit drie inhoudsgebieden: de dia zelf, een zij-inhoudsgebied en een onderaan-inhoudsgebied. Eigenschappen met betrekking tot de positionering van de verschillende inhoudsgebieden. Deze informatie stelt de applicatie in staat de weergavestatus op te slaan in het bestand, zodat bij het opnieuw openen de weergave in dezelfde staat is als toen de presentatie voor het laatst werd opgeslagen.

Eigenschap [IViewProperties.NormalViewProperties](https://reference.aspose.com/slides/nl/net/aspose.slides/iviewproperties/properties/normalviewproperties) is toegevoegd om toegang te bieden tot normale weergave‑eigenschappen van een presentatie.  

Interfaces [INormalViewProperties](https://reference.aspose.com/slides/nl/net/aspose.slides/inormalviewproperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/nl/net/aspose.slides/inormalviewrestoredproperties) en hun afstammelingen, enum [SplitterBarStateType](https://reference.aspose.com/slides/nl/net/aspose.slides/splitterbarstatetype) zijn toegevoegd.

## **Over INormalViewProperties**

Stelt normale weergave‑eigenschappen voor.

Eigenschap **ShowOutlineIcons** bepaalt of de applicatie pictogrammen moet tonen bij het weergeven van outline‑inhoud in een van de inhoudsgebieden van de normale weergavemodus.

Eigenschap **SnapVerticalSplitter** bepaalt of de verticale splitter naar een geminimaliseerde status moet springen wanneer het zij‑gebied voldoende klein is.

Eigenschap **PreferSingleView** bepaalt of de gebruiker liever één volledige‑venster‑inhoudsgebied ziet in plaats van de standaard normale weergave met drie inhoudsgebieden. Indien ingeschakeld, kan de applicatie kiezen om een van de inhoudsgebieden over het gehele venster te tonen.

Eigenschappen **VerticalBarState** en **HorizontalBarState** bepalen de status waarin de horizontale of verticale splitbalk moet worden weergegeven. Een horizontale splitbalk scheidt de dia van het inhoudsgebied onder de dia, een verticale splitbalk scheidt de dia van het zij‑inhoudsgebied. Mogelijke waarden zijn: **SplitterBarStateType.Minimized, SplitterBarStateType.Maximized** en **SplitterBarStateType.Restored**.

Eigenschappen **RestoredLeft** en **RestoredTop** bepalen de grootte van respectievelijk het boven‑ of zij‑dia‑gebied van de normale weergave, wanneer de waarde **SplitterBarStateType.Restored** wordt toegepast op **VerticalBarState** en **HorizontalBarState**.

## **Over het herstellen van INormalViewProperties**

Bepaalt de grootte van het dia‑gebied (breedte wanneer een kind van RestoredTop, hoogte wanneer een kind van RestoredLeft) van de normale weergave, wanneer het gebied een variabele herstelde grootte heeft (niet geminimaliseerd of gemaximaliseerd).

Eigenschap **DimensionSize** bepaalt de grootte van het dia‑gebied (breedte wanneer een kind van RestoredTop, hoogte wanneer een kind van RestoredLeft).

Eigenschap **AutoAdjust** bepaalt of de grootte van het zij‑inhoudsgebied moet worden aangepast aan de nieuwe grootte bij het wijzigen van de grootte van het venster dat de weergave bevat in de applicatie.

Een voorbeeld hieronder toont hoe u toegang krijgt tot eigenschappen van **ViewProperties.NormalViewProperties** voor een presentatie.

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

## **Standaardzoomwaarde instellen**

Aspose.Slides for .NET ondersteunt nu het instellen van de standaardzoomwaarde voor een presentatie, zodat de zoom al is ingesteld wanneer de presentatie wordt geopend. Dit kan worden gedaan door de [ViewProperties](https://reference.aspose.com/slides/nl/net/aspose.slides/viewproperties) van een presentatie in te stellen. Slide View Properties evenals [NotesViewProperties](https://reference.aspose.com/slides/nl/net/aspose.slides/viewproperties/properties/notesviewproperties) kunnen programmatisch worden ingesteld. In dit onderwerp laten we met een voorbeeld zien hoe de View Properties van een presentatie in Aspose.Slides in te stellen.

Om de weergave‑eigenschappen in te stellen, volgt u de onderstaande stappen:

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation)
1. Stel View[Properties](https://reference.aspose.com/slides/nl/net/aspose.slides/viewproperties) van de presentatie in
1. Schrijf de presentatie weg als een PPTX‑bestand

In het voorbeeld hieronder hebben we de zoomwaarde ingesteld voor zowel de dia‑weergave als de notitie‑weergave.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("demo.pptx"))
{
    // Instellen van de weergave‑eigenschappen van de presentatie
    presentation.ViewProperties.SlideViewProperties.Scale = 100; // Zoomwaarde in procenten voor de dia‑weergave
    presentation.ViewProperties.NotesViewProperties.Scale = 100; // Zoomwaarde in procenten voor de notitie‑weergave 

    presentation.Save("Zoom_out.pptx", SaveFormat.Pptx);
}
```

## **Rasterafstand instellen**

Gebruik [Presentation.ViewProperties](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/viewproperties/) om weergave‑instellingen voor de hele presentatie te benaderen. De eigenschap [IViewProperties.GridSpacing](https://reference.aspose.com/slides/nl/net/aspose.slides/iviewproperties/gridspacing/) leest of wijzigt het interval van het onderliggende bewerkingsraster. Deze instelling geldt voor de volledige presentatie, niet voor een individuele dia. Rasterafstand wordt opgegeven in punten, waarbij 72 punten één inch zijn. Gebruik een positieve waarde, zoals vereist door de API‑documentatie.

Het volgende voorbeeld opent een bestaande `demo.pptx`, toont de huidige rasterafstand, stelt een kwart‑inch‑interval in, en slaat het resultaat op.

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

Het raster verschilt van [drawing guides](/slides/nl/net/drawing-guides/). Rasterafstand regelt een regelmatig interval, terwijl teken‑gidsen individuele horizontale of verticale uitlijningslijnen zijn. Het toevoegen, verplaatsen of wissen van teken‑gidsen verandert de rasterafstand niet.

Zowel het raster als de teken‑gidsen zijn hulpmiddelen voor bewerking. Ze worden niet gerenderd als dia‑inhoud in PDF, afbeeldingen, SVG of een diavoorstelling. Het opslaan van de rasterafstand garandeert niet dat een editor het raster weergeeft: de zichtbaarheid hangt ook af van de voorkeuren van de viewer of editor.

## **FAQ**

**Waarom is het raster niet zichtbaar nadat ik de presentatie opnieuw heb geopend?**

Het bestand slaat de rasterafstand op, maar de editor bepaalt of het raster wordt weergegeven. Controleer de raster‑zichtbaarheidsinstellingen van de editor.

**Verandert het wissen van teken‑gidsen de rasterafstand?**

Nee. Teken‑gidsen en rasterafstand zijn onafhankelijke instellingen. Het wissen van gidsen laat het opgeslagen rasterinterval ongewijzigd.

**Kan ik verschillende weergave‑instellingen definiëren voor verschillende secties van een presentatie?**

[Weergave‑instellingen](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/viewproperties/) worden gedefinieerd op presentatieniveau ([Normal View](https://reference.aspose.com/slides/nl/net/aspose.slides/viewproperties/normalviewproperties/)/[Slide View](https://reference.aspose.com/slides/nl/net/aspose.slides/viewproperties/slideviewproperties/)), niet per sectie, dus één set parameters is van toepassing op het hele document bij het openen.

**Kan ik vooraf verschillende weergave‑statussen definiëren voor verschillende gebruikers?**

Nee. De instellingen worden in het bestand opgeslagen en gedeeld. Viewer‑applicaties kunnen gebruikersvoorkeuren respecteren, maar het bestand zelf bevat één set weergave‑eigenschappen.

**Kan ik een sjabloon voorbereiden met vooraf gedefinieerde View Properties zodat nieuwe presentaties op dezelfde manier worden geopend?**

Ja. Omdat [view properties](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/viewproperties/) worden opgeslagen op presentatieniveau, kunt u ze in een sjabloon opnemen en nieuwe documenten ervan maken met dezelfde initiële weergaveconfiguratie.