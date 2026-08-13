---
title: Tillämpa formanimationer i presentationer i .NET
linktitle: Formanimation
type: docs
weight: 60
url: /sv/net/shape-animation/
keywords:
- form
- animation
- effekt
- animerad form
- animerad text
- lägga till animation
- hämta animation
- extrahera animation
- lägga till effekt
- hämta effekt
- extrahera effekt
- effektljud
- tillämpa animation
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Upptäck hur du skapar och anpassar formanimationer i PowerPoint-presentationer med Aspose.Slides för .NET. Stick ut!"
---
## **Introduktion**

Animationer är visuella effekter som kan tillämpas på text, bilder, former eller [diagram](/slides/sv/net/animated-charts/). De ger liv åt presentationer eller deras beståndsdelar. 

## **Varför använda animationer i presentationer?**

Genom att använda animationer kan du  

* styra informationsflödet  
* betona viktiga punkter  
* öka intresse eller deltagande bland publiken  
* göra innehållet lättare att läsa, assimilera eller bearbeta  
* leda läsarnas eller tittarnas uppmärksamhet till viktiga delar i en presentation  

PowerPoint erbjuder många alternativ och verktyg för animationer och animationseffekter inom kategorierna **ingång**, **utgång**, **betoning** och **rörelsevägar**. 

## **Animationer i Aspose.Slides**

* Aspose.Slides tillhandahåller de klasser och typer du behöver för att arbeta med animationer under namnrymden [Aspose.Slides.Animation](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/),  
* Aspose.Slides erbjuder över **150 animationseffekter** under uppräkningen [EffectType](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/effecttype). Dessa effekter är i princip samma (eller motsvarande) effekter som används i PowerPoint.  

## **Tillämpa animation på en textruta**

Aspose.Slides för .NET låter dig tillämpa animation på texten i en form. 

