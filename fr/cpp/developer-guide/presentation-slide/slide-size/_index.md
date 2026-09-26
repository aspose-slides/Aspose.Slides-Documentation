---
title: Modifier la taille des diapositives de la présentation en C++
linktitle: Taille de la diapositive
type: docs
weight: 70
url: /fr/cpp/slide-size/
keywords:
- taille de diapositive
- ratio d’aspect
- standard
- grand écran
- 4:3
- 16:9
- définir la taille de la diapositive
- modifier la taille de la diapositive
- taille de diapositive personnalisée
- taille de diapositive spéciale
- taille de diapositive unique
- diapositive pleine taille
- type d’écran
- ne pas mettre à l’échelle
- garantir l’ajustement
- maximiser
- PowerPoint
- OpenDocument
- présentation
- C++
- Aspose.Slides
description: "Apprenez à redimensionner rapidement les diapositives dans les fichiers PPT, PPTX et ODP avec C++ et Aspose.Slides, et à optimiser les présentations pour n’importe quel écran sans perte de qualité."
---
## **Introduction**

Aspose.Slides fournit des outils complets pour ajuster la taille des diapositives et le ratio d’aspect dans les présentations PowerPoint, essentiels tant pour l’impression que pour l’affichage à l’écran. 

Tailles de diapositives et ratios courants :

- **Standard (ratio d’aspect 4:3)** : Idéal pour les écrans et appareils plus anciens.
- **Widescreen (ratio d’aspect 16:9)** : Recommandé pour les projecteurs et affichages modernes.

Assurez la cohérence de votre présentation en appliquant une taille de diapositive et un ratio d’aspect uniques à toutes les diapositives. Pour de meilleurs résultats, définissez les dimensions de vos diapositives au début du processus de création afin d’éviter des complications.

{{% alert color="info" %}} 
Par défaut, les présentations créées avec Aspose.Slides utilisent le ratio d’aspect standard 4:3.
{{% /alert %}}

Les pages de notes et de support ont des dimensions distinctes des diapositives normales. Consultez [Taille de la page de notes](/slides/fr/cpp/notes-size/) pour modifier leur taille et orientation.

## **Modifier la taille des diapositives dans les présentations**

 Ce code d’exemple montre comment modifier la taille d’une diapositive dans une présentation en C++ avec Aspose.Slides :

``` cpp
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <DOM/SlideSizeType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres-4x3-aspect-ratio.pptx");
pres->get_SlideSize()->SetSize(SlideSizeType::OnScreen16x9, SlideSizeScaleType::DoNotScale);
pres->Save(u"pres-4x3-aspect-ratio.pptx", SaveFormat::Pptx);
```

## **Spécifier des tailles de diapositives personnalisées dans les présentations**

Si les tailles de diapositives courantes (4:3 et 16:9) ne conviennent pas à votre travail, vous pouvez choisir une taille de diapositive spécifique ou unique. Par exemple, si vous prévoyez d’imprimer des diapositives en taille réelle à partir de votre présentation sur une mise en page de page personnalisée ou si vous devez afficher votre présentation sur certains types d’écrans, l’utilisation d’une taille personnalisée peut être bénéfique. 

Ce code d’exemple montre comment spécifier une taille de diapositive personnalisée pour une présentation en C++ avec Aspose.Slides :

``` cpp
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
// Taille de papier A4
pres->get_SlideSize()->SetSize(780.0f, 540.0f, SlideSizeScaleType::DoNotScale);
pres->Save(u"pres-a4-slide-size.pptx", SaveFormat::Pptx);
```

## **Gérer le contenu des diapositives après le redimensionnement**

Après avoir modifié la taille des diapositives d’une présentation, le contenu des diapositives (images ou objets, par exemple) peut se déformer. Par défaut, les objets sont automatiquement redimensionnés pour s’adapter à la nouvelle taille. Cependant, lors du changement de la taille des diapositives, vous pouvez spécifier un paramètre qui détermine comment Aspose.Slides traite le contenu des diapositives.

Selon votre objectif, vous pouvez utiliser l’un de ces paramètres :

- `DoNotScale`

  Si vous ne voulez PAS que les objets des diapositives soient redimensionnés, utilisez ce paramètre.

- `EnsureFit`

  Si vous devez réduire la taille des diapositives et que vous voulez qu’Aspose.Slides réduit les objets afin qu’ils tiennent tous sur les diapositives (pour éviter de perdre du contenu), utilisez ce paramètre. 

- `Maximize`

  Si vous devez augmenter la taille des diapositives et que vous voulez qu’Aspose.Slides agrandisse les objets pour les rendre proportionnels à la nouvelle taille, utilisez ce paramètre. 

Ce code d’exemple montre comment utiliser le paramètre `Maximize` lors du changement de la taille des diapositives d’une présentation :

``` cpp
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <DOM/SlideSizeType.h>
using namespace Aspose::Slides;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->get_SlideSize()->SetSize(SlideSizeType::Ledger, SlideSizeScaleType::Maximize);
```

## **FAQ**

### Puis-je définir une taille de diapositive personnalisée en utilisant des unités autres que les pouces (par exemple, points ou millimètres) ?

Oui. Aspose.Slides utilise les points en interne, où 1 point équivaut à 1/72 de pouce. Vous pouvez convertir n’importe quelle unité (comme les millimètres ou centimètres) en points et utiliser ces valeurs converties pour définir la largeur et la hauteur de la diapositive.

### Une taille de diapositive personnalisée très grande affectera-t-elle les performances et l’utilisation de la mémoire lors du rendu ?

Oui. Des dimensions de diapositive plus importantes (en points) combinées à une échelle de rendu plus élevée entraînent une consommation de mémoire accrue et des temps de traitement plus longs. Optez pour une taille de diapositive pratique et ajustez l’échelle de rendu uniquement si nécessaire pour obtenir la qualité souhaitée.

### Puis-je définir une taille de diapositive non standard puis fusionner des diapositives provenant de présentations de tailles différentes ?

Vous ne pouvez pas [fusionner des présentations](/slides/fr/cpp/merge-presentation/) lorsqu’elles ont des tailles de diapositives différentes — redimensionnez d’abord une présentation pour qu’elle corresponde à l’autre. Lors du changement de la taille des diapositives, vous pouvez choisir la façon dont le contenu existant est géré via l’option [SlideSizeScaleType](https://reference.aspose.com/slides/fr/cpp/aspose.slides/slidesizescaletype/). Après avoir aligné les tailles, vous pouvez fusionner les diapositives tout en conservant le formatage.

### Puis-je générer des vignettes pour des formes individuelles ou des régions spécifiques d’une diapositive, et respecteront-elles la nouvelle taille de diapositive ?

Oui. Aspose.Slides peut rendre des vignettes pour [diapositives entières](https://reference.aspose.com/slides/fr/cpp/aspose.slides/slide/getimage/) ainsi que pour des [formes sélectionnées](https://reference.aspose.com/slides/fr/cpp/aspose.slides/shape/getimage/). Les images résultantes reflètent la taille et le ratio d’aspect actuels de la diapositive, garantissant un cadrage et une géométrie cohérents.