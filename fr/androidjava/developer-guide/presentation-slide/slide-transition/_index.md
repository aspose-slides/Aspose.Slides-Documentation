---
title: Gestion des transitions de diapositives dans les présentations sur Android
linktitle: Transition de diapositive
type: docs
weight: 80
url: /fr/androidjava/slide-transition/
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
- Android
- Java
- Aspose.Slides
description: "Appliquer des transitions de diapositives, configurer l’avancement automatique des diapositives et personnaliser les effets Morph et autres effets de transition avec Aspose.Slides for Android via Java."
---
## **Vue d'ensemble**

Les transitions de diapositive contrôlent la façon dont les diapositives apparaissent pendant un diaporama. Avec Aspose.Slides for Android via Java, vous pouvez choisir un effet de transition pour chaque diapositive, configurer l’avancement par clic de souris ou par minuteur, et ajuster les options spécifiques à un effet. Cet article utilise des exemples Java pour appliquer des transitions, définir des durées de transition exactes, gérer le minutage des diapositives et créer une transition Morph entre deux diapositives. Les exemples montrent également comment enregistrer les paramètres dans un fichier PPTX.

## **Ajouter une transition de diapositive**

Pour appliquer une transition, chargez une présentation avec la classe [Presentation](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentation/) et accédez aux paramètres de transition de la diapositive via [getSlideShowTransition](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ibaseslide/#getSlideShowTransition--). Utilisez [setType](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/islideshowtransition/#setType-int-) avec une valeur de l’énumération [TransitionType](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/transitiontype/), puis enregistrez la présentation.

L’exemple suivant applique une transition Circle à la première diapositive et une transition Comb à la seconde. Utilisez un fichier `input.pptx` contenant au moins deux diapositives.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    if (presentation.getSlides().size() >= 2) {
        presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);
        presentation.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);

        presentation.save("slide-transitions.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("The input presentation must contain at least two slides.");
    }
} finally {
    presentation.dispose();
}
```

## **Ajouter une transition de diapositive avancée**

Vous pouvez configurer la durée pendant laquelle une diapositive reste à l’écran et déterminer si un clic de souris fait avancer le diaporama. Les méthodes suivantes contrôlent ce comportement :

- [setAdvanceOnClick](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceOnClick-boolean-) permet à l’utilisateur d’avancer en cliquant avec la souris.
- [setAdvanceAfter](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceAfter-boolean-) active l’avancement automatique.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceAfterTime-long-) spécifie le délai avant l’avancement automatique, en millisecondes.

Activez à la fois l’avancement par clic et par minuteur pour laisser le spectateur avancer avec un clic ou attendre le minuteur. Pour n’utiliser que le minuteur, passez `false` à [setAdvanceOnClick](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceOnClick-boolean-). Le délai contrôle le moment où le diaporama avance ; il ne définit pas la durée de l’effet visuel de transition.

Cet exemple attribue différents effets aux trois premières diapositives et active l’avancement automatique après 3, 5 et 7 secondes, respectivement. Les clics de souris peuvent également faire avancer ces diapositives. Utilisez un fichier `input.pptx` contenant au moins trois diapositives.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    if (presentation.getSlides().size() >= 3) {
        ISlideShowTransition firstTransition = presentation.getSlides().get_Item(0).getSlideShowTransition();
        firstTransition.setType(TransitionType.Circle);
        firstTransition.setAdvanceOnClick(true);
        firstTransition.setAdvanceAfter(true);
        firstTransition.setAdvanceAfterTime(3000);

        ISlideShowTransition secondTransition = presentation.getSlides().get_Item(1).getSlideShowTransition();
        secondTransition.setType(TransitionType.Comb);
        secondTransition.setAdvanceOnClick(true);
        secondTransition.setAdvanceAfter(true);
        secondTransition.setAdvanceAfterTime(5000);

        ISlideShowTransition thirdTransition = presentation.getSlides().get_Item(2).getSlideShowTransition();
        thirdTransition.setType(TransitionType.Zoom);
        thirdTransition.setAdvanceOnClick(true);
        thirdTransition.setAdvanceAfter(true);
        thirdTransition.setAdvanceAfterTime(7000);

        presentation.save("advanced-transitions.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("The input presentation must contain at least three slides.");
    }
} finally {
    presentation.dispose();
}
```

