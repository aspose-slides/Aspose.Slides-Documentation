---
title: Gestionar conectores en presentaciones en .NET
linktitle: Conector
type: docs
weight: 10
url: /es/net/connector/
keywords:
- conector
- tipo de conector
- punto de conector
- línea de conector
- ángulo de conector
- sitio de conexión
- punto de ajuste
- conectar formas
- PowerPoint
- presentación
- .NET
- C#
- Aspose.Slides
description: "Aprenda cómo añadir, unir, redirigir, ajustar e inspeccionar conectores rectos, doblados y curvos de PowerPoint con Aspose.Slides para .NET."
---
## **Visión general**

Un conector es una línea que puede permanecer unida a dos formas cuando cualquiera de ellas se mueve. Sus extremos se unen a sitios de conexión, representados por puntos verdes en PowerPoint. Algunos conectores doblados y curvos también exponen puntos de ajuste, representados por puntos naranjas, que controlan la posición de los segmentos individuales del conector.

Aspose.Slides representa los conectores a través de la interfaz [IConnector](https://reference.aspose.com/slides/es/net/aspose.slides/iconnector/). Puede crearlos, unir sus extremos a formas, elegir sitios de conexión, redirigirlos y modificar la geometría de los conectores que tienen puntos de ajuste.

## **Tipos de conector**

La enumeración [ShapeType](https://reference.aspose.com/slides/es/net/aspose.slides/shapetype/) incluye predefinidos de conectores rectos, doblados y curvos. La tabla siguiente muestra las geometrías de conector disponibles y el número de puntos de ajuste definidos por cada predefinido.

| Conector | Imagen | Número de puntos de ajuste |
|---|---|---|
| `ShapeType.Line` | ![shapetype-lineconnector](shapetype-lineconnector.png) | 0 |
| `ShapeType.StraightConnector1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0 |
| `ShapeType.BentConnector2` | ![shapetype-bent-connector2](shapetype-bent-connector2.png) | 0 |
| `ShapeType.BentConnector3` | ![shapetype-bentconnector3](shapetype-bentconnector3.png) | 1 |
| `ShapeType.BentConnector4` | ![shapetype-bentconnector4](shapetype-bentconnector4.png) | 2 |
| `ShapeType.BentConnector5` | ![shapetype-bentconnector5](shapetype-bentconnector5.png) | 3 |
| `ShapeType.CurvedConnector2` | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0 |
| `ShapeType.CurvedConnector3` | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1 |
| `ShapeType.CurvedConnector4` | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2 |
| `ShapeType.CurvedConnector5` | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3 |

El número y el significado de los puntos de ajuste forman parte del predefinido de conector seleccionado. No asuma que dos tipos de conector diferentes exponen la misma disposición de la colección.

## **Conectar dos formas**

Utilice [IShapeCollection.AddConnector](https://reference.aspose.com/slides/es/net/aspose.slides/ishapecollection/addconnector/) para añadir un conector, y asigne sus propiedades [StartShapeConnectedTo](https://reference.aspose.com/slides/es/net/aspose.slides/connector/startshapeconnectedto/) y [EndShapeConnectedTo](https://reference.aspose.com/slides/es/net/aspose.slides/connector/endshapeconnectedto/). Después de que ambos extremos estén unidos, [IConnector.Reroute](https://reference.aspose.com/slides/es/net/aspose.slides/iconnector/reroute/) selecciona una ruta corta entre las formas.

El siguiente ejemplo conecta una elipse y un rectángulo con un conector doblado:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var ellipse = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 40, 80, 120, 80);
var rectangle = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 320, 240, 140, 80);
var connector = slide.Shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

connector.StartShapeConnectedTo = ellipse;
connector.EndShapeConnectedTo = rectangle;
connector.Reroute();

presentation.Save("connected-shapes.pptx", SaveFormat.Pptx);
```

{{% alert color="warning" title="Warning" %}}

Llamar a `Reroute` puede cambiar los valores de [StartShapeConnectionSiteIndex](https://reference.aspose.com/slides/es/net/aspose.slides/connector/startshapeconnectionsiteindex/) y [EndShapeConnectionSiteIndex](https://reference.aspose.com/slides/es/net/aspose.slides/connector/endshapeconnectionsiteindex/). Asigne sitios de conexión específicos después de redirigir si esos sitios deben permanecer fijos.

{{% /alert %}}

## **Elegir un sitio de conexión**

Cada forma conectable informa su número de sitios mediante [ConnectionSiteCount](https://reference.aspose.com/slides/es/net/aspose.slides/shape/connectionsitecount/). Valide un índice de sitio preferido (basado en cero) antes de asignarlo a un extremo del conector; el recuento de sitios varía según la geometría de la forma.

Este ejemplo une el conector a un sitio concreto de la elipse cuando ese sitio existe:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var ellipse = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 40, 80, 120, 80);
var rectangle = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 320, 240, 140, 80);
var connector = slide.Shapes.AddConnector(ShapeType.BentConnector3, 0, 0, 10, 10);

connector.StartShapeConnectedTo = ellipse;
connector.EndShapeConnectedTo = rectangle;

uint preferredSiteIndex = 2;
if (preferredSiteIndex < ellipse.ConnectionSiteCount)
{
    connector.StartShapeConnectionSiteIndex = preferredSiteIndex;
}
else
{
    Console.WriteLine($"The ellipse has only {ellipse.ConnectionSiteCount} connection sites.");
}

presentation.Save("specific-connection-site.pptx", SaveFormat.Pptx);
```

## **Ajustar un punto de conector**

Los conectores con puntos de ajuste los exponen a través de [IGeometryShape.Adjustments](https://reference.aspose.com/slides/es/net/aspose.slides/igeometryshape/adjustments/). Examine cada [IAdjustValue](https://reference.aspose.com/slides/es/net/aspose.slides/iadjustvalue/) y compruebe su [Type](https://reference.aspose.com/slides/es/net/aspose.slides/adjustvalue/type/) antes de cambiar su [RawValue](https://reference.aspose.com/slides/es/net/aspose.slides/adjustvalue/rawvalue/). Las reglas generales para identificar los ajustes predefinidos de forma se describen en [Shape Manipulation](/slides/es/net/shape-manipulations/).

El número, orden, significado y rango de valores válidos de los ajustes del conector dependen del predefinido del conector. La propiedad `Type` es de solo lectura, mientras que el valor de ajuste es modificable. La propiedad de solo lectura [Name](https://reference.aspose.com/slides/es/net/aspose.slides/adjustvalue/name/) brinda identificación adicional cuando un conector contiene más de un ajuste del mismo tipo semántico.

### **Ruta alrededor de un obstáculo**

En el siguiente diseño, un conector `BentConnector5` entre dos formas pasa a través de una tercera forma:

![connector-obstruction](connector-obstruction.png)

Este código crea el conector obstruido:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

slide.Shapes.AddAutoShape(ShapeType.Rectangle, 300, 150, 150, 75);
var sourceShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 400, 100, 50);
var targetShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 70, 30);
var connector = slide.Shapes.AddConnector(ShapeType.BentConnector5, 20, 20, 400, 300);

connector.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;
connector.LineFormat.FillFormat.FillType = FillType.Solid;
connector.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
connector.StartShapeConnectedTo = sourceShape;
connector.EndShapeConnectedTo = targetShape;
connector.StartShapeConnectionSiteIndex = 2;

presentation.Save("connector-obstruction.pptx", SaveFormat.Pptx);
```

Mover el doble vertical cambia la ruta de manera que el conector rodea el obstáculo:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

En lugar de suponer que el índice de colección `1` siempre representa el doble vertical, este ejemplo busca `ConnectorBendPositionY` y lo cambia solo cuando el tipo semántico esperado está presente:

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

slide.Shapes.AddAutoShape(ShapeType.Rectangle, 300, 150, 150, 75);
var sourceShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 400, 100, 50);
var targetShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 70, 30);
var connector = slide.Shapes.AddConnector(ShapeType.BentConnector5, 20, 20, 400, 300);

