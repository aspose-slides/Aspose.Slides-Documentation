---
title: Cuadro de texto
type: docs
weight: 40
url: /es/nodejs-java/examples/elements/text-box/
keywords:
- ejemplo de código
- cuadro de texto
- PowerPoint
- OpenDocument
- presentación
- Node.js
- JavaScript
- Aspose.Slides
description: "Trabaje con cuadros de texto en Aspose.Slides para Node.js: añada, formatee, alinee, ajuste, autoajuste y estilice texto usando JavaScript para presentaciones PPT, PPTX y ODP."
---
En Aspose.Slides, un **cuadro de texto** se representa mediante un `AutoShape`. Casi cualquier forma puede contener texto, pero un cuadro de texto típico no tiene relleno ni borde y muestra únicamente texto.

Esta guía explica cómo añadir, acceder y eliminar cuadros de texto mediante programación.

## **Agregar un cuadro de texto**

Un cuadro de texto es simplemente un `AutoShape` sin relleno ni borde y con algo de texto con formato. Así es como se crea uno:

```js
function addTextBox() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Crear una forma rectangular (por defecto con relleno, borde y sin texto).
        let textBox = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 75, 150, 100);

        // Eliminar el relleno y el borde para que parezca un cuadro de texto típico.
        let boxFillType = java.newByte(aspose.slides.FillType.NoFill);
        textBox.getFillFormat().setFillType(boxFillType);
        textBox.getLineFormat().getFillFormat().setFillType(boxFillType);

        // Establecer el formato del texto.
        let paragraph = textBox.getTextFrame().getParagraphs().get_Item(0);
        let textFormat = paragraph.getParagraphFormat().getDefaultPortionFormat();
        let textFillType = java.newByte(aspose.slides.FillType.Solid);
        let textFillColor = java.getStaticFieldValue("java.awt.Color", "BLACK");
        textFormat.getFillFormat().setFillType(textFillType);
        textFormat.getFillFormat().getSolidFillColor().setColor(textFillColor);

        // Asignar el contenido de texto real.
        textBox.getTextFrame().setText("Some text...");

        presentation.save("text_box.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Nota:** Cualquier `AutoShape` que contenga un `TextFrame` no vacío puede funcionar como un cuadro de texto.

## **Acceder a un cuadro de texto**

Recupere el primer cuadro de texto de la diapositiva.

```js
function accessTextBox() {
    let presentation = new aspose.slides.Presentation("text_box.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        let firstTextBox = null;
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            // Sólo los AutoShapes pueden contener texto editable.
            if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                firstTextBox = shape;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Eliminar cuadros de texto por contenido**

Este ejemplo encuentra y elimina todos los cuadros de texto de la primera diapositiva que contienen una palabra clave específica:

```js
function removeTextBoxes() {
    let presentation = new aspose.slides.Presentation("text_box.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        let shapesToRemove = [];
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                let autoShape = shape;
                if (autoShape.getTextFrame().getText().includes("Slide")) {
                    shapesToRemove.push(shape);
                }
            }
        }

        for (let i = 0; i < shapesToRemove.length; i++) {
            slide.getShapes().remove(shapesToRemove[i]);
        }

        presentation.save("text_boxes_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Consejo:** Siempre cree una copia de la colección de formas antes de modificarla durante la iteración para evitar errores de modificación de la colección.