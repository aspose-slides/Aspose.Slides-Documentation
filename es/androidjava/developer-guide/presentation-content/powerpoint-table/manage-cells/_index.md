---
title: Gestionar celdas de tabla en presentaciones en Android
linktitle: Gestionar celdas
type: docs
weight: 30
url: /es/androidjava/manage-cells/
keywords:
- celda de tabla
- combinar celdas
- eliminar borde
- dividir celda
- imagen en celda
- color de fondo
- PowerPoint
- presentación
- Android
- Java
- Aspose.Slides
description: "Gestiona celdas de tabla de PowerPoint en Android: identifica celdas combinadas, elimina bordes, divide celdas y establece colores de fondo e imágenes con Aspose.Slides para Android mediante Java."
---
## **Descripción general**

Aspose.Slides le permite acceder y modificar celdas de tabla en presentaciones de PowerPoint. Este artículo explica cómo identificar celdas de tabla combinadas, eliminar los bordes de las celdas, trabajar con la numeración de celdas después de combinar o dividir celdas, cambiar el color de fondo de una celda y agregar una imagen dentro de una celda de tabla. Los ejemplos muestran cómo crear o abrir una presentación, obtener una tabla de una diapositiva, actualizar el formato de las celdas mediante sus propiedades y guardar la presentación modificada como un archivo PPTX.

Aspose.Slides utiliza índices basados en cero para acceder a las celdas de tabla en el orden `(columna, fila)`.

## **Identificar una celda de tabla combinada**

