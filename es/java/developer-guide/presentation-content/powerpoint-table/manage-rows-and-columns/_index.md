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
description: "Gestiona filas y columnas de tablas en PowerPoint con Aspose.Slides para Java y acelera la edición de presentaciones y la actualización de datos."
---

Para permitirle administrar las filas y columnas de una tabla en una presentación de PowerPoint, Aspose.Slides ofrece la clase [Table](https://reference.aspose.com/slides/java/com.aspose.slides/table/) , la interfaz [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/ITable) y muchos otros tipos. 

## **Establecer la primera fila como encabezado**

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) y cargue la presentación. 
2. Obtenga la referencia de una diapositiva mediante su índice. 
3. Cree un objeto [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/ITable) y establézcalo en null. 
4. Itere a través de todos los objetos [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) para encontrar la tabla correspondiente. 
5. Establezca la primera fila de la tabla como su encabezado. 

Este código Java le muestra cómo establecer la primera fila de una tabla como su encabezado:
```java
// Instancia la clase Presentation
Presentation pres = new Presentation("table.pptx");
try {
    // Accede a la primera diapositiva
    ISlide sld = pres.getSlides().get_Item(0);

    // Inicializa la tabla nula
    ITable tbl = null;

    // Itera a través de las formas y establece una referencia a la tabla
    for (IShape shp : sld.getShapes())
    {
        if (shp instanceof ITable) 
        {
            tbl = (ITable)shp;
            
            // Establece la primera fila de la tabla como encabezado
            tbl.setFirstRow(true);
        }
    }
    
    // Guarda la presentación en disco
    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Clonar una fila o columna de tabla**

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) y cargue la presentación, 
2. Obtenga la referencia de una diapositiva mediante su índice. 
3. Defina una matriz de `columnWidth`. 
4. Defina una matriz de `rowHeight`. 
5. Agregue un objeto [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/ITable) a la diapositiva mediante el método [addTable](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---). 
6. Clone la fila de la tabla. 
7. Clone la columna de la tabla. 
8. Guarde la presentación modificada. 

Este código Java le muestra cómo clonar una fila o columna de una tabla de PowerPoint:
```java
 // Instancia la clase Presentation
