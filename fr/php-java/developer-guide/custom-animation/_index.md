---
title: Créer et modifier des comportements d'animation personnalisés en PHP
linktitle: Animation personnalisée
type: docs
weight: 151
url: /fr/php-java/custom-animation/
keywords:
- animation personnalisée
- comportement d'animation
- chemin de mouvement
- PowerPoint
- présentation
- PHP
- Aspose.Slides
description: "Créer, inspecter et modifier des comportements d'animation personnalisés et des chemins de mouvement éditables dans les présentations PowerPoint avec Aspose.Slides pour PHP via Java."
---
## **Aperçu**

Les comportements d'animation personnalisés vous permettent de contrôler des opérations individuelles au sein d'un effet d'animation, comme changer une couleur, faire pivoter une forme ou suivre un chemin de mouvement éditable. Ce guide montre comment créer et combiner des comportements, configurer leur chronologie, inspecter et modifier les animations existantes, et vérifier que leurs propriétés survivent à l'enregistrement et à la réouverture d'une présentation.

Pour les effets prédéfinis et les déclencheurs de clic, voir [Animation de forme](/slides/fr/php-java/shape-animation/).

## **Comprendre le modèle d'animation**

Une animation est organisée comme **Timeline → Sequence → Effect → Behaviors** :

- Chaque diapositive possède une timeline contenant sa séquence principale et les séquences interactives.
- Une [Sequence](https://reference.aspose.com/slides/fr/php-java/aspose.slides/sequence/) contient des effets, pouvant cibler différentes formes.
- Un [Effect](https://reference.aspose.com/slides/fr/php-java/aspose.slides/effect/) identifie une forme cible, un préréglage, un sous‑type et la chronologie de l'effet.
- La collection retournée par [Effect::getBehaviors](https://reference.aspose.com/slides/fr/php-java/aspose.slides/effect/getbehaviors/) contient les opérations qui implémentent l'effet : changement de couleur, déplacement, rotation, définition d'une propriété, etc.

## **Créer des comportements individuels**

Appelez [Sequence::addEffect](https://reference.aspose.com/slides/fr/php-java/aspose.slides/sequence/addeffect/) pour créer un effet et accéder à la collection [getBehaviors](https://reference.aspose.com/slides/fr/php-java/aspose.slides/effect/getbehaviors/). Un préréglage peut remplir automatiquement cette collection. Conservez ses opérations lors de l'extension du préréglage, ou utilisez [clear](https://reference.aspose.com/slides/fr/php-java/aspose.slides/behaviorcollection/clear/) lorsque vous remplacez délibérément les opérations.

[BehaviorFactory](https://reference.aspose.com/slides/fr/php-java/aspose.slides/behaviorfactory/) crée les huit types de comportements illustrés ci‑dessous. Le mouvement est traité dans [Créer un chemin de mouvement](#create-a-motion-path). Chaque extrait inclut ses importations et suppose que le pont PHP/Java ainsi que la bibliothèque Aspose.Slides PHP ont été chargés. Les exemples d'édition ultérieurs indiquent le fichier de sortie qu'ils utilisent.

### **Rotation**

Utilisez [createRotationEffect](https://reference.aspose.com/slides/fr/php-java/aspose.slides/behaviorfactory/createrotationeffect/) pour créer une rotation. [getBy](https://reference.aspose.com/slides/fr/php-java/aspose.slides/rotationeffect/getby/) spécifie un angle relatif en degrés ; [getFrom](https://reference.aspose.com/slides/fr/php-java/aspose.slides/rotationeffect/getfrom/) et [getTo](https://reference.aspose.com/slides/fr/php-java/aspose.slides/rotationeffect/getto/) spécifient les points de départ et d'arrivée.

L'exemple commence avec un effet Spin, remplace ses opérations de préréglage par un seul comportement de rotation, et donne à cette opération une durée de deux secondes. Un angle relatif de 90 ° représente un quart de tour à partir de l'orientation initiale de la forme, donc aucun angle de départ explicite n'est nécessaire.

```php
use aspose\slides\BehaviorFactory;
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$baseDirectory = getcwd();

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

    $effect = $slide->getTimeline()->getMainSequence()->addEffect($shape, EffectType::Spin, EffectSubtype::None, EffectTriggerType::OnClick);
    $effect->getBehaviors()->clear();

    $factory = new BehaviorFactory();
    $rotation = $factory->createRotationEffect();
    $rotation->setBy(90);
    $rotation->getTiming()->setDuration(2);

    $effect->getBehaviors()->add($rotation);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "rotation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

`rotation.pptx` contient une forme et un comportement de rotation. La collection, la chronologie et les exemples d'édition de rotation ci‑dessous utilisent ce fichier.

### **Échelle**

Utilisez [createScaleEffect](https://reference.aspose.com/slides/fr/php-java/aspose.slides/behaviorfactory/createscaleeffect/) avec des pourcentages X/Y : [getFrom](https://reference.aspose.com/slides/fr/php-java/aspose.slides/scaleeffect/getfrom/) et [getTo](https://reference.aspose.com/slides/fr/php-java/aspose.slides/scaleeffect/getto/) décrivent la taille de départ et d'arrivée, tandis que [getBy](https://reference.aspose.com/slides/fr/php-java/aspose.slides/scaleeffect/getby/) décrit une variation relative. Ici, 100 représente la taille d'origine.

L'exemple agrandit les deux dimensions de 100 % à 125 % en deux secondes. Utiliser des pourcentages horizontaux et verticaux égaux conserve les proportions de la forme ; des pourcentages différents étireraient davantage une dimension.

```php
use aspose\slides\BehaviorFactory;
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$baseDirectory = getcwd();

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

    $effect = $slide->getTimeline()->getMainSequence()->addEffect($shape, EffectType::GrowShrink, EffectSubtype::None, EffectTriggerType::OnClick);
    $effect->getBehaviors()->clear();

    $factory = new BehaviorFactory();
    $scale = $factory->createScaleEffect();
    $initialSize = new Point2DFloat(100, 100);
    $scale->setFrom($initialSize);
    $targetSize = new Point2DFloat(125, 125);
    $scale->setTo($targetSize);
    $scale->getTiming()->setDuration(2);

    $effect->getBehaviors()->add($scale);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "scale.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Couleur**

Utilisez [createColorEffect](https://reference.aspose.com/slides/fr/php-java/aspose.slides/behaviorfactory/createcoloreffect/) pour changer le remplissage du bleu à l'orange. [getFrom](https://reference.aspose.com/slides/fr/php-java/aspose.slides/coloreffect/getfrom/) et [getTo](https://reference.aspose.com/slides/fr/php-java/aspose.slides/coloreffect/getto/) sont des couleurs ; [getBy](https://reference.aspose.com/slides/fr/php-java/aspose.slides/coloreffect/getby/) est un décalage de couleur. La [BehaviorPropertyCollection](https://reference.aspose.com/slides/fr/php-java/aspose.slides/behaviorpropertycollection/) du comportement identifie l'attribut animé.

Le remplissage plein de la forme est initialisé en bleu, correspondant à la couleur de départ de l'animation. Sélectionner l'attribut de couleur de remplissage indique au comportement quelle partie de la forme modifier ; les points de couleur seuls n'identifient pas cet attribut. L'effet enregistré décrit une transition de deux secondes vers l'orange.

```php
use aspose\slides\BehaviorFactory;
use aspose\slides\BehaviorProperty;
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$baseDirectory = getcwd();

$blue = new Java("java.awt.Color", 0, 0, 255);

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setColor($blue);

    $effect = $slide->getTimeline()->getMainSequence()->addEffect($shape, EffectType::ChangeFillColor, EffectSubtype::None, EffectTriggerType::OnClick);
    $effect->getBehaviors()->clear();

    $factory = new BehaviorFactory();
    $color = $factory->createColorEffect();
    $color->getProperties()->add(BehaviorProperty::getFillColor()->getValue());
    $color->getFrom()->setColor($blue);
    $orange = new Java("java.awt.Color", 255, 165, 0);
    $color->getTo()->setColor($orange);
    $color->getTiming()->setDuration(2);

    $effect->getBehaviors()->add($color);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "color.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Filtre**

Utilisez [createFilterEffect](https://reference.aspose.com/slides/fr/php-java/aspose.slides/behaviorfactory/createfiltereffect/) pour choisir un balayage. [getType](https://reference.aspose.com/slides/fr/php-java/aspose.slides/filtereffect/gettype/), [getSubtype](https://reference.aspose.com/slides/fr/php-java/aspose.slides/filtereffect/getsubtype/) et [getReveal](https://reference.aspose.com/slides/fr/php-java/aspose.slides/filtereffect/getreveal/) spécifient le filtre, la direction et s'il faut révéler ou masquer la forme.

Cet exemple configure un balayage de deux secondes qui révèle la forme en utilisant le sous‑type de direction droite. Les paramètres du filtre appartiennent au comportement à l'intérieur de l'effet, ils sont donc configurés après que les opérations d'origine du préréglage aient été supprimées.

```php
use aspose\slides\BehaviorFactory;
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\FilterEffectRevealType;
use aspose\slides\FilterEffectSubtype;
use aspose\slides\FilterEffectType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$baseDirectory = getcwd();

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

    $effect = $slide->getTimeline()->getMainSequence()->addEffect($shape, EffectType::Wipe, EffectSubtype::None, EffectTriggerType::OnClick);
    $effect->getBehaviors()->clear();

    $factory = new BehaviorFactory();
    $filter = $factory->createFilterEffect();
    $filter->setType(FilterEffectType::Wipe);
    $filter->setSubtype(FilterEffectSubtype::Right);
    $filter->setReveal(FilterEffectRevealType::In);
    $filter->getTiming()->setDuration(2);

    $effect->getBehaviors()->add($filter);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "filter.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Propriété**

Utilisez [createPropertyEffect](https://reference.aspose.com/slides/fr/php-java/aspose.slides/behaviorfactory/createpropertyeffect/) pour animer l'opacité. [getFrom](https://reference.aspose.com/slides/fr/php-java/aspose.slides/propertyeffect/getfrom/), [getTo](https://reference.aspose.com/slides/fr/php-java/aspose.slides/propertyeffect/getto/) et [getBy](https://reference.aspose.com/slides/fr/php-java/aspose.slides/propertyeffect/getby/) sont des chaînes interprétées à l'aide de [getValueType](https://reference.aspose.com/slides/fr/php-java/aspose.slides/propertyeffect/getvaluetype/) et [getCalcMode](https://reference.aspose.com/slides/fr/php-java/aspose.slides/propertyeffect/getcalcmode/). Choisissez les points de départ ou un décalage relatif plutôt que de définir les trois simultanément.

Ici, l'attribut sélectionné est l'opacité, et les chaînes numériques représentent une variation de 25 % d'opacité à pleine opacité. L'interpolation linéaire décrit une variation progressive entre ces valeurs. En adaptant cet exemple à un autre attribut, choisissez un type de valeur et des valeurs d'extrémité appropriés à cet attribut.

```php
use aspose\slides\BehaviorFactory;
use aspose\slides\BehaviorProperty;
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\Presentation;
use aspose\slides\PropertyCalcModeType;
use aspose\slides\PropertyValueType;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$baseDirectory = getcwd();

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

    $effect = $slide->getTimeline()->getMainSequence()->addEffect($shape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);
    $effect->getBehaviors()->clear();

    $factory = new BehaviorFactory();
    $property = $factory->createPropertyEffect();
    $property->getProperties()->add(BehaviorProperty::getStyleOpacity()->getValue());
    $property->setValueType(PropertyValueType::Number);
    $property->setCalcMode(PropertyCalcModeType::Linear);
    $property->setFrom("0.25");
    $property->setTo("1");
    $property->getTiming()->setDuration(2);

    $effect->getBehaviors()->add($property);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "property.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Définir**

Utilisez [createSetEffect](https://reference.aspose.com/slides/fr/php-java/aspose.slides/behaviorfactory/createseteffect/) pour affecter la visibilité via [getTo](https://reference.aspose.com/slides/fr/php-java/aspose.slides/seteffect/getto/). Un comportement de type « set » n'interpole pas entre les points d'extrémité.

L'exemple sélectionne l'attribut de visibilité et assigne la chaîne `visible` lorsque le comportement s'exécute. Le rectangle est déjà visible dans cette présentation minimale, donc l'assignation peut ne pas produire de changement visuel évident à elle seule. Une telle opération est utile dans le cadre d'un effet plus large qui contrôle également le moment où la forme devient cachée ou visible.

```php
use aspose\slides\BehaviorFactory;
use aspose\slides\BehaviorProperty;
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$baseDirectory = getcwd();

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

    $effect = $slide->getTimeline()->getMainSequence()->addEffect($shape, EffectType::Appear, EffectSubtype::None, EffectTriggerType::OnClick);
    $effect->getBehaviors()->clear();

    $factory = new BehaviorFactory();
    $set = $factory->createSetEffect();
    $set->getProperties()->add(BehaviorProperty::getStyleVisibility()->getValue());
    $set->setTo("visible");

    $effect->getBehaviors()->add($set);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "set.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Commande**

Utilisez [createCommandEffect](https://reference.aspose.com/slides/fr/php-java/aspose.slides/behaviorfactory/createcommandeffect/) et configurez [getType](https://reference.aspose.com/slides/fr/php-java/aspose.slides/commandeffect/gettype/), [getCommandString](https://reference.aspose.com/slides/fr/php-java/aspose.slides/commandeffect/getcommandstring/) et [getShapeTarget](https://reference.aspose.com/slides/fr/php-java/aspose.slides/commandeffect/getshapetarget/). Placez un enregistrement WAV nommé `sample.wav` dans le répertoire de travail. Cet exemple l'intègre avec [addAudioFrameEmbedded](https://reference.aspose.com/slides/fr/php-java/aspose.slides/shapecollection/addaudioframeembedded/) et y attache une commande de lecture.

Le cadre audio est à la fois la cible de l'effet et la cible de la commande. Cela relie la demande de lecture à l'enregistrement intégré ; une chaîne de commande seule n'identifie pas quel objet multimédia contrôler. L'effet est configuré pour démarrer au clic pendant le diaporama.

```php
use aspose\slides\BehaviorFactory;
use aspose\slides\CommandEffectType;
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$baseDirectory = getcwd();

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $audioPath = $baseDirectory . DIRECTORY_SEPARATOR . "sample.wav";
    $audioStream = new Java("java.io.FileInputStream", $audioPath);
    try {
        $audioFrame = $slide->getShapes()->addAudioFrameEmbedded(100, 100, 40, 40, $audioStream);

        $effect = $slide->getTimeline()->getMainSequence()->addEffect($audioFrame, EffectType::MediaPlay, EffectSubtype::None, EffectTriggerType::OnClick);
        $effect->getBehaviors()->clear();

        $factory = new BehaviorFactory();
        $command = $factory->createCommandEffect();
        $command->setType(CommandEffectType::Call);
        $command->setCommandString("play");
        $command->setShapeTarget($audioFrame);

        $effect->getBehaviors()->add($command);

        $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "command.pptx", SaveFormat::Pptx);
    } finally {
        $audioStream->close();
    }
} finally {
    $presentation->dispose();
}
```

L'enregistrement stocke la commande dans `command.pptx` ; il ne lit pas l'enregistrement. La lecture nécessite un lecteur de diaporama qui prend en charge la commande et sa cible multimédia.

## **Gérer la collection de comportements**

[BehaviorCollection](https://reference.aspose.com/slides/fr/php-java/aspose.slides/behaviorcollection/) prend en charge [add](https://reference.aspose.com/slides/fr/php-java/aspose.slides/behaviorcollection/add/), [insert](https://reference.aspose.com/slides/fr/php-java/aspose.slides/behaviorcollection/insert/), [remove](https://reference.aspose.com/slides/fr/php-java/aspose.slides/behaviorcollection/remove/) et [removeAt](https://reference.aspose.com/slides/fr/php-java/aspose.slides/behaviorcollection/removeat/). Cet exemple ouvre `rotation.pptx`, ajoute une mise à l'échelle, la déplace avant la rotation, puis supprime la rotation. Supprimer et réinsérer le même objet change sa position stockée sans en créer une copie.

La séquence d'éditions transforme la collection de rotation–scale en scale–rotation, puis en scale uniquement. Les indices font référence à la collection actuelle, de sorte que la suppression utilise le nouvel indice de la rotation après le réordonnancement. L'énumération finale confirme quel comportement sera enregistré.

```php
use aspose\slides\BehaviorFactory;
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$baseDirectory = getcwd();

$presentation = new Presentation($baseDirectory . DIRECTORY_SEPARATOR . "rotation.pptx");
try {
    $effect = $presentation->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->get_Item(0);
    $behaviors = $effect->getBehaviors();

    $factory = new BehaviorFactory();
    $scale = $factory->createScaleEffect();
    $targetSize = new Point2DFloat(125, 125);
    $scale->setTo($targetSize);
    $scale->getTiming()->setDuration(2);

    $behaviors->add($scale);

    $behaviors->remove($scale);
    $behaviors->insert(0, $scale);
    $behaviors->removeAt(1);

    $behaviorCount = java_values($behaviors->getCount());
    for ($i = 0; $i < $behaviorCount; $i++) {
        $behavior = $behaviors->get_Item($i);
        echo java_values($behavior->getClass()->getSimpleName()) . PHP_EOL;
    }

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "collection-edited.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

La sortie est `ScaleEffect` : seule la mise à l'échelle demeure. L'ordre de la collection, à lui seul, ne programme pas les comportements les uns après les autres. Videz la collection uniquement lorsque vous remplacez toutes ses opérations.

## **Configurer la chronologie d'un comportement**

Un comportement possède sa propre [Timing](https://reference.aspose.com/slides/fr/php-java/aspose.slides/timing/), indépendante de la chronologie renvoyée par [Effect::getTiming](https://reference.aspose.com/slides/fr/php-java/aspose.slides/effect/gettiming/). La chronologie de l'effet programme l'effet englobant ; la chronologie du comportement décrit une opération à l'intérieur.

### **Définir la durée, le délai, la répétition et l'accélération**

Ouvrez `rotation.pptx` et définissez la durée ([getDuration](https://reference.aspose.com/slides/fr/php-java/aspose.slides/timing/getduration/)) et le délai de déclenchement ([getTriggerDelayTime](https://reference.aspose.com/slides/fr/php-java/aspose.slides/timing/gettriggerdelaytime/)) en secondes, puis configurez le nombre de répétitions via [setRepeatCount](https://reference.aspose.com/slides/fr/php-java/aspose.slides/timing/setrepeatcount/). [getAccelerate](https://reference.aspose.com/slides/fr/php-java/aspose.slides/timing/getaccelerate/) et [getDecelerate](https://reference.aspose.com/slides/fr/php-java/aspose.slides/timing/getdecelerate/) sont des fractions de la durée ; gardez leur somme au plus égale à 1.

Le fichier d'entrée est celui créé dans l'exemple de rotation, où l'on sait que le premier comportement est une rotation. Cet exemple ne modifie que la chronologie de ce comportement ; son angle de 90 ° reste intact. Garder l'angle et la chronologie séparés facilite l'ajustement du tempo sans reconstruire l'animation.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$baseDirectory = getcwd();

$presentation = new Presentation($baseDirectory . DIRECTORY_SEPARATOR . "rotation.pptx");
try {
    $effect = $presentation->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->get_Item(0);

    $rotation = $effect->getBehaviors()->get_Item(0);
    $rotation->getTiming()->setDuration(2);
    $rotation->getTiming()->setTriggerDelayTime(0.5);
    $rotation->getTiming()->setRepeatCount(3);
    $rotation->getTiming()->setAccelerate(0.2);
    $rotation->getTiming()->setDecelerate(0.2);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "timing.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Le comportement utilise une durée de deux secondes, un délai de 0,5 seconde et un nombre de répétitions de 3. Les 20 % initiaux et finaux de sa durée sont utilisés pour l'accélération et la décélération.

D'autres politiques de répétition incluent [getRepeatDuration](https://reference.aspose.com/slides/fr/php-java/aspose.slides/timing/getrepeatduration/), [getRepeatUntilEndSlide](https://reference.aspose.com/slides/fr/php-java/aspose.slides/timing/getrepeatuntilendslide/) et [getRepeatUntilNextClick](https://reference.aspose.com/slides/fr/php-java/aspose.slides/timing/getrepeatuntilnextclick/); choisissez une politique plutôt que de les activer toutes simultanément. [getAutoReverse](https://reference.aspose.com/slides/fr/php-java/aspose.slides/timing/getautoreverse/) lit l'animation à l'envers après le passage avant. L'accélération et la décélération s'appliquent aux changements continus, pas aux affectations discrètes ou aux commandes.

## **Créer un chemin de mouvement**

Utilisez [createMotionEffect](https://reference.aspose.com/slides/fr/php-java/aspose.slides/behaviorfactory/createmotioneffect/) pour créer un mouvement. Ses [getFrom](https://reference.aspose.com/slides/fr/php-java/aspose.slides/motioneffect/getfrom/), [getTo](https://reference.aspose.com/slides/fr/php-java/aspose.slides/motioneffect/getto/) et [getBy](https://reference.aspose.com/slides/fr/php-java/aspose.slides/motioneffect/getby/) décrivent des coordonnées ou des décalages basés sur des pourcentages. Pour un itinéraire éditable, créez un [MotionPath](https://reference.aspose.com/slides/fr/php-java/aspose.slides/motionpath/) et assignez‑le avec [MotionEffect::setPath](https://reference.aspose.com/slides/fr/php-java/aspose.slides/motioneffect/setpath/). [MotionPath](https://reference.aspose.com/slides/fr/php-java/aspose.slides/motionpath/) stocke les commandes du chemin.

[MotionCommandPathType](https://reference.aspose.com/slides/fr/php-java/aspose.slides/motioncommandpathtype/) sélectionne l'opération :

| Command | Points | Signification |
| --- | --- | --- |
| MoveTo | One | Définir la position de départ. |
| LineTo | One | Se déplacer le long d'un segment droit jusqu'à son point final. |
| CurveTo | Three | Suivre une courbe cubique définie par deux points de contrôle et un point final. |
| CloseLoop | None | Retourner à la position de départ. |
| End | None | Terminer le chemin. |

[MotionPathPointsType](https://reference.aspose.com/slides/fr/php-java/aspose.slides/motionpathpointstype/) décrit les caractéristiques d'édition des points, comme les coins ou les points lisses. Il ne remplace pas le type de commande. Utilisez un type de point de courbe pour l'exemple de courbe ci‑dessous, et un type de point d'angle pour les segments droits.

Les coordonnées du chemin sont normalisées par rapport aux dimensions de la diapositive : un déplacement X de 0,25 représente un quart de la largeur de la diapositive, pas 0,25 point. L'axe Y positif descend. Les commandes absolues spécifient des positions dans le système de coordonnées du chemin ; les commandes relatives spécifient des décalages par rapport à la position actuelle. Cela est distinct de [getOrigin](https://reference.aspose.com/slides/fr/php-java/aspose.slides/motioneffect/getorigin/), qui sélectionne le cadre de référence du chemin, et de [getPathEditMode](https://reference.aspose.com/slides/fr/php-java/aspose.slides/motioneffect/getpatheditmode/), qui contrôle comment le chemin se déplace lorsque la forme est déplacée.

### **Créer un chemin droit**

Créez un comportement de mouvement avec un point de départ, un segment droit et une commande de fin. [MotionPath::add](https://reference.aspose.com/slides/fr/php-java/aspose.slides/motionpath/add/) prend le type de commande, ses points, le type de point et un indicateur de coordonnées relatives.

La commande de départ établit (0, 0), et la ligne se termine à (0.25, 0), donnant au trajet un déplacement horizontal d'un quart de la largeur de la diapositive. La commande de fin n'a aucun point de coordonnées. Une fois le chemin assigné, l'ajout du comportement de mouvement à l'effet relie ce trajet au rectangle.

```php
use aspose\slides\BehaviorFactory;
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\MotionCommandPathType;
use aspose\slides\MotionOriginType;
use aspose\slides\MotionPath;
use aspose\slides\MotionPathPointsType;
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$baseDirectory = getcwd();

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

    $effect = $slide->getTimeline()->getMainSequence()->addEffect($shape, EffectType::PathRight, EffectSubtype::None, EffectTriggerType::OnClick);
    $effect->getBehaviors()->clear();

    $factory = new BehaviorFactory();
    $motion = $factory->createMotionEffect();
    $motion->setOrigin(MotionOriginType::Layout);
    $motion->getTiming()->setDuration(2);

    $path = new MotionPath();
    $startPoints = [new Point2DFloat(0, 0)];
    $path->add(MotionCommandPathType::MoveTo, $startPoints, MotionPathPointsType::Auto, false);
    $endPoints = [new Point2DFloat(0.25, 0)];
    $path->add(MotionCommandPathType::LineTo, $endPoints, MotionPathPointsType::Corner, false);
    $path->add(MotionCommandPathType::End, [], MotionPathPointsType::None, false);

    $motion->setPath($path);
    $effect->getBehaviors()->add($motion);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "motion.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

`motion.pptx` contient un comportement de mouvement avec trois commandes de chemin. Les exemples d'édition de fichier suivants utilisent cette structure connue.

### **Comparer les coordonnées absolues et relatives**

Ces deux objets de chemin décrivent le même itinéraire. La commande absolue se termine à (0.3, 0.1) ; la commande relative ajoute (0.1, 0.1) à la position actuelle, soit (0.2, 0).

Les deux chemins commencent à la même position. Pour la ligne relative, ajoutez ses décalages X et Y à la position actuelle afin d'obtenir le point final ; pour la ligne absolue, lisez directement le point final. Basculer l'indicateur sans convertir les coordonnées décrirait un itinéraire différent.

```php
use aspose\slides\MotionCommandPathType;
use aspose\slides\MotionPath;
use aspose\slides\MotionPathPointsType;
use aspose\slides\Point2DFloat;

$absolutePath = new MotionPath();
$absoluteStart = [new Point2DFloat(0.2, 0)];
$absolutePath->add(MotionCommandPathType::MoveTo, $absoluteStart, MotionPathPointsType::Auto, false);
$absoluteEnd = [new Point2DFloat(0.3, 0.1)];
$absolutePath->add(MotionCommandPathType::LineTo, $absoluteEnd, MotionPathPointsType::Corner, false);

$relativePath = new MotionPath();
$relativeStart = [new Point2DFloat(0.2, 0)];
$relativePath->add(MotionCommandPathType::MoveTo, $relativeStart, MotionPathPointsType::Auto, false);
$relativeOffset = [new Point2DFloat(0.1, 0.1)];
$relativePath->add(MotionCommandPathType::LineTo, $relativeOffset, MotionPathPointsType::Corner, true);
```

Assignez l'un ou l'autre chemin à un comportement de mouvement pour l'utiliser dans une présentation. Le dernier argument booléen sélectionne les coordonnées relatives pour cette commande.

### **Remplacer une ligne par une courbe**

Ouvrez `motion.pptx` et remplacez sa commande de ligne par une courbe cubique. Fournissez d'abord les deux points de contrôle, puis le point final.

La position de départ est fournie par la commande précédente. Les deux premiers points façonnent la courbe, tandis que le troisième en est la destination ; ils ne sont pas trois destinations successives. Mettre à jour simultanément le type de commande, le type d'édition du point et le tableau de points maintient le segment cohérent avec sa nouvelle géométrie.

```php
use aspose\slides\MotionCommandPathType;
use aspose\slides\MotionPathPointsType;
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$baseDirectory = getcwd();

$presentation = new Presentation($baseDirectory . DIRECTORY_SEPARATOR . "motion.pptx");
try {
    $effect = $presentation->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->get_Item(0);
    $motion = $effect->getBehaviors()->get_Item(0);

    $path = $motion->getPath();
    $path->get_Item(1)->setCommandType(MotionCommandPathType::CurveTo);
    $path->get_Item(1)->setPointsType(MotionPathPointsType::CurveSmooth);
    $curvePoints = [new Point2DFloat(0.1, 0), new Point2DFloat(0.2, 0.1), new Point2DFloat(0.3, 0.1)];
    $path->get_Item(1)->setPoints($curvePoints);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "curve.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Le chemin dans `curve.pptx` possède toujours trois commandes ; sa commande du milieu définit maintenant une courbe.

## **Inspecter et modifier un chemin enregistré**

Chaque [MotionCmdPath](https://reference.aspose.com/slides/fr/php-java/aspose.slides/motioncmdpath/) expose [getPoints](https://reference.aspose.com/slides/fr/php-java/aspose.slides/motioncmdpath/getpoints/), [getCommandType](https://reference.aspose.com/slides/fr/php-java/aspose.slides/motioncmdpath/getcommandtype/), [getPointsType](https://reference.aspose.com/slides/fr/php-java/aspose.slides/motioncmdpath/getpointstype/) et [isRelative](https://reference.aspose.com/slides/fr/php-java/aspose.slides/motioncmdpath/isrelative/). Les exemples suivants utilisent le chemin connu à trois commandes dans `motion.pptx`. Pour une entrée arbitraire, localisez l'effet visé et vérifiez les types de commande et le nombre de points avant de modifier par index.

### **Lire les commandes et les coordonnées**

Lisez le chemin sans le modifier. Les commandes End et CloseLoop n'ont pas besoin de points, donc prévoyez un tableau de points nul.

La sortie associe chaque type de commande numérique à son indicateur de coordonnées relatives avant d'énumérer ses points. Cela vous permet de distinguer un point final d'un décalage avant de modifier le chemin. Une courbe listerait trois points, alors que la ligne droite de ce fichier n'en liste qu'un.

```php
use aspose\slides\Presentation;

$baseDirectory = getcwd();

$presentation = new Presentation($baseDirectory . DIRECTORY_SEPARATOR . "motion.pptx");
try {
    $effect = $presentation->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->get_Item(0);
    $motion = $effect->getBehaviors()->get_Item(0);

    $path = $motion->getPath();
    $commandCount = java_values($path->getCount());
    for ($i = 0; $i < $commandCount; $i++) {
        $segment = $path->get_Item($i);
        $commandType = java_values($segment->getCommandType());
        $relative = java_values($segment->isRelative()) ? "true" : "false";
        echo $commandType . ", relative: " . $relative . PHP_EOL;
        $points = $segment->getPoints();
        if (!java_is_null($points)) {
            foreach ($points as $point) {
                echo "X=" . java_values($point->getX()) . ", Y=" . java_values($point->getY()) . PHP_EOL;
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

L'énumération contient un point de départ, une ligne absolue se terminant à (0.25, 0) et une commande End.

### **Modifier un point final**

Ouvrez `motion.pptx` et remplacez le tableau de points de la ligne afin de déplacer son point final.

Dans le fichier d'entrée, l'index 0 correspond à la commande de départ et l'index 1 à la ligne. Remplacer le seul point de la ligne change sa destination sans modifier son type de commande, sa chronologie ou sa position dans la collection. Parce que la commande utilise des coordonnées absolues, la nouvelle paire spécifie une position plutôt qu'un décalage ajouté.

```php
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$baseDirectory = getcwd();

$presentation = new Presentation($baseDirectory . DIRECTORY_SEPARATOR . "motion.pptx");
try {
    $effect = $presentation->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->get_Item(0);

    $motion = $effect->getBehaviors()->get_Item(0);
    $endPoints = [new Point2DFloat(0.4, 0.1)];
    $motion->getPath()->get_Item(1)->setPoints($endPoints);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "motion-endpoint.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

La ligne dans `motion-endpoint.pptx` se termine à (0.4, 0.1) ; le fichier original reste inchangé.

### **Remplacer un segment**

Utilisez [insert](https://reference.aspose.com/slides/fr/php-java/aspose.slides/motionpath/insert/) et [removeAt](https://reference.aspose.com/slides/fr/php-java/aspose.slides/motionpath/removeat/) pour remplacer la ligne dans `motion.pptx`. L'insertion décale l'ancienne ligne vers l'index 2.

Cela montre le remplacement d'un objet de commande plutôt que la modification de ses coordonnées existantes. Après insertion, la collection contient temporairement la commande de départ, la nouvelle ligne, l'ancienne ligne et la commande End. Supprimer l'index 2 élimine l'ancienne ligne et laisse le nouveau trajet en place.

```php
use aspose\slides\MotionCommandPathType;
use aspose\slides\MotionPathPointsType;
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$baseDirectory = getcwd();

$presentation = new Presentation($baseDirectory . DIRECTORY_SEPARATOR . "motion.pptx");
try {
    $effect = $presentation->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->get_Item(0);
    $motion = $effect->getBehaviors()->get_Item(0);

    $path = $motion->getPath();
    $replacementPoints = [new Point2DFloat(0.2, 0.1)];
    $path->insert(1, MotionCommandPathType::LineTo, $replacementPoints, MotionPathPointsType::Corner, false);
    $path->removeAt(2);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "motion-edited.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Le chemin enregistré possède toujours trois commandes, la nouvelle ligne se terminant à (0.2, 0.1) et la commande End en dernier.

## **Modifier et vérifier un comportement existant**

Lorsque l'index du comportement est inconnu, sélectionnez‑le par type. Cet exemple ouvre `rotation.pptx`, trouve son [RotationEffect](https://reference.aspose.com/slides/fr/php-java/aspose.slides/rotationeffect/), modifie l'angle et vérifie la valeur enregistrée après réouverture.

Le contrôle de type permet à la boucle d'ignorer les comportements qui ne sont pas des rotations. Le second chargement lit le fichier enregistré dans un objet présentation distinct, de sorte que la comparaison vérifie les données persistées plutôt que la valeur toujours en mémoire. Cet exemple suppose toujours que l'effet connu est le premier de la séquence principale ; sélectionner un comportement par type ne localise pas forcément le bon effet dans une présentation arbitraire.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$baseDirectory = getcwd();

$rotationClass = new JavaClass("com.aspose.slides.IRotationEffect");

$presentation = new Presentation($baseDirectory . DIRECTORY_SEPARATOR . "rotation.pptx");
try {
    $effect = $presentation->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->get_Item(0);

    $behaviors = $effect->getBehaviors();
    $behaviorCount = java_values($behaviors->getCount());
    for ($i = 0; $i < $behaviorCount; $i++) {
        $behavior = $behaviors->get_Item($i);
        if (java_instanceof($behavior, $rotationClass)) {
            $rotation = $behavior;
            $rotation->setBy(180);
        }
    }

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "rotation-edited.pptx", SaveFormat::Pptx);

    $reopened = new Presentation($baseDirectory . DIRECTORY_SEPARATOR . "rotation-edited.pptx");
    try {
        $savedEffect = $reopened->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->get_Item(0);

        $savedBehaviors = $savedEffect->getBehaviors();
        $savedBehaviorCount = java_values($savedBehaviors->getCount());
        for ($i = 0; $i < $savedBehaviorCount; $i++) {
            $behavior = $savedBehaviors->get_Item($i);
            if (java_instanceof($behavior, $rotationClass)) {
                $rotation = $behavior;
                $preserved = abs(java_values($rotation->getBy()) - 180) < 0.001;
                echo "Rotation preserved: " . ($preserved ? "true" : "false") . PHP_EOL;
            }
        }
    } finally {
        $reopened->dispose();
    }
} finally {
    $presentation->dispose();
}
```

La sortie est `Rotation preserved: true`. Appliquez le même schéma de vérification par type à d'autres comportements. Pour une vérification complète de conservation, comparez la forme cible, l'effet, les types et l'ordre des comportements, la chronologie et les commandes de chemin. Utilisez une tolérance numérique pour les valeurs à virgule flottante. Pour une présentation avec une disposition d'animation inconnue, consultez [Read Shape Animations](/slides/fr/php-java/shape-animation/#read-shape-animations) pour parcourir les séquences principales et interactives.

## **Ordre des comportements, préréglages et lecture**

L'ordre dans [BehaviorCollection](https://reference.aspose.com/slides/fr/php-java/aspose.slides/behaviorcollection/) correspond à l'ordre stocké des opérations d'un effet. Ce n'est pas une playlist où chaque comportement attend automatiquement le précédent. La chronologie et l'effet englobant déterminent la planification. Les comportements peuvent se chevaucher, et les opérations sur la même propriété peuvent interagir via les paramètres [additive](https://reference.aspose.com/slides/fr/php-java/aspose.slides/behavioradditivetype/) et [accumulation](https://reference.aspose.com/slides/fr/php-java/aspose.slides/behavioraccumulatetype/). N'utilisez pas le simple réordonnancement de la collection pour programmer « déplacer, puis pivoter » ; utilisez une chronologie explicite ou des effets séparés comme décrit dans [Animation de forme](/slides/fr/php-java/shape-animation/).

Le [getType](https://reference.aspose.com/slides/fr/php-java/aspose.slides/effect/gettype/) et le [getSubtype](https://reference.aspose.com/slides/fr/php-java/aspose.slides/effect/getsubtype/) de l'effet décrivent son préréglage. Ils ne constituent pas une description complète d'un arbre de comportements édité. Choisissez le préréglage et le sous‑type avant de personnaliser les comportements : modifier le préréglage peut reconstruire la collection et supprimer vos opérations personnalisées. Par exemple, transformer un effet Spin personnalisé en Fade peut remplacer son comportement de rotation par des comportements set et filter. Inspectez à nouveau la collection après avoir changé un préréglage ou un sous‑type. Vider les comportements du préréglage peut également supprimer les opérations de visibilité ou d'initialisation dont le préréglage a besoin. Les exemples utilisent délibérément des formes visibles et remplacent les comportements ; ils ne reconstruisent pas l'implémentation de chaque préréglage.

## **Compatibilité des formats**

Un arbre de comportements conservé ne garantit pas une lecture identique dans chaque visionneuse ou moteur d'exportation. Vérifiez séparément les données enregistrées et le rendu produit.

| Format ou sortie | Ce qu'il faut vérifier |
| --- | --- |
| PPTX | Utilisez‑le comme format principal pour ces exemples. Réouvrez‑le pour vérifier l'arbre de comportements éditable, puis testez la lecture dans la version PowerPoint visée. |
| PPT | La représentation binaire hérité peut différer du PPTX. Effectuez un cycle de sauvegarde‑réouverture séparé et testez la lecture ; ne déduisez pas le support de chaque combinaison personnalisée à partir d'un résultat PPTX réussi. |
| PDF, PNG, JPEG et autres images de diapositive statiques | Contiennent une représentation statique de la diapositive, pas de chronologie de comportements jouable ni d'image d'animation finale garantie. |
| [HTML5](/slides/fr/php-java/export-to-html5/) | Peut lire les animations prises en charge lorsque l'animation de forme est activée dans les options d'exportation. Testez les combinaisons personnalisées dans le navigateur. |
| [GIF animé](/slides/fr/php-java/convert-powerpoint-to-animated-gif/) | Stocke les images rendues, pas les comportements éditables ou les interactions déclenchées par un clic. Vérifiez le mouvement réellement rendu. |
| [Vidéo](/slides/fr/php-java/convert-powerpoint-to-video/) | Rend les images d'animation et les encode en vidéo. Le support est limité aux [animations et effets pris en charge](/slides/fr/php-java/convert-powerpoint-to-video/#supported-animations-and-effects) ; les commandes et événements interactifs ne deviennent pas une chronologie éditable. |

## **FAQ**

**Pourquoi mon effet contient‑il des comportements avant que j'en ajoute ?**

Créer un effet prédéfini peut créer ses opérations sous‑jacentes. Inspectez‑les avant de décider d'étendre le préréglage ou de remplacer ses comportements.

**Déplacer un comportement au début le fait‑il jouer en premier ?**

Pas nécessairement. L'ordre de la collection ne remplace pas la chronologie. Vérifiez les délais, les durées et les interactions entre les opérations sur la même propriété.

**Pourquoi une commande End n'a‑t‑elle aucun point ?**

Elle marque la fin du chemin et n'a pas besoin de coordonnées. Vérifiez la présence d'un tableau de points nul lors de l'inspection d'un chemin lu depuis un fichier.

**Un aller‑retour réussi suffit‑il à confirmer la lecture ?**

Non. La réouverture confirme la conservation des propriétés que vous avez vérifiées. Testez séparément le lecteur de diaporama ou l'export animé pour confirmer son comportement visuel.