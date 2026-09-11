---
title: Grupppresentationformer i Python via Java
linktitle: Formgrupp
type: docs
weight: 40
url: /sv/python-java/group/
keywords:
- gruppform
- formgrupp
- lägg till grupp
- alternativ text
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Lär dig att gruppera och avgruppera former i PowerPoint-presentationer med Aspose.Slides för Python via Java - en steg-för-steg-guide med gratis Python-kod."
---
## **Översikt**

Denna artikel förklarar hur man arbetar med gruppformer i Aspose.Slides. Den visar hur man lägger till en gruppform på en bild, placerar former inuti den och sparar den uppdaterade presentationen. Den demonstrerar också hur man får åtkomst till former som lagras i en grupp och läser deras alternativa text med hjälp av [getAlternativeText](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shape/#getAlternativeText). Dessutom täcker artikeln kort relaterade gruppformfunktioner såsom nästlade grupper, z‑ordning och låsalternativ.

## **Lägg till en gruppform**

Aspose.Slides stöder arbete med gruppformer på bilder. Denna funktion hjälper utvecklare att skapa rikare presentationer. Aspose.Slides för Python via Java stöder att lägga till och komma åt gruppformer. Du kan fylla en gruppform med former eller komma åt dess egenskaper. Så här lägger du till en gruppform på en bild med Aspose.Slides för Python via Java:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/).
1. Hämta en referens till en bild genom dess index.
1. Lägg till en gruppform på bilden.
1. Lägg till former i gruppformen.
1. Spara den ändrade presentationen som en PPTX‑fil.

Exemplet nedan lägger till en gruppform på en bild:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, Presentation, SaveFormat, ShapeFrame, ShapeType

# Skapa en instans av Presentation-klassen.
presentation = Presentation()
try:
    # Hämta den första bilden.
    slide = presentation.getSlides().get_Item(0)

    # Kom åt bildens formsamling.
    slide_shapes = slide.getShapes()

    # Lägg till en gruppform på bilden.
    group_shape = slide_shapes.addGroupShape()

    # Lägg till former i gruppformen.
    group_shape.getShapes().addAutoShape(ShapeType.Rectangle, 300, 100, 100, 100)
    group_shape.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 100, 100)
    group_shape.getShapes().addAutoShape(ShapeType.Rectangle, 300, 300, 100, 100)
    group_shape.getShapes().addAutoShape(ShapeType.Rectangle, 500, 300, 100, 100)

    # Ställ in gruppformens ram.
    group_frame = ShapeFrame(100, 300, 500, 40, NullableBool.False_, NullableBool.False_, 0)
    group_shape.setFrame(group_frame)

    # Skriv PPTX-filen till disk.
    presentation.save("GroupShape.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Åtkomst till alternativ text**

Detta avsnitt visar hur man kommer åt den alternativa texten för former i en grupp på en bild. Så här får du åtkomst till denna text med Aspose.Slides för Python via Java:

1. Instansiera klassen [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/) som representerar en PPTX‑fil.
1. Hämta en referens till en bild genom dess index.
1. Kom åt bildens formsamling.
1. Kom åt gruppformen.
1. Läs den alternativa texten för dess former med hjälp av [getAlternativeText](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shape/#getAlternativeText).

Exemplet nedan får åtkomst till den alternativa texten för former i en grupp:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import GroupShape, Presentation

# Skapa en instans av Presentation-klassen som representerar PPTX-filen.
presentation = Presentation("AltText.pptx")
try:
    # Hämta den första bilden.
    slide = presentation.getSlides().get_Item(0)

    for i in range(slide.getShapes().size()):
        # Kom åt en form i bildens formsamling.
        shape = slide.getShapes().get_Item(i)

        if isinstance(shape, GroupShape):
            # Kom åt formerna i gruppen.
            for j in range(shape.getShapes().size()):
                child_shape = shape.getShapes().get_Item(j)

                # Läs den alternativa texten.
                print(child_shape.getAlternativeText())
finally:
    presentation.dispose()
```

## **FAQ**

**Stöds nästlad gruppering (en grupp i en grupp)?**

Ja. [GroupShape](https://reference.aspose.com/slides/sv/python-java/aspose.slides/groupshape/) har en [getParentGroup](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shape/#getParentGroup) metod, som indikerar stöd för hierarki: en grupp kan vara ett underordnat element till en annan grupp.

**Hur styr jag gruppens z‑ordning i förhållande till andra objekt på bilden?**

Använd [GroupShape](https://reference.aspose.com/slides/sv/python-java/aspose.slides/groupshape/)‑objektets [getZOrderPosition](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shape/#getZOrderPosition) metod för att inspektera dess position i visningsstacken.

**Kan jag förhindra att flytta, redigera eller avgruppera?**

Ja. Gruppens lås exponeras via [getGroupShapeLock](https://reference.aspose.com/slides/sv/python-java/aspose.slides/groupshape/#getGroupShapeLock), vilket låter dig begränsa operationer på objektet.