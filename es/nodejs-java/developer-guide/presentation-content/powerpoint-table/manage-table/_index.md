---
title: Gestionar tablas de presentación en JavaScript
linktitle: Gestionar tabla
type: docs
weight: 10
url: /es/nodejs-java/manage-table/
keywords:
- añadir tabla
- crear tabla
- acceder a tabla
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

Una tabla en PowerPoint es una forma eficiente de mostrar y representar información. La información en una cuadrícula de celdas (dispuestas en filas y columnas) es directa y fácil de entender.

Aspose.Slides proporciona la clase [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Table), la clase [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Table), la clase [Cell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/), la clase [Cell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/) y otros tipos para permitir crear, actualizar y gestionar tablas en todo tipo de presentaciones.

## **Crear tabla desde cero**

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).  
2. Obtener una referencia a una diapositiva mediante su índice.  
3. Definir una matriz de `columnWidth`.  
4. Definir una matriz de `rowHeight`.  
5. Añadir un objeto [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Table) a la diapositiva mediante el método [addTable](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addTable-float-float-double:A-double:A-).  
6. Recorrer cada [Cell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/) para aplicar formato a los bordes superior, inferior, derecho e izquierdo.  
7. Fusionar las dos primeras celdas de la primera fila de la tabla.  
8. Acceder al [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) de una [Cell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/).  
9. Añadir texto al [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/).  
10. Guardar la presentación modificada.

Este código JavaScript muestra cómo crear una tabla en una presentación:
```javascript
// Instancia una clase Presentation que representa un archivo PPTX
var pres = new aspose.slides.Presentation();
try {
    // Accede a la primera diapositiva
    var sld = pres.getSlides().get_Item(0);
    // Define columnas con anchuras y filas con alturas
    var dblCols = java.newArray("double", [50, 50, 50]);
    var dblRows = java.newArray("double", [50, 30, 30, 30, 30]);
    // Añade una forma de tabla a la diapositiva
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
    // Añade texto a la celda fusionada
    tbl.getRows().get_Item(0).get_Item(0).getTextFrame().setText("Merged Cells");
    // Guarda la presentación en disco
    pres.save("table.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Numeración en tabla estándar**

En una tabla estándar, la numeración de las celdas es directa y comienza en cero. La primera celda de una tabla tiene el índice 0,0 (columna 0, fila 0).

Por ejemplo, las celdas de una tabla con 4 columnas y 4 filas se numeran así:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Este código JavaScript muestra cómo especificar la numeración de las celdas en una tabla:
```javascript
// Instancia una clase Presentation que representa un archivo PPTX
var pres = new aspose.slides.Presentation();
try {
    // Accede a la primera diapositiva
    var sld = pres.getSlides().get_Item(0);
    // Define columnas con anchuras y filas con alturas
    var dblCols = java.newArray("double", [70, 70, 70, 70]);
    var dblRows = java.newArray("double", [70, 70, 70, 70]);
    // Añade una forma de tabla a la diapositiva
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


## **Acceder a una tabla existente**

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).  

2. Obtener una referencia a la diapositiva que contiene la tabla mediante su índice.  

3. Crear un objeto [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Table) y establecerlo en null.  

4. Recorrer todos los objetos [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) hasta encontrar la tabla.  

   Si sospecha que la diapositiva que está tratando contiene una única tabla, puede simplemente comprobar todas las formas que contiene. Cuando una forma se identifica como tabla, puede convertirla a un objeto [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Table). Pero si la diapositiva contiene varias tablas, será mejor buscar la tabla que necesita mediante su [setAlternativeText(String value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#setAlternativeText-java.lang.String-).  

5. Utilizar el objeto [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Table) para trabajar con la tabla. En el ejemplo siguiente, añadimos una nueva fila a la tabla.  

6. Guardar la presentación modificada.

Este código JavaScript muestra cómo acceder y trabajar con una tabla existente:
```javascript
// Instancia la clase Presentation que representa un archivo PPTX
var pres = new aspose.slides.Presentation("UpdateExistingTable.pptx");
try {
    // Accede a la primera diapositiva
    var sld = pres.getSlides().get_Item(0);
    // Inicializa TableEx nulo
    var tbl = null;
    // Itera a través de las formas y establece una referencia a la tabla encontrada
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


## **Alinear texto en la tabla**

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).  
2. Obtener una referencia a una diapositiva mediante su índice.  
3. Añadir un objeto [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Table) a la diapositiva.  
4. Acceder a un objeto [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) de la tabla.  
5. Acceder al [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/) del [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/).  
6. Alinear el texto verticalmente.  
7. Guardar la presentación modificada.

Este código JavaScript muestra cómo alinear el texto en una tabla:
```javascript
// Crea una instancia de la clase Presentation
var pres = new aspose.slides.Presentation();
try {
    // Obtiene la primera diapositiva
    var slide = pres.getSlides().get_Item(0);
    // Define columnas con anchuras y filas con alturas
    var dblCols = java.newArray("double", [120, 120, 120, 120]);
    var dblRows = java.newArray("double", [100, 100, 100, 100]);
    // Añade la forma de tabla a la diapositiva
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

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).  
2. Obtener una referencia a una diapositiva mediante su índice.  
3. Acceder a un objeto [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Table) de la diapositiva.  
4. Establecer el [setFontHeight(float value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight-float-) para el texto.  
5. Establecer el [setAlignment(int value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) y el [setMarginRight(float value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setMarginRight-float-).  
6. Establecer el [setTextVerticalType(byte value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-).  
7. Guardar la presentación modificada.

Este código JavaScript muestra cómo aplicar sus opciones de formato preferidas al texto de una tabla:
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
    // Establece el tipo de texto vertical de las celdas de la tabla
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


## **Obtener propiedades de estilo de la tabla**

Aspose.Slides le permite recuperar las propiedades de estilo de una tabla para que pueda utilizarlas en otra tabla o en otro lugar. Este código JavaScript muestra cómo obtener las propiedades de estilo a partir de un estilo predefinido de tabla:
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


## **Bloquear relación de aspecto de la tabla**

La relación de aspecto de una forma geométrica es la proporción de sus dimensiones. Aspose.Slides proporciona la propiedad [**setAspectRatioLocked**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GraphicalObjectLock#setAspectRatioLocked-boolean-) para permitir bloquear la configuración de relación de aspecto de tablas y otras formas.

Este código JavaScript muestra cómo bloquear la relación de aspecto de una tabla:
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


## **FAQ**

**¿Puedo habilitar la dirección de lectura de derecha a izquierda (RTL) para una tabla completa y el texto en sus celdas?**

Sí. La tabla expone el método [setRightToLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/setrighttoleft/), y los párrafos tienen [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setrighttoleft/). Usar ambos garantiza el orden RTL correcto y el renderizado dentro de las celdas.

**¿Cómo puedo evitar que los usuarios muevan o cambien el tamaño de una tabla en el archivo final?**

Utilice bloqueos de forma para desactivar mover, cambiar el tamaño, seleccionar, etc. Estos bloqueos también se aplican a las tablas.

**¿Se admite insertar una imagen dentro de una celda como fondo?**

Sí. Puede establecer un [picture fill](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/) para una celda; la imagen cubrirá el área de la celda según el modo elegido (estirar o mosaico).