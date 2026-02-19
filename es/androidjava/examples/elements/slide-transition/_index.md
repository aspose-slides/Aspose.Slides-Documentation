---
title: Transición de diapositiva
type: docs
weight: 110
url: /es/androidjava/examples/elements/slide-transition/
keywords:
- ejemplo de código
- transición de diapositiva
- PowerPoint
- OpenDocument
- presentación
- Android
- Java
- Aspose.Slides
description: "Domina las transiciones de diapositivas en Aspose.Slides for Android: añade, personaliza y secuencia efectos y duraciones con ejemplos en Java para presentaciones PPT, PPTX y ODP."
---
Este artículo muestra cómo aplicar efectos de transición de diapositivas y temporizaciones con **Aspose.Slides for Android via Java**.

## **Agregar una transición de diapositiva**

Aplicar un efecto de transición de fundido a la primera diapositiva.

```java
static void addSlideTransition() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Aplicar una transición de fundido.
    } finally {
        presentation.dispose();
    }
}
```

## **Acceder a una transición de diapositiva**

Leer el tipo de transición asignado actualmente a una diapositiva.

```java
static void accessSlideTransition() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getSlideShowTransition().setType(TransitionType.Push);

        // Acceder al tipo de transición.
        int type = slide.getSlideShowTransition().getType();
    } finally {
        presentation.dispose();
    }
}
```

## **Eliminar una transición de diapositiva**

Eliminar cualquier efecto de transición estableciendo el tipo a `None`.

```java
static void removeSlideTransition() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getSlideShowTransition().setType(TransitionType.Fade);

        // Eliminar la transición estableciendo None.
        slide.getSlideShowTransition().setType(TransitionType.None);
    } finally {
        presentation.dispose();
    }
}
```

## **Establecer la duración de la transición**

Especificar cuánto tiempo se muestra la diapositiva antes de avanzar automáticamente.

```java
static void setTransitionDuration() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getSlideShowTransition().setAdvanceOnClick(true);
        slide.getSlideShowTransition().setAdvanceAfterTime(2000); // en milisegundos.
    } finally {
        presentation.dispose();
    }
}
```