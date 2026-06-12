---
title: VBA Makro
type: docs
weight: 150
url: /cs/nodejs-java/examples/elements/vba-macro/
keywords:
- ukázka kódu
- VBA
- makro
- PowerPoint
- OpenDocument
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Automatizujte prezentace pomocí Aspose.Slides pro Node.js via Java: vytvářejte, importujte a zabezpečujte VBA makra v PPT, PPTX a ODP pomocí přehledných příkladů v JavaScriptu."
---
Tento článek ukazuje, jak pomocí **Aspose.Slides for Node.js via Java** přidávat, přistupovat k a odstraňovat VBA makra.

## **Přidat VBA makro**

Vytvořte prezentaci s projektem VBA a jednoduchým modulem makra.

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

## **Přístup k VBA makru**

Získejte první modul z VBA projektu.

```js
function accessVbaMacro() {
    let presentation = new aspose.slides.Presentation("vba_macro.pptm");
    try {
        // Předpokládáme, že prezentace má alespoň jeden modul VBA.
        let firstModule = presentation.getVbaProject().getModules().get_Item(0);
    } finally {
        presentation.dispose();
    }
}
```

## **Odstranit VBA makro**

Odstraňte modul z VBA projektu.

```js
function removeVbaMacro() {
    let presentation = new aspose.slides.Presentation("vba_macro.pptm");
    try {
        // Předpokládáme, že prezentace má alespoň jeden modul VBA.
        let firstModule = presentation.getVbaProject().getModules().get_Item(0);

        presentation.getVbaProject().getModules().remove(firstModule);

        presentation.save("vba_macro_removed.pptm", aspose.slides.SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```