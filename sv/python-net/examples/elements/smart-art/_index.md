---
title: SmartArt
type: docs
weight: 140
url: /sv/python-net/examples/elements/smart-art/
keywords:
- SmartArt
- lägg till SmartArt
- åtkomst till SmartArt
- ta bort SmartArt
- SmartArt-layout
- kodexempel
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Bygg och redigera SmartArt i Python med Aspose.Slides: lägg till noder, ändra layouter och stilar, konvertera till former med precision, och exportera för PPT, PPTX och ODP."
---
Visar hur du lägger till SmartArt-grafik, får åtkomst till den, tar bort den och ändrar layouter med **Aspose.Slides for Python via .NET**.

## **Lägg till SmartArt**

Infoga en SmartArt-grafik med hjälp av en av de inbyggda layouterna.

```py
def add_smart_art():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        smart_art = slide.shapes.add_smart_art(50, 50, 400, 300, slides.smartart.SmartArtLayoutType.BASIC_PROCESS)

        presentation.save("smart_art.pptx", slides.export.SaveFormat.PPTX)
```

## **Åtkomst till SmartArt**

Hämta det första SmartArt-objektet på en bild.

```py
def access_smart_art():
    with slides.Presentation("smart_art.pptx") as presentation:
        slide = presentation.slides[0]

        # Åtkomst till den första SmartArt-formen.
        first_smart_art = next(shape for shape in slide.shapes if isinstance(shape, slides.smartart.SmartArt))
```

## **Ta bort SmartArt**

Radera en SmartArt-form från bilden.

```py
def remove_smart_art():
    with slides.Presentation("smart_art.pptx") as presentation:
        slide = presentation.slides[0]

        # Antag att den första formen är ett SmartArt-objekt.
        smart_art = slide.shapes[0]

        slide.shapes.remove(smart_art)

        presentation.save("smart_art_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Ändra SmartArt-layout**

Uppdatera layouttypen för en befintlig SmartArt-grafik.

```py
def change_smart_art_layout():
    with slides.Presentation("smart_art.pptx") as presentation:
        slide = presentation.slides[0]

        # Antag att den första formen är ett SmartArt-objekt.
        smart_art = slide.shapes[0]

        # Ändra SmartArt-layouten.
        smart_art.layout = slides.smartart.SmartArtLayoutType.VERTICAL_PICTURE_LIST

        presentation.save("smart_art_changed.pptx", slides.export.SaveFormat.PPTX)
```