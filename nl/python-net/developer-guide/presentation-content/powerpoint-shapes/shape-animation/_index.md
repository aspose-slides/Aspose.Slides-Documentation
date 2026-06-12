---
title: Vormanimaties toepassen in presentaties met Python
linktitle: Vormanimatie
type: docs
weight: 60
url: /nl/python-net/shape-animation/
keywords:
- vorm
- animatie
- effect
- geanimeerde vorm
- geanimeerde tekst
- animatie toevoegen
- animatie ophalen
- animatie extraheren
- effect toevoegen
- effect ophalen
- effect extraheren
- effectgeluid
- animatie toepassen
- PowerPoint
- presentatie
- Python
- Aspose.Slides
description: "Ontdek hoe u vormanimaties kunt maken en aanpassen in PowerPoint- en OpenDocument‑presentaties met Aspose.Slides voor Python via .NET. Val op!"
---
## **Inleiding**

Animaties zijn visuele effecten die toegepast kunnen worden op tekst, afbeeldingen, vormen of [grafieken](/slides/nl/python-net/animated-charts/). Ze geven leven aan presentaties of hun onderdelen. 

## **Waarom animaties gebruiken in presentaties?**

Met animaties kunt u 

* de stroom van informatie beheersen
* belangrijke punten benadrukken
* de interesse of deelname van uw publiek verhogen
* de inhoud makkelijker leesbaar, verteerbaar of verwerkbaar maken
* de aandacht van uw lezers of kijkers vestigen op belangrijke delen in een presentatie

PowerPoint biedt veel opties en tools voor animaties en animatie‑effecten binnen de **entrance**, **exit**, **emphasis**, en **motion paths** categorieën. 

## **Animaties in Aspose.Slides**

* Aspose.Slides biedt de klassen en types die u nodig heeft om met animaties te werken binnen de namespace [Aspose.Slides.Animation](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/),
* Aspose.Slides levert meer dan **150 animatie‑effecten** via de enumeratie [EffectType](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/effecttype/). Deze effecten zijn in wezen identiek (of equivalent) aan de effecten die in PowerPoint worden gebruikt.

## **Animatie toepassen op tekstvak**

Aspose.Slides voor Python via .NET maakt het mogelijk om animatie toe te passen op de tekst in een vorm. 

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/) aan.
2. Haal een verwijzing naar een dia op via de index.
3. Voeg een `rectangle` [IAutoShape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/iautoshape/) toe. 
4. Voeg tekst toe aan `IAutoShape.TextFrame`.
5. Haal de hoofdvolgorde van effecten op.
6. Voeg een animatie‑effect toe aan [IAutoShape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/iautoshape/). 
7. Stel de eigenschap `TextAnimation.BuildType` in op de waarde uit de `BuildType`‑enumeratie.
8. Schrijf de presentatie naar schijf als een PPTX‑bestand.

Deze Python‑code laat zien hoe u het `Fade`‑effect toepast op een AutoShape en de tekstaniminatie instelt op de *By 1st Level Paragraphs* waarde:

```python
import aspose.slides as slides

# Instantiëert een presentatieklasse die een presentatiebestand vertegenwoordigt.
with slides.Presentation() as pres:
    sld = pres.slides[0]
    
    # Voegt een nieuwe AutoShape toe met tekst
    autoShape = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 100)

    textFrame = autoShape.text_frame
    textFrame.text = "First paragraph \nSecond paragraph \n Third paragraph"

    # Haal de hoofdvolgorde van de dia op.
    sequence = sld.timeline.main_sequence

    # Voegt een Fade‑animatie‑effect toe aan de vorm
    effect = sequence.add_effect(autoShape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)

    # Animeert de vormtekst per eerste niveau alinea's
    effect.text_animation.build_type = slides.animation.BuildType.BY_LEVEL_PARAGRAPHS1

    # Sla het PPTX‑bestand op schijf
    pres.save("AnimText_out.pptx", slides.export.SaveFormat.PPTX)
```

{{%  alert color="primary"  %}} 
Naast het toepassen van animaties op tekst, kunt u ook animaties toepassen op een enkele [Paragraph](https://reference.aspose.com/slides/nl/python-net/aspose.slides/iparagraph/). Zie [**Animated Text**](/slides/nl/python-net/animated-text/).
{{% /alert %}} 

## **Animatie toepassen op PictureFrame**

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/) aan.
2. Haal een verwijzing naar een dia op via de index.
3. Voeg een [PictureFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/pictureframe/) toe aan of haal deze op van de dia. 
4. Haal de hoofdvolgorde van effecten op.
5. Voeg een animatie‑effect toe aan [PictureFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/pictureframe/).
6. Schrijf de presentatie naar schijf als een PPTX‑bestand.

