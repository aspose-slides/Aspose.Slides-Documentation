---
title: ActiveX
type: docs
weight: 200
url: /hu/nodejs-java/examples/elements/activex/
keywords:
- kód példa
- ActiveX
- PowerPoint
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Lásd az Aspose.Slides for Node.js ActiveX példákat: ActiveX objektumok beszúrása, konfigurálása és vezérlése PPT és PPTX prezentációkban tiszta JavaScript kóddal."
---
Ez a cikk bemutatja, hogyan lehet hozzáadni, elérni, eltávolítani és konfigurálni az ActiveX vezérlőket egy prezentációban a **Aspose.Slides for Node.js via Java** használatával.

## **ActiveX vezérlő hozzáadása**

Új ActiveX vezérlőt adunk a diára.

```js
function addActiveX() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Új ActiveX vezérlő hozzáadása.
        let control = slide.getControls().addControl(aspose.slides.ControlType.WindowsMediaPlayer, 50, 50, 100, 50);

        presentation.save("activex.pptm", aspose.slides.SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```

## **ActiveX vezérlő elérése**

Az első dián lévő ActiveX vezérlő információinak kiolvasása.

```js
function accessActiveX() {
    let presentation = new aspose.slides.Presentation("activex.pptm");
    try {
        let slide = presentation.getSlides().get_Item(0);

        if (slide.getControls().size() > 0) {
            // Az első ActiveX vezérlő elérése.
            let control = slide.getControls().get_Item(0);

            console.log("Control Name:", control.getName());
            console.log("Value:", control.getProperties().get_Item("Value"));
        }
    } finally {
        presentation.dispose();
    }
}
```

## **ActiveX vezérlő eltávolítása**

Egy meglévő ActiveX vezérlő törlése a diákról.

```js
function removeActiveX() {
    let presentation = new aspose.slides.Presentation("activex.pptm");
    try {
        let slide = presentation.getSlides().get_Item(0);

        if (slide.getControls().size() > 0) {
            // Az első ActiveX vezérlő eltávolítása.
            slide.getControls().removeAt(0);
        }

        presentation.save("activex_removed.pptm", aspose.slides.SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```

## **ActiveX tulajdonságok beállítása**

Több ActiveX tulajdonság konfigurálása.

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