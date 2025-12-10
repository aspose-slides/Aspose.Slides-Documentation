---
title: Obtenir l'arrière-plan complet d'une diapositive d'une présentation sous forme d'image
linktitle: Arrière-plan complet de la diapositive
type: docs
weight: 95
url: /fr/java/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- arrière-plan de diapositive
- arrière-plan final
- extraire arrière-plan
- arrière-plan complet
- arrière-plan en image
- arrière-plan PPT
- arrière-plan PPTX
- arrière-plan ODP
- PowerPoint
- OpenDocument
- présentation
- Java
- Aspose.Slides
description: "Extraire les arrière-plans complets des diapositives en images à partir de présentations PowerPoint et OpenDocument à l'aide d'Aspose.Slides pour Java, simplifiant les flux de travail visuels."
---

## **Obtenir l'arrière‑plan complet de la diapositive**

Dans les présentations PowerPoint, l'arrière‑plan d'une diapositive peut être composé de plusieurs éléments. En plus de l'image définie comme [arrière‑plan de la diapositive](/slides/fr/java/presentation-background/), l'arrière‑plan final peut être influencé par le thème de la présentation, le schéma de couleurs et les formes placées sur la diapositive maître et la diapositive de mise en page.

Aspose.Slides for Java ne fournit pas de méthode simple pour extraire l'arrière‑plan complet d'une diapositive de présentation sous forme d'image, mais vous pouvez suivre les étapes ci‑dessous pour le faire :
1. Chargez la présentation en utilisant la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
1. Obtenez la taille de la diapositive à partir de la présentation.
1. Sélectionnez une diapositive.
1. Créez une présentation temporaire.
1. Définissez la même taille de diapositive dans la présentation temporaire.
1. Clonez la diapositive sélectionnée dans la présentation temporaire.
1. Supprimez les formes de la diapositive clonée.
1. Convertissez la diapositive clonée en image.

L'exemple de code suivant extrait l'arrière‑plan complet d'une diapositive de présentation sous forme d'image.
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


## **FAQ**

**Les dégradés complexes, textures ou remplissages d'image provenant d'une diapositive maître seront-ils conservés dans l'image d'arrière‑plan résultante ?**

Oui. Aspose.Slides rend les remplissages de type dégradé, image et texture définis sur la diapositive, la mise en page ou le maître. Si vous devez isoler l'apparence des maîtres hérités, [définissez un arrière‑plan propre](/slides/fr/java/presentation-background/) sur la diapositive actuelle avant l'export.

**Puis-je ajouter un filigrane à l'image d'arrière‑plan résultante avant de l'enregistrer ?**

Oui. Vous pouvez ajouter une forme ou une image de [filigrane](/slides/fr/java/watermark/) sur une [copie de travail de la diapositive](/slides/fr/java/clone-slides/) (placée derrière le reste du contenu) puis l'exporter. Cela vous permet de générer une image d'arrière‑plan avec le filigrane intégré.

**Puis-je obtenir l'arrière‑plan d'une mise en page ou d'un maître spécifique sans le lier à une diapositive existante ?**

Oui. Accédez au maître ou à la mise en page souhaité(e), appliquez‑le à une [diapositive temporaire](/slides/fr/java/clone-slides/) avec la taille requise, puis exportez cette diapositive pour obtenir l'arrière‑plan dérivé de cette mise en page ou de ce maître.

**Existe‑t‑il des limitations de licence affectant l'exportation d'images ?**

Les fonctionnalités de rendu sont pleinement disponibles avec une [licence valide](/slides/fr/java/licensing/). En mode évaluation, la sortie peut comporter des limitations comme un filigrane. Activez la licence une fois par processus avant d'exécuter les exportations en lot.