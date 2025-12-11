---
title: Modifier la taille des diapositives de la présentation en C++
linktitle: Taille de la diapositive
type: docs
weight: 70
url: /fr/cpp/slide-size/
keywords:
- taille de diapositive
- ratio d'aspect
- standard
- écran large
- 4:3
- 16:9
- définir la taille de la diapositive
- changer la taille de la diapositive
- taille de diapositive personnalisée
- taille de diapositive spéciale
- taille de diapositive unique
- diapositive en taille réelle
- type d'écran
- ne pas mettre à l'échelle
- assurer l'ajustement
- maximiser
- PowerPoint
- OpenDocument
- présentation
- C++
- Aspose.Slides
descriptions: "Apprenez à redimensionner rapidement les diapositives dans les fichiers PPT, PPTX et ODP avec C++ et Aspose.Slides, optimisez les présentations pour tout écran sans perte de qualité."
---

## **Tailles des diapositives dans les présentations PowerPoint**

Aspose.Slides for C++ vous permet de modifier la taille ou le ratio d’aspect des diapositives dans les présentations PowerPoint. Si vous prévoyez d’imprimer votre présentation ou d’afficher ses diapositives sur un écran, vous devez faire attention à leur taille ou à leur ratio d’aspect. 

Voici les tailles de diapositives et ratios d’aspect les plus courants :

