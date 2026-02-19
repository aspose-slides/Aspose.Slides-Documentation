---
title: Diapositiva
type: docs
weight: 10
url: /es/androidjava/examples/elements/slide/
keywords:
- ejemplo de código
- diapositiva
- PowerPoint
- OpenDocument
- presentación
- Android
- Java
- Aspose.Slides
description: "Controla las diapositivas en Aspose.Slides para Android: crea, clona, reordena, redimensiona, establece fondos y aplica transiciones con Java para presentaciones PPT, PPTX y ODP."
---
Este artículo presenta una serie de ejemplos que demuestran cómo trabajar con diapositivas usando **Aspose.Slides for Android via Java**. Aprenderá a agregar, acceder, clonar, reordenar y eliminar diapositivas utilizando la clase `Presentation`.

Cada ejemplo a continuación incluye una breve explicación seguida de un fragmento de código en Java.

## **Add a Slide**

Para agregar una nueva diapositiva, primero debe seleccionar un diseño. En este ejemplo, utilizamos el diseño `Blank` y añadimos una diapositiva vacía a la presentación.

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

> 💡 **Nota:** Cada diseño de diapositiva se deriva de una diapositiva maestra, que define el diseño general y la estructura de los marcadores de posición. La imagen a continuación muestra cómo se organizan las diapositivas maestras y sus diseños asociados en PowerPoint.

![Master and Layout Relationship](master-layout-slide.png)

## **Access Slides by Index**

Puede acceder a las diapositivas mediante su índice, o encontrar el índice de una diapositiva basándose en una referencia. Esto es útil para iterar o modificar diapositivas específicas.

```java
static void accessSlide() {
    Presentation presentation = new Presentation();
    try {
        // Añade otra diapositiva vacía.
        ILayoutSlide blankLayout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);
        presentation.getSlides().addEmptySlide(blankLayout);

        // Accede a las diapositivas por índice.
        ISlide firstSlide = presentation.getSlides().get_Item(0);
        ISlide secondSlide = presentation.getSlides().get_Item(1);

        // Obtén el índice de la diapositiva a partir de una referencia y luego accede a ella por índice.
        int secondSlideIndex = presentation.getSlides().indexOf(secondSlide);
        ISlide secondSlideByIndex = presentation.getSlides().get_Item(secondSlideIndex);
    } finally {
        presentation.dispose();
    }
}
```

## **Clone a Slide**

Este ejemplo muestra cómo clonar una diapositiva existente. La diapositiva clonada se añade automáticamente al final de la colección de diapositivas.

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

## **Reorder Slides**

Puede cambiar el orden de las diapositivas moviendo una a un nuevo índice. En este caso, movemos una diapositiva clonada a la primera posición.

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

## **Remove a Slide**

Para eliminar una diapositiva, simplemente haga referencia a ella y llame a `remove`. Este ejemplo añade una segunda diapositiva y luego elimina la original, quedando solo la nueva.

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