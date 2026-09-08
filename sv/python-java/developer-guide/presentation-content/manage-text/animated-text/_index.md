---
title: Animera PowerPoint-text i Python via Java
linktitle: animera text
type: docs
weight: 60
url: /sv/python-java/animated-text/
keywords:
- animera text
- textanimation
- animera stycke
- styckeanimation
- animationseffekt
- PowerPoint
- OpenDocument
- presentation
- Python
- Java
- Aspose.Slides
description: "Skapa dynamisk animerad text i PowerPoint- och OpenDocument-presentationer med Aspose.Slides för Python via Java, med enkla, optimerade Python-exempel."
---
## **Översikt**

Denna artikel förklarar hur du arbetar med animerad text i Aspose.Slides genom att applicera animationseffekter på enskilda stycken och hämta de effekter som redan har tilldelats stycken i en textram. Den fokuserar på API‑metoderna som används för att lägga till styckenivå‑animation och inspektera befintliga stycke‑animationseffekter i en presentation.

## **Lägg till animationseffekter för stycken**

Metoden [addEffect](https://reference.aspose.com/slides/sv/python-java/aspose.slides/sequence/#addEffect) i klassen [Sequence](https://reference.aspose.com/slides/sv/python-java/aspose.slides/sequence/) låter dig lägga till animationseffekter till ett enda stycke. Följande exempel visar hur du lägger till en animationseffekt till ett stycke:

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

    # Lägg till en Fly-animeringseffekt till det valda stycket.
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(paragraph, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick)

    presentation.save("AnimationEffectinParagraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Hämta animationseffekter för stycken**

Du kan behöva ta reda på vilka animationseffekter som har lagts till i ett stycke – till exempel i ett scenario där du vill hämta animationseffekterna i ett stycke för att applicera dem på ett annat stycke eller en annan form.

Aspose.Slides for Python via Java möjliggör att hämta alla animationseffekter som har applicerats på stycken i en textram (form). Följande exempel visar hur du hämtar animationseffekterna i ett stycke:

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

## **FAQ**

**Hur skiljer sig textanimationer från bildövergångar, och kan de kombineras?**

Textanimationer styr objekts beteende över tid på en bild, medan [transitions](/slides/sv/python-java/slide-transition/) styr hur bilder förändras. De är oberoende och kan användas tillsammans; uppspelningsordningen styrs av animationstidslinjen och övergångsinställningarna.

**Bevaras textanimationer vid export till PDF eller bilder?**

Nej. PDF‑ och rasterbilder är statiska, så du ser bara ett enda tillstånd av bilden utan rörelse. För att behålla rörelsen, använd export till [video](/slides/sv/python-java/convert-powerpoint-to-video/) eller [HTML](/slides/sv/python-java/export-to-html5/).

**Fungerar textanimationer i layouter och bildmaster?**

Effekter som appliceras på layout‑/masterobjekt ärvs av bilder, men deras timing och interaktion med bildnivå‑animationer beror på den slutgiltiga sekvensen på bilden.