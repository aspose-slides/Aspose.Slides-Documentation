---
title: ActiveX
type: docs
weight: 200
url: /de/nodejs-java/examples/elements/activex/
keywords:
- Codebeispiel
- ActiveX
- PowerPoint
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Siehe Aspose.Slides for Node.js ActiveX-Beispiele: Einfügen, Konfigurieren und Steuern von ActiveX-Objekten in PPT- und PPTX-Präsentationen mit klarem JavaScript-Code."
---
Dieser Artikel demonstriert, wie man ActiveX-Steuerelemente in einer Präsentation hinzufügt, darauf zugreift, sie entfernt und konfiguriert, wobei **Aspose.Slides for Node.js via Java** verwendet wird.

## **ActiveX-Steuerelement hinzufügen**

Fügen Sie ein neues ActiveX-Steuerelement zu einer Folie hinzu.

```js
function addActiveX() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Ein neues ActiveX-Steuerelement hinzufügen.
        let control = slide.getControls().addControl(aspose.slides.ControlType.WindowsMediaPlayer, 50, 50, 100, 50);

        presentation.save("activex.pptm", aspose.slides.SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```

## **Zugriff auf ein ActiveX-Steuerelement**

Lesen Sie Informationen vom ersten ActiveX-Steuerelement auf der Folie.

```js
function accessActiveX() {
    let presentation = new aspose.slides.Presentation("activex.pptm");
    try {
        let slide = presentation.getSlides().get_Item(0);

        if (slide.getControls().size() > 0) {
            // Zugriff auf das erste ActiveX-Steuerelement.
            let control = slide.getControls().get_Item(0);

            console.log("Control Name:", control.getName());
            console.log("Value:", control.getProperties().get_Item("Value"));
        }
    } finally {
        presentation.dispose();
    }
}
```

## **ActiveX-Steuerelement entfernen**

Löschen Sie ein vorhandenes ActiveX-Steuerelement von der Folie.

```js
function removeActiveX() {
    let presentation = new aspose.slides.Presentation("activex.pptm");
    try {
        let slide = presentation.getSlides().get_Item(0);

        if (slide.getControls().size() > 0) {
            // Entferne das erste ActiveX-Steuerelement.
            slide.getControls().removeAt(0);
        }

        presentation.save("activex_removed.pptm", aspose.slides.SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```

## **ActiveX-Eigenschaften festlegen**

Konfigurieren Sie mehrere ActiveX-Eigenschaften.

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