---
title: Gérer les transitions de diapositives dans les présentations à l'aide de JavaScript
linktitle: Transition de diapositive
type: docs
weight: 80
url: /fr/nodejs-java/slide-transition/
keywords:
- transition de diapositive
- ajouter une transition de diapositive
- appliquer une transition de diapositive
- transition de diapositive avancée
- transition Morph
- type de transition
- effet de transition
- PowerPoint
- OpenDocument
- présentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Appliquer des transitions de diapositives, configurer l’avancement automatique des diapositives et personnaliser les transitions Morph et autres avec Aspose.Slides pour Node.js via Java."
---
## **Vue d'ensemble**

Les transitions de diapositive contrôlent la façon dont les diapositives apparaissent pendant un diaporama. Avec Aspose.Slides for Node.js via Java, vous pouvez choisir un effet de transition pour chaque diapositive, configurer l’avance par clic de souris ou par minuteur, et ajuster les options spécifiques à un effet. Cet article utilise des exemples JavaScript pour appliquer des transitions, définir des durées exactes de transition, gérer le minutage des diapositives et créer une transition Morph entre deux diapositives. Les exemples montrent également comment enregistrer les paramètres dans un fichier PPTX.

## **Ajouter une transition de diapositive**

Pour appliquer une transition, chargez une présentation avec la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) et accédez aux paramètres de transition de la diapositive via [getSlideShowTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getSlideShowTransition). Utilisez [setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setType) avec une valeur de l’énumération [TransitionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitiontype/), puis enregistrez la présentation.

L’exemple suivant applique une transition Circle à la première diapositive et une transition Comb à la deuxième. Utilisez un fichier `input.pptx` contenant au moins deux diapositives.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    if (presentation.getSlides().size() >= 2) {
        presentation.getSlides().get_Item(0).getSlideShowTransition().setType(slides.TransitionType.Circle);
        presentation.getSlides().get_Item(1).getSlideShowTransition().setType(slides.TransitionType.Comb);

        presentation.save("slide-transitions.pptx", slides.SaveFormat.Pptx);
    } else {
        console.log("The input presentation must contain at least two slides.");
    }
} finally {
    presentation.dispose();
}
```

## **Transition en roue**

La méthode [setSpokes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/wheeltransition/#setSpokes) de [WheelTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/wheeltransition/) contrôle le nombre de secteurs radiaux qui révèlent la diapositive cible. Définissez le type de transition de la diapositive sur Wheel depuis [TransitionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitiontype/) à l’aide de [setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setType) avant d’accéder à [getValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getValue) en tant que [WheelTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/wheeltransition/).

Cet exemple crée deux paires identiques de diapositives : une diapositive noire suivie d’une diapositive avec un rectangle doré. Les diapositives cibles utilisent respectivement des nombres de rayons de 1 et 8, avec la même vitesse définie via [setSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setSpeed) et une durée explicite de 8 000 ms définie via [setDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setDuration) pour rendre la différence facile à observer.

```javascript
const java = require("java");
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const slideWidth = presentation.getSlideSize().getSize().getWidth();
    const slideHeight = presentation.getSlideSize().getSize().getHeight();

    const blackSlide = presentation.getSlides().get_Item(0);
    blackSlide.getShapes().clear();
    blackSlide.getBackground().setType(java.newByte(slides.BackgroundType.OwnBackground));
    blackSlide.getBackground().getFillFormat().setFillType(java.newByte(slides.FillType.Solid));
    const black = java.newInstanceSync("java.awt.Color", 0, 0, 0);
    blackSlide.getBackground().getFillFormat().getSolidFillColor().setColor(black);

    const destinationSlide = presentation.getSlides().addClone(blackSlide);
    const rectangle = destinationSlide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 0, 0, slideWidth, slideHeight);
    rectangle.getFillFormat().setFillType(java.newByte(slides.FillType.Solid));
    const gold = java.newInstanceSync("java.awt.Color", 255, 215, 0);
    rectangle.getFillFormat().getSolidFillColor().setColor(gold);
    rectangle.getTextFrame().setText("Wheel transition");

    presentation.getSlides().addClone(blackSlide);
    presentation.getSlides().addClone(destinationSlide);

    const spokeCounts = [1, 8];
    for (let i = 0; i < spokeCounts.length; i++) {
        const transition = presentation.getSlides().get_Item(i * 2 + 1).getSlideShowTransition();
        transition.setType(slides.TransitionType.Wheel);
        const wheelTransition = transition.getValue();
        wheelTransition.setSpokes(java.newLong(spokeCounts[i]));
        transition.setSpeed(slides.TransitionSpeed.Slow);
        transition.setDuration(8000);
    }

    presentation.save("wheel-transitions.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Ouvrez la présentation de sortie dans PowerPoint et lancez le diaporama. Passez de la diapositive 1 à la diapositive 2, puis de la diapositive 3 à la diapositive 4. En lecture PowerPoint, le nombre de rayons vérifié de 1 révèle la diapositive avec un balayage horaire unique ; le nombre vérifié de 8 la révèle à travers huit secteurs radiaux simultanément. Le contenu cible et le minutage de la transition sont identiques, la différence réside dans le nombre de secteurs de révélation.

## **Ajouter une transition de diapositive avancée**

Vous pouvez configurer la durée pendant laquelle une diapositive reste à l’écran et si un clic de souris avance le diaporama. Les méthodes suivantes contrôlent ce comportement :

- [setAdvanceOnClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) permet au spectateur d’avancer en cliquant.
- [setAdvanceAfter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfter) active l’avancement automatique.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) spécifie le délai avant l’avancement automatique, en millisecondes.

