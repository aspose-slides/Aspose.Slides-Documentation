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
- Morph-övergång
- övergångstyp
- övergångseffekt
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Applicera bildövergångar, konfigurera automatisk bildavancering och anpassa Morph och andra övergångseffekter med Aspose.Slides för Python via .NET."
---
## **Översikt**

Bildövergångar styr hur bilder visas under ett bildspel. Med Aspose.Slides för Python via .NET kan du välja en övergångseffekt för varje bild, konfigurera avancerad stegning med musklick eller timer och justera alternativ specifika för en effekt. Den här artikeln använder Python-exempel för att tillämpa övergångar, ställa in exakta övergångstider, hantera bildtid och skapa en Morph‑övergång mellan två bilder. Exemplen visar också hur du sparar inställningarna till en PPTX‑fil.

## **Lägg till bildövergång**

För att tillämpa en övergång, läs in en presentation med klassen [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) och få åtkomst till bildens egendom [slide_show_transition](https://reference.aspose.com/slides/python-net/aspose.slides/slide/slide_show_transition/). Sätt dess [type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) till ett värde från uppräkningen [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/), och spara sedan presentationen.

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

## **Hjul‑övergång**

Egenskapen [spokes](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/wheeltransition/spokes/) för [WheelTransition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/wheeltransition/) styr antalet radiella sektorer som avslöjar målbilden. Ställ in bildens övergångs [type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) till WHEEL från [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/) innan du får åtkomst till [value](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/value/) som [WheelTransition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/wheeltransition/).

Detta exempel skapar två identiska bildpar: en svart bild följt av en bild med en guldrektangel. Målbilderna använder antalet spår (spokes) 1 respektive 8, med samma [speed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/speed/) och en explicit [duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/) på 8 000 millisekunder för att göra skillnaden lätt att observera.

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

Öppna den genererade presentationen i PowerPoint och kör bildspelet. Gå från bild 1 till bild 2, sedan från bild 3 till bild 4. I PowerPoint‑uppspelning avslöjar den verifierade spårräkningen 1 bilden med en enkel medurs svepning; den verifierade räknaren 8 avslöjar den genom åtta radiella sektorer samtidigt. Målinnehållet och övergångstiden är identiska, så skillnaden är antalet avslöjande sektorer.

## **Tona genom svart med Reveal‑övergång**

Ställ in målbildens övergångs [type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) till Reveal, sätt sedan [through_black](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/revealtransition/through_black/) på det resulterande [RevealTransition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/revealtransition/)‑objektet. Exemplet skapar en turkos källbild och en korallfärgad målbild, och klonar sedan paret. Båda paren använder samma tvåsekunders Reveal‑övergång. Endast det andra paret tonar genom svart.

```python
import aspose.slides as slides


def style_slide(slide, background_color, label):
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.preset_color = background_color

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 160, 180, 400, 130)
    shape.text_frame.text = label
    shape.text_frame.paragraphs[0].portions[0].portion_format.font_height = 44


with slides.Presentation() as presentation:
    source = presentation.slides[0]
    destination = presentation.slides.add_clone(source)
    style_slide(source, slides.PresetColor.TEAL, "Source")
    style_slide(destination, slides.PresetColor.CORAL, "Destination")
    presentation.slides.add_clone(source)
    presentation.slides.add_clone(destination)

    for index in (1, 3):
        transition = presentation.slides[index].slide_show_transition
        transition.type = slides.slideshow.TransitionType.REVEAL
        transition.speed = slides.slideshow.TransitionSpeed.SLOW
        transition.duration = 2000
        
        reveal = transition.value
        reveal.direction = slides.slideshow.TransitionLeftRightDirectionType.LEFT
        reveal.through_black = index == 3

    presentation.save("reveal-transitions.pptx", slides.export.SaveFormat.PPTX)
```

Öppna `reveal-transitions.pptx` i PowerPoint och starta bildspelet. Gå från bild 1 till bild 2 för att se den turkosa tonas direkt in i korallen. Gå sedan från bild 3 till bild 4. Skärmen mörknar kort till nästan svart innan den korallfärgade bilden visas. Båda bilderna behåller sina ursprungliga bakgrundsfärger.

Raderna nedanför visar ramar från PowerPoint med halvt sekunders intervall. Jämför den mellersta ramen i varje rad för att se effekten av inställningen.

![PowerPoint‑uppspelning med through_black inaktiverad (överst) och aktiverad (nedst). Endast den nedre raden passerar genom nästan svart.](reveal-through-black.png)

## **Lägg till avancerad bildövergång**

Du kan konfigurera hur länge en bild förblir på skärmen och om ett musklick avancerar bildspelet. Följande egenskaper styr detta beteende:

- [advance_on_click](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_on_click/) tillåter betraktaren att gå vidare genom att klicka med musen.
- [advance_after](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_after/) aktiverar automatisk avancerning.
- [advance_after_time](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_after_time/) anger fördröjningen innan automatisk avancerning, i millisekunder.

Aktivera både klick- och tidsbaserad avancerning så att betraktaren kan fortsätta med ett klick eller vänta på timern. För att bara använda timern, sätt [advance_on_click](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_on_click/) till `False`. Fördröjningen styr när bildspelet avancerar; den ställer inte in varaktigheten för den visuella övergångseffekten.

Detta exempel tilldelar olika effekter till de tre första bilderna och aktiverar automatisk avancerning efter 3, 5 respektive 7 sekunder. Mus‑klick kan också avancera dessa bilder. Använd en `input.pptx`‑fil med minst tre bilder.

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

För att kontrollera om tidsbaserad avancerning är aktiverad, läs [advance_after](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_after/). Ett lagrat fördröjningsvärde indikerar inte ensamt att timern är aktiv.

Nästa exempel öppnar filen som sparades ovan, rapporterar varje aktiverad timer och inaktiverar automatisk avancerning för bilder med en fördröjning längre än två sekunder. Det aktiverar mus‑klick för dessa bilder och sparar de uppdaterade inställningarna.

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

## **Styr övergångstid exakt**

Använd [duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/) för att specificera den exakta längden på en övergångseffekt i millisekunder. Bildens [slide_show_transition](https://reference.aspose.com/slides/python-net/aspose.slides/slide/slide_show_transition/)‑egenskap exponerar dessa inställningar via [SlideShowTransition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/):

| Egenskap | Syfte |
| --- | --- |
| [duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/) | Anger varaktigheten för själva övergångseffekten, i millisekunder. |
| [advance_after_time](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_after_time/) | Anger fördröjningen innan bilden avancerar automatiskt, i millisekunder. Aktivera [advance_after](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_after/) för att starta timern. |
| [speed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/speed/) | Väljer en fördefinierad hastighetskategori från [TransitionSpeed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionspeed/): SLOW, MEDIUM eller FAST. Den används när ingen exakt varaktighet specificeras. |

[duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/) styr endast övergångseffekten; den bestämmer inte hur länge bilden förblir synlig. Konfigurera den automatiska avanceringsfördröjningen separat. När ingen explicit varaktighet är angiven bestämmer Aspose.Slides effektens varaktighet utifrån övergångstypen och [speed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/speed/)-värdet.

[![Separata staplar identifierar 750‑ms övergångstid och 5 000‑ms automatisk avanceringsinställning.](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*Det gemensamma exemplet ger varje bild en 750‑ms Fade‑övergång och aktiverar separat automatisk avancerning efter 5 000 ms. Övergångstiden styr effekten; avanceringen styr när bilden lämnas. Dessa staplar är schematiska inställningar, inte en uppmätt kombinerad tidslinje.*

### **Tillämpa samma varaktighet på varje bild**

För jämn takt applicera samma effekt och exakt varaktighet på varje bild. Detta exempel läser in `input.pptx`, väljer Fade från [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/), och ger varje övergång en varaktighet på 750 millisekunder. Det aktiverar separat automatisk avancerning efter 5 000 millisekunder och inaktiverar avancerning med mus‑klick, och sparar sedan resultatet som PPTX.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    for slide in presentation.slides:
        transition = slide.slide_show_transition
        transition.type = slides.slideshow.TransitionType.FADE
        transition.duration = 750

        # Konfigurera automatisk avancering oberoende av effektens varaktighet.
        transition.advance_after = True
        transition.advance_after_time = 5000
        transition.advance_on_click = False

    presentation.save("precise-transitions.pptx", slides.export.SaveFormat.PPTX)
```

### **Ställ in olika varaktigheter för enskilda bilder**

Olika bilder kan använda olika varaktigheter för effekter. Till exempel kan en kort övergång användas för en titeldia och en längre för en sektionens introduktion. Detta exempel sätter 500 millisekunder för den första bilden och 1 200 millisekunder för den andra. Använd en `input.pptx`‑fil med minst två bilder.

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

När du förbereder en [animated GIF](/slides/sv/python-net/convert-powerpoint-to-animated-gif/), [HTML5 presentation](/slides/sv/python-net/export-to-html5/), eller [video](/slides/sv/python-net/convert-powerpoint-to-video/), ange exakta övergångstider innan export för att matcha den avsedda takten. Till exempel, använd en 600‑millisekunders toning mellan scener och justera varje bilds avanceringsfördröjning separat för att ge tid åt berättarrösten eller innehållet.

För GIF och video, koordinera utskrifts‑frame‑rate med effektens varaktighet: 600 millisekunder motsvarar 18 ramar vid 30 fps. I HTML5, aktivera animerade övergångar i exportinställningarna. Kontrollera vilka effekter och tidsalternativ som stöds av det valda exportformatet och förhandsgranska resultatet för att bekräfta synkronisering.

### **Läs en befintlig övergångsvaraktighet**

Läs [duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/) innan du modifierar övergången för att avgöra om ett explicit värde är lagrat. Ett värde på `-1` betyder att ingen explicit varaktighet är angiven; ett icke‑negativt värde specificerar den lagrade varaktigheten i millisekunder. Det oangivna värdet är inte den beräknade uppspelningsvaraktigheten: Aspose.Slides använder övergångstypen och [speed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/speed/) för att bestämma den varaktigheten. Att sätta en övergångstyp kan initiera en varaktighet, så inspektera först de ursprungliga inställningarna.

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

Morph‑övergången animerar förändringar mellan objekt på på varandra följande bilder. För att skapa en enkel Morph‑effekt, klona en bild, flytta eller ändra storlek på ett objekt i klonen och applicera Morph‑övergången på den andra bilden. Detta ger övergången motsvarande objekt att animera mellan deras ursprungliga och modifierade tillstånd.

Följande exempel skapar en bild med en textruta, klonar bilden och ändrar rektangelns position och storlek i klonen. Därefter väljer det Morph från [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/)‑uppräkningen för den andra bilden. Öppna den sparade filen i en presentationsvisare som stödjer Morph för att se effekten under ett bildspel.

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

[TransitionMorphType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionmorphtype/)‑uppräkningen styr hur Morph matchar och animera innehåll:

- [BY_OBJECT](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionmorphtype/) behandlar varje form som ett helt objekt.
- [BY_WORD](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionmorphtype/) animera text genom att matcha ord där det är möjligt.
- [BY_CHAR](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionmorphtype/) animera text genom att matcha tecken där det är möjligt.

Ställ in övergångs [type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) till Morph innan du får åtkomst till dess [value](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/value/). Värdet ger då [MorphTransition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/morphtransition/)-objektet, vars [morph_type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/morphtransition/morph_type/)‑egenskap väljer matchningsläget.

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

Vissa övergångar exponerar ytterligare alternativ, såsom riktning eller om effekten startar från en svart skärm. Tillgängliga alternativ beror på den valda övergångs [type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/). Sätt typen först, använd sedan det lämpliga övergångsobjektet från dess [value](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/value/).

Följande exempel applicerar en Cut‑övergång på den första bilden i `input.pptx`. Det sätter [from_black](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/optionalblacktransition/from_black/) via [OptionalBlackTransition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/optionalblacktransition/) så att övergången startar från en svart skärm.

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

Ja. Föredra [duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/) när du behöver en exakt effektvaraktighet i millisekunder. Använd [speed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/speed/) när en fördefinierad [TransitionSpeed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionspeed/)‑kategori—SLOW, MEDIUM eller FAST—räcker och ingen explicit varaktighet är angiven. Dessa inställningar styr övergångseffekten oberoende av den automatiska avanceringsfördröjningen.

**Kan jag bifoga ljud till en övergång och låta det loopa?**

Ja. Tilldela inbäddat ljud till [sound](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound/), sätt [sound_mode](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound_mode/) till START_SOUND från [TransitionSoundMode](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionsoundmode/)-uppräkningen, och aktivera [sound_loop](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound_loop/). Ljudet loopas tills nästa ljudhändelse i bildspelet.

**Vad är det snabbaste sättet att applicera samma övergång på varje bild?**

Loopa igenom presentationens [slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/slides/)‑samling och sätt varje bilds övergångs [type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) till samma värde. Ställ in eventuella timing‑ och effektalternativ i samma loop för att hålla beteendet konsekvent över alla bilder.

**Hur kan jag kontrollera vilken övergång som för närvarande är inställd på en bild?**

Läs [type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/)‑egenskapen från bildens [slide_show_transition](https://reference.aspose.com/slides/python-net/aspose.slides/slide/slide_show_transition/). Den returnerar ett värde från [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/)-uppräkningen; NONE betyder att ingen övergångseffekt är applicerad.