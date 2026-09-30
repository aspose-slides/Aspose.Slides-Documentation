---
title: Beheer presentatietabellen in Python
linktitle: Beheer tabel
type: docs
weight: 10
url: /nl/python-java/manage-table/
keywords:
- tabel toevoegen
- tabel maken
- tabel openen
- aspectverhouding
- tekst uitlijnen
- tekstopmaak
- tabelstijl
- PowerPoint
- presentatie
- Python
- Aspose.Slides
description: "Maak en bewerk tabellen in PowerPoint-dias met Aspose.Slides voor Python via Java. Ontdek eenvoudige code-voorbeelden om uw tabelwerkstromen te stroomlijnen."
---
## **Introductie**

Tabellen in PowerPoint ordenen informatie in rijen en kolommen, waardoor het gemakkelijker wordt om waarden te lezen en te vergelijken.

Aspose.Slides biedt de [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) en [Cell](https://reference.aspose.com/slides/python-java/aspose.slides/cell/) klassen en andere types om tabellen in presentaties te maken, bij te werken en te beheren.

## **Maak een tabel vanaf nul**

Maak een tabel door de positie, kolombreedtes en rijhoogtes op te geven. Na het toevoegen aan een dia kunt u celranden opmaken, cellen samenvoegen en tekst invoegen.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) klasse.
2. Haal een referentie naar de dia op basis van de index.
3. Definieer een lijst met kolombreedtes in points.
4. Definieer een lijst met rijhoogtes in points.
5. Voeg een [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) object toe aan de dia via de [addTable](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addTable) methode.
6. Loop door elke [Cell](https://reference.aspose.com/slides/python-java/aspose.slides/cell/) om opmaak toe te passen op de boven-, onder-, rechter- en linker randen.
7. Voeg de eerste twee cellen van de eerste rij van de tabel samen.
8. Toegang tot de samengevoegde cel via de [getTextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getTextFrame) methode.
9. Stel de tekst in de samengevoegde cel in.
10. Sla de aangepaste presentatie op.

Het voorbeeld hieronder maakt een tabel met drie kolommen en vijf rijen op (100, 50) points. Het past rode randen toe met een breedte van 5 points, voegt de eerste twee cellen in de eerste rij samen, en slaat het resultaat op als `table.pptx`.

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

## **Nummering in een standaardtabel**

In een standaardtabel zijn celindexen nulgebaseerd en gebruiken ze de volgorde (kolom, rij). De eerste cel heeft index (0, 0).

Bijvoorbeeld, de cellen in een tabel met 4 kolommen en 4 rijen worden op deze manier genummerd:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Dit voorbeeld maakt de 4 × 4 tabel weergegeven hierboven, met kolombreedtes en rijhoogtes van 70 points en rode celranden van 5 points. De coördinaten illustreren celindexen; het voorbeeld laat de cellen leeg en slaat de tabel op als `StandardTables_out.pptx`.

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

## **Toegang tot een bestaande tabel**

Tabellen worden opgeslagen in de vormverzameling van een dia. Loop door de vormen om een tabel te vinden, en gebruik vervolgens de [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) klasse om de cellen te lezen of bij te werken.

1. Laad de presentatie met behulp van de [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) klasse.
2. Haal een referentie naar de dia die de tabel bevat op basis van de index.
3. Loop door de [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) objecten en stop wanneer een tabel wordt gevonden. Als de dia meerdere tabellen bevat, gebruik dan [getAlternativeText](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getAlternativeText) om de juiste te identificeren.
4. Werk de tekst in de doelcel bij.
5. Sla de aangepaste presentatie op.

Het voorbeeld hieronder opent `UpdateExistingTable.pptx` en vindt de eerste tabel op de eerste dia. Het stelt de cel op kolom 0, rij 1 in op `New` en slaat het resultaat op als `table1_out.pptx`. De invoer moet minstens één dia bevatten, en de eerste tabel op die dia moet minstens één kolom en twee rijen hebben.

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

Om een rij in een bestaande tabel te wijzigen en te begrijpen waarom de werkelijke hoogte de gevraagde minimumhoogte kan overschrijden, zie [Control Row Height](/slides/nl/python-java/manage-rows-and-columns/#control-row-height).

## **Vind de cel die een tekstframe bezit**

Wanneer generieke tekstverwerkingscode een [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/) van een tabel ontvangt, gebruik dan de [TextFrame.getParentCell](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getParentCell) methode om de eigenaar [Cell](https://reference.aspose.com/slides/python-java/aspose.slides/cell/) op te halen. Voor een tabelcel-tekstframe geeft [TextFrame.getParentCell](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getParentCell) de eigenaar terug en geeft [TextFrame.getParentShape](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getParentShape) `None` terug, ook al is de tabel zelf een vorm.

De celcoördinaten zijn beschikbaar via de alleen-lezen [Cell.getFirstColumnIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstColumnIndex) en [Cell.getFirstRowIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstRowIndex) methoden. [TextFrame.getParentCell](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getParentCell) biedt ook alleen-lezen navigatie: het geeft de eigenaar terug maar wijzigt het eigendom niet. Controleer altijd of de geretourneerde cel niet `None` is voordat u deze gebruikt.

Voor een compleet voorbeeld dat tabelcel- en vorm-eigenaren identificeert, inclusief vormen die aan SmartArt‑knopen zijn gekoppeld, zie [Search and Replace Text](/slides/nl/python-java/search-and-replace-text/).

## **Tekst uitlijnen in een tabel**

U kunt de verticale verankering en tekstoriëntatie van individuele tabelcellen regelen. Het voorbeeld in deze sectie centreert tekst in de eerste cel en draait deze 270 graden.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) klasse.
2. Haal een referentie naar de dia op basis van de index.
3. Voeg een [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) object toe aan de dia.
4. Verkrijg een [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/) object uit de tabel.
5. Verkrijg de eerste [Paragraph](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/) en stel de tekst en kleur in.
6. Stel de verticale verankering en tekstoriëntatie van de cel in met behulp van [setTextAnchorType](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#setTextAnchorType) en [setTextVerticalType](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#setTextVerticalType).
7. Sla de aangepaste presentatie op.

Dit voorbeeld maakt een 4 × 4 tabel met kolombreedtes van 120 points en rijhoogtes van 100 points. Het formatteert de tekst in cel (0, 0), voegt waarden toe aan de overige cellen in de eerste rij, en slaat het resultaat op als `Vertical_Align_Text_out.pptx`.

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

## **Tekstopmaak op tabelniveau instellen**

Gebruik [setTextFormat](https://reference.aspose.com/slides/python-java/aspose.slides/table/#setTextFormat) om tekstopmaak toe te passen op alle cellen in een tabel. De overloads accepteren opmaak voor segmenten, alinea's en tekstframes, zodat u deze eigenschappen kunt instellen zonder door individuele cellen te itereren.

1. Laad de presentatie met behulp van de [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) klasse.
2. Haal een referentie naar de dia op basis van de index.
3. Verkrijg een [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) object uit de dia.
4. Stel de lettergrootte in met behulp van [setFontHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setFontHeight) voor de tekst.
5. Stel de alinea‑uitlijning en de rechter marge in met [setAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setAlignment) en [setMarginRight](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setMarginRight).
6. Stel de tekstoriëntatie in met [setTextVerticalType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setTextVerticalType).
7. Sla de aangepaste presentatie op.

Het voorbeeld hieronder opent `table.pptx`, die minstens één dia moet bevatten met een tabel als eerste vorm. Het stelt de lettergrootte in op 25 points, lijnt alinea's rechts uit met een rechter marge van 20 points, en maakt de tekst verticaal. De opgemaakte presentatie wordt opgeslagen als `result.pptx`.

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

## **Tabelstijleigenschappen ophalen**

Gebruik [getStylePreset](https://reference.aspose.com/slides/python-java/aspose.slides/table/#getStylePreset) om de vooraf ingestelde stijl van een tabel te lezen en [setStylePreset](https://reference.aspose.com/slides/python-java/aspose.slides/table/#setStylePreset) om deze toe te wijzen. Dit voorbeeld past [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/python-java/aspose.slides/tablestylepreset/) toe op één tabel, print de preset‑waarde, en kent dezelfde preset toe aan een tweede tabel. Beide tabellen worden opgeslagen in `table-style.pptx`.

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

## **Aspectratio van een tabel vergrendelen**

De aspectratio van een tabel is de verhouding tussen de breedte en de hoogte. Gebruik [setAspectRatioLocked](https://reference.aspose.com/slides/python-java/aspose.slides/graphicalobjectlock/#setAspectRatioLocked) om deze verhouding voor een tabel te vergrendelen.

Het voorbeeld hieronder opent `pres.pptx`, die minstens één dia moet bevatten met een tabel als eerste vorm. Het print de huidige vergrendelingsstatus, schakelt de aspectratio‑vergrendeling in, print de bijgewerkte status (`True`), en slaat het resultaat op als `pres-out.pptx`.

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

**Kan ik de rechts‑naar‑links (RTL) leesrichting voor een hele tabel en de tekst in de cellen inschakelen?**

Ja. De tabel biedt een [setRightToLeft](https://reference.aspose.com/slides/python-java/aspose.slides/table/#setRightToLeft) methode, en alinea's hebben [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setRightToLeft). Door beide te gebruiken wordt de juiste RTL‑volgorde en weergave binnen cellen gegarandeerd.

**Hoe kan ik voorkomen dat gebruikers een tabel in het uiteindelijke bestand verplaatsen of de grootte wijzigen?**

Gebruik [shape locks](/slides/nl/python-java/applying-protection-to-presentation/) om verplaatsen, herschalen, selecteren, enz. uit te schakelen. Deze vergrendelingen gelden ook voor tabellen.

**Wordt het invoegen van een afbeelding in een cel als achtergrond ondersteund?**

Ja. U kunt een [picture fill](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/) voor een cel instellen; de afbeelding bedekt het celgebied volgens de gekozen modus (strekken of tegelen).