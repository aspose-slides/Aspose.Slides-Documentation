---
title: Personalizza le forme di presentazione in Python tramite Java
linktitle: Forma personalizzata
type: docs
weight: 20
url: /it/python-java/custom-shape/
keywords:
- forma personalizzata
- aggiungi forma
- crea forma
- modifica forma
- geometria della forma
- percorso di geometria
- punti del percorso
- modifica punti
- aggiungi punto
- rimuovi punto
- operazione di modifica
- angolo curvo
- PowerPoint
- presentazione
- Python
- Aspose.Slides
description: "Crea e personalizza le forme nelle presentazioni PowerPoint con Aspose.Slides per Python tramite Java: percorsi di geometria, angoli curvi, forme composite."
---
## **Panoramica**

Questo articolo spiega come personalizzare le forme delle presentazioni in Aspose.Slides modificando la geometria delle forme tramite punti di modifica e percorsi di geometria. Mostra come lavorare con [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) per modificare le forme esistenti, eseguire operazioni di modifica di base del percorso, aggiungere o rimuovere punti e applicare la geometria aggiornata a una forma.

Dimostra inoltre come creare forme personalizzate e composite, costruire forme con angoli curvi, determinare se la geometria di una forma è chiusa, ispezionare gli elementi della forma e convertire i contorni di testo Java AWT in percorsi di geometria.

## **Modifica una forma utilizzando i punti di modifica**

* Sposta un angolo verso l'interno o verso l'esterno.
* Regola la curvatura in un punto.
* Aggiungi nuovi punti.

Modificare i punti consente di modificare il contorno di una forma o di utilizzare una forma esistente come base per una nuova.

## **Suggerimenti per la modifica delle forme**

![overview_image](custom_shape_0.png)

Durante la modifica delle forme di PowerPoint, tieni presenti questi concetti:

* Una forma (o il suo percorso) può essere chiusa o aperta.
* Il percorso di una forma è composto da punti di ancoraggio collegati da segmenti.
* Un segmento può essere lineare o curvo. I punti di ancoraggio e le maniglie di controllo ne determinano la forma.
* I punti di ancoraggio esistono come punti d'angolo, punti lineari o punti lisci:
  * In un punto d'angolo, i segmenti adiacenti possono incontrarsi formando un angolo.
  * In un punto liscio, le due maniglie di controllo sono allineate e a pari distanza dal punto di ancoraggio.
  * In un punto lineare, le due maniglie di controllo sono allineate ma possono trovarsi a distanze diverse dal punto di ancoraggio.
* Spostare i punti di ancoraggio o regolare le loro maniglie modifica il contorno della forma.

Per modificare le forme di PowerPoint tramite i punti di modifica, **Aspose.Slides** fornisce la classe [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/).

