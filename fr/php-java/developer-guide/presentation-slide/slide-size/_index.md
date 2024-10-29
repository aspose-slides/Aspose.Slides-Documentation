---
title: Taille des diapositives
type: docs
weight: 70
url: /fr/php-java/slide-size/

---

## Tailles des diapositives dans les présentations PowerPoint

Aspose.Slides pour PHP via Java vous permet de changer la taille ou le rapport d'aspect des diapositives dans les présentations PowerPoint. Si vous prévoyez d'imprimer votre présentation ou d'afficher ses diapositives sur un écran, vous devez faire attention à sa taille de diapositive ou à son rapport d'aspect.

Voici les tailles de diapositives et les rapports d'aspect les plus courants :

- **Standard (rapport d'aspect 4:3)**

  Si votre présentation doit être affichée ou vue sur des appareils ou des écrans relativement anciens, vous voudrez peut-être utiliser ce paramètre.

- **Widescreen (rapport d'aspect 16:9)** 

  Si votre présentation doit être vue sur des projecteurs ou des écrans modernes, vous voudrez peut-être utiliser ce paramètre.

Vous ne pouvez pas utiliser plusieurs paramètres de taille de diapositive dans une seule présentation. Lorsque vous sélectionnez une taille de diapositive pour une présentation, ce paramètre de taille de diapositive s'applique à toutes les diapositives de la présentation.

Si vous préférez utiliser une taille de diapositive spéciale pour vos présentations, nous vous recommandons fortement de le faire tôt. Idéalement, vous devriez spécifier votre taille de diapositive préférée dès le début, c'est-à-dire lorsque vous êtes en train de configurer la présentation—avant d'ajouter du contenu à la présentation. De cette manière, vous évitez les complications résultant de changements (futurs) apportés à la taille des diapositives.

{{% alert color="primary" %}} 

Lorsque vous utilisez Aspose.Slides pour créer une présentation, toutes les diapositives de la présentation obtiennent automatiquement la taille standard ou le rapport d'aspect 4:3.

{{% /alert %}} 

## Changer la taille des diapositives dans les présentations 

Ce code d'exemple vous montre comment changer la taille des diapositives dans une présentation en utilisant Aspose.Slides :

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

## Spécifier des tailles de diapositives personnalisées dans les présentations

Si vous trouvez que les tailles de diapositives courantes (4:3 et 16:9) ne conviennent pas à votre travail, vous pouvez décider d'utiliser une taille de diapositive spécifique ou unique. Par exemple, si vous prévoyez d'imprimer des diapositives pleine taille de votre présentation sur une mise en page de page personnalisée ou si vous avez l'intention d'afficher votre présentation sur certains types d'écrans, vous êtes susceptible de bénéficier de l'utilisation d'un paramètre de taille personnalisé pour votre présentation.

Ce code d'exemple vous montre comment utiliser Aspose.Slides pour PHP via Java pour spécifier une taille de diapositive personnalisée pour une présentation :

```php
  $pres = new Presentation("pres.pptx");
  try {
    $pres->getSlideSize()->setSize(780, 540, SlideSizeScaleType::DoNotScale);// Taille de papier A4

    $pres->save("pres-a4-slide-size.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## Gérer les problèmes lors du changement de taille des diapositives dans les présentations

Après avoir changé la taille des diapositives pour une présentation, le contenu des diapositives (images ou objets, par exemple) peut se déformer. Par défaut, les objets sont automatiquement redimensionnés pour s'adapter à la nouvelle taille de diapositive. Cependant, lors du changement de la taille des diapositives d'une présentation, vous pouvez spécifier un paramètre qui détermine comment Aspose.Slides gère le contenu sur les diapositives.

Selon ce que vous avez l'intention de faire ou d'accomplir, vous pouvez utiliser l'un de ces paramètres :

- `DoNotScale`

  Si vous NE souhaitez PAS que les objets sur les diapositives soient redimensionnés, utilisez ce paramètre.

- `EnsureFit`

  Si vous souhaitez réduire la taille des diapositives à une taille plus petite et que vous avez besoin qu'Aspose.Slides réduise les objets des diapositives pour s'assurer qu'ils s'adaptent tous sur les diapositives (de cette manière, vous évitez de perdre du contenu), utilisez ce paramètre.

- `Maximize`

  Si vous souhaitez agrandir à une taille de diapositive plus grande et que vous avez besoin qu'Aspose.Slides agrandisse les objets des diapositives pour les rendre proportionnels à la nouvelle taille de diapositive, utilisez ce paramètre.

Ce code d'exemple vous montre comment utiliser le paramètre `Maximize` lors du changement de la taille des diapositives d'une présentation :

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