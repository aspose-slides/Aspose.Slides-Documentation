---
title: Obtenir l'ensemble de l'arrière-plan de la diapositive de présentation en tant qu'image
type: docs
weight: 95
url: /fr/java/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- diapositive
- arrière-plan
- arrière-plan de diapositive
- arrière-plan en une image
- PowerPoint
- PPT
- PPTX
- présentation PowerPoint
- Java
- Aspose.Slides pour Java
---

Dans les présentations PowerPoint, l'arrière-plan de la diapositive peut être constitué de nombreux éléments. En plus de l'image définie comme l'[arrière-plan de la diapositive](/slides/fr/java/presentation-background/), l'arrière-plan final peut être influencé par le thème de la présentation, le schéma de couleurs et les formes placées sur la diapositive maître et la diapositive de mise en page.

Aspose.Slides pour Java ne fournit pas de méthode simple pour extraire l'ensemble de l'arrière-plan de la diapositive de présentation en tant qu'image, mais vous pouvez suivre les étapes ci-dessous pour le faire :
1. Charger la présentation en utilisant la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
1. Obtenez la taille de la diapositive de la présentation.
1. Sélectionnez une diapositive.
1. Créez une présentation temporaire.
1. Définissez la même taille de diapositive dans la présentation temporaire.
1. Clonez la diapositive sélectionnée dans la présentation temporaire.
1. Supprimez les formes de la diapositive clonée.
1. Convertissez la diapositive clonée en image.

L'exemple de code suivant extrait l'ensemble de l'arrière-plan de la diapositive de présentation en tant qu'image.
```java
var slideIndex = 0;
var imageScale = 1;

var presentation = new Presentation("sample.pptx");

var slideSize = presentation.getSlideSize().getSize();
var slide = presentation.getSlides().get_Item(slideIndex);

var tempPresentation = new Presentation();

var slideWidth = (float)slideSize.getWidth();
var slideHeight = (float)slideSize.getHeight();
tempPresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.DoNotScale);

var clonedSlide = tempPresentation.getSlides().addClone(slide);
clonedSlide.getShapes().clear();

var background = clonedSlide.getImage(imageScale, imageScale);
background.save("output.png", ImageFormat.Png);

tempPresentation.dispose();
presentation.dispose();
```