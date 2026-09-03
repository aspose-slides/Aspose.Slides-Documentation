---
title: Gestionar cuadros de texto en presentaciones en Android
linktitle: Gestionar cuadro de texto
type: docs
weight: 20
url: /es/androidjava/manage-textbox/
keywords:
- cuadro de texto
- marco de texto
- añadir texto
- actualizar texto
- crear cuadro de texto
- comprobar cuadro de texto
- añadir columna de texto
- añadir hipervínculo
- PowerPoint
- presentación
- Android
- Java
- Aspose.Slides
description: "Crear, identificar, dar formato y actualizar cuadros de texto en presentaciones de PowerPoint y OpenDocument utilizando Aspose.Slides para Android mediante Java."
---
## **Introducción**

En Aspose.Slides para Android mediante Java, el texto de la diapositiva se almacena en marcos de texto que pertenecen a formas. La interfaz [IAutoShape](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iautoshape/) representa la forma con texto más común y expone su texto a través del método [IAutoShape.getTextFrame](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iautoshape/#getTextFrame--).

{{% alert color="info" title="Nota" %}}
Todas las formas automáticas implementan [IShape](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ishape/), pero no todas las formas son formas automáticas ni admiten un marco de texto. Al procesar una presentación existente, compruebe que una forma implemente [IAutoShape](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iautoshape/) antes de acceder a su texto.
{{% /alert %}}

## **Crear un cuadro de texto en una diapositiva**

Para crear un cuadro de texto, añada una forma automática a una diapositiva, añada texto a su marco de texto y guarde la presentación. El siguiente ejemplo crea un cuadro de texto rectangular:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape textBox = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 300, 50);
    textBox.addTextFrame("Aspose TextBox");

    presentation.save("TextBox.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Las coordenadas y dimensiones pasadas a [IShapeCollection.addAutoShape](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ishapecollection/#addAutoShape-int-float-float-float-float-) se miden en puntos. [IAutoShape.addTextFrame](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) inicializa el marco de texto con el texto suministrado.

## **Comprobar si una forma es un cuadro de texto**

Utilice el método [IAutoShape.isTextBox](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iautoshape/#isTextBox--) para determinar si una forma automática se trata como un cuadro de texto. Esto es útil cuando una presentación contiene tanto formas automáticas con texto como formas únicamente gráficas.

![Un cuadro de texto y una forma](istextbox.png)

El siguiente ejemplo inspecciona cada forma automática en una presentación:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape textBox = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 120, 40);
    textBox.addTextFrame("Text box");
    slide.getShapes().addAutoShape(ShapeType.Ellipse, 150, 10, 40, 40);

    for (ISlide currentSlide : presentation.getSlides()) {
        for (IShape shape : currentSlide.getShapes()) {
            if (shape instanceof IAutoShape) {
                IAutoShape autoShape = (IAutoShape) shape;
                System.out.println(autoShape.isTextBox() ? "The shape is a text box." : "The shape is not a text box.");
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Una forma automática recién añadida no se considera un cuadro de texto hasta que contenga texto no vacío. Puede proporcionar ese texto mediante [IAutoShape.addTextFrame](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) o [ITextFrame.setText](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/itextframe/#setText-java.lang.String-). Añadir o asignar una cadena vacía hace que [IAutoShape.isTextBox](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iautoshape/#isTextBox--) devuelva `false`:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 40);
    shape1.addTextFrame("Shape 1");
    System.out.println(shape1.isTextBox());

    IAutoShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 70, 100, 40);
    shape2.getTextFrame().setText("Shape 2");
    System.out.println(shape2.isTextBox());

    IAutoShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 130, 100, 40);
    shape3.addTextFrame("");
    System.out.println(shape3.isTextBox());

    IAutoShape shape4 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 190, 100, 40);
    shape4.getTextFrame().setText("");
    System.out.println(shape4.isTextBox());
} finally {
    presentation.dispose();
}
```

Las dos primeras llamadas imprimen `true`; las dos últimas imprimen `false`.

## **Encontrar la forma que posee un marco de texto**

El código genérico de procesamiento de texto puede recibir un [ITextFrame](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/itextframe/) sin saber qué objeto de presentación lo contiene. Utilice el método de solo lectura [ITextFrame.getParentShape](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/itextframe/#getParentShape--) para volver a su [IShape](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ishape/) propietario.

Para un marco de texto que pertenece a una forma automática u otra forma con texto, [ITextFrame.getParentShape](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/itextframe/#getParentShape--) devuelve el propietario y [ITextFrame.getParentCell](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/itextframe/#getParentCell--) devuelve `null`. Compruebe el valor devuelto antes de acceder a él. Para identificar tanto los propietarios de forma como de celda de tabla, incluidas las formas asociadas a nodos de SmartArt, vea [Buscar y reemplazar texto](/slides/es/androidjava/search-and-replace-text/).

## **Añadir columnas a un cuadro de texto**

El método [ITextFrameFormat.setColumnCount](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/itextframeformat/#setColumnCount-int-) divide el marco de texto en columnas, mientras que [ITextFrameFormat.setColumnSpacing](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/itextframeformat/#setColumnSpacing-double-) establece la distancia entre columnas en puntos. Ambas configuraciones pertenecen a [ITextFrameFormat](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/itextframeformat/) y pueden modificarse a través del marco de texto de un cuadro de texto existente. El texto se refluye entre columnas dentro de la misma forma; no continúa en otra forma.

El siguiente ejemplo crea un cuadro de texto de tres columnas con 10 puntos entre columnas, guarda la presentación y lee de nuevo la configuración almacenada del archivo de salida:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape textBox = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 200);
    textBox.addTextFrame("This text is distributed automatically across all columns in the text box.");

    ITextFrameFormat textFrameFormat = textBox.getTextFrame().getTextFrameFormat();
    textFrameFormat.setColumnCount(3);
    textFrameFormat.setColumnSpacing(10);

    presentation.save("TextBoxColumns.pptx", SaveFormat.Pptx);

    Presentation savedPresentation = new Presentation("TextBoxColumns.pptx");
    try {
        IAutoShape savedTextBox = (IAutoShape) savedPresentation.getSlides().get_Item(0).getShapes().get_Item(0);
        ITextFrameFormat savedFormat = savedTextBox.getTextFrame().getTextFrameFormat();
        System.out.println("Columns: " + savedFormat.getColumnCount() + "; spacing: " + savedFormat.getColumnSpacing() + " points");
    } finally {
        savedPresentation.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **Extraer texto de columnas individuales**

Utilice [ITextFrame.splitTextByColumns](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/itextframe/#splitTextByColumns--) para obtener el texto asignado a cada columna visual en un marco de texto existente. El método devuelve una cadena por cada columna, en orden de lectura por columnas. Un marco de texto de una sola columna produce una matriz con un elemento, y una columna vacía se representa con una cadena vacía. Las cadenas contienen solo texto plano; el formato a nivel de porción no se conserva.

Esto es útil cuando necesita:

- Extraer el texto conservando su orden de lectura por columnas.
- Indexar o comparar el contenido de diapositivas con varias columnas.
- Exportar cada columna a un archivo separado, campo de base de datos u otro destino.
- Inspeccionar cómo se redistribuye el texto tras cambiar el número de columnas con [ITextFrameFormat.setColumnCount](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/itextframeformat/#setColumnCount-int-), el espaciado con [ITextFrameFormat.setColumnSpacing](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/itextframeformat/#setColumnSpacing-double-), la fuente o el tamaño del marco de texto.

El método informa del texto distribuido dentro del [ITextFrame](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/itextframe/) actual; no fluye automáticamente el texto entre formas o cuadros de texto separados. La distribución de columnas puede depender de las fuentes disponibles y de otras configuraciones de diseño de texto, así que asegúrese de que las fuentes requeridas estén disponibles cuando los resultados consistentes sean importantes.

El siguiente ejemplo carga una presentación, encuentra la primera forma automática multicolumna con un marco de texto, lee su número de columnas configurado y escribe el texto de cada columna en un archivo separado. Las formas que no proporcionan un marco de texto se omiten.

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.IOException;
import java.nio.charset.StandardCharsets;

Presentation presentation = new Presentation("MultiColumnText.pptx");
try {
    IAutoShape textBox = null;
    for (IShape shape : presentation.getSlides().get_Item(0).getShapes()) {
        if (shape instanceof IAutoShape) {
            IAutoShape autoShape = (IAutoShape) shape;
            if (autoShape.getTextFrame() != null) {
                int columnCount = autoShape.getTextFrame().getTextFrameFormat().getColumnCount();
                if (columnCount > 1) {
                    textBox = autoShape;
                    break;
                }
            }
        }
    }

    if (textBox == null) {
        System.out.println("No multi-column text frame was found.");
    } else {
        ITextFrame textFrame = textBox.getTextFrame();
        int configuredColumnCount = textFrame.getTextFrameFormat().getColumnCount();
        String[] columnTexts = textFrame.splitTextByColumns();

        System.out.println("Configured columns: " + configuredColumnCount);

        for (int columnIndex = 0; columnIndex < columnTexts.length; columnIndex++) {
            int columnNumber = columnIndex + 1;
            String columnText = columnTexts[columnIndex];
            System.out.println("Column " + columnNumber + ": " + columnText);
            String outputPath = "Column-" + columnNumber + ".txt";
            byte[] textBytes = columnText.getBytes(StandardCharsets.UTF_8);
            try (FileOutputStream outputStream = new FileOutputStream(outputPath)) {
                outputStream.write(textBytes);
            } catch (IOException exception) {
                System.out.println("Could not write column " + columnNumber + ": " + exception.getMessage());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Actualizar texto**

Para actualizar el texto en toda una presentación, recorra las diapositivas y las formas, seleccione las formas automáticas y luego edite sus porciones de texto. Trabajar a nivel de porción permite cambiar tanto el texto como el formato de los caracteres.

El siguiente ejemplo reemplaza cada aparición de `years` por `months` en el texto de las formas automáticas y pone en negrita cada porción afectada:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("Text.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (!(shape instanceof IAutoShape)) {
                continue;
            }

            IAutoShape autoShape = (IAutoShape) shape;
            ITextFrame textFrame = autoShape.getTextFrame();
            if (textFrame == null) {
                continue;
            }

            for (IParagraph paragraph : textFrame.getParagraphs()) {
                for (IPortion portion : paragraph.getPortions()) {
                    String text = portion.getText();
                    if (text != null && text.contains("years")) {
                        portion.setText(text.replace("years", "months"));
                        portion.getPortionFormat().setFontBold(NullableBool.True);
                    }
                }
            }
        }
    }

    presentation.save("TextChanged.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Este recorrido actualiza el texto solo en formas automáticas. El texto almacenado en tablas, gráficos, SmartArt o formas agrupadas requiere recorrer las colecciones propias de esos objetos.

## **Añadir un cuadro de texto con hipervínculo**

Se puede asignar un hipervínculo a una porción de texto específica, de modo que solo ese texto actúe como enlace clicable. Utilice [IHyperlinkManager.setExternalHyperlinkClick](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ihyperlinkmanager/#setExternalHyperlinkClick-java.lang.String-) para asociar la porción con una URL externa.

El siguiente ejemplo crea texto enlazado y lo guarda en una presentación:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape textBox = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 200, 50);
    textBox.addTextFrame("Aspose.Slides");

    IPortion textPortion = textBox.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    textPortion.getPortionFormat().getHyperlinkManager().setExternalHyperlinkClick("https://www.aspose.com/");

    presentation.save("Hyperlink.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Preguntas frecuentes**

**¿Cuál es la diferencia entre un cuadro de texto y un marcador de posición de texto en una diapositiva maestra o de diseño?**

Un [marcador de posición](/slides/es/androidjava/manage-placeholder/) puede heredar su posición y formato de una [diapositiva maestra](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/masterslide/) o una [diapositiva de diseño](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/layoutslide/). Un cuadro de texto normal es una forma independiente en la diapositiva donde se creó y no adquiere el comportamiento de marcador de posición cuando el diseño cambia.

**¿Cómo puedo reemplazar texto sin modificar el texto de gráficos, tablas o SmartArt?**

Limite el recorrido a las formas que implementen [IAutoShape](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iautoshape/), como se muestra en el ejemplo de Actualizar texto. Los gráficos, tablas y SmartArt almacenan texto en sus propios modelos de objetos, por lo que no se modifican con ese bucle.