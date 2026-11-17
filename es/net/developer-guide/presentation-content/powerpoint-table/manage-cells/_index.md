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
description: "Gestionar celdas de tabla de PowerPoint en C#: identificar celdas combinadas, eliminar bordes, dividir celdas y establecer colores de fondo e imágenes con Aspose.Slides para .NET."
---
## **Descripción general**

Aspose.Slides le permite acceder y modificar celdas de tabla en presentaciones de PowerPoint. Este artículo explica cómo identificar celdas de tabla combinadas, eliminar los bordes de una celda, trabajar con la numeración de celdas después de combinar o dividir celdas, cambiar el color de fondo de una celda y añadir una imagen dentro de una celda de tabla. Los ejemplos muestran cómo crear o abrir una presentación, obtener una tabla de una diapositiva, actualizar el formato de la celda mediante sus propiedades y guardar la presentación modificada como archivo PPTX.

Aspose.Slides utiliza índices basados en cero para acceder a las celdas de tabla en el orden `(columna, fila)`.

## **Identificar una celda de tabla combinada**

El ejemplo abre una presentación existente y accede a la primera forma de la primera diapositiva como una tabla. Se asume que la diapositiva y la forma existen y que la forma es una tabla. A continuación recorre todas las filas y columnas y usa [IsMergedCell](https://reference.aspose.com/slides/net/aspose.slides/icell/ismergedcell/) para identificar celdas en regiones combinadas. Para cada coincidencia, imprime las coordenadas de la celda en orden `fila;columna`, [RowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/rowspan/), [ColSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/colspan/) y las coordenadas iniciales de la región, [FirstRowIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstrowindex/) y [FirstColumnIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstcolumnindex/).

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

Cree una [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) y añada una tabla a su primera diapositiva con [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/). Los anchos de columna, alturas de fila y la posición de la tabla se especifican en puntos. El ejemplo establece los cuatro bordes de la celda a [FillType.NoFill](https://reference.aspose.com/slides/net/aspose.slides/filltype/), haciéndolos invisibles.

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

## **Añadir bordes diagonales a la celda**

Utilice [BorderDiagonalDown](https://reference.aspose.com/slides/net/aspose.slides/icellformat/borderdiagonaldown/) para dibujar una línea desde la esquina superior izquierda a la esquina inferior derecha, y [BorderDiagonalUp](https://reference.aspose.com/slides/net/aspose.slides/icellformat/borderdiagonalup/) para dibujar una línea desde la esquina inferior izquierda a la esquina superior derecha. Una diagonal puede marcar un encabezado de esquina; ambas diagonales pueden formar una X para indicar que la celda no es aplicable.

Cada diagonal es un [ILineFormat](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/). En su [FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/fillformat/), establezca [FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) a [FillType.Solid](https://reference.aspose.com/slides/net/aspose.slides/filltype/) y elija un [SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/solidfillcolor/). Defina el [Width](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/width/) de la línea en puntos.

El ejemplo crea tres celdas en una fila: una diagonal descendente roja, una diagonal ascendente azul y ambas diagonales. Deja sin cambios los bordes superior, inferior, izquierdo y derecho de la celda.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 210, 210, 210 };
double[] rowHeights = { 160 };
var table = slide.Shapes.AddTable(45, 130, columnWidths, rowHeights);

var downwardBorder = table[0, 0].CellFormat.BorderDiagonalDown;
downwardBorder.FillFormat.FillType = FillType.Solid;
downwardBorder.FillFormat.SolidFillColor.Color = Color.Red;
downwardBorder.Width = 3;

var upwardBorder = table[1, 0].CellFormat.BorderDiagonalUp;
upwardBorder.FillFormat.FillType = FillType.Solid;
upwardBorder.FillFormat.SolidFillColor.Color = Color.Blue;
upwardBorder.Width = 5;

var crossDownwardBorder = table[2, 0].CellFormat.BorderDiagonalDown;
crossDownwardBorder.FillFormat.FillType = FillType.Solid;
crossDownwardBorder.FillFormat.SolidFillColor.Color = Color.Red;
crossDownwardBorder.Width = 3;

var crossUpwardBorder = table[2, 0].CellFormat.BorderDiagonalUp;
crossUpwardBorder.FillFormat.FillType = FillType.Solid;
crossUpwardBorder.FillFormat.SolidFillColor.Color = Color.Blue;
crossUpwardBorder.Width = 5;

presentation.Save("diagonal_cell_borders.pptx", SaveFormat.Pptx);
```

Una diagonal es una propiedad de formato, no una división de celda. Cada celda conserva un único [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/icell/textframe/); las regiones a cada lado de una diagonal no pueden editarse independientemente.

La tabla guardada, renderizada en Microsoft PowerPoint:

![Tres celdas de tabla que muestran una diagonal roja de arriba‑izquierda a abajo‑derecha, una diagonal azul de abajo‑izquierda a arriba‑derecha y ambas diagonales formando una X.](diagonal-cell-borders.png)

*De izquierda a derecha: diagonal descendente (roja, 3 pt), diagonal ascendente (azul, 5 pt) y ambas diagonales.*

## **Combinar celdas de tabla**

Utilice [MergeCells](https://reference.aspose.com/slides/net/aspose.slides/itable/mergecells/) para combinar un rango rectangular de celdas de tabla en una sola celda. Especifique las celdas en las esquinas superior‑izquierda e inferior‑derecha del rango. El argumento final controla si la combinación puede incluir celdas fuera del rango especificado; `false` mantiene la combinación dentro de ese rango.

El ejemplo crea una tabla de 4 × 4 con columnas y filas de 70 puntos, luego combina las cuatro celdas centrales desde `(1, 1)` hasta `(2, 2)`. La celda resultante abarca dos columnas y dos filas, mientras que la cuadrícula subyacente de la tabla conserva cuatro columnas y cuatro filas. Para acceder al contenido o formato de la celda combinada, use su posición superior‑izquierda: `table[1, 1]` en este ejemplo. Las demás posiciones del rango combinado siguen formando parte de la cuadrícula, de modo que los índices de las celdas fuera del rango no cambian.

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

Combinar celdas en el ejemplo anterior conserva la cuadrícula de la tabla. Dividir una celda puede introducir una nueva columna en la cuadrícula y cambiar los índices de columna de las celdas situadas a su derecha. Aspose.Slides sigue el modelo de cuadrícula de tabla de PowerPoint.

Este ejemplo crea una tabla de 4 × 4 con columnas y filas de 70 puntos y llama a [SplitByWidth](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbywidth/) sobre la celda `(1, 1)`. La mitad del ancho de 70 puntos de la celda se pasa para crear dos celdas de ancho igual.

Después de esta división, las dos mitades se acceden como `table[1, 1]` y `table[2, 1]`. La cuadrícula de la tabla ahora tiene cinco columnas: las celdas que estaban originalmente en las columnas 2 y 3 pasan a las columnas 3 y 4, respectivamente. Los índices de fila permanecen sin cambios. Utilice estos índices de columna actualizados al acceder a celdas después de la división.

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

Para preparar celdas de plantilla combinadas para la población de datos, use [SplitByRowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbyrowspan/) para dividir a lo largo de un límite de fila existente, o [SplitByColSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbycolspan/) para dividir a lo largo de un límite de columna.

El argumento `index` cuenta filas en la parte superior o columnas en la parte izquierda de la división; es relativo a la región combinada:

- División de fila: `0 < index <` [RowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/rowspan/).
- División de columna: `0 < index <` [ColSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/colspan/).

El ejemplo asume que una presentación tiene una tabla como primera forma en la primera diapositiva, con `(1, 2)` y `(1, 3)` combinados verticalmente. Partiendo de la posición inferior, usa [FirstColumnIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstcolumnindex/) y [FirstRowIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstrowindex/) para localizar el origen y comprueba ambas extensiones. `SplitByRowSpan(1)` separa entonces las filas 2 y 3 para los nombres de producto. Para una combinación horizontal de dos columnas, use `SplitByColSpan(1)`.

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

    // Recuperar las celdas resultantes de la tabla después de la división.
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

La cuadrícula de la tabla y los índices de las celdas circundantes permanecen sin cambios. Obtenga las celdas resultantes por sus coordenadas; aquí, ambas tienen extensiones de 1 y [IsMergedCell](https://reference.aspose.com/slides/net/aspose.slides/icell/ismergedcell/) devuelve `False`. Las regiones más grandes pueden quedar parcialmente combinadas después de una división.

El texto original y su formato permanecen en la celda superior (o izquierda); la nueva celda está vacía pero hereda el formato de la celda, como relleno, bordes y márgenes. Rellene las celdas después de dividir y establezca cualquier formato de texto requerido de forma explícita.

La presentación guardada contiene celdas separadas "Product A" y "Product B" con el formato de celda de la plantilla conservado. Consulte la [Cell API Reference](https://reference.aspose.com/slides/net/aspose.slides/cell/) para más detalles.

<!-- visual-explanation:manage-cells:start -->
[![La celda combinada en la columna 1, filas 2 y 3 se divide en Product A y Product B con los mismos índices de cuadrícula.](visual-manage-cells-62c80896698e.svg)](visual-manage-cells-62c80896698e.svg)

*La división por extensión de fila usa el límite existente. Product A y Product B ocupan (1, 2) y (1, 3), respectivamente.*
<!-- visual-explanation:manage-cells:end -->

### **Dividir una celda a una altura específica**

[SplitByHeight](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbyheight/) recibe la altura de la parte superior en puntos. [SplitByRowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbyrowspan/) recibe el número de filas de la cuadrícula existentes en la parte superior. Para centrar una celda de 40 puntos en la columna derecha, reste 40 a la altura real de la celda y distribuya el espacio restante equitativamente arriba y abajo.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 160, 160 };
double[] rowHeights = { 140 };

var table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);
table[0, 0].TextFrame.Text = "Left";

var height = table[1, 0].Height;
var margin = (height - 40) / 2;

table[1, 0].SplitByHeight(margin);
table[1, 1].SplitByHeight(40);
table[1, 1].TextFrame.Text = "Middle";

presentation.Save("split_by_height.pptx", SaveFormat.Pptx);
```

La primera división añade una fila a la cuadrícula, dejando los 90 puntos inferiores en `[1, 1]`. La segunda división apunta a esa celda y añade otra fila debajo. La columna derecha contiene ahora `[1, 0]` a 50 puntos (`margin`), `[1, 1]` a 40 puntos y `[1, 2]` a 50 puntos (`margin`). La celda izquierda abarca las tres filas con su altura original de 140 puntos.

![La celda izquierda abarca toda la altura de la tabla junto a tres celdas con Middle en el centro.](split-by-height.png)

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

[PictureFillMode.Stretch](https://reference.aspose.com/slides/net/aspose.slides/picturefillmode/) estira la imagen para llenar la celda, lo que puede cambiar su proporción. Los anchos de columna y alturas de fila están en puntos. La imagen cargada se dispone automáticamente mediante su declaración `using`.

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

**¿Puedo establecer diferentes grosores y estilos de línea para los distintos lados de una única celda?**

Sí. Los bordes [top](https://reference.aspose.com/slides/net/aspose.slides/cellformat/bordertop/)/[bottom](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderbottom/)/[left](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderleft/)/[right](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderright/) tienen propiedades independientes, por lo que el grosor y el estilo de cada lado pueden diferir.

**¿Qué ocurre con la imagen si cambio el tamaño de la columna/fila después de establecer una foto como fondo de la celda?**

El comportamiento depende del [fill mode](https://reference.aspose.com/slides/net/aspose.slides/picturefillmode/) (stretch/tile). Con estiramiento, la imagen se ajusta a la nueva celda; con mosaico, los mosaicos se recalculan.

**¿Puedo asignar un hipervínculo a todo el contenido de una celda?**

[Hyperlinks](/slides/es/net/manage-hyperlinks/) se establecen a nivel de texto (porción) dentro del marco de texto de la celda o a nivel de toda la tabla/forma. En la práctica, asigna el enlace a una porción o a todo el texto de la celda.

**¿Puedo establecer diferentes fuentes dentro de una única celda?**

Sí. El marco de texto de una celda admite [portions](https://reference.aspose.com/slides/net/aspose.slides/portion/) (segmentos) con formato independiente: familia de fuente, estilo, tamaño y color.