---
title: Obtenir le fond complet de la diapositive d'une présentation sous forme d'image
linktitle: Fond complet de la diapositive
type: docs
weight: 95
url: /fr/net/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- fond de diapositive
- fond final
- extraction du fond
- fond complet
- fond en image
- fond PPT
- fond PPTX
- fond ODP
- PowerPoint
- OpenDocument
- présentation
- .NET
- C#
- Aspose.Slides
description: "Extrayez les fonds complets des diapositives sous forme d'images à partir de présentations PowerPoint et OpenDocument en utilisant Aspose.Slides pour .NET, simplifiant les flux de travail visuels."
---

## **Obtenir le fond complet de la diapositive**

Dans les présentations PowerPoint, l'arrière‑plan de la diapositive peut être composé de nombreux éléments. En plus de l'image définie comme le [arrière‑plan de la diapositive](/slides/fr/net/presentation-background/), l'arrière‑plan final peut être influencé par le thème de la présentation, le jeu de couleurs et les formes placées sur la diapositive maître et la diapositive de disposition.

Aspose.Slides pour .NET ne fournit pas de méthode simple pour extraire l'arrière‑plan complet d'une diapositive de présentation sous forme d'image, mais vous pouvez suivre les étapes ci‑dessous pour le faire :
1. Chargez la présentation en utilisant la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Obtenez la taille de la diapositive à partir de la présentation.
1. Sélectionnez une diapositive.
1. Créez une présentation temporaire.
1. Définissez la même taille de diapositive dans la présentation temporaire.
1. Clonez la diapositive sélectionnée dans la présentation temporaire.
1. Supprimez les formes de la diapositive clonée.
1. Convertissez la diapositive clonée en image.

Le code suivant extrait l'arrière‑plan complet d'une diapositive de présentation sous forme d'image.
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

**Les dégradés complexes, textures ou remplissages d'image provenant d'une diapositive maître seront-ils conservés dans l'image d'arrière‑plan résultante ?**

Oui. Aspose.Slides rend les remplissages en dégradé, image et texture définis sur la diapositive, la disposition ou le maître. Si vous devez isoler l'apparence des maîtres hérités, [définir un arrière‑plan propre](/slides/fr/net/presentation-background/) sur la diapositive actuelle avant l'export.

**Puis-je ajouter un filigrane à l'image d'arrière‑plan résultante avant de l'enregistrer ?**

Oui. Vous pouvez [ajouter un filigrane](/slides/fr/net/watermark/) sous forme de forme ou d'image sur une [copie de la diapositive](/slides/fr/net/clone-slides/) de travail (placée derrière les autres contenus) puis exporter. Cela vous permet de générer une image d'arrière‑plan avec le filigrane intégré.

**Puis-je obtenir l'arrière‑plan d'une disposition ou d'un maître spécifique sans le lier à une diapositive existante ?**

Oui. Accédez au maître ou à la disposition souhaité(e), appliquez‑le à une [diapositive temporaire](/slides/fr/net/clone-slides/) avec la taille requise, puis exportez cette diapositive pour obtenir l'arrière‑plan dérivé de cette disposition ou de ce maître.

**Existe-t-il des limitations de licence affectant l'exportation d'images ?**

Les fonctionnalités de rendu sont pleinement disponibles avec une [licence valide](/slides/fr/net/licensing/). En mode évaluation, la sortie peut inclure des limitations telles qu'un filigrane. Activez la licence une fois par processus avant d'exécuter les exportations par lots.