Activez à la fois l’avancement par clic et par minuteur pour permettre au spectateur de passer à la suite avec un clic ou d’attendre le minuteur. Pour n’utiliser que le minuteur, passez `false` à [setAdvanceOnClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceOnClick). Le délai contrôle le moment où le diaporama avance ; il ne définit pas la durée de l’effet visuel de transition.

Cet exemple affecte différents effets aux trois premières diapositives et active l’avancement automatique après 3, 5 et 7 secondes respectivement. Les clics de souris peuvent également faire avancer ces diapositives. Utilisez un fichier `input.pptx` contenant au moins trois diapositives.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    if (presentation.getSlides().size() >= 3) {
        const firstTransition = presentation.getSlides().get_Item(0).getSlideShowTransition();
        firstTransition.setType(slides.TransitionType.Circle);
        firstTransition.setAdvanceOnClick(true);
        firstTransition.setAdvanceAfter(true);
        firstTransition.setAdvanceAfterTime(3000);

        const secondTransition = presentation.getSlides().get_Item(1).getSlideShowTransition();
        secondTransition.setType(slides.TransitionType.Comb);
        secondTransition.setAdvanceOnClick(true);
        secondTransition.setAdvanceAfter(true);
        secondTransition.setAdvanceAfterTime(5000);

        const thirdTransition = presentation.getSlides().get_Item(2).getSlideShowTransition();
        thirdTransition.setType(slides.TransitionType.Zoom);
        thirdTransition.setAdvanceOnClick(true);
        thirdTransition.setAdvanceAfter(true);
        thirdTransition.setAdvanceAfterTime(7000);

        presentation.save("advanced-transitions.pptx", slides.SaveFormat.Pptx);
    } else {
        console.log("The input presentation must contain at least three slides.");
    }
} finally {
    presentation.dispose();
}
```

Pour vérifier si l’avancement chronométré est activé, appelez [getAdvanceAfter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getAdvanceAfter). Un délai stocké seul n’indique pas que le minuteur est actif.

L’exemple suivant ouvre le fichier enregistré précédemment, signale chaque minuteur activé et désactive l’avancement automatique pour les diapositives dont le délai dépasse deux secondes. Il active les clics de souris pour ces diapositives et enregistre les paramètres mis à jour.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("advanced-transitions.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        const slide = presentation.getSlides().get_Item(i);
        const transition = slide.getSlideShowTransition();

        if (transition.getAdvanceAfter()) {
            console.log("Slide " + slide.getSlideNumber() + ": advance after " + transition.getAdvanceAfterTime() + " ms.");

            if (transition.getAdvanceAfterTime() > 2000) {
                transition.setAdvanceAfter(false);
                transition.setAdvanceOnClick(true);
            }
        }
    }

    presentation.save("adjusted-transitions.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Contrôler le minutage de la transition avec précision**

Utilisez [setDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setDuration) pour spécifier la longueur exacte d’un effet de transition en millisecondes. La méthode [getSlideShowTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getSlideShowTransition) de la diapositive expose ces paramètres via [SlideShowTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/) :

| Méthode | Objectif |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setDuration) | Définit la durée de l’effet de transition lui‑même, en millisecondes. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) | Définit le délai avant que la diapositive ne progresse automatiquement, en millisecondes. Passez `true` à [setAdvanceAfter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfter) pour activer ce minuteur. |
| [setSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setSpeed) | Sélectionne une catégorie de vitesse prédéfinie depuis [TransitionSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitionspeed/) : Slow, Medium ou Fast. Elle est utilisée lorsqu’une durée exacte n’est pas spécifiée. |

[setDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setDuration) ne contrôle que l’effet de transition ; il ne détermine pas la durée pendant laquelle la diapositive reste visible. Configurez séparément le délai d’avancement automatique. Lorsqu’aucune durée explicite n’est définie, Aspose.Slides détermine la durée de l’effet à partir du type de transition et de la valeur [getSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getSpeed).

<!-- visual-explanation:slide-transition:start -->
[![Des barres séparées identifient la durée de transition de 750 ms et le réglage d’avancement automatique de 5 000 ms.](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*L’exemple partagé applique à chaque diapositive une transition Fondu de 750 ms et active séparément l’avancement automatique à 5 000 ms. La durée de la transition contrôle l’effet ; l’avancement contrôle le moment de quitter la diapositive. Ces barres sont des réglages schématiques, et non une chronologie combinée mesurée.* 
<!-- visual-explanation:slide-transition:end -->

### **Appliquer la même durée à chaque diapositive**

Pour un rythme cohérent, appliquez le même effet et la même durée exacte à chaque diapositive. Cet exemple charge `input.pptx`, sélectionne Fade depuis [TransitionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitiontype/), et donne à chaque transition une durée de 750 millisecondes. Il active séparément l’avancement automatique après 5 000 millisecondes et désactive l’avancement par clic, puis enregistre le résultat au format PPTX.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        const slide = presentation.getSlides().get_Item(i);
        const transition = slide.getSlideShowTransition();
        transition.setType(slides.TransitionType.Fade);
        transition.setDuration(750);

        // Configurer l'avancement automatique indépendamment de la durée de l'effet.
        transition.setAdvanceAfter(true);
        transition.setAdvanceAfterTime(5000);
        transition.setAdvanceOnClick(false);
    }

    presentation.save("precise-transitions.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Définir des durées différentes pour des diapositives individuelles**

Des diapositives différentes peuvent utiliser des durées d’effet distinctes. Par exemple, utilisez une transition brève pour une diapositive titre et une transition plus longue pour une introduction de section. Cet exemple fixe 500 ms pour la première diapositive et 1 200 ms pour la deuxième. Utilisez un fichier `input.pptx` contenant au moins deux diapositives.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    if (presentation.getSlides().size() >= 2) {
        const firstTransition = presentation.getSlides().get_Item(0).getSlideShowTransition();
        firstTransition.setType(slides.TransitionType.Fade);
        firstTransition.setDuration(500);

        const secondTransition = presentation.getSlides().get_Item(1).getSlideShowTransition();
        secondTransition.setType(slides.TransitionType.Push);
        secondTransition.setDuration(1200);

        presentation.save("individual-transition-durations.pptx", slides.SaveFormat.Pptx);
    } else {
        console.log("The input presentation must contain at least two slides.");
    }
} finally {
    presentation.dispose();
}
```

