---
title: "Créer et modifier des comportements d'animation personnalisés en Python"
linktitle: "Animation personnalisée"
type: docs
weight: 151
url: /fr/python-net/custom-animation/
keywords:
- animation personnalisée
- comportement d'animation
- chemin de mouvement
- PowerPoint
- présentation
- Python
- Aspose.Slides
description: "Créer, inspecter et modifier des comportements d'animation personnalisés et des chemins de mouvement éditables dans les présentations PowerPoint avec Aspose.Slides pour Python via .NET."
---
## **Aperçu**

Les comportements d'animation personnalisés vous permettent de contrôler des opérations individuelles au sein d'un effet d'animation, comme changer une couleur, faire pivoter une forme ou suivre un chemin de mouvement modifiable. Ce guide montre comment créer et combiner des comportements, configurer leur chronométrage, inspecter et modifier les animations existantes, et vérifier que leurs propriétés survivent à l'enregistrement et à la réouverture d'une présentation.

Pour les effets prédéfinis et les déclencheurs de clic, voir [Animation de formes](/slides/fr/python-net/shape-animation/).

## **Comprendre le modèle d'animation**

Une animation est organisée comme **Timeline → Sequence → Effect → Behaviors** :

- La [timeline](https://reference.aspose.com/slides/fr/python-net/aspose.slides/baseslide/timeline/) de la diapositive contient sa séquence principale et ses séquences interactives.
- Une [Sequence](https://reference.aspose.com/slides/fr/python-net/aspose.slides.animation/sequence/) contient des effets, pouvant cibler différentes formes.
- Un [Effect](https://reference.aspose.com/slides/fr/python-net/aspose.slides.animation/effect/) identifie une forme cible, un préréglage, un sous‑type et le chronométrage de l'effet.
- [Effect.behaviors](https://reference.aspose.com/slides/fr/python-net/aspose.slides.animation/effect/behaviors/) contient les opérations qui implémentent l'effet : changement de couleur, déplacement, rotation, définition d'une propriété, etc.

## **Créer des comportements individuels**

Appelez [Sequence.add_effect](https://reference.aspose.com/slides/fr/python-net/aspose.slides.animation/sequence/add_effect/) pour créer un effet et accéder à sa collection de [behaviors](https://reference.aspose.com/slides/fr/python-net/aspose.slides.animation/effect/behaviors/). Un préréglage peut remplir automatiquement cette collection. Conservez ses opérations lors de l'extension du préréglage, ou utilisez [clear](https://reference.aspose.com/slides/fr/python-net/aspose.slides.animation/behaviorcollection/clear/) lorsque vous les remplacez délibérément.

[BehaviorFactory](https://reference.aspose.com/slides/fr/python-net/aspose.slides.animation/behaviorfactory/) crée les huit types de comportements illustrés ci‑dessous. Le mouvement est traité dans [Créer un chemin de mouvement](#build-a-motion-path). Chaque exemple de création est un programme complet ; les exemples d'édition ultérieurs indiquent quel fichier de sortie ils utilisent.

### **Rotation**

Utilisez [create_rotation_effect](https://reference.aspose.com/slides/fr/python-net/aspose.slides.animation/behaviorfactory/create_rotation_effect/) pour créer une rotation. [by](https://reference.aspose.com/slides/fr/python-net/aspose.slides.animation/rotationeffect/by/) spécifie un angle relatif en degrés ; [from_address](https://reference.aspose.com/slides/fr/python-net/aspose.slides.animation/rotationeffect/from_address/) et [to](https://reference.aspose.com/slides/fr/python-net/aspose.slides.animation/rotationeffect/to/) définissent les points de départ et d'arrivée.

L'exemple commence avec un effet Spin, remplace ses opérations de préréglage par un seul comportement de rotation, et donne à cette opération une durée de deux secondes. Un angle relatif de 90 degrés représente un quart de tour à partir de l'orientation initiale de la forme, aucune angle de départ explicite n'est donc nécessaire.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 160, 80)

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.SPIN, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.behaviors.clear()

    factory = slides.animation.BehaviorFactory()
    rotation = factory.create_rotation_effect()
    rotation.by = 90
    rotation.timing.duration = 2

    effect.behaviors.add(rotation)

    presentation.save("rotation.pptx", slides.export.SaveFormat.PPTX)
```

`rotation.pptx` contient une forme et un comportement de rotation. La collection, le chronométrage et les exemples d'édition de rotation ci‑dessous utilisent ce fichier.

### **Échelle**

Utilisez [create_scale_effect](https://reference.aspose.com/slides/fr/python-net/aspose.slides.animation/behaviorfactory/create_scale_effect/) avec des pourcentages X/Y : [from_address](https://reference.aspose.com/slides/fr/python-net/aspose.slides.animation/scaleeffect/from_address/) et [to](https://reference.aspose.com/slides/fr/python-net/aspose.slides.animation/scaleeffect/to/) décrivent la taille de départ et d'arrivée, tandis que [by](https://reference.aspose.com/slides/fr/python-net/aspose.slides.animation/scaleeffect/by/) décrit une variation relative. Ici, 100 représente la taille originale.

L'exemple augmente les deux dimensions de 100 % à 125 % en deux secondes. Utiliser des pourcentages horizontaux et verticaux égaux conserve les proportions de la forme ; des pourcentages différents étireront une dimension davantage que l'autre.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 160, 80)

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.GROW_SHRINK, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.behaviors.clear()

    factory = slides.animation.BehaviorFactory()
    scale = factory.create_scale_effect()
    scale.from_address = draw.PointF(100, 100)
    scale.to = draw.PointF(125, 125)
    scale.timing.duration = 2

    effect.behaviors.add(scale)

    presentation.save("scale.pptx", slides.export.SaveFormat.PPTX)
```

### **Couleur**

Utilisez [create_color_effect](https://reference.aspose.com/slides/fr/python-net/aspose.slides.animation/behaviorfactory/create_color_effect/) pour passer le remplissage du bleu à l'orange. [from_address](https://reference.aspose.com/slides/fr/python-net/aspose.slides.animation/coloreffect/from_address/) et [to](https://reference.aspose.com/slides/fr/python-net/aspose.slides.animation/coloreffect/to/) sont des couleurs ; [by](https://reference.aspose.com/slides/fr/python-net/aspose.slides.animation/coloreffect/by/) est un décalage de couleur. [Behavior.properties](https://reference.aspose.com/slides/fr/python-net/aspose.slides.animation/behavior/properties/) identifie l'attribut animé.

Le remplissage plein de la forme est initialisé en bleu, correspondant à la couleur de départ de l'animation. Sélectionner l'attribut de couleur de remplissage indique au comportement quelle partie de la forme modifier ; les seules couleurs d'extrémité ne définissent pas cet attribut. L'effet enregistré décrit une transition de deux secondes vers l'orange.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 160, 80)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.blue

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.CHANGE_FILL_COLOR, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.behaviors.clear()

    factory = slides.animation.BehaviorFactory()
    color = factory.create_color_effect()
    color.properties.add(slides.animation.BehaviorProperty.fill_color.value)
    color.from_address.color = draw.Color.blue
    color.to.color = draw.Color.orange
    color.timing.duration = 2

    effect.behaviors.add(color)

    presentation.save("color.pptx", slides.export.SaveFormat.PPTX)
```

### **Filtre**

Utilisez [create_filter_effect](https://reference.aspose.com/slides/fr/python-net/aspose.slides.animation/behaviorfactory/create_filter_effect/) pour sélectionner un essuyage. [type](https://reference.aspose.com/slides/fr/python-net/aspose.slides.animation/filtereffect/type/), [subtype](https://reference.aspose.com/slides/fr/python-net/aspose.slides.animation/filtereffect/subtype/), et [reveal](https://reference.aspose.com/slides/fr/python-net/aspose.slides.animation/filtereffect/reveal/) spécifient le filtre, la direction et si le filtre doit révéler ou masquer la forme.

Cet exemple configure un essuyage de deux secondes qui révèle la forme en utilisant le sous‑type direction droite. Les paramètres du filtre appartiennent au comportement à l'intérieur de l'effet, ils sont donc configurés après que les opérations originales du préréglage aient été supprimées.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 160, 80)

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.WIPE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.behaviors.clear()

    factory = slides.animation.BehaviorFactory()
    filter_behavior = factory.create_filter_effect()
    filter_behavior.type = slides.animation.FilterEffectType.WIPE
    filter_behavior.subtype = slides.animation.FilterEffectSubtype.RIGHT
    filter_behavior.reveal = slides.animation.FilterEffectRevealType.IN
    filter_behavior.timing.duration = 2

    effect.behaviors.add(filter_behavior)

    presentation.save("filter.pptx", slides.export.SaveFormat.PPTX)
```

### **Propriété**

Utilisez [create_property_effect](https://reference.aspose.com/slides/fr/python-net/aspose.slides.animation/behaviorfactory/create_property_effect/) pour animer l'opacité. [from_address](https://reference.aspose.com/slides/fr/python-net/aspose.slides.animation/propertyeffect/from_address/), [to](https://reference.aspose.com/slides/fr/python-net/aspose.slides.animation/propertyeffect/to/), et [by](https://reference.aspose.com/slides/fr/python-net/aspose.slides.animation/propertyeffect/by/) sont des chaînes interprétées à l'aide de [value_type](https://reference.aspose.com/slides/fr/python-net/aspose.slides.animation/propertyeffect/value_type/) et [calc_mode](https://reference.aspose.com/slides/fr/python-net/aspose.slides.animation/propertyeffect/calc_mode/). Choisissez des extrémités ou un décalage relatif plutôt que de définir les trois simultanément.

Ici, l'attribut sélectionné est l'opacité, et les chaînes numériques représentent une variation de 25 % d'opacité à une opacité totale. L'interpolation linéaire décrit une transition graduelle entre ces valeurs. En adaptant cet exemple à un autre attribut, choisissez un type de valeur et des valeurs d'extrémité appropriés à cet attribut.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 160, 80)

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.behaviors.clear()

    factory = slides.animation.BehaviorFactory()
    property_behavior = factory.create_property_effect()
    property_behavior.properties.add(slides.animation.BehaviorProperty.style_opacity.value)
    property_behavior.value_type = slides.animation.PropertyValueType.NUMBER
    property_behavior.calc_mode = slides.animation.PropertyCalcModeType.LINEAR
    property_behavior.from_address = "0.25"
    property_behavior.to = "1"
    property_behavior.timing.duration = 2

    effect.behaviors.add(property_behavior)

    presentation.save("property.pptx", slides.export.SaveFormat.PPTX)
```

### **Définir**

Utilisez [create_set_effect](https://reference.aspose.com/slides/fr/python-net/aspose.slides.animation/behaviorfactory/create_set_effect/) pour attribuer la visibilité via [to](https://reference.aspose.com/slides/fr/python-net/aspose.slides.animation/seteffect/to/). Un comportement de type *set* n'interpole pas entre les extrémités.

L'exemple sélectionne l'attribut de visibilité et affecte la chaîne `visible` lorsque le comportement s'exécute. Le rectangle est déjà visible dans cette présentation minimale, de sorte que l'affectation ne produit pas de changement visuel évident à elle seule. Une telle opération est utile dans le cadre d'un effet plus large qui contrôle également le moment où la forme devient cachée ou visible.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 160, 80)

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.APPEAR, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.behaviors.clear()

    factory = slides.animation.BehaviorFactory()
    set_behavior = factory.create_set_effect()
    set_behavior.properties.add(slides.animation.BehaviorProperty.style_visibility.value)
    set_behavior.to = "visible"

    effect.behaviors.add(set_behavior)

    presentation.save("set.pptx", slides.export.SaveFormat.PPTX)
```

### **Commande**

Utilisez [create_command_effect](https://reference.aspose.com/slides/fr/python-net/aspose.slides.animation/behaviorfactory/create_command_effect/) et configurez [type](https://reference.aspose.com/slides/fr/python-net/aspose.slides.animation/commandeffect/type/), [command_string](https://reference.aspose.com/slides/fr/python-net/aspose.slides.animation/commandeffect/command_string/), et [shape_target](https://reference.aspose.com/slides/fr/python-net/aspose.slides.animation/commandeffect/shape_target/). Placez un enregistrement WAV nommé `sample.wav` dans le répertoire de travail. Cet exemple l'intègre avec [add_audio_frame_embedded](https://reference.aspose.com/slides/fr/python-net/aspose.slides/shapecollection/add_audio_frame_embedded/) et attache une commande de lecture au cadre audio.

Le cadre audio est à la fois la cible de l'effet et la cible de la commande. Cela relie la demande de lecture à l'enregistrement intégré ; une simple chaîne de commande ne spécifie pas quel objet multimédia contrôler. L'effet est configuré pour démarrer lors d'un clic pendant le diaporama.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("sample.wav", "rb") as audio_stream:
        audio_frame = slide.shapes.add_audio_frame_embedded(100, 100, 40, 40, audio_stream)

    effect = slide.timeline.main_sequence.add_effect(audio_frame, slides.animation.EffectType.MEDIA_PLAY, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.behaviors.clear()

    factory = slides.animation.BehaviorFactory()
    command = factory.create_command_effect()
    command.type = slides.animation.CommandEffectType.CALL
    command.command_string = "play"
    command.shape_target = audio_frame

    effect.behaviors.add(command)

    presentation.save("command.pptx", slides.export.SaveFormat.PPTX)
```

L'enregistrement stocke la commande dans `command.pptx` ; il ne lit pas l'enregistrement. La lecture nécessite un lecteur de diaporama qui prend en charge la commande et sa cible multimédia.

## **Gérer la collection de comportements**

[BehaviorCollection](https://reference.aspose.com/slides/fr/python-net/aspose.slides.animation/behaviorcollection/) prend en charge [add](https://reference.aspose.com/slides/fr/python-net/aspose.slides.animation/behaviorcollection/add/), [insert](https://reference.aspose.com/slides/fr/python-net/aspose.slides.animation/behaviorcollection/insert/), [remove](https://reference.aspose.com/slides/fr/python-net/aspose.slides.animation/behaviorcollection/remove/), et [remove_at](https://reference.aspose.com/slides/fr/python-net/aspose.slides.animation/behaviorcollection/remove_at/). Cet exemple ouvre `rotation.pptx`, ajoute une mise à l'échelle, la déplace avant la rotation, et supprime la rotation. Supprimer et réinsérer le même objet change sa position stockée sans en créer une copie.

La séquence d'éditions transforme la collection de rotation‑scale en scale‑rotation, puis en scale uniquement. Les indices font référence à la collection actuelle, ainsi la suppression utilise le nouvel indice de la rotation après le ré‑ordonnancement. L'énumération finale confirme quel comportement sera enregistré.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("rotation.pptx") as presentation:
    effect = presentation.slides[0].timeline.main_sequence[0]
    behaviors = effect.behaviors

    factory = slides.animation.BehaviorFactory()
    scale = factory.create_scale_effect()
    scale.to = draw.PointF(125, 125)
    scale.timing.duration = 2

    behaviors.add(scale)
    behaviors.remove(scale)
    behaviors.insert(0, scale)
    behaviors.remove_at(1)

    for behavior in behaviors:
        print(type(behavior).__name__)

    presentation.save("collection-edited.pptx", slides.export.SaveFormat.PPTX)
```

Le résultat est `ScaleEffect` : seule la mise à l'échelle demeure. L'ordre de la collection n'ordonne pas les comportements les uns après les autres. Videz la collection uniquement lorsque vous remplacez toutes ses opérations.

## **Configurer le chronométrage des comportements**

[Behavior.timing](https://reference.aspose.com/slides/fr/python-net/aspose.slides.animation/behavior/timing/) expose [Timing](https://reference.aspose.com/slides/fr/python-net/aspose.slides.animation/timing/), indépendamment de [Effect.timing](https://reference.aspose.com/slides/fr/python-net/aspose.slides.animation/effect/timing/). Le chronométrage d'un effet planifie l'effet englobant ; le chronométrage d'un comportement décrit une opération à l'intérieur de celui‑ci.

### **Définir la durée, le délai, la répétition et l'accélération**

Ouvrez `rotation.pptx` et définissez [duration](https://reference.aspose.com/slides/fr/python-net/aspose.slides.animation/timing/duration/) et [trigger_delay_time](https://reference.aspose.com/slides/fr/python-net/aspose.slides.animation/timing/trigger_delay_time/) en secondes, puis configurez [repeat_count](https://reference.aspose.com/slides/fr/python-net/aspose.slides.animation/timing/repeat_count/). [accelerate](https://reference.aspose.com/slides/fr/python-net/aspose.slides.animation/timing/accelerate/) et [decelerate](https://reference.aspose.com/slides/fr/python-net/aspose.slides.animation/timing/decelerate/) sont des fractions de la durée ; leur somme doit être au plus 1.

Le fichier d'entrée est celui créé dans l'exemple de rotation, où le premier comportement est connu comme étant une rotation. Cet exemple ne modifie que le chronométrage de ce comportement ; son angle de 90 degrés reste intact. Séparer l'angle et le chronométrage facilite l'ajustement du rythme sans refaire l'animation.

```python
import aspose.slides as slides

with slides.Presentation("rotation.pptx") as presentation:
    effect = presentation.slides[0].timeline.main_sequence[0]

    rotation = effect.behaviors[0]
    rotation.timing.duration = 2
    rotation.timing.trigger_delay_time = 0.5
    rotation.timing.repeat_count = 3
    rotation.timing.accelerate = 0.2
    rotation.timing.decelerate = 0.2

    presentation.save("timing.pptx", slides.export.SaveFormat.PPTX)
```

Le comportement utilise une durée de deux secondes, un délai de demi‑seconde et un nombre de répétitions de 3. Les 20 % initiaux et finaux de sa durée sont utilisés pour l'accélération et la décélération.

D'autres politiques de répétition incluent [repeat_duration](https://reference.aspose.com/slides/fr/python-net/aspose.slides.animation/timing/repeat_duration/), [repeat_until_end_slide](https://reference.aspose.com/slides/fr/python-net/aspose.slides.animation/timing/repeat_until_end_slide/), et [repeat_until_next_click](https://reference.aspose.com/slides/fr/python-net/aspose.slides.animation/timing/repeat_until_next_click/); choisissez une politique plutôt que de les activer toutes. [auto_reverse](https://reference.aspose.com/slides/fr/python-net/aspose.slides.animation/timing/auto_reverse/) joue l'animation à l'envers après le passage en avant. L'accélération et la décélération s'appliquent aux changements continus, pas aux affectations discrètes ou aux commandes.

## **Créer un chemin de mouvement**

Utilisez [create_motion_effect](https://reference.aspose.com/slides/fr/python-net/aspose.slides.animation/behaviorfactory/create_motion_effect/) pour créer un mouvement. Ses [from_address](https://reference.aspose.com/slides/fr/python-net/aspose.slides.animation/motioneffect/from_address/), [to](https://reference.aspose.com/slides/fr/python-net/aspose.slides.animation/motioneffect/to/), et [by](https://reference.aspose.com/slides/fr/python-net/aspose.slides.animation/motioneffect/by/) décrivent des coordonnées ou des décalages basés sur des pourcentages. Pour une route modifiable, créez un [MotionPath](https://reference.aspose.com/slides/fr/python-net/aspose.slides.animation/motionpath/) et assignez‑le à [MotionEffect.path](https://reference.aspose.com/slides/fr/python-net/aspose.slides.animation/motioneffect/path/). [MotionPath](https://reference.aspose.com/slides/fr/python-net/aspose.slides.animation/motionpath/) stocke les commandes de chemin.

[MotionCommandPathType](https://reference.aspose.com/slides/fr/python-net/aspose.slides.animation/motioncommandpathtype/) sélectionne l'opération :

| Commande | Points | Signification |
| --- | --- | --- |
| MOVE_TO | Un | Définir la position de départ. |
| LINE_TO | Un | Se déplacer le long d'un segment droit jusqu'à son point final. |
| CURVE_TO | Trois | Suivre une courbe cubique définie par deux points de contrôle et un point final. |
| CLOSE_LOOP | Aucun | Retourner à la position de départ. |
| END | Aucun | Terminer le chemin. |

[MotionPathPointsType](https://reference.aspose.com/slides/fr/python-net/aspose.slides.animation/motionpathpointstype/) décrit les caractéristiques d'édition des points, comme les points d'angle ou lisses. Il ne remplace pas le type de commande. Utilisez un type de point courbe pour l'exemple de courbe ci‑dessous, et un type de point coin pour les segments droits.

Les coordonnées du chemin sont normalisées aux dimensions de la diapositive : un déplacement X de 0,25 représente un quart de la largeur de la diapositive, pas 0,25 point. L'axe Y positif descend. Les commandes absolues spécifient des positions dans le système de coordonnées du chemin ; les commandes relatives spécifient des décalages depuis la position actuelle. Cela est distinct de [origin](https://reference.aspose.com/slides/fr/python-net/aspose.slides.animation/motioneffect/origin/), qui sélectionne le cadre de référence du chemin, et de [path_edit_mode](https://reference.aspose.com/slides/fr/python-net/aspose.slides.animation/motioneffect/path_edit_mode/), qui contrôle comment le chemin se déplace lorsqu'on déplace la forme.

### **Créer un chemin droit**

Créez un comportement de mouvement avec un point de départ, un segment droit, et une commande de fin. [MotionPath.add](https://reference.aspose.com/slides/fr/python-net/aspose.slides.animation/motionpath/add/) prend le type de commande, ses points, le type de point, et un indicateur de coordonnées relatives.

La commande de départ établit (0, 0), et la ligne se termine à (0.25, 0), donnant à la route un déplacement horizontal d’un quart de la largeur de la diapositive. La commande de fin n’a aucun point de coordonnées. Une fois le chemin assigné, l’ajout du comportement de mouvement à l’effet relie cette route au rectangle.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 160, 80)

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.PATH_RIGHT, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.behaviors.clear()

    factory = slides.animation.BehaviorFactory()
    motion = factory.create_motion_effect()
    motion.origin = slides.animation.MotionOriginType.LAYOUT
    motion.timing.duration = 2

    path = slides.animation.MotionPath()
    path.add(slides.animation.MotionCommandPathType.MOVE_TO, [draw.PointF(0, 0)], slides.animation.MotionPathPointsType.AUTO, False)
    path.add(slides.animation.MotionCommandPathType.LINE_TO, [draw.PointF(0.25, 0)], slides.animation.MotionPathPointsType.CORNER, False)
    path.add(slides.animation.MotionCommandPathType.END, [], slides.animation.MotionPathPointsType.NONE, False)

    motion.path = path
    effect.behaviors.add(motion)

    presentation.save("motion.pptx", slides.export.SaveFormat.PPTX)
```

`motion.pptx` contient un comportement de mouvement avec trois commandes de chemin. Les exemples d'édition de fichier suivants utilisent cette structure connue.

### **Comparer les coordonnées absolues et relatives**

Ces deux objets de chemin décrivent la même route. La commande absolue se termine à (0.3, 0.1) ; la commande relative ajoute (0.1, 0.1) à la position actuelle, (0.2, 0).

Les deux chemins partent de la même position. Pour la ligne relative, ajoutez ses décalages X et Y à la position actuelle pour obtenir le point final ; pour la ligne absolue, lisez directement le point final. Inverser le drapeau sans convertir les coordonnées décrirait une route différente.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

absolute_path = slides.animation.MotionPath()
absolute_path.add(slides.animation.MotionCommandPathType.MOVE_TO, [draw.PointF(0.2, 0)], slides.animation.MotionPathPointsType.AUTO, False)
absolute_path.add(slides.animation.MotionCommandPathType.LINE_TO, [draw.PointF(0.3, 0.1)], slides.animation.MotionPathPointsType.CORNER, False)

relative_path = slides.animation.MotionPath()
relative_path.add(slides.animation.MotionCommandPathType.MOVE_TO, [draw.PointF(0.2, 0)], slides.animation.MotionPathPointsType.AUTO, False)
relative_path.add(slides.animation.MotionCommandPathType.LINE_TO, [draw.PointF(0.1, 0.1)], slides.animation.MotionPathPointsType.CORNER, True)
```

Assignez l’un ou l’autre chemin à un comportement de mouvement pour l’utiliser dans une présentation. Le dernier argument booléen sélectionne les coordonnées relatives pour cette commande.

### **Remplacer une ligne par une courbe**

Ouvrez `motion.pptx` et remplacez sa commande de ligne par une courbe cubique. Fournissez d’abord les deux points de contrôle, suivis du point final.

La position de départ est fournie par la commande précédente. Les deux premiers points façonnent la courbe, tandis que le troisième en est la destination ; ils ne sont pas trois destinations successives. Mettre à jour simultanément le type de commande, le type d’édition des points et le tableau de points maintient le segment cohérent avec sa nouvelle géométrie.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("motion.pptx") as presentation:
    effect = presentation.slides[0].timeline.main_sequence[0]
    motion = effect.behaviors[0]

    path = motion.path
    path[1].command_type = slides.animation.MotionCommandPathType.CURVE_TO
    path[1].points_type = slides.animation.MotionPathPointsType.CURVE_SMOOTH
    path[1].points = [draw.PointF(0.1, 0), draw.PointF(0.2, 0.1), draw.PointF(0.3, 0.1)]

    presentation.save("curve.pptx", slides.export.SaveFormat.PPTX)
```

Le chemin dans `curve.pptx` possède toujours trois commandes ; sa commande du milieu définit maintenant une courbe.

## **Inspecter et éditer un chemin enregistré**

Chaque [MotionCmdPath](https://reference.aspose.com/slides/fr/python-net/aspose.slides.animation/motioncmdpath/) expose [points](https://reference.aspose.com/slides/fr/python-net/aspose.slides.animation/motioncmdpath/points/), [command_type](https://reference.aspose.com/slides/fr/python-net/aspose.slides.animation/motioncmdpath/command_type/), [points_type](https://reference.aspose.com/slides/fr/python-net/aspose.slides.animation/motioncmdpath/points_type/), et [is_relative](https://reference.aspose.com/slides/fr/python-net/aspose.slides.animation/motioncmdpath/is_relative/). Les exemples suivants utilisent le chemin connu à trois commandes de `motion.pptx`. Pour une entrée arbitraire, localisez l’effet concerné et vérifiez les types de commandes et le nombre de points avant d’éditer par indice.

### **Lire les commandes et les coordonnées**

Lisez le chemin sans le modifier. Les commandes de fin et de boucle fermée ne nécessitent aucun point, il faut donc prévoir un tableau de points `None`.

La sortie associe chaque commande à son indicateur de coordonnées relatives avant d’énumérer ses points. Cela vous permet de différencier un point final d’un décalage avant de modifier le chemin. Une courbe listerait trois points, tandis que la ligne droite de ce fichier n’en liste qu’un.

```python
import aspose.slides as slides

with slides.Presentation("motion.pptx") as presentation:
    effect = presentation.slides[0].timeline.main_sequence[0]
    motion = effect.behaviors[0]

    for segment in motion.path:
        print(f"{segment.command_type}, relative: {segment.is_relative}")
        if segment.points is not None:
            for point in segment.points:
                print(f"X={point.x}, Y={point.y}")
```

Le listing contient un point de départ, une ligne absolue se terminant à (0.25, 0), et une commande de fin.

### **Modifier un point final**

Ouvrez `motion.pptx` et remplacez le tableau de points de la ligne afin de déplacer son point final.

Dans le fichier d’entrée, l’indice 0 correspond à la commande de départ et l’indice 1 à la ligne. Remplacer le seul point de la ligne change sa destination sans modifier son type de commande, son chronométrage ou sa position dans la collection. Parce que la commande utilise des coordonnées absolues, la nouvelle paire spécifie une position plutôt qu’un simple décalage.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("motion.pptx") as presentation:
    effect = presentation.slides[0].timeline.main_sequence[0]

    motion = effect.behaviors[0]
    motion.path[1].points = [draw.PointF(0.4, 0.1)]

    presentation.save("motion-endpoint.pptx", slides.export.SaveFormat.PPTX)
```

La ligne dans `motion-endpoint.pptx` se termine à (0.4, 0.1) ; le fichier original reste inchangé.

### **Remplacer un segment**

Utilisez [insert](https://reference.aspose.com/slides/fr/python-net/aspose.slides.animation/motionpath/insert/) et [remove_at](https://reference.aspose.com/slides/fr/python-net/aspose.slides.animation/motionpath/remove_at/) pour remplacer la ligne dans `motion.pptx`. L’insertion décale l’ancienne ligne à l’indice 2.

Cela montre comment remplacer un objet de commande plutôt que d’éditer ses coordonnées existantes. Après l’insertion, la collection contient temporairement la commande de départ, la nouvelle ligne, l’ancienne ligne et la commande de fin. La suppression de l’indice 2 élimine l’ancienne ligne et laisse la nouvelle route en place.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("motion.pptx") as presentation:
    effect = presentation.slides[0].timeline.main_sequence[0]
    motion = effect.behaviors[0]

    path = motion.path
    path.insert(1, slides.animation.MotionCommandPathType.LINE_TO, [draw.PointF(0.2, 0.1)], slides.animation.MotionPathPointsType.CORNER, False)
    path.remove_at(2)

    presentation.save("motion-edited.pptx", slides.export.SaveFormat.PPTX)
```

Le chemin enregistré possède toujours trois commandes, la nouvelle ligne se terminant à (0.2, 0.1) et la commande de fin en dernier.

## **Modifier et vérifier un comportement existant**

Lorsque l’indice du comportement est inconnu, sélectionnez‑le par type. Cet exemple ouvre `rotation.pptx`, trouve son [RotationEffect](https://reference.aspose.com/slides/fr/python-net/aspose.slides.animation/rotationeffect/), change l’angle, et vérifie la valeur enregistrée après réouverture.

La vérification du type permet à la boucle d’ignorer les comportements qui ne sont pas des rotations. Le deuxième chargement lit le fichier enregistré dans un objet de présentation distinct, de sorte que la comparaison porte sur les données persistées plutôt que sur la valeur encore en mémoire. Cet exemple suppose toujours que l’effet connu est le premier de la séquence principale ; sélectionner un comportement par type ne localise pas forcément le bon effet dans une présentation arbitraire.

```python
import aspose.slides as slides

with slides.Presentation("rotation.pptx") as presentation:
    effect = presentation.slides[0].timeline.main_sequence[0]

    for behavior in effect.behaviors:
        if isinstance(behavior, slides.animation.RotationEffect):
            behavior.by = 180

    presentation.save("rotation-edited.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("rotation-edited.pptx") as reopened:
    saved_effect = reopened.slides[0].timeline.main_sequence[0]

    for behavior in saved_effect.behaviors:
        if isinstance(behavior, slides.animation.RotationEffect):
            print(f"Rotation preserved: {abs(behavior.by - 180) < 0.001}")
```

Le résultat affiché est `Rotation preserved: True`. Appliquez le même schéma de vérification de type à d’autres comportements. Pour une vérification complète de préservation, comparez la forme cible, l’effet, les types et l’ordre des comportements, le chronométrage et les commandes de chemin. Utilisez une tolérance numérique pour les valeurs à virgule flottante. Pour une présentation dont la structure d’animation est inconnue, consultez [Lire les animations de forme](/slides/fr/python-net/shape-animation/#read-shape-animations) pour parcourir les séquences principales et interactives.

## **Ordre des comportements, préréglages et lecture**

L’ordre dans [BehaviorCollection](https://reference.aspose.com/slides/fr/python-net/aspose.slides.animation/behaviorcollection/) correspond à l’ordre stocké des opérations d’un effet. Ce n’est pas une liste de lecture où chaque comportement attend automatiquement le précédent. Le chronométrage et l’effet englobant déterminent la planification. Les comportements peuvent se chevaucher, et les opérations sur la même propriété peuvent interagir via [additive](https://reference.aspose.com/slides/fr/python-net/aspose.slides.animation/behavior/additive/) et [accumulate](https://reference.aspose.com/slides/fr/python-net/aspose.slides.animation/behavior/accumulate/). N’utilisez pas uniquement le ré‑ordonnancement de la collection pour planifier « déplacer, puis faire pivoter » ; utilisez le chronométrage explicite ou des effets séparés comme décrit dans [Animation de formes](/slides/fr/python-net/shape-animation/).

Le [type](https://reference.aspose.com/slides/fr/python-net/aspose.slides.animation/effect/type/) et le [subtype](https://reference.aspose.com/slides/fr/python-net/aspose.slides.animation/effect/subtype/) de l’effet décrivent son préréglage. Ils ne constituent pas une description complète d’un arbre de comportements édité. Choisissez le préréglage et le sous‑type avant de personnaliser les comportements : changer le préréglage peut reconstruire la collection et supprimer vos opérations personnalisées. Par exemple, transformer un effet Spin personnalisé en Fade peut remplacer son comportement de rotation par des comportements set et filter. Inspectez de nouveau la collection après avoir changé un préréglage ou un sous‑type. Vider les comportements du préréglage peut aussi supprimer des opérations de visibilité ou d’initialisation dont le préréglage a besoin. Les exemples utilisent délibérément des formes visibles et remplacent les comportements ; ils ne reconstruisent pas l’implémentation de chaque préréglage.

## **Compatibilité des formats**

Un arbre de comportements conservé ne garantit pas une lecture identique dans chaque visionneuse ou moteur d’exportation. Vérifiez séparément les données enregistrées et le rendu final.

| Format ou sortie | Ce qu’il faut vérifier |
| --- | --- |
| PPTX | Utilisez‑le comme format principal pour ces exemples. Ré‑ouvrez‑le pour vérifier l’arbre de comportements éditable, puis testez la lecture dans la version de PowerPoint visée. |
| PPT | La représentation binaire héritée peut différer du PPTX. Testez un cycle d’enregistrement‑réouverture séparé et la lecture ; ne déduisez pas la prise en charge de chaque combinaison personnalisée à partir d’un PPTX réussi. |
| PDF, PNG, JPEG et autres images de diapositive statiques | Contiennent une représentation statique de la diapositive, pas de ligne de temps d’animation jouable ni d’image finale d’animation garantie. |
| [HTML5](/slides/fr/python-net/export-to-html5/) | Peut lire les animations supportées lorsque l’animation de forme est activée dans les options d’exportation. Testez les combinaisons personnalisées dans le navigateur. |
| [GIF animé](/slides/fr/python-net/convert-powerpoint-to-animated-gif/) | Stocke les images rendues, pas les comportements éditables ou les interactions déclenchées par clic. Vérifiez le mouvement réellement rendu. |
| [Vidéo](/slides/fr/python-net/convert-powerpoint-to-video/) | Rend les images d’animation et les encode en vidéo. Le support est limité aux [animations et effets pris en charge](/slides/fr/python-net/convert-powerpoint-to-video/#supported-animations-and-effects) du moteur de rendu ; les commandes et événements interactifs ne deviennent pas une ligne de temps éditable. |

## **FAQ**

**Pourquoi mon effet contient‑il des comportements avant que j’en ajoute ?**

La création d’un effet prédéfini peut créer ses opérations sous‑jacentes. Inspectez‑les avant de décider d’étendre le préréglage ou de remplacer ses comportements.

**Déplacer un comportement au début le fait‑il jouer en premier ?**

Ce n’est pas nécessairement le cas. L’ordre de la collection ne remplace pas le chronométrage. Vérifiez les délais, les durées et les interactions entre les opérations sur la même propriété.

**Pourquoi une commande de fin n’a‑t‑elle aucun point ?**

Elle marque la fin du chemin et ne nécessite aucune coordonnée. Vérifiez la présence d’un tableau de points `None` lors de l’inspection d’un chemin lu depuis un fichier.

**Un aller‑retour réussi suffit‑il à confirmer la lecture ?**

Non. La réouverture confirme la préservation des propriétés vérifiées. Testez séparément le lecteur de diaporama ou l’export animé pour confirmer le comportement visuel.