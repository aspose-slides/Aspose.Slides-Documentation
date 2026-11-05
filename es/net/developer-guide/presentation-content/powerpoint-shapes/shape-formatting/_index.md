---
title: Formatear formas de PowerPoint en .NET
linktitle: Formato de formas
type: docs
weight: 20
url: /es/net/shape-formatting/
keywords:
- formato de forma
- formato de línea
- efecto boceto
- línea de forma boceto
- estilo de unión
- relleno degradado
- relleno de patrón
- relleno de imagen
- relleno de textura
- relleno de color sólido
- transparencia de forma
- renderizado de forma en blanco y negro
- renderizado de forma en escala de grises
- rotar forma
- efecto de bisel 3D
- efecto de rotación 3D
- restablecer formato
- PowerPoint
- presentación
- .NET
- C#
- Aspose.Slides
description: "Aprenda a formatear formas de PowerPoint en C# usando Aspose.Slides—establezca estilos de relleno, línea y efecto para archivos PPT y PPTX con precisión y control total."
---
## **Introducción**

Formatee formas en PowerPoint ajustando sus contornos, rellenos y efectos. Aspose.Slides para .NET le permite controlar estos ajustes mediante programación, incluyendo transparencia, rotación y formato 3D.

![Opciones de formato de forma en PowerPoint](format-shape-powerpoint.png)

Aspose.Slides para .NET proporciona interfaces y propiedades que le permiten formatear formas utilizando las mismas opciones disponibles en PowerPoint.

## **Formatear líneas**

Utilice [IShape.LineFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/lineformat/) para controlar el contorno de una forma. Este ejemplo crea un rectángulo sin rellenar con un contorno azul y discontinuo. [ILineFormat.Style](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/style/) selecciona una línea compuesta gruesa‑delgada, mientras que [ILineFormat.Width](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/width/) establece su ancho a 7 puntos y [ILineFormat.DashStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/dashstyle/) selecciona el patrón de guiones.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
shape.FillFormat.FillType = FillType.NoFill;
shape.LineFormat.Style = LineStyle.ThickThin;
shape.LineFormat.Width = 7;
shape.LineFormat.DashStyle = LineDashStyle.Dash;
shape.LineFormat.FillFormat.FillType = FillType.Solid;
shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;

presentation.Save("formatted_lines.pptx", SaveFormat.Pptx);
```

El resultado:

![Las líneas formateadas en la presentación](formatted-lines.png)

### **Establecer patrones de guiones personalizados para líneas**

Utilice [ILineFormat.CustomDashPattern](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/customdashpattern/) cuando los estilos de línea predefinidos no proporcionan las longitudes de guiones y espacios que necesita, por ejemplo para contornos de marca o diagramas técnicos. Asignar un patrón establece automáticamente [ILineFormat.DashStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/dashstyle/) en [LineDashStyle.Custom](https://reference.aspose.com/slides/net/aspose.slides/linedashstyle/).

Las entradas del array alternan entre longitudes de guión y de espacio, comenzando con un guión. Cada valor es múltiplo del ancho de la línea: `{ 4, 2 }` con un ancho de 3 puntos produce un guión de 12 puntos seguido de un espacio de 6 puntos. Utilice pares de valores finitos y no negativos para definir segmentos completos de guiones y espacios. El ejemplo usa valores positivos para mantener visibles todos los guiones y espacios.

Este ejemplo crea cinco líneas azules con la misma longitud y extremos planos. Las tres primeras comparan patrones con un ancho de 3 puntos. La cuarta repite el primer patrón con el doble de ancho, duplicando tanto la longitud del guión como del espacio. La quinta cambia de un patrón personalizado a una línea sólida.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(600, 300, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

var patterns = new[]
{
    new float[] { 4, 2 },
    new float[] { 1, 2 },
    new float[] { 6, 2, 1, 2 },
    new float[] { 4, 2 },
    new float[] { 4, 2 }
};

for (var i = 0; i < patterns.Length; i++)
{
    var line = slide.Shapes.AddAutoShape(ShapeType.Line, 50, 50 + i * 50, 500, 0);
    line.LineFormat.Width = i == 3 ? 6 : 3;
    line.LineFormat.FillFormat.FillType = FillType.Solid;
    line.LineFormat.FillFormat.SolidFillColor.Color = Color.DarkBlue;
    line.LineFormat.CapStyle = LineCapStyle.Flat;
    line.LineFormat.BeginArrowheadStyle = LineArrowheadStyle.None;
    line.LineFormat.EndArrowheadStyle = LineArrowheadStyle.None;
    line.LineFormat.CustomDashPattern = patterns[i];
}

// Devolver la última línea a un estilo sólido.
slide.Shapes[4].LineFormat.DashStyle = LineDashStyle.Solid;

presentation.Save("custom_dash_patterns.pptx", SaveFormat.Pptx);
```

