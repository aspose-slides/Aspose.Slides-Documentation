---
title: Gérer les transitions de diapositives dans les présentations avec Python via Java
linktitle: Transition de diapositive
type: docs
weight: 80
url: /fr/python-java/slide-transition/
keywords:
- transition de diapositive
- ajout de transition de diapositive
- application de transition de diapositive
- transition de diapositive avancée
- transition morph
- type de transition
- effet de transition
- PowerPoint
- OpenDocument
- présentation
- Python
- Java
- Aspose.Slides
description: "Appliquer des transitions de diapositives, configurer l'avancement automatique des diapositives et personnaliser les effets Morph et autres effets de transition avec Aspose.Slides for Python via Java."
---
## **Vue d'ensemble**

Les transitions de diapositives contrôlent la façon dont les diapositives apparaissent pendant un diaporama. Avec Aspose.Slides for Python via Java, vous pouvez choisir un effet de transition pour chaque diapositive, configurer l’avancement par clic de souris ou par minuteur, et ajuster les options spécifiques à un effet. Cet article utilise des exemples Python pour appliquer des transitions, définir des durées de transition exactes, gérer le minutage des diapositives et créer une transition Morph entre deux diapositives. Les exemples montrent également comment enregistrer les paramètres dans un fichier PPTX.

## **Ajouter une transition de diapositive**

Pour appliquer une transition, chargez une présentation avec la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/) et accédez aux paramètres de transition de la diapositive via [getSlideShowTransition](https://reference.aspose.com/slides/fr/python-java/aspose.slides/baseslide/#getSlideShowTransition). Utilisez [setType](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slideshowtransition/#setType) avec une valeur de l’énumération [TransitionType](https://reference.aspose.com/slides/fr/python-java/aspose.slides/transitiontype/), puis enregistrez la présentation.

L’exemple suivant applique une transition Circle à la première diapositive et une transition Comb à la seconde. Utilisez un fichier `input.pptx` contenant au moins deux diapositives.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType

presentation = Presentation("input.pptx")
try:
    if presentation.getSlides().size() >= 2:
        presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle)
        presentation.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb)

        presentation.save("slide-transitions.pptx", SaveFormat.Pptx)
    else:
        print("The input presentation must contain at least two slides.")
finally:
    presentation.dispose()
```

## **Ajouter une transition de diapositive avancée**

Vous pouvez configurer la durée pendant laquelle une diapositive reste à l’écran et déterminer si un clic de souris avance le diaporama. Les méthodes suivantes contrôlent ce comportement :

- [setAdvanceOnClick](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) permet au spectateur d’avancer en cliquant avec la souris.
- [setAdvanceAfter](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slideshowtransition/#setAdvanceAfter) active l’avancement automatique.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) spécifie le délai avant l’avancement automatique, en millisecondes.

Activez à la fois l’avancement par clic et par minuteur pour que le spectateur puisse passer à la diapositive suivante soit en cliquant, soit en attendant le minuteur. Pour n’utiliser que le minuteur, transmettez `False` à [setAdvanceOnClick](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slideshowtransition/#setAdvanceOnClick). Le délai contrôle le moment où le diaporama avance ; il ne définit pas la durée de l’effet visuel de transition.

Cet exemple affecte différents effets aux trois premières diapositives et active l’avancement automatique après 3, 5 et 7 secondes respectivement. Les clics de souris peuvent également avancer ces diapositives. Utilisez un fichier `input.pptx` contenant au moins trois diapositives.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType

presentation = Presentation("input.pptx")
try:
    if presentation.getSlides().size() >= 3:
        first_transition = presentation.getSlides().get_Item(0).getSlideShowTransition()
        first_transition.setType(TransitionType.Circle)
        first_transition.setAdvanceOnClick(True)
        first_transition.setAdvanceAfter(True)
        first_transition.setAdvanceAfterTime(3000)

        second_transition = presentation.getSlides().get_Item(1).getSlideShowTransition()
        second_transition.setType(TransitionType.Comb)
        second_transition.setAdvanceOnClick(True)
        second_transition.setAdvanceAfter(True)
        second_transition.setAdvanceAfterTime(5000)

        third_transition = presentation.getSlides().get_Item(2).getSlideShowTransition()
        third_transition.setType(TransitionType.Zoom)
        third_transition.setAdvanceOnClick(True)
        third_transition.setAdvanceAfter(True)
        third_transition.setAdvanceAfterTime(7000)

        presentation.save("advanced-transitions.pptx", SaveFormat.Pptx)
    else:
        print("The input presentation must contain at least three slides.")
finally:
    presentation.dispose()
```