1. Skapa en instans av klassen [Presentation](http://www.aspose.com/api/net/slides/sv/aspose.slides/).  
2. Hämta en slides referens via dess index.  
3. Lägg till en `rectangle` [IAutoShape](https://reference.aspose.com/slides/sv/net/aspose.slides/iautoshape).  
4. Lägg till text i [IAutoShape.TextFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/iautoshape/properties/textframe).  
5. Hämta en huvudsekvens av effekter.  
6. Lägg till en animationseffekt på [IAutoShape](https://reference.aspose.com/slides/sv/net/aspose.slides/iautoshape).  
7. Ställ in egenskapen [TextAnimation.BuildType](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/textanimation/properties/buildtype) till värdet från [BuildType Enumeration](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/buildtype).  
8. Skriv presentationen till disk som en PPTX‑fil.  

Denna C#‑kod visar hur du applicerar `Fade`‑effekten på AutoShape och ställer in textanimationen till värdet *By 1st Level Paragraphs*:

```c#
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

// Skapar en presentationsklass som representerar en presentationsfil.
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];

    // Lägger till en ny AutoShape med text
    IAutoShape autoShape = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 100);

    // Lägger till tre stycken så att byggandet efter stycke har något att gå igenom.
    ITextFrame textFrame = autoShape.TextFrame;
    textFrame.Text = "First paragraph";
    textFrame.Paragraphs.Add(new Paragraph { Text = "Second paragraph" });
    textFrame.Paragraphs.Add(new Paragraph { Text = "Third paragraph" });

    // Hämtar huvudsekvensen för sliden.
    ISequence sequence = sld.Timeline.MainSequence;

    // Lägger till Fade-animationseffekt på formen
    IEffect effect = sequence.AddEffect(autoShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // Animerar formens text efter första nivåns stycken
    effect.TextAnimation.BuildType = BuildType.ByLevelParagraphs1;

    // Sparar PPTX-filen till disk
    pres.Save("AnimTextBox_out.pptx", SaveFormat.Pptx);
}
```

{{% alert color="info"%}} 

Förutom att applicera animationer på text kan du också applicera animationer på ett enskilt [Paragraph](https://reference.aspose.com/slides/sv/net/aspose.slides/iparagraph). Se [**Animated Text**](/slides/sv/net/animated-text/).

{{% /alert %}} 

## **Tillämpa animation på en PictureFrame**

1. Skapa en instans av [Presentation](http://www.aspose.com/api/net/slides/sv/aspose.slides/)‑klassen.  
2. Hämta en slides referens via dess index.  
3. Lägg till eller hämta en [PictureFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/ipictureframe) på sliden.  
5. Hämta huvudsekvensen av effekter.  
6. Lägg till en animationseffekt på [PictureFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/ipictureframe).  
8. Skriv presentationen till disk som en PPTX‑fil.  

Denna C#‑kod visar hur du applicerar `Fly`‑effekten på en bildram:

```c#
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

// Skapar en presentationsklass som representerar en presentationsfil.
using (Presentation pres = new Presentation())
{
    // Laddar bild som ska läggas till i presentationens bildsamling
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // Lägger till en bildram på sliden
    IPictureFrame picFrame = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, ppImage);

    // Hämtar huvudsekvensen för sliden.
    ISequence sequence = pres.Slides[0].Timeline.MainSequence;

    // Lägger till Fly-från-vänster-animationseffekt på bildramen
    IEffect effect = sequence.AddEffect(picFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // Sparar PPTX-filen till disk
    pres.Save("AnimImage_out.pptx", SaveFormat.Pptx);
}
```

## **Tillämpa animation på en Shape**

1. Skapa en instans av [Presentation](http://www.aspose.com/api/net/slides/sv/aspose.slides/)‑klassen.  
2. Hämta en slides referens via dess index.  
3. Lägg till en `rectangle` [IAutoShape](https://reference.aspose.com/slides/sv/net/aspose.slides/iautoshape).  
4. Lägg till en `Bevel` [IAutoShape] (när detta objekt klickas spelas animationen).  
5. Skapa en sekvens av effekter på bevelformen.  
6. Skapa en anpassad `UserPath`.  
7. Lägg till kommandon för att flytta till `UserPath`.  
8. Skriv presentationen till disk som en PPTX‑fil.  

Denna C#‑kod visar hur du applicerar `PathFootball`‑effekten på en shape:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

// Instansierar en Presentation-klass som representerar en presentationsfil.
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];

    // Skapar PathFootball-effekt för befintlig form från början.
    IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 150, 250, 25);

    ashp.AddTextFrame("Animated TextBox");

    // Lägger till PathFootBall-animeringseffekten.
    pres.Slides[0].Timeline.MainSequence.AddEffect(ashp, EffectType.PathFootball,
                           EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // Skapar någon form av "knapp".
    IShape shapeTrigger = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Bevel, 10, 10, 20, 20);

    // Skapar en sekvens av effekter för knappen.
    ISequence seqInter = pres.Slides[0].Timeline.InteractiveSequences.Add(shapeTrigger);

    // Skapar en anpassad användarväg. Vårt objekt kommer bara att flyttas efter att knappen har klickats.
    IEffect fxUserPath = seqInter.AddEffect(ashp, EffectType.PathUser, EffectSubtype.None, EffectTriggerType.OnClick);

    // Lägger till kommandon för rörelse eftersom den skapade vägen är tom.
    IMotionEffect motionBhv = ((IMotionEffect)fxUserPath.Behaviors[0]);

    PointF[] pts = new PointF[1];
    pts[0] = new PointF(0.076f, 0.59f);
    motionBhv.Path.Add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, true);
    pts[0] = new PointF(-0.076f, -0.59f);
    motionBhv.Path.Add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, false);
    motionBhv.Path.Add(MotionCommandPathType.End, null, MotionPathPointsType.Auto, false);

    // Skriver PPTX-filen till disk
    pres.Save("AnimExample_out.pptx", SaveFormat.Pptx);
}
```

## **Hämta animationseffekterna som applicerats på en Shape**

Följande exempel visar hur du använder metoden `GetEffectsByShape` från [ISequence](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/isequence/)‑gränssnittet för att hämta alla animationseffekter som applicerats på en shape.  

**Exempel 1: Hämta animationseffekter applicerade på en shape på en normal slide**

Tidigare lärde du dig hur man lägger till animationseffekter på former i PowerPoint‑presentationer. Följande exempelkod visar hur du hämtar effekterna som applicerats på den första formen på den första normala sliden i presentationen `AnimExample_out.pptx`.

```c#
using Aspose.Slides;
using Aspose.Slides.Animation;

using (Presentation presentation = new Presentation("AnimExample_out.pptx"))
{
    ISlide firstSlide = presentation.Slides[0];

    // Hämtar huvudanimationssekvensen för sliden.
    ISequence sequence = firstSlide.Timeline.MainSequence;

    // Hämtar den första formen på den första sliden.
    IShape shape = firstSlide.Shapes[0];

    // Hämtar animationseffekter som applicerats på formen.
    IEffect[] shapeEffects = sequence.GetEffectsByShape(shape);

    if (shapeEffects.Length > 0)
        Console.WriteLine($"The shape {shape.Name} has {shapeEffects.Length} animation effects.");
}
```

**Exempel 2: Hämta alla animationseffekter, inklusive de som är ärvda från platshållare**

Om en shape på en normal slide har platshållare som finns på layout‑sliden och/eller huvudsliden, och animationseffekter har lagts till dessa platshållare, då kommer alla shape‑effekter att spelas upp under bildspelet, inklusive de som ärvts från platshållarna.

Låt säga att vi har en PowerPoint‑presentationsfil `sample.pptx` med en slide som endast innehåller en sidfot‑shape med texten "Made with Aspose.Slides" och effekten **Random Bars** är applicerad på shape:n.

![Slide shape animation effect](slide-shape-animation.png)

Låt oss också anta att effekten **Split** är applicerad på sidfot‑platshållaren på **layout**‑sliden.

![Layout shape animation effect](layout-shape-animation.png)

Och slutligen är effekten **Fly In** applicerad på sidfot‑platshållaren på **master**‑sliden.

![Master shape animation effect](master-shape-animation.png)

Följande exempelkod visar hur du använder metoden `GetBasePlaceholder` från [IShape](https://reference.aspose.com/slides/sv/net/aspose.slides/ishape/)‑gränssnittet för att komma åt shape‑platshållarna och hämta animationseffekterna som applicerats på sidfot‑shape:n, inklusive de som ärvts från platshållare på layout‑ och master‑slidar.

```cs
using System;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Animation;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Hämta animationseffekter för formen på den normala sliden.
    IShape shape = slide.Shapes[0];
    IEffect[] shapeEffects = slide.Timeline.MainSequence.GetEffectsByShape(shape);

    // Hämta animationseffekter för platshållaren på layout-sliden.
    IShape layoutShape = shape.GetBasePlaceholder();
    IEffect[] layoutShapeEffects = slide.LayoutSlide.Timeline.MainSequence.GetEffectsByShape(layoutShape);

    // Hämta animationseffekter för platshållaren på master-sliden.
    IShape masterShape = layoutShape.GetBasePlaceholder();
    IEffect[] masterShapeEffects = slide.LayoutSlide.MasterSlide.Timeline.MainSequence.GetEffectsByShape(masterShape);

    Console.WriteLine("Main sequence of shape effects:");
    PrintEffects(masterShapeEffects);
    PrintEffects(layoutShapeEffects);
    PrintEffects(shapeEffects);
}

static void PrintEffects(IEnumerable<IEffect> effects)
{
    foreach (IEffect effect in effects)
    {
        Console.WriteLine($"{effect.Type} {effect.Subtype}");
    }
}
```
```cs
using Aspose.Slides.Animation;

static void PrintEffects(IEnumerable<IEffect> effects)
{
    foreach (IEffect effect in effects)
    {
        Console.WriteLine($"{effect.Type} {effect.Subtype}");
    }
}
```

Output:
```text
Main sequence of shape effects:
Fly Bottom
Split VerticalIn
RandomBars Horizontal
```

## **Ändra timing‑egenskaper för animationseffekt**

Aspose.Slides för .NET låter dig ändra timing‑egenskaperna för en animationseffekt.

Detta är Animation Timing‑panelen och det utökade menyn i Microsoft PowerPoint:

![example1_image](shape-animation.png)

Detta är motsvarigheterna mellan PowerPoint Timing och [Effect.Timing](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/effect/properties/timing)‑egenskaperna:
- PowerPoint Timing **Start**‑rullgardinslistan motsvarar egenskapen [Effect.Timing.TriggerType](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/itiming/properties/triggertype).  
- PowerPoint Timing **Duration** motsvarar egenskapen [Effect.Timing.Duration](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/itiming/properties/duration). Durationen för en animation (i sekunder) är den totala tid som animationen tar för att fullfölja en cykel.  
- PowerPoint Timing **Delay** motsvarar egenskapen [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/itiming/properties/triggerdelaytime).  
- PowerPoint Timing **Repeat**‑rullgardinslistan motsvarar dessa egenskaper:  
  * [Effect.Timing.RepeatCount](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/itiming/repeatcount)‑egenskapen som beskriver *antalet* gånger effekten upprepas;  
  * [Effect.Timing.RepeatUntilEndSlide](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/itiming/repeatuntilendslide)‑flaggan som anger om effekten upprepas tills slutet av sliden;  
  * [Effect.Timing.RepeatUntilNextClick](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/itiming/repeatuntilnextclick)‑flaggan som anger om effekten upprepas tills nästa klick.  
- PowerPoint Timing **Rewind when done playing**‑kryssrutan motsvarar egenskapen [Effect.Timing.Rewind](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/itiming/rewind/)‑egenskapen.  

Så här ändrar du Effect Timing‑egenskaperna:

1. [Apply](#apply-animation-to-shape) eller hämta animationseffekten.  
2. Ställ in nya värden för de [Effect.Timing](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/effect/properties/timing)‑egenskaper du behöver.  
3. Spara den modifierade PPTX‑filen.  

Denna C#‑kod demonstrerar operationen:

```c#
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

// Instansierar en presentationsklass som representerar en presentationsfil.
using (Presentation pres = new Presentation("AnimExample_out.pptx"))
{
    // Hämtar huvudsekvensen för sliden.
    ISequence sequence = pres.Slides[0].Timeline.MainSequence;

    // Hämtar den första effekten i huvudsekvensen.
    IEffect effect = sequence[0];

    // Ändrar effektens TriggerType så att den startar vid klick
    effect.Timing.TriggerType = EffectTriggerType.OnClick;

    // Ändrar effektens varaktighet
    effect.Timing.Duration = 3f;

    // Ändrar effektens TriggerDelayTime
    effect.Timing.TriggerDelayTime = 0.5f;

    // Om effektens Repeat‑värde är "none"
    if (effect.Timing.RepeatCount == 1f)
    {
        // Ändrar effektens Repeat till "Until Next Click"
        effect.Timing.RepeatUntilNextClick = true;
    }
    else
    {
        // Ändrar effektens Repeat till "Until End of Slide"
        effect.Timing.RepeatUntilEndSlide = true;
    }

    // Slår på Rewind för effekten
        effect.Timing.Rewind = true;
    
    // Sparar PPTX‑filen till disk
    pres.Save("AnimExample_changed.pptx", SaveFormat.Pptx);
}
```

## **Ljud för animationseffekt**

Aspose.Slides tillhandahåller dessa egenskaper för att du ska kunna arbeta med ljud i animationseffekter: 
- [IEffect.Sound](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/effect/sound/)  
- [IEffect.StopPreviousSound](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/effect/stopprevioussound/) 

### **Lägg till ljud för en animationseffekt**

Denna C#‑kod visar hur du lägger till ett ljud för en animationseffekt och stoppar det när nästa effekt startar:

```c#
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("AnimExample_out.pptx"))
{
	// Lägger till ljud i presentationens ljudsamling
	IAudio effectSound = pres.Audios.AddAudio(File.ReadAllBytes("sampleaudio.wav"));

	ISlide firstSlide = pres.Slides[0];

	// Hämtar huvudsekvensen för sliden.
	ISequence sequence = firstSlide.Timeline.MainSequence;

	// Hämtar den första effekten i huvudsekvensen
	IEffect firstEffect = sequence[0];

	// Kontrollerar om effekten har "No Sound"
	if (!firstEffect.StopPreviousSound && firstEffect.Sound == null)
	{
		// Lägger till ljud för den första effekten
		firstEffect.Sound = effectSound;
	}

	// Hämtar den första interaktiva sekvensen för sliden.
	ISequence interactiveSequence = firstSlide.Timeline.InteractiveSequences[0];

	// Ställer in flaggan "Stop previous sound" för effekten
	interactiveSequence[0].StopPreviousSound = true;

	// Skriver PPTX-filen till disk
	pres.Save("AnimExample_Sound_out.pptx", SaveFormat.Pptx);
}
```

### **Extrahera ljud för en animationseffekt**

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/).  
2. Hämta en slides referens via dess index.  
3. Hämta huvudsekvensen av effekter.  
4. Extrahera det [Sound](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/effect/sound/) som är inbäddat i varje animationseffekt.  

Denna C#‑kod visar hur du extraherar ljudet som är inbäddat i en animationseffekt:

```c#
using Aspose.Slides;
using Aspose.Slides.Animation;

