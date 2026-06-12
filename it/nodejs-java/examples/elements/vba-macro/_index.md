---
title: Macro VBA
type: docs
weight: 150
url: /it/nodejs-java/examples/elements/vba-macro/
keywords:
- esempio di codice
- VBA
- macro
- PowerPoint
- OpenDocument
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Automatizza le presentazioni con Aspose.Slides for Node.js via Java: crea, importa e proteggi le macro VBA in PPT, PPTX e ODP utilizzando chiari esempi JavaScript."
---
Questo articolo illustra come aggiungere, accedere e rimuovere macro VBA utilizzando **Aspose.Slides for Node.js via Java**.

## **Aggiungere una macro VBA**

Crea una presentazione con un progetto VBA e un modulo macro semplice.

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

## **Accedere a una macro VBA**

Recupera il primo modulo dal progetto VBA.

```js
function accessVbaMacro() {
    let presentation = new aspose.slides.Presentation("vba_macro.pptm");
    try {
        // Supponendo che la presentazione abbia almeno un modulo VBA.
        let firstModule = presentation.getVbaProject().getModules().get_Item(0);
    } finally {
        presentation.dispose();
    }
}
```

## **Rimuovere una macro VBA**

Elimina un modulo dal progetto VBA.

```js
function removeVbaMacro() {
    let presentation = new aspose.slides.Presentation("vba_macro.pptm");
    try {
        // Supponendo che la presentazione abbia almeno un modulo VBA.
        let firstModule = presentation.getVbaProject().getModules().get_Item(0);

        presentation.getVbaProject().getModules().remove(firstModule);

        presentation.save("vba_macro_removed.pptm", aspose.slides.SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```