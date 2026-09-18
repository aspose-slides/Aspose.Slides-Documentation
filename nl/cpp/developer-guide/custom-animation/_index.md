---
title: "Aanmaken en Wijzigen van Aangepaste Animatiegedragingen in C++"
linktitle: "Aangepaste Animatie"
type: docs
weight: 151
url: /nl/cpp/custom-animation/
keywords:
- "aangepaste animatie"
- "animatiegedrag"
- "bewegingspad"
- "PowerPoint"
- "presentatie"
- "C++"
- "Aspose.Slides"
description: "Aanmaken, inspecteren en wijzigen van aangepaste animatiegedragingen en bewerkbare bewegingspaden in PowerPoint-presentaties met Aspose.Slides voor C++."
---
## **Overzicht**

Aangepaste animatie‑gedragingen geven je controle over individuele bewerkingen binnen een animatie‑effect, zoals het wijzigen van een kleur, het draaien van een vorm of het volgen van een bewerkbaar bewegingspad. Deze gids toont hoe je gedragingen maakt en combineert, hun timing configureert, bestaande animaties inspecteert en wijzigt, en verifieert dat hun eigenschappen behouden blijven nadat een presentatie is opgeslagen en opnieuw geopend.

Voor vooraf gedefinieerde effecten en klik‑triggers, zie [Vormanimatie](/slides/nl/cpp/shape-animation/).

## **Begrijp het Animatiemodel**

Een animatie is gestructureerd als **Timeline → Sequence → Effect → Behaviors**:

- De slide’s [get_Timeline](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ibaseslide/get_timeline/) bevat de hoofd‑sequentie en interactieve sequenties.
- Een [ISequence](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/isequence/) bevat effecten, eventueel gericht op verschillende vormen.
- Een [IEffect](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/ieffect/) identificeert een doelvorm, preset, subtype en effect‑timing.
- [IEffect::get_Behaviors](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/ieffect/get_behaviors/) bevat de bewerkingen die het effect implementeren: kleur wijzigen, verplaatsen, draaien, een eigenschap instellen, enzovoort.

## **Maak Individuele Gedragingen**

Roep [ISequence::AddEffect](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/isequence/addeffect/) aan om een effect te maken en toegang te krijgen tot de [get_Behaviors](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/ieffect/get_behaviors/)‑collectie. Een preset kan deze collectie automatisch vullen. Behoud de bewerkingen wanneer je het preset uitbreidt, of gebruik [Clear](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/ibehaviorcollection/clear/) wanneer je ze bewust wilt vervangen.