El ejemplo abre una presentación existente y accede a la primera forma de la primera diapositiva como una tabla. Supone que la diapositiva y la forma existen y que la forma es una tabla. Luego recorre todas las filas y columnas y usa [isMergedCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#isMergedCell--) para identificar celdas en regiones combinadas. Para cada coincidencia, imprime las coordenadas de la celda en orden `fila;columna`, [getRowSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getRowSpan--), [getColSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getColSpan--) y las coordenadas iniciales de la región, [getFirstRowIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstRowIndex--) y [getFirstColumnIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstColumnIndex--).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation_with_table.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = (ITable) slide.getShapes().get_Item(0);

    int rowCount = table.getRows().size();
    for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
    {
        int columnCount = table.getColumns().size();
        for (int columnIndex = 0; columnIndex < columnCount; columnIndex++)
        {
            ICell cell = table.get_Item(columnIndex, rowIndex);
            if (cell.isMergedCell())
            {
                System.out.printf("Cell %d;%d belongs to a merged region with RowSpan=%d and ColSpan=%d starting at %d;%d.%n", rowIndex, columnIndex, cell.getRowSpan(), cell.getColSpan(), cell.getFirstRowIndex(), cell.getFirstColumnIndex());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Eliminar los bordes de la celda de la tabla**

Cree una [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) y añada una tabla a su primera diapositiva con [addTable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---). Los anchos de columna, alturas de fila y la posición de la tabla se especifican en puntos. El ejemplo establece los cuatro bordes de la celda a [FillType.NoFill](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) , haciéndolos invisibles.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 50, 50, 50, 50 };
    double[] rowHeights = { 50, 30, 30, 30, 30 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    for (IRow row : table.getRows())
        for (ICell cell : row)
        {
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.NoFill);
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.NoFill);
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.NoFill);
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.NoFill);
        }

    presentation.save("table.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Agregar bordes diagonales a la celda**

Use [getBorderDiagonalDown](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icellformat/#getBorderDiagonalDown--) para dibujar una línea desde la esquina superior izquierda hasta la esquina inferior derecha, y [getBorderDiagonalUp](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icellformat/#getBorderDiagonalUp--) para dibujar una línea desde la esquina inferior izquierda hasta la esquina superior derecha. Una diagonal puede marcar un encabezado de esquina; ambas diagonales pueden formar una X para marcar una celda como no aplicable.

Cada diagonal es un [ILineFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/). En su [getFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#getFillFormat--) , use [setFillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#setFillType-byte-) para seleccionar [FillType.Solid](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) y elegir un color mediante [getSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#getSolidFillColor--). Establezca el ancho de la línea en puntos con [setWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setWidth-double-).

El ejemplo crea tres celdas en una fila: una diagonal descendente roja, una diagonal ascendente azul y ambas diagonales. Deja sin cambios los bordes superior, inferior, izquierdo y derecho de la celda.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 210, 210, 210 };
    double[] rowHeights = { 160 };
    ITable table = slide.getShapes().addTable(45, 130, columnWidths, rowHeights);

    ILineFormat downwardBorder = table.get_Item(0, 0).getCellFormat().getBorderDiagonalDown();
    downwardBorder.getFillFormat().setFillType(FillType.Solid);
    downwardBorder.getFillFormat().getSolidFillColor().setColor(Color.RED);
    downwardBorder.setWidth(3);

    ILineFormat upwardBorder = table.get_Item(1, 0).getCellFormat().getBorderDiagonalUp();
    upwardBorder.getFillFormat().setFillType(FillType.Solid);
    upwardBorder.getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    upwardBorder.setWidth(5);

    ILineFormat crossDownwardBorder = table.get_Item(2, 0).getCellFormat().getBorderDiagonalDown();
    crossDownwardBorder.getFillFormat().setFillType(FillType.Solid);
    crossDownwardBorder.getFillFormat().getSolidFillColor().setColor(Color.RED);
    crossDownwardBorder.setWidth(3);

    ILineFormat crossUpwardBorder = table.get_Item(2, 0).getCellFormat().getBorderDiagonalUp();
    crossUpwardBorder.getFillFormat().setFillType(FillType.Solid);
    crossUpwardBorder.getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    crossUpwardBorder.setWidth(5);

    presentation.save("diagonal_cell_borders.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Una diagonal es una propiedad de formato, no una división de celda. Cada celda conserva un único marco de texto, al que se accede mediante [getTextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getTextFrame--) ; las regiones a cada lado de una diagonal no pueden editarse de forma independiente.

La tabla guardada, renderizada en Microsoft PowerPoint:

![Tres celdas de tabla que muestran una diagonal roja de la esquina superior izquierda a la inferior derecha, una diagonal azul de la esquina inferior izquierda a la superior derecha, y ambas diagonales formando una X.](diagonal-cell-borders.png)

*De izquierda a derecha: diagonal descendente (roja, 3 pt), diagonal ascendente (azul, 5 pt) y ambas diagonales.*

## **Combinar celdas de tabla**

Use [mergeCells](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/#mergeCells-com.aspose.slides.ICell-com.aspose.slides.ICell-boolean-) para combinar un rango rectangular de celdas de tabla en una sola celda. Especifique las celdas en las esquinas superior izquierda e inferior derecha del rango. El argumento final controla si la combinación puede incluir celdas fuera del rango especificado; `false` mantiene la combinación dentro de ese rango.

El ejemplo crea una tabla de 4 × 4 con columnas y filas de 70 puntos, y luego combina las cuatro celdas centrales desde `(1, 1)` hasta `(2, 2)`. La celda resultante abarca dos columnas y dos filas, mientras que la cuadrícula subyacente de la tabla mantiene cuatro columnas y cuatro filas. Para acceder al contenido o formato de la celda combinada, use su posición superior izquierda: `table.get_Item(1, 1)` en este ejemplo. Las demás posiciones del rango combinado siguen formando parte de la cuadrícula de la tabla, por lo que los índices de las celdas fuera del rango no cambian.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 70, 70, 70, 70 };
    double[] rowHeights = { 70, 70, 70, 70 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.mergeCells(table.get_Item(1, 1), table.get_Item(2, 2), false);

    presentation.save("merged_cells.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Dividir celdas de tabla**

La combinación de celdas en el ejemplo anterior preserva la cuadrícula de la tabla. Dividir una celda puede introducir una nueva columna en la cuadrícula y cambiar los índices de columna de las celdas a su derecha. Aspose.Slides sigue el modelo de cuadrícula de tabla de PowerPoint.

Este ejemplo crea una tabla de 4 × 4 con columnas y filas de 70 puntos y llama a [splitByWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#splitByWidth-double-) en la celda `(1, 1)`. La mitad del ancho de 70 puntos de la celda se pasa para crear dos celdas de igual ancho.

Después de esta división, las dos mitades se acceden como `table.get_Item(1, 1)` y `table.get_Item(2, 1)`. La cuadrícula de la tabla ahora tiene cinco columnas: las celdas originalmente en las columnas 2 y 3 se trasladan a las columnas 3 y 4, respectivamente. Los índices de fila permanecen sin cambios. Use estos índices de columna actualizados al acceder a las celdas después de la división.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 70, 70, 70, 70 };
    double[] rowHeights = { 70, 70, 70, 70 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.get_Item(1, 1).splitByWidth(table.get_Item(1, 1).getWidth() / 2);

    presentation.save("split_cells.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

<!-- visual-explanation:manage-cells:start -->
[![Una celda de 70 puntos sin combinar se divide en dos celdas de 35 puntos, añadiendo una quinta columna a la cuadrícula y desplazando los índices a su derecha.](visual-manage-cells-04c40789d81c.svg)](visual-manage-cells-04c40789d81c.svg)

*La división del ancho afecta a la celda (1, 1), usando índices basados en cero (columna, fila). Las demás filas conservan una celda que abarca ambas nuevas posiciones de columna.*
<!-- visual-explanation:manage-cells:end -->

### **Dividir celdas combinadas por fila o columna**

Para preparar celdas de plantilla combinadas para la población de datos, use [splitByRowSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#splitByRowSpan-int-) para dividir a lo largo de un límite de fila existente, o [splitByColSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#splitByColSpan-int-) para dividir a lo largo de un límite de columna.

El argumento `index` cuenta filas en la parte superior o columnas en la parte izquierda de la división; es relativo a la región combinada:

- División de fila: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getRowSpan--).
- División de columna: `0 < index <` [getColSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getColSpan--).

El ejemplo asume que una presentación tiene una tabla como primera forma en la primera diapositiva, con `(1, 2)` y `(1, 3)` combinados verticalmente. Partiendo de la posición inferior, usa [getFirstColumnIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstColumnIndex--) y [getFirstRowIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstRowIndex--) para localizar el origen y verifica ambas combinaciones. `splitByRowSpan(1)` separa entonces las filas 2 y 3 para los nombres de productos. Para una combinación horizontal de dos columnas, use `splitByColSpan(1)` en su lugar.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("table_template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = (ITable) slide.getShapes().get_Item(0);

    ICell selectedCell = table.get_Item(1, 3);
    int firstColumnIndex = selectedCell.getFirstColumnIndex();
    int firstRowIndex = selectedCell.getFirstRowIndex();
    ICell mergedCell = table.get_Item(firstColumnIndex, firstRowIndex);

    if (mergedCell.isMergedCell() && mergedCell.getRowSpan() == 2 && mergedCell.getColSpan() == 1)
    {
        mergedCell.splitByRowSpan(1);

        // Recuperar las celdas resultantes de la tabla después de dividir.
        ICell upperCell = table.get_Item(firstColumnIndex, firstRowIndex);
        ICell lowerCell = table.get_Item(firstColumnIndex, firstRowIndex + 1);
        System.out.println("Upper cell merged: " + upperCell.isMergedCell());
        System.out.println("Lower cell merged: " + lowerCell.isMergedCell());

        upperCell.getTextFrame().setText("Product A");
        lowerCell.getTextFrame().setText("Product B");

        presentation.save("split_template.pptx", SaveFormat.Pptx);
    }
    else
    {
        System.out.println("Select a merged region spanning exactly two rows and one column.");
    }
} finally {
    presentation.dispose();
}
```

La cuadrícula de la tabla y los índices de las celdas circundantes permanecen sin cambios. Recupere las celdas resultantes por sus coordenadas; aquí, ambas tienen un rango de 1 y [isMergedCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#isMergedCell--) devuelve `false`. Las regiones más grandes pueden permanecer parcialmente combinadas después de una división.

El texto original y su formato permanecen en la celda superior (o izquierda); la nueva celda está vacía pero hereda el formato de la celda, como relleno, bordes y márgenes. Poblar las celdas después de dividir y establecer explícitamente cualquier formato de texto requerido.

La presentación guardada contiene celdas separadas “Product A” y “Product B” con el formato de celda de la plantilla conservado. Consulte la [Cell API Reference](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cell/) para obtener más detalles.

### **Dividir una celda a una altura específica**

[splitByHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#splitByHeight-double-) recibe la altura de la parte superior en puntos. [splitByRowSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#splitByRowSpan-int-) recibe el número de filas de cuadrícula existentes en la parte superior. Para centrar una celda de 40 puntos en la columna derecha, reste 40 a la altura real de la celda y divida el espacio restante por igual arriba y abajo.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 160, 160 };
    double[] rowHeights = { 140 };

    ITable table = slide.getShapes().addTable(50, 50, columnWidths, rowHeights);
    table.get_Item(0, 0).getTextFrame().setText("Left");

    double height = table.get_Item(1, 0).getHeight();
    double margin = (height - 40) / 2;

    table.get_Item(1, 0).splitByHeight(margin);
    table.get_Item(1, 1).splitByHeight(40);
    table.get_Item(1, 1).getTextFrame().setText("Middle");

    presentation.save("split_by_height.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

La primera división añade una fila a la cuadrícula y deja los 90 puntos inferiores en la celda `(1, 1)`. La segunda división divide esa celda en una celda intermedia de 40 puntos y una celda inferior de 50 puntos. La columna derecha ahora tiene tres celdas con alturas de 50, 40 y 50 puntos de arriba a abajo. La celda izquierda abarca las tres filas y conserva su altura original de 140 puntos.

![La celda izquierda abarca toda la altura de la tabla junto a tres celdas con Medio en el centro.](split-by-height.png)

## **Cambiar el color de fondo de la celda de la tabla**

Este ejemplo crea una tabla con columnas de 150 puntos y filas de 50 puntos. Usa [setFillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#setFillType-byte-) para seleccionar un relleno sólido y establece el color devuelto por [getSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#getSolidFillColor--) a rojo para la celda `(2, 3)`, en la tercera columna y cuarta fila.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 150, 150, 150, 150 };
    double[] rowHeights = { 50, 50, 50, 50, 50 };
    ITable table = slide.getShapes().addTable(50, 50, columnWidths, rowHeights);

    ICell cell = table.get_Item(2, 3);
    cell.getCellFormat().getFillFormat().setFillType(FillType.Solid);
    cell.getCellFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);

    presentation.save("cell_background_color.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Agregar una imagen dentro de una celda de tabla**

Coloque la imagen de entrada en el directorio de trabajo antes de ejecutar este ejemplo. Carga la imagen con [Images.fromFile](https://reference.aspose.com/slides/androidjava/com.aspose.slides/images/#fromFile-java.lang.String-) y la agrega a la colección de imágenes de la presentación con [addImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagecollection/#addImage-com.aspose.slides.IImage-). Luego asigna la imagen al relleno de imagen de la celda `(0, 0)`, la primera celda de la tabla.

[PictureFillMode.Stretch](https://reference.aspose.com/slides/androidjava/com.aspose.slides/picturefillmode/) estira la imagen para que ocupe toda la celda, lo que puede cambiar su relación de aspecto. Los anchos de columna y alturas de fila están en puntos. La imagen cargada se dispone en un bloque `finally` después de añadirse a la presentación.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 150, 150, 150, 150 };
    double[] rowHeights = { 100, 100, 100, 100, 90 };
    ITable table = slide.getShapes().addTable(50, 50, columnWidths, rowHeights);

    IPPImage ppImage;
    IImage image = Images.fromFile("aspose_logo.jpg");
    try {
        ppImage = presentation.getImages().addImage(image);
    } finally {
        image.dispose();
    }

    table.get_Item(0, 0).getCellFormat().getFillFormat().setFillType(FillType.Picture);
    table.get_Item(0, 0).getCellFormat().getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
    table.get_Item(0, 0).getCellFormat().getFillFormat().getPictureFillFormat().getPicture().setImage(ppImage);

    presentation.save("table_cell_with_image.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Preguntas frecuentes**

**¿Puedo establecer diferentes grosores y estilos de línea para los distintos lados de una única celda?**

Sí. Los bordes [superior](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cellformat/#getBorderTop--)/[inferior](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cellformat/#getBorderBottom--)/[izquierda](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cellformat/#getBorderLeft--)/[derecha](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cellformat/#getBorderRight--) tienen propiedades separadas, por lo que el grosor y el estilo de cada lado pueden ser diferentes.

**¿Qué ocurre con la imagen si cambio el tamaño de la columna/fila después de establecer una imagen como fondo de la celda?**

El comportamiento depende del [modo de relleno](https://reference.aspose.com/slides/androidjava/com.aspose.slides/picturefillmode/) (estirar/azulejar). Con estiramiento, la imagen se ajusta a la nueva celda; con azulejado, los mosaicos se recalculan.

**¿Puedo asignar un hipervínculo a todo el contenido de una celda?**

[Hyperlinks](/slides/es/androidjava/manage-hyperlinks/) se establecen a nivel de texto (porción) dentro del marco de texto de la celda o a nivel de toda la tabla/forma. En la práctica, asigna el enlace a una porción o a todo el texto de la celda.

**¿Puedo establecer diferentes tipografías dentro de una única celda?**

Sí. El marco de texto de una celda admite [porciones](https://reference.aspose.com/slides/androidjava/com.aspose.slides/portion/) (runs) con formato independiente: familia de fuente, estilo, tamaño y color.