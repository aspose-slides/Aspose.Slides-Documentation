---
title: Forma Personalizada
type: docs
weight: 20
url: /net/custom-shape/
keywords: 
- forma
- forma personalizada
- crear forma
- geometría
- geometría de forma
- camino de geometría
- puntos de camino
- editar puntos
- PowerPoint
- presentación
- C#
- Aspose.Slides para .NET
description: "Agregar una forma personalizada a una presentación de PowerPoint en .NET"
---

## Cambiar una Forma Usando Puntos de Edición

Considera un cuadrado. En PowerPoint, usando **puntos de edición**, puedes 

* mover la esquina del cuadrado hacia dentro o hacia fuera
* especificar la curvatura de una esquina o punto
* agregar nuevos puntos al cuadrado
* manipular puntos en el cuadrado, etc. 

Esencialmente, puedes realizar las tareas descritas en cualquier forma. Usando puntos de edición, puedes cambiar una forma o crear una nueva forma a partir de una forma existente. 

## **Consejos de Edición de Formas**

![overview_image](custom_shape_0.png)

Antes de comenzar a editar las formas de PowerPoint a través de puntos de edición, puede que quieras considerar estos puntos sobre las formas:

* Una forma (o su camino) puede ser cerrada o abierta.
* Todas las formas consisten en al menos 2 puntos de ancla vinculados entre sí por líneas.
* Una línea es recta o curva. Los puntos de ancla determinan la naturaleza de la línea. 
* Los puntos de ancla existen como puntos de esquina, puntos rectos o puntos suaves:
  * Un punto de esquina es un punto donde 2 líneas rectas se unen en un ángulo. 
  * Un punto suave es un punto donde 2 manijas existen en una línea recta y los segmentos de la línea se unen en una curva suave. En este caso, todas las manijas están separadas del punto de ancla por una distancia igual. 
  * Un punto recto es un punto donde 2 manijas existen en una línea recta y los segmentos de esa línea se unen en una curva suave. En este caso, las manijas no tienen que estar separadas del punto de ancla por una distancia igual. 
* Al mover o editar puntos de ancla (lo que cambia el ángulo de las líneas), puedes cambiar la apariencia de una forma. 

