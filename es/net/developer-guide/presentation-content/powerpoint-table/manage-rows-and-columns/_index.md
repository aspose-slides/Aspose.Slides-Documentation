---
title: Administrar filas y columnas en tablas de PowerPoint en .NET
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
description: "Administre filas y columnas de tablas en PowerPoint con Aspose.Slides para .NET y acelere la edición de presentaciones y la actualización de datos."
---

Para permitirle gestionar las filas y columnas de una tabla en una presentación de PowerPoint, Aspose.Slides proporciona la clase [Table](https://reference.aspose.com/slides/net/aspose.slides/table/), la interfaz [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) y muchos otros tipos. 

## **Set the First Row as a Header**

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) y cargue la presentación. 
2. Obtenga la referencia de una diapositiva mediante su índice. 
3. Cree un objeto [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) y establézcalo en null. 
4. Itere a través de todos los objetos [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) para encontrar la tabla correspondiente. 
5. Establezca la primera fila de la tabla como su encabezado. 

Este código C# le muestra cómo establecer la primera fila de una tabla como su encabezado:
```c#
// Instancia la clase Presentation
Presentation pres = new Presentation("table.pptx");

// Accede a la primera diapositiva
ISlide sld = pres.Slides[0];

// Inicializa la tabla nula
ITable tbl = null;

// Recorre las formas y establece una referencia a la tabla
foreach (IShape shp in sld.Shapes)
{
    if (shp is ITable)
    {
        tbl = (ITable)shp;
    }
}

// Establece la primera fila de la tabla como encabezado
tbl.FirstRow = true;

// Guarda la presentación en disco
pres.Save("First_row_header.pptx", SaveFormat.Pptx);
```


## **Clone a Table Row or Column**

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) y cargue la presentación, 
2. Obtenga la referencia de una diapositiva mediante su índice. 
3. Defina una matriz de `columnWidth`. 
4. Defina una matriz de `rowHeight`. 
5. Añada un objeto [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) a la diapositiva mediante el método [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/). 
6. Clone la fila de la tabla. 
7. Clone la columna de la tabla. 
8. Guarde la presentación modificada. 

Este código C# le muestra cómo clonar la fila o columna de una tabla de PowerPoint:
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

    // Agrega texto a la fila 1 celda 1
    table[0, 0].TextFrame.Text = "Row 1 Cell 1";

    // Agrega texto a la fila 1 celda 2
    table[1, 0].TextFrame.Text = "Row 1 Cell 2";

    // Clona la fila 1 al final de la tabla
    table.Rows.AddClone(table.Rows[0], false);

    // Agrega texto a la fila 2 celda 1
    table[0, 1].TextFrame.Text = "Row 2 Cell 1";

    // Agrega texto a la fila 2 celda 2
    table[1, 1].TextFrame.Text = "Row 2 Cell 2";

    // Clona la fila 2 como la cuarta fila de la tabla
    table.Rows.InsertClone(3,table.Rows[1], false);

    // Clona la primera columna al final
    table.Columns.AddClone(table.Columns[0], false);

    // Clona la segunda columna en el índice 4
    table.Columns.InsertClone(3,table.Columns[1], false);
    
    // Guarda la presentación en disco 
    presentation.Save("table_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **Remove a Row or Column from a Table**

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) y cargue la presentación, 
2. Obtenga la referencia de una diapositiva mediante su índice. 
3. Defina una matriz de `columnWidth`. 
4. Defina una matriz de `rowHeight`. 
5. Añada un objeto [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) a la diapositiva mediante el método [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/). 
6. Elimine la fila de la tabla. 
7. Elimine la columna de la tabla. 
8. Guarde la presentación modificada. 

Este código C# le muestra cómo eliminar una fila o columna de una tabla:
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


## **Set Text Formatting on the Table Row Level**

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) y cargue la presentación, 
2. Obtenga la referencia de una diapositiva mediante su índice. 
3. Acceda al objeto [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) correspondiente de la diapositiva. 
4. Establezca la [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) de las celdas de la primera fila. 
5. Establezca la [Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) y [MarginRight](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginright/) de las celdas de la primera fila. 
6. Establezca la [TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/textverticaltype/) de las celdas de la segunda fila. 
7. Guarde la presentación modificada. 

