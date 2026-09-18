---
title: Créer et modifier des comportements d'animation personnalisés en Python via Java
linktitle: Animation personnalisée
type: docs
weight: 151
url: /fr/python-java/custom-animation/
keywords:
- animation personnalisée
- comportement d'animation
- chemin de mouvement
- PowerPoint
- présentation
- Python
- Java
- Aspose.Slides
description: "Créer, inspecter et modifier des comportements d'animation personnalisés et des chemins de mouvement éditables dans les présentations PowerPoint avec Aspose.Slides pour Python via Java."
---
## **Vue d'ensemble**

Les comportements d'animation personnalisés vous permettent de contrôler les opérations individuelles au sein d'un effet d'animation, comme changer une couleur, faire pivoter une forme ou suivre un chemin de mouvement éditable. Ce guide montre comment créer et combiner des comportements, configurer leur chronologie, inspecter et modifier les animations existantes, et vérifier que leurs propriétés survivent à l'enregistrement et à la réouverture d'une présentation.

Pour les effets prédéfinis et les déclencheurs de clic, consultez [Animation de forme](/slides/fr/python-java/shape-animation/).

## **Comprendre le modèle d'animation**

Une animation est organisée comme **Timeline → Sequence → Effect → Behaviors** :

- La méthode [getTimeline](https://reference.aspose.com/slides/fr/python-java/aspose.slides/baseslide/#getTimeline) renvoie la chronologie de la diapositive, qui contient sa séquence principale et ses séquences interactives.
- Une [Sequence](https://reference.aspose.com/slides/fr/python-java/aspose.slides/sequence/) contient des effets, pouvant cibler différentes formes.
- Un [Effect](https://reference.aspose.com/slides/fr/python-java/aspose.slides/effect/) identifie la forme cible, le préréglage, le sous‑type et le chronométrage de l'effet.
- La collection renvoyée par [Effect.getBehaviors](https://reference.aspose.com/slides/fr/python-java/aspose.slides/effect/#getBehaviors) contient les opérations qui implémentent l'effet : changement de couleur, déplacement, rotation, définition d'une propriété, etc.

## **Créer des comportements individuels**

Appelez [Sequence.addEffect](https://reference.aspose.com/slides/fr/python-java/aspose.slides/sequence/#addEffect) pour créer un effet et accéder à la collection [getBehaviors](https://reference.aspose.com/slides/fr/python-java/aspose.slides/effect/#getBehaviors). Un préréglage peut remplir automatiquement cette collection. Conservez ses opérations lors de l'extension du préréglage, ou utilisez [clear](https://reference.aspose.com/slides/fr/python-java/aspose.slides/behaviorcollection/#clear) lorsque vous remplacez délibérément les opérations.

[BehaviorFactory](https://reference.aspose.com/slides/fr/python-java/aspose.slides/behaviorfactory/) crée les huit types de comportements illustrés ci‑dessous. Le mouvement est abordé dans [Créer un chemin de mouvement](#build-a-motion-path). Chaque extrait comprend ses importations et démarre la JVM si nécessaire. Les objets point Java et les tableaux sont créés via JPype lorsque l'API les requiert. Les exemples d'édition ultérieurs indiquent le fichier de sortie utilisé.

### **Rotation**

Utilisez [createRotationEffect](https://reference.aspose.com/slides/fr/python-java/aspose.slides/behaviorfactory/#createRotationEffect) pour créer une rotation. [getBy](https://reference.aspose.com/slides/fr/python-java/aspose.slides/rotationeffect/#getBy) spécifie un angle relatif en degrés ; [getFrom](https://reference.aspose.com/slides/fr/python-java/aspose.slides/rotationeffect/#getFrom) et [getTo](https://reference.aspose.com/slides/fr/python-java/aspose.slides/rotationeffect/#getTo) spécifient les points de départ et d'arrivée.

L'exemple commence avec un effet Spin, remplace ses opérations de préréglage par un comportement de rotation, et attribue à cette opération une durée de deux secondes. Un angle relatif de 90° correspond à un quart de tour par rapport à l'orientation de départ de la forme, donc aucun angle de départ explicite n'est requis.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BehaviorFactory, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80)

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Spin, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getBehaviors().clear()

    factory = BehaviorFactory()
    rotation = factory.createRotationEffect()
    rotation.setBy(90)
    rotation.getTiming().setDuration(2)

    effect.getBehaviors().add(rotation)

    presentation.save("rotation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

`rotation.pptx` contient une forme et un comportement de rotation. La collection, le chronométrage et les exemples d'édition de rotation ci‑dessous utilisent ce fichier.

### **Échelle**

Utilisez [createScaleEffect](https://reference.aspose.com/slides/fr/python-java/aspose.slides/behaviorfactory/#createScaleEffect) avec des pourcentages X/Y : [getFrom](https://reference.aspose.com/slides/fr/python-java/aspose.slides/scaleeffect/#getFrom) et [getTo](https://reference.aspose.com/slides/fr/python-java/aspose.slides/scaleeffect/#getTo) décrivent la taille de départ et d'arrivée, tandis que [getBy](https://reference.aspose.com/slides/fr/python-java/aspose.slides/scaleeffect/#getBy) décrit une variation relative. Ici, 100 représente la taille originale.

L'exemple augmente les deux dimensions de 100 % à 125 % en deux secondes. Utiliser des pourcentages horizontaux et verticaux égaux conserve les proportions de la forme ; des pourcentages différents étireraient davantage une dimension que l'autre.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BehaviorFactory, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, ShapeType

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80)

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.GrowShrink, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getBehaviors().clear()

    factory = BehaviorFactory()
    scale = factory.createScaleEffect()
    scale.setFrom(Point2DFloat(100, 100))
    scale.setTo(Point2DFloat(125, 125))
    scale.getTiming().setDuration(2)

    effect.getBehaviors().add(scale)

    presentation.save("scale.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Couleur**

Utilisez [createColorEffect](https://reference.aspose.com/slides/fr/python-java/aspose.slides/behaviorfactory/#createColorEffect) pour changer le remplissage du bleu à l'orange. [getFrom](https://reference.aspose.com/slides/fr/python-java/aspose.slides/coloreffect/#getFrom) et [getTo](https://reference.aspose.com/slides/fr/python-java/aspose.slides/coloreffect/#getTo) sont des couleurs ; [getBy](https://reference.aspose.com/slides/fr/python-java/aspose.slides/coloreffect/#getBy) est un décalage de couleur. [Behavior.getProperties](https://reference.aspose.com/slides/fr/python-java/aspose.slides/behavior/#getProperties) identifie l'attribut animé.

Le remplissage plein de la forme est initialisé en bleu, correspondant à la couleur de départ de l'animation. Sélectionner l'attribut de couleur de remplissage indique au comportement quelle partie de la forme modifier ; les seules couleurs d'extrémité n'identifient pas cet attribut. L'effet enregistré décrit une transition de deux secondes vers l'orange.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BehaviorFactory, BehaviorProperty, EffectSubtype, EffectTriggerType, EffectType, FillType, Presentation, SaveFormat, ShapeType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.ChangeFillColor, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getBehaviors().clear()

    factory = BehaviorFactory()
    color = factory.createColorEffect()
    color.getProperties().add(BehaviorProperty.getFillColor().getValue())
    color.getFrom().setColor(Color.BLUE)
    color.getTo().setColor(Color(255, 165, 0))
    color.getTiming().setDuration(2)

    effect.getBehaviors().add(color)

    presentation.save("color.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Filtre**

Utilisez [createFilterEffect](https://reference.aspose.com/slides/fr/python-java/aspose.slides/behaviorfactory/#createFilterEffect) pour sélectionner un essuyage. [getType](https://reference.aspose.com/slides/fr/python-java/aspose.slides/filtereffect/#getType), [getSubtype](https://reference.aspose.com/slides/fr/python-java/aspose.slides/filtereffect/#getSubtype) et [getReveal](https://reference.aspose.com/slides/fr/python-java/aspose.slides/filtereffect/#getReveal) spécifient le filtre, la direction et si l’on révèle ou masque la forme.

Cet exemple configure un essuyage de deux secondes qui révèle la forme en utilisant le sous‑type de direction droite. Les réglages du filtre appartiennent au comportement à l'intérieur de l'effet, ils sont donc configurés après la suppression des opérations originales du préréglage.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BehaviorFactory, EffectSubtype, EffectTriggerType, EffectType, FilterEffectRevealType, FilterEffectSubtype, FilterEffectType, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80)

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Wipe, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getBehaviors().clear()

    factory = BehaviorFactory()
    filter = factory.createFilterEffect()
    filter.setType(FilterEffectType.Wipe)
    filter.setSubtype(FilterEffectSubtype.Right)
    filter.setReveal(FilterEffectRevealType.In)
    filter.getTiming().setDuration(2)

    effect.getBehaviors().add(filter)

    presentation.save("filter.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Propriété**

Utilisez [createPropertyEffect](https://reference.aspose.com/slides/fr/python-java/aspose.slides/behaviorfactory/#createPropertyEffect) pour animer l'opacité. [getFrom](https://reference.aspose.com/slides/fr/python-java/aspose.slides/propertyeffect/#getFrom), [getTo](https://reference.aspose.com/slides/fr/python-java/aspose.slides/propertyeffect/#getTo) et [getBy](https://reference.aspose.com/slides/fr/python-java/aspose.slides/propertyeffect/#getBy) sont des chaînes interprétées via [getValueType](https://reference.aspose.com/slides/fr/python-java/aspose.slides/propertyeffect/#getValueType) et [getCalcMode](https://reference.aspose.com/slides/fr/python-java/aspose.slides/propertyeffect/#getCalcMode). Choisissez des points d'extrémité ou un décalage relatif plutôt que de définir les trois simultanément.

Ici, l'attribut sélectionné est l'opacité, et les chaînes numériques représentent un passage de 25 % d'opacité à une opacité totale. L'interpolation linéaire décrit une variation progressive entre ces valeurs. En adaptant cet exemple à une autre propriété, choisissez un type de valeur et des points d'extrémité appropriés à cette propriété.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BehaviorFactory, BehaviorProperty, EffectSubtype, EffectTriggerType, EffectType, Presentation, PropertyCalcModeType, PropertyValueType, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80)

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getBehaviors().clear()

    factory = BehaviorFactory()
    property = factory.createPropertyEffect()
    property.getProperties().add(BehaviorProperty.getStyleOpacity().getValue())
    property.setValueType(PropertyValueType.Number)
    property.setCalcMode(PropertyCalcModeType.Linear)
    property.setFrom("0.25")
    property.setTo("1")
    property.getTiming().setDuration(2)

    effect.getBehaviors().add(property)

    presentation.save("property.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Définir**

Utilisez [createSetEffect](https://reference.aspose.com/slides/fr/python-java/aspose.slides/behaviorfactory/#createSetEffect) pour attribuer la visibilité via [getTo](https://reference.aspose.com/slides/fr/python-java/aspose.slides/seteffect/#getTo). Un comportement « set » n’interpole pas entre les points d'extrémité.

L'exemple sélectionne l'attribut de visibilité et assigne la chaîne `visible` lorsque le comportement s'exécute. Le rectangle est déjà visible dans cette présentation minimale, donc l'attribution peut ne pas produire de changement visuel évident à elle seule. Une telle opération est utile dans le cadre d'un effet plus large qui contrôle également le moment où la forme devient masquée ou visible.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BehaviorFactory, BehaviorProperty, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80)

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getBehaviors().clear()

    factory = BehaviorFactory()
    set = factory.createSetEffect()
    set.getProperties().add(BehaviorProperty.getStyleVisibility().getValue())
    set.setTo("visible")

    effect.getBehaviors().add(set)

    presentation.save("set.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Commande**

Utilisez [createCommandEffect](https://reference.aspose.com/slides/fr/python-java/aspose.slides/behaviorfactory/#createCommandEffect) et configurez [getType](https://reference.aspose.com/slides/fr/python-java/aspose.slides/commandeffect/#getType), [getCommandString](https://reference.aspose.com/slides/fr/python-java/aspose.slides/commandeffect/#getCommandString) et [getShapeTarget](https://reference.aspose.com/slides/fr/python-java/aspose.slides/commandeffect/#getShapeTarget). Placez un enregistrement WAV nommé `sample.wav` dans le répertoire de travail. Cet exemple l'intègre avec [addAudioFrameEmbedded](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shapecollection/#addAudioFrameEmbedded) et attache une commande de lecture au cadre audio.

Le cadre audio est à la fois la cible de l'effet et la cible de la commande. Cela relie la requête de lecture à l'enregistrement intégré ; une simple chaîne de commande ne précise pas quel objet média contrôler. L'effet est configuré pour démarrer au clic pendant le diaporama.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path

from asposeslides.api import BehaviorFactory, CommandEffectType, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    audio_data = Path("sample.wav").read_bytes()
    audio_bytes = jpype.JArray(jpype.JByte)(audio_data)
    audio = presentation.getAudios().addAudio(audio_bytes)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(100, 100, 40, 40, audio)

    effect = slide.getTimeline().getMainSequence().addEffect(audio_frame, EffectType.MediaPlay, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getBehaviors().clear()

    factory = BehaviorFactory()
    command = factory.createCommandEffect()
    command.setType(CommandEffectType.Call)
    command.setCommandString("play")
    command.setShapeTarget(audio_frame)

    effect.getBehaviors().add(command)

    presentation.save("command.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

L'enregistrement stocke la commande dans `command.pptx` ; il ne lit pas le son. La lecture nécessite un lecteur de diaporama qui prend en charge la commande et sa cible média.

## **Gérer la collection de comportements**

[BehaviorCollection](https://reference.aspose.com/slides/fr/python-java/aspose.slides/behaviorcollection/) prend en charge [add](https://reference.aspose.com/slides/fr/python-java/aspose.slides/behaviorcollection/#add), [insert](https://reference.aspose.com/slides/fr/python-java/aspose.slides/behaviorcollection/#insert), [remove](https://reference.aspose.com/slides/fr/python-java/aspose.slides/behaviorcollection/#remove) et [removeAt](https://reference.aspose.com/slides/fr/python-java/aspose.slides/behaviorcollection/#removeAt). Cet exemple ouvre `rotation.pptx`, ajoute un effet d'échelle, le déplace avant la rotation et supprime la rotation. Supprimer et réinsérer le même objet modifie sa position stockée sans créer de copie.

La séquence d'éditions transforme la collection de rotation‑échelle en échelle‑rotation, puis en uniquement échelle. Les indices font référence à la collection courante, de sorte que la suppression utilise le nouvel indice de la rotation après réordonnancement. L'énumération finale confirme le comportement qui sera enregistré.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BehaviorFactory, Presentation, SaveFormat

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")

presentation = Presentation("rotation.pptx")
try:
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0)
    behaviors = effect.getBehaviors()

    factory = BehaviorFactory()
    scale = factory.createScaleEffect()
    scale.setTo(Point2DFloat(125, 125))
    scale.getTiming().setDuration(2)

    behaviors.add(scale)

    behaviors.remove(scale)
    behaviors.insert(0, scale)
    behaviors.removeAt(1)

    for behavior in behaviors:
        print(behavior.getClass().getSimpleName())

    presentation.save("collection-edited.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Le résultat est `ScaleEffect` : seule l'échelle reste. L'ordre de la collection ne programme pas, à lui seul, les comportements les uns après les autres. Videz la collection uniquement lors du remplacement de toutes ses opérations.

## **Configurer le chronométrage des comportements**

[Behavior.getTiming](https://reference.aspose.com/slides/fr/python-java/aspose.slides/behavior/#getTiming) expose [Timing](https://reference.aspose.com/slides/fr/python-java/aspose.slides/timing/), indépendamment de [Effect.getTiming](https://reference.aspose.com/slides/fr/python-java/aspose.slides/effect/#getTiming). Le chronométrage de l'effet programme l'effet enveloppant ; le chronométrage du comportement décrit une opération à l'intérieur.

### **Définir la durée, le retard, la répétition et l'accélération**

Ouvrez `rotation.pptx` et définissez la durée ([getDuration](https://reference.aspose.com/slides/fr/python-java/aspose.slides/timing/#getDuration)) ainsi que le retard de déclenchement ([getTriggerDelayTime](https://reference.aspose.com/slides/fr/python-java/aspose.slides/timing/#getTriggerDelayTime)) en secondes, puis configurez le nombre de répétitions via [setRepeatCount](https://reference.aspose.com/slides/fr/python-java/aspose.slides/timing/#setRepeatCount). [getAccelerate](https://reference.aspose.com/slides/fr/python-java/aspose.slides/timing/#getAccelerate) et [getDecelerate](https://reference.aspose.com/slides/fr/python-java/aspose.slides/timing/#getDecelerate) sont des fractions de la durée ; veillez à ce que leur somme ne dépasse pas 1.

Le fichier d'entrée est celui créé dans l'exemple de rotation, où le premier comportement est connu pour être une rotation. Cet exemple ne modifie que le chronométrage de ce comportement ; son angle de 90° reste intact. Séparer l'angle et le chronométrage facilite l'ajustement du rythme sans reconstruire l'animation.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, RotationEffect, SaveFormat

presentation = Presentation("rotation.pptx")
try:
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0)

    rotation = effect.getBehaviors().get_Item(0)
    rotation.getTiming().setDuration(2)
    rotation.getTiming().setTriggerDelayTime(0.5)
    rotation.getTiming().setRepeatCount(3)
    rotation.getTiming().setAccelerate(0.2)
    rotation.getTiming().setDecelerate(0.2)

    presentation.save("timing.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Le comportement utilise une durée de deux secondes, un retard d'une demi‑seconde et un nombre de répétitions de 3. Les 20 % initiaux et finaux de sa durée sont utilisés pour l'accélération et la décélération.

D'autres politiques de répétition incluent [getRepeatDuration](https://reference.aspose.com/slides/fr/python-java/aspose.slides/timing/#getRepeatDuration), [getRepeatUntilEndSlide](https://reference.aspose.com/slides/fr/python-java/aspose.slides/timing/#getRepeatUntilEndSlide) et [getRepeatUntilNextClick](https://reference.aspose.com/slides/fr/python-java/aspose.slides/timing/#getRepeatUntilNextClick) ; choisissez une politique plutôt que de les activer toutes simultanément. [getAutoReverse](https://reference.aspose.com/slides/fr/python-java/aspose.slides/timing/#getAutoReverse) lit l'animation en sens inverse après le passage avant. L'accélération et la décélération s'appliquent aux changements continus, pas aux affectations discrètes ou aux commandes.

## **Créer un chemin de mouvement**

Utilisez [createMotionEffect](https://reference.aspose.com/slides/fr/python-java/aspose.slides/behaviorfactory/#createMotionEffect) pour créer un mouvement. Ses [getFrom](https://reference.aspose.com/slides/fr/python-java/aspose.slides/motioneffect/#getFrom), [getTo](https://reference.aspose.com/slides/fr/python-java/aspose.slides/motioneffect/#getTo) et [getBy](https://reference.aspose.com/slides/fr/python-java/aspose.slides/motioneffect/#getBy) décrivent des coordonnées ou des décalages basés sur des pourcentages. Pour une route éditable, créez un [MotionPath](https://reference.aspose.com/slides/fr/python-java/aspose.slides/motionpath/) et affectez‑le avec [MotionEffect.setPath](https://reference.aspose.com/slides/fr/python-java/aspose.slides/motioneffect/#setPath). [MotionPath](https://reference.aspose.com/slides/fr/python-java/aspose.slides/motionpath/) stocke les commandes du chemin.

[MotionCommandPathType](https://reference.aspose.com/slides/fr/python-java/aspose.slides/motioncommandpathtype/) sélectionne l'opération :

| Commande | Points | Signification |
| --- | --- | --- |
| MoveTo | Un | Définir la position de départ. |
| LineTo | Un | Se déplacer le long d'un segment droit jusqu'à son point d'arrivée. |
| CurveTo | Trois | Suivre une courbe cubique définie par deux points de contrôle et un point d'arrivée. |
| CloseLoop | Aucun | Retourner à la position de départ. |
| End | Aucun | Terminer le chemin. |

[MotionPathPointsType](https://reference.aspose.com/slides/fr/python-java/aspose.slides/motionpathpointstype/) décrit les caractéristiques d'édition des points, comme les coins ou les points lisses. Il ne remplace pas le type de commande. Utilisez un type de point de courbe pour l'exemple de courbe ci‑dessous, et un type de point d'angle pour les segments droits.

Les coordonnées du chemin sont normalisées aux dimensions de la diapositive : un déplacement X de 0,25 représente un quart de la largeur de la diapositive, pas 0,25 point. Le Y positif descend. Les commandes absolues spécifient des positions dans le système de coordonnées du chemin ; les commandes relatives spécifient des décalages par rapport à la position courante. Cela est distinct de [getOrigin](https://reference.aspose.com/slides/fr/python-java/aspose.slides/motioneffect/#getOrigin), qui sélectionne le cadre de référence du chemin, et de [getPathEditMode](https://reference.aspose.com/slides/fr/python-java/aspose.slides/motioneffect/#getPathEditMode), qui contrôle comment le chemin se déplace lorsque la forme est déplacée.

### **Créer un chemin droit**

Créez un comportement de mouvement avec un point de départ, un segment droit et une commande de fin. [MotionPath.add](https://reference.aspose.com/slides/fr/python-java/aspose.slides/motionpath/#add) reçoit le type de commande, ses points, le type de point et un indicateur de coordonnées relatives.

La commande de départ établit (0, 0), et la ligne se termine à (0,25, 0), donnant au tracé un déplacement horizontal d'un quart de la largeur de la diapositive. La commande de fin n’a aucun point de coordonnées. Une fois le chemin affecté, l'ajout du comportement de mouvement à l'effet relie ce tracé au rectangle.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BehaviorFactory, EffectSubtype, EffectTriggerType, EffectType, MotionCommandPathType, MotionOriginType, MotionPath, MotionPathPointsType, Presentation, SaveFormat, ShapeType

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80)

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.PathRight, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getBehaviors().clear()

    factory = BehaviorFactory()
    motion = factory.createMotionEffect()
    motion.setOrigin(MotionOriginType.Layout)
    motion.getTiming().setDuration(2)

    path = MotionPath()
    path_points = jpype.JArray(Point2DFloat)([Point2DFloat(0, 0)])
    path.add(MotionCommandPathType.MoveTo, path_points, MotionPathPointsType.Auto, False)
    path_points_2 = jpype.JArray(Point2DFloat)([Point2DFloat(0.25, 0)])
    path.add(MotionCommandPathType.LineTo, path_points_2, MotionPathPointsType.Corner, False)
    path_points_3 = jpype.JArray(Point2DFloat)(0)
    path.add(MotionCommandPathType.End, path_points_3, MotionPathPointsType.None_, False)

    motion.setPath(path)
    effect.getBehaviors().add(motion)

    presentation.save("motion.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

`motion.pptx` contient un comportement de mouvement avec trois commandes de chemin. Les exemples d'édition de fichier suivants utilisent cette structure connue.

### **Comparer les coordonnées absolues et relatives**

Ces deux objets de chemin décrivent la même route. La commande absolue se termine à (0,3, 0,1) ; la commande relative ajoute (0,1, 0,1) à la position courante, soit (0,2, 0).

Les deux chemins partent de la même position. Pour la ligne relative, ajoutez ses décalages X et Y à la position courante pour obtenir le point d'arrivée ; pour la ligne absolue, lisez directement le point d'arrivée. Basculer l’indicateur sans convertir les coordonnées décrirait une route différente.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MotionCommandPathType, MotionPath, MotionPathPointsType

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")

absolute_path = MotionPath()
path_points = jpype.JArray(Point2DFloat)([Point2DFloat(0.2, 0)])
absolute_path.add(MotionCommandPathType.MoveTo, path_points, MotionPathPointsType.Auto, False)
path_points_2 = jpype.JArray(Point2DFloat)([Point2DFloat(0.3, 0.1)])
absolute_path.add(MotionCommandPathType.LineTo, path_points_2, MotionPathPointsType.Corner, False)

relative_path = MotionPath()
path_points_3 = jpype.JArray(Point2DFloat)([Point2DFloat(0.2, 0)])
relative_path.add(MotionCommandPathType.MoveTo, path_points_3, MotionPathPointsType.Auto, False)
path_points_4 = jpype.JArray(Point2DFloat)([Point2DFloat(0.1, 0.1)])
relative_path.add(MotionCommandPathType.LineTo, path_points_4, MotionPathPointsType.Corner, True)
```

Attribuez l’un ou l’autre chemin à un comportement de mouvement pour l’utiliser dans une présentation. Le dernier argument booléen sélectionne les coordonnées relatives pour cette commande.

### **Remplacer une ligne par une courbe**

Ouvrez `motion.pptx` et remplacez sa commande de ligne par une courbe cubique. Fournissez d'abord les deux points de contrôle, puis le point d'arrivée.

La position de départ est fournie par la commande précédente. Les deux premiers points façonnent la courbe, tandis que le troisième en représente la destination ; ils ne sont pas trois destinations successives. Mettre à jour simultanément le type de commande, le type d’édition des points et le tableau de points maintient le segment cohérent avec sa nouvelle géométrie.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MotionCommandPathType, MotionPathPointsType, Presentation, SaveFormat

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")

presentation = Presentation("motion.pptx")
try:
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0)
    motion = effect.getBehaviors().get_Item(0)

    path = motion.getPath()
    path.get_Item(1).setCommandType(MotionCommandPathType.CurveTo)
    path.get_Item(1).setPointsType(MotionPathPointsType.CurveSmooth)
    path_points = jpype.JArray(Point2DFloat)([Point2DFloat(0.1, 0), Point2DFloat(0.2, 0.1), Point2DFloat(0.3, 0.1)])
    path.get_Item(1).setPoints(path_points)

    presentation.save("curve.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Le chemin dans `curve.pptx` possède toujours trois commandes ; sa commande du milieu définit désormais une courbe.

## **Inspecter et modifier un chemin enregistré**

Chaque [MotionCmdPath](https://reference.aspose.com/slides/fr/python-java/aspose.slides/motioncmdpath/) expose [getPoints](https://reference.aspose.com/slides/fr/python-java/aspose.slides/motioncmdpath/#getPoints), [getCommandType](https://reference.aspose.com/slides/fr/python-java/aspose.slides/motioncmdpath/#getCommandType), [getPointsType](https://reference.aspose.com/slides/fr/python-java/aspose.slides/motioncmdpath/#getPointsType) et [isRelative](https://reference.aspose.com/slides/fr/python-java/aspose.slides/motioncmdpath/#isRelative). Les exemples suivants utilisent le chemin connu à trois commandes de `motion.pptx`. Pour une entrée arbitraire, localisez l’effet visé et vérifiez les types de commande et le nombre de points avant de modifier par indice.

### **Lire les commandes et coordonnées**

Lisez le chemin sans le modifier. Les commandes de fin et de fermeture de boucle ne nécessitent aucun point, donc prévoyez un tableau de points nul.

La sortie associe chaque type de commande numérique à son indicateur de coordonnées relatives avant d'énumérer ses points. Cela vous permet de différencier un point d'arrivée d'un décalage avant de modifier le chemin. Une courbe listerait trois points, alors que la ligne droite de ce fichier n’en liste qu’un.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("motion.pptx")
try:
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0)
    motion = effect.getBehaviors().get_Item(0)

    path = motion.getPath()
    for segment in path:
        print(f"{segment.getCommandType()}, relative: {segment.isRelative()}")
        if segment.getPoints() is not None:
            for point in segment.getPoints():
                print(f"X={point.x}, Y={point.y}")
finally:
    presentation.dispose()
```

Le listing contient un point de départ, une ligne absolue se terminant à (0,25, 0) et une commande de fin.

### **Modifier un point d'arrivée**

Ouvrez `motion.pptx` et remplacez le tableau de points de la ligne afin de déplacer son point d'arrivée.

Dans le fichier d’entrée, l’indice 0 correspond à la commande de départ et l’indice 1 à la ligne. Remplacer le unique point de la ligne change sa destination sans modifier le type de commande, le chronométrage ou la position dans la collection. Parce que la commande utilise des coordonnées absolues, la nouvelle paire spécifie une position plutôt qu’un décalage ajouté.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")

presentation = Presentation("motion.pptx")
try:
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0)

    motion = effect.getBehaviors().get_Item(0)
    path_points = jpype.JArray(Point2DFloat)([Point2DFloat(0.4, 0.1)])
    motion.getPath().get_Item(1).setPoints(path_points)

    presentation.save("motion-endpoint.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

La ligne dans `motion-endpoint.pptx` se termine à (0,4, 0,1) ; le fichier original reste inchangé.

### **Remplacer un segment**

Utilisez [insert](https://reference.aspose.com/slides/fr/python-java/aspose.slides/motionpath/#insert) et [removeAt](https://reference.aspose.com/slides/fr/python-java/aspose.slides/motionpath/#removeAt) pour remplacer la ligne dans `motion.pptx`. L’insertion décale l’ancienne ligne à l’indice 2.

Cela montre le remplacement d’un objet de commande plutôt que la modification de ses coordonnées existantes. Après l’insertion, la collection contient temporairement la commande de départ, la nouvelle ligne, l’ancienne ligne et la commande de fin. La suppression de l’indice 2 élimine l’ancienne ligne et laisse la nouvelle route en place.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MotionCommandPathType, MotionPathPointsType, Presentation, SaveFormat

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")

presentation = Presentation("motion.pptx")
try:
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0)
    motion = effect.getBehaviors().get_Item(0)

    path = motion.getPath()
    path_points = jpype.JArray(Point2DFloat)([Point2DFloat(0.2, 0.1)])
    path.insert(1, MotionCommandPathType.LineTo, path_points, MotionPathPointsType.Corner, False)
    path.removeAt(2)

    presentation.save("motion-edited.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Le chemin enregistré possède toujours trois commandes, la nouvelle ligne se terminant à (0,2, 0,1) et la commande de fin en dernier.

## **Modifier et vérifier un comportement existant**

Lorsque l’indice du comportement est inconnu, sélectionnez‑le par type. Cet exemple ouvre `rotation.pptx`, trouve son [RotationEffect](https://reference.aspose.com/slides/fr/python-java/aspose.slides/rotationeffect/), modifie l’angle et vérifie la valeur enregistrée après réouverture.

La vérification du type permet à la boucle d’ignorer les comportements qui ne sont pas des rotations. Le second chargement lit le fichier enregistré dans un objet présentation distinct, de sorte que la comparaison vérifie les données persistées plutôt que la valeur encore en mémoire. Cet exemple suppose toujours que l’effet connu est le premier de la séquence principale ; sélectionner un comportement par type ne localise pas forcément le bon effet dans une présentation arbitraire.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, RotationEffect, SaveFormat

presentation = Presentation("rotation.pptx")
try:
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0)

    for behavior in effect.getBehaviors():
        if isinstance(behavior, RotationEffect):
            rotation = behavior
            rotation.setBy(180)

    presentation.save("rotation-edited.pptx", SaveFormat.Pptx)

    reopened = Presentation("rotation-edited.pptx")
    try:
        saved_effect = reopened.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0)

        for behavior in saved_effect.getBehaviors():
            if isinstance(behavior, RotationEffect):
                rotation = behavior
                print(f"Rotation preserved: {abs(rotation.getBy() - 180) < 0.001}")
    finally:
        reopened.dispose()
finally:
    presentation.dispose()
```

Le résultat est `Rotation preserved: True`. Appliquez le même schéma de vérification par type aux autres comportements. Pour une vérification de préservation complète, comparez la forme cible, l’effet, les types et l’ordre des comportements, le chronométrage et les commandes de chemin. Utilisez une tolérance numérique pour les valeurs à virgule flottante. Pour une présentation dont la disposition d'animation est inconnue, voir [Lire les animations de forme](/slides/fr/python-java/shape-animation/#read-shape-animations) pour parcourir les séquences principales et interactives.

## **Ordre des comportements, préréglages et lecture**

L’ordre dans [BehaviorCollection](https://reference.aspose.com/slides/fr/python-java/aspose.slides/behaviorcollection/) reflète l’ordre stocké des opérations d’un effet. Ce n’est pas une playlist où chaque comportement attend automatiquement le précédent. Le chronométrage et l’effet enveloppant déterminent la planification. Les comportements peuvent se chevaucher, et les opérations sur la même propriété peuvent interagir via [getAdditive](https://reference.aspose.com/slides/fr/python-java/aspose.slides/behavior/#getAdditive) et [getAccumulate](https://reference.aspose.com/slides/fr/python-java/aspose.slides/behavior/#getAccumulate). N’utilisez pas le simple réordonnancement de la collection pour planifier « déplacer, puis pivoter » ; utilisez un chronométrage explicite ou des effets séparés comme décrit dans [Animation de forme](/slides/fr/python-java/shape-animation/).

Le [getType](https://reference.aspose.com/slides/fr/python-java/aspose.slides/effect/#getType) et le [getSubtype](https://reference.aspose.com/slides/fr/python-java/aspose.slides/effect/#getSubtype) de l’effet décrivent son préréglage. Ce ne sont pas une description complète d’un arbre de comportements modifié. Choisissez le préréglage et le sous‑type avant de personnaliser les comportements : changer le préréglage peut reconstruire la collection et supprimer vos opérations personnalisées. Par exemple, passer d’un effet Spin personnalisé à Fade peut remplacer le comportement de rotation par des comportements de définition et de filtre. Inspectez à nouveau la collection après un changement de préréglage ou de sous‑type. Vider les comportements du préréglage peut également supprimer les opérations de visibilité ou d’initialisation dont le préréglage a besoin. Les exemples utilisent volontairement des formes visibles et remplacent les comportements ; ils ne reconstruisent pas l’implémentation de chaque préréglage.

## **Compatibilité des formats**

Un arbre de comportements préservé ne garantit pas une lecture identique dans chaque visionneur ou moteur d’exportation. Vérifiez séparément les données enregistrées et le rendu produit.

| Format ou sortie | Ce qu’il faut vérifier |
| --- | --- |
| PPTX | Utilisez-le comme format principal pour ces exemples. Réouvrez‑le pour vérifier l’arbre de comportements éditable, puis testez la lecture dans la version PowerPoint cible. |
| PPT | La représentation binaire héritée peut différer du PPTX. Effectuez un cycle sauvegarde‑réouverture séparé et testez la lecture ; ne déduisez pas une prise en charge de chaque combinaison personnalisée à partir d’une réussite PPTX. |
| PDF, PNG, JPEG et autres images de diapositives statiques | Contiennent une représentation statique d’une diapositive, pas de chronologie de comportements jouable ni d’image d’animation finale garantie. |
| [HTML5](/slides/fr/python-java/export-to-html5/) | Peut lire les animations prises en charge lorsque l’animation de forme est activée dans les options d’exportation. Testez les combinaisons personnalisées dans le navigateur. |
| [GIF animé](/slides/fr/python-java/convert-powerpoint-to-animated-gif/) | Stocke les images rendues, pas les comportements éditables ni les interactions déclenchées par clic. Vérifiez le mouvement réellement rendu. |
| [Vidéo](/slides/fr/python-java/convert-powerpoint-to-video/) | Rend les images d’animation et les encode en vidéo. La prise en charge est limitée aux [animations et effets pris en charge](/slides/fr/python-java/convert-powerpoint-to-video/#supported-animations-and-effects) du moteur ; les commandes et événements interactifs ne deviennent pas une timeline éditable. |

## **FAQ**

**Pourquoi mon effet contient‑il des comportements avant que j’en ajoute ?**

La création d’un effet prédéfini peut générer ses opérations sous‑jacentes. Inspectez‑les avant de décider d’étendre le préréglage ou de remplacer ses comportements.

**Déplacer un comportement au début le fait‑il jouer en premier ?**

Pas nécessairement. L’ordre de la collection ne remplace pas le chronométrage. Vérifiez les délais, les durées et les interactions entre les opérations sur la même propriété.

**Pourquoi une commande de fin n’a‑t‑elle aucun point ?**

Elle marque la fin du chemin et n’a pas besoin de coordonnées. Vérifiez la présence d’un tableau de points nul lors de l’inspection d’un chemin lu d’un fichier.

**Un aller‑retour réussi suffit‑il à confirmer la lecture ?**

Non. La réouverture confirme la préservation des propriétés vérifiées. Testez séparément le lecteur de diaporama ou l’export animé pour confirmer le comportement visuel.