---
title: Gestionar cuadros de texto en presentaciones en .NET
linktitle: Gestionar cuadro de texto
type: docs
weight: 20
url: /es/net/manage-textbox/
keywords:
- cuadro de texto
- marco de texto
- añadir texto
- actualizar texto
- crear cuadro de texto
- comprobar cuadro de texto
- añadir columna de texto
- añadir hipervínculo
- PowerPoint
- presentación
- .NET
- C#
- Aspose.Slides
description: "Crear, identificar, dar formato y actualizar cuadros de texto en presentaciones PowerPoint y OpenDocument usando Aspose.Slides para .NET."
---
## **Introducción**

En Aspose.Slides para .NET, el texto de una diapositiva se almacena en marcos de texto que pertenecen a formas. La interfaz [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) representa la forma más común que contiene texto y expone su texto a través de la propiedad [IAutoShape.TextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/textframe/).

{{% alert color="info" title="Nota" %}}

Todas las formas automáticas implementan [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/), pero no todas las formas son formas automáticas o admiten un marco de texto. Al procesar una presentación existente, compruebe que una forma implementa `IAutoShape` antes de acceder a su texto.

{{% /alert %}}

## **Crear un cuadro de texto en una diapositiva**

Para crear un cuadro de texto, añada una forma automática a una diapositiva, añada texto a su marco de texto y guarde la presentación. El siguiente ejemplo crea un cuadro de texto rectangular:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var textBox = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 300, 50);
textBox.AddTextFrame("Aspose TextBox");

presentation.Save("TextBox.pptx", SaveFormat.Pptx);
```

Las coordenadas y dimensiones pasadas a [IShapeCollection.AddAutoShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addautoshape/) se miden en puntos. [IAutoShape.AddTextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/addtextframe/) inicializa el marco de texto con el texto suministrado.

## **Comprobar si una forma es un cuadro de texto**

Utilice la propiedad [AutoShape.IsTextBox](https://reference.aspose.com/slides/net/aspose.slides/autoshape/istextbox/) para determinar si una forma automática se trata como un cuadro de texto. Esto es útil cuando una presentación contiene tanto formas automáticas con texto como formas exclusivamente gráficas.

![Un cuadro de texto y una forma](istextbox.png)

El siguiente ejemplo inspecciona cada forma automática en una presentación:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var textBox = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 120, 40);
textBox.AddTextFrame("Text box");
slide.Shapes.AddAutoShape(ShapeType.Ellipse, 150, 10, 40, 40);

foreach (var currentSlide in presentation.Slides)
{
    foreach (var shape in currentSlide.Shapes)
    {
        if (shape is IAutoShape autoShape)
        {
            Console.WriteLine(autoShape.IsTextBox ? "The shape is a text box." : "The shape is not a text box.");
        }
    }
}
```

Una forma automática recién añadida no se considera un cuadro de texto hasta que contiene texto no vacío. Puede suministrar ese texto mediante [IAutoShape.AddTextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/addtextframe/) o [ITextFrame.Text](https://reference.aspose.com/slides/net/aspose.slides/itextframe/text/). Añadir o asignar una cadena vacía deja `IsTextBox` con el valor `false`:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 40);
shape1.AddTextFrame("Shape 1");
Console.WriteLine(shape1.IsTextBox);

var shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 70, 100, 40);
shape2.TextFrame.Text = "Shape 2";
Console.WriteLine(shape2.IsTextBox);

var shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 130, 100, 40);
shape3.AddTextFrame("");
Console.WriteLine(shape3.IsTextBox);

