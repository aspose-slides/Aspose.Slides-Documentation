---
title: Hantera konnektorer i presentationer med Python
linktitle: Konnektor
type: docs
weight: 10
url: /sv/python-net/connector/
keywords:
- konnektor
- konnektortyp
- konnektorpunk
- konnektorlina
- konnektorsvinkel
- anslutningsplats
- justeringspunkt
- anslut former
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Lär dig hur du lägger till, fäster, omröder, justerar och inspekterar raka, böjda och kurvade PowerPoint-konnek­torer med Aspose.Slides för Python via .NET."
---
## **Översikt**

En konnektor är en linje som kan förbli fäst vid två former när någon av formerna flyttas. Dess ändar kopplas till anslutningsställen, som visas som gröna prickar i PowerPoint. Vissa böjda och kurvade konnektorer visar också justeringspunkter, som visas som orange prickar, som styr positionen för enskilda konnektorsegment.

Aspose.Slides representerar konnektorer via gränssnittet [IConnector](https://reference.aspose.com/slides/sv/python-net/aspose.slides/iconnector/). Du kan skapa dem, fästa deras ändar på former, välja anslutningsställen, omröda dem och modifiera geometrin för konnektorer som har justeringspunkter.

## **Konnektortyper**

[ShapeType](https://reference.aspose.com/slides/sv/python-net/aspose.slides/shapetype/)-uppräkningen innehåller raka, böjda och kurvade konnektorpresetar. Tabellen nedan visar de tillgängliga konnektorgeometrierna och antalet justeringspunkter som definieras av varje preset.

| Konnektor | Bild | Antal justeringspunkter |
|---|---|---|
| `ShapeType.LINE` | ![shapetype-lineconnector](shapetype-lineconnector.png) | 0 |
| `ShapeType.STRAIGHT_CONNECTOR1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0 |
| `ShapeType.BENT_CONNECTOR2` | ![shapetype-bent-connector2](shapetype-bent-connector2.png) | 0 |
| `ShapeType.BENT_CONNECTOR3` | ![shapetype-bentconnector3](shapetype-bentconnector3.png) | 1 |
| `ShapeType.BENT_CONNECTOR4` | ![shapetype-bentconnector4](shapetype-bentconnector4.png) | 2 |
| `ShapeType.BENT_CONNECTOR5` | ![shapetype-bentconnector5](shapetype-bentconnector5.png) | 3 |
| `ShapeType.CURVED_CONNECTOR2` | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0 |
| `ShapeType.CURVED_CONNECTOR3` | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1 |
| `ShapeType.CURVED_CONNECTOR4` | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2 |
| `ShapeType.CURVED_CONNECTOR5` | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3 |

Antalet och betydelsen av justeringspunkter är en del av den valda konnektorpreseten. Anta inte att två olika konnektortyper exponerar samma kollektionslayout.

## **Koppla två former**

Använd [IShapeCollection.add_connector](https://reference.aspose.com/slides/sv/python-net/aspose.slides/ishapecollection/add_connector/) för att lägga till en konnektor och tilldela dess egenskaper [start_shape_connected_to](https://reference.aspose.com/slides/sv/python-net/aspose.slides/iconnector/start_shape_connected_to/) och [end_shape_connected_to](https://reference.aspose.com/slides/sv/python-net/aspose.slides/iconnector/end_shape_connected_to/). När båda ändarna är fästa väljer [IConnector.reroute](https://reference.aspose.com/slides/sv/python-net/aspose.slides/iconnector/reroute/) en kortare bana mellan formerna.

Följande exempel kopplar en ellips och en rektangel med en böjd konnektor:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    ellipse = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 40, 80, 120, 80)
    rectangle = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 320, 240, 140, 80)
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR2, 0, 0, 10, 10)

    connector.start_shape_connected_to = ellipse
    connector.end_shape_connected_to = rectangle
    connector.reroute()

    presentation.save("connected-shapes.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="warning" title="Warning" %}}
Att anropa `reroute` kan ändra värdena för [start_shape_connection_site_index](https://reference.aspose.com/slides/sv/python-net/aspose.slides/iconnector/start_shape_connection_site_index/) och [end_shape_connection_site_index](https://reference.aspose.com/slides/sv/python-net/aspose.slides/iconnector/end_shape_connection_site_index/). Tilldela specifika anslutningsställen efter omröjning om dessa ställen måste förbli fasta.
{{% /alert %}}

## **Välj en anslutningsplats**

Varje anslutningsbar form rapporterar sitt antal ställen via [connection_site_count](https://reference.aspose.com/slides/sv/python-net/aspose.slides/igeometryshape/connection_site_count/). Validera ett föredraget nollbaserat platsindex innan du tilldelar det till en konnektors ände; antalet platser varierar beroende på formens geometri.

Detta exempel fäster konnektorn på en specifik plats på ellipsen när den platsen finns:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    ellipse = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 40, 80, 120, 80)
    rectangle = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 320, 240, 140, 80)
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR3, 0, 0, 10, 10)

    connector.start_shape_connected_to = ellipse
    connector.end_shape_connected_to = rectangle

    preferred_site_index = 2
    if preferred_site_index < ellipse.connection_site_count:
        connector.start_shape_connection_site_index = preferred_site_index
    else:
        print(f"The ellipse has only {ellipse.connection_site_count} connection sites.")

    presentation.save("specific-connection-site.pptx", slides.export.SaveFormat.PPTX)
```

## **Justera en konnektorpunkts position**

Konnektorer med justeringspunkter exponerar dem via [IGeometryShape.adjustments](https://reference.aspose.com/slides/sv/python-net/aspose.slides/igeometryshape/adjustments/). Inspektera varje [IAdjustValue](https://reference.aspose.com/slides/sv/python-net/aspose.slides/iadjustvalue/) och kontrollera dess [type](https://reference.aspose.com/slides/sv/python-net/aspose.slides/iadjustvalue/type/) innan du ändrar dess [raw_value](https://reference.aspose.com/slides/sv/python-net/aspose.slides/iadjustvalue/raw_value/). För allmän formmanipulering, se [Formmanipulering](/slides/sv/python-net/shape-manipulations/).

Antalet, ordningen, betydelsen och det giltiga värdeintervallet för konnektorrejusteringar beror på konnektorpreseten. `type`‑egenskapen är skrivskyddad, medan justeringsvärdet är skrivbart. Den skrivskyddade [name](https://reference.aspose.com/slides/sv/python-net/aspose.slides/iadjustvalue/name/)‑egenskapen ger ytterligare identifiering när en konnektor innehåller mer än en justering av samma semantiska typ.

### **Rutt runt ett hinder**

I layouten nedan passerar en `ShapeType.BENT_CONNECTOR5`‑konnektor mellan två former genom en tredje form:

![connector-obstruction](connector-obstruction.png)

Denna kod skapar den blockerade konnektorn:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 150, 150, 75)
    source_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 400, 100, 50)
    target_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 70, 30)
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR5, 20, 20, 400, 300)

    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.black
    connector.start_shape_connected_to = source_shape
    connector.end_shape_connected_to = target_shape
    connector.start_shape_connection_site_index = 2

    presentation.save("connector-obstruction.pptx", slides.export.SaveFormat.PPTX)
