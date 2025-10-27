---
title: Personalizar formas en presentaciones con Python
linktitle: Forma personalizada
type: docs
weight: 20
url: /es/python-net/developer-guide/presentation-content/powerpoint-shapes/shape-types/custom-shapes/
keywords: 
- forma personalizada
- agregar forma
- crear forma
- cambiar forma
- geometría de forma
- ruta de geometría
- puntos de ruta
- editar puntos
- agregar punto
- eliminar punto
- operación de edición
- esquina curva
- PowerPoint
- OpenDocument
- presentación
- Python
- Aspose.Slides
description: "Cree y personalice formas en presentaciones de PowerPoint y OpenDocument con Aspose.Slides para Python vía .NET: rutas de geometría, esquinas curvas, formas compuestas."
---

## **Visión general**

Considere un cuadrado. En PowerPoint, usando **Editar puntos**, puede:

* mover la esquina de un cuadrado hacia adentro o hacia afuera,
* ajustar la curvatura de una esquina o punto,
* agregar nuevos puntos al cuadrado,
* manipular sus puntos.

Puede aplicar estas operaciones a cualquier forma. Con **Editar puntos**, puede modificar una forma o crear una nueva a partir de una forma existente.

## **Consejos para editar formas**

!["Edit Points" command](custom_shape_0.png)

Antes de comenzar a editar formas de PowerPoint usando **Editar puntos**, tenga en cuenta estas notas sobre las formas:

* Una forma (o su ruta) puede ser **cerrada** o **abierta**.
* Una forma cerrada no tiene punto de inicio ni final; una forma abierta tiene un comienzo y un fin.
* Cada forma tiene al menos dos puntos de anclaje conectados por segmentos de línea.
* Un segmento es recto o curvo; los puntos de anclaje determinan la naturaleza del segmento.
* Los puntos de anclaje pueden ser **esquina**, **suave** o **recto**:
  * Un punto **esquina** es donde se encuentran dos segmentos rectos en un ángulo.
  * Un punto **suave** tiene dos manejadores colineales y los segmentos adyacentes forman una curva suave. En este caso, ambos manejadores están a la misma distancia del punto de anclaje.
  * Un punto **recto** también tiene dos manejadores colineales y los segmentos adyacentes forman una curva suave. En este caso, los manejadores no tienen que estar a la misma distancia del punto de anclaje.
* Al mover o editar los puntos de anclaje (cambiando así los ángulos de los segmentos), puede alterar la apariencia de la forma.

Para editar formas de PowerPoint, Aspose.Slides proporciona la clase [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/).

* Una instancia de [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) representa la ruta de geometría de un objeto [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/).
* Para obtener el [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) de una instancia de [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/), utilice el método [GeometryShape.get_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/get_geometry_paths/).
* Para establecer el [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) de una forma, use [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/) para *formas sólidas* y [GeometryShape.set_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_paths/) para *formas compuestas*.
* Para agregar segmentos, use los métodos de [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/).
* Utilice las propiedades [GeometryPath.stroke](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/stroke/) y [GeometryPath.fill_mode](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/fill_mode/) para controlar la apariencia de una ruta de geometría.
* Use la propiedad [GeometryPath.path_data](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/path_data/) para obtener la ruta de geometría de una forma como una matriz de segmentos de ruta.

## **Operaciones de edición simples**

Los siguientes métodos se utilizan para operaciones de edición simples.

**Agregar una línea** al final de una ruta:

```py
line_to(point)
line_to(x, y)
```

**Agregar una línea** en una posición especificada de una ruta:

```py    
line_to(point, index)
line_to(x, y, index)
```

**Agregar una curva cúbica de Bézier** al final de una ruta:

```py
cubic_bezier_to(point1, point2, point3)
cubic_bezier_to(x1, y1, x2, y2, x3, y3)
```

**Agregar una curva cúbica de Bézier** en una posición especificada de una ruta:

```py
cubic_bezier_to(point1, point2, point3, index)
cubic_bezier_to(x1, y1, x2, y2, x3, y3, index)
```

**Agregar una curva cuadrática de Bézier** al final de una ruta:

```py
quadratic_bezier_to(point1, point2)
quadratic_bezier_to(x1, y1, x2, y2)
```

**Agregar una curva cuadrática de Bézier** en una posición especificada de una ruta:

```py
quadratic_bezier_to(point1, point2, index)
quadratic_bezier_to(x1, y1, x2, y2, index)
```

**Agregar un arco** a una ruta:

```py
arc_to(width, heigth, startAngle, sweepAngle)
```

**Cerrar la figura actual** en una ruta:

```py
close_figure()
```

