---
title: Administrar tablas de presentación en Java
linktitle: Administrar tabla
type: docs
weight: 10
url: /es/java/manage-table/
keywords:
- agregar tabla
- crear tabla
- acceder tabla
- relación de aspecto
- alinear texto
- formato de texto
- estilo de tabla
- PowerPoint
- presentación
- Java
- Aspose.Slides
description: "Crear y editar tablas en diapositivas de PowerPoint con Aspose.Slides para Java. Descubra ejemplos de código sencillos para optimizar su flujo de trabajo con tablas."
---

Una tabla en PowerPoint es una forma eficiente de mostrar y representar información. La información en una cuadrícula de celdas (dispuestas en filas y columnas) es directa y fácil de entender.

Aspose.Slides proporciona la clase [Table](https://reference.aspose.com/slides/java/com.aspose.slides/Table), la interfaz [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/ITable) , la clase [Cell](https://reference.aspose.com/slides/java/com.aspose.slides/cell/) , la interfaz [ICell](https://reference.aspose.com/slides/java/com.aspose.slides/icell/) y otros tipos para permitirle crear, actualizar y administrar tablas en todo tipo de presentaciones. 

## **Crear una tabla desde cero**

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Obtenga una referencia a la diapositiva a través de su índice. 
3. Defina una matriz de `columnWidth`.
4. Defina una matriz de `rowHeight`.
5. Agregue un objeto [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/ITable) a la diapositiva mediante el método [addTable](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-).
6. Itere a través de cada [ICell](https://reference.aspose.com/slides/java/com.aspose.slides/icell/) para aplicar formato a los bordes superior, inferior, derecho e izquierdo.
7. Fusionar las dos primeras celdas de la primera fila de la tabla. 
8. Acceda al [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe/) de un [ICell](https://reference.aspose.com/slides/java/com.aspose.slides/icell/). 
9. Agregue texto al [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe/).
10. Guarde la presentación modificada.

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

    // Sets the border format for each cell
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
    // Fusiona las celdas 1 y 2 de la fila 1
    tbl.mergeCells(tbl.getRows().get_Item(0).get_Item(0), tbl.getRows().get_Item(1).get_Item(1), false);

    // Agrega texto a la celda fusionada
    tbl.getRows().get_Item(0).get_Item(0).getTextFrame().setText("Merged Cells");

    // Guarda la presentación en disco
    pres.save("table.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Numeración en una tabla estándar**

En una tabla estándar, la numeración de las celdas es directa y comienza en cero. La primera celda de una tabla tiene el índice 0,0 (columna 0, fila 0). 

Por ejemplo, las celdas de una tabla con 4 columnas y 4 filas se numeran de la siguiente manera:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Este código Java le muestra cómo especificar la numeración de las celdas en una tabla:
```java
// Instancia una clase Presentation que representa un archivo PPTX
Presentation pres = new Presentation();
try {
    // Accede a la primera diapositiva
    ISlide sld = pres.getSlides().get_Item(0);

    // Define columnas con anchos y filas con alturas
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // Añade una forma de tabla a la diapositiva
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // Establece el formato de borde para cada celda
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

    // Guarda la presentación en disco
    pres.save("StandardTables_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Acceder a una tabla existente**

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).

2. Obtenga una referencia a la diapositiva que contiene la tabla a través de su índice. 

3. Cree un objeto [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/ITable) y establézcalo en null.

4. Itere a través de todos los objetos [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) hasta que se encuentre la tabla.

   Si sospecha que la diapositiva con la que está trabajando contiene una única tabla, puede simplemente verificar todas las formas que contiene. Cuando una forma se identifica como una tabla, puede convertirla a un objeto [Table](https://reference.aspose.com/slides/java/com.aspose.slides/Table). Pero si la diapositiva contiene varias tablas, es mejor buscar la tabla que necesita mediante su método [setAlternativeText(String value)](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#setAlternativeText-java.lang.String-).

5. Utilice el objeto [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/ITable) para trabajar con la tabla. En el ejemplo a continuación, agregamos una nueva fila a la tabla.

6. Guarde la presentación modificada.

```java
// Instancia la clase Presentation que representa un archivo PPTX
Presentation pres = new Presentation("UpdateExistingTable.pptx");
try {

    // Accede a la primera diapositiva
    ISlide sld = pres.getSlides().get_Item(0);

    // Inicializa la tabla nula
    ITable tbl = null;

    // Itera a través de las formas y establece una referencia a la tabla encontrada
    for (IShape shp : sld.getShapes()) 
    {
        if (shp instanceof ITable) 
        {
            tbl = (ITable) shp;
            // Establece el texto para la primera columna de la segunda fila
            tbl.get_Item(0, 1).getTextFrame().setText("New");
        }
    }
    
    // Guarda la presentación modificada en disco
    pres.save("table1_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Alinear texto en una tabla**

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Obtenga una referencia a la diapositiva a través de su índice. 
3. Agregue un objeto [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/ITable) a la diapositiva. 
4. Acceda a un objeto [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) de la tabla. 
5. Acceda al [IParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/) del [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/).
6. Alinee el texto verticalmente.
7. Guarde la presentación modificada.

```java
// Crea una instancia de la clase Presentation
Presentation pres = new Presentation();
try {
    // Obtiene la primera diapositiva
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Define columnas con anchos y filas con alturas
    double[] dblCols = { 120, 120, 120, 120 };
    double[] dblRows = { 100, 100, 100, 100 };
    
    // Añade la forma de tabla a la diapositiva
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
    portion.setText("Text here");
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    
    // Alinea el texto verticalmente
    ICell cell = tbl.get_Item(0, 0);
    cell.setTextAnchorType(TextAnchorType.Center);
    cell.setTextVerticalType(TextVerticalType.Vertical270);
    
    // Guarda la presentación en disco
    pres.save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Establecer formato de texto a nivel de tabla**

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Obtenga una referencia a la diapositiva a través de su índice. 
3. Acceda a un objeto [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/ITable) de la diapositiva.
4. Establezca [setFontHeight(float value)](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/#setFontHeight-float-) para el texto. 
5. Establezca [setAlignment(int value)](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) y [setMarginRight(float value)](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setMarginRight-float-). 
6. Establezca [setTextVerticalType(byte value)](https://reference.aspose.com/slides/java/com.aspose.slides/textframeformat/#setTextVerticalType-byte-).
7. Guarde la presentación modificada. 

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
    
    // Establece el tipo de orientación vertical del texto de las celdas de la tabla
    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
    someTable.setTextFormat(textFrameFormat);
    
    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Obtener propiedades de estilo de tabla**

Aspose.Slides le permite obtener las propiedades de estilo de una tabla para que pueda usar esos detalles en otra tabla o en otra parte. Este código Java le muestra cómo obtener las propiedades de estilo de un estilo predefinido de tabla:
```java
Presentation pres = new Presentation();
try {
    ITable table = pres.getSlides().get_Item(0).getShapes().addTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.setStylePreset(TableStylePreset.DarkStyle1); // cambia el tema predeterminado del preset de estilo
    pres.save("table.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Bloquear relación de aspecto de una tabla**

La relación de aspecto de una forma geométrica es la proporción de sus tamaños en diferentes dimensiones. Aspose.Slides proporciona la propiedad [**setAspectRatioLocked**](https://reference.aspose.com/slides/java/com.aspose.slides/GraphicalObjectLock#setAspectRatioLocked-boolean-) para permitirle bloquear la configuración de la relación de aspecto de tablas y otras formas. 

Este código Java le muestra cómo bloquear la relación de aspecto para una tabla:
```java
Presentation pres = new Presentation("pres.pptx");
try {
    ITable table = (ITable)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    System.out.println("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    table.getGraphicalObjectLock().setAspectRatioLocked(!table.getGraphicalObjectLock().getAspectRatioLocked()); // invertir

    System.out.println("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**¿Puedo habilitar la dirección de lectura de derecha a izquierda (RTL) para una tabla completa y el texto en sus celdas?**

Sí. La tabla expone un método [setRightToLeft](https://reference.aspose.com/slides/java/com.aspose.slides/table/#setRightToLeft-boolean-) y los párrafos tienen [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/java/com.aspose.slides/paragraphformat/#setRightToLeft-byte-). Usar ambos garantiza el orden RTL correcto y la renderización dentro de las celdas.

**¿Cómo puedo evitar que los usuarios muevan o cambien el tamaño de una tabla en el archivo final?**

Utilice [bloqueos de forma](/slides/es/java/applying-protection-to-presentation/) para desactivar el movimiento, el cambio de tamaño, la selección, etc. Estos bloqueos también se aplican a las tablas.

**¿Se admite insertar una imagen dentro de una celda como fondo?**

Sí. Puede establecer un [relleno de imagen](https://reference.aspose.com/slides/java/com.aspose.slides/picturefillformat/) para una celda; la imagen cubrirá el área de la celda según el modo elegido (estirar o mosaico).