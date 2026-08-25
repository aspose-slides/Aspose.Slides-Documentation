---
title: Gérer les sections de diapositives dans les présentations avec PHP
linktitle: Section de diapositive
type: docs
weight: 90
url: /fr/php-java/slide-section/
keywords:
- créer une section
- ajouter une section
- modifier une section
- changer la section
- nom de la section
- récupérer les diapositives de la section
- traiter les diapositives de la section
- PowerPoint
- présentation
- PHP
- Aspose.Slides
description: "Gérer les sections de diapositives avec Aspose.Slides pour PHP via Java : créer, renommer, réorganiser, récupérer et traiter les diapositives de section dans les présentations PPTX."
---
## **Introduction**

Les sections organisent des diapositives consécutives en groupes nommés sans modifier le contenu des diapositives. Avec Aspose.Slides for PHP via Java, vous pouvez créer, réorganiser, renommer, inspecter et supprimer des sections via la méthode [Presentation::getSections](https://reference.aspose.com/slides/fr/php-java/aspose.slides/Presentation/#getSections).

Les sections sont particulièrement utiles lorsque :

- une présentation volumineuse doit être divisée en sujets ou chapitres logiques ;
- différents groupes de diapositives sont assignés à différents collaborateurs ;
- les diapositives doivent être traitées, déplacées ou fusionnées par groupes.

Choisissez des noms de sections concis qui décrivent le but des diapositives groupées. Étant donné que les sections font partie de la structure de la présentation, utilisez les API de sections pour déterminer l'appartenance plutôt que de la déduire des positions des diapositives.

## **Créer et gérer les sections**

Utilisez [SectionCollection::addSection](https://reference.aspose.com/slides/fr/php-java/aspose.slides/SectionCollection/#addSection) pour créer une section en spécifiant son nom et la diapositive de départ. Aspose.Slides détermine quelles diapositives appartiennent à la section à partir de la structure de sections actuelle de la présentation.

Le même [SectionCollection](https://reference.aspose.com/slides/fr/php-java/aspose.slides/SectionCollection/) vous permet également de :

- déplacer une section avec ses diapositives en utilisant [SectionCollection::reorderSectionWithSlides](https://reference.aspose.com/slides/fr/php-java/aspose.slides/SectionCollection/#reorderSectionWithSlides) ;
- supprimer uniquement la définition de la section avec [SectionCollection::removeSection](https://reference.aspose.com/slides/fr/php-java/aspose.slides/SectionCollection/#removeSection), en conservant ses diapositives ;
- supprimer une section ainsi que ses diapositives avec [SectionCollection::removeSectionWithSlides](https://reference.aspose.com/slides/fr/php-java/aspose.slides/SectionCollection/#removeSectionWithSlides) ;
- ajouter une section vide à la fin avec [SectionCollection::appendEmptySection](https://reference.aspose.com/slides/fr/php-java/aspose.slides/SectionCollection/#appendEmptySection).

L’exemple suivant crée deux sections, déplace l’une d’elles, la supprime ainsi que ses diapositives, puis ajoute une section vide :

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

Après ces opérations, la présentation contient la section `Introduction` avec ses diapositives et une section vide `Appendix`. La section `Results` et ses diapositives ont été supprimées.

## **Renommer les sections**

Pour renommer une section, appelez sa méthode [Section::setName](https://reference.aspose.com/slides/fr/php-java/aspose.slides/Section/#setName). Les diapositives et la position de la section restent inchangées.

L’exemple suivant crée une section et change son nom :

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

## **Récupérer les diapositives à partir des sections**

La méthode [Presentation::getSections](https://reference.aspose.com/slides/fr/php-java/aspose.slides/Presentation/#getSections) renvoie un [SectionCollection](https://reference.aspose.com/slides/fr/php-java/aspose.slides/SectionCollection/) que vous pouvez parcourir par indice. Pour chaque [Section](https://reference.aspose.com/slides/fr/php-java/aspose.slides/Section/), appelez [Section::getSlidesListOfSection](https://reference.aspose.com/slides/fr/php-java/aspose.slides/Section/#getSlidesListOfSection) afin d’obtenir les diapositives qui lui appartiennent actuellement. La méthode renvoie un [SectionSlideCollection](https://reference.aspose.com/slides/fr/php-java/aspose.slides/SectionSlideCollection/), qui fournit un compte et un accès indexé.

L’exemple suivant crée deux sections remplies et une section vide, puis affiche le [nom](https://reference.aspose.com/slides/fr/php-java/aspose.slides/Section/#getName), l’[identifiant](https://reference.aspose.com/slides/fr/php-java/aspose.slides/Section/#getSectionId), la [diapositive de départ](https://reference.aspose.com/slides/fr/php-java/aspose.slides/Section/#getStartedFromSlide), le nombre de diapositives et les numéros de diapositives de chaque section. Il utilise [SectionCollection::get_Item](https://reference.aspose.com/slides/fr/php-java/aspose.slides/SectionCollection/#get_Item) et [SectionSlideCollection::get_Item](https://reference.aspose.com/slides/fr/php-java/aspose.slides/SectionSlideCollection/#get_Item) pour l’accès indexé. Pour la section vide, la collection renvoyée a une taille de zéro et `get_Item` n’est pas appelée.

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

L’appartenance à une section est déterminée par la structure de sections de la présentation. Ne calculez pas manuellement la plage d’une section à partir de [Section::getStartedFromSlide](https://reference.aspose.com/slides/fr/php-java/aspose.slides/Section/#getStartedFromSlide), des indices de diapositives et de la diapositive de départ de la section suivante.

Des modifications structurelles peuvent changer à la fois les diapositives renvoyées pour une section et leurs numéros de diapositives. Cela inclut le réordonnancement des diapositives, le clonage d’une diapositive dans une section, le déplacement d’une section avec ses diapositives, la suppression de diapositives et la suppression de sections. L’exemple suivant appelle [Section::getSlidesListOfSection](https://reference.aspose.com/slides/fr/php-java/aspose.slides/Section/#getSlidesListOfSection) après chaque modification au lieu de conserver des hypothèses sur les anciennes limites de la section.

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

Appelez à nouveau [Section::getSlidesListOfSection](https://reference.aspose.com/slides/fr/php-java/aspose.slides/Section/#getSlidesListOfSection) chaque fois que des diapositives ou des sections sont réordonnées, clonées, déplacées ou supprimées. Cela maintient le traitement ultérieur aligné avec la structure actuelle de la présentation.

Le format PPT (PowerPoint 97–2003) ne conserve pas les métadonnées de sections. Utilisez ce flux de travail avec un format qui prend en charge les sections, tel que PPTX ; la conversion en PPT supprime la structure de sections nécessaire aux itérations ultérieures.

## **FAQ**

**Les sections sont‑elles conservées lors de l’enregistrement au format PPT (PowerPoint 97–2003) ?**

Non. Le format PPT ne prend pas en charge les métadonnées de sections, ainsi le regroupement en sections est perdu lors de l’enregistrement au format *.ppt*.

**Une section entière peut‑elle être « masquée » ?**

Non. Une section n’a aucun état de visibilité. Pour masquer son contenu, appelez [Slide::setHidden](https://reference.aspose.com/slides/fr/php-java/aspose.slides/Slide/#setHidden) pour chaque diapositive de la section.

**Comment trouver la section qui contient une diapositive ?**

Parcourez la collection renvoyée par [Presentation::getSections](https://reference.aspose.com/slides/fr/php-java/aspose.slides/Presentation/#getSections), appelez [Section::getSlidesListOfSection](https://reference.aspose.com/slides/fr/php-java/aspose.slides/Section/#getSlidesListOfSection) pour chaque section, et comparez les diapositives renvoyées avec la diapositive cible. Pour une section non vide, [Section::getStartedFromSlide](https://reference.aspose.com/slides/fr/php-java/aspose.slides/Section/#getStartedFromSlide) renvoie sa première diapositive ; pour une section vide, elle renvoie `null`.