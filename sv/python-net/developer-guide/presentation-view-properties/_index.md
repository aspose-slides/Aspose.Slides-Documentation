---
title: Hämta och uppdatera presentationsvyegenskaper i Python
linktitle: Vyegenskaper
type: docs
weight: 80
url: /sv/python-net/presentation-view-properties/
keywords:
- vyegenskaper
- normal vy
- dispositionsinnehåll
- dispositionsikoner
- fäst vertikal delare
- enkel vy
- stapeltillstånd
- dimensionsstorlek
- automatisk justering
- standardzoom
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Upptäck Aspose.Slides för Python via .NET vyegenskaper för att anpassa PPT-, PPTX- och ODP‑bilder—justera layouter, zoomnivåer och visningsinställningar."
---
## **Introduktion**

Den normala vyn består av tre innehållsområden: själva bilden, ett sidoinnehållsområde och ett botteninnehållsområde. Egenskaper som rör placeringen av de olika innehållsområdena. Denna information gör det möjligt för applikationen att spara vyns tillstånd till filen, så att när den öppnas igen är vyn i samma tillstånd som när presentationen senast sparades.

Egenskapen [ViewProperties.normal_view_properties](https://reference.aspose.com/slides/sv/python-net/aspose.slides/viewproperties/normal_view_properties/) har lagts till för att ge åtkomst till normala vyegenskaper för presentationen.

Klasserna [NormalViewProperties](https://reference.aspose.com/slides/sv/python-net/aspose.slides/normalviewproperties/), [NormalViewRestoredProperties](https://reference.aspose.com/slides/sv/python-net/aspose.slides/normalviewrestoredproperties/) och dess underklasser samt enumen [SplitterBarStateType](https://reference.aspose.com/slides/sv/python-net/aspose.slides/splitterbarstatetype/) har lagts till.

## **Om INormalViewProperties**

Representerar normala vyegenskaper.

Egenskapen **ShowOutlineIcons** anger om applikationen ska visa ikoner när den visar dispositionsinnehåll i något av innehållsområdena i normalläget.

Egenskapen **SnapVerticalSplitter** anger om den vertikala delaren ska låsas i ett minimerat tillstånd när sidområdet är tillräckligt litet.

Egenskapen **PreferSingleView** specificerar om användaren föredrar att se ett enda innehållsområde i helskärmsläge i stället för den vanliga vyn med tre innehållsområden. Om den är aktiverad kan applikationen välja att visa ett av innehållsområdena i hela fönstret.

Egenskaperna **VerticalBarState** och **HorizontalBarState** anger i vilket tillstånd den horisontella respektive vertikala delarbalken ska visas. En horisontell delarbalk separerar bilden från innehållsområdet under bilden, en vertikal delarbalk separerar bilden från sidoinnehållsområdet. Möjliga värden är: **SplitterBarStateType.Minimized, SplitterBarStateType.Maximized** och **SplitterBarStateType.Restored**.

Egenskaperna **RestoredLeft** och **RestoredTop** anger storleken på det övre eller sidogränssnittet i den normala vyn när värdet **SplitterBarStateType.Restored** tillämpas på **VerticalBarState** respektive **HorizontalBarState**.

## **Om återställning av INormalViewProperties**

Anger storleken på bildområdet (bredd när det är ett barn till RestoredTop, höjd när det är ett barn till RestoredLeft) i den normala vyn, när området har en variabel återställd storlek (varken minimerad eller maximerad).

Egenskapen **DimensionSize** anger storleken på bildområdet (bredd när det är ett barn till restoredTop, höjd när det är ett barn till restoredLeft).

Egenskapen **AutoAdjust** anger om storleken på sidoinnehållsområdet ska anpassas till den nya storleken när fönstret som innehåller vyn i applikationen ändras storlek.

Ett exempel ges nedan som visar hur du kan komma åt **ViewProperties.NormalViewProperties**-egenskaperna för en presentation.

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as pres:
    pres.view_properties.normal_view_properties.horizontal_bar_state = slides.SplitterBarStateType.RESTORED
    pres.view_properties.normal_view_properties.vertical_bar_state = slides.SplitterBarStateType.MAXIMIZED

    # Återställ vyegenskaperna för presentationen
    pres.view_properties.normal_view_properties.restored_top.auto_adjust = True
    pres.view_properties.normal_view_properties.restored_top.dimension_size = 80
    pres.view_properties.normal_view_properties.show_outline_icons = True

    pres.save("presentation_normal_view_state.pptx", slides.export.SaveFormat.PPTX)
```

## **Ställ in standard zoomvärde**

Aspose.Slides för Python via .NET stöder nu att ställa in standardzoomvärdet för en presentation så att när presentationen öppnas är zoomen redan inställd. Detta kan göras genom att ange [view_properties](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/view_properties/) för en presentation. Bildvisningsinställningar samt [notes_view_properties](https://reference.aspose.com/slides/sv/python-net/aspose.slides/viewproperties/notes_view_properties/) kan sättas programatiskt. I det här ämnet kommer vi med ett exempel att visa hur man ställer in visningsinställningarna för en presentation i Aspose.Slides.

För att ställa in visningsinställningarna, följ stegen nedan:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/)
2. Ange [view properties](https://reference.aspose.com/slides/sv/python-net/aspose.slides/viewproperties/) för presentationen
3. Skriv presentationen som en PPTX‑fil

I exemplet nedan har vi ställt in zoomvärdet för bildvyn samt notvyn.

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # Ställer in vyegenskaperna för presentationen
    presentation.view_properties.slide_view_properties.scale = 100 # Zoomvärde i procent för bildvyn
    presentation.view_properties.notes_view_properties.scale = 100 # Zoomvärde i procent för anteckningsvyn 

    presentation.save("Zoom_out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Kan jag ange olika visningsinställningar för olika sektioner i en presentation?**

[View settings](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/view_properties/) definieras på presentationsnivå ([Normal View](https://reference.aspose.com/slides/sv/python-net/aspose.slides/viewproperties/normal_view_properties/)/[Slide View](https://reference.aspose.com/slides/sv/python-net/aspose.slides/viewproperties/slide_view_properties/)), inte per sektion, så ett enda uppsättning parametrar gäller för hela dokumentet när det öppnas.

**Kan jag fördefiniera olika visningslägen för olika användare?**

Nej. Inställningarna lagras i filen och delas. Visningsprogram kan respektera användarpreferenser, men själva filen innehåller endast en uppsättning visningsegenskaper.

**Kan jag förbereda en mall med fördefinierade View Properties så att nya presentationer öppnas på samma sätt?**

Ja. Eftersom [view properties](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/view_properties/) lagras på presentationsnivå kan du bädda in dem i en mall och skapa nya dokument från den med samma initiala visningskonfiguration.