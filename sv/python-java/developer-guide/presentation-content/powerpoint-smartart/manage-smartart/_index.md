---
title: Hantera SmartArt i PowerPoint-presentationer med Python
linktitle: Hantera SmartArt
type: docs
weight: 10
url: /sv/python-java/manage-smartart/
keywords:
- SmartArt
- SmartArt-text
- layouttyp
- dold egenskap
- organisationsschema
- bildorganisationsschema
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Lär dig att skapa och redigera PowerPoint SmartArt med Aspose.Slides för Python via Java med tydliga kodexempel som snabbar upp bilddesign och automatisering."
---
## **Översikt**

SmartArt är ett PowerPoint-diagram som består av noder, nodformer och en layout. Med Aspose.Slides för Python via Java kan du skapa SmartArt, läsa text från dess noder, ändra dess layout, undersöka dolda noder, konfigurera organisationsschemalayouter och skapa bildorganisationsscheman.

## **Hämta text från ett SmartArt-objekt**

En SmartArt-nod kan innehålla en eller flera former. För att läsa text från nodformerna, iterera genom [SmartArt.getAllNodes](https://reference.aspose.com/slides/python-java/aspose.slides/smartart/#getAllNodes), och läs sedan [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/) som returneras av [SmartArtShape.getTextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/smartartshape/#getTextFrame).

Exemplet kräver en presentation med minst en bild och ett SmartArt-objekt som den första formen på den bilden. Det skriver ut varje tillgänglig textruta till konsolen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArt

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    if isinstance(shape, SmartArt):
        smart_art = shape
        for node in smart_art.getAllNodes():
            for node_shape in node.getShapes():
                if node_shape.getTextFrame() is not None:
                    print(node_shape.getTextFrame().getText())
finally:
    presentation.dispose()
```

## **Ändra layouttypen för ett SmartArt-objekt**

SmartArt-layouten styr hur noder ordnas och kopplas ihop. Följande exempel skapar ett SmartArt-objekt med [SmartArtLayoutType](https://reference.aspose.com/slides/python-java/aspose.slides/smartartlayouttype/) `BasicBlockList`-värdet, ändrar det till värdet `BasicProcess` och sparar presentationen. Positionen och storleken som skickas till [ShapeCollection.addSmartArt](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addSmartArt) mäts i punkter. Använd [SmartArt.setLayout](https://reference.aspose.com/slides/python-java/aspose.slides/smartart/#setLayout) för att ändra layouten.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    smart_art = slide.getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList)
    smart_art.setLayout(SmartArtLayoutType.BasicProcess)

    presentation.save("ChangeSmartArtLayout.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Kontrollera om en SmartArt-nod är dold**

[SmartArtNode.isHidden](https://reference.aspose.com/slides/python-java/aspose.slides/smartartnode/#isHidden) anger om noden är dold i SmartArt-datamodellen. Dolda noder kan finnas i strukturen även när den valda layouten inte visar dem som synliga diagramdelar.

Följande exempel lägger till en nod i ett SmartArt-objekt som använder [SmartArtLayoutType](https://reference.aspose.com/slides/python-java/aspose.slides/smartartlayouttype/) `RadialCycle`-värdet och kontrollerar den tillagda nodens dolda tillstånd. Det skriver ut ett meddelande om noden är dold och sparar diagrammet.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    smart_art = slide.getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle)
    node = smart_art.getAllNodes().addNode()
    is_hidden = node.isHidden()

    if is_hidden:
        print("The node is hidden in the SmartArt data model.")

    presentation.save("CheckSmartArtHiddenProperty.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Hämta eller ange organisationsschemalayout**

För SmartArt-diagram som använder en organisationsschemalayout definierar [SmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/python-java/aspose.slides/smartartnode/#getOrganizationChartLayout) och [SmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/python-java/aspose.slides/smartartnode/#setOrganizationChartLayout) hur barnnoder arrangeras under en föräldranod. Till exempel kan du ange att barnnoder hänger från vänster, högre eller båda sidor, beroende på den valda [OrganizationChartLayoutType](https://reference.aspose.com/slides/python-java/aspose.slides/organizationchartlayouttype/).

Följande exempel skapar ett organisationsschema och sätter layouten för den första noden till [OrganizationChartLayoutType](https://reference.aspose.com/slides/python-java/aspose.slides/organizationchartlayouttype/) `LeftHanging`-värdet. Det nollbaserade indexet `0` väljer den första top-nivånoden; dess barnnoder använder den valda arrangemanget. Den ändrade presentationen sparas sedan.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OrganizationChartLayoutType, Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    smart_art = slide.getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart)
    root_node = smart_art.getNodes().get_Item(0)
    root_node.setOrganizationChartLayout(OrganizationChartLayoutType.LeftHanging)

    presentation.save("OrganizationChartLayout.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Skapa ett bild-organisationsschema**

Ett bild-organisationsschema är en SmartArt-layout avsedd för hierarkidiagram som innehåller bildplatshållare. Använd [SmartArtLayoutType](https://reference.aspose.com/slides/python-java/aspose.slides/smartartlayouttype/) `PictureOrganizationChart`-värdet när du lägger till SmartArt-objektet på en bild. Detta exempel sparar ett diagram med bildplatshållare; det fyller inte i platshållarna med bilder.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    smart_art = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.PictureOrganizationChart)

    presentation.save("PictureOrganizationChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Konvertera äldre diagram till grupper av former**

När du moderniserar en befintlig presentation kan du behöva uppdatera ett organisationsschema som ursprungligen skapades i PowerPoint 97-2003. Aspose.Slides representerar dessa äldre diagram som [LegacyDiagram](https://reference.aspose.com/slides/python-java/aspose.slides/legacydiagram/)‑objekt. Använd [LegacyDiagram.convertToGroupShape](https://reference.aspose.com/slides/python-java/aspose.slides/legacydiagram/#convertToGroupShape) för att konvertera ett diagram till en grupp av former så att du kan redigera enskilda visuella element. Se [LegacyDiagram API Reference](https://reference.aspose.com/slides/python-java/aspose.slides/legacydiagram/) för detaljer.

Konverteringen lägger till en ny grupp i formssamlingen utan att ta bort det ursprungliga diagrammet. Efter en lyckad konvertering, ta bort originalet med [ShapeCollection.remove](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#remove) för att undvika duplicerat innehåll. Samla de äldre diagrammen i en lista innan du konverterar dem så att tillägg och borttagning av former inte stör iterationen.

Följande exempel öppnar en presentation, söker igenom varje bild, konverterar diagrammen till grupper av former och sparar den uppdaterade presentationen som PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LegacyDiagram, Presentation, SaveFormat

presentation = Presentation("legacy-diagrams.ppt")
try:
    for slide in presentation.getSlides():
        legacy_diagrams = []
        for shape in slide.getShapes():
            if isinstance(shape, LegacyDiagram):
                legacy_diagrams.append(shape)

        for legacy_diagram in legacy_diagrams:
            group_shape = legacy_diagram.convertToGroupShape()

            if group_shape is not None:
                slide.getShapes().remove(legacy_diagram)

    presentation.save("modernized.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Den sparade presentationen innehåller redigerbara grupper av former i stället för de konverterade äldre diagrammen, utan några originaldiagram kvar bredvid dem. Öppna PPTX-filen i PowerPoint för att redigera enskilda element i varje grupp, såsom deras text, fyllning eller position.

## **FAQ**

**Stöder SmartArt spegling eller omvändning för RTL-språk?**

Ja. Metoden [SmartArt.setReversed](https://reference.aspose.com/slides/python-java/aspose.slides/smartart/#setReversed) ändrar diagramriktningen från vänster-till-höger till högre-till-vänster, eller tillbaka, när den valda SmartArt-layouten stöder omvändning.

**Hur kan jag kopiera SmartArt till samma bild eller till en annan presentation samtidigt som formateringen bevaras?**

Du kan [klona SmartArt‑formen](/slides/sv/python-java/shape-manipulations/) med [ShapeCollection.addClone](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addClone) eller [klona hela bilden](/slides/sv/python-java/clone-slides/) som innehåller SmartArt. Båda metoderna bevarar storlek, position och formatering.

**Hur renderar jag SmartArt till en rasterbild för förhandsgranskning eller webbutmatning?**

[Rendera bilden](/slides/sv/python-java/convert-powerpoint-to-png/) eller hela presentationen till PNG eller JPEG. SmartArt renderas som en del av bilden.

**Hur kan jag hitta ett specifikt SmartArt‑objekt på en bild om det finns flera?**

Använd [Shape.setAlternativeText](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setAlternativeText) eller [Shape.setName](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setName) för att tilldela en särskiljande alternativ text eller ett namn till SmartArt‑formen, sök efter det värdet i [BaseSlide.getShapes](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getShapes) och kontrollera sedan att den matchande formen är en [SmartArt](https://reference.aspose.com/slides/python-java/aspose.slides/smartart/).