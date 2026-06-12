---
title: ActiveX
type: docs
weight: 200
url: /it/nodejs-java/examples/elements/activex/
keywords:
- esempio di codice
- ActiveX
- PowerPoint
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Vedi gli esempi ActiveX di Aspose.Slides per Node.js: inserimento, configurazione e controllo degli oggetti ActiveX in presentazioni PPT e PPTX con codice JavaScript chiaro."
---
Questo articolo dimostra come aggiungere, accedere, rimuovere e configurare i controlli ActiveX in una presentazione utilizzando **Aspose.Slides for Node.js via Java**.

## **Aggiungi un controllo ActiveX**

Aggiungi un nuovo controllo ActiveX a una diapositiva.

```js
function addActiveX() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Aggiungi un nuovo controllo ActiveX.
        let control = slide.getControls().addControl(aspose.slides.ControlType.WindowsMediaPlayer, 50, 50, 100, 50);

        presentation.save("activex.pptm", aspose.slides.SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```

## **Accedi a un controllo ActiveX**

Leggi le informazioni dal primo controllo ActiveX nella diapositiva.

```js
function accessActiveX() {
    let presentation = new aspose.slides.Presentation("activex.pptm");
    try {
        let slide = presentation.getSlides().get_Item(0);

        if (slide.getControls().size() > 0) {
            // Accedi al primo controllo ActiveX.
            let control = slide.getControls().get_Item(0);

            console.log("Control Name:", control.getName());
            console.log("Value:", control.getProperties().get_Item("Value"));
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Rimuovi un controllo ActiveX**

Elimina un controllo ActiveX esistente dalla diapositiva.

```js
function removeActiveX() {
    let presentation = new aspose.slides.Presentation("activex.pptm");
    try {
        let slide = presentation.getSlides().get_Item(0);

        if (slide.getControls().size() > 0) {
            // Rimuovi il primo controllo ActiveX.
            slide.getControls().removeAt(0);
        }

        presentation.save("activex_removed.pptm", aspose.slides.SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```

## **Imposta le proprietà ActiveX**

Configura diverse proprietà ActiveX.

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