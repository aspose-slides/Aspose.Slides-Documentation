---
title: Créer et modifier des comportements d'animation personnalisés sur Android
linktitle: Animation personnalisée
type: docs
weight: 151
url: /fr/androidjava/custom-animation/
keywords:
- animation personnalisée
- comportement d'animation
- chemin de mouvement
- PowerPoint
- présentation
- Android
- Java
- Aspose.Slides
description: "Créer, inspecter et modifier des comportements d'animation personnalisés et des chemins de mouvement éditables dans les présentations PowerPoint avec Aspose.Slides pour Android via Java."
---
## **Vue d'ensemble**

Les comportements d'animation personnalisés vous permettent de contrôler des opérations individuelles au sein d'un effet d'animation, comme changer une couleur, faire pivoter une forme ou suivre un chemin de mouvement modifiable. Ce guide montre comment créer et combiner des comportements, configurer leur minutage, inspecter et modifier des animations existantes, et vérifier que leurs propriétés survivent à l'enregistrement et à la réouverture d'une présentation.

Pour les effets prédéfinis et les déclencheurs de clic, voir [Shape Animation](/slides/fr/androidjava/shape-animation/).

## **Comprendre le modèle d'animation**

Une animation est organisée comme **Timeline → Sequence → Effect → Behaviors** :

