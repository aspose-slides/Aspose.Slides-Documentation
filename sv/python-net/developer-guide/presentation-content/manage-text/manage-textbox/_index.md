---
title: Hantera textrutor i presentationer med Python
linktitle: Hantera textruta
type: docs
weight: 20
url: /sv/python-net/manage-textbox/
keywords:
- textruta
- textram
- lägga till text
- uppdatera text
- skapa textruta
- kontrollera textruta
- lägga till textkolumn
- lägga till hyperlänk
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Aspose.Slides för Python via .NET gör det enkelt att skapa, redigera och klona textrutor i PowerPoint- och OpenDocument-filer, vilket förbättrar din presentationsautomatisering."
---
## **Introduktion**

Texter på bilder finns vanligtvis i textrutor eller former. Därför måste du, för att lägga till text på en bild, lägga till en textruta och sedan placera någon text i textrutan. Aspose.Slides för Python tillhandahåller klassen [AutoShape](https://reference.aspose.com/slides/sv/python-net/aspose.slides/autoshape/) som låter dig lägga till en form som innehåller text.

{{% alert title="Info" color="info" %}}
Aspose.Slides tillhandahåller också klassen [Shape](https://reference.aspose.com/slides/sv/python-net/aspose.slides/shape/). Men inte alla former kan innehålla text.
{{% /alert %}}

{{% alert title="Note" color="warning" %}}
Därför, när du arbetar med en form som du vill lägga till text i, kan du vilja kontrollera och bekräfta att den har kastats via klassen [AutoShape](https://reference.aspose.com/slides/sv/python-net/aspose.slides/autoshape/). Endast då kan du arbeta med [TextFrame](https://reference.aspose.com/slides/sv/python-net/aspose.slides/textframe/), som är en egenskap under [AutoShape](https://reference.aspose.com/slides/sv/python-net/aspose.slides/autoshape/). Se avsnittet [Update Text](/slides/sv/python-net/manage-textbox/#update-text) på den här sidan.
{{% /alert %}}

## **Skapa textrutor på bilder**

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/).
2. Hämta en referens till den första bilden.
3. Lägg till en [AutoShape](https://reference.aspose.com/slides/sv/python-net/aspose.slides/autoshape/) med `ShapeType.RECTANGLE` på önskad position på bilden.
4. Ställ in texten i formens [TextFrame](https://reference.aspose.com/slides/sv/python-net/aspose.slides/textframe/).
5. Spara presentationen som en PPTX‑fil.

Följande Python‑exempel implementerar dessa steg:

```py
import aspose.slides as slides

# Instansiera Presentation-klassen.
with slides.Presentation() as presentation:

    # Hämta den första bilden i presentationen.
    slide = presentation.slides[0]

    # Lägg till en AutoShape av typen RECTANGLE.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 150, 50)

    shape.text_frame.text = "Aspose TextBox"

    # Spara presentationen till disk.
    presentation.save("TextBox.pptx", slides.export.SaveFormat.PPTX)
```

## **Kontrollera om en form är en textruta**

Aspose.Slides tillhandahåller egenskapen [is_text_box](https://reference.aspose.com/slides/sv/python-net/aspose.slides/autoshape/is_text_box/) på klassen [AutoShape](https://reference.aspose.com/slides/sv/python-net/aspose.slides/autoshape/), vilket låter dig avgöra om en form är en textruta.

![Textruta och form](istextbox.png)

Detta Python‑exempel visar hur du kontrollerar om en form skapades som en textruta:

```python
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if isinstance(shape, slides.AutoShape):
                print("shape is a text box" if shape.is_text_box else "shape is not a text box")
```

Observera att om du lägger till en [AutoShape](https://reference.aspose.com/slides/sv/python-net/aspose.slides/autoshape/) med hjälp av klassen [ShapeCollection](https://reference.aspose.com/slides/sv/python-net/aspose.slides/shapecollection/), returnerar formens `is_text_box`‑egenskap `False`. Efter att du har lagt till text—antingen med metoden `add_text_frame` eller genom att sätta `text`‑egenskapen—returnerar `is_text_box` `True`.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 40)
    # shape1.is_text_box är falskt
    shape1.add_text_frame("shape 1")
    # shape1.is_text_box är sant

    shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 110, 100, 40)
    # shape2.is_text_box är falskt
    shape2.text_frame.text = "shape 2"
    # shape2.is_text_box är sant

    shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 210, 100, 40)
    # shape3.is_text_box är falskt
    shape3.add_text_frame("")
    # shape3.is_text_box är falskt

    shape4 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 310, 100, 40)
    # shape4.is_text_box är falskt
    shape4.text_frame.text = ""
    # shape4.is_text_box är falskt
```

## **Lägg till kolumner i textrutor**

Aspose.Slides tillhandahåller egenskaperna [column_count](https://reference.aspose.com/slides/sv/python-net/aspose.slides/textframeformat/column_count/) och [column_spacing](https://reference.aspose.com/slides/sv/python-net/aspose.slides/textframeformat/column_spacing/) på klassen [TextFrameFormat](https://reference.aspose.com/slides/sv/python-net/aspose.slides/textframeformat/) för att lägga till kolumner i textrutor. Du kan ange antalet kolumner och ställa in avståndet (i punkter) mellan kolumnerna.

Följande Python‑kod demonstrerar denna operation:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:

	# Hämta den första bilden i presentationen.
	slide = presentation.slides[0]

	# Lägg till en AutoShape av typen RECTANGLE.
	shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 300, 300)

	# Lägg till en TextFrame i rektangeln.
	shape.add_text_frame("All of these columns are confined to a single text container—" +
	"you can add or delete text, and any new or remaining text automatically reflows " +
	"within the container. You cannot have text flow from one container to another, " +
	"though—PowerPoint’s column options for text are limited!")

	# Hämta textformatet för TextFrame.
	format = shape.text_frame.text_frame_format

	# Ange antalet kolumner i TextFrame.
	format.column_count = 3

	# Ange avståndet mellan kolumnerna.
	format.column_spacing = 10

	# Spara presentationen.
	presentation.save("ColumnCount.pptx", slides.export.SaveFormat.PPTX)
```

## **Uppdatera text**

Aspose.Slides låter dig uppdatera texten i en enskild textruta eller i hela presentationen.

Följande Python‑exempel visar hur du uppdaterar all text i en presentation:

```py
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if type(shape) is slides.AutoShape:
                for paragraph in shape.text_frame.paragraphs:
                    for portion in paragraph.portions:
                        portion.text = portion.text.replace("years", "months")
                        portion.portion_format.font_bold = 1
  
    # Spara den ändrade presentationen.
    presentation.save("TextChanged.pptx", slides.export.SaveFormat.PPTX)
```

## **Lägg till textrutor med hyperlänkar** 

Du kan infoga en länk i en textruta. När textrutan klickas öppnas länken.

För att lägga till en textruta som innehåller en hyperlänk, följ dessa steg:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/).
2. Hämta en referens till den första bilden.
3. Lägg till en [AutoShape](https://reference.aspose.com/slides/sv/python-net/aspose.slides/autoshape/) med `ShapeType.RECTANGLE` på önskad position på bilden.
4. Ställ in texten i formens [TextFrame](https://reference.aspose.com/slides/sv/python-net/aspose.slides/textframe/).
5. Hämta en referens till [HyperlinkManager](https://reference.aspose.com/slides/sv/python-net/aspose.slides/hyperlinkmanager/).
6. Använd egenskapen `hyperlink_manager` för att ange en extern klick‑hyperlänk.
7. Spara presentationen som en PPTX‑fil.

Detta Python‑exempel visar hur du lägger till en textruta med en hyperlänk på en bild:

```py
import aspose.slides as slides

# Instansiera Presentation-klassen.
with slides.Presentation() as presentation:

    # Hämta den första bilden i presentationen.
    slide = presentation.slides[0]

    # Lägg till en AutoShape av typen RECTANGLE.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 150, 150, 50)

    text_portion = shape.text_frame.paragraphs[0].portions[0]

    # Lägg till text i ramen.
    text_portion.text = "Aspose.Slides"

    # Ange en hyperlänk för portions‑texten.
    hyperlink_manager = text_portion.portion_format.hyperlink_manager
    hyperlink_manager.set_external_hyperlink_click("http://www.aspose.com")

    # Spara presentationen som en PPTX‑fil.
    presentation.save("Hyperlink.pptx", slides.export.SaveFormat.PPTX)
```

## **Vanliga frågor**

**Vad är skillnaden mellan en textruta och en textplatshållare när du arbetar med masterslides?**

En [placeholder](/slides/sv/python-net/manage-placeholder/) ärver stil/position från [master](https://reference.aspose.com/slides/sv/python-net/aspose.slides/masterslide/) och kan åsidosättas på [layouts](https://reference.aspose.com/slides/sv/python-net/aspose.slides/layoutslide/), medan en vanlig textruta är ett självständigt objekt på en specifik bild och förändras inte när du byter layout.

**Hur kan jag utföra en massändring av text i hela presentationen utan att påverka text i diagram, tabeller och SmartArt?**

Begränsa din iteration till auto‑former som har textramar och uteslut inbäddade objekt ([charts](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/chart/), [tables](https://reference.aspose.com/slides/sv/python-net/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/sv/python-net/aspose.slides.smartart/smartart/)) genom att gå igenom deras samlingar separat eller hoppa över dessa objekttyper.