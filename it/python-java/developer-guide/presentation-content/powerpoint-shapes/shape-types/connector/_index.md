---
title: Gestire i connettori nelle presentazioni in Python tramite Java
linktitle: Connettore
type: docs
weight: 10
url: /it/python-java/connector/
keywords:
- connettore
- tipo di connettore
- punto del connettore
- linea del connettore
- angolo del connettore
- sito di connessione
- punto di regolazione
- collegare forme
- PowerPoint
- presentazione
- Python
- Aspose.Slides
description: "Scopri come aggiungere, collegare, ricalcolare, regolare e ispezionare i connettori PowerPoint lineari, piegati e curvi con Aspose.Slides per Python tramite Java."
---
## **Panoramica**

Un connettore è una linea che può rimanere collegata a due forme quando una delle due forme si sposta. Le sue estremità si collegano a siti di connessione, rappresentati da punti verdi in PowerPoint. Alcuni connettori piegati e curvi espongono anche punti di regolazione, rappresentati da punti arancioni, che controllano la posizione dei singoli segmenti del connettore.

Aspose.Slides rappresenta i connettori tramite la classe [Connector](https://reference.aspose.com/slides/it/python-java/aspose.slides/connector/). Puoi crearli, collegare le loro estremità alle forme, scegliere i siti di connessione, ricalcolarli e modificare la geometria dei connettori che hanno punti di regolazione.

## **Tipi di connettore**

La classe [ShapeType](https://reference.aspose.com/slides/it/python-java/aspose.slides/shapetype/) include preset di connettori lineari, piegati e curvi. La tabella seguente mostra le geometrie di connettore disponibili e il numero di punti di regolazione definiti per ciascun preset.

| Connettore | Immagine | Numero di punti di regolazione |
|---|---|---|
| [ShapeType.Line](https://reference.aspose.com/slides/it/python-java/aspose.slides/shapetype/#Line) | ![shapetype-lineconnector](shapetype-lineconnector.png) | 0 |
| [ShapeType.StraightConnector1](https://reference.aspose.com/slides/it/python-java/aspose.slides/shapetype/#StraightConnector1) | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0 |
| [ShapeType.BentConnector2](https://reference.aspose.com/slides/it/python-java/aspose.slides/shapetype/#BentConnector2) | ![shapetype-bent-connector2](shapetype-bent-connector2.png) | 0 |
| [ShapeType.BentConnector3](https://reference.aspose.com/slides/it/python-java/aspose.slides/shapetype/#BentConnector3) | ![shapetype-bentconnector3](shapetype-bentconnector3.png) | 1 |
| [ShapeType.BentConnector4](https://reference.aspose.com/slides/it/python-java/aspose.slides/shapetype/#BentConnector4) | ![shapetype-bentconnector4](shapetype-bentconnector4.png) | 2 |
| [ShapeType.BentConnector5](https://reference.aspose.com/slides/it/python-java/aspose.slides/shapetype/#BentConnector5) | ![shapetype-bentconnector5](shapetype-bentconnector5.png) | 3 |
| [ShapeType.CurvedConnector2](https://reference.aspose.com/slides/it/python-java/aspose.slides/shapetype/#CurvedConnector2) | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0 |
| [ShapeType.CurvedConnector3](https://reference.aspose.com/slides/it/python-java/aspose.slides/shapetype/#CurvedConnector3) | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1 |
| [ShapeType.CurvedConnector4](https://reference.aspose.com/slides/it/python-java/aspose.slides/shapetype/#CurvedConnector4) | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2 |
| [ShapeType.CurvedConnector5](https://reference.aspose.com/slides/it/python-java/aspose.slides/shapetype/#CurvedConnector5) | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3 |

Il numero e il significato dei punti di regolazione fanno parte del preset di connettore selezionato. Non presumere che due tipi di connettore diversi espongano la stessa disposizione della collezione.

## **Collega due forme**

Usa [ShapeCollection.addConnector](https://reference.aspose.com/slides/it/python-java/aspose.slides/shapecollection/#addConnector) per aggiungere un connettore e usa [Connector.setStartShapeConnectedTo](https://reference.aspose.com/slides/it/python-java/aspose.slides/connector/#setStartShapeConnectedTo) e [Connector.setEndShapeConnectedTo](https://reference.aspose.com/slides/it/python-java/aspose.slides/connector/#setEndShapeConnectedTo) per collegare le sue estremità. Dopo che entrambe le estremità sono collegate, [Connector.reroute](https://reference.aspose.com/slides/it/python-java/aspose.slides/connector/#reroute) seleziona un percorso breve tra le forme.

L'esempio seguente collega un'ellisse e un rettangolo con un connettore piegato:

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
Chiamare [reroute](https://reference.aspose.com/slides/it/python-java/aspose.slides/connector/#reroute) può modificare i valori di [setStartShapeConnectionSiteIndex](https://reference.aspose.com/slides/it/python-java/aspose.slides/connector/#setStartShapeConnectionSiteIndex) e [setEndShapeConnectionSiteIndex](https://reference.aspose.com/slides/it/python-java/aspose.slides/connector/#setEndShapeConnectionSiteIndex). Assegna siti di connessione specifici dopo il ricalcolo se quei siti devono rimanere fissi.
{{% /alert %}}

## **Scegli un sito di connessione**

Ogni forma collegabile restituisce il numero di siti tramite [Shape.getConnectionSiteCount](https://reference.aspose.com/slides/it/python-java/aspose.slides/shape/#getConnectionSiteCount). Convalida un indice di sito zero‑based preferito prima di assegnarlo a un'estremità del connettore; il conteggio dei siti varia in base alla geometria della forma.

Questo esempio collega il connettore a un sito particolare sull'ellisse quando tale sito esiste:

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

## **Regola un punto del connettore**

I connettori con punti di regolazione li espongono tramite [GeometryShape.getAdjustments](https://reference.aspose.com/slides/it/python-java/aspose.slides/geometryshape/#getAdjustments). Esamina ogni [AdjustValue](https://reference.aspose.com/slides/it/python-java/aspose.slides/adjustvalue/) e controlla il suo valore [getType](https://reference.aspose.com/slides/it/python-java/aspose.slides/adjustvalue/#getType) prima di modificarlo con [setRawValue](https://reference.aspose.com/slides/it/python-java/aspose.slides/adjustvalue/#setRawValue). Le regole generali per identificare le regolazioni di forma preset sono descritte in [Shape Manipulation](/slides/it/python-java/shape-manipulations/).

Il numero, l'ordine, il significato e l'intervallo di valori validi delle regolazioni dipendono dal preset del connettore. Il tipo di regolazione è di sola lettura, mentre il valore è scrivibile. Il metodo di sola lettura [getName](https://reference.aspose.com/slides/it/python-java/aspose.slides/adjustvalue/#getName) fornisce un'identificazione aggiuntiva quando un connettore contiene più di una regolazione dello stesso tipo semantico.

### **Percorri intorno a un ostacolo**

Nel layout seguente, un connettore [BentConnector5](https://reference.aspose.com/slides/it/python-java/aspose.slides/shapetype/#BentConnector5) tra due forme attraversa una terza forma:

![connector-obstruction](connector-obstruction.png)

Questo codice crea il connettore ostruito:

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

Spostare la piega verticale modifica il percorso in modo che il connettore aggiri l'ostacolo:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

Invece di presumere che l'indice della collezione `1` rappresenti sempre la piega verticale, questo esempio cerca [ConnectorBendPositionY](https://reference.aspose.com/slides/it/python-java/aspose.slides/shapeadjustmenttype/#ConnectorBendPositionY) e lo modifica solo quando è presente il tipo semantico atteso:

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

Un [BentConnector5](https://reference.aspose.com/slides/it/python-java/aspose.slides/shapetype/#BentConnector5) ha due regolazioni [ConnectorBendPositionX](https://reference.aspose.com/slides/it/python-java/aspose.slides/shapeadjustmenttype/#ConnectorBendPositionX) e una [ConnectorBendPositionY](https://reference.aspose.com/slides/it/python-java/aspose.slides/shapeadjustmenttype/#ConnectorBendPositionY). Se il tipo necessario si presenta più volte, ispeziona [getName](https://reference.aspose.com/slides/it/python-java/aspose.slides/adjustvalue/#getName) e la geometria nota di quel preset prima di sceglierne uno. Se una regolazione restituisce [ShapeAdjustmentType.Custom](https://reference.aspose.com/slides/it/python-java/aspose.slides/shapeadjustmenttype/#Custom), considera il suo significato e intervallo come specifici del preset e non modificarla finché tale contratto non è noto.

## **Collega i valori di regolazione alla geometria del connettore**

Per i connettori piegati, i valori di regolazione possono essere usati per stimare le posizioni dei segmenti individuali. Questi calcoli sono specifici del preset del connettore:

- [BentConnector4](https://reference.aspose.com/slides/it/python-java/aspose.slides/shapetype/#BentConnector4) normalmente espone una regolazione [ConnectorBendPositionX](https://reference.aspose.com/slides/it/python-java/aspose.slides/shapeadjustmenttype/#ConnectorBendPositionX) e una [ConnectorBendPositionY](https://reference.aspose.com/slides/it/python-java/aspose.slides/shapeadjustmenttype/#ConnectorBendPositionY).
- Per queste posizioni di piega, dividere il valore restituito da [getRawValue](https://reference.aspose.com/slides/it/python-java/aspose.slides/adjustvalue/#getRawValue) per `100000.0` produce la frazione della larghezza o altezza del frame del connettore usata negli esempi seguenti.
- Un frame di connettore può essere ruotato o capovolto, quindi le coordinate del frame devono essere trasformate prima di confrontarle con le coordinate della diapositiva.

Gli esempi seguenti usano [getType](https://reference.aspose.com/slides/it/python-java/aspose.slides/adjustvalue/#getType) per identificare prima le regolazioni. Non trattano gli indici della collezione come identificatori portabili.

### **Connettore non ruotato**

Il layout iniziale contiene due forme di testo collegate da un [BentConnector4](https://reference.aspose.com/slides/it/python-java/aspose.slides/shapetype/#BentConnector4):

![connector-shape-complex](connector-shape-complex.png)

Questo esempio ispeziona il connettore e ottiene le sue regolazioni di piega orizzontale e verticale:

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

Per cambiare entrambe le pieghe, individua ciascun tipo previsto e modifica i valori solo dopo aver trovato entrambi:

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

Il risultato è un connettore i cui segmenti orizzontali e verticali sono stati spostati:

![connector-adjusted-1](connector-adjusted-1.png)

Una volta noti i tipi semantici, è possibile convertire i loro valori in coordinate del frame del connettore. Questo esempio disegna un rettangolo sottile sul segmento verticale controllato dalle due regolazioni di piega:

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

La forma guida segna il segmento calcolato:

![connector-adjusted-2](connector-adjusted-2.png)

### **Connettore ruotato o capovolto**

Quando la stessa geometria del connettore è orientata verticalmente, i valori di [Shape.getFrame](https://reference.aspose.com/slides/it/python-java/aspose.slides/shape/#getFrame), [ShapeFrame.getFlipH](https://reference.aspose.com/slides/it/python-java/aspose.slides/shapeframe/#getFlipH) e [ShapeFrame.getFlipV](https://reference.aspose.com/slides/it/python-java/aspose.slides/shapeframe/#getFlipV) influiscono sulla conversione da coordinate del frame del connettore a coordinate della diapositiva.

Questo esempio crea e regola il connettore orientato verticalmente:

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

Il connettore regolato appare verticalmente tra le forme:

![connector-adjusted-3](connector-adjusted-3.png)

Per un angolo di rotazione arbitrario `alpha`, ruota un punto del frame del connettore `(x, y)` attorno al centro del frame `(x0, y0)`:

`X = (x - x0) * cos(alpha) - (y - y0) * sin(alpha) + x0`

`Y = (x - x0) * sin(alpha) + (y - y0) * cos(alpha) + y0`

Il codice seguente gestisce l'orientamento a 90 gradi usato in questo esempio e disegna una guida rossa sul segmento corrispondente del connettore:

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

La guida rossa segna il segmento calcolato dopo la trasformazione delle coordinate:

![connector-adjusted-4](connector-adjusted-4.png)

Queste formule descrivono i preset usati negli esempi, non un modello universale di connettore. Convalida i tipi di regolazione, l'orientamento del frame e gli intervalli di valore prima di applicare lo stesso calcolo a un preset diverso.

## **Trova l'angolo di direzione di un connettore**

La direzione di un connettore lineare può essere calcolata dalla sua larghezza e altezza, con le inversioni orizzontali e verticali applicate. L'esempio seguente restituisce l'angolo in senso orario rispetto all'asse orizzontale positivo nelle coordinate della diapositiva:

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

**Come posso capire se un connettore può collegarsi a una forma?**

Controlla il valore di [getConnectionSiteCount](https://reference.aspose.com/slides/it/python-java/aspose.slides/shape/#getConnectionSiteCount) della forma. Un conteggio positivo indica che la forma espone siti di connessione. Convalida l'indice del sito selezionato prima di assegnarlo a una delle estremità del connettore.

**Posso identificare una regolazione del connettore tramite il suo indice nella collezione?**

Un indice è significativo solo per un preset di connettore e una disposizione della collezione conosciuti. Controlla [AdjustValue.getType](https://reference.aspose.com/slides/it/python-java/aspose.slides/adjustvalue/#getType) prima di modificare un valore e usa [AdjustValue.getName](https://reference.aspose.com/slides/it/python-java/aspose.slides/adjustvalue/#getName) come informazione aggiuntiva quando lo stesso tipo semantico compare più volte.

** Cosa succede quando una forma collegata viene eliminata?**

L'estremità corrispondente del connettore viene scollegata. Il connettore rimane nella diapositiva e può essere eliminato, posizionato come linea libera o collegato a un'altra forma.

**I collegamenti dei connettori vengono preservati quando una diapositiva viene copiata?**

In genere i collegamenti sono preservati quando le forme collegate vengono copiate con la diapositiva. Se un connettore viene copiato senza una delle forme target, l'estremità interessata deve essere nuovamente collegata.