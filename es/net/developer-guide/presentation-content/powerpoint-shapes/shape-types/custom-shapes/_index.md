---
title: Personalizar formas de presentación en .NET
linktitle: Forma personalizada
type: docs
weight: 20
url: /es/net/custom-shape/
keywords:
- forma personalizada
- agregar forma
- crear forma
- cambiar forma
- geometría de forma
- ruta de geometría
- puntos de ruta
- puntos de edición
- agregar punto
- eliminar punto
- operación de edición
- esquina curva
- PowerPoint
- presentación
- .NET
- C#
- Aspose.Slides
description: "Cree y personalice formas en presentaciones de PowerPoint con Aspose.Slides para .NET: rutas de geometría, esquinas curvas, formas compuestas."
---

## **Cambiar una forma usando puntos de edición**

Considere un cuadrado. En PowerPoint, usando **puntos de edición**, puede

* mover la esquina del cuadrado hacia adentro o hacia afuera
* especificar la curvatura de una esquina o punto
* agregar nuevos puntos al cuadrado
* manipular puntos del cuadrado, etc.

Básicamente, puede realizar las tareas descritas en cualquier forma. Con los puntos de edición, puede cambiar una forma o crear una nueva a partir de una forma existente.

## **Consejos para editar formas**

![overview_image](custom_shape_0.png)

Antes de comenzar a editar formas de PowerPoint mediante puntos de edición, considere los siguientes aspectos sobre las formas:

* Una forma (o su ruta) puede estar cerrada o abierta.  
* Todas las formas constan de al menos 2 puntos de anclaje vinculados entre sí por líneas.  
* Una línea es recta o curva. Los puntos de anclaje determinan la naturaleza de la línea.  
* Los puntos de anclaje existen como puntos de esquina, puntos rectos o puntos suaves:  
  * Un punto de esquina es aquel donde 2 líneas rectas se unen formando un ángulo.  
  * Un punto suave es aquel donde 2 manejadores están en una línea recta y los segmentos de la línea se unen en una curva suave. En este caso, todos los manejadores están separados del punto de anclaje a la misma distancia.  
  * Un punto recto es aquel donde 2 manejadores están en una línea recta y los segmentos de esa línea se unen en una curva suave. En este caso, los manejadores no tienen que estar separados del punto de anclaje a la misma distancia.  
* Al mover o editar los puntos de anclaje (lo que cambia el ángulo de las líneas), puede modificar la apariencia de una forma.

