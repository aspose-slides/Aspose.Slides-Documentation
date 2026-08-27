---
title: Gestionar tablas de presentación en Java
linktitle: Gestionar tabla
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
description: "Crear y editar tablas en diapositivas de PowerPoint con Aspose.Slides para Java. Descubra ejemplos de código simples para optimizar sus flujos de trabajo con tablas."
---
## **Introducción**

Una tabla en PowerPoint es una forma eficiente de mostrar y representar información. La información en una cuadrícula de celdas (dispuestas en filas y columnas) es directa y fácil de comprender.

Aspose.Slides proporciona la clase [Table](https://reference.aspose.com/slides/es/java/com.aspose.slides/Table), la interfaz [ITable](https://reference.aspose.com/slides/es/java/com.aspose.slides/ITable), la clase [Cell](https://reference.aspose.com/slides/es/java/com.aspose.slides/cell/) , la interfaz [ICell](https://reference.aspose.com/slides/es/java/com.aspose.slides/icell/) y otros tipos que le permiten crear, actualizar y gestionar tablas en todo tipo de presentaciones. 

## **Crear una tabla desde cero**

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/java/com.aspose.slides/Presentation).
2. Obtenga una referencia a la diapositiva mediante su índice. 
3. Defina una matriz de `columnWidth`.
4. Defina una matriz de `rowHeight`.
5. Añada un objeto [ITable](https://reference.aspose.com/slides/es/java/com.aspose.slides/ITable) a la diapositiva mediante el método [addTable](https://reference.aspose.com/slides/es/java/com.aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-).
6. Itere a través de cada [ICell](https://reference.aspose.com/slides/es/java/com.aspose.slides/icell/) para aplicar formato a los bordes superior, inferior, derecho e izquierdo.
7. Combine las dos primeras celdas de la primera fila de la tabla. 
8. Acceda al [TextFrame](https://reference.aspose.com/slides/es/java/com.aspose.slides/textframe/) de un [ICell](https://reference.aspose.com/slides/es/java/com.aspose.slides/icell/). 
9. Añada texto al [TextFrame](https://reference.aspose.com/slides/es/java/com.aspose.slides/textframe/).
10. Guarde la presentación modificada.

Este código Java le muestra cómo crear una tabla en una presentación:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Instancia una clase Presentation que representa un archivo PPTX
Presentation pres = new Presentation();
try {
    // Accede a la primera diapositiva
    ISlide sld = pres.getSlides().get_Item(0);

    // Define columnas con anchuras y filas con alturas
    double[] dblCols = {50, 50, 50};
    double[] dblRows = {50, 30, 30, 30, 30};

    // Añade una forma de tabla a la diapositiva
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // Establece el formato de borde para cada celda
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
    tbl.mergeCells(tbl.getRows().get_Item(0).get_Item(0), tbl.getRows().get_Item(0).get_Item(1), false);

    // Añade texto a la celda fusionada
    tbl.getRows().get_Item(0).get_Item(0).getTextFrame().setText("Merged Cells");

    // Guarda la presentación en disco
    pres.save("table.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Numeración en una tabla estándar**

En una tabla estándar, la numeración de las celdas es sencilla y comienza en cero. La primera celda de una tabla tiene el índice 0,0 (columna 0, fila 0). 

Por ejemplo, las celdas de una tabla con 4 columnas y 4 filas se numeran de la siguiente manera:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Este código Java le muestra cómo especificar la numeración de las celdas en una tabla:

```java
import com.aspose.slides.*;
import java.awt.Color;

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

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/java/com.aspose.slides/Presentation).

2. Obtenga una referencia a la diapositiva que contiene la tabla mediante su índice. 

3. Cree un objeto [ITable](https://reference.aspose.com/slides/es/java/com.aspose.slides/ITable) y establézcalo a null.

4. Itere a través de todos los objetos [IShape](https://reference.aspose.com/slides/es/java/com.aspose.slides/ishape/) hasta que se encuentre la tabla.

   Si sospecha que la diapositiva que está manejando contiene una única tabla, puede simplemente comprobar todas las formas que contiene. Cuando una forma se identifica como una tabla, puede convertirla a un objeto [Table](https://reference.aspose.com/slides/es/java/com.aspose.slides/Table). Pero si la diapositiva contiene varias tablas, será mejor buscar la tabla que necesita mediante su método [setAlternativeText(String value)](https://reference.aspose.com/slides/es/java/com.aspose.slides/ishape/#setAlternativeText-java.lang.String-).

5. Utilice el objeto [ITable](https://reference.aspose.com/slides/es/java/com.aspose.slides/ITable) para trabajar con la tabla. En el ejemplo siguiente, añadimos una nueva fila a la tabla.

6. Guarde la presentación modificada.

Este código Java le muestra cómo acceder y trabajar con una tabla existente:

```java
import com.aspose.slides.*;

// Instancia la clase Presentation que representa un archivo PPTX
Presentation pres = new Presentation("UpdateExistingTable.pptx");
try {

    // Accede a la primera diapositiva
    ISlide sld = pres.getSlides().get_Item(0);

    // Inicializa la tabla como null
    ITable tbl = null;

    // Recorre las formas y establece una referencia a la tabla encontrada
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

## **Encontrar la celda que posee un marco de texto**

Cuando un código genérico de procesamiento de texto recibe un [ITextFrame](https://reference.aspose.com/slides/es/java/com.aspose.slides/itextframe/) de una tabla, utilice el método [ITextFrame.getParentCell](https://reference.aspose.com/slides/es/java/com.aspose.slides/itextframe/#getParentCell--) para obtener la [ICell](https://reference.aspose.com/slides/es/java/com.aspose.slides/icell/) propietaria. Para un marco de texto de celda de tabla, [ITextFrame.getParentCell](https://reference.aspose.com/slides/es/java/com.aspose.slides/itextframe/#getParentCell--) devuelve el propietario y [ITextFrame.getParentShape](https://reference.aspose.com/slides/es/java/com.aspose.slides/itextframe/#getParentShape--) devuelve `null`, aunque la tabla en sí es una forma.

Las coordenadas de la celda están disponibles mediante los métodos de solo lectura [ICell.getFirstColumnIndex](https://reference.aspose.com/slides/es/java/com.aspose.slides/icell/#getFirstColumnIndex--) y [ICell.getFirstRowIndex](https://reference.aspose.com/slides/es/java/com.aspose.slides/icell/#getFirstRowIndex--). [ITextFrame.getParentCell](https://reference.aspose.com/slides/es/java/com.aspose.slides/itextframe/#getParentCell--) también ofrece navegación de solo lectura: devuelve el propietario pero no cambia la propiedad. Siempre compruebe que la celda devuelta no sea `null` antes de usarla.

Para obtener un ejemplo completo que identifica propietarios de celdas de tabla y de formas, incluidas las formas asociadas a nodos de SmartArt, consulte [Search and Replace Text](/slides/es/java/search-and-replace-text/).

## **Alinear texto en una tabla**

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/java/com.aspose.slides/Presentation).
2. Obtenga una referencia a la diapositiva mediante su índice. 
3. Añada un objeto [ITable](https://reference.aspose.com/slides/es/java/com.aspose.slides/ITable) a la diapositiva. 
4. Acceda a un objeto [ITextFrame](https://reference.aspose.com/slides/es/java/com.aspose.slides/itextframe/) de la tabla. 
5. Acceda al [IParagraph](https://reference.aspose.com/slides/es/java/com.aspose.slides/iparagraph/) del [ITextFrame](https://reference.aspose.com/slides/es/java/com.aspose.slides/itextframe/). 
6. Alinee el texto verticalmente.
7. Guarde la presentación modificada.

Este código Java le muestra cómo alinear el texto en una tabla:

```java
import com.aspose.slides.*;
import java.awt.Color;

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

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/java/com.aspose.slides/Presentation).
2. Obtenga una referencia a la diapositiva mediante su índice. 
3. Acceda a un objeto [ITable](https://reference.aspose.com/slides/es/java/com.aspose.slides/ITable) de la diapositiva.
4. Establezca [setFontHeight(float value)](https://reference.aspose.com/slides/es/java/com.aspose.slides/baseportionformat/#setFontHeight-float-) para el texto. 
5. Establezca [setAlignment(int value)](https://reference.aspose.com/slides/es/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) y [setMarginRight(float value)](https://reference.aspose.com/slides/es/java/com.aspose.slides/iparagraphformat/#setMarginRight-float-). 
6. Establezca [setTextVerticalType(byte value)](https://reference.aspose.com/slides/es/java/com.aspose.slides/textframeformat/#setTextVerticalType-byte-).
7. Guarde la presentación modificada. 

Este código Java le muestra cómo aplicar sus opciones de formato preferidas al texto de una tabla:

```java
import com.aspose.slides.*;

// Crea una instancia de la clase Presentation
Presentation pres = new Presentation("simpletable.pptx");
try {
    // Supongamos que la primera forma de la primera diapositiva es una tabla
    ITable someTable = (ITable) pres.getSlides().get_Item(0).getShapes().get_Item(0);
    
    // Establece la altura de fuente de las celdas de la tabla
    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
    someTable.setTextFormat(portionFormat);
    
    // Establece la alineación de texto y el margen derecho de las celdas de la tabla en una sola llamada
    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    someTable.setTextFormat(paragraphFormat);
    
    // Establece el tipo vertical de texto de las celdas de la tabla
    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
    someTable.setTextFormat(textFrameFormat);
    
    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Obtener propiedades de estilo de tabla**

Aspose.Slides le permite obtener las propiedades de estilo de una tabla para que pueda usar esos detalles en otra tabla o en otro lugar. Este código Java le muestra cómo obtener las propiedades de estilo de un estilo predefinido de tabla:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    ITable table = pres.getSlides().get_Item(0).getShapes().addTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.setStylePreset(TableStylePreset.DarkStyle1); // cambia el preset de estilo predeterminado

    // Obtiene el preset de estilo de la tabla
    int stylePreset = table.getStylePreset();
    System.out.println("Table style preset: " + stylePreset);

    // Aplica el preset de estilo obtenido a otra tabla
    ITable anotherTable = pres.getSlides().get_Item(0).getShapes().addTable(10, 100, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    anotherTable.setStylePreset(stylePreset);

    pres.save("table.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Bloquear la relación de aspecto de una tabla**

La relación de aspecto de una forma geométrica es la proporción de sus dimensiones. Aspose.Slides ofrece la propiedad [**setAspectRatioLocked**](https://reference.aspose.com/slides/es/java/com.aspose.slides/GraphicalObjectLock#setAspectRatioLocked-boolean-) para permitirle bloquear la configuración de la relación de aspecto de tablas y otras formas. 

Este código Java le muestra cómo bloquear la relación de aspecto de una tabla:

```java
import com.aspose.slides.*;

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

**¿Puedo habilitar la dirección de lectura de derecha a izquierda (RTL) para toda una tabla y el texto en sus celdas?**

Sí. La tabla expone el método [setRightToLeft](https://reference.aspose.com/slides/es/java/com.aspose.slides/table/#setRightToLeft-boolean-), y los párrafos tienen [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/es/java/com.aspose.slides/paragraphformat/#setRightToLeft-byte-). Usar ambos garantiza el orden y el renderizado correctos de RTL dentro de las celdas.

**¿Cómo puedo evitar que los usuarios muevan o cambien el tamaño de una tabla en el archivo final?**

Utilice [shape locks](/slides/es/java/applying-protection-to-presentation/) para desactivar el movimiento, el cambio de tamaño, la selección, etc. Estos bloqueos también se aplican a las tablas.

**¿Se admite la inserción de una imagen dentro de una celda como fondo?**

Sí. Puede establecer un [picture fill](https://reference.aspose.com/slides/es/java/com.aspose.slides/picturefillformat/) para una celda; la imagen cubrirá el área de la celda según el modo seleccionado (estirar o mosaico).