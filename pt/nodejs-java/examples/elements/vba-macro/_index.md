---
title: Macro VBA
type: docs
weight: 150
url: /pt/nodejs-java/examples/elements/vba-macro/
keywords:
- exemplo de código
- VBA
- macro
- PowerPoint
- OpenDocument
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Automatize apresentações com Aspose.Slides for Node.js via Java: crie, importe e proteja macros VBA em PPT, PPTX e ODP usando exemplos claros de JavaScript."
---
Este artigo demonstra como adicionar, acessar e remover macros VBA usando **Aspose.Slides for Node.js via Java**.

## **Adicionar uma macro VBA**

Crie uma apresentação com um projeto VBA e um módulo de macro simples.

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

## **Acessar uma macro VBA**

Recupere o primeiro módulo do projeto VBA.

```js
function accessVbaMacro() {
    let presentation = new aspose.slides.Presentation("vba_macro.pptm");
    try {
        // Assumindo que a apresentação possui ao menos um módulo VBA.
        let firstModule = presentation.getVbaProject().getModules().get_Item(0);
    } finally {
        presentation.dispose();
    }
}
```

## **Remover uma macro VBA**

Exclua um módulo do projeto VBA.

```js
function removeVbaMacro() {
    let presentation = new aspose.slides.Presentation("vba_macro.pptm");
    try {
        // Assumindo que a apresentação possui ao menos um módulo VBA.
        let firstModule = presentation.getVbaProject().getModules().get_Item(0);

        presentation.getVbaProject().getModules().remove(firstModule);

        presentation.save("vba_macro_removed.pptm", aspose.slides.SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```