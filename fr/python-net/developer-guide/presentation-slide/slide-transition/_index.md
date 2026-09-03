---
title: Gestion des transitions de diapositives dans les présentations avec Python
linktitle: Transition de diapositive
type: docs
weight: 90
url: /fr/python-net/slide-transition/
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
- Aspose.Slides
description: "Appliquer des transitions de diapositives, configurer l'avancement automatique des diapositives et personnaliser les effets Morph et autres effets de transition avec Aspose.Slides pour Python via .NET."
---
## **Aperçu**

Les transitions de diapositive contrôlent la façon dont les diapositives apparaissent pendant un diaporama. Avec Aspose.Slides for Python via .NET, vous pouvez choisir un effet de transition pour chaque diapositive, configurer l'avancement par clic de souris ou par minuteur, et ajuster les options spécifiques à un effet. Cet article utilise des exemples Python pour appliquer des transitions, définir des durées de transition exactes, gérer le timing des diapositives et créer une transition Morph entre deux diapositives. Les exemples montrent également comment enregistrer les paramètres dans un fichier PPTX.

## **Ajouter une transition de diapositive**

Pour appliquer une transition, chargez une présentation avec la classe [Presentation](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/) et accédez à la propriété [slide_show_transition](https://reference.aspose.com/slides/fr/python-net/aspose.slides/slide/slide_show_transition/). Définissez son [type](https://reference.aspose.com/slides/fr/python-net/aspose.slides.slideshow/slideshowtransition/type/) sur une valeur de l'énumération [TransitionType](https://reference.aspose.com/slides/fr/python-net/aspose.slides.slideshow/transitiontype/), puis enregistrez la présentation.

L'exemple suivant applique une transition Circle à la première diapositive et une transition Comb à la deuxième. Utilisez un fichier `input.pptx` contenant au moins deux diapositives.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    if len(presentation.slides) >= 2:
        presentation.slides[0].slide_show_transition.type = slides.slideshow.TransitionType.CIRCLE
        presentation.slides[1].slide_show_transition.type = slides.slideshow.TransitionType.COMB

        presentation.save("slide-transitions.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The input presentation must contain at least two slides.")
```

## **Ajouter une transition de diapositive avancée**

Vous pouvez configurer la durée d'affichage d'une diapositive à l'écran et si un clic de souris avance le diaporama. Les propriétés suivantes contrôlent ce comportement :

- [advance_on_click](https://reference.aspose.com/slides/fr/python-net/aspose.slides.slideshow/slideshowtransition/advance_on_click/) permet au spectateur d'avancer en cliquant avec la souris.
- [advance_after](https://reference.aspose.com/slides/fr/python-net/aspose.slides.slideshow/slideshowtransition/advance_after/) active l'avancement automatique.
- [advance_after_time](https://reference.aspose.com/slides/fr/python-net/aspose.slides.slideshow/slideshowtransition/advance_after_time/) spécifie le délai avant l'avancement automatique, en millisecondes.

Activez à la fois l'avancement par clic et l'avancement chronométré pour laisser le spectateur avancer avec un clic ou attendre le minuteur. Pour n'utiliser que le minuteur, définissez [advance_on_click](https://reference.aspose.com/slides/fr/python-net/aspose.slides.slideshow/slideshowtransition/advance_on_click/) sur `False`. Le délai contrôle le moment où le diaporama avance ; il ne définit pas la durée de l'effet de transition visuel.

Cet exemple attribue différents effets aux trois premières diapositives et active l'avancement automatique après 3, 5 et 7 secondes, respectivement. Les clics de souris peuvent également avancer ces diapositives. Utilisez un fichier `input.pptx` contenant au moins trois diapositives.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    if len(presentation.slides) >= 3:
        first_transition = presentation.slides[0].slide_show_transition
        first_transition.type = slides.slideshow.TransitionType.CIRCLE
        first_transition.advance_on_click = True
        first_transition.advance_after = True
        first_transition.advance_after_time = 3000

        second_transition = presentation.slides[1].slide_show_transition
        second_transition.type = slides.slideshow.TransitionType.COMB
        second_transition.advance_on_click = True
        second_transition.advance_after = True
        second_transition.advance_after_time = 5000

        third_transition = presentation.slides[2].slide_show_transition
        third_transition.type = slides.slideshow.TransitionType.ZOOM
        third_transition.advance_on_click = True
        third_transition.advance_after = True
        third_transition.advance_after_time = 7000

        presentation.save("advanced-transitions.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The input presentation must contain at least three slides.")
```

Pour vérifier si l'avancement chronométré est activé, lisez [advance_after](https://reference.aspose.com/slides/fr/python-net/aspose.slides.slideshow/slideshowtransition/advance_after/). Un délai stocké seul n'indique pas que le minuteur est actif.

L'exemple suivant ouvre le fichier enregistré ci‑dessus, signale chaque minuteur activé et désactive l'avancement automatique pour les diapositives dont le délai dépasse deux secondes. Il active les clics de souris pour ces diapositives et enregistre les paramètres mis à jour.

```python
import aspose.slides as slides

with slides.Presentation("advanced-transitions.pptx") as presentation:
    for slide in presentation.slides:
        transition = slide.slide_show_transition

        if transition.advance_after:
            print(f"Slide {slide.slide_number}: advance after {transition.advance_after_time} ms.")

            if transition.advance_after_time > 2000:
                transition.advance_after = False
                transition.advance_on_click = True

    presentation.save("adjusted-transitions.pptx", slides.export.SaveFormat.PPTX)
```

## **Contrôler précisément le timing des transitions**

Utilisez [duration](https://reference.aspose.com/slides/fr/python-net/aspose.slides.slideshow/slideshowtransition/duration/) pour spécifier la longueur exacte d'un effet de transition en millisecondes. La propriété [slide_show_transition](https://reference.aspose.com/slides/fr/python-net/aspose.slides/slide/slide_show_transition/) de la diapositive expose ces paramètres via [SlideShowTransition](https://reference.aspose.com/slides/fr/python-net/aspose.slides.slideshow/slideshowtransition/) :

| Propriété | Objectif |
| --- | --- |
| [duration](https://reference.aspose.com/slides/fr/python-net/aspose.slides.slideshow/slideshowtransition/duration/) | Définit la durée de l'effet de transition lui‑même, en millisecondes. |
| [advance_after_time](https://reference.aspose.com/slides/fr/python-net/aspose.slides.slideshow/slideshowtransition/advance_after_time/) | Définit le délai avant que la diapositive n'avance automatiquement, en millisecondes. Activez [advance_after](https://reference.aspose.com/slides/fr/python-net/aspose.slides.slideshow/slideshowtransition/advance_after/) pour activer ce minuteur. |
| [speed](https://reference.aspose.com/slides/fr/python-net/aspose.slides.slideshow/slideshowtransition/speed/) | Sélectionne une catégorie de vitesse prédéfinie dans [TransitionSpeed](https://reference.aspose.com/slides/fr/python-net/aspose.slides.slideshow/transitionspeed/) : SLOW, MEDIUM ou FAST. Elle est utilisée lorsqu'aucune durée exacte n'est spécifiée. |

[duration](https://reference.aspose.com/slides/fr/python-net/aspose.slides.slideshow/slideshowtransition/duration/) ne contrôle que l'effet de transition ; il ne détermine pas la durée pendant laquelle la diapositive reste visible. Configurez le délai d'avancement automatique séparément. Lorsqu'aucune durée explicite n'est définie, Aspose.Slides détermine la durée de l'effet à partir du type de transition et de la valeur [speed](https://reference.aspose.com/slides/fr/python-net/aspose.slides.slideshow/slideshowtransition/speed/).

### **Appliquer la même durée à chaque diapositive**

Pour un rythme cohérent, appliquez le même effet et la même durée exacte à chaque diapositive. Cet exemple charge `input.pptx`, sélectionne Fade depuis [TransitionType](https://reference.aspose.com/slides/fr/python-net/aspose.slides.slideshow/transitiontype/), et donne à chaque transition une durée de 750 millisecondes. Il active séparément l'avancement automatique après 5 000 millisecondes et désactive l'avancement par clic de souris, puis enregistre le résultat en PPTX.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    for slide in presentation.slides:
        transition = slide.slide_show_transition
        transition.type = slides.slideshow.TransitionType.FADE
        transition.duration = 750

        # Configurer l'avancement automatique indépendamment de la durée de l'effet.
        transition.advance_after = True
        transition.advance_after_time = 5000
        transition.advance_on_click = False

    presentation.save("precise-transitions.pptx", slides.export.SaveFormat.PPTX)
```

### **Définir des durées différentes pour les diapositives individuelles**

Différentes diapositives peuvent utiliser des durées d'effet différentes. Par exemple, utilisez une transition brève pour une diapositive de titre et une transition plus longue pour l'introduction d'une section. Cet exemple définit 500 millisecondes pour la première diapositive et 1 200 millisecondes pour la deuxième. Utilisez un fichier `input.pptx` contenant au moins deux diapositives.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    if len(presentation.slides) >= 2:
        first_transition = presentation.slides[0].slide_show_transition
        first_transition.type = slides.slideshow.TransitionType.FADE
        first_transition.duration = 500

        second_transition = presentation.slides[1].slide_show_transition
        second_transition.type = slides.slideshow.TransitionType.PUSH
        second_transition.duration = 1200

        presentation.save("individual-transition-durations.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The input presentation must contain at least two slides.")
```

### **Coordonner les transitions avec la sortie animée**

Lors de la préparation d'un [animated GIF](/slides/fr/python-net/convert-powerpoint-to-animated-gif/), d'une [HTML5 presentation](/slides/fr/python-net/export-to-html5/) ou d'une [video](/slides/fr/python-net/convert-powerpoint-to-video/), définissez des durées de transition exactes avant l'exportation pour correspondre au rythme prévu. Par exemple, utilisez un fondu de 600 millisecondes entre les scènes et ajustez séparément le délai d'avancement de chaque diapositive pour laisser le temps à la narration ou au contenu.

Pour les GIF et les vidéos, coordonnez la fréquence d'images de sortie avec la durée de l'effet : 600 millisecondes correspondent à 18 images à 30 images par seconde. En HTML5, activez les transitions animées dans les paramètres d'exportation. Vérifiez les effets et options de timing pris en charge par le format d'export choisi, et prévisualisez la sortie pour confirmer la synchronisation.

### **Lire la durée d'une transition existante**

Lisez [duration](https://reference.aspose.com/slides/fr/python-net/aspose.slides.slideshow/slideshowtransition/duration/) avant de modifier la transition pour déterminer si une valeur explicite est stockée. Une valeur de `-1` signifie qu'aucune durée explicite n'est définie ; une valeur non négative indique la durée stockée en millisecondes. La valeur non définie n'est pas la durée de lecture calculée : Aspose.Slides utilise le type de transition et [speed](https://reference.aspose.com/slides/fr/python-net/aspose.slides.slideshow/slideshowtransition/speed/) pour déterminer cette durée. La définition d'un type de transition peut initialiser une durée, il faut donc d'abord inspecter les paramètres d'origine.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    for slide in presentation.slides:
        transition = slide.slide_show_transition
        duration = transition.duration

        if duration >= 0:
            print(f"Slide {slide.slide_number}: stored transition duration is {duration} ms.")
        else:
            print(f"Slide {slide.slide_number}: no explicit duration; timing depends on {transition.type} and {transition.speed}.")
```

## **Transition Morph**

La transition Morph anime les changements entre objets sur des diapositives consécutives. Pour créer un effet Morph simple, dupliquez une diapositive, déplacez ou redimensionnez un objet sur le clone, puis appliquez la transition Morph à la deuxième diapositive. Cela fournit à la transition les objets correspondants à animer entre leurs états d'origine et modifié.

L'exemple suivant crée une diapositive contenant un rectangle de texte, duplique la diapositive et modifie la position et la taille du rectangle sur le clone. Il sélectionne ensuite Morph depuis l'énumération [TransitionType](https://reference.aspose.com/slides/fr/python-net/aspose.slides.slideshow/transitiontype/) pour la deuxième diapositive. Ouvrez le fichier enregistré dans un visualiseur de présentation qui prend en charge Morph pour voir l'effet pendant le diaporama.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    first_slide = presentation.slides[0]
    rectangle = first_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 400, 100)
    rectangle.text_frame.text = "Morph transition"

    second_slide = presentation.slides.add_clone(first_slide)
    moved_rectangle = second_slide.shapes[0]
    moved_rectangle.x += 100
    moved_rectangle.y += 50
    moved_rectangle.width -= 200
    moved_rectangle.height -= 10

    second_slide.slide_show_transition.type = slides.slideshow.TransitionType.MORPH

    presentation.save("morph-transition.pptx", slides.export.SaveFormat.PPTX)
```

## **Types de transition Morph**

L'énumération [TransitionMorphType](https://reference.aspose.com/slides/fr/python-net/aspose.slides.slideshow/transitionmorphtype/) contrôle la façon dont Morph associe et anime le contenu :

- [BY_OBJECT](https://reference.aspose.com/slides/fr/python-net/aspose.slides.slideshow/transitionmorphtype/) considère chaque forme comme un objet entier.
- [BY_WORD](https://reference.aspose.com/slides/fr/python-net/aspose.slides.slideshow/transitionmorphtype/) anime le texte en faisant correspondre les mots lorsque c'est possible.
- [BY_CHAR](https://reference.aspose.com/slides/fr/python-net/aspose.slides.slideshow/transitionmorphtype/) anime le texte en faisant correspondre les caractères lorsque c'est possible.

Définissez la [type](https://reference.aspose.com/slides/fr/python-net/aspose.slides.slideshow/slideshowtransition/type/) de transition sur Morph avant d'accéder à sa [value](https://reference.aspose.com/slides/fr/python-net/aspose.slides.slideshow/slideshowtransition/value/). La valeur fournit alors l'objet [MorphTransition](https://reference.aspose.com/slides/fr/python-net/aspose.slides.slideshow/morphtransition/), dont la propriété [morph_type](https://reference.aspose.com/slides/fr/python-net/aspose.slides.slideshow/morphtransition/morph_type/) sélectionne le mode de correspondance.

```python
import aspose.slides as slides

with slides.Presentation("morph-transition.pptx") as presentation:
    if len(presentation.slides) >= 2:
        transition = presentation.slides[1].slide_show_transition
        transition.type = slides.slideshow.TransitionType.MORPH
        morph_transition = transition.value

        if isinstance(morph_transition, slides.slideshow.MorphTransition):
            morph_transition.morph_type = slides.slideshow.TransitionMorphType.BY_WORD
            presentation.save("morph-by-word.pptx", slides.export.SaveFormat.PPTX)
        else:
            print("Morph transition options are unavailable.")
    else:
        print("The input presentation must contain at least two slides.")
```

## **Définir les effets de transition**

Certaines transitions exposent des options supplémentaires, telles que la direction ou si l'effet commence depuis un écran noir. Les options disponibles dépendent du [type](https://reference.aspose.com/slides/fr/python-net/aspose.slides.slideshow/slideshowtransition/type/) de transition sélectionné. Définissez d'abord le type, puis utilisez l'objet de transition approprié via sa [value](https://reference.aspose.com/slides/fr/python-net/aspose.slides.slideshow/slideshowtransition/value/).

L'exemple suivant applique une transition Cut à la première diapositive de `input.pptx`. Il définit [from_black](https://reference.aspose.com/slides/fr/python-net/aspose.slides.slideshow/optionalblacktransition/from_black/) via [OptionalBlackTransition](https://reference.aspose.com/slides/fr/python-net/aspose.slides.slideshow/optionalblacktransition/) afin que la transition commence depuis un écran noir.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    transition = presentation.slides[0].slide_show_transition
    transition.type = slides.slideshow.TransitionType.CUT
    cut_transition = transition.value

    if isinstance(cut_transition, slides.slideshow.OptionalBlackTransition):
        cut_transition.from_black = True
        presentation.save("cut-from-black.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("Cut transition options are unavailable.")
```

## **FAQ**

**Puis-je contrôler la vitesse de lecture d'une transition de diapositive ?**

Oui. Privilégiez [duration](https://reference.aspose.com/slides/fr/python-net/aspose.slides.slideshow/slideshowtransition/duration/) lorsque vous avez besoin d'une durée d'effet exacte en millisecondes. Utilisez [speed](https://reference.aspose.com/slides/fr/python-net/aspose.slides.slideshow/slideshowtransition/speed/) lorsqu'une catégorie prédéfinie de [TransitionSpeed](https://reference.aspose.com/slides/fr/python-net/aspose.slides.slideshow/transitionspeed/) — SLOW, MEDIUM ou FAST — suffit et qu'aucune durée explicite n'est définie. Ces paramètres contrôlent l'effet de transition indépendamment du délai d'avancement automatique.

**Puis-je ajouter un audio à une transition et le faire boucler ?**

Oui. Assignez un audio intégré à [sound](https://reference.aspose.com/slides/fr/python-net/aspose.slides.slideshow/slideshowtransition/sound/), définissez [sound_mode](https://reference.aspose.com/slides/fr/python-net/aspose.slides.slideshow/slideshowtransition/sound_mode/) sur START_SOUND provenant de l'énumération [TransitionSoundMode](https://reference.aspose.com/slides/fr/python-net/aspose.slides.slideshow/transitionsoundmode/), et activez [sound_loop](https://reference.aspose.com/slides/fr/python-net/aspose.slides.slideshow/slideshowtransition/sound_loop/). L'audio boucle jusqu'au prochain événement sonore du diaporama.

**Quelle est la façon la plus rapide d'appliquer la même transition à chaque diapositive ?**

Parcourez la collection [slides](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/slides/fr/) de la présentation et définissez la [type](https://reference.aspose.com/slides/fr/python-net/aspose.slides.slideshow/slideshowtransition/type/) de transition de chaque diapositive sur la même valeur. Appliquez les options de timing et d'effet dans la même boucle pour garantir un comportement cohérent sur toutes les diapositives.

**Comment puis-je vérifier quelle transition est actuellement définie sur une diapositive ?**

Lisez la propriété [type](https://reference.aspose.com/slides/fr/python-net/aspose.slides.slideshow/slideshowtransition/type/) depuis la [slide_show_transition](https://reference.aspose.com/slides/fr/python-net/aspose.slides/slide/slide_show_transition/) de la diapositive. Elle renvoie une valeur de l'énumération [TransitionType](https://reference.aspose.com/slides/fr/python-net/aspose.slides.slideshow/transitiontype/) ; NONE signifie qu'aucun effet de transition n'est appliqué.