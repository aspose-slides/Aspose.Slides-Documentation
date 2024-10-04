---
title: Administrar Tabla
type: docs
weight: 10
url: /androidjava/manage-table/
keywords: "Tabla, crear tabla, acceder a la tabla, relación de aspecto de la tabla, presentación de PowerPoint, Java, Aspose.Slides para Android a través de Java"
description: "Crear y gestionar tablas en presentaciones de PowerPoint en Java"
---

Una tabla en PowerPoint es una manera eficiente de mostrar y retratar información. La información en una cuadrícula de celdas (organizadas en filas y columnas) es directa y fácil de entender.

Aspose.Slides proporciona la clase [Table](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Table), la interfaz [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITable), la clase [Cell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cell/), la interfaz [ICell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/) y otros tipos para permitirte crear, actualizar y gestionar tablas en todo tipo de presentaciones.

## **Crear Tabla desde Cero**

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Obtén la referencia de una diapositiva a través de su índice. 
3. Define un arreglo de `columnWidth`.
4. Define un arreglo de `rowHeight`.
5. Agrega un objeto [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITable) a la diapositiva a través del método [addTable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-).
6. Itera a través de cada [ICell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/) para aplicar formato a los bordes superior, inferior, derecho e izquierdo.
7. Une las dos primeras celdas de la primera fila de la tabla. 
8. Accede al [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe/) de un [ICell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/).
9. Agrega algo de texto al [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe/).
10. Guarda la presentación modificada.

Este código Java te muestra cómo crear una tabla en una presentación:

