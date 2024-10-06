---
title: Transition de Diapositive
type: docs
weight: 80
url: /androidjava/slide-transition/
keywords: "transition de diapositive PowerPoint, transition morph dans Java"
description: "transition de diapositive PowerPoint, transition morph PowerPoint dans Java"
---


## **Vue d'ensemble**
{{% alert color="primary" %}} 

Aspose.Slides pour Android via Java permet également aux développeurs de gérer ou de personnaliser les effets de transition des diapositives. Dans ce sujet, nous allons discuter du contrôle des transitions de diapositives avec une grande facilité en utilisant Aspose.Slides pour Android via Java.

{{% /alert %}} 

Pour faciliter la compréhension, nous avons démontré l'utilisation d'Aspose.Slides pour Android via Java pour gérer des transitions de diapositives simples. Les développeurs peuvent non seulement appliquer différents effets de transition de diapositives, mais également personnaliser le comportement de ces effets de transition.

## **Ajouter une Transition de Diapositive**
Pour créer un effet de transition de diapositive simple, suivez les étapes ci-dessous :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
1. Appliquez un Type de Transition de Diapositive sur la diapositive à partir de l'un des effets de transition proposés par Aspose.Slides pour Android via Java via l'énumération TransitionType.
1. Écrivez le fichier de présentation modifié.

```java
// Instancier la classe Presentation pour charger le fichier de présentation source
Presentation presentation = new Presentation("AccessSlides.pptx");
try {
    // Appliquer une transition de type cercle sur la diapositive 1
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // Appliquer une transition de type peigne sur la diapositive 2
    presentation.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);

    // Écrire la présentation sur le disque
    presentation.save("SampleTransition_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ajouter une Transition de Diapositive Avancée**
Dans la section ci-dessus, nous avons simplement appliqué un effet de transition simple sur la diapositive. Maintenant, pour améliorer encore cet effet de transition simple et le contrôler, veuillez suivre les étapes ci-dessous :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
1. Appliquez un Type de Transition de Diapositive sur la diapositive à partir de l'un des effets de transition proposés par Aspose.Slides pour Android via Java.
1. Vous pouvez également définir la transition pour avancer au clic, après une période de temps spécifique ou les deux.
1. Si la transition de diapositive est activée pour avancer au clic, la transition n'avancera que lorsque quelqu'un cliquera avec la souris. De plus, si la propriété Avancer Après le Temps est définie, la transition avancera automatiquement après que le temps de progression spécifié sera écoulé.
1. Écrivez la présentation modifiée en tant que fichier de présentation.

```java
// Instancier la classe Presentation qui représente un fichier de présentation
Presentation pres = new Presentation("BetterSlideTransitions.pptx");
try {
    // Appliquer une transition de type cercle sur la diapositive 1
    pres.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // Définir le temps de transition de 3 secondes
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceAfterTime(3000);

    // Appliquer une transition de type peigne sur la diapositive 2
    pres.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);
    
    // Définir le temps de transition de 5 secondes
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceAfterTime(5000);

    // Appliquer une transition de type zoom sur la diapositive 3
    pres.getSlides().get_Item(2).getSlideShowTransition().setType(TransitionType.Zoom);
    
    // Définir le temps de transition de 7 secondes
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

Aspose.Slides pour Android via Java prend maintenant en charge la [Transition Morph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMorphTransition). Elles représentent de nouvelles transitions morph introduites dans PowerPoint 2019.

{{% /alert %}} 

La transition Morph vous permet d'animer un mouvement fluide d'une diapositive à l'autre. Cet article décrit le concept et comment utiliser la transition Morph. Pour utiliser la transition Morph efficacement, vous devez disposer de deux diapositives avec au moins un objet en commun. La manière la plus simple consiste à dupliquer la diapositive, puis à déplacer l'objet sur la deuxième diapositive à un autre endroit.

Le code suivant vous montre comment ajouter un clone de la diapositive avec un texte à la présentation et définir une transition de type [morph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TransitionType) sur la deuxième diapositive.

```java
Presentation presentation = new Presentation();
try {
    AutoShape autoshape = (AutoShape)presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 100);
    autoshape.getTextFrame().setText("Transition Morph dans les Présentations PowerPoint");

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
Une nouvelle énumération [TransitionMorphType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TransitionMorphType) a été ajoutée. Elle représente différents types de transition morph de diapositive.

L'énumération TransitionMorphType a trois membres :

- ByObject : la transition morph sera effectuée en considérant les formes comme des objets indivisibles.
- ByWord : la transition morph sera effectuée en transférant le texte par mots lorsque cela est possible.
- ByChar : la transition morph sera effectuée en transférant le texte par caractères lorsque cela est possible.

Le code suivant vous montre comment définir une transition morph sur la diapositive et changer le type morph :

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
Aspose.Slides pour Android via Java prend en charge la définition des effets de transition comme, de noir, de gauche, de droite, etc. Afin de définir l'Effet de Transition, veuillez suivre les étapes ci-dessous :

- Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
- Obtenez la référence de la diapositive.
- Définir l'effet de transition.
- Écrire la présentation en tant que fichier [PPTX ](https://docs.fileformat.com/presentation/pptx/).

Dans l'exemple donné ci-dessous, nous avons défini les effets de transition.

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