---
title: Egyéni animációs viselkedések létrehozása és módosítása C++-ban
linktitle: Egyéni animáció
type: docs
weight: 151
url: /hu/cpp/custom-animation/
keywords:
- egyéni animáció
- animációs viselkedés
- mozgásútvonal
- PowerPoint
- prezentáció
- C++
- Aspose.Slides
description: "Egyéni animációs viselkedések és szerkeszthető mozgásútvonalak létrehozása, ellenőrzése és módosítása PowerPoint prezentációkban az Aspose.Slides for C++ segítségével."
---
## **Áttekintés**

Az egyéni animációs viselkedések lehetővé teszik, hogy egy animációs effektuson belül egyedi műveleteket irányítsunk, például szín megváltoztatását, alakzat forgatását vagy egy szerkeszthető mozgási útvonal követését. Ez az útmutató bemutatja, hogyan hozhatunk létre és kombinálhatunk viselkedéseket, hogyan állíthatjuk be azok időzítését, hogyan vizsgálhatjuk és módosíthatjuk a meglévő animációkat, valamint hogyan ellenőrizhetjük, hogy a tulajdonságaik megmaradnak-e a prezentáció mentése és újbóli megnyitása után.

Előre meghatározott effektusok és kattintás‑aktiválók esetén lásd a [Shape Animation](/slides/hu/cpp/shape-animation/)-t.

## **Az animációs modell megértése**

Az animáció a következő struktúrában van szervezve: **Timeline → Sequence → Effect → Behaviors**:

- A dián található [get_Timeline](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ibaseslide/get_timeline/) a fő szekvenciát és az interaktív szekvenciákat tartalmazza.
- Egy [ISequence](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/isequence/) effektusokat tartalmaz, amelyek különböző alakzatokra irányulhatnak.
- Egy [IEffect](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/ieffect/) meghatározza a célt alakzatot, az előre beállított effektust, az al‑típust és az effektus időzítését.
- [IEffect::get_Behaviors](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/ieffect/get_behaviors/) tartalmazza azokat a műveleteket, amelyek megvalósítják az effektust: szín megváltoztatása, mozgatás, forgatás, tulajdonság beállítása stb.

## **Egyéni viselkedések létrehozása**

Hívja meg az [ISequence::AddEffect](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/isequence/addeffect/) metódust egy effektus létrehozásához, majd érje el annak [get_Behaviors](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/ieffect/get_behaviors/) gyűjteményét. Egy előre beállított effektus automatikusan feltöltheti ezt a gyűjteményt. Bővítse a preset műveleteit, vagy használja a [Clear](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/ibehaviorcollection/clear/) metódust, ha szándékosan felül akarja írni őket.

