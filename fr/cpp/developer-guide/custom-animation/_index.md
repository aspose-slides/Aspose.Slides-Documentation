---
title: Créer et modifier des comportements d'animation personnalisés en C++
linktitle: Animation personnalisée
type: docs
weight: 151
url: /fr/cpp/custom-animation/
keywords:
- animation personnalisée
- comportement d'animation
- chemin de mouvement
- PowerPoint
- présentation
- C++
- Aspose.Slides
description: "Créer, inspecter et modifier des comportements d'animation personnalisés et des chemins de mouvement éditables dans les présentations PowerPoint avec Aspose.Slides pour C++."
---
## **Vue d'ensemble**

Les comportements d'animation personnalisés vous permettent de contrôler des opérations individuelles au sein d'un effet d'animation, comme changer une couleur, faire pivoter une forme ou suivre un chemin de mouvement éditable. Ce guide montre comment créer et combiner des comportements, configurer leur minutage, inspecter et modifier des animations existantes, et vérifier que leurs propriétés survivent à l'enregistrement et à la réouverture d'une présentation.

Pour les effets prédéfinis et les déclencheurs de clic, voir [Animation de forme](/slides/fr/cpp/shape-animation/).

## **Comprendre le modèle d'animation**

Une animation est organisée comme **Timeline → Sequence → Effect → Behaviors** :

