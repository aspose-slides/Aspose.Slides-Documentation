---
title: Åtkomst till presentationsbilder i Python
linktitle: Åtkomst till bild
type: docs
weight: 20
url: /sv/python-java/access-slide-in-presentation/
keywords:
- åtkomst bild
- bild index
- bild id
- bild position
- ändra position
- bild egenskaper
- bild nummer
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Lär dig hur du får åtkomst till och hanterar bilder i PowerPoint- och OpenDocument-presentationer med Aspose.Slides för Python via Java. Öka produktiviteten med kodexempel."
---
## **Översikt**

Den här artikeln förklarar hur man får åtkomst till och hanterar bilder i en presentation med Aspose.Slides. Den visar hur man hämtar bilder via deras nollbaserade index från bildsamlingen och hur man får åtkomst till en bild via dess unika ID med hjälp av metoden [getSlideById](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/#getSlideById).

Du får också lära dig hur du ändrar en bilds position med metoden [setSlideNumber](https://reference.aspose.com/slides/sv/python-java/aspose.slides/slide/#setSlideNumber) och hur du definierar startbildnumret för en presentation med metoden [setFirstSlideNumber](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/#setFirstSlideNumber). Exemplen visar hur man laddar en presentation, får bildreferenser, uppdaterar bildordning eller numrering och sparar den modifierade presentationen.

## **Åtkomst till en bild via index**

Alla bilder i en presentation är ordnade numeriskt baserat på bildens position med början från 0. Den första bilden är åtkomlig via index 0; den andra bilden nås via index 1; osv.

Klassen [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/) som representerar en presentationsfil exponerar alla bilder som en [SlideCollection](https://reference.aspose.com/slides/sv/python-java/aspose.slides/slidecollection/) (samling av [Slide](https://reference.aspose.com/slides/sv/python-java/aspose.slides/slide/)‑objekt). Denna Python‑kod visar hur du får åtkomst till en bild via dess index:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

# Skapa ett Presentation-objekt som representerar en presentationsfil.
presentation = Presentation("demo.pptx")
try:
    # Hämta en bild med hjälp av dess index.
    slide = presentation.getSlides().get_Item(0)
finally:
    presentation.dispose()
```

## **Åtkomst till en bild via ID**

Varje bild i en presentation har ett unikt ID kopplat till sig. Du kan använda metoden [getSlideById](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/#getSlideById) (tillgänglig via klassen [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/)) för att rikta in dig på det ID:t. Denna Python‑kod visar hur du anger ett giltigt bild‑ID och får åtkomst till den bilden via metoden [getSlideById](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/#getSlideById):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

# Skapa ett Presentation-objekt som representerar en presentationsfil.
presentation = Presentation("demo.pptx")
try:
    # Hämta ett bild-ID.
    slide_id = presentation.getSlides().get_Item(0).getSlideId()

    # Åtkomst till bilden via dess ID.
    slide = presentation.getSlideById(slide_id)
finally:
    presentation.dispose()
```

## **Ändra bildens position**

Aspose.Slides låter dig ändra en bilds position. Till exempel kan du ange att den första bilden ska bli den andra bilden.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/).
1. Hämta bildens referens (vilken position du vill ändra) via dess index.
1. Ange en ny position för bilden med metoden [setSlideNumber](https://reference.aspose.com/slides/sv/python-java/aspose.slides/slide/#setSlideNumber).
1. Spara den ändrade presentationen.

Denna Python‑kod demonstrerar en operation där bilden i position 1 flyttas till position 2:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Skapa ett Presentation-objekt som representerar en presentationsfil.
presentation = Presentation("Presentation.pptx")
try:
    # Hämta bilden vars position ska ändras.
    slide = presentation.getSlides().get_Item(0)

    # Ange den nya positionen för bilden.
    slide.setSlideNumber(2)

    # Spara den ändrade presentationen.
    presentation.save("helloworld_Pos.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Den första bilden blev den andra; den andra bilden blev den första. När du ändrar en bilds position justeras övriga bilder automatiskt.

## **Ange bildnumret**

Genom att använda metoden [setFirstSlideNumber](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/#setFirstSlideNumber) (tillgänglig via klassen [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/)) kan du ange ett nytt nummer för den första bilden i en presentation. Denna operation får andra bildnummer att beräknas om.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/).
1. Hämta bildnumret.
1. Ange bildnumret.
1. Spara den ändrade presentationen.

Denna Python‑kod demonstrerar en operation där det första bildnumret sätts till 10:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Skapa ett Presentation-objekt som representerar en presentationsfil.
presentation = Presentation("HelloWorld.pptx")
try:
    # Hämta bildnumret.
    first_slide_number = presentation.getFirstSlideNumber()

    # Ange bildnumret.
    presentation.setFirstSlideNumber(10)

    # Spara den ändrade presentationen.
    presentation.save("Set_Slide_Number_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Om du föredrar att hoppa över den första bilden kan du starta numreringen från den andra bilden (och dölja numreringen för den första bilden) på följande sätt:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpime.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideLayoutType

presentation = Presentation()
try:
    layout_slide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)
    presentation.getSlides().addEmptySlide(layout_slide)
    presentation.getSlides().addEmptySlide(layout_slide)
    presentation.getSlides().addEmptySlide(layout_slide)

    # Ställ in numret för den första presentationsbilden.
    # Visa bildnummer för alla bilder.
    # Dölj bildnumret för den första bilden.
    # Spara den ändrade presentationen.
    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Matchar bildnumret som en användare ser samlingens nollbaserade index?**

Numret som visas på en bild kan börja från ett godtyckligt värde (t.ex. 10) och behöver inte matcha indexet; förhållandet styrs av presentationens [first slide number](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/#setFirstSlideNumber)-inställning.

**Påverkar dolda bilder indexeringen?**

Ja. En dold bild finns kvar i samlingen och räknas med i indexeringen; “dold” avser visning, inte dess position i samlingen.

**Ändras en bilds index när andra bilder läggs till eller tas bort?**

Ja. Indexen speglar alltid den aktuella ordningen i bildsamlingen och beräknas om vid insättning, borttagning och flyttoperationer.