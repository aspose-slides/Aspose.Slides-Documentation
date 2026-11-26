---
title: Personalizar formas de presentación en .NET
linktitle: Forma personalizada
type: docs
weight: 20
url: /es/net/custom-shape/
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
- .NET
- C#
- Aspose.Slides
description: "Crear y personalizar formas en presentaciones de PowerPoint con Aspose.Slides para .NET: rutas de geometría, esquinas curvas, formas compuestas."
---
## **Resumen**

Este artículo explica cómo personalizar las formas de presentación en Aspose.Slides editando la geometría de la forma mediante puntos de edición y rutas de geometría. Muestra cómo trabajar con [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) y [IGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/) para modificar formas existentes, realizar operaciones básicas de edición de rutas, añadir o eliminar puntos y aplicar la geometría actualizada a una forma.

También demuestra cómo crear formas personalizadas y compuestas, construir formas con esquinas curvas, determinar si la geometría de una forma está cerrada y utilizar la conversión heredada entre [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) y [GraphicsPath](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath) para escenarios adicionales de personalización de geometría.

## **Cambiar una forma usando puntos de edición**

* Mover una esquina hacia dentro o hacia fuera.
* Ajustar la curvatura en un punto.
* Añadir nuevos puntos.

Editar puntos le permite modificar el contorno de una forma o usar una forma existente como base para una nueva.

## **Consejos para editar formas**

![overview_image](custom_shape_0.png)

Al editar formas de PowerPoint, tenga en cuenta estos conceptos:

* Una forma (o su ruta) puede ser cerrada o abierta.
* La ruta de una forma está compuesta por puntos de anclaje conectados por segmentos.
* Un segmento puede ser recto o curvo. Los puntos de anclaje y los manejadores de control determinan su forma.
* Los puntos de anclaje pueden ser puntos de esquina, puntos rectos o puntos suaves:
  * En un punto de esquina, los segmentos adyacentes pueden encontrarse en un ángulo.
  * En un punto suave, los dos manejadores de control están alineados y a la misma distancia del punto de anclaje.
  * En un punto recto, los dos manejadores de control están alineados pero pueden estar a distintas distancias del punto de anclaje.
* Mover los puntos de anclaje o ajustar sus manejadores cambia el contorno de la forma.

Para editar formas de PowerPoint mediante puntos de edición, **Aspose.Slides** proporciona la clase [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) y la interfaz [IGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/).

