---
title: Obtener propiedades efectivas de forma de presentaciones en .NET
linktitle: Propiedades efectivas
type: docs
weight: 50
url: /es/net/shape-effective-properties/
keywords:
- propiedades de forma
- propiedades de cámara
- conjunto de luces
- forma biselada
- marco de texto
- estilo de texto
- altura de fuente
- formato de relleno
- PowerPoint
- presentación
- .NET
- C#
- Aspose.Slides
description: "Descubra cómo Aspose.Slides para .NET calcula y aplica propiedades efectivas de forma para una renderización precisa de PowerPoint."
---
## **Visión general**

Este tema explica la diferencia entre propiedades **locales** y **efectivas**. Los valores locales son los que se establecen directamente en un nivel de formato concreto, como:

1. Propiedades de porciones en una diapositiva.  
2. Estilos de texto de forma prototipo en una diapositiva de diseño o maestra, cuando la forma del marco de texto de la porción lo tiene.  
3. Configuraciones de texto globales en una presentación.

Los valores locales pueden definirse u omitirse en cualquier nivel. Cuando Aspose.Slides necesita el formato final “tal como se renderiza”, resuelve la cadena de herencia y devuelve los valores **efectivos**. Puede obtenerlos llamando al método `GetEffective` sobre el objeto de formato local.