```java
// Instancia una clase Presentation que representa un archivo PPTX
Presentation pres = new Presentation();
try {
    // Accede a la primera diapositiva
    ISlide sld = pres.getSlides().get_Item(0);

    // Define columnas con anchos y filas con alturas
    double[] dblCols = {50, 50, 50};
    double[] dblRows = {50, 30, 30, 30, 30};

    // Agrega una forma de tabla a la diapositiva
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // Establece el formato del borde para cada celda
    for (int row = 0; row < tbl.getRows().size(); row++)
    {
        for (int cell = 0; cell < tbl.getRows().get_Item(row).size(); cell++)
        {
            ICellFormat cellFormat = tbl.getRows().get_Item(row).get_Item(cell).getCellFormat();
            
            cellFormat.getBorderTop().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderTop().setWidth(5);

            cellFormat.getBorderBottom().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderBottom().setWidth(5);

            cellFormat.getBorderLeft().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderLeft().setWidth(5);

            cellFormat.getBorderRight().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderRight().setWidth(5);
        }
    }
    // Une las celdas 1 y 2 de la fila 1
    tbl.mergeCells(tbl.getRows().get_Item(0).get_Item(0), tbl.getRows().get_Item(1).get_Item(1), false);

    // Agrega algún texto a la celda unida
    tbl.getRows().get_Item(0).get_Item(0).getTextFrame().setText("Celdas Unidas");

    // Guarda la presentación en el disco
    pres.save("table.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Numeración en Tabla Estándar**

En una tabla estándar, la numeración de las celdas es sencilla y basada en cero. La primera celda en una tabla se indexa como 0,0 (columna 0, fila 0). 

Por ejemplo, las celdas en una tabla con 4 columnas y 4 filas se numeran de esta manera:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Este código Java te muestra cómo especificar la numeración para celdas en una tabla:

```java
// Instancia una clase Presentation que representa un archivo PPTX
Presentation pres = new Presentation();
try {
    // Accede a la primera diapositiva
    ISlide sld = pres.getSlides().get_Item(0);

    // Define columnas con anchos y filas con alturas
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // Agrega una forma de tabla a la diapositiva
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // Establece el formato del borde para cada celda
    for (IRow row : tbl.getRows())
    {
        for (ICell cell : row)
        {
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderTop().setWidth(5);

            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderBottom().setWidth(5);

            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderLeft().setWidth(5);

            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderRight().setWidth(5);
        }
    }

    // Guarda la presentación en el disco
    pres.save("StandardTables_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Acceder a Tabla Existente**

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).

2. Obtén una referencia a la diapositiva que contiene la tabla a través de su índice. 

3. Crea un objeto [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITable) y configúralo en null.

4. Itera a través de todos los objetos [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) hasta que se encuentre la tabla.

   Si sospechas que la diapositiva con la que estás tratando contiene una única tabla, puedes simplemente verificar todas las formas que contiene. Cuando una forma se identifica como una tabla, puedes convertirla en un objeto [Table](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Table). Pero si la diapositiva que estás tratando contiene varias tablas, entonces es mejor buscar la tabla que necesitas a través de su [setAlternativeText(String value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#setAlternativeText-java.lang.String-).

5. Usa el objeto [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITable) para trabajar con la tabla. En el siguiente ejemplo, agregamos una nueva fila a la tabla.

6. Guarda la presentación modificada.

Este código Java te muestra cómo acceder y trabajar con una tabla existente:

```java
// Instancia la clase Presentation que representa un archivo PPTX
Presentation pres = new Presentation("UpdateExistingTable.pptx");
try {

    // Accede a la primera diapositiva
    ISlide sld = pres.getSlides().get_Item(0);

    // Inicializa la TablaEx como null
    ITable tbl = null;

    // Itera a través de las formas y establece una referencia a la tabla encontrada
    for (IShape shp : sld.getShapes()) 
    {
        if (shp instanceof ITable) 
        {
            tbl = (ITable) shp;
            // Establece el texto para la primera columna de la segunda fila
            tbl.get_Item(0, 1).getTextFrame().setText("Nuevo");
        }
    }
    
    // Guarda la presentación modificada en el disco
    pres.save("table1_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Alinear Texto en Tabla**

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Obtén la referencia de una diapositiva a través de su índice. 
3. Agrega un objeto [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITable) a la diapositiva.
4. Accede a un objeto [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) de la tabla.
5. Accede al [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) [IParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/).
6. Alinea el texto verticalmente.
7. Guarda la presentación modificada.

Este código Java te muestra cómo alinear el texto en una tabla:

```java
// Crea una instancia de la clase Presentation
Presentation pres = new Presentation();
try {
    // Obtiene la primera diapositiva 
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Define columnas con anchos y filas con alturas
    double[] dblCols = { 120, 120, 120, 120 };
    double[] dblRows = { 100, 100, 100, 100 };
    
    // Agrega la forma de tabla a la diapositiva
    ITable tbl = slide.getShapes().addTable(100, 50, dblCols, dblRows);
    tbl.get_Item(1, 0).getTextFrame().setText("10");
    tbl.get_Item(2, 0).getTextFrame().setText("20");
    tbl.get_Item(3, 0).getTextFrame().setText("30");
    
    // Accede al marco de texto
    ITextFrame txtFrame = tbl.get_Item(0, 0).getTextFrame();
    
    // Crea el objeto Paragraph para el marco de texto
    IParagraph paragraph = txtFrame.getParagraphs().get_Item(0);
    
    // Crea el objeto Portion para el párrafo
    IPortion portion = paragraph.getPortions().get_Item(0);
    portion.setText("Texto aquí");
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    
    // Alinea el texto verticalmente
    ICell cell = tbl.get_Item(0, 0);
    cell.setTextAnchorType(TextAnchorType.Center);
    cell.setTextVerticalType(TextVerticalType.Vertical270);
    
    // Guarda la presentación en el disco
    pres.save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Establecer Formato de Texto a Nivel de Tabla**

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Obtén la referencia de una diapositiva a través de su índice. 
3. Accede a un objeto [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITable) de la diapositiva.
4. Establece el [setFontHeight(float value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-) para el texto.
5. Establece el [setAlignment(int value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) y [setMarginRight(float value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setMarginRight-float-).
6. Establece el [setTextVerticalType(byte value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframeformat/#setTextVerticalType-byte-).
7. Guarda la presentación modificada. 

Este código Java te muestra cómo aplicar tus opciones de formato preferidas al texto en una tabla:

```java
// Crea una instancia de la clase Presentation
Presentation pres = new Presentation("simpletable.pptx");
try {
    // Supongamos que la primera forma en la primera diapositiva es una tabla
    ITable someTable = (ITable) pres.getSlides().get_Item(0).getShapes().get_Item(0);
    
    // Establece la altura de fuente de las celdas de la tabla
    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
    someTable.setTextFormat(portionFormat);
    
    // Establece la alineación del texto de las celdas de la tabla y el margen derecho en una sola llamada
    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    someTable.setTextFormat(paragraphFormat);
    
    // Establece el tipo de texto vertical de las celdas de la tabla
    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
    someTable.setTextFormat(textFrameFormat);
    
    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Obtener Propiedades de Estilo de la Tabla**

Aspose.Slides te permite recuperar las propiedades de estilo de una tabla para que puedas usar esos detalles para otra tabla o en otro lugar. Este código Java te muestra cómo obtener las propiedades de estilo de un estilo de tabla preestablecido:

```java
Presentation pres = new Presentation();
try {
    ITable table = pres.getSlides().get_Item(0).getShapes().addTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.setStylePreset(TableStylePreset.DarkStyle1); // cambia el estilo preestablecido por defecto 
    pres.save("table.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Bloquear Relación de Aspecto de la Tabla**

La relación de aspecto de una forma geométrica es la relación de sus tamaños en diferentes dimensiones. Aspose.Slides proporciona la propiedad [**setAspectRatioLocked**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GraphicalObjectLock#setAspectRatioLocked-boolean-) para permitirte bloquear la configuración de relación de aspecto para tablas y otras formas.

Este código Java te muestra cómo bloquear la relación de aspecto para una tabla:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    ITable table = (ITable)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    System.out.println("Bloquear relación de aspecto establecido: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    table.getGraphicalObjectLock().setAspectRatioLocked(!table.getGraphicalObjectLock().getAspectRatioLocked()); // invertir

    System.out.println("Bloquear relación de aspecto establecido: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```