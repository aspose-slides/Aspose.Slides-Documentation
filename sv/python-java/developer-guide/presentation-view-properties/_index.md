---
title: Hämta och uppdatera presentationsvyegenskaper i Python via Java
linktitle: Vyegenskaper
type: docs
weight: 80
url: /sv/python-java/presentation-view-properties/
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
- OpenDocument
- presentation
- Python
- Java
- Aspose.Slides
description: "Upptäck Aspose.Slides för Python via Java vyegenskaper för att anpassa PPT-, PPTX- och ODP-bilder—justera layouter, zoomnivåer och visningsinställningar."
---
## **Introduktion**

Normalvyn består av tre innehållsområden: själva bilden, ett sidobehållsområde och ett botteninnehållsområde. Normalvyegenskaper beskriver positioneringen av dessa innehållsområden. Denna information gör att applikationen kan spara sitt vyläge till filen, så att när den öppnas igen är vyn i samma tillstånd som när presentationen senast sparades.

Metoden [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/sv/python-java/aspose.slides/viewproperties/#getNormalViewProperties) har lagts till för att ge åtkomst till normalvyegenskaper för en presentation.

Klasserna [NormalViewProperties](https://reference.aspose.com/slides/sv/python-java/aspose.slides/normalviewproperties/) och [NormalViewRestoredProperties](https://reference.aspose.com/slides/sv/python-java/aspose.slides/normalviewrestoredproperties/) samt uppräkningen [SplitterBarStateType](https://reference.aspose.com/slides/sv/python-java/aspose.slides/splitterbarstatetype/) har lagts till.

## **Om NormalViewProperties**

Representerar normalvyegenskaper.

Metoderna [getShowOutlineIcons](https://reference.aspose.com/slides/sv/python-java/aspose.slides/normalviewproperties/#getShowOutlineIcons) och [setShowOutlineIcons](https://reference.aspose.com/slides/sv/python-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) anger om applikationen ska visa ikoner när den visar dispositionsinnehåll i något av innehållsområdena i normalvyläget.

Metoderna [getSnapVerticalSplitter](https://reference.aspose.com/slides/sv/python-java/aspose.slides/normalviewproperties/#getSnapVerticalSplitter) och [setSnapVerticalSplitter](https://reference.aspose.com/slides/sv/python-java/aspose.slides/normalviewproperties/#setSnapVerticalSplitter) anger om den vertikala delaren ska fästas i ett minimerat läge när sidoregionen är tillräckligt liten.

Metoderna [getPreferSingleView](https://reference.aspose.com/slides/sv/python-java/aspose.slides/normalviewproperties/#getPreferSingleView) och [setPreferSingleView](https://reference.aspose.com/slides/sv/python-java/aspose.slides/normalviewproperties/#setPreferSingleView) anger om användaren föredrar att se ett helfönster med ett enda innehållsområde istället för den vanliga normalvyn med tre innehållsområden. Om aktiverat kan applikationen välja att visa ett av innehållsområdena i hela fönstret.

Metoderna [getVerticalBarState](https://reference.aspose.com/slides/sv/python-java/aspose.slides/normalviewproperties/#getVerticalBarState) och [getHorizontalBarState](https://reference.aspose.com/slides/sv/python-java/aspose.slides/normalviewproperties/#getHorizontalBarState) anger vilket tillstånd den horisontella eller vertikala delarstapeln ska visas i. En horisontell delar stapel separerar bilden från innehållsområdet under bilden; en vertikal delar stapel separerar bilden från sidoinnehållsområdet. Möjliga värden är: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/sv/python-java/aspose.slides/splitterbarstatetype/#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/sv/python-java/aspose.slides/splitterbarstatetype/#Maximized) och [SplitterBarStateType.Restored](https://reference.aspose.com/slides/sv/python-java/aspose.slides/splitterbarstatetype/#Restored).

Metoderna [getRestoredLeft](https://reference.aspose.com/slides/sv/python-java/aspose.slides/normalviewproperties/#getRestoredLeft) och [getRestoredTop](https://reference.aspose.com/slides/sv/python-java/aspose.slides/normalviewproperties/#getRestoredTop) anger storleken på den övre eller sidogående bildregionen i normalvyn, när värdet [SplitterBarStateType.Restored](https://reference.aspose.com/slides/sv/python-java/aspose.slides/splitterbarstatetype/#Restored) tillämpas på [getVerticalBarState](https://reference.aspose.com/slides/sv/python-java/aspose.slides/normalviewproperties/#getVerticalBarState) respektive [getHorizontalBarState](https://reference.aspose.com/slides/sv/python-java/aspose.slides/normalviewproperties/#getHorizontalBarState).

## **Om återställning av NormalViewProperties**

Anger storleken på bildregionen (bredd när den är ett barn till [getRestoredTop](https://reference.aspose.com/slides/sv/python-java/aspose.slides/normalviewproperties/#getRestoredTop), höjd när den är ett barn till [getRestoredLeft](https://reference.aspose.com/slides/sv/python-java/aspose.slides/normalviewproperties/#getRestoredLeft)) i normalvyn, när regionen har en variabel återställd storlek (varken minimerad eller maximerad).

Metoden [getDimensionSize](https://reference.aspose.com/slides/sv/python-java/aspose.slides/normalviewrestoredproperties/#getDimensionSize) specificerar storleken på bildregionen (bredd när den är ett barn till [getRestoredTop](https://reference.aspose.com/slides/sv/python-java/aspose.slides/normalviewproperties/#getRestoredTop), höjd när den är ett barn till [getRestoredLeft](https://reference.aspose.com/slides/sv/python-java/aspose.slides/normalviewproperties/#getRestoredLeft)).

Metoden [getAutoAdjust](https://reference.aspose.com/slides/sv/python-java/aspose.slides/normalviewrestoredproperties/#getAutoAdjust) anger om storleken på sidoinnehållsområdet ska kompensera för den nya storleken när fönstret som innehåller vyn ändras i applikationen.

Exemplet nedan visar hur man får åtkomst till [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/sv/python-java/aspose.slides/viewproperties/#getNormalViewProperties) för en presentation.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SplitterBarStateType

presentation = Presentation()
try:
    normal_view_properties = presentation.getViewProperties().getNormalViewProperties()
    normal_view_properties.setHorizontalBarState(SplitterBarStateType.Restored)
    normal_view_properties.setVerticalBarState(SplitterBarStateType.Maximized)

    # Återställ vyegenskaperna för presentationen.
    normal_view_properties.getRestoredTop().setAutoAdjust(True)
    normal_view_properties.getRestoredTop().setDimensionSize(80)
    normal_view_properties.setShowOutlineIcons(True)

    presentation.save("presentation_normal_view_state.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ställ in standardzoomvärdet**

{{% alert color="info" title="Note" %}}
Aspose.Slides för Python via Java stöder att ange standardzoomvärdet så att det redan tillämpas när presentationen öppnas. Detta kan göras genom att ställa in [ViewProperties](https://reference.aspose.com/slides/sv/python-java/aspose.slides/viewproperties/) för en presentation. [getSlideViewProperties](https://reference.aspose.com/slides/sv/python-java/aspose.slides/viewproperties/#getSlideViewProperties) samt [getNotesViewProperties](https://reference.aspose.com/slides/sv/python-java/aspose.slides/viewproperties/#getNotesViewProperties) kan konfigureras programmässigt. I detta ämne kommer vi med ett exempel att visa hur man ställer in [View Properties](https://reference.aspose.com/slides/sv/python-java/aspose.slides/viewproperties/) för [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/) i Aspose.Slides.
{{% /alert %}}

För att ställa in vyegenskaperna, följ dessa steg:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/).
1. Ställ in [View Properties](https://reference.aspose.com/slides/sv/python-java/aspose.slides/viewproperties/) för [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/).
1. Skriv presentationen som en [PPTX](https://docs.fileformat.com/presentation/pptx/)-fil.

I exemplet nedan sätter vi zoomvärdet för både bildvyn och anteckningsvyn.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    # Ställ in vyegenskaperna för presentationen.
    presentation.getViewProperties().getSlideViewProperties().setScale(100)  # Zoomprocent för bildvyn.
    presentation.getViewProperties().getNotesViewProperties().setScale(100)  # Zoomprocent för anteckningsvyn.

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ställ in rutnätsavståndet**

Använd [Presentation.getViewProperties](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/#getViewProperties) för att komma åt vyinställningar för hela presentationen. Metoderna [ViewProperties.getGridSpacing](https://reference.aspose.com/slides/sv/python-java/aspose.slides/viewproperties/#getGridSpacing) och [ViewProperties.setGridSpacing](https://reference.aspose.com/slides/sv/python-java/aspose.slides/viewproperties/#setGridSpacing) läser eller ändrar intervallet för det underliggande redigeringsrutnätet. Denna inställning gäller hela presentationen, inte en enskild bild. Rutnätsavstånd anges i punkter, där 72 punkter motsvarar en tum. Använd ett positivt värde, enligt API-dokumentationen.

Följande exempel öppnar en befintlig `demo.pptx`, skriver ut aktuellt rutnätsavstånd, sätter ett kvartstumsintervall och sparar resultatet.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("demo.pptx")
try:
    grid_spacing = presentation.getViewProperties().getGridSpacing()
    print(f"Current grid spacing: {grid_spacing} points")

    presentation.getViewProperties().setGridSpacing(18.0)
    presentation.save("grid-spacing.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Rutnätet skiljer sig från [drawing guides](/slides/sv/python-java/drawing-guides/). Rutnätsavstånd styr ett regelbundet intervall, medan ritningsguider är individuellt placerade horisontella eller vertikala justeringslinjer. Att lägga till, flytta eller rensa ritningsguider ändrar inte rutnätsavståndet.

Både rutnätet och ritningsguiderna är redigeringshjälpmedel. De renderas inte som bildinnehåll i PDF, bilder, SVG eller ett bildspel. Att lagra rutnätsavståndet garanterar inte att en redigerare visar rutnätet: dess synlighet beror också på visnings- eller redigerarens inställningar.

## **Vanliga frågor**

**Varför är rutnätet inte synligt när jag öppnar presentationen igen?**

Filen lagrar rutnätsavståndet, men redigeraren styr om rutnätet visas. Kontrollera redigerarens inställningar för rutnätsynlighet.

**Är det så att rensning av ritningsguider ändrar rutnätsavståndet?**

Nej. Ritningsguider och rutnätsavstånd är oberoende inställningar. Att rensa guider lämnar det lagrade rutnätsintervallet oförändrat.

**Kan jag ange olika vyinställningar för olika sektioner i en presentation?**

[View settings](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/#getViewProperties) definieras på presentationsnivå ([Normal View](https://reference.aspose.com/slides/sv/python-java/aspose.slides/viewproperties/#getNormalViewProperties)/[Slide View](https://reference.aspose.com/slides/sv/python-java/aspose.slides/viewproperties/#getSlideViewProperties)), inte per sektion, så ett enda uppsättning parametrar gäller för hela dokumentet när det öppnas.

**Kan jag fördefiniera olika vylägen för olika användare?**

Nej. Inställningarna lagras i filen och delas. Visningsprogram kan respektera användarpreferenser, men filen själv innehåller endast ett set av vyegenskaper.

**Kan jag förbereda en mall med fördefinierade View Properties så att nya presentationer öppnas på samma sätt?**

Ja. Eftersom [view properties](https://reference.aspose.com/slides/sv/python-java/aspose.slides/viewproperties/) lagras på presentationsnivå kan du bädda in dem i en mall och skapa nya dokument från den med samma initiala vykonfiguration.