---
title: Hantera bildövergångar i presentationer med Python
linktitle: Bildövergång
type: docs
weight: 90
url: /sv/python-net/slide-transition/
keywords:
- bildövergång
- lägg till bildövergång
- tillämpa bildövergång
- avancerad bildövergång
- morph‑övergång
- övergångstyp
- övergångseffekt
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Applicera bildövergångar, konfigurera automatisk bildfortsättning, och anpassa Morph och andra övergångseffekter med Aspose.Slides för Python via .NET."
---
## **Översikt**

Bildspelövergångar styr hur bilder visas under ett bildspel. Med Aspose.Slides för Python via .NET kan du välja en övergångseffekt för varje bild, konfigurera vidaregång med musklick eller timer och justera alternativ som är specifika för en effekt. Denna artikel använder Python‑exempel för att tillämpa övergångar, ange exakta övergångstider, hantera bildtidsinställningar och skapa en Morph‑övergång mellan två bilder. Exemplen visar också hur man sparar inställningarna till en PPTX‑fil.

## **Lägg till bildövergång**

För att tillämpa en övergång, ladda en presentation med klassen [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) och nå bildens egenskap [slide_show_transition](https://reference.aspose.com/slides/python-net/aspose.slides/slide/slide_show_transition/). Sätt dess [type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) till ett värde från uppräkningen [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/), spara sedan presentationen.

Följande exempel tillämpar en Circle‑övergång på den första bilden och en Comb‑övergång på den andra. Använd en `input.pptx`‑fil med minst två bilder.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    if len(presentation.slides) >= 2:
        presentation.slides[0].slide_show_transition.type = slides.slideshow.TransitionType.CIRCLE
        presentation.slides[1].slide_show_transition.type = slides.slideshow.TransitionType.COMB

        presentation.save("slide-transitions.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The input presentation must contain at least two slides.")
```

## **Wheel‑övergång**

Egenskapen [spokes](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/wheeltransition/spokes/) i [WheelTransition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/wheeltransition/) styr antalet radiala sektorer som avslöjar destinationsbilden. Sätt bildens övergångs‑[type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) till WHEEL från [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/) innan du får åtkomst till [value](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/value/) som [WheelTransition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/wheeltransition/).

Detta exempel skapar två identiska bildpar: en svart bild följt av en bild med en gul rektangel. Destinationsbilderna använder antalet spoke på 1 respektive 8, med samma [speed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/speed/) och en explicit [duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/) på 8 000 millisekunder för att göra skillnaden lätt att observera.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide_width = presentation.slide_size.size.width
    slide_height = presentation.slide_size.size.height

    black_slide = presentation.slides[0]
    black_slide.shapes.clear()
    black_slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    black_slide.background.fill_format.fill_type = slides.FillType.SOLID
    black_slide.background.fill_format.solid_fill_color.preset_color = slides.PresetColor.BLACK

    destination_slide = presentation.slides.add_clone(black_slide)
    rectangle = destination_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 0, 0, slide_width, slide_height)
    rectangle.fill_format.fill_type = slides.FillType.SOLID
    rectangle.fill_format.solid_fill_color.preset_color = slides.PresetColor.GOLD
    rectangle.text_frame.text = "Wheel transition"

    presentation.slides.add_clone(black_slide)
    presentation.slides.add_clone(destination_slide)

    spoke_counts = [1, 8]
    for i, spoke_count in enumerate(spoke_counts):
        transition = presentation.slides[i * 2 + 1].slide_show_transition
        transition.type = slides.slideshow.TransitionType.WHEEL
        wheel_transition = transition.value
        wheel_transition.spokes = spoke_count
        transition.speed = slides.slideshow.TransitionSpeed.SLOW
        transition.duration = 8000

    presentation.save("wheel-transitions.pptx", slides.export.SaveFormat.PPTX)
```

Öppna den sparade presentationen i PowerPoint och kör bildspelet. Gå från bild 1 till bild 2, sedan från bild 3 till bild 4. I PowerPoint‑uppspelning visar den verifierade spoke‑räkningen 1 bilden med ett medurs svep; den verifierade räknaren 8 visar den genom åtta radiala sektorer samtidigt. Destinationsinnehållet och övergångstiden är identiska, så skillnaden är antalet avslöjandesektorer.

## **Lägg till avancerad bildövergång**

Du kan konfigurera hur länge en bild förblir på skärmen och om ett musklick går vidare i bildspelet. Följande egenskaper styr detta beteende:

- [advance_on_click](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_on_click/) låter betraktaren gå vidare genom att klicka med musen.
- [advance_after](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_after/) möjliggör automatisk vidaregång.
- [advance_after_time](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_after_time/) specificerar fördröjningen innan automatisk vidaregång, i millisekunder.

Aktivera både klick‑ och tidsbaserad vidaregång så att betraktaren kan gå vidare med ett klick eller vänta på timern. För att endast använda timern, sätt [advance_on_click](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_on_click/) till `False`. Fördröjningen styr när bildspelet går vidare; den bestämmer inte varaktigheten för den visuella övergångseffekten.

Detta exempel tilldelar olika effekter till de tre första bilderna och aktiverar automatisk vidaregång efter 3, 5 respektive 7 sekunder. Mus‑klick kan också gå vidare på dessa bilder. Använd en `input.pptx`‑fil med minst tre bilder.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    if len(presentation.slides) >= 3:
        first_transition = presentation.slides[0].slide_show_transition
        first_transition.type = slides.slideshow.TransitionType.CIRCLE
        first_transition.advance_on_click = True
        first_transition.advance_after = True
        first_transition.advance_after_time = 3000

        second_transition = presentation.slides[1].slide_show_transition
        second_transition.type = slides.slideshow.TransitionType.COMB
        second_transition.advance_on_click = True
        second_transition.advance_after = True
        second_transition.advance_after_time = 5000

        third_transition = presentation.slides[2].slide_show_transition
        third_transition.type = slides.slideshow.TransitionType.ZOOM
        third_transition.advance_on_click = True
        third_transition.advance_after = True
        third_transition.advance_after_time = 7000

        presentation.save("advanced-transitions.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The input presentation must contain at least three slides.")
```

För att kontrollera om tidsbaserad vidaregång är aktiverad, läs [advance_after](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_after/). En lagrad fördröjning i sig indikerar inte att timern är aktiv.

Nästa exempel öppnar filen som sparades ovan, rapporterar varje aktiverad timer och inaktiverar automatisk vidaregång för bilder med en fördröjning längre än två sekunder. Det aktiverar musklick för de bilderna och sparar de uppdaterade inställningarna.

```python
import aspose.slides as slides

with slides.Presentation("advanced-transitions.pptx") as presentation:
    for slide in presentation.slides:
        transition = slide.slide_show_transition

        if transition.advance_after:
            print(f"Slide {slide.slide_number}: advance after {transition.advance_after_time} ms.")

            if transition.advance_after_time > 2000:
                transition.advance_after = False
                transition.advance_on_click = True

    presentation.save("adjusted-transitions.pptx", slides.export.SaveFormat.PPTX)
```

## **Styr övergångstiden exakt**

Använd [duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/) för att ange den exakta längden på en övergångseffekt i millisekunder. Bildens egenskap [slide_show_transition](https://reference.aspose.com/slides/python-net/aspose.slides/slide/slide_show_transition/) exponerar dessa inställningar via [SlideShowTransition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/):

| Property | Purpose |
| --- | --- |
| [duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/) | Anger varaktigheten för själva övergångseffekten, i millisekunder. |
| [advance_after_time](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_after_time/) | Anger fördröjningen innan bilden automatiskt går vidare, i millisekunder. Aktivera [advance_after](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_after/) för att slå på timern. |
| [speed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/speed/) | Väljer en fördefinierad hastighetskategori från [TransitionSpeed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionspeed/): SLOW, MEDIUM eller FAST. Den används när ingen exakt varaktighet har specificerats. |

[duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/) styr endast övergångseffekten; den bestämmer inte hur länge bilden förblir synlig. Konfigurera den automatiska fördröjningen separat. När ingen explicit varaktighet anges bestämmer Aspose.Slides effektens varaktighet utifrån övergångstyp och värdet för [speed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/speed/).

<!-- visual-explanation:slide-transition:start -->
[![Separate bars identify the 750-ms transition duration and 5,000-ms automatic advancement setting.](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*The shared example gives each slide a 750-ms Fade transition and separately enables automatic advancement at 5,000 ms. Transition duration controls the effect; advancement controls when to leave the slide. These bars are schematic settings, not a measured combined timeline.*
<!-- visual-explanation:slide-transition:end -->

### **Tillämpa samma varaktighet på varje bild**

För ett jämnt tempo, tillämpa samma effekt och exakt varaktighet på varje bild. Detta exempel laddar `input.pptx`, väljer Fade från [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/), och ger varje övergång en varaktighet på 750 millisekunder. Det aktiverar separat automatisk vidaregång efter 5 000 millisekunder och inaktiverar vidaregång med musklick, och sparar resultatet som PPTX.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    for slide in presentation.slides:
        transition = slide.slide_show_transition
        transition.type = slides.slideshow.TransitionType.FADE
        transition.duration = 750

        # Konfigurera automatisk vidaregång oberoende av effektens varaktighet.
        transition.advance_after = True
        transition.advance_after_time = 5000
        transition.advance_on_click = False

    presentation.save("precise-transitions.pptx", slides.export.SaveFormat.PPTX)
```

### **Ange olika varaktigheter för enskilda bilder**

Olika bilder kan ha olika effektvaraktigheter. Till exempel kan en titelbild ha en kort övergång medan en sektionsintroduktion har en längre. Detta exempel sätter 500 millisekunder för den första bilden och 1 200 millisekunder för den andra. Använd en `input.pptx`‑fil med minst två bilder.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    if len(presentation.slides) >= 2:
        first_transition = presentation.slides[0].slide_show_transition
        first_transition.type = slides.slideshow.TransitionType.FADE
        first_transition.duration = 500

        second_transition = presentation.slides[1].slide_show_transition
        second_transition.type = slides.slideshow.TransitionType.PUSH
        second_transition.duration = 1200

        presentation.save("individual-transition-durations.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The input presentation must contain at least two slides.")
```

### **Koordinera övergångar med animerad export**

När du förbereder en [animated GIF](/slides/sv/python-net/convert-powerpoint-to-animated-gif/), en [HTML5 presentation](/slides/sv/python-net/export-to-html5/), eller en [video](/slides/sv/python-net/convert-powerpoint-to-video/), ange exakta övergångstider innan export så att tempot blir rätt. Till exempel, använd en 600‑millisekunders fade mellan scener och justera varje bilds vidaregångsfördröjning separat för att ge tid för berättarrösten eller innehållet.

För GIF och video, samordna bildfrekvensen med effektens varaktighet: 600 millisekunder motsvarar 18 bildrutor vid 30 bilder per sekund. I HTML5, aktivera animerade övergångar i exportinställningarna. Kontrollera vilka övergångar och tidsalternativ som stöds av det valda exportformatet och förhandsgranska resultatet för att bekräfta synkronisering.

### **Läs en befintlig övergångsvaraktighet**

Läs [duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/) innan du ändrar övergången för att avgöra om ett explicit värde är lagrat. Ett värde på `-1` betyder att ingen explicit varaktighet är satt; ett icke‑negativt värde specificerar den lagrade varaktigheten i millisekunder. Det osatta värdet är inte den beräknade uppspelningsvaraktigheten: Aspose.Slides använder övergångstyp och [speed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/speed/) för att bestämma den varaktigheten. Att sätta en övergångstyp kan initiera en varaktighet, så inspektera de ursprungliga inställningarna först.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    for slide in presentation.slides:
        transition = slide.slide_show_transition
        duration = transition.duration

        if duration >= 0:
            print(f"Slide {slide.slide_number}: stored transition duration is {duration} ms.")
        else:
            print(f"Slide {slide.slide_number}: no explicit duration; timing depends on {transition.type} and {transition.speed}.")
```

## **Morph‑övergång**

Morph‑övergången animerar förändringar mellan objekt på på varandra följande bilder. För att skapa en enkel Morph‑effekt, klona en bild, flytta eller ändra storlek på ett objekt i klonen och tillämpa Morph‑övergången på den andra bilden. Detta ger övergången motsvarande objekt att animera mellan deras ursprungliga och modifierade tillstånd.

Följande exempel skapar en bild med en textruta, klonar bilden och ändrar rektangelns position och storlek i klonen. Den väljer sedan Morph från uppräkningen [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/) för den andra bilden. Öppna den sparade filen i en presentationsvisare som stödjer Morph för att se effekten under ett bildspel.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    first_slide = presentation.slides[0]
    rectangle = first_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 400, 100)
    rectangle.text_frame.text = "Morph transition"

    second_slide = presentation.slides.add_clone(first_slide)
    moved_rectangle = second_slide.shapes[0]
    moved_rectangle.x += 100
    moved_rectangle.y += 50
    moved_rectangle.width -= 200
    moved_rectangle.height -= 10

    second_slide.slide_show_transition.type = slides.slideshow.TransitionType.MORPH

    presentation.save("morph-transition.pptx", slides.export.SaveFormat.PPTX)
