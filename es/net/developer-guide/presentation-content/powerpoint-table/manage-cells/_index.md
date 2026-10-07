---
title: Gestionar celdas de tabla en presentaciones en .NET
linktitle: Gestionar celdas
type: docs
weight: 30
url: /es/net/manage-cells/
keywords:
- celda de tabla
- combinar celdas
- eliminar borde
- dividir celda
- imagen en celda
- color de fondo
- PowerPoint
- presentación
- .NET
- C#
- Aspose.Slides
description: "Gestiona celdas de tabla de PowerPoint en C#: identifica celdas combinadas, elimina bordes, divide celdas y establece colores de fondo e imágenes con Aspose.Slides para .NET."
---
## **Descripción general**

Aspose.Slides le permite acceder y modificar celdas de tabla en presentaciones de PowerPoint. Este artículo explica cómo identificar celdas de tabla combinadas, eliminar los bordes de una celda, trabajar con la numeración de celdas después de combinar o dividir celdas, cambiar el color de fondo de una celda y añadir una imagen dentro de una celda de tabla. Los ejemplos muestran cómo crear o abrir una presentación, obtener una tabla de una diapositiva, actualizar el formato de la celda a través de sus propiedades y guardar la presentación modificada como un archivo PPTX.

Aspose.Slides utiliza índices basados en cero para acceder a las celdas de tabla en el orden `(column, row)`.

## **Identificar una celda de tabla combinada**

