---
title: "Beheer connectors in presentaties met Python via Java"
linktitle: "Connector"
type: docs
weight: 10
url: /nl/python-java/connector/
keywords:
- connector
- type connector
- connectorpunt
- connectorlijn
- connectorhoek
- verbindingspunt
- aanpassingspunt
- vormen verbinden
- PowerPoint
- presentatie
- Python
- Aspose.Slides
description: "Leer hoe u rechte, gebogen en kromme PowerPoint-connectors kunt toevoegen, bevestigen, opnieuw routeren, aanpassen en inspecteren met Aspose.Slides voor Python via Java."
---
## **Overzicht**

Een connector is een lijn die aan twee vormen kan blijven bevestigd wanneer een van de vormen beweegt. De uiteinden hechten zich aan verbindingspunten, weergegeven door groene stippen in PowerPoint. Sommige gebogen en kromme connectors onthullen ook aanpassingspunten, weergegeven door oranje stippen, die de positie van individuele connectorsegmenten regelen.

Aspose.Slides vertegenwoordigt connectors via de [Connector](https://reference.aspose.com/slides/nl/python-java/aspose.slides/connector/) klasse. Je kunt ze maken, hun uiteinden aan vormen verbinden, verbindingspunten kiezen, ze opnieuw laten routeren, en de geometrie van connectors die aanpassingspunten hebben aanpassen.

## **Connectortypen**

De [ShapeType](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shapetype/) klasse bevat rechte, gebogen en kromme connector‑presets. De onderstaande tabel toont de beschikbare connector‑geometrieën en het aantal aanpassingspunten dat door elk preset wordt gedefinieerd.

| Connector | Image | Aantal aanpassingspunten |
|---|---|---|
| [ShapeType.Line](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shapetype/#Line) | ![shapetype-lineconnector](shapetype-lineconnector.png) | 0 |
| [ShapeType.StraightConnector1](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shapetype/#StraightConnector1) | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0 |
| [ShapeType.BentConnector2](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shapetype/#BentConnector2) | ![shapetype-bent-connector2](shapetype-bent-connector2.png) | 0 |
| [ShapeType.BentConnector3](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shapetype/#BentConnector3) | ![shapetype-bentconnector3](shapetype-bentconnector3.png) | 1 |
| [ShapeType.BentConnector4](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shapetype/#BentConnector4) | ![shapetype-bentconnector4](shapetype-bentconnector4.png) | 2 |
| [ShapeType.BentConnector5](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shapetype/#BentConnector5) | ![shapetype-bentconnector5](shapetype-bentconnector5.png) | 3 |
| [ShapeType.CurvedConnector2](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shapetype/#CurvedConnector2) | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0 |
| [ShapeType.CurvedConnector3](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shapetype/#CurvedConnector3) | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1 |
| [ShapeType.CurvedConnector4](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shapetype/#CurvedConnector4) | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2 |
| [ShapeType.CurvedConnector5](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shapetype/#CurvedConnector5) | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3 |

Het aantal en de betekenis van aanpassingspunten maken deel uit van het geselecteerde connector‑preset. Ga er niet van uit dat twee verschillende connector‑typen dezelfde collectie‑indeling blootleggen.

## **Twee vormen verbinden**

Gebruik [ShapeCollection.addConnector](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shapecollection/#addConnector) om een connector toe te voegen, en gebruik [Connector.setStartShapeConnectedTo](https://reference.aspose.com/slides/nl/python-java/aspose.slides/connector/#setStartShapeConnectedTo) en [Connector.setEndShapeConnectedTo](https://reference.aspose.com/slides/nl/python-java/aspose.slides/connector/#setEndShapeConnectedTo) om de uiteinden te verbinden. Nadat beide uiteinden zijn verbonden, selecteert [Connector.reroute](https://reference.aspose.com/slides/nl/python-java/aspose.slides/connector/#reroute) een korte route tussen de vormen.

Het volgende voorbeeld verbindt een ellips en een rechthoek met een gebogen connector:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    ellipse = slide.getShapes().addAutoShape(ShapeType.Ellipse, 40, 80, 120, 80)
    rectangle = slide.getShapes().addAutoShape(ShapeType.Rectangle, 320, 240, 140, 80)
    connector = slide.getShapes().addConnector(ShapeType.BentConnector2, 0, 0, 10, 10)

    connector.setStartShapeConnectedTo(ellipse)
    connector.setEndShapeConnectedTo(rectangle)
    connector.reroute()

    presentation.save("connected-shapes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="warning" title="Waarschuwing" %}}
Het aanroepen van [reroute](https://reference.aspose.com/slides/nl/python-java/aspose.slides/connector/#reroute) kan de waarden van [setStartShapeConnectionSiteIndex](https://reference.aspose.com/slides/nl/python-java/aspose.slides/connector/#setStartShapeConnectionSiteIndex) en [setEndShapeConnectionSiteIndex](https://reference.aspose.com/slides/nl/python-java/aspose.slides/connector/#setEndShapeConnectionSiteIndex) wijzigen. Wijs specifieke verbindingspunten toe na het opnieuw routeren als die punten vast moeten blijven.
{{% /alert %}}

## **Kies een verbindingspunt**

Elke verbindbare vorm rapporteert het aantal verbindingspunten via [Shape.getConnectionSiteCount](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shape/#getConnectionSiteCount). Valideer een voorkeursindex (nul‑gebaseerd) voordat je deze toekent aan een connector‑uiteinde; het aantal punten varieert per vormgeometrie.

Dit voorbeeld verbindt de connector met een specifiek punt op de ellips wanneer dat punt bestaat:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    ellipse = slide.getShapes().addAutoShape(ShapeType.Ellipse, 40, 80, 120, 80)
    rectangle = slide.getShapes().addAutoShape(ShapeType.Rectangle, 320, 240, 140, 80)
    connector = slide.getShapes().addConnector(ShapeType.BentConnector3, 0, 0, 10, 10)

    connector.setStartShapeConnectedTo(ellipse)
    connector.setEndShapeConnectedTo(rectangle)

    preferred_site_index = 2
    if preferred_site_index < ellipse.getConnectionSiteCount():
        connector.setStartShapeConnectionSiteIndex(preferred_site_index)
    else:
        print(f"The ellipse has only {ellipse.getConnectionSiteCount()} connection sites.")

    presentation.save("specific-connection-site.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Een connectorpunt aanpassen**

Connectors met aanpassingspunten geven ze bloot via [GeometryShape.getAdjustments](https://reference.aspose.com/slides/nl/python-java/aspose.slides/geometryshape/#getAdjustments). Inspecteer elke [AdjustValue](https://reference.aspose.com/slides/nl/python-java/aspose.slides/adjustvalue/) en controleer de [getType](https://reference.aspose.com/slides/nl/python-java/aspose.slides/adjustvalue/#getType) waarde voordat je deze wijzigt met [setRawValue](https://reference.aspose.com/slides/nl/python-java/aspose.slides/adjustvalue/#setRawValue). De algemene regels voor het identificeren van preset‑vormaanpassingen worden beschreven in [Shape Manipulation](/slides/nl/python-java/shape-manipulations/).

Het aantal, de volgorde, de betekenis en het geldige waardebereik van connector‑aanpassingen hangen af van het connector‑preset. Het aanpassingstype is alleen‑lees, terwijl de aanpassingswaarde beschrijfbaar is. De alleen‑lees [getName](https://reference.aspose.com/slides/nl/python-java/aspose.slides/adjustvalue/#getName)‑methode biedt extra identificatie wanneer een connector meer dan één aanpassing van hetzelfde semantische type bevat.

### **Route om een obstakel heen**

In de onderstaande opmaak gaat een [BentConnector5](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shapetype/#BentConnector5) connector tussen twee vormen door een derde vorm:

![connector-obstruction](connector-obstruction.png)

Deze code maakt de geblokkeerde connector:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SaveFormat, LineArrowheadStyle, FillType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getShapes().addAutoShape(ShapeType.Rectangle, 300, 150, 150, 75)
    source_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 500, 400, 100, 50)
    target_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 70, 30)
    connector = slide.getShapes().addConnector(ShapeType.BentConnector5, 20, 20, 400, 300)

    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle)
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    connector.setStartShapeConnectedTo(source_shape)
    connector.setEndShapeConnectedTo(target_shape)
    connector.setStartShapeConnectionSiteIndex(2)

    presentation.save("connector-obstruction.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Het verplaatsen van de verticale buiging verandert de route zodat de connector het obstakel omzeilt:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

In plaats van aan te nemen dat collectie‑index `1` altijd de verticale buiging vertegenwoordigt, zoekt dit voorbeeld naar [ConnectorBendPositionY](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shapeadjustmenttype/#ConnectorBendPositionY) en wijzigt het alleen wanneer het verwachte semantische type aanwezig is:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SaveFormat, LineArrowheadStyle, FillType, ShapeAdjustmentType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getShapes().addAutoShape(ShapeType.Rectangle, 300, 150, 150, 75)
    source_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 500, 400, 100, 50)
    target_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 70, 30)
    connector = slide.getShapes().addConnector(ShapeType.BentConnector5, 20, 20, 400, 300)

    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle)
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    connector.setStartShapeConnectedTo(source_shape)
    connector.setEndShapeConnectedTo(target_shape)
    connector.setStartShapeConnectionSiteIndex(2)

    vertical_bend = None
    for adjustment_index in range(connector.getAdjustments().size()):
        adjustment = connector.getAdjustments().get_Item(adjustment_index)
        print(f"{adjustment.getName()}: {adjustment.getType()}, raw value = {adjustment.getRawValue()}")
        if adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionY:
            vertical_bend = adjustment
            break

    if vertical_bend is None:
        print("The connector does not expose a vertical bend adjustment.")
    else:
        vertical_bend.setRawValue(60000)
        presentation.save("connector-obstruction-fixed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Een [BentConnector5](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shapetype/#BentConnector5) heeft twee [ConnectorBendPositionX](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shapeadjustmenttype/#ConnectorBendPositionX) aanpassingen en één [ConnectorBendPositionY](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shapeadjustmenttype/#ConnectorBendPositionY) aanpassing. Als het type dat je nodig hebt meer dan één keer voorkomt, inspecteer [getName](https://reference.aspose.com/slides/nl/python-java/aspose.slides/adjustvalue/#getName) en de bekende geometrie van dat preset voordat je er één selecteert. Als een aanpassing [ShapeAdjustmentType.Custom](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shapeadjustmenttype/#Custom) meldt, behandel dan de betekenis en het bereik als preset‑specifiek en verander het niet totdat dat contract bekend is.

## **Aanpassingswaarden relateren aan connector‑geometrie**

Voor gebogen connectors kunnen aanpassingswaarden worden gebruikt om de posities van individuele segmenten te schatten. Deze berekeningen zijn specifiek voor het connector‑preset:

- [BentConnector4](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shapetype/#BentConnector4) geeft normaal één [ConnectorBendPositionX](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shapeadjustmenttype/#ConnectorBendPositionX) en één [ConnectorBendPositionY](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shapeadjustmenttype/#ConnectorBendPositionY) aanpassing weer.
- Voor deze buigposities resulteert het delen van de waarde die wordt geretourneerd door [getRawValue](https://reference.aspose.com/slides/nl/python-java/aspose.slides/adjustvalue/#getRawValue) door `100000.0` in de fractie van de connector‑framebreedte of -hoogte die in de onderstaande voorbeelden wordt gebruikt.
- Een connector‑frame kan worden gedraaid of gespiegeld, dus frame‑coördinaten moeten worden getransformeerd voordat ze worden vergeleken met slide‑coördinaten.

De onderstaande voorbeelden gebruiken eerst [getType](https://reference.aspose.com/slides/nl/python-java/aspose.slides/adjustvalue/#getType) om de aanpassingen te identificeren. Ze behandelen collectie‑indexen niet als overdraagbare identifiers.

### **Niet‑geroteerde connector**

De startopmaak bevat twee tekstvormen verbonden door een [BentConnector4](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shapetype/#BentConnector4):

![connector-shape-complex](connector-shape-complex.png)

Dit voorbeeld inspecteert de connector en verkrijgt de horizontale en verticale buig‑aanpassingen:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, LineArrowheadStyle, FillType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25)
    source_shape.getTextFrame().setText("From")
    target_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 60, 25)
    target_shape.getTextFrame().setText("To")
    connector = slide.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300)

    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle)
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED)
    connector.getLineFormat().setWidth(3)
    connector.setStartShapeConnectedTo(source_shape)
    connector.setStartShapeConnectionSiteIndex(3)
    connector.setEndShapeConnectedTo(target_shape)
    connector.setEndShapeConnectionSiteIndex(2)

    for adjustment_index in range(connector.getAdjustments().size()):
        adjustment = connector.getAdjustments().get_Item(adjustment_index)
        print(f"{adjustment.getName()}: {adjustment.getType()}, raw value = {adjustment.getRawValue()}")
finally:
    presentation.dispose()
```

Om beide buigingen te wijzigen, zoek elk verwachte type en wijzig de waarden pas nadat beide gevonden zijn:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SaveFormat, ShapeAdjustmentType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25)
    target_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 60, 25)
    connector = slide.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300)
    connector.setStartShapeConnectedTo(source_shape)
    connector.setStartShapeConnectionSiteIndex(3)
    connector.setEndShapeConnectedTo(target_shape)
    connector.setEndShapeConnectionSiteIndex(2)

    horizontal_bend = None
    vertical_bend = None
    for adjustment_index in range(connector.getAdjustments().size()):
        adjustment = connector.getAdjustments().get_Item(adjustment_index)
        if adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionX:
            horizontal_bend = adjustment
        elif adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionY:
            vertical_bend = adjustment

    if horizontal_bend is None or vertical_bend is None:
        print("The connector does not expose the expected bend adjustments.")
    else:
        horizontal_bend.setRawValue(horizontal_bend.getRawValue() + 20000)
        vertical_bend.setRawValue(vertical_bend.getRawValue() + 200000)
        presentation.save("connector-adjusted.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Het resultaat is een connector waarvan de horizontale en verticale segmenten zijn verplaatst:

![connector-adjusted-1](connector-adjusted-1.png)

Zodra de semantische types bekend zijn, kunnen hun waarden worden omgezet naar connector‑frame‑coördinaten. Dit voorbeeld tekent een dunne rechthoek over het verticale segment dat wordt beheerst door de twee buig‑aanpassingen:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SaveFormat, ShapeAdjustmentType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25)
    target_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 60, 25)
    connector = slide.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300)
    connector.setStartShapeConnectedTo(source_shape)
    connector.setStartShapeConnectionSiteIndex(3)
    connector.setEndShapeConnectedTo(target_shape)
    connector.setEndShapeConnectionSiteIndex(2)

    horizontal_bend = None
    vertical_bend = None
    for adjustment_index in range(connector.getAdjustments().size()):
        adjustment = connector.getAdjustments().get_Item(adjustment_index)
        if adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionX:
            horizontal_bend = adjustment
        elif adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionY:
            vertical_bend = adjustment

    if horizontal_bend is None or vertical_bend is None:
        print("The connector does not expose the expected bend adjustments.")
    else:
        x = connector.getX() + connector.getWidth() * horizontal_bend.getRawValue() / 100000.0
        y = connector.getY()
        height = connector.getHeight() * vertical_bend.getRawValue() / 100000.0
        slide.getShapes().addAutoShape(ShapeType.Rectangle, x, y, 1, height)
        presentation.save("connector-segment-guide.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

De hulplijn markeert het berekende segment:

![connector-adjusted-2](connector-adjusted-2.png)

### **Gedraaide of gespiegelde connector**

Wanneer dezelfde connector‑geometrie verticaal georiënteerd is, beïnvloeden de waarden van [Shape.getFrame](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shape/#getFrame), [ShapeFrame.getFlipH](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shapeframe/#getFlipH) en [ShapeFrame.getFlipV](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shapeframe/#getFlipV) de conversie van connector‑frame‑coördinaten naar slide‑coördinaten.

Dit voorbeeld maakt en past de verticaal georiënteerde connector aan:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SaveFormat, LineArrowheadStyle, FillType, ShapeAdjustmentType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25)
    source_shape.getTextFrame().setText("From")
    target_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 400, 60, 25)
    target_shape.getTextFrame().setText("To 1")
    connector = slide.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300)

    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle)
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    connector_color = Color(102, 205, 170)
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(connector_color)
    connector.getLineFormat().setWidth(3)
    connector.setStartShapeConnectedTo(source_shape)
    connector.setStartShapeConnectionSiteIndex(2)
    connector.setEndShapeConnectedTo(target_shape)
    connector.setEndShapeConnectionSiteIndex(3)

    for adjustment_index in range(connector.getAdjustments().size()):
        adjustment = connector.getAdjustments().get_Item(adjustment_index)
        if adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionX:
            adjustment.setRawValue(adjustment.getRawValue() + 20000)
        elif adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionY:
            adjustment.setRawValue(adjustment.getRawValue() + 200000)

    presentation.save("vertical-connector-adjusted.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

De aangepaste connector verschijnt verticaal tussen de vormen:

![connector-adjusted-3](connector-adjusted-3.png)

Voor een willekeurige rotatiehoek `alpha` wordt een connector‑frame‑punt `(x, y)` rond het frame‑centrum `(x0, y0)` geroteerd:

`X = (x - x0) * cos(alpha) - (y - y0) * sin(alpha) + x0`

`Y = (x - x0) * sin(alpha) + (y - y0) * cos(alpha) + y0`

De onderstaande code behandelt de 90‑graden oriëntatie die in dit voorbeeld wordt gebruikt en tekent een rode hulplijn over het overeenkomstige connector‑segment:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SaveFormat, FillType, ShapeAdjustmentType, NullableBool

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25)
    target_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 400, 60, 25)
    connector = slide.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300)
    connector.setStartShapeConnectedTo(source_shape)
    connector.setStartShapeConnectionSiteIndex(2)
    connector.setEndShapeConnectedTo(target_shape)
    connector.setEndShapeConnectionSiteIndex(3)

    horizontal_bend = None
    vertical_bend = None
    for adjustment_index in range(connector.getAdjustments().size()):
        adjustment = connector.getAdjustments().get_Item(adjustment_index)
        if adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionX:
            horizontal_bend = adjustment
        elif adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionY:
            vertical_bend = adjustment

    if horizontal_bend is None or vertical_bend is None:
        print("The connector does not expose the expected bend adjustments.")
    else:
        horizontal_bend.setRawValue(horizontal_bend.getRawValue() + 20000)
        vertical_bend.setRawValue(vertical_bend.getRawValue() + 200000)

        x = connector.getX()
        y = connector.getY()
        if connector.getFrame().getFlipH() == NullableBool.True_:
            x += connector.getWidth()
        if connector.getFrame().getFlipV() == NullableBool.True_:
            y += connector.getHeight()

        x += connector.getWidth() * horizontal_bend.getRawValue() / 100000.0
        rotated_x = connector.getFrame().getCenterX() - y + connector.getFrame().getCenterY()
        rotated_y = x - connector.getFrame().getCenterX() + connector.getFrame().getCenterY()
        segment_width = connector.getHeight() * vertical_bend.getRawValue() / 100000.0
        guide = slide.getShapes().addAutoShape(ShapeType.Rectangle, rotated_x, rotated_y, segment_width, 1)
        guide.getLineFormat().getFillFormat().setFillType(FillType.Solid)
        guide.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED)

        presentation.save("rotated-connector-segment-guide.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

De rode hulplijn markeert het berekende segment na de coördinatentransformatie:

![connector-adjusted-4](connector-adjusted-4.png)

Deze formules beschrijven de presets die in de voorbeelden worden gebruikt, niet een universeel connector‑model. Valideer de aanpassingstypen, frame‑oriëntatie en waardebereiken voordat je dezelfde berekening op een ander preset toepast.

## **Vind de richtinghoek van een connector**

De richting van een rechte connector kan worden berekend uit zijn breedte en hoogte, met horizontale en verticale flips toegepast. Het volgende voorbeeld geeft de met de klok mee draaihoek ten opzichte van de positieve horizontale as in slide‑coördinaten weer:

```python
import jpype
import asposeslides
import math

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, NullableBool

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    connector = slide.getShapes().addConnector(ShapeType.StraightConnector1, 100, 100, 200, 100)

    flip_h = connector.getFrame().getFlipH() == NullableBool.True_
    flip_v = connector.getFrame().getFlipV() == NullableBool.True_
    delta_x = connector.getWidth() * (-1 if flip_h else 1)
    delta_y = connector.getHeight() * (-1 if flip_v else 1)
    angle = math.atan2(delta_y, delta_x) * 180.0 / math.pi

    if angle < 0:
        angle += 360

    print(f"Connector direction: {angle:.2f} degrees")
finally:
    presentation.dispose()
```

## **FAQ**

**Hoe kan ik zien of een connector aan een vorm kan worden bevestigd?**

Controleer de waarde van [getConnectionSiteCount](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shape/#getConnectionSiteCount) van de vorm. Een positieve telling betekent dat de vorm verbindingspunten blootlegt. Valideer de geselecteerde punt‑index voordat je deze toekent aan een connector‑uiteinde.

**Kan ik een connector‑aanpassing identificeren op basis van de collectie‑index?**

Een index is alleen betekenisvol voor een bekend connector‑preset en collectie‑indeling. Controleer [AdjustValue.getType](https://reference.aspose.com/slides/nl/python-java/aspose.slides/adjustvalue/#getType) vóór het wijzigen van een waarde, en gebruik [AdjustValue.getName](https://reference.aspose.com/slides/nl/python-java/aspose.slides/adjustvalue/#getName) als aanvullende informatie wanneer hetzelfde semantische type meer dan eens voorkomt.

**Wat gebeurt er als een verbonden vorm wordt verwijderd?**

Het overeenkomstige connector‑uiteinde wordt losgekoppeld. De connector blijft op de slide aanwezig en kan worden verwijderd, als een losse lijn worden gepositioneerd, of aan een andere vorm worden gekoppeld.

**Worden connector‑koppelingen behouden wanneer een slide wordt gekopieerd?**

Koppelingen blijven over het algemeen behouden wanneer de verbonden vormen samen met de slide worden gekopieerd. Als een connector wordt gekopieerd zonder één van de doelvormen, moet het getroffen uiteinde opnieuw worden gekoppeld.