---
title: Hämta och uppdatera presentationsvyegenskaper i .NET
linktitle: Vyegenskaper
type: docs
weight: 80
url: /sv/net/presentation-view-properties/
keywords:
- vyegenskaper
- normal vy
- dispositionsinnehåll
- dispositionsikoner
- fäst vertikal delare
- ensam vy
- fältstatus
- dimensionstorlek
- automatisk justering
- standardzoom
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Upptäck Aspose.Slides för .NET vyegenskaper för att anpassa format PPT, PPTX och ODP-bilder—justera layouter, zoomnivåer och visningsinställningar."
---
## **Introduktion**

Den normala vyn består av tre innehållsområden: själva bilden, ett sidoinnehållsområde och ett botteninnehållsområde. Egenskaper som rör placeringen av de olika innehållsområdena. Denna information gör att applikationen kan spara vyns tillstånd till filen, så att när den öppnas igen är vyn i samma tillstånd som när presentationen senast sparades.

Egenskapen [IViewProperties.NormalViewProperties](https://reference.aspose.com/slides/sv/net/aspose.slides/iviewproperties/properties/normalviewproperties) har lagts till för att ge åtkomst till normalvyns egenskaper för presentationen.

[INormalViewProperties](https://reference.aspose.com/slides/sv/net/aspose.slides/inormalviewproperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/sv/net/aspose.slides/inormalviewrestoredproperties) gränssnitt och deras underklasser, samt [SplitterBarStateType](https://reference.aspose.com/slides/sv/net/aspose.slides/splitterbarstatetype) enum har lagts till.

## **Om INormalViewProperties**

Representerar normalvyns egenskaper.

Egenskapen **ShowOutlineIcons** anger om applikationen ska visa ikoner när dispositionens innehåll visas i något av innehållsområdena i normalvyläget.

Egenskapen **SnapVerticalSplitter** anger om den vertikala delaren ska låsas i ett minimerat läge när sidoregionen är tillräckligt liten.

Egenskapen **PreferSingleView** anger om användaren föredrar att se ett enda innehållsområde som fyller hela fönstret istället för den standardmässiga normalvyn med tre innehållsområden. Om den är aktiverad kan applikationen välja att visa ett av innehållsområdena i hela fönstret.

Egenskaperna **VerticalBarState** och **HorizontalBarState** specificerar i vilket tillstånd den horisontella respektive vertikala delarbalken ska visas. En horisontell delarbalk separerar bilden från innehållsområdet under bilden, en vertikal delarbalk separerar bilden från sidoinnehållsområdet. Möjliga värden är: **SplitterBarStateType.Minimized, SplitterBarStateType.Maximized** och **SplitterBarStateType.Restored.**

Egenskaperna **RestoredLeft** och **RestoredTop** anger storleken på det övre eller sidogestalta bilden i normalvyn när värdet **SplitterBarStateType.Restored** används för **VerticalBarState** respektive **HorizontalBarState**.

## **Om återställning av INormalViewProperties**

Anger storleken på bildområdet (bredd när det är ett barn till RestoredTop, höjd när det är ett barn till RestoredLeft) i normalvyn, när området har en variabel återställd storlek (varken minimerad eller maximerad).

Egenskapen **DimensionSize** specificerar storleken på bildområdet (bredd när det är ett barn till restoredTop, höjd när det är ett barn till restoredLeft).

Egenskapen **AutoAdjust** anger om storleken på sidoinnehållsområdet ska justeras för den nya storleken när fönstret som innehåller vyn i applikationen ändras.

Ett exempel ges nedan som visar hur du kan komma åt egenskaperna **ViewProperties.NormalViewProperties** för en presentation.

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

## **Ställ in standardzoomvärdet**

Aspose.Slides för .NET stödjer nu att ange ett standardzoomvärde för presentationer så att zoomen redan är satt när presentationen öppnas. Detta kan göras genom att ställa in [ViewProperties](https://reference.aspose.com/slides/sv/net/aspose.slides/viewproperties) för en presentation. Slide View Properties samt [NotesViewProperties](https://reference.aspose.com/slides/sv/net/aspose.slides/viewproperties/properties/notesviewproperties) kan ställas in programatiskt. I detta avsnitt ser vi med ett exempel hur man sätter vyegenskaperna för en presentation i Aspose.Slides.

För att ställa in vyegenskaperna, följ stegen nedan:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation)
1. Ställ in View [Properties](https://reference.aspose.com/slides/sv/net/aspose.slides/viewproperties) för presentationen
1. Skriv presentationen som en PPTX‑fil

I exemplet nedan har vi satt zoomvärdet för bildvyn samt notvyn.

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

## **Ställ in rutnätets avstånd**

Använd [Presentation.ViewProperties](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/viewproperties/) för att komma åt visningsinställningar på presentationsnivå. Egenskapen [IViewProperties.GridSpacing](https://reference.aspose.com/slides/sv/net/aspose.slides/iviewproperties/gridspacing/) läser eller ändrar intervallet för det underliggande redigeringsrutnätet. Denna inställning gäller hela presentationen, inte en enskild bild. Rutnätsavstånd anges i punkter, där 72 punkter motsvarar en tum. Använd ett positivt värde, enligt API‑dokumentationen.

Följande exempel öppnar en befintlig `demo.pptx`, skriver ut dess nuvarande rutnätsavstånd, sätter ett kvart tum‑intervall och sparar resultatet.

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

Rutnätet skiljer sig från [drawing guides](/slides/sv/net/drawing-guides/). Rutnätsavstånd styr ett regelbundet intervall, medan ritlinjer är individuellt placerade horisontella eller vertikala justeringslinjer. Att lägga till, flytta eller rensa ritlinjer ändrar inte rutnätsavståndet.

Både rutnätet och ritlinjerna är hjälpmedel för redigering. De renderas inte som bildinnehåll i PDF, bilder, SVG eller bildspel. Att lagra rutnätsavståndet garanterar inte att en redigerare visar rutnätet: dess synlighet beror också på visnings‑ eller redigerarens inställningar.

## **Visa eller dölja kommentarer när en presentation öppnas**

Använd [Presentation.ViewProperties](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/viewproperties/) för att komma åt visningsinställningar på presentationsnivå. Läs eller ändra [IViewProperties.ShowComments](https://reference.aspose.com/slides/sv/net/aspose.slides/iviewproperties/showcomments/) för att lagra en preferens om huruvida kommentarer ska visas när presentationen öppnas i PowerPoint eller en annan kompatibel redigerare.

Denna inställning styr endast den lagrade visningspreferensen. Den lägger inte till, tar bort, redigerar eller löser kommentarer. Att dölja kommentarer bevarar deras innehåll, författare, positioner, svar och statusar. Se [Presentation Comments](/slides/sv/net/presentation-comments/) för operationer som ändrar kommentarerna själva.

Följande exempel kräver en befintlig `comments.pptx` som innehåller kommentarer. Det skriver ut den aktuella synlighetsinställningen, begär att kommentarer ska döljas och sparar en ny PPTX utan att ta bort några kommentarer. Det sätter också [IViewProperties.LastView](https://reference.aspose.com/slides/sv/net/aspose.slides/iviewproperties/lastview/) till [ViewType.SlideView](https://reference.aspose.com/slides/sv/net/aspose.slides/viewtype/) för att konfigurera den initiala redigeringsvyn tillsammans med kommentarernas synlighet.

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

Denna inställning bestämmer inte om kommentarer inkluderas i PDF-, HTML-, bild-, antecknings‑ eller handout‑export. Konfigurera respektive export‑specifika alternativ separat.

## **FAQ**

**Varför är rutnätet inte synligt när jag öppnar presentationen igen?**

Filen lagrar rutnätsavståndet, men redigeraren styr om rutnätet visas. Kontrollera redigerarens inställningar för rutnätsynlighet.

**Ändrar rensning av ritlinjer rutnätsavståndet?**

Nej. Ritlinjer och rutnätsavstånd är oberoende inställningar. Att rensa ritlinjer lämnar det lagrade rutnätsintervallet oförändrat.

**Kan jag ange olika visningsinställningar för olika avsnitt i en presentation?**

[View settings](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/viewproperties/) definieras på presentationsnivå ([Normal View](https://reference.aspose.com/slides/sv/net/aspose.slides/viewproperties/normalviewproperties/)/[Slide View](https://reference.aspose.com/slides/sv/net/aspose.slides/viewproperties/slideviewproperties/)), inte per avsnitt, så en enda uppsättning parametrar gäller för hela dokumentet när det öppnas.

**Kan jag fördefiniera olika visningstillstånd för olika användare?**

Nej. Inställningarna lagras i filen och delas. Visningsprogram kan ta hänsyn till användarpreferenser, men filen själv innehåller endast en uppsättning vyegenskaper.

**Kan jag skapa en mall med fördefinierade View Properties så att nya presentationer öppnas på samma sätt?**

Ja. Eftersom [view properties](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/viewproperties/) lagras på presentationsnivå kan du bädda in dem i en mall och skapa nya dokument från den med samma initiala vykonfiguration.