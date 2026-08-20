---
title: Gestionar formas de presentación en .NET
linktitle: Manipulación de formas
type: docs
weight: 40
url: /es/net/shape-manipulations/
keywords:
- Forma de PowerPoint
- Forma de presentación
- Forma en diapositiva
- Buscar forma
- Clonar forma
- Eliminar forma
- Ocultar forma
- Cambiar orden de forma
- Obtener ID de forma interop
- Texto alternativo de forma
- Formatos de diseño de forma
- Forma como SVG
- Forma a SVG
- Alinear forma
- Voltear forma
- PowerPoint
- presentación
- .NET
- C#
- Aspose.Slides
description: "Aprenda a identificar, clonar, eliminar, ocultar, reordenar, exportar, alinear y voltear formas de presentación con Aspose.Slides para .NET."
---
## **Visión general**

Aspose.Slides for .NET representa las formas en una diapositiva como una [IShapeCollection](https://reference.aspose.com/slides/es/net/aspose.slides/ishapecollection/) ordenada. La colección es tanto el lugar donde se encuentran y modifican las formas como la fuente de su orden de apilamiento: el índice `0` es la forma más trasera, mientras que el último índice es la forma más delantera.

Este artículo sigue ese modelo. Primero explica cómo identificar una forma de forma fiable, luego muestra cómo clonar, eliminar, ocultar y reordenar formas. Las secciones finales cubren el formato a nivel de diseño, la exportación a SVG, la alineación y los ajustes de inversión. Cada ejemplo es independiente, por lo que puede usar solo las operaciones que requiere su flujo de trabajo.

## **Identificar y buscar formas**

Los índices de la colección son convenientes al procesar un archivo conocido, pero no son identificadores estables. Añadir, eliminar o reordenar una forma puede cambiar su índice. Elija un identificador según cómo se crea y mantiene la presentación:

- [Name](https://reference.aspose.com/slides/es/net/aspose.slides/ishape/name/) es útil para plantillas controladas por desarrolladores y es fácil de inspeccionar en el panel de selección de PowerPoint. Los nombres pueden editarse y no se garantiza que sean únicos, por lo que debe establecer una convención de nombres si el código depende de ellos.
- [AlternativeText](https://reference.aspose.com/slides/es/net/aspose.slides/ishape/alternativetext/) es útil cuando una descripción de accesibilidad o una etiqueta proporcionada por el autor ya identifica la forma. Es visible para los usuarios, puede localizarse o reescribirse para accesibilidad, y no se garantiza que sea única. No reutilice silenciosamente texto de accesibilidad significativo como clave de base de datos.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/es/net/aspose.slides/ishape/officeinteropshapeid/) es un identificador de solo lectura que es único dentro de una diapositiva y corresponde al ID de forma utilizado por la interoperabilidad de PowerPoint. Úselo al integrar con PowerPoint o cuando necesite una referencia inequívoca durante la vida útil de una forma. Una forma clonada o recreada es una forma diferente y recibe su propio ID.

La propiedad relacionada [UniqueId](https://reference.aspose.com/slides/es/net/aspose.slides/ishape/uniqueid/) tiene alcance a nivel de presentación, pero está destinada a complementos y puede reasignarse. No debe tratarse como una clave externa permanente. Si la identidad a largo plazo es esencial, mantenga el mapeo en los datos de la aplicación y valide que la forma esperada siga existiendo.

El siguiente ejemplo busca por `Name` con una comparación ordinal y reporta el ID de interop a nivel de diapositiva. Cuando la plantilla no contiene la forma esperada, el código informa ese resultado en lugar de continuar con el objeto incorrecto.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");
var slide = presentation.Slides[0];

IShape? targetShape = null;
foreach (var shape in slide.Shapes)
{
    if (string.Equals(shape.Name, "RevenueChart", StringComparison.Ordinal))
    {
        targetShape = shape;
        break;
    }
}

if (targetShape is null)
{
    Console.WriteLine("The shape 'RevenueChart' was not found on slide 1.");
}
else
{
    Console.WriteLine($"Found {targetShape.Name}; interop ID: {targetShape.OfficeInteropShapeId}");
}
```

Cuando una operación es específica de un tipo de forma, compruebe la interfaz antes de usar miembros específicos del tipo. Este ejemplo actualiza el texto y el texto alternativo solo si el objeto con nombre es un [IAutoShape](https://reference.aspose.com/slides/es/net/aspose.slides/iautoshape/).

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");
var slide = presentation.Slides[0];

IShape? candidate = null;
foreach (var shape in slide.Shapes)
{
    if (string.Equals(shape.Name, "StatusLabel", StringComparison.Ordinal))
    {
        candidate = shape;
        break;
    }
}

if (candidate is IAutoShape autoShape)
{
    autoShape.TextFrame.Text = "Approved";
    autoShape.AlternativeText = "Approval status: approved";
    presentation.Save("identified-shape.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("'StatusLabel' is missing or is not an AutoShape.");
}
```

## **Modificar la colección de formas**

Los métodos add, clone, remove y reorder operan sobre la colección de forma inmediata. Si una operación cambia el número o el orden de las formas, no continúe confiando en los índices capturados antes de esa operación.

### **Clonar una forma**

[AddClone](https://reference.aspose.com/slides/es/net/aspose.slides/ishapecollection/addclone/) crea una copia independiente y la añade al final de la colección de destino. [InsertClone](https://reference.aspose.com/slides/es/net/aspose.slides/ishapecollection/insertclone/) también crea una copia pero la coloca en un índice de orden Z especificado. Las sobrecargas que aceptan coordenadas mueven la copia sin cambiar su tamaño; las sobrecargas con ancho y alto pueden redimensionarla también.

El ejemplo crea una diapositiva de destino, clona un rectángulo etiquetado al frente e inserta una segunda copia al fondo. Los cambios en cualquiera de las copias no modifican la forma original.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var sourceSlide = presentation.Slides[0];
var sourceShape = sourceSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 180, 60);
sourceShape.Name = "SourceLabel";
sourceShape.TextFrame.Text = "Source";

var blankLayout = presentation.Masters[0].LayoutSlides.GetByType(SlideLayoutType.Blank);
var destinationSlide = presentation.Slides.AddEmptySlide(blankLayout);

var frontCloneShape = destinationSlide.Shapes.AddClone(sourceShape, 80, 80);
frontCloneShape.Name = "FrontClone";
if (frontCloneShape is IAutoShape frontClone)
{
    frontClone.TextFrame.Text = "Front clone";
}
else
{
    Console.WriteLine("The front clone is not an AutoShape; its text was not changed.");
}

var backCloneShape = destinationSlide.Shapes.InsertClone(0, sourceShape, 80, 180);
backCloneShape.Name = "BackClone";
if (backCloneShape is IAutoShape backClone)
{
    backClone.TextFrame.Text = "Back clone";
}
else
{
    Console.WriteLine("The back clone is not an AutoShape; its text was not changed.");
}

presentation.Save("cloned-shapes.pptx", SaveFormat.Pptx);
```

Clonar copia el contenido y el formato de la forma, incluido su nombre y texto alternativo. Asigne nuevos identificadores lógicos a la copia cuando esos valores deben ser únicos. Los recursos utilizados por formas complejas son gestionados por la presentación, pero una copia sigue siendo un nuevo elemento de la colección con una nueva identidad de forma.

### **Eliminar formas**

[Remove](https://reference.aspose.com/slides/es/net/aspose.slides/ishapecollection/remove/) elimina un objeto de forma específico de su colección. Cuando se eliminan varias coincidencias durante una iteración indexada, recorra desde el final para que cada índice restante siga siendo válido.

Este ejemplo elimina cada forma con un nombre designado. Lee `slide.Shapes[i]`, no un elemento de colección fijo, y no convierte la forma innecesariamente.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var keepShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 140, 60);
keepShape.Name = "Keep";

var firstTemporaryShape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 220, 40, 80, 80);
firstTemporaryShape.Name = "Temporary";

var secondTemporaryShape = slide.Shapes.AddAutoShape(ShapeType.Triangle, 340, 40, 100, 80);
secondTemporaryShape.Name = "Temporary";

for (var i = slide.Shapes.Count - 1; i >= 0; i--)
{
    var shape = slide.Shapes[i];
    if (string.Equals(shape.Name, "Temporary", StringComparison.Ordinal))
    {
        slide.Shapes.Remove(shape);
    }
}

presentation.Save("removed-shapes.pptx", SaveFormat.Pptx);
```

Después de la eliminación, el recuento de formas y los índices de las formas posteriores cambian. Las referencias a formas no afectadas siguen siendo más fiables que los índices guardados. También considere conectores, animaciones y otras características de la presentación que puedan referirse al objeto eliminado; eliminar una forma visible puede cambiar más que la apariencia de la diapositiva.

### **Ocultar una forma**

Establecer [Hidden](https://reference.aspose.com/slides/es/net/aspose.slides/ishape/hidden/) a `true` mantiene la forma en la colección pero impide que aparezca en la presentación normal. Su índice, formato y contenido siguen disponibles para el código, por lo que ocultar es apropiado para elementos opcionales que pueden restaurarse más tarde.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var visibleShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 160, 60);
visibleShape.Name = "VisibleLabel";

var optionalShape = slide.Shapes.AddAutoShape(ShapeType.Moon, 240, 40, 100, 100);
optionalShape.Name = "OptionalDecoration";

foreach (var shape in slide.Shapes)
{
    if (string.Equals(shape.Name, "OptionalDecoration", StringComparison.Ordinal))
    {
        shape.Hidden = true;
    }
}

presentation.Save("hidden-shape.pptx", SaveFormat.Pptx);
```

Ocultar no es eliminación ni seguridad. El objeto todavía puede ser descubierto y vuelto a mostrar por un usuario o por código, y sigue formando parte del archivo de la presentación.

### **Cambiar el orden Z**

Las formas superpuestas se dibujan según el orden de la colección. [Reorder](https://reference.aspose.com/slides/es/net/aspose.slides/ishapecollection/reorder/) mueve una forma existente a un índice objetivo sin clonarla. El índice `0` es el fondo; `Count - 1` es el frente.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var blueRectangle = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 220, 120);
blueRectangle.Name = "BlueRectangle";
blueRectangle.FillFormat.FillType = FillType.Solid;
blueRectangle.FillFormat.SolidFillColor.Color = Color.SteelBlue;

var orangeEllipse = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 180, 140, 220, 120);
orangeEllipse.Name = "OrangeEllipse";
orangeEllipse.FillFormat.FillType = FillType.Solid;
orangeEllipse.FillFormat.SolidFillColor.Color = Color.Orange;

slide.Shapes.Reorder(slide.Shapes.Count - 1, blueRectangle);
presentation.Save("reordered-shapes.pptx", SaveFormat.Pptx);
```

El rectángulo se crea primero y inicialmente se sitúa detrás de la elipse. Moviéndolo al índice final lo coloca al frente. Finalice el orden Z después de añadir o clonar todas las formas relacionadas, porque esas operaciones añaden o insertan nuevos elementos en la colección y pueden alterar la pila prevista.

## **Inspeccionar formas en diapositivas de diseño**

Las diapositivas normales, de diseño y maestras tienen colecciones de formas separadas. Una forma en una colección de diseño no es el mismo objeto que una forma posicionada de forma similar en una diapositiva normal. Inspeccione las formas de diseño cuando necesite comprender o cambiar el formato suministrado por un diseño.

El siguiente ejemplo lee el [FillFormat](https://reference.aspose.com/slides/es/net/aspose.slides/ishape/fillformat/) y el [LineFormat](https://reference.aspose.com/slides/es/net/aspose.slides/ishape/lineformat/) de cada forma de diseño sin asumir que cada forma es un `AutoShape`.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");

foreach (var layoutSlide in presentation.LayoutSlides)
{
    foreach (var shape in layoutSlide.Shapes)
    {
        var fillType = shape.FillFormat.FillType;
        var lineWidth = shape.LineFormat.Width;
        Console.WriteLine($"{layoutSlide.Name} / {shape.Name}: fill={fillType}, line width={lineWidth}");
    }
}
```

Editar un diseño puede afectar a varias diapositivas que lo usan. Antes de cambiar una forma de diseño, determine si una diapositiva normal hereda el objeto o contiene una sobrescritura local, y pruebe cada diapositiva que use ese diseño.

## **Exportar una forma a SVG**

[WriteAsSvg](https://reference.aspose.com/slides/es/net/aspose.slides/ishape/writeassvg/) escribe el contenido renderizado de una forma a un flujo. El resultado contiene la forma, no todo el fondo de la diapositiva ni las formas adyacentes.

```csharp
using System;
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");
var slide = presentation.Slides[0];

if (slide.Shapes.Count == 0)
{
    Console.WriteLine("Slide 1 does not contain a shape to export.");
}
else
{
    var shape = slide.Shapes[0];
    using var svgStream = File.Create("shape.svg");
    shape.WriteAsSvg(svgStream);
}
```

Mantenga la presentación abierta mientras renderiza. La salida depende del formato de la forma y de recursos como fuentes e imágenes. Si necesita la composición completa, exporte la diapositiva en lugar de una forma individual. El llamador posee el flujo y debe disponerlo.

## **Alinear formas**

Las sobrecargas de [SlideUtil.AlignShapes](https://reference.aspose.com/slides/es/net/aspose.slides.util/slideutil/alignshapes/) alinean ya sea todas las formas o los índices de colección seleccionados. [ShapesAlignmentType](https://reference.aspose.com/slides/es/net/aspose.slides/shapesalignmenttype/) especifica el borde, la línea central o el modo de distribución. Establezca `alignToSlide` a `true` para usar los bordes de la diapositiva; establézcalo a `false` para alinear las formas seleccionadas entre sí.

Este ejemplo alinea tres formas al borde superior de la diapositiva. Las referencias a las formas devueltas se convierten a sus índices actuales inmediatamente antes de la alineación.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Util;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var firstShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 60, 80, 120, 50);
var secondShape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 240, 160, 120, 50);
var thirdShape = slide.Shapes.AddAutoShape(ShapeType.Triangle, 420, 240, 120, 50);
firstShape.Name = "FirstAlignedShape";
secondShape.Name = "SecondAlignedShape";
thirdShape.Name = "ThirdAlignedShape";

var shapeIndexes = new[]
{
    slide.Shapes.IndexOf(firstShape),
    slide.Shapes.IndexOf(secondShape),
    slide.Shapes.IndexOf(thirdShape)
};

SlideUtil.AlignShapes(ShapesAlignmentType.AlignTop, true, slide, shapeIndexes);
presentation.Save("aligned-shapes.pptx", SaveFormat.Pptx);
```

La alineación cambia posiciones, no el orden Z. La alineación relativa normalmente necesita al menos dos formas, mientras que la distribución horizontal o vertical requiere suficientes formas para definir el espaciado. Recalcule los índices si modifica la colección antes de llamar al método.

## **Voltear una forma**

La clase [ShapeFrame](https://reference.aspose.com/slides/es/net/aspose.slides/shapeframe/) almacena la posición, el tamaño, los ajustes de volteo horizontal y vertical, y la rotación. Sus valores `FlipH` y `FlipV` usan [NullableBool](https://reference.aspose.com/slides/es/net/aspose.slides/nullablebool/): `True` activa el volteo, `False` lo desactiva, y `NotDefined` conserva el estado no especificado/predeterminado.

La presentación de entrada a continuación contiene una forma sin voltear.

![La forma antes de voltear](shape_to_be_flipped.png)

El ejemplo conserva todos los demás valores del marco y reemplaza solo los dos ajustes de volteo. Esto es importante porque asignar un nuevo [Frame](https://reference.aspose.com/slides/es/net/aspose.slides/ishape/frame/) reemplaza el marco completo.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var shape = presentation.Slides[0].Shapes[0];
var frame = shape.Frame;

Console.WriteLine($"Horizontal flip before change: {frame.FlipH}");
Console.WriteLine($"Vertical flip before change: {frame.FlipV}");

shape.Frame = new ShapeFrame(
    frame.X, frame.Y, frame.Width, frame.Height,
    NullableBool.True, NullableBool.True, frame.Rotation);

presentation.Save("flipped-shape.pptx", SaveFormat.Pptx);
```

La forma guardada se refleja horizontal y verticalmente manteniendo su posición, tamaño y rotación.

![La forma después de voltear](flipped_shape.png)

## **Preguntas frecuentes**

**¿Debo usar un índice de colección como identificador de forma?**

Solo para procesamiento de corta duración cuando la colección no cambiará antes de que se use el índice. Prefiera una convención validada de `Name` o `AlternativeText` para plantillas creadas, o `OfficeInteropShapeId` para trabajos de interop a nivel de diapositiva.

**¿Ocultar una forma la elimina del orden Z?**

No. Una forma oculta permanece en la colección en el mismo índice. Puede encontrarse, reordenarse, editarse o volver a hacerse visible.

**¿Por qué una forma clonada apareció delante de otra forma?**

`AddClone` añade la copia al final de la colección, que es el frente del orden Z. Use `InsertClone` para elegir el índice inicial o `Reorder` después de que se hayan añadido todas las formas.