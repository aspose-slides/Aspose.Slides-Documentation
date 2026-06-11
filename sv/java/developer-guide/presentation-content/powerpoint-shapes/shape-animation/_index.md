---
title: Tillämpa formanimationer i presentationer med Java
linktitle: Formanimation
type: docs
weight: 60
url: /sv/java/shape-animation/
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
- Java
- Aspose.Slides
description: "Upptäck hur du skapar och anpassar formanimationer i PowerPoint-presentationer med Aspose.Slides för Java. Stick ut!"
---
## **Introduktion**

Animationer är visuella effekter som kan tillämpas på texter, bilder, former eller [charts](https://docs.aspose.com/slides/sv/java/animated-charts/). De ger liv åt presentationer eller deras beståndsdelar. 

## **Varför använda animationer i presentationer?**

Genom att använda animationer kan du 

* kontrollera informationsflödet
* betona viktiga punkter
* öka intresse eller delaktighet hos din publik
* göra innehållet lättare att läsa, assimilera eller bearbeta
* få dina läsare eller tittare att uppmärksamma viktiga delar i en presentation

PowerPoint erbjuder många alternativ och verktyg för animationer och animationseffekter inom kategorierna **entrance**, **exit**, **emphasis** och **motion paths**. 

## **Animationer i Aspose.Slides**

* Aspose.Slides tillhandahåller de klasser och typer du behöver för att arbeta med animationer under `Aspose.Slides.Animation`-namnrymden,
* Aspose.Slides tillhandahåller över **150 animation effects** under [EffectType](https://reference.aspose.com/slides/sv/java/com.aspose.slides/effecttype)‑uppräkningen. Dessa effekter är i huvudsak samma (eller motsvarande) effekter som används i PowerPoint.

## **Tillämpa animation på en textruta**

Aspose.Slides för Java gör att du kan tillämpa animation på texten i en form. 

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation).
2. Hämta en bildreferens via dess index.
3. Lägg till en `rectangle` [IAutoShape](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iautoshape). 
4. Lägg till text till [IAutoShape.TextFrame](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IAutoShape#addTextFrame-java.lang.String-).
5. Hämta en huvudsekvens av effekter.
6. Lägg till en animationseffekt på [IAutoShape](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iautoshape). 
7. Ställ in egenskapen `TextAnimation.BuildType` till värdet från `BuildType`‑uppräkningen.
8. Skriv presentationen till disk som en PPTX‑fil.

Den här Java‑koden visar hur du tillämpar `Fade`‑effekten på AutoShape och ställer in textanimationen till *By 1st Level Paragraphs*‑värde:

```java
// Instansierar en presentationsklass som representerar en presentationsfil.
Presentation pres = new Presentation();
try {
    ISlide sld = pres.getSlides().get_Item(0);

    // Lägger till en ny AutoShape med text
    IAutoShape autoShape = sld.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 100);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.setText("First paragraph \nSecond paragraph \n Third paragraph");

    // Hämtar huvudsekvensen för bilden.
    ISequence sequence = sld.getTimeline().getMainSequence();

    // Lägger till Fade-animationseffekt på formen
    IEffect effect = sequence.addEffect(autoShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // Animerar formens text efter första nivåns stycken
    effect.getTextAnimation().setBuildType(BuildType.ByLevelParagraphs1);

    // Spara PPTX-filen till disk
    pres.save(path + "AnimText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{%  alert color="primary"  %}} 

Förutom att tillämpa animationer på text kan du också tillämpa animationer på ett enskilt [Paragraph](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iparagraph). Se [**Animated Text**](/slides/sv/java/animated-text/).

{{% /alert %}} 

## **Tillämpa animation på en PictureFrame**

1. Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation)‑klassen.
2. Hämta en bilds referens via dess index.
3. Lägg till eller hämta en [PictureFrame](https://reference.aspose.com/slides/sv/java/com.aspose.slides/pictureframe) på bilden. 
4. Hämta huvudsekvensen av effekter.
5. Lägg till en animationseffekt på [PictureFrame](https://reference.aspose.com/slides/sv/java/com.aspose.slides/pictureframe).
6. Skriv presentationen till disk som en PPTX‑fil.

Den här Java‑koden visar hur du tillämpar `Fly`‑effekten på en bildram:

```java
// Instansierar en presentationsklass som representerar en presentationsfil.
Presentation pres = new Presentation();
try {
    // Ladda bild som ska läggas till i presentationens bildsamling
    IPPImage picture;
    IImage image = Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Lägger till bildram på bilden
    IPictureFrame picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, picture);

    // Hämtar huvudsekvensen för bilden.
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();

    // Lägger till Fly fr.o.m vänster-animationseffekt på bildramen
    IEffect effect = sequence.addEffect(picFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // Spara PPTX-filen till disk
    pres.save(path + "AnimImage_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Tillämpa animation på en form**

1. Skapa en instans av the [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation)‑klassen.
2. Hämta en bilds referens via dess index.
3. Lägg till en `rectangle` [IAutoShape](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iautoshape). 
4. Lägg till en `Bevel` [IAutoShape](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iautoshape) (when this object is clicked, the animation gets played).
5. Skapa en sekvens av effekter på bevelformen.
6. Skapa en anpassad `UserPath`.
7. Lägg till kommandon för att flytta till `UserPath`.
8. Skriv presentationen till disk som en PPTX‑fil.

Den här Java‑koden visar hur du tillämpar `PathFootball`‑effekten (path football) på en form:

```java
// Instansiera en Presentation-klass som representerar en PPTX-fil.
Presentation pres = new Presentation();
try {
    ISlide sld = pres.getSlides().get_Item(0);

    // Skapar PathFootball-effekt för befintlig form från grunden.
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 250, 25);
    ashp.addTextFrame("Animated TextBox");

    // Lägger till PathFootBall-animeringseffekten
    pres.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(ashp, EffectType.PathFootball,
            EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // Skapar någon form av "knapp".
    IShape shapeTrigger = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Bevel, 10, 10, 20, 20);

    // Skapar en sekvens av effekter för denna knapp.
    ISequence seqInter = pres.getSlides().get_Item(0).getTimeline().getInteractiveSequences().add(shapeTrigger);

     // Skapar en anpassad användarväg. Vårt objekt kommer bara att flyttas efter att knappen har klickats.
    IEffect fxUserPath = seqInter.addEffect(ashp, EffectType.PathUser, EffectSubtype.None, EffectTriggerType.OnClick);

     // Lägger till kommandon för rörelse eftersom den skapade vägen är tom.
    IMotionEffect motionBhv = ((IMotionEffect)fxUserPath.getBehaviors().get_Item(0));

    Point2D.Float[] pts = new Point2D.Float[1];
    pts[0] = new Point2D.Float(0.076f, 0.59f);
    motionBhv.getPath().add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, true);
    pts[0] = new Point2D.Float(-0.076f, -0.59f);
    motionBhv.getPath().add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, false);
    motionBhv.getPath().add(MotionCommandPathType.End, null, MotionPathPointsType.Auto, false);

     // Skriver PPTX-filen till disk
    pres.save("AnimExample_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Hämta animationseffekterna som tillämpats på en form**

Följande exempel visar hur du använder metoden `getEffectsByShape` från gränssnittet [ISequence](https://reference.aspose.com/slides/sv/java/com.aspose.slides/isequence/) för att hämta alla animationseffekter som tillämpats på en form.

**Exempel 1: Hämta animationseffekter som tillämpats på en form på en normal bild**

Tidigare lärde du dig hur du lägger till animationseffekter på former i PowerPoint‑presentationer. Följande exempelkod visar hur du hämtar effekterna som tillämpats på den första formen på den första normala bilden i presentationen `AnimExample_out.pptx`.

```java
Presentation presentation = new Presentation("AnimExample_out.pptx");
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // Hämtar huvudanimationssekvensen för bilden.
    ISequence sequence = firstSlide.getTimeline().getMainSequence();

    // Hämtar den första formen på den första bilden.
    IShape shape = firstSlide.getShapes().get_Item(0);

    // Hämtar animationseffekter som tillämpats på formen.
    IEffect[] shapeEffects = sequence.getEffectsByShape(shape);

    if (shapeEffects.length > 0)
        System.out.println("The shape " + shape.getName() + " has " + shapeEffects.length + " animation effects.");
} finally {
    if (presentation != null) presentation.dispose();
}
```

**Exempel 2: Hämta alla animationseffekter, inklusive de som ärvs från platshållare**

Om en form på en normal bild har platshållare som finns på layoutbilden och/eller huvudinbilden, och animationseffekter har lagts till på dessa platshållare, så kommer alla effekter för formen att spelas upp under bildspelet, inklusive de som ärvs från platshållarna.

Anta att vi har en PowerPoint‑presentation `sample.pptx` med en bild som bara innehåller en sidfotform med texten "Made with Aspose.Slides" och effekten **Random Bars** är tillämpad på formen.

![Bildform animationseffekt](slide-shape-animation.png)

Anta också att **Split**‑effekten är tillämpad på sidfotens platshållare på **layout**‑bilden.

![Layoutform animationseffekt](layout-shape-animation.png)

Och slutligen är **Fly In**‑effekten tillämpad på sidfotens platshållare på **master**‑bilden.

![Masterform animationseffekt](master-shape-animation.png)

Följande exempelkod visar hur du använder metoden `getBasePlaceholder` från gränssnittet [IShape](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ishape/) för att komma åt formens platshållare och hämta animationseffekterna som tillämpats på sidfotformen, inklusive de som ärvs från platshållare på layout‑ och master‑bilderna.

```java
Presentation presentation = new Presentation("sample.pptx");

ISlide slide = presentation.getSlides().get_Item(0);

// Get animation effects of the shape on the normal slide.
IShape shape = slide.getShapes().get_Item(0);
IEffect[] shapeEffects = slide.getTimeline().getMainSequence().getEffectsByShape(shape);

// Get animation effects of the placeholder on the layout slide.
IShape layoutShape = shape.getBasePlaceholder();
IEffect[] layoutShapeEffects = slide.getLayoutSlide().getTimeline().getMainSequence().getEffectsByShape(layoutShape);

// Get animation effects of the placeholder on the master slide.
IShape masterShape = layoutShape.getBasePlaceholder();
IEffect[] masterShapeEffects = slide.getLayoutSlide().getMasterSlide().getTimeline().getMainSequence().getEffectsByShape(masterShape);

System.out.println("Main sequence of shape effects:");
printEffects(masterShapeEffects);
printEffects(layoutShapeEffects);
printEffects(shapeEffects);

presentation.dispose();
```
```java
static void printEffects(IEffect[] effects)
{
    for (IEffect effect : effects)
    {
        String typeName = EffectType.getName(EffectType.class, effect.getType());
        String subtypeName = EffectSubtype.getName(EffectSubtype.class, effect.getSubtype());

        System.out.println(typeName + " " + subtypeName);
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

## **Ändra timingegenskaper för animationseffekt**

Aspose.Slides för Java gör att du kan ändra timing‑egenskaperna för en animationseffekt.

![Animation Timing i Microsoft PowerPoint](shape-animation.png)

Här är motsvarigheterna mellan PowerPoint Timing och [Effect.Timing](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IEffect#getTiming--)‑egenskaper:

- PowerPoint Timing **Start**‑rullgardinslistan matchar egenskapen [Effect.Timing.TriggerType](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ITiming#getTriggerType--) .
- PowerPoint Timing **Duration** matchar egenskapen [Effect.Timing.Duration](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ITiming#getDuration--) . Varaktigheten (i sekunder) är den totala tid som animationen tar för att slutföra en cykel. 
- PowerPoint Timing **Delay** matchar egenskapen [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ITiming#getTriggerDelayTime--) .

Så här ändrar du egenskaperna för Effect Timing:

1. [Apply](#apply-animation-to-shape) eller hämta animationseffekten.
2. Ställ in nya värden för de [Effect.Timing](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IEffect#getTiming--)‑egenskaper du behöver. 
3. Spara den ändrade PPTX‑filen.

```java
// Instansierar en presentationsklass som representerar en presentationsfil.
Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // Hämtar huvudsekvensen för bilden.
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();

    // Hämtar den första effekten i huvudsekvensen.
    IEffect effect = sequence.get_Item(0);

    // Ändrar effektens TriggerType till att starta vid klick
    effect.getTiming().setTriggerType(EffectTriggerType.OnClick);

    // Ändrar effektens varaktighet
    effect.getTiming().setDuration(3f);

    // Ändrar effektens TriggerDelayTime
    effect.getTiming().setTriggerDelayTime(0.5f);

    // Sparar PPTX-filen till disk
    pres.save("AnimExample_changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ljud för animationseffekt**

Aspose.Slides tillhandahåller dessa egenskaper för att du ska kunna arbeta med ljud i animationseffekter: 

- [setSound(IAudio value)](https://reference.aspose.com/slides/sv/java/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-) 
- [setStopPreviousSound(boolean value)](https://reference.aspose.com/slides/sv/java/com.aspose.slides/effect/#setStopPreviousSound-boolean-) 

### **Lägg till ett ljud för en animationseffekt**

Den här Java‑koden visar hur du lägger till ett ljud för en animationseffekt och stoppar det när nästa effekt startar:

```java
Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // Lägger till ljud i presentationens ljudsamling
    IAudio effectSound = pres.getAudios().addAudio(Files.readAllBytes(Paths.get("sampleaudio.wav")));

    ISlide firstSlide = pres.getSlides().get_Item(0);

    // Hämtar huvudsekvensen för bilden.
    ISequence sequence = firstSlide.getTimeline().getMainSequence();

    // Hämtar den första effekten i huvudsekvensen
    IEffect firstEffect = sequence.get_Item(0);

    // Kontrollerar om effekten har "Inget ljud"
    if (!firstEffect.getStopPreviousSound() && firstEffect.getSound() == null)
    {
        // Lägger till ljud för den första effekten
        firstEffect.setSound(effectSound);
    }

    // Hämtar den första interaktiva sekvensen för bilden.
    ISequence interactiveSequence = firstSlide.getTimeline().getInteractiveSequences().get_Item(0);

    // Ställer in flaggan "Stoppa föregående ljud" för effekten
    interactiveSequence.get_Item(0).setStopPreviousSound(true);

    // Skriver PPTX-filen till disk
    pres.save("AnimExample_Sound_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Extrahera ett ljud för en animationseffekt**

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/).
2. Hämta en bilds referens via dess index. 
3. Hämta huvudsekvensen av effekter. 
4. Extrahera den inbäddade [setSound(IAudio value)](https://reference.aspose.com/slides/sv/java/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-) för varje animationseffekt. 

Den här Java‑koden visar hur du extraherar ljudet som är inbäddat i en animationseffekt:

```java
// Instansierar en presentationsklass som representerar en presentationsfil.
Presentation presentation = new Presentation("EffectSound.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Hämtar huvudsekvensen för bilden.
    ISequence sequence = slide.getTimeline().getMainSequence();

    for (IEffect effect : sequence)
    {
        if (effect.getSound() == null)
            continue;

        // Extraherar effektljudet i en bytearray
        byte[] audio = effect.getSound().getBinaryData();
    }
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Efter animation**

Aspose.Slides för Java gör att du kan ändra egenskapen After animation för en animationseffekt.

![Efter animation i Microsoft PowerPoint](shape-after-animation.png)

PowerPoint Effect **After animation**‑rullgardinslistan matchar dessa egenskaper: 

- egenskapen [setAfterAnimationType(int value)](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ieffect/#setAfterAnimationType-int-) som beskriver typen för Efter animation :
  * PowerPoint **More Colors** matchar typen [AfterAnimationType.Color](https://reference.aspose.com/slides/sv/java/com.aspose.slides/afteranimationtype/#Color);
  * PowerPoint **Don't Dim** matchar typen [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/sv/java/com.aspose.slides/afteranimationtype/#DoNotDim) (standardtyp för efter animation);
  * PowerPoint **Hide After Animation** matchar typen [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/afteranimationtype/#HideAfterAnimation);
  * PowerPoint **Hide on Next Mouse Click** matchar typen [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/sv/java/com.aspose.slides/afteranimationtype/#HideOnNextMouseClick);
- egenskapen [setAfterAnimationColor(IColorFormat value)](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ieffect/#setAfterAnimationColor-com.aspose.slides.IColorFormat-) som definierar ett färgformat för efter animation. Denna egenskap fungerar i kombination med typen [AfterAnimationType.Color](https://reference.aspose.com/slides/sv/java/com.aspose.slides/afteranimationtype/#Color). Om du ändrar typen till en annan, rensas färgen för efter animation.

Den här Java‑koden visar hur du ändrar en efteranimationseffekt:

```java
// Instansierar en presentationsklass som representerar en presentationsfil
Presentation pres = new Presentation("AnimImage_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // Hämtar den första effekten i huvudsekvensen
    IEffect firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);

    // Ändrar efteranimationstypen till Color
    firstEffect.setAfterAnimationType(AfterAnimationType.Color);

    // Ställer in efteranimationens dim-färg
    firstEffect.getAfterAnimationColor().setColor(Color.BLUE);

    // Skriver PPTX-filen till disk
    pres.save("AnimImage_AfterAnimation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Animera text**

Aspose.Slides tillhandahåller dessa egenskaper för att du ska kunna arbeta med ett animationseffekts *Animate text*-block:

- egenskapen [setAnimateTextType(int value)](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ieffect/#setAnimateTextType-int-) som beskriver en typ av textanimation för effekten. Formens text kan animeras:
  - Alla på en gång ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/sv/java/com.aspose.slides/animatetexttype/#AllAtOnce)‑typ)
  - Ord för ord ([AnimateTextType.ByWord](https://reference.aspose.com/slides/sv/java/com.aspose.slides/animatetexttype/#ByWord)‑typ)
  - Bokstav för bokstav ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/sv/java/com.aspose.slides/animatetexttype/#ByLetter)‑typ)
- egenskapen [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-) anger en fördröjning mellan de animerade textdelarna (ord eller bokstäver). Ett positivt värde anger procentuell andel av effektens varaktighet. Ett negativt värde anger fördröjning i sekunder.

Så här kan du ändra egenskaperna för Effect Animate text:

1. [Apply](#apply-animation-to-shape) eller hämta animationseffekten.
2. Ställ in egenskapen [setBuildType(int value)](https://reference.aspose.com/slides/sv/java/com.aspose.slides/itextanimation/#setBuildType-int-) till värdet [BuildType.AsOneObject](https://reference.aspose.com/slides/sv/java/com.aspose.slides/buildtype/#AsOneObject) för att stänga av *By Paragraphs*-animatläget.
3. Ställ in nya värden för egenskaperna [setAnimateTextType(int value)](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ieffect/#setAnimateTextType-int-) och [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-).
4. Spara den ändrade PPTX‑filen.

```java
// Instansierar en presentationsklass som representerar en presentationsfil.
Presentation pres = new Presentation("AnimTextBox_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // Hämtar den första effekten i huvudsekvensen
    IEffect firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);

    // Ändrar effektens textanimations-typ till "As One Object"
    firstEffect.getTextAnimation().setBuildType(BuildType.AsOneObject);

    // Ändrar effektens animate text-typ till "By word"
    firstEffect.setAnimateTextType(AnimateTextType.ByWord);

    // Ställer in fördröjning mellan ord till 20% av effektens varaktighet
    firstEffect.setDelayBetweenTextParts(20f);

    // Skriver PPTX-filen till disk
    pres.save("AnimTextBox_AnimateText.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Hur kan jag säkerställa att animationer bevaras när presentationen publiceras på webben?**

[Export to HTML5](/slides/sv/java/export-to-html5/) och aktivera de [options](https://reference.aspose.com/slides/sv/java/com.aspose.slides/html5options/) som ansvarar för [shape](https://reference.aspose.com/slides/sv/java/com.aspose.slides/html5options/#setAnimateShapes-boolean-) och [transition](https://reference.aspose.com/slides/sv/java/com.aspose.slides/html5options/#setAnimateTransitions-boolean-) animationer. Vanlig HTML spelar inte upp bildanimationer, medan HTML5 gör det.

**Hur påverkar ändring av z‑ordning (lagerordning) för former animation?**

Animation‑ och ritordning är oberoende: en effekt styr timing och typ för framträde/försvinnande, medan [z‑order](https://reference.aspose.com/slides/sv/java/com.aspose.slides/shape/#getZOrderPosition--) bestämmer vad som täcker vad. Det synliga resultatet definieras av deras samverkan. (Detta är generellt PowerPoint‑beteende; Aspose.Slides‑modellen för effekter‑och‑former följer samma logik.)

**Finns det begränsningar när man konverterar animationer till video för vissa effekter?**

I allmänhet stöds [animations](/slides/sv/java/convert-powerpoint-to-video/) men sällsynta fall eller specifika effekter kan renderas annorlunda. Det rekommenderas att testa med de effekter du använder och med den aktuella biblioteks­versionen.