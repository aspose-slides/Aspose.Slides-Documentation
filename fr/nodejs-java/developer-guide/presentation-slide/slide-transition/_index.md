---
title: Transition de diapositive
type: docs
weight: 80
url: /fr/nodejs-java/slide-transition/
keywords: "Transition de diapositive PowerPoint, transition morph en JavaScript"
description: "Transition de diapositive PowerPoint, transition morph PowerPoint en JavaScript"
---

## **Vue d'ensemble**
{{% alert color="primary" %}} 

Aspose.Slides for Node.js via Java permet également aux développeurs de gérer ou de personnaliser les effets de transition des diapositives. Dans cet article, nous allons expliquer comment contrôler les transitions de diapositives avec une grande facilité en utilisant Aspose.Slides for Node.js via Java.

{{% /alert %}} 

Pour faciliter la compréhension, nous avons démontré l’utilisation d’Aspose.Slides for Node.js via Java pour gérer des transitions de diapositives simples. Les développeurs peuvent non seulement appliquer différents effets de transition aux diapositives, mais aussi personnaliser le comportement de ces effets de transition.

## **Ajouter une transition de diapositive**
Pour créer un effet de transition de diapositive simple, suivez les étapes ci-dessous :

1. Créez une instance de [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) classe.
1. Appliquez un type de transition de diapositive sur la diapositive à partir de l’un des effets de transition proposés par Aspose.Slides for Node.js via Java via l’énumération TransitionType
1. Enregistrez le fichier de présentation modifié.
```javascript
// Instancier la classe Presentation pour charger le fichier de présentation source
var presentation = new aspose.slides.Presentation("AccessSlides.pptx");
try {
    // Appliquer la transition de type cercle sur la diapositive 1
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(aspose.slides.TransitionType.Circle);
    // Appliquer la transition de type peigne sur la diapositive 2
    presentation.getSlides().get_Item(1).getSlideShowTransition().setType(aspose.slides.TransitionType.Comb);
    // Enregistrer la présentation sur le disque
    presentation.save("SampleTransition_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **Ajouter une transition de diapositive avancée**
Dans la section précédente, nous avons simplement appliqué un effet de transition simple sur la diapositive. Maintenant, pour rendre cette transition simple encore meilleure et plus contrôlée, suivez les étapes ci-dessous :

1. Créez une instance de [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) classe.
1. Appliquez un type de transition de diapositive sur la diapositive à partir de l’un des effets de transition proposés par Aspose.Slides for Node.js via Java
1. Vous pouvez également définir la transition sur Avance au clic, après une période de temps spécifique ou les deux.
1. Si la transition de diapositive est activée pour Avance au clic, la transition n’avancera que lorsqu’un utilisateur cliquera avec la souris. De plus, si la propriété Advance After Time est définie, la transition avancera automatiquement après le temps d’avance spécifié.
1. Enregistrez la présentation modifiée sous forme de fichier de présentation.
```javascript
// Instancier la classe Presentation qui représente un fichier de présentation
var pres = new aspose.slides.Presentation("BetterSlideTransitions.pptx");
try {
    // Appliquer la transition de type cercle sur la diapositive 1
    pres.getSlides().get_Item(0).getSlideShowTransition().setType(aspose.slides.TransitionType.Circle);
    // Définir le temps de transition à 3 secondes
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceAfterTime(3000);
    // Appliquer la transition de type peigne sur la diapositive 2
    pres.getSlides().get_Item(1).getSlideShowTransition().setType(aspose.slides.TransitionType.Comb);
    // Définir le temps de transition à 5 secondes
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceAfterTime(5000);
    // Appliquer la transition de type zoom sur la diapositive 3
    pres.getSlides().get_Item(2).getSlideShowTransition().setType(aspose.slides.TransitionType.Zoom);
    // Définir le temps de transition à 7 secondes
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceAfterTime(7000);
    // Enregistrer la présentation sur le disque
    pres.save("SampleTransition_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


## **Transition Morph**
{{% alert color="primary" %}} 

Aspose.Slides for Node.js via Java prend désormais en charge la [Morph Transition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MorphTransition). Elle représente la nouvelle transition morph introduite dans PowerPoint 2019.

{{% /alert %}} 

La transition Morph vous permet d’animer un mouvement fluide d’une diapositive à la suivante. Cet article décrit le concept et la façon d’utiliser la transition Morph. Pour utiliser efficacement la transition Morph, vous devez disposer de deux diapositives avec au moins un objet commun. Le moyen le plus simple consiste à dupliquer la diapositive, puis à déplacer l’objet sur la seconde diapositive vers un autre emplacement.

L’extrait de code suivant montre comment ajouter un clone de la diapositive avec du texte à la présentation et définir une transition de type [morph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TransitionType) sur la deuxième diapositive.
```javascript
var presentation = new aspose.slides.Presentation();
try {
    var autoshape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 400, 100);
    autoshape.getTextFrame().setText("Morph Transition in PowerPoint Presentations");
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0));
    var shape = presentation.getSlides().get_Item(1).getShapes().get_Item(0);
    shape.setX(shape.getX() + 100);
    shape.setY(shape.getY() + 50);
    shape.setWidth(shape.getWidth() - 200);
    shape.setHeight(shape.getHeight() - 10);
    presentation.getSlides().get_Item(1).getSlideShowTransition().setType(aspose.slides.TransitionType.Morph);
    presentation.save("presentation-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **Types de transition Morph**
Une nouvelle énumération [TransitionMorphType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TransitionMorphType) a été ajoutée. Elle représente différents types de transition Morph de diapositive.

L’énumération TransitionMorphType possède trois membres :

- ByObject : la transition Morph sera effectuée en considérant les formes comme des objets indivisibles.
- ByWord : la transition Morph sera effectuée en transférant le texte par mots lorsque cela est possible.
- ByChar : la transition Morph sera effectuée en transférant le texte par caractères lorsque cela est possible.

L’extrait de code suivant montre comment définir une transition Morph sur une diapositive et changer le type Morph :
```javascript
var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(aspose.slides.TransitionType.Morph);
    presentation.getSlides().get_Item(0).getSlideShowTransition().getValue().setMorphType(aspose.slides.TransitionMorphType.ByWord);
    presentation.save("presentation-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **Définir les effets de transition**
Aspose.Slides for Node.js via Java prend en charge la définition d’effets de transition tels que depuis le noir, depuis la gauche, depuis la droite, etc. Pour définir l’effet de transition, suivez les étapes ci-dessous :

- Créez une instance de [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) classe.
- Obtenez la référence de la diapositive.
- Définissez l’effet de transition.
- Enregistrez la présentation sous forme de [PPTX](https://docs.fileformat.com/presentation/pptx/) fichier.

Dans l’exemple ci‑dessous, nous avons défini les effets de transition.
```javascript
// Créer une instance de la classe Presentation
var presentation = new aspose.slides.Presentation("AccessSlides.pptx");
try {
    // Définir l'effet
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(aspose.slides.TransitionType.Cut);
    presentation.getSlides().get_Item(0).getSlideShowTransition().getValue().setFromBlack(true);
    // Enregistrer la présentation sur le disque
    presentation.save("SetTransitionEffects_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **FAQ**

**Puis‑je contrôler la vitesse de lecture d’une transition de diapositive ?**

Oui. Définissez la [speed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/setspeed/) de la transition à l’aide du paramètre [TransitionSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitionspeed/) (par ex., slow/medium/fast).

**Puis‑je attacher un son à une transition et le faire boucler ?**

Oui. Vous pouvez incorporer un son pour la transition et contrôler son comportement via des paramètres tels que le mode son et la boucle (par ex., [setSound](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/setsound/), [setSoundMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/setsoundmode/), [setSoundLoop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/setsoundloop/), ainsi que des métadonnées comme [setSoundIsBuiltIn](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/setsoundisbuiltin/) et [setSoundName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/setsoundname/)).

**Quelle est la façon la plus rapide d’appliquer la même transition à chaque diapositive ?**

Configurez le type de transition souhaité dans les paramètres de transition de chaque diapositive ; les transitions sont stockées par diapositive, donc appliquer le même type à toutes les diapositives donne un résultat cohérent.

**Comment puis‑je vérifier quelle transition est actuellement définie sur une diapositive ?**

Inspectez les [transition settings](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getSlideShowTransition) de la diapositive et lisez son [transition type](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/gettype/) ; cette valeur indique exactement quel effet est appliqué.