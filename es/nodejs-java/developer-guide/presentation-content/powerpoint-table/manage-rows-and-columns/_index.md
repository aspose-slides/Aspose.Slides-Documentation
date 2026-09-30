---
title: Gestionar filas y columnas en tablas de PowerPoint usando JavaScript
linktitle: Filas y columnas
type: docs
weight: 20
url: /es/nodejs-java/manage-rows-and-columns/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Gestione filas y columnas de tablas en PowerPoint con JavaScript y Aspose.Slides para Node.js mediante Java y acelere la edición de presentaciones y la actualización de datos."
---
## **Introducción**

Aspose.Slides for Node.js via Java le permite administrar la estructura y el formato de tablas en presentaciones de PowerPoint mediante la clase [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/). Puede designar una fila de encabezado, clonar o eliminar filas y columnas, y aplicar formato de texto a una fila o columna completa.

Este artículo explica estas operaciones con ejemplos en JavaScript. También muestra cómo recuperar el preset de estilo de una tabla para que pueda reutilizarlo. Los índices de filas y columnas de la tabla son base cero.

## **Controlar la altura de la fila**

Use [Row.setMinimalHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/row/#setMinimalHeight-double-) para establecer la altura mínima de una fila en puntos. Es un límite inferior, no una altura fija. [Row.getHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/row/#getHeight--) devuelve la altura real. Acceda a la fila a través de [Table.getRows](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#getRows--).

El ejemplo carga [row-height-input.pptx](row-height-input.pptx), que tiene una tabla como la primera forma de la primera diapositiva. Su primera fila comienza en 70 puntos. Las celdas usan texto Arial de 18 puntos, con ajuste y márgenes superior e inferior de 6 puntos; el texto más largo en la segunda columna se ajusta en varias líneas. El ejemplo aumenta el mínimo a 100 puntos, luego lo reduce a 20 puntos, muestra la altura real después de cada cambio y guarda ambos resultados.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("row-height-input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const table = slide.getShapes().get_Item(0);
    const row = table.getRows().get_Item(0);

    row.setMinimalHeight(100);
    console.log("Increased: minimum = " + row.getMinimalHeight().toFixed(1) + ", actual = " + row.getHeight().toFixed(1) + " pt");
    presentation.save("row-height-increased.pptx", slides.SaveFormat.Pptx);

    row.setMinimalHeight(20);
    console.log("Decreased: minimum = " + row.getMinimalHeight().toFixed(1) + ", actual = " + row.getHeight().toFixed(1) + " pt");
    presentation.save("row-height-decreased.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Con la presentación suministrada, aumentar el mínimo añade espacio a la fila. Reducirlo elimina ese espacio adicional, pero la altura real sigue siendo mayor que 20 puntos porque el texto y los márgenes de la celda necesitan más espacio. Disminuir solo el mínimo no puede forzar la fila por debajo del espacio requerido por su contenido.

Varios factores afectan la altura real:

- **Texto y tamaño de fuente:** texto más largo, saltos de línea explícitos o una fuente mayor pueden requerir más espacio vertical.
- **Ajuste y ancho de columna:** con ajuste activado, reducir el ancho de la columna con [Column.setWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/column/#setWidth-double-) puede producir más líneas. Una columna más ancha puede reducir el espacio necesario verticalmente.
- **Márgenes de celda:** [Cell.setMarginTop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#setMarginTop-double-) y [Cell.setMarginBottom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#setMarginBottom-double-) añaden espacio vertical. [Cell.setMarginLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#setMarginLeft-double-) y [Cell.setMarginRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#setMarginRight-double-) reducen el ancho disponible para el texto y pueden provocar un ajuste adicional.

Para esta tabla sin celdas combinadas, la celda que necesita más espacio vertical determina el límite inferior impulsado por el contenido para toda la fila. Para acortar la fila, también puede ser necesario abreviar el texto, reducir el tamaño de fuente o los márgenes, o ensanchar una columna.

Las imágenes a continuación muestran la misma tabla a la misma escala. En los resultados ilustrados, las alturas reales fueron 70, 100 y 55,2 puntos: la fila final permaneció más alta que su mínimo de 20 puntos. Las mediciones exactas del texto pueden variar según las fuentes disponibles en su entorno. Descargue los resultados guardados: [increased minimum](row-height-increased.pptx) y [decreased minimum](row-height-decreased.pptx).

| Original: mínimo 70 pt, real 70 pt | Aumentado: mínimo 100 pt, real 100 pt | Reducido: mínimo 20 pt, real 55.2 pt |
| --- | --- | --- |
| ![Tabla original con una primera fila de 70 puntos.](row-height-before.png) | ![Tabla después de aumentar el mínimo de la primera fila a 100 puntos.](row-height-increased.png) | ![Tabla después de disminuir el mínimo de la primera fila a 20 puntos; el texto ajustado mantiene la fila más alta que el mínimo.](row-height-decreased.png) |

## **Establecer la primera fila como encabezado**

Use el método [setFirstRow](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#setFirstRow-boolean-) para marcar la primera fila para formato de encabezado. Su apariencia depende del estilo de tabla aplicado a la tabla.

1. Cargue la presentación con la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. Acceda a la primera diapositiva.
3. Acceda a la tabla almacenada como la primera forma de la diapositiva.
4. Active el formato de encabezado para su primera fila.
5. Guarde la presentación modificada.

El ejemplo requiere `table.pptx` con una tabla como la primera forma de la primera diapositiva. Activa el formato de encabezado para la primera fila y guarda `First_row_header.pptx`.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("table.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const table = slide.getShapes().get_Item(0);
    table.setFirstRow(true);

    presentation.save("First_row_header.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Clonar una fila o columna de tabla**

Clone filas o columnas para reutilizar su contenido y formato. Puede añadir una copia al final de la tabla o insertarla en una posición específica.

1. Cargue la presentación con la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. Acceda a la primera diapositiva.
3. Defina los anchos de columna y las alturas de fila.
4. Añada una tabla con el método [addTable](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addTable-float-float-double---double---).
5. Clone las filas requeridas.
6. Clone las columnas requeridas.
7. Guarde la presentación modificada.

El ejemplo requiere `Test.pptx` con al menos una diapositiva. Crea una tabla con tres columnas y cinco filas, con dimensiones especificadas en puntos. Añade copias de la primera fila y columna, luego inserta copias de la segunda fila y columna en el índice 3 (la cuarta posición). La tabla resultante tiene siete filas y cinco columnas. El argumento `false` deshabilita la clonación en filas o columnas combinadas adyacentes; esta tabla no tiene celdas combinadas.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("Test.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [50, 50, 50]);
    const rowHeights = java.newArray("double", [50, 30, 30, 30, 30]);
    const table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.get_Item(0, 0).getTextFrame().setText("Row 1 Cell 1");
    table.get_Item(1, 0).getTextFrame().setText("Row 1 Cell 2");
    table.getRows().addClone(table.getRows().get_Item(0), false);

    table.get_Item(0, 1).getTextFrame().setText("Row 2 Cell 1");
    table.get_Item(1, 1).getTextFrame().setText("Row 2 Cell 2");
    table.getRows().insertClone(3, table.getRows().get_Item(1), false);

    table.getColumns().addClone(table.getColumns().get_Item(0), false);
    table.getColumns().insertClone(3, table.getColumns().get_Item(1), false);

    presentation.save("table_out.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Eliminar una fila o columna de una tabla**

Elimine filas o columnas que ya no se necesiten en una tabla. Eliminar un elemento desplaza los índices de las filas o columnas que lo siguen.

1. Cree una presentación con la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. Acceda a la primera diapositiva.
3. Defina los anchos de columna y las alturas de fila.
4. Añada una tabla con el método [addTable](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addTable-float-float-double---double---).
5. Elimine la segunda fila y la segunda columna.
6. Guarde la presentación modificada.

Este ejemplo crea una tabla de tres por tres y elimina la fila y columna en el índice 1, dejando una tabla de dos por dos en `TestTable_out.pptx`. Las dimensiones están en puntos. El argumento `false` deshabilita la eliminación de filas o columnas combinadas adyacentes; esta tabla no tiene celdas combinadas.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [100, 50, 30]);
    const rowHeights = java.newArray("double", [30, 50, 30]);
    const table = slide.getShapes().addTable(100, 100, columnWidths, rowHeights);

    table.getRows().removeAt(1, false);
    table.getColumns().removeAt(1, false);

    presentation.save("TestTable_out.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Establecer formato de texto a nivel de fila de tabla**

Aplique formato de texto a una fila completa para mantener la coherencia de sus celdas. Puede establecer propiedades de fuente, formato de párrafo y dirección del texto sin formatear cada celda individualmente.

1. Cargue la presentación con la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. Acceda a la tabla en la primera diapositiva.
3. Use [setFontHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight-float-) para la primera fila.
4. Use [setAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) y [setMarginRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setMarginRight-float-) para la primera fila.
5. Use [setTextVerticalType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-) para la segunda fila.
6. Guarde la presentación modificada.

El ejemplo requiere `table.pptx` con una tabla como la primera forma de la primera diapositiva y al menos dos filas. Aplica texto de 25 puntos, alineación a la derecha y un margen derecho de párrafo de 20 puntos a la primera fila, luego establece texto vertical en la segunda fila.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("table.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const table = slide.getShapes().get_Item(0);

    const portionFormat = new slides.PortionFormat();
    portionFormat.setFontHeight(25);
    table.getRows().get_Item(0).setTextFormat(portionFormat);

    const paragraphFormat = new slides.ParagraphFormat();
    paragraphFormat.setAlignment(slides.TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    table.getRows().get_Item(0).setTextFormat(paragraphFormat);

    const textFrameFormat = new slides.TextFrameFormat();
    textFrameFormat.setTextVerticalType(java.newByte(slides.TextVerticalType.Vertical));
    table.getRows().get_Item(1).setTextFormat(textFrameFormat);

    presentation.save("row_formatting.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Establecer formato de texto a nivel de columna de tabla**

Aplique formato de texto a una columna completa para mantener la coherencia de sus celdas. Puede establecer propiedades de fuente, formato de párrafo y dirección del texto sin formatear cada celda individualmente.

1. Cargue la presentación con la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. Acceda a la tabla en la primera diapositiva.
3. Use [setFontHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight-float-) para la primera columna.
4. Use [setAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) y [setMarginRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setMarginRight-float-) para la primera columna.
5. Use [setTextVerticalType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-) para la segunda columna.
6. Guarde la presentación modificada.

El ejemplo requiere `table.pptx` con una tabla como la primera forma de la primera diapositiva y al menos dos columnas. Aplica texto de 25 puntos, alineación a la derecha y un margen derecho de párrafo de 20 puntos a la primera columna, luego establece texto vertical en la segunda columna.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("table.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const table = slide.getShapes().get_Item(0);

    const portionFormat = new slides.PortionFormat();
    portionFormat.setFontHeight(25);
    table.getColumns().get_Item(0).setTextFormat(portionFormat);

    const paragraphFormat = new slides.ParagraphFormat();
    paragraphFormat.setAlignment(slides.TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    table.getColumns().get_Item(0).setTextFormat(paragraphFormat);

    const textFrameFormat = new slides.TextFrameFormat();
    textFrameFormat.setTextVerticalType(java.newByte(slides.TextVerticalType.Vertical));
    table.getColumns().get_Item(1).setTextFormat(textFrameFormat);

    presentation.save("column_formatting.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Obtener propiedades de estilo de tabla**

Use el método [getStylePreset](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#getStylePreset--) para recuperar el preset aplicado a una tabla y reutilizarlo en otra tabla. Esto identifica el preset en lugar de los sobrescritos de formato individual de celda.

El ejemplo crea una tabla, aplica [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tablestylepreset/#DarkStyle1) y lee el preset. Imprime el valor entero correspondiente a `DarkStyle1` y guarda la tabla en `table.pptx`.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [100, 150]);
    const rowHeights = java.newArray("double", [5, 5, 5]);
    const table = slide.getShapes().addTable(10, 10, columnWidths, rowHeights);
    table.setStylePreset(slides.TableStylePreset.DarkStyle1);

    const stylePreset = table.getStylePreset();
    console.log(stylePreset);

    presentation.save("table.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Preguntas frecuentes**

**¿Puedo aplicar temas/estilos de PowerPoint a una tabla que ya está creada?**

Sí. La tabla hereda el tema de la diapositiva/disposición/maestra, y aún puede sobrescribir rellenos, bordes y colores de texto sobre ese tema.

**¿Puedo ordenar filas de tabla como en Excel?**

No, las tablas de Aspose.Slides no incluyen ordenación ni filtros integrados. Ordene sus datos en memoria primero y luego vuelva a poblar las filas de la tabla en ese orden.

**¿Puedo tener columnas con bandas (rayas) manteniendo colores personalizados en celdas específicas?**

Sí. Active columnas con bandas y luego sobrescriba celdas específicas con formato local; el formato a nivel de celda tiene prioridad sobre el estilo de tabla.