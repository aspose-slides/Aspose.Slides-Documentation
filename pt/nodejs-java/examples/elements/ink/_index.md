---
title: Tinta
type: docs
weight: 180
url: /pt/nodejs-java/examples/elements/ink/
keywords:
  - exemplo de código
  - tinta
  - PowerPoint
  - OpenDocument
  - apresentação
  - Node.js
  - JavaScript
  - Aspose.Slides
description: "Trabalhe com Tinta no Aspose.Slides for Node.js: desenhe, importe e edite traços, ajuste a cor e a largura, e exporte para PPT, PPTX e ODP usando exemplos."
---
Este artigo apresenta exemplos de acesso a formas de tinta existentes e sua remoção usando **Aspose.Slides for Node.js via Java**.

> ❗ **Nota:** Formas de tinta representam a entrada do usuário a partir de dispositivos especializados. Aspose.Slides não pode criar novos traços de tinta programaticamente, mas você pode ler e modificar a tinta existente.

## **Acessar Tinta**

Recupere a primeira forma de tinta em um slide.

```js
function accessInk() {
    let presentation = new aspose.slides.Presentation("ink.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        let inkShape = null;
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            if (java.instanceOf(shape, "com.aspose.slides.IInk")) {
                inkShape = shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Remover Tinta**

Exclua uma forma de tinta do slide.

```js
function removeInk() {
    let presentation = new aspose.slides.Presentation("ink.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Pressupondo que a forma de tinta seja a primeira forma no slide.
        slide.getShapes().removeAt(0);

        presentation.save("ink_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```