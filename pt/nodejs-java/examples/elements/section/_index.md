---
title: Seção
type: docs
weight: 90
url: /pt/nodejs-java/examples/elements/section/
keywords:
- exemplo de código
- seção
- PowerPoint
- OpenDocument
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Gerencie seções de slides no Aspose.Slides para Node.js via Java: crie, renomeie, reordene e agrupe slides com exemplos em JavaScript para PPT, PPTX e ODP."
---
Exemplos de gerenciamento de seções de apresentação — adicionar, acessar, remover e renomear programaticamente usando **Aspose.Slides for Node.js via Java**.

## **Adicionar uma Seção**

Crie uma seção que começa em um slide específico.

```js
function addSection() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Especifique o slide que marca o início da seção.
        presentation.getSections().addSection("New Section", slide);

        presentation.save("section.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Acessar uma Seção**

Leia as informações da seção de uma apresentação.

```js
function accessSection() {
    let presentation = new aspose.slides.Presentation("section.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Acesse uma seção por índice.
        let section = presentation.getSections().get_Item(0);
        let sectionName = section.getName();
    } finally {
        presentation.dispose();
    }
}
```

## **Remover uma Seção**

Exclua uma seção adicionada anteriormente.

```js
function removeSection() {
    let presentation = new aspose.slides.Presentation("section.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Remova a primeira seção.
        let section = presentation.getSections().get_Item(0);
        presentation.getSections().removeSection(section);

        presentation.save("section_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Renomear uma Seção**

Altere o nome de uma seção existente.

```js
function renameSection() {
    let presentation = new aspose.slides.Presentation("section.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        let section = presentation.getSections().get_Item(0);
        section.setName("New Name");

        presentation.save("section_renamed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```