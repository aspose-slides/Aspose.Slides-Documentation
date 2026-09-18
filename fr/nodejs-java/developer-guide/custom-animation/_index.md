---
title: Créer et modifier des comportements d'animation personnalisés en JavaScript
linktitle: Animation personnalisée
type: docs
weight: 151
url: /fr/nodejs-java/custom-animation/
keywords:
- animation personnalisée
- comportement d'animation
- chemin de mouvement
- PowerPoint
- présentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Créer, inspecter et modifier des comportements d'animation personnalisés ainsi que des chemins de mouvement éditables dans les présentations PowerPoint avec Aspose.Slides pour Node.js via Java."
---
## **Vue d'ensemble**

Les comportements d'animation personnalisés vous permettent de contrôler des opérations individuelles au sein d'un effet d'animation, comme changer une couleur, faire pivoter une forme ou suivre un tracé de mouvement modifiable. Ce guide explique comment créer et combiner des comportements, configurer leur chronologie, inspecter et modifier les animations existantes, et vérifier que leurs propriétés survivent à l'enregistrement et à la réouverture d'une présentation.

Pour les effets prédéfinis et les déclencheurs de clic, voir [Animation de forme](/slides/fr/nodejs-java/shape-animation/).

## **Comprendre le modèle d'animation**

