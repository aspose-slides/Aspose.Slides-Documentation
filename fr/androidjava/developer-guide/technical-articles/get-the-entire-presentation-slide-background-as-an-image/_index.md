---
title: Obtenir l'intégralité de l'arrière-plan de la diapositive de présentation en tant qu'image
type: docs
weight: 95
url: /androidjava/get-the-entire-presentation-slide-background-as-an-image/
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
- Aspose.Slides pour Android via Java
---

Dans les présentations PowerPoint, l'arrière-plan de la diapositive peut consister en de nombreux éléments. En plus de l'image définie comme [arrière-plan de diapositive](/slides/androidjava/presentation-background/), l'arrière-plan final peut être influencé par le thème de la présentation, le schéma de couleurs et les formes placées sur la diapositive maître et la diapositive de mise en page.

Aspose.Slides pour Android via Java ne fournit pas de méthode simple pour extraire l'intégralité de l'arrière-plan de la diapositive de présentation en tant qu'image, mais vous pouvez suivre les étapes ci-dessous pour le faire :
1. Chargez la présentation en utilisant la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
1. Obtenez la taille de la diapositive depuis la présentation.
1. Sélectionnez une diapositive.
1. Créez une présentation temporaire.
1. Définissez la même taille de diapositive dans la présentation temporaire.
1. Clonez la diapositive sélectionnée dans la présentation temporaire.
1. Supprimez les formes de la diapositive clonée.
1. Convertissez la diapositive clonée en une image.

L'exemple de code suivant extrait l'intégralité de l'arrière-plan de la diapositive de présentation en tant qu'image.
```java
int slideIndex = 0;
int imageScale = 1;

Presentation presentation = new Presentation("sample.pptx");

Dimension2D slideSize = presentation.getSlideSize().getSize();
ISlide slide = presentation.getSlides().get_Item(slideIndex);

Presentation tempPresentation = new Presentation();

float slideWidth = (float)slideSize.getWidth();
float slideHeight = (float)slideSize.getHeight();
tempPresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.DoNotScale);

ISlide clonedSlide = tempPresentation.getSlides().addClone(slide);
clonedSlide.getShapes().clear();

IImage background = clonedSlide.getImage(imageScale, imageScale);
background.save("output.png", ImageFormat.Png);

tempPresentation.dispose();
presentation.dispose();
```