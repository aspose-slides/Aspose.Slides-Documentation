---
title: Personalizza le forme nelle presentazioni con Python
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
- modifica punti
- aggiungi punto
- rimuovi punto
- operazione di modifica
- angolo curvo
- PowerPoint
- OpenDocument
- presentazione
- Python
- Aspose.Slides
description: "Crea e personalizza forme in presentazioni PowerPoint e OpenDocument con Aspose.Slides per Python via .NET: percorsi geometrici, angoli curvi, forme composite."
---
## **Introduzione**

Considera un quadrato. In PowerPoint, usando **Modifica punti**, puoi:

* spostare l’angolo di un quadrato verso l’interno o verso l’esterno,
* regolare la curvatura di un angolo o di un punto,
* aggiungere nuovi punti al quadrato,
* manipolare i suoi punti.

Puoi applicare queste operazioni a qualsiasi forma. Con **Modifica punti**, puoi modificare una forma o crearne una nuova a partire da una forma esistente.

## **Suggerimenti per la modifica delle forme**

!["Comando Modifica punti"](custom_shape_0.png)

Prima di iniziare a modificare le forme di PowerPoint usando **Modifica punti**, considera queste note sulle forme:

* Una forma (o il suo percorso) può essere **chiusa** o **aperta**.
* Una forma chiusa non ha punto di inizio o di fine; una forma aperta ha un inizio e una fine.
* Ogni forma ha almeno due punti di ancoraggio collegati da segmenti di linea.
* Un segmento è dritto o curvo; i punti di ancoraggio determinano la natura del segmento.
* I punti di ancoraggio possono essere **angolo**, **liscio**, o **dritto**:
  * Un punto **angolo** è dove due segmenti dritti si incontrano formando un angolo.
  * Un punto **liscio** ha due maniglie collineari e i segmenti adiacenti formano una curva fluida. In questo caso, entrambe le maniglie sono alla stessa distanza dal punto di ancoraggio.
  * Un punto **dritto** ha anche due maniglie collineari, e i segmenti adiacenti formano una curva fluida. In questo caso, le maniglie non devono essere alla stessa distanza dal punto di ancoraggio.
* Spostando o modificando i punti di ancoraggio (cambiando così gli angoli dei segmenti), puoi modificare l’aspetto della forma.

