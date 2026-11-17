---
title: Hantera tabellceller i presentationer med Python
linktitle: Hantera celler
type: docs
weight: 30
url: /sv/python-java/manage-cells/
keywords:
- tabellcell
- slå samman celler
- ta bort ram
- dela cell
- bild i cell
- bakgrundsfärg
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Hantera PowerPoint-tabellceller i Python: identifiera sammanslagna celler, ta bort ramar, dela celler och sätta bakgrundsfärger samt bilder med Aspose.Slides för Python via Java."
---
## **Översikt**

Aspose.Slides låter dig komma åt och ändra tabellceller i PowerPoint-presentationer. Den här artikeln förklarar hur du identifierar sammanslagna tabellceller, tar bort cellramar, arbetar med cellnumrering efter sammanslagning eller delning av celler, ändrar en cells bakgrundsfärg och lägger till en bild i en tabellcell. Exemplen visar hur du skapar eller öppnar en presentation, hämtar en tabell från en bild, uppdaterar cellformatering via cellegenskaper och sparar den ändrade presentationen som en PPTX‑fil.

Aspose.Slides använder nollbaserade index för att komma åt tabellceller i ordningen `(column, row)`.

## **Identifiera en sammanslagen tabellcell**

Exemplet öppnar en befintlig presentation och får åtkomst till den första formen på den första bilden som en tabell. Det förutsätter att bilden och formen finns och att formen är en tabell. Därefter itererar det genom alla rader och kolumner och använder [isMergedCell](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#isMergedCell) för att identifiera celler i sammanslagna områden. För varje matchning skriver det ut cellkoordinaterna i ordningen `row;column`, [getRowSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getRowSpan), [getColSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getColSpan) och regionens startkoordinater, [getFirstRowIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstRowIndex) och [getFirstColumnIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstColumnIndex).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation_with_table.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    table = slide.getShapes().get_Item(0)

    row_count = table.getRows().size()
    for row_index in range(row_count):
        column_count = table.getColumns().size()
        for column_index in range(column_count):
            cell = table.get_Item(column_index, row_index)
            if cell.isMergedCell():
                print(f"Cell {row_index};{column_index} belongs to a merged region with RowSpan={cell.getRowSpan()} and ColSpan={cell.getColSpan()} starting at {cell.getFirstRowIndex()};{cell.getFirstColumnIndex()}.")
finally:
    presentation.dispose()
```

## **Ta bort tabellcellramar**

Skapa en [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) och lägg till en tabell på dess första bild med [addTable](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addTable). Kolumnbredder, radhöjder och tabellens position anges i punkter. Exemplet sätter alla fyra cellramar till [FillType.NoFill](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/), vilket gör dem osynliga.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [50, 50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    for row in table.getRows():
        for cell in row:
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.NoFill)
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.NoFill)
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.NoFill)
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.NoFill)

    presentation.save("table.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Lägg till diagonala cellramar**

Använd [getBorderDiagonalDown](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderDiagonalDown) för att rita en linje från övre vänstra hörnet till nedre högra, och [getBorderDiagonalUp](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderDiagonalUp) för att rita en linje från nedre vänstra hörnet till övre högra. En diagonal kan markera en hörnrubrik. Båda diagonalerna kan bilda ett X för att markera att en cell inte är tillämplig.

Varje diagonal är ett [LineFormat](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/). I dess [getFillFormat](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#getFillFormat) använder du [setFillType](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#setFillType) för att välja [FillType.Solid](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/) och välja en färg via [getSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getSolidFillColor). Ställ in linjens bredd i punkter med [setWidth](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setWidth).

Exemplet skapar tre celler i en rad: en röd nedåtdiagonal, en blå uppåtdiagonal och båda diagonalerna. Det lämnar de övre, nedre, vänstra och högra cellramarna oförändrade.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat
from java.awt import Color


def format_border(border, color, width):
    fill = border.getFillFormat()
    fill.setFillType(FillType.Solid)
    fill.getSolidFillColor().setColor(color)
    border.setWidth(width)


presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    table = slide.getShapes().addTable(45, 130, [210, 210, 210], [160])

    left_cell = table.get_Item(0, 0).getCellFormat()
    middle_cell = table.get_Item(1, 0).getCellFormat()
    right_cell = table.get_Item(2, 0).getCellFormat()
    format_border(left_cell.getBorderDiagonalDown(), Color.RED, 3)
    format_border(middle_cell.getBorderDiagonalUp(), Color.BLUE, 5)
    format_border(right_cell.getBorderDiagonalDown(), Color.RED, 3)
    format_border(right_cell.getBorderDiagonalUp(), Color.BLUE, 5)

    presentation.save("diagonal_cell_borders.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

En diagonal är en formateringsegenskap, inte en celluppdelning. Varje cell behåller en enda textram, åtkomlig via [getTextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getTextFrame). Regionen på vardera sidan av en diagonal kan inte redigeras oberoende.

Den sparade tabellen, renderad i Microsoft PowerPoint:

![Tre tabellceller som visar en röd diagonal från övre vänstra till nedre högra, en blå diagonal från nedre vänstra till övre högra, och båda diagonalerna som bildar ett X.](diagonal-cell-borders.png)

*Från vänster till höger: nedåtdiagonal (röd, 3 pt), uppåtdiagonal (blå, 5 pt) och båda diagonalerna.*

## **Slå samman tabellceller**

Använd [mergeCells](https://reference.aspose.com/slides/python-java/aspose.slides/table/#mergeCells) för att kombinera ett rektangulärt område av tabellceller till en cell. Ange cellerna i det övre vänstra och nedre högra hörnet av området. Det sista argumentet styr om sammanslagningen får omfatta celler utanför det angivna området; `False` håller sammanslagningen inom det området.

Exemplet skapar en 4×4‑tabell med 70‑punkts kolumner och rader, och slår sedan samman de fyra centrala cellerna från `(1, 1)` till `(2, 2)`. Den resulterande cellen sträcker sig över två kolumner och två rader, medan tabellens underliggande rutnät behåller fyra kolumner och fyra rader. För att komma åt den sammanslagna cellens innehåll eller formatering, använd dess övre vänstra position: `table.get_Item(1, 1)` i detta exempel. De andra positionerna i det sammanslagna området förblir en del av tabellrutnätet, så indexen för celler utanför området ändras inte.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    table.mergeCells(table.get_Item(1, 1), table.get_Item(2, 2), False)

    presentation.save("merged_cells.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Dela tabellceller**

Att slå samman celler i föregående exempel bevarar tabellens rutnät. Att dela en cell kan introducera en ny kolumn i rutnätet och ändra kolumnindexen för cellerna till höger om den. Aspose.Slides följer PowerPoints tabellrutnätsmodell.

Detta exempel skapar en 4×4‑tabell med 70‑punkts kolumner och rader och anropar [splitByWidth](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByWidth) på cell `(1, 1)`. Hälften av cellens 70‑punkts bredd skickas för att skapa två lika breda celler.

Efter denna delning nås de två halvorna som `table.get_Item(1, 1)` och `table.get_Item(2, 1)`. Tabellrutnätet har nu fem kolumner: celler som ursprungligen låg i kolumn 2 och 3 flyttas till kolumn 3 respektive 4. Radrubrikerna förblir oförändrade. Använd dessa uppdaterade kolumnindex när du kommer åt celler efter delningen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    table.get_Item(1, 1).splitByWidth(table.get_Item(1, 1).getWidth() / 2)

    presentation.save("split_cells.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

<!-- visual-explanation:manage-cells:start -->
[![En osammanslagen 70‑punkts cell delas i två 35‑punkts celler, vilket lägger till en femte kolumn i rutnätet och flyttar indexen till höger.](visual-manage-cells-04c40789d81c.svg)](visual-manage-cells-04c40789d81c.svg)

*Bredddelningen påverkar cell (1, 1), med nollbaserade (column, row)-index. Andra rader behåller en cell som spänner över båda nya kolumnpositionerna.*
<!-- visual-explanation:manage-cells:end -->

### **Dela sammanslagna celler efter rad- eller kolumnspann**

För att förbereda sammanslagna mallceller för datainmatning, använd [splitByRowSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByRowSpan) för att dela längs en befintlig radgräns, eller [splitByColSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByColSpan) för att dela längs en kolumngräns.

`index`‑argumentet räknar rader i den övre delen eller kolumner i den vänstra delen av delningen; det är relativt till det sammanslagna området:

- Row split: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getRowSpan).
- Column split: `0 < index <` [getColSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getColSpan).

Exemplet förutsätter att en presentation har en tabell som den första formen på den första bilden, med `(1, 2)` och `(1, 3)` sammanslagna vertikalt. Med början från den lägre positionen använder det [getFirstColumnIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstColumnIndex) och [getFirstRowIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstRowIndex) för att lokalisera ursprunget och kontrollerar båda spannen. `splitByRowSpan(1)` separerar sedan raderna 2 och 3 för produktnamn. För en horisontell två‑kolumns sammanslagning, använd `splitByColSpan(1)` istället.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("table_template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    table = slide.getShapes().get_Item(0)

    selected_cell = table.get_Item(1, 3)
    first_column_index = selected_cell.getFirstColumnIndex()
    first_row_index = selected_cell.getFirstRowIndex()
    merged_cell = table.get_Item(first_column_index, first_row_index)

    if merged_cell.isMergedCell() and merged_cell.getRowSpan() == 2 and merged_cell.getColSpan() == 1:
        merged_cell.splitByRowSpan(1)

        # Hämta de resulterande cellerna från tabellen efter delning.
        upper_cell = table.get_Item(first_column_index, first_row_index)
        lower_cell = table.get_Item(first_column_index, first_row_index + 1)
        print(f"Upper cell merged: {upper_cell.isMergedCell()}")
        print(f"Lower cell merged: {lower_cell.isMergedCell()}")

        upper_cell.getTextFrame().setText("Product A")
        lower_cell.getTextFrame().setText("Product B")

        presentation.save("split_template.pptx", SaveFormat.Pptx)
    else:
        print("Select a merged region spanning exactly two rows and one column.")
finally:
    presentation.dispose()
```

Tabellrutnätet och omgivande cellindex förblir oförändrade. Hämta de resulterande cellerna via deras koordinater; här har båda ett spann på 1 och [isMergedCell](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#isMergedCell) skriver ut `False`. Större områden kan förbli delvis sammanslagna efter en delning.

Den ursprungliga texten och dess formatering förblir i den övre (eller vänstra) cellen; den nya cellen är tom men ärver cellformatering såsom fyllning, ramar och marginaler. Fyll i cellerna efter delning och ange eventuell nödvändig textformatering explicit.

Den sparade presentationen innehåller separata "Product A"- och "Product B"-celler med mallens cellformatering bevarad. Se [Cell API Reference](https://reference.aspose.com/slides/python-java/aspose.slides/cell/) för detaljer.

### **Dela en cell vid en specifik höjd**

[splitByHeight](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByHeight) tar höjden på den övre delen i punkter. [splitByRowSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByRowSpan) tar antalet befintliga rutnätsrader i den övre delen. För att centrera en 40‑punkts cell i den högra kolumnen, dra av 40 från cellens faktiska höjd och dela det återstående utrymmet lika över och under den.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    table = slide.getShapes().addTable(50, 50, [160, 160], [140])
    table.get_Item(0, 0).getTextFrame().setText("Left")

    height = table.get_Item(1, 0).getHeight()
    margin = (height - 40) / 2
    
    table.get_Item(1, 0).splitByHeight(margin)
    table.get_Item(1, 1).splitByHeight(40)
    table.get_Item(1, 1).getTextFrame().setText("Middle")

    presentation.save("split_by_height.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Den första delningen lägger till en rutnätsrad och lämnar de nedre 90 punkterna i cell `(1, 1)`. Den andra delningen delar den cellen i en 40‑punkts mittcell och en 50‑punkts bottencell. Den högra kolumnen har nu tre celler med höjderna 50, 40 och 50 punkter från toppen till botten. Den vänstra cellen sträcker sig över alla tre rader och behåller sin ursprungliga höjd på 140 punkter.

![Den vänstra cellen sträcker sig över hela tabellens höjd bredvid tre celler med Mitt i mitten.](split-by-height.png)

## **Ändra tabellcellens bakgrundsfärg**

Detta exempel skapar en tabell med 150‑punkts kolumner och 50‑punkts rader. Det använder [setFillType](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#setFillType) för att välja en solid fyllning och sätter färgen som returneras av [getSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getSolidFillColor) till röd för cell `(2, 3)`, i den tredje kolumnen och fjärde raden.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [150, 150, 150, 150]
    row_heights = [50, 50, 50, 50, 50]
    table = slide.getShapes().addTable(50, 50, column_widths, row_heights)

    cell = table.get_Item(2, 3)
    cell.getCellFormat().getFillFormat().setFillType(FillType.Solid)
    cell.getCellFormat().getFillFormat().getSolidFillColor().setColor(Color.RED)

    presentation.save("cell_background_color.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Lägg till en bild i en tabellcell**

Placera inmatningsbilden i arbetskatalogen innan du kör detta exempel. Den laddar bilden med [Images.fromFile](https://reference.aspose.com/slides/python-java/aspose.slides/images/#fromFile) och lägger till den i presentationens bildsamling med [addImage](https://reference.aspose.com/slides/python-java/aspose.slides/imagecollection/#addImage). Därefter tilldelas bilden till bildfyllningen av cell `(0, 0)`, den första cellen i tabellen.

[PictureFillMode.Stretch](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillmode/) sträcker bilden för att fylla cellen, vilket kan ändra dess bildförhållande. Kolumnbredder och radhöjder anges i punkter. Den inlästa bilden frigörs i ett `finally`‑block efter att den har lagts till i presentationen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Images, FillType, PictureFillMode, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [150, 150, 150, 150]
    row_heights = [100, 100, 100, 100, 90]
    table = slide.getShapes().addTable(50, 50, column_widths, row_heights)

    image = Images.fromFile("aspose_logo.jpg")
    try:
        presentation_image = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    table.get_Item(0, 0).getCellFormat().getFillFormat().setFillType(FillType.Picture)
    table.get_Item(0, 0).getCellFormat().getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch)
    table.get_Item(0, 0).getCellFormat().getFillFormat().getPictureFillFormat().getPicture().setImage(presentation_image)

    presentation.save("table_cell_with_image.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Vanliga frågor**

**Kan jag ange olika linjetjocklekar och stilar för de olika sidorna av en enda cell?**

Ja. Ramarna för [top](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderTop)/[bottom](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderBottom)/[left](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderLeft)/[right](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderRight) har separata egenskaper, så tjocklek och stil för varje sida kan skilja sig.

**Vad händer med bilden om jag ändrar kolumn-/radstorlek efter att ha satt en bild som cellens bakgrund?**

Beteendet beror på [fill mode](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillmode/). Vid stretchning anpassas bilden till den nya cellen; vid tile‑läge beräknas kakelsektionen om.

**Kan jag tilldela en hyperlänk till allt innehåll i en cell?**

[Hyperlinks](/slides/sv/python-java/manage-hyperlinks/) sätts på text‑ (portion)‑nivå inuti cellens textram eller på hela tabellens/formens nivå. I praktiken tilldelar du länken till en del eller till all text i cellen.

**Kan jag ange olika typsnitt inom en enda cell?**

Ja. En cells textram stödjer [portions](https://reference.aspose.com/slides/python-java/aspose.slides/portion/) (körningar) med oberoende formatering — typsnittsfamilj, stil, storlek och färg.