connector.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;
connector.LineFormat.FillFormat.FillType = FillType.Solid;
connector.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
connector.StartShapeConnectedTo = sourceShape;
connector.EndShapeConnectedTo = targetShape;
connector.StartShapeConnectionSiteIndex = 2;

IAdjustValue? verticalBend = null;
for (var adjustmentIndex = 0; adjustmentIndex < connector.Adjustments.Count; adjustmentIndex++)
{
    var adjustment = connector.Adjustments[adjustmentIndex];
    Console.WriteLine($"{adjustment.Name}: {adjustment.Type}, raw value = {adjustment.RawValue}");
    if (adjustment.Type == ShapeAdjustmentType.ConnectorBendPositionY)
    {
        verticalBend = adjustment;
        break;
    }
}

if (verticalBend is null)
{
    Console.WriteLine("The connector does not expose a vertical bend adjustment.");
}
else
{
    verticalBend.RawValue = 60000;
    presentation.Save("connector-obstruction-fixed.pptx", SaveFormat.Pptx);
}
```

Un `BentConnector5` tiene dos ajustes `ConnectorBendPositionX` y un ajuste `ConnectorBendPositionY`. Si el tipo que necesita aparece más de una vez, examine `Name` y la geometría conocida de ese predefinido antes de seleccionar uno. Si un ajuste informa `ShapeAdjustmentType.Custom`, trate su significado y rango como específicos del predefinido y no lo modifique hasta que se conozca ese contrato.

## **Relacionar valores de ajuste con la geometría del conector**

Para los conectores doblados, los valores de ajuste pueden usarse para estimar las posiciones de los segmentos individuales. Estos cálculos son específicos del predefinido del conector:

- `BentConnector4` normalmente expone un ajuste `ConnectorBendPositionX` y uno `ConnectorBendPositionY`.
- Para estas posiciones de doblez, `RawValue / 100000f` produce la fracción del ancho o alto del marco del conector usada en los ejemplos siguientes.
- Un marco de conector puede rotarse o voltearse, por lo que las coordenadas del marco deben transformarse antes de compararse con las coordenadas de la diapositiva.

Los ejemplos siguientes usan `Type` para identificar primero los ajustes. No tratan los índices de colección como identificadores portátiles.

### **Conector no rotado**

El diseño inicial contiene dos formas de texto conectadas por un `BentConnector4`:

![connector-shape-complex](connector-shape-complex.png)

Este ejemplo inspecciona el conector y obtiene sus ajustes de doble vertical y horizontal:

```csharp
using System;
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var sourceShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
sourceShape.TextFrame.Text = "From";
var targetShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 100, 60, 25);
targetShape.TextFrame.Text = "To";
var connector = slide.Shapes.AddConnector(ShapeType.BentConnector4, 20, 20, 400, 300);

