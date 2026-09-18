---
title: Créer et modifier des comportements d'animation personnalisés en .NET
linktitle: Animation personnalisée
type: docs
weight: 151
url: /fr/net/custom-animation/
keywords:
- animation personnalisée
- comportement d'animation
- chemin de mouvement
- PowerPoint
- présentation
- .NET
- C#
- Aspose.Slides
description: "Créer, inspecter et modifier des comportements d'animation personnalisés ainsi que des chemins de mouvement éditables dans les présentations PowerPoint avec Aspose.Slides pour .NET."
---
## **Vue d'ensemble**

Les comportements d'animation personnalisés vous permettent de contrôler des opérations individuelles au sein d'un effet d'animation, comme changer une couleur, faire pivoter une forme ou suivre un chemin de mouvement éditable. Ce guide montre comment créer et combiner des comportements, configurer leur timing, inspecter et modifier les animations existantes, et vérifier que leurs propriétés survivent à l'enregistrement et à la réouverture d'une présentation.

Pour les effets prédéfinis et les déclencheurs de clic, voir [Animation de forme](/slides/fr/net/shape-animation/).

## **Comprendre le modèle d'animation**

Une animation est organisée comme **Timeline → Sequence → Effect → Behaviors** :

- Le [Timeline](https://reference.aspose.com/slides/fr/net/aspose.slides/ibaseslide/timeline/) de la diapositive contient sa séquence principale et les séquences interactives.  
- Une [ISequence](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/isequence/) contient des effets, pouvant cibler différentes formes.  
- Un [IEffect](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/ieffect/) identifie une forme cible, un préréglage, un sous‑type et le timing de l'effet.  
- [IEffect.Behaviors](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/ieffect/behaviors/) contient les opérations qui implémentent l'effet : changer la couleur, déplacer, faire pivoter, définir une propriété, etc.

## **Créer des comportements individuels**

Appelez [ISequence.AddEffect](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/isequence/addeffect/) pour créer un effet et accéder à sa collection [Behaviors](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/ieffect/behaviors/). Un préréglage peut remplir automatiquement cette collection. Conservez ses opérations lors de l'extension du préréglage, ou utilisez [Clear](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/ibehaviorcollection/clear/) lorsque vous les remplacez délibérément.

[IBehaviorFactory](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/ibehaviorfactory/) crée les huit types de comportements illustrés ci‑dessous. Le mouvement est couvert dans [Build a Motion Path](#build-a-motion-path). Chaque exemple de création est un programme complet ; les exemples d'édition ultérieurs indiquent le fichier de sortie utilisé.

### **Rotation**

Utilisez [CreateRotationEffect](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/ibehaviorfactory/createrotationeffect/) pour créer une rotation. [By](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/irotationeffect/by/) indique un angle relatif en degrés ; [From](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/irotationeffect/from/) et [To](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/irotationeffect/to/) définissent les points de départ et d'arrivée.

L'exemple commence avec un effet Spin, remplace ses opérations de préréglage par un comportement de rotation, et donne à cette opération une durée de deux secondes. Un angle relatif de 90 degrés représente un quart de tour à partir de l'orientation initiale de la forme, ainsi aucun angle de départ explicite n'est nécessaire.

```csharp
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.Spin, EffectSubtype.None, EffectTriggerType.OnClick);
effect.Behaviors.Clear();

IBehaviorFactory factory = new BehaviorFactory();
var rotation = factory.CreateRotationEffect();
rotation.By = 90f;
rotation.Timing.Duration = 2f;

effect.Behaviors.Add(rotation);

presentation.Save("rotation.pptx", SaveFormat.Pptx);
```

`rotation.pptx` contient une forme et un comportement de rotation. La collection, le timing et les exemples de modification de rotation ci‑dessous utilisent ce fichier.

### **Échelle**

Utilisez [CreateScaleEffect](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/ibehaviorfactory/createscaleeffect/) avec des pourcentages X/Y : [From](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/iscaleeffect/from/) et [To](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/iscaleeffect/to/) décrivent la taille de départ et d'arrivée, tandis que [By](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/iscaleeffect/by/) décrit une modification relative. Ici, 100 représente la taille d'origine.

L'exemple augmente les deux dimensions de 100 % à 125 % en deux secondes. Utiliser des pourcentages horizontaux et verticaux égaux conserve les proportions de la forme ; des pourcentages différents étireraient davantage une dimension que l'autre.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.GrowShrink, EffectSubtype.None, EffectTriggerType.OnClick);
effect.Behaviors.Clear();

IBehaviorFactory factory = new BehaviorFactory();
var scale = factory.CreateScaleEffect();
scale.From = new PointF(100, 100);
scale.To = new PointF(125, 125);
scale.Timing.Duration = 2f;

effect.Behaviors.Add(scale);

presentation.Save("scale.pptx", SaveFormat.Pptx);
```

### **Couleur**

Utilisez [CreateColorEffect](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/ibehaviorfactory/createcoloreffect/) pour changer le remplissage du bleu à l'orange. [From](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/icoloreffect/from/) et [To](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/icoloreffect/to/) sont des couleurs ; [By](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/icoloreffect/by/) est un décalage de couleur. [IBehavior.Properties](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/ibehavior/properties/) identifie l'attribut animé.

Le remplissage plein de la forme est initialisé en bleu, correspondant à la couleur de départ de l'animation. Sélectionner l'attribut de couleur de remplissage indique au comportement quelle partie de la forme modifier ; les points de couleur seuls n'identifient pas cet attribut. L'effet enregistré décrit une transition de deux secondes vers l'orange.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.Blue;

var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.ChangeFillColor, EffectSubtype.None, EffectTriggerType.OnClick);
effect.Behaviors.Clear();

IBehaviorFactory factory = new BehaviorFactory();
var color = factory.CreateColorEffect();
color.Properties.Add(BehaviorProperty.FillColor);
color.From.Color = Color.Blue;
color.To.Color = Color.Orange;
color.Timing.Duration = 2f;

effect.Behaviors.Add(color);

presentation.Save("color.pptx", SaveFormat.Pptx);
```

### **Filtre**

Utilisez [CreateFilterEffect](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/ibehaviorfactory/createfiltereffect/) pour sélectionner une transition. [Type](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/ifiltereffect/type/), [Subtype](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/ifiltereffect/subtype/), et [Reveal](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/ifiltereffect/reveal/) spécifient le filtre, la direction et si la forme doit être révélée ou masquée.

Cet exemple configure une transition de deux secondes qui révèle la forme en utilisant le sous‑type de direction droite. Les paramètres du filtre appartiennent au comportement à l'intérieur de l'effet, ils sont donc configurés après la suppression des opérations originales du préréglage.

```csharp
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.Wipe, EffectSubtype.None, EffectTriggerType.OnClick);
effect.Behaviors.Clear();

IBehaviorFactory factory = new BehaviorFactory();
var filter = factory.CreateFilterEffect();
filter.Type = FilterEffectType.Wipe;
filter.Subtype = FilterEffectSubtype.Right;
filter.Reveal = FilterEffectRevealType.In;
filter.Timing.Duration = 2f;

effect.Behaviors.Add(filter);

presentation.Save("filter.pptx", SaveFormat.Pptx);
```

### **Propriété**

Utilisez [CreatePropertyEffect](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/ibehaviorfactory/createpropertyeffect/) pour animer l'opacité. [From](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/ipropertyeffect/from/), [To](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/ipropertyeffect/to/), et [By](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/ipropertyeffect/by/) sont des chaînes interprétées à l'aide de [ValueType](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/ipropertyeffect/valuetype/) et [CalcMode](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/ipropertyeffect/calcmode/). Choisissez des points d'extrémité ou un décalage relatif plutôt que de définir les trois indiscriminément.

Ici, l'attribut sélectionné est l'opacité, et les chaînes numériques représentent un changement de 25 % d'opacité à pleine opacité. L'interpolation linéaire décrit une variation progressive entre ces valeurs. Lors de l'adaptation de cet exemple à un autre attribut, choisissez un type de valeur et des valeurs d'extrémité appropriées à cet attribut.

```csharp
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
effect.Behaviors.Clear();

IBehaviorFactory factory = new BehaviorFactory();
var property = factory.CreatePropertyEffect();
property.Properties.Add(BehaviorProperty.StyleOpacity);
property.ValueType = PropertyValueType.Number;
property.CalcMode = PropertyCalcModeType.Linear;
property.From = "0.25";
property.To = "1";
property.Timing.Duration = 2f;

effect.Behaviors.Add(property);

presentation.Save("property.pptx", SaveFormat.Pptx);
```

### **Set**

Utilisez [CreateSetEffect](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/ibehaviorfactory/createseteffect/) pour affecter la visibilité via [To](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/iseteffect/to/). Un comportement Set n’interpole pas entre les points d'extrémité.

L'exemple sélectionne l'attribut visibilité et assigne la chaîne `visible` lorsque le comportement s'exécute. Le rectangle est déjà visible dans cette présentation minimale, ainsi l'assignation peut ne pas produire de changement visuel évident seule. Une telle opération est utile dans le cadre d'un effet plus large qui contrôle également quand la forme devient cachée ou visible.

```csharp
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.Appear, EffectSubtype.None, EffectTriggerType.OnClick);
effect.Behaviors.Clear();

IBehaviorFactory factory = new BehaviorFactory();
var set = factory.CreateSetEffect();
set.Properties.Add(BehaviorProperty.StyleVisibility);
set.To = "visible";

effect.Behaviors.Add(set);

presentation.Save("set.pptx", SaveFormat.Pptx);
```

### **Commande**

Utilisez [CreateCommandEffect](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/ibehaviorfactory/createcommandeffect/) et configurez [Type](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/icommandeffect/type/), [CommandString](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/icommandeffect/commandstring/), et [ShapeTarget](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/icommandeffect/shapetarget/). Placez un enregistrement WAV nommé `sample.wav` dans le répertoire de travail. Cet exemple l'intègre avec [AddAudioFrameEmbedded](https://reference.aspose.com/slides/fr/net/aspose.slides/ishapecollection/addaudioframeembedded/) et attache une commande de lecture au cadre audio.

Le cadre audio est à la fois la cible de l'effet et la cible de la commande. Cela relie la demande de lecture à l'enregistrement intégré ; une chaîne de commande seule n'identifie pas l'objet multimédia à contrôler. L'effet est configuré pour démarrer lors d'un clic pendant le diaporama.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var audioStream = File.OpenRead("sample.wav");
var audioFrame = slide.Shapes.AddAudioFrameEmbedded(100, 100, 40, 40, audioStream);

var effect = slide.Timeline.MainSequence.AddEffect(audioFrame, EffectType.MediaPlay, EffectSubtype.None, EffectTriggerType.OnClick);
effect.Behaviors.Clear();

IBehaviorFactory factory = new BehaviorFactory();
var command = factory.CreateCommandEffect();
command.Type = CommandEffectType.Call;
command.CommandString = "play";
command.ShapeTarget = audioFrame;

effect.Behaviors.Add(command);

presentation.Save("command.pptx", SaveFormat.Pptx);
```

L'enregistrement stocke la commande dans `command.pptx` ; il ne lit pas l'enregistrement. La lecture nécessite un lecteur de diaporama qui prend en charge la commande et sa cible multimédia.

## **Gérer la collection de comportements**

[IBehaviorCollection](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/ibehaviorcollection/) prend en charge [Add](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/ibehaviorcollection/add/), [Insert](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/ibehaviorcollection/insert/), [Remove](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/ibehaviorcollection/remove/), et [RemoveAt](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/ibehaviorcollection/removeat/). Cet exemple ouvre `rotation.pptx`, ajoute une mise à l'échelle, la déplace avant la rotation, et supprime la rotation. Supprimer et réinsérer le même objet change sa position stockée sans en créer une copie.

La séquence d'éditions modifie la collection de rotation–scale à scale–rotation, puis à scale uniquement. Les indices font référence à la collection actuelle, ainsi la suppression utilise le nouvel indice de la rotation après le réordonnancement. L'énumération finale confirme quel comportement sera enregistré.

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation("rotation.pptx");
var effect = presentation.Slides[0].Timeline.MainSequence[0];
var behaviors = effect.Behaviors;

IBehaviorFactory factory = new BehaviorFactory();
var scale = factory.CreateScaleEffect();
scale.To = new PointF(125, 125);
scale.Timing.Duration = 2f;

behaviors.Add(scale);

behaviors.Remove(scale);
behaviors.Insert(0, scale);
behaviors.RemoveAt(1);

foreach (var behavior in behaviors)
    Console.WriteLine(behavior.GetType().Name);

presentation.Save("collection-edited.pptx", SaveFormat.Pptx);
```

Le résultat est `ScaleEffect` : seul le redimensionnement reste. L'ordre de la collection ne planifie pas, en soi, les comportements les uns après les autres. Videz la collection uniquement lorsque vous remplacez toutes ses opérations.

## **Configurer le timing des comportements**

[IBehavior.Timing](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/ibehavior/timing/) expose [ITiming](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/itiming/), indépendamment de [IEffect.Timing](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/ieffect/timing/). Le timing de l'effet planifie l'effet enveloppant ; le timing du comportement décrit une opération à l'intérieur.

### **Définir la durée, le délai, la répétition et l'accélération**

Ouvrez `rotation.pptx` et définissez [Duration](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/itiming/duration/) et [TriggerDelayTime](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/itiming/triggerdelaytime/) en secondes, puis configurez [RepeatCount](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/itiming/repeatcount/). [Accelerate](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/itiming/accelerate/) et [Decelerate](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/itiming/decelerate/) sont des fractions de la durée ; gardez leur somme au maximum à 1.

Le fichier d'entrée est celui créé dans l'exemple de rotation, où le premier comportement est connu comme étant une rotation. Cet exemple ne modifie que le timing de ce comportement ; son angle de 90 ° reste intact. Séparer l'angle et le timing facilite l'ajustement du rythme sans reconstruire l'animation.

```csharp
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation("rotation.pptx");
var effect = presentation.Slides[0].Timeline.MainSequence[0];

var rotation = (IRotationEffect)effect.Behaviors[0];
rotation.Timing.Duration = 2f;
rotation.Timing.TriggerDelayTime = 0.5f;
rotation.Timing.RepeatCount = 3f;
rotation.Timing.Accelerate = 0.2f;
rotation.Timing.Decelerate = 0.2f;

presentation.Save("timing.pptx", SaveFormat.Pptx);
```

Le comportement utilise une durée de deux secondes, un délai de 0,5 seconde et un nombre de répétitions de 3. Les 20 % du début et de la fin de sa durée sont utilisés pour l'accélération et la décélération.

D'autres politiques de répétition incluent [RepeatDuration](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/itiming/repeatduration/), [RepeatUntilEndSlide](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/itiming/repeatuntilendslide/), et [RepeatUntilNextClick](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/itiming/repeatuntilnextclick/); choisissez une politique plutôt que de les activer toutes simultanément. [AutoReverse](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/itiming/autoreverse/) joue l'animation à l'envers après le passage avant. L'accélération et la décélération s'appliquent aux changements continus, pas aux assignations ou commandes discrètes.

## **Construire un chemin de mouvement**

Utilisez [CreateMotionEffect](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/ibehaviorfactory/createmotioneffect/) pour créer un mouvement. Ses [From](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/imotioneffect/from/), [To](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/imotioneffect/to/), et [By](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/imotioneffect/by/) décrivent des coordonnées ou décalages basés sur des pourcentages. Pour un trajet éditable, créez un [MotionPath](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/motionpath/) et assignez‑le à [IMotionEffect.Path](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/imotioneffect/path/). [IMotionPath](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/imotionpath/) stocke les commandes du chemin.

| Commande | Points | Signification |
| --- | --- | --- |
| MoveTo | Un | Définir la position de départ. |
| LineTo | Un | Se déplacer le long d'un segment droit jusqu'à son point final. |
| CurveTo | Trois | Suivre une courbe cubique définie par deux points de contrôle et un point final. |
| CloseLoop | Aucun | Revenir à la position de départ. |
| End | Aucun | Terminer le chemin. |

[MotionPathPointsType](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/motionpathpointstype/) décrit les caractéristiques d'édition des points, telles que les points d'angle ou lisses. Il ne remplace pas le type de commande. Utilisez un type de point de courbe pour l'exemple de courbe ci‑dessous, et un type de point d'angle pour les segments droits.

Les coordonnées du chemin sont normalisées aux dimensions de la diapositive : un déplacement X de 0,25 représente un quart de la largeur de la diapositive, pas 0,25 points. Le Y positif descend. Les commandes absolues spécifient des positions dans le système de coordonnées du chemin ; les commandes relatives spécifient des décalages à partir de la position actuelle. Cela est distinct de [Origin](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/imotioneffect/origin/), qui sélectionne le cadre de référence du chemin, et de [PathEditMode](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/imotioneffect/patheditmode/), qui contrôle comment le chemin se déplace lorsque la forme est déplacée.

### **Créer un chemin droit**

Créez un comportement de mouvement avec un point de départ, un segment droit, et une commande de fin. [IMotionPath.Add](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/imotionpath/add/) prend le type de commande, ses points, le type de point et un indicateur de coordonnées relatives.

La commande de départ établit (0, 0), et la ligne se termine à (0,25, 0), donnant au trajet un déplacement horizontal d'un quart de la largeur de la diapositive. La commande de fin n'a aucun point de coordonnées. Une fois le chemin attribué, l'ajout du comportement de mouvement à l'effet relie ce trajet au rectangle.

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.PathRight, EffectSubtype.None, EffectTriggerType.OnClick);
effect.Behaviors.Clear();

