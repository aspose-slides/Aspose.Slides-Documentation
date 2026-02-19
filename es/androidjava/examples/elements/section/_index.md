---
title: Sección
type: docs
weight: 90
url: /es/androidjava/examples/elements/section/
keywords:
- ejemplo de código
- sección
- PowerPoint
- OpenDocument
- presentación
- Android
- Java
- Aspose.Slides
description: "Administre secciones de diapositivas en Aspose.Slides para Android: cree, renombre, reordene y agrupe diapositivas con ejemplos en Java para PPT, PPTX y ODP."
---
Ejemplos para gestionar secciones de presentación—agregar, acceder, eliminar y renombrar programáticamente usando **Aspose.Slides for Android via Java**.

## **Agregar una sección**

Cree una sección que comience en una diapositiva específica.

```java
static void addSection() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Especifique la diapositiva que marca el inicio de la sección.
        presentation.getSections().addSection("New Section", slide);
    } finally {
        presentation.dispose();
    }
}
```

## **Acceder a una sección**

Lea la información de la sección de una presentación.

```java
static void accessSection() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        presentation.getSections().addSection("My Section", slide);

        // Acceda a una sección por índice.
        ISection section = presentation.getSections().get_Item(0);
        String sectionName = section.getName();
    } finally {
        presentation.dispose();
    }
}
```

## **Eliminar una sección**

Elimine una sección añadida previamente.

```java
static void removeSection() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        ISection section = presentation.getSections().addSection("Temporary Section", slide);

        // Eliminar la primera sección.
        presentation.getSections().removeSection(section);
    } finally {
        presentation.dispose();
    }
}
```

## **Renombrar una sección**

Cambie el nombre de una sección existente.

```java
static void renameSection() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        presentation.getSections().addSection("Old Name", slide);

        ISection section = presentation.getSections().get_Item(0);
        section.setName("New Name");
    } finally {
        presentation.dispose();
    }
}
```