// Instansierar en presentationsklass som representerar en presentationsfil.
using (Presentation presentation = new Presentation("EffectSound.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Hämtar huvudsekvensen för sliden.
    ISequence sequence = slide.Timeline.MainSequence;

    foreach (IEffect effect in sequence)
    {
        if (effect.Sound == null)
            continue;

        // Extraherar effektljudet till en bytearray
        byte[] audio = effect.Sound.BinaryData;
    }
}
```

## **Efter animation**

Aspose.Slides för .NET låter dig ändra egenskapen After animation för en animationseffekt.

Detta är Animation Effect‑panelen och det utökade menyn i Microsoft PowerPoint:

![example1_image](shape-after-animation.png)

PowerPoint Effect **After animation**‑rullgardinslistan motsvarar dessa egenskaper: 

- [IEffect.AfterAnimationType](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/ieffect/afteranimationtype/)‑egenskapen som beskriver typen för After animation :  
  * PowerPoint **More Colors** motsvarar typen [AfterAnimationType.Color](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/afteranimationtype/);  
  * PowerPoint **Don't Dim**‑objektet motsvarar typen [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/afteranimationtype/) (standard after animation‑typ);  
  * PowerPoint **Hide After Animation** motsvarar typen [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/afteranimationtype/);  
  * PowerPoint **Hide on Next Mouse Click** motsvarar typen [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/afteranimationtype/);  
- [IEffect.AfterAnimationColor](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/ieffect/afteranimationcolor/)‑egenskapen som definierar ett färgformat för after animation. Denna egenskap fungerar i samverkan med typen [AfterAnimationType.Color](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/afteranimationtype/). Om du ändrar typen till en annan kommer after animation‑färgen att rensas.  

Denna C#‑kod visar hur du ändrar en after animation‑effekt:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

// Instansierar en presentationsklass som representerar en presentationsfil
using (Presentation pres = new Presentation("AnimImage_out.pptx"))
{
    ISlide firstSlide = pres.Slides[0];

    // Hämtar den första effekten i huvudsekvensen
    IEffect firstEffect = firstSlide.Timeline.MainSequence[0];

    // Ändrar efteranimationstypen till Color
    firstEffect.AfterAnimationType = AfterAnimationType.Color;

    // Ställer in efteranimationens dimfärg
    firstEffect.AfterAnimationColor.Color = Color.AliceBlue;

    // Skriver PPTX-filen till disk
    pres.Save("AnimImage_AfterAnimation.pptx", SaveFormat.Pptx);
}
```

## **Animera text**

Aspose.Slides tillhandahåller dessa egenskaper för att du ska kunna arbeta med ett animationseffekts *Animate text*-block:  

- [IEffect.AnimateTextType](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/ieffect/animatetexttype/) som beskriver vilken typ av textanimation som effekten har. Formens text kan animeras:  
  - Alla på en gång ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/animatetexttype/)‑typen)  
  - Efter ord ([AnimateTextType.ByWord](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/animatetexttype/)‑typen)  
  - Efter bokstav ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/animatetexttype/)‑typen)  
