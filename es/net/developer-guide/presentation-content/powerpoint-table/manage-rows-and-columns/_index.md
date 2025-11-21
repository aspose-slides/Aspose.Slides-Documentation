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
description: "Administre filas y columnas de tablas en PowerPoint con Aspose.Slides para .NET y agilice la edición de presentaciones y la actualización de datos."
---

Para permitirle administrar las filas y columnas de una tabla en una presentación de PowerPoint, Aspose.Slides proporciona la clase [Table](https://reference.aspose.com/slides/net/aspose.slides/table/) , la interfaz [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) y muchos otros tipos. 

## **Establecer la primera fila como encabezado**

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) y cargar la presentación. 
2. Obtener la referencia de una diapositiva mediante su índice. 
3. Crear un objeto [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) y establecerlo a null. 
4. Recorrer todos los objetos [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) para encontrar la tabla correspondiente. 
5. Establecer la primera fila de la tabla como su encabezado. 

Este código C# le muestra cómo establecer la primera fila de una tabla como su encabezado:
```c#
// Instancia la clase Presentation
// Accede a la primera diapositiva
// Inicializa la TableEx nula
// Recorre las formas y establece una referencia a la tabla
// Establece la primera fila de una tabla como su encabezado
// Guarda la presentación en disco
Presentation pres = new Presentation("table.pptx");

ISlide sld = pres.Slides[0];

ITable tbl = null;

foreach (IShape shp in sld.Shapes)
{
    if (shp is ITable)
    {
        tbl = (ITable)shp;
    }
}

tbl.FirstRow = true;

pres.Save("First_row_header.pptx", SaveFormat.Pptx);
```



## **Clonar la fila o columna de una tabla**

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) y cargar la presentación, 
2. Obtener la referencia de una diapositiva mediante su índice. 
3. Definir una matriz de `columnWidth`. 
4. Definir una matriz de `rowHeight`. 
5. Añadir un objeto [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) a la diapositiva mediante el método [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/). 
6. Clonar la fila de la tabla. 
7. Clonar la columna de la tabla. 
8. Guardar la presentación modificada. 

Este código C# le muestra cómo clonar una fila o columna de una tabla de PowerPoint:
```c#
 // Instancia la clase Presentation
using (Presentation presentation = new Presentation("Test.pptx"))
{
    // Accede a la primera diapositiva
    ISlide sld = presentation.Slides[0];

    // Define columnas con anchos y filas con alturas
    double[] dblCols = { 50, 50, 50 };
    double[] dblRows = { 50, 30, 30, 30, 30 };

    // Añade una forma de tabla a la diapositiva
    ITable table = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

    // Añade texto a la fila 1 celda 1
    table[0, 0].TextFrame.Text = "Row 1 Cell 1";

    // Añade texto a la fila 1 celda 2
    table[1, 0].TextFrame.Text = "Row 1 Cell 2";

    // Clona la fila 1 al final de la tabla
    table.Rows.AddClone(table.Rows[0], false);

    // Añade texto a la fila 2 celda 1
    table[0, 1].TextFrame.Text = "Row 2 Cell 1";

    // Añade texto a la fila 2 celda 2
    table[1, 1].TextFrame.Text = "Row 2 Cell 2";

    // Clona la fila 2 como la cuarta fila de la tabla
    table.Rows.InsertClone(3,table.Rows[1], false);

    // Clona la primera columna al final
    table.Columns.AddClone(table.Columns[0], false);

    // Clona la segunda columna en el índice de la cuarta columna
    table.Columns.InsertClone(3,table.Columns[1], false);
    
    // Guarda la presentación en disco 
    presentation.Save("table_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **Eliminar fila o columna de una tabla**

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) y cargar la presentación, 
2. Obtener la referencia de una diapositiva mediante su índice. 
3. Definir una matriz de `columnWidth`. 
4. Definir una matriz de `rowHeight`. 
5. Añadir un objeto [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) a la diapositiva mediante el método [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/). 
6. Eliminar la fila de la tabla. 
7. Eliminar la columna de la tabla. 
8. Guardar la presentación modificada. 

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


## **Establecer formato de texto a nivel de fila de tabla**

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) y cargar la presentación, 
2. Obtener la referencia de una diapositiva mediante su índice. 
3. Acceder al objeto [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) correspondiente desde la diapositiva. 
4. Establecer la [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) de las celdas de la primera fila. 
5. Establecer la [Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) y [MarginRight](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginright/) de las celdas de la primera fila. 
6. Establecer la [TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/textverticaltype/) de las celdas de la segunda fila. 
7. Guardar la presentación modificada. 

Este código C# demuestra la operación.
```c#
// Crea una instancia de la clase Presentation
Presentation presentation = new Presentation();
           
ISlide slide = presentation.Slides[0];

ITable someTable = presentation.Slides[0].Shapes[0] as ITable; // Supongamos que la primera forma de la primera diapositiva es una tabla

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

// Guarda la presentación en disco
presentation.Save("result.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```


## **Establecer formato de texto a nivel de columna de tabla**

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) y cargar la presentación, 
2. Obtener la referencia de una diapositiva mediante su índice. 
3. Acceder al objeto [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) correspondiente desde la diapositiva. 
4. Establecer la [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) de las celdas de la primera columna. 
5. Establecer la [Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) y [MarginRight](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginright/) de las celdas de la primera columna. 
6. Establecer la [TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/textverticaltype/) de las celdas de la segunda columna. 
7. Guardar la presentación modificada. 

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

// Establece el tipo de texto vertical de las celdas de la segunda columna
TextFrameFormat textFrameFormat = new TextFrameFormat();
textFrameFormat.TextVerticalType = TextVerticalType.Vertical;
someTable.Columns[1].SetTextFormat(textFrameFormat);

// Guarda la presentación en disco
pres.Save("result.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```


## **Obtener propiedades de estilo de tabla**

Aspose.Slides le permite recuperar las propiedades de estilo de una tabla para que pueda usar esos detalles en otra tabla o en otro lugar. Este código C# le muestra cómo obtener las propiedades de estilo de un estilo predefinido de tabla: 
```c#
using (Presentation pres = new Presentation())
{
    ITable table = pres.Slides[0].Shapes.AddTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.StylePreset = TableStylePreset.DarkStyle1; // cambia el tema predeterminado del preset de estilo
    pres.Save("table.pptx", SaveFormat.Pptx);
}
```


## **Preguntas frecuentes**

**¿Puedo aplicar temas/estilos de PowerPoint a una tabla que ya está creada?**

Sí. La tabla hereda el tema de la diapositiva/diseño/maestro, y aún puede sobrescribir los rellenos, bordes y colores de texto sobre ese tema.

**¿Puedo ordenar filas de tabla como en Excel?**

No, las tablas de Aspose.Slides no tienen ordenación o filtros incorporados. Ordene sus datos en memoria primero, y luego vuelva a rellenar las filas de la tabla en ese orden.

**¿Puedo tener columnas con bandas (rayadas) mientras mantengo colores personalizados en celdas específicas?**

Sí. Active las columnas con bandas, luego sobrescriba celdas específicas con formato local; el formato a nivel de celda tiene precedencia sobre el estilo de tabla.