connector.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;
connector.LineFormat.FillFormat.FillType = FillType.Solid;
connector.LineFormat.FillFormat.SolidFillColor.Color = Color.Crimson;
connector.LineFormat.Width = 3;
connector.StartShapeConnectedTo = sourceShape;
connector.StartShapeConnectionSiteIndex = 3;
connector.EndShapeConnectedTo = targetShape;
connector.EndShapeConnectionSiteIndex = 2;

for (var adjustmentIndex = 0; adjustmentIndex < connector.Adjustments.Count; adjustmentIndex++)
{
    var adjustment = connector.Adjustments[adjustmentIndex];
    Console.WriteLine($"{adjustment.Name}: {adjustment.Type}, raw value = {adjustment.RawValue}");
}
```

Para cambiar ambos dobleces, localice cada tipo esperado y modifique los valores solo después de haber encontrado ambos:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var sourceShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
var targetShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 100, 60, 25);
var connector = slide.Shapes.AddConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
connector.StartShapeConnectedTo = sourceShape;
connector.StartShapeConnectionSiteIndex = 3;
connector.EndShapeConnectedTo = targetShape;
connector.EndShapeConnectionSiteIndex = 2;

IAdjustValue? horizontalBend = null;
IAdjustValue? verticalBend = null;
for (var adjustmentIndex = 0; adjustmentIndex < connector.Adjustments.Count; adjustmentIndex++)
{
    var adjustment = connector.Adjustments[adjustmentIndex];
    if (adjustment.Type == ShapeAdjustmentType.ConnectorBendPositionX)
    {
        horizontalBend = adjustment;
    }
    else if (adjustment.Type == ShapeAdjustmentType.ConnectorBendPositionY)
    {
        verticalBend = adjustment;
    }
}

if (horizontalBend is null || verticalBend is null)
{
    Console.WriteLine("The connector does not expose the expected bend adjustments.");
}
else
{
    horizontalBend.RawValue += 20000;
    verticalBend.RawValue += 200000;
    presentation.Save("connector-adjusted.pptx", SaveFormat.Pptx);
}
```

El resultado es un conector cuyos segmentos horizontal y vertical se han desplazado:

