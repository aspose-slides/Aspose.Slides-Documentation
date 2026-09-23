---
title: Hämta och uppdatera presentationsvisningsinställningar i Python via Java
linktitle: Visningsinställningar
type: docs
weight: 80
url: /sv/python-java/presentation-view-properties/
keywords:
- visningsegenskaper
- normalvy
- dispositionsinnehåll
- dispositionsikoner
- snappa vertikal delare
- enskild vy
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
description: "Upptäck Aspose.Slides för Python via Java visningsinställningar för att anpassa PPT-, PPTX- och ODP-bilder—justera layouter, zoomnivåer och visningsinställningar."
---
## **Introduktion**

Normalvyn består av tre innehållsområden: själva bilden, ett sidoinnehållsområde och ett botteninnehållsområde. Normalvy‑egenskaper beskriver placeringen av dessa innehållsområden. Denna information gör att applikationen kan spara sitt visningsläge till filen, så att när den öppnas igen är vyn i samma tillstånd som när presentationen senast sparades.

Metoden [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/sv/python-java/aspose.slides/viewproperties/#getNormalViewProperties) har lagts till för att ge åtkomst till normalvyns egenskaper för en presentation.

Klasserna [NormalViewProperties](https://reference.aspose.com/slides/sv/python-java/aspose.slides/normalviewproperties/) och [NormalViewRestoredProperties](https://reference.aspose.com/slides/sv/python-java/aspose.slides/normalviewrestoredproperties/) samt uppräkningen [SplitterBarStateType](https://reference.aspose.com/slides/sv/python-java/aspose.slides/splitterbarstatetype/) har lagts till.

## **Om NormalViewProperties**

Representerar egenskaper för normalvyn.

Metoderna [getShowOutlineIcons](https://reference.aspose.com/slides/sv/python-java/aspose.slides/normalviewproperties/#getShowOutlineIcons) och [setShowOutlineIcons](https://reference.aspose.com/slides/sv/python-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) anger om applikationen ska visa ikoner när dispositionens innehåll visas i någon av innehållsområdena i normalvy‑läget.

Metoderna [getSnapVerticalSplitter](https://reference.aspose.com/slides/sv/python-java/aspose.slides/normalviewproperties/#getSnapVerticalSplitter) och [setSnapVerticalSplitter](https://reference.aspose.com/slides/sv/python-java/aspose.slides/normalviewproperties/#setSnapVerticalSplitter) anger om den vertikala delaren ska låsas till ett minimerat tillstånd när sidområdet är tillräckligt litet.

Metoderna [getPreferSingleView](https://reference.aspose.com/slides/sv/python-java/aspose.slides/normalviewproperties/#getPreferSingleView) och [setPreferSingleView](https://reference.aspose.com/slides/sv/python-java/aspose.slides/normalviewproperties/#setPreferSingleView) anger om användaren föredrar att se ett full‑fönster med ett enskilt innehållsområde i stället för den vanliga normalvyn med tre innehållsområden. Om detta är aktiverat kan applikationen välja att visa ett av innehållsområdena i hela fönstret.

Metoderna [getVerticalBarState](https://reference.aspose.com/slides/sv/python-java/aspose.slides/normalviewproperties/#getVerticalBarState) och [getHorizontalBarState](https://reference.aspose.com/slides/sv/python-java/aspose.slides/normalviewproperties/#getHorizontalBarState) anger i vilket tillstånd den horisontella eller vertikala delarstapeln ska visas. En horisontell delarstapel separerar bilden från innehållsområdet under bilden; en vertikal delarstapel separerar bilden från sidoinnehållsområdet. Möjliga värden är: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/sv/python-java/aspose.slides/splitterbarstatetype/#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/sv/python-java/aspose.slides/splitterbarstatetype/#Maximized) och [SplitterBarStateType.Restored](https://reference.aspose.com/slides/sv/python-java/aspose.slides/splitterbarstatetype/#Restored).

Metoderna [getRestoredLeft](https://reference.aspose.com/slides/sv/python-java/aspose.slides/normalviewproperties/#getRestoredLeft) och [getRestoredTop](https://reference.aspose.com/slides/sv/python-java/aspose.slides/normalviewproperties/#getRestoredTop) anger storleken på den övre eller sidobildsområdet i normalvyn när värdet [SplitterBarStateType.Restored](https://reference.aspose.com/slides/sv/python-java/aspose.slides/splitterbarstatetype/#Restored) tillämpas på [getVerticalBarState](https://reference.aspose.com/slides/sv/python-java/aspose.slides/normalviewproperties/#getVerticalBarState) respektive [getHorizontalBarState](https://reference.aspose.com/slides/sv/python-java/aspose.slides/normalviewproperties/#getHorizontalBarState).

## **Om att återställa NormalViewProperties**

Anger storleken på bildområdet (bredd när det är ett barn till [getRestoredTop](https://reference.aspose.com/slides/sv/python-java/aspose.slides/normalviewproperties/#getRestoredTop), höjd när det är ett barn till [getRestoredLeft](https://reference.aspose.com/slides/sv/python-java/aspose.slides/normalviewproperties/#getRestoredLeft)) i normalvyn, när området har en variabel återställd storlek (varken minimerad eller maximiserad).

Metoden [getDimensionSize](https://reference.aspose.com/slides/sv/python-java/aspose.slides/normalviewrestoredproperties/#getDimensionSize) specificerar storleken på bildområdet (bredd när det är ett barn till [getRestoredTop](https://reference.aspose.com/slides/sv/python-java/aspose.slides/normalviewproperties/#getRestoredTop), höjd när det är ett barn till [getRestoredLeft](https://reference.aspose.com/slides/sv/python-java/aspose.slides/normalviewproperties/#getRestoredLeft)).

Metoden [getAutoAdjust](https://reference.aspose.com/slides/sv/python-java/aspose.slides/normalviewrestoredproperties/#getAutoAdjust) anger om storleken på sidoinnehållsområdet ska anpassas till den nya storleken när fönstret som innehåller vyn i applikationen ändras.

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

    # Återställ presentationens visningsinställningar.
    normal_view_properties.getRestoredTop().setAutoAdjust(True)
    normal_view_properties.getRestoredTop().setDimensionSize(80)
    normal_view_properties.setShowOutlineIcons(True)

    presentation.save("presentation_normal_view_state.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ställ in standardzoomvärdet**

{{% alert color="info" title="Note" %}}
Aspose.Slides for Python via Java stöder att ange standardzoomvärdet så att det redan tillämpas när presentationen öppnas. Detta kan göras genom att ställa in [ViewProperties](https://reference.aspose.com/slides/sv/python-java/aspose.slides/viewproperties/) för en presentation. [getSlideViewProperties](https://reference.aspose.com/slides/sv/python-java/aspose.slides/viewproperties/#getSlideViewProperties) samt [getNotesViewProperties](https://reference.aspose.com/slides/sv/python-java/aspose.slides/viewproperties/#getNotesViewProperties) kan konfigureras programatiskt. I detta avsnitt ser vi med ett exempel hur man sätter [View Properties](https://reference.aspose.com/slides/sv/python-java/aspose.slides/viewproperties/) för [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/) i Aspose.Slides.
{{% /alert %}}

För att ställa in visnings‑egenskaperna, följ dessa steg:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/).
1. Ställ in [View Properties](https://reference.aspose.com/slides/sv/python-java/aspose.slides/viewproperties/) för [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/).
1. Skriv presentationen som en [PPTX](https://docs.fileformat.com/presentation/pptx/)‑fil.

I exemplet nedan sätter vi zoomvärdet för både bildvyn och anteckningsvyn.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    # Ställ in presentationens visningsinställningar.
    presentation.getViewProperties().getSlideViewProperties().setScale(100)  # Zoomprocent för bildvyn.
    presentation.getViewProperties().getNotesViewProperties().setScale(100)  # Zoomprocent för anteckningsvyn.

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ställ in rutnätsavståndet**

Använd [Presentation.getViewProperties](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/#getViewProperties) för att få åtkomst till visningsinställningarna för hela presentationen. Metoderna [ViewProperties.getGridSpacing](https://reference.aspose.com/slides/sv/python-java/aspose.slides/viewproperties/#getGridSpacing) och [ViewProperties.setGridSpacing](https://reference.aspose.com/slides/sv/python-java/aspose.slides/viewproperties/#setGridSpacing) läser eller ändrar intervallet för det underliggande redigeringsrutnätet. Denna inställning gäller hela presentationen, inte en enskild bild. Rutnätsavståndet anges i punkter, där 72 punkter motsvarar en tum. Använd ett positivt värde, enligt API‑dokumentationen.

Följande exempel öppnar en befintlig `demo.pptx`, skriver ut dess aktuella rutnätsavstånd, sätter ett fjärdedel‑tum‑intervall och sparar resultatet.

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

Rutnätet är annorlunda än [drawing guides](/slides/sv/python-java/drawing-guides/). Rutnätsavståndet styr ett regelbundet intervall, medan ritningsguider är individuellt placerade horisontella eller vertikala justeringslinjer. Att lägga till, flytta eller rensa ritningsguider ändrar inte rutnätsavståndet.

Både rutnätet och ritningsguiderna är redigeringshjälpmedel. De renderas inte som bildinnehåll i PDF, bilder, SVG eller ett bildspel. Att lagra rutnätsavståndet garanterar inte att en redigerare visar rutnätet: dess synlighet beror också på visnings‑ eller redigerarens inställningar.

## **Visa eller dölja kommentarer när en presentation öppnas**

Använd [Presentation.getViewProperties](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/#getViewProperties) för att få åtkomst till visningsinställningarna för hela presentationen. Använd [ViewProperties.getShowComments](https://reference.aspose.com/slides/sv/python-java/aspose.slides/viewproperties/#getShowComments) och [ViewProperties.setShowComments](https://reference.aspose.com/slides/sv/python-java/aspose.slides/viewproperties/#setShowComments) för att läsa eller ändra den lagrade preferensen för om kommentarer ska visas när presentationen öppnas i PowerPoint eller en annan kompatibel redigerare.

Denna inställning styr endast den lagrade visningspreferensen. Den lägger inte till, tar bort, redigerar eller löser kommentarer. Att dölja kommentarer bevarar deras innehåll, författare, positioner, svar och status. Se [Presentation Comments](/slides/sv/python-java/presentation-comments/) för operationer som ändrar kommentarerna själva.

Följande exempel kräver en befintlig `comments.pptx` som innehåller kommentarer. Det skriver ut den aktuella synlighetsinställningen, begär att kommentarer ska döljas och sparar en ny PPTX utan att ta bort några kommentarer. Det använder också [ViewProperties.setLastView](https://reference.aspose.com/slides/sv/python-java/aspose.slides/viewproperties/#setLastView) med [ViewType.SlideView](https://reference.aspose.com/slides/sv/python-java/aspose.slides/viewtype/#SlideView) för att konfigurera den initiala redigeringsvyn tillsammans med kommentarernas synlighet.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, Presentation, SaveFormat, ViewType

presentation = Presentation("comments.pptx")
try:
    show_comments = presentation.getViewProperties().getShowComments()
    print(f"Current comment visibility: {show_comments}")

    presentation.getViewProperties().setShowComments(NullableBool.False_)
    presentation.getViewProperties().setLastView(ViewType.SlideView)
    presentation.save("comments-hidden.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Denna inställning avgör inte om kommentarer inkluderas i PDF-, HTML-, bild-, antecknings- eller utdrags‑export. Konfigurera de relevanta export‑specifika alternativen separat.

## **FAQ**

**Varför är rutnätet inte synligt när jag öppnar presentationen igen?**

Filen lagrar rutnätsavståndet, men redigeraren styr om rutnätet visas. Kontrollera redigerarens inställningar för rutnätsynlighet.

**Ändrar rensning av ritningsguider rutnätsavståndet?**

Nej. Ritningsguider och rutnätsavstånd är oberoende inställningar. Att rensa guider lämnar det lagrade rutnätsintervallet oförändrat.

**Kan jag ange olika visningsinställningar för olika avsnitt i en presentation?**

[View settings](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/#getViewProperties) definieras på presentationsnivå (Normal View/Slide View), inte per avsnitt, så ett enda parameter‑set gäller för hela dokumentet när det öppnas.

**Kan jag fördefiniera olika visningstillstånd för olika användare?**

Nej. Inställningarna lagras i filen och delas. Visningsprogram kan hedra användarpreferenser, men själva filen innehåller ett enda set av visningsegenskaper.

**Kan jag förbereda en mall med fördefinierade View Properties så att nya presentationer öppnas på samma sätt?**

Ja. Eftersom [view properties](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/#getViewProperties) lagras på presentationsnivå kan du bädda in dem i en mall och skapa nya dokument från den med samma initiala visningskonfiguration.