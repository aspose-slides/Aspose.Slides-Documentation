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
- cambia forma
- geometria della forma
- percorso geometrico
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
description: "Crea e personalizza le forme nelle presentazioni PowerPoint con Aspose.Slides per Python tramite Java: percorsi geometrici, angoli curvi, forme composite."
---
## **Panoramica**

Questo articolo spiega come personalizzare le forme di una presentazione in Aspose.Slides modificando la geometria delle forme tramite i punti di modifica e i percorsi geometrici. Mostra come lavorare con [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) per modificare forme esistenti, eseguire operazioni di base di modifica del percorso, aggiungere o rimuovere punti e applicare la geometria aggiornata a una forma.

Dimostra inoltre come creare forme personalizzate e composite, costruire forme con angoli curvi, determinare se la geometria di una forma è chiusa, ispezionare gli elementi della forma e convertire i contorni di testo Java AWT in percorsi geometrici.

## **Modifica di una Forma con i Punti di Modifica**

In PowerPoint, è possibile utilizzare **Edit Points** per modificare un quadrato:

* Spostare un angolo verso l’interno o verso l’esterno.
* Regolare la curvatura in un punto.
* Aggiungere nuovi punti.

Modificando i punti è possibile modificare il contorno di una forma o utilizzare una forma esistente come base per una nuova.

## **Suggerimenti per la Modifica delle Forme**

![overview_image](custom_shape_0.png)

Quando si modificano le forme in PowerPoint, tenere presente questi concetti:

* Una forma (o il suo percorso) può essere chiusa o aperta.
* Il percorso di una forma è costituito da punti di ancoraggio collegati da segmenti.
* Un segmento può essere lineare o curvo. I punti di ancoraggio e le maniglie di controllo determinano la sua forma.
* I punti di ancoraggio esistono come punti d’angolo, punti lineari o punti lisci:
  * In un punto d’angolo, i segmenti adiacenti possono incontrarsi con un angolo.
  * In un punto liscio, le due maniglie di controllo sono allineate e a distanza uguale dal punto di ancoraggio.
  * In un punto lineare, le due maniglie di controllo sono allineate ma possono avere distanze diverse dal punto di ancoraggio.
* Spostare i punti di ancoraggio o regolare le loro maniglie cambia il contorno della forma.

Per modificare le forme di PowerPoint tramite i punti di modifica, **Aspose.Slides** fornisce la classe [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/).