### **Coordonner les transitions avec une sortie animée**

Lors de la préparation d’un [animated GIF](/slides/fr/nodejs-java/convert-powerpoint-to-animated-gif/), d’une [présentation HTML5](/slides/fr/nodejs-java/export-to-html5/) ou d’une [vidéo](/slides/fr/nodejs-java/convert-powerpoint-to-video/), définissez les durées exactes des transitions avant l’exportation afin de correspondre au rythme souhaité. Par exemple, utilisez un fondu de 600 ms entre les scènes et ajustez séparément le délai d’avancement de chaque diapositive pour laisser le temps à la narration ou au contenu.

Pour les GIF et les vidéos, coordonnez le nombre d’images par seconde avec la durée de l’effet : 600 ms correspondent à 18 images à 30 fps. En HTML5, activez les transitions animées dans les paramètres d’export. Vérifiez les effets et options de minutage pris en charge par le format d’export choisi et prévisualisez la sortie pour confirmer la synchronisation.

### **Lire une durée de transition existante**

Appelez [getDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getDuration) avant de modifier la transition afin de déterminer si une valeur explicite est stockée. Une valeur de `-1` indique qu’aucune durée explicite n’est définie ; une valeur non négative spécifie la durée stockée en millisecondes. La valeur non définie n’est pas la durée de lecture calculée : Aspose.Slides utilise le type de transition et la valeur [getSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getSpeed) pour déterminer cette durée. La définition d’un type de transition peut initialiser une durée, donc inspectez d’abord les paramètres originaux.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        const slide = presentation.getSlides().get_Item(i);
        const transition = slide.getSlideShowTransition();
        const duration = transition.getDuration();

        if (duration >= 0) {
            console.log("Slide " + slide.getSlideNumber() + ": stored transition duration is " + duration + " ms.");
        } else {
            console.log("Slide " + slide.getSlideNumber() + ": no explicit duration; timing depends on transition type " + transition.getType() + " and speed " + transition.getSpeed() + ".");
        }
    }
} finally {
    presentation.dispose();
}
```

## **Transition Morph**

La transition Morph anime les changements entre les objets sur des diapositives consécutives. Pour créer un effet Morph simple, dupliquez une diapositive, déplacez ou redimensionnez un objet sur la copie, puis appliquez la transition Morph à la deuxième diapositive. Cela donne aux objets correspondants la possibilité d’animer entre leurs états d’origine et modifiés.

L’exemple suivant crée une diapositive contenant un rectangle de texte, duplique la diapositive et modifie la position et la taille du rectangle sur la copie. Il sélectionne ensuite Morph depuis l’énumération [TransitionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitiontype/) pour la deuxième diapositive. Ouvrez le fichier enregistré dans un visionneur de présentations qui prend en charge Morph pour voir l’effet pendant le diaporama.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const firstSlide = presentation.getSlides().get_Item(0);
    const rectangle = firstSlide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 100, 100, 400, 100);
    rectangle.getTextFrame().setText("Morph transition");

    const secondSlide = presentation.getSlides().addClone(firstSlide);
    const movedRectangle = secondSlide.getShapes().get_Item(0);
    movedRectangle.setX(movedRectangle.getX() + 100);
    movedRectangle.setY(movedRectangle.getY() + 50);
    movedRectangle.setWidth(movedRectangle.getWidth() - 200);
    movedRectangle.setHeight(movedRectangle.getHeight() - 10);

    secondSlide.getSlideShowTransition().setType(slides.TransitionType.Morph);

    presentation.save("morph-transition.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Types de transition Morph**

L’énumération [TransitionMorphType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitionmorphtype/) contrôle la manière dont Morph associe et anime le contenu :

- [ByObject](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitionmorphtype/#ByObject) traite chaque forme comme un objet complet.
- [ByWord](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitionmorphtype/#ByWord) anime le texte en associant les mots lorsque c’est possible.
- [ByChar](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitionmorphtype/#ByChar) anime le texte en associant les caractères lorsque c’est possible.

Utilisez [setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setType) pour sélectionner Morph avant d’accéder à [getValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getValue). La valeur fournit alors un objet [MorphTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/morphtransition/), dont la méthode [setMorphType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/morphtransition/#setMorphType) sélectionne le mode d’association.

Cet exemple ouvre la présentation créée dans la section précédente et configure la deuxième diapositive pour utiliser l’animation Morph basée sur les mots.

```javascript
const java = require("java");
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("morph-transition.pptx");
try {
    if (presentation.getSlides().size() >= 2) {
        const transition = presentation.getSlides().get_Item(1).getSlideShowTransition();
        transition.setType(slides.TransitionType.Morph);
        const transitionValue = transition.getValue();

        if (java.instanceOf(transitionValue, "com.aspose.slides.IMorphTransition")) {
            transitionValue.setMorphType(slides.TransitionMorphType.ByWord);
            presentation.save("morph-by-word.pptx", slides.SaveFormat.Pptx);
        } else {
            console.log("Morph transition options are unavailable.");
        }
    } else {
        console.log("The input presentation must contain at least two slides.");
    }
} finally {
    presentation.dispose();
}
```

## **Définir les effets de transition**

Certaines transitions exposent des options supplémentaires, telles que la direction ou si l’effet débute à partir d’un écran noir. Les options disponibles dépendent de la transition sélectionnée avec [setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setType). Définissez d’abord le type, puis utilisez l’objet de transition approprié obtenu via [getValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getValue).

L’exemple suivant applique une transition Cut à la première diapositive de `input.pptx`. Il appelle [setFromBlack](https://reference.aspose.com/slides/nodejs-java/aspose.slides/optionalblacktransition/#setFromBlack) via [OptionalBlackTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/optionalblacktransition/) afin que la transition démarre depuis un écran noir.

```javascript
const java = require("java");
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    const transition = presentation.getSlides().get_Item(0).getSlideShowTransition();
    transition.setType(slides.TransitionType.Cut);
    const transitionValue = transition.getValue();

    if (java.instanceOf(transitionValue, "com.aspose.slides.IOptionalBlackTransition")) {
        transitionValue.setFromBlack(true);
        presentation.save("cut-from-black.pptx", slides.SaveFormat.Pptx);
    } else {
        console.log("Cut transition options are unavailable.");
    }
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Puis‑je contrôler la vitesse de lecture d’une transition de diapositive ?**

