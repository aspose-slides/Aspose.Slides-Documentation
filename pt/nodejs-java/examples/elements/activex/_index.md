---
title: ActiveX
type: docs
weight: 200
url: /pt/nodejs-java/examples/elements/activex/
keywords:
- exemplo de código
- ActiveX
- PowerPoint
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Veja exemplos de ActiveX do Aspose.Slides for Node.js: inserir, configurar e controlar objetos ActiveX em apresentações PPT e PPTX com código JavaScript claro."
---
Este artigo demonstra como adicionar, acessar, remover e configurar controles ActiveX em uma apresentação usando **Aspose.Slides for Node.js via Java**.

## **Adicionar um Controle ActiveX**

Adicione um novo controle ActiveX a um slide.

```js
function addActiveX() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Adicionar um novo controle ActiveX.
        let control = slide.getControls().addControl(aspose.slides.ControlType.WindowsMediaPlayer, 50, 50, 100, 50);

        presentation.save("activex.pptm", aspose.slides.SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```

## **Acessar um Controle ActiveX**

Leia informações do primeiro controle ActiveX no slide.

```js
function accessActiveX() {
    let presentation = new aspose.slides.Presentation("activex.pptm");
    try {
        let slide = presentation.getSlides().get_Item(0);

        if (slide.getControls().size() > 0) {
            // Acessar o primeiro controle ActiveX.
            let control = slide.getControls().get_Item(0);

            console.log("Control Name:", control.getName());
            console.log("Value:", control.getProperties().get_Item("Value"));
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Remover um Controle ActiveX**

Exclua um controle ActiveX existente do slide.

```js
function removeActiveX() {
    let presentation = new aspose.slides.Presentation("activex.pptm");
    try {
        let slide = presentation.getSlides().get_Item(0);

        if (slide.getControls().size() > 0) {
            // Remover o primeiro controle ActiveX.
            slide.getControls().removeAt(0);
        }

        presentation.save("activex_removed.pptm", aspose.slides.SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```

## **Definir Propriedades do ActiveX**

Configure várias propriedades do ActiveX.

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