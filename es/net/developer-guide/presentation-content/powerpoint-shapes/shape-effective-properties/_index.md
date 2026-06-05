---
title: Obtener propiedades efectivas de formas desde presentaciones en .NET
linktitle: Propiedades efectivas
type: docs
weight: 50
url: /es/net/shape-effective-properties/
keywords:
- propiedades de forma
- propiedades de cámara
- conjunto de luces
- forma de bisel
- marco de texto
- estilo de texto
- altura de fuente
- formato de relleno
- PowerPoint
- presentación
- .NET
- C#
- Aspose.Slides
description: "Descubra cómo Aspose.Slides para .NET calcula y aplica las propiedades efectivas de forma para una renderización precisa de PowerPoint."
---
## **Resumen**

Este tema explica la diferencia entre propiedades **locales** y **efectivas**. Los valores locales son valores que se establecen directamente en un nivel de formato específico, como por ejemplo:

1. Propiedades de porción en una diapositiva.
1. Estilos de texto de forma prototipo en una diapositiva de diseño o maestra, cuando la forma del marco de texto de la porción tiene uno.
1. Configuraciones de texto globales en una presentación.

Los valores locales pueden definirse u omitirse en cualquier nivel. Cuando Aspose.Slides necesita el formato final "tal como se muestra", resuelve la cadena de herencia y devuelve valores **efectivos**. Puedes obtenerlos llamando al método `GetEffective` del objeto de formato local.

