---
title: Gestionar cuadros de texto en presentaciones usando JavaScript
linktitle: Gestionar cuadro de texto
type: docs
weight: 20
url: /es/nodejs-java/manage-textbox/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Crear, identificar, dar formato y actualizar cuadros de texto en presentaciones de PowerPoint y OpenDocument usando Aspose.Slides para Node.js mediante Java."
---
## **Introducción**

En Aspose.Slides para Node.js mediante Java, el texto de la diapositiva se almacena en marcos de texto que pertenecen a formas. La clase [AutoShape](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/autoshape/) representa la forma que más comúnmente contiene texto y expone su texto mediante el método [AutoShape.getTextFrame](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/autoshape/#getTextFrame).

{{% alert color="info" title="Note" %}}
Todas las autoformas derivan de [Shape](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/shape/), pero no todas las formas son autoformas o admiten un marco de texto. Al procesar una presentación existente, compruebe que una forma sea una instancia de [AutoShape](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/autoshape/) antes de acceder a su texto.
{{% /alert %}}

## **Crear un cuadro de texto en una diapositiva**

Para crear un cuadro de texto, añada una autoforma a una diapositiva, agregue texto a su marco de texto y guarde la presentación. El siguiente ejemplo crea un cuadro de texto rectangular:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const textBox = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 300, 50);
    textBox.addTextFrame("Aspose TextBox");

    presentation.save("TextBox.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Las coordenadas y dimensiones pasadas a [ShapeCollection.addAutoShape](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/shapecollection/#addAutoShape) se miden en puntos. [AutoShape.addTextFrame](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/autoshape/#addTextFrame) inicializa el marco de texto con el texto suministrado.

## **Comprobar si una forma es un cuadro de texto**

Utilice el método [AutoShape.isTextBox](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/autoshape/#isTextBox) para determinar si una autoforma se trata como un cuadro de texto. Esto es útil cuando una presentación contiene tanto autoformas con texto como autoformas puramente gráficas.

![Un cuadro de texto y una forma](istextbox.png)

El siguiente ejemplo inspecciona cada autoforma en una presentación:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const textBox = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 120, 40);
    textBox.addTextFrame("Text box");
    slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 150, 10, 40, 40);

    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const currentSlide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < currentSlide.getShapes().size(); shapeIndex++) {
            const shape = currentSlide.getShapes().get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
                console.log(shape.isTextBox() ? "The shape is a text box." : "The shape is not a text box.");
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Una autoforma recién añadida no se considera un cuadro de texto hasta que contiene texto no vacío. Puede proporcionar ese texto mediante [AutoShape.addTextFrame](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/autoshape/#addTextFrame) o [TextFrame.setText](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/textframe/#setText). Añadir o asignar una cadena vacía hace que [AutoShape.isTextBox](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/autoshape/#isTextBox) devuelva `false`:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape1 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 40);
    shape1.addTextFrame("Shape 1");
    console.log(shape1.isTextBox());

    const shape2 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 70, 100, 40);
    shape2.getTextFrame().setText("Shape 2");
    console.log(shape2.isTextBox());

    const shape3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 130, 100, 40);
    shape3.addTextFrame("");
    console.log(shape3.isTextBox());

    const shape4 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 190, 100, 40);
    shape4.getTextFrame().setText("");
    console.log(shape4.isTextBox());
} finally {
    presentation.dispose();
}
```

Las dos primeras llamadas imprimen `true`; las dos últimas imprimen `false`.

## **Encontrar la forma que posee un marco de texto**

El código genérico de procesamiento de texto puede recibir un [TextFrame](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/textframe/) sin saber qué objeto de la presentación lo contiene. Utilice el método de solo lectura [TextFrame.getParentShape](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/textframe/#getParentShape) para volver a su [Shape](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/shape/) propietario.

Para un marco de texto perteneciente a una autoforma u otra forma con texto, [TextFrame.getParentShape](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/textframe/#getParentShape) devuelve el propietario y [TextFrame.getParentCell](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/textframe/#getParentCell) devuelve `null`. Compruebe el valor devuelto antes de acceder a él. Para identificar tanto propietarios de forma como de celda de tabla, incluidas las formas asociadas a nodos de SmartArt, consulte [Buscar y reemplazar texto](/slides/es/nodejs-java/search-and-replace-text/).

## **Añadir columnas a un cuadro de texto**

El método [TextFrameFormat.setColumnCount](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/textframeformat/#setColumnCount) divide el marco de texto en columnas, mientras que [TextFrameFormat.setColumnSpacing](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/textframeformat/#setColumnSpacing) establece el espacio entre columnas en puntos. Ambos ajustes pertenecen a [TextFrameFormat](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/textframeformat/) y pueden modificarse a través del marco de texto de un cuadro de texto existente. El texto se redistribuye entre columnas dentro de la misma forma; no continúa en otra forma.

El siguiente ejemplo crea un cuadro de texto de tres columnas con 10 puntos entre columnas, guarda la presentación y lee los ajustes almacenados del archivo de salida:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const textBox = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 300, 200);
    textBox.addTextFrame("This text is distributed automatically across all columns in the text box.");

    const textFrameFormat = textBox.getTextFrame().getTextFrameFormat();
    textFrameFormat.setColumnCount(3);
    textFrameFormat.setColumnSpacing(10);

    presentation.save("TextBoxColumns.pptx", aspose.slides.SaveFormat.Pptx);

    const savedPresentation = new aspose.slides.Presentation("TextBoxColumns.pptx");
    try {
        const savedTextBox = savedPresentation.getSlides().get_Item(0).getShapes().get_Item(0);
        const savedFormat = savedTextBox.getTextFrame().getTextFrameFormat();
        console.log("Columns: " + savedFormat.getColumnCount() + "; spacing: " + savedFormat.getColumnSpacing() + " points");
    } finally {
        savedPresentation.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **Extraer texto de columnas individuales**

Utilice [TextFrame.splitTextByColumns](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/textframe/#splitTextByColumns) para obtener el texto asignado a cada columna visual en un marco de texto existente. El método devuelve una cadena por cada columna, en orden de lectura basado en columnas. Un marco de texto de una sola columna produce una matriz con un elemento, y una columna vacía se representa con una cadena vacía. Las cadenas contienen solo texto sin formato; el formato a nivel de porción no se conserva.

Esto es útil cuando necesita:

- Extraer texto conservando su orden de lectura basado en columnas.
- Indexar o comparar el contenido de diapositivas con varias columnas.
- Exportar cada columna a un archivo separado, campo de base de datos u otro destino.
- Examinar cómo se redistribuye el texto tras cambiar el número de columnas con [TextFrameFormat.setColumnCount](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/textframeformat/#setColumnCount), el espaciado con [TextFrameFormat.setColumnSpacing](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/textframeformat/#setColumnSpacing), la fuente o el tamaño del marco de texto.

El método informa del texto distribuido dentro del [TextFrame](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/textframe/) actual; no fluye automáticamente el texto entre formas o cuadros de texto separados. La distribución de columnas puede depender de las fuentes disponibles y de otras configuraciones de maquetación, así que asegúrese de que las fuentes requeridas estén accesibles cuando la consistencia sea importante.

El siguiente ejemplo carga una presentación, encuentra la primera autoforma multi‑columna con un marco de texto, lee su número de columnas configurado y escribe el texto de cada columna en un archivo separado. Las formas que no proporcionan un marco de texto se omiten.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation("MultiColumnText.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    let textBox = null;
    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
            const textFrame = shape.getTextFrame();
            if (textFrame != null) {
                const columnCount = textFrame.getTextFrameFormat().getColumnCount();
                if (columnCount > 1) {
                    textBox = shape;
                    break;
                }
            }
        }
    }

    if (textBox == null) {
        console.log("No multi-column text frame was found.");
    } else {
        const textFrame = textBox.getTextFrame();
        const configuredColumnCount = textFrame.getTextFrameFormat().getColumnCount();
        const columnTexts = textFrame.splitTextByColumns();

        console.log("Configured columns: " + configuredColumnCount);

        for (let columnIndex = 0; columnIndex < columnTexts.length; columnIndex++) {
            const columnNumber = columnIndex + 1;
            const columnText = columnTexts[columnIndex];
            console.log("Column " + columnNumber + ": " + columnText);
            const outputPath = "Column-" + columnNumber + ".txt";
            try {
                fs.writeFileSync(outputPath, columnText, "utf8");
            } catch (error) {
                console.log("Could not write column " + columnNumber + ": " + error.message);
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Actualizar texto**

Para actualizar texto en toda la presentación, recorra las diapositivas y las formas, seleccione las autoformas y luego edite sus porciones de texto. Trabajar a nivel de porción le permite cambiar tanto el texto como el formato de los caracteres.

El siguiente ejemplo reemplaza cada aparición de `years` por `months` en el texto de las autoformas y pone en negrita cada porción afectada:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const fontBold = java.newByte(aspose.slides.NullableBool.True);
const presentation = new aspose.slides.Presentation("Text.pptx");
try {
    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            if (!java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
                continue;
            }

            const textFrame = shape.getTextFrame();
            if (textFrame == null) {
                continue;
            }

            for (let paragraphIndex = 0; paragraphIndex < textFrame.getParagraphs().getCount(); paragraphIndex++) {
                const paragraph = textFrame.getParagraphs().get_Item(paragraphIndex);
                for (let portionIndex = 0; portionIndex < paragraph.getPortions().getCount(); portionIndex++) {
                    const portion = paragraph.getPortions().get_Item(portionIndex);
                    const text = portion.getText();
                    if (text != null && text.includes("years")) {
                        portion.setText(text.replace(/years/g, "months"));
                        portion.getPortionFormat().setFontBold(fontBold);
                    }
                }
            }
        }
    }

    presentation.save("TextChanged.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Este recorrido actualiza el texto solo en autoformas. El texto almacenado en tablas, gráficos, SmartArt o formas agrupadas requiere recorrer las colecciones propias de esos objetos.

## **Añadir un cuadro de texto con hipervínculo**

Se puede asignar un hipervínculo a una porción de texto específica, de modo que solo ese texto actúe como enlace clicable. Utilice [HyperlinkManager.setExternalHyperlinkClick](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/hyperlinkmanager/#setExternalHyperlinkClick) para asociar la porción con una URL externa.

El siguiente ejemplo crea texto enlazado y lo guarda en una presentación:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const textBox = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 150, 200, 50);
    textBox.addTextFrame("Aspose.Slides");

    const textPortion = textBox.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    textPortion.getPortionFormat().getHyperlinkManager().setExternalHyperlinkClick("https://www.aspose.com/");

    presentation.save("Hyperlink.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Preguntas frecuentes**

**¿Cuál es la diferencia entre un cuadro de texto y un marcador de posición de texto en una diapositiva maestra o de diseño?**

Un [marcador de posición](/slides/es/nodejs-java/manage-placeholder/) puede heredar su posición y formato de una [diapositiva maestra](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/masterslide/) o una [diapositiva de diseño](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/layoutslide/). Un cuadro de texto normal es una forma independiente en la diapositiva donde se creó y no adquiere el comportamiento de marcador de posición cuando el diseño cambia.

**¿Cómo puedo reemplazar texto sin modificar el texto en gráficos, tablas o SmartArt?**

Limite el recorrido a las formas que sean instancias de [AutoShape](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/autoshape/), como se muestra en el ejemplo de Actualizar texto. Los gráficos, tablas y SmartArt almacenan texto en sus propios modelos de objetos, por lo que no se modifican con ese bucle.