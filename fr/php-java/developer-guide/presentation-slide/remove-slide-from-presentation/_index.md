---
title: Supprimer une diapositive de la présentation
type: docs
weight: 30
url: /fr/php-java/remove-slide-from-presentation/
keywords: "Supprimer diapositive, Effacer diapositive, PowerPoint, Présentation, Java, Aspose.Slides"
description: "Supprimer une diapositive de PowerPoint par référence ou index"

---

Si une diapositive (ou son contenu) devient redondante, vous pouvez la supprimer. Aspose.Slides fournit la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) qui encapsule [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/islidecollection/), qui est un dépôt pour toutes les diapositives d'une présentation. En utilisant des pointeurs (référence ou index) pour un objet [ISlide](https://reference.aspose.com/slides/php-java/aspose.slides/islide/) connu, vous pouvez spécifier la diapositive que vous souhaitez supprimer.

## **Supprimer une diapositive par référence**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. Obtenez une référence de la diapositive que vous souhaitez supprimer via son ID ou son index.
1. Supprimez la diapositive référencée de la présentation.
1. Enregistrez la présentation modifiée.

Ce code PHP vous montre comment supprimer une diapositive par référence :

```php
  # Instancie un objet Presentation qui représente un fichier de présentation
  $pres = new Presentation("demo.pptx");
  try {
    # Accède à une diapositive par son index dans la collection de diapositives
    $slide = $pres->getSlides()->get_Item(0);
    # Supprime une diapositive par sa référence
    $pres->getSlides()->remove($slide);
    # Enregistre la présentation modifiée
    $pres->save("modified.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```


## **Supprimer une diapositive par index**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. Supprimez la diapositive de la présentation via sa position d'index.
1. Enregistrez la présentation modifiée.

Ce code PHP vous montre comment supprimer une diapositive par son index :

```php
  # Instancie un objet Presentation qui représente un fichier de présentation
  $pres = new Presentation("demo.pptx");
  try {
    # Supprime une diapositive par son index de diapositive
    $pres->getSlides()->removeAt(0);
    # Enregistre la présentation modifiée
    $pres->save("modified.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **Supprimer une diapositive de mise en page inutilisée**

Aspose.Slides fournit la méthode [removeUnusedLayoutSlides](https://reference.aspose.com/slides/php-java/aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) (de la classe [Compress](https://reference.aspose.com/slides/php-java/aspose.slides/compress/)) pour vous permettre de supprimer les diapositives de mise en page inutiles et non désirées. Ce code PHP vous montre comment supprimer une diapositive de mise en page d'une présentation PowerPoint :

```php
  $pres = new Presentation("pres.pptx");
  try {
    Compress->removeUnusedLayoutSlides($pres);
    $pres->save("pres-out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Supprimer une diapositive maître inutilisée**

Aspose.Slides fournit la méthode [removeUnusedMasterSlides](https://reference.aspose.com/slides/php-java/aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) (de la classe [Compress](https://reference.aspose.com/slides/php-java/aspose.slides/compress/)) pour vous permettre de supprimer les diapositives maîtresses non désirées et inutilisées. Ce code PHP vous montre comment supprimer une diapositive maîtresse d'une présentation PowerPoint :

```php
  $pres = new Presentation("pres.pptx");
  try {
    Compress->removeUnusedMasterSlides($pres);
    $pres->save("pres-out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```