---
title: VBA-makro
type: docs
weight: 150
url: /sv/nodejs-java/examples/elements/vba-macro/
keywords:
- kodexempel
- VBA
- makro
- PowerPoint
- OpenDocument
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Automatisera presentationer med Aspose.Slides för Node.js via Java: skapa, importera och skydda VBA-makron i PPT, PPTX och ODP med tydliga JavaScript-exempel."
---
Den här artikeln visar hur du lägger till, får åtkomst till och tar bort VBA-makron med hjälp av **Aspose.Slides for Node.js via Java**.

## **Lägg till ett VBA-makro**

Skapa en presentation med ett VBA-projekt och en enkel makro-modul.

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

## **Få åtkomst till ett VBA-makro**

Hämta den första modulen från VBA-projektet.

```js
function accessVbaMacro() {
    let presentation = new aspose.slides.Presentation("vba_macro.pptm");
    try {
        // Antar att presentationen har minst en VBA-modul.
        let firstModule = presentation.getVbaProject().getModules().get_Item(0);
    } finally {
        presentation.dispose();
    }
}
```

## **Ta bort ett VBA-makro**

Ta bort en modul från VBA-projektet.

```js
function removeVbaMacro() {
    let presentation = new aspose.slides.Presentation("vba_macro.pptm");
    try {
        // Antar att presentationen har minst en VBA-modul.
        let firstModule = presentation.getVbaProject().getModules().get_Item(0);

        presentation.getVbaProject().getModules().remove(firstModule);

        presentation.save("vba_macro_removed.pptm", aspose.slides.SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```