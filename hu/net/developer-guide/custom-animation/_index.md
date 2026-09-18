---
title: Egyéni animációs viselkedések létrehozása és módosítása .NET-ben
linktitle: Egyéni animáció
type: docs
weight: 151
url: /hu/net/custom-animation/
keywords:
- egyéni animáció
- animációs viselkedés
- mozgásútvonal
- PowerPoint
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Egyedi animációs viselkedések és szerkeszthető mozgásútvonalak létrehozása, vizsgálata és módosítása PowerPoint-prezentációkban az Aspose.Slides for .NET segítségével."
---
## **Áttekintés**

Az egyéni animációs viselkedések lehetővé teszik az animációs hatás egyes műveleteinek vezérlését, például egy szín megváltoztatását, egy alakzat forgatását, vagy egy szerkeszthető mozgásútvonal követését. Ez az útmutató bemutatja, hogyan hozhatunk létre és kombinálhatunk viselkedéseket, hogyan állíthatjuk be azok időzítését, hogyan vizsgálhatjuk és módosíthatjuk a meglévő animációkat, és hogyan ellenőrizhetjük, hogy a tulajdonságok megmaradnak-e a prezentáció mentése és újbóli megnyitása után.

Előre definiált hatások és kattintási aktiválók esetén lásd a [Alakzat animáció](/slides/hu/net/shape-animation/).

## **Ismerje meg az animációs modellt**

Az animáció úgy van felépítve, hogy **Idővonal → Sorozat → Hatás → Viselkedések**:

