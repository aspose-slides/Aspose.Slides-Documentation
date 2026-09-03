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
- transition Morph
- type de transition
- effet de transition
- PowerPoint
- OpenDocument
- présentation
- PHP
- Aspose.Slides
description: "Appliquer des transitions de diapositives, configurer l'avancement automatique des diapositives et personnaliser Morph ainsi que d'autres effets de transition avec Aspose.Slides pour PHP via Java."
---
## **Vue d'ensemble**

Les transitions de diapositives contrôlent la façon dont les diapositives apparaissent pendant un diaporama. Avec Aspose.Slides pour PHP via Java, vous pouvez choisir un effet de transition pour chaque diapositive, configurer l’avancement par clic de souris ou par minuteur, et ajuster les options spécifiques à un effet. Cet article utilise des exemples PHP pour appliquer des transitions, définir des durées de transition précises, gérer le chronométrage des diapositives et créer une transition Morph entre deux diapositives. Les exemples montrent également comment enregistrer les paramètres dans un fichier PPTX.

## **Ajouter une transition de diapositive**

Pour appliquer une transition, chargez une présentation avec la classe [Presentation](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/) et accédez aux paramètres de transition de la diapositive via [getSlideShowTransition](https://reference.aspose.com/slides/fr/php-java/aspose.slides/baseslide/#getSlideShowTransition). Utilisez [setType](https://reference.aspose.com/slides/fr/php-java/aspose.slides/slideshowtransition/#setType) avec une valeur de l'énumération [TransitionType](https://reference.aspose.com/slides/fr/php-java/aspose.slides/transitiontype/), puis enregistrez la présentation.

L'exemple suivant applique une transition Circle à la première diapositive et une transition Comb à la deuxième. Utilisez un fichier `input.pptx` contenant au moins deux diapositives.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TransitionType;

$presentation = new Presentation("input.pptx");
try {
    if (java_values($presentation->getSlides()->size()) >= 2) {
        $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->setType(TransitionType::Circle);
        $presentation->getSlides()->get_Item(1)->getSlideShowTransition()->setType(TransitionType::Comb);

        $presentation->save("slide-transitions.pptx", SaveFormat::Pptx);
    } else {
        echo "The input presentation must contain at least two slides." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **Ajouter une transition de diapositive avancée**

Vous pouvez configurer la durée d'affichage d'une diapositive et si un clic de souris fait avancer le diaporama. Les méthodes suivantes contrôlent ce comportement :

- [setAdvanceOnClick](https://reference.aspose.com/slides/fr/php-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) permet au spectateur d'avancer en cliquant avec la souris.
- [setAdvanceAfter](https://reference.aspose.com/slides/fr/php-java/aspose.slides/slideshowtransition/#setAdvanceAfter) active l'avancement automatique.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/fr/php-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) spécifie le délai avant l'avancement automatique, en millisecondes.

Activez à la fois l'avancement par clic et le chronométrage pour permettre au spectateur de passer à la diapositive suivante en cliquant ou d'attendre le minuteur. Pour n'utiliser que le minuteur, transmettez `false` à [setAdvanceOnClick](https://reference.aspose.com/slides/fr/php-java/aspose.slides/slideshowtransition/#setAdvanceOnClick). Le délai contrôle le moment où le diaporama avance ; il ne définit pas la durée de l'effet de transition visuel.

Cet exemple attribue des effets différents aux trois premières diapositives et active l'avancement automatique après 3, 5 et 7 secondes, respectivement. Les clics de souris peuvent également faire avancer ces diapositives. Utilisez un fichier `input.pptx` contenant au moins trois diapositives.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TransitionType;

$presentation = new Presentation("input.pptx");
try {
    if (java_values($presentation->getSlides()->size()) >= 3) {
        $firstTransition = $presentation->getSlides()->get_Item(0)->getSlideShowTransition();
        $firstTransition->setType(TransitionType::Circle);
        $firstTransition->setAdvanceOnClick(true);
        $firstTransition->setAdvanceAfter(true);
        $firstTransition->setAdvanceAfterTime(3000);

        $secondTransition = $presentation->getSlides()->get_Item(1)->getSlideShowTransition();
        $secondTransition->setType(TransitionType::Comb);
        $secondTransition->setAdvanceOnClick(true);
        $secondTransition->setAdvanceAfter(true);
        $secondTransition->setAdvanceAfterTime(5000);

        $thirdTransition = $presentation->getSlides()->get_Item(2)->getSlideShowTransition();
        $thirdTransition->setType(TransitionType::Zoom);
        $thirdTransition->setAdvanceOnClick(true);
        $thirdTransition->setAdvanceAfter(true);
        $thirdTransition->setAdvanceAfterTime(7000);

        $presentation->save("advanced-transitions.pptx", SaveFormat::Pptx);
    } else {
        echo "The input presentation must contain at least three slides." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

Pour vérifier si l'avancement chronométré est activé, appelez [getAdvanceAfter](https://reference.aspose.com/slides/fr/php-java/aspose.slides/slideshowtransition/#getAdvanceAfter). Un délai stocké seul n'indique pas que le minuteur est actif.

L'exemple suivant ouvre le fichier enregistré ci‑dessus, signale chaque minuteur activé et désactive l'avancement automatique pour les diapositives dont le délai dépasse deux secondes. Il active les clics de souris pour ces diapositives et enregistre les paramètres mis à jour.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("advanced-transitions.pptx");
try {
    for ($slideIndex = 0; $slideIndex < java_values($presentation->getSlides()->size()); $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $transition = $slide->getSlideShowTransition();

        if (java_values($transition->getAdvanceAfter())) {
            echo "Slide " . java_values($slide->getSlideNumber()) . ": advance after " . java_values($transition->getAdvanceAfterTime()) . " ms." . PHP_EOL;

            if (java_values($transition->getAdvanceAfterTime()) > 2000) {
                $transition->setAdvanceAfter(false);
                $transition->setAdvanceOnClick(true);
            }
        }
    }

    $presentation->save("adjusted-transitions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Contrôler précisément le minutage des transitions**

Utilisez [setDuration](https://reference.aspose.com/slides/fr/php-java/aspose.slides/slideshowtransition/#setDuration) pour spécifier la durée exacte d'un effet de transition en millisecondes. La méthode [getSlideShowTransition](https://reference.aspose.com/slides/fr/php-java/aspose.slides/baseslide/#getSlideShowTransition) de la diapositive expose ces paramètres via [SlideShowTransition](https://reference.aspose.com/slides/fr/php-java/aspose.slides/slideshowtransition/) :

| Méthode | Objectif |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/fr/php-java/aspose.slides/slideshowtransition/#setDuration) | Définit la durée de l'effet de transition lui‑même, en millisecondes. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/fr/php-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) | Définit le délai avant que la diapositive avance automatiquement, en millisecondes. Transmettez `true` à [setAdvanceAfter](https://reference.aspose.com/slides/fr/php-java/aspose.slides/slideshowtransition/#setAdvanceAfter) pour activer ce minuteur. |
| [setSpeed](https://reference.aspose.com/slides/fr/php-java/aspose.slides/slideshowtransition/#setSpeed) | Sélectionne une catégorie de vitesse prédéfinie à partir de [TransitionSpeed](https://reference.aspose.com/slides/fr/php-java/aspose.slides/transitionspeed/) : Slow, Medium ou Fast. Elle est utilisée lorsqu'aucune durée exacte n'est spécifiée. |

[setDuration](https://reference.aspose.com/slides/fr/php-java/aspose.slides/slideshowtransition/#setDuration) ne contrôle que l'effet de transition ; il ne détermine pas la durée pendant laquelle la diapositive reste visible. Configurez séparément le délai d'avancement automatique. Lorsqu'aucune durée explicite n'est définie, Aspose.Slides détermine la durée de l'effet à partir du type de transition et de la valeur [getSpeed](https://reference.aspose.com/slides/fr/php-java/aspose.slides/slideshowtransition/#getSpeed).

### **Appliquer la même durée à chaque diapositive**

Pour un rythme cohérent, appliquez le même effet et la même durée exacte à chaque diapositive. Cet exemple charge `input.pptx`, sélectionne Fade dans [TransitionType](https://reference.aspose.com/slides/fr/php-java/aspose.slides/transitiontype/) et attribue à chaque transition une durée de 750 millisecondes. Il active séparément l'avancement automatique après 5 000 millisecondes et désactive l'avancement par clic de souris, puis enregistre le résultat au format PPTX.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TransitionType;

$presentation = new Presentation("input.pptx");
try {
    for ($slideIndex = 0; $slideIndex < java_values($presentation->getSlides()->size()); $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $transition = $slide->getSlideShowTransition();
        $transition->setType(TransitionType::Fade);
        $transition->setDuration(750);

        // Configurer l'avancement automatique indépendamment de la durée de l'effet.
        $transition->setAdvanceAfter(true);
        $transition->setAdvanceAfterTime(5000);
        $transition->setAdvanceOnClick(false);
    }

    $presentation->save("precise-transitions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Définir des durées différentes pour les diapositives individuelles**

Différentes diapositives peuvent utiliser des durées d'effet différentes. Par exemple, utilisez une transition brève pour une diapositive de titre et une transition plus longue pour une introduction de section. Cet exemple définit 500 millisecondes pour la première diapositive et 1 200 millisecondes pour la seconde. Utilisez un fichier `input.pptx` contenant au moins deux diapositives.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TransitionType;

$presentation = new Presentation("input.pptx");
try {
    if (java_values($presentation->getSlides()->size()) >= 2) {
        $firstTransition = $presentation->getSlides()->get_Item(0)->getSlideShowTransition();
        $firstTransition->setType(TransitionType::Fade);
        $firstTransition->setDuration(500);

        $secondTransition = $presentation->getSlides()->get_Item(1)->getSlideShowTransition();
        $secondTransition->setType(TransitionType::Push);
        $secondTransition->setDuration(1200);

        $presentation->save("individual-transition-durations.pptx", SaveFormat::Pptx);
    } else {
        echo "The input presentation must contain at least two slides." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

### **Coordonner les transitions avec la sortie animée**

Lorsque vous préparez un [GIF animé](/slides/fr/php-java/convert-powerpoint-to-animated-gif/), une [présentation HTML5](/slides/fr/php-java/export-to-html5/) ou une [vidéo](/slides/fr/php-java/convert-powerpoint-to-video/), définissez des durées de transition exactes avant l'exportation afin de correspondre au rythme prévu. Par exemple, utilisez un fondu de 600 millisecondes entre les scènes et ajustez séparément le délai d'avancement de chaque diapositive pour laisser le temps à sa narration ou à son contenu.

Pour les GIF et les vidéos, coordonnez le taux d'images de sortie avec la durée de l'effet : 600 millisecondes correspondent à 18 images à 30 images par seconde. En HTML5, activez les transitions animées dans les paramètres d'exportation. Vérifiez les effets et options de timing pris en charge par le format d'exportation choisi, et prévisualisez la sortie pour confirmer la synchronisation.

### **Lire une durée de transition existante**

Appelez [getDuration](https://reference.aspose.com/slides/fr/php-java/aspose.slides/slideshowtransition/#getDuration) avant de modifier la transition pour déterminer si une valeur explicite est stockée. Une valeur de `-1` signifie qu'aucune durée explicite n'est définie ; une valeur non négative indique la durée stockée en millisecondes. La valeur non définie n'est pas la durée de lecture calculée : Aspose.Slides utilise le type de transition et la valeur [getSpeed](https://reference.aspose.com/slides/fr/php-java/aspose.slides/slideshowtransition/#getSpeed) pour déterminer cette durée. La définition d'un type de transition peut initialiser une durée, il convient donc d'examiner d'abord les paramètres d'origine.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    for ($slideIndex = 0; $slideIndex < java_values($presentation->getSlides()->size()); $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $transition = $slide->getSlideShowTransition();
        $duration = java_values($transition->getDuration());

        if ($duration >= 0) {
            echo "Slide " . java_values($slide->getSlideNumber()) . ": stored transition duration is " . $duration . " ms." . PHP_EOL;
        } else {
            echo "Slide " . java_values($slide->getSlideNumber()) . ": no explicit duration; timing depends on transition type " . java_values($transition->getType()) . " and speed " . java_values($transition->getSpeed()) . "." . PHP_EOL;
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Transition Morph**

La transition Morph anime les changements entre les objets sur des diapositives consécutives. Pour créer un effet Morph simple, clonez une diapositive, déplacez ou redimensionnez un objet sur le clone, puis appliquez la transition Morph à la deuxième diapositive. Cela donne à la transition les objets correspondants à animer entre leurs états d'origine et modifiés.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TransitionType;

$presentation = new Presentation();
try {
    $firstSlide = $presentation->getSlides()->get_Item(0);
    $rectangle = $firstSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 400, 100);
    $rectangle->getTextFrame()->setText("Morph transition");

    $secondSlide = $presentation->getSlides()->addClone($firstSlide);
    $movedRectangle = $secondSlide->getShapes()->get_Item(0);
    $movedRectangle->setX(java_values($movedRectangle->getX()) + 100);
    $movedRectangle->setY(java_values($movedRectangle->getY()) + 50);
    $movedRectangle->setWidth(java_values($movedRectangle->getWidth()) - 200);
    $movedRectangle->setHeight(java_values($movedRectangle->getHeight()) - 10);

    $secondSlide->getSlideShowTransition()->setType(TransitionType::Morph);

    $presentation->save("morph-transition.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Types de transition Morph**

L'énumération [TransitionMorphType](https://reference.aspose.com/slides/fr/php-java/aspose.slides/transitionmorphtype/) contrôle la façon dont Morph associe et anime le contenu :

- [ByObject](https://reference.aspose.com/slides/fr/php-java/aspose.slides/transitionmorphtype/#ByObject) traite chaque forme comme un objet complet.
- [ByWord](https://reference.aspose.com/slides/fr/php-java/aspose.slides/transitionmorphtype/#ByWord) anime le texte en associant les mots lorsque c'est possible.
- [ByChar](https://reference.aspose.com/slides/fr/php-java/aspose.slides/transitionmorphtype/#ByChar) anime le texte en associant les caractères lorsque c'est possible.

Utilisez [setType](https://reference.aspose.com/slides/fr/php-java/aspose.slides/slideshowtransition/#setType) pour sélectionner Morph avant d'accéder à [getValue](https://reference.aspose.com/slides/fr/php-java/aspose.slides/slideshowtransition/#getValue). La valeur fournit alors un objet [MorphTransition](https://reference.aspose.com/slides/fr/php-java/aspose.slides/morphtransition/), dont la méthode [setMorphType](https://reference.aspose.com/slides/fr/php-java/aspose.slides/morphtransition/#setMorphType) sélectionne le mode d'association.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TransitionMorphType;
use aspose\slides\TransitionType;

$presentation = new Presentation("morph-transition.pptx");
try {
    if (java_values($presentation->getSlides()->size()) >= 2) {
        $transition = $presentation->getSlides()->get_Item(1)->getSlideShowTransition();
        $transition->setType(TransitionType::Morph);
        $morphTransition = $transition->getValue();

        if (!java_is_null($morphTransition)) {
            $morphTransition->setMorphType(TransitionMorphType::ByWord);
            $presentation->save("morph-by-word.pptx", SaveFormat::Pptx);
        } else {
            echo "Morph transition options are unavailable." . PHP_EOL;
        }
    } else {
        echo "The input presentation must contain at least two slides." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **Définir les effets de transition**

Certaines transitions exposent des options supplémentaires, comme la direction ou si l'effet commence depuis un écran noir. Les options disponibles dépendent de la transition sélectionnée avec [setType](https://reference.aspose.com/slides/fr/php-java/aspose.slides/slideshowtransition/#setType). Définissez d'abord le type, puis utilisez l'objet de transition approprié de [getValue](https://reference.aspose.com/slides/fr/php-java/aspose.slides/slideshowtransition/#getValue).

L'exemple suivant applique une transition Cut à la première diapositive de `input.pptx`. Il appelle [setFromBlack](https://reference.aspose.com/slides/fr/php-java/aspose.slides/optionalblacktransition/#setFromBlack) via [OptionalBlackTransition](https://reference.aspose.com/slides/fr/php-java/aspose.slides/optionalblacktransition/) afin que la transition commence depuis un écran noir.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TransitionType;

$presentation = new Presentation("input.pptx");
try {
    $transition = $presentation->getSlides()->get_Item(0)->getSlideShowTransition();
    $transition->setType(TransitionType::Cut);
    $cutTransition = $transition->getValue();

    if (!java_is_null($cutTransition)) {
        $cutTransition->setFromBlack(true);
        $presentation->save("cut-from-black.pptx", SaveFormat::Pptx);
    } else {
        echo "Cut transition options are unavailable." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Puis-je contrôler la vitesse de lecture d'une transition de diapositive ?**

Oui. Privilégiez [setDuration](https://reference.aspose.com/slides/fr/php-java/aspose.slides/slideshowtransition/#setDuration) lorsque vous avez besoin d'une durée d'effet exacte en millisecondes. Utilisez [setSpeed](https://reference.aspose.com/slides/fr/php-java/aspose.slides/slideshowtransition/#setSpeed) lorsqu'une catégorie prédéfinie de [TransitionSpeed](https://reference.aspose.com/slides/fr/php-java/aspose.slides/transitionspeed/) — Slow, Medium ou Fast — suffit et aucune durée explicite n'est définie. Ces paramètres contrôlent l'effet de transition indépendamment du délai d'avancement automatique.

**Puis-je attacher un audio à une transition et le faire boucler ?**

Oui. Assignez un audio incorporé avec [setSound](https://reference.aspose.com/slides/fr/php-java/aspose.slides/slideshowtransition/#setSound), transmettez StartSound de l'énumération [TransitionSoundMode](https://reference.aspose.com/slides/fr/php-java/aspose.slides/transitionsoundmode/) à [setSoundMode](https://reference.aspose.com/slides/fr/php-java/aspose.slides/slideshowtransition/#setSoundMode), et activez [setSoundLoop](https://reference.aspose.com/slides/fr/php-java/aspose.slides/slideshowtransition/#setSoundLoop) avec `true`. L'audio boucle jusqu'au prochain événement sonore du diaporama.

**Quelle est la façon la plus rapide d'appliquer la même transition à chaque diapositive ?**

Parcourez la collection [getSlides](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/#getSlides) de la présentation et appelez [setType](https://reference.aspose.com/slides/fr/php-java/aspose.slides/slideshowtransition/#setType) avec la même valeur pour chaque transition de diapositive. Définissez les options de timing et d'effet dans la même boucle afin de garder le comportement cohérent sur toutes les diapositives.

**Comment puis‑je vérifier quelle transition est actuellement définie sur une diapositive ?**

Appelez [getType](https://reference.aspose.com/slides/fr/php-java/aspose.slides/slideshowtransition/#getType) sur le résultat de [getSlideShowTransition](https://reference.aspose.com/slides/fr/php-java/aspose.slides/baseslide/#getSlideShowTransition) de la diapositive. Elle renvoie une valeur de l'énumération [TransitionType](https://reference.aspose.com/slides/fr/php-java/aspose.slides/transitiontype/) ; None signifie qu'aucun effet de transition n'est appliqué.