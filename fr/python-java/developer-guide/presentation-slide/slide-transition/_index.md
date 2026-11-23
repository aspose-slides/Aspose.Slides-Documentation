---
title: Gérer les transitions de diapositives dans les présentations avec Python via Java
linktitle: Transition de diapositive
type: docs
weight: 80
url: /fr/python-java/slide-transition/
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
- Python
- Java
- Aspose.Slides
description: "Appliquez des transitions de diapositives, configurez l'avance automatique des diapositives, et personnalisez les effets Morph et d'autres transitions avec Aspose.Slides pour Python via Java."
---
## **Vue d'ensemble**

Les transitions de diapositives contrôlent la façon dont les diapositives apparaissent pendant un diaporama. Avec Aspose.Slides for Python via Java, vous pouvez choisir un effet de transition pour chaque diapositive, configurer l'avancement par clic de souris ou par minuteur, et ajuster les options spécifiques à un effet. Cet article utilise des exemples Python pour appliquer des transitions, définir des durées de transition précises, gérer le minutage des diapositives et créer une transition Morph entre deux diapositives. Les exemples montrent également comment enregistrer les paramètres dans un fichier PPTX.

## **Ajouter une transition de diapositive**

Pour appliquer une transition, chargez une présentation avec la classe [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) et accédez aux paramètres de transition de la diapositive via [getSlideShowTransition](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getSlideShowTransition). Utilisez [setType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setType) avec une valeur de l'énumération [TransitionType](https://reference.aspose.com/slides/python-java/aspose.slides/transitiontype/), puis enregistrez la présentation.

L'exemple suivant applique une transition Circle à la première diapositive et une transition Comb à la deuxième. Utilisez un fichier `input.pptx` contenant au moins deux diapositives.

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

## **Transition en roue**