Este código C# demuestra la operación.
```c#
// Crea una instancia de la clase Presentation
Presentation presentation = new Presentation();
           
ISlide slide = presentation.Slides[0];

ITable someTable = presentation.Slides[0].Shapes[0] as ITable; // Supongamos que la primera forma en la primera diapositiva es una tabla

// Establece la altura de fuente de las celdas de la primera fila
PortionFormat portionFormat = new PortionFormat();
portionFormat.FontHeight = 25;
someTable.Rows[0].SetTextFormat(portionFormat);

// Establece la alineación de texto y el margen derecho de las celdas de la primera fila
ParagraphFormat paragraphFormat = new ParagraphFormat();
paragraphFormat.Alignment = TextAlignment.Right;
paragraphFormat.MarginRight = 20;
someTable.Rows[0].SetTextFormat(paragraphFormat);

// Establece el tipo de orientación vertical del texto de las celdas de la segunda fila
TextFrameFormat textFrameFormat = new TextFrameFormat();
textFrameFormat.TextVerticalType = TextVerticalType.Vertical;
someTable.Rows[1].SetTextFormat(textFrameFormat);

// Guarda la presentación en disco
presentation.Save("result.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```


## **Set Text Formatting on the Table Column Level**

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) y cargue la presentación, 
2. Obtenga la referencia de una diapositiva mediante su índice. 
3. Acceda al objeto [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) correspondiente de la diapositiva. 
4. Establezca la [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) de las celdas de la primera columna. 
5. Establezca la [Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) y [MarginRight](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginright/) de las celdas de la primera columna. 
6. Establezca la [TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/textverticaltype/) de las celdas de la segunda columna. 
7. Guarde la presentación modificada. 

Este código C# demuestra la operación: 
```c#
 // Crea una instancia de la clase Presentation
Presentation pres = new Presentation();
           
ISlide slide = pres.Slides[0];

ITable someTable = pres.Slides[0].Shapes[0] as ITable; // Supongamos que la primera forma en la primera diapositiva es una tabla

// Establece la altura de fuente de las celdas de la primera columna
PortionFormat portionFormat = new PortionFormat();
portionFormat.FontHeight = 25;
someTable.Columns[0].SetTextFormat(portionFormat);

// Establece la alineación de texto y el margen derecho de las celdas de la primera columna en una sola llamada
ParagraphFormat paragraphFormat = new ParagraphFormat();
paragraphFormat.Alignment = TextAlignment.Right;
paragraphFormat.MarginRight = 20;
someTable.Columns[0].SetTextFormat(paragraphFormat);

// Establece el tipo de orientación vertical del texto de las celdas de la segunda columna
TextFrameFormat textFrameFormat = new TextFrameFormat();
textFrameFormat.TextVerticalType = TextVerticalType.Vertical;
someTable.Columns[1].SetTextFormat(textFrameFormat);

// Guarda la presentación en disco
pres.Save("result.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```


## **Get Table Style Properties**

Aspose.Slides le permite recuperar las propiedades de estilo de una tabla para que pueda usar esos detalles en otra tabla o en otro lugar. Este código C# le muestra cómo obtener las propiedades de estilo de un estilo predefinido de tabla: 
```c#
using (Presentation pres = new Presentation())
{
    ITable table = pres.Slides[0].Shapes.AddTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.StylePreset = TableStylePreset.DarkStyle1; // cambia el tema predeterminado del estilo preestablecido
    pres.Save("table.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**Can I apply PowerPoint themes/styles to a table that’s already created?**

**¿Puedo aplicar temas/estilos de PowerPoint a una tabla que ya está creada?**

Sí. La tabla hereda el tema de la diapositiva/disposición/maestro, y aún puede sobrescribir los rellenos, bordes y colores de texto sobre ese tema.

**Can I sort table rows like in Excel?**

**¿Puedo ordenar filas de tabla como en Excel?**

No, las tablas de Aspose.Slides no disponen de ordenación o filtros incorporados. Ordene sus datos en memoria primero, y luego vuelva a rellenar las filas de la tabla en ese orden.

**Can I have banded (striped) columns while keeping custom colors on specific cells?**

**¿Puedo tener columnas con bandas (rayas) manteniendo colores personalizados en celdas específicas?**

Sí. Active las columnas con bandas, luego sobrescriba celdas específicas con formato local; el formato a nivel de celda tiene prioridad sobre el estilo de la tabla.