Per modificare le forme di PowerPoint, Aspose.Slides fornisce la classe [GeometryPath](https://reference.aspose.com/slides/it/python-net/aspose.slides/geometrypath/) .

* Un'istanza di [GeometryPath](https://reference.aspose.com/slides/it/python-net/aspose.slides/geometrypath/) rappresenta il percorso geometrico di un oggetto [GeometryShape](https://reference.aspose.com/slides/it/python-net/aspose.slides/geometryshape/) .
* Per recuperare il [GeometryPath](https://reference.aspose.com/slides/it/python-net/aspose.slides/geometrypath/) da un'istanza di [GeometryShape](https://reference.aspose.com/slides/it/python-net/aspose.slides/geometryshape/) , usa il metodo [GeometryShape.get_geometry_paths](https://reference.aspose.com/slides/it/python-net/aspose.slides/geometryshape/get_geometry_paths/) .
* Per impostare il [GeometryPath](https://reference.aspose.com/slides/it/python-net/aspose.slides/geometrypath/) per una forma, usa [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/it/python-net/aspose.slides/geometryshape/set_geometry_path/) per *forme solide* e [GeometryShape.set_geometry_paths](https://reference.aspose.com/slides/it/python-net/aspose.slides/geometryshape/set_geometry_paths/) per *forme composite* .
* Per aggiungere segmenti, usa i metodi di [GeometryPath](https://reference.aspose.com/slides/it/python-net/aspose.slides/geometrypath/) .
* Usa le proprietà [GeometryPath.stroke](https://reference.aspose.com/slides/it/python-net/aspose.slides/geometrypath/stroke/) e [GeometryPath.fill_mode](https://reference.aspose.com/slides/it/python-net/aspose.slides/geometrypath/fill_mode/) per controllare l’aspetto di un percorso geometrico.
* Usa la proprietà [GeometryPath.path_data](https://reference.aspose.com/slides/it/python-net/aspose.slides/geometrypath/path_data/) per recuperare il percorso geometrico di una forma come un array di segmenti di percorso.

## **Operazioni di modifica semplici**

I seguenti metodi sono usati per operazioni di modifica semplici.

**Aggiungi una linea** alla fine di un percorso:

```py
line_to(point)
line_to(x, y)
```

**Aggiungi una linea** in una posizione specificata in un percorso:

```py    
line_to(point, index)
line_to(x, y, index)
```

**Aggiungi una curva cubica di Bézier** alla fine di un percorso:

```py
cubic_bezier_to(point1, point2, point3)
cubic_bezier_to(x1, y1, x2, y2, x3, y3)
```

**Aggiungi una curva cubica di Bézier** in una posizione specificata in un percorso:

```py
cubic_bezier_to(point1, point2, point3, index)
cubic_bezier_to(x1, y1, x2, y2, x3, y3, index)
```

**Aggiungi una curva quadratica di Bézier** alla fine di un percorso:

```py
quadratic_bezier_to(point1, point2)
quadratic_bezier_to(x1, y1, x2, y2)
```

**Aggiungi una curva quadratica di Bézier** in una posizione specificata in un percorso:

```py
quadratic_bezier_to(point1, point2, index)
quadratic_bezier_to(x1, y1, x2, y2, index)
```

**Aggiungi un arco** a un percorso:

```py
arc_to(width, heigth, startAngle, sweepAngle)
```

**Chiudi la figura corrente** in un percorso:

```py
close_figure()
```

**Imposta la posizione per il punto successivo**:

```py
move_to(point)
move_to(x, y)
```

**Rimuovi il segmento del percorso** a un indice dato:

```py
remove_at(index)
```

## **Aggiungere punti personalizzati alle forme**

Qui imparerai a definire una forma libera aggiungendo la tua sequenza di punti. Specificando punti ordinati e tipi di segmento (dritto o curvo) e chiudendo opzionalmente il percorso, puoi disegnare grafiche personalizzate precise — poligoni, icone, didascalie o loghi — direttamente nelle tue diapositive.

1. Crea un'istanza della classe [GeometryShape](https://reference.aspose.com/slides/it/python-net/aspose.slides/geometryshape/) e imposta il suo [ShapeType.RECTANGLE](https://reference.aspose.com/slides/it/python-net/aspose.slides/shapetype/) .
2. Ottieni un'istanza di [GeometryPath](https://reference.aspose.com/slides/it/python-net/aspose.slides/geometrypath/) dalla forma.
3. Inserisci un nuovo punto tra i due punti superiori del percorso.
4. Inserisci un nuovo punto tra i due punti inferiori del percorso.
5. Applica il percorso aggiornato alla forma.

Il seguente codice Python mostra come aggiungere punti personalizzati a una forma:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 200, 100)

    geometry_path = shape.get_geometry_paths()[0]
    geometry_path.line_to(100, 50, 1)
    geometry_path.line_to(100, 50, 4)

    shape.set_geometry_path(geometry_path)

    presentation.save("custom_points.pptx", slides.export.SaveFormat.PPTX)
```

![Punti personalizzati](custom_shape_1.png)

##  **Rimuovere i punti dalle forme**

A volte una forma personalizzata contiene punti non necessari che complicano la sua geometria o influenzano il rendering. Questa sezione mostra come rimuovere punti specifici dal percorso di una forma così da semplificare il contorno e ottenere risultati più puliti e precisi.

1. Crea un'istanza della classe [GeometryShape](https://reference.aspose.com/slides/it/python-net/aspose.slides/geometryshape/) e imposta il suo tipo [ShapeType.HEART](https://reference.aspose.com/slides/it/python-net/aspose.slides/shapetype/) .
2. Ottieni un'istanza di [GeometryPath](https://reference.aspose.com/slides/it/python-net/aspose.slides/geometrypath/) dalla forma.
3. Rimuovi un segmento dal percorso.
4. Applica il percorso aggiornato alla forma.

Il seguente codice Python mostra come rimuovere i punti da una forma:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.HEART, 100, 100, 300, 300)

    path = shape.get_geometry_paths()[0]
    path.remove_at(2)

    shape.set_geometry_path(path)

    presentation.save("removed_points.pptx", slides.export.SaveFormat.PPTX)
```

![Punti rimossi](custom_shape_2.png)

##  **Creare forme personalizzate**

Crea forme vettoriali su misura definendo un [GeometryPath](https://reference.aspose.com/slides/it/python-net/aspose.slides/geometrypath/) e componendolo da linee, archi e curve Bézier. Questa sezione mostra come costruire una geometria personalizzata da zero e aggiungere la forma risultante alla tua diapositiva.

1. Calcola i punti per la forma.
2. Crea un'istanza della classe [GeometryPath](https://reference.aspose.com/slides/it/python-net/aspose.slides/geometrypath/) .
3. Popola il percorso con i punti.
4. Crea un'istanza della classe [GeometryShape](https://reference.aspose.com/slides/it/python-net/aspose.slides/geometryshape/) .
5. Applica il percorso alla forma.

Il seguente codice Python mostra come creare una forma personalizzata:

```py
import aspose.slides as slides
import aspose.pydrawing as draw
import math

points = []

R = 100
r = 50
step = 72

for angle in range(-90, 270, step):
    radians = angle * (math.pi / 180)
    x = R * math.cos(radians)
    y = R * math.sin(radians)
    points.append(draw.PointF(x + R, y + R))

    radians = math.pi * (angle + step / 2) / 180.0
    x = r * math.cos(radians)
    y = r * math.sin(radians)
    points.append(draw.PointF(x + R, y + R))

star_path = slides.GeometryPath()
star_path.move_to(points[0])

for i in range(len(points)):
    star_path.line_to(points[i])

star_path.close_figure()

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, R * 2, R * 2)
    shape.set_geometry_path(star_path)

    presentation.save("custom_shape.pptx", slides.export.SaveFormat.PPTX)
```

![Forma personalizzata](custom_shape_3.png)

## **Creare forme personalizzate composite**

Creare una forma personalizzata composita ti consente di combinare più percorsi geometrici in un'unica forma riutilizzabile nella diapositiva. Definisci e unisci questi percorsi per costruire visualizzazioni complesse che vanno oltre il set di forme standard.

1. Crea un'istanza della classe [GeometryShape](https://reference.aspose.com/slides/it/python-net/aspose.slides/geometryshape/) .
2. Crea la prima istanza della classe [GeometryPath](https://reference.aspose.com/slides/it/python-net/aspose.slides/geometrypath/) .
3. Crea la seconda istanza della classe [GeometryPath](https://reference.aspose.com/slides/it/python-net/aspose.slides/geometrypath/) .
4. Applica entrambi i percorsi alla forma.

Il seguente codice Python mostra come creare una forma personalizzata composita:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 200, 100)

    geometry_path_0 = slides.GeometryPath()
    geometry_path_0.move_to(0, 0)
    geometry_path_0.line_to(shape.width, 0)
    geometry_path_0.line_to(shape.width, shape.height/3)
    geometry_path_0.line_to(0, shape.height / 3)
    geometry_path_0.close_figure()

    geometry_path_1 = slides.GeometryPath()
    geometry_path_1.move_to(0, shape.height/3 * 2)
    geometry_path_1.line_to(shape.width, shape.height / 3 * 2)
    geometry_path_1.line_to(shape.width, shape.height)
    geometry_path_1.line_to(0, shape.height)
    geometry_path_1.close_figure()

    shape.set_geometry_paths([ geometry_path_0, geometry_path_1])

    presentation.save("composite_shape.pptx", slides.export.SaveFormat.PPTX)
```

![Forma composita](custom_shape_4.png)

## **Creare forme personalizzate con angoli curvi**

Questa sezione mostra come disegnare una forma personalizzata con angoli curvi lisci usando un percorso geometrico. Combinerai segmenti dritti e archi circolari per formare il contorno e aggiungere la forma finita alla tua diapositiva.

Il seguente codice Python mostra come creare una forma personalizzata con angoli curvi:

```py
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

    shape = slide.shapes.add_auto_shape(
        slides.ShapeType.CUSTOM, shape_x, shape_y, shape_width, shape_height)

    point1 = draw.PointF(left_top_size, 0)
    point2 = draw.PointF(shape_width - right_top_size, 0)
    point3 = draw.PointF(shape_width, shape_height - right_bottom_size)
    point4 = draw.PointF(left_bottom_size, shape_height)
    point5 = draw.PointF(0, left_top_size)

    geometry_path = slides.GeometryPath()
    geometry_path.move_to(point1)
    geometry_path.line_to(point2)
    geometry_path.arc_to(right_top_size, right_top_size, 180, -90)
    geometry_path.line_to(point3)
    geometry_path.arc_to(right_bottom_size, right_bottom_size, -90, -90)
    geometry_path.line_to(point4)
    geometry_path.arc_to(left_bottom_size, left_bottom_size, 0, -90)
    geometry_path.line_to(point5)
    geometry_path.arc_to(left_top_size, left_top_size, 90, -90)
    geometry_path.close_figure()

    shape.set_geometry_path(geometry_path)

    presentation.save("curved_corners.pptx", slides.export.SaveFormat.PPTX)
```

![Angoli curvi](custom_shape_6.png)

## **Determinare se la geometria di una forma è chiusa**

Una forma chiusa è definita come quella in cui tutti i suoi lati sono collegati, formando un unico contorno senza spazi. Tale forma può essere una semplice figura geometrica o un contorno personalizzato complesso. Il seguente esempio di codice mostra come verificare se la geometria di una forma è chiusa:

```py
def is_geometry_closed(geometry_shape):
    is_closed = None

    for geometry_path in geometry_shape.get_geometry_paths():
        data_length = len(geometry_path.path_data)
        if data_length == 0:
            continue

        last_segment = geometry_path.path_data[data_length - 1]
        is_closed = last_segment.path_command == PathCommandType.CLOSE

        if not is_closed:
            return False

    return is_closed
```

## **FAQ**

**Cosa succederà al riempimento e al contorno dopo la sostituzione della geometria?**

Lo stile rimane sulla forma; solo il contorno cambia. Il riempimento e il contorno vengono applicati automaticamente alla nuova geometria.

**Come ruoto correttamente una forma personalizzata insieme alla sua geometria?**

Usa la proprietà [rotation](https://reference.aspose.com/slides/it/python-net/aspose.slides/geometryshape/rotation/) della forma; la geometria ruota con la forma perché è vincolata al sistema di coordinate della forma.

**Posso convertire una forma personalizzata in un'immagine per "bloccare" il risultato?**

Sì. Esporta l'area della [slide](/slides/it/python-net/convert-powerpoint-to-png/) richiesta o la [forma](/slides/it/python-net/create-shape-thumbnails/) stessa in un formato raster; questo semplifica ulteriori lavori con geometrie complesse.