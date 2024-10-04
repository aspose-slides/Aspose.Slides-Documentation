---
title: Administrar Filas y Columnas
type: docs
weight: 20
url: /es/net/manage-rows-and-columns/
keywords: "Tabla, filas y columnas de la tabla, presentación de PowerPoint, C#, Csharp, Aspose.Slides para .NET"
description: "Administra filas y columnas de tablas en presentaciones de PowerPoint en C# o .NET"

---

Para permitirte administrar las filas y columnas de una tabla en una presentación de PowerPoint, Aspose.Slides proporciona la clase [Table](https://reference.aspose.com/slides/net/aspose.slides/table/), la interfaz [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) y muchos otros tipos.

## **Establecer la Primera Fila como Encabezado**

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) y carga la presentación.
2. Obtén la referencia de una diapositiva a través de su índice.
3. Crea un objeto [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) y establecelo como nulo.
4. Itera a través de todos los objetos [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) para encontrar la tabla relevante.
5. Establece la primera fila de la tabla como su encabezado.

Este código en C# te muestra cómo establecer la primera fila de una tabla como su encabezado:

```c#
// Instancia la clase Presentation
Presentation pres = new Presentation("table.pptx");

// Accede a la primera diapositiva
ISlide sld = pres.Slides[0];

// Inicializa la tabla nula
ITable tbl = null;

// Itera a través de las formas y establece una referencia a la tabla
foreach (IShape shp in sld.Shapes)
{
    if (shp is ITable)
    {
        tbl = (ITable)shp;
    }
}

// Establece la primera fila de la tabla como su encabezado
tbl.FirstRow = true;

// Guarda la presentación en el disco
pres.Save("First_row_header.pptx", SaveFormat.Pptx);
```

## **Clonar Fila o Columna de la Tabla**

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) y carga la presentación.
2. Obtén la referencia de una diapositiva a través de su índice.
3. Define un arreglo de `columnWidth`.
4. Define un arreglo de `rowHeight`.
5. Agrega un objeto [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) a la diapositiva a través del método [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/).
6. Clona la fila de la tabla.
7. Clona la columna de la tabla.
8. Guarda la presentación modificada.

Este código en C# te muestra cómo clonar una fila o columna de una tabla de PowerPoint:

```c#
// Instancia la clase Presentation
using (Presentation presentation = new Presentation("Test.pptx"))
{
    // Accede a la primera diapositiva
    ISlide sld = presentation.Slides[0];

    // Define columnas con anchos y filas con alturas
    double[] dblCols = { 50, 50, 50 };
    double[] dblRows = { 50, 30, 30, 30, 30 };

    // Agrega una forma de tabla a la diapositiva
    ITable table = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

    // Agrega texto a la celda 1 de la fila 1
    table[0, 0].TextFrame.Text = "Celda 1 de la Fila 1";

    // Agrega texto a la celda 2 de la fila 1
    table[1, 0].TextFrame.Text = "Celda 2 de la Fila 1";

    // Clona la Fila 1 al final de la tabla
    table.Rows.AddClone(table.Rows[0], false);

    // Agrega texto a la celda 1 de la fila 2
    table[0, 1].TextFrame.Text = "Celda 1 de la Fila 2";

    // Agrega texto a la celda 2 de la fila 2
    table[1, 1].TextFrame.Text = "Celda 2 de la Fila 2";

    // Clona la Fila 2 como la 4ta fila de la tabla
    table.Rows.InsertClone(3, table.Rows[1], false);

    // Clona la primera columna al final
    table.Columns.AddClone(table.Columns[0], false);

    // Clona la 2da columna en el índice de la 4ta columna
    table.Columns.InsertClone(3, table.Columns[1], false);
    
    // Guarda la presentación en el disco 
    presentation.Save("table_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Eliminar Fila o Columna de la Tabla**

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) y carga la presentación.
2. Obtén la referencia de una diapositiva a través de su índice.
3. Define un arreglo de `columnWidth`.
4. Define un arreglo de `rowHeight`.
5. Agrega un objeto [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) a la diapositiva a través del método [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/).
6. Elimina la fila de la tabla.
7. Elimina la columna de la tabla.
8. Guarda la presentación modificada.

Este código en C# te muestra cómo eliminar una fila o columna de una tabla:

```c#
Presentation pres = new Presentation();

