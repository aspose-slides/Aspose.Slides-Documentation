---
title: Sección
type: docs
weight: 90
url: /es/nodejs-java/examples/elements/section/
keywords:
- ejemplo de código
- sección
- PowerPoint
- OpenDocument
- presentación
- Node.js
- JavaScript
- Aspose.Slides
description: "Gestiona las secciones de diapositivas en Aspose.Slides para Node.js a través de Java: crea, renombra, reordena y agrupa diapositivas con ejemplos de JavaScript para PPT, PPTX y ODP."
---
Ejemplos de gestión de secciones de presentación—agregar, acceder, eliminar y renombrar programáticamente usando **Aspose.Slides for Node.js via Java**.

## **Agregar una sección**

Cree una sección que comienza en una diapositiva específica.

```js
function addSection() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Especifica la diapositiva que marca el comienzo de la sección.
        presentation.getSections().addSection("New Section", slide);

        presentation.save("section.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Acceder a una sección**

Lea la información de la sección de una presentación.

```js
function accessSection() {
    let presentation = new aspose.slides.Presentation("section.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Acceder a una sección por índice.
        let section = presentation.getSections().get_Item(0);
        let sectionName = section.getName();
    } finally {
        presentation.dispose();
    }
}
```

## **Eliminar una sección**

Elimine una sección previamente añadida.

```js
function removeSection() {
    let presentation = new aspose.slides.Presentation("section.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Eliminar la primera sección.
        let section = presentation.getSections().get_Item(0);
        presentation.getSections().removeSection(section);

        presentation.save("section_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Renombrar una sección**

Cambie el nombre de una sección existente.

```js
function renameSection() {
    let presentation = new aspose.slides.Presentation("section.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        let section = presentation.getSections().get_Item(0);
        section.setName("New Name");

        presentation.save("section_renamed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```