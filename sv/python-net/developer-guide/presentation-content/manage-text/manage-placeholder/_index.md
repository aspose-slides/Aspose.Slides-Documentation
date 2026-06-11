---
title: Hantera platshållare i presentationer med Python
linktitle: Hantera platshållare
type: docs
weight: 10
url: /sv/python-net/manage-placeholder/
keywords:
- platshållare
- textplatshållare
- bildplatshållare
- diagramplatshållare
- uppmaningstext
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Hantera enkelt platshållare i Aspose.Slides för Python via .NET: ersätt text, anpassa uppmaningar och ställ in bildtransparens i PowerPoint och OpenDocument."
---
## **Översikt**

Aspose.Slides låter dig hantera presentationsplatshållare programatiskt. Denna artikel förklarar hur du hittar platshållare på bilder och ändrar deras text, anger anpassad uppmaningstext för platshållarlayouter och justerar transparensen för en bild som används som bakgrund för en platshållare. Den innehåller också en kort FAQ som klargör skillnaden mellan basplatshållare och lokala former, förklarar hur platshållarändringar kan tillämpas via layouter eller master, och pekar på hantering av rubrik- och sidfotplatshållare.

## **Ändra text i platshållare**

Med Aspose.Slides för Python kan du hitta och ändra platshållare på bilder i en presentation. Aspose.Slides låter dig modifiera texten i en platshållare.

**Förutsättning:** Du behöver en presentation som innehåller en platshållare. Du kan skapa en sådan presentation i Microsoft PowerPoint.

Så här använder du Aspose.Slides för att ersätta texten i en platshållare:

1. Instansiera klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/) och skicka in presentationen som ett argument.
1. Hämta en referens till bilden med dess index.
1. Iterera genom formerna för att hitta platshållaren.
1. Ändra texten med hjälp av [TextFrame](https://reference.aspose.com/slides/sv/python-net/aspose.slides/textframe/) som är kopplad till [AutoShape](https://reference.aspose.com/slides/sv/python-net/aspose.slides/autoshape/).
1. Spara den modifierade presentationen.

Denna Python‑kod visar hur du ändrar texten i en platshållare:

```python
import aspose.slides as slides

# Instansiera Presentation-klassen.
with slides.Presentation("ReplacingText.pptx") as presentation:
    # Hämta den första bilden.
    slide = presentation.slides[0]

    # Iterera genom former för att hitta platshållare.
    for shape in slide.shapes:
        if shape.placeholder is not None:
            # Ändra texten i varje platshållare.
            shape.text_frame.text = "This is Placeholder"

    # Spara presentationen till disk.
    presentation.save("ReplacingText_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Ange uppmaningstext för en platshållare**

Standard‑ och förbyggda layouter innehåller uppmaningstext för platshållare, t.ex. **Klicka för att lägga till en rubrik** eller **Klicka för att lägga till en underrubrik**. Med Aspose.Slides kan du ersätta dessa uppmaningar med din egen text i platshållarlayouterna.

Följande Python‑exempel visar hur du anger uppmaningstexten för en platshållare:

```python
import aspose.slides as slides

with slides.Presentation("PromptText.pptx") as presentation:
    slide = presentation.slides[0]

    # Iterera genom former för att hitta platshållare.
    for shape in slide.slide.shapes:
        if shape.placeholder is not None and type(shape) is slides.AutoShape:
            if shape.placeholder.type == slides.PlaceholderType.CENTERED_TITLE:
                text = "Add Title"
            elif shape.placeholder.type == slides.PlaceholderType.SUBTITLE:
                text = "Add Subtitle"

            shape.text_frame.text = text
            print(f"Placeholder with text: {text}")

    presentation.save("PromptText_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Ange bildtransparens i en platshållare**

Aspose.Slides låter dig ställa in transparensen för en bakgrundsbild i en textplatshållare. Genom att justera bildens transparens i den ramen kan du låta antingen texten eller bilden framträda mer, beroende på deras färger.

Följande Python‑exempel visar hur du ställer in transparensen för en bildbakgrund i en form:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 100)
    auto_shape.fill_format.fill_type = slides.FillType.PICTURE

    with open("image.png", "rb") as image_stream:
        auto_shape.fill_format.picture_fill_format.picture.image = presentation.images.add_image(image_stream)
        auto_shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH
        auto_shape.fill_format.picture_fill_format.picture.image_transform.add_alpha_modulate_fixed_effect(75)
```

## **FAQ**

**Vad är en basplatshållare och hur skiljer den sig från en lokal form på en bild?**

En basplatshållare är den ursprungliga formen på en layout eller master som bildens form ärver från – typ, position och viss formatering kommer från den. En lokal form är självständig; om det inte finns någon basplatshållare gäller ingen arv.

**Hur kan jag uppdatera alla rubriker eller bildtexter i en presentation utan att iterera över varje bild?**

Redigera den motsvarande platshållaren på layouten eller masteren. Bilder som är baserade på dessa layouter/master kommer automatiskt att ärva ändringen.

**Hur styr jag de standardiserade rubrik-/sidfotplatshållarna – datum & tid, bildnummer och sidfotstext?**

Använd HeaderFooter‑hanterarna i lämplig omfattning (vanliga bilder, layouter, master, anteckningar/handouts) för att slå på eller av dessa platshållare och för att ange deras innehåll.