Presentation pres = new Presentation("Test.pptx");
try {
    // Accede a la primera diapositiva
    ISlide sld = pres.getSlides().get_Item(0);

    // Define columnas con anchuras y filas con alturas
    double[] dblCols = { 50, 50, 50 };
    double[] dblRows = { 50, 30, 30, 30, 30 };

    // Añade una forma de tabla a la diapositiva
    ITable table = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // Añade texto a la fila 1 celda 1
    table.get_Item(0, 0).getTextFrame().setText("Row 1 Cell 1");

    // Añade texto a la fila 1 celda 2
    table.get_Item(1, 0).getTextFrame().setText("Row 1 Cell 2");

    // Clona la fila 1 al final de la tabla
    table.getRows().addClone(table.getRows().get_Item(0), false);

    // Añade texto a la fila 2 celda 1
    table.get_Item(0, 1).getTextFrame().setText("Row 2 Cell 1");

    // Añade texto a la fila 2 celda 2
    table.get_Item(1, 1).getTextFrame().setText("Row 2 Cell 2");

    // Clona la fila 2 como cuarta fila de la tabla
    table.getRows().insertClone(3, table.getRows().get_Item(1), false);

    // Clona la primera columna al final
    table.getColumns().addClone(table.getColumns().get_Item(0), false);

    // Clona la segunda columna en el índice de la cuarta columna
    table.getColumns().insertClone(3,table.getColumns().get_Item(1), false);
    
    // Guarda la presentación en disco
    pres.save("table_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Eliminar una fila o columna de una tabla**

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) y cargue la presentación, 
2. Obtenga la referencia de una diapositiva mediante su índice. 
3. Defina una matriz de `columnWidth`. 
4. Defina una matriz de `rowHeight`. 
5. Agregue un objeto [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/ITable) a la diapositiva mediante el método [addTable](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---). 
6. Elimine la fila de la tabla. 
7. Elimine la columna de la tabla. 
8. Guarde la presentación modificada. 

Este código Java le muestra cómo eliminar una fila o columna de una tabla:
```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    
    double[] colWidth = { 100, 50, 30 };
    double[] rowHeight = { 30, 50, 30 };

    ITable table = slide.getShapes().addTable(100, 100, colWidth, rowHeight);
    table.getRows().removeAt(1, false);
    table.getColumns().removeAt(1, false);
    
    pres.save("TestTable_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Establecer formato de texto a nivel de fila de tabla**

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) y cargue la presentación, 
2. Obtenga la referencia de una diapositiva mediante su índice. 
3. Acceda al objeto [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/ITable) relevante desde la diapositiva. 
4. Establezca la altura de fuente de las celdas de la primera fila mediante [setFontHeight(float value)](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/#setFontHeight-float-). 
5. Establezca la alineación de las celdas de la primera fila mediante [setAlignment(int value)](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) y el margen derecho mediante [setMarginRight(float value)](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setMarginRight-float-). 
6. Establezca el tipo de texto vertical de las celdas de la segunda fila mediante [setTextVerticalType(byte value)](https://reference.aspose.com/slides/java/com.aspose.slides/textframeformat/#setTextVerticalType-byte-). 
7. Guarde la presentación modificada. 

Este código Java demuestra la operación.
```java
// Crea una instancia de la clase Presentation
Presentation pres = new Presentation();
try {
    // Supongamos que la primera forma en la primera diapositiva es una tabla
    ITable someTable = (ITable)pres.getSlides().get_Item(0).getShapes().get_Item(0); 
    
    // Establece la altura de fuente de las celdas de la primera fila
    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
	
    someTable.getRows().get_Item(0).setTextFormat(portionFormat);
    
    // Establece la alineación del texto y el margen derecho de las celdas de la primera fila
    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
	
    someTable.getRows().get_Item(0).setTextFormat(paragraphFormat);
    
    // Establece el tipo de texto vertical de las celdas de la segunda fila
    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
	
    someTable.getRows().get_Item(1).setTextFormat(textFrameFormat);

  // Guarda la presentación en disco
    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Establecer formato de texto a nivel de columna de tabla**

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) y cargue la presentación, 
2. Obtenga la referencia de una diapositiva mediante su índice. 
3. Acceda al objeto [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/ITable) relevante desde la diapositiva. 
4. Establezca la altura de fuente de las celdas de la primera columna mediante [setFontHeight(float value)](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/#setFontHeight-float-). 
5. Establezca la alineación de las celdas de la primera columna mediante [setAlignment(int value)](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) y el margen derecho mediante [setMarginRight(float value)](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setMarginRight-float-). 
6. Establezca el tipo de texto vertical de las celdas de la segunda columna mediante [setTextVerticalType(byte value)](https://reference.aspose.com/slides/java/com.aspose.slides/textframeformat/#setTextVerticalType-byte-). 
7. Guarde la presentación modificada. 

Este código Java demuestra la operación: 
```java
// Crea una instancia de la clase Presentation
Presentation pres = new Presentation();
try {
    // Supongamos que la primera forma en la primera diapositiva es una tabla
    ITable someTable = (ITable)pres.getSlides().get_Item(0).getShapes().get_Item(0)];

    // Establece la altura de fuente de las celdas de la primera columna
    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
	
    someTable.getColumns().get_Item(0).setTextFormat(portionFormat);

    // Establece la alineación del texto y el margen derecho de las celdas de la primera columna en una sola llamada
    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
	
    someTable.getColumns().get_Item(0).setTextFormat(paragraphFormat);

    // Establece el tipo de texto vertical de las celdas de la segunda columna
    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
	
    someTable.getColumns().get_Item(1).setTextFormat(textFrameFormat);

    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Obtener propiedades de estilo de tabla**

Aspose.Slides le permite recuperar las propiedades de estilo de una tabla para que pueda usar esos detalles en otra tabla o en otro lugar. Este código Java le muestra cómo obtener las propiedades de estilo de un estilo de tabla predefinido:
```java
Presentation pres = new Presentation();
try {
    ITable table = pres.getSlides().get_Item(0).getShapes().addTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.setStylePreset(TableStylePreset.DarkStyle1); // cambia el tema predeterminado del estilo preestablecido
    pres.save("table.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Preguntas frecuentes**

**¿Puedo aplicar temas/estilos de PowerPoint a una tabla que ya está creada?**

Sí. La tabla hereda el tema de la diapositiva/disposición/maestro, y aún puede sobrescribir los rellenos, bordes y colores de texto sobre ese tema.

**¿Puedo ordenar filas de tabla como en Excel?**

No, las tablas de Aspose.Slides no tienen ordenación ni filtros incorporados. Ordene sus datos en memoria primero, luego vuelva a rellenar las filas de la tabla en ese orden.

**¿Puedo tener columnas con bandas (rayas) manteniendo colores personalizados en celdas específicas?**

Sí. Active las columnas con bandas, luego sobrescriba celdas específicas con formato local; el formato a nivel de celda tiene prioridad sobre el estilo de tabla.