---
title: Vytvoření a úprava vlastních animačních chování v C++
linktitle: Vlastní animace
type: docs
weight: 151
url: /cs/cpp/custom-animation/
keywords:
- vlastní animace
- animační chování
- dráha pohybu
- PowerPoint
- prezentace
- C++
- Aspose.Slides
description: "Vytvořte, prohlédněte a upravte vlastní animační chování a editovatelné dráhy pohybu v prezentacích PowerPoint pomocí Aspose.Slides pro C++."
---
## **Přehled**

Vlastní animace umožňují řídit jednotlivé operace v rámci animačního efektu, jako je změna barvy, otáčení objektu nebo sledování editovatelné dráhy pohybu. Tento průvodce ukazuje, jak vytvářet a kombinovat chování, konfigurovat jejich časování, prohlížet a upravovat existující animace a ověřit, že jejich vlastnosti přežijí uložení a opětovné otevření prezentace.

Pro předdefinované efekty a spouštěče kliknutí viz [Animace tvarů](/slides/cs/cpp/shape-animation/).

## **Pochopit model animace**

Animace je organizována jako **Timeline → Sequence → Effect → Behaviors**:

- Časová osa snímku [get_Timeline](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ibaseslide/get_timeline/) obsahuje hlavní sekvenci a interaktivní sekvence.
- [ISequence](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/isequence/) obsahuje efekty, které mohou cílit na různé tvary.
- [IEffect](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/ieffect/) identifikuje cílový tvar, předvolbu, podtyp a časování efektu.
- [IEffect::get_Behaviors](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/ieffect/get_behaviors/) obsahuje operace, které implementují efekt: změna barvy, pohyb, otáčení, nastavení vlastnosti a podobně.

## **Vytvořit jednotlivé chování**

Vyvolejte [ISequence::AddEffect](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/isequence/addeffect/) k vytvoření efektu a přístupu k jeho kolekci [get_Behaviors](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/ieffect/get_behaviors/). Předvolba může tuto kolekci naplnit automaticky. Zachovejte její operace při rozšiřování předvolby nebo použijte [Clear](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/ibehaviorcollection/clear/) při úmyslné náhradě.