Para editar formas de PowerPoint a través de puntos de edición, **Aspose.Slides** proporciona la clase [**GeometryPath**](https://reference.aspose.com/slides/net/aspose.slides/geometrypath) y la interfaz [**IGeometryPath**](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath). 

* Una [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath) representa un camino de geometría del objeto [IGeometryShape](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape). 
* Para recuperar la `GeometryPath` del `IGeometryShape`, puedes usar el método [IGeometryShape.GetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/methods/getgeometrypaths). 
* Para establecer el `GeometryPath` para una forma, puedes usar estos métodos: [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/methods/setgeometrypath) para *formas sólidas* y [IGeometryShape.SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/methods/setgeometrypaths) para *formas compuestas*.
* Para agregar segmentos, puedes usar los métodos bajo [IGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath). 
* Usando las propiedades [IGeometryPath.Stroke](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/properties/stroke) y [IGeometryPath.FillMode](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/properties/fillmode), puedes establecer la apariencia de un camino de geometría.
* Usando la propiedad [IGeometryPath.PathData](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/properties/pathdata), puedes recuperar el camino de geometría de un `GeometryShape` como una matriz de segmentos de camino. 
* Para acceder a opciones adicionales de personalización de geometría de formas, puedes convertir [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath) a [GraphicsPath](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d?view=dotnet-plat-ext-5.0)
* Usa los métodos [GeometryPathToGraphicsPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/methods/geometrypathtographicspath) y [GraphicsPathToGeometryPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/methods/graphicspathtogeometrypath) (de la clase [ShapeUtil](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil)) para convertir [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath) a [GraphicsPath](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d?view=dotnet-plat-ext-5.0) y viceversa. 

## **Operaciones de Edición Simples**

Este código C# te muestra cómo

**Agregar una línea** al final de un camino

``` csharp
void LineTo(PointF point);
void LineTo(float x, float y);
```
**Agregar una línea** a una posición especificada en un camino:

``` csharp    
void LineTo(PointF point, uint index);
void LineTo(float x, float y, uint index);
```
**Agregar una curva Bezier cúbica** al final de un camino:

``` csharp
void CubicBezierTo(PointF point1, PointF point2, PointF point3);
void CubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3);
```
**Agregar una curva Bezier cúbica** a la posición especificada en un camino:

``` csharp
void CubicBezierTo(PointF point1, PointF point2, PointF point3, uint index);
void CubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3, uint index);
```
**Agregar una curva Bezier cuadrática** al final de un camino:

``` csharp
void QuadraticBezierTo(PointF point1, PointF point2);
void QuadraticBezierTo(float x1, float y1, float x2, float y2);
```
**Agregar una curva Bezier cuadrática** a una posición especificada en un camino:

``` csharp
void QuadraticBezierTo(PointF point1, PointF point2, uint index);
void QuadraticBezierTo(float x1, float y1, float x2, float y2, uint index);
```
**Agregar un arco** a un camino:

``` csharp
void ArcTo(float width, float heigth, float startAngle, float sweepAngle);
```
**Cerrar la figura actual** de un camino:

``` csharp
void CloseFigure();
```
**Establecer la posición para el siguiente punto**:

``` csharp
void MoveTo(PointF point);
void MoveTo(float x, float y);
```
**Eliminar el segmento de camino** en un índice dado:

``` csharp
void RemoveAt(int index);
```

## **Agregar Puntos Personalizados a la Forma**

1. Crea una instancia de la clase [GeometryShape](https://reference.aspose.com/slides/net/aspose.slides/geometryshape) y establece el tipo [ShapeType.Rectangle](https://reference.aspose.com/slides/net/aspose.slides/shapetype).
2. Obtén una instancia de la clase [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath) de la forma.
3. Agrega un nuevo punto entre los dos puntos superiores en el camino.
4. Agrega un nuevo punto entre los dos puntos inferiores en el camino.
5. Aplica el camino a la forma.

Este código C# te muestra cómo agregar puntos personalizados a una forma:

``` csharp
using (Presentation pres = new Presentation())
{
    GeometryShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100) as GeometryShape;
    IGeometryPath geometryPath = shape.GetGeometryPaths()[0];

    geometryPath.LineTo(100, 50, 1);
    geometryPath.LineTo(100, 50, 4);
    shape.SetGeometryPath(geometryPath);
}
```

![example1_image](custom_shape_1.png)

##  **Eliminar Puntos de la Forma**

1. Crea una instancia de la clase [GeometryShape](https://reference.aspose.com/slides/net/aspose.slides/geometryshape) y establece el tipo [ShapeType.Heart](https://reference.aspose.com/slides/net/aspose.slides/shapetype). 
2. Obtén una instancia de la clase [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath) de la forma.
3. Elimina el segmento del camino.
4. Aplica el camino a la forma.

Este código C# te muestra cómo eliminar puntos de una forma:

``` csharp
using (Presentation pres = new Presentation())
{
    GeometryShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Heart, 100, 100, 300, 300) as GeometryShape;

    IGeometryPath path = shape.GetGeometryPaths()[0];
    path.RemoveAt(2);
    shape.SetGeometryPath(path);
}
```
![example2_image](custom_shape_2.png)

##  **Crear Forma Personalizada**

1. Calcula los puntos para la forma.
2. Crea una instancia de la clase [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath). 
3. Llena el camino con los puntos.
4. Crea una instancia de la clase [GeometryShape](https://reference.aspose.com/slides/net/aspose.slides/geometryshape). 
5. Aplica el camino a la forma.

Este código C# te muestra cómo crear una forma personalizada:

``` csharp
List<PointF> points = new List<PointF>();

float R = 100, r = 50;
int step = 72;

for (int angle = -90; angle < 270; angle += step)
{
    double radians = angle * (Math.PI / 180f);
    double x = R * Math.Cos(radians);
    double y = R * Math.Sin(radians);
    points.Add(new PointF((float)x + R, (float)y + R));

    radians = Math.PI * (angle + step / 2) / 180.0;
    x = r * Math.Cos(radians);
    y = r * Math.Sin(radians);
    points.Add(new PointF((float)x + R, (float)y + R));
}

GeometryPath starPath = new GeometryPath();
starPath.MoveTo(points[0]);

for (int i = 1; i < points.Count; i++)
{
    starPath.LineTo(points[i]);
}

starPath.CloseFigure();

using (Presentation pres = new Presentation())
{
    GeometryShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, R * 2, R * 2) as GeometryShape;

    shape.SetGeometryPath(starPath);
}
```
![example3_image](custom_shape_3.png)

## **Crear Forma Personalizada Compuesta**

1. Crea una instancia de la clase [GeometryShape](https://reference.aspose.com/slides/net/aspose.slides/geometryshape).
2. Crea una primera instancia de la clase [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath).
3. Crea una segunda instancia de la clase [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath).
4. Aplica los caminos a la forma.

Este código C# te muestra cómo crear una forma personalizada compuesta:

``` csharp
using (Presentation pres = new Presentation())
{
    GeometryShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100) as GeometryShape;

    GeometryPath geometryPath0 = new GeometryPath();
    geometryPath0.MoveTo(0, 0);
    geometryPath0.LineTo(shape.Width, 0);
    geometryPath0.LineTo(shape.Width, shape.Height/3);
    geometryPath0.LineTo(0, shape.Height / 3);
    geometryPath0.CloseFigure();

    GeometryPath geometryPath1 = new GeometryPath();
    geometryPath1.MoveTo(0, shape.Height/3 * 2);
    geometryPath1.LineTo(shape.Width, shape.Height / 3 * 2);
    geometryPath1.LineTo(shape.Width, shape.Height);
    geometryPath1.LineTo(0, shape.Height);
    geometryPath1.CloseFigure();

    shape.SetGeometryPaths(new GeometryPath[] { geometryPath0, geometryPath1});
}
```
![example4_image](custom_shape_4.png)

## **Crear Forma Personalizada con Esquinas Curvadas**

Este código C# te muestra cómo crear una forma personalizada con esquinas curvadas (hacia adentro):

```c#
var shapeX = 20f;
var shapeY = 20f;
var shapeWidth = 300f;
var shapeHeight = 200f;

var leftTopSize = 50f;
var rightTopSize = 20f;
var rightBottomSize = 40f;
var leftBottomSize = 10f;

using (var presentation = new Presentation())
{
    var childShape = presentation.Slides[0].Shapes.AddAutoShape(
        ShapeType.Custom, shapeX, shapeY, shapeWidth, shapeHeight);

    var geometryPath = new GeometryPath();

    var point1 = new PointF(leftTopSize, 0);
    var point2 = new PointF(shapeWidth - rightTopSize, 0);
    var point3 = new PointF(shapeWidth, shapeHeight - rightBottomSize);
    var point4 = new PointF(leftBottomSize, shapeHeight);
    var point5 = new PointF(0, leftTopSize);

    geometryPath.MoveTo(point1);
    geometryPath.LineTo(point2);
    geometryPath.ArcTo(rightTopSize, rightTopSize, 180, -90);
    geometryPath.LineTo(point3);
    geometryPath.ArcTo(rightBottomSize, rightBottomSize, -90, -90);
    geometryPath.LineTo(point4);
    geometryPath.ArcTo(leftBottomSize, leftBottomSize, 0, -90);
    geometryPath.LineTo(point5);
    geometryPath.ArcTo(leftTopSize, leftTopSize, 90, -90);

    geometryPath.CloseFigure();

    childShape.SetGeometryPath(geometryPath);

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Descubrir Si la Geometría de una Forma Está Cerrada**

Verificar si una forma en una presentación de PowerPoint está cerrada puede ser crucial para la correcta visualización y edición de objetos en las diapositivas. Una forma cerrada se define como aquella donde todos sus lados se conectan, formando un único límite sin huecos. Tal forma puede ser una forma geométrica simple o un contorno personalizado complejo.

La cerradura de una forma es importante para realizar varias operaciones, como rellenar con color o degradado, aplicar efectos y transformaciones, y asegurar una adecuada interacción con otros elementos de la diapositiva.

Para verificar si la geometría de una forma está cerrada, necesitas hacer lo siguiente:
1. Obtener acceso a la geometría de la forma.
2. Enumerar los caminos de geometría en la forma.
    2.1. Obtener el último segmento del siguiente camino.
    2.2. Verificar si el último segmento es el comando `CLOSE`.

El siguiente ejemplo de código muestra cómo hacer esto:

```cs
if (shape is GeometryShape geometryShape)
{
    for (int i = 0; i < geometryShape.GetGeometryPaths().Length; i++)
    {
        IGeometryPath path = geometryShape.GetGeometryPaths()[i];

        if (path.PathData.Length == 0) continue;

        IPathSegment lastSegment = path.PathData[path.PathData.Length - 1];
        bool isClosed = lastSegment.PathCommand == PathCommandType.Close;
        
        Console.WriteLine($"El camino {i} está cerrado: {isClosed}");
    }
}
```

## **Convertir GeometryPath a GraphicsPath (System.Drawing.Drawing2D)** 

1. Crea una instancia de la clase [GeometryShape](https://reference.aspose.com/slides/net/aspose.slides/geometryshape).
2. Crea una instancia de la clase [GraphicsPath](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath?view=dotnet-plat-ext-5.0) del espacio de nombres [System.Drawing.Drawing2D](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d?view=dotnet-plat-ext-5.0).
3. Convierte la instancia de [GraphicsPath](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath?view=dotnet-plat-ext-5.0) a la instancia de [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath) usando [ShapeUtil](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil).
4. Aplica los caminos a la forma.

Este código C#—una implementación de los pasos anteriores—demuestra el proceso de conversión de **GeometryPath** a **GraphicsPath**:

``` csharp
using (Presentation pres = new Presentation())
{
    GeometryShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 100) as GeometryShape;

    IGeometryPath originalPath = shape.GetGeometryPaths()[0];
    originalPath.FillMode = PathFillModeType.None;

    GraphicsPath gPath = new GraphicsPath();

    gPath.AddString("Texto en la forma", new FontFamily("Arial"), 1, 40, new PointF(10, 10), StringFormat.GenericDefault);

    IGeometryPath textPath = ShapeUtil.GraphicsPathToGeometryPath(gPath);
    textPath.FillMode = PathFillModeType.Normal;

    shape.SetGeometryPaths(new[] {originalPath, textPath}) ;
}
```
![example5_image](custom_shape_5.png)