IBehaviorFactory factory = new BehaviorFactory();
var motion = factory.CreateMotionEffect();
motion.Origin = MotionOriginType.Layout;
motion.Timing.Duration = 2f;

var path = new MotionPath();
path.Add(MotionCommandPathType.MoveTo, new[] { new PointF(0, 0) }, MotionPathPointsType.Auto, false);
path.Add(MotionCommandPathType.LineTo, new[] { new PointF(0.25f, 0) }, MotionPathPointsType.Corner, false);
path.Add(MotionCommandPathType.End, Array.Empty<PointF>(), MotionPathPointsType.None, false);

motion.Path = path;
effect.Behaviors.Add(motion);

presentation.Save("motion.pptx", SaveFormat.Pptx);
```

`motion.pptx` contient un comportement de mouvement avec trois commandes de chemin. Les exemples d'édition de fichiers suivants utilisent cette structure connue.

### **Comparer les coordonnées absolues et relatives**

Ces deux objets de chemin décrivent le même trajet. La commande absolue se termine à (0,3, 0,1) ; la commande relative ajoute (0,1, 0,1) à la position actuelle, (0,2, 0).

Les deux chemins commencent à la même position. Pour la ligne relative, ajoutez ses décalages X et Y à la position actuelle pour obtenir le point final ; pour la ligne absolue, lisez directement le point final. Basculer l'indicateur sans convertir les coordonnées décrirait un trajet différent.

```csharp
using System.Drawing;
using Aspose.Slides.Animation;

