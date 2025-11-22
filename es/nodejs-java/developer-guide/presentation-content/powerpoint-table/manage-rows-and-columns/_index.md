---
title: Gestionar filas y columnas
type: docs
weight: 20
url: /es/nodejs-java/manage-rows-and-columns/
keywords: "Tabla, filas y columnas de tabla, presentación de PowerPoint, Java, Aspose.Slides para Node.js mediante Java"
description: "Gestionar filas y columnas de tabla en presentaciones de PowerPoint en JavaScript"
---

Para permitirle administrar las filas y columnas de una tabla en una presentación de PowerPoint, Aspose.Slides proporciona la clase [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) , [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Table) y muchos otros tipos.

## **Establecer la primera fila como encabezado**

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) y cargue la presentación.  
2. Obtenga la referencia de una diapositiva mediante su índice.  
3. Cree un objeto [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Table) y establézcalo en null.  
4. Itere a través de todos los objetos [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) para encontrar la tabla correspondiente.  
5. Establezca la primera fila de la tabla como su encabezado.  

Este código JavaScript le muestra cómo establecer la primera fila de una tabla como su encabezado:
```javascript
// Instancia la clase Presentation
var pres = new aspose.slides.Presentation("table.pptx");
try {
    // Accede a la primera diapositiva
    var sld = pres.getSlides().get_Item(0);
    // Inicializa la TableEx nula
    var tbl = null;
    // Recorre las formas y establece una referencia a la tabla
    for (let i = 0; i < sld.getShapes().size(); i++) {
        let shp = sld.getShapes().get_Item(i);
        if (java.instanceOf(shp, "com.aspose.slides.ITable")) {
            tbl = shp;
            // Establece la primera fila de la tabla como encabezado
            tbl.setFirstRow(true);
        }
    }
    // Guarda la presentación en disco
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Clonar fila o columna de la tabla**

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) y cargue la presentación,  
2. Obtenga la referencia de una diapositiva mediante su índice.  
3. Defina una matriz de `columnWidth`.  
4. Defina una matriz de `rowHeight`.  
5. Añada un objeto [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Table) a la diapositiva mediante el método [addTable](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addTable-float-float-double---double---).  
6. Clone la fila de la tabla.  
7. Clone la columna de la tabla.  
8. Guarde la presentación modificada.  

Este código JavaScript le muestra cómo clonar una fila o columna de una tabla de PowerPoint:
```javascript
// Instancia la clase Presentation
var pres = new aspose.slides.Presentation("Test.pptx");
try {
    // Accede a la primera diapositiva
    var sld = pres.getSlides().get_Item(0);
    // Define columnas con anchos y filas con alturas
    var dblCols = java.newArray("double", [50, 50, 50]);
    var dblRows = java.newArray("double", [50, 30, 30, 30, 30]);
    // Añade una forma de tabla a la diapositiva
    var table = sld.getShapes().addTable(100, 50, dblCols, dblRows);
    // Añade texto a la celda 1 de la fila 1
    table.get_Item(0, 0).getTextFrame().setText("Row 1 Cell 1");
    // Añade texto a la celda 2 de la fila 1
    table.get_Item(1, 0).getTextFrame().setText("Row 1 Cell 2");
    // Clona la fila 1 al final de la tabla
    table.getRows().addClone(table.getRows().get_Item(0), false);
    // Añade texto a la celda 1 de la fila 2
    table.get_Item(0, 1).getTextFrame().setText("Row 2 Cell 1");
    // Añade texto a la celda 2 de la fila 2
    table.get_Item(1, 1).getTextFrame().setText("Row 2 Cell 2");
    // Clona la fila 2 como cuarta fila de la tabla
    table.getRows().insertClone(3, table.getRows().get_Item(1), false);
    // Clona la primera columna al final
    table.getColumns().addClone(table.getColumns().get_Item(0), false);
    // Clona la segunda columna en el índice 4
    table.getColumns().insertClone(3, table.getColumns().get_Item(1), false);
    // Guarda la presentación en disco
    pres.save("table_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Eliminar fila o columna de la tabla**

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) y cargue la presentación,  
2. Obtenga la referencia de una diapositiva mediante su índice.  
3. Defina una matriz de `columnWidth`.  
4. Defina una matriz de `rowHeight`.  
5. Añada un objeto [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Table) a la diapositiva mediante el método [addTable](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addTable-float-float-double---double---).  
6. Elimine la fila de la tabla.  
7. Elimine la columna de la tabla.  
8. Guarde la presentación modificada.  

Este código JavaScript le muestra cómo eliminar una fila o columna de una tabla:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var colWidth = java.newArray("double", [100, 50, 30]);
    var rowHeight = java.newArray("double", [30, 50, 30]);
    var table = slide.getShapes().addTable(100, 100, colWidth, rowHeight);
    table.getRows().removeAt(1, false);
    table.getColumns().removeAt(1, false);
    pres.save("TestTable_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Establecer formato de texto a nivel de fila de tabla**

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) y cargue la presentación,  
2. Obtenga la referencia de una diapositiva mediante su índice.  
3. Acceda al objeto [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Table) relevante desde la diapositiva.  
4. Establezca la altura de fuente de las celdas de la primera fila mediante [setFontHeight(float value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight-float-).  
5. Establezca la alineación de las celdas de la primera fila mediante [setAlignment(int value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) y [setMarginRight(float value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setMarginRight-float-).  
6. Establezca el tipo de texto vertical de las celdas de la segunda fila mediante [setTextVerticalType(byte value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-).  
7. Guarde la presentación modificada.  

Este código JavaScript demuestra la operación.
```javascript
// Crea una instancia de la clase Presentation
var pres = new aspose.slides.Presentation();
try {
    // Supongamos que la primera forma en la primera diapositiva es una tabla
    var someTable = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    // Establece la altura de fuente de las celdas de la primera fila
    var portionFormat = new aspose.slides.PortionFormat();
    portionFormat.setFontHeight(25);
    someTable.getRows().get_Item(0).setTextFormat(portionFormat);
    // Establece la alineación del texto y el margen derecho de las celdas de la primera fila
    var paragraphFormat = new aspose.slides.ParagraphFormat();
    paragraphFormat.setAlignment(aspose.slides.TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    someTable.getRows().get_Item(0).setTextFormat(paragraphFormat);
    // Establece el tipo de texto vertical de las celdas de la segunda fila
    var textFrameFormat = new aspose.slides.TextFrameFormat();
    textFrameFormat.setTextVerticalType(aspose.slides.TextVerticalType.Vertical);
    someTable.getRows().get_Item(1).setTextFormat(textFrameFormat);
    // Guarda la presentación en disco
    pres.save("result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Establecer formato de texto a nivel de columna de tabla**

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) y cargue la presentación,  
2. Obtenga la referencia de una diapositiva mediante su índice.  
3. Acceda al objeto [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Table) relevante desde la diapositiva.  
4. Establezca la altura de fuente de las celdas de la primera columna mediante [setFontHeight(float value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight-float-).  
5. Establezca la alineación de las celdas de la primera columna mediante [setAlignment(int value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) y [setMarginRight(float value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setMarginRight-float-).  
6. Establezca el tipo de texto vertical de las celdas de la segunda columna mediante [setTextVerticalType(byte value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-).  
7. Guarde la presentación modificada.  

Este código JavaScript demuestra la operación:
```javascript
// Crea una instancia de la clase Presentation
var pres = new aspose.slides.Presentation();
try {
    // Supongamos que la primera forma en la primera diapositiva es una tabla
    var someTable = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    // Establece la altura de fuente de las celdas de la primera columna
    var portionFormat = new aspose.slides.PortionFormat();
    portionFormat.setFontHeight(25);
    someTable.getColumns().get_Item(0).setTextFormat(portionFormat);
    // Establece la alineación del texto y el margen derecho de las celdas de la primera columna en una sola llamada
    var paragraphFormat = new aspose.slides.ParagraphFormat();
    paragraphFormat.setAlignment(aspose.slides.TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    someTable.getColumns().get_Item(0).setTextFormat(paragraphFormat);
    // Establece el tipo de texto vertical de las celdas de la segunda columna
    var textFrameFormat = new aspose.slides.TextFrameFormat();
    textFrameFormat.setTextVerticalType(aspose.slides.TextVerticalType.Vertical);
    someTable.getColumns().get_Item(1).setTextFormat(textFrameFormat);
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
    table.setStylePreset(aspose.slides.TableStylePreset.DarkStyle1);// cambia el tema predeterminado del estilo preestablecido
    pres.save("table.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**¿Puedo aplicar temas/estilos de PowerPoint a una tabla que ya está creada?**

Sí. La tabla hereda el tema de la diapositiva/disposición/maestro, y aún puede sobrescribir los rellenos, bordes y colores de texto sobre ese tema.

**¿Puedo ordenar filas de tabla como en Excel?**

No, las tablas de Aspose.Slides no tienen ordenamiento o filtros incorporados. Ordene sus datos en memoria primero, y luego vuelva a poblar las filas de la tabla en ese orden.

**¿Puedo tener columnas con bandas (a rayas) manteniendo colores personalizados en celdas específicas?**

Sí. Active las columnas con bandas y luego sobrescriba celdas específicas con formato local; el formato a nivel de celda tiene precedencia sobre el estilo de tabla.