```

## **Morph‑övergångstyper**

Uppräkningen [TransitionMorphType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionmorphtype/) styr hur Morph matchar och animerar innehåll:

- [BY_OBJECT](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionmorphtype/) behandlar varje form som ett helt objekt.
- [BY_WORD](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionmorphtype/) animerar text genom att matcha ord där det är möjligt.
- [BY_CHAR](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionmorphtype/) animerar text genom att matcha tecken där det är möjligt.

Sätt övergångens [type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) till Morph innan du får åtkomst till dess [value](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/value/). Värdet ger då objektet [MorphTransition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/morphtransition/), vars egenskap [morph_type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/morphtransition/morph_type/) väljer matchningsläge.

Detta exempel öppnar presentationen som skapades i föregående avsnitt och konfigurerar den andra bilden att använda ord‑baserad Morph‑animation.

```python
import aspose.slides as slides

with slides.Presentation("morph-transition.pptx") as presentation:
    if len(presentation.slides) >= 2:
        transition = presentation.slides[1].slide_show_transition
        transition.type = slides.slideshow.TransitionType.MORPH
        morph_transition = transition.value

        if isinstance(morph_transition, slides.slideshow.MorphTransition):
            morph_transition.morph_type = slides.slideshow.TransitionMorphType.BY_WORD
            presentation.save("morph-by-word.pptx", slides.export.SaveFormat.PPTX)
        else:
            print("Morph transition options are unavailable.")
    else:
        print("The input presentation must contain at least two slides.")
