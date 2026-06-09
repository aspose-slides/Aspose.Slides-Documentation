---
title: Caixa de Texto
type: docs
weight: 40
url: /pt/nodejs-java/examples/elements/text-box/
keywords:
  - exemplo de código
  - caixa de texto
  - PowerPoint
  - OpenDocument
  - apresentação
  - Node.js
  - JavaScript
  - Aspose.Slides
description: "Trabalhe com caixas de texto no Aspose.Slides para Node.js: adicione, formate, alinhe, ajuste de linha, ajuste automático e estilize o texto usando JavaScript para apresentações PPT, PPTX e ODP."
---
No Aspose.Slides, um **caixa de texto** é representado por um `AutoShape`. Quase qualquer forma pode conter texto, mas uma caixa de texto típica não tem preenchimento nem borda e exibe apenas texto.

Este guia explica como adicionar, acessar e remover caixas de texto programaticamente.

## **Adicionar uma Caixa de Texto**

Uma caixa de texto é simplesmente um `AutoShape` sem preenchimento nem borda e com algum texto formatado. Aqui está como criar uma:

```js
function addTextBox() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Crie uma forma retangular (padrão preenchida com borda e sem texto).
        let textBox = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 75, 150, 100);

        // Remova o preenchimento e a borda para que pareça uma caixa de texto típica.
        let boxFillType = java.newByte(aspose.slides.FillType.NoFill);
        textBox.getFillFormat().setFillType(boxFillType);
        textBox.getLineFormat().getFillFormat().setFillType(boxFillType);

        // Defina a formatação do texto.
        let paragraph = textBox.getTextFrame().getParagraphs().get_Item(0);
        let textFormat = paragraph.getParagraphFormat().getDefaultPortionFormat();
        let textFillType = java.newByte(aspose.slides.FillType.Solid);
        let textFillColor = java.getStaticFieldValue("java.awt.Color", "BLACK");
        textFormat.getFillFormat().setFillType(textFillType);
        textFormat.getFillFormat().getSolidFillColor().setColor(textFillColor);

        // Atribua o conteúdo real do texto.
        textBox.getTextFrame().setText("Some text...");

        presentation.save("text_box.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Observação:** Qualquer `AutoShape` que contém um `TextFrame` não vazio pode funcionar como uma caixa de texto.

## **Acessar uma Caixa de Texto**

Recupere a primeira caixa de texto do slide.

```js
function accessTextBox() {
    let presentation = new aspose.slides.Presentation("text_box.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        let firstTextBox = null;
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            // Somente AutoShapes podem conter texto editável.
            if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                firstTextBox = shape;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Remover Caixas de Texto por Conteúdo**

Este exemplo encontra e exclui todas as caixas de texto no primeiro slide que contêm uma palavra‑chave específica:

```js
function removeTextBoxes() {
    let presentation = new aspose.slides.Presentation("text_box.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        let shapesToRemove = [];
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                let autoShape = shape;
                if (autoShape.getTextFrame().getText().includes("Slide")) {
                    shapesToRemove.push(shape);
                }
            }
        }

        for (let i = 0; i < shapesToRemove.length; i++) {
            slide.getShapes().remove(shapesToRemove[i]);
        }

        presentation.save("text_boxes_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Dica:** Sempre crie uma cópia da coleção de formas antes de modificá‑la durante a iteração para evitar erros de modificação da coleção.