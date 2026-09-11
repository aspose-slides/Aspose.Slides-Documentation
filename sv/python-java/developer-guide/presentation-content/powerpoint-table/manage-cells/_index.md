---
title: Hantera tabellceller i presentationer med Python
linktitle: Hantera celler
type: docs
weight: 30
url: /sv/python-java/manage-cells/
keywords:
- tabellcell
- sammanfoga celler
- ta bort ram
- dela cell
- bild i cell
- bakgrundsfärg
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Hantera tabellceller i PowerPoint med Aspose.Slides för Python via Java utan ansträngning. Bemästra åtkomst, modifiering och formatering av celler snabbt för sömlös bildspelsautomatisering."
---
## **Översikt**

Aspose.Slides låter dig komma åt och ändra tabellceller i PowerPoint-presentationer. Denna artikel förklarar hur du identifierar sammanslagna tabellceller, tar bort cellramar, arbetar med cellnumrering efter sammanslagning eller delning av celler, ändrar en cells bakgrundsfärg och lägger till en bild i en tabellcell. Exemplen visar hur du skapar eller öppnar en presentation, får en tabell från en bild, uppdaterar cellformatering via cellens egenskaper och sparar den ändrade presentationen som en PPTX‑fil.

## **Identifiera en sammanslagen tabellcell**

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/).
2. Hämta tabellen från den första bilden.
3. Iterera genom tabellens rader och kolumner för att hitta sammanslagna celler.
4. Skriv ut ett meddelande när sammanslagna celler hittas.

Denna Python‑kod visar hur du identifierar sammanslagna tabellceller i en presentation:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Table

presentation = Presentation("SomePresentationWithTable.pptx")
try:
    # Anta att den första formen på den första bilden är en tabell.
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(shape, Table):
        table = shape
        for i in range(table.getRows().size()):
            for j in range(table.getColumns().size()):
                current_cell = table.getRows().get_Item(i).get_Item(j)
                if current_cell.isMergedCell():
                    print(f"Cell {i};{j} is part of a merged cell with RowSpan={current_cell.getRowSpan()} and ColSpan={current_cell.getColSpan()} starting from Cell {current_cell.getFirstRowIndex()};{current_cell.getFirstColumnIndex()}.")
    else:
        print("The first shape is not a table.")
finally:
    presentation.dispose()
```

## **Ta bort tabellcellramar**

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/).
2. Hämta en referens till en bild via dess index.
3. Definiera en lista med kolumnbredder.
4. Definiera en lista med radhöjder.
5. Lägg till en tabell på bilden via metoden [addTable](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shapecollection/#addTable).
6. Iterera genom varje cell för att rensa de övre, nedre, högra och vänstra ramarna.
7. Spara den ändrade presentationen som en PPTX‑fil.

Denna Python‑kod visar hur du tar bort ramarna från tabellceller:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat

presentation = Presentation()
try:
    # Åtkomst till den första bilden.
    slide = presentation.getSlides().get_Item(0)

    # Definiera kolumnbredder och radhöjder.
    column_widths = [50, 50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]

    # Lägg till en tabell på bilden.
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    # Ställ in ramformatet för varje cell.
    for row in table.getRows():
        for cell in row:
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.NoFill)
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.NoFill)
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.NoFill)
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.NoFill)

    # Spara presentationen som en PPTX-fil.
    presentation.save("table_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Numrering i sammanslagna celler**

Om vi slår ihop två par celler, (1, 1) och (2, 1), samt (1, 2) och (2, 2), behåller den resulterande tabellen sin cellnumrering. Denna Python‑kod demonstrerar processen:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # Åtkomst till den första bilden.
    slide = presentation.getSlides().get_Item(0)

    # Definiera kolumnbredder och radhöjder.
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # Lägg till en tabell på bilden.
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    # Ställ in ramformatet för varje cell.
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


    # Slå ihop cellerna (1, 1) och (2, 1).
    table.mergeCells(table.get_Item(1, 1), table.get_Item(2, 1), False)

    # Slå ihop cellerna (1, 2) och (2, 2).
    table.mergeCells(table.get_Item(1, 2), table.get_Item(2, 2), False)

    # Spara presentationen som en PPTX-fil.
    presentation.save("MergeCells_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Vi slår sedan ihop cellerna ytterligare genom att slå ihop (1, 1) och (1, 2). Resultatet är en tabell som innehåller en stor sammanslagen cell i mitten:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # Åtkomst till den första bilden.
    slide = presentation.getSlides().get_Item(0)

    # Definiera kolumnbredder och radhöjder.
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # Lägg till en tabell på bilden.
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    # Ställ in ramformatet för varje cell.
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


    # Slå ihop cellerna (1, 1) och (2, 1).
    table.mergeCells(table.get_Item(1, 1), table.get_Item(2, 1), False)

    # Slå ihop cellerna (1, 2) och (2, 2).
    table.mergeCells(table.get_Item(1, 2), table.get_Item(2, 2), False)

    # Slå ihop cellerna (1, 1) och (1, 2).
    table.mergeCells(table.get_Item(1, 1), table.get_Item(1, 2), True)

    # Spara presentationen som en PPTX-fil.
    presentation.save("MergeCells_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Numrering i en delad cell**

I de föregående exemplen förändrade inte sammanslagning av tabellceller numreringen av de andra cellerna.

Denna gång tar vi en vanlig tabell (en tabell utan sammanslagna celler) och försöker sedan dela cell (1, 1) för att få en speciell tabell. Du kanske vill uppmärksamma tabellens numrering, som kan verka märklig. Detta är dock så Microsoft PowerPoint numrerar tabellceller och Aspose.Slides gör samma sak.

Denna Python‑kod demonstrerar processen vi beskrev:

```python
import jpype
import asposeslides

