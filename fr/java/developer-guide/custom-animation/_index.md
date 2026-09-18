---
title: Créer et modifier des comportements d'animation personnalisés en Java
linktitle: Animation personnalisée
type: docs
weight: 151
url: /fr/java/custom-animation/
keywords:
- animation personnalisée
- comportement d'animation
- chemin de mouvement
- PowerPoint
- présentation
- Java
- Aspose.Slides
description: "Créer, inspecter et modifier des comportements d'animation personnalisés et des chemins de mouvement éditables dans les présentations PowerPoint avec Aspose.Slides pour Java."
---
## **Aperçu**

Les comportements d’animation personnalisés vous permettent de contrôler des opérations individuelles au sein d’un effet d’animation, comme changer une couleur, faire pivoter une forme ou suivre un chemin de mouvement modifiable. Ce guide montre comment créer et combiner des comportements, configurer leur synchronisation, inspecter et modifier des animations existantes, et vérifier que leurs propriétés persistent après la sauvegarde et la réouverture d’une présentation.

Pour les effets prédéfinis et les déclencheurs de clic, voir [Animation de forme](/slides/fr/java/shape-animation/).

## **Comprendre le modèle d'animation**

Une animation est organisée comme **Chronologie → Séquence → Effet → Comportements** :

- La méthode [getTimeline](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ibaseslide/#getTimeline--) renvoie la chronologie de la diapositive, qui contient sa séquence principale et les séquences interactives.
- Un [ISequence](https://reference.aspose.com/slides/fr/java/com.aspose.slides/isequence/) contient des effets, pouvant cibler différentes formes.
- Un [IEffect](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ieffect/) identifie une forme cible, un préréglage, un sous‑type et la synchronisation de l’effet.
- La collection renvoyée par [IEffect.getBehaviors](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ieffect/#getBehaviors--) contient les opérations qui implémentent l’effet : changer la couleur, déplacer, faire pivoter, définir une propriété, etc.

## **Créer des comportements individuels**

Appelez [ISequence.addEffect](https://reference.aspose.com/slides/fr/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) pour créer un effet et accéder à la collection [getBehaviors](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ieffect/#getBehaviors--). Un préréglage peut peupler automatiquement cette collection. Conservez ses opérations lors de l’extension du préréglage, ou utilisez [clear](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ibehaviorcollection/#clear--) lorsque vous les remplacez intentionnellement.

[IBehaviorFactory](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ibehaviorfactory/) crée les huit types de comportements illustrés ci‑dessous. Le mouvement est abordé dans [Créer un chemin de mouvement](#build-a-motion-path). Chaque extrait inclut ses imports ; placez ses instructions exécutables à l’intérieur d’une méthode. Les exemples d’édition ultérieure indiquent le fichier de sortie utilisé.

### **Rotation**

Utilisez [createRotationEffect](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ibehaviorfactory/#createRotationEffect--) pour créer une rotation. [getBy](https://reference.aspose.com/slides/fr/java/com.aspose.slides/irotationeffect/#getBy--) spécifie un angle relatif en degrés ; [getFrom](https://reference.aspose.com/slides/fr/java/com.aspose.slides/irotationeffect/#getFrom--) et [getTo](https://reference.aspose.com/slides/fr/java/com.aspose.slides/irotationeffect/#getTo--) définissent les points de départ et d’arrivée.

L’exemple commence avec un effet Spin, remplace ses opérations de préréglage par un seul comportement de rotation et attribue à cette opération une durée de deux secondes. Un angle relatif de 90° représente un quart de tour à partir de l’orientation initiale de la forme, aucune angle de départ explicite n’est donc nécessaire.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

    IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Spin, EffectSubtype.None, EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    IBehaviorFactory factory = new BehaviorFactory();
    IRotationEffect rotation = factory.createRotationEffect();
    rotation.setBy(90f);
    rotation.getTiming().setDuration(2f);

    effect.getBehaviors().add(rotation);

    presentation.save("rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`rotation.pptx` contient une forme et un comportement de rotation. La collection, la synchronisation et les exemples d’édition de rotation ci‑dessous utilisent ce fichier.

### **Échelle**

Utilisez [createScaleEffect](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ibehaviorfactory/#createScaleEffect--) avec des pourcentages X/Y : [getFrom](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iscaleeffect/#getFrom--) et [getTo](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iscaleeffect/#getTo--) décrivent la taille de départ et d’arrivée, tandis que [getBy](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iscaleeffect/#getBy--) décrit un changement relatif. Ici, 100 représente la taille originale.

L’exemple augmente les deux dimensions de 100 % à 125 % pendant deux secondes. Utiliser les mêmes pourcentages horizontaux et verticaux conserve les proportions de la forme ; des pourcentages différents étireraient une dimension davantage que l’autre.

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

    IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.GrowShrink, EffectSubtype.None, EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    IBehaviorFactory factory = new BehaviorFactory();
    IScaleEffect scale = factory.createScaleEffect();
    scale.setFrom(new Point2D.Float(100, 100));
    scale.setTo(new Point2D.Float(125, 125));
    scale.getTiming().setDuration(2f);

    effect.getBehaviors().add(scale);

    presentation.save("scale.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Couleur**

Utilisez [createColorEffect](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ibehaviorfactory/#createColorEffect--) pour changer le remplissage du bleu à l’orange. [getFrom](https://reference.aspose.com/slides/fr/java/com.aspose.slides/icoloreffect/#getFrom--) et [getTo](https://reference.aspose.com/slides/fr/java/com.aspose.slides/icoloreffect/#getTo--) sont des couleurs ; [getBy](https://reference.aspose.com/slides/fr/java/com.aspose.slides/icoloreffect/#getBy--) est un décalage de couleur. [IBehavior.getProperties](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ibehavior/#getProperties--) identifie l’attribut animé.

Le remplissage solide de la forme est initialisé en bleu, correspondant à la couleur de départ de l’animation. Sélectionner l’attribut remplissage‑couleur indique au comportement quelle partie de la forme modifier ; les points de couleur seuls n’identifient pas cet attribut. L’effet enregistré décrit une transition de deux secondes vers l’orange.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.ChangeFillColor, EffectSubtype.None, EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    IBehaviorFactory factory = new BehaviorFactory();
    IColorEffect color = factory.createColorEffect();
    color.getProperties().add(BehaviorProperty.getFillColor().getValue());
    color.getFrom().setColor(Color.BLUE);
    Color orange = new Color(255, 165, 0);
    color.getTo().setColor(orange);
    color.getTiming().setDuration(2f);

    effect.getBehaviors().add(color);

    presentation.save("color.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Filtre**

Utilisez [createFilterEffect](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ibehaviorfactory/#createFilterEffect--) pour sélectionner un balayage. [getType](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ifiltereffect/#getType--), [getSubtype](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ifiltereffect/#getSubtype--), et [getReveal](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ifiltereffect/#getReveal--) spécifient le filtre, la direction et s’il faut révéler ou masquer la forme.

Cet exemple configure un balayage de deux secondes qui révèle la forme en utilisant le sous‑type de direction droite. Les paramètres du filtre appartiennent au comportement à l’intérieur de l’effet, ils sont donc configurés après la suppression des opérations originales du préréglage.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

    IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Wipe, EffectSubtype.None, EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    IBehaviorFactory factory = new BehaviorFactory();
    IFilterEffect filter = factory.createFilterEffect();
    filter.setType(FilterEffectType.Wipe);
    filter.setSubtype(FilterEffectSubtype.Right);
    filter.setReveal(FilterEffectRevealType.In);
    filter.getTiming().setDuration(2f);

    effect.getBehaviors().add(filter);

    presentation.save("filter.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Propriété**

Utilisez [createPropertyEffect](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ibehaviorfactory/#createPropertyEffect--) pour animer l’opacité. [getFrom](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ipropertyeffect/#getFrom--), [getTo](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ipropertyeffect/#getTo--), et [getBy](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ipropertyeffect/#getBy--) sont des chaînes interprétées grâce à [getValueType](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ipropertyeffect/#getValueType--) et [getCalcMode](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ipropertyeffect/#getCalcMode--). Choisissez des points d’arrivée ou un décalage relatif plutôt que de définir les trois simultanément.

Ici, l’attribut sélectionné est l’opacité, et les chaînes numériques représentent un passage de 25 % d’opacité à une opacité totale. L’interpolation linéaire décrit une variation graduelle entre ces valeurs. Lors de l’adaptation de cet exemple à une autre propriété, choisissez un type de valeur et des valeurs d’extrémité appropriés à cette propriété.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

    IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    IBehaviorFactory factory = new BehaviorFactory();
    IPropertyEffect property = factory.createPropertyEffect();
    property.getProperties().add(BehaviorProperty.getStyleOpacity().getValue());
    property.setValueType(PropertyValueType.Number);
    property.setCalcMode(PropertyCalcModeType.Linear);
    property.setFrom("0.25");
    property.setTo("1");
    property.getTiming().setDuration(2f);

    effect.getBehaviors().add(property);

    presentation.save("property.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Définir**

Utilisez [createSetEffect](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ibehaviorfactory/#createSetEffect--) pour assigner la visibilité via [getTo](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iseteffect/#getTo--). Un comportement de type *set* n’interpole pas entre les points d’arrivée.

L’exemple sélectionne l’attribut visibilité et affecte la chaîne `visible` lorsque le comportement s’exécute. Le rectangle est déjà visible dans cette présentation minimale, si bien que l’affectation peut ne pas produire de changement visuel évident à elle seule. Une telle opération est utile dans le cadre d’un effet plus large qui contrôle également quand la forme devient cachée ou visible.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

    IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Appear, EffectSubtype.None, EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    IBehaviorFactory factory = new BehaviorFactory();
    ISetEffect set = factory.createSetEffect();
    set.getProperties().add(BehaviorProperty.getStyleVisibility().getValue());
    set.setTo("visible");

    effect.getBehaviors().add(set);

    presentation.save("set.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Commande**

Utilisez [createCommandEffect](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ibehaviorfactory/#createCommandEffect--) et configurez [getType](https://reference.aspose.com/slides/fr/java/com.aspose.slides/icommandeffect/#getType--), [getCommandString](https://reference.aspose.com/slides/fr/java/com.aspose.slides/icommandeffect/#getCommandString--), et [getShapeTarget](https://reference.aspose.com/slides/fr/java/com.aspose.slides/icommandeffect/#getShapeTarget--). Placez un enregistrement WAV nommé `sample.wav` dans le répertoire de travail. Cet exemple l’intègre avec [addAudioFrameEmbedded](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ishapecollection/#addAudioFrameEmbedded-float-float-float-float-java.io.InputStream-) et attache une commande de lecture à la trame audio.

La trame audio est à la fois la cible de l’effet et la cible de la commande. Cela relie la demande de lecture à l’enregistrement intégré ; une chaîne de commande seule n’identifie pas l’objet multimédia à contrôler. L’effet est configuré pour démarrer sur un clic pendant le diaporama.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;
import java.io.IOException;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    try (FileInputStream audioStream = new FileInputStream("sample.wav")) {
        IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(100, 100, 40, 40, audioStream);

        IEffect effect = slide.getTimeline().getMainSequence().addEffect(audioFrame, EffectType.MediaPlay, EffectSubtype.None, EffectTriggerType.OnClick);
        effect.getBehaviors().clear();

        IBehaviorFactory factory = new BehaviorFactory();
        ICommandEffect command = factory.createCommandEffect();
        command.setType(CommandEffectType.Call);
        command.setCommandString("play");
        command.setShapeTarget(audioFrame);

        effect.getBehaviors().add(command);

        presentation.save("command.pptx", SaveFormat.Pptx);
    } catch (IOException exception) {
        System.out.println("Unable to read sample.wav: " + exception.getMessage());
    }
} finally {
    presentation.dispose();
}
```

La sauvegarde stocke la commande dans `command.pptx` ; elle ne lit pas l’enregistrement. La lecture nécessite un lecteur de diaporama qui prend en charge la commande et sa cible multimédia.

## **Gérer la collection de comportements**

[IBehaviorCollection](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ibehaviorcollection/) prend en charge [add](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ibehaviorcollection/#add-com.aspose.slides.IBehavior-), [insert](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ibehaviorcollection/#insert-int-com.aspose.slides.IBehavior-), [remove](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ibehaviorcollection/#remove-com.aspose.slides.IBehavior-), et [removeAt](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ibehaviorcollection/#removeAt-int-). Cet exemple ouvre `rotation.pptx`, ajoute une mise à l’échelle, la déplace avant la rotation et supprime la rotation. Supprimer et réinsérer le même objet modifie sa position stockée sans en créer une copie.

La séquence d’éditions change la collection de rotation‑scale à scale‑rotation, puis à scale uniquement. Les indices se réfèrent à la collection courante, de sorte que la suppression utilise le nouvel indice de la rotation après le réordonnancement. L’énumération finale confirme quel comportement sera sauvegardé.

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

Presentation presentation = new Presentation("rotation.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    IBehaviorCollection behaviors = effect.getBehaviors();

    IBehaviorFactory factory = new BehaviorFactory();
    IScaleEffect scale = factory.createScaleEffect();
    scale.setTo(new Point2D.Float(125, 125));
    scale.getTiming().setDuration(2f);

    behaviors.add(scale);

    behaviors.remove(scale);
    behaviors.insert(0, scale);
    behaviors.removeAt(1);

    for (IBehavior behavior : behaviors)
        System.out.println(behavior.getClass().getSimpleName());

    presentation.save("collection-edited.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le résultat est `ScaleEffect` : seule la mise à l’échelle reste. L’ordre de la collection ne planifie pas, à lui seul, les comportements les uns après les autres. Videz la collection uniquement lorsque vous remplacez toutes ses opérations.

## **Configurer la synchronisation des comportements**

[IBehavior.getTiming](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ibehavior/#getTiming--) expose [ITiming](https://reference.aspose.com/slides/fr/java/com.aspose.slides/itiming/), indépendamment de [IEffect.getTiming](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ieffect/#getTiming--). La synchronisation de l’effet planifie l’effet englobant ; la synchronisation du comportement décrit une opération à l’intérieur de celui‑ci.

### **Définir la durée, le retard, la répétition et l'accélération**

Ouvrez `rotation.pptx` et définissez la durée ([getDuration](https://reference.aspose.com/slides/fr/java/com.aspose.slides/itiming/#getDuration--)) et le délai de déclenchement ([getTriggerDelayTime](https://reference.aspose.com/slides/fr/java/com.aspose.slides/itiming/#getTriggerDelayTime--)) en secondes, puis configurez le nombre de répétitions via [setRepeatCount](https://reference.aspose.com/slides/fr/java/com.aspose.slides/itiming/#setRepeatCount-float-). [getAccelerate](https://reference.aspose.com/slides/fr/java/com.aspose.slides/itiming/#getAccelerate--) et [getDecelerate](https://reference.aspose.com/slides/fr/java/com.aspose.slides/itiming/#getDecelerate--) sont des fractions de la durée ; gardez leur somme au plus égale à 1.

Le fichier d’entrée est celui créé dans l’exemple de rotation, où le premier comportement est connu pour être une rotation. Cet exemple ne modifie que la synchronisation de ce comportement ; son angle de 90° reste intact. Séparer l’angle et la synchronisation facilite l’ajustement du rythme sans reconstruire l’animation.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("rotation.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

    IRotationEffect rotation = (IRotationEffect)effect.getBehaviors().get_Item(0);
    rotation.getTiming().setDuration(2f);
    rotation.getTiming().setTriggerDelayTime(0.5f);
    rotation.getTiming().setRepeatCount(3f);
    rotation.getTiming().setAccelerate(0.2f);
    rotation.getTiming().setDecelerate(0.2f);

    presentation.save("timing.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le comportement utilise une durée de deux secondes, un retard de demi‑seconde et un compte de répétition de 3. Les 20 % initiaux et finaux de sa durée sont utilisés pour l’accélération et la décélération.

D’autres politiques de répétition comprennent [getRepeatDuration](https://reference.aspose.com/slides/fr/java/com.aspose.slides/itiming/#getRepeatDuration--), [getRepeatUntilEndSlide](https://reference.aspose.com/slides/fr/java/com.aspose.slides/itiming/#getRepeatUntilEndSlide--), et [getRepeatUntilNextClick](https://reference.aspose.com/slides/fr/java/com.aspose.slides/itiming/#getRepeatUntilNextClick--); choisissez une politique plutôt que de les activer toutes simultanément. [getAutoReverse](https://reference.aspose.com/slides/fr/java/com.aspose.slides/itiming/#getAutoReverse--) lit l’animation à l’envers après le passage en avant. L’accélération et la décélération s’appliquent aux changements continus, pas aux affectations discrètes ou aux commandes.

## **Créer un chemin de mouvement**

Utilisez [createMotionEffect](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ibehaviorfactory/#createMotionEffect--) pour créer un mouvement. Ses [getFrom](https://reference.aspose.com/slides/fr/java/com.aspose.slides/imotioneffect/#getFrom--), [getTo](https://reference.aspose.com/slides/fr/java/com.aspose.slides/imotioneffect/#getTo--), et [getBy](https://reference.aspose.com/slides/fr/java/com.aspose.slides/imotioneffect/#getBy--) décrivent des coordonnées ou des décalages exprimés en pourcentage. Pour une trajectoire modifiable, créez un [MotionPath](https://reference.aspose.com/slides/fr/java/com.aspose.slides/motionpath/) et assignez‑le avec [IMotionEffect.setPath](https://reference.aspose.com/slides/fr/java/com.aspose.slides/imotioneffect/#setPath-com.aspose.slides.IMotionPath-). [IMotionPath](https://reference.aspose.com/slides/fr/java/com.aspose.slides/imotionpath/) stocke les commandes du chemin.

[MotionCommandPathType](https://reference.aspose.com/slides/fr/java/com.aspose.slides/motioncommandpathtype/) sélectionne l’opération :

| Commande | Points | Signification |
| --- | --- | --- |
| MoveTo | Un | Définit la position de départ. |
| LineTo | Un | Déplace le long d’un segment droit jusqu’à son point final. |
| CurveTo | Trois | Suit une courbe cubique définie par deux points de contrôle et un point final. |
| CloseLoop | Aucun | Retourne à la position de départ. |
| End | Aucun | Termine le chemin. |

[MotionPathPointsType](https://reference.aspose.com/slides/fr/java/com.aspose.slides/motionpathpointstype/) décrit les caractéristiques de modification des points, telles que coin ou point lisse. Il ne remplace pas le type de commande. Utilisez un type de point de courbe pour l’exemple de courbe ci‑dessous, et un type de point coin pour les segments droits.

Les coordonnées du chemin sont normalisées aux dimensions de la diapositive : un déplacement X de 0,25 représente un quart de la largeur de la diapositive, pas 0,25 point. Y positif descend. Les commandes absolues spécifient des positions dans le système de coordonnées du chemin ; les commandes relatives spécifient des décalages par rapport à la position courante. Cela est distinct de [getOrigin](https://reference.aspose.com/slides/fr/java/com.aspose.slides/imotioneffect/#getOrigin--), qui sélectionne le cadre de référence du chemin, et de [getPathEditMode](https://reference.aspose.com/slides/fr/java/com.aspose.slides/imotioneffect/#getPathEditMode--), qui contrôle comment le chemin se déplace lorsqu’on déplace la forme.

### **Créer un chemin droit**

Créez un comportement de mouvement avec un point de départ, un segment droit et une commande de fin. [IMotionPath.add](https://reference.aspose.com/slides/fr/java/com.aspose.slides/imotionpath/#add-int-java.awt.geom.Point2D.Float---int-boolean-) prend le type de commande, ses points, le type de point et un indicateur de coordonnées relatives.

La commande de départ établit (0, 0), et la ligne se termine à (0,25, 0), donnant au trajet un déplacement horizontal d’un quart de la largeur de la diapositive. La commande de fin n’a aucun point de coordonnées. Une fois le chemin assigné, ajouter le comportement de mouvement à l’effet relie ce trajet au rectangle.

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

    IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.PathRight, EffectSubtype.None, EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    IBehaviorFactory factory = new BehaviorFactory();
    IMotionEffect motion = factory.createMotionEffect();
    motion.setOrigin(MotionOriginType.Layout);
    motion.getTiming().setDuration(2f);

    IMotionPath path = new MotionPath();
    path.add(MotionCommandPathType.MoveTo, new Point2D.Float[] { new Point2D.Float(0, 0) }, MotionPathPointsType.Auto, false);
    path.add(MotionCommandPathType.LineTo, new Point2D.Float[] { new Point2D.Float(0.25f, 0) }, MotionPathPointsType.Corner, false);
    path.add(MotionCommandPathType.End, new Point2D.Float[0], MotionPathPointsType.None, false);

    motion.setPath(path);
    effect.getBehaviors().add(motion);

    presentation.save("motion.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`motion.pptx` contient un comportement de mouvement avec trois commandes de chemin. Les exemples d’édition de fichier suivants utilisent cette structure connue.

### **Comparer les coordonnées absolues et relatives**

Ces deux objets chemin décrivent le même trajet. La commande absolue se termine à (0,3, 0,1) ; la commande relative ajoute (0,1, 0,1) à la position courante, soit (0,2, 0).

Les deux chemins partent de la même position. Pour la ligne relative, ajoutez ses décalages X et Y à la position courante afin d’obtenir le point final ; pour la ligne absolue, lisez directement le point final. Changer l’indicateur sans convertir les coordonnées décrirait un trajet différent.

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

MotionPath absolutePath = new MotionPath();
absolutePath.add(MotionCommandPathType.MoveTo, new Point2D.Float[] { new Point2D.Float(0.2f, 0) }, MotionPathPointsType.Auto, false);
absolutePath.add(MotionCommandPathType.LineTo, new Point2D.Float[] { new Point2D.Float(0.3f, 0.1f) }, MotionPathPointsType.Corner, false);

MotionPath relativePath = new MotionPath();
relativePath.add(MotionCommandPathType.MoveTo, new Point2D.Float[] { new Point2D.Float(0.2f, 0) }, MotionPathPointsType.Auto, false);
relativePath.add(MotionCommandPathType.LineTo, new Point2D.Float[] { new Point2D.Float(0.1f, 0.1f) }, MotionPathPointsType.Corner, true);
```

Assignez l’un ou l’autre chemin à un comportement de mouvement pour l’utiliser dans une présentation. Le dernier argument booléen sélectionne les coordonnées relatives pour cette commande.

### **Remplacer une ligne par une courbe**

Ouvrez `motion.pptx` et remplacez sa commande de ligne par une courbe cubique. Fournissez d’abord les deux points de contrôle, suivis du point final.

La position de départ est fournie par la commande précédente. Les deux premiers points façonnent la courbe, tandis que le troisième est sa destination ; ils ne sont pas trois destinations successives. Mettre à jour simultanément le type de commande, le type de points et le tableau de points maintient le segment cohérent avec sa nouvelle géométrie.

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

Presentation presentation = new Presentation("motion.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    IMotionEffect motion = (IMotionEffect)effect.getBehaviors().get_Item(0);

    IMotionPath path = motion.getPath();
    path.get_Item(1).setCommandType(MotionCommandPathType.CurveTo);
    path.get_Item(1).setPointsType(MotionPathPointsType.CurveSmooth);
    path.get_Item(1).setPoints(new Point2D.Float[] { new Point2D.Float(0.1f, 0), new Point2D.Float(0.2f, 0.1f), new Point2D.Float(0.3f, 0.1f) });

    presentation.save("curve.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le chemin dans `curve.pptx` possède toujours trois commandes ; sa commande du milieu définit maintenant une courbe.

## **Inspecter et modifier un chemin enregistré**

Chaque [IMotionCmdPath](https://reference.aspose.com/slides/fr/java/com.aspose.slides/imotioncmdpath/) expose [getPoints](https://reference.aspose.com/slides/fr/java/com.aspose.slides/imotioncmdpath/#getPoints--), [getCommandType](https://reference.aspose.com/slides/fr/java/com.aspose.slides/imotioncmdpath/#getCommandType--), [getPointsType](https://reference.aspose.com/slides/fr/java/com.aspose.slides/imotioncmdpath/#getPointsType--), et [isRelative](https://reference.aspose.com/slides/fr/java/com.aspose.slides/imotioncmdpath/#isRelative--). Les exemples suivants utilisent le chemin à trois commandes connu dans `motion.pptx`. Pour une entrée arbitraire, localisez l’effet visé et vérifiez les types de commandes et le nombre de points avant de modifier par indice.

### **Lire les commandes et les coordonnées**

Lisez le chemin sans le modifier. Les commandes End et CloseLoop n’ont pas besoin de points, prévoyez donc un tableau de points nul.

La sortie associe chaque type de commande numérique à son indicateur de coordonnées relatives avant de lister ses points. Cela vous permet de distinguer un point final d’un décalage avant de modifier le chemin. Une courbe listerait trois points, alors que la ligne droite de ce fichier n’en liste qu’un.

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

Presentation presentation = new Presentation("motion.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    IMotionEffect motion = (IMotionEffect)effect.getBehaviors().get_Item(0);

    IMotionPath path = motion.getPath();
    for (IMotionCmdPath segment : path)
    {
        System.out.println(segment.getCommandType() + ", relative: " + segment.isRelative());
        if (segment.getPoints() != null)
            for (Point2D.Float point : segment.getPoints())
                System.out.println("X=" + point.x + ", Y=" + point.y);
    }
} finally {
    presentation.dispose();
}
```

Le listing contient un point de départ, une ligne absolue se terminant à (0,25, 0), et une commande End.

### **Modifier un point final**

Ouvrez `motion.pptx` et remplacez le tableau de points de la ligne afin de déplacer son point final.

Dans le fichier d’entrée, l’indice 0 désigne la commande de départ et l’indice 1 la ligne. Remplacer le point unique de la ligne change sa destination sans modifier son type de commande, sa synchronisation ou sa position dans la collection. Parce que la commande utilise des coordonnées absolues, la nouvelle paire spécifie une position plutôt qu’un décalage ajouté.

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

Presentation presentation = new Presentation("motion.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

    IMotionEffect motion = (IMotionEffect)effect.getBehaviors().get_Item(0);
    motion.getPath().get_Item(1).setPoints(new Point2D.Float[] { new Point2D.Float(0.4f, 0.1f) });

    presentation.save("motion-endpoint.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

La ligne dans `motion-endpoint.pptx` se termine à (0,4, 0,1) ; le fichier original reste inchangé.

### **Remplacer un segment**

Utilisez [insert](https://reference.aspose.com/slides/fr/java/com.aspose.slides/imotionpath/#insert-int-int-java.awt.geom.Point2D.Float---int-boolean-) et [removeAt](https://reference.aspose.com/slides/fr/java/com.aspose.slides/imotionpath/#removeAt-int-) pour remplacer la ligne dans `motion.pptx`. L’insertion décale l’ancienne ligne à l’indice 2.

Cela montre le remplacement d’un objet commande plutôt que la modification de ses coordonnées existantes. Après insertion, la collection contient temporairement la commande de départ, la nouvelle ligne, l’ancienne ligne et la commande End. Supprimer l’indice 2 élimine l’ancienne ligne et laisse le nouveau trajet en place.

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

Presentation presentation = new Presentation("motion.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    IMotionEffect motion = (IMotionEffect)effect.getBehaviors().get_Item(0);

    IMotionPath path = motion.getPath();
    path.insert(1, MotionCommandPathType.LineTo, new Point2D.Float[] { new Point2D.Float(0.2f, 0.1f) }, MotionPathPointsType.Corner, false);
    path.removeAt(2);

    presentation.save("motion-edited.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le chemin enregistré conserve toujours trois commandes, la nouvelle ligne se terminant à (0,2, 0,1) et la commande End à la fin.

## **Modifier et vérifier un comportement existant**

Lorsque l’indice du comportement est inconnu, sélectionnez‑le par type. Cet exemple ouvre `rotation.pptx`, trouve son [IRotationEffect](https://reference.aspose.com/slides/fr/java/com.aspose.slides/irotationeffect/), modifie l’angle et vérifie la valeur enregistrée après réouverture.

La vérification du type permet à la boucle de sauter les comportements qui ne sont pas des rotations. Le second chargement lit le fichier sauvegardé dans un objet présentation distinct, de sorte que la comparaison porte sur les données persistées plutôt que sur la valeur encore en mémoire. Cet exemple suppose toujours que l’effet connu est le premier de la séquence principale ; sélectionner un comportement par type ne localise pas forcément le bon effet dans une présentation arbitraire.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("rotation.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

    for (IBehavior behavior : effect.getBehaviors())
    {
        if (behavior instanceof IRotationEffect) {
            IRotationEffect rotation = (IRotationEffect) behavior;
            rotation.setBy(180f);
        }
    }

    presentation.save("rotation-edited.pptx", SaveFormat.Pptx);

    Presentation reopened = new Presentation("rotation-edited.pptx");
    try {
        IEffect savedEffect = reopened.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

        for (IBehavior behavior : savedEffect.getBehaviors())
        {
            if (behavior instanceof IRotationEffect) {
                IRotationEffect rotation = (IRotationEffect) behavior;
                System.out.println("Rotation preserved: " + (Math.abs(rotation.getBy() - 180f) < 0.001f));
            }
        }
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

La sortie est `Rotation preserved: true`. Appliquez le même modèle de vérification de type à d’autres comportements. Pour un contrôle complet de préservation, comparez la forme cible, l’effet, les types et l’ordre des comportements, la synchronisation et les commandes de chemin. Utilisez une tolérance numérique pour les valeurs en virgule flottante. Pour une présentation avec une disposition d’animation inconnue, voir [Read Shape Animations](/slides/fr/java/shape-animation/#read-shape-animations) pour le parcours des séquences principales et interactives.

## **Ordre des comportements, préréglages et lecture**

L’ordre dans [IBehaviorCollection](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ibehaviorcollection/) correspond à l’ordre stocké des opérations d’un effet. Ce n’est pas une liste de lecture où chaque comportement attend automatiquement le précédent. La synchronisation et l’effet englobant déterminent la planification. Les comportements peuvent se chevaucher, et les opérations sur la même propriété peuvent interagir via [getAdditive](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ibehavior/#getAdditive--) et [getAccumulate](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ibehavior/#getAccumulate--). Ne vous fiez pas uniquement au réordonnancement de la collection pour planifier « déplacer, puis tourner » ; utilisez la synchronisation explicite ou des effets séparés comme décrit dans [Animation de forme](/slides/fr/java/shape-animation/).

Le [getType](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ieffect/#getType--) et le [getSubtype](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ieffect/#getSubtype--) de l’effet décrivent son préréglage. Ils ne constituent pas une description complète d’un arbre de comportements édité. Choisissez le préréglage et le sous‑type avant de personnaliser les comportements : changer le préréglage peut reconstruire la collection et supprimer vos opérations personnalisées. Par exemple, transformer un effet Spin personnalisé en Fade peut remplacer son comportement de rotation par des comportements set et filter. Inspectez à nouveau la collection après modification d’un préréglage ou d’un sous‑type. Vider les comportements de préréglage peut également supprimer des opérations de visibilité ou d’initialisation dont le préréglage a besoin. Les exemples utilisent volontairement des formes visibles et remplacent les comportements ; ils ne reconstruisent pas chaque implémentation de préréglage.

## **Compatibilité des formats**

Un arbre de comportements préservé ne garantit pas une lecture identique dans chaque visionneur ou moteur d’exportation. Vérifiez séparément les données sauvegardées et le rendu final.

| Format ou sortie | Ce qu'il faut vérifier |
| --- | --- |
| PPTX | Utilisez ce format comme principal pour ces exemples. Rouvrez‑le pour vérifier l’arbre de comportements éditable, puis testez la lecture dans la version PowerPoint visée. |
| PPT | La représentation binaire héritée peut différer du PPTX. Testez un cycle sauvegarde‑reouverture séparé et la lecture ; ne déduisez pas la prise en charge de chaque combinaison personnalisée à partir d’un succès PPTX. |
| PDF, PNG, JPEG et autres images de diapositives statiques | Contiennent une représentation statique de la diapositive, pas de ligne de temps jouable ni d’image finale d’animation garantie. |
| [HTML5](/slides/fr/java/export-to-html5/) | Peut lire les animations prises en charge lorsque l’animation de forme est activée dans les options d’export. Testez les combinaisons personnalisées dans le navigateur. |
| [Animated GIF](/slides/fr/java/convert-powerpoint-to-animated-gif/) | Stocke les images rendues, pas les comportements éditables ni les interactions déclenchées par clic. Vérifiez le mouvement réellement rendu. |
| [Video](/slides/fr/java/convert-powerpoint-to-video/) | Render les cadres d’animation et les encode en vidéo. Le support est limité aux [animations et effets pris en charge](/slides/fr/java/convert-powerpoint-to-video/#supported-animations-and-effects) ; les commandes et événements interactifs ne deviennent pas une ligne de temps éditable. |

## **FAQ**

**Pourquoi mon effet contient‑il des comportements avant que j’en ajoute ?**

Créer un effet prédéfini peut créer ses opérations sous‑jacentes. Inspectez‑les avant de décider d’étendre le préréglage ou de remplacer ses comportements.

**Le fait de déplacer un comportement vers le début le fait‑il jouer en premier ?**

Pas nécessairement. L’ordre de la collection ne remplace pas la synchronisation. Vérifiez les délais, les durées et les interactions entre les opérations sur la même propriété.

**Pourquoi une commande End n’a‑t‑elle aucun point ?**

Elle marque la fin du chemin et n’a pas besoin de coordonnées. Vérifiez un tableau de points nul lors de l’inspection d’un chemin lu depuis un fichier.

**Un aller‑retour réussi suffit‑il à confirmer la lecture ?**

Non. La réouverture confirme la conservation des propriétés que vous avez vérifiées. Testez séparément le lecteur de diaporama ou l’export animé pour confirmer son comportement visuel.