```

Att flytta den vertikala böjen ändrar rutten så att konnektorn går runt hindret:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

Istället för att anta att kollektionsindex `1` alltid representerar den vertikala böjen, söker detta exempel efter `ShapeAdjustmentType.CONNECTOR_BEND_POSITION_Y` och ändrar den endast när den förväntade semantiska typen finns:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 150, 150, 75)
    source_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 400, 100, 50)
    target_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 70, 30)
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR5, 20, 20, 400, 300)

    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.black
    connector.start_shape_connected_to = source_shape
    connector.end_shape_connected_to = target_shape
    connector.start_shape_connection_site_index = 2

    vertical_bend = None
    for adjustment_index in range(len(connector.adjustments)):
        adjustment = connector.adjustments[adjustment_index]
        print(f"{adjustment.name}: {adjustment.type}, raw value = {adjustment.raw_value}")
        if adjustment.type == slides.ShapeAdjustmentType.CONNECTOR_BEND_POSITION_Y:
            vertical_bend = adjustment
            break

    if vertical_bend is None:
        print("The connector does not expose a vertical bend adjustment.")
    else:
        vertical_bend.raw_value = 60000
        presentation.save("connector-obstruction-fixed.pptx", slides.export.SaveFormat.PPTX)
```

En `ShapeType.BENT_CONNECTOR5` har två justeringar av typen `ShapeAdjustmentType.CONNECTOR_BEND_POSITION_X` och en justering av typen `ShapeAdjustmentType.CONNECTOR_BEND_POSITION_Y`. Om den typ du behöver förekommer mer än en gång, inspektera `name` och den kända geometrin för den preseten innan du väljer en. Om en justering rapporterar [ShapeAdjustmentType.CUSTOM](https://reference.aspose.com/slides/sv/python-net/aspose.slides/shapeadjustmenttype/), behandla dess betydelse och intervall som preset‑specifikt och ändra den inte förrän den kontrakten är känd.

## **Relatera justeringsvärden till konnektorgeometri**

För böjda konnektorer kan justeringsvärden användas för att uppskatta positionerna för enskilda segment. Dessa beräkningar är specifika för konnektorpreseten:

- `ShapeType.BENT_CONNECTOR4` exponerar normalt en `ShapeAdjustmentType.CONNECTOR_BEND_POSITION_X`‑justering och en `ShapeAdjustmentType.CONNECTOR_BEND_POSITION_Y`‑justering.
- För dessa böjpositioner ger `raw_value / 100000` bråkdelen av konnektorns rambredd eller -höjd som används i exemplen nedan.
- En konnektorram kan roteras eller vändas, så ramkoordinater måste transformeras innan de jämförs med bildkoordinater.

Följande exempel använder `type` för att först identifiera justeringarna. De behandlar inte kollektionsindex som portabla identifierare.

### **Orotad konnektor**

Den initiala layouten innehåller två textformer kopplade med en `ShapeType.BENT_CONNECTOR4`:

![connector-shape-complex](connector-shape-complex.png)

Detta exempel inspekterar konnektorn och hämtar dess horisontella och vertikala böjningsjusteringar:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    source_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 60, 25)
    source_shape.text_frame.text = "From"
    target_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 100, 60, 25)
    target_shape.text_frame.text = "To"
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)

    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.crimson
    connector.line_format.width = 3
    connector.start_shape_connected_to = source_shape
    connector.start_shape_connection_site_index = 3
    connector.end_shape_connected_to = target_shape
    connector.end_shape_connection_site_index = 2

    for adjustment_index in range(len(connector.adjustments)):
        adjustment = connector.adjustments[adjustment_index]
        print(f"{adjustment.name}: {adjustment.type}, raw value = {adjustment.raw_value}")