![connector-adjusted-1](connector-adjusted-1.png)

Una vez conocidos los tipos semánticos, sus valores pueden convertirse a coordenadas del marco del conector. Este ejemplo dibuja un rectángulo delgado sobre el segmento vertical controlado por los dos ajustes de doblez:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var sourceShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
var targetShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 100, 60, 25);
var connector = slide.Shapes.AddConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
connector.StartShapeConnectedTo = sourceShape;
connector.StartShapeConnectionSiteIndex = 3;
connector.EndShapeConnectedTo = targetShape;
connector.EndShapeConnectionSiteIndex = 2;

IAdjustValue? horizontalBend = null;
IAdjustValue? verticalBend = null;
for (var adjustmentIndex = 0; adjustmentIndex < connector.Adjustments.Count; adjustmentIndex++)
{
    var adjustment = connector.Adjustments[adjustmentIndex];
    if (adjustment.Type == ShapeAdjustmentType.ConnectorBendPositionX)
    {
        horizontalBend = adjustment;
    }
    else if (adjustment.Type == ShapeAdjustmentType.ConnectorBendPositionY)
    {
        verticalBend = adjustment;
    }
}

if (horizontalBend is null || verticalBend is null)
{
    Console.WriteLine("The connector does not expose the expected bend adjustments.");
}
else
{
    var x = connector.X + connector.Width * horizontalBend.RawValue / 100000f;
    var y = connector.Y;
    var height = connector.Height * verticalBend.RawValue / 100000f;
    slide.Shapes.AddAutoShape(ShapeType.Rectangle, x, y, 1, height);
    presentation.Save("connector-segment-guide.pptx", SaveFormat.Pptx);
}
```

La forma guía marca el segmento calculado:

![connector-adjusted-2](connector-adjusted-2.png)

### **Conector girado o volteado**

Cuando la misma geometría de conector está orientada verticalmente, sus valores [Frame](https://reference.aspose.com/slides/es/net/aspose.slides/ishape/frame/), [FlipH](https://reference.aspose.com/slides/es/net/aspose.slides/shapeframe/fliph/), y [FlipV](https://reference.aspose.com/slides/es/net/aspose.slides/shapeframe/flipv/) afectan la conversión de coordenadas del marco del conector a coordenadas de la diapositiva.

Este ejemplo crea y ajusta el conector orientado verticalmente:

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var sourceShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
sourceShape.TextFrame.Text = "From";
var targetShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 400, 60, 25);
targetShape.TextFrame.Text = "To 1";
var connector = slide.Shapes.AddConnector(ShapeType.BentConnector4, 20, 20, 400, 300);

connector.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;
connector.LineFormat.FillFormat.FillType = FillType.Solid;
connector.LineFormat.FillFormat.SolidFillColor.Color = Color.MediumAquamarine;
connector.LineFormat.Width = 3;
connector.StartShapeConnectedTo = sourceShape;
connector.StartShapeConnectionSiteIndex = 2;
connector.EndShapeConnectedTo = targetShape;
connector.EndShapeConnectionSiteIndex = 3;

for (var adjustmentIndex = 0; adjustmentIndex < connector.Adjustments.Count; adjustmentIndex++)
{
    var adjustment = connector.Adjustments[adjustmentIndex];
    if (adjustment.Type == ShapeAdjustmentType.ConnectorBendPositionX)
    {
        adjustment.RawValue += 20000;
    }
    else if (adjustment.Type == ShapeAdjustmentType.ConnectorBendPositionY)
    {
        adjustment.RawValue += 200000;
    }
}

presentation.Save("vertical-connector-adjusted.pptx", SaveFormat.Pptx);
```

El conector ajustado aparece verticalmente entre las formas:

![connector-adjusted-3](connector-adjusted-3.png)

Para un ángulo de rotación arbitrario `alpha`, rote un punto del marco del conector `(x, y)` alrededor del centro del marco `(x0, y0)`:

`X = (x - x0) * cos(alpha) - (y - y0) * sin(alpha) + x0`

`Y = (x - x0) * sin(alpha) + (y - y0) * cos(alpha) + y0`

El código siguiente gestiona la orientación de 90 grados usada en este ejemplo y dibuja una guía roja sobre el segmento correspondiente del conector:

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var sourceShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
var targetShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 400, 60, 25);
var connector = slide.Shapes.AddConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
connector.StartShapeConnectedTo = sourceShape;
connector.StartShapeConnectionSiteIndex = 2;
connector.EndShapeConnectedTo = targetShape;
connector.EndShapeConnectionSiteIndex = 3;

