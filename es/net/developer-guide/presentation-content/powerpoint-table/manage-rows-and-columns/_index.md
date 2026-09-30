---
title: Gestionar filas y columnas en tablas de PowerPoint en .NET
linktitle: Filas y columnas
type: docs
weight: 20
url: /es/net/manage-rows-and-columns/
keywords:
- fila de tabla
- columna de tabla
- primera fila
- encabezado de tabla
- clonar fila
- clonar columna
- copiar fila
- copiar columna
- eliminar fila
- eliminar columna
- formato de texto de fila
- formato de texto de columna
- estilo de tabla
- PowerPoint
- presentación
- .NET
- C#
- Aspose.Slides
description: "Gestiona filas y columnas de tablas en PowerPoint con Aspose.Slides para .NET y acelera la edición de presentaciones y la actualización de datos."
---
## **Introducción**

Aspose.Slides for .NET le permite gestionar la estructura y el formato de tablas en presentaciones de PowerPoint mediante la clase [Table](https://reference.aspose.com/slides/net/aspose.slides/table/) y la interfaz [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/). Puede designar una fila de encabezado, clonar o eliminar filas y columnas, y aplicar formato de texto a una fila o columna completa.

Este artículo explica estas operaciones con ejemplos en C#. También muestra cómo obtener el preset de estilo de una tabla para que pueda reutilizarlo. Los índices de filas y columnas de la tabla comienzan en cero.

## **Controlar la altura de la fila**

Utilice [IRow.MinimalHeight](https://reference.aspose.com/slides/net/aspose.slides/irow/minimalheight/) para establecer la altura mínima de una fila en puntos. Es un límite inferior, no una altura fija. [IRow.Height](https://reference.aspose.com/slides/net/aspose.slides/irow/height/) devuelve la altura real y es de solo lectura. Acceda a la fila a través de [ITable.Rows](https://reference.aspose.com/slides/net/aspose.slides/itable/rows/).

El ejemplo carga [row-height-input.pptx](row-height-input.pptx), que tiene una tabla como la primera forma en la primera diapositiva. Su primera fila comienza en 70 puntos. Las celdas usan texto Arial de 18 puntos, con ajuste de línea y márgenes superior e inferior de 6 puntos; el texto más largo en la segunda columna se ajusta en varias líneas. El ejemplo aumenta la altura mínima a 100 puntos, luego la reduce a 20 puntos, imprime la altura real después de cada cambio y guarda ambos resultados.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("row-height-input.pptx");
var table = (ITable)presentation.Slides[0].Shapes[0];
var row = table.Rows[0];

row.MinimalHeight = 100;
Console.WriteLine($"Increased: minimum = {row.MinimalHeight:F1}, actual = {row.Height:F1} pt");
presentation.Save("row-height-increased.pptx", SaveFormat.Pptx);

row.MinimalHeight = 20;
Console.WriteLine($"Decreased: minimum = {row.MinimalHeight:F1}, actual = {row.Height:F1} pt");
presentation.Save("row-height-decreased.pptx", SaveFormat.Pptx);
```

Con la presentación suministrada, aumentar el mínimo añade espacio a la fila. Reducirlo elimina ese espacio adicional, pero la altura real sigue siendo mayor de 20 puntos porque el texto y los márgenes de celda necesitan más espacio. Disminuir solo el mínimo no puede forzar que la fila quede por debajo del espacio requerido por su contenido.

Varios factores afectan la altura real:

- **Texto y tamaño de fuente:** el texto más largo, los saltos de línea explícitos o una fuente más grande pueden requerir más espacio vertical.
- **Ajuste y ancho de columna:** con el ajuste habilitado, una [IColumn.Width](https://reference.aspose.com/slides/net/aspose.slides/icolumn/width/) más estrecha puede producir más líneas. Una columna más ancha puede reducir el espacio requerido verticalmente.
- **Márgenes de celda:** [ICell.MarginTop](https://reference.aspose.com/slides/net/aspose.slides/icell/margintop/) y [ICell.MarginBottom](https://reference.aspose.com/slides/net/aspose.slides/icell/marginbottom/) añaden espacio vertical. [ICell.MarginLeft](https://reference.aspose.com/slides/net/aspose.slides/icell/marginleft/) y [ICell.MarginRight](https://reference.aspose.com/slides/net/aspose.slides/icell/marginright/) reducen el ancho disponible para el texto y pueden causar un ajuste adicional.

Para esta tabla sin celdas combinadas, la celda que necesita más espacio vertical determina el límite inferior impulsado por el contenido para toda la fila. Para acortar la fila, también puede ser necesario acortar el texto, reducir el tamaño de fuente o los márgenes, o ensanchar una columna.

Las imágenes a continuación muestran la misma tabla a la misma escala. En esta ejecución, las alturas reales fueron 70, 100 y 55,2 puntos: la fila final permaneció más alta que su mínimo de 20 puntos. Las mediciones exactas del texto pueden variar con las fuentes disponibles en su entorno. Descargue los resultados guardados: [mínimo incrementado](row-height-increased.pptx) y [mínimo reducido](row-height-decreased.pptx).

| Original: mínimo 70 pt, real 70 pt | Incrementado: mínimo 100 pt, real 100 pt | Reducido: mínimo 20 pt, real 55.2 pt |
| --- | --- | --- |
| ![Tabla original con una primera fila de 70 puntos.](row-height-before.png) | ![Tabla después de aumentar el mínimo de la primera fila a 100 puntos.](row-height-increased.png) | ![Tabla después de reducir el mínimo de la primera fila a 20 puntos; el texto ajustado mantiene la fila más alta que el mínimo.](row-height-decreased.png) |

## **Establecer la primera fila como encabezado**

Utilice la propiedad [FirstRow](https://reference.aspose.com/slides/net/aspose.slides/itable/firstrow/) para marcar la primera fila para el formato de encabezado. Su apariencia depende del estilo de tabla aplicado a la tabla.

1. Cargue la presentación con la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
2. Acceda a la primera diapositiva.
3. Acceda a la tabla almacenada como la primera forma en la diapositiva.
4. Active el formato de encabezado para su primera fila.
5. Guarde la presentación modificada.

El ejemplo requiere `table.pptx` con una tabla como la primera forma en la primera diapositiva. Activa el formato de encabezado para la primera fila y guarda `First_row_header.pptx`.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("table.pptx");
var slide = presentation.Slides[0];

var table = (ITable)slide.Shapes[0];
table.FirstRow = true;

presentation.Save("First_row_header.pptx", SaveFormat.Pptx);
```

## **Clonar una fila o columna de tabla**

Clone filas o columnas para reutilizar su contenido y formato. Puede añadir una copia al final de la tabla o insertarla en una posición específica.

1. Cargue la presentación con la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
2. Acceda a la primera diapositiva.
3. Defina los anchos de columna y las alturas de fila.
4. Añada una tabla con el método [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/).
5. Clone las filas requeridas.
6. Clone las columnas requeridas.
7. Guarde la presentación modificada.

El ejemplo requiere `Test.pptx` con al menos una diapositiva. Crea una tabla con tres columnas y cinco filas, con dimensiones especificadas en puntos. Añade copias de la primera fila y columna, luego inserta copias de la segunda fila y columna en el índice 3 (la cuarta posición). La tabla resultante tiene siete filas y cinco columnas. El argumento `false` desactiva la clonación en filas o columnas combinadas adyacentes; esta tabla no tiene celdas combinadas.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Test.pptx");
var slide = presentation.Slides[0];

var columnWidths = new double[] { 50, 50, 50 };
var rowHeights = new double[] { 50, 30, 30, 30, 30 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);

table[0, 0].TextFrame.Text = "Row 1 Cell 1";
table[1, 0].TextFrame.Text = "Row 1 Cell 2";
table.Rows.AddClone(table.Rows[0], false);

table[0, 1].TextFrame.Text = "Row 2 Cell 1";
table[1, 1].TextFrame.Text = "Row 2 Cell 2";
table.Rows.InsertClone(3, table.Rows[1], false);

table.Columns.AddClone(table.Columns[0], false);
table.Columns.InsertClone(3, table.Columns[1], false);

presentation.Save("table_out.pptx", SaveFormat.Pptx);
```

## **Eliminar una fila o columna de una tabla**

Elimine filas o columnas que ya no son necesarias en una tabla. Eliminar un elemento desplaza los índices de las filas o columnas que le siguen.

1. Cree una presentación con la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
2. Acceda a la primera diapositiva.
3. Defina los anchos de columna y las alturas de fila.
4. Añada una tabla con el método [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/).
5. Elimine la segunda fila y la segunda columna.
6. Guarde la presentación modificada.

Este ejemplo crea una tabla de tres por tres y elimina la fila y la columna en el índice 1, dejando una tabla de dos por dos en `TestTable_out.pptx`. Las dimensiones están en puntos. El argumento `false` desactiva la eliminación de filas o columnas combinadas adyacentes; esta tabla no tiene celdas combinadas.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var columnWidths = new double[] { 100, 50, 30 };
var rowHeights = new double[] { 30, 50, 30 };
var table = slide.Shapes.AddTable(100, 100, columnWidths, rowHeights);

table.Rows.RemoveAt(1, false);
table.Columns.RemoveAt(1, false);

presentation.Save("TestTable_out.pptx", SaveFormat.Pptx);
```

## **Establecer formato de texto a nivel de fila de tabla**

Aplique formato de texto a una fila completa para mantener sus celdas consistentes. Puede establecer propiedades de fuente, formato de párrafo y dirección del texto sin formatear cada celda individualmente.

1. Cargue la presentación con la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
2. Acceda a la tabla en la primera diapositiva.
3. Establezca [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) para la primera fila.
4. Establezca [Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) y [MarginRight](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginright/) para la primera fila.
5. Establezca [TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/textverticaltype/) para la segunda fila.
6. Guarde la presentación modificada.

El ejemplo requiere `table.pptx` con una tabla como la primera forma en la primera diapositiva y al menos dos filas. Aplica texto de 25 puntos, alineación a la derecha y un margen de párrafo derecho de 20 puntos a la primera fila, y luego establece texto vertical en la segunda fila.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("table.pptx");
var slide = presentation.Slides[0];

var table = (ITable)slide.Shapes[0];

var portionFormat = new PortionFormat { FontHeight = 25 };
table.Rows[0].SetTextFormat(portionFormat);

var paragraphFormat = new ParagraphFormat { Alignment = TextAlignment.Right, MarginRight = 20 };
table.Rows[0].SetTextFormat(paragraphFormat);

var textFrameFormat = new TextFrameFormat { TextVerticalType = TextVerticalType.Vertical };
table.Rows[1].SetTextFormat(textFrameFormat);

presentation.Save("row_formatting.pptx", SaveFormat.Pptx);
```

## **Establecer formato de texto a nivel de columna de tabla**

Aplique formato de texto a una columna completa para mantener sus celdas consistentes. Puede establecer propiedades de fuente, formato de párrafo y dirección del texto sin formatear cada celda individualmente.

1. Cargue la presentación con la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
2. Acceda a la tabla en la primera diapositiva.
3. Establezca [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) para la primera columna.
4. Establezca [Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) y [MarginRight](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginright/) para la primera columna.
5. Establezca [TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/textverticaltype/) para la segunda columna.
6. Guarde la presentación modificada.

El ejemplo requiere `table.pptx` con una tabla como la primera forma en la primera diapositiva y al menos dos columnas. Aplica texto de 25 puntos, alineación a la derecha y un margen de párrafo derecho de 20 puntos a la primera columna, y luego establece texto vertical en la segunda columna.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("table.pptx");
var slide = presentation.Slides[0];

var table = (ITable)slide.Shapes[0];

var portionFormat = new PortionFormat { FontHeight = 25 };
table.Columns[0].SetTextFormat(portionFormat);

var paragraphFormat = new ParagraphFormat { Alignment = TextAlignment.Right, MarginRight = 20 };
table.Columns[0].SetTextFormat(paragraphFormat);

var textFrameFormat = new TextFrameFormat { TextVerticalType = TextVerticalType.Vertical };
table.Columns[1].SetTextFormat(textFrameFormat);

presentation.Save("column_formatting.pptx", SaveFormat.Pptx);
```

## **Obtener propiedades de estilo de tabla**

Utilice la propiedad [StylePreset](https://reference.aspose.com/slides/net/aspose.slides/itable/stylepreset/) para obtener el preset aplicado a una tabla y reutilizarlo en otra tabla. Esto identifica el preset en lugar de las anulaciones de formato individual de celdas.

El ejemplo crea una tabla, aplica [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/net/aspose.slides/tablestylepreset/), y lee el preset de nuevo. Imprime `DarkStyle1` y guarda la tabla en `table.pptx`.

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

Console.WriteLine(table.StylePreset);

presentation.Save("table.pptx", SaveFormat.Pptx);
```

## **Preguntas frecuentes**

**¿Puedo aplicar temas/estilos de PowerPoint a una tabla que ya está creada?**

Sí. La tabla hereda el tema de la diapositiva/disposición/maestra, y todavía puede sobrescribir rellenos, bordes y colores de texto sobre ese tema.

**¿Puedo ordenar filas de tabla como en Excel?**

No, las tablas de Aspose.Slides no tienen ordenación o filtros incorporados. Ordene sus datos en memoria primero y luego vuelva a poblar las filas de la tabla en ese orden.

**¿Puedo tener columnas con bandas (rayas) manteniendo colores personalizados en celdas específicas?**

Sí. Active las columnas con bandas, luego sobrescriba celdas específicas con formato local; el formato a nivel de celda tiene prioridad sobre el estilo de tabla.