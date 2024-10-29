---
title: Mise en page de diapositive
type: docs
weight: 60
url: /fr/php-java/slide-layout/
keyword: "Définir la taille de la diapositive, définir les options de diapositive, spécifier la taille de la diapositive, visibilité du pied de page, pied de page enfant, mise à l'échelle du contenu, taille de page, Java, Aspose.Slides"
description: "Définir la taille et les options des diapositives PowerPoint "
---

Une mise en page de diapositive contient les zones de texte de remplacement et les informations de formatage pour tout le contenu qui apparaît sur une diapositive. La mise en page détermine les espaces réservés au contenu disponibles et leur emplacement. 

Les mises en page de diapositives vous permettent de créer et de concevoir des présentations rapidement (qu'elles soient simples ou complexes). Voici quelques-unes des mises en page de diapositives les plus populaires utilisées dans les présentations PowerPoint : 

* **Mise en page de diapositive de titre**. Cette mise en page se compose de deux espaces réservés pour le texte. Un espace réservé est pour le titre et l'autre est pour le sous-titre. 
* **Mise en page de titre et contenu**. Cette mise en page contient un espace réservé relativement petit en haut pour le titre et un plus grand espace réservé pour le contenu principal (graphique, paragraphes, liste à puces, liste numérotée, images, etc).
* **Mise en page vierge**. Cette mise en page ne contient pas d'espaces réservés, vous permettant ainsi de créer des éléments à partir de zéro. 

Étant donné qu'un maître de diapositive est la diapositive hiérarchique supérieure qui stocke des informations sur les mises en page de diapositives, vous pouvez utiliser la diapositive maître pour accéder aux mises en page de diapositives et y apporter des modifications. Une diapositive de mise en page peut être accessible par type ou par nom. De même, chaque diapositive a un identifiant unique qui peut être utilisé pour y accéder. 

Alternativement, vous pouvez apporter des modifications directement à une mise en page de diapositive spécifique dans une présentation. 

* Pour vous permettre de travailler avec des mises en page de diapositives (y compris celles dans les diapositives maîtres), Aspose.Slides fournit des propriétés comme [getLayoutSlides()](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getLayoutSlides--) et [getMasters()](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getMasters--) sous la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
* Pour effectuer des tâches connexes, Aspose.Slides fournit [MasterSlide](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/), [MasterLayoutSlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/masterlayoutslidecollection/), [SlideSize](https://reference.aspose.com/slides/php-java/aspose.slides/slidesize/), [BaseSlideHeaderFooterManager](https://reference.aspose.com/slides/php-java/aspose.slides/baseslideheaderfootermanager/), et de nombreux autres types.

{{% alert title="Info" color="info" %}}

Pour plus d'informations sur le travail avec les diapositives maîtres en particulier, voir l'article [Maitre de diapositive](https://docs.aspose.com/slides/php-java/slide-master/).

{{% /alert %}}

## **Ajouter une mise en page de diapositive à la présentation**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. Accédez à la collection [MasterSlide](https://reference.aspose.com/slides/php-java/aspose.slides/imasterlayoutslidecollection/).
1. Parcourez les diapositives de mise en page existantes pour confirmer que la diapositive de mise en page requise existe déjà dans la collection de diapositives de mise en page. Sinon, ajoutez la diapositive de mise en page que vous souhaitez. 
1. Ajoutez une diapositive vide basée sur la nouvelle diapositive de mise en page.
1. Enregistrez la présentation. 

Ce code PHP vous montre comment ajouter une mise en page de diapositive à une présentation PowerPoint :

```php
  # Instancie une classe Presentation qui représente le fichier de présentation
  $pres = new Presentation("AccessSlides.pptx");
  try {
    # Parcourt les types de diapositive de mise en page
    $layoutSlides = $pres->getMasters()->get_Item(0)->getLayoutSlides();
    $layoutSlide = null;
    if (!java_is_null($layoutSlides->getByType(SlideLayoutType::TitleAndObject))) {
      $layoutSlide = $layoutSlides->getByType(SlideLayoutType::TitleAndObject);
    } else {
      $layoutSlide = $layoutSlides->getByType(SlideLayoutType::Title);
    }
    if (java_is_null($layoutSlide)) {
      # La situation où une présentation ne contient pas certains types de mise en page.
      # Le fichier de présentation ne contient que des mises en page vides et personnalisées.
      # Mais les diapositives de mise en page avec des types personnalisés ont des noms de diapositive différents,
      # comme "Titre", "Titre et contenu", etc. Et il est possible d'utiliser ces
      # noms pour la sélection de diapositives de mise en page.
      # Vous pouvez également utiliser un ensemble de types de formes de texte de remplacement. Par exemple,
      # La diapositive de titre ne doit avoir que le type de texte de remplacement Titre, etc.
      foreach($layoutSlides as $titleAndObjectLayoutSlide) {
        if (java_values($titleAndObjectLayoutSlide->getName()) == "Titre et objet") {
          $layoutSlide = $titleAndObjectLayoutSlide;
          break;
        }
      }
      if (java_is_null($layoutSlide)) {
        foreach($layoutSlides as $titleLayoutSlide) {
          if (java_values($titleLayoutSlide->getName()) == "Titre") {
            $layoutSlide = $titleLayoutSlide;
            break;
          }
        }
        if (java_is_null($layoutSlide)) {
          $layoutSlide = $layoutSlides->getByType(SlideLayoutType::Blank);
          if (java_is_null($layoutSlide)) {
            $layoutSlide = $layoutSlides->add(SlideLayoutType::TitleAndObject, "Titre et objet");
          }
        }
      }
    }
    # Ajoute une diapositive vide avec la diapositive de mise en page ajoutée
    $pres->getSlides()->insertEmptySlide(0, $layoutSlide);
    # Enregistre la présentation sur le disque
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **Supprimer la diapositive de mise en page inutilisée**

Aspose.Slides fournit la méthode [removeUnusedLayoutSlides](https://reference.aspose.com/slides/php-java/aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) de la classe [Compress](https://reference.aspose.com/slides/php-java/aspose.slides/compress/) pour vous permettre de supprimer les diapositives de mise en page indésirables et inutilisées. Ce code PHP vous montre comment supprimer une diapositive de mise en page d'une présentation PowerPoint :

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

## **Définir la taille et le type pour une mise en page de diapositive**

Pour vous permettre de définir la taille et le type pour une diapositive de mise en page spécifique, Aspose.Slides fournit les propriétés [getType()](https://reference.aspose.com/slides/php-java/aspose.slides/slidesize/#getType--) et [getSize()](https://reference.aspose.com/slides/php-java/aspose.slides/slidesize/#getSize--) (de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)). Cet exemple Java démontre l'opération :

```php
  # Instancie un objet Presentation qui représente un fichier de présentation
  $presentation = new Presentation("demo.pptx");
  try {
    $auxPresentation = new Presentation();
    try {
      # Définit la taille de la diapositive pour la présentation générée à celle de la source
      $auxPresentation->getSlideSize()->setSize(540, 720, SlideSizeScaleType::EnsureFit);
      # getType());
      $auxPresentation->getSlideSize()->setSize(SlideSizeType::A4Paper, SlideSizeScaleType::Maximize);
      # Clone la diapositive requise
      $auxPresentation->getSlides()->addClone($presentation->getSlides()->get_Item(0));
      $auxPresentation->getSlides()->removeAt(0);
      # Enregistre la présentation sur le disque
      $auxPresentation->save("size.pptx", SaveFormat::Pptx);
    } finally {
      $auxPresentation->dispose();
    }
  } finally {
    $presentation->dispose();
  }
```

## **Définir la visibilité du pied de page à l'intérieur de la diapositive**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) .
1. Obtenez la référence d'une diapositive par son index.
1. Réglez l'espace réservé du pied de page de la diapositive sur visible. 
1. Réglez l'espace réservé de la date-heure sur visible. 
1. Enregistrez la présentation. 

Ce code PHP vous montre comment définir la visibilité d'un pied de page de diapositive (et effectuer des tâches connexes) :

```php
  $presentation = new Presentation("presentation.ppt");
  try {
    $headerFooterManager = $presentation->getSlides()->get_Item(0)->getHeaderFooterManager();
    # La méthode isFooterVisible est utilisée pour spécifier qu'un espace réservé de pied de page de diapositive est manquant
    if (!$headerFooterManager->isFooterVisible()) {
      $headerFooterManager->setFooterVisibility(true);// La méthode setFooterVisibility est utilisée pour rendre un pied de page de diapositive visible

    }
    # La méthode isSlideNumberVisible est utilisée pour spécifier qu'un espace réservé de numéro de diapositive est manquant
    if (!$headerFooterManager->isSlideNumberVisible()) {
      $headerFooterManager->setSlideNumberVisibility(true);// La méthode setSlideNumberVisibility est utilisée pour rendre un numéro de diapositive visible

    }
    # La méthode isDateTimeVisible est utilisée pour spécifier qu'un espace réservé de date-heure de diapositive est manquant
    if (!$headerFooterManager->isDateTimeVisible()) {
      $headerFooterManager->setDateTimeVisibility(true);// La méthode SetFooterVisibility est utilisée pour rendre un espace réservé de date-heure de diapositive visible

    }
    $headerFooterManager->setFooterText("Texte du pied de page");// La méthode SetFooterText est utilisée pour définir un texte pour un espace réservé de pied de page de diapositive.

    $headerFooterManager->setDateTimeText("Texte de date et heure");// La méthode SetDateTimeText est utilisée pour définir un texte pour un espace réservé de date-heure de diapositive.

  } finally {
    $presentation->dispose();
  }
```

## **Définir la visibilité du pied de page enfant à l'intérieur de la diapositive**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) .
1. Obtenez une référence pour la diapositive maître par son index. 
1. Réglez la diapositive maître et tous les espaces réservés de pied de page enfant sur visible.
1. Définissez un texte pour la diapositive maître et tous les espaces réservés de pied de page enfant. 
1. Définissez un texte pour la diapositive maître et tous les espaces réservés de date-heure enfant. 
1. Enregistrez la présentation. 

Ce code PHP démontre l'opération :

```php
  $presentation = new Presentation("presentation.ppt");
  try {
    $headerFooterManager = $presentation->getMasters()->get_Item(0)->getHeaderFooterManager();
    $headerFooterManager->setFooterAndChildFootersVisibility(true);// La méthode setFooterAndChildFootersVisibility est utilisée pour rendre la diapositive maître et tous les espaces réservés de pied de page enfant visibles

    $headerFooterManager->setSlideNumberAndChildSlideNumbersVisibility(true);// La méthode setSlideNumberAndChildSlideNumbersVisibility est utilisée pour rendre la diapositive maître et tous les espaces réservés de numéro de page enfant visibles

    $headerFooterManager->setDateTimeAndChildDateTimesVisibility(true);// La méthode setDateTimeAndChildDateTimesVisibility est utilisée pour rendre la diapositive maître et tous les espaces réservés de date-heure enfant visibles

    $headerFooterManager->setFooterAndChildFootersText("Texte du pied de page");// La méthode setFooterAndChildFootersText est utilisée pour définir des textes pour la diapositive maître et tous les espaces réservés de pied de page enfant

    $headerFooterManager->setDateTimeAndChildDateTimesText("Texte de date et heure");// La méthode setDateTimeAndChildDateTimesText est utilisée pour définir un texte pour la diapositive maître et tous les espaces réservés de date-heure enfant

  } finally {
    $presentation->dispose();
  }
```

## **Définir la taille de la diapositive par rapport à la mise à l'échelle du contenu**

1. Créez une instance de la [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) et chargez la présentation contenant la diapositive dont vous souhaitez définir la taille.
1. Créez une autre instance de la [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) pour générer une nouvelle présentation.
1. Obtenez la référence de la diapositive (de la première présentation) par son index.
1. Réglez l'espace réservé du pied de page de la diapositive sur visible. 
1. Réglez l'espace réservé de la date-heure sur visible. 
1. Enregistrez la présentation. 

Ce code PHP démontre l'opération :

```php
  # Instancie un objet Presentation qui représente un fichier de présentation
  $presentation = new Presentation("demo.pptx");
  try {
    # Définit la taille de la diapositive pour les présentations générées à celle de la source
    $presentation->getSlideSize()->setSize(540, 720, SlideSizeScaleType::EnsureFit);// La méthode SetSize est utilisée pour définir la taille de la diapositive avec une échelle de contenu pour s'assurer qu'elle s'adapte

    $presentation->getSlideSize()->setSize(SlideSizeType::A4Paper, SlideSizeScaleType::Maximize);// La méthode SetSize est utilisée pour définir la taille de la diapositive avec la taille maximale du contenu

    # Enregistre la présentation sur le disque
    $presentation->save("Set_Size&Type_out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```

## **Définir la taille de la page lors de la génération d'un PDF**

Certaines présentations (comme des affiches) sont souvent converties en documents PDF. Si vous souhaitez convertir votre PowerPoint en PDF pour accéder aux meilleures options d'impression et d'accessibilité, vous voulez définir vos diapositives à des tailles qui conviennent aux documents PDF (A4, par exemple).

Aspose.Slides fournit la classe [SlideSize](https://reference.aspose.com/slides/php-java/aspose.slides/slidesize/) pour vous permettre de spécifier vos paramètres préférés pour les diapositives. Ce code PHP vous montre comment utiliser la propriété [getType()](https://reference.aspose.com/slides/php-java/aspose.slides/slidesize/#getType--) (de la classe `SlideSize`) pour définir une taille de papier spécifique pour les diapositives d'une présentation :

```php
  # Instancie un objet Presentation qui représente un fichier de présentation
  $presentation = new Presentation();
  try {
    # Définit la propriété SlideSize.Type
    $presentation->getSlideSize()->setSize(SlideSizeType::A4Paper, SlideSizeScaleType::EnsureFit);
    # Définit différentes propriétés pour les options PDF
    $opts = new PdfOptions();
    $opts->setSufficientResolution(600);
    # Enregistre la présentation sur le disque
    $presentation->save("SetPDFPageSize_out.pdf", SaveFormat::Pdf, $opts);
  } finally {
    $presentation->dispose();
  }
```