- Le [get_Timeline]((https://reference.aspose.com/slides/fr/cpp/aspose.slides/ibaseslide/get_timeline/)) de la diapositive contient sa séquence principale et les séquences interactives.  
- Une [ISequence]((https://reference.aspose.com/slides/fr/cpp/aspose.slides.animation/isequence/)) contient des effets, pouvant cibler différentes formes.  
- Un [IEffect]((https://reference.aspose.com/slides/fr/cpp/aspose.slides.animation/ieffect/)) identifie une forme cible, un préréglage, un sous‑type et le minutage de l'effet.  
- [IEffect::get_Behaviors]((https://reference.aspose.com/slides/fr/cpp/aspose.slides.animation/ieffect/get_behaviors/)) contient les opérations qui implémentent l'effet : changement de couleur, déplacement, rotation, définition d'une propriété, etc.

## **Créer des comportements individuels**

Appelez [ISequence::AddEffect]((https://reference.aspose.com/slides/fr/cpp/aspose.slides.animation/isequence/addeffect/)) pour créer un effet et accéder à sa collection [get_Behaviors]((https://reference.aspose.com/slides/fr/cpp/aspose.slides.animation/ieffect/get_behaviors/)). Un préréglage peut remplir cette collection automatiquement. Conservez ses opérations lorsque vous étendez le préréglage, ou utilisez [Clear]((https://reference.aspose.com/slides/fr/cpp/aspose.slides.animation/ibehaviorcollection/clear/)) lorsque vous les remplacez délibérément.

[IBehaviorFactory]((https://reference.aspose.com/slides/fr/cpp/aspose.slides.animation/ibehaviorfactory/)) crée les huit types de comportements illustrés ci‑dessous. Le mouvement est traité dans [Construire un chemin de mouvement](#build-a-motion-path). Chaque exemple de création est du code autonome à exécuter dans une fonction ; les exemples d'édition ultérieurs indiquent le fichier de sortie utilisé.

### **Rotation**

Utilisez [CreateRotationEffect]((https://reference.aspose.com/slides/fr/cpp/aspose.slides.animation/ibehaviorfactory/createrotationeffect/)) pour créer une rotation. [get_By]((https://reference.aspose.com/slides/fr/cpp/aspose.slides.animation/irotationeffect/get_by/)) indique un angle relatif en degrés ; [get_From]((https://reference.aspose.com/slides/fr/cpp/aspose.slides.animation/irotationeffect/get_from/)) et [get_To]((https://reference.aspose.com/slides/fr/cpp/aspose.slides.animation/irotationeffect/get_to/)) spécifient les points de départ et d'arrivée.

L'exemple commence avec un effet Spin, remplace ses opérations de préréglage par un seul comportement de rotation, et donne à cette opération une durée de deux secondes. Un angle relatif de 90 degrés représente un quart de tour par rapport à l'orientation de départ de la forme, il n'est donc pas nécessaire de préciser d'angle de départ.

```cpp
#include <DOM/Animation/BehaviorFactory.h>
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IRotationEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

auto effect = slide->get_Timeline()->get_MainSequence()->AddEffect(shape, EffectType::Spin, EffectSubtype::None, EffectTriggerType::OnClick);
effect->get_Behaviors()->Clear();

auto factory = MakeObject<BehaviorFactory>();
auto rotation = factory->CreateRotationEffect();
rotation->set_By(90.0f);
rotation->get_Timing()->set_Duration(2.0f);

effect->get_Behaviors()->Add(rotation);

presentation->Save(u"rotation.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

`rotation.pptx` contient une forme et un comportement de rotation. La collection, le minutage et les exemples d'édition de rotation ci‑dessous utilisent ce fichier.

### **Mise à l'échelle**

Utilisez [CreateScaleEffect]((https://reference.aspose.com/slides/fr/cpp/aspose.slides.animation/ibehaviorfactory/createscaleeffect/)) avec des pourcentages X/Y : [get_From]((https://reference.aspose.com/slides/fr/cpp/aspose.slides.animation/iscaleeffect/get_from/)) et [get_To]((https://reference.aspose.com/slides/fr/cpp/aspose.slides.animation/iscaleeffect/get_to/)) décrivent la taille de départ et d'arrivée, tandis que [get_By]((https://reference.aspose.com/slides/fr/cpp/aspose.slides.animation/iscaleeffect/get_by/)) décrit une variation relative. Ici, 100 signifie la taille originale.

L'exemple augmente les deux dimensions de 100 % à 125 % sur deux secondes. Utiliser des pourcentages égaux horizontalement et verticalement préserve les proportions de la forme ; des pourcentages différents étireraient une dimension davantage que l'autre.

```cpp
#include <DOM/Animation/BehaviorFactory.h>
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IScaleEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

auto effect = slide->get_Timeline()->get_MainSequence()->AddEffect(shape, EffectType::GrowShrink, EffectSubtype::None, EffectTriggerType::OnClick);
effect->get_Behaviors()->Clear();

auto factory = MakeObject<BehaviorFactory>();
auto scale = factory->CreateScaleEffect();
scale->set_From(PointF(100, 100));
scale->set_To(PointF(125, 125));
scale->get_Timing()->set_Duration(2.0f);

effect->get_Behaviors()->Add(scale);

presentation->Save(u"scale.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

### **Couleur**

Utilisez [CreateColorEffect]((https://reference.aspose.com/slides/fr/cpp/aspose.slides.animation/ibehaviorfactory/createcoloreffect/)) pour changer le remplissage du bleu à l'orange. [get_From]((https://reference.aspose.com/slides/fr/cpp/aspose.slides.animation/icoloreffect/get_from/)) et [get_To]((https://reference.aspose.com/slides/fr/cpp/aspose.slides.animation/icoloreffect/get_to/)) sont des couleurs ; [get_By]((https://reference.aspose.com/slides/fr/cpp/aspose.slides.animation/icoloreffect/get_by/)) est un décalage de couleur. [IBehavior::get_Properties]((https://reference.aspose.com/slides/fr/cpp/aspose.slides.animation/ibehavior/get_properties/)) identifie l’attribut animé.

Le remplissage plein de la forme est initialisé en bleu, correspondant à la couleur de départ de l'animation. Sélectionner l'attribut de couleur de remplissage indique au comportement quelle partie de la forme changer ; les points de couleur seuls n'identifient pas cet attribut. L'effet enregistré décrit une transition de deux secondes vers l'orange.

```cpp
#include <DOM/Animation/BehaviorFactory.h>
#include <DOM/Animation/BehaviorProperty.h>
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IBehaviorPropertyCollection.h>
#include <DOM/Animation/IColorEffect.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/FillType.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

auto effect = slide->get_Timeline()->get_MainSequence()->AddEffect(shape, EffectType::ChangeFillColor, EffectSubtype::None, EffectTriggerType::OnClick);
effect->get_Behaviors()->Clear();

auto factory = MakeObject<BehaviorFactory>();
auto color = factory->CreateColorEffect();
color->get_Properties()->Add(BehaviorProperty::get_FillColor()->get_Value());
color->get_From()->set_Color(Color::get_Blue());
color->get_To()->set_Color(Color::get_Orange());
color->get_Timing()->set_Duration(2.0f);

effect->get_Behaviors()->Add(color);

presentation->Save(u"color.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

### **Filtre**

Utilisez [CreateFilterEffect]((https://reference.aspose.com/slides/fr/cpp/aspose.slides.animation/ibehaviorfactory/createfiltereffect/)) pour sélectionner un fondu. [get_Type]((https://reference.aspose.com/slides/fr/cpp/aspose.slides.animation/ifiltereffect/get_type/)), [get_Subtype]((https://reference.aspose.com/slides/fr/cpp/aspose.slides.animation/ifiltereffect/get_subtype/)) et [get_Reveal]((https://reference.aspose.com/slides/fr/cpp/aspose.slides.animation/ifiltereffect/get_reveal/)) spécifient le filtre, la direction et s'il faut révéler ou masquer la forme.

Cet exemple configure un fondu de deux secondes qui révèle la forme en utilisant le sous‑type de direction vers la droite. Les paramètres du filtre appartiennent au comportement à l'intérieur de l'effet, ils sont donc configurés après la suppression des opérations originales du préréglage.

```cpp
#include <DOM/Animation/BehaviorFactory.h>
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/FilterEffectRevealType.h>
#include <DOM/Animation/FilterEffectSubtype.h>
#include <DOM/Animation/FilterEffectType.h>
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IFilterEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

auto effect = slide->get_Timeline()->get_MainSequence()->AddEffect(shape, EffectType::Wipe, EffectSubtype::None, EffectTriggerType::OnClick);
effect->get_Behaviors()->Clear();

auto factory = MakeObject<BehaviorFactory>();
auto filter = factory->CreateFilterEffect();
filter->set_Type(FilterEffectType::Wipe);
filter->set_Subtype(FilterEffectSubtype::Right);
filter->set_Reveal(FilterEffectRevealType::In);
filter->get_Timing()->set_Duration(2.0f);

effect->get_Behaviors()->Add(filter);

presentation->Save(u"filter.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

### **Propriété**

Utilisez [CreatePropertyEffect]((https://reference.aspose.com/slides/fr/cpp/aspose.slides.animation/ibehaviorfactory/createpropertyeffect/)) pour animer l'opacité. [get_From]((https://reference.aspose.com/slides/fr/cpp/aspose.slides.animation/ipropertyeffect/get_from/)), [get_To]((https://reference.aspose.com/slides/fr/cpp/aspose.slides.animation/ipropertyeffect/get_to/)) et [get_By]((https://reference.aspose.com/slides/fr/cpp/aspose.slides.animation/ipropertyeffect/get_by/)) sont des chaînes interprétées grâce à [get_ValueType]((https://reference.aspose.com/slides/fr/cpp/aspose.slides.animation/ipropertyeffect/get_valuetype/)) et [get_CalcMode]((https://reference.aspose.com/slides/fr/cpp/aspose.slides.animation/ipropertyeffect/get_calcmode/)). Choisissez des points d'extrémité ou un décalage relatif plutôt que de définir les trois simultanément.

Ici, l'attribut sélectionné est l'opacité, et les chaînes numériques représentent un passage de 25 % d'opacité à l'opacité maximale. L’interpolation linéaire décrit un changement progressif entre ces valeurs. En adaptant cet exemple à un autre attribut, choisissez un type de valeur et des valeurs d'extrémité adaptés à cet attribut.

```cpp
#include <DOM/Animation/BehaviorFactory.h>
#include <DOM/Animation/BehaviorProperty.h>
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IBehaviorPropertyCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IPropertyEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/Animation/PropertyCalcModeType.h>
#include <DOM/Animation/PropertyValueType.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

auto effect = slide->get_Timeline()->get_MainSequence()->AddEffect(shape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);
effect->get_Behaviors()->Clear();

auto factory = MakeObject<BehaviorFactory>();
auto property = factory->CreatePropertyEffect();
property->get_Properties()->Add(BehaviorProperty::get_StyleOpacity()->get_Value());
property->set_ValueType(PropertyValueType::Number);
property->set_CalcMode(PropertyCalcModeType::Linear);
property->set_From(u"0.25");
property->set_To(u"1");
property->get_Timing()->set_Duration(2.0f);

effect->get_Behaviors()->Add(property);

presentation->Save(u"property.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

### **Définir**

Utilisez [CreateSetEffect]((https://reference.aspose.com/slides/fr/cpp/aspose.slides.animation/ibehaviorfactory/createseteffect/)) pour attribuer la visibilité via [get_To]((https://reference.aspose.com/slides/fr/cpp/aspose.slides.animation/iseteffect/get_to/)). Un comportement de type set n’interpole pas entre les points d'extrémité.

L'exemple sélectionne l'attribut visibilité et assigne la chaîne `visible` lorsque le comportement s'exécute. En C++, encapsulez la chaîne dans un objet avant de l'assigner au comportement de type set. Le rectangle est déjà visible dans cette présentation minimale, donc l'assignation peut ne pas produire de changement visuel évident à elle seule. Une telle opération est utile dans le cadre d'un effet plus grand qui contrôle également le moment où la forme devient cachée ou visible.

```cpp
#include <DOM/Animation/BehaviorFactory.h>
#include <DOM/Animation/BehaviorProperty.h>
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IBehaviorPropertyCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ISetEffect.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

auto effect = slide->get_Timeline()->get_MainSequence()->AddEffect(shape, EffectType::Appear, EffectSubtype::None, EffectTriggerType::OnClick);
effect->get_Behaviors()->Clear();

auto factory = MakeObject<BehaviorFactory>();
auto set = factory->CreateSetEffect();
set->get_Properties()->Add(BehaviorProperty::get_StyleVisibility()->get_Value());
auto visibility = ObjectExt::Box<String>(u"visible");
set->set_To(visibility);

effect->get_Behaviors()->Add(set);

presentation->Save(u"set.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

### **Commande**

Utilisez [CreateCommandEffect]((https://reference.aspose.com/slides/fr/cpp/aspose.slides.animation/ibehaviorfactory/createcommandeffect/)) et configurez [get_Type]((https://reference.aspose.com/slides/fr/cpp/aspose.slides.animation/icommandeffect/get_type/)), [get_CommandString]((https://reference.aspose.com/slides/fr/cpp/aspose.slides.animation/icommandeffect/get_commandstring/)) et [get_ShapeTarget]((https://reference.aspose.com/slides/fr/cpp/aspose.slides.animation/icommandeffect/get_shapetarget/)). Placez un enregistrement WAV nommé `sample.wav` dans le répertoire de travail. Cet exemple l’intègre avec [AddAudioFrameEmbedded]((https://reference.aspose.com/slides/fr/cpp/aspose.slides/ishapecollection/addaudioframeembedded/)) et attache une commande de lecture au cadre audio.

Le cadre audio est à la fois la cible de l’effet et la cible de la commande. Cela relie la requête de lecture à l’enregistrement intégré ; une simple chaîne de commande n’identifie pas quel objet média contrôler. L'effet est configuré pour démarrer sur un clic pendant le diaporama.

```cpp
#include <DOM/Animation/BehaviorFactory.h>
#include <DOM/Animation/CommandEffectType.h>
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/ICommandEffect.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAudioFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
#include <system/io/file_stream.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto audioStream = IO::File::OpenRead(u"sample.wav");
auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(100, 100, 40, 40, audioStream);

auto effect = slide->get_Timeline()->get_MainSequence()->AddEffect(audioFrame, EffectType::MediaPlay, EffectSubtype::None, EffectTriggerType::OnClick);
effect->get_Behaviors()->Clear();

auto factory = MakeObject<BehaviorFactory>();
auto command = factory->CreateCommandEffect();
command->set_Type(CommandEffectType::Call);
command->set_CommandString(u"play");
command->set_ShapeTarget(audioFrame);

effect->get_Behaviors()->Add(command);

presentation->Save(u"command.pptx", SaveFormat::Pptx);

audioStream->Close();

presentation->Dispose();
```

L’enregistrement sauvegarde la commande dans `command.pptx` ; il ne lit pas l’enregistrement. La lecture nécessite un lecteur de diaporama qui prend en charge la commande et sa cible multimédia.

## **Gérer la collection de comportements**

[IBehaviorCollection]((https://reference.aspose.com/slides/fr/cpp/aspose.slides.animation/ibehaviorcollection/)) prend en charge [Add]((https://reference.aspose.com/slides/fr/cpp/aspose.slides.animation/ibehaviorcollection/add/)), [Insert]((https://reference.aspose.com/slides/fr/cpp/aspose.slides.animation/ibehaviorcollection/insert/)), [Remove]((https://reference.aspose.com/slides/fr/cpp/aspose.slides.animation/ibehaviorcollection/remove/)) et [RemoveAt]((https://reference.aspose.com/slides/fr/cpp/aspose.slides.animation/ibehaviorcollection/removeat/)). Cet exemple ouvre `rotation.pptx`, ajoute une mise à l’échelle, la déplace avant la rotation, et supprime la rotation. Supprimer et réinsérer le même objet change sa position stockée sans en faire une copie.

La séquence d’éditions transforme la collection de rotation–mise à l’échelle en mise à l’échelle–rotation, puis en uniquement mise à l’échelle. Les indices se réfèrent à la collection courante, ainsi la suppression utilise le nouvel indice de la rotation après le réordonnancement. L’énumération finale confirme quel comportement sera sauvegardé.

```cpp
#include <DOM/Animation/BehaviorFactory.h>
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IScaleEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/array.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"rotation.pptx");
auto effect = presentation->get_Slide(0)->get_Timeline()->get_MainSequence()->idx_get(0);
auto behaviors = effect->get_Behaviors();

auto factory = MakeObject<BehaviorFactory>();
auto scale = factory->CreateScaleEffect();
scale->set_To(PointF(125, 125));
scale->get_Timing()->set_Duration(2.0f);

behaviors->Add(scale);

behaviors->Remove(scale);
behaviors->Insert(0, scale);
behaviors->RemoveAt(1);

for (auto behavior : behaviors)
    Console::WriteLine(behavior->GetType().get_Name());

presentation->Save(u"collection-edited.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

Le résultat est `ScaleEffect` : seule la mise à l’échelle reste. L’ordre de la collection ne programme pas, à lui seul, les comportements les uns après les autres. Videz la collection uniquement lorsque vous remplacez toutes ses opérations.

## **Configurer le minutage des comportements**

[IBehavior::get_Timing]((https://reference.aspose.com/slides/fr/cpp/aspose.slides.animation/ibehavior/get_timing/)) expose [ITiming]((https://reference.aspose.com/slides/fr/cpp/aspose.slides.animation/itiming/)), indépendamment de [IEffect::get_Timing]((https://reference.aspose.com/slides/fr/cpp/aspose.slides.animation/ieffect/get_timing/)). Le minutage de l’effet planifie l’effet enveloppant ; le minutage du comportement décrit une opération à l’intérieur de celui‑ci.

### **Définir la durée, le délai, la répétition et l'accélération**

Ouvrez `rotation.pptx` et fixez [get_Duration]((https://reference.aspose.com/slides/fr/cpp/aspose.slides.animation/itiming/get_duration/)) et [get_TriggerDelayTime]((https://reference.aspose.com/slides/fr/cpp/aspose.slides.animation/itiming/get_triggerdelaytime/)) en secondes, puis configurez [get_RepeatCount]((https://reference.aspose.com/slides/fr/cpp/aspose.slides.animation/itiming/get_repeatcount/)). [get_Accelerate]((https://reference.aspose.com/slides/fr/cpp/aspose.slides.animation/itiming/get_accelerate/)) et [get_Decelerate]((https://reference.aspose.com/slides/fr/cpp/aspose.slides.animation/itiming/get_decelerate/)) sont des fractions de la durée ; gardez leur somme au maximum à 1.

Le fichier d’entrée est celui créé dans l’exemple de rotation, où le premier comportement est connu pour être une rotation. Cet exemple ne modifie que le minutage de ce comportement ; son angle de 90 degrés reste intact. Séparer l’angle et le minutage facilite l’ajustement du rythme sans reconstruire l’animation.

```cpp
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IRotationEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"rotation.pptx");
auto effect = presentation->get_Slide(0)->get_Timeline()->get_MainSequence()->idx_get(0);

auto rotation = ExplicitCast<IRotationEffect>(effect->get_Behaviors()->idx_get(0));
rotation->get_Timing()->set_Duration(2.0f);
rotation->get_Timing()->set_TriggerDelayTime(0.5f);
rotation->get_Timing()->set_RepeatCount(3.0f);
rotation->get_Timing()->set_Accelerate(0.2f);
rotation->get_Timing()->set_Decelerate(0.2f);

presentation->Save(u"timing.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

Le comportement utilise une durée de deux secondes, un délai de 0,5 s et un nombre de répétitions de 3. Les 20 % initiaux et finaux de sa durée servent à l’accélération et à la décélération.

D’autres politiques de répétition incluent [get_RepeatDuration]((https://reference.aspose.com/slides/fr/cpp/aspose.slides.animation/itiming/get_repeatduration/)), [get_RepeatUntilEndSlide]((https://reference.aspose.com/slides/fr/cpp/aspose.slides.animation/itiming/get_repeatuntilendslide/)) et [get_RepeatUntilNextClick]((https://reference.aspose.com/slides/fr/cpp/aspose.slides.animation/itiming/get_repeatuntilnextclick/)) ; choisissez-en une plutôt que de les activer toutes. [get_AutoReverse]((https://reference.aspose.com/slides/fr/cpp/aspose.slides.animation/itiming/get_autoreverse/)) lit l’animation à l’envers après le passage en avant. L’accélération et la décélération s’appliquent aux changements continus, pas aux assignations discrètes ou aux commandes.

## **Construire un chemin de mouvement**

Utilisez [CreateMotionEffect]((https://reference.aspose.com/slides/fr/cpp/aspose.slides.animation/ibehaviorfactory/createmotioneffect/)) pour créer un mouvement. Ses [get_From]((https://reference.aspose.com/slides/fr/cpp/aspose.slides.animation/imotioneffect/get_from/)), [get_To]((https://reference.aspose.com/slides/fr/cpp/aspose.slides.animation/imotioneffect/get_to/)) et [get_By]((https://reference.aspose.com/slides/fr/cpp/aspose.slides.animation/imotioneffect/get_by/)) décrivent des coordonnées ou des décalages basés sur des pourcentages. Pour une trajectoire éditable, créez un [MotionPath]((https://reference.aspose.com/slides/fr/cpp/aspose.slides.animation/motionpath/)) et assignez‑le à [IMotionEffect::get_Path]((https://reference.aspose.com/slides/fr/cpp/aspose.slides.animation/imotioneffect/get_path/)). [IMotionPath]((https://reference.aspose.com/slides/fr/cpp/aspose.slides.animation/imotionpath/)) stocke les commandes du chemin.

[MotionCommandPathType]((https://reference.aspose.com/slides/fr/cpp/aspose.slides.animation/motioncommandpathtype/)) sélectionne l’opération :

| Commande | Points | Signification |
| --- | --- | --- |
| MoveTo | One | Set the starting position. |
| LineTo | One | Move along a straight segment to its endpoint. |
| CurveTo | Three | Follow a cubic curve defined by two control points and an endpoint. |
| CloseLoop | None | Return to the starting position. |
| End | None | Finish the path. |

[MotionPathPointsType]((https://reference.aspose.com/slides/fr/cpp/aspose.slides.animation/motionpathpointstype/)) décrit les caractéristiques de l’édition des points, comme les coins ou les points lisses. Il ne remplace pas le type de commande. Utilisez un type de point de courbe pour l’exemple de courbe ci‑dessous, et un type de point de coin pour les segments droits.

Les coordonnées du chemin sont normalisées aux dimensions de la diapositive : un déplacement X de 0,25 représente un quart de la largeur de la diapositive, pas 0,25 points. L’axe Y positif descend. Les commandes absolues spécifient des positions dans le système de coordonnées du chemin ; les commandes relatives spécifient des décalages depuis la position courante. Cela est distinct de [get_Origin]((https://reference.aspose.com/slides/fr/cpp/aspose.slides.animation/imotioneffect/get_origin/)), qui sélectionne le cadre de référence du chemin, et de [get_PathEditMode]((https://reference.aspose.com/slides/fr/cpp/aspose.slides.animation/imotioneffect/get_patheditmode/)), qui contrôle comment le chemin se déplace lorsque la forme est déplacée.

### **Créer un chemin droit**

Créez un comportement de mouvement avec un point de départ, un segment droit, et une commande de fin. [IMotionPath::Add]((https://reference.aspose.com/slides/fr/cpp/aspose.slides.animation/imotionpath/add/)) prend le type de commande, ses points, le type de point, et un indicateur de coordonnées relatives.

La commande de départ établit (0, 0), et la ligne se termine à (0.25, 0), donnant au trajet un déplacement horizontal d’un quart de la largeur de la diapositive. La commande de fin n’a aucun point de coordonnées. Une fois le chemin assigné, ajouter le comportement de mouvement à l’effet relie ce trajet au rectangle.

```cpp
#include <DOM/Animation/BehaviorFactory.h>
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IMotionCmdPath.h>
#include <DOM/Animation/IMotionEffect.h>
#include <DOM/Animation/IMotionPath.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/Animation/MotionCommandPathType.h>
#include <DOM/Animation/MotionOriginType.h>
#include <DOM/Animation/MotionPath.h>
#include <DOM/Animation/MotionPathPointsType.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

auto effect = slide->get_Timeline()->get_MainSequence()->AddEffect(shape, EffectType::PathRight, EffectSubtype::None, EffectTriggerType::OnClick);
effect->get_Behaviors()->Clear();

auto factory = MakeObject<BehaviorFactory>();
auto motion = factory->CreateMotionEffect();
motion->set_Origin(MotionOriginType::Layout);
motion->get_Timing()->set_Duration(2.0f);

auto path = MakeObject<MotionPath>();
auto startPoints = MakeArray<PointF>({ PointF(0, 0) });
path->Add(MotionCommandPathType::MoveTo, startPoints, MotionPathPointsType::Auto, false);
auto linePoints = MakeArray<PointF>({ PointF(0.25f, 0) });
path->Add(MotionCommandPathType::LineTo, linePoints, MotionPathPointsType::Corner, false);
auto endPoints = MakeArray<PointF>(0);
path->Add(MotionCommandPathType::End, endPoints, MotionPathPointsType::None, false);

motion->set_Path(path);
effect->get_Behaviors()->Add(motion);

presentation->Save(u"motion.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

`motion.pptx` contient un comportement de mouvement avec trois commandes de chemin. Les exemples d’édition de fichier suivants utilisent cette structure connue.

### **Comparer les coordonnées absolues et relatives**

Ces deux objets de chemin décrivent le même trajet. La commande absolue se termine à (0.3, 0.1) ; la commande relative ajoute (0.1, 0.1) à la position courante, (0.2, 0).

Les deux chemins partent de la même position. Pour la ligne relative, ajoutez ses décalages X et Y à la position courante pour obtenir le point d’arrivée ; pour la ligne absolue, lisez directement le point d’arrivée. Inverser le drapeau sans convertir les coordonnées décrirait un trajet différent.

```cpp
#include <DOM/Animation/IMotionCmdPath.h>
#include <DOM/Animation/IMotionPath.h>
#include <DOM/Animation/MotionCommandPathType.h>
#include <DOM/Animation/MotionPath.h>
#include <DOM/Animation/MotionPathPointsType.h>
#include <drawing/point_f.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace System;
using namespace System::Drawing;

auto absolutePath = MakeObject<MotionPath>();
auto startPoints = MakeArray<PointF>({ PointF(0.2f, 0) });
absolutePath->Add(MotionCommandPathType::MoveTo, startPoints, MotionPathPointsType::Auto, false);
auto absoluteEndPoints = MakeArray<PointF>({ PointF(0.3f, 0.1f) });
absolutePath->Add(MotionCommandPathType::LineTo, absoluteEndPoints, MotionPathPointsType::Corner, false);

auto relativePath = MakeObject<MotionPath>();
auto relativeStartPoints = MakeArray<PointF>({ PointF(0.2f, 0) });
relativePath->Add(MotionCommandPathType::MoveTo, relativeStartPoints, MotionPathPointsType::Auto, false);
auto relativeOffsets = MakeArray<PointF>({ PointF(0.1f, 0.1f) });
relativePath->Add(MotionCommandPathType::LineTo, relativeOffsets, MotionPathPointsType::Corner, true);
```

Attribuez l’un ou l’autre chemin à un comportement de mouvement pour l’utiliser dans une présentation. Le dernier argument booléen sélectionne les coordonnées relatives pour cette commande.

### **Remplacer une ligne par une courbe**

Ouvrez `motion.pptx` et remplacez sa commande de ligne par une courbe cubique. Fournissez d’abord les deux points de contrôle, puis le point d’arrivée.

La position de départ est fournie par la commande précédente. Les deux premiers points façonnent la courbe, le troisième en est la destination ; ils ne sont pas trois destinations successives. Mettre à jour simultanément le type de commande, le type d’édition des points et le tableau de points maintient le segment cohérent avec sa nouvelle géométrie.

```cpp
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IMotionCmdPath.h>
#include <DOM/Animation/IMotionEffect.h>
#include <DOM/Animation/IMotionPath.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/MotionCommandPathType.h>
#include <DOM/Animation/MotionPathPointsType.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/array.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"motion.pptx");
auto effect = presentation->get_Slide(0)->get_Timeline()->get_MainSequence()->idx_get(0);
auto motion = ExplicitCast<IMotionEffect>(effect->get_Behaviors()->idx_get(0));

auto path = motion->get_Path();
path->idx_get(1)->set_CommandType(MotionCommandPathType::CurveTo);
path->idx_get(1)->set_PointsType(MotionPathPointsType::CurveSmooth);
auto curvePoints = MakeArray<PointF>({ PointF(0.1f, 0), PointF(0.2f, 0.1f), PointF(0.3f, 0.1f) });
path->idx_get(1)->set_Points(curvePoints);

presentation->Save(u"curve.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

Le chemin dans `curve.pptx` possède toujours trois commandes ; sa commande du milieu définit maintenant une courbe.

## **Inspecter et modifier un chemin enregistré**

Chaque [IMotionCmdPath]((https://reference.aspose.com/slides/fr/cpp/aspose.slides.animation/imotioncmdpath/)) expose [get_Points]((https://reference.aspose.com/slides/fr/cpp/aspose.slides.animation/imotioncmdpath/get_points/)), [get_CommandType]((https://reference.aspose.com/slides/fr/cpp/aspose.slides.animation/imotioncmdpath/get_commandtype/)), [get_PointsType]((https://reference.aspose.com/slides/fr/cpp/aspose.slides.animation/imotioncmdpath/get_pointstype/)) et [get_IsRelative]((https://reference.aspose.com/slides/fr/cpp/aspose.slides.animation/imotioncmdpath/get_isrelative/)). Les exemples suivants utilisent le chemin à trois commandes connu dans `motion.pptx`. Pour une entrée arbitraire, localisez l’effet souhaité et vérifiez les types de commande et le nombre de points avant d’éditer par indice.

### **Lire les commandes et les coordonnées**

Lisez le chemin sans le modifier. Les commandes End et CloseLoop ne nécessitent aucun point, prévoyez donc un tableau de points nul.

La sortie associe chaque commande à son drapeau de coordonnées relatives avant d’énumérer ses points. Cela vous permet de distinguer un point d’arrivée d’un décalage avant de modifier le chemin. Une courbe listerait trois points, alors que la ligne droite de ce fichier n’en liste qu’un.

```cpp
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IMotionCmdPath.h>
#include <DOM/Animation/IMotionEffect.h>
#include <DOM/Animation/IMotionPath.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/MotionCommandPathType.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <drawing/point_f.h>
#include <system/array.h>
#include <system/console.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace System;

auto presentation = MakeObject<Presentation>(u"motion.pptx");
auto effect = presentation->get_Slide(0)->get_Timeline()->get_MainSequence()->idx_get(0);
auto motion = ExplicitCast<IMotionEffect>(effect->get_Behaviors()->idx_get(0));

auto path = motion->get_Path();
for (auto segment : path)
{
    Console::WriteLine(u"{0}, relative: {1}", segment->get_CommandType(), segment->get_IsRelative());
    if (segment->get_Points() != nullptr)
        for (auto point : segment->get_Points())
            Console::WriteLine(u"X={0}, Y={1}", point.get_X(), point.get_Y());
}

presentation->Dispose();
```

Le listing contient un point de départ, une ligne absolue se terminant à (0.25, 0), et une commande End.

### **Modifier un point final**

Ouvrez `motion.pptx` et remplacez le tableau de points de la ligne pour déplacer son point d’arrivée.

Dans le fichier d’entrée, l’indice 0 correspond à la commande de départ et l’indice 1 à la ligne. Remplacer le seul point de la ligne change sa destination sans toucher son type de commande, son minutage ou sa position dans la collection. Parce que la commande utilise des coordonnées absolues, la nouvelle paire spécifie une position plutôt qu’un simple décalage ajouté.

```cpp
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IMotionCmdPath.h>
#include <DOM/Animation/IMotionEffect.h>
#include <DOM/Animation/IMotionPath.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/array.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"motion.pptx");
auto effect = presentation->get_Slide(0)->get_Timeline()->get_MainSequence()->idx_get(0);

auto motion = ExplicitCast<IMotionEffect>(effect->get_Behaviors()->idx_get(0));
auto endpointPoints = MakeArray<PointF>({ PointF(0.4f, 0.1f) });
motion->get_Path()->idx_get(1)->set_Points(endpointPoints);

presentation->Save(u"motion-endpoint.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

La ligne dans `motion-endpoint.pptx` se termine à (0.4, 0.1) ; le fichier original reste inchangé.

### **Remplacer un segment**

Utilisez [Insert]((https://reference.aspose.com/slides/fr/cpp/aspose.slides.animation/imotionpath/insert/)) et [RemoveAt]((https://reference.aspose.com/slides/fr/cpp/aspose.slides.animation/imotionpath/removeat/)) pour remplacer la ligne dans `motion.pptx`. L’insertion décale l’ancienne ligne à l’indice 2.

Cela montre le remplacement d’un objet commande plutôt que l’édition de ses coordonnées existantes. Après insertion, la collection contient temporairement la commande de départ, la nouvelle ligne, l’ancienne ligne, et la commande End. Supprimer l’indice 2 élimine l’ancienne ligne et laisse le nouveau trajet en place.

```cpp
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IMotionCmdPath.h>
#include <DOM/Animation/IMotionEffect.h>
#include <DOM/Animation/IMotionPath.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/MotionCommandPathType.h>
#include <DOM/Animation/MotionPathPointsType.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/array.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"motion.pptx");
auto effect = presentation->get_Slide(0)->get_Timeline()->get_MainSequence()->idx_get(0);
auto motion = ExplicitCast<IMotionEffect>(effect->get_Behaviors()->idx_get(0));

auto path = motion->get_Path();
auto linePoints = MakeArray<PointF>({ PointF(0.2f, 0.1f) });
path->Insert(1, MotionCommandPathType::LineTo, linePoints, MotionPathPointsType::Corner, false);
path->RemoveAt(2);

presentation->Save(u"motion-edited.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

Le chemin enregistré possède toujours trois commandes, la nouvelle ligne se terminant à (0.2, 0.1) et la commande End en dernier.

## **Modifier et vérifier un comportement existant**

Lorsque l’indice du comportement est inconnu, sélectionnez‑le par type. Cet exemple ouvre `rotation.pptx`, trouve son [IRotationEffect]((https://reference.aspose.com/slides/fr/cpp/aspose.slides.animation/irotationeffect/)), change l’angle, et vérifie la valeur sauvegardée après réouverture.

Le contrôle de type permet à la boucle d’ignorer les comportements qui ne sont pas des rotations. Le second chargement lit le fichier sauvegardé dans un objet présentation distinct, ainsi la comparaison porte sur les données persistées plutôt que sur la valeur encore en mémoire. Cet exemple suppose toujours que l’effet connu est le premier de la séquence principale ; sélectionner un comportement par type ne localise pas forcément le bon effet dans une présentation arbitraire.

```cpp
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IRotationEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <cmath>
#include <system/console.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"rotation.pptx");
auto effect = presentation->get_Slide(0)->get_Timeline()->get_MainSequence()->idx_get(0);

for (auto behavior : effect->get_Behaviors())
{
    auto rotation = DynamicCast<IRotationEffect>(behavior);
    if (rotation != nullptr)
        rotation->set_By(180.0f);
}

presentation->Save(u"rotation-edited.pptx", SaveFormat::Pptx);

auto reopened = MakeObject<Presentation>(u"rotation-edited.pptx");
auto savedEffect = reopened->get_Slide(0)->get_Timeline()->get_MainSequence()->idx_get(0);

for (auto behavior : savedEffect->get_Behaviors())
{
    auto rotation = DynamicCast<IRotationEffect>(behavior);
    if (rotation != nullptr)
        Console::WriteLine(u"Rotation preserved: {0}", std::abs(rotation->get_By() - 180.0f) < 0.001f);
}

presentation->Dispose();
reopened->Dispose();
```

Le résultat est `Rotation preserved: True`. Appliquez le même modèle de vérification par type aux autres comportements. Pour une vérification complète de la préservation, comparez la forme cible, l’effet, les types et l’ordre des comportements, le minutage et les commandes du chemin. Utilisez une tolérance numérique pour les valeurs à virgule flottante. Pour une présentation dont la disposition d’animation est inconnue, consultez [Lire les animations de forme](/slides/fr/cpp/shape-animation/#read-shape-animations) pour parcourir les séquences principales et interactives.

## **Ordre des comportements, préréglages et lecture**

L’ordre dans [IBehaviorCollection]((https://reference.aspose.com/slides/fr/cpp/aspose.slides.animation/ibehaviorcollection/)) correspond à l’ordre stocké des opérations d’un effet. Ce n’est pas une playlist où chaque comportement attend automatiquement le précédent. Le minutage et l’effet enveloppant déterminent la planification. Les comportements peuvent se chevaucher, et les opérations sur la même propriété peuvent interagir via [get_Additive]((https://reference.aspose.com/slides/fr/cpp/aspose.slides.animation/ibehavior/get_additive/)) et [get_Accumulate]((https://reference.aspose.com/slides/fr/cpp/aspose.slides.animation/ibehavior/get_accumulate/)). N’utilisez pas uniquement le réordonnancement de la collection pour planifier « déplacer, puis pivoter » ; utilisez un minutage explicite ou des effets séparés comme décrit dans [Animation de forme](/slides/fr/cpp/shape-animation/).

Le [get_Type]((https://reference.aspose.com/slides/fr/cpp/aspose.slides.animation/ieffect/get_type/)) et le [get_Subtype]((https://reference.aspose.com/slides/fr/cpp/aspose.slides.animation/ieffect/get_subtype/)) de l’effet décrivent son préréglage. Ils ne constituent pas une description complète d’un arbre de comportements modifié. Choisissez le préréglage et le sous‑type avant de personnaliser les comportements : changer le préréglage peut reconstruire la collection et supprimer vos opérations personnalisées. Par exemple, passer d’un effet Spin personnalisé à Fade peut remplacer le comportement de rotation par des comportements set et filter. Inspectez à nouveau la collection après avoir changé un préréglage ou un sous‑type. Vider les comportements du préréglage peut aussi supprimer les opérations de visibilité ou d’initialisation que le préréglage nécessite. Les exemples utilisent volontairement des formes visibles et remplacent les comportements ; ils ne reconstruisent pas l’implémentation de chaque préréglage.

## **Compatibilité des formats**

Un arbre de comportements préservé ne garantit pas une lecture identique dans tous les lecteurs ou moteurs d’exportation. Vérifiez les données enregistrées et la sortie rendue séparément.

| Format ou sortie | Ce qu'il faut vérifier |
| --- | --- |
| PPTX | Utilisez ce format comme principal pour ces exemples. Rouvrez‑le pour vérifier l’arbre de comportements éditable, puis testez la lecture dans la version PowerPoint visée. |
| PPT | La représentation binaire héritée peut différer de PPTX. Effectuez un cycle sauvegarde‑réouverture séparé et testez la lecture ; ne déduisez pas la prise en charge de chaque combinaison personnalisée à partir d’un résultat PPTX réussi. |
| PDF, PNG, JPEG et autres images de diapositive statiques | Contiennent une représentation statique de la diapositive, pas de chronologie d’animation jouable ni d’image‑clé finale garantie. |
| [HTML5](/slides/fr/cpp/export-to-html5/) | Peut lire les animations prises en charge lorsque l’animation de forme est activée dans les options d’exportation. Testez les combinaisons personnalisées dans le navigateur. |
| [GIF animé](/slides/fr/cpp/convert-powerpoint-to-animated-gif/) | Stocke les images rendues, pas les comportements éditables ni les interactions déclenchées par un clic. Vérifiez le mouvement réellement rendu. |
| [Vidéo](/slides/fr/cpp/convert-powerpoint-to-video/) | Rend les images d’animation et les encode en vidéo. Le support est limité aux [animations et effets pris en charge](/slides/fr/cpp/convert-powerpoint-to-video/#supported-animations-and-effects) du moteur de rendu ; les commandes et événements interactifs ne deviennent pas une chronologie éditable. |

## **FAQ**

**Pourquoi mon effet contient‑il des comportements avant que j’en ajoute ?**  
Créer un effet prédéfini peut générer ses opérations sous‑jacentes. Inspectez‑les avant de décider d’étendre le préréglage ou de remplacer ses comportements.

**Déplacer un comportement au début le fait‑il jouer en premier ?**  
Pas nécessairement. L’ordre de la collection ne remplace pas le minutage. Vérifiez les délais, durées et interactions entre les opérations sur la même propriété.

**Pourquoi une commande End n’a‑t‑elle aucun point ?**  
Elle marque la fin du chemin et n’a pas besoin de coordonnées. Lors de l’inspection d’un chemin lu depuis un fichier, vérifiez un tableau de points nul.

**Un aller‑retour réussi suffit‑il à confirmer la lecture ?**  
Non. La réouverture confirme la préservation des propriétés vérifiées. Testez séparément le lecteur de diaporama ou l’export animé pour confirmer le comportement visuel.