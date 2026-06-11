---
title: Applicera formanimationer i presentationer på Android
linktitle: Formanimation
type: docs
weight: 60
url: /sv/androidjava/shape-animation/
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
- Android
- Java
- Aspose.Slides
description: "Upptäck hur du skapar och anpassar formanimationer i PowerPoint-presentationer med Aspose.Slides för Android via Java. Stick ut!"
---
## **Introduktion**

Animationer är visuella effekter som kan tillämpas på text, bilder, former eller [diagram](https://docs.aspose.com/slides/sv/androidjava/animated-charts/). De ger liv åt presentationer eller dess beståndsdelar.

## **Varför använda animationer i presentationer?**

* kontrollera informationsflödet
* betona viktiga punkter
* öka intresse eller deltagande bland din publik
* göra innehållet lättare att läsa, förstå eller bearbeta
* rikta dina läsares eller tittares uppmärksamhet mot viktiga delar i en presentation

PowerPoint erbjuder många alternativ och verktyg för animationer och animationseffekter inom kategorierna **entrance**, **exit**, **emphasis** och **motion paths**.

## **Animationer i Aspose.Slides**

* Aspose.Slides tillhandahåller de klasser och typer du behöver för att arbeta med animationer under `Aspose.Slides.Animation`-namnrymden,
* Aspose.Slides erbjuder över **150 animationseffekter** under [EffectType](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/effecttype)-enumerationen. Dessa effekter är i huvudsak samma (eller motsvarande) effekter som används i PowerPoint.

## **Tillämpa animation på en textruta**

Aspose.Slides för Android via Java låter dig tillämpa animation på texten i en form.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Presentation).
2. Hämta en referens till en bild via dess index.
3. Lägg till en `rectangle` [IAutoShape](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iautoshape).
4. Lägg till text till [IAutoShape.TextFrame](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IAutoShape#addTextFrame-java.lang.String-).
5. Hämta en huvudsekvens av effekter.
6. Lägg till en animationseffekt till [IAutoShape](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iautoshape).
7. Ställ in egenskapen `TextAnimation.BuildType` till värdet från `BuildType`‑enumerationen.
8. Skriv presentationen till disk som en PPTX‑fil.

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

    // Lägger till Fade‑animationseffekt på formen
    IEffect effect = sequence.addEffect(autoShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // Animera formens text efter 1:a nivåns stycken
    effect.getTextAnimation().setBuildType(BuildType.ByLevelParagraphs1);

    // Spara PPTX‑filen till disk
    pres.save(path + "AnimText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{%  alert color="primary"  %}} 

Förutom att applicera animationer på text kan du också applicera animationer på ett enskilt [Paragraph](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iparagraph). Se [**Animated Text**](/slides/sv/androidjava/animated-text/).

{{% /alert %}} 

## **Tillämpa animation på en PictureFrame**

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Presentation).
2. Hämta en referens till en bild via dess index.
3. Lägg till eller hämta en [PictureFrame](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/pictureframe) på bilden.
4. Hämta huvudsekvensen av effekter.
5. Lägg till en animationseffekt till [PictureFrame](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/pictureframe).
6. Skriv presentationen till disk som en PPTX‑fil.

```java
// Instansierar en presentationsklass som representerar en presentationsfil.
Presentation pres = new Presentation();
try {
    // Ladda bild som ska läggas till i presentations bildsamlingen
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

    // Lägger till Fly‑från‑vänster‑animationseffekt på bildramen
    IEffect effect = sequence.addEffect(picFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // Spara PPTX‑filen till disk
    pres.save(path + "AnimImage_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Tillämpa animation på en form**

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Presentation).
2. Hämta en referens till en bild via dess index.
3. Lägg till en `rectangle` [IAutoShape](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iautoshape).
4. Lägg till en `Bevel`‑[IAutoShape](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iautoshape) (när detta objekt klickas spelas animationen upp).
5. Skapa en sekvens av effekter på bevel‑formen.
6. Skapa en anpassad `UserPath`.
7. Lägg till kommandon för att flytta till `UserPath`.
8. Skriv presentationen till disk som en PPTX‑fil.

```java
// Instansierar en Presentation-klass som representerar en PPTX-fil.
Presentation pres = new Presentation();
try {
    ISlide sld = pres.getSlides().get_Item(0);

    // Skapar PathFootball-effekt för befintlig form från början.
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 250, 25);
    ashp.addTextFrame("Animated TextBox");

    // Lägger till PathFootball‑animationseffekt
    pres.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(ashp, EffectType.PathFootball,
            EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // Skapar någon form av "button".
    IShape shapeTrigger = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Bevel, 10, 10, 20, 20);

    // Skapar en sekvens av effekter för den här knappen.
    ISequence seqInter = pres.getSlides().get_Item(0).getTimeline().getInteractiveSequences().add(shapeTrigger);

     // Skapar en anpassad användarväg. Vårt objekt kommer bara att flyttas efter att knappen har klickats.
    IEffect fxUserPath = seqInter.addEffect(ashp, EffectType.PathUser, EffectSubtype.None, EffectTriggerType.OnClick);

     // Lägger till kommandon för rörelse eftersom den skapade vägen är tom.
    IMotionEffect motionBvh = ((IMotionEffect)fxUserPath.getBehaviors().get_Item(0));

    Point2D.Float[] pts = new Point2D.Float[1];
    pts[0] = new Point2D.Float(0.076f, 0.59f);
    motionBvh.getPath().add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, true);
    pts[0] = new Point2D.Float(-0.076f, -0.59f);
    motionBvh.getPath().add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, false);
    motionBvh.getPath().add(MotionCommandPathType.End, null, MotionPathPointsType.Auto, false);

     // Skriver PPTX-filen till disk
    pres.save("AnimExample_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Hämta animationseffekterna som tillämpats på en form**

Följande exempel visar hur du använder metoden `getEffectsByShape` från [ISequence](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/isequence/)‑gränssnittet för att hämta alla animationseffekter som tillämpats på en form.

**Exempel 1: Hämta animationseffekter som tillämpats på en form på en normal bild**

Tidigare lärde du dig hur man lägger till animationseffekter på former i PowerPoint‑presentationer. Följande exempel kod visar hur du hämtar effekterna som tillämpats på den första formen på den första normala bilden i presentationen `AnimExample_out.pptx`.

```java
Presentation presentation = new Presentation("AnimExample_out.pptx");
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // Hämtar huvudanimationsekvensen för bilden.
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

**Exempel 2: Hämta alla animationseffekter, inklusive de som är ärvda från platshållare**

Om en form på en normal bild har platshållare som finns på layout‑bilden och/eller mästare‑bilden, och animationseffekter har lagts till dessa platshållare, så kommer alla effekter för formen att spelas upp under bildspelet, inklusive de som är ärvda från platshållarna.

Låt oss säga att vi har en PowerPoint‑presentationsfil `sample.pptx` med en bild som bara innehåller en sidfotform med texten "Made with Aspose.Slides" och effekten **Random Bars** är tillämpad på formen.

![Slide shape animation effect](slide-shape-animation.png)

Anta också att effekten **Split** är tillämpad på sidfot‑platshållaren på **layout**‑bilden.

![Layout shape animation effect](layout-shape-animation.png)

Och slutligen är effekten **Fly In** tillämpad på sidfot‑platshållaren på **master**‑bilden.

![Master shape animation effect](master-shape-animation.png)

Följande exempel kod visar hur du använder metoden `getBasePlaceholder` från [IShape](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ishape/)‑gränssnittet för att komma åt formens platshållare och hämta animationseffekterna som tillämpats på sidfotformen, inklusive de som är ärvda från platshållare placerade på layout‑ och master‑bilder.

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

```text
Main sequence of shape effects:
Fly Bottom
Split VerticalIn
RandomBars Horizontal
```

## **Ändra tidsinställningarna för animationseffekter**

Aspose.Slides för Android via Java låter dig ändra tidsinställningarna för en animationseffekt.

Detta är panelen för Animation Timing i Microsoft PowerPoint:

![example1_image](shape-animation.png)

Detta är motsvarigheterna mellan PowerPoint Timing och [Effect.Timing](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IEffect#getTiming--)‑egenskaperna:

- PowerPoint Timing **Start**‑rullgardinsmenyn motsvarar egenskapen [Effect.Timing.TriggerType](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ITiming#getTriggerType--).
- PowerPoint Timing **Duration** motsvarar egenskapen [Effect.Timing.Duration](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ITiming#getDuration--). Varaktigheten för en animation (i sekunder) är den totala tid som krävs för att animationen ska slutföra en cykel.
- PowerPoint Timing **Delay** motsvarar egenskapen [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ITiming#getTriggerDelayTime--).

Så här ändrar du Effect Timing‑egenskaperna:

1. [Apply](#apply-animation-to-shape) eller hämta animationseffekten.
2. Ställ in nya värden för de [Effect.Timing](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IEffect#getTiming--)‑egenskaper du behöver.
3. Spara den modifierade PPTX‑filen.

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

Aspose.Slides tillhandahåller dessa egenskaper för att låta dig arbeta med ljud i animationseffekter: 

- [setSound(IAudio value)](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-)
- [setStopPreviousSound(boolean value)](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/effect/#setStopPreviousSound-boolean-)

### **Lägg till ett ljud för en animationseffekt**

Denna Java‑kod visar hur du lägger till ett ljud för en animationseffekt och stoppar det när nästa effekt startar:

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

    // Kontrollerar om effekten har "No Sound"
    if (!firstEffect.getStopPreviousSound() && firstEffect.getSound() == null)
    {
        // Lägger till ljud för den första effekten
        firstEffect.setSound(effectSound);
    }

    // Hämtar den första interaktiva sekvensen för bilden.
    ISequence interactiveSequence = firstSlide.getTimeline().getInteractiveSequences().get_Item(0);

    // Sätter flaggan för effekten "Stop previous sound"
    interactiveSequence.get_Item(0).setStopPreviousSound(true);

    // Skriver PPTX-filen till disk
    pres.save("AnimExample_Sound_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Extrahera ett ljud för en animationseffekt**

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/).
2. Hämta en referens till en bild via dess index. 
3. Hämta huvudsekvensen av effekter. 
4. Extrahera den [setSound(IAudio value)](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-)‑inbäddade ljudet för varje animationseffekt.

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

        // Extraherar effektljudet i en byte-array
        byte[] audio = effect.getSound().getBinaryData();
    }
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Efter animation**

Aspose.Slides för Android via Java låter dig ändra egenskapen After animation för en animationseffekt.

Detta är panelen för Animation Effect och den utökade menyn i Microsoft PowerPoint:

![example1_image](shape-after-animation.png)

PowerPoint Effect **After animation**‑rullgardinsmenyn motsvarar dessa egenskaper: 

- [setAfterAnimationType(int value)](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ieffect/#setAfterAnimationType-int-)‑egenskapen som beskriver typen för After animation:
  * PowerPoint **More Colors** motsvarar typen [AfterAnimationType.Color](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/afteranimationtype/#Color);
  * PowerPoint **Don't Dim** motsvarar typen [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/afteranimationtype/#DoNotDim) (standard typ för After animation);
  * PowerPoint **Hide After Animation** motsvarar typen [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/afteranimationtype/#HideAfterAnimation);
  * PowerPoint **Hide on Next Mouse Click** motsvarar typen [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/afteranimationtype/#HideOnNextMouseClick);
- [setAfterAnimationColor(IColorFormat value)](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ieffect/#setAfterAnimationColor-com.aspose.slides.IColorFormat-)‑egenskapen som definierar ett färgformat för After animation. Denna egenskap fungerar tillsammans med typen [AfterAnimationType.Color](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/afteranimationtype/#Color). Om du ändrar typen till en annan, rensas färgen för After animation.

Denna Java‑kod visar hur du ändrar en After animation‑effekt:

```java
// Instansierar en presentationsklass som representerar en presentationsfil
Presentation pres = new Presentation("AnimImage_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // Hämtar den första effekten i huvudsekvensen
    IEffect firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);

    // Ändrar efteranimationstypen till Color
    firstEffect.setAfterAnimationType(AfterAnimationType.Color);

    // Ställer in efteranimationens dimfärg
    firstEffect.getAfterAnimationColor().setColor(Color.BLUE);

    // Skriver PPTX-filen till disk
    pres.save("AnimImage_AfterAnimation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Animera text**

Aspose.Slides tillhandahåller dessa egenskaper för att låta dig arbeta med *Animate text*-blocket i en animationseffekt:

- [setAnimateTextType(int value)](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ieffect/#setAnimateTextType-int-) som beskriver typen av *animate text* för effekten. Formtexten kan animeras:
  - Alla på en gång ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/animatetexttype/#AllAtOnce) typ)
  - Per ord ([AnimateTextType.ByWord](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/animatetexttype/#ByWord) typ)
  - Per bokstav ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/animatetexttype/#ByLetter) typ)
- [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-) anger en fördröjning mellan de animerade textdelarna (ord eller bokstäver). Ett positivt värde anger procent av effektens varaktighet. Ett negativt värde anger fördröjning i sekunder.

Så här kan du ändra egenskaperna för Effect Animate text:

1. [Apply](#apply-animation-to-shape) eller hämta animationseffekten.
2. Ställ in egenskapen [setBuildType(int value)](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/itextanimation/#setBuildType-int-) till värdet [BuildType.AsOneObject](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/buildtype/#AsOneObject) för att inaktivera *By Paragraphs*-animationsläget.
3. Ställ in nya värden för egenskaperna [setAnimateTextType(int value)](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ieffect/#setAnimateTextType-int-) och [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-).
4. Spara den modifierade PPTX‑filen.

```java
// Instansierar en presentationsklass som representerar en presentationsfil.
Presentation pres = new Presentation("AnimTextBox_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // Hämtar den första effekten i huvudsekvensen
    IEffect firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);

    // Ändrar effektens Textanimationstyp till "As One Object"
    firstEffect.getTextAnimation().setBuildType(BuildType.AsOneObject);

    // Ändrar effektens Animate text-typ till "By word"
    firstEffect.setAnimateTextType(AnimateTextType.ByWord);

    // Ställer in fördröjningen mellan ord till 20% av effektens varaktighet
    firstEffect.setDelayBetweenTextParts(20f);

    // Skriver PPTX-filen till disk
    pres.save("AnimTextBox_AnimateText.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Hur kan jag säkerställa att animationer bevaras när presentationen publiceras på webben?**

[Export to HTML5](/slides/sv/androidjava/export-to-html5/) och aktivera de [alternativ](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/html5options/) som ansvarar för [shape](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/html5options/#setAnimateShapes-boolean-) och [transition](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/html5options/#setAnimateTransitions-boolean-) animationer. Vanlig HTML spelar inte upp bildanimationer, medan HTML5 gör det.

**Hur påverkar ändring av z-ordning (lagerordning) för former animationen?**

Animation och ritordning är oberoende: en effekt styr tidpunkten och typen av fram- och försvinnande, medan [z-order](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/shape/#getZOrderPosition--) bestämmer vad som täcker vad. Det synliga resultatet definieras av deras kombination. (Detta är allmänt beteende i PowerPoint; Aspose.Slides modell för effekter och former följer samma logik.)

**Finns det begränsningar när animationer konverteras till video för vissa effekter?**

I allmänhet [stöds animationer](/slides/sv/androidjava/convert-powerpoint-to-video/), men sällsynta fall eller specifika effekter kan renderas annorlunda. Det rekommenderas att testa med de effekter du använder och med den aktuella versionen av biblioteket.