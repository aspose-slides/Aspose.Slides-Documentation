---
title: Erstellen und Ändern benutzerdefinierter Animationsverhaltensweisen in C++
linktitle: Benutzerdefinierte Animation
type: docs
weight: 151
url: /de/cpp/custom-animation/
keywords:
- benutzerdefinierte Animation
- Animationsverhalten
- Bewegungspfad
- PowerPoint
- Präsentation
- C++
- Aspose.Slides
description: "Erstellen, inspizieren und ändern Sie benutzerdefinierte Animationsverhaltensweisen und editierbare Bewegungspfade in PowerPoint-Präsentationen mit Aspose.Slides für C++."
---
## **Übersicht**

Benutzerdefinierte Animations‑Verhaltensweisen ermöglichen die Steuerung einzelner Vorgänge innerhalb eines Animationseffekts, z. B. das Ändern einer Farbe, das Drehen einer Form oder das Verfolgen eines editierbaren Bewegungspfads. Dieses Handbuch zeigt, wie Verhaltensweisen erstellt und kombiniert, ihr Timing konfiguriert, vorhandene Animationen inspiziert und geändert sowie überprüft werden, dass ihre Eigenschaften das Speichern und erneute Öffnen einer Präsentation überstehen.

Für vordefinierte Effekte und Klick‑Trigger siehe [Shape Animation](/slides/de/cpp/shape-animation/).

## **Verstehen des Animationsmodells**

Eine Animation ist strukturiert als **Timeline → Sequence → Effect → Behaviors**:

