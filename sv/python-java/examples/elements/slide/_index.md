---
title: Bild
type: docs
weight: 10
url: /sv/python-java/examples/elements/slide/
keywords:
- kodexempel
- bild
- PowerPoint
- OpenDocument
- presentation
- Python
- Java
- Aspose.Slides
description: "Hantera bilder i Aspose.Slides för Python via Java: lägg till, få åtkomst till, klona, ändra ordning och ta bort bilder med Python kodexempel för PowerPoint och OpenDocument presentationer."
---
Denna artikel innehåller exempel som visar hur man lägger till, får åtkomst till, klonar, ordnar om och tar bort bilder med **Aspose.Slides for Python via Java**.

Installera paketet enligt beskrivningen i [Installation](/slides/sv/python-java/installation/). Varje exempel importerar `asposeslides` innan JVM startas, och importerar sedan API:t efter att JVM körs.

## **Lägg till en bild**

För att lägga till en ny bild, välj först en layout. Detta exempel använder en tom layout för att lägga till en tom bild i presentationen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideLayoutType

presentation = Presentation()
try:
    blank_layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)

    presentation.getSlides().addEmptySlide(blank_layout)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
Varje bildlayout härstammar från en huvudbild, som definierar den övergripande designen och platshållarstrukturen. Bilden nedan visar hur huvudbilder och deras tillhörande layouter är organiserade i PowerPoint.
{{% /alert %}}

![Relation mellan huvudbild och layout](master-layout-slide.png)

## **Åtkomst till bilder via index**

Få åtkomst till bilder med deras nollbaserade index, eller hitta en bilds index baserat på en referens. Detta är användbart för att iterera igenom eller modifiera specifika bilder.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideLayoutType

presentation = Presentation()
try:
    # Lägg till en annan tom bild.
    blank_layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)
    presentation.getSlides().addEmptySlide(blank_layout)

    # Få åtkomst till bilder via index.
    first_slide = presentation.getSlides().get_Item(0)
    second_slide = presentation.getSlides().get_Item(1)

    # Hämta en bilds index från en referens och få sedan åtkomst till den via index.
    second_slide_index = presentation.getSlides().indexOf(second_slide)
    second_slide_by_index = presentation.getSlides().get_Item(second_slide_index)
finally:
    presentation.dispose()
```

## **Klona en bild**

Klona en befintlig bild. Den klonade bilden läggs automatiskt till i slutet av bildsamlingen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)

    cloned_slide = presentation.getSlides().addClone(first_slide)

    cloned_slide_index = presentation.getSlides().indexOf(cloned_slide)
finally:
    presentation.dispose()
```

## **Ordna om bilder**

Ändra ordningen på bilder genom att flytta en till ett nytt index. Detta exempel flyttar en klonad bild till den första positionen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)

    cloned_slide = presentation.getSlides().addClone(first_slide)

    presentation.getSlides().reorder(0, cloned_slide)
finally:
    presentation.dispose()
```

## **Ta bort en bild**

Ta bort en bild genom att skicka dess referens till bildsamlingen. Detta exempel lägger till en andra bild och tar sedan bort den ursprungliga, så att endast den nya kvarstår.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideLayoutType

presentation = Presentation()
try:
    blank_layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)
    second_slide = presentation.getSlides().addEmptySlide(blank_layout)

    first_slide = presentation.getSlides().get_Item(0)
    presentation.getSlides().remove(first_slide)
finally:
    presentation.dispose()
```