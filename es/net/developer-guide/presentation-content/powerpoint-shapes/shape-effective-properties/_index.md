---
title: Obtener propiedades efectivas de formas desde presentaciones en .NET
linktitle: Propiedades efectivas
type: docs
weight: 50
url: /es/net/shape-effective-properties/
keywords:
- propiedades de forma
- propiedades de cámara
- sistema de iluminación
- forma con bisel
- marco de texto
- estilo de texto
- altura de fuente
- formato de relleno
- PowerPoint
- presentación
- .NET
- C#
- Aspose.Slides
description: "Aprenda a usar Aspose.Slides para .NET para distinguir el formato local, heredado y efectivo de formas en presentaciones de PowerPoint."
---
## **Comprender las propiedades locales, heredadas y efectivas**

El formato de PowerPoint puede provenir de varios lugares. El valor almacenado directamente en un objeto es su **valor local**. Si ese valor no está establecido, PowerPoint busca fuentes de formato padre, como el valor predeterminado de un párrafo, un estilo de texto, una diapositiva de diseño o maestra, un tema o valores predeterminados a nivel de presentación. esos valores son **valores heredados**. El valor que queda después de resolver toda la jerarquía es el **valor efectivo** —el valor utilizado para representar el objeto.

Por ejemplo, una porción de texto puede no definir su propia altura de fuente. Su [FontHeight](https://reference.aspose.com/slides/es/net/aspose.slides/ibaseportionformat/fontheight/) local es entonces `float.NaN`, lo que significa "no establecido aquí". La porción puede heredar una altura de su párrafo, del estilo de texto predeterminado de la presentación u otra fuente aplicable. Llamar a [GetEffective](https://reference.aspose.com/slides/es/net/aspose.slides/iportionformat/geteffective/) en el formato de la porción devuelve la altura final resuelta.

Utilice los dos tipos de datos de formato para diferentes propósitos:

- Lea o modifique un objeto de formato local, como [IPortionFormat](https://reference.aspose.com/slides/es/net/aspose.slides/iportionformat/), cuando necesite controlar dónde se define un valor.
- Lea un objeto de datos efectivo, como [IPortionFormatEffectiveData](https://reference.aspose.com/slides/es/net/aspose.slides/iportionformateffectivedata/), cuando necesite el resultado final renderizado. Los datos efectivos son de solo lectura.

## **Comparar valores locales, heredados y efectivos**

El siguiente ejemplo completo crea una forma y aplica alturas de fuente a nivel de presentación, párrafo y porción. Cada paso muestra los valores definidos en esos niveles y el valor efectivo resultante para la misma porción de texto. También demuestra por qué los datos efectivos deben leerse nuevamente después de los cambios de formato.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 500, 80, false);
var textFrame = shape.AddTextFrame("Effective formatting");
var paragraph = textFrame.Paragraphs[0];
var portion = paragraph.Portions[0];

// Definir valores heredados en dos niveles diferentes.
presentation.DefaultTextStyle.GetLevel(0).DefaultPortionFormat.FontHeight = 20;
paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight = 28;

PrintFontHeights("The portion inherits from the paragraph", presentation, paragraph, portion);

// Un valor local en la porción sobrescribe ambos valores heredados.
portion.PortionFormat.FontHeight = 36;
PrintFontHeights("A local value overrides inherited values", presentation, paragraph, portion);

// Cambiar un valor heredado no sobrescribe un valor local existente.
paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight = 30;
PrintFontHeights("The local value still has priority", presentation, paragraph, portion);

// Borrar el valor local. La porción vuelve a heredar del párrafo.
portion.PortionFormat.FontHeight = float.NaN;
PrintFontHeights("The local value is cleared", presentation, paragraph, portion);

// Borrar el valor del párrafo. El valor predeterminado de la presentación suministra ahora el resultado.
paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight = float.NaN;
PrintFontHeights("The paragraph value is cleared", presentation, paragraph, portion);

presentation.Save("effective-properties.pptx", SaveFormat.Pptx);

static void PrintFontHeights(string caption, Presentation presentation, IParagraph paragraph, IPortion portion)
{
    var presentationValue = presentation.DefaultTextStyle.GetLevel(0).DefaultPortionFormat.FontHeight;
    var paragraphValue = paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight;
    var localValue = portion.PortionFormat.FontHeight;

    // Leer datos efectivos después de los cambios anteriores.
    var effectiveValue = portion.PortionFormat.GetEffective().FontHeight;

    Console.WriteLine(caption);
    Console.WriteLine($"  Presentation default: {FormatLocalValue(presentationValue)}");
    Console.WriteLine($"  Paragraph default:    {FormatLocalValue(paragraphValue)}");
    Console.WriteLine($"  Portion local:        {FormatLocalValue(localValue)}");
    Console.WriteLine($"  Portion effective:    {effectiveValue}");
}

static string FormatLocalValue(float value) => float.IsNaN(value) ? "<not set>" : value.ToString();
```

La prioridad en este ejemplo es el formato local de la porción, luego el formato del párrafo y, por último, el valor predeterminado de la presentación. Otros objetos pueden tener cadenas de herencia diferentes, pero el principio es el mismo: un valor explícito más específico gana, y [GetEffective](https://reference.aspose.com/slides/es/net/aspose.slides/iportionformat/geteffective/) devuelve el resultado final.

## **Obtener propiedades de texto efectivas**

El formato de texto se divide entre varios objetos:

- [ITextFrameFormat.GetEffective()](https://reference.aspose.com/slides/es/net/aspose.slides/itextframeformat/geteffective/) resuelve propiedades del marco de texto como márgenes, anclaje, ajuste automático y dirección del texto vertical.
- [ITextStyle.GetEffective()](https://reference.aspose.com/slides/es/net/aspose.slides/itextstyle/geteffective/) resuelve el formato de párrafo para cada nivel de estilo de texto.
- [IParagraphFormat.GetEffective()](https://reference.aspose.com/slides/es/net/aspose.slides/iparagraphformat/geteffective/) resuelve propiedades del párrafo como alineación, sangría y viñetas.
- [IPortionFormat.GetEffective()](https://reference.aspose.com/slides/es/net/aspose.slides/iportionformat/geteffective/) resuelve propiedades de carácter como altura de fuente, tipografía, color, negrita e itálica.

Para el siguiente ejemplo, `text-formatting.pptx` debe contener al menos una diapositiva y una [AutoShape](https://reference.aspose.com/slides/es/net/aspose.slides/autoshape/) con un marco de texto no vacío. La AutoShape puede aparecer en cualquier posición de la colección de formas; el código busca un objeto adecuado y lo valida antes de usarlo.

```csharp
using System;
using System.Linq;
using Aspose.Slides;

using var presentation = new Presentation("text-formatting.pptx");

if (presentation.Slides.Count == 0)
    throw new InvalidOperationException("The presentation contains no slides.");

var autoShapes = presentation.Slides[0].Shapes.OfType<IAutoShape>();
var shape = autoShapes.FirstOrDefault(candidate => HasNonEmptyText(candidate));

if (shape == null)
{
    throw new InvalidOperationException("The first slide must contain an AutoShape with non-empty text.");
}

var textFrame = shape.TextFrame;
var paragraph = textFrame.Paragraphs[0];
var portion = paragraph.Portions[0];

var textFrameEffective = textFrame.TextFrameFormat.GetEffective();
var paragraphEffective = paragraph.ParagraphFormat.GetEffective();
var portionEffective = portion.PortionFormat.GetEffective();

Console.WriteLine("Text frame margins:");
Console.WriteLine($"  Left: {textFrameEffective.MarginLeft}");
Console.WriteLine($"  Top: {textFrameEffective.MarginTop}");
Console.WriteLine($"  Right: {textFrameEffective.MarginRight}");
Console.WriteLine($"  Bottom: {textFrameEffective.MarginBottom}");
Console.WriteLine($"Paragraph alignment: {paragraphEffective.Alignment}");
Console.WriteLine($"Font height: {portionEffective.FontHeight}");
Console.WriteLine($"Bold: {portionEffective.FontBold}");

var effectiveTextStyle = textFrame.TextFrameFormat.TextStyle.GetEffective();
for (var level = 0; level < 9; level++)
{
    var levelEffective = effectiveTextStyle.GetLevel(level);
    Console.WriteLine($"Level {level} indent: {levelEffective.Indent}");
}

static bool HasNonEmptyText(IAutoShape shape)
{
    if (shape.TextFrame == null)
        return false;

    if (shape.TextFrame.Paragraphs.Count == 0)
        return false;

    return shape.TextFrame.Paragraphs[0].Portions.Count > 0;
}
```

## **Obtener propiedades 3D efectivas**

[IThreeDFormat.GetEffective()](https://reference.aspose.com/slides/es/net/aspose.slides/ithreedformat/geteffective/) devuelve un objeto [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/es/net/aspose.slides/ithreedformateffectivedata/) que agrupa todos los ajustes 3D resueltos. Sus propiedades [Camera](https://reference.aspose.com/slides/es/net/aspose.slides/ithreedformateffectivedata/camera/), [LightRig](https://reference.aspose.com/slides/es/net/aspose.slides/ithreedformateffectivedata/lightrig/), [BevelTop](https://reference.aspose.com/slides/es/net/aspose.slides/ithreedformateffectivedata/beveltop/), y [BevelBottom](https://reference.aspose.com/slides/es/net/aspose.slides/ithreedformateffectivedata/bevelbottom/) exponen los datos efectivos correspondientes. Leer estos ajustes relacionados juntos facilita la comprensión de la apariencia 3D final de una forma.

Para este ejemplo, `shape-3d.pptx` debe contener al menos una forma en su primera diapositiva. Aplique ajustes de cámara 3D, iluminación o bisel a esa forma si desea que la salida contenga valores distintos a los predeterminados.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("shape-3d.pptx");

if (presentation.Slides.Count == 0 || presentation.Slides[0].Shapes.Count == 0)
{
    throw new InvalidOperationException("The first slide must contain a shape.");
}

var shape = presentation.Slides[0].Shapes[0];
var threeDEffective = shape.ThreeDFormat.GetEffective();

Console.WriteLine("Camera:");
Console.WriteLine($"  Type: {threeDEffective.Camera.CameraType}");
Console.WriteLine($"  Field of view: {threeDEffective.Camera.FieldOfViewAngle}");
Console.WriteLine($"  Zoom: {threeDEffective.Camera.Zoom}");

Console.WriteLine("Light rig:");
Console.WriteLine($"  Type: {threeDEffective.LightRig.LightType}");
Console.WriteLine($"  Direction: {threeDEffective.LightRig.Direction}");

Console.WriteLine("Top bevel:");
Console.WriteLine($"  Type: {threeDEffective.BevelTop.BevelType}");
Console.WriteLine($"  Width: {threeDEffective.BevelTop.Width}");
Console.WriteLine($"  Height: {threeDEffective.BevelTop.Height}");
```

## **Obtener formato de tabla efectivo**

El formato de tabla puede provenir del estilo de tabla y de los formatos aplicados a toda la tabla, una columna, una fila o una celda individual. En caso de conflictos entre rellenos definidos explícitamente, la prioridad es celda, fila, columna y luego toda la tabla. El formato efectivo de una celda es el formato final utilizado para dibujar esa celda.

Para este ejemplo, `table-formatting.pptx` debe contener al menos una tabla en su primera diapositiva. La tabla debe tener al menos una fila y una columna. El código busca un [ITable](https://reference.aspose.com/slides/es/net/aspose.slides/itable/) en lugar de asumir que `Shapes[0]` es una tabla.

```csharp
using System;
using System.Linq;
using Aspose.Slides;

using var presentation = new Presentation("table-formatting.pptx");

if (presentation.Slides.Count == 0)
    throw new InvalidOperationException("The presentation contains no slides.");

var table = presentation.Slides[0].Shapes.OfType<ITable>().FirstOrDefault();

if (table == null)
    throw new InvalidOperationException("The first slide must contain a table.");

if (table.Rows.Count == 0 || table.Columns.Count == 0)
    throw new InvalidOperationException("The table must contain at least one cell.");

var tableEffective = table.TableFormat.GetEffective();
var rowEffective = table.Rows[0].RowFormat.GetEffective();
var columnEffective = table.Columns[0].ColumnFormat.GetEffective();
var cellEffective = table[0, 0].CellFormat.GetEffective();

Console.WriteLine($"Table fill: {tableEffective.FillFormat.FillType}");
Console.WriteLine($"Row fill: {rowEffective.FillFormat.FillType}");
Console.WriteLine($"Column fill: {columnEffective.FillFormat.FillType}");
Console.WriteLine($"Final cell fill: {cellEffective.FillFormat.FillType}");
```

Si necesita el color en lugar de solo el tipo de relleno, primero compruebe el [FillType](https://reference.aspose.com/slides/es/net/aspose.slides/ifillformateffectivedata/filltype/) efectivo y luego lea la propiedad que corresponde a ese tipo —por ejemplo, [SolidFillColor](https://reference.aspose.com/slides/es/net/aspose.slides/ifillformateffectivedata/solidfillcolor/) para un relleno sólido.

## **Volver a leer los datos efectivos después de los cambios**

Los datos efectivos describen la jerarquía de formato en el momento en que se resuelve. Llame a `GetEffective` nuevamente después de cambiar cualquier elemento que pueda participar en esa jerarquía, incluyendo:

- el formato local del objeto;
- los valores predeterminados de párrafo o marco de texto;
- un estilo de tabla, tabla, columna, fila o formato de celda;
- el formato de diseño o diapositiva maestra;
- los datos del tema o valores predeterminados a nivel de presentación;
- el diseño o la maestra asignada a una diapositiva.

No mantenga un objeto de datos efectivo como una captura permanente. Aspose.Slides puede almacenar en caché algunos datos efectivos internamente, y una llamada posterior a `GetEffective` puede actualizar esos datos. Si necesita comparar valores antes y después de un cambio, copie los valores escalares que necesite —como la altura de fuente, color, alineación o ancho del bisel— en sus propias variables antes de realizar el cambio.

Para cambiar un valor, actualice el objeto de formato local correspondiente y luego llame a `GetEffective` para verificar el resultado. Los propios objetos de datos efectivos son de solo lectura.

## **FAQ**

**¿Cómo puedo saber qué nivel suministró un valor efectivo?**

Los datos efectivos contienen el valor final, no su origen. Inspeccione los objetos locales aplicables desde el nivel más específico hacia afuera. Para el texto, esto puede incluir la porción, el párrafo, el marco de texto, el diseño, la maestra, el tema y los valores predeterminados de la presentación. Valores indefinidos como `float.NaN` o `null` indican que la búsqueda continúa en otro nivel.

**¿Qué ocurre cuando ningún nivel define una propiedad?**

Aspose.Slides resuelve el valor predeterminado adecuado de PowerPoint o de la biblioteca. Ese valor resuelto aparece en los datos efectivos aunque ningún objeto local lo defina explícitamente.

**¿Por qué a veces un valor efectivo es igual al valor local?**

El valor local ganó el cálculo de herencia. Esto es esperado cuando la propiedad está establecida explícitamente en el objeto y ninguna regla más específica la sobrescribe.

**¿Cuándo debo usar datos locales en lugar de datos efectivos?**

Utilice datos locales para inspeccionar o editar un nivel de formato específico. Utilice datos efectivos cuando necesite la apariencia final tras la herencia, reglas de tema y estilos aplicables. El [ejemplo completo de comparación](#compare-local-inherited-and-effective-values) muestra ambos en el mismo flujo de trabajo.