- Der Folien‑[get_Timeline](https://reference.aspose.com/slides/de/cpp/aspose.slides/ibaseslide/get_timeline/) enthält die Hauptsequenz und interaktive Sequenzen.
- Eine [ISequence](https://reference.aspose.com/slides/de/cpp/aspose.slides.animation/isequence/) enthält Effekte, die möglicherweise unterschiedliche Formen ansprechen.
- Ein [IEffect](https://reference.aspose.com/slides/de/cpp/aspose.slides.animation/ieffect/) identifiziert Ziel‑Form, Vorgabe, Untertyp und Timing des Effekts.
- [IEffect::get_Behaviors](https://reference.aspose.com/slides/de/cpp/aspose.slides.animation/ieffect/get_behaviors/) enthält die Vorgänge, die den Effekt umsetzen: Farbe ändern, Verschieben, Drehen, Eigenschaft setzen usw.

## **Einzelne Verhaltensweisen erstellen**

Rufen Sie [ISequence::AddEffect](https://reference.aspose.com/slides/de/cpp/aspose.slides.animation/isequence/addeffect/) auf, um einen Effekt zu erzeugen und seine [get_Behaviors](https://reference.aspose.com/slides/de/cpp/aspose.slides.animation/ieffect/get_behaviors/)‑Sammlung zu erhalten. Eine Vorgabe kann diese Sammlung automatisch füllen. Behalten Sie ihre Vorgänge bei, wenn Sie die Vorgabe erweitern, oder verwenden Sie [Clear](https://reference.aspose.com/slides/de/cpp/aspose.slides.animation/ibehaviorcollection/clear/), wenn Sie sie bewusst ersetzen.

[IBehaviorFactory](https://reference.aspose.com/slides/de/cpp/aspose.slides.animation/ibehaviorfactory/) erzeugt die acht im Folgenden illustrierten Verhaltens­typen. Bewegung wird in [Build a Motion Path](#build-a-motion-path) behandelt. Jeder Erstellungs‑Beispielcode ist eigenständig und kann innerhalb einer Funktion ausgeführt werden; spätere Bearbeitungs‑Beispiele geben an, welche Ausgabedatei sie verwenden.

### **Drehung**

Verwenden Sie [CreateRotationEffect](https://reference.aspose.com/slides/de/cpp/aspose.slides.animation/ibehaviorfactory/createrotationeffect/), um eine Drehung zu erzeugen. [get_By](https://reference.aspose.com/slides/de/cpp/aspose.slides.animation/irotationeffect/get_by/) gibt einen relativen Winkel in Grad an; [get_From](https://reference.aspose.com/slides/de/cpp/aspose.slides.animation/irotationeffect/get_from/) und [get_To](https://reference.aspose.com/slides/de/cpp/aspose.slides.animation/irotationeffect/get_to/) geben Endpunkte an.

Das Beispiel beginnt mit einem Spin‑Effekt, ersetzt seine Vorgabevorgänge durch ein Dreh‑Verhalten und gibt diesem Vorgang eine Dauer von zwei Sekunden. Ein relativer Winkel von 90 Grad entspricht einer Vierteldrehung von der Ausgangsausrichtung der Form, sodass kein expliziter Startwinkel benötigt wird.

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

`rotation.pptx` enthält eine Form und ein Dreh‑Verhalten. Die nachfolgenden Beispiele für Sammlung, Timing und Dreh‑Bearbeitung verwenden diese Datei.

### **Skalierung**

Verwenden Sie [CreateScaleEffect](https://reference.aspose.com/slides/de/cpp/aspose.slides.animation/ibehaviorfactory/createscaleeffect/) mit X/Y‑Prozentwerten: [get_From](https://reference.aspose.com/slides/de/cpp/aspose.slides.animation/iscaleeffect/get_from/) und [get_To](https://reference.aspose.com/slides/de/cpp/aspose.slides.animation/iscaleeffect/get_to/) beschreiben die Anfangs‑ bzw. Endgröße, während [get_By](https://reference.aspose.com/slides/de/cpp/aspose.slides.animation/iscaleeffect/get_by/) einen relativen Wechsel angibt. Hier bedeutet 100 % die Originalgröße.

Das Beispiel vergrößert beide Dimensionen von 100 % auf 125 % über zwei Sekunden. Gleiche horizontale und vertikale Prozentwerte erhalten das Seitenverhältnis der Form; unterschiedliche Werte würden eine Dimension stärker strecken als die andere.

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

### **Farbe**

Verwenden Sie [CreateColorEffect](https://reference.aspose.com/slides/de/cpp/aspose.slides.animation/ibehaviorfactory/createcoloreffect/), um die Füllung von Blau zu Orange zu ändern. [get_From](https://reference.aspose.com/slides/de/cpp/aspose.slides.animation/icoloreffect/get_from/) und [get_To](https://reference.aspose.com/slides/de/cpp/aspose.slides.animation/icoloreffect/get_to/) sind Farben; [get_By](https://reference.aspose.com/slides/de/cpp/aspose.slides.animation/icoloreffect/get_by/) ist ein Farboffset. [IBehavior::get_Properties](https://reference.aspose.com/slides/de/cpp/aspose.slides.animation/ibehavior/get_properties/) identifiziert das animierte Attribut.

Die feste Füllung der Form wird initial auf Blau gesetzt, passend zur Ausgangsfarbe der Animation. Die Auswahl des Füll‑Farbe‑Attributs sagt dem Verhalten, welchen Teil der Form es ändern soll; die Farbeingänge allein identifizieren das Attribut nicht. Der gespeicherte Effekt beschreibt einen zweisekündigen Übergang zu Orange.

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

### **Filter**

Verwenden Sie [CreateFilterEffect](https://reference.aspose.com/slides/de/cpp/aspose.slides.animation/ibehaviorfactory/createfiltereffect/), um eine Wisch‑Animation auszuwählen. [get_Type](https://reference.aspose.com/slides/de/cpp/aspose.slides.animation/ifiltereffect/get_type/), [get_Subtype](https://reference.aspose.com/slides/de/cpp/aspose.slides.animation/ifiltereffect/get_subtype/) und [get_Reveal](https://reference.aspose.com/slides/de/cpp/aspose.slides.animation/ifiltereffect/get_reveal/) geben Filter, Richtung und ob die Form angezeigt oder verborgen werden soll, an.

Dieses Beispiel konfiguriert ein zweisekündiges Wischen, das die Form mit dem rechten‑Richtungs‑Subtype enthüllt. Die Filtereinstellungen gehören zum Verhalten innerhalb des Effekts und werden nach dem Entfernen der ursprünglichen Vorgabevorgänge konfiguriert.

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

### **Eigenschaft**

Verwenden Sie [CreatePropertyEffect](https://reference.aspose.com/slides/de/cpp/aspose.slides.animation/ibehaviorfactory/createpropertyeffect/), um die Opazität zu animieren. [get_From](https://reference.aspose.com/slides/de/cpp/aspose.slides.animation/ipropertyeffect/get_from/), [get_To](https://reference.aspose.com/slides/de/cpp/aspose.slides.animation/ipropertyeffect/get_to/) und [get_By](https://reference.aspose.com/slides/de/cpp/aspose.slides.animation/ipropertyeffect/get_by/) sind Zeichenketten, die über [get_ValueType](https://reference.aspose.com/slides/de/cpp/aspose.slides.animation/ipropertyeffect/get_valuetype/) und [get_CalcMode](https://reference.aspose.com/slides/de/cpp/aspose.slides.animation/ipropertyeffect/get_calcmode/) interpretiert werden. Verwenden Sie Endpunkte oder einen relativen Offset, anstatt alle drei ununterscheidet zu setzen.

Hier ist das ausgewählte Attribut Opazität, und die numerischen Zeichenketten beschreiben eine Änderung von 25 % Opazität zu voller Opazität. Lineare Interpolation beschreibt eine allmähliche Änderung zwischen diesen Werten. Beim Anpassen dieses Beispiels an ein anderes Attribut wählen Sie einen passenden Werttyp und passende Endpunktwerte für dieses Attribut.

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

### **Setzen**

Verwenden Sie [CreateSetEffect](https://reference.aspose.com/slides/de/cpp/aspose.slides.animation/ibehaviorfactory/createseteffect/), um die Sichtbarkeit über [get_To](https://reference.aspose.com/slides/de/cpp/aspose.slides.animation/iseteffect/get_to/) zuzuweisen. Ein Set‑Verhalten interpoliert nicht zwischen Endpunkten.

Das Beispiel wählt das Sichtbarkeits‑Attribut und weist den String `visible` zu, wenn das Verhalten ausgeführt wird. In C++ packen Sie den String in ein Objekt, bevor Sie ihn dem Set‑Verhalten zuweisen. Das Rechteck ist in dieser Minimalpräsentation bereits sichtbar, sodass die Zuweisung allein keine offensichtliche visuelle Änderung erzeugt. Eine solche Operation ist nützlich als Teil eines größeren Effekts, der ebenfalls steuert, wann die Form verborgen oder sichtbar wird.

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

### **Befehl**

Verwenden Sie [CreateCommandEffect](https://reference.aspose.com/slides/de/cpp/aspose.slides.animation/ibehaviorfactory/createcommandeffect/) und konfigurieren Sie [get_Type](https://reference.aspose.com/slides/de/cpp/aspose.slides.animation/icommandeffect/get_type/), [get_CommandString](https://reference.aspose.com/slides/de/cpp/aspose.slides.animation/icommandeffect/get_commandstring/) und [get_ShapeTarget](https://reference.aspose.com/slides/de/cpp/aspose.slides.animation/icommandeffect/get_shapetarget/). Legen Sie eine WAV‑Aufnahme namens `sample.wav` im Arbeitsverzeichnis ab. Dieses Beispiel bettet sie mit [AddAudioFrameEmbedded](https://reference.aspose.com/slides/de/cpp/aspose.slides/ishapecollection/addaudioframeembedded/) ein und fügt dem Audio‑Frame einen Play‑Befehl hinzu.

Der Audio‑Frame ist sowohl Ziel des Effekts als auch Ziel des Befehls. Dadurch wird die Abspielanforderung mit der eingebetteten Aufnahme verbunden; ein reiner Befehls‑String identifiziert nicht, welches Medienobjekt zu steuern ist. Der Effekt ist so konfiguriert, dass er beim Klick während der Bildschirmpräsentation startet.

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

Das Speichern legt den Befehl in `command.pptx` ab; es spielt die Aufnahme nicht ab. Die Wiedergabe erfordert einen Präsentations‑Player, der den Befehl und sein Medien‑Ziel unterstützt.

## **Verwalten der Verhaltens‑Sammlung**

[IBehaviorCollection](https://reference.aspose.com/slides/de/cpp/aspose.slides.animation/ibehaviorcollection/) unterstützt [Add](https://reference.aspose.com/slides/de/cpp/aspose.slides.animation/ibehaviorcollection/add/), [Insert](https://reference.aspose.com/slides/de/cpp/aspose.slides.animation/ibehaviorcollection/insert/), [Remove](https://reference.aspose.com/slides/de/cpp/aspose.slides.animation/ibehaviorcollection/remove/) und [RemoveAt](https://reference.aspose.com/slides/de/cpp/aspose.slides.animation/ibehaviorcollection/removeat/). Dieses Beispiel öffnet `rotation.pptx`, fügt Skalierung hinzu, verschiebt sie vor die Drehung und entfernt die Drehung. Das Entfernen und erneute Einfügen desselben Objekts ändert seine gespeicherte Position, ohne eine Kopie zu erzeugen.

Die Bearbeitungssequenz ändert die Sammlung von Drehung‑Skalierung zu Skalierung‑Drehung und schließlich zu nur Skalierung. Indizes beziehen sich auf die aktuelle Sammlung, sodass die Entfernung den neuen Index der Drehung nach der Neuordnung verwendet. Die abschließende Aufzählung bestätigt, welches Verhalten gespeichert wird.

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

Die Ausgabe ist `ScaleEffect`: nur Skalierung bleibt erhalten. Die Reihenfolge der Sammlung bestimmt nicht von sich aus, dass Verhaltensweisen nacheinander abgespielt werden. Leeren Sie die Sammlung nur, wenn Sie alle Vorgänge ersetzen wollen.

## **Timing der Verhaltensweise konfigurieren**

[IBehavior::get_Timing](https://reference.aspose.com/slides/de/cpp/aspose.slides.animation/ibehavior/get_timing/) gibt ein [ITiming](https://reference.aspose.com/slides/de/cpp/aspose.slides.animation/itiming/) frei, unabhängig von [IEffect::get_Timing](https://reference.aspose.com/slides/de/cpp/aspose.slides.animation/ieffect/get_timing/). Das Effekt‑Timing plant den umschließenden Effekt; das Verhalten‑Timing beschreibt einen Vorgang darin.

### **Dauer, Verzögerung, Wiederholung und Beschleunigung festlegen**

Öffnen Sie `rotation.pptx` und setzen Sie [get_Duration](https://reference.aspose.com/slides/de/cpp/aspose.slides.animation/itiming/get_duration/) und [get_TriggerDelayTime](https://reference.aspose.com/slides/de/cpp/aspose.slides.animation/itiming/get_triggerdelaytime/) in Sekunden, dann konfigurieren Sie [get_RepeatCount](https://reference.aspose.com/slides/de/cpp/aspose.slides.animation/itiming/get_repeatcount/). [get_Accelerate](https://reference.aspose.com/slides/de/cpp/aspose.slides.animation/itiming/get_accelerate/) und [get_Decelerate](https://reference.aspose.com/slides/de/cpp/aspose.slides.animation/itiming/get_decelerate/) sind Bruchteile der Dauer; ihre Summe darf höchstens 1 betragen.

Die Eingabedatei ist die im Drehungs‑Beispiel erstellte, wobei das erste Verhalten als Drehung bekannt ist. Dieses Beispiel ändert nur das Timing dieses Verhaltens; sein 90‑Grad‑Winkel bleibt unverändert. Das getrennte Verwalten von Winkel und Timing erleichtert die Anpassung des Tempos, ohne die Animation neu zu bauen.

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

Das Verhalten nutzt eine Dauer von zwei Sekunden, eine halbe Sekunde Verzögerung und eine Wiederholungszahl von 3. Die ersten und letzten 20 % seiner Dauer werden für Beschleunigung bzw. Verzögerung verwendet.

Weitere Wiederholungs‑Optionen umfassen [get_RepeatDuration](https://reference.aspose.com/slides/de/cpp/aspose.slides.animation/itiming/get_repeatduration/), [get_RepeatUntilEndSlide](https://reference.aspose.com/slides/de/cpp/aspose.slides.animation/itiming/get_repeatuntilendslide/) und [get_RepeatUntilNextClick](https://reference.aspose.com/slides/de/cpp/aspose.slides.animation/itiming/get_repeatuntilnextclick/); wählen Sie eine Option, anstatt alle gleichzeitig zu aktivieren. [get_AutoReverse](https://reference.aspose.com/slides/de/cpp/aspose.slides.animation/itiming/get_autoreverse/) spielt die Animation nach dem Vorwärtspass rückwärts ab. Beschleunigung und Verzögerung gelten für kontinuierliche Änderungen, nicht für diskrete Zuweisungen oder Befehle.

## **Einen Bewegungspfad erstellen**

Verwenden Sie [CreateMotionEffect](https://reference.aspose.com/slides/de/cpp/aspose.slides.animation/ibehaviorfactory/createmotioneffect/), um Bewegung zu erzeugen. Seine [get_From](https://reference.aspose.com/slides/de/cpp/aspose.slides.animation/imotioneffect/get_from/), [get_To](https://reference.aspose.com/slides/de/cpp/aspose.slides.animation/imotioneffect/get_to/) und [get_By](https://reference.aspose.com/slides/de/cpp/aspose.slides.animation/imotioneffect/get_by/) beschreiben prozentbasierte Koordinaten oder Offsets. Für eine editierbare Route erzeugen Sie einen [MotionPath](https://reference.aspose.com/slides/de/cpp/aspose.slides.animation/motionpath/) und ordnen ihn [IMotionEffect::get_Path](https://reference.aspose.com/slides/de/cpp/aspose.slides.animation/imotioneffect/get_path/) zu. [IMotionPath](https://reference.aspose.com/slides/de/cpp/aspose.slides.animation/imotionpath/) speichert die Pfad‑Befehle.

[MotionCommandPathType](https://reference.aspose.com/slides/de/cpp/aspose.slides.animation/motioncommandpathtype/) wählt die Operation:

| Befehl | Punkte | Bedeutung |
| --- | --- | --- |
| MoveTo | One | Setze die Startposition. |
| LineTo | One | Bewege dich entlang eines geraden Segments zum Endpunkt. |
| CurveTo | Three | Folge einer kubischen Kurve, definiert durch zwei Steuerpunkte und einen Endpunkt. |
| CloseLoop | None | Kehre zur Startposition zurück. |
| End | None | Beende den Pfad. |

[MotionPathPointsType](https://reference.aspose.com/slides/de/cpp/aspose.slides.animation/motionpathpointstype/) beschreibt die Eigenschaften der Punkte, z. B. Ecken‑ oder Glättungspunkte. Es ersetzt nicht den Befehls‑Typ. Verwenden Sie für das Kurven‑Beispiel unten einen Kurven‑Punkt‑Typ und für die Geraden einen Eck‑Punkt‑Typ.

Pfad‑Koordinaten sind an die Folien‑Dimensionen normalisiert: Eine X‑Verschiebung von 0.25 entspricht einem Viertel der Folien‑Breite, nicht 0.25 Punkten. Positives Y verläuft nach unten. Absolute Befehle geben Positionen im Pfad‑Koordinatensystem an; relative Befehle geben Offsets zur aktuellen Position an. Dies ist getrennt von [get_Origin](https://reference.aspose.com/slides/de/cpp/aspose.slides.animation/imotioneffect/get_origin/), das den Referenzrahmen des Pfads auswählt, und [get_PathEditMode](https://reference.aspose.com/slides/de/cpp/aspose.slides.animation/imotioneffect/get_patheditmode/), das steuert, wie sich der Pfad bewegt, wenn die Form verschoben wird.

### **Geraden Pfad erstellen**

Erstellen Sie ein Bewegungs‑Verhalten mit einem Startpunkt, einem geraden Segment und einem End‑Befehl. [IMotionPath::Add](https://reference.aspose.com/slides/de/cpp/aspose.slides.animation/imotionpath/add/) nimmt den Befehls‑Typ, seine Punkte, den Punkt‑Typ und ein Relative‑Koordinaten‑Flag.

Der Start‑Befehl legt (0, 0) fest, und die Linie endet bei (0.25, 0), wodurch die Route eine horizontale Verschiebung von einem Viertel der Folien‑Breite erhält. Der End‑Befehl hat keine Punkte. Sobald der Pfad zugewiesen ist, verbindet das Hinzufügen des Bewegungs‑Verhaltens zum Effekt diese Route mit dem Rechteck.

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

`motion.pptx` enthält ein Bewegungs‑Verhalten mit drei Pfad‑Befehlen. Die nachfolgenden Dateibearbeitungs‑Beispiele verwenden diese bekannte Struktur.

### **Absolute und relative Koordinaten vergleichen**

Diese beiden Pfad‑Objekte beschreiben die gleiche Route. Der absolute Befehl endet bei (0.3, 0.1); der relative Befehl addiert (0.1, 0.1) zur aktuellen Position, (0.2, 0).

Beide Pfade starten an derselben Position. Für die relative Linie addieren Sie X‑ und Y‑Offsets zur aktuellen Position, um den Endpunkt zu erhalten; für die absolute Linie lesen Sie den Endpunkt direkt. Das Umschalten des Flags ohne Umrechnung der Koordinaten würde eine andere Route beschreiben.

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

Ordnen Sie entweder den Pfad einem Bewegungs‑Verhalten zu, um ihn in einer Präsentation zu verwenden. Das abschließende boolesche Argument wählt relative Koordinaten für diesen Befehl.

### **Eine Linie durch eine Kurve ersetzen**

Öffnen Sie `motion.pptx` und ersetzen Sie den Linien‑Befehl durch eine kubische Kurve. Geben Sie zuerst die beiden Steuerpunkte an, gefolgt vom Endpunkt.

Die Startposition wird vom vorherigen Befehl geliefert. Die ersten beiden Punkte formen die Kurve, das dritte ist ihr Ziel; es handelt sich nicht um drei aufeinanderfolgende Zielpunkte. Die gleichzeitige Aktualisierung von Befehls‑Typ, Punkt‑Edit‑Typ und Punkte‑Array hält das Segment konsistent mit seiner neuen Geometrie.

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

Der Pfad in `curve.pptx` hat weiterhin drei Befehle; sein mittlerer Befehl definiert jetzt eine Kurve.

## **Einen gespeicherten Pfad inspizieren und bearbeiten**

Jeder [IMotionCmdPath](https://reference.aspose.com/slides/de/cpp/aspose.slides.animation/imotioncmdpath/) bietet [get_Points](https://reference.aspose.com/slides/de/cpp/aspose.slides.animation/imotioncmdpath/get_points/), [get_CommandType](https://reference.aspose.com/slides/de/cpp/aspose.slides.animation/imotioncmdpath/get_commandtype/), [get_PointsType](https://reference.aspose.com/slides/de/cpp/aspose.slides.animation/imotioncmdpath/get_pointstype/) und [get_IsRelative](https://reference.aspose.com/slides/de/cpp/aspose.slides.animation/imotioncmdpath/get_isrelative/). Die folgenden Beispiele nutzen den bekannten Drei‑Befehl‑Pfad in `motion.pptx`. Für beliebige Eingaben lokalisieren Sie zuerst den gewünschten Effekt und prüfen Sie Befehls‑Typen und Punkt‑Anzahlen, bevor Sie per Index bearbeiten.

### **Befehle und Koordinaten lesen**

Lesen Sie den Pfad, ohne ihn zu ändern. End‑ und CloseLoop‑Befehle benötigen keine Punkte, also erlauben Sie ein null‑Punkte‑Array.

Die Ausgabe paart jeden Befehl mit seinem Relative‑Koordinaten‑Flag, bevor die Punkte aufgelistet werden. So können Sie einen Endpunkt von einem Offset unterscheiden, bevor Sie den Pfad ändern. Eine Kurve würde drei Punkte auflisten, während die gerade Linie in dieser Datei nur einen Punkt enthält.

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

Die Auflistung enthält einen Startpunkt, eine absolute Linie, die bei (0.25, 0) endet, und einen End‑Befehl.

### **Einen Endpunkt ändern**

Öffnen Sie `motion.pptx` und ersetzen Sie das Punkte‑Array der Linie, um ihren Endpunkt zu verschieben.

In der Eingabedatei ist Index 0 der Start‑Befehl und Index 1 die Linie. Das Ersetzen des einzelnen Punktes der Linie ändert ihr Ziel, ohne den Befehls‑Typ, das Timing oder die Position in der Sammlung zu ändern. Da der Befehl absolute Koordinaten verwendet, legt das neue Paar eine Position fest, nicht ein zusätzliches Offset.

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

Die Linie in `motion-endpoint.pptx` endet bei (0.4, 0.1); die Originaldatei bleibt unverändert.

### **Ein Segment ersetzen**

Verwenden Sie [Insert](https://reference.aspose.com/slides/de/cpp/aspose.slides.animation/imotionpath/insert/) und [RemoveAt](https://reference.aspose.com/slides/de/cpp/aspose.slides.animation/imotionpath/removeat/) um die Linie in `motion.pptx` zu ersetzen. Das Einfügen verschiebt die alte Linie zu Index 2.

Dies demonstriert das Ersetzen eines Befehls‑Objekts statt das Bearbeiten seiner bestehenden Koordinaten. Nach dem Einfügen enthält die Sammlung temporär den Start‑Befehl, die neue Linie, die alte Linie und den End‑Befehl. Das Entfernen von Index 2 verwirft die alte Linie und lässt die neue Route bestehen.

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

Der gespeicherte Pfad hat weiterhin drei Befehle, wobei die neue Linie bei (0.2, 0.1) endet und der End‑Befehl zuletzt steht.

## **Ein vorhandenes Verhalten ändern und verifizieren**

Wenn der Index des Verhaltens unbekannt ist, wählen Sie es nach Typ aus. Dieses Beispiel öffnet `rotation.pptx`, findet den [IRotationEffect](https://reference.aspose.com/slides/de/cpp/aspose.slides.animation/irotationeffect/), ändert den Winkel und prüft den gespeicherten Wert nach erneutem Öffnen.

Die Typ‑Überprüfung lässt die Schleife Verhaltensweisen, die keine Drehungen sind, überspringen. Der zweite Ladevorgang liest die gespeicherte Datei in ein separates Präsentations‑Objekt, sodass der Vergleich persistente Daten prüft und nicht den noch im Speicher gehaltenen Wert. Dieses Beispiel geht weiterhin davon aus, dass der bekannte Effekt an erster Stelle in der Hauptsequenz steht; das Auswählen nach Typ findet nicht zwangsläufig den korrekten Effekt in einer beliebigen Präsentation.

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

Die Ausgabe lautet `Rotation preserved: True`. Wenden Sie dasselbe Typ‑Prüfmuster auf andere Verhaltensweisen an. Für eine vollständige Erhaltungs‑Prüfung vergleichen Sie Ziel‑Form, Effekt, Verhaltens‑Typen und Reihenfolge, Timing sowie Pfad‑Befehle. Verwenden Sie eine numerische Toleranz für Gleitkomma‑Werte. Für eine Präsentation mit unbekanntem Animations‑Layout siehe [Read Shape Animations](/slides/de/cpp/shape-animation/#read-shape-animations) für die Durchlauf‑Analyse von Haupt‑ und Interaktions‑Sequenzen.

## **Verhaltens‑Reihenfolge, Vorgaben und Wiedergabe**

Die Reihenfolge in [IBehaviorCollection](https://reference.aspose.com/slides/de/cpp/aspose.slides.animation/ibehaviorcollection/) ist die gespeicherte Reihenfolge der Vorgänge eines Effekts. Sie ist keine Wiedergabeliste, in der jedes Verhalten automatisch auf das vorherige wartet. Timing und der umgebende Effekt bestimmen die Planung. Verhaltensweisen können sich überschneiden, und Vorgänge am selben Attribut können über [get_Additive](https://reference.aspose.com/slides/de/cpp/aspose.slides.animation/ibehavior/get_additive/) und [get_Accumulate](https://reference.aspose.com/slides/de/cpp/aspose.slides.animation/ibehavior/get_accumulate/) interagieren. Verwenden Sie nicht nur die Neuordnung der Sammlung, um „Bewegen, dann Drehen“ zu planen; nutzen Sie explizites Timing oder separate Effekte, wie in [Shape Animation](/slides/de/cpp/shape-animation/) beschrieben.

Der [get_Type](https://reference.aspose.com/slides/de/cpp/aspose.slides.animation/ieffect/get_type/) und [get_Subtype](https://reference.aspose.com/slides/de/cpp/aspose.slides.animation/ieffect/get_subtype/) des Effekts beschreiben seine Vorgabe. Sie sind keine vollständige Beschreibung eines bearbeiteten Verhaltens‑Baums. Wählen Sie Vorgabe und Untertyp, bevor Sie Verhaltensweisen anpassen: Das Ändern der Vorgabe kann die Sammlung neu erstellen und Ihre benutzerdefinierten Vorgänge verwerfen. Beispielsweise kann das Ändern eines angepassten Spin‑Effekts zu Fade die Dreh‑Verhaltensweise durch Set‑ und Filter‑Verhaltensweisen ersetzen. Prüfen Sie die Sammlung erneut, nachdem Sie Vorgabe oder Untertyp geändert haben. Das Löschen von Vorgabe‑Verhaltensweisen kann auch Sichtbarkeits‑ oder Initialisierungs‑Vorgänge entfernen, die die Vorgabe benötigt. Die Beispiele verwenden bewusst sichtbare Formen und ersetzen die Verhaltensweisen; sie rekonstruieren nicht jede Implementierung der Vorgabe.

## **Format‑Kompatibilität**

Ein erhaltenes Verhaltens‑Baum‑Modell garantiert nicht identische Wiedergabe in jedem Viewer oder Export‑Renderer. Prüfen Sie die gespeicherten Daten und die gerenderte Ausgabe separat.

| Format oder Ausgabe | Was zu überprüfen ist |
| --- | --- |
| PPTX | Verwenden Sie dieses Format als primäres Beispiel. Öffnen Sie es erneut, um den editierbaren Verhaltens‑Baum zu prüfen, und testen Sie die Wiedergabe in der gewünschten PowerPoint‑Version. |
| PPT | Das alte binäre Format kann vom PPTX abweichen. Durchlaufen Sie einen separaten Speicher‑und‑Öffnen‑Zyklus und testen Sie die Wiedergabe; schließen Sie nicht auf Unterstützung jeder benutzerdefinierten Kombination allein aus PPTX‑Ergebnis. |
| PDF, PNG, JPEG und andere statische Folien‑Bilder | Enthalten eine statische Folien‑Darstellung, keine abspielbare Verhaltens‑Zeitachse oder garantierten finalen Animations‑Frame. |
| [HTML5](/slides/de/cpp/export-to-html5/) | Kann unterstützte Animationen abspielen, wenn Form‑Animation in den Export‑Optionen aktiviert ist. Testen Sie benutzerdefinierte Kombinationen im Browser. |
| [Animated GIF](/slides/de/cpp/convert-powerpoint-to-animated-gif/) | Speichert gerenderte Frames, nicht editierbare Verhaltensweisen oder klick‑gesteuerte Interaktion. Prüfen Sie die tatsächlich gerenderte Bewegung. |
| [Video](/slides/de/cpp/convert-powerpoint-to-video/) | Rendert Animations‑Frames und kodiert sie als Video. Unterstützung ist auf die vom Renderer **unterstützten Animationen und Effekte** beschränkt; Befehle und interaktive Ereignisse werden nicht zu einer editierbaren Timeline. |

## **FAQ**

**Warum enthält mein Effekt Verhaltensweisen, bevor ich welche hinzugefügt habe?**

Das Erzeugen eines vordefinierten Effekts kann seine zugrundeliegenden Vorgänge erzeugen. Inspizieren Sie sie, bevor Sie entscheiden, ob Sie die Vorgabe erweitern oder deren Verhaltensweisen ersetzen.

**Führt das Verschieben eines Verhaltens an den Anfang dazu, dass es zuerst abgespielt wird?**

Nicht unbedingt. Die Reihenfolge der Sammlung ersetzt nicht das Timing. Prüfen Sie Verzögerungen, Dauern und Interaktionen zwischen Vorgängen am selben Attribut.

**Warum hat ein End‑Befehl keine Punkte?**

Er markiert das Ende des Pfads und benötigt keine Koordinaten. Prüfen Sie beim Inspizieren eines aus einer Datei gelesenen Pfads auf ein null‑Punkte‑Array.

**Reicht ein erfolgreicher Round‑Trip aus, um die Wiedergabe zu bestätigen?**

Nein. Das erneute Öffnen bestätigt die Erhaltung der geprüften Eigenschaften. Testen Sie den Präsentations‑Player oder den animierten Export separat, um das visuelle Verhalten zu verifizieren.