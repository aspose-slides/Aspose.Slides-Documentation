---
title: Hipervínculo
type: docs
weight: 130
url: /es/nodejs-java/examples/elements/hyperlink/
keywords:
- ejemplo de código
- hipervínculo
- PowerPoint
- OpenDocument
- presentación
- Node.js
- JavaScript
- Aspose.Slides
description: "Añade y gestiona hipervínculos en Aspose.Slides para Node.js: texto de enlace, formas e imágenes, establece destinos y acciones para PPT, PPTX y ODP con ejemplos."
---
Este artículo demuestra cómo agregar, acceder, eliminar y actualizar hipervínculos en formas usando **Aspose.Slides for Node.js via Java**.

## **Agregar un hipervínculo**

Crea una forma rectangular con un hipervínculo que apunta a un sitio web externo.

```js
function addHyperlink() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 50);
        shape.getTextFrame().setText("Aspose");

        let paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
        let textPortion = paragraph.getPortions().get_Item(0);

        let hyperlink = new aspose.slides.Hyperlink("https://www.aspose.com");
        textPortion.getPortionFormat().setHyperlinkClick(hyperlink);

        presentation.save("hyperlink.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Acceder a un hipervínculo**

Lee el hipervínculo de la porción de texto de una forma.

```js
function accessHyperlink() {
    let presentation = new aspose.slides.Presentation("hyperlink.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Suponiendo que la primera forma contiene el texto con hipervínculo.
        let shape = slide.getShapes().get_Item(0);

        let paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
        let textPortion = paragraph.getPortions().get_Item(0);

        let hyperlink = textPortion.getPortionFormat().getHyperlinkClick();
    } finally {
        presentation.dispose();
    }
}
```

## **Eliminar un hipervínculo**

Elimina el hipervínculo del texto de una forma.

```js
function removeHyperlink() {
    let presentation = new aspose.slides.Presentation("hyperlink.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Suponiendo que la primera forma contiene el texto con hipervínculo.
        let shape = slide.getShapes().get_Item(0);

        let paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
        let textPortion = paragraph.getPortions().get_Item(0);

        textPortion.getPortionFormat().setHyperlinkClick(null);

        presentation.save("hyperlink_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Actualizar un hipervínculo**

Cambia el destino de un hipervínculo existente. Usa `HyperlinkManager` para modificar el texto que ya contiene un hipervínculo, lo que imita cómo PowerPoint actualiza los hipervínculos de forma segura.

```js
function updateHyperlink() {
    let presentation = new aspose.slides.Presentation("hyperlink.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Suponiendo que la primera forma contiene el texto con hipervínculo.
        let shape = slide.getShapes().get_Item(0);

        let paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
        let textPortion = paragraph.getPortions().get_Item(0);

        // Cambiar un hipervínculo dentro del texto existente debe hacerse mediante
        // HyperlinkManager en lugar de establecer la propiedad directamente.
        // Esto imita cómo PowerPoint actualiza los hipervínculos de forma segura.
        textPortion.getPortionFormat().getHyperlinkManager().setExternalHyperlinkClick("https://new.example.com");

        presentation.save("hyperlink_updated.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```