var absolutePath = new MotionPath();
absolutePath.Add(MotionCommandPathType.MoveTo, new[] { new PointF(0.2f, 0) }, MotionPathPointsType.Auto, false);
absolutePath.Add(MotionCommandPathType.LineTo, new[] { new PointF(0.3f, 0.1f) }, MotionPathPointsType.Corner, false);

var relativePath = new MotionPath();
relativePath.Add(MotionCommandPathType.MoveTo, new[] { new PointF(0.2f, 0) }, MotionPathPointsType.Auto, false);
relativePath.Add(MotionCommandPathType.LineTo, new[] { new PointF(0.1f, 0.1f) }, MotionPathPointsType.Corner, true);
```

Attribuez l'un ou l'autre chemin à un comportement de mouvement pour l'utiliser dans une présentation. Le dernier argument booléen sélectionne les coordonnées relatives pour cette commande.

### **Remplacer une ligne par une courbe**

Ouvrez `motion.pptx` et remplacez sa commande de ligne par une courbe cubique. Fournissez d'abord les deux points de contrôle, suivis du point final.

La position de départ est fournie par la commande précédente. Les deux premiers points façonnent la courbe, tandis que le troisième est sa destination ; ils ne sont pas trois destinations successives. Mettre à jour le type de commande, le type d'édition des points et le tableau de points ensemble maintient le segment cohérent avec sa nouvelle géométrie.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation("motion.pptx");
var effect = presentation.Slides[0].Timeline.MainSequence[0];
var motion = (IMotionEffect)effect.Behaviors[0];

var path = motion.Path;
path[1].CommandType = MotionCommandPathType.CurveTo;
path[1].PointsType = MotionPathPointsType.CurveSmooth;
path[1].Points = new[] { new PointF(0.1f, 0), new PointF(0.2f, 0.1f), new PointF(0.3f, 0.1f) };

presentation.Save("curve.pptx", SaveFormat.Pptx);
```

