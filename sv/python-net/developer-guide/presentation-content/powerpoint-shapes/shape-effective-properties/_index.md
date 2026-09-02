---
title: Hämta effektiva egenskaper för former från presentationer i Python
linktitle: Effektiva egenskaper
type: docs
weight: 50
url: /sv/python-net/shape-effective-properties/
keywords:
- formegenskaper
- kameraegenskaper
- ljusrigg
- fasade former
- textram
- textstil
- teckenhöjd
- fyllformat
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Lär dig hur du använder Aspose.Slides för Python via .NET för att särskilja lokal, ärvd och effektiv formatering av former i PowerPoint-presentationer."
---
## **Förstå lokala, ärvda och effektiva egenskaper**

PowerPoint-formatering kan komma från flera ställen. Värdet som lagras direkt på ett objekt är dess **lokala värde**. Om det värdet inte är angivet ser PowerPoint på föräldraformatkällor, såsom ett standardvärde för stycke, en textstil, en layout‑ eller masterns bild, ett tema eller standardinställningar på presentationsnivå. Dessa värden är **ärvda värden**. Värdet som återstår efter att hela hierarkin har lösts är det **effektiva värdet**, som används för att rendera objektet.

Till exempel kanske en textdel inte definierar sin egen teckenhöjd. Dess lokala [font_height](https://reference.aspose.com/slides/sv/python-net/aspose.slides/ibaseportionformat/font_height/) är då `float("nan")`, vilket betyder "inte angivet här." Delen kan ärva en höjd från sitt stycke, presentationens standardtextstil eller en annan tillämplig källa. Att anropa [get_effective](https://reference.aspose.com/slides/sv/python-net/aspose.slides/iportionformat/get_effective/) på delformatet returnerar den slutgiltigt lösta höjden.

Använd de två typerna av formateringsdata för olika ändamål:

- Läs eller ändra ett lokalt formatobjekt, till exempel [IPortionFormat](https://reference.aspose.com/slides/sv/python-net/aspose.slides/iportionformat/), när du behöver kontrollera var ett värde är definierat.
- Läs ett effektivt dataobjekt, till exempel [IPortionFormatEffectiveData](https://reference.aspose.com/slides/sv/python-net/aspose.slides/iportionformateffectivedata/), när du behöver det slutgiltiga, renderade resultatet. Effektiva data är skrivskyddade.

## **Jämför lokala, ärvda och effektiva värden**

Det följande kompletta exemplet skapar en form och tillämpar teckenhöjder på presentations-, stycke- och delnivå. Varje steg skriver ut de värden som definierats på dessa nivåer och det resulterande effektiva värdet för samma textdel. Det visar också varför effektiva data måste läsas igen efter formateringsändringar.

```python
import math

import aspose.slides as slides


def format_local_value(value):
    return "<not set>" if math.isnan(value) else str(value)


def print_font_heights(caption, presentation, paragraph, portion):
    presentation_value = presentation.default_text_style.get_level(0).default_portion_format.font_height
    paragraph_value = paragraph.paragraph_format.default_portion_format.font_height
    local_value = portion.portion_format.font_height

    # Läs effektiva data efter de föregående ändringarna.
    effective_value = portion.portion_format.get_effective().font_height

    print(caption)
    print("  Presentation default: " + format_local_value(presentation_value))
    print("  Paragraph default:    " + format_local_value(paragraph_value))
    print("  Portion local:        " + format_local_value(local_value))
    print("  Portion effective:    " + str(effective_value))


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 500, 80, False)
    text_frame = shape.add_text_frame("Effective formatting")
    paragraph = text_frame.paragraphs[0]
    portion = paragraph.portions[0]

    # Definiera ärvda värden på två olika nivåer.
    presentation.default_text_style.get_level(0).default_portion_format.font_height = 20
    paragraph.paragraph_format.default_portion_format.font_height = 28

    print_font_heights("The portion inherits from the paragraph", presentation, paragraph, portion)

    # Ett lokalt värde på delen åsidosätter båda ärvda värdena.
    portion.portion_format.font_height = 36
    print_font_heights("A local value overrides inherited values", presentation, paragraph, portion)

    # Att ändra ett ärvt värde åsidosätter inte ett befintligt lokalt värde.
    paragraph.paragraph_format.default_portion_format.font_height = 30
    print_font_heights("The local value still has priority", presentation, paragraph, portion)

    # Rensa det lokala värdet. Delen ärver nu igen från stycket.
    portion.portion_format.font_height = float("nan")
    print_font_heights("The local value is cleared", presentation, paragraph, portion)

    # Rensa styckets värde. Presentationens standardvärde levererar nu resultatet.
    paragraph.paragraph_format.default_portion_format.font_height = float("nan")
    print_font_heights("The paragraph value is cleared", presentation, paragraph, portion)

    presentation.save("effective-properties.pptx", slides.export.SaveFormat.PPTX)
```

Prioriteten i detta exempel är delens lokala formatering, sedan styckets formatering, sedan presentationens standard. Andra objekt kan ha olika arvskedjor, men principen är densamma: ett mer specifikt explicit värde vinner, och [get_effective](https://reference.aspose.com/slides/sv/python-net/aspose.slides/iportionformat/get_effective/) returnerar det slutgiltiga resultatet.

## **Hämta effektiva textegenskaper**

Textformatering är uppdelad över flera objekt:

- [ITextFrameFormat.get_effective()](https://reference.aspose.com/slides/sv/python-net/aspose.slides/itextframeformat/get_effective/) löser egenskaper för textram, såsom marginaler, fästning, autofit och vertikal textriktning.
- [ITextStyle.get_effective()](https://reference.aspose.com/slides/sv/python-net/aspose.slides/itextstyle/get_effective/) löser styckeformatering för varje textstilsnivå.
- [IParagraphFormat.get_effective()](https://reference.aspose.com/slides/sv/python-net/aspose.slides/iparagraphformat/get_effective/) löser styckeegenskaper såsom justering, indragning och punktlistor.
- [IPortionFormat.get_effective()](https://reference.aspose.com/slides/sv/python-net/aspose.slides/iportionformat/get_effective/) löser teckenegenskaper såsom teckenhöjd, teckensnitt, färg, fetstil och kursiv.

För nästa exempel måste `text-formatting.pptx` innehålla minst en bild och en [AutoShape](https://reference.aspose.com/slides/sv/python-net/aspose.slides/autoshape/) med en icke‑tom textram. AutoShape kan förekomma på vilken position som helst i formsamlingen; koden söker efter ett lämpligt objekt och validerar det innan det används.

```python
import aspose.slides as slides


def has_non_empty_text(shape):
    if not isinstance(shape, slides.AutoShape):
        return False
    if shape.text_frame is None:
        return False
    if shape.text_frame.paragraphs.count == 0:
        return False
    return shape.text_frame.paragraphs[0].portions.count > 0


with slides.Presentation("text-formatting.pptx") as presentation:
    if presentation.slides.count == 0:
        raise RuntimeError("The presentation contains no slides.")

    shape = None
    for candidate in presentation.slides[0].shapes:
        if has_non_empty_text(candidate):
            shape = candidate
            break

    if shape is None:
        raise RuntimeError("The first slide must contain an AutoShape with non-empty text.")

    text_frame = shape.text_frame
    paragraph = text_frame.paragraphs[0]
    portion = paragraph.portions[0]

    text_frame_effective = text_frame.text_frame_format.get_effective()
    paragraph_effective = paragraph.paragraph_format.get_effective()
    portion_effective = portion.portion_format.get_effective()

    print("Text frame margins:")
    print("  Left: " + str(text_frame_effective.margin_left))
    print("  Top: " + str(text_frame_effective.margin_top))
    print("  Right: " + str(text_frame_effective.margin_right))
    print("  Bottom: " + str(text_frame_effective.margin_bottom))
    print("Paragraph alignment: " + str(paragraph_effective.alignment))
    print("Font height: " + str(portion_effective.font_height))
    print("Bold: " + str(portion_effective.font_bold))

    effective_text_style = text_frame.text_frame_format.text_style.get_effective()
    for level in range(9):
        level_effective = effective_text_style.get_level(level)
        print("Level " + str(level) + " indent: " + str(level_effective.indent))
```

## **Hämta effektiva 3D‑egenskaper**

[IThreeDFormat.get_effective()](https://reference.aspose.com/slides/sv/python-net/aspose.slides/ithreedformat/get_effective/) returnerar ett [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/sv/python-net/aspose.slides/ithreedformateffectivedata/)‑objekt som grupperar alla lösta 3D‑inställningar. Dess [camera](https://reference.aspose.com/slides/sv/python-net/aspose.slides/ithreedformateffectivedata/camera/), [light_rig](https://reference.aspose.com/slides/sv/python-net/aspose.slides/ithreedformateffectivedata/light_rig/), [bevel_top](https://reference.aspose.com/slides/sv/python-net/aspose.slides/ithreedformateffectivedata/bevel_top/) och [bevel_bottom](https://reference.aspose.com/slides/sv/python-net/aspose.slides/ithreedformateffectivedata/bevel_bottom/)‑egenskaper visar motsvarande effektiva data. Att läsa dessa relaterade inställningar tillsammans gör det lättare att förstå den slutgiltiga 3D‑utseendet för en form.

För detta exempel måste `shape-3d.pptx` innehålla minst en form på den första bilden. Tillämpa 3D‑kamera, belysning eller fasningsinställningar på den formen om du vill att utsignalen ska innehålla värden som skiljer sig från standardvärdena.

```python
import aspose.slides as slides


with slides.Presentation("shape-3d.pptx") as presentation:
    if presentation.slides.count == 0 or presentation.slides[0].shapes.count == 0:
        raise RuntimeError("The first slide must contain a shape.")

    shape = presentation.slides[0].shapes[0]
    three_d_effective = shape.three_d_format.get_effective()

    print("Camera:")
    print("  Type: " + str(three_d_effective.camera.camera_type))
    print("  Field of view: " + str(three_d_effective.camera.field_of_view_angle))
    print("  Zoom: " + str(three_d_effective.camera.zoom))

    print("Light rig:")
    print("  Type: " + str(three_d_effective.light_rig.light_type))
    print("  Direction: " + str(three_d_effective.light_rig.direction))

    print("Top bevel:")
    print("  Type: " + str(three_d_effective.bevel_top.bevel_type))
    print("  Width: " + str(three_d_effective.bevel_top.width))
    print("  Height: " + str(three_d_effective.bevel_top.height))
```

## **Hämta effektiv tabellformatering**

Tabellformatering kan komma från tabellstilen och från format som tillämpas på hela tabellen, en kolumn, en rad eller en enskild cell. Vid konflikter mellan explicit definierade fyllningar är prioriteten cell, rad, kolumn och sedan hela tabellen. Den effektiva formateringen av en cell är det slutgiltiga formatet som används för att rita cellen.

För detta exempel måste `table-formatting.pptx` innehålla minst en tabell på den första bilden. Tabellen måste ha minst en rad och en kolumn. Koden söker efter en [Table](https://reference.aspose.com/slides/sv/python-net/aspose.slides/table/) istället för att anta att `shapes[0]` är en tabell.

```python
import aspose.slides as slides


with slides.Presentation("table-formatting.pptx") as presentation:
    if presentation.slides.count == 0:
        raise RuntimeError("The presentation contains no slides.")

    table = None
    for shape in presentation.slides[0].shapes:
        if isinstance(shape, slides.Table):
            table = shape
            break

    if table is None:
        raise RuntimeError("The first slide must contain a table.")

    if table.rows.count == 0 or table.columns.count == 0:
        raise RuntimeError("The table must contain at least one cell.")

    table_effective = table.table_format.get_effective()
    row_effective = table.rows[0].row_format.get_effective()
    column_effective = table.columns[0].column_format.get_effective()
    cell_effective = table.rows[0][0].cell_format.get_effective()

    print("Table fill: " + str(table_effective.fill_format.fill_type))
    print("Row fill: " + str(row_effective.fill_format.fill_type))
    print("Column fill: " + str(column_effective.fill_format.fill_type))
    print("Final cell fill: " + str(cell_effective.fill_format.fill_type))
```

Om du behöver färgen snarare än bara fyllningstypen, kontrollera först den effektiva [fill_type](https://reference.aspose.com/slides/sv/python-net/aspose.slides/ifillformateffectivedata/fill_type/), och läs sedan egenskapen som gäller för den typen, till exempel [solid_fill_color](https://reference.aspose.com/slides/sv/python-net/aspose.slides/ifillformateffectivedata/solid_fill_color/) för en solid fyllning.

## **Läs effektiva data igen efter ändringar**

Effektiva data beskriver formateringshierarkin vid den tidpunkt den löses. Anropa `get_effective` igen efter att ha ändrat något som kan delta i den hierarkin, inklusive:

- objektets lokala formatering;
- stycke‑ eller textram‑standarder;
- en tabellstil, tabell, kolumn, rad eller cellformat;
- layout‑ eller masterns bildformatering;
- temadata eller standardinställningar på presentationsnivå;
- layouten eller mastern som tilldelats en bild.

Behåll inte ett effektivt dataobjekt som en permanent ögonblicksbild. Aspose.Slides kan cachea vissa effektiva data internt, och ett senare `get_effective`‑anrop kan uppdatera dessa data. Om du behöver jämföra värden före och efter en ändring, kopiera de skalära värden du behöver, såsom teckenhöjd, färg, justering eller fasningsbredd, till egna variabler innan du gör ändringen.

För att ändra ett värde, uppdatera det lämpliga lokala formatobjektet och anropa sedan `get_effective` för att verifiera resultatet. Effektiva dataobjekt är själva skrivskyddade.

## **FAQ**

**Hur kan jag avgöra vilken nivå som levererade ett effektivt värde?**

Effektiva data innehåller det slutgiltiga värdet, inte dess källa. Inspektera de tillämpliga lokala objekten från den mest specifika nivån och utåt. För text kan detta inkludera delen, stycket, textramen, layouten, mastern, temat och presentationsstandarderna. Odefinierade värden såsom `float("nan")` eller `None` indikerar att sökningen fortsätter till en annan nivå.

**Vad händer när ingen nivå definierar en egenskap?**

Aspose.Slides löser den lämpliga PowerPoint‑ eller biblioteksstandardvärdet. Det lösta värdet visas i de effektiva data även om inget lokalt objekt explicit definierar det.

**Varför kan ett effektivt värde ibland vara lika med det lokala värdet?**

Det lokala värdet vann arvberäkningen. Detta är förväntat när egenskapen är explicit satt på objektet och ingen mer specifik regel åsidosätter den.

**När bör jag använda lokala data istället för effektiva data?**

Använd lokala data för att inspektera eller redigera en specifik formateringsnivå. Använd effektiva data när du behöver det slutgiltiga utseendet efter arv, temaregelverk och tillämpliga stilar har lösts. Det [kompletta jämförelseexemplet](#compare-local-inherited-and-effective-values) demonstrerar båda i samma arbetsflöde.