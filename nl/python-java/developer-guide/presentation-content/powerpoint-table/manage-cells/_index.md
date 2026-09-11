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
description: "Beheer moeiteloos tabelcellen in PowerPoint met Aspose.Slides voor Python via Java. Beheers het snel benaderen, wijzigen en opmaken van cellen voor naadloze dia‑automatisering."
---
## **Overzicht**

Aspose.Slides stelt u in staat om tabelcellen in PowerPoint‑presentaties te benaderen en te wijzigen. Dit artikel legt uit hoe u samengevoegde tabelcellen kunt identificeren, celranden kunt verwijderen, kunt werken met celnummering na het samenvoegen of splitsen van cellen, de achtergrondkleur van een cel kunt wijzigen en een afbeelding in een tabelcel kunt toevoegen. De voorbeelden tonen hoe u een presentatie kunt maken of openen, een tabel van een dia kunt verkrijgen, celopmaak via cel‑eigenschappen kunt bijwerken en de gewijzigde presentatie kunt opslaan als een PPTX‑bestand.

## **Identificeer een samengevoegde tabelcel**

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/) klasse.  
2. Haal de tabel op van de eerste dia.  
3. Itereer door de rijen en kolommen van de tabel om samengevoegde cellen te vinden.  
4. Print een bericht wanneer er samengevoegde cellen worden gevonden.

Deze Python‑code laat zien hoe u samengevoegde tabelcellen in een presentatie kunt identificeren:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Table

presentation = Presentation("SomePresentationWithTable.pptx")
try:
    # Veronderstel dat de eerste vorm op de eerste dia een tabel is.
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

