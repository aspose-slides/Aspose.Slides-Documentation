---
title: Hämta och uppdatera presentationsvyegenskaper i Python
linktitle: Vyegenskaper
type: docs
weight: 80
url: /sv/python-net/presentation-view-properties/
keywords:
- vyegenskaper
- normalvy
- dispositionsinnehåll
- dispositionsikoner
- snappa vertikal delare
- enkel vy
- stapeltillstånd
- dimensionsstorlek
- automatisk justering
- standardzoom
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Upptäck Aspose.Slides för Python via .NET vyegenskaper för att anpassa PPT-, PPTX- och ODP-bilder—justera layouter, zoomnivåer och visningsinställningar."
---
## **Introduktion**

Det normala vyn består av tre innehållsområden: själva bilden, ett sidoinnehållsområde och ett botteninnehållsområde. Egenskaper som rör placeringen av de olika innehållsområdena. Denna information gör att applikationen kan spara vyns tillstånd till filen, så att när den öppnas igen är vyn i samma tillstånd som när presentationen senast sparades.

Egenskapen [ViewProperties.normal_view_properties](https://reference.aspose.com/slides/sv/python-net/aspose.slides/viewproperties/normal_view_properties/) har lagts till för att ge åtkomst till normalvyegenskaper för presentation.

Klasserna [NormalViewProperties](https://reference.aspose.com/slides/sv/python-net/aspose.slides/normalviewproperties/), [NormalViewRestoredProperties](https://reference.aspose.com/slides/sv/python-net/aspose.slides/normalviewrestoredproperties/) och deras underklasser, samt enumet [SplitterBarStateType](https://reference.aspose.com/slides/sv/python-net/aspose.slides/splitterbarstatetype/) har lagts till.

## **Om INormalViewProperties**

Representerar normala vyegenskaper.

Egenskapen **ShowOutlineIcons** anger om applikationen ska visa ikoner när dispositionen visas i något av innehållsområdena i normalläget.

Egenskapen **SnapVerticalSplitter** anger om den vertikala delaren ska hakas fast i ett minimerat tillstånd när sidområdet är tillräckligt litet.

Egenskapen **PreferSingleView** anger om användaren föredrar att se ett fullständigt fönsterrum för en enda innehållsregion istället för standardnormalläget med tre innehållsområden. Om den är aktiverad kan applikationen välja att visa en av innehållsområdena i hela fönstret.

Egenskaperna **VerticalBarState** och **HorizontalBarState** anger i vilket tillstånd den horisontella eller vertikala delarlisten ska visas. En horisontell delarlist separerar bilden från innehållsområdet under bilden, en vertikal delarlist separerar bilden från sidoinnehållsområdet. Möjliga värden är: **SplitterBarStateType.Minimized, SplitterBarStateType.Maximized** och **SplitterBarStateType.Restored**.

Egenskaperna **RestoredLeft** och **RestoredTop** anger storleken på den övre eller sidobildregionen i normalvyn, när värdet **SplitterBarStateType.Restored** tillämpas på **VerticalBarState** respektive **HorizontalBarState**.

## **Om återställning av INormalViewProperties**

Anger storleken på bildregionen (bredd när den är ett barn till RestoredTop, höjd när den är ett barn till RestoredLeft) i normalvyn, när regionen har en variabel återställd storlek (varken minimerad eller maximerad).

Egenskapen **DimensionSize** anger storleken på bildregionen (bredd när den är ett barn till restoredTop, höjd när den är ett barn till restoredLeft).

Egenskapen **AutoAdjust** anger om sidoinnehållsområdets storlek ska kompensera för den nya storleken när fönstret som innehåller vyn i applikationen ändras storlek.

Ett exempel ges nedan som visar hur du kan komma åt **ViewProperties.NormalViewProperties**‑egenskaper för en presentation.

```py
import aspose.slides as slides

with slides.Presentation("AccessSlides.pptx") as pres:
    pres.view_properties.normal_view_properties.horizontal_bar_state = slides.SplitterBarStateType.RESTORED
    pres.view_properties.normal_view_properties.vertical_bar_state = slides.SplitterBarStateType.MAXIMIZED

    # Återställ vyegenskaperna för presentationen
    pres.view_properties.normal_view_properties.restored_top.auto_adjust = True
    pres.view_properties.normal_view_properties.restored_top.dimension_size = 80
    pres.view_properties.normal_view_properties.show_outline_icons = True

    pres.save("presentation_normal_view_state.pptx", slides.export.SaveFormat.PPTX)
```

## **Ställ in standardzoomvärde**

Aspose.Slides för Python via .NET stöder nu att ställa in standardzoomvärdet för en presentation så att när presentationen öppnas är zoomen redan satt. Detta kan göras genom att ange [view_properties](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/view_properties/) för en presentation. Bildvyesegenskaper samt [notes_view_properties](https://reference.aspose.com/slides/sv/python-net/aspose.slides/viewproperties/notes_view_properties/) kan ställas in programmatiskt. I detta ämne kommer vi med ett exempel att visa hur man sätter View Properties för en Presentation i Aspose.Slides.

För att ställa in vyesegenskaperna, följ stegen nedan:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/)
1. Ange [view properties](https://reference.aspose.com/slides/sv/python-net/aspose.slides/viewproperties/) för presentationen
1. Spara presentationen som en PPTX‑fil

I exemplet nedan har vi ställt in zoomvärdet för bildvyn samt notvyn.

```py
import aspose.slides as slides

with slides.Presentation("AccessSlides.pptx") as presentation:
    # Ställer in vyegenskaperna för presentationen
    presentation.view_properties.slide_view_properties.scale = 100 # Zoomvärde i procent för bildvyn
    presentation.view_properties.notes_view_properties.scale = 100 # Zoomvärde i procent för anteckningsvyn 

    presentation.save("Zoom_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Ställ in rutnätsavståndet**

Använd [Presentation.view_properties](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/view_properties/) för att komma åt vyinställningar för hela presentationen. Egenskapen [ViewProperties.grid_spacing](https://reference.aspose.com/slides/sv/python-net/aspose.slides/viewproperties/grid_spacing/) läser eller ändrar intervallet för det underliggande redigeringsrutnätet. Denna inställning gäller hela presentationen, inte en enskild bild. Rutnätsavstånd anges i punkter, där 72 punkter motsvarar en tum. Använd ett positivt värde enligt API‑dokumentationen.

Följande exempel öppnar en befintlig `demo.pptx`, skriver ut dess aktuella rutnätsavstånd, sätter ett kvart‑tumsintervall och sparar resultatet.

```py
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    grid_spacing = presentation.view_properties.grid_spacing
    print(f"Current grid spacing: {grid_spacing} points")

    presentation.view_properties.grid_spacing = 18.0
    presentation.save("grid-spacing.pptx", slides.export.SaveFormat.PPTX)
```

Rutnätet skiljer sig från [drawing guides](/slides/sv/python-net/drawing-guides/). Rutnätsavstånd styr ett regelbundet intervall, medan ritningsguider är individuellt placerade horisontella eller vertikala justeringslinjer. Att lägga till, flytta eller rensa ritningsguider ändrar inte rutnätsavståndet.

Både rutnätet och ritningsguiderna är hjälpmedel för redigering. De renderas inte som bildinnehåll i PDF, bilder, SVG eller bildspel. Att lagra rutnätsavståndet garanterar inte att en redigerare visar rutnätet: dess synlighet beror även på tittarens eller redigerarens inställningar.

## **FAQ**

**Varför är rutnätet inte synligt när jag öppnar presentationen igen?**

Filen lagrar rutnätsavståndet, men redigeraren bestämmer om rutnätet visas. Kontrollera redigerarens inställningar för rutnätsynlighet.

**Ändrar rensning av ritningsguider rutnätsavståndet?**

Nej. Ritningsguider och rutnätsavstånd är oberoende inställningar. Att rensa guider lämnar det lagrade rutnätsintervallet oförändrat.

**Kan jag ställa in olika vyinställningar för olika avsnitt i en presentation?**

[View settings](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/view_properties/) definieras på presentationsnivå ([Normal View](https://reference.aspose.com/slides/sv/python-net/aspose.slides/viewproperties/normal_view_properties/)/[Slide View](https://reference.aspose.com/slides/sv/python-net/aspose.slides/viewproperties/slide_view_properties/)), inte per avsnitt, så ett enda parameteruppsättning gäller för hela dokumentet när det öppnas.

**Kan jag fördefiniera olika vylägen för olika användare?**

Nej. Inställningarna lagras i filen och delas. Visningsprogram kan respektera användarinställningar, men filen själv innehåller endast ett set av vyegenskaper.

**Kan jag förbereda en mall med fördefinierade vyegenskaper så att nya presentationer öppnas på samma sätt?**

Ja. Eftersom [view properties](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/view_properties/) lagras på presentationsnivå kan du bädda in dem i en mall och skapa nya dokument från den med samma initiala vykonfiguration.