Para volver a un estilo discontinuo predefinido, asigne [LineDashStyle.Dash](https://reference.aspose.com/slides/net/aspose.slides/linedashstyle/) a [ILineFormat.DashStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/dashstyle/). El estilo seleccionado controla la apariencia de la línea.

El resultado en PowerPoint, de arriba a abajo: **{4, 2}, 3 pt**; **{1, 2}, 3 pt**; **{6, 2, 1, 2}, 3 pt**; **{4, 2}, 6 pt**; y **Solid, 3 pt**.

![Tres patrones de guiones personalizados, una línea más ancha usando el primer patrón y una línea sólida en PowerPoint](custom-dash-patterns.png)

### **Establecer extremos de línea**

Utilice [ILineFormat.CapStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/capstyle/) para establecer los extremos de una línea abierta. La enumeración [LineCapStyle](https://reference.aspose.com/slides/net/aspose.slides/linecapstyle/) ofrece tres estilos de extremo explícitos:

- `Flat`: El trazo se detiene en el punto final.
- `Round`: Un extremo semicircular se extiende más allá del punto final en la mitad del ancho de línea.
- `Square`: Un extremo cuadrado se extiende más allá del punto final en la mitad del ancho de línea.

La enumeración también incluye `NotDefined`, que significa que no se ha asignado ningún estilo de extremo explícitamente.

Los extremos son diferentes de las puntas de flecha, que añaden símbolos a los extremos de la línea, y de las uniones, que controlan las esquinas entre segmentos de línea. Este ejemplo desactiva las puntas de flecha mediante [ILineFormat.BeginArrowheadStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/beginarrowheadstyle/) y [ILineFormat.EndArrowheadStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/endarrowheadstyle/) para que solo se comparen las formas de los extremos.

El siguiente ejemplo crea tres líneas horizontales, idénticas en demás aspectos, de 20 puntos de ancho. De arriba a abajo, usan extremos plano, redondo y cuadrado. Sus puntos finales comparten las mismas coordenadas horizontales; los extremos redondos y cuadrados se extienden 10 puntos más allá de cada punto final.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(500, 240, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

var capStyles = new[] { LineCapStyle.Flat, LineCapStyle.Round, LineCapStyle.Square };

for (var i = 0; i < capStyles.Length; i++)
{
    var line = slide.Shapes.AddAutoShape(ShapeType.Line, 100, 50 + i * 70, 300, 0);
    line.LineFormat.Width = 20;
    line.LineFormat.FillFormat.FillType = FillType.Solid;
    line.LineFormat.FillFormat.SolidFillColor.Color = Color.DarkBlue;
    line.LineFormat.DashStyle = LineDashStyle.Solid;
    line.LineFormat.CapStyle = capStyles[i];
    line.LineFormat.BeginArrowheadStyle = LineArrowheadStyle.None;
    line.LineFormat.EndArrowheadStyle = LineArrowheadStyle.None;
}

presentation.Save("line_caps.pptx", SaveFormat.Pptx);
```

El resultado en PowerPoint, de arriba a abajo: **Flat**, **Round** y **Square**.

![Extremos plano, redondo y cuadrado en líneas gruesas idénticas en PowerPoint](line-caps.png)

## **Aplicar efectos de boceto a líneas de forma**

Un efecto de boceto hace que la línea de una forma parezca dibujada a mano. Utilice [IShape.LineFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/lineformat/) para acceder a la configuración de la línea, [ILineFormat.SketchFormat](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/sketchformat/) para acceder a la configuración del boceto y [ISketchFormat.SketchType](https://reference.aspose.com/slides/net/aspose.slides/isketchformat/sketchtype/) para seleccionar un valor de la enumeración [LineSketchType](https://reference.aspose.com/slides/net/aspose.slides/linesketchtype/).

El siguiente código C# muestra cómo aplicar un efecto [LineSketchType.Curved](https://reference.aspose.com/slides/net/aspose.slides/linesketchtype/) , leer el valor asignado explícitamente y eliminar el efecto con [LineSketchType.None](https://reference.aspose.com/slides/net/aspose.slides/linesketchtype/):

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);

var sketchFormat = shape.LineFormat.SketchFormat;
sketchFormat.SketchType = LineSketchType.Curved;
var explicitSketchType = sketchFormat.SketchType;
Console.WriteLine($"Explicit sketch type: {explicitSketchType}");
sketchFormat.SketchType = LineSketchType.None;
```

El valor devuelto por [ISketchFormat.SketchType](https://reference.aspose.com/slides/net/aspose.slides/isketchformat/sketchtype/) representa la configuración asignada directamente a la forma. Si el formato de la línea puede heredarse de un tema, diapositiva maestra o diapositiva de diseño, utilice [ILineFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/geteffective/), acceda a [ILineFormatEffectiveData.SketchFormat](https://reference.aspose.com/slides/net/aspose.slides/ilineformateffectivedata/sketchformat/) y lea [ISketchFormatEffectiveData.SketchType](https://reference.aspose.com/slides/net/aspose.slides/isketchformateffectivedata/sketchtype/). El valor efectivo refleja el formato que se aplica realmente después de resolver la herencia. Este ejemplo requiere una presentación existente con al menos una forma en su primera diapositiva y muestra ambos valores:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var shape = presentation.Slides[0].Shapes[0];

var lineFormat = shape.LineFormat;
var explicitSketchType = lineFormat.SketchFormat.SketchType;
var effectiveLineFormat = lineFormat.GetEffective();
var effectiveSketchType = effectiveLineFormat.SketchFormat.SketchType;

Console.WriteLine($"Explicit sketch type: {explicitSketchType}");
Console.WriteLine($"Effective sketch type: {effectiveSketchType}");
```

## **Formatear estilos de unión**

Estas son las tres opciones de tipo de unión:

* Round
* Miter
* Bevel

El estilo de unión controla cómo se encuentran dos segmentos de contorno en una esquina. Utilice **Round** para esquinas redondeadas, **Miter** para esquinas agudas o **Bevel** para esquinas aplanadas.

![El estilo de unión en la presentación](join-style-powerpoint.png)

Este ejemplo crea tres rectángulos negros con contornos azules de 15 puntos de ancho. Establece [ILineFormat.JoinStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/joinstyle/) a los valores miter, bevel y round de [LineJoinStyle](https://reference.aspose.com/slides/net/aspose.slides/linejoinstyle/), respectivamente, para comparar cómo se dibujan las esquinas.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var miterShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 75);
var bevelShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 210, 20, 150, 75);
var roundShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 135, 150, 75);

miterShape.FillFormat.FillType = FillType.Solid;
miterShape.FillFormat.SolidFillColor.Color = Color.Black;
bevelShape.FillFormat.FillType = FillType.Solid;
bevelShape.FillFormat.SolidFillColor.Color = Color.Black;
roundShape.FillFormat.FillType = FillType.Solid;
roundShape.FillFormat.SolidFillColor.Color = Color.Black;

miterShape.LineFormat.Width = 15;
bevelShape.LineFormat.Width = 15;
roundShape.LineFormat.Width = 15;

miterShape.LineFormat.FillFormat.FillType = FillType.Solid;
miterShape.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
bevelShape.LineFormat.FillFormat.FillType = FillType.Solid;
bevelShape.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
roundShape.LineFormat.FillFormat.FillType = FillType.Solid;
roundShape.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;

miterShape.LineFormat.JoinStyle = LineJoinStyle.Miter;
bevelShape.LineFormat.JoinStyle = LineJoinStyle.Bevel;
roundShape.LineFormat.JoinStyle = LineJoinStyle.Round;

miterShape.TextFrame.Text = "Miter Join Style";
bevelShape.TextFrame.Text = "Bevel Join Style";
roundShape.TextFrame.Text = "Round Join Style";

presentation.Save("join_styles.pptx", SaveFormat.Pptx);
```

### **Limitar uniones en inglete en esquinas agudas**

Utilice [ILineFormat.MiterLimit](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/miterlimit/) con [ILineFormat.JoinStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/joinstyle/) configurado en [LineJoinStyle.Miter](https://reference.aspose.com/slides/net/aspose.slides/linejoinstyle/) para limitar hasta dónde puede extenderse una esquina aguda.

El límite es una proporción entre la distancia entre las esquinas interior y exterior de la unión y el ancho de línea. Por ejemplo, un valor de `8` permite una longitud de inglete de hasta ocho veces el ancho de línea; no es una medida en puntos. Si la esquina superaría el límite, PowerPoint usa una unión biselada en esa esquina. Un límite mayor permite puntos más agudos. La configuración afecta solo a uniones en inglete, y cambiarla no tiene un efecto visible cuando la esquina se mantiene dentro de ambos límites.

Este ejemplo crea dos triángulos idénticos, sin relleno, con contornos de 20 puntos de ancho. El triángulo izquierdo usa un límite de `2` y el derecho usa `8`. Cada triángulo mide 80 puntos de ancho y 160 puntos de alto, lo que le da a su esquina superior una proporción de longitud de inglete a ancho de línea de aproximadamente `4.12`. En consecuencia, PowerPoint bisela la cúspide izquierda y preserva la derecha.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(500, 320, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

var miterLimits = new[] { 2f, 8f };

for (var i = 0; i < miterLimits.Length; i++)
{
    var triangle = slide.Shapes.AddAutoShape(ShapeType.Triangle, 90 + i * 240, 110, 80, 160);
    triangle.FillFormat.FillType = FillType.NoFill;
    triangle.LineFormat.Width = 20;
    triangle.LineFormat.FillFormat.FillType = FillType.Solid;
    triangle.LineFormat.FillFormat.SolidFillColor.Color = Color.DarkBlue;
    triangle.LineFormat.JoinStyle = LineJoinStyle.Miter;
    triangle.LineFormat.MiterLimit = miterLimits[i];
}

presentation.Save("miter_limits.pptx", SaveFormat.Pptx);
```

El resultado en PowerPoint: **Miter limit 2** a la izquierda y **miter limit 8** a la derecha.

![Una cúspide biselada con límite de inglete 2 y una cúspide puntiaguda con límite de inglete 8 en PowerPoint](miter-limits.png)

## **Relleno degradado**

Un relleno degradado mezcla colores a lo largo de una forma. Este ejemplo rellena una elipse con un degradado lineal a 45 grados de rojo a púrpura usando [IFillFormat.GradientFormat](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/gradientformat/). El método [IGradientStopCollection.Add](https://reference.aspose.com/slides/net/aspose.slides/igradientstopcollection/add/) coloca los puntos de color en 0 y 1, el inicio y el final del degradado. Borrar los puntos existentes garantiza que solo se usen estos dos colores.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);
shape.FillFormat.FillType = FillType.Gradient;
shape.FillFormat.GradientFormat.GradientShape = GradientShape.Linear;
shape.FillFormat.GradientFormat.LinearGradientAngle = 45;
shape.FillFormat.GradientFormat.GradientStops.Clear();
shape.FillFormat.GradientFormat.GradientStops.Add(1.0f, PresetColor.Purple);
shape.FillFormat.GradientFormat.GradientStops.Add(0.0f, PresetColor.Red);

presentation.Save("gradient_fill.pptx", SaveFormat.Pptx);
```

El resultado:

![La elipse con relleno degradado](gradient-fill.png)

Si un degradado se ve diferente en una imagen exportada que en PowerPoint, consulte [Choose a Gradient Rendering Style](/slides/es/net/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). Puede seleccionar un estilo de renderizado sin cambiar el relleno degradado almacenado en la presentación.

### **Establecer el ángulo del degradado lineal**

Utilice [IGradientFormat.LinearGradientAngle](https://reference.aspose.com/slides/net/aspose.slides/igradientformat/lineargradientangle/) para controlar la orientación de un relleno [GradientShape.Linear](https://reference.aspose.com/slides/net/aspose.slides/gradientshape/). El ángulo se mide en grados y aumenta en sentido horario: `0` va de izquierda a derecha, `90` de arriba a abajo, `180` de derecha a izquierda y `270` de abajo a arriba. Se admiten ángulos fraccionarios. Los ángulos finitos fuera de `[0, 360)` se normalizan a una revolución; por ejemplo, `-45` pasa a `315` y `360` pasa a `0`.

Este ejemplo crea seis rectángulos con paradas de color rojo, verde y azul idénticas en las posiciones `0`, `0.5` y `1`. El escalado está desactivado para que el ángulo se pueda comparar independientemente de las proporciones de los rectángulos. Los ángulos, de izquierda a derecha, son `0`, `45` y `90` en la primera fila, y `135`, `180` y `270` en la segunda fila.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(720, 400, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

var angles = new float[] { 0, 45, 90, 135, 180, 270 };

for (var i = 0; i < angles.Length; i++)
{
    var x = 30 + (i % 3) * 230;
    var y = 30 + (i / 3) * 190;

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, x, y, 200, 150);
    shape.LineFormat.FillFormat.FillType = FillType.NoFill;
    shape.FillFormat.FillType = FillType.Gradient;

    var gradient = shape.FillFormat.GradientFormat;
    gradient.GradientShape = GradientShape.Linear;
    gradient.GradientStops.Clear();
    gradient.GradientStops.Add(0f, Color.Red);
    gradient.GradientStops.Add(0.5f, Color.Lime);
    gradient.GradientStops.Add(1f, Color.Blue);
    gradient.LinearGradientScaled = NullableBool.False;
    gradient.LinearGradientAngle = angles[i];
}

presentation.Save("linear_gradient_angles.pptx", SaveFormat.Pptx);
```

El resultado en PowerPoint:

![Degradados lineales a 0, 45 y 90 grados en la fila superior, y 135, 180 y 270 grados en la fila inferior](linear-gradient-angles.png)

### **Escalar un degradado lineal con la forma**

[IGradientFormat.LinearGradientScaled](https://reference.aspose.com/slides/net/aspose.slides/igradientformat/lineargradientscaled/) acepta un valor [NullableBool](https://reference.aspose.com/slides/net/aspose.slides/nullablebool/). Establécelo explícitamente en `False` para mantener el ángulo geométrico del degradado cuando cambien las proporciones de la forma, o en `True` para escalar el degradado con el ancho y alto de la forma. Con el escalado activado, el ángulo visible puede diferir del ángulo asignado en una forma no cuadrada.

El siguiente ejemplo usa un ángulo de `45` grados y los mismos puntos de color que la comparación de ángulos. La columna izquierda usa `False`; la columna derecha usa `True`. Cada columna contiene un rectángulo ancho encima de un rectángulo alto. Ambos comienzan con las mismas dimensiones anchas; cambiar el ancho y alto del segundo rectángulo muestra cómo el relleno responde al redimensionamiento sin cambiar su configuración de degradado.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(720, 460, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

var scalingOptions = new[] { NullableBool.False, NullableBool.True };

for (var column = 0; column < scalingOptions.Length; column++)
{
    for (var row = 0; row < 2; row++)
    {
        var x = 30 + column * 360;
        var y = row == 0 ? 30 : 150;
        
        var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, x, y, 300, 90);
        shape.LineFormat.FillFormat.FillType = FillType.NoFill;
        shape.FillFormat.FillType = FillType.Gradient;

        var gradient = shape.FillFormat.GradientFormat;
        gradient.GradientShape = GradientShape.Linear;
        gradient.GradientStops.Clear();
        gradient.GradientStops.Add(0f, Color.Red);
        gradient.GradientStops.Add(0.5f, Color.Lime);
        gradient.GradientStops.Add(1f, Color.Blue);
        gradient.LinearGradientAngle = 45;
        gradient.LinearGradientScaled = scalingOptions[column];

        if (row == 1)
        {
            shape.Width = 90;
            shape.Height = 280;
        }
    }
}

presentation.Save("linear_gradient_scaling.pptx", SaveFormat.Pptx);
```

El resultado en PowerPoint, con el escalado desactivado a la izquierda y activado a la derecha:

![Rectángulos anchos y altos con un degradado de 45 grados, comparando LinearGradientScaled False a la izquierda con True a la derecha](linear-gradient-scaling.png)

Con el escalado desactivado, las bandas diagonales de color mantienen la misma orientación en ambos rectángulos. Con el escalado activado, las bandas se estiran con las proporciones de la forma. Esto ayuda a reproducir el degradado de una plantilla al adaptar una forma a un tamaño diferente. En una forma cuadrada, activar el escalado no cambia la apariencia de este degradado de `45` grados.

Tanto el ángulo como la configuración de escalado se aplican a los degradados lineales. No controlan los rellenos [GradientShape.Radial or GradientShape.Rectangle](https://reference.aspose.com/slides/net/aspose.slides/gradientshape/).

### **Combinar el ángulo con la dirección del degradado**

[IGradientFormat.GradientDirection](https://reference.aspose.com/slides/net/aspose.slides/igradientformat/gradientdirection/) selecciona un estilo de degradado de la enumeración [GradientDirection](https://reference.aspose.com/slides/net/aspose.slides/gradientdirection/). No es un sustituto de un ángulo numérico. Para un degradado lineal, los estilos de esquina pueden cambiar el área sobre la que se distribuyen los colores sin cambiar [LinearGradientAngle](https://reference.aspose.com/slides/net/aspose.slides/igradientformat/lineargradientangle/). Mantenga la dirección sin cambios al comparar ángulos o escalado.

El siguiente ejemplo aplica la misma configuración en órdenes opuestos. Los dos rectángulos tienen el mismo aspecto: asignar la dirección antes o después del ángulo no cambia el resultado.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

for (var i = 0; i < 2; i++)
{
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 30 + i * 140, 320, 100);
    shape.LineFormat.FillFormat.FillType = FillType.NoFill;
    shape.FillFormat.FillType = FillType.Gradient;

    var gradient = shape.FillFormat.GradientFormat;
    gradient.GradientShape = GradientShape.Linear;
    gradient.GradientStops.Clear();
    gradient.GradientStops.Add(0f, Color.Red);
    gradient.GradientStops.Add(0.5f, Color.Lime);
    gradient.GradientStops.Add(1f, Color.Blue);
    gradient.LinearGradientScaled = NullableBool.True;

    if (i == 0)
    {
        gradient.GradientDirection = GradientDirection.FromCorner1;
        gradient.LinearGradientAngle = 30;
    }
    else
    {
        gradient.LinearGradientAngle = 30;
        gradient.GradientDirection = GradientDirection.FromCorner1;
    }
}

presentation.Save("linear_gradient_direction.pptx", SaveFormat.Pptx);
```


## **Relleno de patrón**

Un relleno de patrón aplica un diseño bicolor, como puntos, rayas o cuadros. Este ejemplo usa [IPatternFormat.PatternStyle](https://reference.aspose.com/slides/net/aspose.slides/ipatternformat/patternstyle/) para seleccionar un patrón de celosía. [IPatternFormat.BackColor](https://reference.aspose.com/slides/net/aspose.slides/ipatternformat/backcolor/) suministra el fondo gris claro, y [IPatternFormat.ForeColor](https://reference.aspose.com/slides/net/aspose.slides/ipatternformat/forecolor/) suministra el color amarillo del patrón.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
shape.FillFormat.FillType = FillType.Pattern;
shape.FillFormat.PatternFormat.PatternStyle = PatternStyle.Trellis;
shape.FillFormat.PatternFormat.BackColor.Color = Color.LightGray;
shape.FillFormat.PatternFormat.ForeColor.Color = Color.Yellow;

presentation.Save("pattern_fill.pptx", SaveFormat.Pptx);
```

El resultado:

![El rectángulo con relleno de patrón](pattern-fill.png)

## **Relleno de imagen**

Un relleno de imagen usa una imagen dentro de una forma. Este ejemplo necesita una imagen local y utiliza [Images.FromFile](https://reference.aspose.com/slides/net/aspose.slides/images/fromfile/) para cargarla en la colección de imágenes de la presentación. Establecer [IPictureFillFormat.PictureFillMode](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/picturefillmode/) en el modo mosaico repite la imagen dentro del rectángulo. La imagen fuente utilizada aquí se muestra a continuación:

![La imagen del loto](lotus.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);
shape.FillFormat.FillType = FillType.Picture;
shape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Tile;

using var image = Images.FromFile("lotus.png");
var presentationImage = presentation.Images.AddImage(image);
shape.FillFormat.PictureFillFormat.Picture.Image = presentationImage;

presentation.Save("picture_fill.pptx", SaveFormat.Pptx);
```

El resultado:

![La forma con relleno de imagen](picture-fill.png)

### **Repetir imagen como textura**

Si desea establecer una imagen en mosaico como textura y personalizar el comportamiento del mosaico, puede usar las siguientes propiedades de la interfaz [IPictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/) y la clase [PictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/):

- [PictureFillMode](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/picturefillmode/): Establece el modo de relleno de imagen — `Tile` o `Stretch`.
- [TileAlignment](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tilealignment/): Especifica la alineación de los mosaicos dentro de la forma.
- [TileFlip](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tileflip/): Controla si el mosaico se voltea horizontalmente, verticalmente o en ambas direcciones.
- [TileOffsetX](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tileoffsetx/): Establece el desplazamiento horizontal del mosaico (en puntos) desde el origen de la forma.
- [TileOffsetY](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tileoffsety/): Establece el desplazamiento vertical del mosaico (en puntos) desde el origen de la forma.
- [TileScaleX](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tilescalex/): Define la escala horizontal del mosaico como porcentaje.
- [TileScaleY](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tilescaley/): Define la escala vertical del mosaico como porcentaje.

Este ejemplo necesita una imagen local y configura [IPictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/) para repetirla al 50 % de su tamaño original. Desplazamientos de −32 puntos desplazan los mosaicos horizontal y verticalmente; la alineación inferior‑derecha y el volteo en ambas direcciones determinan cómo se organiza la textura repetida.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var firstSlide = presentation.Slides[0];

var shape = firstSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);
shape.FillFormat.FillType = FillType.Picture;

using var sourceImage = Images.FromFile("lotus.png");
var presentationImage = presentation.Images.AddImage(sourceImage);

var pictureFillFormat = shape.FillFormat.PictureFillFormat;
pictureFillFormat.Picture.Image = presentationImage;
pictureFillFormat.PictureFillMode = PictureFillMode.Tile;
pictureFillFormat.TileOffsetX = -32;
pictureFillFormat.TileOffsetY = -32;
pictureFillFormat.TileScaleX = 50;
pictureFillFormat.TileScaleY = 50;
pictureFillFormat.TileAlignment = RectangleAlignment.BottomRight;
pictureFillFormat.TileFlip = TileFlip.FlipBoth;

presentation.Save("tile.pptx", SaveFormat.Pptx);
```

El resultado:

![Las opciones de mosaico](tile-options.png)

## **Relleno de color sólido**

Un relleno sólido otorga a una forma un color único y uniforme. Este ejemplo establece [IFillFormat.FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) al modo de relleno sólido y asigna amarillo mediante [IFillFormat.SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/solidfillcolor/), luego guarda el rectángulo en una presentación.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.Yellow;

presentation.Save("solid_color_fill.pptx", SaveFormat.Pptx);
```

El resultado:

![La forma con relleno de color sólido](solid-color-fill.png)

### **Copiar colores manteniendo referencias de tema**

Utilice [IColorFormat.CopyFrom](https://reference.aspose.com/slides/net/aspose.slides/icolorformat/copyfrom/) para copiar una definición de color, incluyendo su tipo de color, referencia de tema y transformaciones. Esto es útil al transferir un color de relleno entre formas que deben seguir el tema de la presentación. El método copia solo el color: no copia el tipo de relleno, contorno u otro formato de forma. Establezca explícitamente el [IFillFormat.FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) del destino.

Este ejemplo crea tres rectángulos, de izquierda a derecha: la fuente, una copia con conocimiento del tema y una copia RGB fija. La fuente usa [IColorFormat.SchemeColor](https://reference.aspose.com/slides/net/aspose.slides/icolorformat/schemecolor/) para referenciar el primer color de acento y añade un tono mediante [IColorOperationCollection.Add](https://reference.aspose.com/slides/net/aspose.slides/icoloroperationcollection/add/). La copia RGB usa el color de relleno efectivo de la fuente, por lo que los tres inicialmente se ven idénticos. Asignar [IColorFormat.Color](https://reference.aspose.com/slides/net/aspose.slides/icolorformat/color/) establece un valor RGB fijo y elimina cualquier transformación de color existente.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(660, 220, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

presentation.MasterTheme.ColorScheme.Accent1.Color = Color.RoyalBlue;

var source = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 40, 180, 140);
var themeCopy = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 240, 40, 180, 140);
var rgbCopy = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 450, 40, 180, 140);

foreach (var shape in new[] { source, themeCopy, rgbCopy })
{
    shape.FillFormat.FillType = FillType.Solid;
    shape.LineFormat.FillFormat.FillType = FillType.NoFill;
}

var sourceColor = source.FillFormat.SolidFillColor;
sourceColor.SchemeColor = SchemeColor.Accent1;
sourceColor.ColorTransform.Add(ColorTransformOperation.Tint, 0.75f);

themeCopy.FillFormat.SolidFillColor.CopyFrom(sourceColor);
rgbCopy.FillFormat.SolidFillColor.Color = source.FillFormat.GetEffective().SolidFillColor;

using var before = slide.GetImage(1f, 1f);
before.Save("color-copy-before.png", ImageFormat.Png);

// Las referencias de tema siguen el nuevo color de acento; el valor RGB fijo no lo hace.
presentation.MasterTheme.ColorScheme.Accent1.Color = Color.OrangeRed;

using var after = slide.GetImage(1f, 1f);
after.Save("color-copy-after.png", ImageFormat.Png);
presentation.Save("copied_colors.pptx", SaveFormat.Pptx);
```

Antes del cambio de tema, los tres rellenos coinciden:

![Fuente, destino CopyFrom y destino RGB fijo con rellenos azules idénticos](color-copy-before.png)

Después del cambio de tema, la fuente y la copia con conocimiento del tema siguen el nuevo color de acento y conservan su tono. La copia RGB fija permanece azul:

![Fuente y destino CopyFrom con rellenos naranjas, mientras que el destino RGB fijo sigue azul](color-copy-after.png)

La definición copiada es independiente de la fuente. Cambiar posteriormente la referencia de tema de la fuente, asignar otro color o añadir o eliminar sus transformaciones no cambia el destino. Un cambio de tema sigue afectando a ambas formas porque cada una refiere independientemente al mismo color de tema.

Guardar y volver a abrir el PPTX conserva el [IColorFormat.ColorType](https://reference.aspose.com/slides/net/aspose.slides/icolorformat/colortype/), la referencia de tema y la colección [IColorFormat.ColorTransform](https://reference.aspose.com/slides/net/aspose.slides/icolorformat/colortransform/) del color copiado; no aplana la definición a RGB.

Al copiar entre diferentes contextos de tema, como presentaciones con paletas de acento distintas, la referencia copiada se resuelve contra el tema del destino. La misma referencia y transformaciones pueden producir un color visible diferente. Consulte [Presentation Theme](/slides/es/net/presentation-theme/) para más información sobre la configuración de colores de tema.

## **Usar el fondo de la diapositiva como relleno de forma**

Utilice [IAutoShape.UseBackgroundFill](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/usebackgroundfill/) cuando una forma debe coincidir con el fondo de la diapositiva, por ejemplo en una plantilla de presentación. Establezca [IFillFormat.FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) a [FillType.NotDefined](https://reference.aspose.com/slides/net/aspose.slides/filltype/) primero para eliminar cualquier relleno explícito. Con esta combinación, la forma usa el fondo de la diapositiva en lugar de su relleno de estilo. Activar solo la bandera no elimina un relleno explícito existente.

Esto difiere de [FillType.NoFill](https://reference.aspose.com/slides/net/aspose.slides/filltype/): el relleno de fondo cubre los objetos detrás de la forma con el área correspondiente del fondo de la diapositiva, mientras que sin relleno esos objetos permanecen visibles. Un degradado sigue alineado con la diapositiva en lugar de reiniciarse dentro de cada forma.

El siguiente ejemplo crea un fondo maestro heredado por la diapositiva y coloca una banda magenta detrás de tres rectángulos. El rectángulo izquierdo usa el fondo, el rectángulo central no tiene relleno y el rectángulo derecho cambia de relleno de fondo a un relleno naranja explícito.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(720, 400, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

// Heredar el degradado del maestro.
slide.Background.Type = BackgroundType.NotDefined;
slide.LayoutSlide.Background.Type = BackgroundType.NotDefined;
var background = slide.LayoutSlide.MasterSlide.Background;
background.Type = BackgroundType.OwnBackground;
background.FillFormat.FillType = FillType.Gradient;
var gradient = background.FillFormat.GradientFormat;
gradient.GradientShape = GradientShape.Linear;
gradient.LinearGradientAngle = 0;
gradient.GradientStops.Clear();
gradient.GradientStops.Add(0, Color.DarkBlue);
gradient.GradientStops.Add(1, Color.LightSkyBlue);

// Añadir este objeto primero para que aparezca detrás de los rectángulos.
var band = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 25, 150, 670, 100);
band.FillFormat.FillType = FillType.Solid;
band.FillFormat.SolidFillColor.Color = Color.Magenta;
band.LineFormat.FillFormat.FillType = FillType.NoFill;

var backgroundShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 100, 160, 200);
backgroundShape.FillFormat.FillType = FillType.NotDefined;
backgroundShape.UseBackgroundFill = true;

var noFillShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 280, 100, 160, 200);
noFillShape.FillFormat.FillType = FillType.NoFill;

var explicitShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 510, 100, 160, 200);
explicitShape.FillFormat.FillType = FillType.NotDefined;
explicitShape.UseBackgroundFill = true;

// Desactivar el relleno de fondo antes de aplicar un relleno explícito.
explicitShape.UseBackgroundFill = false;
explicitShape.FillFormat.FillType = FillType.Solid;
explicitShape.FillFormat.SolidFillColor.Color = Color.Orange;

presentation.Save("background_fill.pptx", SaveFormat.Pptx);
```

El resultado, de izquierda a derecha: **background fill**, **no fill** y **explicit fill**. La banda magenta está oculta por los rectángulos izquierdo y derecho, pero sigue visible a través del rectángulo central.

![Relleno de fondo, sin relleno y relleno naranja explícito sobre una banda magenta](background-fill.png)

El mismo comportamiento se aplica a un fondo definido directamente en la diapositiva o heredado de un diseño. La forma usa el fondo de diapositiva resuelto; el ejemplo deja los fondos de diapositiva y de diseño sin definir para que el maestro lo proporcione.

## **Establecer transparencia**

Para un relleno sólido, el componente alfa del color controla la opacidad: 0 es totalmente transparente y 255 es totalmente opaco. Este ejemplo usa un valor alfa de 128 para un rectángulo amarillo, haciéndolo aproximadamente 50 % transparente para que el rectángulo subyacente siga visible. El color se asigna mediante [IFillFormat.SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/solidfillcolor/).

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

const int alpha = 128;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var solidShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

var transparentShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
transparentShape.FillFormat.FillType = FillType.Solid;
transparentShape.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Yellow);

presentation.Save("shape_transparency.pptx", SaveFormat.Pptx);
```

El resultado:

![La forma transparente](shape-transparency.png)

## **Rotar formas**

Utilice [IShape.Rotation](https://reference.aspose.com/slides/net/aspose.slides/ishape/rotation/) para rotar una forma en el plano de la diapositiva. El ángulo se mide en grados; este ejemplo rota un rectángulo 5 grados en sentido horario y guarda la presentación.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
shape.Rotation = 5;

presentation.Save("shape_rotation.pptx", SaveFormat.Pptx);
```

El resultado:

![La rotación de la forma](shape-rotation.png)

## **Agregar efectos de bisel 3D**

Utilice [IShape.ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/threedformat/) para dar a una forma profundidad y bordes biselados. Este ejemplo crea una elipse verde con un contorno naranja, establece [IThreeDFormat.Depth](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/depth/) en 4 puntos y aplica un bisel superior circular con ancho y alto de 6 puntos mediante [IThreeDFormat.BevelTop](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/beveltop/). Una cámara ortográfica frontal y una iluminación de tres puntos hacen visible el bisel.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 50, 100, 100);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.Green;
shape.LineFormat.FillFormat.FillType = FillType.Solid;
shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Orange;
shape.LineFormat.Width = 2.0;
shape.ThreeDFormat.Depth = 4;
shape.ThreeDFormat.BevelTop.BevelType = BevelPresetType.Circle;
shape.ThreeDFormat.BevelTop.Height = 6;
shape.ThreeDFormat.BevelTop.Width = 6;
shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.ThreePt;
shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;

presentation.Save("3D_bevel_effect.pptx", SaveFormat.Pptx);
```

El resultado:

![El efecto de bisel 3D](3D-bevel-effect.png)

## **Agregar efectos de rotación 3D**

La vista 3D de una forma se controla mediante la configuración de su cámara. Este ejemplo usa [ICamera.SetRotation](https://reference.aspose.com/slides/net/aspose.slides/icamera/setrotation/) con ángulos de latitud, longitud y revolución de 40, 35 y 20 grados, respectivamente. Selecciona una cámara isométrica a través de [ICamera.CameraType](https://reference.aspose.com/slides/net/aspose.slides/icamera/cameratype/) y una iluminación equilibrada mediante [ILightRig.LightType](https://reference.aspose.com/slides/net/aspose.slides/ilightrig/lighttype/), luego guarda el rectángulo formateado.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
autoShape.TextFrame.Text = "Hello, Aspose!";
autoShape.ThreeDFormat.Camera.CameraType = CameraPresetType.IsometricLeftUp;
autoShape.ThreeDFormat.Camera.SetRotation(40, 35, 20);
autoShape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;

presentation.Save("3D_rotation_effect.pptx", SaveFormat.Pptx);
```

El resultado:

![El efecto de rotación 3D](3D-rotation-effect.png)

## **Controlar el renderizado en blanco y negro de las formas**

La propiedad [IShape.BlackWhiteMode](https://reference.aspose.com/slides/net/aspose.slides/ishape/blackwhitemode/) especifica cómo se renderiza una forma individual cuando una presentación se visualiza o procesa en modo blanco y negro. No habilita la visualización en blanco y negro por sí sola, y no cambia el relleno, la línea u otros formatos de la forma en modo de color normal.

Utilice un valor de la enumeración [BlackWhiteMode](https://reference.aspose.com/slides/net/aspose.slides/blackwhitemode/) para seleccionar el comportamiento deseado. Por ejemplo, `Automatic` permite que la aplicación de renderizado elija la conversión, `Gray` y `LightGray` usan color gris, `BlackWhite` usa solo negro y blanco, `Black` y `White` obligan a un solo color, `Color` conserva el color normal y `Hidden` omite la forma en modo blanco y negro. `NotDefined` indica que no se ha asignado ningún modo a nivel de forma.

Este ejemplo crea un rectángulo naranja y establece [IShape.BlackWhiteMode](https://reference.aspose.com/slides/net/aspose.slides/ishape/blackwhitemode/) a gris. La forma guardada conserva su relleno naranja para la visualización en color normal y solicita un color gris a las aplicaciones que respetan la configuración de visualización en blanco y negro:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.Orange;
shape.BlackWhiteMode = BlackWhiteMode.Gray;

presentation.Save("shape_black_white_mode.pptx", SaveFormat.Pptx);
```

En modo de color normal, el rectángulo conserva su relleno naranja. En un flujo de trabajo de visualización en blanco y negro, usa color gris porque su modo está configurado a `Gray`. Esto le permite conservar una diapositiva a todo color mientras define una apariencia distinta para impresión, vista previa u otros flujos de trabajo que respeten la configuración de visualización en blanco y negro de la presentación.

## **Restablecer formato**

Utilice [ISlide.Reset](https://reference.aspose.com/slides/net/aspose.slides/islide/reset/) para restaurar la posición, tamaño y formato de los marcadores de posición de la diapositiva a partir de sus marcadores de posición del diseño correspondiente. Este ejemplo requiere una presentación existente con marcadores de posición vinculados al diseño y restablece cada diapositiva antes de guardar. Las formas sin marcadores de posición del diseño correspondiente no se restablecen.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
foreach (var slide in presentation.Slides)
{
    slide.Reset();
}

presentation.Save("reset_formatting.pptx", SaveFormat.Pptx);
```

## **FAQ**

**¿Afecta el formato de la forma al tamaño final del archivo de la presentación?**

Los colores, estilos de línea y configuraciones de efectos generalmente añaden pocos datos en comparación con imágenes y medios incrustados. Los rellenos de imagen pueden aumentar el tamaño del archivo porque sus imágenes se almacenan en la presentación.

**¿Cómo puedo detectar formas en una diapositiva que compartan el mismo formato para poder agruparlas?**

Compare las propiedades clave de formato de cada forma — relleno, línea y configuraciones de efectos. Si todos los valores correspondientes coinciden, trate sus estilos como idénticos y agrupe lógicamente esas formas, lo que simplifica la gestión de estilos posterior.

**¿Puedo guardar un conjunto de estilos de forma personalizados en un archivo separado para reutilizarlos en otras presentaciones?**

Sí. Guarde formas de muestra con los estilos deseados en una presentación de plantilla o en un archivo plantilla .POTX. Al crear una nueva presentación, abra la plantilla, clone las formas con estilo que necesite y vuelva a aplicar su formato donde sea necesario.