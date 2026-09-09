---
title: Animera PowerPoint-text i Python via Java
linktitle: Animerad text
type: docs
weight: 60
url: /sv/python-java/animated-text/
keywords:
- animerad text
- textanimation
- animerat stycke
- styckeanimation
- animationseffekt
- PowerPoint
- OpenDocument
- presentation
- Python
- Java
- Aspose.Slides
description: "Skapa dynamisk animerad text i PowerPoint- och OpenDocument-presentationer med Aspose.Slides för Python via Java, med lättföljda, optimerade Python-kodexempel."
---
## **Översikt**

Den här artikeln förklarar hur du arbetar med animerad text i Aspose.Slides genom att tillämpa animationseffekter på enskilda stycken och hämta de effekter som redan har tilldelats stycken i ett textram. Den fokuserar på API‑metoderna som används för att lägga till styckesnivåanimation och inspektera befintliga styckeanimationseffekter i en presentation.

## **Lägg till animationseffekter på stycken**

Metoden [addEffect](https://reference.aspose.com/slides/sv/python-java/aspose.slides/sequence/#addEffect) i klassen [Sequence](https://reference.aspose.com/slides/sv/python-java/aspose.slides/sequence/) låter dig lägga till animationseffekter på ett enskilt stycke. Den här exempel­koden visar hur du lägger till en animationseffekt på ett enskilt stycke:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat

presentation = Presentation("Presentation.pptx")
try:
    # Välj stycket att lägga till en effekt på.
    auto_shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # Lägg till en Fly-animationseffekt på det valda stycket.
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(paragraph, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick)

    presentation.save("AnimationEffectinParagraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Hämta animationseffekter för stycken**

Du kan vilja hämta de animationseffekter som har applicerats på ett stycke – till exempel för att tillämpa dessa effekter på ett annat stycke eller en form.

Aspose.Slides för Python via Java låter dig hämta alla animationseffekter som har applicerats på stycken i ett textram (form). Den här exempel­koden visar hur du får animationseffekterna som är applicerade på ett stycke:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("Presentation.pptx")
try:
    sequence = presentation.getSlides().get_Item(0).getTimeline().getMainSequence()
    auto_shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)

    for paragraph in auto_shape.getTextFrame().getParagraphs():
        effects = sequence.getEffectsByParagraph(paragraph)

        if len(effects) > 0:
            print(f'Paragraph "{paragraph.getText()}" has {effects[0].getType()} effect.')
finally:
    presentation.dispose()
```

## **Vanliga frågor**

**Hur skiljer sig textanimationer från bildövergångar, och kan de kombineras?**

Textanimationer styr objektets beteende över tid på en bild, medan [transitions](/slides/sv/python-java/slide-transition/) styr hur bilderna förändras. De är oberoende och kan användas tillsammans; uppspelningsordningen styrs av animationstidslinjen och övergångsinställningarna.

**Bevaras textanimationer vid export till PDF eller bilder?**

Nej. PDF‑ och rasterbilder är statiska, så du ser ett enda tillstånd av bilden utan rörelse. För att behålla rörelsen, använd export till [video](/slides/sv/python-java/convert-powerpoint-to-video/) eller [HTML](/slides/sv/python-java/export-to-html5/).

**Fungerar textanimationer i layouter och bildmästaren?**

Effekter som appliceras på layout‑/mästarelement ärvs av bilder, men deras timing och interaktion med bildnivåanimationer beror på den slutgiltiga sekvensen på bilden.