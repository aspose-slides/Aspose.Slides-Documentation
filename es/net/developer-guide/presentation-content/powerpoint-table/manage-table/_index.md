---
title: Gestionar tablas de presentación en .NET
linktitle: Gestionar tabla
type: docs
weight: 10
url: /es/net/manage-table/
keywords:
- añadir tabla
- crear tabla
- acceder tabla
- relación de aspecto
- alinear texto
- formato de texto
- estilo de tabla
- PowerPoint
- presentación
- .NET
- C#
- Aspose.Slides
description: "Crear y editar tablas en diapositivas de PowerPoint con Aspose.Slides para .NET. Descubra ejemplos sencillos de código C# para optimizar sus flujos de trabajo con tablas."
---
## **Introducción**

Las tablas en PowerPoint organizan la información en filas y columnas, lo que facilita la lectura y la comparación de valores.

Aspose.Slides **proporciona** la clase [Table](https://reference.aspose.com/slides/net/aspose.slides/table/), la interfaz [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/), la clase [Cell](https://reference.aspose.com/slides/net/aspose.slides/cell/), la interfaz [ICell](https://reference.aspose.com/slides/net/aspose.slides/icell/) y otros tipos para permitirle crear, actualizar y gestionar tablas en presentaciones.

## **Crear una tabla desde cero**

Cree una tabla especificando su posición, anchuras de columna y alturas de fila. Después de añadirla a una diapositiva, puede dar formato a los bordes de las celdas, combinar celdas e insertar texto.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
2. Obtenga una referencia a la diapositiva por su índice.
3. Defina un array con las anchuras de columna en puntos.
4. Defina un array con las alturas de fila en puntos.
5. Añada un objeto [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) a la diapositiva mediante el método [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/).
6. Recorra cada [ICell](https://reference.aspose.com/slides/net/aspose.slides/icell/) para aplicar formato a los bordes superior, inferior, derecho e izquierdo.
7. Combine las dos primeras celdas de la primera fila de la tabla.
8. Acceda a la celda combinada a través de su propiedad [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/icell/textframe/).
9. Establezca el texto en la celda combinada.
10. Guarde la presentación modificada.

El ejemplo siguiente crea una tabla con tres columnas y cinco filas en la posición (100, 50) puntos. Aplica bordes rojos con un grosor de 5 puntos, combina las dos primeras celdas de la primera fila y guarda el resultado como `table.pptx`.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var columnWidths = new double[] { 50, 50, 50 };
var rowHeights = new double[] { 50, 30, 30, 30, 30 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);

foreach (var row in table.Rows)
{
    foreach (var cell in row)
    {
        var cellFormat = cell.CellFormat;
        cellFormat.BorderTop.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderTop.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderTop.Width = 5;

        cellFormat.BorderBottom.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderBottom.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderBottom.Width = 5;

        cellFormat.BorderLeft.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderLeft.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderLeft.Width = 5;

        cellFormat.BorderRight.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderRight.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderRight.Width = 5;
    }
}

table.MergeCells(table[0, 0], table[1, 0], false);
table[0, 0].TextFrame.Text = "Merged Cells";

presentation.Save("table.pptx", SaveFormat.Pptx);
```

## **Numeración en una tabla estándar**

En una tabla estándar, los índices de celda comienzan en cero y se utilizan en el orden (columna, fila). La primera celda se indexa como (0, 0).

Por ejemplo, las celdas en una tabla con 4 columnas y 4 filas se numeran así:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Este ejemplo crea la tabla 4 × 4 ilustrada arriba, con anchuras de columna y alturas de fila de 70 puntos y bordes de celda rojos con un grosor de 5 puntos. Las coordenadas ilustran los índices de celda; el ejemplo deja las celdas vacías y guarda la tabla como `StandardTables_out.pptx`.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var columnWidths = new double[] { 70, 70, 70, 70 };
var rowHeights = new double[] { 70, 70, 70, 70 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);

foreach (var row in table.Rows)
{
    foreach (var cell in row)
    {
        var cellFormat = cell.CellFormat;
        cellFormat.BorderTop.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderTop.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderTop.Width = 5;

        cellFormat.BorderBottom.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderBottom.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderBottom.Width = 5;

        cellFormat.BorderLeft.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderLeft.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderLeft.Width = 5;

        cellFormat.BorderRight.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderRight.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderRight.Width = 5;
    }
}

presentation.Save("StandardTables_out.pptx", SaveFormat.Pptx);
```

## **Acceder a una tabla existente**

Las tablas se almacenan en la colección de formas de una diapositiva. Recorra las formas para localizar una tabla y, a continuación, utilice la interfaz [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) para leer o actualizar sus celdas.

1. Cargue la presentación mediante la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
2. Obtenga una referencia a la diapositiva que contiene la tabla por su índice.
3. Recorra los objetos [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) y deténgase cuando encuentre una tabla. Si la diapositiva contiene varias tablas, utilice [AlternativeText](https://reference.aspose.com/slides/net/aspose.slides/ishape/alternativetext/) para identificar la que necesita.
4. Actualice el texto en la celda objetivo.
5. Guarde la presentación modificada.

El ejemplo siguiente abre `UpdateExistingTable.pptx` y encuentra la primera tabla en la primera diapositiva. Establece la celda en la columna 0, fila 1 a `New` y guarda el resultado como `table1_out.pptx`. La entrada debe contener al menos una diapositiva, y la primera tabla en esa diapositiva debe tener al menos una columna y dos filas.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("UpdateExistingTable.pptx");
var slide = presentation.Slides[0];
ITable? table = null;

foreach (var shape in slide.Shapes)
{
    if (shape is ITable candidateTable)
    {
        table = candidateTable;
        break;
    }
}

table![0, 1].TextFrame.Text = "New";

presentation.Save("table1_out.pptx", SaveFormat.Pptx);
```

Para cambiar el tamaño de una fila en una tabla existente y comprender por qué su altura real puede superar la mínima solicitada, consulte [Control Row Height](/slides/es/net/manage-rows-and-columns/#control-row-height).

## **Encontrar la celda que posee un marco de texto**

Cuando el código genérico de procesamiento de texto recibe un [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) de una tabla, use la propiedad [ITextFrame.ParentCell](https://reference.aspose.com/slides/net/aspose.slides/itextframe/parentcell/) para obtener la [ICell](https://reference.aspose.com/slides/net/aspose.slides/icell/) propietaria. Para un marco de texto de celda de tabla, [ITextFrame.ParentCell](https://reference.aspose.com/slides/net/aspose.slides/itextframe/parentcell/) está establecido y [ITextFrame.ParentShape](https://reference.aspose.com/slides/net/aspose.slides/itextframe/parentshape/) es `null`, aunque la tabla misma es una forma.

Las coordenadas de la celda están disponibles a través de las propiedades de solo lectura [ICell.FirstColumnIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstcolumnindex/) e [ICell.FirstRowIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstrowindex/). [ITextFrame.ParentCell](https://reference.aspose.com/slides/net/aspose.slides/itextframe/parentcell/) también es de solo lectura: proporciona navegación hacia el propietario pero no cambia la propiedad. Siempre compruebe que la celda devuelta no sea `null` antes de usarla.

Para un ejemplo completo que identifica propietarios de celdas de tabla y de formas, incluidas las formas asociadas a nodos de SmartArt, consulte [Search and Replace Text](/slides/es/net/search-and-replace-text/).

## **Alinear texto en una tabla**

Puede controlar el anclaje vertical y la dirección del texto de celdas individuales de tabla. El ejemplo de esta sección centra el texto dentro de la primera celda y lo gira 270 grados.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
2. Obtenga una referencia a la diapositiva por su índice.
3. Añada un objeto [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) a la diapositiva.
4. Acceda a un objeto [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) de la tabla.
5. Acceda al primer [IParagraph](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/) y establezca su texto y color.
6. Establezca el [TextAnchorType](https://reference.aspose.com/slides/net/aspose.slides/icell/textanchortype/) y el [TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/icell/textverticaltype/) de la celda.
7. Guarde la presentación modificada.

Este ejemplo crea una tabla 4 × 4 con anchuras de columna de 120 puntos y alturas de fila de 100 puntos. Da formato al texto en la celda (0, 0), añade valores a las celdas restantes de la primera fila y guarda el resultado como `Vertical_Align_Text_out.pptx`.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var columnWidths = new double[] { 120, 120, 120, 120 };
var rowHeights = new double[] { 100, 100, 100, 100 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);
table[1, 0].TextFrame.Text = "10";
table[2, 0].TextFrame.Text = "20";
table[3, 0].TextFrame.Text = "30";

var cell = table[0, 0];
var paragraph = cell.TextFrame.Paragraphs[0];
var portion = paragraph.Portions[0];
portion.Text = "Text here";
portion.PortionFormat.FillFormat.FillType = FillType.Solid;
portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

cell.TextAnchorType = TextAnchorType.Center;
cell.TextVerticalType = TextVerticalType.Vertical270;

presentation.Save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx);
```

## **Establecer formato de texto a nivel de tabla**

Utilice [SetTextFormat](https://reference.aspose.com/slides/net/aspose.slides/ibulktextformattable/settextformat/) para aplicar formato de texto a todas las celdas de una tabla. Sus sobrecargas aceptan formato de porción, párrafo y marco de texto, por lo que puede establecer estas propiedades sin iterar por celdas individuales.

1. Cargue la presentación mediante la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
2. Obtenga una referencia a la diapositiva por su índice.
3. Acceda a un objeto [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) de la diapositiva.
4. Establezca el [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) para el texto.
5. Establezca el [Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) y el [MarginRight](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginright/).
6. Establezca el [TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/textverticaltype/).
7. Guarde la presentación modificada.

El ejemplo siguiente abre `table.pptx`, que debe contener al menos una diapositiva con una tabla como su primera forma. Establece el tamaño de fuente a 25 puntos, alinea a la derecha los párrafos con un margen derecho de 20 puntos y hace el texto vertical. La presentación con formato se guarda como `result.pptx`.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("table.pptx");
var slide = presentation.Slides[0];

var table = (ITable)slide.Shapes[0];

var portionFormat = new PortionFormat();
portionFormat.FontHeight = 25;
table.SetTextFormat(portionFormat);

var paragraphFormat = new ParagraphFormat();
paragraphFormat.Alignment = TextAlignment.Right;
paragraphFormat.MarginRight = 20;
table.SetTextFormat(paragraphFormat);

var textFrameFormat = new TextFrameFormat();
textFrameFormat.TextVerticalType = TextVerticalType.Vertical;
table.SetTextFormat(textFrameFormat);

presentation.Save("result.pptx", SaveFormat.Pptx);
```

## **Obtener propiedades de estilo de tabla**

Utilice [StylePreset](https://reference.aspose.com/slides/net/aspose.slides/itable/stylepreset/) para leer o asignar un estilo predefinido a una tabla. Este ejemplo aplica [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/net/aspose.slides/tablestylepreset/) a una tabla, imprime el nombre del preset y asigna el mismo preset a una segunda tabla. Ambas tablas se guardan en `table-style.pptx`.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var columnWidths = new double[] { 100, 150 };
var rowHeights = new double[] { 5, 5, 5 };
var table = slide.Shapes.AddTable(10, 10, columnWidths, rowHeights);
table.StylePreset = TableStylePreset.DarkStyle1;

var stylePreset = table.StylePreset;
Console.WriteLine($"Table style preset: {stylePreset}");

var anotherTable = slide.Shapes.AddTable(10, 100, columnWidths, rowHeights);
anotherTable.StylePreset = stylePreset;

presentation.Save("table-style.pptx", SaveFormat.Pptx);
```

## **Bloquear la proporción de aspecto de una tabla**

La proporción de aspecto de una tabla es la relación entre su anchura y su altura. Utilice [AspectRatioLocked](https://reference.aspose.com/slides/net/aspose.slides/igraphicalobjectlock/aspectratiolocked/) para bloquear esta relación en una tabla.

El ejemplo siguiente abre `pres.pptx`, que debe contener al menos una diapositiva con una tabla como su primera forma. Imprime el estado de bloqueo actual, habilita el bloqueo de proporción de aspecto, imprime el estado actualizado (`True`) y guarda el resultado como `pres-out.pptx`.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");
var slide = presentation.Slides[0];

var table = (ITable)slide.Shapes[0];

Console.WriteLine($"Lock aspect ratio set: {table.ShapeLock.AspectRatioLocked}");

table.ShapeLock.AspectRatioLocked = true;
Console.WriteLine($"Lock aspect ratio set: {table.ShapeLock.AspectRatioLocked}");

presentation.Save("pres-out.pptx", SaveFormat.Pptx);
```

## **Preguntas frecuentes**

**¿Puedo habilitar la dirección de lectura de derecha a izquierda (RTL) para toda una tabla y el texto en sus celdas?**

Sí. La tabla expone una propiedad [RightToLeft](https://reference.aspose.com/slides/net/aspose.slides/table/righttoleft/), y los párrafos tienen [ParagraphFormat.RightToLeft](https://reference.aspose.com/slides/net/aspose.slides/paragraphformat/righttoleft/). Usar ambas garantiza el orden RTL correcto y la representación dentro de las celdas.

**¿Cómo puedo impedir que los usuarios muevan o cambien el tamaño de una tabla en el archivo final?**

Utilice [shape locks](/slides/es/net/applying-protection-to-presentation/) para desactivar el movimiento, el cambio de tamaño, la selección, etc. Estos bloqueos se aplican también a las tablas.

**¿Se admite la inserción de una imagen dentro de una celda como fondo?**

Sí. Puede establecer un [picture fill](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/) para una celda; la imagen cubrirá el área de la celda según el modo elegido (estirado o mosaico).