Deze Python‑code laat zien hoe u het `Fly`‑effect toepast op een picture frame:

```python
import aspose.slides as slides
import aspose.pydrawing as draw


# Instantiëert een presentatieklasse die een presentatiebestand vertegenwoordigt.
with slides.Presentation() as pres:
    # Laad afbeelding die moet worden toegevoegd aan de presentatie‑afbeeldingscollectie
    img = draw.Bitmap("aspose-logo.jpg")
    image = pres.images.add_image(img)

    # Voegt een picture‑frame toe aan de dia
    picFrame = pres.slides[0].shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 100, 100, image)

    # Haal de hoofdvolgorde van de dia op.
    sequence = pres.slides[0].timeline.main_sequence

    # Voegt een Fly‑van‑links‑animatie‑effect toe aan het picture‑frame
    effect = sequence.add_effect(picFrame, slides.animation.EffectType.FLY,  
        slides.animation.EffectSubtype.LEFT, 
        slides.animation.EffectTriggerType.ON_CLICK)

    # Sla het PPTX‑bestand op schijf
    pres.save("AnimImage_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Animatie toepassen op vorm**

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/) aan.
2. Haal een verwijzing naar een dia op via de index.
3. Voeg een `rectangle` [IAutoShape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/iautoshape/) toe. 
4. Voeg een `Bevel` [IAutoShape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/iautoshape/) toe (wanneer dit object wordt aangeklikt, wordt de animatie afgespeeld).
5. Maak een reeks effecten aan op de bevel‑vorm.
6. Maak een aangepaste `UserPath`.
7. Voeg commando’s toe voor het verplaatsen naar de `UserPath`.
8. Schrijf de presentatie naar schijf als een PPTX‑bestand.

Deze Python‑code laat zien hoe u het `PathFootball`‑effect toepast op een vorm:

```python
import aspose.slides.animation as anim
import aspose.slides as slides
import aspose.pydrawing as draw

