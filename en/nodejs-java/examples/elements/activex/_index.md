---
title: ActiveX
type: docs
weight: 200
url: /nodejs-java/examples/elements/activex/
keywords:
- code example
- ActiveX
- PowerPoint
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "See Aspose.Slides for Node.js ActiveX examples: insert, configure, and control ActiveX objects in PPT and PPTX presentations with clear JavaScript code."
---

This article demonstrates how to add, access, remove, and configure ActiveX controls in a presentation using **Aspose.Slides for Node.js via Java**.

## **Add an ActiveX Control**

Insert a new ActiveX control and optionally set its properties.

```js
function addActiveX() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Add a new ActiveX control.
        let control = slide.getControls().addControl(aspose.slides.ControlType.WindowsMediaPlayer, 50, 50, 100, 50);

        // Optionally set some properties.
        control.getProperties().add("Value", "Default text");

        presentation.save("add_activex.pptm", aspose.slides.SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```

## **Access an ActiveX Control**

Read information from the first ActiveX control on the slide.

```js
function accessActiveX() {
    let presentation = new aspose.slides.Presentation("add_activex.pptm");
    try {
        let slide = presentation.getSlides().get_Item(0);

        if (slide.getControls().size() > 0) {
            // Access the first ActiveX control.
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

Delete an existing ActiveX control from the slide.

```js
function removeActiveX() {
    let presentation = new aspose.slides.Presentation("add_activex.pptm");
    try {
        let slide = presentation.getSlides().get_Item(0);

        if (slide.getControls().size() > 0) {
            // Remove the first ActiveX control.
            slide.getControls().removeAt(0);
        }

        presentation.save("removed_activex.pptm", aspose.slides.SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```

## **Set ActiveX Properties**

Add a control and configure several ActiveX properties.

```js
function setActiveXProperties() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Add a Windows Media Player control and configure properties.
        let control = slide.getControls().addControl(aspose.slides.ControlType.WindowsMediaPlayer, 50, 50, 150, 50);
        control.getProperties().set_Item("Caption", "Click Me");
        control.getProperties().set_Item("Enabled", "true");

        presentation.save("set_activex_props.pptm", aspose.slides.SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```
