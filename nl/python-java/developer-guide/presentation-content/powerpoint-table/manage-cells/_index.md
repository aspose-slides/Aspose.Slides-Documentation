---
title: Beheer tabelcellen in presentaties met Python
linktitle: Beheer cellen
type: docs
weight: 30
url: /nl/python-java/manage-cells/
keywords:
- tabelcel
- cellen samenvoegen
- rand verwijderen
- cel splitsen
- afbeelding in cel
- achtergrondkleur
- PowerPoint
- presentatie
- Python
- Aspose.Slides
description: "Beheer PowerPoint‑tabelcellen in Python: identificeer samengevoegde cellen, verwijder randen, split cellen, en stel achtergrondkleuren en afbeeldingen in met Aspose.Slides voor Python via Java."
---
## **Overzicht**

Aspose.Slides stelt u in staat om tabelcellen in PowerPoint‑presentaties te benaderen en te wijzigen. Dit artikel legt uit hoe u samengevoegde tabelcellen kunt identificeren, celranden kunt verwijderen, met celnummering kunt werken na het samenvoegen of splitsen van cellen, de achtergrondkleur van een cel kunt wijzigen en een afbeelding in een tabelcel kunt toevoegen. De voorbeelden tonen hoe u een presentatie maakt of opent, een tabel van een dia haalt, celopmaak bijwerkt via cel‑eigenschappen, en de gewijzigde presentatie opslaat als een PPTX‑bestand.

Aspose.Slides gebruikt nulgebaseerde indexen om tabelcellen te benaderen in de volgorde `(kolom, rij)`.

## **Een samengevoegde tabelcel identificeren**

