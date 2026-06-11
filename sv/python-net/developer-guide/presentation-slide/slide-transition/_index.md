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
- Python
- Aspose.Slides
description: "Upptäck hur du anpassar bildövergångar i Aspose.Slides för Python via .NET, med steg-för-steg-vägledning för PowerPoint- och OpenDocument-presentationer."
---
## **Översikt**

Aspose.Slides for Python ger full kontroll över bildövergångar, från att välja en övergångstyp till att konfigurera timing och triggere som en del av automatiserade presentationsarbetsflöden. Du kan ställa in att bilder ska gå vidare på klick och/eller efter en angiven fördröjning samt förfina visuell beteende med effekter som klipp från svart eller riktade ingångar. Biblioteket stödjer även Morph‑övergången som introducerades i PowerPoint 2019, inklusive lägen som morphar efter objekt, ord eller tecken för att skapa en jämn, sammanhängande rörelse mellan bilder.

## **Lägg till bildövergångar**

För att göra detta enklare att förstå visar detta exempel hur man använder Aspose.Slides for Python för att hantera enkla bildövergångar. Utvecklare kan tillämpa olika bildövergångseffekter på bilder och anpassa deras beteende. Följ dessa steg för att skapa en enkel bildövergång:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/).
2. Tillämpa en bildövergång med hjälp av någon av effekterna från enum‑typen [TransitionType](https://reference.aspose.com/slides/sv/python-net/aspose.slides.slideshow/transitiontype/).
3. Spara den modifierade presentationsfilen.

```py
import aspose.slides as slides

# Instansiera Presentation-klassen för att läsa in en presentationsfil.
with slides.Presentation("sample.pptx") as presentation:
    # Tillämpa en cirkelövergång på bild 1.
    presentation.slides[0].slide_show_transition.type = slides.slideshow.TransitionType.CIRCLE

    # Tillämpa en kamövergång på bild 2.
    presentation.slides[1].slide_show_transition.type = slides.slideshow.TransitionType.COMB

    # Spara presentationen till disk.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Lägg till avancerade bildövergångar**

I det här avsnittet har vi tillämpat en enkel övergångseffekt på en bild. För att göra den effekten mer kontrollerad och polerad, följ dessa steg:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/).
2. Tillämpa en bildövergång med hjälp av någon av effekterna från enum‑typen [TransitionType](https://reference.aspose.com/slides/sv/python-net/aspose.slides.slideshow/transitiontype/).
3. Konfigurera övergången för att gå vidare vid klick, efter en bestämd tidsperiod, eller båda.
4. Spara den modifierade presentationsfilen.

Om **Advance On Click** är aktiverat går bilden endast vidare när användaren klickar. Om egenskapen **Advance After Time** är satt, går bilden automatiskt vidare efter det angivna intervallet.

```py
import aspose.slides as slides

# Instansiera Presentation-klassen för att öppna en presentationsfil.
with slides.Presentation("sample.pptx") as presentation:
    slide0 = presentation.slides[0]

    # Tillämpa en cirkelövergång på bild 1.
    slide0.slide_show_transition.type = slides.slideshow.TransitionType.CIRCLE

    # Aktivera gå vidare vid klick och ställ in en automatisk förflyttning på 3 sekunder.
    slide0.slide_show_transition.advance_on_click = True
    slide0.slide_show_transition.advance_after_time = 3000

    slide1 = presentation.slides[1]

    # Tillämpa en kamövergång på bild 2.
    slide1.slide_show_transition.type = slides.slideshow.TransitionType.COMB

    # Aktivera gå vidare vid klick och ställ in en automatisk förflyttning på 5 sekunder.
    slide1.slide_show_transition.advance_on_click = True
    slide1.slide_show_transition.advance_after_time = 5000

    slide2 = presentation.slides[2]

    # Tillämpa en zoom-övergång på bild 3.
    slide2.slide_show_transition.type = slides.slideshow.TransitionType.ZOOM

    # Aktivera gå vidare vid klick och ställ in en automatisk förflyttning på 7 sekunder.
    slide2.slide_show_transition.advance_on_click = True
    slide2.slide_show_transition.advance_after_time = 7000

    # Spara presentationen till disk.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Morph-övergång**

Aspose.Slides for Python stödjer [Morph transition](https://reference.aspose.com/slides/sv/python-net/aspose.slides.slideshow/morphtransition/), som animera den jämna rörelsen från en bild till nästa. Det här avsnittet förklarar hur man använder Morph‑övergången. För att använda den effektivt behöver du två bilder med minst ett gemensamt objekt. Det enklaste tillvägagångssättet är att duplicera en bild och sedan flytta objektet till en annan position på den andra bilden.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide0 = presentation.slides[0]

    auto_shape = slide0.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 400, 100)
    auto_shape.text_frame.text = "Morph Transition in PowerPoint Presentations"

    # Klona den första bilden för att skapa en andra bild med samma former för Morph‑kontinuitet.
    slide1 = presentation.slides.add_clone(slide0)

    # Välj samma rektangel på den andra bilden och ändra dess position och storlek.
    shape = slide1.shapes[0]
    shape.x += 100
    shape.y += 50
    shape.width -= 200
    shape.height -= 10

    # Aktivera Morph‑övergången på den andra bilden för att animera formförändringarna smidigt.
    slide1.slide_show_transition.type = slides.slideshow.TransitionType.MORPH

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Morph-övergångstyper**

Enum‑typen [TransitionMorphType](https://reference.aspose.com/slides/sv/python-net/aspose.slides.slideshow/transitionmorphtype/) representerar de olika typerna av Morph‑bildövergångar.

Följande kodsnutt visar hur man tillämpar en Morph‑övergång på en bild och ändrar morph‑typen:

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    slide.slide_show_transition.type = slides.slideshow.TransitionType.MORPH
    slide.slide_show_transition.value.morph_type = slides.slideshow.TransitionMorphType.BY_WORD
    
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Ställ in övergångseffekter**

Aspose.Slides for Python låter dig ställa in övergångseffekter såsom **From Black**, **From Left**, **From Right**, osv. För att konfigurera en övergångseffekt, följ dessa steg:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/).
2. Hämta en referens till bilden.
3. Ställ in önskad övergångseffekt.
4. Spara presentationen som en PPTX‑fil.

I exemplet nedan har vi ställt in flera övergångseffekter.

```py
import aspose.slides as slides

# Instansiera Presentation-klassen för att öppna en presentationsfil.
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    # Tillämpa en Cut-övergång och aktivera From Black.
    slide.slide_show_transition.type = slides.slideshow.TransitionType.CUT
    slide.slide_show_transition.value.from_black = True

    # Spara presentationen till disk.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Vanliga frågor**

**Kan jag kontrollera uppspelningshastigheten för en bildövergång?**

Ja. Ställ in övergångens [speed](https://reference.aspose.com/slides/sv/python-net/aspose.slides.slideshow/slideshowtransition/speed/) med hjälp av inställningen [TransitionSpeed](https://reference.aspose.com/slides/sv/python-net/aspose.slides.slideshow/transitionspeed/) (t.ex. slow/medium/fast).

**Kan jag bifoga ljud till en övergång och göra den i loop?**

Ja. Du kan bädda in ett ljud för övergången och styra beteendet via inställningar som ljudläge och loopning (t.ex. [sound](https://reference.aspose.com/slides/sv/python-net/aspose.slides.slideshow/slideshowtransition/sound/), [sound_mode](https://reference.aspose.com/slides/sv/python-net/aspose.slides.slideshow/slideshowtransition/sound_mode/), [sound_loop](https://reference.aspose.com/slides/sv/python-net/aspose.slides.slideshow/slideshowtransition/sound_loop/), samt metadata såsom [sound_is_built_in](https://reference.aspose.com/slides/sv/python-net/aspose.slides.slideshow/slideshowtransition/sound_is_built_in/), och [sound_name](https://reference.aspose.com/slides/sv/python-net/aspose.slides.slideshow/slideshowtransition/sound_name/)).

**Vad är det snabbaste sättet att tillämpa samma övergång på varje bild?**

Konfigurera önskad övergångstyp i varje bilds övergångsinställningar; övergångar lagras per bild, så att tillämpa samma typ på alla bilder ger ett konsekvent resultat.

**Hur kan jag kontrollera vilken övergång som för närvarande är inställd på en bild?**

Granska bildens [transition settings](https://reference.aspose.com/slides/sv/python-net/aspose.slides/slide/slide_show_transition/) och läs dess [transition type](https://reference.aspose.com/slides/sv/python-net/aspose.slides.slideshow/slideshowtransition/type/); det värdet visar exakt vilken effekt som används.