---
title: Personalizza le forme di presentazione in Python
linktitle: Forma personalizzata
type: docs
weight: 20
url: /it/python-net/custom-shape/
keywords:
- forma personalizzata
- aggiungi forma
- crea forma
- modifica forma
- geometria della forma
- percorso geometrico
- punti del percorso
- punti di modifica
- aggiungi punto
- rimuovi punto
- operazione di modifica
- angolo curvo
- PowerPoint
- presentazione
- Python
- Aspose.Slides
description: "Crea e personalizza forme nelle presentazioni PowerPoint con Aspose.Slides per Python tramite .NET: percorsi geometrici, angoli curvi, forme composite."
---
## **Panoramica**

Questo articolo spiega come personalizzare le forme di presentazione in Aspose.Slides modificando la geometria delle forme tramite i punti di modifica e i percorsi geometrici. Mostra come lavorare con [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) per modificare forme esistenti, eseguire operazioni di modifica di base, aggiungere o rimuovere punti e applicare la geometria aggiornata a una forma.

Dimostra inoltre come creare forme personalizzate e composite, costruire forme con angoli curvi, determinare se una geometria di forma è chiusa ed estrarre gli elementi della forma per l'analisi dei contorni.

## **Modifica di una Forma mediante Punti di Modifica**

In PowerPoint, è possibile utilizzare **Edit Points** per modificare un quadrato:

* Spostare un angolo verso l'interno o verso l'esterno.
* Regolare la curvatura in un punto.
* Aggiungere nuovi punti.

La modifica dei punti consente di alterare il contorno di una forma o di utilizzare una forma esistente come base per una nuova.

## **Suggerimenti per la Modifica delle Forme**

![overview_image](custom_shape_0.png)

Quando si modificano le forme di PowerPoint, tenere presenti questi concetti:

* Una forma (o il suo percorso) può essere chiusa o aperta.
* Il percorso di una forma è costituito da punti di ancoraggio collegati da segmenti.
* Un segmento può essere dritto o curvo. I punti di ancoraggio e le maniglie di controllo ne determinano la forma.
* I punti di ancoraggio esistono come punti d'angolo, punti dritti o punti lisci:
  * In un punto d'angolo, i segmenti adiacenti possono incontrarsi formando un angolo.
  * In un punto liscio, le due maniglie di controllo sono allineate e alla stessa distanza dal punto di ancoraggio.
  * In un punto dritto, le due maniglie di controllo sono allineate ma possono avere distanze diverse dal punto di ancoraggio.
* Spostare i punti di ancoraggio o regolare le loro maniglie cambia il contorno della forma.

Per modificare le forme di PowerPoint tramite i punti di modifica, **Aspose.Slides** fornisce la classe [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/).

* Un'istanza di [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) rappresenta il percorso geometrico dell'oggetto [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/).
* Per recuperare il [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) da un'istanza di [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/), è possibile utilizzare il metodo [GeometryShape.get_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/get_geometry_paths/).
* Per impostare il [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) per una forma, è possibile utilizzare questi metodi: [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/) per forme con un unico percorso e [GeometryShape.set_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_paths/) per forme con percorsi multipli.
* Per aggiungere segmenti, è possibile utilizzare i metodi definiti sotto [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/).
* Utilizzando le proprietà [GeometryPath.stroke](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/stroke/) e [GeometryPath.fill_mode](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/fill_mode/), è possibile impostare l'aspetto di un percorso geometrico.
* Utilizzando la proprietà [GeometryPath.path_data](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/path_data/), è possibile recuperare il percorso geometrico di un [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/) come un array di segmenti di percorso.

## **Operazioni di Modifica Semplici**

Utilizzare i seguenti metodi per modificare un percorso geometrico. Le overload che accettano un indice inseriscono un segmento in quella posizione basata su zero nell'array dei segmenti del percorso.

| Operazione | Metodo |
| --- | --- |
| Aggiungere o inserire una linea retta. | [GeometryPath.line_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/line_to/) |
| Aggiungere o inserire una curva Bézier cubica con due punti di controllo e un punto finale. | [GeometryPath.cubic_bezier_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/cubic_bezier_to/) |
| Aggiungere o inserire una curva Bézier quadratica con un punto di controllo e un punto finale. | [GeometryPath.quadratic_bezier_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/quadratic_bezier_to/) |
| Aggiungere un arco ellittico con le dimensioni e gli angoli specificati in gradi. | [GeometryPath.arc_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/arc_to/) |
| Chiudere la figura corrente collegando il suo punto finale al punto iniziale. | [GeometryPath.close_figure](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/close_figure/) |
| Impostare il punto di partenza di una figura. | [GeometryPath.move_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/move_to/) |
| Rimuovere un segmento in una posizione basata su zero. | [GeometryPath.remove_at](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/remove_at/) |

