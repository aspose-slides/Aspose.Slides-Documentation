---
title: Slide Mestre
type: docs
weight: 30
url: /pt/nodejs-java/examples/elements/master-slide/
keywords:
- exemplo de código
- slide mestre
- PowerPoint
- OpenDocument
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Explore exemplos de slide mestre do Aspose.Slides para Node.js: crie, edite e estilize mestres, marcadores de posição e temas em PPT, PPTX e ODP com código claro."
---
Os slides mestre formam o nível superior da hierarquia de herança de slides no PowerPoint. Um **slide mestre** define elementos de design comuns, como fundos, logotipos e formatação de texto. Os **slides de layout** herdam dos slides mestre, e os **slides normais** herdam dos slides de layout.

Este artigo demonstra como criar, modificar e gerenciar slides mestre usando Aspose.Slides para Node.js via Java.

## **Adicionar um Slide Mestre**

Este exemplo mostra como criar um novo slide mestre clonando o padrão. Em seguida, adiciona uma faixa com o nome da empresa a todos os slides por meio da herança de layout.

```js
function addMasterSlide() {
    let presentation = new aspose.slides.Presentation();
    try {
        // Clone o slide mestre padrão.
        let defaultMasterSlide = presentation.getMasters().get_Item(0);
        let newMasterSlide = presentation.getMasters().addClone(defaultMasterSlide);

        let textBoxFillType = java.newByte(aspose.slides.FillType.NoFill);

        // Adicione uma faixa com o nome da empresa ao topo do slide mestre.
        let textBox = newMasterSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 0, 0, 720, 25);
        textBox.getTextFrame().setText("Company Name");
        textBox.getFillFormat().setFillType(textBoxFillType);

        let paragraphFillType = java.newByte(aspose.slides.FillType.Solid);
        let paragraphFillColor = java.getStaticFieldValue("java.awt.Color", "BLACK");

        let paragraph = textBox.getTextFrame().getParagraphs().get_Item(0);
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(paragraphFillType);
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(paragraphFillColor);

        // Atribua o novo slide mestre a um slide de layout.
        let layoutSlide = presentation.getLayoutSlides().get_Item(0);
        layoutSlide.setMasterSlide(newMasterSlide);

        // Atribua o slide de layout ao primeiro slide da apresentação.
        presentation.getSlides().get_Item(0).setLayoutSlide(layoutSlide);

        presentation.save("master_slide.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Note 1:** Os slides mestre permitem aplicar uma identidade visual consistente ou elementos de design compartilhados em todos os slides. Qualquer alteração feita no mestre será refletida automaticamente nos slides de layout e nos slides normais dependentes.
> 
> 💡 **Note 2:** Qualquer forma ou formatação adicionada a um slide mestre é herdada pelos slides de layout e, por sua vez, por todos os slides normais que utilizam esses layouts.  
> A imagem abaixo ilustra como uma caixa de texto adicionada em um slide mestre é renderizada automaticamente no slide final.

![Exemplo de Herança de Slide Mestre](master-slide-banner.png)

## **Acessar um Slide Mestre**

Você pode acessar slides mestre usando a coleção mestre da apresentação. Veja como recuperar e trabalhar com eles:

```js
function accessMasterSlide() {
    let presentation = new aspose.slides.Presentation("master_slide.pptx");
    try {
        let firstMasterSlide = presentation.getMasters().get_Item(0);

        // Alterar o tipo de plano de fundo.
        let backgroundType = java.newByte(aspose.slides.BackgroundType.OwnBackground);
        firstMasterSlide.getBackground().setType(backgroundType);
    } finally {
        presentation.dispose();
    }
}
```

## **Remover um Slide Mestre**

Slides mestre podem ser removidos por índice ou por referência.

```js
function removeMasterSlide() {
    let presentation = new aspose.slides.Presentation("master_slide.pptx");
    try {
        // Remover um slide mestre por índice.
        presentation.getMasters().removeAt(0);

        // Remover um slide mestre por referência.
        let firstMasterSlide = presentation.getMasters().get_Item(0);
        presentation.getMasters().remove(firstMasterSlide);

        presentation.save("master_slide_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Remover Slides Mestres Não Utilizados**

Algumas apresentações contêm slides mestre que não são usados. Remover esses slides pode ajudar a reduzir o tamanho do arquivo.

```js
function removeUnusedMasterSlides() {
    let presentation = new aspose.slides.Presentation("master_slide.pptx");
    try {
        // Remover todos os slides mestres não utilizados (mesmo aqueles marcados como Preserve).
        presentation.getMasters().removeUnused(true);

        presentation.save("unused_master_slides_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```