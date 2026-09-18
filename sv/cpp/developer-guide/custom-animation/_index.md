---
title: Skapa och ändra anpassade animationsbeteenden i C++
linktitle: Anpassad animation
type: docs
weight: 151
url: /sv/cpp/custom-animation/
keywords:
- anpassad animation
- animationsbeteende
- rörelsestråle
- PowerPoint
- presentation
- C++
- Aspose.Slides
description: "Skapa, inspektera och ändra anpassade animationsbeteenden och redigerbara rörelsestrålar i PowerPoint-presentationer med Aspose.Slides för C++."
---
## **Översikt**

Anpassade animationsbeteenden låter dig kontrollera enskilda operationer inom en animationseffekt, såsom att ändra en färg, rotera en form eller följa en redigerbar rörelsestråle. Denna guide visar hur man skapar och kombinerar beteenden, konfigurerar deras timing, inspekterar och ändrar befintliga animationer, samt verifierar att deras egenskaper överlever sparande och återöppning av en presentation.

För fördefinierade effekter och klickutlösare, se [Shape Animation](/slides/sv/cpp/shape-animation/).

## **Förstå animationsmodellen**

En animation är organiserad som **Timeline → Sequence → Effect → Behaviors**:

- Bildens [get_Timeline](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ibaseslide/get_timeline/) innehåller dess huvudsekvens och interaktiva sekvenser.
- En [ISequence](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/isequence/) innehåller effekter, eventuellt riktade mot olika former.
- En [IEffect](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/ieffect/) identifierar en målform, förinställning, undertyp och effektens timing.
- [IEffect::get_Behaviors](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/ieffect/get_behaviors/) innehåller de operationer som implementerar effekten: ändra färg, flytta, rotera, sätta en egenskap, osv.

## **Skapa enskilda beteenden**

Anropa [ISequence::AddEffect](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/isequence/addeffect/) för att skapa en effekt och komma åt dess [get_Behaviors](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/ieffect/get_behaviors/)‑samling. En förinställning kan fylla denna samling automatiskt. Behåll dess operationer när du utökar förinställningen, eller använd [Clear](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/ibehaviorcollection/clear/) när du avsiktligt ersätter dem.

