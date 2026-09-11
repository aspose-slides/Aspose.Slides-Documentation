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
- beeldverhouding
- tekst uitlijnen
- tekst opmaak
- tabelstijl
- PowerPoint
- presentatie
- Python
- Aspose.Slides
description: "Maak & bewerk tabellen in PowerPoint-dia's met Aspose.Slides voor Python via Java. Ontdek eenvoudige codevoorbeelden om uw tabelwerkstromen te stroomlijnen."
---
## **Introductie**

Een tabel in PowerPoint is een efficiënte manier om informatie weer te geven. De informatie in een raster van cellen (gerangschikt in rijen en kolommen) is duidelijk en makkelijk te begrijpen.

Aspose.Slides biedt de [Tabel](https://reference.aspose.com/slides/nl/python-java/aspose.slides/table/) klasse, [Cel](https://reference.aspose.com/slides/nl/python-java/aspose.slides/cell/) klasse, en andere typen om u in staat te stellen tabellen te maken, bij te werken en te beheren in allerlei presentaties.

## **Maak een tabel vanaf nul**

1. Maak een instantie van de [Presentatie](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/) klasse.  
2. Krijg een referentie naar een dia op basis van de index.  
3. Definieer een lijst met kolombreedtes.  
4. Definieer een lijst met rijhoogtes.  
5. Voeg een [Tabel](https://reference.aspose.com/slides/nl/python-java/aspose.slides/table/) object toe aan de dia via de [addTable](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shapecollection/#addTable) methode.  
6. Itereer door elke [Cel](https://reference.aspose.com/slides/nl/python-java/aspose.slides/cell/) om opmaak toe te passen op de boven-, onder-, rechts- en linkerranden.  
7. Voeg de eerste twee cellen van de eerste rij van de tabel samen.  
8. Toegang tot een [Cel](https://reference.aspose.com/slides/nl/python-java/aspose.slides/cell/)'s [TextFrame](https://reference.aspose.com/slides/nl/python-java/aspose.slides/textframe/).  
9. Voeg wat tekst toe aan het [TextFrame](https://reference.aspose.com/slides/nl/python-java/aspose.slides/textframe/).  
10. Sla de gewijzigde presentatie op.

Deze Python-code toont hoe u een tabel in een presentatie kunt maken:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

# Instancieert een Presentation-klasse die een PPTX‑bestand vertegenwoordigt
presentation = Presentation()
try:

    # Benadert de eerste dia
    slide = presentation.getSlides().get_Item(0)

    # Definieert kolommen met breedtes en rijen met hoogtes
    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]

    # Voegt een tabelvorm toe aan de dia
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    # Stelt het randformaat in voor elke cel
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

    # Voegt cellen 1 & 2 van rij 1 samen
    table.mergeCells(table.getRows().get_Item(0).get_Item(0), table.getRows().get_Item(0).get_Item(1), False)

    # Voegt wat tekst toe aan de samengevoegde cel
    table.getRows().get_Item(0).get_Item(0).getTextFrame().setText("Merged Cells")

    # Slaat de presentatie op schijf
    presentation.save("table.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Nummering in een standaardtabel**

In een standaardtabel is de nummering van cellen eenvoudig en nulgebaseerd. De eerste cel in een tabel heeft de index 0,0 (kolom 0, rij 0).

Bijvoorbeeld, de cellen in een tabel met 4 kolommen en 4 rijen worden op deze manier genummerd:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Deze Python-code toont hoe u een tabel met standaardcelnummering kunt maken:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

# Instancieert een Presentation-klasse die een PPTX‑bestand vertegenwoordigt
presentation = Presentation()
try:

    # Benadert eerste dia
    slide = presentation.getSlides().get_Item(0)

    # Definieert kolommen met breedtes en rijen met hoogtes
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # Voegt een tabelvorm toe aan de dia
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    # Stelt het randformaat in voor elke cel
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

    # Slaat de presentatie op schijf
    presentation.save("StandardTables_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Toegang tot een bestaande tabel**

1. Maak een instantie van de [Presentatie](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/) klasse.  

2. Krijg een referentie naar de dia die de tabel bevat via de index.  

3. Initialiseer een variabele voor een [Tabel](https://reference.aspose.com/slides/nl/python-java/aspose.slides/table/) object en stel deze in op `None`.  

4. Itereer door alle [Shape](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shape/) objecten totdat de tabel is gevonden.  

   Als u vermoedt dat de dia waarmee u werkt slechts één tabel bevat, kunt u eenvoudig alle vormen die erin staan controleren. Wanneer een vorm wordt herkend als een tabel, kunt u deze gebruiken als een [Tabel](https://reference.aspose.com/slides/nl/python-java/aspose.slides/table/) object. Maar als de dia meerdere tabellen bevat, zoekt u beter naar de gewenste tabel via zijn [getAlternativeText](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shape/#getAlternativeText).  

5. Gebruik het [Tabel](https://reference.aspose.com/slides/nl/python-java/aspose.slides/table/) object om met de tabel te werken. In het voorbeeld hieronder werken we de tekst in de eerste kolom van de tweede rij bij.  

6. Sla de gewijzigde presentatie op.

Deze Python-code toont hoe u toegang krijgt tot en werkt met een bestaande tabel:

```python
import jpype
import asposeslides

if not jpile.isJVMStarted():
    jpile.startJVM()

from asposeslides.api import Presentation, SaveFormat, Table

# Instancieert de Presentation-klasse die een PPTX‑bestand vertegenwoordigt
presentation = Presentation("UpdateExistingTable.pptx")
try:

    # Benadert de eerste dia
    slide = presentation.getSlides().get_Item(0)

    # Initialiseert de tabelreferentie.
    table = None

    # Gaat door de vormen en stelt een referentie in naar de gevonden tabel
    for shape in slide.getShapes():
        if isinstance(shape, Table):
            table = shape

            # Stelt de tekst in voor de eerste kolom van de tweede rij
            table.get_Item(0, 1).getTextFrame().setText("New")

    # Slaat de gewijzigde presentatie op schijf
    presentation.save("table1_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Vind de cel die een TextFrame bezit**

Wanneer generieke tekstverwerkingscode een [TextFrame](https://reference.aspose.com/slides/nl/python-java/aspose.slides/textframe/) van een tabel ontvangt, gebruik dan de [TextFrame.getParentCell](https://reference.aspose.com/slides/nl/python-java/aspose.slides/textframe/#getParentCell) methode om de eigenaar‑[Cel](https://reference.aspose.com/slides/nl/python-java/aspose.slides/cell/) op te halen. Voor een tabel‑cel‑tekstkader geeft [TextFrame.getParentCell](https://reference.aspose.com/slides/nl/python-java/aspose.slides/textframe/#getParentCell) de eigenaar terug en geeft [TextFrame.getParentShape](https://reference.aspose.com/slides/nl/python-java/aspose.slides/textframe/#getParentShape) `None` terug, hoewel de tabel zelf een vorm is.

De celcoördinaten zijn beschikbaar via de alleen‑lezen methoden [Cell.getFirstColumnIndex](https://reference.aspose.com/slides/nl/python-java/aspose.slides/cell/#getFirstColumnIndex) en [Cell.getFirstRowIndex](https://reference.aspose.com/slides/nl/python-java/aspose.slides/cell/#getFirstRowIndex). [TextFrame.getParentCell](https://reference.aspose.com/slides/nl/python-java/aspose.slides/textframe/#getParentCell) biedt eveneens alleen‑lezen navigatie: het retourneert de eigenaar maar wijzigt geen eigendom. Controleer altijd of de geretourneerde cel niet `None` is voordat u deze gebruikt.

Voor een compleet voorbeeld dat zowel tabel‑cel‑ als vorm‑eigenaars identificeert, inclusief vormen die aan SmartArt‑nodes zijn gekoppeld, zie [Search and Replace Text](/slides/nl/python-java/search-and-replace-text/).

## **Tekst uitlijnen in een tabel**

1. Maak een instantie van de [Presentatie](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/) klasse.  
2. Krijg een referentie naar een dia op basis van de index.  
3. Voeg een [Tabel](https://reference.aspose.com/slides/nl/python-java/aspose.slides/table/) object toe aan de dia.  
4. Toegang tot een [TextFrame](https://reference.aspose.com/slides/nl/python-java/aspose.slides/textframe/) object van de tabel.  
5. Toegang tot het [Paragraph](https://reference.aspose.com/slides/nl/python-java/aspose.slides/paragraph/) van het [TextFrame](https://reference.aspose.com/slides/nl/python-java/aspose.slides/textframe/).  
6. Lijn de tekst verticaal uit.  
7. Sla de gewijzigde presentatie op.

Deze Python-code toont hoe u de tekst in een tabel kunt uitlijnen:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, TextAnchorType, TextVerticalType
from java.awt import Color

    # Maakt een instantie van de Presentation-klasse
    presentation = Presentation()
    try:

        # Haalt de eerste dia op
        slide = presentation.getSlides().get_Item(0)

        # Definieert kolommen met breedtes en rijen met hoogtes
        column_widths = [120, 120, 120, 120]
        row_heights = [100, 100, 100, 100]

        # Voegt de tabelvorm toe aan de dia
        table = slide.getShapes().addTable(100, 50, column_widths, row_heights)
        table.get_Item(1, 0).getTextFrame().setText("10")
        table.get_Item(2, 0).getTextFrame().setText("20")
        table.get_Item(3, 0).getTextFrame().setText("30")

        # Benadert het tekstkader
        text_frame = table.get_Item(0, 0).getTextFrame()

        # Benadert de eerste alinea in het tekstkader.
        paragraph = text_frame.getParagraphs().get_Item(0)

        # Benadert het eerste gedeelte in de alinea.
        portion = paragraph.getPortions().get_Item(0)
        portion.setText("Text here")
        portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
        portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)

        # Lijnt de tekst verticaal uit
        cell = table.get_Item(0, 0)
        cell.setTextAnchorType(TextAnchorType.Center)
        cell.setTextVerticalType(TextVerticalType.Vertical270)

        # Slaat de presentatie op schijf
        presentation.save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()
```

## **Tekstopmaak instellen op tabelniveau**

1. Maak een instantie van de [Presentatie](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/) klasse.  
2. Krijg een referentie naar een dia op basis van de index.  
3. Toegang tot een [Tabel](https://reference.aspose.com/slides/nl/python-java/aspose.slides/table/) object van de dia.  
4. Stel de lettergrootte van de tekst in met [setFontHeight](https://reference.aspose.com/slides/nl/python-java/aspose.slides/baseportionformat/#setFontHeight).  
5. Stel de uitlijning en de rechtermarge in met [setAlignment](https://reference.aspose.com/slides/nl/python-java/aspose.slides/paragraphformat/#setAlignment) en [setMarginRight](https://reference.aspose.com/slides/nl/python-java/aspose.slides/paragraphformat/#setMarginRight).  
6. Stel het verticale teksttype in met [setTextVerticalType](https://reference.aspose.com/slides/nl/python-java/aspose.slides/textframeformat/#setTextVerticalType).  
7. Sla de gewijzigde presentatie op.

Deze Python-code toont hoe u uw gewenste opmaakopties kunt toepassen op de tekst in een tabel:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ParagraphFormat, PortionFormat, Presentation, SaveFormat, TextAlignment, TextFrameFormat, TextVerticalType, Table

# Maakt een instantie van de Presentation-klasse
presentation = Presentation("simpletable.pptx")
try:

    # Laten we aannemen dat de eerste vorm op de eerste dia een tabel is
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(shape, Table):
        table = shape

        # Stelt de letterhoogte van de tabelcellen in
        portion_format = PortionFormat()
        portion_format.setFontHeight(25)
        table.setTextFormat(portion_format)

        # Stelt de tekstuitlijning en rechtermarge van de tabelcellen in één oproep in
        paragraph_format = ParagraphFormat()
        paragraph_format.setAlignment(TextAlignment.Right)
        paragraph_format.setMarginRight(20)
        table.setTextFormat(paragraph_format)

        # Stelt het verticale teksttype van de tabelcellen in
        text_frame_format = TextFrameFormat()
        text_frame_format.setTextVerticalType(TextVerticalType.Vertical)
        table.setTextFormat(text_frame_format)
        presentation.save("result.pptx", SaveFormat.Pptx)
    else:
        print("The first shape is not a table.")
finally:
    presentation.dispose()
```

## **Stijl‑eigenschappen van tabel ophalen**

Aspose.Slides stelt u in staat de stijl‑eigenschappen van een tabel op te halen zodat u die details voor een andere tabel of elders kunt gebruiken. Deze Python-code toont hoe u de stijl‑eigenschappen uit een vooraf ingestelde tabelstijl kunt verkrijgen:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TableStylePreset

presentation = Presentation()
try:
    table = presentation.getSlides().get_Item(0).getShapes().addTable(10, 10, [100, 150], [5, 5, 5])
    table.setStylePreset(TableStylePreset.DarkStyle1)  # verander het standaard stijlvoorinstellingsthema

    # Haalt de stijlvoorinstelling van de tabel op
    style_preset = table.getStylePreset()
    print("Table style preset: ", style_preset)

    # Past de verkregen stijlvoorinstelling toe op een andere tabel
    another_table = presentation.getSlides().get_Item(0).getShapes().addTable(10, 100, [100, 150], [5, 5, 5])
    another_table.setStylePreset(style_preset)
    presentation.save("table.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Verhouding van een tabel vergrendelen**

De beeldverhouding van een geometrische vorm is de verhouding tussen de afmetingen in verschillende dimensies. Aspose.Slides biedt de [setAspectRatioLocked](https://reference.aspose.com/slides/nl/python-java/aspose.slides/graphicalobjectlock/#setAspectRatioLocked) methode om de instelling voor de beeldverhouding van tabellen en andere vormen te vergrendelen.

Deze Python-code toont hoe u de beeldverhouding voor een tabel kunt vergrendelen:

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
        table.getGraphicalObjectLock().setAspectRatioLocked(not table.getGraphicalObjectLock().getAspectRatioLocked())  # omkeren
        print("Lock aspect ratio set: ", table.getGraphicalObjectLock().getAspectRatioLocked())
        presentation.save("pres-out.pptx", SaveFormat.Pptx)
    else:
        print("The first shape is not a table.")
finally:
    presentation.dispose()
```

## **FAQ**

**Kan ik rechts‑naar‑links (RTL) leesrichting inschakelen voor een hele tabel en de tekst in de cellen?**

Ja. De tabel stelt een [setRightToLeft](https://reference.aspose.com/slides/nl/python-java/aspose.slides/table/#setRightToLeft) methode beschikbaar, en alinea’s hebben [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/nl/python-java/aspose.slides/paragraphformat/#setRightToLeft). Het gebruik van beide zorgt voor de correcte RTL‑volgorde en weergave binnen cellen.

**Hoe kan ik voorkomen dat gebruikers een tabel verplaatsen of de grootte wijzigen in het uiteindelijke bestand?**

Gebruik [shape locks](/slides/nl/python-java/applying-protection-to-presentation/) om verplaatsen, herschalen, selecteren, enz. uit te schakelen. Deze vergrendelingen gelden ook voor tabellen.

**Wordt het invoegen van een afbeelding in een cel als achtergrond ondersteund?**

Ja. U kunt een [picture fill](https://reference.aspose.com/slides/nl/python-java/aspose.slides/picturefillformat/) voor een cel instellen; de afbeelding bedekt het celgebied volgens de gekozen modus (strekken of tegel).