var shape4 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 190, 100, 40);
shape4.TextFrame.Text = "";
Console.WriteLine(shape4.IsTextBox);
```

Las dos primeras llamadas imprimen `True`; las dos últimas imprimen `False`.

## **Encontrar la forma que posee un marco de texto**

El código genérico de procesamiento de texto puede recibir un [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) sin saber qué objeto de la presentación lo contiene. Utilice la propiedad de solo lectura [ITextFrame.ParentShape](https://reference.aspose.com/slides/net/aspose.slides/itextframe/parentshape/) para volver a su [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) propietario.

Para un marco de texto propiedad de una forma automática u otra forma que contenga texto, `ParentShape` contiene al propietario y [ITextFrame.ParentCell](https://reference.aspose.com/slides/net/aspose.slides/itextframe/parentcell/) es `null`. Compruebe el valor devuelto antes de acceder a él. Para identificar tanto propietarios de forma como de celda de tabla, incluidas las formas asociadas a nodos de SmartArt, consulte [Search and Replace Text](/slides/es/net/search-and-replace-text/).

## **Obtener el rectángulo de texto de la forma**

A partir de Aspose.Slides para .NET 26.11, [ITextFrame.GetTextRect](https://reference.aspose.com/slides/net/aspose.slides/itextframe/gettextrect/) devuelve el área de texto definida por la geometría de la forma padre. Sus coordenadas y dimensiones están en puntos, relativas a la esquina superior izquierda de esa forma. Por ejemplo, una elipse tiene un rectángulo de texto más pequeño que sus límites externos.

Este rectángulo describe la forma, no los caracteres renderizados. Cambiar el texto o los márgenes del marco de texto no lo convierte en una medida del texto ocupado. Utilice [paragraph bounds](/slides/es/net/paragraph-bounds/) o [portion bounds](/slides/es/net/portion-bounds/) para mediciones del texto renderizado.

Después de [installing Aspose.Slides for .NET](/slides/es/net/installation/) 26.11 o posterior, ejecute este ejemplo para dibujar el rectángulo de texto de la geometría en rojo. Las formas no están rotadas ni agrupadas, por lo que basta con añadir su posición X/Y para colocar la superposición en la diapositiva.

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

foreach (var shapeType in new[] { ShapeType.Rectangle, ShapeType.Ellipse })
{
    var x = shapeType == ShapeType.Rectangle ? 50 : 300;
    var shape = slide.Shapes.AddAutoShape(shapeType, x, 200, 200, 100);
    shape.AddTextFrame("Text area");
    var rectangle = shape.TextFrame.GetTextRect();
    Console.WriteLine($"{shapeType}: {rectangle}");

    var overlayX = shape.X + rectangle.X;
    var overlayY = shape.Y + rectangle.Y;
    var outline = slide.Shapes.AddAutoShape(ShapeType.Rectangle, overlayX, overlayY, rectangle.Width, rectangle.Height);
    outline.FillFormat.FillType = FillType.NoFill;
    outline.LineFormat.FillFormat.FillType = FillType.Solid;
    outline.LineFormat.FillFormat.SolidFillColor.Color = Color.Red;
}

presentation.Save("text-rectangles.pptx", SaveFormat.Pptx);
```

Para las formas de 200 × 100 puntos mostradas arriba, el rectángulo devuelve `(0, 0, 200, 100)`; la elipse devuelve aproximadamente `(29.289, 14.645, 141.421, 70.711)`. El método también lee el rectángulo de texto declarado de una geometría personalizada. No aplica la rotación del espacio de la diapositiva ni transformaciones de grupo; tenga en cuenta esas transformaciones por separado al posicionar una superposición. Un marco de texto sin una forma geométrica, como el de una celda de tabla, puede lanzar `InvalidOperationException`.

## **Añadir columnas a un cuadro de texto**

La propiedad [ITextFrameFormat.ColumnCount](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/columncount/) divide el marco de texto en columnas, mientras que [ITextFrameFormat.ColumnSpacing](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/columnspacing/) establece el espacio entre columnas en puntos. Ambas configuraciones pertenecen a [ITextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/) y pueden modificarse a través del marco de texto de un cuadro de texto existente. El texto se reorganiza entre columnas dentro de la misma forma; no continúa en otra forma.

El siguiente ejemplo crea un cuadro de texto de tres columnas con 10 puntos entre columnas, guarda la presentación y lee de nuevo la configuración almacenada en el archivo de salida:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var textBox = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 200);
textBox.AddTextFrame("This text is distributed automatically across all columns in the text box.");

var textFrameFormat = textBox.TextFrame.TextFrameFormat;
textFrameFormat.ColumnCount = 3;
textFrameFormat.ColumnSpacing = 10;

presentation.Save("TextBoxColumns.pptx", SaveFormat.Pptx);

using var savedPresentation = new Presentation("TextBoxColumns.pptx");
var savedTextBox = (IAutoShape)savedPresentation.Slides[0].Shapes[0];
var savedFormat = savedTextBox.TextFrame.TextFrameFormat;
Console.WriteLine($"Columns: {savedFormat.ColumnCount}; spacing: {savedFormat.ColumnSpacing} points");
```

## **Extraer texto de columnas individuales**

Utilice [TextFrame.SplitTextByColumns](https://reference.aspose.com/slides/net/aspose.slides/textframe/splittextbycolumns/) para obtener el texto asignado a cada columna visual en un marco de texto existente. El método devuelve una cadena por columna, en orden de lectura basado en columnas. Un marco de texto de una sola columna produce una matriz con un elemento, y una columna vacía se representa con una cadena vacía. Las cadenas contienen solo texto plano; el formato a nivel de porción no se conserva.

Esto es útil cuando necesita:

- Extraer texto preservando su orden de lectura basado en columnas.
- Indexar o comparar el contenido de diapositivas multicolumna.
- Exportar cada columna a un archivo separado, campo de base de datos u otro destino.
- Inspeccionar cómo se redistribuye el texto después de cambiar [ITextFrameFormat.ColumnCount](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/columncount/), [ITextFrameFormat.ColumnSpacing](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/columnspacing/), la fuente o el tamaño del marco de texto.

El método informa del texto distribuido dentro del [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) actual; no fluye automáticamente el texto entre formas o cuadros de texto separados. La distribución en columnas puede depender de las fuentes disponibles y de otras configuraciones de diseño de texto, por lo que asegúrese de que las fuentes requeridas estén disponibles cuando la consistencia de los resultados sea importante.

El siguiente ejemplo carga una presentación, encuentra la primera forma automática multicolumna con un marco de texto, lee su número de columnas configurado y escribe el texto de cada columna en un archivo separado. Las formas que no proporcionan un marco de texto se omiten.

```csharp
using System;
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation("MultiColumnText.pptx");

