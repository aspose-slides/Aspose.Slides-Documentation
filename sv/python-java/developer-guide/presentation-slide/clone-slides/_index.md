---
title: Klona presentationsbilder i Python
linktitle: Klona bilder
type: docs
weight: 35
url: /sv/python-java/clone-slides/
keywords:
- klona bild
- kopiera bild
- spara bild
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Duplicera snabbt PowerPoint-bilder med Aspose.Slides för Python via Java. Följ våra tydliga kodexempel för att automatisera skapandet av PPT på sekunder och eliminera manuellt arbete."
---
## **Introduktion**

Kloning är processen att göra en exakt kopia eller replica av något. Aspose.Slides för Python via Java möjliggör också att skapa en kopia eller klon av en valfri bild och sedan infoga den klonade bilden i den aktuella presentationen eller någon annan öppen presentation. Processen för bildkloning skapar en ny bild som kan modifieras av utvecklare utan att ändra den ursprungliga bilden. Det finns flera möjliga sätt att klona en bild:

- Klona i slutet inom en presentation.
- Klona på en annan position inom en presentation.
- Klona i slutet i en annan presentation.
- Klona på en annan position i en annan presentation.
- Klona tillsammans med dess master‑bild till en annan presentation.

I Aspose.Slides för Python via Java tillhandahåller bildsamlingen (en samling av [Slide](https://reference.aspose.com/slides/sv/python-java/aspose.slides/slide/)‑objekt) som exponeras av [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/)‑objektet metoderna [addClone](https://reference.aspose.com/slides/sv/python-java/aspose.slides/slidecollection/#addClone) och [insertClone](https://reference.aspose.com/slides/sv/python-java/aspose.slides/slidecollection/#insertClone) för att utföra ovanstående typer av bildkloning.

## **Klona en bild i slutet av en presentation**

Om du vill klona en bild och sedan använda den i samma presentationsfil i slutet av de befintliga bilderna, använd metoden [addClone](https://reference.aspose.com/slides/sv/python-java/aspose.slides/slidecollection/#addClone) enligt stegen nedan:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/).
1. Hämta [SlideCollection](https://reference.aspose.com/slides/sv/python-java/aspose.slides/slidecollection/)‑objektet genom att referera till Slides‑samlingen som exponeras av [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/)‑objektet.
1. Anropa [addClone](https://reference.aspose.com/slides/sv/python-java/aspose.slides/slidecollection/#addClone)‑metoden som exponeras av [SlideCollection](https://reference.aspose.com/slides/sv/python-java/aspose.slides/slidecollection/)‑objektet och skicka bilden som ska klonas som en parameter till [addClone](https://reference.aspose.com/slides/sv/python-java/aspose.slides/slidecollection/#addClone)‑metoden.
1. Skriv den modifierade presentationsfilen.

I exemplaret nedan har vi klonat en bild (som ligger på den första positionen – index 0 – i presentationen) till slutet av presentationen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Instansiera Presentation-klassen som representerar en presentationsfil
presentation = Presentation("CloneWithinSamePresentationToEnd.pptx")
try:
    # Klona den önskade bilden till slutet av bildsamlingen i samma presentation
    slides = presentation.getSlides()

    slides.addClone(presentation.getSlides().get_Item(0))

    # Skriv den modifierade presentationen till disk
    presentation.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Klona en bild till en annan position inom en presentation**

Om du vill klona en bild och sedan använda den i samma presentationsfil men på en annan position, använd metoden [insertClone](https://reference.aspose.com/slides/sv/python-java/aspose.slides/slidecollection/#insertClone):

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/).
1. Hämta en referens till bildsamlingen som returneras av [getSlides](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/#getSlides) på [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/)‑objektet.
1. Anropa [insertClone](https://reference.aspose.com/slides/sv/python-java/aspose.slides/slidecollection/#insertClone)‑metoden som exponeras av [SlideCollection](https://reference.aspose.com/slides/sv/python-java/aspose.slides/slidecollection/)‑objektet och skicka bilden som ska klonas tillsammans med indexet för den nya positionen som en parameter till [insertClone](https://reference.aspose.com/slides/sv/python-java/aspose.slides/slidecollection/#insertClone)‑metoden.
1. Skriv den modifierade presentationen som en PPTX‑fil.

I exemplaret nedan har vi klonat en bild (som ligger på index 1 – position 2 – i presentationen) till index 2 – position 3 – i presentationen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Instansiera Presentation-klassen som representerar en presentationsfil
presentation = Presentation("CloneWithInSamePresentation.pptx")
try:
    # Hämta samlingen av bilder i presentationen
    slides = presentation.getSlides()

    # Klona den önskade bilden till det angivna indexet i samma presentation
    slides.insertClone(2, presentation.getSlides().get_Item(1))

    # Skriv den modifierade presentationen till disk
    presentation.save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Klona en bild i slutet av en annan presentation**

Om du behöver klona en bild från en presentation och använda den i en annan presentationsfil, i slutet av de befintliga bilderna:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/) som innehåller den presentation som bilden ska klonas från.
1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/) som innehåller destinationspresentationen som bilden ska läggas till i.
1. Hämta [SlideCollection](https://reference.aspose.com/slides/sv/python-java/aspose.slides/slidecollection/)‑objektet genom att referera till bildsamlingen som returneras av [getSlides](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/#getSlides) på [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/)‑objektet för destinationspresentationen.
1. Anropa [addClone](https://reference.aspose.com/slides/sv/python-java/aspose.slides/slidecollection/#addClone)‑metoden som exponeras av [SlideCollection](https://reference.aspose.com/slides/sv/python-java/aspose.slides/slidecollection/)‑objektet och skicka bilden från källpresentationen som en parameter till [addClone](https://reference.aspose.com/slides/sv/python-java/aspose.slides/slidecollection/#addClone)‑metoden.
1. Skriv den modifierade destinationspresentationsfilen.

I exemplaret nedan har vi klonat en bild (från index 0 i källpresentationen) till slutet av destinationspresentationen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Instansiera Presentation-klassen för att ladda källpresentationsfilen
source_presentation = Presentation("CloneAtEndOfAnother.pptx")
try:
    # Instansiera Presentation-klassen för destinations-PPTX (där bilden ska klonas)
    destination_presentation = Presentation()
    try:
        # Klona den önskade bilden från källpresentationen till slutet av bildsamlingen i destinationspresentationen
        slides = destination_presentation.getSlides()

        slides.addClone(source_presentation.getSlides().get_Item(0))

        # Skriv destinationspresentationen till disk
        destination_presentation.save("Aspose2_out.pptx", SaveFormat.Pptx)
    finally:
        destination_presentation.dispose()
finally:
    source_presentation.dispose()
```

## **Klona en bild till en annan position i en annan presentation**

Om du behöver klona en bild från en presentation och använda den i en annan presentationsfil, på en specifik position:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/) som innehåller källpresentationen som bilden ska klonas från.
1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/) som innehåller den presentation som bilden ska läggas till i.
1. Hämta [SlideCollection](https://reference.aspose.com/slides/sv/python-java/aspose.slides/slidecollection/)‑objektet genom att referera till Slides‑samlingen som exponeras av [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/)‑objektet för destinationspresentationen.
1. Anropa [insertClone](https://reference.aspose.com/slides/sv/python-java/aspose.slides/slidecollection/#insertClone)‑metoden som exponeras av [SlideCollection](https://reference.aspose.com/slides/sv/python-java/aspose.slides/slidecollection/)‑objektet och skicka bilden från källpresentationen tillsammans med den önskade positionen som en parameter till [insertClone](https://reference.aspose.com/slides/sv/python-java/aspose.slides/slidecollection/#insertClone)‑metoden.
1. Skriv den modifierade destinationspresentationsfilen.

I exemplaret nedan har vi klonat en bild (från index 0 i källpresentationen) till index 1 (position 2) i destinationspresentationen.

```python
import jpype
import asposeslides

if not jpide.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Instansiera Presentation-klassen för att ladda källpresentationsfilen
source_presentation = Presentation("CloneAtEndOfAnother.pptx")
try:
    # Instansiera Presentation-klassen för destinations-PPTX (där bilden ska klonas)
    destination_presentation = Presentation()
    try:
        # Klona den önskade bilden från källpresentationen till det specificerade indexet i destinationspresentationen
        slides = destination_presentation.getSlides()

        slides.insertClone(1, source_presentation.getSlides().get_Item(0))

        # Skriv destinationspresentationen till disk
        destination_presentation.save("Aspose2_out.pptx", SaveFormat.Pptx)
    finally:
        destination_presentation.dispose()
finally:
    source_presentation.dispose()
```

## **Klona en bild med dess master‑bild till en annan presentation**

Om du behöver klona en bild med en master‑bild från en presentation och använda den i en annan presentation, måste du först klona den önskade master‑bilden från källpresentationen till destinationspresentationen. Använd sedan den klonade master‑bilden när du klonar bilden. Metoden [addClone](https://reference.aspose.com/slides/sv/python-java/aspose.slides/slidecollection/#addClone) förväntar sig en master‑bild från destinationspresentationen snarare än från källpresentationen. För att klona bilden med en master, följ stegen nedan:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/) som innehåller källpresentationen som bilden ska klonas från.
1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/) som innehåller destinationspresentationen som bilden ska klonas till.
1. Kom åt bilden som ska klonas tillsammans med master‑bilden.
1. Hämta [MasterSlideCollection](https://reference.aspose.com/slides/sv/python-java/aspose.slides/masterslidecollection/)‑objektet genom att referera till Masters‑samlingen som exponeras av [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/)‑objektet för destinationspresentationen.
1. Anropa [addClone](https://reference.aspose.com/slides/sv/python-java/aspose.slides/masterslidecollection/#addClone)‑metoden som exponeras av [MasterSlideCollection](https://reference.aspose.com/slides/sv/python-java/aspose.slides/masterslidecollection/)‑objektet och skicka master‑bilden från käll‑PPTX som ska klonas som en parameter till [addClone](https://reference.aspose.com/slides/sv/python-java/aspose.slides/masterslidecollection/#addClone)‑metoden.
1. Hämta [SlideCollection](https://reference.aspose.com/slides/sv/python-java/aspose.slides/slidecollection/)‑objektet genom att referera till Slides‑samlingen som exponeras av [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/)‑objektet för destinationspresentationen.
1. Anropa [addClone](https://reference.aspose.com/slides/sv/python-java/aspose.slides/slidecollection/#addClone)‑metoden som exponeras av [SlideCollection](https://reference.aspose.com/slides/sv/python-java/aspose.slides/slidecollection/)‑objektet och skicka bilden från källpresentationen som ska klonas samt master‑bilden som en parameter till [addClone](https://reference.aspose.com/slides/sv/python-java/aspose.slides/slidecollection/#addClone)‑metoden.
1. Skriv den modifierade destinationspresentationsfilen.

I exemplaret nedan har vi klonat en bild med en master (som ligger på index 0 i källpresentationen) till slutet av destinationspresentationen med hjälp av källbildens master.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Instansiera Presentation-klassen för att ladda källpresentationsfilen
source_presentation = Presentation("CloneToAnotherPresentationWithMaster.pptx")
try:
    # Instansiera Presentation-klassen för destinationspresentationen (där bilden ska klonas)
    destination_presentation = Presentation()
    try:
        # Instansiera Slide från samlingen av bilder i källpresentationen tillsammans med
        # Master-bilden
        source_slide = source_presentation.getSlides().get_Item(0)
        source_master = source_slide.getLayoutSlide().getMasterSlide()

        # Klona den önskade master-bilden från källpresentationen till samlingen av master-bilder i
        # destinationspresentationen
        masters = destination_presentation.getMasters()
        destination_master = masters.addClone(source_master)

        # Klona den önskade bilden från källpresentationen med den önskade master-bilden till slutet av
        # samlingen av bilder i destinationspresentationen
        slides = destination_presentation.getSlides()
        slides.addClone(source_slide, destination_master, True)

        # Spara destinationspresentationen till disk
        destination_presentation.save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat.Pptx)
    finally:
        destination_presentation.dispose()
finally:
    source_presentation.dispose()
```

## **Klona en bild i slutet av ett specificerat avsnitt**

Om du vill klona en bild och sedan använda den i samma presentationsfil men i ett annat avsnitt, använd då metoden [**addClone**](https://reference.aspose.com/slides/sv/python-java/aspose.slides/slidecollection/#addClone) som exponeras av klassen [**SlideCollection**](https://reference.aspose.com/slides/sv/python-java/aspose.slides/slidecollection/). Aspose.Slides för Python via Java möjliggör att klona en bild från det första avsnittet och sedan infoga den klonade bilden i det andra avsnittet i samma presentation.

Följande kodsnutt visar hur du klonar en bild och infogar den klonade bilden i ett specificerat avsnitt.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 50, 300, 100)
    presentation.getSections().addSection("Section 1", presentation.getSlides().get_Item(0))

    destination_section = presentation.getSections().appendEmptySection("Section 2")
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0), destination_section)

    # Spara destinationspresentationen till disk
    presentation.save("CloneSlideIntoSpecifiedSection.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Säkerställ matchande bildstorlek**

När du klonar bilder till en annan presentation, se till att destinationspresentationen har samma bildstorlek som källan. Om bildstorlekarna skiljer sig, skalar inte Aspose.Slides automatiskt om de klonade formerna – deras ursprungliga koordinater och dimensioner bevaras, vilket kan leda till att innehållet blir feljusterat eller sträcker sig utanför bildens gränser.

Du kan ställa in destinationspresentationens bildstorlek så att den matchar källan innan du klonar master‑bilden och bilden:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideSizeScaleType

source_presentation = Presentation("CloneToAnotherPresentationWithMaster.pptx")
try:
    target_presentation = Presentation()
    try:
        source_size = source_presentation.getSlideSize().getSize()
        target_presentation.getSlideSize().setSize(jpype.JFloat(source_size.getWidth()), jpype.JFloat(source_size.getHeight()), SlideSizeScaleType.DoNotScale)
    finally:
        target_presentation.dispose()
finally:
    source_presentation.dispose()
```

Gör detta innan du klonar master‑bilden och bilden.

## **Vanliga frågor**

**Klonas föreläsaranteckningar och granskarkommentarer?**

Ja. Notssidan och granskningskommentarerna inkluderas i klonen. Om du inte vill ha dem, [ta bort dem](/slides/sv/python-java/presentation-notes/) efter infogning.

**Hur hanteras diagram och deras datakällor?**

Diagramobjektet, formateringen och de inbäddade data kopieras. Om diagrammet var länkat till en extern källa (t.ex. en OLE‑inbäddad arbetsbok), bevaras den länken som ett [OLE‑objekt](/slides/sv/python-java/manage-ole/). Efter flytt mellan filer, verifiera datatillgänglighet och uppdateringsbeteende.

**Kan jag styra infogningspositionen och avsnitten för klonen?**

Ja. Du kan infoga klonen på ett specifikt bildindex och placera den i ett valt [avsnitt](/slides/sv/python-java/slide-section/). Om mål‑avsnittet inte finns, skapa det först och flytta sedan bilden dit.