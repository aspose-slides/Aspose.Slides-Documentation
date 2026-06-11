---
title: Makro VBA
type: docs
weight: 150
url: /pl/nodejs-java/examples/elements/vba-macro/
keywords:
- przykład kodu
- VBA
- makro
- PowerPoint
- OpenDocument
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Automatyzuj prezentacje za pomocą Aspose.Slides for Node.js via Java: twórz, importuj i zabezpieczaj makra VBA w formatach PPT, PPTX i ODP, korzystając z przejrzystych przykładów JavaScript."
---
Ten artykuł pokazuje, jak dodać, uzyskać dostęp i usunąć makra VBA przy użyciu **Aspose.Slides for Node.js via Java**.

## **Dodaj makro VBA**

Utwórz prezentację z projektem VBA i prostym modułem makra.

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

## **Uzyskaj dostęp do makra VBA**

Pobierz pierwszy moduł z projektu VBA.

```js
function accessVbaMacro() {
    let presentation = new aspose.slides.Presentation("vba_macro.pptm");
    try {
        // Zakładając, że prezentacja ma co najmniej jeden moduł VBA.
        let firstModule = presentation.getVbaProject().getModules().get_Item(0);
    } finally {
        presentation.dispose();
    }
}
```

## **Usuń makro VBA**

Usuń moduł z projektu VBA.

```js
function removeVbaMacro() {
    let presentation = new aspose.slides.Presentation("vba_macro.pptm");
    try {
        // Zakładając, że prezentacja ma co najmniej jeden moduł VBA.
        let firstModule = presentation.getVbaProject().getModules().get_Item(0);

        presentation.getVbaProject().getModules().remove(firstModule);

        presentation.save("vba_macro_removed.pptm", aspose.slides.SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```