Pour vérifier si l’avancement chronométré est activé, appelez [getAdvanceAfter](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/islideshowtransition/#getAdvanceAfter--). Un délai stocké à lui seul n’indique pas que le minuteur est actif.

L’exemple suivant ouvre le fichier enregistré ci‑dessus, signale chaque minuteur activé, et désactive l’avancement automatique pour les diapositives dont le délai dépasse deux secondes. Il active les clics de souris pour ces diapositives et enregistre les paramètres mis à jour.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("advanced-transitions.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        ISlideShowTransition transition = slide.getSlideShowTransition();

        if (transition.getAdvanceAfter()) {
            System.out.println("Slide " + slide.getSlideNumber() + ": advance after " + transition.getAdvanceAfterTime() + " ms.");

            if (transition.getAdvanceAfterTime() > 2000) {
                transition.setAdvanceAfter(false);
                transition.setAdvanceOnClick(true);
            }
        }
    }

    presentation.save("adjusted-transitions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Contrôler précisément le timing des transitions**

Utilisez [setDuration](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/islideshowtransition/#setDuration-int-) pour spécifier la longueur exacte d’un effet de transition en millisecondes. La méthode [getSlideShowTransition](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ibaseslide/#getSlideShowTransition--) de la diapositive expose ces paramètres via [ISlideShowTransition](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/islideshowtransition/) :

| Méthode | Objectif |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/islideshowtransition/#setDuration-int-) | Détermine la durée de l’effet de transition lui‑même, en millisecondes. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceAfterTime-long-) | Définit le délai avant que la diapositive avance automatiquement, en millisecondes. Passez `true` à [setAdvanceAfter](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceAfter-boolean-) pour activer ce minuteur. |
| [setSpeed](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/islideshowtransition/#setSpeed-int-) | Sélectionne une catégorie de vitesse prédéfinie dans [TransitionSpeed](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/transitionspeed/) : Slow, Medium ou Fast. Elle est utilisée lorsqu’aucune durée exacte n’est spécifiée. |

[setDuration](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/islideshowtransition/#setDuration-int-) ne contrôle que l’effet de transition ; il ne détermine pas la durée pendant laquelle la diapositive reste visible. Configurez le délai d’avancement automatique séparément. Lorsqu’aucune durée explicite n’est définie, Aspose.Slides détermine la durée de l’effet à partir du type de transition et de la valeur [getSpeed](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/islideshowtransition/#getSpeed--) .

### **Appliquer la même durée à chaque diapositive**

Pour un rythme cohérent, appliquez le même effet et la même durée exacte à chaque diapositive. Cet exemple charge `input.pptx`, sélectionne Fade dans [TransitionType](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/transitiontype/), et attribue à chaque transition une durée de 750 millisecondes. Il active séparément l’avancement automatique après 5 000 millisecondes et désactive l’avancement par clic de souris, puis enregistre le résultat au format PPTX.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        ISlideShowTransition transition = slide.getSlideShowTransition();
        transition.setType(TransitionType.Fade);
        transition.setDuration(750);

        // Configurer l'avancement automatique indépendamment de la durée de l'effet.
        transition.setAdvanceAfter(true);
        transition.setAdvanceAfterTime(5000);
        transition.setAdvanceOnClick(false);
    }

    presentation.save("precise-transitions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Définir des durées différentes pour chaque diapositive**

Des diapositives distinctes peuvent utiliser des durées d’effet différentes. Par exemple, utilisez une transition brève pour une diapositive titre et une transition plus longue pour une introduction de section. Cet exemple fixe 500 millisecondes pour la première diapositive et 1 200 millisecondes pour la seconde. Utilisez un fichier `input.pptx` contenant au moins deux diapositives.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    if (presentation.getSlides().size() >= 2) {
        ISlideShowTransition firstTransition = presentation.getSlides().get_Item(0).getSlideShowTransition();
        firstTransition.setType(TransitionType.Fade);
        firstTransition.setDuration(500);

        ISlideShowTransition secondTransition = presentation.getSlides().get_Item(1).getSlideShowTransition();
        secondTransition.setType(TransitionType.Push);
        secondTransition.setDuration(1200);

        presentation.save("individual-transition-durations.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("The input presentation must contain at least two slides.");
    }
} finally {
    presentation.dispose();
}
```

### **Coordonner les transitions avec la sortie animée**

Lors de la préparation d’un [GIF animé](/slides/fr/androidjava/convert-powerpoint-to-animated-gif/), d’une [présentation HTML5](/slides/fr/androidjava/export-to-html5/) ou d’une [vidéo](/slides/fr/androidjava/convert-powerpoint-to-video/), définissez des durées de transition exactes avant l’exportation afin d’obtenir le tempo souhaité. Par exemple, utilisez un fondu de 600 millisecondes entre les scènes, et ajustez séparément le délai d’avancement de chaque diapositive pour laisser le temps à la narration ou au contenu.

Pour les GIF et les vidéos, synchronisez la fréquence d’images de sortie avec la durée de l’effet : 600 millisecondes correspondent à 18 images à 30 images par seconde. En HTML5, activez les transitions animées dans les paramètres d’exportation. Vérifiez les effets et options de temporisation pris en charge par le format d’exportation choisi, et prévisualisez le résultat pour confirmer la synchronisation.

### **Lire la durée d’une transition existante**

Appelez [getDuration](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/islideshowtransition/#getDuration--) avant de modifier la transition afin de savoir si une valeur explicite est stockée. Une valeur de `-1` signifie qu’aucune durée explicite n’est définie ; une valeur non négative indique la durée stockée en millisecondes. Cette valeur non définie n’est pas la durée de lecture calculée : Aspose.Slides utilise le type de transition et la valeur [getSpeed](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/islideshowtransition/#getSpeed--) pour déterminer cette durée. La définition d’un type de transition peut initialiser une durée, il est donc conseillé d’inspecter les paramètres d’origine d’abord.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        ISlideShowTransition transition = slide.getSlideShowTransition();
        int duration = transition.getDuration();

        if (duration >= 0) {
            System.out.println("Slide " + slide.getSlideNumber() + ": stored transition duration is " + duration + " ms.");
        } else {
            System.out.println("Slide " + slide.getSlideNumber() + ": no explicit duration; timing depends on transition type " + transition.getType() + " and speed " + transition.getSpeed() + ".");
        }
    }
} finally {
    presentation.dispose();
}
```

## **Transition Morph**

La transition Morph anime les changements entre les objets de diapositives consécutives. Pour créer un effet Morph simple, clonez une diapositive, déplacez ou redimensionnez un objet sur le clone, puis appliquez la transition Morph à la deuxième diapositive. Cela fournit aux objets correspondants une animation entre leurs états d’origine et modifiés.

L’exemple suivant crée une diapositive contenant un rectangle de texte, clone la diapositive, puis modifie la position et la taille du rectangle sur le clone. Il sélectionne ensuite Morph dans l’énumération [TransitionType](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/transitiontype/) pour la deuxième diapositive. Ouvrez le fichier enregistré dans un visualiseur de présentations qui prend en charge Morph pour voir l’effet pendant le diaporama.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);
    IAutoShape rectangle = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 100);
    rectangle.getTextFrame().setText("Morph transition");

    ISlide secondSlide = presentation.getSlides().addClone(firstSlide);
    IShape movedRectangle = secondSlide.getShapes().get_Item(0);
    movedRectangle.setX(movedRectangle.getX() + 100);
    movedRectangle.setY(movedRectangle.getY() + 50);
    movedRectangle.setWidth(movedRectangle.getWidth() - 200);
    movedRectangle.setHeight(movedRectangle.getHeight() - 10);

    secondSlide.getSlideShowTransition().setType(TransitionType.Morph);

    presentation.save("morph-transition.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Types de transition Morph**

L’énumération [TransitionMorphType](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/transitionmorphtype/) détermine comment Morph associe et anime le contenu :

- [ByObject](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/transitionmorphtype/#ByObject) traite chaque forme comme un objet complet.
- [ByWord](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/transitionmorphtype/#ByWord) anime le texte en associant les mots lorsque c’est possible.
- [ByChar](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/transitionmorphtype/#ByChar) anime le texte en associant les caractères lorsque c’est possible.

Utilisez [setType](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/islideshowtransition/#setType-int-) pour sélectionner Morph avant d’accéder à [getValue](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/islideshowtransition/#getValue--). La valeur renvoie ensuite l’interface [IMorphTransition](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/imorphtransition/), dont la méthode [setMorphType](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/imorphtransition/#setMorphType-int-) choisit le mode d’appariement.

Cet exemple ouvre la présentation créée dans la section précédente et configure la deuxième diapositive pour utiliser une animation Morph basée sur les mots.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("morph-transition.pptx");
try {
    if (presentation.getSlides().size() >= 2) {
        ISlideShowTransition transition = presentation.getSlides().get_Item(1).getSlideShowTransition();
        transition.setType(TransitionType.Morph);
        ITransitionValueBase transitionValue = transition.getValue();

        if (transitionValue instanceof IMorphTransition) {
            IMorphTransition morphTransition = (IMorphTransition) transitionValue;
            morphTransition.setMorphType(TransitionMorphType.ByWord);
            presentation.save("morph-by-word.pptx", SaveFormat.Pptx);
        } else {
            System.out.println("Morph transition options are unavailable.");
        }
    } else {
        System.out.println("The input presentation must contain at least two slides.");
    }
} finally {
    presentation.dispose();
}
```

## **Définir les effets de transition**

Certaines transitions exposent des options supplémentaires, comme la direction ou le fait que l’effet démarre à partir d’un écran noir. Les options disponibles dépendent de la transition sélectionnée avec [setType](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/islideshowtransition/#setType-int-). Définissez d’abord le type, puis utilisez l’interface appropriée obtenue via [getValue](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/islideshowtransition/#getValue--).

L’exemple suivant applique une transition Cut à la première diapositive de `input.pptx`. Il appelle [setFromBlack](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ioptionalblacktransition/#setFromBlack-boolean-) via [IOptionalBlackTransition](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ioptionalblacktransition/) afin que la transition commence à partir d’un écran noir.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlideShowTransition transition = presentation.getSlides().get_Item(0).getSlideShowTransition();
    transition.setType(TransitionType.Cut);
    ITransitionValueBase transitionValue = transition.getValue();

    if (transitionValue instanceof IOptionalBlackTransition) {
        IOptionalBlackTransition cutTransition = (IOptionalBlackTransition) transitionValue;
        cutTransition.setFromBlack(true);
        presentation.save("cut-from-black.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("Cut transition options are unavailable.");
    }
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Puis‑je contrôler la vitesse de lecture d’une transition de diapositive ?**

Oui. Privilégiez [setDuration](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/islideshowtransition/#setDuration-int-) lorsque vous avez besoin d’une durée d’effet exacte en millisecondes. Utilisez [setSpeed](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/islideshowtransition/#setSpeed-int-) lorsqu’une catégorie prédéfinie de [TransitionSpeed](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/transitionspeed/) — Slow, Medium ou Fast — suffit et qu’aucune durée explicite n’est définie. Ces paramètres contrôlent l’effet de transition indépendamment du délai d’avancement automatique.

**Puis‑je attacher un son à une transition et le faire boucler ?**

Oui. Assignez un son intégré avec [setSound](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/islideshowtransition/#setSound-com.aspose.slides.IAudio-), passez `StartSound` de l’énumération [TransitionSoundMode](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/transitionsoundmode/) à [setSoundMode](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/islideshowtransition/#setSoundMode-int-), et activez [setSoundLoop](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/islideshowtransition/#setSoundLoop-boolean-) avec `true`. Le son boucle jusqu’à l’événement sonore suivant du diaporama.

**Quelle est la façon la plus rapide d’appliquer la même transition à toutes les diapositives ?**

Parcourez la collection [getSlides](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentation/#getSlides--) de la présentation et appelez [setType](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/islideshowtransition/#setType-int-) avec la même valeur pour chaque transition de diapositive. Définissez les options de temporisation et d’effet dans la même boucle afin de conserver un comportement cohérent sur toutes les diapositives.

**Comment puis‑je vérifier quelle transition est actuellement définie sur une diapositive ?**

Appelez [getType](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/islideshowtransition/#getType--) sur le résultat de [getSlideShowTransition](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ibaseslide/#getSlideShowTransition--) de la diapositive. Cette méthode renvoie une valeur de l’énumération [TransitionType](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/transitiontype/) ; `None` signifie qu’aucun effet de transition n’est appliqué.