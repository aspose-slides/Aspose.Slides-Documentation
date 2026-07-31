---
title: Modifier la taille des diapositives de la présentation en C++
linktitle: Taille de diapositive
type: docs
weight: 70
url: /fr/cpp/slide-size/
keywords:
- taille de diapositive
- rapport d'aspect
- standard
- grand écran
- 4:3
- 16:9
- définir la taille de diapositive
- modifier la taille de diapositive
- taille de diapositive personnalisée
- taille de diapositive spéciale
- taille de diapositive unique
- diapositive pleine taille
- type d'écran
- ne pas mettre à l'échelle
- assurer l'ajustement
- maximiser
- PowerPoint
- OpenDocument
- présentation
- C++
- Aspose.Slides
description: "Apprenez à redimensionner rapidement les diapositives dans les fichiers PPT, PPTX et ODP avec C++ et Aspose.Slides, optimisez les présentations pour n'importe quel écran sans perte de qualité."
---
## **Introduction**

Aspose.Slides fournit des outils complets pour ajuster la taille des diapositives et le rapport d’aspect dans les présentations PowerPoint, essentiel tant pour l’impression que pour l’affichage à l’écran. 

Taille de diapositives courantes et rapports :

- **Standard (ratio 4 : 3)** : Idéal pour les écrans et appareils plus anciens.
- **Grand écran (ratio 16 : 9)** : Recommandé pour les projecteurs et affichages modernes.

Assurez la cohérence de votre présentation, car une même taille de diapositive et un même rapport d’aspect s’appliquent à toutes les diapositives. Pour de meilleurs résultats, définissez les dimensions de vos diapositives au début du processus de création de la présentation afin d’éviter des complications.

{{% alert color="primary" %}} 
Par défaut, les présentations créées avec Aspose.Slides utilisent le ratio standard 4 : 3.
{{% /alert %}}

## **Modifier la taille des diapositives dans les présentations**

Ce code d’exemple montre comment modifier la taille d’une diapositive dans une présentation en C++ à l’aide d’Aspose.Slides :

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres-4x3-aspect-ratio.pptx");
pres->get_SlideSize()->SetSize(SlideSizeType::OnScreen16x9, SlideSizeScaleType::DoNotScale);
pres->Save(u"pres-4x3-aspect-ratio.pptx", SaveFormat::Pptx);
```

## **Spécifier des tailles de diapositives personnalisées dans les présentations**

Si les tailles de diapositives courantes (4 : 3 et 16 : 9) ne conviennent pas à votre travail, vous pouvez décider d’utiliser une taille de diapositive spécifique ou unique. Par exemple, si vous prévoyez d’imprimer des diapositives en taille réelle à partir de votre présentation sur une mise en page de page personnalisée ou si vous envisagez d’afficher votre présentation sur certains types d’écrans, vous tirerez probablement profit de l’utilisation d’un réglage de taille personnalisée pour votre présentation. 

Ce code d’exemple montre comment utiliser Aspose.Slides pour C++ afin de spécifier une taille de diapositive personnalisée pour une présentation en C++ :

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
// Taille de papier A4
pres->get_SlideSize()->SetSize(780.0f, 540.0f, SlideSizeScaleType::DoNotScale);
pres->Save(u"pres-a4-slide-size.pptx", SaveFormat::Pptx);
```

## **Gérer le contenu des diapositives après redimensionnement**

Après avoir modifié la taille des diapositives d’une présentation, le contenu des diapositives (images ou objets, par exemple) peut se déformer. Par défaut, les objets sont automatiquement redimensionnés pour s’adapter à la nouvelle taille de diapositive. Cependant, lors du changement de la taille des diapositives d’une présentation, vous pouvez spécifier un réglage qui détermine comment Aspose.Slides gère le contenu des diapositives.

En fonction de ce que vous souhaitez faire ou obtenir, vous pouvez utiliser l’un de ces réglages :

- `DoNotScale`

  Si vous ne voulez PAS que les objets sur les diapositives soient redimensionnés, utilisez ce réglage.

- `EnsureFit`

  Si vous souhaitez réduire la taille des diapositives et que vous avez besoin qu’Aspose.Slides réduise les objets des diapositives afin qu’ils tiennent tous sur les diapositives (ainsi, vous évitez la perte de contenu), utilisez ce réglage. 

- `Maximize`

  Si vous souhaitez augmenter la taille des diapositives et que vous avez besoin qu’Aspose.Slides agrandisse les objets des diapositives pour les rendre proportionnels à la nouvelle taille, utilisez ce réglage. 

Ce code d’exemple montre comment utiliser le réglage `Maximize` lors du changement de la taille des diapositives d’une présentation :

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->get_SlideSize()->SetSize(SlideSizeType::Ledger, SlideSizeScaleType::Maximize);
```

## **FAQ**

**Puis-je définir une taille de diapositive personnalisée en utilisant des unités autres que les pouces (par exemple, les points ou les millimètres) ?**

Oui. Aspose.Slides utilise des points en interne, où 1 point équivaut à 1/72 de pouce. Vous pouvez convertir n’importe quelle unité (telle que les millimètres ou les centimètres) en points et utiliser les valeurs converties pour définir la largeur et la hauteur de la diapositive.

**Une taille de diapositive personnalisée très grande affectera-t-elle les performances et l’utilisation de la mémoire lors du rendu ?**

Oui. Des dimensions de diapositive plus grandes (en points) combinées à une échelle de rendu plus élevée entraînent une consommation de mémoire accrue et des temps de traitement plus longs. Visez une taille de diapositive pratique et ajustez l’échelle de rendu uniquement si nécessaire pour obtenir la qualité de sortie souhaitée.

**Puis-je définir une taille de diapositive non standard puis fusionner des diapositives provenant de présentations ayant des tailles différentes ?**

Vous ne pouvez pas [fusionner des présentations](/slides/fr/cpp/merge-presentation/) lorsqu’elles ont des tailles de diapositives différentes — redimensionnez d’abord une présentation pour correspondre à l’autre. Lors du changement de la taille des diapositives, vous pouvez choisir comment le contenu existant est traité via l’option [SlideSizeScaleType](https://reference.aspose.com/slides/fr/cpp/aspose.slides/slidesizescaletype/). Après avoir aligné les tailles, vous pouvez fusionner les diapositives tout en conservant la mise en forme.

**Puis-je générer des miniatures pour des formes individuelles ou des zones spécifiques d’une diapositive, et respecteront-elles la nouvelle taille de diapositive ?**

Oui. Aspose.Slides peut rendre des miniatures pour des [diapositives entières](https://reference.aspose.com/slides/fr/cpp/aspose.slides/slide/getimage/) ainsi que pour des [formes sélectionnées](https://reference.aspose.com/slides/fr/cpp/aspose.slides/shape/getimage/). Les images résultantes reflètent la taille de diapositive et le rapport d’aspect actuels, assurant un cadrage et une géométrie cohérents.