---
title: Hantera anslutningar i presentationer i Python via Java
linktitle: Anslutning
type: docs
weight: 10
url: /sv/python-java/connector/
keywords:
- anslutning
- anslutningstyp
- anslutningspunkt
- anslutningslinje
- anslutningsvinkel
- anslutningsställe
- justeringspunkt
- anslut former
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Lär dig hur du lägger till, fäster, omruttar, justerar och granskar raka, böjda och kurviga PowerPoint-anslutningar med Aspose.Slides för Python via Java."
---
## **Översikt**

En anslutning är en linje som kan förbli fäst vid två former när någon av formerna flyttas. Dess ändar fästs vid anslutningsställen, representerade av gröna prickar i PowerPoint. Vissa böjda och kurviga anslutningar har också justeringspunkter, representerade av orange prickar, som styr positionen för enskilda anslutningssegment.

Aspose.Slides representerar anslutningar genom klassen [Connector](https://reference.aspose.com/slides/sv/python-java/aspose.slides/connector/). Du kan skapa dem, fästa deras ändar till former, välja anslutningsställen, omrouta dem och modifiera geometrin för anslutningar som har justeringspunkter.

## **Anslutningstyper**

Klassen [ShapeType](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shapetype/) innehåller förinställningar för raka, böjda och kurviga anslutningar. Tabellen nedan visar de tillgängliga anslutningsgeometrierna och antalet justeringspunkter som definieras av varje förinställning.

| Anslutning | Bild | Antal justeringspunkter |
|---|---|---|
| [ShapeType.Line](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shapetype/#Line) | ![shapetype-lineconnector](shapetype-lineconnector.png) | 0 |
| [ShapeType.StraightConnector1](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shapetype/#StraightConnector1) | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0 |
| [ShapeType.BentConnector2](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shapetype/#BentConnector2) | ![shapetype-bent-connector2](shapetype-bent-connector2.png) | 0 |
| [ShapeType.BentConnector3](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shapetype/#BentConnector3) | ![shapetype-bentconnector3](shapetype-bentconnector3.png) | 1 |
| [ShapeType.BentConnector4](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shapetype/#BentConnector4) | ![shapetype-bentconnector4](shapetype-bentconnector4.png) | 2 |
| [ShapeType.BentConnector5](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shapetype/#BentConnector5) | ![shapetype-bentconnector5](shapetype-bentconnector5.png) | 3 |
| [ShapeType.CurvedConnector2](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shapetype/#CurvedConnector2) | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0 |
| [ShapeType.CurvedConnector3](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shapetype/#CurvedConnector3) | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1 |
| [ShapeType.CurvedConnector4](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shapetype/#CurvedConnector4) | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2 |
| [ShapeType.CurvedConnector5](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shapetype/#CurvedConnector5) | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3 |

Antalet och betydelsen av justeringspunkter är en del av den valda anslutningsförinställningen. Anta inte att två olika anslutningstyper exponerar samma samlingslayout.

## **Anslut två former**

Använd [ShapeCollection.addConnector](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shapecollection/#addConnector) för att lägga till en anslutning, och använd [Connector.setStartShapeConnectedTo](https://reference.aspose.com/slides/sv/python-java/aspose.slides/connector/#setStartShapeConnectedTo) samt [Connector.setEndShapeConnectedTo](https://reference.aspose.com/slides/sv/python-java/aspose.slides/connector/#setEndShapeConnectedTo) för att fästa dess ändar. När båda ändarna är fästa väljer [Connector.reroute](https://reference.aspose.com/slides/sv/python-java/aspose.slides/connector/#reroute) en kort väg mellan formerna.

Följande exempel ansluter en ellips och en rektangel med en böjd anslutning:

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

{{% alert color="warning" title="Warning" %}}

Att anropa [reroute](https://reference.aspose.com/slides/sv/python-java/aspose.slides/connector/#reroute) kan ändra värdena för [setStartShapeConnectionSiteIndex](https://reference.aspose.com/slides/sv/python-java/aspose.slides/connector/#setStartShapeConnectionSiteIndex) och [setEndShapeConnectionSiteIndex](https://reference.aspose.com/slides/sv/python-java/aspose.slides/connector/#setEndShapeConnectionSiteIndex). Tilldela specifika anslutningsställen efter omruttning om dessa ställen måste förbli fasta.

{{% /alert %}}

## **Välj ett anslutningsställe**

Varje form som kan anslutas rapporterar sitt antal ställen via [Shape.getConnectionSiteCount](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shape/#getConnectionSiteCount). Validera ett föredraget nollbaserat ställesindex innan du tilldelar det till en anslutningsände; antalet ställen varierar beroende på formens geometri.

Detta exempel fäster anslutningen till ett specifikt ställe på ellipsen när det stället finns:

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

## **Justera en anslutningspunkt**

Anslutningar med justeringspunkter exponerar dem via [GeometryShape.getAdjustments](https://reference.aspose.com/slides/sv/python-java/aspose.slides/geometryshape/#getAdjustments). Inspektera varje [AdjustValue](https://reference.aspose.com/slides/sv/python-java/aspose.slides/adjustvalue/) och kontrollera dess [getType](https://reference.aspose.com/slides/sv/python-java/aspose.slides/adjustvalue/#getType)-värde innan du ändrar det med [setRawValue](https://reference.aspose.com/slides/sv/python-java/aspose.slides/adjustvalue/#setRawValue). De allmänna reglerna för att identifiera förinställda formjusteringar beskrivs i [Shape Manipulation](/slides/sv/python-java/shape-manipulations/).

Antalet, ordningen, betydelsen och det giltiga värdeintervallet för anslutningsjusteringar beror på anslutningsförinställningen. Justeringstypen är skrivskyddad, medan justeringsvärdet är skrivbart. Den skrivskyddade [getName](https://reference.aspose.com/slides/sv/python-java/aspose.slides/adjustvalue/#getName)-metoden ger ytterligare identifiering när en anslutning innehåller mer än en justering av samma semantiska typ.

### **Rutt runt ett hinder**

I följande layout passerar en [BentConnector5](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shapetype/#BentConnector5) mellan två former genom en tredje form:

![connector-obstruction](connector-obstruction.png)

Denna kod skapar den hindrade anslutningen:

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

Att flytta den vertikala böjen ändrar rutten så att anslutningen passerar förbi hindret:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

Istället för att anta att samlingsindex `1` alltid representerar den vertikala böjen söker detta exempel efter [ConnectorBendPositionY](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shapeadjustmenttype/#ConnectorBendPositionY) och ändrar det endast när den förväntade semantiska typen finns:

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

En [BentConnector5](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shapetype/#BentConnector5) har två [ConnectorBendPositionX](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shapeadjustmenttype/#ConnectorBendPositionX)-justeringar och en [ConnectorBendPositionY](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shapeadjustmenttype/#ConnectorBendPositionY)-justering. Om den typ du behöver förekommer flera gånger, inspektera [getName](https://reference.aspose.com/slides/sv/python-java/aspose.slides/adjustvalue/#getName) och den kända geometrin för den förinställningen innan du väljer en. Om en justering rapporterar [ShapeAdjustmentType.Custom](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shapeadjustmenttype/#Custom), behandla dess betydelse och intervall som förinställningsspecifika och ändra den inte förrän kontraktet är känt.

## **Relatera justeringsvärden till anslutningsgeometri**

För böjda anslutningar kan justeringsvärden användas för att uppskatta positionerna för enskilda segment. Dessa beräkningar är specifika för anslutningsförinställningen:

- [BentConnector4](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shapetype/#BentConnector4) exponerar normalt en [ConnectorBendPositionX](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shapeadjustmenttype/#ConnectorBendPositionX) och en [ConnectorBendPositionY](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shapeadjustmenttype/#ConnectorBendPositionY)-justering.
- För dessa böjningspositioner ger division av värdet som returneras av [getRawValue](https://reference.aspose.com/slides/sv/python-java/aspose.slides/adjustvalue/#getRawValue) med `100000.0` bråkdelen av anslutningsramens bredd eller höjd som används i exemplen nedan.
- En anslutningsram kan vara roterad eller speglad, så ramkoordinater måste transformeras innan de jämförs med bildkoordinater.

Följande exempel använder [getType](https://reference.aspose.com/slides/sv/python-java/aspose.slides/adjustvalue/#getType) för att först identifiera justeringarna. De behandlar inte samlingsindex som bärbara identifierare.

### **Ej roterad anslutning**

Den initiala layouten innehåller två textrutor anslutna med en [BentConnector4](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shapetype/#BentConnector4):

![connector-shape-complex](connector-shape-complex.png)

Detta exempel inspekterar anslutningen och hämtar dess horisontella och vertikala böjningsjusteringar:

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

För att ändra båda böjarna, lokalisera varje förväntad typ och modifiera värdena först när båda har hittats:

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

Resultatet är en anslutning vars horisontella och vertikala segment har flyttats:

![connector-adjusted-1](connector-adjusted-1.png)

När de semantiska typerna är kända kan deras värden konverteras till anslutningsramens koordinater. Detta exempel ritar en tunn rektangel över det vertikala segmentet som styrs av de två böjningsjusteringarna:

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

Guidformen markerar det beräknade segmentet:

![connector-adjusted-2](connector-adjusted-2.png)

### **Roterad eller speglad anslutning**

När samma anslutningsgeometri orienteras vertikalt påverkar [Shape.getFrame](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shape/#getFrame), [ShapeFrame.getFlipH](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shapeframe/#getFlipH) och [ShapeFrame.getFlipV](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shapeframe/#getFlipV)-värdena konverteringen från anslutningsramens koordinater till bildkoordinater.

Detta exempel skapar och justerar den vertikalt orienterade anslutningen:

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

Den justerade anslutningen visas vertikalt mellan formerna:

![connector-adjusted-3](connector-adjusted-3.png)

För en godtycklig rotationsvinkel `alpha` roteras en punkt i anslutningsramen `(x, y)` kring ramens centrum `(x0, y0)`:

`X = (x - x0) * cos(alpha) - (y - y0) * sin(alpha) + x0`

`Y = (x - x0) * sin(alpha) + (y - y0) * cos(alpha) + y0`

Följande kod hanterar den 90‑graders orientering som används i detta exempel och ritar en röd guide över motsvarande anslutningssegment:

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

Den röda guiden markerar det beräknade segmentet efter koordinattransformationen:

![connector-adjusted-4](connector-adjusted-4.png)

Dessa formler beskriver de förinställningar som används i exemplen, inte en universell anslutningsmodell. Validera justeringstyper, ramorientering och värdeintervall innan du tillämpar samma beräkning på en annan förinställning.

## **Hitta en anslutningsriktningens vinkel**

Riktningen för en rak anslutning kan beräknas från dess bredd och höjd, med horisontella och vertikala speglingar tillämpade. Följande exempel rapporterar den medurs vinkel från den positiva horisontella axeln i bildkoordinater:

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

**Hur kan jag avgöra om en anslutning kan fästas vid en form?**

Kontrollera formens [getConnectionSiteCount](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shape/#getConnectionSiteCount)-värde. Ett positivt antal innebär att formen exponerar anslutningsställen. Validera det valda ställesindexet innan du tilldelar det till någon av anslutningens ändar.

**Kan jag identifiera en anslutningsjustering via dess samlingsindex?**

Ett index är meningsfullt endast för en känd anslutningsförinställning och samlingslayout. Kontrollera [AdjustValue.getType](https://reference.aspose.com/slides/sv/python-java/aspose.slides/adjustvalue/#getType) innan du modifierar ett värde, och använd [AdjustValue.getName](https://reference.aspose.com/slides/sv/python-java/aspose.slides/adjustvalue/#getName) som ytterligare information när samma semantiska typ förekommer flera gånger.

**Vad händer när en ansluten form tas bort?**

Den motsvarande anslutningsänden blir frånkopplad. Ansutningen kvarstår på bilden och kan tas bort, placeras som en fri linje eller fästas till en annan form.

**Bevaras anslutningsbindningar när en bild kopieras?**

Bindningarna bevaras i regel när de anslutna formerna kopieras med bilden. Om en anslutning kopieras utan någon av sina målformer måste den berörda änden fästas på nytt.