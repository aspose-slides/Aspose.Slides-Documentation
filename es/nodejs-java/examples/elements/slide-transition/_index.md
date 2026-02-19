---
title: Transición de diapositiva
type: docs
weight: 110
url: /es/nodejs-java/examples/elements/slide-transition/
keywords:
- ejemplo de código
- transición de diapositiva
- PowerPoint
- OpenDocument
- presentación
- Node.js
- JavaScript
- Aspose.Slides
description: "Domina las transiciones de diapositivas en Aspose.Slides para Node.js: agrega, personaliza y secuencia efectos y duraciones con ejemplos para presentaciones PPT, PPTX y ODP."
---
Este artículo muestra cómo aplicar efectos de transición de diapositivas y tiempos con **Aspose.Slides for Node.js via Java**.

## **Añadir una transición de diapositiva**
Aplica un efecto de transición de desvanecimiento a la primera diapositiva.

```js
function addSlideTransition() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Aplicar una transición de desvanecimiento.
        slide.getSlideShowTransition().setType(aspose.slides.TransitionType.Fade);

        presentation.save("slide_transition.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Acceder a una transición de diapositiva**
Lee el tipo de transición asignado actualmente a una diapositiva.

```js
function accessSlideTransition() {
    let presentation = new aspose.slides.Presentation("slide_transition.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Acceder al tipo de transición.
        let type = slide.getSlideShowTransition().getType();
    } finally {
        presentation.dispose();
    }
}
```

## **Eliminar una transición de diapositiva**
Elimina cualquier efecto de transición estableciendo el tipo a `None`.

```js
function removeSlideTransition() {
    let presentation = new aspose.slides.Presentation("slide_transition.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Eliminar la transición estableciendo ninguno.
        slide.getSlideShowTransition().setType(aspose.slides.TransitionType.None);

        presentation.save("slide_transition_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Establecer la duración de la transición**
Especifica cuánto tiempo se muestra la diapositiva antes de avanzar automáticamente.

```js
function setTransitionDuration() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        slide.getSlideShowTransition().setAdvanceOnClick(true);
        slide.getSlideShowTransition().setAdvanceAfterTime(2000); // en milisegundos.

        presentation.save("slide_transition_duration.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```