```

För att ändra båda böjerna, lokalisera varje förväntad typ och modifiera värdena först när båda har hittats:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    source_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 60, 25)
    target_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 100, 60, 25)
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)
    connector.start_shape_connected_to = source_shape
    connector.start_shape_connection_site_index = 3
    connector.end_shape_connected_to = target_shape
    connector.end_shape_connection_site_index = 2

    horizontal_bend = None
    vertical_bend = None
    for adjustment_index in range(len(connector.adjustments)):
        adjustment = connector.adjustments[adjustment_index]
        if adjustment.type == slides.ShapeAdjustmentType.CONNECTOR_BEND_POSITION_X:
            horizontal_bend = adjustment
        elif adjustment.type == slides.ShapeAdjustmentType.CONNECTOR_BEND_POSITION_Y:
            vertical_bend = adjustment

    if horizontal_bend is None or vertical_bend is None:
        print("The connector does not expose the expected bend adjustments.")
    else:
        horizontal_bend.raw_value += 20000
        vertical_bend.raw_value += 200000
        presentation.save("connector-adjusted.pptx", slides.export.SaveFormat.PPTX)
```

Resultatet är en konnektor vars horisontella och vertikala segment har förflyttats:

![connector-adjusted-1](connector-adjusted-1.png)

När de semantiska typerna är kända kan deras värden konverteras till konnektorram‑koordinater. Detta exempel ritar en tunn rektangel över det vertikala segmentet som styrs av de två böjningsjusteringarna:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    source_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 60, 25)
    target_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 100, 60, 25)
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)
    connector.start_shape_connected_to = source_shape
    connector.start_shape_connection_site_index = 3
    connector.end_shape_connected_to = target_shape
    connector.end_shape_connection_site_index = 2

    horizontal_bend = None
    vertical_bend = None
    for adjustment_index in range(len(connector.adjustments)):
        adjustment = connector.adjustments[adjustment_index]
        if adjustment.type == slides.ShapeAdjustmentType.CONNECTOR_BEND_POSITION_X:
            horizontal_bend = adjustment
        elif adjustment.type == slides.ShapeAdjustmentType.CONNECTOR_BEND_POSITION_Y:
            vertical_bend = adjustment

    if horizontal_bend is None or vertical_bend is None:
        print("The connector does not expose the expected bend adjustments.")
    else:
        x = connector.x + connector.width * horizontal_bend.raw_value / 100000
        y = connector.y
        height = connector.height * vertical_bend.raw_value / 100000
        slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, x, y, 1, height)
        presentation.save("connector-segment-guide.pptx", slides.export.SaveFormat.PPTX)