Le chemin dans `curve.pptx` comporte toujours trois commandes ; sa commande du milieu définit maintenant une courbe.

## **Inspecter et modifier un chemin enregistré**

Chaque [IMotionCmdPath](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/imotioncmdpath/) expose [Points](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/imotioncmdpath/points/), [CommandType](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/imotioncmdpath/commandtype/), [PointsType](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/imotioncmdpath/pointstype/), et [IsRelative](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/imotioncmdpath/isrelative/). Les exemples suivants utilisent le chemin à trois commandes connu dans `motion.pptx`. Pour une entrée quelconque, localisez l'effet visé et vérifiez les types de commande et le nombre de points avant d'éditer par indice.

### **Lire les commandes et les coordonnées**

Lisez le chemin sans le modifier. Les commandes End et CloseLoop n'ont pas besoin de points, donc prévoyez un tableau de points nul.

La sortie associe chaque commande à son indicateur de coordonnées relatives avant d'énumérer ses points. Cela vous permet de distinguer un point final d'un décalage avant de modifier le chemin. Une courbe listerait trois points, alors que la ligne droite dans ce fichier n'en liste qu'un.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Animation;

using var presentation = new Presentation("motion.pptx");
var effect = presentation.Slides[0].Timeline.MainSequence[0];
var motion = (IMotionEffect)effect.Behaviors[0];

