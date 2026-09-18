---
title: Aanmaken en aanpassen van aangepaste animatiegedragingen in .NET
linktitle: Aangepaste animatie
type: docs
weight: 151
url: /nl/net/custom-animation/
keywords:
- aangepaste animatie
- animatiegedrag
- bewegingspad
- PowerPoint
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Aanmaken, inspecteren en aanpassen van aangepaste animatiegedragingen en bewerkbare bewegingspaden in PowerPoint‑presentaties met Aspose.Slides voor .NET."
---
## **Overzicht**

Aangepaste animatie‑gedragingen geven u controle over individuele bewerkingen binnen een animatie‑effect, zoals het wijzigen van een kleur, het roteren van een vorm, of het volgen van een bewerkbaar bewegingspad. Deze gids laat zien hoe u gedragingen maakt en combineert, de timing configureert, bestaande animaties inspecteert en wijzigt, en controleert dat hun eigenschappen behouden blijven bij het opslaan en opnieuw openen van een presentatie.

Voor vooraf gedefinieerde effecten en klik‑triggers, zie [Vormanimatie](/slides/nl/net/shape-animation/).

## **Begrijp het animatiemodel**

- De slide‑[Timeline](https://reference.aspose.com/slides/nl/net/aspose.slides/ibaseslide/timeline/) bevat de hoofd‑sequentie en interactieve sequenties.  
- Een [ISequence](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/isequence/) bevat effecten, eventueel gericht op verschillende vormen.  
- Een [IEffect](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/ieffect/) identificeert een doelvorm, preset, subtype en effect‑timing.  
- [IEffect.Behaviors](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/ieffect/behaviors/) bevat de bewerkingen die het effect implementeren: kleur wijzigen, verplaatsen, roteren, een eigenschap instellen, enzovoort.

## **Maak individuele gedragingen**

Roep [ISequence.AddEffect](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/isequence/addeffect/) aan om een effect te maken en toegang te krijgen tot de [Behaviors](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/ieffect/behaviors/)‑collectie. Een preset kan deze collectie automatisch vullen. Houd de bewerkingen wanneer u het preset uitbreidt, of gebruik [Clear](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/ibehaviorcollection/clear/) wanneer u ze opzettelijk vervangt.

[IBehaviorFactory](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/ibehaviorfactory/) creëert de acht gedragstypen die hieronder worden geïllustreerd. Beweging wordt behandeld in [Bouw een bewegingspad](#build-a-motion-path). Elk aanmaakvoorbeeld is een compleet programma; latere bewerkingsvoorbeelden geven aan welk uitvoerbestand ze gebruiken.

### **Rotatie**

Gebruik [CreateRotationEffect](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/ibehaviorfactory/createrotationeffect/) om een rotatie te maken. [By](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/irotationeffect/by/) geeft een relatieve hoek in graden; [From](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/irotationeffect/from/) en [To](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/irotationeffect/to/) geven eindpunten.

Het voorbeeld start met een Spin‑effect, vervangt de preset‑bewerkingen door één rotatiegedrag, en geeft die bewerking een duur van twee seconden. Een relatieve hoek van 90 graden stelt een kwartdraai voor ten opzichte van de beginnende oriëntatie van de vorm, dus een expliciete starthoek is niet nodig.

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

`rotation.pptx` bevat één vorm en één rotatiegedrag. De collectie, timing en rotatie‑bewerkings‑voorbeelden hieronder gebruiken dit bestand.

### **Schaal**

Gebruik [CreateScaleEffect](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/ibehaviorfactory/createscaleeffect/) met X/Y‑percentages: [From](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/iscaleeffect/from/) en [To](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/iscaleeffect/to/) beschrijven de start‑ en eindgrootte, terwijl [By](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/iscaleeffect/by/) een relatieve wijziging beschrijft. Hier betekent 100 de oorspronkelijke grootte.

Het voorbeeld vergroot beide dimensies van 100 % naar 125 % over twee seconden. Gelijke horizontale en verticale percentages behouden de verhoudingen van de vorm; verschillende percentages zouden één dimensie meer uitrekken dan de andere.

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

### **Kleur**

Gebruik [CreateColorEffect](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/ibehaviorfactory/createcoloreffect/) om de vulling van blauw naar oranje te wijzigen. [From](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/icoloreffect/from/) en [To](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/icoloreffect/to/) zijn kleuren; [By](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/icoloreffect/by/) is een kleuroffset. [IBehavior.Properties](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/ibehavior/properties/) identificeert het attribuut dat wordt geanimeerd.

De vorm krijgt een solide vulling in blauw, overeenkomend met de startkleur van de animatie. Het selecteren van het vulling‑kleurattribuut vertelt het gedrag welk deel van de vorm moet worden gewijzigd; de kleuren‑eindpunten alleen identificeren dat attribuut niet. Het opgeslagen effect beschrijft een twee‑seconden‑overgang naar oranje.

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

Gebruik [CreateFilterEffect](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/ibehaviorfactory/createfiltereffect/) om een veeg‑filter te selecteren. [Type](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/ifiltereffect/type/), [Subtype](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/ifiltereffect/subtype/), en [Reveal](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/ifiltereffect/reveal/) geven het filter, de richting en of de vorm wordt onthuld of verborgen.

Dit voorbeeld configureert een twee‑seconden‑veeg die de vorm onthult met het subtype “right‑direction”. De filterinstellingen behoren tot het gedrag binnen het effect, dus ze worden geconfigureerd nadat de oorspronkelijke bewerkingen van het preset zijn verwijderd.

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

### **Eigenschap**

Gebruik [CreatePropertyEffect](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/ibehaviorfactory/createpropertyeffect/) om de doorzichtigheid te animeren. [From](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/ipropertyeffect/from/), [To](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/ipropertyeffect/to/), en [By](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/ipropertyeffect/by/) zijn strings die worden geïnterpreteerd met [ValueType](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/ipropertyeffect/valuetype/) en [CalcMode](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/ipropertyeffect/calcmode/). Kies eindpunten of een relatieve offset in plaats van alle drie ondoordacht te gebruiken.

Hier is het geselecteerde attribuut doorzichtigheid, en de numerieke strings vertegenwoordigen een wijziging van 25 % doorzichtigheid naar volledige doorzichtigheid. Lineaire interpolatie beschrijft een geleidelijke wijziging tussen die waarden. Bij het aanpassen van dit voorbeeld naar een ander attribuut, kies een waardetype en eindwaarden die bij dat attribuut passen.

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

### **Instellen**

Gebruik [CreateSetEffect](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/ibehaviorfactory/createseteffect/) om zichtbaarheid toe te wijzen via [To](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/iseteffect/to/). Een set‑gedrag interpoleert niet tussen eindpunten.

Het voorbeeld selecteert het zichtbaarheid‑attribuut en kent de string `visible` toe wanneer het gedrag wordt uitgevoerd. De rechthoek is al zichtbaar in deze minimale presentatie, dus de toewijzing produceert op zichzelf geen duidelijke visuele wijziging. Zo’n bewerking is nuttig als onderdeel van een groter effect dat ook bepaalt wanneer de vorm verborgen of zichtbaar wordt.

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

### **Opdracht**

Gebruik [CreateCommandEffect](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/ibehaviorfactory/createcommandeffect/) en configureer [Type](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/icommandeffect/type/), [CommandString](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/icommandeffect/commandstring/), en [ShapeTarget](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/icommandeffect/shapetarget/). Plaats een WAV‑opname genaamd `sample.wav` in de werkmap. Dit voorbeeld embedt deze met [AddAudioFrameEmbedded](https://reference.aspose.com/slides/nl/net/aspose.slides/ishapecollection/addaudioframeembedded/) en koppelt een afspeel‑opdracht aan het audio‑frame.

Audio‑frame is zowel het doel van het effect als van de opdracht. Dit verbindt het afspeelverzoek met de ingesloten opname; een opdracht‑string alleen identificeert niet welk media‑object moet worden aangestuurd. Het effect wordt geconfigureerd om te starten bij een klik tijdens de diavoorstelling.

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

Opslaan legt de opdracht vast in `command.pptx`; het speelt de opname niet af. Afspelen vereist een diavoorstellings‑speler die de opdracht en het mediadoel ondersteunt.

## **Beheer de gedrag‑collectie**

[IBehaviorCollection](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/ibehaviorcollection/) ondersteunt [Add](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/ibehaviorcollection/add/), [Insert](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/ibehaviorcollection/insert/), [Remove](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/ibehaviorcollection/remove/), en [RemoveAt](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/ibehaviorcollection/removeat/). Dit voorbeeld opent `rotation.pptx`, voegt schalen toe, verplaatst het vóór de rotatie, en verwijdert de rotatie. Verwijderen en opnieuw invoegen van hetzelfde object wijzigt de opgeslagen positie zonder een kopie te maken.

De reeks bewerkingen verandert de collectie van rotatie‑schaal naar schaal‑rotatie, daarna naar alleen schaal. Indexen verwijzen naar de actuele collectie, dus de verwijdering gebruikt de nieuwe index van de rotatie na het herschikken. De uiteindelijke enumeratie bevestigt welk gedrag zal worden opgeslagen.

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

De output is `ScaleEffect`: alleen schalen blijft over. Volgorde in de collectie bepaalt niet automatisch dat gedrag één na het andere wordt afgespeeld. Wis de collectie alleen wanneer u alle bewerkingen vervangt.

## **Configureer timing van gedrag**

[IBehavior.Timing](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/ibehavior/timing/) geeft toegang tot [ITiming](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/itiming/), onafhankelijk van [IEffect.Timing](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/ieffect/timing/). Effect‑timing plant het omvattende effect; gedrag‑timing beschrijft een bewerking binnen dat effect.

### **Stel duur, vertraging, herhaling en versnelling in**

Open `rotation.pptx` en stel [Duration](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/itiming/duration/) en [TriggerDelayTime](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/itiming/triggerdelaytime/) in seconden in, vervolgens [RepeatCount](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/itiming/repeatcount/). [Accelerate](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/itiming/accelerate/) en [Decelerate](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/itiming/decelerate/) zijn fracties van de duur; hun som mag maximaal 1 bedragen.

Het invoerbestand is het bestand dat werd gemaakt in het rotatie‑voorbeeld, waarbij bekend is dat het eerste gedrag een rotatie is. Dit voorbeeld wijzigt alleen de timing van dat gedrag; de hoek van 90 graden blijft behouden. Het gescheiden houden van hoek en timing maakt het makkelijker om het tempo aan te passen zonder de animatie opnieuw op te bouwen.

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

Het gedrag gebruikt een duur van twee seconden, een vertraging van een halve seconde, en een herhalingsaantal van 3. De eerste en laatste 20 % van de duur worden gebruikt voor versnelling en vertraging.

Andere herhaal‑strategieën omvatten [RepeatDuration](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/itiming/repeatduration/), [RepeatUntilEndSlide](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/itiming/repeatuntilendslide/), en [RepeatUntilNextClick](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/itiming/repeatuntilnextclick/); kies één beleid in plaats van ze allen tegelijk in te schakelen. [AutoReverse](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/itiming/autoreverse/) speelt de animatie achteruit af na de voorwaartse doorgang. Versnelling en vertraging gelden voor continue veranderingen, niet voor discrete toewijzingen of opdrachten.

## **Bouw een bewegingspad**

Gebruik [CreateMotionEffect](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/ibehaviorfactory/createmotioneffect/) om beweging te creëren. De [From](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/imotioneffect/from/), [To](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/imotioneffect/to/), en [By](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/imotioneffect/by/) beschrijven percentage‑gebaseerde coördinaten of offsets. Voor een bewerkbare route, maak een [MotionPath](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/motionpath/) en wijs deze toe aan [IMotionEffect.Path](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/imotioneffect/path/). [IMotionPath](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/imotionpath/) slaat de pad‑opdrachten op.

[MotionCommandPathType](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/motioncommandpathtype/) selecteert de opdracht:

| Opdracht | Punten | Betekenis |
| --- | --- | --- |
| MoveTo | One | Stelt de beginpositie in. |
| LineTo | One | Beweeg langs een rechte segment tot het eindpunt. |
| CurveTo | Three | Volg een kubieke curve gedefinieerd door twee controlepunten en een eindpunt. |
| CloseLoop | None | Keer terug naar de startpositie. |
| End | None | Beëindig het pad. |

[MotionPathPointsType](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/motionpathpointstype/) beschrijft kenmerken van puntbewerking, zoals hoek‑ of vloeiende punten. Het vervangt het opdrachttype niet. Gebruik een curve‑punttype voor het curve‑voorbeeld hieronder, en een hoek‑punttype voor de rechte segmenten.

Pad‑coördinaten worden genormaliseerd naar de afmetingen van de slide: een X‑verschuiving van 0.25 staat voor een kwart van de breedte van de slide, niet voor 0.25 punten. Positieve Y loopt naar beneden. Absoluut‑opdrachten geven posities op in het pad‑coördinatensysteem; relatieve opdrachten geven offsets ten opzichte van de huidige positie. Dit staat los van [Origin](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/imotioneffect/origin/), dat het referentiekader van het pad selecteert, en [PathEditMode](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/imotioneffect/patheditmode/), dat bepaalt hoe het pad beweegt wanneer de vorm wordt verplaatst.

### **Maak een recht pad**

Creëer een bewegingsgedrag met een startpunt, één recht segment, en een eind‑opdracht. [IMotionPath.Add](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/imotionpath/add/) neemt het opdrachttype, de punten, het punttype en een relatieve‑coördinaat‑vlag.

De startopdracht zet (0, 0), en de lijn eindigt op (0.25, 0), waardoor het traject een horizontale verschuiving van een kwart van de slide‑breedte krijgt. De eind‑opdracht heeft geen coördinaat‑punten. Zodra het pad is toegewezen, verbindt het toevoegen van het bewegingsgedrag aan het effect dat traject met de rechthoek.

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

`motion.pptx` bevat één bewegingsgedrag met drie pad‑opdrachten. De volgende bewerking‑voorbeelden gebruiken deze bekende structuur.

### **Vergelijk absolute en relatieve coördinaten**

Deze twee padobjecten beschrijven dezelfde route. De absolute opdracht eindigt op (0.3, 0.1); de relatieve opdracht voegt (0.1, 0.1) toe aan de huidige positie, (0.2, 0).

Beide paden starten op dezelfde positie. Voor de relatieve lijn voeg je de X‑ en Y‑offsets toe aan de huidige positie om het eindpunt te verkrijgen; voor de absolute lijn lees je het eindpunt direct. Het omwisselen van de vlag zonder de coördinaten om te zetten zou een andere route beschrijven.

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

Ken een van beide paden toe aan een bewegingsgedrag om het in een presentatie te gebruiken. Het laatste Booleaanse argument selecteert relatieve coördinaten voor die opdracht.

### **Vervang een lijn door een curve**

Open `motion.pptx` en vervang de lijn‑opdracht door een kubieke curve. Geef eerst de twee controlepunten op, gevolgd door het eindpunt.

De startpositie wordt geleverd door de voorafgaande opdracht. De eerste twee punten vormen de curve, terwijl het derde punt het eindpunt is; ze zijn niet drie opeenvolgende bestemmingen. Het tegelijk updaten van het opdrachttype, het punt‑bewerkings‑type en de puntarray houdt het segment consistent met de nieuwe geometrie.

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

Het pad in `curve.pptx` heeft nog steeds drie opdrachten; de middelste opdracht definieert nu een curve.

## **Inspecteer en bewerk een opgeslagen pad**

Elke [IMotionCmdPath](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/imotioncmdpath/) exposeert [Points](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/imotioncmdpath/points/), [CommandType](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/imotioncmdpath/commandtype/), [PointsType](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/imotioncmdpath/pointstype/), en [IsRelative](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/imotioncmdpath/isrelative/). De volgende voorbeelden gebruiken het bekende drie‑opdrachten‑pad in `motion.pptx`. Voor willekeurige invoer, locate het beoogde effect en controleer opdrachttypes en punt‑aantallen vóór bewerking op index.

### **Lees opdrachten en coördinaten**

Lees het pad zonder het te wijzigen. Eind‑ en sluit‑loop‑opdrachten hebben geen punten nodig, dus houd een nul‑puntarray in de gaten.

De output koppelt elke opdracht aan zijn relatieve‑coördinaat‑vlag voordat de punten worden opgesomd. Dit stelt u in staat een eindpunt van een offset te onderscheiden voordat u het pad wijzigt. Een curve zou drie punten opsommen, terwijl de rechte lijn in dit bestand er slechts één opsomt.

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

De lijst bevat een startpunt, een absolute lijn die eindigt op (0.25, 0), en een eind‑opdracht.

### **Wijzig een eindpunt**

Open `motion.pptx` en vervang de puntarray van de lijn om het eindpunt te verplaatsen.

In het invoerbestand is index 0 de start‑opdracht en index 1 de lijn. Het vervangen van het enige punt van de lijn verandert de bestemming zonder het opdrachttype, de timing of de positie in de collectie te wijzigen. Omdat de opdracht absolute coördinaten gebruikt, geeft het nieuwe paar een positie op in plaats van een toegevoegde offset.

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

De lijn in `motion-endpoint.pptx` eindigt op (0.4, 0.1); het oorspronkelijke bestand blijft ongewijzigd.

### **Vervang een segment**

Gebruik [Insert](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/imotionpath/insert/) en [RemoveAt](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/imotionpath/removeat/) om de lijn in `motion.pptx` te vervangen. Invoegen verschuift de oude lijn naar index 2.

Dit toont het vervangen van een opdrachtobject in plaats van het bewerken van bestaande coördinaten. Na invoegen bevat de collectie tijdelijk de start‑opdracht, de nieuwe lijn, de oude lijn en de eind‑opdracht. Verwijderen van index 2 verwijdert de oude lijn en laat de nieuwe route achter.

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

Het opgeslagen pad heeft nog steeds drie opdrachten, waarbij de nieuwe lijn eindigt op (0.2, 0.1) en de eind‑opdracht het laatste is.

## **Wijzig en verifieer een bestaand gedrag**

Wanneer de index van het gedrag onbekend is, selecteer het op type. Dit voorbeeld opent `rotation.pptx`, vindt de [IRotationEffect](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/irotationeffect/), wijzigt de hoek, en controleert de opgeslagen waarde na heropenen.

De type‑controle laat de lus gedragsslepen die geen rotaties zijn overslaan. De tweede load leest het opgeslagen bestand in een apart presentatiedossier, zodat de vergelijking persistente data controleert in plaats van de waarde die nog in het geheugen zit. Dit voorbeeld gaat nog steeds uit van het bekende effect als eerste in de hoofd‑sequentie; een gedrag selecteren op type localiseert niet noodzakelijk het juiste effect in een willekeurige presentatie.

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

De output is `Rotation preserved: True`. Pas hetzelfde type‑checkpatroon toe op andere gedragingen. Voor een volledige behoud‑check, vergelijk de doelvorm, het effect, gedragstypen en volgorde, timing en pad‑opdrachten. Gebruik een numerieke tolerantie voor drijvende‑komma waarden. Voor een presentatie met een onbekende animatie‑indeling, zie [Lees vormanimaties](/slides/nl/net/shape-animation/#read-shape-animations) voor traversie van hoofd‑ en interactieve sequenties.

## **Volgorde van gedrag, presets en weergave**

De volgorde in [IBehaviorCollection](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/ibehaviorcollection/) is de opgeslagen volgorde van de bewerkingen van een effect. Het is geen afspeellijst waarin elk gedrag automatisch wacht op het voorgaande. Timing en het omvattende effect bepalen de planning. Gedragingen kunnen overlappen, en bewerkingen op dezelfde eigenschap kunnen interageren via [Additive](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/ibehavior/additive/) en [Accumulate](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/ibehavior/accumulate/). Gebruik geen herschikking van de collectie alleen om “verplaatsen, dan roteren” te plannen; gebruik expliciete timing of gescheiden effecten zoals beschreven in [Vormanimatie](/slides/nl/net/shape-animation/).

Het [Type](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/ieffect/type/) en [Subtype](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/ieffect/subtype/) van het effect beschrijven de preset. Ze vormen geen volledige beschrijving van een bewerkt gedrag‑boom. Kies de preset en subtype vóór het aanpassen van gedragingen: het wijzigen van de preset kan de collectie opnieuw opbouwen en uw aangepaste bewerkingen verwijderen. Bijv. het wijzigen van een aangepast Spin‑effect naar Fade kan het rotatie‑gedrag vervangen door set‑ en filter‑gedragingen. Inspecteer de collectie opnieuw nadat u een preset of subtype hebt gewijzigd. Het wissen van preset‑gedragingen kan ook zichtbaarheid‑ of initialisatie‑bewerkingen verwijderen die de preset nodig heeft. De voorbeelden gebruiken doelbewust zichtbare vormen en vervangen de gedragingen; ze herbouwen niet de implementatie van elk preset.

## **Formaatcompatibiliteit**

Een bewaarde gedrag‑boom garandeert niet identieke weergave in iedere viewer of export‑renderer. Controleer zowel de opgeslagen data als de gerenderde output afzonderlijk.

| Formaat of output | Wat te verifiëren |
| --- | --- |
| PPTX | Gebruik als primair formaat voor deze voorbeelden. Open opnieuw om de bewerkbare gedrag‑boom te verifiëren, en controleer vervolgens de weergave in de beoogde PowerPoint‑versie. |
| PPT | Legacy‑binaire representatie kan verschillen van PPTX. Test een aparte opslaan‑en‑heropen‑cyclus en de weergave; concludeer niet dat elke aangepaste combinatie wordt ondersteund op basis van een geslaagde PPTX‑output. |
| PDF, PNG, JPEG en andere statische slide‑afbeeldingen | Bevat een statische weergave van de slide, geen afspeelbare gedrag‑tijdlijn of gegarandeerd eind‑animatie‑frame. |
| [HTML5](/slides/nl/net/export-to-html5/) | Kan ondersteunde animaties afspelen wanneer vormanimatie is ingeschakeld in de exportopties. Test aangepaste combinaties in de browser. |
| [Animated GIF](/slides/nl/net/convert-powerpoint-to-animated-gif/) | Slaat gerenderde frames op, geen bewerkbare gedragingen of klik‑gestuurde interactie. Controleer de feitelijke gerenderde beweging. |
| [Video](/slides/nl/net/convert-powerpoint-to-video/) | Render animatie‑frames en codeer ze als video. Ondersteuning is beperkt tot de renderer’s [ondersteunde animaties en effecten](/slides/nl/net/convert-powerpoint-to-video/#supported-animations-and-effects); opdrachten en interactieve gebeurtenissen worden geen bewerkbare tijdlijn. |

## **FAQ**

### **Waarom bevat mijn effect al gedragingen voordat ik er een toevoeg?**

Het aanmaken van een vooraf gedefinieerd effect kan zijn onderliggende bewerkingen creëren. Inspecteer ze voordat u beslist of u het preset uitbreidt of de gedragingen vervangt.

### **Zorgt het verplaatsen van een gedrag naar het begin ervoor dat het als eerste wordt afgespeeld?**

Niet per se. Volgorde in de collectie is geen vervanging voor timing. Controleer vertragingen, duur, en interacties tussen bewerkingen op dezelfde eigenschap.

### **Waarom heeft een einde‑opdracht geen punten?**

Het markeert het einde van het pad en heeft geen coördinaten nodig. Houd rekening met een nul‑puntarray bij het inspecteren van een pad dat uit een bestand is gelezen.

### **Is een geslaagde ronde reis voldoende om de weergave te bevestigen?**

Nee. Heropenen bevestigt alleen de behoud van de gecontroleerde eigenschappen. Test de diavoorstellings‑speler of de geanimeerde export afzonderlijk om het visuele gedrag te bevestigen.