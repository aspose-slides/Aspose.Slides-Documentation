---
title: Obtenir l'arrière-plan complet d'une diapositive de présentation sous forme d'image
type: docs
weight: 95
url: /fr/nodejs-java/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- diapositive
- arrière-plan
- arrière-plan de diapositive
- arrière-plan en image
- PowerPoint
- PPT
- PPTX
- présentation PowerPoint
- Node
- JavaScript
- Aspose.Slides pour Node.js via Java
---

## **Obtenir l'arrière-plan complet de la diapositive**

Dans les présentations PowerPoint, l'arrière-plan de la diapositive peut être composé de nombreux éléments. En plus de l'image définie comme l[arrière-plan de la diapositive](/slides/fr/nodejs-java/presentation-background/), l'arrière-plan final peut être influencé par le thème de la présentation, le jeu de couleurs et les formes placées sur la diapositive maître et la diapositive de mise en page.

Aspose.Slides for Node.js via Java ne fournit pas de méthode simple pour extraire l'arrière-plan complet d'une diapositive de présentation sous forme d'image, mais vous pouvez suivre les étapes ci-dessous pour le faire :
1. Chargez la présentation en utilisant la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
1. Obtenez la taille de la diapositive à partir de la présentation.
1. Sélectionnez une diapositive.
1. Créez une présentation temporaire.
1. Définissez la même taille de diapositive dans la présentation temporaire.
1. Clonez la diapositive sélectionnée dans la présentation temporaire.
1. Supprimez les formes de la diapositive clonée.
1. Convertissez la diapositive clonée en image.

Le code suivant extrait l'arrière-plan complet de la diapositive de présentation sous forme d'image.
```javascript
var slideIndex = 0;
var imageScale = 1;
var presentation = new aspose.slides.Presentation("sample.pptx");
var slideSize = presentation.getSlideSize().getSize();
var slide = presentation.getSlides().get_Item(slideIndex);
var tempPresentation = new aspose.slides.Presentation();
var slideWidth = slideSize.getWidth();
var slideHeight = slideSize.getHeight();
tempPresentation.getSlideSize().setSize(slideWidth, slideHeight, aspose.slides.SlideSizeScaleType.DoNotScale);
var clonedSlide = tempPresentation.getSlides().addClone(slide);
clonedSlide.getShapes().clear();
var background = clonedSlide.getImage(imageScale, imageScale);
background.save("output.png", aspose.slides.ImageFormat.Png);
tempPresentation.dispose();
presentation.dispose();
```


## **FAQ**

**Les dégradés complexes, textures ou remplissages d'image d'une diapositive maître seront-ils conservés dans l'image d'arrière-plan résultante ?**

Oui. Aspose.Slides rend les remplissages de dégradé, d'image et de texture définis sur la diapositive, la mise en page ou le maître. Si vous devez isoler l'apparence des maîtres hérités, [définissez un arrière-plan propre](/slides/fr/nodejs-java/presentation-background/) sur la diapositive actuelle avant l'exportation.

**Puis-je ajouter un filigrane à l'image d'arrière-plan résultante avant de l'enregistrer ?**

Oui. Vous pouvez [ajouter un filigrane](/slides/fr/nodejs-java/watermark/) sous forme de forme ou d'image sur une [copie de travail de la diapositive](/slides/fr/nodejs-java/clone-slides/) (placée derrière le reste du contenu) puis exporter. Cela vous permet de générer une image d'arrière-plan avec le filigrane intégré.

**Puis-je obtenir l'arrière-plan d'une mise en page ou d'un maître spécifique sans le lier à une diapositive existante ?**

Oui. Accédez au maître ou à la mise en page souhaité(e), appliquez-le à une [diapositive temporaire](/slides/fr/nodejs-java/clone-slides/) avec la taille requise, puis exportez cette diapositive pour obtenir l'arrière-plan dérivé de cette mise en page ou de ce maître.

**Existe-t-il des limitations de licence affectant l'exportation d'images ?**

Les fonctionnalités de rendu sont pleinement disponibles avec une [licence valide](/slides/fr/nodejs-java/licensing/). En mode d'évaluation, la sortie peut comporter des limitations telles qu'un filigrane. Activez la licence une fois par processus avant d'exécuter les exportations en lot.