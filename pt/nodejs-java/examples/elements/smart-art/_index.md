---
title: SmartArt
type: docs
weight: 140
url: /pt/nodejs-java/examples/elements/smart-art/
keywords:
  - exemplo de código
  - SmartArt
  - PowerPoint
  - OpenDocument
  - apresentação
  - Node.js
  - JavaScript
  - Aspose.Slides
description: "Trabalhe com SmartArt no Aspose.Slides for Node.js: crie, edite, converta e estilize diagramas com JavaScript para apresentações PowerPoint e OpenDocument."
---
Este artigo demonstra como adicionar gráficos SmartArt, acessá-los, removê-los e alterar layouts usando **Aspose.Slides for Node.js via Java**.

## **Adicionar SmartArt**

Insira um gráfico SmartArt usando um dos layouts incorporados.

```js
function addSmartArt() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        let smartArt = slide.getShapes().addSmartArt(50, 50, 400, 300, aspose.slides.SmartArtLayoutType.BasicProcess);

        presentation.save("smartart.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Acessar SmartArt**

Recupere o primeiro objeto SmartArt em um slide.

```js
function accessSmartArt() {
    let presentation = new aspose.slides.Presentation("smartart.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        let firstSmartArt = null;
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
                firstSmartArt = shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Remover SmartArt**

Exclua uma forma SmartArt do slide.

```js
function removeSmartArt() {
    let presentation = new aspose.slides.Presentation("smartart.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Assumindo que a primeira forma é SmartArt.
        let smartArt = slide.getShapes().get_Item(0);

        slide.getShapes().remove(smartArt);

        presentation.save("smartart_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Alterar Layout do SmartArt**

Atualize o tipo de layout de um gráfico SmartArt existente.

```js
function changeSmartArtLayout() {
    let presentation = new aspose.slides.Presentation("smartart.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Pressupondo que a primeira forma é SmartArt.
        let smartArt = slide.getShapes().get_Item(0);

        smartArt.setLayout(aspose.slides.SmartArtLayoutType.VerticalPictureList);

        presentation.save("smartart_layout_changed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```