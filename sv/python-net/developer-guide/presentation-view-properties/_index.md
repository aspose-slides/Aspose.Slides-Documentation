---
title: Hämta och uppdatera presentationsvy‑egenskaper i Python
linktitle: Vy‑egenskaper
type: docs
weight: 80
url: /sv/python-net/presentation-view-properties/
keywords: 
- vy‑egenskaper
- normalvy
- dispositionsinnehåll
- dispositionsikoner
- fäst vertikal delare
- enkelvy
- balkstatus
- dimensionstorlek
- automatisk justering
- standardzoom
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Upptäck Aspose.Slides för Python via .NET vy‑egenskaper för att anpassa format PPT, PPTX och ODP‑bilder—justera layouter, zoomnivåer och visningsinställningar."
---
## **Introduktion**

Normalvyn består av tre innehållsregioner: själva bilden, en sidoinnehållsregion och en botteninnehållsregion. Egenskaper som rör positioneringen av de olika innehållsregionerna. Denna information gör att programmet kan spara visningsstatusen till filen, så att när den öppnas igen är vyn i samma tillstånd som när presentationen senast sparades.

Egenskapen [ViewProperties.normal_view_properties](https://reference.aspose.com/slides/sv/python-net/aspose.slides/viewproperties/normal_view_properties/) har lagts till för att ge åtkomst till normalvyns egenskaper för en presentation.  

[NormalViewProperties](https://reference.aspose.com/slides/sv/python-net/aspose.slides/normalviewproperties/), [NormalViewRestoredProperties](https://reference.aspose.com/slides/sv/python-net/aspose.slides/normalviewrestoredproperties/) klasser och deras underklasser, [SplitterBarStateType](https://reference.aspose.com/slides/sv/python-net/aspose.slides/splitterbarstatetype/) enum har lagts till.

## **Om INormalViewProperties**

Representerar normalvyns egenskaper.

Egendomen **ShowOutlineIcons** specificerar huruvida programmet ska visa ikoner när dispositionsinnehåll visas i någon av innehållsregionerna i normalvyläge.

Egendomen **SnapVerticalSplitter** specificerar huruvida den vertikala delaren ska klämmas till ett minimerat tillstånd när sidoregionen är tillräckligt liten.

Egendomen **PreferSingleView** specificerar om användaren föredrar att se en hel‑fönster enkel‑innehållsregion istället för den vanliga normalvyn med tre innehållsregioner. Om den är aktiverad kan programmet välja att visa en av innehållsregionerna i hela fönstret.

Egenskaperna **VerticalBarState** och **HorizontalBarState** anger i vilket tillstånd den horisontella eller vertikala delarbalken ska visas. En horisontell delarbalk separerar bilden från innehållsregionen under bilden, en vertikal delarbalk separerar bilden från sidoinnehållsregionen. Möjliga värden är: **SplitterBarStateType.Minimized, SplitterBarStateType.Maximized** och **SplitterBarStateType.Restored**.

Egenskaperna **RestoredLeft** och **RestoredTop** specificerar storleken på den övre eller sidobildregionen i normalvyn, när värdet **SplitterBarStateType.Restored** tillämpas på **VerticalBarState** respektive **HorizontalBarState**.

## **Om återställning av INormalViewProperties**

Anger storleken på bildregionen (bredd när den är ett underobjekt till RestoredTop, höjd när den är ett underobjekt till RestoredLeft) i normalvyn, när regionen har en variabel återställd storlek (varken minimerad eller maximerad).

Egendomen **DimensionSize** specificerar storleken på bildregionen (bredd när den är ett underobjekt till restoredTop, höjd när den är ett underobjekt till restoredLeft).

Egendomen **AutoAdjust** specificerar om storleken på sidoinnehållsregionen ska kompensera för den nya storleken när fönstret som innehåller vyn i programmet ändras i storlek.

Ett exempel nedan visar hur du kan komma åt **ViewProperties.NormalViewProperties**‑egenskaper för en presentation.

```py
import aspose.slides as slides

with slides.Presentation("AccessSlides.pptx") as pres:
    pres.view_properties.normal_view_properties.horizontal_bar_state = slides.SplitterBarStateType.RESTORED
    pres.view_properties.normal_view_properties.vertical_bar_state = slides.SplitterBarStateType.MAXIMIZED

    # Återställ vy-egenskaperna för presentationen
    pres.view_properties.normal_view_properties.restored_top.auto_adjust = True
    pres.view_properties.normal_view_properties.restored_top.dimension_size = 80
    pres.view_properties.normal_view_properties.show_outline_icons = True

    pres.save("presentation_normal_view_state.pptx", slides.export.SaveFormat.PPTX)
```

## **Ställ in standardzoomvärde**

Aspose.Slides för Python via .NET stöder nu att ange standardzoomvärdet för en presentation så att när presentationen öppnas är zoomen redan inställd. Detta kan göras genom att ställa in [view_properties](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/view_properties/) för en presentation. Bildvyeegenskaper samt [notes_view_properties](https://reference.aspose.com/slides/sv/python-net/aspose.slides/viewproperties/notes_view_properties/) kan sättas programatiskt. I det här avsnittet visar vi med ett exempel hur man sätter vy‑egenskaperna för en presentation i Aspose.Slides.

För att ställa in vy‑egenskaperna, följ stegen nedan:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/)
1. Ställ in [view properties](https://reference.aspose.com/slides/sv/python-net/aspose.slides/viewproperties/) för presentationen
1. Spara presentationen som en PPTX‑fil

```py
import aspose.slides as slides

with slides.Presentation("AccessSlides.pptx") as presentation:
    # Ställer in vy‑egenskaperna för presentationen
    presentation.view_properties.slide_view_properties.scale = 100 # Zoomvärde i procent för bildvyn
    presentation.view_properties.notes_view_properties.scale = 100 # Zoomvärde i procent för anteckningsvyn 

    presentation.save("Zoom_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Ställ in rutnätets avstånd**

Använd [Presentation.view_properties](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/view_properties/) för att komma åt vy‑inställningarna för hela presentationen. Egenskapen [ViewProperties.grid_spacing](https://reference.aspose.com/slides/sv/python-net/aspose.slides/viewproperties/grid_spacing/) läser eller ändrar intervallet för det underliggande redigeringsrutnätet. Denna inställning gäller för hela presentationen, inte för en enskild bild. Rutnätsavståndet anges i punkter, där 72 punkter motsvarar en tum. Använd ett positivt värde, enligt API‑dokumentationen.

Följande exempel öppnar en befintlig `demo.pptx`, skriver ut dess aktuella rutnätsavstånd, ställer in ett kvart‑tumsintervall och sparar resultatet.

```py
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    grid_spacing = presentation.view_properties.grid_spacing
    print(f"Current grid spacing: {grid_spacing} points")

    presentation.view_properties.grid_spacing = 18.0
    presentation.save("grid-spacing.pptx", slides.export.SaveFormat.PPTX)
```

Rutnätet skiljer sig från [drawing guides](/slides/sv/python-net/drawing-guides/). Rutnätsavståndet styr ett regelbundet intervall, medan ritningsguider är individuellt placerade horisontella eller vertikala justeringslinjer. Att lägga till, flytta eller rensa ritningsguider förändrar inte rutnätsavståndet.

Både rutnätet och ritningsguiderna är redigeringshjälpmedel. De renderas inte som bildinnehåll i PDF, bilder, SVG eller en bildspelsvisning. Att lagra rutnätsavståndet garanterar inte att en redigerare visar rutnätet: dess synlighet beror också på visnings‑ eller redigerarens inställningar.

## **Visa eller dölja kommentarer när en presentation öppnas**

Använd [Presentation.view_properties](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/view_properties/) för att komma åt vy‑inställningarna för hela presentationen. Läs eller ändra [ViewProperties.show_comments](https://reference.aspose.com/slides/sv/python-net/aspose.slides/viewproperties/show_comments/) för att lagra en preferens för huruvida kommentarer ska visas när presentationen öppnas i PowerPoint eller en annan kompatibel redigerare.

Den här inställningen styr endast den lagrade vy‑preferensen. Den lägger inte till, tar bort, redigerar eller löser kommentarer. Att dölja kommentarer bevarar deras innehåll, författare, positioner, svar och status. Se [Presentation Comments](/slides/sv/python-net/presentation-comments/) för operationer som ändrar kommentarerna själva.

Följande exempel kräver en befintlig `comments.pptx` som innehåller kommentarer. Det skriver ut den aktuella synlighetsinställningen, begär att kommentarer döljs och sparar en ny PPTX utan att ta bort några kommentarer. Det sätter också [ViewProperties.last_view](https://reference.aspose.com/slides/sv/python-net/aspose.slides/viewproperties/last_view/) till [ViewType.SLIDE_VIEW](https://reference.aspose.com/slides/sv/python-net/aspose.slides/viewtype/) för att konfigurera den initiala redigeringsvyn tillsammans med kommentarsynlighet.

```py
import aspose.slides as slides

with slides.Presentation("comments.pptx") as presentation:
    show_comments = presentation.view_properties.show_comments
    print(f"Current comment visibility: {show_comments}")

    presentation.view_properties.show_comments = slides.NullableBool.FALSE
    presentation.view_properties.last_view = slides.ViewType.SLIDE_VIEW
    presentation.save("comments-hidden.pptx", slides.export.SaveFormat.PPTX)
```

Den här inställningen avgör inte om kommentarer inkluderas i PDF-, HTML-, bild-, antecknings‑ eller utdelnings‑exporter. Konfigurera de relevanta export‑specifika alternativen separat.

## **FAQ**

**Varför är rutnätet inte synligt när jag öppnar presentationen igen?**

Filen lagrar rutnätsavståndet, men redigeraren styr om rutnätet visas. Kontrollera redigerarens inställningar för rutnätsynlighet.

**Ändrar rensning av ritningsguider rutnätsavståndet?**

Nej. Ritningsguider och rutnätsavstånd är oberoende inställningar. Att rensa guider lämnar det lagrade rutnätsintervallet oförändrat.

**Kan jag ange olika vy‑inställningar för olika sektioner i en presentation?**

[View settings](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/view_properties/) definieras på presentationsnivå ([Normal View](https://reference.aspose.com/slides/sv/python-net/aspose.slides/viewproperties/normal_view_properties/)/[Slide View](https://reference.aspose.com/slides/sv/python-net/aspose.slides/viewproperties/slide_view_properties/)), inte per sektion, så ett enda uppsättning parametrar gäller för hela dokumentet när det öppnas.

**Kan jag fördefiniera olika vy‑tillstånd för olika användare?**

Nej. Inställningarna lagras i filen och delas. Visningsprogram kan ta hänsyn till användarpreferenser, men filen själv innehåller en enda uppsättning vy‑egenskaper.

**Kan jag förbereda en mall med fördefinierade View Properties så att nya presentationer öppnas på samma sätt?**

Ja. Eftersom [view properties](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/view_properties/) lagras på presentationsnivå kan du bädda in dem i en mall och skapa nya dokument från den med samma initiala vy‑konfiguration.