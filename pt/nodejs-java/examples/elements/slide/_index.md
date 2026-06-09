---
title: Slide
type: docs
weight: 10
url: /pt/nodejs-java/examples/elements/slide/
keywords:
- exemplo de código
- slide
- PowerPoint
- OpenDocument
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Controle slides no Aspose.Slides para Node.js: crie, clone, reordene, redimensione, defina fundos e aplique transições para apresentações PPT, PPTX e ODP."
---
Este artigo fornece uma série de exemplos que demonstram como trabalhar com slides usando **Aspose.Slides for Node.js via Java**. Você aprenderá a adicionar, acessar, clonar, reorganizar e remover slides usando a classe `Presentation`.

Cada exemplo abaixo inclui uma breve explicação seguida por um trecho de código em JavaScript.

## **Adicionar um slide**

Para adicionar um novo slide, você deve primeiro selecionar um layout. Neste exemplo, usamos o layout `Blank` e adicionamos um slide vazio à apresentação.

```js
function addSlide() {
    let presentation = new aspose.slides.Presentation();
    try {
        let layoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
        let layoutSlide = presentation.getLayoutSlides().getByType(layoutType);
        presentation.getSlides().addEmptySlide(layoutSlide);

        presentation.save("slide.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Observação:** Cada layout de slide é derivado de um slide mestre, que define o design geral e a estrutura de espaço reservado. A imagem abaixo ilustra como os slides mestres e seus layouts associados são organizados no PowerPoint.

![Relacionamento entre mestre e layout](master-layout-slide.png)

## **Acessar slides por índice**

Você pode acessar slides usando seu índice. Isso é útil para iterar ou modificar slides específicos.

```js
function accessSlide() {
    let presentation = new aspose.slides.Presentation("slide.pptx");
    try {
        // Acesse um slide por índice.
        let firstSlide = presentation.getSlides().get_Item(0);
    } finally {
        presentation.dispose();
    }
}
```

## **Clonar um slide**

Este exemplo demonstra como clonar um slide existente. O slide clonado é automaticamente adicionado ao final da coleção de slides.

```js
function cloneSlide() {
    let presentation = new aspose.slides.Presentation();
    try {
        let firstSlide = presentation.getSlides().get_Item(0);
        let clonedSlide = presentation.getSlides().addClone(firstSlide);

        presentation.save("slide_cloned.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Reordenar slides**

Você pode alterar a ordem dos slides movendo um para um novo índice. Nesse caso, movemos um slide para a primeira posição.

```js
function reorderSlide() {
    let presentation = new aspose.slides.Presentation("slide.pptx");
    try {
        // Reordene os slides movendo o segundo slide para a primeira posição.
        let secondSlide = presentation.getSlides().get_Item(1);
        presentation.getSlides().reorder(0, secondSlide);

        presentation.save("slide_reordered.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Remover um slide**

Para remover um slide, basta referenciá-lo e chamar `remove`. Este exemplo adiciona um segundo slide e então remove o original, deixando apenas o novo.

```js
function removeSlide() {
    let presentation = new aspose.slides.Presentation("slide.pptx");
    try {
        let firstSlide = presentation.getSlides().get_Item(0);
        presentation.getSlides().remove(firstSlide);

        presentation.save("slide_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```