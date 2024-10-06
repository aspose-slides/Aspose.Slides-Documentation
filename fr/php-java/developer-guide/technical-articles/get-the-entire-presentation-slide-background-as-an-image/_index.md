---
title: Obtenir l'arrière-plan entier de la diapositive de présentation en tant qu'image
type: docs
weight: 95
url: /php-java/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- diapositive
- arrière-plan
- arrière-plan de diapositive
- arrière-plan en tant qu'image
- PowerPoint
- PPT
- PPTX
- présentation PowerPoint
- Java
- Php
- Aspose.Slides pour PHP via Java
---

Dans les présentations PowerPoint, l'arrière-plan de diapositive peut être constitué de nombreux éléments. En plus de l'image définie comme l'[arrière-plan de la diapositive](/slides/php-java/presentation-background/), l'arrière-plan final peut être influencé par le thème de la présentation, le schéma de couleurs et les formes placées sur la diapositive maître et la diapositive de mise en page.

Aspose.Slides pour PHP via Java ne fournit pas de méthode simple pour extraire l'arrière-plan entier de la diapositive de présentation en tant qu'image, mais vous pouvez suivre les étapes ci-dessous pour le faire :
1. Chargez la présentation en utilisant la classe [Presentation](https://reference.aspose.com/slides/php-java/com.aspose.slides/presentation/).
1. Obtenez la taille de la diapositive à partir de la présentation.
1. Sélectionnez une diapositive.
1. Créez une présentation temporaire.
1. Définissez la même taille de diapositive dans la présentation temporaire.
1. Clonez la diapositive sélectionnée dans la présentation temporaire.
1. Supprimez les formes de la diapositive clonée.
1. Convertissez la diapositive clonée en image.

L'exemple de code suivant extrait l'arrière-plan entier de la diapositive de présentation en tant qu'image.
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