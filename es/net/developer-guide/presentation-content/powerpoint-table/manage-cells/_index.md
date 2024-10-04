---
title: Gestionar Celdas
type: docs
weight: 30
url: /net/manage-cells/
keywords:
- tabla
- celdas combinadas
- celdas divididas
- imagen en celda de tabla
- C#
- Csharp
- Aspose.Slides para .NET
description: "Celdas de tabla en presentaciones de PowerPoint en C# o .NET"
---

## **Identificar Celda de Tabla Combinada**

1. Crea una instancia de la [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) class.
2. Obtén la tabla de la primera diapositiva. 
3. Itera a través de las filas y columnas de la tabla para encontrar celdas combinadas.
4. Imprime un mensaje cuando se encuentren celdas combinadas.

Este código C# te muestra cómo identificar celdas de tabla combinadas en una presentación:

```c#
using (Presentation pres = new Presentation("SomePresentationWithTable.pptx"))
{
    ITable table = pres.Slides[0].Shapes[0] as ITable; // suponiendo que Slide#0.Shape#0 es una tabla
    for (int i = 0; i < table.Rows.Count; i++)
    {
        for (int j = 0; j < table.Columns.Count; j++)
        {
            ICell currentCell = table.Rows[i][j];
            if (currentCell.IsMergedCell)
            {
                Console.WriteLine(string.Format("La celda {0};{1} es parte de una celda combinada con RowSpan={2} y ColSpan={3} comenzando desde la celda {4};{5}.",
                                  i, j, currentCell.RowSpan, currentCell.ColSpan, currentCell.FirstRowIndex, currentCell.FirstColumnIndex));


            }
        }
    }
}
```

## **Eliminar Bordes de Celdas de Tabla**
1. Crea una instancia de la clase `Presentation`.
2. Obtén una referencia de la diapositiva a través de su índice. 
3. Define un array de columnas con ancho.
4. Define un array de filas con altura.
5. Agrega una tabla a la diapositiva a través del método `AddTable`.
6. Itera a través de cada celda para eliminar los bordes superior, inferior, derecho e izquierdo.
7. Guarda la presentación modificada como un archivo PPTX.

Este código C# te muestra cómo eliminar los bordes de las celdas de tabla:

