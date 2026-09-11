---
title: "Appliquer des animations de forme dans les présentations en utilisant Python via Java"
linktitle: "Animation de forme"
type: docs
weight: 60
url: /fr/python-java/shape-animation/
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
- son effet
- appliquer animation
- PowerPoint
- présentation
- Python
- Java
- Aspose.Slides
description: "Découvrez comment ajouter, inspecter et personnaliser les animations de forme, la synchronisation, les sons, le comportement après l'animation et le texte animé avec Aspose.Slides pour Python via Java."
---
## **Vue d'ensemble**

Aspose.Slides for Python via Java représente les animations de diapositive sous forme d’effets dans une chronologie de diapositive. Un effet possède une forme cible, un type et sous‑type d’animation, un déclencheur, des paramètres de synchronisation et des propriétés optionnelles telles que le son ou le comportement après l’animation.

La chronologie contient deux types de séquences :

- La **séquence principale** s’exécute au fur et à mesure que la diapositive progresse.
- Une **séquence interactive** démarre lorsque sa forme déclencheur est cliquée.

Comme les zones de texte, images, graphiques, tableaux et autres objets de diapositive dérivent de [Shape](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shape/), vous utilisez la même méthode [Sequence.addEffect](https://reference.aspose.com/slides/fr/python-java/aspose.slides/sequence/#addEffect) pour la plupart du contenu de diapositive. Les effets disponibles sont répertoriés dans la classe [EffectType](https://reference.aspose.com/slides/fr/python-java/aspose.slides/effecttype/).

## **Ajouter des animations de forme**

Pour ajouter une animation, récupérez la séquence principale de la diapositive et appelez [Sequence.addEffect](https://reference.aspose.com/slides/fr/python-java/aspose.slides/sequence/#addEffect) avec la forme cible, le type d’effet, le sous‑type et le déclencheur. Pour un effet qui démarre lorsqu’une autre forme est cliquée, créez une séquence interactive dont le déclencheur est cette autre forme.

L’exemple suivant crée les deux types d’animation et enregistre le résultat dans `shape-animations.pptx`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    target_shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 120, 100, 320, 80)
    target_shape.addTextFrame("Click to animate this shape")

    main_sequence = slide.getTimeline().getMainSequence()
    entrance_effect = main_sequence.addEffect(target_shape, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)
    entrance_effect.getTiming().setDuration(1.5)

    trigger_shape = slide.getShapes().addAutoShape(ShapeType.Bevel, 20, 20, 100, 40)
    trigger_shape.addTextFrame("Move")

    interactive_sequence = slide.getTimeline().getInteractiveSequences().add(trigger_shape)
    interactive_sequence.addEffect(target_shape, EffectType.PathFootball, EffectSubtype.None_, EffectTriggerType.OnClick)

    presentation.save("shape-animations.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Le déclencheur contrôle le moment où un effet démarre :

- [EffectTriggerType.OnClick](https://reference.aspose.com/slides/fr/python-java/aspose.slides/effecttriggertype/#OnClick) attend un clic dans la séquence principale, ou un clic sur la forme déclencheur dans une séquence interactive.
- [EffectTriggerType.WithPrevious](https://reference.aspose.com/slides/fr/python-java/aspose.slides/effecttriggertype/#WithPrevious) démarre avec l’effet précédent.
- [EffectTriggerType.AfterPrevious](https://reference.aspose.com/slides/fr/python-java/aspose.slides/effecttriggertype/#AfterPrevious) démarre lorsque l’effet précédent se termine.

Pour animer une image, un graphique ou un autre type de forme, transmettez cet objet à [Sequence.addEffect](https://reference.aspose.com/slides/fr/python-java/aspose.slides/sequence/#addEffect) au lieu de `target_shape`. Pour les options de groupement spécifiques aux graphiques, consultez [Animated Charts](/slides/fr/python-java/animated-charts/).

## **Lire les animations de forme**

Utilisez [Sequence.getEffectsByShape](https://reference.aspose.com/slides/fr/python-java/aspose.slides/sequence/#getEffectsByShape) lorsque vous connaissez la forme cible. Pour inspecter chaque effet, parcourez la séquence principale et chaque séquence interactive. L’énumération évite de supposer qu’une séquence contient un effet à l’index `0`.

L’exemple suivant crée une forme avec des effets de séquence principale et interactive, récupère les effets qui ciblent la forme, puis parcourt chaque séquence de la diapositive.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Presentation, ShapeType

def print_sequence(label, sequence):
    print(f"  {label}: {sequence.getCount()} effect(s)")
    for effect in sequence:
        target_shape = effect.getTargetShape()
        target_name = "unknown" if target_shape is None else target_shape.getName()
        type_name = EffectType.getName(EffectType.class_, effect.getType())
        subtype_name = EffectSubtype.getName(EffectSubtype.class_, effect.getSubtype())
        trigger_name = EffectTriggerType.getName(EffectTriggerType.class_, effect.getTiming().getTriggerType())
        effect_description = f"{type_name} {subtype_name}; target: {target_name}; trigger: {trigger_name}"
        print(f"    {effect_description}")


presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    target_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 120, 100, 320, 80)
    target_shape.addTextFrame("Animated shape")

    main_sequence = slide.getTimeline().getMainSequence()
    main_sequence.addEffect(target_shape, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)

    trigger_shape = slide.getShapes().addAutoShape(ShapeType.Bevel, 20, 20, 100, 40)
    trigger_shape.addTextFrame("Move")

    interactive_sequence = slide.getTimeline().getInteractiveSequences().add(trigger_shape)
    interactive_sequence.addEffect(target_shape, EffectType.PathFootball, EffectSubtype.None_, EffectTriggerType.OnClick)

    target_effects = main_sequence.getEffectsByShape(target_shape)
    print(f"The main sequence contains {len(target_effects)} effect(s) for {target_shape.getName()}.")
    print_sequence("Main sequence", main_sequence)

    for interactive_index, sequence in enumerate(slide.getTimeline().getInteractiveSequences(), start=1):
        trigger_shape = sequence.getTriggerShape()
        trigger_name = "unknown" if trigger_shape is None else trigger_shape.getName()
        sequence_label = f"Interactive sequence {interactive_index}, trigger: {trigger_name}"
        print_sequence(sequence_label, sequence)
finally:
    presentation.dispose()
```

Si vous n’avez besoin que des effets pour une seule forme, identifiez d’abord la forme par son nom, son type de zone réservée ou une autre propriété stable ; puis appelez [Sequence.getEffectsByShape](https://reference.aspose.com/slides/fr/python-java/aspose.slides/sequence/#getEffectsByShape). Ne supposez pas que [ShapeCollection.get_Item](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shapecollection/#get_Item) à l’index `0` soit toujours l’objet souhaité.

## **Travailler avec les effets d’espace réservé hérité**

Un espace réservé sur une diapositive normale peut hériter du comportement d’animation de l’espace réservé correspondant sur la diapositive de disposition et la diapositive principale. [Shape.getBasePlaceholder](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shape/#getBasePlaceholder) renvoie cet espace réservé parent, ou `None` lorsqu’il n’existe pas.

Dans la présentation d’exemple suivante, le pied de page possède **Random Bars** sur la diapositive normale, **Split** sur la diapositive de disposition et **Fly In** sur la diapositive principale.

![Effet d'animation du pied de page sur la diapositive normale](slide-shape-animation.png)

![Effet d'animation du pied de page sur la diapositive de disposition](layout-shape-animation.png)

![Effet d'animation du pied de page sur la diapositive principale](master-shape-animation.png)

L’exemple suivant utilise une hiérarchie d’espace réservé provenant d’une nouvelle présentation. Il ajoute des effets à un espace réservé principal, à un espace réservé de disposition et à l’espace réservé correspondant sur une diapositive normale. Chaque appel à [Shape.getBasePlaceholder](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shape/#getBasePlaceholder) est vérifié avant d’utiliser la forme retournée.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, SlideLayoutType

def find_placeholder_with_base(slide, expected_base=None):
    for shape in slide.getShapes():
        base_placeholder = shape.getBasePlaceholder()
        if base_placeholder is not None and (expected_base is None or base_placeholder == expected_base):
            return shape
    return None


def print_effects(source, effects):
    print(f"{source}: {len(effects)} effect(s)")
    for effect in effects:
        type_name = EffectType.getName(EffectType.class_, effect.getType())
        subtype_name = EffectSubtype.getName(EffectSubtype.class_, effect.getSubtype())
        print(f"  {type_name} {subtype_name}")


presentation = Presentation()
try:
    layout_slide = presentation.getLayoutSlides().getByType(SlideLayoutType.TitleAndObject)
    layout_placeholder = find_placeholder_with_base(layout_slide) if layout_slide is not None else None
    if layout_placeholder is None:
        print("The layout slide does not contain a placeholder linked to its master slide.")
    else:
        master_placeholder = layout_placeholder.getBasePlaceholder()
        layout_slide.getMasterSlide().getTimeline().getMainSequence().addEffect(master_placeholder, EffectType.Fly, EffectSubtype.Bottom, EffectTriggerType.OnClick)
        layout_slide.getTimeline().getMainSequence().addEffect(layout_placeholder, EffectType.Split, EffectSubtype.VerticalIn, EffectTriggerType.OnClick)

        slide = presentation.getSlides().addEmptySlide(layout_slide)
        slide_placeholder = find_placeholder_with_base(slide, layout_placeholder)
        if slide_placeholder is None:
            print("The slide does not contain a placeholder linked to its layout slide.")
        else:
            slide.getTimeline().getMainSequence().addEffect(slide_placeholder, EffectType.RandomBars, EffectSubtype.Horizontal, EffectTriggerType.OnClick)
            slide_effects = slide.getTimeline().getMainSequence().getEffectsByShape(slide_placeholder)
            print_effects("Normal slide", slide_effects)

            base_layout_placeholder = slide_placeholder.getBasePlaceholder()
            if base_layout_placeholder is not None:
                layout_effects = layout_slide.getTimeline().getMainSequence().getEffectsByShape(base_layout_placeholder)
                print_effects("Layout slide", layout_effects)

                base_master_placeholder = base_layout_placeholder.getBasePlaceholder()
                if base_master_placeholder is not None:
                    master_effects = layout_slide.getMasterSlide().getTimeline().getMainSequence().getEffectsByShape(base_master_placeholder)
                    print_effects("Master slide", master_effects)

            presentation.save("placeholder-animations.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Modifier la synchronisation des animations**

La boîte de dialogue PowerPoint **Timing** correspond aux propriétés de [Timing](https://reference.aspose.com/slides/fr/python-java/aspose.slides/timing/).

![Boîte de dialogue Timing de PowerPoint pour un effet d'animation](shape-animation.png)

- **Start** correspond à [Timing.getTriggerType](https://reference.aspose.com/slides/fr/python-java/aspose.slides/timing/#getTriggerType).
- **Duration** correspond à [Timing.getDuration](https://reference.aspose.com/slides/fr/python-java/aspose.slides/timing/#getDuration), en secondes.
- **Delay** correspond à [Timing.getTriggerDelayTime](https://reference.aspose.com/slides/fr/python-java/aspose.slides/timing/#getTriggerDelayTime), en secondes.
- **Repeat** correspond à [Timing.getRepeatCount](https://reference.aspose.com/slides/fr/python-java/aspose.slides/timing/#getRepeatCount), [Timing.getRepeatUntilNextClick](https://reference.aspose.com/slides/fr/python-java/aspose.slides/timing/#getRepeatUntilNextClick) ou [Timing.getRepeatUntilEndSlide](https://reference.aspose.com/slides/fr/python-java/aspose.slides/timing/#getRepeatUntilEndSlide).
- **Rewind when done playing** correspond à [Timing.getRewind](https://reference.aspose.com/slides/fr/python-java/aspose.slides/timing/#getRewind).

Cet exemple autonome ajoute un effet, modifie sa synchronisation via l’objet retourné par [Sequence.addEffect](https://reference.aspose.com/slides/fr/python-java/aspose.slides/sequence/#addEffect) et enregistre le résultat. Conserver la référence à l’objet [Effect](https://reference.aspose.com/slides/fr/python-java/aspose.slides/effect/) retourné évite un indice de collection inutile.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 120, 100, 320, 80)
    shape.addTextFrame("Timed animation")

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getTiming().setTriggerType(EffectTriggerType.OnClick)
    effect.getTiming().setDuration(2.0)
    effect.getTiming().setTriggerDelayTime(0.5)
    effect.getTiming().setRepeatUntilNextClick(False)
    effect.getTiming().setRepeatUntilEndSlide(False)
    effect.getTiming().setRepeatCount(2.0)
    effect.getTiming().setRewind(True)

    presentation.save("shape-animation-timing.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Utilisez un seul mode de répétition intentionnellement. Combiner un nombre de répétitions avec un drapeau « until » peut produire des résultats déroutants selon le visualiseur. Lors du changement de modes de répétition, appelez [Timing.setRepeatUntilNextClick](https://reference.aspose.com/slides/fr/python-java/aspose.slides/timing/#setRepeatUntilNextClick) et [Timing.setRepeatUntilEndSlide](https://reference.aspose.com/slides/fr/python-java/aspose.slides/timing/#setRepeatUntilEndSlide) avant [Timing.setRepeatCount](https://reference.aspose.com/slides/fr/python-java/aspose.slides/timing/#setRepeatCount), car la définition de l’un des drapeaux modifie également le mode de répétition actif.

## **Ajouter et extraire les sons d’animation**

Un effet d’animation peut référencer un audio intégré via [Effect.getSound](https://reference.aspose.com/slides/fr/python-java/aspose.slides/effect/#getSound). [Effect.setStopPreviousSound](https://reference.aspose.com/slides/fr/python-java/aspose.slides/effect/#setStopPreviousSound) indique à un effet d’arrêter le son démarré par un effet antérieur.

### **Ajouter un son à un effet**

L’exemple suivant suppose un fichier audio local nommé `animation-sound.wav`. Il crée deux effets, intègre ce fichier comme son du premier effet et configure le second effet pour arrêter le son. Il utilise les objets retournés par [Sequence.addEffect](https://reference.aspose.com/slides/fr/python-java/aspose.slides/sequence/#addEffect), aucune indexation de séquence n’est requise.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, ShapeType
from pathlib import Path

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    first_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 100, 240, 80)
    second_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 400, 100, 240, 80)
    first_shape.addTextFrame("Starts sound")
    second_shape.addTextFrame("Stops sound")

    sequence = slide.getTimeline().getMainSequence()
    first_effect = sequence.addEffect(first_shape, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)
    second_effect = sequence.addEffect(second_shape, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)

    audio_data = Path("animation-sound.wav").read_bytes()
    effect_sound = presentation.getAudios().addAudio(jpype.JArray(jpype.JByte)(audio_data))
    first_effect.setSound(effect_sound)
    second_effect.setStopPreviousSound(True)

    presentation.save("shape-animation-sound.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Extraire les sons d’effet intégrés**

L’exemple suivant suppose une présentation locale nommée `presentation-with-animation-sounds.pptx`. Il parcourt les séquences principales et interactives et écrit chaque son d’effet intégré dans le répertoire `extracted-animation-sounds`. L’extension est choisie à partir du type MIME audio exposé par [Audio.getContentType](https://reference.aspose.com/slides/fr/python-java/aspose.slides/audio/#getContentType).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation
from pathlib import Path

def get_audio_extension(content_type):
    normalized_type = "" if content_type is None else str(content_type).lower()
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
        sound = effect.getSound()
        if sound is None:
            continue
        extension = get_audio_extension(sound.getContentType())
        output_path = output_directory / f"effect-sound-{sound_index}{extension}"
        audio_data = bytes(sound.getBinaryData())
        output_path.write_bytes(audio_data)
        sound_index += 1
    return sound_index


input_path = Path("presentation-with-animation-sounds.pptx")
output_directory = Path("extracted-animation-sounds")
output_directory.mkdir(parents=True, exist_ok=True)

presentation = Presentation(str(input_path))
try:
    sound_index = 1
    for slide in presentation.getSlides():
        sound_index = save_sounds(slide.getTimeline().getMainSequence(), output_directory, sound_index)
        for sequence in slide.getTimeline().getInteractiveSequences():
            sound_index = save_sounds(sequence, output_directory, sound_index)
    print(f"Extracted {sound_index - 1} sound file(s) to {output_directory.resolve()}.")
finally:
    presentation.dispose()
```

Pour les objets audio volumineux, utilisez [Audio.getStream](https://reference.aspose.com/slides/fr/python-java/aspose.slides/audio/#getStream) et copiez le flux dans un fichier plutôt que de charger l’ensemble de l’objet dans un tableau d’octets.

## **Définir le comportement après l’animation**

L’option **After animation** contrôle ce qui arrive à une forme après la fin de son effet.

![Boîte de dialogue Options d’effet de PowerPoint affichant les paramètres After animation](shape-after-animation.png)

La classe [AfterAnimationType](https://reference.aspose.com/slides/fr/python-java/aspose.slides/afteranimationtype/) prend en charge le maintien de la forme inchangée, le changement de sa couleur, son masquage après l’animation ou son masquage au prochain clic. Lorsque le type est [AfterAnimationType.Color](https://reference.aspose.com/slides/fr/python-java/aspose.slides/afteranimationtype/#Color), définissez également [Effect.getAfterAnimationColor](https://reference.aspose.com/slides/fr/python-java/aspose.slides/effect/#getAfterAnimationColor).

Cet exemple autonome crée un effet, définit son comportement après l’animation via l’objet effet retourné et enregistre le résultat.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AfterAnimationType, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 120, 100, 320, 80)
    shape.addTextFrame("Dim after animation")

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.setAfterAnimationType(AfterAnimationType.Color)
    effect.getAfterAnimationColor().setColor(Color.LIGHT_GRAY)

    presentation.save("shape-animation-after-effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Modifier le type en dehors de [AfterAnimationType.Color](https://reference.aspose.com/slides/fr/python-java/aspose.slides/afteranimationtype/#Color) supprime le paramètre de couleur après l’animation.

## **Animer du texte**

L’animation du texte possède deux contrôles associés :

- [TextAnimation.getBuildType](https://reference.aspose.com/slides/fr/python-java/aspose.slides/textanimation/#getBuildType) contrôle si les paragraphes apparaissent ensemble ou par niveau de paragraphe.
- [Effect.getAnimateTextType](https://reference.aspose.com/slides/fr/python-java/aspose.slides/effect/#getAnimateTextType) contrôle si le texte apparaît d’un seul coup, par mot ou par lettre. [Effect.getDelayBetweenTextParts](https://reference.aspose.com/slides/fr/python-java/aspose.slides/effect/#getDelayBetweenTextParts) définit le délai entre les mots ou les lettres. Une valeur positive est un pourcentage de la durée de l’effet ; une valeur négative est un délai en secondes.

L’exemple autonome suivant anime les mots dans une zone de texte. [BuildType.AsOneObject](https://reference.aspose.com/slides/fr/python-java/aspose.slides/buildtype/#AsOneObject) désactive la construction paragraphe par paragraphe afin que le réglage par mot s’applique à tout le cadre de texte.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AnimateTextType, BuildType, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 560, 100)
    text_box.addTextFrame("Aspose.Slides animates this sentence word by word.")

    effect = slide.getTimeline().getMainSequence().addEffect(text_box, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getTextAnimation().setBuildType(BuildType.AsOneObject)
    effect.setAnimateTextType(AnimateTextType.ByWord)
    effect.setDelayBetweenTextParts(20.0)

    presentation.save("animated-text.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Pour construire une zone de texte paragraphe par paragraphe, définissez [BuildType.ByLevelParagraphs1](https://reference.aspose.com/slides/fr/python-java/aspose.slides/buildtype/#ByLevelParagraphs1) (ou un autre niveau de paragraphe). Pour cibler un seul paragraphe avec son propre effet, utilisez la surcharge de [Sequence.addEffect](https://reference.aspose.com/slides/fr/python-java/aspose.slides/sequence/#addEffect) qui accepte un [Paragraph](https://reference.aspose.com/slides/fr/python-java/aspose.slides/paragraph/). Consultez [Animated Text](/slides/fr/python-java/animated-text/) pour des exemples au niveau du paragraphe.

## **Exportation et notes de compatibilité**

- L’enregistrement en PPT ou PPTX conserve le modèle d’animation, mais la lecture finale dépend du visualiseur de présentation.
- PDF et images statiques ne jouent pas les animations. Utilisez l’[exportation HTML5](/slides/fr/python-java/export-to-html5/), les GIF animés ou la [conversion vidéo](/slides/fr/python-java/convert-powerpoint-to-video/) lorsque le résultat doit montrer le mouvement.
- Pour HTML5, activez [Html5Options.setAnimateShapes](https://reference.aspose.com/slides/fr/python-java/aspose.slides/html5options/#setAnimateShapes) et, si nécessaire, [Html5Options.setAnimateTransitions](https://reference.aspose.com/slides/fr/python-java/aspose.slides/html5options/#setAnimateTransitions).
- Le rendu vidéo prend en charge de nombreux effets d’entrée, d’emphase, de sortie et de trajectoire, mais tous les effets PowerPoint ne sont pas pris en charge. Consultez la page actuelle des [animations et effets pris en charge](/slides/fr/python-java/convert-powerpoint-to-video/#supported-animations-and-effects) et testez les présentations critiques avec votre version cible d’Aspose.Slides.
- Les effets personnalisés avancés et les effets importés d’autres formats de présentation peuvent être conservés dans le fichier mais s’afficher différemment dans PowerPoint, HTML5 ou la vidéo. Validez le résultat exporté plutôt que de vous fier uniquement au nom de l’effet.

## **FAQ**

**Pourquoi une animation apparaît‑elle dans PowerPoint mais pas dans un PDF ?**

PDF est un format statique, les animations et les transitions de diapositive ne sont pas lues. Exportez en HTML5, GIF animé ou vidéo lorsque le mouvement doit être conservé.

**Pourquoi un effet se lit‑il différemment dans une vidéo ?**

L’exportation vidéo rend les animations plutôt que de stocker le comportement PowerPoint d’origine. Certains effets avancés ne sont pas pris en charge ou sont approximés. Consultez le tableau des effets pris en charge et testez la présentation réelle avant une utilisation en production.

**Le fait de déplacer une forme vers l’avant ou l’arrière modifie‑t‑il son ordre d’animation ?**

Non. L’ordre Z de la forme contrôle le chevauchement, tandis que l’ordre des séquences et les déclencheurs contrôlent la lecture des animations. Modifiez la chronologie si vous avez besoin d’un ordre de lecture différent.