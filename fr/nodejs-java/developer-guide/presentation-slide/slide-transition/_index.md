---
title: Gérer les transitions de diapositives dans les présentations avec JavaScript
linktitle: Transition de diapositive
type: docs
weight: 80
url: /fr/nodejs-java/slide-transition/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Appliquer des transitions de diapositives, configurer l'avancement automatique des diapositives et personnaliser les effets Morph et autres effets de transition avec Aspose.Slides pour Node.js via Java."
---
## **Vue d'ensemble**

Les transitions de diapositive contrôlent la façon dont les diapositives apparaissent pendant un diaporama. Avec Aspose.Slides pour Node.js via Java, vous pouvez choisir un effet de transition pour chaque diapositive, configurer l'avance par clic de souris ou par minuterie, et ajuster les options spécifiques à un effet. Cet article utilise des exemples JavaScript pour appliquer des transitions, définir des durées de transition précises, gérer le chronométrage des diapositives et créer une transition Morph entre deux diapositives. Les exemples montrent également comment enregistrer les paramètres dans un fichier PPTX.

## **Ajouter une transition de diapositive**

Pour appliquer une transition, chargez une présentation avec la classe [Presentation](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/) et accédez aux paramètres de transition de la diapositive via [getSlideShowTransition](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/baseslide/#getSlideShowTransition). Utilisez [setType](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/slideshowtransition/#setType) avec une valeur de l'énumération [TransitionType](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/transitiontype/), puis enregistrez la présentation.

L'exemple suivant applique une transition Circle à la première diapositive et une transition Comb à la deuxième. Utilisez un fichier `input.pptx` contenant au moins deux diapositives.

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

## **Ajouter une transition de diapositive avancée**

Vous pouvez configurer la durée pendant laquelle une diapositive reste à l'écran et si un clic de souris fait avancer le diaporama. Les méthodes suivantes contrôlent ce comportement :

- [setAdvanceOnClick](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) permet au spectateur d'avancer en cliquant la souris.
- [setAdvanceAfter](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfter) active l'avancement automatique.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) spécifie le délai avant l'avancement automatique, en millisecondes.

Activez à la fois l'avancement par clic et le minuteur pour que le spectateur puisse passer à la diapositive soit en cliquant, soit en attendant le minuteur. Pour n'utiliser que le minuteur, transmettez `false` à [setAdvanceOnClick](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceOnClick). Le délai contrôle le moment où le diaporama avance ; il ne définit pas la durée de l'effet visuel de transition.

Cet exemple attribue différents effets aux trois premières diapositives et active l'avancement automatique après 3, 5 et 7 secondes respectivement. Les clics de souris peuvent également faire avancer ces diapositives. Utilisez un fichier `input.pptx` contenant au moins trois diapositives.

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

Pour vérifier si l'avancement chronométré est activé, appelez [getAdvanceAfter](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/slideshowtransition/#getAdvanceAfter). Un délai stocké seul n'indique pas que le minuteur est actif.

L'exemple suivant ouvre le fichier enregistré ci‑dessus, indique chaque minuteur activé, puis désactive l'avancement automatique pour les diapositives dont le délai dépasse deux secondes. Il active les clics de souris pour ces diapositives et enregistre les paramètres mis à jour.

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

## **Contrôler précisément le chronométrage des transitions**

Utilisez [setDuration](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/slideshowtransition/#setDuration) pour spécifier la longueur exacte d'un effet de transition en millisecondes. La méthode [getSlideShowTransition](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/baseslide/#getSlideShowTransition) de la diapositive expose ces paramètres via [SlideShowTransition](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/slideshowtransition/) :

| Méthode | But |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/slideshowtransition/#setDuration) | Définit la durée de l'effet de transition lui‑même, en millisecondes. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) | Définit le délai avant que la diapositive avance automatiquement, en millisecondes. Passez `true` à [setAdvanceAfter](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfter) pour activer ce minuteur. |
| [setSpeed](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/slideshowtransition/#setSpeed) | Sélectionne une catégorie de vitesse prédéfinie dans [TransitionSpeed](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/transitionspeed/) : Slow, Medium ou Fast. Elle est utilisée lorsqu'aucune durée exacte n'est spécifiée. |

[setDuration] contrôle uniquement l'effet de transition ; il ne détermine pas la durée pendant laquelle la diapositive reste visible. Configurez le délai d'avancement automatique séparément. Lorsqu'aucune durée explicite n'est définie, Aspose.Slides détermine la durée de l'effet à partir du type de transition et de la valeur de [getSpeed].

### **Appliquer la même durée à chaque diapositive**

Pour un rythme cohérent, appliquez le même effet et la même durée exacte à chaque diapositive. Cet exemple charge `input.pptx`, sélectionne Fade dans [TransitionType](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/transitiontype/), et attribue à chaque transition une durée de 750 millisecondes. Il active séparément l'avancement automatique après 5 000 millisecondes et désactive l'avancement par clic de souris, puis enregistre le résultat au format PPTX.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        const slide = presentation.getSlides().get_Item(i);
        const transition = slide.getSlideShowTransition();
        transition.setType(slides.TransitionType.Fade);
        transition.setDuration(750);

        // Configurer l'avance automatique indépendamment de la durée de l'effet.
        transition.setAdvanceAfter(true);
        transition.setAdvanceAfterTime(5000);
        transition.setAdvanceOnClick(false);
    }

    presentation.save("precise-transitions.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Définir des durées différentes pour chaque diapositive**

Des diapositives différentes peuvent utiliser des durées d'effet différentes. Par exemple, utilisez une transition brève pour une diapositive de titre et une transition plus longue pour une introduction de section. Cet exemple fixe 500 millisecondes pour la première diapositive et 1 200 millisecondes pour la deuxième. Utilisez un fichier `input.pptx` contenant au moins deux diapositives.

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

### **Coordonner les transitions avec la sortie animée**

Lors de la préparation d'un [animated GIF](/slides/fr/nodejs-java/convert-powerpoint-to-animated-gif/), d'une [HTML5 presentation](/slides/fr/nodejs-java/export-to-html5/), ou d'une [video](/slides/fr/nodejs-java/convert-powerpoint-to-video/), définissez des durées de transition exactes avant l'exportation afin de correspondre au rythme prévu. Par exemple, utilisez un fondu de 600 millisecondes entre les scènes et ajustez séparément le délai d'avancement de chaque diapositive pour laisser le temps à la narration ou au contenu.

Pour les GIF et les vidéos, coordonnez le taux d'images de sortie avec la durée de l'effet : 600 millisecondes correspondent à 18 images à 30 images par seconde. En HTML5, activez les transitions animées dans les paramètres d'exportation. Vérifiez les effets et options de chronométrage pris en charge par le format d'export choisi, et prévisualisez la sortie pour confirmer la synchronisation.

### **Lire la durée d'une transition existante**

Appelez [getDuration](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/slideshowtransition/#getDuration) avant de modifier la transition pour déterminer si une valeur explicite est stockée. Une valeur de `-1` signifie qu'aucune durée explicite n'est définie ; une valeur non négative indique la durée stockée en millisecondes. La valeur non définie n'est pas la durée de lecture calculée : Aspose.Slides utilise le type de transition et la valeur de [getSpeed] pour déterminer cette durée. La définition d'un type de transition peut initialiser une durée, il vaut donc mieux inspecter d'abord les paramètres d'origine.

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

La transition Morph anime les changements entre objets sur des diapositives consécutives. Pour créer un effet Morph simple, clonez une diapositive, déplacez ou redimensionnez un objet sur le clone, puis appliquez la transition Morph à la deuxième diapositive. Cela fournit à la transition les objets correspondants à animer entre leurs états d'origine et modifié.

L'exemple suivant crée une diapositive contenant un rectangle de texte, clone la diapositive et modifie la position et la taille du rectangle sur le clone. Il sélectionne ensuite Morph dans l'énumération [TransitionType](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/transitiontype/) pour la deuxième diapositive. Ouvrez le fichier enregistré dans un visualiseur de présentation qui prend en charge Morph pour voir l'effet pendant un diaporama.

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

L'énumération [TransitionMorphType](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/transitionmorphtype/) contrôle la façon dont Morph fait correspondre et animer le contenu :

- [ByObject](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/transitionmorphtype/#ByObject) traite chaque forme comme un objet complet.
- [ByWord](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/transitionmorphtype/#ByWord) anime le texte en associant les mots lorsque cela est possible.
- [ByChar](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/transitionmorphtype/#ByChar) anime le texte en associant les caractères lorsque cela est possible.

Utilisez [setType](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/slideshowtransition/#setType) pour sélectionner Morph avant d'accéder à [getValue](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/slideshowtransition/#getValue). La valeur renvoie alors un objet [MorphTransition](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/morphtransition/), dont la méthode [setMorphType](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/morphtransition/#setMorphType) sélectionne le mode de correspondance.

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

Certaines transitions exposent des options supplémentaires, comme la direction ou le fait que l'effet commence à partir d'un écran noir. Les options disponibles dépendent de la transition sélectionnée avec [setType](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/slideshowtransition/#setType). Définissez d'abord le type, puis utilisez l'objet de transition approprié obtenu via [getValue](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/slideshowtransition/#getValue).

L'exemple suivant applique une transition Cut à la première diapositive de `input.pptx`. Il appelle [setFromBlack](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/optionalblacktransition/#setFromBlack) via [OptionalBlackTransition](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/optionalblacktransition/) afin que la transition commence à partir d'un écran noir.

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

**Puis-je contrôler la vitesse de lecture d'une transition de diapositive ?**

Oui. Privilégiez [setDuration](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/slideshowtransition/#setDuration) lorsque vous avez besoin d'une durée d'effet exacte en millisecondes. Utilisez [setSpeed](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/slideshowtransition/#setSpeed) lorsque une catégorie prédéfinie de [TransitionSpeed](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/transitionspeed/) — Slow, Medium ou Fast — est suffisante et qu'aucune durée explicite n'est définie. Ces réglages contrôlent l'effet de transition indépendamment du délai d'avancement automatique.

**Puis-je attacher un audio à une transition et le faire boucler ?**

Oui. Assignez un audio intégré avec [setSound](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/slideshowtransition/#setSound), transmettez `StartSound` de l'énumération [TransitionSoundMode](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/transitionsoundmode/) à [setSoundMode](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/slideshowtransition/#setSoundMode), et activez [setSoundLoop](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/slideshowtransition/#setSoundLoop) avec `true`. L'audio se répète jusqu'au prochain événement sonore du diaporama.

**Quelle est la manière la plus rapide d'appliquer la même transition à chaque diapositive ?**

Parcourez la collection [getSlides](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/#getSlides) de la présentation et appelez [setType](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/slideshowtransition/#setType) avec la même valeur pour la transition de chaque diapositive. Définissez les options de timing et d'effet dans la même boucle pour conserver un comportement cohérent entre les diapositives.

**Comment puis‑je vérifier quelle transition est actuellement définie sur une diapositive ?**

Appelez [getType](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/slideshowtransition/#getType) sur le résultat de [getSlideShowTransition](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/baseslide/#getSlideShowTransition) de la diapositive. Elle renvoie une valeur de l'énumération [TransitionType](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/transitiontype/) ; None indique qu'aucun effet de transition n'est appliqué.