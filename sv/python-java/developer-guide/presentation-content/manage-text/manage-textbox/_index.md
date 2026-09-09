---
title: "Hantera textrutor i presentationer med Python via Java"
linktitle: "Hantera textruta"
type: docs
weight: 20
url: /sv/python-java/manage-textbox/
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
- Java
- Aspose.Slides
description: "Skapa, identifiera, formatera och uppdatera textrutor i PowerPoint- och OpenDocument-presentationer med Aspose.Slides för Python via Java."
---
## **Introduktion**

I Aspose.Slides för Python via Java lagras bildtext i textramar som tillhör former. Klassen [AutoShape](https://reference.aspose.com/slides/sv/python-java/aspose.slides/autoshape/) representerar den vanligaste textbärande formen och exponerar dess text via metoden [AutoShape.getTextFrame](https://reference.aspose.com/slides/sv/python-java/aspose.slides/autoshape/#getTextFrame).

{{% alert color="info" title="Obs" %}}
Varje autoform ärver från [Shape](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shape/), men inte varje form är en autoform eller stödjer en textram. När du bearbetar en befintlig presentation, kontrollera att en form är en instans av [AutoShape](https://reference.aspose.com/slides/sv/python-java/aspose.slides/autoshape/) innan du kommer åt dess text.
{{% /alert %}}

## **Skapa en textruta på en bild**

För att skapa en textruta, lägg till en autoform på en bild, lägg till text i dess textram och spara presentationen. Följande exempel skapar en rektangulär textruta:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 300, 50)
    text_box.addTextFrame("Aspose TextBox")

    presentation.save("TextBox.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Koordinaterna och dimensionerna som skickas till [ShapeCollection.addAutoShape](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shapecollection/#addAutoShape) mäts i punkter. [AutoShape.addTextFrame](https://reference.aspose.com/slides/sv/python-java/aspose.slides/autoshape/#addTextFrame) initierar textramen med den angivna texten.

## **Kontrollera om en form är en textruta**

Använd metoden [AutoShape.isTextBox](https://reference.aspose.com/slides/sv/python-java/aspose.slides/autoshape/#isTextBox) för att avgöra om en autoform behandlas som en textruta. Detta är användbart när en presentation innehåller både textbärande och enbart grafiska autoformer.

![En textruta och en form](istextbox.png)

Följande exempel inspekterar varje autoform i en presentation:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 120, 40)
    text_box.addTextFrame("Text box")
    slide.getShapes().addAutoShape(ShapeType.Ellipse, 150, 10, 40, 40)

    for current_slide in presentation.getSlides():
        for shape in current_slide.getShapes():
            if isinstance(shape, AutoShape):
                print("The shape is a text box." if shape.isTextBox() else "The shape is not a text box.")
finally:
    presentation.dispose()
```

En nyupplagd autoform betraktas inte som en textruta förrän den innehåller icke‑tom text. Du kan tillhandahålla den texten via [AutoShape.addTextFrame](https://reference.aspose.com/slides/sv/python-java/aspose.slides/autoshape/#addTextFrame) eller [TextFrame.setText](https://reference.aspose.com/slides/sv/python-java/aspose.slides/textframe/#setText). Att lägga till eller tilldela en tom sträng gör så att [AutoShape.isTextBox](https://reference.aspose.com/slides/sv/python-java/aspose.slides/autoshape/#isTextBox) returnerar `False`:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    added_text_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 40)
    added_text_shape.addTextFrame("Shape 1")
    print(added_text_shape.isTextBox())

    assigned_text_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 70, 100, 40)
    assigned_text_shape.getTextFrame().setText("Shape 2")
    print(assigned_text_shape.isTextBox())

    added_empty_text_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 130, 100, 40)
    added_empty_text_shape.addTextFrame("")
    print(added_empty_text_shape.isTextBox())

    assigned_empty_text_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 190, 100, 40)
    assigned_empty_text_shape.getTextFrame().setText("")
    print(assigned_empty_text_shape.isTextBox())
finally:
    presentation.dispose()
```

De två första anropen skriver ut `True`; de två sista skriver ut `False`.

## **Hitta formen som äger en textram**

Generisk textbearbetningskod kan få en [TextFrame](https://reference.aspose.com/slides/sv/python-java/aspose.slides/textframe/) utan att veta vilket presentationsobjekt som innehåller den. Använd den skrivskyddade metoden [TextFrame.getParentShape](https://reference.aspose.com/slides/sv/python-java/aspose.slides/textframe/#getParentShape) för att navigera tillbaka till dess ägande [Shape](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shape/).

För en textram som ägs av en autoform eller en annan textbärande form returnerar [TextFrame.getParentShape](https://reference.aspose.com/slides/sv/python-java/aspose.slides/textframe/#getParentShape) ägaren och [TextFrame.getParentCell](https://reference.aspose.com/slides/sv/python-java/aspose.slides/textframe/#getParentCell) returnerar `None`. Kontrollera det returnerade värdet innan du kommer åt det. För att identifiera både form‑ och tabellcell‑ägare, inklusive former som är kopplade till SmartArt‑noder, se [Sök och ersätt text](/slides/sv/python-java/search-and-replace-text/).

## **Lägg till kolumner i en textruta**

Metoden [TextFrameFormat.setColumnCount](https://reference.aspose.com/slides/sv/python-java/aspose.slides/textframeformat/#setColumnCount) delar textramen i kolumner, medan [TextFrameFormat.setColumnSpacing](https://reference.aspose.com/slides/sv/python-java/aspose.slides/textframeformat/#setColumnSpacing) sätter avståndet mellan kolumnerna i punkter. Båda inställningarna tillhör [TextFrameFormat](https://reference.aspose.com/slides/sv/python-java/aspose.slides/textframeformat/) och kan ändras via textramen i en befintlig textruta. Text flödar om mellan kolumner inom samma form; den fortsätter inte i en annan form.

Följande exempel skapar en textruta med tre kolumner och 10 punkters mellanrum, sparar presentationen och läser tillbaka de lagrade inställningarna från utskriftsfilen:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 200)
    text_box.addTextFrame("This text is distributed automatically across all columns in the text box.")

    text_frame_format = text_box.getTextFrame().getTextFrameFormat()
    text_frame_format.setColumnCount(3)
    text_frame_format.setColumnSpacing(10)

    presentation.save("TextBoxColumns.pptx", SaveFormat.Pptx)

    saved_presentation = Presentation("TextBoxColumns.pptx")
    try:
        saved_text_box = saved_presentation.getSlides().get_Item(0).getShapes().get_Item(0)
        saved_format = saved_text_box.getTextFrame().getTextFrameFormat()
        print(f"Columns: {saved_format.getColumnCount()}; spacing: {saved_format.getColumnSpacing()} points")
    finally:
        saved_presentation.dispose()
finally:
    presentation.dispose()
```

## **Extrahera text från enskilda kolumner**

Använd [TextFrame.splitTextByColumns](https://reference.aspose.com/slides/sv/python-java/aspose.slides/textframe/#splitTextByColumns) för att hämta den text som tilldelats varje visuell kolumn i en befintlig textram. Metoden returnerar en sträng för varje kolumn i kolumnbaserad läsordning. En enkelskikts textram ger en array med ett element, och en tom kolumn representeras av en tom sträng. Strängarna innehåller enbart vanlig text; formatering på portionsnivå bevaras inte.

Detta är användbart när du behöver:

- Extrahera text samtidigt som du bevarar dess kolumnbaserade läsordning.
- Indexera eller jämföra innehållet i bilder med flera kolumner.
- Exportera varje kolumn till en separat fil, databasfält eller annat mål.
- Undersöka hur text omfördelas efter att ha ändrat kolumnantalet med [TextFrameFormat.setColumnCount](https://reference.aspose.com/slides/sv/python-java/aspose.slides/textframeformat/#setColumnCount), avståndet med [TextFrameFormat.setColumnSpacing](https://reference.aspose.com/slides/sv/python-java/aspose.slides/textframeformat/#setColumnSpacing), fonten eller textramens storlek.

Metoden rapporterar den text som fördelas inom den aktuella [TextFrame](https://reference.aspose.com/slides/sv/python-java/aspose.slides/textframe/); den flödar inte automatiskt text mellan separata former eller textrutor. Kolumndistribution kan bero på tillgängliga fonter och andra textlayout‑inställningar, så se till att de nödvändiga fonterna finns tillgängliga när konsistenta resultat är viktiga.

Följande exempel läser in en presentation, hittar den första multi‑kolumn‑autoformen med en textram, läser dess konfigurerade kolumnantal och skriver texten från varje kolumn till en separat fil. Former som inte tillhandahåller en textram hoppas över.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import AutoShape, Presentation

presentation = Presentation("MultiColumnText.pptx")
try:
    text_box = None
    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, AutoShape):
            if shape.getTextFrame() is not None:
                column_count = shape.getTextFrame().getTextFrameFormat().getColumnCount()
                if column_count > 1:
                    text_box = shape
                    break

    if text_box is None:
        print("No multi-column text frame was found.")
    else:
        text_frame = text_box.getTextFrame()
        configured_column_count = text_frame.getTextFrameFormat().getColumnCount()
        column_texts = text_frame.splitTextByColumns()

        print(f"Configured columns: {configured_column_count}")

        for column_number, column_text in enumerate(column_texts, start=1):
            print(f"Column {column_number}: {column_text}")
            output_path = Path(f"Column-{column_number}.txt")
            try:
                output_path.write_text(str(column_text), encoding="utf-8")
            except OSError as exception:
                print(f"Could not write column {column_number}: {exception}")
finally:
    presentation.dispose()
```

## **Uppdatera text**

För att uppdatera text i hela presentationen, iterera genom bilder och former, välj autoformer och redigera sedan deras textportioner. Att arbeta på portionsnivå låter dig ändra både text och teckenformatering.

Följande exempel ersätter varje förekomst av `years` med `months` i auto‑form‑text och gör varje drabbat segment fetstilat:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, NullableBool, Presentation, SaveFormat

presentation = Presentation("Text.pptx")
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if not isinstance(shape, AutoShape):
                continue

            text_frame = shape.getTextFrame()
            if text_frame is None:
                continue

            for paragraph in text_frame.getParagraphs():
                for portion in paragraph.getPortions():
                    text = portion.getText()
                    if text is not None and "years" in str(text):
                        portion.setText(str(text).replace("years", "months"))
                        portion.getPortionFormat().setFontBold(NullableBool.True_)

    presentation.save("TextChanged.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Denna traversal uppdaterar endast text i autoformer. Text som lagras i tabeller, diagram, SmartArt eller grupperade former kräver traversering av dessa objekts egna samlingar.

## **Lägg till en textruta med en hyperlänk**

En hyperlänk kan tilldelas ett specifikt textsegment, så att endast den texten fungerar som den klickbara länken. Använd [HyperlinkManager.setExternalHyperlinkClick](https://reference.aspose.com/slides/sv/python-java/aspose.slides/hyperlinkmanager/#setExternalHyperlinkClick) för att koppla segmentet till en extern URL.

Följande exempel skapar länkad text och sparar den i en presentation:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 200, 50)
    text_box.addTextFrame("Aspose.Slides")

    text_portion = text_box.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    text_portion.getPortionFormat().getHyperlinkManager().setExternalHyperlinkClick("https://www.aspose.com/")

    presentation.save("Hyperlink.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Vad är skillnaden mellan en textruta och en textplatshållare på ett master‑ eller layout‑bild?**

En [placeholder](/slides/sv/python-java/manage-placeholder/) kan ärva sin position och formatering från en [master slide](https://reference.aspose.com/slides/sv/python-java/aspose.slides/masterslide/) eller [layout slide](https://reference.aspose.com/slides/sv/python-java/aspose.slides/layoutslide/). En vanlig textruta är en självständig form på bilden där den skapades och får inte platsbehållar‑beteende när layouten ändras.

**Hur kan jag ersätta text utan att ändra text i diagram, tabeller eller SmartArt?**

Begränsa traverseringen till former som är instanser av [AutoShape](https://reference.aspose.com/slides/sv/python-java/aspose.slides/autoshape/), som visas i exemplet Uppdatera text. Diagram, tabeller och SmartArt lagrar text i sina egna objekmodeller, så de modifieras inte av den loopen.