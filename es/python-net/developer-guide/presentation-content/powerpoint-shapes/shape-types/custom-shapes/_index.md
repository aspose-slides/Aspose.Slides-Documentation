---
title: Forma personalizada
type: docs
weight: 20
url: /python-net/custom-shape/
keywords: "forma de PowerPoint, forma personalizada, presentación de PowerPoint, Python, Aspose.Slides para Python a través de .NET"
description: "Agrega una forma personalizada en una presentación de PowerPoint en Python"
---

# Cambiar una forma usando puntos de edición

Considera un cuadrado. En PowerPoint, utilizando **puntos de edición**, puedes 

* mover la esquina del cuadrado hacia adentro o hacia afuera
* especificar la curvatura para una esquina o punto
* agregar nuevos puntos al cuadrado
* manipular puntos en el cuadrado, etc.

Esencialmente, puedes realizar las tareas descritas en cualquier forma. Usando puntos de edición, puedes cambiar una forma o crear una nueva forma a partir de una forma existente. 

## Consejos para la edición de formas

![overview_image](custom_shape_0.png)

Antes de comenzar a editar formas de PowerPoint a través de puntos de edición, quizás quieras considerar estos puntos sobre las formas:

* Una forma (o su camino) puede ser cerrada o abierta.
* Cuando una forma está cerrada, no tiene un punto de inicio o fin. Cuando una forma está abierta, tiene un comienzo y un final.
* Todas las formas constan de al menos 2 puntos de anclaje vinculados entre sí por líneas.
* Una línea es recta o curva. Los puntos de anclaje determinan la naturaleza de la línea.
* Los puntos de anclaje existen como puntos de esquina, puntos rectos o puntos suaves:
  * Un punto de esquina es un punto donde 2 líneas rectas se unen en un ángulo.
  * Un punto suave es un punto donde 2 mangos existen en una línea recta y los segmentos de la línea se unen en una curva suave. En este caso, todos los mangos están separados del punto de anclaje por una distancia igual.
  * Un punto recto es un punto donde 2 mangos existen en una línea recta y los segmentos de esa línea se unen en una curva suave. En este caso, los mangos no tienen que estar separados del punto de anclaje por una distancia igual.
* Al mover o editar puntos de anclaje (lo que cambia el ángulo de las líneas), puedes cambiar la forma en que se ve una forma.

