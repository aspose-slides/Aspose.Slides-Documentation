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

Animationer är visuella effekter som kan tillämpas på texter, bilder, former eller [diagram](/slides/sv/net/animated-charts/). De ger liv åt presentationer eller deras beståndsdelar. 

## **Varför använda animationer i presentationer?**

* styra informationsflödet
* betona viktiga punkter
* öka intresse eller engagemang hos din publik
* göra innehållet lättare att läsa, assimilera eller bearbeta
* leda dina läsare eller tittare uppmärksamhet till viktiga delar i en presentation

PowerPoint erbjuder många alternativ och verktyg för animationer och animationseffekter inom kategorierna **entrance**, **exit**, **emphasis** och **motion paths**. 

## **Animationer i Aspose.Slides**

* Aspose.Slides tillhandahåller de klasser och typer du behöver för att arbeta med animationer under namnutrymmet [Aspose.Slides.Animation](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/).
* Aspose.Slides tillhandahåller över **150 animationseffekter** under uppräkningen [EffectType](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/effecttype). Dessa effekter är i princip samma (eller motsvarande) som de som används i PowerPoint.

## **Tillämpa animation på en TextBox**

Aspose.Slides för .NET låter dig applicera animation på texten i en form. 

1. Skapa en instans av klassen [Presentation](http://www.aspose.com/api/net/slides/sv/aspose.slides/).
2. Hämta en slides referens via dess index.
3. Lägg till en `rectangle` [IAutoShape](https://reference.aspose.com/slides/sv/net/aspose.slides/iautoshape). 
4. Lägg till text till [IAutoShape.TextFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/iautoshape/properties/textframe).
5. Hämta en huvudsekvens av effekter.
6. Lägg till en animationseffekt på [IAutoShape](https://reference.aspose.com/slides/sv/net/aspose.slides/iautoshape).
7. Ställ in egenskapen [TextAnimation.BuildType](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/textanimation/properties/buildtype) till värdet från [BuildType Enumeration](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/buildtype).
8. Skriv presentationen till disk som en PPTX‑fil.

```c#
// Skapar en presentation-klass som representerar en presentationsfil.
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];
    
    // Lägger till en ny AutoShape med text
    IAutoShape autoShape = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 100);

    ITextFrame textFrame = autoShape.TextFrame;
    textFrame.Text = "First paragraph \nSecond paragraph \n Third paragraph";

    // Hämtar huvudsekvensen för sliden.
    ISequence sequence = sld.Timeline.MainSequence;

    // Lägger till Fade‑animationseffekt på formen
    IEffect effect = sequence.AddEffect(autoShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // Animera formens text efter stycken på första nivån
    effect.TextAnimation.BuildType = BuildType.ByLevelParagraphs1;

    // Spara PPTX‑filen till disk
    pres.Save(path + "AnimTextBox_out.pptx", SaveFormat.Pptx);
}
```

{{%  alert color="primary"  %}} 

Förutom att applicera animationer på text kan du också applicera animationer på ett enskilt [Paragraph](https://reference.aspose.com/slides/sv/net/aspose.slides/iparagraph). Se [**Animerad text**](/slides/sv/net/animated-text/).

{{% /alert %}} 

## **Tillämpa animation på en PictureFrame**

1. Skapa en instans av klassen [Presentation](http://www.aspose.com/api/net/slides/sv/aspose.slides/).
2. Hämta en slides referens via dess index.
3. Lägg till eller hämta en [PictureFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/ipictureframe) på sliden. 
5. Hämta huvudsekvensen av effekter.
6. Lägg till en animationseffekt på [PictureFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/ipictureframe).
8. Skriv presentationen till disk som en PPTX‑fil.

```c#
// Skapar en presentation-klass som representerar en presentationsfil.
using (Presentation pres = new Presentation())
{
    // Ladda bild som ska läggas till i presentationens bildsamling
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // Lägger till en bildram på sliden
    IPictureFrame picFrame = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, ppImage);

    // Hämtar huvudsekvensen för sliden.
    ISequence sequence = pres.Slides[0].Timeline.MainSequence;

    // Lägger till Fly‑från‑vänster‑animationseffekt på bildramen
    IEffect effect = sequence.AddEffect(picFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // Spara PPTX‑filen till disk
    pres.Save("AnimImage_out.pptx", SaveFormat.Pptx);
}
```

## **Tillämpa animation på en Shape**

1. Skapa en instans av klassen [Presentation](http://www.aspose.com/api/net/slides/sv/aspose.slides/).
2. Hämta en slides referens via dess index.
3. Lägg till en `rectangle` [IAutoShape](https://reference.aspose.com/slides/sv/net/aspose.slides/iautoshape). 
4. Lägg till en `Bevel` [IAutoShape](https://reference.aspose.com/slides/sv/net/aspose.slides/iautoshape) (när detta objekt klickas på spelas animationen).
5. Skapa en sekvens av effekter på bevel‑formen.
6. Skapa en anpassad `UserPath`.
7. Lägg till kommandon för att flytta till `UserPath`.
8. Skriv presentationen till disk som en PPTX‑fil.

```c#
// Skapar en Presentation-klass som representerar en presentationsfil.
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];

    // Skapar PathFootball-effekt för befintlig form från början.
    IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 150, 250, 25);

    ashp.AddTextFrame("Animated TextBox");

    // Lägger till PathFootBall-animationseffekten.
    pres.Slides[0].Timeline.MainSequence.AddEffect(ashp, EffectType.PathFootball,
                           EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // Skapar någon typ av "knapp".
    IShape shapeTrigger = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Bevel, 10, 10, 20, 20);

    // Skapar en sekvens av effekter för knappen.
    ISequence seqInter = pres.Slides[0].Timeline.InteractiveSequences.Add(shapeTrigger);

    // Skapar en anpassad användarstig. Vårt objekt kommer endast att flyttas efter att knappen har klickats.
    IEffect fxUserPath = seqInter.AddEffect(ashp, EffectType.PathUser, EffectSubtype.None, EffectTriggerType.OnClick);

    // Lägger till kommandon för att flytta eftersom den skapade stigen är tom.
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

## **Hämta animationseffekterna som tillämpats på en Shape**

Följande exempel visar hur du använder metoden `GetEffectsByShape` från gränssnittet [ISequence](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/isequence/) för att hämta alla animationseffekter som tillämpats på en shape.

**Exempel 1: Hämta animationseffekter som tillämpats på en shape i en vanlig slide**

Tidigare lärde du dig hur du lägger till animationseffekter på former i PowerPoint‑presentationer. Följande exempel visar hur du får de effekter som tillämpats på den första formen på den första vanliga sliden i presentationen `AnimExample_out.pptx`.

```c#
using (Presentation presentation = new Presentation("AnimExample_out.pptx"))
{
    ISlide firstSlide = presentation.Slides[0];

    // Hämtar huvudanimationssekvensen för sliden.
    ISequence sequence = firstSlide.Timeline.MainSequence;

    // Hämtar den första formen på den första sliden.
    IShape shape = firstSlide.Shapes[0];

    // Hämtar animationseffekter som tillämpats på formen.
    IEffect[] shapeEffects = sequence.GetEffectsByShape(shape);

    if (shapeEffects.Length > 0)
        Console.WriteLine($"The shape {shape.Name} has {shapeEffects.Length} animation effects.");
}
```

**Exempel 2: Hämta alla animationseffekter, inklusive de som ärvs från platshållare**

Om en shape på en vanlig slide har platshållare som finns på layout‑sliden och/eller master‑sliden, och animationseffekter har lagts till på dessa platshållare, så kommer alla effekter för shape:n att spelas under bildspelet, inklusive de som ärvs från platshållarna.

Låt oss anta att vi har en PowerPoint‑fil `sample.pptx` med en slide som bara innehåller en sidfot‑shape med texten "Made with Aspose.Slides" och **Random Bars**‑effekten är tillämpad på shape:n.

![Slide form animationseffekt](slide-shape-animation.png)

Låt oss också anta att **Split**‑effekten är tillämpad på sidfot‑platshållaren på **layout**‑sliden.

![Layout form animationseffekt](layout-shape-animation.png)

Och slutligen är **Fly In**‑effekten tillämpad på sidfot‑platshållaren på **master**‑sliden.

![Master form animationseffekt](master-shape-animation.png)

Följande exempel visar hur du använder metoden `GetBasePlaceholder` från gränssnittet [IShape](https://reference.aspose.com/slides/sv/net/aspose.slides/ishape/) för att komma åt shape‑platshållarna och hämta animationseffekterna som tillämpats på sidfots‑shape:n, inklusive de som ärvs från platshållare på layout‑ och master‑slides.

```cs
using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Hämta animationseffekter för formen på den normala sliden.
    IShape shape = slide.Shapes[0];
    IEffect[] shapeEffects = slide.Timeline.MainSequence.GetEffectsByShape(shape);

    // Hämta animationseffekter för platshållaren på layout‑sliden.
    IShape layoutShape = shape.GetBasePlaceholder();
    IEffect[] layoutShapeEffects = slide.LayoutSlide.Timeline.MainSequence.GetEffectsByShape(layoutShape);

    // Hämta animationseffekter för platshållaren på master‑sliden.
    IShape masterShape = layoutShape.GetBasePlaceholder();
    IEffect[] masterShapeEffects = slide.LayoutSlide.MasterSlide.Timeline.MainSequence.GetEffectsByShape(masterShape);

    Console.WriteLine("Main sequence of shape effects:");
    PrintEffects(masterShapeEffects);
    PrintEffects(layoutShapeEffects);
    PrintEffects(shapeEffects);
}
```
```cs
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

## **Ändra timingegenskaper för animationseffekter**

Aspose.Slides för .NET låter dig ändra timingegenskaperna för en animationseffekt.

This is the Animation Timing pane and extended menu in Microsoft PowerPoint:

![example1_image](shape-animation.png)

These are the correspondences between PowerPoint Timing and [Effect.Timing](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/effect/properties/timing) properties:
- PowerPoint Timing **Start** drop‑down list matches the [Effect.Timing.TriggerType](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/itiming/properties/triggertype) property. 
- PowerPoint Timing **Duration** matches the [Effect.Timing.Duration](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/itiming/properties/duration) property. The duration of an animation (in seconds) is the total time it takes the animation to complete one cycle. 
- PowerPoint Timing **Delay** matches the [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/itiming/properties/triggerdelaytime) property. 
- PowerPoint Timing **Repeat** drop‑down list matches these properties: 
  * [Effect.Timing.RepeatCount](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/itiming/repeatcount) property which describes the *number* of times the effect is repeated;
  * [Effect.Timing.RepeatUntilEndSlide](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/itiming/repeatuntilendslide) flag which specifies whether the effect is repeated until the end of the slide;
  * [Effect.Timing.RepeatUntilNextClick](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/itiming/repeatuntilnextclick) flag which specifies whether the effect is repeated until the next click.
- PowerPoint Timing **Rewind when done playing** checkbox matches the [Effect.Timing.Rewind](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/itiming/rewind/) property. 

This is how you change the Effect Timing properties:

1. [Apply](#apply-animation-to-shape) eller hämta animationseffekten.
2. Ställ in nya värden för de [Effect.Timing](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/effect/properties/timing) egenskaper du behöver. 
3. Spara den ändrade PPTX‑filen.

```c#
// Skapar en presentation-klass som representerar en presentationsfil.
using (Presentation pres = new Presentation("AnimExample_out.pptx"))
{
    // Hämtar huvudsekvensen för sliden.
    ISequence sequence = pres.Slides[0].Timeline.MainSequence;

    // Hämtar den första effekten i huvudsekvensen.
    IEffect effect = sequence[0];

    // Ändrar effektens TriggerType till att starta vid klick
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

    // Slår på effektens Rewind
        effect.Timing.Rewind = true;
    
    // Sparar PPTX‑filen till disk
    pres.Save("AnimExample_changed.pptx", SaveFormat.Pptx);
}
```

## **Ljud för animationseffekter**

Aspose.Slides provides these properties to allow you to work with sounds in animation effects: 
- [IEffect.Sound](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/effect/sound/) 
- [IEffect.StopPreviousSound](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/effect/stopprevioussound/) 

### **Lägg till ljud för en animationseffekt**

This C# code shows you how to add an animation effect sound and stop it when the next effect starts:

```c#
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

	// Sätter flaggan "Stop previous sound" för effekten
	interactiveSequence[0].StopPreviousSound = true;

	// Skriver PPTX-filen till disk
	pres.Save("AnimExample_Sound_out.pptx", SaveFormat.Pptx);
}
```

### **Extrahera ljud för en animationseffekt**

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/).
2. Hämta en slides referens via dess index. 
3. Hämta huvudsekvensen av effekter. 
4. Extrahera [Sound](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/effect/sound/) som är inbäddat i varje animationseffekt. 

This C# code shows you how to extract the sound embedded in an animation effect:

```c#
// Skapar en presentation-klass som representerar en presentationsfil.
using (Presentation presentation = new Presentation("EffectSound.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Hämtar huvudsekvensen för sliden.
    ISequence sequence = slide.Timeline.MainSequence;

    foreach (IEffect effect in sequence)
    {
        if (effect.Sound == null)
            continue;

        // Extraherar effektens ljud som byte-array
        byte[] audio = effect.Sound.BinaryData;
    }
}
```

## **Efter animation**

Aspose.Slides för .NET låter dig ändra egenskapen After animation för en animationseffekt.

This is the Animation Effect pane and extended menu in Microsoft PowerPoint:

![example1_image](shape-after-animation.png)

PowerPoint Effect **After animation** drop‑down list matches these properties: 

- [IEffect.AfterAnimationType](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/ieffect/afteranimationtype/) property which describes the After animation type :
  * PowerPoint **More Colors** matches the [AfterAnimationType.Color](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/afteranimationtype/) type;
  * PowerPoint **Don't Dim** list item matches the [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/afteranimationtype/) type (default after animation type);
  * PowerPoint **Hide After Animation** item matches the [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/afteranimationtype/) type;
  * PowerPoint **Hide on Next Mouse Click** item matches the [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/afteranimationtype/) type;
- [IEffect.AfterAnimationColor](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/ieffect/afteranimationcolor/) property which defines an after animation color format. This property works in conjunction with the [AfterAnimationType.Color](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/afteranimationtype/) type. If you change the type to another, the after animation color will be cleared.

```c#
// Skapar en presentation-klass som representerar en presentationsfil
using (Presentation pres = new Presentation("AnimImage_out.pptx"))
{
    ISlide firstSlide = pres.Slides[0];

    // Hämtar den första effekten i huvudsekvensen
    IEffect firstEffect = firstSlide.Timeline.MainSequence[0];

    // Ändrar efteranimationstypen till Color
    firstEffect.AfterAnimationType = AfterAnimationType.Color;

    // Sätter dim‑färgen för efteranimationen
    firstEffect.AfterAnimationColor.Color = Color.AliceBlue;

    // Skriver PPTX‑filen till disk
    pres.Save("AnimImage_AfterAnimation.pptx", SaveFormat.Pptx);
}
```

## **Animera text**

Aspose.Slides provides these properties to allow you to work with an animation effect's *Animate text* block:

- [IEffect.AnimateTextType](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/ieffect/animatetexttype/) which describes an animate text type of the effect. The shape text can be animated:
  - All at once ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/animatetexttype/) type)
  - By word ([AnimateTextType.ByWord](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/animatetexttype/) type)
  - By letter ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/animatetexttype/) type)
- [IEffect.DelayBetweenTextParts](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/ieffect/delaybetweentextparts/) sets a delay between the animated text parts (words or letters). A positive value specifies the percentage of effect duration. A negative value specifies the delay in seconds.

This is how you can change the Effect Animate text properties:

1. [Apply](#apply-animation-to-shape) eller hämta animationseffekten.
2. Ställ in egenskapen [IEffect.TextAnimation.BuildType](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/itextanimation/buildtype/) till värdet [BuildType.AsOneObject](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/buildtype/) för att stänga av *By Paragraphs*-animeringen.
3. Ställ in nya värden för [IEffect.AnimateTextType](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/ieffect/animatetexttype/) och [IEffect.DelayBetweenTextParts](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/ieffect/delaybetweentextparts/).
4. Spara den ändrade PPTX‑filen.

```c#
// Instansierar en presentationsklass som representerar en presentationsfil.
using (Presentation pres = new Presentation("AnimTextBox_out.pptx"))
{
    ISlide firstSlide = pres.Slides[0];

    // Hämtar den första effekten i huvudsekvensen
    IEffect firstEffect = firstSlide.Timeline.MainSequence[0];

    // Ändrar effektens TextAnimation-typ till "As One Object"
    firstEffect.TextAnimation.BuildType = BuildType.AsOneObject;

    // Ändrar effektens AnimateText-typ till "By word"
    firstEffect.AnimateTextType = AnimateTextType.ByWord;

    // Ställer in fördröjningen mellan ord till 20% av effektens varaktighet
    firstEffect.DelayBetweenTextParts = 20f;

    // Skriver PPTX-filen till disk
    pres.Save("AnimTextBox_AnimateText.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Hur kan jag säkerställa att animationer bevaras när presentationen publiceras på webben?**

[Export to HTML5](/slides/sv/net/export-to-html5/) and enable the [options](https://reference.aspose.com/slides/sv/net/aspose.slides.export/html5options/) responsible for [shape](https://reference.aspose.com/slides/sv/net/aspose.slides.export/html5options/animateshapes/) and [transition](https://reference.aspose.com/slides/sv/net/aspose.slides.export/html5options/animatetransitions/) animations. Ren HTML spelar inte upp bildspelsanimationer, medan HTML5 gör det.

**Hur påverkar ändring av z‑order (lagerordning) för former animationen?**

Animation och ritordning är oberoende: en effekt kontrollerar timing och typ av visning/borttagning, medan [z-order](https://reference.aspose.com/slides/sv/net/aspose.slides/shape/zorderposition/) bestämmer vad som täcker vad. Det synliga resultatet definieras av deras kombination. (Detta är det generella PowerPoint‑beteendet; Aspose.Slides‑modellen för effekter och former följer samma logik.)

**Finns det begränsningar när animationer konverteras till video för vissa effekter?**

I allmänhet stöds [animationer](/slides/sv/net/convert-powerpoint-to-video/), men sällsynta fall eller specifika effekter kan renderas annorlunda. Det rekommenderas att testa med de effekter du använder och med den aktuella versionen av biblioteket.