if not jp.ype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # Åtkomst till den första bilden.
    slide = presentation.getSlides().get_Item(0)

    # Definiera kolumnbredder och radhöjder.
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # Lägg till en tabell på bilden.
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    # Ställ in ramformatet för varje cell.
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


    # Dela cell (1, 1).
    table.get_Item(1, 1).splitByWidth(table.get_Item(2, 1).getWidth() / 2)

    # Spara presentationen som en PPTX-fil.
    presentation.save("SplitCells_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ändra tabellcellens bakgrundsfärg**

Denna Python‑kod visar hur du ändrar en tabellcells bakgrundsfärg:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # Åtkomst till den första bilden.
    slide = presentation.getSlides().get_Item(0)

    # Definiera kolumnbredder och radhöjder.
    column_widths = [150, 150, 150, 150]
    row_heights = [50, 50, 50, 50, 50]

    # Lägg till en tabell på bilden.
    table = slide.getShapes().addTable(50, 50, column_widths, row_heights)

    # Ställ in bakgrundsfärg för en cell.
    cell = table.get_Item(2, 3)
    cell.getCellFormat().getFillFormat().setFillType(FillType.Solid)
    cell.getCellFormat().getFillFormat().getSolidFillColor().setColor(Color.RED)

    # Spara presentationen som en PPTX-fil.
    presentation.save("cell_background_color.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Lägg till en bild i en tabellcell**

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/).
2. Hämta en referens till en bild via dess index.
3. Definiera en lista med kolumnbredder.
4. Definiera en lista med radhöjder.
5. Lägg till en tabell på bilden via metoden [addTable](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shapecollection/#addTable).
6. Läs in bildfilen med [Images.fromFile](https://reference.aspose.com/slides/sv/python-java/aspose.slides/images/#fromFile).
7. Lägg till bilden i presentationen för att skapa ett [PPImage](https://reference.aspose.com/slides/sv/python-java/aspose.slides/ppimage/)‑objekt.
8. Ställ in tabellcellens [FillFormat](https://reference.aspose.com/slides/sv/python-java/aspose.slides/fillformat/) fylltyp till [FillType.Picture](https://reference.aspose.com/slides/sv/python-java/aspose.slides/filltype/#Picture).
9. Lägg till bilden i tabellens första cell.
10. Spara den ändrade presentationen som en PPTX‑fil.

Denna Python‑kod visar hur du placerar en bild i en tabellcell när du skapar en tabell:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Images, FillType, PictureFillMode, SaveFormat

presentation = Presentation()
try:
    # Åtkomst till den första bilden.
    slide = presentation.getSlides().get_Item(0)

    # Definiera kolumnbredder och radhöjder.
    column_widths = [150, 150, 150, 150]
    row_heights = [100, 100, 100, 100, 90]

    # Lägg till en tabell på bilden.
    table = slide.getShapes().addTable(50, 50, column_widths, row_heights)

    # Skapa en presentationsbild från bildfilen.
    image = Images.fromFile("image.jpg")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    # Lägg till bilden i den första tabellcellen.
    cell_format = table.get_Item(0, 0).getCellFormat()
    cell_format.getFillFormat().setFillType(FillType.Picture)
    cell_format.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch)
    cell_format.getFillFormat().getPictureFillFormat().getPicture().setImage(picture)

    # Spara presentationen som en PPTX-fil.
    presentation.save("Image_In_TableCell_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Kan jag ange olika linjetjocklekar och stilar för olika sidor av en enda cell?**

Ja. [top](https://reference.aspose.com/slides/sv/python-java/aspose.slides/cellformat/#getBorderTop)/[bottom](https://reference.aspose.com/slides/sv/python-java/aspose.slides/cellformat/#getBorderBottom)/[left](https://reference.aspose.com/slides/sv/python-java/aspose.slides/cellformat/#getBorderLeft)/[right](https://reference.aspose.com/slides/sv/python-java/aspose.slides/cellformat/#getBorderRight)‑ramarna har separata egenskaper, så tjocklek och stil för varje sida kan skilja sig. Detta följer logiskt från per‑sidans ramkontroll för en cell som demonstreras i artikeln.

**Vad händer med bilden om jag ändrar kolumn‑/radstorleken efter att ha ställt in en bild som cellens bakgrund?**

Beteendet beror på [fill mode](https://reference.aspose.com/slides/sv/python-java/aspose.slides/picturefillmode/) (stretch/tile). Vid stretching anpassas bilden till den nya cellen; vid tiling beräknas rutorna om. Artikeln nämner bildens visningslägen i en cell.

**Kan jag tilldela en hyperlänk till allt innehåll i en cell?**

[Hyperlinks](/slides/sv/python-java/manage-hyperlinks/) sätts på text‑ (portion)‑nivå inuti cellens textram eller på hela tabellens/figurens nivå. I praktiken tilldelar du länken till en del eller till all text i cellen.

**Kan jag ange olika teckensnitt i en enda cell?**

Ja. En cells textram stödjer [portions](https://reference.aspose.com/slides/sv/python-java/aspose.slides/portion/) (körningar) med oberoende formatering—teckensnittsfamilj, stil, storlek och färg.