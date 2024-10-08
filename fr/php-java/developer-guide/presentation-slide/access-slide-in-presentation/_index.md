---
title: Accéder à une diapositive dans la présentation
type: docs
weight: 20
url: /fr/php-java/access-slide-in-presentation/
keywords: "Accéder à la présentation PowerPoint, Accéder à la diapositive, Modifier les propriétés de la diapositive, Changer la position de la diapositive, Définir le numéro de diapositive, index, ID, position Java, Aspose.Slides"
description: "Accéder à la diapositive PowerPoint par index, ID, ou position. Modifier les propriétés de la diapositive."
---

Aspose.Slides vous permet d'accéder aux diapositives de deux manières : par index et par ID.

## **Accéder à la diapositive par index**

Toutes les diapositives d'une présentation sont disposées numériquement en fonction de la position de la diapositive commençant par 0. La première diapositive est accessible par l'index 0 ; la deuxième diapositive est accessible par l'index 1 ; etc.

La classe Presentation, représentant un fichier de présentation, expose toutes les diapositives en tant que collection [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/islidecollection/) (collection d'objets [ISlide](https://reference.aspose.com/slides/php-java/aspose.slides/islide/)). Ce code PHP vous montre comment accéder à une diapositive par son index :

```php
  # Instancie un objet Presentation qui représente un fichier de présentation
  $pres = new Presentation("demo.pptx");
  try {
    # Accède à une diapositive en utilisant son index de diapositive
    $slide = $pres->getSlides()->get_Item(0);
  } finally {
    $pres->dispose();
  }
```

## **Accéder à la diapositive par ID**

Chaque diapositive d'une présentation a un ID unique qui lui est associé. Vous pouvez utiliser la méthode [getSlideById](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getSlideById-long-) (exposée par la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)) pour cibler cet ID. Ce code PHP vous montre comment fournir un ID de diapositive valide et accéder à cette diapositive via la méthode [getSlideById](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getSlideById-long-) :

```php
  # Instancie un objet Presentation qui représente un fichier de présentation
  $pres = new Presentation("demo.pptx");
  try {
    # Obtient un ID de diapositive
    $id = $pres->getSlides()->get_Item(0)->getSlideId();
    # Accède à la diapositive par son ID
    $slide = $pres->getSlideById($id);
  } finally {
    $pres->dispose();
  }
```

## **Changer la position de la diapositive**

Aspose.Slides vous permet de changer la position d'une diapositive. Par exemple, vous pouvez spécifier que la première diapositive doit devenir la deuxième diapositive.

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. Obtenir la référence de la diapositive (dont vous souhaitez changer la position) par son index.
1. Définir une nouvelle position pour la diapositive via la propriété [setSlideNumber](https://reference.aspose.com/slides/php-java/aspose.slides/islide/#setSlideNumber-int-).
1. Enregistrer la présentation modifiée.

Ce code PHP démontre une opération dans laquelle la diapositive en position 1 est déplacée à la position 2 :

```php
  # Instancie un objet Presentation qui représente un fichier de présentation
  $pres = new Presentation("Presentation.pptx");
  try {
    # Obtient la diapositive dont la position va être changée
    $sld = $pres->getSlides()->get_Item(0);
    # Définit la nouvelle position pour la diapositive
    $sld->setSlideNumber(2);
    # Enregistre la présentation modifiée
    $pres->save("helloworld_Pos.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

La première diapositive est devenue la deuxième ; la deuxième diapositive est devenue la première. Lorsque vous changez la position d'une diapositive, les autres diapositives sont automatiquement ajustées.

## **Définir le numéro de diapositive**

En utilisant la propriété [setFirstSlideNumber](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#setFirstSlideNumber-int-) (exposée par la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)), vous pouvez spécifier un nouveau numéro pour la première diapositive d'une présentation. Cette opération entraîne le recalcul des autres numéros de diapositive.

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. Obtenir le numéro de diapositive.
1. Définir le numéro de diapositive.
1. Enregistrer la présentation modifiée.

Ce code PHP démontre une opération où le numéro de la première diapositive est défini sur 10 :

```php
  # Instancie un objet Presentation qui représente un fichier de présentation
  $pres = new Presentation("HelloWorld.pptx");
  try {
    # Obtient le numéro de la première diapositive
    $firstSlideNumber = $pres->getFirstSlideNumber();
    # Définit le numéro de la diapositive
    $pres->setFirstSlideNumber(10);
    # Enregistre la présentation modifiée
    $pres->save("Set_Slide_Number_out.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

Si vous préférez ignorer la première diapositive, vous pouvez commencer la numérotation à partir de la deuxième diapositive (et masquer la numérotation pour la première diapositive) de cette manière :

```php
  $presentation = new Presentation();
  try {
    $layoutSlide = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);
    $presentation->getSlides()->addEmptySlide($layoutSlide);
    $presentation->getSlides()->addEmptySlide($layoutSlide);
    $presentation->getSlides()->addEmptySlide($layoutSlide);
    # Définit le numéro pour la première diapositive de présentation
    $presentation->setFirstSlideNumber(0);
    # Montre les numéros de diapositive pour toutes les diapositives
    $presentation->getHeaderFooterManager()->setAllSlideNumbersVisibility(true);
    # Cache le numéro de la première diapositive
    $presentation->getSlides()->get_Item(0)->getHeaderFooterManager()->setSlideNumberVisibility(false);
    # Enregistre la présentation modifiée
    $presentation->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```