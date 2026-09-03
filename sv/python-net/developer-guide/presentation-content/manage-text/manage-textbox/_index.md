---
title: Hantera textrutor i presentationer med Python
linktitle: Hantera textruta
type: docs
weight: 20
url: /sv/python-net/manage-textbox/
keywords:
- textruta
- textram
- lägg till text
- uppdatera text
- skapa textruta
- kontrollera textruta
- lägg till textkolumn
- lägg till hyperlänk
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Skapa, identifiera, formatera och uppdatera textrutor i PowerPoint- och OpenDocument-presentationer med Aspose.Slides för Python via .NET."
---
## **Introduktion**

I Aspose.Slides för Python via .NET lagras bildtext i textramar som tillhör former. Klassen [AutoShape](https://reference.aspose.com/slides/sv/python-net/aspose.slides/autoshape/) representerar den vanligaste textbärande formen och exponerar dess text via egenskapen [AutoShape.text_frame](https://reference.aspose.com/slides/sv/python-net/aspose.slides/autoshape/text_frame/).

{{% alert color="info" title="Note" %}}
Varje autoform ärver från [Shape](https://reference.aspose.com/slides/sv/python-net/aspose.slides/shape/), men inte varje form är en autoform eller stöder en textram. När du bearbetar en befintlig presentation, använd `isinstance(shape, slides.AutoShape)` för att kontrollera formens typ innan du får åtkomst till dess text.
{{% /alert %}}

## **Skapa en textruta på en bild**

För att skapa en textruta, lägg till en autoform på en bild, lägg till text i dess textram och spara presentationen. Följande exempel skapar en rektangulär textruta:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    text_box = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 300, 50)
    text_box.add_text_frame("Aspose TextBox")

    presentation.save("TextBox.pptx", slides.export.SaveFormat.PPTX)
```

Koordinaterna och dimensionerna som skickas till [ShapeCollection.add_auto_shape](https://reference.aspose.com/slides/sv/python-net/aspose.slides/shapecollection/add_auto_shape/) mäts i punkter. [AutoShape.add_text_frame](https://reference.aspose.com/slides/sv/python-net/aspose.slides/autoshape/add_text_frame/) initierar textramen med den angivna texten.

## **Kontrollera om en form är en textruta**

Använd egenskapen [AutoShape.is_text_box](https://reference.aspose.com/slides/sv/python-net/aspose.slides/autoshape/is_text_box/) för att avgöra om en autoform behandlas som en textruta. Detta är användbart när en presentation innehåller både textbärande och enbart grafiska autoformer.

![En textruta och en form](istextbox.png)

Följande exempel granskar varje autoform i en presentation:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    text_box = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 120, 40)
    text_box.add_text_frame("Text box")
    slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 150, 10, 40, 40)

    for current_slide in presentation.slides:
        for shape in current_slide.shapes:
            if isinstance(shape, slides.AutoShape):
                print("The shape is a text box." if shape.is_text_box else "The shape is not a text box.")
```

En nyinlagd autoform betraktas inte som en textruta förrän den innehåller icke-tom text. Du kan tillhandahålla den texten via [AutoShape.add_text_frame](https://reference.aspose.com/slides/sv/python-net/aspose.slides/autoshape/add_text_frame/) eller [TextFrame.text](https://reference.aspose.com/slides/sv/python-net/aspose.slides/textframe/text/). Att lägga till eller tilldela en tom sträng sätter is_text_box till `False`:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 40)
    shape1.add_text_frame("Shape 1")
    print(shape1.is_text_box)

    shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 70, 100, 40)
    shape2.text_frame.text = "Shape 2"
    print(shape2.is_text_box)

    shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 130, 100, 40)
    shape3.add_text_frame("")
    print(shape3.is_text_box)

    shape4 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 190, 100, 40)
    shape4.text_frame.text = ""
    print(shape4.is_text_box)
