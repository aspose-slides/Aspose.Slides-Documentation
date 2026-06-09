---
title: Transição de Slide
type: docs
weight: 110
url: /pt/androidjava/examples/elements/slide-transition/
keywords:
- exemplo de código
- transição de slide
- PowerPoint
- OpenDocument
- apresentação
- Android
- Java
- Aspose.Slides
description: "Domine as transições de slide no Aspose.Slides para Android: adicione, personalize e sequencie efeitos e durações com exemplos Java para apresentações PPT, PPTX e ODP."
---
Este artigo demonstra a aplicação de efeitos de transição de slides e tempos com **Aspose.Slides for Android via Java**.

## **Adicionar uma Transição de Slide**

Aplicar um efeito de transição de desbotamento ao primeiro slide.

```java
static void addSlideTransition() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Aplicar uma transição de desvanecimento.
        slide.getSlideShowTransition().setType(TransitionType.Fade);
    } finally {
        presentation.dispose();
    }
}
```

## **Acessar uma Transição de Slide**

Ler o tipo de transição atualmente atribuído a um slide.

```java
static void accessSlideTransition() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getSlideShowTransition().setType(TransitionType.Push);

        // Acessar o tipo de transição.
        int type = slide.getSlideShowTransition().getType();
    } finally {
        presentation.dispose();
    }
}
```

## **Remover uma Transição de Slide**

Limpar qualquer efeito de transição definindo o tipo como `None`.

```java
static void removeSlideTransition() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getSlideShowTransition().setType(TransitionType.Fade);

        // Remover a transição definindo None.
        slide.getSlideShowTransition().setType(TransitionType.None);
    } finally {
        presentation.dispose();
    }
}
```

## **Definir Duração da Transição**

Especificar quanto tempo o slide é exibido antes de avançar automaticamente.

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