* Una instancia de [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) representa una ruta de geometría del objeto [IGeometryShape](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/).
* Para obtener el [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) del objeto [IGeometryShape](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/), puede usar el método [IGeometryShape.GetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/getgeometrypaths/).
* Para establecer el [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) de una forma, puede usar estos métodos: [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/) para formas con una sola ruta y [IGeometryShape.SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypaths/) para formas con múltiples rutas.
* Para añadir segmentos, puede usar los métodos bajo [IGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/).
* Usando las propiedades [IGeometryPath.Stroke](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/stroke/) y [IGeometryPath.FillMode](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/fillmode/), puede establecer la apariencia de una ruta de geometría.
* Mediante la propiedad [IGeometryPath.PathData](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/pathdata/), puede obtener la ruta de geometría de un [GeometryShape](https://reference.aspose.com/slides/net/aspose.slides/geometryshape/) como una matriz de segmentos de ruta.
* En versiones heredadas que admiten los métodos de conversión a continuación, puede convertir [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) a [GraphicsPath](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath).
* Utilice los métodos [GeometryPathToGraphicsPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/geometrypathtographicspath/) y [GraphicsPathToGeometryPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/graphicspathtogeometrypath/) (de la clase [ShapeUtil](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/)) para convertir entre [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) y [GraphicsPath](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath).

## **Operaciones de edición simples**

Utilice los siguientes métodos para editar una ruta de geometría. Las sobrecargas que aceptan un índice insertan un segmento en esa posición basada en cero dentro de la matriz de segmentos de la ruta.

| Operación | Método |
| --- | --- |
| Añadir o insertar una línea recta. | [GeometryPath.LineTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/lineto/) |
| Añadir o insertar una curva cúbica Bézier con dos puntos de control y un punto final. | [GeometryPath.CubicBezierTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/cubicbezierto/) |
| Añadir o insertar una curva cuadrática Bézier con un punto de control y un punto final. | [GeometryPath.QuadraticBezierTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/quadraticbezierto/) |
| Añadir un arco elíptico con las dimensiones y ángulos especificados en grados. | [GeometryPath.ArcTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/arcto/) |
| Cerrar la figura actual conectando su punto final con su punto inicial. | [GeometryPath.CloseFigure](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/closefigure/) |
| Establecer el punto inicial de una figura. | [GeometryPath.MoveTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/moveto/) |
| Eliminar un segmento en un índice basado en cero. | [GeometryPath.RemoveAt](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/removeat/) |

## **Añadir puntos personalizados a una forma**

Este ejemplo inserta dos puntos en una forma rectangular usando [GeometryPath.LineTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/lineto/) y aplica la ruta editada con [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/). Las coordenadas son locales a la forma: ambos puntos nuevos están en su centro, a 100 puntos de la izquierda y 50 puntos de la parte superior. Los índices de segmento 1 y 4 los colocan en los bordes superior e inferior, tirando esos bordes hacia dentro.

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

var geometryPath = shape.GetGeometryPaths()[0];
geometryPath.LineTo(100, 50, 1);
geometryPath.LineTo(100, 50, 4);

shape.SetGeometryPath(geometryPath);
```

![example1_image](custom_shape_1.png)

## **Eliminar puntos de una forma**

Este ejemplo modifica el contorno de una forma en forma de corazón eliminando el segmento en el índice basado en cero 2 con [GeometryPath.RemoveAt](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/removeat/). Aplicar la ruta modificada con [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/) actualiza el contorno de la forma.

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Heart, 100, 100, 300, 300);

var path = shape.GetGeometryPaths()[0];
path.RemoveAt(2);

shape.SetGeometryPath(path);
```
![example2_image](custom_shape_2.png)

## **Crear una forma personalizada**

Este ejemplo construye una estrella de cinco puntas con [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/). Los radios externos e internos alternados de 100 y 50 puntos definen las puntas y las hendiduras; un paso de 72 grados distribuye uniformemente las cinco puntas. La ruta se cierra con [GeometryPath.CloseFigure](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/closefigure/) y se aplica a una forma rectangular usando [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/), sustituyendo su contorno.

```csharp
using System;
using System.Collections.Generic;
using System.Drawing;
using Aspose.Slides;

var points = new List<PointF>();

var outerRadius = 100f;
var innerRadius = 50f;
var angleStep = 72;

for (var angle = -90; angle < 270; angle += angleStep)
{
    var radians = angle * (Math.PI / 180f);
    var x = outerRadius * Math.Cos(radians);
    var y = outerRadius * Math.Sin(radians);
    points.Add(new PointF((float)x + outerRadius, (float)y + outerRadius));

    radians = Math.PI * (angle + angleStep / 2) / 180.0;
    x = innerRadius * Math.Cos(radians);
    y = innerRadius * Math.Sin(radians);
    points.Add(new PointF((float)x + outerRadius, (float)y + outerRadius));
}

var starPath = new GeometryPath();
starPath.MoveTo(points[0]);

for (var i = 1; i < points.Count; i++)
{
    starPath.LineTo(points[i]);
}

starPath.CloseFigure();

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, outerRadius * 2, outerRadius * 2);
shape.SetGeometryPath(starPath);
```
![example3_image](custom_shape_3.png)

## **Crear una forma personalizada compuesta**

Este ejemplo define dos objetos [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) cerrados para el tercio superior e inferior de una forma. Aplicar ambas rutas con [IGeometryShape.SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypaths/) crea una única forma compuesta con una apertura en el tercio central.

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

var topPath = new GeometryPath();
topPath.MoveTo(0, 0);
topPath.LineTo(shape.Width, 0);
topPath.LineTo(shape.Width, shape.Height / 3);
topPath.LineTo(0, shape.Height / 3);
topPath.CloseFigure();

var bottomPath = new GeometryPath();
bottomPath.MoveTo(0, shape.Height / 3 * 2);
bottomPath.LineTo(shape.Width, shape.Height / 3 * 2);
bottomPath.LineTo(shape.Width, shape.Height);
bottomPath.LineTo(0, shape.Height);
bottomPath.CloseFigure();

shape.SetGeometryPaths(new GeometryPath[] { topPath, bottomPath });
```
![example4_image](custom_shape_4.png)

## **Crear una forma personalizada con esquinas curvas**

Este ejemplo combina segmentos rectos con [GeometryPath.ArcTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/arcto/) para crear una forma con esquinas curvadas hacia dentro. Cada tamaño de esquina define el ancho y alto del arco en puntos, y el barrido de -90 grados dibuja un cuarto de elipse en sentido antihorario. La ruta completada se aplica con [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/), y la presentación se guarda en formato PPTX.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

var shapeX = 20f;
var shapeY = 20f;
var shapeWidth = 300f;
var shapeHeight = 200f;

var leftTopSize = 50f;
var rightTopSize = 20f;
var rightBottomSize = 40f;
var leftBottomSize = 10f;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var topLeft = new PointF(leftTopSize, 0);
var topRight = new PointF(shapeWidth - rightTopSize, 0);
var rightBottom = new PointF(shapeWidth, shapeHeight - rightBottomSize);
var bottomLeft = new PointF(leftBottomSize, shapeHeight);
var leftTop = new PointF(0, leftTopSize);

var geometryPath = new GeometryPath();
geometryPath.MoveTo(topLeft);
geometryPath.LineTo(topRight);
geometryPath.ArcTo(rightTopSize, rightTopSize, 180, -90);
geometryPath.LineTo(rightBottom);
geometryPath.ArcTo(rightBottomSize, rightBottomSize, -90, -90);
geometryPath.LineTo(bottomLeft);
geometryPath.ArcTo(leftBottomSize, leftBottomSize, 0, -90);
geometryPath.LineTo(leftTop);
geometryPath.ArcTo(leftTopSize, leftTopSize, 90, -90);
geometryPath.CloseFigure();

var shape = slide.Shapes.AddAutoShape(ShapeType.Custom, shapeX, shapeY, shapeWidth, shapeHeight);
shape.SetGeometryPath(geometryPath);

presentation.Save("output.pptx", SaveFormat.Pptx);
```

## **Determinar si la geometría de una forma está cerrada**

El siguiente asistente verifica si cada ruta de geometría no vacía termina con un segmento de cierre. Lee [IGeometryPath.PathData](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/pathdata/) y compara el [IPathSegment.PathCommand](https://reference.aspose.com/slides/net/aspose.slides/ipathsegment/pathcommand/) del segmento final con [PathCommandType.Close](https://reference.aspose.com/slides/net/aspose.slides/pathcommandtype/). Devuelve false cuando no hay rutas no vacías. Esto comprueba el comando final de cada ruta; no inspecciona cada subfigura dentro de una ruta. El ejemplo muestra `True` para un rectángulo.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
Console.WriteLine(IsGeometryClosed(shape));

bool IsGeometryClosed(IGeometryShape geometryShape)
{
    var hasNonemptyPath = false;

    foreach (var geometryPath in geometryShape.GetGeometryPaths())
    {
        var segments = geometryPath.PathData;
        if (segments.Length == 0)
        {
            continue;
        }

        hasNonemptyPath = true;
        var lastSegment = segments[segments.Length - 1];
        if (lastSegment.PathCommand != PathCommandType.Close)
        {
            return false;
        }
    }

    return hasNonemptyPath;
}
```

## **Inspeccionar comandos de ruta de geometría**

Descargue [contour.pptx](contour.pptx) y colóquelo en el directorio de trabajo de la aplicación. La primera diapositiva contiene una forma con un borde superior recto, una curva cúbica Bézier y un borde de cierre recto. Use [GetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/getgeometrypaths/) para leer sus rutas. Cada ruta enumera sus segmentos en orden de dibujo en [PathData](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/pathdata/). El [PathCommand](https://reference.aspose.com/slides/net/aspose.slides/ipathsegment/pathcommand/) de cada segmento determina cómo leer su [SegmentData](https://reference.aspose.com/slides/net/aspose.slides/ipathsegment/segmentdata/).

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("contour.pptx");

var shape = (IGeometryShape)presentation.Slides[0].Shapes[0];
var paths = shape.GetGeometryPaths();

for (int i = 0; i < paths.Length; i++)
{
    var segments = paths[i].PathData;
    for (int j = 0; j < segments.Length; j++)
    {
        var command = segments[j].PathCommand;
        var data = segments[j].SegmentData;
        var detail = command switch
        {
            PathCommandType.MoveTo or PathCommandType.LineTo => $"destination=({data[0]}, {data[1]})",
            PathCommandType.CubicBezierTo => $"control1=({data[0]}, {data[1]}) control2=({data[2]}, {data[3]}) end=({data[4]}, {data[5]})",
            PathCommandType.Close => "no coordinates",
            _ => $"raw=[{string.Join(", ", data)}]"
        };
        Console.WriteLine($"Path {i}, segment {j}: {command} {detail}");
    }
}
```

La forma está situada en (200, 100) puntos en la diapositiva. Los puntos reportados son locales a la forma, con (0, 0) en su esquina superior izquierda, x aumentando hacia la derecha e y aumentando hacia abajo. El segmento de cierre vuelve al punto inicial sin coordenadas adicionales.

```text
Path 0, segment 0: MoveTo destination=(0, 0)
Path 0, segment 1: LineTo destination=(80, 0)
Path 0, segment 2: CubicBezierTo control1=(70, 15) control2=(30, 45) end=(0, 60)
Path 0, segment 3: Close no coordinates
```

![Forma de PowerPoint con un borde superior recto, un borde curvo desde la parte superior derecha hasta la inferior izquierda, y un borde izquierdo recto](contour.png)

## **Extraer e inspeccionar elementos de forma**

Utilice [IGeometryShape.CreateShapeElements](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/createshapeelements/) para inspeccionar una forma existente como elementos que contienen puntos de ruta y tipos de punto. Convierta cada [IShapeElement](https://reference.aspose.com/slides/net/aspose.slides/ishapeelement/) devuelto a [ShapeElement](https://reference.aspose.com/slides/net/aspose.slides/shapeelement/) para leer sus matrices [PathPoints](https://reference.aspose.com/slides/net/aspose.slides/shapeelement/pathpoints/) y [PathTypes](https://reference.aspose.com/slides/net/aspose.slides/shapeelement/pathtypes/). Esta representación es útil para el análisis de contornos o para pasar la geometría a herramientas de dibujo personalizadas.

El ejemplo abre una presentación, busca la primera forma de geometría directamente en la primera diapositiva y muestra sus segmentos de ruta. Use una presentación que contenga una forma con segmentos rectos y curvos para ver ambos tipos de salida. No busca dentro de grupos.

```csharp
using System;
using System.Linq;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");
var slide = presentation.Slides[0];

var shape = slide.Shapes.OfType<IGeometryShape>().FirstOrDefault();
if (shape == null)
{
    Console.WriteLine("No geometry shape found on the first slide.");
    return;
}

foreach (IShapeElement element in shape.CreateShapeElements())
{
    var shapeElement = (ShapeElement)element;
    var points = shapeElement.PathPoints;
    var types = shapeElement.PathTypes;
    Console.WriteLine("Shape element:");

    for (var i = 0; i < points.Length; i++)
    {
        var pointType = types[i] & 0x07; // Keep the segment type, excluding flags.
        switch (pointType)
        {
            case 0:
                Console.WriteLine($"Start figure at {points[i]}");
                break;
            case 1:
                Console.WriteLine($"Line to {points[i]}");
                break;
            case 3:
                Console.WriteLine($"Cubic Bezier: controls {points[i]}, {points[i + 1]}; end {points[i + 2]}");
                i += 2; // Consume both control points and the endpoint.
                break;
        }

        if ((types[i] & 0x80) != 0)
        {
            Console.WriteLine("Close subpath back to its starting point.");
        }
    }
}
```

Las matrices corresponden por índice: `points[i]` es un punto y `types[i]` describe su papel. El tipo `0` inicia una figura, y el tipo `1` dibuja una línea desde el punto anterior al punto actual. Un segmento Bézier cúbico comienza en el punto final anterior y utiliza tres entradas consecutivas de tipo `3`: dos puntos de control seguidos del nuevo punto final. El bucle consume estas tres entradas juntas y verifica el punto final para el cierre.

Los tipos de punto también contienen banderas. Enmascare con `0x07` para identificar el tipo de segmento, y pruebe `0x80` por separado para detectar una subruta cerrada. Por ejemplo, `129` (`0x81`) significa un punto final de línea que cierra una subruta, y `131` (`0x83`) significa un punto final Bézier que cierra una. Comparar el valor crudo solo con `1` o `3` pasaría por alto estos casos. Otras banderas, como guión (`0x10`) y marcador (`0x20`), no cambian el tipo base del segmento.

**Coordenadas y transformaciones.** Los puntos se miden en puntos (1/72 de pulgada), con X aumentando hacia la derecha e Y aumentando hacia abajo. Para una forma sin agrupar, las coordenadas extraídas ya incluyen su posición [X](https://reference.aspose.com/slides/net/aspose.slides/shape/x/) y [Y](https://reference.aspose.com/slides/net/aspose.slides/shape/y/) y reflejan su ancho y alto actuales. Por ejemplo, un rectángulo sin rotar en `(100, 200)` con tamaño `120 × 80` tiene límites de contorno `(100, 200)`–`(220, 280)`. No vuelva a añadir la posición de la forma. Reste su X e Y para obtener coordenadas relativas a su marco sin rotar.

Los puntos extraídos no aplican la [Rotation](https://reference.aspose.com/slides/net/aspose.slides/shape/rotation/) de la forma ni los volteos horizontales y verticales. Para reproducir el contorno mostrado, aplique esas transformaciones alrededor del centro de la forma. Para formas agrupadas, también tenga en cuenta el mapeo de coordenadas del grupo y sus transformaciones; no asuma que los puntos extraídos son las coordenadas finales renderizadas de la diapositiva o aplique una traslación o escala dos veces si ya está reflejada en el marco del hijo.

**Inspección versus edición.** Las matrices extraídas describen el contorno; cambiarlas no actualiza la forma original. Elija este enfoque cuando su análisis o código de dibujo necesite matrices de punto/tipo. Use [GetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/getgeometrypaths/) cuando necesite comandos de geometría en el sistema de coordenadas local de la forma o quiera editar su geometría. Aplique rutas editadas mediante [SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/) o [SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypaths/).

## **Convertir GeometryPath a GraphicsPath (System.Drawing.Drawing2D)**

El siguiente ejemplo requiere un ensamblado heredado de Aspose.Slides para .NET que soporte [ShapeUtil.GraphicsPathToGeometryPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/graphicspathtogeometrypath/), como la versión 25.10, y un entorno Windows con `System.Drawing.Common`. Los métodos de conversión fueron eliminados en la [versión 25.11](https://releases.aspose.com/slides/net/release-notes/2025/aspose-slides-for-net-25-11-release-notes/).

Este ejemplo combina un contorno rectangular con texto convertido a geometría. El [IGeometryPath.FillMode](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/fillmode/) del contorno se establece para desactivar su relleno. Un [GraphicsPath](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath) almacena el contorno del texto, que [ShapeUtil.GraphicsPathToGeometryPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/graphicspathtogeometrypath/) convierte en una ruta de geometría rellenada. Aplicar ambas rutas con [IGeometryShape.SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypaths/) produce una única forma que contiene el rectángulo y el texto. Para la conversión en sentido inverso, use [ShapeUtil.GeometryPathToGraphicsPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/geometrypathtographicspath/).

```csharp
using System.Drawing;
using System.Drawing.Drawing2D;
using Aspose.Slides;
using Aspose.Slides.Util;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 100);

var originalPath = shape.GetGeometryPaths()[0];
originalPath.FillMode = PathFillModeType.None;

using var graphicsPath = new GraphicsPath();
using var fontFamily = new FontFamily("Arial");
using var stringFormat = StringFormat.GenericDefault;

graphicsPath.AddString("Text in shape", fontFamily, (int)FontStyle.Bold, 40, new PointF(10, 10), stringFormat);

var textPath = ShapeUtil.GraphicsPathToGeometryPath(graphicsPath);
textPath.FillMode = PathFillModeType.Normal;

shape.SetGeometryPaths(new[] { originalPath, textPath });
```
![example5_image](custom_shape_5.png)

## **Preguntas frecuentes**

**¿Qué ocurrirá con el relleno y el contorno después de reemplazar la geometría?**

El estilo permanece con la forma; solo cambia el contorno. El relleno y el contorno se aplican automáticamente a la nueva geometría.

**¿Cómo rotar correctamente una forma personalizada junto con su geometría?**

Utilice la propiedad [Rotation](https://reference.aspose.com/slides/net/aspose.slides/shape/rotation/) de la forma; la geometría gira con la forma porque está vinculada al propio sistema de coordenadas de la forma.

**¿Puedo convertir una forma personalizada a una imagen para “bloquear” el resultado?**

Sí. Exporte el área de la [diapositiva](/slides/es/net/convert-powerpoint-to-png/) requerida o la propia [forma](/slides/es/net/create-shape-thumbnails/) a un formato raster; esto simplifica el trabajo posterior con geometrías complejas.