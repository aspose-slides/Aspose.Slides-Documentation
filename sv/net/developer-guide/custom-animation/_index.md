---
title: Skapa och ändra anpassade animationsbeteenden i .NET
linktitle: Anpassad animation
type: docs
weight: 151
url: /sv/net/custom-animation/
keywords:
- anpassad animation
- animationsbeteende
- rörelsestråle
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Skapa, inspektera och ändra anpassade animationsbeteenden och redigerbara rörelsestrålar i PowerPoint-presentationer med Aspose.Slides för .NET."
---
## **Översikt**

Anpassade animationsbeteenden låter dig styra enskilda operationer inom en animationseffekt, såsom att ändra färg, rotera en form eller följa en redigerbar rörelsestråle. Den här guiden visar hur du skapar och kombinerar beteenden, konfigurerar deras tidtagning, inspekterar och ändrar befintliga animationer samt verifierar att deras egenskaper överlever när en presentation sparas och öppnas igen.

För fördefinierade effekter och klickutlösare, se [Formanimation](/slides/sv/net/shape-animation/).

## **Förstå animationsmodellen**

En animation är organiserad som **Timeline → Sequence → Effect → Behaviors**:

- Bildens [Timeline](https://reference.aspose.com/slides/sv/net/aspose.slides/ibaseslide/timeline/) innehåller dess huvudsekvens och interaktiva sekvenser.
- En [ISequence](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/isequence/) innehåller effekter, eventuellt riktade mot olika former.
- En [IEffect](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/ieffect/) identifierar en målform, förinställning, undertyp och effektens timing.
- [IEffect.Behaviors](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/ieffect/behaviors/) innehåller de operationer som implementerar effekten: färgändring, förflyttning, rotation, egendefiniering osv.

## **Skapa enskilda beteenden**

Anropa [ISequence.AddEffect](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/isequence/addeffect/) för att skapa en effekt och få åtkomst till dess [Behaviors](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/ieffect/behaviors/)‑samling. En förinställning kan fylla i denna samling automatiskt. Behåll dess operationer när du utökar förinställningen, eller använd [Clear](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/ibehaviorcollection/clear/) när du medvetet ersätter dem.

[IBehaviorFactory](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/ibehaviorfactory/) skapar de åtta beteendetyper som illustreras nedan. Rörelse behandlas i [Bygg en rörelsestråle](#build-a-motion-path). Varje skapelseexempel är ett komplett program; senare redigeringsexempel anger vilken utskriftsfil de använder.

### **Rotation**

Använd [CreateRotationEffect](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/ibehaviorfactory/createrotationeffect/) för att skapa en rotation. [By](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/irotationeffect/by/) anger en relativ vinkel i grader; [From](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/irotationeffect/from/) och [To](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/irotationeffect/to/) anger ändpunkter.

Exemplet börjar med en Spin‑effekt, ersätter dess förinställda operationer med ett rotationsbeteende och ger den operationen en tvåsekunders varaktighet. En relativ vinkel på 90 grader motsvarar en kvartsvarv från formens startorientering, så ingen explicit startvinkel behövs.

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

`rotation.pptx` innehåller en form och ett rotationsbeteende. Samlingen, timing‑ och rotationsredigeringsexemplen nedan använder denna fil.

### **Skala**

Använd [CreateScaleEffect](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/ibehaviorfactory/createscaleeffect/) med X/Y‑procent: [From](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/iscaleeffect/from/) och [To](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/iscaleeffect/to/) beskriver start‑ och slutstorlek, medan [By](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/iscaleeffect/by/) beskriver en relativ förändring. Här betyder 100 den ursprungliga storleken.

Exemplet ökar båda dimensionerna från 100 % till 125 % under två sekunder. Att använda lika horisontella och vertikala procent håller formens proportioner; olika procent skulle sträcka en dimension mer än den andra.

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

### **Färg**

Använd [CreateColorEffect](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/ibehaviorfactory/createcoloreffect/) för att ändra fyllningen från blå till orange. [From](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/icoloreffect/from/) och [To](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/icoloreffect/to/) är färger; [By](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/icoloreffect/by/) är en färgförskjutning. [IBehavior.Properties](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/ibehavior/properties/) identifierar den egenskap som animeras.

Formens solida fyllning initieras till blå, vilket matchar animationens startfärg. Att välja fyllningsfärg‑attributet talar om för beteendet vilken del av formen som ska ändras; färgändpunkterna i sig identifierar inte attributet. Den sparade effekten beskriver en tvåsekunders övergång till orange.

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

### **Filter**

Använd [CreateFilterEffect](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/ibehaviorfactory/createfiltereffect/) för att välja en svepning. [Type](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/ifiltereffect/type/), [Subtype](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/ifiltereffect/subtype/), och [Reveal](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/ifiltereffect/reveal/) anger filtret, riktning och om formen ska avslöjas eller döljas.

Detta exempel konfigurerar en tvåsekunders svepning som avslöjar formen med undertypen höger‑riktning. Filterinställningarna tillhör beteendet inom effekten, så de konfigureras efter att förinställningens ursprungliga operationer har tagits bort.

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

### **Egenskap**

Använd [CreatePropertyEffect](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/ibehaviorfactory/createpropertyeffect/) för att animera opacitet. [From](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/ipropertyeffect/from/), [To](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/ipropertyeffect/to/), och [By](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/ipropertyeffect/by/) är strängar som tolkas med [ValueType](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/ipropertyeffect/valuetype/) och [CalcMode](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/ipropertyeffect/calcmode/). Välj ändpunkter eller en relativ förskjutning i stället för att sätta alla tre godtyckligt.

Här är den valda egenskapen opacitet, och de numeriska strängarna representerar en förändring från 25 % opacitet till full opacitet. Linjär interpolering beskriver en gradvis förändring mellan dessa värden. När du anpassar detta exempel till en annan egenskap, välj en värdetyp och ändpunktsvärden som passar den egenskapen.

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

### **Sätt**

Använd [CreateSetEffect](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/ibehaviorfactory/createseteffect/) för att tilldela synlighet via [To](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/iseteffect/to/). Ett set‑beteende interpolerar inte mellan ändpunkter.

Exemplet väljer synlighetsattributet och tilldelar strängen `visible` när beteendet körs. Rektangeln är redan synlig i denna minimala presentation, så tilldelningen kanske inte ger någon uppenbar visuell förändring i sig. En sådan operation är användbar som del av en större effekt som också styr när formen blir dold eller synlig.

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

### **Kommando**

Använd [CreateCommandEffect](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/ibehaviorfactory/createcommandeffect/) och konfigurera [Type](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/icommandeffect/type/), [CommandString](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/icommandeffect/commandstring/), och [ShapeTarget](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/icommandeffect/shapetarget/). Placera en WAV‑inspelning med namnet `sample.wav` i arbetskatalogen. Detta exempel bäddar in den med [AddAudioFrameEmbedded](https://reference.aspose.com/slides/sv/net/aspose.slides/ishapecollection/addaudioframeembedded/) och fäster ett play‑kommando på ljud‑ramen.

Ljud‑ramen är både effektens mål och kommandots mål. Detta kopplar uppspelningsbegäran till den inbäddade inspelningen; en kommandosträng i sig identifierar inte vilket medieobjekt som ska styras. Effekten är konfigurerad att starta på ett klick under bildspelet.

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

Sparandet lagrar kommandot i `command.pptx`; inspelningen spelas inte upp. Uppspelning kräver en bildspelar‑motor som stöder kommandot och dess mediamål.

## **Hantera beteendesamlingen**

[IBehaviorCollection](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/ibehaviorcollection/) stöder [Add](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/ibehaviorcollection/add/), [Insert](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/ibehaviorcollection/insert/), [Remove](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/ibehaviorcollection/remove/), och [RemoveAt](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/ibehaviorcollection/removeat/). Detta exempel öppnar `rotation.pptx`, lägger till skalning, flyttar den före rotation och tar bort rotationen. Att ta bort och återinföra samma objekt ändrar dess lagrade position utan att göra en kopia.

Redigeringssekvensen ändrar samlingen från rotation–skala till skala–rotation, och slutligen bara skala. Index refererar till den aktuella samlingen, så borttagningen använder rotationens nya index efter omordning. Den slutgiltiga enumerationen bekräftar vilket beteende som kommer sparas.

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

Utdatan är `ScaleEffect`: endast skalning återstår. Samlingsordning i sig schemalägger inte beteenden ett efter ett. Rensa samlingen endast när du ersätter alla dess operationer.

## **Konfigurera beteendetiming**

[IBehavior.Timing](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/ibehavior/timing/) exponerar [ITiming](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/itiming/), oberoende av [IEffect.Timing](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/ieffect/timing/). Effekt‑timing schemalägger den omslutande effekten; beteendetiming beskriver en operation inom den.

### **Ställ in varaktighet, fördröjning, upprepning och acceleration**

Öppna `rotation.pptx` och sätt [Duration](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/itiming/duration/) samt [TriggerDelayTime](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/itiming/triggerdelaytime/) i sekunder, konfigurera sedan [RepeatCount](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/itiming/repeatcount/). [Accelerate](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/itiming/accelerate/) och [Decelerate](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/itiming/decelerate/) är bråkdelar av varaktigheten; håll deras summa högst 1.

Ingångsfilen är den som skapades i rotations‑exemplet, där det första beteendet är känt som en rotation. Detta exempel ändrar endast den beteendets timing; dess 90‑graders vinkel förblir intakt. Att hålla vinkel och timing separata gör det enklare att justera takten utan att bygga om animationen.

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

Beteendet använder en tvåsekunders varaktighet, en halvt sekunders fördröjning och ett upprepningsantal på 3. De första och sista 20 % av varaktigheten används för acceleration respektive deceleration.

Andra upprepningspolicys inkluderar [RepeatDuration](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/itiming/repeatduration/), [RepeatUntilEndSlide](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/itiming/repeatuntilendslide/), och [RepeatUntilNextClick](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/itiming/repeatuntilnextclick/); välj en policy i stället för att aktivera dem alla samtidigt. [AutoReverse](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/itiming/autoreverse/) spelar animationen baklänges efter den framåtriktade passagen. Acceleration och deceleration gäller kontinuerliga förändringar, inte diskreta tilldelningar eller kommandon.

## **Bygg en rörelsestråle**

Använd [CreateMotionEffect](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/ibehaviorfactory/createmotioneffect/) för att skapa rörelse. Dess [From](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/imotioneffect/from/), [To](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/imotioneffect/to/), och [By](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/imotioneffect/by/) beskriver procent‑baserade koordinater eller förskjutningar. För en redigerbar bana, skapa en [MotionPath](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/motionpath/) och tilldela den till [IMotionEffect.Path](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/imotioneffect/path/). [IMotionPath](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/imotionpath/) lagrar ban‑kommandona.

[MotionCommandPathType](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/motioncommandpathtype/) väljer operationen:

| Kommando | Punkter | Betydelse |
| --- | --- | --- |
| MoveTo | One | Sätt startpositionen. |
| LineTo | One | Förflytta längs ett rakt segment till dess slutpunkt. |
| CurveTo | Three | Följ en kubisk kurva definierad av två styrpunkter och en slutpunkt. |
| CloseLoop | None | Återgå till startpositionen. |
| End | None | Avsluta banan. |

[MotionPathPointsType](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/motionpathpointstype/) beskriver egenskaper för punktredigering, såsom hörn‑ eller släta punkter. Det ersätter inte kommandotypen. Använd en kurvpunkttyp för kursexemplet nedan och en hörnpunkttyp för de raka segmenten.

Bananvända koordinater normaliseras till bildens dimensioner: en X‑förskjutning på 0,25 motsvarar en fjärdedel av bildbredden, inte 0,25 punkter. Positiv Y går nedåt. Absoluta kommandon anger positioner i ban‑koordinatsystemet; relativa kommandon anger förskjutningar från den aktuella positionen. Detta är separat från [Origin](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/imotioneffect/origin/), som väljer referensram för banan, och [PathEditMode](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/imotioneffect/patheditmode/), som styr hur banan rör sig när formen flyttas.

### **Skapa en rak bana**

Skapa ett rörelsbeteende med en startpunkt, ett rakt segment och ett slut‑kommando. [IMotionPath.Add](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/imotionpath/add/) tar kommandotyp, dess punkter, punkt‑typ och en relativ‑koordinat‑flagga.

Startkommandot etablerar (0, 0) och linjen avslutas vid (0,25, 0), vilket ger banan en horisontell förskjutning på en fjärdedel av bildbredden. Slutkommandot har inga koordinatpunkter. När banan har tilldelats, kopplar tillägget av rörelsbeteendet till effekten den rutten till rektangeln.

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

`motion.pptx` innehåller ett rörelsbeteende med tre ban‑kommandon. Följande fil‑redigeringsexempel använder denna kända struktur.

### **Jämför absoluta och relativa koordinater**

Dessa två ban‑objekt beskriver samma bana. Det absoluta kommandot slutar vid (0,3, 0,1); det relativa kommandot lägger till (0,1, 0,1) till den aktuella positionen, (0,2, 0).

Båda banor startar på samma position. För den relativa linjen adderar du dess X‑ och Y‑förskjutningar till den aktuella positionen för att få slutpunkten; för den absoluta linjen läser du slutpunkten direkt. Att bara byta flagga utan att konvertera koordinaterna beskriver en annan bana.

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

Tilldela antingen bana till ett rörelsbeteende för att använda den i en presentation. Det sista booleska argumentet väljer relativa koordinater för det kommandot.

### **Ersätt en linje med en kurva**

Öppna `motion.pptx` och ersätt dess linjekommando med en kubisk kurva. Ange först de två styrpunkterna, följt av slutpunkten.

Startpositionen tillhandahålls av föregående kommando. De två första punkterna formar kurvan, medan den tredje är dess destination; de är inte tre på varandra följande destinationer. Att uppdatera kommandotyp, punkt‑redigeringstyp och punkt‑array tillsammans håller segmentet konsistent med dess nya geometri.

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

Banen i `curve.pptx` har fortfarande tre kommandon; dess mittkommandon definierar nu en kurva.

## **Läs och redigera en sparad bana**

Varje [IMotionCmdPath](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/imotioncmdpath/) exponerar [Points](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/imotioncmdpath/points/), [CommandType](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/imotioncmdpath/commandtype/), [PointsType](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/imotioncmdpath/pointstype/), och [IsRelative](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/imotioncmdpath/isrelative/). Följande exempel använder den kända tre‑kommandobanen i `motion.pptx`. För godtycklig indata, lokalisera den avsedda effekten och kontrollera kommandotyper och antal punkter innan du redigerar efter index.

### **Läs kommandon och koordinater**

Läs banan utan att ändra den. Slut‑ och close‑loop‑kommandon kräver inga punkter, så tillåt en null‑punkt‑array.

Utdatan parar varje kommando med dess relativ‑koordinat‑flagga innan punkterna listas. Detta låter dig skilja en slutpunkt från en förskjutning före du modifierar banan. En kurva skulle lista tre punkter, medan den raka linjen i denna fil listar endast en.

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

Listan innehåller en startpunkt, en absolut linje som slutar vid (0,25, 0) och ett slut‑kommando.

### **Ändra en slutpunkt**

Öppna `motion.pptx` och ersätt linjens punkt‑array för att flytta dess slutpunkt.

I input‑filen är index 0 startkommandot och index 1 linjen. Att ersätta linjens enda punkt ändrar dess destination utan att ändra kommandotyp, timing eller position i samlingen. Eftersom kommandot använder absoluta koordinater specificerar det nya paret en position snarare än en tillagd förskjutning.

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

Linjen i `motion-endpoint.pptx` slutar vid (0,4, 0,1); originalfilen är oförändrad.

### **Ersätt ett segment**

Använd [Insert](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/imotionpath/insert/) och [RemoveAt](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/imotionpath/removeat/) för att ersätta linjen i `motion.pptx`. Infogning skjuter den gamla linjen till index 2.

Detta demonstrerar ersättning av ett kommando‑objekt snarare än att redigera dess befintliga koordinater. Efter infogning innehåller samlingen tillfälligt startkommandot, den nya linjen, den gamla linjen och slut‑kommandot. Att ta bort index 2 förkastar den gamla linjen och lämnar den nya banan på plats.

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

Den sparade banan har fortfarande tre kommandon, med den nya linjen som slutar vid (0,2, 0,1) och slut‑kommandot sist.

## **Modifiera och verifiera ett befintligt beteende**

När beteendets index är okänt, välj det efter typ. Detta exempel öppnar `rotation.pptx`, hittar dess [IRotationEffect](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/irotationeffect/), ändrar vinkeln och kontrollerar det sparade värdet efter att filen åter öppnats.

Typkontrollen gör att loopen kan hoppa över beteenden som inte är rotationer. Den andra inläsningen läser den sparade filen i ett separat presentationsobjekt, så jämförelsen kontrollerar persisterade data snarare än värdet som fortfarande finns i minnet. Detta exempel förutsätter fortfarande att den kända effekten är den första i huvudsekvensen; att välja ett beteende efter typ lokalisera inte rätt effekt i en godtycklig presentation.

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

Utdatan är `Rotation preserved: True`. Använd samma typ‑kontrollmönster för andra beteenden. För en fullständig bevarandekontroll, jämför målformen, effekt‑ och beteendetyp samt ordning, timing och ban‑kommandon. Använd en numerisk tolerans för flyttal. För en presentation med okänd animationslayout, se [Läs form‑animationer](/slides/sv/net/shape-animation/#read-shape-animations) för traversal av huvud‑ och interaktiva sekvenser.

## **Beteendeordning, förinställningar och uppspelning**

Ordningen i [IBehaviorCollection](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/ibehaviorcollection/) är den lagrade ordningen av en effektens operationer. Det är inte en spellista där varje beteende automatiskt väntar på föregående. Timing och den omslutande effekten bestämmer schemaläggning. Beteenden kan överlappa, och operationer på samma egenskap kan interagera via [Additive](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/ibehavior/additive/) och [Accumulate](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/ibehavior/accumulate/). Använd inte enbart omordning av samlingen för att schemalägga “flytta, sedan rotera”; använd explicit timing eller separata effekter enligt beskrivningen i [Formanimation](/slides/sv/net/shape-animation/).

Effektens [Type](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/ieffect/type/) och [Subtype](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/ieffect/subtype/) beskriver dess förinställning. De är inte en komplett beskrivning av ett redigerat beteendetträd. Välj förinställning och undertyp innan du anpassar beteenden: att ändra förinställningen kan bygga om samlingen och ta bort dina anpassade operationer. Till exempel kan en ändring av en anpassad Spin‑effekt till Fade ersätta dess rotationsbeteende med set‑ och filter‑beteenden. Inspektera samlingen igen efter att du ändrat förinställning eller undertyp. Att rensa förinställnings‑beteenden kan också ta bort synlighets‑ eller initialiseringsoperationer som förinställningen behöver. Exemplen använder medvetet synliga former och ersätter beteendena; de återskapar inte varje förinställnings implementation.

## **Format‑kompatibilitet**

Ett bevarat beteendetträd garanterar inte identisk uppspelning i varje visare eller export‑renderare. Kontrollera sparade data och den renderade utskriften separat.

| Format eller output | Vad som ska verifieras |
| --- | --- |
| PPTX | Använd som primärt format för dessa exempel. Öppna igen för att verifiera det redigerbara beteendetträdet, och kontrollera sedan uppspelning i avsedd PowerPoint‑version. |
| PPT | Äldre binär representation kan skilja sig från PPTX. Testa en separat spara‑och‑öppna‑cykel och uppspelning; dra inte slutsatsen att alla anpassade kombinationer stöds bara för att PPTX fungerar. |
| PDF, PNG, JPEG och andra statiska bild‑bilder | Innehåller en statisk bildrepresentation, inte en spelbar beteendetidslinje eller garanterat slut‑animationsram. |
| [HTML5](/slides/sv/net/export-to-html5/) | Kan spela stödjade animationer när form‑animation är aktiverad i exportalternativen. Testa anpassade kombinationer i webbläsaren. |
| [Animated GIF](/slides/sv/net/convert-powerpoint-to-animated-gif/) | Lagrar renderade ramar, inte redigerbara beteenden eller klick‑utlösta interaktioner. Kontrollera den faktiska renderade rörelsen. |
| [Video](/slides/sv/net/convert-powerpoint-to-video/) | Renderar animationsramar och kodar dem som video. Stödet är begränsat till renderarens [stödda animationer och effekter](/slides/sv/net/convert-powerpoint-to-video/#supported-animations-and-effects); kommandon och interaktiva händelser blir inte ett redigerbart tidslinje. |

## **FAQ**

**Varför innehåller min effekt beteenden innan jag lagt till någon?**

Att skapa en fördefinierad effekt kan skapa dess underliggande operationer. Inspektera dem innan du bestämmer dig för att utöka förinställningen eller ersätta dess beteenden.

**Gör det att flytta ett beteende till början att det spelas först?**

Inte nödvändigtvis. Samlingsordning ersätter inte timing. Kontrollera fördröjningar, varaktigheter och interaktioner mellan operationer på samma egenskap.

**Varför har ett slut‑kommando inga punkter?**

Det markerar banans slut och kräver inga koordinater. Kontrollera en null‑punkt‑array när du inspekterar en bana läst från en fil.

**Är en lyckad rundresa tillräcklig för att bekräfta uppspelning?**

Nej. Att öppna igen bekräftar bevarandet av de egenskaper du kontrollerade. Testa bildspelar‑programmet eller den animerade exporten separat för att bekräfta dess visuella beteende.