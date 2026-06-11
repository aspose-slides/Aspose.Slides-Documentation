---
title: Textruta
type: docs
weight: 40
url: /sv/python-net/examples/elements/text-box/
keywords:
- textruta
- lägga till textruta
- åtkomst till textruta
- ta bort textruta
- kodexempel
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Skapa och formatera textrutor i Python med Aspose.Slides: ange teckensnitt, justering, radbrytning, autofit och länkar för att finjustera bilder för PowerPoint och OpenDocument."
---
I Aspose.Slides representeras en **textruta** av en `AutoShape`. Nästan alla former kan innehålla text, men en typisk textruta har ingen fyllning eller kant och visar bara text.

Den här guiden förklarar hur man lägger till, får åtkomst till och tar bort textrutor programatiskt.

## **Lägg till en textruta**

En textruta är helt enkelt en `AutoShape` utan fyllning eller kant och med någon formaterad text. Så här skapar du en:

```py
def add_text_box():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Skapa en rektangelform (standard är ifylld med kant och utan text).
        text_box = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 75, 150, 100)

        # Ta bort fyllning och kant för att få den att se ut som en vanlig textruta.
        text_box.fill_format.fill_type = slides.FillType.NO_FILL
        text_box.line_format.fill_format.fill_type = slides.FillType.NO_FILL

        # Ange textformatering.
        paragraph_format = text_box.text_frame.paragraphs[0].paragraph_format
        paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
        paragraph_format.default_portion_format.fill_format.solid_fill_color.color = drawing.Color.black

        # Tilldela det faktiska textinnehållet.
        text_box.text_frame.text = "Some text..."

        presentation.save("text_box.pptx", slides.export.SaveFormat.PPTX)
```

> 💡 **Obs:** Alla `AutoShape` som innehåller en icke‑tom `TextFrame` kan fungera som en textruta.

## **Få åtkomst till textrutor efter innehåll**

För att hitta alla textrutor som innehåller ett specifikt nyckelord (t.ex. "Slide") itererar du genom formerna och kontrollerar deras text:

```py
def access_text_box():
    with slides.Presentation("text_box.pptx") as presentation:
        slide = presentation.slides[0]

        for shape in slide.shapes:
            # Endast AutoShapes kan innehålla redigerbar text.
            if isinstance(shape, slides.AutoShape):
                if "Slide" in shape.text_frame.text:
                    # Gör något med den matchande textrutan.
                    pass
```

## **Ta bort textrutor efter innehåll**

Det här exemplet hittar och tar bort alla textrutor på den första bilden som innehåller ett specifikt nyckelord:

```py
def remove_text_boxes():
    with slides.Presentation("text_box.pptx") as presentation:
        slide = presentation.slides[0]

        # Hitta former att ta bort som är AutoShapes och innehåller ordet "Slide".
        shapes_to_remove = [
            shape for shape in slide.shapes
            if isinstance(shape, slides.AutoShape) and "Slide" in shape.text_frame.text
        ]

        # Ta bort varje matchande form från bilden.
        for shape in shapes_to_remove:
            slide.shapes.remove(shape)

        presentation.save("text_boxes_removed.pptx", slides.export.SaveFormat.PPTX)
```

> 💡 **Tips:** Skapa alltid en kopia av formsamlingen innan du modifierar den under iteration för att undvika fel vid ändring av samlingen.