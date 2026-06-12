---
title: ActiveX
type: docs
weight: 200
url: /nl/nodejs-java/examples/elements/activex/
keywords:
- codevoorbeeld
- ActiveX
- PowerPoint
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Zie Aspose.Slides voor Node.js ActiveX-voorbeelden: voeg ActiveX-objecten in PPT- en PPTX-presentaties in, configureer ze en beheer ze met duidelijke JavaScript-code."
---
Dit artikel laat zien hoe u ActiveX‑besturingselementen kunt toevoegen, benaderen, verwijderen en configureren in een presentatie met behulp van **Aspose.Slides for Node.js via Java**.

## **Add an ActiveX Control**
Voeg een nieuw ActiveX‑besturingselement toe aan een dia.

```js
function addActiveX() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Voeg een nieuw ActiveX-besturingselement toe.
        let control = slide.getControls().addControl(aspose.slides.ControlType.WindowsMediaPlayer, 50, 50, 100, 50);

        presentation.save("activex.pptm", aspose.slides.SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```

## **Access an ActiveX Control**
Lees informatie van het eerste ActiveX‑besturingselement op de dia.

```js
function accessActiveX() {
    let presentation = new aspose.slides.Presentation("activex.pptm");
    try {
        let slide = presentation.getSlides().get_Item(0);

        if (slide.getControls().size() > 0) {
            // Toegang tot het eerste ActiveX-besturingselement.
            let control = slide.getControls().get_Item(0);

            console.log("Control Name:", control.getName());
            console.log("Value:", control.getProperties().get_Item("Value"));
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Remove an ActiveX Control**
Verwijder een bestaand ActiveX‑besturingselement van de dia.

```js
function removeActiveX() {
    let presentation = new aspose.slides.Presentation("activex.pptm");
    try {
        let slide = presentation.getSlides().get_Item(0);

        if (slide.getControls().size() > 0) {
            // Verwijder het eerste ActiveX-besturingselement.
            slide.getControls().removeAt(0);
        }

        presentation.save("activex_removed.pptm", aspose.slides.SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```

## **Set ActiveX Properties**
Configureer verschillende ActiveX‑eigenschappen.

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