```

Guideformen markerar det beräknade segmentet:

![connector-adjusted-2](connector-adjusted-2.png)

### **Roterad eller speglad konnektor**

När samma konnektorgeometri är orienterad vertikalt påverkar dess [frame](https://reference.aspose.com/slides/sv/python-net/aspose.slides/iconnector/frame/), [flip_h](https://reference.aspose.com/slides/sv/python-net/aspose.slides/ishapeframe/flip_h/) och [flip_v](https://reference.aspose.com/slides/sv/python-net/aspose.slides/ishapeframe/flip_v/)‑värden omvandlingen från konnektorram‑koordinater till bildkoordinater.

Detta exempel skapar och justerar den vertikalt orienterade konnektorn:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    source_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 60, 25)
    source_shape.text_frame.text = "From"
    target_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 400, 60, 25)
    target_shape.text_frame.text = "To 1"
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)

    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.medium_aquamarine
    connector.line_format.width = 3
    connector.start_shape_connected_to = source_shape
    connector.start_shape_connection_site_index = 2
    connector.end_shape_connected_to = target_shape
    connector.end_shape_connection_site_index = 3

    for adjustment_index in range(len(connector.adjustments)):
        adjustment = connector.adjustments[adjustment_index]
        if adjustment.type == slides.ShapeAdjustmentType.CONNECTOR_BEND_POSITION_X:
            adjustment.raw_value += 20000
        elif adjustment.type == slides.ShapeAdjustmentType.CONNECTOR_BEND_POSITION_Y:
            adjustment.raw_value += 200000

    presentation.save("vertical-connector-adjusted.pptx", slides.export.SaveFormat.PPTX)
```

Den justerade konnektorn visas vertikalt mellan formerna:

![connector-adjusted-3](connector-adjusted-3.png)

För en godtycklig rotationsvinkel `alpha` roteras en konnektorram‑punkt `(x, y)` kring ramens centrum `(x0, y0)`:

`X = (x - x0) * cos(alpha) - (y - y0) * sin(alpha) + x0`

`Y = (x - x0) * sin(alpha) + (y - y0) * cos(alpha) + y0`

