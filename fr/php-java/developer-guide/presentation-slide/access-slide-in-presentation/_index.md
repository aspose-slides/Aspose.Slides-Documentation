---
title: Accéder aux diapositives de présentation en PHP
linktitle: Accéder à la diapositive
type: docs
weight: 20
url: /fr/php-java/access-slide-in-presentation/
keywords:
- accéder à la diapositive
- indice de diapositive
- identifiant de diapositive
- position de diapositive
- changer la position
- propriétés de diapositive
- numéro de diapositive
- PowerPoint
- OpenDocument
- présentation
- PHP
- Aspose.Slides
description: "Apprenez à accéder et gérer les diapositives dans les présentations PowerPoint et OpenDocument avec Aspose.Slides pour PHP via Java. Augmentez la productivité avec des exemples de code."
---

Aspose.Slides vous permet d'accéder aux diapositives de deux manières : par indice et par ID.

## **Accéder à une diapositive par indice**

Toutes les diapositives d’une présentation sont ordonnées numériquement en fonction de la position de la diapositive à partir de 0. La première diapositive est accessible via l’indice 0 ; la deuxième diapositive via l’indice 1 ; etc.

La classe Presentation, représentant un fichier de présentation, expose toutes les diapositives sous forme d’une collection [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/islidecollection/) (collection d’objets [ISlide](https://reference.aspose.com/slides/php-java/aspose.slides/islide/)). Ce code PHP montre comment accéder à une diapositive via son indice :
```php
  # Instancie un objet Presentation qui représente un fichier de présentation
  $pres = new Presentation("demo.pptx");
  try {
    # Accède à une diapositive en utilisant son indice de diapositive
    $slide = $pres->getSlides()->get_Item(0);
  } finally {
    $pres->dispose();
  }
```


## **Accéder à une diapositive par ID**

Chaque diapositive d’une présentation possède un ID unique. Vous pouvez utiliser la méthode [getSlideById](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getSlideById-long-) (exposée par la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)) pour cibler cet ID. Ce code PHP montre comment fournir un ID de diapositive valide et accéder à cette diapositive via la méthode [getSlideById](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getSlideById-long-) :
```php
  # Instancie un objet Presentation qui représente un fichier de présentation
  $pres = new Presentation("demo.pptx");
  try {
    # Obtient un ID de diapositive
    $id = $pres->getSlides()->get_Item(0)->getSlideId();
    # Accède à la diapositive via son ID
    $slide = $pres->getSlideById($id);
  } finally {
    $pres->dispose();
  }
```


## **Modifier la position d’une diapositive**

Aspose.Slides vous permet de modifier la position d’une diapositive. Par exemple, vous pouvez spécifier que la première diapositive doit devenir la deuxième.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Obtenez la référence de la diapositive (dont vous voulez changer la position) via son indice.
3. Définissez une nouvelle position pour la diapositive via la propriété [setSlideNumber](https://reference.aspose.com/slides/php-java/aspose.slides/islide/#setSlideNumber-int-).
4. Enregistrez la présentation modifiée.

Ce code PHP montre une opération où la diapositive en position 1 est déplacée en position 2 :
```php
  # Instancie un objet Presentation qui représente un fichier de présentation
  $pres = new Presentation("Presentation.pptx");
  try {
    # Obtient la diapositive dont la position sera modifiée
    $sld = $pres->getSlides()->get_Item(0);
    # Définit la nouvelle position pour la diapositive
    $sld->setSlideNumber(2);
    # Enregistre la présentation modifiée
    $pres->save("helloworld_Pos.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```


La première diapositive est devenue la deuxième ; la deuxième diapositive est devenue la première. Lorsque vous modifiez la position d’une diapositive, les autres diapositives sont ajustées automatiquement.


## **Définir le numéro de la diapositive**

En utilisant la propriété [setFirstSlideNumber](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#setFirstSlideNumber-int-) (exposée par la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)), vous pouvez spécifier un nouveau numéro pour la première diapositive d’une présentation. Cette opération entraîne le recalcul des numéros des autres diapositives.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Obtenez le numéro de la diapositive.
3. Définissez le numéro de la diapositive.
4. Enregistrez la présentation modifiée.

Ce code PHP montre une opération où le numéro de la première diapositive est fixé à 10 :
```php
  # Instancie un objet Presentation qui représente un fichier de présentation
  $pres = new Presentation("HelloWorld.pptx");
  try {
    # Obtient le numéro de la diapositive
    $firstSlideNumber = $pres->getFirstSlideNumber();
    # Définit le numéro de la diapositive
    $pres->setFirstSlideNumber(10);
    # Enregistre la présentation modifiée
    $pres->save("Set_Slide_Number_out.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```


Si vous préférez ignorer la première diapositive, vous pouvez commencer la numérotation à partir de la deuxième diapositive (et masquer la numérotation pour la première) de cette façon :
```php
  $presentation = new Presentation();
  try {
    $layoutSlide = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);
    $presentation->getSlides()->addEmptySlide($layoutSlide);
    $presentation->getSlides()->addEmptySlide($layoutSlide);
    $presentation->getSlides()->addEmptySlide($layoutSlide);
    # Définit le numéro de la première diapositive de la présentation
    $presentation->setFirstSlideNumber(0);
    # Affiche les numéros de diapositive pour toutes les diapositives
    $presentation->getHeaderFooterManager()->setAllSlideNumbersVisibility(true);
    # Masque le numéro de diapositive pour la première diapositive
    $presentation->getSlides()->get_Item(0)->getHeaderFooterManager()->setSlideNumberVisibility(false);
    # Enregistre la présentation modifiée
    $presentation->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```


## **FAQ**

**Le numéro de diapositive affiché à l’utilisateur correspond‑il à l’indice zéro‑based de la collection ?**

Le numéro affiché sur une diapositive peut commencer à une valeur arbitraire (par ex., 10) et n’a pas besoin de correspondre à l’indice ; la relation est contrôlée par le paramètre [first slide number](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/setfirstslidenumber/) de la présentation.

**Les diapositives masquées affectent‑elles l’indexation ?**

Oui. Une diapositive masquée reste dans la collection et est comptée dans l’indexation ; « hidden » fait référence à l’affichage, pas à sa position dans la collection.

**L’indice d’une diapositive change‑t‑il lorsque d’autres diapositives sont ajoutées ou supprimées ?**

Oui. Les indices reflètent toujours l’ordre actuel des diapositives et sont recalculés lors des opérations d’insertion, de suppression et de déplacement.