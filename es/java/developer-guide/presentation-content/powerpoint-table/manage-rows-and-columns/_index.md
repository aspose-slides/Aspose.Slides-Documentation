---
title: Gestionar filas y columnas en tablas de PowerPoint usando Java
linktitle: Filas y columnas
type: docs
weight: 20
url: /es/java/manage-rows-and-columns/
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
- Java
- Aspose.Slides
description: "Gestione filas y columnas de tabla en PowerPoint con Aspose.Slides para Java y acelere la edición de presentaciones y la actualización de datos."
---
## **Introducción**

Aspose.Slides for Java le permite gestionar la estructura y el formato de tablas en presentaciones de PowerPoint mediante la clase [Tabla](https://reference.aspose.com/slides/java/com.aspose.slides/table/) y la interfaz [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/itable/). Puede designar una fila de encabezado, clonar o eliminar filas y columnas, y aplicar formato de texto a una fila o columna completa.

Este artículo explica estas operaciones con ejemplos en Java. También muestra cómo obtener el estilo predefinido de una tabla para reutilizarlo. Los índices de filas y columnas de tabla comienzan en cero.

## **Controlar la altura de la fila**

Use [IRow.setMinimalHeight](https://reference.aspose.com/slides/java/com.aspose.slides/irow/#setMinimalHeight-double-) para establecer la altura mínima de una fila en puntos. Es un límite inferior, no una altura fija. [IRow.getHeight](https://reference.aspose.com/slides/java/com.aspose.slides/irow/#getHeight--) devuelve la altura real. Acceda a la fila a través de [ITable.getRows](https://reference.aspose.com/slides/java/com.aspose.slides/itable/#getRows--).

El ejemplo carga [row-height-input.pptx](row-height-input.pptx), que contiene una tabla como la primera forma en la primera diapositiva. Su primera fila comienza en 70 puntos. Las celdas usan texto Arial de 18 puntos, con ajuste de línea y márgenes superior e inferior de 6 puntos; el texto más largo en la segunda columna se ajusta en varias líneas. El ejemplo aumenta el mínimo a 100 puntos, luego lo disminuye a 20 puntos, muestra la altura real después de cada cambio y guarda ambos resultados.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("row-height-input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ITable table = (ITable)slide.getShapes().get_Item(0);
    IRow row = table.getRows().get_Item(0);

    row.setMinimalHeight(100);
    System.out.printf("Increased: minimum = %.1f, actual = %.1f pt%n", row.getMinimalHeight(), row.getHeight());
    presentation.save("row-height-increased.pptx", SaveFormat.Pptx);

    row.setMinimalHeight(20);
    System.out.printf("Decreased: minimum = %.1f, actual = %.1f pt%n", row.getMinimalHeight(), row.getHeight());
    presentation.save("row-height-decreased.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Con la presentación suministrada, aumentar el mínimo añade espacio a la fila. Disminuirlo elimina ese espacio adicional, pero la altura real sigue siendo mayor que 20 puntos porque el texto y los márgenes de la celda requieren más espacio. Reducir solo el mínimo no puede forzar que la fila quede por debajo del espacio requerido por su contenido.

Varios factores influyen en la altura real:

- **Texto y tamaño de fuente:** texto más largo, saltos de línea explícitos o una fuente mayor pueden requerir más espacio vertical.
- **Ajuste y ancho de columna:** con el ajuste activado, reducir el ancho de la columna con [IColumn.setWidth](https://reference.aspose.com/slides/java/com.aspose.slides/icolumn/#setWidth-double-) puede generar más líneas. Una columna más ancha puede reducir el espacio necesario verticalmente.
- **Márgenes de celda:** [ICell.setMarginTop](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#setMarginTop-double-) y [ICell.setMarginBottom](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#setMarginBottom-double-) añaden espacio vertical. [ICell.setMarginLeft](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#setMarginLeft-double-) y [ICell.setMarginRight](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#setMarginRight-double-) reducen el ancho disponible para el texto y pueden provocar ajustes adicionales.

Para esta tabla sin celdas combinadas, la celda que necesita más espacio vertical determina el límite inferior impuesto por el contenido para toda la fila. Para acortar la fila, también puede ser necesario reducir el texto, disminuir el tamaño de fuente o los márgenes, o ensanchar una columna.

Las imágenes siguientes muestran la misma tabla a la misma escala. En los resultados ilustrados, las alturas reales fueron 70, 100 y 55,2 puntos: la fila final permaneció más alta que su mínimo de 20 puntos. Las mediciones exactas del texto pueden variar según las fuentes disponibles en su entorno. Descargue los resultados guardados: [mínimo aumentado](row-height-increased.pptx) y [mínimo disminuido](row-height-decreased.pptx).

| Original: mínimo 70 pt, real 70 pt | Aumentado: mínimo 100 pt, real 100 pt | Disminuido: mínimo 20 pt, real 55,2 pt |
| --- | --- | --- |
| ![Tabla original con una primera fila de 70 puntos.](row-height-before.png) | ![Tabla después de aumentar el mínimo de la primera fila a 100 puntos.](row-height-increased.png) | ![Tabla después de disminuir el mínimo de la primera fila a 20 puntos; el texto ajustado mantiene la fila más alta que el mínimo.](row-height-decreased.png) |

## **Establecer la primera fila como encabezado**

Use el método [setFirstRow](https://reference.aspose.com/slides/java/com.aspose.slides/itable/#setFirstRow-boolean-) para marcar la primera fila como encabezado. Su apariencia depende del estilo de tabla aplicado.

1. Cargue la presentación con la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
2. Acceda a la primera diapositiva.
3. Acceda a la tabla almacenada como la primera forma en la diapositiva.
4. Active el formato de encabezado para su primera fila.
5. Guarde la presentación modificada.

El ejemplo necesita `table.pptx` con una tabla como la primera forma en la primera diapositiva. Activa el formato de encabezado para la primera fila y guarda `First_row_header.pptx`.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("table.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ITable table = (ITable)slide.getShapes().get_Item(0);
    table.setFirstRow(true);

    presentation.save("First_row_header.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Clonar una fila o columna de tabla**

Clone filas o columnas para reutilizar su contenido y formato. Puede añadir una copia al final de la tabla o insertarla en una posición específica.

1. Cargue la presentación con la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
2. Acceda a la primera diapositiva.
3. Defina los anchos de columna y las alturas de fila.
4. Añada una tabla con el método [addTable](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---).
5. Clone las filas necesarias.
6. Clone las columnas necesarias.
7. Guarde la presentación modificada.

El ejemplo necesita `Test.pptx` con al menos una diapositiva. Crea una tabla con tres columnas y cinco filas, con dimensiones especificadas en puntos. Añade copias de la primera fila y columna, luego inserta copias de la segunda fila y columna en el índice 3 (la cuarta posición). La tabla resultante tiene siete filas y cinco columnas. El argumento `false` desactiva la clonación en filas o columnas combinadas adyacentes; esta tabla no tiene celdas combinadas.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("Test.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = new double[] { 50, 50, 50 };
    double[] rowHeights = new double[] { 50, 30, 30, 30, 30 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.get_Item(0, 0).getTextFrame().setText("Row 1 Cell 1");
    table.get_Item(1, 0).getTextFrame().setText("Row 1 Cell 2");
    table.getRows().addClone(table.getRows().get_Item(0), false);

    table.get_Item(0, 1).getTextFrame().setText("Row 2 Cell 1");
    table.get_Item(1, 1).getTextFrame().setText("Row 2 Cell 2");
    table.getRows().insertClone(3, table.getRows().get_Item(1), false);

    table.getColumns().addClone(table.getColumns().get_Item(0), false);
    table.getColumns().insertClone(3, table.getColumns().get_Item(1), false);

    presentation.save("table_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Eliminar una fila o columna de una tabla**

Elimine filas o columnas que ya no sean necesarias en una tabla. Eliminar un elemento desplaza los índices de las filas o columnas que le siguen.

1. Cree una presentación con la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
2. Acceda a la primera diapositiva.
3. Defina los anchos de columna y las alturas de fila.
4. Añada una tabla con el método [addTable](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---).
5. Elimine la segunda fila y la segunda columna.
6. Guarde la presentación modificada.

Este ejemplo crea una tabla de tres por tres y elimina la fila y la columna en el índice 1, dejando una tabla de dos por dos en `TestTable_out.pptx`. Las dimensiones están en puntos. El argumento `false` desactiva la eliminación de filas o columnas combinadas adyacentes; esta tabla no tiene celdas combinadas.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = new double[] { 100, 50, 30 };
    double[] rowHeights = new double[] { 30, 50, 30 };
    ITable table = slide.getShapes().addTable(100, 100, columnWidths, rowHeights);

    table.getRows().removeAt(1, false);
    table.getColumns().removeAt(1, false);

    presentation.save("TestTable_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Establecer formato de texto a nivel de fila de tabla**

Aplique formato de texto a una fila completa para que sus celdas sean consistentes. Puede definir propiedades de fuente, formato de párrafo y dirección del texto sin formatear cada celda individualmente.

1. Cargue la presentación con la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
2. Acceda a la tabla en la primera diapositiva.
3. Use [setFontHeight](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/#setFontHeight-float-) para la primera fila.
4. Use [setAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) y [setMarginRight](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setMarginRight-float-) para la primera fila.
5. Use [setTextVerticalType](https://reference.aspose.com/slides/java/com.aspose.slides/textframeformat/#setTextVerticalType-byte-) para la segunda fila.
6. Guarde la presentación modificada.

El ejemplo necesita `table.pptx` con una tabla como la primera forma en la primera diapositiva y al menos dos filas. Aplica texto de 25 puntos, alineación a la derecha y un margen de párrafo derecho de 20 puntos a la primera fila, luego establece texto vertical en la segunda fila.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("table.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ITable table = (ITable)slide.getShapes().get_Item(0);

    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
    table.getRows().get_Item(0).setTextFormat(portionFormat);

    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    table.getRows().get_Item(0).setTextFormat(paragraphFormat);

    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
    table.getRows().get_Item(1).setTextFormat(textFrameFormat);

    presentation.save("row_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Establecer formato de texto a nivel de columna de tabla**

Aplique formato de texto a una columna completa para que sus celdas sean consistentes. Puede definir propiedades de fuente, formato de párrafo y dirección del texto sin formatear cada celda individualmente.

1. Cargue la presentación con la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
2. Acceda a la tabla en la primera diapositiva.
3. Use [setFontHeight](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/#setFontHeight-float-) para la primera columna.
4. Use [setAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) y [setMarginRight](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setMarginRight-float-) para la primera columna.
5. Use [setTextVerticalType](https://reference.aspose.com/slides/java/com.aspose.slides/textframeformat/#setTextVerticalType-byte-) para la segunda columna.
6. Guarde la presentación modificada.

El ejemplo necesita `table.pptx` con una tabla como la primera forma en la primera diapositiva y al menos dos columnas. Aplica texto de 25 puntos, alineación a la derecha y un margen de párrafo derecho de 20 puntos a la primera columna, luego establece texto vertical en la segunda columna.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("table.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ITable table = (ITable)slide.getShapes().get_Item(0);

    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
    table.getColumns().get_Item(0).setTextFormat(portionFormat);

    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    table.getColumns().get_Item(0).setTextFormat(paragraphFormat);

    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
    table.getColumns().get_Item(1).setTextFormat(textFrameFormat);

    presentation.save("column_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Obtener propiedades del estilo de tabla**

Use el método [getStylePreset](https://reference.aspose.com/slides/java/com.aspose.slides/itable/#getStylePreset--) para obtener el estilo predefinido aplicado a una tabla y reutilizarlo en otra tabla. Esto identifica el preset en lugar de las anulaciones de formato de celdas individuales.

El ejemplo crea una tabla, aplica [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/java/com.aspose.slides/tablestylepreset/#DarkStyle1) y lee de nuevo el preset. Imprime el valor entero correspondiente a `DarkStyle1` y guarda la tabla en `table.pptx`.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = new double[] { 100, 150 };
    double[] rowHeights = new double[] { 5, 5, 5 };
    ITable table = slide.getShapes().addTable(10, 10, columnWidths, rowHeights);
    table.setStylePreset(TableStylePreset.DarkStyle1);

    int stylePreset = table.getStylePreset();
    System.out.println(stylePreset);

    presentation.save("table.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Preguntas frecuentes**

**¿Puedo aplicar temas/estilos de PowerPoint a una tabla ya creada?**

Sí. La tabla hereda el tema de la diapositiva/disposición/maestra, y aún puede sobrescribir rellenos, bordes y colores de texto sobre ese tema.

**¿Puedo ordenar filas de tabla como en Excel?**

No, las tablas de Aspose.Slides no disponen de ordenación ni filtros incorporados. Ordene sus datos en memoria primero y, a continuación, vuelva a rellenar las filas de la tabla en ese orden.

**¿Puedo tener columnas con bandas (rayas) y mantener colores personalizados en celdas específicas?**

Sí. Active las columnas con bandas y, después, sobrescriba celdas específicas con formato local; el formato a nivel de celda tiene prioridad sobre el estilo de tabla.