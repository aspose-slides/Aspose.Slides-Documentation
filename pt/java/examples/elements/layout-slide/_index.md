---
title: Slide de Layout
type: docs
weight: 20
url: /pt/java/examples/elements/layout-slide/
keywords:
- exemplo de código
- slide de layout
- PowerPoint
- OpenDocument
- apresentação
- Java
- Aspose.Slides
description: "Slides mestres de layout no Aspose.Slides para Java: escolha, aplique e personalize layouts de slides, espaços reservados e mestres com exemplos Java para apresentações PPT, PPTX e ODP."
---
Este artigo demonstra como trabalhar com **Layout Slides** no Aspose.Slides para Java. Um slide de layout define o design e a formatação herdados pelos slides normais. Você pode adicionar, acessar, clonar e remover slides de layout, além de limpar os que não são usados para reduzir o tamanho da apresentação.

## **Adicionar um Slide de Layout**

Você pode criar um slide de layout personalizado para definir formatação reutilizável. Por exemplo, pode adicionar uma caixa de texto que aparece em todos os slides que usam esse layout.

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

> 💡 **Nota 1:** Slides de layout atuam como modelos para slides individuais. Você pode definir elementos comuns uma única vez e reutilizá‑los em muitos slides.

> 💡 **Nota 2:** Quando você adiciona formas ou texto a um slide de layout, todos os slides baseados nesse layout exibirão esse conteúdo compartilhado automaticamente.
> A captura de tela abaixo mostra dois slides, cada um herdando uma caixa de texto do mesmo slide de layout.

![Slides Inheriting Layout Content](layout-slide-result.png)

## **Acessar um Slide de Layout**

Slides de layout podem ser acessados por índice ou por tipo de layout (por exemplo, `Blank`, `Title`, `SectionHeader`, etc.).

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

Você pode remover um slide de layout específico se ele não for mais necessário.

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

Para reduzir o tamanho da apresentação, pode ser desejável remover slides de layout que não são usados por nenhum slide normal.

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

Você pode duplicar um slide de layout usando o método `addClone`.

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

> ✅ **Resumo:** Slides de layout são ferramentas poderosas para gerenciar formatação consistente em slides. Aspose.Slides permite controle total sobre a criação, gerenciamento e otimização de slides de layout.