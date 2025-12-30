---
title: Modifier la taille des diapositives de la présentation en PHP
linktitle: Taille des diapositives
type: docs
weight: 70
url: /fr/php-java/slide-size/
keywords:
- taille de diapositive
- ratio d'aspect
- standard
- écran large
- 4:3
- 16:9
- définir la taille de diapositive
- modifier la taille de diapositive
- taille de diapositive personnalisée
- taille de diapositive spéciale
- taille de diapositive unique
- diapositive pleine taille
- type d'écran
- ne pas redimensionner
- adapter
- maximiser
- PowerPoint
- OpenDocument
- présentation
- PHP
- Aspose.Slides
descriptions: "Apprenez comment redimensionner rapidement les diapositives dans les fichiers PPT, PPTX et ODP avec PHP et Aspose.Slides, optimisez les présentations pour n'importe quel écran sans perdre en qualité."
---

## **Tailles de diapositives dans les présentations PowerPoint**

Aspose.Slides for PHP via Java vous permet de modifier la taille ou le rapport d'aspect des diapositives dans les présentations PowerPoint. Si vous prévoyez d'imprimer votre présentation ou d'afficher ses diapositives sur un écran, vous devez faire attention à la taille ou au rapport d'aspect des diapositives.

Voici les tailles de diapositives et rapports d'aspect les plus courants :

- **Standard (ratio d'aspect 4:3)**

  Si votre présentation doit être affichée ou visualisée sur des appareils ou écrans relativement anciens, vous pouvez souhaiter utiliser ce réglage. 

- **Écran large (ratio d'aspect 16:9)** 

  Si votre présentation doit être vue sur des projecteurs ou écrans modernes, vous pouvez souhaiter utiliser ce réglage. 

Vous ne pouvez pas utiliser plusieurs réglages de taille de diapositive dans une même présentation. Lorsque vous sélectionnez une taille de diapositive pour une présentation, ce réglage de taille s'applique à toutes les diapositives de la présentation. 

Si vous préférez utiliser une taille de diapositive spéciale pour vos présentations, nous vous recommandons fortement de le faire tôt. Idéalement, vous devriez spécifier votre taille de diapositive préférée dès le début, c'est‑à‑dire lors de la création de la présentation—avant d'ajouter tout contenu à la présentation. Ainsi, vous évitez les complications résultant de modifications (futures) de la taille des diapositives. 

{{% alert color="primary" %}} 

Lorsque vous utilisez Aspose.Slides pour créer une présentation, toutes les diapositives de la présentation obtiennent automatiquement la taille standard ou le ratio d'aspect 4:3.

{{% /alert %}} 

## **Modifier la taille de la diapositive dans les présentations**

Ce code d'exemple vous montre comment modifier la taille de la diapositive dans une présentation en utilisant Aspose.Slides :
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


## **Spécifier des tailles de diapositives personnalisées dans les présentations**

Si vous trouvez que les tailles de diapositives courantes (4:3 et 16:9) ne conviennent pas à votre travail, vous pouvez décider d'utiliser une taille de diapositive spécifique ou unique. Par exemple, si vous prévoyez d'imprimer des diapositives pleine taille de votre présentation sur une mise en page personnalisée ou si vous envisagez d'afficher votre présentation sur certains types d'écrans, il est probable que vous bénéficiiez d'un réglage de taille personnalisé pour votre présentation. 

Ce code d'exemple vous montre comment utiliser Aspose.Slides for PHP via Java pour spécifier une taille de diapositive personnalisée pour une présentation :
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


## **Gérer le contenu des diapositives après redimensionnement**

Après avoir modifié la taille de la diapositive d'une présentation, le contenu des diapositives (images ou objets, par exemple) peut se déformer. Par défaut, les objets sont automatiquement redimensionnés pour s'adapter à la nouvelle taille de diapositive. Cependant, lors du changement de la taille de la diapositive d'une présentation, vous pouvez spécifier un réglage qui détermine comment Aspose.Slides gère le contenu des diapositives.

Selon ce que vous souhaitez faire ou atteindre, vous pouvez utiliser l'un de ces réglages :

- `DoNotScale`

  Si vous NE voulez PAS que les objets sur les diapositives soient redimensionnés, utilisez ce réglage.

- `EnsureFit`

  Si vous voulez réduire à une taille de diapositive plus petite et que vous avez besoin qu'Aspose.Slides réduise les objets des diapositives pour garantir qu'ils tiennent tous sur les diapositives (ainsi, vous évitez de perdre du contenu), utilisez ce réglage. 

- `Maximize`

  Si vous voulez agrandir à une taille de diapositive plus grande et que vous avez besoin qu'Aspose.Slides agrandisse les objets des diapositives pour les rendre proportionnels à la nouvelle taille de diapositive, utilisez ce réglage. 

Ce code d'exemple vous montre comment utiliser le réglage `Maximize` lors du changement de la taille de la diapositive d'une présentation :
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

Oui. Aspose.Slides utilise des points en interne, où 1 point équivaut à 1/72 de pouce. Vous pouvez convertir n'importe quelle unité (comme les millimètres ou centimètres) en points et utiliser les valeurs converties pour définir la largeur et la hauteur de la diapositive.

**Une taille de diapositive personnalisée très grande affectera-t-elle les performances et l'utilisation de la mémoire lors du rendu ?**

Oui. Des dimensions de diapositive plus grandes (en points) combinées à une échelle de rendu plus élevée entraînent une consommation de mémoire accrue et des temps de traitement plus longs. Visez une taille de diapositive pratique et ajustez l'échelle de rendu uniquement si nécessaire pour obtenir la qualité de sortie souhaitée.

**Puis-je définir une taille de diapositive non standard puis fusionner des diapositives provenant de présentations de tailles différentes ?**

Vous ne pouvez pas [fusionner des présentations](/slides/fr/php-java/merge-presentation/) lorsqu'elles ont des tailles de diapositive différentes — commencez par redimensionner une présentation pour qu'elle corresponde à l'autre. Lors du changement de la taille de la diapositive, vous pouvez choisir comment le contenu existant est traité via l'option [SlideSizeScaleType](https://reference.aspose.com/slides/php-java/aspose.slides/slidesizescaletype/). Après avoir aligné les tailles, vous pouvez fusionner les diapositives tout en conservant le formatage.

**Puis-je générer des miniatures pour des formes individuelles ou des régions spécifiques d’une diapositive, et respecteront‑elles la nouvelle taille de diapositive ?**

Oui. Aspose.Slides peut créer des miniatures pour [toutes les diapositives](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getImage) ainsi que pour [des formes sélectionnées](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getImage). Les images résultantes reflètent la taille et le ratio d'aspect actuels de la diapositive, garantissant un cadrage et une géométrie cohérents.