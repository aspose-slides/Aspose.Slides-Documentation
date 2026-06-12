---
title: Hyperlink
type: docs
weight: 130
url: /nl/python-net/examples/elements/hyperlink/
keywords:
- hyperlink
- hyperlink toevoegen
- hyperlink benaderen
- hyperlink verwijderen
- hyperlink bijwerken
- codevoorbeelden
- PowerPoint
- OpenDocument
- presentatie
- Python
- Aspose.Slides
description: "Hyperlinks toevoegen, bewerken en verwijderen in Python met Aspose.Slides: linktekst, vormen, dia's, URL's en e-mail; doelstellingen en acties instellen voor PPT, PPTX en ODP."
---
Toont hoe hyperlinks toevoegen, benaderen, verwijderen en bijwerken op vormen met **Aspose.Slides for Python via .NET**.

## **Hyperlink toevoegen**

Maak een rechthoekvorm aan met een hyperlink die naar een externe website verwijst.

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

## **Hyperlink benaderen**

Lees hyperlink‑informatie uit een tekstgedeelte van een vorm.

```py
def access_hyperlink():
    with slides.Presentation("hyperlink.pptx") as presentation:
        slide = presentation.slides[0]
        shape = slide.shapes[0]

        text_portion = shape.text_frame.paragraphs[0].portions[0]
        hyperlink = text_portion.portion_format.hyperlink_click
```

## **Hyperlink verwijderen**

Verwijder de hyperlink uit de tekst van een vorm.

```py
def remove_hyperlink():
    with slides.Presentation("hyperlink.pptx") as presentation:
        slide = presentation.slides[0]
        shape = slide.shapes[0]

        text_portion = shape.text_frame.paragraphs[0].portions[0]
        text_portion.portion_format.hyperlink_click = None

        presentation.save("hyperlink_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Hyperlink bijwerken**

Wijzig het doel van een bestaande hyperlink. Gebruik `HyperlinkManager` om tekst die al een hyperlink bevat te wijzigen, hetgeen nabootst hoe PowerPoint hyperlinks veilig bijwerkt.

```py
def update_hyperlink():
    with slides.Presentation("hyperlink.pptx") as presentation:
        slide = presentation.slides[0]
        shape = slide.shapes[0]

        # Een hyperlink in bestaande tekst wijzigen moet gebeuren via
        # HyperlinkManager in plaats van de eigenschap direct in te stellen.
        # Dit bootst na hoe PowerPoint hyperlinks veilig bijwerkt.
        text_portion = shape.text_frame.paragraphs[0].portions[0]
        text_portion.portion_format.hyperlink_manager.set_external_hyperlink_click("https://new.example.com")

        presentation.save("hyperlink_updated.pptx", slides.export.SaveFormat.PPTX)
```