## **Aggiungere Punti Personalizzati a una Forma**

Questo esempio inserisce due punti in una forma rettangolare usando [GeometryPath.line_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/line_to/) e applica il percorso modificato con [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/). Le coordinate sono locali alla forma: entrambi i nuovi punti si trovano al centro, a 100 punti dal lato sinistro e 50 punti dall'alto. Gli indici di segmento 1 e 4 li posizionano rispettivamente sui bordi superiore e inferiore, tirando tali bordi verso l'interno.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 200, 100)

    geometry_path = shape.get_geometry_paths()[0]
    geometry_path.line_to(100, 50, 1)
    geometry_path.line_to(100, 50, 4)

    shape.set_geometry_path(geometry_path)
```

![example1_image](custom_shape_1.png)

## **Rimuovere Punti da una Forma**

Questo esempio modifica il contorno di una forma a cuore rimuovendo il segmento all'indice 2 (basato su zero) con [GeometryPath.remove_at](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/remove_at/). L'applicazione del percorso modificato con [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/) aggiorna il contorno della forma.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.HEART, 100, 100, 300, 300)

    path = shape.get_geometry_paths()[0]
    path.remove_at(2)

    shape.set_geometry_path(path)
```
![example2_image](custom_shape_2.png)

## **Creare una Forma Personalizzata**

Questo esempio costruisce una stella a cinque punte con [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/). Raggi esterni e interni alternati di 100 e 50 punti definiscono le punte e le rientranze; un passo di 72 gradi distribuisce uniformemente le cinque punte. Il percorso è chiuso con [GeometryPath.close_figure](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/close_figure/) e applicato a una forma rettangolare usando [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/), sostituendo il suo contorno.

```python
import aspose.slides as slides
import aspose.pydrawing as draw
import math

points = []

outer_radius = 100
inner_radius = 50
angle_step = 72

for angle in range(-90, 270, angle_step):
    radians = angle * (math.pi / 180)
    x = outer_radius * math.cos(radians)
    y = outer_radius * math.sin(radians)
    points.append(slides.PointF(x + outer_radius, y + outer_radius))

    radians = math.pi * (angle + angle_step / 2) / 180.0
    x = inner_radius * math.cos(radians)
    y = inner_radius * math.sin(radians)
    points.append(slides.PointF(x + outer_radius, y + outer_radius))

star_path = slides.GeometryPath()
star_path.move_to(points[0])

for i in range(1, len(points)):
    star_path.line_to(points[i])

star_path.close_figure()

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, outer_radius * 2, outer_radius * 2)
    shape.set_geometry_path(star_path)
```
![example3_image](custom_shape_3.png)

## **Creare una Forma Personalizzata Composite**

Questo esempio definisce due [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) chiusi per il terzo superiore e inferiore di una forma. L'applicazione di entrambi i percorsi con [GeometryShape.set_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_paths/) crea una singola forma composita con una fessura nel terzo centrale.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 200, 100)

    top_path = slides.GeometryPath()
    top_path.move_to(0, 0)
    top_path.line_to(shape.width, 0)
    top_path.line_to(shape.width, shape.height / 3)
    top_path.line_to(0, shape.height / 3)
    top_path.close_figure()

    bottom_path = slides.GeometryPath()
    bottom_path.move_to(0, shape.height / 3 * 2)
    bottom_path.line_to(shape.width, shape.height / 3 * 2)
    bottom_path.line_to(shape.width, shape.height)
    bottom_path.line_to(0, shape.height)
    bottom_path.close_figure()

    shape.set_geometry_paths([top_path, bottom_path])
