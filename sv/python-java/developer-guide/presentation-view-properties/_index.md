---
title: Hämta och uppdatera presentationsvyegenskaper i Python via Java
linktitle: Vyegenskaper
type: docs
weight: 80
url: /sv/python-java/presentation-view-properties/
keywords:
- vyegenskaper
- normalläge
- dispositionsinnehåll
- dispositionsikoner
- fästa vertikal splitare
- enda vy
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
description: "Använd Aspose.Slides för Python via Java för att konfigurera layouten i normalläget, zoom för bild och anteckningar, rutnätsavstånd samt kommentarers synlighet i PowerPoint-presentationer."
---
## **Introduktion**

I PowerPoints normalläge visas bilden mellan ett sidofält för miniatyrer eller en disposition och ett anteckningsfält nedanför. Aspose.Slides för Python via Java exponerar presentationens sparade redigeringsinställningar via [Presentation.getViewProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getViewProperties). Dessa inkluderar fältlayout, zoomnivåer, rutnätsavstånd och kommentarers synlighet.

## **Om NormalViewProperties**

Använd [getNormalViewProperties](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#getNormalViewProperties) för att komma åt klassen [NormalViewProperties](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/). [setShowOutlineIcons](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) styr om ikoner visas bredvid bildrubriker i dispositionen. [setSnapVerticalSplitter](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#setSnapVerticalSplitter) låter sidofältet fästa i sitt minimerade tillstånd när användaren minskar det. [setPreferSingleView](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#setPreferSingleView) indikerar en preferens för att visa ett fält i hela fönstret.

[setVerticalBarState](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#setVerticalBarState) styr delaren mellan sidofältet och bilden. [setHorizontalBarState](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#setHorizontalBarState) styr delaren ovanför anteckningsfältet. Båda accepterar ett [SplitterBarStateType](https://reference.aspose.com/slides/python-java/aspose.slides/splitterbarstatetype/)‑värde av `Minimized`, `Maximized` eller `Restored`.

## **Om återställning av NormalViewProperties**

När en delare återställs ger [getRestoredLeft](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#getRestoredLeft) den sparade storleken på sidofältet och [getRestoredTop](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#getRestoredTop) den sparade storleken på det övre bildområdet. Båda returnerar en instans av [NormalViewRestoredProperties](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewrestoredproperties/). Dess [setDimensionSize](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewrestoredproperties/#setDimensionSize)‑metod accepterar en procentsats från 0 till 100, och [setAutoAdjust](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewrestoredproperties/#setAutoAdjust) styr om redigeraren justerar storleken när fönstret ändras i storlek.

Det här exemplet uppdaterar en befintlig presentation. Det återställer den horisontella delaren, sätter storleken som returneras av [getRestoredTop](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#getRestoredTop) till 80% med automatisk justering aktiverad, och maximerar den vertikala delaren. Det anropar också [setShowOutlineIcons](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) för att visa ikoner i dispositionsvyn.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SplitterBarStateType

presentation = Presentation("demo.pptx")
try:
    normal_view_properties = presentation.getViewProperties().getNormalViewProperties()
    normal_view_properties.setHorizontalBarState(SplitterBarStateType.Restored)
    normal_view_properties.setVerticalBarState(SplitterBarStateType.Maximized)

    normal_view_properties.getRestoredTop().setAutoAdjust(True)
    normal_view_properties.getRestoredTop().setDimensionSize(80)
    normal_view_properties.setShowOutlineIcons(True)

    presentation.save("presentation_normal_view_state.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ställ in standardzoomvärdet**

[getSlideViewProperties](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#getSlideViewProperties) och [getNotesViewProperties](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#getNotesViewProperties) lagrar oberoende zoominställningar för redigeraren. Dessa inställningar påverkar inte bilddimensioner, bildspelsuppspelning eller bildexportens upplösning.

Det här exemplet öppnar en befintlig presentation och anropar [setVariableScale](https://reference.aspose.com/slides/python-java/aspose.slides/commonslideviewproperties/#setVariableScale) för att anpassa bilden till redigeringsfönstret. För anteckningssidan inaktiveras automatisk skalning och [setScale](https://reference.aspose.com/slides/python-java/aspose.slides/commonslideviewproperties/#setScale) anropas för att sätta en fast 80% zoom.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("demo.pptx")
try:
    view_properties = presentation.getViewProperties()
    view_properties.getSlideViewProperties().setVariableScale(True)
    notes_view = view_properties.getNotesViewProperties()
    notes_view.setVariableScale(False)
    notes_view.setScale(80)

    presentation.save("zoom.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ställ in rutnätsavståndet**

[setGridSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#setGridSpacing) anger avståndet mellan redigeringsrutnätslinjer i hela presentationen. Den tar ett positivt värde i punkter, med 72 punkter per tum. Det här exemplet skriver ut det aktuella avståndet i en befintlig presentation och sparar ett kvarts tum‑rutnät genom att sätta intervallet till 18 punkter.

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

Rutnätet upprepas med ett fast intervall. [Ritningsguider](/slides/sv/python-java/drawing-guides/) markerar enskilda horisontella eller vertikala positioner. Båda är redigeringshjälpmedel och visas endast i redigerare som visar dem. Bildspel och export till PDF, bilder eller SVG utelämnar dem.

## **Visa eller dölj kommentarer när en presentation öppnas**

[setShowComments](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#setShowComments) lagrar en preferens som kompatibla redigerare använder när de öppnar presentationen. För en befintlig presentation med kommentarer skriver detta exempel ut den aktuella inställningen och sparar en kopia med kommentarer dolda. Det anropar också [setLastView](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#setLastView) med [ViewType.SlideView](https://reference.aspose.com/slides/python-java/aspose.slides/viewtype/#SlideView) så att kopian öppnas i bildvyn.

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

Att dölja kommentarer bevarar deras text, författare, positioner, svar och status. För att ändra kommentarerna själva, se [Presentation‑kommentarer](/slides/sv/python-java/presentation-comments/). Exportinställningarna styr om kommentarer visas i PDF, HTML, bilder, anteckningar eller utdelningar.

## **Vanliga frågor**

**Varför är rutnätet dolt när jag öppnar presentationen igen?**

Presentationen lagrar rutnätsintervallet. För att se rutnätet, aktivera rutnätsynlighet i redigeraren.

**Ändrar borttagning av ritningsguider rutnätsavståndet?**

Nej. Att lägga till, flytta eller ta bort en guide lämnar rutnätsintervallet oförändrat.

**Kan olika avsnitt i en presentation ha olika vyinställningar?**

Nej. [Presentation.getViewProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getViewProperties) gäller för hela presentationen.

**Kan jag spara olika vyinställningar för olika användare?**

Filen lagrar en uppsättning vyegenskaper för alla. En redigerare kan också tillämpa en användares lokala preferenser.

**Kan jag spara vyinställningar i en mall?**

Ja. Presentationer som skapas från mallen ärver dess sparade vyinställningar.