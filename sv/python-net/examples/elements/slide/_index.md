---
title: Bild
type: docs
weight: 10
url: /sv/python-net/examples/elements/slide/
keywords:
- bild
- lägg till bild
- åtkomst till bild
- bildindex
- klona bild
- omordna bilder
- ta bort bild
- kodexempel
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Hantera bilder i Python med Aspose.Slides: skapa, klona, omordna, dölja, ställa in bakgrunder och storlek, tillämpa övergångar och exportera för PowerPoint och OpenDocument."
---
Den här artikeln innehåller en rad exempel som visar hur du arbetar med bilder med **Aspose.Slides for Python via .NET**. Du lär dig hur du lägger till, får åtkomst till, klonar, omordnar och tar bort bilder med `Presentation`-klassen.

Varje exempel nedan innehåller en kort förklaring följt av ett kodavsnitt i Python.

## **Lägg till en bild**

För att lägga till en ny bild måste du först välja en layout. I det här exemplet använder vi `Blank`-layouten och lägger till en tom bild i presentationen.

```py
def add_slide():
    with slides.Presentation() as presentation:
        # Varje bild baseras på en layout, som i sin tur baseras på en masterbild.
        # Använd Blank-layouten för att skapa en ny bild.
        blank_layout = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

        # Lägg till en ny tom bild med den valda layouten.
        presentation.slides.add_empty_slide(blank_layout)

        presentation.save("slide.pptx", slides.export.SaveFormat.PPTX)
```

> 💡 **Tips:** Varje bildlayout härrör från en masterbild, som definierar den övergripande designen och platshållarstrukturen. Bilden nedan visar hur masterbilder och deras tillhörande layouter är organiserade i PowerPoint.

![Relation mellan master och layout](master-layout-slide.png)

## **Åtkomst till bilder efter index**

Du kan komma åt bilder med deras index. Detta är användbart för att iterera igenom eller modifiera specifika bilder.

```py
def access_slide():
    with slides.Presentation("slide.pptx") as presentation:
        # Åtkomst till en bild efter index.
        first_slide = presentation.slides[0]
```

## **Klona en bild**

Det här exemplet visar hur du klonar en befintlig bild. Den klonade bilden läggs automatiskt till i slutet av bildsamlingen.

```py
def clone_slide():
    with slides.Presentation("slide.pptx") as presentation:
        slide = presentation.slides[0]

        # Klona bilden; den kommer att läggas till i slutet av presentationen.
        cloned_slide = presentation.slides.add_clone(slide)

        presentation.save("slide_cloned.pptx", slides.export.SaveFormat.PPTX)
```

## **Omordna bilder**

Du kan ändra ordningen på bilder genom att flytta en till ett nytt index. I det här fallet flyttar vi en bild till den första positionen.

```py
def reorder_slide():
    with slides.Presentation("slide.pptx") as presentation:
        slide = presentation.slides[1]

        # Flytta bilden till första positionen (övriga flyttas ner).
        presentation.slides.reorder(0, slide)

        presentation.save("slide_reordered.pptx", slides.export.SaveFormat.PPTX)
```

## **Ta bort en bild**

För att ta bort en bild refererar du helt enkelt till den och anropar `remove`. Detta exempel tar bort den första bilden.

```py
def remove_slide():
    with slides.Presentation("slide.pptx") as presentation:
        slide = presentation.slides[0]

        # Ta bort bilden.
        presentation.slides.remove(slide)

        presentation.save("slide_removed.pptx", slides.export.SaveFormat.PPTX)
```