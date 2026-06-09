---
title: Slide
type: docs
weight: 10
url: /pt/androidjava/examples/elements/slide/
keywords:
- exemplo de código
- slide
- PowerPoint
- OpenDocument
- apresentação
- Android
- Java
- Aspose.Slides
description: "Controle de slides no Aspose.Slides para Android: crie, clone, reorganize, redimensione, defina fundos e aplique transições com Java para apresentações PPT, PPTX e ODP."
---
Este artigo fornece uma série de exemplos que demonstram como trabalhar com slides usando **Aspose.Slides for Android via Java**. Você aprenderá como adicionar, acessar, clonar, reordenar e remover slides usando a classe `Presentation`.

Cada exemplo abaixo inclui uma breve explicação seguida de um trecho de código em Java.

## **Adicionar um Slide**

Para adicionar um novo slide, você deve primeiro selecionar um layout. Neste exemplo, usamos o layout `Blank` e adicionamos um slide vazio à apresentação.

```java
static void addSlide() {
    Presentation presentation = new Presentation();
    try {
        ILayoutSlide blankLayout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);

        presentation.getSlides().addEmptySlide(blankLayout);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Observação:** Cada layout de slide é derivado de um slide mestre, que define o design geral e a estrutura de marcadores de posição. A imagem abaixo ilustra como os slides mestres e seus layouts associados são organizados no PowerPoint.

![Relação entre Mestre e Layout](master-layout-slide.png)

## **Acessar Slides por Índice**

Você pode acessar slides usando seu índice, ou encontrar o índice de um slide com base em uma referência. Isso é útil para iterar ou modificar slides específicos.

```java
static void accessSlide() {
    Presentation presentation = new Presentation();
    try {
        // Adicione outro slide vazio.
        ILayoutSlide blankLayout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);
        presentation.getSlides().addEmptySlide(blankLayout);

        // Acesse slides por índice.
        ISlide firstSlide = presentation.getSlides().get_Item(0);
        ISlide secondSlide = presentation.getSlides().get_Item(1);

        // Obtenha o índice do slide a partir de uma referência, então acesse-o por índice.
        int secondSlideIndex = presentation.getSlides().indexOf(secondSlide);
        ISlide secondSlideByIndex = presentation.getSlides().get_Item(secondSlideIndex);
    } finally {
        presentation.dispose();
    }
}
```

## **Clonar um Slide**

Este exemplo demonstra como clonar um slide existente. O slide clonado é adicionado automaticamente ao final da coleção de slides.

```java
static void cloneSlide() {
    Presentation presentation = new Presentation();
    try {
        ISlide firstSlide = presentation.getSlides().get_Item(0);

        ISlide clonedSlide = presentation.getSlides().addClone(firstSlide);

        int clonedSlideIndex = presentation.getSlides().indexOf(clonedSlide);
    } finally {
        presentation.dispose();
    }
}
```

## **Reordenar Slides**

Você pode mudar a ordem dos slides movendo um para um novo índice. Neste caso, movemos um slide clonado para a primeira posição.

```java
static void reorderSlide() {
    Presentation presentation = new Presentation();
    try {
        ISlide firstSlide = presentation.getSlides().get_Item(0);

        ISlide clonedSlide = presentation.getSlides().addClone(firstSlide);

        presentation.getSlides().reorder(0, clonedSlide);
    } finally {
        presentation.dispose();
    }
}
```

## **Remover um Slide**

Para remover um slide, basta referenciá-lo e chamar `remove`. Este exemplo adiciona um segundo slide e então remove o original, deixando apenas o novo.

```java
static void removeSlide() {
    Presentation presentation = new Presentation();
    try {
        ILayoutSlide blankLayout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);
        ISlide secondSlide = presentation.getSlides().addEmptySlide(blankLayout);

        ISlide firstSlide = presentation.getSlides().get_Item(0);
        presentation.getSlides().remove(firstSlide);
    } finally {
        presentation.dispose();
    }
}
```