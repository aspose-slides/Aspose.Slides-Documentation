---
title: Transição de Slide
type: docs
weight: 110
url: /pt/nodejs-java/examples/elements/slide-transition/
keywords:
- exemplo de código
- transição de slide
- PowerPoint
- OpenDocument
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Domine transições de slide no Aspose.Slides for Node.js: adicione, personalize e sequencie efeitos e durações com exemplos para apresentações PPT, PPTX e ODP."
---
Este artigo demonstra a aplicação de efeitos de transição de slides e tempos com **Aspose.Slides for Node.js via Java**.

## **Adicionar uma Transição de Slide**

Aplique um efeito de transição de desvanecimento ao primeiro slide.

```js
function addSlideTransition() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Aplicar uma transição de desvanecimento.
        slide.getSlideShowTransition().setType(aspose.slides.TransitionType.Fade);

        presentation.save("slide_transition.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Acessar uma Transição de Slide**

Leia o tipo de transição atualmente atribuído a um slide.

```js
function accessSlideTransition() {
    let presentation = new aspose.slides.Presentation("slide_transition.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Acessar o tipo de transição.
        let type = slide.getSlideShowTransition().getType();
    } finally {
        presentation.dispose();
    }
}
```

## **Remover uma Transição de Slide**

Remova qualquer efeito de transição definindo o tipo como `None`.

```js
function removeSlideTransition() {
    let presentation = new aspose.slides.Presentation("slide_transition.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Remover a transição definindo None.
        slide.getSlideShowTransition().setType(aspose.slides.TransitionType.None);

        presentation.save("slide_transition_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Definir Duração da Transição**

Especifique quanto tempo o slide é exibido antes de avançar automaticamente.

```js
function setTransitionDuration() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        slide.getSlideShowTransition().setAdvanceOnClick(true);
        slide.getSlideShowTransition().setAdvanceAfterTime(2000); // em milissegundos.

        presentation.save("slide_transition_duration.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```