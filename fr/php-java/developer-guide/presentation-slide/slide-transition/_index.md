---
title: Gérer les transitions de diapositives dans les présentations avec PHP
linktitle: Transition de diapositive
type: docs
weight: 80
url: /fr/php-java/slide-transition/
keywords:
- transition de diapositive
- ajouter une transition de diapositive
- appliquer une transition de diapositive
- transition de diapositive avancée
- transition morph
- type de transition
- effet de transition
- PowerPoint
- OpenDocument
- présentation
- PHP
- Aspose.Slides
description: "Découvrez comment personnaliser les transitions de diapositives dans Aspose.Slides pour PHP via Java, avec des instructions étape par étape pour les présentations PowerPoint et OpenDocument."
---

## **Vue d'ensemble**
{{% alert color="primary" %}} 
Aspose.Slides for PHP via Java permet également aux développeurs de gérer ou de personnaliser les effets de transition des diapositives. Dans cet article, nous aborderons le contrôle des transitions de diapositives avec une grande facilité en utilisant Aspose.Slides for PHP via Java.
{{% /alert %}} 
Pour faciliter la compréhension, nous avons démontré l'utilisation d'Aspose.Slides for PHP via Java pour gérer des transitions de diapositives simples. Les développeurs peuvent non seulement appliquer différents effets de transition aux diapositives, mais également personnaliser le comportement de ces effets de transition.

## **Ajouter une transition de diapositive**
Pour créer un effet de transition de diapositive simple, suivez les étapes ci-dessous :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
1. Appliquer un type de transition de diapositive sur la diapositive à partir de l'un des effets de transition proposés par Aspose.Slides for PHP via Java via l'énumération TransitionType enum
1. Enregistrer le fichier de présentation modifié.
```php
  # Instancier la classe Presentation pour charger le fichier de présentation source
  $presentation = new Presentation("AccessSlides.pptx");
  try {
    # Appliquer la transition de type cercle sur la diapositive 1
    $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->setType(TransitionType::Circle);
    # Appliquer la transition de type peigne sur la diapositive 2
    $presentation->getSlides()->get_Item(1)->getSlideShowTransition()->setType(TransitionType::Comb);
    # Enregistrer la présentation sur le disque
    $presentation->save("SampleTransition_out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```


## **Ajouter une transition de diapositive avancée**
Dans la section précédente, nous avons simplement appliqué un effet de transition simple à la diapositive. Maintenant, pour améliorer et contrôler davantage cet effet de transition simple, veuillez suivre les étapes ci-dessous :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
1. Appliquer un type de transition de diapositive sur la diapositive à partir de l'un des effets de transition proposés par Aspose.Slides for PHP via Java
1. Vous pouvez également définir la transition pour qu'elle avance au clic, après une période de temps spécifique ou les deux.
1. Si la transition de la diapositive est configurée pour avancer au clic, elle ne progresse que lorsqu'un utilisateur clique avec la souris. De plus, si la propriété Advance After Time est définie, la transition avancera automatiquement après le délai spécifié.
1. Enregistrer la présentation modifiée en tant que fichier de présentation.
```php
  # Instancier la classe Presentation qui représente un fichier de présentation
  $pres = new Presentation("BetterSlideTransitions.pptx");
  try {
    # Appliquer la transition de type cercle sur la diapositive 1
    $pres->getSlides()->get_Item(0)->getSlideShowTransition()->setType(TransitionType::Circle);
    # Définir le temps de transition à 3 secondes
    $pres->getSlides()->get_Item(0)->getSlideShowTransition()->setAdvanceOnClick(true);
    $pres->getSlides()->get_Item(0)->getSlideShowTransition()->setAdvanceAfterTime(3000);
    # Appliquer la transition de type peigne sur la diapositive 2
    $pres->getSlides()->get_Item(1)->getSlideShowTransition()->setType(TransitionType::Comb);
    # Définir le temps de transition à 5 secondes
    $pres->getSlides()->get_Item(1)->getSlideShowTransition()->setAdvanceOnClick(true);
    $pres->getSlides()->get_Item(1)->getSlideShowTransition()->setAdvanceAfterTime(5000);
    # Appliquer la transition de type zoom sur la diapositive 3
    $pres->getSlides()->get_Item(2)->getSlideShowTransition()->setType(TransitionType::Zoom);
    # Définir le temps de transition à 7 secondes
    $pres->getSlides()->get_Item(2)->getSlideShowTransition()->setAdvanceOnClick(true);
    $pres->getSlides()->get_Item(2)->getSlideShowTransition()->setAdvanceAfterTime(7000);
    # Enregistrer la présentation sur le disque
    $pres->save("SampleTransition_out.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```


