---
title: Diapositiva
type: docs
weight: 10
url: /es/nodejs-java/examples/elements/slide/
keywords:
- ejemplo de código
- diapositiva
- PowerPoint
- OpenDocument
- presentación
- Node.js
- JavaScript
- Aspose.Slides
description: "Controla diapositivas en Aspose.Slides para Node.js: crea, clona, reordena, redimensiona, establece fondos y aplica transiciones para presentaciones PPT, PPTX y ODP."
---
Este artículo proporciona una serie de ejemplos que demuestran cómo trabajar con diapositivas usando **Aspose.Slides for Node.js via Java**. Aprenderás a añadir, acceder, clonar, reordenar y eliminar diapositivas utilizando la clase `Presentation`.

Cada ejemplo a continuación incluye una breve explicación seguida de un fragmento de código en JavaScript.

## **Añadir una diapositiva**

Para añadir una nueva diapositiva, primero debes seleccionar un diseño. En este ejemplo, usamos el diseño `Blank` y añadimos una diapositiva vacía a la presentación.

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

> 💡 **Nota:** Cada diseño de diapositiva se deriva de una diapositiva maestra, que define el diseño general y la estructura de los marcadores de posición. La imagen a continuación muestra cómo se organizan las diapositivas maestras y sus diseños asociados en PowerPoint.

![Relación entre maestra y diseño](master-layout-slide.png)

## **Acceder a diapositivas por índice**

Puedes acceder a las diapositivas mediante su índice. Esto es útil para iterar o modificar diapositivas específicas.

```js
function accessSlide() {
    let presentation = new aspose.slides.Presentation("slide.pptx");
    try {
        // Acceder a una diapositiva por índice.
        let firstSlide = presentation.getSlides().get_Item(0);
    } finally {
        presentation.dispose();
    }
}
```

## **Clonar una diapositiva**

Este ejemplo muestra cómo clonar una diapositiva existente. La diapositiva clonada se añade automáticamente al final de la colección de diapositivas.

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

## **Reordenar diapositivas**

Puedes cambiar el orden de las diapositivas moviendo una a un nuevo índice. En este caso, movemos una diapositiva a la primera posición.

```js
function reorderSlide() {
    let presentation = new aspose.slides.Presentation("slide.pptx");
    try {
        // Reordenar diapositivas moviendo la segunda diapositiva a la primera posición.
        let secondSlide = presentation.getSlides().get_Item(1);
        presentation.getSlides().reorder(0, secondSlide);

        presentation.save("slide_reordered.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Eliminar una diapositiva**

Para eliminar una diapositiva, simplemente haz referencia a ella y llama a `remove`. Este ejemplo añade una segunda diapositiva y luego elimina la original, dejando solo la nueva.

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