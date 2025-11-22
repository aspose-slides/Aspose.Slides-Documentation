---
title: Administrar tabla
type: docs
weight: 10
url: /es/nodejs-java/manage-table/
keywords: "Tabla, crear tabla, acceder a tabla, relación de aspecto de tabla, presentación de PowerPoint, Java, Aspose.Slides para Node.js vía Java"
description: "Crear y administrar tabla en presentaciones de PowerPoint en JavaScript"
---

Una tabla en PowerPoint es una forma eficiente de mostrar y representar información. La información en una cuadrícula de celdas (dispuestas en filas y columnas) es directa y fácil de entender.

Aspose.Slides proporciona la clase [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Table) clase [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Table) clase [Cell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/) clase [Cell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/) y otros tipos para permitirle crear, actualizar y gestionar tablas en todo tipo de presentaciones.

## **Crear tabla desde cero**

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Obtenga una referencia a la diapositiva mediante su índice. 
3. Defina una matriz de `columnWidth`.
4. Defina una matriz de `rowHeight`.
5. Agregue un objeto [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Table) a la diapositiva mediante el método [addTable](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addTable-float-float-double:A-double:A-).
6. Itere a través de cada [Cell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/) para aplicar formato a los bordes superior, inferior, derecho e izquierdo.
7. Combine las dos primeras celdas de la primera fila de la tabla. 
8. Acceda al [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) de una [Cell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/).
9. Agregue texto al [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/).
10. Guarde la presentación modificada.