El ejemplo abre una presentación existente y accede a la primera forma en la primera diapositiva como una tabla. Asume que la diapositiva y la forma existen y que la forma es una tabla. Luego recorre todas las filas y columnas y utiliza [IsMergedCell](https://reference.aspose.com/slides/net/aspose.slides/icell/ismergedcell/) para identificar celdas en regiones combinadas. Para cada coincidencia, imprime las coordenadas de la celda en orden `row;column`, [RowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/rowspan/), [ColSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/colspan/), y las coordenadas iniciales de la región, [FirstRowIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstrowindex/) y [FirstColumnIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstcolumnindex/).

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("presentation_with_table.pptx");
var slide = presentation.Slides[0];
var table = (ITable) slide.Shapes[0];

var rowCount = table.Rows.Count;
for (var rowIndex = 0; rowIndex < rowCount; rowIndex++)
{
    var columnCount = table.Columns.Count;
    for (var columnIndex = 0; columnIndex < columnCount; columnIndex++)
    {
        var cell = table[columnIndex, rowIndex];
        if (cell.IsMergedCell)
        {
            Console.WriteLine($"Cell {rowIndex};{columnIndex} belongs to a merged region with RowSpan={cell.RowSpan} and ColSpan={cell.ColSpan} starting at {cell.FirstRowIndex};{cell.FirstColumnIndex}.");
        }
    }
}
```

## **Eliminar los bordes de una celda de tabla**

Cree una [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) y añada una tabla a su primera diapositiva con [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/). Los anchos de columna, las alturas de fila y la posición de la tabla se especifican en puntos. El ejemplo establece los cuatro bordes de la celda a [FillType.NoFill](https://reference.aspose.com/slides/net/aspose.slides/filltype/), haciéndolos invisibles.

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 50, 50, 50, 50 };
double[] rowHeights = { 50, 30, 30, 30, 30 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);

foreach (var row in table.Rows)
    foreach (var cell in row)
    {
        cell.CellFormat.BorderTop.FillFormat.FillType = FillType.NoFill;
        cell.CellFormat.BorderBottom.FillFormat.FillType = FillType.NoFill;
        cell.CellFormat.BorderLeft.FillFormat.FillType = FillType.NoFill;
        cell.CellFormat.BorderRight.FillFormat.FillType = FillType.NoFill;
    }

presentation.Save("table.pptx", SaveFormat.Pptx);
```

## **Combinar celdas de tabla**

Utilice [MergeCells](https://reference.aspose.com/slides/net/aspose.slides/itable/mergecells/) para combinar un rango rectangular de celdas de tabla en una sola celda. Especifique las celdas en las esquinas superior izquierda e inferior derecha del rango. El argumento final controla si la combinación puede incluir celdas fuera del rango especificado; `false` mantiene la combinación dentro de ese rango.

El ejemplo crea una tabla de 4 × 4 con columnas y filas de 70 puntos, luego combina las cuatro celdas centrales desde `(1, 1)` hasta `(2, 2)`. La celda resultante abarca dos columnas y dos filas, mientras que la cuadrícula subyacente de la tabla conserva cuatro columnas y cuatro filas. Para acceder al contenido o formato de la celda combinada, utilice su posición superior izquierda: `table[1, 1]` en este ejemplo. Las demás posiciones dentro del rango combinado siguen formando parte de la cuadrícula de la tabla, por lo que los índices de las celdas fuera del rango no cambian.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 70, 70, 70, 70 };
double[] rowHeights = { 70, 70, 70, 70 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);

table.MergeCells(table[1, 1], table[2, 2], false);

presentation.Save("merged_cells.pptx", SaveFormat.Pptx);
```

## **Dividir celdas de tabla**

Combinar celdas en el ejemplo anterior preserva la cuadrícula de la tabla. Dividir una celda puede introducir una nueva columna en la cuadrícula y cambiar los índices de columna de las celdas a su derecha. Aspose.Slides sigue el modelo de cuadrícula de tabla de PowerPoint.

Este ejemplo crea una tabla de 4 × 4 con columnas y filas de 70 puntos y llama a [SplitByWidth](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbywidth/) sobre la celda `(1, 1)`. La mitad del ancho de 70 puntos de la celda se pasa para crear dos celdas de igual ancho.

Después de esta división, las dos mitades se acceden como `table[1, 1]` y `table[2, 1]`. La cuadrícula de la tabla ahora tiene cinco columnas: las celdas que originalmente estaban en las columnas 2 y 3 se trasladan a las columnas 3 y 4, respectivamente. Los índices de fila permanecen sin cambios. Utilice estos índices de columna actualizados al acceder a las celdas después de la división.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 70, 70, 70, 70 };
double[] rowHeights = { 70, 70, 70, 70 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);

table[1, 1].SplitByWidth(table[1, 1].Width / 2);

presentation.Save("split_cells.pptx", SaveFormat.Pptx);
```

### **Dividir celdas combinadas por extensión de fila o columna**

Para preparar celdas de plantilla combinadas para la población de datos, utilice [SplitByRowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbyrowspan/) para dividir a lo largo de un límite de fila existente, o [SplitByColSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbycolspan/) para dividir a lo largo de un límite de columna.

El argumento `index` cuenta filas en la parte superior o columnas en la parte izquierda de la división; es relativo a la región combinada:

- Divi­sión de fila: `0 < index <` [RowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/rowspan/).
- Divi­sión de columna: `0 < index <` [ColSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/colspan/).

El ejemplo asume que una presentación tiene una tabla como la primera forma en la primera diapositiva, con `(1, 2)` y `(1, 3)` combinadas verticalmente. Partiendo de la posición inferior, utiliza [FirstColumnIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstcolumnindex/) y [FirstRowIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstrowindex/) para localizar el origen y verifica ambas extensiones. `SplitByRowSpan(1)` separa entonces las filas 2 y 3 para los nombres de producto. Para una combinación horizontal de dos columnas, use `SplitByColSpan(1)` en su lugar.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("table_template.pptx");
var slide = presentation.Slides[0];
var table = (ITable) slide.Shapes[0];

var selectedCell = table[1, 3];
var firstColumnIndex = selectedCell.FirstColumnIndex;
var firstRowIndex = selectedCell.FirstRowIndex;
var mergedCell = table[firstColumnIndex, firstRowIndex];

if (mergedCell.IsMergedCell && mergedCell.RowSpan == 2 && mergedCell.ColSpan == 1)
{
    mergedCell.SplitByRowSpan(1);

    // Recuperar las celdas resultantes de la tabla después de dividir.
    var upperCell = table[firstColumnIndex, firstRowIndex];
    var lowerCell = table[firstColumnIndex, firstRowIndex + 1];
    Console.WriteLine($"Upper cell merged: {upperCell.IsMergedCell}");
    Console.WriteLine($"Lower cell merged: {lowerCell.IsMergedCell}");

    upperCell.TextFrame.Text = "Product A";
    lowerCell.TextFrame.Text = "Product B";

    presentation.Save("split_template.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("Select a merged region spanning exactly two rows and one column.");
}
```

La cuadrícula de la tabla y los índices de celdas circundantes permanecen sin cambios. Recupere las celdas resultantes por sus coordenadas; aquí, ambas tienen extensiones de 1 y [IsMergedCell](https://reference.aspose.com/slides/net/aspose.slides/icell/ismergedcell/) muestra `False`. Las regiones más grandes pueden permanecer parcialmente combinadas después de una división.

El texto original y su formato permanecen en la celda superior (o izquierda); la nueva celda está vacía pero hereda el formato de celda como relleno, bordes y márgenes. Rellene las celdas después de dividir y establezca explícitamente cualquier formato de texto necesario.

La presentación guardada contiene celdas separadas “Product A” y “Product B” con el formato de celda de la plantilla conservado. Consulte la [Cell API Reference](https://reference.aspose.com/slides/net/aspose.slides/cell/) para obtener más detalles.

## **Cambiar el color de fondo de la celda de tabla**

Este ejemplo crea una tabla con columnas de 150 puntos y filas de 50 puntos. Establece [FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) a sólido y [SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/solidfillcolor/) a rojo para la celda `(2, 3)`, en la tercera columna y cuarta fila.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 150, 150, 150, 150 };
double[] rowHeights = { 50, 50, 50, 50, 50 };
var table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);

var cell = table[2, 3];
cell.CellFormat.FillFormat.FillType = FillType.Solid;
cell.CellFormat.FillFormat.SolidFillColor.Color = Color.Red;

presentation.Save("cell_background_color.pptx", SaveFormat.Pptx);
```

## **Añadir una imagen dentro de una celda de tabla**

Coloque la imagen de entrada en el directorio de trabajo antes de ejecutar este ejemplo. Carga la imagen con [Images.FromFile](https://reference.aspose.com/slides/net/aspose.slides/images/fromfile/) y la añade a la colección de imágenes de la presentación con [AddImage](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection/addimage/). Luego asigna la imagen al relleno de imagen de la celda `(0, 0)`, la primera celda de la tabla.

[PictureFillMode.Stretch](https://reference.aspose.com/slides/net/aspose.slides/picturefillmode/) estira la imagen para que ocupe toda la celda, lo que puede cambiar su proporción. Los anchos de columna y las alturas de fila están en puntos. La imagen cargada se elimina automáticamente mediante su declaración using.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 150, 150, 150, 150 };
double[] rowHeights = { 100, 100, 100, 100, 90 };
var table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);

using var image = Images.FromFile("aspose_logo.jpg");
var ppImage = presentation.Images.AddImage(image);

table[0, 0].CellFormat.FillFormat.FillType = FillType.Picture;
table[0, 0].CellFormat.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
table[0, 0].CellFormat.FillFormat.PictureFillFormat.Picture.Image = ppImage;

presentation.Save("table_cell_with_image.pptx", SaveFormat.Pptx);
```

## **Preguntas frecuentes**

**¿Puedo establecer distintos grosores y estilos de línea para los diferentes lados de una sola celda?**

Sí. Los bordes [top](https://reference.aspose.com/slides/net/aspose.slides/cellformat/bordertop/)/[bottom](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderbottom/)/[left](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderleft/)/[right](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderright/) tienen propiedades independientes, por lo que el grosor y el estilo de cada lado pueden diferir.

**¿Qué ocurre con la imagen si cambio el tamaño de la columna/fila después de establecer una imagen como fondo de la celda?**

El comportamiento depende del [fill mode](https://reference.aspose.com/slides/net/aspose.slides/picturefillmode/) (estiramiento/entreajuste). Con el estiramiento, la imagen se adapta a la nueva celda; con el entreajuste, los mosaicos se recalculan.

**¿Puedo asignar un hipervínculo a todo el contenido de una celda?**

[Hyperlinks](/slides/es/net/manage-hyperlinks/) se establecen a nivel de texto (porción) dentro del marco de texto de la celda o a nivel de toda la tabla/forma. En la práctica, asigna el enlace a una porción o a todo el texto de la celda.

**¿Puedo establecer diferentes fuentes dentro de una sola celda?**

Sí. El marco de texto de una celda admite [portions](https://reference.aspose.com/slides/net/aspose.slides/portion/) (segmentos) con formato independiente: familia de fuente, estilo, tamaño y color.