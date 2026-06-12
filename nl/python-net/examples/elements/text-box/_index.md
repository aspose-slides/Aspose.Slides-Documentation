---
title: Tekstvak
type: docs
weight: 40
url: /nl/python-net/examples/elements/text-box/
keywords:
- tekstvak
- tekstvak toevoegen
- tekstvak benaderen
- tekstvak verwijderen
- codevoorbeelden
- PowerPoint
- OpenDocument
- presentatie
- Python
- Aspose.Slides
description: "Maak en formatteer tekstvakken in Python met Aspose.Slides: stel lettertypen, uitlijning, regelafbreking, autofit en koppelingen in om dia's voor PowerPoint en OpenDocument te verfijnen."
---
In Aspose.Slides wordt een **tekstvak** weergegeven door een `AutoShape`. Bijna elke vorm kan tekst bevatten, maar een typisch tekstvak heeft geen vulling of rand en toont alleen tekst.

Deze gids legt uit hoe u programmatisch tekstvakken kunt toevoegen, benaderen en verwijderen.

## **Tekstvak toevoegen**

Een tekstvak is simpelweg een `AutoShape` zonder vulling of rand en met enige opgemaakte tekst. Zo maakt u er één:

```py
def add_text_box():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Maak een rechthoekige vorm (standaard gevuld met rand en zonder tekst).
        text_box = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 75, 150, 100)

        # Verwijder vulling en rand zodat het eruitziet als een typisch tekstvak.
        text_box.fill_format.fill_type = slides.FillType.NO_FILL
        text_box.line_format.fill_format.fill_type = slides.FillType.NO_FILL

        # Stel de tekstopmaak in.
        paragraph_format = text_box.text_frame.paragraphs[0].paragraph_format
        paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
        paragraph_format.default_portion_format.fill_format.solid_fill_color.color = drawing.Color.black

        # Wijs de eigenlijke tekstinhoud toe.
        text_box.text_frame.text = "Some text..."

        presentation.save("text_box.pptx", slides.export.SaveFormat.PPTX)
```

> 💡 **Opmerking:** Elke `AutoShape` die een niet-leeg `TextFrame` bevat, kan functioneren als een tekstvak.

## **Toegang tot tekstvakken op inhoud**

Om alle tekstvakken te vinden die een bepaald trefwoord bevatten (bijv. "Slide"), itereren we door de vormen en controleren we hun tekst:

```py
def access_text_box():
    with slides.Presentation("text_box.pptx") as presentation:
        slide = presentation.slides[0]

        for shape in slide.shapes:
            # Alleen AutoShapes kunnen bewerkbare tekst bevatten.
            if isinstance(shape, slides.AutoShape):
                if "Slide" in shape.text_frame.text:
                    # Doe iets met het overeenkomende tekstvak.
                    pass
```

## **Verwijder tekstvakken op inhoud**

Dit voorbeeld zoekt en verwijdert alle tekstvakken op de eerste dia die een specifiek trefwoord bevatten:

```py
def remove_text_boxes():
    with slides.Presentation("text_box.pptx") as presentation:
        slide = presentation.slides[0]

        # Zoek vormen om te verwijderen die AutoShapes zijn en het woord "Slide" bevatten.
        shapes_to_remove = [
            shape for shape in slide.shapes
            if isinstance(shape, slides.AutoShape) and "Slide" in shape.text_frame.text
        ]

        # Verwijder elke overeenkomende vorm van de dia.
        for shape in shapes_to_remove:
            slide.shapes.remove(shape)

        presentation.save("text_boxes_removed.pptx", slides.export.SaveFormat.PPTX)
```

> 💡 **Tip:** Maak altijd een kopie van de vormverzameling voordat u deze tijdens iteratie wijzigt om fouten door wijziging van de collectie te voorkomen.