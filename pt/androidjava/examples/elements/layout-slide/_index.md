---
title: Slide de Layout
type: docs
weight: 20
url: /pt/androidjava/examples/elements/layout-slide/
keywords:
- exemplo de código
- slide de layout
- PowerPoint
- OpenDocument
- apresentação
- Android
- Java
- Aspose.Slides
description: "Domine slides de layout no Aspose.Slides para Android: escolha, aplique e personalize layouts de slides, marcadores de posição e mestres com exemplos em Java para apresentações PPT, PPTX e ODP."
---
Este artigo demonstra como trabalhar com **Layout Slides** no Aspose.Slides para Android via Java. Um slide de layout define o design e a formatação herdados pelos slides normais. Você pode adicionar, acessar, clonar e remover slides de layout, além de limpar os não utilizados para reduzir o tamanho da apresentação.

## **Adicionar um Slide de Layout**

Você pode criar um slide de layout personalizado para definir formatação reutilizável. Por exemplo, pode adicionar uma caixa de texto que aparece em todos os slides que utilizam este layout.

```java
static void addLayoutSlide() {
    Presentation presentation = new Presentation();
    try {
        IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

        // Crie um slide de layout com um tipo de layout em branco e um nome personalizado.
        ILayoutSlide layoutSlide = presentation.getLayoutSlides().add(masterSlide, SlideLayoutType.Blank, "Main layout");

        // Adicione uma caixa de texto ao slide de layout.
        IAutoShape layoutTextBox = layoutSlide.getShapes().addAutoShape(ShapeType.Rectangle, 75, 75, 150, 150);
        layoutTextBox.getTextFrame().setText("Layout Slide Text");

        // Adicione dois slides usando este layout; ambos herdarão o texto do layout.
        presentation.getSlides().addEmptySlide(layoutSlide);
        presentation.getSlides().addEmptySlide(layoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Nota 1:** Slides de layout funcionam como modelos para slides individuais. Você pode definir elementos comuns uma vez e reutilizá‑los em vários slides.

> 💡 **Nota 2:** Quando você adiciona formas ou texto a um slide de layout, todos os slides baseados nesse layout exibirão esse conteúdo compartilhado automaticamente.

> A captura de tela abaixo mostra dois slides, cada um herdando uma caixa de texto do mesmo slide de layout.

![Slides Herdando Conteúdo do Layout](layout-slide-result.png)

## **Acessar um Slide de Layout**

```java
static void accessLayoutSlide() {
    Presentation presentation = new Presentation();
    try {
        // Acesse um slide de layout por índice.
        ILayoutSlide firstLayoutSlide = presentation.getLayoutSlides().get_Item(0);

        // Acesse um slide de layout por tipo.
        ILayoutSlide blankLayoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);
    } finally {
        presentation.dispose();
    }
}
```

## **Remover um Slide de Layout**

```java
static void removeLayoutSlide() {
    Presentation presentation = new Presentation();
    try {
        // Obtenha um slide de layout por tipo e remova-o.
        ILayoutSlide blankLayoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Custom);
        presentation.getLayoutSlides().remove(blankLayoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

## **Remover Slides de Layout Não Utilizados**

```java
static void removeUnusedLayoutSlides() {
    Presentation presentation = new Presentation();
    try {
        // Remove automaticamente todos os slides de layout que não são referenciados por nenhum slide.
        presentation.getLayoutSlides().removeUnused();
    } finally {
        presentation.dispose();
    }
}
```

## **Clonar um Slide de Layout**

```java
static void cloneLayoutSlides() {
    Presentation presentation = new Presentation();
    try {
        // Obtenha um slide de layout existente por tipo.
        ILayoutSlide blankLayoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);

        // Clone o slide de layout para o final da coleção de slides de layout.
        ILayoutSlide clonedLayoutSlide = presentation.getLayoutSlides().addClone(blankLayoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

> ✅ **Resumo:** Slides de layout são ferramentas poderosas para gerenciar formatação consistente em todos os slides. Aspose.Slides permite controle total sobre a criação, gerenciamento e otimização de slides de layout.