---
title: Administrar celdas de tabla en presentaciones usando Java
linktitle: Administrar celdas
type: docs
weight: 30
url: /es/java/manage-cells/
keywords:
- celda de tabla
- combinar celdas
- eliminar borde
- dividir celda
- imagen en celda
- color de fondo
- PowerPoint
- presentación
- Java
- Aspose.Slides
description: "Administre fácilmente celdas de tabla en PowerPoint con Aspose.Slides para Java. Domine el acceso, la modificación y el estilo de las celdas rápidamente para una automatización fluida de diapositivas."
---

## **Identificar una celda de tabla combinada**
1. Cree una instancia de la [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) clase.
2. Obtenga la tabla de la primera diapositiva. 
3. Recorra las filas y columnas de la tabla para encontrar celdas combinadas.
4. Imprima un mensaje cuando se encuentren celdas combinadas.

Este código Java le muestra cómo identificar celdas de tabla combinadas en una presentación:
```java
Presentation pres = new Presentation("SomePresentationWithTable.pptx");
try {
    ITable table = (ITable)pres.getSlides().get_Item(0).getShapes().get_Item(0); // asumiendo que Slide#0.Shape#0 es una tabla
    for (int i = 0; i < table.getRows().size(); i++)
    {
        for (int j = 0; j < table.getColumns().size(); j++)
        {
            ICell currentCell = table.getRows().get_Item(i).get_Item(j);
            if (currentCell.isMergedCell())
            {
                System.out.println(String.format("Cell %d;%d is a part of merged cell with RowSpan=%d and ColSpan=%d starting from Cell %d;%d.",
                        i, j, currentCell.getRowSpan(), currentCell.getColSpan(), currentCell.getFirstRowIndex(), currentCell.getFirstColumnIndex()));
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **Eliminar bordes de celdas de tabla**
1. Cree una instancia de la [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) clase.
2. Obtenga una referencia a una diapositiva mediante su índice. 
3. Defina una matriz de columnas con ancho.
4. Defina una matriz de filas con altura.
5. Agregue una tabla a la diapositiva mediante el método [addTable](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-).
6. Recorra cada celda para eliminar los bordes superior, inferior, derecho e izquierdo.
7. Guarde la presentación modificada como un archivo PPTX.

Este código Java le muestra cómo eliminar los bordes de las celdas de tabla:
```java
// Instancia la clase Presentation que representa un archivo PPTX
Presentation pres = new Presentation();
try {
    // Accede a la primera diapositiva
    Slide sld = (Slide)pres.getSlides().get_Item(0);

    // Define columnas con anchos y filas con alturas
    double[] dblCols = { 50, 50, 50, 50 };
    double[] dblRows = { 50, 30, 30, 30, 30 };

    // Añade la forma de tabla a la diapositiva
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // Establece el formato de borde para cada celda
    for (IRow row : tbl.getRows())
    {
        for (ICell cell : row)
        {
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.NoFill);
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.NoFill);
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.NoFill);
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.NoFill);
        }
    }

    // Escribe el PPTX en disco
    pres.save("table_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Numeración en celdas combinadas**
Si combinamos 2 pares de celdas (1, 1) x (2, 1) y (1, 2) x (2, 2), la tabla resultante estará numerada. Este código Java demuestra el proceso:
```java
// Instancia la clase Presentation que representa un archivo PPTX
Presentation pres = new Presentation();
try {
    // Accede a la primera diapositiva
    ISlide sld = pres.getSlides().get_Item(0);

    // Define columnas con anchos y filas con alturas
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // Añade una forma de tabla a la diapositiva
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // Establece el formato de borde para cada celda
    for (IRow row : tbl.getRows())
    {
        for (ICell cell : row)
        {
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderTop().setWidth(5);

            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderBottom().setWidth(5);

            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderLeft().setWidth(5);

            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderRight().setWidth(5);
        }
    }

    // Fusiona celdas (1, 1) x (2, 1)
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);

    // Fusiona celdas (1, 2) x (2, 2)
    tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);

    pres.save("MergeCells_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


Luego combinamos más celdas al combinar (1, 1) y (1, 2). El resultado es una tabla que contiene una gran celda combinada en su centro:
```java
// Instancia la clase Presentation que representa un archivo PPTX
Presentation pres = new Presentation();
try {
    // Accede a la primera diapositiva
    ISlide sld = pres.getSlides().get_Item(0);

    // Define columnas con anchos y filas con alturas
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // Añade una forma de tabla a la diapositiva
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // Establece el formato de borde para cada celda
    for (IRow row : tbl.getRows())
    {
        for (ICell cell : row)
        {
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderTop().setWidth(5);

            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderBottom().setWidth(5);

            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderLeft().setWidth(5);

            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderRight().setWidth(5);
        }
    }

    // Fusiona celdas (1, 1) x (2, 1)
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);

    // Fusiona celdas (1, 2) x (2, 2)
    tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);

    // Fusiona celdas (1, 1) x (1, 2)
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(1, 2), true);
    
	// Escribe el archivo PPTX en disco
    pres.save("MergeCells_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Numeración en una celda dividida**
En los ejemplos anteriores, cuando las celdas de la tabla se combinaron, la numeración o el sistema de numerado en otras celdas no cambió.

Esta vez, tomamos una tabla normal (una tabla sin celdas combinadas) y luego intentamos dividir la celda (1,1) para obtener una tabla especial. Preste atención a la numeración de esta tabla, que puede parecer extraña. Sin embargo, esa es la forma en que Microsoft PowerPoint numera las celdas de tabla y Aspose.Slides hace lo mismo.

Este código Java demuestra el proceso descrito:
```java
// Instancia la clase Presentation que representa un archivo PPTX
Presentation pres = new Presentation();
try {
    // Accede a la primera diapositiva
    ISlide sld = pres.getSlides().get_Item(0);

    // Define columnas con anchos y filas con alturas
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // Añade una forma de tabla a la diapositiva
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // Establece el formato de borde para cada celda
    for (IRow row : tbl.getRows())
    {
        for (ICell cell : row)
        {
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderTop().setWidth(5);

            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderBottom().setWidth(5);

            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderLeft().setWidth(5);

            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderRight().setWidth(5);
        }
    }

    // Fusiona celdas (1, 1) x (2, 1)
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);

    // Fusiona celdas (1, 2) x (2, 2)
    tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);

    // Divide la celda (1, 1)
    tbl.get_Item(1, 1).splitByWidth(tbl.get_Item(2, 1).getWidth() / 2);

    //Escribe el archivo PPTX en disco
    pres.save("SplitCells_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Cambiar el color de fondo de la celda de tabla**

Este código Java le muestra cómo cambiar el color de fondo de una celda de tabla:
```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] dblCols = { 150, 150, 150, 150 };
    double[] dblRows = { 50, 50, 50, 50, 50 };

    // crea una nueva tabla
    ITable table = slide.getShapes().addTable(50, 50, dblCols, dblRows);

    // establece el color de fondo de una celda 
    ICell cell = table.get_Item(2, 3);
    cell.getCellFormat().getFillFormat().setFillType(FillType.Solid);
    cell.getCellFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);

    presentation.save("cell_background_color.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```


## **Agregar una imagen dentro de una celda de tabla**

1. Cree una instancia de la [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) clase.
2. Obtenga una referencia a una diapositiva mediante su índice.
3. Defina una matriz de columnas con ancho.
4. Defina una matriz de filas con altura.
5. Agregue una tabla a la diapositiva mediante el método [AddTable](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-).
6. Cree un objeto `Images` para contener el archivo de imagen.
7. Añada la imagen `IImage` al objeto `IPPImage`.
8. Establezca el `FillFormat` de la celda de tabla a `Picture`.
9. Añada la imagen a la primera celda de la tabla.
10. Guarde la presentación modificada como un archivo PPTX.

Este código Java le muestra cómo colocar una imagen dentro de una celda de tabla al crear una tabla:
```java
// Instancia la clase Presentation que representa un archivo PPTX
Presentation pres = new Presentation();
try {
    // Accede a la primera diapositiva
    ISlide islide = pres.getSlides().get_Item(0);

    // Define columnas con anchos y filas con alturas
    double[] dblCols = {150, 150, 150, 150};
    double[] dblRows = {100, 100, 100, 100, 90};

    // Añade una forma de tabla a la diapositiva
    ITable tbl = islide.getShapes().addTable(50, 50, dblCols, dblRows);

    // Crea un objeto IPPImage usando el archivo de imagen
    IPPImage picture;
    IImage image = Images.fromFile("image.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Añade la imagen a la primera celda de la tabla
    ICellFormat cellFormat = tbl.get_Item(0, 0).getCellFormat();
    cellFormat.getFillFormat().setFillType(FillType.Picture);
    cellFormat.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
    cellFormat.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // Guarda el archivo PPTX en el disco
    pres.save("Image_In_TableCell_out.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**¿Puedo establecer grosores y estilos de línea diferentes para los distintos lados de una sola celda?**

Sí. Los bordes [superior](https://reference.aspose.com/slides/java/com.aspose.slides/cellformat/#getBorderTop--)/[inferior](https://reference.aspose.com/slides/java/com.aspose.slides/cellformat/#getBorderBottom--)/[izquierdo](https://reference.aspose.com/slides/java/com.aspose.slides/cellformat/#getBorderLeft--)/[derecho](https://reference.aspose.com/slides/java/com.aspose.slides/cellformat/#getBorderRight--) tienen propiedades independientes, por lo que el grosor y el estilo de cada lado pueden diferir. Esto sigue lógicamente el control de bordes por lado demostrado en el artículo.

**¿Qué ocurre con la imagen si cambio el tamaño de la columna/fila después de establecer una foto como fondo de la celda?**

El comportamiento depende del [modo de relleno](https://reference.aspose.com/slides/java/com.aspose.slides/picturefillmode/) (estiramiento/azulejo). Con estiramiento, la imagen se ajusta a la nueva celda; con azulejo, los azulejos se recalculan. El artículo menciona los modos de visualización de la imagen en una celda.

**¿Puedo asignar un hipervínculo a todo el contenido de una celda?**

Los [Hipervínculos](/slides/es/java/manage-hyperlinks/) se establecen a nivel del texto (porción) dentro del marco de texto de la celda o a nivel de toda la tabla/forma. En la práctica, asigna el enlace a una porción o a todo el texto de la celda.

**¿Puedo establecer diferentes fuentes dentro de una sola celda?**

Sí. El marco de texto de una celda admite [porciones](https://reference.aspose.com/slides/java/com.aspose.slides/portion/) (runs) con formato independiente: familia de fuente, estilo, tamaño y color.