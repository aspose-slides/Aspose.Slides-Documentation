---
title: Gestionar tablas de presentaciones en JavaScript
linktitle: Gestionar tabla
type: docs
weight: 10
url: /es/nodejs-java/manage-table/
keywords:
- añadir tabla
- crear tabla
- acceder tabla
- relación de aspecto
- alinear texto
- formato de texto
- estilo de tabla
- PowerPoint
- presentación
- Node.js
- JavaScript
- Aspose.Slides
description: "Crear y editar tablas en diapositivas de PowerPoint con JavaScript y Aspose.Slides para Node.js. Descubre ejemplos de código sencillos para optimizar tus flujos de trabajo con tablas."
---
## **Introducción**

Las tablas en PowerPoint organizan la información en filas y columnas, facilitando su lectura y comparación de valores.

Aspose.Slides proporciona la clase [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/), la clase [Cell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/) y otros tipos que le permiten crear, actualizar y gestionar tablas en presentaciones.

## **Crear una tabla desde cero**

Cree una tabla especificando su posición, anchuras de columna y alturas de fila. Después de añadirla a una diapositiva, puede dar formato a los bordes de las celdas, combinar celdas e insertar texto.

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. Obtener una referencia a la diapositiva mediante su índice.
3. Definir una matriz de anchuras de columna en puntos.
4. Definir una matriz de alturas de fila en puntos.
5. Añadir un objeto [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) a la diapositiva a través del método [addTable](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addTable-float-float-double:A-double:A-).
6. Recorrer cada [Cell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/) para aplicar formato a los bordes superior, inferior, derecho e izquierdo.
7. Combinar las dos primeras celdas de la primera fila de la tabla.
8. Acceder a la celda combinada mediante su método [getTextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#getTextFrame--) .
9. Establecer el texto en la celda combinada.
10. Guardar la presentación modificada.

El ejemplo siguiente crea una tabla con tres columnas y cinco filas en el punto (100, 50). Aplica bordes rojos de 5 puntos de ancho, combina las dos primeras celdas de la primera fila y guarda el resultado como `table.pptx`.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const red = java.getStaticFieldValue("java.awt.Color", "RED");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [50, 50, 50]);
    const rowHeights = java.newArray("double", [50, 30, 30, 30, 30]);
    const table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    for (let i = 0; i < table.getRows().size(); i++) {
        const row = table.getRows().get_Item(i);
        for (let j = 0; j < row.size(); j++) {
            const cell = row.get_Item(j);
            const cellFormat = cell.getCellFormat();
            cellFormat.getBorderTop().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderTop().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderTop().setWidth(5);

            cellFormat.getBorderBottom().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderBottom().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderBottom().setWidth(5);

            cellFormat.getBorderLeft().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderLeft().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderLeft().setWidth(5);

            cellFormat.getBorderRight().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderRight().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderRight().setWidth(5);
        }
    }

    table.mergeCells(table.get_Item(0, 0), table.get_Item(1, 0), false);
    table.get_Item(0, 0).getTextFrame().setText("Merged Cells");

    presentation.save("table.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Numeración en una tabla estándar**

En una tabla estándar, los índices de las celdas comienzan en cero y siguen el orden (columna, fila). La primera celda tiene el índice (0, 0).

Por ejemplo, las celdas de una tabla con 4 columnas y 4 filas se numeran de la siguiente manera:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Este ejemplo crea la tabla 4 × 4 ilustrada arriba, con anchuras de columna y alturas de fila de 70 puntos y bordes rojos de 5 puntos de ancho. Las coordenadas ilustran los índices de las celdas; el ejemplo deja las celdas vacías y guarda la tabla como `StandardTables_out.pptx`.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const red = java.getStaticFieldValue("java.awt.Color", "RED");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [70, 70, 70, 70]);
    const rowHeights = java.newArray("double", [70, 70, 70, 70]);
    const table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    for (let i = 0; i < table.getRows().size(); i++) {
        const row = table.getRows().get_Item(i);
        for (let j = 0; j < row.size(); j++) {
            const cell = row.get_Item(j);
            const cellFormat = cell.getCellFormat();
            cellFormat.getBorderTop().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderTop().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderTop().setWidth(5);

            cellFormat.getBorderBottom().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderBottom().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderBottom().setWidth(5);

            cellFormat.getBorderLeft().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderLeft().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderLeft().setWidth(5);

            cellFormat.getBorderRight().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderRight().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderRight().setWidth(5);
        }
    }

    presentation.save("StandardTables_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Acceder a una tabla existente**

Las tablas se almacenan en la colección de formas de una diapositiva. Recorra las formas para localizar una tabla y luego use la clase [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) para leer o actualizar sus celdas.

1. Cargar la presentación usando la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. Obtener una referencia a la diapositiva que contiene la tabla mediante su índice.
3. Recorrer los objetos [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) y detenerse cuando se encuentre una tabla. Si la diapositiva contiene varias tablas, utilice [getAlternativeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getAlternativeText--) para identificar la que necesita.
4. Actualizar el texto en la celda objetivo.
5. Guardar la presentación modificada.

El ejemplo siguiente abre `UpdateExistingTable.pptx` y encuentra la primera tabla de la primera diapositiva. Establece la celda de la columna 0, fila 1 a `New` y guarda el resultado como `table1_out.pptx`. La entrada debe contener al menos una diapositiva, y la primera tabla de esa diapositiva debe tener al menos una columna y dos filas.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("UpdateExistingTable.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    let table = null;

    for (let i = 0; i < slide.getShapes().size(); i++) {
        const shape = slide.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.ITable")) {
            table = shape;
            break;
        }
    }

    if (table != null) {
        table.get_Item(0, 1).getTextFrame().setText("New");
        presentation.save("table1_out.pptx", aspose.slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Para cambiar el tamaño de una fila en una tabla existente y entender por qué su altura real puede superar la altura mínima solicitada, vea [Control de altura de fila](/slides/es/nodejs-java/manage-rows-and-columns/#control-row-height).

## **Encontrar la celda que posee un marco de texto**

Cuando el código genérico de procesamiento de texto recibe un [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) de una tabla, utilice el método [TextFrame.getParentCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/#getParentCell--) para obtener la [Cell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/) propietaria. Para un marco de texto de una celda de tabla, [TextFrame.getParentCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/#getParentCell--) devuelve el propietario y [TextFrame.getParentShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/#getParentShape--) devuelve `null`, aunque la tabla en sí es una forma.

Las coordenadas de la celda están disponibles mediante los métodos de solo lectura [Cell.getFirstColumnIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#getFirstColumnIndex--) y [Cell.getFirstRowIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#getFirstRowIndex--). [TextFrame.getParentCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/#getParentCell--) también proporciona navegación de solo lectura: devuelve el propietario pero no cambia la propiedad. Siempre compruebe si la celda devuelta es `null` antes de usarla.

Para un ejemplo completo que identifica propietarios de celdas de tabla y de formas, incluidas las formas asociadas a nodos de SmartArt, vea [Buscar y reemplazar texto](/slides/es/nodejs-java/search-and-replace-text/).

## **Alinear texto en una tabla**

Puede controlar el anclaje vertical y la dirección del texto de celdas individuales. El ejemplo de esta sección centra el texto dentro de la primera celda y lo rota 270 grados.

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. Obtener una referencia a la diapositiva mediante su índice.
3. Añadir un objeto [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) a la diapositiva.
4. Acceder a un objeto [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) de la tabla.
5. Acceder al primer [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/) y establecer su texto y color.
6. Establecer el anclaje vertical y la dirección del texto de la celda mediante [setTextAnchorType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#setTextAnchorType-byte-) y [setTextVerticalType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#setTextVerticalType-byte-).
7. Guardar la presentación modificada.

Este ejemplo crea una tabla 4 × 4 con anchuras de columna de 120 puntos y alturas de fila de 100 puntos. Da formato al texto de la celda (0, 0), añade valores a las celdas restantes de la primera fila y guarda el resultado como `Vertical_Align_Text_out.pptx`.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const black = java.getStaticFieldValue("java.awt.Color", "BLACK");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [120, 120, 120, 120]);
    const rowHeights = java.newArray("double", [100, 100, 100, 100]);
    const table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.get_Item(1, 0).getTextFrame().setText("10");
    table.get_Item(2, 0).getTextFrame().setText("20");
    table.get_Item(3, 0).getTextFrame().setText("30");

    const textFrame = table.get_Item(0, 0).getTextFrame();
    const paragraph = textFrame.getParagraphs().get_Item(0);

    const portion = paragraph.getPortions().get_Item(0);
    portion.setText("Text here");
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(black);

    const cell = table.get_Item(0, 0);
    cell.setTextAnchorType(java.newByte(aspose.slides.TextAnchorType.Center));
    cell.setTextVerticalType(java.newByte(aspose.slides.TextVerticalType.Vertical270));

    presentation.save("Vertical_Align_Text_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Establecer formato de texto a nivel de tabla**

Utilice [setTextFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#setTextFormat-com.aspose.slides.IPortionFormat-) para aplicar formato de texto a todas las celdas de una tabla. Sus sobrecargas aceptan formato de porción, de párrafo y de marco de texto, por lo que puede establecer estas propiedades sin iterar por cada celda.

1. Cargar la presentación usando la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. Obtener una referencia a la diapositiva mediante su índice.
3. Acceder a un objeto [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) de la diapositiva.
4. Establecer el tamaño de fuente mediante [setFontHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight-float-) para el texto.
5. Establecer la alineación del párrafo y el margen derecho mediante [setAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) y [setMarginRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setMarginRight-float-).
6. Establecer la dirección del texto mediante [setTextVerticalType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-).
7. Guardar la presentación modificada.

El ejemplo siguiente abre `table.pptx`, que debe contener al menos una diapositiva con una tabla como su primera forma. Establece el tamaño de fuente a 25 puntos, alinea a la derecha los párrafos con un margen derecho de 20 puntos y hace que el texto sea vertical. La presentación formateada se guarda como `result.pptx`.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("table.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const table = slide.getShapes().get_Item(0);

    const portionFormat = new aspose.slides.PortionFormat();
    portionFormat.setFontHeight(25);
    table.setTextFormat(portionFormat);

    const paragraphFormat = new aspose.slides.ParagraphFormat();
    paragraphFormat.setAlignment(aspose.slides.TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    table.setTextFormat(paragraphFormat);

    const textFrameFormat = new aspose.slides.TextFrameFormat();
    textFrameFormat.setTextVerticalType(java.newByte(aspose.slides.TextVerticalType.Vertical));
    table.setTextFormat(textFrameFormat);

    presentation.save("result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Obtener propiedades de estilo de tabla**

Use [getStylePreset](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#getStylePreset--) para leer el estilo predefinido de una tabla y [setStylePreset](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#setStylePreset-int-) para asignarlo. Este ejemplo aplica [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tablestylepreset/) a una tabla, imprime el valor predefinido y asigna el mismo predefinido a una segunda tabla. Ambas tablas se guardan en `table-style.pptx`.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [100, 150]);
    const rowHeights = java.newArray("double", [5, 5, 5]);
    const table = slide.getShapes().addTable(10, 10, columnWidths, rowHeights);
    table.setStylePreset(aspose.slides.TableStylePreset.DarkStyle1);

    const stylePreset = table.getStylePreset();
    console.log("Table style preset: " + stylePreset);

    const anotherTable = slide.getShapes().addTable(10, 100, columnWidths, rowHeights);
    anotherTable.setStylePreset(stylePreset);

    presentation.save("table-style.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Bloquear la relación de aspecto de una tabla**

La relación de aspecto de una tabla es la proporción de su ancho respecto a su altura. Use [setAspectRatioLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/graphicalobjectlock/#setAspectRatioLocked-boolean-) para bloquear esta proporción para una tabla.

El ejemplo siguiente abre `pres.pptx`, que debe contener al menos una diapositiva con una tabla como su primera forma. Imprime el estado de bloqueo actual, habilita el bloqueo de relación de aspecto, imprime el estado actualizado (`true`) y guarda el resultado como `pres-out.pptx`.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const table = slide.getShapes().get_Item(0);
    console.log("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    table.getGraphicalObjectLock().setAspectRatioLocked(true);
    console.log("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    presentation.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Preguntas frecuentes**

**¿Puedo habilitar la dirección de lectura de derecha a izquierda (RTL) para toda una tabla y el texto en sus celdas?**

Sí. La tabla expone un método [setRightToLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#setRightToLeft-boolean-), y los párrafos tienen [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setRightToLeft-byte-). Usar ambos garantiza el orden RTL correcto y el renderizado dentro de las celdas.

**¿Cómo puedo impedir que los usuarios muevan o cambien el tamaño de una tabla en el archivo final?**

Utilice [bloqueos de forma](https://reference.aspose.com/slides/nodejs-java/aspose.slides/graphicalobjectlock/) para desactivar el movimiento, el cambio de tamaño, la selección, etc. Estos bloqueos también se aplican a las tablas.

**¿Se admite insertar una imagen dentro de una celda como fondo?**

Sí. Puede establecer un [relleno de imagen](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/) para una celda; la imagen cubrirá el área de la celda según el modo elegido (estirar o mosaico).