- La méthode [getTimeline](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/baseslide/#getTimeline) renvoie la chronologie de la diapositive, qui contient sa séquence principale et ses séquences interactives.
- Une [Sequence](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/sequence/) contient des effets, pouvant cibler différentes formes.
- Un [Effect](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/effect/) identifie une forme cible, un préréglage, un sous-type et le chronométrage de l'effet.
- La collection renvoyée par [Effect.getBehaviors](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/effect/#getBehaviors) contient les opérations qui implémentent l'effet : changement de couleur, déplacement, rotation, définition d'une propriété, etc.

## **Créer des comportements individuels**

Appelez [Sequence.addEffect](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/sequence/#addEffect) pour créer un effet et accéder à la collection [getBehaviors](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/effect/#getBehaviors). Un préréglage peut remplir cette collection automatiquement. Conservez ses opérations lors de l'extension du préréglage, ou utilisez [clear](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/behaviorcollection/#clear) lorsque vous les remplacez délibérément.

[BehaviorFactory](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/behaviorfactory/) crée les huit types de comportements illustrés ci-dessous. Le mouvement est abordé dans [Créer un chemin de mouvement](#build-a-motion-path). Chaque extrait inclut les importations de modules et peut être exécuté comme un script Node.js avec les packages `aspose.slides.via.java` et `java` installés. Exécutez les exemples de création de fichiers avant ceux qui lisent leur sortie. Les exemples d'édition ultérieurs indiquent quel fichier de sortie ils utilisent.

### **Rotation**

Utilisez [createRotationEffect](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/behaviorfactory/#createRotationEffect) pour créer une rotation. [getBy](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/rotationeffect/#getBy) spécifie un angle relatif en degrés ; [getFrom](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/rotationeffect/#getFrom) et [getTo](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/rotationeffect/#getTo) spécifient les points de départ et d'arrivée.

L'exemple commence avec un effet Spin, remplace ses opérations de préréglage par un seul comportement de rotation, et attribue à cette opération une durée de deux secondes. Un angle relatif de 90 degrés représente un quart de tour par rapport à l'orientation initiale de la forme, ainsi aucun angle de départ explicite n'est requis.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 160, 80);

    const effect = slide.getTimeline().getMainSequence().addEffect(shape, aspose.slides.EffectType.Spin, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    const factory = new aspose.slides.BehaviorFactory();
    const rotation = factory.createRotationEffect();
    rotation.setBy(90);
    rotation.getTiming().setDuration(2);

    effect.getBehaviors().add(rotation);

    presentation.save("rotation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`rotation.pptx` contient une forme et un comportement de rotation. La collection, le chronométrage et les exemples de modification de rotation ci‑dessous utilisent ce fichier.

### **Mise à l'échelle**

Utilisez [createScaleEffect](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/behaviorfactory/#createScaleEffect) avec des pourcentages X/Y : [getFrom](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/scaleeffect/#getFrom) et [getTo](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/scaleeffect/#getTo) décrivent la taille de départ et d'arrivée, tandis que [getBy](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/scaleeffect/#getBy) décrit une variation relative. Ici, 100 représente la taille originale.

L'exemple augmente les deux dimensions de 100 % à 125 % en deux secondes. Utiliser des pourcentages horizontaux et verticaux égaux conserve les proportions de la forme ; des pourcentages différents étireraient davantage une dimension que l'autre.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 160, 80);

    const effect = slide.getTimeline().getMainSequence().addEffect(shape, aspose.slides.EffectType.GrowShrink, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    const factory = new aspose.slides.BehaviorFactory();
    const scale = factory.createScaleEffect();
    scale.setFrom(java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(100), java.newFloat(100)));
    scale.setTo(java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(125), java.newFloat(125)));
    scale.getTiming().setDuration(2);

    effect.getBehaviors().add(scale);

    presentation.save("scale.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Couleur**

Utilisez [createColorEffect](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/behaviorfactory/#createColorEffect) pour changer le remplissage du bleu à l'orange. [getFrom](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/coloreffect/#getFrom) et [getTo](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/coloreffect/#getTo) sont des couleurs ; [getBy](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/coloreffect/#getBy) est un décalage de couleur. [Behavior.getProperties](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/behavior/#getProperties) identifie l'attribut animé.

Le remplissage uni de la forme est initialisé en bleu, correspondant à la couleur de départ de l'animation. Sélectionner l'attribut couleur de remplissage indique au comportement quelle partie de la forme modifier ; les points de couleur seuls n'identifient pas cet attribut. L'effet sauvegardé décrit une transition de deux secondes vers l'orange.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 160, 80);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    const effect = slide.getTimeline().getMainSequence().addEffect(shape, aspose.slides.EffectType.ChangeFillColor, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    const factory = new aspose.slides.BehaviorFactory();
    const color = factory.createColorEffect();
    color.getProperties().add(aspose.slides.BehaviorProperty.getFillColor().getValue());
    color.getFrom().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    const orange = java.newInstanceSync("java.awt.Color", 255, 165, 0);
    color.getTo().setColor(orange);
    color.getTiming().setDuration(2);

    effect.getBehaviors().add(color);

    presentation.save("color.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Filtre**

Utilisez [createFilterEffect](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/behaviorfactory/#createFilterEffect) pour sélectionner un effet d'effacement. [getType](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/filtereffect/#getType), [getSubtype](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/filtereffect/#getSubtype), et [getReveal](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/filtereffect/#getReveal) spécifient le filtre, la direction et s'il faut révéler ou masquer la forme.

Cet exemple configure un effacement de deux secondes qui révèle la forme en utilisant le sous‑type direction droite. Les paramètres du filtre appartiennent au comportement à l'intérieur de l'effet, ils sont donc configurés après la suppression des opérations originales du préréglage.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 160, 80);

    const effect = slide.getTimeline().getMainSequence().addEffect(shape, aspose.slides.EffectType.Wipe, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    const factory = new aspose.slides.BehaviorFactory();
    const filter = factory.createFilterEffect();
    filter.setType(aspose.slides.FilterEffectType.Wipe);
    filter.setSubtype(aspose.slides.FilterEffectSubtype.Right);
    filter.setReveal(aspose.slides.FilterEffectRevealType.In);
    filter.getTiming().setDuration(2);

    effect.getBehaviors().add(filter);

    presentation.save("filter.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Propriété**

Utilisez [createPropertyEffect](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/behaviorfactory/#createPropertyEffect) pour animer l'opacité. [getFrom](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/propertyeffect/#getFrom), [getTo](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/propertyeffect/#getTo), et [getBy](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/propertyeffect/#getBy) sont des chaînes interprétées à l'aide de [getValueType](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/propertyeffect/#getValueType) et [getCalcMode](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/propertyeffect/#getCalcMode). Choisissez des points d'arrivée ou un décalage relatif plutôt que de définir les trois de manière indifférenciée.

Ici, l'attribut sélectionné est l'opacité, et les chaînes numériques représentent un changement de 25 % d'opacité à une opacité totale. L'interpolation linéaire décrit une transition progressive entre ces valeurs. Lors de l'adaptation de cet exemple à un autre attribut, choisissez un type de valeur et des valeurs d'extrémité appropriées à cet attribut.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 160, 80);

    const effect = slide.getTimeline().getMainSequence().addEffect(shape, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    const factory = new aspose.slides.BehaviorFactory();
    const property = factory.createPropertyEffect();
    property.getProperties().add(aspose.slides.BehaviorProperty.getStyleOpacity().getValue());
    property.setValueType(aspose.slides.PropertyValueType.Number);
    property.setCalcMode(aspose.slides.PropertyCalcModeType.Linear);
    property.setFrom("0.25");
    property.setTo("1");
    property.getTiming().setDuration(2);

    effect.getBehaviors().add(property);

    presentation.save("property.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Définir**

Utilisez [createSetEffect](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/behaviorfactory/#createSetEffect) pour attribuer la visibilité via [getTo](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/seteffect/#getTo). Un comportement de type set n'interpole pas entre les points d'arrivée.

L'exemple sélectionne l'attribut visibilité et attribue la chaîne `visible` lorsque le comportement s'exécute. Le rectangle est déjà visible dans cette présentation minimale, ainsi l'affectation peut ne pas produire de changement visuel évident seule. Une telle opération est utile dans le cadre d'un effet plus vaste qui contrôle également le moment où la forme devient masquée ou visible.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 160, 80);

    const effect = slide.getTimeline().getMainSequence().addEffect(shape, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    const factory = new aspose.slides.BehaviorFactory();
    const set = factory.createSetEffect();
    set.getProperties().add(aspose.slides.BehaviorProperty.getStyleVisibility().getValue());
    set.setTo("visible");

    effect.getBehaviors().add(set);

    presentation.save("set.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Commande**

Utilisez [createCommandEffect](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/behaviorfactory/#createCommandEffect) et configurez [getType](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/commandeffect/#getType), [getCommandString](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/commandeffect/#getCommandString), et [getShapeTarget](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/commandeffect/#getShapeTarget). Placez un enregistrement WAV nommé `sample.wav` dans le répertoire de travail. Cet exemple l'intègre avec [addAudioFrameEmbedded](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/shapecollection/#addAudioFrameEmbedded) et associe une commande de lecture à la trame audio.

La trame audio est à la fois la cible de l'effet et la cible de la commande. Cela relie la demande de lecture à l'enregistrement intégré ; une chaîne de commande seule n'identifie pas quel objet multimédia contrôler. L'effet est configuré pour démarrer sur un clic pendant le diaporama.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const audioStream = java.newInstanceSync("java.io.FileInputStream", "sample.wav");
    try {
        const audioFrame = slide.getShapes().addAudioFrameEmbedded(100, 100, 40, 40, audioStream);

        const effect = slide.getTimeline().getMainSequence().addEffect(audioFrame, aspose.slides.EffectType.MediaPlay, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
        effect.getBehaviors().clear();

        const factory = new aspose.slides.BehaviorFactory();
        const command = factory.createCommandEffect();
        command.setType(java.newByte(aspose.slides.CommandEffectType.Call));
        command.setCommandString("play");
        command.setShapeTarget(audioFrame);

        effect.getBehaviors().add(command);

        presentation.save("command.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        audioStream.close();
    }
} finally {
    presentation.dispose();
}
```

L'enregistrement stocke la commande dans `command.pptx` ; cela ne lit pas l'enregistrement. La lecture nécessite un lecteur de diaporama qui supporte la commande et sa cible multimédia.

## **Gérer la collection de comportements**

[BehaviorCollection](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/behaviorcollection/) prend en charge [add](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/behaviorcollection/#add), [insert](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/behaviorcollection/#insert), [remove](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/behaviorcollection/#remove), et [removeAt](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/behaviorcollection/#removeAt). Cet exemple ouvre `rotation.pptx`, ajoute une mise à l'échelle, la déplace avant la rotation et supprime la rotation. Supprimer et réinsérer le même objet modifie sa position stockée sans en faire une copie.

La séquence d'éditions change la collection de rotation‑mise à l'échelle à mise à l'échelle‑rotation, puis à seule mise à l'échelle. Les indices se réfèrent à la collection actuelle, ainsi la suppression utilise le nouvel indice de la rotation après le réordonnancement. L'énumération finale confirme quel comportement sera enregistré.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("rotation.pptx");
try {
    const effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    const behaviors = effect.getBehaviors();

    const factory = new aspose.slides.BehaviorFactory();
    const scale = factory.createScaleEffect();
    scale.setTo(java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(125), java.newFloat(125)));
    scale.getTiming().setDuration(2);

    behaviors.add(scale);

    behaviors.remove(scale);
    behaviors.insert(0, scale);
    behaviors.removeAt(1);

    for (let i = 0; i < behaviors.getCount(); i++) {
        const behavior = behaviors.get_Item(i);
        console.log(behavior.getClass().getSimpleName());
    }

    presentation.save("collection-edited.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

La sortie est `ScaleEffect` : seule la mise à l'échelle reste. L'ordre de la collection ne programme pas, à lui seul, les comportements l'un après l'autre. Videz la collection uniquement lors du remplacement de toutes ses opérations.

## **Configurer le chronométrage des comportements**

[Behavior.getTiming](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/behavior/#getTiming) expose [Timing](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/timing/), indépendamment de [Effect.getTiming](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/effect/#getTiming). Le chronométrage de l'effet programme l'effet enveloppant ; le chronométrage du comportement décrit une opération à l'intérieur.

### **Définir la durée, le délai, la répétition et l'accélération**

Ouvrez `rotation.pptx` et définissez la durée ([getDuration](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/timing/#getDuration)) ainsi que le délai de déclencheur ([getTriggerDelayTime](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/timing/#getTriggerDelayTime)) en secondes, puis configurez le nombre de répétitions via [setRepeatCount](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/timing/#setRepeatCount). [getAccelerate](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/timing/#getAccelerate) et [getDecelerate](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/timing/#getDecelerate) sont des fractions de la durée ; gardez leur somme au plus à 1.

Le fichier d'entrée est celui créé dans l'exemple de rotation, où le premier comportement est connu comme étant une rotation. Cet exemple ne modifie que le chronométrage de ce comportement ; son angle de 90 degrés reste inchangé. Séparer l'angle et le chronométrage facilite l'ajustement du rythme sans reconstruire l'animation.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("rotation.pptx");
try {
    const effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

    const rotation = effect.getBehaviors().get_Item(0);
    rotation.getTiming().setDuration(2);
    rotation.getTiming().setTriggerDelayTime(java.newFloat(0.5));
    rotation.getTiming().setRepeatCount(3);
    rotation.getTiming().setAccelerate(java.newFloat(0.2));
    rotation.getTiming().setDecelerate(java.newFloat(0.2));

    presentation.save("timing.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le comportement utilise une durée de deux secondes, un délai de 0,5 seconde et un nombre de répétitions de 3. Les 20 % initiaux et finaux de sa durée sont utilisés pour l'accélération et la décélération.

Les autres politiques de répétition incluent [getRepeatDuration](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/timing/#getRepeatDuration), [getRepeatUntilEndSlide](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/timing/#getRepeatUntilEndSlide), et [getRepeatUntilNextClick](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/timing/#getRepeatUntilNextClick); choisissez une politique plutôt que de les activer toutes ensemble. [getAutoReverse](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/timing/#getAutoReverse) lit l'animation à l'envers après le passage en avant. L'accélération et la décélération s'appliquent aux changements continus, pas aux affectations ou commandes discrètes.

## **Créer un chemin de mouvement**

Utilisez [createMotionEffect](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/behaviorfactory/#createMotionEffect) pour créer un mouvement. Ses [getFrom](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/motioneffect/#getFrom), [getTo](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/motioneffect/#getTo), et [getBy](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/motioneffect/#getBy) décrivent des coordonnées ou des décalages basés sur des pourcentages. Pour un tracé modifiable, créez un [MotionPath](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/motionpath/) et assignez‑le avec [MotionEffect.setPath](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/motioneffect/#setPath). [MotionPath](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/motionpath/) stocke les commandes du chemin.

| Commande | Points | Signification |
| --- | --- | --- |
| MoveTo | One | Définir la position de départ. |
| LineTo | One | Se déplacer le long d'un segment droit jusqu'à son point d'arrivée. |
| CurveTo | Three | Suivre une courbe cubique définie par deux points de contrôle et un point d'arrivée. |
| CloseLoop | None | Revenir à la position de départ. |
| End | None | Terminer le chemin. |

[MotionPathPointsType](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/motionpathpointstype/) décrit les caractéristiques d'édition des points, comme les points d'angle ou lisses. Il ne remplace pas le type de commande. Utilisez un type de point de courbe pour l'exemple de courbe ci‑dessous, et un type de point d'angle pour les segments droits.

Les coordonnées du chemin sont normalisées aux dimensions de la diapositive : un déplacement X de 0,25 représente un quart de la largeur de la diapositive, pas 0,25 point. Le Y positif descend. Les commandes absolues spécifient les positions dans le système de coordonnées du chemin ; les commandes relatives spécifient des décalages par rapport à la position actuelle. Cela est distinct de [getOrigin](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/motioneffect/#getOrigin), qui sélectionne le cadre de référence du chemin, et de [getPathEditMode](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/motioneffect/#getPathEditMode), qui contrôle comment le chemin se déplace lorsque la forme est déplacée.

### **Créer un chemin droit**

Créez un comportement de mouvement avec un point de départ, un segment droit, et une commande de fin. [MotionPath.add](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/motionpath/#add) prend le type de commande, ses points, le type de point, et un indicateur de coordonnées relatives.

La commande de départ établit (0, 0), et la ligne se termine à (0,25, 0), donnant au tracé un déplacement horizontal d'un quart de la largeur de la diapositive. La commande de fin n'a aucun point de coordonnées. Une fois le chemin assigné, l'ajout du comportement de mouvement à l'effet relie ce tracé au rectangle.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 160, 80);

    const effect = slide.getTimeline().getMainSequence().addEffect(shape, aspose.slides.EffectType.PathRight, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    const factory = new aspose.slides.BehaviorFactory();
    const motion = factory.createMotionEffect();
    motion.setOrigin(aspose.slides.MotionOriginType.Layout);
    motion.getTiming().setDuration(2);

    const path = new aspose.slides.MotionPath();
    path.add(aspose.slides.MotionCommandPathType.MoveTo, java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0), java.newFloat(0))]), aspose.slides.MotionPathPointsType.Auto, false);
    path.add(aspose.slides.MotionCommandPathType.LineTo, java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.25), java.newFloat(0))]), aspose.slides.MotionPathPointsType.Corner, false);
    path.add(aspose.slides.MotionCommandPathType.End, java.newArray("java.awt.geom.Point2D$Float", []), aspose.slides.MotionPathPointsType.None, false);

    motion.setPath(path);
    effect.getBehaviors().add(motion);

    presentation.save("motion.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`motion.pptx` contient un comportement de mouvement avec trois commandes de chemin. Les exemples d'édition de fichier suivants utilisent cette structure connue.

### **Comparer les coordonnées absolues et relatives**

Ces deux objets de chemin décrivent le même tracé. La commande absolue se termine à (0,3, 0,1) ; la commande relative ajoute (0,1, 0,1) à la position actuelle, (0,2, 0).  

Les deux chemins démarrent à la même position. Pour la ligne relative, ajoutez ses décalages X et Y à la position actuelle pour obtenir le point d'arrivée ; pour la ligne absolue, lisez directement le point d'arrivée. Basculer l'indicateur sans convertir les coordonnées décrirait un tracé différent.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const absolutePath = new aspose.slides.MotionPath();
absolutePath.add(aspose.slides.MotionCommandPathType.MoveTo, java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.2), java.newFloat(0))]), aspose.slides.MotionPathPointsType.Auto, false);
absolutePath.add(aspose.slides.MotionCommandPathType.LineTo, java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.3), java.newFloat(0.1))]), aspose.slides.MotionPathPointsType.Corner, false);

const relativePath = new aspose.slides.MotionPath();
relativePath.add(aspose.slides.MotionCommandPathType.MoveTo, java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.2), java.newFloat(0))]), aspose.slides.MotionPathPointsType.Auto, false);
relativePath.add(aspose.slides.MotionCommandPathType.LineTo, java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.1), java.newFloat(0.1))]), aspose.slides.MotionPathPointsType.Corner, true);
```

Attribuez l'un ou l'autre chemin à un comportement de mouvement pour l'utiliser dans une présentation. Le dernier argument booléen sélectionne les coordonnées relatives pour cette commande.

### **Remplacer une ligne par une courbe**

Ouvrez `motion.pptx` et remplacez sa commande de ligne par une courbe cubique. Fournissez d'abord les deux points de contrôle, puis le point d'arrivée.

La position de départ est fournie par la commande précédente. Les deux premiers points façonnent la courbe, tandis que le troisième est sa destination ; ils ne sont pas trois destinations successives. Mettre à jour le type de commande, le type d'édition des points et le tableau de points simultanément maintient le segment cohérent avec sa nouvelle géométrie.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("motion.pptx");
try {
    const effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    const motion = effect.getBehaviors().get_Item(0);

    const path = motion.getPath();
    path.get_Item(1).setCommandType(aspose.slides.MotionCommandPathType.CurveTo);
    path.get_Item(1).setPointsType(aspose.slides.MotionPathPointsType.CurveSmooth);
    path.get_Item(1).setPoints(java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.1), java.newFloat(0)), java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.2), java.newFloat(0.1)), java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.3), java.newFloat(0.1))]));

    presentation.save("curve.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le chemin dans `curve.pptx` possède toujours trois commandes ; sa commande du milieu définit désormais une courbe.

## **Inspecter et modifier un chemin enregistré**

Chaque [MotionCmdPath](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/motioncmdpath/) expose [getPoints](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/motioncmdpath/#getPoints), [getCommandType](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/motioncmdpath/#getCommandType), [getPointsType](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/motioncmdpath/#getPointsType), et [isRelative](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/motioncmdpath/#isRelative). Les exemples suivants utilisent le chemin connu à trois commandes dans `motion.pptx`. Pour une entrée arbitraire, localisez l'effet souhaité et vérifiez les types de commandes et le nombre de points avant d'éditer par indice.

### **Lire les commandes et les coordonnées**

Lisez le chemin sans le modifier. Les commandes End et CloseLoop n'ont pas besoin de points, prévoyez donc un tableau de points nul.

La sortie associe chaque type de commande numérique à son indicateur de coordonnées relatives avant de lister ses points. Cela vous permet de distinguer un point d'arrivée d'un décalage avant de modifier le chemin. Une courbe listerait trois points, tandis que la ligne droite dans ce fichier n'en liste qu'un.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("motion.pptx");
try {
    const effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    const motion = effect.getBehaviors().get_Item(0);

    const path = motion.getPath();
    for (let i = 0; i < path.getCount(); i++) {
        const segment = path.get_Item(i);
        console.log(segment.getCommandType() + ", relative: " + segment.isRelative());
        const points = segment.getPoints();
        if (points != null) {
            for (const point of points) {
                console.log("X=" + point.getX() + ", Y=" + point.getY());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

### **Modifier un point d'arrivée**

Ouvrez `motion.pptx` et remplacez le tableau de points de la ligne pour déplacer son point d'arrivée.

Dans le fichier d'entrée, l'indice 0 correspond à la commande de départ et l'indice 1 à la ligne. Remplacer le point unique de la ligne change sa destination sans modifier son type de commande, son chronométrage ou sa position dans la collection. Comme la commande utilise des coordonnées absolues, la nouvelle paire spécifie une position plutôt qu'un décalage ajouté.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("motion.pptx");
try {
    const effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

    const motion = effect.getBehaviors().get_Item(0);
    motion.getPath().get_Item(1).setPoints(java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.4), java.newFloat(0.1))]));

    presentation.save("motion-endpoint.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

La ligne dans `motion-endpoint.pptx` se termine à (0,4, 0,1) ; le fichier original reste inchangé.

### **Remplacer un segment**

Utilisez [insert](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/motionpath/#insert) et [removeAt](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/motionpath/#removeAt) pour remplacer la ligne dans `motion.pptx`. L'insertion décale l'ancienne ligne à l'indice 2.

Cela montre le remplacement d'un objet de commande plutôt que la modification de ses coordonnées existantes. Après l'insertion, la collection contient temporairement la commande de départ, la nouvelle ligne, l'ancienne ligne et la commande de fin. La suppression de l'indice 2 élimine l'ancienne ligne et laisse le nouveau tracé en place.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("motion.pptx");
try {
    const effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    const motion = effect.getBehaviors().get_Item(0);

    const path = motion.getPath();
    path.insert(1, aspose.slides.MotionCommandPathType.LineTo, java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.2), java.newFloat(0.1))]), aspose.slides.MotionPathPointsType.Corner, false);
    path.removeAt(2);

    presentation.save("motion-edited.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le chemin enregistré possède toujours trois commandes, la nouvelle ligne se terminant à (0,2, 0,1) et la commande de fin en dernière position.

## **Modifier et vérifier un comportement existant**

Lorsque l'indice du comportement est inconnu, sélectionnez‑le par type. Cet exemple ouvre `rotation.pptx`, trouve son [RotationEffect](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/rotationeffect/), modifie l'angle, et vérifie la valeur enregistrée après réouverture.

La vérification du type permet à la boucle d'ignorer les comportements qui ne sont pas des rotations. Le second chargement lit le fichier enregistré dans un objet de présentation distinct, ainsi la comparaison vérifie les données persistées plutôt que la valeur encore en mémoire. Cet exemple suppose toujours que l'effet connu est le premier de la séquence principale ; sélectionner un comportement par type ne localise pas nécessairement le bon effet dans une présentation quelconque.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("rotation.pptx");
try {
    const effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

    for (let i = 0; i < effect.getBehaviors().getCount(); i++) {
        const behavior = effect.getBehaviors().get_Item(i);
        if (java.instanceOf(behavior, "com.aspose.slides.IRotationEffect")) {
            const rotation = behavior;
            rotation.setBy(180);
        }
    }

    presentation.save("rotation-edited.pptx", aspose.slides.SaveFormat.Pptx);

    const reopened = new aspose.slides.Presentation("rotation-edited.pptx");
    try {
        const savedEffect = reopened.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

        for (let i = 0; i < savedEffect.getBehaviors().getCount(); i++) {
            const behavior = savedEffect.getBehaviors().get_Item(i);
            if (java.instanceOf(behavior, "com.aspose.slides.IRotationEffect")) {
                const rotation = behavior;
                console.log("Rotation preserved: " + (Math.abs(rotation.getBy() - 180) < 0.001));
            }
        }
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

La sortie est `Rotation preserved: true`. Appliquez le même schéma de vérification de type aux autres comportements. Pour une vérification complète de la conservation, comparez la forme cible, l'effet, les types et l'ordre des comportements, le chronométrage et les commandes du chemin. Utilisez une tolérance numérique pour les valeurs à virgule flottante. Pour une présentation avec une disposition d'animation inconnue, consultez [Lire les animations de forme](/slides/fr/nodejs-java/shape-animation/#read-shape-animations) pour le parcours des séquences principales et interactives.

## **Ordre des comportements, préréglages et lecture**

L'ordre dans [BehaviorCollection](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/behaviorcollection/) est l'ordre stocké des opérations d'un effet. Ce n'est pas une liste de lecture où chaque comportement attend automatiquement le précédent. Le chronométrage et l'effet enveloppant déterminent la planification. Les comportements peuvent se chevaucher, et les opérations sur la même propriété peuvent interagir via [getAdditive](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/behavior/#getAdditive) et [getAccumulate](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/behavior/#getAccumulate). N'utilisez pas uniquement le réordonnancement de la collection pour planifier « déplacer, puis pivoter » ; utilisez un chronométrage explicite ou des effets séparés comme décrit dans [Animation de forme](/slides/fr/nodejs-java/shape-animation/).

Les [getType](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/effect/#getType) et [getSubtype](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/effect/#getSubtype) de l'effet décrivent son préréglage. Ils ne constituent pas une description complète d'un arbre de comportements édité. Choisissez le préréglage et le sous‑type avant de personnaliser les comportements : modifier le préréglage peut reconstruire la collection et supprimer vos opérations personnalisées. Par exemple, changer un effet Spin personnalisé en Fade peut remplacer son comportement de rotation par des comportements set et filter. Inspectez à nouveau la collection après avoir changé un préréglage ou un sous‑type. Vider les comportements du préréglage peut également supprimer les opérations de visibilité ou d'initialisation dont le préréglage a besoin. Les exemples utilisent délibérément des formes visibles et remplacent les comportements ; ils ne reconstruisent pas chaque implémentation de préréglage.

## **Compatibilité des formats**

Un arbre de comportements conservé ne garantit pas une lecture identique dans chaque visionneur ou moteur d'exportation. Vérifiez séparément les données enregistrées et le rendu produit.

| Format ou sortie | Ce qu’il faut vérifier |
| --- | --- |
| PPTX | Utilisez‑le comme format principal pour ces exemples. Rouvrez‑le pour vérifier l'arbre de comportements éditable, puis testez la lecture dans la version PowerPoint visée. |
| PPT | La représentation binaire héritée peut différer du PPTX. Testez un cycle d’enregistrement‑re‑ouverture séparé et la lecture ; ne déduisez pas la prise en charge de chaque combinaison personnalisée à partir d’un PPTX réussi. |
| PDF, PNG, JPEG, et autres images de diapositive statiques | Contiennent une représentation statique de la diapositive, pas de chronologie de comportement jouable ni d'image d'animation finale garantie. |
| [HTML5](/slides/fr/nodejs-java/export-to-html5/) | Peut lire les animations prises en charge lorsque l'animation de forme est activée dans les options d’export. Testez les combinaisons personnalisées dans le navigateur. |
| [Animated GIF](/slides/fr/nodejs-java/convert-powerpoint-to-animated-gif/) | Stocke les images rendues, pas les comportements éditables ou les interactions déclenchées par un clic. Vérifiez le mouvement réellement rendu. |
| [Video](/slides/fr/nodejs-java/convert-powerpoint-to-video/) | Rend les images d’animation et les encode en vidéo. Le support est limité aux [animations et effets pris en charge](/slides/fr/nodejs-java/convert-powerpoint-to-video/#supported-animations-and-effects) du moteur d’affichage ; les commandes et événements interactifs ne deviennent pas une chronologie éditable. |

## **FAQ**

**Pourquoi mon effet contient‑il des comportements avant que j’en ajoute ?**

Créer un effet prédéfini peut générer ses opérations sous‑jacentes. Inspectez‑les avant de décider d’étendre le préréglage ou de remplacer ses comportements.

**Déplacer un comportement au début le fait‑il jouer en premier ?**

Pas nécessairement. L'ordre de la collection ne remplace pas le chronométrage. Vérifiez les délais, les durées et les interactions entre les opérations sur la même propriété.

**Pourquoi une commande End n’a‑t‑elle pas de points ?**

Elle marque la fin du chemin et n’a pas besoin de coordonnées. Vérifiez la présence d’un tableau de points nul lors de l’inspection d’un chemin lu depuis un fichier.

**Un aller‑retour réussi suffit‑il à confirmer la lecture ?**

Non. La réouverture confirme la conservation des propriétés vérifiées. Testez séparément le lecteur de diaporama ou l’export animé pour confirmer son comportement visuel.