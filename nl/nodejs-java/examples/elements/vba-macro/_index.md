---
title: VBA-macro
type: docs
weight: 150
url: /nl/nodejs-java/examples/elements/vba-macro/
keywords:
- codevoorbeeld
- VBA
- macro
- PowerPoint
- OpenDocument
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Automatiseer presentaties met Aspose.Slides voor Node.js via Java: maak, importeer en beveilig VBA-macro's in PPT, PPTX en ODP met duidelijke JavaScript-voorbeelden."
---
Dit artikel laat zien hoe je VBA‑macro's kunt toevoegen, openen en verwijderen met **Aspose.Slides for Node.js via Java**.

## **Voeg een VBA Macro toe**

Maak een presentatie met een VBA‑project en een eenvoudige macro‑module.

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

## **Toegang tot een VBA Macro**

Haal de eerste module op uit het VBA‑project.

```js
function accessVbaMacro() {
    let presentation = new aspose.slides.Presentation("vba_macro.pptm");
    try {
        // Aangenomen dat de presentatie minstens één VBA-module bevat.
        let firstModule = presentation.getVbaProject().getModules().get_Item(0);
    } finally {
        presentation.dispose();
    }
}
```

## **Verwijder een VBA Macro**

Verwijder een module uit het VBA‑project.

```js
function removeVbaMacro() {
    let presentation = new aspose.slides.Presentation("vba_macro.pptm");
    try {
        // Aangenomen dat de presentatie minstens één VBA-module bevat.
        let firstModule = presentation.getVbaProject().getModules().get_Item(0);

        presentation.getVbaProject().getModules().remove(firstModule);

        presentation.save("vba_macro_removed.pptm", aspose.slides.SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```