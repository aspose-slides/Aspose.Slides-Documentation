---
title: Tillämpa formanimationer i presentationer med Python
linktitle: Formanimation
type: docs
weight: 60
url: /sv/python-net/shape-animation/
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
- Python
- Aspose.Slides
description: "Upptäck hur du skapar och anpassar formanimationer i PowerPoint- och OpenDocument-presentationer med Aspose.Slides för Python via .NET. Utmärk dig!"
---
## **Introduktion**

Animationer är visuella effekter som kan tillämpas på texter, bilder, former eller [diagram](/slides/sv/python-net/animated-charts/). De ger liv åt presentationer eller deras beståndsdelar. 

## **Varför använda animationer i presentationer?**

Genom att använda animationer kan du  

* styra flödet av information  
* betona viktiga punkter  
* öka intresse eller deltagande bland din publik  
* göra innehållet lättare att läsa, assimilera eller bearbeta  
* dra läsarens eller tittarens uppmärksamhet till viktiga delar i en presentation  

PowerPoint erbjuder många alternativ och verktyg för animationer och animationseffekter inom kategorierna **entrance**, **exit**, **emphasis** och **motion paths**. 

## **Animationer i Aspose.Slides**

* Aspose.Slides tillhandahåller de klasser och typer du behöver för att arbeta med animationer under namnutrymmet [Aspose.Slides.Animation](https://reference.aspose.com/slides/sv/python-net/aspose.slides.animation/) .
* Aspose.Slides tillhandahåller över **150 animationseffekter** under uppräkningen [EffectType](https://reference.aspose.com/slides/sv/python-net/aspose.slides.animation/effecttype/) . Dessa effekter är i princip samma (eller motsvarande) effekter som används i PowerPoint.

## **Applicera animation på TextBox**

Aspose.Slides för Python via .NET låter dig applicera animation på texten i en form. 

1. Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/) klassen.  
2. Hämta en slides referens via dess index.  
3. Lägg till en `rectangle` [IAutoShape](https://reference.aspose.com/slides/sv/python-net/aspose.slides/iautoshape/).  
4. Lägg till text till `IAutoShape.TextFrame`.  
5. Hämta en huvudsekvens av effekter.  
6. Lägg till en animationseffekt till [IAutoShape](https://reference.aspose.com/slides/sv/python-net/aspose.slides/iautoshape/).  
7. Ställ in egenskapen `TextAnimation.BuildType` till värdet från `BuildType`‑enumerationen.  
8. Skriv presentationen till disk som en PPTX‑fil.  

Denna Python‑kod visar hur du applicerar `Fade`‑effekten på AutoShape och ställer in textanimationen till värdet *By 1st Level Paragraphs*:

```python
import aspose.slides as slides

# Instansierar en presentationsklass som representerar en presentationsfil.
with slides.Presentation() as pres:
    sld = pres.slides[0]
    
    # Lägger till en ny AutoShape med text
    autoShape = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 100)

    textFrame = autoShape.text_frame
    textFrame.text = "First paragraph \nSecond paragraph \n Third paragraph"

    # Hämtar huvudsekvensen för sliden.
    sequence = sld.timeline.main_sequence

    # Lägger till Fade‑animationseffekt på formen
    effect = sequence.add_effect(autoShape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype NONE, slides.animation.EffectTriggerType.ON_CLICK)

    # Animera formens text enligt första nivåns stycken
    effect.text_animation.build_type = slides.animation.BuildType.BY_LEVEL_PARAGRAPHS1

    # Spara PPTX‑filen till disk
    pres.save("AnimText_out.pptx", slides.export.SaveFormat.PPTX)
```

{{%  alert color="primary"  %}} 

Förutom att applicera animationer på text kan du också applicera animationer på ett enskilt [Paragraph](https://reference.aspose.com/slides/sv/python-net/aspose.slides/iparagraph/). Se [**Animated Text**](/slides/sv/python-net/animated-text/).

{{% /alert %}} 

## **Applicera animation på PictureFrame**

1. Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/) klassen.  
2. Hämta en slides referens via dess index.  
3. Lägg till eller hämta en [PictureFrame](https://reference.aspose.com/slides/sv/python-net/aspose.slides/pictureframe/) på sliden.  
4. Hämta huvudsekvensen av effekter.  
5. Lägg till en animationseffekt till [PictureFrame](https://reference.aspose.com/slides/sv/python-net/aspose.slides/pictureframe/).  
6. Skriv presentationen till disk som en PPTX‑fil.  

Denna Python‑kod visar hur du applicerar `Fly`‑effekten på en bildram:

```python
import aspose.slides as slides
import aspose.pydrawing as draw


# Instansierar en presentationsklass som representerar en presentationsfil.
with slides.Presentation() as pres:
    # Ladda bild som ska läggas till i presentationens bildsamling
    img = draw.Bitmap("aspose-logo.jpg")
    image = pres.images.add_image(img)

    # Lägger till bildram på sliden
    picFrame = pres.slides[0].shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 100, 100, image)

    # Hämtar huvudsekvensen för sliden.
    sequence = pres.slides[0].timeline.main_sequence

    # Lägger till Fly‑från‑vänster‑animationseffekt på bildramen
    effect = sequence.add_effect(picFrame, slides.animation.EffectType.FLY,  
        slides.animation.EffectSubtype.LEFT, 
        slides.animation.EffectTriggerType.ON_CLICK)

    # Spara PPTX‑filen till disk
    pres.save("AnimImage_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Applicera animation på Shape**

1. Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/) klassen.  
2. Hämta en slides referens via dess index.  
3. Lägg till en `rectangle` [IAutoShape](https://reference.aspose.com/slides/sv/python-net/aspose.slides/iautoshape/).  
4. Lägg till en `Bevel` [IAutoShape](https://reference.aspose.com/slides/sv/python-net/aspose.slides/iautoshape/) (när detta objekt klickas spelas animationen).  
5. Skapa en sekvens av effekter på bevel‑formen.  
6. Skapa en anpassad `UserPath`.  
7. Lägg till kommandon för att flytta till `UserPath`.  
8. Skriv presentationen till disk som en PPTX‑fil.  

Denna Python‑kod visar hur du applicerar `PathFootball` (path football)-effekten på en form:

```python
import aspose.slides.animation as anim
import aspose.slides as slides
import aspose.pydrawing as draw

# Instansierar en Presentation-klass som representerar en PPTX-fil
with slides.Presentation() as pres:
    sld = pres.slides[0]

    # Skapar PathFootball-effekt för befintlig shape från grunden.
    ashp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 150, 250, 25)

    ashp.add_text_frame("Animated TextBox")

    # Lägger till PathFootBall-animationseffekten.
    pres.slides[0].timeline.main_sequence.add_effect(ashp, 
        anim.EffectType.PATH_FOOTBALL,
        anim.EffectSubtype.NONE, 
        anim.EffectTriggerType.AFTER_PREVIOUS)

    # Skapar någon form av "button".
    shapeTrigger = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.BEVEL, 10, 10, 20, 20)

    # Skapar en sekvens av effekter för knappen.
    seqInter = pres.slides[0].timeline.interactive_sequences.add(shapeTrigger)

    # Skapar en anpassad användar-sökväg. Vårt objekt kommer bara att flyttas efter att knappen har klickats.
    fxUserPath = seqInter.add_effect(ashp, 
        anim.EffectType.PATH_USER, 
        anim.EffectSubtype.NONE, 
        anim.EffectTriggerType.ON_CLICK)

    # Lägger till kommandon för rörelse eftersom den skapade sökvägen är tom.
    motionBhv = fxUserPath.behaviors[0]

    pts = [draw.PointF(0.076, 0.59)]
    motionBhv.path.add(anim.MotionCommandPathType.LINE_TO, pts, anim.MotionPathPointsType.AUTO, True)
    pts = [draw.PointF(-0.076, -0.59)]
    motionBhv.path.add(anim.MotionCommandPathType.LINE_TO, pts, anim.MotionPathPointsType.AUTO, False)
    motionBhv.path.add(anim.MotionCommandPathType.END, None, anim.MotionPathPointsType.AUTO, False)

    # Skriver PPTX-filen till disk
    pres.save("AnimExample_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Hämta animationseffekterna som applicerats på Shape**

Följande exempel visar hur du använder metoden `get_effects_by_shape` från klassen [Sequence](https://reference.aspose.com/slides/sv/python-net/aspose.slides.animation/sequence/) för att hämta alla animationseffekter som applicerats på en shape.

**Exempel 1: Hämta animationseffekter som applicerats på en shape på en normal slide**

Tidigare lärde du dig hur du lägger till animationseffekter på shapes i PowerPoint‑presentationer. Följande exempel­kod visar hur du hämtar effekterna som applicerats på den första shape på den första normala sliden i presentationen `AnimExample_out.pptx`.

```python
import aspose.slides as slides

with slides.Presentation("AnimExample_out.pptx") as presentation:
    first_slide = presentation.slides[0]

    # Hämtar huvudanimationsekvensen för sliden.
    sequence = first_slide.timeline.main_sequence

    # Hämtar den första shape på den första sliden.
    shape = first_slide.shapes[0]

    # Hämtar animationseffekter som tillämpats på shape.
    shape_effects = sequence.get_effects_by_shape(shape)

    if len(shape_effects) > 0:
        print("The shape", shape.name, "has", len(shape_effects), "animation effects.")
```

**Exempel 2: Hämta alla animationseffekter, inklusive de som ärvs från platshållare**

Om en shape på en normal slide har platshållare som finns på layout‑sliden och/eller mastern, och animationseffekter har lagts till dessa platshållare, så kommer alla effekter för shape att spelas upp under bildspelet, inklusive de som ärvs från platshållarna.

Anta att vi har en PowerPoint‑presentationsfil `sample.pptx` med en slide som endast innehåller en sidfot‑shape med texten "Made with Aspose.Slides" och effekten **Random Bars** har applicerats på shape.

![Slide shape animation effect](slide-shape-animation.png)

Låt oss också anta att **Split**‑effekten har applicerats på sidfot‑platshållaren på **layout**‑sliden.

![Layout shape animation effect](layout-shape-animation.png)

Och slutligen har **Fly In**‑effekten applicerats på sidfot‑platshållaren på **master**‑sliden.

![Master shape animation effect](master-shape-animation.png)

Följande exempel­kod visar hur du använder metoden `get_base_placeholder` från klassen [Shape](https://reference.aspose.com/slides/sv/python-net/aspose.slides/shape/) för att komma åt shape‑platshållarna och hämta animationseffekterna som applicerats på sidfot‑shape, inklusive de som ärvs från platshållare på layout‑ och master‑slide.

```py
import aspose.slides as slides

def print_effects(effects):
    for effect in effects:
        print(effect.type.name, effect.subtype.name)
```
```py
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    # Hämta animationseffekter för shape på den normala sliden.
    shape = slide.shapes[0]
    shape_effects = slide.timeline.main_sequence.get_effects_by_shape(shape)

    # Hämta animationseffekter för platshållaren på layout‑sliden.
    layout_shape = shape.get_base_placeholder()
    layout_shape_effects = slide.layout_slide.timeline.main_sequence.get_effects_by_shape(layout_shape)

    # Hämta animationseffekter för platshållaren på master‑sliden.
    master_shape = layout_shape.get_base_placeholder()
    master_shape_effects = slide.layout_slide.master_slide.timeline.main_sequence.get_effects_by_shape(master_shape)

    print("Main sequence of shape effects:")
    print_effects(master_shape_effects)
    print_effects(layout_shape_effects)
    print_effects(shape_effects)
```

Output:
```text
Main sequence of shape effects:
FLY BOTTOM
SPLIT VERTICAL_IN
RANDOM_BARS HORIZONTAL
```

## **Ändra timing‑egenskaper för animationseffekt**

Aspose.Slides för Python via .NET låter dig ändra timing‑egenskaperna för en animationseffekt.

Det här är panelen Animation Timing i Microsoft PowerPoint:

![example1_image](shape-animation.png)

Detta är motsvarigheterna mellan PowerPoint Timing och `Effect.Timing`‑egenskaperna:

- PowerPoint Timing **Start**-rullgardinslistan matchar egenskapen [Effect.Timing.TriggerType](https://reference.aspose.com/slides/sv/python-net/aspose.slides.animation/effecttriggertype/) .  
- PowerPoint Timing **Duration** matchar egenskapen `Effect.Timing.Duration`. Durationen för en animation (i sekunder) är den totala tid det tar för animationen att slutföra en cykel.  
- PowerPoint Timing **Delay** matchar egenskapen `Effect.Timing.TriggerDelayTime` .  

Så här ändrar du Effect Timing‑egenskaperna:

1. [Applicera](#apply-animation-to-shape) eller hämta animationseffekten.  
2. Ställ in nya värden för de `Effect.Timing`‑egenskaper du behöver.  
3. Spara den modifierade PPTX‑filen.  

```python
import aspose.slides as slides

# Instansierar en presentationsklass som representerar en presentationsfil.
with slides.Presentation("AnimExample_out.pptx") as pres:
    # Hämtar huvudsekvensen för sliden.
    sequence = pres.slides[0].timeline.main_sequence

    # Hämtar den första effekten i huvudsekvensen.
    effect = sequence[0]

    # Ändrar effektens TriggerType till att starta vid klick
    effect.timing.trigger_type = slides.animation.EffectTriggerType.ON_CLICK

    # Ändrar effektens varaktighet
    effect.timing.duration = 3

    # Ändrar effektens TriggerDelayTime
    effect.timing.trigger_delay_time = 0.5

    # Sparar PPTX-filen till disk
    pres.save("AnimExample_changed.pptx", slides.export.SaveFormat.PPTX)
```

## **Animationseffektljud**

Aspose.Slides tillhandahåller dessa egenskaper för att låta dig arbeta med ljud i animationseffekter: 

- `sound`  
- `stop_previous_sound`  

### **Lägg till ljud för animationseffekt**

Denna Python‑kod visar hur du lägger till ett ljud för en animationseffekt och stoppar det när nästa effekt startar:

```python
import aspose.slides as slides

with Presentation("AnimExample_out.pptx") as pres:
    # Lägger till ljud i presentationens ljudsamling
    effect_sound = pres.audios.add_audio(open("sampleaudio.wav", "rb").read())

    first_slide = pres.slides[0]

    # Hämtar huvudsekvensen för sliden.
    sequence = first_slide.timeline.main_sequence

    # Hämtar den första effekten i huvudsekvensen
    first_effect = sequence[0]

    # Kontrollerar effekten för "No Sound"
    if not first_effect.stop_previous_sound and first_effect.sound is None:
        # Lägger till ljud för den första effekten
        first_effect.sound = effect_sound

    # Hämtar den första interaktiva sekvensen för sliden.
    interactive_sequence = first_slide.timeline.interactive_sequences[0]

    # Sätter flaggan "Stop previous sound" för effekten
    interactive_sequence[0].stop_previous_sound = True

    # Skriver PPTX-filen till disk
    pres.save("AnimExample_Sound_out.pptx", slides.export.SaveFormat.PPTX)
```

### **Extrahera ljud för animationseffekt**

1. Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/) klassen.  
2. Hämta en slides referens via dess index.  
3. Hämta huvudsekvensen av effekter.  
4. Extrahera det `sound` som är inbäddat i varje animationseffekt.  

Denna Python‑kod visar hur du extraherar ljudet som är inbäddat i en animationseffekt:

```python
import aspose.slides as slides

# Instansierar en presentationsklass som representerar en presentationsfil.
with slides.Presentation("EffectSound.pptx") as presentation:
    slide = presentation.slides[0]

    # Hämtar huvudsekvensen för sliden.
    sequence = slide.timeline.main_sequence

    for effect in sequence:
        if effect.sound is None:
            continue

        # Extraherar effektljudet i byte-array
        audio = effect.sound.binary_data
```

## **Efter animation**

Aspose.Slides för .NET låter dig ändra egenskapen After animation för en animationseffekt.

Detta är panelen Animation Effect och den utökade menyn i Microsoft PowerPoint:

![example1_image](shape-after-animation.png)

PowerPoint Effect **After animation**-rullgardinslistan matchar dessa egenskaper: 

- `after_animation_type`‑egenskapen som beskriver typen av After animation :  
  * PowerPoint **More Colors** matchar typen [COLOR](https://reference.aspose.com/slides/sv/python-net/aspose.slides.animation/afteranimationtype/) ;  
  * PowerPoint **Don't Dim**‑alternativet matchar typen [DO_NOT_DIM](https://reference.aspose.com/slides/sv/python-net/aspose.slides.animation/afteranimationtype/) (standardtyp för after animation);  
  * PowerPoint **Hide After Animation**‑alternativet matchar typen [HIDE_AFTER_ANIMATION](https://reference.aspose.com/slides/sv/python-net/aspose.slides.animation/afteranimationtype/) ;  
  * PowerPoint **Hide on Next Mouse Click**‑alternativet matchar typen [HIDE_ON_NEXT_MOUSE_CLICK](https://reference.aspose.com/slides/sv/python-net/aspose.slides.animation/afteranimationtype/) ;  
- `after_animation_color`‑egenskapen som definierar ett färgformat för after animation. Denna egenskap fungerar i kombination med typen [COLOR](https://reference.aspose.com/slides/sv/python-net/aspose.slides.animation/afteranimationtype/) . Om du ändrar typen till en annan kommer färgen för after animation att rensas.  

Denna Python‑kod visar hur du ändrar en after animation‑effekt:

```python
import aspose.slides as slides

# Instansierar en presentationsklass som representerar en presentationsfil
with slides.Presentation("AnimImage_out.pptx") as pres:
    first_slide = pres.slides[0]

    # Hämtar den första effekten i huvudsekvensen
    first_effect = first_slide.timeline.main_sequence[0]

    # Ändrar efteranimationstypen till Color
    first_effect.after_animation_type = AfterAnimationType.COLOR

    # Ställer in dämpningsfärgen för efteranimationen
    first_effect.after_animation_color.color = Color.alice_blue

    # Skriver PPTX-filen till disk
    pres.save("AnimImage_AfterAnimation.pptx", slides.export.SaveFormat.PPTX)
```

## **Animera text**

Aspose.Slides tillhandahåller dessa egenskaper för att låta dig arbeta med en animationseffekts *Animate text*-block: 

- `animate_text_type` som beskriver typen av animate text för effekten. Shape‑texten kan animeras:  
  - Alla på en gång ([ALL_AT_ONCE](https://reference.aspose.com/slides/sv/python-net/aspose.slides.animation/animatetexttype/) typ)  
  - Per ord ([BY_WORD](https://reference.aspose.com/slides/sv/python-net/aspose.slides.animation/animatetexttype/) typ)  
  - Per bokstav ([BY_LETTER](https://reference.aspose.com/slides/sv/python-net/aspose.slides.animation/animatetexttype/) typ)  
- `delay_between_text_parts` ställer in en fördröjning mellan de animerade textdelarna (ord eller bokstäver). Ett positivt värde anger procent av effektens varaktighet. Ett negativt värde anger fördröjningen i sekunder.  

Så här kan du ändra egenskaperna för Effect Animate text:

1. [Applicera](#apply-animation-to-shape) eller hämta animationseffekten.  
2. Ställ in egenskapen `build_type` till värdet [AS_ONE_OBJECT](https://reference.aspose.com/slides/sv/python-net/aspose.slides.animation/buildtype/) för att stänga av *By Paragraphs*-animationsläget.  
3. Ställ in nya värden för egenskaperna `animate_text_type` och `delay_between_text_parts`.  
4. Spara den modifierade PPTX‑filen.  

```python
import aspose.slides as slides

with slides.Presentation("AnimTextBox_out.pptx") as pres:
    first_slide = pres.slides[0]

    # Hämtar den första effekten i huvudsekvensen
    first_effect = first_slide.timeline.main_sequence[0]

    # Ändrar effektens textanimations typ till "As One Object"
    first_effect.text_animation.build_type = slides.animation.BuildType.AS_ONE_OBJECT

    # Ändrar effektens animera text-typ till "By word"
    first_effect.animate_text_type = slides.animation.AnimateTextType.BY_WORD

    # Ställer in fördröjning mellan ord till 20% av effektens varaktighet
    first_effect.delay_between_text_parts = 20

    # Skriver PPTX-filen till disk
    pres.save("AnimTextBox_AnimateText.pptx", slides.export.SaveFormat.PPTX)

```

## **FAQ**

**Hur kan jag säkerställa att animationer bevaras när presentationen publiceras på webben?**

[Export to HTML5](/slides/sv/python-net/export-to-html5/) och aktivera de [alternativ](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/html5options/) som ansvarar för animationer av [shape](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/html5options/animate_shapes/) och [transition](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/html5options/animate_transitions/) . Vanlig HTML spelar inte upp bildanimationer, medan HTML5 gör det.

**Hur påverkar förändring av z-ordning (lagerordning) för shapes animationen?**

Animation och ritordning är oberoende: en effekt styr timing och typ av framträde/borttagning, medan [z-order](https://reference.aspose.com/slides/sv/python-net/aspose.slides/shape/z_order_position/) bestämmer vad som täcker vad. Det synliga resultatet definieras av deras kombination. (Detta är den generella PowerPoint‑beteendet; Aspose.Slides-modellen för effekter och shapes följer samma logik.)

**Finns det begränsningar när animationer konverteras till video för vissa effekter?**

I allmänhet [stöds animationer](/slides/sv/python-net/convert-powerpoint-to-video/), men sällsynta fall eller specifika effekter kan renderas annorlunda. Det rekommenderas att testa med de effekter du använder och med den version av biblioteket.