- [IEffect.DelayBetweenTextParts](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/ieffect/delaybetweentextparts/) anger en fördröjning mellan de animerade textdelarna (ord eller bokstäver). Ett positivt värde anger procentandel av effektens varaktighet. Ett negativt värde anger fördröjning i sekunder.  

Så här kan du ändra Effect Animate text‑egenskaperna:

1. [Apply](#apply-animation-to-shape) eller hämta animationseffekten.  
2. Ställ in egenskapen [IEffect.TextAnimation.BuildType](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/itextanimation/buildtype/) till värdet [BuildType.AsOneObject](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/buildtype/) för att stänga av *By Paragraphs*-animationsläget.  
3. Ställ in nya värden för egenskaperna [IEffect.AnimateTextType](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/ieffect/animatetexttype/) och [IEffect.DelayBetweenTextParts](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/ieffect/delaybetweentextparts/).  
4. Spara den modifierade PPTX‑filen.  

Denna C#‑kod demonstrerar operationen:

```c#
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

// Instansierar en presentationsklass som representerar en presentationsfil.
using (Presentation pres = new Presentation("AnimTextBox_out.pptx"))
{
    ISlide firstSlide = pres.Slides[0];

    // Hämtar den första effekten i huvudsekvensen
    IEffect firstEffect = firstSlide.Timeline.MainSequence[0];

    // Ändrar textanimations‑typen för effekten till "As One Object"
    firstEffect.TextAnimation.BuildType = BuildType.AsOneObject;

    // Ändrar animera‑text‑typen för effekten till "By word"
    firstEffect.AnimateTextType = AnimateTextType.ByWord;

    // Ställer in fördröjningen mellan ord till 20% av effektens varaktighet
    firstEffect.DelayBetweenTextParts = 20f;

    // Skriver PPTX‑filen till disk
    pres.Save("AnimTextBox_AnimateText.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

### Hur kan jag säkerställa att animationer bevaras när presentationen publiceras på webben?

[Exportera till HTML5](/slides/sv/net/export-to-html5/) och aktivera de alternativ som ansvarar för [shape](https://reference.aspose.com/slides/sv/net/aspose.slides.export/html5options/animateshapes/) och [transition](https://reference.aspose.com/slides/sv/net/aspose.slides.export/html5options/animatetransitions/) animationer. Vanlig HTML spelar inte upp slide‑animationer, medan HTML5 gör det.  

### Hur påverkar ändring av z‑ordning (lagerrangordning) för former animation?

Animation‑ och ritordning är oberoende: en effekt styr tidpunkt och typ för framträdande/försvinnande, medan [z-order](https://reference.aspose.com/slides/sv/net/aspose.slides/shape/zorderposition/) bestämmer vad som täcker vad. Det synliga resultatet definieras av deras kombination. (Detta är det generella PowerPoint‑beteendet; Aspose.Slides‑modellen följer samma logik.)  

### Finns det begränsningar när man konverterar animationer till video för vissa effekter?

I allmänhet stöds [animationer](/slides/sv/net/convert-powerpoint-to-video/), men sällsynta fall eller specifika effekter kan renderas annorlunda. Det rekommenderas att testa med de effekter du använder och med den aktuella versionen av biblioteket.