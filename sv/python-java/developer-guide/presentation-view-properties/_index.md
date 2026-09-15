---
title: Hämta och uppdatera presentationsvisningsegenskaper i Python via Java
linktitle: Visningsegenskaper
type: docs
weight: 80
url: /sv/python-java/presentation-view-properties/
keywords:
- visningsegenskaper
- normalvy
- översiktsinnehåll
- översiktsikoner
- fäst vertikal delare
- enkelsyn
- balkstatus
- dimensionstorlek
- automatisk justering
- standardzoom
- PowerPoint
- OpenDocument
- presentation
- Python
- Java
- Aspose.Slides
description: "Upptäck Aspose.Slides för Python via Java visningsegenskaper för att anpassa PPT-, PPTX- och ODP-bilder—justera layouter, zoomnivåer och displayinställningar."
---
## **Introduktion**

Normalvyn består av tre innehållsområden: själva bilden, ett sidoinnehållsområde och ett nedre innehållsområde. Normalvy‑egenskaper beskriver placeringen av dessa innehållsområden. Denna information gör att applikationen kan spara sitt visningsläge till filen, så att när den öppnas igen är vyn i samma tillstånd som när presentationen senast sparades.

Metoden [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/sv/python-java/aspose.slides/viewproperties/#getNormalViewProperties) har lagts till för att ge åtkomst till normalvy‑egenskaperna för en presentation.

Klasserna [NormalViewProperties](https://reference.aspose.com/slides/sv/python-java/aspose.slides/normalviewproperties/) och [NormalViewRestoredProperties](https://reference.aspose.com/slides/sv/python-java/aspose.slides/normalviewrestoredproperties/) samt uppräkningen [SplitterBarStateType](https://reference.aspose.com/slides/sv/python-java/aspose.slides/splitterbarstatetype/) har lagts till.

## **Om NormalViewProperties**

Representerar normalvy‑egenskaper.

Metoderna [getShowOutlineIcons](https://reference.aspose.com/slides/sv/python-java/aspose.slides/normalviewproperties/#getShowOutlineIcons) och [setShowOutlineIcons](https://reference.aspose.com/slides/sv/python-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) anger om applikationen ska visa ikoner när dispositionen visas i något av innehållsområdena i normalvyläge.

Metoderna [getSnapVerticalSplitter](https://reference.aspose.com/slides/sv/python-java/aspose.slides/normalviewproperties/#getSnapVerticalSplitter) och [setSnapVerticalSplitter](https://reference.aspose.com/slides/sv/python-java/aspose.slides/normalviewproperties/#setSnapVerticalSplitter) anger om den vertikala delaren ska hakas på ett minimerat läge när sidoregionen är tillräckligt liten.

Metoderna [getPreferSingleView](https://reference.aspose.com/slides/sv/python-java/aspose.slides/normalviewproperties/#getPreferSingleView) och [setPreferSingleView](https://reference.aspose.com/slides/sv/python-java/aspose.slides/normalviewproperties/#setPreferSingleView) anger om användaren föredrar att se ett fullskärms‑ensamt innehållsområde framför den normala vyn med tre innehållsområden. Om den är aktiverad kan applikationen välja att visa ett av innehållsområdena i hela fönstret.

Metoderna [getVerticalBarState](https://reference.aspose.com/slides/sv/python-java/aspose.slides/normalviewproperties/#getVerticalBarState) och [getHorizontalBarState](https://reference.aspose.com/slides/sv/python-java/aspose.slides/normalviewproperties/#getHorizontalBarState) anger i vilket tillstånd den horisontella eller vertikala delarbalken ska visas. En horisontell delarbalk separerar bilden från innehållsområdet under bilden; en vertikal delarbalk separerar bilden från sidoinnehållsområdet. Möjliga värden är: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/sv/python-java/aspose.slides/splitterbarstatetype/#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/sv/python-java/aspose.slides/splitterbarstatetype/#Maximized) och [SplitterBarStateType.Restored](https://reference.aspose.com/slides/sv/python-java/aspose.slides/splitterbarstatetype/#Restored).

Metoderna [getRestoredLeft](https://reference.aspose.com/slides/sv/python-java/aspose.slides/normalviewproperties/#getRestoredLeft) och [getRestoredTop](https://reference.aspose.com/slides/sv/python-java/aspose.slides/normalviewproperties/#getRestoredTop) anger storleken på det övre eller sidoregionen i normalvyn när värdet [SplitterBarStateType.Restored](https://reference.aspose.com/slides/sv/python-java/aspose.slides/splitterbarstatetype/#Restored) tillämpas på [getVerticalBarState](https://reference.aspose.com/slides/sv/python-java/aspose.slides/normalviewproperties/#getVerticalBarState) respektive [getHorizontalBarState](https://reference.aspose.com/slides/sv/python-java/aspose.slides/normalviewproperties/#getHorizontalBarState).

## **Om återställning av NormalViewProperties**

Anger storleken på bildregionen (bredd när den är ett underobjekt till [getRestoredTop](https://reference.aspose.com/slides/sv/python-java/aspose.slides/normalviewproperties/#getRestoredTop), höjd när den är ett underobjekt till [getRestoredLeft](https://reference.aspose.com/slides/sv/python-java/aspose.slides/normalviewproperties/#getRestoredLeft)) i normalvyn, när regionen har en variabel återställd storlek (varken minimerad eller maximerad).

Metoden [getDimensionSize](https://reference.aspose.com/slides/sv/python-java/aspose.slides/normalviewrestoredproperties/#getDimensionSize) anger storleken på bildregionen (bredd när den är ett underobjekt till [getRestoredTop](https://reference.aspose.com/slides/sv/python-java/aspose.slides/normalviewproperties/#getRestoredTop), höjd när den är ett underobjekt till [getRestoredLeft](https://reference.aspose.com/slides/sv/python-java/aspose.slides/normalviewproperties/#getRestoredLeft)).

Metoden [getAutoAdjust](https://reference.aspose.com/slides/sv/python-java/aspose.slides/normalviewrestoredproperties/#getAutoAdjust) anger om storleken på sidoinnehållsområdet ska kompensera för den nya storleken när fönstret som innehåller vyn ändras storlek i applikationen.

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

    # Återställ visningsegenskaperna för presentationen.
    normal_view_properties.getRestoredTop().setAutoAdjust(True)
    normal_view_properties.getRestoredTop().setDimensionSize(80)
    normal_view_properties.setShowOutlineIcons(True)

    presentation.save("presentation_normal_view_state.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ställ in standardzoomvärdet**

{{% alert color="info" title="Note" %}}
Aspose.Slides för Python via Java stödjer att ange standardzoomvärdet så att det redan tillämpas när presentationen öppnas. Detta kan göras genom att ange [ViewProperties](https://reference.aspose.com/slides/sv/python-java/aspose.slides/viewproperties/) för en presentation. [getSlideViewProperties](https://reference.aspose.com/slides/sv/python-java/aspose.slides/viewproperties/#getSlideViewProperties) samt [getNotesViewProperties](https://reference.aspose.com/slides/sv/python-java/aspose.slides/viewproperties/#getNotesViewProperties) kan konfigureras programmässigt. I detta avsnitt visar vi med ett exempel hur man ställer in [View Properties](https://reference.aspose.com/slides/sv/python-java/aspose.slides/viewproperties/) för [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/) i [Aspose.Slides](/slides/sv/).
{{% /alert %}}

För att ange visnings‑egenskaperna, följ dessa steg:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/).
1. Ange [View Properties](https://reference.aspose.com/slides/sv/python-java/aspose.slides/viewproperties/) för [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/).
1. Spara presentationen som en [PPTX](https://docs.fileformat.com/presentation/pptx/)-fil.

I exemplet nedan sätter vi zoomvärdet för både bildvyn och notvyn.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    # Ange visningsegenskaperna för presentationen.
    presentation.getViewProperties().getSlideViewProperties().setScale(100)  # Zoomprocent för bildvyn.
    presentation.getViewProperties().getNotesViewProperties().setScale(100)  # Zoomprocent för notvyn.

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Vanliga frågor**

**Kan jag ange olika visningsinställningar för olika sektioner i en presentation?**

[View settings](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/#getViewProperties) definieras på presentationsnivå ([Normal View](https://reference.aspose.com/slides/sv/python-java/aspose.slides/viewproperties/#getNormalViewProperties)/[Slide View](https://reference.aspose.com/slides/sv/python-java/aspose.slides/viewproperties/#getSlideViewProperties)), inte per sektion, så en enda uppsättning parametrar gäller för hela dokumentet när det öppnas.

**Kan jag fördefiniera olika visningstillstånd för olika användare?**

Nej. Inställningarna lagras i filen och delas. Visningsprogram kan respektera användarpreferenser, men filen i sig innehåller en enda uppsättning visnings‑egenskaper.

**Kan jag förbereda en mall med fördefinierade View Properties så att nya presentationer öppnas på samma sätt?**

Ja. Eftersom [view properties](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/#getViewProperties) lagras på presentationsnivå kan du bädda in dem i en mall och skapa nya dokument från den med samma initiala visningskonfiguration.