ISlide slide = pres.Slides[0];
double[] colWidth = { 100, 50, 30 };
double[] rowHeight = { 30, 50, 30 };

ITable table = slide.Shapes.AddTable(100, 100, colWidth, rowHeight);
table.Rows.RemoveAt(1, false);
table.Columns.RemoveAt(1, false);
pres.Save("TestTable_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **Establecer Formato de Texto a Nivel de Fila de la Tabla**

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) y carga la presentación.
2. Obtén la referencia de una diapositiva a través de su índice.
3. Accede al objeto [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) relevante desde la diapositiva.
4. Establece la [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) de las celdas de la primera fila.
5. Establece la [Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) y el [MarginRight](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginright/) de las celdas de la primera fila.
6. Establece el [TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/textverticaltype/) de las celdas de la segunda fila.
7. Guarda la presentación modificada.

Este código en C# demuestra la operación.

```c#
// Crea una instancia de la clase Presentation
Presentation presentation = new Presentation();
           
ISlide slide = presentation.Slides[0];

ITable someTable = presentation.Slides[0].Shapes[0] as ITable; // Supongamos que la primera forma en la primera diapositiva es una tabla

// Establece la altura de fuente de las celdas de la primera fila
PortionFormat portionFormat = new PortionFormat();
portionFormat.FontHeight = 25;
someTable.Rows[0].SetTextFormat(portionFormat);

// Establece la alineación del texto y el margen derecho de las celdas de la primera fila
ParagraphFormat paragraphFormat = new ParagraphFormat();
paragraphFormat.Alignment = TextAlignment.Right;
paragraphFormat.MarginRight = 20;
someTable.Rows[0].SetTextFormat(paragraphFormat);

// Establece el tipo de texto vertical de las celdas de la segunda fila
TextFrameFormat textFrameFormat = new TextFrameFormat();
textFrameFormat.TextVerticalType = TextVerticalType.Vertical;
someTable.Rows[1].SetTextFormat(textFrameFormat);

// Guarda la presentación en el disco
presentation.Save("result.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **Establecer Formato de Texto a Nivel de Columna de la Tabla**

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) y carga la presentación.
2. Obtén la referencia de una diapositiva a través de su índice.
3. Accede al objeto [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) relevante desde la diapositiva.
4. Establece la [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) de las celdas de la primera columna.
5. Establece la [Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) y el [MarginRight](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginright/) de las celdas de la primera columna.
6. Establece el [TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/textverticaltype/) de las celdas de la segunda columna.
7. Guarda la presentación modificada.

Este código en C# demuestra la operación:

```c#
// Crea una instancia de la clase Presentation
Presentation pres = new Presentation();
           
ISlide slide = pres.Slides[0];

ITable someTable = pres.Slides[0].Shapes[0] as ITable; // Supongamos que la primera forma en la primera diapositiva es una tabla

// Establece la altura de fuente de las celdas de la primera columna
PortionFormat portionFormat = new PortionFormat();
portionFormat.FontHeight = 25;
someTable.Columns[0].SetTextFormat(portionFormat);

// Establece la alineación del texto y el margen derecho de las celdas de la primera columna en una sola llamada
ParagraphFormat paragraphFormat = new ParagraphFormat();
paragraphFormat.Alignment = TextAlignment.Right;
paragraphFormat.MarginRight = 20;
someTable.Columns[0].SetTextFormat(paragraphFormat);

// Establece el tipo de texto vertical de las celdas de la segunda columna
TextFrameFormat textFrameFormat = new TextFrameFormat();
textFrameFormat.TextVerticalType = TextVerticalType.Vertical;
someTable.Columns[1].SetTextFormat(textFrameFormat);

// Guarda la presentación en el disco
pres.Save("result.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **Obtener Propiedades de Estilo de la Tabla**

Aspose.Slides te permite recuperar las propiedades de estilo de una tabla para que puedas usar esos detalles en otra tabla o en otro lugar. Este código en C# te muestra cómo obtener las propiedades de estilo de un estilo de tabla preestablecido:

```c#
using (Presentation pres = new Presentation())
{
    ITable table = pres.Slides[0].Shapes.AddTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.StylePreset = TableStylePreset.DarkStyle1; // cambia el tema de estilo preestablecido por defecto 
    pres.Save("table.pptx", SaveFormat.Pptx);
}
```