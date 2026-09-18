---
title: Vytváření a úprava vlastních animačních chování v .NET
linktitle: Vlastní animace
type: docs
weight: 151
url: /cs/net/custom-animation/
keywords:
- vlastní animace
- animační chování
- cesta pohybu
- PowerPoint
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Vytvářejte, prohlížejte a upravujte vlastní animační chování a editovatelné cesty pohybu v prezentacích PowerPoint pomocí Aspose.Slides pro .NET."
---
## **Přehled**

Vlastní animační chování vám umožňují řídit jednotlivé operace v rámci animačního efektu, například změnu barvy, otáčení tvaru nebo sledování upravitelných pohybových cest. Tento návod ukazuje, jak vytvářet a kombinovat chování, konfigurovat jejich časování, prohlížet a upravovat existující animace a ověřovat, že jejich vlastnosti přežijí uložení a opětovné otevření prezentace.

Pro předdefinované efekty a spouštěče kliknutí viz [Animace tvarů](/slides/cs/net/shape-animation/).

## **Porozumění animačnímu modelu**

Animace je uspořádána jako **Timeline → Sequence → Effect → Behaviors**:

- [Timeline] prezentace (https://reference.aspose.com/slides/cs/net/aspose.slides/ibaseslide/timeline/) obsahuje hlavní sekvenci a interaktivní sekvence.
- [ISequence] (https://reference.aspose.com/slides/cs/net/aspose.slides.animation/isequence/) obsahuje efekty, které mohou cílit na různé tvary.
- [IEffect] (https://reference.aspose.com/slides/cs/net/aspose.slides.animation/ieffect/) identifikuje cílový tvar, předvolbu, podtyp a časování efektu.
- [IEffect.Behaviors] (https://reference.aspose.com/slides/cs/net/aspose.slides.animation/ieffect/behaviors/) obsahuje operace, které implementují efekt: změna barvy, přesun, otáčení, nastavení vlastnosti atd.

## **Vytvoření jednotlivých chování**

Voláním [ISequence.AddEffect] (https://reference.aspose.com/slides/cs/net/aspose.slides.animation/isequence/addeffect/) vytvoříte efekt a získáte jeho kolekci [Behaviors] (https://reference.aspose.com/slides/cs/net/aspose.slides.animation/ieffect/behaviors/). Předvolba může tuto kolekci naplnit automaticky. Ponechte její operace při rozšiřování předvolby nebo použijte [Clear] (https://reference.aspose.com/slides/cs/net/aspose.slides.animation/ibehaviorcollection/clear/) při úmyslné náhradě.

[IBehaviorFactory] (https://reference.aspose.com/slides/cs/net/aspose.slides.animation/ibehaviorfactory/) vytváří osm typů chování znázorněných níže. Pohyb je popsán v sekci [Vytvořit cestu pohybu](#build-a-motion-path). Každý příklad vytvoření je kompletním programem; pozdější příklady úprav uvádějí, který výstupní soubor používají.

### **Otáčení**

Použijte [CreateRotationEffect] (https://reference.aspose.com/slides/cs/net/aspose.slides.animation/ibehaviorfactory/createrotationeffect/) pro vytvoření otáčení. [By] (https://reference.aspose.com/slides/cs/net/aspose.slides.animation/irotationeffect/by/) určuje relativní úhel ve stupních; [From] (https://reference.aspose.com/slides/cs/net/aspose.slides.animation/irotationeffect/from/) a [To] (https://reference.aspose.com/slides/cs/net/aspose.slides.animation/irotationeffect/to/) určují koncové body.

Příklad začíná efektem Spin, nahradí jeho přednastavené operace jedním otáčecím chováním a nastaví trvání operace na dvě sekundy. Relativní úhel 90 stupňů představuje čtvrtotoč, takže není potřeba explicitní počáteční úhel.

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

`rotation.pptx` obsahuje jeden tvar a jedno otáčecí chování. Kolekce, časování a příklady úprav otáčení níže používají tento soubor.

### **Měřítko**

Použijte [CreateScaleEffect] (https://reference.aspose.com/slides/cs/net/aspose.slides.animation/ibehaviorfactory/createscaleeffect/) s procenty X/Y: [From] (https://reference.aspose.com/slides/cs/net/aspose.slides.animation/iscaleeffect/from/) a [To] (https://reference.aspose.com/slides/cs/net/aspose.slides.animation/iscaleeffect/to/) popisují počáteční a koncovou velikost, zatímco [By] (https://reference.aspose.com/slides/cs/net/aspose.slides.animation/iscaleeffect/by/) popisuje relativní změnu. Zde 100 znamená původní velikost.

Příklad zvětší oba rozměry ze 100 % na 125 % během dvou sekund. Použití stejných horizontálních a vertikálních procent zachová proporce tvaru; různé procenta by natahovaly jeden rozměr více než druhý.

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

### **Barva**

Použijte [CreateColorEffect] (https://reference.aspose.com/slides/cs/net/aspose.slides.animation/ibehaviorfactory/createcoloreffect/) pro změnu výplně z modré na oranžovou. [From] (https://reference.aspose.com/slides/cs/net/aspose.slides.animation/icoloreffect/from/) a [To] (https://reference.aspose.com/slides/cs/net/aspose.slides.animation/icoloreffect/to/) jsou barvy; [By] (https://reference.aspose.com/slides/cs/net/aspose.slides.animation/icoloreffect/by/) je barevný posun. [IBehavior.Properties] (https://reference.aspose.com/slides/cs/net/aspose.slides.animation/ibehavior/properties/) identifikuje animovaný atribut.

Výplň tvaru je inicializována na modrou, což odpovídá počáteční barvě animace. Výběr atributu výplň‑barvy říká chování, kterou část tvaru má změnit; samotné koncové barvy tento atribut neidentifikují. Uložený efekt popisuje dvousekundovou interpolaci na oranžovou.

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

### **Filtr**

Použijte [CreateFilterEffect] (https://reference.aspose.com/slides/cs/net/aspose.slides.animation/ibehaviorfactory/createfiltereffect/) pro výběr setření. [Type] (https://reference.aspose.com/slides/cs/net/aspose.slides.animation/ifiltereffect/type/), [Subtype] (https://reference.aspose.com/slides/cs/net/aspose.slides.animation/ifiltereffect/subtype/) a [Reveal] (https://reference.aspose.com/slides/cs/net/aspose.slides.animation/ifiltereffect/reveal/) určují filtr, směr a zda má tvar odhalit nebo skrýt.

Tento příklad konfiguruje dvousekundové setření, které odhalí tvar pomocí podtypu s pravým směrem. Nastavení filtru patří k chování uvnitř efektu, proto se konfiguruje po odstranění původních operací předvolby.

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

### **Vlastnost**

Použijte [CreatePropertyEffect] (https://reference.aspose.com/slides/cs/net/aspose.slides.animation/ibehaviorfactory/createpropertyeffect/) pro animaci neprůhlednosti. [From] (https://reference.aspose.com/slides/cs/net/aspose.slides.animation/ipropertyeffect/from/), [To] (https://reference.aspose.com/slides/cs/net/aspose.slides.animation/ipropertyeffect/to/) a [By] (https://reference.aspose.com/slides/cs/net/aspose.slides.animation/ipropertyeffect/by/) jsou řetězce interpretované pomocí [ValueType] (https://reference.aspose.com/slides/cs/net/aspose.slides.animation/ipropertyeffect/valuetype/) a [CalcMode] (https://reference.aspose.com/slides/cs/net/aspose.slides.animation/ipropertyeffect/calcmode/). Zvolte koncové body nebo relativní posun místo nastavení všech tří hodnot najednou.

Zde je vybraná vlastnost neprůhlednost a číselné řetězce představují změnu z 25 % neprůhlednosti na plnou neprůhlednost. Lineární interpolace popisuje plynulou změnu mezi těmito hodnotami. Při úpravě příkladu na jinou vlastnost vyberte typ hodnoty a koncové hodnoty odpovídající dané vlastnosti.

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

### **Nastavení**

Použijte [CreateSetEffect] (https://reference.aspose.com/slides/cs/net/aspose.slides.animation/ibehaviorfactory/createseteffect/) pro přiřazení viditelnosti pomocí [To] (https://reference.aspose.com/slides/cs/net/aspose.slides.animation/iseteffect/to/). Chování Set neinterpoluje mezi koncovými body.

Příklad vybere atribut viditelnosti a při běhu chování přiřadí řetězec `visible`. Obdélník je v této minimální prezentaci již viditelný, takže samotné přiřazení nemusí mít zřetelnou vizuální změnu. Taková operace je užitečná jako součást většího efektu, který také řídí, kdy se tvar skryje nebo zobrazí.

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

### **Příkaz**

Použijte [CreateCommandEffect] (https://reference.aspose.com/slides/cs/net/aspose.slides.animation/ibehaviorfactory/createcommandeffect/) a nastavte [Type] (https://reference.aspose.com/slides/cs/net/aspose.slides.animation/icommandeffect/type/), [CommandString] (https://reference.aspose.com/slides/cs/net/aspose.slides.animation/icommandeffect/commandstring/) a [ShapeTarget] (https://reference.aspose.com/slides/cs/net/aspose.slides.animation/icommandeffect/shapetarget/). Umístěte nahrávku WAV s názvem `sample.wav` do pracovního adresáře. Tento příklad ji vloží pomocí [AddAudioFrameEmbedded] (https://reference.aspose.com/slides/cs/net/aspose.slides/ishapecollection/addaudioframeembedded/) a připojí příkaz pro přehrání k audio‑rámci.

Audio‑rám je jak cílem efektu, tak cílem příkazu. To propojí požadavek na přehrání s vloženou nahrávkou; samotný řetězec příkazu neurčuje, který mediální objekt má být řízen. Efekt je nastaven tak, aby se spustil kliknutím během prezentace.

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

Uložení uloží příkaz do `command.pptx`; nahrávka se nepřehraje. Přehrávání vyžaduje přehrávač prezentací, který podporuje příkaz a jeho mediální cíl.

## **Správa kolekce chování**

[IBehaviorCollection] (https://reference.aspose.com/slides/cs/net/aspose.slides.animation/ibehaviorcollection/) podporuje [Add] (https://reference.aspose.com/slides/cs/net/aspose.slides.animation/ibehaviorcollection/add/), [Insert] (https://reference.aspose.com/slides/cs/net/aspose.slides.animation/ibehaviorcollection/insert/), [Remove] (https://reference.aspose.com/slides/cs/net/aspose.slides.animation/ibehaviorcollection/remove/) a [RemoveAt] (https://reference.aspose.com/slides/cs/net/aspose.slides.animation/ibehaviorcollection/removeat/). Tento příklad otevře `rotation.pptx`, přidá měřítko, přesune jej před otáčení a odstraní otáčení. Odstranění a opětovné vložení stejného objektu změní jeho uloženou pozici, aniž by se vytvořila kopie.

Sekvence úprav mění kolekci z otáčení‑měřítko na měřítko‑otáčení a nakonec jen na měřítko. Indexy se vztahují k aktuální kolekci, takže odstranění používá nový index otáčení po přeuspořádání. Konečné výčtování potvrzuje, které chování bude uloženo.

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

Výstup je `ScaleEffect`: zůstane jen měřítko. Pořadí v kolekci samo o sobě neschází chování jedno po druhém. Vyprázdněte kolekci jen při úplné náhradě všech jejích operací.

## **Konfigurace časování chování**

[IBehavior.Timing] (https://reference.aspose.com/slides/cs/net/aspose.slides.animation/ibehavior/timing/) odhaluje [ITiming] (https://reference.aspose.com/slides/cs/net/aspose.slides.animation/itiming/), nezávisle na [IEffect.Timing] (https://reference.aspose.com/slides/cs/net/aspose.slides.animation/ieffect/timing/). Časování efektu řídí celý efekt; časování chování popisuje operaci uvnitř něj.

### **Nastavení trvání, zpoždění, opakování a zrychlení**

Otevřete `rotation.pptx` a nastavte [Duration] (https://reference.aspose.com/slides/cs/net/aspose.slides.animation/itiming/duration/) a [TriggerDelayTime] (https://reference.aspose.com/slides/cs/net/aspose.slides.animation/itiming/triggerdelaytime/) v sekundách, poté nakonfigurujte [RepeatCount] (https://reference.aspose.com/slides/cs/net/aspose.slides.animation/itiming/repeatcount/). [Accelerate] (https://reference.aspose.com/slides/cs/net/aspose.slides.animation/itiming/accelerate/) a [Decelerate] (https://reference.aspose.com/slides/cs/net/aspose.slides.animation/itiming/decelerate/) jsou zlomky trvání; jejich součet nesmí překročit 1.

Vstupní soubor je ten vytvořený v příkladu otáčení, kde je první chování známo jako otáčení. Tento příklad mění jen časování tohoto chování; úhel 90 ° zůstává nedotčen. Oddělené uchovávání úhlu a časování usnadňuje úpravu tempa bez nutnosti přestavovat animaci.

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

Chování používá dvousekundové trvání, půlsekundové zpoždění a opakování 3 krát. Prvních a posledních 20 % jeho trvání slouží pro zrychlení a zpomalení.

Další politiky opakování zahrnují [RepeatDuration] (https://reference.aspose.com/slides/cs/net/aspose.slides.animation/itiming/repeatduration/), [RepeatUntilEndSlide] (https://reference.aspose.com/slides/cs/net/aspose.slides.animation/itiming/repeatuntilendslide/), a [RepeatUntilNextClick] (https://reference.aspose.com/slides/cs/net/aspose.slides.animation/itiming/repeatuntilnextclick/); vyberte jednu politiku místo povolení všech najednou. [AutoReverse] (https://reference.aspose.com/slides/cs/net/aspose.slides.animation/itiming/autoreverse/) přehraje animaci pozpátku po dopředném průchodu. Zrychlení a zpomalení se vztahují na spojité změny, ne na diskrétní přiřazení nebo příkazy.

## **Vytvořit cestu pohybu**

Použijte [CreateMotionEffect] (https://reference.aspose.com/slides/cs/net/aspose.slides.animation/ibehaviorfactory/createmotioneffect/) pro vytvoření pohybu. Jeho [From] (https://reference.aspose.com/slides/cs/net/aspose.slides.animation/imotioneffect/from/), [To] (https://reference.aspose.com/slides/cs/net/aspose.slides.animation/imotioneffect/to/) a [By] (https://reference.aspose.com/slides/cs/net/aspose.slides.animation/imotioneffect/by/) popisují procentuální souřadnice nebo posuny. Pro upravitelnou trasu vytvořte [MotionPath] (https://reference.aspose.com/slides/cs/net/aspose.slides.animation/motionpath/) a přiřaďte ji k [IMotionEffect.Path] (https://reference.aspose.com/slides/cs/net/aspose.slides.animation/imotioneffect/path/). [IMotionPath] (https://reference.aspose.com/slides/cs/net/aspose.slides.animation/imotionpath/) uchovává příkazy cesty.

[MotionCommandPathType] (https://reference.aspose.com/slides/cs/net/aspose.slides.animation/motioncommandpathtype/) vybírá operaci:

| Command | Points | Meaning |
| --- | --- | --- |
| MoveTo | One | Nastaví počáteční pozici. |
| LineTo | One | Přesune se po úsečce ke koncovému bodu. |
| CurveTo | Three | Následuje kubickou křivku definovanou dvěma kontrolními body a koncovým bodem. |
| CloseLoop | None | Vrátí se na počáteční pozici. |
| End | None | Ukončí cestu. |

[MotionPathPointsType] (https://reference.aspose.com/slides/cs/net/aspose.slides.animation/motionpathpointstype/) popisuje vlastnosti úprav bodů, například rohové nebo hladké body. Nenahrazuje typ příkazu. Použijte typ bodu křivky pro příklad křivky níže a typ rohového bodu pro přímé úseky.

Souřadnice cesty jsou normalizovány na rozměry snímku: posun X 0,25 představuje čtvrtinu šířky snímku, ne 0,25 bodů. Kladné Y běží dolů. Absolutní příkazy určují pozice v souřadnicovém systému cesty; relativní příkazy určují posuny od aktuální pozice. To je oddělené od [Origin] (https://reference.aspose.com/slides/cs/net/aspose.slides.animation/imotioneffect/origin/), který volí referenční rámec cesty, a [PathEditMode] (https://reference.aspose.com/slides/cs/net/aspose.slides.animation/imotioneffect/patheditmode/), který řídí, jak se cesta pohybuje při přesunu tvaru.

### **Vytvořit přímou cestu**

Vytvořte pohybové chování s počátečním bodem, jedním přímým úsekem a koncovým příkazem. [IMotionPath.Add] (https://reference.aspose.com/slides/cs/net/aspose.slides.animation/imotionpath/add/) přijímá typ příkazu, jeho body, typ bodu a příznak relativních souřadnic.

Počáteční příkaz stanoví (0, 0) a úsek končí v (0,25, 0), čímž trasa získá horizontální posun o čtvrtinu šířky snímku. Koncový příkaz nemá žádné souřadnice. Po přiřazení cesty se přidáním pohybového chování k efektu propojí tato trasa s obdélníkem.

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

`motion.pptx` obsahuje jedno pohybové chování se třemi příkazy cesty. Následující příklady úprav souboru používají tuto známou strukturu.

### **Porovnání absolutních a relativních souřadnic**

Tyto dva objekty cesty popisují stejnou trasu. Absolutní příkaz končí v (0,3, 0,1); relativní příkaz přičte (0,1, 0,1) k aktuální pozici, tedy (0,2, 0).

Obě cesty začínají ve stejném bodě. Pro relativní úsek přičtěte jeho X a Y offsety k aktuální pozici, abyste získali koncový bod; pro absolutní úsek přečtěte koncový bod přímo. Přepnutí příznaku bez převedení souřadnic by popsalo jinou trasu.

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

Přiřaďte libovolnou z cest k pohybovému chování a použijte ji v prezentaci. Poslední argument typu Boolean určuje, zda jsou souřadnice relativní pro daný příkaz.

### **Nahradit úsek přímkou křivkou**

Otevřete `motion.pptx` a nahraďte jeho příkaz úseku kubickou křivkou. Nejprve uveďte dva kontrolní body, následovaný koncovým bodem.

Počáteční pozice je dána předchozím příkazem. První dva body tvarují křivku, třetí je její cíl; nejde o tři po sobě jdoucí cíle. Aktualizace typu příkazu, typu úpravy bodů a pole bodů najednou udržuje segment konzistentní s novou geometrií.

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

Cesta v `curve.pptx` má stále tři příkazy; její prostřední příkaz nyní definuje křivku.

## **Prohlížení a úprava uložené cesty**

Každý [IMotionCmdPath] (https://reference.aspose.com/slides/cs/net/aspose.slides.animation/imotioncmdpath/) odhaluje [Points] (https://reference.aspose.com/slides/cs/net/aspose.slides.animation/imotioncmdpath/points/), [CommandType] (https://reference.aspose.com/slides/cs/net/aspose.slides.animation/imotioncmdpath/commandtype/), [PointsType] (https://reference.aspose.com/slides/cs/net/aspose.slides.animation/imotioncmdpath/pointstype/) a [IsRelative] (https://reference.aspose.com/slides/cs/net/aspose.slides.animation/imotioncmdpath/isrelative/). Následující příklady používají známou třípříkazovou cestu v `motion.pptx`. Pro libovolný vstup nejprve najděte příslušný efekt a zkontrolujte typy příkazů a počty bodů před úpravou podle indexu.

### **Číst příkazy a souřadnice**

Přečtěte cestu bez změny. Příkazy End a CloseLoop nepotřebují body, takže umožněte nulové pole bodů.

Výstup spojuje každý příkaz s příznakem relativních souřadnic před výpisem jeho bodů. To vám umožní rozlišit koncový bod od offsetu před úpravou cesty. Křivka vypíše tři body, zatímco přímka v tomto souboru vypíše pouze jeden.

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

Výpis obsahuje počáteční bod, absolutní úsek končící v (0,25, 0) a příkaz End.

### **Změnit koncový bod**

Otevřete `motion.pptx` a nahraďte pole bodů úseku, aby se posunul jeho koncový bod.

V vstupním souboru je index 0 počáteční příkaz a index 1 úsek. Nahrazení jediného bodu úseku změní jeho cíl, aniž by se změnil typ příkazu, časování nebo pozice v kolekci. Protože příkaz používá absolutní souřadnice, nový pár specifikuje pozici místo přidaného offsetu.

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

Úsek v `motion-endpoint.pptx` končí v (0,4, 0,1); původní soubor zůstává nezměněn.

### **Nahradit segment**

Použijte [Insert] (https://reference.aspose.com/slides/cs/net/aspose.slides.animation/imotionpath/insert/) a [RemoveAt] (https://reference.aspose.com/slides/cs/net/aspose.slides.animation/imotionpath/removeat/) pro nahrazení úseku v `motion.pptx`. Vložení posune starý úsek na index 2.

Tím se ukazuje nahrazení objektu příkazu místo úpravy jeho existujících souřadnic. Po vložení kolekce dočasně obsahuje počáteční příkaz, nový úsek, starý úsek a příkaz End. Odstraněním indexu 2 se starý úsek zahodí a nová trasa zůstane.

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

Uložená cesta stále má tři příkazy, přičemž nový úsek končí v (0,2, 0,1) a příkaz End je poslední.

## **Úprava a ověření existujícího chování**

Když není znám index chování, vyberte jej podle typu. Tento příklad otevře `rotation.pptx`, najde jeho [IRotationEffect] (https://reference.aspose.com/slides/cs/net/aspose.slides.animation/irotationeffect/), změní úhel a po opětovném otevření zkontroluje uloženou hodnotu.

Kontrola typu umožňuje smyčce přeskočit chování, která nejsou otáčení. Druhé načtení načte uložený soubor do samostatného objektu prezentace, takže srovnání kontroluje trvalá data, nikoli hodnotu stále drženou v paměti. Tento příklad stále předpokládá, že známý efekt je první v hlavní sekvenci; výběr chování podle typu nevyhledá správný efekt v libovolné prezentaci.

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

Výstup je `Rotation preserved: True`. Použijte stejný vzor kontroly typu i pro ostatní chování. Pro úplnou kontrolu zachování porovnejte cílový tvar, efekt, typy a pořadí chování, časování a příkazy cesty. Použijte číselnou toleranci pro hodnoty s plovoucí desetinnou čárkou. Pro prezentaci s neznámým rozvržením animací viz [Čtení animací tvarů](/slides/cs/net/shape-animation/#read-shape-animations) pro procházení hlavních a interaktivních sekvencí.

## **Pořadí chování, předvolby a přehrávání**

Pořadí v [IBehaviorCollection] (https://reference.aspose.com/slides/cs/net/aspose.slides.animation/ibehaviorcollection/) je uložené pořadí operací efektu. Není to playlist, ve kterém každé chování automaticky čeká na předchozí. Časování a obklopující efekt určují plánování. Chování se může překrývat a operace na stejné vlastnosti mohou vzájemně působit přes [Additive] (https://reference.aspose.com/slides/cs/net/aspose.slides.animation/ibehavior/additive/) a [Accumulate] (https://reference.aspose.com/slides/cs/net/aspose.slides.animation/ibehavior/accumulate/). Nepoužívejte jen přeuspořádání kolekce pro plánování „přesun, pak otáčení“; použijte explicitní časování nebo oddělené efekty, jak je popsáno v [Animaci tvarů](/slides/cs/net/shape-animation/).

[Type] (https://reference.aspose.com/slides/cs/net/aspose.slides.animation/ieffect/type/) a [Subtype] (https://reference.aspose.com/slides/cs/net/aspose.slides.animation/ieffect/subtype/) efektu popisují jeho předvolbu. Nejedná se o úplný popis upraveného stromu chování. Vyberte předvolbu a podtyp před vlastním přizpůsobením chování: změna předvolby může přestavit kolekci a zahodit vaše vlastní operace. Například změna přizpůsobeného efektu Spin na Fade může nahradit otáčecí chování chováním Set a Filter. Po změně předvolby nebo podtypu opět zkontrolujte kolekci. Vyprázdnění předvolených chování může také odstranit operace viditelnosti nebo inicializace, které předvolba potřebuje. Příklady vědomě používají viditelné tvary a nahrazují chování; nepřestavují kompletní implementaci každé předvolby.

## **Kompatibilita formátů**

Zachování stromu chování nezaručuje identické přehrání ve všech prohlížečích nebo exportních rendererech. Zkontrolujte uložená data a zobrazovaný výstup samostatně.

| Formát nebo výstup | Co ověřit |
| --- | --- |
| PPTX | Používejte jako primární formát pro tyto příklady. Otevřete jej znovu pro ověření editovatelného stromu chování, poté zkontrolujte přehrávání ve zvoleném PowerPointu. |
| PPT | Starší binární reprezentace se může lišit od PPTX. Proveďte samostatný cyklus uložení‑otevření a přehrání; nevyvozujte podporu pro každou vlastní kombinaci jen z úspěšného výstupu PPTX. |
| PDF, PNG, JPEG a další statické snímky | Obsahují statický obrázek snímku, ne přehratelnou časovou osu chování ani zaručený konečný animační snímek. |
| [HTML5](/slides/cs/net/export-to-html5/) | Může přehrávat podporované animace, pokud je v možnostech exportu povolena animace tvarů. Otestujte vlastní kombinace v prohlížeči. |
| [Animovaný GIF](/slides/cs/net/convert-powerpoint-to-animated-gif/) | Ukládá vykreslené snímky, ne editovatelné chování ani interaktivní klikací události. Zkontrolujte skutečný vykreslený pohyb. |
| [Video](/slides/cs/net/convert-powerpoint-to-video/) | Vykresluje animační snímky a kóduje je jako video. Podpora je omezena na [podporované animace a efekty](/slides/cs/net/convert-powerpoint-to-video/#supported-animations-and-effects); příkazy a interaktivní události se nepromění v editovatelnou časovou osu. |

## **Často kladené otázky**

**Proč můj efekt obsahuje chování, i když jsem žádné nepřidal?**

Vytvoření předdefinovaného efektu může vytvořit jeho podkladové operace. Prohlédněte je, než se rozhodnete rozšířit předvolbu nebo nahradit její chování.

**Způsobí přesunutí chování na začátek, že se přehraje jako první?**

Ne nutně. Pořadí v kolekci nenahrazuje časování. Zkontrolujte zpoždění, trvání a vzájemné interakce operací na stejné vlastnosti.

**Proč má příkaz End žádné body?**

Označuje konec cesty a nepotřebuje souřadnice. Při prohlížení cesty načtené ze souboru očekávejte nulové pole bodů.

**Je úspěšný round‑trip dostačující pro potvrzení přehrání?**

Ne. Otevření znovu potvrzuje zachování zkontrolovaných vlastností. Přehrajte prezentaci nebo animovaný export samostatně, abyste ověřili vizuální chování.