- La méthode [getTimeline](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ibaseslide/#getTimeline--) renvoie la chronologie de la diapositive, qui contient sa séquence principale et ses séquences interactives.
- Un [ISequence](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/isequence/) contient des effets, pouvant cibler différentes formes.
- Un [IEffect](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ieffect/) identifie une forme cible, un préréglage, un sous‑type et le minutage de l'effet.
- La collection renvoyée par [IEffect.getBehaviors](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ieffect/#getBehaviors--) contient les opérations qui implémentent l'effet : changement de couleur, déplacement, rotation, définition d'une propriété, etc.

## **Créer des comportements individuels**

Appelez [ISequence.addEffect](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) pour créer un effet et accéder à la collection [getBehaviors](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ieffect/#getBehaviors--). Un préréglage peut peupler automatiquement cette collection. Conservez ses opérations lorsque vous étendez le préréglage, ou utilisez [clear](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ibehaviorcollection/#clear--) lorsque vous les remplacez délibérément.

[IBehaviorFactory](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ibehaviorfactory/) crée les huit types de comportements illustrés ci‑dessous. Le mouvement est couvert dans [Build a Motion Path](#build-a-motion-path). Chaque extrait inclut ses imports ; placez les instructions exécutables à l'intérieur d'une méthode. Les exemples d'édition ultérieurs indiquent quel fichier de sortie ils utilisent. Sur Android, remplacez les noms de fichiers d'exemple par des chemins complets dans un répertoire accessible par l'application, tel que le répertoire files de votre application.

### **Rotation**

Utilisez [createRotationEffect](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ibehaviorfactory/#createRotationEffect--) pour créer une rotation. [getBy](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/irotationeffect/#getBy--) spécifie un angle relatif en degrés ; [getFrom](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/irotationeffect/#getFrom--) et [getTo](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/irotationeffect/#getTo--) spécifient les points de départ et d'arrivée.

L'exemple commence avec un effet Spin, remplace ses opérations de préréglage par un comportement de rotation, et donne à cette opération une durée de deux secondes. Un angle relatif de 90 ° représente un quart de tour par rapport à l'orientation initiale de la forme, aucune angle de départ explicite n'est donc nécessaire.

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

`rotation.pptx` contient une forme et un comportement de rotation. La collection, le minutage et les exemples de modification de rotation ci‑dessous utilisent ce fichier.

### **Échelle**

Utilisez [createScaleEffect](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ibehaviorfactory/#createScaleEffect--) avec des pourcentages X/Y : [getFrom](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iscaleeffect/#getFrom--) et [getTo](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iscaleeffect/#getTo--) décrivent la taille de départ et d'arrivée, tandis que [getBy](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iscaleeffect/#getBy--) décrit une modification relative. Ici, 100 signifie la taille originale.

L'exemple augmente les deux dimensions de 100 % à 125 % en deux secondes. Utiliser des pourcentages horizontaux et verticaux égaux conserve les proportions de la forme ; des pourcentages différents étireraient une dimension davantage que l'autre.

```java
import com.aspose.slides.*;
import android.graphics.PointF;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

    IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.GrowShrink, EffectSubtype.None, EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    IBehaviorFactory factory = new BehaviorFactory();
    IScaleEffect scale = factory.createScaleEffect();
    scale.setFrom(new PointF(100, 100));
    scale.setTo(new PointF(125, 125));
    scale.getTiming().setDuration(2f);

    effect.getBehaviors().add(scale);

    presentation.save("scale.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Couleur**

Utilisez [createColorEffect](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ibehaviorfactory/#createColorEffect--) pour changer le remplissage du bleu à l'orange. [getFrom](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/icoloreffect/#getFrom--) et [getTo](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/icoloreffect/#getTo--) sont des couleurs ; [getBy](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/icoloreffect/#getBy--) est un décalage de couleur. [IBehavior.getProperties](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ibehavior/#getProperties--) identifie l'attribut animé.

Le remplissage plein de la forme est initialisé en bleu, correspondant à la couleur de départ de l'animation. Sélectionner l'attribut de couleur de remplissage indique au comportement quelle partie de la forme modifier ; les seules couleurs d'extrémité ne permettent pas d'identifier cet attribut. L'effet enregistré décrit une transition de deux secondes vers l'orange.

```java
import com.aspose.slides.*;
import android.graphics.Color;

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
    int orange = Color.rgb(255, 165, 0);
    color.getTo().setColor(orange);
    color.getTiming().setDuration(2f);

    effect.getBehaviors().add(color);

    presentation.save("color.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Filtre**

Utilisez [createFilterEffect](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ibehaviorfactory/#createFilterEffect--) pour choisir un essuyage. [getType](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ifiltereffect/#getType--), [getSubtype](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ifiltereffect/#getSubtype--), et [getReveal](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ifiltereffect/#getReveal--) spécifient le filtre, la direction et s'il faut révéler ou masquer la forme.

Cet exemple configure un essuyage de deux secondes qui révèle la forme en utilisant le sous‑type direction droite. Les paramètres du filtre appartiennent au comportement à l'intérieur de l'effet, ils sont donc configurés après la suppression des opérations originales du préréglage.

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

Utilisez [createPropertyEffect](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ibehaviorfactory/#createPropertyEffect--) pour animer l'opacité. [getFrom](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ipropertyeffect/#getFrom--), [getTo](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ipropertyeffect/#getTo--), et [getBy](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ipropertyeffect/#getBy--) sont des chaînes interprétées avec [getValueType](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ipropertyeffect/#getValueType--) et [getCalcMode](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ipropertyeffect/#getCalcMode--). Choisissez des points d'extrémité ou un décalage relatif au lieu de définir les trois simultanément.

Ici, l'attribut sélectionné est l'opacité, et les chaînes numériques représentent un passage de 25 % d'opacité à l'opacité totale. L'interpolation linéaire décrit un changement progressif entre ces valeurs. Lors de l'adaptation de cet exemple à une autre propriété, choisissez un type de valeur et des valeurs d'extrémité appropriés à cette propriété.

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

### **Set**

Utilisez [createSetEffect](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ibehaviorfactory/#createSetEffect--) pour assigner la visibilité via [getTo](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iseteffect/#getTo--). Un comportement de type *set* n'interpole pas entre les points d'extrémité.

L'exemple sélectionne l'attribut de visibilité et assigne la chaîne `visible` lorsque le comportement s'exécute. Le rectangle est déjà visible dans cette présentation minimale, de sorte que l'assignation peut ne pas produire de changement visuel évident à elle seule. Une telle opération est utile dans le cadre d'un effet plus large qui contrôle également le moment où la forme devient cachée ou visible.

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

Utilisez [createCommandEffect](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ibehaviorfactory/#createCommandEffect--) et configurez [getType](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/icommandeffect/#getType--), [getCommandString](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/icommandeffect/#getCommandString--), et [getShapeTarget](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/icommandeffect/#getShapeTarget--). Placez un enregistrement WAV nommé `sample.wav` dans le répertoire de travail. Cet exemple l'intègre avec [addAudioFrameEmbedded](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ishapecollection/#addAudioFrameEmbedded-float-float-float-float-java.io.InputStream-) et attache une commande de lecture au cadre audio.

Le cadre audio est à la fois la cible de l'effet et la cible de la commande. Cela relie la requête de lecture à l'enregistrement intégré ; une chaîne de commande seule ne spécifie pas quel objet multimédia contrôler. L'effet est configuré pour démarrer sur un clic pendant le diaporama.

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

L'enregistrement stocke la commande dans `command.pptx` ; il ne lit pas l'enregistrement. La lecture nécessite un lecteur de diaporama qui prend en charge la commande et sa cible multimédia.

## **Gérer la collection de comportements**

[IBehaviorCollection](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ibehaviorcollection/) prend en charge [add](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ibehaviorcollection/#add-com.aspose.slides.IBehavior-), [insert](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ibehaviorcollection/#insert-int-com.aspose.slides.IBehavior-), [remove](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ibehaviorcollection/#remove-com.aspose.slides.IBehavior-), et [removeAt](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ibehaviorcollection/#removeAt-int-). Cet exemple ouvre `rotation.pptx`, ajoute une mise à l'échelle, la déplace avant la rotation, puis supprime la rotation. Supprimer et réinsérer le même objet change sa position stockée sans créer de copie.

La séquence d'éditions transforme la collection de rotation‑scale à scale‑rotation, puis à scale uniquement. Les indices font référence à la collection courante, ainsi la suppression utilise le nouvel indice de la rotation après le réordonnancement. L'énumération finale confirme quel comportement sera enregistré.

```java
import com.aspose.slides.*;
import android.graphics.PointF;

Presentation presentation = new Presentation("rotation.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    IBehaviorCollection behaviors = effect.getBehaviors();

    IBehaviorFactory factory = new BehaviorFactory();
    IScaleEffect scale = factory.createScaleEffect();
    scale.setTo(new PointF(125, 125));
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

Le résultat est `ScaleEffect` : seule la mise à l'échelle reste. L'ordre de la collection ne programme pas, à lui seul, les comportements l'un après l'autre. Vide la collection uniquement lorsque vous remplacez toutes ses opérations.

## **Configurer le minutage des comportements**

[IBehavior.getTiming](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ibehavior/#getTiming--) expose [ITiming](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/itiming/), indépendamment de [IEffect.getTiming](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ieffect/#getTiming--). Le minutage de l'effet programme l'effet englobant ; le minutage du comportement décrit une opération à l'intérieur.

### **Définir durée, délai, répétition et accélération**

Ouvrez `rotation.pptx` et définissez la durée ([getDuration](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/itiming/#getDuration--)) ainsi que le délai de déclenchement ([getTriggerDelayTime](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/itiming/#getTriggerDelayTime--)) en secondes, puis configurez le nombre de répétitions via [setRepeatCount](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/itiming/#setRepeatCount-float-). [getAccelerate](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/itiming/#getAccelerate--) et [getDecelerate](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/itiming/#getDecelerate--) sont des fractions de la durée ; leur somme doit rester au plus à 1.

Le fichier d’entrée est celui créé dans l'exemple de rotation, où le premier comportement est connu comme une rotation. Cet exemple ne modifie que le minutage de ce comportement ; son angle de 90 ° reste intact. Séparer angle et minutage facilite l'ajustement du rythme sans reconstruire l'animation.

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

Le comportement utilise une durée de deux secondes, un délai de demi‑seconde et un nombre de répétitions de 3. Les 20 % initiaux et finaux de sa durée sont réservés à l'accélération et à la décélération.

D'autres politiques de répétition incluent [getRepeatDuration](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/itiming/#getRepeatDuration--), [getRepeatUntilEndSlide](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/itiming/#getRepeatUntilEndSlide--), et [getRepeatUntilNextClick](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/itiming/#getRepeatUntilNextClick--) ; choisissez une politique plutôt que de les activer toutes simultanément. [getAutoReverse](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/itiming/#getAutoReverse--) lit l'animation à l'envers après le passage avant. L'accélération et la décélération s'appliquent aux changements continus, pas aux affectations discrètes ou aux commandes.

## **Construire un chemin de mouvement**

Utilisez [createMotionEffect](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ibehaviorfactory/#createMotionEffect--) pour créer un mouvement. Ses [getFrom](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/imotioneffect/#getFrom--), [getTo](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/imotioneffect/#getTo--), et [getBy](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/imotioneffect/#getBy--) décrivent des coordonnées ou des décalages exprimés en pourcentage. Pour un tracé modifiable, créez un [MotionPath](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/motionpath/) et assignez‑le avec [IMotionEffect.setPath](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/imotioneffect/#setPath-com.aspose.slides.IMotionPath-). [IMotionPath](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/imotionpath/) stocke les commandes du chemin.

[MotionCommandPathType](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/motioncommandpathtype/) sélectionne l'opération :

| Commande | Points | Signification |
| --- | --- | --- |
| MoveTo | Un | Définit la position de départ. |
| LineTo | Un | Se déplace le long d'un segment droit jusqu'à son point d'arrivée. |
| CurveTo | Trois | Suit une courbe cubique définie par deux points de contrôle et un point d'arrivée. |
| CloseLoop | Aucun | Retourne à la position de départ. |
| End | Aucun | Termine le chemin. |

[MotionPathPointsType](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/motionpathpointstype/) décrit les caractéristiques d'édition des points, comme les points d'angle ou lisses. Cela ne remplace pas le type de commande. Utilisez un type de point de courbe pour l'exemple de courbe ci‑dessous, et un type de point d'angle pour les segments droits.

Les coordonnées du chemin sont normalisées aux dimensions de la diapositive : un déplacement X de 0,25 représente un quart de la largeur de la diapositive, pas 0,25 point. L'axe Y positif descend. Les commandes absolues spécifient des positions dans le système de coordonnées du chemin ; les commandes relatives spécifient des décalages depuis la position courante. Cela est distinct de [getOrigin](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/imotioneffect/#getOrigin--), qui sélectionne le cadre de référence du chemin, et de [getPathEditMode](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/imotioneffect/#getPathEditMode--), qui contrôle comment le chemin se déplace lorsque la forme est déplacée.

### **Créer un chemin droit**

Créez un comportement de mouvement avec un point de départ, un segment droit, et une commande de fin. [IMotionPath.add](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/imotionpath/#add-int-android.graphics.PointF---int-boolean-) prend le type de commande, ses points, le type de point et un indicateur de coordonnées relatives.

La commande de départ établit (0, 0), et la ligne se termine à (0,25, 0), donnant au trajet un déplacement horizontal d'un quart de la largeur de la diapositive. La commande de fin n’a aucun point de coordonnées. Une fois le chemin assigné, l’ajout du comportement de mouvement à l’effet relie ce trajet au rectangle.

```java
import com.aspose.slides.*;
import android.graphics.PointF;

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
    path.add(MotionCommandPathType.MoveTo, new PointF[] { new PointF(0, 0) }, MotionPathPointsType.Auto, false);
    path.add(MotionCommandPathType.LineTo, new PointF[] { new PointF(0.25f, 0) }, MotionPathPointsType.Corner, false);
    path.add(MotionCommandPathType.End, new PointF[0], MotionPathPointsType.None, false);

    motion.setPath(path);
    effect.getBehaviors().add(motion);

    presentation.save("motion.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`motion.pptx` contient un comportement de mouvement avec trois commandes de chemin. Les exemples suivants d’édition de fichier utilisent cette structure connue.

### **Comparer les coordonnées absolues et relatives**

Ces deux objets de chemin décrivent le même trajet. La commande absolue se termine à (0,3, 0,1) ; la commande relative ajoute (0,1, 0,1) à la position courante (0,2, 0).

Les deux chemins partent de la même position. Pour la ligne relative, ajoutez ses décalages X et Y à la position courante pour obtenir le point d'arrivée ; pour la ligne absolue, lisez directement le point d'arrivée. Basculer l’indicateur sans convertir les coordonnées décrirait un trajet différent.

```java
import com.aspose.slides.*;
import android.graphics.PointF;

MotionPath absolutePath = new MotionPath();
absolutePath.add(MotionCommandPathType.MoveTo, new PointF[] { new PointF(0.2f, 0) }, MotionPathPointsType.Auto, false);
absolutePath.add(MotionCommandPathType.LineTo, new PointF[] { new PointF(0.3f, 0.1f) }, MotionPathPointsType.Corner, false);

MotionPath relativePath = new MotionPath();
relativePath.add(MotionCommandPathType.MoveTo, new PointF[] { new PointF(0.2f, 0) }, MotionPathPointsType.Auto, false);
relativePath.add(MotionCommandPathType.LineTo, new PointF[] { new PointF(0.1f, 0.1f) }, MotionPathPointsType.Corner, true);
```

Attribuez l’un ou l’autre chemin à un comportement de mouvement pour l’utiliser dans une présentation. Le dernier argument booléen sélectionne les coordonnées relatives pour cette commande.

### **Remplacer une ligne par une courbe**

Ouvrez `motion.pptx` et remplacez sa commande de ligne par une courbe cubique. Fournissez d'abord les deux points de contrôle, suivis du point d'arrivée.

La position de départ est fournie par la commande précédente. Les deux premiers points façonnent la courbe, tandis que le troisième en constitue la destination ; il ne s'agit pas de trois destinations successives. Mettre à jour simultanément le type de commande, le type d’édition des points et le tableau de points maintient le segment cohérent avec sa nouvelle géométrie.

```java
import com.aspose.slides.*;
import android.graphics.PointF;

Presentation presentation = new Presentation("motion.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    IMotionEffect motion = (IMotionEffect)effect.getBehaviors().get_Item(0);

    IMotionPath path = motion.getPath();
    path.get_Item(1).setCommandType(MotionCommandPathType.CurveTo);
    path.get_Item(1).setPointsType(MotionPathPointsType.CurveSmooth);
    path.get_Item(1).setPoints(new PointF[] { new PointF(0.1f, 0), new PointF(0.2f, 0.1f), new PointF(0.3f, 0.1f) });

    presentation.save("curve.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le chemin dans `curve.pptx` possède toujours trois commandes ; sa commande du milieu définit désormais une courbe.

## **Inspecter et modifier un chemin enregistré**

Chaque [IMotionCmdPath](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/imotioncmdpath/) expose [getPoints](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/imotioncmdpath/#getPoints--), [getCommandType](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/imotioncmdpath/#getCommandType--), [getPointsType](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/imotioncmdpath/#getPointsType--), et [isRelative](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/imotioncmdpath/#isRelative--). Les exemples suivants utilisent le chemin à trois commandes connu dans `motion.pptx`. Pour une entrée quelconque, localisez l’effet voulu et vérifiez les types de commande et le nombre de points avant de les modifier par indice.

### **Lire les commandes et les coordonnées**

Lisez le chemin sans le modifier. Les commandes de fin et de fermeture de boucle n’ont pas besoin de points, prévoyez donc un tableau de points nul.

La sortie associe chaque type de commande numérique à son indicateur de coordonnées relatives avant d'énumérer ses points. Cela vous permet de distinguer un point d'arrivée d’un décalage avant de modifier le chemin. Une courbe listerait trois points, alors que la ligne droite dans ce fichier n’en liste qu’un.

```java
import com.aspose.slides.*;
import android.graphics.PointF;

Presentation presentation = new Presentation("motion.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    IMotionEffect motion = (IMotionEffect)effect.getBehaviors().get_Item(0);

    IMotionPath path = motion.getPath();
    for (IMotionCmdPath segment : path)
    {
        System.out.println(segment.getCommandType() + ", relative: " + segment.isRelative());
        if (segment.getPoints() != null)
            for (PointF point : segment.getPoints())
                System.out.println("X=" + point.x + ", Y=" + point.y);
    }
} finally {
    presentation.dispose();
}
```

Le listing contient un point de départ, une ligne absolue se terminant à (0,25, 0), et une commande de fin.

### **Modifier un point d'arrivée**

Ouvrez `motion.pptx` et remplacez le tableau de points de la ligne pour déplacer son point d'arrivée.

Dans le fichier d’entrée, l’indice 0 correspond à la commande de départ et l’indice 1 à la ligne. Remplacer le point unique de la ligne change sa destination sans modifier son type de commande, son minutage ou sa position dans la collection. Parce que la commande utilise des coordonnées absolues, la nouvelle paire spécifie une position plutôt qu’un décalage ajouté.

```java
import com.aspose.slides.*;
import android.graphics.PointF;

Presentation presentation = new Presentation("motion.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

    IMotionEffect motion = (IMotionEffect)effect.getBehaviors().get_Item(0);
    motion.getPath().get_Item(1).setPoints(new PointF[] { new PointF(0.4f, 0.1f) });

    presentation.save("motion-endpoint.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

La ligne dans `motion-endpoint.pptx` se termine à (0,4, 0,1) ; le fichier original reste inchangé.

### **Remplacer un segment**

Utilisez [insert](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/imotionpath/#insert-int-int-android.graphics.PointF---int-boolean-) et [removeAt](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/imotionpath/#removeAt-int-) pour remplacer la ligne dans `motion.pptx`. L’insertion décale l’ancienne ligne à l’indice 2.

Cela montre le remplacement d’un objet de commande plutôt que la modification de ses coordonnées existantes. Après insertion, la collection contient temporairement la commande de départ, la nouvelle ligne, l’ancienne ligne, puis la commande de fin. La suppression de l’indice 2 élimine l’ancienne ligne et laisse le nouveau trajet en place.

```java
import com.aspose.slides.*;
import android.graphics.PointF;

Presentation presentation = new Presentation("motion.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    IMotionEffect motion = (IMotionEffect)effect.getBehaviors().get_Item(0);

    IMotionPath path = motion.getPath();
    path.insert(1, MotionCommandPathType.LineTo, new PointF[] { new PointF(0.2f, 0.1f) }, MotionPathPointsType.Corner, false);
    path.removeAt(2);

    presentation.save("motion-edited.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le chemin enregistré possède toujours trois commandes, la nouvelle ligne se terminant à (0,2, 0,1) et la commande de fin en dernier.

## **Modifier et vérifier un comportement existant**

Lorsque l’indice du comportement est inconnu, sélectionnez‑le par type. Cet exemple ouvre `rotation.pptx`, trouve son [IRotationEffect](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/irotationeffect/), change l’angle, puis vérifie la valeur enregistrée après réouverture.

La vérification du type permet à la boucle d’ignorer les comportements qui ne sont pas des rotations. Le second chargement lit le fichier enregistré dans un objet présentation distinct, de sorte que la comparaison porte sur les données persistées plutôt que sur la valeur encore en mémoire. Cet exemple suppose toujours que l’effet connu est le premier de la séquence principale ; sélectionner un comportement par type ne localise pas forcément l’effet correct dans une présentation arbitraire.

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

La sortie est `Rotation preserved: true`. Appliquez le même schéma de vérification de type à d’autres comportements. Pour une vérification complète de la préservation, comparez la forme cible, l’effet, les types et l’ordre des comportements, le minutage et les commandes du chemin. Utilisez une tolérance numérique pour les valeurs à virgule flottante. Pour une présentation avec une structure d'animation inconnue, voir [Read Shape Animations](/slides/fr/androidjava/shape-animation/#read-shape-animations) pour parcourir les séquences principales et interactives.

## **Ordre des comportements, préréglages et lecture**

L’ordre dans [IBehaviorCollection](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ibehaviorcollection/) correspond à l’ordre stocké des opérations d’un effet. Ce n’est pas une liste de lecture où chaque comportement attend automatiquement celui qui le précède. Le minutage et l’effet englobant déterminent la planification. Les comportements peuvent se chevaucher, et les opérations sur la même propriété peuvent interagir via [getAdditive](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ibehavior/#getAdditive--) et [getAccumulate](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ibehavior/#getAccumulate--). N’utilisez pas uniquement le réordonnancement de la collection pour planifier « déplacer, puis pivoter » ; utilisez un minutage explicite ou des effets séparés comme décrit dans [Shape Animation](/slides/fr/androidjava/shape-animation/).

Le [getType](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ieffect/#getType--) et le [getSubtype](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ieffect/#getSubtype--) de l’effet décrivent son préréglage. Ils ne constituent pas une description complète d’un arbre de comportements édité. Choisissez le préréglage et le sous‑type avant de personnaliser les comportements : changer le préréglage peut reconstruire la collection et supprimer vos opérations personnalisées. Par exemple, changer un effet Spin personnalisé en Fade peut remplacer son comportement de rotation par des comportements set et filter. Inspectez de nouveau la collection après avoir changé un préréglage ou un sous‑type. Vider les comportements du préréglage peut également supprimer des opérations de visibilité ou d’initialisation dont le préréglage a besoin. Les exemples utilisent volontairement des formes visibles et remplacent les comportements ; ils ne reconstruisent pas l’implémentation complète de chaque préréglage.

## **Compatibilité des formats**

Un arbre de comportements préservé ne garantit pas une lecture identique dans chaque visionneur ou moteur d’exportation. Vérifiez séparément les données enregistrées et le rendu produit.

| Format ou sortie | Ce qu'il faut vérifier |
| --- | --- |
| PPTX | Utilisez ce format comme principal pour ces exemples. Réouvrez‑le pour vérifier l’arbre de comportements éditable, puis testez la lecture dans la version PowerPoint visée. |
| PPT | La représentation binaire héritée peut différer du PPTX. Testez un cycle d’enregistrement‑réouverture séparé ainsi que la lecture ; ne déduisez pas la prise en charge de chaque combinaison personnalisée à partir d’un résultat PPTX réussi. |
| PDF, PNG, JPEG et autres images de diapositive statiques | Contiennent une représentation statique de la diapositive, pas de chronologie de comportements jouable ni de cadre d’animation final garanti. |
| [HTML5](/slides/fr/androidjava/export-to-html5/) | Peut lire les animations prises en charge lorsque l’animation de forme est activée dans les options d’exportation. Testez les combinaisons personnalisées dans le navigateur. |
| [Animated GIF](/slides/fr/androidjava/convert-powerpoint-to-animated-gif/) | Stocke les images rendues, pas les comportements éditables ou les interactions déclenchées par clic. Vérifiez le mouvement réellement rendu. |
| [Video](/slides/fr/androidjava/convert-powerpoint-to-video/) | Rend les images d’animation et les encode en vidéo. La prise en charge est limitée aux [animations et effets pris en charge](/slides/fr/androidjava/convert-powerpoint-to-video/#supported-animations-and-effects) du moteur de rendu ; les commandes et les événements interactifs ne deviennent pas une chronologie éditable. |

## **FAQ**

**Pourquoi mon effet contient‑il des comportements avant que j’en ajoute ?**

La création d’un effet prédéfini peut générer ses opérations sous‑jacentes. Inspectez‑les avant de décider d’étendre le préréglage ou de remplacer ses comportements.

**Déplacer un comportement au début le fait‑il jouer en premier ?**

Pas nécessairement. L’ordre de la collection ne remplace pas le minutage. Vérifiez les délais, les durées et les interactions entre les opérations sur la même propriété.

**Pourquoi une commande de fin n’a‑t‑elle pas de points ?**

Elle marque la fin du chemin et n’a pas besoin de coordonnées. Vérifiez la présence d’un tableau de points nul lors de l’inspection d’un chemin lu depuis un fichier.

**Un aller‑retour réussi suffit‑il à confirmer la lecture ?**

Non. Réouvrir confirme la préservation des propriétés que vous avez vérifiées. Testez séparément le lecteur de diaporama ou l’export animé pour confirmer le comportement visuel.