---
title: Obtenir l'ensemble de l'arrière-plan de la diapositive de présentation en tant qu'image
type: docs
weight: 95
url: /cpp/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- diapositive
- arrière-plan
- arrière-plan de diapositive
- arrière-plan en tant qu'image
- PowerPoint
- PPT
- PPTX
- présentation PowerPoint
- C++
- Aspose.Slides pour C++
---

Dans les présentations PowerPoint, l'arrière-plan de la diapositive peut se composer de nombreux éléments. En plus de l'image définie comme [arrière-plan de diapositive](/slides/cpp/presentation-background/), l'arrière-plan final peut être influencé par le thème de présentation, le schéma de couleurs et les formes placées sur la diapositive maître et la diapositive de mise en page.

Aspose.Slides pour C++ ne propose pas de méthode simple pour extraire l'ensemble de l'arrière-plan de la diapositive de présentation en tant qu'image, mais vous pouvez suivre les étapes ci-dessous pour le faire :
1. Chargez la présentation en utilisant la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Obtenez la taille de la diapositive à partir de la présentation.
1. Sélectionnez une diapositive.
1. Créez une présentation temporaire.
1. Définissez la même taille de diapositive dans la présentation temporaire.
1. Clonez la diapositive sélectionnée dans la présentation temporaire.
1. Supprimez les formes de la diapositive clonée.
1. Convertissez la diapositive clonée en image.

L'exemple de code suivant extrait l'ensemble de l'arrière-plan de la diapositive de présentation en tant qu'image.
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