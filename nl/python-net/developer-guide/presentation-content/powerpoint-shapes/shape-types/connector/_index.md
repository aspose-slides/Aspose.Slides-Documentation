---
title: Beheer connectors in presentaties met Python
linktitle: Connector
type: docs
weight: 10
url: /nl/python-net/connector/
keywords:
- connector
- connector type
- connectorpunt
- connectorlijn
- connectorhoek
- verbindingpunt
- aanpassingspunt
- vormen verbinden
- PowerPoint
- presentatie
- Python
- Aspose.Slides
description: "Leer hoe u rechte, gebogen en kromme PowerPoint-connectors kunt toevoegen, koppelen, opnieuw routeren, aanpassen en inspecteren met Aspose.Slides voor Python via .NET."
---
## **Overzicht**

Een connector is een lijn die aan twee vormen gekoppeld kan blijven wanneer een van de vormen wordt verplaatst. De uiteinden worden gekoppeld aan verbindingspunten, weergegeven door groene stippen in PowerPoint. Sommige gebogen en kromme connectors tonen ook aanpassingspunten, weergegeven door oranje stippen, die de positie van individuele connectorsegmenten regelen.

Aspose.Slides vertegenwoordigt connectors via de [IConnector](https://reference.aspose.com/slides/nl/python-net/aspose.slides/iconnector/) interface. Je kunt ze maken, de uiteinden aan vormen koppelen, verbindingspunten kiezen, ze opnieuw routeren en de geometrie van connectors met aanpassingspunten aanpassen.

## **Connector‑typen**

De [ShapeType](https://reference.aspose.com/slides/nl/python-net/aspose.slides/shapetype/) enumeratie bevat rechte, gebogen en kromme connector‑presets. De onderstaande tabel toont de beschikbare connector‑geometrieën en het aantal aanpassingspunten dat door elk preset wordt gedefinieerd.

| Connector | Afbeelding | Aantal aanpassingspunten |
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

Het aantal en de betekenis van aanpassingspunten maken deel uit van het geselecteerde connector‑preset. Ga er niet van uit dat twee verschillende connector‑typen dezelfde collectie‑lay‑out tonen.

## **Verbind twee vormen**

Gebruik [IShapeCollection.add_connector](https://reference.aspose.com/slides/nl/python-net/aspose.slides/ishapecollection/add_connector/) om een connector toe te voegen, en wijs de eigenschappen [start_shape_connected_to](https://reference.aspose.com/slides/nl/python-net/aspose.slides/iconnector/start_shape_connected_to/) en [end_shape_connected_to](https://reference.aspose.com/slides/nl/python-net/aspose.slides/iconnector/end_shape_connected_to/) toe. Nadat beide uiteinden zijn gekoppeld, kiest [IConnector.reroute](https://reference.aspose.com/slides/nl/python-net/aspose.slides/iconnector/reroute/) een korte route tussen de vormen.

Het volgende voorbeeld verbindt een ellips en een rechthoek met een gebogen connector:

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

{{% alert color="warning" title="Waarschuwing" %}}
Het aanroepen van `reroute` kan de waarden van [start_shape_connection_site_index](https://reference.aspose.com/slides/nl/python-net/aspose.slides/iconnector/start_shape_connection_site_index/) en [end_shape_connection_site_index](https://reference.aspose.com/slides/nl/python-net/aspose.slides/iconnector/end_shape_connection_site_index/) wijzigen. Wijs specifieke verbindingspunten toe na het opnieuw routeren als die punten vast moeten blijven staan.
{{% /alert %}}

## **Kies een verbindingspunt**

Elke verbindbare vorm rapporteert zijn aantal punten via [connection_site_count](https://reference.aspose.com/slides/nl/python-net/aspose.slides/igeometryshape/connection_site_count/). Valideer een voorkeurs‑index (nulgebaseerd) voordat je deze toewijst aan een connector‑uiteinde; het aantal punten varieert per vormgeometrie.

Dit voorbeeld koppelt de connector aan een specifiek punt op de ellips wanneer dat punt bestaat:

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

## **Pas een connectorpunt aan**

Connectors met aanpassingspunten maken ze toegankelijk via [IGeometryShape.adjustments](https://reference.aspose.com/slides/nl/python-net/aspose.slides/igeometryshape/adjustments/). Inspecteer elke [IAdjustValue](https://reference.aspose.com/slides/nl/python-net/aspose.slides/iadjustvalue/) en controleer zijn [type](https://reference.aspose.com/slides/nl/python-net/aspose.slides/iadjustvalue/type/) voordat je de [raw_value](https://reference.aspose.com/slides/nl/python-net/aspose.slides/iadjustvalue/raw_value/) wijzigt. Voor algemene vormmanipulatie, zie [Shape Manipulation](/slides/nl/python-net/shape-manipulations/).

Het aantal, de volgorde, de betekenis en het geldige bereik van connector‑aanpassingen hangen af van het connector‑preset. De eigenschap `type` is alleen‑lezen, terwijl de aanpassingswaarde beschrijfbaar is. De alleen‑lees [name](https://reference.aspose.com/slides/nl/python-net/aspose.slides/iadjustvalue/name/) eigenschap biedt extra identificatie wanneer een connector meer dan één aanpassing van hetzelfde semantische type bevat.

### **Omzeil een obstakel**

In de volgende opzet gaat een `ShapeType.BENT_CONNECTOR5` connector tussen twee vormen door een derde vorm:

![connector-obstruction](connector-obstruction.png)

Deze code maakt de geblokkeerde connector:

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

Het verplaatsen van de verticale bocht wijzigt de route zodat de connector het obstakel omzeilt:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

In plaats van ervan uit te gaan dat collectie‑index `1` altijd de verticale bocht vertegenwoordigt, zoekt dit voorbeeld naar `ShapeAdjustmentType.CONNECTOR_BEND_POSITION_Y` en wijzigt het alleen wanneer het verwachte semantische type aanwezig is:

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

Een `ShapeType.BENT_CONNECTOR5` heeft twee `ShapeAdjustmentType.CONNECTOR_BEND_POSITION_X`‑aanpassingen en één `ShapeAdjustmentType.CONNECTOR_BEND_POSITION_Y`‑aanpassing. Als het type dat je nodig hebt meer dan eens voorkomt, inspecteer dan `name` en de bekende geometrie van dat preset voordat je er één selecteert. Als een aanpassing [ShapeAdjustmentType.CUSTOM](https://reference.aspose.com/slides/nl/python-net/aspose.slides/shapeadjustmenttype/) rapporteert, behandel de betekenis en het bereik als preset‑specifiek en wijzig het niet totdat die contractueel is vastgesteld.

## **Relateer aanpassingswaarden aan connector‑geometrie**

Voor gebogen connectors kunnen aanpassingswaarden worden gebruikt om de posities van individuele segmenten in te schatten. Deze berekeningen zijn specifiek voor het connector‑preset:

- `ShapeType.BENT_CONNECTOR4` toont normaal één `ShapeAdjustmentType.CONNECTOR_BEND_POSITION_X` en één `ShapeAdjustmentType.CONNECTOR_BEND_POSITION_Y` aanpassing.
- Voor deze bochtposities levert `raw_value / 100000` de fractie van de connector‑frame breedte of hoogte op die in de onderstaande voorbeelden wordt gebruikt.
- Een connector‑frame kan gedraaid of gespiegeld worden, zodat frame‑coördinaten moeten worden getransformeerd voordat ze vergeleken worden met slide‑coördinaten.

De volgende voorbeelden gebruiken eerst `type` om de aanpassingen te identificeren. Ze behandelen collectie‑indexen niet als draagbare identifiers.

### **Niet‑gedraaid connector**

De beginsituatie bevat twee tekstvormen die verbonden zijn door een `ShapeType.BENT_CONNECTOR4`:

![connector-shape-complex](connector-shape-complex.png)

Dit voorbeeld inspecteert de connector en haalt de horizontale en verticale bocht‑aanpassingen op:

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

Om beide bochten te wijzigen, zoek je elk verwacht type en wijzig je de waarden pas nadat beide gevonden zijn:

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

Het resultaat is een connector waarvan de horizontale en verticale segmenten zijn verplaatst:

![connector-adjusted-1](connector-adjusted-1.png)

Zodra de semantische types bekend zijn, kunnen hun waarden omgezet worden naar connector‑frame coördinaten. Dit voorbeeld tekent een dunne rechthoek over het verticale segment dat wordt bestuurd door de twee bocht‑aanpassingen:

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

De hulpflichaam markeert het berekende segment:

![connector-adjusted-2](connector-adjusted-2.png)

### **Gedraaid of gespiegeld connector**

Wanneer dezelfde connector‑geometrie verticaal georiënteerd is, beïnvloeden de waarden van [frame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/iconnector/frame/), [flip_h](https://reference.aspose.com/slides/nl/python-net/aspose.slides/ishapeframe/flip_h/) en [flip_v](https://reference.aspose.com/slides/nl/python-net/aspose.slides/ishapeframe/flip_v/) de conversie van connector‑frame coördinaten naar slide‑coördinaten.

Dit voorbeeld maakt en past de verticaal georiënteerde connector aan:

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

De aangepaste connector verschijnt verticaal tussen de vormen:

![connector-adjusted-3](connector-adjusted-3.png)

Voor een willekeurige rotatiehoek `alpha` rotatie je een connector‑frame punt `(x, y)` rond het frame‑centrum `(x0, y0)`:

`X = (x - x0) * cos(alpha) - (y - y0) * sin(alpha) + x0`

`Y = (x - x0) * sin(alpha) + (y - y0) * cos(alpha) + y0`

De volgende code behandelt de 90‑graden oriëntatie die in dit voorbeeld wordt gebruikt en tekent een rode gids over het overeenkomstige connector‑segment:

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

De rode gids markeert het berekende segment na de coördinatentransformatie:

![connector-adjusted-4](connector-adjusted-4.png)

Deze formules beschrijven de presets die in de voorbeelden worden gebruikt, niet een universeel connector‑model. Valideer de aanpassingstypen, frame‑oriëntatie en waardebereiken voordat je dezelfde berekening toepast op een ander preset.

## **Bepaal de richtingshoek van een connector**

De richting van een rechte connector kan worden berekend uit zijn breedte en hoogte, met horizontale en verticale spiegels toegepast. Het volgende voorbeeld geeft de klokwijzerige hoek ten opzichte van de positieve horizontale as in slide‑coördinaten weer:

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

**Hoe kan ik zien of een connector aan een vorm kan worden gekoppeld?**  
Controleer de [connection_site_count](https://reference.aspose.com/slides/nl/python-net/aspose.slides/igeometryshape/connection_site_count/) van de vorm. Een positieve telling betekent dat de vorm verbindingspunten exposeert. Valideer de gekozen punt‑index vóór toewijzing aan een connector‑uiteinde.

**Kan ik een connector‑aanpassing identificeren via zijn collectie‑index?**  
Een index is alleen betekenisvol voor een bekend connector‑preset en collectie‑lay‑out. Controleer [IAdjustValue.type](https://reference.aspose.com/slides/nl/python-net/aspose.slides/iadjustvalue/type/) vóór het wijzigen van een waarde, en gebruik [IAdjustValue.name](https://reference.aspose.com/slides/nl/python-net/aspose.slides/iadjustvalue/name/) als extra informatie wanneer hetzelfde semantische type meer dan eens voorkomt.

**Wat gebeurt er wanneer een gekoppelde vorm wordt verwijderd?**  
Het overeenkomstige connector‑uiteinde wordt losgekoppeld. De connector blijft op de slide staan en kan worden verwijderd, als vrije lijn gepositioneerd of aan een andere vorm gekoppeld worden.

**Worden connector‑bindingen behouden wanneer een slide wordt gekopieerd?**  
Bindingen blijven doorgaans behouden wanneer de gekoppelde vormen samen met de slide worden gekopieerd. Als een connector wordt gekopieerd zonder één van zijn doel­vormen, moet het betreffende uiteinde opnieuw worden gekoppeld.