[IBehaviorFactory](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/ibehaviorfactory/) vytváří osm typů chování ilustrovaných níže. Pohyb je popsán v [Vytvoření dráhy pohybu](#vytvoření-dráhy-pohybu). Každý příklad tvorby je samostatný kód, který lze spustit ve funkci; pozdější příklady úprav uvádějí, který výstupní soubor používají.

### **Rotace**

Použijte [CreateRotationEffect](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/ibehaviorfactory/createrotationeffect/) k vytvoření rotace. [get_By](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/irotationeffect/get_by/) určuje relativní úhel ve stupních; [get_From](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/irotationeffect/get_from/) a [get_To](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/irotationeffect/get_to/) určují koncové body.

Příklad začíná efektem Spin, nahradí jeho přednastavené operace jedním chováním rotace a nastaví tomuto chování trvání dvě sekundy. Relativní úhel 90 stupňů představuje čtvrt otáčky od výchozí orientace tvaru, takže není potřeba explicitně zadávat výchozí úhel.

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

`rotation.pptx` obsahuje jeden tvar a jedno chování rotace. Kolekce, časování a příklady úprav rotace níže používají tento soubor.

### **Měřítko**

Použijte [CreateScaleEffect](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/ibehaviorfactory/createscaleeffect/) s procenty X/Y: [get_From](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/iscaleeffect/get_from/) a [get_To](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/iscaleeffect/get_to/) popisují počáteční a koncovou velikost, zatímco [get_By](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/iscaleeffect/get_by/) popisuje relativní změnu. Zde 100 znamená původní velikost.

Příklad zvětšuje obě rozměry ze 100 % na 125 % během dvou sekund. Používání stejných horizontálních i vertikálních procent zachovává proporce tvaru; odlišná procenta by natáhla jeden rozměr více než druhý.

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

### **Barva**

Použijte [CreateColorEffect](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/ibehaviorfactory/createcoloreffect/) ke změně výplně z modré na oranžovou. [get_From](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/icoloreffect/get_from/) a [get_To](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/icoloreffect/get_to/) jsou barvy; [get_By](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/icoloreffect/get_by/) je posun barvy. [IBehavior::get_Properties](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/ibehavior/get_properties/) identifikuje atribut, který se animuje.

Výplň tvaru je inicializována na modrou, což odpovídá výchozí barvě animace. Výběr atributu výplně říká chování, kterou část tvaru měnit; samotné koncové barvy tento atribut neidentifikují. Uložený efekt popisuje dvousekundový přechod na oranžovou.

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

### **Filtr**

Použijte [CreateFilterEffect](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/ibehaviorfactory/createfiltereffect/) k výběru setření. [get_Type](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/ifiltereffect/get_type/), [get_Subtype](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/ifiltereffect/get_subtype/) a [get_Reveal](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/ifiltereffect/get_reveal/) určují filtr, směr a zda má tvar odhalit nebo skrýt.

Tento příklad konfiguruje dvousekundové setření, které odhalí tvar pomocí podtypu pravý směr. Nastavení filtru patří k chování uvnitř efektu, takže jsou konfigurována po odstranění původních operací předvolby.

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

### **Vlastnost**

Použijte [CreatePropertyEffect](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/ibehaviorfactory/createpropertyeffect/) k animaci neprůhlednosti. [get_From](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/ipropertyeffect/get_from/), [get_To](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/ipropertyeffect/get_to/), a [get_By](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/ipropertyeffect/get_by/) jsou řetězce interpretované pomocí [get_ValueType](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/ipropertyeffect/get_valuetype/) a [get_CalcMode](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/ipropertyeffect/get_calcmode/). Vyberte koncové hodnoty nebo relativní posun místo nastavení všech tří najednou.

Zde je vybraný atribut neprůhlednost a číselné řetězce představují změnu z 25 % neprůhlednosti na plnou neprůhlednost. Lineární interpolace popisuje postupnou změnu mezi těmito hodnotami. Při adaptaci tohoto příkladu na jiný atribut zvolte typ hodnoty a koncové hodnoty odpovídající danému atributu.

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

### **Nastavení**

Použijte [CreateSetEffect](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/ibehaviorfactory/createseteffect/) k přiřazení viditelnosti pomocí [get_To](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/iseteffect/get_to/). Chování nastavení neinterpoluje mezi koncovými body.

Příklad vybere atribut viditelnosti a při spuštění chování přiřadí řetězec `visible`. V C++ zabalte řetězec jako objekt před přiřazením do chování nastavení. Obdélník je v této minimální prezentaci již viditelný, takže přiřazení nemusí samostatně vyvolat výraznou vizuální změnu. Taková operace je užitečná jako součást většího efektu, který také řídí, kdy se tvar skryje nebo zobrazí.

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

### **Příkaz**

Použijte [CreateCommandEffect](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/ibehaviorfactory/createcommandeffect/) a nakonfigurujte [get_Type](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/icommandeffect/get_type/), [get_CommandString](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/icommandeffect/get_commandstring/), a [get_ShapeTarget](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/icommandeffect/get_shapetarget/). Umístěte nahrávku WAV pojmenovanou `sample.wav` do pracovního adresáře. Tento příklad ji vloží pomocí [AddAudioFrameEmbedded](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ishapecollection/addaudioframeembedded/) a připojí příkaz přehrání k audio rámci.

Audio rámec je zároveň cílem efektu i cílem příkazu. To spojuje požadavek na přehrání s vloženou nahrávkou; samotný řetězec příkazu neidentifikuje, který multimediální objekt má být řízen. Efekt je nastaven tak, aby se spustil kliknutím během prezentace.

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

Uložení ukládá příkaz do `command.pptx`; nahrávka se nepřehraje. Přehrání vyžaduje přehrávač prezentací, který podporuje tento příkaz a jeho mediální cíl.

## **Správa kolekce chování**

[IBehaviorCollection](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/ibehaviorcollection/) podporuje [Add](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/ibehaviorcollection/add/), [Insert](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/ibehaviorcollection/insert/), [Remove](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/ibehaviorcollection/remove/), a [RemoveAt](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/ibehaviorcollection/removeat/). Tento příklad otevírá `rotation.pptx`, přidává měřítko, přesouvá jej před rotaci a odstraňuje rotaci. Odstranění a opětovné vložení stejného objektu mění jeho uloženou pozici, aniž by se vytvořila kopie.

Sekvence úprav mění kolekci z rotace–měřítko na měřítko–rotace a nakonec jen na měřítko. Indexy odkazují na aktuální kolekci, takže odstranění používá nový index rotace po přeuspořádání. Konečné výčtování potvrzuje, které chování bude uloženo.

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

Výstup je `ScaleEffect`: zůstane jen měřítko. Pořadí v kolekci samo o sobě neschraňuje chování za sebou. Kolekci vymažte pouze při úplné náhradě všech jejích operací.

## **Nastavení časování chování**

[IBehavior::get_Timing](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/ibehavior/get_timing/) vystavuje [ITiming](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/itiming/), nezávisle na [IEffect::get_Timing](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/ieffect/get_timing/). Časování efektu plánuje celý efekt; časování chování popisuje operaci uvnitř něj.

### **Nastavení trvání, zpoždění, opakování a zrychlení**

Otevřete `rotation.pptx` a nastavte [get_Duration](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/itiming/get_duration/) a [get_TriggerDelayTime](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/itiming/get_triggerdelaytime/) v sekundách, potom nakonfigurujte [get_RepeatCount](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/itiming/get_repeatcount/). [get_Accelerate](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/itiming/get_accelerate/) a [get_Decelerate](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/itiming/get_decelerate/) jsou zlomky trvání; jejich součet udržujte nejvýše 1.

Vstupní soubor je ten vytvořený v příkladu rotace, kde je první chování známé jako rotace. Tento příklad mění jen časování toho chování; úhel 90 ° zůstává nezměněn. Oddělení úhlu a časování usnadňuje úpravu tempa bez přestavování animace.

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

Chování používá dvousekundové trvání, půlsekundové zpoždění a počet opakování 3. Prvních a posledních 20 % trvání jsou využity pro zrychlení a zpomalení.

Další politiky opakování zahrnují [get_RepeatDuration](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/itiming/get_repeatduration/), [get_RepeatUntilEndSlide](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/itiming/get_repeatuntilendslide/), a [get_RepeatUntilNextClick](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/itiming/get_repeatuntilnextclick/); zvolte jednu politiku místo povolení všech najednou. [get_AutoReverse](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/itiming/get_autoreverse/) přehraje animaci zpět po dopředném průchodu. Zrychlení a zpomalení se vztahují k plynulým změnám, ne k diskrétním přiřazením nebo příkazům.

## **Vytvoření dráhy pohybu**

Použijte [CreateMotionEffect](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/ibehaviorfactory/createmotioneffect/) k vytvoření pohybu. Jeho [get_From](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/imotioneffect/get_from/), [get_To](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/imotioneffect/get_to/), a [get_By](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/imotioneffect/get_by/) popisují souřadnice nebo offsety založené na procentech. Pro editovatelnou trasu vytvořte [MotionPath](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/motionpath/) a přiřaďte ji k [IMotionEffect::get_Path](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/imotioneffect/get_path/). [IMotionPath](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/imotionpath/) uchovává příkazy cesty.

[MotionCommandPathType](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/motioncommandpathtype/) vybírá operaci:

| Příkaz | Body | Význam |
| --- | --- | --- |
| MoveTo | One | Nastaví počáteční pozici. |
| LineTo | One | Pohne se po přímém úseku k jeho koncovému bodu. |
| CurveTo | Three | Následuje kubickou křivku definovanou dvěma kontrolními body a koncovým bodem. |
| CloseLoop | None | Vrátí se na počáteční pozici. |
| End | None | Ukončí cestu. |

[MotionPathPointsType](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/motionpathpointstype/) popisuje vlastnosti úpravy bodu, jako je roh nebo hladký bod. Nenahrazuje typ příkazu. Použijte typ bodu křivky pro níže uvedený příklad křivky a typ rohového bodu pro přímé úseky.

Souřadnice cesty jsou normalizovány podle rozměrů snímku: posun X 0.25 představuje čtvrt šířky snímku, ne 0.25 bodů. Kladné Y běží dolů. Absolutní příkazy udávají pozice v souřadnicovém systému cesty; relativní příkazy udávají offsety od aktuální pozice. To je oddělené od [get_Origin](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/imotioneffect/get_origin/), který volí referenční rámec cesty, a [get_PathEditMode](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/imotioneffect/get_patheditmode/), který řídí, jak se cesta pohybuje při přesunu tvaru.

### **Vytvoření přímé dráhy**

Vytvořte chování pohybu s počátečním bodem, jedním přímým úsekem a příkazem konce. [IMotionPath::Add](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/imotionpath/add/) přijímá typ příkazu, jeho body, typ bodu a příznak relativní souřadnice.

Počáteční příkaz stanoví (0, 0) a čára končí v (0.25, 0), což dává trase horizontální posun o čtvrt šířky snímku. Příkaz konce nemá žádné souřadnicové body. Jakmile je cesta přiřazena, přidání chování pohybu k efektu připojí tuto trasu k obdélníku.

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

`motion.pptx` obsahuje jedno chování pohybu se třemi příkazy cesty. Následující příklady úprav souboru používají tuto známou strukturu.

### **Porovnání absolutních a relativních souřadnic**

Tyto dva objekty cesty popisují stejnou trasu. Absolutní příkaz končí v (0.3, 0.1); relativní příkaz přičte (0.1, 0.1) k aktuální pozici, tedy (0.2, 0).

Obě cesty začínají ve stejném bodě. Pro relativní úsečku přičtěte její offsety X a Y k aktuální pozici, abyste získali koncový bod; pro absolutní úsečku čtěte koncový bod přímo. Přepnutí příznaku bez konverze souřadnic by popisovalo jinou trasu.

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

Přiřaďte libovolnou cestu k chování pohybu, aby se použila v prezentaci. Konečný boolovský argument volí relativní souřadnice pro tento příkaz.

### **Nahrazení čáry křivkou**

Otevřete `motion.pptx` a nahraďte jeho příkaz čáry kubickou křivkou. Nejprve zadejte dva kontrolní body, následovaný koncovým bodem.

Počáteční pozice je určena předchozím příkazem. První dva body formují křivku, třetí je její cíl; nejsou to tři po sobě jdoucí cíle. Aktualizace typu příkazu, typu úpravy bodu a pole bodů současně udržuje segment v souladě s novou geometrií.

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

Cesta v `curve.pptx` stále má tři příkazy; její prostřední příkaz nyní definuje křivku.

## **Prohlížení a úprava uložené dráhy**

Každý [IMotionCmdPath](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/imotioncmdpath/) vystavuje [get_Points](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/imotioncmdpath/get_points/), [get_CommandType](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/imotioncmdpath/get_commandtype/), [get_PointsType](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/imotioncmdpath/get_pointstype/), a [get_IsRelative](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/imotioncmdpath/get_isrelative/). Následující příklady používají známou třípříkazovou cestu v `motion.pptx`. Pro libovolný vstup najděte požadovaný efekt a zkontrolujte typy příkazů a počty bodů před úpravou podle indexu.

### **Čtení příkazů a souřadnic**

Přečtěte cestu bez její změny. Příkazy End a CloseLoop nepotřebují body, takže umožněte nulové pole bodů.

Výstup spáruje každý příkaz s jeho příznakem relativní souřadnice před výpisem jeho bodů. To vám umožní rozlišit koncový bod od offsetu před úpravou cesty. Křivka by vypsala tři body, zatímco přímá čára v tomto souboru pouze jeden.

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

Výpis obsahuje počáteční bod, absolutní čáru končící v (0.25, 0) a příkaz End.

### **Změna koncového bodu**

Otevřete `motion.pptx` a nahraďte pole bodů čáry, aby se posunulo její koncové místo.

Ve vstupním souboru je index 0 počáteční příkaz a index 1 čára. Nahrazení jediného bodu čáry změní její cíl bez změny typu příkazu, časování nebo pozice v kolekci. Protože příkaz používá absolutní souřadnice, nový pár určuje pozici, nikoli přidaný offset.

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

Čára v `motion-endpoint.pptx` končí v (0.4, 0.1); původní soubor zůstává beze změny.

### **Nahrazení segmentu**

Použijte [Insert](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/imotionpath/insert/) a [RemoveAt](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/imotionpath/removeat/) k nahrazení čáry v `motion.pptx`. Vložení posune starou čáru na index 2.

Tento příklad ukazuje nahrazení objektu příkazu místo úpravy jeho existujících souřadnic. Po vložení kolekce dočasně obsahuje počáteční příkaz, novou čáru, starou čáru a příkaz End. Odstraněním indexu 2 se stará čára zahodí a nová trasa zůstane.

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

Uložená cesta stále má tři příkazy, přičemž nová čára končí v (0.2, 0.1) a příkaz End je poslední.

## **Úprava a ověření existujícího chování**

Když není známý index chování, vyberte jej podle typu. Tento příklad otevírá `rotation.pptx`, najde jeho [IRotationEffect](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/irotationeffect/), změní úhel a po opětovném otevření zkontroluje uloženou hodnotu.

Kontrola typu umožňuje smyčce přeskočit chování, která nejsou rotace. Druhé načtení načte uložený soubor do samostatného objektu prezentace, takže porovnání ověřuje trvalá data, ne hodnotu stále drženou v paměti. Tento příklad stále předpokládá, že známý efekt je první v hlavní sekvenci; výběr chování podle typu nenajde správný efekt v libovolné prezentaci.

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

Výstup je `Rotation preserved: True`. Použijte stejný vzor kontroly typu i u dalších chování. Pro úplnou kontrolu zachování porovnejte cílový tvar, efekt, typy a pořadí chování, časování a příkazy cesty. Použijte numerickou toleranci pro hodnoty s plovoucí řádovou čárkou. Pro prezentaci s neznámým rozvržením animací viz [Read Shape Animations](/slides/cs/cpp/shape-animation/#read-shape-animations) pro procházení hlavní a interaktivní sekvence.

## **Pořadí chování, předvolby a přehrávání**

Pořadí v [IBehaviorCollection](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/ibehaviorcollection/) je uložené pořadí operací efektu. Není to playlist, ve kterém každé chování automaticky čeká na předchozí. Časování a zahrnutý efekt určují plánování. Chování se mohou překrývat a operace na stejném atributu mohou interagovat přes [get_Additive](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/ibehavior/get_additive/) a [get_Accumulate](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/ibehavior/get_accumulate/). Nepoužívejte jen přeřazení kolekce k naplánování „přesun, pak rotace“; použijte explicitní časování nebo separátní efekty, jak je popsáno v [Animace tvarů](/slides/cs/cpp/shape-animation/).

Předvolba efektu [get_Type](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/ieffect/get_type/) a [get_Subtype](https://reference.aspose.com/slides/cs/cpp/aspose.slides.animation/ieffect/get_subtype/) popisují jeho přednastavení. Nejsou úplným popisem upraveného stromu chování. Vyberte předvolbu a podtyp před vlastním přizpůsobením chování: změna předvolby může přestavět kolekci a zahodit vaše vlastní operace. Například změna přizpůsobeného efektu Spin na Fade může nahradit jeho rotaci chováním set a filter. Po změně předvolby nebo podtypu znovu prohlédněte kolekci. Vymazání přednastavených chování může také odstranit operace viditelnosti nebo inicializace, které předvolba potřebuje. Příklady vědomě používají viditelné tvary a nahrazují chování; neprovádějí kompletní rekonstrukci implementace každé předvolby.

## **Kompatibilita formátů**

Uložený strom chování negarantuje identické přehrávání v každém prohlížeči nebo exportním rendereru. Zkontrolujte uložená data a renderovaný výstup odděleně.

| Formát nebo výstup | Co ověřit |
| --- | --- |
| PPTX | Použijte jako primární formát pro tyto příklady. Otevřete jej znovu pro ověření editovatelného stromu chování, pak zkontrolujte přehrávání ve zamýšlené verzi PowerPointu. |
| PPT | Dědictví binárního formátu může differovat od PPTX. Otestujte samostatný cyklus uložení‑otevření a přehrávání; nevyvozujte podporu pro každou vlastní kombinaci z úspěšného výstupu PPTX. |
| PDF, PNG, JPEG a další statické obrázky snímků | Obsahují statické znázornění snímku, ne přehratelnou časovou osu chování ani garantovaný finální animační rámec. |
| [HTML5](/slides/cs/cpp/export-to-html5/) | Může přehrávat podporované animace, pokud je v možnostech exportu povolena animace tvarů. Otestujte vlastní kombinace v prohlížeči. |
| [Animated GIF](/slides/cs/cpp/convert-powerpoint-to-animated-gif/) | Ukládá vykreslené snímky, ne editovatelná chování ani interakci na kliknutí. Zkontrolujte skutečný vykreslený pohyb. |
| [Video](/slides/cs/cpp/convert-powerpoint-to-video/) | Renderuje animační snímky a kóduje je jako video. Podpora je omezena na [podporované animace a efekty](/slides/cs/cpp/convert-powerpoint-to-video/#supported-animations-and-effects) renderera; příkazy a interaktivní události se nepřevádějí na editovatelnou časovou osu. |

## **Často kladené otázky**

**Proč můj efekt obsahuje chování, i když jsem žádné nepřidal?**

Vytvoření předdefinovaného efektu může vytvořit jeho podkladové operace. Prohlédněte si je, než se rozhodnete, zda rozšířit předvolbu nebo nahradit její chování.

**Způsobí přesunutí chování na začátek, že se přehraje jako první?**

Ne nutně. Pořadí v kolekci nenahrazuje časování. Zkontrolujte zpoždění, trvání a interakce mezi operacemi na stejném atributu.

**Proč má příkaz End žádné body?**

Označuje konec cesty a nepotřebuje souřadnice. Při prohlížení cesty načtené ze souboru zkontrolujte, zda není pole bodů nulové.

**Je úspěšný round‑trip dostačující k potvrzení přehrávání?**

Ne. Otevření souboru potvrzuje zachování zkontrolovaných vlastností. Otestujte přehrávač prezentací nebo animovaný export zvlášť, abyste potvrdili vizuální chování.