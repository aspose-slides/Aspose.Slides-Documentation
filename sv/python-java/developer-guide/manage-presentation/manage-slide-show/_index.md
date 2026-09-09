---
title: Hantera bildspel i Python via Java
linktitle: Bildspel
type: docs
weight: 90
url: /sv/python-java/manage-slide-show/
keywords:
- visningstyp
- presenterad av talare
- bläddrad av enskild
- bläddrad i kiosk
- visningsalternativ
- loopa kontinuerligt
- visa utan berättarröst
- visa utan animation
- penfärg
- visa bilder
- anpassad visning
- avancera bilder
- manuellt
- använda tider
- PowerPoint
- OpenDocument
- presentation
- Python
- Java
- Aspose.Slides
description: "Lär dig hur du hanterar bildspel i Aspose.Slides för Python via Java. Kontrollera bildövergångar, tider och mer i PPT-, PPTX- och ODP-format med lätthet."
---
## **Introduktion**

Microsoft PowerPoints **Set Up Show**-alternativ låter dig välja bildspels‑typ, aktivera loopning, välja bilder och kontrollera hur bilderna avancerar. Med Aspose.Slides för Python via Java kan du konfigurera dessa alternativ programatiskt och spara dem i en presentationsfil.

Metoden [Presentation.getSlideShowSettings](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/#getSlideShowSettings) returnerar ett [SlideShowSettings](https://reference.aspose.com/slides/sv/python-java/aspose.slides/slideshowsettings/)‑objekt som styr dessa alternativ. Exemplen nedan kräver Aspose.Slides för Python via Java och en kompatibel Java‑runtime. Varje exempel startar JVM om det behövs och frigör presentationen när den är klar.

## **Välj bildspels‑typ**

[SlideShowSettings.setSlideShowType](https://reference.aspose.com/slides/sv/python-java/aspose.slides/slideshowsettings/#setSlideShowType) definierar typen av bildspel, som kan vara en instans av följande klasser: [PresentedBySpeaker](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/sv/python-java/aspose.slides/browsedbyindividual/), eller [BrowsedAtKiosk](https://reference.aspose.com/slides/sv/python-java/aspose.slides/browsedatkiosk/). Genom att använda den här metoden kan du anpassa presentationen för olika användningsscenarier, såsom automatiserade kiosker eller manuella presentationer.

Kodexemplet nedan skapar en ny presentation och ställer in bildspels‑typen till "Browsed by an individual" utan att visa rullningslisten.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, BrowsedByIndividual

presentation = Presentation()
try:
    show_type = BrowsedByIndividual()
    show_type.setShowScrollbar(False)
    presentation.getSlideShowSettings().setSlideShowType(show_type)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Aktivera bildspelsalternativ**

[SlideShowSettings.setLoop](https://reference.aspose.com/slides/sv/python-java/aspose.slides/slideshowsettings/#setLoop) bestämmer om bildspelet ska upprepas i en loop tills det stoppas manuellt. Detta är användbart för automatiserade presentationer som måste köras kontinuerligt. [SlideShowSettings.setShowNarration](https://reference.aspose.com/slides/sv/python-java/aspose.slides/slideshowsettings/#setShowNarration) bestämmer om röstberättelser ska spelas upp under bildspelet. Det är användbart för automatiserade presentationer som innehåller röstinstruktioner för publiken. [SlideShowSettings.setShowAnimation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/slideshowsettings/#setShowAnimation) bestämmer om animationer som lagts till i bildobjekt ska spelas upp. Detta är användbart för att ge den fulla visuella effekten av presentationen.

Följande kodexempel skapar en ny presentation och loopar bildspelet.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    presentation.getSlideShowSettings().setLoop(True)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Välj bilder att visa**

[SlideShowSettings.setSlides](https://reference.aspose.com/slides/sv/python-java/aspose.slides/slideshowsettings/#setSlides) låter dig välja ett intervall av bilder som ska visas under presentationen. Detta är användbart när du bara vill visa en del av presentationen istället för alla bilder. Följande kodexempel skapar en presentation med nio bilder och väljer bilderna 2 till 9. Intervallet använder bildnummer med gränsen 1.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlidesRange

presentation = Presentation()
try:
    # Skapa nio bilder så att det valda intervallet finns.
    first_slide = presentation.getSlides().get_Item(0)
    for _ in range(8):
        presentation.getSlides().addClone(first_slide)

    slide_range = SlidesRange()
    slide_range.setStart(2)
    slide_range.setEnd(9)
    presentation.getSlideShowSettings().setSlides(slide_range)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Kontrollera bildframsteg**

[SlideShowSettings.setUseTimings](https://reference.aspose.com/slides/sv/python-java/aspose.slides/slideshowsettings/#setUseTimings) låter dig aktivera eller inaktivera användningen av fördefinierade tider för varje bild. Detta är användbart för att automatiskt visa bilder med fördefinierade visningstider. Kodexemplet nedan skapar en ny presentation och inaktiverar användning av tider.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    presentation.getSlideShowSettings().setUseTimings(False)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Visa mediakontroller**

[SlideShowSettings.setShowMediaControls](https://reference.aspose.com/slides/sv/python-java/aspose.slides/slideshowsettings/#setShowMediaControls) bestämmer om mediakontroller (t.ex. spela, pausa och stoppa) ska visas under bildspelet när multimediainnehåll (t.ex. video eller ljud) spelas. Detta är användbart när du vill ge presentatören kontroll över mediuppspelning under presentationen.

Följande kodexempel skapar en ny presentation och möjliggör att mediakontroller visas.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    presentation.getSlideShowSettings().setShowMediaControls(True)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Kan jag spara en presentation så att den öppnas direkt i bildspelsläge?**

Ja. Spara filen som PPSX eller PPSM; dessa format startar direkt i bildspelsläge när de öppnas i PowerPoint. I Aspose.Slides väljer du motsvarande sparformat [vid export](/slides/sv/python-java/save-presentation/).

**Kan jag utesluta enskilda bilder från visningen utan att radera dem från filen?**

Ja. Markera en bild som [dold](https://reference.aspose.com/slides/sv/python-java/aspose.slides/slide/#setHidden). Dolda bilder finns kvar i presentationen men visas inte under bildspelet.

**Kan Aspose.Slides spela upp ett bildspel eller styra en livepresentation på skärmen?**

Nej. Aspose.Slides redigerar, analyserar och konverterar presentationsfiler; själva uppspelningen hanteras av ett visningsprogram som PowerPoint.