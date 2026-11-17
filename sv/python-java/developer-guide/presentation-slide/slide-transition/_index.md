---
title: Hantera bildövergångar i presentationer med Python via Java
linktitle: Bildövergång
type: docs
weight: 80
url: /sv/python-java/slide-transition/
keywords:
- bildövergång
- lägga till bildövergång
- tillämpa bildövergång
- avancerad bildövergång
- Morph-övergång
- övergångstyp
- övergångseffekt
- PowerPoint
- OpenDocument
- presentation
- Python
- Java
- Aspose.Slides
description: "Tillämpa bildövergångar, konfigurera automatisk förflyttning av bilder och anpassa Morph och andra övergångseffekter med Aspose.Slides för Python via Java."
---
## **Översikt**

Slide transitions control how slides appear during a slide show. With Aspose.Slides for Python via Java, you can choose a transition effect for each slide, configure advancement by mouse click or timer, and adjust options specific to an effect. This article uses Python examples to apply transitions, set exact transition durations, manage slide timing, and create a Morph transition between two slides. The examples also show how to save the settings to a PPTX file.

## **Lägg till bildövergång**

För att tillämpa en övergång, ladda en presentation med klassen [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) och få åtkomst till bildens övergångsinställningar via [getSlideShowTransition](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getSlideShowTransition). Använd [setType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setType) med ett värde från uppräkningen [TransitionType](https://reference.aspose.com/slides/python-java/aspose.slides/transitiontype/), spara sedan presentationen.

Följande exempel tillämpar en Circle‑övergång på den första bilden och en Comb‑övergång på den andra. Använd en `input.pptx`‑fil med minst två bilder.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType

presentation = Presentation("input.pptx")
try:
    if presentation.getSlides().size() >= 2:
        presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle)
        presentation.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb)

        presentation.save("slide-transitions.pptx", SaveFormat.Pptx)
    else:
        print("The input presentation must contain at least two slides.")
finally:
    presentation.dispose()
