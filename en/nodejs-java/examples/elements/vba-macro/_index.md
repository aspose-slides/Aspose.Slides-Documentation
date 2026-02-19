---
title: VBA Macro
type: docs
weight: 150
url: /nodejs-java/examples/elements/vba-macro/
keywords:
- code example
- VBA
- macro
- PowerPoint
- OpenDocument
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Automate presentations with Aspose.Slides for Node.js via Java: create, import, and secure VBA macros in PPT, PPTX, and ODP using clear JavaScript examples."
---

This article demonstrates how to add, access, and remove VBA macros using **Aspose.Slides for Node.js via Java**.

## **Add a VBA Macro**

Create a presentation with a VBA project and a simple macro module.

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

## **Access a VBA Macro**

Retrieve the first module from the VBA project.

```js
function accessVbaMacro() {
    let presentation = new aspose.slides.Presentation("vba_macro.pptm");
    try {
        // Assuming the presentation has at least one VBA module.
        let firstModule = presentation.getVbaProject().getModules().get_Item(0);
    } finally {
        presentation.dispose();
    }
}
```

## **Remove a VBA Macro**

Delete a module from the VBA project.

```js
function removeVbaMacro() {
    let presentation = new aspose.slides.Presentation("vba_macro.pptm");
    try {
        // Assuming the presentation has at least one VBA module.
        let firstModule = presentation.getVbaProject().getModules().get_Item(0);

        presentation.getVbaProject().getModules().remove(firstModule);

        presentation.save("vba_macro_removed.pptm", aspose.slides.SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```
