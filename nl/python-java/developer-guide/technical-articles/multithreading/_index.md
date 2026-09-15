---
title: Multithreading in Aspose.Slides voor Python via Java
linktitle: Multithreading
type: docs
weight: 310
url: /nl/python-java/multithreading/
keywords:
- multithreading
- meerdere threads
- parallel werken
- dia's converteren
- dia's naar afbeeldingen
- PowerPoint
- OpenDocument
- presentatie
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides voor Python via Java multithreading versnelt de verwerking van PowerPoint- en OpenDocumentbestanden. Ontdek de beste praktijken voor efficiënte presentatieworkflows."
---
## **Inleiding**

Hoewel parallel werken met presentaties mogelijk is (behalve bij het ontleden, laden en klonen) en meestal goed werkt, is er een kleine kans op onjuiste resultaten wanneer u de bibliotheek in meerdere threads gebruikt.

We raden sterk aan om **geen** enkele [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/) instantie te gebruiken in een multithreaded omgeving, omdat dit kan leiden tot onvoorspelbare fouten of storingen die niet gemakkelijk worden gedetecteerd.

Het is **niet** veilig om een [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/) instantie te laden, op te slaan en/of te klonen in meerdere threads. Dergelijke bewerkingen worden **niet** ondersteund. Als u dergelijke taken moet uitvoeren, moet u de bewerkingen paralleliseren met behulp van meerdere single‑threaded processen — en elk van deze processen moet zijn eigen presentatie‑instantie gebruiken.

## **Presentatieslides parallel naar afbeeldingen converteren**

Stel dat we alle dia's van een PowerPoint‑presentatie parallel naar PNG‑afbeeldingen willen omzetten. Omdat het onveilig is om een enkele [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/) instantie in meerdere threads te gebruiken, splitsen we de presentatiedia's op in afzonderlijke presentaties en zetten de dia's parallel om naar afbeeldingen, waarbij elke presentatie in een aparte thread wordt gebruikt. Het volgende codevoorbeeld laat zien hoe dit te doen.

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
            # Extraheer de dia naar een aparte presentatie.
            slide_presentation = Presentation()
            slide_presentation.getSlideSize().setSize(slide_width, slide_height, SlideSizeScaleType.DoNotScale)
            slide_presentation.getSlides().removeAt(0)
            slide_presentation.getSlides().addClone(presentation.getSlides().get_Item(slide_index))

            # Converteer de dia naar een afbeelding in een aparte taak.
            slide_number = slide_index + 1
            conversion_task = executor.submit(convert_slide_to_image, slide_presentation, slide_number)
            conversion_tasks.append(conversion_task)

        # Wacht tot alle taken voltooid zijn.
        for conversion_task in conversion_tasks:
            conversion_task.result()
finally:
    presentation.dispose()
```

## **FAQ**

**Moet ik licentie‑instelling in elke thread aanroepen?**

Nee. Het volstaat om dit één keer per proces te doen voordat de threads starten. Als [license setup](/slides/nl/python-java/licensing/) mogelijk gelijktijdig wordt aangeroepen (bijvoorbeeld tijdens lazy initialisatie), synchroniseer die aanroep omdat de licentie‑instellingsmethode zelf niet thread‑safe is.

**Kan ik [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/)‑ of [Slide](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slide/)‑objecten tussen threads doorgeven?**

Het doorgeven van "live" presentatiedobjecten tussen threads wordt niet aanbevolen: gebruik onafhankelijke instanties per thread of maak vooraf afzonderlijke presentaties of slide‑containers voor elke thread aan. Deze aanpak volgt de algemene aanbeveling om geen enkele presentatied instantie te delen tussen threads.

**Is het veilig om export naar verschillende formaten (PDF, HTML, afbeeldingen) te paralleliseren, mits elke thread zijn eigen [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/) instantie heeft?**

Ja. Met onafhankelijke instanties en afzonderlijke output‑paden paralleliseren dergelijke taken zich doorgaans correct; vermijd gedeelde presentatiedobjecten en gedeelde I/O‑streams.

**Wat moet ik doen met globale lettertype‑instellingen (mappen, substituties) in multithreading?**

Initialiseer alle globale [font settings](/slides/nl/python-java/powerpoint-fonts/) voordat de threads worden gestart en wijzig ze niet tijdens parallel werk. Dit voorkomt race‑condities bij het benaderen van gedeelde lettertype‑bronnen.