IAdjustValue? horizontalBend = null;
IAdjustValue? verticalBend = null;
for (var adjustmentIndex = 0; adjustmentIndex < connector.Adjustments.Count; adjustmentIndex++)
{
    var adjustment = connector.Adjustments[adjustmentIndex];
    if (adjustment.Type == ShapeAdjustmentType.ConnectorBendPositionX)
    {
        horizontalBend = adjustment;
    }
    else if (adjustment.Type == ShapeAdjustmentType.ConnectorBendPositionY)
    {
        verticalBend = adjustment;
    }
}

if (horizontalBend is null || verticalBend is null)
{
    Console.WriteLine("The connector does not expose the expected bend adjustments.");
}
else
{
    horizontalBend.RawValue += 20000;
    verticalBend.RawValue += 200000;

    var x = connector.X;
    var y = connector.Y;
    if (connector.Frame.FlipH == NullableBool.True)
    {
        x += connector.Width;
    }
    if (connector.Frame.FlipV == NullableBool.True)
    {
        y += connector.Height;
    }

    x += connector.Width * horizontalBend.RawValue / 100000f;
    var rotatedX = connector.Frame.CenterX - y + connector.Frame.CenterY;
    var rotatedY = x - connector.Frame.CenterX + connector.Frame.CenterY;
    var segmentWidth = connector.Height * verticalBend.RawValue / 100000f;
    var guide = slide.Shapes.AddAutoShape(ShapeType.Rectangle, rotatedX, rotatedY, segmentWidth, 1);
    guide.LineFormat.FillFormat.FillType = FillType.Solid;
    guide.LineFormat.FillFormat.SolidFillColor.Color = Color.Red;

    presentation.Save("rotated-connector-segment-guide.pptx", SaveFormat.Pptx);
}
```

La guía roja marca el segmento calculado después de la transformación de coordenadas:

![connector-adjusted-4](connector-adjusted-4.png)

Estas fórmulas describen los predefinidos usados en los ejemplos, no un modelo universal de conectores. Valide los tipos de ajuste, la orientación del marco y los rangos de valores antes de aplicar el mismo cálculo a un predefinido diferente.

## **Encontrar el ángulo de dirección del conector**

La dirección de un conector recto puede calcularse a partir de su ancho y alto, con los volteos horizontal y vertical aplicados. El siguiente ejemplo informa el ángulo en sentido horario desde el eje horizontal positivo en coordenadas de diapositiva:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var connector = slide.Shapes.AddConnector(ShapeType.StraightConnector1, 100, 100, 200, 100);

var flipH = connector.Frame.FlipH == NullableBool.True;
var flipV = connector.Frame.FlipV == NullableBool.True;
var deltaX = connector.Width * (flipH ? -1 : 1);
var deltaY = connector.Height * (flipV ? -1 : 1);
var angle = Math.Atan2(deltaY, deltaX) * 180.0 / Math.PI;

if (angle < 0)
{
    angle += 360;
}

Console.WriteLine($"Connector direction: {angle:F2} degrees");
```

## **Preguntas frecuentes**

**¿Cómo puedo saber si un conector puede unirse a una forma?**

Compruebe el `ConnectionSiteCount` de la forma. Un recuento positivo indica que la forma expone sitios de conexión. Valide el índice de sitio seleccionado antes de asignarlo a cualquiera de los extremos del conector.

**¿Puedo identificar un ajuste de conector por su índice de colección?**

Un índice tiene significado solo para un predefinido de conector conocido y la disposición de su colección. Verifique `IAdjustValue.Type` antes de modificar un valor, y use `IAdjustValue.Name` como información adicional cuando el mismo tipo semántico aparece más de una vez.

**¿Qué ocurre cuando se elimina una forma conectada?**

El extremo correspondiente del conector queda desacoplado. El conector permanece en la diapositiva y puede eliminarse, posicionarse como una línea libre o unirse a otra forma.

**¿Se conservan los enlaces de los conectores al copiar una diapositiva?**

Los enlaces generalmente se conservan cuando las formas conectadas se copian con la diapositiva. Si se copia un conector sin una de sus formas objetivo, el extremo afectado debe volver a unirse.