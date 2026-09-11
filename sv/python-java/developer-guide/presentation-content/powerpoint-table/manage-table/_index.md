---
title: Hantera presentationstabeller i Python
linktitle: Hantera tabell
type: docs
weight: 10
url: /sv/python-java/manage-table/
keywords:
- lägg till tabell
- skapa tabell
- åtkomst tabell
- bildförhållande
- justera text
- textformatering
- tabellstil
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Skapa och redigera tabeller i PowerPoint-bilder med Aspose.Slides för Python via Java. Upptäck enkla kodexempel för att förenkla ditt tabellarbetsflöde."
---
## **Introduktion**

En tabell i PowerPoint är ett effektivt sätt att visa information. Informationen i ett rutnät av celler (ordnade i rader och kolumner) är enkel och lätt att förstå.

Aspose.Slides tillhandahåller klassen [Table](https://reference.aspose.com/slides/sv/python-java/aspose.slides/table/), klassen [Cell](https://reference.aspose.com/slides/sv/python-java/aspose.slides/cell/) samt andra typer för att låta dig skapa, uppdatera och hantera tabeller i alla slags presentationer.

## **Skapa en tabell från grunden**

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/).
2. Hämta en referens till en bildruta via dess index.
3. Definiera en lista med kolumnbredder.
4. Definiera en lista med radhöjder.
5. Lägg till ett [Table](https://reference.aspose.com/slides/sv/python-java/aspose.slides/table/) objekt till bilden genom metoden [addTable](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shapecollection/#addTable).
6. Iterera genom varje [Cell](https://reference.aspose.com/slides/sv/python-java/aspose.slides/cell/) för att tillämpa formatering på de övre, nedre, högra och vänstra kanterna.
7. Sammanfoga de två första cellerna i tabellens första rad.
8. Få åtkomst till en [Cell](https://reference.aspose.com/slides/sv/python-java/aspose.slides/cell/)'s [TextFrame](https://reference.aspose.com/slides/sv/python-java/aspose.slides/textframe/).
9. Lägg till lite text i [TextFrame](https://reference.aspose.com/slides/sv/python-java/aspose.slides/textframe/).
10. Spara den ändrade presentationen.

Den här Python‑koden visar hur du skapar en tabell i en presentation:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

# Skapar en Presentation-klass som representerar en PPTX-fil
presentation = Presentation()
try:

    # Hämtar den första bilden
    slide = presentation.getSlides().get_Item(0)

    # Definierar kolumner med bredder och rader med höjder
    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]

    # Lägger till ett tabellform på bilden
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    # Ställer in kantformat för varje cell
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

    # Sammanfogar cellerna 1 och 2 i rad 1
    table.mergeCells(table.getRows().get_Item(0).get_Item(0), table.getRows().get_Item(0).get_Item(1), False)

    # Lägger till text i den sammanslagna cellen
    table.getRows().get_Item(0).get_Item(0).getTextFrame().setText("Merged Cells")

    # Sparar presentationen till disk
    presentation.save("table.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Numrering i en standardtabell**

I en standardtabell är numreringen av celler enkel och nollbaserad. Den första cellen i en tabell har indexet 0,0 (kolumn 0, rad 0).

Till exempel numreras cellerna i en tabell med 4 kolumner och 4 rows på följande sätt:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Den här Python‑koden visar hur du skapar en tabell med standardcellnumrering:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

# Skapar en Presentation-klass som representerar en PPTX-fil
presentation = Presentation()
try:

    # Hämtar första bilden
    slide = presentation.getSlides().get_Item(0)

    # Definierar kolumner med bredder och rader med höjder
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # Lägger till ett tabellform på bilden
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    # Ställer in kantformat för varje cell
    for row in table.getRows():
        for cell in row:
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderTop().setWidth(5)
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderBottom().setWidth(5)
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderLeft().setWidth(5)
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderRight().setWidth(5)

    # Sparar presentationen till disk
    presentation.save("StandardTables_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Åtkomst till en befintlig tabell**

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/).
2. Hämta en referens till bilden som innehåller tabellen via dess index.
3. Initiera en variabel för ett [Table](https://reference.aspose.com/slides/sv/python-java/aspose.slides/table/)‑objekt och sätt den till `None`.
4. Iterera genom alla [Shape](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shape/)‑objekt tills tabellen hittas.

   Om du misstänker att bilden du arbetar med innehåller en enda tabell kan du helt enkelt kontrollera alla dess former. När en form identifieras som en tabell kan du använda den som ett [Table](https://reference.aspose.com/slides/sv/python-java/aspose.slides/table/)‑objekt. Men om bilden du arbetar med innehåller flera tabeller är det bättre att söka efter den tabell du behöver via dess [getAlternativeText](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shape/#getAlternativeText).

5. Använd [Table](https://reference.aspose.com/slides/sv/python-java/aspose.slides/table/)‑objektet för att arbeta med tabellen. I exemplet nedan uppdaterar vi texten i den första kolumnen i den andra raden.
6. Spara den ändrade presentationen.

Den här Python‑koden visar hur du får åtkomst till och arbetar med en befintlig tabell:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Table

# Skapar en Presentation-klass som representerar en PPTX-fil
presentation = Presentation("UpdateExistingTable.pptx")
try:

    # Hämtar den första bilden
    slide = presentation.getSlides().get_Item(0)

    # Initierar tabellreferensen.
    table = None

    # Itererar genom formerna och sätter en referens till den hittade tabellen
    for shape in slide.getShapes():
        if isinstance(shape, Table):
            table = shape

            # Sätter texten för den första kolumnen i den andra raden
            table.get_Item(0, 1).getTextFrame().setText("New")

    # Sparar den ändrade presentationen till disk
    presentation.save("table1_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Hitta cellen som äger en TextFrame**

När generell textbehandlingskod får en [TextFrame](https://reference.aspose.com/slides/sv/python-java/aspose.slides/textframe/) från en tabell, använd metoden [TextFrame.getParentCell](https://reference.aspose.com/slides/sv/python-java/aspose.slides/textframe/#getParentCell) för att hämta den ägande [Cell](https://reference.aspose.com/slides/sv/python-java/aspose.slides/cell/). För en tabellcellen TextFrame returnerar [TextFrame.getParentCell](https://reference.aspose.com/slides/sv/python-java/aspose.slides/textframe/#getParentCell) ägaren och [TextFrame.getParentShape](https://reference.aspose.com/slides/sv/python-java/aspose.slides/textframe/#getParentShape) returnerar `None`, även om själva tabellen är en form.

Cellkoordinaterna är tillgängliga via de skrivskyddade metoderna [Cell.getFirstColumnIndex](https://reference.aspose.com/slides/sv/python-java/aspose.slides/cell/#getFirstColumnIndex) och [Cell.getFirstRowIndex](https://reference.aspose.com/slides/sv/python-java/aspose.slides/cell/#getFirstRowIndex). [TextFrame.getParentCell](https://reference.aspose.com/slides/sv/python-java/aspose.slides/textframe/#getParentCell) ger också skrivskyddad navigation: den returnerar ägaren men ändrar inte ägarskap. Kontrollera alltid om den returnerade cellen är `None` innan du använder den.

För ett komplett exempel som identifierar ägare av tabellceller och former, inklusive former kopplade till SmartArt‑noder, se [Search and Replace Text](/slides/sv/python-java/search-and-replace-text/).

## **Justera text i en tabell**

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/).
2. Hämta en referens till en bildruta via dess index.
3. Lägg till ett [Table](https://reference.aspose.com/slides/sv/python-java/aspose.slides/table/)‑objekt på bilden.
4. Få åtkomst till ett [TextFrame](https://reference.aspose.com/slides/sv/python-java/aspose.slides/textframe/)‑objekt från tabellen.
5. Få åtkomst till [TextFrame](https://reference.aspose.com/slides/sv/python-java/aspose.slides/textframe/)-objektets [Paragraph](https://reference.aspose.com/slides/sv/python-java/aspose.slides/paragraph/).
6. Justera texten vertikalt.
7. Spara den ändrade presentationen.

Den här Python‑koden visar hur du justerar texten i en tabell:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, TextAnchorType, TextVerticalType
from java.awt import Color

# Skapar en instans av Presentation-klassen
presentation = Presentation()
try:

    # Hämtar den första bilden
    slide = presentation.getSlides().get_Item(0)

    # Definierar kolumner med bredd och rader med höjd
    column_widths = [120, 120, 120, 120]
    row_heights = [100, 100, 100, 100]

    # Lägger till tabellformen på bilden
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)
    table.get_Item(1, 0).getTextFrame().setText("10")
    table.get_Item(2, 0).getTextFrame().setText("20")
    table.get_Item(3, 0).getTextFrame().setText("30")

    # Hämtar textramen
    text_frame = table.get_Item(0, 0).getTextFrame()

    # Hämtar det första stycket i textramen.
    paragraph = text_frame.getParagraphs().get_Item(0)

    # Hämtar den första delen i stycket.
    portion = paragraph.getPortions().get_Item(0)
    portion.setText("Text here")
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)

    # Justera texten vertikalt
    cell = table.get_Item(0, 0)
    cell.setTextAnchorType(TextAnchorType.Center)
    cell.setTextVerticalType(TextVerticalType.Vertical270)

    # Sparar presentationen till disk
    presentation.save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ställ in textformatering på tabellnivå**

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/).
2. Hämta en referens till en bildruta via dess index.
3. Få åtkomst till ett [Table](https://reference.aspose.com/slides/sv/python-java/aspose.slides/table/)‑objekt från bilden.
4. Ställ in textens teckenhöjd med [setFontHeight](https://reference.aspose.com/slides/sv/python-java/aspose.slides/baseportionformat/#setFontHeight).
5. Ställ in justeringen och högermarginalen med [setAlignment](https://reference.aspose.com/slides/sv/python-java/aspose.slides/paragraphformat/#setAlignment) och [setMarginRight](https://reference.aspose.com/slides/sv/python-java/aspose.slides/paragraphformat/#setMarginRight).
6. Ställ in vertikal texttyp med [setTextVerticalType](https://reference.aspose.com/slides/sv/python-java/aspose.slides/textframeformat/#setTextVerticalType).
7. Spara den ändrade presentationen.

Den här Python‑koden visar hur du applicerar dina föredragna formateringsalternativ på texten i en tabell:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ParagraphFormat, PortionFormat, Presentation, SaveFormat, TextAlignment, TextFrameFormat, TextVerticalType, Table

# Skapar en instans av Presentation-klassen
presentation = Presentation("simpletable.pptx")
try:

    # Anta att den första formen på den första bilden är en tabell
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(shape, Table):
        table = shape

        # Ställer in teckenhöjden för tabellcellerna
        portion_format = PortionFormat()
        portion_format.setFontHeight(25)
        table.setTextFormat(portion_format)

        # Ställer in textjustering och högermarginal för tabellcellerna i ett anrop
        paragraph_format = ParagraphFormat()
        paragraph_format.setAlignment(TextAlignment.Right)
        paragraph_format.setMarginRight(20)
        table.setTextFormat(paragraph_format)

        # Ställer in vertikal texttyp för tabellcellerna
        text_frame_format = TextFrameFormat()
        text_frame_format.setTextVerticalType(TextVerticalType.Vertical)
        table.setTextFormat(text_frame_format)
        presentation.save("result.pptx", SaveFormat.Pptx)
    else:
        print("The first shape is not a table.")
finally:
    presentation.dispose()
```

## **Hämta tabellstilens egenskaper**

Aspose.Slides låter dig hämta stilegenskaper för en tabell så att du kan använda dessa uppgifter för en annan tabell eller någon annanstans. Den här Python‑koden visar hur du får stilegenskaperna från en förinställd tabellstil:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TableStylePreset

presentation = Presentation()
try:
    table = presentation.getSlides().get_Item(0).getShapes().addTable(10, 10, [100, 150], [5, 5, 5])
    table.setStylePreset(TableStylePreset.DarkStyle1)  # ändra standardtema för stilinställning

    # Hämtar stilinställningen för tabellen
    style_preset = table.getStylePreset()
    print("Table style preset: ", style_preset)

    # Tillämpar den hämtade stilinställningen på en annan tabell
    another_table = presentation.getSlides().get_Item(0).getShapes().addTable(10, 100, [100, 150], [5, 5, 5])
    another_table.setStylePreset(style_preset)
    presentation.save("table.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Lås bildförhållandet för en tabell**

Bildförhållandet för en geometrisk form är förhållandet mellan dess storlekar i olika dimensioner. Aspose.Slides tillhandahåller metoden [setAspectRatioLocked](https://reference.aspose.com/slides/sv/python-java/aspose.slides/graphicalobjectlock/#setAspectRatioLocked) för att låta dig låsa bildförhållandet för tabeller och andra former.

Den här Python‑koden visar hur du låser bildförhållandet för en tabell:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Table

presentation = Presentation("pres.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(shape, Table):
        table = shape
        print("Lock aspect ratio set: ", table.getGraphicalObjectLock().getAspectRatioLocked())
        table.getGraphicalObjectLock().setAspectRatioLocked(not table.getGraphicalObjectLock().getAspectRatioLocked())  # invertera
        print("Lock aspect ratio set: ", table.getGraphicalObjectLock().getAspectRatioLocked())
        presentation.save("pres-out.pptx", SaveFormat.Pptx)
    else:
        print("The first shape is not a table.")
finally:
    presentation.dispose()
```

## **FAQ**

**Kan jag aktivera höger-till-vänster (RTL) läsriktning för en hel tabell och texten i dess celler?**

Ja. Tabellen har en [setRightToLeft](https://reference.aspose.com/slides/sv/python-java/aspose.slides/table/#setRightToLeft)‑metod, och stycken har [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/sv/python-java/aspose.slides/paragraphformat/#setRightToLeft). Att använda båda säkerställer korrekt RTL‑ordning och rendering i cellerna.

**Hur kan jag hindra användare från att flytta eller ändra storlek på en tabell i den slutliga filen?**

Använd [shape locks](/slides/sv/python-java/applying-protection-to-presentation/) för att inaktivera flytt, storleksändring, val osv. Dessa lås gäller även för tabeller.

**Stöds det att infoga en bild som bakgrund i en cell?**

Ja. Du kan ange en [picture fill](https://reference.aspose.com/slides/sv/python-java/aspose.slides/picturefillformat/) för en cell; bilden kommer att täcka cellområdet enligt det valda läget (sträcka eller mosaik).