var path = motion.Path;
foreach (var segment in path)
{
    Console.WriteLine($"{segment.CommandType}, relative: {segment.IsRelative}");
    if (segment.Points != null)
        foreach (var point in segment.Points)
            Console.WriteLine($"X={point.X}, Y={point.Y}");
}
```

La liste contient un point de départ, une ligne absolue se terminant à (0,25, 0), et une commande End.

### **Modifier un point final**

Ouvrez `motion.pptx` et remplacez le tableau de points de la ligne pour déplacer son point final.

Dans le fichier d'entrée, l'indice 0 correspond à la commande de départ et l'indice 1 à la ligne. Remplacer le point unique de la ligne change sa destination sans modifier son type de commande, son timing ou sa position dans la collection. Comme la commande utilise des coordonnées absolues, la nouvelle paire spécifie une position plutôt qu'un décalage ajouté.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation("motion.pptx");
var effect = presentation.Slides[0].Timeline.MainSequence[0];

var motion = (IMotionEffect)effect.Behaviors[0];
motion.Path[1].Points = new[] { new PointF(0.4f, 0.1f) };

presentation.Save("motion-endpoint.pptx", SaveFormat.Pptx);
```

La ligne dans `motion-endpoint.pptx` se termine à (0,4, 0,1) ; le fichier original reste inchangé.