[IBehaviorFactory](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/ibehaviorfactory/) maakt de acht getoonde gedragstypen. Beweging wordt behandeld in [Een Bewegingspad Maken](#build-a-motion-path). Elk creatie‑voorbeeld is zelf‑standende code die binnen een functie kan worden uitgevoerd; latere bewerkingsvoorbeelden geven aan welk uitvoer‑bestand ze gebruiken.

### **Rotatie**

Gebruik [CreateRotationEffect](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/ibehaviorfactory/createrotationeffect/) om een rotatie te maken. [get_By](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/irotationeffect/get_by/) geeft een relatieve hoek in graden op; [get_From](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/irotationeffect/get_from/) en [get_To](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/irotationeffect/get_to/) geven de eindpunten.

Het voorbeeld start met een Spin‑effect, vervangt de preset‑bewerkingen door één rotatie‑gedrag, en geeft die bewerking een duur van twee seconden. Een relatieve hoek van 90 graden betekent een kwartslag ten opzichte van de start‑oriëntatie van de vorm, dus er is geen expliciete start‑hoek nodig.

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

`rotation.pptx` bevat één vorm en één rotatie‑gedrag. De collectie, timing‑ en rotatie‑bewerkingsvoorbeelden hieronder gebruiken dit bestand.

### **Schalen**

Gebruik [CreateScaleEffect](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/ibehaviorfactory/createscaleeffect/) met X/Y‑percentages: [get_From](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/iscaleeffect/get_from/) en [get_To](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/iscaleeffect/get_to/) beschrijven de beginnende en eindgrootte, terwijl [get_By](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/iscaleeffect/get_by/) een relatieve wijziging aangeeft. Hier betekent 100 de oorspronkelijke grootte.

Het voorbeeld vergroot beide dimensies van 100 % naar 125 % in twee seconden. Gelijke horizontale en verticale percentages behouden de verhoudingen van de vorm; verschillende percentages zouden één dimensie meer uitrekken dan de andere.

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

### **Kleur**

Gebruik [CreateColorEffect](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/ibehaviorfactory/createcoloreffect/) om de vulling van blauw naar oranje te wijzigen. [get_From](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/icoloreffect/get_from/) en [get_To](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/icoloreffect/get_to/) zijn kleuren; [get_By](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/icoloreffect/get_by/) is een kleur‑offset. [IBehavior::get_Properties](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/ibehavior/get_properties/) identificeert het attribute dat wordt geanimeerd.

De solide vulling van de vorm wordt initieel op blauw gezet, overeenkomstig de startkleur van de animatie. Het selecteren van het vulling‑kleur‑attribute vertelt het gedrag welk deel van de vorm moet worden gewijzigd; de kleur‑eindpunten alleen identificeren dat attribute niet. Het opgeslagen effect beschrijft een twee‑seconden‑overgang naar oranje.

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

Gebruik [CreateFilterEffect](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/ibehaviorfactory/createfiltereffect/) om een veeg‑effect te kiezen. [get_Type](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/ifiltereffect/get_type/), [get_Subtype](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/ifiltereffect/get_subtype/), en [get_Reveal](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/ifiltereffect/get_reveal/) geven het filter, de richting en of de vorm moet worden onthuld of verborgen.

Dit voorbeeld configureert een twee‑seconden‑veeg die de vorm onthult met het subtype “right”. De filterinstellingen behoren tot het gedrag binnen het effect, dus ze worden geconfigureerd nadat de oorspronkelijke bewerkingen van het preset zijn verwijderd.

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

### **Eigenschap**

Gebruik [CreatePropertyEffect](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/ibehaviorfactory/createpropertyeffect/) om de ondoorzichtigheid (opacity) te animeren. [get_From](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/ipropertyeffect/get_from/), [get_To](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/ipropertyeffect/get_to/), en [get_By](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/ipropertyeffect/get_by/) zijn strings die worden geïnterpreteerd met [get_ValueType](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/ipropertyeffect/get_valuetype/) en [get_CalcMode](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/ipropertyeffect/get_calcmode/). Kies eindpunten of een relatieve offset in plaats van alle drie ondoordacht in te stellen.

Hier is het geselecteerde attribute ondoorzichtigheid, en de numerieke strings representeren een wijziging van 25 % ondoorzichtigheid naar volledige ondoorzichtigheid. Lineaire interpolatie beschrijft een geleidelijke wijziging tussen die waarden. Wanneer je dit voorbeeld aanpast naar een ander attribute, kies dan een waardetype en eindwaarden die passen bij dat attribute.

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

### **Instellen**

Gebruik [CreateSetEffect](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/ibehaviorfactory/createseteffect/) om de zichtbaarheid toe te wijzen via [get_To](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/iseteffect/get_to/). Een set‑gedrag interpoleert niet tussen eindpunten.

Het voorbeeld selecteert het zichtbaar‑attribute en kent de string `visible` toe wanneer het gedrag wordt uitgevoerd. In C++ moet je de string als object verpakken voordat je deze aan het set‑gedrag toekent. De rechthoek is al zichtbaar in deze minimale presentatie, dus de toewijzing veroorzaakt mogelijk geen opvallende visuele wijziging op zichzelf. Zo’n bewerking is nuttig als onderdeel van een groter effect dat tevens bepaalt wanneer de vorm verborgen of zichtbaar wordt.

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

### **Opdracht**

Gebruik [CreateCommandEffect](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/ibehaviorfactory/createcommandeffect/) en configureer [get_Type](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/icommandeffect/get_type/), [get_CommandString](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/icommandeffect/get_commandstring/), en [get_ShapeTarget](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/icommandeffect/get_shapetarget/). Plaats een WAV‑opname met de naam `sample.wav` in de werkmap. Dit voorbeeld embed‑t de opname met [AddAudioFrameEmbedded](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ishapecollection/addaudioframeembedded/) en koppelt een afspeel‑opdracht aan het audiokanaal.

Het audiokanaal is zowel het doel van het effect als van de opdracht. Hierdoor wordt het afspeelverzoek aan de ingebedde opname gekoppeld; een opdracht‑string op zich identificeert niet welk media‑object moet worden aangestuurd. Het effect wordt geconfigureerd om te starten bij een klik tijdens de diavoorstelling.

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

Opslaan legt de opdracht vast in `command.pptx`; het wordt niet automatisch afgespeeld. Afspelen vereist een diavoorstellings‑speler die de opdracht en het mediatarget ondersteunt.

## **Beheer de Gedragingen‑Collectie**

[IBehaviorCollection](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/ibehaviorcollection/) ondersteunt [Add](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/ibehaviorcollection/add/), [Insert](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/ibehaviorcollection/insert/), [Remove](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/ibehaviorcollection/remove/), en [RemoveAt](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/ibehaviorcollection/removeat/). Dit voorbeeld opent `rotation.pptx`, voegt schalen toe, verplaatst het vóór de rotatie, en verwijdert de rotatie. Het verwijderen en opnieuw invoegen van hetzelfde object verandert de opgeslagen positie zonder een kopie te maken.

De reeks bewerkingen verandert de collectie van rotatie‑schalen naar schalen‑rotatie, en tenslotte naar alleen schalen. Indexen verwijzen naar de huidige collectie, dus de verwijdering gebruikt de nieuwe index van de rotatie na het herschikken. De definitieve enumeratie bevestigt welk gedrag zal worden opgeslagen.

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

De output is `ScaleEffect`: alleen schalen blijft over. De volgorde van de collectie plant gedragingen niet automatisch achter elkaar. Maak de collectie leeg alleen wanneer je alle bewerkingen vervangt.

## **Configureer Gedrag‑Timing**

[IBehavior::get_Timing](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/ibehavior/get_timing/) geeft toegang tot [ITiming](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/itiming/), onafhankelijk van [IEffect::get_Timing](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/ieffect/get_timing/). Effect‑timing plant het omvattende effect; gedrag‑timing beschrijft een bewerking binnen dat effect.

### **Duur, Vertraging, Herhaling en Versnelling Instellen**

Open `rotation.pptx` en stel [get_Duration](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/itiming/get_duration/) en [get_TriggerDelayTime](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/itiming/get_triggerdelaytime/) in seconden in, configureer daarna [get_RepeatCount](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/itiming/get_repeatcount/). [get_Accelerate](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/itiming/get_accelerate/) en [get_Decelerate](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/itiming/get_decelerate/) zijn breuken van de duur; houd hun som ≤ 1.

Het invoerbestand is het bestand dat in het rotatie‑voorbeeld is gemaakt, waarbij de eerste gedraging een rotatie is. Dit voorbeeld wijzigt alleen de timing van dat gedrag; de 90‑graden‑hoek blijft ongewijzigd. Het scheiden van hoek en timing maakt het eenvoudiger het tempo aan te passen zonder de animatie opnieuw te bouwen.

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

Het gedrag gebruikt een duur van twee seconden, een vertraging van een halve seconde, en een herhalings‑aantal van 3. De eerste en laatste 20 % van de duur worden gebruikt voor versnelling en vertraging.

Andere herhalings‑opties omvatten [get_RepeatDuration](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/itiming/get_repeatduration/), [get_RepeatUntilEndSlide](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/itiming/get_repeatuntilendslide/), en [get_RepeatUntilNextClick](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/itiming/get_repeatuntilnextclick/); kies één beleid in plaats van ze allemaal tegelijk in te schakelen. [get_AutoReverse](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/itiming/get_autoreverse/) speelt de animatie achterstevoren na de voorwaartse uitvoering. Versnelling en vertraging gelden voor continue wijzigingen, niet voor discrete toewijzingen of opdrachten.

## **Een Bewegingspad Maken**

Gebruik [CreateMotionEffect](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/ibehaviorfactory/createmotioneffect/) om beweging te creëren. Zijn [get_From](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/imotioneffect/get_from/), [get_To](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/imotioneffect/get_to/), en [get_By](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/imotioneffect/get_by/) beschrijven coördinaten of offsets op basis van percentages. Voor een bewerkbare route, maak een [MotionPath](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/motionpath/) en wijs deze toe aan [IMotionEffect::get_Path](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/imotioneffect/get_path/). [IMotionPath](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/imotionpath/) slaat de pad‑opdrachten op.

[MotionCommandPathType](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/motioncommandpathtype/) selecteert de operatie:

| Opdracht | Punten | Betekenis |
| --- | --- | --- |
| MoveTo | Eén | Zet de startpositie. |
| LineTo | Eén | Beweeg langs een rechte segment naar het eindpunt. |
| CurveTo | Drie | Volg een kubieke curve gedefinieerd door twee controlepunten en een eindpunt. |
| CloseLoop | Geen | Keer terug naar de startpositie. |
| End | Geen | Eindig het pad. |

[MotionPathPointsType](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/motionpathpointstype/) beschrijft de eigenschappen van puntbewerking, zoals hoek‑ of vloeiende punten. Het vervangt niet het opdrachttype. Gebruik een curve‑punttype voor het curve‑voorbeeld hieronder, en een hoek‑punttype voor de rechte segmenten.

Pad‑coördinaten zijn genormaliseerd naar de afmetingen van de slide: een X‑verplaatsing van 0,25 staat voor een kwart van de slide‑breedte, niet 0,25 punten. Positieve Y loopt omlaag. Absolute opdrachten geven posities op in het pad‑coördinatensysteem; relatieve opdrachten geven offsets ten opzichte van de huidige positie. Dit staat los van [get_Origin](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/imotioneffect/get_origin/), dat het referentiekader van het pad kiest, en [get_PathEditMode](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/imotioneffect/get_patheditmode/), dat bepaalt hoe het pad beweegt wanneer de vorm wordt verplaatst.

### **Een Rechte Route Maken**

Creëer een bewegings­gedrag met een startpunt, één recht segment, en een eind‑opdracht. [IMotionPath::Add](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/imotionpath/add/) neemt het opdrachttype, de punten, het punt‑type en een relatieve‑coördinaat‑vlag.

De start‑opdracht zet (0, 0), en de lijn eindigt op (0,25, 0), waardoor de route een horizontale verplaatsing van een kwart van de slide‑breedte krijgt. De eind‑opdracht heeft geen coördinaat‑punten. Zodra het pad is toegewezen, koppelt het toevoegen van het bewegingsgedrag aan het effect die route aan de rechthoek.

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

`motion.pptx` bevat één bewegingsgedrag met drie pad‑opdrachten. De volgende bewerkings‑voorbeelden gebruiken deze bekende structuur.

### **Absolute en Relatieve Coördinaten Vergelijken**

Deze twee pad‑objecten beschrijven dezelfde route. De absolute opdracht eindigt op (0,3, 0,1); de relatieve opdracht voegt (0,1, 0,1) toe aan de huidige positie, (0,2, 0).

Beide paden starten op dezelfde positie. Voor de relatieve lijn tel je de X‑ en Y‑offsets op bij de huidige positie om het eindpunt te verkrijgen; voor de absolute lijn lees je het eindpunt direct. Het wisselen van de vlag zonder de coördinaten te converteren resulteert in een andere route.

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

Ken een van beide paden toe aan een bewegings‑gedrag om het in een presentatie te gebruiken. Het laatste Booleaanse argument selecteert relatieve coördinaten voor die opdracht.

### **Een Lijn Vervangen Door een Curve**

Open `motion.pptx` en vervang de lijn‑opdracht door een kubieke curve. Geef eerst de twee controlepunten op, gevolgd door het eindpunt.

De startpositie wordt geleverd door de voorafgaande opdracht. De eerste twee punten vormen de curve, het derde punt is de bestemming; ze zijn geen drie opeenvolgende eindpunten. Het samen bijwerken van opdrachttype, punt‑bewerkingstype en punt‑array houdt het segment consistent met de nieuwe geometrie.

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

Het pad in `curve.pptx` heeft nog steeds drie opdrachten; de middelste opdracht definieert nu een curve.

## **Een Opgeslagen Pad Inspecteren en Bewerken**

Elk [IMotionCmdPath](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/imotioncmdpath/) geeft toegang tot [get_Points](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/imotioncmdpath/get_points/), [get_CommandType](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/imotioncmdpath/get_commandtype/), [get_PointsType](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/imotioncmdpath/get_pointstype/), en [get_IsRelative](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/imotioncmdpath/get_isrelative/). De volgende voorbeelden gebruiken het bekende drie‑opdracht‑pad in `motion.pptx`. Voor willekeurige invoer, zoek eerst het beoogde effect en controleer opdrachttypes en punt‑aantallen vóór bewerking op index.

### **Opdrachten en Coördinaten Lezen**

Lees het pad zonder het te wijzigen. Eind‑ en close‑loop‑opdrachten hebben geen punten nodig, dus houd rekening met een nul‑punt‑array.

De output koppelt elke opdracht aan zijn relatieve‑coördinaat‑vlag voordat de punten worden opgesomd. Zo kun je een eindpunt onderscheiden van een offset vóór je het pad bewerkt. Een curve zou drie punten tonen, terwijl de rechte lijn in dit bestand er slechts één heeft.

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

De lijst bevat een startpunt, een absolute lijn die eindigt op (0,25, 0), en een eind‑opdracht.

### **Een Eindpunt Wijzigen**

Open `motion.pptx` en vervang de punt‑array van de lijn om het eindpunt te verplaatsen.

In het invoerbestand is index 0 de start‑opdracht en index 1 de lijn. Het vervangen van het enkele punt van de lijn wijzigt de bestemming zonder het opdrachttype, de timing of de positie in de collectie te wijzigen. Omdat de opdracht absolute coördinaten gebruikt, specificeert het nieuwe paar een positie in plaats van een extra offset.

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

De lijn in `motion-endpoint.pptx` eindigt op (0,4, 0,1); het originele bestand blijft ongewijzigd.

### **Een Segment Vervangen**

Gebruik [Insert](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/imotionpath/insert/) en [RemoveAt](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/imotionpath/removeat/) om de lijn in `motion.pptx` te vervangen. Invoegen verschuift de oude lijn naar index 2.

Dit toont het vervangen van een opdrachtobject in plaats van het bewerken van bestaande coördinaten. Na invoegen bevat de collectie tijdelijk de start‑opdracht, de nieuwe lijn, de oude lijn, en de eind‑opdracht. Het verwijderen van index 2 verwijdert de oude lijn en laat de nieuwe route staan.

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

Het opgeslagen pad heeft nog steeds drie opdrachten, met de nieuwe lijn die eindigt op (0,2, 0,1) en de eind‑opdracht op de laatste plaats.

## **Bestaand Gedrag Wijzigen en Verifiëren**

Wanneer de index van het gedrag onbekend is, selecteer het op type. Dit voorbeeld opent `rotation.pptx`, vindt de [IRotationEffect](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/irotationeffect/), wijzigt de hoek, en controleert de opgeslagen waarde na het opnieuw openen.

De type‑controle laat de lus gedrag dat geen rotaties zijn overslaan. De tweede lading leest het opgeslagen bestand in een apart presentatie‑object, zodat de vergelijking de persistente data controleert i.p.v. de nog in het geheugen aanwezige waarde. Dit voorbeeld gaat nog steeds uit van het bekende effect als eerste in de hoofd‑sequentie; selecteren op type vindt niet per se het juiste effect in een willekeurige presentatie.

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

De output is `Rotation preserved: True`. Pas hetzelfde type‑controlpatroon toe op andere gedragingen. Voor een volledige behoud‑controle, vergelijk de doelvorm, effect, gedragstypen en volgorde, timing, en pad‑opdrachten. Gebruik een numerieke tolerantie voor zwevende‑komma waarden. Voor een presentatie met een onbekende animatie‑structuur, zie [Shape‑animaties Lezen](/slides/nl/cpp/shape-animation/#read-shape-animations) voor het doorlopen van hoofd‑ en interactieve sequenties.

## **Gedragvolgorde, Presets en Afspelen**

De volgorde in [IBehaviorCollection](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/ibehaviorcollection/) is de opgeslagen volgorde van de bewerkingen van een effect. Het is geen afspeellijst waarbij elk gedrag automatisch wacht op het vorige. Timing en het omvattende effect bepalen de planning. Gedragingen kunnen overlappen, en bewerkingen op hetzelfde attribuut kunnen met [get_Additive](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/ibehavior/get_additive/) en [get_Accumulate](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/ibehavior/get_accumulate/) op elkaar inwerken. Gebruik niet alleen herschikking van de collectie om “verplaatsen, dan roteren” te plannen; gebruik expliciete timing of gescheiden effecten zoals beschreven in [Vormanimatie](/slides/nl/cpp/shape-animation/).

Het effect‑[get_Type](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/ieffect/get_type/) en [get_Subtype](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/ieffect/get_subtype/) beschrijven het preset. Ze vormen geen volledige beschrijving van een bewerkte gedragboom. Kies het preset en subtype voordat je gedragingen aanpast: het wijzigen van het preset kan de collectie opnieuw bouwen en je aangepaste bewerkingen weggooien. Bijvoorbeeld, een Spin‑effect aanpassen naar Fade kan de rotatie‑gedrag vervangen door set‑ en filter‑gedragingen. Controleer de collectie opnieuw na het wijzigen van een preset of subtype. Het leegmaken van preset‑gedragingen kan ook zichtbaarheid‑ of initialisatie‑bewerkingen verwijderen die het preset nodig heeft. De voorbeelden gebruiken bewust zichtbare vormen en vervangen de gedragingen; ze herbouwen niet de implementatie van elk preset.

## **Formaat‑Compatibiliteit**

Een bewaarde gedragboom garandeert geen identieke weergave in elke viewer of export‑renderer. Controleer afzonderlijk de opgeslagen data en de gerenderde output.

| Formaat of output | Te verifiëren |
| --- | --- |
| PPTX | Gebruik als primair formaat voor deze voorbeelden. Open opnieuw om de bewerkbare gedragboom te verifiëren, en controleer daarna de weergave in de beoogde PowerPoint‑versie. |
| PPT | Het oude binaire formaat kan verschillen van PPTX. Test een afzonderlijke opslaan‑en‑opnieuw‑open‑cyclus en afspelen; leid niet af dat elke aangepaste combinatie werkt vanwege een geslaagde PPTX‑output. |
| PDF, PNG, JPEG en andere statische dia‑afbeeldingen | Bevatten een statische weergave, geen afspeelbare gedragstijdlijn of gegarandeerd eindframe van de animatie. |
| [HTML5](/slides/nl/cpp/export-to-html5/) | Kan ondersteunde animaties afspelen wanneer vormanimatie is ingeschakeld in de exportopties. Test aangepaste combinaties in de browser. |
| [Geanimeerde GIF](/slides/nl/cpp/convert-powerpoint-to-animated-gif/) | Slaat gerenderde frames op, geen bewerkbare gedragingen of klik‑gestuurde interactie. Controleer de werkelijk gerenderde beweging. |
| [Video](/slides/nl/cpp/convert-powerpoint-to-video/) | Render animatie‑frames en codeert ze als video. Ondersteuning is beperkt tot de renderer‑[ondersteunde animaties en effecten](/slides/nl/cpp/convert-powerpoint-to-video/#supported-animations-and-effects); opdrachten en interactieve gebeurtenissen worden geen bewerkbare tijdlijn. |

## **FAQ**

**Waarom bevat mijn effect gedragingen voordat ik er één heb toegevoegd?**

Het aanmaken van een vooraf gedefinieerd effect kan de onderliggende bewerkingen genereren. Inspecteer ze voordat je beslist of je het preset wilt uitbreiden of de gedragingen wilt vervangen.

**Zorgt verplaatsen van een gedrag naar het begin ervan dat het eerst wordt afgespeeld?**

Niet per se. De volgorde in de collectie is geen vervanging voor timing. Controleer vertragingen, duur en interacties tussen bewerkingen op hetzelfde attribuut.

**Waarom heeft een eind‑opdracht geen punten?**

Het markeert het einde van het pad en heeft geen coördinaten nodig. Controleer op een nul‑punt‑array bij het inspecteren van een pad dat uit een bestand is gelezen.

**Is een geslaagde round‑trip voldoende om afspelen te bevestigen?**

Nee. Het opnieuw openen bevestigt alleen de bewaarde eigenschappen die je gecontroleerd hebt. Test de diavoorstellings‑speler of geanimeerde export apart om het visuele gedrag te bevestigen.