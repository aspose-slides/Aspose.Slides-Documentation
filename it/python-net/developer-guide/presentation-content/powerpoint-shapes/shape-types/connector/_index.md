---
title: Gestire i connettori nelle presentazioni con Python
linktitle: Connettore
type: docs
weight: 10
url: /it/python-net/connector/
keywords:
- connettore
- tipo di connettore
- punto del connettore
- linea del connettore
- angolo del connettore
- punto di connessione
- punto di regolazione
- collegare forme
- PowerPoint
- presentazione
- Python
- Aspose.Slides
description: "Scopri come aggiungere, agganciare, ricalcolare, regolare e ispezionare i connettori rettilinei, piegati e curvi di PowerPoint con Aspose.Slides per Python tramite .NET."
---
## **Panoramica**

Un connettore è una linea che può rimanere collegata a due forme quando una delle due forme si sposta. Le sue estremità si agganciano a punti di connessione, rappresentati da punti verdi in PowerPoint. Alcuni connettori piegati e curvi espongono anche punti di regolazione, rappresentati da punti arancioni, che controllano la posizione dei singoli segmenti del connettore.

Aspose.Slides rappresenta i connettori tramite l'interfaccia [IConnector](https://reference.aspose.com/slides/it/python-net/aspose.slides/iconnector/). È possibile crearli, agganciare le loro estremità alle forme, scegliere i punti di connessione, ricalcolare il percorso e modificare la geometria dei connettori che hanno punti di regolazione.

## **Tipi di connettore**

L'enumerazione [ShapeType](https://reference.aspose.com/slides/it/python-net/aspose.slides/shapetype/) include preset di connettori rettilinei, piegati e curvi. La tabella seguente mostra le geometrie di connettore disponibili e il numero di punti di regolazione definiti da ciascun preset.

| Connettore | Immagine | Numero di punti di regolazione |
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

Il numero e il significato dei punti di regolazione fanno parte del preset di connettore selezionato. Non dare per scontato che due tipi di connettore diversi espongano la stessa disposizione della collezione.

## **Collega due forme**

