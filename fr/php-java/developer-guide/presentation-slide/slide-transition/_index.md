---
title: Transition de Diapositive
type: docs
weight: 80
url: /php-java/slide-transition/
keywords: "transition de diapositive PowerPoint, transition morph"
description: "transition de diapositive PowerPoint, transition morph PowerPoint"
---


## **Aperçu**
{{% alert color="primary" %}} 

Aspose.Slides pour PHP via Java permet également aux développeurs de gérer ou de personnaliser les effets de transition de diapositives. Dans ce sujet, nous allons discuter de la manière de contrôler les transitions de diapositives avec une grande facilité en utilisant Aspose.Slides pour PHP via Java.

{{% /alert %}} 

Pour faciliter la compréhension, nous avons démontré l'utilisation d'Aspose.Slides pour PHP via Java pour gérer des transitions de diapositives simples. Les développeurs peuvent non seulement appliquer différents effets de transition de diapositive, mais aussi personnaliser le comportement de ces effets de transition.

## **Ajouter une Transition de Diapositive**
Pour créer un effet de transition de diapositive simple, suivez les étapes ci-dessous :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
1. Appliquez un type de transition de diapositive sur la diapositive à partir de l'un des effets de transition offerts par Aspose.Slides pour PHP via Java à travers l'énumération TransitionType.
1. Écrivez le fichier de présentation modifié.

```php
  # Instancier la classe Presentation pour charger le fichier de présentation source
  $presentation = new Presentation("AccessSlides.pptx");
  try {
    # Appliquer une transition de type cercle sur la diapositive 1
    $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->setType(TransitionType::Circle);
    # Appliquer une transition de type peigne sur la diapositive 2
    $presentation->getSlides()->get_Item(1)->getSlideShowTransition()->setType(TransitionType::Comb);
    # Écrire la présentation sur le disque
    $presentation->save("SampleTransition_out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```

## **Ajouter une Transition de Diapositive Avancée**
Dans la section ci-dessus, nous avons simplement appliqué un effet de transition simple sur la diapositive. Maintenant, pour améliorer et contrôler cet effet de transition simple, veuillez suivre les étapes ci-dessous :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
1. Appliquez un type de transition de diapositive sur la diapositive à partir de l'un des effets de transition offerts par Aspose.Slides pour PHP via Java.
1. Vous pouvez également définir la transition pour avancer sur clic, après une période spécifique ou les deux.
1. Si la transition de diapositive est activée pour avancer sur clic, la transition n'avancera que lorsque quelqu'un cliquera avec la souris. De plus, si la propriété Avancer Après Temps est définie, la transition avancera automatiquement après que le temps d'avance spécifié sera écoulé.
1. Écrivez la présentation modifiée en tant que fichier de présentation.

