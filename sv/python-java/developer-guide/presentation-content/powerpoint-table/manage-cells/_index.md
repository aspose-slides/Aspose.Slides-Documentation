---
title: Hantera tabellceller i presentationer med Python
linktitle: Hantera celler
type: docs
weight: 30
url: /sv/python-java/manage-cells/
keywords:
- tabellcell
- slå ihop celler
- ta bort ram
- dela cell
- bild i cell
- bakgrundsfärg
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Hantera PowerPoint-tabellceller i Python: identifiera sammanslagna celler, ta bort ramar, dela celler och ange bakgrundsfärger samt bilder med Aspose.Slides för Python via Java."
---
## **Översikt**

Aspose.Slides låter dig komma åt och ändra tabellceller i PowerPoint-presentationer. Denna artikel förklarar hur du identifierar sammanslagna tabellceller, tar bort cellramar, arbetar med cellnumrering efter sammanslagning eller delning av celler, ändrar en cells bakgrundsfärg och lägger till en bild i en tabellcell. Exemplen visar hur du skapar eller öppnar en presentation, hämtar en tabell från en bild, uppdaterar cellformatering via cellens egenskaper och sparar den modifierade presentationen som en PPTX‑fil.

Aspose.Slides använder nollbaserade index för att komma åt tabellceller i ordningen `(column, row)`.

## **Identifiera en sammanslagen tabellcell**

Exemplet öppnar en befintlig presentation och får åtkomst till den första formen på den första bilden som en tabell. Det förutsätter att bilden och formen finns och att formen är en tabell. Därefter itererar det genom alla rader och kolumner och använder [isMergedCell](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#isMergedCell) för att identifiera celler i sammanslagna områden. För varje träff skriver det ut cellkoordinaterna i ordningen `row;column`, [getRowSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getRowSpan), [getColSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getColSpan) och regionens startkoordinater, [getFirstRowIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstRowIndex) och [getFirstColumnIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstColumnIndex).

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

## **Sammanfoga tabellceller**

Använd [mergeCells](https://reference.aspose.com/slides/python-java/aspose.slides/table/#mergeCells) för att kombinera ett rektangulärt område av tabellceller till en cell. Specificera cellerna i det övre vänstra och nedre högra hörnet av området. Det sista argumentet styr om sammanslagningen får inkludera celler utanför det angivna området; `False` håller sammanslagningen inom det området.

Exemplet skapar en 4 × 4‑tabell med 70‑punkts kolumner och rader, och sammanslår sedan de fyra centrala cellerna från `(1, 1)` till `(2, 2)`. Den resulterande cellen spänner över två kolumner och två rader, medan tabellens underliggande rutnät behåller fyra kolumner och fyra rader. För att komma åt den sammanslagna cellens innehåll eller formatering, använd dess övre vänstra position: `table.get_Item(1, 1)` i detta exempel. De andra positionerna i det sammanslagna området förblir en del av tabellrutnätet, så indexen för celler utanför området ändras inte.

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

Att sammanfoga celler i det föregående exemplet bevarar tabellens rutnät. Att dela en cell kan införa en ny rutnätskolumn och ändra kolumnindex för celler till höger. Aspose.Slides följer PowerPoints tabellrutnätsmodell.

Detta exempel skapar en 4 × 4‑tabell med 70‑punkts kolumner och rader och anropar [splitByWidth](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByWidth) på cell `(1, 1)`. Halva cellens 70‑punkts bredd skickas för att skapa två celler med lika bredd.

Efter den här delningen nås de två halvorna som `table.get_Item(1, 1)` och `table.get_Item(2, 1)`. Tabellrutnätet har nu fem kolumner: celler som ursprungligen var i kolumn 2 och 3 flyttas till kolumn 3 respektive 4. Radrubrikerna förblir oförändrade. Använd dessa uppdaterade kolumnindex när du får åtkomst till celler efter delningen.

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

### **Dela sammanslagna celler efter rad- eller kolumnspann**

För att förbereda sammanslagna mallceller för datainmatning, använd [splitByRowSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByRowSpan) för att dela längs en befintlig radgräns, eller [splitByColSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByColSpan) för att dela längs en kolumngräns.

`index`‑argumentet räknar rader i den övre delen eller kolumner i den vänstra delen av delningen; det är relativt till det sammanslagna området:

- Row split: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getRowSpan).
- Column split: `0 < index <` [getColSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getColSpan).

Exemplet förutsätter att en presentation har en tabell som den första formen på den första bilden, med `(1, 2)` och `(1, 3)` sammanslagna vertikalt. Med start från den lägre positionen används [getFirstColumnIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstColumnIndex) och [getFirstRowIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstRowIndex) för att lokalisera ursprunget och kontrollera båda spannen. `splitByRowSpan(1)` delar sedan raderna 2 och 3 för produktnamn. För en horisontell sammanslagning av två kolumner, använd `splitByColSpan(1)` istället.

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

Tabellrutnätet och omkringliggande cellindex förblir oförändrade. Hämta de resulterande cellerna via deras koordinater; här har båda ett spann på 1 och [isMergedCell](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#isMergedCell) skriver ut `False`. Större områden kan förbli delvis sammanslagna efter en delning.

Den ursprungliga texten och dess formatering förblir i den övre (eller vänstra) cellen; den nya cellen är tom men ärver cellformatering såsom fyllning, ramar och marginaler. Fyll i cellerna efter delning och ange eventuell nödvändig textformatering explicit.

Den sparade presentationen innehåller separata celler för "Product A" och "Product B" med mallens cellformatering bevarad. Se [Cell API Reference](https://reference.aspose.com/slides/python-java/aspose.slides/cell/) för detaljer.

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

Placera inmatningsbilden i arbetskatalogen innan du kör detta exempel. Den laddar bilden med [Images.fromFile](https://reference.aspose.com/slides/python-java/aspose.slides/images/#fromFile) och lägger till den i presentationens bildsamling med [addImage](https://reference.aspose.com/slides/python-java/aspose.slides/imagecollection/#addImage). Den tilldelar sedan bilden till bildfyllningen för cell `(0, 0)`, den första cellen i tabellen.

[PictureFillMode.Stretch](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillmode/) sträcker bilden för att fylla cellen, vilket kan ändra bildförhållandet. Kolumnbredder och radhöjder anges i punkter. Den inlästa bilden avaktiveras i ett `finally`‑block efter att den har lagts till i presentationen.

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

## **FAQ**

**Kan jag ange olika linjetjocklekar och stilar för olika sidor av en enskild cell?**

Ja. [top](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderTop)/[bottom](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderBottom)/[left](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderLeft)/[right](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderRight)-ramarna har separata egenskaper, så tjocklek och stil för varje sida kan skilja sig.

**Vad händer med bilden om jag ändrar kolumn-/radstorlek efter att ha ställt in en bild som cellens bakgrund?**

Beteendet beror på [fill mode](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillmode/) (stretch/tile). Vid sträckning anpassas bilden till den nya cellen; vid tilning beräknas rutorna om.

**Kan jag tilldela en hyperlänk till allt innehåll i en cell?**

[Hyperlinks](/slides/sv/python-java/manage-hyperlinks/) sätts på text‑ (portion) nivå inne i cellens textram eller på hela tabellens/formens nivå. I praktiken tilldelar du länken till en portion eller till all text i cellen.

**Kan jag ange olika teckensnitt inom en enskild cell?**

Ja. En cells textram stödjer [portions](https://reference.aspose.com/slides/python-java/aspose.slides/portion/) (körningar) med oberoende formatering — teckensnittsfamilj, stil, storlek och färg.