```

De två första anropen skriver ut `True`; de två sista skriver ut `False`.

## **Hitta formen som äger en textram**

Generisk textbearbetningskod kan få en [TextFrame](https://reference.aspose.com/slides/sv/python-net/aspose.slides/textframe/) utan att veta vilket presentationsobjekt som innehåller den. Använd den skrivskyddade egenskapen [TextFrame.parent_shape](https://reference.aspose.com/slides/sv/python-net/aspose.slides/textframe/parent_shape/) för att navigera tillbaka till den ägande [Shape](https://reference.aspose.com/slides/sv/python-net/aspose.slides/shape/).

För en textram som ägs av en autoform eller en annan textbärande form, innehåller parent_shape ägaren och [TextFrame.parent_cell](https://reference.aspose.com/slides/sv/python-net/aspose.slides/textframe/parent_cell/) är `None`. Kontrollera det returnerade värdet innan du kommer åt det. För att identifiera både form- och tabellcellsägare, inklusive former kopplade till SmartArt‑noder, se [Search and Replace Text](/slides/sv/python-net/search-and-replace-text/).

## **Lägg till kolumner i en textruta**

Egenskapen [TextFrameFormat.column_count](https://reference.aspose.com/slides/sv/python-net/aspose.slides/textframeformat/column_count/) delar textramen i kolumner, medan [TextFrameFormat.column_spacing](https://reference.aspose.com/slides/sv/python-net/aspose.slides/textframeformat/column_spacing/) anger avståndet mellan kolumner i punkter. Båda inställningarna tillhör [TextFrameFormat](https://reference.aspose.com/slides/sv/python-net/aspose.slides/textframeformat/) och kan ändras via textramen i en befintlig textruta. Text flödar om mellan kolumner inom samma form; den fortsätter inte i en annan form.

Följande exempel skapar en tre‑kolumners textruta med 10 punkter mellan kolumnerna, sparar presentationen och läser de lagrade inställningarna från utdatafilen:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    text_box = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 300, 200)
    text_box.add_text_frame("This text is distributed automatically across all columns in the text box.")

    text_frame_format = text_box.text_frame.text_frame_format
    text_frame_format.column_count = 3
    text_frame_format.column_spacing = 10

    presentation.save("TextBoxColumns.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("TextBoxColumns.pptx") as saved_presentation:
    saved_text_box = saved_presentation.slides[0].shapes[0]
    if isinstance(saved_text_box, slides.AutoShape):
        saved_format = saved_text_box.text_frame.text_frame_format
        print(f"Columns: {saved_format.column_count}; spacing: {saved_format.column_spacing} points")
```

## **Extrahera text från enskilda kolumner**

