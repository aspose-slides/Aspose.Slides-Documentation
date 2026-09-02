---
title: Gestionar secciones de diapositivas en presentaciones con JavaScript
linktitle: Sección de diapositiva
type: docs
weight: 90
url: /es/nodejs-java/slide-section/
keywords:
- crear sección
- añadir sección
- editar sección
- cambiar sección
- nombre de sección
- recuperar diapositivas de sección
- procesar diapositivas de sección
- PowerPoint
- presentación
- Node.js
- JavaScript
- Aspose.Slides
description: "Gestionar secciones de diapositivas con Aspose.Slides para Node.js a través de Java: crear, renombrar, reordenar, recuperar y procesar diapositivas de sección en presentaciones PPTX."
---
## **Introducción**

Las secciones organizan diapositivas consecutivas en grupos con nombre sin modificar el contenido de la diapositiva. Con Aspose.Slides para Node.js a través de Java, puedes crear, reordenar, renombrar, inspeccionar y eliminar secciones mediante el método [Presentation.getSections](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/#getSections).

Las secciones son especialmente útiles cuando:

- una presentación grande necesita dividirse en temas o capítulos lógicos;
- diferentes grupos de diapositivas se asignan a distintos colaboradores;
- las diapositivas necesitan ser procesadas, movidas o combinadas como grupos.

Elige nombres de sección concisos que describan el propósito de las diapositivas agrupadas. Dado que las secciones forman parte de la estructura de la presentación, utiliza las API de sección para determinar la pertenencia en lugar de derivarla de las posiciones de las diapositivas.

## **Crear y administrar secciones**

Utiliza [SectionCollection.addSection](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/sectioncollection/#addSection) para crear una sección especificando su nombre y diapositiva inicial. Aspose.Slides determina qué diapositivas pertenecen a la sección a partir de la estructura de secciones actual de la presentación.

El mismo [SectionCollection](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/sectioncollection/) también permite:

- mover una sección junto con sus diapositivas usando [SectionCollection.reorderSectionWithSlides](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/sectioncollection/#reorderSectionWithSlides);
- eliminar solo la definición de la sección con [SectionCollection.removeSection](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/sectioncollection/#removeSection), lo que conserva sus diapositivas;
- eliminar una sección y sus diapositivas con [SectionCollection.removeSectionWithSlides](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/sectioncollection/#removeSectionWithSlides);
- añadir una sección vacía al final con [SectionCollection.appendEmptySection](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/sectioncollection/#appendEmptySection).

El siguiente ejemplo crea dos secciones, mueve una de ellas, la elimina junto con sus diapositivas y añade una sección vacía:

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const titleSlide = presentation.getSlides().get_Item(0);
    const layoutSlide = presentation.getLayoutSlides().get_Item(0);
    presentation.getSlides().addEmptySlide(layoutSlide);
    const resultsSlide = presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);

    presentation.getSections().addSection("Introduction", titleSlide);
    const resultsSection = presentation.getSections().addSection("Results", resultsSlide);

    presentation.getSections().reorderSectionWithSlides(resultsSection, 0);
    presentation.getSections().removeSectionWithSlides(resultsSection);
    presentation.getSections().appendEmptySection("Appendix");
} finally {
    presentation.dispose();
}
```

Después de estas operaciones, la presentación contiene la sección `Introduction` con sus diapositivas y una sección vacía `Appendix`. La sección `Results` y sus diapositivas han sido eliminadas.

## **Renombrar secciones**

Para renombrar una sección, llama a su método [Section.setName](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/section/#setName). Las diapositivas y la posición de la sección permanecen sin cambios.

El siguiente ejemplo crea una sección y cambia su nombre:

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const section = presentation.getSections().addSection("Overview", slide);
    section.setName("Introduction");
} finally {
    presentation.dispose();
}
```

## **Obtener diapositivas de secciones**

El método [Presentation.getSections](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/#getSections) devuelve una [SectionCollection](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/sectioncollection/) a la que puedes acceder por índice. Para cada [Section](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/section/), llama a [Section.getSlidesListOfSection](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/section/#getSlidesListOfSection) para obtener las diapositivas que le pertenecen actualmente. El método devuelve una [SectionSlideCollection](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/sectionslidecollection/), que proporciona un recuento y acceso indexado.

El siguiente ejemplo crea dos secciones con contenido y una sección vacía, luego muestra el [name](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/section/#getName), [identifier](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/section/#getSectionId), [starting slide](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/section/#getStartedFromSlide), recuento de diapositivas y números de diapositiva de cada sección. Utiliza [SectionSlideCollection.get_Item](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/sectionslidecollection/#get_Item) para leer tanto la primera diapositiva como cada diapositiva de la colección. Para la sección vacía, la colección devuelta tiene un tamaño de cero, se omite el acceso indexado y el bucle no realiza ninguna operación.

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const firstSlide = presentation.getSlides().get_Item(0);
    const layoutSlide = presentation.getLayoutSlides().get_Item(0);
    presentation.getSlides().addEmptySlide(layoutSlide);
    const thirdSlide = presentation.getSlides().addEmptySlide(layoutSlide);

    presentation.getSections().addSection("Introduction", firstSlide);
    presentation.getSections().addSection("Details", thirdSlide);
    presentation.getSections().appendEmptySection("Appendix");

    const sections = presentation.getSections();
    for (let sectionIndex = 0; sectionIndex < sections.size(); sectionIndex++) {
        const section = sections.get_Item(sectionIndex);
        const sectionSlides = section.getSlidesListOfSection();
        const startingSlideObject = section.getStartedFromSlide();
        const startingSlide = startingSlideObject === null ? "none" : startingSlideObject.getSlideNumber().toString();

        console.log("Section: " + section.getName());
        console.log("ID: " + section.getSectionId().toString());
        console.log("Starting slide: " + startingSlide);
        console.log("Slide count: " + sectionSlides.size());

        if (sectionSlides.size() > 0) {
            console.log("First slide via get_Item: " + sectionSlides.get_Item(0).getSlideNumber());
        }

        let slideNumbers = "Slide numbers:";
        for (let slideIndex = 0; slideIndex < sectionSlides.size(); slideIndex++) {
            slideNumbers += " " + sectionSlides.get_Item(slideIndex).getSlideNumber();
        }
        console.log(slideNumbers);
    }
} finally {
    presentation.dispose();
}
```

La pertenencia a una sección se determina por la estructura de secciones de la presentación. No calcules manualmente el rango de una sección a partir de [Section.getStartedFromSlide](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/section/#getStartedFromSlide), índices de diapositiva y la diapositiva inicial de la siguiente sección.

Las ediciones estructurales pueden cambiar tanto las diapositivas devueltas para una sección como sus números de diapositiva. Esto incluye reordenar diapositivas, clonar una diapositiva en una sección, mover una sección junto con sus diapositivas, eliminar diapositivas y eliminar secciones. El siguiente ejemplo llama a [Section.getSlidesListOfSection](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/section/#getSlidesListOfSection) después de cada uno de estos cambios en lugar de mantener suposiciones sobre los límites anteriores de la sección.

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const firstSlide = presentation.getSlides().get_Item(0);
    const layoutSlide = presentation.getLayoutSlides().get_Item(0);
    presentation.getSlides().addEmptySlide(layoutSlide);
    const thirdSlide = presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);
    const firstSection = presentation.getSections().addSection("First", firstSlide);
    const secondSection = presentation.getSections().addSection("Second", thirdSlide);

    const printSectionSlides = (label, section) => {
        const sectionSlides = section.getSlidesListOfSection();
        let output = label + " (" + sectionSlides.size() + " slides):";
        for (let slideIndex = 0; slideIndex < sectionSlides.size(); slideIndex++) {
            output += " " + sectionSlides.get_Item(slideIndex).getSlideNumber();
        }
        console.log(output);
    };

    printSectionSlides("Initially", firstSection);

    const slidesBeforeClone = firstSection.getSlidesListOfSection();
    presentation.getSlides().addClone(slidesBeforeClone.get_Item(0), firstSection);
    printSectionSlides("After cloning into the section", firstSection);

    const slidesBeforeReorder = firstSection.getSlidesListOfSection();
    const firstSectionPosition = slidesBeforeReorder.get_Item(0).getSlideNumber() - 1;
    const lastSlideInSection = slidesBeforeReorder.get_Item(slidesBeforeReorder.size() - 1);
    presentation.getSlides().reorder(firstSectionPosition, lastSlideInSection);
    printSectionSlides("After reordering slides", firstSection);

    presentation.getSections().reorderSectionWithSlides(firstSection, 1);
    printSectionSlides("After moving the section", firstSection);

    const slidesBeforeRemoval = firstSection.getSlidesListOfSection();
    presentation.getSlides().remove(slidesBeforeRemoval.get_Item(0));
    printSectionSlides("After removing a slide", firstSection);

    presentation.getSections().removeSectionWithSlides(secondSection);
    const remainingSections = presentation.getSections();
    for (let sectionIndex = 0; sectionIndex < remainingSections.size(); sectionIndex++) {
        printSectionSlides("Remaining section", remainingSections.get_Item(sectionIndex));
    }
} finally {
    presentation.dispose();
}
```

Llama a [Section.getSlidesListOfSection](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/section/#getSlidesListOfSection) nuevamente siempre que se reordenan, clonan, mueven o eliminan diapositivas o secciones. Esto mantiene el procesamiento posterior alineado con la estructura actual de la presentación.

El formato PPT (PowerPoint 97–2003) no conserva los metadatos de sección. Utiliza este flujo de trabajo con un formato que admita secciones, como PPTX; convertir a PPT elimina la estructura de secciones necesaria para iteraciones posteriores.

## **Preguntas frecuentes**

**¿Se conservan las secciones al guardar en el formato PPT (PowerPoint 97–2003)?**

No. El formato PPT no admite metadatos de sección, por lo que el agrupamiento de secciones se pierde al guardar en .ppt.

**¿Puede ocultarse una sección completa?**

No. Una sección no tiene estado de visibilidad. Para ocultar su contenido, llama a [Slide.setHidden](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/slide/#setHidden) para cada diapositiva de la sección.

**¿Cómo puedo encontrar la sección que contiene una diapositiva?**

Accede a cada sección en la colección devuelta por [Presentation.getSections](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/#getSections), llama a [Section.getSlidesListOfSection](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/section/#getSlidesListOfSection) para cada sección y compara las diapositivas devueltas con la diapositiva objetivo. Para una sección no vacía, [Section.getStartedFromSlide](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/section/#getStartedFromSlide) devuelve su primera diapositiva; para una sección vacía, devuelve `null`.