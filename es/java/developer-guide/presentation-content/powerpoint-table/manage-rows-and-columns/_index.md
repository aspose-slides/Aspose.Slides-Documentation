---
title: Gestionar Filas y Columnas
type: docs
weight: 20
url: /es/java/manage-rows-and-columns/
keywords: "Tabla, filas y columnas de la tabla, presentación de PowerPoint, Java, Aspose.Slides para Java"
description: "Gestionar filas y columnas de tablas en presentaciones de PowerPoint en Java"
---

Para permitirte gestionar las filas y columnas de una tabla en una presentación de PowerPoint, Aspose.Slides proporciona la clase [Table](https://reference.aspose.com/slides/java/com.aspose.slides/table/), la interfaz [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/ITable) y muchos otros tipos. 

## **Establecer la Primera Fila como Encabezado**

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) y carga la presentación. 
2. Obtén la referencia de una diapositiva a través de su índice. 
3. Crea un objeto [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/ITable) y configúralo como nulo.
4. Itera a través de todos los objetos [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) para encontrar la tabla relevante. 
5. Establece la primera fila de la tabla como su encabezado. 

Este código Java te muestra cómo establecer la primera fila de una tabla como su encabezado:

```java
// Instantiates the Presentation class
Presentation pres = new Presentation("table.pptx");
try {
    // Accesses the first slide
    ISlide sld = pres.getSlides().get_Item(0);

    // Initializes the null TableEx
    ITable tbl = null;

    // Iterates through the shapes and sets a reference to the table
    for (IShape shp : sld.getShapes())
    {
        if (shp instanceof ITable) 
        {
            tbl = (ITable)shp;
            
            //Sets the first row of a table as its header
            tbl.setFirstRow(true);
        }
    }
    
    // Saves the presentation to disk
    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Clonar Fila o Columna de la Tabla**

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) y carga la presentación. 
2. Obtén la referencia de una diapositiva a través de su índice. 
3. Define un arreglo de `columnWidth`.
4. Define un arreglo de `rowHeight`.
5. Agrega un objeto [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/ITable) a la diapositiva a través del método [addTable](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---).
6. Clona la fila de la tabla.
7. Clona la columna de la tabla.
8. Guarda la presentación modificada.

Este código Java te muestra cómo clonar una fila o columna de una tabla de PowerPoint:

```java
 // Instantiates the Presentation class
