---
title: Personalizar formas de presentación en Python mediante Java
linktitle: Forma personalizada
type: docs
weight: 20
url: /es/python-java/custom-shape/
keywords:
- forma personalizada
- añadir forma
- crear forma
- cambiar forma
- geometría de forma
- ruta de geometría
- puntos de ruta
- puntos de edición
- añadir punto
- eliminar punto
- operación de edición
- esquina curva
- PowerPoint
- presentación
- Python
- Aspose.Slides
description: "Crea y personaliza formas en presentaciones de PowerPoint con Aspose.Slides para Python mediante Java: rutas de geometría, esquinas curvas, formas compuestas."
---
## **Visión general**

Este artículo explica cómo personalizar las formas de presentación en Aspose.Slides editando la geometría de la forma mediante puntos de edición y rutas de geometría. Muestra cómo trabajar con [GeometryPath](https://reference.aspose.com/slides/es/python-java/aspose.slides/geometrypath/) para modificar formas existentes, realizar operaciones básicas de edición de rutas, añadir o eliminar puntos y aplicar la geometría actualizada a una forma.

También demuestra cómo crear formas personalizadas y compuestas, construir formas con esquinas curvas, determinar si la geometría de una forma está cerrada y convertir entre [GeometryPath](https://reference.aspose.com/slides/es/python-java/aspose.slides/geometrypath/) y [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) para escenarios adicionales de personalización de geometría.

## **Cambiar una forma mediante puntos de edición**

Considere un cuadrado. En PowerPoint, usando **puntos de edición**, puede  

* mover la esquina del cuadrado hacia dentro o fuera  
* especificar la curvatura de una esquina o punto  
* añadir nuevos puntos al cuadrado  
* manipular los puntos del cuadrado, etc.  

En esencia, puede realizar las tareas descritas en cualquier forma. Con los puntos de edición, puede modificar una forma o crear una nueva forma a partir de una forma existente. 

## **Consejos para la edición de formas**

![overview_image](custom_shape_0.png)

Antes de comenzar a editar formas de PowerPoint mediante puntos de edición, puede que desee considerar los siguientes aspectos sobre las formas:

* Una forma (o su ruta) puede ser cerrada o abierta.  
* Cuando una forma es cerrada, carece de punto de inicio o fin. Cuando es abierta, tiene un comienzo y un final.  
* Todas las formas constan de al menos 2 puntos de anclaje vinculados entre sí por líneas.  
* Una línea puede ser recta o curva. Los puntos de anclaje determinan la naturaleza de la línea.  
* Los puntos de anclaje existen como puntos de esquina, puntos rectos o puntos suaves:  
  * Un punto de esquina es un punto donde se unen 2 líneas rectas formando un ángulo.  
  * Un punto suave es un punto donde existen 2 manejadores en una línea recta y los segmentos de la línea se unen en una curva suave. En este caso, todos los manejadores están separados del punto de anclaje por una distancia igual.  
  * Un punto recto es un punto donde existen 2 manejadores en una línea recta y los segmentos de esa línea se unen en una curva suave. En este caso, los manejadores no tienen que estar separados del punto de anclaje por una distancia igual.  
* Al mover o editar los puntos de anclaje (lo que cambia el ángulo de las líneas), puedes modificar la apariencia de una forma.  

Para editar formas de PowerPoint mediante puntos de edición, **Aspose.Slides** proporciona la clase [GeometryPath](https://reference.aspose.com/slides/es/python-java/aspose.slides/geometrypath/).  

* Una instancia de [GeometryPath](https://reference.aspose.com/slides/es/python-java/aspose.slides/geometrypath/) representa una ruta de geometría del objeto [GeometryShape](https://reference.aspose.com/slides/es/python-java/aspose.slides/geometryshape/).  
* Para obtener el [GeometryPath](https://reference.aspose.com/slides/es/python-java/aspose.slides/geometrypath/) del instancia de [GeometryShape](https://reference.aspose.com/slides/es/python-java/aspose.slides/geometryshape/) puedes usar el método [GeometryShape.getGeometryPaths](https://reference.aspose.com/slides/es/python-java/aspose.slides/geometryshape/#getGeometryPaths).  
* Para establecer el [GeometryPath](https://reference.aspose.com/slides/es/python-java/aspose.slides/geometrypath/) de una forma, puedes usar estos métodos: [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/es/python-java/aspose.slides/geometryshape/#setGeometryPath) para *formas sólidas* y [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/es/python-java/aspose.slides/geometryshape/#setGeometryPaths) para *formas compuestas*.  
* Para añadir segmentos, puedes usar los métodos bajo [GeometryPath](https://reference.aspose.com/slides/es/python-java/aspose.slides/geometrypath/).  
* Usando los métodos [GeometryPath.setStroke](https://reference.aspose.com/slides/es/python-java/aspose.slides/geometrypath/#setStroke) y [GeometryPath.setFillMode](https://reference.aspose.com/slides/es/python-java/aspose.slides/geometrypath/#setFillMode), puedes establecer la apariencia de una ruta de geometría.  
* Con el método [GeometryPath.getPathData](https://reference.aspose.com/slides/es/python-java/aspose.slides/geometrypath/#getPathData) puedes obtener la ruta de geometría de un [GeometryShape](https://reference.aspose.com/slides/es/python-java/aspose.slides/geometryshape/) como una matriz de segmentos de ruta.  
* Para acceder a opciones adicionales de personalización de la geometría de la forma, puedes convertir [GeometryPath](https://reference.aspose.com/slides/es/python-java/aspose.slides/geometrypath/) a [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html).  
* Utiliza los métodos [geometryPathToGraphicsPath](https://reference.aspose.com/slides/es/python-java/aspose.slides/shapeutil/) y [graphicsPathToGeometryPath](https://reference.aspose.com/slides/es/python-java/aspose.slides/shapeutil/) (de la clase [ShapeUtil](https://reference.aspose.com/slides/es/python-java/aspose.slides/shapeutil/)) para convertir [GeometryPath](https://reference.aspose.com/slides/es/python-java/aspose.slides/geometrypath/) a [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) y viceversa.  

## **Operaciones de edición simples**

Las siguientes firmas muestran las operaciones básicas de edición:

**Añadir una línea** al final de una ruta:

- `geometry_path.lineTo(point)`
- `geometry_path.lineTo(x, y)`

**Añadir una línea** a una posición especificada en una ruta:

- `geometry_path.lineTo(point, index)`
- `geometry_path.lineTo(x, y, index)`

**Añadir una curva cúbica Bézier** al final de una ruta:

- `geometry_path.cubicBezierTo(point1, point2, point3)`
- `geometry_path.cubicBezierTo(x1, y1, x2, y2, x3, y3)`

**Añadir una curva cúbica Bézier** a una posición especificada en una ruta:

- `geometry_path.cubicBezierTo(point1, point2, point3, index)`
- `geometry_path.cubicBezierTo(x1, y1, x2, y2, x3, y3, index)`

**Añadir una curva cuadrática Bézier** al final de una ruta:

- `geometry_path.quadraticBezierTo(point1, point2)`
- `geometry_path.quadraticBezierTo(x1, y1, x2, y2)`

**Añadir una curva cuadrática Bézier** a una posición especificada en una ruta:

- `geometry_path.quadraticBezierTo(point1, point2, index)`
- `geometry_path.quadraticBezierTo(x1, y1, x2, y2, index)`

**Añadir un arco dado** a una ruta:

- `geometry_path.arcTo(width, height, start_angle, sweep_angle)`

**Cerrar la figura actual** de una ruta:

- `geometry_path.closeFigure()`

**Establecer la posición del siguiente punto**:

- `geometry_path.moveTo(point)`
- `geometry_path.moveTo(x, y)`

**Eliminar el segmento de ruta** en un índice dado:

- `geometry_path.removeAt(index)`


## **Añadir puntos personalizados a una forma**
1. Crea una instancia de la clase [GeometryShape](https://reference.aspose.com/slides/es/python-java/aspose.slides/geometryshape/) y establece el tipo [ShapeType.Rectangle](https://reference.aspose.com/slides/es/python-java/aspose.slides/shapetype/#Rectangle).  
2. Obtén una instancia de la clase [GeometryPath](https://reference.aspose.com/slides/es/python-java/aspose.slides/geometrypath/) a partir de la forma.  
3. Añade un nuevo punto entre los dos puntos superiores de la ruta.  
4. Añade un nuevo punto entre los dos puntos inferiores de la ruta.  
5. Aplica la ruta a la forma.  

Este código Python muestra cómo añadir puntos personalizados a una forma:

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

## **Eliminar puntos de una forma**

1. Crea una instancia de la clase [GeometryShape](https://reference.aspose.com/slides/es/python-java/aspose.slides/geometryshape/) y establece el tipo [ShapeType.Heart](https://reference.aspose.com/slides/es/python-java/aspose.slides/shapetype/#Heart).  
2. Obtén una instancia de la clase [GeometryPath](https://reference.aspose.com/slides/es/python-java/aspose.slides/geometrypath/) a partir de la forma.  
3. Elimina el segmento de la ruta.  
4. Aplica la ruta a la forma.  

Este código Python muestra cómo eliminar puntos de una forma:

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

## **Crear una forma personalizada**

1. Calcula los puntos para la forma.  
2. Crea una instancia de la clase [GeometryPath](https://reference.aspose.com/slides/es/python-java/aspose.slides/geometrypath/).  
3. Rellena la ruta con los puntos.  
4. Crea una instancia de la clase [GeometryShape](https://reference.aspose.com/slides/es/python-java/aspose.slides/geometryshape/).  
5. Aplica la ruta a la forma.  

Este código Python muestra cómo crear una forma personalizada:

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


## **Crear una forma compuesta personalizada**

1. Crea una instancia de la clase [GeometryShape](https://reference.aspose.com/slides/es/python-java/aspose.slides/geometryshape/).  
2. Crea una primera instancia de la clase [GeometryPath](https://reference.aspose.com/slides/es/python-java/aspose.slides/geometrypath/).  
3. Crea una segunda instancia de la clase [GeometryPath](https://reference.aspose.com/slides/es/python-java/aspose.slides/geometrypath/).  
4. Aplica las rutas a la forma.  

Este código Python muestra cómo crear una forma compuesta personalizada:

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

## **Crear una forma personalizada con esquinas curvas**

Este código Python muestra cómo crear una forma personalizada con esquinas curvas (hacia dentro):

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

## **Descubrir si la geometría de una forma está cerrada**

Una forma cerrada se define como aquella en la que todos sus lados se conectan, formando un único contorno sin huecos. Esa forma puede ser una figura geométrica simple o un contorno personalizado complejo. El siguiente ejemplo de código muestra cómo comprobar si la geometría de una forma está cerrada:

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

## **Convertir GeometryPath a java.awt.Shape**

1. Crea una instancia de la clase [GeometryShape](https://reference.aspose.com/slides/es/python-java/aspose.slides/geometryshape/).  
2. Crea una instancia de la clase [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html).  
3. Convierte la instancia de [java.awt Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) a la instancia [GeometryPath](https://reference.aspose.com/slides/es/python-java/aspose.slides/geometrypath/) recorriendo su [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) y reproduciendo cada segmento en la ruta.  
4. Aplica las rutas a la forma.  

Este código Python implementa los pasos anteriores para convertir una ruta gráfica a una ruta de geometría:

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
    # Crear una nueva forma.
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 100)

    # Obtener la ruta de geometría de la forma.
    original_path = shape.getGeometryPaths()[0]
    original_path.setFillMode(PathFillModeType.None_)

    # Crear una nueva ruta gráfica con texto.
    font = Font("Arial", Font.PLAIN, 40)
    text = "Text in shape"
    image = BufferedImage(100, 100, BufferedImage.TYPE_INT_ARGB)
    graphics = image.createGraphics()
    try:
        glyph_vector = font.createGlyphVector(graphics.getFontRenderContext(), text)
        graphics_path = glyph_vector.getOutline(20.0, -glyph_vector.getVisualBounds().getY() + 10)
    finally:
        graphics.dispose()

    # Convertir la ruta gráfica a una ruta de geometría.
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

    # Aplicar la ruta de texto junto con la ruta de geometría original.
    shape.setGeometryPaths([original_path, text_path])
finally:
    presentation.dispose()
```
![example5_image](custom_shape_5.png)

## **Preguntas frecuentes**

**¿Qué ocurrirá con el relleno y el contorno después de reemplazar la geometría?**

El estilo permanece con la forma; solo cambia el contorno. El relleno y el contorno se aplican automáticamente a la nueva geometría.

**¿Cómo rotar correctamente una forma personalizada junto con su geometría?**

Utiliza el método [setRotation](https://reference.aspose.com/slides/es/python-java/aspose.slides/shape/#setRotation) de la forma; la geometría gira con la forma porque está vinculada al propio sistema de coordenadas de la forma.

**¿Puedo convertir una forma personalizada en una imagen para "bloquear" el resultado?**

Sí. Exporta la zona de la [slide](/slides/es/python-java/convert-powerpoint-to-png/) requerida o la propia [shape](/slides/es/python-java/create-shape-thumbnails/) a un formato raster; esto simplifica el trabajo posterior con geometrías complejas.