```c#
// Instancia la clase Presentation que representa un archivo PPTX
using (Presentation pres = new Presentation())
{
   // Accede a la primera diapositiva
    Slide sld = (Slide)pres.Slides[0];

    // Define columnas con anchos y filas con alturas
    double[] dblCols = { 50, 50, 50, 50 };
    double[] dblRows = { 50, 30, 30, 30, 30 };

    // Agrega la forma de tabla a la diapositiva
    ITable tbl = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

    // Establece el formato del borde para cada celda
    foreach (IRow row in tbl.Rows)
        foreach (ICell cell in row)
        {
            cell.CellFormat.BorderTop.FillFormat.FillType = FillType.NoFill;
            cell.CellFormat.BorderBottom.FillFormat.FillType = FillType.NoFill;
            cell.CellFormat.BorderLeft.FillFormat.FillType = FillType.NoFill;
            cell.CellFormat.BorderRight.FillFormat.FillType = FillType.NoFill;
        }

    // Escribe el archivo PPTX en el disco
    pres.Save("table_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Numeración en Celdas Combinadas**
Si combinamos 2 pares de celdas (1, 1) x (2, 1) y (1, 2) x (2, 2), la tabla resultante estará numerada. Este código C# demuestra el proceso:

```c#
// Instancia la clase Presentation que representa un archivo PPTX
using (Presentation presentation = new Presentation())
{
    // Accede a la primera diapositiva
    ISlide sld = presentation.Slides[0];

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

    // Combina celdas (1, 1) x (2, 1)
    tbl.MergeCells(tbl[1, 1], tbl[2, 1], false);

    // Combina celdas (1, 2) x (2, 2)
    tbl.MergeCells(tbl[1, 2], tbl[2, 2], false);

    presentation.Save("MergeCells_out.pptx", SaveFormat.Pptx);
}
```

Luego combinamos las celdas aún más combinando (1, 1) y (1, 2). El resultado es una tabla que contiene una gran celda combinada en su centro:

```c#
// Instancia la clase Presentation que representa un archivo PPTX
using (Presentation presentation = new Presentation())
{
    // Accede a la primera diapositiva
    ISlide slide = presentation.Slides[0];

    // Define columnas con anchos y filas con alturas
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // Agrega una forma de tabla a la diapositiva
    ITable table = slide.Shapes.AddTable(100, 50, dblCols, dblRows);

    // Establece el formato del borde para cada celda
    foreach (IRow row in table.Rows)
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

    // Combina celdas (1, 1) x (2, 1)
    table.MergeCells(table[1, 1], table[2, 1], false);

    // Combina celdas (1, 2) x (2, 2)
    table.MergeCells(table[1, 2], table[2, 2], false);

    // Combina celdas (1, 1) y (1, 2)
    table.MergeCells(table[1, 1], table[1, 2], true);

    // Escribe el archivo PPTX en el disco
    presentation.Save("MergeCells1_out.pptx", SaveFormat.Pptx);
}
```

## **Numeración en Celda Dividida**
En los ejemplos anteriores, cuando las celdas de la tabla se combinaron, la numeración o el sistema de números en otras celdas no cambió. 

Esta vez, tomamos una tabla regular (una tabla sin celdas combinadas) y luego intentamos dividir la celda (1,1) para obtener una tabla especial. Es posible que desees prestar atención a la numeración de esta tabla, que puede considerarse extraña. Sin embargo, así es como Microsoft PowerPoint numera las celdas de la tabla y Aspose.Slides hace lo mismo. 

Este código C# demuestra el proceso que describimos:

```c#
// Instancia la clase Presentation que representa un archivo PPTX
using (Presentation presentation = new Presentation())
{
    // Accede a la primera diapositiva
    ISlide slide = presentation.Slides[0];

    // Define columnas con anchos y filas con alturas
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // Agrega una forma de tabla a la diapositiva
    ITable table = slide.Shapes.AddTable(100, 50, dblCols, dblRows);

    // Establece el formato del borde para cada celda
    foreach (IRow row in table.Rows)
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

    // Combina celdas (1, 1) x (2, 1)
    table.MergeCells(table[1, 1], table[2, 1], false);

    // Combina celdas (1, 2) x (2, 2)
    table.MergeCells(table[1, 2], table[2, 2], false);

    // Divide la celda (1, 1).
    table[1, 1].SplitByWidth(table[2, 1].Width / 2);

    // Escribe el archivo PPTX en el disco
    presentation.Save("CellSplit_out.pptx", SaveFormat.Pptx);
}
```

## **Cambiar el Color de Fondo de la Celda de la Tabla**

Este código C# te muestra cómo cambiar el color de fondo de una celda de tabla:

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    double[] dblCols = { 150, 150, 150, 150 };
    double[] dblRows = { 50, 50, 50, 50, 50 };

    // crea una nueva tabla
    ITable table = slide.Shapes.AddTable(50, 50, dblCols, dblRows);

    // establece el color de fondo para una celda 
    ICell cell = table[2, 3];
    cell.CellFormat.FillFormat.FillType = FillType.Solid;
    cell.CellFormat.FillFormat.SolidFillColor.Color = Color.Red;

    presentation.Save("cell_background_color.pptx", SaveFormat.Pptx);
}
```

## **Agregar Imagen Dentro de la Celda de la Tabla**

1. Crea una instancia de la clase `Presentation`.
2. Obtén una referencia de la diapositiva a través de su índice.
3. Define un array de columnas con ancho.
4. Define un array de filas con altura.
5. Agrega una tabla a la diapositiva a través del método `AddTable`. 
6. Crea un objeto `Bitmap` para contener el archivo de imagen.
7. Agrega la imagen de bitmap al objeto `IPPImage`.
8. Establece el `FillFormat` para la celda de la tabla a `Picture`.
9. Agrega la imagen a la primera celda de la tabla.
10. Guarda la presentación modificada como un archivo PPTX.

Este código C# te muestra cómo colocar una imagen dentro de una celda de tabla al crear una tabla:

```c#
// Instancia la clase Presentation que representa un archivo PPTX
using (Presentation presentation = new Presentation())
{
    // Accede a la primera diapositiva
    ISlide slide = presentation.Slides[0];

    // Define columnas con anchos y filas con alturas
    double[] dblCols = { 150, 150, 150, 150 };
    double[] dblRows = { 100, 100, 100, 100, 90 };

    // Agrega una forma de tabla a la diapositiva
    ITable table = slide.Shapes.AddTable(50, 50, dblCols, dblRows);

    // Carga una imagen desde un archivo y la agrega a los recursos de la presentación
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    // Agrega la imagen a la primera celda de la tabla
    table[0, 0].CellFormat.FillFormat.FillType = FillType.Picture;
    table[0, 0].CellFormat.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
    table[0, 0].CellFormat.FillFormat.PictureFillFormat.Picture.Image = ppImage;

    // Guarda el archivo PPTX en el disco
    presentation.Save("Image_In_TableCell_out.pptx", SaveFormat.Pptx);
}
```