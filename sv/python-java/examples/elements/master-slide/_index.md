---
title: Masterbild
type: docs
weight: 30
url: /sv/python-java/examples/elements/master-slide/
keywords:
- kodexempel
- masterbild
- lägg till masterbild
- åtkomst till masterbild
- ta bort masterbild
- oanvänd masterbild
- PowerPoint
- OpenDocument
- presentation
- Python
- Java
- Aspose.Slides
description: "Hantera masterbilder med Aspose.Slides för Python via Java: skapa, få åtkomst till, ta bort och rensa upp masterbilder i PowerPoint- och OpenDocument-presentationer."
---
Masterbilder utgör den översta nivån i bildärvningshierarkin i PowerPoint. En **masterbild** definierar gemensamma designelement såsom bakgrunder, logotyper och textformatering. **Layoutbilder** ärver från masterbilder, och **normala bilder** ärver från layoutbilder.

Denna artikel demonstrerar hur man skapar, modifierar och hanterar masterbilder med hjälp av **Aspose.Slides for Python via Java**.

Installera paketet enligt beskrivningen i [Installation](/slides/sv/python-java/installation/). Varje exempel importerar `asposeslides` innan JVM startas, och importerar sedan API:n när JVM körs.

## **Lägg till en masterbild**

Detta exempel visar hur man skapar en ny masterbild genom att klona standardbilden. Den lägger sedan till en företagsnamnsbanner på alla bilder via layoutärvning.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    # Klona standardmasterbilden.
    default_master_slide = presentation.getMasters().get_Item(0)
    new_master_slide = presentation.getMasters().addClone(default_master_slide)

    # Lägg till en banner med företagsnamnet högst upp på masterbilden.
    text_box = new_master_slide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 720, 25)
    text_box.getTextFrame().setText("Company Name")
    paragraph = text_box.getTextFrame().getParagraphs().get_Item(0)
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    text_box.getFillFormat().setFillType(FillType.NoFill)

    # Tilldela den nya masterbilden till en layoutbild.
    layout_slide = presentation.getLayoutSlides().get_Item(0)
    layout_slide.setMasterSlide(new_master_slide)

    # Tilldela layoutbilden till den första bilden i presentationen.
    presentation.getSlides().get_Item(0).setLayoutSlide(layout_slide)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
Masterbilder ger ett sätt att applicera enhetligt varumärke eller delade designelement på alla bilder. Ändringar som görs i en master återges automatiskt på beroende layout- och normala bilder.
{{% /alert %}}

{{% alert color="info" title="Note" %}}
Former och formatering som läggs till i en masterbild ärvs av layoutbilder och i sin tur av alla normala bilder som använder dessa layouter. Bilden nedan illustrerar hur en textruta som lagts till i en masterbild automatiskt renderas på den slutgiltiga bilden.
{{% /alert %}}

![Exempel på masterärvning](master-slide-banner.png)

## **Åtkomst till en masterbild**

Du kan komma åt masterbilder via presentationens mastersamling. Detta exempel hämtar den första masterbilden och ändrar dess bakgrundstyp.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, Presentation

presentation = Presentation()
try:
    first_master_slide = presentation.getMasters().get_Item(0)
    first_master_slide.getBackground().setType(BackgroundType.OwnBackground)
finally:
    presentation.dispose()
```

## **Ta bort en masterbild**

En masterbild kan tas bort efter index eller genom referens när den inte längre används. Detta exempel tilldelar en klonad masterbild till presentationen och tar sedan bort den ursprungliga masterbilden efter index.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    default_master_slide = presentation.getMasters().get_Item(0)
    new_master_slide = presentation.getMasters().addClone(default_master_slide)

    layout_slide = presentation.getLayoutSlides().get_Item(0)
    layout_slide.setMasterSlide(new_master_slide)
    presentation.getSlides().get_Item(0).setLayoutSlide(layout_slide)

    # Ta bort den oanvända ursprungliga masterbilden efter index.
    presentation.getMasters().removeAt(0)

    # Alternativt, ta bort en oanvänd masterbild efter referens:
    # presentation.getMasters().remove(unused_master_slide)
finally:
    presentation.dispose()
```

## **Ta bort oanvända masterbilder**

Vissa presentationer innehåller masterbilder som inte används. Att ta bort dessa bilder kan hjälpa till att minska filstorleken.

```python
import jpime
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    default_master_slide = presentation.getMasters().get_Item(0)
    presentation.getMasters().addClone(default_master_slide)

    # Ta bort alla oanvända masterbilder, inklusive de som är markerade som Preserve.
    presentation.getMasters().removeUnused(True)
finally:
    presentation.dispose()
```