---
title: Hämta och uppdatera vyegenskaper för presentation i .NET
linktitle: Vyegenskaper
type: docs
weight: 80
url: /sv/net/presentation-view-properties/
keywords:
- vyegenskaper
- normal vy
- konturinnehåll
- konturikoner
- fäst vertikal splitter
- enkel vy
- bar-tillstånd
- dimensionstorlek
- automatisk justering
- standardzoom
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Upptäck Aspose.Slides för .NET vyegenskaper för att anpassa PPT-, PPTX- och ODP‑bilder—justera layouter, zoomnivåer och visningsinställningar."
---
## **Introduktion**

Normalvyn består av tre innehållsområden: själva bilden, ett sidoinnehållsområde och ett botteninnehållsområde. Egenskaper som rör placeringen av de olika innehållsområdena. Denna information gör att applikationen kan spara sitt vyläge i filen, så att när den öppnas igen är vyn i samma tillstånd som när presentationen senast sparades.

Egenskapen [IViewProperties.NormalViewProperties](https://reference.aspose.com/slides/sv/net/aspose.slides/iviewproperties/properties/normalviewproperties) har lagts till för att ge åtkomst till normalvyns egenskaper för en presentation.

[INormalViewProperties](https://reference.aspose.com/slides/sv/net/aspose.slides/inormalviewproperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/sv/net/aspose.slides/inormalviewrestoredproperties) gränssnitt och deras underordnade, [SplitterBarStateType](https://reference.aspose.com/slides/sv/net/aspose.slides/splitterbarstatetype) enum har lagts till.

## **Om INormalViewProperties**

Representerar normalvyns egenskaper.

Egendomen **ShowOutlineIcons** anger om applikationen ska visa ikoner när konturens innehåll visas i något av innehållsområdena i normalvyläget.

Egendomen **SnapVerticalSplitter** anger om den vertikala splittern ska fästas i ett minimerat läge när sidområdet är tillräckligt litet.

Egendomen **PreferSingleView** anger om användaren föredrar att se ett enda innehållsområde som täcker hela fönstret istället för standardnormalvyn med tre innehållsområden. Om den är aktiverad kan applikationen välja att visa ett av innehållsområdena i hela fönstret.

Egenskaperna **VerticalBarState** och **HorizontalBarState** specificerar i vilket tillstånd den horisontella eller vertikala splittern ska visas. En horisontell splittern separerar bilden från innehållsområdet under bilden, en vertikal splittern separerar bilden från sidoinnehållsområdet. Möjliga värden är: **SplitterBarStateType.Minimized, SplitterBarStateType.Maximized** och **SplitterBarStateType.Restored.**

Egenskaperna **RestoredLeft** och **RestoredTop** anger storleken på den övre eller sidobildregionen i normalvyn, när värdet **SplitterBarStateType.Restored** tillämpas för **VerticalBarState** och **HorizontalBarState** respektive.

## **Om återställning av INormalViewProperties**

Anger storleken på bildregionen (bredd när den är ett barn till RestoredTop, höjd när den är ett barn till RestoredLeft) i normalvyn, när regionen har en variabel återställd storlek (varken minimerad eller maximized).

Egendomen **DimensionSize** anger storleken på bildregionen (bredd när den är ett barn till restoredTop, höjd när den är ett barn till restoredLeft).

Egendomen **AutoAdjust** anger om storleken på sidoinnehållsområdet ska kompensera för den nya storleken vid ändring av fönstrets storlek som innehåller vyn i applikationen.

Ett exempel ges nedan som visar hur du kan komma åt **ViewProperties.NormalViewProperties**‑egenskaper för en presentation.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("demo.pptx"))
{
    pres.ViewProperties.NormalViewProperties.HorizontalBarState = SplitterBarStateType.Restored;
    pres.ViewProperties.NormalViewProperties.VerticalBarState = SplitterBarStateType.Maximized;

    // Återställ vyegenskaperna för presentationen
    pres.ViewProperties.NormalViewProperties.RestoredTop.AutoAdjust = true;
    pres.ViewProperties.NormalViewProperties.RestoredTop.DimensionSize = 80;
    pres.ViewProperties.NormalViewProperties.ShowOutlineIcons = true;

    pres.Save("presentation_normal_view_state.pptx", SaveFormat.Pptx);
}
```

## **Ange standardzoomvärdet**

Aspose.Slides för .NET stöder nu att ange standardzoomvärdet för en presentation så att när presentationen öppnas är zoom redan inställt. Detta kan göras genom att ange [ViewProperties](https://reference.aspose.com/slides/sv/net/aspose.slides/viewproperties) för en presentation. Bildvyegenskaper samt [NotesViewProperties](https://reference.aspose.com/slides/sv/net/aspose.slides/viewproperties/properties/notesviewproperties) kan ställas in programatiskt. I detta avsnitt kommer vi med ett exempel att visa hur man sätter vyegenskaperna för en presentation i Aspose.Slides.

För att ställa in vyegenskaperna, följ stegen nedan:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation)
2. Ställ in vy [Properties](https://reference.aspose.com/slides/sv/net/aspose.slides/viewproperties) för presentationen
3. Spara presentationen som en PPTX‑fil

I exemplet nedan har vi angett zoomvärdet för bildvyn såväl som notvyn.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("demo.pptx"))
{
    // Ställer in vyegenskaperna för presentationen
    presentation.ViewProperties.SlideViewProperties.Scale = 100; // Zoomvärde i procent för bildvyn
    presentation.ViewProperties.NotesViewProperties.Scale = 100; // Zoomvärde i procent för notvyn 

    presentation.Save("Zoom_out.pptx", SaveFormat.Pptx);
}
```

## **Ange rutnätets avstånd**

Använd [Presentation.ViewProperties](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/viewproperties/) för att komma åt vyinställningar som gäller för hela presentationen. Egenskapen [IViewProperties.GridSpacing](https://reference.aspose.com/slides/sv/net/aspose.slides/iviewproperties/gridspacing/) läser eller ändrar intervallet för det underliggande redigeringsrutnätet. Denna inställning gäller hela presentationen, inte en enskild bild. Rutnätsavstånd anges i punkter, där 72 punkter motsvarar en tum. Använd ett positivt värde, enligt API‑dokumentationen.

Följande exempel öppnar en befintlig `demo.pptx`, skriver ut dess aktuella rutnätsavstånd, sätter ett kvart‑tum‑intervall och sparar resultatet.

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

Rutnätet skiljer sig från [drawing guides](/slides/sv/net/drawing-guides/). Rutnätsavstånd styr ett regelbundet intervall, medan ritguider är individuellt placerade horisontella eller vertikala linjer för justering. Att lägga till, flytta eller rensa ritguider ändrar inte rutnätsavståndet.

Både rutnätet och ritguiderna är redigeringshjälpmedel. De renderas inte som bildinnehåll i PDF, bilder, SVG eller ett bildspel. Att lagra rutnätsavståndet garanterar inte att en redigerare visar rutnätet: dess synlighet beror också på visarens eller redigerarens inställningar.

## **Vanliga frågor**

**Varför är rutnätet inte synligt när jag öppnar presentationen igen?**

Filen lagrar rutnätsavståndet, men redigeraren styr om rutnätet visas. Kontrollera redigerarens inställningar för rutnätsvisning.

**Ändrar rensning av ritguider rutnätsavståndet?**

Nej. Ritguider och rutnätsavstånd är oberoende inställningar. Att rensa guider lämnar det lagrade rutnätsintervallet oförändrat.

**Kan jag ange olika vyinställningar för olika sektioner i en presentation?**

[View settings](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/viewproperties/) definieras på presentationsnivå ([Normal View](https://reference.aspose.com/slides/sv/net/aspose.slides/viewproperties/normalviewproperties/)/[Slide View](https://reference.aspose.com/slides/sv/net/aspose.slides/viewproperties/slideviewproperties/)), inte per sektion, så ett enda uppsättning parametrar gäller för hela dokumentet när det öppnas.

**Kan jag fördefiniera olika vylägen för olika användare?**

Nej. Inställningarna lagras i filen och delas. Visningsprogram kan ta hänsyn till användarens preferenser, men filen själv innehåller bara en uppsättning vyegenskaper.

**Kan jag förbereda en mall med fördefinierade vyegenskaper så att nya presentationer öppnas på samma sätt?**

Ja. Eftersom [view properties](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/viewproperties/) lagras på presentationsnivå kan du bädda in dem i en mall och skapa nya dokument från den med samma initiala vykonfiguration.