Para editar formas de PowerPoint mediante puntos de edición, **Aspose.Slides** proporciona la clase [**GeometryPath**](https://reference.aspose.com/slides/net/aspose.slides/geometrypath) y la interfaz [**IGeometryPath**](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath).

* Una [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath) representa la ruta geométrica del objeto [IGeometryShape](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape).  
* Para obtener el `GeometryPath` del objeto `IGeometryShape`, puede usar el método [IGeometryShape.GetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/methods/getgeometrypaths).  
* Para establecer el `GeometryPath` de una forma, puede usar estos métodos: [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/methods/setgeometrypath) para *formas sólidas* y [IGeometryShape.SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/methods/setgeometrypaths) para *formas compuestas*.  
* Para agregar segmentos, puede usar los métodos bajo [IGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath).  
* Usando las propiedades [IGeometryPath.Stroke](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/properties/stroke) y [IGeometryPath.FillMode](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/properties/fillmode), puede definir la apariencia de una ruta geométrica.  
* Con la propiedad [IGeometryPath.PathData](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/properties/pathdata), puede obtener la ruta geométrica de un `GeometryShape` como una matriz de segmentos de ruta.  
* Para acceder a opciones adicionales de personalización de la geometría de la forma, puede convertir [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath) a [GraphicsPath](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d?view=dotnet-plat-ext-5.0).  
* Utilice los métodos [GeometryPathToGraphicsPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/methods/geometrypathtographicspath) y [GraphicsPathToGeometryPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/methods/graphicspathtogeometrypath) (de la clase [ShapeUtil](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil)) para convertir [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath) a [GraphicsPath](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d?view=dotnet-plat-ext-5.0) y viceversa.

## **Operaciones de edición simples**

Este código C# muestra cómo

**Agregar una línea** al final de una ruta
``` csharp
void LineTo(PointF point);
void LineTo(float x, float y);
```

**Agregar una línea** a una posición especificada en una ruta:
``` csharp    
void LineTo(PointF point, uint index);
void LineTo(float x, float y, uint index);
```

**Agregar una curva cúbica de Bézier** al final de una ruta:
``` csharp
void CubicBezierTo(PointF point1, PointF point2, PointF point3);
void CubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3);
```

**Agregar una curva cúbica de Bézier** a una posición especificada en una ruta:
``` csharp
void CubicBezierTo(PointF point1, PointF point2, PointF point3, uint index);
void CubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3, uint index);
```

**Agregar una curva cuadrática de Bézier** al final de una ruta:
``` csharp
void QuadraticBezierTo(PointF point1, PointF point2);
void QuadraticBezierTo(float x1, float y1, float x2, float y2);
```

**Agregar una curva cuadrática de Bézier** a una posición especificada en una ruta:
``` csharp
void QuadraticBezierTo(PointF point1, PointF point2, uint index);
void QuadraticBezierTo(float x1, float y1, float x2, float y2, uint index);
```

**Agregar un arco dado** a una ruta:
``` csharp
void ArcTo(float width, float heigth, float startAngle, float sweepAngle);
```

**Cerrar la figura actual** de una ruta:
``` csharp
void CloseFigure();
```

**Establecer la posición del siguiente punto**:
``` csharp
void MoveTo(PointF point);
void MoveTo(float x, float y);
```

**Eliminar el segmento de la ruta** en un índice dado:
``` csharp
void RemoveAt(int index);
```


## **Agregar puntos personalizados a la forma**

1. Crear una instancia de la clase [GeometryShape](https://reference.aspose.com/slides/net/aspose.slides/geometryshape) y establecer el tipo [ShapeType.Rectangle](https://reference.aspose.com/slides/net/aspose.slides/shapetype).  
2. Obtener una instancia de la clase [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath) a partir de la forma.  
3. Agregar un nuevo punto entre los dos puntos superiores de la ruta.  
4. Agregar un nuevo punto entre los dos puntos inferiores de la ruta.  
5. Aplicar la ruta a la forma.

Este código C# muestra cómo agregar puntos personalizados a una forma:
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

## **Eliminar puntos de la forma**

1. Crear una instancia de la clase [GeometryShape](https://reference.aspose.com/slides/net/aspose.slides/geometryshape) y establecer el tipo [ShapeType.Heart](https://reference.aspose.com/slides/net/aspose.slides/shapetype).  
2. Obtener una instancia de la clase [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath) a partir de la forma.  
3. Eliminar el segmento de la ruta.  
4. Aplicar la ruta a la forma.

Este código C# muestra cómo eliminar puntos de una forma:
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

## **Crear forma personalizada**

1. Calcular los puntos para la forma.  
2. Crear una instancia de la clase [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath).  
3. Rellenar la ruta con los puntos.  
4. Crear una instancia de la clase [GeometryShape](https://reference.aspose.com/slides/net/aspose.slides/geometryshape).  
5. Aplicar la ruta a la forma.

Este C# muestra cómo crear una forma personalizada:
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

## **Crear forma compuesta personalizada**

1. Crear una instancia de la clase [GeometryShape](https://reference.aspose.com/slides/net/aspose.slides/geometryshape).  
2. Crear una primera instancia de la clase [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath).  
3. Crear una segunda instancia de la clase [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath).  
4. Aplicar las rutas a la forma.

Este código C# muestra cómo crear una forma compuesta personalizada:
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

## **Crear forma personalizada con esquinas curvadas**

Este código C# muestra cómo crear una forma personalizada con esquinas curvadas (hacia adentro);
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


## **Descubrir si la geometría de una forma está cerrada**

Una forma cerrada se define como aquella en la que todos sus lados se conectan, formando un único contorno sin huecos. Esa forma puede ser una figura geométrica simple o un contorno personalizado complejo. El siguiente ejemplo de código muestra cómo comprobar si la geometría de una forma está cerrada:
```cs
bool IsGeometryClosed(IGeometryShape geometryShape)
{
    bool? isClosed = null;

    foreach (var geometryPath in geometryShape.GetGeometryPaths())
    {
        var dataLength = geometryPath.PathData.Length;
        if (dataLength == 0)
            continue;

        var lastSegment = geometryPath.PathData[dataLength - 1];
        isClosed = lastSegment.PathCommand == PathCommandType.Close;

        if (isClosed == false)
            return false;
    }
    
    return isClosed == true;
}
```


## **Convertir GeometryPath a GraphicsPath (System.Drawing.Drawing2D)**

1. Crear una instancia de la clase [GeometryShape](https://reference.aspose.com/slides/net/aspose.slides/geometryshape).  
2. Crear una instancia de la clase [GraphicsPath](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath?view=dotnet-plat-ext-5.0) del espacio de nombres [System.Drawing.Drawing2D](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d?view=dotnet-plat-ext-5.0).  
3. Convertir la instancia de [GraphicsPath](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath?view=dotnet-plat-ext-5.0) a la instancia de [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath) usando [ShapeUtil](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil).  
4. Aplicar las rutas a la forma.

Este código C#—una implementación de los pasos anteriores—demuestra el proceso de conversión de **GeometryPath** a **GraphicsPath**:
``` csharp
using (Presentation pres = new Presentation())
{
    GeometryShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 100) as GeometryShape;

    IGeometryPath originalPath = shape.GetGeometryPaths()[0];
    originalPath.FillMode = PathFillModeType.None;

    GraphicsPath gPath = new GraphicsPath();

    gPath.AddString("Text in shape", new FontFamily("Arial"), 1, 40, new PointF(10, 10), StringFormat.GenericDefault);

    IGeometryPath textPath = ShapeUtil.GraphicsPathToGeometryPath(gPath);
    textPath.FillMode = PathFillModeType.Normal;

    shape.SetGeometryPaths(new[] {originalPath, textPath}) ;
}
```

![example5_image](custom_shape_5.png)

## **Preguntas frecuentes**

**¿Qué ocurrirá con el relleno y el contorno después de reemplazar la geometría?**

El estilo permanece con la forma; solo cambia el contorno. El relleno y el contorno se aplican automáticamente a la nueva geometría.

**¿Cómo rotar correctamente una forma personalizada junto con su geometría?**

Utilice la propiedad de [rotación](https://reference.aspose.com/slides/net/aspose.slides/shape/rotation/) de la forma; la geometría gira con la forma porque está vinculada al propio sistema de coordenadas de la forma.

**¿Puedo convertir una forma personalizada a una imagen para “bloquear” el resultado?**

Sí. Exporte el área de la [diapositiva](/slides/es/net/convert-powerpoint-to-png/) requerida o la propia [forma](/slides/es/net/create-shape-thumbnails/) a un formato raster; esto simplifica el trabajo posterior con geometrías pesadas.