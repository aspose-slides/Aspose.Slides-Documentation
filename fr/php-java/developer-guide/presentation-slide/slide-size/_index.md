---
title: Modifier la taille des diapositives de la présentation en PHP
linktitle: Taille de diapositive
type: docs
weight: 70
url: /fr/php-java/slide-size/
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
- diapositive plein format
- type d'écran
- ne pas mettre à l'échelle
- ajuster pour faire tenir
- maximiser
- PowerPoint
- OpenDocument
- présentation
- PHP
- Aspose.Slides
description: "Apprenez comment redimensionner rapidement les diapositives dans les fichiers PPT, PPTX et ODP avec PHP et Aspose.Slides, optimisez les présentations pour n'importe quel écran sans perdre en qualité."
---
## **Introduction**

Aspose.Slides propose des outils complets pour ajuster la taille et le rapport d’aspect des diapositives dans les présentations PowerPoint, essentiels tant pour l’impression que pour l’affichage à l’écran.

Tailles de diapositives populaires et rapports :

- **Standard (rapport d’aspect 4:3)** : Idéal pour les anciens écrans et appareils.  
- **Grand écran (rapport d’aspect 16:9)** : Recommandé pour les projecteurs et écrans modernes.

Assurez la cohérence de toute votre présentation en appliquant une seule taille et un seul rapport d’aspect à toutes les diapositives. Pour obtenir les meilleurs résultats, définissez les dimensions de vos diapositives au début du processus de création afin d’éviter les complications.

{{% alert color="info" title="Note" %}}
Par défaut, les présentations créées avec Aspose.Slides utilisent le rapport d’aspect standard 4:3.
{{% /alert %}}

Les notes et les pages de support ont des dimensions séparées des diapositives normales. Consultez [Notes Page Size](/slides/fr/php-java/notes-size/) pour modifier leur taille et leur orientation.

## **Change the Slide Size in Presentations**

Ce code d’exemple montre comment modifier la taille d’une diapositive dans une présentation à l’aide d’Aspose.Slides :

```php
  $pres = new Presentation("pres-4x3-aspect-ratio.pptx");
  try {
    $pres->getSlideSize()->setSize(SlideSizeType::OnScreen16x9, SlideSizeScaleType::DoNotScale);
    $pres->save("pres-4x3-aspect-ratio.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Specify Custom Slide Sizes in Presentations**

Si les tailles de diapositives courantes (4:3 et 16:9) ne conviennent pas à votre travail, vous pouvez choisir une taille de diapositive spécifique ou unique. Par exemple, si vous prévoyez d’imprimer des diapositives en plein format sur une mise en page personnalisée ou si vous devez afficher votre présentation sur certains types d’écrans, l’utilisation d’une taille personnalisée vous sera bénéfique.

Ce code d’exemple montre comment utiliser Aspose.Slides for PHP via Java pour définir une taille de diapositive personnalisée pour une présentation :

```php
  $pres = new Presentation("pres.pptx");
  try {
    $pres->getSlideSize()->setSize(780, 540, SlideSizeScaleType::DoNotScale);// format papier A4

    $pres->save("pres-a4-slide-size.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Handle Slide Content After Resizing**

Après avoir modifié la taille d’une diapositive, le contenu des diapositives (images ou objets, par exemple) peut être déformé. Par défaut, les objets sont automatiquement redimensionnés pour s’adapter à la nouvelle taille. Cependant, lors du changement de taille, vous pouvez spécifier un paramètre qui détermine la façon dont Aspose.Slides gère le contenu des diapositives.

Selon ce que vous souhaitez faire ou obtenir, vous pouvez utiliser l’un de ces paramètres :

- `DoNotScale`  

  Si vous NE voulez PAS que les objets sur les diapositives soient redimensionnés, utilisez ce paramètre.

- `EnsureFit`  

  Si vous devez réduire la taille de la diapositive et que vous souhaitez qu’Aspose.Slides réduise les objets pour qu’ils tiennent tous sur la diapositive (afin d’éviter la perte de contenu), utilisez ce paramètre.

- `Maximize`  

  Si vous augmentez la taille de la diapositive et que vous souhaitez qu’Aspose.Slides agrandisse les objets pour les rendre proportionnels à la nouvelle taille, utilisez ce paramètre.

Ce code d’exemple montre comment utiliser le paramètre `Maximize` lors du changement de taille d’une diapositive de présentation :

```php
  $pres = new Presentation("pres.pptx");
  try {
    $pres->getSlideSize()->setSize(SlideSizeType::Ledger, SlideSizeScaleType::Maximize);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Puis-je définir une taille de diapositive personnalisée en utilisant des unités autres que les pouces (par exemple, points ou millimètres) ?**

Oui. Aspose.Slides utilise les points en interne, où 1 point vaut 1/72 de pouce. Vous pouvez convertir n’importe quelle unité (comme les millimètres ou les centimètres) en points et utiliser les valeurs converties pour définir la largeur et la hauteur de la diapositive.

**Une taille de diapositive personnalisée très grande affectera-t-elle les performances et la consommation de mémoire lors du rendu ?**

Oui. Des dimensions de diapositive plus importantes (en points) combinées à une échelle de rendu élevée entraînent une consommation mémoire accrue et des temps de traitement plus longs. Visez une taille de diapositive pratique et ajustez l’échelle de rendu uniquement si nécessaire pour obtenir la qualité souhaitée.

**Puis-je définir une seule taille de diapositive non standard puis fusionner des diapositives provenant de présentations aux tailles différentes ?**

Vous ne pouvez pas [merge presentations](/slides/fr/php-java/merge-presentation/) tant qu’elles ont des tailles différentes — il faut d’abord redimensionner une présentation pour qu’elle corresponde à l’autre. Lors du changement de taille, vous pouvez choisir comment le contenu existant est géré via l’option [SlideSizeScaleType](https://reference.aspose.com/slides/fr/php-java/aspose.slides/slidesizescaletype/). Après avoir aligné les tailles, vous pouvez fusionner les diapositives tout en préservant le formatage.

**Puis-je générer des miniatures pour des formes individuelles ou des zones spécifiques d’une diapositive, et ces miniatures respecteront-elles la nouvelle taille de diapositive ?**

Oui. Aspose.Slides peut rendre des miniatures pour [entire slides](https://reference.aspose.com/slides/fr/php-java/aspose.slides/slide/#getImage) ainsi que pour [selected shapes](https://reference.aspose.com/slides/fr/php-java/aspose.slides/shape/#getImage). Les images résultantes reflètent la taille et le rapport d’aspect actuels de la diapositive, assurant un cadrage et une géométrie cohérents.