Använd [TextFrame.split_text_by_columns](https://reference.aspose.com/slides/sv/python-net/aspose.slides/textframe/split_text_by_columns/) för att hämta texten som tilldelats varje visuell kolumn i en befintlig textram. Metoden returnerar en sträng för varje kolumn, i kolumnbaserad läsordning. En enkalkolumns‑textram ger en lista med ett element, och en tom kolumn representeras av en tom sträng. Strängarna innehåller endast vanlig text; formatering på portionsnivå bevaras inte.

Detta är användbart när du behöver:

- Extrahera text samtidigt som dess kolumnbaserade läsordning bevaras.
- Indexera eller jämföra innehållet i flerkolumns‑bilder.
- Exportera varje kolumn till en separat fil, databassfält eller annan destination.
- Inspektera hur text omfördelas efter att ha ändrat [TextFrameFormat.column_count](https://reference.aspose.com/slides/sv/python-net/aspose.slides/textframeformat/column_count/), [TextFrameFormat.column_spacing](https://reference.aspose.com/slides/sv/python-net/aspose.slides/textframeformat/column_spacing/), teckensnittet eller storleken på textramen.

Metoden rapporterar texten som fördelas inom den aktuella [TextFrame](https://reference.aspose.com/slides/sv/python-net/aspose.slides/textframe/); den flödar inte automatiskt text mellan separata former eller textrutor. Kolumnfördelning kan bero på tillgängliga teckensnitt och andra textlayout‑inställningar, så se till att de nödvändiga teckensnitten finns tillgängliga när konsekventa resultat är viktiga.

Följande exempel läser in en presentation, hittar den första flerkolumns‑autoformen med en textram, läser dess konfigurerade kolumnantal och skriver texten från varje kolumn till en separat fil. Former som inte ger en textram hoppas över.

```python
import aspose.slides as slides

with slides.Presentation("MultiColumnText.pptx") as presentation:
    text_box = None
    for shape in presentation.slides[0].shapes:
        if isinstance(shape, slides.AutoShape) and shape.text_frame is not None:
            column_count = shape.text_frame.text_frame_format.column_count
            if column_count > 1:
                text_box = shape
                break

    if text_box is None:
        print("No multi-column text frame was found.")
    else:
        text_frame = text_box.text_frame
        configured_column_count = text_frame.text_frame_format.column_count
        column_texts = text_frame.split_text_by_columns()

        print(f"Configured columns: {configured_column_count}")

        for column_number, column_text in enumerate(column_texts, start=1):
            print(f"Column {column_number}: {column_text}")
            with open(f"Column-{column_number}.txt", "w", encoding="utf-8") as column_file:
                column_file.write(column_text)
```

## **Uppdatera text**

För att uppdatera text i hela en presentation, iterera genom bilderna och formerna, välj autoformer och redigera sedan deras textdelar. Att arbeta på delningsnivå låter dig ändra både text och teckenformatering.

Följande exempel ersätter varje förekomst av `years` med `months` i autoformens text och gör varje påverkad del fetstil:

```python
import aspose.slides as slides

with slides.Presentation("Text.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if not isinstance(shape, slides.AutoShape) or shape.text_frame is None:
                continue

            for paragraph in shape.text_frame.paragraphs:
                for portion in paragraph.portions:
                    if "years" in portion.text:
                        portion.text = portion.text.replace("years", "months")
                        portion.portion_format.font_bold = slides.NullableBool.TRUE

    presentation.save("TextChanged.pptx", slides.export.SaveFormat.PPTX)
```

Denna genomgång uppdaterar enbart text i autoformer. Text lagrad i tabeller, diagram, SmartArt eller grupperade former kräver genomgång av dessa objekts egna samlingar.

## **Lägg till en textruta med hyperlänk**

En hyperlänk kan tilldelas en specifik textdel, så att endast den texten fungerar som den klickbara länken. Använd [HyperlinkManager.set_external_hyperlink_click](https://reference.aspose.com/slides/sv/python-net/aspose.slides/hyperlinkmanager/set_external_hyperlink_click/) för att koppla delen till en extern URL.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    text_box = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 150, 200, 50)
    text_box.add_text_frame("Aspose.Slides")

    text_portion = text_box.text_frame.paragraphs[0].portions[0]
    text_portion.portion_format.hyperlink_manager.set_external_hyperlink_click("https://www.aspose.com/")

    presentation.save("Hyperlink.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Vad är skillnaden mellan en textruta och en textplatshållare på en master- eller layoutbild?**

En [placeholder](/slides/sv/python-net/manage-placeholder/) kan ärva sin position och formatering från en [master slide](https://reference.aspose.com/slides/sv/python-net/aspose.slides/masterslide/) eller [layout slide](https://reference.aspose.com/slides/sv/python-net/aspose.slides/layoutslide/). En vanlig textruta är en självständig form på den bild där den skapades och får inte placeholder‑beteende när layouten ändras.

**Hur kan jag ersätta text utan att ändra text i diagram, tabeller eller SmartArt?**

Begränsa genomgången till [AutoShape](https://reference.aspose.com/slides/sv/python-net/aspose.slides/autoshape/)‑instanser, som visas i uppdateringstext‑exemplet. Diagram, tabeller och SmartArt lagrar text i sina egna objektsmodeller, så de ändras inte av den loopen.