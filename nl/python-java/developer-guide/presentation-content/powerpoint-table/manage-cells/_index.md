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
description: "Beheer PowerPoint-tabelcellen in Python: identificeer samengevoegde cellen, verwijder randen, split cellen, en stel achtergrondkleuren en afbeeldingen in met Aspose.Slides voor Python via Java."
---
## **Overzicht**

Aspose.Slides stelt je in staat om tabelcellen in PowerPoint‑presentaties te benaderen en te wijzigen. Dit artikel legt uit hoe je samengevoegde tabelcellen kunt identificeren, celranden kunt verwijderen, met celnummering kunt werken na het samenvoegen of splitsen van cellen, de achtergrondkleur van een cel kunt wijzigen, en een afbeelding in een tabelcel kunt toevoegen. De voorbeelden laten zien hoe je een presentatie kunt maken of openen, een tabel van een dia kunt ophalen, celopmaak kunt bijwerken via cel‑eigenschappen, en de gewijzigde presentatie kunt opslaan als een PPTX‑bestand.

Aspose.Slides gebruikt nul‑gebaseerde indexen om tabelcellen te benaderen in de volgorde `(column, row)`.

## **Een samengevoegde tabelcel identificeren**

Het voorbeeld opent een bestaande presentatie en benadert de eerste vorm op de eerste dia als een tabel. Het gaat ervan uit dat de dia en de vorm bestaan en dat de vorm een tabel is. Vervolgens wordt door alle rijen en kolommen gelopen en wordt [isMergedCell](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#isMergedCell) gebruikt om cellen in samengevoegde regio’s te identificeren. Voor elke overeenkomst wordt de celcoördinaten in `row;column`‑volgorde afgedrukt, evenals [getRowSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getRowSpan), [getColSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getColSpan), en de startcoördinaten van de regio, [getFirstRowIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstRowIndex) en [getFirstColumnIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstColumnIndex).

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

## **Celranden van tabel verwijderen**

Maak een [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) aan en voeg een tabel toe aan de eerste dia met [addTable](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addTable). De kolombreedtes, rijhoogtes en de positie van de tabel worden gespecificeerd in points. Het voorbeeld stelt alle vier de celranden in op [FillType.NoFill](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/), waardoor ze onzichtbaar worden.

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

## **Tabelcellen samenvoegen**

Gebruik [mergeCells](https://reference.aspose.com/slides/python-java/aspose.slides/table/#mergeCells) om een rechthoekig bereik van tabelcellen tot één cel te combineren. Geef de cellen op in de linkerboven‑ en rechteronderhoek van het bereik. Het laatste argument bepaalt of de samenvoeging cellen buiten het opgegeven bereik mag omvatten; `False` houdt de samenvoeging binnen dat bereik.

Het voorbeeld maakt een 4‑bij‑4‑tabel met kolommen en rijen van 70 points, en voegt vervolgens de vier centrale cellen samen van `(1, 1)` tot `(2, 2)`. De resulterende cel beslaat twee kolommen en twee rijen, terwijl het onderliggende raster van de tabel vier kolommen en vier rijen behoudt. Om de inhoud of opmaak van de samengevoegde cel te benaderen, gebruik je de linkerboven‑positie: `table.get_Item(1, 1)` in dit voorbeeld. De andere posities in het samengevoegde bereik blijven deel uitmaken van het tabelraster, zodat de indexen van cellen buiten het bereik niet veranderen.

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

Dit voorbeeld maakt een 4‑bij‑4‑tabel met kolommen en rijen van 70 points en roept [splitByWidth](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByWidth) aan op cel `(1, 1)`. De helft van de 70‑point breedte van de cel wordt gebruikt om twee even brede cellen te creëren.

Na deze splitsing worden de twee helften benaderd als `table.get_Item(1, 1)` en `table.get_Item(2, 1)`. Het tabelraster heeft nu vijf kolommen: cellen die oorspronkelijk in kolommen 2 en 3 stonden, verplaatsen zich naar kolommen 3 en 4, respectievelijk. Rij‑indexen blijven ongewijzigd. Gebruik deze bijgewerkte kolomindexen bij het benaderen van cellen na de splitsing.

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

### **Samengevoegde cellen splitsen op rij‑ of kolom‑span**

Om samengevoegde sjablooncellen voor te bereiden op het vullen van gegevens, gebruik je [splitByRowSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByRowSpan) om langs een bestaande rijgrens te splitsen, of [splitByColSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByColSpan) om langs een kolomgrens te splitsen.

Het argument `index` telt rijen in het bovenste deel of kolommen in het linkerdeel van de splitsing; het is relatief ten opzichte van de samengevoegde regio:

- Rij‑splitsing: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getRowSpan).
- Kolom‑splitsing: `0 < index <` [getColSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getColSpan).

Het voorbeeld gaat ervan uit dat een presentatie een tabel heeft als de eerste vorm op de eerste dia, met `(1, 2)` en `(1, 3)` verticaal samengevoegd. Beginnend vanaf de onderste positie, gebruikt het [getFirstColumnIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstColumnIndex) en [getFirstRowIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstRowIndex) om de oorsprong te bepalen en controleert beide spans. `splitByRowSpan(1)` scheidt vervolgens rijen 2 en 3 voor productnamen. Voor een horizontale samenvoeging van twee kolommen, gebruik je `splitByColSpan(1)`.

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

Het tabelraster en de omliggende cel‑indexen blijven onveranderd. Haal de resulterende cellen op via hun coördinaten; hier hebben beide een span van 1 en [isMergedCell](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#isMergedCell) geeft `False` terug. Grotere regio’s kunnen na één splitsing gedeeltelijk samengevoegd blijven.

De oorspronkelijke tekst en opmaak blijven in de boven‑ (of linker‑)cel; de nieuwe cel is leeg maar erft de celopmaak zoals vulling, randen en marges. Vul de cellen na het splitsen en stel eventuele vereiste tekstopmaak expliciet in.

De opgeslagen presentatie bevat afzonderlijke cellen "Product A" en "Product B" met de celopmaak van het sjabloon behouden. Zie de [Cell API Reference](https://reference.aspose.com/slides/python-java/aspose.slides/cell/) voor details.

## **De achtergrondkleur van een tabelcel wijzigen**

Dit voorbeeld maakt een tabel met kolommen van 150 points en rijen van 50 points. Het gebruikt [setFillType](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#setFillType) om een effen vulling te selecteren en stelt de kleur die door [getSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getSolidFillColor) wordt teruggegeven in op rood voor cel `(2, 3)`, in de derde kolom en vierde rij.

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

## **Een afbeelding in een tabelcel plaatsen**

Plaats de invoerafbeelding in de werkmap voordat je dit voorbeeld uitvoert. Het laadt de afbeelding met [Images.fromFile](https://reference.aspose.com/slides/python-java/aspose.slides/images/#fromFile) en voegt deze toe aan de afbeeldingscollectie van de presentatie met [addImage](https://reference.aspose.com/slides/python-java/aspose.slides/imagecollection/#addImage). Vervolgens wordt de afbeelding toegewezen aan de afbeeldingvulling van cel `(0, 0)`, de eerste cel in de tabel.

[PictureFillMode.Stretch](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillmode/) rekent de afbeelding uit om de cel te vullen, wat de beeldverhouding kan veranderen. Kolombreedtes en rijhoogtes staan in points. De geladen afbeelding wordt vrijgegeven in een `finally`‑blok nadat deze aan de presentatie is toegevoegd.

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

**Kun ik verschillende lijndiktes en stijlen instellen voor de verschillende zijden van één cel?**

Ja. De [top](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderTop)/[bottom](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderBottom)/[left](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderLeft)/[right](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderRight)‑randen hebben afzonderlijke eigenschappen, zodat de dikte en stijl van elke zijde kan verschillen.

**Wat gebeurt er met de afbeelding als ik de kolom‑/rij‑grootte wijzig nadat ik een afbeelding als achtergrond van de cel heb ingesteld?**

Het gedrag hangt af van de [fill mode](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillmode/) (stretch/tile). Bij rekken past de afbeelding zich aan de nieuwe cel aan; bij betegelen worden de tegels opnieuw berekend.

**Kan ik een hyperlink toewijzen aan de gehele inhoud van een cel?**

[Hyperlinks](/slides/nl/python-java/manage-hyperlinks/) worden ingesteld op tekst‑ (portion) niveau binnen het tekstframe van de cel of op het niveau van de hele tabel/vorm. In de praktijk wijs je de link toe aan een portion of aan alle tekst in de cel.

**Kan ik verschillende lettertypen binnen één cel instellen?**

Ja. Het tekstframe van een cel ondersteunt [portions](https://reference.aspose.com/slides/python-java/aspose.slides/portion/) (runs) met onafhankelijke opmaak — lettertypefamilie, stijl, grootte en kleur.