- **Standard (ratio d'aspect 4:3)**

  Si votre présentation doit être affichée ou consultée sur des appareils ou écrans relativement anciens, vous pouvez choisir ce paramètre. 

- **Écran large (ratio d'aspect 16:9)** 

  Si votre présentation doit être vue sur des projecteurs ou écrans modernes, vous pouvez choisir ce paramètre. 

Vous ne pouvez pas utiliser plusieurs paramètres de taille de diapositive dans une même présentation. Lorsque vous sélectionnez une taille de diapositive pour une présentation, ce paramètre s’applique à toutes les diapositives de la présentation. 

Si vous souhaitez utiliser une taille de diapositive spéciale pour vos présentations, nous vous recommandons fortement de le faire tôt. Idéalement, vous devez spécifier votre taille de diapositive préférée au début, c’est‑à‑dire lors de la création de la présentation—avant d’ajouter tout contenu. Ainsi, vous évitez les complications résultant de modifications (futures) de la taille des diapositives. 

{{% alert color="primary" %}} 

 Lorsque vous utilisez Aspose.Slides pour créer une présentation, toutes les diapositives de la présentation obtiennent automatiquement la taille standard ou le ratio d’aspect 4:3.

{{% /alert %}} 

## **Modifier la taille des diapositives dans les présentations**

 Ce fragment de code montre comment modifier la taille d’une diapositive dans une présentation en C++ avec Aspose.Slides:
``` cpp
auto pres = System::MakeObject<Presentation>(u"pres-4x3-aspect-ratio.pptx");
pres->get_SlideSize()->SetSize(SlideSizeType::OnScreen16x9, SlideSizeScaleType::DoNotScale);
pres->Save(u"pres-4x3-aspect-ratio.pptx", SaveFormat::Pptx);
```


## **Spécifier des tailles de diapositives personnalisées dans les présentations**

Si les tailles de diapositives courantes (4:3 et 16:9) ne conviennent pas à votre travail, vous pouvez décider d’utiliser une taille de diapositive spécifique ou unique. Par exemple, si vous prévoyez d’imprimer des diapositives en taille réelle à partir de votre présentation sur une mise en page de page personnalisée ou si vous avez l’intention d’afficher votre présentation sur certains types d’écrans, il est probable que vous bénéficiiez d’un réglage de taille personnalisée pour votre présentation. 

Ce fragment de code montre comment utiliser Aspose.Slides for C++ pour spécifier une taille de diapositive personnalisée pour une présentation en C++:
``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
// Taille du papier A4
pres->get_SlideSize()->SetSize(780.0f, 540.0f, SlideSizeScaleType::DoNotScale);
pres->Save(u"pres-a4-slide-size.pptx", SaveFormat::Pptx);
```


## **Gérer le contenu des diapositives après redimensionnement**

Après avoir modifié la taille des diapositives d’une présentation, le contenu des diapositives (images ou objets, par exemple) peut être déformé. Par défaut, les objets sont automatiquement redimensionnés pour s’adapter à la nouvelle taille de diapositive. Cependant, lors du changement de la taille des diapositives d’une présentation, vous pouvez spécifier un paramètre qui détermine comment Aspose.Slides gère le contenu des diapositives.

Selon ce que vous souhaitez faire ou obtenir, vous pouvez utiliser l’un de ces paramètres :

- `DoNotScale`

  Si vous NE voulez PAS que les objets sur les diapositives soient redimensionnés, utilisez ce paramètre.

- `EnsureFit`

  Si vous souhaitez réduire la taille des diapositives et que vous avez besoin qu’Aspose.Slides réduise les objets des diapositives pour qu’ils tiennent tous sur les diapositives (ainsi, vous évitez la perte de contenu), utilisez ce paramètre. 

- `Maximize`

  Si vous souhaitez augmenter la taille des diapositives et que vous avez besoin qu’Aspose.Slides agrandisse les objets des diapositives pour les rendre proportionnels à la nouvelle taille, utilisez ce paramètre. 

Ce fragment de code montre comment utiliser le paramètre `Maximize` lors du changement de la taille d’une diapositive de présentation:
``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->get_SlideSize()->SetSize(SlideSizeType::Ledger, SlideSizeScaleType::Maximize);
```


## **FAQ**

**Puis-je définir une taille de diapositive personnalisée en utilisant des unités autres que les pouces (par exemple, des points ou des millimètres) ?**

Oui. Aspose.Slides utilise des points en interne, où 1 point équivaut à 1/72 de pouce. Vous pouvez convertir n’importe quelle unité (comme les millimètres ou les centimètres) en points et utiliser les valeurs converties pour définir la largeur et la hauteur de la diapositive.

**Une taille de diapositive personnalisée très grande affectera-t-elle les performances et l’utilisation de la mémoire lors du rendu ?**

Oui. Des dimensions de diapositive plus grandes (en points) combinées à une échelle de rendu plus élevée entraînent une consommation de mémoire accrue et des temps de traitement plus longs. Visez une taille de diapositive pratique et ajustez l’échelle de rendu uniquement si nécessaire pour obtenir la qualité de sortie souhaitée.

**Puis-je définir une taille de diapositive non standard puis fusionner des diapositives provenant de présentations ayant des tailles différentes ?**

Vous ne pouvez pas [fusionner des présentations](/slides/fr/cpp/merge-presentation/) lorsqu’elles ont des tailles de diapositives différentes — redimensionnez d’abord une présentation pour qu’elle corresponde à l’autre. Lors du changement de taille des diapositives, vous pouvez choisir comment le contenu existant est traité via l’option [SlideSizeScaleType](https://reference.aspose.com/slides/cpp/aspose.slides/slidesizescaletype/). Après avoir aligné les tailles, vous pouvez fusionner les diapositives tout en conservant le formatage.

**Puis‑je générer des miniatures pour des formes individuelles ou des régions spécifiques d’une diapositive, et respecteront‑elles la nouvelle taille de diapositive ?**

Oui. Aspose.Slides peut rendre des miniatures pour [toutes les diapositives](https://reference.aspose.com/slides/cpp/aspose.slides/slide/getimage/) ainsi que pour [des formes sélectionnées](https://reference.aspose.com/slides/cpp/aspose.slides/shape/getimage/). Les images résultantes reflètent la taille et le ratio d’aspect actuels de la diapositive, garantissant un cadrage et une géométrie cohérents.