* Un'istanza di [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) rappresenta un percorso di geometria dell'oggetto [GeometryShape](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/).
* Per recuperare il [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) dall'istanza [GeometryShape](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/), è possibile utilizzare il metodo [GeometryShape.getGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#getGeometryPaths).
* Per impostare il [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) per una forma, è possibile utilizzare questi metodi: [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath) per forme con un singolo percorso e [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPaths) per forme con percorsi multipli.
* Per aggiungere segmenti, è possibile utilizzare i metodi di [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/).
* Utilizzando i metodi [GeometryPath.setStroke](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#setStroke) e [GeometryPath.setFillMode](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#setFillMode), è possibile impostare l'aspetto di un percorso di geometria.
* Con il metodo [GeometryPath.getPathData](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#getPathData), è possibile recuperare il percorso di geometria di un [GeometryShape](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/) come un array di segmenti di percorso.
* Per accedere a ulteriori opzioni di personalizzazione della geometria della forma, è possibile leggere un [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) tramite il suo [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) e riprodurre i segmenti su un [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/).

## **Operazioni di modifica semplici**

Utilizza i seguenti metodi per modificare un percorso di geometria. Le sovraccariche che accettano un indice inseriscono un segmento in quella posizione basata su zero nell'array dei segmenti del percorso.

| Operazione | Metodo |
| --- | --- |
| Aggiungi o inserisci una linea retta. | [GeometryPath.lineTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#lineTo) |
| Aggiungi o inserisci una curva Bézier cubica con due punti di controllo e un punto finale. | [GeometryPath.cubicBezierTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#cubicBezierTo) |
| Aggiungi o inserisci una curva Bézier quadratica con un punto di controllo e un punto finale. | [GeometryPath.quadraticBezierTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#quadraticBezierTo) |
| Aggiungi un arco ellittico con le dimensioni e gli angoli specificati in gradi. | [GeometryPath.arcTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#arcTo) |
| Chiudi la figura corrente collegando il suo punto finale al punto di partenza. | [GeometryPath.closeFigure](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#closeFigure) |
| Imposta il punto di partenza di una figura. | [GeometryPath.moveTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#moveTo) |
| Rimuovi un segmento a un indice basato su zero. | [GeometryPath.removeAt](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#removeAt) |

## **Aggiungi punti personalizzati a una forma**

Questo esempio inserisce due punti in una forma rettangolare utilizzando [GeometryPath.lineTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#lineTo) e applica il percorso modificato con [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath). Le coordinate sono locali alla forma: entrambi i nuovi punti si trovano al centro, 100 punti dal lato sinistro e 50 punti dalla parte superiore. Gli indici dei segmenti 1 e 4 li posizionano sui bordi superiore e inferiore, tirando questi bordi verso l'interno.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100)

    geometry_path = shape.getGeometryPaths()[0]
    geometry_path.lineTo(100, 50, 1)
    geometry_path.lineTo(100, 50, 4)

    shape.setGeometryPath(geometry_path)
finally:
    presentation.dispose()
```

![example1_image](custom_shape_1.png)

## **Rimuovi punti da una forma**

Questo esempio modifica il contorno di una forma a cuore rimuovendo il segmento all'indice basato su zero 2 con [GeometryPath.removeAt](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#removeAt). Applicando il percorso modificato con [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath), si aggiorna il contorno della forma.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Heart, 100, 100, 300, 300)

    geometry_path = shape.getGeometryPaths()[0]
    geometry_path.removeAt(2)

    shape.setGeometryPath(geometry_path)
finally:
    presentation.dispose()
```
![example2_image](custom_shape_2.png)

## **Crea una forma personalizzata**

Questo esempio crea una stella a cinque punte con [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/). I raggi esterno e interno alternati di 100 e 50 punti definiscono le punte e le rientranze; un passo di 72 gradi distribuisce uniformemente le cinque punte. Il percorso è chiuso con [GeometryPath.closeFigure](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#closeFigure) e applicato a una forma rettangolare usando [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath), sostituendo il suo contorno.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, GeometryPath

import math

points = []
outer_radius = 100
inner_radius = 50
angle_step = 72

for angle in range(-90, 270, angle_step):
    radians = math.radians(angle)
    x = outer_radius * math.cos(radians)
    y = outer_radius * math.sin(radians)
    points.append((x + outer_radius, y + outer_radius))

    radians = math.radians(angle + angle_step / 2)
    x = inner_radius * math.cos(radians)
    y = inner_radius * math.sin(radians)
    points.append((x + outer_radius, y + outer_radius))

star_path = GeometryPath()
star_path.moveTo(*points[0])
for point in points[1:]:
    star_path.lineTo(*point)
star_path.closeFigure()

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, outer_radius * 2, outer_radius * 2)
    shape.setGeometryPath(star_path)
finally:
    presentation.dispose()
```
![example3_image](custom_shape_3.png)

## **Crea una forma personalizzata composita**

Questo esempio definisce due oggetti [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) chiusi per il terzo superiore e inferiore di una forma. Applicando entrambi i percorsi con [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPaths), si crea una singola forma composita con uno spazio attraverso il terzo centrale.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, GeometryPath

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100)

    top_path = GeometryPath()
    top_path.moveTo(0, 0)
    top_path.lineTo(shape.getWidth(), 0)
    top_path.lineTo(shape.getWidth(), shape.getHeight() / 3)
    top_path.lineTo(0, shape.getHeight() / 3)
    top_path.closeFigure()

    bottom_path = GeometryPath()
    bottom_path.moveTo(0, shape.getHeight() / 3 * 2)
    bottom_path.lineTo(shape.getWidth(), shape.getHeight() / 3 * 2)
    bottom_path.lineTo(shape.getWidth(), shape.getHeight())
    bottom_path.lineTo(0, shape.getHeight())
    bottom_path.closeFigure()

    shape.setGeometryPaths([top_path, bottom_path])
finally:
    presentation.dispose()
```
![example4_image](custom_shape_4.png)

## **Crea una forma personalizzata con angoli curvi**

Questo esempio combina segmenti lineari con [GeometryPath.arcTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#arcTo) per creare una forma con angoli curvi verso l'interno. La dimensione di ciascun angolo imposta la larghezza e l'altezza dell'arco in punti, e la sweep di -90 gradi disegna un quarto di ellisse in senso antiorario. Il percorso completato è applicato con [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath), e la presentazione è salvata in formato PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, GeometryPath, SaveFormat

shape_x = 20
shape_y = 20
shape_width = 300
shape_height = 200

left_top_size = 50
right_top_size = 20
right_bottom_size = 40
left_bottom_size = 10

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Custom, shape_x, shape_y, shape_width, shape_height)

    geometry_path = GeometryPath()
    geometry_path.moveTo(left_top_size, 0)
    geometry_path.lineTo(shape_width - right_top_size, 0)
    geometry_path.arcTo(right_top_size, right_top_size, 180, -90)
    geometry_path.lineTo(shape_width, shape_height - right_bottom_size)
    geometry_path.arcTo(right_bottom_size, right_bottom_size, -90, -90)
    geometry_path.lineTo(left_bottom_size, shape_height)
    geometry_path.arcTo(left_bottom_size, left_bottom_size, 0, -90)
    geometry_path.lineTo(0, left_top_size)
    geometry_path.arcTo(left_top_size, left_top_size, 90, -90)
    geometry_path.closeFigure()
    
    shape.setGeometryPath(geometry_path)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Scopri se la geometria di una forma è chiusa**

Il seguente helper verifica se ogni percorso di geometria non vuoto termina con un segmento di chiusura. Legge [GeometryPath.getPathData](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#getPathData) e confronta il comando del segmento finale [PathSegment.getPathCommand](https://reference.aspose.com/slides/python-java/aspose.slides/pathsegment/#getPathCommand) con [PathCommandType.Close](https://reference.aspose.com/slides/python-java/aspose.slides/pathcommandtype/). Restituisce `False` quando non ci sono percorsi non vuoti. Questo controlla il comando finale di ciascun percorso; non ispeziona ogni sottofigura all'interno di un percorso. L'esempio stampa `True` per un rettangolo.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, PathCommandType

def is_geometry_closed(geometry_shape):
    has_nonempty_path = False
    for geometry_path in geometry_shape.getGeometryPaths():
        path_data = geometry_path.getPathData()
        if len(path_data) == 0:
            continue
        last_segment = path_data[-1]
        has_nonempty_path = True
        if last_segment.getPathCommand() != PathCommandType.Close:
            return False
    return has_nonempty_path

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100)
    closed = is_geometry_closed(shape)
    print(closed)
finally:
    presentation.dispose()
```

## **Ispeziona i comandi del percorso di geometria**

Scarica [contour.pptx](contour.pptx) e posizionalo nella directory di lavoro dell'applicazione. La prima forma nella prima diapositiva ha un bordo superiore lineare, una curva Bézier cubica e un bordo di chiusura lineare. Usa [getGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#getGeometryPaths) per leggere i percorsi della forma e [getPathData](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#getPathData) per leggere i segmenti di ogni percorso nell'ordine di disegno. Per ciascun segmento, [getPathCommand](https://reference.aspose.com/slides/python-java/aspose.slides/pathsegment/#getPathCommand) identifica il comando e determina come interpretare i valori restituiti da [getSegmentData](https://reference.aspose.com/slides/python-java/aspose.slides/pathsegment/#getSegmentData).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PathCommandType, Presentation

presentation = Presentation("contour.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    for i, path in enumerate(shape.getGeometryPaths()):
        for j, segment in enumerate(path.getPathData()):
            command = segment.getPathCommand()
            data = segment.getSegmentData()
            if command in (PathCommandType.MoveTo, PathCommandType.LineTo):
                detail = f"destination=({data[0]}, {data[1]})"
            elif command == PathCommandType.CubicBezierTo:
                detail = f"control1=({data[0]}, {data[1]}) control2=({data[2]}, {data[3]}) end=({data[4]}, {data[5]})"
            elif command == PathCommandType.Close:
                detail = "no coordinates"
            else:
                detail = f"raw={list(data)}"
            name = PathCommandType.getName(PathCommandType.class_, command)
            print(f"Path {i}, segment {j}: {name} {detail}")
finally:
    presentation.dispose()
```

La forma si trova a (200, 100) punti sulla diapositiva. Le coordinate riportate sono locali alla forma, con (0, 0) nell'angolo superiore sinistro, x che aumenta verso destra e y che aumenta verso il basso. Il segmento di chiusura ritorna al punto di partenza senza coordinate aggiuntive.

```text
Path 0, segment 0: MoveTo destination=(0.0, 0.0)
Path 0, segment 1: LineTo destination=(80.0, 0.0)
Path 0, segment 2: CubicBezierTo control1=(70.0, 15.0) control2=(30.0, 45.0) end=(0.0, 60.0)
Path 0, segment 3: Close no coordinates
```

![Forma PowerPoint con un bordo superiore lineare, un bordo curvo dall'angolo superiore destro a quello inferiore sinistro e un bordo sinistro lineare](contour.png)

## **Estrai e ispeziona gli elementi della forma**

Utilizza [GeometryShape.createShapeElements](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#createShapeElements) per ispezionare una forma esistente come elementi contenenti punti del percorso e tipi di punto. Converti ciascun elemento restituito in [ShapeElement](https://reference.aspose.com/slides/python-java/aspose.slides/shapeelement/) con `jpype.JObject` per recuperare gli array di punti e di tipi tramite i metodi [getPathPoints](https://reference.aspose.com/slides/python-java/aspose.slides/shapeelement/#getPathPoints) e [getPathTypes](https://reference.aspose.com/slides/python-java/aspose.slides/shapeelement/#getPathTypes). Questa rappresentazione è utile per l'analisi del contorno o per passare la geometria a strumenti di disegno personalizzati.

L'esempio apre input.pptx, trova la prima forma di geometria direttamente nella prima diapositiva e stampa i suoi segmenti di percorso. Usa una presentazione contenente una forma con segmenti lineari e curvi per vedere entrambi i tipi di output. Non ricerca all'interno dei gruppi.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, GeometryShape, ShapeElement

presentation = Presentation("input.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    shape = None
    for candidate in slide.getShapes():
        if isinstance(candidate, GeometryShape):
            shape = candidate
            break

    if shape is None:
        print("No geometry shape found on the first slide.")
    else:
        for element in shape.createShapeElements():
            shape_element = jpype.JObject(element, ShapeElement)
            points = shape_element.getPathPoints()
            types = shape_element.getPathTypes()
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

                if types[i] & 0x80:
                    print("Close subpath back to its starting point.")
                i += 1
finally:
    presentation.dispose()
```

Gli array corrispondono per indice: `points[i]` è un punto e `types[i]` ne descrive il ruolo. Il tipo `0` avvia una figura, e il tipo `1` traccia una linea dal punto precedente a quello corrente. Un segmento Bézier cubico inizia dal punto finale precedente e utilizza tre voci consecutive di tipo `3`: due punti di controllo seguiti dal nuovo punto finale. Il ciclo consuma queste tre voci insieme e verifica la chiusura del punto finale.

I tipi di punto contengono anche flag. Maschera con `0x07` per identificare il tipo di segmento e testa `0x80` separatamente per rilevare un sotto-percorso chiuso. Ad esempio, `129` (`0x81`) indica un punto finale di linea che chiude un sotto-percorso, e `131` (`0x83`) indica un punto finale Bézier che chiude uno. Java memorizza questi flag in byte con segno; la mascheratura conserva i valori di bit desiderati. Confrontare il valore grezzo solo con `1` o `3` ometterebbe questi casi. Altri flag, come dash (`0x10`) e marker (`0x20`), non modificano il tipo di segmento di base.

**Coordinate e trasformazioni.** I punti sono misurati in punti (1/72 di pollice), con X che aumenta verso destra e Y che aumenta verso il basso. Per una forma non raggruppata, le coordinate estratte includono già la posizione restituita da [getX](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getX) e [getY](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getY) e riflettono la sua larghezza e altezza attuali. Per esempio, un rettangolo non ruotato a `(100, 200)` con dimensioni `120 × 80` ha i limiti del contorno `(100, 200)`–`(220, 280)`. Non aggiungere nuovamente la posizione della forma. Sottrai X e Y per ottenere coordinate relative al suo frame non ruotato.

I punti estratti non applicano la rotazione della forma, restituita da [getRotation](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getRotation), né i ribaltamenti orizzontali e verticali. Per riprodurre il contorno visualizzato, applica quelle trasformazioni attorno al centro della forma. Per forme raggruppate, considera anche la mappatura delle coordinate del gruppo e le trasformazioni; non presumere che i punti estratti siano le coordinate finali della diapositiva renderizzate o applicare una traslazione o scala due volte se già riflessa nel frame del figlio.

**Ispezione vs modifica.** Gli array estratti descrivono il contorno; modificarli non aggiorna la forma originale. Scegli questo approccio quando la tua analisi o il codice di disegno richiedono array di punti/tipi. Usa [getGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#getGeometryPaths) quando ti servono comandi di geometria nel sistema di coordinate locale della forma o desideri modificare la sua geometria. Applica i percorsi modificati tramite [setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath) o [setGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPaths).

## **Converti una forma Java AWT in GeometryPath**

Questo esempio combina un contorno rettangolare con testo convertito in geometria. Il metodo [setFillMode](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#setFillMode) del contorno disattiva il suo riempimento. Un [GlyphVector](https://docs.oracle.com/javase/8/docs/api/java/awt/font/GlyphVector.html) crea il contorno del testo in un [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html). Il suo [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) fornisce segmenti di spostamento, linea, quadratica, cubica e di chiusura, che l'esempio riproduce su un [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/).

Il testo utilizza un carattere Arial da 40 punti. Il contorno è spostato di 20 punti orizzontalmente e posizionato con la sua parte superiore visiva 10 punti sotto il bordo superiore della forma. Il percorso del testo è riempito, mentre il rettangolo originale rimane un contorno. Applicando entrambi i percorsi con [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPaths), si ottiene una singola forma contenente il rettangolo e il testo.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, GeometryPath, PathFillModeType

from java.awt import Font
from java.awt.geom import PathIterator
from java.awt.image import BufferedImage

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 100)

    # Ottieni il percorso di geometria della forma.
    original_path = shape.getGeometryPaths()[0]
    original_path.setFillMode(PathFillModeType.None_)

    # Crea un nuovo percorso grafico con testo.
    font = Font("Arial", Font.PLAIN, 40)
    text = "Text in shape"
    image = BufferedImage(100, 100, BufferedImage.TYPE_INT_ARGB)
    graphics = image.createGraphics()
    try:
        font_context = graphics.getFontRenderContext()
        glyph_vector = font.createGlyphVector(font_context, text)
        text_bounds = glyph_vector.getVisualBounds()
        baseline = -text_bounds.getY() + 10
        graphics_path = glyph_vector.getOutline(20.0, baseline)
    finally:
        graphics.dispose()

    # Converte il percorso grafico in un percorso di geometria.
    text_path = GeometryPath()
    path_iterator = graphics_path.getPathIterator(None)
    points = jpype.JArray(jpype.JFloat)(6)
    while not path_iterator.isDone():
        segment_type = path_iterator.currentSegment(points)
        if segment_type == PathIterator.SEG_MOVETO:
            text_path.moveTo(points[0], points[1])
        elif segment_type == PathIterator.SEG_LINETO:
            text_path.lineTo(points[0], points[1])
        elif segment_type == PathIterator.SEG_QUADTO:
            text_path.quadraticBezierTo(points[0], points[1], points[2], points[3])
        elif segment_type == PathIterator.SEG_CUBICTO:
            text_path.cubicBezierTo(points[0], points[1], points[2], points[3], points[4], points[5])
        elif segment_type == PathIterator.SEG_CLOSE:
            text_path.closeFigure()
        path_iterator.next()
    text_path.setFillMode(PathFillModeType.Normal)

    # Applica il percorso di testo insieme al percorso di geometria originale.
    shape.setGeometryPaths([original_path, text_path])
finally:
    presentation.dispose()
```
![example5_image](custom_shape_5.png)

## **FAQ**

**Cosa succederà al riempimento e al contorno dopo aver sostituito la geometria?**

Lo stile rimane associato alla forma; solo il contorno cambia. Il riempimento e il contorno sono applicati automaticamente alla nuova geometria.

**Come ruoto correttamente una forma personalizzata insieme alla sua geometria?**

Utilizza il metodo [setRotation](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setRotation) della forma; la geometria ruota con la forma perché è legata al sistema di coordinate della forma stessa.

**Posso convertire una forma personalizzata in un'immagine per “bloccare” il risultato?**

Sì. Esporta l'area della [diapositiva](/slides/it/python-java/convert-powerpoint-to-png/) necessaria o la stessa [forma](/slides/it/python-java/create-shape-thumbnails/) in un formato raster; questo semplifica ulteriori lavori con geometrie complesse.