### **Remplacer un segment**

Utilisez [Insert](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/imotionpath/insert/) et [RemoveAt](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/imotionpath/removeat/) pour remplacer la ligne dans `motion.pptx`. L'insertion décale l'ancienne ligne à l'indice 2.

Cela démontre la substitution d'un objet de commande plutôt que la modification de ses coordonnées existantes. Après l'insertion, la collection contient temporairement la commande de départ, la nouvelle ligne, l'ancienne ligne et la commande End. La suppression de l'indice 2 élimine l'ancienne ligne et laisse le nouveau trajet en place.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation("motion.pptx");
var effect = presentation.Slides[0].Timeline.MainSequence[0];
var motion = (IMotionEffect)effect.Behaviors[0];

var path = motion.Path;
path.Insert(1, MotionCommandPathType.LineTo, new[] { new PointF(0.2f, 0.1f) }, MotionPathPointsType.Corner, false);
path.RemoveAt(2);

presentation.Save("motion-edited.pptx", SaveFormat.Pptx);
```

Le chemin enregistré possède toujours trois commandes, la nouvelle ligne se terminant à (0,2, 0,1) et la commande End en dernier.

## **Modifier et vérifier un comportement existant**

Lorsque l'indice du comportement est inconnu, sélectionnez-le par type. Cet exemple ouvre `rotation.pptx`, trouve son [IRotationEffect](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/irotationeffect/), modifie l'angle et vérifie la valeur enregistrée après réouverture.

La vérification du type permet à la boucle d'ignorer les comportements qui ne sont pas des rotations. Le deuxième chargement lit le fichier enregistré dans un objet présentation séparé, ainsi la comparaison vérifie les données persistées plutôt que la valeur toujours en mémoire. Cet exemple suppose toujours que l'effet connu est le premier de la séquence principale ; sélectionner un comportement par type ne localise pas l'effet correct dans une présentation arbitraire.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation("rotation.pptx");
var effect = presentation.Slides[0].Timeline.MainSequence[0];

foreach (var behavior in effect.Behaviors)
{
    if (behavior is IRotationEffect rotation)
        rotation.By = 180f;
}

presentation.Save("rotation-edited.pptx", SaveFormat.Pptx);

using var reopened = new Presentation("rotation-edited.pptx");
var savedEffect = reopened.Slides[0].Timeline.MainSequence[0];

foreach (var behavior in savedEffect.Behaviors)
{
    if (behavior is IRotationEffect rotation)
        Console.WriteLine($"Rotation preserved: {Math.Abs(rotation.By - 180f) < 0.001f}");
}
```