Pour vérifier si l’avancement chronométré est activé, appelez [getAdvanceAfter](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slideshowtransition/#getAdvanceAfter). Un retard stocké seul n’indique pas que le minuteur est actif.

L’exemple suivant ouvre le fichier enregistré ci‑dessus, signale chaque minuteur activé et désactive l’avancement automatique pour les diapositives dont le délai dépasse deux secondes. Il active les clics de souris pour ces diapositives et enregistre les paramètres mis à jour.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("advanced-transitions.pptx")
try:
    for slide in presentation.getSlides():
        transition = slide.getSlideShowTransition()

        if transition.getAdvanceAfter():
            print(f"Slide {slide.getSlideNumber()}: advance after {transition.getAdvanceAfterTime()} ms.")

            if transition.getAdvanceAfterTime() > 2000:
                transition.setAdvanceAfter(False)
                transition.setAdvanceOnClick(True)

    presentation.save("adjusted-transitions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Contrôler précisément le minutage des transitions**

Utilisez [setDuration](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slideshowtransition/#setDuration) pour spécifier la longueur exacte d’un effet de transition en millisecondes. La méthode [getSlideShowTransition](https://reference.aspose.com/slides/fr/python-java/aspose.slides/baseslide/#getSlideShowTransition) de la diapositive expose ces paramètres via la classe [SlideShowTransition](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slideshowtransition/) :

| Méthode | Objectif |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slideshowtransition/#setDuration) | Définit la durée de l’effet de transition lui‑même, en millisecondes. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) | Définit le délai avant que la diapositive avance automatiquement, en millisecondes. Transmettez `True` à [setAdvanceAfter](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slideshowtransition/#setAdvanceAfter) pour activer ce minuteur. |
| [setSpeed](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slideshowtransition/#setSpeed) | Sélectionne une catégorie de vitesse prédéfinie dans [TransitionSpeed](https://reference.aspose.com/slides/fr/python-java/aspose.slides/transitionspeed/) : Slow, Medium ou Fast. Elle est utilisée lorsqu’aucune durée exacte n’est spécifiée. |

[setDuration](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slideshowtransition/#setDuration) contrôle uniquement l’effet de transition ; il ne détermine pas la durée pendant laquelle la diapositive reste visible. Configurez séparément le délai d’avancement automatique. Lorsqu’aucune durée explicite n’est définie, Aspose.Slides détermine la durée de l’effet à partir du type de transition et de la valeur de [getSpeed](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slideshowtransition/#getSpeed).

### **Appliquer la même durée à chaque diapositive**

Pour un rythme homogène, appliquez le même effet et la même durée exacte à chaque diapositive. Cet exemple charge `input.pptx`, sélectionne Fade dans [TransitionType](https://reference.aspose.com/slides/fr/python-java/aspose.slides/transitiontype/) et attribue à chaque transition une durée de 750 millisecondes. Il active séparément l’avancement automatique après 5 000 millisecondes et désactive l’avancement par clic de souris, puis enregistre le résultat au format PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType

presentation = Presentation("input.pptx")
try:
    for slide in presentation.getSlides():
        transition = slide.getSlideShowTransition()
        transition.setType(TransitionType.Fade)
        transition.setDuration(750)

        # Configurer l'avancement automatique indépendamment de la durée de l'effet.
        transition.setAdvanceAfter(True)
        transition.setAdvanceAfterTime(5000)
        transition.setAdvanceOnClick(False)

    presentation.save("precise-transitions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Définir des durées différentes pour des diapositives individuelles**

Des diapositives différentes peuvent utiliser des durées d’effet différentes. Par exemple, utilisez une transition brève pour une diapositive titre et une transition plus longue pour l’introduction d’une section. Cet exemple définit 500 millisecondes pour la première diapositive et 1 200 millisecondes pour la seconde. Utilisez un fichier `input.pptx` contenant au moins deux diapositives.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType

presentation = Presentation("input.pptx")
try:
    if presentation.getSlides().size() >= 2:
        first_transition = presentation.getSlides().get_Item(0).getSlideShowTransition()
        first_transition.setType(TransitionType.Fade)
        first_transition.setDuration(500)

        second_transition = presentation.getSlides().get_Item(1).getSlideShowTransition()
        second_transition.setType(TransitionType.Push)
        second_transition.setDuration(1200)

        presentation.save("individual-transition-durations.pptx", SaveFormat.Pptx)
    else:
        print("The input presentation must contain at least two slides.")
finally:
    presentation.dispose()
```

### **Coordonner les transitions avec une sortie animée**

Lors de la préparation d’un [GIF animé](/slides/fr/python-java/convert-powerpoint-to-animated-gif/), d’une [présentation HTML5](/slides/fr/python-java/export-to-html5/) ou d’une [vidéo](/slides/fr/python-java/convert-powerpoint-to-video/), définissez des durées de transition exactes avant l’exportation pour correspondre au rythme souhaité. Par exemple, utilisez un fondu de 600 millisecondes entre les scènes et ajustez séparément le délai d’avancement de chaque diapositive afin de laisser le temps à la narration ou au contenu.

Pour les GIF et les vidéos, coordonnez le taux d’images de sortie avec la durée de l’effet : 600 millisecondes correspondent à 18 images à 30 images par seconde. En HTML5, activez les transitions animées dans les paramètres d’exportation. Vérifiez les effets et options de minutage pris en charge par le format d’exportation choisi et prévisualisez la sortie pour confirmer la synchronisation.

### **Lire la durée d’une transition existante**

Appelez [getDuration](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slideshowtransition/#getDuration) avant de modifier la transition afin de déterminer si une valeur explicite est stockée. Une valeur de `-1` signifie qu’aucune durée explicite n’est définie ; une valeur non négative indique la durée stockée en millisecondes. La valeur non définie n’est pas la durée de lecture calculée : Aspose.Slides utilise le type de transition et la valeur de [getSpeed](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slideshowtransition/#getSpeed) pour déterminer cette durée. La définition d’un type de transition peut initialiser une durée, il faut donc inspecter les paramètres d’origine d’abord.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("input.pptx")
try:
    for slide in presentation.getSlides():
        transition = slide.getSlideShowTransition()
        duration = transition.getDuration()

        if duration >= 0:
            print(f"Slide {slide.getSlideNumber()}: stored transition duration is {duration} ms.")
        else:
            print(f"Slide {slide.getSlideNumber()}: no explicit duration; timing depends on transition type {transition.getType()} and speed {transition.getSpeed()}.")
finally:
    presentation.dispose()
```

## **Transition Morph**

La transition Morph anime les changements entre les objets sur des diapositives consécutives. Pour créer un effet Morph simple, clonez une diapositive, déplacez ou redimensionnez un objet sur le clone, puis appliquez la transition Morph à la seconde diapositive. Cela fournit aux objets correspondants la possibilité d’animer leur état original et modifié.

L’exemple suivant crée une diapositive contenant un rectangle de texte, clone la diapositive, puis modifie la position et la taille du rectangle sur le clone. Il sélectionne ensuite Morph dans l’énumération [TransitionType](https://reference.aspose.com/slides/fr/python-java/aspose.slides/transitiontype/) pour la seconde diapositive. Ouvrez le fichier enregistré dans un visualiseur de présentations prenant en charge Morph pour voir l’effet pendant le diaporama.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType, ShapeType

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)
    rectangle = first_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 100)
    rectangle.getTextFrame().setText("Morph transition")

    second_slide = presentation.getSlides().addClone(first_slide)
    moved_rectangle = second_slide.getShapes().get_Item(0)
    moved_rectangle.setX(moved_rectangle.getX() + 100)
    moved_rectangle.setY(moved_rectangle.getY() + 50)
    moved_rectangle.setWidth(moved_rectangle.getWidth() - 200)
    moved_rectangle.setHeight(moved_rectangle.getHeight() - 10)

    second_slide.getSlideShowTransition().setType(TransitionType.Morph)

    presentation.save("morph-transition.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Types de transition Morph**

L’énumération [TransitionMorphType](https://reference.aspose.com/slides/fr/python-java/aspose.slides/transitionmorphtype/) contrôle la façon dont Morph associe et anime le contenu :

- [ByObject](https://reference.aspose.com/slides/fr/python-java/aspose.slides/transitionmorphtype/#ByObject) traite chaque forme comme un objet complet.
- [ByWord](https://reference.aspose.com/slides/fr/python-java/aspose.slides/transitionmorphtype/#ByWord) anime le texte en faisant correspondre les mots lorsque cela est possible.
- [ByChar](https://reference.aspose.com/slides/fr/python-java/aspose.slides/transitionmorphtype/#ByChar) anime le texte en faisant correspondre les caractères lorsque cela est possible.

Utilisez [setType](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slideshowtransition/#setType) pour sélectionner Morph avant d’accéder à [getValue](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slideshowtransition/#getValue). La valeur retournée est alors une instance de la classe [MorphTransition](https://reference.aspose.com/slides/fr/python-java/aspose.slides/morphtransition/) dont la méthode [setMorphType](https://reference.aspose.com/slides/fr/python-java/aspose.slides/morphtransition/#setMorphType) sélectionne le mode de correspondance.

Cet exemple ouvre la présentation créée dans la section précédente et configure la seconde diapositive pour utiliser l’animation Morph basée sur les mots.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType, TransitionMorphType, MorphTransition

presentation = Presentation("morph-transition.pptx")
try:
    if presentation.getSlides().size() >= 2:
        transition = presentation.getSlides().get_Item(1).getSlideShowTransition()
        transition.setType(TransitionType.Morph)
        transition_value = transition.getValue()

        if isinstance(transition_value, MorphTransition):
            morph_transition = transition_value
            morph_transition.setMorphType(TransitionMorphType.ByWord)
            presentation.save("morph-by-word.pptx", SaveFormat.Pptx)
        else:
            print("Morph transition options are unavailable.")
    else:
        print("The input presentation must contain at least two slides.")
finally:
    presentation.dispose()
```

## **Définir les effets de transition**

Certaines transitions exposent des options supplémentaires, telles que la direction ou le fait que l’effet commence à partir d’un écran noir. Les options disponibles dépendent de la transition sélectionnée avec [setType](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slideshowtransition/#setType). Définissez d’abord le type, puis utilisez la classe appropriée à partir de [getValue](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slideshowtransition/#getValue).

L’exemple suivant applique une transition Cut à la première diapositive de `input.pptx`. Il appelle [setFromBlack](https://reference.aspose.com/slides/fr/python-java/aspose.slides/optionalblacktransition/#setFromBlack) via [OptionalBlackTransition](https://reference.aspose.com/slides/fr/python-java/aspose.slides/optionalblacktransition/) afin que la transition commence à partir d’un écran noir.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType, OptionalBlackTransition

presentation = Presentation("input.pptx")
try:
    transition = presentation.getSlides().get_Item(0).getSlideShowTransition()
    transition.setType(TransitionType.Cut)
    transition_value = transition.getValue()

    if isinstance(transition_value, OptionalBlackTransition):
        cut_transition = transition_value
        cut_transition.setFromBlack(True)
        presentation.save("cut-from-black.pptx", SaveFormat.Pptx)
    else:
        print("Cut transition options are unavailable.")
finally:
    presentation.dispose()
```

## **FAQ**

**Puis‑je contrôler la vitesse de lecture d’une transition de diapositive ?**

Oui. Privilégiez [setDuration](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slideshowtransition/#setDuration) lorsque vous avez besoin d’une durée d’effet exacte en millisecondes. Utilisez [setSpeed](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slideshowtransition/#setSpeed) lorsqu’une catégorie prédéfinie de [TransitionSpeed](https://reference.aspose.com/slides/fr/python-java/aspose.slides/transitionspeed/) — Slow, Medium ou Fast — est suffisante et qu’aucune durée explicite n’est définie. Ces réglages contrôlent l’effet de transition indépendamment du délai d’avancement automatique.

**Puis‑je attacher du son à une transition et le faire boucler ?**

Oui. Assignez un son intégré avec [setSound](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slideshowtransition/#setSound), transmettez `StartSound` de l’énumération [TransitionSoundMode](https://reference.aspose.com/slides/fr/python-java/aspose.slides/transitionsoundmode/) à [setSoundMode](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slideshowtransition/#setSoundMode), et activez [setSoundLoop](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slideshowtransition/#setSoundLoop) avec `True`. Le son boucle jusqu’au prochain événement sonore du diaporama.

**Quelle est la façon la plus rapide d’appliquer la même transition à chaque diapositive ?**

Parcourez la collection [getSlides](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/#getSlides) de la présentation et appelez [setType](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slideshowtransition/#setType) avec la même valeur pour chaque transition de diapositive. Définissez les options de minutage et d’effet dans la même boucle afin de garder le comportement cohérent sur toutes les diapositives.

**Comment vérifier quelle transition est actuellement définie sur une diapositive ?**

Appelez [getType](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slideshowtransition/#getType) sur le résultat de [getSlideShowTransition](https://reference.aspose.com/slides/fr/python-java/aspose.slides/baseslide/#getSlideShowTransition) de la diapositive. Elle renvoie une valeur de l’énumération [TransitionType](https://reference.aspose.com/slides/fr/python-java/aspose.slides/transitiontype/) ; `None_` indique qu’aucun effet de transition n’est appliqué.