## **Verwijderen van tabelcelranden**

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/) klasse.  
2. Haal een referentie naar een dia op basis van de index.  
3. Definieer een lijst met kolombreedtes.  
4. Definieer een lijst met rijhoogtes.  
5. Voeg een tabel toe aan de dia via de [addTable](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shapecollection/#addTable) methode.  
6. Itereer door elke cel om de boven-, onder-, rechter- en linkerrand te wissen.  
7. Sla de gewijzigde presentatie op als een PPTX‑bestand.

Deze Python‑code laat zien hoe u de randen van tabelcellen kunt verwijderen:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jp2pe.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat

presentation = Presentation()
try:
    # Toegang tot de eerste dia.
    slide = presentation.getSlides().get_Item(0)

    # Definieer kolombreedtes en rijhoogtes.
    column_widths = [50, 50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]

    # Voeg een tabel toe aan de dia.
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    # Stel het randformaat in voor elke cel.
    for row in table.getRows():
        for cell in row:
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.NoFill)
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.NoFill)
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.NoFill)
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.NoFill)

    # Sla de presentatie op als een PPTX‑bestand.
    presentation.save("table_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Nummering in samengevoegde cellen**

Als we twee paren cellen samenvoegen, (1, 1) en (2, 1), en (1, 2) en (2, 2), behoudt de resulterende tabel haar celnummering. Deze Python‑code demonstreert het proces:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # Toegang tot de eerste dia.
    slide = presentation.getSlides().get_Item(0)

    # Definieer kolombreedtes en rijhoogtes.
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # Voeg een tabel toe aan de dia.
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    # Stel het randformaat in voor elke cel.
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


    # Voeg cellen (1, 1) en (2, 1) samen.
    table.mergeCells(table.get_Item(1, 1), table.get_Item(2, 1), False)

    # Voeg cellen (1, 2) en (2, 2) samen.
    table.mergeCells(table.get_Item(1, 2), table.get_Item(2, 2), False)

    # Sla de presentatie op als een PPTX‑bestand.
    presentation.save("MergeCells_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Vervolgens voegen we de cellen verder samen door (1, 1) en (1, 2) te combineren. Het resultaat is een tabel met een grote samengevoegde cel in het midden:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # Toegang tot de eerste dia.
    slide = presentation.getSlides().get_Item(0)

    # Definieer kolombreedtes en rijhoogtes.
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # Voeg een tabel toe aan de dia.
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    # Stel het randformaat in voor elke cel.
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


    # Voeg cellen (1, 1) en (2, 1) samen.
    table.mergeCells(table.get_Item(1, 1), table.get_Item(2, 1), False)

    # Voeg cellen (1, 2) en (2, 2) samen.
    table.mergeCells(table.get_Item(1, 2), table.get_Item(2, 2), False)

    # Voeg cellen (1, 1) en (1, 2) samen.
    table.mergeCells(table.get_Item(1, 1), table.get_Item(1, 2), True)

    # Sla de presentatie op als een PPTX-bestand.
    presentation.save("MergeCells_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Nummering in een gesplitste cel**

In de eerdere voorbeelden veranderde het samenvoegen van tabelcellen de nummering van de andere cellen niet.

Deze keer nemen we een normale tabel (een tabel zonder samengevoegde cellen) en proberen we cel (1, 1) te splitsen om een speciale tabel te krijgen. Let goed op de nummering van deze tabel, die wellicht vreemd lijkt. Dit is echter de manier waarop Microsoft PowerPoint tabelcellen nummert en Aspose.Slides doet precies hetzelfde.

Deze Python‑code laat het beschreven proces zien:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # Toegang tot de eerste dia.
    slide = presentation.getSlides().get_Item(0)

    # Definieer kolombreedtes en rijhoogtes.
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # Voeg een tabel toe aan de dia.
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    # Stel het randformaat in voor elke cel.
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


    # Splits cel (1, 1).
    table.get_Item(1, 1).splitByWidth(table.get_Item(2, 1).getWidth() / 2)

    # Sla de presentatie op als een PPTX‑bestand.
    presentation.save("SplitCells_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Achtergrondkleur van een tabelcel wijzigen**

Deze Python‑code laat zien hoe u de achtergrondkleur van een tabelcel kunt wijzigen:

```python
import jpase
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # Toegang tot de eerste dia.
    slide = presentation.getSlides().get_Item(0)

    # Definieer kolombreedtes en rijhoogtes.
    column_widths = [150, 150, 150, 150]
    row_heights = [50, 50, 50, 50, 50]

    # Voeg een tabel toe aan de dia.
    table = slide.getShapes().addTable(50, 50, column_widths, row_heights)

    # Stel de achtergrondkleur in voor een cel.
    cell = table.get_Item(2, 3)
    cell.getCellFormat().getFillFormat().setFillType(FillType.Solid)
    cell.getCellFormat().getFillFormat().getSolidFillColor().setColor(Color.RED)

    # Sla de presentatie op als een PPTX‑bestand.
    presentation.save("cell_background_color.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Afbeelding toevoegen in een tabelcel**

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/) klasse.  
2. Haal een referentie naar een dia op basis van de index.  
3. Definieer een lijst met kolombreedtes.  
4. Definieer een lijst met rijhoogtes.  
5. Voeg een tabel toe aan de dia via de [addTable](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shapecollection/#addTable) methode.  
6. Laad het afbeeldingsbestand met behulp van [Images.fromFile](https://reference.aspose.com/slides/nl/python-java/aspose.slides/images/#fromFile).  
7. Voeg de afbeelding toe aan de presentatie om een [PPImage](https://reference.aspose.com/slides/nl/python-java/aspose.slides/ppimage/) object te maken.  
8. Stel het [FillFormat](https://reference.aspose.com/slides/nl/python-java/aspose.slides/fillformat/) vultype van de tabelcel in op [FillType.Picture](https://reference.aspose.com/slides/nl/python-java/aspose.slides/filltype/#Picture).  
9. Voeg de afbeelding toe aan de eerste cel van de tabel.  
10. Sla de gewijzigde presentatie op als een PPTX‑bestand.

Deze Python‑code laat zien hoe u een afbeelding in een tabelcel plaatst bij het maken van een tabel:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Images, FillType, PictureFillMode, SaveFormat

presentation = Presentation()
try:
    # Toegang tot de eerste dia.
    slide = presentation.getSlides().get_Item(0)

    # Definieer kolombreedtes en rijhoogtes.
    column_widths = [150, 150, 150, 150]
    row_heights = [100, 100, 100, 100, 90]

    # Voeg een tabel toe aan de dia.
    table = slide.getShapes().addTable(50, 50, column_widths, row_heights)

    # Maak een presentatie-afbeelding van het afbeeldingsbestand.
    image = Images.fromFile("image.jpg")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    # Voeg de afbeelding toe aan de eerste tabelcel.
    cell_format = table.get_Item(0, 0).getCellFormat()
    cell_format.getFillFormat().setFillType(FillType.Picture)
    cell_format.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch)
    cell_format.getFillFormat().getPictureFillFormat().getPicture().setImage(picture)

    # Sla de presentatie op als een PPTX-bestand.
    presentation.save("Image_In_TableCell_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Kan ik verschillende lijndiktes en stijlen instellen voor de verschillende zijden van één cel?**

Ja. De [top](https://reference.aspose.com/slides/nl/python-java/aspose.slides/cellformat/#getBorderTop)/[bottom](https://reference.aspose.com/slides/nl/python-java/aspose.slides/cellformat/#getBorderBottom)/[left](https://reference.aspose.com/slides/nl/python-java/aspose.slides/cellformat/#getBorderLeft)/[right](https://reference.aspose.com/slides/nl/python-java/aspose.slides/cellformat/#getBorderRight) randen hebben afzonderlijke eigenschappen, zodat de dikte en stijl van elke zijde kunnen verschillen. Dit volgt logisch uit de per‑zijde randcontrole voor een cel die in het artikel wordt aangetoond.

**Wat gebeurt er met de afbeelding als ik de kolom‑/rijgrootte wijzig nadat ik een afbeelding als achtergrond van de cel heb ingesteld?**

Het gedrag hangt af van de [fill mode](https://reference.aspose.com/slides/nl/python-java/aspose.slides/picturefillmode/) (stretch/tilen). Bij stretchen past de afbeelding zich aan de nieuwe cel aan; bij tilen worden de tegels opnieuw berekend. Het artikel noemt de weergavemodi van afbeeldingen in een cel.

**Kan ik een hyperlink toewijzen aan alle inhoud van een cel?**

[Hyperlinks](/slides/nl/python-java/manage-hyperlinks/) worden ingesteld op tekstaanduidingsniveau (portion) binnen het tekstframe van de cel of op het niveau van de hele tabel/vorm. In de praktijk kent u de link toe aan een portion of aan alle tekst in de cel.

**Kan ik verschillende lettertypen instellen binnen één enkele cel?**

Ja. Het tekstframe van een cel ondersteunt [portions](https://reference.aspose.com/slides/nl/python-java/aspose.slides/portion/) (runs) met onafhankelijke opmaak—lettertypefamilie, stijl, grootte en kleur.