Le résultat est `Rotation preserved: True`. Appliquez le même modèle de vérification de type aux autres comportements. Pour une vérification complète de la préservation, comparez la forme cible, l'effet, les types et l'ordre des comportements, le timing et les commandes du chemin. Utilisez une tolérance numérique pour les valeurs à virgule flottante. Pour une présentation avec une disposition d'animation inconnue, voir [Read Shape Animations](/slides/fr/net/shape-animation/#read-shape-animations) pour le parcours des séquences principales et interactives.

## **Ordre des comportements, préréglages et lecture**

L'ordre dans [IBehaviorCollection](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/ibehaviorcollection/) est l'ordre stocké des opérations d'un effet. Ce n'est pas une playlist où chaque comportement attend automatiquement le précédent. Le timing et l'effet enveloppant déterminent la planification. Les comportements peuvent se chevaucher, et les opérations sur la même propriété peuvent interagir via [Additive](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/ibehavior/additive/) et [Accumulate](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/ibehavior/accumulate/). N'utilisez pas uniquement le réordonnancement de la collection pour planifier « déplacer, puis pivoter » ; utilisez un timing explicite ou des effets séparés comme décrit dans [Shape Animation](/slides/fr/net/shape-animation/).

Le [Type](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/ieffect/type/) et le [Subtype](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/ieffect/subtype/) de l'effet décrivent son préréglage. Ils ne constituent pas une description complète d'un arbre de comportements édité. Choisissez le préréglage et le sous‑type avant de personnaliser les comportements : changer le préréglage peut reconstruire la collection et supprimer vos opérations personnalisées. Par exemple, changer un effet Spin personnalisé en Fade peut remplacer son comportement de rotation par des comportements set et filter. Inspectez de nouveau la collection après avoir changé un préréglage ou un sous‑type. Vider les comportements du préréglage peut également supprimer des opérations de visibilité ou d'initialisation dont le préréglage a besoin. Les exemples utilisent délibérément des formes visibles et remplacent les comportements ; ils ne reconstruisent pas l'implémentation de chaque préréglage.

