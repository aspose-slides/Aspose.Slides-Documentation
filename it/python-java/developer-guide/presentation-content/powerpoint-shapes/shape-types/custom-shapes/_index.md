---
title: Personalizza le forme delle presentazioni in Python tramite Java
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
description: "Crea e personalizza forme nelle presentazioni PowerPoint con Aspose.Slides per Python tramite Java: percorsi geometrici, angoli curvi, forme composite."
---
## **Panoramica**

Questo articolo spiega come personalizzare le forme nelle presentazioni in Aspose.Slides modificando la geometria delle forme tramite punti di modifica e percorsi geometrici. Mostra come utilizzare [GeometryPath](https://reference.aspose.com/slides/it/python-java/aspose.slides/geometrypath/) per modificare le forme esistenti, eseguire operazioni di base di modifica del percorso, aggiungere o rimuovere punti e applicare la geometria aggiornata a una forma.

Dimostra inoltre come creare forme personalizzate e composite, costruire forme con angoli curvi, determinare se la geometria di una forma è chiusa e convertire tra [GeometryPath](https://reference.aspose.com/slides/it/python-java/aspose.slides/geometrypath/) e [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) per scenari aggiuntivi di personalizzazione della geometria.

## **Modifica di una Forma tramite Punti di Modifica**

Considera un quadrato. In PowerPoint, usando **punti di modifica**, è possibile 

* spostare l'angolo del quadrato verso l'interno o l'esterno  
* specificare la curvatura di un angolo o di un punto  
* aggiungere nuovi punti al quadrato  
* manipolare i punti sul quadrato, ecc.  

In sostanza, è possibile eseguire le operazioni descritte su qualsiasi forma. Con i punti di modifica, si può modificare una forma o crearne una nuova a partire da una forma esistente. 

## **Suggerimenti per la Modifica delle Forme**

![overview_image](custom_shape_0.png)

Prima di iniziare a modificare le forme di PowerPoint mediante punti di modifica, potresti considerare questi aspetti delle forme:

* Una forma (o il suo percorso) può essere chiusa o aperta.  
* Quando una forma è chiusa, non ha un punto di inizio o di fine. Quando è aperta, ha un inizio e una fine.  
* Tutte le forme sono composte da almeno 2 punti di ancoraggio collegati tra loro da segmenti.  
* Un segmento è lineare o curvo. I punti di ancoraggio determinano la natura del segmento.  
* I punti di ancoraggio esistono come punti di angolo, punti lineari o punti lisci:  
  * Un punto di angolo è un punto in cui 2 segmenti lineari si incontrano con un angolo.  
  * Un punto liscio è un punto in cui 2 maniglie sono allineate su una linea retta e i segmenti del percorso si uniscono in una curva fluida. In questo caso, tutte le maniglie sono separate dal punto di ancoraggio alla stessa distanza.  
  * Un punto lineare è un punto in cui 2 maniglie sono allineate su una linea retta e i segmenti del percorso si uniscono in una curva fluida. In questo caso, le maniglie non devono essere separate dal punto di ancoraggio alla stessa distanza.  
* Spostando o modificando i punti di ancoraggio (che cambia l'angolo dei segmenti), è possibile modificare l’aspetto di una forma.  

Per modificare le forme di PowerPoint tramite punti di modifica, **Aspose.Slides** fornisce la classe [GeometryPath](https://reference.aspose.com/slides/it/python-java/aspose.slides/geometrypath/).

* Un'istanza di [GeometryPath](https://reference.aspose.com/slides/it/python-java/aspose.slides/geometrypath/) rappresenta il percorso geometrico dell'oggetto [GeometryShape](https://reference.aspose.com/slides/it/python-java/aspose.slides/geometryshape/).  
* Per recuperare il [GeometryPath](https://reference.aspose.com/slides/it/python-java/aspose.slides/geometrypath/) da un'istanza di [GeometryShape](https://reference.aspose.com/slides/it/python-java/aspose.slides/geometryshape/), puoi utilizzare il metodo [GeometryShape.getGeometryPaths](https://reference.aspose.com/slides/it/python-java/aspose.slides/geometryshape/#getGeometryPaths).  
* Per impostare il [GeometryPath](https://reference.aspose.com/slides/it/python-java/aspose.slides/geometrypath/) per una forma, puoi usare questi metodi: [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/it/python-java/aspose.slides/geometryshape/#setGeometryPath) per *forme solide* e [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/it/python-java/aspose.slides/geometryshape/#setGeometryPaths) per *forme composite*.  
* Per aggiungere segmenti, puoi utilizzare i metodi sotto [GeometryPath](https://reference.aspose.com/slides/it/python-java/aspose.slides/geometrypath/).  
* Usando i metodi [GeometryPath.setStroke](https://reference.aspose.com/slides/it/python-java/aspose.slides/geometrypath/#setStroke) e [GeometryPath.setFillMode](https://reference.aspose.com/slides/it/python-java/aspose.slides/geometrypath/#setFillMode), è possibile impostare l’aspetto di un percorso geometrico.  
* Con il metodo [GeometryPath.getPathData](https://reference.aspose.com/slides/it/python-java/aspose.slides/geometrypath/#getPathData), puoi recuperare il percorso geometrico di un [GeometryShape](https://reference.aspose.com/slides/it/python-java/aspose.slides/geometryshape/) come un array di segmenti del percorso.  
* Per accedere a ulteriori opzioni di personalizzazione della geometria delle forme, puoi convertire [GeometryPath](https://reference.aspose.com/slides/it/python-java/aspose.slides/geometrypath/) in [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html).  
* Usa i metodi [geometryPathToGraphicsPath](https://reference.aspose.com/slides/it/python-java/aspose.slides/shapeutil/) e [graphicsPathToGeometryPath](https://reference.aspose.com/slides/it/python-java/aspose.slides/shapeutil/) (dalla classe [ShapeUtil](https://reference.aspose.com/slides/it/python-java/aspose.slides/shapeutil/)) per convertire [GeometryPath](https://reference.aspose.com/slides/it/python-java/aspose.slides/geometrypath/) in [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) e viceversa.  

## **Operazioni di Modifica Semplici**

Le firme seguenti mostrano le operazioni di modifica di base:

**Aggiungi una linea** alla fine di un percorso:

- `geometry_path.lineTo(point)`
- `geometry_path.lineTo(x, y)`

**Aggiungi una linea** a una posizione specificata nel percorso:

- `geometry_path.lineTo(point, index)`
- `geometry_path.lineTo(x, y, index)`

**Aggiungi una curva di Bézier cubica** alla fine di un percorso:

- `geometry_path.cubicBezierTo(point1, point2, point3)`
- `geometry_path.cubicBezierTo(x1, y1, x2, y2, x3, y3)`

**Aggiungi una curva di Bézier cubica** alla posizione specificata nel percorso:

- `geometry_path.cubicBezierTo(point1, point2, point3, index)`
- `geometry_path.cubicBezierTo(x1, y1, x2, y2, x3, y3, index)`

**Aggiungi una curva di Bézier quadratica** alla fine di un percorso:

- `geometry_path.quadraticBezierTo(point1, point2)`
- `geometry_path.quadraticBezierTo(x1, y1, x2, y2)`

**Aggiungi una curva di Bézier quadratica** a una posizione specificata nel percorso:

- `geometry_path.quadraticBezierTo(point1, point2, index)`
- `geometry_path.quadraticBezierTo(x1, y1, x2, y2, index)`

**Allega un arco dato** a un percorso:

- `geometry_path.arcTo(width, height, start_angle, sweep_angle)`

**Chiudi la figura corrente** di un percorso:

- `geometry_path.closeFigure()`

**Imposta la posizione per il punto successivo**:

- `geometry_path.moveTo(point)`
- `geometry_path.moveTo(x, y)`

**Rimuovi il segmento del percorso** a un indice specificato:

- `geometry_path.removeAt(index)`


## **Aggiungi Punti Personalizzati a una Forma**
1. Crea un'istanza della classe [GeometryShape](https://reference.aspose.com/slides/it/python-java/aspose.slides/geometryshape/) e imposta il tipo [ShapeType.Rectangle](https://reference.aspose.com/slides/it/python-java/aspose.slides/shapetype/#Rectangle).  
2. Ottieni un'istanza della classe [GeometryPath](https://reference.aspose.com/slides/it/python-java/aspose.slides/geometrypath/) dalla forma.  
3. Aggiungi un nuovo punto tra i due punti superiori del percorso.  
4. Aggiungi un nuovo punto tra i due punti inferiori del percorso.  
5. Applica il percorso alla forma.  

Questo codice Python mostra come aggiungere punti personalizzati a una forma:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100)
    geometry_path = shape.getGeometryPaths()[0]
    geometry_path.lineTo(100, 50, 1)
    geometry_path.lineTo(100, 50, 4)
    shape.setGeometryPath(geometry_path)
finally:
    presentation.dispose()
```
![example1_image](custom_shape_1.png)

## **Rimuovi Punti da una Forma**

1. Crea un'istanza della classe [GeometryShape](https://reference.aspose.com/slides/it/python-java/aspose.slides/geometryshape/) e imposta il tipo [ShapeType.Heart](https://reference.aspose.com/slides/it/python-java/aspose.slides/shapetype/#Heart).  
2. Ottieni un'istanza della classe [GeometryPath](https://reference.aspose.com/slides/it/python-java/aspose.slides/geometrypath/) dalla forma.  
3. Rimuovi il segmento del percorso.  
4. Applica il percorso alla forma.  

Questo codice Python mostra come rimuovere punti da una forma:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Heart, 100, 100, 300, 300)
    geometry_path = shape.getGeometryPaths()[0]
    geometry_path.removeAt(2)
    shape.setGeometryPath(geometry_path)
finally:
    presentation.dispose()
```
![example2_image](custom_shape_2.png)

## **Crea una Forma Personalizzata**

1. Calcola i punti per la forma.  
2. Crea un'istanza della classe [GeometryPath](https://reference.aspose.com/slides/it/python-java/aspose.slides/geometrypath/).  
3. Riempi il percorso con i punti.  
4. Crea un'istanza della classe [GeometryShape](https://reference.aspose.com/slides/it/python-java/aspose.slides/geometryshape/).  
5. Applica il percorso alla forma.  

Questo codice Python mostra come creare una forma personalizzata:

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
step = 72

for angle in range(-90, 270, step):
    radians = math.radians(angle)
    x = outer_radius * math.cos(radians)
    y = outer_radius * math.sin(radians)
    points.append((x + outer_radius, y + outer_radius))

    radians = math.radians(angle + step / 2)
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
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, outer_radius * 2, outer_radius * 2)
    shape.setGeometryPath(star_path)
finally:
    presentation.dispose()
```
![example3_image](custom_shape_3.png)


## **Crea una Forma Personalizzata Composite**

1. Crea un'istanza della classe [GeometryShape](https://reference.aspose.com/slides/it/python-java/aspose.slides/geometryshape/).  
2. Crea una prima istanza della classe [GeometryPath](https://reference.aspose.com/slides/it/python-java/aspose.slides/geometrypath/).  
3. Crea una seconda istanza della classe [GeometryPath](https://reference.aspose.com/slides/it/python-java/aspose.slides/geometrypath/).  
4. Applica i percorsi alla forma.  

Questo codice Python mostra come creare una forma personalizzata composite:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, GeometryPath

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100)

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

## **Crea una Forma Personalizzata con Angoli Curvi**

Questo codice Python mostra come creare una forma personalizzata con angoli curvi (verso l'interno):

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
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Custom, shape_x, shape_y, shape_width, shape_height)
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

## **Verifica se la Geometria di una Forma è Chiusa**

Una forma chiusa è definita come quella i cui lati sono tutti collegati, formando un unico perimetro senza interruzioni. Tale forma può essere una semplice figura geometrica o un contorno personalizzato complesso. L'esempio di codice seguente mostra come verificare se la geometria di una forma è chiusa:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PathCommandType

def is_geometry_closed(geometry_shape):
    is_closed = False
    for geometry_path in geometry_shape.getGeometryPaths():
        path_data = geometry_path.getPathData()
        if len(path_data) == 0:
            continue
        last_segment = path_data[-1]
        is_closed = last_segment.getPathCommand() == PathCommandType.Close
        if not is_closed:
            return False
    return is_closed
```

## **Converti GeometryPath in java.awt.Shape** 

1. Crea un'istanza della classe [GeometryShape](https://reference.aspose.com/slides/it/python-java/aspose.slides/geometryshape/).  
2. Crea un'istanza della classe [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html).  
3. Converti l'istanza di [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) in un'istanza di [GeometryPath](https://reference.aspose.com/slides/it/python-java/aspose.slides/geometrypath/) percorrendo il suo [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) e riproducendo ogni segmento sul percorso.  
4. Applica i percorsi alla forma.  

Questo codice Python implementa i passaggi sopra per convertire un percorso grafico in un percorso geometrico:

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
    # Crea una nuova forma.
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 100)

    # Ottieni il percorso geometrico della forma.
    original_path = shape.getGeometryPaths()[0]
    original_path.setFillMode(PathFillModeType.None_)

    # Crea un nuovo percorso grafico con testo.
    font = Font("Arial", Font.PLAIN, 40)
    text = "Text in shape"
    image = BufferedImage(100, 100, BufferedImage.TYPE_INT_ARGB)
    graphics = image.createGraphics()
    try:
        glyph_vector = font.createGlyphVector(graphics.getFontRenderContext(), text)
        graphics_path = glyph_vector.getOutline(20.0, -glyph_vector.getVisualBounds().getY() + 10)
    finally:
        graphics.dispose()

    # Convert the graphics path to a geometry path.
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

    # Apply the text path together with the original geometry path.
    shape.setGeometryPaths([original_path, text_path])
finally:
    presentation.dispose()
```
![example5_image](custom_shape_5.png)

## **FAQ**

**Cosa succede al riempimento e al contorno dopo aver sostituito la geometria?**

Lo stile rimane associato alla forma; solo il contorno cambia. Il riempimento e il contorno vengono applicati automaticamente alla nuova geometria.

**Come ruoto correttamente una forma personalizzata insieme alla sua geometria?**

Usa il metodo [setRotation](https://reference.aspose.com/slides/it/python-java/aspose.slides/shape/#setRotation) della forma; la geometria ruota con la forma perché è legata al sistema di coordinate della forma stessa.

**Posso convertire una forma personalizzata in un'immagine per “bloccare” il risultato?**

Sì. Esporta l'area della [slide](/slides/it/python-java/convert-powerpoint-to-png/) o la [shape](/slides/it/python-java/create-shape-thumbnails/) stessa in un formato raster; questo semplifica il lavoro successivo con geometrie complesse.