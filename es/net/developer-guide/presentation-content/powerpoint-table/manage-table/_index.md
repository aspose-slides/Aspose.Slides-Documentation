---
title: Administrar tablas de presentación en .NET
linktitle: Administrar tabla
type: docs
weight: 10
url: /es/net/manage-table/
keywords:
- agregar tabla
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
description: "Crear y editar tablas en diapositivas de PowerPoint con Aspose.Slides para .NET. Descubra ejemplos simples de código C# para optimizar sus flujos de trabajo con tablas."
---

Una tabla en PowerPoint es una forma eficiente de mostrar y representar información. La información en una cuadrícula de celdas (dispuestas en filas y columnas) es directa y fácil de entender.

Aspose.Slides proporciona la clase [Table](https://reference.aspose.com/slides/net/aspose.slides/table/), la interfaz [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/), la clase [Cell](https://reference.aspose.com/slides/net/aspose.slides/cell/), la interfaz [ICell](https://reference.aspose.com/slides/net/aspose.slides/icell/) y otros tipos para permitirle crear, actualizar y gestionar tablas en todo tipo de presentaciones. 

## **Crear una tabla desde cero**

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).  
2. Obtener la referencia a una diapositiva mediante su índice.  
3. Definir una matriz de `columnWidth`.  
4. Definir una matriz de `rowHeight`.  
5. Añadir un objeto [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) a la diapositiva mediante el método [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/).  
6. Recorrer cada [ICell](https://reference.aspose.com/slides/net/aspose.slides/icell/) para aplicar formato a los bordes superior, inferior, derecho e izquierdo.  
7. Fusionar las dos primeras celdas de la primera fila de la tabla.  
8. Acceder al [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/) de un [ICell](https://reference.aspose.com/slides/net/aspose.slides/icell/).  
9. Añadir texto al [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/).  
10. Guardar la presentación modificada.

Este código C# le muestra cómo crear una tabla en una presentación:
```c#
// Instancia una clase Presentation que representa un archivo PPTX
Presentation pres = new Presentation();

// Accede a la primera diapositiva
ISlide sld = pres.Slides[0];

// Define columnas con anchos y filas con alturas
double[] dblCols = { 50, 50, 50 };
double[] dblRows = { 50, 30, 30, 30, 30 };

// Agrega una forma de tabla a la diapositiva
ITable tbl = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

// Establece el formato de borde para cada celda
for (int row = 0; row < tbl.Rows.Count; row++)
{
	for (int cell = 0; cell < tbl.Rows[row].Count; cell++)
	{
		tbl.Rows[row][cell].CellFormat.BorderTop.FillFormat.FillType = FillType.Solid;
		tbl.Rows[row][cell].CellFormat.BorderTop.FillFormat.SolidFillColor.Color = Color.Red;
		tbl.Rows[row][cell].CellFormat.BorderTop.Width = 5;

		tbl.Rows[row][cell].CellFormat.BorderBottom.FillFormat.FillType = (FillType.Solid);
		tbl.Rows[row][cell].CellFormat.BorderBottom.FillFormat.SolidFillColor.Color= Color.Red;
		tbl.Rows[row][cell].CellFormat.BorderBottom.Width =5;

		tbl.Rows[row][cell].CellFormat.BorderLeft.FillFormat.FillType = FillType.Solid;
		tbl.Rows[row][cell].CellFormat.BorderLeft.FillFormat.SolidFillColor.Color =Color.Red;
		tbl.Rows[row][cell].CellFormat.BorderLeft.Width = 5;

		tbl.Rows[row][cell].CellFormat.BorderRight.FillFormat.FillType = FillType.Solid;
		tbl.Rows[row][cell].CellFormat.BorderRight.FillFormat.SolidFillColor.Color = Color.Red;
		tbl.Rows[row][cell].CellFormat.BorderRight.Width = 5;
	}
}
// Fusiona las celdas 1 y 2 de la fila 1
tbl.MergeCells(tbl.Rows[0][0], tbl.Rows[1][1], false);

// Agrega texto a la celda fusionada
tbl.Rows[0][0].TextFrame.Text = "Merged Cells";

// Guarda la presentación en disco
pres.Save("table.pptx", SaveFormat.Pptx);
```


## **Numeración en una tabla estándar**

En una tabla estándar, la numeración de celdas es directa y basada en cero. La primera celda de una tabla tiene el índice 0,0 (columna 0, fila 0).

Por ejemplo, las celdas en una tabla de 4 columnas y 4 filas se numeran de la siguiente manera:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Este código C# le muestra cómo especificar la numeración de las celdas en una tabla:
```c#
// Instancia una clase Presentation que representa un archivo PPTX
using (Presentation pres = new Presentation())
{

    // Accede a la primera diapositiva
    ISlide sld = pres.Slides[0];

    // Define columnas con anchos y filas con alturas
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // Añade una forma de tabla a la diapositiva
    ITable tbl = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

    // Establece el formato de borde para cada celda
    foreach (IRow row in tbl.Rows)
    {
        foreach (ICell cell in row)
        {
			cell.CellFormat.BorderTop.FillFormat.FillType = FillType.Solid;
			cell.CellFormat.BorderTop.FillFormat.SolidFillColor.Color = Color.Red;
			cell.CellFormat.BorderTop.Width = 5;

			cell.CellFormat.BorderBottom.FillFormat.FillType = FillType.Solid;
			cell.CellFormat.BorderBottom.FillFormat.SolidFillColor.Color = Color.Red;
			cell.CellFormat.BorderBottom.Width = 5;

			cell.CellFormat.BorderLeft.FillFormat.FillType = FillType.Solid;
			cell.CellFormat.BorderLeft.FillFormat.SolidFillColor.Color = Color.Red;
			cell.CellFormat.BorderLeft.Width = 5;

			cell.CellFormat.BorderRight.FillFormat.FillType = FillType.Solid;
			cell.CellFormat.BorderRight.FillFormat.SolidFillColor.Color = Color.Red;
			cell.CellFormat.BorderRight.Width = 5;
        }
    }

    // Guarda la presentación en disco
    pres.Save("StandardTables_out.pptx", SaveFormat.Pptx);
}
```


## **Acceder a una tabla existente**

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).  

2. Obtener una referencia a la diapositiva que contiene la tabla mediante su índice.  

3. Crear un objeto [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) y asignarle null.  

4. Recorrer todos los objetos [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) hasta encontrar la tabla.  

   Si sospecha que la diapositiva que está tratando contiene una única tabla, puede simplemente comprobar todas las formas que contiene. Cuando una forma se identifica como tabla, puede convertirla a un objeto [Table](https://reference.aspose.com/slides/net/aspose.slides/table/). Pero si la diapositiva contiene varias tablas, es mejor buscar la tabla que necesita mediante su [AlternativeText](https://reference.aspose.com/slides/net/aspose.slides/ishape/alternativetext/).  

5. Utilizar el objeto [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) para trabajar con la tabla. En el ejemplo siguiente, añadimos una nueva fila a la tabla.  

6. Guardar la presentación modificada.

Este código C# le muestra cómo acceder y trabajar con una tabla existente:
```c#
// Instancia una clase Presentation que representa un archivo PPTX
using (Presentation pres = new Presentation("UpdateExistingTable.pptx"))
{

    // Accede a la primera diapositiva
    ISlide sld = pres.Slides[0];

    // Inicializa TableEx como null
    ITable tbl = null;

    // Itera a través de las formas y establece una referencia a la tabla encontrada
    foreach (IShape shp in sld.Shapes)
        if (shp is ITable)
            tbl = (ITable)shp;

    // Establece el texto para la primera columna de la segunda fila
    tbl[0, 1].TextFrame.Text = "New";

    // Guarda la presentación modificada en disco
    pres.Save("table1_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **Alinear texto en una tabla**

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).  
2. Obtener la referencia a una diapositiva mediante su índice.  
3. Añadir un objeto [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) a la diapositiva.  
4. Acceder a un objeto [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) de la tabla.  
5. Acceder al [IParagraph](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/) del [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/).  
6. Alinear el texto verticalmente.  
7. Guardar la presentación modificada.

Este código C# le muestra cómo alinear el texto en una tabla:
```c#
// Crea una instancia de la clase Presentation
Presentation presentation = new Presentation();

// Obtiene la primera diapositiva 
ISlide slide = presentation.Slides[0];

// Define columnas con anchos y filas con alturas
double[] dblCols = { 120, 120, 120, 120 };
double[] dblRows = { 100, 100, 100, 100 };

// Agrega la forma de tabla a la diapositiva
ITable tbl = slide.Shapes.AddTable(100, 50, dblCols, dblRows);
tbl[1, 0].TextFrame.Text = "10";
tbl[2, 0].TextFrame.Text = "20";
tbl[3, 0].TextFrame.Text = "30";

// Accede al marco de texto
ITextFrame txtFrame = tbl[0, 0].TextFrame;

// Crea el objeto Paragraph para el marco de texto
IParagraph paragraph = txtFrame.Paragraphs[0];

// Crea el objeto Portion para el párrafo
IPortion portion = paragraph.Portions[0];
portion.Text = "Text here";
portion.PortionFormat.FillFormat.FillType = FillType.Solid;
portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

// Alinea el texto verticalmente
ICell cell = tbl[0, 0];
cell.TextAnchorType = TextAnchorType.Center;
cell.TextVerticalType = TextVerticalType.Vertical270;

// Guarda la presentación en disco
presentation.Save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx);
```


## **Establecer formato de texto a nivel de tabla**

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).  
2. Obtener la referencia a una diapositiva mediante su índice.  
3. Acceder a un objeto [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) de la diapositiva.  
4. Establecer la [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) para el texto.  
5. Establecer la [Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) y [MarginRight](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginright/).  
6. Establecer el [TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/textverticaltype/).  
7. Guardar la presentación modificada.  

Este código C# le muestra cómo aplicar sus opciones de formato preferidas al texto de una tabla:
```c#
// Crea una instancia de la clase Presentation
Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

ITable someTable = presentation.Slides[0].Shapes[0] as ITable; // Supongamos que la primera forma en la primera diapositiva es una tabla

// Establece la altura de fuente de las celdas de la tabla
PortionFormat portionFormat = new PortionFormat();
portionFormat.FontHeight = 25;
someTable.SetTextFormat(portionFormat);

// Establece la alineación de texto y el margen derecho de las celdas de la tabla en una sola llamada
ParagraphFormat paragraphFormat = new ParagraphFormat();
paragraphFormat.Alignment = TextAlignment.Right;
paragraphFormat.MarginRight = 20;
someTable.SetTextFormat(paragraphFormat);

// Establece el tipo de texto vertical de las celdas de la tabla
TextFrameFormat textFrameFormat = new TextFrameFormat();
textFrameFormat.TextVerticalType = TextVerticalType.Vertical;
someTable.SetTextFormat(textFrameFormat);


presentation.Save("result.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```


## **Obtener propiedades de estilo de tabla**

Aspose.Slides le permite recuperar las propiedades de estilo de una tabla para que pueda usar esos detalles en otra tabla o en otro lugar. Este código C# le muestra cómo obtener las propiedades de estilo de un estilo predefinido de tabla: 
```c#
using (Presentation pres = new Presentation())
{
    ITable table = pres.Slides[0].Shapes.AddTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.StylePreset = TableStylePreset.DarkStyle1; // cambia el preset de estilo predeterminado
    pres.Save("table.pptx", SaveFormat.Pptx);
}
```


## **Bloquear la relación de aspecto de una tabla**

La relación de aspecto de una forma geométrica es la proporción de sus tamaños en diferentes dimensiones. Aspose.Slides proporciona la propiedad `AspectRatioLocked` para permitirle bloquear la configuración de relación de aspecto de tablas y otras formas. 

Este código C# le muestra cómo bloquear la relación de aspecto de una tabla:
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    ITable table = (ITable)pres.Slides[0].Shapes[0];
    Console.WriteLine($"Lock aspect ratio set: {table.ShapeLock.AspectRatioLocked}");

    table.ShapeLock.AspectRatioLocked = !table.ShapeLock.AspectRatioLocked; // invertir

    Console.WriteLine($"Lock aspect ratio set: {table.ShapeLock.AspectRatioLocked}");

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```


## **Preguntas frecuentes**

**¿Puedo habilitar la dirección de lectura de derecha a izquierda (RTL) para una tabla completa y el texto en sus celdas?**

Sí. La tabla expone la propiedad [RightToLeft](https://reference.aspose.com/slides/net/aspose.slides/table/righttoleft/), y los párrafos tienen [ParagraphFormat.RightToLeft](https://reference.aspose.com/slides/net/aspose.slides/paragraphformat/righttoleft/). Usar ambos garantiza el orden y el renderizado RTL correctos dentro de las celdas.

**¿Cómo puedo evitar que los usuarios muevan o redimensionen una tabla en el archivo final?**

Utilice [bloqueos de forma](/slides/es/net/applying-protection-to-presentation/) para desactivar el movimiento, redimensionamiento, selección, etc. Estos bloqueos también se aplican a las tablas.

**¿Se admite insertar una imagen dentro de una celda como fondo?**

Sí. Puede establecer un [relleno de imagen](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/) para una celda; la imagen cubrirá el área de la celda según el modo elegido (estiramiento o mosaico).