# Instantiëert een Presentation‑klasse die een PPTX‑bestand vertegenwoordigt.
with slides.Presentation() as pres:
    sld = pres.slides[0]

    # Creëert PathFootball‑effect voor bestaande vorm vanaf nul.
    ashp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 150, 250, 25)

    ashp.add_text_frame("Animated TextBox")

    # Voegt het PathFootBall‑animatie‑effect toe.
    pres.slides[0].timeline.main_sequence.add_effect(ashp, 
        anim.EffectType.PATH_FOOTBALL,
        anim.EffectSubtype.NONE, 
        anim.EffectTriggerType.AFTER_PREVIOUS)

    # Creëert een soort “knop”.
    shapeTrigger = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.BEVEL, 10, 10, 20, 20)

    # Creëert een reeks effecten voor de knop.
    seqInter = pres.slides[0].timeline.interactive_sequences.add(shapeTrigger)

    # Creëert een aangepast gebruikerspad. Ons object wordt pas verplaatst nadat op de knop is geklikt.
    fxUserPath = seqInter.add_effect(ashp, 
        anim.EffectType.PATH_USER, 
        anim.EffectSubtype.NONE, 
        anim.EffectTriggerType.ON_CLICK)

    # Voegt opdrachten toe voor verplaatsing aangezien het aangemaakte pad leeg is.
    motionBhv = fxUserPath.behaviors[0]

    pts = [draw.PointF(0.076, 0.59)]
    motionBhv.path.add(anim.MotionCommandPathType.LINE_TO, pts, anim.MotionPathPointsType.AUTO, True)
    pts = [draw.PointF(-0.076, -0.59)]
    motionBhv.path.add(anim.MotionCommandPathType.LINE_TO, pts, anim.MotionPathPointsType.AUTO, False)
    motionBhv.path.add(anim.MotionCommandPathType.END, None, anim.MotionPathPointsType.AUTO, False)

    # Schrijft het PPTX‑bestand naar schijf
    pres.save("AnimExample_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Animatie‑effecten die op een vorm zijn toegepast ophalen**

De volgende voorbeelden laten zien hoe u de methode `get_effects_by_shape` van de klasse [Sequence](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/sequence/) kunt gebruiken om alle animatie‑effecten op te halen die op een vorm zijn toegepast.

**Voorbeeld 1: Animatie‑effecten ophalen die op een vorm op een normale dia zijn toegepast**

Eerder heeft u geleerd hoe u animatie‑effecten toevoegt aan vormen in PowerPoint‑presentaties. De volgende voorbeeldcode laat zien hoe u de effecten ophaalt die op de eerste vorm op de eerste normale dia in de presentatie `AnimExample_out.pptx` zijn toegepast.

```python
import aspose.slides as slides

with slides.Presentation("AnimExample_out.pptx") as presentation:
    first_slide = presentation.slides[0]

    # Haalt de hoofdanimatievolgorde van de dia op.
    sequence = first_slide.timeline.main_sequence

    # Haalt de eerste vorm op de eerste dia op.
    shape = first_slide.shapes[0]

    # Haalt de op de vorm toegepaste animatie‑effecten op.
    shape_effects = sequence.get_effects_by_shape(shape)

    if len(shape_effects) > 0:
        print("The shape", shape.name, "has", len(shape_effects), "animation effects.")
```

**Voorbeeld 2: Alle animatie‑effecten ophalen, inclusief die afkomstig van placeholders**

Als een vorm op een normale dia placeholders heeft die zich op de lay‑out‑dia en/of master‑dia bevinden, en er animatie‑effecten aan deze placeholders zijn toegevoegd, dan worden alle effecten van de vorm afgespeeld tijdens de diavoorstelling, inclusief de effecten die van de placeholders zijn geërfd.

Stel dat we een PowerPoint‑presentatie `sample.pptx` hebben met één dia die alleen een voettekst‑vorm bevat met de tekst “Made with Aspose.Slides” en het **Random Bars**‑effect is toegepast op de vorm.

![Dia vorm animatie-effect](slide-shape-animation.png)

Stel bovendien dat het **Split**‑effect is toegepast op de voettekst‑placeholder op de **layout**‑dia.

![Lay-out vorm animatie-effect](layout-shape-animation.png)

En tenslotte is het **Fly In**‑effect toegepast op de voettekst‑placeholder op de **master**‑dia.

![Master vorm animatie-effect](master-shape-animation.png)

De volgende voorbeeldcode laat zien hoe u de methode `get_base_placeholder` van de klasse [Shape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/shape/) gebruikt om de shape‑placeholders te benaderen en de animatie‑effecten op te halen die op de voettekst‑vorm zijn toegepast, inclusief de geërfde effecten van placeholders op de lay‑out‑ en master‑dia’s.

```py
import aspose.slides as slides

def print_effects(effects):
    for effect in effects:
        print(effect.type.name, effect.subtype.name)
```
```py
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    # Haal de animatie-effecten van de vorm op de normale dia op.
    shape = slide.shapes[0]
    shape_effects = slide.timeline.main_sequence.get_effects_by_shape(shape)

    # Haal de animatie-effecten van de placeholder op de layout-dia op.
    layout_shape = shape.get_base_placeholder()
    layout_shape_effects = slide.layout_slide.timeline.main_sequence.get_effects_by_shape(layout_shape)

    # Haal de animatie-effecten van de placeholder op de master-dia op.
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

## **Timing‑eigenschappen van animatie‑effect wijzigen**

Aspose.Slides voor Python via .NET maakt het mogelijk om de timing‑eigenschappen van een animatie‑effect te wijzigen.

Dit is het Animation Timing‑venster in Microsoft PowerPoint:

![example1_image](shape-animation.png)

Dit zijn de overeenkomsten tussen PowerPoint Timing en de eigenschappen van `Effect.Timing`:

- De vervolgkeuzelijst **Start** in PowerPoint Timing komt overeen met de eigenschap [Effect.Timing.TriggerType](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/effecttriggertype/). 
- De vervolgkeuzelijst **Duration** in PowerPoint Timing komt overeen met de eigenschap `Effect.Timing.Duration`. De duur van een animatie (in seconden) is de totale tijd die de animatie nodig heeft om één cyclus te voltooien. 
- De vervolgkeuzelijst **Delay** in PowerPoint Timing komt overeen met de eigenschap `Effect.Timing.TriggerDelayTime`. 

Zo wijzigt u de timing‑eigenschappen van een effect:

1. [Pas](#apply-animation-to-shape) of haal het animatie‑effect op.
2. Stel nieuwe waarden in voor de `Effect.Timing`‑eigenschappen die u nodig heeft. 
3. Sla het gewijzigde PPTX‑bestand op.

Deze Python‑code demonstreert de bewerking:

```python
import aspose.slides as slides

# Instantiëert een presentatieklasse die een presentatiebestand vertegenwoordigt.
with slides.Presentation("AnimExample_out.pptx") as pres:
    # Haalt de hoofdvolgorde van de dia op.
    sequence = pres.slides[0].timeline.main_sequence

    # Haalt het eerste effect van de hoofdvolgorde op.
    effect = sequence[0]

    # Wijzigt het TriggerType van het effect zodat het start bij klikken
    effect.timing.trigger_type = slides.animation.EffectTriggerType.ON_CLICK

    # Wijzigt de duur van het effect
    effect.timing.duration = 3

    # Wijzigt de triggervertragingstijd van het effect
    effect.timing.trigger_delay_time = 0.5

    # Slaat het PPTX‑bestand op schijf
    pres.save("AnimExample_changed.pptx", slides.export.SaveFormat.PPTX)
```

## **Geluid van animatie‑effect**

Aspose.Slides biedt deze eigenschappen om met geluiden in animatie‑effecten te werken: 

- `sound`
- `stop_previous_sound`

### **Geluid toevoegen aan animatie‑effect**

Deze Python‑code laat zien hoe u een geluid aan een animatie‑effect toevoegt en het stopt wanneer het volgende effect start:

```python
import aspose.slides as slides

with Presentation("AnimExample_out.pptx") as pres:
    # Voegt audio toe aan de audiocollectie van de presentatie
    effect_sound = pres.audios.add_audio(open("sampleaudio.wav", "rb").read())

    first_slide = pres.slides[0]

    # Haalt de hoofdvolgorde van de dia op.
    sequence = first_slide.timeline.main_sequence

    # Haalt het eerste effect van de hoofdvolgorde op
    first_effect = sequence[0]

    # Controleert of het effect geen geluid heeft
    if not first_effect.stop_previous_sound and first_effect.sound is None:
        # Voegt geluid toe aan het eerste effect
        first_effect.sound = effect_sound

    # Haalt de eerste interactieve volgorde van de dia op.
    interactive_sequence = first_slide.timeline.interactive_sequences[0]

    # Stelt de vlag “Stop previous sound” van het effect in
    interactive_sequence[0].stop_previous_sound = True

    # Schrijft het PPTX‑bestand naar schijf
    pres.save("AnimExample_Sound_out.pptx", slides.export.SaveFormat.PPTX)
```

### **Geluid van animatie‑effect extraheren**

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/) aan.
2. Haal een verwijzing naar een dia op via de index. 
3. Haal de hoofdvolgorde van effecten op. 
4. Extraheer het `sound`‑bestand dat in elk animatie‑effect is ingebed. 

Deze Python‑code laat zien hoe u het in een animatie‑effect ingebedde geluid extraheert:

```python
import aspose.slides as slides

# Instantiëert een presentatieklasse die een presentatiebestand vertegenwoordigt.
with slides.Presentation("EffectSound.pptx") as presentation:
    slide = presentation.slides[0]

    # Haalt de hoofdvolgorde van de dia op.
    sequence = slide.timeline.main_sequence

    for effect in sequence:
        if effect.sound is None:
            continue

        # Extraheert het effectgeluid als byte‑array
        audio = effect.sound.binary_data
```

## **Na animatie**

Aspose.Slides voor .NET maakt het mogelijk om de **After animation**‑eigenschap van een animatie‑effect te wijzigen.

Dit is het Animation Effect‑venster en het uitgebreide menu in Microsoft PowerPoint:

![example1_image](shape-after-animation.png)

De vervolgkeuzelijst **After animation** in PowerPoint komt overeen met de volgende eigenschappen: 

- Eigenschap `after_animation_type` die het type After animation beschrijft:
  * **More Colors** komt overeen met het type [COLOR](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/afteranimationtype/);
  * **Don't Dim** komt overeen met het type [DO_NOT_DIM](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/afteranimationtype/) (standaard after‑animation‑type);
  * **Hide After Animation** komt overeen met het type [HIDE_AFTER_ANIMATION](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/afteranimationtype/);
  * **Hide on Next Mouse Click** komt overeen met het type [HIDE_ON_NEXT_MOUSE_CLICK](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/afteranimationtype/);
- Eigenschap `after_animation_color` die een kleurformaat voor after‑animation definieert. Deze eigenschap werkt in combinatie met het type [COLOR](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/afteranimationtype/). Als u het type wijzigt, wordt de after‑animation‑kleur gewist.

Deze Python‑code laat zien hoe u een after‑animation‑effect wijzigt:

```python
import aspose.slides as slides

# Instantiëert een presentatieklasse die een presentatiebestand vertegenwoordigt
with slides.Presentation("AnimImage_out.pptx") as pres:
    first_slide = pres.slides[0]

    # Haalt het eerste effect van de hoofdvolgorde op
    first_effect = first_slide.timeline.main_sequence[0]

    # Wijzigt het after‑animation‑type naar Kleur
    first_effect.after_animation_type = AfterAnimationType.COLOR

    # Stelt de after‑animation‑dimkleur in
    first_effect.after_animation_color.color = Color.alice_blue

    # Schrijft het PPTX‑bestand naar schijf
    pres.save("AnimImage_AfterAnimation.pptx", slides.export.SaveFormat.PPTX)
```

## **Tekst animeren**

Aspose.Slides biedt deze eigenschappen om met het *Animate text*‑blok van een animatie‑effect te werken:

- `animate_text_type` beschrijft het type tekstanimatie van het effect. De tekst van de vorm kan geanimeerd worden:
  - Alles tegelijk ([ALL_AT_ONCE](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/animatetexttype/) type)
  - Per woord ([BY_WORD](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/animatetexttype/) type)
  - Per letter ([BY_LETTER](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/animatetexttype/) type)
- `delay_between_text_parts` stelt een vertraging in tussen de geanimeerde tekstdelen (woorden of letters). Een positieve waarde geeft het percentage van de effectduur aan; een negatieve waarde geeft de vertraging in seconden aan.

Zo wijzigt u de eigenschappen van *Animate text*:

1. [Pas](#apply-animation-to-shape) of haal het animatie‑effect op.
2. Stel de eigenschap `build_type` in op de waarde [AS_ONE_OBJECT](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/buildtype/) om de *By Paragraphs*‑animatiemodus uit te schakelen.
3. Stel nieuwe waarden in voor de eigenschappen `animate_text_type` en `delay_between_text_parts`.
4. Sla het gewijzigde PPTX‑bestand op.

Deze Python‑code demonstreert de bewerking:

```python
import aspose.slides as slides

with slides.Presentation("AnimTextBox_out.pptx") as pres:
    first_slide = pres.slides[0]

    # Haalt het eerste effect van de hoofdvolgorde op
    first_effect = first_slide.timeline.main_sequence[0]

    # Wijzigt het effect Tekstanimatie-type naar "As One Object"
    first_effect.text_animation.build_type = slides.animation.BuildType.AS_ONE_OBJECT

    # Wijzigt het effect Animate text type naar "By word"
    first_effect.animate_text_type = slides.animation.AnimateTextType.BY_WORD

    # Stelt de vertraging tussen woorden in op 20% van de effectduur
    first_effect.delay_between_text_parts = 20

    # Schrijft het PPTX-bestand naar schijf
    pres.save("AnimTextBox_AnimateText.pptx", slides.export.SaveFormat.PPTX)

```

## **FAQ**

**Hoe zorg ik ervoor dat animaties behouden blijven wanneer ik de presentatie publiceer op het web?**

Exporteer naar **HTML5** (/slides/nl/python-net/export-to-html5/) en schakel de [opties](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/html5options/) in die verantwoordelijk zijn voor animaties van [shapes](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/html5options/animate_shapes/) en [transities](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/html5options/animate_transitions/). Platte HTML speelt geen dia‑animaties af, HTML5 wel.

**Hoe beïnvloedt het wijzigen van de z‑order (laagvolgorde) van vormen de animatie?**

Animatie‑ en tekentvolgorde zijn onafhankelijk: een effect bepaalt de timing en het type verschijnen/verdwijnen, terwijl de [z‑order](https://reference.aspose.com/slides/nl/python-net/aspose.slides/shape/z_order_position/) bepaalt wat wat bedekt. Het zichtbare resultaat wordt door hun combinatie bepaald. (Dit is het algemene gedrag van PowerPoint; het Aspose.Slides‑model voor effecten‑en‑vormen volgt dezelfde logica.)

**Zijn er beperkingen bij het converteren van animaties naar video voor bepaalde effecten?**

In het algemeen worden [animaties ondersteund](/slides/nl/python-net/convert-powerpoint-to-video/), maar zeldzame gevallen of specifieke effecten kunnen anders worden gerenderd. Het wordt aangeraden de gebruikte effecten en de bibliotheekversie te testen.