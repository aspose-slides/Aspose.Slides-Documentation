---
title: ActiveX
type: docs
weight: 200
url: /es/nodejs-java/examples/elements/activex/
keywords:
- ejemplo de código
- ActiveX
- PowerPoint
- presentación
- Node.js
- JavaScript
- Aspose.Slides
description: "Consulte los ejemplos de ActiveX de Aspose.Slides para Node.js: inserte, configure y controle objetos ActiveX en presentaciones PPT y PPTX con código JavaScript claro."
---
Este artículo muestra cómo añadir, acceder, eliminar y configurar controles ActiveX en una presentación usando **Aspose.Slides for Node.js via Java**.

## **Añadir un control ActiveX**

Añade un nuevo control ActiveX a una diapositiva.

```js
function addActiveX() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Añadir un nuevo control ActiveX.
        let control = slide.getControls().addControl(aspose.slides.ControlType.WindowsMediaPlayer, 50, 50, 100, 50);

        presentation.save("activex.pptm", aspose.slides.SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```

## **Acceder a un control ActiveX**

Lee información del primer control ActiveX de la diapositiva.

```js
function accessActiveX() {
    let presentation = new aspose.slides.Presentation("activex.pptm");
    try {
        let slide = presentation.getSlides().get_Item(0);

        if (slide.getControls().size() > 0) {
            // Acceder al primer control ActiveX.
            let control = slide.getControls().get_Item(0);

            console.log("Control Name:", control.getName());
            console.log("Value:", control.getProperties().get_Item("Value"));
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Eliminar un control ActiveX**

Elimina un control ActiveX existente de la diapositiva.

```js
function removeActiveX() {
    let presentation = new aspose.slides.Presentation("activex.pptm");
    try {
        let slide = presentation.getSlides().get_Item(0);

        if (slide.getControls().size() > 0) {
            // Eliminar el primer control ActiveX.
            slide.getControls().removeAt(0);
        }

        presentation.save("activex_removed.pptm", aspose.slides.SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```

## **Establecer propiedades ActiveX**

Configura varias propiedades ActiveX.

```js
function setActiveXProperties() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        if (slide.getControls().size() > 0) {
            let control = slide.getControls().get_Item(0);

            control.getProperties().set_Item("Caption", "Click Me");
            control.getProperties().set_Item("Enabled", "true");
        }

        presentation.save("activex_properties.pptm", aspose.slides.SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```