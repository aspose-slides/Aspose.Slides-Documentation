---
title: Gestionar tablas de presentación en Java
linktitle: Gestionar tabla
type: docs
weight: 10
url: /es/java/manage-table/
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
- Java
- Aspose.Slides
description: "Crear y editar tablas en diapositivas de PowerPoint con Aspose.Slides para Java. Descubre ejemplos de código simples para optimizar tus flujos de trabajo con tablas."
---
## **Introducción**

Las tablas en PowerPoint organizan la información en filas y columnas, facilitando su lectura y la comparación de valores.

Aspose.Slides proporciona la clase [Table](https://reference.aspose.com/slides/java/com.aspose.slides/table/) , la interfaz [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/itable/) , la clase [Cell](https://reference.aspose.com/slides/java/com.aspose.slides/cell/) , la interfaz [ICell](https://reference.aspose.com/slides/java/com.aspose.slides/icell/) y otros tipos que le permiten crear, actualizar y gestionar tablas en presentaciones.

## **Crear una tabla desde cero**

Cree una tabla especificando su posición, los anchos de columna y las alturas de fila. Después de añadirla a una diapositiva, puede dar formato a los bordes de las celdas, fusionar celdas e insertar texto.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) .
2. Obtenga una referencia a la diapositiva por su índice.
3. Defina una matriz de anchos de columna en puntos.
4. Defina una matriz de alturas de fila en puntos.
5. Añada un objeto [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/itable/) a la diapositiva mediante el método [addTable](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---) .
6. Itere a través de cada [ICell](https://reference.aspose.com/slides/java/com.aspose.slides/icell/) para aplicar formato a los bordes superior, inferior, derecho e izquierdo.
7. Fusiona las dos primeras celdas de la primera fila de la tabla.
8. Acceda a la celda fusionada mediante su método [getTextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getTextFrame--) .
9. Establezca el texto en la celda fusionada.
10. Guarde la presentación modificada.

El siguiente ejemplo crea una tabla con tres columnas y cinco filas en (100, 50) puntos. Aplica bordes rojos con un ancho de 5 puntos, fusiona las dos primeras celdas de la primera fila y guarda el resultado como `table.pptx`.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 50, 50, 50 };
    double[] rowHeights = { 50, 30, 30, 30, 30 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    for (IRow row : table.getRows())
    {
        for (ICell cell : row)
        {
            ICellFormat cellFormat = cell.getCellFormat();
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

    table.mergeCells(table.get_Item(0, 0), table.get_Item(1, 0), false);
    table.get_Item(0, 0).getTextFrame().setText("Merged Cells");

    presentation.save("table.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Numeración en una tabla estándar**

En una tabla estándar, los índices de las celdas comienzan en cero y siguen el orden (columna, fila). La primera celda tiene el índice (0, 0).

Por ejemplo, las celdas de una tabla con 4 columnas y 4 filas se numeran de esta forma:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Este ejemplo crea la tabla 4 × 4 ilustrada arriba, con anchos de columna y alturas de fila de 70 puntos y bordes de celda rojos con un ancho de 5 puntos. Las coordenadas ilustran los índices de las celdas; el ejemplo deja las celdas vacías y guarda la tabla como `StandardTables_out.pptx`.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 70, 70, 70, 70 };
    double[] rowHeights = { 70, 70, 70, 70 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    for (IRow row : table.getRows())
    {
        for (ICell cell : row)
        {
            ICellFormat cellFormat = cell.getCellFormat();
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

    presentation.save("StandardTables_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Acceder a una tabla existente**

Las tablas se almacenan en la colección de formas de una diapositiva. Recorra las formas para localizar una tabla y, a continuación, utilice la interfaz [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/itable/) para leer o actualizar sus celdas.

1. Cargue la presentación usando la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) .
2. Obtenga una referencia a la diapositiva que contiene la tabla por su índice.
3. Itere a través de los objetos [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) y deténgase cuando se encuentre una tabla. Si la diapositiva contiene varias tablas, use [getAlternativeText](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getAlternativeText--) para identificar la que necesita.
4. Actualice el texto en la celda objetivo.
5. Guarde la presentación modificada.

El siguiente ejemplo abre `UpdateExistingTable.pptx` y encuentra la primera tabla en la primera diapositiva. Establece la celda en la columna 0, fila 1 a `New` y guarda el resultado como `table1_out.pptx`. La entrada debe contener al menos una diapositiva, y la primera tabla de esa diapositiva debe tener al menos una columna y dos filas.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("UpdateExistingTable.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = null;

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof ITable) {
            table = (ITable) shape;
            break;
        }
    }

    if (table != null) {
        table.get_Item(0, 1).getTextFrame().setText("New");
        presentation.save("table1_out.pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Para cambiar el tamaño de una fila en una tabla existente y comprender por qué su altura real puede superar el mínimo solicitado, consulte [Control Row Height](/slides/es/java/manage-rows-and-columns/#control-row-height).

## **Encontrar la celda que posee un marco de texto**

Cuando el código genérico de procesamiento de texto recibe un [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) de una tabla, use el método [ITextFrame.getParentCell](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/#getParentCell--) para obtener la [ICell](https://reference.aspose.com/slides/java/com.aspose.slides/icell/) propietaria. Para un marco de texto de una celda de tabla, [ITextFrame.getParentCell](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/#getParentCell--) devuelve al propietario y [ITextFrame.getParentShape](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/#getParentShape--) devuelve `null`, aunque la tabla en sí es una forma.

Las coordenadas de la celda están disponibles a través de los métodos de solo lectura [ICell.getFirstColumnIndex](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getFirstColumnIndex--) y [ICell.getFirstRowIndex](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getFirstRowIndex--) . [ITextFrame.getParentCell](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/#getParentCell--) también proporciona navegación de solo lectura: devuelve al propietario pero no cambia la propiedad. Siempre verifique que la celda devuelta no sea `null` antes de usarla.

Para un ejemplo completo que identifica propietarios de celdas de tabla y de formas, incluidas las formas asociadas a nodos de SmartArt, consulte [Search and Replace Text](/slides/es/java/search-and-replace-text/) .

## **Alinear texto en una tabla**

Puede controlar el anclaje vertical y la dirección del texto de celdas de tabla individuales. El ejemplo en esta sección centra el texto dentro de la primera celda y lo rota 270 grados.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) .
2. Obtenga una referencia a la diapositiva por su índice.
3. Añada un objeto [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/itable/) a la diapositiva.
4. Acceda a un objeto [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) de la tabla.
5. Acceda al primer [IParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/) y establezca su texto y color.
6. Establezca el anclaje vertical de la celda y la dirección del texto usando [setTextAnchorType](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#setTextAnchorType-byte-) y [setTextVerticalType](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#setTextVerticalType-byte-) .
7. Guarde la presentación modificada.

Este ejemplo crea una tabla 4 × 4 con anchos de columna de 120 puntos y alturas de fila de 100 puntos. Da formato al texto en la celda (0, 0), añade valores a las celdas restantes de la primera fila y guarda el resultado como `Vertical_Align_Text_out.pptx`.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 120, 120, 120, 120 };
    double[] rowHeights = { 100, 100, 100, 100 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.get_Item(1, 0).getTextFrame().setText("10");
    table.get_Item(2, 0).getTextFrame().setText("20");
    table.get_Item(3, 0).getTextFrame().setText("30");

    ITextFrame textFrame = table.get_Item(0, 0).getTextFrame();
    IParagraph paragraph = textFrame.getParagraphs().get_Item(0);

    IPortion portion = paragraph.getPortions().get_Item(0);
    portion.setText("Text here");
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    ICell cell = table.get_Item(0, 0);
    cell.setTextAnchorType(TextAnchorType.Center);
    cell.setTextVerticalType(TextVerticalType.Vertical270);

    presentation.save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Establecer formato de texto a nivel de tabla**

Utilice [setTextFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ibulktextformattable/#setTextFormat-com.aspose.slides.IPortionFormat-) para aplicar formato de texto a todas las celdas de una tabla. Sus sobrecargas aceptan formato de porción, párrafo y marco de texto, por lo que puede establecer estas propiedades sin iterar por celdas individuales.

1. Cargue la presentación usando la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) .
2. Obtenga una referencia a la diapositiva por su índice.
3. Acceda a un objeto [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/itable/) de la diapositiva.
4. Establezca el tamaño de fuente usando [setFontHeight](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/#setFontHeight-float-) para el texto.
5. Establezca la alineación del párrafo y el margen derecho usando [setAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) y [setMarginRight](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setMarginRight-float-) .
6. Establezca la dirección del texto usando [setTextVerticalType](https://reference.aspose.com/slides/java/com.aspose.slides/textframeformat/#setTextVerticalType-byte-) .
7. Guarde la presentación modificada.

El siguiente ejemplo abre `table.pptx`, que debe contener al menos una diapositiva con una tabla como su primera forma. Establece el tamaño de fuente a 25 puntos, alinea a la derecha los párrafos con un margen derecho de 20 puntos y hace el texto vertical. La presentación formateada se guarda como `result.pptx`.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("table.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = (ITable) slide.getShapes().get_Item(0);

    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
    table.setTextFormat(portionFormat);

    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    table.setTextFormat(paragraphFormat);

    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
    table.setTextFormat(textFrameFormat);

    presentation.save("result.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Obtener propiedades de estilo de tabla**

Utilice [getStylePreset](https://reference.aspose.com/slides/java/com.aspose.slides/itable/#getStylePreset--) para leer el estilo predefinido de una tabla y [setStylePreset](https://reference.aspose.com/slides/java/com.aspose.slides/itable/#setStylePreset-int-) para asignarlo. Este ejemplo aplica [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/java/com.aspose.slides/tablestylepreset/) a una tabla, muestra el valor predefinido y asigna el mismo predefinido a una segunda tabla. Ambas tablas se guardan en `table-style.pptx`.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 100, 150 };
    double[] rowHeights = { 5, 5, 5 };
    ITable table = slide.getShapes().addTable(10, 10, columnWidths, rowHeights);
    table.setStylePreset(TableStylePreset.DarkStyle1);

    int stylePreset = table.getStylePreset();
    System.out.println("Table style preset: " + stylePreset);

    ITable anotherTable = slide.getShapes().addTable(10, 100, columnWidths, rowHeights);
    anotherTable.setStylePreset(stylePreset);

    presentation.save("table-style.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Bloquear relación de aspecto de una tabla**

La relación de aspecto de una tabla es la proporción entre su anchura y su altura. Utilice [setAspectRatioLocked](https://reference.aspose.com/slides/java/com.aspose.slides/igraphicalobjectlock/#setAspectRatioLocked-boolean-) para bloquear esta proporción en una tabla.

El siguiente ejemplo abre `pres.pptx`, que debe contener al menos una diapositiva con una tabla como su primera forma. Muestra el estado actual del bloqueo, habilita el bloqueo de la relación de aspecto, muestra el estado actualizado (`true`) y guarda el resultado como `pres-out.pptx`.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ITable table = (ITable) slide.getShapes().get_Item(0);
    System.out.println("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    table.getGraphicalObjectLock().setAspectRatioLocked(true);
    System.out.println("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    presentation.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**¿Puedo habilitar la dirección de lectura de derecha a izquierda (RTL) para una tabla completa y el texto de sus celdas?**

Sí. La tabla expone un método [setRightToLeft](https://reference.aspose.com/slides/java/com.aspose.slides/table/#setRightToLeft-boolean-) , y los párrafos tienen [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/java/com.aspose.slides/paragraphformat/#setRightToLeft-byte-) . Usar ambos garantiza el orden RTL correcto y el renderizado dentro de las celdas.

**¿Cómo puedo evitar que los usuarios muevan o cambien el tamaño de una tabla en el archivo final?**

Utilice [shape locks](/slides/es/java/applying-protection-to-presentation/) para desactivar el movimiento, el cambio de tamaño, la selección, etc. Estos bloqueos se aplican también a las tablas.

**¿Se admite insertar una imagen dentro de una celda como fondo?**

Sí. Puede establecer un [picture fill](https://reference.aspose.com/slides/java/com.aspose.slides/picturefillformat/) para una celda; la imagen cubrirá el área de la celda según el modo elegido (estirar o mosaico).