Följande kod hanterar den 90‑graders orientering som används i detta exempel och ritar en röd guide över motsvarande konnektorsegment:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    source_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 60, 25)
    target_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 400, 60, 25)
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)
    connector.start_shape_connected_to = source_shape
    connector.start_shape_connection_site_index = 2
    connector.end_shape_connected_to = target_shape
    connector.end_shape_connection_site_index = 3

    horizontal_bend = None
    vertical_bend = None
    for adjustment_index in range(len(connector.adjustments)):
        adjustment = connector.adjustments[adjustment_index]
        if adjustment.type == slides.ShapeAdjustmentType.CONNECTOR_BEND_POSITION_X:
            horizontal_bend = adjustment
        elif adjustment.type == slides.ShapeAdjustmentType.CONNECTOR_BEND_POSITION_Y:
            vertical_bend = adjustment

    if horizontal_bend is None or vertical_bend is None:
        print("The connector does not expose the expected bend adjustments.")
    else:
        horizontal_bend.raw_value += 20000
        vertical_bend.raw_value += 200000

        x = connector.x
        y = connector.y
        if connector.frame.flip_h == slides.NullableBool.TRUE:
            x += connector.width
        if connector.frame.flip_v == slides.NullableBool.TRUE:
            y += connector.height

        x += connector.width * horizontal_bend.raw_value / 100000
        rotated_x = connector.frame.center_x - y + connector.frame.center_y
        rotated_y = x - connector.frame.center_x + connector.frame.center_y
        segment_width = connector.height * vertical_bend.raw_value / 100000
        guide = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, rotated_x, rotated_y, segment_width, 1)
        guide.line_format.fill_format.fill_type = slides.FillType.SOLID
        guide.line_format.fill_format.solid_fill_color.color = draw.Color.red

        presentation.save("rotated-connector-segment-guide.pptx", slides.export.SaveFormat.PPTX)
```

Den röda guiden markerar det beräknade segmentet efter koordinattransformationen:

![connector-adjusted-4](connector-adjusted-4.png)

Dessa formler beskriver presetarna som används i exemplen, inte en universell konnektormodell. Validera justeringstyperna, ramorienteringen och värdeintervallen innan du tillämpar samma beräkning på en annan preset.

## **Hitta en konnektors riktningsvinkel**

Riktningen för en rak konnektor kan beräknas från dess bredd och höjd, med horisontella och vertikala vändningar tillämpade. Följande exempel rapporterar den medurs vinkel från den positiva horisontella axeln i bildkoordinater:

```python
import math
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    connector = slide.shapes.add_connector(slides.ShapeType.STRAIGHT_CONNECTOR1, 100, 100, 200, 100)

    flip_h = connector.frame.flip_h == slides.NullableBool.TRUE
    flip_v = connector.frame.flip_v == slides.NullableBool.TRUE
    delta_x = connector.width * (-1 if flip_h else 1)
    delta_y = connector.height * (-1 if flip_v else 1)
    angle = math.atan2(delta_y, delta_x) * 180.0 / math.pi

    if angle < 0:
        angle += 360

    print(f"Connector direction: {angle:.2f} degrees")
```

## **FAQ**

**Hur kan jag avgöra om en konnektor kan fästas på en form?**

Kontrollera formens [connection_site_count](https://reference.aspose.com/slides/sv/python-net/aspose.slides/igeometryshape/connection_site_count/). Ett positivt antal betyder att formen exponerar anslutningsställen. Validera det valda platsindexet innan du tilldelar det till någon av konnektorns ändar.

**Kan jag identifiera en konnektorrejustering via dess kollektionsindex?**

Ett index är meningsfullt endast för en känd konnektorpreset och kollektionslayout. Kontrollera [IAdjustValue.type](https://reference.aspose.com/slides/sv/python-net/aspose.slides/iadjustvalue/type/) innan du ändrar ett värde, och använd [IAdjustValue.name](https://reference.aspose.com/slides/sv/python-net/aspose.slides/iadjustvalue/name/) som ytterligare information när samma semantiska typ förekommer mer än en gång.

**Vad händer när en ansluten form tas bort?**

Den motsvarande konnektoränden blir fristående. Konnektorn kvarstår på bilden och kan tas bort, placeras som en fri linje eller fästas till en annan form.

**Bevaras konnektorbindingar när en bild kopieras?**

Bindningar bevaras i allmänhet när de anslutna formerna kopieras med bilden. Om en konnektor kopieras utan någon av sina målformer måste den påverkade änden fästas igen.