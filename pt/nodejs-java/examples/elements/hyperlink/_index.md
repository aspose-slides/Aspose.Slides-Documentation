---
title: Hiperlink
type: docs
weight: 130
url: /pt/nodejs-java/examples/elements/hyperlink/
keywords:
- exemplo de código
- hiperlink
- PowerPoint
- OpenDocument
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Adicione e gerencie hiperlinks no Aspose.Slides para Node.js: vincule texto, formas e imagens, defina destinos e ações para PPT, PPTX e ODP com exemplos."
---
Este artigo demonstra como adicionar, acessar, remover e atualizar hiperlinks em formas usando **Aspose.Slides for Node.js via Java**.

## **Adicionar um hiperlink**

Crie uma forma retangular com um hiperlink apontando para um site externo.

```js
function addHyperlink() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 50);
        shape.getTextFrame().setText("Aspose");

        let paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
        let textPortion = paragraph.getPortions().get_Item(0);

        let hyperlink = new aspose.slides.Hyperlink("https://www.aspose.com");
        textPortion.getPortionFormat().setHyperlinkClick(hyperlink);

        presentation.save("hyperlink.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Acessar um hiperlink**

Leia o hiperlink da parte de texto de uma forma.

```js
function accessHyperlink() {
    let presentation = new aspose.slides.Presentation("hyperlink.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Assumindo que a primeira forma contém o texto com hiperlink.
        let shape = slide.getShapes().get_Item(0);

        let paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
        let textPortion = paragraph.getPortions().get_Item(0);

        let hyperlink = textPortion.getPortionFormat().getHyperlinkClick();
    } finally {
        presentation.dispose();
    }
}
```

## **Remover um hiperlink**

Remova o hiperlink do texto de uma forma.

```js
function removeHyperlink() {
    let presentation = new aspose.slides.Presentation("hyperlink.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Assumindo que a primeira forma contém o texto com hiperlink.
        let shape = slide.getShapes().get_Item(0);

        let paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
        let textPortion = paragraph.getPortions().get_Item(0);

        textPortion.getPortionFormat().setHyperlinkClick(null);

        presentation.save("hyperlink_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Atualizar um hiperlink**

Altere o destino de um hiperlink existente. Use `HyperlinkManager` para modificar o texto que já contém um hiperlink, simulando como o PowerPoint atualiza hiperlinks de forma segura.

```js
function updateHyperlink() {
    let presentation = new aspose.slides.Presentation("hyperlink.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Assumindo que a primeira forma contém o texto com hiperlink.
        let shape = slide.getShapes().get_Item(0);

        let paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
        let textPortion = paragraph.getPortions().get_Item(0);

        // Alterar um hiperlink dentro do texto existente deve ser feito via
        // HyperlinkManager em vez de definir a propriedade diretamente.
        // Isso imita como o PowerPoint atualiza hiperlinks de forma segura.
        textPortion.getPortionFormat().getHyperlinkManager().setExternalHyperlinkClick("https://new.example.com");

        presentation.save("hyperlink_updated.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```