[IBehaviorFactory](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/ibehaviorfactory/) a lent illusztrált nyolc viselkedéstípust hozza létre. A mozgás a [Build a Motion Path](#build-a-motion-path) szekcióban kerül tárgyalásra. Minden létrehozási példa egy önálló kódrészlet, amely egy függvényen belül futtatható; a későbbi szerkesztési példák megadják, melyik kimeneti fájlt használják.

### **Forgatás**

Használja a [CreateRotationEffect](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/ibehaviorfactory/createrotationeffect/) metódust egy forgatás létrehozásához. A [get_By](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/irotationeffect/get_by/) relatív szöget ad meg fokban; a [get_From](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/irotationeffect/get_from/) és a [get_To](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/irotationeffect/get_to/) a kezdő‑ és végpontokat határozzák meg.

A példa egy Spin effektussal indul, lecseréli annak preset műveleteit egy forgatásra, és két másodperces időtartamot ad neki. A 90 fokos relatív szög egy negyedfordulatot jelent az alakzat kiinduló orientációjához képest, ezért a kezdő szög megadása nem szükséges.

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

`rotation.pptx` egy alakzatot és egy forgatási viselkedést tartalmaz. Az alábbi gyűjtemény‑, időzítési‑ és forgatás‑szerkesztési példák ehhez a fájlhoz kapcsolódnak.

### **Méretezés**

Használja a [CreateScaleEffect](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/ibehaviorfactory/createscaleeffect/) metódust X/Y százalékos értékekkel: a [get_From](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/iscaleeffect/get_from/) és a [get_To](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/iscaleeffect/get_to/) a kiinduló és végső méretet írják le, míg a [get_By](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/iscaleeffect/get_by/) egy relatív változást ad meg. Itt a 100 az eredeti méretet jelenti.

A példa mindkét dimenziót 100 %‑ról 125 %‑ra növeli két másodperc alatt. Azonos vízszintes és függőleges százalékok megtartják az alakzat arányait; különböző százalékok nyújtanak egy dimenziót a másikhoz képest.

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

### **Szín**

Használja a [CreateColorEffect](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/ibehaviorfactory/createcoloreffect/) metódust a kitöltés kék színről narancssárgára változtatásához. A [get_From](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/icoloreffect/get_from/) és a [get_To](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/icoloreffect/get_to/) színek; a [get_By](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/icoloreffect/get_by/) színeltolást jelent. Az [IBehavior::get_Properties](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/ibehavior/get_properties/) az animált attribútumot azonosítja.

Az alakzat szilárd kitöltése kék színre van inicializálva, ami megegyezik az animáció kezdőszínével. A kitöltés‑szín attribútum kiválasztása azt mondja a viselkedésnek, melyik alakzatrészt kell módosítania; a színek önmagukban nem határozzák meg az attribútumot. A mentett effektus két másodperces átmenetet ír le narancssárgára.

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

### **Szűrő**

Használja a [CreateFilterEffect](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/ibehaviorfactory/createfiltereffect/) metódust egy törlés kiválasztásához. A [get_Type](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/ifiltereffect/get_type/), a [get_Subtype](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/ifiltereffect/get_subtype/) és a [get_Reveal](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/ifiltereffect/get_reveal/) a szűrőt, az irányt és azt határozzák meg, hogy a forma megjelenik vagy elrejtődik.

Ez a példa egy két másodperces törlést konfigurál, amely a jobb‑irányú al‑típussal jeleníti meg az alakzatot. A szűrő beállítások a viselkedéshez tartoznak az effektuson belül, ezért a preset eredeti műveleteinek eltávolítása után kerülnek beállításra.

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

### **Tulajdonság**

Használja a [CreatePropertyEffect](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/ibehaviorfactory/createpropertyeffect/) metódust az átlátszóság animálásához. A [get_From](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/ipropertyeffect/get_from/), a [get_To](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/ipropertyeffect/get_to/) és a [get_By](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/ipropertyeffect/get_by/) karakterláncok, amelyeket a [get_ValueType](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/ipropertyeffect/get_valuetype/) és a [get_CalcMode](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/ipropertyeffect/get_calcmode/) értelmez. Válasszon végpontokat vagy relatív eltolást, ahelyett, hogy mindhárom értéket egyszerre állítaná be.

Itt a kiválasztott attribútum az átlátszóság, a numerikus karakterláncok pedig a 25 %‑os átlátszóságtól a teljes átlátszóságig tartó változást jelentik. A lineáris interpoláció fokozatos változást ír le ezek között az értékek között. Ha a példát más attribútumra alkalmazza, válassza ki a megfelelő értéktípust és végpontértékeket.

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

### **Beállítás**

Használja a [CreateSetEffect](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/ibehaviorfactory/createseteffect/) metódust a láthatóság hozzárendeléséhez a [get_To](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/iseteffect/get_to/) segítségével. A set viselkedés nem interpolál a végpontok között.

A példa a láthatóság attribútumát választja, és a viselkedés futásakor a `visible` karakterláncot állítja be. C++‑ban a karakterláncot objektummá kell csomagolni, mielőtt a set viselkedésnek átadná. A téglalap már látható ebben a minimális prezentációban, ezért a beállítás önmagában nem biztos, hogy nyilvánvaló vizuális változást eredményez. Egy ilyen művelet hasznos lehet egy nagyobb effektus részeként, amely szabályozza, mikor válik az alakzat rejtetté vagy láthatóvá.

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

### **Parancs**

Használja a [CreateCommandEffect](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/ibehaviorfactory/createcommandeffect/) metódust, és konfigurálja a [get_Type](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/icommandeffect/get_type/), a [get_CommandString](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/icommandeffect/get_commandstring/) és a [get_ShapeTarget](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/icommandeffect/get_shapetarget/) értékeket. Helyezze a `sample.wav` nevű WAV‑felvételt a munkakönyvtárba. Ez a példa a [AddAudioFrameEmbedded](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishapecollection/addaudioframeembedded/) segítségével ágyazza be, és egy lejátszási parancsot csatol az audio‑kerethez.

Az audio‑keret egyszerre az effektus célpontja és a parancs célpontja. Így a lejátszási kérés az beágyazott felvételhez kapcsolódik; a parancskarakterlánc önmagában nem határozza meg, melyik médiaobjektumot kell vezérelni. Az effektust kattintásra, a diavetítés közben indítják el.

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

A mentés a `command.pptx` fájlba helyezi a parancsot; ez nem játsza le a felvételt. A lejátszáshoz olyan diavetítést kell használni, amely támogatja a parancsot és a média‑célpontot.

## **A viselkedésgyűjtemény kezelése**

[IBehaviorCollection](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/ibehaviorcollection/) támogatja az [Add](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/ibehaviorcollection/add/), [Insert](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/ibehaviorcollection/insert/), [Remove](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/ibehaviorcollection/remove/) és a [RemoveAt](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/ibehaviorcollection/removeat/) metódusokat. Ez a példa megnyitja a `rotation.pptx` fájlt, hozzáad egy méretezést, a forgatás előtt helyezi el, majd eltávolítja a forgatást. Egy objektum eltávolítása és újra beszúrása megváltoztatja a tárolt pozíciót, anélkül, hogy másolatot hozna létre.

A szerkesztések sorozata a gyűjteményt a forgatás‑méretezésről méretezés‑forgatásra, majd csak méretezésre módosítja. Az indexek az aktuális gyűjteményre vonatkoznak, ezért az eltávolítás a forgatás új indexét használja a rendezés után. A végső felsorolás megmutatja, melyik viselkedés lesz mentve.

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

A kimenet `ScaleEffect`: csak a méretezés maradt. A gyűjtemény sorrendje önmagában nem ütemezi a viselkedéseket egymás után. A gyűjteményt csak akkor kell törölni, ha az összes műveletet felül kívánja írni.

## **A viselkedés időzítésének beállítása**

[IBehavior::get_Timing](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/ibehavior/get_timing/) a [ITiming](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/itiming/) objektumot teszi elérhetővé, függetlenül az [IEffect::get_Timing](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/ieffect/get_timing/)-tól. Az effektus időzítése az egész effektust időzíti; a viselkedés időzítése egy adott műveletet belül.

### **Időtartam, késleltetés, ismétlés és gyorsulás beállítása**

Nyissa meg a `rotation.pptx` fájlt, és állítsa be a [get_Duration](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/itiming/get_duration/) és a [get_TriggerDelayTime](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/itiming/get_triggerdelaytime/) értékeket másodpercben, majd konfigurálja a [get_RepeatCount](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/itiming/get_repeatcount/)-ot. A [get_Accelerate](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/itiming/get_accelerate/) és a [get_Decelerate](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/itiming/get_decelerate/) a teljes időtartam tört részei; azok összege legfeljebb 1 legyen.

A bemeneti fájl a forgatási példában létrehozott fájl, ahol az első viselkedés ismert, hogy forgatás. Ez a példa csak ennek a viselkedésnek az időzítését módosítja; a 90‑fokos szög változatlan marad. Az időzítés és a szög szétválasztása megkönnyíti a tempó módosítását anélkül, hogy újra felépítené az animációt.

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

A viselkedés két másodperces időtartammal, fél másodperces késleltetéssel és 3‑szori ismétléssel rendelkezik. Az időtartam első és utolsó 20 %-a a gyorsulásra és lassulásra van fenntartva.

Egyéb ismétlési beállítások: [get_RepeatDuration](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/itiming/get_repeatduration/), [get_RepeatUntilEndSlide](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/itiming/get_repeatuntilendslide/), és [get_RepeatUntilNextClick](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/itiming/get_repeatuntilnextclick/); válasszon egyet, ahelyett, hogy mindet egyszerre engedélyezné. A [get_AutoReverse](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/itiming/get_autoreverse/) a animációt visszafelé játssza le a előrehaladást követően. A gyorsulás és lassulás folytonos változásokra vonatkozik, nem pedig diszkrét hozzárendelésekre vagy parancsokra.

## **Mozgásútvonal létrehozása**

Használja a [CreateMotionEffect](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/ibehaviorfactory/createmotioneffect/) metódust a mozgás létrehozásához. A [get_From](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/imotioneffect/get_from/), a [get_To](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/imotioneffect/get_to/) és a [get_By](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/imotioneffect/get_by/) százalékos koordinátákat vagy eltolásokat ír le. Szerkeszthető útvonalhoz hozza létre a [MotionPath](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/motionpath/) objektumot, és rendelje hozzá az [IMotionEffect::get_Path](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/imotioneffect/get_path/)‑hez. Az [IMotionPath](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/imotionpath/) tárolja az útparancsokat.

[MotionCommandPathType](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/motioncommandpathtype/) a műveletet választja ki:

| Parancs | Pontok | Jelentés |
| --- | --- | --- |
| MoveTo | Egy | A kezdőpozíció beállítása. |
| LineTo | Egy | Egyenes szegmens mentén mozog a végpontjáig. |
| CurveTo | Három | Követ egy köbös ívet két vezérlőponttal és egy végponttal. |
| CloseLoop | Nincs | Visszatér a kezdőpozícióba. |
| End | Nincs | Az útvonal befejezése. |

[MotionPathPointsType](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/motionpathpointstype/) a pontszerkesztési jellemzőket írja le, például sarok‑ vagy sima pontokat. Nem helyettesíti a parancstípust. Használjon ív‑pont típust az alább látható ív‑példához, és sarok‑pont típust az egyenes szakaszokhoz.

Az útvonal koordinátái a diák méreteihez vannak normalizálva: a 0.25‑os X‑eltolás a dia szélességének egynegyedét jelenti, nem 0.25 pontot. A pozitív Y lefelé fut. Az abszolút parancsok a koordináta‑rendszerben határozzák meg a pozíciót; a relatív parancsok a jelenlegi pozícióhoz viszonyított eltolást jelölik. Ez különbözik a [get_Origin](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/imotioneffect/get_origin/) beállítástól, amely az útvonal referenciakeretét választja, és a [get_PathEditMode](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/imotioneffect/get_patheditmode/)-tól, amely szabályozza, hogyan mozog az útvonal, ha az alakzatot mozgatják.

### **Egyenes útvonal létrehozása**

Hozzon létre egy mozgás‑viselkedést egy kezdőponttal, egy egyenes szegmenssel és egy befejező parancssal. Az [IMotionPath::Add](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/imotionpath/add/) a parancstípust, annak pontjait, a ponttípust és a relatív‑koordináta jelzőt veszi fel.

A kezdőparancs (0, 0)-t állít be, a vonal pedig (0.25, 0)-ra végződik, így a útvonal a dia szélességének egynegyedét teszi ki vízszintesen. A befejező parancsnak nincsenek koordinátapontjai. Az útvonal hozzárendelése után a mozgás‑viselkedés hozzáadása az effektushoz összekapcsolja az útvonalat a téglalappal.

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

`motion.pptx` egy mozgás‑viselkedést három útparancssal tartalmaz. Az alábbi fájlszerkesztési példák ezt a struktúrát használják.

### **Abszolút és relatív koordináták összehasonlítása**

Ez a két útobjektum ugyanazt az útvonalat írja le. Az abszolút parancs (0.3, 0.1)-re végződik; a relatív parancs (0.1, 0.1)-et ad a jelenlegi pozícióhoz, ez pedig (0.2, 0)-t eredményez.

Mindkét út ugyanazzal a pozícióval indul. Relatív vonal esetén adja hozzá az X és Y eltolásokat a jelenlegi pozícióhoz a végpont meghatározásához; abszolút vonal esetén a végpontot közvetlenül olvassa. A jelző megváltoztatása a koordináták konvertálása nélkül más útvonalat eredményezne.

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

Rendelje hozzá bármelyik útvonalat egy mozgás‑viselkedéshez, hogy használja a prezentációban. A végső logikai argumentum a relatív koordinátákat jelöli azon parancshoz.

### **Vonal helyettesítése ívvel**

Nyissa meg a `motion.pptx` fájlt, és cserélje le a vonalparancsot egy köbös ívre. Először adja meg a két vezérlőpontot, majd a végpontot.

A kezdőpozíciót az előző parancs biztosítja. Az első két pont formálja az ívet, a harmadik a célpont; nem három egymást követő célpontokról van szó. A parancstípus, a pontszerkesztési típus és a ponttömb egyszerre történő frissítése teszi a szegmenst konzisztenssé az új geometriával.

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

A `curve.pptx` útvonalban továbbra is három parancs van; a középső parancs most egy ívet definiál.

## **Mentett útvonal vizsgálata és szerkesztése**

Minden [IMotionCmdPath](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/imotioncmdpath/) a [get_Points](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/imotioncmdpath/get_points/), a [get_CommandType](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/imotioncmdpath/get_commandtype/), a [get_PointsType](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/imotioncmdpath/get_pointstype/) és a [get_IsRelative](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/imotioncmdpath/get_isrelative/) metódusokat biztosítja. Az alábbi példák a `motion.pptx` háromparancsos útvonalat használják. Általános bemenet esetén keresse meg a kívánt effektust, és ellenőrizze a parancstípusokat és a pontszámokat, mielőtt indexek alapján szerkesztené.

### **Parancsok és koordináták olvasása**

Olvassa be az útvonalat változtatás nélkül. A vég‑ és a close‑loop parancsok nem igényelnek pontokat, ezért engedélyezze a null ponttömböt.

A kimenet minden parancshoz hozzárendeli a relatív‑koordináta jelzőjét, mielőtt felsorolja a pontjait. Ez lehetővé teszi, hogy a módosítás előtt megkülönböztesse a végpontot az eltolástól. Egy ív három pontot sorol fel, míg ebben a fájlban a egyenes vonal csak egyet.

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

A lista egy kezdőpontot, egy abszolút vonalat (0.25, 0) végponttal és egy end‑parancsot tartalmaz.

### **Végpont módosítása**

Nyissa meg a `motion.pptx` fájlt, és cserélje le a vonal ponttömbjét a végpont áthelyezéséhez.

A bemeneti fájlban a 0‑s index a kezdőparancs, az 1‑es index a vonal. A vonal egyetlen pontjának cseréje megváltoztatja a célpontot, anélkül, hogy a parancstípust, az időzítést vagy a gyűjteményben elfoglalt helyét módosítaná. Mivel a parancs abszolút koordinátákat használ, az új pár egy pozíciót ad meg, nem egy eltolást.

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

A `motion-endpoint.pptx` fájlban a vonal (0.4, 0.1)-re végződik; az eredeti fájl változatlan marad.

### **Szakasz cseréje**

Használja a [Insert](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/imotionpath/insert/) és a [RemoveAt](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/imotionpath/removeat/) metódusokat a vonal cseréjéhez a `motion.pptx`‑ben. A beszúrás a régi vonalat a 2‑es indexre helyezi.

Ez bemutatja egy parancsobjektum cseréjét a meglévő koordináták szerkesztése helyett. A beszúrás után a gyűjtemény ideiglenesen a kezdőparancsot, az új vonalat, a régi vonalat és a end‑parancsot tartalmazza. A 2‑es index eltávolítása eltávolítja a régi vonalat, és az új útvonal marad helyben.

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

A mentett útvonal továbbra is három parancsot tartalmaz, az új vonal (0.2, 0.1)-re végződik, az end‑parancs pedig utoljára szerepel.

## **Meglévő viselkedés módosítása és ellenőrzése**

Ha a viselkedés indexe ismeretlen, válassza ki típus szerint. Ez a példa megnyitja a `rotation.pptx`‑t, megtalálja az [IRotationEffect](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/irotationeffect/)‑et, módosítja a szöget, majd a megnyitás után ellenőrzi a mentett értéket.

A típusellenőrzés lehetővé teszi, hogy a ciklus átugorja a nem forgatási viselkedéseket. A második betöltés a mentett fájlt egy külön prezentációobjektumba olvassa be, így az összehasonlítás a perszisztált adatokat vizsgálja, nem a memóriában lévő értéket. Ez a példa továbbra is feltételezi, hogy a ismert effektus az első a fő szekvenciában; a típus szerinti kiválasztás nem feltétlenül helyezi el a megfelelő effektust egy tetszőleges prezentációban.

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

A kimenet `Rotation preserved: True`. Alkalmazza ugyanezt a típus‑ellenőrzési mintát más viselkedésekre is. Teljes megőrzés ellenőrzéséhez hasonlítsa össze a célalakzatot, az effektust, a viselkedéstípusokat és sorrendet, az időzítést, valamint az útparancsokat. A lebegőpontos értékekhez használjon numerikus tűréshatárt. Ismeretlen animációs elrendezésű prezentációkhoz lásd a [Read Shape Animations](/slides/hu/cpp/shape-animation/#read-shape-animations) útmutatót a fő‑ és interaktív szekvenciák bejárásához.

## **Viselkedés sorrend, presetek és lejátszás**

Az [IBehaviorCollection](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/ibehaviorcollection/) sorrendje az effektus műveleteinek tárolt sorrendje. Nem egy lejátszási lista, ahol minden viselkedés automatikusan megvárja az előzőt. Az időzítés és a körülvevő effektus határozza meg az ütemezést. A viselkedések átfedhetnek, és ugyanazon tulajdonságra vonatkozó műveletek kölcsönhatásba léphetnek a [get_Additive](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/ibehavior/get_additive/) és a [get_Accumulate](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/ibehavior/get_accumulate/) segítségével. Ne használja csak a gyűjtemény újrarendezését a „mozgatás, majd forgatás” ütemezésére; használjon explicit időzítést vagy külön effektusokat, ahogy a [Shape Animation](/slides/hu/cpp/shape-animation/)-ban le van írva.

Az effektus [get_Type](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/ieffect/get_type/) és [get_Subtype](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/ieffect/get_subtype/) leírja a presetet. Ezek nem adnak teljes leírást egy szerkesztett viselkedésfáról. Válassza ki a presetet és az al‑típust, mielőtt testreszabná a viselkedéseket: a preset módosítása újraépítheti a gyűjteményt, és eldobhatja az egyéni műveleteket. Például egy testreszabott Spin effektus Fade‑re változtatása felcserélheti a forgatási viselkedést set‑ és filter‑viselkedésekkel. A preset vagy al‑típus módosítása után ellenőrizze újra a gyűjteményt. A preset viselkedéseinek törlése eltávolíthatja a láthatóságot vagy inicializálást biztosító műveleteket is, amelyeket a preset igényel. A példák szándékosan látható alakzatokat használnak, és a viselkedéseket helyettesítik; nem építik újra minden preset implementációját.

## **Formátumkompatibilitás**

Egy megőrzött viselkedésfa nem garantálja az azonos lejátszást minden nézőben vagy exportálási renderelőben. Ellenőrizze a mentett adatokat és a renderelt kimenetet külön-külön.

| Formátum vagy kimenet | Mit kell ellenőrizni |
| --- | --- |
| PPTX | Használja elsődleges formátumként ezeket a példákat. Nyissa meg újra a fájlt a szerkeszthető viselkedésfa ellenőrzéséhez, majd ellenőrizze a lejátszást a cél PowerPoint‑verzióban. |
| PPT | Az örökölt bináris ábrázolás eltérhet a PPTX‑től. Teszteljen külön mentés‑újra‑megnyitás ciklust és lejátszást; ne vonjon le következtetést minden egyéni kombináció támogatottságáról a sikeres PPTX‑kimenet alapján. |
| PDF, PNG, JPEG és egyéb statikus diaképek | Statikus diaábrázolást tartalmaznak, nem játszható viselkedésidővonalat vagy garantált véganimációs képkockát. |
| [HTML5](/slides/hu/cpp/export-to-html5/) | Lejátszhatja a támogatott animációkat, ha a shape animation engedélyezve van az exportbeállításokban. Tesztelje az egyéni kombinációkat a böngészőben. |
| [Animated GIF](/slides/hu/cpp/convert-powerpoint-to-animated-gif/) | Renderelt képkockákat tárol, nem szerkeszthető viselkedéseket vagy kattintás‑alapú interakciót. Ellenőrizze a tényleges renderelt mozgást. |
| [Video](/slides/hu/cpp/convert-powerpoint-to-video/) | Rendereli az animációs képkockákat, és videóként kódolja. A támogatás korlátozott a renderelő [supported animations and effects](/slides/hu/cpp/convert-powerpoint-to-video/#supported-animations-and-effects) listájára; a parancsok és interaktív események nem válnak szerkeszthető idővonalárrá. |

## **GYIK**

**Miért tartalmaz effektusom viselkedéseket már a hozzáadás előtt?**

Egy előre definiált effektus létrehozhatja a mögöttes műveleteket. Tekintse át őket, mielőtt döntene a preset kibővítéséről vagy a viselkedéseinek helyettesítéséről.

**Ha a viselkedést a kezdetre helyezi, akkor először játszódik le?**

Nem feltétlenül. A gyűjtemény sorrendje nem helyettesíti az időzítést. Ellenőrizze a késleltetéseket, időtartamokat és a ugyanazon tulajdonságon végzett műveletek kölcsönhatását.

**Miért nincs pontja egy end‑parancsnak?**

Az end‑parancs jelzi az útvonal végét, és nincs szüksége koordinátákra. Az útvonal fájlból való beolvasásakor ellenőrizze a null ponttömböt.

**Elég egy sikeres körkörös mentés a lejátszás megerősítéséhez?**

Nem. A megnyitás csak a vizsgált tulajdonságok megőrzését erősíti meg. A diavetítő vagy az animált export külön tesztelése szükséges a vizuális viselkedés megerősítéséhez.