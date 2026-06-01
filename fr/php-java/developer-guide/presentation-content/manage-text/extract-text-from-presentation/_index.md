---
title: Extraction avancée de texte à partir de présentations en PHP
linktitle: Extraire le texte
type: docs
weight: 90
url: /fr/php-java/extract-text-from-presentation/
keywords:
- extraire du texte
- extraire du texte d'une diapositive
- extraire du texte d'une présentation
- extraire du texte de PowerPoint
- extraire du texte d'OpenDocument
- extraire du texte de PPT
- extraire du texte de PPTX
- extraire du texte de ODP
- récupérer le texte
- récupérer le texte d'une diapositive
- récupérer le texte d'une présentation
- récupérer le texte de PowerPoint
- récupérer le texte d'OpenDocument
- récupérer le texte de PPT
- récupérer le texte de PPTX
- récupérer le texte de ODP
- PowerPoint
- OpenDocument
- présentation
- PHP
- Aspose.Slides
description: "Extrayez rapidement du texte des présentations PowerPoint et OpenDocument à l'aide d'Aspose.Slides pour PHP via Java. Suivez notre guide simple, étape par étape, pour gagner du temps."
---
## **Vue d'ensemble**

L'extraction de texte à partir de présentations est une tâche courante mais essentielle pour les développeurs qui travaillent avec le contenu des diapositives. Que vous manipuliez des fichiers Microsoft PowerPoint au format PPT ou PPTX, ou des présentations OpenDocument (ODP), accéder et récupérer les données textuelles peut être crucial pour l'analyse, l'automatisation, l'indexation ou la migration de contenu.

Cet article fournit un guide complet sur la façon d'extraire efficacement du texte de divers formats de présentation, y compris PPT, PPTX et ODP, en utilisant Aspose.Slides for PHP via Java. Vous apprendrez à itérer systématiquement à travers les éléments de la présentation afin de récupérer avec précision le contenu texte dont vous avez besoin.

## **Extraire du texte d'une diapositive**

Aspose.Slides for PHP via Java fournit la classe [SlideUtil](https://reference.aspose.com/slides/fr/php-java/aspose.slides/slideutil/). Cette classe expose plusieurs méthodes statiques surchargées pour extraire tout le texte d'une présentation ou d'une diapositive. Pour extraire le texte d'une diapositive dans une présentation, utilisez la méthode [getAllTextBoxes](https://reference.aspose.com/slides/fr/php-java/aspose.slides/slideutil/#getAllTextBoxes). Cette méthode accepte en paramètre un objet de type [BaseSlide](https://reference.aspose.com/slides/fr/php-java/aspose.slides/baseslide/). Lorsqu'elle est exécutée, la méthode parcourt l'intégralité de la diapositive à la recherche de texte et renvoie un tableau d'objets de type [TextFrame](https://reference.aspose.com/slides/fr/php-java/aspose.slides/textframe/), en conservant tout formatage du texte.

Le fragment de code suivant extrait tout le texte de la première diapositive de la présentation :

```php
$slideIndex = 0;

$presentation = new Presentation("demo.pptx");
$arrayClass = new java_class("java.lang.reflect.Array");

try {
    $slide = $presentation->getSlides()->get_Item($slideIndex);

    $textFrames = SlideUtil::getAllTextBoxes($slide);
    $textFrameCount = java_values($arrayClass->getLength($textFrames));

    for ($textFrameIndex = 0; $textFrameIndex < $textFrameCount; $textFrameIndex++) {
        foreach ($textFrames[$textFrameIndex]->getParagraphs() as $paragraph) {
            foreach ($paragraph->getPortions() as $portion) {
                $portionText = $portion->getText();
                echo($portionText);

                $portionFormat = $portion->getPortionFormat();
                $fontHeight = $portionFormat->getFontHeight();
                echo($fontHeight);

                $latinFont = $portionFormat->getLatinFont();
                if (!java_is_null($latinFont)) {
                    $fontName = $latinFont->getFontName();
                    echo($fontName);
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Extraire du texte d'une présentation**

Pour parcourir le texte de l'ensemble de la présentation, utilisez la méthode statique [getAllTextFrames](https://reference.aspose.com/slides/fr/php-java/aspose.slides/slideutil/#getAllTextFrames) exposée par la classe [SlideUtil](https://reference.aspose.com/slides/fr/php-java/aspose.slides/slideutil/). Elle accepte deux paramètres :

1. Tout d'abord, un objet [Presentation](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/) représentant une présentation PowerPoint ou OpenDocument à partir de laquelle le texte sera extrait.  
1. Deuxièmement, une valeur `boolean` indiquant si les diapositives maîtres doivent être incluses lors du balayage du texte de la présentation.

La méthode renvoie un tableau d'objets de type [TextFrame](https://reference.aspose.com/slides/fr/php-java/aspose.slides/textframe/), incluant les informations de formatage du texte. Le code ci‑dessous parcourt le texte et les détails de formatage d'une présentation, y compris les diapositives maîtres.

```php
$presentation = new Presentation("demo.pptx");
$arrayClass = new java_class("java.lang.reflect.Array");

try {
    $includeMasterSlides = true;
    $textFrames = SlideUtil::getAllTextFrames($presentation, $includeMasterSlides);
    $textFrameCount = java_values($arrayClass->getLength($textFrames));

    for ($textFrameIndex = 0; $textFrameIndex < $textFrameCount; $textFrameIndex++) {
        foreach ($textFrames[$textFrameIndex]->getParagraphs() as $paragraph) {
            foreach ($paragraph->getPortions() as $portion) {
                $portionText = $portion->getText();
                echo($portionText);

                $portionFormat = $portion->getPortionFormat();
                $fontHeight = $portionFormat->getFontHeight();
                echo($fontHeight);

                $latinFont = $portionFormat->getLatinFont();
                if (!java_is_null($latinFont)) {
                    $fontName = $latinFont->getFontName();
                    echo($fontName);
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Extraction de texte catégorisée et rapide**

La classe [PresentationFactory](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentationfactory/) propose également des méthodes pour extraire tout le texte des présentations :

{{58176f3a-eab8-4e3d-b70d-a1390d