* Un’istanza di [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) rappresenta il percorso geometrico dell’oggetto [GeometryShape](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/).
* Per recuperare il [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) da un’istanza di [GeometryShape](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/), è possibile utilizzare il metodo [GeometryShape.getGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#getGeometryPaths).
* Per impostare il [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) per una forma, è possibile utilizzare questi metodi: [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath) per forme con un singolo percorso e [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPaths) per forme con percorsi multipli.
* Per aggiungere segmenti, è possibile utilizzare i metodi della classe [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/).
* Utilizzando i metodi [GeometryPath.setStroke](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#setStroke) e [GeometryPath.setFillMode](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#setFillMode), è possibile impostare l’aspetto di un percorso geometrico.
* Tramite il metodo [GeometryPath.getPathData](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#getPathData) è possibile recuperare il percorso geometrico di un [GeometryShape](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/) come array di segmenti di percorso.
* Per accedere a ulteriori opzioni di personalizzazione della geometria della forma, è possibile leggere un [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) tramite il suo [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) e riprodurre i segmenti su un [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/).

## **Operazioni di Modifica Semplici**

Utilizzare i seguenti metodi per modificare un percorso geometrico. Le overload che accettano un indice inseriscono un segmento in quella posizione basata su zero nell’array dei segmenti del percorso.

| Operazione | Metodo |
| --- | --- |
| Aggiungere o inserire una linea retta. | [GeometryPath.lineTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#lineTo) |
| Aggiungere o inserire una curva Bézier cubica con due punti di controllo e un punto finale. | [GeometryPath.cubicBezierTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#cubicBezierTo) |
| Aggiungere o inserire una curva Bézier quadratica con un punto di controllo e un punto finale. | [GeometryPath.quadraticBezierTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#quadraticBezierTo) |
| Aggiungere un arco ellittico con le dimensioni e gli angoli specificati in gradi. | [GeometryPath.arcTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#arcTo) |
| Chiudere la figura corrente collegando il suo punto finale al punto di partenza. | [GeometryPath.closeFigure](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#closeFigure) |
| Impostare il punto di partenza di una figura. | [GeometryPath.moveTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#moveTo) |
| Rimuovere un segmento a un indice basato su zero. | [GeometryPath.removeAt](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#removeAt) |

## **Aggiungere Punti Personalizzati a una Forma**

Questo esempio inserisce due punti in una forma rettangolare usando [GeometryPath.lineTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#lineTo) e applica il percorso modificato con [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath). Le coordinate sono relative alla forma: entrambi i nuovi punti sono al suo centro, a 100 punti dal lato sinistro e 50 punti dalla parte superiore. Gli indici dei segmenti 1 e 4 li posizionano sui bordi superiore e inferiore, tirando quei bordi verso l’interno.

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

## **Rimuovere Punti da una Forma**

Questo esempio modifica il contorno di una forma a cuore rimuovendo il segmento all’indice basato su zero 2 con [GeometryPath.removeAt](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#removeAt). L’applicazione del percorso modificato con [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath) aggiorna il contorno della forma.

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

## **Creare una Forma Personalizzata**

Questo esempio costruisce una stella a cinque punte con [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/). I raggi alternati esterno e interno di 100 e 50 punti definiscono le punte e le rientranze; un passo di 72 gradi distribuisce uniformemente le cinque punte. Il percorso è chiuso con [GeometryPath.closeFigure](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#closeFigure) e applicato a una forma rettangolare usando [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath), sostituendo il suo contorno.

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

## **Creare una Forma Personalizzata Composite**

Questo esempio definisce due [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) chiusi per il terzo superiore e inferiore di una forma. L’applicazione di entrambi i percorsi con [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPaths) crea una singola forma composita con uno spazio al centro del terzo.

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

## **Creare una Forma Personalizzata con Angoli Curvi**

Questo esempio combina segmenti lineari con [GeometryPath.arcTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#arcTo) per creare una forma con angoli curvi verso l’interno. Ogni dimensione dell’angolo imposta la larghezza e l’altezza dell’arco in punti, e la sweep di -90 gradi disegna un quarto d’ellisse in senso antiorario. Il percorso completato è applicato con [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath) e la presentazione è salvata in formato PPTX.

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

## **Verificare se la Geometria di una Forma è Chiusa**

Il seguente helper verifica se ogni percorso geometrico non vuoto termina con un segmento di chiusura. Legge [GeometryPath.getPathData](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#getPathData) e confronta il comando dell’ultimo segmento [PathSegment.getPathCommand](https://reference.aspose.com/slides/python-java/aspose.slides/pathsegment/#getPathCommand) con [PathCommandType.Close](https://reference.aspose.com/slides/python-java/aspose.slides/pathcommandtype/). Restituisce `False` quando non ci sono percorsi non vuoti. Questo controlla il comando finale di ogni percorso; non ispeziona ogni sottofigura all’interno di un percorso. L’esempio stampa `True` per un rettangolo.

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

## **Estrarre e Ispezionare gli Elementi della Forma**

Utilizzare [GeometryShape.createShapeElements](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#createShapeElements) per ispezionare una forma esistente come elementi contenenti punti di percorso e tipi di punto. Convertire ogni elemento restituito in [ShapeElement](https://reference.aspose.com/slides/python-java/aspose.slides/shapeelement/) con `jpype.JObject` per recuperare gli array di punti e di tipi tramite i metodi [getPathPoints](https://reference.aspose.com/slides/python-java/aspose.slides/shapeelement/#getPathPoints) e [getPathTypes](https://reference.aspose.com/slides/python-java/aspose.slides/shapeelement/#getPathTypes). Questa rappresentazione è utile per l’analisi del contorno o per passare la geometria a strumenti di disegno personalizzati.

L’esempio apre `input.pptx`, trova la prima forma geometrica direttamente nella prima diapositiva e stampa i suoi segmenti di percorso. Utilizzare una presentazione contenente una forma con segmenti lineari e curvi per vedere entrambi i tipi di output. Non ricerca all’interno dei gruppi.

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
                point_type = types[i] & 0x07  # Keep the segment type, excluding flags.
                if point_type == 0:
                    print(f"Start figure at {points[i]}")
                elif point_type == 1:
                    print(f"Line to {points[i]}")
                elif point_type == 3:
                    print(f"Cubic Bezier: controls {points[i]}, {points[i + 1]}; end {points[i + 2]}")
                    i += 2  # Consume both control points and the endpoint.

                if types[i] & 0x80:
                    print("Close subpath back to its starting point.")
                i += 1
finally:
    presentation.dispose()
```

Gli array corrispondono per indice: `points[i]` è un punto e `types[i]` ne descrive il ruolo. Il tipo `0` inizia una figura, e il tipo `1` disegna una linea dal punto precedente al punto corrente. Un segmento Bézier cubico inizia dal punto finale precedente e utilizza tre voci di tipo `3` consecutive: due punti di controllo seguiti dal nuovo punto finale. Il ciclo consuma queste tre voci insieme e verifica il punto finale per la chiusura.

I tipi di punto contengono anche flag. Mascherare con `0x07` per identificare il tipo di segmento, e testare `0x80` separatamente per rilevare un sotto‑percorso chiuso. Per esempio, `129` (`0x81`) indica un punto finale di linea che chiude un sotto‑percorso, e `131` (`0x83`) indica un punto finale di Bézier che chiude uno. Java memorizza questi flag in byte con segno; la mascheratura preserva i valori di bit desiderati. Confrontare il valore grezzo solo con `1` o `3` farebbe perdere questi casi. Altri flag, come dash (`0x10`) e marker (`0x20`), non modificano il tipo di segmento base.

**Coordinate e trasformazioni.** I punti sono misurati in punti (1/72 di pollice), con X che aumenta verso destra e Y che aumenta verso il basso. Per una forma non raggruppata, le coordinate estratte includono già la posizione restituita da [getX](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getX) e [getY](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getY) e riflettono la sua larghezza e altezza attuali. Per esempio, un rettangolo non ruotato a `(100, 200)` con dimensioni `120 × 80` ha i limiti del contorno `(100, 200)`–`(220, 280)`. Non aggiungere nuovamente la posizione della forma. Sottrarre X e Y per ottenere coordinate relative al suo riquadro non ruotato.

I punti estratti non applicano la rotazione della forma, restituita da [getRotation](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getRotation), né le capovolgimenti orizzontali e verticali. Per riprodurre il contorno visualizzato, applicare tali trasformazioni attorno al centro della forma. Per forme raggruppate, considerare anche la mappatura delle coordinate del gruppo e le trasformazioni; non presumere che i punti estratti siano le coordinate finali del slide renderizzato o applicare una traslazione o scala due volte se già presenti nel frame del figlio.

**Ispezione vs. modifica.** Gli array estratti descrivono il contorno; modificarli non aggiorna la forma originale. Usare questo approccio quando l’analisi o il codice di disegno richiedono array di punti/tipo. Utilizzare [getGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#getGeometryPaths) quando servono i comandi di geometria nel sistema di coordinate locale della forma o quando si desidera modificarne la geometria. Applicare i percorsi modificati tramite [setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath) o [setGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPaths).

## **Convertire una Forma Java AWT in GeometryPath**

Questo esempio combina un contorno rettangolare con testo convertito in geometria. Il metodo [setFillMode](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#setFillMode) del contorno ne disattiva il riempimento. Un [GlyphVector](https://docs.oracle.com/javase/8/docs/api/java/awt/font/GlyphVector.html) crea il contorno del testo in un [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html). Il suo [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) fornisce spostamenti, linee, segmenti quadratici, cubici e di chiusura, che l’esempio riproduce su un [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/).

Il testo utilizza un font Arial da 40 punti. Il contorno è spostato di 20 punti in orizzontale e posizionato con la sua parte superiore visiva 10 punti sotto il bordo superiore della forma. Il percorso del testo è riempito, mentre il rettangolo originale rimane un contorno. L’applicazione di entrambi i percorsi con [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPaths) produce una singola forma contenente il rettangolo e il testo.

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

    # Ottieni il percorso geometrico della forma.
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

    # Converti il percorso grafico in un percorso geometrico.
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

    # Applica il percorso del testo insieme al percorso geometrico originale.
    shape.setGeometryPaths([original_path, text_path])
finally:
    presentation.dispose()
```
![example5_image](custom_shape_5.png)

## **FAQ**

**Cosa succede al riempimento e al contorno dopo aver sostituito la geometria?**

Lo stile rimane associato alla forma; solo il contorno viene modificato. Il riempimento e il contorno vengono applicati automaticamente alla nuova geometria.

**Come ruoto correttamente una forma personalizzata insieme alla sua geometria?**

Utilizzare il metodo [setRotation](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setRotation) della forma; la geometria ruota con la forma perché è legata al suo sistema di coordinate.

**Posso convertire una forma personalizzata in un’immagine per “bloccare” il risultato?**

Sì. Esportare l’area della [slide](/slides/it/python-java/convert-powerpoint-to-png/) o la [forma](/slides/it/python-java/create-shape-thumbnails/) stessa in un formato raster; questo semplifica ulteriori operazioni con geometrie complesse.