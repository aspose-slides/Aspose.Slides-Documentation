---
title: Hantera presentationstabeller i Python
linktitle: Hantera tabell
type: docs
weight: 10
url: /sv/python-java/manage-table/
keywords:
- lägga till tabell
- skapa tabell
- åtkomst till tabell
- bildförhållande
- justera text
- textformatering
- tabellstil
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Skapa och redigera tabeller i PowerPoint-bilder med Aspose.Slides för Python via Java. Upptäck enkla kodexempel för att effektivisera dina tabellarbetsflöden."
---
## **Introduktion**

Tabeller i PowerPoint organiserar information i rader och kolumner, vilket gör det enklare att läsa och jämföra värden.

Aspose.Slides tillhandahåller klasserna [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) och [Cell](https://reference.aspose.com/slides/python-java/aspose.slides/cell/) samt andra typer som låter dig skapa, uppdatera och hantera tabeller i presentationer.

## **Skapa en tabell från grunden**

Skapa en tabell genom att ange dess position, kolumnbredder och radhöjder. Efter att du lagt till den på en bild kan du formatera cellkantlinjer, slå samman celler och infoga text.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).
2. Hämta en referens till bilden med dess index.
3. Definiera en lista med kolumnbredder i punkter.
4. Definiera en lista med radhöjder i punkter.
5. Lägg till ett [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/)‑objekt på bilden via metoden [addTable](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addTable).
6. Iterera genom varje [Cell](https://reference.aspose.com/slides/python-java/aspose.slides/cell/) för att applicera formatering på övre, nedre, högra och vänstra kantlinjer.
7. Slå samman de två första cellerna i tabellens första rad.
8. Kom åt den sammanslagna cellen via dess metod [getTextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getTextFrame).
9. Ange texten i den sammanslagna cellen.
10. Spara den modifierade presentationen.

Exemplet nedan skapar en tabell med tre kolumner och fem rader vid (100, 50) punkter. Det applicerar röda kantlinjer med en bredd på 5 punkter, slår samman de två första cellerna i första raden och sparar resultatet som `table.pptx`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    for row in table.getRows():
        for cell in row:
            cell_format = cell.getCellFormat()
            cell_format.getBorderTop().getFillFormat().setFillType(FillType.Solid)
            cell_format.getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell_format.getBorderTop().setWidth(5)
            cell_format.getBorderBottom().getFillFormat().setFillType(FillType.Solid)
            cell_format.getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell_format.getBorderBottom().setWidth(5)
            cell_format.getBorderLeft().getFillFormat().setFillType(FillType.Solid)
            cell_format.getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell_format.getBorderLeft().setWidth(5)
            cell_format.getBorderRight().getFillFormat().setFillType(FillType.Solid)
            cell_format.getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell_format.getBorderRight().setWidth(5)

    table.mergeCells(table.get_Item(0, 0), table.get_Item(1, 0), False)
    table.get_Item(0, 0).getTextFrame().setText("Merged Cells")

    presentation.save("table.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Numrering i en standardtabell**

I en standardtabell är cellindex nollbaserade och använder ordningen (kolumn, rad). Den första cellen har index (0, 0).

Till exempel numreras cellerna i en tabell med 4 kolumner och 4 rader på följande sätt:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Detta exempel skapar 4 × 4‑tabellen som illustreras ovan, med kolumnbredder och radhöjder på 70 punkter och röda cellkantlinjer med en bredd på 5 punkter. Koordinaterna visar cellindex; exemplet lämnar cellerna tomma och sparar tabellen som `StandardTables_out.pptx`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    for row in table.getRows():
        for cell in row:
            cell_format = cell.getCellFormat()
            cell_format.getBorderTop().getFillFormat().setFillType(FillType.Solid)
            cell_format.getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell_format.getBorderTop().setWidth(5)
            cell_format.getBorderBottom().getFillFormat().setFillType(FillType.Solid)
            cell_format.getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell_format.getBorderBottom().setWidth(5)
            cell_format.getBorderLeft().getFillFormat().setFillType(FillType.Solid)
            cell_format.getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell_format.getBorderLeft().setWidth(5)
            cell_format.getBorderRight().getFillFormat().setFillType(FillType.Solid)
            cell_format.getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell_format.getBorderRight().setWidth(5)

    presentation.save("StandardTables_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Åtkomst till en befintlig tabell**

Tabeller lagras i en bilds shape‑samling. Iterera genom formerna för att hitta en tabell, och använd sedan klassen [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) för att läsa eller uppdatera dess celler.

1. Läs in presentationen med klassen [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).
2. Hämta en referens till bilden som innehåller tabellen med dess index.
3. Iterera genom [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/)‑objekten och stoppa när en tabell hittas. Om bilden innehåller flera tabeller, använd [getAlternativeText](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getAlternativeText) för att identifiera den du behöver.
4. Uppdatera texten i målcell.
5. Spara den modifierade presentationen.

Exemplet nedan öppnar `UpdateExistingTable.pptx` och hittar den första tabellen på den första bilden. Det sätter cellen i kolumn 0, rad 1 till `New` och sparar resultatet som `table1_out.pptx`. Inmatningen måste innehålla minst en bild, och den första tabellen på den bilden måste ha minst en kolumn och två rader.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Table

presentation = Presentation("UpdateExistingTable.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    table = None

    for shape in slide.getShapes():
        if isinstance(shape, Table):
            table = shape
            break

    if table is not None:
        table.get_Item(0, 1).getTextFrame().setText("New")
        presentation.save("table1_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

För att ändra storlek på en rad i en befintlig tabell och förstå varför dess faktiska höjd kan överstiga den begärda minimin, se [Control Row Height](/slides/sv/python-java/manage-rows-and-columns/#control-row-height).

## **Hitta cellen som äger en TextFrame**

När generisk textbehandlingskod får en [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/) från en tabell, använd metoden [TextFrame.getParentCell](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getParentCell) för att hämta den ägande [Cell](https://reference.aspose.com/slides/python-java/aspose.slides/cell/). För en tabellcell‑textframe returnerar [TextFrame.getParentCell](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getParentCell) ägaren och [TextFrame.getParentShape](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getParentShape) returnerar `None`, även om tabellen själv är en shape.

Cellkoordinaterna är tillgängliga via de skrivskyddade metoderna [Cell.getFirstColumnIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstColumnIndex) och [Cell.getFirstRowIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstRowIndex). [TextFrame.getParentCell](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getParentCell) erbjuder också skrivskyddad navigation: den returnerar ägaren men ändrar inte ägarskapet. Kontrollera alltid om den returnerade cellen är `None` innan du använder den.

För ett komplett exempel som identifierar tabellcell‑ och shape‑ägare, inklusive former knutna till SmartArt‑noder, se [Search and Replace Text](/slides/sv/python-java/search-and-replace-text/).

## **Justera text i en tabell**

Du kan kontrollera vertikal förankring och textriktning för enskilda tabellceller. Exemplet i detta avsnitt centrerar texten i den första cellen och roterar den 270 grader.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).
2. Hämta en referens till bilden med dess index.
3. Lägg till ett [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/)‑objekt på bilden.
4. Kom åt ett [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/)‑objekt från tabellen.
5. Kom åt den första [Paragraph](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/) och ange dess text och färg.
6. Ställ in cellens vertikala förankring och textriktning med [setTextAnchorType](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#setTextAnchorType) och [setTextVerticalType](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#setTextVerticalType).
7. Spara den modifierade presentationen.

Detta exempel skapar en 4 × 4‑tabell med kolumnbredder på 120 punkter och radhöjder på 100 punkter. Det formaterar texten i cell (0, 0), lägger till värden i de återstående cellerna i första raden och sparar resultatet som `Vertical_Align_Text_out.pptx`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, TextAnchorType, TextVerticalType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [120, 120, 120, 120]
    row_heights = [100, 100, 100, 100]
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)
    
    table.get_Item(1, 0).getTextFrame().setText("10")
    table.get_Item(2, 0).getTextFrame().setText("20")
    table.get_Item(3, 0).getTextFrame().setText("30")

    text_frame = table.get_Item(0, 0).getTextFrame()
    paragraph = text_frame.getParagraphs().get_Item(0)

    portion = paragraph.getPortions().get_Item(0)
    portion.setText("Text here")
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)

    cell = table.get_Item(0, 0)
    cell.setTextAnchorType(TextAnchorType.Center)
    cell.setTextVerticalType(TextVerticalType.Vertical270)

    presentation.save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ange textformatering på tabellnivå**

Använd [setTextFormat](https://reference.aspose.com/slides/python-java/aspose.slides/table/#setTextFormat) för att applicera textformatering på alla celler i en tabell. Dess överlagringar accepterar formatering för segment, stycken och textframe, så du kan ange dessa egenskaper utan att iterera genom enskilda celler.

1. Läs in presentationen med klassen [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).
2. Hämta en referens till bilden med dess index.
3. Kom åt ett [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/)‑objekt från bilden.
4. Ställ in teckenstorleken med [setFontHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setFontHeight) för texten.
5. Ställ in styckejustering och högermarginal med [setAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setAlignment) och [setMarginRight](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setMarginRight).
6. Ställ in textriktning med [setTextVerticalType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setTextVerticalType).
7. Spara den modifierade presentationen.

Exemplet nedan öppnar `table.pptx`, som måste innehålla minst en bild med en tabell som dess första shape. Det sätter teckenstorleken till 25 punkter, högerjusterar stycken med en högermarginal på 20 punkter och gör texten vertikal. Den formaterade presentationen sparas som `result.pptx`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ParagraphFormat, PortionFormat, Presentation, SaveFormat, TextAlignment, TextFrameFormat, TextVerticalType, Table

presentation = Presentation("table.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    table = slide.getShapes().get_Item(0)

    portion_format = PortionFormat()
    portion_format.setFontHeight(25)
    table.setTextFormat(portion_format)

    paragraph_format = ParagraphFormat()
    paragraph_format.setAlignment(TextAlignment.Right)
    paragraph_format.setMarginRight(20)
    table.setTextFormat(paragraph_format)

    text_frame_format = TextFrameFormat()
    text_frame_format.setTextVerticalType(TextVerticalType.Vertical)
    table.setTextFormat(text_frame_format)
    presentation.save("result.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Hämta tabellstilens egenskaper**

Använd [getStylePreset](https://reference.aspose.com/slides/python-java/aspose.slides/table/#getStylePreset) för att läsa en tabells förinställda stil och [setStylePreset](https://reference.aspose.com/slides/python-java/aspose.slides/table/#setStylePreset) för att tilldela den. Detta exempel tillämpar [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/python-java/aspose.slides/tablestylepreset/) på en tabell, skriver ut förinställningsvärdet och tilldelar samma förinställning till en andra tabell. Båda tabellerna sparas i `table-style.pptx`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TableStylePreset

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [100, 150]
    row_heights = [5, 5, 5]
    table = slide.getShapes().addTable(10, 10, column_widths, row_heights)
    table.setStylePreset(TableStylePreset.DarkStyle1)

    style_preset = table.getStylePreset()
    print("Table style preset: ", style_preset)

    another_table = slide.getShapes().addTable(10, 100, column_widths, row_heights)
    another_table.setStylePreset(style_preset)

    presentation.save("table-style.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Låsa bildförhållandet för en tabell**

En tabells bildförhållande är förhållandet mellan dess bredd och höjd. Använd [setAspectRatioLocked](https://reference.aspose.com/slides/python-java/aspose.slides/graphicalobjectlock/#setAspectRatioLocked) för att låsa detta förhållande för en tabell.

Exemplet nedan öppnar `pres.pptx`, som måste innehålla minst en bild med en tabell som dess första shape. Det skriver ut det aktuella låstillståndet, aktiverar låsning av bildförhållandet, skriver ut det uppdaterade tillståndet (`True`) och sparar resultatet som `pres-out.pptx`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Table

presentation = Presentation("pres.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    table = slide.getShapes().get_Item(0)

    print("Lock aspect ratio set: ", table.getGraphicalObjectLock().getAspectRatioLocked())

    table.getGraphicalObjectLock().setAspectRatioLocked(True)
    print("Lock aspect ratio set: ", table.getGraphicalObjectLock().getAspectRatioLocked())

    presentation.save("pres-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Kan jag aktivera höger-till-vänster (RTL) läsriktning för en hel tabell och texten i dess celler?**

Ja. Tabellen exponerar en [setRightToLeft](https://reference.aspose.com/slides/python-java/aspose.slides/table/#setRightToLeft)‑metod, och stycken har [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setRightToLeft). Genom att använda båda säkerställer du korrekt RTL‑ordning och renderning i cellerna.

**Hur kan jag förhindra att användare flyttar eller ändrar storlek på en tabell i den slutgiltiga filen?**

Använd [shape locks](/slides/sv/python-java/applying-protection-to-presentation/) för att inaktivera flytt, storleksändring, markering osv. Dessa lås gäller även för tabeller.

**Stöds det att infoga en bild i en cell som bakgrund?**

Ja. Du kan ange en [picture fill](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/) för en cell; bilden kommer att täcka cellområdet enligt valt läge (stretch eller tile).