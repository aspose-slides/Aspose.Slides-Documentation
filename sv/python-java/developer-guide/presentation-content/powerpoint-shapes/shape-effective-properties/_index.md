---
title: Hämta formens effektiva egenskaper från presentationer i Python via Java
linktitle: Effektiva egenskaper
type: docs
weight: 50
url: /sv/python-java/shape-effective-properties/
keywords:
- formegenskaper
- kameraegenskaper
- ljusrigg
- fasningsform
- textram
- textstil
- teckenhöjd
- fyllningsformat
- PowerPoint
- presentation
- Python
- Java
- Aspose.Slides
description: "Lär dig hur du använder Aspose.Slides för Python via Java för att särskilja lokal, ärvd och effektiv formatering av former i PowerPoint-presentationer."
---
## **Förstå lokala, ärvda och effektiva egenskaper**

PowerPoint-formatering kan komma från flera ställen. Värdet som lagras direkt på ett objekt är dess **lokala värde**. Om det värdet inte är satt, tittar PowerPoint på föräldraformateringskällor, såsom ett standardvärde för stycke, en textstil, en layout‑ eller masternedslag, ett tema eller presentationens standardvärden. Dessa värden är **ärvda värden**. Värdet som återstår efter att hela hierarkin har lösts är **effektiva värdet** — värdet som används för att rendera objektet.

