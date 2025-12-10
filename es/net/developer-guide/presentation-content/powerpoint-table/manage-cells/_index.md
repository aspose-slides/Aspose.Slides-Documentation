---
title: Administrar celdas de tabla en presentaciones en .NET
linktitle: Administrar celdas
type: docs
weight: 30
url: /es/net/manage-cells/
keywords:
- celda de tabla
- fusionar celdas
- eliminar borde
- dividir celda
- imagen en celda
- color de fondo
- PowerPoint
- presentación
- .NET
- C#
- Aspose.Slides
description: "Administre fácilmente celdas de tabla en PowerPoint con Aspose.Slides para .NET. Domine el acceso, la modificación y el estilo de las celdas rápidamente para una automatización de diapositivas sin problemas."
---

## **Identificar una celda de tabla fusionada**

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Obtener la tabla de la primera diapositiva.
3. Recorrer las filas y columnas de la tabla para encontrar celdas fusionadas.
4. Imprimir un mensaje cuando se encuentren celdas fusionadas.

Este código C# le muestra cómo identificar celdas de tabla fusionadas en una presentación:
```c#
using (Presentation pres = new Presentation("SomePresentationWithTable.pptx"))
{
    ITable table = pres.Slides[0].Shapes[0] as ITable; // asumiendo que Slide#0.Shape#0 es una tabla
    for (int i = 0; i < table.Rows.Count; i++)
    {
        for (int j = 0; j < table.Columns.Count; j++)
        {
            ICell currentCell = table.Rows[i][j];
            if (currentCell.IsMergedCell)
            {
                Console.WriteLine(string.Format("Cell {0};{1} is a part of merged cell with RowSpan={2} and ColSpan={3} starting from Cell {4};{5}.",
                                  i, j, currentCell.RowSpan, currentCell.ColSpan, currentCell.FirstRowIndex, currentCell.FirstColumnIndex));


            }
        }
    }
}
```


## **Eliminar los bordes de las celdas de tabla**
1. Crear una instancia de la clase `Presentation`.
2. Obtener la referencia de una diapositiva mediante su índice.
3. Definir una matriz de columnas con ancho.
4. Definir una matriz de filas con altura.
5. Agregar una tabla a la diapositiva mediante el método `AddTable`.
6. Recorrer cada celda para borrar los bordes superior, inferior, derecho e izquierdo.
7. Guardar la presentación modificada como un archivo PPTX.