Usa [IShapeCollection.add_connector](https://reference.aspose.com/slides/it/python-net/aspose.slides/ishapecollection/add_connector/) per aggiungere un connettore e imposta le sue proprietà [start_shape_connected_to](https://reference.aspose.com/slides/it/python-net/aspose.slides/iconnector/start_shape_connected_to/) e [end_shape_connected_to](https://reference.aspose.com/slides/it/python-net/aspose.slides/iconnector/end_shape_connected_to/). Dopo che entrambe le estremità sono state agganciate, [IConnector.reroute](https://reference.aspose.com/slides/it/python-net/aspose.slides/iconnector/reroute/) seleziona un percorso più breve tra le forme.

L'esempio seguente collega un'ellisse e un rettangolo con un connettore piegato:

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

{{% alert color="warning" title="Avviso" %}}

Chiamare `reroute` può modificare i valori di [start_shape_connection_site_index](https://reference.aspose.com/slides/it/python-net/aspose.slides/iconnector/start_shape_connection_site_index/) e [end_shape_connection_site_index](https://reference.aspose.com/slides/it/python-net/aspose.slides/iconnector/end_shape_connection_site_index/). Assegna punti di connessione specifici dopo la ricalcolazione se tali punti devono rimanere fissi.

{{% /alert %}}

## **Scegli un punto di connessione**

Ogni forma collegabile restituisce il numero di punti tramite [connection_site_count](https://reference.aspose.com/slides/it/python-net/aspose.slides/igeometryshape/connection_site_count/). Convalida un indice di punto zero‑based preferito prima di assegnarlo a un'estremità del connettore; il conteggio varia a seconda della geometria della forma.

Questo esempio aggancia il connettore a un punto particolare sull'ellisse quando tale punto esiste:

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

## **Regola un punto del connettore**

I connettori con punti di regolazione li espongono tramite [IGeometryShape.adjustments](https://reference.aspose.com/slides/it/python-net/aspose.slides/igeometryshape/adjustments/). Esamina ogni [IAdjustValue](https://reference.aspose.com/slides/it/python-net/aspose.slides/iadjustvalue/) e verifica il suo [type](https://reference.aspose.com/slides/it/python-net/aspose.slides/iadjustvalue/type/) prima di modificare il suo [raw_value](https://reference.aspose.com/slides/it/python-net/aspose.slides/iadjustvalue/raw_value/). Per la manipolazione generale delle forme, vedi [Manipolazione delle forme](/slides/it/python-net/shape-manipulations/).

Il numero, l'ordine, il significato e l'intervallo di valori validi delle regolazioni dipendono dal preset del connettore. La proprietà `type` è di sola lettura, mentre il valore di regolazione è scrivibile. La proprietà di sola lettura [name](https://reference.aspose.com/slides/it/python-net/aspose.slides/iadjustvalue/name/) fornisce un'identificazione aggiuntiva quando un connettore contiene più di una regolazione dello stesso tipo semantico.

### **Percorri intorno a un ostacolo**

Nel layout seguente, un connettore `ShapeType.BENT_CONNECTOR5` tra due forme passa attraverso una terza forma:

![connector-obstruction](connector-obstruction.png)

Questo codice crea il connettore ostruito:

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

Spostare la piega verticale cambia il percorso in modo che il connettore aggiri l'ostacolo:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

Invece di presumere che l'indice di collezione `1` rappresenti sempre la piega verticale, questo esempio cerca `ShapeAdjustmentType.CONNECTOR_BEND_POSITION_Y` e lo modifica solo quando è presente il tipo semantico previsto:

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

Un `ShapeType.BENT_CONNECTOR5` ha due regolazioni `ShapeAdjustmentType.CONNECTOR_BEND_POSITION_X` e una regolazione `ShapeAdjustmentType.CONNECTOR_BEND_POSITION_Y`. Se il tipo di cui hai bisogno compare più volte, esamina `name` e la geometria nota di quel preset prima di sceglierne uno. Se una regolazione restituisce [ShapeAdjustmentType.CUSTOM](https://reference.aspose.com/slides/it/python-net/aspose.slides/shapeadjustmenttype/), considera che il suo significato e l'intervallo sono specifici del preset e non modificarlo finché il contratto non è noto.

## **Collega i valori di regolazione alla geometria del connettore**

Per i connettori piegati, i valori di regolazione possono essere usati per stimare le posizioni dei singoli segmenti. Questi calcoli sono specifici al preset del connettore:

- `ShapeType.BENT_CONNECTOR4` normalmente espone una regolazione `ShapeAdjustmentType.CONNECTOR_BEND_POSITION_X` e una `ShapeAdjustmentType.CONNECTOR_BEND_POSITION_Y`.
- Per queste posizioni di piega, `raw_value / 100000` produce la frazione della larghezza o altezza del frame del connettore usata negli esempi seguenti.
- Un frame del connettore può essere ruotato o capovolto, quindi le coordinate del frame devono essere trasformate prima di confrontarle con le coordinate della diapositiva.

Gli esempi seguenti usano `type` per identificare prima le regolazioni. Non trattano gli indici di collezione come identificatori portabili.

### **Connettore non ruotato**

Il layout iniziale contiene due forme di testo collegate da un `ShapeType.BENT_CONNECTOR4`:

![connector-shape-complex](connector-shape-complex.png)

Questo esempio esamina il connettore e ottiene le sue regolazioni di piega orizzontale e verticale:

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

Per modificare entrambe le pieghe, individua ogni tipo previsto e modifica i valori solo dopo aver trovato entrambi:

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

Il risultato è un connettore i cui segmenti orizzontali e verticali si sono spostati:

![connector-adjusted-1](connector-adjusted-1.png)

Una volta noti i tipi semantici, i loro valori possono essere convertiti in coordinate del frame del connettore. Questo esempio disegna un rettangolo sottile sopra il segmento verticale controllato dalle due regolazioni di piega:

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

La forma guida indica il segmento calcolato:

![connector-adjusted-2](connector-adjusted-2.png)

### **Connettore ruotato o capovolto**

Quando la stessa geometria di connettore è orientata verticalmente, i valori di [frame](https://reference.aspose.com/slides/it/python-net/aspose.slides/iconnector/frame/), [flip_h](https://reference.aspose.com/slides/it/python-net/aspose.slides/ishapeframe/flip_h/) e [flip_v](https://reference.aspose.com/slides/it/python-net/aspose.slides/ishapeframe/flip_v/) influenzano la conversione dalle coordinate del frame del connettore a quelle della diapositiva.

Questo esempio crea e regola il connettore orientato verticalmente:

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

Il connettore regolato appare verticalmente tra le forme:

![connector-adjusted-3](connector-adjusted-3.png)

Per un angolo di rotazione arbitrario `alpha`, ruota un punto del frame del connettore `(x, y)` attorno al centro del frame `(x0, y0)`:

`X = (x - x0) * cos(alpha) - (y - y0) * sin(alpha) + x0`

`Y = (x - x0) * sin(alpha) + (y - y0) * cos(alpha) + y0`

Il codice seguente gestisce l'orientamento a 90 gradi usato in questo esempio e disegna una guida rossa sopra il segmento corrispondente del connettore:

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

La guida rossa indica il segmento calcolato dopo la trasformazione delle coordinate:

![connector-adjusted-4](connector-adjusted-4.png)

Queste formule descrivono i preset usati negli esempi, non un modello universale di connettore. Convalida i tipi di regolazione, l'orientamento del frame e gli intervalli di valori prima di applicare lo stesso calcolo a un preset diverso.

## **Trova l'angolo di direzione del connettore**

La direzione di un connettore rettilineo può essere calcolata dalla sua larghezza e altezza, con i ribaltamenti orizzontali e verticali applicati. L'esempio seguente restituisce l'angolo in senso orario rispetto all'asse orizzontale positivo nelle coordinate della diapositiva:

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

**Come posso capire se un connettore può essere agganciato a una forma?**

Controlla il valore di [connection_site_count](https://reference.aspose.com/slides/it/python-net/aspose.slides/igeometryshape/connection_site_count/) della forma. Un valore positivo indica che la forma espone punti di connessione. Convalida l'indice del punto selezionato prima di assegnarlo a una delle estremità del connettore.

**Posso identificare una regolazione del connettore tramite il suo indice di collezione?**

Un indice è significativo solo per un preset di connettore conosciuto e per la disposizione della collezione. Verifica [IAdjustValue.type](https://reference.aspose.com/slides/it/python-net/aspose.slides/iadjustvalue/type/) prima di modificare un valore e usa [IAdjustValue.name](https://reference.aspose.com/slides/it/python-net/aspose.slides/iadjustvalue/name/) come informazione aggiuntiva quando lo stesso tipo semantico compare più volte.

**Cosa succede quando una forma collegata viene eliminata?**

L'estremità corrispondente del connettore si stacca. Il connettore rimane sulla diapositiva e può essere eliminato, posizionato come linea libera o agganciato a un'altra forma.

**I collegamenti del connettore vengono conservati quando una diapositiva viene copiata?**

I collegamenti sono generalmente conservati quando le forme collegate sono copiate insieme alla diapositiva. Se un connettore viene copiato senza una delle sue forme target, l'estremità interessata deve essere riagganciata.