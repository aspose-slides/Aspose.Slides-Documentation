---
title: Administrar Tabla
type: docs
weight: 10
url: /net/manage-table/
keywords: "Tabla, crear tabla, acceder a tabla, relación de aspecto de tabla, presentación de PowerPoint, C#, Csharp, Aspose.Slides para .NET"
description: "Crear y gestionar tablas en presentaciones de PowerPoint en C# o .NET"
---

Una tabla en PowerPoint es una forma eficiente de mostrar y representar información. La información en una cuadrícula de celdas (organizadas en filas y columnas) es clara y fácil de entender.

Aspose.Slides proporciona la clase [Table](https://reference.aspose.com/slides/net/aspose.slides/table/), la interfaz [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/), la clase [Cell](https://reference.aspose.com/slides/net/aspose.slides/cell/), la interfaz [ICell](https://reference.aspose.com/slides/net/aspose.slides/icell/) y otros tipos para permitirle crear, actualizar y gestionar tablas en todo tipo de presentaciones.

## **Crear Tabla Desde Cero**

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Obtenga una referencia de la diapositiva a través de su índice.
3. Defina un arreglo de `columnWidth`.
4. Defina un arreglo de `rowHeight`.
5. Agregue un objeto [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) a la diapositiva a través del método [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/).
6. Itere a través de cada [ICell](https://reference.aspose.com/slides/net/aspose.slides/icell/) para aplicar formato a los bordes superior, inferior, derecho e izquierdo.
7. Fusión de las dos primeras celdas de la primera fila de la tabla.
8. Acceda a un [ICell](https://reference.aspose.com/slides/net/aspose.slides/icell/)'s [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/).
9. Agregue algún texto al [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/).
10. Guarde la presentación modificada.

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

// Establece el formato del borde para cada celda
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
tbl.Rows[0][0].TextFrame.Text = "Celdas Fusionadas";

// Guarda la presentación en el disco
pres.Save("table.pptx", SaveFormat.Pptx);
```

## **Numeración en Tabla Estándar**

En una tabla estándar, la numeración de las celdas es sencilla y comienza desde cero. La primera celda de una tabla se indexa como 0,0 (columna 0, fila 0).

Por ejemplo, las celdas en una tabla con 4 columnas y 4 filas están numeradas de esta manera:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Este código C# le muestra cómo especificar la numeración para celdas en una tabla:

```c#
// Instancia una clase Presentation que representa un archivo PPTX
using (Presentation pres = new Presentation())
{

    // Accede a la primera diapositiva
    ISlide sld = pres.Slides[0];

    // Define columnas con anchos y filas con alturas
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // Agrega una forma de tabla a la diapositiva
    ITable tbl = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

    // Establece el formato del borde para cada celda
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

    // Guarda la presentación en el disco
    pres.Save("StandardTables_out.pptx", SaveFormat.Pptx);
}
```

## **Acceder a Tabla Existente**

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).

2. Obtenga una referencia a la diapositiva que contiene la tabla a través de su índice.

3. Cree un objeto [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) y configúrelo como nulo.

4. Itere a través de todos los objetos [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) hasta que se encuentre la tabla.

   Si sospecha que la diapositiva con la que está tratando contiene una sola tabla, puede simplemente verificar todas las formas que contiene. Cuando se identifica una forma como una tabla, puede convertirla a un objeto [Table](https://reference.aspose.com/slides/net/aspose.slides/table/). Pero si la diapositiva con la que está tratando contiene varias tablas, entonces es mejor buscar la tabla que necesita a través de su [AlternativeText](https://reference.aspose.com/slides/net/aspose.slides/ishape/alternativetext/).

5. Utilice el objeto [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) para trabajar con la tabla. En el ejemplo a continuación, se añadió una nueva fila a la tabla.

6. Guarde la presentación modificada.

Este código C# le muestra cómo acceder y trabajar con una tabla existente:

```c#
// Instancia una clase Presentation que representa un archivo PPTX
using (Presentation pres = new Presentation("UpdateExistingTable.pptx"))
{

    // Accede a la primera diapositiva
    ISlide sld = pres.Slides[0];

    // Inicializa una TablaEx nula
    ITable tbl = null;

    // Itera a través de las formas y establece una referencia a la tabla encontrada
    foreach (IShape shp in sld.Shapes)
        if (shp is ITable)
            tbl = (ITable)shp;

    // Establece el texto para la primera columna de la segunda fila
    tbl[0, 1].TextFrame.Text = "Nuevo";

    // Guarda la presentación modificada en el disco
    pres.Save("table1_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Alinear Texto en Tabla**

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) class.
2. Obtenga una referencia de la diapositiva a través de su índice.
3. Agregue un objeto [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) a la diapositiva.
4. Acceda a un objeto [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) desde la tabla.
5. Acceda al [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) [IParagraph](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/).
6. Alinear el texto verticalmente.
7. Guarde la presentación modificada.

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
portion.Text = "Texto aquí";
portion.PortionFormat.FillFormat.FillType = FillType.Solid;
portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

// Alinea el texto verticalmente
ICell cell = tbl[0, 0];
cell.TextAnchorType = TextAnchorType.Center;
cell.TextVerticalType = TextVerticalType.Vertical270;

// Guarda la presentación en el disco
presentation.Save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx);
```

## **Establecer Formato de Texto a Nivel de Tabla**

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) class.
2. Obtenga una referencia de la diapositiva a través de su índice.
3. Acceda a un objeto [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) desde la diapositiva.
4. Establezca la [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) para el texto.
5. Establezca la [Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) y [MarginRight](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginright/).
6. Establezca el [TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/textverticaltype/).
7. Guarde la presentación modificada.

Este código C# le muestra cómo aplicar sus opciones de formato preferidas al texto en una tabla:

```c#
// Crea una instancia de la clase Presentation
Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

ITable someTable = presentation.Slides[0].Shapes[0] as ITable; // Supongamos que la primera forma en la primera diapositiva es una tabla

// Establece la altura de fuente de las celdas de la tabla
PortionFormat portionFormat = new PortionFormat();
portionFormat.FontHeight = 25;
someTable.SetTextFormat(portionFormat);

// Establece la alineación del texto de las celdas de la tabla y el margen derecho en una sola llamada
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

## **Obtener Propiedades de Estilo de Tabla**

Aspose.Slides le permite recuperar las propiedades de estilo para una tabla para que pueda utilizar esos detalles para otra tabla o en otro lugar. Este código C# le muestra cómo obtener las propiedades de estilo de un estilo de tabla preestablecido:

```c#
using (Presentation pres = new Presentation())
{
    ITable table = pres.Slides[0].Shapes.AddTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.StylePreset = TableStylePreset.DarkStyle1; // cambia el tema de estilo preestablecido por defecto 
    pres.Save("table.pptx", SaveFormat.Pptx);
}
```

## **Bloquear Relación de Aspecto de Tabla**

La relación de aspecto de una forma geométrica es la relación de sus tamaños en diferentes dimensiones. Aspose.Slides proporciona la propiedad `AspectRatioLocked` para permitirle bloquear la configuración de la relación de aspecto para tablas y otras formas.

Este código C# le muestra cómo bloquear la relación de aspecto para una tabla:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    ITable table = (ITable)pres.Slides[0].Shapes[0];
    Console.WriteLine($"Bloquear relación de aspecto establecido: {table.ShapeLock.AspectRatioLocked}");

    table.ShapeLock.AspectRatioLocked = !table.ShapeLock.AspectRatioLocked; // invertir

    Console.WriteLine($"Bloquear relación de aspecto establecido: {table.ShapeLock.AspectRatioLocked}");

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```