```
![example4_image](custom_shape_4.png)

## **Creare una Forma Personalizzata con Angoli Curvi**

Questo esempio combina segmenti dritti con [GeometryPath.arc_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/arc_to/) per creare una forma con angoli curvi verso l'interno. La dimensione di ciascun angolo imposta la larghezza e l'altezza dell'arco in punti, e l'ampiezza di -90 gradi disegna un quarto di ellisse in senso antiorario. Il percorso completato è applicato con [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/), e la presentazione viene salvata in formato PPTX.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

shape_x = 20
shape_y = 20
shape_width = 300
shape_height = 200

left_top_size = 50
right_top_size = 20
right_bottom_size = 40
left_bottom_size = 10

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.CUSTOM, shape_x, shape_y, shape_width, shape_height)

    top_left = slides.PointF(left_top_size, 0)
    top_right = slides.PointF(shape_width - right_top_size, 0)
    right_bottom = slides.PointF(shape_width, shape_height - right_bottom_size)
    bottom_left = slides.PointF(left_bottom_size, shape_height)
    left_top = slides.PointF(0, left_top_size)

    geometry_path = slides.GeometryPath()
    geometry_path.move_to(top_left)
    geometry_path.line_to(top_right)
    geometry_path.arc_to(right_top_size, right_top_size, 180, -90)
    geometry_path.line_to(right_bottom)
    geometry_path.arc_to(right_bottom_size, right_bottom_size, -90, -90)
    geometry_path.line_to(bottom_left)
    geometry_path.arc_to(left_bottom_size, left_bottom_size, 0, -90)
    geometry_path.line_to(left_top)
    geometry_path.arc_to(left_top_size, left_top_size, 90, -90)
    geometry_path.close_figure()

    shape.set_geometry_path(geometry_path)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Verificare se una Geometria di Forma è Chiusa**

Il seguente helper verifica se ogni percorso geometrico non vuoto termina con un segmento di chiusura. Legge [GeometryPath.path_data](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/path_data/) e confronta il comando del segmento finale [PathSegment.path_command](https://reference.aspose.com/slides/python-net/aspose.slides/pathsegment/path_command/) con [PathCommandType.CLOSE](https://reference.aspose.com/slides/python-net/aspose.slides/pathcommandtype/). Restituisce false quando non ci sono percorsi non vuoti. Questa verifica il comando finale di ciascun percorso; non esamina ogni sottofigura all'interno di un percorso. L'esempio stampa `True` per un rettangolo.

```python
import aspose.slides as slides


def is_geometry_closed(geometry_shape):
    has_nonempty_path = False

    for geometry_path in geometry_shape.get_geometry_paths():
        segments = geometry_path.path_data
        if len(segments) == 0:
            continue

        has_nonempty_path = True
        last_segment = segments[len(segments) - 1]
        if last_segment.path_command != slides.PathCommandType.CLOSE:
            return False

    return has_nonempty_path


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 200, 100)
    print(is_geometry_closed(shape))
```

## **Ispezionare i Comandi del Percorso Geometrico**

Scaricare [contour.pptx](contour.pptx) e collocarlo nella directory di lavoro. La prima forma sulla prima diapositiva ha un bordo superiore diritto, una curva Bézier cubica e un bordo di chiusura diritto. Utilizzare [GeometryShape.get_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/get_geometry_paths/) per leggere i suoi percorsi. Per ogni percorso, [GeometryPath.path_data](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/path_data/) elenca i segmenti nell'ordine di disegno. Il [PathSegment.path_command](https://reference.aspose.com/slides/python-net/aspose.slides/pathsegment/path_command/) di ciascun segmento determina come interpretare il relativo [PathSegment.segment_data](https://reference.aspose.com/slides/python-net/aspose.slides/pathsegment/segment_data/).

```python
import aspose.slides as slides

