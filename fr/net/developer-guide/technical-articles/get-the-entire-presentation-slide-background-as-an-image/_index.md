---
title: Obtenir l'arrière-plan complet de la diapositive de présentation en tant qu'image
type: docs
weight: 95
url: /fr/net/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- diapositive
- arrière-plan
- arrière-plan de la diapositive
- arrière-plan en image
- PowerPoint
- PPT
- PPTX
- présentation PowerPoint
- C#
- VB.NET
- Aspose.Slides for .NET
---

## **Obtenir l'arrière‑plan complet de la diapositive**

Dans les présentations PowerPoint, l'arrière‑plan de la diapositive peut être composé de plusieurs éléments. En plus de l'image définie comme [arrière‑plan de la diapositive](/slides/fr/net/presentation-background/), l'arrière‑plan final peut être influencé par le thème de la présentation, le jeu de couleurs et les formes placées sur la diapositive maître et la diapositive de mise en page.

Aspose.Slides for .NET ne fournit pas de méthode simple pour extraire l'arrière‑plan complet d'une diapositive de présentation en tant qu'image, mais vous pouvez suivre les étapes ci‑dessous pour le faire :
1. Chargez la présentation en utilisant la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Obtenez la taille de la diapositive à partir de la présentation.
1. Sélectionnez une diapositive.
1. Créez une présentation temporaire.
1. Définissez la même taille de diapositive dans la présentation temporaire.
1. Clonez la diapositive sélectionnée dans la présentation temporaire.
1. Supprimez les formes de la diapositive clonée.
1. Convertissez la diapositive clonée en image.

L'exemple de code suivant extrait l'arrière‑plan complet d'une diapositive de présentation sous forme d'image.
```cs
var slideIndex = 0;
var imageScale = 1;

using var presentation = new Presentation("sample.pptx");

var slideSize = presentation.SlideSize.Size;
var slide = presentation.Slides[slideIndex];

using var tempPresentation = new Presentation();    
tempPresentation.SlideSize.SetSize(slideSize.Width, slideSize.Height, SlideSizeScaleType.DoNotScale);

var clonedSlide = tempPresentation.Slides.AddClone(slide);
clonedSlide.Shapes.Clear();

using var background = clonedSlide.GetImage(imageScale, imageScale);
background.Save("output.png", ImageFormat.Png);
```


## **FAQ**

**Les dégradés complexes, textures ou remplissages d'image d'une diapositive maître seront-ils conservés dans l'image d'arrière‑plan résultante ?**

Oui. Aspose.Slides rend les remplissages en dégradé, image et texture définis sur la diapositive, la mise en page ou le maître. Si vous devez isoler l'apparence des maîtres hérités, [définissez un arrière‑plan propre](/slides/fr/net/presentation-background/) sur la diapositive actuelle avant l'exportation.

**Puis‑je ajouter un filigrane à l'image d'arrière‑plan résultante avant de l'enregistrer ?**

Oui. Vous pouvez [ajouter un filigrane](/slides/fr/net/watermark/) sous forme de forme ou d'image sur une [copie de travail de la diapositive](/slides/fr/net/clone-slides/) (placée derrière le reste du contenu) puis exporter. Cela vous permet de générer une image d'arrière‑plan avec le filigrane intégré.

**Puis‑je obtenir l'arrière‑plan d'une mise en page ou d'un maître spécifique sans le lier à une diapositive existante ?**

Oui. Accédez au maître ou à la mise en page souhaité(e), appliquez‑le à une [diapositive temporaire](/slides/fr/net/clone-slides/) de la taille requise, puis exportez cette diapositive pour obtenir l'arrière‑plan dérivé de cette mise en page ou de ce maître.

**Existe‑t‑il des limitations de licence affectant l'exportation d'images ?**

Les fonctionnalités de rendu sont pleinement disponibles avec une [licence valide](/slides/fr/net/licensing/). En mode d'évaluation, la sortie peut comporter des limitations comme un filigrane. Activez la licence une fois par processus avant d'exécuter les exportations par lots.