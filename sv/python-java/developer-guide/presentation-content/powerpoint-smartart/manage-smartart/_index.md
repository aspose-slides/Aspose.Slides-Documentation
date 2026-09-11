---
title: "Hantera SmartArt i PowerPoint-presentationer med Python"
linktitle: "Hantera SmartArt"
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

SmartArt är ett PowerPoint-diagram som består av noder, nodformer och en layout. Med Aspose.Slides för Python via Java kan du skapa SmartArt, läsa text från dess noder, ändra dess layout, undersöka dolda noder, konfigurera organisationsschemalayouter och skapa bildorganisationsdiagram.

## **Hämta text från ett SmartArt-objekt**

En SmartArt-nod kan innehålla en eller flera former. För att läsa den synliga texten, iterera genom [SmartArt.getAllNodes](https://reference.aspose.com/slides/sv/python-java/aspose.slides/smartart/#getAllNodes), och läs sedan den [TextFrame](https://reference.aspose.com/slides/sv/python-java/aspose.slides/textframe/) som returneras av [SmartArtShape.getTextFrame](https://reference.aspose.com/slides/sv/python-java/aspose.slides/smartartshape/#getTextFrame).

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

SmartArt-layouten styr hur noder arrangeras och kopplas ihop. Följande exempel skapar ett SmartArt-objekt med värdet `BasicBlockList` från [SmartArtLayoutType](https://reference.aspose.com/slides/sv/python-java/aspose.slides/smartartlayouttype/), ändrar det till värdet `BasicProcess` och sparar presentationen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    smart_art = presentation.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList)

    smart_art.setLayout(SmartArtLayoutType.BasicProcess)

    presentation.save("ChangeSmartArtLayout_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Kontrollera om en SmartArt-nod är dold**

[SmartArtNode.isHidden](https://reference.aspose.com/slides/sv/python-java/aspose.slides/smartartnode/#isHidden) indikerar om noden är dold i SmartArt:s datamodell. Dolda noder kan finnas i strukturen även när den valda layouten inte visar dem som synliga diagramdelar.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    smart_art = presentation.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle)

    node = smart_art.getAllNodes().addNode()
    is_hidden = node.isHidden()

    if is_hidden:
        print("The node is hidden in the SmartArt data model.")

    presentation.save("CheckSmartArtHiddenProperty_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Hämta eller ställ in layouten för organisationsschemat**

För SmartArt-diagram som använder en organisationsschemalayout definierar [SmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/sv/python-java/aspose.slides/smartartnode/#getOrganizationChartLayout) och [SmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/sv/python-java/aspose.slides/smartartnode/#setOrganizationChartLayout) hur underordnade noder placeras under en föräldranod. Till exempel kan du låta underordnade noder hänga från vänster, höger eller båda sidor, beroende på den valda [OrganizationChartLayoutType](https://reference.aspose.com/slides/sv/python-java/aspose.slides/organizationchartlayouttype/).

Följande exempel skapar ett organisationsschema och ställer in layouten för den första noden till värdet `LeftHanging` från [OrganizationChartLayoutType](https://reference.aspose.com/slides/sv/python-java/aspose.slides/organizationchartlayouttype/).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OrganizationChartLayoutType, Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    smart_art = presentation.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart)

    root_node = smart_art.getNodes().get_Item(0)
    root_node.setOrganizationChartLayout(OrganizationChartLayoutType.LeftHanging)

    presentation.save("OrganizationChartLayout_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Skapa ett bildorganisationsschema**

Ett bildorganisationsschema är en SmartArt-layout avsedd för hierarkidiagram som innehåller bildplatshållare. Använd värdet `PictureOrganizationChart` från [SmartArtLayoutType](https://reference.aspose.com/slides/sv/python-java/aspose.slides/smartartlayouttype/) när du lägger till SmartArt-objektet på en bild.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    smart_art = presentation.getSlides().get_Item(0).getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.PictureOrganizationChart)

    presentation.save("PictureOrganizationChart_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Vanliga frågor**

**Stöder SmartArt spegling eller omvändning för RTL-språk?**

Ja. Metoden [SmartArt.setReversed](https://reference.aspose.com/slides/sv/python-java/aspose.slides/smartart/#setReversed) byter diagramriktningen från vänster-till-höger till höger-till-vänster, eller tillbaka, när den valda SmartArt-layouten stöder omvändning.

**Hur kan jag kopiera SmartArt till samma bild eller till en annan presentation samtidigt som formatering bevaras?**

Du kan [klona SmartArt-formen](/slides/sv/python-java/shape-manipulations/) med [ShapeCollection.addClone](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shapecollection/#addClone) eller [klona hela bilden](/slides/sv/python-java/clone-slides/) som innehåller SmartArt. Båda metoderna bevarar storlek, position och formatering.

**Hur renderar jag SmartArt till en rasterbild för förhandsgranskning eller webbexport?**

[Rendera bilden](/slides/sv/python-java/convert-powerpoint-to-png/) eller hela presentationen till PNG eller JPEG. SmartArt renderas som en del av bilden.

**Hur kan jag hitta ett specifikt SmartArt-objekt på en bild om det finns flera?**

Ange ett distinkt [Shape.getAlternativeText](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shape/#getAlternativeText) eller [Shape.getName](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shape/#getName) värde på SmartArt-formen, sök efter det värdet i [BaseSlide.getShapes](https://reference.aspose.com/slides/sv/python-java/aspose.slides/baseslide/#getShapes), och kontrollera sedan att den matchande formen är en [SmartArt](https://reference.aspose.com/slides/sv/python-java/aspose.slides/smartart/).