---
title: SmartArt
type: docs
weight: 140
url: /es/nodejs-java/examples/elements/smart-art/
keywords:
- ejemplo de código
- SmartArt
- PowerPoint
- OpenDocument
- presentación
- Node.js
- JavaScript
- Aspose.Slides
description: "Trabaje con SmartArt en Aspose.Slides para Node.js: cree, edite, convierta y aplique estilo a diagramas con JavaScript para presentaciones de PowerPoint y OpenDocument."
---
Este artículo muestra cómo añadir gráficos SmartArt, acceder a ellos, eliminarlos y cambiar diseños usando **Aspose.Slides for Node.js via Java**.

## **Agregar SmartArt**

Inserte un gráfico SmartArt usando uno de los diseños incorporados.

```js
function addSmartArt() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        let smartArt = slide.getShapes().addSmartArt(50, 50, 400, 300, aspose.slides.SmartArtLayoutType.BasicProcess);

        presentation.save("smartart.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Acceder a SmartArt**

Recupere el primer objeto SmartArt de una diapositiva.

```js
function accessSmartArt() {
    let presentation = new aspose.slides.Presentation("smartart.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        let firstSmartArt = null;
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
                firstSmartArt = shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Eliminar SmartArt**

Elimine una forma SmartArt de la diapositiva.

```js
function removeSmartArt() {
    let presentation = new aspose.slides.Presentation("smartart.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Suponiendo que la primera forma es SmartArt.
        let smartArt = slide.getShapes().get_Item(0);

        slide.getShapes().remove(smartArt);

        presentation.save("smartart_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Cambiar diseño de SmartArt**

Actualice el tipo de diseño de un gráfico SmartArt existente.

```js
function changeSmartArtLayout() {
    let presentation = new aspose.slides.Presentation("smartart.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Suponiendo que la primera forma es SmartArt.
        let smartArt = slide.getShapes().get_Item(0);

        smartArt.setLayout(aspose.slides.SmartArtLayoutType.VerticalPictureList);

        presentation.save("smartart_layout_changed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```