Utilisez [setType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setType) pour sélectionner Wheel dans [TransitionType](https://reference.aspose.com/slides/python-java/aspose.slides/transitiontype/). Ensuite, appelez [getValue](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getValue) pour accéder aux paramètres de [WheelTransition](https://reference.aspose.com/slides/python-java/aspose.slides/wheeltransition/). Sa méthode [setSpokes](https://reference.aspose.com/slides/python-java/aspose.slides/wheeltransition/#setSpokes) contrôle le nombre de secteurs radiaux qui révèlent la diapositive de destination.

L'exemple crée deux paires identiques de diapositives. Chaque paire commence par une diapositive noire et se termine par un rectangle doré occupant toute la diapositive. Les deux diapositives de destination utilisent la même vitesse lente définie avec [setSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSpeed) et la même durée explicite de 8,000 millisecondes définie avec [setDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setDuration). Seul le nombre de rayons change.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat, ShapeType, TransitionSpeed, TransitionType

Color = jpype.JClass("java.awt.Color")
presentation = Presentation()
try:
    width = jpype.JFloat(presentation.getSlideSize().getSize().getWidth())
    height = jpype.JFloat(presentation.getSlideSize().getSize().getHeight())

    slides = presentation.getSlides()
    black_slide = slides.get_Item(0)
    black_slide.getShapes().clear()
    background = black_slide.getBackground()
    background.setType(BackgroundType.OwnBackground)
    background.getFillFormat().setFillType(FillType.Solid)
    background.getFillFormat().getSolidFillColor().setColor(Color.BLACK)

    destination_slide = slides.addClone(black_slide)
    rectangle = destination_slide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, width, height)
    rectangle.getFillFormat().setFillType(FillType.Solid)
    rectangle.getFillFormat().getSolidFillColor().setColor(Color(255, 215, 0))
    rectangle.getTextFrame().setText("Wheel transition")

    slides.addClone(black_slide)
    slides.addClone(destination_slide)
    for slide_index, spokes in ((1, 1), (3, 8)):
        transition = slides.get_Item(slide_index).getSlideShowTransition()
        transition.setType(TransitionType.Wheel)
        wheel_transition = transition.getValue()
        wheel_transition.setSpokes(spokes)
        transition.setSpeed(TransitionSpeed.Slow)
        transition.setDuration(8000)

    presentation.save("wheel-transitions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Ouvrez `wheel-transitions.pptx` dans PowerPoint et lancez le diaporama. Avancez de la diapositive 1 à la diapositive 2 pour voir un balayage horaire révéler le rectangle doré. Puis avancez de la diapositive 3 à la diapositive 4 pour voir huit secteurs radiaux révéler simultanément le même rectangle.

## **Fondu vers le noir avec la transition Reveal**

Définissez le type de transition de la diapositive de destination sur Reveal, puis appelez [setThroughBlack](https://reference.aspose.com/slides/python-java/aspose.slides/revealtransition/#setThroughBlack) sur ses paramètres [RevealTransition](https://reference.aspose.com/slides/python-java/aspose.slides/revealtransition/). L'exemple crée une diapositive source teal et une diapositive de destination coral, puis les clone. Chaque paire utilise la même transition Reveal de deux secondes. Seule la seconde paire effectue un fondu via le noir.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, PresetColor, Presentation, SaveFormat, ShapeType
from asposeslides.api import TransitionLeftRightDirectionType, TransitionSpeed, TransitionType


def style_slide(slide, background_color, label):
    slide.getBackground().setType(BackgroundType.OwnBackground)
    fill = slide.getBackground().getFillFormat()
    fill.setFillType(FillType.Solid)
    fill.getSolidFillColor().setPresetColor(background_color)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 160, 180, 400, 130)
    shape.getTextFrame().setText(label)
    portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.getPortionFormat().setFontHeight(44)


presentation = Presentation()
try:
    source = presentation.getSlides().get_Item(0)
    destination = presentation.getSlides().addClone(source)
    style_slide(source, PresetColor.Teal, "Source")
    style_slide(destination, PresetColor.Coral, "Destination")

    presentation.getSlides().addClone(source)
    cloned_destination = presentation.getSlides().addClone(destination)
    for slide in (destination, cloned_destination):
        transition = slide.getSlideShowTransition()
        transition.setType(TransitionType.Reveal)
        transition.setSpeed(TransitionSpeed.Slow)
        transition.setDuration(2000)

        reveal = transition.getValue()
        reveal.setDirection(TransitionLeftRightDirectionType.Left)
        reveal.setThroughBlack(slide is cloned_destination)

    presentation.save("reveal-transitions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Ouvrez `reveal-transitions.pptx` dans PowerPoint et lancez le diaporama. Avancez de la diapositive 1 à la diapositive 2 pour voir le teal fondre directement en coral. Puis avancez de la diapositive 3 à la diapositive 4. L'écran s'assombrit brièvement presque jusqu'au noir avant que la diapositive coral n'apparaisse. Les deux diapositives conservent leurs couleurs de fond d'origine.

Les lignes ci‑dessous montrent des images de PowerPoint à intervalles d'une demi‑seconde. Comparez l'image du milieu de chaque ligne pour voir l'effet.

![Lecture PowerPoint avec le fondu via noir désactivé (haut) et activé (bas). Seule la ligne du bas passe par un noir quasi total.](reveal-through-black.png)

## **Ajouter une transition de diapositive avancée**

Vous pouvez configurer la durée d'affichage d'une diapositive à l'écran et déterminer si un clic de souris fait avancer le diaporama. Les méthodes suivantes contrôlent ce comportement :

- [setAdvanceOnClick](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) permet au spectateur d'avancer en cliquant avec la souris.
- [setAdvanceAfter](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceAfter) active l'avancement automatique.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) spécifie le délai avant l'avancement automatique, en millisecondes.

Activez à la fois l'avancement par clic et le minutage pour permettre au spectateur de poursuivre avec un clic ou d'attendre le minuteur. Pour n'utiliser que le minuteur, passez `False` à [setAdvanceOnClick](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceOnClick). Le délai contrôle le moment où le diaporama avance ; il ne définit pas la durée de l'effet de transition visuel.

Cet exemple attribue différents effets aux trois premières diapositives et active l'avancement automatique après 3, 5 et 7 secondes, respectivement. Les clics de souris peuvent également faire avancer ces diapositives. Utilisez un fichier `input.pptx` contenant au moins trois diapositives.

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

Pour vérifier si l'avancement chronométré est activé, appelez [getAdvanceAfter](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getAdvanceAfter). Un délai stocké seul n'indique pas que le minuteur est actif.

L'exemple suivant ouvre le fichier enregistré précédemment, signale chaque minuteur activé et désactive l'avancement automatique pour les diapositives dont le délai dépasse deux secondes. Il active les clics de souris pour ces diapositives et enregistre les paramètres mis à jour.

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

Utilisez [setDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setDuration) pour spécifier la durée exacte d'un effet de transition en millisecondes. La méthode [getSlideShowTransition](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getSlideShowTransition) de la diapositive expose ces paramètres via [SlideShowTransition](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/) :

| Méthode | Objectif |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setDuration) | Définit la durée de l'effet de transition lui-même, en millisecondes. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) | Définit le délai avant que la diapositive n'avance automatiquement, en millisecondes. Passez `True` à [setAdvanceAfter](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceAfter) pour activer ce minuteur. |
| [setSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSpeed) | Sélectionne une catégorie de vitesse prédéfinie dans [TransitionSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/transitionspeed/): Slow, Medium ou Fast. Elle est utilisée lorsqu'aucune durée précise n'est spécifiée. |

[setDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setDuration) ne contrôle que l'effet de transition ; il ne détermine pas la durée pendant laquelle la diapositive reste visible. Configurez séparément le délai d'avancement automatique. Lorsqu'aucune durée explicite n'est définie, Aspose.Slides détermine la durée de l'effet à partir du type de transition et de la valeur [getSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getSpeed).

<!-- visual-explanation:slide-transition:start -->
[![Des barres séparées identifient la durée de transition de 750 ms et le réglage d'avancement automatique de 5 000 ms.](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*L'exemple partagé applique à chaque diapositive une transition Fade de 750 ms et active séparément l'avancement automatique à 5 000 ms. La durée de transition contrôle l'effet ; l'avancement contrôle le moment de quitter la diapositive. Ces barres sont des réglages schématiques, pas une chronologie combinée mesurée.*
<!-- visual-explanation:slide-transition:end -->

### **Appliquer la même durée à chaque diapositive**

Pour un rythme cohérent, appliquez le même effet et la même durée exacte à chaque diapositive. Cet exemple charge `input.pptx`, sélectionne Fade dans [TransitionType](https://reference.aspose.com/slides/python-java/aspose.slides/transitiontype/), et attribue à chaque transition une durée de 750 millisecondes. Il active séparément l'avancement automatique après 5 000 millisecondes et désactive l'avancement par clic de souris, puis enregistre le résultat au format PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpile.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType

presentation = Presentation("input.pptx")
try:
    for slide in presentation.getSlides():
        transition = slide.getSlideShowTransition()
        transition.setType(TransitionType.Fade)
        transition.setDuration(750)

        # Configurer l'avance automatique indépendamment de la durée de l'effet.
        transition.setAdvanceAfter(True)
        transition.setAdvanceAfterTime(5000)
        transition.setAdvanceOnClick(False)

    presentation.save("precise-transitions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Définir des durées différentes pour chaque diapositive**

Différentes diapositives peuvent utiliser des durées d'effet différentes. Par exemple, utilisez une transition brève pour une diapositive titre et une transition plus longue pour une introduction de section. Cet exemple définit 500 ms pour la première diapositive et 1 200 ms pour la deuxième. Utilisez un fichier `input.pptx` contenant au moins deux diapositives.

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

### **Coordonner les transitions avec la sortie animée**

Lors de la préparation d'un [GIF animé](/slides/fr/python-java/convert-powerpoint-to-animated-gif/), d'une [présentation HTML5](/slides/fr/python-java/export-to-html5/) ou d'une [vidéo](/slides/fr/python-java/convert-powerpoint-to-video/), définissez des durées de transition exactes avant l'exportation pour correspondre au rythme souhaité. Par exemple, utilisez un fondu de 600 ms entre les scènes, et ajustez séparément le délai d'avancement de chaque diapositive pour laisser le temps à sa narration ou à son contenu. 

Pour les GIF et les vidéos, coordonnez la fréquence d'images de sortie avec la durée de l'effet : 600 ms correspondent à 18 images à 30 images par seconde. En HTML5, activez les transitions animées dans les paramètres d'exportation. Vérifiez les effets et les options de minutage pris en charge par le format d'exportation choisi, et prévisualisez la sortie pour confirmer la synchronisation.

### **Lire la durée d'une transition existante**

Appelez [getDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getDuration) avant de modifier la transition pour déterminer si une valeur explicite est stockée. Une valeur de `-1` signifie qu'aucune durée explicite n'est définie ; une valeur non négative spécifie la durée stockée en millisecondes. La valeur non définie n'est pas la durée de lecture calculée : Aspose.Slides utilise le type de transition et la valeur [getSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getSpeed) pour déterminer cette durée. Le fait de définir un type de transition peut initialiser une durée, il faut donc d'abord inspecter les paramètres d'origine.

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

La transition Morph anime les changements entre objets sur des diapositives consécutives. Pour créer un effet Morph simple, clonez une diapositive, déplacez ou redimensionnez un objet sur le clone, et appliquez la transition Morph à la deuxième diapositive. Cela fournit à la transition les objets correspondants à animer entre leurs états d'origine et modifié.

L'exemple suivant crée une diapositive contenant un rectangle de texte, clone la diapositive, et modifie la position et la taille du rectangle sur le clone. Il sélectionne ensuite Morph dans l'énumération [TransitionType](https://reference.aspose.com/slides/python-java/aspose.slides/transitiontype/) pour la deuxième diapositive. Ouvrez le fichier enregistré dans un visionneur de présentations qui prend en charge Morph pour voir l'effet pendant un diaporama.

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

L'énumération [TransitionMorphType](https://reference.aspose.com/slides/python-java/aspose.slides/transitionmorphtype/) contrôle la façon dont Morph associe et anime le contenu :

- [ByObject](https://reference.aspose.com/slides/python-java/aspose.slides/transitionmorphtype/#ByObject) traite chaque forme comme un objet complet.
- [ByWord](https://reference.aspose.com/slides/python-java/aspose.slides/transitionmorphtype/#ByWord) anime le texte en associant les mots lorsque c'est possible.
- [ByChar](https://reference.aspose.com/slides/python-java/aspose.slides/transitionmorphtype/#ByChar) anime le texte en associant les caractères lorsque c'est possible.

Utilisez [setType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setType) pour sélectionner Morph avant d'accéder à [getValue](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getValue). La valeur est alors une instance de la classe [MorphTransition](https://reference.aspose.com/slides/python-java/aspose.slides/morphtransition/), dont la méthode [setMorphType](https://reference.aspose.com/slides/python-java/aspose.slides/morphtransition/#setMorphType) sélectionne le mode d'association.

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

Certaines transitions exposent des options supplémentaires, comme la direction ou si l'effet démarre depuis un écran noir. Les options disponibles dépendent de la transition sélectionnée avec [setType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setType). Définissez d'abord le type, puis utilisez la classe appropriée de [getValue](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getValue).

L'exemple suivant applique une transition Cut à la première diapositive de `input.pptx`. Il appelle [setFromBlack](https://reference.aspose.com/slides/python-java/aspose.slides/optionalblacktransition/#setFromBlack) via [OptionalBlackTransition](https://reference.aspose.com/slides/python-java/aspose.slides/optionalblacktransition/) afin que la transition démarre depuis un écran noir.

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

**Puis-je contrôler la vitesse de lecture d'une transition de diapositive ?**

Oui. Privilégiez [setDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setDuration) lorsque vous avez besoin d'une durée d'effet exacte en millisecondes. Utilisez [setSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSpeed) lorsqu'une catégorie prédéfinie de [TransitionSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/transitionspeed/) — Slow, Medium ou Fast — suffit et qu'aucune durée explicite n'est définie. Ces réglages contrôlent l'effet de transition indépendamment du délai d'avancement automatique.

**Puis-je attacher un audio à une transition et le faire boucler ?**

Oui. Assignez un audio intégré avec [setSound](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSound), passez StartSound de l'énumération [TransitionSoundMode](https://reference.aspose.com/slides/python-java/aspose.slides/transitionsoundmode/) à [setSoundMode](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSoundMode), et activez [setSoundLoop](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSoundLoop) avec `True`. L'audio bouclera jusqu'au prochain événement sonore du diaporama.

**Quelle est la manière la plus rapide d'appliquer la même transition à chaque diapositive ?**

Parcourez la collection [getSlides](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getSlides) de la présentation et appelez [setType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setType) avec la même valeur pour chaque transition de diapositive. Définissez les options de minutage et d'effet dans la même boucle afin de garder le comportement cohérent entre les diapositives.

**Comment puis‑je vérifier quelle transition est actuellement définie sur une diapositive ?**

Appelez [getType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getType) sur le résultat de [getSlideShowTransition](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getSlideShowTransition) de la diapositive. Elle renvoie une valeur de l'énumération [TransitionType](https://reference.aspose.com/slides/python-java/aspose.slides/transitiontype/) ; None_ indique qu'aucun effet de transition n'est appliqué.