**Establecer la posición del siguiente punto**:

```py
move_to(point)
move_to(x, y)
```

**Eliminar el segmento de ruta** en un índice dado:

```py
remove_at(index)
```

## **Agregar puntos personalizados a formas**

Aquí aprenderá cómo definir una forma libre agregando su propia secuencia de puntos. Al especificar puntos ordenados y tipos de segmento (recto o curvo) y, opcionalmente, cerrar la ruta, puede dibujar gráficos personalizados precisos—polígonos, íconos, llamadas o logotipos—directamente en sus diapositivas.

1. Cree una instancia de la clase [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/) y establezca su [ShapeType.RECTANGLE](https://reference.aspose.com/slides/python-net/aspose.slides/shapetype/).
2. Obtenga una instancia de [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) de la forma.
3. Inserte un nuevo punto entre los dos puntos superiores de la ruta.
4. Inserte un nuevo punto entre los dos puntos inferiores de la ruta.
5. Aplique la ruta actualizada a la forma.

El siguiente código Python muestra cómo agregar puntos personalizados a una forma:

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

![Puntos personalizados](custom_shape_1.png)

## **Eliminar puntos de formas**

A veces una forma personalizada contiene puntos innecesarios que complican su geometría o afectan su renderizado. Esta sección muestra cómo eliminar puntos específicos de la ruta de una forma para simplificar el contorno y lograr resultados más limpios y precisos.

1. Cree una instancia de la clase [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/) y establezca su tipo [ShapeType.HEART](https://reference.aspose.com/slides/python-net/aspose.slides/shapetype/).
2. Obtenga una instancia de [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) de la forma.
3. Elimine un segmento de la ruta.
4. Aplique la ruta actualizada a la forma.

El siguiente código Python muestra cómo eliminar puntos de una forma:

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

![Puntos eliminados](custom_shape_2.png)

## **Crear formas personalizadas**

Cree formas vectoriales a medida definiendo un [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) y componiéndolo a partir de líneas, arcos y curvas Bézier. Esta sección muestra cómo construir una geometría personalizada desde cero y agregar la forma resultante a su diapositiva.

1. Calcule los puntos de la forma.
2. Cree una instancia de la clase [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/).
3. Complete la ruta con los puntos.
4. Cree una instancia de la clase [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/).
5. Aplique la ruta a la forma.

El siguiente código Python muestra cómo crear una forma personalizada:

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

![Forma personalizada](custom_shape_3.png)

## **Crear formas personalizadas compuestas**

Crear una forma personalizada compuesta le permite combinar múltiples rutas de geometría en una sola forma reutilizable en una diapositiva. Defina y fusione estas rutas para construir visuales complejos que van más allá del conjunto de formas estándar.

1. Cree una instancia de la clase [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/).
2. Cree la primera instancia de la clase [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/).
3. Cree la segunda instancia de la clase [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/).
4. Aplique ambas rutas a la forma.

El siguiente código Python muestra cómo crear una forma personalizada compuesta:

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

![Forma compuesta](custom_shape_4.png)

## **Crear formas personalizadas con esquinas curvas**

Esta sección muestra cómo dibujar una forma personalizada con esquinas suavemente curvadas usando una ruta de geometría. Combinará segmentos rectos y arcos circulares para formar el contorno y añadirá la forma terminada a su diapositiva.

El siguiente código Python muestra cómo crear una forma personalizada con esquinas curvas:

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

![Esquinas curvas](custom_shape_6.png)

## **Determinar si la geometría de una forma está cerrada**

Una forma cerrada se define como aquella en la que todos sus lados se conectan, formando un único contorno sin huecos. Tal forma puede ser una figura geométrica simple o un contorno personalizado complejo. El siguiente ejemplo de código muestra cómo comprobar si la geometría de una forma está cerrada:

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

## **Preguntas frecuentes**

**¿Qué sucederá con el relleno y el contorno después de reemplazar la geometría?**

El estilo permanece con la forma; solo cambia el contorno. El relleno y el contorno se aplican automáticamente a la nueva geometría.

**¿Cómo rotar correctamente una forma personalizada junto con su geometría?**

Utilice la propiedad de [rotación](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/rotation/) de la forma; la geometría rota con la forma porque está vinculada al propio sistema de coordenadas de la forma.

**¿Puedo convertir una forma personalizada en una imagen para “bloquear” el resultado?**

Sí. Exporte el área de la [diapositiva](/slides/es/python-net/convert-powerpoint-to-png/) requerida o la propia [forma](/slides/es/python-net/create-shape-thumbnails/) a un formato raster; esto simplifica el trabajo posterior con geometrías pesadas.