Het voorbeeld opent een bestaande presentatie en benadert de eerste vorm op de eerste dia als een tabel. Het gaat ervan uit dat de dia en vorm bestaan en dat de vorm een tabel is. Vervolgens doorloopt het alle rijen en kolommen en gebruikt [isMergedCell](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#isMergedCell) om cellen in samengevoegde regio’s te identificeren. Voor elke vondst wordt de celcoördinaat in de volgorde `rij;kolom` afgedrukt, evenals [getRowSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getRowSpan), [getColSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getColSpan) en de beginkoördinaten van de regio, [getFirstRowIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstRowIndex) en [getFirstColumnIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstColumnIndex).

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

## **Tabelcelranden verwijderen**

Maak een [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) aan en voeg een tabel toe aan de eerste dia met [addTable](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addTable). Kolombreedtes, rijhoogtes en de positie van de tabel worden opgegeven in punten. Het voorbeeld stelt alle vier de celranden in op [FillType.NoFill](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/), waardoor ze onzichtbaar worden.

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

## **Diagonale celranden toevoegen**

Gebruik [getBorderDiagonalDown](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderDiagonalDown) om een lijn te tekenen van de linkerbovenhoek naar de rechteronderhoek, en [getBorderDiagonalUp](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderDiagonalUp) om een lijn te tekenen van de linkeronderhoek naar de rechterbovenhoek. Een diagonale kan een hoekkop markeren. Beide diagonalen kunnen een X vormen om een cel als niet‑toepasbaar te markeren.

Elke diagonale is een [LineFormat](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/). In de [getFillFormat](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#getFillFormat) wordt met [setFillType](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#setFillType) [FillType.Solid](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/) geselecteerd en wordt via [getSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getSolidFillColor) een kleur gekozen. De lijndikte wordt in punten ingesteld met [setWidth](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setWidth).

Het voorbeeld maakt drie cellen in één rij: een rode neerwaartse diagonale, een blauwe opwaartse diagonale en beide diagonalen. Het laat de bovenste, onderste, linker‑ en rechtercelranden ongewijzigd.

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

Een diagonale is een opmaak‑eigenschap, geen cel‑splitsing. Elke cel behoudt één tekstframe, toegankelijk via [getTextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getTextFrame). De regio’s aan beide zijden van een diagonale kunnen niet onafhankelijk worden bewerkt.

De opgeslagen tabel, gerenderd in Microsoft PowerPoint:

![Three table cells showing a red diagonal from top-left to bottom-right, a blue diagonal from bottom-left to top-right, and both diagonals forming an X.](diagonal-cell-borders.png)

*Van links naar rechts: neerwaartse diagonale (rood, 3 pt), opwaartse diagonale (blauw, 5 pt) en beide diagonalen.*

## **Tabelcellen samenvoegen**

Gebruik [mergeCells](https://reference.aspose.com/slides/python-java/aspose.slides/table/#mergeCells) om een rechthoekig bereik van tabelcellen tot één cel te combineren. Geef de cellen op die de linkerboven‑ en rechteronderhoek van het bereik vormen. Het laatste argument bepaalt of de samenvoeging cellen buiten het opgegeven bereik mag omvatten; `False` houdt de samenvoeging binnen dat bereik.

Het voorbeeld maakt een 4‑bij‑4‑tabel met 70‑punt kolommen en rijen, en voegt vervolgens de vier centrale cellen van `(1, 1)` tot en met `(2, 2)` samen. De resulterende cel beslaat twee kolommen en twee rijen, terwijl het onderliggende raster van de tabel vier kolommen en vier rijen behoudt. Om de inhoud of opmaak van de samengevoegde cel te benaderen, gebruikt u de linkerbovenpositie: `table.get_Item(1, 1)` in dit voorbeeld. De andere posities in het samengevoegde bereik blijven deel uitmaken van het tabelraster, zodat de indexen van cellen buiten het bereik niet wijzigen.

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

## **Tabelcellen splitsen**

Het samenvoegen van cellen in het vorige voorbeeld behoudt het raster van de tabel. Het splitsen van een cel kan een nieuwe rasterkolom introduceren en de kolomindexen van de cellen rechts daarvan wijzigen. Aspose.Slides volgt het tabelrastermodel van PowerPoint.

Dit voorbeeld maakt een 4‑bij‑4‑tabel met 70‑punt kolommen en rijen en roept [splitByWidth](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByWidth) aan op cel `(1, 1)`. De helft van de 70‑punt breedte van de cel wordt doorgegeven om twee cellen met gelijke breedte te maken.

Na deze splitsing worden de twee helften benaderd als `table.get_Item(1, 1)` en `table.get_Item(2, 1)`. Het tabelraster heeft nu vijf kolommen: cellen die oorspronkelijk in kolom 2 en 3 stonden, verplaatsen naar kolom 3 en 4. Rij‑indexen blijven ongewijzigd. Gebruik deze bijgewerkte kolomindexen bij het benaderen van cellen na de splitsing.

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
[![An unmerged 70-point cell splits into two 35-point cells, adding a fifth grid column and shifting the indices to its right.](visual-manage-cells-04c40789d81c.svg)](visual-manage-cells-04c40789d81c.svg)

*De breedte‑splitsing heeft invloed op cel (1, 1), met nulgebaseerde (kolom, rij) indexen. Andere rijen behouden een cel die beide nieuwe kolomposities beslaat.*
<!-- visual-explanation:manage-cells:end -->

### **Samengevoegde cellen splitsen op rij‑ of kolomsprong**

Om samengevoegde sjablooncellen voor gegevensvulling voor te bereiden, gebruikt u [splitByRowSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByRowSpan) om langs een bestaande rijgrens te splitsen, of [splitByColSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByColSpan) om langs een kolomgrens te splitsen.

Het argument `index` telt rijen in het bovenste gedeelte of kolommen in het linker gedeelte van de splitsing; het is relatief ten opzichte van de samengevoegde regio:

- Rijsplitsing: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getRowSpan).
- Kolomsplitsing: `0 < index <` [getColSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getColSpan).

Het voorbeeld gaat ervan uit dat een presentatie een tabel heeft als eerste vorm op de eerste dia, met `(1, 2)` en `(1, 3)` verticaal samengevoegd. Vanaf de onderste positie wordt [getFirstColumnIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstColumnIndex) en [getFirstRowIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstRowIndex) gebruikt om het oorsprongspunt te bepalen en beide reeksen te controleren. `splitByRowSpan(1)` scheidt vervolgens rijen 2 en 3 voor productnamen. Voor een horizontale twee‑koloms‑samenvoeging gebruikt u in plaats daarvan `splitByColSpan(1)`.

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

        # Haal de resulterende cellen op uit de tabel na het splitsen.
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

De tabelgrid en omliggende celindexen blijven onveranderd. Haal de resulterende cellen op via hun coördinaten; hier hebben beide een span van 1 en [isMergedCell](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#isMergedCell) geeft `False` weer. Grotere regio’s kunnen na één splitsing deels samengevoegd blijven.

De oorspronkelijke tekst en opmaak blijven in de bovenste (of linker) cel; de nieuwe cel is leeg maar erft de celopmaak zoals opvulling, randen en marges. Vul de cellen na het splitsen en stel eventuele tekstopmaak expliciet in.

De opgeslagen presentatie bevat aparte “Product A” en “Product B” cellen met de celopmaak van het sjabloon behouden. Zie de [Cell API Reference](https://reference.aspose.com/slides/python-java/aspose.slides/cell/) voor details.

### **Een cel splitsen op een specifieke hoogte**

[splitByHeight](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByHeight) neemt de hoogte van het bovenste gedeelte in punten. [splitByRowSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByRowSpan) neemt het aantal bestaande rasterrijen in het bovenste gedeelte. Om een cel van 40 punt in het rechterkolom te centreren, trekt u 40 af van de werkelijke hoogte van de cel en verdeelt u de resterende ruimte gelijk boven- en onderin.

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

De eerste splitsing voegt een rasterrij toe en laat de onderste 90 punt in cel `(1, 1)` achter. De tweede splitsing verdeelt die cel in een middencel van 40 punt en een onderste cel van 50 punt. De rechterkolom heeft nu drie cellen met hoogtes van 50, 40 en 50 punt van boven naar beneden. De linkercel beslaat alle drie de rijen en behoudt zijn oorspronkelijke hoogte van 140 punt.

![The left cell spans the full table height beside three cells with Middle in the center.](split-by-height.png)

## **De achtergrondkleur van een tabelcel wijzigen**

Dit voorbeeld maakt een tabel met 150‑punt kolommen en 50‑punt rijen. Het gebruikt [setFillType](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#setFillType) om een solide opvulling te selecteren en stelt de kleur die door [getSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getSolidFillColor) wordt teruggegeven, in op rood voor cel `(2, 3)`, in de derde kolom en vierde rij.

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

## **Een afbeelding in een tabelcel toevoegen**

Plaats de invoerafbeelding in de werkmap voordat u dit voorbeeld uitvoert. De afbeelding wordt geladen met [Images.fromFile](https://reference.aspose.com/slides/python-java/aspose.slides/images/#fromFile) en toegevoegd aan de afbeeldingsverzameling van de presentatie met [addImage](https://reference.aspose.com/slides/python-java/aspose.slides/imagecollection/#addImage). Vervolgens wordt de afbeelding toegewezen aan de picture‑fill van cel `(0, 0)`, de eerste cel in de tabel.

[PictureFillMode.Stretch](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillmode/) strekt de afbeelding uit om de cel te vullen, wat de beeldverhouding kan wijzigen. Kolombreedtes en rijhoogtes zijn in punten. De geladen afbeelding wordt in een `finally`‑blok vrijgegeven nadat deze aan de presentatie is toegevoegd.

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

**Kan ik verschillende lijndiktes en -stijlen instellen voor verschillende zijden van één cel?**

Ja. De [top](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderTop)/[bottom](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderBottom)/[left](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderLeft)/[right](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderRight) randen hebben afzonderlijke eigenschappen, zodat de dikte en stijl van elke zijde kan verschillen.

**Wat gebeurt er met de afbeelding als ik de kolom‑/rijgrootte wijzig nadat ik een afbeelding als achtergrond van de cel heb ingesteld?**

Het gedrag hangt af van de [fill mode](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillmode/) (stretch/tile). Bij stretchen past de afbeelding zich aan de nieuwe cel aan, bij tilen worden de tegels opnieuw berekend.

**Kan ik een hyperlink toewijzen aan alle inhoud van een cel?**

[Hyperlinks](/slides/nl/python-java/manage-hyperlinks/) worden ingesteld op het tekst‑ (portion)‑niveau binnen het tekstframe van de cel of op het niveau van de gehele tabel/vorm. In de praktijk kent u de link toe aan een portion of aan alle tekst in de cel.

**Kan ik verschillende lettertypen binnen één cel instellen?**

Ja. Het tekstframe van een cel ondersteunt [portions](https://reference.aspose.com/slides/python-java/aspose.slides/portion/) (runs) met onafhankelijke opmaak — lettertype, stijl, grootte en kleur.