El siguiente ejemplo muestra cómo obtener valores efectivos. Se asume que la primera forma en la primera diapositiva es un [IAutoShape](https://reference.aspose.com/slides/es/net/aspose.slides/iautoshape/) con un marco de texto y al menos una porción.

```csharp
using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = (IAutoShape)slide.Shapes[0];

var localTextFrameFormat = shape.TextFrame.TextFrameFormat;
var effectiveTextFrameFormat = localTextFrameFormat.GetEffective();

var portion = shape.TextFrame.Paragraphs[0].Portions[0];
var localPortionFormat = portion.PortionFormat;
var effectivePortionFormat = localPortionFormat.GetEffective();
```

{{% alert color="primary" %}}
Los datos de formato efectivo representan el formato calculado actual después de aplicar la herencia. En la implementación actual, algunos objetos de datos efectivos, como [IPortionFormatEffectiveData](https://reference.aspose.com/slides/es/net/aspose.slides/iportionformateffectivedata/), pueden almacenarse en caché internamente. Llamar a `GetEffective` de nuevo después de cambiar el formato padre o heredado puede actualizar los datos en caché, y un objeto obtenido previamente puede dejar de representar el estado anterior. Si necesitas conservar los valores efectivos para reutilizarlos más tarde, copia las propiedades necesarias, como la altura de fuente, el color de relleno, el estilo de fuente o la alineación, en tu propio objeto de datos.
{{% /alert %}}

## **Obtener propiedades efectivas de una cámara**

Aspose.Slides permite obtener propiedades efectivas de una cámara. La interfaz [ICameraEffectiveData](https://reference.aspose.com/slides/es/net/aspose.slides/icameraeffectivedata/) representa un objeto inmutable que contiene las propiedades efectivas de la cámara. Una instancia de [ICameraEffectiveData](https://reference.aspose.com/slides/es/net/aspose.slides/icameraeffectivedata/) se expone a través de [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/es/net/aspose.slides/ithreedformateffectivedata/), que proporciona valores efectivos para [IThreeDFormat](https://reference.aspose.com/slides/es/net/aspose.slides/ithreedformat/).

El siguiente fragmento de código muestra cómo obtener propiedades efectivas para la cámara. Se asume que la primera forma en la primera diapositiva tiene formato 3D.

```csharp
using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = slide.Shapes[0];

var threeDEffectiveData = shape.ThreeDFormat.GetEffective();

Console.WriteLine("= Effective camera properties =");
Console.WriteLine("Type: " + threeDEffectiveData.Camera.CameraType);
Console.WriteLine("Field of view: " + threeDEffectiveData.Camera.FieldOfViewAngle);
Console.WriteLine("Zoom: " + threeDEffectiveData.Camera.Zoom);
```

## **Obtener propiedades efectivas de un conjunto de luces**

Aspose.Slides permite obtener propiedades efectivas de un conjunto de luces. La interfaz [ILightRigEffectiveData](https://reference.aspose.com/slides/es/net/aspose.slides/ilightrigeffectivedata/) representa un objeto inmutable que contiene las propiedades efectivas del conjunto de luces. Una instancia de [ILightRigEffectiveData](https://reference.aspose.com/slides/es/net/aspose.slides/ilightrigeffectivedata/) se expone a través de [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/es/net/aspose.slides/ithreedformateffectivedata/), que proporciona valores efectivos para [IThreeDFormat](https://reference.aspose.com/slides/es/net/aspose.slides/ithreedformat/).

El siguiente fragmento de código muestra cómo obtener propiedades efectivas para el conjunto de luces. Se asume que la primera forma en la primera diapositiva tiene formato 3D.

```csharp
using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = slide.Shapes[0];

var threeDEffectiveData = shape.ThreeDFormat.GetEffective();

Console.WriteLine("= Effective light rig properties =");
Console.WriteLine("Type: " + threeDEffectiveData.LightRig.LightType);
Console.WriteLine("Direction: " + threeDEffectiveData.LightRig.Direction);
```

## **Obtener propiedades efectivas de un bisel de forma**

Aspose.Slides permite obtener propiedades efectivas de un bisel de forma. La interfaz [IShapeBevelEffectiveData](https://reference.aspose.com/slides/es/net/aspose.slides/ishapebeveleffectivedata/) representa un objeto inmutable que contiene propiedades de relieve de cara efectivas para una forma. Una instancia de [IShapeBevelEffectiveData](https://reference.aspose.com/slides/es/net/aspose.slides/ishapebeveleffectivedata/) se expone a través de [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/es/net/aspose.slides/ithreedformateffectivedata/), que proporciona valores efectivos para [IThreeDFormat](https://reference.aspose.com/slides/es/net/aspose.slides/ithreedformat/).

El siguiente fragmento de código muestra cómo obtener propiedades efectivas para el bisel superior de una forma. Se asume que la primera forma en la primera diapositiva tiene formato 3D.

```csharp
using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = slide.Shapes[0];

var threeDEffectiveData = shape.ThreeDFormat.GetEffective();

Console.WriteLine("= Effective shape's top face relief properties =");
Console.WriteLine("Type: " + threeDEffectiveData.BevelTop.BevelType);
Console.WriteLine("Width: " + threeDEffectiveData.BevelTop.Width);
Console.WriteLine("Height: " + threeDEffectiveData.BevelTop.Height);
```

## **Obtener propiedades efectivas de un marco de texto**

Con Aspose.Slides, puedes obtener propiedades efectivas de un marco de texto. La interfaz [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/es/net/aspose.slides/itextframeformateffectivedata/) contiene propiedades de formato efectivas del marco de texto.

El siguiente fragmento de código muestra cómo obtener propiedades de formato efectivas del marco de texto. Se asume que la primera forma en la primera diapositiva es un [IAutoShape](https://reference.aspose.com/slides/es/net/aspose.slides/iautoshape/) con un marco de texto.

```csharp
using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = (IAutoShape)slide.Shapes[0];

var textFrameFormat = shape.TextFrame.TextFrameFormat;
var effectiveTextFrameFormat = textFrameFormat.GetEffective();

Console.WriteLine("Anchoring type: " + effectiveTextFrameFormat.AnchoringType);
Console.WriteLine("Autofit type: " + effectiveTextFrameFormat.AutofitType);
Console.WriteLine("Text vertical type: " + effectiveTextFrameFormat.TextVerticalType);
Console.WriteLine("Margins");
Console.WriteLine("   Left: " + effectiveTextFrameFormat.MarginLeft);
Console.WriteLine("   Top: " + effectiveTextFrameFormat.MarginTop);
Console.WriteLine("   Right: " + effectiveTextFrameFormat.MarginRight);
Console.WriteLine("   Bottom: " + effectiveTextFrameFormat.MarginBottom);
```

## **Obtener propiedades efectivas de un estilo de texto**

Con Aspose.Slides, puedes obtener propiedades efectivas de un estilo de texto. La interfaz [ITextStyleEffectiveData](https://reference.aspose.com/slides/es/net/aspose.slides/itextstyleeffectivedata/) contiene propiedades de estilo de texto efectivas.

El siguiente fragmento de código muestra cómo obtener propiedades de estilo de texto efectivas. Se asume que la primera forma en la primera diapositiva es un [IAutoShape](https://reference.aspose.com/slides/es/net/aspose.slides/iautoshape/) con un marco de texto.

```csharp
using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = (IAutoShape)slide.Shapes[0];

var effectiveTextStyle = shape.TextFrame.TextFrameFormat.TextStyle.GetEffective();
var levelCount = 9;

for (var levelIndex = 0; levelIndex < levelCount; levelIndex++)
{
    var effectiveStyleLevel = effectiveTextStyle.GetLevel(levelIndex);
    Console.WriteLine("= Effective paragraph formatting for style level #" + levelIndex + " =");

    Console.WriteLine("Depth: " + effectiveStyleLevel.Depth);
    Console.WriteLine("Indent: " + effectiveStyleLevel.Indent);
    Console.WriteLine("Alignment: " + effectiveStyleLevel.Alignment);
    Console.WriteLine("Font alignment: " + effectiveStyleLevel.FontAlignment);
}
```

## **Obtener el valor efectivo de la altura de fuente**

Con Aspose.Slides, puedes obtener la altura de fuente efectiva. El siguiente código demuestra cómo cambia la altura de fuente efectiva de una porción después de establecer valores locales de altura de fuente en diferentes niveles de la estructura de la presentación.

```csharp
using var presentation = new Presentation();

var slide = presentation.Slides[0];
var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 75, false);
autoShape.AddTextFrame("");

var paragraph = autoShape.TextFrame.Paragraphs[0];
paragraph.Portions.Clear();

var firstPortion = new Portion("Sample text with first portion");
var secondPortion = new Portion(" and second portion.");

paragraph.Portions.Add(firstPortion);
paragraph.Portions.Add(secondPortion);

var firstPortionFormatEffectiveData = firstPortion.PortionFormat.GetEffective();
var secondPortionFormatEffectiveData = secondPortion.PortionFormat.GetEffective();

Console.WriteLine("Effective font height just after creation:");
Console.WriteLine("Portion #0: " + firstPortionFormatEffectiveData.FontHeight);
Console.WriteLine("Portion #1: " + secondPortionFormatEffectiveData.FontHeight);

presentation.DefaultTextStyle.GetLevel(0).DefaultPortionFormat.FontHeight = 24;
firstPortionFormatEffectiveData = firstPortion.PortionFormat.GetEffective();
secondPortionFormatEffectiveData = secondPortion.PortionFormat.GetEffective();

Console.WriteLine("Effective font height after setting the presentation default font height:");
Console.WriteLine("Portion #0: " + firstPortionFormatEffectiveData.FontHeight);
Console.WriteLine("Portion #1: " + secondPortionFormatEffectiveData.FontHeight);

paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight = 40;
firstPortionFormatEffectiveData = firstPortion.PortionFormat.GetEffective();
secondPortionFormatEffectiveData = secondPortion.PortionFormat.GetEffective();

Console.WriteLine("Effective font height after setting paragraph default font height:");
Console.WriteLine("Portion #0: " + firstPortionFormatEffectiveData.FontHeight);
Console.WriteLine("Portion #1: " + secondPortionFormatEffectiveData.FontHeight);

firstPortion.PortionFormat.FontHeight = 55;
firstPortionFormatEffectiveData = firstPortion.PortionFormat.GetEffective();
secondPortionFormatEffectiveData = secondPortion.PortionFormat.GetEffective();

Console.WriteLine("Effective font height after setting portion #0 font height:");
Console.WriteLine("Portion #0: " + firstPortionFormatEffectiveData.FontHeight);
Console.WriteLine("Portion #1: " + secondPortionFormatEffectiveData.FontHeight);

secondPortion.PortionFormat.FontHeight = 18;
firstPortionFormatEffectiveData = firstPortion.PortionFormat.GetEffective();
secondPortionFormatEffectiveData = secondPortion.PortionFormat.GetEffective();

Console.WriteLine("Effective font height after setting portion #1 font height:");
Console.WriteLine("Portion #0: " + firstPortionFormatEffectiveData.FontHeight);
Console.WriteLine("Portion #1: " + secondPortionFormatEffectiveData.FontHeight);

presentation.Save("SetLocalFontHeightValues.pptx", SaveFormat.Pptx);
```

## **Obtener el formato de relleno efectivo de una tabla**

Con Aspose.Slides, puedes obtener formato de relleno efectivo para diferentes partes de una tabla. La interfaz [IFillFormatEffectiveData](https://reference.aspose.com/slides/es/net/aspose.slides/ifillformateffectivedata/) contiene propiedades de formato de relleno efectivas. El formato de celda tiene mayor prioridad que el formato de fila, el formato de fila tiene mayor prioridad que el formato de columna, y el formato de columna tiene mayor prioridad que el formato de tabla completa.

Como resultado, se utilizan las propiedades de [ICellFormatEffectiveData](https://reference.aspose.com/slides/es/net/aspose.slides/icellformateffectivedata/) para dibujar la celda de la tabla. El siguiente fragmento de código muestra cómo obtener formato de relleno efectivo para diferentes partes de la tabla. Se asume que la primera forma en la primera diapositiva es una [ITable](https://reference.aspose.com/slides/es/net/aspose.slides/itable/).

```csharp
using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var table = (ITable)presentation.Slides[0].Shapes[0];

var tableFormatEffective = table.TableFormat.GetEffective();
var rowFormatEffective = table.Rows[0].RowFormat.GetEffective();
var columnFormatEffective = table.Columns[0].ColumnFormat.GetEffective();
var cellFormatEffective = table[0, 0].CellFormat.GetEffective();

var tableFillFormatEffective = tableFormatEffective.FillFormat;
var rowFillFormatEffective = rowFormatEffective.FillFormat;
var columnFillFormatEffective = columnFormatEffective.FillFormat;
var cellFillFormatEffective = cellFormatEffective.FillFormat;
```

## **Preguntas frecuentes**

**¿Devuelve `GetEffective` una instantánea?**

No siempre. Los datos efectivos representan el formato calculado después de aplicar la herencia, pero algunos objetos de datos efectivos pueden almacenarse en caché internamente. Una llamada posterior a `GetEffective` puede recalcular el formato y actualizar los datos en caché, por lo que un objeto obtenido previamente no debe considerarse una instantánea permanente.

**¿Cuándo debo volver a leer las propiedades efectivas?**

Llama a `GetEffective` de nuevo después de cambiar el formato local, los estilos padre, el formato de diseño, el formato maestro o los valores predeterminados a nivel de presentación. La siguiente llamada vuelve a evaluar la jerarquía de formato y devuelve el resultado efectivo actual.

**¿Cambiar o eliminar una diapositiva de diseño/maestra afecta a las propiedades efectivas que ya se han obtenido?**

Sí, pero el cambio se refleja en la siguiente llamada a `GetEffective`. Si se modifica o elimina una fuente de formato padre, los datos efectivos obtenidos previamente pueden quedar obsoletos. Cuando se vuelva a llamar a `GetEffective`, Aspose.Slides vuelve a evaluar el árbol de formato y las fuentes, colores, tamaños u otros valores resultantes pueden cambiar.

**¿Puedo modificar valores a través de los objetos de datos efectivos?**

No. Los objetos de datos efectivos exponen valores calculados. Realiza los cambios en los objetos de formato local y, a continuación, vuelve a obtener los valores efectivos.

**¿Qué ocurre si una propiedad no está establecida a nivel de forma, ni en el diseño/maestra, ni en la configuración global?**

El valor efectivo se determina mediante el mecanismo por defecto, que incluye los valores predeterminados de PowerPoint y Aspose.Slides. Ese valor resuelto pasa a formar parte de los datos efectivos actuales.

**A partir de un valor de fuente efectivo, ¿puedo saber qué nivel proporcionó el tamaño o la familia tipográfica?**

No de forma directa. Los datos efectivos devuelven el valor final. Para encontrar la fuente, verifica los valores locales en la porción, el párrafo, el marco de texto y los estilos de texto en los niveles de diseño, maestro y presentación para ver dónde aparece la primera definición explícita.

**¿Por qué a veces los valores efectivos parecen idénticos a los locales?**

Porque el valor local resultó ser el final (no se necesitó herencia de un nivel superior). En esos casos, el valor efectivo coincide con el local.

**¿Cuándo debo usar propiedades efectivas y cuándo debo trabajar solo con las locales?**

Utiliza los datos efectivos cuando necesites el resultado "tal como se muestra" después de aplicar toda la herencia, por ejemplo para alinear colores, sangrías o tamaños. Si necesitas conservar esos valores independientemente de cambios posteriores de formato, copia las propiedades necesarias en tu propio objeto. Si necesitas cambiar el formato en un nivel específico, modifica las propiedades locales y, si es necesario, vuelve a leer los datos efectivos para verificar el resultado.