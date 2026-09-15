---
title: Multitrådning i Aspose.Slides för Python via Java
linktitle: Multitrådning
type: docs
weight: 310
url: /sv/python-java/multithreading/
keywords:
- multitrådning
- flera trådar
- parallellt arbete
- konvertera bilder
- bilder till bildfiler
- PowerPoint
- OpenDocument
- presentation
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides för Python via Java multitrådning förbättrar bearbetning av PowerPoint och OpenDocument. Upptäck bästa praxis för effektiva presentationsarbetsflöden."
---
## **Introduktion**

Även om parallellt arbete med presentationer är möjligt (förutom parsning, inläsning och kloning) och vanligtvis fungerar bra, finns det en liten risk för felaktiga resultat när du använder biblioteket i flera trådar.

Vi rekommenderar starkt att du **inte** använder en enda [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/)-instans i en multitrådad miljö eftersom det kan leda till oförutsägbara fel eller misslyckanden som inte lätt upptäcks.

Det är **inte** säkert att ladda, spara och/eller klona en [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/)-instans i flera trådar. Sådana operationer **stöds inte**. Om du behöver utföra sådana uppgifter måste du parallellisera operationerna med flera enklatrådade processer—och varje process bör använda sin egen presentationsinstans.

## **Konvertera presentationsbilder till bilder parallellt**

Låt oss säga att vi vill konvertera alla bilder i en PowerPoint-presentation till PNG-bilder parallellt. Eftersom det är osäkert att använda en enda [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/)-instans i flera trådar, delar vi upp presentationsbilderna i separata presentationer och konverterar bilderna till bilder parallellt, genom att använda varje presentation i en separat tråd. Följande kodexempel visar hur man gör detta.

```python
from concurrent.futures import ThreadPoolExecutor

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation, SlideSizeScaleType


input_file_path = "sample.pptx"
output_file_path_template = "slide_{}.png"
image_scale = 2.0


def convert_slide_to_image(slide_presentation, slide_number):
    try:
        slide = slide_presentation.getSlides().get_Item(0)
        image = slide.getImage(image_scale, image_scale)
        try:
            image_file_path = output_file_path_template.format(slide_number)
            image.save(image_file_path, ImageFormat.Png)
        finally:
            image.dispose()
    finally:
        slide_presentation.dispose()


presentation = Presentation(input_file_path)
try:
    slide_count = presentation.getSlides().size()
    slide_size = presentation.getSlideSize().getSize()
    slide_width = jpype.JFloat(slide_size.getWidth())
    slide_height = jpype.JFloat(slide_size.getHeight())

    with ThreadPoolExecutor() as executor:
        conversion_tasks = []
        for slide_index in range(slide_count):
            # Extrahera bilden till en separat presentation.
            slide_presentation = Presentation()
            slide_presentation.getSlideSize().setSize(slide_width, slide_height, SlideSizeScaleType.DoNotScale)
            slide_presentation.getSlides().removeAt(0)
            slide_presentation.getSlides().addClone(presentation.getSlides().get_Item(slide_index))

            # Konvertera bilden till en bild i en separat uppgift.
            slide_number = slide_index + 1
            conversion_task = executor.submit(convert_slide_to_image, slide_presentation, slide_number)
            conversion_tasks.append(conversion_task)

        # Vänta på att alla uppgifter ska slutföras.
        for conversion_task in conversion_tasks:
            conversion_task.result()
finally:
    presentation.dispose()
```

## **FAQ**

**Behöver jag anropa licensinställning i varje tråd?**

Nej. Det räcker att göra det en gång per process innan trådar startas. Om [license setup](/slides/sv/python-java/licensing/) kan anropas samtidigt (till exempel under lat initiering), synkronisera det anropet eftersom licensinställningsmetoden själv inte är trådsäker.

**Kan jag skicka [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/) eller [Slide](https://reference.aspose.com/slides/sv/python-java/aspose.slides/slide/) objekt mellan trådar?**

Att skicka "levande" presentationsobjekt mellan trådar rekommenderas inte: använd oberoende instanser per tråd eller skapa separata presentationer eller bildbehållare för varje tråd i förväg. Detta tillvägagångssätt följer den allmänna rekommendationen att inte dela en enda presentationsinstans över trådar.

**Är det säkert att parallellisera export till olika format (PDF, HTML, bilder) förutsatt att varje tråd har sin egen [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/)-instans?**

Ja. Med oberoende instanser och separata utmatningssökvägar parallelliseras sådana uppgifter vanligtvis korrekt; undvik delade presentationsobjekt och delade I/O-strömmar.

**Vad bör jag göra med globala typsnittsinställningar (mappar, ersättningar) i multitrådning?**

Initiera alla globala [font settings](/slides/sv/python-java/powerpoint-fonts/) innan trådarna startas och ändra dem inte under parallellt arbete. Detta eliminerar tävlingar när delade typsnittresurser nås.