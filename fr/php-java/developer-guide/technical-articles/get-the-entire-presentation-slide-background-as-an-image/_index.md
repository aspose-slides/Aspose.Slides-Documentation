---
title: Obtenir l'ensemble de l'arrière-plan d'une diapositive d'une présentation sous forme d'image
linktitle: Arrière-plan complet de la diapositive
type: docs
weight: 95
url: /fr/php-java/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- arrière-plan de diapositive
- arrière-plan final
- extraire l'arrière-plan
- arrière-plan complet
- arrière-plan en image
- arrière-plan PPT
- arrière-plan PPTX
- arrière-plan ODP
- PowerPoint
- OpenDocument
- présentation
- PHP
- Aspose.Slides
description: "Extraire les arrière-plans complets des diapositives sous forme d'images à partir de présentations PowerPoint et OpenDocument à l'aide d'Aspose.Slides pour PHP via Java, simplifiant les flux de travail visuels."
---

## **Obtenir tout l'arrière‑plan de la diapositive**

Dans les présentations PowerPoint, l'arrière‑plan d'une diapositive peut être composé de plusieurs éléments. En plus de l'image définie comme [arrière‑plan de la diapositive](/slides/fr/php-java/presentation-background/), l'arrière‑plan final peut être influencé par le thème de la présentation, le jeu de couleurs et les formes placées sur la diapositive maîtresse et la diapositive de mise en page.

Aspose.Slides for PHP via Java ne fournit pas de méthode simple pour extraire tout l'arrière‑plan d'une diapositive de présentation sous forme d'image, mais vous pouvez suivre les étapes ci‑dé dessous pour le faire :
1. Charger la présentation à l'aide de la classe [Presentation](https://reference.aspose.com/slides/php-java/com.aspose.slides/presentation/).
1. Obtenir la taille de la diapositive depuis la présentation.
1. Sélectionner une diapositive.
1. Créer une présentation temporaire.
1. Définir la même taille de diapositive dans la présentation temporaire.
1. Cloner la diapositive sélectionnée dans la présentation temporaire.
1. Supprimer les formes de la diapositive clonée.
1. Convertir la diapositive clonée en image.

L'exemple de code suivant extrait tout l'arrière‑plan de la diapositive de la présentation sous forme d'image.
```php
$slideIndex = 0;
$imageScale = 1;

$presentation = new Presentation("sample.pptx");

$slideSize = $presentation->getSlideSize()->getSize();
$slide = $presentation->getSlides()->get_Item($slideIndex);

$tempPresentation = new Presentation();

$slideWidth = $slideSize->getWidth();
$slideHeight = $slideSize->getHeight();
$tempPresentation->getSlideSize()->setSize($slideWidth, $slideHeight, SlideSizeScaleType::DoNotScale);

$clonedSlide = $tempPresentation->getSlides()->addClone($slide);
$clonedSlide->getShapes()->clear();

$background = clonedSlide->getImage($imageScale, $imageScale);
$background->save("output->png", ImageFormat::Png);

$tempPresentation->dispose();
$presentation->dispose();
```


## **FAQ**

**Les dégradés complexes, textures ou remplissages d'image d'une diapositive maîtresse seront-ils conservés dans l'image d'arrière‑plan résultante ?**

Oui. Aspose.Slides rend les remplissages en dégradé, image et texture définis sur la diapositive, la mise en page ou la maîtresse. Si vous devez isoler l'apparence des maîtresses héritées, [définissez un arrière‑plan propre](/slides/fr/php-java/presentation-background/) sur la diapositive actuelle avant l'exportation.

**Puis-je ajouter un filigrane à l'image d'arrière‑plan résultante avant de l'enregistrer ?**

Oui. Vous pouvez [ajouter un filigrane](/slides/fr/php-java/watermark/) sous forme de forme ou d'image sur une [copie de travail de la diapositive](/slides/fr/php-java/clone-slides/) (placée derrière le reste du contenu) puis l'exporter. Cela vous permet de générer une image d'arrière‑plan avec le filigrane intégré.

**Puis-je obtenir l'arrière‑plan d'une mise en page ou d'une maîtresse spécifique sans le lier à une diapositive existante ?**

Oui. Accédez à la maîtresse ou à la mise en page souhaitée, appliquez‑la à une [diapositive temporaire](/slides/fr/php-java/clone-slides/) avec la taille requise, puis exportez cette diapositive pour obtenir l'arrière‑plan dérivé de cette mise en page ou de cette maîtresse.

**Existe‑t‑il des limitations de licence qui affectent l'exportation d'images ?**

Les fonctionnalités de rendu sont entièrement disponibles avec une [licence valide](/slides/fr/php-java/licensing/). En mode d'évaluation, la sortie peut inclure des limitations telles qu'un filigrane. Activez la licence une fois par processus avant d'exécuter des exportations par lots.