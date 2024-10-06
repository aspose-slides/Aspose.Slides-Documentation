---
title: Obtenir l'arrière-plan de la diapositive de présentation entière en tant qu'image
type: docs
weight: 95
url: /net/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- diapositive
- arrière-plan
- arrière-plan de diapositive
- arrière-plan en tant qu'image
- PowerPoint
- PPT
- PPTX
- présentation PowerPoint
- C#
- VB.NET
- Aspose.Slides for .NET
---

Dans les présentations PowerPoint, l'arrière-plan de la diapositive peut se composer de nombreux éléments. En plus de l'image définie comme [arrière-plan de diapositive](/slides/net/presentation-background/), l'arrière-plan final peut être influencé par le thème de la présentation, le schéma de couleurs et les formes placées sur la diapositive maîtresse et la diapositive de mise en page.

Aspose.Slides for .NET ne fournit pas de méthode simple pour extraire l'arrière-plan entier de la diapositive de présentation en tant qu'image, mais vous pouvez suivre les étapes ci-dessous pour le faire :
1. Chargez la présentation à l'aide de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Obtenez la taille de la diapositive à partir de la présentation.
1. Sélectionnez une diapositive.
1. Créez une présentation temporaire.
1. Définissez la même taille de diapositive dans la présentation temporaire.
1. Clonez la diapositive sélectionnée dans la présentation temporaire.
1. Supprimez les formes de la diapositive clonée.
1. Convertissez la diapositive clonée en image.

L'exemple de code suivant extrait l'arrière-plan entier de la diapositive de présentation en tant qu'image.
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