## **Transition Morph**
{{% alert color="primary" %}} 
Aspose.Slides for PHP via Java prend désormais en charge la [Morph Transition](https://reference.aspose.com/slides/php-java/aspose.slides/IMorphTransition). Elles représentent la nouvelle transition morph introduite dans PowerPoint 2019.
{{% /alert %}} 
La transition Morph vous permet d'animer un déplacement fluide d'une diapositive à la suivante. Cet article décrit le concept et la façon d'utiliser la transition Morph. Pour exploiter efficacement la transition Morph, vous devez disposer de deux diapositives partageant au moins un objet commun. La façon la plus simple est de dupliquer la diapositive, puis de déplacer l'objet sur la seconde diapositive à un autre endroit.

Le fragment de code suivant montre comment ajouter un clone de la diapositive avec du texte à la présentation et définir un [morph type](https://reference.aspose.com/slides/php-java/aspose.slides/TransitionType) sur la seconde diapositive.
```php
  $presentation = new Presentation();
  try {
    $autoshape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 400, 100);
    $autoshape->getTextFrame()->setText("Morph Transition in PowerPoint Presentations");
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


## **Types de transition Morph**
Le nouvel énumérateur [TransitionMorphType](https://reference.aspose.com/slides/php-java/aspose.slides/TransitionMorphType) a été ajouté. Il représente différents types de transition de diapositive Morph.

L'énumération TransitionMorphType comporte trois membres :

- ByObject : La transition morph sera effectuée en considérant les formes comme des objets indivisibles.
- ByWord : La transition morph sera effectuée en transférant le texte par mots lorsque cela est possible.
- ByChar : La transition morph sera effectuée en transférant le texte par caractères lorsque cela est possible.

Le fragment de code suivant montre comment définir une transition morph sur une diapositive et changer le type de morph :
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


## **Définir les effets de transition**
Aspose.Slides for PHP via Java prend en charge la définition d'effets de transition tels que depuis le noir, depuis la gauche, depuis la droite, etc. Pour définir l'effet de transition, veuillez suivre les étapes ci-dessous :

- Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
- Obtenir la référence de la diapositive.
- Définir l'effet de transition.
- Enregistrer la présentation en tant que fichier [PPTX](https://docs.fileformat.com/presentation/pptx/).

Dans l'exemple ci-dessous, nous avons défini les effets de transition.
```php
  # Créer une instance de la classe Presentation
  $presentation = new Presentation("AccessSlides.pptx");
  try {
    # Définir l'effet
    $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->setType(TransitionType::Cut);
    $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->getValue()->setFromBlack(true);
    # Enregistrer la présentation sur le disque
    $presentation->save("SetTransitionEffects_out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```


## **FAQ**

**Puis-je contrôler la vitesse de lecture d'une transition de diapositive ?**

Oui. Définissez la [vitesse](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/setspeed/) de la transition à l'aide du paramètre [TransitionSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/transitionspeed/) (par ex. lent/moyen/rapide).

**Puis-je attacher un audio à une transition et le faire boucler ?**

Oui. Vous pouvez intégrer un son à la transition et contrôler son comportement via des paramètres tels que le mode son et la boucle (par ex. [setSound](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/setsound/), [setSoundMode](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/setsoundmode/), [setSoundLoop](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/setsoundloop/), ainsi que des métadonnées comme [setSoundIsBuiltIn](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/setsoundisbuiltin/) et [setSoundName](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/setsoundname/)).

**Quelle est la manière la plus rapide d’appliquer la même transition à chaque diapositive ?**

Configurez le type de transition souhaité dans les paramètres de transition de chaque diapositive ; les transitions étant stockées par diapositive, appliquer le même type à toutes les diapositives donne un résultat cohérent.

**Comment puis‑je vérifier quelle transition est actuellement définie sur une diapositive ?**

Inspectez les [paramètres de transition](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getSlideShowTransition) de la diapositive et lisez son [type de transition](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/settype/); cette valeur indique précisément quel effet est appliqué.