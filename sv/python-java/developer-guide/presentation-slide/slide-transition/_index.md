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
- morph‑övergång
- övergångstyp
- övergångseffekt
- PowerPoint
- OpenDocument
- presentation
- Python
- Java
- Aspose.Slides
description: "Tillämpa bildövergångar, konfigurera automatisk bildvidaregång och anpassa Morph och andra övergångseffekter med Aspose.Slides för Python via Java."
---
## **Översikt**

Bildövergångar styr hur bilder visas under en bildspelsvisning. Med Aspose.Slides for Python via Java kan du välja en övergångseffekt för varje bild, konfigurera vidaregång med musklick eller timer och justera alternativ som är specifika för en effekt. Denna artikel använder Python‑exempel för att tillämpa övergångar, ange exakta övergångstider, hantera bildtidsinställningar och skapa en Morph‑övergång mellan två bilder. Exemplen visar också hur man sparar inställningarna i en PPTX‑fil.

## **Lägg till bildövergång**

För att tillämpa en övergång, läs in en presentation med klassen [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/) och nå bildens övergångsinställningar via [getSlideShowTransition](https://reference.aspose.com/slides/sv/python-java/aspose.slides/baseslide/#getSlideShowTransition). Använd [setType](https://reference.aspose.com/slides/sv/python-java/aspose.slides/slideshowtransition/#setType) med ett värde från uppräkningen [TransitionType](https://reference.aspose.com/slides/sv/python-java/aspose.slides/transitiontype/), och spara sedan presentationen.

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

## **Lägg till avancerad bildövergång**

Du kan konfigurera hur länge en bild visas på skärmen och om ett musklick går vidare i bildspelet. Följande metoder styr detta beteende:

- [setAdvanceOnClick](https://reference.aspose.com/slides/sv/python-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) låter användaren gå vidare genom att klicka med musen.  
- [setAdvanceAfter](https://reference.aspose.com/slides/sv/python-java/aspose.slides/slideshowtransition/#setAdvanceAfter) aktiverar automatisk vidaregång.  
- [setAdvanceAfterTime](https://reference.aspose.com/slides/sv/python-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) anger fördröjningen innan automatisk vidaregång, i millisekunder.

Aktivera både klick och tidsstyrd vidaregång så att användaren kan gå vidare med ett klick eller vänta på timern. För att använda enbart timern, skicka `False` till [setAdvanceOnClick]. Fördröjningen styr när bildspelet går vidare; den bestämmer inte varaktigheten för den visuella övergångseffekten.

Detta exempel tilldelar olika effekter till de tre första bilderna och aktiverar automatisk vidaregång efter 3, 5 respektive 7 sekunder. Musklick kan också gå vidare dessa bilder. Använd en `input.pptx`‑fil med minst tre bilder.

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

För att kontrollera om tidsstyrd vidaregång är aktiverad, anropa [getAdvanceAfter]. En lagrad fördröjning ensam indikerar inte att timern är aktiv.

Nästa exempel öppnar filen som sparades ovan, rapporterar varje aktiverad timer och inaktiverar automatisk vidaregång för bilder med en fördröjning större än två sekunder. Det aktiverar musklick för dessa bilder och sparar de uppdaterade inställningarna.

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

## **Styr övergångstider exakt**

Använd [setDuration] för att ange den exakta längden på en övergångseffekt i millisekunder. Bildens [getSlideShowTransition]-metod visar dessa inställningar via [SlideShowTransition]:

| Metod | Syfte |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/sv/python-java/aspose.slides/slideshowtransition/#setDuration) | Ställer in varaktigheten för själva övergångseffekten, i millisekunder. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/sv/python-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) | Ställer in fördröjningen innan bilden går vidare automatiskt, i millisekunder. Skicka `True` till [setAdvanceAfter](https://reference.aspose.com/slides/sv/python-java/aspose.slides/slideshowtransition/#setAdvanceAfter) för att aktivera denna timer. |
| [setSpeed](https://reference.aspose.com/slides/sv/python-java/aspose.slides/slideshowtransition/#setSpeed) | Väljer en fördefinierad hastighetskategori från [TransitionSpeed](https://reference.aspose.com/slides/sv/python-java/aspose.slides/transitionspeed/): Slow, Medium eller Fast. Den används när ingen exakt varaktighet anges. |

[setDuration] styr endast övergångseffekten; den bestämmer inte hur länge bilden förblir synlig. Konfigurera den automatiska fördröjningen separat. När ingen explicit varaktighet är angiven bestämmer Aspose.Slides effektens varaktighet utifrån övergångstypen och värdet från [getSpeed].

### **Tillämpa samma varaktighet på alla bilder**

För en jämn takt, tillämpa samma effekt och exakta varaktighet på alla bilder. Detta exempel läser in `input.pptx`, väljer Fade från [TransitionType](https://reference.aspose.com/slides/sv/python-java/aspose.slides/transitiontype/) och ger varje övergång en varaktighet på 750 millisekunder. Det aktiverar separat automatisk vidaregång efter 5 000 millisekunder och inaktiverar vidaregång med musklick, och sparar sedan resultatet som PPTX.

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

        # Konfigurera automatisk vidaregång oberoende av effektens varaktighet.
        transition.setAdvanceAfter(True)
        transition.setAdvanceAfterTime(5000)
        transition.setAdvanceOnClick(False)

    presentation.save("precise-transitions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Ange olika varaktigheter för enskilda bilder**

Olika bilder kan ha olika varaktigheter för effekter. Till exempel kan en kort övergång användas för en titelsida och en längre övergång för en sektionintro. Detta exempel anger 500 millisekunder för den första bilden och 1 200 millisekunder för den andra. Använd en `input.pptx`‑fil med minst två bilder.

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

När du förbereder en [animated GIF](/slides/sv/python-java/convert-powerpoint-to-animated-gif/), en [HTML5 presentation](/slides/sv/python-java/export-to-html5/) eller en [video](/slides/sv/python-java/convert-powerpoint-to-video/), ange exakta övergångstider innan export för att matcha den avsedda takten. Till exempel, använd en 600‑millisekunders fade mellan scener och justera varje bilds fördröjning för vidaregång separat för att ge tid för dess berättelse eller innehåll.

För GIF och video, koordinera utdatas bildfrekvens med effektens varaktighet: 600 millisekunder motsvarar 18 bildrutor vid 30 bildrutor per sekund. I HTML5, aktivera animerade övergångar i exportinställningarna. Kontrollera vilka effekter och tidsalternativ som stöds av det valda exportformatet och förhandsgranska utdatan för att bekräfta synkronisering.

### **Läs en befintlig övergångsvaraktighet**

Anropa [getDuration](https://reference.aspose.com/slides/sv/python-java/aspose.slides/slideshowtransition/#getDuration) innan du ändrar övergången för att avgöra om ett explicit värde är lagrat. Ett värde på `-1` betyder att ingen explicit varaktighet är angiven; ett icke‑negativt värde anger den lagrade varaktigheten i millisekunder. Det oangivna värdet är inte den beräknade uppspelningsvaraktigheten: Aspose.Slides använder övergångstypen och värdet från [getSpeed](https://reference.aspose.com/slides/sv/python-java/aspose.slides/slideshowtransition/#getSpeed) för att bestämma den varaktigheten. Att sätta en övergångstyp kan initiera en varaktighet, så undersök först de ursprungliga inställningarna.

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

Följande exempel skapar en bild med en textruta, klonar bilden och ändrar rektangelns position och storlek i klonen. Därefter väljs Morph från uppräkningen [TransitionType](https://reference.aspose.com/slides/sv/python-java/aspose.slides/transitiontype/) för den andra bilden. Öppna den sparade filen i en presentationsvisare som stödjer Morph för att se effekten under ett bildspel.

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

[TransitionMorphType]-uppräkningen styr hur Morph matchar och animera innehåll:

- [ByObject](https://reference.aspose.com/slides/sv/python-java/aspose.slides/transitionmorphtype/#ByObject) behandlar varje form som ett helt objekt.  
- [ByWord](https://reference.aspose.com/slides/sv/python-java/aspose.slides/transitionmorphtype/#ByWord) animera text genom att matcha ord där det är möjligt.  
- [ByChar](https://reference.aspose.com/slides/sv/python-java/aspose.slides/transitionmorphtype/#ByChar) animera text genom att matcha tecken där det är möjligt.

Använd [setType](https://reference.aspose.com/slides/sv/python-java/aspose.slides/slideshowtransition/#setType) för att välja Morph innan du hämtar [getValue](https://reference.aspose.com/slides/sv/python-java/aspose.slides/slideshowtransition/#getValue). Värdet blir då en instans av klassen [MorphTransition](https://reference.aspose.com/slides/sv/python-java/aspose.slides/morphtransition/), vars [setMorphType](https://reference.aspose.com/slides/sv/python-java/aspose.slides/morphtransition/#setMorphType) metod väljer matchningsläget.

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

Vissa övergångar erbjuder ytterligare alternativ, såsom riktning eller om effekten startar från en svart skärm. Tillgängliga alternativ beror på den övergång som valts med [setType]. Ställ först in typen och använd sedan den lämpliga klassen från [getValue].

Följande exempel tillämpar en Cut‑övergång på den första bilden i `input.pptx`. Det anropar [setFromBlack](https://reference.aspose.com/slides/sv/python-java/aspose.slides/optionalblacktransition/#setFromBlack) via [OptionalBlackTransition](https://reference.aspose.com/slides/sv/python-java/aspose.slides/optionalblacktransition/) så att övergången startar från en svart skärm.

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

## **Vanliga frågor**

**Kan jag kontrollera uppspelningshastigheten för en bildövergång?**

Ja. Föredra [setDuration](https://reference.aspose.com/slides/sv/python-java/aspose.slides/slideshowtransition/#setDuration) när du behöver en exakt effektvaraktighet i millisekunder. Använd [setSpeed](https://reference.aspose.com/slides/sv/python-java/aspose.slides/slideshowtransition/#setSpeed) när en fördefinierad [TransitionSpeed](https://reference.aspose.com/slides/sv/python-java/aspose.slides/transitionspeed/)‑kategori — Slow, Medium eller Fast — är tillräcklig och ingen explicit varaktighet är angiven. Dessa inställningar styr övergångseffekten oberoende av den automatiska vidaregångens fördröjning.

**Kan jag lägga till ljud till en övergång och låta den loopa?**

Ja. Tilldela inbäddat ljud med [setSound](https://reference.aspose.com/slides/sv/python-java/aspose.slides/slideshowtransition/#setSound), skicka StartSound från uppräkningen [TransitionSoundMode](https://reference.aspose.com/slides/sv/python-java/aspose.slides/transitionsoundmode/) till [setSoundMode](https://reference.aspose.com/slides/sv/python-java/aspose.slides/slideshowtransition/#setSoundMode) och aktivera [setSoundLoop](https://reference.aspose.com/slides/sv/python-java/aspose.slides/slideshowtransition/#setSoundLoop) med `True`. Ljudet loopar tills nästa ljudevent i bildspelet.

**Vad är det snabbaste sättet att tillämpa samma övergång på varje bild?**

Loopa igenom presentationens [getSlides](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/#getSlides)-samling och anropa [setType](https://reference.aspose.com/slides/sv/python-java/aspose.slides/slideshowtransition/#setType) med samma värde för varje bilds övergång. Sätt eventuella tids- och effektalternativ i samma loop för att hålla beteendet konsekvent över bilderna.

**Hur kan jag kontrollera vilken övergång som för närvarande är inställd på en bild?**

Anropa [getType](https://reference.aspose.com/slides/sv/python-java/aspose.slides/slideshowtransition/#getType) på resultatet från bildens [getSlideShowTransition](https://reference.aspose.com/slides/sv/python-java/aspose.slides/baseslide/#getSlideShowTransition). Den returnerar ett värde från uppräkningen [TransitionType](https://reference.aspose.com/slides/sv/python-java/aspose.slides/transitiontype/); None_ betyder att ingen övergångseffekt är tillämpad.