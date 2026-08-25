---
title: Gestionar secciones de diapositivas en presentaciones en Android
linktitle: Sección de diapositiva
type: docs
weight: 90
url: /es/androidjava/slide-section/
keywords:
- crear sección
- añadir sección
- editar sección
- cambiar sección
- nombre de sección
- obtener diapositivas de sección
- procesar diapositivas de sección
- PowerPoint
- presentación
- Android
- Java
- Aspose.Slides
description: "Gestiona las secciones de diapositivas con Aspose.Slides para Android mediante Java: crea, renombra, reordena, recupera y procesa diapositivas de sección en presentaciones PPTX."
---
## **Introducción**

Las secciones organizan diapositivas consecutivas en grupos con nombre sin modificar el contenido de la diapositiva. Con Aspose.Slides para Android mediante Java, puedes crear, reordenar, renombrar, inspeccionar y eliminar secciones mediante el método [Presentation.getSections](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/presentation/#getSections--).

Las secciones son especialmente útiles cuando:

- una presentación grande necesita dividirse en temas o capítulos lógicos;
- diferentes grupos de diapositivas se asignan a distintos colaboradores;
- las diapositivas deben procesarse, moverse o combinarse como grupos.

Elige nombres de sección concisos que describan el propósito de las diapositivas agrupadas. Dado que las secciones forman parte de la estructura de la presentación, utiliza las API de sección para determinar la pertenencia en lugar de derivarla de las posiciones de las diapositivas.

## **Crear y administrar secciones**

Utiliza [ISectionCollection.addSection](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/isectioncollection/#addSection-java.lang.String-com.aspose.slides.ISlide-) para crear una sección especificando su nombre y diapositiva inicial. Aspose.Slides determina qué diapositivas pertenecen a la sección a partir de la estructura de secciones actual de la presentación.

El mismo [ISectionCollection](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/isectioncollection/) también permite:

- mover una sección junto con sus diapositivas utilizando [ISectionCollection.reorderSectionWithSlides](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/isectioncollection/#reorderSectionWithSlides-com.aspose.slides.ISection-int-);
- eliminar solo la definición de la sección con [ISectionCollection.removeSection](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/isectioncollection/#removeSection-com.aspose.slides.ISection-), lo que conserva sus diapositivas;
- eliminar una sección y sus diapositivas con [ISectionCollection.removeSectionWithSlides](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/isectioncollection/#removeSectionWithSlides-com.aspose.slides.ISection-);
- añadir una sección vacía al final con [ISectionCollection.appendEmptySection](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/isectioncollection/#appendEmptySection-java.lang.String-).

El siguiente ejemplo crea dos secciones, mueve una de ellas, la elimina junto con sus diapositivas y añade una sección vacía:

```java
import com.aspose.slides.ILayoutSlide;
import com.aspose.slides.ISection;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation();
try {
    ISlide titleSlide = presentation.getSlides().get_Item(0);
    ILayoutSlide layoutSlide = presentation.getLayoutSlides().get_Item(0);
    presentation.getSlides().addEmptySlide(layoutSlide);
    ISlide resultsSlide = presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);

    presentation.getSections().addSection("Introduction", titleSlide);
    ISection resultsSection = presentation.getSections().addSection("Results", resultsSlide);

    presentation.getSections().reorderSectionWithSlides(resultsSection, 0);
    presentation.getSections().removeSectionWithSlides(resultsSection);
    presentation.getSections().appendEmptySection("Appendix");
} finally {
    presentation.dispose();
}
```

Después de estas operaciones, la presentación contiene la sección `Introduction` con sus diapositivas y una sección vacía `Appendix`. La sección `Results` y sus diapositivas han sido eliminadas.

## **Renombrar secciones**

Para renombrar una sección, llama a su método [ISection.setName](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/isection/#setName-java.lang.String-). Las diapositivas y la posición de la sección permanecen sin cambios.

El siguiente ejemplo crea una sección y cambia su nombre:

```java
import com.aspose.slides.ISection;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ISection section = presentation.getSections().addSection("Overview", slide);
    section.setName("Introduction");
} finally {
    presentation.dispose();
}
```

## **Obtener diapositivas de secciones**

El método [Presentation.getSections](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/presentation/#getSections--) devuelve una [ISectionCollection](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/isectioncollection/) que puedes iterar. Para cada [ISection](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/isection/), llama a [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/isection/#getSlidesListOfSection--) para obtener las diapositivas que le pertenecen actualmente. El método devuelve una [ISectionSlideCollection](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/isectionslidecollection/), que ofrece un recuento, acceso indexado e iteración.

El siguiente ejemplo crea dos secciones pobladas y una sección vacía, y luego muestra el [nombre](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/isection/#getName--) , el [identificador](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/isection/#getSectionId--) , la [diapositiva inicial](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/isection/#getStartedFromSlide--) , el recuento de diapositivas y los números de diapositiva de cada sección. Utiliza [ISectionSlideCollection.get_Item](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/isectionslidecollection/#get_Item-int-) para leer la primera diapositiva y una sentencia `for` mejorada para procesar cada diapositiva. Para la sección vacía, la colección devuelta tiene un tamaño cero, no se llama al método y la iteración no realiza operaciones.

```java
import com.aspose.slides.ILayoutSlide;
import com.aspose.slides.ISection;
import com.aspose.slides.ISectionSlideCollection;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation();
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);
    ILayoutSlide layoutSlide = presentation.getLayoutSlides().get_Item(0);
    presentation.getSlides().addEmptySlide(layoutSlide);
    ISlide thirdSlide = presentation.getSlides().addEmptySlide(layoutSlide);

    presentation.getSections().addSection("Introduction", firstSlide);
    presentation.getSections().addSection("Details", thirdSlide);
    presentation.getSections().appendEmptySection("Appendix");

    for (ISection section : presentation.getSections()) {
        ISectionSlideCollection sectionSlides = section.getSlidesListOfSection();
        String startingSlide = section.getStartedFromSlide() == null ? "none" : Integer.toString(section.getStartedFromSlide().getSlideNumber());

        System.out.println("Section: " + section.getName());
        System.out.println("ID: " + section.getSectionId());
        System.out.println("Starting slide: " + startingSlide);
        System.out.println("Slide count: " + sectionSlides.size());

        if (sectionSlides.size() > 0) {
            System.out.println("First slide via get_Item: " + sectionSlides.get_Item(0).getSlideNumber());
        }

        System.out.print("Slide numbers:");
        for (ISlide slide : sectionSlides) {
            System.out.print(" " + slide.getSlideNumber());
        }
        System.out.println();
    }
} finally {
    presentation.dispose();
}
```

La pertenencia a una sección se determina por la estructura de secciones de la presentación. No calcules manualmente el rango de una sección a partir de [ISection.getStartedFromSlide](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/isection/#getStartedFromSlide--), índices de diapositivas y la diapositiva inicial de la siguiente sección.

Las ediciones estructurales pueden cambiar tanto las diapositivas devueltas para una sección como sus números de diapositiva. Esto incluye reordenar diapositivas, clonar una diapositiva en una sección, mover una sección junto con sus diapositivas, eliminar diapositivas y eliminar secciones. El siguiente ejemplo llama a [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/isection/#getSlidesListOfSection--) después de cada uno de esos cambios en lugar de mantener supuestos sobre los límites anteriores de la sección.

```java
import com.aspose.slides.ILayoutSlide;
import com.aspose.slides.ISection;
import com.aspose.slides.ISectionSlideCollection;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;

import java.util.function.BiConsumer;

Presentation presentation = new Presentation();
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);
    ILayoutSlide layoutSlide = presentation.getLayoutSlides().get_Item(0);
    presentation.getSlides().addEmptySlide(layoutSlide);
    ISlide thirdSlide = presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);
    ISection firstSection = presentation.getSections().addSection("First", firstSlide);
    ISection secondSection = presentation.getSections().addSection("Second", thirdSlide);

    BiConsumer<String, ISection> printSectionSlides = (label, section) -> {
        ISectionSlideCollection sectionSlides = section.getSlidesListOfSection();
        System.out.printf("%s (%d slides):", label, sectionSlides.size());
        for (ISlide slide : sectionSlides) {
            System.out.print(" " + slide.getSlideNumber());
        }
        System.out.println();
    };

    printSectionSlides.accept("Initially", firstSection);

    ISectionSlideCollection slidesBeforeClone = firstSection.getSlidesListOfSection();
    presentation.getSlides().addClone(slidesBeforeClone.get_Item(0), firstSection);
    printSectionSlides.accept("After cloning into the section", firstSection);

    ISectionSlideCollection slidesBeforeReorder = firstSection.getSlidesListOfSection();
    int firstSectionPosition = slidesBeforeReorder.get_Item(0).getSlideNumber() - 1;
    presentation.getSlides().reorder(firstSectionPosition, slidesBeforeReorder.get_Item(slidesBeforeReorder.size() - 1));
    printSectionSlides.accept("After reordering slides", firstSection);

    presentation.getSections().reorderSectionWithSlides(firstSection, 1);
    printSectionSlides.accept("After moving the section", firstSection);

    ISectionSlideCollection slidesBeforeRemoval = firstSection.getSlidesListOfSection();
    presentation.getSlides().remove(slidesBeforeRemoval.get_Item(0));
    printSectionSlides.accept("After removing a slide", firstSection);

    presentation.getSections().removeSectionWithSlides(secondSection);
    for (ISection section : presentation.getSections()) {
        printSectionSlides.accept("Remaining section", section);
    }
} finally {
    presentation.dispose();
}
```

Llama a [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/isection/#getSlidesListOfSection--) nuevamente siempre que se reordenen, clonen, muevan o eliminen diapositivas o secciones. Esto mantiene el procesamiento posterior alineado con la estructura actual de la presentación.

El formato PPT (PowerPoint 97–2003) no conserva los metadatos de secciones. Utiliza este flujo de trabajo con un formato que admita secciones, como PPTX; convertir a PPT elimina la estructura de secciones necesaria para iteraciones posteriores.

## **Preguntas frecuentes**

**¿Se conservan las secciones al guardar en el formato PPT (PowerPoint 97–2003)?**

No. El formato PPT no admite metadatos de secciones, por lo que el agrupamiento de secciones se pierde al guardar en .ppt.

**¿Se puede "ocultar" una sección completa?**

No. Una sección no tiene un estado de visibilidad. Para ocultar su contenido, llama a [ISlide.setHidden](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/islide/#setHidden-boolean-) para cada diapositiva de la sección.

**¿Cómo puedo encontrar la sección que contiene una diapositiva?**

Itera sobre la colección devuelta por [Presentation.getSections](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/presentation/#getSections--), llama a [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/isection/#getSlidesListOfSection--) para cada sección y compara las diapositivas devueltas con la diapositiva objetivo. Para una sección no vacía, [ISection.getStartedFromSlide](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/isection/#getStartedFromSlide--) devuelve su primera diapositiva; para una sección vacía, devuelve `null`.