```

## **Hjul‑övergång**

Använd [setType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setType) för att välja Wheel från [TransitionType](https://reference.aspose.com/slides/python-java/aspose.slides/transitiontype/). Anropa sedan [getValue](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getValue) för att komma åt inställningarna för [WheelTransition](https://reference.aspose.com/slides/python-java/aspose.slides/wheeltransition/). Dess metod [setSpokes](https://reference.aspose.com/slides/python-java/aspose.slides/wheeltransition/#setSpokes) styr hur många radiala sektorer som avslöjar målbilden.

Exemplet skapar två identiska bildpar. Varje par börjar med en svart bild och avslutas med en helbilds guldrektangel. Båda målbilderna använder samma långsamma hastighet som ställs in med [setSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSpeed) och samma uttryckliga varaktighet på 8 000 millisekunder som ställs in med [setDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setDuration). Endast antalet spår (spokes) ändras.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat, ShapeType, TransitionSpeed, TransitionType

Color = jpype.JClass("java.awt.Color")
presentation = Presentation()
try:
    width = jpype.JFloat(presentation.getSlideSize().getSize().getWidth())
    height = jpype.JFloat(presentation.getSlideSize().getSize().getHeight())

    slides = presentation.getSlides()
    black_slide = slides.get_Item(0)
    black_slide.getShapes().clear()
    background = black_slide.getBackground()
    background.setType(BackgroundType.OwnBackground)
    background.getFillFormat().setFillType(FillType.Solid)
    background.getFillFormat().getSolidFillColor().setColor(Color.BLACK)

    destination_slide = slides.addClone(black_slide)
    rectangle = destination_slide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, width, height)
    rectangle.getFillFormat().setFillType(FillType.Solid)
    rectangle.getFillFormat().getSolidFillColor().setColor(Color(255, 215, 0))
    rectangle.getTextFrame().setText("Wheel transition")

    slides.addClone(black_slide)
    slides.addClone(destination_slide)
    for slide_index, spokes in ((1, 1), (3, 8)):
        transition = slides.get_Item(slide_index).getSlideShowTransition()
        transition.setType(TransitionType.Wheel)
        wheel_transition = transition.getValue()
        wheel_transition.setSpokes(spokes)
        transition.setSpeed(TransitionSpeed.Slow)
        transition.setDuration(8000)

    presentation.save("wheel-transitions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Öppna `wheel-transitions.pptx` i PowerPoint och starta bildspelet. Gå fram från bild 1 till bild 2 för att se en medurs svepning avslöja den guldiga rektangeln. Gå sedan fram från bild 3 till bild 4 för att se åtta radiala sektorer avslöja samma rektangel samtidigt.

## **Lägg till avancerad bildövergång**

Du kan konfigurera hur länge en bild visas på skärmen och om ett musklick förflyttar bildspelet. Följande metoder styr detta beteende:

- [setAdvanceOnClick](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) låter visningsprogrammet gå vidare genom att klicka med musen.
- [setAdvanceAfter](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceAfter) möjliggör automatisk förflyttning.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) specificerar fördröjningen innan automatisk förflyttning, i millisekunder.

Aktivera både klick- och tidsbaserad förflyttning så att användaren kan gå vidare med ett klick eller vänta på timern. För att bara använda timern, skicka `False` till [setAdvanceOnClick](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceOnClick). Fördröjningen styr när bildspelet går vidare; den anger inte varaktigheten för den visuella övergångseffekten.

Detta exempel tilldelar olika effekter till de tre första bilderna och aktiverar automatisk förflyttning efter respektive 3, 5 och 7 sekunder. Musknappar kan också föra fram dessa bilder. Använd en `input.pptx`‑fil med minst tre bilder.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType

presentation = Presentation("input.pptx")
try:
    if presentation.getSlides().size() >= 3:
        first_transition = presentation.getSlides().get_Item(0).getSlideShowTransition()
        first_transition.setType(TransitionType.Circle)
        first_transition.setAdvanceOnClick(True)
        first_transition.setAdvanceAfter(True)
        first_transition.setAdvanceAfterTime(3000)

        second_transition = presentation.getSlides().get_Item(1).getSlideShowTransition()
        second_transition.setType(TransitionType.Comb)
        second_transition.setAdvanceOnClick(True)
        second_transition.setAdvanceAfter(True)
        second_transition.setAdvanceAfterTime(5000)

        third_transition = presentation.getSlides().get_Item(2).getSlideShowTransition()
        third_transition.setType(TransitionType.Zoom)
        third_transition.setAdvanceOnClick(True)
        third_transition.setAdvanceAfter(True)
        third_transition.setAdvanceAfterTime(7000)

        presentation.save("advanced-transitions.pptx", SaveFormat.Pptx)
    else:
        print("The input presentation must contain at least three slides.")
finally:
    presentation.dispose()
```

För att kontrollera om tidsbaserad förflyttning är aktiverad, anropa [getAdvanceAfter](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getAdvanceAfter). En lagrad fördröjning ensam indikerar inte att timern är aktiv.

Det följande exemplet öppnar filen som sparades ovan, rapporterar varje aktiverad timer och inaktiverar automatisk förflyttning för bilder med en fördröjning över två sekunder. Det aktiverar musknappar för dessa bilder och sparar de uppdaterade inställningarna.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("advanced-transitions.pptx")
try:
    for slide in presentation.getSlides():
        transition = slide.getSlideShowTransition()

        if transition.getAdvanceAfter():
            print(f"Slide {slide.getSlideNumber()}: advance after {transition.getAdvanceAfterTime()} ms.")

            if transition.getAdvanceAfterTime() > 2000:
                transition.setAdvanceAfter(False)
                transition.setAdvanceOnClick(True)

    presentation.save("adjusted-transitions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Styr övergångstiming exakt**

Använd [setDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setDuration) för att ange den exakta längden på en övergångseffekt i millisekunder. Bildens [getSlideShowTransition](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getSlideShowTransition)-metod visar dessa inställningar via [SlideShowTransition](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/):

| Metod | Syfte |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setDuration) | Anger varaktigheten för själva övergångseffekten, i millisekunder. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) | Anger fördröjningen innan bilden automatiskt går vidare, i millisekunder. Skicka `True` till [setAdvanceAfter](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceAfter) för att aktivera denna timer. |
| [setSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSpeed) | Väljer en fördefinierad hastighetskategori från [TransitionSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/transitionspeed/): Slow, Medium eller Fast. Den används när ingen exakt varaktighet anges. |

[setDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setDuration) styr endast övergångseffekten; den bestämmer inte hur länge bilden förblir synlig. Konfigurera den automatiska förflyttningsfördröjningen separat. När ingen uttrycklig varaktighet är angiven, bestämmer Aspose.Slides effektens varaktighet utifrån övergångstypen och värdet från [getSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getSpeed).

<!-- visual-explanation:slide-transition:start -->
[![Separata staplar identifierar övergångsdurationen på 750 ms och den automatiska förflyttningsinställningen på 5 000 ms.](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*Det delade exemplet ger varje bild en Fade‑övergång på 750 ms och aktiverar separat automatisk förflyttning efter 5 000 ms. Övergångsdurationen styr effekten; förflyttningen styr när bilden lämnas. Dessa staplar är schematiska inställningar, inte en mätt samlad tidslinje.*
<!-- visual-explanation:slide-transition:end -->

### **Tillämpa samma varaktighet på varje bild**

För ett jämnt tempo, tillämpa samma effekt och exakt varaktighet på varje bild. Detta exempel laddar `input.pptx`, väljer Fade från [TransitionType](https://reference.aspose.com/slides/python-java/aspose.slides/transitiontype/), och ger varje övergång en varaktighet på 750 millisekunder. Det aktiverar separat automatisk förflyttning efter 5 000 millisekunder och inaktiverar förflyttning med musklick, och sparar sedan resultatet som PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType

presentation = Presentation("input.pptx")
try:
    for slide in presentation.getSlides():
        transition = slide.getSlideShowTransition()
        transition.setType(TransitionType.Fade)
        transition.setDuration(750)

        # Konfigurera automatisk förflyttning oberoende av effektens varaktighet.
        transition.setAdvanceAfter(True)
        transition.setAdvanceAfterTime(5000)
        transition.setAdvanceOnClick(False)

    presentation.save("precise-transitions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Ange olika varaktigheter för enskilda bilder**

Olika bilder kan använda olika effektvaraktigheter. Till exempel kan du använda en kort övergång för en titelsbild och en längre övergång för en sektionsintroduktion. Detta exempel sätter 500 millisekunder för den första bilden och 1 200 millisekunder för den andra. Använd en `input.pptx`‑fil med minst två bilder.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType

presentation = Presentation("input.pptx")
try:
    if presentation.getSlides().size() >= 2:
        first_transition = presentation.getSlides().get_Item(0).getSlideShowTransition()
        first_transition.setType(TransitionType.Fade)
        first_transition.setDuration(500)

        second_transition = presentation.getSlides().get_Item(1).getSlideShowTransition()
        second_transition.setType(TransitionType.Push)
        second_transition.setDuration(1200)

        presentation.save("individual-transition-durations.pptx", SaveFormat.Pptx)
    else:
        print("The input presentation must contain at least two slides.")
finally:
    presentation.dispose()
```

### **Koordinera övergångar med animerad utdata**

När du förbereder en [animated GIF](/slides/sv/python-java/convert-powerpoint-to-animated-gif/), [HTML5 presentation](/slides/sv/python-java/export-to-html5/), eller [video](/slides/sv/python-java/convert-powerpoint-to-video/), ange exakt övergångsduration innan export för att matcha önskat tempo. Till exempel, använd en fade på 600 millisekunder mellan scener och justera varje bilds förflyttningsfördröjning separat för att ge tid åt dess berättelse eller innehåll.

För GIF och video, koordinera utdata bildfrekvens med effektens varaktighet: 600 millisekunder motsvarar 18 bildrutor vid 30 bilder per sekund. I HTML5, aktivera animerade övergångar i exportinställningarna. Kontrollera att det valda exportformatet stöder effekter och tidsalternativ, och förhandsgranska utdata för att bekräfta synkroniseringen.

### **Läs en befintlig övergångsvaraktighet**

Anropa [getDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getDuration) innan du ändrar övergången för att avgöra om ett explicit värde är lagrat. Ett värde på `-1` betyder att ingen explicit varaktighet är angiven; ett icke‑negativt värde specificerar den lagrade varaktigheten i millisekunder. Det oinställda värdet är inte den beräknade uppspelningsvaraktigheten: Aspose.Slides använder övergångstypen och värdet från [getSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getSpeed) för att bestämma den varaktigheten. Att ställa in en övergångstyp kan initiera en varaktighet, så inspektera först de ursprungliga inställningarna.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("input.pptx")
try:
    for slide in presentation.getSlides():
        transition = slide.getSlideShowTransition()
        duration = transition.getDuration()

        if duration >= 0:
            print(f"Slide {slide.getSlideNumber()}: stored transition duration is {duration} ms.")
        else:
            print(f"Slide {slide.getSlideNumber()}: no explicit duration; timing depends on transition type {transition.getType()} and speed {transition.getSpeed()}.")
finally:
    presentation.dispose()
```

## **Morph‑övergång**

Morph‑övergången animerar förändringar mellan objekt på på varandra följande bilder. För att skapa en enkel Morph‑effekt, klona en bild, flytta eller ändra storlek på ett objekt i klonen och tillämpa Morph‑övergången på den andra bilden. Detta ger övergången motsvarande objekt att animera mellan sina ursprungliga och modifierade tillstånd.

Följande exempel skapar en bild med en textruta, klonar bilden och ändrar rektangelns position och storlek i klonen. Det väljer sedan Morph från uppräkningen [TransitionType](https://reference.aspose.com/slides/python-java/aspose.slides/transitiontype/) för den andra bilden. Öppna den sparade filen i en presentationsvisare som stöder Morph för att se effekten under ett bildspel.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType, ShapeType

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)
    rectangle = first_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 100)
    rectangle.getTextFrame().setText("Morph transition")

    second_slide = presentation.getSlides().addClone(first_slide)
    moved_rectangle = second_slide.getShapes().get_Item(0)
    moved_rectangle.setX(moved_rectangle.getX() + 100)
    moved_rectangle.setY(moved_rectangle.getY() + 50)
    moved_rectangle.setWidth(moved_rectangle.getWidth() - 200)
    moved_rectangle.setHeight(moved_rectangle.getHeight() - 10)

    second_slide.getSlideShowTransition().setType(TransitionType.Morph)

    presentation.save("morph-transition.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Morph‑övergångstyper**

Uppräkningen [TransitionMorphType](https://reference.aspose.com/slides/python-java/aspose.slides/transitionmorphtype/) styr hur Morph matchar och animera innehåll:

- [ByObject](https://reference.aspose.com/slides/python-java/aspose.slides/transitionmorphtype/#ByObject) behandlar varje form som ett helt objekt.
- [ByWord](https://reference.aspose.com/slides/python-java/aspose.slides/transitionmorphtype/#ByWord) animerar text genom att matcha ord där det är möjligt.
- [ByChar](https://reference.aspose.com/slides/python-java/aspose.slides/transitionmorphtype/#ByChar) animerar text genom att matcha tecken där det är möjligt.

Använd [setType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setType) för att välja Morph innan du får åtkomst till [getValue](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getValue). Värdet blir då en instans av klassen [MorphTransition](https://reference.aspose.com/slides/python-java/aspose.slides/morphtransition/), vars metod [setMorphType](https://reference.aspose.com/slides/python-java/aspose.slides/morphtransition/#setMorphType) väljer matchningsläget.

Detta exempel öppnar presentationen som skapades i föregående avsnitt och konfigurerar den andra bilden att använda ordbaserad Morph‑animation.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType, TransitionMorphType, MorphTransition

presentation = Presentation("morph-transition.pptx")
try:
    if presentation.getSlides().size() >= 2:
        transition = presentation.getSlides().get_Item(1).getSlideShowTransition()
        transition.setType(TransitionType.Morph)
        transition_value = transition.getValue()

        if isinstance(transition_value, MorphTransition):
            morph_transition = transition_value
            morph_transition.setMorphType(TransitionMorphType.ByWord)
            presentation.save("morph-by-word.pptx", SaveFormat.Pptx)
        else:
            print("Morph transition options are unavailable.")
    else:
        print("The input presentation must contain at least two slides.")
finally:
    presentation.dispose()
```

## **Ställ in övergångseffekter**

Vissa övergångar visar ytterligare alternativ, såsom riktning eller om effekten startar från en svart skärm. Tillgängliga alternativ beror på den övergång som valts med [setType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setType). Ställ in typen först, och använd sedan den lämpliga klassen från [getValue](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getValue).

Följande exempel tillämpar en Cut‑övergång på den första bilden i `input.pptx`. Det anropar [setFromBlack](https://reference.aspose.com/slides/python-java/aspose.slides/optionalblacktransition/#setFromBlack) via [OptionalBlackTransition](https://reference.aspose.com/slides/python-java/aspose.slides/optionalblacktransition/) så att övergången startar från en svart skärm.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType, OptionalBlackTransition

presentation = Presentation("input.pptx")
try:
    transition = presentation.getSlides().get_Item(0).getSlideShowTransition()
    transition.setType(TransitionType.Cut)
    transition_value = transition.getValue()

    if isinstance(transition_value, OptionalBlackTransition):
        cut_transition = transition_value
        cut_transition.setFromBlack(True)
        presentation.save("cut-from-black.pptx", SaveFormat.Pptx)
    else:
        print("Cut transition options are unavailable.")
finally:
    presentation.dispose()
```

## **FAQ**

**Kan jag kontrollera uppspelningshastigheten för en bildövergång?**

Ja. Föredra [setDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setDuration) när du behöver en exakt effektvaraktighet i millisekunder. Använd [setSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSpeed) när en fördefinierad kategori i [TransitionSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/transitionspeed/) — Slow, Medium eller Fast — räcker och ingen explicit varaktighet är angiven. Dessa inställningar styr övergångseffekten oberoende av den automatiska förflyttningsfördröjningen.

**Kan jag bifoga ljud till en övergång och få den att loopa?**

Ja. Tilldela inbäddat ljud med [setSound](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSound), skicka StartSound från uppräkningen [TransitionSoundMode](https://reference.aspose.com/slides/python-java/aspose.slides/transitionsoundmode/) till [setSoundMode](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSoundMode), och aktivera [setSoundLoop](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSoundLoop) med `True`. Ljudet loopar tills nästa ljudhändelse i bildspelet.

**Vad är det snabbaste sättet att tillämpa samma övergång på varje bild?**

Loopa igenom presentationens [getSlides](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getSlides)-samling och anropa [setType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setType) med samma värde för varje bilds övergång. Ställ in eventuell timing och effektalternativ i samma loop för att hålla beteendet konsekvent över alla bilder.

**Hur kan jag kontrollera vilken övergång som för närvarande är inställd på en bild?**

Anropa [getType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getType) på bildens [getSlideShowTransition](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getSlideShowTransition)-resultat. Den returnerar ett värde från uppräkningen [TransitionType](https://reference.aspose.com/slides/python-java/aspose.slides/transitiontype/); None_ betyder att ingen övergångseffekt är tillämpad.