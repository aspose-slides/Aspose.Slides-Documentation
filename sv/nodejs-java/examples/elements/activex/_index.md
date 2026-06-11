---
title: ActiveX
type: docs
weight: 200
url: /sv/nodejs-java/examples/elements/activex/
keywords:
- kodexempel
- ActiveX
- PowerPoint
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Se Aspose.Slides for Node.js ActiveX-exempel: infoga, konfigurera och styra ActiveX-objekt i PPT- och PPTX-presentationer med tydlig JavaScript-kod."
---
Den här artikeln visar hur du lägger till, får åtkomst till, tar bort och konfigurerar ActiveX‑kontroller i en presentation med **Aspose.Slides for Node.js via Java**.

## **Lägg till en ActiveX‑kontroll**

Lägg till en ny ActiveX‑kontroll på en bild.

```js
function addActiveX() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Lägg till en ny ActiveX‑kontroll.
        let control = slide.getControls().addControl(aspose.slides.ControlType.WindowsMediaPlayer, 50, 50, 100, 50);

        presentation.save("activex.pptm", aspose.slides.SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```

## **Åtkomst till en ActiveX‑kontroll**

Läs information från den första ActiveX‑kontrollen på bilden.

```js
function accessActiveX() {
    let presentation = new aspose.slides.Presentation("activex.pptm");
    try {
        let slide = presentation.getSlides().get_Item(0);

        if (slide.getControls().size() > 0) {
            // Åtkomst till den första ActiveX‑kontrollen.
            let control = slide.getControls().get_Item(0);

            console.log("Control Name:", control.getName());
            console.log("Value:", control.getProperties().get_Item("Value"));
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Ta bort en ActiveX‑kontroll**

Radera en befintlig ActiveX‑kontroll från bilden.

```js
function removeActiveX() {
    let presentation = new aspose.slides.Presentation("activex.pptm");
    try {
        let slide = presentation.getSlides().get_Item(0);

        if (slide.getControls().size() > 0) {
            // Ta bort den första ActiveX‑kontrollen.
            slide.getControls().removeAt(0);
        }

        presentation.save("activex_removed.pptm", aspose.slides.SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```

## **Ställ in ActiveX‑egenskaper**

Konfigurera flera ActiveX‑egenskaper.

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