---
title: Ophalen en bijwerken van presentatieweergave‑eigenschappen in .NET
linktitle: Weergave‑eigenschappen
type: docs
weight: 80
url: /nl/net/presentation-view-properties/
keywords:
- weergave‑eigenschappen
- normale weergave
- inhoud van overzicht
- overzichts‑iconen
- snap‑verticale‑splits
- enkele weergave
- balkstatus
- dimensiegrootte
- automatische aanpassing
- standaardzoom
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Gebruik Aspose.Slides voor .NET om de indeling van de normale weergave, de zoom van dia’s en notities, de rasterafstand en de zichtbaarheid van commentaren in PowerPoint‑presentaties te configureren."
---
## **Inleiding**

In de normale weergave van PowerPoint verschijnt de dia tussen een zijpaneel voor miniaturen of een overzicht en een notitiepaneel eronder. Aspose.Slides for .NET maakt de opgeslagen bewerkingsvoorkeuren van de presentatie beschikbaar via [Presentation.ViewProperties](https://reference.aspose.com/slides/net/aspose.slides/presentation/viewproperties/). Deze omvatten de paneelindeling, zoomniveaus, rasterafstand en zichtbaarheid van commentaren.

## **Over INormalViewProperties**

Gebruik [NormalViewProperties](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/normalviewproperties/) om toegang te krijgen tot de [INormalViewProperties](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/) interface. [ShowOutlineIcons](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/showoutlineicons/) bepaalt of pictogrammen naast de dia‑titels in het overzicht verschijnen. [SnapVerticalSplitter](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/snapverticalsplitter/) laat het zijpaneel naar de geminimaliseerde toestand springen wanneer de gebruiker het vernauwt. [PreferSingleView](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/prefersingleview/) geeft een voorkeur aan voor het weergeven van één paneel in het volledige venster.

[VerticalBarState](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/verticalbarstate/) regelt de scheidingsbalk tussen het zijpaneel en de dia. [HorizontalBarState](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/horizontalbarstate/) regelt de scheidingsbalk boven het notitiepaneel. Beide accepteren een [SplitterBarStateType](https://reference.aspose.com/slides/net/aspose.slides/splitterbarstatetype/) waarde van `Minimized`, `Maximized` of `Restored`.

## **Over het herstellen van INormalViewProperties**

Wanneer een scheidingsbalk wordt hersteld, levert [RestoredLeft](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/restoredleft/) de opgeslagen grootte van het zijpaneel en [RestoredTop](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/restoredtop/) de opgeslagen grootte van het bovenste dia‑gebied. Beide exposeren [INormalViewRestoredProperties](https://reference.aspose.com/slides/net/aspose.slides/inormalviewrestoredproperties/). De eigenschap [DimensionSize](https://reference.aspose.com/slides/net/aspose.slides/inormalviewrestoredproperties/dimensionsize/) accepteert een percentage van 0 tot 100, en [AutoAdjust](https://reference.aspose.com/slides/net/aspose.slides/inormalviewrestoredproperties/autoadjust/) bepaalt of de editor de grootte aanpast wanneer het venster wordt gewijzigd.

Dit voorbeeld werkt een bestaande presentatie bij. Het herstelt de horizontale scheidingsbalk, stelt [RestoredTop](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/restoredtop/) in op 80% met automatische aanpassing ingeschakeld, en maximaliseert de verticale scheidingsbalk. Het schakelt ook [ShowOutlineIcons](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/showoutlineicons/) in voor de overzichtsweergave.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("demo.pptx");

var normalView = presentation.ViewProperties.NormalViewProperties;
normalView.HorizontalBarState = SplitterBarStateType.Restored;
normalView.VerticalBarState = SplitterBarStateType.Maximized;
normalView.RestoredTop.AutoAdjust = true;
normalView.RestoredTop.DimensionSize = 80;
normalView.ShowOutlineIcons = true;

presentation.Save("presentation_normal_view_state.pptx", SaveFormat.Pptx);
```

## **Stel de standaard zoomwaarde in**

[SlideViewProperties](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/slideviewproperties/) en [NotesViewProperties](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/notesviewproperties/) slaan onafhankelijke zoominstellingen op voor de editor. Deze instellingen hebben geen invloed op de dia‑afmetingen, de weergave van de diavoorstelling, of de resolutie bij exporteren van afbeeldingen.

Dit voorbeeld opent een bestaande presentatie en schakelt [VariableScale](https://reference.aspose.com/slides/net/aspose.slides/icommonslideviewproperties/variablescale/) in om de dia aan te passen aan het bewerkingsvenster. Voor de notitiepagina schakelt het automatische schalen uit en stelt [Scale](https://reference.aspose.com/slides/net/aspose.slides/icommonslideviewproperties/scale/) in op een vaste zoom van 80%.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("demo.pptx");

var viewProperties = presentation.ViewProperties;
viewProperties.SlideViewProperties.VariableScale = true;
viewProperties.NotesViewProperties.VariableScale = false;
viewProperties.NotesViewProperties.Scale = 80;

presentation.Save("zoom.pptx", SaveFormat.Pptx);
```

## **Stel de rasterafstand in**

[GridSpacing](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/gridspacing/) stelt de afstand tussen bewerkingsrasterlijnen in de hele presentatie in. Het neemt een positieve waarde in punten, met 72 punten per inch. Dit voorbeeld toont de huidige afstand in een bestaande presentatie en slaat een kwart‑inch raster op door het interval op 18 punten in te stellen.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("demo.pptx");

var viewProperties = presentation.ViewProperties;
Console.WriteLine($"Current grid spacing: {viewProperties.GridSpacing} points");

viewProperties.GridSpacing = 18f;
presentation.Save("grid-spacing.pptx", SaveFormat.Pptx);
```

Het raster herhaalt zich met een vast interval. [Tekenhulpmiddelen](/slides/nl/net/drawing-guides/) markeren individuele horizontale of verticale posities. Beide zijn hulpmiddelen bij het bewerken en verschijnen alleen in editors die ze weergeven. Diavoorstellingen en exporten naar PDF, afbeeldingen of SVG laten ze weg.

## **Toon of verberg commentaren bij het openen van een presentatie**

[ShowComments](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/showcomments/) slaat een voorkeur op die compatibele editors gebruiken bij het openen van de presentatie. Voor een bestaande presentatie met commentaren toont dit voorbeeld de huidige instelling en slaat een kopie op met verstopte commentaren. Het stelt ook [LastView](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/lastview/) in op [ViewType.SlideView](https://reference.aspose.com/slides/net/aspose.slides/viewtype/) zodat de kopie opent in de diaweergave.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("comments.pptx");

var viewProperties = presentation.ViewProperties;
Console.WriteLine($"Current comment visibility: {viewProperties.ShowComments}");

viewProperties.ShowComments = NullableBool.False;
viewProperties.LastView = ViewType.SlideView;
presentation.Save("comments-hidden.pptx", SaveFormat.Pptx);
```

Het verbergen van commentaren behoudt hun tekst, auteurs, posities, reacties en statussen. Om de commentaren zelf te wijzigen, zie [Presentatiecommentaren](/slides/nl/net/presentation-comments/). Exportinstellingen bepalen of commentaren verschijnen in PDF, HTML, afbeeldingen, notities of hand‑outs.

## **Veelgestelde vragen**

**Waarom is het raster verborgen wanneer ik de presentatie opnieuw open?**

De presentatie slaat het rasterinterval op. Om het raster te zien, schakel de rasterzichtbaarheid in de editor in.

**Verandert het verwijderen van tekenhulpmiddelen de rasterafstand?**

Nee. Het toevoegen, verplaatsen of verwijderen van een hulplijn verandert het rasterinterval niet.

**Kunnen verschillende secties van een presentatie verschillende weergave‑instellingen hebben?**

Nee. [Presentation.ViewProperties](https://reference.aspose.com/slides/net/aspose.slides/presentation/viewproperties/) geldt voor de hele presentatie.

**Kan ik verschillende weergave‑instellingen opslaan voor verschillende gebruikers?**

Het bestand slaat één set weergave‑eigenschappen op voor iedereen. Een editor kan ook de lokale voorkeuren van een gebruiker toepassen.

**Kan ik weergave‑instellingen opslaan in een sjabloon?**

Ja. Presentaties die uit het sjabloon worden gemaakt, erven de daarin opgeslagen weergave‑instellingen.