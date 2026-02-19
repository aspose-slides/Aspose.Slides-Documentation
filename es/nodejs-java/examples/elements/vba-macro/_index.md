---
title: Macro VBA
type: docs
weight: 150
url: /es/nodejs-java/examples/elements/vba-macro/
keywords:
- ejemplo de código
- VBA
- macro
- PowerPoint
- OpenDocument
- presentación
- Node.js
- JavaScript
- Aspose.Slides
description: "Automatice presentaciones con Aspose.Slides para Node.js a través de Java: cree, importe y proteja macros VBA en PPT, PPTX y ODP utilizando ejemplos claros de JavaScript."
---
Este artículo muestra cómo agregar, acceder y eliminar macros VBA usando **Aspose.Slides for Node.js via Java**.

## **Agregar un macro VBA**

Cree una presentación con un proyecto VBA y un módulo de macro sencillo.

```js
function addVbaMacro() {
    let presentation = new aspose.slides.Presentation();
    try {
        presentation.setVbaProject(new aspose.slides.VbaProject());

        let module = presentation.getVbaProject().getModules().addEmptyModule("Module");
        module.setSourceCode("Sub Test()\n MsgBox \"Hi\" \nEnd Sub");

        presentation.save("vba_macro.pptm", aspose.slides.SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```

## **Acceder a un macro VBA**

Recupere el primer módulo del proyecto VBA.

```js
function accessVbaMacro() {
    let presentation = new aspose.slides.Presentation("vba_macro.pptm");
    try {
        // Suponiendo que la presentación tiene al menos un módulo VBA.
        let firstModule = presentation.getVbaProject().getModules().get_Item(0);
    } finally {
        presentation.dispose();
    }
}
```

## **Eliminar un macro VBA**

Elimine un módulo del proyecto VBA.

```js
function removeVbaMacro() {
    let presentation = new aspose.slides.Presentation("vba_macro.pptm");
    try {
        // Suponiendo que la presentación tiene al menos un módulo VBA.
        let firstModule = presentation.getVbaProject().getModules().get_Item(0);

        presentation.getVbaProject().getModules().remove(firstModule);

        presentation.save("vba_macro_removed.pptm", aspose.slides.SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```