El siguiente ejemplo muestra cómo obtener valores efectivos. Parte de la base de que la primera forma de la primera diapositiva es un [IAutoShape](https://reference.aspose.com/slides/es/net/aspose.slides/iautoshape/) con un marco de texto y al menos una porción.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = (IAutoShape)slide.Shapes[0];

var localTextFrameFormat = shape.TextFrame.TextFrameFormat;
var effectiveTextFrameFormat = localTextFrameFormat.GetEffective();

var portion = shape.TextFrame.Paragraphs[0].Portions[0];
var localPortionFormat = portion.PortionFormat;
var effectivePortionFormat = localPortionFormat.GetEffective();
```

{{% alert color="info" %}}

Los datos de formato efectivo representan el formato calculado actual después de aplicar la herencia. En la implementación actual, algunos objetos de datos efectivos, como [IPortionFormatEffectiveData](https://reference.aspose.com/slides/es/net/aspose.slides/iportionformateffectivedata/), pueden almacenarse en caché internamente. Llamar a `GetEffective` nuevamente después de cambiar el formato heredado o del padre puede actualizar la caché, y un objeto obtenido previamente puede ya no representar el estado anterior. Si necesita conservar los valores efectivos para reutilizarlos más adelante, copie las propiedades necesarias, como altura de fuente, color de relleno, estilo de fuente o alineación, en su propio objeto de datos.

{{% /alert %}}

## **Obtener propiedades efectivas de una cámara**

Aspose.Slides permite obtener las propiedades efectivas de una cámara. La interfaz [ICameraEffectiveData](https://reference.aspose.com/slides/es/net/aspose.slides/icameraeffectivedata/) representa un objeto inmutable que contiene propiedades de cámara efectivas. Una instancia de [ICameraEffectiveData](https://reference.aspose.com/slides/es/net/aspose.slides/icameraeffectivedata/) se expone a través de [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/es/net/aspose.slides/ithreedformateffectivedata/), que proporciona valores efectivos para [IThreeDFormat](https://reference.aspose.com/slides/es/net/aspose.slides/ithreedformat/).

El siguiente fragmento de código muestra cómo obtener propiedades efectivas para la cámara. Parte de la base de que la primera forma de la primera diapositiva tiene formato 3D.

```csharp
using Aspose.Slides;

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

Aspose.Slides permite obtener las propiedades efectivas de un conjunto de luces. La interfaz [ILightRigEffectiveData](https://reference.aspose.com/slides/es/net/aspose.slides/ilightrigeffectivedata/) representa un objeto inmutable que contiene propiedades de conjunto de luces efectivas. Una instancia de [ILightRigEffectiveData](https://reference.aspose.com/slides/es/net/aspose.slides/ilightrigeffectivedata/) se expone a través de [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/es/net/aspose.slides/ithreedformateffectivedata/), que proporciona valores efectivos para [IThreeDFormat](https://reference.aspose.com/slides/es/net/aspose.slides/ithreedformat/).

El siguiente fragmento de código muestra cómo obtener propiedades efectivas para el conjunto de luces. Parte de la base de que la primera forma de la primera diapositiva tiene formato 3D.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = slide.Shapes[0];

var threeDEffectiveData = shape.ThreeDFormat.GetEffective();

Console.WriteLine("= Effective light rig properties =");
Console.WriteLine("Type: " + threeDEffectiveData.LightRig.LightType);
Console.WriteLine("Direction: " + threeDEffectiveData.LightRig.Direction);
```

## **Obtener propiedades efectivas de un bisel de forma**

Aspose.Slides permite obtener las propiedades efectivas de un bisel de forma. La interfaz [IShapeBevelEffectiveData](https://reference.aspose.com/slides/es/net/aspose.slides/ishapebeveleffectivedata/) representa un objeto inmutable que contiene propiedades de relieve de cara efectivas para una forma. Una instancia de [IShapeBevelEffectiveData](https://reference.aspose.com/slides/es/net/aspose.slides/ishapebeveleffectivedata/) se expone a través de [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/es/net/aspose.slides/ithreedformateffectivedata/), que proporciona valores efectivos para [IThreeDFormat](https://reference.aspose.com/slides/es/net/aspose.slides/ithreedformat/).

El siguiente fragmento de código muestra cómo obtener propiedades efectivas para el bisel superior de una forma. Parte de la base de que la primera forma de la primera diapositiva tiene formato 3D.

```csharp
using Aspose.Slides;

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

Con Aspose.Slides, puede obtener las propiedades efectivas de un marco de texto. La interfaz [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/es/net/aspose.slides/itextframeformateffectivedata/) contiene propiedades de formato de marco de texto efectivas.

El siguiente fragmento de código muestra cómo obtener propiedades de formato de marco de texto efectivas. Parte de la base de que la primera forma de la primera diapositiva es un [IAutoShape](https://reference.aspose.com/slides/es/net/aspose.slides/iautoshape/) con un marco de texto.

```csharp
using Aspose.Slides;

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

Con Aspose.Slides, puede obtener las propiedades efectivas de un estilo de texto. La interfaz [ITextStyleEffectiveData](https://reference.aspose.com/slides/es/net/aspose.slides/itextstyleeffectivedata/) contiene propiedades de estilo de texto efectivas.

El siguiente fragmento de código muestra cómo obtener propiedades de estilo de texto efectivas. Parte de la base de que la primera forma de la primera diapositiva es un [IAutoShape](https://reference.aspose.com/slides/es/net/aspose.slides/iautoshape/) con un marco de texto.

```csharp
using Aspose.Slides;

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

## **Obtener el valor efectivo de altura de fuente**

Con Aspose.Slides, puede obtener la altura de fuente efectiva. El siguiente código demuestra cómo cambia la altura de fuente efectiva de una porción después de establecer valores locales de altura de fuente en diferentes niveles de la estructura de la presentación.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

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

## **Obtener el formato de relleno efectivo para una tabla**

Con Aspose.Slides, puede obtener el formato de relleno efectivo para distintas partes de una tabla. La interfaz [IFillFormatEffectiveData](https://reference.aspose.com/slides/es/net/aspose.slides/ifillformateffectivedata/) contiene propiedades de formato de relleno efectivas. El formato de celda tiene mayor prioridad que el de fila, el de fila tiene mayor prioridad que el de columna y el de columna tiene mayor prioridad que el formato de tabla completa.

Como resultado, las propiedades de [ICellFormatEffectiveData](https://reference.aspose.com/slides/es/net/aspose.slides/icellformateffectivedata/) se utilizan para dibujar la celda de la tabla. El siguiente fragmento de código muestra cómo obtener el formato de relleno efectivo para distintas partes de la tabla. Parte de la base de que la primera forma de la primera diapositiva es un [ITable](https://reference.aspose.com/slides/es/net/aspose.slides/itable/).

```csharp
using Aspose.Slides;

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

## **FAQ**

### ¿`GetEffective` devuelve una instantánea?

No siempre. Los datos efectivos representan el formato calculado después de aplicar la herencia, pero algunos objetos de datos efectivos pueden almacenarse en caché internamente. Una llamada posterior a `GetEffective` puede recalcular el formato y actualizar la caché, de modo que un objeto obtenido anteriormente no debe considerarse una instantánea duradera.

### ¿Cuándo debo volver a leer las propiedades efectivas?

Llame a `GetEffective` de nuevo después de modificar el formato local, los estilos del padre, el formato de diseño, el formato maestro o los valores predeterminados a nivel de presentación. La siguiente llamada reevalúa la jerarquía de formato y devuelve el resultado efectivo actual.

### ¿Cambiar o eliminar una diapositiva de diseño/maestra afecta a las propiedades efectivas ya obtenidas?

Sí, pero el cambio se refleja en la siguiente llamada a `GetEffective`. Si se modifica o elimina una fuente de formato padre, los datos efectivos obtenidos previamente pueden quedar obsoletos. Una vez que se vuelva a llamar a `GetEffective`, Aspose.Slides reevalúa el árbol de formato y los valores resultantes de fuentes, colores, tamaños u otros pueden cambiar.

### ¿Puedo modificar valores a través de objetos de datos efectivos?

No. Los objetos de datos efectivos exponen valores calculados. Realice los cambios en los objetos de formato local y, a continuación, obtenga de nuevo los valores efectivos.

### ¿Qué ocurre si una propiedad no está definida a nivel de forma, ni en el diseño/maestra, ni en la configuración global?

El valor efectivo se determina mediante el mecanismo predeterminado, que incluye los valores por defecto de PowerPoint y de Aspose.Slides. Ese valor resuelto pasa a formar parte de los datos efectivos actuales.

### A partir de un valor de fuente efectivo, ¿puedo saber qué nivel proporcionó el tamaño o la tipografía?

No directamente. Los datos efectivos devuelven el valor final. Para encontrar la fuente, compruebe los valores locales en la porción, párrafo, marco de texto y estilos de texto en los niveles de diseño, maestro y presentación, y vea dónde aparece la primera definición explícita.

### ¿Por qué los valores efectivos a veces aparecen idénticos a los locales?

Porque el valor local resultó ser el final (no se necesitó herencia de nivel superior). En esos casos, el valor efectivo coincide con el local.

### ¿Cuándo debo usar propiedades efectivas y cuándo trabajar solo con las locales?

Utilice los datos efectivos cuando necesite el resultado “tal como se renderiza” tras aplicar toda la herencia, por ejemplo, para alinear colores, sangrías o tamaños. Si necesita conservar esos valores independientemente de cambios posteriores de formato, copie las propiedades requeridas a su propio objeto. Si necesita cambiar el formato en un nivel específico, modifique las propiedades locales y, si es necesario, lea de nuevo los datos efectivos para verificar el resultado.