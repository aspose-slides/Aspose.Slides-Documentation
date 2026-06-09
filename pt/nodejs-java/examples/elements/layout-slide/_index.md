---
title: Slide de Layout
type: docs
weight: 20
url: /pt/nodejs-java/examples/elements/layout-slide/
keywords:
- exemplo de código
- slide de layout
- PowerPoint
- OpenDocument
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Domine slides de layout no Aspose.Slides para Node.js: escolha, aplique e personalize layouts de slide, marcadores de posição e mestres com exemplos para apresentações PPT, PPTX e ODP."
---
Este artigo demonstra como trabalhar com **Layout Slides** no Aspose.Slides para Node.js via Java. Um layout slide define o design e a formatação herdados pelos slides normais. Você pode adicionar, acessar, clonar e remover layout slides, bem como limpar os que não são usados para reduzir o tamanho da apresentação.

## **Adicionar um Layout Slide**

Você pode criar um layout slide personalizado para definir formatação reutilizável.

```js
function addLayoutSlide() {
    let presentation = new aspose.slides.Presentation();
    try {
        let masterSlide = presentation.getMasters().get_Item(0);

        // Crie um slide de layout com um tipo de layout em branco e um nome personalizado.
        let layoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
        let layoutSlide = presentation.getLayoutSlides().add(masterSlide, layoutType, "Main layout");

        presentation.save("layout_slide.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Nota 1:** Os layout slides atuam como modelos para slides individuais. Você pode definir elementos comuns uma vez e reutilizá-los em muitos slides.

> 💡 **Nota 2:** Quando você adiciona formas ou texto a um layout slide, todos os slides baseados nesse layout exibirão esse conteúdo compartilhado automaticamente.
> A captura de tela abaixo mostra dois slides, cada um herdando uma caixa de texto do mesmo layout slide.

![Slides Herdando Conteúdo do Layout](layout-slide-result.png)

## **Acessar um Layout Slide**

Os layout slides podem ser acessados por índice ou por tipo de layout (por exemplo, `Blank`, `Title`, `SectionHeader`, etc.).

```js
function accessLayoutSlide() {
    let presentation = new aspose.slides.Presentation("layout_slide.pptx");
    try {
        // Acesse um slide de layout por índice.
        let firstLayoutSlide = presentation.getLayoutSlides().get_Item(0);

        // Acesse um slide de layout por tipo.
        let layoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
        let layoutSlide = presentation.getLayoutSlides().getByType(layoutType);
    } finally {
        presentation.dispose();
    }
}
```

## **Remover um Layout Slide**

Você pode remover um layout slide específico caso ele não seja mais necessário.

```js
function removeLayoutSlide() {
    let presentation = new aspose.slides.Presentation("layout_slide.pptx");
    try {
        // Obtenha um slide de layout por tipo e remova-o.
        let layoutType = java.newByte(aspose.slides.SlideLayoutType.Custom);
        let layoutSlide = presentation.getLayoutSlides().getByType(layoutType);
        presentation.getLayoutSlides().remove(layoutSlide);

        presentation.save("layout_slide_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Remover Layout Slides Não Utilizados**

Para reduzir o tamanho da apresentação, você pode querer remover layout slides que não são usados por nenhum slide normal.

```js
function removeUnusedLayoutSlides() {
    let presentation = new aspose.slides.Presentation();
    try {
        // Remove automaticamente todos os slides de layout que não são referenciados por nenhum slide.
        presentation.getLayoutSlides().removeUnused();

        presentation.save("unused_layout_slides_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Clonar um Layout Slide**

Você pode duplicar um layout slide usando o método `addClone`.

```js
function cloneLayoutSlide() {
    let presentation = new aspose.slides.Presentation("layout_slide.pptx");
    try {
        // Obtenha um slide de layout existente por tipo.
        let layoutType = java.newByte(aspose.slides.SlideLayoutType.Title);
        let layoutSlide = presentation.getLayoutSlides().getByType(layoutType);

        // Clone o slide de layout para o final da coleção de slides de layout.
        let clonedLayoutSlide = presentation.getLayoutSlides().addClone(layoutSlide);

        presentation.save("layout_slide_cloned.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

> ✅ **Resumo:** Os layout slides são ferramentas poderosas para gerenciar formatação consistente em todos os slides. O Aspose.Slides permite controle total sobre a criação, gerenciamento e otimização de layout slides.