with slides.Presentation("contour.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    for i, path in enumerate(shape.get_geometry_paths()):
        for j, segment in enumerate(path.path_data):
            command = segment.path_command
            data = segment.segment_data
            if command in (slides.PathCommandType.MOVE_TO, slides.PathCommandType.LINE_TO):
                detail = f"destination={tuple(data)}"
            elif command == slides.PathCommandType.CUBIC_BEZIER_TO:
                detail = f"control1={tuple(data[:2])} control2={tuple(data[2:4])} end={tuple(data[4:])}"
            elif command == slides.PathCommandType.CLOSE:
                detail = "no coordinates"
            else:
                detail = f"raw={data}"
            print(f"Path {i}, segment {j}: {command.name} {detail}")
```

La forma si trova a (200, 100) punti sulla diapositiva. Le coordinate riportate sono locali alla forma. L'angolo in alto a sinistra è (0, 0), x aumenta verso destra e y aumenta verso il basso. Il segmento di chiusura ritorna al punto iniziale senza coordinate aggiuntive.

```text
Path 0, segment 0: MOVE_TO destination=(0, 0)
Path 0, segment 1: LINE_TO destination=(80, 0)
Path 0, segment 2: CUBIC_BEZIER_TO control1=(70, 15) control2=(30, 45) end=(0, 60)
Path 0, segment 3: CLOSE no coordinates
```

![PowerPoint shape with a straight top edge, a curved edge from the upper right to the lower left, and a straight left edge](contour.png)

## **Estrarre e Ispezionare gli Elementi della Forma**

Utilizzare [GeometryShape.create_shape_elements](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/create_shape_elements/) per ispezionare una forma esistente come elementi contenenti punti di percorso e tipi di punto. Ogni [ShapeElement](https://reference.aspose.com/slides/python-net/aspose.slides/shapeelement/) restituito espone i propri array [path_points](https://reference.aspose.com/slides/python-net/aspose.slides/shapeelement/path_points/) e [path_types](https://reference.aspose.com/slides/python-net/aspose.slides/shapeelement/path_types/). Questa rappresentazione è utile per l'analisi dei contorni o per passare la geometria a strumenti di disegno personalizzati.

L'esempio apre una presentazione, trova la prima forma geometrica direttamente sulla prima diapositiva e stampa i suoi segmenti di percorso. Utilizzare una presentazione contenente una forma con segmenti dritti e curvi per osservare entrambi i tipi di output. Non ricerca all'interno dei gruppi.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]
    shape = next((item for item in slide.shapes if isinstance(item, slides.GeometryShape)), None)

    if shape is None:
        print("No geometry shape found on the first slide.")
    else:
        for element in shape.create_shape_elements():
            points = element.path_points
            types = element.path_types
            print("Shape element:")

            i = 0
            while i < len(points):
                point_type = types[i] & 0x07  # Mantieni il tipo di segmento, escludendo i flag.
                if point_type == 0:
                    print(f"Start figure at {points[i]}")
                elif point_type == 1:
                    print(f"Line to {points[i]}")
                elif point_type == 3:
                    print(f"Cubic Bezier: controls {points[i]}, {points[i + 1]}; end {points[i + 2]}")
                    i += 2  # Consuma entrambi i punti di controllo e il punto finale.

                if (types[i] & 0x80) != 0:
                    print("Close subpath back to its starting point.")
                i += 1
```

Gli array corrispondono per indice: `points[i]` è un punto e `types[i]` ne descrive il ruolo. Il tipo `0` avvia una figura, e il tipo `1` traccia una linea dal punto precedente al punto corrente. Un segmento Bézier cubico inizia dal punto finale precedente e utilizza tre voci consecutive di tipo `3`: due punti di controllo seguiti dal nuovo punto finale. Il ciclo consuma queste tre voci insieme e verifica il punto finale per la chiusura.

I tipi di punto contengono anche flag. Mascherare con `0x07` per identificare il tipo di segmento e testare `0x80` separatamente per rilevare un sotto-percorso chiuso. Ad esempio, `129` (`0x81`) indica un punto finale di linea che chiude un sotto-percorso, e `131` (`0x83`) indica un punto finale Bézier che chiude uno. Confrontare il valore grezzo solo con `1` o `3` farebbe perdere questi casi. Altri flag, come quello di tratteggio (`0x10`) e marker (`0x20`), non modificano il tipo base del segmento.

**Coordinate e trasformazioni.** I punti sono misurati in punti (1/72 di pollice), con X che aumenta verso destra e Y che aumenta verso il basso. Per una forma non raggruppata, le coordinate estratte includono già la sua posizione [x](https://reference.aspose.com/slides/python-net/aspose.slides/shape/x/) e [y](https://reference.aspose.com/slides/python-net/aspose.slides/shape/y/) e riflettono la sua larghezza e altezza attuali. Ad esempio, un rettangolo non ruotato a `(100, 200)` con dimensioni `120 × 80` ha i limiti del contorno `(100, 200)`–`(220, 280)`. Non aggiungere nuovamente la posizione della forma. Sottrarre X e Y per ottenere coordinate relative al suo riquadro non ruotato.

I punti estratti non applicano la [rotation](https://reference.aspose.com/slides/python-net/aspose.slides/shape/rotation/) della forma né le inversioni orizzontali e verticali. Per ricreare il contorno visualizzato, applicare tali trasformazioni intorno al centro della forma. Per le forme raggruppate, tenere conto anche della mappatura delle coordinate del gruppo e delle trasformazioni; non presumere che i punti estratti siano le coordinate finali della diapositiva renderizzata o applicare una traduzione o scala due volte se è già riflessa nel frame del figlio.

**Ispezione vs. modifica.** Gli array estratti descrivono il contorno; modificarli non aggiorna la forma originale. Scegliere questo approccio quando la tua analisi o codice di disegno necessita di array punto/tipo. Utilizzare [get_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/get_geometry_paths/) quando occorrono comandi di geometria nel sistema di coordinate locale della forma o quando si vuole modificare la sua geometria. Applicare i percorsi modificati tramite [set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/) o [set_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_paths/).

## **FAQ**

**Cosa accade al riempimento e al contorno dopo aver sostituito la geometria?**

Lo stile rimane associato alla forma; solo il contorno cambia. Il riempimento e il contorno vengono applicati automaticamente alla nuova geometria.

**Come ruoto correttamente una forma personalizzata insieme alla sua geometria?**

Utilizzare la proprietà [rotation](https://reference.aspose.com/slides/python-net/aspose.slides/shape/rotation/) della forma; la geometria ruota con la forma perché è legata al sistema di coordinate della forma stessa.

**Posso convertire una forma personalizzata in un'immagine per "bloccarne" il risultato?**

Sì. Esportare l'area della [diapositiva](/slides/it/python-net/convert-powerpoint-to-png/) o la [forma](/slides/it/python-net/create-shape-thumbnails/) stessa in un formato raster; questo semplifica il lavoro successivo con geometrie complesse.