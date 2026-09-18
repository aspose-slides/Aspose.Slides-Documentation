---
title: "Appliquer des animations de forme dans les présentations avec Python"
linktitle: "Animation de forme"
type: docs
weight: 60
url: /fr/python-net/shape-animation/
keywords:
- forme
- animation
- effet
- forme animée
- texte animé
- ajouter animation
- obtenir animation
- extraire animation
- ajouter effet
- obtenir effet
- extraire effet
- son d'effet
- appliquer animation
- PowerPoint
- présentation
- Python
- Aspose.Slides
description: "Apprenez comment ajouter, inspecter et personnaliser les animations de forme, le chronométrage, les sons, le comportement après l'animation et le texte animé avec Aspose.Slides pour Python via .NET."
---
## **Vue d'ensemble**

Pour travailler avec les comportements individuels d'un effet ou éditer les segments de trajectoire de mouvement, voir [Animation personnalisée](/slides/fr/python-net/custom-animation/).

Aspose.Slides for Python via .NET représente les animations de diapositives sous forme d'effets dans la chronologie d'une diapositive. Un effet possède une forme cible, un type et un sous‑type d'animation, un déclencheur, des paramètres de chronométrage, ainsi que des propriétés optionnelles telles que le son ou le comportement après l'animation.

La chronologie contient deux types de séquences :

- La **séquence principale** se lit au fur et à mesure que la diapositive avance.
- Une **séquence interactive** démarre lorsque sa forme déclencheur est cliquée.