IAutoShape? textBox = null;
foreach (var shape in presentation.Slides[0].Shapes)
{
    if (shape is IAutoShape autoShape && autoShape.TextFrame is not null)
    {
        var columnCount = autoShape.TextFrame.TextFrameFormat.ColumnCount;
        if (columnCount > 1)
        {
            textBox = autoShape;
            break;
        }
    }
}

if (textBox is null)
{
    Console.WriteLine("No multi-column text frame was found.");
}
else
{
    var textFrame = textBox.TextFrame;
    var configuredColumnCount = textFrame.TextFrameFormat.ColumnCount;
    var columnTexts = textFrame.SplitTextByColumns();

    Console.WriteLine($"Configured columns: {configuredColumnCount}");

    for (var columnIndex = 0; columnIndex < columnTexts.Length; columnIndex++)
    {
        var columnNumber = columnIndex + 1;
        var columnText = columnTexts[columnIndex];
        Console.WriteLine($"Column {columnNumber}: {columnText}");
        File.WriteAllText($"Column-{columnNumber}.txt", columnText);
    }
}
```

## **Actualizar texto**

Para actualizar texto en toda la presentación, recorra las diapositivas y las formas, seleccione las formas automáticas y luego edite sus porciones de texto. Trabajar a nivel de porción le permite cambiar tanto el texto como el formato de los caracteres.

El siguiente ejemplo sustituye cada aparición de `years` por `months` en el texto de las formas automáticas y pone en negrita cada porción afectada:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Text.pptx");

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape is not IAutoShape autoShape)
        {
            continue;
        }

        foreach (var paragraph in autoShape.TextFrame.Paragraphs)
        {
            foreach (var portion in paragraph.Portions)
            {
                portion.Text = portion.Text.Replace("years", "months");
                portion.PortionFormat.FontBold = NullableBool.True;
            }
        }
    }
}

presentation.Save("TextChanged.pptx", SaveFormat.Pptx);
```

Este recorrido actualiza el texto solo en formas automáticas. El texto almacenado en tablas, gráficos, SmartArt o formas agrupadas requiere recorrer las colecciones propias de esos objetos.

## **Añadir un cuadro de texto con hipervínculo**

Se puede asignar un hipervínculo a una porción de texto específica, de modo que solo ese texto actúe como enlace clicable. Utilice [IHyperlinkManager.SetExternalHyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/setexternalhyperlinkclick/) para asociar la porción a una URL externa.

El siguiente ejemplo crea texto con enlace y lo guarda en una presentación:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var textBox = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 150, 200, 50);
textBox.AddTextFrame("Aspose.Slides");

var textPortion = textBox.TextFrame.Paragraphs[0].Portions[0];
textPortion.PortionFormat.HyperlinkManager.SetExternalHyperlinkClick("https://www.aspose.com/");

presentation.Save("Hyperlink.pptx", SaveFormat.Pptx);
```

## **FAQ**

**¿Cuál es la diferencia entre un cuadro de texto y un marcador de posición de texto en una diapositiva maestra o de diseño?**

Un [placeholder](/slides/es/net/manage-placeholder/) puede heredar su posición y formato de una [master slide](https://reference.aspose.com/slides/net/aspose.slides/masterslide/) o [layout slide](https://reference.aspose.com/slides/net/aspose.slides/layoutslide/). Un cuadro de texto normal es una forma independiente en la diapositiva donde se creó y no adquiere el comportamiento de marcador de posición cuando el diseño cambia.

**¿Cómo puedo sustituir texto sin modificar el texto de gráficos, tablas o SmartArt?**

Limite el recorrido a las formas que implementen [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/), como se muestra en el ejemplo de Actualizar texto. Los gráficos, tablas y SmartArt almacenan texto en sus propios modelos de objetos, por lo que no se modifican con ese bucle.