- A dia [Idővonal](https://reference.aspose.com/slides/hu/net/aspose.slides/ibaseslide/timeline/) tartalmazza a fő sorozatot és az interaktív sorozatokat.
- Az [ISequence](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/isequence/) hatásokat tartalmaz, amelyek esetleg különböző alakzatokra vonatkoznak.
- Az [IEffect](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/ieffect/) meghatározza a cél alakzatot, az előbeállítást, az altípust és a hatás időzítését.
- [IEffect.Behaviors](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/ieffect/behaviors/) tartalmazza a hatást megvalósító műveleteket: szín módosítása, mozgatás, forgatás, tulajdonság beállítása stb.

## **Egyéni viselkedések létrehozása**

Hívja a [ISequence.AddEffect](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/isequence/addeffect/) metódust egy hatás létrehozásához, és a [Behaviors](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/ieffect/behaviors/) gyűjtemény eléréséhez. Egy előre beállított sablon automatikusan feltöltheti ezt a gyűjteményt. Tartsa meg a műveleteket a sablon kibővítésekor, vagy használja a [Clear](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/ibehaviorcollection/clear/) metódust, ha szándékosan felül szeretné írni őket.

[IBehaviorFactory](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/ibehaviorfactory/) létrehozza az alább bemutatott nyolc viselkedéstípust. A mozgás részletezve van a [Mozgásútvonal létrehozása](#build-a-motion-path) című részben. Minden létrehozási példa egy teljes program; a későbbi szerkesztési példák jelzik, melyik kimeneti fájlt használják.

### **Rotáció**

Használja a [CreateRotationEffect](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/ibehaviorfactory/createrotationeffect/) metódust egy forgatás létrehozásához. A [By](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/irotationeffect/by/) relatív szöget ad meg fokban; a [From](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/irotationeffect/from/) és a [To](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/irotationeffect/to/) a végpontokat határozza meg.

A példa egy Spin hatással kezdődik, helyettesíti annak előbeállított műveleteit egy forgatási viselkedéssel, és a műveletnek kétmásodperces időtartamot ad. A 90 fokos relatív szög a alakzat kiindulási tájolásának negyedfordulóját jelenti, ezért nincs szükség kifejezett kiindulási szögre.

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

`rotation.pptx` egy alakzatot és egy forgatási viselkedést tartalmaz. Az alábbi gyűjtemény, időzítés és forgatás‑szerkesztési példák ezt a fájlt használják.

### **Méretezés**

Használja a [CreateScaleEffect](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/ibehaviorfactory/createscaleeffect/) metódust X/Y százalékokkal: a [From](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/iscaleeffect/from/) és a [To](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/iscaleeffect/to/) a kiinduló és a végső méretet írja le, míg a [By](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/iscaleeffect/by/) egy relatív változást ad meg. Itt a 100 az eredeti méretet jelenti.

A példa mindkét dimenziót 100 %‑ról 125 %‑ra növeli két másodperc alatt. Az egyenlő vízszintes és függőleges százalékok megtartják az alakzat arányait; eltérő százalékok az egyik dimenziót jobban nyújtják.

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

### **Szín**

Használja a [CreateColorEffect](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/ibehaviorfactory/createcoloreffect/) metódust a kitöltés kék színből narancssárgára változtatásához. A [From](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/icoloreffect/from/) és a [To](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/icoloreffect/to/) színek; a [By](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/icoloreffect/by/) egy színeltolás. Az [IBehavior.Properties](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/ibehavior/properties/) az animált attribútumot azonosítja.

Az alakzat szilárd kitöltése kékre van inicializálva, ami megegyezik az animáció kiindulási színével. A kitöltési szín attribútumának kiválasztása megmondja a viselkedésnek, az alakzat mely részét kell módosítani; a szín végpontok önmagukban nem határozzák meg ezt az attribútumot. A mentett hatás egy kétmásodperces átmenetet ír le narancssárga felé.

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

### **Szűrő**

Használja a [CreateFilterEffect](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/ibehaviorfactory/createfiltereffect/) metódust egy áttűnés kiválasztásához. A [Type](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/ifiltereffect/type/), a [Subtype](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/ifiltereffect/subtype/) és a [Reveal](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/ifiltereffect/reveal/) határozza meg a szűrőt, az irányt, valamint, hogy a alakzatot felfedjék vagy elrejtik.

Ez a példa egy kétmásodperces áttűnést állít be, amely a jobb irányú altípussal felfedi az alakzatot. A szűrő beállítások a hatáson belüli viselkedéshez tartoznak, ezért azok konfigurálása az előbeállított eredeti műveletek eltávolítása után történik.

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

### **Tulajdonság**

Használja a [CreatePropertyEffect](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/ibehaviorfactory/createpropertyeffect/) metódust az átlátszóság animálásához. A [From](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/ipropertyeffect/from/), a [To](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/ipropertyeffect/to/) és a [By](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/ipropertyeffect/by/) karakterláncok, amelyeket a [ValueType](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/ipropertyeffect/valuetype/) és a [CalcMode](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/ipropertyeffect/calcmode/) értelmez. Válasszon végpontokat vagy relatív eltolást, ahelyett, hogy mindhárom értéket együttesen állítaná be.

Itt a kiválasztott attribútum az átlátszóság, és a numerikus karakterláncok a 25 % átlátszóságról teljes átlátszóságra történő változást reprezentálják. A lineáris interpoláció fokozatos változást ír le ezek között az értékek között. Amikor ezt a példát egy másik attribútumra alkalmazza, válasszon megfelelő értéktípust és végpontértékeket.

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

### **Beállítás**

Használja a [CreateSetEffect](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/ibehaviorfactory/createseteffect/) metódust a láthatóság hozzárendeléséhez a [To](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/iseteffect/to/) segítségével. A beállítási viselkedés nem interpolál a végpontok között.

A példa a láthatóság attribútumát választja ki, és a `visible` karakterláncot rendeli hozzá, amikor a viselkedés lefut. A téglalap már látható ebben a minimális prezentációban, így a hozzárendelés önmagában nem feltétlenül eredményez nyilvánvaló vizuális változást. Egy ilyen művelet hasznos lehet egy nagyobb hatás részeként, amely szabályozza, mikor válik az alakzat rejtetté vagy láthatóvá.

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

### **Parancs**

Használja a [CreateCommandEffect](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/ibehaviorfactory/createcommandeffect/) metódust, és konfigurálja a [Type](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/icommandeffect/type/), a [CommandString](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/icommandeffect/commandstring/) és a [ShapeTarget](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/icommandeffect/shapetarget/) beállításait. Helyezzen egy `sample.wav` nevű WAV felvételt a munkakönyvtárba. Ez a példa a [AddAudioFrameEmbedded](https://reference.aspose.com/slides/hu/net/aspose.slides/ishapecollection/addaudioframeembedded/) segítségével ágyazza be, és egy lejátszási parancsot csatol az audio kerethez.

Az audio keret egyszerre a hatás és a parancs célpontja. Ez összekapcsolja a lejátszási kérést a beágyazott felvétellel; a parancs karakterlánc önmagában nem határozza meg, melyik médiaobjektumot kell vezérelni. A hatás úgy van beállítva, hogy a diavetítés közben egy kattintásra induljon.

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

A mentés a `command.pptx` fájlba tárolja a parancsot; nem játsza le a felvételt. A lejátszáshoz egy olyan diavetítőre van szükség, amely támogatja a parancsot és annak média célpontját.

## **A viselkedésgyűjtemény kezelése**

[IBehaviorCollection](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/ibehaviorcollection/) támogatja a [Add](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/ibehaviorcollection/add/), [Insert](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/ibehaviorcollection/insert/), [Remove](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/ibehaviorcollection/remove/) és [RemoveAt](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/ibehaviorcollection/removeat/) műveleteket. Ez a példa megnyitja a `rotation.pptx` fájlt, hozzáad egy méretezést, áthelyezi a forgatás előtt, és eltávolítja a forgatást. Egy objektum eltávolítása és újbóli beszúrása megváltoztatja a tárolt helyét anélkül, hogy másolatot hozna létre.

A szerkesztések sorozata a gyűjteményt a forgatás–méretezésből méretezés–forgatásra, majd csak méretezésre változtatja. Az indexek az aktuális gyűjteményre vonatkoznak, így az eltávolítás a forgatás új indexét használja a rendezés után. A végső felsorolás megerősíti, melyik viselkedés lesz mentve.

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

A kimenet `ScaleEffect`: csak a méretezés marad meg. A gyűjtemény sorrendje önmagában nem ütemezi a viselkedéseket egymás után. A gyűjteményt csak akkor törölje, ha az összes műveletet cserélni szeretné.

## **A viselkedés időzítésének beállítása**

[IBehavior.Timing](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/ibehavior/timing/) a [ITiming](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/itiming/) objektumot teszi elérhetővé, függetlenül az [IEffect.Timing](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/ieffect/timing/)-től. A hatás időzítése ütemezi a tartalmazó hatást; a viselkedés időzítése egy benne lévő műveletet ír le.

### **Időtartam, késleltetés, ismétlés és gyorsulás beállítása**

Nyissa meg a `rotation.pptx` fájlt, és állítsa be a [Duration](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/itiming/duration/) és a [TriggerDelayTime](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/itiming/triggerdelaytime/) értékeket másodpercben, majd konfigurálja a [RepeatCount](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/itiming/repeatcount/)-ot. A [Accelerate](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/itiming/accelerate/) és a [Decelerate](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/itiming/decelerate/) a időtartam törtrészei; összegük legfeljebb 1 legyen.

A bemeneti fájl a forgatás példában létrehozott, ahol az első viselkedés forgatásként ismert. Ez a példa csak ennek a viselkedésnek az időzítését módosítja; a 90‑fokos szög érintetlen marad. A szög és az időzítés elkülönítése megkönnyíti a tempó állítását a animáció újbóli felépítése nélkül.

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

A viselkedés kétmásodperces időtartamot, félmásodperces késleltetést és 3 ismétlést használ. Az időtartam első és utolsó 20 %-a a gyorsulásra és lassulásra szolgál.

Más ismétlési szabályok közé tartozik a [RepeatDuration](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/itiming/repeatduration/), a [RepeatUntilEndSlide](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/itiming/repeatuntilendslide/) és a [RepeatUntilNextClick](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/itiming/repeatuntilnextclick/); válasszon egy szabályt, ahelyett, hogy mindet egyszerre engedélyezné. Az [AutoReverse](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/itiming/autoreverse/) a animációt visszafelé játssza le a előrehaladást követően. A gyorsulás és lassulás folyamatos változásokra vonatkozik, nem pedig diszkrét hozzárendelésekre vagy parancsokra.

## **Mozgásútvonal létrehozása**

Használja a [CreateMotionEffect](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/ibehaviorfactory/createmotioneffect/) metódust mozgás létrehozásához. A [From](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/imotioneffect/from/), a [To](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/imotioneffect/to/) és a [By](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/imotioneffect/by/) százalékalapú koordinátákat vagy eltolásokat ír le. Szerkeszthető útvonalhoz hozza létre a [MotionPath](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/motionpath/)‑t, és rendelje hozzá a [IMotionEffect.Path](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/imotioneffect/path/)-hez. Az [IMotionPath](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/imotionpath/) tárolja az útvonal parancsait.

[MotionCommandPathType](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/motioncommandpathtype/) a parancsot választja:

| Parancs | Pontok | Jelentés |
| --- | --- | --- |
| MoveTo | Egy | A kezdőpozíció beállítása. |
| LineTo | Egy | Mozgás egy egyenes szegmens mentén a végpontjáig. |
| CurveTo | Három | Kövesse a két irányítópontot és egy végpontot meghatározó köbös ívet. |
| CloseLoop | Nincs | Visszatérés a kezdőpozícióba. |
| End | Nincs | Az útvonal befejezése. |

A [MotionPathPointsType](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/motionpathpointstype/) leírja a pont‑szerkesztési jellemzőket, például sarok- vagy sima pontokat. Nem helyettesíti a parancs típust. Használjon görbe pont típust a alábbi görbe példához, és sarok pont típust az egyenes szegmensekhez.

Az útvonal koordinátái a dia méreteihez vannak normalizálva: egy 0,25 X eltolás a dia szélességének negyedét jelenti, nem 0,25 pontot. A pozitív Y lefelé mutat. Az abszolút parancsok a útvonal koordináta‑rendszerben adnak meg pozíciókat; a relatív parancsok a jelenlegi pozíciótól számított eltolásokat. Ez különáll a [Origin](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/imotioneffect/origin/)-tól, amely az útvonal referencia‑keretét választja, és a [PathEditMode](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/imotioneffect/patheditmode/)-tól, amely szabályozza, hogyan mozog az útvonal, amikor az alakzatot mozgatják.

### **Egyenes útvonal létrehozása**

Hozzon létre egy mozgásviselkedést egy kezdőponttal, egy egyenes szegmenssel és egy befejező paranccsal. Az [IMotionPath.Add](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/imotionpath/add/) a parancs típusát, annak pontjait, a pont típusát és egy relatív‑koordináta jelzőt veszi fel.

A kezdőparancs (0, 0)-t állít be, és a vonal (0,25, 0)-nál végződik, ez a útvonal vízszintes eltolását a dia szélességének negyedére adja. A befejező parancsnak nincsenek koordinátapontjai. Ha az útvonalat hozzárendeljük, a mozgásviselkedés a hatáshoz hozzáadása összekapcsolja ezt az útvonalat a téglalappal.

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

`motion.pptx` egy mozgásviselkedést tartalmaz három útvonalparanccsal. A következő fájlszerkesztési példák ezt a ismert struktúrát használják.

### **Abszolút és relatív koordináták összehasonlítása**

Ez a két útvonalobjektum ugyanazt az útvonalat írja le. Az abszolút parancs (0,3, 0,1)-nél ér véget; a relatív parancs (0,1, 0,1)-et ad a jelenlegi pozícióhoz, (0,2, 0).

Mindkét útvonal ugyanannél a pozíciónál kezdődik. A relatív vonal esetén adja hozzá az X és Y eltolásokat a jelenlegi pozícióhoz a végpont eléréséhez; az abszolút vonal esetén olvassa ki közvetlenül a végpontot. A jelző megváltoztatása a koordináták konvertálása nélkül más útvonalat eredményezne.

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

Rendeljen bármelyik útvonalat egy mozgásviselkedéshez a prezentációban való használathoz. Az utolsó logikai argumentum a relatív koordinátákat választja ki az adott parancshoz.

### **Vonal cseréje görbére**

Nyissa meg a `motion.pptx` fájlt, és cserélje le a vonalparancsát egy köbös görbére. Először adja meg a két irányítópontot, majd a végpontot.

A kezdőpozíciót az előző parancs biztosítja. Az első két pont alakítja a görbét, a harmadik a célpont; nem három egymást követő célpontokról van szó. A parancs típusának, a pont‑szerkesztési típusnak és a ponttömbnek egyszerre történő frissítése biztosítja, hogy a szegmens az új geometriával összhangban maradjon.

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

A `curve.pptx` útvonalban továbbra is három parancs van; a középső parancs most már egy görbét definiál.

## **Mentett útvonal vizsgálata és szerkesztése**

Minden [IMotionCmdPath](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/imotioncmdpath/) a [Points](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/imotioncmdpath/points/), a [CommandType](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/imotioncmdpath/commandtype/), a [PointsType](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/imotioncmdpath/pointstype/) és az [IsRelative](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/imotioncmdpath/isrelative/) adatokat teszi elérhetővé. A következő példák a `motion.pptx` ismert háromparancsos útvonalát használják. Tetszőleges bemenet esetén először keresse meg a kívánt hatást, és ellenőrizze a parancstípusokat és a pontok számát, mielőtt index szerint szerkesztené.

### **Parancsok és koordináták olvasása**

Olvassa be az útvonalat anélkül, hogy módosítaná. A End és a CloseLoop parancsoknak nincs szükségük pontokra, ezért engedélyezzen egy null ponttömböt.

A kimenet párosítja minden parancsot a relatív‑koordináta jelzőjével, mielőtt felsorítaná a pontokat. Ez lehetővé teszi a végpont és egy eltolás megkülönböztetését az útvonal módosítása előtt. Egy görbe három pontot sorol fel, míg a fájlban lévő egyenes vonal csak egyet.

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

A listázás egy kezdőpontot, egy abszolút vonalat (0,25, 0)-nál végződően, és egy End parancsot tartalmaz.

### **Végpont módosítása**

Nyissa meg a `motion.pptx` fájlt, és cserélje le a vonal ponttömbjét a végpont áthelyezéséhez.

A bemeneti fájlban a 0 index a kezdőparancs, az 1 index a vonal. A vonal egyetlen pontjának cseréje megváltoztatja a célpontját anélkül, hogy módosítaná a parancstípust, az időzítést vagy a gyűjteményben betöltött pozícióját. Mivel a parancs abszolút koordinátákat használ, az új pár egy pozíciót ad meg, nem pedig egy hozzáadott eltolást.

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

A `motion-endpoint.pptx` fájlban a vonal (0,4, 0,1)-nél ér véget; az eredeti fájl változatlan marad.

### **Szegmens cseréje**

Használja az [Insert](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/imotionpath/insert/) és a [RemoveAt](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/imotionpath/removeat/) metódusokat a `motion.pptx` vonalának cseréjéhez. Beszúráskor a régi vonal a 2‑es indexre tolódik.

Ez azt mutatja, hogy egy parancsobjektust cserélünk, ahelyett, hogy a meglévő koordinátákat szerkesztenénk. Beszúrás után a gyűjtemény ideiglenesen a kezdőparancsot, az új vonalat, a régi vonalat és az End parancsot tartalmazza. A 2‑es index eltávolítása eltávolítja a régi vonalat, és az új útvonal helyben marad.

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

A mentett útvonal továbbra is három parancsot tartalmaz, az új vonal (0,2, 0,1)-nél végződik, az End parancs pedig az utolsó.

## **Meglévő viselkedés módosítása és ellenőrzése**

Ha a viselkedés indexe ismeretlen, válassza ki típusa szerint. Ez a példa megnyitja a `rotation.pptx` fájlt, megtalálja az [IRotationEffect](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/irotationeffect/) objektumot, megváltoztatja a szöget, és az újbóli megnyitás után ellenőrzi a mentett értéket.

A típusellenőrzés lehetővé teszi, hogy a ciklus átugorja a nem forgatási viselkedéseket. A második betöltés a mentett fájlt egy külön prezentációobjektumba olvassa, így az összehasonlítás a mentett adatokat ellenőrzi, nem a memóriában maradt értéket. Ez a példa továbbra is feltételezi, hogy a ismert hatás az első a fő sorozatban; a típus szerinti viselkedésválasztás nem feltétlenül találja meg a helyes hatást egy tetszőleges prezentációban.

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

A kimenet `Rotation preserved: True`. Alkalmazza ugyanazt a típusellenőrzési mintát más viselkedésekre is. A teljes megőrzés ellenőrzéséhez hasonlítsa össze a cél alakzatot, a hatást, a viselkedéstípusokat és sorrendet, az időzítést és az útvonalparancsokat. Használjon numerikus toleranciát a lebegőpontos értékekhez. Egy ismeretlen animációs felépítésű prezentáció esetén lásd a [Alakzat animációk olvasása](/slides/hu/net/shape-animation/#read-shape-animations) oldalt a fő és interaktív sorozatok bejárásához.

## **Viselkedés sorrend, előbeállítások és lejátszás**

Az [IBehaviorCollection](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/ibehaviorcollection/) sorrendje a hatás műveleteinek tárolt sorrendje. Nem egy lejátszási lista, ahol minden viselkedés automatikusan a megelőzőre vár. Az időzítés és a körülvevő hatás határozza meg az ütemezést. A viselkedések átfedhetnek, és ugyanazon tulajdonságon végzett műveletek interakcióba léphetnek az [Additive](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/ibehavior/additive/) és az [Accumulate](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/ibehavior/accumulate/) segítségével. Ne használja csak a gyűjtemény átrendezését a „mozgatás, majd forgatás” ütemezéséhez; használjon explicitt időzítést vagy külön hatásokat, ahogy a [Alakzat animáció](/slides/hu/net/shape-animation/) leírásában szerepel.

A hatás [Type](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/ieffect/type/) és [Subtype](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/ieffect/subtype/) leírja az előbeállított sablont. Ezek nem adnak teljes képet egy szerkesztett viselkedésfáról. Válassza ki a sablont és az altípust a viselkedések testreszabása előtt: a sablon módosítása újraépítheti a gyűjteményt, és eldobhatja az egyéni műveleteket. Például egy egyedi Spin hatás Fade‑re cserélése helyettesítheti a forgatási viselkedést set és filter viselkedésekkel. Ellenőrizze újra a gyűjteményt a sablon vagy altípus módosítása után. A sablon viselkedéseinek törlése eltávolíthatja a láthatóságot vagy az inicializációs műveleteket, amelyekre a sablonnak szüksége van. A példák szándékosan látható alakzatokat használnak, és helyettesítik a viselkedéseket; nem építik újra minden sablon megvalósítását.

## **Formátum kompatibilitás**

A megőrzött viselkedésfa nem garantálja az azonos lejátszást minden megjelenítőben vagy exportáló renderelőben. Ellenőrizze külön a mentett adatokat és a renderelt kimenetet.

| Formátum vagy kimenet | Mit kell ellenőrizni |
| --- | --- |
| PPTX | Használja fő formátumként ezekhez a példákhoz. Nyissa meg újra, hogy ellenőrizze a szerkeszthető viselkedésfát, majd ellenőrizze a lejátszást a kívánt PowerPoint verzióban. |
| PPT | Az örökölt bináris ábrázolás eltérhet a PPTX‑től. Teszteljen külön mentés‑újraolvasási ciklust és lejátszást; ne feltételezze a támogatást minden egyedi kombinációra a sikeres PPTX kimenet alapján. |
| PDF, PNG, JPEG, and other static slide images | Statikus diaábrázolást tartalmaz, nem játszható viselkedés‑idővonalat vagy garantált végső animációs keretet. |
| [HTML5](/slides/hu/net/export-to-html5/) | Képes lejátszani a támogatott animációkat, ha az exportálási beállításokban engedélyezve van az alakzatanimáció. Tesztelje az egyedi kombinációkat a böngészőben. |
| [Animated GIF](/slides/hu/net/convert-powerpoint-to-animated-gif/) | A renderelt képkockákat tárolja, nem szerkeszthető viselkedéseket vagy kattintás triggerelt interakciót. Ellenőrizze a tényleges renderelt mozgást. |
| [Video](/slides/hu/net/convert-powerpoint-to-video/) | Rendereli az animációs képkockákat és videóként kódolja őket. A támogatás a renderelő [támogatott animációira és hatásaira](/slides/hu/net/convert-powerpoint-to-video/#supported-animations-and-effects) korlátozódik; a parancsok és interaktív események nem válnak szerkeszthető idővonalra. |

## **GYIK**

**Miért tartalmaz a hatásom viselkedéseket, mielőtt bármilyet hozzáadnék?**

Egy előre definiált hatás létrehozhatja a háttérben lévő műveleteket. Vizsgálja meg ezeket, mielőtt eldöntené, hogy kibővíti-e a sablont vagy lecseréli a viselkedéseket.

**Az, hogy egy viselkedést a lista elejére helyezek, azt jelenti, hogy először lejátszódik?**

Nem feltétlenül. A gyűjtemény sorrendje nem helyettesíti az időzítést. Ellenőrizze a késleltetéseket, időtartamokat és a műveletek közti interakciókat ugyanazon tulajdonságon.

**Miért nincs pont a End parancshoz?**

Az jelzi az útvonal végét, ezért nincs szükség koordinátákra. Ellenőrizze, hogy a fájlból beolvasott útvonal esetén a ponttömb null‑e.

**Elégséges-e egy sikeres round‑trip a lejátszás megerősítéséhez?**

Nem. A újbóli megnyitás csak azt erősíti meg, hogy a vizsgált tulajdonságok megmaradtak. Tesztelje külön a diavetítő lejátszót vagy az animált exportot, hogy megerősítse a vizuális viselkedést.