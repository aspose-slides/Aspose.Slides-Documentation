---
title: Tinta
type: docs
weight: 180
url: /es/nodejs-java/examples/elements/ink/
keywords:
- ejemplo de código
- tinta
- PowerPoint
- OpenDocument
- presentación
- Node.js
- JavaScript
- Aspose.Slides
description: "Trabaja con Tinta en Aspose.Slides para Node.js: dibuja, importa y edita trazos, ajusta el color y el ancho, y exporta a PPT, PPTX y ODP mediante ejemplos."
---
Este artículo ofrece ejemplos de cómo acceder a formas de tinta existentes y eliminarlas usando **Aspose.Slides for Node.js via Java**.

> ❗ **Nota:** Las formas de tinta representan la entrada del usuario desde dispositivos especializados. Aspose.Slides no puede crear nuevos trazos de tinta programáticamente, pero puedes leer y modificar la tinta existente.

## **Acceder a la tinta**
Recupera la primera forma de tinta en una diapositiva.

```js
function accessInk() {
    let presentation = new aspose.slides.Presentation("ink.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        let inkShape = null;
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            if (java.instanceOf(shape, "com.aspose.slides.IInk")) {
                inkShape = shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Eliminar tinta**
Elimina una forma de tinta de la diapositiva.

```js
function removeInk() {
    let presentation = new aspose.slides.Presentation("ink.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Suponiendo que la forma de tinta es la primera forma en la diapositiva.
        slide.getShapes().removeAt(0);

        presentation.save("ink_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```