Comme les zones de texte, les images, les graphiques, les tableaux et d'autres objets de diapositive implémentent [IShape](https://reference.aspose.com/slides/fr/python-net/aspose.slides/ishape/), vous utilisez la même méthode [Sequence.add_effect](https://reference.aspose.com/slides/fr/python-net/aspose.slides.animation/sequence/add_effect/) pour la plupart du contenu de la diapositive. Les effets disponibles sont répertoriés dans l'énumération [EffectType](https://reference.aspose.com/slides/fr/python-net/aspose.slides.animation/effecttype/).

## **Ajouter des animations de forme**

Pour ajouter une animation, récupérez la séquence principale de la diapositive et appelez [Sequence.add_effect](https://reference.aspose.com/slides/fr/python-net/aspose.slides.animation/sequence/add_effect/) avec la forme cible, le type d'effet, le sous‑type et le déclencheur. Pour un effet qui démarre lorsqu'une autre forme est cliquée, créez une séquence interactive dont le déclencheur est cette autre forme.

L'exemple suivant crée les deux types d'animation et enregistre le résultat dans `shape-animations.pptx`.

```python
import aspose.slides as slides


with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    target_shape = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 120, 100, 320, 80)
    target_shape.text_frame.text = "Click to animate this shape"

    main_sequence = slide.timeline.main_sequence
    entrance_effect = main_sequence.add_effect(target_shape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    entrance_effect.timing.duration = 1.5

    trigger_shape = slide.shapes.add_auto_shape(slides.ShapeType.BEVEL, 20, 20, 100, 40)
    trigger_shape.text_frame.text = "Move"

    interactive_sequence = slide.timeline.interactive_sequences.add(trigger_shape)
    interactive_sequence.add_effect(target_shape, slides.animation.EffectType.PATH_FOOTBALL, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)

    presentation.save("shape-animations.pptx", slides.export.SaveFormat.PPTX)
```

Le déclencheur contrôle le moment où un effet démarre :

- [EffectTriggerType.ON_CLICK](https://reference.aspose.com/slides/fr/python-net/aspose.slides.animation/effecttriggertype/) attend un clic dans la séquence principale, ou un clic sur la forme déclencheur dans une séquence interactive.
- [EffectTriggerType.WITH_PREVIOUS](https://reference.aspose.com/slides/fr/python-net/aspose.slides.animation/effecttriggertype/) démarre avec l'effet précédent.
- [EffectTriggerType.AFTER_PREVIOUS](https://reference.aspose.com/slides/fr/python-net/aspose.slides.animation/effecttriggertype/) démarre lorsque l'effet précédent se termine.

Pour animer une image, un graphique ou un autre type de forme, transmettez cet objet à [Sequence.add_effect](https://reference.aspose.com/slides/fr/python-net/aspose.slides.animation/sequence/add_effect/) au lieu de `target_shape`. Pour les options de groupement spécifiques aux graphiques, voir [Graphiques animés](/slides/fr/python-net/animated-charts/).

## **Lire les animations de forme**

Utilisez [Sequence.get_effects_by_shape](https://reference.aspose.com/slides/fr/python-net/aspose.slides.animation/sequence/get_effects_by_shape/) lorsque vous connaissez la forme cible. Pour examiner chaque effet, parcourez la séquence principale et chaque séquence interactive. L'itération évite de supposer qu'une séquence contient un effet à l'index `0`.

L'exemple suivant crée une forme avec des effets de séquence principale et interactive, récupère les effets qui ciblent la forme, puis parcourt chaque séquence de la diapositive.

```python
import aspose.slides as slides


def print_sequence(label, sequence):
    print(f"  {label}: {sequence.count} effect(s)")

    for effect in sequence:
        target_name = "unknown" if effect.target_shape is None else effect.target_shape.name
        effect_description = f"{effect.type.name} {effect.subtype.name}; target: {target_name}; trigger: {effect.timing.trigger_type.name}"
        print(f"    {effect_description}")


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    target_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 120, 100, 320, 80)
    target_shape.text_frame.text = "Animated shape"

    main_sequence = slide.timeline.main_sequence
    main_sequence.add_effect(target_shape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)

    trigger_shape = slide.shapes.add_auto_shape(slides.ShapeType.BEVEL, 20, 20, 100, 40)
    trigger_shape.text_frame.text = "Move"

    interactive_sequence = slide.timeline.interactive_sequences.add(trigger_shape)
    interactive_sequence.add_effect(target_shape, slides.animation.EffectType.PATH_FOOTBALL, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)

    target_effects = main_sequence.get_effects_by_shape(target_shape)
    print(f"The main sequence contains {len(target_effects)} effect(s) for {target_shape.name}.")

    print_sequence("Main sequence", main_sequence)

    for interactive_index, sequence in enumerate(slide.timeline.interactive_sequences, start=1):
        trigger_name = "unknown" if sequence.trigger_shape is None else sequence.trigger_shape.name
        sequence_label = f"Interactive sequence {interactive_index}, trigger: {trigger_name}"
        print_sequence(sequence_label, sequence)
```

Si vous avez besoin uniquement des effets pour une seule forme, identifiez d'abord la forme par son nom, son type de placeholder ou une autre propriété stable ; puis appelez [Sequence.get_effects_by_shape](https://reference.aspose.com/slides/fr/python-net/aspose.slides.animation/sequence/get_effects_by_shape/). N'assumez pas que la forme à l'index `0` est toujours l'objet souhaité.

## **Travailler avec les effets de placeholder hérités**

Un placeholder sur une diapositive normale peut hériter du comportement d'animation du placeholder correspondant sur sa diapositive de mise en page et sur la diapositive maître. [Shape.get_base_placeholder](https://reference.aspose.com/slides/fr/python-net/aspose.slides/shape/get_base_placeholder/) renvoie ce placeholder parent, ou `None` s'il n'existe pas.

Dans la présentation d'exemple suivante, le pied de page a **Random Bars** sur la diapositive normale, **Split** sur la diapositive de mise en page, et **Fly In** sur la diapositive maître.

![Effet d'animation du pied de page sur la diapositive normale](slide-shape-animation.png)

![Effet d'animation du placeholder du pied de page sur la diapositive de mise en page](layout-shape-animation.png)

![Effet d'animation du placeholder du pied de page sur la diapositive maître](master-shape-animation.png)

L'exemple suivant construit lui‑même la hiérarchie des placeholders. Il ajoute des effets à un placeholder maître, un placeholder de mise en page, et le placeholder correspondant sur une diapositive normale. Chaque appel à [Shape.get_base_placeholder](https://reference.aspose.com/slides/fr/python-net/aspose.slides/shape/get_base_placeholder/) est vérifié avant d'utiliser la forme retournée.

```python
import aspose.slides as slides


def find_placeholder_with_base(slide):
    for shape in slide.shapes:
        if shape.get_base_placeholder() is not None:
            return shape

    return None


def print_effects(source, effects):
    print(f"{source}: {len(effects)} effect(s)")

    for effect in effects:
        print(f"  {effect.type.name} {effect.subtype.name}")


with slides.Presentation() as presentation:
    layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)
    layout_placeholder = layout_slide.placeholder_manager.add_text_placeholder(100, 100, 400, 80)
    layout_slide.timeline.main_sequence.add_effect(layout_placeholder, slides.animation.EffectType.SPLIT, slides.animation.EffectSubtype.VERTICAL_IN, slides.animation.EffectTriggerType.ON_CLICK)

    master_placeholder = layout_placeholder.get_base_placeholder()
    if master_placeholder is not None:
        master_sequence = layout_slide.master_slide.timeline.main_sequence
        master_sequence.add_effect(master_placeholder, slides.animation.EffectType.FLY, slides.animation.EffectSubtype.BOTTOM, slides.animation.EffectTriggerType.ON_CLICK)

    slide = presentation.slides.add_empty_slide(layout_slide)
    slide_placeholder = find_placeholder_with_base(slide)

    if slide_placeholder is None:
        raise RuntimeError("The slide does not contain a placeholder linked to its layout slide.")

    slide.timeline.main_sequence.add_effect(slide_placeholder, slides.animation.EffectType.RANDOM_BARS, slides.animation.EffectSubtype.HORIZONTAL, slides.animation.EffectTriggerType.ON_CLICK)
    print_effects("Normal slide", slide.timeline.main_sequence.get_effects_by_shape(slide_placeholder))

    base_layout_placeholder = slide_placeholder.get_base_placeholder()
    if base_layout_placeholder is not None:
        print_effects("Layout slide", layout_slide.timeline.main_sequence.get_effects_by_shape(base_layout_placeholder))

        base_master_placeholder = base_layout_placeholder.get_base_placeholder()
        if base_master_placeholder is not None:
            print_effects("Master slide", layout_slide.master_slide.timeline.main_sequence.get_effects_by_shape(base_master_placeholder))

    presentation.save("placeholder-animations.pptx", slides.export.SaveFormat.PPTX)
```

## **Modifier le chronométrage des animations**

La boîte de dialogue **Timing** de PowerPoint correspond aux propriétés de [Timing](https://reference.aspose.com/slides/fr/python-net/aspose.slides.animation/timing/).

![Boîte de dialogue Timing de PowerPoint pour un effet d'animation](shape-animation.png)

- **Start** correspond à [Timing.trigger_type](https://reference.aspose.com/slides/fr/python-net/aspose.slides.animation/timing/trigger_type/).
- **Duration** correspond à [Timing.duration](https://reference.aspose.com/slides/fr/python-net/aspose.slides.animation/timing/duration/), en secondes.
- **Delay** correspond à [Timing.trigger_delay_time](https://reference.aspose.com/slides/fr/python-net/aspose.slides.animation/timing/trigger_delay_time/), en secondes.
- **Repeat** correspond à [Timing.repeat_count](https://reference.aspose.com/slides/fr/python-net/aspose.slides.animation/timing/repeat_count/), [Timing.repeat_until_next_click](https://reference.aspose.com/slides/fr/python-net/aspose.slides.animation/timing/repeat_until_next_click/), ou [Timing.repeat_until_end_slide](https://reference.aspose.com/slides/fr/python-net/aspose.slides.animation/timing/repeat_until_end_slide/).
- **Revenir en arrière après lecture** correspond à [Timing.rewind](https://reference.aspose.com/slides/fr/python-net/aspose.slides.animation/timing/rewind/).

Cet exemple indépendant ajoute un effet, modifie son chronométrage via l'objet renvoyé par [Sequence.add_effect](https://reference.aspose.com/slides/fr/python-net/aspose.slides.animation/sequence/add_effect/), et enregistre le résultat. Conserver la référence [Effect](https://reference.aspose.com/slides/fr/python-net/aspose.slides.animation/effect/) renvoyée évite un index de collection inutile.

```python
import aspose.slides as slides


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 120, 100, 320, 80)
    shape.text_frame.text = "Timed animation"

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.timing.trigger_type = slides.animation.EffectTriggerType.ON_CLICK
    effect.timing.duration = 2.0
    effect.timing.trigger_delay_time = 0.5
    effect.timing.repeat_until_next_click = False
    effect.timing.repeat_until_end_slide = False
    effect.timing.repeat_count = 2.0
    effect.timing.rewind = True

    presentation.save("shape-animation-timing.pptx", slides.export.SaveFormat.PPTX)
```

Utilisez un seul mode de répétition intentionnellement. Combiner un compte de répétition avec un drapeau « until » peut produire des résultats confus selon les visionneuses. Lors du changement de modes de répétition, définissez [Timing.repeat_until_next_click](https://reference.aspose.com/slides/fr/python-net/aspose.slides.animation/timing/repeat_until_next_click/) et [Timing.repeat_until_end_slide](https://reference.aspose.com/slides/fr/python-net/aspose.slides.animation/timing/repeat_until_end_slide/) avant [Timing.repeat_count](https://reference.aspose.com/slides/fr/python-net/aspose.slides.animation/timing/repeat_count/), car la définition de l'un de ces drapeaux modifie également le mode de répétition actif.

## **Ajouter et extraire des sons d'animation**

Un effet d'animation peut référencer un audio intégré via [Effect.sound](https://reference.aspose.com/slides/fr/python-net/aspose.slides.animation/effect/sound/). [Effect.stop_previous_sound](https://reference.aspose.com/slides/fr/python-net/aspose.slides.animation/effect/stop_previous_sound/) indique à un effet d'arrêter l'audio démarré par un effet précédent.

### **Ajouter un son à un effet**

L'exemple suivant s'attend à un fichier audio local nommé `animation-sound.wav`. Il crée deux effets, intègre ce fichier comme son du premier effet, et configure le second effet pour arrêter le son. Il utilise les objets renvoyés par [Sequence.add_effect](https://reference.aspose.com/slides/fr/python-net/aspose.slides.animation/sequence/add_effect/), de sorte qu'aucun index de séquence n'est requis.

```python
import aspose.slides as slides


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    first_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 80, 100, 240, 80)
    second_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 400, 100, 240, 80)
    first_shape.text_frame.text = "Starts sound"
    second_shape.text_frame.text = "Stops sound"

    sequence = slide.timeline.main_sequence
    first_effect = sequence.add_effect(first_shape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    second_effect = sequence.add_effect(second_shape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)

    with open("animation-sound.wav", "rb") as audio_file:
        effect_sound = presentation.audios.add_audio(audio_file.read())

    first_effect.sound = effect_sound
    second_effect.stop_previous_sound = True

    presentation.save("shape-animation-sound.pptx", slides.export.SaveFormat.PPTX)
```

### **Extraire les sons intégrés aux effets**

L'exemple suivant s'attend à une présentation locale nommée `presentation-with-animation-sounds.pptx`. Il parcourt les séquences principales et interactives et écrit chaque son d'effet intégré dans le répertoire `extracted-animation-sounds`. L'extension est sélectionnée à partir du type MIME audio exposé par [Audio.content_type](https://reference.aspose.com/slides/fr/python-net/aspose.slides/audio/content_type/).

```python
import os

import aspose.slides as slides


def get_audio_extension(content_type):
    normalized_type = "" if content_type is None else content_type.lower()

    if normalized_type == "audio/mpeg":
        return ".mp3"
    if normalized_type == "audio/mp4":
        return ".m4a"
    if normalized_type == "audio/ogg":
        return ".ogg"
    if normalized_type in ("audio/wav", "audio/x-wav"):
        return ".wav"

    return ".bin"


def save_sounds(sequence, output_directory, sound_index):
    for effect in sequence:
        if effect.sound is None:
            continue

        extension = get_audio_extension(effect.sound.content_type)
        output_path = os.path.join(output_directory, f"effect-sound-{sound_index}{extension}")
        with open(output_path, "wb") as output_file:
            output_file.write(bytes(effect.sound.binary_data))
        sound_index += 1

    return sound_index


input_path = "presentation-with-animation-sounds.pptx"
output_directory = "extracted-animation-sounds"

os.makedirs(output_directory, exist_ok=True)

with slides.Presentation(input_path) as presentation:
    sound_index = 1

    for slide in presentation.slides:
        sound_index = save_sounds(slide.timeline.main_sequence, output_directory, sound_index)

        for sequence in slide.timeline.interactive_sequences:
            sound_index = save_sounds(sequence, output_directory, sound_index)

print(f"Extracted {sound_index - 1} sound file(s) to {os.path.abspath(output_directory)}.")
```

Pour les gros objets audio, utilisez [Audio.get_stream](https://reference.aspose.com/slides/fr/python-net/aspose.slides/audio/get_stream/) et copiez le flux vers un fichier au lieu de charger l'objet complet dans un tableau d'octets.

## **Définir le comportement après l'animation**

L'option **After animation** contrôle ce qui arrive à une forme après la fin de son effet.

![Boîte de dialogue Options d'effet PowerPoint affichant les paramètres After animation](shape-after-animation.png)

L'énumération [AfterAnimationType](https://reference.aspose.com/slides/fr/python-net/aspose.slides.animation/afteranimationtype/) prend en charge le fait de laisser la forme inchangée, de changer sa couleur, de la masquer après l'animation, ou de la masquer au clic suivant. Lorsque le type est [AfterAnimationType.COLOR](https://reference.aspose.com/slides/fr/python-net/aspose.slides.animation/afteranimationtype/), définissez également [Effect.after_animation_color](https://reference.aspose.com/slides/fr/python-net/aspose.slides.animation/effect/after_animation_color/).

Cet exemple indépendant crée un effet, définit son comportement après l'animation via l'objet effet renvoyé, et enregistre le résultat.

```python
import aspose.pydrawing as draw
import aspose.slides as slides


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 120, 100, 320, 80)
    shape.text_frame.text = "Dim after animation"

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.after_animation_type = slides.animation.AfterAnimationType.COLOR
    effect.after_animation_color.color = draw.Color.light_gray

    presentation.save("shape-animation-after-effect.pptx", slides.export.SaveFormat.PPTX)
```

Modifier le type en dehors de [AfterAnimationType.COLOR](https://reference.aspose.com/slides/fr/python-net/aspose.slides.animation/afteranimationtype/) supprime le paramètre de couleur après l'animation.

## **Animer du texte**

L'animation de texte possède deux contrôles associés :

- [TextAnimation.build_type](https://reference.aspose.com/slides/fr/python-net/aspose.slides.animation/textanimation/build_type/) contrôle si les paragraphes apparaissent ensemble ou au niveau du paragraphe.
- [Effect.animate_text_type](https://reference.aspose.com/slides/fr/python-net/aspose.slides.animation/effect/animate_text_type/) contrôle si le texte apparaît d'un seul coup, mot par mot, ou lettre par lettre. [Effect.delay_between_text_parts](https://reference.aspose.com/slides/fr/python-net/aspose.slides.animation/effect/delay_between_text_parts/) définit le délai entre les mots ou les lettres. Une valeur positive représente un pourcentage de la durée de l'effet ; une valeur négative correspond à un délai en secondes.

L'exemple indépendant suivant anime les mots dans une zone de texte. [BuildType.AS_ONE_OBJECT](https://reference.aspose.com/slides/fr/python-net/aspose.slides.animation/buildtype/) désactive la construction paragraphe par paragraphe afin que le paramètre de mot s'applique à l'ensemble du cadre de texte.

```python
import aspose.slides as slides


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    text_box = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 80, 80, 560, 100)
    text_box.text_frame.text = "Aspose.Slides animates this sentence word by word."

    effect = slide.timeline.main_sequence.add_effect(text_box, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.text_animation.build_type = slides.animation.BuildType.AS_ONE_OBJECT
    effect.animate_text_type = slides.animation.AnimateTextType.BY_WORD
    effect.delay_between_text_parts = 20.0

    presentation.save("animated-text.pptx", slides.export.SaveFormat.PPTX)
```

Pour construire une zone de texte paragraphe par paragraphe, définissez [BuildType.BY_LEVEL_PARAGRAPHS1](https://reference.aspose.com/slides/fr/python-net/aspose.slides.animation/buildtype/) (ou un autre niveau de paragraphe). Pour cibler un seul paragraphe avec son propre effet, utilisez la surcharge de [Sequence.add_effect](https://reference.aspose.com/slides/fr/python-net/aspose.slides.animation/sequence/add_effect/) qui accepte un [IParagraph](https://reference.aspose.com/slides/fr/python-net/aspose.slides/iparagraph/). Voir [Texte animé](/slides/fr/python-net/animated-text/) pour des exemples au niveau du paragraphe.

## **Notes d'exportation et de compatibilité**

- Enregistrer en PPT ou PPTX préserve le modèle d'animation, mais la lecture finale est contrôlée par le visualiseur de présentation.
- Les PDF et les images statiques ne lisent pas les animations. Utilisez [Exportation HTML5](/slides/fr/python-net/export-to-html5/), GIF animé, ou [conversion vidéo](/slides/fr/python-net/convert-powerpoint-to-video/) lorsque la sortie doit montrer du mouvement.
- Pour HTML5, activez [Html5Options.animate_shapes] et, si nécessaire, [Html5Options.animate_transitions].
- Le rendu vidéo prend en charge de nombreux effets d'entrée, d'emphase, de sortie et de trajectoire, mais tous les effets PowerPoint ne sont pas supportés. Vérifiez les [animations et effets pris en charge](/slides/fr/python-net/convert-powerpoint-to-video/#supported-animations-and-effects) actuels et testez les présentations critiques avec la version cible d'Aspose.Slides.
- Les effets personnalisés avancés et les effets importés d'autres formats de présentation peuvent être conservés dans le fichier mais rendus différemment dans PowerPoint, HTML5 ou vidéo. Validez le résultat exporté plutôt que de vous fier uniquement au nom de l'effet.

## **FAQ**

**Pourquoi une animation apparaît‑elle dans PowerPoint mais pas dans un PDF ?**

Le PDF est un format statique, donc les animations et les transitions de diapositive ne sont pas lues. Exportez vers HTML5, GIF animé ou vidéo lorsque le mouvement doit être conservé.

**Pourquoi un effet est‑il lu différemment dans une vidéo ?**

L'exportation vidéo rend les animations plutôt que de stocker le comportement PowerPoint original. Certains effets avancés ne sont pas pris en charge ou sont approximés. Consultez le tableau des effets pris en charge et testez la présentation réelle avant une utilisation en production.

**Déplacer une forme vers l'avant ou vers l'arrière change‑t‑il son ordre d'animation ?**

Non. L'ordre Z de la forme contrôle le chevauchement, tandis que l'ordre des séquences et les déclencheurs contrôlent la lecture des animations. Modifiez la chronologie si vous avez besoin d'un ordre de lecture différent.