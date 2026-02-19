---
title: Sección
type: docs
weight: 90
url: /es/java/examples/elements/section/
keywords:
- ejemplo de código
- sección
- PowerPoint
- OpenDocument
- presentación
- Java
- Aspose.Slides
description: "Gestionar secciones de diapositivas en Aspose.Slides for Java: crear, renombrar, reordenar y agrupar diapositivas con ejemplos en Java para PPT, PPTX y ODP."
---
Ejemplos de cómo gestionar secciones de una presentación—agregar, acceder, eliminar y renombrar programáticamente usando **Aspose.Slides for Java**.

## **Agregar una sección**

Crea una sección que comience en una diapositiva específica.

```java
static void addSection() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Especifica la diapositiva que marca el comienzo de la sección.
        presentation.getSections().addSection("New Section", slide);
    } finally {
        presentation.dispose();
    }
}
```

## **Acceder a una sección**

Lee la información de la sección de una presentación.

```java
static void accessSection() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        presentation.getSections().addSection("My Section", slide);

        // Acceder a una sección por índice.
        ISection section = presentation.getSections().get_Item(0);
        String sectionName = section.getName();
    } finally {
        presentation.dispose();
    }
}
```

## **Eliminar una sección**

Elimina una sección añadida previamente.

```java
static void removeSection() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        ISection section = presentation.getSections().addSection("Temporary Section", slide);

        // Elimina la primera sección.
        presentation.getSections().removeSection(section);
    } finally {
        presentation.dispose();
    }
}
```

## **Renombrar una sección**

Cambia el nombre de una sección existente.

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