```

## **Ställ in övergångseffekter**

Vissa övergångar visar ytterligare alternativ, t.ex. riktning eller om effekten ska börja från en svart skärm. Tillgängliga alternativ beror på den valda övergångens [type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/). Sätt typen först, och använd sedan det lämpliga övergångsobjektet från dess [value](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/value/).

Följande exempel tillämpar en Cut‑övergång på den första bilden i `input.pptx`. Det sätter [from_black](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/optionalblacktransition/from_black/) via [OptionalBlackTransition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/optionalblacktransition/) så att övergången börjar från en svart skärm.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    transition = presentation.slides[0].slide_show_transition
    transition.type = slides.slideshow.TransitionType.CUT
    cut_transition = transition.value

    if isinstance(cut_transition, slides.slideshow.OptionalBlackTransition):
        cut_transition.from_black = True
        presentation.save("cut-from-black.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("Cut transition options are unavailable.")
```

## **FAQ**

**Kan jag styra uppspelningshastigheten för en bildövergång?**

Ja. Föredra [duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/) när du behöver en exakt effektvaraktighet i millisekunder. Använd [speed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/speed/) när en fördefinierad kategori i [TransitionSpeed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionspeed/) — SLOW, MEDIUM eller FAST — räcker och ingen explicit varaktighet är satt. Dessa inställningar styr övergångseffekten oberoende av den automatiska vidaregångsfördröjningen.

**Kan jag fästa ljud till en övergång och få det att loopa?**

Ja. Tilldela inbäddat ljud till [sound](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound/), sätt [sound_mode](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound_mode/) till START_SOUND från uppräkningen [TransitionSoundMode](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionsoundmode/), och aktivera [sound_loop](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound_loop/). Ljudet loopas tills nästa ljudhändelse i bildspelet.

**Vad är det snabbaste sättet att tillämpa samma övergång på varje bild?**

Loopa igenom presentationens [slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/slides/)‑samling och sätt varje bilds övergångs‑[type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) till samma värde. Ställ in eventuell timing och effektalternativ i samma loop för att hålla beteendet jämnt över alla bilder.

**Hur kan jag kontrollera vilken övergång som för närvarande är inställd på en bild?**

Läs [type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/)‑egenskapen från bildens [slide_show_transition](https://reference.aspose.com/slides/python-net/aspose.slides/slide/slide_show_transition/). Den returnerar ett värde från uppräkningen [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/); NONE betyder att ingen övergångseffekt är tillämpad.