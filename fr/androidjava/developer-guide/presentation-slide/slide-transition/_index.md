---
title: Gérer les transitions de diapositives dans les présentations sur Android
linktitle: Transition de diapositive
type: docs
weight: 80
url: /fr/androidjava/slide-transition/
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
- Android
- Java
- Aspose.Slides
description: "Découvrez comment personnaliser les transitions de diapositives dans Aspose.Slides pour Android via Java, avec un guide étape par étape pour les présentations PowerPoint et OpenDocument."
---

## **Vue d'ensemble**
{{% alert color="primary" %}} 

Aspose.Slides for Android via Java permet également aux développeurs de gérer ou de personnaliser les effets de transition des diapositives. Dans ce sujet, nous aborderons le contrôle des transitions de diapositives avec une grande facilité en utilisant Aspose.Slides for Android via Java.

{{% /alert %}} 

Pour faciliter la compréhension, nous avons démontré l'utilisation d'Aspose.Slides for Android via Java pour gérer des transitions de diapositives simples. Les développeurs peuvent non seulement appliquer différents effets de transition aux diapositives, mais aussi personnaliser le comportement de ces effets de transition.

## **Ajouter une transition de diapositive**
Pour créer un effet de transition de diapositive simple, suivez les étapes ci-dessous :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
1. Appliquez un type de transition de diapositive sur la diapositive à partir de l'un des effets de transition proposés par Aspose.Slides for Android via Java via l'énumération TransitionType.
1. Enregistrez le fichier de présentation modifié.
```java
// Instancier la classe Presentation pour charger le fichier de présentation source
Presentation presentation = new Presentation("AccessSlides.pptx");
try {
    // Appliquer la transition de type cercle sur la diapositive 1
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // Appliquer la transition de type peigne sur la diapositive 2
    presentation.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);

    // Enregistrer la présentation sur le disque
    presentation.save("SampleTransition_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **Ajouter une transition de diapositive avancée**
Dans la section précédente, nous avons simplement appliqué un effet de transition simple sur la diapositive. Maintenant, pour rendre cet effet de transition simple encore meilleur et contrôlé, veuillez suivre les étapes ci-dessous :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
1. Appliquez un type de transition de diapositive sur la diapositive à partir de l'un des effets de transition proposés par Aspose.Slides for Android via Java.
1. Vous pouvez également définir la transition pour qu'elle avance au clic, après une période de temps spécifique ou les deux.
1. Si la transition de la diapositive est activée pour avancer au clic, la transition n'avancera que lorsqu'un utilisateur cliquera avec la souris. De plus, si la propriété Avancer après le temps est définie, la transition avancera automatiquement après le délai spécifié.
1. Enregistrez la présentation modifiée en tant que fichier de présentation.
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

    // Enregistrer la présentation sur le disque
    pres.save("SampleTransition_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


## **Transition Morph**
{{% alert color="primary" %}} 

Aspose.Slides for Android via Java prend désormais en charge la [Transition Morph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMorphTransition). Elles représentent la nouvelle transition morph introduite dans PowerPoint 2019.

{{% /alert %}} 

La transition Morph vous permet d'animer un déplacement fluide d'une diapositive à la suivante. Cet article décrit le concept et la façon d'utiliser la transition Morph. Pour utiliser efficacement la transition Morph, vous devez disposer de deux diapositives partageant au moins un objet commun. Le moyen le plus simple est de dupliquer la diapositive, puis de déplacer l'objet sur la deuxième diapositive vers un autre emplacement.

Le fragment de code suivant montre comment ajouter un clone de la diapositive contenant du texte à la présentation et définir une transition de type [morph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TransitionType) sur la deuxième diapositive.
```java
Presentation presentation = new Presentation();
try {
    AutoShape autoshape = (AutoShape)presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 100);
    autoshape.getTextFrame().setText("Morph Transition in PowerPoint Presentations");

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


## **Types de transition Morph**
Le nouvel énumération [TransitionMorphType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TransitionMorphType) a été ajouté. Il représente différents types de transition de diapositive Morph.

L'énumération TransitionMorphType comprend trois membres :

- ByObject : la transition Morph sera exécutée en considérant les formes comme des objets indivisibles.
- ByWord : la transition Morph sera exécutée en transférant le texte par mots lorsque cela est possible.
- ByChar : la transition Morph sera exécutée en transférant le texte par caractères lorsque cela est possible.

Le fragment de code suivant montre comment définir une transition Morph sur une diapositive et changer le type de morph.
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


## **Définir les effets de transition**
Aspose.Slides for Android via Java prend en charge la définition des effets de transition tels que « from black », « from left », « from right », etc. Pour définir l'effet de transition, veuillez suivre les étapes ci-dessous :

- Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
- Obtenez la référence de la diapositive.
- Définissez l'effet de transition.
- Enregistrez la présentation en tant que fichier [PPTX](https://docs.fileformat.com/presentation/pptx/).

Dans l'exemple ci‑dessous, nous avons défini les effets de transition.
```java
// Créer une instance de la classe Presentation
Presentation presentation = new Presentation("AccessSlides.pptx");
try {
    // Définir l'effet
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Cut);
    ((OptionalBlackTransition)presentation.getSlides().get_Item(0).getSlideShowTransition().getValue()).setFromBlack(true);
    
    // Enregistrer la présentation sur le disque
    presentation.save("SetTransitionEffects_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **FAQ**

**Puis‑je contrôler la vitesse de lecture d'une transition de diapositive ?**

Oui. Définissez la [vitesse](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slideshowtransition/#setSpeed-int-) de la transition à l'aide du paramètre [TransitionSpeed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitionspeed/) (par exemple, lent/moyen/rapide).

**Puis‑je attacher un son à une transition et le faire boucler ?**

Oui. Vous pouvez intégrer un son à la transition et contrôler son comportement via des paramètres tels que le mode son et la boucle (par exemple, [setSound](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slideshowtransition/#setSound-com.aspose.slides.IAudio-), [setSoundMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slideshowtransition/#setSoundMode-int-), [setSoundLoop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slideshowtransition/#setSoundLoop-boolean-), ainsi que des métadonnées comme [setSoundIsBuiltIn](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slideshowtransition/#setSoundIsBuiltIn-boolean-) et [setSoundName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slideshowtransition/#setSoundName-java.lang.String-)).

**Quelle est la façon la plus rapide d'appliquer la même transition à chaque diapositive ?**

Configurez le type de transition souhaité dans les paramètres de transition de chaque diapositive ; les transitions sont stockées par diapositive, ainsi appliquer le même type à toutes les diapositives donne un résultat cohérent.

**Comment vérifier quelle transition est actuellement définie sur une diapositive ?**

Inspectez les [paramètres de transition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseslide/#getSlideShowTransition--) de la diapositive et lisez son [type de transition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slideshowtransition/#setType-int-); cette valeur indique exactement quel effet est appliqué.