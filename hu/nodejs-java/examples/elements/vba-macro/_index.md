---
title: VBA makró
type: docs
weight: 150
url: /hu/nodejs-java/examples/elements/vba-macro/
keywords:
- kódrészlet példa
- VBA
- makró
- PowerPoint
- OpenDocument
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Automatizálja a prezentációkat az Aspose.Slides for Node.js via Java segítségével: hozza létre, importálja és biztosítsa a VBA makrókat PPT, PPTX és ODP formátumban egyértelmű JavaScript példákkal."
---
Ez a cikk bemutatja, hogyan lehet VBA makrókat hozzáadni, elérni és eltávolítani a **Aspose.Slides for Node.js via Java** használatával.

## **VBA makró hozzáadása**

Hozzon létre egy prezentációt egy VBA projekttel és egy egyszerű makrómodullal.

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

## **VBA makró elérése**

Szerezze be az első modult a VBA projektből.

```js
function accessVbaMacro() {
    let presentation = new aspose.slides.Presentation("vba_macro.pptm");
    try {
        // Feltételezve, hogy a prezentációnak legalább egy VBA modulja van.
        let firstModule = presentation.getVbaProject().getModules().get_Item(0);
    } finally {
        presentation.dispose();
    }
}
```

## **VBA makró eltávolítása**

Töröljön egy modult a VBA projektből.

```js
function removeVbaMacro() {
    let presentation = new aspose.slides.Presentation("vba_macro.pptm");
    try {
        // Feltételezve, hogy a prezentációnak legalább egy VBA modulja van.
        let firstModule = presentation.getVbaProject().getModules().get_Item(0);

        presentation.getVbaProject().getModules().remove(firstModule);

        presentation.save("vba_macro_removed.pptm", aspose.slides.SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```