Este código C# le muestra cómo eliminar los bordes de las celdas de tabla:
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

    // Establece el formato de borde para cada celda
    foreach (IRow row in tbl.Rows)
        foreach (ICell cell in row)
        {
            cell.CellFormat.BorderTop.FillFormat.FillType = FillType.NoFill;
            cell.CellFormat.BorderBottom.FillFormat.FillType = FillType.NoFill;
            cell.CellFormat.BorderLeft.FillFormat.FillType = FillType.NoFill;
            cell.CellFormat.BorderRight.FillFormat.FillType = FillType.NoFill;
        }

    // Escribe el archivo PPTX en disco
    pres.Save("table_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **Numeración en celdas fusionadas**
Si fusionamos 2 pares de celdas (1, 1) x (2, 1) y (1, 2) x (2, 2), la tabla resultante tendrá numeración. Este código C# demuestra el proceso:
```c#
// Instancia la clase Presentation que representa un archivo PPTX
using (Presentation presentation = new Presentation())
{
    // Accede a la primera diapositiva
    ISlide sld = presentation.Slides[0];

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

    // Fusiona celdas (1, 1) x (2, 1)
    tbl.MergeCells(tbl[1, 1], tbl[2, 1], false);

    // Fusiona celdas (1, 2) x (2, 2)
    tbl.MergeCells(tbl[1, 2], tbl[2, 2], false);

    presentation.Save("MergeCells_out.pptx", SaveFormat.Pptx);
}
```


Luego fusionamos las celdas adicionales fusionando (1, 1) y (1, 2). El resultado es una tabla que contiene una gran celda fusionada en su centro:
```c#
 // Instancia la clase Presentation que representa un archivo PPTX
using (Presentation presentation = new Presentation())
{
    // Accede a la primera diapositiva
    ISlide slide = presentation.Slides[0];

    // Define columnas con anchos y filas con alturas
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // Añade una forma de tabla a la diapositiva
    ITable table = slide.Shapes.AddTable(100, 50, dblCols, dblRows);

    // Establece el formato de borde para cada celda
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

    // Fusiona celdas (1, 1) x (2, 1)
    table.MergeCells(table[1, 1], table[2, 1], false);

    // Fusiona celdas (1, 2) x (2, 2)
    table.MergeCells(table[1, 2], table[2, 2], false);

    // Fusiona celdas (1, 2) x (2, 2)
    table.MergeCells(table[1, 1], table[1, 2], true);

    //Escribe el archivo PPTX en disco
    presentation.Save("MergeCells1_out.pptx", SaveFormat.Pptx);
}
```


## **Numeración en una celda dividida**
En los ejemplos anteriores, cuando las celdas de la tabla se fusionaban, la numeración o el sistema de numeración en otras celdas no cambiaba.

En esta ocasión, tomamos una tabla normal (una tabla sin celdas fusionadas) y luego intentamos dividir la celda (1,1) para obtener una tabla especial. Es posible que desee prestar atención a la numeración de esta tabla, que puede parecer extraña. Sin embargo, así es como Microsoft PowerPoint numera las celdas de tabla y Aspose.Slides hace lo mismo.

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

    // Establece el formato de borde para cada celda
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

    // Fusiona celdas (1, 1) x (2, 1)
    table.MergeCells(table[1, 1], table[2, 1], false);

    // Fusiona celdas (1, 2) x (2, 2)
    table.MergeCells(table[1, 2], table[2, 2], false);

    // Divide la celda (1, 1). 
    table[1, 1].SplitByWidth(table[2, 1].Width / 2);

    // Escribe el archivo PPTX en disco
    presentation.Save("CellSplit_out.pptx", SaveFormat.Pptx);
}
```


## **Cambiar el color de fondo de la celda de tabla**

Este código C# le muestra cómo cambiar el color de fondo de una celda de tabla:
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


## **Agregar una imagen dentro de una celda de tabla**

1. Crear una instancia de la clase `Presentation`.
2. Obtener la referencia de una diapositiva mediante su índice.
3. Definir una matriz de columnas con ancho.
4. Definir una matriz de filas con altura.
5. Agregar una tabla a la diapositiva mediante el método `AddTable`.
6. Crear un objeto `Bitmap` para contener el archivo de imagen.
7. Agregar la imagen bitmap al objeto `IPPImage`.
8. Establecer el `FillFormat` de la celda de tabla a `Picture`.
9. Agregar la imagen a la primera celda de la tabla.
10. Guardar la presentación modificada como un archivo PPTX

Este código C# le muestra cómo colocar una imagen dentro de una celda de tabla al crear una tabla:
```c#
 // Instancia la clase Presentation que representa un archivo PPTX
using (Presentation presentation = new Presentation())
{
    // Accede a la primera diapositiva
    ISlide slide = presentation.Slides[0];

    // Define columnas con anchos y filas con alturas
    double[] dblCols = { 150, 150, 150, 150 };
    double[] dblRows = { 100, 100, 100, 100, 90 };

    // Añade una forma de tabla a la diapositiva
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


## **FAQ**

**¿Puedo establecer diferentes grosores y estilos de línea para los distintos lados de una sola celda?**

Sí. Los bordes [top](https://reference.aspose.com/slides/net/aspose.slides/cellformat/bordertop/)/[bottom](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderbottom/)/[left](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderleft/)/[right](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderright/) tienen propiedades separadas, por lo que el grosor y el estilo de cada lado pueden diferir. Esto se deduce lógicamente del control de bordes por lado para una celda demostrado en el artículo.

**¿Qué ocurre con la imagen si cambio el tamaño de la columna/fila después de establecer una imagen como fondo de la celda?**

El comportamiento depende del [fill mode](https://reference.aspose.com/slides/net/aspose.slides/picturefillmode/) (stretch/tile). Con estiramiento, la imagen se ajusta a la nueva celda; con mosaico, los mosaicos se recalculan. El artículo menciona los modos de visualización de la imagen en una celda.

**¿Puedo asignar un hipervínculo a todo el contenido de una celda?**

Los [Hyperlinks](/slides/es/net/manage-hyperlinks/) se establecen a nivel de texto (porción) dentro del marco de texto de la celda o a nivel de toda la tabla/forma. En la práctica, asigna el enlace a una porción o a todo el texto de la celda.

**¿Puedo establecer diferentes fuentes dentro de una sola celda?**

Sí. El marco de texto de una celda admite [portions](https://reference.aspose.com/slides/net/aspose.slides/portion/) (runs) con formato independiente: familia de fuente, estilo, tamaño y color.