Para editar formas de PowerPoint a través de puntos de edición, **Aspose.Slides** proporciona la clase [**GeometryPath**](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) y la interfaz [**IGeometryPath**](https://reference.aspose.com/slides/python-net/aspose.slides/igeometrypath/).

* Una instancia de [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) representa un camino geométrico del objeto [IGeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/igeometryshape/).
* Para recuperar el `GeometryPath` de la instancia `IGeometryShape`, puedes usar el método [IGeometryShape.GetGeometryPaths](https://reference.aspose.com/slides/python-net/aspose.slides/igeometryshape/).
* Para establecer el `GeometryPath` para una forma, puedes usar estos métodos: [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/igeometryshape/) para *formas sólidas* y [IGeometryShape.SetGeometryPaths](https://reference.aspose.com/slides/python-net/aspose.slides/igeometryshape/) para *formas compuestas*.
* Para agregar segmentos, puedes usar los métodos bajo [IGeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/igeometrypath/).
* Usando las propiedades [IGeometryPath.Stroke](https://reference.aspose.com/slides/python-net/aspose.slides/igeometrypath/) y [IGeometryPath.FillMode](https://reference.aspose.com/slides/python-net/aspose.slides/igeometrypath/), puedes establecer la apariencia para un camino geométrico.
* Usando la propiedad [IGeometryPath.PathData](https://reference.aspose.com/slides/python-net/aspose.slides/igeometrypath/properties/pathdata), puedes recuperar el camino geométrico de una `GeometryShape` como un array de segmentos de camino.
* Para acceder a opciones adicionales de personalización de geometría de la forma, puedes convertir [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) a [GraphicsPath](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d?view=dotnet-plat-ext-5.0).
* Usa los métodos `GeometryPathToGraphicsPath` y `GraphicsPathToGeometryPath` (de la clase [ShapeUtil](https://reference.aspose.com/slides/python-net/aspose.slides.util/shapeutil/)) para convertir `GeometryPath` a `GraphicsPath` y viceversa.

## **Operaciones de edición simples**

Este código en Python te muestra cómo

**Agregar una línea** al final de un camino:

```py
line_to(point)
line_to(x, y)
```
**Agregar una línea** a una posición especificada en un camino:

```py    
line_to(point, index)
line_to(x, y, index)
```
**Agregar una curva de Bezier cúbica** al final de un camino:

```py
cubic_bezier_to(point1, point2, point3)
cubic_bezier_to(x1, y1, x2, y2, x3, y3)
```
**Agregar una curva de Bezier cúbica** a la posición especificada en un camino:

```py
cubic_bezier_to(point1, point2, point3, index)
cubic_bezier_to(x1, y1, x2, y2, x3, y3, index)
```
**Agregar una curva de Bezier cuadrática** al final de un camino:
```py
quadratic_bezier_to(point1, point2)
quadratic_bezier_to(x1, y1, x2, y2)
```
**Agregar una curva de Bezier cuadrática** a una posición especificada en un camino:

```py
quadratic_bezier_to(point1, point2, index)
quadratic_bezier_to(x1, y1, x2, y2, index)
```
**Agregar un arco dado** a un camino:
```py
arc_to(width, heigth, startAngle, sweepAngle)
```
**Cerrar la figura actual** de un camino:
```py
close_figure()
```
**Establecer la posición para el próximo punto**:
```py
move_to(point)
move_to(x, y)
```
**Eliminar el segmento del camino** en un índice dado:

```py
remove_at(index)
```
## Agregar puntos personalizados a la forma
1. Crea una instancia de la clase [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/) y establece el [ShapeType.Rectangle](https://reference.aspose.com/slides/python-net/aspose.slides/shapetype/).
2. Obtén una instancia de la clase [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) del objeto forma.
3. Agrega un nuevo punto entre los dos puntos superiores en el camino.
4. Agrega un nuevo punto entre los dos puntos inferiores en el camino.
6. Aplica el camino a la forma.

Este código en Python te muestra cómo agregar puntos personalizados a una forma:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 200, 100)
    geometryPath = shape.get_geometry_paths()[0]

    geometryPath.line_to(100, 50, 1)
    geometryPath.line_to(100, 50, 4)
    shape.set_geometry_path(geometryPath)
```

![example1_image](custom_shape_1.png)

## Eliminar puntos de una forma

1. Crea una instancia de la clase [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/) y establece el tipo [ShapeType.Heart](https://reference.aspose.com/slides/python-net/aspose.slides/shapetype/).
2. Obtén una instancia de la clase [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) del objeto forma.
3. Elimina el segmento para el camino.
4. Aplica el camino a la forma.

Este código en Python te muestra cómo eliminar puntos de una forma:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
	shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.HEART, 100, 100, 300, 300)

	path = shape.get_geometry_paths()[0]
	path.remove_at(2)
	shape.set_geometry_path(path)
```
![example2_image](custom_shape_2.png)

## Crear forma personalizada

1. Calcula los puntos para la forma.
2. Crea una instancia de la clase [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/).
3. Llena el camino con los puntos.
4. Crea una instancia de la clase [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/).
5. Aplica el camino a la forma.

Este código en Python te muestra cómo crear una forma personalizada:

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

starPath = slides.GeometryPath()
starPath.move_to(points[0])

for i in range(len(points)):
    starPath.line_to(points[i])

starPath.close_figure()

with slides.Presentation() as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, R * 2, R * 2)
    shape.set_geometry_path(starPath)
```
![example3_image](custom_shape_3.png)


## Crear forma personalizada compuesta

  1. Crea una instancia de la clase [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/).
  2. Crea una primera instancia de la clase [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/).
  3. Crea una segunda instancia de la clase [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/).
  4. Aplica los caminos a la forma.

Este código en Python te muestra cómo crear una forma personalizada compuesta:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 200, 100)

    geometryPath0 = slides.GeometryPath()
    geometryPath0.move_to(0, 0)
    geometryPath0.line_to(shape.width, 0)
    geometryPath0.line_to(shape.width, shape.height/3)
    geometryPath0.line_to(0, shape.height / 3)
    geometryPath0.close_figure()

    geometryPath1 = slides.GeometryPath()
    geometryPath1.move_to(0, shape.height/3 * 2)
    geometryPath1.line_to(shape.width, shape.height / 3 * 2)
    geometryPath1.line_to(shape.width, shape.height)
    geometryPath1.line_to(0, shape.height)
    geometryPath1.close_figure()

    shape.set_geometry_paths([ geometryPath0, geometryPath1])
```
![example4_image](custom_shape_4.png)

## **Crear una forma personalizada con esquinas redondeadas**

Este código en Python te muestra cómo crear una forma personalizada con esquinas redondeadas (hacia adentro):

```py
import aspose.slides as slides
import aspose.pydrawing as draw

shapeX = 20
shapeY = 20
shapeWidth = 300
shapeHeight = 200

leftTopSize = 50
rightTopSize = 20
rightBottomSize = 40
leftBottomSize = 10

with slides.Presentation() as presentation:
    childShape = presentation.slides[0].shapes.add_auto_shape(
        slides.ShapeType.CUSTOM, shapeX, shapeY, shapeWidth, shapeHeight)

    geometryPath = slides.GeometryPath()

    point1 = draw.PointF(leftTopSize, 0)
    point2 = draw.PointF(shapeWidth - rightTopSize, 0)
    point3 = draw.PointF(shapeWidth, shapeHeight - rightBottomSize)
    point4 = draw.PointF(leftBottomSize, shapeHeight)
    point5 = draw.PointF(0, leftTopSize)

    geometryPath.move_to(point1)
    geometryPath.line_to(point2)
    geometryPath.arc_to(rightTopSize, rightTopSize, 180, -90)
    geometryPath.line_to(point3)
    geometryPath.arc_to(rightBottomSize, rightBottomSize, -90, -90)
    geometryPath.line_to(point4)
    geometryPath.arc_to(leftBottomSize, leftBottomSize, 0, -90)
    geometryPath.line_to(point5)
    geometryPath.arc_to(leftTopSize, leftTopSize, 90, -90)

    geometryPath.close_figure()

    childShape.set_geometry_path(geometryPath)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## Conversión de GeometryPath a GraphicsPath (System.Drawing.Drawing2D) 

1. Crea una instancia de la clase [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/).
2. Crea una instancia de la clase [GrpahicsPath](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath?view=dotnet-plat-ext-5.0) del nombre de espacio [System.Drawing.Drawing2D](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d?view=dotnet-plat-ext-5.0).
3. Convierte la instancia de [GraphicsPath](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath?view=dotnet-plat-ext-5.0) a la instancia de [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) usando [ShapeUtil](https://reference.aspose.com/slides/python-net/aspose.slides.util/shapeutil/).
4. Aplica los caminos a la forma.

Este código en Python—una implementación de los pasos anteriores—demuestra el proceso de conversión de **GeometryPath** a **GraphicsPath**:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 300, 100)

    originalPath = shape.get_geometry_paths()[0]
    originalPath.fill_mode = slides.PathFillModeType.NONE

    gPath = draw.drawing2d.GraphicsPath()

    gPath.add_string("Texto en la forma", draw.FontFamily("Arial"), 1, 40, draw.PointF(10, 10), draw.StringFormat.generic_default)

    textPath = slides.util.ShapeUtil.graphics_path_to_geometry_path(gPath)
    textPath.fill_mode = slides.PathFillModeType.NORMAL

    shape.set_geometry_paths([originalPath, textPath])
```
![example5_image](custom_shape_5.png)