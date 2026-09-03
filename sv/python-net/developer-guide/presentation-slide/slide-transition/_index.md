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
description: "Applicera bildövergångar, konfigurera automatisk bildframsteg och anpassa Morph och andra övergångseffekter med Aspose.Slides för Python via .NET."
---
## **Översikt**

Bildövergångar styr hur bilder visas under en bildspelspresentation. Med Aspose.Slides för Python via .NET kan du välja en övergångseffekt för varje bild, konfigurera framsteg med musklick eller timer och justera alternativ som är specifika för en effekt. Denna artikel använder Python‑exempel för att applicera övergångar, ange exakta övergångsvaraktigheter, hantera bildtidpunkter och skapa en Morph‑övergång mellan två bilder. Exemplen visar också hur man sparar inställningarna till en PPTX‑fil.

## **Lägg till bildövergång**

För att applicera en övergång, ladda en presentation med klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/) och nå bildens [slide_show_transition](https://reference.aspose.com/slides/sv/python-net/aspose.slides/slide/slide_show_transition/) egendom. Ställ in dess [type](https://reference.aspose.com/slides/sv/python-net/aspose.slides.slideshow/slideshowtransition/type/) på ett värde från uppräkningen [TransitionType](https://reference.aspose.com/slides/sv/python-net/aspose.slides.slideshow/transitiontype/), och spara sedan presentationen.

Följande exempel applicerar en Circle‑övergång på den första bilden och en Comb‑övergång på den andra. Använd en `input.pptx`‑fil med minst två bilder.

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

## **Lägg till avancerad bildövergång**

Du kan konfigurera hur länge en bild förblir på skärmen och om ett musklick går vidare i bildspelspresentationen. Följande egenskaper styr detta beteende:

- [advance_on_click](https://reference.aspose.com/slides/sv/python-net/aspose.slides.slideshow/slideshowtransition/advance_on_click/) låter visaren gå vidare genom att klicka med musen.
- [advance_after](https://reference.aspose.com/slides/sv/python-net/aspose.slides.slideshow/slideshowtransition/advance_after/) aktiverar automatisk vidaregång.
- [advance_after_time](https://reference.aspose.com/slides/sv/python-net/aspose.slides.slideshow/slideshowtransition/advance_after_time/) anger fördröjningen innan automatisk vidaregång, i millisekunder.

Aktivera både klick och tidsstyrd vidaregång så att visaren kan gå vidare med ett klick eller vänta på timern. För att endast använda timern, sätt [advance_on_click](https://reference.aspose.com/slides/sv/python-net/aspose.slides.slideshow/slideshowtransition/advance_on_click/) till `False`. Fördröjningen styr när bildspelspresentationen går vidare; den anger inte varaktigheten för den visuella övergångseffekten.

Detta exempel tilldelar olika effekter till de tre första bilderna och aktiverar automatisk vidaregång efter 3, 5 respektive 7 sekunder. Musklick kan också gå vidare på dessa bilder. Använd en `input.pptx`‑fil med minst tre bilder.

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

För att kontrollera om tidsstyrd vidaregång är aktiverad, läs [advance_after](https://reference.aspose.com/slides/sv/python-net/aspose.slides.slideshow/slideshowtransition/advance_after/). En lagrad fördröjning ensam indikerar inte att timern är aktiv.

Nästa exempel öppnar filen som sparades ovan, rapporterar varje aktiverad timer och inaktiverar automatisk vidaregång för bilder med en fördröjning större än två sekunder. Det aktiverar musklick för dessa bilder och sparar de uppdaterade inställningarna.

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

## **Styr övergångstidsinställning exakt**

Använd [duration](https://reference.aspose.com/slides/sv/python-net/aspose.slides.slideshow/slideshowtransition/duration/) för att ange den exakta längden på en övergångseffekt i millisekunder. Bildens egendom [slide_show_transition](https://reference.aspose.com/slides/sv/python-net/aspose.slides/slide/slide_show_transition/) exponerar dessa inställningar via [SlideShowTransition](https://reference.aspose.com/slides/sv/python-net/aspose.slides.slideshow/slideshowtransition/):

| Egenskap | Syfte |
| --- | --- |
| [duration](https://reference.aspose.com/slides/sv/python-net/aspose.slides.slideshow/slideshowtransition/duration/) | Anger varaktigheten för själva övergångseffekten, i millisekunder. |
| [advance_after_time](https://reference.aspose.com/slides/sv/python-net/aspose.slides.slideshow/slideshowtransition/advance_after_time/) | Anger fördröjningen innan bilden automatiskt går vidare, i millisekunder. Aktivera [advance_after](https://reference.aspose.com/slides/sv/python-net/aspose.slides.slideshow/slideshowtransition/advance_after/) för att starta denna timer. |
| [speed](https://reference.aspose.com/slides/sv/python-net/aspose.slides.slideshow/slideshowtransition/speed/) | Väljer en fördefinierad hastighetskategori från [TransitionSpeed](https://reference.aspose.com/slides/sv/python-net/aspose.slides.slideshow/transitionspeed/): SLOW, MEDIUM eller FAST. Används när ingen exakt varaktighet specificeras. |

[duration] styr endast övergångseffekten; den bestämmer inte hur länge bilden förblir synlig. Konfigurera den automatiska fördröjningen separat. När ingen explicit varaktighet är angiven bestämmer Aspose.Slides effektens varaktighet utifrån övergångstypen och [speed]-värdet.

### **Applicera samma varaktighet på varje bild**

För ett enhetligt tempo, applicera samma effekt och exakta varaktighet på varje bild. Detta exempel laddar `input.pptx`, väljer Fade från [TransitionType](https://reference.aspose.com/slides/sv/python-net/aspose.slides.slideshow/transitiontype/), och ger varje övergång en varaktighet på 750 millisekunder. Det aktiverar dessutom automatisk vidaregång efter 5000 millisekunder och inaktiverar vidaregång via musklick, och sparar sedan resultatet som PPTX.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    for slide in presentation.slides:
        transition = slide.slide_show_transition
        transition.type = slides.slideshow.TransitionType.FADE
        transition.duration = 750

        # Konfigurera automatisk bildframsteg oberoende av effektens varaktighet.
        transition.advance_after = True
        transition.advance_after_time = 5000
        transition.advance_on_click = False

    presentation.save("precise-transitions.pptx", slides.export.SaveFormat.PPTX)
```

### **Ange olika varaktigheter för enskilda bilder**

Olika bilder kan ha olika varaktigheter för sina effekter. Till exempel kan du använda en kort övergång för en titelsida och en längre övergång för en sektionsintroduktion. Detta exempel sätter 500 millisekunder för den första bilden och 1200 millisekunder för den andra. Använd en `input.pptx`‑fil med minst två bilder.

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

### **Koordinera övergångar med animerad utdata**

När du förbereder en [animated GIF](/slides/sv/python-net/convert-powerpoint-to-animated-gif/), [HTML5 presentation](/slides/sv/python-net/export-to-html5/) eller [video](/slides/sv/python-net/convert-powerpoint-to-video/), ange exakta övergångsvaraktigheter innan export så att de matchar den avsedda takten. Till exempel, använd en 600-millisekunders fade mellan scener och justera varje bilds fördröjning för vidaregång separat för att ge tid för dess berättelse eller innehåll.

För GIF och video, koordinera utskriftsbildhastigheten med effektens varaktighet: 600 millisekunder motsvarar 18 bildrutor vid 30 bildrutor per sekund. I HTML5, aktivera animerade övergångar i exportinställningarna. Kontrollera vilka effekter och tidsalternativ som stöds av det valda exportformatet och förhandsgranska resultatet för att bekräfta synkroniseringen.

### **Läs en befintlig övergångsvaraktighet**

Läs [duration](https://reference.aspose.com/slides/sv/python-net/aspose.slides.slideshow/slideshowtransition/duration/) innan du modifierar övergången för att avgöra om ett explicit värde är lagrat. Ett värde på `-1` betyder att ingen explicit varaktighet är satt; ett icke‑negativt värde specificerar den lagrade varaktigheten i millisekunder. Det odefinierade värdet är inte den beräknade uppspelningsvaraktigheten: Aspose.Slides använder övergångstypen och [speed](https://reference.aspose.com/slides/sv/python-net/aspose.slides.slideshow/slideshowtransition/speed/) för att bestämma den varaktigheten. Att sätta en övergångstyp kan initiera en varaktighet, så inspektera de ursprungliga inställningarna först.

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

Följande exempel skapar en bild med en textruta, klonar bilden och ändrar rektangelns position och storlek i klonen. Därefter väljer det Morph från uppräkningen [TransitionType](https://reference.aspose.com/slides/sv/python-net/aspose.slides.slideshow/transitiontype/) för den andra bilden. Öppna den sparade filen i en presentationsvisare som stödjer Morph för att se effekten under ett bildspel.

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

Uppräkningen [TransitionMorphType](https://reference.aspose.com/slides/sv/python-net/aspose.slides.slideshow/transitionmorphtype/) styr hur Morph matchar och animerar innehåll:

- [BY_OBJECT](https://reference.aspose.com/slides/sv/python-net/aspose.slides.slideshow/transitionmorphtype/) behandlar varje form som ett helt objekt.
- [BY_WORD](https://reference.aspose.com/slides/sv/python-net/aspose.slides.slideshow/transitionmorphtype/) animera text genom att matcha ord där det är möjligt.
- [BY_CHAR](https://reference.aspose.com/slides/sv/python-net/aspose.slides.slideshow/transitionmorphtype/) animera text genom att matcha tecken där det är möjligt.

Ställ in övergångens [type](https://reference.aspose.com/slides/sv/python-net/aspose.slides.slideshow/slideshowtransition/type/) till Morph innan du får åtkomst till dess [value](https://reference.aspose.com/slides/sv/python-net/aspose.slides.slideshow/slideshowtransition/value/). Värdet ger sedan objektet [MorphTransition](https://reference.aspose.com/slides/sv/python-net/aspose.slides.slideshow/morphtransition/), vars egenskap [morph_type](https://reference.aspose.com/slides/sv/python-net/aspose.slides.slideshow/morphtransition/morph_type/) väljer matchningsläget.

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

Vissa övergångar exponerar ytterligare alternativ, såsom riktning eller om effekten startar från en svart skärm. Tillgängliga alternativ beror på den valda övergångens [type](https://reference.aspose.com/slides/sv/python-net/aspose.slides.slideshow/slideshowtransition/type/). Ställ in typen först, och använd sedan det lämpliga övergångsobjektet från dess [value](https://reference.aspose.com/slides/sv/python-net/aspose.slides.slideshow/slideshowtransition/value/).

Följande exempel applicerar en Cut‑övergång på den första bilden i `input.pptx`. Det sätter [from_black](https://reference.aspose.com/slides/sv/python-net/aspose.slides.slideshow/optionalblacktransition/from_black/) via [OptionalBlackTransition](https://reference.aspose.com/slides/sv/python-net/aspose.slides.slideshow/optionalblacktransition/) så att övergången startar från en svart skärm.

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

**Kan jag kontrollera uppspelningshastigheten för en bildövergång?**

Ja. Föredra [duration](https://reference.aspose.com/slides/sv/python-net/aspose.slides.slideshow/slideshowtransition/duration/) när du behöver en exakt effektvaraktighet i millisekunder. Använd [speed](https://reference.aspose.com/slides/sv/python-net/aspose.slides.slideshow/slideshowtransition/speed/) när en fördefinierad kategori från [TransitionSpeed](https://reference.aspose.com/slides/sv/python-net/aspose.slides.slideshow/transitionspeed/) — SLOW, MEDIUM eller FAST — är tillräcklig och ingen explicit varaktighet är angiven. Dessa inställningar styr övergångseffekten oberoende av den automatiska fördröjningen för vidaregång.

**Kan jag bifoga ljud till en övergång och göra det loopat?**

Ja. Tilldela inbäddat ljud till [sound](https://reference.aspose.com/slides/sv/python-net/aspose.slides.slideshow/slideshowtransition/sound/), sätt [sound_mode](https://reference.aspose.com/slides/sv/python-net/aspose.slides.slideshow/slideshowtransition/sound_mode/) till START_SOUND från uppräkningen [TransitionSoundMode](https://reference.aspose.com/slides/sv/python-net/aspose.slides.slideshow/transitionsoundmode/) och aktivera [sound_loop](https://reference.aspose.com/slides/sv/python-net/aspose.slides.slideshow/slideshowtransition/sound_loop/). Ljudet loopar tills nästa ljudhändelse i bildspelspresentationen.

**Vad är det snabbaste sättet att applicera samma övergång på varje bild?**

Iterera genom presentationens [slides](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/slides/sv/) samling och sätt varje bilds övergångs [type](https://reference.aspose.com/slides/sv/python-net/aspose.slides.slideshow/slideshowtransition/type/) till samma värde. Ställ in eventuella tids- och effektalternativ i samma loop för att hålla beteendet konsekvent över alla bilder.

**Hur kan jag kontrollera vilken övergång som för närvarande är inställd på en bild?**

Läs egenskapen [type](https://reference.aspose.com/slides/sv/python-net/aspose.slides.slideshow/slideshowtransition/type/) från bildens [slide_show_transition](https://reference.aspose.com/slides/sv/python-net/aspose.slides/slide/slide_show_transition/). Den returnerar ett värde från uppräkningen [TransitionType](https://reference.aspose.com/slides/sv/python-net/aspose.slides.slideshow/transitiontype/); NONE betyder att ingen övergångseffekt är applicerad.