```php
  # Instancier la classe Presentation qui représente un fichier de présentation
  $pres = new Presentation("BetterSlideTransitions.pptx");
  try {
    # Appliquer une transition de type cercle sur la diapositive 1
    $pres->getSlides()->get_Item(0)->getSlideShowTransition()->setType(TransitionType::Circle);
    # Définir le temps de transition à 3 secondes
    $pres->getSlides()->get_Item(0)->getSlideShowTransition()->setAdvanceOnClick(true);
    $pres->getSlides()->get_Item(0)->getSlideShowTransition()->setAdvanceAfterTime(3000);
    # Appliquer une transition de type peigne sur la diapositive 2
    $pres->getSlides()->get_Item(1)->getSlideShowTransition()->setType(TransitionType::Comb);
    # Définir le temps de transition à 5 secondes
    $pres->getSlides()->get_Item(1)->getSlideShowTransition()->setAdvanceOnClick(true);
    $pres->getSlides()->get_Item(1)->getSlideShowTransition()->setAdvanceAfterTime(5000);
    # Appliquer une transition de type zoom sur la diapositive 3
    $pres->getSlides()->get_Item(2)->getSlideShowTransition()->setType(TransitionType::Zoom);
    # Définir le temps de transition à 7 secondes
    $pres->getSlides()->get_Item(2)->getSlideShowTransition()->setAdvanceOnClick(true);
    $pres->getSlides()->get_Item(2)->getSlideShowTransition()->setAdvanceAfterTime(7000);
    # Écrire la présentation sur le disque
    $pres->save("SampleTransition_out.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **Transition Morph**
{{% alert color="primary" %}} 

Aspose.Slides pour PHP via Java prend maintenant en charge la [Transition Morph](https://reference.aspose.com/slides/php-java/aspose.slides/IMorphTransition). Elles représentent la nouvelle transition morph introduite dans PowerPoint 2019.

{{% /alert %}} 

La transition Morph permet d'animer un mouvement fluide d'une diapositive à l'autre. Cet article décrit le concept et comment utiliser la transition Morph. Pour utiliser la transition Morph efficacement, vous devez disposer de deux diapositives avec au moins un objet en commun. La façon la plus simple est de dupliquer la diapositive, puis de déplacer l'objet sur la deuxième diapositive à un autre endroit.

Le code suivant vous montre comment ajouter un clone de la diapositive avec du texte à la présentation et définir une transition de [type morph](https://reference.aspose.com/slides/php-java/aspose.slides/TransitionType) à la deuxième diapositive.

```php
  $presentation = new Presentation();
  try {
    $autoshape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 400, 100);
    $autoshape->getTextFrame()->setText("Transition Morph dans les Présentations PowerPoint");
    $presentation->getSlides()->addClone($presentation->getSlides()->get_Item(0));
    $shape = $presentation->getSlides()->get_Item(1)->getShapes()->get_Item(0);
    $shape->setX($shape->getX() + 100);
    $shape->setY($shape->getY() + 50);
    $shape->setWidth($shape->getWidth() - 200);
    $shape->setHeight($shape->getHeight() - 10);
    $presentation->getSlides()->get_Item(1)->getSlideShowTransition()->setType(TransitionType::Morph);
    $presentation->save("presentation-out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```

## **Types de Transition Morph**
Une nouvelle énumération [TransitionMorphType](https://reference.aspose.com/slides/php-java/aspose.slides/TransitionMorphType) a été ajoutée. Elle représente différents types de transition morph de diapositive.

L'énumération TransitionMorphType a trois membres :

- ByObject : La transition morph sera effectuée en considérant les formes comme des objets indivisibles.
- ByWord : La transition morph sera effectuée en transférant le texte par mots lorsque cela est possible.
- ByChar : La transition morph sera effectuée en transférant le texte par caractères lorsque cela est possible.

Le code suivant vous montre comment définir la transition morph à la diapositive et changer le type de morph :

```php
  $presentation = new Presentation("presentation.pptx");
  try {
    $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->setType(TransitionType::Morph);
    $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->getValue()->setMorphType(TransitionMorphType::ByWord);
    $presentation->save("presentation-out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```

## **Définir des Effets de Transition**
Aspose.Slides pour PHP via Java prend en charge la définition des effets de transition comme, de noir, de gauche, de droite, etc. Afin de définir l'effet de transition. Veuillez suivre les étapes ci-dessous :

- Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
- Obtenez la référence de la diapositive.
- Définir l'effet de transition.
- Écrivez la présentation en tant que fichier [PPTX ](https://docs.fileformat.com/presentation/pptx/).

Dans l'exemple donné ci-dessous, nous avons défini les effets de transition.

```php
  # Créer une instance de la classe Presentation
  $presentation = new Presentation("AccessSlides.pptx");
  try {
    # Définir l'effet
    $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->setType(TransitionType::Cut);
    $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->getValue()->setFromBlack(true);
    # Écrire la présentation sur le disque
    $presentation->save("SetTransitionEffects_out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```