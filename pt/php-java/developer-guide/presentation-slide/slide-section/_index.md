---
title: Gerenciar Seções de Slides em Apresentações com PHP
linktitle: Seção de Slide
type: docs
weight: 90
url: /pt/php-java/slide-section/
keywords:
- criar seção
- adicionar seção
- editar seção
- alterar seção
- nome da seção
- recuperar slides da seção
- processar slides da seção
- PowerPoint
- apresentação
- PHP
- Aspose.Slides
description: "Gerencie seções de slides com Aspose.Slides para PHP via Java: crie, renomeie, reordene, recupere e processe slides de seção em apresentações PPTX."
---
## **Introdução**

Sections organize consecutive slides into named groups without changing the slide content. With Aspose.Slides for PHP via Java, you can create, reorder, rename, inspect, and remove sections through the [Presentation::getSections](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Presentation/#getSections) method.

Sections are especially useful when:

- uma apresentação grande precisa ser dividida em tópicos ou capítulos lógicos;
- diferentes grupos de slides são atribuídos a diferentes colaboradores;
- os slides precisam ser processados, movidos ou mesclados como grupos.

Choose concise section names that describe the purpose of the grouped slides. Because sections are part of the presentation structure, use the section APIs to determine membership instead of deriving it from slide positions.

## **Criar e Gerenciar Seções**

Use [SectionCollection::addSection](https://reference.aspose.com/slides/pt/php-java/aspose.slides/SectionCollection/#addSection) to create a section by specifying its name and starting slide. Aspose.Slides determines which slides belong to the section from the presentation's current section structure.

The same [SectionCollection](https://reference.aspose.com/slides/pt/php-java/aspose.slides/SectionCollection/) also lets you:

- mover uma seção junto com seus slides usando [SectionCollection::reorderSectionWithSlides](https://reference.aspose.com/slides/pt/php-java/aspose.slides/SectionCollection/#reorderSectionWithSlides);
- remover apenas a definição da seção com [SectionCollection::removeSection](https://reference.aspose.com/slides/pt/php-java/aspose.slides/SectionCollection/#removeSection), que mantém seus slides;
- remover uma seção e seus slides com [SectionCollection::removeSectionWithSlides](https://reference.aspose.com/slides/pt/php-java/aspose.slides/SectionCollection/#removeSectionWithSlides);
- adicionar uma seção vazia no final com [SectionCollection::appendEmptySection](https://reference.aspose.com/slides/pt/php-java/aspose.slides/SectionCollection/#appendEmptySection).

The following example creates two sections, moves one of them, removes it together with its slides, and appends an empty section:

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

After these operations, the presentation contains the `Introduction` section with its slides and an empty `Appendix` section. The `Results` section and its slides have been removed.

## **Renomear Seções**

To rename a section, call its [Section::setName](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Section/#setName) method. The section's slides and position remain unchanged.

The following example creates a section and changes its name:

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

## **Recuperar Slides de Seções**

The [Presentation::getSections](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Presentation/#getSections) method returns a [SectionCollection](https://reference.aspose.com/slides/pt/php-java/aspose.slides/SectionCollection/) that you can process by index. For each [Section](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Section/), call [Section::getSlidesListOfSection](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Section/#getSlidesListOfSection) to obtain the slides that currently belong to it. The method returns a [SectionSlideCollection](https://reference.aspose.com/slides/pt/php-java/aspose.slides/SectionSlideCollection/), which provides a count and indexed access.

The following example creates two populated sections and one empty section, then prints each section's [name](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Section/#getName), [identifier](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Section/#getSectionId), [starting slide](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Section/#getStartedFromSlide), slide count, and slide numbers. It uses [SectionCollection::get_Item](https://reference.aspose.com/slides/pt/php-java/aspose.slides/SectionCollection/#get_Item) and [SectionSlideCollection::get_Item](https://reference.aspose.com/slides/pt/php-java/aspose.slides/SectionSlideCollection/#get_Item) for indexed access. For the empty section, the returned collection has a size of zero and `get_Item` is not called.

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

Section membership is determined by the presentation's section structure. Do not calculate a section's range manually from [Section::getStartedFromSlide](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Section/#getStartedFromSlide), slide indexes, and the next section's starting slide.

Structural edits can change both the slides returned for a section and their slide numbers. This includes reordering slides, cloning a slide into a section, moving a section together with its slides, removing slides, and removing sections. The next example calls [Section::getSlidesListOfSection](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Section/#getSlidesListOfSection) after every such change instead of retaining assumptions about the section's former boundaries.

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

Call [Section::getSlidesListOfSection](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Section/#getSlidesListOfSection) again whenever slides or sections are reordered, cloned, moved, or removed. This keeps subsequent processing aligned with the current presentation structure.

The PPT (PowerPoint 97–2003) format does not preserve section metadata. Use this workflow with a format that supports sections, such as PPTX; converting to PPT removes the section structure needed for later iteration.

## **Perguntas Frequentes**

**As seções são preservadas ao salvar no formato PPT (PowerPoint 97–2003)?**

No. The PPT format does not support section metadata, so section grouping is lost when saving to .ppt.

**É possível "ocultar" uma seção inteira?**

No. A section has no visibility state. To hide its contents, call [Slide::setHidden](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Slide/#setHidden) for each slide in the section.

**Como posso encontrar a seção que contém um slide?**

Loop through the collection returned by [Presentation::getSections](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Presentation/#getSections), call [Section::getSlidesListOfSection](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Section/#getSlidesListOfSection) for each section, and compare the returned slides with the target slide. For a non-empty section, [Section::getStartedFromSlide](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Section/#getStartedFromSlide) returns its first slide; for an empty section, it returns `null`.