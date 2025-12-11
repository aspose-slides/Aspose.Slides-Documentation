---
title: Obtenir l'arrière-plan complet de la diapositive d'une présentation sous forme d'image
linktitle: Arrière-plan complet de la diapositive
type: docs
weight: 95
url: /fr/cpp/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- arrière-plan de la diapositive
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
- C++
- Aspose.Slides
description: "Extrayez les arrière-plans complets des diapositives en images à partir de présentations PowerPoint et OpenDocument à l'aide d'Aspose.Slides pour C++, facilitant les flux de travail visuels."
---

## **Obtenir l'arrière-plan complet de la diapositive**

Dans les présentations PowerPoint, l'arrière-plan de la diapositive peut être composé de plusieurs éléments. En plus de l'image définie comme l'[arrière-plan de la diapositive](/slides/fr/cpp/presentation-background/), l'arrière-plan final peut être influencé par le thème de la présentation, le schéma de couleurs et les formes placées sur la diapositive maître et la diapositive de mise en page.

Aspose.Slides for C++ ne fournit pas de méthode simple pour extraire l'arrière-plan complet d'une diapositive de présentation sous forme d'image, mais vous pouvez suivre les étapes ci-dessous pour le faire :
1. Chargez la présentation en utilisant la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Obtenez la taille de la diapositive à partir de la présentation.
1. Sélectionnez une diapositive.
1. Créez une présentation temporaire.
1. Définissez la même taille de diapositive dans la présentation temporaire.
1. Clonez la diapositive sélectionnée dans la présentation temporaire.
1. Supprimez les formes de la diapositive clonée.
1. Convertissez la diapositive clonée en image.

L'exemple de code suivant extrait l'arrière-plan complet d'une diapositive de présentation sous forme d'image.
```cpp
auto slideIndex = 0;
auto imageScale = 1;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto slideSize = presentation->get_SlideSize()->get_Size();
auto slide = presentation->get_Slides()->idx_get(slideIndex);

auto tempPresentation = System::MakeObject<Presentation>();

auto slideWidth = slideSize.get_Width();
auto slideHeight = slideSize.get_Height();
tempPresentation->get_SlideSize()->SetSize(slideWidth, slideHeight, SlideSizeScaleType::DoNotScale);

auto clonedSlide = tempPresentation->get_Slides()->AddClone(slide);
clonedSlide->get_Shapes()->Clear();

auto background = clonedSlide->GetImage(imageScale, imageScale);
background->Save(u"output.png", ImageFormat::Png);

tempPresentation->Dispose();
presentation->Dispose();
```


## **FAQ**

**Les dégradés complexes, textures ou remplissages d'image d'une diapositive maître seront-ils conservés dans l'image d'arrière-plan résultante ?**

Oui. Aspose.Slides rend les remplissages de dégradé, d'image et de texture définis sur la diapositive, la mise en page ou le maître. Si vous devez isoler l'apparence des maîtres hérités, [définissez un arrière‑plan propre](/slides/fr/cpp/presentation-background/) sur la diapositive actuelle avant l'exportation.

**Puis-je ajouter un filigrane à l'image d'arrière-plan résultante avant de l'enregistrer ?**

Oui. Vous pouvez [ajouter un filigrane](/slides/fr/cpp/watermark/) sous forme de forme ou d'image sur une [copie de travail de la diapositive](/slides/fr/cpp/clone-slides/) (placée derrière le reste du contenu), puis exporter. Cela vous permet de générer une image d'arrière‑plan avec le filigrane intégré.

**Puis-je obtenir l'arrière‑plan d'une mise en page ou d'un maître spécifique sans le lier à une diapositive existante ?**

Oui. Accédez au maître ou à la mise en page souhaité(e), appliquez‑le à une [diapositive temporaire](/slides/fr/cpp/clone-slides/) avec la taille requise, puis exportez cette diapositive pour obtenir l'arrière‑plan dérivé de cette mise en page ou de ce maître.

**Existe‑t‑il des limitations de licence qui affectent l'exportation d'images ?**

Les fonctionnalités de rendu sont entièrement disponibles avec une [licence valide](/slides/fr/cpp/licensing/). En mode évaluation, la sortie peut inclure des limitations comme un filigrane. Activez la licence une fois par processus avant d'exécuter des exportations batch.