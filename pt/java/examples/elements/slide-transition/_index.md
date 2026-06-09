---
title: Transição de Slide
type: docs
weight: 110
url: /pt/java/examples/elements/slide-transition/
keywords:
- exemplo de código
- transição de slide
- PowerPoint
- OpenDocument
- apresentação
- Java
- Aspose.Slides
description: "Domine as transições de slide no Aspose.Slides for Java: adicione, personalize e organize efeitos e durações com exemplos Java para apresentações PPT, PPTX e ODP."
---
Este artigo demonstra como aplicar efeitos de transição de slides e tempos com **Aspose.Slides for Java**.

## **Adicionar uma Transição de Slide**

Aplique um efeito de transição de fade ao primeiro slide.

```java
static void addSlideTransition() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Aplique uma transição de fade.
    } finally {
        presentation.dispose();
    }
}
```

## **Acessar uma Transição de Slide**

Leia o tipo de transição atualmente atribuído a um slide.

```java
static void accessSlideTransition() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getSlideShowTransition().setType(TransitionType.Push);

        // Acesse o tipo de transição.
        int type = slide.getSlideShowTransition().getType();
    } finally {
        presentation.dispose();
    }
}
```

## **Remover uma Transição de Slide**

Remova qualquer efeito de transição definindo o tipo como `None`.

```java
static void removeSlideTransition() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getSlideShowTransition().setType(TransitionType.Fade);

        // Remova a transição definindo None.
        slide.getSlideShowTransition().setType(TransitionType.None);
    } finally {
        presentation.dispose();
    }
}
```

## **Definir Duração da Transição**

Especifique por quanto tempo o slide é exibido antes de avançar automaticamente.

```java
static void setTransitionDuration() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getSlideShowTransition().setAdvanceOnClick(true);
        slide.getSlideShowTransition().setAdvanceAfterTime(2000); // em milissegundos.
    } finally {
        presentation.dispose();
    }
}
```