Presentation pres = new Presentation("Test.pptx");
try {
    // Accesses the first slide
    ISlide sld = pres.getSlides().get_Item(0);

    // Defines columns with widths and rows with heights
    double[] dblCols = { 50, 50, 50 };
    double[] dblRows = { 50, 30, 30, 30, 30 };

    // Adds a table shape to slide
    ITable table = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // Adds some text to the row 1 cell 1
    table.get_Item(0, 0).getTextFrame().setText("Celda 1 Fila 1");

    // Adds some text to the row 1 cell 2
    table.get_Item(1, 0).getTextFrame().setText("Celda 2 Fila 1");

    // Clones Row 1 at end of table
    table.getRows().addClone(table.getRows().get_Item(0), false);

    // Adds some text to the row 2 cell 1
    table.get_Item(0, 1).getTextFrame().setText("Celda 1 Fila 2");

    // Adds some text to the row 2 cell 2
    table.get_Item(1, 1).getTextFrame().setText("Celda 2 Fila 2");

    // Clones Row 2 as 4th row of table
    table.getRows().insertClone(3, table.getRows().get_Item(1), false);

    // Clones first column at the end
    table.getColumns().addClone(table.getColumns().get_Item(0), false);

    // Clones 2nd column at 4th column index
    table.getColumns().insertClone(3,table.getColumns().get_Item(1), false);
    
    // Saves the presentation to disk
    pres.save("table_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Eliminar Fila o Columna de la Tabla**

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) y carga la presentación. 
2. Obtén la referencia de una diapositiva a través de su índice. 
3. Define un arreglo de `columnWidth`.
4. Define un arreglo de `rowHeight`.
5. Agrega un objeto [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/ITable) a la diapositiva a través del método [addTable](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---).
6. Elimina la fila de la tabla.
7. Elimina la columna de la tabla.
8. Guarda la presentación modificada. 

Este código Java te muestra cómo eliminar una fila o columna de una tabla:

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

## **Establecer Formato de Texto a Nivel de Fila de Tabla**

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) y carga la presentación. 
2. Obtén la referencia de una diapositiva a través de su índice. 
3. Accede al objeto [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/ITable) relevante de la diapositiva. 
4. Establece la altura de fuente de las celdas de la primera fila [setFontHeight(float value)](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/#setFontHeight-float-). 
5. Establece la alineación y el margen derecho de las celdas de la primera fila [setAlignment(int value)](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) y [setMarginRight(float value)](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setMarginRight-float-). 
6. Establece el tipo de texto vertical de las celdas de la segunda fila [setTextVerticalType(byte value)](https://reference.aspose.com/slides/java/com.aspose.slides/textframeformat/#setTextVerticalType-byte-).
7. Guarda la presentación modificada.

Este código Java demuestra la operación.

```java
// Creates an instance of the Presentation class
Presentation pres = new Presentation();
try {
    // Let's assume that the first shape on the first slide is a table
    ITable someTable = (ITable)pres.getSlides().get_Item(0).getShapes().get_Item(0); 
    
    // Sets first row cells' font height
    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
	
    someTable.getRows().get_Item(0).setTextFormat(portionFormat);
    
    // Sets the first row cells' text alignment and right margin
    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
	
    someTable.getRows().get_Item(0).setTextFormat(paragraphFormat);
    
    // Sets the second row cells' text vertical type
    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
	
    someTable.getRows().get_Item(1).setTextFormat(textFrameFormat);

  // Saves the presentation to disk
    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Establecer Formato de Texto a Nivel de Columna de Tabla**

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) y carga la presentación. 
2. Obtén la referencia de una diapositiva a través de su índice. 
3. Accede al objeto [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/ITable) relevante de la diapositiva. 
4. Establece la altura de fuente de las celdas de la primera columna [setFontHeight(float value)](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/#setFontHeight-float-).
5. Establece la alineación y el margen derecho de las celdas de la primera columna [setAlignment(int value)](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) y [setMarginRight(float value)](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setMarginRight-float-). 
6. Establece el tipo de texto vertical de las celdas de la segunda columna [setTextVerticalType(byte value)](https://reference.aspose.com/slides/java/com.aspose.slides/textframeformat/#setTextVerticalType-byte-).
7. Guarda la presentación modificada. 

Este código Java demuestra la operación: 

```java
// Creates an instance of the Presentation class
Presentation pres = new Presentation();
try {
    // Let's assume that the first shape on the first slide is a table
    ITable someTable = (ITable)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    
    // Sets the first column cells' font height
    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
	
    someTable.getColumns().get_Item(0).setTextFormat(portionFormat);

    // Sets the first column cells' text alignment and right margin in one call
    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
	
    someTable.getColumns().get_Item(0).setTextFormat(paragraphFormat);

    // Sets the second column cells' text vertical type
    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
	
    someTable.getColumns().get_Item(1).setTextFormat(textFrameFormat);

    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Obtener Propiedades de Estilo de la Tabla**

Aspose.Slides te permite recuperar las propiedades de estilo para una tabla para que puedas usar esos detalles en otra tabla o en otro lugar. Este código Java te muestra cómo obtener las propiedades de estilo de un estilo de tabla preestablecido:

```java
Presentation pres = new Presentation();
try {
    ITable table = pres.getSlides().get_Item(0).getShapes().addTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.setStylePreset(TableStylePreset.DarkStyle1); // change the default style preset theme
    pres.save("table.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```