## **Compatibilité des formats**

Un arbre de comportements préservé ne garantit pas une lecture identique dans chaque visualiseur ou moteur d'exportation. Vérifiez séparément les données enregistrées et le rendu obtenu.

| Format ou sortie | Ce qu'il faut vérifier |
| --- | --- |
| PPTX | Utilisez-le comme format principal pour ces exemples. Rouvrez-le pour vérifier l'arbre de comportements éditable, puis testez la lecture dans la version de PowerPoint souhaitée. |
| PPT | La représentation binaire héritée peut différer du PPTX. Testez un cycle séparé d'enregistrement‑et‑réouverture et la lecture ; ne déduisez pas le support de chaque combinaison personnalisée à partir d'un résultat PPTX réussi. |
| PDF, PNG, JPEG, et autres images de diapositive statiques | Contiennent une représentation statique de la diapositive, pas de chronologie de comportements jouable ni d'image d'animation finale garantie. |
| [HTML5](/slides/fr/net/export-to-html5/) | Peut lire les animations supportées lorsque l'animation de forme est activée dans les options d'exportation. Testez les combinaisons personnalisées dans le navigateur. |
| [Animated GIF](/slides/fr/net/convert-powerpoint-to-animated-gif/) | Stocke les images rendues, pas des comportements éditables ou des interactions déclenchées par clic. Vérifiez le mouvement réellement rendu. |
| [Video](/slides/fr/net/convert-powerpoint-to-video/) | Rend les images d'animation et les encode en vidéo. Le support est limité aux [animations et effets pris en charge](/slides/fr/net/convert-powerpoint-to-video/#supported-animations-and-effects) du moteur ; les commandes et événements interactifs ne deviennent pas une chronologie éditable. |

## **FAQ**

**Pourquoi mon effet contient‑il des comportements avant que j'en ajoute ?**  
Créer un effet prédéfini peut créer ses opérations sous‑jacentes. Inspectez‑les avant de décider d'étendre le préréglage ou de remplacer ses comportements.

**Déplacer un comportement au début le fait‑il jouer en premier ?**  
Pas nécessairement. L'ordre de la collection ne remplace pas le timing. Vérifiez les délais, durées et les interactions entre les opérations sur la même propriété.

**Pourquoi une commande End n’a‑t‑elle aucun point ?**  
Elle marque la fin du chemin et n’a pas besoin de coordonnées. Vérifiez la présence d’un tableau de points nul lors de l’inspection d’un chemin lu depuis un fichier.

**Un aller‑retour réussi suffit‑il à confirmer la lecture ?**  
Non. La réouverture confirme la préservation des propriétés vérifiées. Testez séparément le lecteur de diaporama ou l’export animée pour confirmer son comportement visuel.