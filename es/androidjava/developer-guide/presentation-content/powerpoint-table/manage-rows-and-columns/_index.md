---
title: Administrar Filas y Columnas
type: docs
weight: 20
url: /es/androidjava/manage-rows-and-columns/
keywords: "Tabla, filas y columnas de tabla, presentación de PowerPoint, Java, Aspose.Slides para Android a través de Java"
description: "Administra filas y columnas de tablas en presentaciones de PowerPoint en Java"
---

Para permitirte administrar las filas y columnas de una tabla en una presentación de PowerPoint, Aspose.Slides proporciona la clase [Table](https://reference.aspose.com/slides/androidjava/com.aspose.slides/table/), la interfaz [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITable) y muchos otros tipos.

## **Establecer la Primera Fila como Encabezado**

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) y carga la presentación.
2. Obtén la referencia de una diapositiva a través de su índice.
3. Crea un objeto [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITable) y configúralo como nulo.
4. Itera a través de todos los objetos [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) para encontrar la tabla correspondiente.
5. Establece la primera fila de la tabla como su encabezado.

Este código Java te muestra cómo establecer la primera fila de una tabla como su encabezado:

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
            
            //Establece la primera fila de una tabla como su encabezado
            tbl.setFirstRow(true);
        }
    }
    
    // Guarda la presentación en el disco
    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Clonar Fila o Columna de la Tabla**

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) y carga la presentación,
2. Obtén la referencia de una diapositiva a través de su índice.
3. Define un arreglo de `columnWidth`.
4. Define un arreglo de `rowHeight`.
5. Agrega un objeto [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITable) a la diapositiva a través del método [addTable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---).
6. Clona la fila de la tabla.
7. Clona la columna de la tabla.
8. Guarda la presentación modificada.

Este código Java te muestra cómo clonar una fila o columna de una tabla de PowerPoint:

```java
 // Instancia la clase Presentation
Presentation pres = new Presentation("Test.pptx");
try {
    // Accede a la primera diapositiva
    ISlide sld = pres.getSlides().get_Item(0);

    // Define las columnas con anchos y las filas con alturas
    double[] dblCols = { 50, 50, 50 };
    double[] dblRows = { 50, 30, 30, 30, 30 };

    // Agrega una forma de tabla a la diapositiva
    ITable table = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // Agrega algo de texto a la celda 1 de la fila 1
    table.get_Item(0, 0).getTextFrame().setText("Celda 1 Fila 1");

    // Agrega algo de texto a la celda 2 de la fila 1
    table.get_Item(1, 0).getTextFrame().setText("Celda 2 Fila 1");

    // Clona la Fila 1 al final de la tabla
    table.getRows().addClone(table.getRows().get_Item(0), false);

    // Agrega algo de texto a la celda 1 de la fila 2
    table.get_Item(0, 1).getTextFrame().setText("Celda 1 Fila 2");

    // Agrega algo de texto a la celda 2 de la fila 2
    table.get_Item(1, 1).getTextFrame().setText("Celda 2 Fila 2");

    // Clona la Fila 2 como la 4ta fila de la tabla
    table.getRows().insertClone(3, table.getRows().get_Item(1), false);

    // Clona la primera columna al final
    table.getColumns().addClone(table.getColumns().get_Item(0), false);

    // Clona la 2da columna en el índice de la 4ta columna
    table.getColumns().insertClone(3,table.getColumns().get_Item(1), false);
    
    // Guarda la presentación en el disco
    pres.save("table_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Eliminar Fila o Columna de la Tabla**

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) y carga la presentación,
2. Obtén la referencia de una diapositiva a través de su índice.
3. Define un arreglo de `columnWidth`.
4. Define un arreglo de `rowHeight`.
5. Agrega un objeto [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITable) a la diapositiva a través del método [addTable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---).
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

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) y carga la presentación,
2. Obtén la referencia de una diapositiva a través de su índice.
3. Accede al objeto [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITable) relevante de la diapositiva.
4. Establece el [setFontHeight(float value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-) de las celdas de la primera fila.
5. Establece la [setAlignment(int value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) y [setMarginRight(float value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setMarginRight-float-) de las celdas de la primera fila.
6. Establece el [setTextVerticalType(byte value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframeformat/#setTextVerticalType-byte-) de las celdas de la segunda fila.
7. Guarda la presentación modificada.

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
    
    // Establece el tipo vertical de texto de las celdas de la segunda fila
    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
	
    someTable.getRows().get_Item(1).setTextFormat(textFrameFormat);

    // Guarda la presentación en el disco
    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Establecer Formato de Texto a Nivel de Columna de Tabla**

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) y carga la presentación,
2. Obtén la referencia de una diapositiva a través de su índice.
3. Accede al objeto [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITable) relevante de la diapositiva.
4. Establece el [setFontHeight(float value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-) de las celdas de la primera columna.
5. Establece la [setAlignment(int value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) y [setMarginRight(float value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setMarginRight-float-) de las celdas de la primera columna.
6. Establece el [setTextVerticalType(byte value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframeformat/#setTextVerticalType-byte-) de las celdas de la segunda columna.
7. Guarda la presentación modificada.

Este código Java demuestra la operación:

```java
// Crea una instancia de la clase Presentation
Presentation pres = new Presentation();
try {
    // Supongamos que la primera forma en la primera diapositiva es una tabla
    ITable someTable = (ITable)pres.getSlides().get_Item(0).getShapes().get_Item(0);

    // Establece la altura de fuente de las celdas de la primera columna
    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
	
    someTable.getColumns().get_Item(0).setTextFormat(portionFormat);

    // Establece la alineación del texto y el margen derecho de las celdas de la primera columna en una sola llamada
    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
	
    someTable.getColumns().get_Item(0).setTextFormat(paragraphFormat);

    // Establece el tipo vertical de texto de las celdas de la segunda columna
    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
	
    someTable.getColumns().get_Item(1).setTextFormat(textFrameFormat);

    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Obtener Propiedades de Estilo de la Tabla**

Aspose.Slides te permite recuperar las propiedades de estilo para una tabla para que puedas usar esos detalles para otra tabla o en otro lugar. Este código Java te muestra cómo obtener las propiedades de estilo de un estilo preset de tabla:

```java
Presentation pres = new Presentation();
try {
    ITable table = pres.getSlides().get_Item(0).getShapes().addTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.setStylePreset(TableStylePreset.DarkStyle1); // cambia el tema de estilo preset por defecto
    pres.save("table.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```