---
title: Transition de Diapositive
type: docs
weight: 80
url: /fr/java/slide-transition/
keywords: "transition de diapositive PowerPoint, transition morph dans Java"
description: "transition de diapositive PowerPoint, transition morph PowerPoint dans Java"
---


## **Vue d'ensemble**
{{% alert color="primary" %}} 

Aspose.Slides pour Java permet également aux développeurs de gérer ou de personnaliser les effets de transition des diaporamas. Dans ce sujet, nous allons discuter de la manière de contrôler les transitions de diapositive avec une grande facilité en utilisant Aspose.Slides pour Java.

{{% /alert %}} 

Pour faciliter la compréhension, nous avons démontré l'utilisation d'Aspose.Slides pour Java pour gérer des transitions de diapositive simples. Les développeurs peuvent non seulement appliquer différents effets de transition de diapositive, mais également personnaliser le comportement de ces effets de transition.

## **Ajouter une Transition de Diapositive**
Pour créer un effet de transition de diapositive simple, suivez les étapes ci-dessous :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation).
1. Appliquez un type de transition de diapositive sur la diapositive à partir de l'un des effets de transition proposés par Aspose.Slides pour Java via l'énumération TransitionType.
1. Écrivez le fichier de présentation modifié.

```java
// Instancier la classe Presentation pour charger le fichier de présentation source
Presentation presentation = new Presentation("AccessSlides.pptx");
try {
    // Appliquer la transition de type cercle sur la diapositive 1
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // Appliquer la transition de type peigne sur la diapositive 2
    presentation.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);

    // Écrire la présentation sur le disque
    presentation.save("SampleTransition_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ajouter une Transition de Diapositive Avancée**
Dans la section ci-dessus, nous avons simplement appliqué un effet de transition simple sur la diapositive. Maintenant, pour améliorer et contrôler cet effet de transition simple, veuillez suivre les étapes ci-dessous :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation).
1. Appliquez un type de transition de diapositive sur la diapositive à partir de l'un des effets de transition proposés par Aspose.Slides pour Java.
1. Vous pouvez également définir la transition pour avancer au clic, après une période de temps spécifique ou les deux.
1. Si la transition de diapositive est activée pour avancer au clic, la transition ne progressera que lorsque quelqu'un cliquera avec la souris. De plus, si la propriété Avancer Après Temps est définie, la transition avancera automatiquement après le temps spécifié.
1. Écrivez la présentation modifiée en tant que fichier de présentation.

```java
// Instancier la classe Presentation qui représente un fichier de présentation
Presentation pres = new Presentation("BetterSlideTransitions.pptx");
try {
    // Appliquer la transition de type cercle sur la diapositive 1
    pres.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // Définir le temps de transition à 3 secondes
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceAfterTime(3000);

    // Appliquer la transition de type peigne sur la diapositive 2
    pres.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);
    
    // Définir le temps de transition à 5 secondes
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceAfterTime(5000);

    // Appliquer la transition de type zoom sur la diapositive 3
    pres.getSlides().get_Item(2).getSlideShowTransition().setType(TransitionType.Zoom);
    
    // Définir le temps de transition à 7 secondes
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceAfterTime(7000);

    // Écrire la présentation sur le disque
    pres.save("SampleTransition_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Transition Morph**
{{% alert color="primary" %}} 

Aspose.Slides pour Java prend maintenant en charge la [Transition Morph](https://reference.aspose.com/slides/java/com.aspose.slides/IMorphTransition). Elle représente la nouvelle transition morph introduite dans PowerPoint 2019.

{{% /alert %}} 

La transition Morph vous permet d'animer un mouvement fluide d'une diapositive à l'autre. Cet article décrit le concept et comment utiliser la transition Morph. Pour utiliser efficacement la transition Morph, vous devez avoir deux diapositives avec au moins un objet en commun. La façon la plus simple est de dupliquer la diapositive, puis de déplacer l'objet sur la deuxième diapositive à un autre endroit.

Le code suivant montre comment ajouter un clone de la diapositive avec un texte à la présentation et définir une transition de type [morph](https://reference.aspose.com/slides/java/com.aspose.slides/TransitionType) sur la deuxième diapositive.

```java
Presentation presentation = new Presentation();
try {
    AutoShape autoshape = (AutoShape)presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 100);
    autoshape.getTextFrame().setText("Transition Morph dans les présentations PowerPoint");

    presentation.getSlides().addClone(presentation.getSlides().get_Item(0));

    IShape shape = presentation.getSlides().get_Item(1).getShapes().get_Item(0);
    shape.setX(shape.getX() + 100);
    shape.setY(shape.getY() + 50);
    shape.setWidth(shape.getWidth() - 200);
    shape.setHeight(shape.getHeight() - 10);

    presentation.getSlides().get_Item(1).getSlideShowTransition().setType(com.aspose.slides.TransitionType.Morph);

    presentation.save("presentation-out.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

## **Types de Transition Morph**
Une nouvelle énumération [TransitionMorphType](https://reference.aspose.com/slides/java/com.aspose.slides/TransitionMorphType) a été ajoutée. Elle représente différents types de transition morph de diapositive.

L'énumération TransitionMorphType a trois membres :

- ByObject: La transition morph sera effectuée en considérant les formes comme des objets indivisibles.
- ByWord: La transition morph sera effectuée en transférant le texte par mots lorsque c'est possible.
- ByChar: La transition morph sera effectuée en transférant le texte par caractères lorsque c'est possible.

Le code suivant montre comment définir une transition morph sur une diapositive et changer le type de morph :

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Morph);
    ((IMorphTransition)presentation.getSlides().get_Item(0).getSlideShowTransition().getValue()).setMorphType(TransitionMorphType.ByWord);
    presentation.save("presentation-out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Définir les Effets de Transition**
Aspose.Slides pour Java prend en charge la définition des effets de transition comme, à partir de noir, à partir de gauche, à partir de droite, etc. Pour définir l'effet de transition, veuillez suivre les étapes ci-dessous :

- Créez une instance de [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) classe.
- Obtenez la référence de la diapositive.
- Définissez l'effet de transition.
- Écrivez la présentation en tant que fichier [PPTX](https://docs.fileformat.com/presentation/pptx/).

Dans l'exemple ci-dessous, nous avons défini les effets de transition.

```java
// Créer une instance de la classe Presentation
Presentation presentation = new Presentation("AccessSlides.pptx");
try {
    // Définir l'effet
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Cut);
    ((OptionalBlackTransition)presentation.getSlides().get_Item(0).getSlideShowTransition().getValue()).setFromBlack(true);
    
    // Écrire la présentation sur le disque
    presentation.save("SetTransitionEffects_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```