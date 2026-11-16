---
title: Hämta och uppdatera presentationsvyegenskaper i .NET
linktitle: Vyegenskaper
type: docs
weight: 80
url: /sv/net/presentation-view-properties/
keywords:
- vyegenskaper
- normalläge
- dispositionsinnehåll
- dispositionsikoner
- fästa vertikal delare
- enkel vy
- stapeltillstånd
- dimensionstorlek
- automatisk justering
- standardzoom
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Använd Aspose.Slides för .NET för att konfigurera normalvylayout, bild- och noteringszoom, rutnätsavstånd och kommentarsynlighet i PowerPoint-presentationer."
---
## **Introduktion**

I PowerPoints normalläge visas bilden mellan ett sidofält för miniatyrer eller en disposition och ett noteringsfält nedanför. Aspose.Slides for .NET exponerar presentationens sparade redigeringsinställningar via [Presentation.ViewProperties](https://reference.aspose.com/slides/net/aspose.slides/presentation/viewproperties/). Dessa inkluderar fältlayout, zoomnivåer, rutnätsavstånd och kommentarer synlighet.

## **Om INormalViewProperties**

Använd [NormalViewProperties](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/normalviewproperties/) för att komma åt [INormalViewProperties](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/) gränssnittet. [ShowOutlineIcons](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/showoutlineicons/) styr om ikoner visas bredvid bildrubriker i dispositionen. [SnapVerticalSplitter](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/snapverticalsplitter/) låter sidofältet fästa sig i sitt minimerade tillstånd när användaren minskar det. [PreferSingleView](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/prefersingleview/) indikerar en preferens för att visa ett fält i hela fönstret.

[VerticalBarState](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/verticalbarstate/) styr avdelaren mellan sidofältet och bilden. [HorizontalBarState](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/horizontalbarstate/) styr avdelaren ovanför noteringsfältet. Båda accepterar ett [SplitterBarStateType](https://reference.aspose.com/slides/net/aspose.slides/splitterbarstatetype/) värde av `Minimized`, `Maximized` eller `Restored`.

## **Om återställning av INormalViewProperties**

När en avdelare återställs, tillhandahåller [RestoredLeft](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/restoredleft/) den sparade storleken på sidofältet och [RestoredTop](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/restoredtop/) den sparade storleken på det övre bildområdet. Båda exponerar [INormalViewRestoredProperties](https://reference.aspose.com/slides/net/aspose.slides/inormalviewrestoredproperties/). Dess [DimensionSize](https://reference.aspose.com/slides/net/aspose.slides/inormalviewrestoredproperties/dimensionsize/) egenskap accepterar en procentsats från 0 till 100, och [AutoAdjust](https://reference.aspose.com/slides/net/aspose.slides/inormalviewrestoredproperties/autoadjust/) styr om redigeraren justerar storleken när fönstret ändras i storlek.

Detta exempel uppdaterar en befintlig presentation. Det återställer den horisontella avdelaren, sätter [RestoredTop](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/restoredtop/) till 80% med automatisk justering aktiverad, och maximerar den vertikala avdelaren. Det aktiverar också [ShowOutlineIcons](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/showoutlineicons/) för dispositionsvy.

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

## **Ställ in standardzoomnivå**

[SlideViewProperties](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/slideviewproperties/) och [NotesViewProperties](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/notesviewproperties/) lagrar oberoende zoomininställningar för redigeraren. Dessa inställningar påverkar inte bildens dimensioner, bildspelsuppspelning eller exportupplösning för bilder.

Detta exempel öppnar en befintlig presentation och aktiverar [VariableScale](https://reference.aspose.com/slides/net/aspose.slides/icommonslideviewproperties/variablescale/) för att anpassa bilden till redigeringsfönstret. För noteringssidan inaktiveras automatisk skalning och [Scale](https://reference.aspose.com/slides/net/aspose.slides/icommonslideviewproperties/scale/) sätts till en fast 80% zoom.

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

## **Ställ in rutnätsavståndet**

[GridSpacing](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/gridspacing/) anger avståndet mellan redigeringsrutnätslinjer i hela presentationen. Den tar ett positivt värde i punkter, med 72 punkter per tum. Detta exempel skriver ut det aktuella avståndet i en befintlig presentation och sparar ett rutnät på en fjärdedels tum genom att sätta intervallet till 18 punkter.

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

Rutnätet upprepas med ett fast intervall. [Drawing guides](/slides/sv/net/drawing-guides/) markerar enskilda horisontella eller vertikala positioner. Båda är redigeringshjälpmedel och visas endast i redigerare som visar dem. Bildspel och export till PDF, bilder eller SVG utesluter dem.

## **Visa eller dölja kommentarer vid öppning av en presentation**

[ShowComments](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/showcomments/) lagrar en preferens som kompatibla redigerare använder när de öppnar presentationen. För en befintlig presentation med kommentarer skriver detta exempel ut den aktuella inställningen och sparar en kopia med kommentarer dolda. Det sätter också [LastView](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/lastview/) till [ViewType.SlideView](https://reference.aspose.com/slides/net/aspose.slides/viewtype/) så att kopian öppnas i bildvyn.

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

Att dölja kommentarer bevarar deras text, författare, positioner, svar och status. För att ändra kommentarerna själva, se [Presentation Comments](/slides/sv/net/presentation-comments/). Exportinställningar styr om kommentarer visas i PDF, HTML, bilder, anteckningar eller handouts.

## **FAQ**

**Varför är rutnätet dolt när jag öppnar presentationen igen?**

Presentationen lagrar rutnätsintervallet. För att se rutnätet, aktivera rutnätsvisning i redigeraren.

**Ändrar rensning av ritningsguider rutnätsavståndet?**

Nej. Att lägga till, flytta eller rensa en guide lämnar rutnätsintervallet oförändrat.

**Kan olika sektioner i en presentation ha olika vyinställningar?**

Nej. [Presentation.ViewProperties](https://reference.aspose.com/slides/net/aspose.slides/presentation/viewproperties/) gäller för hela presentationen.

**Kan jag spara olika vyinställningar för olika användare?**

Filen lagrar en uppsättning vyegenskaper för alla. En redigerare kan också tillämpa en användares lokala preferenser.

**Kan jag spara vyinställningar i en mall?**

Ja. Presentationer som skapas från mallen ärver dess sparade vyinställningar.