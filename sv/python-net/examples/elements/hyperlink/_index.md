---
title: Hyperlänk
type: docs
weight: 130
url: /sv/python-net/examples/elements/hyperlink/
keywords:
- hyperlänk
- lägg till hyperlänk
- åtkomst till hyperlänk
- ta bort hyperlänk
- uppdatera hyperlänk
- kodexempel
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Lägg till, redigera och ta bort hyperlänkar i Python med Aspose.Slides: länka text, former, bilder, URL:er och e-post; ange mål och åtgärder för PPT, PPTX och ODP."
---
Visar hur man lägger till, får åtkomst till, tar bort och uppdaterar hyperlänkar på former med **Aspose.Slides for Python via .NET**.

## **Lägg till en hyperlänk**

Skapa en rektangelform med en hyperlänk som pekar på en extern webbplats.

```py
def add_hyperlink():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 50)
        shape.text_frame.text = "Aspose"

        text_portion = shape.text_frame.paragraphs[0].portions[0]
        text_portion.portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com")

        presentation.save("hyperlink.pptx", slides.export.SaveFormat.PPTX)
```

## **Åtkomst till en hyperlänk**

Läs hyperlänkinformation från en formes textdel.

```py
def access_hyperlink():
    with slides.Presentation("hyperlink.pptx") as presentation:
        slide = presentation.slides[0]
        shape = slide.shapes[0]

        text_portion = shape.text_frame.paragraphs[0].portions[0]
        hyperlink = text_portion.portion_format.hyperlink_click
```

## **Ta bort en hyperlänk**

Rensa hyperlänken från en formes text.

```py
def remove_hyperlink():
    with slides.Presentation("hyperlink.pptx") as presentation:
        slide = presentation.slides[0]
        shape = slide.shapes[0]

        text_portion = shape.text_frame.paragraphs[0].portions[0]
        text_portion.portion_format.hyperlink_click = None

        presentation.save("hyperlink_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Uppdatera en hyperlänk**

Ändra målet för en befintlig hyperlänk. Använd `HyperlinkManager` för att modifiera text som redan innehåller en hyperlänk, vilket efterliknar hur PowerPoint uppdaterar hyperlänkar på ett säkert sätt.

```py
def update_hyperlink():
    with slides.Presentation("hyperlink.pptx") as presentation:
        slide = presentation.slides[0]
        shape = slide.shapes[0]

        # Att ändra en hyperlänk i befintlig text bör göras via
        # HyperlinkManager snarare än att sätta egenskapen direkt.
        # Detta efterliknar hur PowerPoint säkert uppdaterar hyperlänkar.
        text_portion = shape.text_frame.paragraphs[0].portions[0]
        text_portion.portion_format.hyperlink_manager.set_external_hyperlink_click("https://new.example.com")

        presentation.save("hyperlink_updated.pptx", slides.export.SaveFormat.PPTX)
```