[IBehaviorFactory](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/ibehaviorfactory/) skapar de åtta beteendetyper som illustreras nedan. Rörelse täcks i [Build a Motion Path](#build-a-motion-path). Varje skapelseexempel är självständig kod som kan köras i en funktion; senare redigeringsexempel anger vilken utdatfil de använder.

### **Rotation**

Använd [CreateRotationEffect](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/ibehaviorfactory/createrotationeffect/) för att skapa en rotation. [get_By](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/irotationeffect/get_by/) anger en relativ vinkel i grader; [get_From](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/irotationeffect/get_from/) och [get_To](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/irotationeffect/get_to/) anger start‑ och slutpunkter.

Exemplet börjar med en Spin‑effekt, ersätter dess förinställda operationer med ett rotationsbeteende och ger den operationen en tvåsekunders varaktighet. En relativ vinkel på 90 grader motsvarar en fjärdedels rotation från formens startorientering, så ingen explicit startvinkel behövs.

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

`rotation.pptx` innehåller en form och ett rotationsbeteende. Samlingen, timingen och rotationsredigeringsexemplen nedan använder den här filen.

### **Skala**

Använd [CreateScaleEffect](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/ibehaviorfactory/createscaleeffect/) med X/Y‑procenttal: [get_From](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/iscaleeffect/get_from/) och [get_To](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/iscaleeffect/get_to/) beskriver start‑ och slutstorlek, medan [get_By](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/iscaleeffect/get_by/) beskriver en relativ förändring. Här betyder 100 den ursprungliga storleken.

Exemplet växer båda dimensionerna från 100 % till 125 % under två sekunder. Att använda lika horisontella och vertikala procenttal behåller formens proportioner; olika procenttal skulle sträcka en dimension mer än den andra.

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

### **Färg**

Använd [CreateColorEffect](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/ibehaviorfactory/createcoloreffect/) för att ändra fyllningen från blå till orange. [get_From](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/icoloreffect/get_from/) och [get_To](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/icoloreffect/get_to/) är färger; [get_By](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/icoloreffect/get_by/) är en färgförskjutning. [IBehavior::get_Properties](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/ibehavior/get_properties/) identifierar attributet som animeras.

Formens solida fyllning initieras till blå, vilket matchar animationens startfärg. Att välja fyllnings‑färgattributet talar om för beteendet vilken del av formen som ska ändras; färgslutpunkterna ensamma identifierar inte det attributet. Den sparade effekten beskriver en tvåsekunders övergång till orange.

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

Använd [CreateFilterEffect](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/ibehaviorfactory/createfiltereffect/) för att välja en svepning. [get_Type](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/ifiltereffect/get_type/), [get_Subtype](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/ifiltereffect/get_subtype/), och [get_Reveal](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/ifiltereffect/get_reveal/) anger filtret, riktningen och om formen ska avslöjas eller döljas.

Detta exempel konfigurerar en tvåsekunders svepning som avslöjar formen med under‑typen för högerriktning. Filterinställningarna tillhör beteendet inne i effekten, så de konfigureras efter att de ursprungliga operationerna i förinställningen har tagits bort.

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

### **Egenskap**

Använd [CreatePropertyEffect](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/ibehaviorfactory/createpropertyeffect/) för att animera opacitet. [get_From](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/ipropertyeffect/get_from/), [get_To](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/ipropertyeffect/get_to/), och [get_By](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/ipropertyeffect/get_by/) är strängar som tolkas med [get_ValueType](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/ipropertyeffect/get_valuetype/) och [get_CalcMode](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/ipropertyeffect/get_calcmode/). Välj slutpunkter eller en relativ förskjutning snarare än att sätta alla tre utan åtskillnad.

Här är det valda attributet opacitet, och de numeriska strängarna representerar en förändring från 25 % opacitet till full opacitet. Linjär interpolering beskriver en gradvis förändring mellan dessa värden. När du anpassar exemplet till ett annat attribut, välj en värdetyp och slutvärden som är lämpliga för just det attributet.

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

### **Set**

Använd [CreateSetEffect](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/ibehaviorfactory/createseteffect/) för att tilldela synlighet via [get_To](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/iseteffect/get_to/). Ett set‑beteende interpolerar inte mellan slutpunkter.

Exemplet väljer synlighetsattributet och tilldelar strängen `visible` när beteendet körs. I C++ paketera strängen som ett objekt innan du tilldelar den till set‑beteendet. Rektangeln är redan synlig i denna minimala presentation, så tilldelningen ger inte nödvändigtvis någon uppenbar visuell förändring på egen hand. En sådan operation är användbar som del av en större effekt som också styr när formen blir dold eller synlig.

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

### **Kommando**

Använd [CreateCommandEffect](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/ibehaviorfactory/createcommandeffect/) och konfigurera [get_Type](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/icommandeffect/get_type/), [get_CommandString](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/icommandeffect/get_commandstring/), och [get_ShapeTarget](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/icommandeffect/get_shapetarget/). Placera en WAV‑inspelning med namnet `sample.wav` i arbetskatalogen. Detta exempel bäddar in den med [AddAudioFrameEmbedded](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ishapecollection/addaudioframeembedded/) och bifogar ett spel‑kommando till ljudramen.

Ljudramen är både effektens mål och kommandots mål. Detta kopplar uppspelningsbegäran till den inbäddade inspelningen; en kommandosträng i sig identifierar inte vilket mediaobjekt som ska kontrolleras. Effekten är konfigurerad att starta på ett klick under bildspelet.

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

Sparning lagrar kommandot i `command.pptx`; den spelar inte upp inspelningen. Uppspelning kräver en bildspelsspelare som stöder kommandot och dess mediamål.

## **Hantera beteendesamlingen**

[IBehaviorCollection](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/ibehaviorcollection/) stödjer [Add](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/ibehaviorcollection/add/), [Insert](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/ibehaviorcollection/insert/), [Remove](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/ibehaviorcollection/remove/), och [RemoveAt](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/ibehaviorcollection/removeat/). Detta exempel öppnar `rotation.pptx`, lägger till skalning, flyttar den före rotation och tar bort rotationen. Att ta bort och återinfoga samma objekt ändrar dess lagrade position utan att skapa en kopia.

Redigeringssekvensen ändrar samlingen från rotation‑scale till scale‑rotation och sedan till endast scale. Index refererar till den aktuella samlingen, så borttagningen använder rotationens nya index efter omordning. Den slutgiltiga uppräkningen bekräftar vilket beteende som kommer att sparas.

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

Resultatet är `ScaleEffect`: endast skalning återstår. Samlingsordning schemalägger i sig inte beteenden ett efter ett. Rensa samlingen endast när du ersätter alla dess operationer.

## **Konfigurera beteendetiming**

[IBehavior::get_Timing](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/ibehavior/get_timing/) exponerar [ITiming](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/itiming/), oberoende av [IEffect::get_Timing](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/ieffect/get_timing/). Effekt‑timing schemalägger den omslutande effekten; beteende‑timing beskriver en operation inom den.

### **Ställ in varaktighet, fördröjning, upprepning och acceleration**

Öppna `rotation.pptx` och sätt [get_Duration](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/itiming/get_duration/) och [get_TriggerDelayTime](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/itiming/get_triggerdelaytime/) i sekunder, konfiguera sedan [get_RepeatCount](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/itiming/get_repeatcount/). [get_Accelerate](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/itiming/get_accelerate/) och [get_Decelerate](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/itiming/get_decelerate/) är bråkdelar av varaktigheten; håll deras summa högst 1.

Indatafilen är den som skapades i rotations‑exemplet, där det första beteendet är känt som en rotation. Detta exempel ändrar endast den beteendets timing; dess 90‑gradsvinkel förblir intakt. Att hålla vinkel och timing separata gör det enklare att justera takten utan att återskapa animationen.

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

Beteendet använder en tvåsekunders varaktighet, en halvsekunders fördröjning och ett repetitionsantal på 3. De första och sista 20 % av varaktigheten används för acceleration och deceleration.

Andra repetitionspolicyer inkluderar [get_RepeatDuration](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/itiming/get_repeatduration/), [get_RepeatUntilEndSlide](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/itiming/get_repeatuntilendslide/), och [get_RepeatUntilNextClick](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/itiming/get_repeatuntilnextclick/); välj en policy snarare än att aktivera dem alla samtidigt. [get_AutoReverse](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/itiming/get_autoreverse/) spelar animationen baklänges efter framåtpasset. Acceleration och deceleration gäller kontinuerliga förändringar, inte diskreta tilldelningar eller kommandon.

## **Bygg en rörelsestråle**

Använd [CreateMotionEffect](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/ibehaviorfactory/createmotioneffect/) för att skapa rörelse. Dess [get_From](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/imotioneffect/get_from/), [get_To](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/imotioneffect/get_to/), och [get_By](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/imotioneffect/get_by/) beskriver procentbaserade koordinater eller förskjutningar. För en redigerbar bana, skapa en [MotionPath](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/motionpath/) och tilldela den till [IMotionEffect::get_Path](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/imotioneffect/get_path/). [IMotionPath](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/imotionpath/) lagrar bankommandona.

| Kommando | Punkter | Betydelse |
| --- | --- | --- |
| MoveTo | Ett | Ställ in startpositionen. |
| LineTo | Ett | Flytta längs ett rakt segment till dess slutpunkt. |
| CurveTo | Tre | Följ en kubisk kurva definierad av två kontrollpunkter och en slutpunkt. |
| CloseLoop | Ingen | Återgå till startpositionen. |
| End | Ingen | Avsluta strålen. |

[MotionPathPointsType](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/motionpathpointstype/) beskriver punkt‑redigeringskaraktäristika, såsom hörn‑ eller släta punkter. Det ersätter inte kommandotypen. Använd en kurvpunkttyp för kurvexemplet nedan, och en hörnpunkttyp för de raka segmenten.

Bananormering är relativ till bildens dimensioner: en X‑förskjutning på 0,25 motsvarar en fjärdedel av bildens bredd, inte 0,25 punkt. Positiv Y går neråt. Absoluta kommandon anger positioner i banans koordinatsystem; relativa kommandon anger förskjutningar från aktuell position. Detta är separat från [get_Origin](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/imotioneffect/get_origin/), som väljer banans referensram, och [get_PathEditMode](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/imotioneffect/get_patheditmode/), som styr hur banan rör sig när formen flyttas.

### **Skapa en rak väg**

Skapa ett rörelsbeteende med en startpunkt, ett rakt segment och ett end‑kommando. [IMotionPath::Add](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/imotionpath/add/) tar kommandotyp, dess punkter, punkt‑typ och en flagga för relativ koordinat.

Startkommandot etablerar (0, 0), och linjen avslutas vid (0.25, 0), vilket ger vägen en horisontell förflyttning på en fjärdedel av bildbredden. End‑kommandot har inga koordinatpunkter. När banan är tilldelad kopplas rörelsbeteendet till effekten och förbinder vägen med rektangeln.

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

`motion.pptx` innehåller ett rörelsbeteende med tre bankommandon. Följande fil‑redigeringsexempel använder denna kända struktur.

### **Jämför absoluta och relativa koordinater**

Dessa två banobjekt beskriver samma rutt. Det absoluta kommandot slutar vid (0.3, 0.1); det relativa kommandot lägger till (0.1, 0.1) till den aktuella positionen, (0.2, 0).

Båda banorna startar på samma position. För den relativa linjen lägger du till dess X‑ och Y‑förskjutningar på den aktuella positionen för att få slutpunkten; för den absoluta linjen läser du slutpunkten direkt. Att byta flaggan utan att konvertera koordinaterna skulle beskriva en annan rutt.

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

Tilldela antingen bana till ett rörelsbeteende för att använda den i en presentation. Det sista booleska argumentet väljer relativa koordinater för det kommandot.

### **Ersätt en linje med en kurva**

Öppna `motion.pptx` och ersätt dess linjekommando med en kubisk kurva. Förse först de två kontrollpunkterna och sedan slutpunkten.

Startpositionen levereras av föregående kommando. De två första punkterna formar kurvan, medan den tredje är dess destination; de är inte tre på varandra följande destinationer. Att uppdatera kommandotyp, punkt‑redigeringstyp och punktarray tillsammans håller segmentet i linje med dess nya geometri.

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

Banan i `curve.pptx` har fortfarande tre kommandon; dess mellersta kommando definierar nu en kurva.

## **Inspektera och redigera en sparad stråle**

Varje [IMotionCmdPath](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/imotioncmdpath/) exponerar [get_Points](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/imotioncmdpath/get_points/), [get_CommandType](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/imotioncmdpath/get_commandtype/), [get_PointsType](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/imotioncmdpath/get_pointstype/), och [get_IsRelative](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/imotioncmdpath/get_isrelative/). Följande exempel använder den kända tre‑kommandobanan i `motion.pptx`. För godtycklig indata, lokalisera den avsedda effekten och kontrollera kommandotyper och antal punkter innan redigering via index.

### **Läs kommandon och koordinater**

Läs banan utan att ändra den. End‑ och close‑loop‑kommandon kräver inga punkter, så tillåt en null‑punktarray.

Utdata parar varje kommando med dess relativ‑koordinat‑flagga innan punkterna listas. Detta låter dig skilja en slutpunkt från en förskjutning innan du modifierar banan. En kurva skulle lista tre punkter, medan den raka linjen i denna fil listar endast en.

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

Listan innehåller en startpunkt, en absolut linje som slutar vid (0.25, 0), och ett end‑kommando.

### **Ändra en slutpunkt**

Öppna `motion.pptx` och ersätt linjens punktarray för att flytta dess slutpunkt.

I indatafilen är index 0 startkommandot och index 1 linjen. Att ersätta linjens enda punkt förändrar dess destination utan att ändra kommandotyp, timing eller position i samlingen. Eftersom kommandot använder absoluta koordinater specificerar det nya paret en position snarare än en tillagd förskjutning.

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

Linjen i `motion-endpoint.pptx` slutar vid (0.4, 0.1); originalfilen är oförändrad.

### **Ersätt ett segment**

Använd [Insert](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/imotionpath/insert/) och [RemoveAt](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/imotionpath/removeat/) för att ersätta linjen i `motion.pptx`. Inmatning flyttar den gamla linjen till index 2.

Detta demonstrerar att man ersätter ett kommandobjekt istället för att redigera dess befintliga koordinater. Efter insättning innehåller samlingen tillfälligt startkommandot, den nya linjen, den gamla linjen och end‑kommandot. Att ta bort index 2 kastar den gamla linjen och lämnar den nya vägen på plats.

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

Den sparade banan har fortfarande tre kommandon, med den nya linjen som slutar vid (0.2, 0.1) och end‑kommandot sist.

## **Modifiera och verifiera ett befintligt beteende**

När beteendets index är okänt, välj det efter typ. Detta exempel öppnar `rotation.pptx`, hittar dess [IRotationEffect](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/irotationeffect/), ändrar vinkeln och kontrollerar det sparade värdet efter återöppning.

Typkontrollen gör att loopen hoppar över beteenden som inte är rotationer. Den andra laddningen läser den sparade filen i ett separat presentationsobjekt, så jämförelsen kontrollerar bestående data snarare än värdet som fortfarande finns i minnet. Detta exempel förutsätter fortfarande att den kända effekten är den första i huvudsekvensen; att välja ett beteende efter typ hittar inte nödvändigtvis rätt effekt i en godtycklig presentation.

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

Utdata är `Rotation preserved: True`. Använd samma typ‑kontrollmönster för andra beteenden. För en komplett bevarande‑kontroll, jämför målformen, effekten, beteendetyper och ordning, timing samt ban‑kommandon. Använd en numerisk tolerans för flyttalsvärden. För en presentation med okänt animationslayout, se [Read Shape Animations](/slides/sv/cpp/shape-animation/#read-shape-animations) för traversal av huvud‑ och interaktiva sekvenser.

## **Beteendeordning, förinställningar och uppspelning**

Ordningen i [IBehaviorCollection](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/ibehaviorcollection/) är den lagrade ordningen för en effektens operationer. Det är inte en spellista där varje beteende automatiskt väntar på det föregående. Timing och den omslutande effekten bestämmer schemaläggning. Beteenden kan överlappa, och operationer på samma egenskap kan interagera via [get_Additive](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/ibehavior/get_additive/) och [get_Accumulate](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/ibehavior/get_accumulate/). Använd inte enbart omordning av samlingen för att schemalägga “flytta, sedan rotera”; använd explicit timing eller separata effekter som beskrivs i [Shape Animation](/slides/sv/cpp/shape-animation/).

Effektens [get_Type](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/ieffect/get_type/) och [get_Subtype](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/ieffect/get_subtype/) beskriver dess förinställning. De är inte en komplett beskrivning av ett redigerat beteendeträd. Välj förinställning och undertyp innan du anpassar beteenden: att ändra förinställningen kan bygga om samlingen och kasta dina egna operationer. Till exempel kan en anpassad Spin‑effekt som ändras till Fade ersätta dess rotationsbeteende med set‑ och filter‑beteenden. Inspektera samlingen igen efter att du ändrat en förinställning eller undertyp. Att rensa förinställda beteenden kan också ta bort synlighets‑ eller initieringsoperationer som förinställningen behöver. Exemplen använder medvetet synliga former och ersätter beteendena; de återskapar inte varje förinställnings implementation.

## **Formatkompatibilitet**

Ett bevarat beteendeträd garanterar inte identisk uppspelning i varje visare eller exportrenderare. Kontrollera sparad data och renderad utmatning separat.

| Format eller utdata | Vad som ska verifieras |
| --- | --- |
| PPTX | Använd som primärt format för dessa exempel. Öppna den igen för att verifiera det redigerbara beteendetreet, och kontrollera uppspelning i avsedd PowerPoint‑version. |
| PPT | Äldre binärt format kan skilja sig från PPTX. Testa en separat spara‑och‑öppna‑cykel och uppspelning; dra inte slutsatsen att alla egna kombinationer stöds enbart på grund av lyckad PPTX‑utmatning. |
| PDF, PNG, JPEG och andra statiska bildbilder | Innehåller en statisk bildrepresentation, inte en spelbar beteendetidslinje eller en garanterad slutanimation. |
| [HTML5](/slides/sv/cpp/export-to-html5/) | Kan spela stödjade animationer när formanimation är aktiverad i exportalternativen. Testa egna kombinationer i webbläsaren. |
| [Animated GIF](/slides/sv/cpp/convert-powerpoint-to-animated-gif/) | Sparar renderade bildrutor, inte redigerbara beteenden eller klickutlösta interaktioner. Kontrollera den faktiska renderade rörelsen. |
| [Video](/slides/sv/cpp/convert-powerpoint-to-video/) | Renderar animationsbilder och kodar dem som video. Stödet är begränsat till renderarens [stödda animationer och effekter](/slides/sv/cpp/convert-powerpoint-to-video/#supported-animations-and-effects); kommandon och interaktiva händelser blir inte en redigerbar tidslinje. |

## **FAQ**

**Varför innehåller min effekt beteenden innan jag har lagt till någon?**

En fördefinierad effekt kan skapa sina underliggande operationer. Inspektera dem innan du bestämmer dig för att utöka förinställningen eller ersätta dess beteenden.

**Gör att flytta ett beteende till början att det spelas först?**

Inte nödvändigtvis. Samlingsordning ersätter inte timing. Kontrollera fördröjningar, varaktigheter och interaktioner mellan operationer på samma egenskap.

**Varför har ett end‑kommando inga punkter?**

Det markerar slutet på banan och kräver inga koordinater. Kontrollera en null‑punktarray när du inspekterar en bana som lästs från en fil.

**Är en lyckad rundresa tillräcklig för att bekräfta uppspelning?**

Nej. Återöppning bekräftar bevarandet av de egenskaper du kontrollerade. Testa bildspels‑spelaren eller den animerade exporten separat för att bekräfta dess visuella beteende.