Este código JavaScript le muestra cómo crear una tabla en una presentación:
```javascript
// Instancia una clase Presentation que representa un archivo PPTX
var pres = new aspose.slides.Presentation();
try {
    // Accede a la primera diapositiva
    var sld = pres.getSlides().get_Item(0);
    // Define columnas con anchuras y filas con alturas
    var dblCols = java.newArray("double", [50, 50, 50]);
    var dblRows = java.newArray("double", [50, 30, 30, 30, 30]);
    // Agrega una forma de tabla a la diapositiva
    var tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);
    // Establece el formato de borde para cada celda
    for (var row = 0; row < tbl.getRows().size(); row++) {
        for (var cell = 0; cell < tbl.getRows().get_Item(row).size(); cell++) {
            var cellFormat = tbl.getRows().get_Item(row).get_Item(cell).getCellFormat();
            cellFormat.getBorderTop().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderTop().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cellFormat.getBorderTop().setWidth(5);
            cellFormat.getBorderBottom().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderBottom().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cellFormat.getBorderBottom().setWidth(5);
            cellFormat.getBorderLeft().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderLeft().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cellFormat.getBorderLeft().setWidth(5);
            cellFormat.getBorderRight().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderRight().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cellFormat.getBorderRight().setWidth(5);
        }
    }
    // Fusiona las celdas 1 y 2 de la fila 1
    tbl.mergeCells(tbl.getRows().get_Item(0).get_Item(0), tbl.getRows().get_Item(1).get_Item(1), false);
    // Agrega texto a la celda fusionada
    tbl.getRows().get_Item(0).get_Item(0).getTextFrame().setText("Merged Cells");
    // Guarda la presentación en el disco
    pres.save("table.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Numeración en tabla estándar**

En una tabla estándar, la numeración de las celdas es directa y basada en cero. La primera celda de una tabla tiene el índice 0,0 (columna 0, fila 0). 

Por ejemplo, las celdas de una tabla con 4 columnas y 4 filas se numeran de la siguiente manera:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Este código JavaScript le muestra cómo especificar la numeración de las celdas en una tabla:
```javascript
// Instancia una clase Presentation que representa un archivo PPTX
var pres = new aspose.slides.Presentation();
try {
    // Accede a la primera diapositiva
    var sld = pres.getSlides().get_Item(0);
    // Define columnas con anchuras y filas con alturas
    var dblCols = java.newArray("double", [70, 70, 70, 70]);
    var dblRows = java.newArray("double", [70, 70, 70, 70]);
    // Agrega una forma de tabla a la diapositiva
    var tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);
    // Establece el formato de borde para cada celda
    for (let i = 0; i < tbl.getRows().size(); i++) {
        const row = tbl.getRows().get_Item(i);
        for (let j = 0; j < row.size(); j++) {
            const cell = row.get_Item(j);
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderTop().setWidth(5);
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderBottom().setWidth(5);
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderLeft().setWidth(5);
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderRight().setWidth(5);
        }
    }
    // Guarda la presentación en disco
    pres.save("StandardTables_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Acceder a tabla existente**

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Obtenga una referencia a la diapositiva que contiene la tabla mediante su índice. 
3. Cree un objeto [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Table) y establézcalo en null.
4. Itere a través de todos los objetos [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) hasta que se encuentre la tabla.

   Si sospecha que la diapositiva con la que está trabajando contiene una sola tabla, puede simplemente revisar todas las formas que contiene. Cuando una forma se identifica como una tabla, puede convertirla a un objeto [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Table). Pero si la diapositiva contiene varias tablas, es mejor buscar la tabla que necesita mediante su [setAlternativeText(String value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#setAlternativeText-java.lang.String-).

5. Use el objeto [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Table) para trabajar con la tabla. En el ejemplo a continuación, agregamos una nueva fila a la tabla.
6. Guarde la presentación modificada.

Este código JavaScript le muestra cómo acceder y trabajar con una tabla existente:
```javascript
// Instancia la clase Presentation que representa un archivo PPTX
var pres = new aspose.slides.Presentation("UpdateExistingTable.pptx");
try {
    // Accede a la primera diapositiva
    var sld = pres.getSlides().get_Item(0);
    // Inicializa TableEx nulo
    var tbl = null;
    // Recorre las formas y establece una referencia a la tabla encontrada
    for (let i = 0; i < sld.getShapes().size(); i++) {
        let shp = sld.getShapes().get_Item(i);
        if (java.instanceOf(shp, "com.aspose.slides.ITable")) {
            tbl = shp;
            // Establece el texto para la primera columna de la segunda fila
            tbl.get_Item(0, 1).getTextFrame().setText("New");
        }
    }
    // Guarda la presentación modificada en disco
    pres.save("table1_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Alinear texto en tabla**

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Obtenga una referencia a la diapositiva mediante su índice. 
3. Agregue un objeto [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Table) a la diapositiva.
4. Acceda a un objeto [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) de la tabla.
5. Acceda al [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/) del [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/).
6. Alinee el texto verticalmente.
7. Guarde la presentación modificada.

Este código JavaScript le muestra cómo alinear el texto en una tabla:
```javascript
// Crea una instancia de la clase Presentation
var pres = new aspose.slides.Presentation();
try {
    // Obtiene la primera diapositiva
    var slide = pres.getSlides().get_Item(0);
    // Define columnas con anchuras y filas con alturas
    var dblCols = java.newArray("double", [120, 120, 120, 120]);
    var dblRows = java.newArray("double", [100, 100, 100, 100]);
    // Agrega la forma de tabla a la diapositiva
    var tbl = slide.getShapes().addTable(100, 50, dblCols, dblRows);
    tbl.get_Item(1, 0).getTextFrame().setText("10");
    tbl.get_Item(2, 0).getTextFrame().setText("20");
    tbl.get_Item(3, 0).getTextFrame().setText("30");
    // Accede al marco de texto
    var txtFrame = tbl.get_Item(0, 0).getTextFrame();
    // Crea el objeto Paragraph para el marco de texto
    var paragraph = txtFrame.getParagraphs().get_Item(0);
    // Crea el objeto Portion para el párrafo
    var portion = paragraph.getPortions().get_Item(0);
    portion.setText("Text here");
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // Alinea el texto verticalmente
    var cell = tbl.get_Item(0, 0);
    cell.setTextAnchorType(aspose.slides.TextAnchorType.Center);
    cell.setTextVerticalType(aspose.slides.TextVerticalType.Vertical270);
    // Guarda la presentación en disco
    pres.save("Vertical_Align_Text_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Establecer formato de texto a nivel de tabla**

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Obtenga una referencia a la diapositiva mediante su índice. 
3. Acceda a un objeto [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Table) de la diapositiva.
4. Establezca el [setFontHeight(float value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight-float-) para el texto.
5. Establezca el [setAlignment(int value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) y el [setMarginRight(float value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setMarginRight-float-).
6. Establezca el [setTextVerticalType(byte value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-).
7. Guarde la presentación modificada. 

Este código JavaScript le muestra cómo aplicar sus opciones de formato preferidas al texto en una tabla:
```javascript
// Crea una instancia de la clase Presentation
var pres = new aspose.slides.Presentation("simpletable.pptx");
try {
    // Supongamos que la primera forma en la primera diapositiva es una tabla
    var someTable = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    // Establece la altura de fuente de las celdas de la tabla
    var portionFormat = new aspose.slides.PortionFormat();
    portionFormat.setFontHeight(25);
    someTable.setTextFormat(portionFormat);
    // Establece la alineación del texto y el margen derecho de las celdas de la tabla en una sola llamada
    var paragraphFormat = new aspose.slides.ParagraphFormat();
    paragraphFormat.setAlignment(aspose.slides.TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    someTable.setTextFormat(paragraphFormat);
    // Establece el tipo vertical de texto de las celdas de la tabla
    var textFrameFormat = new aspose.slides.TextFrameFormat();
    textFrameFormat.setTextVerticalType(aspose.slides.TextVerticalType.Vertical);
    someTable.setTextFormat(textFrameFormat);
    pres.save("result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Obtener propiedades de estilo de tabla**

Aspose.Slides le permite recuperar las propiedades de estilo de una tabla para que pueda usar esos detalles en otra tabla o en otro lugar. Este código JavaScript le muestra cómo obtener las propiedades de estilo de un estilo predefinido de tabla:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var table = pres.getSlides().get_Item(0).getShapes().addTable(10, 10, java.newArray("double", [100, 150]), java.newArray("double", [5, 5, 5]));
    table.setStylePreset(aspose.slides.TableStylePreset.DarkStyle1);// change the default style preset theme
    pres.save("table.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Bloquear proporción de aspecto de la tabla**

La proporción de aspecto de una forma geométrica es la relación de sus tamaños en diferentes dimensiones. Aspose.Slides proporciona la propiedad [**setAspectRatioLocked**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GraphicalObjectLock#setAspectRatioLocked-boolean-) para permitirle bloquear la configuración de proporción de aspecto para tablas y otras formas.

Este código JavaScript le muestra cómo bloquear la proporción de aspecto para una tabla:
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var table = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    console.log("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());
    table.getGraphicalObjectLock().setAspectRatioLocked(!table.getGraphicalObjectLock().getAspectRatioLocked());// invert
    console.log("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());
    pres.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Preguntas frecuentes**

**¿Puedo habilitar la dirección de lectura de derecha a izquierda (RTL) para una tabla completa y el texto en sus celdas?**

Sí. La tabla expone un método [setRightToLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/setrighttoleft/) y los párrafos tienen [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setrighttoleft/). Usar ambos garantiza el orden RTL correcto y la renderización dentro de las celdas.

**¿Cómo puedo evitar que los usuarios muevan o cambien el tamaño de una tabla en el archivo final?**

Utilice [bloqueos de forma](/slides/es/nodejs-java/applying-protection-to-presentation/) para desactivar el movimiento, el cambio de tamaño, la selección, etc. Estos bloqueos también se aplican a las tablas.

**¿Se admite insertar una imagen dentro de una celda como fondo?**

Sí. Puede establecer un [relleno de imagen](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/) para una celda; la imagen cubrirá el área de la celda según el modo elegido (estirar o mosaico).