Till exempel kanske en textdel inte definierar sin egen teckenhöjd. Dess lokala [getFontHeight](https://reference.aspose.com/slides/sv/python-java/aspose.slides/baseportionformat/#getFontHeight) värde blir då `float("nan")`, vilket betyder "inte satt här". Textdelen kan ärva en höjd från sitt stycke, presentationens standardtextstil eller en annan tillämplig källa. Att anropa [getEffective](https://reference.aspose.com/slides/sv/python-java/aspose.slides/portionformat/#getEffective) på delens format returnerar den slutgiltigt lösta höjden.

Använd de två typerna av formateringsdata för olika ändamål:

- Läs eller ändra ett lokalt formatobjekt, t.ex. [PortionFormat](https://reference.aspose.com/slides/sv/python-java/aspose.slides/portionformat/), när du behöver kontrollera var ett värde definieras.
- Läs ett effektivt dataobjekt, t.ex. `PortionFormatEffectiveData`, när du behöver det slutgiltiga, renderade resultatet. Effektiva data är skrivskyddade.

## **Jämför lokala, ärvda och effektiva värden**

Det följande kompletta exemplet skapar en form och tillämpar teckenhöjder på presentations‑, stycke‑ och delnivå. Varje steg skriver ut de värden som definierats på dessa nivåer och det resulterande effektiva värdet för samma textdel. Det demonstrerar också varför effektiva data måste läsas igen efter formateringsändringar.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from math import isnan
from asposeslides.api import Presentation, SaveFormat, ShapeType


def format_local_value(value):
    return "<not set>" if isnan(value) else str(value)


def print_font_heights(caption, presentation, paragraph, portion):
    presentation_value = presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().getFontHeight()
    paragraph_value = paragraph.getParagraphFormat().getDefaultPortionFormat().getFontHeight()
    local_value = portion.getPortionFormat().getFontHeight()

    # Läs effektiva data efter de föregående ändringarna.
    effective_value = portion.getPortionFormat().getEffective().getFontHeight()

    print(caption)
    print(f"  Presentation default: {format_local_value(presentation_value)}")
    print(f"  Paragraph default:    {format_local_value(paragraph_value)}")
    print(f"  Portion local:        {format_local_value(local_value)}")
    print(f"  Portion effective:    {effective_value}")


presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 500, 80, False)
    text_frame = shape.addTextFrame("Effective formatting")
    paragraph = text_frame.getParagraphs().get_Item(0)
    portion = paragraph.getPortions().get_Item(0)

    # Definiera ärvda värden på två olika nivåer.
    presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().setFontHeight(20)
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(28)
    print_font_heights("The portion inherits from the paragraph", presentation, paragraph, portion)

    # Ett lokalt värde på delen åsidosätter båda ärvda värden.
    portion.getPortionFormat().setFontHeight(36)
    print_font_heights("A local value overrides inherited values", presentation, paragraph, portion)

    # Att ändra ett ärvt värde åsidosätter inte ett befintligt lokalt värde.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(30)
    print_font_heights("The local value still has priority", presentation, paragraph, portion)

    # Rensa det lokala värdet. Textdelen ärver nu från stycket igen.
    portion.getPortionFormat().setFontHeight(float("nan"))
    print_font_heights("The local value is cleared", presentation, paragraph, portion)

    # Rensa styckevärdet. Presentationens standardvärde levererar nu resultatet.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(float("nan"))
    print_font_heights("The paragraph value is cleared", presentation, paragraph, portion)

    presentation.save("effective-properties.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Prioriteten i detta exempel är delens lokala formatering, sedan styckeformatering, sedan presentationens standard. Andra objekt kan ha olika arvskedjor, men principen är densamma: ett mer specifikt explicit värde vinner, och [getEffective](https://reference.aspose.com/slides/sv/python-java/aspose.slides/portionformat/#getEffective) returnerar slutresultatet.

## **Hämta effektiva textegenskaper**

Textformatering är uppdelad över flera objekt:

- [TextFrameFormat.getEffective](https://reference.aspose.com/slides/sv/python-java/aspose.slides/textframeformat/#getEffective) löser text‑ramegenskaper såsom marginaler, förankring, autofit och vertikal textriktning.
- [TextStyle.getEffective](https://reference.aspose.com/slides/sv/python-java/aspose.slides/textstyle/#getEffective) löser styckeformatering för varje textstilsnivå.
- [ParagraphFormat.getEffective](https://reference.aspose.com/slides/sv/python-java/aspose.slides/paragraphformat/#getEffective) löser styckeegenskaper såsom justering, indentering och punktlistor.
- [PortionFormat.getEffective](https://reference.aspose.com/slides/sv/python-java/aspose.slides/portionformat/#getEffective) löser teckenegenskaper såsom teckenhöjd, teckensnitt, färg, fetstil och kursiv.

För nästa exempel måste `text-formatting.pptx` innehålla minst en bild och en [AutoShape](https://reference.aspose.com/slides/sv/python-java/aspose.slides/autoshape/) med en icke‑tom textram. AutoShape kan finnas på någon position i formsamlingen; koden söker efter ett lämpligt objekt och validerar det innan användning.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Presentation


def has_non_empty_text(shape):
    text_frame = shape.getTextFrame()
    if text_frame is None or text_frame.getParagraphs().getCount() == 0:
        return False
    return text_frame.getParagraphs().get_Item(0).getPortions().getCount() > 0


def find_auto_shape_with_text(slide):
    for candidate in slide.getShapes():
        if isinstance(candidate, AutoShape) and has_non_empty_text(candidate):
            return candidate
    return None


presentation = Presentation("text-formatting.pptx")
try:
    if presentation.getSlides().size() == 0:
        print("The presentation contains no slides.")
    else:
        shape = find_auto_shape_with_text(presentation.getSlides().get_Item(0))
        if shape is None:
            print("The first slide must contain an AutoShape with non-empty text.")
        else:
            text_frame = shape.getTextFrame()
            paragraph = text_frame.getParagraphs().get_Item(0)
            portion = paragraph.getPortions().get_Item(0)

            text_frame_effective = text_frame.getTextFrameFormat().getEffective()
            paragraph_effective = paragraph.getParagraphFormat().getEffective()
            portion_effective = portion.getPortionFormat().getEffective()

            print("Text frame margins:")
            print(f"  Left: {text_frame_effective.getMarginLeft()}")
            print(f"  Top: {text_frame_effective.getMarginTop()}")
            print(f"  Right: {text_frame_effective.getMarginRight()}")
            print(f"  Bottom: {text_frame_effective.getMarginBottom()}")
            print(f"Paragraph alignment: {paragraph_effective.getAlignment()}")
            print(f"Font height: {portion_effective.getFontHeight()}")
            print(f"Bold: {portion_effective.getFontBold()}")

            effective_text_style = text_frame.getTextFrameFormat().getTextStyle().getEffective()
            for level in range(9):
                level_effective = effective_text_style.getLevel(level)
                print(f"Level {level} indent: {level_effective.getIndent()}")
finally:
    presentation.dispose()
```

## **Hämta effektiva 3D‑egenskaper**

[ThreeDFormat.getEffective](https://reference.aspose.com/slides/sv/python-java/aspose.slides/threedformat/#getEffective) returnerar ett `ThreeDFormatEffectiveData`‑objekt som samlar alla lösta 3D‑inställningar. Dess metoder `getCamera`, `getLightRig`, `getBevelTop` och `getBevelBottom` visar motsvarande effektiva data. Att läsa dessa relaterade inställningar tillsammans gör det enklare att förstå den slutgiltiga 3D‑utseendet för en form.

För detta exempel måste `shape-3d.pptx` innehålla minst en form på dess första bild. Applicera 3D‑kamera, belysning eller fasningsinställningar på den formen om du vill att utdata ska innehålla andra värden än standardvärdena.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("shape-3d.pptx")
try:
    if presentation.getSlides().size() == 0 or presentation.getSlides().get_Item(0).getShapes().size() == 0:
        print("The first slide must contain a shape.")
    else:
        shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
        three_d_effective = shape.getThreeDFormat().getEffective()

        print("Camera:")
        print(f"  Type: {three_d_effective.getCamera().getCameraType()}")
        print(f"  Field of view: {three_d_effective.getCamera().getFieldOfViewAngle()}")
        print(f"  Zoom: {three_d_effective.getCamera().getZoom()}")

        print("Light rig:")
        print(f"  Type: {three_d_effective.getLightRig().getLightType()}")
        print(f"  Direction: {three_d_effective.getLightRig().getDirection()}")

        print("Top bevel:")
        print(f"  Type: {three_d_effective.getBevelTop().getBevelType()}")
        print(f"  Width: {three_d_effective.getBevelTop().getWidth()}")
        print(f"  Height: {three_d_effective.getBevelTop().getHeight()}")
finally:
    presentation.dispose()
```

## **Hämta effektiv tabellformatering**

Tabellformatering kan komma från tabellstilen och från format som tillämpas på hela tabellen, en kolumn, en rad eller en enskild cell. Vid konflikter mellan explicit definierade fyllningar är prioriteten cell, rad, kolumn och sedan hela tabellen. Det effektiva formatet för en cell är det slutgiltiga format som används för att rita den cellen.

För detta exempel måste `table-formatting.pptx` innehålla minst en tabell på dess första bild. Tabellen måste ha minst en rad och en kolumn. Koden söker efter en [Table](https://reference.aspose.com/slides/sv/python-java/aspose.slides/table/) istället för att anta att `getShapes().get_Item(0)` är en tabell.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Table


def find_table(slide):
    for shape in slide.getShapes():
        if isinstance(shape, Table):
            return shape
    return None


presentation = Presentation("table-formatting.pptx")
try:
    if presentation.getSlides().size() == 0:
        print("The presentation contains no slides.")
    else:
        table = find_table(presentation.getSlides().get_Item(0))
        if table is None:
            print("The first slide must contain a table.")
        elif table.getRows().size() == 0 or table.getColumns().size() == 0:
            print("The table must contain at least one cell.")
        else:
            table_effective = table.getTableFormat().getEffective()
            row_effective = table.getRows().get_Item(0).getRowFormat().getEffective()
            column_effective = table.getColumns().get_Item(0).getColumnFormat().getEffective()
            cell_effective = table.get_Item(0, 0).getCellFormat().getEffective()

            print(f"Table fill: {table_effective.getFillFormat().getFillType()}")
            print(f"Row fill: {row_effective.getFillFormat().getFillType()}")
            print(f"Column fill: {column_effective.getFillFormat().getFillType()}")
            print(f"Final cell fill: {cell_effective.getFillFormat().getFillType()}")
finally:
    presentation.dispose()
```

Om du behöver färgen snarare än bara fyllningstypen, kontrollera först den effektiva `getFillType` och läs sedan den metod som gäller för den typen — till exempel `getSolidFillColor` för en solid fyllning.

## **Läs om effektiva data efter ändringar**

Effektiva data beskriver formateringshierarkin vid den tidpunkt den lösts. Anropa [getEffective](https://reference.aspose.com/slides/sv/python-java/aspose.slides/portionformat/#getEffective) igen efter att ha ändrat något som kan delta i den hierarkin, inklusive:

- objektets lokala formatering;
- stycke‑ eller textram‑standarder;
- en tabellstil, tabell, kolumn, rad eller cellformat;
- layout‑ eller masternedslag‑formatering;
- temadata eller presentationens standarder;
- layouten eller mastern som tilldelats en bild.

Behåll inte ett effektivt dataobjekt som en permanent ögonblicksbild. Aspose.Slides kan cachelagra vissa effektiva data internt, och ett senare anrop av [getEffective](https://reference.aspose.com/slides/sv/python-java/aspose.slides/portionformat/#getEffective) kan uppdatera dessa data. Om du behöver jämföra värden före och efter en ändring, kopiera de skalära värden du behöver — såsom teckenhöjd, färg, justering eller fasningsbredd — till egna variabler innan du gör ändringen.

För att ändra ett värde, uppdatera det lämpliga lokala formatobjektet och anropa sedan [getEffective](https://reference.aspose.com/slides/sv/python-java/aspose.slides/portionformat/#getEffective) för att verifiera resultatet. Effektiva dataobjekt är i sig skrivskyddade.

## **FAQ**

**Hur kan jag avgöra vilken nivå som levererade ett effektivt värde?**

Effektiva data innehåller det slutgiltiga värdet, inte dess källa. Inspektera de tillämpliga lokala objekten från den mest specifika nivån och utåt. För text kan detta inkludera delen, stycket, textramen, layouten, mastern, temat och presentationens standarder. Odefinierade värden såsom `float("nan")` eller `None` indikerar att sökningen fortsätter till en annan nivå.

**Vad händer när ingen nivå definierar en egenskap?**

Aspose.Slides löser upp det lämpliga PowerPoint‑ eller biblioteksstandardvärdet. Detta lösta värde visas i de effektiva data även om inget lokalt objekt explicit definierar det.

**Varför är ett effektivt värde ibland lika med det lokala värdet?**

Det lokala värdet vann arvberäkningen. Detta är förväntat när egenskapen är explicit satt på objektet och ingen mer specifik regel åsidosätter det.

**När bör jag använda lokala data istället för effektiva data?**

Använd lokala data för att inspektera eller redigera en specifik formateringsnivå. Använd effektiva data när du behöver den slutgiltiga utseendet efter arv, temaregelverk och tillämpliga stilar har lösts. [Det kompletta jämförelseexemplet](#compare-local-inherited-and-effective-values) demonstrerar båda i samma arbetsflöde.