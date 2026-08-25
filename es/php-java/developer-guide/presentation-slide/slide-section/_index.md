---
title: Gestionar secciones de diapositivas en presentaciones con PHP
linktitle: Sección de diapositiva
type: docs
weight: 90
url: /es/php-java/slide-section/
keywords:
- crear sección
- añadir sección
- editar sección
- cambiar sección
- nombre de la sección
- recuperar diapositivas de sección
- procesar diapositivas de sección
- PowerPoint
- presentación
- PHP
- Aspose.Slides
description: "Gestiona secciones de diapositivas con Aspose.Slides para PHP mediante Java: crea, renombra, reordena, recupera y procesa diapositivas de sección en presentaciones PPTX."
---
## **Introducción**

Las secciones organizan diapositivas consecutivas en grupos con nombre sin modificar el contenido de las diapositivas. Con Aspose.Slides para PHP mediante Java, puedes crear, reordenar, renombrar, inspeccionar y eliminar secciones mediante el método [Presentation::getSections](https://reference.aspose.com/slides/es/php-java/aspose.slides/Presentation/#getSections).

Las secciones son especialmente útiles cuando:

- una presentación grande necesita dividirse en temas o capítulos lógicos;
- diferentes grupos de diapositivas se asignan a distintos colaboradores;
- las diapositivas deben procesarse, mover‑se o combinarse como grupos.

Elige nombres de sección concisos que describan el propósito de las diapositivas agrupadas. Como las secciones forman parte de la estructura de la presentación, utiliza las API de secciones para determinar la pertenencia en lugar de derivarla de las posiciones de las diapositivas.

## **Crear y gestionar secciones**

Utiliza [SectionCollection::addSection](https://reference.aspose.com/slides/es/php-java/aspose.slides/SectionCollection/#addSection) para crear una sección especificando su nombre y diapositiva inicial. Aspose.Slides determina a qué diapositivas pertenece la sección a partir de la estructura de secciones actual de la presentación.

La misma [SectionCollection](https://reference.aspose.com/slides/es/php-java/aspose.slides/SectionCollection/) también permite:

- mover una sección junto con sus diapositivas mediante [SectionCollection::reorderSectionWithSlides](https://reference.aspose.com/slides/es/php-java/aspose.slides/SectionCollection/#reorderSectionWithSlides);
- eliminar solo la definición de la sección con [SectionCollection::removeSection](https://reference.aspose.com/slides/es/php-java/aspose.slides/SectionCollection/#removeSection), conservando sus diapositivas;
- eliminar una sección y sus diapositivas con [SectionCollection::removeSectionWithSlides](https://reference.aspose.com/slides/es/php-java/aspose.slides/SectionCollection/#removeSectionWithSlides);
- añadir una sección vacía al final con [SectionCollection::appendEmptySection](https://reference.aspose.com/slides/es/php-java/aspose.slides/SectionCollection/#appendEmptySection).

El siguiente ejemplo crea dos secciones, mueve una de ellas, la elimina junto con sus diapositivas y añade una sección vacía:

```php
use aspose\slides\Presentation;

$presentation = new Presentation();
try {
    $titleSlide = $presentation->getSlides()->get_Item(0);
    $layoutSlide = $presentation->getLayoutSlides()->get_Item(0);
    $presentation->getSlides()->addEmptySlide($layoutSlide);
    $resultsSlide = $presentation->getSlides()->addEmptySlide($layoutSlide);
    $presentation->getSlides()->addEmptySlide($layoutSlide);

    $presentation->getSections()->addSection("Introduction", $titleSlide);
    $resultsSection = $presentation->getSections()->addSection("Results", $resultsSlide);

    $presentation->getSections()->reorderSectionWithSlides($resultsSection, 0);
    $presentation->getSections()->removeSectionWithSlides($resultsSection);
    $presentation->getSections()->appendEmptySection("Appendix");
} finally {
    $presentation->dispose();
}
```

Después de estas operaciones, la presentación contiene la sección `Introduction` con sus diapositivas y una sección vacía `Appendix`. La sección `Results` y sus diapositivas se han eliminado.

## **Renombrar secciones**

Para renombrar una sección, llama a su método [Section::setName](https://reference.aspose.com/slides/es/php-java/aspose.slides/Section/#setName). Las diapositivas y la posición de la sección permanecen sin cambios.

El siguiente ejemplo crea una sección y cambia su nombre:

```php
use aspose\slides\Presentation;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $section = $presentation->getSections()->addSection("Overview", $slide);
    $section->setName("Introduction");
} finally {
    $presentation->dispose();
}
```

## **Obtener diapositivas de las secciones**

El método [Presentation::getSections](https://reference.aspose.com/slides/es/php-java/aspose.slides/Presentation/#getSections) devuelve una [SectionCollection](https://reference.aspose.com/slides/es/php-java/aspose.slides/SectionCollection/) que puedes procesar por índice. Para cada [Section](https://reference.aspose.com/slides/es/php-java/aspose.slides/Section/), llama a [Section::getSlidesListOfSection](https://reference.aspose.com/slides/es/php-java/aspose.slides/Section/#getSlidesListOfSection) para obtener las diapositivas que le pertenecen actualmente. El método devuelve una [SectionSlideCollection](https://reference.aspose.com/slides/es/php-java/aspose.slides/SectionSlideCollection/), que proporciona un recuento y acceso indexado.

El siguiente ejemplo crea dos secciones pobladas y una sección vacía, luego muestra el [name](https://reference.aspose.com/slides/es/php-java/aspose.slides/Section/#getName), el [identifier](https://reference.aspose.com/slides/es/php-java/aspose.slides/Section/#getSectionId), la [starting slide](https://reference.aspose.com/slides/es/php-java/aspose.slides/Section/#getStartedFromSlide), el recuento de diapositivas y los números de diapositiva de cada sección. Utiliza [SectionCollection::get_Item](https://reference.aspose.com/slides/es/php-java/aspose.slides/SectionCollection/#get_Item) y [SectionSlideCollection::get_Item](https://reference.aspose.com/slides/es/php-java/aspose.slides/SectionSlideCollection/#get_Item) para el acceso indexado. Para la sección vacía, la colección devuelta tiene un tamaño de cero y no se llama a `get_Item`.

```php
use aspose\slides\Presentation;

$presentation = new Presentation();
try {
    $firstSlide = $presentation->getSlides()->get_Item(0);
    $layoutSlide = $presentation->getLayoutSlides()->get_Item(0);
    $presentation->getSlides()->addEmptySlide($layoutSlide);
    $thirdSlide = $presentation->getSlides()->addEmptySlide($layoutSlide);

    $presentation->getSections()->addSection("Introduction", $firstSlide);
    $presentation->getSections()->addSection("Details", $thirdSlide);
    $presentation->getSections()->appendEmptySection("Appendix");

    $sections = $presentation->getSections();
    $sectionCount = java_values($sections->size());
    for ($sectionIndex = 0; $sectionIndex < $sectionCount; $sectionIndex++) {
        $section = $sections->get_Item($sectionIndex);
        $sectionSlides = $section->getSlidesListOfSection();
        $startingSlide = java_is_null($section->getStartedFromSlide()) ? "none" : java_values($section->getStartedFromSlide()->getSlideNumber());
        $slideCount = java_values($sectionSlides->size());

        echo "Section: " . java_values($section->getName()) . PHP_EOL;
        echo "ID: " . java_values($section->getSectionId()) . PHP_EOL;
        echo "Starting slide: " . $startingSlide . PHP_EOL;
        echo "Slide count: " . $slideCount . PHP_EOL;

        if ($slideCount > 0) {
            echo "First slide via get_Item: " . java_values($sectionSlides->get_Item(0)->getSlideNumber()) . PHP_EOL;
        }

        echo "Slide numbers:";
        for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
            $slide = $sectionSlides->get_Item($slideIndex);
            echo " " . java_values($slide->getSlideNumber());
        }
        echo PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

La pertenencia a una sección se determina por la estructura de secciones de la presentación. No calcules manualmente el rango de una sección a partir de [Section::getStartedFromSlide](https://reference.aspose.com/slides/es/php-java/aspose.slides/Section/#getStartedFromSlide), índices de diapositiva y la diapositiva inicial de la sección siguiente.

Las ediciones estructurales pueden cambiar tanto las diapositivas devueltas para una sección como sus números de diapositiva. Esto incluye reordenar diapositivas, clonar una diapositiva dentro de una sección, mover una sección junto con sus diapositivas, eliminar diapositivas y eliminar secciones. El siguiente ejemplo llama a [Section::getSlidesListOfSection](https://reference.aspose.com/slides/es/php-java/aspose.slides/Section/#getSlidesListOfSection) después de cada uno de estos cambios en lugar de mantener suposiciones sobre los límites anteriores de la sección.

```php
use aspose\slides\Presentation;

$presentation = new Presentation();
try {
    $firstSlide = $presentation->getSlides()->get_Item(0);
    $layoutSlide = $presentation->getLayoutSlides()->get_Item(0);
    $presentation->getSlides()->addEmptySlide($layoutSlide);
    $thirdSlide = $presentation->getSlides()->addEmptySlide($layoutSlide);
    $presentation->getSlides()->addEmptySlide($layoutSlide);
    $firstSection = $presentation->getSections()->addSection("First", $firstSlide);
    $secondSection = $presentation->getSections()->addSection("Second", $thirdSlide);

    $printSectionSlides = function ($label, $section) {
        $sectionSlides = $section->getSlidesListOfSection();
        $slideCount = java_values($sectionSlides->size());
        echo $label . " (" . $slideCount . " slides):";
        for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
            $slide = $sectionSlides->get_Item($slideIndex);
            echo " " . java_values($slide->getSlideNumber());
        }
        echo PHP_EOL;
    };

    $printSectionSlides("Initially", $firstSection);

    $slidesBeforeClone = $firstSection->getSlidesListOfSection();
    $presentation->getSlides()->addClone($slidesBeforeClone->get_Item(0), $firstSection);
    $printSectionSlides("After cloning into the section", $firstSection);

    $slidesBeforeReorder = $firstSection->getSlidesListOfSection();
    $firstSectionPosition = java_values($slidesBeforeReorder->get_Item(0)->getSlideNumber()) - 1;
    $lastSlideIndex = java_values($slidesBeforeReorder->size()) - 1;
    $presentation->getSlides()->reorder($firstSectionPosition, $slidesBeforeReorder->get_Item($lastSlideIndex));
    $printSectionSlides("After reordering slides", $firstSection);

    $presentation->getSections()->reorderSectionWithSlides($firstSection, 1);
    $printSectionSlides("After moving the section", $firstSection);

    $slidesBeforeRemoval = $firstSection->getSlidesListOfSection();
    $presentation->getSlides()->remove($slidesBeforeRemoval->get_Item(0));
    $printSectionSlides("After removing a slide", $firstSection);

    $presentation->getSections()->removeSectionWithSlides($secondSection);
    $remainingSections = $presentation->getSections();
    $remainingSectionCount = java_values($remainingSections->size());
    for ($sectionIndex = 0; $sectionIndex < $remainingSectionCount; $sectionIndex++) {
        $section = $remainingSections->get_Item($sectionIndex);
        $printSectionSlides("Remaining section", $section);
    }
} finally {
    $presentation->dispose();
}
```

Llama a [Section::getSlidesListOfSection](https://reference.aspose.com/slides/es/php-java/aspose.slides/Section/#getSlidesListOfSection) nuevamente siempre que se reordenen, clonen, muevan o eliminen diapositivas o secciones. Así mantienes el procesamiento posterior alineado con la estructura actual de la presentación.

El formato PPT (PowerPoint 97–2003) no conserva los metadatos de sección. Utiliza este flujo de trabajo con un formato que admita secciones, como PPTX; convertir a PPT elimina la estructura de secciones necesaria para iteraciones posteriores.

## **Preguntas frecuentes**

**¿Se conservan las secciones al guardar en formato PPT (PowerPoint 97–2003)?**

No. El formato PPT no admite metadatos de sección, por lo que el agrupamiento por secciones se pierde al guardar en .ppt.

**¿Puede ocultarse una sección completa?**

No. Una sección no tiene estado de visibilidad. Para ocultar su contenido, llama a [Slide::setHidden](https://reference.aspose.com/slides/es/php-java/aspose.slides/Slide/#setHidden) para cada diapositiva de la sección.

**¿Cómo puedo encontrar la sección que contiene una diapositiva?**

Recorre la colección devuelta por [Presentation::getSections](https://reference.aspose.com/slides/es/php-java/aspose.slides/Presentation/#getSections), llama a [Section::getSlidesListOfSection](https://reference.aspose.com/slides/es/php-java/aspose.slides/Section/#getSlidesListOfSection) para cada sección y compara las diapositivas devueltas con la diapositiva objetivo. Para una sección no vacía, [Section::getStartedFromSlide](https://reference.aspose.com/slides/es/php-java/aspose.slides/Section/#getStartedFromSlide) devuelve su primera diapositiva; para una sección vacía, devuelve `null`.