Oui. Privilégiez [setDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setDuration) lorsque vous avez besoin d’une durée d’effet exacte en millisecondes. Utilisez [setSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setSpeed) lorsque la catégorie prédefinie [TransitionSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitionspeed/) — Slow, Medium ou Fast — est suffisante et qu’aucune durée explicite n’est définie. Ces paramètres contrôlent l’effet de transition indépendamment du délai d’avancement automatique.

**Puis‑je attacher un son à une transition et le faire boucler ?**

Oui. Affectez le son incorporé avec [setSound](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setSound), passez StartSound depuis l’énumération [TransitionSoundMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitionsoundmode/) à [setSoundMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setSoundMode), et activez [setSoundLoop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setSoundLoop) avec `true`. Le son se répète jusqu’au prochain événement sonore du diaporama.

**Quelle est la façon la plus rapide d’appliquer la même transition à chaque diapositive ?**

Parcourez la collection [getSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getSlides) de la présentation et appelez [setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setType) avec la même valeur pour la transition de chaque diapositive. Définissez les options de minutage et d’effet dans la même boucle afin de garder le comportement cohérent sur toutes les diapositives.

**Comment puis‑je vérifier quelle transition est actuellement définie sur une diapositive ?**

Appelez [getType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getType) sur le résultat de [getSlideShowTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getSlideShowTransition) de la diapositive. Elle renvoie une valeur de l’énumération [TransitionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitiontype/) ; None signifie qu’aucun effet de transition n’est appliqué.